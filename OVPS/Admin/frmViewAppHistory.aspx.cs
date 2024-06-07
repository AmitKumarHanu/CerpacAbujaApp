using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using DataAccessLayer;
using System.Data.SqlClient;
using System.IO;


public partial class Admin_frmViewAppHistory : System.Web.UI.Page
{
    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    BaseLayer.General_function objgenenral = null;
    protected DataSet objDs = new DataSet();
    protected DataTable dt = new DataTable();

    protected BaseLayer.General_function ObjGenBal = null;
    string AppID = "";
    string UserID = null;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        if (objectSessionHolderPersistingData == null)
        {
            Response.Redirect("../Login.aspx");
        }
    }
    protected void Go_Click(object sender, EventArgs e)
    {
        if (txtSurname.Text == "" && txtForename.Text == "" && TextAppId.Text == "")
        {
            Response.Write("<script>alert('Please Fill atleast one field');</script>");
            return;
        }
        
        bindGrid();

    }


    public void bindGrid()
    {
        objgenenral = new BaseLayer.General_function();

        string quer = "select a.forename,a.surname,a.cerpac_file_no, a.cerpac_receipt_date,a.cerpac_expiry_date,a.passport_no,ISNULL((CASE (SUBSTRING(a.cerpac_no, 1, 2)) WHEN 'AO' THEN b.company ELSE c.company END), a.verid_template_1) AS Company,a.designation,a.cerpac_no,a.nationality from People a left join CompMaster b on a.company=b.regno LEFT OUTER JOIN CompMasterForARCR c ON a.company = c.Regno where a.cerpac_no is not null";


        if (txtSurname.Text != "")
        {
            if (Rd1Match.Checked == true)
                quer = quer + " and a.surname='" + txtSurname.Text + "'";
            else if (Rd2Start.Checked == true)
                quer = quer + " and a.surname like '" + txtSurname.Text + "%'";
            else if (Rd3Any.Checked == true)
                quer = quer + " and a.surname like '%" + txtSurname.Text + "%'";

        }

        if (txtForename.Text != "")
        {
            if (Rd1Match.Checked == true)
                quer = quer + " and a.forename='" + txtForename.Text + "'";
            else if (Rd2Start.Checked == true)
                quer = quer + " and a.forename like '" + txtForename.Text + "%'";
            else if (Rd3Any.Checked == true)
                quer = quer + " and a.forename like '%" + txtForename.Text + "%'";


        }

        if (TextAppId.Text != "")
        {
            if (Rd1Match.Checked == true)
                quer = quer + " and a." + dropdown_SearchOption.SelectedValue + "='" + TextAppId.Text + "'";
            else if (Rd2Start.Checked == true)
                quer = quer + " and a." + dropdown_SearchOption.SelectedValue + " like '" + TextAppId.Text + "%'";
            else if (Rd3Any.Checked == true)
                quer = quer + " and a." + dropdown_SearchOption.SelectedValue + " like '%" + TextAppId.Text + "%'";

        }

        DataTable dt_result = new DataTable();
        dt_result = objgenenral.FetchData(quer);


        if (dt_result.Rows.Count == 0)
        {
            warn.Style.Add("display", "");
            grd_display_data.DataSource = dt_result;
            grd_display_data.DataBind();
            warn.InnerText = "No History Found";
        }
        else
        {
            warn.Style.Add("display", "none");
            grd_display_data.DataSource = dt_result;
            grd_display_data.DataBind();
        }
    }

    protected void grd_display_data_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grd_display_data.PageIndex = e.NewPageIndex;
        bindGrid();
    }

    private void GetData(string ApplicationId)
    {
        DataTable Dt = null;
        Dt = new DataTable();
        ObjGenBal = new BaseLayer.General_function();
        // string queryforcerpac = "select a.*,b.* from People as a , PeopleChild as b where a.cerpac_no = b.CerpacNo and (IsVerified=1) and a.cerpac_no='" + ApplicationId.ToString() + "'";

       // string queryforcerpac = "select * from vw_prod_consolidated_data where cerpac_no='" + ApplicationId.ToString() + "'";
        string queryforcerpac = "select * from people where cerpac_no='" + ApplicationId.ToString() + "'";
        Dt = ObjGenBal.FetchData(queryforcerpac);
        Session["Card"] = Dt;
        if (Dt.Rows.Count > 0)
        {
            /*****************************Retrieve Image****************************/
            byte[] picData = Dt.Rows[0]["userimage"] as byte[] ?? null;
            System.Drawing.Image newImage;
            if (picData != null)
            {
                using (MemoryStream ms = new MemoryStream(picData))
                {
                    // Load the image from the memory stream. How you do it depends
                    // on whether you're using Windows Forms or WPF.
                    // For Windows Forms you could write:
                    // System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(ms);

                    newImage = System.Drawing.Image.FromStream(ms);

                    if (Dt.Rows[0]["picture"] == null || Dt.Rows[0]["picture"].ToString() == "")
                        Dt.Rows[0]["picture"] = Dt.Rows[0]["cerpac_no"] + ".jpg";

                    if (!File.Exists(Server.MapPath("~") + "/Images/Logo/" + Dt.Rows[0]["picture"].ToString().Trim()))
                        newImage.Save(Server.MapPath("~") + "/Images/Logo/" + Dt.Rows[0]["picture"].ToString().Trim());
                    // newImage.Save("g:/Saurabh" + Dt.Rows[0]["picture"].ToString().Trim());

                }
            }
            /*******************************End************************************/
            ImgPhoto.ImageUrl = "~/Images/Logo/" + Dt.Rows[0]["picture"].ToString().Trim();

            TxtPassportNo.Text = Dt.Rows[0]["passport_no"].ToString().Trim();
            TxtNationality.Text = string.Format("{0:dd/MM/yy}", Dt.Rows[0]["nationality"]).ToString().Trim();
            TxtPassportType.Text = string.Format("{0:dd/MM/yy}", Dt.Rows[0]["passport_issue_by"]).ToString().Trim();
            TxtDateOfIssue.Text = string.Format("{0:dd/MM/yy}", Dt.Rows[0]["passport_issue_date"]).ToString().Trim();
            txtdoe.Text = string.Format("{0:dd/MM/yy}", Dt.Rows[0]["passport_expiry_date"]).ToString().Trim();
            TxtPlaceOfIssue.Text = Dt.Rows[0]["passport_issue_loc"].ToString().Trim();
            TxtFirstName.Text = Dt.Rows[0]["forename"].ToString().Trim();
            TxtMiddleName.Text = Dt.Rows[0]["middle_name"].ToString().Trim();
            TxtLastName.Text = Dt.Rows[0]["surname"].ToString().Trim();
            //============================ fetching the code for the company======================
            if (Dt.Rows[0]["company"] != null && Dt.Rows[0]["company"].ToString().Trim() != "")
            {
                txtcompid.Text = Dt.Rows[0]["company"].ToString().Trim();
            }
            else if (Dt.Rows[0]["verid_template_1"] != null && Dt.Rows[0]["verid_template_1"].ToString().Trim() != "")
            {
                oldcompanyname.InnerHtml = Dt.Rows[0]["verid_template_1"].ToString().Trim();
                txtcompid.Text = "";
            }
            else
            {
                oldcompanyname.InnerHtml = "";
                txtcompid.Text = "";
            }

            //==========================================end======================================
            DataTable ds_comp = new DataTable();
            ds_comp = ObjGenBal.FetchData("select isnull(company,'') as company from compmaster where regno='" + txtcompid.Text + "'");

            if (ds_comp.Rows.Count > 0)
                txtcompname.Text = ds_comp.Rows[0]["company"].ToString().Trim();
            else
                txtcompname.Text = "";


            txtcompadd1.Text = Dt.Rows[0]["company_add_1"].ToString().Trim();
            txtcompadd2.Text = Dt.Rows[0]["company_add_2"].ToString().Trim();
            txtdesig.Text = Dt.Rows[0]["designation"].ToString().Trim();
            txtphno.Text = Dt.Rows[0]["company_tel_no"].ToString().Trim();
            txtfaxno.Text = Dt.Rows[0]["company_fax_no"].ToString().Trim();
            txtfileno.Text = Dt.Rows[0]["cerpac_file_no"].ToString().Trim();
            txtemailprsn.Text = Dt.Rows[0]["email"].ToString().Trim();
            txtcntcnoprsn.Text = Dt.Rows[0]["ContactNo"].ToString().Trim();
            if (Dt.Rows[0]["sex"].ToString().Trim() == "F")
            {
                TxtSex.Text = "Female";
            }
            else
            {
                TxtSex.Text = "Male";
            }
            TxtCerpacNo.Text = Dt.Rows[0]["cerpac_no"].ToString().Trim();

            if (Dt.Rows[0]["cerpac_receipt_date"].ToString().Trim() != null || Dt.Rows[0]["cerpac_receipt_date"].ToString().Trim() != "")
            {
                TxtIssueDate.Text = string.Format("{0:dd/MM/yy}", Dt.Rows[0]["cerpac_receipt_date"]).ToString().Trim();
                TxtExpDate.Text = string.Format("{0:dd/MM/yy}", Dt.Rows[0]["cerpac_expiry_date"]).ToString().Trim();
            }
            else
            {
                TxtIssueDate.Text = "-----";
                TxtExpDate.Text = "-----";
            }

            detailtable.Style.Add("display", "");
            warn.Style.Add("display", "none");
            div_grd.Style.Add("display", "none");
            //tr_msg.Style.Add("display", "none");

            tr_ser.Style.Add("display", "none");
            tr_ser1.Style.Add("display", "none");
            tr1.Style.Add("display", "none");


        }
        else
        {
            detailtable.Style.Add("display", "none");
            warn.Style.Add("display", "");
        }

    }


    protected void grd_display_data_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            //  e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
            e.Row.ToolTip = "Click to select row";
            e.Row.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.grd_display_data, "Select$" + e.Row.RowIndex);
        }
    }
    protected void grd_display_data_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = grd_display_data.SelectedRow;

        GetData(row.Cells[4].Text);
        btn_back.Visible = true;
    }

    protected void btn_back_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmViewAppHistory.aspx");
    }
    protected void btnapphis_Click(object sender, EventArgs e)
    {
        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "Onclick", "<script>window.open('viewAppliHist.aspx?AppID=" + TxtCerpacNo.Text.ToString() + "','PaperVisa','menubar=no,status=yes,Width=1320,Height=1120,top=50,left=5,scrollbar=yes');</script>");
    }
}