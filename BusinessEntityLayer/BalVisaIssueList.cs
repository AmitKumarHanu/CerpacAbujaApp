using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BusinessEntityLayer
{
   public class BalVisaIssueList
    {

       public DataTable GetVisaPandingList(string L1id)
       {
           DataAccessLayer.DalVisaIssueList ObjDalvisaissue = null;
           DataTable dt = null;
           dt = new DataTable();

           try
           {
               ObjDalvisaissue = new DataAccessLayer.DalVisaIssueList();
               return dt = ObjDalvisaissue.GetDalVisaPandingList(L1id);


           }
           catch (Exception ex)
           {
               throw (ex);
           }

           finally
           {
               ObjDalvisaissue = null;
           }
       }
    }
}
