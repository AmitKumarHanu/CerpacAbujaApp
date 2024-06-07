using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Threading;
using System.Globalization;
using System.IO;


public partial class Bank_VerifyUploadBankData : System.Web.UI.Page
{
    BusinessEntityLayer.BankUserData ObjFetchData = null;
    BaseLayer.General_function ObjGeneral = null;

    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    BaseLayer.General_function objgenenral = null;
   // BaseLayer.General_function ObjGeneral = null;
    protected BaseLayer.General_function ObjGenBal = null;

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            BaseLayer.General_function ObjGeneral = new BaseLayer.General_function();
            objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];


            if (objectSessionHolderPersistingData == null)
            {
                Response.Redirect("../Login.aspx");
            }

            Session["display"] = 0;
            Session["count"] = 0;
            if (!IsPostBack)
            {
                // string script = "$(document).ready(function () { $('[id*=btn_verify]').click(); });";
                // ClientScript.RegisterStartupScript(this.GetType(), "load", script, true);

                Bindlist();
            }
        }
        catch (Exception ex)
        {
            Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            ObjGenBal = new BaseLayer.General_function();
            string err = ObjGenBal.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.CssClass = "warning-box";
        }
        finally
        {
            ObjGenBal = null;

        }
        
    }


    protected void Bindlist()
    {
        try
        {
            ObjGeneral = new BaseLayer.General_function();
            string queryforposition;
            if (string.IsNullOrEmpty(Request.QueryString["con"]) == false && Request.QueryString["con"] != "")
            {
                queryforposition = "select (CASE WHEN (cerpacNo IS NULL) THEN 'false' ELSE 'false' END) AS Exist,* from correct_bank_data";

                spn.InnerText = "Pending Manual Corrections";

                btn_verify.Visible = false;
                btnMannual.Visible = true;

            }
            else
            {
                queryforposition = "select (CASE WHEN (cerpacNo IS NULL) THEN 'false' ELSE 'false' END) AS Exist,* from temp_bank_data";
                spn.InnerText = "Verify Uploaded Data";

                btn_verify.Visible = true;

            }
            // string queryforposition = "SELECT * from vwDisplayVerifiedData";

            DataTable dt1 = new DataTable();
            dt1 = ObjGeneral.FetchData(queryforposition);

            if (dt1.Rows.Count > 0)
            {
                grd_display_data.DataSource = dt1;
                grd_display_data.DataBind();
                grd_display_data.Columns[16].Visible = false;
            }
            else
            {
                // dt1.Rows.Add(dt1.NewRow());
                grd_display_data.Visible = false;

                confirm.Style.Add("display", "none");
                warn.Style.Add("display", "");
                //  warn.InnerText = "Data Uploading Process Over Press to Continue";

                grd_display_data.DataSource = dt1;
                grd_display_data.DataBind();
                grd_display_data.Columns[16].Visible = false;
                btn_verify.Visible = false;
                //int columncount = grd_display_data.Rows[0].Cells.Count;
                //grd_display_data.Rows[0].Cells.Clear();
                //grd_display_data.Rows[0].Cells.Add(new TableCell());
                //grd_display_data.Rows[0].Cells[0].ColumnSpan = columncount;
                //grd_display_data.Rows[0].Cells[0].Text = "No Records Found";
            }
        }
        catch (Exception ex)
        {
            Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            ObjGenBal = new BaseLayer.General_function();
            string err = ObjGenBal.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.CssClass = "warning-box";
        }
        finally
        {
            ObjGenBal = null;

        }
    }


    protected void BindVerifylist()
    {
        try
        {
            ObjGeneral = new BaseLayer.General_function();
            string queryforposition;
            // string queryforposition = "select (CASE WHEN (cerpacNo IS NULL) THEN 'false' ELSE 'false' END) AS Exist,* from temp_bank_data";
            if (string.IsNullOrEmpty(Request.QueryString["con"]) == false && Request.QueryString["con"] != "")
            {
                queryforposition = "SELECT * from vwDisplayDataForCorrections";
            }
            else
            {
                queryforposition = "SELECT * from vwDisplayVerifiedData";
            }


            DataTable dt1 = new DataTable();
            dt1 = ObjGeneral.FetchData(queryforposition);

            if (dt1.Rows.Count > 0)
            {
                grd_display_data.DataSource = dt1;
                grd_display_data.DataBind();
                grd_display_data.Columns[16].Visible = true;
            }
            else
            {
                // dt1.Rows.Add(dt1.NewRow());
                grd_display_data.DataSource = dt1;
                grd_display_data.DataBind();
                //int columncount = grd_display_data.Rows[0].Cells.Count;
                //grd_display_data.Rows[0].Cells.Clear();
                //grd_display_data.Rows[0].Cells.Add(new TableCell());
                //grd_display_data.Rows[0].Cells[0].ColumnSpan = columncount;
                //grd_display_data.Rows[0].Cells[0].Text = "No Records Found";
                grd_display_data.Columns[16].Visible = true;
                btn_verify.Visible = false;

            }
        }
        catch (Exception ex)
        {
            Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            ObjGenBal = new BaseLayer.General_function();
            string err = ObjGenBal.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.CssClass = "warning-box";
        }
        finally
        {
            ObjGenBal = null;

        }

    }


    protected void btn_submit_Click(object sender, EventArgs e)
    {
        try
        {
            BusinessEntityLayer.BankRegDetails objDetails = new BusinessEntityLayer.BankRegDetails();
            int res = 0;
            double Num;
            bool isNum;

            //string queryforposition = "SELECT * from vwDisplayVerifiedData";
            //ObjGeneral = new BaseLayer.General_function();
            //DataTable dt1 = new DataTable();
            //dt1 = ObjGeneral.FetchData(queryforposition);

            grd_display_data.AllowPaging = false;
            BindVerifylist();
            grd_display_data.AllowPaging = false;

            int cnt = grd_display_data.Rows.Count;
            // for (int i = 0; i < cnt; i++)
            int i = 0;
            while (cnt != 0)
            {
               
                // for(int j=3; j<grd_display_data.Rows[i].Cells.Count;j++)
                // if (grd_display_data.Rows[i].Cells[3].Text == "true")
                {

                    //objDetails.BankDate = grd_display_data.Rows[i].Cells[12].Text;
                    objDetails.BankDate = ConvertDate(grd_display_data.Rows[i].Cells[12].Text.ToString(), "d-MM-yyyy");
                    objDetails.Branch = grd_display_data.Rows[i].Cells[11].Text;
                    objDetails.ReqNo = grd_display_data.Rows[i].Cells[6].Text;
                    // objDetails.PassportNo = grd_display_data.Rows[i].Cells[13].Text;
                    objDetails.PassportNo = "";
                    objDetails.FirstName = grd_display_data.Rows[i].Cells[1].Text;

                    //objDetails.MiddleName = grd_display_data.Rows[i].Cells[2].Text;
                    objDetails.MiddleName = "";
                    objDetails.LastName = grd_display_data.Rows[i].Cells[3].Text;
                    objDetails.Company = grd_display_data.Rows[i].Cells[4].Text;
                    objDetails.Nationality = grd_display_data.Rows[i].Cells[5].Text;
                    objDetails.CerpacNo = grd_display_data.Rows[i].Cells[8].Text;
                    objDetails.FormNo = grd_display_data.Rows[i].Cells[7].Text;
                    objDetails.TellerNo = grd_display_data.Rows[i].Cells[9].Text;
                    objDetails.Amount = Convert.ToDecimal(grd_display_data.Rows[i].Cells[10].Text);
                    //  objDetails.StrVisaNo = grd_display_data.Rows[i].Cells[14].Text;
                    objDetails.StrVisaNo = "";
                    objDetails.CreatedBy = Convert.ToInt32(objectSessionHolderPersistingData.User_ID);

                    isNum = double.TryParse(grd_display_data.Rows[i].Cells[7].Text.Remove(0, 2), out Num);
                    objDetails.Condition = 3;

                    if ((objDetails.FormNo.Substring(0, 2) == "AO" || objDetails.FormNo.Substring(0, 2) == "AR" || objDetails.FormNo.Substring(0, 2) == "CR") && (objDetails.FormNo.Length == 8) && isNum == true)
                        res = objDetails.BankDetailsUpload();

               //     Bindlist();

                 //   cnt = grd_display_data.Rows.Count;
                    cnt = cnt - 1;
                    i = i + 1;
                    
                }

               
            }
            Bindlist();
            btn_submit.Visible = false;
            confirm.Style.Add("display", "none");
            warn.Style.Add("display", "");

            //if (res == 1)
            //{
            //    Response.Write("<script>alert('Verified Data Upload Successfully.');</script>");
            //    //Response.Redirect("~/BankLogin.aspx");
            //}
            //else
            //{
            //    Response.Write("<script>alert('Upload Error.');</script>");
            //}
        }
        catch (Exception ex)
        {
            Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            ObjGenBal = new BaseLayer.General_function();
            string err = ObjGenBal.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.CssClass = "warning-box";
        }
        finally
        {
            ObjGenBal = null;

        }

    }
    protected void grd_display_data_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            //foreach (GridViewRow row in grd_display_data.Rows)
            //{
            //    CheckBox cb = (CheckBox)grd_display_data.Rows[row].Cells[0].FindControl("chkbox");

            //    if (cb.Checked == true)
            //        cb.Enabled = false;
            //}

            double Num;
            bool isNum;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                isNum = double.TryParse(e.Row.Cells[7].Text.Remove(0, 2), out Num);
                if (e.Row.Cells[7].Text != "" && e.Row.Cells[7].Text.Substring(0, 2) != "AO" && e.Row.Cells[7].Text.Substring(0, 2) != "AR" && e.Row.Cells[7].Text.Substring(0, 2) != "CR" || e.Row.Cells[7].Text.Length != 8)
                {
                    e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";

                    e.Row.ToolTip = "Click to select row";
                    e.Row.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.grd_display_data, "Select$" + e.Row.RowIndex);
                }

            }

            foreach (GridViewRow di in grd_display_data.Rows)
            {
                CheckBox chkBx = (CheckBox)di.FindControl("chkbox");
                Image img = (Image)di.FindControl("Image1");



                isNum = double.TryParse(di.Cells[7].Text.Remove(0, 2), out Num);
                //if (chkBx != null && chkBx.Checked == true)

                if (chkBx != null)
                {
                    /// put your code here
                    /// 

                    if (chkBx.Checked == true)
                    {
                        chkBx.Enabled = false;
                        img.ImageUrl = "~/Images/Delete.png";
                        img.AlternateText = "Already Uploaded";
                        // btn_submit.Enabled = false;
                        // btn_submit.Visible = false;

                        //  Session["count"] = Convert.ToInt32(Session["count"].ToString()) + 1;
                    }
                    else
                    {
                        if (di.Cells[7].Text.Substring(0, 2) != "AO" && di.Cells[7].Text.Substring(0, 2) != "AR" && di.Cells[7].Text.Substring(0, 2) != "CR" || di.Cells[7].Text.Length != 8 || isNum == false)
                        {
                            img.ImageUrl = "~/Images/Edit-icon.png";
                            img.AlternateText = "To Be Uploaded";
                        }
                        else
                        {
                            img.ImageUrl = "~/Images/tick_64.png";
                            img.AlternateText = "To Be Uploaded";
                        }
                        if (Session["display"].ToString() == "1")
                        {
                            btn_submit.Enabled = true;
                            btn_submit.Visible = true;
                            btn_verify.Visible = false;
                        }
                    }

                    //if (e.Row.RowType == DataControlRowType.DataRow)
                    //{
                    //    if (e.Row.Cells[7].Text != "" && e.Row.Cells[7].Text.Substring(0, 2) != "AO" && e.Row.Cells[7].Text.Substring(0, 2) != "AR" && e.Row.Cells[7].Text.Substring(0, 2) != "CR")
                    //    {
                    //        e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                    //        //  e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
                    //        e.Row.ToolTip = "Click to select row";
                    //        e.Row.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.grd_display_data, "Select$" + e.Row.RowIndex);
                    //    }

                    //}
                }
            }
        }
        catch (Exception ex)
        {
            Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            ObjGenBal = new BaseLayer.General_function();
            string err = ObjGenBal.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.CssClass = "warning-box";
        }
        finally
        {
            ObjGenBal = null;

        }
    }
    protected void btn_verify_Click(object sender, EventArgs e)
    {
        try
        {
            //TreeView tvleft = (TreeView)this.Page.Master.FindControl("TVLeftMenu");
            //tvleft.Enabled = false;
            hid.Value = "0";
            BusinessEntityLayer.BankRegDetails objDetails = new BusinessEntityLayer.BankRegDetails();

            //modal.Attributes.("class") = "";
            int res = 0;
            Session["display"] = 1;
            Session["count"] = 0;
            BindVerifylist();
            // grd_display_data.Columns[16].Visible = true;
            string queryforposition;

            if (string.IsNullOrEmpty(Request.QueryString["con"]) == false && Request.QueryString["con"] != "")
            {
                queryforposition = "SELECT * from vwDisplayDataForCorrections";
            }
            else
            {
                queryforposition = "SELECT * from vwDisplayVerifiedData";
            }

            Session["needchange"] = "";
            DataTable dt1 = new DataTable();
            dt1 = ObjGeneral.FetchData(queryforposition);
            grd_display_data.AllowPaging = false;
            BindVerifylist();
            //  for (int i = 0; i < grd_display_data.Rows.Count; i++)
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                // for(int j=3; j<grd_display_data.Rows[i].Cells.Count;j++)
                // if (grd_display_data.Rows[i].Cells[3].Text == "true")
                {
                    //  BindVerifylist();

                    objDetails.BankDate = ConvertDate(grd_display_data.Rows[i].Cells[12].Text.ToString(), "d-MM-yyyy");
                    objDetails.Branch = grd_display_data.Rows[i].Cells[11].Text;
                    objDetails.ReqNo = grd_display_data.Rows[i].Cells[6].Text;
                    objDetails.PassportNo = grd_display_data.Rows[i].Cells[13].Text;
                    objDetails.FirstName = grd_display_data.Rows[i].Cells[1].Text;
                    objDetails.MiddleName = grd_display_data.Rows[i].Cells[2].Text;
                    objDetails.LastName = grd_display_data.Rows[i].Cells[3].Text;
                    objDetails.Company = grd_display_data.Rows[i].Cells[4].Text;
                    objDetails.Nationality = grd_display_data.Rows[i].Cells[5].Text;
                    objDetails.CerpacNo = grd_display_data.Rows[i].Cells[8].Text;
                    objDetails.FormNo = grd_display_data.Rows[i].Cells[7].Text;
                    objDetails.TellerNo = grd_display_data.Rows[i].Cells[9].Text;
                    objDetails.Amount = Convert.ToDecimal(grd_display_data.Rows[i].Cells[10].Text);
                    objDetails.StrVisaNo = grd_display_data.Rows[i].Cells[14].Text;
                    objDetails.CreatedBy = Convert.ToInt32(objectSessionHolderPersistingData.User_ID);


                    double Num;
                    bool isNum = double.TryParse(objDetails.FormNo.Remove(0, 2), out Num);

                    if (objDetails.FormNo.Substring(0, 2).ToUpper() == "A0")
                    {
                        btnA0AO.Visible = true;
                        if (string.IsNullOrEmpty(Request.QueryString["con"]) == false && Request.QueryString["con"] != "")
                        {
                            btnCorrectLater.Visible = false;
                        }
                        else
                        {
                            btnCorrectLater.Visible = true;
                        }
                    }
                    if (objDetails.FormNo.Substring(0, 2).ToUpper() != "AO" && objDetails.FormNo.Substring(0, 2).ToUpper() != "AR" && objDetails.FormNo.Substring(0, 2).ToUpper() != "CR" || objDetails.FormNo.Length != 8 || isNum == false)
                    {
                        Session["needchange"] = Session["needchange"].ToString() + "#" + objDetails.FormNo;
                        btnMannual.Visible = true;
                        if (string.IsNullOrEmpty(Request.QueryString["con"]) == false && Request.QueryString["con"] != "")
                        {
                            btnCorrectLater.Visible = false;
                        }
                        else
                        {
                            btnCorrectLater.Visible = true;
                        }
                    }

                    if (grd_display_data.Rows[i].Cells[16].Text == "true")
                        Session["count"] = Convert.ToInt32(Session["count"].ToString()) + 1;

                    objDetails.Condition = 2;


                    //  BindVerifylist();
                }

            }
            grd_display_data.AllowPaging = true;
            BindVerifylist();
            grd_display_data.Columns[16].Visible = false;

            //comment on 9Sep after discussion Sanjay Sirhttp://localhost:24318/OVPS/Bank/EditUploadedData.aspx
            // confirm.Style.Add("display", "");

            string[] change = Session["needchange"].ToString().Split('#');



            if (((dt1.Rows.Count - Convert.ToInt32(Session["count"].ToString())) == 0) || change.Length > 1)
                btn_submit.Visible = false;
            else
                btn_submit.Visible = true;

            // confirm.InnerText = "";
            string alert = "";
            confirm.InnerHtml = "<p style='color:#006600'><strong>";
            if (Session["count"].ToString() != "0")
            {
                alert = alert + Session["count"].ToString() + " records already Uploaded.  \\n";
                confirm.InnerHtml = confirm.InnerHtml + Session["count"].ToString() + " records already Uploaded. <br/> ";

            }

            if ((dt1.Rows.Count - Convert.ToInt32(Session["count"].ToString())) != 0)
            {
                alert = alert + "Total " + (dt1.Rows.Count - Convert.ToInt32(Session["count"].ToString())) + " records will be uploaded. \\n";
                confirm.InnerHtml = confirm.InnerHtml + (dt1.Rows.Count - Convert.ToInt32(Session["count"].ToString())) + " records to be uploaded. <br/> ";
            }

            if ((change.Length - 1) != 0)
            {
                alert = alert + (change.Length - 1) + " records needs correction.";
                confirm.InnerHtml = confirm.InnerHtml + (change.Length - 1) + " records need to be change.";
            }

            confirm.InnerHtml = confirm.InnerHtml + "</strong></p>";
            confirm.InnerHtml = (confirm.InnerText).Replace("hhh", Session["count"].ToString() + " records already Uploaded. <br/> " + (dt1.Rows.Count - Convert.ToInt32(Session["count"].ToString())) + " records to be uploaded. <br/> " + (change.Length - 1) + " records need to be change.");
            // Response.Write("<script>alert('hi');</script>");
            ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('" + alert + "');", true);

            hid.Value = "";
        }
        catch (Exception ex)
        {
            Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            ObjGenBal = new BaseLayer.General_function();
            string err = ObjGenBal.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.CssClass = "warning-box";
        }
        finally
        {
            ObjGenBal = null;

        }
    }

    public static string ConvertDate(string date, string pattern)
    {

        if (string.IsNullOrEmpty(date) == false && date != "")
        {
            DateTime date2;
            if (DateTime.TryParseExact(date, pattern, CultureInfo.InvariantCulture, DateTimeStyles.None, out date2))
            {
                return date2.ToString("MM/d/yyyy");
            }
            else
            {
                return "";
            }
        }
        else
        {
            return "";
        }
    }

    protected void grd_display_data_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (btn_verify.Visible == true)
        {
            grd_display_data.PageIndex = e.NewPageIndex;
            Bindlist();

        }

        else
        {
            grd_display_data.PageIndex = e.NewPageIndex;
            BindVerifylist();

            grd_display_data.Visible = true;
        }
    }
    protected void grd_display_data_RowCreated(object sender, GridViewRowEventArgs e)
    {
       
    }
    protected void grd_display_data_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = grd_display_data.SelectedRow;
      //  Response.Redirect("EditUploadedData.aspx?CerpacNo=" + row.Cells[7].Text);

        if (string.IsNullOrEmpty(Request.QueryString["con"]) == false && Request.QueryString["con"] != "")
        {
            Response.Redirect("EditUploadedData.aspx?CerpacNo=" + row.Cells[7].Text + "&cond=5");
        }
        else
        {
            Response.Redirect("EditUploadedData.aspx?CerpacNo=" + row.Cells[7].Text + "&cond=2");
        }
    }

    protected void grd_display_data_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {

    }

    protected void btnA0AO_Click(object sender, EventArgs e)
    {
        //Server.Transfer("BankAll.aspx");

        Response.Redirect("BankAll.aspx?cond=1");
    }
    protected void btnMannual_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Request.QueryString["con"]) == false && Request.QueryString["con"] != "")
        {
            Response.Redirect("BankAll.aspx?cond=5");

        }
        else
        {
            Response.Redirect("BankAll.aspx?cond=2");
        }
    }
    protected void btnCorrectLater_Click(object sender, EventArgs e)
    {
        try
        {
            BusinessEntityLayer.BankRegDetails objDetails = new BusinessEntityLayer.BankRegDetails();
            int res = 0;

            //string queryforposition = "SELECT * from vwDisplayVerifiedData";
            //ObjGeneral = new BaseLayer.General_function();
            //DataTable dt1 = new DataTable();
            //dt1 = ObjGeneral.FetchData(queryforposition);

            grd_display_data.AllowPaging = false;
            BindVerifylist();
            grd_display_data.AllowPaging = false;

            int cnt = grd_display_data.Rows.Count;
            // for (int i = 0; i < cnt; i++)
            int i = 0;
            while (cnt != 0)
            {

                // for(int j=3; j<grd_display_data.Rows[i].Cells.Count;j++)
                // if (grd_display_data.Rows[i].Cells[3].Text == "true")
                {

                    //objDetails.BankDate = grd_display_data.Rows[i].Cells[12].Text;
                    objDetails.BankDate = ConvertDate(grd_display_data.Rows[i].Cells[12].Text.ToString(), "d-MM-yyyy");
                    objDetails.Branch = grd_display_data.Rows[i].Cells[11].Text;
                    objDetails.ReqNo = grd_display_data.Rows[i].Cells[6].Text;
                    // objDetails.PassportNo = grd_display_data.Rows[i].Cells[13].Text;
                    objDetails.PassportNo = "";
                    objDetails.FirstName = grd_display_data.Rows[i].Cells[1].Text;

                    //objDetails.MiddleName = grd_display_data.Rows[i].Cells[2].Text;
                    objDetails.MiddleName = "";
                    objDetails.LastName = grd_display_data.Rows[i].Cells[3].Text;
                    objDetails.Company = grd_display_data.Rows[i].Cells[4].Text;
                    objDetails.Nationality = grd_display_data.Rows[i].Cells[5].Text;
                    objDetails.CerpacNo = grd_display_data.Rows[i].Cells[8].Text;
                    objDetails.FormNo = grd_display_data.Rows[i].Cells[7].Text;
                    objDetails.TellerNo = grd_display_data.Rows[i].Cells[9].Text;
                    objDetails.Amount = Convert.ToDecimal(grd_display_data.Rows[i].Cells[10].Text);
                    //  objDetails.StrVisaNo = grd_display_data.Rows[i].Cells[14].Text;
                    objDetails.StrVisaNo = "";
                    objDetails.CreatedBy = Convert.ToInt32(objectSessionHolderPersistingData.User_ID);


                    objDetails.Condition = 10;


                    double Num;
                    bool isNum = double.TryParse(objDetails.FormNo.Remove(0, 2), out Num);


                    if (objDetails.FormNo.Substring(0, 2) != "AO" && objDetails.FormNo.Substring(0, 2) != "AR" && objDetails.FormNo.Substring(0, 2) != "CR" || objDetails.FormNo.Length != 8 || isNum == false)
                        res = objDetails.BankDetailsUpload();

                    ////Bindlist();
                    ////cnt = grd_display_data.Rows.Count;
                    i = i + 1;
                    cnt = cnt - 1;
                    //confirm.InnerText = "Data Uploaded Successfully";
                    btn_submit.Visible = false;
                    confirm.Style.Add("display", "");
                    warn.Style.Add("display", "none");

                    confirm.InnerText = "Data Successfully Moved For Later Corrections";

                }
            }


        }
        catch (Exception ex)
        {
            Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            ObjGenBal = new BaseLayer.General_function();
            string err = ObjGenBal.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.CssClass = "warning-box";
        }
        finally
        {
            ObjGenBal = null;

        }
    }

}