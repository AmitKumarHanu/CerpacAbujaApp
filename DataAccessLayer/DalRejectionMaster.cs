using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
   public  class DalRejectionMaster
    {
        public DataSet GetRejectionList()
        {
            DataSet ds = null;

            try
            {
                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, "Usp_REJECTIONMASTER_FETCHLIST");
                return ds;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ds = null;
            }

        }

        public int InsertRejectionDetail(DataTable dt)
        {
            SqlParameter[] pram = null;
            try
            {
                //Adding the parameters of Insertion stored procedure.
                pram = new SqlParameter[5];
                pram[0] = new SqlParameter("@Rejection_Code", dt.Rows[0]["Rejection_Code"]);
                pram[1] = new SqlParameter("@Rejection_Description", dt.Rows[0]["Rejection_Description"]);
                pram[2] = new SqlParameter("@Status", dt.Rows[0]["Status"]);
                pram[3] = new SqlParameter("@CreatedBy", dt.Rows[0]["ModifiedBy"]);

                pram[4] = new SqlParameter("@SuccessId", 1);
                pram[4].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_REJECTIONMASTER_INSERT", pram);
                return int.Parse(pram[4].Value.ToString());

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

        public int UpdateRejectionDetail(DataTable dt)
        {
            SqlParameter[] pram = null;
            try
            {
                //Adding the parameters of Insertion stored procedure.
                pram = new SqlParameter[5];
                pram[0] = new SqlParameter("@Rejection_Code", dt.Rows[0]["Rejection_Code"]);
                pram[1] = new SqlParameter("@Rejection_Description", dt.Rows[0]["Rejection_Description"]);
                pram[2] = new SqlParameter("@Status", dt.Rows[0]["Status"]);
                pram[3] = new SqlParameter("@ModifiedBy", dt.Rows[0]["ModifiedBy"]);

                pram[4] = new SqlParameter("@SuccessId", 1);
                pram[4].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_REJECTION_UPDATE", pram);
                return int.Parse(pram[4].Value.ToString());

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

        public DataTable FetchRejectionDetails_RejectionCode(string Rejection_Code)
        {
            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@Rejection_Code", Rejection_Code);

                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[USP_REJECTIONMASTER_FETCH_BY_REJECTIONCODE]", pram);
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
                pram[0] = new SqlParameter("@Rejection_Code", keyvalue);
                pram[1] = new SqlParameter("@SuccessId", 1);
                pram[1].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspREJECTIONMasterDelete", pram);
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
