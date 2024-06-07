using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_FrmWrongformsused : System.Web.UI.Page
{
    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    BaseLayer.General_function objgenenral = null;
    BaseLayer.General_function ObjGeneral = null;
    protected BaseLayer.General_function ObjGenBal = null;
    protected DataSet objDs = new DataSet();
    Label LabelMessage = null;

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        if (objectSessionHolderPersistingData == null)
        {
            Response.Redirect("../Login.aspx");
        }
        LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
        From.HRef = "javascript:NewCal('" + txtFromDate.ClientID + "','DDMMMYYYY','','',5,1)";
        To.HRef = "javascript:NewCal('" + txtToDate.ClientID + "','DDMMMYYYY','','',5,1)";


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

        //LocalReport report = new LocalReport();
        //report.ReportPath = @"Admin/Reports/ProductionRep.rdlc";
        //report.DataSources.Add(new ReportDataSource("DataSet1", LoadData()));
        if (!IsPostBack)
        {
            CompareValidator1.ValueToCompare = DateTime.Now.ToShortDateString();
            CompareValidator3.ValueToCompare = DateTime.Now.ToShortDateString();
            btn_generate_report0.Attributes.Add("onclick", "if(!pwd('Submit')) return false;");
            R1.Visible = false;
            R2.Visible = true;
            DivPrint.Visible = false;

        }
    }
    protected void btn_generate_report_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtFromDate.Value == "" || txtToDate.Value == "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Please Fill From- Date & To-Date.');", true);
                // Response.Write("<script language=javascript>alert('Please Fill From- Date & To-Date')</script>");
                return;

            }

            else
            {
                LoadData();
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
    }

    private DataTable LoadData()
    {
        ObjGeneral = new BaseLayer.General_function();
        DataTable dt = new DataTable();

        //string query = "select a.FORMNO,a.FirstName,a.LastName,a.NATIONALITY,b.forename,b.surname,b.nationality as nationality_p, a.company, d.company as company_p  from Uploaded_Excel_Data a, People b, peoplechild c, CompMaster d where a.FORMNO=c.formno and b.cerpac_no=c.CerpacNo and b.company=d.regno  and   (len(replace(RTRIM(LTRIM(UPPER(a.FirstName+' '+a.LastName))), b.forename,''))= len(RTRIM(LTRIM(UPPER(a.FirstName+' '+a.LastName))))  or len(replace(RTRIM(LTRIM(UPPER(a.FirstName+' '+a.LastName))), b.surname,''))= len(RTRIM(LTRIM(UPPER(a.FirstName+' '+a.LastName))))) and substring(a.FirstName+a.LastName,0,8)<>substring(b.forename+b.surname,0,8)";

        string query = "select * from vw_wrong_forms_used_report where ConfirmedOn Between '" + ConvertDate(txtFromDate.Value, "d-MM-yyyy") + "' And '" + ConvertDate(txtToDate.Value, "d-MM-yyyy") + "'";
        dt = ObjGeneral.FetchData(query);
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

    protected void btnBack_Click(object sender, EventArgs e)
    {
        R1.Visible = false;
        R2.Visible = true;
        DivPrint.Visible = false;
        Response.Redirect("FrmexceptionReport.aspx");

    }

    protected void btn_excel_Click(object sender, ImageClickEventArgs e)
    {

        string html = HdnValue.Value;
        ExportToExcel(ref html, "ExceptionReport");
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