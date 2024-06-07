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
using System.Data;
using System.Data.SqlClient;
//using Microsoft.Reporting.WebForms;
using System.Drawing.Printing;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Drawing;
using System.Text;
using System.IO;

using System.Globalization;

public partial class Admin_SpoilCardReports : System.Web.UI.Page
{

    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    //BaseLayer.General_function objgenenral = null;
    BaseLayer.General_function ObjGeneral = null;
    protected BaseLayer.General_function ObjGenBal = null;

    protected DataSet objDs = new DataSet();


    #endregion


    protected void Page_Load(object sender, EventArgs e)
    {
        From.HRef = "javascript:NewCal('" + txtFromDate.ClientID + "','DDMMMYYYY','','',5,1)";
        To.HRef = "javascript:NewCal('" + txtToDate.ClientID + "','DDMMMYYYY','','',5,1)";

        if (!IsPostBack)
        {
            CompareValidator1.ValueToCompare = DateTime.Now.ToShortDateString();
            CompareValidator3.ValueToCompare = DateTime.Now.ToShortDateString();
            btn_generate_report.Attributes.Add("onclick", "if(!pwd('Submit')) return false;");
            R1.Visible = false;
            R2.Visible = true;
            DivPrint.Visible = false;
           
        }
        
    }


    
    protected void btn_generate_report_Click(object sender, EventArgs e)
    {


        if (txtFromDate.Value != "" && txtToDate.Value != "")
        {
            CerpacDate();
            lblFDate.Text = txtFromDate.Value;
            lblTDate.Text = txtToDate.Value;
            R1.Visible = true;
            R2.Visible = false;
            DivPrint.Visible = true;

        }
        else if (txtFromDate.Value != "" && txtToDate.Value == "")
        {
            Response.Write("<script language=javascript>alert('Please Select To Date.')</script>");
            return;
        }
        
        else if (txtFromDate.Value == "" && txtToDate.Value != "")
        {
            Response.Write("<script language=javascript>alert('Please Select From Date.')</script>");
            return;
        }
        else
        {
            Response.Write("<script language=javascript>alert('Date must be select.')</script>");
            return;
        }

    }
    private DataTable CerpacDate()
    {
       
        ObjGeneral = new BaseLayer.General_function();
        DataTable dt = new DataTable();
        string query = "select  a.StickerIssuedToApplicationID, a.StickerNumber, a.StickerWastedReason, b.producedon,c.UserName From userstickerrelation a , peoplechild b, UserMaster c where b.ProducedBy=c.UserID And  a.StickerIssuedToApplicationID=b.FORMNO";
        string condition = "";
        if (txtFromDate.Value != "" && txtToDate.Value != "")
        {
            if (condition == "")
                condition = condition + " And   b.producedon between '" + ConvertDate(txtFromDate.Value.Trim(), "d-MM-yyyy") + "' And DateAdd(dd,1,'" + ConvertDate(txtToDate.Value.Trim(), "d-MM-yyyy") + "') ";
        }
       if (txtFromDate.Value != "" || txtFromDate.Value != ""  )
       {
           query = query + condition + " And a.StickerWastedYN = 1";
           dt = ObjGeneral.FetchData(query);
           objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.Text, query);
      
       }
       return dt;
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


    protected void btnExcel_Click(object sender, ImageClickEventArgs e)
    {
        string html = HdnValue.Value;
        ExportToExcel(ref html, "SpoilCardReport");
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

    protected void btnBack_Click(object sender, EventArgs e)
    {
        R1.Visible = false;
      //  R2.Visible = true;
        DivPrint.Visible = false;
        Response.Redirect("FrmSpoilCardReports.aspx");

    }

    public static string ConvertDate(string date, string pattern)
    {

        if (string.IsNullOrEmpty(date) == false && date != "")
        {
            DateTime date2;
            if (DateTime.TryParseExact(date, pattern, CultureInfo.InvariantCulture, DateTimeStyles.None, out date2))
            {
                // return date2.ToString("MM/dd/yyyy");
                return date2.ToString("MM-dd-yyyy");
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

       
}
