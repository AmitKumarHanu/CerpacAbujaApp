using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Web;


namespace DataAccessLayer
{
    public class DalApplicantRegist
    {
        private static char[] charSeparators = new char[] { };
        private static String[] result;

        #region InsertApplicantRegister

        public int InsertApplicantRegister(DataTable dt)
        {
            SqlParameter[] pram = null;
            //try
            //{
            pram = new SqlParameter[86];
            pram[0] = new SqlParameter("@Password", dt.Rows[0]["Password"]);
            pram[1] = new SqlParameter("@PrimaryEmail", dt.Rows[0]["PrimaryEmail"]);
            pram[2] = new SqlParameter("@AlternateEmail", dt.Rows[0]["AlternateEmail"]);
            pram[3] = new SqlParameter("@SecretQuestion", dt.Rows[0]["SecretQuestion"]);
            pram[4] = new SqlParameter("@SecretQueAnswer", dt.Rows[0]["SecretQueAnswer"]);
            pram[5] = new SqlParameter("@FirstName", dt.Rows[0]["FirstName"]);
            pram[6] = new SqlParameter("@MiddleName", dt.Rows[0]["MiddleName"]);
            pram[7] = new SqlParameter("@LastName", dt.Rows[0]["LastName"]);
            pram[8] = new SqlParameter("@DateOfBirth", dt.Rows[0]["DateOfBirth"]);
            pram[9] = new SqlParameter("@PlaceOfBirth", dt.Rows[0]["PlaceOfBirth"]);
            pram[10] = new SqlParameter("@Sex", dt.Rows[0]["Sex"]);
            pram[11] = new SqlParameter("@MaritalStatus", dt.Rows[0]["MaritalStatus"]);
            pram[12] = new SqlParameter("@FatherName", dt.Rows[0]["FatherName"]);
            pram[13] = new SqlParameter("@MotherName", dt.Rows[0]["MotherName"]);
            pram[14] = new SqlParameter("@Nationality", dt.Rows[0]["Nationality"]);
            pram[15] = new SqlParameter("@CurrentAddress", dt.Rows[0]["CurrentAddress"]);
            pram[16] = new SqlParameter("@PermanentAddress", dt.Rows[0]["PermanentAddress"]);
            pram[17] = new SqlParameter("@PassportNo", dt.Rows[0]["PassportNo"]);
            pram[18] = new SqlParameter("@PassportType", dt.Rows[0]["PassportType"]);
            pram[19] = new SqlParameter("@DateOfIssue", dt.Rows[0]["DateOfIssue"]);
            pram[20] = new SqlParameter("@DateOfExpiry", dt.Rows[0]["DateOfExpiry"]);
            pram[21] = new SqlParameter("@PlaceOfIssue", dt.Rows[0]["PlaceOfIssue"]);
            pram[22] = new SqlParameter("@IssuingAuthority", dt.Rows[0]["IssuingAuthority"]);
            pram[23] = new SqlParameter("@MobileNumber", dt.Rows[0]["MobileNumber"]);
            pram[24] = new SqlParameter("@LandlinePhone", dt.Rows[0]["LandlinePhone"]);
            pram[25] = new SqlParameter("@LoginID", dt.Rows[0]["LoginID"]);
            pram[26] = new SqlParameter("@UserIPAddress", dt.Rows[0]["UserIPAddress"]);
            //pram[27] = new SqlParameter("@CreatedBy", dt.Rows[0]["CreatedBy"]);
            //pram[28] = new SqlParameter("@ModifiedBy", dt.Rows[0]["ModifiedBy"]);
            pram[27] = new SqlParameter("@Companyid", dt.Rows[0]["CompanyID"]);
            pram[28] = new SqlParameter("@Groupid", dt.Rows[0]["GrpID"]);
            pram[29] = new SqlParameter("@Uniquecode", dt.Rows[0]["UniqueCode"]);
            pram[30] = new SqlParameter("@Photo", dt.Rows[0]["Photo"]);
            pram[31] = new SqlParameter("@ColorHair", dt.Rows[0]["ColorHair"]);
            pram[32] = new SqlParameter("@ColorEye", dt.Rows[0]["ColorEye"]);
            pram[33] = new SqlParameter("@IndentityMark", dt.Rows[0]["IndentityMark"]);
            pram[34] = new SqlParameter("@Height", dt.Rows[0]["Height"]);
            pram[35] = new SqlParameter("@InMilitary", dt.Rows[0]["InMilitary"]);
            pram[36] = new SqlParameter("@FromDate", dt.Rows[0]["FromDate"]);
            pram[37] = new SqlParameter("@ToDate", dt.Rows[0]["ToDate"]);
            pram[38] = new SqlParameter("@EmpName", dt.Rows[0]["EmpName"]);
            pram[39] = new SqlParameter("@EmpPhoneNo", dt.Rows[0]["EmpPhoneNo"]);
            pram[40] = new SqlParameter("@EmpLivedFrom", dt.Rows[0]["EmpLivedFrom"]);
            pram[41] = new SqlParameter("@Address1", dt.Rows[0]["Address1"]);
            pram[42] = new SqlParameter("@Address2", dt.Rows[0]["Address2"]);
            pram[43] = new SqlParameter("@EmpCity", dt.Rows[0]["EmpCity"]);
            pram[44] = new SqlParameter("@EmpState", dt.Rows[0]["EmpState"]);
            pram[45] = new SqlParameter("@EmpPostCode", dt.Rows[0]["EmpPostCode"]);
            pram[46] = new SqlParameter("@IntedAddress1", dt.Rows[0]["IntedAddress1"]);
            pram[47] = new SqlParameter("@IntedAddress2", dt.Rows[0]["IntedAddress2"]);
            pram[48] = new SqlParameter("@IntedCity", dt.Rows[0]["IntedCity"]);
            pram[49] = new SqlParameter("@IntedState", dt.Rows[0]["IntedState"]);
            pram[50] = new SqlParameter("@IntedDistrict", dt.Rows[0]["IntedDistrict"]);
            pram[51] = new SqlParameter("@IntedPostcode", dt.Rows[0]["IntedPostcode"]);
            pram[52] = new SqlParameter("@ApplyCountryYears", dt.Rows[0]["ApplyCountryYears"]);
            pram[53] = new SqlParameter("@FlagSeriousDisease", dt.Rows[0]["FlagSeriousDisease"]);
            pram[54] = new SqlParameter("@FlagCrimeRecord", dt.Rows[0]["FlagCrimeRecord"]);
            pram[55] = new SqlParameter("@FlagDrugReport", dt.Rows[0]["FlagDrugReport"]);
            pram[56] = new SqlParameter("@FlagDeported", dt.Rows[0]["FlagDeported"]);
            pram[57] = new SqlParameter("@FlagFraudRecord", dt.Rows[0]["FlagFraudRecord"]);

            //insert data to last visited countries details 
            pram[58] = new SqlParameter("@CountryCode1", dt.Rows[0]["CountryCode1"]);
            pram[59] = new SqlParameter("@CityName1", dt.Rows[0]["CityName1"]);
            pram[60] = new SqlParameter("@DepartureDate1", dt.Rows[0]["DepartureDate1"]);
            pram[61] = new SqlParameter("@CountryCode2", dt.Rows[0]["CountryCode2"]);
            pram[62] = new SqlParameter("@CityName2", dt.Rows[0]["CityName2"]);
            pram[63] = new SqlParameter("@DepartureDate2", dt.Rows[0]["DepartureDate2"]);
            pram[64] = new SqlParameter("@CountryCode3", dt.Rows[0]["CountryCode3"]);
            pram[65] = new SqlParameter("@CityName3", dt.Rows[0]["CityName3"]);
            pram[66] = new SqlParameter("@DepartureDate3", dt.Rows[0]["DepartureDate3"]);

            //insert data to last lived countries details 
            pram[67] = new SqlParameter("@LastLivedCountryCode1", dt.Rows[0]["LastLivedCountryCode1"]);
            pram[68] = new SqlParameter("@LastLivedCityName1", dt.Rows[0]["LastLivedCityName1"]);
            pram[69] = new SqlParameter("@LastLivedDepartureDate1", dt.Rows[0]["LastLivedDepartureDate1"]);
            pram[70] = new SqlParameter("@LastLivedCountryCode2", dt.Rows[0]["LastLivedCountryCode2"]);
            pram[71] = new SqlParameter("@LastLivedCityName2", dt.Rows[0]["LastLivedCityName2"]);
            pram[72] = new SqlParameter("@LastLivedDepartureDate2", dt.Rows[0]["LastLivedDepartureDate2"]);
            pram[73] = new SqlParameter("@LastLivedCountryCode3", dt.Rows[0]["LastLivedCountryCode3"]);
            pram[74] = new SqlParameter("@LastLivedCityName3", dt.Rows[0]["LastLivedCityName3"]);
            pram[75] = new SqlParameter("@LastLivedDepartureDate3", dt.Rows[0]["LastLivedDepartureDate3"]);

            pram[76] = new SqlParameter("@OtherName", dt.Rows[0]["OtherName"]);

            pram[77] = new SqlParameter("@FatherLastName", dt.Rows[0]["FatherLastName"]);
            pram[78] = new SqlParameter("@FatherDateOfBirth", dt.Rows[0]["FatherDateOfBirth"]);
            pram[79] = new SqlParameter("@FatherAddress", dt.Rows[0]["FatherAddress"]);
            pram[80] = new SqlParameter("@FatherNationality", dt.Rows[0]["FatherNationality"]);

            pram[81] = new SqlParameter("@MotherLastName", dt.Rows[0]["MotherLastName"]);
            pram[82] = new SqlParameter("@MotherDateOfBirth", dt.Rows[0]["MotherDateOfBirth"]);
            pram[83] = new SqlParameter("@MotherAddress", dt.Rows[0]["MotherAddress"]);
            pram[84] = new SqlParameter("@MotherNationality", dt.Rows[0]["MotherNationality"]);
           // pram[85] = new SqlParameter("@bphoto", System.Data.SqlDbType.Image,,dt.Rows[0]["bphoto"]);
            pram[85] = new SqlParameter("@SuccessId", 1);
            pram[85].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_APPLICATION_REGISTRATION_INSERT", pram);
            return (int.Parse(pram[85].Value.ToString()));
            //}
            //catch (Exception ex)
            //{
            //    throw (ex);
            //}
            //finally
            //{
            //    pram = null;

            //}
        }
        #endregion


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

