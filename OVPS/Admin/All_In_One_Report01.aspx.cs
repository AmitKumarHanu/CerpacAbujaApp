using System;
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

public partial class All_In_One_Report : System.Web.UI.Page
{

    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    BaseLayer.General_function objgenenral = null;
    BaseLayer.General_function ObjGeneral = null;
    protected BaseLayer.General_function ObjGenBal = null;
    protected DataSet objDs = new DataSet();
    protected DataSet objDs1 = new DataSet();
    protected DataSet objDs2 = new DataSet();
    protected DataSet objDs3 = new DataSet();
    protected DataSet objDs4 = new DataSet();
    protected DataSet objDs5 = new DataSet();
    string ZoneCode;
    protected DataSet objDs_wasted = new DataSet();
    protected DataSet objDs_prod = new DataSet();


    protected DataSet objDs_WrongForms = new DataSet();
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

        //menuTabs.Items[0].v
            //MenuItemCollection menuItems = menuTabs.Items;
            //MenuItem adminItem = new MenuItem();
            //foreach (MenuItem menuItem in menuItems)
            //{
            //    if (menuItem.Text == "Roles")
            //        adminItem = menuItem;
            //}
            //menuItems.Remove(0);
        //LocalReport report = new LocalReport();
        //report.ReportPath = @"Admin/Reports/ProductionRep.rdlc";
        //report.DataSources.Add(new ReportDataSource("DataSet1", LoadData()));
        if (!IsPostBack)
        {
            CompareValidator1.ValueToCompare = DateTime.Now.ToShortDateString();
            CompareValidator3.ValueToCompare = DateTime.Now.ToShortDateString();
          //  btn_generate_report0.Attributes.Add("onclick", "if(!pwd('Submit')) return false;");
            sp2.Visible = false;
            // DivPrint.Visible = false;

            string queryforzonename = "select b.ZoneName,b.zonecode from UserZoneRelation as a, Zonemaster as b where a.ZoneCode=b.ZoneCode and a.UserId=" + objectSessionHolderPersistingData.User_ID + "";
            objgenenral = new BaseLayer.General_function();
            DataTable dt = new DataTable();
            dt = objgenenral.FetchData(queryforzonename); 
            
            if (dt.Rows.Count > 0)
            {
                dpd_zone.SelectedValue = dt.Rows[0]["zonecode"].ToString();
            }
            dpdYear.DataSource = Enumerable.Range(DateTime.Now.AddYears(-1).Year, 3);
            dpdYear.DataBind();

        }
    }
    protected void btn_generate_report_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(dpdMon.SelectedValue) > 0 && Convert.ToInt32(dpdYear.SelectedValue) > 0)
        {
            txtFromDate.Value = "01-" + dpdMon.SelectedValue + "-" + dpdYear.SelectedValue;

            int mon = (Convert.ToInt32(dpdMon.SelectedValue) + 1);
            if(mon<10)
            txtToDate.Value = "01-0" + mon + "-" + dpdYear.SelectedValue;
            else
                txtToDate.Value = "01-" + mon + "-" + dpdYear.SelectedValue;
        }
        if (txtFromDate.Value == "" || txtToDate.Value == "")
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Please Fill Month & Year.');", true);
            // Response.Write("<script language=javascript>alert('Please Fill From- Date & To-Date')</script>");
            return;

        }


        if (txtFromDate.Value != "" && txtToDate.Value != "")
        {
            try
            {
                CerpacDate();
                //lblFDate.Text = txtFromDate.Value;
                //lblTDate.Text = txtToDate.Value;
                //R1.Visible = true;
                //   R2.Visible = false;
                // DivPrint.Visible = true;
             
                VerfiedData();
                ContecData();
                AuthData();
                ProdData();
                QualData();


                wrongformsUsed();





                objgenenral = new BaseLayer.General_function();
                DataTable dt = new DataTable();
                string query = "";
                query = "SELECT TOP (100) PERCENT ISNULL(dbo.vw_rep_cnt1.Month, dbo.vw_rep_cnt.Month) AS Month_S, ISNULL(dbo.vw_rep_cnt1.Year, dbo.vw_rep_cnt.Year) AS Year_S," +
                        " dbo.vw_rep_cnt1.AO AS AO_S, dbo.vw_rep_cnt1.CR AS CR_S, ISNULL(dbo.vw_rep_cnt.Total, 0) AS Total, ISNULL(dbo.vw_rep_cnt.ZoneName, '') " +
                        " AS ZoneName, ISNULL(dbo.vw_rep_cnt.AO, 0) AS AO, ISNULL(dbo.vw_rep_cnt.AR, 0) AS AR, ISNULL(dbo.vw_rep_cnt.CR, 0) AS CR, dbo.vw_rep_cnt1.mon " +
                        " FROM dbo.vw_rep_cnt FULL OUTER JOIN   dbo.vw_rep_cnt1 ON dbo.vw_rep_cnt.Month = dbo.vw_rep_cnt1.Month AND dbo.vw_rep_cnt.Year = dbo.vw_rep_cnt1.Year " +
                        " where dbo.vw_rep_cnt.Month='" + dpdMon.SelectedItem + "' and ISNULL(dbo.vw_rep_cnt1.Year, dbo.vw_rep_cnt.Year)=" + dpdYear.SelectedValue + "  ORDER BY Year_S, dbo.vw_rep_cnt1.mon";

                dt = objgenenral.FetchData(query);
                objDs_prod = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.Text, query);

                DataTable dt_wasted = new DataTable();
                string qry_wasted = " SELECT SUM(dbo.UserStickerRelation.StickerWastedYN) AS WasteCards, CONVERT(varchar(3), dbo.PeopleChild.ProducedOn, 100) AS Month, Month(dbo.PeopleChild.ProducedOn) as mon," +
                                    " YEAR(dbo.PeopleChild.ProducedOn) AS Year, dbo.Zonemaster.ZoneName FROM (SELECT cerpac_no, cerpac_file_no FROM dbo.People) AS a INNER JOIN " +
                                    " dbo.UserStickerRelation ON a.cerpac_no = dbo.UserStickerRelation.StickerIssuedToApplicationID INNER JOIN dbo.PeopleChild ON a.cerpac_file_no = dbo.PeopleChild.FORMNO AND a.cerpac_no = dbo.PeopleChild.CerpacNo INNER JOIN " +
                                    " dbo.UserZoneRelation ON dbo.PeopleChild.VerifiedBy = dbo.UserZoneRelation.UserId INNER JOIN dbo.Zonemaster ON dbo.UserZoneRelation.ZoneCode = dbo.Zonemaster.ZoneCode " +
                                    " WHERE (dbo.UserStickerRelation.StickerWastedYN = 1) and Month(dbo.PeopleChild.ProducedOn)=" + dpdMon.SelectedValue + " and YEAR(dbo.PeopleChild.ProducedOn)=" + dpdYear.SelectedValue + "  GROUP BY Month(dbo.PeopleChild.ProducedOn), CONVERT(varchar(3), dbo.PeopleChild.ProducedOn, 100), YEAR(dbo.PeopleChild.ProducedOn), dbo.Zonemaster.ZoneName";

                dt_wasted = objgenenral.FetchData(qry_wasted);
                objDs_wasted = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.Text, qry_wasted);

                // return dt;
            }

            catch (Exception ep)
            {
                string exp = ep.ToString();
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Please Try Again.');", true);


            }

        }
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
    protected void dropdown_SearchOption_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ObjGenBal = new BaseLayer.General_function();
            if (dropdown_SearchOption.SelectedValue == "Nationality")
            {
                sp1.Visible = true;
                sp2.Visible = false;
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
            }

            if (dropdown_SearchOption.SelectedValue == "ProducedONDate")
            {
                sp1.Visible = true;
                sp2.Visible = false;
                string queryfornationality = "Select * from NationalityMaster where 1<>1 order by adjective";
                ObjGenBal.Fill_DDLReport(dpd_search, queryfornationality, "adjective", "adjective");
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

        string query = "select * from vw_Allin1_ReportNew ";
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




            condition = condition + " Where   producedon Between '" + ConvertDate(txtFromDate.Value, "d-MM-yyyy") + "' And '" + ConvertDate(txtToDate.Value, "d-MM-yyyy") + "'";
            // condition = condition + " Where   producedon Between '" + txtFromDate.Value + "' And '" + txtToDate.Value + "'";


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

    protected void menuTabs_MenuItemClick(object sender, System.Web.UI.WebControls.MenuEventArgs e)
    {
        multiTabs.ActiveViewIndex = Int32.Parse(menuTabs.SelectedValue);
        btn_generate_report_Click(sender, e);
    }

    protected void multiTabs_ActiveViewChanged(object sender, EventArgs e)
    {

    }

    //private void CallZoneCode()
    //{
    //    ObjGenBal = new BaseLayer.General_function();
    //    DataTable dtz = new DataTable();
    //    string query = "select ZoneCode From UserZoneRelation where userID ='" + UserID + "'";
    //    //  "SELECT * from ProdReportCerpacCard";
    //    dtz = ObjGenBal.FetchData(query);
    //    if (dtz.Rows.Count > 0)
    //    {
    //        ZoneCode = dtz.Rows[0].ItemArray[0].ToString();
    //    }

    //    dtz = null;

    //}

    public DataTable wrongformsUsed()
    {
        DataTable dt_wr = new DataTable();
       // string query_wr = "Select *  From vw_wrong_forms_used_report a, UserZoneRelation b  where  a.VerifiedBy=b.UserId and b.ZoneCode='" + dpd_zone.SelectedValue + "'";
        string query_wr = "Select *  From vw_wrong_forms_used_report where 1=1 ";
        string condition = "";
        if (txtFromDate.Value != "" && txtToDate.Value != "")
        {
            CallDate();
            if (condition != "")
                condition = condition + " And ";

            condition = condition + " and VerifiedOn >= '" + ConvertDate(txtFromDate.Value, "d-MM-yyyy") + "' And VerifiedOn <= '" + ConvertDate(txtToDate.Value, "d-MM-yyyy") + "' ";
            query_wr = query_wr + condition;
            // dt = ObjGeneral.FetchData(query);
            objDs_WrongForms = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.Text, query_wr);

        }
        return dt_wr;
    }

    private DataTable VerfiedData()
    {

        //ObjGeneral = new BaseLayer.General_function();
        DataTable dt = new DataTable();
        //Select a. UserName From UserMaster as a , UserStickerRelation as b where a.UserID=b.UserID And StickerWastedYN =1 ;

        //Select  b.LoginID, count(a.IsProduced) as ProdCount  From PeopleChild a, UserMaster b, UserZoneRelation c  where  b.UserID = a.ProducedBy and b.UserID=c.UserId and c.ZoneCode='512'  group by a.ProducedBy,  b.LoginID order by b.LoginID
        string query = "Select b.UserName as LoginID, count(a.IsVerified) as VerCount  From PeopleChild a, UserMaster b, UserZoneRelation c  where  b.UserID = a.VerifiedBy and b.UserID=c.UserId and IsVerified=1 and c.ZoneCode='" + dpd_zone.SelectedValue + "'";

        string condition = "";
        if (txtFromDate.Value != "" && txtToDate.Value != "")
        {
            CallDate();
            if (condition != "")
                condition = condition + " And ";

            condition = condition + " and a.Verifiedon between '" + ConvertDate(txtFromDate.Value, "d-MM-yyyy") + "' And '" + ConvertDate(txtToDate.Value, "d-MM-yyyy") + "' ";
            query = query + condition + " group by a.VerifiedBy,  b.UserName order by b.UserName";
            // dt = ObjGeneral.FetchData(query);
            objDs1 = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.Text, query);

        }
        return dt;
    }

    private DataTable ContecData()
    {

        // ObjGeneral = new BaseLayer.General_function();
        DataTable dt = new DataTable();
        //Select a. UserName From UserMaster as a , UserStickerRelation as b where a.UserID=b.UserID And StickerWastedYN =1 ;

        //Select  b.LoginID, count(a.IsProduced) as ProdCount  From PeopleChild a, UserMaster b, UserZoneRelation c  where  b.UserID = a.ProducedBy and b.UserID=c.UserId and c.ZoneCode='512'  group by a.ProducedBy,  b.LoginID order by b.LoginID
        string query = "Select b.UserName as LoginID, count(a.ISARCR) as ContecOfficer  From PeopleChild a, UserMaster b, UserZoneRelation c  where  b.UserID = a.ConfirmedBy and b.UserID=c.UserId and a.IsQual=1 and c.ZoneCode='" + dpd_zone.SelectedValue + "'";

        string condition = "";
        if (txtFromDate.Value != "" && txtToDate.Value != "")
        {
            CallDate();
            if (condition != "")
                condition = condition + " And ";

            condition = condition + " and a.ConfirmedOn between '" + ConvertDate(txtFromDate.Value, "d-MM-yyyy") + "' And '" + ConvertDate(txtToDate.Value, "d-MM-yyyy") + "' ";
            query = query + condition + " group by a.ConfirmedBy,  b.UserName order by b.UserName";
            // dt = ObjGeneral.FetchData(query);
            objDs5 = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.Text, query);

        }
        return dt;
    }

    private DataTable AuthData()
    {

        //ObjGeneral = new BaseLayer.General_function();
        DataTable dt = new DataTable();
        //Select a. UserName From UserMaster as a , UserStickerRelation as b where a.UserID=b.UserID And StickerWastedYN =1 ;

        //Select  b.LoginID, count(a.IsProduced) as ProdCount  From PeopleChild a, UserMaster b, UserZoneRelation c  where  b.UserID = a.ProducedBy and b.UserID=c.UserId and c.ZoneCode='512'  group by a.ProducedBy,  b.LoginID order by b.LoginID
        string query = "Select b.UserName as LoginID, count(a.isAuthorized) as AuthCount  From PeopleChild a, UserMaster b, UserZoneRelation c  where  b.UserID = a.AuthorizedBy and b.UserID=c.UserId and isAuthorized=1 and c.ZoneCode='" + dpd_zone.SelectedValue + "'";

        string condition = "";
        if (txtFromDate.Value != "" && txtToDate.Value != "")
        {
            CallDate();
            if (condition != "")
                condition = condition + " And ";

            condition = condition + " and a.AuthorizedOn between '" + ConvertDate(txtFromDate.Value, "d-MM-yyyy") + "' And '" + ConvertDate(txtToDate.Value, "d-MM-yyyy") + "' ";
            query = query + condition + " group by a.AuthorizedBy,  b.UserName order by b.UserName";
            // dt = ObjGeneral.FetchData(query);
            objDs2 = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.Text, query);

        }
        return dt;
    }

    private DataTable ProdData()
    {

        // ObjGeneral = new BaseLayer.General_function();
        DataTable dt = new DataTable();
        //Select a. UserName From UserMaster as a , UserStickerRelation as b where a.UserID=b.UserID And StickerWastedYN =1 ;

        //Select  b.LoginID, count(a.IsProduced) as ProdCount  From PeopleChild a, UserMaster b, UserZoneRelation c  where  b.UserID = a.ProducedBy and b.UserID=c.UserId and c.ZoneCode='512'  group by a.ProducedBy,  b.LoginID order by b.LoginID
        string query = "Select b.UserName as LoginID, count(a.IsProduced) as ProdCount  From PeopleChild a, UserMaster b, UserZoneRelation c  where  b.UserID = a.ProducedBy and b.UserID=c.UserId and IsProduced=1 and c.ZoneCode='" + dpd_zone.SelectedValue + "'";

        string condition = "";
        if (txtFromDate.Value != "" && txtToDate.Value != "")
        {
            CallDate();
            if (condition != "")
                condition = condition + " And ";

            condition = condition + " and a.ProducedOn between '" + ConvertDate(txtFromDate.Value, "d-MM-yyyy") + "' And '" + ConvertDate(txtToDate.Value, "d-MM-yyyy") + "' ";
            query = query + condition + " group by a.ProducedBy,  b.UserName order by b.UserName";
            // dt = ObjGeneral.FetchData(query);
            objDs3 = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.Text, query);

        }
        return dt;
    }

    private DataTable QualData()
    {

        // ObjGeneral = new BaseLayer.General_function();
        DataTable dt = new DataTable();
        //Select a. UserName From UserMaster as a , UserStickerRelation as b where a.UserID=b.UserID And StickerWastedYN =1 ;

        //Select  b.LoginID, count(a.IsProduced) as ProdCount  From PeopleChild a, UserMaster b, UserZoneRelation c  where  b.UserID = a.ProducedBy and b.UserID=c.UserId and c.ZoneCode='512'  group by a.ProducedBy,  b.LoginID order by b.LoginID
        string query = "Select b.UserName as LoginID, count(a.IsQual) as QualCount  From PeopleChild a, UserMaster b, UserZoneRelation c  where  b.UserID = a.QualBy and b.UserID=c.UserId and a.IsQual=1 and c.ZoneCode='" + dpd_zone.SelectedValue + "'";

        string condition = "";
        if (txtFromDate.Value != "" && txtToDate.Value != "")
        {
            CallDate();
            if (condition != "")
                condition = condition + " And ";

            condition = condition + " and a.QualOn between '" + ConvertDate(txtFromDate.Value, "d-MM-yyyy") + "' And '" + ConvertDate(txtToDate.Value, "d-MM-yyyy") + "' ";
            query = query + condition + " group by a.QualBy,  b.UserName order by b.UserName";
            // dt = ObjGeneral.FetchData(query);
            objDs4 = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.Text, query);

        }
        return dt;
    }
    protected void dpdYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
}