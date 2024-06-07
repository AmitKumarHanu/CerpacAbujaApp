using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DalAdminDocType
    {
        public int InsertDocTypeGroup(string DocTypeName,bool IsActive, string companyId )
        {
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[4];

                pram[0] = new SqlParameter("@DocTypeName", DocTypeName);
                pram[1] = new SqlParameter("@IsActive", IsActive);
                pram[2] = new SqlParameter("@companyId", companyId);
                pram[3] = new SqlParameter("@SuccessId", 1);
                pram[3].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspDocTypeInsert", pram);
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

      
        

        /// <summary>
        /// <author>Wasim Karim</author>
        /// <creation date>1 sept 2009</creation>
        /// <purpose>Update in table GroupMaster</purpose>
        /// <summary>
        /// <returns></returns>      
        public int UpdateDocType(string DocTypeNo, string DocTypeName, string CompanyId, bool IsActive)
        {
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[5];

                pram[0] = new SqlParameter("@DocTypeNo", DocTypeNo);
                pram[1] = new SqlParameter("@DocTypeName", DocTypeName);
                pram[2] = new SqlParameter("@CompanyId", CompanyId);
                pram[3] = new SqlParameter("@IsActive", IsActive);                
                pram[4] = new SqlParameter("@SuccessId", 1);

                pram[4].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspDocTypeUpdate", pram);


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

        public DataSet GetDocumentTypeInfo(string DocTypeNo)
        {
            DataSet ds = null;
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@DocTypeNo", DocTypeNo);
                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, "UspDocTypeFetchByDocTypeNo", pram);
                return ds;
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

        public DataTable GetDocTypeFetchByCompanyId(string CompanyId)
        {
            DataSet ds = null;
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@CompanyId", CompanyId);
                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, "UspDocTypeFetchByCompanyId", pram);
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


        public int InsertUserHierarchy(string DocTypeNo, string Originator, string Receiver, string ProcessId, string NotifyDays, string LevelNo, string CreatedBy)
        {
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[8];

                pram[0] = new SqlParameter("@DocTypeNo", DocTypeNo);
                pram[1] = new SqlParameter("@Originator", Originator);
                pram[2] = new SqlParameter("@Receiver", Receiver);
                pram[3] = new SqlParameter("@ProcessId", ProcessId);
                pram[4] = new SqlParameter("@NotifyDays", NotifyDays);
                pram[5] = new SqlParameter("@LevelNo", LevelNo);
                pram[6] = new SqlParameter("@CreatedBy", CreatedBy);
                pram[7] = new SqlParameter("@SuccessId", 1);
                pram[7].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspUserHierarchyInsert", pram);
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

        public DataTable GetUserHierarchyListByDocTypeNo(string DocTypeNo)
        {
            DataSet ds = null;
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@DocTypeNo", DocTypeNo);
                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, "UspUserHierarchyFetchByDocTypeNo", pram);
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

        public int UpdateUserHierarchy(string Id, string DocTypeNo, string Originator, string Receiver, string ProcessId, string NotifyDays, string LevelNo, string ModifyBy)
        {
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[9];

                pram[0] = new SqlParameter("@Id", Id);
                pram[1] = new SqlParameter("@DocTypeNo", DocTypeNo);
                pram[2] = new SqlParameter("@Originator", Originator);
                pram[3] = new SqlParameter("@Receiver", Receiver);
                pram[4] = new SqlParameter("@ProcessId", ProcessId);
                pram[5] = new SqlParameter("@NotifyDays", NotifyDays);
                pram[6] = new SqlParameter("@LevelNo", LevelNo);
                pram[7] = new SqlParameter("@ModifyBy", ModifyBy);
                pram[8] = new SqlParameter("@SuccessId", 1);
                pram[8].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspUserHierarchyUpdate", pram);
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

        public DataTable GetUserHierarchyInfoByID(string Id)
        {
            DataSet ds = null;
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@Id", Id);
                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, "UspUserHierarchyFetchById", pram);
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
    }
}
