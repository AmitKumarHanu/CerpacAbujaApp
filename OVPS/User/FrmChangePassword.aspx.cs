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

public partial class User_FrmChangePassword : System.Web.UI.Page
{

    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    BaseLayer.General_function objgenbal = null;
    #endregion

    protected void Page_PreInit(object sender, EventArgs e)
    {
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        if (objectSessionHolderPersistingData == null)
        {
            Response.Redirect("../Login.aspx");
        }
        if (objectSessionHolderPersistingData != null)
        {
            string companyid = objectSessionHolderPersistingData.CompanyId;
            if (companyid == "0")

                this.Page.MasterPageFile = "~/MasterPage/MasterPageCompany.master";
            else
                this.Page.MasterPageFile = "~/MasterPage/MasterPageUser.master";
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        if (objectSessionHolderPersistingData == null)
        {
            Response.Redirect("../Login.aspx");
        }

        if (!IsPostBack)
        {
            txtLoginId.Text = objectSessionHolderPersistingData.LoginId;
            //-----------------------------------------for disabling the hyperlink ------------------------------
            TreeView tvr = (TreeView)this.Page.Master.FindControl("TVLeftMenu");
            tvr.Visible = false;
            HyperLink hyp = (HyperLink)this.Page.Master.FindControl("hypHome");
            hyp.Attributes.Add("onclick", "if(!confirm('Are you sure you want to go to home page')) return false;");
            //-----------------------------------------------end ---------------------------------------------------
            if (Convert.ToString(Request.QueryString["msg"]) != null)
            {
                lblpwdchngmsg.Visible = true;
            }
            else
            {
                lblpwdchngmsg.Visible = false;
            }
        }

    }

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

    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        BusinessEntityLayer.AccountUserData objBalAccountUserData = null;
        
        try
        {
            objBalAccountUserData = new BusinessEntityLayer.AccountUserData();
            objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
            //Setting the properties of ObjectBalVesselcode to perform the update operation.
            objBalAccountUserData.loginid = objectSessionHolderPersistingData.LoginId;
            objBalAccountUserData.password = base64Encode(txtOldPassword.Text.ToString());
            objBalAccountUserData.newpassword = base64Encode(txtconfirmpassword.Text.ToString());

            if (txtNewPassword.Text.ToString().Trim() == txtOldPassword.Text.ToString().Trim())
            {
                Response.Write("<script>alert('New Password cannot be equal to old password.')</script>");
                return;
            }
            string oldpwdquery = "Select * from tbl_passwordpolicy where userid='"+objectSessionHolderPersistingData.User_ID+"'";
            objgenbal = new BaseLayer.General_function();
            DataTable dtoldpwd = null;
            dtoldpwd = new DataTable();
            dtoldpwd = objgenbal.FetchData(oldpwdquery);
            if (dtoldpwd.Rows.Count > 0)
            {
                if (base64Decode(dtoldpwd.Rows[0]["old_password"].ToString().Trim()).Trim() == txtNewPassword.Text.ToString().Trim())
                {                                                                                                                     
                    txtNewPassword.Text = "";
                    txtconfirmpassword.Text = "";
                    Response.Write("<script>alert('You have already setup this password one time. Please try a new password.')</script>");
                    return;
                }
            }

            //Call the Update method of business layer
            int StatusId = objBalAccountUserData.UserMasterChangePassword();


            //Code for setting the attributes of the label which shows the status of the insert opertation.
            if (StatusId == 1)
            {
                //--------------Insert into Audit-----------
               
                BaseLayer.General_function ObjGenBal = new BaseLayer.General_function();
                ObjGenBal.audittype = ENUMAUDITTYPE.ChangePassword.GetHashCode().ToString();
                ObjGenBal.userid = objectSessionHolderPersistingData.User_ID;
                ObjGenBal.auditdetail = "User '"+txtLoginId.Text+"' changed Password.";
                ObjGenBal.machineIP = Request.UserHostAddress.ToString();
                ObjGenBal.AuditInsert();
                //---------------------End----------
                lblmessage.Visible = true;
                lblmessage.CssClass = "successmsg";
                lblmessage.Text = "Password Updated Sucessfully";
                Response.Write("<script>alert(Password Updated sucessfully. Please login again with the new password.)</script>");
                Session.Abandon();
                objectSessionHolderPersistingData = null;
            }
            else
            {
                lblmessage.Visible = true;
                lblmessage.CssClass = "errormsg";
                lblmessage.Text = "Incorrect Old Password,Please enter correct one";

            }
        }
        catch (Exception ex)
        {
            lblmessage.Visible = true;
            lblmessage.CssClass = "errormsg";
            lblmessage.Text = "Please contact to System Administrator; Error message is: " + ex.Message.ToString();

        }
        finally
        {
            objBalAccountUserData = null;

        }
    }
}
