using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DalSystemSettingDetails
    {

        public DataSet GetSystemSettingList()
        {
            DataSet ds = null;

            try
            {
                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, "UspSystemSettingFetchList");
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

        public int InsertSystemSettingDetail(DataTable dt)
        {
            SqlParameter[] pram = null;
            try
            {
                //Adding the parameters of Insertion stored procedure.
                pram = new SqlParameter[5];
                pram[0] = new SqlParameter("@Code", dt.Rows[0]["Code"]);
                pram[1] = new SqlParameter("@Value", dt.Rows[0]["Value"]);
                pram[2] = new SqlParameter("@ShortDesc", dt.Rows[0]["ShortDesc"]);
                //pram[3] = new SqlParameter("@DateOfExpiry", dt.Rows[0]["DateOfExpiry"]);
                //pram[4] = new SqlParameter("@Nationality", dt.Rows[0]["Nationality"]);
                //pram[5] = new SqlParameter("@PassportType", dt.Rows[0]["PassportType"]);
                pram[3] = new SqlParameter("@CreatedBy", dt.Rows[0]["ModifiedBy"]);
                pram[4] = new SqlParameter("@SuccessId", 1);
                pram[4].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_SYSTEMSETTING_INSERT", pram);
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

        public DataTable FetchSystemSettingDetails(string SystemSettingID)
        {
            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@SystemSettingID", SystemSettingID);

                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_SystemSettingMaster_FETCH_BY_System", pram);
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

        public int UpdateSystemSettingDetail(DataTable dt)
        {
            SqlParameter[] pram = null;
            try
            {
                //Adding the parameters of Insertion stored procedure.
                pram = new SqlParameter[6];
                pram[0] = new SqlParameter("@Code", dt.Rows[0]["Code"]);
                pram[1] = new SqlParameter("@Value", dt.Rows[0]["Value"]);
                pram[2] = new SqlParameter("@ShortDesc", dt.Rows[0]["ShortDesc"]);
                pram[3] = new SqlParameter("@SystemSettingMasterID", dt.Rows[0]["SystemSettingMasterID"]);
                // pram[4] = new SqlParameter("@DateOfExpiry", dt.Rows[0]["DateOfExpiry"]);
                //pram[5] = new SqlParameter("@Nationality", dt.Rows[0]["Nationality"]);
                // pram[6] = new SqlParameter("@PassportType", dt.Rows[0]["PassportType"]);
                //pram[4] = new SqlParameter("@Status", dt.Rows[0]["Status"]);
                pram[4] = new SqlParameter("@ModifiedBy", dt.Rows[0]["ModifiedBy"]);

                pram[5] = new SqlParameter("@SuccessId", 1);
                pram[5].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_SystemSetting_UPDATE", pram);
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

        public int DeleteDataRow(String keyvalue)
        {
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[2];
                pram[0] = new SqlParameter("@SystemSettingID", keyvalue);
                pram[1] = new SqlParameter("@SuccessId", 1);
                pram[1].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_SystemSetting_DELETE", pram);
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
