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
using System.IO;
using System.Drawing;

public partial class FrmGuestLogin : System.Web.UI.Page
{
    BaseLayer.General_function ObjGeneral = null;

    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];

        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.Now.AddDays(-1));
        Response.Cache.SetNoStore();
        if (Request.Cookies.Count > 0)
        {
            //HttpCookie cookie = Request.Cookies["ASPXAUTH"];
            //cookie.Expires = DateTime.Now.AddYears(-10);
            //Response.AppendCookie(cookie)       }


            Submit.Attributes.Add("onclick", "if(!pwd('Submit')) return false;");
            if (!IsPostBack)
            {

            }



        }
    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        //BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
        //objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];

        ObjGeneral = new BaseLayer.General_function();

        BusinessEntityLayer.BalGuestLogin ObjBalGuestLogin = null;

        int StatusID = 0;
        try
        {
            ObjBalGuestLogin = new BusinessEntityLayer.BalGuestLogin();

            Int32 CompanyID1 = (Int32)ENUMAUDITTYPE.CompanyId.GetHashCode();
            ObjBalGuestLogin.CompanyID = CompanyID1;
            Int32 grpid1 =(Int32)ENUMAUDITTYPE.GroupId.GetHashCode();
            ObjBalGuestLogin.grpid = grpid1;
            ObjBalGuestLogin.Loginid = txtLoginId.Text.Trim().ToString();
            ObjBalGuestLogin.Password = txtPassword.Text.Trim().ToString();
            ObjBalGuestLogin.EmailId = txtEmailId.Text.Trim().ToString();
            ObjBalGuestLogin.UserIPAddress = Request.UserHostAddress.ToString();
           
            //ObjBalAppReg.ApplicantID=  ;
            //ObjBalAppReg.VerifiedYN= ;
            //ObjBalAppReg.Status= ;
            int random = RandomNumber();
            ObjBalGuestLogin.UniqueCode = random.ToString();
            //ObjBalAppReg.ActiveYN= ;
            //ObjBalAppReg.CreatedBy=objectSessionHolderPersistingData.User_ID.ToString();
            //ObjBalAppReg.ModifiedBy=objectSessionHolderPersistingData.User_ID.ToString();


            StatusID = ObjBalGuestLogin.InsertGuestRegister();

            if (StatusID == 1)
            {

                string sthtml = "";
            //http://localhost:52759/OVPS/FrmVerify.aspx
                //Added by Ankit : call the Url from Web.config
                string str = System.Configuration.ConfigurationManager.AppSettings["link"].ToString();

                sthtml = sthtml + "<table border='0'>";
                sthtml = sthtml + "<tr><td>Dear Applicant,</td><tr>";
                sthtml = sthtml + "<tr><td> </td><tr>";
                sthtml = sthtml + "<tr><td> </td><tr>";
                sthtml = sthtml + "<tr><td>Thank you for using our online Visa Application facility. you have been registered successfully and the Login details are indicated below </td><tr>";
                sthtml = sthtml + "<tr><td>Your LoginID =" + txtLoginId.Text  + "</td><tr>";
                sthtml = sthtml + "<tr><td>Password =" + txtPassword.Text + "</td><tr>";
                sthtml = sthtml + "<tr><td>Unique Code =" + random + "</td><tr>";
                sthtml = sthtml + "<tr><td>Please Click On the given Link to verify your loginID </td><tr>";
                sthtml = sthtml + "<tr><td><h4><a href=" + str + ">Click me to Verify Your login </a> </h4> </td><tr>";
                sthtml = sthtml + "<tr><td> </td><tr>";
                sthtml = sthtml + "<tr><td> </td><tr>";
                sthtml = sthtml + "<tr><td>Thank you<br> OVPS Team</td><tr>";

                sthtml = sthtml + "</table>";
                
                ObjBalGuestLogin.EmailId = txtEmailId.Text.Trim().ToString();
                ObjBalGuestLogin.Subject = "OVPS:: Your Login Detail";
                ObjBalGuestLogin.Message = sthtml;//"Dear Applicant,\r\n\r\n  Your LoginID =" + txtLoginId.Text + "\r\n Your Password =" + txtPassword.Text + "\r\n\r\n Your Unique Code = " + random + "\r\n Please Click On the given Link to verify your loginID \r\n\r\n Thank you";
                //ObjBalGuestLogin.Message = "Dear Applicant,\r\n\r\n  Your LoginID =" + txtLoginId.Text + "\r\n Your Password =" + txtPassword.Text + "\r\n\r\n Your Unique Code = " + random + "\r\n Please Click On the given Link to verify your loginID \r\n\r\n Thank you";

                int Status = ObjBalGuestLogin.EmailHandler();
                if (Status == 1)
                {
                    Response.Write("<script>alert('Your Login detail has been forwarded to Your  Email ID !!')</script>");
                    Response.Redirect("FrmVerifierLinkNMessage.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Applicant has been registered successfully.But due to internet connectivity failed to deliver!!')</script>");
                }
               
            }
            if (StatusID == 2)
            {
                lblmessage.Text = "Login ID is not Available,Please change the login ID";             

            }

            if (StatusID == 3)
            {
                Response.Write("<script>alert('EmailID has been already Registered')</script>");
            }

            else
            {
                Response.Write("<script>alert('Guest can not be Registered')</script>");
               
            }
            // Response.Redirect("FrmVerifierLinkNMessage.aspx");
        }
        catch (Exception Ex)
        {
            if (Ex.Message.IndexOf("Failure")>-1)
            {
                Response.Write("<script>alert('Applicant has been registered successfully.But due to internet connectivity failed to deliver!!')</script>");
            }
            else
            {
                Response.Write("<script>alert('Guest can not be Registered')</script>");
            }
        }

        
    }
    public int RandomNumber()
    {

        Random random = new Random();

        return random.Next(10, 9999999);

    }

    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("FrmHomePage.aspx");
    }


}



