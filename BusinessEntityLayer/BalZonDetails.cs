using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BusinessEntityLayer
{
    public class BalZonDetails
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


        public DataSet GetZoneList()
        {
            DataAccessLayer.DalZonDetails ObjDalZonInfo = null;
            DataSet ds = null;

            try
            {
                ObjDalZonInfo = new DataAccessLayer.DalZonDetails();
                return ds = ObjDalZonInfo.GetZoneList();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                ObjDalZonInfo = null;
            }
        }

        public int InsertZonDetail()
        {
            DataAccessLayer.DalZonDetails ObjDalZonDetails = null;
            DataTable dt = null;
            try
            {
                ObjDalZonDetails = new DataAccessLayer.DalZonDetails();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                //Code for adding columns in datatable.
                dt.Columns.Add("CountryCode");
                //dt.Columns.Add("CityName");
                dt.Columns.Add("CityCode");
                dt.Columns.Add("ZonCode");
                //dt.Columns.Add("ZonName");
                dt.Columns.Add("Status");
                dt.Columns.Add("ModifiedBy");

                dr["CountryCode"] = this.CountryCode;
                //dr["CityName"] = this.CityName;
                dr["CityCode"] = this.CityCode;
                dr["ZonCode"] = this.ZonCode;
                // dr["ZonName"] = this.ZonName;
                dr["ModifiedBy"] = this.ModifiedBy;
                dr["Status"] = this.Status;

                dt.Rows.Add(dr);

                return ObjDalZonDetails.InsertZoneDetail(dt);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dt = null;
                ObjDalZonDetails = null;
            }
        }

        public DataTable FetchZonDetails()
        {
            DataAccessLayer.DalZonDetails ObjDalZonDetails = null;

            try
            {
                ObjDalZonDetails = new DataAccessLayer.DalZonDetails();
                return ObjDalZonDetails.FetchZonDetails(this.ZonCode.ToString());

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ObjDalZonDetails = null;

            }
        }

        public int UpdateZoneDetail()
        {
            DataAccessLayer.DalZonDetails ObjDalZonDetails = null;
            DataTable dt = null;
            try
            {
                ObjDalZonDetails = new DataAccessLayer.DalZonDetails();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                //Code for adding columns in datatable.                
                dt.Columns.Add("ZonCode");
                dt.Columns.Add("ZonName");
                dt.Columns.Add("ModifiedBy");

                dr["ZonCode"] = this.ZonCode;
                dr["ZonName"] = this.ZonName;
                dr["ModifiedBy"] = this.ModifiedBy;

                dt.Rows.Add(dr);

                return ObjDalZonDetails.UpdateZoneDetail(dt);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dt = null;
                ObjDalZonDetails = null;
            }
        }

        public int DeleteDataRow(string keyvalue)
        {
            DataAccessLayer.DalZonDetails ObjDalZonDetails = null;
            ObjDalZonDetails = new DataAccessLayer.DalZonDetails();
            return ObjDalZonDetails.DeleteDataRow(keyvalue);
        }

        public object ZonCode { get; set; }

        public object ZonName { get; set; }

        public DataSet GetZoneCityList()
        {
            DataAccessLayer.DalZonDetails ObjDalZonInfo = null;
            DataSet ds = null;

            try
            {
                ObjDalZonInfo = new DataAccessLayer.DalZonDetails();
                return ds = ObjDalZonInfo.GetZoneCityList();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                ObjDalZonInfo = null;
            }
        }



        public DataSet GetZonList()
        {
            DataAccessLayer.DalZonDetails ObjDalZonDetails = null;
            ObjDalZonDetails = new DataAccessLayer.DalZonDetails();
            return ObjDalZonDetails.GetZonList();
        }

        public DataSet GetZonUpdateList()
        {
            DataAccessLayer.DalZonDetails ObjDalZonDetails = null;
            ObjDalZonDetails = new DataAccessLayer.DalZonDetails();
            return ObjDalZonDetails.GetZonUpdateList();
        }

        public int DeletePrevdata(string p)
        {
            DataAccessLayer.DalZonDetails ObjDalZonDetails = null;
            ObjDalZonDetails = new DataAccessLayer.DalZonDetails();
            return ObjDalZonDetails.DeletePrevData(p);
        }
    }
}
