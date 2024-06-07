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


    private DataTable LoadData()
    {
        ObjGeneral = new BaseLayer.General_function();
        DataTable dt = new DataTable();
        string query = "SELECT  a.forename, a.cerpac_no, a.cerpac_file_no, b.CardNo, a.passport_no, a.nationality,  c.ZoneName, cerpac_receipt_date, cerpac_expiry_date  From vw_prod_consolidated_data a INNER JOIN CerpacNo_Out_One b ON  a.CerpacNo=b.cerpac_no   INNER JOIN Zonemaster c ON b.ZoneCode = c.ZoneCode where zonecode=" + dt.Rows[0]["ZoneCode"].ToString();

        dt = ObjGeneral.FetchData(query);
        

        return dt;
    }
    protected void btn_generate_report_Click(object sender, EventArgs e)
    {

   

        //LoadData();

        ////ReportViewer1.Visible = true;
        //ReportDataSource datasource = new ReportDataSource("DataSet1", CerpacDate());
        //ReportViewer1.LocalReport.DataSources.Clear();
        //ReportViewer1.LocalReport.DataSources.Add(datasource);
        //ReportViewer1.LocalReport.Refresh();

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

           //string query = "SELECT  c.ZoneName, a.nationality,a.passport_no, a.forename, a.cerpac_no, a.cerpac_file_no, b.CardNo,  cerpac_receipt_date, cerpac_expiry_date From vw_prod_consolidated_data a INNER JOIN CerpacNo_Out_One b ON  a.CerpacNo=b.cerpac_no  INNER JOIN Zonemaster c ON b.ZoneCode = c.ZoneCode ";

            string query = "SELECT  c.ZoneName, a.nationality,a.passport_no, a.forename, a.cerpac_no, a.cerpac_file_no, b.CardNo,  cerpac_receipt_date, cerpac_expiry_date From vw_prod_consolidated_data a INNER JOIN CerpacNo_Out_One b ON  a.CerpacNo=b.cerpac_no  INNER JOIN Zonemaster c ON b.ZoneCode = c.ZoneCode ";
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
        
        //string query = "SELECT  a.forename, a.cerpac_no, a.cerpac_file_no, b.CardNo, a.passport_no, a.nationality,  c.ZoneName, a.cerpac_receipt_date, a.cerpac_expiry_date, convert(varchar(10),a.CreatedON,103) as CreatedON, isnull( a.IsProduced, 0) From vwconsolidatedreport a INNER JOIN CerpacNo_Out_One b ON  a.CerpacNo=b.cerpac_no   INNER JOIN Zonemaster c ON b.ZoneCode = c.ZoneCode ";
        string query = " SELECT a.nationality,a.passport_no, a.forename, a.cerpac_no, a.cerpac_file_no, convert(varchar(10),a.cerpac_receipt_date,103) as cerpac_receipt_date, convert(varchar(10),a.cerpac_expiry_date,103) as cerpac_expiry_date,convert(varchar(10),a.date_issued,103) as CreatedON, isnull(b.zonecode,a.residence_issue_loc) as zonecode FROM Issue a LEFT OUTER JOIN UserZoneRelation b ON a.issued_by_user_id = b.UserId";
        //WHERE (dbo.Issue.residence_issue_loc = '512') OR (dbo.UserZoneRelation.ZoneCode = '512')";
        string condition = "";

        if (txtFromDate.Value == "" && txtToDate.Value == "")
        {
          //  ReportViewer1.Visible = false;

            //saurabh
          //  R1.Visible = false;
        }

        if (txtFromDate.Value != "" && txtToDate.Value != "")
        {
            CallDate();
            if (condition != "")
                condition = condition + "And ";

            //condition = condition + " Where   a.CreatedON Between '" + ConvertDate(txtFromDate.Value, "d-MM-yyyy") + "' And '" + ConvertDate(txtToDate.Value, "d-MM-yyyy") + "' and b.zonecode=(select zonecode from userzonerelation where userid=" + objectSessionHolderPersistingData.User_ID + ")";
            condition = condition + " Where   a.date_issued Between '" + ConvertDate(txtFromDate.Value, "d-MM-yyyy") + "' And '" + ConvertDate(txtToDate.Value, "d-MM-yyyy") + "' and (a.residence_issue_loc=(select zonecode from userzonerelation where userid=" + objectSessionHolderPersistingData.User_ID + ") or b.ZoneCode=(select zonecode from userzonerelation where userid=" + objectSessionHolderPersistingData.User_ID + "))";

           // condition = condition + " And a.IsProduced=1 ";
        }

        if (chk_date.Checked == true || chk_nationality.Checked == true || chk_user.Checked == true || chk_Zone.Checked == true)
        {
           // condition = condition + " And a.IsProduced=1 order by a.IsProduced ";
            condition = condition + " order by ";
        }

        if (chk_date.Checked == true)
        {

            condition = condition + "a.date_issued,";
            // condition = condition + " a.cerpac_receipt_date, a.cerpac_expiry_date,";
           
        }

        if (chk_nationality.Checked == true)
        {
            condition = condition + " a.nationality,";
           // condition = condition + " , nationality";
        }

        if (chk_user.Checked == true)
        {
            condition = condition + " a.forename, a.surname,";
            //condition = condition + " , forename";
        }

        if (chk_Zone.Checked == true)
        {
            condition = condition + " b.ZoneCode,";
            //condition = condition + " , ZoneCode";
        }

        query = query + condition.TrimEnd(',');
        
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
               // Response.Write("<script language=javascript>alert('To-Date must be greater than From- Date')</script>");

                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('To-Date must be greater than From- Date.');", true);
                return;
            }

            //if(Convert.ToDateTime(txtToDate.Value)>DateTime.Now)
            //{
            //}
        }
    }

    //public void Nationality()
    //{
  
    //   BaseLayer.General_function  ObjItemCode = new BaseLayer.General_function();
    //   string NationalityQuery = "SELECT Distinct(Nationality) FROM ProdReportCerpacCard ";
    //    ObjItemCode.Fill_DDL(ddlNationality, NationalityQuery, "Nationality", "Nationality");
    //}
    //public void Zone()
    //{

    //    BaseLayer.General_function ObjItemCode = new BaseLayer.General_function();
    //    string ZoneQuery = "SELECT Distinct(Zone) FROM ProdReportCerpacCard ";
    //    ObjItemCode.Fill_DDL( ddlZone, ZoneQuery, "Zone", "Zone");
    //}
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



    protected void btnBack_Click(object sender, EventArgs e)
    {
        R1.Visible = false;
        R2.Visible = true;
        DivPrint.Visible =  false;
        Response.Redirect("FrmConsolidatedReports.aspx");  
            
    }
}
