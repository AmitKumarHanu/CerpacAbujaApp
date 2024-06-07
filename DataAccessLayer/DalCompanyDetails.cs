using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
   public class DalCompanyDetails
    {
        public int InsertCompanyRegistration(DataTable dt)
        {
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[14];
                
                pram[0] = new SqlParameter("@CompanyName", dt.Rows[0]["Company_Name"]);
                pram[1] = new SqlParameter("@CompAddressLine1", dt.Rows[0]["Comp_Address_Line1"]);
                pram[2] = new SqlParameter("@CompAddressLine2", dt.Rows[0]["Comp_Address_Line2"]);
                pram[3] = new SqlParameter("@CompAddressLine3", dt.Rows[0]["Comp_Address_Line3"]);
                pram[4] = new SqlParameter("@CompanyZip", dt.Rows[0]["Company_Zip"]);
                pram[5] = new SqlParameter("@CompanyPhone1", dt.Rows[0]["Company_Phone1"]);
                pram[6] = new SqlParameter("@CompanyPhone2", dt.Rows[0]["Company_Phone2"]);
                pram[7] = new SqlParameter("@CompanyPhone3", dt.Rows[0]["Company_Phone3"]);
                pram[8] = new SqlParameter("@CompanyFax", dt.Rows[0]["Company_Fax"]);
                pram[9] = new SqlParameter("@CompanyWebSite", dt.Rows[0]["Company_WebSite"]);
                pram[10] = new SqlParameter("@CompanyEmailId", dt.Rows[0]["Company_EmailId"]);
                pram[11] = new SqlParameter("@CompanyLogo", dt.Rows[0]["Company_Logo"]);
                pram[12] = new SqlParameter("@CreatedBy", dt.Rows[0]["Created_By"]);
                pram[13] = new SqlParameter("@SuccessId", 1);
                pram[13].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspCompanyMasterInsert", pram);
                return int.Parse(pram[13].Value.ToString());

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

       public int UpdateCompanyRegistration(DataTable dt)
       {
           SqlParameter[] pram = null;
           try
           {
               pram = new SqlParameter[15];
               pram[0] = new SqlParameter("@CompanyId", dt.Rows[0]["CompanyId"]);
               pram[1] = new SqlParameter("@CompanyName", dt.Rows[0]["Company_Name"]);
               pram[2] = new SqlParameter("@CompAddressLine1", dt.Rows[0]["Comp_Address_Line1"]);
               pram[3] = new SqlParameter("@CompAddressLine2", dt.Rows[0]["Comp_Address_Line2"]);
               pram[4] = new SqlParameter("@CompAddressLine3", dt.Rows[0]["Comp_Address_Line3"]);
               pram[5] = new SqlParameter("@CompanyZip", dt.Rows[0]["Company_Zip"]);
               pram[6] = new SqlParameter("@CompanyPhone1", dt.Rows[0]["Company_Phone1"]);
               pram[7] = new SqlParameter("@CompanyPhone2", dt.Rows[0]["Company_Phone2"]);
               pram[8] = new SqlParameter("@CompanyPhone3", dt.Rows[0]["Company_Phone3"]);
               pram[9] = new SqlParameter("@CompanyFax", dt.Rows[0]["Company_Fax"]);
               pram[10] = new SqlParameter("@CompanyWebSite", dt.Rows[0]["Company_WebSite"]);
               pram[11] = new SqlParameter("@CompanyEmailId", dt.Rows[0]["Company_EmailId"]);
               pram[12] = new SqlParameter("@CompanyLogo", dt.Rows[0]["Company_Logo"]);
               pram[13] = new SqlParameter("@CreatedBy", dt.Rows[0]["Created_By"]);
               pram[14] = new SqlParameter("@SuccessId", 1);
               pram[14].Direction = ParameterDirection.Output;
               SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspCompanyMasterUpdate", pram);
               return int.Parse(pram[14].Value.ToString());

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

       public DataSet GetCompanyInfo(int Company_Id)
       {
           DataSet ds = null;
           SqlParameter[] pram = null;
           try
           {
               pram = new SqlParameter[1];
               pram[0] = new SqlParameter("@CompanyId", Company_Id);
               ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, "UspCompanyMasterFetchByCompanyId", pram);
               return ds;
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

       public DataSet GetCompanyList()
       {
           DataSet ds = null;
           
           try
           {
               ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, "UspCompanyMasterFetchList");
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

       public int DeleteDataRow(string keyvalue)
       {
           SqlParameter[] pram = null;
           try
           {
               pram = new SqlParameter[2];
               pram[0] = new SqlParameter("@PositionCode", keyvalue);
               pram[1] = new SqlParameter("@SuccessId", 1);
               pram[1].Direction = ParameterDirection.Output;
               SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspPositionMasterDelete", pram);
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

       public int InsertPosition(DataTable dtCompanyDetails)
       {
         SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[3];

                pram[0] = new SqlParameter("@PositionName", dtCompanyDetails.Rows[0]["PositionName"]);
                pram[1] = new SqlParameter("@companyid", dtCompanyDetails.Rows[0]["companyid"]);
                pram[2] = new SqlParameter("@SuccessId", 1);
                pram[2].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspPositionMasterInsert", pram);
                return int.Parse(pram[2].Value.ToString());

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

       public int InsertQuota(DataTable dtCompanyDetails)
       {
           SqlParameter[] pram = null;
           try
           {
               pram = new SqlParameter[8];

               pram[0] = new SqlParameter("@QuotaNo", dtCompanyDetails.Rows[0]["QuotaNo"]);
               pram[1] = new SqlParameter("@dateofsanction", dtCompanyDetails.Rows[0]["dateofsanction"]);
               pram[2] = new SqlParameter("@Position", dtCompanyDetails.Rows[0]["Position"]);
               pram[3] = new SqlParameter("@NumPosition", dtCompanyDetails.Rows[0]["NumPosition"]);
               pram[4] = new SqlParameter("@BalPosition", dtCompanyDetails.Rows[0]["BalPosition"]);
               pram[5] = new SqlParameter("@companyid", dtCompanyDetails.Rows[0]["companyid"]);
               pram[6] = new SqlParameter("@dateofexipry", dtCompanyDetails.Rows[0]["dateofexipry"]);
               pram[7] = new SqlParameter("@SuccessId", 1);
               pram[7].Direction = ParameterDirection.Output;
               SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspQuotaMasterInsert", pram);
               return int.Parse(pram[7].Value.ToString());

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

       public int UpdatePosition(DataTable dtCompanyDetails)
       {
           SqlParameter[] pram = null;
           try
           {
               pram = new SqlParameter[3];

               pram[0] = new SqlParameter("@PositionCode", dtCompanyDetails.Rows[0]["PositionCode"]);
               pram[1] = new SqlParameter("@PositionName", dtCompanyDetails.Rows[0]["PositionName"]);
               pram[2] = new SqlParameter("@SuccessId", 1);
               pram[2].Direction = ParameterDirection.Output;
               SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspPositionMasterUpdate", pram);
               return int.Parse(pram[2].Value.ToString());

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

       public int UpdateQuota(DataTable dtCompanyDetails)
       {
           SqlParameter[] pram = null;
           try
           {
               pram = new SqlParameter[8];

               pram[0] = new SqlParameter("@QuotaNo", dtCompanyDetails.Rows[0]["QuotaNo"]);
               pram[1] = new SqlParameter("@dateofsanction", dtCompanyDetails.Rows[0]["dateofsanction"]);
               pram[2] = new SqlParameter("@Position", dtCompanyDetails.Rows[0]["Position"]);
               pram[3] = new SqlParameter("@NumPosition", dtCompanyDetails.Rows[0]["NumPosition"]);
               pram[4] = new SqlParameter("@BalPosition", dtCompanyDetails.Rows[0]["BalPosition"]);
               pram[5] = new SqlParameter("@dateofexipry", dtCompanyDetails.Rows[0]["dateofexipry"]);
               pram[6] = new SqlParameter("@STRQuotaId", dtCompanyDetails.Rows[0]["STRQuotaId"]);
               pram[7] = new SqlParameter("@SuccessId", 1);
               pram[7].Direction = ParameterDirection.Output;
               SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspQuotaMasterUpdate", pram);
               return int.Parse(pram[7].Value.ToString());

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

       public int InsertApplicant(DataTable dtCompanyDetails)
       {
           SqlParameter[] pram = null;
           try
           {
               pram = new SqlParameter[9];

               pram[0] = new SqlParameter("@QuotaNo", dtCompanyDetails.Rows[0]["QuotaNo"]);
               pram[1] = new SqlParameter("@dateofbirth", dtCompanyDetails.Rows[0]["dateofbirth"]);
               pram[2] = new SqlParameter("@FirstName", dtCompanyDetails.Rows[0]["FirstName"]);
               pram[3] = new SqlParameter("@LastName", dtCompanyDetails.Rows[0]["LastName"]);
               pram[4] = new SqlParameter("@Nationality", dtCompanyDetails.Rows[0]["Nationality"]);
               pram[5] = new SqlParameter("@PassportNo", dtCompanyDetails.Rows[0]["PassportNo"]);
               pram[6] = new SqlParameter("@companyid", dtCompanyDetails.Rows[0]["companyid"]);
               pram[7] = new SqlParameter("@PositionCode", dtCompanyDetails.Rows[0]["PositionCode"]);
               pram[8] = new SqlParameter("@SuccessId", 1);
               pram[8].Direction = ParameterDirection.Output;
               SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspApplicantMasterInsert", pram);
               return int.Parse(pram[8].Value.ToString());

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

       public int UpdateApplicantData(DataTable dtCompanyDetails)
       {
           SqlParameter[] pram = null;
           try
           {
               pram = new SqlParameter[9];

               pram[0] = new SqlParameter("@QuotaNo", dtCompanyDetails.Rows[0]["QuotaNo"]);
               pram[1] = new SqlParameter("@dateofbirth", dtCompanyDetails.Rows[0]["dateofbirth"]);
               pram[2] = new SqlParameter("@FirstName", dtCompanyDetails.Rows[0]["FirstName"]);
               pram[3] = new SqlParameter("@LastName", dtCompanyDetails.Rows[0]["LastName"]);
               pram[4] = new SqlParameter("@Nationality", dtCompanyDetails.Rows[0]["Nationality"]);
               pram[5] = new SqlParameter("@PassportNo", dtCompanyDetails.Rows[0]["PassportNo"]);
               pram[6] = new SqlParameter("@applicationid", dtCompanyDetails.Rows[0]["applicationid"]);
               pram[7] = new SqlParameter("@PositionCode", dtCompanyDetails.Rows[0]["PositionCode"]);
               pram[8] = new SqlParameter("@SuccessId", 1);
               pram[8].Direction = ParameterDirection.Output;
               SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspApplicantMasterUpdate", pram);
               return int.Parse(pram[8].Value.ToString());

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

       public int CreateRequistion(DataTable dtCompanyDetails)
       {
           SqlParameter[] pram = null;
           try
           {
               pram = new SqlParameter[3];

               pram[0] = new SqlParameter("@applicationId", dtCompanyDetails.Rows[0]["applicationId"]);
               pram[1] = new SqlParameter("@RequisitionNo", dtCompanyDetails.Rows[0]["RequisitionNo"]);
               pram[2] = new SqlParameter("@SuccessId", 1);
               pram[2].Direction = ParameterDirection.Output;
               SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspRequisitionInsert", pram);
               return int.Parse(pram[2].Value.ToString());

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

       public int ExpireQuota(string keyvalue)
       {
           SqlParameter[] pram = null;
           try
           {
               pram = new SqlParameter[2];
               pram[0] = new SqlParameter("@STRQuotaId", keyvalue);
               pram[1] = new SqlParameter("@SuccessId", 1);
               pram[1].Direction = ParameterDirection.Output;
               SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspExpireQuota", pram);
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

       public int UpdateBalancePosition(DataTable dtCompanyDetails)
       {
           SqlParameter[] pram = null;
           try
           {
               pram = new SqlParameter[5];

               pram[0] = new SqlParameter("@QuotaNo", dtCompanyDetails.Rows[0]["QuotaNo"]);
               pram[1] = new SqlParameter("@DateofResign", dtCompanyDetails.Rows[0]["DateofResign"]);
               pram[2] = new SqlParameter("@PositionCode", dtCompanyDetails.Rows[0]["PositionCode"]);
               pram[3] = new SqlParameter("@applicationid", dtCompanyDetails.Rows[0]["applicationid"]);
               pram[4] = new SqlParameter("@SuccessId", 1);
               pram[4].Direction = ParameterDirection.Output;
               SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspUpdateBalancePosition", pram);
               return int.Parse(pram[4].Value.ToString());

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
