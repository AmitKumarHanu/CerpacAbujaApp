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
//using Microsoft.Reporting.WebForms;
using System.Drawing.Printing;
using System.Drawing.Printing;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Drawing2D;
using System.IO;
using System.Globalization;

public partial class Admin_frmLaminaRepDetail : System.Web.UI.Page
{

    #region "Declarations"
 
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    BaseLayer.General_function objgenenral = null;
    BaseLayer.General_function ObjGeneral = null;
    protected BaseLayer.General_function ObjGenBal = null;
    protected DataSet objDsCR = new DataSet();
    protected DataSet objDsWR = new DataSet();
   
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
                    lblZoneName.Text = dt.Rows[0]["ZoneName"].ToString();
                    lblZoneNameW.Text = dt.Rows[0]["ZoneName"].ToString();
                    LabelMessage.Visible = true;
                    LabelMessage.BorderStyle = BorderStyle.None;

                    CansolidatedReport();
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
        }
    }


    protected void CansolidatedReport()
    {
        //DataSet ds = new DataSet();
        ObjGeneral = new BaseLayer.General_function();
        DataTable dt = new DataTable();
        string query = "SELECT count(*) as TotalLamina, ISNULL(SUM(CASE WHEN isnull(lam_printedYN, 0) = 1 THEN 1 END), 0) as Printed, ISNULL(SUM(CASE WHEN isnull(lam_wastedYN, 0) = 1 THEN 1 END), 0) as Wasted  from tbl_lamination_detail";
        try
        {
            dt = ObjGeneral.FetchData(query);
            //if (dt.Rows.Count > 0)
            if (dt.Rows.Count > 0)
            {
                txt_tot_lam.Text = dt.Rows[0]["TotalLamina"].ToString();
                txt_used_lam.Text = dt.Rows[0]["Printed"].ToString();
                txt_wasted_lam.Text = dt.Rows[0]["Wasted"].ToString();
                txt_rest_lam.Text = Convert.ToString(Convert.ToInt32(dt.Rows[0]["TotalLamina"].ToString()) - (Convert.ToInt32(dt.Rows[0]["Printed"].ToString()) + Convert.ToInt32(dt.Rows[0]["Wasted"].ToString())));
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


    protected void DatawiseR_Click(object sender, EventArgs e)
    {
        Datewise.Visible = true;
        LamCard.Visible = false;
        LamWaste.Visible = false;
        MainDiv.Visible = false;
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
            lblFDate.Text = txtFromDate.Value;
            lblTDate.Text = txtToDate.Value;
            lblFDateW.Text = txtFromDate.Value;
            lblTDateW.Text = txtToDate.Value;
            lblZoneName.Text = lblZoneName.Text;
            if (Convert.ToInt32(dt.Rows[0].ItemArray[0].ToString()) < 0)
            {
                Response.Write("<script language=javascript>alert('To-Date must be greater than From- Date')</script>");
                return;
            }
        }
    }

    protected void btnCardReport_Click(object sender, EventArgs e)
    {
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


        if (txtFromDate.Value != "" && txtToDate.Value != "")
        {
            try
            {
                bind_PrintCard();
                LamCard.Visible = true;
                LamWaste.Visible = false;
                MainDiv.Visible = false;
                Datewise.Visible = false;
            }

            catch (Exception ep)
            {
                string exp = ep.ToString();
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Please Try Again.');", true);


            }

        }
    }
    protected void bind_PrintCard()
    {
        
        CallDate();

        //DataSet ds = new DataSet();
        ObjGeneral = new BaseLayer.General_function();
        DataTable dt = new DataTable();
        //string query = "SELECT count(*) as TotalLamina, ISNULL(SUM(CASE WHEN isnull(lam_printedYN, 0) = 1 THEN 1 END), 0) as Printed, ISNULL(SUM(CASE WHEN isnull(lam_wastedYN, 0) = 1 THEN 1 END), 0) as Wasted  from tbl_lamination_detail";
        string query = "Select A.lam_issued_cerpac_no, A.lam_issued_cerpac_fileno, A.card_no, A.lam_No as FrontL, B.lam_No as backL, A.lam_printedYN, A.lam_wastedYN, Convert(varchar(10),A.created_on,103) as Dt From (Select * From tbl_lamination_detail where lamflag_f_b='F') as A , (Select * From tbl_lamination_detail where lamflag_f_b='B') as B  where A.card_no= B.card_no and A.lam_printedYN = B.lam_printedYN and  B.lam_wastedYN=A.lam_wastedYN  and  A.created_by=B.created_by and A.lam_printedYN=1 and A.lam_wastedYN=0  and A.created_on >= '" + ConvertDate(txtFromDate.Value, "d-MM-yyyy") + "' and A.created_on<='" + ConvertDate(txtToDate.Value, "d-MM-yyyy") + "' order by A.created_on";
        try
        {
            dt = ObjGeneral.FetchData(query);
            //if (dt.Rows.Count > 0)
            if (dt.Rows.Count > 0)
            {
                objDsCR = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.Text, query);

            }
            else
            {
                Response.Write("<script language=javascript>alert('Lamination details could not found with in given date')</script>");
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
    
    protected void btnWastedReport_Click(object sender, EventArgs e)
    {
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


        if (txtFromDate.Value != "" && txtToDate.Value != "")
        {
            try
            {
                bind_wastedCard();
                LamCard.Visible = false;
                LamWaste.Visible =true;
                MainDiv.Visible = false;
                Datewise.Visible = false;
            }

            catch (Exception ep)
            {
                string exp = ep.ToString();
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Please Try Again.');", true);


            }

        }
    }
    protected void bind_wastedCard()
    {
        CallDate();

        //DataSet ds = new DataSet();
        ObjGeneral = new BaseLayer.General_function();
        DataTable dt = new DataTable();
        //string query = "SELECT count(*) as TotalLamina, ISNULL(SUM(CASE WHEN isnull(lam_printedYN, 0) = 1 THEN 1 END), 0) as Printed, ISNULL(SUM(CASE WHEN isnull(lam_wastedYN, 0) = 1 THEN 1 END), 0) as Wasted  from tbl_lamination_detail";
        string query = "Select A.lam_issued_cerpac_no, A.lam_issued_cerpac_fileno, A.card_no, A.lam_No as FrontL, B.lam_No as backL, A.lam_printedYN, A.lam_wastedYN, Convert(varchar(10),A.created_on,103) as Dt From (Select * From tbl_lamination_detail where lamflag_f_b='F') as A , (Select * From tbl_lamination_detail where lamflag_f_b='B') as B  where A.card_no= B.card_no and A.lam_printedYN = B.lam_printedYN and  B.lam_wastedYN=A.lam_wastedYN  and  A.created_by=B.created_by  and A.lam_wastedYN=1  and A.created_on >= '" + ConvertDate(txtFromDate.Value, "d-MM-yyyy") + "' and A.created_on<='" + ConvertDate(txtToDate.Value, "d-MM-yyyy") + "' order by A.created_on";
        try
        {
            dt = ObjGeneral.FetchData(query);
            //if (dt.Rows.Count > 0)
            if (dt.Rows.Count > 0)
            {
                objDsWR = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.Text, query);

            }
            else
            {
                Response.Write("<script language=javascript>alert('Lamination details could not found with in given date')</script>");
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
    protected void BtnExcel_Click(object sender, ImageClickEventArgs e)
    {
        string html = HdnValue.Value;
        ExportToExcel(ref html, "LaminateReport");
    }
    public void ExportToExcel(ref string html, string fileName)
    {
        html = html.Replace("&gt;", ">");
        html = html.Replace("&lt;", "<");
        HttpContext.Current.Response.ClearContent();
        HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + fileName + "_" + DateTime.Now.ToString("M_dd_yyyy_H_M_s") + ".xls");
        HttpContext.Current.Response.ContentType = "application/xls";
        HttpContext.Current.Response.Write(html);
        HttpContext.Current.Response.End();


    }

    protected void BtnExcelW_Click(object sender, ImageClickEventArgs e)
    {
        string html = HdnValue.Value;
        ExportToExcelW(ref html, "WastedLaminateReport");
    }
    public void ExportToExcelW(ref string html, string fileName)
    {
        html = html.Replace("&gt;", ">");
        html = html.Replace("&lt;", "<");
        HttpContext.Current.Response.ClearContent();
        HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + fileName + "_" + DateTime.Now.ToString("M_dd_yyyy_H_M_s") + ".xls");
        HttpContext.Current.Response.ContentType = "application/xls";
        HttpContext.Current.Response.Write(html);
        HttpContext.Current.Response.End();


    }
    protected void btnRefreshW_Click(object sender, ImageClickEventArgs e)
    {
        MainDiv.Visible = true;
        Datewise.Visible = false;
        LamCard.Visible = false;
        LamWaste.Visible = false;
        Response.Redirect("FrmLaminaRepDetail.aspx");
    }
    protected void btnRefresh_Click(object sender, ImageClickEventArgs e)
    {
        MainDiv.Visible = true;
        Datewise.Visible = false;
        LamCard.Visible = false;
        LamWaste.Visible = false;
        Response.Redirect("FrmLaminaRepDetail.aspx");
    }
}