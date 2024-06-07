using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BusinessEntityLayer
{
    public class BalCountryVisaTypeDetails
    {
        #region Private Variables

        private string _COUNTRYCODE;
        private string _VISATYPECODE;
        private string _ENTRYTYPE;
        private string _PERIODTYPE;
        private string _PERIOD;
        private string _RATE;
        private string _COMMISION;

        
        #endregion

        #region Public Variables
        public int CountryVisaId { get; set; }

        public string COUNTRYCODE
        {
            get
            {
                return _COUNTRYCODE;
            }
            set
            {
                _COUNTRYCODE = value;
            }
        }

        public string VISATYPECODE
        {
            get
            {
                return _VISATYPECODE;
            }
            set
            {
                _VISATYPECODE = value;
            }
        }
        public string ENTRYTYPE
        {
            get
            {
                return _ENTRYTYPE;
            }
            set
            {
                _ENTRYTYPE = value;
            }
        }

        public string PERIODTYPE
        {
            get
            {
                return _PERIODTYPE;
            }
            set
            {
                PERIODTYPE= value;
            }
        }

        public string PERIOD
        {
            get
            {
                return _PERIOD;
            }
            set
            {
                PERIOD=value;
            }
        }

        public string RATE
        {
            get
            {
                return _RATE;
            }
            set
            {
                RATE=value;
            }
        }
        public string COMMISION
        {
            get
            {
                return _COMMISION;
            }
            set
            {
                COMMISION=value;
            }
        }




        #endregion


        public DataSet GetCountryVisaTypeList()
        {
            DataAccessLayer.DalCountryVisaTypeDetails ObjDalCountryVisaTypeInfo = null;
            DataSet ds = null;

            try
            {
                ObjDalCountryVisaTypeInfo = new DataAccessLayer.DalCountryVisaTypeDetails();
                return ds = ObjDalCountryVisaTypeInfo.GetCountryVisaTypeList();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                ObjDalCountryVisaTypeInfo = null;
            }
        }

        public int DeleteDataRow(int keyvalue)
        {
            DataAccessLayer.DalCountryVisaTypeDetails ObjDalCountryVisaTypeDetails = null;
            ObjDalCountryVisaTypeDetails = new DataAccessLayer.DalCountryVisaTypeDetails();
            return ObjDalCountryVisaTypeDetails.DeleteDataRow(keyvalue);
        }
    
    }
}
