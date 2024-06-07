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

public partial class Bank_EditUploadedData : System.Web.UI.Page
{
    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    BaseLayer.General_function objgenenral = null;
    protected DataSet objDs = new DataSet();
    protected DataTable dt = new DataTable();

    protected BaseLayer.General_function ObjGenBal = null;
    string AppID = "";
    string UserID = null;
    string cond = "";
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            cond = Request.QueryString["cond"].ToString();

            objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
            if (objectSessionHolderPersistingData == null)
            {
                Response.Redirect("../Login.aspx");
            }

            string cer_no = Request.QueryString["CerpacNo"].ToString();

            int len = cer_no.Length;
            string substr = cer_no.Substring(0, 2);


            double Num;
            bool isNum = double.TryParse(cer_no.Remove(0, 2), out Num);
            if (!isNum)
            {
                lbl_issue.Text = "Last 8 digits should be numeric ";
            }

            if (len != 8)
            {
                lbl_issue.Text = "Form No. should be 8 digits";
            }
            if (len != 8 && substr != "AO" && substr != "AR" && substr != "CR")
            {
                lbl_issue.Text = "Form No. should be 8 digits & Start with AO, AR or CR";
            }
            if (substr != "AO" && substr != "AR" && substr != "CR")
            {
                lbl_issue.Text = "Form No. should be start with AO, AR or CR";
            }

            objgenenral = new BaseLayer.General_function();
            if (!IsPostBack)
            {
                string queryforposition = "";
                if (cond == "5")
                {
                    queryforposition = "select * from correct_bank_data where formno='" + cer_no + "'";
                }
                else
                {
                    queryforposition = "select * from temp_bank_data where cerpacno='" + cer_no + "'";
                    // string queryforposition = "SELECT * from vwDisplayVerifiedData";
                }
                DataTable dt1 = new DataTable();
                dt1 = objgenenral.FetchData(queryforposition);
                if (dt1.Rows.Count > 0)
                {
                    //-----------Read Details-------------
                    TxtSecuredSoldFormNoR.Text = dt1.Rows[0]["FormNo"].ToString();                    
                    TxtFirstNameR.Text = dt1.Rows[0]["FirstName"].ToString();
                    TxtLastNameR.Text = dt1.Rows[0]["LastName"].ToString();
                    TxtNationalityR.Text = dt1.Rows[0]["Nationality"].ToString();
                    TxtTelNoR.Text = dt1.Rows[0]["TellerNo"].ToString();
                    TxtCompanyR.Text = dt1.Rows[0]["Company"].ToString();
                    TxtAmountR.Text = dt1.Rows[0]["Amount"].ToString();

                    //-------------Update Details-----------------
                    TxtFirstName.Text = dt1.Rows[0]["FirstName"].ToString();
                    TxtLastName.Text = dt1.Rows[0]["LastName"].ToString();
                    TxtNationality.Text = dt1.Rows[0]["Nationality"].ToString();
                    TxtTellerNo.Text = dt1.Rows[0]["TellerNo"].ToString();
                    TxtSecuredSoldFormNo.Text = dt1.Rows[0]["FormNo"].ToString();
                    TxtCompany.Text = dt1.Rows[0]["Company"].ToString();
                    TxtAmount.Text = dt1.Rows[0]["Amount"].ToString();

                    //
                }
            }
        }
        catch (Exception ex)
        {
            Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            ObjGenBal = new BaseLayer.General_function();
            string err = ObjGenBal.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.CssClass = "warning-box";
        }
        finally
        {
            ObjGenBal = null;

        }
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {
        try
        {
            BusinessEntityLayer.BankRegDetails objDetails = new BusinessEntityLayer.BankRegDetails();
            int res = 0;

            objDetails.FirstName = TxtFirstName.Text;
            objDetails.LastName = TxtLastName.Text;
            objDetails.Company = TxtCompany.Text;
            objDetails.Nationality = TxtNationality.Text;
            objDetails.CerpacNo = Request.QueryString["CerpacNo"].ToString();
            objDetails.FormNo = TxtSecuredSoldFormNo.Text;
            objDetails.TellerNo = TxtTellerNo.Text;
            objDetails.Amount = Convert.ToDecimal(TxtAmount.Text);

            objDetails.CreatedBy = Convert.ToInt32(objectSessionHolderPersistingData.User_ID);

            if (cond == "5")
                objDetails.Condition = 10;
            else

                objDetails.Condition = 5;

            //res = objDetails.BankDetailsUpdateData();

            if (res == 1)
            {
                if (cond == "5")
                    Response.Redirect("BankAll.aspx?cond=5");
                else
                    Response.Redirect("BankAll.aspx?cond=2");
            }
        }
        catch (Exception ex)
        {
            Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            ObjGenBal = new BaseLayer.General_function();
            string err = ObjGenBal.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.CssClass = "warning-box";
        }
        finally
        {
            ObjGenBal = null;

        }
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {

        if (cond == "5")
        {
            Response.Redirect("VerifyUploadBankData.aspx?con=1");
        }
        else
        {
            Response.Redirect("VerifyUploadBankData.aspx");
        }
//        Response.Redirect("VerifyUploadBankData.aspx");
    }
   
}