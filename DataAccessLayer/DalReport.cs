using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
  public  class DalReport
    {
        public DataTable RptAudit(string CompanyId,string UserId,string Fromdate,string Todate)
        {
            DataSet ds = null;
            ds = new DataSet();
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[4];
                pram[0] = new SqlParameter("@CompanyId", CompanyId);
                pram[1] = new SqlParameter("@UserId", UserId);
                pram[2] = new SqlParameter("@Fromdate", Fromdate);
                pram[3] = new SqlParameter("@Todate", Todate);
                ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, "RptAudit", pram);
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


      public DataTable RptGeographicInfo(string countryId, string regionId, string stateId, string cityId, string LocalityId, string PropertyId)
      {
          DataSet ds = null;
          ds = new DataSet();
          SqlParameter[] pram = null;
          try
          {
              pram = new SqlParameter[6];
              pram[0] = new SqlParameter("@countryId", countryId);
              pram[1] = new SqlParameter("@regionId", regionId);
              pram[2] = new SqlParameter("@stateId", stateId);
              pram[3] = new SqlParameter("@cityId", cityId);
              pram[4] = new SqlParameter("@LocalityId", LocalityId);
              pram[5] = new SqlParameter("@PropertyId", PropertyId);
              ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, "Rpt_GeographicInfo", pram);
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

    }
}
