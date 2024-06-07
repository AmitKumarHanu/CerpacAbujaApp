using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Configuration;
using System.Web;
using System.Data.Common;
using System.Data.SqlClient;
using System.Net;
using System;
using DataAccessLayer;
using System.Net.Mail;

namespace BusinessEntityLayer
{

    public class AccountUserData
    {
        private static char[] charSeparators = new char[] { };
        private static String[] result;

        private string _MenuItem;
        private string _ROLEID;   // roleId =UserId temporarily.
        private string _grpid;
        private string _username;

        private string _password;
        private string _companyid;

        private string _GrpName;
        private string _DateOfBirth;
        private string _EmailId;
        private string _ContactNo;
        private string _Address;
        private string _UserStatus;

        //private string _UniqueCode;
        public string UserLoginid { get; set; }
        public string NPassword { get; set; }
        public string UniqueCode { get; set; }
        public string loginid { get; set; }
        public string newpassword { get; set; }


        public string menuitem
        {
            get { return menuitem; }
            set { menuitem = value; }

        }
        public string roleid
        {
            get { return roleid; }
            set { roleid = value; }
        }

        public string grpid
        {
            get { return _grpid; }
            set { _grpid = value; }
        }
        public string username
        {
            get { return _username; }
            set { _username = value; }
        }

        public string password
        {
            get { return _password; }
            set { _password = value; }

        }


        public string companyid
        {
            get { return _companyid; }
            set { _companyid = value; }

        }
        public string grpname
        {
            get { return grpname; }
            set { grpname = value; }

        }
        public string dateofbirth
        {
            get { return dateofbirth; }
            set { dateofbirth = value; }

        }
        public string emailid
        {
            get { return emailid; }
            set { emailid = value; }

        }
        public string contactno
        {
            get { return contactno; }
            set { contactno = value; }

        }
        public string address
        {
            get { return address; }
            set { address = value; }

        }
        public string userstatus
        {
            get { return userstatus; }
            set { userstatus = value; }

        }

        //public string UniqueCode
        //{
        //    get { return UniqueCode; }
        //    set { UniqueCode = value; }

        //}

        /// <summary>
        /// To fetch Form Detail from TBL_FORMMASTER for the clicked menu item
        /// <returns></returns>
        /// <author>Ankit Gupta</author>
        /// <created Date>3rd july 2008</created>
        public DataTable FetchFormData()
        {
            DataAccessLayer.DalAccountUserData objDalAccountUser = null;
            try
            {
                objDalAccountUser = new DataAccessLayer.DalAccountUserData();
                return objDalAccountUser.Fetch_FormDetail_For_Menu(this.menuitem, this.roleid);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDalAccountUser = null;
            }
        }

        /// <author >Ankit gupta</author>
        /// <created Date>9th june 2008</created>
        /// <purpose> Fetch User Detail</purpose>
        /// </summary>
        /// <returns></returns>      
        public DataTable Fetch_UserDetail_by_UserName(string UserName, string Password)
        {
            DataAccessLayer.DalAccountUserData ObjDalAccountUserData = null;

            try
            {
                ObjDalAccountUserData = new DataAccessLayer.DalAccountUserData();
                return ObjDalAccountUserData.Fetch_USerDetailByUserName(UserName, Password);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ObjDalAccountUserData = null;

            }
        }

        /// <author >Bimalesh Karn</author>
        /// <created Date>9th August 2011</created>
        /// <purpose> Fetch User Detail with unique code</purpose>
        /// </summary>
        /// <returns></returns>      
        public DataTable Fetch_UserDetail_by_UserName(string UserName, string Password, string uniqueid)
        {
            DataAccessLayer.DalAccountUserData ObjDalAccountUserData = null;

            try
            {
                ObjDalAccountUserData = new DataAccessLayer.DalAccountUserData();
                return ObjDalAccountUserData.Fetch_USerDetailByUserName(UserName, Password, uniqueid);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ObjDalAccountUserData = null;

            }
        }



        public int UpdateVerified()
        {
            DataAccessLayer.DalAccountUserData ObjDalUpdate = null;
            DataTable dt = null;
            try
            {
                ObjDalUpdate = new DataAccessLayer.DalAccountUserData();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                //Code for adding columns in datatable.
                dt.Columns.Add("LoginID");
                dt.Columns.Add("Password");
                dt.Columns.Add("UniqueCode");

                dr["LoginID"] = this.UserLoginid;
                dr["Password"] = this.NPassword;
                dr["UniqueCode"] = this.UniqueCode;

                dt.Rows.Add(dr);

                return ObjDalUpdate.UpdateVerified(dt);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dt = null;
                ObjDalUpdate = null;
            }
        }

