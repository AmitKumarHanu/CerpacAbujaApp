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
using System.Data;
using System.Data.SqlClient;

public partial class Admin_FrmConfirmList : System.Web.UI.Page
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

        if (!IsPostBack)
        {
            bindgrid();
        }
    }

    protected void bindgrid()
    {
        objgenenral = new BaseLayer.General_function();
       // string queryforgrid = "select a.cerpac_no,(a.forename+' '+a.surname)as Name,a.passport_no from People as a , PeopleChild as b where a.cerpac_no = b.CerpacNo and b.IsVerified=1 and b.IsAuthorized=1 and (ISARCR=0 or ISARCR is null)";
       // string queryforgrid = "select a.cerpac_no,b.FormNo,(a.forename+' '+a.surname)as Name,a.passport_no,a.designation,nationality,ISNULL((CASE (SUBSTRING(a.cerpac_no, 1, 2)) WHEN 'AO' THEN c.company ELSE d.company END), a.verid_template_1) AS Company from People as a left join CompMaster c on a.company=c.regno LEFT OUTER JOIN CompMasterForARCR d ON a.company = d.Regno , PeopleChild as b  where a.cerpac_no = b.CerpacNo and b.IsVerified=1 and b.IsAuthorized=1 and (ISARCR=0 or ISARCR is null)";
        string queryforgrid = "select a.cerpac_no,b.FormNo,(a.forename+' '+a.surname)as Name,a.passport_no,a.designation,nationality,ISNULL((CASE (SUBSTRING(a.cerpac_no, 1, 2)) WHEN 'AO' THEN c.company ELSE d.company END), a.verid_template_1) AS Company from People as a left join CompMaster c on a.company=c.regno LEFT OUTER JOIN CompMasterForARCR d ON a.company = d.Regno , PeopleChild as b,UserZoneRelation as e where a.cerpac_no = b.CerpacNo and b.VerifiedBy=e.UserId and b.IsVerified=1 and b.IsAuthorized=1 and (ISARCR=0 or ISARCR is null) and (FORMNO Like 'AR%' ) and e.ZoneCode=(Select ZoneCode from UserZoneRelation where userid='" + objectSessionHolderPersistingData.User_ID + "')"; 
        DataTable dt = new DataTable();
        dt = objgenenral.FetchData(queryforgrid);
        if (dt.Rows.Count > 0)
        {
            GridViewAuth.DataSource = dt;
            GridViewAuth.DataBind();
        }
    }

    protected void Go_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(500);
        objgenenral = new BaseLayer.General_function();
       // string quer = "select a.*,b.* from People as a , PeopleChild as b where a.cerpac_no = b.CerpacNo and a.cerpac_no='" + TextAppId.Text.ToString() + "' and b.isVerified=1 and b.isAuthorized =1 and(b.isARCR = 0 or b.isARCR is null)";
        string quer = "select a.*,b.* from People as a , PeopleChild as b where a.cerpac_no = b.CerpacNo and a.cerpac_no='" + TextAppId.Text.ToString() + "' and b.isVerified=1 and b.isAuthorized =1 and(b.isARCR = 0 or b.isARCR is null) and (FORMNO Like 'AR%' )";
      
	DataTable dt = new DataTable();
        dt = objgenenral.FetchData(quer);
        DataTable dtuser = new DataTable();
        if (dt.Rows.Count > 0 && (dt.Rows[0]["ISARCR"].ToString().Trim() == "0" || dt.Rows[0]["ISARCR"].ToString().Trim() == "" || dt.Rows[0]["ISARCR"] == null) && dt.Rows[0]["IsAuthorized"].ToString().Trim() == "1" && dt.Rows[0]["IsVerified"].ToString().Trim() == "1")
        {
            Response.Redirect("FrmConfirmEligibility.aspx?no=" + TextAppId.Text.ToString() + "");
        }
        else if (dt.Rows.Count > 0 && dt.Rows[0]["IsARCR"].ToString() == "1")
        {
            lblmsg.Text = "This Cerpac Number Has already been Authorized";
            lblmsg.CssClass = "warning-box";
        }
        else
        {
            lblmsg.Text = "This Cerpac Number does not exists.Please check the number and try again";
            lblmsg.CssClass = "error-box";

        }
    }
    protected void chkAccessAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkGV;
        CheckBox chk = ((CheckBox)sender);
        string ChkName = chk.ID;
        ChkName = ChkName.Substring(0, ChkName.Length - 6);
        foreach (GridViewRow gv in GridViewAuth.Rows)
        {
            chkGV = (CheckBox)gv.FindControl("CheckBox1");
            chkGV.Checked = chk.Checked;

        }

    }
    public void getRec(string cer)
    {
        System.Threading.Thread.Sleep(500);
        objgenenral = new BaseLayer.General_function();
        string quer = "select a.*,b.* from People as a , PeopleChild as b where a.cerpac_no = b.CerpacNo and a.cerpac_no='" + cer + "'and b.isVerified=1 and b.isAuthorized =1 and(b.isARCR = 0 or b.isARCR is null)";
        DataTable dt = new DataTable();
        dt = objgenenral.FetchData(quer);
        DataTable dtuser = new DataTable();
        if (dt.Rows.Count > 0 && (dt.Rows[0]["ISARCR"].ToString().Trim() == "0" || dt.Rows[0]["ISARCR"].ToString().Trim() == "" || dt.Rows[0]["ISARCR"] == null) && dt.Rows[0]["IsAuthorized"].ToString().Trim() == "1" && dt.Rows[0]["IsVerified"].ToString().Trim() == "1")
        {
            Response.Redirect("FrmConfirmEligibility.aspx?no=" + cer + "");
        }
        else if (dt.Rows.Count > 0 && dt.Rows[0]["IsARCR"].ToString() == "1")
        {
            lblmsg.Text = "This Cerpac Number Has already been Authorized";
            lblmsg.CssClass = "warning-box";
        }
        else
        {
            lblmsg.Text = "This Cerpac Number does not exists.Please check the number and try again";
            lblmsg.CssClass = "error-box";

        }
    }

    protected void GridViewAuth_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridViewAuth.EditIndex = e.NewEditIndex;

        Label lblcerpacno = (Label)GridViewAuth.Rows[GridViewAuth.EditIndex].FindControl("lblcerpacno");

        string keyvalue = lblcerpacno.Text.ToString();
        TextAppId.Text = keyvalue.ToString();
        GridViewAuth.Style.Add("display", "none");
        //   Response.Redirect("AuthorizationDetails.aspx?no="+keyvalue.ToString()+"");

    }

    protected void GridViewAuth_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        GridViewAuth.PageIndex = e.NewPageIndex;
        bindgrid();
    }


    protected void GridViewAuth_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
                //e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                //e.Row.ToolTip = "Click to select row";
                //e.Row.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.GridViewAuth, "Select$" + e.Row.RowIndex);


            e.Row.Cells[0].Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Cells[1].Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Cells[2].Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Cells[3].Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Cells[4].Attributes["onmouseover"] = "this.style.cursor='pointer';";


            //  e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
            e.Row.ToolTip = "Click to select row";
            e.Row.Cells[0].Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.GridViewAuth, "Select$" + e.Row.RowIndex);
            e.Row.Cells[1].Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.GridViewAuth, "Select$" + e.Row.RowIndex);
            e.Row.Cells[2].Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.GridViewAuth, "Select$" + e.Row.RowIndex);
            e.Row.Cells[3].Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.GridViewAuth, "Select$" + e.Row.RowIndex);
            e.Row.Cells[4].Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.GridViewAuth, "Select$" + e.Row.RowIndex);

            
        }
    }

    protected void GridViewAuth_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = GridViewAuth.SelectedRow;
        Label cerno = row.FindControl("lblcerpacno") as Label;
        getRec(cerno.Text);
    }
    protected void btnconfirm_Click(object sender, EventArgs e)
    {
        int status = 0;
        int count = 0;
        try
        {
            foreach (GridViewRow gv in GridViewAuth.Rows)
            {
                CheckBox chkGV = (CheckBox)gv.FindControl("CheckBox1");
                if (chkGV.Checked == true)
                {

                    string keyvalue = GridViewAuth.DataKeys[gv.RowIndex].Value.ToString();
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
                foreach (GridViewRow gv in GridViewAuth.Rows)
                {
                    CheckBox chkGV = (CheckBox)gv.FindControl("CheckBox1");
                    if (chkGV.Checked == true)
                    {

                        string keyvalue = GridViewAuth.DataKeys[gv.RowIndex].Value.ToString();
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