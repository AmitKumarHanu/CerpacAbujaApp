using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DalDocdetails
    {

        public DataSet GetdocList()
        {
            DataSet ds = null;

            try
            {
                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, "UspDocumentmasterFetchList");
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

        public int InsertdocDetail(DataTable dt)
        {
            SqlParameter[] pram = null;
            try
            {
                //Adding the parameters of Insertion stored procedure.
                pram = new SqlParameter[5];
                pram[0] = new SqlParameter("@DocCode", dt.Rows[0]["DocCode"]);
                pram[1] = new SqlParameter("@DocName", dt.Rows[0]["DocName"]);
                pram[2] = new SqlParameter("@DocDesc", dt.Rows[0]["DocDesc"]);

                pram[3] = new SqlParameter("@CreatedBy", dt.Rows[0]["ModifiedBy"]);

                pram[4] = new SqlParameter("@SuccessId", 1);
                pram[4].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_DOCUMENTMASTER_INSERT", pram);
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

        public DataTable FetchDocDetails(string DocCode)
        {
            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@DocCode", DocCode);

                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[USP_DOCUMENTMASTER_FETCH_BY_DOCCODE]", pram);
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

        public int UpdateDocDetail(DataTable dt)
        {
            SqlParameter[] pram = null;
            try
            {
                //Adding the parameters of Insertion stored procedure.
                pram = new SqlParameter[5];
                pram[0] = new SqlParameter("@DocCode", dt.Rows[0]["docCode"]);
                pram[1] = new SqlParameter("@DocName", dt.Rows[0]["DocName"]);
                pram[2] = new SqlParameter("@DocDesc", dt.Rows[0]["DocDesc"]);
                pram[3] = new SqlParameter("@ModifiedBy", dt.Rows[0]["ModifiedBy"]);

                pram[4] = new SqlParameter("@SuccessId", 1);
                pram[4].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_DOCUMENTMASTER_UPDATE", pram);
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
                pram[0] = new SqlParameter("@DocCode", keyvalue);
                pram[1] = new SqlParameter("@SuccessId", 1);
                pram[1].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_DOCUMENTMASTER_DELETE", pram);
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


// ==============================================by chitresh for CERPAC==============================================================
        //**************************************** Designation Master Insert ***********************************************

        public int InsertDesignation(DataTable dt)
        {
            SqlParameter[] pram = null;
            try
            {
                //Adding the parameters of Insertion stored procedure.
                pram = new SqlParameter[3];
                pram[0] = new SqlParameter("@designame", dt.Rows[0]["designame"]);
                pram[1] = new SqlParameter("@createdby", dt.Rows[0]["createdby"]);
                pram[2] = new SqlParameter("@SuccessId", 1);
                pram[2].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_DESIGNATIONMASTER_INSERT", pram);
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

        //*************************************************end*************************************************************
        //******************************************************designation master update*********************************************
        public int UpdateDesignation(DataTable dt)
        {
            SqlParameter[] pram = null;
            try
            {
                //Adding the parameters of Insertion stored procedure.
                pram = new SqlParameter[4];
                pram[0] = new SqlParameter("@designame", dt.Rows[0]["designame"]);
                pram[1] = new SqlParameter("@desigCode", dt.Rows[0]["desigCode"]);
                pram[2] = new SqlParameter("@createdby", dt.Rows[0]["createdby"]);
                pram[3] = new SqlParameter("@SuccessId", 1);
                pram[3].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_DESIGNATIONMASTER_UPDATE", pram);
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
        //***************************************************************end*****************************************************
        //=================================================================end ============================================================

       
    }
}
