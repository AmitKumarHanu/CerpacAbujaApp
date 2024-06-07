using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BusinessEntityLayer
{
    public class BalActivityDetails
    {
        #region Private Variables

        private string _ActivityName;
        private int _ActivityID { get; set; }
        private string _ActivityType{ get; set; }
        private string _ActivityCode { get; set; }
        
        #endregion

        #region Public Variables


        public string ActivityName
        {
            get
            {
                return _ActivityName;
            }
            set
            {
                _ActivityName = value;
            }
        }
        public int ActivityID
        {
            get
            {
                return _ActivityID;
            }
            set
            {
                _ActivityID = value;
            }
        }
        public string ActivityType
        {
            get
            {
                return _ActivityType;
            }
            set
            {
                _ActivityType = value;
            }
        }
        public string ActivityCode
        {
            get
            {
                return _ActivityCode;
            }
            set
            {
                _ActivityCode= value;
            }
        }
        public string Status { get; set; }
        public string ModifiedBy { get; set; }

        #endregion


        public DataSet GetActivityList()
        {
            DataAccessLayer.DalActivityDetails ObjDalActivityInfo = null;
            DataSet ds = null;

            try
            {
                ObjDalActivityInfo = new DataAccessLayer.DalActivityDetails();
                return ds = ObjDalActivityInfo.GetActivityList();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                ObjDalActivityInfo = null;
            }
        }

        public int InsertActivityDetail()
        {
            DataAccessLayer.DalActivityDetails ObjDalActivityDetails = null;
            DataTable dt = null;
            try
            {
                ObjDalActivityDetails = new DataAccessLayer.DalActivityDetails();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                //Code for adding columns in datatable.
                dt.Columns.Add("ActivityName");
                dt.Columns.Add("ActivityType");
                dt.Columns.Add("ActivityCode");
               // dt.Columns.Add("Status");
                dt.Columns.Add("ModifiedBy");

                dr["ActivityName"] = this.ActivityName;
                dr["ActivityType"] = this.ActivityType;
                dr["ActivityCode"] = this.ActivityCode;
                //dr["Status"] = this.Status;
                dr["ModifiedBy"] = this.ModifiedBy;

                dt.Rows.Add(dr);

                return ObjDalActivityDetails.InsertActivityDetail(dt);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dt = null;
                ObjDalActivityDetails = null;
            }
        }

        public DataTable FetchActivityDetails()
        {
            DataAccessLayer.DalActivityDetails ObjDalActivityDetails = null;

            try
            {
                ObjDalActivityDetails = new DataAccessLayer.DalActivityDetails();
                return ObjDalActivityDetails.FetchActivityDetails(this.ActivityID);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ObjDalActivityDetails = null;

            }
        }

        public int UpdateActivityDetail()
        {
            DataAccessLayer.DalActivityDetails ObjDalActivityDetails = null;
            DataTable dt = null;
            try
            {
                ObjDalActivityDetails = new DataAccessLayer.DalActivityDetails();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                //Code for adding columns in datatable.                
                dt.Columns.Add("ActivityName");
                dt.Columns.Add("ActivityType");
                dt.Columns.Add("ActivityCode");
                dt.Columns.Add("ActivityID");
                //dt.Columns.Add("Status");
                dt.Columns.Add("ModifiedBy");

                dr["ActivityName"] = this.ActivityName;
                dr["ActivityType"] = this.ActivityType;
                dr["ActivityCode"] = this.ActivityCode;
                dr["ActivityID"] = this.ActivityID;
               // dr["Status"] = this.Status;
                dr["ModifiedBy"] = this.ModifiedBy;

                dt.Rows.Add(dr);

                return ObjDalActivityDetails.UpdateActivityDetail(dt);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dt = null;
                ObjDalActivityDetails = null;
            }
        }

        public int DeleteDataRow(string keyvalue)
        {
            DataAccessLayer.DalActivityDetails ObjDalActivityDetails = null;
            ObjDalActivityDetails = new DataAccessLayer.DalActivityDetails();
            return ObjDalActivityDetails.DeleteDataRow(keyvalue);
        }





        
    }
}
