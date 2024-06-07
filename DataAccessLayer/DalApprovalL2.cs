using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DalApprovalL2
    {
        public DataTable GetDalVisaPandingListL2(string L1id)
        {
            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@USERID", L1id);

                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[USP_VISA_PENDINGLISTL2_FETCH_BY_APPLICATIONID_VISATYPE]", pram);

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

        public DataTable GetDalVisaPandingListL1ByL2(string id)
        {
            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@USERID", id);

                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[USP_VISA_PENDINGLISTL2_FETCH_BY_APPLICATIONID_VISATYPE_L1]", pram);

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

        public DataTable GetDalVisaPandingListL1ByL2_ByDate(string id, DateTime FromDate, DateTime ToDate)
        {
            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[4];
                pram[0] = new SqlParameter("@USERID", id);
                pram[1] = new SqlParameter("@FromDate", FromDate);
                pram[2] = new SqlParameter("@ToDate", ToDate);

                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_VISA_PENDINGLISTL2_FETCH_BY_APPLICATIONID_VISATYPE_L1ByDate", pram);

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

