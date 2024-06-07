using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BusinessEntityLayer
{
    public class BalZoneDetails
    {

        #region Private Variables

        private string _ZoneCode;
        private string _ZoneDesc;
        private string _ZoneFullName;
        private string _Address;
        private string _ZonalOfficer;
        private string _EmailID;
        private string _MobileNo;

        #endregion

        #region Public Variables

        public string ZoneCode
        {
            get
            {
                return _ZoneCode;
            }
            set
            {
                _ZoneCode = value;
            }
        }
        public string ZoneDesc
        {
            get
            {
                return _ZoneDesc;
            }
            set
            {
                _ZoneDesc = value;
            }
        }
        public string ZoneFullName
        {

            get
            {
                return _ZoneFullName;
            }
            set
            {
                _ZoneFullName = value;
            }

        }
        public string Address
        {

            get
            {
                return _Address;
            }
            set
            {
                _Address = value;
            }

        }
        public string ZonalOfficer
        {

            get
            {
                return _ZonalOfficer;
            }
            set
            {
                _ZonalOfficer = value;
            }

        }
        public string EmailID
        {

            get
            {
                return _EmailID;
            }
            set
            {
                _EmailID = value;
            }

        }
        // public string Status { get; set; }
        // public string EACFlag { get; set; }

        public string MobileNo
        {

            get
            {
                return _MobileNo;
            }
            set
            {
                _MobileNo = value;
            }

        }

        #endregion


        public DataSet GetZoneList()
        {
            DataAccessLayer.DalZoneDetails ObjDalZoneInfo = null;
            DataSet ds = null;
            ds = new DataSet();

            try
            {
                ObjDalZoneInfo = new DataAccessLayer.DalZoneDetails();
                return ds = ObjDalZoneInfo.GetZoneList();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                ObjDalZoneInfo = null;
            }
        }

        public int InsertZoneDetail()
        {
            DataAccessLayer.DalZoneDetails ObjDalZoneDetails = null;
            DataTable dt = null;
            try
            {
                ObjDalZoneDetails = new DataAccessLayer.DalZoneDetails();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                //Code for adding columns in datatable.
                dt.Columns.Add("ZoneCode");
                dt.Columns.Add("ZoneDesc");
                dt.Columns.Add("ZoneFullName");
                dt.Columns.Add("Address");
                dt.Columns.Add("ZonalOfficer");
                dt.Columns.Add("EmailID");
                dt.Columns.Add("MobileNo");
                //dt.Columns.Add("EACFlag");

                dr["ZoneCode"] = this.ZoneCode;
                dr["ZoneDesc"] = this.ZoneDesc;
                dr["ZoneFullName"] = this.ZoneFullName;
                dr["Address"] = this.Address;
                dr["ZonalOfficer"] = this.ZonalOfficer;
                dr["EmailID"] = this.EmailID;
                dr["MobileNo"] = this.MobileNo;
                // dr["EACFlag"] = this.EACFlag;

                dt.Rows.Add(dr);

                return ObjDalZoneDetails.InsertZoneDetail(dt);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dt = null;
                ObjDalZoneDetails = null;
            }
        }

        public DataTable FetchZoneDetails_ZoneCode()
        {
            DataAccessLayer.DalZoneDetails ObjDalZoneDetails = null;

            try
            {
                ObjDalZoneDetails = new DataAccessLayer.DalZoneDetails();
                return ObjDalZoneDetails.FetchZoneDetails_ZoneCode(this.ZoneCode);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ObjDalZoneDetails = null;

            }
        }

        public int UpdateZoneDetail()
        {
            DataAccessLayer.DalZoneDetails ObjDalZoneDetails = null;
            DataTable dt = null;
            try
            {
                ObjDalZoneDetails = new DataAccessLayer.DalZoneDetails();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                //Code for adding columns in datatable.
                dt.Columns.Add("ZoneCode");
                dt.Columns.Add("ZoneDesc");
                dt.Columns.Add("ZoneFullName");
                dt.Columns.Add("Address");
                dt.Columns.Add("ZonalOfficer");
                dt.Columns.Add("EmailID");
                dt.Columns.Add("MobileNo");

                dr["ZoneCode"] = this.ZoneCode;
                dr["ZoneDesc"] = this.ZoneDesc;
                dr["ZoneFullName"] = this.ZoneFullName;
                dr["Address"] = this.Address;
                dr["ZonalOfficer"] = this.ZonalOfficer;
                dr["EmailID"] = this.EmailID;
                dr["MobileNo"] = this.MobileNo;
                // dr["EACFlag"] = this.EACFlag;

                dt.Rows.Add(dr);

                return ObjDalZoneDetails.UpdateZoneDetail(dt);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dt = null;
                ObjDalZoneDetails = null;
            }
        }

        public int DeleteDataRow(string keyvalue)
        {
            DataAccessLayer.DalZoneDetails ObjDalZoneDetails = null;
            ObjDalZoneDetails = new DataAccessLayer.DalZoneDetails();
            return ObjDalZoneDetails.DeleteDataRow(keyvalue);
        }



    }
}
