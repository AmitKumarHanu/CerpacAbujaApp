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

public partial class Admin_FrmVisaIssuePage : System.Web.UI.Page
{
    //#region "Declarations"
    ////Session Holder  for Persisting Data Class Object intialization
    //BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    //BaseLayer.General_function ObjGeneral = null;
    //#endregion

    //protected void Page_PreInit(object sender, EventArgs e)
    //{
    //    objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
    //    string companyid = objectSessionHolderPersistingData.CompanyId;
    //    if (companyid == "0")

    //        this.Page.MasterPageFile = "~/MasterPage/MasterPageCompany.master";
    //    else
    //        this.Page.MasterPageFile = "~/MasterPage/MasterPageUser.master";
    //}

    //protected void Page_Load(object sender, EventArgs e)
    //{
    //    /// Session["form"] = "FrmVisaIssuePage";

    //    //Popup open code


    //    // String url = Page.Request.UrlReferrer.ToString();
    //    if (!IsPostBack)
    //    {

    //    }

    //    GetApplicantDetail();


    //    BtnIssuePaperVisa.Attributes.Add("onClick", "javascript:Print();");

    //}


    //protected void BtnIssuePaperVisa_Click(object sender, EventArgs e)
    //{
    //    //Session["visa"] = "paper";

    //     //BtnIssuePaperVisa.Attributes.Add("onClick", "javascript:Print();");
    //}

    //protected void GetApplicantDetail()
    //{

    //    string Applicant = string.Empty;
    //    Applicant = Request.QueryString["ApplicationId"].ToString().Trim();
    //    ObjGeneral = new BaseLayer.General_function();
    //    DataTable dt = null;
    //    dt = new DataTable();
    //    string Getdetailquery = "Select ApplicationId,PassportNumber,Nationality,FirstName,MiddleName,LastName,DateOfBirth,EntryType,DurationType,Duration,Rate,RateCurrency,Sex,MaritalStatus,FatherName,PassportType,EmailID,vm.VisaTypeName from VisaApplicationInfo as v join VisaTypeMaster vm on v.VisaTypeCode=vm.VisaTypeCode   where ApplicationId='" + Applicant + " '";
    //    dt = ObjGeneral.FetchData(Getdetailquery);
    //    if (dt.Rows.Count > 0)
    //    {
    //        LblPassportNo.Text = dt.Rows[0]["PassportNumber"].ToString().Trim();
    //        LblNationality.Text = dt.Rows[0]["Nationality"].ToString().Trim();
    //        LblEmail.Text = dt.Rows[0]["EmailID"].ToString().Trim();
    //        lblName.Text = dt.Rows[0]["FirstName"].ToString().Trim() + " " + dt.Rows[0]["MiddleName"].ToString().Trim() + " " + dt.Rows[0]["LastName"].ToString().Trim();
    //        LblDoB.Text = string.Format("{0:dd-MMM-yyyy}", dt.Rows[0]["DateOfBirth"]).ToString();
    //        LblPassportType.Text = dt.Rows[0]["PassportType"].ToString().Trim();
    //        LblSex.Text = dt.Rows[0]["Sex"].ToString().Trim();
    //        LblAppId.Text = dt.Rows[0]["ApplicationId"].ToString().Trim();
    //        LblVisaType.Text = dt.Rows[0]["VisaTypeName"].ToString().Trim();
    //        LblDuration.Text = dt.Rows[0]["Duration"].ToString().Trim();
    //        LblDurationType.Text = dt.Rows[0]["DurationType"].ToString().Trim();
    //        //LblAmount.Text = dt.Rows[0]["Rate"].ToString().Trim();
    //       // LblCurrency.Text = dt.Rows[0]["RateCurrency"].ToString().Trim();
    //        LblEntryType.Text = dt.Rows[0]["EntryType"].ToString().Trim();
    //        FatherName.Text = dt.Rows[0]["FatherName"].ToString().Trim();
    //    }

    //}

    //protected void BtnBack_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("FrmVisaIssueList.aspx");
    //}
}
