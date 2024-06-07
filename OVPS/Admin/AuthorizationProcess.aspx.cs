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
public partial class Admin_AuthorizationProcess : System.Web.UI.Page
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
        Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
        string queryforzonename = "select b.ZoneName from UserZoneRelation as a, Zonemaster as b where a.ZoneCode=b.ZoneCode and a.UserId=" + objectSessionHolderPersistingData.User_ID + "";
        objgenenral = new BaseLayer.General_function();
        DataTable dt = new DataTable();
        try
        {
            dt = objgenenral.FetchData(queryforzonename);
            if (dt.Rows.Count > 0)
            {
                LabelMessage.Text = "Zone" + " " + dt.Rows[0]["ZoneName"].ToString();
                LabelMessage.Visible = true;
                LabelMessage.BorderStyle = BorderStyle.None;
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
            dt = null;
            objgenenral = null;
        }
    }


    protected void bindgrid()
    {
        objgenenral = new BaseLayer.General_function();
        DataTable dt = new DataTable();
        DataTable dtbio = new DataTable();
        DataTable dtmetrics = new DataTable();
        dtmetrics.Columns.Add("Name", typeof(String));
        dtmetrics.Columns.Add("cerpac_no", typeof(String));  
        dtmetrics.Columns.Add("FORMNO", typeof(String));
        dtmetrics.Columns.Add("Status", typeof(String));
        try
        {
            string queryforgrid = "select a.cerpac_no,(a.forename+' '+a.surname)as Name,b.FORMNO,a.people_id,  (Case when a.cerpac_no=b.FORMNO then 'Fresh Case' Else 'Renewal Case' End) as Status from People as a , PeopleChild as b,CerpacNo_Out_One as c,UserZoneRelation as d where a.cerpac_no = b.CerpacNo and b.CerpacNo=c.cerpac_no and b.FORMNO=c.cerpac_file_no and c.ZoneCode=d.ZoneCode and b.IsVerified=1 and (b.IsAuthorized=0 or b.IsAuthorized is null) and d.UserId=" + objectSessionHolderPersistingData.User_ID + "";

            dt = objgenenral.FetchData(queryforgrid);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                string queryforbiometrics = "Select * from VisaApplicationBiometric where VisaApplicationId=" + dt.Rows[i]["people_id"].ToString().Trim() + "";

                dtbio = objgenenral.FetchData(queryforbiometrics);
               
                 //   if (dtbio.Rows.Count > 0)
                    {
                        dtmetrics.Rows.Add(dt.Rows[i]["Name"].ToString(), dt.Rows[i]["cerpac_no"].ToString(), dt.Rows[i]["FORMNO"].ToString(), dt.Rows[i]["Status"].ToString());

                    }
                    
                }
                GridViewAuth.DataSource = dtmetrics;
                GridViewAuth.DataBind();
                if (GridViewAuth.Rows.Count > 0)
                {
                    btnauth.Visible = false;
                    btnreject.Visible = false;
                }
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
            dtmetrics = null;
            dt = null;
            dtbio = null;
            objgenenral = null;
        }

    }

    protected void Go_Click(object sender, EventArgs e)
    {
       // System.Threading.Thread.Sleep(500);
        objgenenral = new BaseLayer.General_function();
        try
        {
            //----------------------------------------------------------------------checking for zone processing-----------------------------------------
            string queryforzone = "select a.ZoneCode as ZoneCode,b.ZoneName from CerpacNo_Out_One as a,Zonemaster as b where a.ZoneCode=b.ZoneCode and a.cerpac_no='" + TextAppId.Text + "' and a.cerpac_file_no=(select cerpac_file_no from people where cerpac_no='" + TextAppId.Text.ToString().Trim() + "')";
            DataTable dtzoneprs = new DataTable();
            dtzoneprs = null;
            dtzoneprs = objgenenral.FetchData(queryforzone);
            string queryforuser = "select * from UserZoneRelation where UserId=" + objectSessionHolderPersistingData.User_ID + "";
            DataTable dtuserprcs = new DataTable();
            dtuserprcs = objgenenral.FetchData(queryforuser);
            if (dtuserprcs.Rows.Count > 0)
            {
                if (dtzoneprs.Rows.Count > 0)
                {
                    if (dtzoneprs.Rows[0]["ZoneCode"].ToString().Trim() != dtuserprcs.Rows[0]["ZoneCode"].ToString().Trim())
                    {
                        lblmsg.Text = "This form is under processing at " + dtzoneprs.Rows[0]["ZoneName"].ToString() + " zone.";
                        lblmsg.CssClass = "warning-box";
                        return;
                    }
                }
            }
            //----------------------------------------------------------------------------end----------------------------------------------------------------
            //-------------------------------------------------------------------------Check for biometric capture-------------------------------------------
            //string queryforbio = "select a.people_id from People as a, VisaApplicationBiometric as b where a.people_id=b.VisaApplicationId and a.cerpac_no='" + TextAppId.Text.ToString().Trim() + "'";
            //DataTable dtbiomet = new DataTable();
            //dtbiomet = objgenenral.FetchData(queryforbio);
            //if (dtbiomet.Rows.Count == 0)
            //{
            //    lblmsg.Text = "Biometrics for the particular appliaction is not been captured";
            //    lblmsg.CssClass = "warning-box";
            //    return;

            //}
            //-----------------------------------------------------------------------------end---------------------------------------------------------------
            string quer = "select a.*,b.* from People as a , PeopleChild as b where a.cerpac_no = b.CerpacNo and a.cerpac_no='" + TextAppId.Text.ToString() + "' and (b.IsAuthorized=0 or b.IsAuthorized is null) and b.IsVerified=1";
            DataTable dt = new DataTable();
            dt = objgenenral.FetchData(quer);
            DataTable dtuser = new DataTable();
            if (dt.Rows.Count > 0 && (dt.Rows[0]["IsAuthorized"].ToString().Trim() == "0" || dt.Rows[0]["IsAuthorized"].ToString().Trim() == "" || dt.Rows[0]["IsAuthorized"].ToString().Trim() == null) && dt.Rows[0]["IsVerified"].ToString().Trim() == "1")
            {
                Response.Redirect("AuthorizationDetails.aspx?no=" + TextAppId.Text.ToString() + "");
            }
            else if (dt.Rows.Count > 0 && dt.Rows[0]["IsAuthorized"].ToString() == "1")
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

    protected void GridViewAuth_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridViewAuth.EditIndex = e.NewEditIndex;

        Label lblcerpacno = (Label)GridViewAuth.Rows[GridViewAuth.EditIndex].FindControl("lblcerpacno");

        string keyvalue = lblcerpacno.Text.ToString();
        TextAppId.Text = keyvalue.ToString();
        GridViewAuth.Style.Add("display", "none");
        btnauth.Visible = false;
        btnreject.Visible = false;
     //   Response.Redirect("AuthorizationDetails.aspx?no="+keyvalue.ToString()+"");

    }

    protected void GridViewAuth_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        GridViewAuth.PageIndex = e.NewPageIndex;
        bindgrid();
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
    protected void btnauth_Click(object sender, EventArgs e)
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
                    ObjbalApporvalL1 = new BusinessEntityLayer.BalApprovalReviewL1();
                    ObjbalApporvalL1.UserId = objectSessionHolderPersistingData.User_ID;
                    ObjbalApporvalL1.cerpacno = keyvalue.ToString();
                    ObjbalApporvalL1.authnotes = "Authorized";
                    status = status + ObjbalApporvalL1.Authorize();
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
                p.InnerHtml = count + " record(s) sent for authorisation sucessfully";
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

    protected void btnreject_Click(object sender, EventArgs e)
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
                    ObjbalApporvalL1 = new BusinessEntityLayer.BalApprovalReviewL1();
                    ObjbalApporvalL1.UserId = objectSessionHolderPersistingData.User_ID;
                    ObjbalApporvalL1.cerpacno = keyvalue.ToString();
                    ObjbalApporvalL1.reason = "Rejected";
                    status = status + ObjbalApporvalL1.Reject();
                    count = count + 1;
                }

            }
            if (status == count && count >= 1)
            {
                auth_contain.Style.Add("display", "none");
                loading.Style.Add("display", "none");
                confirm.Style.Add("display", "");
                confirm.Attributes.Add("class", "confirmation-box animated-table flipInY");
                p.InnerHtml = count + " record(s) rejected sucessfully";
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
    protected void GridViewAuth_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[0].Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Cells[1].Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Cells[2].Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Cells[3].Attributes["onmouseover"] = "this.style.cursor='pointer';";

            //  e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
            e.Row.ToolTip = "Click to select row";
            e.Row.Cells[0].Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.GridViewAuth, "Select$" + e.Row.RowIndex);
            e.Row.Cells[1].Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.GridViewAuth, "Select$" + e.Row.RowIndex);
            e.Row.Cells[2].Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.GridViewAuth, "Select$" + e.Row.RowIndex);
            e.Row.Cells[3].Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.GridViewAuth, "Select$" + e.Row.RowIndex);

        }
    }
    protected void GridViewAuth_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = GridViewAuth.SelectedRow;
        objgenenral = new BaseLayer.General_function();
        try
        {
            string quer = "select a.*,b.* from People as a , PeopleChild as b where a.cerpac_no = b.CerpacNo and a.cerpac_no='" + row.Cells[1].Text + "' and (b.IsAuthorized=0 or b.IsAuthorized is null)";
            DataTable dt = null;
            dt = new DataTable();
            dt = objgenenral.FetchData(quer);
            DataTable dtuser = null;
            dtuser = new DataTable();
            if (dt.Rows.Count > 0 && (dt.Rows[0]["IsAuthorized"].ToString().Trim() == "0" || dt.Rows[0]["IsAuthorized"].ToString().Trim() == "" || dt.Rows[0]["IsAuthorized"].ToString().Trim() == null) && dt.Rows[0]["IsVerified"].ToString().Trim() == "1")
            {
                Response.Redirect("AuthorizationDetails.aspx?no=" + row.Cells[1].Text + "");
            }
            else if (dt.Rows.Count > 0 && dt.Rows[0]["IsAuthorized"].ToString() == "1")
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
}