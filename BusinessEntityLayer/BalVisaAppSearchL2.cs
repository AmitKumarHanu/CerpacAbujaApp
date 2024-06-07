using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace BusinessEntityLayer
{
    public class BalVisaAppSearchL2
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
            DataAccessLayer.DalVisaAppSearchL2 ObjDalVisaAppSearchL2 = null;

            try
            {
                ObjDalVisaAppSearchL2 = new DataAccessLayer.DalVisaAppSearchL2();


                return ObjDalVisaAppSearchL2.searchvisaappDal(this.ApplicationId, this.country, this.visatype, this.fromdate, this.todate, this.status);


            }
            catch (Exception ex)
            {
                throw (ex);
            }


        }

    }
}
