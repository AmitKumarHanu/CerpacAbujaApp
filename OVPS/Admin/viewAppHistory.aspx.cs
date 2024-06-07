using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;

public partial class Admin_view : System.Web.UI.Page
{

    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    BaseLayer.General_function ObjGeneral = null;
    protected DataSet objDs = new DataSet();
    string strApplicationId;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
       
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        if (objectSessionHolderPersistingData == null)
        {
            Response.Redirect("../Login.aspx");
        }

        if (Request.QueryString["AppID"] != null)
        {
            strApplicationId = Request.QueryString["AppID"].ToString();
            string strQuery = " SELECT vaf.StepId , vaf.WorkCenter , um.UserName ,vaf.ActivityName , vaf.ActivityDisplayName,ISNULL(vaf.Comments,'--')Comments ,convert(varchar(12),vaf.ActivityDate ,105) ActivityDate " +
                              " FROM VisaApplicationInfo va " +
                              " INNER JOIN VisaApplicationWorkFlow vaf ON va.ApplicationId  = vaf.ApplicationID  " +
                              " INNER JOIN UserMaster um ON um.UserID = vaf.UserID " +
                              " WHERE va.ApplicationId = '" + strApplicationId + "' ORDER BY vaf.StepId ";
       
            objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.Text, strQuery);                       
        }
    }   
}