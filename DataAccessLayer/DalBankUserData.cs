using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace DataAccessLayer
{
    public class DalBankUserData
    {
        public DataTable Fetch_BankDetail_by_UserName(string userName, string password)
        {
            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[2];
                pram[0] = new SqlParameter("@UserName", userName);
                pram[1] = new SqlParameter("@Password", password);
                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspBankDetailsFetchByUserName", pram);
                objDs.Tables[0].TableName = "BankregMaster";
                return objDs.Tables[0];
            }

            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                pram = null;
                objDs = null;
            }
        }
    }
}
