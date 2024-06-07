using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
  public class DalPrintPaperVisa
    {
      public DataTable GetApprovedVisaDetailDL(string Applicant)
      {
          SqlParameter[] pram = null;
          DataSet objDs = null;
          try
          {
              pram = new SqlParameter[1];
              pram[0] = new SqlParameter("@ApplicantId", Applicant);

              objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[USP_VISA_ISSUE_LIST_FETCH_BY_APPLICANTID]", pram);

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

      public int UpadatePaperVisaStatusDL(string Applicant)
      {
          SqlParameter[] pram = null;
          DataSet objDs = null;
          //DataTable dt = null;
          //dt = new DataTable();
          try
          {
              pram = new SqlParameter[1];
              pram[0] = new SqlParameter("@ApplicantId", Applicant);

              return SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[USP_VISA_ISSUE_LIST_UPDATE_BY_APPLICANTID]", pram);
            
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

      public int insertencryptdata(DataTable dt)
      {
          SqlParameter[] pram = null;
          try
          {
              //Adding the parameters of Insertion stored procedure.
              pram = new SqlParameter[4];
              pram[0] = new SqlParameter("@ApplicationId", dt.Rows[0]["ApplicationId"]);
              pram[1] = new SqlParameter("@ghostimage", dt.Rows[0]["ghostimage"]);
              pram[2] = new SqlParameter("@qrcode", dt.Rows[0]["qrcode"]);

              pram[3] = new SqlParameter("@SuccessId", 1);
              pram[3].Direction = ParameterDirection.Output;
              SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_APPLICATIONENCRYPTDATA_INSERT", pram);
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
