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

public partial class MasterPage_RegistrationMasterPage : System.Web.UI.MasterPage
{
    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    #endregion

    public string LabelMessage
    {
        get { return this.lblmsg.Text; }
        set { this.lblmsg.Text = value; }
    }
    public string LabelMessageCss
    {
        get { return this.lblmsg.CssClass; }
        set { this.lblmsg.CssClass = value; }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now.AddDays(-1));
            Response.Cache.SetNoStore();
            if (Request.Cookies.Count > 0)
            {
                //HttpCookie cookie = Request.Cookies["ASPXAUTH"];
                //cookie.Expires = DateTime.Now.AddYears(-10);
                //Response.AppendCookie(cookie);
            }

            LabelSysDate.Text = DateTime.Now.ToLongDateString();         
        }
    }

    private void HeaderContent(int CompanyId)
    {
        BusinessEntityLayer.BalCompanyDetails ObjBalCompanyInfo = null;
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        DataSet ds = null;
        DataTable dt = null;

        try
        {
            ds = new DataSet();
            dt = new DataTable();
            ObjBalCompanyInfo = new BusinessEntityLayer.BalCompanyDetails();

            CompanyId = Convert.ToInt16(objectSessionHolderPersistingData.CompanyId);
            ds = ObjBalCompanyInfo.GetCompanyInfo(CompanyId);

            ds.Tables.Add(dt);
            dt = ds.Tables[0];

            //LabelLoginUser.Text = " Welcome: <font color='GREEN'>" + objectSessionHolderPersistingData.User_Name + "</font>";
            LabelSysDate.Text = DateTime.Now.Date.ToString();
        }
        catch (Exception ex)
        {
            lblmsg.CssClass = "errormsg";
            lblmsg.Text = ex.Message.ToString();
        }
        finally
        {
            ds = null;
            dt = null;
            ObjBalCompanyInfo = null;
        }
    }

    private void FooterContent()
    {
        BusinessEntityLayer.BalCompanyDetails ObjBalCompanyInfo = null;
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        DataSet ds = null;
        DataTable dt = null;

        try
        {
            ds = new DataSet();
            dt = new DataTable();
            ObjBalCompanyInfo = new BusinessEntityLayer.BalCompanyDetails();

            int CompanyId = Convert.ToInt16(objectSessionHolderPersistingData.CompanyId);
            ds = ObjBalCompanyInfo.GetCompanyInfo(CompanyId);

            ds.Tables.Add(dt);
            dt = ds.Tables[0];
        }
        catch (Exception ex)
        {
            lblmsg.CssClass = "errormsg";
            lblmsg.Text = ex.Message.ToString();
        }
        finally
        {
            ds = null;
            dt = null;
            ObjBalCompanyInfo = null;
        }

    }

    private void bindLeftMenu(string GrpId, string CompanyId)
    {   
    }
}
