using System;
using System.Collections;
using System.Configuration;
using System.Data;
//using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//using System.Xml.Linq;
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
using System.Threading;

public partial class Admin_CheckSheetReports : System.Web.UI.Page
{

    private int m_currentPageIndex;
    private IList<Stream> m_streams;

   
    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    BaseLayer.General_function objgenenral = null;
    BaseLayer.General_function ObjGeneral = null;
    protected BaseLayer.General_function ObjGenBal = null;
    string AppID = "";
    string FRNno = "";
    #endregion


    protected void Page_Load(object sender, EventArgs e)
    {

        if (string.IsNullOrEmpty(Request.QueryString["no"]) == false && Request.QueryString["no"] != "" && string.IsNullOrEmpty(Request.QueryString["fno"]) == false && Request.QueryString["fno"] != "")
        {
            AppID = Convert.ToString(Request.QueryString["no"]);
            FRNno = Convert.ToString(Request.QueryString["fno"]);
            //drpdwn = Convert.ToString(Request.QueryString["dpr"]);
           // ReportViewer1.Visible = true;


            tr1.Style.Add("display", "none");
            tr2.Style.Add("display", "none");
            //tr3.Style.Add("display", "");


           txtCerpacNo.Value = AppID;
           
        }
        else
        {
            tr1.Style.Add("display", "");
            tr2.Style.Add("display", "");
           //tr3.Style.Add("display", "none");


        }

        if (!IsPostBack)
        {
            //--------------------------------------Zone User Details  --------------------
            ObjGeneral = new BaseLayer.General_function();
            objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];

            if (objectSessionHolderPersistingData == null)
            {
                Response.Redirect("../Login.aspx");
            }
            Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            string queryforzonename = "select b.ZoneName, b.ZoneCode from UserZoneRelation as a, Zonemaster as b where a.ZoneCode=b.ZoneCode and a.UserId=" + objectSessionHolderPersistingData.User_ID + "";
            objgenenral = new BaseLayer.General_function();
            DataTable dtZone = new DataTable();
            try
            {
                dtZone = objgenenral.FetchData(queryforzonename);
                if (dtZone.Rows.Count > 0)
                {
                    LabelMessage.Text = "Zone" + " " + dtZone.Rows[0]["ZoneName"].ToString();
                    LabelMessage.Visible = true;
                    LabelMessage.BorderStyle = BorderStyle.None;
                    lblPlaceofIssue.Text = dtZone.Rows[0]["ZoneName"].ToString();
                    lblCode.Text = dtZone.Rows[0]["ZoneCode"].ToString();
                   
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                dtZone = null;
                objgenenral = null;
            }
            //--------------------


            if (txtCerpacNo.Value != "")
            {
                FillCheckSheet();
                 div_main.Visible = true;
                 PtDiv.Visible = false;
             }

      
            if (string.IsNullOrEmpty(Request.QueryString["no"]) == false && Request.QueryString["no"] != "" && string.IsNullOrEmpty(Request.QueryString["fno"]) == false && Request.QueryString["fno"] != "")
            {
                div_main.Visible = true;
                PtDiv.Visible = true;
               // DetailPage.visible = true;
            }
            else
            {
                div_main.Visible = false;
                PtDiv.Visible = false;
            }
          }

       
    }


    
    /* Print Report */
    
