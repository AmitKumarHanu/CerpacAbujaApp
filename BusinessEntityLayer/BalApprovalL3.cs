using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BusinessEntityLayer
{
    public class BalApprovalL3
    {

        public DataTable GetVisaPandingList(string L1id)
        {
            DataAccessLayer.DalApprovalL3 ObjDalApprovalL3 = null;
            DataTable dt = null;
            dt = new DataTable();

            try
            {
                ObjDalApprovalL3 = new DataAccessLayer.DalApprovalL3();
                return dt = ObjDalApprovalL3.GetDalVisaPandingList(L1id);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                ObjDalApprovalL3 = null;
            }
        }

        public DataTable GetVisaPandingListL2(string L2id)
        {
            DataAccessLayer.DalApprovalL3 ObjDalApprovalL3 = null;
            DataTable dt = null;
            dt = new DataTable();

            try
            {
                ObjDalApprovalL3 = new DataAccessLayer.DalApprovalL3();
                return dt = ObjDalApprovalL3.GetVisaPandingListL2(L2id);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                ObjDalApprovalL3 = null;
            }
        }

        public DataTable GetVisaPandingListL1(string L3id)
        {
            DataAccessLayer.DalApprovalL3 ObjDalApprovalL3 = null;
            DataTable dt = null;
            dt = new DataTable();

            try
            {
                ObjDalApprovalL3 = new DataAccessLayer.DalApprovalL3();
                return dt = ObjDalApprovalL3.GetVisaPandingListL1(L3id);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                ObjDalApprovalL3 = null;
            }
        }


        public DataTable GetDalVisaPandingListL3ByL2(string id)
        {
            DataAccessLayer.DalApprovalL3 ObjDalApprovalL2 = null;
            DataTable dt = null;
            dt = new DataTable();

            try
            {
                ObjDalApprovalL2 = new DataAccessLayer.DalApprovalL3();
                return dt = ObjDalApprovalL2.GetDalVisaPandingListL3ByL2(id);


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

        public DataTable GetDalVisaPandingListL3ByL2_ByDate(string id, DateTime FromDate, DateTime ToDate)
        {
            DataAccessLayer.DalApprovalL3 ObjDalApprovalL2 = null;
            DataTable dt = null;
            dt = new DataTable();

            try
            {
                ObjDalApprovalL2 = new DataAccessLayer.DalApprovalL3();
                return dt = ObjDalApprovalL2.GetDalVisaPandingListL3ByL2_ByDate(id, FromDate, ToDate);


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
