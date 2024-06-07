using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DalAccountUserData
    {

        /// <summary>
        /// <author >Ankit gupta</author>
        /// <created Date>3rd jule 2008</created>
        /// <purpose> Fetch TBL_FORMMASTER for clicked menu item</purpose>
        /// </summary>
        /// <returns></returns>      
        public DataTable Fetch_FormDetail_For_Menu(string MenuItem, string ROLEID)
        {
            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[2];
                pram[0] = new SqlParameter("@MenuItem", MenuItem);
                pram[1] = new SqlParameter("@ROLEID", ROLEID);

                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[USP_TBL_FORMMASTER_FETCH_BY_MENUITEM]", pram);
                objDs.Tables[0].TableName = "FormMaster";
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


        /// <summary>
        /// <author >Ankit gupta</author>
        /// <created Date>9th july 2008</created>
        /// <purpose> Fetch User Detail</purpose>
        /// </summary>
        /// <returns></returns>      
        public DataTable Fetch_USerDetailByUserId(string UserId)
        {
            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@UserId", UserId);

                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspUserMasterFetchByUserId", pram);
                objDs.Tables[0].TableName = "UserMaster";
                return objDs.Tables[0];


            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                pram = null;
                objDs = null;
            }
        }

        public DataTable FetchBorderList()
        {
            DataSet ds = null;
            ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspFetchBorderList");
            ds.Tables[0].TableName = "BorderMaster";
            return ds.Tables[0];
        }
        public DataTable FetchCountryList()
        {
            DataSet ds = null;
            ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspFetchCountryList");
            ds.Tables[0].TableName = "CountryMaster";
            return ds.Tables[0];
        }

        public DataTable Fetch_USerDetailByUserName(string UserName, string Password)
        {
            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[2];
                pram[0] = new SqlParameter("@UserName", UserName);
                pram[1] = new SqlParameter("@Password", Password);
                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspUserMasterFetchByUserName", pram);
                objDs.Tables[0].TableName = "UserMaster";
                return objDs.Tables[0];


            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                pram = null;
                objDs = null;
            }
        }
        /// <summary>
        // By Bimalesh Karn-----09-Aug-2011
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public DataTable Fetch_USerDetailByUserName(string UserName, string Password, string uniqueid)
        {
            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[3];
                pram[0] = new SqlParameter("@UserName", UserName);
                pram[1] = new SqlParameter("@Password", Password);
                pram[2] = new SqlParameter("@uniqueid", uniqueid);
                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspUserMasterFetchByUserNameUniqueid", pram);
                objDs.Tables[0].TableName = "UserMaster";
                return objDs.Tables[0];


            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                pram = null;
                objDs = null;
            }
        }


        public int UpdateVerified(DataTable dt)
        {
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[4];
                pram[0] = new SqlParameter("@LoginID", dt.Rows[0]["LoginID"]);
                pram[1] = new SqlParameter("@Password", dt.Rows[0]["Password"]);
                pram[2] = new SqlParameter("@uniqueid", dt.Rows[0]["UniqueCode"]);
                pram[3] = new SqlParameter("@SuccessId", 1);
                pram[3].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_APPLICANT_VERIFIED_UPDATE", pram);
                return (int.Parse(pram[3].Value.ToString()));
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
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataTable Fetch_UserDetail_by_CompanyId(string CompanyId)
        {
            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@CompanyId", CompanyId);

                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspUserMasterFetchByCompanyId", pram);
                objDs.Tables[0].TableName = "UserMaster";
                return objDs.Tables[0];


            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                pram = null;
                objDs = null;
            }
        }

        public DataTable Fetch_UserDetail_by_GrpId(string GrpId)
        {
            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@GrpId", GrpId);

                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspUserMasterFetchByGroupId", pram);
                objDs.Tables[0].TableName = "UserMaster";
                return objDs.Tables[0];


            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                pram = null;
                objDs = null;
            }
        }

        /// <summary>
        /// <author >Wasim Karim</author>
        /// <created Date>2 Sept 2009</created>
        /// <purpose> Fetch GroupMaster by CompanyId</purpose>
        /// </summary>
        /// <returns></returns> 
        public DataTable Fetch_GroupDetail_by_CompanyId(string CompanyId)
        {
            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@CompanyId", CompanyId);

                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspGroupMasterFetchByCompanyId", pram);
                objDs.Tables[0].TableName = "GroupMaster";
                return objDs.Tables[0];


            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                pram = null;
                objDs = null;
            }
        }

        /// <summary>
        /// <author >Wasim Karim</author>
        /// <created Date>3 Sept 2009</created>
        /// <purpose> Fetch ModuleMaster by CompanyId</purpose>
        /// </summary>
        /// <returns></returns> 
        public DataTable Fetch_ModuleDetail_by_CompanyId(string CompanyId)
        {
            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@CompanyId", CompanyId);

                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspModuleMasterFetchByCompanyId", pram);
                objDs.Tables[0].TableName = "ModuleMaster";
                return objDs.Tables[0];


            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                pram = null;
                objDs = null;
            }
        }

        /// <summary>
        /// <author >Ankit gupta</author>
        /// <created Date>10th july 2008</created>
        /// <purpose> Fetch Home Page Detail</purpose>
        /// </summary>
        /// <returns></returns>      
        public DataTable Fetch_HomePage_content()
        {

            DataSet objDs = null;
            try
            {
                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[USP_TBL_HOMEPAGECONTENT_FTECH]");
                objDs.Tables[0].TableName = "HomepageContent";
                return objDs.Tables[0];


            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                objDs = null;

            }
        }

        public int Insert_UserDetail(DataTable dt)
        {
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[12];

                pram[0] = new SqlParameter("@UserName", dt.Rows[0]["UserName"]);
                pram[1] = new SqlParameter("@Password", dt.Rows[0]["Password"]);
                pram[2] = new SqlParameter("@GrpId", dt.Rows[0]["GrpId"]);
                pram[3] = new SqlParameter("@CompanyId", dt.Rows[0]["CompanyId"]);
                pram[4] = new SqlParameter("@DateOfBirth", dt.Rows[0]["DateOfBirth"]);
                pram[5] = new SqlParameter("@EmailId", dt.Rows[0]["EmailId"]);
                pram[6] = new SqlParameter("@ContactNo", dt.Rows[0]["ContactNo"]);
                pram[7] = new SqlParameter("@Address", dt.Rows[0]["Address"]);
                pram[8] = new SqlParameter("@UserStatus", dt.Rows[0]["UserStatus"]);
                pram[9] = new SqlParameter("@SuccessId", 1);
                pram[9].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspUserMasterInsert", pram);
                return int.Parse(pram[9].Value.ToString());

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public int DeleteDataRow(int keyvalue)
        {
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[2];
                pram[0] = new SqlParameter("@UserId", keyvalue);
                pram[1] = new SqlParameter("@SuccessId", 1);
                pram[1].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspUserMasterDelete", pram);
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

        public int Update_UserDetails(DataTable dt)
        {
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[10];
                pram[0] = new SqlParameter("@UserId", dt.Rows[0]["UserId"]);
                pram[1] = new SqlParameter("@UserName", dt.Rows[0]["UserName"]);
                pram[2] = new SqlParameter("@UserStatus", dt.Rows[0]["Userstatus"]);
                pram[3] = new SqlParameter("@CompanyId", dt.Rows[0]["CompanyId"]);
                pram[4] = new SqlParameter("@GrpId", dt.Rows[0]["GrpId"]);
                pram[5] = new SqlParameter("@DateOfBirth", dt.Rows[0]["DateOfBirth"]);
                pram[6] = new SqlParameter("@EmailId", dt.Rows[0]["EmailId"]);
                pram[7] = new SqlParameter("@ContactNo", dt.Rows[0]["ContactNo"]);
                pram[8] = new SqlParameter("@Address", dt.Rows[0]["Address"]);

                pram[9] = new SqlParameter("@SuccessId", 1);
                pram[9].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspUserMasterUpdate", pram);
                return int.Parse(pram[9].Value.ToString());

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

        public DataTable ForGetPossword(string UserName)
        {
            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[2];
                pram[0] = new SqlParameter("@UserName", UserName);
                pram[1] = new SqlParameter("@SuccessId", 1);
                pram[1].Direction = ParameterDirection.Output;
                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspUserMasterFetchtForForgetPwd", pram);

                objDs.Tables[0].TableName = "UserMaster";
                return objDs.Tables[0];



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                pram = null;
                objDs = null;
            }
        }

        public int UserMasterChangePassword(DataTable dt)
        {
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[5];
                pram[0] = new SqlParameter("@LoginId", dt.Rows[0]["LoginID"]);
                pram[1] = new SqlParameter("@Password", dt.Rows[0]["Password"]);
                pram[2] = new SqlParameter("@NewPassword", dt.Rows[0]["NewPassword"]);
                pram[3] = new SqlParameter("@SuccessId", 1);
                pram[3].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspUserMasterChangePassword", pram);
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

        public DataTable FetchForwarderNameList(string DocId, string UserId, string GrpId)
        {
            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[3];
                pram[0] = new SqlParameter("@DocID", DocId);
                pram[1] = new SqlParameter("@UserID", UserId);
                pram[2] = new SqlParameter("@GrpId", GrpId);

                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspFetchForwaderName", pram);

                objDs.Tables[0].TableName = "ForwarderList";
                return objDs.Tables[0];



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                pram = null;
                objDs = null;
            }
        }


        //===============================by chitresh====================

        public int BlockLoginID(DataTable dt)
        {
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[12];

                pram[0] = new SqlParameter("@BlockUser", dt.Rows[0]["BlockUser"]);
                pram[1] = new SqlParameter("@SuccessId", 1);
                pram[1].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspUserMasterBlockLoginID", pram);
                return int.Parse(pram[1].Value.ToString());

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        //=================================end================================
        //==============================================by chitresh latest=========================================
        public DataTable Fetch_CompanyDetail_by_Loginid(string userName, string password, string uniqueid)
        {
            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[3];
                pram[0] = new SqlParameter("@UserName", userName);
                pram[1] = new SqlParameter("@Password", password);
                pram[2] = new SqlParameter("@uniqueid", uniqueid);
                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspCompanyRegistrationMasterFetchByUserNameUniqueid", pram);
                objDs.Tables[0].TableName = "CompanyRegistrationMaster";
                return objDs.Tables[0];


            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                pram = null;
                objDs = null;
            }
        }



        public int UpdateVerificationofCompany(DataTable dt)
        {
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[4];
                pram[0] = new SqlParameter("@LoginID", dt.Rows[0]["LoginID"]);
                pram[1] = new SqlParameter("@Password", dt.Rows[0]["Password"]);
                pram[2] = new SqlParameter("@uniqueid", dt.Rows[0]["UniqueCode"]);
                pram[3] = new SqlParameter("@SuccessId", 1);
                pram[3].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_COMPANY_VERIFIED_UPDATE", pram);
                return (int.Parse(pram[3].Value.ToString()));
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
        //========================================end=================================================

        public DataTable Fetch_CompanyDetail_by_UserName(string userName, string password)
        {
            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[2];
                pram[0] = new SqlParameter("@UserName", userName);
                pram[1] = new SqlParameter("@Password", password);
                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspCompanyRegistrationFetchByUserName", pram);
                objDs.Tables[0].TableName = "CompanygistrationMaster";
                return objDs.Tables[0];


            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                pram = null;
                objDs = null;
            }
        }

        public DataTable Fetch_USerDetailByUserNameAdmin(string userName, string password)
        {
            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[2];
                pram[0] = new SqlParameter("@UserName", userName);
                pram[1] = new SqlParameter("@Password", password);
                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspUserMasterFetchByUserNameForAdmin", pram);
                objDs.Tables[0].TableName = "UserMaster";
                return objDs.Tables[0];


            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                pram = null;
                objDs = null;
            }
        }
    }
}
