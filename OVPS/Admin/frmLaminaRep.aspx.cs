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
using Microsoft.Reporting.WebForms;
using System.Drawing.Printing;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Drawing2D;
using System.IO;
using System.Globalization;

public partial class Admin_frmLaminaRep : System.Web.UI.Page
{

    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    BaseLayer.General_function objgenenral = null;
    BaseLayer.General_function ObjGeneral = null;
    protected BaseLayer.General_function ObjGenBal = null;

    Label LabelMessage = null;

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        From.HRef = "javascript:NewCal('" + txtFromDate.ClientID + "','DDMMMYYYY','','',1,80)";
        To.HRef = "javascript:NewCal('" + txtToDate.ClientID + "','DDMMMYYYY','','',1,80)";
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];

        LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");

        if (!IsPostBack)
        {
            ObjGeneral = new BaseLayer.General_function();
            objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];

            if (objectSessionHolderPersistingData == null)
            {
                Response.Redirect("../Login.aspx");
            }

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
                ObjGenBal = new BaseLayer.General_function();
                string err = ObjGenBal.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
                LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
                LabelMessage.CssClass = "warning-box";
                LabelMessage.Visible = true;
            }
            finally
            {
                dt = null;
                objgenenral = null;
            }
            CompareValidator1.ValueToCompare = DateTime.Now.ToShortDateString();
            CompareValidator3.ValueToCompare = DateTime.Now.ToShortDateString();
           
        }      
      

        
    }
    public static string ConvertDate(string date, string pattern)
    {

        if (string.IsNullOrEmpty(date) == false && date != "")
        {
            DateTime date2;
            if (DateTime.TryParseExact(date, pattern, CultureInfo.InvariantCulture, DateTimeStyles.None, out date2))
            {
                return date2.ToString("MM/dd/yyyy");
            }
            else
            {
                return "";
            }
        }
        else
        {
            return "";
        }
    }
    public void CallDate()
    {
        ObjGeneral = new BaseLayer.General_function();
        DataTable dt = new DataTable();
        string query = "Select DATEDIFF(d, '" + ConvertDate(txtFromDate.Value, "d-MM-yyyy") + "','" + ConvertDate(txtToDate.Value, "d-MM-yyyy") + "')";
        //  "SELECT * from ProdReportCerpacCard";
        dt = ObjGeneral.FetchData(query);
        if (txtFromDate.Value != "" && txtToDate.Value != "")
        {
            if (Convert.ToInt32(dt.Rows[0].ItemArray[0].ToString()) < 0)
            {
                Response.Write("<script language=javascript>alert('To-Date must be greater than From- Date')</script>");
                return;
            }
        }
    }

    protected void btn_generate_report_Click(object sender, EventArgs e)
    {
        
      
        ObjGeneral = new BaseLayer.General_function();
        DataTable dt = new DataTable();

         if (txtFromDate.Value == "" && txtToDate.Value == "")
        {

            ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Please Fill From-Date & To-Date.');", true);
            // Response.Write("<script language=javascript>alert('Please Fill From- Date & To-Date')</script>");
            return;

        }

        if (txtFromDate.Value == "")
        {

            ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Please Fill From-Date.');", true);
            // Response.Write("<script language=javascript>alert('Please Fill From- Date & To-Date')</script>");
            return;

        }

        if (txtToDate.Value == "")
        {

            ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Please Fill To-Date.');", true);
            // Response.Write("<script language=javascript>alert('Please Fill From- Date & To-Date')</script>");
            return;

        }


     
        //string query = "SELECT count(*) as TotalLamina, ISNULL(SUM(CASE WHEN isnull(lam_printedYN, 0) = 1 THEN 1 END), 0) as Printed, ISNULL(SUM(CASE WHEN isnull(lam_wastedYN, 0) = 1 THEN 1 END), 0) as Wasted  from tbl_lamination_detail";
        try
        {
            CallDate();
            if (txtFromDate.Value != "" && txtToDate.Value != "")
            {
                string query = "SELECT count(*) as TotalLamina, ISNULL(SUM(CASE WHEN isnull(lam_printedYN, 0) = 1 THEN 1 END), 0) as Printed, ISNULL(SUM(CASE WHEN isnull(lam_wastedYN, 0) = 1 THEN 1 END), 0) as Wasted,   ISNULL(SUM(CASE WHEN (isnull(lam_printedYN, 0) = 1 and created_on >= '" + ConvertDate(txtFromDate.Value, "d-MM-yyyy") + "' and  created_on <='" + ConvertDate(txtToDate.Value, "d-MM-yyyy") + "') THEN 1 END), 0) as UsedTillDate,  ISNULL(SUM(CASE WHEN (isnull(lam_wastedYN, 0) = 1 and created_on >= '" + ConvertDate(txtFromDate.Value, "d-MM-yyyy") + "' and  created_on <='" + ConvertDate(txtToDate.Value, "d-MM-yyyy") + "') THEN 1 END), 0) as WastedTillDate from tbl_lamination_detail";


                dt = ObjGeneral.FetchData(query);
                //if (dt.Rows.Count > 0)
                if (dt.Rows.Count > 0)
                {
                    txt_tot_lam.Text = dt.Rows[0]["TotalLamina"].ToString();
                    txt_used_lam.Text = dt.Rows[0]["Printed"].ToString();
                    txt_wasted_lam.Text = dt.Rows[0]["Wasted"].ToString();
                    txt_rest_lam.Text = Convert.ToString(Convert.ToInt32(dt.Rows[0]["TotalLamina"].ToString()) - (Convert.ToInt32(dt.Rows[0]["Printed"].ToString()) + Convert.ToInt32(dt.Rows[0]["Wasted"].ToString())));

                    txt_used_lam_date.Text = dt.Rows[0]["UsedTillDate"].ToString();
                    txt_wasted_lam_date.Text = dt.Rows[0]["WastedTillDate"].ToString();

                }
            }
            else
            {
                Response.Write("<script language=javascript>alert('Please enter both date ')</script>");
                return;

            }
        }
        catch (Exception ex)
        {
            ObjGenBal = new BaseLayer.General_function();
            //Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            string err = ObjGenBal.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.CssClass = "warning-box";
            LabelMessage.Visible = true;
        }
    }
}