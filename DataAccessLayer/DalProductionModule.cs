using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace DataAccessLayer
{
    public class DalProductionModule
    {
        public int UpdateProducedFlag(string CerpacNo, string reason, string condition, int userid, string CardNo)
        {
            SqlParameter[] pram = null;
            try
            {

                pram = new SqlParameter[12];
                //pram[0] = new SqlParameter("@FormId", Convert.ToInt16(FormId));
                pram[0] = new SqlParameter("@CerpacNo", CerpacNo);
                pram[1] = new SqlParameter("@UserId", userid);
                pram[2] = new SqlParameter("@Reason", reason);
                pram[3] = new SqlParameter("@condition", condition);
                pram[4] = new SqlParameter("@CardNo", CardNo);
               
                pram[5] = new SqlParameter("@SuccessId", 1);

                pram[5].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_UPDATE_PRODUCED_CARD", pram);

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


        public int UpdateStikerFlag(string StikerNo, string reason, int userid)
        {
            SqlParameter[] pram = null;
            try
            {

                pram = new SqlParameter[12];
                //pram[0] = new SqlParameter("@FormId", Convert.ToInt16(FormId));
                pram[0] = new SqlParameter("@StikerNo", StikerNo);
                pram[1] = new SqlParameter("@UserId", userid);
                pram[2] = new SqlParameter("@Reason", reason);
                
                pram[4] = new SqlParameter("@SuccessId", 1);

                pram[4].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_UPDATE_Stiker_CARD", pram);

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


        public int UpdateQualityFlag(string CerpacNo, int userid)
        {
            SqlParameter[] pram = null;
            try
            {

                pram = new SqlParameter[12];
                //pram[0] = new SqlParameter("@FormId", Convert.ToInt16(FormId));
                pram[0] = new SqlParameter("@CerpacNo", CerpacNo);
                pram[1] = new SqlParameter("@User_Id", userid);
               

                pram[4] = new SqlParameter("@SuccessId", 1);

                pram[4].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_QUALITY_ISSUE_INSERT", pram);

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


        public int UpdateQualityFlagReject(string CerpacNo, int userid, string reason)
        {
            SqlParameter[] pram = null;
            try
            {

                pram = new SqlParameter[12];
                //pram[0] = new SqlParameter("@FormId", Convert.ToInt16(FormId));
                pram[0] = new SqlParameter("@CerpacNo", CerpacNo);
                pram[1] = new SqlParameter("@User_Id", userid);
                pram[2] = new SqlParameter("@Reason", reason);

                pram[4] = new SqlParameter("@SuccessId", 1);

                pram[4].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_QUALITY_REJECT", pram);

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

        public int UpdateLoginFlag(int userid, int condition)
        {
            SqlParameter[] pram = null;
            try
            {

                pram = new SqlParameter[12];
                //pram[0] = new SqlParameter("@FormId", Convert.ToInt16(FormId));
                pram[0] = new SqlParameter("@UserId", userid);
                pram[1] = new SqlParameter("@condition", condition);

                pram[2] = new SqlParameter("@SuccessId", 1);

                pram[2].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_Check_Login", pram);

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


        public int UpdateCerpacFlag(string userid, string cerpac_no)
        {
            SqlParameter[] pram = null;
            try
            {

                pram = new SqlParameter[12];
                //pram[0] = new SqlParameter("@FormId", Convert.ToInt16(FormId));

                pram[0] = new SqlParameter("@UserId", userid);
                pram[1] = new SqlParameter("@cerpac_no", cerpac_no);                
                pram[2] = new SqlParameter("@SuccessId", 1);

                pram[2].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_Check_cerpac_concurrent", pram);

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


    }
}
