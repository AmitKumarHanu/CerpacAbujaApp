using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_FrmConfirmListAO : System.Web.UI.Page
{
    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    BaseLayer.General_function objgenenral = null;
    protected DataTable dt = new DataTable();
    protected DataSet objDs = new DataSet();
    BusinessEntityLayer.BalApprovalReviewL1 ObjbalApporvalL1 = null;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        if (objectSessionHolderPersistingData == null)
        {
            Response.Redirect("../Login.aspx");
        }

       // if (!IsPostBack)
       // {
            bindgrid();
     //   }
    }

    protected void bindgrid()
    {
        objgenenral = new BaseLayer.General_function();
        // string queryforgrid = "select a.cerpac_no,(a.forename+' '+a.surname)as Name,a.passport_no from People as a , PeopleChild as b where a.cerpac_no = b.CerpacNo and b.IsVerified=1 and b.IsAuthorized=1 and (ISARCR=0 or ISARCR is null)";
       // string queryforgrid = "select a.cerpac_no,b.FormNo,(a.forename+' '+a.surname)as Name,a.passport_no,a.designation,nationality,ISNULL((CASE (SUBSTRING(a.cerpac_no, 1, 2)) WHEN 'AO' THEN c.company ELSE d.company END), a.verid_template_1) AS Company from People as a left join CompMaster c on a.company=c.regno LEFT OUTER JOIN CompMasterForARCR d ON a.company = d.Regno , PeopleChild as b  where a.cerpac_no = b.CerpacNo and b.IsVerified=1 and b.IsAuthorized=1 and (ISARCR=0 or ISARCR is null) and FORMNO Like 'AO%'";

        string queryforgrid = "select  distinct(cerpac_file_no),cerpac_no, (first_name +' '+last_name )as Name from people_wrong_forms_used_details"; 
        DataTable dt = new DataTable();
        dt = objgenenral.FetchData(queryforgrid);
        if (dt.Rows.Count > 0)
        {
            GridViewCntcAuthAO.DataSource = dt;
            GridViewCntcAuthAO.DataBind();
        }
    }

    protected void Go_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(500);
        objgenenral = new BaseLayer.General_function();
        string quer = "select cerpac_no from people_wrong_forms_used_details where cerpac_file_no='" + TextAppId.Text.ToString() + "'";
        DataTable dt = new DataTable();
        dt = objgenenral.FetchData(quer);
       
        DataTable dtuser = new DataTable();
        if (dt.Rows.Count > 0 )
        {
            string CerpacNo = dt.Rows[0]["cerpac_no"].ToString();
            Response.Redirect("FrmDenialRemark.aspx?FRN=" + TextAppId.Text.ToString() + "&CerpacNo=" + CerpacNo +"");
        }      
        else
        {
            lblmsg.Text = "This form Number does not exists.Please check the number and try again";
            lblmsg.CssClass = "error-box";

        }
    }
    protected void chkAccessAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkGV;
        CheckBox chk = ((CheckBox)sender);
        string ChkName = chk.ID;
        ChkName = ChkName.Substring(0, ChkName.Length - 6);
        foreach (GridViewRow gv in GridViewCntcAuthAO.Rows)
        {
            chkGV = (CheckBox)gv.FindControl("CheckBox1");
            chkGV.Checked = chk.Checked;

        }

    }
    public void getRec(string cer)
    {
        System.Threading.Thread.Sleep(500);
        objgenenral = new BaseLayer.General_function();
        string quer = "select cerpac_no from people_wrong_forms_used_details where cerpac_file_no='" + cer.ToString() + "'";
        DataTable dt = new DataTable();
        dt = objgenenral.FetchData(quer);

        DataTable dtuser = new DataTable();
        if (dt.Rows.Count > 0)
        {
            string CerpacNo = dt.Rows[0]["cerpac_no"].ToString();
            Response.Redirect("FrmDenialRemark.aspx?FRN=" + cer.ToString() + "&CerpacNo=" + CerpacNo + "");
        }
        else
        {
            lblmsg.Text = "This form Number does not exists.Please check the number and try again";
            lblmsg.CssClass = "error-box";

        }
    }

    protected void GridViewCntcAuthAO_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridViewCntcAuthAO.EditIndex = e.NewEditIndex;

        Label lblcerpacno = (Label)GridViewCntcAuthAO.Rows[GridViewCntcAuthAO.EditIndex].FindControl("lblcerpacno");

        string keyvalue = lblcerpacno.Text.ToString();
        TextAppId.Text = keyvalue.ToString();
        GridViewCntcAuthAO.Style.Add("display", "none");
        //   Response.Redirect("AuthorizationDetails.aspx?no="+keyvalue.ToString()+"");

    }

    protected void GridViewCntcAuthAO_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        GridViewCntcAuthAO.PageIndex = e.NewPageIndex;
        bindgrid();
    }


    protected void GridViewCntcAuthAO_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            //e.Row.ToolTip = "Click to select row";
            //e.Row.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.GridViewAuth, "Select$" + e.Row.RowIndex);


            e.Row.Cells[0].Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Cells[1].Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Cells[2].Attributes["onmouseover"] = "this.style.cursor='pointer';";
           

            //  e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
            e.Row.ToolTip = "Click to select row";
            e.Row.Cells[0].Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.GridViewCntcAuthAO, "Select$" + e.Row.RowIndex);
            e.Row.Cells[1].Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.GridViewCntcAuthAO, "Select$" + e.Row.RowIndex);
            e.Row.Cells[2].Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.GridViewCntcAuthAO, "Select$" + e.Row.RowIndex);
           

        }
    }

    protected void GridViewCntcAuthAO_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = GridViewCntcAuthAO.SelectedRow;
        Label cerno = row.FindControl("lblformno") as Label;
        getRec(cerno.Text);
    }
    protected void btnconfirm_Click(object sender, EventArgs e)
    {
        int status = 0;
        int count = 0;
        try
        {
            foreach (GridViewRow gv in GridViewCntcAuthAO.Rows)
            {
                CheckBox chkGV = (CheckBox)gv.FindControl("CheckBox1");
                if (chkGV.Checked == true)
                {

                    string keyvalue = GridViewCntcAuthAO.DataKeys[gv.RowIndex].Value.ToString();
                    status = status + confirmeligibility(keyvalue);
                    count = count + 1;
                }

            }
            if (status == count && count >= 1)
            {
                auth_contain.Style.Add("display", "none");
                loading.Style.Add("display", "none");
                confirm.Style.Add("display", "");
                confirm.Attributes.Add("class", "confirmation-box animated-table flipInY");
                //p.InnerHtml = count + " record(s) authorised sucessfully";
                p.InnerHtml = count + " record(s) confirmed";
            }
            else
            {
                lblmsg.Text = "Please Check atleast one record before further processing";
                lblmsg.CssClass = "warning-box";
                auth_contain.Style.Add("display", "");
                loading.Style.Add("display", "none");
                confirm.Style.Add("display", "none");
            }
        }
        catch (Exception ex)
        {
            objgenenral = new BaseLayer.General_function();
            string err = objgenenral.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            lblmsg.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            lblmsg.CssClass = "warning-box";
        }
        finally
        {
            objgenenral = null;
        }
    }
    public int confirmeligibility(string cerpacno)
    {
        SqlParameter[] pram = null;

        pram = new SqlParameter[4];
        pram[0] = new SqlParameter("@UserId", objectSessionHolderPersistingData.User_ID);
        pram[1] = new SqlParameter("@cerpacno", cerpacno.ToString());
        pram[2] = new SqlParameter("@SuccessId", 1);
        pram[2].Direction = ParameterDirection.Output;
        SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_CERPAC_DATA_CONFIRM", pram);
        return int.Parse(pram[2].Value.ToString());
    }

    protected void btndeny_Click(object sender, EventArgs e)
    {
        int status = 0;
        int count = 0;
        try
        {
            foreach (GridViewRow gv in GridViewCntcAuthAO.Rows)
            {
                CheckBox chkGV = (CheckBox)gv.FindControl("CheckBox1");
                if (chkGV.Checked == true)
                {

                    string keyvalue = GridViewCntcAuthAO.DataKeys[gv.RowIndex].Value.ToString();
                    status = status + defer(keyvalue);
                    count = count + 1;
                }

            }
            if (status == count && count >= 1)
            {
                auth_contain.Style.Add("display", "none");
                loading.Style.Add("display", "none");
                confirm.Style.Add("display", "");
                confirm.Attributes.Add("class", "confirmation-box animated-table flipInY");
                //p.InnerHtml = count + " record(s) authorised sucessfully";
                p.InnerHtml = count + " record(s) defered";
            }
            else
            {
                lblmsg.Text = "Please Check atleast one recoed before further processing";
                lblmsg.CssClass = "warning-box";
                auth_contain.Style.Add("display", "");
                loading.Style.Add("display", "none");
                confirm.Style.Add("display", "none");
            }
        }
        catch (Exception ex)
        {
            objgenenral = new BaseLayer.General_function();
            string err = objgenenral.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            lblmsg.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            lblmsg.CssClass = "warning-box";
        }
        finally
        {
            objgenenral = null;
        }
    }
    public int defer(string cerpacno)
    {
        SqlParameter[] pram = null;

        pram = new SqlParameter[3];
        pram[0] = new SqlParameter("@UserId", objectSessionHolderPersistingData.User_ID);
        pram[1] = new SqlParameter("@cerpacno", cerpacno.ToString());
        pram[2] = new SqlParameter("@SuccessId", 1);
        pram[2].Direction = ParameterDirection.Output;
        SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_CERPAC_DATA_DEFER", pram);
        return int.Parse(pram[2].Value.ToString());

    }

}