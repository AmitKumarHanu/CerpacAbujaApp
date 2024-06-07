using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using Microsoft.Win32;

public partial class FrmVerify : System.Web.UI.Page
{
    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    //string WindowUID = "";
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    #endregion

    BaseLayer.General_function objgen = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        ////////////////////////////////////////////////////////
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.Now.AddDays(-1));
        Response.Cache.SetNoStore();
        if (Request.Cookies.Count > 0)
        {
            //HttpCookie cookie = Request.Cookies["ASPXAUTH"];
            //cookie.Expires = DateTime.Now.AddYears(-10);
            //Response.AppendCookie(cookie);
        }
        ///////////////////////////////////////////////////////
        
        objgen = new BaseLayer.General_function();
        if (!IsPostBack)
        {
           // verifiertologin.Visible = false;
        }
    }
      

    private bool AuthenticateMe()
    {
        string userName = txtLoginId.Text;
        string password = txtPassword.Text;
        string uniqueid = TxtUniqueCode.Text;
        bool rememberUserName = true;
        DataTable dtable = null;
        BusinessEntityLayer.AccountUserData ObjUserAccount = null;

        try
        {
            ObjUserAccount = new BusinessEntityLayer.AccountUserData();
            dtable = ObjUserAccount.Fetch_UserDetail_by_UserName(userName, password, uniqueid);

            // record validated
            if (dtable.Rows.Count > 0)
            {
                if (dtable.Rows[0]["LoginID"].ToString() != userName)
                {
                    lblmessage.Text = "Wrong LoginID";
                    //Response.Write("<script>alert('Wrong LoginID')</script>");
                    txtLoginId.Focus();                   
                    return false;
                }
                else if (dtable.Rows[0]["Password"].ToString() != password)
                {
                    lblmessage.Text = "Wrong Password";
                    //Response.Write("<script>alert('Wrong Password')</script>");
                    txtPassword.Focus();
                    return false;
                }
                else if (dtable.Rows[0]["UniqueCode"].ToString() != uniqueid)
                {
                    lblmessage.Text = "Wrong Password";
                    //Response.Write("<script>alert('Wrong Unique Code')</script>");
                    TxtUniqueCode.Focus();
                    return false;
                }
                else if (dtable.Rows[0]["VerifiedYN"].ToString() == "1")
                {
                    lblmessage.Text = "You are already Verified!please login through main login page";
                    //Response.Write("<script>alert('You are already verifyed!please login through main login page')</script>");
                    txtLoginId.Text = string.Empty;
                    txtPassword.Text = string.Empty;
                    TxtUniqueCode.Text = string.Empty;
                    //verifiertologin.Visible = true;
                    //Response.Redirect("Login.aspx");
                    return false;
                }
                else
                {
                    int StatusID = 0;

                    BusinessEntityLayer.AccountUserData Objverifiedupdate = null;

                    Objverifiedupdate = new BusinessEntityLayer.AccountUserData();
                    Objverifiedupdate.UserLoginid = txtLoginId.Text.ToString();
                    Objverifiedupdate.NPassword = txtPassword.Text.ToString();
                    Objverifiedupdate.UniqueCode = TxtUniqueCode.Text.ToString();
                    StatusID = Objverifiedupdate.UpdateVerified();
                    if (StatusID == 1)
                    {
                        lblmessage.Text = "Login ID Verified Successfully";
                        //Response.Write("<script>alert('LoginId Verified Successfully')</script>");
                    }


                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, // Ticket version
                            userName,// Username to be associated with this ticket
                            DateTime.Now, // Date/time ticket was issued
                            DateTime.Now.AddMinutes(50), // Date and time the cookie will expire
                            rememberUserName, // if user has chcked rememebr me then create persistent cookie
                             "ROLE", // store the user data, in this case roles of the user

                            FormsAuthentication.FormsCookiePath); // Cookie path specified in the web.config file in <Forms> tag if any.
                    // To give more security it is suggested to hash it

                    string hashCookies = FormsAuthentication.Encrypt(ticket);

                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hashCookies); // Hashed ticket

                    // Add the cookie to the response, user browser
                    Response.Cookies.Add(cookie);

                    // Get the requested page from the url
                    string returnUrl = Request.QueryString["ReturnUrl"];

                    // check if it exists, if not then redirect to default page
                    if (returnUrl == null)
                    { returnUrl = "~/User/Default.aspx"; }

                    // Response.Redirect(returnUrl);

                    //objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
                    objectSessionHolderPersistingData = new BaseLayer.SessionHolderPersistingData();
                    objectSessionHolderPersistingData.User_Name = dtable.Rows[0]["UserName"].ToString();
                    objectSessionHolderPersistingData.User_ID = dtable.Rows[0]["UserId"].ToString();
                    objectSessionHolderPersistingData.User_Type = dtable.Rows[0]["UserType"].ToString();
                    objectSessionHolderPersistingData.CompanyId = dtable.Rows[0]["CompanyId"].ToString();
                    objectSessionHolderPersistingData.CompanyName = dtable.Rows[0]["CompanyName"].ToString();
                    objectSessionHolderPersistingData.Grp_ID = dtable.Rows[0]["GrpId"].ToString();
                    Session["SessionHolderPersistingData"] = objectSessionHolderPersistingData;
                    return true;
                }             
        }
     else // wrong username and password
     {

         lblmessage.Text = "Wrong LoginId,Password or Unique Code";
         //Response.Write("<script>alert('Wrong LoginId,Password or Unique Code')</script>");
         //txtLoginId.Focus();
         //txtPassword.Text = string.Empty;
         //TxtUniqueCode.Text = string.Empty;
         return false;
      }
 }
        catch (Exception ex)
        {
            throw ex;
            return false;
        }
 }

    protected void UserLogin_Authenticate()
    {
        //  string CurrentWindowUser = System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToString();
        bool authenticated = AuthenticateMe();
        if (authenticated)
        {
            //---------Insert Into Audit---------
            BaseLayer.General_function ObjGenBal = new BaseLayer.General_function();
            ObjGenBal.audittype = ENUMAUDITTYPE.Login.GetHashCode().ToString();
            ObjGenBal.userid = objectSessionHolderPersistingData.User_ID;
            ObjGenBal.auditdetail = "User Login";
            ObjGenBal.machineIP = Request.UserHostAddress.ToString();
            ObjGenBal.AuditInsert();
            //-----------END---------------------
            if (objectSessionHolderPersistingData.CompanyId == "0")
            {
                Response.Redirect("CompanyPage/default.aspx");
            }
            FormsAuthentication.RedirectFromLoginPage(txtLoginId.Text, true);
        }
    }

    protected void VerifyButton_Click(object sender, EventArgs e)
    {
        UserLogin_Authenticate();

    }
}
