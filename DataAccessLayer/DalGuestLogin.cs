using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;

namespace DataAccessLayer
{
    public class DalGuestLogin
    {
        private static char[] charSeparators = new char[] { };
        private static String[] result;


        #region InsertGuestRegister

        public int InsertGuestRegister(DataTable dt)
        {
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[11];
               
                pram[0] = new SqlParameter("@EmailId", dt.Rows[0]["EmailId"]);                
                pram[1] = new SqlParameter("@Password", dt.Rows[0]["Password"]);               
          
                pram[2] = new SqlParameter("@LoginID", dt.Rows[0]["LoginID"]);
                pram[3] = new SqlParameter("@UserIPAddress", dt.Rows[0]["UserIPAddress"]);
                //pram[4] = new SqlParameter("@CreatedBy", dt.Rows[0]["CreatedBy"]);
                //pram[5] = new SqlParameter("@ModifiedBy", dt.Rows[0]["ModifiedBy"]);
                pram[6] = new SqlParameter("@Companyid", dt.Rows[0]["CompanyID"]);
                pram[7] = new SqlParameter("@Groupid", dt.Rows[0]["GrpID"]);
                pram[8] = new SqlParameter("@Uniquecode", dt.Rows[0]["UniqueCode"]);
                pram[9] = new SqlParameter("@SuccessId", 1);
                pram[9].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_GUEST_REGISTRATION_INSERT", pram);
                return (int.Parse(pram[9].Value.ToString()));
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
        #endregion

        public int SendMailMessage(string EmailId, string Subject, string Message)
        {
            int Status;
            try
            {

                MailAddress From = new System.Net.Mail.MailAddress(System.Configuration.ConfigurationSettings.AppSettings["Email.Sender"]);
                string smtpHost = System.Configuration.ConfigurationSettings.AppSettings["Email.Smtp"].ToString();
                MailMessage mailMsg = new MailMessage();
                result = EmailId.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
                for (int count = 0; count < result.Length; count++)
                { mailMsg.To.Add(new MailAddress(result[count])); }

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

