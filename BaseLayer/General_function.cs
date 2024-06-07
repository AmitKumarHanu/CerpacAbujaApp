using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Net.Mail;
using System.Configuration;
using System.Web;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Xml;
using DataAccessLayer;



//ENUM FOR FORM CODE
public enum ENUMFORMCODE
{
    CountryMaster = 15,
    CityMaster = 80,
    VisaTypeMaster = 82,
    CurrencyMaster = 81,
    BorderMaster = 93,
    CountryVisaMaster = 85,
    UserMaster = 30,
    ApprovalL1 = 86,
    RejectionMaster = 139,
    DocumentMaster = 20,
    DocMaster = 50,
    Documentmaster = 151,
    Zonemaster = 152,
    ZoneMaster = 153,
    HeaderMaster = 149,
    ReportMaster = 150,
    StickerMaster = 128,
    GroupMaster = 74,
    ModuleMaster = 72,
    VisaStickerList = 137,
    Immigration = 134,
    AgentRegistration = 61,
    WorkCenterMaster = 160,
    WorkMaster,
    ActivityMaster = 162,
    BlacklistedPassportMaster,
    SystemSettingMaster,
    ContactMasterMaster,
    ContactMaster,
    Branchmaster,



}
//ENUM FOR AUDIT TYPE
//ENUM FOR AUDIT TYPE
public enum ENUMAUDITTYPE
{
    CompanyId = 59,
    GroupId = 28,
    Login = 10,
    Logout = 11,
    CompanyRegistered = 12,
    CompanyDeleted = 13,
    CompanyInfoUpdated = 14,
    UserCreated = 15,
    UserDeleted = 16,
    UserUpdated = 17,
    AgentDeleted = 48,
    ChangePassword = 18,
    FormAccessRights = 19,
    DocUploaded = 20,
    DocView = 22,
    DocDownload = 23,
    DocEmail = 24,
    GroupAdded = 40,
    GroupInfoUpdated = 41,
    GroupFormRelation = 42,
    ModuleAdded = 50,
    ModuleInfoUpdated = 51,
    ModuleFormRelation = 52,
    CountryCreated = 25,
    CountryUpdated = 26,
    CountryDeleted = 27,
    CityCreated = 28,
    CityUpdated = 29,
    CityDeleted = 30,
    Docdeleted,
    CurrencyCreated = 31,
    CurrencyUpdated = 32,
    CurrencyDeleted = 33,
    VisaTypeCreated = 34,
    VisaTypeUpdated = 35,
    VisaTypeDeleted = 36,
    BorderCreated = 37,
    BorderUpdated = 38,
    BorderDeleted = 39,
    CountryVisaMasterCreated = 40,
    CountryVisaMasterUpdated = 41,
    CountryVisaMasterDeleted = 42,
    StickerMasterCreated = 43,
    StickerMasterUpdated = 44,
    StickerMasterDeleted = 45,
    StickerAuthorityIssued = 46,
    StickerAuthorityReceived = 47,
    RejectionUpdated = 50,
    REJECTIONCreated = 51,
    RejectionDeleted = 52,
    ApprovalL1select = 87,
    VisaApplicationDeleted = 88,
    EmbassyDeleted = 98,
    DocCreated = 100,
    DocumentUpdated = 123,
    ZonCreated = 85,
    ZonUpdated = 86,
    ZonDeleted = 87,
    ZoneCreated = 82,
    ZoneUpdated = 83,
    ZoneDeleted = 84,
    WorkCenterCreated = 79,
    WorkCenterUpdated = 80,
    WorkCenterDeleted = 81,
    ActivityDeleted = 65,
    ActivityUpdated = 64,
    ActivityCreated = 63,
    BlacklistedPassportCreated = 66,
    BlacklistedPassportUpdated = 67,
    BlacklistedPassportDeleted = 68,
    PassportCreated = 144,
    PassportUpdated = 255,
    SystemSettingCreated = 76,
    SystemSettingUpdated = 77,
    SystemSettingdeleted = 78,
    ReportMasterDeleted = 62,
    ReportMasterCreated = 60,
    ReportMasterUpdated = 61,
    WorkflowUpdated = 88,
    GFUpdated = 89,
    RCUpdated = 90,
    UAUpdated = 91,
    RJUpdated = 92,
    RecommendUpdated = 93,
    MyProfileUpdated = 88,
    DocUpdated,
    DocDeleted,
    BranchUpdated,
    BranchCreated,
    BranchDeleted
}



