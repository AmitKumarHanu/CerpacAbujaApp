using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
   public class DalPayableListBank
    {
       public DataTable GetApplicantPayableListDal()
       {
           SqlParameter[] pram = null;
           DataSet objDs = null;
           try
           {
               pram = new SqlParameter[0];
               //pram[0] = new SqlParameter("@PassportNo", PassportNo);
               //pram[1] = new SqlParameter("@Nationality", Nationality);
               //pram[2] = new SqlParameter("@ApplicationID", AppID);
               objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[USP_APPLICANT_LIST_FOR_PAYMENT_ATBANK]", pram);

               return objDs.Tables[0];


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

       public DataTable GetApplicantPayableListBankByIdDal(string ApplicationId)//,string Userid)
       {
           SqlParameter[] pram = null;
           DataSet ds = null;
           try
           {
               pram = new SqlParameter[1];
               pram[0] = new SqlParameter("@ApplicationId", ApplicationId);
               //pram[1] = new SqlParameter("@UserId", Userid);
               ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[USP_SEARCH_APPLICANT_PAYABLE_AT_BANK_BY_APPID]", pram);

               return ds.Tables[0];
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


       public DataTable GetDalPayableListBankbyApplicationId(string ApplicationId)
       {
           SqlParameter[] pram = null;
           DataSet ds = null;
           try
           {
               pram = new SqlParameter[1];
               pram[0] = new SqlParameter("@ApplicationId", ApplicationId);

               ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[USP_APPLICANT_DETAIL_FOR_PAYMENT_BY_APPLICATIONID]", pram);

               return ds.Tables[0];
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


       public int GetDalUpdateApplicantPaymentVisaNormalbyApplicationId(string Appid,string UId) //, string VisaTypeCode)
       {
           SqlParameter[] pram = null;
           //int i = 0;
           try
           {
               pram = new SqlParameter[3];
               pram[0] = new SqlParameter("@ApplicationId", Appid);
               pram[1] = new SqlParameter("@Userid", UId);
               pram[2] = new SqlParameter("@SuccessId", 1);
               pram[2].Direction = ParameterDirection.Output;
               SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_UPDATE_BANK_PAYMENT_STATUS_NRECEIPTNO", pram);
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

       public DataTable GetDataCashReceipt(string AppliId)
       {
           DataSet ds = null;
           SqlParameter[] param = null;
           try
           {
               ds = new DataSet();
               param = new SqlParameter[1];

               param[0] = new SqlParameter("@APPLICATIONID", AppliId);


               ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_CASH_RECEIPT_GENERATION", param);
               if (ds.Tables.Count > 0)
               {
                   return ds.Tables[0];
               }
               else
               {
                   DataTable dt = null;
                   return dt;
               }
           }
           catch (Exception ex)
           {
               throw ex;
           }

       }
       
    }
}
