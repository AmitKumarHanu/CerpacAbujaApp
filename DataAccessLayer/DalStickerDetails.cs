using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DalStickerDetails
    {
        public DataTable GetStickerList(string UserID)
        {


            DataSet ds = null;
            DataTable dt = null;
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@UserId", UserID);
                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_STICKERAUTHORITY_FETCH_ISSUE_LIST", pram);
                dt = ds.Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw (ex);
            }



        }


        public DataTable GetStickerReceiveList(string UserId)
        {


            DataSet ds = null;
            DataTable dt = null;
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@UserId", UserId);
                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_STICKERAUTHORITY_FETCH_RECEIVE_LIST", pram);
                dt = ds.Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw (ex);
            }



        }


        public int UpdateStickerDetail(DataTable dt)
        {
            SqlParameter[] pram = null;
            try
            {
                //Adding the parameters of Insertion stored procedure.
                pram = new SqlParameter[4];
                pram[0] = new SqlParameter("@StickerNumber", dt.Rows[0]["StickerSerialNumber"]);
                pram[1] = new SqlParameter("@Status", dt.Rows[0]["Status"]);
                pram[2] = new SqlParameter("@ModifiedBy", dt.Rows[0]["ModifiedBy"]);
                pram[3] = new SqlParameter("@SuccessId", 1);
                pram[3].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USPSTICKERMASTERUPDATE", pram);
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

        public int DeleteDataRow(int keyvalue)
        {
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[2];
                pram[0] = new SqlParameter("@StickerSerialNumber", keyvalue);
                pram[1] = new SqlParameter("@SuccessId", -1);
                pram[1].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_STICKER_INVENTORY_MASTER_DELETE", pram);
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

        public int InsertStickerDetail(DataTable dt)
        {
            SqlParameter[] pram = null;
            try
            {
                //Adding the parameters of Insertion stored procedure.
                pram = new SqlParameter[6];
                pram[0] = new SqlParameter("@StickerNumberFrom", dt.Rows[0]["StickerNumberFrom"]);
                pram[1] = new SqlParameter("@StickerNumberTo", dt.Rows[0]["StickerNumberTo"]);
                pram[2] = new SqlParameter("@Status", dt.Rows[0]["Status"]);
                pram[3] = new SqlParameter("@CreatedBy", dt.Rows[0]["CreatedBy"]);

                pram[4] = new SqlParameter("@SuccessId", 1);
                pram[4].Direction = ParameterDirection.Output;
                pram[5] = new SqlParameter("@StartStickerNo", 0);
                // pram[4].Direction = ParameterDirection.Output;
                pram[5].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USPSTICKERMASTERINSERT", pram);
                int a = int.Parse(pram[4].Value.ToString());
                int b = int.Parse(pram[5].Value.ToString());
                return a;

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
        public DataSet GetStickerInfo(int StickerSerialNumber)
        {
            DataSet ds = new DataSet();
            SqlParameter[] param = null;

            try
            {
                param = new SqlParameter[1];
                param[0] = new SqlParameter("@StickerSerialNumber", StickerSerialNumber);
                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, "UspStickerMasterFetchByStickerNumber", param);

                return ds;
            }
            catch (Exception e)
            {
                throw (e);
            }

            finally
            {
                param = null;
            }


        }

        public DataSet MaxSerialNo()
        {
            DataSet dts = null;
            dts = new DataSet();
            SqlParameter[] parm = null;
            try
            {
                parm = new SqlParameter[1];
                parm[0] = new SqlParameter("RT", 1);

                parm[0].Direction = ParameterDirection.Output;
                dts = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "MaxStickerNo", parm);
                return dts;
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

        public int StickerIssueDetails(int StartStickerNum, int EndStickerNum, int Sticker_UserId, int CreatedBy, int ModifiedBy)
        {
            SqlParameter[] pram = null;
            //if(Issued_New_StickerSerialNo.Length > Issued_Removed_StickerSerialNo.Length)
            //{
            //    max=Issued_New_StickerSerialNo.Length;
            //}
            //else
            //{
            //    max=Issued_Removed_StickerSerialNo.Length;
            //}

            try
            {
                pram = new SqlParameter[6];
                pram[5] = new SqlParameter("@SuccessId", 1);
                pram[5].Direction = ParameterDirection.Output;
                //for (int i = 0; i < max; i++)
                //{
                //Adding the parameters of Insertion stored procedure.

                //if (i <= Issued_Removed_StickerSerialNo.Length)
                //{
                //    pram[0] = new SqlParameter("@Issued_Removed_StickerSerialNo", Issued_Removed_StickerSerialNo[i]);
                //}
                //else
                //{
                //    pram[0] = new SqlParameter("@Issued_Removed_StickerSerialNo", 0);
                //}
                //if (i <= Issued_New_StickerSerialNo.Length)
                //{
                //    pram[1] = new SqlParameter("@Issued_New_StickerSerialNo", Issued_New_StickerSerialNo[i]);
                //}
                //else
                //{
                //    pram[1] = new SqlParameter("@Issued_New_StickerSerialNo", 0);
                //}
                pram[0] = new SqlParameter("@StartStickerNum", StartStickerNum);
                pram[1] = new SqlParameter("@EndStickerNum", EndStickerNum);
                pram[2] = new SqlParameter("@Sticker_UserId", Sticker_UserId);
                pram[3] = new SqlParameter("@CreatedBy", CreatedBy);
                pram[4] = new SqlParameter("@ModifiedBy", ModifiedBy);



                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_STICKERAUTHORITY_UPDATE_NEW", pram);

                //}

                return (int.Parse(pram[5].Value.ToString()));

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

        public int StickerReceivedDetails(int[] Issued_Removed_StickerSerialNo, int[] Issued_New_StickerSerialNo, int Sticker_UserId, int CreatedBy, int ModifiedBy)
        {

            SqlParameter[] pram = null;
            int max;
            int SuccessId;
            if (Issued_New_StickerSerialNo.Length > Issued_Removed_StickerSerialNo.Length)
            {
                max = Issued_New_StickerSerialNo.Length;
            }
            else
            {
                max = Issued_Removed_StickerSerialNo.Length;
            }

            try
            {
                pram = new SqlParameter[6];
                pram[5] = new SqlParameter("@SuccessId", 1);
                pram[5].Direction = ParameterDirection.Output;
                for (int i = 0; i < max; i++)
                {
                    //Adding the parameters of Insertion stored procedure.

                    if (i <= Issued_Removed_StickerSerialNo.Length)
                    {
                        pram[0] = new SqlParameter("@Issued_Removed_StickerSerialNo", Issued_Removed_StickerSerialNo[i]);
                    }
                    else
                    {
                        pram[0] = new SqlParameter("@Issued_Removed_StickerSerialNo", 0);
                    }
                    if (i <= Issued_New_StickerSerialNo.Length)
                    {
                        pram[1] = new SqlParameter("@Issued_New_StickerSerialNo", Issued_New_StickerSerialNo[i]);
                    }
                    else
                    {
                        pram[1] = new SqlParameter("@Issued_New_StickerSerialNo", 0);
                    }
                    pram[2] = new SqlParameter("@Sticker_UserId", Sticker_UserId);
                    pram[3] = new SqlParameter("@CreatedBy", CreatedBy);
                    pram[4] = new SqlParameter("@ModifiedBy", ModifiedBy);



                    SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_STICKERAUTHORITY_Receive_UPDATE", pram);

                }

                return (int.Parse(pram[5].Value.ToString()));

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
