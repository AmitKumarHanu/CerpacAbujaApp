using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
   public  class DalVisaStickerPrintingList
    {
        public DataTable GetVisaStickerListDal()
        {
            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[0];
                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[USP_VISA_STICKERLIST]", pram);

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

        public int UpdateVisaStickerWastageDal(string stickerno, string WasteReason, string uid)
        {
            SqlParameter[] pram = null;
            //int i = 0;
            try
            {
                pram = new SqlParameter[4];
                pram[0] = new SqlParameter("@Stickernumber",stickerno);
                pram[1] = new SqlParameter("@WastageReason", WasteReason);
                pram[2] = new SqlParameter("@ModifiedBy", uid);
                pram[3] = new SqlParameter("@SuccessId", 1);
                pram[3].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_UPDATE_STICKERWASTED_BY_SIICKERNO", pram);
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

        public int UpadteStickerUsagesDal(string stickerno, string uid, string AppId, string Remark, DateTime ValidTillDate)
        {
            SqlParameter[] pram = null;
            //int i = 0;
            try
            {
                pram = new SqlParameter[6];
                pram[0] = new SqlParameter("@Stickernumber", stickerno);
                pram[1] = new SqlParameter("@ApplicationId", AppId);
                pram[2] = new SqlParameter("@ModifiedBy", uid);
                pram[3] = new SqlParameter("@Remark", Remark);
                pram[4] = new SqlParameter("@ValidTillDate", ValidTillDate);
                pram[5] = new SqlParameter("@SuccessId", 1);
                pram[5].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_UPDATE_STICKERUSAGE_BY_SIICKERNO_TO_APPLICANT", pram);
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
        public int UpadteStickerUsagesByWestageDal( string uid, string AppId)
        {
            SqlParameter[] pram = null;
            //int i = 0;
            try
            {
                pram = new SqlParameter[3];
               
                pram[0] = new SqlParameter("@ApplicationId", AppId);
                pram[1] = new SqlParameter("@ModifiedBy", uid);
               
                pram[2] = new SqlParameter("@SuccessId", 1);
                pram[2].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_UPDATE_STICKERUSAGE_BY_SIICKERNO_TO_APPLICANT_Westage", pram);
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

        public int UpadteStickerUsagesByIDDal(string stickerno, string uid, string AppId, string Remark,int StickerStatusID)
        {
            SqlParameter[] pram = null;
            //int i = 0;
            try
            {
                pram = new SqlParameter[5];
                pram[0] = new SqlParameter("@Stickernumber", stickerno);
                pram[1] = new SqlParameter("@ApplicationId", AppId);
                pram[2] = new SqlParameter("@ModifiedBy", uid);
                pram[3] = new SqlParameter("@Remark", Remark);
                pram[4] = new SqlParameter("@SuccessId", StickerStatusID);
                pram[4].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_UPDATE_STICKERUSAGE_BY_SIICKERNO_TO_APPLICANT", pram);
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


        public DataTable GetApplicantStatusById(string ApplicationId, string userid)
        {
            SqlParameter[] pram = null;
            DataSet ds = null;
            try
            {
                pram = new SqlParameter[2];
                pram[0] = new SqlParameter("@ApplicationId", ApplicationId);
                pram[1] = new SqlParameter("@userid", userid);
                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_SEARCH_STICKER_PRINTINGLIST_DETAILS_BYAPPLICATIONID", pram);

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


        public DataTable GetMRZDal(string AppId)
        {
            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@ApplicationId", AppId);
                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[USP_MRZ_GENERATION_BY_APPLICATIONID]", pram);

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

        public int InsertMRZDal(string MRZ1, string MRZ2, string AppId, string strValidTillDate)
        {
            SqlParameter[] pram = null;
            //int i = 0;
            //try
            //{
                pram = new SqlParameter[5];
                pram[0] = new SqlParameter("@MRZ1", MRZ1);
                pram[1] = new SqlParameter("@MRZ2", MRZ2);
                pram[2] = new SqlParameter("@ApplicationId", AppId);
                pram[3] = new SqlParameter("@ValidTillDate", strValidTillDate);
                pram[4] = new SqlParameter("@SuccessId", 1);
                pram[4].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_UPDATE_VISAAPPLICATION_MRZLINE", pram);
                return int.Parse(pram[4].Value.ToString());
            //}

            //catch (Exception ex)
            //{
            //    throw (ex);
            //}

            //finally
            //{
            //    pram = null;
            //}
        }

        public DataTable PrintStickerDal(string ApplicationId)
        {
            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@APPLICATIONID", ApplicationId);

               objDs= SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_FETCHDATA_FOR_FINAL_STICKER_PRINTING", pram);
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

        
    }
}
