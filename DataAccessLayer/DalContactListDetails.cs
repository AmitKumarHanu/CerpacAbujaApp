using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DalContactListDetails
    {

        public DataSet GetContactList(string strStatus)
        {
            DataSet ds = null;
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@Status", strStatus);

                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, "UspContactFetchList", pram);
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

        public int ViewContactDetail(DataTable dt)
        {
            SqlParameter[] pram = null;
            try
            {
                //Adding the parameters of Insertion stored procedure.
                pram = new SqlParameter[4];
                pram[0] = new SqlParameter("@QueryId", dt.Rows[0]["QueryId"]);
                pram[1] = new SqlParameter("@UserID", dt.Rows[0]["UserID"]);
                pram[2] = new SqlParameter("@Message", dt.Rows[0]["Message"]);

                //pram[3] = new SqlParameter("@DateOfExpiry", dt.Rows[0]["DateOfExpiry"]);
                //pram[4] = new SqlParameter("@Nationality", dt.Rows[0]["Nationality"]);
                // pram[5] = new SqlParameter("@PassportType", dt.Rows[0]["PassportType"]);
                pram[3] = new SqlParameter("@SuccessId", 1);
                pram[3].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_CONTACT_INSERT", pram);
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

        public DataTable FetchContactDetails(int QueryId)
        {
            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@QueryId", QueryId);

                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[USP_ContactMaster_FETCH_BY_Contact]", pram);
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
    }

}