namespace BaseLayer
{


    public class General_function
    {
        //public static General_function Instance = new General_function();

        #region Private Variables : Fill drop Down

        private string _textfield;
        private string _valuefield;
        private string _tableName;
        private string _whereclause;
        private string _qry;
        private string _audittype;
        private string _userid;
        private string _auditdetail;
        private string _formid;
        private string _machineIP;
        private string _machineName;
        private string _windowUser;



        #endregion

        #region public property

        public string TextField
        {
            get
            {
                return _textfield;
            }
            set
            {
                _textfield = value;
            }
        }

        public string Qry
        {
            get
            {
                return _qry;
            }
            set
            {
                _qry = value;
            }
        }


        public string ValueField
        {
            get
            {
                return _valuefield;
            }
            set
            {
                _valuefield = value;
            }
        }

        public string TableName
        {
            get
            {
                return _tableName;
            }
            set
            {
                _tableName = value;
            }
        }

        public string WhereClause
        {
            get
            {
                return _whereclause;
            }
            set
            {
                _whereclause = value;
            }
        }

        public string audittype
        {
            get { return _audittype; }
            set { _audittype = value; }
        }
        public string machineIP
        {
            get { return _machineIP; }
            set { _machineIP = value; }
        }
        public string machineName
        {
            get { return _machineName; }
            set { _machineName = value; }
        }
        public string windowUser
        {
            get { return _windowUser; }
            set { _windowUser = value; }
        }
        public string userid
        {
            get { return _userid; }
            set { _userid = value; }
        }
        public string auditdetail
        {
            get { return _auditdetail; }
            set { _auditdetail = value; }
        }
        public string formid
        {
            get { return _formid; }
            set { _formid = value; }
        }



        #endregion

        private static char[] charSeparators = new char[] { };  // used in email method
        private static String[] result;                         // used in email method


        #region General Methods for Fetch Data
        #region  Dropdown List
        /// <summary>
        /// Created by: Ankit Gupta, 24th june 2008       
        /// </summary>
        /// <param name="text">General</param>
        /// <param name="value"General></param>
        /// <param name="tablename">General</param>
        /// <param name="whereclause">General</param>
        /// <returns>method return datatable with text/value for dropdown </returns>
        /// 
        public DataTable Fill_dropdownlist()
        {
            DataAccessLayer.DalGeneral_function objDalGeneral_function = null;
            DataTable dt = null;
            try
            {
                objDalGeneral_function = new DataAccessLayer.DalGeneral_function();
                dt = objDalGeneral_function.Fill_dropdown_list(this.TextField, this.ValueField, this.TableName, this.WhereClause);
                return dt;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                objDalGeneral_function = null;
                dt = null;
            }
        }
        #endregion

        #region Fetch Data By SqlStatement
        /// <summary>
        /// <author >Manish Khandelwal</author>
        /// <created Date>29 july 2008</created>
        /// <Purpose>General Method For Fetch the data </Purpose>
        /// </summary>
        /// <returns></returns>  
        public DataTable FETCH_DATA_GENRAL()
        {
            DataAccessLayer.DalGeneral_function objDalGeneral_function = null;
            DataTable dt = null;
            try
            {
                objDalGeneral_function = new DataAccessLayer.DalGeneral_function();
                dt = objDalGeneral_function.FetchData(this.Qry);
                return dt;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                objDalGeneral_function = null;
                dt = null;
            }
        }

        #endregion

        #region Insert into Audit
        public string getActionDetails_FormAccesRights(DataTable dtActionDetail)
        {
            string strActionDetails = "";
            for (int RowCounter = 0; RowCounter < dtActionDetail.Rows.Count; RowCounter++)
            {
                DataRow drActionDetail = dtActionDetail.Rows[RowCounter];


                strActionDetails = strActionDetails + "#(" + drActionDetail["FormId"].ToString();
                strActionDetails = strActionDetails + ":" + drActionDetail["Add_Permission"].ToString();
                strActionDetails = strActionDetails + "-" + drActionDetail["Mod_Permission"].ToString();
                strActionDetails = strActionDetails + "-" + drActionDetail["Del_Permission"].ToString();
                strActionDetails = strActionDetails + "-" + drActionDetail["View_Permission"].ToString() + ")";
            }

            return strActionDetails;
        }

