using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BusinessEntityLayer
{
    public class BalCountryDetails
    {       

        #region Private Variables       

        private string _Country_Name;
        private string _CountryCode;
        private string _Abbreviation;
        private string _Nationality;
        private string _ModifiedBy;
        
        #endregion

        #region Public Variables

        public string EmbassyId { get; set; } 
        public string Country_Name
        {
            get
            {
                return _Country_Name;
            }
            set
            {
                _Country_Name = value;
            }
        }
        public string CountryCode
        {
            get
            {
                return _CountryCode;
            }
            set
            {
                _CountryCode = value;
            }
        }
        public string Abbreviation
        {

            get
            {
                return _Abbreviation;
            }
            set
            {
                _Abbreviation = value;
            }

        }
        public string Nationality
        {

            get
            {
                return _Nationality;
            }
            set
            {
                _Nationality = value;
            }

        }
        public string Status { get; set; }
        public string EACFlag { get; set; }
        public string ModifiedBy
        {

            get
            {
                return _ModifiedBy;
            }
            set
            {
                _ModifiedBy = value;
            }

        }

        #endregion


        public DataTable GetCountryList()
        {
            DataAccessLayer.DalCountryDetails ObjDalCountryInfo = null;
            DataTable dt = null;
            dt = new DataTable();

            try
            {
                ObjDalCountryInfo = new DataAccessLayer.DalCountryDetails();
                return dt = ObjDalCountryInfo.GetCountryList();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                ObjDalCountryInfo = null;
            }
        }

        public int InsertCountryDetail()
        {
            DataAccessLayer.DalCountryDetails ObjDalCountryDetails = null;
            DataTable dt = null;
            try
            {
                ObjDalCountryDetails = new DataAccessLayer.DalCountryDetails();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                //Code for adding columns in datatable.
                dt.Columns.Add("CountryCode");
                dt.Columns.Add("Country_Name");
                dt.Columns.Add("Nationality");
                dt.Columns.Add("Abbreviation");
                dt.Columns.Add("Status");
                dt.Columns.Add("ModifiedBy");
                dt.Columns.Add("EACFlag");
                dt.Columns.Add("EmbassyId");

                dr["CountryCode"] = this.CountryCode;
                dr["Country_Name"] = this.Country_Name;
                dr["Nationality"] = this.Nationality;
                dr["Abbreviation"] = this.Abbreviation;
                dr["Status"] = this.Status;
                dr["ModifiedBy"] = this.ModifiedBy;
                dr["EACFlag"] = this.EACFlag;
                dr["EmbassyId"] = this.EmbassyId;

                dt.Rows.Add(dr);

                return ObjDalCountryDetails.InsertCountryDetail(dt);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dt = null;
                ObjDalCountryDetails = null;
            }
        }

        public DataTable FetchCountryDetails_CountryCode()
        {
            DataAccessLayer.DalCountryDetails ObjDalCountryDetails = null;

            try
            {
                ObjDalCountryDetails = new DataAccessLayer.DalCountryDetails();
                return ObjDalCountryDetails.FetchCountryDetails_CountryCode(this.CountryCode);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ObjDalCountryDetails = null;

            }
        }

        public int UpdateCountryDetail()
        {
            DataAccessLayer.DalCountryDetails ObjDalCountryDetails = null;
            DataTable dt = null;
            try
            {
                ObjDalCountryDetails = new DataAccessLayer.DalCountryDetails();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                //Code for adding columns in datatable.
                dt.Columns.Add("CountryCode");
                dt.Columns.Add("Country_Name");
                dt.Columns.Add("Nationality");
                dt.Columns.Add("Abbreviation");
                dt.Columns.Add("Status");
                dt.Columns.Add("ModifiedBy");
                dt.Columns.Add("EACFlag");
                dt.Columns.Add("EmbassyId");

                dr["CountryCode"] = this.CountryCode;
                dr["Country_Name"] = this.Country_Name;
                dr["Nationality"] = this.Nationality;
                dr["Abbreviation"] = this.Abbreviation;
                dr["Status"] = this.Status;
                dr["ModifiedBy"] = this.ModifiedBy;
                dr["EACFlag"] = this.EACFlag;
                dr["EmbassyId"] = this.EmbassyId;

                dt.Rows.Add(dr);

                return ObjDalCountryDetails.UpdateCountryDetail(dt);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dt = null;
                ObjDalCountryDetails = null;
            }
        }

        public int DeleteDataRow(string keyvalue)
        {
            DataAccessLayer.DalCountryDetails ObjDalCountryDetails = null;
            ObjDalCountryDetails = new DataAccessLayer.DalCountryDetails();
            return ObjDalCountryDetails.DeleteDataRow(keyvalue);
        }

    }
}
