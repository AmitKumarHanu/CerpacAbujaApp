using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DalGeneral_function
    {

        /// <summary>
        /// Created by: Ankit Gupta, 24th june 2008       
        /// </summary>
        /// <param name="text">General</param>
        /// <param name="value"General></param>
        /// <param name="tablename">General</param>
        /// <param name="whereclause">General</param>
        /// <returns>method return dataset with text/value for dropdown </returns>
        /// 
        #region General Methods for Fetch Data
        #region  Dropdown List
        public DataTable Fill_dropdown_list(string text, string value, string tablename, string whereclause)
        {
            SqlParameter[] pram = null;
            DataSet objDS = null;
            try
            {
                pram = new SqlParameter[4];
                pram[0] = new SqlParameter("@textfield", text);
                pram[1] = new SqlParameter("@valuefield", value);
                pram[2] = new SqlParameter("@table_name", tablename);
                pram[3] = new SqlParameter("@where_clause", whereclause);

                objDS = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_FILL_DROPDOWNLIST", pram);
                objDS.Tables[0].TableName = tablename;
                return objDS.Tables[0];              
               
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
        #endregion

        #region Fetch Data By SqlStatement
        /// <summary>
        /// <author >Manish Khandelwal</author>
        /// <created Date>29 july 2008</created>
        /// <Purpose>General Method For Fetch the data </Purpose>
        /// </summary>
        /// <returns></returns>  


        public DataTable FetchData(string Sqlstatement)
        {
            SqlParameter[] pram = null;
            DataSet objDS = null;
            try
            {
                objDS = new DataSet();
                pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@Sqlstatement", Sqlstatement);


                objDS = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_FETCH_DATA_GENRAL", pram);
                

                return objDS.Tables[0];

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                pram = null;
                objDS = null;
            }
        }
        #endregion

        public void AuditInsert(DataTable dt)
        {
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[6];

                pram[0] = new SqlParameter("@AuditType", dt.Rows[0]["AuditType"]);
                pram[1] = new SqlParameter("@UserId", dt.Rows[0]["UserId"]);
                pram[2] = new SqlParameter("@AuditDetail", dt.Rows[0]["AuditDetail"]);
                pram[3] = new SqlParameter("@MachineIP", dt.Rows[0]["MachineIP"]);
                pram[4] = new SqlParameter("@MachineName", dt.Rows[0]["MachineName"]);
                pram[5] = new SqlParameter("@WindowUser", dt.Rows[0]["WindowUser"]);
                
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspAuditTransInsert", pram);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable CheckAccess(string FormId, string UserId)
        {
            SqlParameter[] pram = null;
            DataSet  ds = null;
            try
            {
                ds = new DataSet();
                pram = new SqlParameter[3];
                
                pram[0] = new SqlParameter("@FormId",FormId );
                pram[1] = new SqlParameter("@UserId", UserId);

                ds= SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspFormAccessRightFetch", pram);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
       
        #endregion

        
         public int ValidDateCheck()
        {
            SqlParameter[] pram = null;
            DataSet  ds = null;
            try
            {
                ds = new DataSet();
                pram = new SqlParameter[1];
                
                pram[0] = new SqlParameter("@SuccessId",1 );
                pram[0].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspInstallationMasterFetch", pram);
                return int.Parse(pram[0].Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
    }
       

}
