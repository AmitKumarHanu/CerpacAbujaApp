using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace DataAccessLayer
{
  public class DalVisaAppSearchL1
    {

      public DataTable searchvisaappDal(string AppID, string country, string visatype, string fromdate, string todate, string status)
      {
          SqlParameter[] pram = null;
          DataSet objDs = new DataSet();
          try
          {
              pram = new SqlParameter[6];
              pram[0] = new SqlParameter("@APPLICATIONID", AppID);
              pram[1] = new SqlParameter("@VISATYPE", visatype);
              pram[2] = new SqlParameter("@COUNTRY", country);
              pram[3] = new SqlParameter("@FROMDATE", fromdate);
              pram[4] = new SqlParameter("@TODATE", todate);
              pram[5] = new SqlParameter("@STATUS", status);

              objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_SEARCH_DETAIL_L1", pram);
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