        public void AuditInsert()
        {
            DataAccessLayer.DalGeneral_function ObjGenDal = null;
            DataTable dtAudit = null;
            this.machineName = System.Net.Dns.GetHostName();
            this.windowUser = HttpContext.Current.Request.LogonUserIdentity.Name;
            try
            {
                ObjGenDal = new DataAccessLayer.DalGeneral_function();
                dtAudit = new DataTable();
                dtAudit.Columns.Add("AuditType");
                dtAudit.Columns.Add("UserId");
                dtAudit.Columns.Add("AuditDetail");
                dtAudit.Columns.Add("MachineIP");
                dtAudit.Columns.Add("MachineName");
                dtAudit.Columns.Add("WindowUser");

                DataRow drAudit = dtAudit.NewRow();
                drAudit["AuditType"] = this._audittype;
                drAudit["UserId"] = this._userid;
                drAudit["AuditDetail"] = this._auditdetail;
                drAudit["MachineIP"] = this._machineIP;
                drAudit["MachineName"] = this._machineName;
                drAudit["WindowUser"] = this._windowUser;
                dtAudit.Rows.Add(drAudit);
                ObjGenDal.AuditInsert(dtAudit);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #endregion


        /// <summary>
        /// Created By : Ankit Gupta
        /// Created Date :22 Sep 2009
        /// Description : Common function for sending mail
        /// </summary>
        /// <param name="strTo"></param>
        /// <param name="strFrom"></param>
        /// <param name="Subject"></param>
        /// <param name="Body"></param>
        /// <returns></returns>
        public bool SendMail(string strTo, string strFrom, string Subject, string Body)
        {
            try
            {
                System.Net.Mail.MailMessage objMailMessage = new System.Net.Mail.MailMessage();
                objMailMessage.From = new MailAddress(strFrom.Trim());
                objMailMessage.To.Add(new MailAddress(strTo.Trim()));
                objMailMessage.IsBodyHtml = true;
                objMailMessage.Subject = Subject;
                objMailMessage.Body = Body;

                objMailMessage.Priority = MailPriority.Normal;

                string sUserName = "";
                sUserName = ConfigurationManager.AppSettings["MailServerUserID"].ToString();
                string spAssword = ConfigurationManager.AppSettings["MailServerPassword"].ToString();
                System.Net.NetworkCredential basicAuthenticationInfo = new System.Net.NetworkCredential(sUserName, spAssword);

                SmtpClient objSmptp = new SmtpClient();
                objSmptp.Host = ConfigurationManager.AppSettings["MailServer"].ToString();
                //objSmptp.Port = int.Parse(ConfigurationManager.AppSettings["MailServerPort"].ToString().Trim());

                objSmptp.UseDefaultCredentials = false;
                objSmptp.Credentials = basicAuthenticationInfo;
                objSmptp.Send(objMailMessage);

                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string errorhandling(string errdesc, int userid)
        {
            SqlParameter[] pram = null;
            pram = new SqlParameter[3];

            pram[0] = new SqlParameter("@expception_details", errdesc.ToString().Trim());
            pram[1] = new SqlParameter("@user_id", userid);
            pram[2] = new SqlParameter("@SuccessId", 1);
            pram[2].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_Exception_Details", pram);
            return pram[2].Value.ToString();
        }

        public bool SendMailMessage(string smtpHost, MailAddress from, string to, string subject, string message, string strFilePathNew)
        {

            try
            {

                MailMessage mailMsg = new MailMessage();
                result = to.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
                for (int count = 0; count < result.Length; count++)
                { mailMsg.To.Add(new MailAddress(result[count])); }
                // mailMsg.CC.Add(cc);
                mailMsg.From = from;
                mailMsg.Subject = subject;
                mailMsg.IsBodyHtml = true;
                mailMsg.BodyEncoding = System.Text.Encoding.UTF8;
                mailMsg.Body = message;

                mailMsg.Attachments.Add(new Attachment(strFilePathNew));

                SmtpClient smtpClient = new SmtpClient(smtpHost);

                smtpClient.Send(mailMsg);

                mailMsg.Dispose();

                return true;


            }
            catch (Exception exc)
            {

                //   throw exc;
                return false;
            }

        }

        #region  Checking Access Rights.

        public void CheckAccess(out string Add, out string Mod, out string Del, out string View)
        {
            DataAccessLayer.DalGeneral_function ObjGenDal = null;
            DataTable dt = null;
            try
            {
                ObjGenDal = new DataAccessLayer.DalGeneral_function();
                dt = ObjGenDal.CheckAccess(this._formid, this._userid);
                if (dt.Rows.Count > 0)
                {
                    Add = dt.Rows[0]["Add_Permission"].ToString();
                    Mod = dt.Rows[0]["Mod_Permission"].ToString();
                    Del = dt.Rows[0]["Del_Permission"].ToString();
                    View = dt.Rows[0]["View_Permission"].ToString();
                }
                else
                {
                    Add = "N";
                    Mod = "N";
                    Del = "N";
                    View = "N";

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion

        public int ValidDateCheck()
        {
            DataAccessLayer.DalGeneral_function objDalGeneral_function = null;
            try
            {
                objDalGeneral_function = new DataAccessLayer.DalGeneral_function();
                return objDalGeneral_function.ValidDateCheck();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                objDalGeneral_function = null;

            }
        }

        public DataTable FetchData(string StrQuery)
        {
            DataAccessLayer.DalGeneral_function objDalGeneral_function = null;
            DataTable dt = null;
            try
            {
                objDalGeneral_function = new DataAccessLayer.DalGeneral_function();
                dt = objDalGeneral_function.FetchData(StrQuery);
                return dt;
            }
            catch (Exception ex)
            {
               throw (ex);
            }
            finally
            {
                objDalGeneral_function = null;
                dt = null;
            }
        }

        public void Fill_DDL(DropDownList ddl, string StrQuery, string Text_Field, string Value_Field)
        {
            DataTable dtGenral;
            //   try
            // {
            dtGenral = new DataTable();
            dtGenral = FetchData(StrQuery);
            ddl.Items.Clear();
            ddl.DataSource = dtGenral;
            ddl.DataTextField = Text_Field;
            ddl.DataValueField = Value_Field;
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("----Select----", "0"));

            //}
            //catch (Exception ex)
            // {
            //   throw (ex);
            //}
            //finally
            // {
            //   dtGenral = null;
            // }

        }

        public void Fill_DDLReport(DropDownList ddl, string StrQuery, string Text_Field, string Value_Field)
        {
            DataTable dtGenral;
            try
            {
                dtGenral = new DataTable();
                dtGenral = FetchData(StrQuery);
                ddl.Items.Clear();
                ddl.DataSource = dtGenral;
                ddl.DataTextField = Text_Field;
                ddl.DataValueField = Value_Field;
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem("ALL", "0"));

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                dtGenral = null;
            }

        }

        /*----- Btn access rights for form (VPS : Made by WASIM--- */

        public DataTable TbBtnaccess(string FORMCODE, string USERID)
        {

            DataTable dtBtnAccess;
            try
            {
                dtBtnAccess = new DataTable();
                string StrQuery = "SELECT * FROM dbo.FORMACCESS WHERE FORMID = '" + FORMCODE + "' AND USERID = '" + USERID + "'";

                dtBtnAccess = FetchData(StrQuery);
                return dtBtnAccess;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                dtBtnAccess = null;
            }
        }

        public int approvalLevelType(string strvisaType, string strPeriodType, string strPeriod)
        {
            DataTable dtLevelType = new DataTable();
            string queryType = @" select cvm.ApproverLevel,cvm.VISATYPECODE from CountryVisaMaster cvm left outer join VisaTypeMaster vtm on vtm.VisaTypeCode=cvm.VISATYPECODE  where  cvm.STATUS='A' and cvm.PERIODTYPE='" + strPeriodType + "' AND CVM.PERIOD='" + strPeriod + "' and vtm.VisaTypeName ='" + strvisaType + "' ";
            dtLevelType = FetchData(queryType);
            int intLevelType = Convert.ToInt32(dtLevelType.Rows[0]["ApproverLevel"].ToString());
            return intLevelType;

        }


    }
}
