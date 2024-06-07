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
using Microsoft.Win32;
using AjaxControlToolkit.HTMLEditor.ToolbarButton;


public partial class Login : System.Web.UI.Page
{

    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    //string WindowUID = "";
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    BaseLayer.General_function ObjGeneral = null;
    validity.validitychecking valid = null;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        lblmessage.Text = "";
       // liscencecheck();

    }

    protected void liscencecheck()
    {
        ObjGeneral = new BaseLayer.General_function();
        valid = new validity.validitychecking();
        string query = "Select * from Licensing";
        DataTable dtlic = new DataTable();
        dtlic = ObjGeneral.FetchData(query);
        try
        {
            if (dtlic.Rows.Count > 0)
            {
                int status = validitycheck(dtlic.Rows[0]["LKey"].ToString());
                if (status == -1)
                {
                    double day = daysleft(dtlic.Rows[0]["LKey"].ToString());
                    if (day < 5)
                    {
                        lblmessage.Text = "Your Liscence will expire in "+ day.ToString() + " day(s). Please renew your liscence.";
                        lblmessage.Visible = true;
                        lblmessage.CssClass = "information-box";
                        lblmessage.Font.Size = FontUnit.Small;
                        lblmessage.Style.Add("text-decoration", "blink");
                    }
                }
                else
                {
                    UserName.Enabled = false;
                    Password.Enabled = false;
                    BtnLogin.Enabled = false;
                    lblmessage.Text = "Your licence has expired.Please renew your liscence.";
                    lblmessage.Font.Size = FontUnit.Small;
                    lblmessage.Visible = true;
                    lblmessage.CssClass = "warning-box";
                    //Response.Write("<script>alert('Your licence has expired.Please contact system administrator.')</script>");

                }
            }
            else
            {
                UserName.Enabled = false;
                Password.Enabled = false;
                BtnLogin.Enabled = false;
                lblmessage.Text = "Please contact Administrator for the liscence key.";
                lblmessage.Visible = true;
                lblmessage.Font.Size = FontUnit.Small;
                lblmessage.CssClass = "warning-box";
                //Response.Write("<script>alert('Your licence has expired.Please contact system administrator.')</script>");

            }
        }
        catch (Exception ex)
        {
            lblmessage.Text = "Your current liscence is not valid or is tampered. Please renew your liscence.";
            lblmessage.Visible = true;
            UserName.Enabled = false;
            Password.Enabled = false;
            BtnLogin.Enabled = false;
            lblmessage.Font.Size = FontUnit.Smaller;
            lblmessage.CssClass = "warning-box";
        }
        finally
        {
            dtlic = null;
            ObjGeneral = null;
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

            /***********************/
            int res1 = 0;
            //  objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];

            // BusinessEntityLayer.BalProductionModule objProduction = new BusinessEntityLayer.BalProductionModule();


            //res = objProduction.UpdateLoginFlag(Convert.ToInt32(Session["UserId"].ToString()), 2);

            /***********************/


            ObjGenBal.auditdetail = "User Login";
            ObjGenBal.machineIP = Request.UserHostAddress.ToString();
            ObjGenBal.AuditInsert();
            //-----------END---------------------

            //----------Track Contec IT Team-----------
            if (Convert.ToString(objectSessionHolderPersistingData.GrpCode) == "RKBE")
            {
                string query = "Select * from AuditITTeam where LoingId='" + objectSessionHolderPersistingData.LoginId + "'";
                DataTable dtTrack = new DataTable();
                dtTrack = ObjGenBal.FetchData(query);
                if (dtTrack.Rows.Count > 0)
                {
                    if (Request.UserHostAddress.ToString() != dtTrack.Rows[0]["MachineIP"].ToString())
                    {
                        lblmessage.CssClass = "warning-box";
                        lblmessage.Text = "Please login with own system";
                        lblmessage.Visible = true;
                       
                        return;
                    }
                }
            }
            //-------------------
            int res = 0;
            BusinessEntityLayer.BalProductionModule objProduction = new BusinessEntityLayer.BalProductionModule();
            res1 = objProduction.UpdateLoginFlag(Convert.ToInt32(ObjGenBal.userid), 4);

            res = objProduction.UpdateLoginFlag(Convert.ToInt32(ObjGenBal.userid), 1);
            
            if (res == 2)
            {
              //  lblmessage.Visible = true;
              //  lblmessage.Text = "You are already login. Please logout first.";
               // ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('You are already login. Please logout first.');", true);
                lblmessage.CssClass = "warning-box";
                lblmessage.Text = "You are already Logged in. Please Log Out first";
                lblmessage.Visible = true;
               // Response.Write("<script>alert('You are already login. Please logout first.');</script>");
                return;
            }

            if (objectSessionHolderPersistingData.CompanyId == "0")
            {
                Response.Redirect("CompanyPage/default.aspx");
            }
            else
            {               
                Trace.Warn("objectSessionHolderPersistingData.CompanyId : " + objectSessionHolderPersistingData.CompanyId);
                string strGrpCode = Convert.ToString(objectSessionHolderPersistingData.GrpCode);
                Trace.Warn("strGrpCode : " + strGrpCode);
                if (strGrpCode == "EMBS" || strGrpCode == "VSAO" || strGrpCode == "CMDC" || strGrpCode == "NILO")
                {
                    Response.Redirect("Admin/ApplicationProcess.aspx");
                }
                else if (strGrpCode == "IMOF")
                {
                    Response.Redirect("Admin/FrmImmigrationApplicationList.aspx");
                }
                else if (strGrpCode == "STKR")
                {
                    Response.Redirect("Admin/FrmVisaStickerPrintingList.aspx");
                }
                else
                {
                    Response.Redirect("Admin/default.aspx");
                }              
            }
           // FormsAuthentication.RedirectFromLoginPage(UserName.Text, true);
        }
    }

    //----------------------------------------base 64 encode and decoding functions----------------------------

    public string base64Decode(string data)
    {
        try
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();

            byte[] todecode_byte = Convert.FromBase64String(data);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;
        }
        catch (Exception e)
        {
            throw new Exception("Error in base64Decode" + e.Message);
        }
    }

    public string base64Encode(string data)
    {
        try
        {
            byte[] encData_byte = new byte[data.Length];
            encData_byte = System.Text.Encoding.UTF8.GetBytes(data);
            string encodedData = Convert.ToBase64String(encData_byte);
            return encodedData;
        }
        catch (Exception e)
        {
            throw new Exception("Error in base64Encode" + e.Message);
        }
    }
    //----------------------------------------end -------------------------------------------------------

    /// <summary>

    /// Authenticate user

    /// </summary>

    /// <param name="userName"></param>

    /// <param name="password"></param>

    /// <param name="rememberUserName"></param>

    /// <returns></returns>
    private bool AuthenticateMe()
    {
        string userName = UserName.Text;
        string password = Password.Text;

        bool rememberUserName = true;
        DataTable dtable = null;
        BusinessEntityLayer.AccountUserData ObjUserAccount = null;

        //try
        //{
            ObjUserAccount = new BusinessEntityLayer.AccountUserData();
                    dtable = ObjUserAccount.Fetch_UserDetail_by_UserName(userName, password);
            if (dtable.Rows.Count > 0)
            {
            ObjGeneral = new BaseLayer.General_function();
            string query = "select a.*,b.* from UserZoneRelation as a,Zonemaster as b where a.ZoneCode = b.ZoneCode and a.UserId=" + dtable.Rows[0]["UserId"].ToString().Trim()+ "";
            DataTable dtznip = new DataTable();
            dtznip = ObjGeneral.FetchData(query);

            // record validated
            
                if (dtable.Rows[0]["LoginID"].ToString() != userName)
                {
                    lblmessage.Text = "Wrong Login ID";
                    lblmessage.Visible = true;
                    lblmessage.CssClass = "warning-box";
                    //Response.Write("<script>alert('Wrong Login ID')</script>");
                    UserName.Focus();
                    return false;
                }
                else if (base64Decode(dtable.Rows[0]["Password"].ToString()) != password)
                {
                    lblmessage.Text = "Wrong Password";
                    lblmessage.Visible = true;
                    lblmessage.CssClass = "warning-box";
                    //Response.Write("<script>alert('Wrong Password')</script>");
                    Password.Focus();
                    return false;
                }
                //check userstatus
                else if (dtable.Rows[0]["UserStatus"].ToString() != "A")
                {
                    lblmessage.Text = "Inactive User,Contact to System Admin";
                    lblmessage.Visible = true;
                    lblmessage.CssClass = "warning-box";
                    //Response.Write("<script>alert('Inactive User,Contact to System Admin')</script>");
                    UserName.Focus();
                    return false;
                }
                //Added by Ankit for Validity and Verification request

                else if (dtable.Rows[0]["IsValid"].ToString() == "3")
                {
                    lblmessage.Text = "Validity of Login ID has been expired";
                    lblmessage.Visible = true;
                    lblmessage.CssClass = "warning-box";
                    UserName.Focus();
                    return false;     
                }

                else if (dtable.Rows[0]["IsValid"].ToString() == "0")
                {
                    lblmessage.Text = "Login ID has not been verified,Kindly verify it from your email";
                    lblmessage.Visible = true;
                    lblmessage.CssClass = "warning-box";
                    UserName.Focus();
                    return false;  
                }

                if (dtznip.Rows.Count > 0)
                {
                    string ip = HttpContext.Current.Request.Url.Host;
                    if (dtznip.Rows[0]["ZoneIP"].ToString() != ip.ToString() && ip.ToString()!="localhost")
                    {
                        lblmessage.Text = "You are not authorized to login in this Zone";
                        lblmessage.Visible = true;
                        lblmessage.CssClass = "warning-box";
                        return false;
                    }
                    else
                    {

                        // get the role now
                        //string roles = rows[0]["Roles"].ToString();

                        // Create forms authentication ticket
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
                        objectSessionHolderPersistingData.LevelType = dtable.Rows[0]["ApproverLevel"].ToString();
                        objectSessionHolderPersistingData.LoginId = dtable.Rows[0]["LoginId"].ToString();
                        objectSessionHolderPersistingData.GrpCode = dtable.Rows[0]["GrpCode"].ToString();
                        Session["SessionHolderPersistingData"] = objectSessionHolderPersistingData;
                        return true;
                    }
                }
                else
                {
                    lblmessage.Text = "You are not authorized to login in this Zone..";
                    lblmessage.Visible = true;
                    lblmessage.CssClass = "warning-box";
                    return false;
                }
            }
            else // wrong Login ID or Password
            {

                lblmessage.Text = "Wrong Login ID or Password";
                lblmessage.Visible = true;
                lblmessage.CssClass = "warning-box";
                //Response.Write("<script>alert('Wrong LoginID or Password')</script>");
                UserName.Focus();
                Password.Text = string.Empty;                
                return false;
            }
        //}
        //catch (Exception ex)
        //{
        //    throw ex;
        //    return false;
        //}




    }

    protected void idsuperAdmin_Click(object sender, EventArgs e)
    {
        //Response.Redirect("CompanyPage/default.aspx");
    }

    //protected void LoginButton_Click(object sender, ImageClickEventArgs e)
    //{
        
    //}


    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "Help", "<script>window.open('FrmHelpText.aspx','_blank','menubar=no,status=yes,Width=900,Height=750,top=50,right=50');</script>");                    
                    
    }
    
    protected void BtnLogin_Click(object sender, EventArgs e)
    {
        UserLogin_Authenticate();
    }

    public int validitycheck(string key)
    {
        string val_old = key.ToString();
        string val = Decode(Decode(val_old));
        string[] val1 = val.Split('*');
        DateTime date = Convert.ToDateTime(val1[1].ToString());
        if (date < DateTime.Now)
        {
            return 1;
        }
        else
        {
            return -1;
        }

    }

    public double daysleft(string key)
    {
        string val_old = key.ToString();
        string val = Decode(Decode(val_old));
        string[] val1 = val.Split('*');
        DateTime date = Convert.ToDateTime(val1[1].ToString());
        //TimeSpan diff = date-DateTime.No
        return (date - DateTime.Today).TotalDays;
    }

    public string Decode(string data)
    {
        try
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();

            byte[] todecode_byte = Convert.FromBase64String(data);

            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;

        }
        catch (Exception e)
        {
            throw e;
        }

    }
}
