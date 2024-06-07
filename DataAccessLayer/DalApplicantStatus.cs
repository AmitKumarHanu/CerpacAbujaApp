using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DalApplicantStatus
    {
        public DataTable GetApplicantStatusList(string L1id )
        {
            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
           {
               pram = new SqlParameter[1];
               pram[0] = new SqlParameter("@UserId",L1id);

               objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[UspApplicantStatusFetchList]", pram);

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

        public DataTable GetApplicantStatusById(string ApplicationId)
        {
            SqlParameter[] pram = null;
            DataSet ds = null;
            try
            {
                pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@ApplicationId", ApplicationId);

                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[UspApplicantStatusFetchListByApplicationId]", pram);

                return ds.Tables[0];
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

        public DataTable GetApplicantStatusListPreview(string PassportNo, string Nationality, string AppID)
        {
            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[3];
                pram[0] = new SqlParameter("@PassportNo", PassportNo);
                pram[1] = new SqlParameter("@Nationality", Nationality);
                pram[2] = new SqlParameter("@ApplicationID", AppID);
                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[UspApplicantStatusFetchListPreview]", pram);

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

        public int DeleteDataRow(int keyvalue)
        {
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[2];
                pram[0] = new SqlParameter("@TransactionId", keyvalue);
                pram[1] = new SqlParameter("@SuccessId", 1);
                pram[1].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspApplicantStatusMasterDelete", pram);
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
        //-----------------------------------by chitresh --------------------------------
        public DataTable GetApplicantStatusList1(string L1id)
        {
            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                // pram = new SqlParameter[1];
                //pram[0] = new SqlParameter("@UserId", L1id);

                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[UspApplicantStatusFetchListCommandCenter]", pram);

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
        //--------------------------end--------------------------------
        public DataTable GetApplicantStatusListApprovedVisa(string L1id)
        {
            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                // pram = new SqlParameter[1];
                //pram[0] = new SqlParameter("@UserId", L1id);

                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[UspApplicantStatusApporvedFetchListCommandCenter]", pram);

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
