using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
   public class DalL2status
    {
       public DataTable GetL2StatusList(string L1id)
        {
            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@UserId", L1id);

                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[USP_APPLICANTSTATUS_FETCHLIST_L2]", pram);

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

       public DataTable GetApplicantStatusById(string ApplicationId)
       {
           SqlParameter[] pram = null;
           DataSet ds = null;
           try
           {
               pram = new SqlParameter[1];
               pram[0] = new SqlParameter("@ApplicationId", ApplicationId);

               ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[USP_APPLICANTSTATUS_FETCH_BYAPPLICANTID]", pram);

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
