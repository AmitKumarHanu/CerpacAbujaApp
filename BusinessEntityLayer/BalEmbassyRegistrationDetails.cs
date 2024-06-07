using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BusinessEntityLayer
{
    public class BalEmbassyRegistrationDetails
    {


        #region Private Variables

        private string _CountryCode;
        private string _CountryName;
        private string _EmbassyId;
        private string _EmbassyAddress;

        private string _Status;
        private int _CreatedBy;


        #endregion

        #region Public Variables
        public string city { get; set; }
        public string CountryCode
        {
            get
            {
                return _CountryCode;
            }
            set
            {
                _CountryCode = value;
            }
        }

        public string CountryName
        {
            get
            {
                return _CountryName;
            }
            set
            {
                _CountryName = value;
            }
        }

        public string EmbassyId
        {
            get
            {
                return _EmbassyId;
            }
            set
            {
                _EmbassyId = value;
            }
        }

        public string EmbassyAddress
        {
            get
            {
                return _EmbassyAddress;
            }
            set
            {
                _EmbassyAddress = value;
            }
        }

        public string Status
        {
            get
            {
                return _Status;
            }
            set
            {
                _Status = value;
            }
        }

        public int CreatedBy
        {
            get
            {
                return _CreatedBy;
            }
            set
            {
                _CreatedBy = value;
            }
        }

        public string FlagEmbassyAvail { get; set; }

        public string Note { get; set; }



        public string loginid { get; set; }
        public string password { get; set; }
        public string dob { get; set; }
        public string primaryemail { get; set; }
        public string alternateemail { get; set; }
        public string secretquestion { get; set; }
        public string secretquestionanswer { get; set; }
        public string Embassyagentname { get; set; }
        public string fname { get; set; }
        public string mname { get; set; }
        public string lname { get; set; }
        public string pob { get; set; }
        public string sex { get; set; }
        public string maritalstatus { get; set; }
        public string fathername { get; set; }
        public string mothername { get; set; }
        public string nationality { get; set; }
        public string currentaddress { get; set; }
        public string permanentad { get; set; }
        public string passportnumber { get; set; }
        public string passporttype { get; set; }
        public string dateofissue { get; set; }
        public string dateofexpiry { get; set; }
        public string placeofissue { get; set; }
        public string issuingauthority { get; set; }
        public string mobilenumber { get; set; }
        public string landlinenumber { get; set; }
        public string Embassyactivefrom { get; set; }
        public string Embassyactivetill { get; set; }
        public int modifiedby { get; set; }
        public int companyid { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string UserMode { get; set; }


        #endregion


        public DataSet GetEmbassyRegistrationList()
        {
            DataAccessLayer.DalEmbassyRegistrationDetails ObjDalEmbassyRegistrationInfo = null;
            DataSet ds = null;

            try
            {
                ObjDalEmbassyRegistrationInfo = new DataAccessLayer.DalEmbassyRegistrationDetails();
                return ds = ObjDalEmbassyRegistrationInfo.GetEmbassyRegistrationList();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                ObjDalEmbassyRegistrationInfo = null;
            }
        }

        public DataSet Fetch_EmbassyDetail_by_UserId(int EmbassyId)
        {
            DataAccessLayer.DalEmbassyRegistrationDetails ObjDalEmbassyData = null;

            try
            {
                ObjDalEmbassyData = new DataAccessLayer.DalEmbassyRegistrationDetails();
                return ObjDalEmbassyData.Fetch_EmbassyDetail_by_UserId(EmbassyId);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ObjDalEmbassyData = null;

            }
        }

        public int Update_EmbassyDetails()
        {
            DataAccessLayer.DalEmbassyRegistrationDetails ObjDalEmbassyRegistrationDetails = null;

            DataTable dt = null;
            //try
            //{
            ObjDalEmbassyRegistrationDetails = new DataAccessLayer.DalEmbassyRegistrationDetails();
            dt = new DataTable();

            DataRow dr = dt.NewRow();

            // data for UserMaster Table

            //dt.Columns.Add("UserId");
            //dt.Columns.Add("Loginid");
            //dt.Columns.Add("Password");
            //dt.Columns.Add("EmbassyAgentName");
            //dt.Columns.Add("EmailId");
            //dt.Columns.Add("MobileNumber");
            //dt.Columns.Add("LandlineNo");
            dt.Columns.Add("CompanyId");
            //dt.Columns.Add("DateOfBirth");
            dt.Columns.Add("EmbassyActiveFrom");
            dt.Columns.Add("EmbassyActiveTill");
            dt.Columns.Add("CountryCode");
            dt.Columns.Add("CountryName");
            dt.Columns.Add("embassyid");
            dt.Columns.Add("EmbassyAddress");
            dt.Columns.Add("Status");
            dt.Columns.Add("CreatedBy");
            dt.Columns.Add("city");
            dt.Columns.Add("FlagEmbassyAvail");
            dt.Columns.Add("Note");

            //Rows for UserMaster Table

            //dr["UserId"] = this.agentid;
            //dr["Loginid"] = this.loginid;
            //dr["Password"] = this.password;
            //dr["EmbassyAgentName"] = this.Embassyagentname;
            //dr["EmailId"] = this.primaryemail;
            //dr["MobileNumber"] = this.mobilenumber;
            //dr["LandlineNo"] = this.landlinenumber;
            dr["CompanyId"] = this.companyid;
            //dr["DateOfBirth"] = this.dob;
            dr["EmbassyActiveFrom"] = this.Embassyactivefrom;
            dr["EmbassyActiveTill"] = this.Embassyactivetill;
            dr["CountryCode"] = this.CountryCode;
            dr["CountryName"] = this.CountryName;
            dr["embassyid"] = this.embassyid;
            dr["EmbassyAddress"] = this.EmbassyAddress;
            dr["Status"] = this.Status;
            dr["CreatedBy"] = this.CreatedBy;
            dr["city"] = this.city;
            dr["FlagEmbassyAvail"] = this.FlagEmbassyAvail;
            dr["Note"] = this.Note;

            dt.Rows.Add(dr);

            return ObjDalEmbassyRegistrationDetails.Update_EmbassyDetails(dt);
            //}
            //catch (Exception ex)
            //{
            //    throw (ex);
            //}

        }

        public int DeleteDataRow(int keyvalue)
        {
            DataAccessLayer.DalEmbassyRegistrationDetails ObjDalEmbassyRegistrationDetails = null;
            ObjDalEmbassyRegistrationDetails = new DataAccessLayer.DalEmbassyRegistrationDetails();
            return ObjDalEmbassyRegistrationDetails.DeleteDataRow(keyvalue);
        }

        public int Insert_EmbassyDetailsInUserMaster()
        {
            DataAccessLayer.DalEmbassyRegistrationDetails ObjDalEmbassyRegistrationDetails = null;

            DataTable dt = null;
            //try
            //{
            ObjDalEmbassyRegistrationDetails = new DataAccessLayer.DalEmbassyRegistrationDetails();
            dt = new DataTable();

            DataRow dr = dt.NewRow();

            // data for UserMaster Table

            //dt.Columns.Add("UserId");
            //dt.Columns.Add("Loginid");
            //dt.Columns.Add("Password");
            //dt.Columns.Add("EmbassyAgentName");
            //dt.Columns.Add("EmailId");
            //dt.Columns.Add("MobileNumber");
            //dt.Columns.Add("LandlineNo");
            dt.Columns.Add("CompanyId");
            //dt.Columns.Add("DateOfBirth");
            dt.Columns.Add("EmbassyActiveFrom");
            dt.Columns.Add("EmbassyActiveTill");


            //dt.Columns.Add("FirstName");
            //dt.Columns.Add("MiddleName");
            //dt.Columns.Add("LastName");
            //dt.Columns.Add("PrimaryEmail");
            //dt.Columns.Add("AlternateEmail");
            //dt.Columns.Add("SecretQuestion");
            //dt.Columns.Add("SecretQuestionAnswer");
            //dt.Columns.Add("PlaceOfBirth");
            //dt.Columns.Add("Sex");
            //dt.Columns.Add("MaritalStatus");
            //dt.Columns.Add("FatherName");
            //dt.Columns.Add("MotherName");
            //dt.Columns.Add("Nationality");
            //dt.Columns.Add("PassportNumber");
            dt.Columns.Add("CountryCode");
            dt.Columns.Add("CountryName");
            //dt.Columns.Add("EmbassyId");
            dt.Columns.Add("EmbassyAddress");
            dt.Columns.Add("city");
            dt.Columns.Add("Status");
            dt.Columns.Add("CreatedBy");
            dt.Columns.Add("FlagEmbassyAvail");
            dt.Columns.Add("Note");
            //Rows for UserMaster Table

            //dr["UserId"] = this.agentid;
            //dr["Loginid"] = this.loginid;
            //dr["Password"] = this.password;
            //dr["EmbassyAgentName"] = this.Embassyagentname;
            //dr["EmailId"] = this.primaryemail;
            //dr["MobileNumber"] = this.mobilenumber;
            //dr["LandlineNo"] = this.landlinenumber;
            dr["CompanyId"] = this.companyid;
            //dr["DateOfBirth"] = this.dob;
            dr["EmbassyActiveFrom"] = this.Embassyactivefrom;
            dr["EmbassyActiveTill"] = this.Embassyactivetill;

            //dr["FirstName"] = this.fname;
            //dr["MiddleName"] = this.mname;
            //dr["LastName"] = this.lname;
            //dr["PrimaryEmail"] = this.primaryemail;
            //dr["AlternateEmail"] = this.alternateemail;
            //dr["SecretQuestion"] = this.secretquestion;
            //dr["SecretQuestionAnswer"] = this.secretquestionanswer;
            //dr["PlaceOfBirth"] = this.pob;
            //dr["Sex"] = this.sex;
            //dr["MaritalStatus"] = this.maritalstatus;
            //dr["FatherName"] = this.fathername;
            //dr["MotherName"] = this.mothername;
            //dr["Nationality"] = this.nationality;
            //dr["PassportNumber"] = this.passportnumber;
            dr["CountryCode"] = this.CountryCode;
            dr["CountryName"] = this.CountryName;
            //dr["EmbassyId"] = this.EmbassyId;
            dr["EmbassyAddress"] = this.EmbassyAddress;
            dr["city"] = this.city;
            dr["Status"] = this.Status;
            dr["CreatedBy"] = this.CreatedBy;
            dr["FlagEmbassyAvail"] = this.FlagEmbassyAvail;
            dr["Note"] = this.Note;


            dt.Rows.Add(dr);

            return ObjDalEmbassyRegistrationDetails.Insert_EmbassyDetailsInUserMaster(dt);
            //}
            //catch (Exception ex)
            //{
            //    throw (ex);
            //}

        }

        public int EmailHandler()
        {
            int i;

            DataAccessLayer.DalEmbassyRegistrationDetails ObjDalEmbassyRegistrationDetails = null;
            ObjDalEmbassyRegistrationDetails = new DataAccessLayer.DalEmbassyRegistrationDetails();
            i = ObjDalEmbassyRegistrationDetails.SendMailMessage(this.primaryemail, this.Subject, this.Message, this.alternateemail);
            return i;
        }


        public int userid { get; set; }

        public int embassyid { get; set; }

        public int InsertUserRelationWithEmbassy()
        {
            DataAccessLayer.DalEmbassyRegistrationDetails ObjDalEmbassyRegistrationDetails = null;

            DataTable dt = null;
            //try
            //{
            ObjDalEmbassyRegistrationDetails = new DataAccessLayer.DalEmbassyRegistrationDetails();
            dt = new DataTable();

            DataRow dr = dt.NewRow();

            dt.Columns.Add("userid");
            dt.Columns.Add("embassyid");

            dr["userid"] = this.userid;
            dr["embassyid"] = this.embassyid;

            dt.Rows.Add(dr);

            return ObjDalEmbassyRegistrationDetails.InsertUserRelationWithEmbassy(dt);
        }

        public int DeletePrevioususers(int embassyid)
        {
            DataAccessLayer.DalEmbassyRegistrationDetails ObjDalEmbassyRegistrationDetails = null;
            ObjDalEmbassyRegistrationDetails = new DataAccessLayer.DalEmbassyRegistrationDetails();
            return ObjDalEmbassyRegistrationDetails.DeletePrevioususers(embassyid);
        }
    }
}
