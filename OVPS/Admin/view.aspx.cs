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


public partial class Admin_view : System.Web.UI.Page
{

    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    BaseLayer.General_function ObjGeneral = null;
    Label LabelMessage = null;
    string LogoPath1 = string.Empty;
    BusinessEntityLayer.BalVisaApplicationSubmit ObjBalVisa = new BusinessEntityLayer.BalVisaApplicationSubmit();
    protected DataTable dt = new DataTable();
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
            ObjBalVisa = new BusinessEntityLayer.BalVisaApplicationSubmit();
            dt = new DataTable();
            dt = ObjBalVisa.GetVisaApplicationInfo4Update(strApplicationId);
           
        }

    }

    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        Response.Redirect("../User/MakePayment.aspx?AppID=" + strApplicationId);
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Admin/FrmVisaApplication.aspx?AppID=" + strApplicationId);
    }
}