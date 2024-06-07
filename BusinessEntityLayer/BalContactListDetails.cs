using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BusinessEntityLayer
{
    public class BalContactListDetails
    {
        #region Private Variables

        private string _PersonName;
        private string _Email { get; set; }
        private int _QueryId { get; set; }
        private string _Message { get; set; }
        private string _queryfor { get; set; }

        #endregion

        #region Public Variables


        public string PersonName
        {
            get
            {
                return _PersonName;
            }
            set
            {
                _PersonName = value;
            }
        }
        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
            }
        }
        public string Message
        {
            get
            {
                return _Message;
            }
            set
            {
                _Message = value;
            }
        }
        public string queryfor
        {
            get
            {
                return _queryfor;
            }
            set
            {
                _queryfor = value;
            }
        }
        public int QueryId
        {
            get
            {
                return _QueryId;
            }
            set
            {
                _QueryId = value;
            }
        }


        //public string Status { get; set; }
        public string ModifiedBy { get; set; }

        #endregion


        public DataSet GetContactList(string strStatus)
        {
            DataAccessLayer.DalContactListDetails ObjDalContactInfo = null;
            DataSet ds = null;

            try
            {
                ObjDalContactInfo = new DataAccessLayer.DalContactListDetails();
                return ds = ObjDalContactInfo.GetContactList(strStatus);

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                ObjDalContactInfo = null;
            }
        }

        public int ViewContactDetail()
        {
            DataAccessLayer.DalContactListDetails ObjDalContactListDetails = null;
            DataTable dt = null;
            try
            {
                ObjDalContactListDetails = new DataAccessLayer.DalContactListDetails();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                //Code for adding columns in datatable.
                dt.Columns.Add("QueryId");
                dt.Columns.Add("UserID");
                dt.Columns.Add("Message");
                //dt.Columns.Add("queryfor");
                //dt.Columns.Add("DateOfExpiry");
                //dt.Columns.Add("PassportType");
                //dt.Columns.Add("Nationality");
                //dt.Columns.Add("Status");
                dt.Columns.Add("ModifiedBy");

                dr["QueryId"] = this.QueryId;
                dr["UserID"] = this.UserID;
                dr["Message"] = this.Message;
                //dr["queryfor"] = this.queryfor;
                //dr["DateOfExpiry"] = this.DateOfExpiry;
                //dr["Nationality"] = this.Nationality;
                //dr["PassportType"] = this.PassportType;
                //dr["Status"] = this.Status;


                dt.Rows.Add(dr);

                return ObjDalContactListDetails.ViewContactDetail(dt);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dt = null;
                ObjDalContactListDetails = null;
            }
        }

        public DataTable FetchContactDetails()
        {
            DataAccessLayer.DalContactListDetails ObjDalContactListDetails = null;

            try
            {
                ObjDalContactListDetails = new DataAccessLayer.DalContactListDetails();
                return ObjDalContactListDetails.FetchContactDetails(this.QueryId);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ObjDalContactListDetails = null;

            }
        }

        //public int UpdateBlacklistedPassportDetail()
        //{
        //    DataAccessLayer.DalContactListDetails ObjDalContactListDetails = null;
        //    DataTable dt = null;
        //    try
        //    {
        //        ObjDalContactListDetails = new DataAccessLayer.DalContactListDetails();
        //        dt = new DataTable();

        //        DataRow dr = dt.NewRow();

        //        //Code for adding columns in datatable.                
        //        dt.Columns.Add("PassportName");
        //        dt.Columns.Add("PassportNumber");
        //        dt.Columns.Add("DateOfIssue");
        //        dt.Columns.Add("BlacklistedID");
        //        dt.Columns.Add("DateOfExpiry");
        //        dt.Columns.Add("PassportType");
        //        dt.Columns.Add("Nationality");
        //        // dt.Columns.Add("Status");
        //        dt.Columns.Add("ModifiedBy");

        //        dr["PassportName"] = this.PassportName;
        //        dr["PassportNumber"] = this.PassportNumber;
        //        dr["DateOfIssue"] = this.DateOfIssue;
        //        dr["BlacklistedID"] = this.BlacklistedID;
        //        dr["DateOfExpiry"] = this.DateOfExpiry;
        //        dr["Nationality"] = this.Nationality;
        //        dr["PassportType"] = this.PassportType;
        //        //dr["Status"] = this.Status;
        //        dr["ModifiedBy"] = this.ModifiedBy;

        //        dt.Rows.Add(dr);

        //        return ObjDalBlacklistedPassportListDetails.UpdateBlacklistedPassportDetail(dt);


        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }

        //    finally
        //    {
        //        dt = null;
        //        ObjDalBlacklistedPassportListDetails = null;
        //    }
        //}

        //public int DeleteDataRow(int keyvalue)
        //{
        //    DataAccessLayer.DalBlacklistedPassportListDetails ObjDalBlacklistedPassportListDetails = null;
        //    ObjDalBlacklistedPassportListDetails = new DataAccessLayer.DalBlacklistedPassportListDetails();
        //    return ObjDalBlacklistedPassportListDetails.DeleteDataRow(keyvalue);
        //}







        //    public int Nationality { get; set; }
        //}

        public object UserID { get; set; }
    }

}
