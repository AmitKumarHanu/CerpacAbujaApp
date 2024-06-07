using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BusinessEntityLayer
{
    public class BalBlacklistedPassportListDetails
    {
        #region Private Variables

        private string _PassportName;
        private string _PassportNumber { get; set; }
        private string _DateOfIssue { get; set; }
        private int _BlacklistedID { get; set; }
        private string _DateOfExpiry { get; set; }
        private string _PassportType { get; set; }

        #endregion

        #region Public Variables


        public string PassportName
        {
            get
            {
                return _PassportName;
            }
            set
            {
                _PassportName = value;
            }
        }
        public string PassportNumber
        {
            get
            {
                return _PassportNumber;
            }
            set
            {
                _PassportNumber = value;
            }
        }
        public string DateOfIssue
        {
            get
            {
                return _DateOfIssue;
            }
            set
            {
                _DateOfIssue = value;
            }
        }
        public int BlacklistedID
        {
            get
            {
                return _BlacklistedID;
            }
            set
            {
                _BlacklistedID = value;
            }
        }
        public string PassportType
        {
            get
            {
                return _PassportType;
            }
            set
            {
                _PassportType = value;
            }
        }
        public string DateOfExpiry
        {
            get
            {
                return _DateOfExpiry;
            }
            set
            {
                _DateOfExpiry = value;
            }
        }

        //public string Status { get; set; }
        public string ModifiedBy { get; set; }

        #endregion


        public DataSet GetBlacklistedPassportList()
        {
            DataAccessLayer.DalBlacklistedPassportListDetails ObjDalBlacklistedPassportInfo = null;
            DataSet ds = null;

            try
            {
                ObjDalBlacklistedPassportInfo = new DataAccessLayer.DalBlacklistedPassportListDetails();
                return ds = ObjDalBlacklistedPassportInfo.GetBlacklistedPassportList();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                ObjDalBlacklistedPassportInfo = null;
            }
        }

        public int InsertBlacklistedPassportDetail()
        {
            DataAccessLayer.DalBlacklistedPassportListDetails ObjDalBlacklistedPassportListDetails = null;
            DataTable dt = null;
            try
            {
                ObjDalBlacklistedPassportListDetails = new DataAccessLayer.DalBlacklistedPassportListDetails();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                //Code for adding columns in datatable.
                dt.Columns.Add("PassportName");
                dt.Columns.Add("PassportNumber");
                dt.Columns.Add("DateOfIssue");
                dt.Columns.Add("DateOfExpiry");
                dt.Columns.Add("PassportType");
                dt.Columns.Add("Nationality");
                //dt.Columns.Add("Status");
                dt.Columns.Add("ModifiedBy");

                dr["PassportName"] = this.PassportName;
                dr["PassportNumber"] = this.PassportNumber;
                dr["DateOfIssue"] = this.DateOfIssue;
                dr["DateOfExpiry"] = this.DateOfExpiry;
                dr["Nationality"] = this.Nationality;
                dr["PassportType"] = this.PassportType;
                //dr["Status"] = this.Status;
                dr["ModifiedBy"] = this.ModifiedBy;

                dt.Rows.Add(dr);

                return ObjDalBlacklistedPassportListDetails.InsertBlacklistedPassportDetail(dt);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dt = null;
                ObjDalBlacklistedPassportListDetails = null;
            }
        }

        public DataTable FetchBlacklistedPassportDetails()
        {
            DataAccessLayer.DalBlacklistedPassportListDetails ObjDalBlacklistedPassportListDetails = null;

            try
            {
                ObjDalBlacklistedPassportListDetails = new DataAccessLayer.DalBlacklistedPassportListDetails();
                return ObjDalBlacklistedPassportListDetails.FetchBlacklistedPassportDetails(this.BlacklistedID);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ObjDalBlacklistedPassportListDetails = null;

            }
        }

        public int UpdateBlacklistedPassportDetail()
        {
            DataAccessLayer.DalBlacklistedPassportListDetails ObjDalBlacklistedPassportListDetails = null;
            DataTable dt = null;
            try
            {
                ObjDalBlacklistedPassportListDetails = new DataAccessLayer.DalBlacklistedPassportListDetails();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                //Code for adding columns in datatable.                
                dt.Columns.Add("PassportName");
                dt.Columns.Add("PassportNumber");
                dt.Columns.Add("DateOfIssue");
                dt.Columns.Add("BlacklistedID");
                dt.Columns.Add("DateOfExpiry");
                dt.Columns.Add("PassportType");
                dt.Columns.Add("Nationality");
                // dt.Columns.Add("Status");
                dt.Columns.Add("ModifiedBy");

                dr["PassportName"] = this.PassportName;
                dr["PassportNumber"] = this.PassportNumber;
                dr["DateOfIssue"] = this.DateOfIssue;
                dr["BlacklistedID"] = this.BlacklistedID;
                dr["DateOfExpiry"] = this.DateOfExpiry;
                dr["Nationality"] = this.Nationality;
                dr["PassportType"] = this.PassportType;
                //dr["Status"] = this.Status;
                dr["ModifiedBy"] = this.ModifiedBy;

                dt.Rows.Add(dr);

                return ObjDalBlacklistedPassportListDetails.UpdateBlacklistedPassportDetail(dt);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dt = null;
                ObjDalBlacklistedPassportListDetails = null;
            }
        }

        public int DeleteDataRow(int keyvalue)
        {
            DataAccessLayer.DalBlacklistedPassportListDetails ObjDalBlacklistedPassportListDetails = null;
            ObjDalBlacklistedPassportListDetails = new DataAccessLayer.DalBlacklistedPassportListDetails();
            return ObjDalBlacklistedPassportListDetails.DeleteDataRow(keyvalue);
        }







        public int Nationality { get; set; }
    }
}
