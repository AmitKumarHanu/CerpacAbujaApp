using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Data;
using DataAccessLayer;

public partial class Admin_WasteCardReport : System.Web.UI.Page
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

        string dateString = txtFromDate.Value;
        string format = "d-mm-yyyy";
        DateTime dateTime = DateTime.ParseExact(dateString, format, CultureInfo.InvariantCulture);
        string strFromDate = dateTime.ToString("yyyy-mm-dd");

        string dateString1 = txtToDate.Value;
        string format1 = "d-mm-yyyy";
        DateTime dateTime1 = DateTime.ParseExact(dateString1, format1, CultureInfo.InvariantCulture);
        string strToDate = dateTime1.ToString("yyyy-mm-dd");


        // string query = "select sum(case when isnull(IsAuthorized,0)=0 then 1 end) as Auth,  sum(case when isnull(IsProduced,0)=0 then 1 end) as Prod, sum(case when isnull(ISARCR,0)=0 then 1 end) as ISARCR, sum(case when isnull(IsQual,0)=0 then 1 end) as Qual	from people a, PeopleChild b where a.cerpac_no=b.CerpacNo ";
      //  string query = "Select a.StickerNumber,  a.StickerWastedReason, a.StickerWastedYN, b.FORMNO, b.CerpacNo, Convert(varchar(10),b.ProducedOn,103) as Date , d.LoginID from UserStickerRelation a , PeopleChild b, UserZoneRelation c,  UserMaster d where a.StickerIssuedToApplicationID= b.FORMNO and a.StickerWastedYN=1 and b.IsProduced=1 and b.ProducedBy= c.UserId and c.ZoneCode=512  and b.ProducedBy=d.UserID and (b.ProducedOn >= '" + strFromDate + " 00:00:00.000'  and b.ProducedOn <= '" + strToDate + " 23:59:59.000')  group by  b.ProducedOn, a.StickerNumber, a.StickerIssuedToApplicationID, a.StickerWastedReason, a.StickerWastedYN, b.FORMNO, b.CerpacNo ,b.ProducedBy,  d.LoginID  order by b.ProducedOn";

        string query = "Select upper(a.card_no) as card_no , upper(a.lam_issued_cerpac_no) as lam_issued_cerpac_no, upper(a.lam_No) as Front, upper(b.lam_No) as Back from (select distinct(card_no),lam_issued_cerpac_no, lam_No  from tbl_lamination_detail where lam_printedYN='1' and lam_wastedYN='1' and lam_No like 'F%' and created_on between '" + strFromDate + " 00:00:00.000' and '" + strToDate + " 23:59:59.000') a, (select distinct(card_no),lam_issued_cerpac_no, lam_No  from tbl_lamination_detail where lam_printedYN='1' and lam_wastedYN='1' and lam_No like 'b%' and created_on  between '" + strFromDate + " 00:00:00.000' and '" + strToDate + " 23:59:59.000') b Where a.card_no=b.card_no and a.lam_issued_cerpac_no=b.lam_issued_cerpac_no and a.card_no!='0' and b.card_no !='0' ";

        objDsAO = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.Text, query);

    }

    protected void btn_excel_Click(object sender, ImageClickEventArgs e)
    {

        string html = HdnValue.Value;
        ExportToExcel(ref html, "WastedCardReport");
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

    
}