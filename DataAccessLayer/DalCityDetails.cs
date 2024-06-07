using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DalCityDetails
    {

        public DataSet GetCityList()
        {
            DataSet ds = null;

            try
            {
                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, "UspCityMasterFetchList");
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

        public int InsertCityDetail(DataTable dt)
        {
            SqlParameter[] pram = null;
            try
            {
                //Adding the parameters of Insertion stored procedure.
                pram = new SqlParameter[6];
                pram[0] = new SqlParameter("@CountryCode", dt.Rows[0]["CountryCode"]);
                pram[1] = new SqlParameter("@CityCode", dt.Rows[0]["CityCode"]);
                pram[2] = new SqlParameter("@CityName", dt.Rows[0]["CityName"]);
                pram[3] = new SqlParameter("@Status", dt.Rows[0]["Status"]);
                pram[4] = new SqlParameter("@CreatedBy", dt.Rows[0]["ModifiedBy"]);

                pram[5] = new SqlParameter("@SuccessId", 1);
                pram[5].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_CITYMASTER_INSERT", pram);
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

        public DataTable FetchCityDetails(string CityCode)
        {
            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[1];                
                pram[0] = new SqlParameter("@CityCode", CityCode);

                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[USP_CITYMASTER_FETCH_BY_CITYCODE]", pram);
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

        public int UpdateCityDetail(DataTable dt)
        {
            SqlParameter[] pram = null;
            try
            {
                //Adding the parameters of Insertion stored procedure.
                pram = new SqlParameter[5];                
                pram[0] = new SqlParameter("@CityCode", dt.Rows[0]["CityCode"]);
                pram[1] = new SqlParameter("@CityName", dt.Rows[0]["CityName"]);
                pram[2] = new SqlParameter("@Status", dt.Rows[0]["Status"]);
                pram[3] = new SqlParameter("@ModifiedBy", dt.Rows[0]["ModifiedBy"]);

                pram[4] = new SqlParameter("@SuccessId", 1);
                pram[4].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_CITYMASTER_UPDATE", pram);
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
                pram = new SqlParameter[3];
                pram[0] = new SqlParameter("@CityCode", keyvalue);                
                pram[1] = new SqlParameter("@SuccessId", 1);
                pram[1].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_CITYMASTER_DELETE", pram);
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
