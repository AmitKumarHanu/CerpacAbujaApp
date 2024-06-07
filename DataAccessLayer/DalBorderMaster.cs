using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DalBorderMaster
    {
        public DataSet GetBorderInfo(int BorderId)
        {
            DataSet ds = new DataSet();
            SqlParameter[] param = null;

            try
            {
                param = new SqlParameter[1];
                param[0] = new SqlParameter("@BorderId", BorderId);
                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, "UspBorderMasterFetchByBorderId", param);

                return ds;
            }
            catch (Exception e)
            {
                throw (e);
            }

            finally
            {
                param = null;
            }

        }

        public int InsertBorderMaster(DataTable dt)
        {
            SqlParameter[] param1 = null;

            try
            {
                param1 = new SqlParameter[7];

                param1[0] = new SqlParameter("@CountryCode", dt.Rows[0]["CountryCode"]);
                param1[1] = new SqlParameter("@CityCode", dt.Rows[0]["CityCode"]);
                param1[2]=new SqlParameter("@BorderCode",dt.Rows[0]["BorderCode"]);
                param1[3]=new SqlParameter("@BorderName", dt.Rows[0]["BorderName"]);
                param1[4] = new SqlParameter("@Status", dt.Rows[0]["Status"]);
                param1[5] = new SqlParameter("@CreatedBy", dt.Rows[0]["CreatedBy"]);
                param1[6] = new SqlParameter("@SuccessId", 1);
                param1[6].Direction=ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspBorderMasterInsert", param1);

                return int.Parse(param1[6].Value.ToString());


            }
            catch (Exception ex)
            {
                throw(ex);

            }
            finally
            {
                param1=null;
            }
        }
        //public int UpdateBorderMaster()
        //{
        //    return 1;
        //}
    }
}
