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

public partial class Admin_frmLaminaReport : System.Web.UI.Page
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
        From.HRef = "javascript:NewCal('" + txtFromDate.ClientID + "','DDMMMYYYY','','',5,1)";
        To.HRef = "javascript:NewCal('" + txtToDate.ClientID + "','DDMMMYYYY','','',5,1)";



        //LocalReport report = new LocalReport();
        //report.ReportPath = @"Admin/Reports/ProductionRep.rdlc";
        //report.DataSources.Add(new ReportDataSource("DataSet1", LoadData()));
        if (!IsPostBack)
        {
            CompareValidator1.ValueToCompare = DateTime.Now.ToShortDateString();
            CompareValidator3.ValueToCompare = DateTime.Now.ToShortDateString();


            // DivPrint.Visible = false;

            // string queryforzonename = "select b.ZoneName,b.zonecode from UserZoneRelation as a, Zonemaster as b where a.ZoneCode=b.ZoneCode and a.UserId=" + objectSessionHolderPersistingData.User_ID + "";
            // objgenenral = new BaseLayer.General_function();
            // DataTable dt1 = new DataTable();
            // dt1 = objgenenral.FetchData(queryforzonename);
            // if (dt1.Rows.Count > 0)
            // {
            ////     dpd_zone.SelectedValue = dt.Rows[0]["zonecode"].ToString();
            // }

        }
    }

    protected void btn_generate_report_Click(object sender, EventArgs e)
    {
        ObjGeneral = new BaseLayer.General_function();
        DataTable dt = new DataTable();
        //string query = "SELECT count(*) as TotalLamina, ISNULL(SUM(CASE WHEN isnull(lam_printedYN, 0) = 1 THEN 1 END), 0) as Printed, ISNULL(SUM(CASE WHEN isnull(lam_wastedYN, 0) = 1 THEN 1 END), 0) as Wasted  from tbl_lamination_detail";
        string query = "SELECT       CONVERT(varchar(19),tbl_lamination_detail.created_on,105) As Date, tbl_lamination_detail.lam_issued_cerpac_no as CerpacNo, tbl_lamination_detail.lam_issued_cerpac_fileno as FormNo, tbl_lamination_detail.card_no, tbl_lamination_detail.lam_No as FrontLam, tbl_lamination_detail_1.lam_no as BackLam, " +
                         "  CASE WHEN isnull(tbl_lamination_detail.lam_wastedYN, 0) " +
                         " = 1 THEN 'BAD' ELSE 'GOOD' END AS Status " +
" FROM            (SELECT        lam_id, lam_No, lamflag_f_b, lam_printedYN, lam_wastedYN, lam_issued_cerpac_no, lam_issued_cerpac_fileno, created_on, created_by, " +
                         " card_no, free1, free2, free3, free4 FROM dbo.tbl_lamination_detail AS tbl_lamination_detail_3" +
                          " WHERE        (SUBSTRING(lam_No, 1, 1) = 'F')) AS tbl_lamination_detail INNER JOIN (SELECT        lam_id, lam_No, lamflag_f_b, lam_printedYN, lam_wastedYN, lam_issued_cerpac_no, lam_issued_cerpac_fileno, created_on, created_by, " +
                  " card_no, free1, free2, free3, free4 FROM            dbo.tbl_lamination_detail AS tbl_lamination_detail_2 WHERE        (SUBSTRING(lam_No, 1, 1) = 'B')) AS tbl_lamination_detail_1 ON tbl_lamination_detail.card_no = tbl_lamination_detail_1.card_no where CONVERT(date,tbl_lamination_detail.created_on,105) between CONVERT(date,'" + txtFromDate.Value + "',105) and CONVERT(date,'" + txtToDate.Value + "',105) and (tbl_lamination_detail.lam_printedYN=1 or tbl_lamination_detail.lam_wastedYN=1)";




        try
        {
            dt = ObjGeneral.FetchData(query);
            //if (dt.Rows.Count > 0)
            if (dt.Rows.Count > 0)
            {
                if (ddl_filter.SelectedValue != "ALL")
                {
                    DataView dvData = new DataView(dt);
                    dvData.RowFilter = "Status = '" + ddl_filter.SelectedValue + "'";
                    GridView1.DataSource = dvData;
                }
                else
                {
                    GridView1.DataSource = dt;
                }
                    GridView1.DataBind();
            }
        }
        catch (Exception e1)
        {
        }
    }
    protected void btn_excel_Click(object sender, ImageClickEventArgs e)
    {

        string html = HdnValue.Value;
        ExportToExcel(ref html, "MyReport");
        // ClientScript.RegisterStartupScript(this.GetType(), "GetData", "a=GetValue();alert(a)", true);
        // Data = a;//a is Javascript Variable

        // string html = "";
        //var sb = new StringBuilder();
        //divmain.RenderControl(new HtmlTextWriter(new System.IO.StringWriter(sb)));

        //string s = sb.ToString();


        //Response.Clear();
        //Response.AddHeader("content-disposition", "attachment;filename=FileName.xls");
        //Response.Charset = "";
        //Response.ContentType = "application/vnd.xls";
        //System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        //System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        //DivReport.RenderControl(htmlWrite);
        //Response.Write(stringWrite.ToString());
        //Response.End();  
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


        /***********
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=Panel.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        //DivReport.RenderControl(hw);

        //hw.ToString() = html;
        StringReader sr = new StringReader(sw.ToString());
        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();
        htmlparser.Parse(sr);
        pdfDoc.Close();
        Response.Write(pdfDoc);
        Response.End();
**************/

    }
}