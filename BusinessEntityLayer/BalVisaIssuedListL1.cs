using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BusinessEntityLayer
{
    public class BalVisaIssuedListL1
    {
        public DataTable GetVisaPandingList(string L1id)
        {
            DataAccessLayer.DalVisaIssuedListL1 ObjDalVisaIssuedListL1 = null;
            DataTable dt = null;
            dt = new DataTable();

            try
            {
                ObjDalVisaIssuedListL1 = new DataAccessLayer.DalVisaIssuedListL1();
                return dt = ObjDalVisaIssuedListL1.GetDalVisaPandingList(L1id);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                ObjDalVisaIssuedListL1 = null;
            }
        }
    }
}
