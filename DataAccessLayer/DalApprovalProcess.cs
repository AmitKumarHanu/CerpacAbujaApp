using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DalApprovalProcess
    {

        public DataTable GetApplicationListByUserID(string UserID)
        {
            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@UserId", UserID);

                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[USPVisaAppGetAllActivitiesByUserIDForView]", pram);

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

        public DataTable GetApplicationListByAppID(string UserID, string ApplicationID)
        {
            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[2];
                pram[0] = new SqlParameter("@UserId", UserID);
                pram[1] = new SqlParameter("@ApplicationID", ApplicationID);

                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[USPVisaApplicationFetchByAppID]", pram);

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

        public DataTable GetApplicationDetails(string ApplicationID)
        {
            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@ApplicationID", ApplicationID);

                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[USPFetchApplicationDetails]", pram);
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

        public DataTable GetAllActivitiesByUserID(string UserID, string ApplicationID)
        {
            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[2];
                pram[0] = new SqlParameter("@UserID", UserID);
                pram[1] = new SqlParameter("@ApplicationID", ApplicationID);

                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[USPVisaApplicationGetAllActivitiesByUserID]", pram);
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

        public int UpdateApplicationWorkFlow(DataTable dt)
        {
            SqlParameter[] pram = null;
            //try
            //{
                //Adding the parameters of Insertion stored procedure.
                pram = new SqlParameter[8];
                pram[0] = new SqlParameter("@ApplicationID", dt.Rows[0]["ApplicationID"]);
                pram[1] = new SqlParameter("@StepId", dt.Rows[0]["StepId"]);
                pram[2] = new SqlParameter("@ActivityCode", dt.Rows[0]["ActivityCode"]);
                pram[3] = new SqlParameter("@FlagActivityStatus", dt.Rows[0]["FlagActivityStatus"]);
                pram[4] = new SqlParameter("@Comments", dt.Rows[0]["Comments"]);
                pram[5] = new SqlParameter("@UserID", dt.Rows[0]["UserID"]);
                pram[6] = new SqlParameter("@FileName", dt.Rows[0]["strFileName"]);
               

                pram[7] = new SqlParameter("@SuccessId", 1);
                pram[7].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USPUpdateApplicationWorkFlow", pram);
                return int.Parse(pram[7].Value.ToString());

            //}
            //catch (Exception ex)
            //{
            //    throw (ex);
            //}
            //finally
            //{
            //    pram = null;

            //}
        }

        public int UpdateApplicationForImg(DataTable dt)
        {
            SqlParameter[] pram = null;
            //try
            //{
            //Adding the parameters of Insertion stored procedure.
            pram = new SqlParameter[3];
            pram[0] = new SqlParameter("@ApplicationID", dt.Rows[0]["ApplicationID"]);
            pram[1] = new SqlParameter("@USERID", dt.Rows[0]["USERID"]);        
            pram[2] = new SqlParameter("@SuccessId", 1);
            pram[2].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USPVarifyByIMG", pram);
            return int.Parse(pram[2].Value.ToString());

            //}
            //catch (Exception ex)
            //{
            //    throw (ex);
            //}
            //finally
            //{
            //    pram = null;

            //}
        }

        public int UpdateApplicationForRejection(DataTable dt)
        {
            SqlParameter[] pram = null;
            //try
            //{
            //Adding the parameters of Insertion stored procedure.
            pram = new SqlParameter[4];
            pram[0] = new SqlParameter("@ApplicationID", dt.Rows[0]["ApplicationID"]);
            pram[1] = new SqlParameter("@RejectionCode", dt.Rows[0]["RejectionCode"]);
            pram[2] = new SqlParameter("@RejectionDesc", dt.Rows[0]["RejectionDesc"]);
            pram[3] = new SqlParameter("@SuccessId", 1);
            pram[3].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USPUpdateApplicationForRejection", pram);
            return int.Parse(pram[3].Value.ToString());

            //}
            //catch (Exception ex)
            //{
            //    throw (ex);
            //}
            //finally
            //{
            //    pram = null;

            //}
        }
    }
}
