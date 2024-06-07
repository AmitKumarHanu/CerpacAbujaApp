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

public partial class Admin_ApplicationProcess : System.Web.UI.Page
{
    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
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
            BindGrid();
        }
    }

    protected void BindGrid()
    {        
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        BusinessEntityLayer.BalApprovalProcess ObjBalApprovalProcess = null;
        try
        {
            ObjBalApprovalProcess = new BusinessEntityLayer.BalApprovalProcess();

            string UserID = null;
            UserID = objectSessionHolderPersistingData.User_ID.ToString();          
            dt = ObjBalApprovalProcess.GetApplicationListByUserID(UserID);

            GridViewApplicantStatusList.DataSource = dt;
            GridViewApplicantStatusList.DataBind();
        }
        catch (Exception ex)
        {
            Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            LabelMessage.CssClass = "errormsg";
            LabelMessage.Text = "Please contact to System Administrator; Error message is: " + ex.Message.ToString();

        }
        finally
        {
            ObjBalApprovalProcess = null;
            dt = null;
        }
    }

    protected void GridViewApplicantStatusList_RowEditing(object sender, GridViewEditEventArgs e)
    {
        string keyvalue;
        keyvalue = GridViewApplicantStatusList.DataKeys[e.NewEditIndex].Value.ToString();

        Response.Redirect("FrmApplicationDetails.aspx?ApplicationId=" + keyvalue);
    }

    protected void GridViewApplicantStatusList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewApplicantStatusList.PageIndex = e.NewPageIndex;
        BindGrid();
    }
   

    protected void GridViewApplicantStatusList_RowDatabound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblRemark = ((Label)e.Row.FindControl("lblRemark"));
            DataRowView row = (DataRowView)e.Row.DataItem;
            int intApplicationID = Convert.ToInt32(row["ApplicationId"]);           
            int intCurrStepID = Convert.ToInt32(row["currStep"]);

            Trace.Warn("intApplicationID : " + intApplicationID);
            Trace.Warn("intCurrStepID : " + intCurrStepID);

            if (intCurrStepID > 1)
            {
                intCurrStepID = intCurrStepID - 1;
                string strSqlstatement = "SELECT Comments " +
                                         "FROM VisaApplicationWorkFlow " +
                                         "WHERE ApplicationId = " + intApplicationID + " AND (flagActType ='M' OR flagActType ='O')AND " +
                                         "StepId = " + intCurrStepID + " AND FlagActivityStatus = 'Y' ORDER BY ActivityDate ";

                Trace.Warn("strSqlstatement : " + strSqlstatement);

                string strComments = (string)SqlHelper.ExecuteScalar(AppSetting.ActivateConnection, CommandType.Text, strSqlstatement);
                lblRemark.Text = strComments;
            }

            
        }
    }

    protected void Go_Click(object sender, EventArgs e)
    {
        BusinessEntityLayer.BalApprovalProcess ObjBalApprovalProcess = null;

        DataTable dt = null;
        dt = new DataTable();

        try
        {
            string UserID = null;
            UserID = objectSessionHolderPersistingData.User_ID.ToString();     
            string ApplicationID = TextAppId.Text.ToString();

            ObjBalApprovalProcess = new BusinessEntityLayer.BalApprovalProcess();

            dt = ObjBalApprovalProcess.GetApplicationListByAppID(UserID, ApplicationID);

            GridViewApplicantStatusList.DataSource = dt;
            GridViewApplicantStatusList.DataBind();
        }
        catch (Exception ex)
        {
            Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            LabelMessage.CssClass = "errormsg";
            LabelMessage.Text = "Please contact to System Administrator; Error message is: " + ex.Message.ToString();

        }
        finally
        {
            ObjBalApprovalProcess = null;
            dt = null;
        }
    }
}
