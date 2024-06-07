using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BusinessEntityLayer
{
    public class BalVisaAppSearchL3
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
            DataAccessLayer.DalVisaAppSearchL3 ObjDalVisaAppSearchL3 = null;
            
            try
            {
                ObjDalVisaAppSearchL3 = new DataAccessLayer.DalVisaAppSearchL3();
             

                return ObjDalVisaAppSearchL3.searchvisaappDal(this.ApplicationId,this.country,this.visatype,this.fromdate,this.todate,this.status);

                
            }
            catch (Exception ex)
            {
                throw (ex);
            }

           
        }

    }
}