        public int SendMailMessage(string PrimaryEmail, string Subject, string Message, string AlternateEmail, string sAttachment)
        {
            int Status;
            try
            {
                MailAddress From = new System.Net.Mail.MailAddress(System.Configuration.ConfigurationSettings.AppSettings["Email.Sender"]);
                string smtpHost = System.Configuration.ConfigurationSettings.AppSettings["Email.Smtp"].ToString();
                string sAttachmentFilesPath = System.Configuration.ConfigurationSettings.AppSettings["PDFPath"].ToString();
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
                Attachment objAttachment = new Attachment(sAttachmentFilesPath + sAttachment);
                mailMsg.Attachments.Add(objAttachment);
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


        //=========================================by chitresh latest=============================================

        public int CompanyRegistration(DataTable dt)
        {
            SqlParameter[] pram = null;
            //try
            //{
            pram = new SqlParameter[16];
            pram[0] = new SqlParameter("@Password", dt.Rows[0]["Password"]);
            pram[1] = new SqlParameter("@PrimaryEmail", dt.Rows[0]["PrimaryEmail"]);
            pram[2] = new SqlParameter("@AlternateEmail", dt.Rows[0]["AlternateEmail"]);
            pram[3] = new SqlParameter("@LoginID", dt.Rows[0]["LoginID"]);
            pram[4] = new SqlParameter("@Companyname", dt.Rows[0]["Companyname"]);
            pram[5] = new SqlParameter("@Directorname", dt.Rows[0]["Directorname"]);
            pram[6] = new SqlParameter("@Address", dt.Rows[0]["Address"]);
            pram[7] = new SqlParameter("@Phoneno", dt.Rows[0]["Phoneno"]);
            pram[8] = new SqlParameter("@Contactperson", dt.Rows[0]["Contactperson"]);
            pram[9] = new SqlParameter("@DateofIncorporation", dt.Rows[0]["DateofIncorporation"]);
            pram[10] = new SqlParameter("@Designation", dt.Rows[0]["Designation"]);
            pram[11] = new SqlParameter("@MobileNo", dt.Rows[0]["MobileNo"]);
            pram[12] = new SqlParameter("@UniqueCode", dt.Rows[0]["UniqueCode"]);
            pram[13] = new SqlParameter("@userid", dt.Rows[0]["userid"]);
            pram[14] = new SqlParameter("@docofincorporation", dt.Rows[0]["docofincorporation"]);
            pram[15] = new SqlParameter("@SuccessId", 1);
            pram[15].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_COMPANY_REGISTRATION_INSERT", pram);
            return (int.Parse(pram[15].Value.ToString()));
        }

        //===========================================end==============================================

    }
}