        /////////////////////////////////////////////////////////


        public DataTable Fetch_UserDetail_by_UserId(string UserId)
        {
            DataAccessLayer.DalAccountUserData ObjDalAccountUserData = null;

            try
            {
                ObjDalAccountUserData = new DataAccessLayer.DalAccountUserData();
                return ObjDalAccountUserData.Fetch_USerDetailByUserId(UserId);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ObjDalAccountUserData = null;

            }
        }

        public DataTable Fetch_UserDetail_by_CompanyId(string CompanyId)
        {
            DataAccessLayer.DalAccountUserData ObjDalAccountUserData = null;

            try
            {
                ObjDalAccountUserData = new DataAccessLayer.DalAccountUserData();
                return ObjDalAccountUserData.Fetch_UserDetail_by_CompanyId(CompanyId);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ObjDalAccountUserData = null;

            }
        }

        public DataTable Fetch_UserDetail_by_GrpId()
        {
            DataAccessLayer.DalAccountUserData ObjDalAccountUserData = null;

            try
            {
                ObjDalAccountUserData = new DataAccessLayer.DalAccountUserData();
                return ObjDalAccountUserData.Fetch_UserDetail_by_GrpId(this.grpid);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ObjDalAccountUserData = null;

            }
        }

        /// <author >Wasim Karim</author>
        /// <created Date>2 sept 09</created>
        /// <purpose> Fetch GroupMaster by CompanyId</purpose>
        /// </summary>
        /// <returns></returns>       
        public DataTable Fetch_GroupDetail_by_CompanyId(string CompanyId)
        {
            DataAccessLayer.DalAccountUserData ObjDalAccountUserData = null;

            try
            {
                ObjDalAccountUserData = new DataAccessLayer.DalAccountUserData();
                return ObjDalAccountUserData.Fetch_GroupDetail_by_CompanyId(CompanyId);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ObjDalAccountUserData = null;

            }
        }

        /// <author >Wasim Karim</author>
        /// <created Date>3 sept 09</created>
        /// <purpose> Fetch ModuleMaster by CompanyId</purpose>
        /// </summary>
        /// <returns></returns>
        public DataTable Fetch_ModuleDetail_by_CompanyId(string CompanyId)
        {
            DataAccessLayer.DalAccountUserData ObjDalAccountUserData = null;

            try
            {
                ObjDalAccountUserData = new DataAccessLayer.DalAccountUserData();
                return ObjDalAccountUserData.Fetch_ModuleDetail_by_CompanyId(CompanyId);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ObjDalAccountUserData = null;

            }
        }
        public DataTable FetchBorderList()
        {
            DataAccessLayer.DalAccountUserData ObjDalAccount = null;
            ObjDalAccount = new DalAccountUserData();
            return ObjDalAccount.FetchBorderList();
        }
        public DataTable FetchCountryList()
        {
            DataAccessLayer.DalAccountUserData ObjDalAccount = null;
            ObjDalAccount = new DalAccountUserData();
            return ObjDalAccount.FetchCountryList();
        }

        /// <author >Ankit gupta</author>
        /// <created Date>10th july 2008</created>
        /// <purpose> Fetch Home page Content</purpose>
        /// </summary>
        /// <returns></returns>
        public DataTable Fetch_Homepage_Content()
        {
            DataAccessLayer.DalAccountUserData ObjDalAccountUserData = null;

            try
            {
                ObjDalAccountUserData = new DataAccessLayer.DalAccountUserData();
                return ObjDalAccountUserData.Fetch_HomePage_content();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ObjDalAccountUserData = null;

            }
        }

