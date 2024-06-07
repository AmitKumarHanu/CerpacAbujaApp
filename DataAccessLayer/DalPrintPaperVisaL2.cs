using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
  public   class DalPrintPaperVisaL2
    {
        public DataTable GetApprovedVisaDetailDL(string Applicant)
        {
            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@ApplicantId", Applicant);

                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[USP_VISA_ISSUEL2_LIST_FETCH_BY_APPLICANTID]", pram);

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

        public DataTable UpadatePaperVisaStatusDL(string Applicant)
        {
            SqlParameter[] pram = null;
            DataSet objDs = null;
            //DataTable dt = null;
            //dt = new DataTable();
            try
            {
                pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@ApplicantId", Applicant);

                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[USP_VISA_ISSUE_LIST_UPDATE_BY_APPLICANTID]", pram);

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
