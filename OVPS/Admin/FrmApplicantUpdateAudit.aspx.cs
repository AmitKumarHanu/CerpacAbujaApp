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
using System.Drawing.Imaging;

using System.Drawing;
using System.Text;
using System.IO;
using System.Globalization;
using Excel = Microsoft.Office.Interop.Excel;



public partial class Admin_FrmApplicantUpdateAduit : System.Web.UI.Page
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
       

        if (!IsPostBack)
        {
           
            trCerpacNoViews.Visible = false;
            trToDate.Visible = false;
            trFromDate.Visible = false;
            R1.Visible = true;
            R2.Visible = false;
            DivPrint.Visible = false;

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

    public void Clr()
    {
        txtCerpacNo.Value = "";
        txtFromDate.Value = "";
        txtToDate.Value = "";
    }

   
    protected void btn_generate_report_Click(object sender, EventArgs e)
    {

        if (rdOpt.SelectedIndex == 0 && txtCerpacNo.Value == "") 
        {

            Response.Write("<script language=javascript>alert('Please Fill Cerpac No.')</script>");
            return;

        }   
    
         if (rdOpt.SelectedIndex == 1 && txtFromDate.Value == "" && txtToDate.Value == "")
        {

            Response.Write("<script language=javascript>alert('Please Fill From- Date & To-Date')</script>");
            return;

        }  

        if ( ( txtCerpacNo.Value !="" )|| (txtFromDate.Value != "" && txtToDate.Value != "") )
        {
            
            SearchType();
          
        }
       
    }
   

    private DataTable SearchType()
    {

        objgenenral = new BaseLayer.General_function();
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        DataTable dt = new DataTable();


        string Query = "  select cerpac_no,cerpac_file_no,cerpac_receipt_date,cerpac_expiry_date,nigeria_add_1,nigeria_add_2,nigeria_tel_no,abroad_add_1,abroad_add_2,abroad_tel_no,company,company_add_1,company_add_2,designation,CerpacNo,cerpac_issue_date,cerpac_exp_date,CompName,CompAdd1,CompAdd2,Designat,addnigeria1,addnigeria2,addabroad1,addabroad2,UserName, CONVERT(Varchar(10),Updatedon,105) as Updatedon, duplicateRecCount from ( SELECT cerpac_no,cerpac_file_no,cerpac_receipt_date,cerpac_expiry_date,nigeria_add_1,nigeria_add_2,nigeria_tel_no,abroad_add_1,abroad_add_2,abroad_tel_no,company,company_add_1,company_add_2,designation,CerpacNo,cerpac_issue_date,cerpac_exp_date,CompName,CompAdd1,CompAdd2,Designat,addnigeria1,addnigeria2,addabroad1,addabroad2,UserName, ROW_NUMBER() OVER(PARTITION by cerpac_no ORDER BY Updatedon Desc ) AS duplicateRecCount, Updatedon  FROM ApplicantUpdateAudit) a where duplicateRecCount =1 ";
        string condition = "";

        if (  rdOpt.SelectedIndex ==0 && txtCerpacNo.Value != "" )
        {
            if (condition == "")
                condition = condition + " And cerpac_no ='"+ txtCerpacNo.Value.Trim() +"'";

        }

        if (rdOpt.SelectedIndex ==1 && txtFromDate.Value != "" && txtToDate.Value != "")
        {
            //CallDate();
            if (condition == "")
                 condition = condition + " And  UpdatedOn between '" + ConvertDate(txtFromDate.Value.Trim(), "d-MM-yyyy") + "' And DateAdd(dd,1,'" + ConvertDate(txtToDate.Value.Trim(), "d-MM-yyyy") + "') ";

          
        }

       
        Query = Query + condition.TrimEnd(',');
        
        dt = objgenenral.FetchData(Query);
        objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.Text, Query);

        if (dt.Rows.Count > 0)
        {
            lblFDate.Text = txtFromDate.Value;
            lblTDate.Text = txtToDate.Value;
            R1.Visible = false;
            R2.Visible = true;
            DivPrint.Visible = true;
        }
        else
        {
            Response.Write("<script language=javascript>alert('Data not Found.')</script>");
            return dt;

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

       
   
    protected void rdOpt_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdOpt.SelectedIndex == 0)
        {
            trCerpacNoViews.Visible = true;
            trToDate.Visible = false;
            trFromDate.Visible = false;
            Clr();
            Opt1.Visible = true;
            Opt2a.Visible = false;
            Opt2b.Visible = false;
        }
        if (rdOpt.SelectedIndex == 1)
        {
            trCerpacNoViews.Visible = false;
            trToDate.Visible = true;
            trFromDate.Visible = true;
            Clr();
            Opt1.Visible = false;
            Opt2a.Visible = true;
            Opt2b.Visible = true;
            
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/FrmapplicantUpdateAudit.aspx");
    }

    protected void btnExcel_Click(object sender, ImageClickEventArgs e)
    {
        string html = HdnValue.Value;
        ExportToExcel(ref html, "CerpacNoAduit");
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