        public int Insert_UserDetail()
        {
            DataAccessLayer.DalAccountUserData ObjDalAccountUserData = null;
            DataTable dt = null;

            try
            {
                ObjDalAccountUserData = new DalAccountUserData();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                dt.Columns.Add("UserName");
                dt.Columns.Add("Password");
                dt.Columns.Add("GrpId");
                dt.Columns.Add("CompanyId");
                dt.Columns.Add("DateOfBirth");
                dt.Columns.Add("EmailId");
                dt.Columns.Add("ContactNo");
                dt.Columns.Add("Address");
                dt.Columns.Add("UserStatus");


                dr["UserName"] = this._username;
                dr["Password"] = this._password;
                dr["GrpId"] = this._grpid;
                dr["CompanyId"] = this._companyid;
                dr["DateOfBirth"] = this._DateOfBirth;
                dr["EmailId"] = this._EmailId;
                dr["ContactNo"] = this._ContactNo;
                dr["Address"] = this._Address;
                dr["UserStatus"] = this._UserStatus;
                dt.Rows.Add(dr);
                return ObjDalAccountUserData.Insert_UserDetail(dt);
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public int Update_UserDetail()
        {
            DataAccessLayer.DalAccountUserData ObjDalUserDetails = null;
            DataTable dtUserDetails = null;
            try
            {
                ObjDalUserDetails = new DataAccessLayer.DalAccountUserData();
                dtUserDetails = new DataTable();

                DataRow drUserDetails = dtUserDetails.NewRow();

                dtUserDetails.Columns.Add("UserId");
                dtUserDetails.Columns.Add("UserName");
                dtUserDetails.Columns.Add("CompanyId");
                dtUserDetails.Columns.Add("GrpId");
                dtUserDetails.Columns.Add("DateOfBirth");
                dtUserDetails.Columns.Add("EmailId");
                dtUserDetails.Columns.Add("ContactNo");
                dtUserDetails.Columns.Add("Address");
                dtUserDetails.Columns.Add("Userstatus");

                drUserDetails["UserId"] = this._ROLEID;
                drUserDetails["UserName"] = this._username;
                drUserDetails["CompanyId"] = this._companyid;
                drUserDetails["GrpId"] = this._grpid;
                drUserDetails["DateOfBirth"] = this._DateOfBirth;
                drUserDetails["EmailId"] = this._EmailId;
                drUserDetails["ContactNo"] = this._ContactNo;
                drUserDetails["Address"] = this._Address;
                drUserDetails["Userstatus"] = this._UserStatus;

                dtUserDetails.Rows.Add(drUserDetails);

                return ObjDalUserDetails.Update_UserDetails(dtUserDetails);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dtUserDetails = null;
                ObjDalUserDetails = null;
            }



        }

        public int DeleteDataRow(int keyvalue)
        {
            DataAccessLayer.DalAccountUserData ObjDalAccountUserData = null;
            ObjDalAccountUserData = new DataAccessLayer.DalAccountUserData();
            return ObjDalAccountUserData.DeleteDataRow(keyvalue);
        }

        public string ForGetPossword(string EmailID, string Subject, string Body)
        {
            MailAddress From = new System.Net.Mail.MailAddress(System.Configuration.ConfigurationSettings.AppSettings["Email.Sender"]);
            string smtpHost = System.Configuration.ConfigurationSettings.AppSettings["Email.Smtp"].ToString();

            try
            {

                MailMessage mailMsg = new MailMessage();
                result = EmailID.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
                for (int count = 0; count < result.Length; count++)
                { mailMsg.To.Add(new MailAddress(result[count])); }
                //mailMsg.CC.Add("");

                mailMsg.From = From;
                mailMsg.Subject = Subject;
                mailMsg.IsBodyHtml = true;
                mailMsg.BodyEncoding = System.Text.Encoding.UTF8;
                mailMsg.Body = Body;

                SmtpClient smtpClient = new SmtpClient(smtpHost);
                smtpClient.Send(mailMsg);


                mailMsg.Dispose();
                return "Your Login Details has been sent to your mail id";

            }
            catch (Exception exc)
            {
                return "Problem in Mail server,your Login Details could not sent to your mail id";
            }

        }


        public int UserMasterChangePassword()
        {
            DataAccessLayer.DalAccountUserData ObjDalUserDetails = null;
            DataTable dtUserDetails = null;
            try
            {
                ObjDalUserDetails = new DataAccessLayer.DalAccountUserData();
                dtUserDetails = new DataTable();

                DataRow drUserDetails = dtUserDetails.NewRow();

                dtUserDetails.Columns.Add("LoginID");
                dtUserDetails.Columns.Add("Password");
                dtUserDetails.Columns.Add("NewPassword");

                drUserDetails["LoginID"] = this.loginid;
                drUserDetails["Password"] = this.password;
                drUserDetails["NewPassword"] = this.newpassword;

                dtUserDetails.Rows.Add(drUserDetails);

                return ObjDalUserDetails.UserMasterChangePassword(dtUserDetails);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dtUserDetails = null;
                ObjDalUserDetails = null;
            }



        }

        public string ApplicationStatus(string EmailID, string Subject, string Body)
        {
            MailAddress From = new System.Net.Mail.MailAddress(System.Configuration.ConfigurationSettings.AppSettings["Email.Sender"]);
            string smtpHost = System.Configuration.ConfigurationSettings.AppSettings["Email.Smtp"].ToString();

            try
            {

                MailMessage mailMsg = new MailMessage();
                result = EmailID.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
                for (int count = 0; count < result.Length; count++)
                { mailMsg.To.Add(new MailAddress(result[count])); }
                //mailMsg.CC.Add("");

                mailMsg.From = From;
                mailMsg.Subject = Subject;
                mailMsg.IsBodyHtml = true;
                mailMsg.BodyEncoding = System.Text.Encoding.UTF8;
                mailMsg.Body = Body;

                SmtpClient smtpClient = new SmtpClient(smtpHost);
                smtpClient.Send(mailMsg);


                mailMsg.Dispose();
                return "Your Online Visa Details has been sent to your mail id";

            }
            catch (Exception exc)
            {
                return "Problem in Mail server. Mail could not sent to Applicant";
            }

        }

        //===========================by chitresh======================

        public string BlockUser { get; set; }

        public int BlockLoginID()
        {
            DataAccessLayer.DalAccountUserData ObjDalUserDetails = null;
            DataTable dt = null;
            try
            {
                ObjDalUserDetails = new DataAccessLayer.DalAccountUserData();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                dt.Columns.Add("BlockUser");
                dr["BlockUser"] = this.BlockUser;
                dt.Rows.Add(dr);

                return ObjDalUserDetails.BlockLoginID(dt);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dt = null;
                ObjDalUserDetails = null;
            }

        }

        //==============================end==================
        //=============================================by chitresh latest =============================
        public DataTable Fetch_CompanyDetail_by_Loginid(string userName, string password, string uniqueid)
        {
            DataAccessLayer.DalAccountUserData ObjDalAccountUserData = null;

            try
            {
                ObjDalAccountUserData = new DataAccessLayer.DalAccountUserData();
                return ObjDalAccountUserData.Fetch_CompanyDetail_by_Loginid(userName, password, uniqueid);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ObjDalAccountUserData = null;

            }
        }


        public int UpdateVerificationofCompany()
        {
            DataAccessLayer.DalAccountUserData ObjDalUpdate = null;
            DataTable dt = null;
            try
            {
                ObjDalUpdate = new DataAccessLayer.DalAccountUserData();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                //Code for adding columns in datatable.
                dt.Columns.Add("LoginID");
                dt.Columns.Add("Password");
                dt.Columns.Add("UniqueCode");

                dr["LoginID"] = this.UserLoginid;
                dr["Password"] = this.NPassword;
                dr["UniqueCode"] = this.UniqueCode;

                dt.Rows.Add(dr);

                return ObjDalUpdate.UpdateVerificationofCompany(dt);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dt = null;
                ObjDalUpdate = null;
            }
        }
        //========================================end===========================================
        //=====================================================by chitresh dated:12-04-13===================================
        public DataTable Fetch_CompanyDetail_by_UserName(string userName, string password)
        {
            DataAccessLayer.DalAccountUserData ObjDalAccountUserData = null;

            try
            {
                ObjDalAccountUserData = new DataAccessLayer.DalAccountUserData();
                return ObjDalAccountUserData.Fetch_CompanyDetail_by_UserName(userName, password);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ObjDalAccountUserData = null;

            }
        }
        //===================================================end================================================

        public DataTable Fetch_UserDetail_by_UserNameAdmin(string userName, string password)
        {
            DataAccessLayer.DalAccountUserData ObjDalAccountUserData = null;

            try
            {
                ObjDalAccountUserData = new DataAccessLayer.DalAccountUserData();
                return ObjDalAccountUserData.Fetch_USerDetailByUserNameAdmin(userName, password);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ObjDalAccountUserData = null;

            }
        }
    }


}
