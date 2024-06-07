using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DalBorderDetails
    {
        public DataTable GetBorderList()
        {
            DataSet ds = null;
            DataTable dt = null;

            try
            {
                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, "UspBorderMasterFetchList");
                dt = ds.Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                dt = null;
            }

        }
        public int UpdateBorderDetail(DataTable dt)
        {
            SqlParameter[] pram = null;
            try
            {
                //Adding the parameters of Insertion stored procedure.
                pram = new SqlParameter[5];
                pram[0] = new SqlParameter("@BorderId", dt.Rows[0]["BorderId"]);
                pram[1] = new SqlParameter("@BorderName", dt.Rows[0]["BorderName"]);
                pram[2] = new SqlParameter("@Status", dt.Rows[0]["Status"]);
                pram[3] = new SqlParameter("@ModifiedBy", dt.Rows[0]["ModifiedBy"]);

                pram[4] = new SqlParameter("@SuccessId", 1);
                pram[4].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USPBORDERMASTERUPDATE", pram);
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

        public int DeleteDataRow(int keyvalue)
        {
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[2];
                pram[0] = new SqlParameter("@BorderId", keyvalue);
                pram[1] = new SqlParameter("@SuccessId", 1);
                pram[1].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspBorderMasterDelete", pram);
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
