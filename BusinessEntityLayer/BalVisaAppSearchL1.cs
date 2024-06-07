using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BusinessEntityLayer
{
   public class BalVisaAppSearchL1
    {
        #region  Automatic Properties

        public string ApplicationId { get; set; }
        public string visatype { get; set; }
        public string country { get; set; }
        public string fromdate { get; set; }
        public string todate { get; set; }
        public string status { get; set; }

        #endregion

        public DataTable searchvisaapp()
        {
            DataAccessLayer.DalVisaAppSearchL1 ObjDalVisaAppSearchL1 = null;

            try
            {
                ObjDalVisaAppSearchL1 = new DataAccessLayer.DalVisaAppSearchL1();


                return ObjDalVisaAppSearchL1.searchvisaappDal(this.ApplicationId, this.country, this.visatype, this.fromdate, this.todate, this.status);


            }
            catch (Exception ex)
            {
                throw (ex);
            }


        }
    }
}
