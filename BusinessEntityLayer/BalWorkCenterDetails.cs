using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BusinessEntityLayer
{
    public class BalWorkCenterDetails
    {
        #region Private Variables

        private string _WorkCenter;
        private int _WorkCenterID { get; set; }
        
        #endregion

        #region Public Variables

       
        public string WorkCenter
        {
            get
            {
                return _WorkCenter;
            }
            set
            {
                _WorkCenter = value;
            }
        }
        public int WorkCenterID
        {
            get
            {
                return _WorkCenterID;
            }
            set
            {
                _WorkCenterID = value;
            }
        }
                
        public string Status { get; set; }
        public string ModifiedBy { get; set; }

        #endregion


        public DataSet GetWorkCenterList()
        {
            DataAccessLayer.DalWorkCenterDetails ObjDalWorkCenterInfo = null;
            DataSet ds = null;

            try
            {
                ObjDalWorkCenterInfo = new DataAccessLayer.DalWorkCenterDetails();
                return ds = ObjDalWorkCenterInfo.GetWorkCenterList();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                ObjDalWorkCenterInfo = null;
            }
        }

        public int InsertWorkCenterDetail()
        {
            DataAccessLayer.DalWorkCenterDetails ObjDalWorkCenterDetails = null;
            DataTable dt = null;
            try
            {
                ObjDalWorkCenterDetails = new DataAccessLayer.DalWorkCenterDetails();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                //Code for adding columns in datatable.
                dt.Columns.Add("WorkCenter");
                
                dt.Columns.Add("Status");
                dt.Columns.Add("ModifiedBy");

                dr["WorkCenter"] = this.WorkCenter;
                dr["Status"] = this.Status;
                dr["ModifiedBy"] = this.ModifiedBy;

                dt.Rows.Add(dr);

                return ObjDalWorkCenterDetails.InsertWorkCenterDetail(dt);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dt = null;
                ObjDalWorkCenterDetails = null;
            }
        }

        public DataTable FetchWorkCenterDetails()
        {
            DataAccessLayer.DalWorkCenterDetails ObjDalWorkCenterDetails = null;

            try
            {
                ObjDalWorkCenterDetails = new DataAccessLayer.DalWorkCenterDetails();
                return ObjDalWorkCenterDetails.FetchWorkCenterDetails(this.WorkCenterID);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ObjDalWorkCenterDetails = null;

            }
        }

        public int UpdateWorkCenterDetail()
        {
            DataAccessLayer.DalWorkCenterDetails ObjDalWorkCenterDetails = null;
            DataTable dt = null;
            try
            {
                ObjDalWorkCenterDetails = new DataAccessLayer.DalWorkCenterDetails();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                //Code for adding columns in datatable.                
                dt.Columns.Add("WorkCenter");
                dt.Columns.Add("WorkCenterID");
                dt.Columns.Add("Status");
                dt.Columns.Add("ModifiedBy");

                dr["WorkCenterID"] = this.WorkCenterID;
                dr["WorkCenter"] = this.WorkCenter;
                dr["Status"] = this.Status;
                dr["ModifiedBy"] = this.ModifiedBy;

                dt.Rows.Add(dr);

                return ObjDalWorkCenterDetails.UpdateWorkCenterDetail(dt);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dt = null;
                ObjDalWorkCenterDetails = null;
            }
        }

        public int DeleteDataRow(string keyvalue)
        {
            DataAccessLayer.DalWorkCenterDetails ObjDalWorkCenterDetails = null;
            ObjDalWorkCenterDetails = new DataAccessLayer.DalWorkCenterDetails();
            return ObjDalWorkCenterDetails.DeleteDataRow(keyvalue);
        }





        
    }
}
