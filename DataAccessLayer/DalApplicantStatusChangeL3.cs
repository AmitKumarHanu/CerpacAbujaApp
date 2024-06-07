using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace DataAccessLayer
{
   public class DalApplicantStatusChangeL3
    {
       public DataTable GetApplicantStatusList(string L3id)
       {
           SqlParameter[] pram = null;
           DataSet objDs = null;
           try
           {
               pram = new SqlParameter[1];
               pram[0] = new SqlParameter("@UserId", L3id);

               objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[USP_AAPPLICANT_STATUS_CHANGE_FETCHLIST_L3]", pram);

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

       public DataTable GetApplicantStatusById(string ApplicationId,string Userid)
       {
           SqlParameter[] pram = null;
           DataSet ds = null;
           try
           {
               pram = new SqlParameter[2];
               pram[0] = new SqlParameter("@ApplicationId", ApplicationId);
               pram[1] = new SqlParameter("@UserId", Userid);
               ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[Usp_Applicant_Status_FetchList_ByApplicationId_L3]", pram);

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
    }
}
