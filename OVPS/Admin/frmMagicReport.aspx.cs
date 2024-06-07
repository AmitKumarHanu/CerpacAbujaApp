﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using DataAccessLayer;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Drawing;
using System.Text;
using System.IO;
using System.Globalization;

//using iTextSharp.text.html.simpleparser;
//using iTextSharp.text.pdf;
//using iTextSharp.text;

public partial class Admin_frmMagicReport : System.Web.UI.Page
{

    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    BaseLayer.General_function objgenenral = null;
    BaseLayer.General_function ObjGeneral = null;
    protected BaseLayer.General_function ObjGenBal = null;
    protected DataSet objDs = new DataSet();



    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        if (objectSessionHolderPersistingData == null)
        {
            Response.Redirect("../Login.aspx");
        }

        From.HRef = "javascript:NewCal('" + txtFromDate.ClientID + "','DDMMMYYYY','','',5,1)";
        To.HRef = "javascript:NewCal('" + txtToDate.ClientID + "','DDMMMYYYY','','',5,1)";



        //LocalReport report = new LocalReport();
        //report.ReportPath = @"Admin/Reports/ProductionRep.rdlc";
        //report.DataSources.Add(new ReportDataSource("DataSet1", LoadData()));
        if (!IsPostBack)
        {
            CompareValidator1.ValueToCompare = DateTime.Now.ToShortDateString();
            CompareValidator3.ValueToCompare = DateTime.Now.ToShortDateString();
            btn_generate_report0.Attributes.Add("onclick", "if(!pwd('Submit')) return false;");
            sp2.Visible = false;
            sp3.Visible = false;
            // DivPrint.Visible = false;
        }
    }
    protected void btn_generate_report_Click(object sender, EventArgs e)
    {
        if (txtFromDate.Value == "" || txtToDate.Value == "")
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Please Fill From- Date & To-Date.');", true);
            // Response.Write("<script language=javascript>alert('Please Fill From- Date & To-Date')</script>");
            return;

        }


        if (txtFromDate.Value != "" && txtToDate.Value != "")
        {
            try
            {
                CerpacDate();
                lblFDate.Text = txtFromDate.Value;
                lblTDate.Text = txtToDate.Value;
                R1.Visible = true;
                //   R2.Visible = false;
                // DivPrint.Visible = true;
            }

            catch (Exception ep)
            {
                string exp = ep.ToString();
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Please Try Again.');", true);

                lblErrorMsg.Text =  ep.Message;
            }

        }
    }

    protected void dropdown_SearchOption_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ObjGenBal = new BaseLayer.General_function();
            if (dropdown_SearchOption.SelectedValue == "Nationality")
            {
                sp1.Visible = true;
                sp2.Visible = false;
                sp3.Visible = false;
                string queryfornationality = "Select * from NationalityMaster order by adjective";
                ObjGenBal.Fill_DDLReport(dpd_search, queryfornationality, "adjective", "adjective");
            }

            if (dropdown_SearchOption.SelectedValue == "Company")
            {
                Session["CerpaxNo"] = "AO121212";
                //string queryfornationality = "Select * from CompMaster order by company";
                // ObjGenBal.Fill_DDL(dpd_search, queryfornationality, "company", "regno");

                sp1.Visible = false;
                sp2.Visible = true;
                sp3.Visible = false;
            }

            if (dropdown_SearchOption.SelectedValue == "ProducedONDate")
            {
                sp1.Visible = true;
                sp2.Visible = false;
                sp3.Visible = false;
                string queryfornationality = "Select * from NationalityMaster where 1<>1 order by adjective";
                ObjGenBal.Fill_DDLReport(dpd_search, queryfornationality, "adjective", "adjective");
            }

            if (dropdown_SearchOption.SelectedValue == "User")
            {
                sp1.Visible = false;
                sp2.Visible = false;
                sp3.Visible = true;
                string queryforusergrp = "Select * from GroupMaster order by grpname";
                ObjGenBal.Fill_DDLReport(dpd_usergrp, queryforusergrp, "grpname", "grpid");

                string queryforuser = "Select * from UserMaster order by username";
                ObjGenBal.Fill_DDLReport(dpd_user, queryforuser, "username", "userid");

            }
        }
        catch (Exception ex)
        {
        }

    }

    private DataTable LoadData()
    {
        ObjGeneral = new BaseLayer.General_function();
        DataTable dt = new DataTable();
        string query = "SELECT  a.forename, a.cerpac_no, a.cerpac_file_no, b.CardNo, a.passport_no, a.nationality,  c.ZoneName, cerpac_receipt_date, cerpac_expiry_date  From vw_prod_consolidated_data a INNER JOIN CerpacNo_Out_One b ON  a.CerpacNo=b.cerpac_no   INNER JOIN Zonemaster c ON b.ZoneCode = c.ZoneCode ";
        dt = ObjGeneral.FetchData(query);


        return dt;
    }

    private DataTable CerpacDate()
    {

        objgenenral = new BaseLayer.General_function();

        DataTable dt = new DataTable();


        //string query = " SELECT a.nationality,a.passport_no, a.forename, a.cerpac_no, a.cerpac_file_no, convert(varchar(10),a.cerpac_receipt_date,103) as cerpac_receipt_date, convert(varchar(10),a.cerpac_expiry_date,103) as cerpac_expiry_date,convert(varchar(10),a.date_issued,103) as CreatedON, isnull(c.zonename,'') as ZoneName, isnull(d.company,a.company) as Company, a.designation FROM Issue a LEFT OUTER JOIN UserZoneRelation b ON a.issued_by_user_id = b.UserId left outer join Zonemaster c on b.ZoneCode=c.ZoneCode left outer join CompMaster d on a.company=d.regno";

       // string query = "select * from vw_Allin1_ReportNew_S ";

        string query = "select * from vw4 ";
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




            //condition = condition + " Where   (producedon Between '" + ConvertDate(txtFromDate.Value, "d-MM-yyyy") + "' And '" + ConvertDate(txtToDate.Value, "d-MM-yyyy") + "' or producedonDate_C Between '" + ConvertDate(txtFromDate.Value, "d-MM-yyyy") + "' And '" + ConvertDate(txtToDate.Value, "d-MM-yyyy") + "') and (IsProduced=1 or IsProduced_C=1)";
            condition = condition + " Where   producedon Between '" + ConvertDate(txtFromDate.Value, "d-MM-yyyy") + " 00:00:00' And '" + ConvertDate(txtToDate.Value, "d-MM-yyyy") + " 23:59:59' and IsProduced=1 ";


        }

        if (dpd_search.Visible == true && dpd_search.SelectedItem.Text != "ALL")
        {
            condition = condition + " and " + dropdown_SearchOption.SelectedValue + "='" + dpd_search.SelectedValue + "'";
        }
        if (dropdown_SearchOption.SelectedValue == "Company" && txtcompname.Text != "ALL")
        {
            condition = condition + " and a." + dropdown_SearchOption.SelectedValue + "='" + txtcompid.Text + "'";
        }

        if (dpd_zone.SelectedValue != "ALL")
        {
            condition = condition + " and ZoneCode='" + dpd_zone.SelectedValue + "'";
        }

        if (dropdown_SearchOption.SelectedValue == "User")
        {
            if (dpd_user.SelectedItem.Text != "ALL")
                condition = condition + " and (username='" + dpd_user.SelectedItem.Text + "' or dataEntryUser='" + dpd_user.SelectedItem.Text + "' or authuser='" + dpd_user.SelectedItem.Text + "' or qualuser='" + dpd_user.SelectedItem.Text + "')";
            else if (dpd_usergrp.SelectedItem.Text != "ALL")
                condition = condition + " and (grpid1=" + dpd_usergrp.SelectedValue + " or grpid2=" + dpd_usergrp.SelectedValue + " or grpid3=" + dpd_usergrp.SelectedValue + " or grpid4=" + dpd_usergrp.SelectedValue + ")";

        }
        //   if (chk_date.Checked == true || chk_nationality.Checked == true || chk_user.Checked == true || chk_Zone.Checked == true)
        {
            // condition = condition + " And a.IsProduced=1 order by a.IsProduced ";
            condition = condition + " order by ";
        }

        //if (chk_date.Checked == true)
        //{
        //    condition = condition + " a.date_issued,";
        //    //condition = condition + " , cerpac_receipt_date, cerpac_expiry_date";
        //}

        //if (chk_nationality.Checked == true)
        //{
        //    condition = condition + " a.nationality,";
        //    // condition = condition + " , nationality";
        //}

        //if (chk_user.Checked == true)
        //{
        //    condition = condition + " a.forename+ a.surname,";
        //    //condition = condition + " , forename";
        //}

        //   if (chk_Zone.Checked == true)
        if (dropdown_SearchOption.SelectedValue == "ProducedONDate")
        {
            condition = condition + "ProducedON , zonename";
        }
        else if (dropdown_SearchOption.SelectedValue == "User")
        {
            condition = condition + "ProducedON , zonename";
        }
        else
        {
            condition = condition + dropdown_SearchOption.SelectedValue + " , zonename";
            //condition = condition + " , ZoneCode";
        }

        query = query + condition.TrimEnd(',');

        dt = objgenenral.FetchData(query);
        objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.Text, query);
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
    protected void btn_excel_Click(object sender, ImageClickEventArgs e)
    {

        string html = HdnValue.Value;
        ExportToExcel(ref html, "Production_Report");

        Response.Redirect("frmMagicReport.aspx");
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
    protected void dpd_usergrp_SelectedIndexChanged(object sender, EventArgs e)
    {
        ObjGenBal = new BaseLayer.General_function();
        if (dpd_usergrp.SelectedValue == "ALL" && dpd_zone.SelectedValue=="ALL")
        {
            string queryforuser = "Select * from UserMaster order by username";
            ObjGenBal.Fill_DDLReport(dpd_user, queryforuser, "username", "userid");
        }
        else
        {
           // string queryforuser = "Select * from UserMaster where grpid=" + dpd_usergrp.SelectedValue + "  order by username";
           // ObjGenBal.Fill_DDLReport(dpd_user, queryforuser, "username", "userid");
            string queryforuser = "";
            if (dpd_usergrp.SelectedValue == "ALL")
            {
                 queryforuser = "select * from UserMaster a, UserZoneRelation b where a.UserID=b.UserId and b.zonecode=" + dpd_zone.SelectedValue + "  order by username";
            }

            else if (dpd_zone.SelectedValue == "ALL")
            {
                queryforuser = "select * from UserMaster a, UserZoneRelation b where a.UserID=b.UserId and grpid=" + dpd_usergrp.SelectedValue + "  order by username";
            }

            else
            {
                queryforuser = "select * from UserMaster a, UserZoneRelation b where a.UserID=b.UserId and grpid=" + dpd_usergrp.SelectedValue + " and b.zonecode=" + dpd_zone.SelectedValue + "  order by username";
            }


            ObjGenBal.Fill_DDLReport(dpd_user, queryforuser, "username", "userid");
        }
    }
    protected void dpd_zone_SelectedIndexChanged(object sender, EventArgs e)
    {
        ObjGenBal = new BaseLayer.General_function();
        if (dpd_zone.SelectedValue == "ALL")
        {
            string queryforusergrp = "Select * from GroupMaster order by grpname";
            ObjGenBal.Fill_DDLReport(dpd_usergrp, queryforusergrp, "grpname", "grpid");

            string queryforuser = "Select * from UserMaster order by username";
            ObjGenBal.Fill_DDLReport(dpd_user, queryforuser, "username", "userid");
        }
        else
        {
            string queryforusergrp = "Select * from GroupMaster order by grpname";
            ObjGenBal.Fill_DDLReport(dpd_usergrp, queryforusergrp, "grpname", "grpid");

            string queryforuser = "select * from UserMaster a, UserZoneRelation b where a.UserID=b.UserId and a.grpid=" + dpd_usergrp.SelectedValue + " and b.zonecode=" + dpd_zone.SelectedValue + "  order by username";
            ObjGenBal.Fill_DDLReport(dpd_user, queryforuser, "username", "userid");
        }
    }
}