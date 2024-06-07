using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DalZoneDetails
    {

        public DataSet GetZoneList()
        {

            DataSet ds = null;
            ds = new DataSet();

            try
            {
                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, "UspZoneMasterFetchList1");
                //dt = ds.Tables[0];
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
                pram = new SqlParameter[8];
                pram[0] = new SqlParameter("@ZoneCode", dt.Rows[0]["ZoneCode"]);
                pram[1] = new SqlParameter("@ZoneDesc", dt.Rows[0]["ZoneDesc"]);
                pram[2] = new SqlParameter("@ZoneFullName", dt.Rows[0]["ZoneFullName"]);
                pram[3] = new SqlParameter("@Address", dt.Rows[0]["Address"]);
                pram[4] = new SqlParameter("@ZonalOfficer", dt.Rows[0]["ZonalOfficer"]);
                pram[5] = new SqlParameter("@EmailID", dt.Rows[0]["EmailID"]);
                pram[6] = new SqlParameter("@MobileNo", dt.Rows[0]["MobileNo"]);
                // pram[7] = new SqlParameter("@EACFlag", dt.Rows[0]["EACFlag"]);

                pram[7] = new SqlParameter("@SuccessId", 1);
                pram[7].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_ZONEMASTER_INSERT1", pram);
                return int.Parse(pram[7].Value.ToString());

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

        public DataTable FetchZoneDetails_ZoneCode(string ZoneCode)
        {
            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@ZoneCode", ZoneCode);

                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[USP_ZONEMASTER_FETCH_BY_ZONECODE1]", pram);
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
                pram = new SqlParameter[8];
                pram[0] = new SqlParameter("@ZoneCode", dt.Rows[0]["ZoneCode"]);
                pram[1] = new SqlParameter("@ZoneDesc", dt.Rows[0]["ZoneDesc"]);
                pram[2] = new SqlParameter("@ZoneFullName", dt.Rows[0]["ZoneFullName"]);
                pram[3] = new SqlParameter("@Address", dt.Rows[0]["Address"]);
                pram[4] = new SqlParameter("@ZonalOfficer", dt.Rows[0]["ZonalOfficer"]);
                pram[5] = new SqlParameter("@EmailID", dt.Rows[0]["EmailID"]);
                pram[6] = new SqlParameter("@MobileNo", dt.Rows[0]["MobileNo"]);
                //pram[6] = new SqlParameter("@EACFlag", dt.Rows[0]["EACFlag"]);

                pram[7] = new SqlParameter("@SuccessId", 1);
                pram[7].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_ZONEMASTER_UPDATE1", pram);
                return int.Parse(pram[7].Value.ToString());

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
                pram[0] = new SqlParameter("@ZoneCode", keyvalue);
                pram[1] = new SqlParameter("@SuccessId", 1);
                pram[1].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_ZoneMASTER_DELETE", pram);
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
