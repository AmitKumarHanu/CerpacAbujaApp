using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BusinessEntityLayer
{
    public class BalApplicantStatusChangeL3
    {
        public DataTable GetApplicantStatusList(string L3id)
        {
            DataAccessLayer.DalApplicantStatusChangeL3 ObjDalApplicantStatusChangeL3 = null;
            DataTable dt = null;
            dt = new DataTable();

            try
            {
                ObjDalApplicantStatusChangeL3 = new DataAccessLayer.DalApplicantStatusChangeL3();
                return dt = ObjDalApplicantStatusChangeL3.GetApplicantStatusList(L3id);

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                ObjDalApplicantStatusChangeL3 = null;
            }
        }

        public DataTable GetApplicantStatusById(string ApplicationId, string Userid)
        {
            DataAccessLayer.DalApplicantStatusChangeL3 ObjDalApplicantStatusChangeL3 = null;
            DataTable dt = new DataTable();

            try
            {
                ObjDalApplicantStatusChangeL3 = new DataAccessLayer.DalApplicantStatusChangeL3();
                return dt = ObjDalApplicantStatusChangeL3.GetApplicantStatusById(ApplicationId,Userid);
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                ObjDalApplicantStatusChangeL3 = null;
            }
        }


    }
}
