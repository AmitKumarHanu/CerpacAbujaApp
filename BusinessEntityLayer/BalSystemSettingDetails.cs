using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BusinessEntityLayer
{
    public class BalSystemSettingDetails
    {
        #region Private Variables

        //private string _PassportName;
        private string _Code { get; set; }
        private string _Value { get; set; }
        private string _SystemSettingMasterID { get; set; }
        private string _ShortDesc { get; set; }
        // private string _PassportType { get; set; }

        #endregion

        #region Public Variables


        public string Code
        {
            get
            {
                return _Code;
            }
            set
            {
                _Code = value;
            }
        }
        public string Value
        {
            get
            {
                return _Value;
            }
            set
            {
                _Value = value;
            }
        }
        public string SystemSettingMasterID
        {
            get
            {
                return _SystemSettingMasterID;
            }
            set
            {
                _SystemSettingMasterID = value;
            }
        }
        public string ShortDesc
        {
            get
            {
                return _ShortDesc;
            }
            set
            {
                _ShortDesc = value;
            }
        }

        //public string Status { get; set; }
        public string ModifiedBy { get; set; }

        #endregion


        public DataSet GetSystemSettingList()
        {
            DataAccessLayer.DalSystemSettingDetails ObjDalSystemSettingInfo = null;
            DataSet ds = null;

            try
            {
                ObjDalSystemSettingInfo = new DataAccessLayer.DalSystemSettingDetails();
                return ds = ObjDalSystemSettingInfo.GetSystemSettingList();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                ObjDalSystemSettingInfo = null;
            }
        }

        public int InsertSystemSettingDetail()
        {
            DataAccessLayer.DalSystemSettingDetails ObjDalSystemSettingListDetails = null;
            DataTable dt = null;
            try
            {
                ObjDalSystemSettingListDetails = new DataAccessLayer.DalSystemSettingDetails();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                //Code for adding columns in datatable.
                dt.Columns.Add("Code");
                dt.Columns.Add("Value");
                dt.Columns.Add("ShortDesc");
                //dt.Columns.Add("DateOfExpiry");
                //dt.Columns.Add("PassportType");
                //dt.Columns.Add("Nationality");
                //dt.Columns.Add("Status");
                dt.Columns.Add("ModifiedBy");

                dr["Code"] = this.Code;
                dr["Value"] = this.Value;
                dr["ShortDesc"] = this.ShortDesc;
                //dr["DateOfExpiry"] = this.DateOfExpiry;
                //dr["Nationality"] = this.Nationality;
                //dr["PassportType"] = this.PassportType;
                //dr["Status"] = this.Status;
                dr["ModifiedBy"] = this.ModifiedBy;

                dt.Rows.Add(dr);

                return ObjDalSystemSettingListDetails.InsertSystemSettingDetail(dt);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dt = null;
                ObjDalSystemSettingListDetails = null;
            }
        }

        public DataTable FetchSystemSettingDetails(string id)
        {
            DataAccessLayer.DalSystemSettingDetails ObjDalSystemSettingListDetails = null;

            try
            {
                ObjDalSystemSettingListDetails = new DataAccessLayer.DalSystemSettingDetails();
                return ObjDalSystemSettingListDetails.FetchSystemSettingDetails(id);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ObjDalSystemSettingListDetails = null;

            }
        }

        public int UpdateSystemSettingDetail()
        {
            DataAccessLayer.DalSystemSettingDetails ObjDalSystemSettingListDetails = null;
            DataTable dt = null;
            try
            {
                ObjDalSystemSettingListDetails = new DataAccessLayer.DalSystemSettingDetails();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                //Code for adding columns in datatable.                
                dt.Columns.Add("Code");
                dt.Columns.Add("Value");
                dt.Columns.Add("ShortDesc");
                dt.Columns.Add("SystemSettingMasterID");
                //dt.Columns.Add("DateOfExpiry");
                //dt.Columns.Add("PassportType");
                //dt.Columns.Add("Nationality");
                // dt.Columns.Add("Status");
                dt.Columns.Add("ModifiedBy");

                dr["Code"] = this.Code;
                dr["Value"] = this.Value;
                dr["ShortDesc"] = this.ShortDesc;
                dr["SystemSettingMasterID"] = this.SystemSettingMasterID;
                //dr["DateOfExpiry"] = this.DateOfExpiry;
                //dr["Nationality"] = this.Nationality;
                // dr["PassportType"] = this.PassportType;
                //dr["Status"] = this.Status;
                dr["ModifiedBy"] = this.ModifiedBy;

                dt.Rows.Add(dr);

                return ObjDalSystemSettingListDetails.UpdateSystemSettingDetail(dt);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dt = null;
                ObjDalSystemSettingListDetails = null;
            }
        }

        public int DeleteDataRow(String keyvalue)
        {
            DataAccessLayer.DalSystemSettingDetails ObjDalSystemSettingListDetails = null;
            ObjDalSystemSettingListDetails = new DataAccessLayer.DalSystemSettingDetails();
            return ObjDalSystemSettingListDetails.DeleteDataRow(keyvalue);
        }



        public int PageIndex { get; set; }
    }
}
