using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;

namespace DataAccessLayer
{
    public class DalAgentRegistrationDetails
    {
        private static char[] charSeparators = new char[] { };
        private static String[] result;

        public DataSet GetAgentRegistrationList()
        {
            DataSet ds = null;

            try
            {
                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, "UspAgentRegistrationFetchList");
                return ds;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ds = null;
            }

        }

        public DataSet Fetch_AgentDetailByUserId(int AgentRegistrationId)
        {
            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@AgentId", AgentRegistrationId);

                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspUserMasterAgentRegistrationFetchByAgentId", pram);
                objDs.Tables[0].TableName = "UserMaster";
                //objDs.Tables[1].TableName = "UserCountryRelation";
                //objDs.Tables[2].TableName = "UserVisaTypeRelation";
                return objDs;


            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                pram = null;
                objDs = null;
            }
        }

        public int Insert_AgentDetailsInUserMaster(DataTable dt)
        {
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[34];


                //For UserMAster Table
                pram[0] = new SqlParameter("@loginid", dt.Rows[0]["Loginid"]);
                pram[1] = new SqlParameter("@Password", dt.Rows[0]["Password"]);
                pram[2] = new SqlParameter("@AgentName", dt.Rows[0]["AgentName"]);
                pram[3] = new SqlParameter("@DateOfBirth", dt.Rows[0]["DateOfBirth"]);
                pram[4] = new SqlParameter("@Address", dt.Rows[0]["Address"]);
                pram[5] = new SqlParameter("@LandlineNumber", dt.Rows[0]["LandlineNo"]);
                pram[6] = new SqlParameter("@Status", dt.Rows[0]["Status"]);
                pram[7] = new SqlParameter("@EmailId", dt.Rows[0]["EmailId"]);
                pram[8] = new SqlParameter("@CreatedBy", dt.Rows[0]["CreatedBy"]);
                pram[9] = new SqlParameter("@Companyid", dt.Rows[0]["CompanyId"]);
                pram[10] = new SqlParameter("@AgentActiveFrom",dt.Rows[0]["AgentActiveFrom"]);
                pram[11] = new SqlParameter("@AgentActiveTill", dt.Rows[0]["AgentActiveTill"]); 



                //For AgentRegistration Table
                pram[12] = new SqlParameter("@AgentCoName", dt.Rows[0]["AgentCoName"]);
                pram[13] = new SqlParameter("@AlternateEmail", dt.Rows[0]["AlternateEmail"]);
                pram[14] = new SqlParameter("@SecretQuestion", dt.Rows[0]["SecretQuestion"]);
                pram[15] = new SqlParameter("@SecretQuestionAnswer", dt.Rows[0]["SecretQuestionAnswer"]);
                pram[16] = new SqlParameter("@FirstName", dt.Rows[0]["FirstName"]);
                pram[17] = new SqlParameter("@MiddleName", dt.Rows[0]["MiddleName"]);
                pram[18] = new SqlParameter("@LastName", dt.Rows[0]["LastName"]);
                pram[19] = new SqlParameter("@PlaceOfBirth", dt.Rows[0]["PlaceOfBirth"]);
                pram[20] = new SqlParameter("@Sex", dt.Rows[0]["Sex"]);
                pram[21] = new SqlParameter("@MaritalStatus", dt.Rows[0]["MaritalStatus"]);
                pram[22] = new SqlParameter("@FatherName", dt.Rows[0]["FatherName"]);
                pram[23] = new SqlParameter("@MotherName", dt.Rows[0]["MotherName"]);
                pram[24] = new SqlParameter("@Nationality", dt.Rows[0]["Nationality"]);
                pram[25] = new SqlParameter("@CurrentAddress", dt.Rows[0]["CurrentAddress"]);
                pram[26] = new SqlParameter("@PassportNumber", dt.Rows[0]["PassportNumber"]);
                pram[27] = new SqlParameter("@PassportType", dt.Rows[0]["PassportType"]);
                pram[28] = new SqlParameter("@DateOfIssue", dt.Rows[0]["DateOfIssue"]);
                pram[29] = new SqlParameter("@DateOfExpiry", dt.Rows[0]["DateOfExpiry"]);
                pram[30] = new SqlParameter("@PlaceOfIssue", dt.Rows[0]["PlaceOfIssue"]);
                pram[31] = new SqlParameter("@IssuingAuthority", dt.Rows[0]["IssuingAuthority"]);
                pram[32] = new SqlParameter("@MobileNumber", dt.Rows[0]["MobileNumber"]);


                pram[33] = new SqlParameter("@SuccessId", 1);


                pram[33].Direction = ParameterDirection.Output;


                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspAgentToUserMasterInsert", pram);
                //int SuccessId = int.Parse(pram[31].Value.ToString());
                //int UserId = int.Parse(pram[10].Value.ToString());
                return (int.Parse(pram[33].Value.ToString()));
                //if (UserId !=-1)
                //{

                //    return UserId;
                //}
                //else
                //{
                //    return -1;
                //}
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public int Update_AgentDetailsInUserMaster(DataTable dt)
        {
            SqlParameter[] pram = null;

          try
            {
                pram = new SqlParameter[33];


                //For UserMAster Table
                pram[0] = new SqlParameter("@loginid", dt.Rows[0]["Loginid"]);
                //pram[1] = new SqlParameter("@Password", dt.Rows[0]["Password"]);
                pram[1] = new SqlParameter("@AgentName", dt.Rows[0]["AgentName"]);
                pram[2] = new SqlParameter("@DateOfBirth", dt.Rows[0]["DateOfBirth"]);
                pram[3] = new SqlParameter("@Address", dt.Rows[0]["Address"]);
                pram[4] = new SqlParameter("@LandlineNumber", dt.Rows[0]["LandlineNo"]);
                pram[5] = new SqlParameter("@Status", dt.Rows[0]["Status"]);
                pram[6] = new SqlParameter("@EmailId", dt.Rows[0]["EmailId"]);
                pram[7] = new SqlParameter("@ModifiedBy", dt.Rows[0]["ModifiedBy"]);
                //pram[8] = new SqlParameter("@Companyid", dt.Rows[0]["CompanyId"]);
                pram[8] = new SqlParameter("@AgentActiveFrom",dt.Rows[0]["AgentActiveFrom"]);
                pram[9] = new SqlParameter("@AgentActiveTill", dt.Rows[0]["AgentActiveTill"]); 



                //For AgentRegistration Table
                pram[10] = new SqlParameter("@AgentCoName", dt.Rows[0]["AgentCoName"]);
                pram[11] = new SqlParameter("@AlternateEmail", dt.Rows[0]["AlternateEmail"]);
                pram[12] = new SqlParameter("@SecretQuestion", dt.Rows[0]["SecretQuestion"]);
                pram[13] = new SqlParameter("@SecretQuestionAnswer", dt.Rows[0]["SecretQuestionAnswer"]);
                pram[14] = new SqlParameter("@FirstName", dt.Rows[0]["FirstName"]);
                pram[15] = new SqlParameter("@MiddleName", dt.Rows[0]["MiddleName"]);
                pram[16] = new SqlParameter("@LastName", dt.Rows[0]["LastName"]);
                pram[17] = new SqlParameter("@PlaceOfBirth", dt.Rows[0]["PlaceOfBirth"]);
                pram[18] = new SqlParameter("@Sex", dt.Rows[0]["Sex"]);
                pram[19] = new SqlParameter("@MaritalStatus", dt.Rows[0]["MaritalStatus"]);
                pram[20] = new SqlParameter("@FatherName", dt.Rows[0]["FatherName"]);
                pram[21] = new SqlParameter("@MotherName", dt.Rows[0]["MotherName"]);
                pram[22] = new SqlParameter("@Nationality", dt.Rows[0]["Nationality"]);
                pram[23] = new SqlParameter("@CurrentAddress", dt.Rows[0]["CurrentAddress"]);
                pram[24] = new SqlParameter("@PassportNumber", dt.Rows[0]["PassportNumber"]);
                pram[25] = new SqlParameter("@PassportType", dt.Rows[0]["PassportType"]);
                pram[26] = new SqlParameter("@DateOfIssue", dt.Rows[0]["DateOfIssue"]);
                pram[27] = new SqlParameter("@DateOfExpiry", dt.Rows[0]["DateOfExpiry"]);
                pram[28] = new SqlParameter("@PlaceOfIssue", dt.Rows[0]["PlaceOfIssue"]);
                pram[29] = new SqlParameter("@IssuingAuthority", dt.Rows[0]["IssuingAuthority"]);
                pram[30] = new SqlParameter("@MobileNumber", dt.Rows[0]["MobileNumber"]);
                pram[31] = new SqlParameter("@UserId", dt.Rows[0]["AgentId"]);

                pram[32] = new SqlParameter("@SuccessId", 1);


                pram[32].Direction = ParameterDirection.Output;


                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspUserMaster_AgentRegistration_Update", pram);
                //int SuccessId = int.Parse(pram[31].Value.ToString());
                //int UserId = int.Parse(pram[10].Value.ToString());
                return (int.Parse(pram[32].Value.ToString()));
                //if (UserId !=-1)
                //{

                //    return UserId;
                //}
                //else
                //{
                //    return -1;
                //}
            }
            catch (Exception ex)
            {
                throw (ex);
            }


        }

        public int DeleteDataRow(int keyvalue)
        {
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[2];
                pram[0] = new SqlParameter("@UserId", keyvalue);
                pram[1] = new SqlParameter("@SuccessId", 1);
                pram[1].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspAgentRegistrationMasterActiveInactive", pram);
                return int.Parse(pram[1].Value.ToString());

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                pram = null;
            }

        }

        public int SendMailMessage(string PrimaryEmail, string Subject, string Message, string AlternateEmail)
        {
            int Status;
            try
            {

                MailAddress From = new System.Net.Mail.MailAddress(System.Configuration.ConfigurationSettings.AppSettings["Email.Sender"]);
                string smtpHost = System.Configuration.ConfigurationSettings.AppSettings["Email.Smtp"].ToString();
                MailMessage mailMsg = new MailMessage();
                result = PrimaryEmail.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
                for (int count = 0; count < result.Length; count++)
                { mailMsg.To.Add(new MailAddress(result[count])); }
                if (AlternateEmail != "")
                {
                    mailMsg.CC.Add(AlternateEmail);
                }
                mailMsg.From = From;
                mailMsg.Subject = Subject;
                mailMsg.IsBodyHtml = true;
                mailMsg.BodyEncoding = System.Text.Encoding.UTF8;
                mailMsg.Body = "<html><body>" + Message + "</body></html>";



                SmtpClient smtpClient = new SmtpClient(smtpHost);

                smtpClient.Send(mailMsg);

                mailMsg.Dispose();
                Status = 1;

            }
            catch (Exception exc)
            {

                throw exc;

                Status = 0;
            }
            return Status;

        }

    }
}


