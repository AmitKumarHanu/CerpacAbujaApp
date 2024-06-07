using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BusinessEntityLayer
{
    public class BalCityDetails
    {
        #region Private Variables

        private string _CityCode;
        private string _CityName;
        
        
        #endregion

        #region Public Variables

        public string CountryCode { get; set; }
        public string CityCode
        {
            get
            {
                return _CityCode;
            }
            set
            {
                _CityCode = value;
            }
        }

        public string CityName
        {
            get
            {
                return _CityName;
            }
            set
            {
                _CityName = value;
            }
        }
        public string Status { get; set; }
        public string ModifiedBy { get; set; }

        #endregion


        public DataSet GetCityList()
        {
            DataAccessLayer.DalCityDetails ObjDalCityInfo = null;
            DataSet ds = null;

            try
            {
                ObjDalCityInfo = new DataAccessLayer.DalCityDetails();
                return ds = ObjDalCityInfo.GetCityList();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                ObjDalCityInfo = null;
            }
        }

        public int InsertCityDetail()
        {
            DataAccessLayer.DalCityDetails ObjDalCityDetails = null;
            DataTable dt = null;
            try
            {
                ObjDalCityDetails = new DataAccessLayer.DalCityDetails();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                //Code for adding columns in datatable.
                dt.Columns.Add("CountryCode");
                dt.Columns.Add("CityCode");
                dt.Columns.Add("CityName");
                dt.Columns.Add("Status");
                dt.Columns.Add("ModifiedBy");

                dr["CountryCode"] = this.CountryCode;
                dr["CityCode"] = this.CityCode;
                dr["CityName"] = this.CityName;
                dr["Status"] = this.Status;
                dr["ModifiedBy"] = this.ModifiedBy;

                dt.Rows.Add(dr);

                return ObjDalCityDetails.InsertCityDetail(dt);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dt = null;
                ObjDalCityDetails = null;
            }
        }

        public DataTable FetchCityDetails()
        {
            DataAccessLayer.DalCityDetails ObjDalCityDetails = null;

            try
            {
                ObjDalCityDetails = new DataAccessLayer.DalCityDetails();
                return ObjDalCityDetails.FetchCityDetails(this.CityCode);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ObjDalCityDetails = null;

            }
        }

        public int UpdateCityDetail()
        {
            DataAccessLayer.DalCityDetails ObjDalCityDetails = null;
            DataTable dt = null;
            try
            {
                ObjDalCityDetails = new DataAccessLayer.DalCityDetails();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                //Code for adding columns in datatable.                
                dt.Columns.Add("CityCode");
                dt.Columns.Add("CityName");
                dt.Columns.Add("Status");
                dt.Columns.Add("ModifiedBy");
                                
                dr["CityCode"] = this.CityCode;
                dr["CityName"] = this.CityName;
                dr["Status"] = this.Status;
                dr["ModifiedBy"] = this.ModifiedBy;

                dt.Rows.Add(dr);

                return ObjDalCityDetails.UpdateCityDetail(dt);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dt = null;
                ObjDalCityDetails = null;
            }
        }

        public int DeleteDataRow(string keyvalue)
        {
            DataAccessLayer.DalCityDetails ObjDalCityDetails = null;
            ObjDalCityDetails = new DataAccessLayer.DalCityDetails();
            return ObjDalCityDetails.DeleteDataRow(keyvalue);
        }
    }
}
