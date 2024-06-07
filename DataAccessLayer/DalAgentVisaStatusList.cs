using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public  class DalAgentVisaStatusList
    {
        public DataTable GetAgentVisaStatusList(string AppliedByUserId)
        {
            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@UserId", AppliedByUserId);

                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_VISA_AGENT_STATUS_FETCHBY_APPLICATIONID", pram);

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
                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[USP_SEARCH_AGENTVISASTATUS_DETAILS_BYAPPLICATIONID]", pram);

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
