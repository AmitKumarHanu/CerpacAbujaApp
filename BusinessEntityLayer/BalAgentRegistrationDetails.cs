using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BusinessEntityLayer
{
    public class BalAgentRegistrationDetails
    {
        
        #region Public Variables

        public int agentid { get; set; }
        public string loginid { get; set; }
        public string password { get; set; }
        public string agentconame { get; set; }
        public string dob { get; set; }
        public string primaryemail { get; set; }
        public string alternateemail { get; set; }
        public string secretquestion { get; set; }
        public string secretquestionanswer { get; set; }
        public string agentname { get; set; }
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
        public string agentactivefrom { get; set; }
        public string agentactivetill { get; set; }
        public string status { get; set; }
        public int createdby { get; set; }
        public int modifiedby { get; set; }
        public int companyid { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string UserMode { get; set; }


        #endregion


        // Inserting agent details in table User Master
        public int Insert_AgentDetailsInUserMaster()
        {
            DataAccessLayer.DalAgentRegistrationDetails ObjDalAgentDetails = null;
            
            DataTable dt = null;
            try
            {
                ObjDalAgentDetails = new DataAccessLayer.DalAgentRegistrationDetails();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

// data for UserMaster Table

            dt.Columns.Add("UserId");
            dt.Columns.Add("Loginid");
            dt.Columns.Add("Password");
            dt.Columns.Add("AgentName");
            dt.Columns.Add("Address");
            dt.Columns.Add("Status");
            dt.Columns.Add("EmailId");
            dt.Columns.Add("CreatedBy");
            dt.Columns.Add("MobileNumber");
            dt.Columns.Add("LandlineNo");
            dt.Columns.Add("CompanyId");
            dt.Columns.Add("DateOfBirth");
            dt.Columns.Add("AgentActiveFrom");
            dt.Columns.Add("AgentActiveTill");
                
// data for AgentRegistration Table

            dt.Columns.Add("FirstName");
            dt.Columns.Add("MiddleName");
            dt.Columns.Add("LastName");
            dt.Columns.Add("CurrentAddress");
            dt.Columns.Add("PermanentAddress");
            dt.Columns.Add("PrimaryEmail");
            dt.Columns.Add("AlternateEmail");
            dt.Columns.Add("AgentCoName");
            dt.Columns.Add("SecretQuestion");
            dt.Columns.Add("SecretQuestionAnswer");
            dt.Columns.Add("PlaceOfBirth");
            dt.Columns.Add("Sex");
            dt.Columns.Add("MaritalStatus");
            dt.Columns.Add("FatherName");
            dt.Columns.Add("MotherName");
            dt.Columns.Add("Nationality");
            dt.Columns.Add("PassportNumber");
            dt.Columns.Add("PassportType");
            dt.Columns.Add("DateOfIssue");
            dt.Columns.Add("DateOfExpiry");
            dt.Columns.Add("PlaceOfIssue");
            dt.Columns.Add("IssuingAuthority");
            

//Rows for UserMaster Table

            dr["UserId"] = this.agentid;
            dr["Loginid"] = this.loginid;
            dr["Password"] = this.password;
            dr["AgentName"] = this.agentname;
            dr["Address"] = this.permanentad;
            dr["Status"] = this.status;
            dr["EmailId"] = this.primaryemail;
            dr["CreatedBy"] = this.createdby;
            dr["MobileNumber"] = this.mobilenumber;
            dr["LandlineNo"] = this.landlinenumber;
            dr["CompanyId"] = this.companyid;
            dr["DateOfBirth"] = this.dob;
            dr["AgentActiveFrom"] = this.agentactivefrom;
            dr["AgentActiveTill"] = this.agentactivetill;
                             

// Rows for AgentRegistration Table

            dr["FirstName"] = this.fname;
            dr["MiddleName"] = this.mname;
            dr["LastName"] = this.lname;
            dr["CurrentAddress"] = this.currentaddress;
            dr["PermanentAddress"] = this.permanentad;
            dr["PrimaryEmail"] = this.primaryemail;
            dr["AlternateEmail"] = this.alternateemail;
            dr["AgentCoName"] = this.agentconame;
            dr["SecretQuestion"] = this.secretquestion;
            dr["SecretQuestionAnswer"] = this.secretquestionanswer;
            dr["PlaceOfBirth"] = this.pob;
            dr["Sex"] = this.sex;
            dr["MaritalStatus"] = this.maritalstatus;
            dr["FatherName"] = this.fathername;
            dr["MotherName"] = this.mothername;
            dr["Nationality"] = this.nationality;
            dr["PassportNumber"] = this.passportnumber;
            dr["PassportType"] = this.passporttype;
            dr["DateOfIssue"] = this.dateofissue;
            dr["DateOfExpiry"] = this.dateofexpiry;
            dr["PlaceOfIssue"] = this.placeofissue;
            dr["IssuingAuthority"] = this.issuingauthority;
            

            dt.Rows.Add(dr);

            return ObjDalAgentDetails.Insert_AgentDetailsInUserMaster(dt);
        }
             catch (Exception ex)
            {
                throw (ex);
            }

        }

        public DataSet Fetch_AgentDetail_by_UserId(int AgentRegistrationId)
        {
            DataAccessLayer.DalAgentRegistrationDetails ObjDalAgentData = null;

            try
            {
                ObjDalAgentData = new DataAccessLayer.DalAgentRegistrationDetails();
                return ObjDalAgentData.Fetch_AgentDetailByUserId(AgentRegistrationId);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ObjDalAgentData = null;

            }
        }


        public int update_agentdetails()
        {
            DataAccessLayer.DalAgentRegistrationDetails ObjDalAgentDetails = null;
            DataTable dt = null;

            try
            {
                ObjDalAgentDetails = new DataAccessLayer.DalAgentRegistrationDetails();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                // data for UserMaster Table

                dt.Columns.Add("Loginid");
                dt.Columns.Add("AgentId");
               // dt.Columns.Add("Password");
                dt.Columns.Add("AgentName");
                dt.Columns.Add("Address");
                dt.Columns.Add("Status");
                dt.Columns.Add("EmailId");
                dt.Columns.Add("ModifiedBy");
                dt.Columns.Add("MobileNumber");
                dt.Columns.Add("LandlineNo");
                dt.Columns.Add("CompanyId");
                dt.Columns.Add("DateOfBirth");
                dt.Columns.Add("AgentActiveFrom");
                dt.Columns.Add("AgentActiveTill");

                // data for AgentRegistration Table

                dt.Columns.Add("FirstName");
                dt.Columns.Add("MiddleName");
                dt.Columns.Add("LastName");
                dt.Columns.Add("CurrentAddress");
                dt.Columns.Add("PermanentAddress");
                dt.Columns.Add("PrimaryEmail");
                dt.Columns.Add("AlternateEmail");
                dt.Columns.Add("AgentCoName");
                dt.Columns.Add("SecretQuestion");
                dt.Columns.Add("SecretQuestionAnswer");
                dt.Columns.Add("PlaceOfBirth");
                dt.Columns.Add("Sex");
                dt.Columns.Add("MaritalStatus");
                dt.Columns.Add("FatherName");
                dt.Columns.Add("MotherName");
                dt.Columns.Add("Nationality");
                dt.Columns.Add("PassportNumber");
                dt.Columns.Add("PassportType");
                dt.Columns.Add("DateOfIssue");
                dt.Columns.Add("DateOfExpiry");
                dt.Columns.Add("PlaceOfIssue");
                dt.Columns.Add("IssuingAuthority");

                


                //Rows for UserMaster Table


                dr["Loginid"] = this.loginid;
                dr["AgentId"] = this.agentid;
                //dr["Password"] = this.password;
                dr["AgentName"] = this.agentname;
                dr["Address"] = this.permanentad;
                dr["Status"] = this.status;
                dr["EmailId"] = this.primaryemail;
                dr["ModifiedBy"] = this.modifiedby;
                dr["MobileNumber"] = this.mobilenumber;
                dr["LandlineNo"] = this.landlinenumber;
                //dr["CompanyId"] = this.companyid;
                dr["DateOfBirth"] = this.dob;
                dr["AgentActiveFrom"] = this.agentactivefrom;
                dr["AgentActiveTill"] = this.agentactivetill;


                // Rows for AgentRegistration Table

                dr["FirstName"] = this.fname;
                dr["MiddleName"] = this.mname;
                dr["LastName"] = this.lname;
                dr["CurrentAddress"] = this.currentaddress;
                dr["PermanentAddress"] = this.permanentad;
                dr["PrimaryEmail"] = this.primaryemail;
                dr["AlternateEmail"] = this.alternateemail;
                dr["AgentCoName"] = this.agentconame;
                dr["SecretQuestion"] = this.secretquestion;
                dr["SecretQuestionAnswer"] = this.secretquestionanswer;
                dr["PlaceOfBirth"] = this.pob;
                dr["Sex"] = this.sex;
                dr["MaritalStatus"] = this.maritalstatus;
                dr["FatherName"] = this.fathername;
                dr["MotherName"] = this.mothername;
                dr["Nationality"] = this.nationality;
                dr["PassportNumber"] = this.passportnumber;
                dr["PassportType"] = this.passporttype;
                dr["DateOfIssue"] = this.dateofissue;
                dr["DateOfExpiry"] = this.dateofexpiry;
                dr["PlaceOfIssue"] = this.placeofissue;
                dr["IssuingAuthority"] = this.issuingauthority;


                dt.Rows.Add(dr);

                return ObjDalAgentDetails.Update_AgentDetailsInUserMaster(dt);

            }
            catch (Exception ex)
            {
                throw (ex);
            }


    }

        public int EmailHandler()
        {
            int i;

            DataAccessLayer.DalAgentRegistrationDetails ObjDalAgentDetails = null;
            ObjDalAgentDetails = new DataAccessLayer.DalAgentRegistrationDetails();
            i = ObjDalAgentDetails.SendMailMessage(this.primaryemail, this.Subject, this.Message, this.alternateemail);
            return i;
        }   

        
        public DataSet GetAgentRegistrationList()
        {
            DataAccessLayer.DalAgentRegistrationDetails ObjDalAgentRegistrationInfo = null;
            DataSet ds = null;

            try
            {
                ObjDalAgentRegistrationInfo = new DataAccessLayer.DalAgentRegistrationDetails();
                return ds = ObjDalAgentRegistrationInfo.GetAgentRegistrationList();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                ObjDalAgentRegistrationInfo = null;
            }
        }

        public int DeleteDataRow(int keyvalue)
        {
            DataAccessLayer.DalAgentRegistrationDetails ObjDalAgentRegistrationDetails = null;
            ObjDalAgentRegistrationDetails = new DataAccessLayer.DalAgentRegistrationDetails();
            return ObjDalAgentRegistrationDetails.DeleteDataRow(keyvalue);
        }
    }
  
}
