using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

public partial class Admin_calpopup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindrop();
            
        }
       
    }
    protected void calexp_SelectionChanged(object sender, EventArgs e)
    {
       
            string datesel = calexp.SelectedDate.ToString("dd-MM-yyyy");
            Session["date"] = datesel;

            ScriptManager.RegisterStartupScript(this, GetType(), "key", "ReturnParentPage('" + datesel + "')", true);
       
    }
    protected void calexp_DayRender(object sender, DayRenderEventArgs e)
    {
        
            if (Convert.ToString(Request.QueryString["maxdt"]) != null)
            {
                int startdate = int.Parse(Request.QueryString["start"]);
                int enddate = int.Parse(Request.QueryString["end"]);
                string stdt = string.Format("{0:d-MM-yyyy}", Request.QueryString["maxdt"].ToString()).ToString().Trim();

                DateTime startDate = DateTime.ParseExact(stdt, "d-MM-yyyy", CultureInfo.InvariantCulture).AddYears(startdate); //Convert.ToDateTime(stdt).AddYears(startdate);

                DateTime endDate = DateTime.ParseExact(stdt, "d-MM-yyyy", CultureInfo.InvariantCulture).AddYears(enddate); //Convert.ToDateTime(stdt).AddYears(enddate);

                e.Day.IsSelectable = e.Day.Date >= startDate & e.Day.Date <= endDate;
            }
        
    }

    public void bindrop()
    {
        if (Convert.ToString(Request.QueryString["maxdt"]) != null)
        {
            int addyrs = int.Parse(Request.QueryString["add"]);
            int count = int.Parse(Request.QueryString["cnt"]);
            drpyear.DataSource = Enumerable.Range(DateTime.ParseExact(Request.QueryString["maxdt"].ToString(),"d-MM-yyyy",CultureInfo.InvariantCulture).AddYears(addyrs).Year, count);
            drpyear.DataBind();
        }
    }
    protected void drpmonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        calexp.VisibleDate = new DateTime(int.Parse(drpyear.SelectedValue),int.Parse(drpmonth.SelectedValue), 1);
    }
    protected void drpyear_SelectedIndexChanged(object sender, EventArgs e)
    {
        calexp.VisibleDate = new DateTime(int.Parse(drpyear.SelectedValue), int.Parse(drpmonth.SelectedValue), 1);
    }
}