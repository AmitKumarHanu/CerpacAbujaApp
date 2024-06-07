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

public partial class Admin_FrmVisaApplicationSearch : System.Web.UI.Page
{
    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    #endregion
    BaseLayer.General_function ObjGeneral = null;
   

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.Now.AddDays(-1));
        Response.Cache.SetNoStore();
        if (Request.Cookies.Count > 0)
        {
            //HttpCookie cookie = Request.Cookies["ASPXAUTH"];
            //cookie.Expires = DateTime.Now.AddYears(-10);
            //Response.AppendCookie(cookie);
        }

        Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
        LabelMessage.CssClass = "";
        LabelMessage.Text = "";

        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        if (objectSessionHolderPersistingData == null)
        {
            Response.Redirect("../Login.aspx");
        }

        FromDate.HRef = "javascript:NewCal('" + TextFromDate.ClientID + "','DDMMMYYYY')";
        Todate.HRef = "javascript:NewCal('" + TextToDate.ClientID + "','DDMMMYYYY')";

        if (!IsPostBack)
        {
            Binddropdown();
            GridView1.Visible = false;
        }
       
    }

   
    protected void Search_Click(object sender, EventArgs e)
    {        
     Bindgrid();      
    }


  public void  Binddropdown()
    {

        string CountryQuery = "Select CountryCode,CountryName from CountryMaster where Status= 'A' order by CountryName";
        ObjGeneral = new BaseLayer.General_function();
        ObjGeneral.Fill_DDL(ddlCountry, CountryQuery, "CountryName", "CountryCode");

        string VisaTypeQuery = "Select VisaTypeCode,VisaTypeName from VisaTypeMaster where Status= 'A' order by VisaTypeName";
        ObjGeneral = new BaseLayer.General_function();
        ObjGeneral.Fill_DDL(ddlVisaType, VisaTypeQuery, "VisaTypeName", "VisaTypeCode");


    }

  protected void Bindgrid()
  {
      DataTable dt = null;
      dt = new DataTable();
      BusinessEntityLayer.BalVisaAppSearchL3 ObjBalVisasAppsearch = null;
      Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
      GridView1.Visible = false;
      try
      {
          ObjBalVisasAppsearch = new BusinessEntityLayer.BalVisaAppSearchL3();
          if (TextFromDate.Value != "")
          {
              if (TextToDate.Value == "")
              {
                  LabelMessage.CssClass = "errormsg";
                  LabelMessage.Text = "Please select To Date";
                  TextToDate.Focus();
                  return;

              }
          }


          if (TextToDate.Value != "")
          {
              if (TextFromDate.Value == "")
              {
                  LabelMessage.CssClass = "errormsg";
                  LabelMessage.Text = "Please select From Date";
                  TextFromDate.Focus();
                  return;

              }
          }

          if (TextFromDate.Value != "" && TextToDate.Value != "")
          {
              DateTime TempFD = Convert.ToDateTime(TextFromDate.Value.ToString());
              DateTime TempTD = Convert.ToDateTime(TextToDate.Value.ToString());

              if (TempFD >= TempTD)
              {
                  LabelMessage.CssClass = "errormsg";
                  LabelMessage.Text = "To Date should be greater than From Date";
                  return;

              }

          }
          ObjBalVisasAppsearch.ApplicationId = txtapplicationid.Text.Trim().ToString() == "" ? "ALL" : txtapplicationid.Text.Trim().ToString();
          ObjBalVisasAppsearch.country = ddlCountry.SelectedIndex == 0 ? "ALL" : ddlCountry.SelectedValue.Trim();
          ObjBalVisasAppsearch.visatype = ddlVisaType.SelectedIndex == 0 ? "ALL" : ddlVisaType.SelectedValue.Trim();
          ObjBalVisasAppsearch.fromdate = TextFromDate.Value.Trim().ToString() == "" ? "ALL" : TextFromDate.Value.Trim().ToString();
          ObjBalVisasAppsearch.todate = TextToDate.Value.Trim().ToString() == "" ? "ALL" : TextToDate.Value.Trim().ToString();
          ObjBalVisasAppsearch.status = rblstatus.SelectedValue.ToString() == "" ? "C" : rblstatus.SelectedValue.ToString();

          dt = ObjBalVisasAppsearch.searchvisaapp();

          if (dt.Rows.Count > 0)
          {

              GridView1.Visible = true;
              GridView1.DataSource = dt;
              GridView1.DataBind();
          }
          else
          {
              GridView1.Visible = false;
              LabelMessage.CssClass = "errormsg";
              LabelMessage.Text = "No records found on the given criteria";
          }

      }
      catch (Exception ex)
      {
          LabelMessage.CssClass = "errormsg";
          LabelMessage.Text = "Please contact to System Administrator; Error message is: " + ex.Message.ToString();

      }
       

  }


  protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
  {
      GridView1.PageIndex = e.NewPageIndex;
      Bindgrid();
  }
 
}
