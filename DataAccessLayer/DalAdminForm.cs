using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DalAdminForm
    {
        //<summary>
        //<author >Wasim Karim</author>
        //<created Date>3 sept 2009</created>
        //<purpose> Bind Grid Listing</purpose>
        //</summary>
        //<returns></returns> 
        public DataSet FillGridFormList(string GrpId)
        {

            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@GrpId", GrpId);
                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[USPListForm]", pram);
                return objDs;


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
        /// <creation date>26 Nov 2008</creation>
        /// <purpose>Update query into USP_PS_FormMaster_UPDATE_STATUS</purpose>
        /// <summary>
        /// <returns></returns>      
        //public int UpdatePS_FormMaster_Status(DataTable dt)
        //{
        //    SqlParameter[] pram = null;
        //    try
        //    {

        //        pram = new SqlParameter[3];
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            pram[0] = new SqlParameter("@RepCode", dt.Rows[i]["RepCode"]);
        //            pram[1] = new SqlParameter("@Status", dt.Rows[i]["Status"]);
        //            pram[2] = new SqlParameter("@SuccessId", 1);

        //            pram[2].Direction = ParameterDirection.Output;
        //            SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_PS_FormMASTER_UPDATE_STATUS", pram);
        //        }

        //        return 1;

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


        /// <summary>
        /// <author>Wasim Karim</author>
        /// <creation date>5 sept 2009</creation>
        /// <purpose>Insert into ModuleFormRelation  table </purpose>
        /// <summary>
        /// <returns></returns>      

        public int InsertFormModRelation(string FormId, string ModIdList, string CompanyId)
        {
            SqlParameter[] pram = null;
            try
            {

                pram = new SqlParameter[4];
                //pram[0] = new SqlParameter("@FormId", Convert.ToInt16(FormId));
                pram[0] = new SqlParameter("@FormId", FormId);
                pram[1] = new SqlParameter("@ModIdList", ModIdList);
                pram[2] = new SqlParameter("@CompanyId", CompanyId);
                //pram[2] = new SqlParameter("@CompanyId",Convert.ToInt16(CompanyId));
                pram[3] = new SqlParameter("@SuccessId", 1);

                pram[3].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspFormModRelationInsert", pram);

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

        public DataTable GetFormName(string Form_Id)
        {
            DataSet ds = null;
            ds = new DataSet();
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@FormId", Form_Id);
                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, "UspFormMasterFetchbyFormId", pram);
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

        //<summary>
        //<author >Wasim Karim</author>
        //<created Date>8 sept 2009</created>
        //<purpose> Fetch FormMaster by GrpId</purpose>
        //</summary>
        //<returns></returns> 
        public DataTable GetFormInfo(string Grp_Id, string Company_Id)
        {
            DataSet ds = null;
            ds = new DataSet();
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[2];
                pram[0] = new SqlParameter("@GrpId", Convert.ToInt32(Grp_Id));
                pram[1] = new SqlParameter("@CompanyId", Convert.ToInt32(Company_Id));
                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, "UspFormMasterFetchByGrpId", pram);
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
                pram[0] = new SqlParameter("@FormId", keyvalue);
                pram[1] = new SqlParameter("@SuccessId", 1);
                pram[1].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspFormMasterDelete", pram);
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

        public int GetCompleteAppCount(string strSqlstatement)
        {
            try
            {

                int intCount = 0;
                intCount = (int)SqlHelper.ExecuteScalar(AppSetting.ActivateConnection, CommandType.Text, strSqlstatement);
                return intCount;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {

            }

        }

        public int InsertForm(DataTable dt)
        {
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[4];

                pram[0] = new SqlParameter("@FormName", dt.Rows[0]["Form_Name"]);
                pram[1] = new SqlParameter("@FormURL", dt.Rows[0]["Form_URL"]);
                pram[2] = new SqlParameter("@FormStatus", dt.Rows[0]["Form_Status"]);
                pram[3] = new SqlParameter("@SuccessId", 1);
                pram[3].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspFormMasterInsert", pram);
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
        public int UpdateFormMaster(DataTable dt)
        {
            SqlParameter[] pram = null;
            try
            {

                pram = new SqlParameter[5];

                pram[0] = new SqlParameter("@FormId", dt.Rows[0]["Form_Id"]);
                pram[1] = new SqlParameter("@FormName", dt.Rows[0]["Form_Name"]);
                pram[2] = new SqlParameter("@FormURL", dt.Rows[0]["Form_URL"]);
                pram[3] = new SqlParameter("@FormStatus", dt.Rows[0]["Form_Status"]);
                pram[4] = new SqlParameter("@SuccessId", 1);

                pram[4].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspFormMasterUpdate", pram);


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



    }
}
