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
using Microsoft.Reporting.WebForms;
using System.Drawing.Printing;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Drawing;
using System.Text;
using System.IO;
//using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.text;

using System.Globalization;

public partial class Admin_ConsolidatedReports : System.Web.UI.Page
{

    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    BaseLayer.General_function objgenenral = null;
    BaseLayer.General_function ObjGeneral = null;
    protected BaseLayer.General_function ObjGenBal = null;
    protected DataSet objDs = new DataSet();
    string UserID = null;
    #endregion


    protected void Page_Load(object sender, EventArgs e)
    {
        From.HRef = "javascript:NewCal('" + txtFromDate.ClientID + "','DDMMMYYYY','','',3,1)";
        To.HRef = "javascript:NewCal('" + txtToDate.ClientID + "','DDMMMYYYY','','',3,1)";
       


        //LocalReport report = new LocalReport();
        //report.ReportPath = @"Admin/Reports/ProductionRep.rdlc";
        //report.DataSources.Add(new ReportDataSource("DataSet1", LoadData()));
        if (!IsPostBack)
        {
            R1.Visible = false;
            R2.Visible = true;
            DivPrint.Visible = false;
            //ReportDataSource datasource = new ReportDataSource("DataSet1", LoadData());
            //ReportViewer1.LocalReport.DataSources.Clear();
            //ReportViewer1.LocalReport.DataSources.Add(datasource);
            //ReportViewer1.LocalReport.Refresh();
            //////Nationality();

            //ReportViewer1.Visible = false;
            //Zone();
            objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
            UserID = objectSessionHolderPersistingData.User_ID.ToString();
            Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            string queryforzonename = "select b.ZoneName,b.ZoneCode from UserZoneRelation as a, Zonemaster as b where a.ZoneCode=b.ZoneCode and a.UserId=" + objectSessionHolderPersistingData.User_ID + "";
            ObjGenBal = new BaseLayer.General_function();
            DataTable dt = new DataTable();
            try
            {
                dt = ObjGenBal.FetchData(queryforzonename);
                if (dt.Rows.Count > 0)
                {
                    LabelMessage.Text = "Zone" + " " + dt.Rows[0]["ZoneName"].ToString();
                    LabelMessage.Visible = true;
                    LabelMessage.BorderStyle = BorderStyle.None;
                   // txtZoneCode.Text = dt.Rows[0]["ZoneName"].ToString() + "--" + dt.Rows[0]["ZoneCode"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                dt = null;
                ObjGenBal = null;
            }
        }
    }


    
    protected void btn_generate_report_Click(object sender, EventArgs e)
    {  

      
        if (txtFromDate.Value == "" && txtToDate.Value == "")
        {

            Response.Write("<script language=javascript>alert('Please Fill From- Date & To-Date')</script>");
            return;

        }


        if (txtFromDate.Value != "" && txtToDate.Value != "")
        {
            CerpacDate();
           
            

        }
       // PrintReports();

    }
    protected   DataTable  PrintReports()
    {
       // if (Request.QueryString["AppID"] != null)
        {

            objgenenral = new BaseLayer.General_function();


            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();

            dt.Columns.Add("ZoneName            ", typeof(String));
            dt.Columns.Add("Nationality         ", typeof(String));
            dt.Columns.Add("Passport            ", typeof(String));
            dt.Columns.Add("ForeName            ", typeof(String));
            dt.Columns.Add("Cerpac No.          ", typeof(String));
            dt.Columns.Add("FRN No.             ", typeof(String));
            dt.Columns.Add("Card No.            ", typeof(String));
            dt.Columns.Add("Cerpac_Receipt_Date  ", typeof(String));
            dt.Columns.Add("Cerpac_Expiry_Date   ", typeof(String));

           
            string query = "select FORMAT( DtAO,'yyyy-MMM') as Month_Year , sum(TotalSoldFormAO) as TotalSoldFormAO, sum(TotalAmountAO) as CollectionAO, sum(TotalSoldFormCR) as TotalSoldFormCR  , sum(TotalAmountCR) as CollectionCR,  sum(TotalAmountAO)+sum(TotalAmountCR) as TotalCollection, Format((((sum(TotalAmountAO)+sum(TotalAmountCR))* 50 )/100),'N2') as TotalCollectionFifty, Format( ( ((sum(TotalAmountAO)+sum(TotalAmountCR) )* 40 )/100),'N2') TotalCollectionForty, Format( ( ((sum(TotalAmountAO)+sum(TotalAmountCR) )* 10 )/100),'N2') TotalCollectionTenth, Format( ( ((sum(TotalAmountAO)+sum(TotalAmountCR) )* 45 )/100),'N2') TotalCollectionFortyfive, format(( ((sum(TotalAmountAO)+sum(TotalAmountCR) )* 5 )/100),'N2') TotalCollectionFive    From SoldFromDetails_DateWise where DtAO between  '" + ConvertDate(txtFromDate.Value, "d-MM-yyyy") + "' and '" + ConvertDate(txtToDate.Value, "d-MM-yyyy") + "'   group by YEAR(DtAO), MONTH (DtAO), FORMAT(DtAO, 'yyyy-MMM') order by YEAR(DtAO), MONTH (DtAO)";
            dt1 = objgenenral.FetchData(query);
            int i, count = 0;
            count=dt1.Rows.Count;
            for ( i = 0; i < count ; i++)
            {
                dt.Rows.Add(dt1.Rows[i][0].ToString(),
                    dt1.Rows[i][1].ToString(),
                    dt1.Rows[i][2].ToString(),
                    dt1.Rows[i][3].ToString(),
                    dt1.Rows[i][4].ToString(),
                    dt1.Rows[i][5].ToString(),
                    dt1.Rows[i][6].ToString(),
                    dt1.Rows[i][7].ToString(),
                    dt1.Rows[i][8].ToString());
            }

           // GridView1.DataSource = dt;
            //GridView1.DataBind();
            return dt;
        }
    }

    private DataTable CerpacDate()
    {

        objgenenral = new BaseLayer.General_function();
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        DataTable dt = new DataTable();

        string query = "select FORMAT( DtAO,'yyyy-MMM') as Month_Year , sum(TotalSoldFormAO) as TotalSoldFormAO, sum(TotalAmountAO) as CollectionAO, sum(TotalSoldFormCR) as TotalSoldFormCR  , sum(TotalAmountCR) as CollectionCR,  sum(TotalAmountAO)+sum(TotalAmountCR) as TotalCollection, Format((((sum(TotalAmountAO)+sum(TotalAmountCR))* 50 )/100),'N2') as TotalCollectionFifty, Format( ( ((sum(TotalAmountAO)+sum(TotalAmountCR) )* 40 )/100),'N2') TotalCollectionForty, Format( ( ((sum(TotalAmountAO)+sum(TotalAmountCR) )* 10 )/100),'N2') TotalCollectionTenth, Format( ( ((sum(TotalAmountAO)+sum(TotalAmountCR) )* 45 )/100),'N2') TotalCollectionFortyfive, format(( ((sum(TotalAmountAO)+sum(TotalAmountCR) )* 5 )/100),'N2') TotalCollectionFive    From SoldFromDetails_DateWise where DtAO between  '" + ConvertDate(txtFromDate.Value, "d-MM-yyyy") + "' and '" + ConvertDate(txtToDate.Value, "d-MM-yyyy") + "'   group by YEAR(DtAO), MONTH (DtAO), FORMAT(DtAO, 'yyyy-MMM') order by YEAR(DtAO), MONTH (DtAO)";

       
        if (txtFromDate.Value == "" && txtToDate.Value == "")
        {
            //  ReportViewer1.Visible = false;

            //saurabh
            //  R1.Visible = false;
        }

        
        if (txtFromDate.Value != "" && txtToDate.Value != "")
        {
            CallDate();
           
            dt = objgenenral.FetchData(query);
            objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.Text, query);

            if (dt.Rows.Count > 0)
            {
                lblFDate.Text = txtFromDate.Value;
                lblTDate.Text = txtToDate.Value;
                R1.Visible = true;
                R2.Visible = false;
                DivPrint.Visible = true;
            }
            
        }
        return dt;
    }



    
    public void CallDate()
    {
        ObjGeneral = new BaseLayer.General_function();
        DataTable dt = new DataTable();
        string query = "Select DATEDIFF(d, '" + ConvertDate(txtFromDate.Value, "d-MM-yyyy") + "','" + ConvertDate(txtToDate.Value, "d-MM-yyyy") + "')";
        dt = ObjGeneral.FetchData(query);
        if (txtFromDate.Value != "" && txtToDate.Value != "")
        {
            if (Convert.ToInt32(dt.Rows[0].ItemArray[0].ToString()) < 0)
            {
           
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('To-Date must be greater than From- Date.');", true);
                return;
            }           
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

   
    protected void btnBack_Click(object sender, ImageClickEventArgs e)
    {
        R1.Visible = false;
        R2.Visible = true;
        DivPrint.Visible = false;
        
        Response.Redirect("~/Admin/FrmSoldFormDetails.aspx");

    }
    protected void btn_excel_Click(object sender, ImageClickEventArgs e)
    {

        string html = HdnValue.Value;
        ExportToExcel(ref html, "MyReport");
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

}