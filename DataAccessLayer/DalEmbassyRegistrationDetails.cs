using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;

namespace DataAccessLayer
{
    public class DalEmbassyRegistrationDetails
    {
        private static char[] charSeparators = new char[] { };
        private static String[] result;

        public DataSet GetEmbassyRegistrationList()
        {
            DataSet ds = null;

            try
            {
                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, "UspEmbassyRegistrationFetchList");
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

        public int Update_EmbassyDetails(DataTable dt)
        {
            SqlParameter[] pram = null;
            //try
            //{
            pram = new SqlParameter[20];


            //For UserMAster Table
            //pram[0] = new SqlParameter("@loginid", dt.Rows[0]["Loginid"]);
            //pram[1] = new SqlParameter("@Password", dt.Rows[0]["Password"]);
            //pram[2] = new SqlParameter("@EmbassyAgentName", dt.Rows[0]["EmbassyAgentName"]);
            //pram[3] = new SqlParameter("@DateOfBirth", dt.Rows[0]["DateOfBirth"]);
            //pram[4] = new SqlParameter("@MobileNumber", dt.Rows[0]["MobileNumber"]);
            //pram[5] = new SqlParameter("@LandlineNumber", dt.Rows[0]["LandlineNo"]);
            //pram[6] = new SqlParameter("@EmailId", dt.Rows[0]["EmailId"]);
            pram[7] = new SqlParameter("@Companyid", dt.Rows[0]["CompanyId"]);
            pram[8] = new SqlParameter("@EmbassyActiveFrom", dt.Rows[0]["EmbassyActiveFrom"]);
            pram[9] = new SqlParameter("@EmbassyActiveTill", dt.Rows[0]["EmbassyActiveTill"]);
            pram[10] = new SqlParameter("@CountryCode", dt.Rows[0]["CountryCode"]);
            pram[11] = new SqlParameter("@CountryName", dt.Rows[0]["CountryName"]);
            pram[12] = new SqlParameter("@EmbassyId", dt.Rows[0]["EmbassyId"]);
            pram[13] = new SqlParameter("@EmbassyAddress", dt.Rows[0]["EmbassyAddress"]);
            pram[14] = new SqlParameter("@Status", dt.Rows[0]["Status"]);
            pram[15] = new SqlParameter("@CreatedBy", dt.Rows[0]["CreatedBy"]);

            pram[16] = new SqlParameter("@city", dt.Rows[0]["city"]);
            pram[17] = new SqlParameter("@FlagEmbassyAvail", dt.Rows[0]["FlagEmbassyAvail"]);
            pram[18] = new SqlParameter("@Note", dt.Rows[0]["Note"]);

            pram[19] = new SqlParameter("@SuccessId", 1);

            pram[19].Direction = ParameterDirection.Output;


            SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "Usp_UpdateEmbassyRegistrationUserMasterInsert", pram);
            //int SuccessId = int.Parse(pram[31].Value.ToString());
            //int UserId = int.Parse(pram[10].Value.ToString());
            return (int.Parse(pram[19].Value.ToString()));
            //if (UserId !=-1)
            //{

            //    return UserId;
            //}
            //else
            //{
            //    return -1;
            //}
            //}
            //catch (Exception ex)
            //{
            //    throw (ex);
            //}

        }

