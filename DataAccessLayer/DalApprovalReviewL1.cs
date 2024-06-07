using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DalApprovalReviewL1
    {
        public int UpdateApplicationStatus(DataTable dt)
        {
          SqlParameter[] pram = null;
                try
                {
                    //Adding the parameters of Insertion stored procedure.
                    pram = new SqlParameter[7];
                    pram[0] = new SqlParameter("@APPLICATIONID", dt.Rows[0]["APPLICATIONID"]);
                    pram[1] = new SqlParameter("@APPROVER1STATUS", dt.Rows[0]["APPROVER1STATUS"]);
                    pram[2] = new SqlParameter("@APPROVER1COMMENTS", dt.Rows[0]["APPROVER1COMMENTS"]);
                    pram[3] = new SqlParameter("@Rejection_Code", dt.Rows[0]["Rejection_Code"]);
                    pram[4] = new SqlParameter("@L1Id", dt.Rows[0]["L1Id"]);
                    pram[5] = new SqlParameter("@ModifiedBy", dt.Rows[0]["ModifiedBy"]);

                    pram[6] = new SqlParameter("@SuccessId", 1);
                    pram[6].Direction = ParameterDirection.Output;
                    SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_PANDINGL1_UPDATE", pram);
                    return int.Parse(pram[6].Value.ToString());

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

        public DataTable GetDurationNDurationTypeDal(string AppId)
        {
            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@APPLICATIONID", AppId);

                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[USP_FETCH_DURATIONNTYPE_BY_APPLICATIONID_FORL1]", pram);

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

        public DataTable GetArrivalDate(string AppId)
        {
            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@APPLICATIONID", AppId);

                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[USP_FETCH_Get_Arrival_Date]", pram);

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

        public DataTable InsertValidTillDal(string AppId, DateTime ValidTillDate)
        {
            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[2];
                pram[0] = new SqlParameter("@APPLICATIONID", AppId);
                pram[1] = new SqlParameter("@VALIDTILL", ValidTillDate);
                //pram[2] = new SqlParameter("@PaperVisaValidFrom", PaperVisaValidFrom);
                //pram[3] = new SqlParameter("@PaperVisaValidThru", PaperVisaValidThru);
                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[USP_UPDATE_VALIDTILL_FORL1]", pram);

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
        //------------------------------By chitresh -------------------------------------
        public int UpdateApplicationStatusCommandCenter(DataTable dt)
        {
            {
                SqlParameter[] pram = null;
                try
                {
                    //Adding the parameters of Insertion stored procedure.
                    pram = new SqlParameter[4];
                    pram[0] = new SqlParameter("@APPLICATIONID", dt.Rows[0]["APPLICATIONID"]);
                    // pram[1] = new SqlParameter("@APPROVER1STATUS", dt.Rows[0]["APPROVER1STATUS"]);
                    //  pram[2] = new SqlParameter("@APPROVER1COMMENTS", dt.Rows[0]["APPROVER1COMMENTS"]);
                    //  pram[3] = new SqlParameter("@Rejection_Code", dt.Rows[0]["Rejection_Code"]);
                    pram[1] = new SqlParameter("@L1Id", dt.Rows[0]["L1Id"]);
                    //   pram[5] = new SqlParameter("@ModifiedBy", dt.Rows[0]["ModifiedBy"]);
                    pram[2] = new SqlParameter("@GenerateFileCode", dt.Rows[0]["GenerateFileCode"]);
                    pram[3] = new SqlParameter("@SuccessId", 1);
                    pram[3].Direction = ParameterDirection.Output;
                    SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_COMMANDCENTER_UPDATE", pram);
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

        public DataTable GetDocList(string ApplicationId)
        {
            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@APPLICATIONID", ApplicationId);

                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[USP_FETCH_DOCLIST_BY_APPLICATIONID]", pram);

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
        //---------------------------------end-----------------------------
//-------------------------------------------------------------by chitresh CERPAC------------------------------------------------
       
        public int UpdateCerpacData(DataTable dt)
        {
            SqlParameter[] pram = null;
            try
            {
                //Adding the parameters of Insertion stored procedure.
                pram = new SqlParameter[24];
                pram[0] = new SqlParameter("@passportissueby", dt.Rows[0]["passportissueby"]);
                pram[1] = new SqlParameter("@dateofissuep", dt.Rows[0]["dateofissuep"]);
                pram[2] = new SqlParameter("@dateofexpp", dt.Rows[0]["dateofexpp"]);
                pram[3] = new SqlParameter("@placeissuep", dt.Rows[0]["placeissuep"]);
                pram[4] = new SqlParameter("@companyname", dt.Rows[0]["companyname"]);
                pram[5] = new SqlParameter("@companyadd1", dt.Rows[0]["companyadd1"]);
                pram[6] = new SqlParameter("@companyadd2", dt.Rows[0]["companyadd2"]);
                pram[7] = new SqlParameter("@designation", dt.Rows[0]["designation"]);
                pram[8] = new SqlParameter("@comptelno", dt.Rows[0]["comptelno"]);
                pram[9] = new SqlParameter("@compfaxno", dt.Rows[0]["compfaxno"]);
                pram[10] = new SqlParameter("@emailprsn", dt.Rows[0]["emailprsn"]);
                pram[11] = new SqlParameter("@contactprsn", dt.Rows[0]["contactprsn"]);
                pram[12] = new SqlParameter("@cerpacno", dt.Rows[0]["cerpacno"]);
                pram[13] = new SqlParameter("@companyid", dt.Rows[0]["companyid"]);
                pram[14] = new SqlParameter("@UserId", dt.Rows[0]["UserId"]);
                pram[15] = new SqlParameter("@zonenote", dt.Rows[0]["zonenote"]);
                pram[16] = new SqlParameter("@fname", dt.Rows[0]["fname"]);
                pram[17] = new SqlParameter("@lname", dt.Rows[0]["lname"]);
                pram[18] = new SqlParameter("@mname", dt.Rows[0]["mname"]);
                pram[19] = new SqlParameter("@nationality", dt.Rows[0]["nationality"]);
                pram[20] = new SqlParameter("@passportno", dt.Rows[0]["passportno"]);
                pram[21] = new SqlParameter("@sex", dt.Rows[0]["sex"]);
                pram[22] = new SqlParameter("@fileno", dt.Rows[0]["fileno"]);
                pram[23] = new SqlParameter("@SuccessId", 1);
                pram[23].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_CERPAC_DATA_UPDATE", pram);
                return int.Parse(pram[23].Value.ToString());
               
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


        public int UpdateCerpacApplicantData(DataTable dt)
        {
            SqlParameter[] pram = null;
            try
            {
                //Adding the parameters of Insertion stored procedure.
                pram = new SqlParameter[24];
                pram[0] = new SqlParameter("@passportissueby", dt.Rows[0]["passportissueby"]);
                pram[1] = new SqlParameter("@dateofissuep", dt.Rows[0]["dateofissuep"]);
                pram[2] = new SqlParameter("@dateofexpp", dt.Rows[0]["dateofexpp"]);
                pram[3] = new SqlParameter("@placeissuep", dt.Rows[0]["placeissuep"]);
                pram[4] = new SqlParameter("@companyname", dt.Rows[0]["companyname"]);
                pram[5] = new SqlParameter("@companyadd1", dt.Rows[0]["companyadd1"]);
                pram[6] = new SqlParameter("@companyadd2", dt.Rows[0]["companyadd2"]);
                pram[7] = new SqlParameter("@designation", dt.Rows[0]["designation"]);
                pram[8] = new SqlParameter("@comptelno", dt.Rows[0]["comptelno"]);
                pram[9] = new SqlParameter("@compfaxno", dt.Rows[0]["compfaxno"]);
                pram[10] = new SqlParameter("@emailprsn", dt.Rows[0]["emailprsn"]);
                pram[11] = new SqlParameter("@contactprsn", dt.Rows[0]["contactprsn"]);
                pram[12] = new SqlParameter("@cerpacno", dt.Rows[0]["cerpacno"]);
                pram[13] = new SqlParameter("@companyid", dt.Rows[0]["companyid"]);
                pram[14] = new SqlParameter("@UserId", dt.Rows[0]["UserId"]);
                pram[15] = new SqlParameter("@zonenote", dt.Rows[0]["zonenote"]);
                pram[16] = new SqlParameter("@fname", dt.Rows[0]["fname"]);
                pram[17] = new SqlParameter("@lname", dt.Rows[0]["lname"]);
                pram[18] = new SqlParameter("@mname", dt.Rows[0]["mname"]);
                pram[19] = new SqlParameter("@nationality", dt.Rows[0]["nationality"]);
                pram[20] = new SqlParameter("@passportno", dt.Rows[0]["passportno"]);
                pram[21] = new SqlParameter("@sex", dt.Rows[0]["sex"]);
                pram[22] = new SqlParameter("@fileno", dt.Rows[0]["fileno"]);
                pram[23] = new SqlParameter("@SuccessId", 1);
                pram[23].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_CERPAC_APPLICANT_DATA_UPDATE", pram);
                return int.Parse(pram[23].Value.ToString());

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

        public int Authorize(DataTable dt)
        {
             SqlParameter[] pram = null;
             try
             {
                 pram = new SqlParameter[4];
                 pram[0] = new SqlParameter("@UserId", dt.Rows[0]["UserId"]);
                 pram[1] = new SqlParameter("@cerpacno", dt.Rows[0]["cerpacno"]);
                 pram[2] = new SqlParameter("@authnotes", dt.Rows[0]["authnotes"]);
                 pram[3] = new SqlParameter("@SuccessId", 1);
                 pram[3].Direction = ParameterDirection.Output;
                 SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_CERPAC_DATA_AUTHORIZE", pram);
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
        public int Reject(DataTable dt)
        {
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[6];
                pram[0] = new SqlParameter("@UserId", dt.Rows[0]["UserId"]);
                pram[1] = new SqlParameter("@cerpacno", dt.Rows[0]["cerpacno"]);
                pram[2] = new SqlParameter("@reason", dt.Rows[0]["reason"]);
                pram[3] = new SqlParameter("@fileno", dt.Rows[0]["file_no"]);
                pram[4] = new SqlParameter("@authnotes", dt.Rows[0]["authnotes"]);
                pram[5] = new SqlParameter("@SuccessId", 1);
                pram[5].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_CERPAC_DATA_REJECT", pram);
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

        public int InsertDoc(DataTable dt)
        {
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[3];
                pram[0] = new SqlParameter("@docode", dt.Rows[0]["docode"]);
                pram[1] = new SqlParameter("@cerpacno", dt.Rows[0]["cerpacno"]);
                pram[2] = new SqlParameter("@SuccessId", 1);
                pram[2].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_CERPAC_DOCUMENT_LINK", pram);
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

        public int Confirm(DataTable dt)
        {
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[4];
                pram[0] = new SqlParameter("@UserId", dt.Rows[0]["UserId"]);
                pram[1] = new SqlParameter("@cerpacno", dt.Rows[0]["cerpacno"]);
                pram[2] = new SqlParameter("@SuccessId", 1);
                pram[2].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_CERPAC_DATA_CONFIRM", pram);
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

        public int Defer(DataTable dt)
        {
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[4];
                pram[0] = new SqlParameter("@UserId", dt.Rows[0]["UserId"]);
                pram[1] = new SqlParameter("@cerpacno", dt.Rows[0]["cerpacno"]);
                pram[2] = new SqlParameter("@SuccessId", 1);
                pram[2].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_CERPAC_DATA_DEFER", pram);
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



        public int InsertCerpacData(DataTable dt)
        {
            SqlParameter[] pram = null;
            try
            {
                //Adding the parameters of Insertion stored procedure.
                pram = new SqlParameter[24];
                pram[0] = new SqlParameter("@passportissueby", dt.Rows[0]["passportissueby"]);
                pram[1] = new SqlParameter("@dateofissuep", dt.Rows[0]["dateofissuep"]);
                pram[2] = new SqlParameter("@dateofexpp", dt.Rows[0]["dateofexpp"]);
                pram[3] = new SqlParameter("@placeissuep", dt.Rows[0]["placeissuep"]);
                pram[4] = new SqlParameter("@companyname", dt.Rows[0]["companyname"]);
                pram[5] = new SqlParameter("@companyadd1", dt.Rows[0]["companyadd1"]);
                pram[6] = new SqlParameter("@companyadd2", dt.Rows[0]["companyadd2"]);
                pram[7] = new SqlParameter("@designation", dt.Rows[0]["designation"]);
                pram[8] = new SqlParameter("@comptelno", dt.Rows[0]["comptelno"]);
                pram[9] = new SqlParameter("@compfaxno", dt.Rows[0]["compfaxno"]);
                pram[10] = new SqlParameter("@emailprsn", dt.Rows[0]["emailprsn"]);
                pram[11] = new SqlParameter("@contactprsn", dt.Rows[0]["contactprsn"]);
                pram[12] = new SqlParameter("@cerpacno", dt.Rows[0]["cerpacno"]);
                pram[13] = new SqlParameter("@companyid", dt.Rows[0]["companyid"]);
                pram[14] = new SqlParameter("@UserId", dt.Rows[0]["UserId"]);
                pram[15] = new SqlParameter("@zonenote", dt.Rows[0]["zonenote"]);
                pram[16] = new SqlParameter("@fname", dt.Rows[0]["fname"]);
                pram[17] = new SqlParameter("@lname", dt.Rows[0]["lname"]);
                pram[18] = new SqlParameter("@mname", dt.Rows[0]["mname"]);
                pram[19] = new SqlParameter("@nationality", dt.Rows[0]["nationality"]);
                pram[20] = new SqlParameter("@passportno", dt.Rows[0]["passportno"]);
                pram[21] = new SqlParameter("@sex", dt.Rows[0]["sex"]);
                pram[22] = new SqlParameter("@fileno", dt.Rows[0]["fileno"]);
                pram[23] = new SqlParameter("@SuccessId", 1);
                pram[23].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_CERPAC_DATA_INSERT", pram);
                return int.Parse(pram[23].Value.ToString());

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

        public int VerifyRejection(DataTable dt)
        {
            SqlParameter[] pram = null;
            try
            {
                //Adding the parameters of Insertion stored procedure.
                pram = new SqlParameter[24];
                pram[0] = new SqlParameter("@passportissueby", dt.Rows[0]["passportissueby"]);
                pram[1] = new SqlParameter("@dateofissuep", dt.Rows[0]["dateofissuep"]);
                pram[2] = new SqlParameter("@dateofexpp", dt.Rows[0]["dateofexpp"]);
                pram[3] = new SqlParameter("@placeissuep", dt.Rows[0]["placeissuep"]);
                pram[4] = new SqlParameter("@companyname", dt.Rows[0]["companyname"]);
                pram[5] = new SqlParameter("@companyadd1", dt.Rows[0]["companyadd1"]);
                pram[6] = new SqlParameter("@companyadd2", dt.Rows[0]["companyadd2"]);
                pram[7] = new SqlParameter("@designation", dt.Rows[0]["designation"]);
                pram[8] = new SqlParameter("@comptelno", dt.Rows[0]["comptelno"]);
                pram[9] = new SqlParameter("@compfaxno", dt.Rows[0]["compfaxno"]);
                pram[10] = new SqlParameter("@emailprsn", dt.Rows[0]["emailprsn"]);
                pram[11] = new SqlParameter("@contactprsn", dt.Rows[0]["contactprsn"]);
                pram[12] = new SqlParameter("@cerpacno", dt.Rows[0]["cerpacno"]);
                pram[13] = new SqlParameter("@companyid", dt.Rows[0]["companyid"]);
                pram[14] = new SqlParameter("@UserId", dt.Rows[0]["UserId"]);
                pram[15] = new SqlParameter("@zonenote", dt.Rows[0]["zonenote"]);
                pram[16] = new SqlParameter("@fname", dt.Rows[0]["fname"]);
                pram[17] = new SqlParameter("@lname", dt.Rows[0]["lname"]);
                pram[18] = new SqlParameter("@mname", dt.Rows[0]["mname"]);
                pram[19] = new SqlParameter("@nationality", dt.Rows[0]["nationality"]);
                pram[20] = new SqlParameter("@passportno", dt.Rows[0]["passportno"]);
                pram[21] = new SqlParameter("@sex", dt.Rows[0]["sex"]);
                pram[22] = new SqlParameter("@fileno", dt.Rows[0]["fileno"]);
                pram[23] = new SqlParameter("@SuccessId", 1);
                pram[23].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_CERPAC_REJECTION_VERIFY", pram);
                return int.Parse(pram[23].Value.ToString());

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

        public int VerifyRejectionAfterQuality(DataTable dt)
        {
            SqlParameter[] pram = null;
            try
            {
                //Adding the parameters of Insertion stored procedure.
                pram = new SqlParameter[24];
                pram[0] = new SqlParameter("@passportissueby", dt.Rows[0]["passportissueby"]);
                pram[1] = new SqlParameter("@dateofissuep", dt.Rows[0]["dateofissuep"]);
                pram[2] = new SqlParameter("@dateofexpp", dt.Rows[0]["dateofexpp"]);
                pram[3] = new SqlParameter("@placeissuep", dt.Rows[0]["placeissuep"]);
                pram[4] = new SqlParameter("@companyname", dt.Rows[0]["companyname"]);
                pram[5] = new SqlParameter("@companyadd1", dt.Rows[0]["companyadd1"]);
                pram[6] = new SqlParameter("@companyadd2", dt.Rows[0]["companyadd2"]);
                pram[7] = new SqlParameter("@designation", dt.Rows[0]["designation"]);
                pram[8] = new SqlParameter("@comptelno", dt.Rows[0]["comptelno"]);
                pram[9] = new SqlParameter("@compfaxno", dt.Rows[0]["compfaxno"]);
                pram[10] = new SqlParameter("@emailprsn", dt.Rows[0]["emailprsn"]);
                pram[11] = new SqlParameter("@contactprsn", dt.Rows[0]["contactprsn"]);
                pram[12] = new SqlParameter("@cerpacno", dt.Rows[0]["cerpacno"]);
                pram[13] = new SqlParameter("@companyid", dt.Rows[0]["companyid"]);
                pram[14] = new SqlParameter("@UserId", dt.Rows[0]["UserId"]);
                pram[15] = new SqlParameter("@zonenote", dt.Rows[0]["zonenote"]);
                pram[16] = new SqlParameter("@fname", dt.Rows[0]["fname"]);
                pram[17] = new SqlParameter("@lname", dt.Rows[0]["lname"]);
                pram[18] = new SqlParameter("@mname", dt.Rows[0]["mname"]);
                pram[19] = new SqlParameter("@nationality", dt.Rows[0]["nationality"]);
                pram[20] = new SqlParameter("@passportno", dt.Rows[0]["passportno"]);
                pram[21] = new SqlParameter("@sex", dt.Rows[0]["sex"]);
                pram[22] = new SqlParameter("@fileno", dt.Rows[0]["fileno"]);
                pram[23] = new SqlParameter("@SuccessId", 1);
                pram[23].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_CERPAC_REJECTION_QUALITY", pram);
                return int.Parse(pram[23].Value.ToString());

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
        //------------------------------------------------------------end----------------------------------------------------------------

        
    }
}
