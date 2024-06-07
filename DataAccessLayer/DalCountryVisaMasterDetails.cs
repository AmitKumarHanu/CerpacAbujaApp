using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DalCountryVisaMasterDetails
    {


        public int InsertCountryVisaMasterDetails(DataTable dt)
        {
            SqlParameter[] param = null;

            try
            {
                param = new SqlParameter[15];

                param[0] = new SqlParameter("@COUNTRYCODE", dt.Rows[0]["COUNTRYCODE"]);
                param[1] = new SqlParameter("@VISATYPECODE", dt.Rows[0]["VISATYPE"]);
                param[2] = new SqlParameter("@ENTRYTYPE", dt.Rows[0]["ENTRYTYPE"]);
                param[3] = new SqlParameter("@PERIODTYPE", dt.Rows[0]["PERIODTYPE"]);
                param[4] = new SqlParameter("@PERIOD", dt.Rows[0]["PERIOD"]);
                param[5] = new SqlParameter("@RATE", dt.Rows[0]["RATE"]);
                param[6] = new SqlParameter("@RATECURRENCYCODE", dt.Rows[0]["RATECURRENCYCODE"]);
                param[7] = new SqlParameter("@RATEEFFECTIVEDATE", dt.Rows[0]["RATEEFFECTIVEDATE"]);
                param[8] = new SqlParameter("@COMMISION", dt.Rows[0]["COMMISION"]);
                param[9] = new SqlParameter("@COMMISIONCURRENCYCODE", dt.Rows[0]["COMMISIONCURRENCYCODE"]);
                param[10] = new SqlParameter("@COMMISIONEFFECTIVEDATE", dt.Rows[0]["COMMISIONEFFECTIVEDATE"]);
                param[11] = new SqlParameter("@CREATEDBY", dt.Rows[0]["CREATEDBY"]);
                param[12] = new SqlParameter("@ApproverLevel", dt.Rows[0]["ApproverLevel"]);
                param[13] = new SqlParameter("@VisaTypeForApplicant", dt.Rows[0]["VisaTypeForApplicant"]);
                param[14] = new SqlParameter("@SuccessId", 1);
                param[14].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_COUNTRYVISAMASTER_INSERT", param);
                return int.Parse(param[14].Value.ToString());


            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                param = null;

            }

        }

        public DataTable FetchCountryVisaMasterDetailsBy_CountryVisaId(int id)
        {
            SqlParameter[] param = null;
            DataSet objDs = null;
            try
            {
                objDs = new DataSet();
                param = new SqlParameter[2];
                param[0] = new SqlParameter("@CountryVisaId", id);

                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_COUNTRYVISAMASTER_FETCH_BY_COUNTRYVISAID", param);
                return objDs.Tables[0];
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                param = null;

            }
        }

        public int UpdateCountryVisaMasterDetails(DataTable dt)
        {
            SqlParameter[] param = null;

            try
            {
                param = new SqlParameter[16];

                param[0] = new SqlParameter("@COUNTRYCODE", dt.Rows[0]["COUNTRYCODE"]);
                param[1] = new SqlParameter("@VISATYPECODE", dt.Rows[0]["VISATYPE"]);
                param[2] = new SqlParameter("@ENTRYTYPE", dt.Rows[0]["ENTRYTYPE"]);
                param[3] = new SqlParameter("@PERIODTYPE", dt.Rows[0]["PERIODTYPE"]);
                param[4] = new SqlParameter("@PERIOD", dt.Rows[0]["PERIOD"]);
                param[5] = new SqlParameter("@RATE", dt.Rows[0]["RATE"]);
                param[6] = new SqlParameter("@RATECURRENCYCODE", dt.Rows[0]["RATECURRENCYCODE"]);
                param[7] = new SqlParameter("@RATEEFFECTIVEDATE", dt.Rows[0]["RATEEFFECTIVEDATE"]);
                param[8] = new SqlParameter("@COMMISION", dt.Rows[0]["COMMISION"]);
                param[9] = new SqlParameter("@COMMISIONCURRENCYCODE", dt.Rows[0]["COMMISIONCURRENCYCODE"]);
                param[10] = new SqlParameter("@COMMISIONEFFECTIVEDATE", dt.Rows[0]["COMMISIONEFFECTIVEDATE"]);
                param[11] = new SqlParameter("@MODIFIEDBY", dt.Rows[0]["MODIFIEDBY"]);
                param[12] = new SqlParameter("@CREATEDBY", dt.Rows[0]["CREATEDBY"]);
                param[13] = new SqlParameter("@ApproverLevel", dt.Rows[0]["ApproverLevel"]);
                param[14] = new SqlParameter("@VisaTypeForApplicant", dt.Rows[0]["VisaTypeForApplicant"]);
                param[15] = new SqlParameter("@SuccessId", 1);
                param[15].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_COUNTRYVISAMASTER_UPDATE", param);
                return int.Parse(param[15].Value.ToString());
                //ADD CREATED BY PARAMETER IN DAL AND PROCEDURE

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                param = null;

            }

        }

        public int DeleteDataRow(string keyvalue)
        {
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[2];
                pram[0] = new SqlParameter("@CountryVisaId", keyvalue);
                pram[1] = new SqlParameter("@SuccessId", 1);
                pram[1].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_COUNTRYVISAMASTER_DELETE", pram);
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