        public DataSet Fetch_EmbassyDetail_by_UserId(int EmbassyId)
        {
            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@EmbassyId", EmbassyId);
                //pram[1] = new SqlParameter("@UserId", UserId);

                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspUserMasterEmbassyRegistrationFetchByEmbassyId", pram);
                //objDs.Tables[0].TableName = "EmbassyRegistration";
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

        public int DeleteDataRow(int keyvalue)
        {
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[2];
                pram[0] = new SqlParameter("@EmbassyId", keyvalue);
                //pram[1] = new SqlParameter("@UserId", UserId);
                pram[1] = new SqlParameter("@SuccessId", 1);
                pram[1].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspEmbassyRegistrationMasterDelete", pram);
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

        public int Insert_EmbassyDetailsInUserMaster(DataTable dt)
        {
            SqlParameter[] pram = null;
            //try
            //{
            pram = new SqlParameter[13];


            //For UserMAster Table
            //pram[0] = new SqlParameter("@loginid", dt.Rows[0]["Loginid"]);
            //pram[1] = new SqlParameter("@Password", dt.Rows[0]["Password"]);
            //pram[2] = new SqlParameter("@EmbassyAgentName", dt.Rows[0]["EmbassyAgentName"]);
            //pram[3] = new SqlParameter("@DateOfBirth", dt.Rows[0]["DateOfBirth"]);
            //pram[4] = new SqlParameter("@MobileNumber", dt.Rows[0]["MobileNumber"]);
            //pram[5] = new SqlParameter("@LandlineNumber", dt.Rows[0]["LandlineNo"]);
            //pram[6] = new SqlParameter("@EmailId", dt.Rows[0]["EmailId"]);
            pram[1] = new SqlParameter("@Companyid", dt.Rows[0]["CompanyId"]);
            pram[2] = new SqlParameter("@EmbassyActiveFrom", dt.Rows[0]["EmbassyActiveFrom"]);
            pram[3] = new SqlParameter("@EmbassyActiveTill", dt.Rows[0]["EmbassyActiveTill"]);

            //pram[10] = new SqlParameter("@PrimaryEmail", dt.Rows[0]["PrimaryEmail"]);
            //pram[11] = new SqlParameter("@AlternateEmail", dt.Rows[0]["AlternateEmail"]);
            //pram[12] = new SqlParameter("@SecretQuestion", dt.Rows[0]["SecretQuestion"]);
            //pram[13] = new SqlParameter("@SecretQuestionAnswer", dt.Rows[0]["SecretQuestionAnswer"]);
            //pram[14] = new SqlParameter("@FirstName", dt.Rows[0]["FirstName"]);
            //pram[15] = new SqlParameter("@MiddleName", dt.Rows[0]["MiddleName"]);
            //pram[16] = new SqlParameter("@LastName", dt.Rows[0]["LastName"]);
            //pram[17] = new SqlParameter("@PlaceOfBirth", dt.Rows[0]["PlaceOfBirth"]);
            //pram[18] = new SqlParameter("@Sex", dt.Rows[0]["Sex"]);
            //pram[19] = new SqlParameter("@MaritalStatus", dt.Rows[0]["MaritalStatus"]);
            //pram[20] = new SqlParameter("@FatherName", dt.Rows[0]["FatherName"]);
            //pram[21] = new SqlParameter("@MotherName", dt.Rows[0]["MotherName"]);
            //pram[22] = new SqlParameter("@Nationality", dt.Rows[0]["Nationality"]);
            //pram[23] = new SqlParameter("@PassportNumber", dt.Rows[0]["PassportNumber"]);
            pram[4] = new SqlParameter("@CountryCode", dt.Rows[0]["CountryCode"]);
            pram[5] = new SqlParameter("@CountryName", dt.Rows[0]["CountryName"]);
            //pram[6] = new SqlParameter("@EmbassyId", dt.Rows[0]["EmbassyId"]);
            pram[6] = new SqlParameter("@EmbassyAddress", dt.Rows[0]["EmbassyAddress"]);
            pram[7] = new SqlParameter("@Status", dt.Rows[0]["Status"]);
            pram[8] = new SqlParameter("@CreatedBy", dt.Rows[0]["CreatedBy"]);
            pram[9] = new SqlParameter("@city", dt.Rows[0]["city"]);
            pram[10] = new SqlParameter("@FlagEmbassyAvail", dt.Rows[0]["FlagEmbassyAvail"]);
            pram[11] = new SqlParameter("@Note", dt.Rows[0]["Note"]);

            pram[12] = new SqlParameter("@SuccessId", 1);


            pram[12].Direction = ParameterDirection.Output;


            SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspEmbassyRegistrationToUserMasterInsert", pram);
            //int SuccessId = int.Parse(pram[31].Value.ToString());
            //int UserId = int.Parse(pram[10].Value.ToString());
            return (int.Parse(pram[12].Value.ToString()));
            //if (UserId !=-1)
            //{

            //    return UserId;
            //}
            //else
            //{
            //    return -1;
            //}
            //}
            //catch (Exception ex)
            //{
            //    throw (ex);
            //}

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

        public int InsertUserRelationWithEmbassy(DataTable dt)
        {
            SqlParameter[] pram = null;
            //try
            //{
            pram = new SqlParameter[3];


            //For UserMAster Table
            pram[0] = new SqlParameter("@UserID", dt.Rows[0]["userid"]);
            pram[1] = new SqlParameter("@EmbassyId", dt.Rows[0]["embassyid"]);

            pram[2] = new SqlParameter("@SuccessId", 1);


            pram[2].Direction = ParameterDirection.Output;


            SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspEmbassyUserRelationInsert", pram);
            //int SuccessId = int.Parse(pram[31].Value.ToString());
            //int UserId = int.Parse(pram[10].Value.ToString());
            return (int.Parse(pram[2].Value.ToString()));

        }

        public int DeletePrevioususers(int embassyid)
        {

            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[2];
                pram[0] = new SqlParameter("@EmbassyId", embassyid);
                //pram[1] = new SqlParameter("@UserId", UserId);
                pram[1] = new SqlParameter("@SuccessId", 1);
                pram[1].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspEmbassyUsersDeleteForUpdate", pram);
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
    }
}
