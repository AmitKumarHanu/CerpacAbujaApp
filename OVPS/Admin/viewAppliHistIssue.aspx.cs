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

public partial class Admin_viewAppliHistIssue : System.Web.UI.Page
{
    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    BaseLayer.General_function ObjGeneral = null;
    protected DataSet objDs = new DataSet();
    protected DataSet objdsp = new DataSet();
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
            string strQuery = "select cerpac_file_no, cerpac_receipt_date,cerpac_expiry_date,passport_no,company,designation,sex,passport_issue_loc,date_of_birth,place_of_birth,nationality_id,forename,surname from CardIssue where cerpac_no='" + strApplicationId.ToString() + "' and cerpac_expiry_date>'2009-01-01'";
            objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.Text, strQuery);
        }
    }
}