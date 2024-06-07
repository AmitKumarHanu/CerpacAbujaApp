using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
   public  class DalVisaStatus
    {
       public DataTable GetApplicantVisaStatus(string AppliedByUserId)
       {
           SqlParameter[] pram = null;
           DataSet objDs = null;
           try
           {
               pram = new SqlParameter[1];
               pram[0] = new SqlParameter("@APPLICATIONID", AppliedByUserId);

               objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_VISA_APPLICANT_STATUS_FETCHBY_APPLICATIONID", pram);

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

       public int DeleteDataRow(string keyvalue)
       {
           SqlParameter[] pram = null;
           try
           {
               pram = new SqlParameter[2];
               pram[0] = new SqlParameter("@ApplicationId", keyvalue);
               pram[1] = new SqlParameter("@SuccessId", 1);
               pram[1].Direction = ParameterDirection.Output;
               SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_Visa_Application_DELETE", pram);
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
    }
}
