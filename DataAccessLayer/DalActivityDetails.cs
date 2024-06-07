using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DalActivityDetails
    {

        public DataSet GetActivityList()
        {
            DataSet ds = null;

            try
            {
                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, "UspActivityFetchList");
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

        public int InsertActivityDetail(DataTable dt)
        {
            SqlParameter[] pram = null;
            try
            {
                //Adding the parameters of Insertion stored procedure.
                pram = new SqlParameter[5];
                pram[0] = new SqlParameter("@ActivityName", dt.Rows[0]["ActivityName"]);
                pram[1] = new SqlParameter("@ActivityType", dt.Rows[0]["ActivityType"]);
                pram[2] = new SqlParameter("@ActivityCode", dt.Rows[0]["ActivityCode"]);
                //pram[1] = new SqlParameter("@CityCode", dt.Rows[0]["CityCode"]);
               // pram[2] = new SqlParameter("@CityName", dt.Rows[0]["CityName"]);
               // pram[3] = new SqlParameter("@Status", dt.Rows[0]["Status"]);
                pram[3] = new SqlParameter("@CreatedBy", dt.Rows[0]["ModifiedBy"]);

                pram[4] = new SqlParameter("@SuccessId", 1);
                pram[4].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_ACTIVITY_INSERT", pram);
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

        public DataTable FetchActivityDetails(int ActivityID)
        {
            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@ActivityID", ActivityID);

                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[USP_ACTIVITYMASTER_FETCH_BY_ACTIVITY]", pram);
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

        public int UpdateActivityDetail(DataTable dt)
        {
            SqlParameter[] pram = null;
            try
            {
                //Adding the parameters of Insertion stored procedure.
                pram = new SqlParameter[6];
                pram[0] = new SqlParameter("@ActivityName", dt.Rows[0]["ActivityName"]);
                pram[1] = new SqlParameter("@ActivityType", dt.Rows[0]["ActivityType"]);
                pram[2] = new SqlParameter("@ActivityCode", dt.Rows[0]["ActivityCode"]);
                pram[3] = new SqlParameter("@ActivityID", dt.Rows[0]["ActivityID"]);
               // pram[4] = new SqlParameter("@Status", dt.Rows[0]["Status"]);
                pram[4] = new SqlParameter("@ModifiedBy", dt.Rows[0]["ModifiedBy"]);

                pram[5] = new SqlParameter("@SuccessId", 1);
                pram[5].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_ACTIVITY_UPDATE", pram);
                return int.Parse(pram[5].Value.ToString());

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
                pram[0] = new SqlParameter("@ActivityName", keyvalue);                
                pram[1] = new SqlParameter("@SuccessId", 1);
                pram[1].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_ACTIVITY_DELETE", pram);
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
