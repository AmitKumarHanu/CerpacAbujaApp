using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;
//using DataAccessLayer;

//using Microsoft.ApplicationBlocks.Data;
 
	
namespace DataAccessLayer 
{
    public class DalItemMaster
    {
        //----------Item Stock Detials-------------
        public int InsertDetails(DataTable dt)
        {
            SqlParameter[] parm = null;
            try
            {
                parm = new SqlParameter[11];
                parm[0] = new SqlParameter("@MRNo", dt.Rows[0]["MRNo"]);
                parm[1] = new SqlParameter("@MRNDate", dt.Rows[0]["MRNDate"]);
                parm[2]= new SqlParameter ("@Name",dt.Rows[0]["Name"]);
                parm[3]= new SqlParameter ("@Quantity",dt.Rows [0]["Quantity"]);
                parm[4]= new SqlParameter ("@Code",dt.Rows [0]["Code"]);
                parm[5] = new SqlParameter("@CreatedBy", dt.Rows[0]["CreatedBy"]);
                parm[6] = new SqlParameter("@CodeFrom", dt.Rows[0]["CodeFrom"]);
                parm[7] = new SqlParameter("@CodeTo", dt.Rows[0]["CodeTo"]);
                parm[8] = new SqlParameter("@WorkArea", dt.Rows[0]["WorkArea"]);
                parm[9] = new SqlParameter("@LStr", dt.Rows[0]["LStr"]);
                parm[10] = new SqlParameter("@RT", 1);
                
                parm[10].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspItemStockInsert", parm);
                return int.Parse(parm[10].Value.ToString());

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                parm = null;
            }
        }

        public object ConnString { get; set; }

        public int DelDetails(DataTable dt)
        {
            SqlParameter[] parm = null;
            try
            {
                parm = new SqlParameter[4];
                parm[0] = new SqlParameter("@Name", dt.Rows[0]["Name"]);
                parm[1] = new SqlParameter("@FName", dt.Rows[0]["FName"]);
                parm[2] = new SqlParameter("@Mobile", dt.Rows[0]["Mobile"]);
                parm[3] = new SqlParameter("@RT", 1);

                parm[3].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "HomeADDel", parm);
                return int.Parse(parm[3].Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                parm = null; 
            }

        }

        public int UpdateDetails(DataTable dt)
        {
            SqlParameter[] parm = null;
            try
            {
                parm = new SqlParameter[4];
                parm[0] = new SqlParameter("Name", dt.Rows[0]["Name"]);
                parm[1] = new SqlParameter("FName", dt.Rows[0]["FName"]);
                parm[2] = new SqlParameter("Mobile", dt.Rows[0]["Mobile"]);
                parm[3] = new SqlParameter("RT", 1);

                parm[3].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure,"HomeADUpdate", parm);
                return int.Parse(parm[3].Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                parm = null;
            }
        }
        
        public DataSet  SearchDetails(String M)
        {
            DataSet dts = null;
            dts= new DataSet();
            SqlParameter[] parm = null;
            try
            {
                parm = new SqlParameter[4];
                parm[0] = new SqlParameter("Mobile", M);
                parm[1] = new SqlParameter("RT", 1);
             
                parm[1].Direction = ParameterDirection.Output;
                dts=SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "HomeADSearch", parm);
                return dts ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                parm = null;
            }
        }

        //------------Item Code Master Details-----------

        public int ItemMasterInsert(DataTable dt1)
        {
            SqlParameter[] parm = null;
            try
            {
                parm = new SqlParameter[6];
                parm[0] = new SqlParameter("@ItemName", dt1.Rows[0]["ItemName"]);
                parm[1] = new SqlParameter("@ItemCode", dt1.Rows[0]["ItemCode"]);
                parm[2] = new SqlParameter("@ItemCurrentStock", dt1.Rows[0]["ItemCurrentStock"]);
                parm[3] = new SqlParameter("@CreatedBy", dt1.Rows[0]["CreatedBy"]);
                parm[4] = new SqlParameter("@WorkArea", dt1.Rows[0]["WorkArea"]);
                parm[5] = new SqlParameter("@RT", 1);

                parm[5].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspItemMasterInsert", parm);
                return int.Parse(parm[5].Value.ToString());

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                parm = null;
            }
        }


        //------------Item Invertory Insert Details-----------

        public int ItemInventoryInsert(DataTable dt1)
        {
            SqlParameter[] parm = null;
            try
            {
                parm = new SqlParameter[8];
                parm[0] = new SqlParameter("@BankCode", dt1.Rows[0]["BankCode"]);
                parm[1] = new SqlParameter("@ZoneID", dt1.Rows[0]["ZoneID"]);
                parm[2] = new SqlParameter("@UserID", dt1.Rows[0]["UserID"]);
                parm[3] = new SqlParameter("@ItemCode", dt1.Rows[0]["ItemCode"]);
                parm[4] = new SqlParameter("@ItemCodeN", dt1.Rows[0]["ItemCodeN"]);
                parm[5] = new SqlParameter("@CreatedBy", dt1.Rows[0]["CreatedBy"]);
                parm[6] = new SqlParameter("@WorkArea", dt1.Rows[0]["WorkArea"]);
                parm[7] = new SqlParameter("@RT", 1);

                parm[7].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspItemInventoryInsert", parm);
                return int.Parse(parm[7].Value.ToString());

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                parm = null;
            }
        }

        //------------Del ItemStock MRNo Grid-----------

        public int DelMRNoGrid( DataTable dtDelStock)
        {
            SqlParameter[] parm = null;
            try
            {
                parm = new SqlParameter[3];
                parm[0] = new SqlParameter("@MRNo", dtDelStock.Rows[0]["MRNo"] );
                parm[1] = new SqlParameter("@OptDelStock", dtDelStock.Rows[0]["OptDelStock"]);
                parm[2] = new SqlParameter("@RT", 1);

                parm[2].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspItemStockDel", parm);
                return int.Parse(parm[2].Value.ToString());

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                parm = null;
            }
        }

        //----------UpDate Item Stock Detials-------------
        public int ItemStockUpdate(DataTable dt)
        {
            SqlParameter[] parm = null;
            try
            {
                parm = new SqlParameter[11];
                parm[0] = new SqlParameter("@MRNo", dt.Rows[0]["MRNo"]);
                parm[1] = new SqlParameter("@MRNDate", dt.Rows[0]["MRNDate"]);
                parm[2] = new SqlParameter("@Name", dt.Rows[0]["Name"]);
                parm[3] = new SqlParameter("@Quantity", dt.Rows[0]["Quantity"]);
                parm[4] = new SqlParameter("@Code", dt.Rows[0]["Code"]);
                parm[5] = new SqlParameter("@CreatedBy", dt.Rows[0]["CreatedBy"]);
                parm[6] = new SqlParameter("@CodeFrom", dt.Rows[0]["CodeFrom"]);
                parm[7] = new SqlParameter("@CodeTo", dt.Rows[0]["CodeTo"]);
                parm[8] = new SqlParameter("@WorkArea", dt.Rows[0]["WorkArea"]);
                parm[9] = new SqlParameter("@LStr", dt.Rows[0]["LStr"]);
                parm[10] = new SqlParameter("@RT", 1);

                parm[10].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspItemStockUpdate", parm);
                return int.Parse(parm[10].Value.ToString());

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                parm = null;
            }
        }
    }
}