using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DalVisaTypeDetails
    {
        public DataSet GetVisaTypeList()
        {
            DataSet ds = null;

            try
            {
                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, "USP_VISATYPEMASTER_FETCH_LIST");
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

        public int InsertVisaTypeDetail(DataTable dt)
        {
            SqlParameter[] pram = null;
            try
            {
                //Adding the parameters of Insertion stored procedure.
                pram = new SqlParameter[7];
                pram[0] = new SqlParameter("@VisaTypeCode", dt.Rows[0]["VisaTypeCode"]);
                pram[1] = new SqlParameter("@SVisaTypeName", dt.Rows[0]["SVisaTypeName"]);
                pram[2] = new SqlParameter("@VisaTypeName", dt.Rows[0]["VisaTypeName"]);
                pram[3] = new SqlParameter("@Status", dt.Rows[0]["Status"]);
                pram[4] = new SqlParameter("@CreatedBy", dt.Rows[0]["CreatedBy"]);
                pram[5] = new SqlParameter("@flagEmove", dt.Rows[0]["flagEmove"]);

                pram[6] = new SqlParameter("@SuccessId", 1);
                pram[6].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_VISATYPEMASTER_INSERT", pram);
                return int.Parse(pram[6].Value.ToString());

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

        public DataTable FetchVisaTypeDetails_VisaTypeCode(string VisaTypeCode)
        {
            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@VisaTypeCode", VisaTypeCode);

                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[USP_VISATYPEMASTER_FETCH_BY_VISATYPECODE]", pram);
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

        public int UpdateVisaTypeDetail(DataTable dt)
        {
            SqlParameter[] pram = null;
            try
            {
                //Adding the parameters of Insertion stored procedure.
                pram = new SqlParameter[7];
                pram[0] = new SqlParameter("@VisaTypeCode", dt.Rows[0]["VisaTypeCode"]);
                pram[1] = new SqlParameter("@SVisaTypeName", dt.Rows[0]["SVisaTypeName"]);
                pram[2] = new SqlParameter("@VisaTypeName", dt.Rows[0]["VisaTypeName"]);
                pram[3] = new SqlParameter("@Status", dt.Rows[0]["Status"]);
                pram[4] = new SqlParameter("@ModifiedBy", dt.Rows[0]["ModifiedBy"]);
                pram[5] = new SqlParameter("@flagEmove", dt.Rows[0]["flagEmove"]);
                pram[6] = new SqlParameter("@SuccessId", 1);
                pram[6].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_VISATYPEMASTER_UPDATE", pram);
                return int.Parse(pram[6].Value.ToString());

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
                pram[0] = new SqlParameter("@VisaTypeCode", keyvalue);
                pram[1] = new SqlParameter("@SuccessId", 1);
                pram[1].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_VISATYPEMASTER_DELETE", pram);
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


        public DataSet GetDocList()
        {
            DataSet ds = null;

            try
            {
                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, "USP_DOC_FETCH_LIST");
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

        //public int DeletePrevDoc(string p, string VisaTypeCode)
        //{
        //    SqlParameter[] pram = null;
        //    try
        //    {
        //        pram = new SqlParameter[2];
               
        //        pram[0] = new SqlParameter("@VisaTypeCode", VisaTypeCode);
        //        pram[1] = new SqlParameter("@SuccessId", 1);
        //        pram[1].Direction = ParameterDirection.Output;
        //        SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_VISATYPEDOC_DOC_DELETE_FOR_UPDATE", pram);
        //        return int.Parse(pram[1].Value.ToString());

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        pram = null;
        //    }
        //}

        public int InsertDocUpdated(DataTable dt)
        {
            SqlParameter[] pram = null;
            try
            {
                //Adding the parameters of Insertion stored procedure.
                pram = new SqlParameter[5];
                pram[0] = new SqlParameter("@VisaTypeCode", dt.Rows[0]["VisaTypeCode"]);
                pram[1] = new SqlParameter("@DocCode", dt.Rows[0]["DocCode"]);
                //pram[2] = new SqlParameter("@VisaTypeName", dt.Rows[0]["VisaTypeName"]);
                //pram[3] = new SqlParameter("@Status", dt.Rows[0]["Status"]);
                pram[2] = new SqlParameter("@CreatedBy", dt.Rows[0]["CreatedBy"]);
                pram[3] = new SqlParameter("@FlagMmendatory", dt.Rows[0]["FlagMmendatory"]);
                //   pram[5] = new SqlParameter("@DocCode", dt.Rows[0]["DocCode"]);

                pram[4] = new SqlParameter("@SuccessId", 1);
                pram[4].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_INSERT_DOC_UPDATED", pram);
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

        public DataSet GetActivityList()
        {
            DataSet ds = null;

            try
            {
                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, "USP_ACTIVITY_FETCH_LIST");
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

        public int InsertWorkFlow(DataTable dt)
        {
            SqlParameter[] pram = null;
            try
            {
                //Adding the parameters of Insertion stored procedure.
                pram = new SqlParameter[6];
                pram[0] = new SqlParameter("@WorkCenterMasterId", dt.Rows[0]["WorkCenterMasterId"]);
                pram[1] = new SqlParameter("@StepId", dt.Rows[0]["StepId"]);
                pram[2] = new SqlParameter("@DisplayActivityName", dt.Rows[0]["DisplayActivityName"]);
                pram[3] = new SqlParameter("@ActivityMasterID", dt.Rows[0]["ActivityMasterID"]);
                pram[4] = new SqlParameter("@VisaTypeCode", dt.Rows[0]["VisaTypeCode"]);
                // pram[5] = new SqlParameter("@flagEmove", dt.Rows[0]["flagEmove"]);

                pram[5] = new SqlParameter("@SuccessId", 1);
                pram[5].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_VISATYPEMASTERWORKFLOW_INSERT", pram);
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

        public int DeleteWorkFlowForUpdation(string p)
        {
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[2];
                pram[0] = new SqlParameter("@VisaTypeCode", p);
                pram[1] = new SqlParameter("@SuccessId", 1);
                pram[1].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_WORKFLOW_DELETE_FOR_UPDATE", pram);
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

        public int DeletePrevDoc(string VisaTypeCode)
        {
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[2];

                pram[0] = new SqlParameter("@VisaTypeCode", VisaTypeCode);
                pram[1] = new SqlParameter("@SuccessId", 1);
                pram[1].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_VISATYPEDOC_DOC_DELETE_FOR_UPDATE", pram);
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
