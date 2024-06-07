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

public partial class Admin_FrmVisaIssueListL2 : System.Web.UI.Page
{
    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    BusinessEntityLayer.BalVisaIssuedListL2 ObjBalVisaIssuedListL2 = null;
    #endregion

    

    protected void Page_Load(object sender, EventArgs e)
    {
        //BusinessEntityLayer.BalPrintPaperVisaL2 ObjBalPrintPaperVisaL2 = null;
        BaseLayer.General_function ObjGenBal = null;
        Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
        ObjBalVisaIssuedListL2 = new BusinessEntityLayer.BalVisaIssuedListL2();
        ObjGenBal = new BaseLayer.General_function();
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        if (objectSessionHolderPersistingData == null)
        {
            Response.Redirect("../Login.aspx");
        }
        LabelMessage.CssClass = "";
        LabelMessage.Text = "";
        ////////////////////////////////////////////////////////
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.Now.AddDays(-1));
        Response.Cache.SetNoStore();
        if (Request.Cookies.Count > 0)
        {
            //HttpCookie cookie = Request.Cookies["ASPXAUTH"];
            //cookie.Expires = DateTime.Now.AddYears(-10);
            //Response.AppendCookie(cookie);
        }
        ///////////////////////////////////////////////////////

        if (!IsPostBack)
        {
            string ApplicationId = null;

            if (Request.QueryString["ApplicationId"] != null)
            {
                ApplicationId = Request.QueryString["ApplicationId"].ToString();
            }
            BindGrid();
        }
    }

    protected void BindGrid()
    {
        DataTable dt = new DataTable();
        try
        {
            // BusinessEntityLayer.BalPrintPaperVisaL2 ObjBalPrintPaperVisaL2 = null;
            ObjBalVisaIssuedListL2 = new BusinessEntityLayer.BalVisaIssuedListL2();

            string L1id = null;
            L1id = objectSessionHolderPersistingData.User_ID.ToString();
            dt = ObjBalVisaIssuedListL2.GetVisaPandingList(L1id);
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }
        catch (Exception ex)
        {
            Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            LabelMessage.CssClass = "errormsg";
            LabelMessage.Text = "Please contact to System Administrator; Error message is: " + ex.Message.ToString();

        }
        finally
        {
            ObjBalVisaIssuedListL2 = null;
            dt = null;
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        BindGrid();
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        //string keyvalue;
        //keyvalue = GridView1.DataKeys[e.NewEditIndex].Value.ToString();

        //Response.Redirect("FrmPrintPaperVisal2.aspx?ApplicationId=" + keyvalue);
    }


    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string AppID = GridView1.DataKeys[e.Row.RowIndex].Value.ToString();
            ImageButton keyButton = (ImageButton)e.Row.FindControl("ImgButton");
            keyButton.Attributes.Add("onClick", "javascript:DisplayPaperVisa('" + AppID + "')");

        }
    }
}
