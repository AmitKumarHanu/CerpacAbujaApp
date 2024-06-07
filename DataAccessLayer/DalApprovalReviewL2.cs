using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
   public  class DalApprovalReviewL2
    {
       public int UpdateApplicationStatus(DataTable dt)
       {

           {
               SqlParameter[] pram = null;
               try
               {
                   //Adding the parameters of Insertion stored procedure.
                   pram = new SqlParameter[7];
                   pram[0] = new SqlParameter("@APPLICATIONID", dt.Rows[0]["APPLICATIONID"]);
                   pram[1] = new SqlParameter("@APPROVER2STATUS", dt.Rows[0]["APPROVER2STATUS"]);
                   pram[2] = new SqlParameter("@APPROVER2COMMENTS", dt.Rows[0]["APPROVER2COMMENTS"]);
                   pram[3] = new SqlParameter("@Rejection_Code", dt.Rows[0]["Rejection_Code"]);
                   pram[4] = new SqlParameter("@L2Id", dt.Rows[0]["L2Id"]);
                   pram[5] = new SqlParameter("@ModifiedBy", dt.Rows[0]["ModifiedBy"]);
                   pram[6] = new SqlParameter("@SuccessId", 1);
                   pram[6].Direction = ParameterDirection.Output;
                   SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_PANDINGL2_UPDATE", pram);
                   return int.Parse(pram[6].Value.ToString());

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

       public DataTable GetApprovedL1Detail(string ApplicantId)
       {
           SqlParameter[] pram = null;
           DataSet objDs = null;
           try
           {
               pram = new SqlParameter[1];
               pram[0] = new SqlParameter("@APPLICATIONID", ApplicantId);

               objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[USP_L1STATUS_FETCH_BY_APPLICATIONID]", pram);

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

       public DataTable GetDurationNDurationTypeDal(string AppId)
       {
           SqlParameter[] pram = null;
           DataSet objDs = null;
           try
           {
               pram = new SqlParameter[1];
               pram[0] = new SqlParameter("@APPLICATIONID", AppId);

               objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[USP_FETCH_DURATIONNTYPE_BY_APPLICATIONID_FORL2]", pram);

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

       public DataTable GetArrivalDate(string AppId)
       {
           SqlParameter[] pram = null;
           DataSet objDs = null;
           try
           {
               pram = new SqlParameter[1];
               pram[0] = new SqlParameter("@APPLICATIONID", AppId);

               objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[USP_FETCH_Get_Arrival_Date]", pram);

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

       public DataTable InsertValidTillDal(string AppId, DateTime ValidTillDate)
       {
           SqlParameter[] pram = null;
           DataSet objDs = null;
           try
           {
               pram = new SqlParameter[2];
               pram[0] = new SqlParameter("@APPLICATIONID", AppId);
               pram[1] = new SqlParameter("@VALIDTILL", ValidTillDate);
               //pram[2] = new SqlParameter("@PaperVisaValidFrom", PaperVisaValidFrom);
               //pram[3] = new SqlParameter("@PaperVisaValidThru", PaperVisaValidThru);
               objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[USP_UPDATE_VALIDTILL_FORL2]", pram);

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
     
    }


}
