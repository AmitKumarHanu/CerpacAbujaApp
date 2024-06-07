using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BusinessEntityLayer
{
   public class BalPayableListBank
    {

       public DataTable GetApplicantPayableList()
       {
           DataAccessLayer.DalPayableListBank ObjDalPayableListBank = null;
           DataTable dt = null;
           dt = new DataTable();

           try
           {
               ObjDalPayableListBank = new DataAccessLayer.DalPayableListBank();
               return dt = ObjDalPayableListBank.GetApplicantPayableListDal();
           }
           catch (Exception ex)
           {
               throw (ex);
           }

           finally
           {
               ObjDalPayableListBank = null;
           }
       }


       public DataTable GetApplicantPayableListBankById(string ApplicationId)//, string Userid)
       {
           DataAccessLayer.DalPayableListBank ObjDalPayableListBanksearch = null;
           DataTable dt = new DataTable();

           try
           {
               ObjDalPayableListBanksearch = new DataAccessLayer.DalPayableListBank();
               return dt = ObjDalPayableListBanksearch.GetApplicantPayableListBankByIdDal(ApplicationId);//,Userid);
           }
           catch (Exception ex)
           {
               throw (ex);
           }

           finally
           {
               ObjDalPayableListBanksearch = null;
           }
       }


       public DataTable GetPayableListBankbyApplicationId(string ApplicationId)
       {
           DataAccessLayer.DalPayableListBank ObjDalPayableListBankbyApplicationId = null;
           DataTable dt = new DataTable();

           try
           {
               ObjDalPayableListBankbyApplicationId = new DataAccessLayer.DalPayableListBank();
               return dt = ObjDalPayableListBankbyApplicationId.GetDalPayableListBankbyApplicationId(ApplicationId);
           }
           catch (Exception ex)
           {
               throw (ex);
           }

           finally
           {
               ObjDalPayableListBankbyApplicationId = null;
           }
       }

       public int UpdateApplicantPaymentVisaNormal(string Appid, string UId)//, string VisaTypeCode)
       {
           DataAccessLayer.DalPayableListBank ObjDalUpdateApplicantPaymentVisaNormalApplicationId = null;
          // DataTable dt = new DataTable();

           try
           {
               ObjDalUpdateApplicantPaymentVisaNormalApplicationId = new DataAccessLayer.DalPayableListBank();
               return ObjDalUpdateApplicantPaymentVisaNormalApplicationId.GetDalUpdateApplicantPaymentVisaNormalbyApplicationId(Appid, UId);//, VisaTypeCode);
           }
           catch (Exception ex)
           {
               throw (ex);
           }

           finally
           {
               ObjDalUpdateApplicantPaymentVisaNormalApplicationId = null;
           }
       }

       public DataTable GetDataCashReceipt(string AppliId)
       {
           DataAccessLayer.DalPayableListBank ObjDalCashReceipt = null;
           try
           {
               ObjDalCashReceipt = new DataAccessLayer.DalPayableListBank();
               return ObjDalCashReceipt.GetDataCashReceipt(AppliId);
           }

           catch (Exception ex)
           {
               throw ex;
           }
       }
    }
}
