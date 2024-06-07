using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DalUserMasterDetails
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
        public DataSet Fetch_USerDetailByUserId(int UserId)
        {
            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@UserId", UserId);

                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspUserMasterFetchByUserId", pram);
                objDs.Tables[0].TableName = "UserMaster";
                objDs.Tables[1].TableName = "UserCountryRelation";
                objDs.Tables[2].TableName = "UserVisaTypeRelation";
                return objDs;


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
        public DataTable FetchVisaTypeList()
        {
            DataSet ds = null;
            ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspFetchVisaTypeList");
            ds.Tables[0].TableName = "VisaTypeMaster";
            return ds.Tables[0];
        }
        public DataTable FetchZoneDetails_ZoneCode()
        {
            DataSet ds = null;
            ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspZoneMasterFetchList1");
            ds.Tables[0].TableName = "ZoneName";
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

        public DataTable Fetch_UserDetail_by_CompanyId(string CompanyId, string UserType)
        {
            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[2];
                pram[0] = new SqlParameter("@CompanyId", CompanyId);
                pram[1] = new SqlParameter("@UserType", UserType);

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
                pram = new SqlParameter[23];


                pram[0] = new SqlParameter("@CompanyId", dt.Rows[0]["CompanyId"]);
                pram[1] = new SqlParameter("@loginid", dt.Rows[0]["loginid"]);
                pram[2] = new SqlParameter("@Password", dt.Rows[0]["Password"]);
                pram[3] = new SqlParameter("@UserName", dt.Rows[0]["UserName"]);
                pram[4] = new SqlParameter("@usertype", dt.Rows[0]["usertype"]);
                pram[5] = new SqlParameter("@GrpId", dt.Rows[0]["GrpId"]);
                pram[6] = new SqlParameter("@DateOfBirth", dt.Rows[0]["DateOfBirth"]);
                pram[7] = new SqlParameter("@EmailId", dt.Rows[0]["EmailId"]);
                pram[8] = new SqlParameter("@designation", dt.Rows[0]["designation"]);
                pram[9] = new SqlParameter("@ContactNo", dt.Rows[0]["ContactNo"]);
                pram[10] = new SqlParameter("@LandlineNo", dt.Rows[0]["LandlineNo"]);
                pram[11] = new SqlParameter("@Address", dt.Rows[0]["Address"]);
                pram[12] = new SqlParameter("@approver", dt.Rows[0]["approver"]);
                pram[13] = new SqlParameter("@approvallevel", dt.Rows[0]["approvallevel"]);
                pram[14] = new SqlParameter("@bankperson", dt.Rows[0]["bankperson"]);
                pram[15] = new SqlParameter("@borderid", dt.Rows[0]["borderid"]);

                pram[16] = new SqlParameter("@UserActiveFrom", dt.Rows[0]["UserActiveFrom"]);
                pram[17] = new SqlParameter("@UserActiveTo", dt.Rows[0]["UserActiveTo"]);
                pram[18] = new SqlParameter("@UserStatus", dt.Rows[0]["UserStatus"]);
                pram[19] = new SqlParameter("@CreatedBy", dt.Rows[0]["CreatedBy"]);
                pram[20] = new SqlParameter("@ZoneCode", dt.Rows[0]["ZoneCode"]);
                pram[21] = new SqlParameter("@SuccessId", 1);
                pram[22] = new SqlParameter("@UserId", -1);

                pram[21].Direction = ParameterDirection.Output;
                pram[22].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspUserMasterInsert", pram);
                int SuccessId = int.Parse(pram[21].Value.ToString());
                int UserId = int.Parse(pram[22].Value.ToString());
                if (SuccessId == 1)
                {

                    return UserId;



                }
                else
                {
                    return -1;
                }



            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }


        public int Insert_User_Country_VisaType(DataTable dtCountryListBox, DataTable dtVisaTypeList)
        {
            SqlConnection Con = null;
            SqlCommand Cmd = null;
            Con = new SqlConnection(AppSetting.ActivateConnection);
            Con.Open();
            Cmd = new SqlCommand();
            Cmd.Connection = Con;
            try
            {
                foreach (DataRow dr in dtCountryListBox.Rows)
                {


                    Cmd.Parameters.Clear();
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.CommandText = "USP_USER_COUNTRY_RELATION_INSERT";
                    Cmd.Parameters.AddWithValue("@USERID", dr["USERID"]);
                    Cmd.Parameters.AddWithValue("@COUNTRYCODE", dr["COUNTRYCODE"].ToString());
                    Cmd.Parameters.AddWithValue("@CREATEDBY", dr["CREATEDBY"]);



                    Cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                return 2;
            }

            try
            {
                foreach (DataRow dr in dtVisaTypeList.Rows)
                {


                    Cmd.Parameters.Clear();
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.CommandText = "USP_USER_VISATYPE_RELATION_INSERT";
                    Cmd.Parameters.AddWithValue("@USERID", dr["USERID"]);
                    Cmd.Parameters.AddWithValue("@VISATYPECODE", dr["VISATYPECODE"].ToString());
                    Cmd.Parameters.AddWithValue("@CREATEDBY", dr["CREATEDBY"]);



                    Cmd.ExecuteNonQuery();

                }
            }

            catch (Exception ex)
            {
                return 2;
            }

            return 1;

        }

        public int Update_User_Country_VisaType(DataTable dtCountryListBox, DataTable dtVisaTypeList, int UserId)
        {
            SqlConnection Con = null;
            SqlCommand Cmd = null;
            Con = new SqlConnection(AppSetting.ActivateConnection);
            Con.Open();
            Cmd = new SqlCommand();
            Cmd.Connection = Con;
            SqlCommand deletecmdFromUserCountryRelation = new SqlCommand("delete from UserCountryrelation where UserId = " + UserId + "", Con);
            int getstatusForUserCountryRelation = deletecmdFromUserCountryRelation.ExecuteNonQuery();
            SqlCommand deletecmdFromUserVisaTypeRelation = new SqlCommand("delete from UserVisaTyperelation where UserId = " + UserId + "", Con);
            int getstatusForUserVisaTypeRelation = deletecmdFromUserVisaTypeRelation.ExecuteNonQuery();
            try
            {
                if (getstatusForUserCountryRelation > 0 && getstatusForUserVisaTypeRelation > 0)
                {

                    foreach (DataRow dr in dtCountryListBox.Rows)
                    {


                        Cmd.Parameters.Clear();
                        Cmd.CommandType = CommandType.StoredProcedure;
                        Cmd.CommandText = "USP_USER_COUNTRY_RELATION_INSERT";
                        Cmd.Parameters.AddWithValue("@USERID", dr["USERID"]);
                        Cmd.Parameters.AddWithValue("@COUNTRYCODE", dr["COUNTRYCODE"].ToString());
                        Cmd.Parameters.AddWithValue("@CREATEDBY", dr["CREATEDBY"]);



                        Cmd.ExecuteNonQuery();

                    }


                    foreach (DataRow dr in dtVisaTypeList.Rows)
                    {


                        Cmd.Parameters.Clear();
                        Cmd.CommandType = CommandType.StoredProcedure;
                        Cmd.CommandText = "USP_USER_VISATYPE_RELATION_INSERT";
                        Cmd.Parameters.AddWithValue("@USERID", dr["USERID"]);
                        Cmd.Parameters.AddWithValue("@VISATYPECODE", dr["VISATYPECODE"].ToString());
                        Cmd.Parameters.AddWithValue("@CREATEDBY", dr["CREATEDBY"]);



                        Cmd.ExecuteNonQuery();


                    }
                }
            }
            catch (Exception ex)
            {
                return 2;
            }

            return 1;

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
                pram = new SqlParameter[22];


                pram[0] = new SqlParameter("@CompanyId", dt.Rows[0]["CompanyId"]);
                pram[1] = new SqlParameter("@loginid", dt.Rows[0]["loginid"]);
               // pram[2] = new SqlParameter("@Password", dt.Rows[0]["Password"]);
                pram[2] = new SqlParameter("@UserName", dt.Rows[0]["UserName"]);
                pram[3] = new SqlParameter("@usertype", dt.Rows[0]["usertype"]);
                pram[4] = new SqlParameter("@GrpId", dt.Rows[0]["GrpId"]);
                pram[5] = new SqlParameter("@DateOfBirth", dt.Rows[0]["DateOfBirth"]);
                pram[6] = new SqlParameter("@EmailId", dt.Rows[0]["EmailId"]);
                pram[7] = new SqlParameter("@designation", dt.Rows[0]["designation"]);
                pram[8] = new SqlParameter("@ContactNo", dt.Rows[0]["ContactNo"]);
                pram[9] = new SqlParameter("@LandlineNo", dt.Rows[0]["LandlineNo"]);
                pram[10] = new SqlParameter("@Address", dt.Rows[0]["Address"]);
                pram[11] = new SqlParameter("@approver", dt.Rows[0]["approver"]);
                pram[12] = new SqlParameter("@approvallevel", dt.Rows[0]["approvallevel"]);
                pram[13] = new SqlParameter("@bankperson", dt.Rows[0]["bankperson"]);
                pram[14] = new SqlParameter("@borderid", dt.Rows[0]["borderid"]);

                pram[15] = new SqlParameter("@UserActiveFrom", dt.Rows[0]["UserActiveFrom"]);
                pram[16] = new SqlParameter("@UserActiveTo", dt.Rows[0]["UserActiveTo"]);
                pram[17] = new SqlParameter("@UserStatus", dt.Rows[0]["UserStatus"]);
                pram[18] = new SqlParameter("@CreatedBy", dt.Rows[0]["CreatedBy"]);
                pram[19] = new SqlParameter("@UserId", dt.Rows[0]["UserId"]);
                pram[20] = new SqlParameter("@SuccessId", 1);

                pram[20].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspUserMasterUpdate", pram);
                int SuccessId = int.Parse(pram[20].Value.ToString());

                return SuccessId;



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

        //public DataTable ForGetPossword(string UserName)
        //{
        //    SqlParameter[] pram = null;
        //    DataSet objDs = null;
        //    try
        //    {
        //        pram = new SqlParameter[2];
        //        pram[0] = new SqlParameter("@UserName", UserName);
        //        pram[1] = new SqlParameter("@SuccessId", 1);
        //        pram[1].Direction = ParameterDirection.Output;
        //        objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspUserMasterFetchtForForgetPwd", pram);

        //        objDs.Tables[0].TableName = "UserMaster";
        //        return objDs.Tables[0];



        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);

        //    }
        //    finally
        //    {
        //        pram = null;
        //        objDs = null;
        //    }
        //}

        public int UserMasterChangePassword(DataTable dt)
        {
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[5];
                pram[0] = new SqlParameter("@UserName", dt.Rows[0]["UserName"]);
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

    }
}




