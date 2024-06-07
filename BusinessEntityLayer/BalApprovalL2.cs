using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BusinessEntityLayer
{
    public class BalApprovalL2
    {
        public DataTable GetVisaPandingList2(string L1id)
        {
            DataAccessLayer.DalApprovalL2 ObjDalApprovalL2 = null;
            DataTable dt = null;
            dt = new DataTable();

            try
            {
                ObjDalApprovalL2 = new DataAccessLayer.DalApprovalL2();
                return dt = ObjDalApprovalL2.GetDalVisaPandingListL2(L1id);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                ObjDalApprovalL2 = null;
            }
        }

        public DataTable GetDalVisaPandingListL1ByL2(string id)
        {
            DataAccessLayer.DalApprovalL2 ObjDalApprovalL2 = null;
            DataTable dt = null;
            dt = new DataTable();

            try
            {
                ObjDalApprovalL2 = new DataAccessLayer.DalApprovalL2();
                return dt = ObjDalApprovalL2.GetDalVisaPandingListL1ByL2(id);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                ObjDalApprovalL2 = null;
            }
        }

        public DataTable GetDalVisaPandingListL1ByL2_ByDate(string id, DateTime FromDate, DateTime ToDate)
        {
            DataAccessLayer.DalApprovalL2 ObjDalApprovalL2 = null;
            DataTable dt = null;
            dt = new DataTable();

            try
            {
                ObjDalApprovalL2 = new DataAccessLayer.DalApprovalL2();
                return dt = ObjDalApprovalL2.GetDalVisaPandingListL1ByL2_ByDate(id, FromDate, ToDate);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                ObjDalApprovalL2 = null;
            }
        }
    }
}
