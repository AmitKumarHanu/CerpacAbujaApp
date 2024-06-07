using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;
using System.Data.SqlClient;
using System.Net.Mail;


namespace DataAccessLayer
{
    public class DalBankRegDetails
    {
        public int BankRegistration(string BankLoginid, string BankName, string Password, string BranchName, string BankAddress, string Email, string city, string country,string contact_person, string contact_person_email,string contact_person_mobile)
        {
            SqlParameter[] pram = null;
            //try
            //{
            pram = new SqlParameter[86];
            pram[0] = new SqlParameter("@BankId", BankLoginid);
            pram[1] = new SqlParameter("@BankName", BankName);
            pram[2] = new SqlParameter("@Password", Password);
            pram[3] = new SqlParameter("@BranchName", BranchName);
            pram[4] = new SqlParameter("@BankAddress", BankAddress);
            pram[5] = new SqlParameter("@Email", Email);
            pram[6] = new SqlParameter("@City", city);
            pram[7] = new SqlParameter("@Country", country);
            pram[8] = new SqlParameter("@ContactPerson", contact_person);
            pram[9] = new SqlParameter("@ContactPersonEmail", contact_person_email);
            pram[10] = new SqlParameter("@ContactPersonMobile", contact_person_mobile);

            
           // pram[85] = new SqlParameter("@bphoto", System.Data.SqlDbType.Image,,dt.Rows[0]["bphoto"]);
            pram[85] = new SqlParameter("@SuccessId", 1);
            pram[85].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_BANK_REGISTRATION_INSERT", pram);
            return (int.Parse(pram[85].Value.ToString()));

          
        }


        public int BankUploadVerifiedData(string BankDate, string Branch, string ReqNo, string PassportNo, string FirstName, string MiddleName, string LastName, string Company, string Nationality, string FormNo, string TellerNo, decimal Amount, int CreatedBy, string CerpacNo, string strVisaNo, int condition)
        {
            SqlParameter[] pram = null;
            //try
            //{
            pram = new SqlParameter[86];
            pram[0] = new SqlParameter("@Date1", BankDate);
            pram[1] = new SqlParameter("@Branch", Branch);
            pram[2] = new SqlParameter("@RequisitionNO", ReqNo);
            pram[3] = new SqlParameter("@PassportNo", PassportNo);
            pram[4] = new SqlParameter("@FirstNAME", FirstName);
            pram[5] = new SqlParameter("@MiddleNAME", MiddleName);
            pram[6] = new SqlParameter("@LastNAME", LastName);
            pram[7] = new SqlParameter("@COMPANY", Company);
            pram[8] = new SqlParameter("@NATIONALITY", Nationality);
            pram[9] = new SqlParameter("@FORMNO", FormNo);
            pram[10] = new SqlParameter("@TELLERNO", TellerNo);
            pram[11] = new SqlParameter("@AMOUNT", Amount);
            pram[12] = new SqlParameter("@CerPAcNo", CerpacNo);
            pram[13] = new SqlParameter("@StrVisaNo", strVisaNo);            
            pram[14] = new SqlParameter("@CreatedBY", CreatedBy);

            pram[15] = new SqlParameter("@Condition", condition);

            // pram[85] = new SqlParameter("@bphoto", System.Data.SqlDbType.Image,,dt.Rows[0]["bphoto"]);
            pram[16] = new SqlParameter("@SuccessId", 1);
            pram[16].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_VerifyBankData_INSERT", pram);
            return (int.Parse(pram[15].Value.ToString()));


        }
    }
}
