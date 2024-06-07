using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DalAdminModule
    {

        /// <summary>
        /// <author>Wasim Karim</author>
        /// <creation date>3 sept 2009</creation>
        /// <purpose>Insert into table ModuleMaster</purpose>
        /// <summary>
        /// <returns></returns> 
        public int InsertAdminModule(DataTable dt)
        {
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[6];

                pram[0] = new SqlParameter("@ModName", dt.Rows[0]["Module_Name"]);
                pram[1] = new SqlParameter("@ModStatus", dt.Rows[0]["Module_Status"]);
                pram[2] = new SqlParameter("@CompanyId", dt.Rows[0]["Company_Id"]);
                pram[3] = new SqlParameter("@CreatedBy", dt.Rows[0]["Created_By"]);
                pram[4] = new SqlParameter("@SuccessId", 1);
                pram[4].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspModuleMasterInsert", pram);
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

        /// <summary>
        /// <author>Wasim Karim</author>
        /// <creation date>3 sept 2009</creation>
        /// <purpose>Update in table ModuleMaster</purpose>
        /// <summary>
        /// <returns></returns>      
        public int UpdateModuleMaster(DataTable dt)
        {
            SqlParameter[] pram = null;
            try
            {

                pram = new SqlParameter[6];

                pram[0] = new SqlParameter("@ModId", dt.Rows[0]["Module_Id"]);
                pram[1] = new SqlParameter("@ModName", dt.Rows[0]["Module_Name"]);
                pram[2] = new SqlParameter("@ModStatus", dt.Rows[0]["Module_Status"]);
                pram[3] = new SqlParameter("@CompanyId", dt.Rows[0]["Company_Id"]);
                pram[4] = new SqlParameter("@ModifiedBy", dt.Rows[0]["Modified_By"]);
                pram[5] = new SqlParameter("@SuccessId", 1);

                pram[5].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspModuleMasterUpdate", pram);


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

        public DataSet GetModuleInfo(string Module_Id)
        {
            DataSet ds = null;
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@ModId", Module_Id);
                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, "UspModuleMasterFetchByModId", pram);
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

        public DataTable GetUnAssociatedFormModuleList(string FormId,string CompanyId)
        {
            DataSet ds = null;
            
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[2];
                pram[0] = new SqlParameter("@FormId", FormId);
                pram[1] = new SqlParameter("@CompanyId", CompanyId);
                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, "UspListUnAssociatedFormModuleRelationFetchByFormId", pram);
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
        public DataTable GetAssociatedFormModuleList(string FormId, string CompanyId)
        {
            DataSet ds = null;

            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[2];
                pram[0] = new SqlParameter("@FormId", FormId);
                pram[1] = new SqlParameter("@CompanyId", CompanyId);
                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, "UspListAssociatedFormModuleRelationFetchByFormId", pram);
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

        public int DeleteDataRow(int keyvalue)
        {
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[2];
                pram[0] = new SqlParameter("@ModId", keyvalue);
                pram[1] = new SqlParameter("@SuccessId", 1);
                pram[1].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspModuleMasterDelete", pram);
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
