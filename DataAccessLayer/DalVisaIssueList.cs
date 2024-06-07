using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
   public class DalVisaIssueList
    {

       public DataTable GetDalVisaPandingList(string L1id)
       {
           SqlParameter[] pram = null;
           DataSet objDs = null;
           try
           {
               pram = new SqlParameter[1];
               pram[0] = new SqlParameter("@USERID", L1id);

               objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[USP_VISA_ISSUE_LIST_FETCH_BY_USERID]", pram);

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
