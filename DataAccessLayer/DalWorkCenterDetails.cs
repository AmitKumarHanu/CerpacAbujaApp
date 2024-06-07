using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DalWorkCenterDetails
    {

        public DataSet GetWorkCenterList()
        {
            DataSet ds = null;

            try
            {
                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, "UspWorkCenterFetchList");
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

        public int InsertWorkCenterDetail(DataTable dt)
        {
            SqlParameter[] pram = null;
            try
            {
                //Adding the parameters of Insertion stored procedure.
                pram = new SqlParameter[4];
                pram[0] = new SqlParameter("@WorkCenter", dt.Rows[0]["WorkCenter"]);
                //pram[1] = new SqlParameter("@CityCode", dt.Rows[0]["CityCode"]);
               // pram[2] = new SqlParameter("@CityName", dt.Rows[0]["CityName"]);
                pram[1] = new SqlParameter("@Status", dt.Rows[0]["Status"]);
                pram[2] = new SqlParameter("@CreatedBy", dt.Rows[0]["ModifiedBy"]);

                pram[3] = new SqlParameter("@SuccessId", 1);
                pram[3].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_WORKCENTER_INSERT", pram);
                return int.Parse(pram[3].Value.ToString());

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

        public DataTable FetchWorkCenterDetails(int WorkCenterID)
        {
            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@WorkCenterID", WorkCenterID);

                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[USP_WORKMASTER_FETCH_BY_WORKCENTER]", pram);
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

        public int UpdateWorkCenterDetail(DataTable dt)
        {
            SqlParameter[] pram = null;
            try
            {
                //Adding the parameters of Insertion stored procedure.
                pram = new SqlParameter[5];
                pram[0] = new SqlParameter("@WorkCenter", dt.Rows[0]["WorkCenter"]);
                pram[1] = new SqlParameter("@WorkCenterID", dt.Rows[0]["WorkCenterID"]);
                pram[2] = new SqlParameter("@Status", dt.Rows[0]["Status"]);
                pram[3] = new SqlParameter("@ModifiedBy", dt.Rows[0]["ModifiedBy"]);

                pram[4] = new SqlParameter("@SuccessId", 1);
                pram[4].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_WORKCENTER_UPDATE", pram);
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

        public int DeleteDataRow(string keyvalue)
        {
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[2];
                pram[0] = new SqlParameter("@WorkCenter", keyvalue);                
                pram[1] = new SqlParameter("@SuccessId", 1);
                pram[1].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_WORKCENTER_DELETE", pram);
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
