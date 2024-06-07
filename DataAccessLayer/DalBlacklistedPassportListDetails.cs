using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DalBlacklistedPassportListDetails
    {

        public DataSet GetBlacklistedPassportList()
        {
            DataSet ds = null;

            try
            {
                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, "UspBlacklistedPassportFetchList");
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

        public int InsertBlacklistedPassportDetail(DataTable dt)
        {
            SqlParameter[] pram = null;
            try
            {
                //Adding the parameters of Insertion stored procedure.
                pram = new SqlParameter[8];
                pram[0] = new SqlParameter("@PassportName", dt.Rows[0]["PassportName"]);
                pram[1] = new SqlParameter("@PassportNumber", dt.Rows[0]["PassportNumber"]);
                pram[2] = new SqlParameter("@DateOfIssue", dt.Rows[0]["DateOfIssue"]);
                pram[3] = new SqlParameter("@DateOfExpiry", dt.Rows[0]["DateOfExpiry"]);
                pram[4] = new SqlParameter("@Nationality", dt.Rows[0]["Nationality"]);
                pram[5] = new SqlParameter("@PassportType", dt.Rows[0]["PassportType"]);
                pram[6] = new SqlParameter("@CreatedBy", dt.Rows[0]["ModifiedBy"]);
                pram[7] = new SqlParameter("@SuccessId", 1);
                pram[7].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_BLACKLISTEDPASSPORT_INSERT", pram);
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

        public DataTable FetchBlacklistedPassportDetails(int BlacklistedPassportID)
        {
            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@BlacklistedPassportID", BlacklistedPassportID);

                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[USP_BlacklistedPassportMaster_FETCH_BY_Blacklisted]", pram);
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

        public int UpdateBlacklistedPassportDetail(DataTable dt)
        {
            SqlParameter[] pram = null;
            try
            {
                //Adding the parameters of Insertion stored procedure.
                pram = new SqlParameter[9];
                pram[0] = new SqlParameter("@PassportName", dt.Rows[0]["PassportName"]);
                pram[1] = new SqlParameter("@PassportNumber", dt.Rows[0]["PassportNumber"]);
                pram[2] = new SqlParameter("@DateOfIssue", dt.Rows[0]["DateOfIssue"]);
                pram[3] = new SqlParameter("@BlacklistedID", dt.Rows[0]["BlacklistedID"]);
                pram[4] = new SqlParameter("@DateOfExpiry", dt.Rows[0]["DateOfExpiry"]);
                pram[5] = new SqlParameter("@Nationality", dt.Rows[0]["Nationality"]);
                pram[6] = new SqlParameter("@PassportType", dt.Rows[0]["PassportType"]);
                //pram[4] = new SqlParameter("@Status", dt.Rows[0]["Status"]);
                pram[7] = new SqlParameter("@ModifiedBy", dt.Rows[0]["ModifiedBy"]);

                pram[8] = new SqlParameter("@SuccessId", 1);
                pram[8].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_BlacklistedPassport_UPDATE", pram);
                return int.Parse(pram[8].Value.ToString());

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
                pram[0] = new SqlParameter("@BlacklistedPassportID", keyvalue);
                pram[1] = new SqlParameter("@SuccessId", 1);
                pram[1].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_BlacklistedPassport_DELETE", pram);
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
