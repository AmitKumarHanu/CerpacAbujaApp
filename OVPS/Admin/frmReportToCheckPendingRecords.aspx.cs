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
using System.Drawing.Printing;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Drawing;
using System.Text;
using System.IO;
using System.Globalization;

public partial class Admin_frmReportToCheckPendingRecords : System.Web.UI.Page
{
    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    BaseLayer.General_function objgenenral = null;
    BaseLayer.General_function ObjGeneral = null;
    protected BaseLayer.General_function ObjGenBal = null;
    protected DataSet objDsAO = new DataSet();
    protected DataSet objDsAR = new DataSet();
    protected DataSet objDsCR = new DataSet();


    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        From.HRef = "javascript:NewCal('" + txtFromDate.ClientID + "','DDMMMYYYY','','',1,80)";
        To.HRef = "javascript:NewCal('" + txtToDate.ClientID + "','DDMMMYYYY','','',1,80)";
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        if (objectSessionHolderPersistingData == null)
        {
            Response.Redirect("../Login.aspx");
        }
        string queryforzonename = "select b.ZoneName,b.zonecode from UserZoneRelation as a, Zonemaster as b where a.ZoneCode=b.ZoneCode and a.UserId=" + objectSessionHolderPersistingData.User_ID + "";
        objgenenral = new BaseLayer.General_function();
        DataTable dt = new DataTable();
        dt = objgenenral.FetchData(queryforzonename);
        if (dt.Rows.Count > 0)
        {
            dpd_zone.SelectedValue = dt.Rows[0]["zonecode"].ToString();
            dpd_zone.Enabled = false;
        }
    }
    protected void btn_generate_Click(object sender, EventArgs e)
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
                CallDate();
                bind_reportAO();
                bind_reportAR();
                bind_reportCR();
                R1.Visible = true;
                //   R2.Visible = false;
                // DivPrint.Visible = true;
            }

            catch (Exception ep)
            {
                string exp = ep.ToString();
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Please Try Again.');", true);


            }

        }


       
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

    public void bind_reportAO()
    {
        ObjGeneral = new BaseLayer.General_function();
        DataTable dt = new DataTable();
       // string query = "select sum(case when isnull(IsAuthorized,0)=0 then 1 end) as Auth,  sum(case when isnull(IsProduced,0)=0 then 1 end) as Prod, sum(case when isnull(ISARCR,0)=0 then 1 end) as ISARCR, sum(case when isnull(IsQual,0)=0 then 1 end) as Qual	from people a, PeopleChild b where a.cerpac_no=b.CerpacNo ";

        string query = "select isnull(sum(case when (isnull(IsAuthorized,0)=0 and isnull(IsVerified,0)=1) then 1 end),0) as Auth," +
                        "isnull(sum(case when (isnull(IsProduced,0)=0 and isnull(IsAuthorized,0)=1) then 1 end),0) as Prod," +
                        "isnull(sum(case when (isnull(ISARCR,0)=0 and isnull(IsVerified,0)=1) then 1 end),0) as ISARCR," +
                        "isnull(sum(case when (isnull(IsQual,0)=0 and isnull(IsProduced,0)=1) then 1 end),0) as Qual from PeopleChild a, UserZoneRelation b, Zonemaster c, People d " +
                        "where a.VerifiedBy=b.UserId and b.ZoneCode=c.ZoneCode and a.CerpacNo=d.cerpac_no and verifiedon Between '" + ConvertDate(txtFromDate.Value, "d-MM-yyyy") + "' And '" + ConvertDate(txtToDate.Value, "d-MM-yyyy") + "'and a.FORMNO like 'AO%'";
        
        if(dpd_zone.SelectedValue!="ALL")
            query = "select isnull(sum(case when (isnull(IsAuthorized,0)=0 and isnull(IsVerified,0)=1) then 1 end),0) as Auth," +
                        "isnull(sum(case when (isnull(IsProduced,0)=0 and isnull(IsAuthorized,0)=1) then 1 end),0) as Prod," +
                        "isnull(sum(case when (isnull(ISARCR,0)=0 and isnull(IsVerified,0)=1) then 1 end),0) as ISARCR," +
                        "isnull(sum(case when (isnull(IsQual,0)=0 and isnull(IsProduced,0)=1) then 1 end),0) as Qual from PeopleChild a, UserZoneRelation b, Zonemaster c, People d " +
                        "where a.VerifiedBy=b.UserId and b.ZoneCode=c.ZoneCode and a.CerpacNo=d.cerpac_no and c.ZoneCode=" + dpd_zone.SelectedValue + " and verifiedon Between '" + ConvertDate(txtFromDate.Value, "d-MM-yyyy") + "' And '" + ConvertDate(txtToDate.Value, "d-MM-yyyy") + "'and a.FORMNO like 'AO%'";
        
        objDsAO = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.Text, query);

    }

    public void bind_reportAR()
    {
        ObjGeneral = new BaseLayer.General_function();
        DataTable dt = new DataTable();
        // string query = "select sum(case when isnull(IsAuthorized,0)=0 then 1 end) as Auth,  sum(case when isnull(IsProduced,0)=0 then 1 end) as Prod, sum(case when isnull(ISARCR,0)=0 then 1 end) as ISARCR, sum(case when isnull(IsQual,0)=0 then 1 end) as Qual	from people a, PeopleChild b where a.cerpac_no=b.CerpacNo ";

        string query = "select isnull(sum(case when (isnull(IsAuthorized,0)=0 and isnull(IsVerified,0)=1) then 1 end),0) as Auth," +
                        "isnull(sum(case when (isnull(IsProduced,0)=0 and isnull(IsAuthorized,0)=1) then 1 end),0) as Prod," +
                        "isnull(sum(case when (isnull(ISARCR,0)=0 and isnull(IsVerified,0)=1) then 1 end),0) as ISARCR," +
                        "isnull(sum(case when (isnull(IsQual,0)=0 and isnull(IsProduced,0)=1) then 1 end),0) as Qual from PeopleChild a, UserZoneRelation b, Zonemaster c, People d " +
                        "where a.VerifiedBy=b.UserId and b.ZoneCode=c.ZoneCode and a.CerpacNo=d.cerpac_no and verifiedon Between '" + ConvertDate(txtFromDate.Value, "d-MM-yyyy") + "' And '" + ConvertDate(txtToDate.Value, "d-MM-yyyy") + "' and a.FORMNO like 'AR%'";

        if (dpd_zone.SelectedValue != "ALL")
            query = "select isnull(sum(case when (isnull(IsAuthorized,0)=0 and isnull(IsVerified,0)=1) then 1 end),0) as Auth," +
                        "isnull(sum(case when (isnull(IsProduced,0)=0 and isnull(IsAuthorized,0)=1) then 1 end),0) as Prod," +
                        "isnull(sum(case when (isnull(ISARCR,0)=0 and isnull(IsVerified,0)=1) then 1 end),0) as ISARCR," +
                        "isnull(sum(case when (isnull(IsQual,0)=0 and isnull(IsProduced,0)=1) then 1 end),0) as Qual from PeopleChild a, UserZoneRelation b, Zonemaster c, People d " +
                        "where a.VerifiedBy=b.UserId and b.ZoneCode=c.ZoneCode and a.CerpacNo=d.cerpac_no and c.ZoneCode=" + dpd_zone.SelectedValue + " and verifiedon Between '" + ConvertDate(txtFromDate.Value, "d-MM-yyyy") + "' And '" + ConvertDate(txtToDate.Value, "d-MM-yyyy") + "' and a.FORMNO like 'AR%'";

        objDsAR = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.Text, query);

    }

    public void bind_reportCR()
    {
        ObjGeneral = new BaseLayer.General_function();
        DataTable dt = new DataTable();
        // string query = "select sum(case when isnull(IsAuthorized,0)=0 then 1 end) as Auth,  sum(case when isnull(IsProduced,0)=0 then 1 end) as Prod, sum(case when isnull(ISARCR,0)=0 then 1 end) as ISARCR, sum(case when isnull(IsQual,0)=0 then 1 end) as Qual	from people a, PeopleChild b where a.cerpac_no=b.CerpacNo ";

        string query = "select isnull(sum(case when (isnull(IsAuthorized,0)=0 and isnull(IsVerified,0)=1) then 1 end),0) as Auth," +
                        "isnull(sum(case when (isnull(IsProduced,0)=0 and isnull(IsAuthorized,0)=1) then 1 end),0) as Prod," +
                        "isnull(sum(case when (isnull(ISARCR,0)=0 and isnull(IsVerified,0)=1) then 1 end),0) as ISARCR," +
                        "isnull(sum(case when (isnull(IsQual,0)=0 and isnull(IsProduced,0)=1) then 1 end),0) as Qual from PeopleChild a, UserZoneRelation b, Zonemaster c, People d " +
                        "where a.VerifiedBy=b.UserId and b.ZoneCode=c.ZoneCode and a.CerpacNo=d.cerpac_no and verifiedon Between '" + ConvertDate(txtFromDate.Value, "d-MM-yyyy") + "' And '" + ConvertDate(txtToDate.Value, "d-MM-yyyy") + "' and a.FORMNO like 'CR%'";

        if (dpd_zone.SelectedValue != "ALL")
            query = "select isnull(sum(case when (isnull(IsAuthorized,0)=0 and isnull(IsVerified,0)=1) then 1 end),0) as Auth," +
                        "isnull(sum(case when (isnull(IsProduced,0)=0 and isnull(IsAuthorized,0)=1) then 1 end),0) as Prod," +
                        "isnull(sum(case when (isnull(ISARCR,0)=0 and isnull(IsVerified,0)=1) then 1 end),0) as ISARCR," +
                        "isnull(sum(case when (isnull(IsQual,0)=0 and isnull(IsProduced,0)=1) then 1 end),0) as Qual from PeopleChild a, UserZoneRelation b, Zonemaster c, People d " +
                        "where a.VerifiedBy=b.UserId and b.ZoneCode=c.ZoneCode and a.CerpacNo=d.cerpac_no and c.ZoneCode=" + dpd_zone.SelectedValue + " and verifiedon Between '" + ConvertDate(txtFromDate.Value, "d-MM-yyyy") + "' And '" + ConvertDate(txtToDate.Value, "d-MM-yyyy") + "' and a.FORMNO like 'CR%'";

        objDsCR = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.Text, query);

    }

}