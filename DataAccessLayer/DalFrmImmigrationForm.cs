using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
   public class DalFrmImmigrationForm
    {
       public DataTable GetApplicantListDal()
       {
           SqlParameter[] pram = null;
           DataSet objDs = null;
           try
           {
               pram = new SqlParameter[0];               
               objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[USP_APPLICANT_LIST_FOR_IMMIGRATION]", pram);

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

       public DataTable GetApplicantStatusById(string ApplicationId)
       {
           SqlParameter[] pram = null;
           DataSet ds = null;
           try
           {
               pram = new SqlParameter[1];
               pram[0] = new SqlParameter("@ApplicationId", ApplicationId);

               ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[USP_IMMIGRATION_FETCH_BYAPPLICANTID]", pram);

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

       public DataTable GetApplicationReview1(string APPLICATIONID)
       {
           SqlParameter[] pram = null;
           DataSet objDs = null;
           try
           {
               pram = new SqlParameter[1];
               pram[0] = new SqlParameter("@APPLICATIONID", APPLICATIONID);

               objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[USP_FETCH_IMMIGRATION_REVIEW_OR_CHANGE]", pram);
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
       
       public int UpdateImmigVerifyDal(DataTable dt)
       {
           SqlParameter[] pram = null;
           
           try
           {
               pram = new SqlParameter[9];

               pram[0] = new SqlParameter("@APPLICATIONID",dt.Rows[0]["Appid"]);
               pram[1] = new SqlParameter("@VISATYPECODE", dt.Rows[0]["VisaType"]);
               pram[2] = new SqlParameter("@ENTRYTYPE", dt.Rows[0]["EntryType"]);
               pram[3] = new SqlParameter("@PERIODTYPE", dt.Rows[0]["periodtype"]);
               pram[4] = new SqlParameter("@DURATION", dt.Rows[0]["Duration"]);
               pram[5] = new SqlParameter("@RATE", dt.Rows[0]["rate"]);
               pram[6] = new SqlParameter("@RATECURRENCY", dt.Rows[0]["ratecurrency"]);
               pram[7] = new SqlParameter("@USERID", dt.Rows[0]["Userid"]);
               pram[8] = new SqlParameter("@Successid",1);
               pram[8].Direction=ParameterDirection.Output;
               SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[USP_UPDATE_APPLICANT_VISATYPESACTUALISSUED_BY_IMMIGRATIONOFF]", pram);
               //return objDs.Tables[0];
               return int.Parse(pram[8].Value.ToString());


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

       public int UpdateImmgRejectDal(string Applicant,string Userid)
       {
           SqlParameter[] pram = null;

           try
           {
               pram = new SqlParameter[3];

               pram[0] = new SqlParameter("@APPLICATIONID", Applicant);
               pram[1] = new SqlParameter("@USERID", Userid);
               pram[2] = new SqlParameter("@Successid", 1);
               pram[2].Direction = ParameterDirection.Output;
               SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_UPDATE_APPLICANT_IMMIGRATIONOFFICER_REJECT", pram);
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
