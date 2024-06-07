using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
   public class DalCountryDetails
    {

        public DataTable GetCountryList()
        {
            DataTable dt = null;
            dt = new DataTable();
            DataSet ds = null;
            ds = new DataSet();

            try
            {
                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, "UspCountryMasterFetchList");
                dt = ds.Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                dt = null;
            }

        }

        public int InsertCountryDetail(DataTable dt)
        {
            SqlParameter[] pram = null;
            try
            {
                //Adding the parameters of Insertion stored procedure.
                pram = new SqlParameter[9];
                pram[0] = new SqlParameter("@CountryCode", dt.Rows[0]["CountryCode"]);
                pram[1] = new SqlParameter("@CountryName", dt.Rows[0]["Country_Name"]);
                pram[2] = new SqlParameter("@Nationality", dt.Rows[0]["Nationality"]);
                pram[3] = new SqlParameter("@Abbreviation", dt.Rows[0]["Abbreviation"]);
                pram[4] = new SqlParameter("@Status", dt.Rows[0]["Status"]);
                pram[5] = new SqlParameter("@CreatedBy", dt.Rows[0]["ModifiedBy"]);
                pram[6] = new SqlParameter("@EACFlag", dt.Rows[0]["EACFlag"]);
                pram[7] = new SqlParameter("@EmbassyId", dt.Rows[0]["EmbassyId"]);
                
                pram[8] = new SqlParameter("@SuccessId", 1);
                pram[8].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_COUNTRYMASTER_INSERT", pram);
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

        public DataTable FetchCountryDetails_CountryCode(string CountryCode)
        {
            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@CountryCode", CountryCode);

                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[USP_COUNTRYMASTER_FETCH_BY_COUNTRYCODE]", pram);               
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

        public int UpdateCountryDetail(DataTable dt)
        {
            SqlParameter[] pram = null;
            try
            {
                //Adding the parameters of Insertion stored procedure.
                pram = new SqlParameter[9];
                pram[0] = new SqlParameter("@CountryCode", dt.Rows[0]["CountryCode"]);
                pram[1] = new SqlParameter("@CountryName", dt.Rows[0]["Country_Name"]);
                pram[2] = new SqlParameter("@Nationality", dt.Rows[0]["Nationality"]);
                pram[3] = new SqlParameter("@Abbreviation", dt.Rows[0]["Abbreviation"]);
                pram[4] = new SqlParameter("@Status", dt.Rows[0]["Status"]);
                pram[5] = new SqlParameter("@ModifiedBy", dt.Rows[0]["ModifiedBy"]);
                pram[6] = new SqlParameter("@EACFlag", dt.Rows[0]["EACFlag"]);
                pram[7] = new SqlParameter("@EmbassyId", dt.Rows[0]["EmbassyId"]);
                
                pram[8] = new SqlParameter("@SuccessId", 1);
                pram[8].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_COUNTRYMASTER_UPDATE", pram);
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

        public int DeleteDataRow(string keyvalue)
        {
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[2];
                pram[0] = new SqlParameter("@CountryCode", keyvalue);
                pram[1] = new SqlParameter("@SuccessId", 1);
                pram[1].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_COUNTRYMASTER_DELETE", pram);
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
