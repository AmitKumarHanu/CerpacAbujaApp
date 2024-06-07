using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DalZonDetails
    {

        public DataSet GetZoneList()
        {
            DataSet ds = null;

            try
            {
                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, "UspZonemasterFetchList");
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

        public int InsertZoneDetail(DataTable dt)
        {
            SqlParameter[] pram = null;
            try
            {
                //Adding the parameters of Insertion stored procedure.
                pram = new SqlParameter[5];
                pram[0] = new SqlParameter("@CountryCode", dt.Rows[0]["CountryCode"]);
                // pram[1] = new SqlParameter("@CityName",   dt.Rows[0]["CityName"]);
                pram[1] = new SqlParameter("@ZonCode", dt.Rows[0]["ZonCode"]);
                pram[2] = new SqlParameter("@CityCode", dt.Rows[0]["CityCode"]);
                pram[3] = new SqlParameter("@CreatedBy", dt.Rows[0]["ModifiedBy"]);
                pram[4] = new SqlParameter("@SuccessId", 1);
                pram[4].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_ZONEMASTER_INSERT", pram);
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

        public DataTable FetchZonDetails(string ZoneCode)
        {
            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@ZoneCode", ZoneCode);

                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[USP_ZONEMASTER_FETCH_BY_ZONECODE]", pram);
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

        public int UpdateZoneDetail(DataTable dt)
        {
            SqlParameter[] pram = null;
            try
            {
                //Adding the parameters of Insertion stored procedure.
                pram = new SqlParameter[4];
                pram[0] = new SqlParameter("@CountryName", dt.Rows[0]["CountryName"]);
                pram[1] = new SqlParameter("@CityName", dt.Rows[0]["CityName"]);
                pram[2] = new SqlParameter("@ZoneCode", dt.Rows[0]["ZoneCode"]);
                pram[3] = new SqlParameter("@ZoneName", dt.Rows[0]["ZoneName"]);
                pram[4] = new SqlParameter("@ModifiedBy", dt.Rows[0]["ModifiedBy"]);
                pram[5] = new SqlParameter("@SuccessId", 1);
                pram[5].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_ZONEMASTER_UPDATE", pram);
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
                pram[0] = new SqlParameter("@ZoneCode", keyvalue);
                pram[1] = new SqlParameter("@SuccessId", 1);
                pram[1].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_ZONEMASTER_DELETE1", pram);
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




        public DataSet GetZoneCityList()
        {
            DataSet ds = null;

            try
            {
                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, "UspZoneCitymasterFetchList");
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



        public DataSet GetZonList()
        {
            DataSet ds = null;

            try
            {
                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, "USP_ZON_FETCH_LIST");
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

        public DataSet GetZonUpdateList()
        {
            DataSet ds = null;

            try
            {
                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, "USP_ZON_UPDATE_FETCH_LIST");
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

        public int DeletePrevData(string p)
        {

            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[3];
                pram[0] = new SqlParameter("@CityCode", p);
                pram[1] = new SqlParameter("@SuccessId", 1);
                pram[1].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_ZONEMASTER_DELETE_PREV_DATA", pram);
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
