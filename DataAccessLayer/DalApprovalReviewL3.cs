using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
   public class DalApprovalReviewL3
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
                   pram[1] = new SqlParameter("@APPROVER3STATUS", dt.Rows[0]["APPROVER3STATUS"]);
                   pram[2] = new SqlParameter("@APPROVER3COMMENTS", dt.Rows[0]["APPROVER3COMMENTS"]);
                   pram[3] = new SqlParameter("@Rejection_Code", dt.Rows[0]["Rejection_Code"]);
                   pram[4] = new SqlParameter("@L3Id", dt.Rows[0]["L3Id"]);
                   pram[5] = new SqlParameter("@ModifiedBy", dt.Rows[0]["ModifiedBy"]);
                   pram[6] = new SqlParameter("@SuccessId", 1);
                   pram[6].Direction = ParameterDirection.Output;
                   SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_UPDATE_APPROVALSTATUS_L3", pram);
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



       public DataTable GetApprovedL1N2DetailDal(string ApplicantId)
       {
           SqlParameter[] pram = null;
           DataSet objDs = null;
           try
           {
               pram = new SqlParameter[1];
               pram[0] = new SqlParameter("@APPLICATIONID", ApplicantId);

               objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[USP_L1NL2STATUS_FETCH_BY_APPLICATIONID_FORL3]", pram);

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

               objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[USP_FETCH_DURATIONNTYPE_BY_APPLICATIONID_FORL3]", pram);

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

       public DataTable InsertValidTillDal(string AppId, DateTime ValidTillDate, string VisaValidFor)
       {
           SqlParameter[] pram = null;
           DataSet objDs = null;
           try
           {
               pram = new SqlParameter[3];
               pram[0] = new SqlParameter("@APPLICATIONID", AppId);
               pram[1] = new SqlParameter("@VALIDTILL", ValidTillDate);
               pram[2] = new SqlParameter("@VALIDFOR", VisaValidFor);
               //pram[3] = new SqlParameter("@PaperVisaValidFrom", PaperVisaValidFrom);
               //pram[4] = new SqlParameter("@PaperVisaValidThru", PaperVisaValidThru);
               objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[USP_UPDATE_VALIDTILL_FORL3]", pram);

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
