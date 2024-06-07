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
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Text;
using System.IO;
using System.Globalization;
using System.Threading;

public partial class Admin_ProductionDetailPrintBrownCard : System.Web.UI.Page
{
    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    BaseLayer.General_function objgenenral = null;
    DataTable dt = null;
    string cerpac_no = "";
    string formno = "";
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];

        if (objectSessionHolderPersistingData == null)
        {
            Response.Redirect("../Login.aspx");
        }
        if (Request.QueryString["id"].ToString() != null || Request.QueryString["id"].ToString() != "" || Request.QueryString["userid"].ToString() != null || Request.QueryString["userid"].ToString() != "")
        {
            cerpac_no = Request.QueryString["id"].ToString().Trim();
            formno = Request.QueryString["userid"].ToString().Trim();
        }
        
        //-----------------------------------------------checking for zone ----------------------------------------
        string queryforzonename = "select b.ZoneName from UserZoneRelation as a, Zonemaster as b where a.ZoneCode=b.ZoneCode and a.UserId=" + formno + "";
        objgenenral = new BaseLayer.General_function();
        DataTable dt1 = new DataTable();
        try
        {
            dt1 = objgenenral.FetchData(queryforzonename);
            if (dt1.Rows.Count > 0)
            {
               Session["zone"] = dt1.Rows[0]["ZoneName"].ToString();
           }
        }
        catch (Exception ex)
        {
         //   throw (ex);
            Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");

            objgenenral = new BaseLayer.General_function();
            string err = objgenenral.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.CssClass = "warning-box";
            LabelMessage.Visible = true;
        }
        finally
        {
            dt1 = null;
            objgenenral = null;
        }
        //---------------------------------------------------end------------------------------------------------------
        if (!IsPostBack)
        {
            getdata(cerpac_no.ToString().Trim());
        }
    }
    public void getdata(string id)
    {
        objgenenral = new BaseLayer.General_function();
        dt= new DataTable();
        string query = "Select * from people where cerpac_no='" + id.ToString().Trim() + "'";

        try
        {
            dt = objgenenral.FetchData(query);
            if (dt.Rows.Count > 0)
            {
                CultureInfo c = Thread.CurrentThread.CurrentCulture;
                TextInfo textInfo = c.TextInfo;
                lbl_cerpac_no.Text = id.ToString().ToString().Trim();
                lbl_desig.Text = textInfo.ToTitleCase(dt.Rows[0]["designation"].ToString());
                lbl_expiry_date.Text = string.Format("{0:d-MM-yyyy}", dt.Rows[0]["cerpac_expiry_date"]).ToString();
                lbl_name.Text = textInfo.ToTitleCase(dt.Rows[0]["forename"].ToString()) + " " + textInfo.ToTitleCase(dt.Rows[0]["surname"].ToString());
                lbl_nationality.Text = textInfo.ToTitleCase(dt.Rows[0]["nationality"].ToString());
                lbl_passport.Text = dt.Rows[0]["passport_no"].ToString();
                lbl_place_of_issue.Text = textInfo.ToTitleCase(Session["zone"].ToString());
                ImgPhoto.ImageUrl = "~/Images/Logo/" + dt.Rows[0]["picture"].ToString().Trim();
                imgbarcode.ImageUrl = @"~/Images/Logo/Barcode/" + id.ToString() + "BCCode.bmp";



            }
        }

        catch (Exception ex)
        {
            Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            objgenenral = new BaseLayer.General_function();
            string err = objgenenral.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.CssClass = "warning-box";
            LabelMessage.Visible = true;
        }
        finally
        {
            dt = null;
            objgenenral = null;
        }
    }
}