    protected void btn_generate_report_Click(object sender, EventArgs e)
    {

        if (txtCerpacNo.Value != "")
        {
            ObjGeneral = new BaseLayer.General_function();
        
            DataTable dtC = new DataTable();
            string query1 = "Select isnull(a.cerpac_file_no,'') From people a, peoplechild b where a.cerpac_file_no=b.FORMNO and a.cerpac_no ='" + txtCerpacNo.Value + "'";

            dtC = ObjGeneral.FetchData(query1);
            if (dtC.Rows.Count > 0)
            {
                string FormNo = dtC.Rows[0][0].ToString().Trim();
                if (FormNo != "")
                {
                    FillCheckSheet();
                    lblGetDate.Text = String.Format("{0:dd-MMM-yyyy}", DateTime.Today);
                }
            }
            else
            {
                div_main.Visible = false;
                Response.Write("<script>alert('Please enter cerpac no. only');</script>");
                return;
            }
            
        }
        else
        {
            div_main.Visible = false;
            Response.Write("<script>alert('Please enter cerpac no. only');</script>");
            return;
        }
    }
    public void FillCheckSheet()
    {
        ObjGeneral = new BaseLayer.General_function();
        DataTable dt = new DataTable();
        string query1 = "(SELECT isnull(b.Title,''), a.forename, a.middle_name, a.surname, a.residence_permit_no, a.residence_issue_loc, a.sex, a.cerpac_no,isnull (Convert(varchar(11),a.cerpac_receipt_date,106),' '), isnull(Convert(varchar(11),a.cerpac_expiry_date,106),' '), a.cerpac_file_no, a.file_no, a.deedmark_no, a.issue_no, a.passport_no, a.nationality, isnull ( Convert(varchar(11),a.passport_issue_date,106),' ') , isnull( Convert(varchar(11),a.passport_expiry_date,106),' '), a.passport_issue_loc, a.passport_issue_by, isnull(Convert(varchar(11),a.date_of_birth,106),' ') , a.place_of_birth, a.nigeria_add_1, a.nigeria_add_2, a.nigeria_tel_no, a.abroad_add_1, a.abroad_add_2, a.abroad_tel_no, ISNULL((CASE (SUBSTRING(a.cerpac_no, 1, 2)) WHEN 'AO' THEN c.company ELSE d.company END), a.verid_template_1) AS Company, a.company_add_1, a.company_add_2, a.designation, isnull( Convert(varchar(11),a.employment_date,106),' '), a.company_tel_no, a.company_fax_no, a.email, a.verid_template_1 from people as a Left Outer Join TitleMaster as b  ON  a.Title=b.TitleCode left join CompMaster c on a.company=c.regno LEFT OUTER JOIN CompMasterForARCR d ON a.company = d.Regno Where  a.Cerpac_No='" + txtCerpacNo.Value + "')";
       
        dt = ObjGeneral.FetchData(query1);
        if (dt.Rows.Count == 0)
        {
            dt.Rows.Clear();
            div_main.Visible = false;
            Response.Write("<script>alert('Secure sold form no. does not found');</script>");
            return;

        }
        else if  (dt.Rows.Count > 0)
        {
            div_main.Visible = true;
            //-----------Personal Details-------------
            lblTile.Text = dt.Rows[0][0].ToString().Trim();
            lblForeName.Text = dt.Rows[0][1].ToString().Trim();
            lblMiddleName.Text = dt.Rows[0][2].ToString().Trim();
            lblSurName.Text = dt.Rows[0][3].ToString().Trim();
            //lblResidencePermitNo.Text = dt.Rows[0][4].ToString().Trim();
            //lblPlaceofIssue.Text = dt.Rows[0][5].ToString().Trim();
           
            lblSex.Text = dt.Rows[0][6].ToString().Trim();

            if (lblSex.Text != "") { if (dt.Rows[0][6].ToString().Trim() == "F") lblSex.Text = "Female"; else if (dt.Rows[0][6].ToString().Trim() == "M") lblSex.Text = "Male"; }
           
            //----------Cerpac Details-----------------
            lblCerpacNo.Text = dt.Rows[0][7].ToString().Trim();
            lblDateofReceipt.Text =  dt.Rows[0][8].ToString().Trim();
            lblDateofExpiry.Text = dt.Rows[0][9].ToString().Trim();
            lblFileNo.Text = dt.Rows[0][10].ToString().Trim();
            lblFileN.Text = dt.Rows[0][11].ToString().Trim();
            //lblWatermarkNo.Text = dt.Rows[0][12].ToString().Trim();
            lblIssueNo.Text = dt.Rows[0][13].ToString().Trim();
            //-------------Condition for Issue no ------------------------
            if (lblCerpacNo.Text.Trim() != lblFileNo.Text.Trim())
            {
                FillIssue();
            }
            else if (lblCerpacNo.Text.Trim() == lblFileNo.Text.Trim())
            {
                lblFileNo.Text ="";
            }

            //----------Passport Details--------------
            lblPassportNo.Text = dt.Rows[0][14].ToString().Trim();
            lblNationality.Text = dt.Rows[0][15].ToString().Trim();
            lblDateofIssueP.Text = dt.Rows[0][16].ToString().Trim();
            lblDateofExpiryP.Text = dt.Rows[0][17].ToString().Trim();
            lblPlaceofIssueP.Text = dt.Rows[0][18].ToString().Trim();
            lblIssuedByP.Text = dt.Rows[0][19].ToString().Trim();
            lblDateofBirth.Text = dt.Rows[0][20].ToString().Trim();
            lblPlaceofBirth.Text = dt.Rows[0][21].ToString().Trim();

            //-------------Address Details------------------
            lblNigeriaAdd1.Text = dt.Rows[0][22].ToString().Trim();
            lblNigeriaAdd2.Text = dt.Rows[0][23].ToString().Trim();
            lblNigeriaTelNo.Text = dt.Rows[0][24].ToString().Trim();
            lblAbroadAdd1.Text = dt.Rows[0][25].ToString().Trim();
            lblAbroadAdd2.Text = dt.Rows[0][26].ToString().Trim();
            lblAbroadTelNo.Text = dt.Rows[0][27].ToString().Trim();

            ////------------Company Details------------- 

            lblCompanyName.Text = dt.Rows[0][28].ToString().Trim();

            ////-----------------------------------------

            lblCompanyAdd1.Text = dt.Rows[0][29].ToString().Trim();
            lblCompanyAdd2.Text = dt.Rows[0][30].ToString().Trim();
            lblDesgination.Text = dt.Rows[0][31].ToString().Trim();
            lblDateofemployement.Text = dt.Rows[0][32].ToString().Trim();
            lblTelNo.Text = dt.Rows[0][33].ToString().Trim();
            lblFaxNo.Text = dt.Rows[0][34].ToString().Trim();
            lblEmail.Text = dt.Rows[0][35].ToString().Trim();

            //----------------Details  -------------
            dt.Rows.Clear();
        }
    }

    public void FillIssue()
    {
          DataTable dti = new DataTable();
          string query1 = "(Select Count(*), cerpac_no From Issue where cerpac_no= '" + txtCerpacNo.Value + "' Group by cerpac_no)";
       
        dti = ObjGeneral.FetchData(query1);
        if (dti.Rows.Count > 0)
        {
            lblIssueNo.Text = dti.Rows[0][0].ToString().Trim();
        }
    }

    
}
