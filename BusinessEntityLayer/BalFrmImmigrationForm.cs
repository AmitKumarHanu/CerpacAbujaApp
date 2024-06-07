using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BusinessEntityLayer
{
   public class BalFrmImmigrationForm
    {
       public DataTable GetApplicantList()
       {
           DataAccessLayer.DalFrmImmigrationForm ObjDalFrmImmigrationForm = null;
           DataTable dt = null;
           dt = new DataTable();

           try
           {
               ObjDalFrmImmigrationForm = new DataAccessLayer.DalFrmImmigrationForm();
               return dt = ObjDalFrmImmigrationForm.GetApplicantListDal();
           }
           catch (Exception ex)
           {
               throw (ex);
           }

           finally
           {
               ObjDalFrmImmigrationForm = null;
           }
       }

       public DataTable GetApplicantStatusById(string ApplicationId)
       {
           DataAccessLayer.DalFrmImmigrationForm ObjDalFrmImmigrationForm = null;
           DataTable dt = new DataTable();

           try
           {
               ObjDalFrmImmigrationForm = new DataAccessLayer.DalFrmImmigrationForm();
               return dt = ObjDalFrmImmigrationForm.GetApplicantStatusById(ApplicationId);
           }
           catch (Exception ex)
           {
               throw (ex);
           }

           finally
           {
               ObjDalFrmImmigrationForm = null;
           }
       }

       public DataTable GetApplicationReview1(string APPLICATIONID)
       {
           DataAccessLayer.DalFrmImmigrationForm ObjDalApplicationReview1 = null;
           DataTable dt = null;
           dt = new DataTable();

           try
           {
               ObjDalApplicationReview1 = new DataAccessLayer.DalFrmImmigrationForm();
               return dt = ObjDalApplicationReview1.GetApplicationReview1(APPLICATIONID);


           }
           catch (Exception ex)
           {
               throw (ex);
           }

           finally
           {
               ObjDalApplicationReview1 = null;
           }
       }

       public int UpdateImmigVerify(string Appid, string VisaType, string EntryType, string periodtype, string Duration, string rate, string ratecurrency, string Userid)
       {
           DataAccessLayer.DalFrmImmigrationForm ObjDalImmigVerify = null;
           DataTable dt = null;
           dt = new DataTable();

           try
           {
               ObjDalImmigVerify = new DataAccessLayer.DalFrmImmigrationForm();
               
               DataRow dr = dt.NewRow();
               dt.Columns.Add("Appid");
               dt.Columns.Add("VisaType");
               dt.Columns.Add("EntryType");
               dt.Columns.Add("periodtype");
               dt.Columns.Add("Duration");
               dt.Columns.Add("rate");
               dt.Columns.Add("ratecurrency");
               dt.Columns.Add("Userid");

               dr["Appid"] = Appid;
               dr["VisaType"] = VisaType;
               dr["EntryType"] = EntryType;
               dr["periodtype"] = periodtype;
               dr["Duration"] = Duration;
               dr["rate"] = rate;
               dr["ratecurrency"] = ratecurrency;
               dr["Userid"] = Userid;

               dt.Rows.Add(dr);

               return ObjDalImmigVerify.UpdateImmigVerifyDal(dt);


           }
           catch (Exception ex)
           {
               throw (ex);
           }

           finally
           {
               ObjDalImmigVerify = null;
           }
       }

       public int UpdateImmigReject(string Applicant, string Userid)
       {
           DataAccessLayer.DalFrmImmigrationForm ObjDalImmigReject = null;

           ObjDalImmigReject = new DataAccessLayer.DalFrmImmigrationForm();

           return ObjDalImmigReject.UpdateImmgRejectDal(Applicant, Userid);
       }


    }
}
