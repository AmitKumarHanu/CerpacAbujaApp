using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DalApprovalL1
    {
        public DataTable GetDalVisaPandingList(string L1id)
        {
            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@USERID", L1id);

                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[USP_VISA_PENDINGLIST_FETCH_BY_APPLICATIONID_VISATYPE]", pram);

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
        //================================BY CHITRESH ====================
        public DataTable GetDalVisaApprovedList(string L1id)
        {
            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@USERID", L1id);

                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[USP_VISA_APPROVEDLIST_BY_NIS]", pram);

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




        public int ForwardToCC(DataTable dt)
        {
            {
                SqlParameter[] pram = null;
                try
                {
                    //Adding the parameters of Insertion stored procedure.
                    pram = new SqlParameter[3];
                    pram[0] = new SqlParameter("@ApplicationId", dt.Rows[0]["ApplicationId"]);
                    // pram[1] = new SqlParameter("@APPROVER1STATUS", dt.Rows[0]["APPROVER1STATUS"]);
                    //  pram[2] = new SqlParameter("@APPROVER1COMMENTS", dt.Rows[0]["APPROVER1COMMENTS"]);
                    //  pram[3] = new SqlParameter("@Rejection_Code", dt.Rows[0]["Rejection_Code"]);
                    pram[1] = new SqlParameter("@id", dt.Rows[0]["id"]);
                    //   pram[5] = new SqlParameter("@ModifiedBy", dt.Rows[0]["ModifiedBy"]);
                    // pram[2] = new SqlParameter("@GenerateFileCode", dt.Rows[0]["GenerateFileCode"]);
                    pram[2] = new SqlParameter("@SuccessId", 1);
                    pram[2].Direction = ParameterDirection.Output;
                    SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_FORWARD_TO_CC", pram);
                    return int.Parse(pram[2].Value.ToString());

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
        public DataTable GetDalVisaApprovedList(string ApplicationId, string Userid)
        {
            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[2];
                pram[0] = new SqlParameter("@USERID", Userid);
                pram[1] = new SqlParameter("@ApplicationId", ApplicationId);

                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[USP_FETCH_VISA_APPROVALS_UPLOAD]", pram);

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




        public int InsertApproval(DataTable dt)
        {
            {
                SqlParameter[] pram = null;
                try
                {
                    //Adding the parameters of Insertion stored procedure.
                    pram = new SqlParameter[4];
                    pram[0] = new SqlParameter("@ApplicationId", dt.Rows[0]["ApplicationId"]);
                    //pram[1] = new SqlParameter("@APPROVER1STATUS", dt.Rows[0]["APPROVER1STATUS"]);
                    //  pram[2] = new SqlParameter("@APPROVER1COMMENTS", dt.Rows[0]["APPROVER1COMMENTS"]);
                    //  pram[3] = new SqlParameter("@Rejection_Code", dt.Rows[0]["Rejection_Code"]);
                    pram[1] = new SqlParameter("@id", dt.Rows[0]["id"]);
                    //   pram[5] = new SqlParameter("@ModifiedBy", dt.Rows[0]["ModifiedBy"]);
                    pram[2] = new SqlParameter("@Filename", dt.Rows[0]["Filename"]);
                    pram[3] = new SqlParameter("@SuccessId", 1);
                    pram[3].Direction = ParameterDirection.Output;
                    SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_INSERT_APPROVAL", pram);
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
        }
        public DataTable GetDalIssueVisaList(string ApplicationId, string User_id)
        {
            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[2];
                pram[0] = new SqlParameter("@USERID", User_id);
                pram[1] = new SqlParameter("@ApplicationId", ApplicationId);

                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[USP_FETCH_ISSUE_VISA_LIST]", pram);

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

        public DataTable GetDalIssueVisaListbyApplicationId(string ApplicationId, string User_id)
        {
            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[2];
                pram[0] = new SqlParameter("@USERID", User_id);
                pram[1] = new SqlParameter("@ApplicationId", ApplicationId);

                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[USP_FETCH_ISSUE_VISA_LIST_BY_APPLICATIONID]", pram);

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
        //=====================================END======================




    }
}
