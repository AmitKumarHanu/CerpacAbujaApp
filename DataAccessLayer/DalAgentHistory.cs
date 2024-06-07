using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
   public  class DalAgentHistory
    {
       public DataTable GetApplicantHistory(string USERID)
       {
           SqlParameter[] pram = null;
           DataSet objDs = null;
           try
           {
               pram = new SqlParameter[1];
               pram[0] = new SqlParameter("@USERID", USERID);

               objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[USP_AGENT_HISTORY]", pram);

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

       public DataTable GetApplicantStatusById(string ApplicationId, string userid)
       {
           SqlParameter[] pram = null;
           DataSet ds = null;
           try
           {
               pram = new SqlParameter[2];
               pram[0] = new SqlParameter("@ApplicationId", ApplicationId);
               pram[1] = new SqlParameter("@userid", userid);
               ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_SEARCH_AGENTHISTORY_DETAILS_BYAPPLICATIONID", pram);

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
