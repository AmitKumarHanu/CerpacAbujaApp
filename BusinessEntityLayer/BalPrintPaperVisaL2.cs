using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BusinessEntityLayer
{
   public  class BalPrintPaperVisaL2
    {
        public DataTable GetApprovedVisaDetail(string Applicant)
        {
            DataAccessLayer.DalPrintPaperVisaL2 objDalPrintPaperVisaL2 = null;
            DataTable dt = null;
            dt = new DataTable();

            try
            {
                objDalPrintPaperVisaL2 = new DataAccessLayer.DalPrintPaperVisaL2();
                return dt = objDalPrintPaperVisaL2.GetApprovedVisaDetailDL(Applicant);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                objDalPrintPaperVisaL2 = null;
            }
        }


        public DataTable UpadatePaperVisaStatus(string Applicant)
        {
            DataAccessLayer.DalPrintPaperVisaL2 objDalPrintPaperVisaL2 = null;
            DataTable dt = null;
            dt = new DataTable();

            try
            {
                objDalPrintPaperVisaL2 = new DataAccessLayer.DalPrintPaperVisaL2();
                return dt = objDalPrintPaperVisaL2.UpadatePaperVisaStatusDL(Applicant);
                //dt = objDalPrintVisa.UpadatePaperVisaStatusDL(Applicant);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                objDalPrintPaperVisaL2 = null;
            }
        }
    }
}
