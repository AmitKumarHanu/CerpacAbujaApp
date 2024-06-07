using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace DataAccessLayer
{
    public class DalAdminKeyword
    {
        public DataTable BindGrid(string CompanyId)
        {

            SqlParameter[] pram = null;
            DataSet objDs = null;
            DataTable dt = null;
            try
            {
                pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@CompanyId", CompanyId);
                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspDocIdentifierMasterFetchByCompanyId", pram);
                dt = objDs.Tables[0];

                return dt;

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
        
        public DataTable BindGridByIdentifier(string UserId,string IdentifierId)
        {

            SqlParameter[] pram = null;
            DataSet objDs = null;
            DataTable dt = null;
            try
            {
                pram = new SqlParameter[2];
                pram[0] = new SqlParameter("@IdentifierId", IdentifierId);
                pram[1] = new SqlParameter("@UserId", UserId);
                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspDocIdentifierRelationSearchByIdentifierId", pram);
                dt = objDs.Tables[0];

                return dt;

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
        public DataTable Fetch_DocIdentifier(string IdentifierId)
        {
            SqlParameter[] pram = null;
            DataSet  ds = null;
            try
            {
                ds = new DataSet();
                pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@IdentifierId", IdentifierId);
                ds =SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspDocIdentifierMasterFetch", pram);
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
        public void Insert_DocIdentifier(string Identifier, string CompanyId)
        {
            SqlParameter[] pram = null;
      
            try
            {
                pram = new SqlParameter[2];
                pram[0] = new SqlParameter("@Identifier", Identifier);
                pram[1] = new SqlParameter("@CompanyId", CompanyId);
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspDocIdentifierMasterInsert", pram);

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

        public void Update_DocIdentifier(string Identifier, string CompanyId, string IdentifierId)
        {
            SqlParameter[] pram = null;

            try
            {
                pram = new SqlParameter[3];
                pram[0] = new SqlParameter("@Identifier", Identifier);
                pram[1] = new SqlParameter("@CompanyId", CompanyId);
                pram[2] = new SqlParameter("@IdentifierId", IdentifierId);
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspDocIdentifierMasterUpdate", pram);

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
