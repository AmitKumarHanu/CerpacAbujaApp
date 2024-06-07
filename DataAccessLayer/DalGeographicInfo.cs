using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DalGeographicInfo
    {

       public DataTable GetGoegraphicEntity(string TableName, string condition)
        {
            SqlParameter[] pram = null;
            DataSet ds = null;
            try
            {
                ds = new DataSet();
                pram = new SqlParameter[2];
                pram[0] = new SqlParameter("@TableName", TableName);
                pram[1] = new SqlParameter("@condition", condition);
                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspGeographicEntityFetch", pram);
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

        public DataTable GetGoegraphicInfoById(string GeograhicInfoId)
        {
            SqlParameter[] pram = null;
            DataSet ds = null;
            try
            {
                ds = new DataSet();
                pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@Id", GeograhicInfoId);

                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspGeographicInfoMasterFetchById", pram);
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


        public DataTable GetGoegraphicInfoList()
        {
            SqlParameter[] pram = null;
            DataSet ds = null;
            try
            {
                ds = new DataSet();
                pram = new SqlParameter[1];

                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspGeographicInfoMasterFetchList", pram);
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


        public int InsertGeographicInfoDetail( Hashtable ht)
        {
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[12];

                pram[0] = new SqlParameter("@CountryId", ht["CountryId"].ToString());
                pram[1] = new SqlParameter("@RegionId", ht["RegionId"].ToString());
                pram[2] = new SqlParameter("@StateId", ht["StateId"].ToString());
                pram[3] = new SqlParameter("@CityId", ht["CityId"].ToString());
                pram[4] = new SqlParameter("@Locality", ht["Locality"].ToString());
                pram[5] = new SqlParameter("@ShopNo", ht["ShopNo"].ToString());
                pram[6] = new SqlParameter("@Address", ht["Address"].ToString());
                pram[7] = new SqlParameter("@OwnerName", ht["Owner"].ToString());
                pram[8] = new SqlParameter("@PropertyId", ht["PropertyId"].ToString());
                pram[9] = new SqlParameter("@OwnerContactNo", ht["OwnerContactNo"].ToString());
                pram[10] = new SqlParameter("@OwnerEmailId", ht["OwnerEmailId"].ToString());
                pram[11] = new SqlParameter("@SuccessId", 1);
                pram[11].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspGeographicInfoMasterInsert", pram);
                return int.Parse(pram[11].Value.ToString());

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

        public int UpdateGeographicInfoDetail(Hashtable ht)
        {
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[13];

                pram[0] = new SqlParameter("@GeograhicInfoId", ht["GeograhicInfoId"].GetHashCode().ToString());
                pram[1] = new SqlParameter("@CountryId", ht["CountryId"].GetHashCode().ToString());
                pram[2] = new SqlParameter("@RegionId", ht["RegionId"].GetHashCode().ToString());
                pram[3] = new SqlParameter("@StateId", ht["StateId"].GetHashCode().ToString());
                pram[4] = new SqlParameter("@CityId", ht["CityId"].GetHashCode().ToString());
                pram[5] = new SqlParameter("@LocalityId", ht["LocalityId"].GetHashCode().ToString());
                pram[6] = new SqlParameter("@ShopNo", ht["ShopNo"].GetHashCode().ToString());
                pram[7] = new SqlParameter("@Address", ht["Address"].GetHashCode().ToString());
                pram[8] = new SqlParameter("@OwnerName", ht["Owner"].GetHashCode().ToString());
                pram[9] = new SqlParameter("@PropertyId", ht["PropertyId"].GetHashCode().ToString());
                pram[10] = new SqlParameter("@OwnerContactNo", ht["OwnerContactNo"].ToString());
                pram[11] = new SqlParameter("@OwnerEmailId", ht["OwnerEmailId"].ToString());
                pram[12] = new SqlParameter("@SuccessId", 1);
                pram[12].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspGeographicInfoMasterUpdate", pram);
                return int.Parse(pram[12].Value.ToString());

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


        public DataTable GetShopNoByCityId(string CityId)
        {
            SqlParameter[] pram = null;
            DataSet ds = null;
            try
            {
                ds = new DataSet();
                pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@CityId", CityId);

                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "uspGeographicInfoFetchShopNobyCity", pram);
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
