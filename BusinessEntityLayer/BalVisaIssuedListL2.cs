using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


namespace BusinessEntityLayer
{
   public class BalVisaIssuedListL2
    {
       public DataTable GetVisaPandingList(string L1id)
           {
               DataAccessLayer.DalVisaIssuedListL2 ObjDalVisaIssuedListL2 = null;
               DataTable dt = null;
               dt = new DataTable();

               try
               {
                   ObjDalVisaIssuedListL2 = new DataAccessLayer.DalVisaIssuedListL2();
                   return dt = ObjDalVisaIssuedListL2.GetDalVisaPandingList(L1id);


               }
               catch (Exception ex)
               {
                   throw (ex);
               }

               finally
               {
                   ObjDalVisaIssuedListL2 = null;
               }
           }
       }
    }

