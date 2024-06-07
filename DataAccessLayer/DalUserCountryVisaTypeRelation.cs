using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace DataAccessLayer
{
    public class DalUserCountryVisaTypeRelation
    {
        public DataSet FillCountryListBoxes(int GrpId)
        {

            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[2];
                pram[0] = new SqlParameter("@UserID", GrpId);
                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspUserCountryTypeRelationByGrpId", pram);
                objDs.Tables[0].TableName = "UnAssociated";
                objDs.Tables[1].TableName = "Associated";
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
        public DataSet FillWorkCenterBoxes(int GrpId)
        {

            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[2];
                pram[0] = new SqlParameter("@UserID", GrpId);
                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspUserWorkCenterTypeLinkByGrpId", pram);
                objDs.Tables[0].TableName = "UnAssociated";
                objDs.Tables[1].TableName = "Associated";
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

        public DataSet FillActivityBoxes(int GrpId)
        {

            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[2];
                pram[0] = new SqlParameter("@UserID", GrpId);
                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspUserActivityTypeLinkByGrpId", pram);
                objDs.Tables[0].TableName = "UnAssociated";
                objDs.Tables[1].TableName = "Associated";
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
        public DataSet FillVisaListBoxes(int GrpId)
        {

            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[2];
                pram[0] = new SqlParameter("@UserID", GrpId);
                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspUserVisaTypeRelationByGrpId", pram);
                objDs.Tables[0].TableName = "UnAssociated";
                objDs.Tables[1].TableName = "Associated";
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

        public DataSet getUserCountryVisaTypeList()
        {
            SqlParameter[] pram = null;
            DataSet ds = null;
            ds = new DataSet();
            try
            {
                pram = new SqlParameter[1];
                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, "UserCountryVisaTypeRelation", pram);
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

        public int InsertUserCountryRelation(DataTable dt)
        {
            SqlParameter[] pram = null;
            try
            {
                //Adding the parameters of Insertion stored procedure.
                pram = new SqlParameter[4];
                pram[0] = new SqlParameter("@UserID", dt.Rows[0]["UserID"]);
                pram[1] = new SqlParameter("@CountryCodeList", dt.Rows[0]["CountryCode"]);
                pram[2] = new SqlParameter("@CreatedBy", dt.Rows[0]["CreatedBy"]);
               
                pram[3] = new SqlParameter("@SuccessId", 1);
                pram[3].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_InsertUserCountryRelation", pram);
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
        public int InsertUserWorkCenterLink(DataTable dt)
        {
            SqlParameter[] pram = null;
            try
            {
                //Adding the parameters of Insertion stored procedure.
                pram = new SqlParameter[4];
                pram[0] = new SqlParameter("@UserID", dt.Rows[0]["UserID"]);
                pram[1] = new SqlParameter("@WorkCenterID", dt.Rows[0]["WorkCenterID"]);
                pram[2] = new SqlParameter("@CreatedBy", dt.Rows[0]["CreatedBy"]);

                pram[3] = new SqlParameter("@SuccessId", 1);
                pram[3].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_InsertUserWorkCenterLink", pram);
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

        public int InsertUserVisaRelation(DataTable dt)
    {
        SqlParameter[] pram = null;
        try
        {
            //Adding the parameters of Insertion stored procedure.
            pram = new SqlParameter[4];
            pram[0] = new SqlParameter("@UserID", dt.Rows[0]["UserID"]);
            pram[1] = new SqlParameter("@VisaTypeCodeList", dt.Rows[0]["VisaTypeCode"]);
            pram[2] = new SqlParameter("@CreatedBy", dt.Rows[0]["CreatedBy"]);
            pram[3] = new SqlParameter("@SuccessId", 1);
            pram[3].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_InsertUserVisaRelation", pram);
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
        public int InsertUserActivityLink(DataTable dt)
        {
            SqlParameter[] pram = null;
            try
            {
                //Adding the parameters of Insertion stored procedure.
                pram = new SqlParameter[4];
                pram[0] = new SqlParameter("@UserID", dt.Rows[0]["UserID"]);
                pram[1] = new SqlParameter("@ActivityID", dt.Rows[0]["ActivityID"]);
                pram[2] = new SqlParameter("@CreatedBy", dt.Rows[0]["CreatedBy"]);
                pram[3] = new SqlParameter("@SuccessId", 1);
                pram[3].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_InsertUserActivityLink", pram);
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

    }


}
