using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DalAdminGroup
    {
        public int InsertAdminGroup(DataTable dt)
        {
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[7];

                pram[0] = new SqlParameter("@GrpName", dt.Rows[0]["Group_Name"]);
                pram[1] = new SqlParameter("@GrpCode", dt.Rows[0]["Group_Code"]);
                pram[2] = new SqlParameter("@GrpStatus", dt.Rows[0]["Group_Status"]);
                pram[3] = new SqlParameter("@CompanyId", dt.Rows[0]["Company_Id"]);
                pram[4] = new SqlParameter("@CreatedBy", dt.Rows[0]["Created_By"]);
                pram[5] = new SqlParameter("@SuccessId", 1);
                pram[5].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspGroupMasterInsert", pram);
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

        public int InsertMainGroup(DataTable dt)
        {
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[4];

                pram[0] = new SqlParameter("@GrpId", dt.Rows[0]["Group_Id"]);
                pram[1] = new SqlParameter("@CompanyId", dt.Rows[0]["Company_Id"]);
                pram[2] = new SqlParameter("@SuccessId", 1);
                pram[2].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspCompanyMainGroupRelationInsert", pram);
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

        public int CheckForMainGroup(string CompanyId)
        {
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[2];
                pram[0] = new SqlParameter("@CompanyId", CompanyId);
                pram[1] = new SqlParameter("@SuccessId", 1);
                pram[1].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspCompanyMainGroupRelationFetch", pram);
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


        /// <summary>
        /// <author>Wasim Karim</author>
        /// <creation date>1 sept 2009</creation>
        /// <purpose>Update in table GroupMaster</purpose>
        /// <summary>
        /// <returns></returns>      
        public int UpdateGroupMaster(DataTable dt)
        {
            SqlParameter[] pram = null;
            try
            {

                pram = new SqlParameter[7];

                pram[0] = new SqlParameter("@GrpId", dt.Rows[0]["Group_Id"]);
                pram[1] = new SqlParameter("@GrpName", dt.Rows[0]["Group_Name"]);
                pram[2] = new SqlParameter("@GrpCode", dt.Rows[0]["Group_Code"]);
                pram[3] = new SqlParameter("@GrpStatus", dt.Rows[0]["Group_Status"]);
                pram[4] = new SqlParameter("@CompanyId", dt.Rows[0]["Company_Id"]);
                pram[5] = new SqlParameter("@ModifiedBy", dt.Rows[0]["Modified_By"]);
                pram[5] = new SqlParameter("@SuccessId", 1);

                pram[6].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspGroupMasterUpdate", pram);


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

        public DataSet GetGroupInfo(string GroupId)
        {
            DataSet ds = null;
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@GrpId", GroupId);
                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, "UspGroupMasterFetchByGrpId", pram);
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

        public DataSet GetGroupInfoFetchByCompanyId(string CompanyId)
        {
            DataSet ds = null;
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@CompanyId", CompanyId);
                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, "UspGroupMasterFetchByCompanyId", pram);
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
        public DataSet GetGroupInfoByCompanyId(string CompanyId, string CurrentLogin)
        {
            DataSet ds = null;
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[2];
                pram[0] = new SqlParameter("@CompanyId", CompanyId);
                pram[1] = new SqlParameter("@CurrentLogin", CurrentLogin);
                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, "UspGroupMasterFetch", pram);

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

        public int DeleteDataRow(int keyvalue)
        {
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[2];
                pram[0] = new SqlParameter("@GrpId", keyvalue);
                pram[1] = new SqlParameter("@SuccessId", 1);
                pram[1].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspGroupMasterDelete", pram);
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
