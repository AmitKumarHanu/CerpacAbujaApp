using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;


namespace DataAccessLayer
{
    public class DalMyProfile
    {
        private static char[] charSeparators = new char[] { };
        private static String[] result;

        #region UpdateMyProfile

        public int UpdateMyProfile(DataTable dt)
        {
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[32];

                // pram[0] = new SqlParameter("@Password", dt.Rows[0]["Password"]);
                pram[0] = new SqlParameter("@PrimaryEmail", dt.Rows[0]["PrimaryEmail"]);
                //pram[2] = new SqlParameter("@AlternateEmail", dt.Rows[0]["AlternateEmail"]);
                // pram[3] = new SqlParameter("@SecretQuestion", dt.Rows[0]["SecretQuestion"]);
                // pram[4] = new SqlParameter("@SecretAnswer", dt.Rows[0]["SecretAnswer"]);
                pram[1] = new SqlParameter("@FirstName", dt.Rows[0]["FirstName"]);
                pram[2] = new SqlParameter("@MiddleName", dt.Rows[0]["MiddleName"]);
                pram[3] = new SqlParameter("@LastName", dt.Rows[0]["LastName"]);
                pram[4] = new SqlParameter("@DateOfBirth", dt.Rows[0]["DateOfBirth"]);
                pram[5] = new SqlParameter("@PlaceOfBirth", dt.Rows[0]["PlaceOfBirth"]);
                pram[6] = new SqlParameter("@Sex", dt.Rows[0]["Sex"]);
                pram[7] = new SqlParameter("@MaritalStatus", dt.Rows[0]["MaritalStatus"]);
                pram[8] = new SqlParameter("@FatherName", dt.Rows[0]["FatherName"]);
                pram[9] = new SqlParameter("@FatherLastName", dt.Rows[0]["FatherLastName"]);
                pram[10] = new SqlParameter("@DateofBirthF", dt.Rows[0]["DateofBirthF"]);
                pram[11] = new SqlParameter("@PlaceAndCountryOfBirthF", dt.Rows[0]["PlaceAndCountryOfBirthF"]);
                pram[12] = new SqlParameter("@FatherNationality", dt.Rows[0]["FatherNationality"]);
                pram[13] = new SqlParameter("@MotherName", dt.Rows[0]["MotherName"]);
                pram[14] = new SqlParameter("@MotherLastName", dt.Rows[0]["MotherLastName"]);
                pram[15] = new SqlParameter("@DateofBirthM", dt.Rows[0]["DateofBirthM"]);
                pram[16] = new SqlParameter("@PlaceAndCountryOfBirthM", dt.Rows[0]["PlaceAndCountryOfBirthM"]);
                pram[17] = new SqlParameter("@MotherNationality", dt.Rows[0]["MotherNationality"]);
                pram[18] = new SqlParameter("@Nationality", dt.Rows[0]["Nationality"]);
                // pram[15] = new SqlParameter("@CurrentAddress", dt.Rows[0]["CurrentAddress"]);
                //pram[16] = new SqlParameter("@PermanentAddress", dt.Rows[0]["PermanentAddress"]);
                pram[19] = new SqlParameter("@PassportOrTravelDocumentNumber", dt.Rows[0]["PassportOrTravelDocumentNumber"]);
                pram[20] = new SqlParameter("@PassportType", dt.Rows[0]["PassportType"]);
                pram[21] = new SqlParameter("@DateOfIssue", dt.Rows[0]["DateOfIssue"]);
                pram[22] = new SqlParameter("@DateOfExpiry", dt.Rows[0]["DateOfExpiry"]);
                pram[23] = new SqlParameter("@PlaceOfIssue", dt.Rows[0]["PlaceOfIssue"]);
                pram[24] = new SqlParameter("@IssuingAuthority", dt.Rows[0]["IssuingAuthority"]);
                pram[25] = new SqlParameter("@ColorOfEyes", dt.Rows[0]["ColorOfEyes"]);
                pram[26] = new SqlParameter("@ColorOfHair", dt.Rows[0]["ColorOfHair"]);
                // pram[23] = new SqlParameter("@MobileNumber", dt.Rows[0]["MobileNumber"]);
                //pram[24] = new SqlParameter("@LandlinePhone", dt.Rows[0]["LandlinePhone"]);
                pram[27] = new SqlParameter("@Height", dt.Rows[0]["Height"]);
                // pram[32] = new SqlParameter("@LoginID", dt.Rows[0]["LoginID"]);
                pram[28] = new SqlParameter("@OtherName", dt.Rows[0]["OtherName"]);
                //pram[26] = new SqlParameter("@UserIPAddress", dt.Rows[0]["UserIPAddress"]);
                //pram[27] = new SqlParameter("@CreatedBy", dt.Rows[0]["CreatedBy"]);
                //pram[28] = new SqlParameter("@ModifiedBy", dt.Rows[0]["ModifiedBy"]);
                //pram[27] = new SqlParameter("@Companyid", dt.Rows[0]["CompanyID"]);
                //pram[28] = new SqlParameter("@Groupid", dt.Rows[0]["GrpID"]);
                //pram[29] = new SqlParameter("@Uniquecode", dt.Rows[0]["UniqueCode"]);
                //pram[34] = new SqlParameter("@Photo", dt.Rows[0]["Photo"]);
                pram[29] = new SqlParameter("@LoginID", dt.Rows[0]["LoginID"]);
                pram[30] = new SqlParameter("@IndentificationMarks", dt.Rows[0]["IndentificationMarks"]);
                pram[31] = new SqlParameter("@SuccessId", 1);
                pram[31].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_MYPROFILE_UPDATE", pram);
                return (int.Parse(pram[31].Value.ToString()));
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






    }
}
