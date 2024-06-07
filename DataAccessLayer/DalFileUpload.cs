using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DalFileUpload
    {
        public int InsertUploadedFileDetail(DataTable dt, string GeographicId)
        {
            SqlParameter[] pram = null;
            string[] GeoDetail = new string[2];
            try
            {
                pram = new SqlParameter[11];

                pram[0] = new SqlParameter("@DocName", dt.Rows[0]["doc_name"]);
                pram[1] = new SqlParameter("@SpecifiedDocName", dt.Rows[0]["SpecifiedDoc_name"]);
                pram[2] = new SqlParameter("@DocType", dt.Rows[0]["doc_type"]);
                pram[3] = new SqlParameter("@DocVersion", dt.Rows[0]["doc_version"]);
                pram[4] = new SqlParameter("@UploadBy", dt.Rows[0]["uploaded_by"]);
                pram[5] = new SqlParameter("@CompanyId", dt.Rows[0]["company_id"]);
                pram[6] = new SqlParameter("@DocDescription", dt.Rows[0]["docDesc"]);
                pram[7] = new SqlParameter("@DocTypeId", dt.Rows[0]["TypeOfDoc"]);
                GeoDetail = GeographicId.Split('|');
                pram[8] = new SqlParameter("@CityId", GeoDetail[0].ToString());
                pram[9] = new SqlParameter("@ShopNo", GeoDetail[1].ToString());
                pram[10] = new SqlParameter("@SuccessId", 1);
                pram[10].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspDocUploadMasterInsert", pram);
                return int.Parse(pram[10].Value.ToString());

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

        public DataTable BindGrid(int UserId)
        {
            SqlParameter[] pram = null;
            DataSet ds = null;
            try
            {
                pram = new SqlParameter[1];
                ds = new DataSet();
                pram[0] = new SqlParameter("@UserId", UserId);
                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, "UspDocUploadMasterFetchListByUserId", pram);
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

        //public DataTable getDataRow(int keyvalue)
        //{
        //    //SqlParameter[] pram = null;
        //    DataSet ds = null;
        //    try
        //    {
        //        //ds = new DataSet();
        //        //pram = new SqlParameter[1];
        //        //pram[0] = new SqlParameter("@DocNo", keyvalue);
        //        ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.Text, "Select DocName From DocUploadMaster Where DocNo=3");
        //        return ds.Tables[0];

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        //pram = null;
        //    }

        //}

        public int DeleteDataRow(int keyvalue)
        {
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[2];
                pram[0] = new SqlParameter("@DocNo", keyvalue);
                pram[1] = new SqlParameter("@SuccessId", 1);
                pram[1].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspDocUploadMasterDelete", pram);
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

        public DataTable GetFilePath(int DocNo)
        {
            SqlParameter[] pram = null;
            DataSet ds = null;
            try
            {
                ds = new DataSet();
                pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@DocNo", DocNo);
                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspDocUploadMasterFetchPathByDocNo", pram);
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

        public DataTable BindGridFetchbyCompanyId(string CompanyId)
        {
            SqlParameter[] pram = null;
            DataSet ds = null;
            try
            {
                pram = new SqlParameter[1];
                ds = new DataSet();
                pram[0] = new SqlParameter("@CompanyId", CompanyId);
                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, "UspDocUploadMasterFetchDocTypeByCompanyId", pram);
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

        public DataTable BindGridFetchForAll(string CompanyId, string UserId, string DocType, string Identifier, string FromDate, string ToDate, string DocName)
        {
            SqlParameter[] pram = null;
            DataSet ds = null;
            try
            {
                pram = new SqlParameter[7];
                ds = new DataSet();
                pram[0] = new SqlParameter("@CompanyId", CompanyId);
                pram[1] = new SqlParameter("@UserId", UserId);
                pram[2] = new SqlParameter("@DocType", DocType);
                pram[3] = new SqlParameter("@Identifier", Identifier);
                pram[4] = new SqlParameter("@FromDate", FromDate);
                pram[5] = new SqlParameter("@ToDate", ToDate);
                pram[6] = new SqlParameter("@DocName", DocName);
                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, "UspSearchFromDocUploadMaster", pram);
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


        public DataTable FetchDocNo(string CompanyId, string UserId, string DocType, string Identifier, string FromDate, string ToDate, string DocName, string CurrentLoginUser,string GeoInfo)
        {
            SqlParameter[] pram = null;
            DataSet ds = null;
            try
            {
                pram = new SqlParameter[9];
                ds = new DataSet();
                pram[0] = new SqlParameter("@CompanyId", CompanyId);
                pram[1] = new SqlParameter("@UserId", UserId);
                pram[2] = new SqlParameter("@DocType", DocType);
                pram[3] = new SqlParameter("@Identifier", Identifier);
                pram[4] = new SqlParameter("@FromDate", FromDate);
                pram[5] = new SqlParameter("@ToDate", ToDate);
                pram[6] = new SqlParameter("@DocName", DocName);
                pram[7] = new SqlParameter("@LoginId", CurrentLoginUser);
                pram[8] = new SqlParameter("@GeoInfo", GeoInfo);
                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, "UspAdvanceSearchFetchDocNo", pram);
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

        public DataTable BindGridAdvanceSearch(string DocNo)
        {
            SqlParameter[] pram = null;
            DataSet ds = null;
            try
            {
                pram = new SqlParameter[1];
                ds = new DataSet();
                pram[0] = new SqlParameter("@DocNo", DocNo);
                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, "UspAdvanceSearchFetchFromDocUploadMaster", pram);
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


        public DataTable GetDocVersion(string UserId, string DocName)
        {
            SqlParameter[] pram = null;
            DataSet ds = null;
            try
            {
                pram = new SqlParameter[2];
                ds = new DataSet();
                pram[0] = new SqlParameter("@UploadBy", Convert.ToInt32(UserId));
                pram[1] = new SqlParameter("@DocName", DocName);
                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, "UspDocUploadMasterVersionCheck", pram);
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

        public DataTable BindGridForOther(int UserId)
        {
            SqlParameter[] pram = null;
            DataSet ds = null;
            try
            {
                pram = new SqlParameter[1];
                ds = new DataSet();
                pram[0] = new SqlParameter("@UserId", UserId);
                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, "UspDocUploadMasterFetchForOther", pram);
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

        public int InsertDocTracker(string DocId, string FwdTo, string Uid, bool FwdFlg, string comment, int statusId)
        {
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[7];

                pram[0] = new SqlParameter("@DocId", DocId);
                pram[1] = new SqlParameter("@ForwardTo", FwdTo);
                pram[2] = new SqlParameter("@AssignedBy", Uid);
                pram[3] = new SqlParameter("@ForwardFlag", FwdFlg);
                pram[4] = new SqlParameter("@Comment", comment);
                pram[5] = new SqlParameter("@StatusId", statusId);
                pram[6] = new SqlParameter("@SuccessId", 1);
                pram[6].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspDocTrackerInsert", pram);
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


        public DataTable FetchDocTrackerData(string UserId, string DocId)
        {
            SqlParameter[] pram = null;
            DataSet ds = null;
            try
            {
                pram = new SqlParameter[2];
                ds = new DataSet();
                pram[0] = new SqlParameter("@DocId", DocId);
                pram[1] = new SqlParameter("@UploadedBy", UserId);
                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, "UspDocTrackerFetch", pram);
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

        public int UpdateDocTracker(string DocId, string FwdTo, string Uid, string comment, int StatusId)
        {
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[6];

                pram[0] = new SqlParameter("@DocId", DocId);
                pram[1] = new SqlParameter("@ForwardTo", FwdTo);
                pram[2] = new SqlParameter("@AssignedBy", Uid);
                pram[3] = new SqlParameter("@Comment", comment);
                pram[4] = new SqlParameter("@StatusId", StatusId);
                pram[5] = new SqlParameter("@SuccessId", 1);
                pram[5].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspDocTrackerUpdate", pram);
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

        public string FetchDocReceived4approvalCount(string UserId)
        {
            SqlParameter[] pram = null;
            DataSet ds = null;
            try
            {
                pram = new SqlParameter[1];
                ds = new DataSet();
                pram[0] = new SqlParameter("@receiverId", UserId);
                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, "UspDocReceived4ApprovalCountFetch", pram);
                return ds.Tables[0].Rows[0]["DocCount"].ToString();
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

        public DataTable FetchDocReceived4approvalList(string UserId, bool fwdflg)
        {
            SqlParameter[] pram = null;
            DataSet ds = null;
            try
            {
                pram = new SqlParameter[2];
                ds = new DataSet();
                pram[0] = new SqlParameter("@ForwardTo", UserId);
                pram[1] = new SqlParameter("@FwdFlg", fwdflg);
                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, "UspDocReceived4ApprovalListFetchByUserId", pram);
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

        public DataTable FetchDocApprovalLog(string DocId)
        {
            SqlParameter[] pram = null;
            DataSet ds = null;
            try
            {
                pram = new SqlParameter[1];
                ds = new DataSet();
                pram[0] = new SqlParameter("@DocId", DocId);
                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, "UspDocApprovalLog", pram);
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

        public DataTable FetchDocUploadedStatis(string UserId)
        {
            SqlParameter[] pram = null;
            DataSet ds = null;
            try
            {
                pram = new SqlParameter[1];
                ds = new DataSet();
                pram[0] = new SqlParameter("@CreatedBy", UserId);
                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, "UspDocUploadedStatics", pram);
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

        public DataTable FetchDocReceivedStatis(string UserId)
        {
            SqlParameter[] pram = null;
            DataSet ds = null;
            try
            {
                pram = new SqlParameter[1];
                ds = new DataSet();
                pram[0] = new SqlParameter("@ReceivedBy", UserId);
                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, "UspDocReceivedStatics", pram);
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


        public DataTable FetchDocUploadListbyUserIdStatusID(string UserId, string StatusId)
        {
            SqlParameter[] pram = null;
            DataSet ds = null;
            try
            {
                pram = new SqlParameter[2];
                ds = new DataSet();
                pram[0] = new SqlParameter("@CreatedBy", UserId);
                pram[1] = new SqlParameter("@StatusId", StatusId);
                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, "UspDocUploadedFetchByUserIdStatusId", pram);
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


        public int InsertDocAlert(int DocId, string AlertType, string AlertDesc, string ActionDate, int NotificationDays, bool IsEmailAlert, string CreatedBy)
        {
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[8];                

                pram[0] = new SqlParameter("@DocId", DocId);
                pram[1] = new SqlParameter("@AlertType", AlertType);
                pram[2] = new SqlParameter("@AlertDesc", AlertDesc);
                pram[3] = new SqlParameter("@ActionDate", ActionDate);
                pram[4] = new SqlParameter("@NotificationDays",NotificationDays);
                pram[5] = new SqlParameter("@IsEmailAlert", IsEmailAlert);
                pram[6] = new SqlParameter("@CreatedBy", CreatedBy);
                pram[7] = new SqlParameter("@SuccessId", 1);
                pram[7].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspDocAlertInsert", pram);
                return int.Parse(pram[7].Value.ToString());

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

        public int InsertDocAlertEscalate(int DocId, string UserId, int NotificationDays)
        {
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[4];

                pram[0] = new SqlParameter("@DocId", "DocId");
                pram[1] = new SqlParameter("@UserId","UserId");
                pram[2] = new SqlParameter("@NotificationDays","NotificationDays");
                pram[3] = new SqlParameter("@SuccessId", 1);
                pram[3].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "SP_TEST", pram);
                return int.Parse(pram[7].Value.ToString());

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


        public int UpdateDocAlert(int DocId, string AlertType, string AlertDesc, string ActionDate, int NotificationDays, bool IsEmailAlert, string ModifyBy)
        {
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[8];

                pram[0] = new SqlParameter("@DocId", DocId);
                pram[1] = new SqlParameter("@AlertType", AlertType);
                pram[2] = new SqlParameter("@AlertDesc",AlertDesc);
                pram[3] = new SqlParameter("@ActionDate",ActionDate);
                pram[4] = new SqlParameter("@NotificationDays", NotificationDays);
                pram[5] = new SqlParameter("@IsEmailAlert",IsEmailAlert);
                pram[6] = new SqlParameter("@ModifyBy", ModifyBy);               
                pram[7] = new SqlParameter("@SuccessId", 1);
                pram[7].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspDocAlertUpdate", pram);
                return int.Parse(pram[7].Value.ToString());

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

        public DataTable FetchDocAlertByDocId(int DocId)
        {
            SqlParameter[] pram = null;
            DataSet ds = null;
            try
            {
                pram = new SqlParameter[1];
                ds = new DataSet();
                pram[0] = new SqlParameter("@DocId", DocId);
                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, "UspDocAlertFetchByDocId", pram);
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

        public int FetchCountActiveDocAlert(string UserId)
        {
            SqlParameter[] pram = null;
            DataSet ds = null;
            try
            {
                pram = new SqlParameter[1];
                ds = new DataSet();
                pram[0] = new SqlParameter("@UserId", UserId);
                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, "UspCountActiveDocAlter", pram);
               return Convert.ToInt16(ds.Tables[0].Rows[0]["Count"]);
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

        public DataTable FetchActiveAlertbyUserId(string UserId)
        {
            SqlParameter[] pram = null;
            DataSet ds = null;
            try
            {
                pram = new SqlParameter[1];
                ds = new DataSet();
                pram[0] = new SqlParameter("@UserId", UserId);
                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, "UspDocAlertActiveFetchByUserId", pram);
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

        public DataTable FetchDocumentTypebyCompanyId(string CompanyId)
        {
            SqlParameter[] pram = null;
            DataSet ds = null;
            try
            {
                pram = new SqlParameter[1];
                ds = new DataSet();
                pram[0] = new SqlParameter("@CompanyId", CompanyId);
                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, "UspDocTypeFetchByCompanyId", pram);
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

        public int UpdateDocAlertAction(int DocId, string ActionRemark, string ModifyBy)

        {
           SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[4];

                pram[0] = new SqlParameter("@DocId", DocId);
                pram[1] = new SqlParameter("@ActionRemark", ActionRemark);
                pram[2] = new SqlParameter("@ModifyBy", ModifyBy);                        
                pram[3] = new SqlParameter("@SuccessId", 1);
                pram[3].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspDocAlertActionUpdate", pram);
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