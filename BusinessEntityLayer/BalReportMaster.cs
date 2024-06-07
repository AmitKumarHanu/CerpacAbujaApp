using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web;

 namespace BusinessEntityLayer
{
   public class BalReportMaster
    {
        #region Private Variables

       public string _ReportName;
       
       public string _ModifiedBy;
       


        #endregion

        #region Public Variables

        public string ReportName
        {
            get
            {
                return _ReportName;
            }
            set
            {
                _ReportName = value;
            }
        }

        public string ReportId { get; set; }
        public string GroupCode { get; set; }
        public string Status { get; set; }
        public string ModifiedBy { get; set; }

        #endregion


        public DataSet GetReportMasterList()
        {
            DataAccessLayer.DalReportMaster objDalReportMaster = null;
            DataSet ds = null;

            try
            {
                objDalReportMaster = new DataAccessLayer.DalReportMaster();
                return ds = objDalReportMaster.GetReportMasterList();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                objDalReportMaster = null;
            }
        }

        //public DataTable FetchReportDtails_ReportName()
        //{
        //    DataAccessLayer.DalReportMaster objDalReportMaster = null;

        //    try
        //    {
        //        objDalReportMaster = new DataAccessLayer.DalReportMaster();
        //        return objDalReportMaster.FetchReportDetails_ReportName(this._ReportName);
                 
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        objDalReportMaster = null;

        //    }
        //}

        public int InsertReportDetail()
        {
            DataAccessLayer.DalReportMaster objDalReportMaster = null;
            DataTable dt = null;
            try
            {
                objDalReportMaster = new DataAccessLayer.DalReportMaster();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                //Code for adding columns in datatable.
                dt.Columns.Add("ReportName");
                dt.Columns.Add("GroupCode");
                dt.Columns.Add("Status");
                dt.Columns.Add("ModifiedBy");

                dr["ReportName"] = this.ReportName;
                dr["GroupCode"] = this.GroupCode;
                dr["Status"] = this.Status;
                dr["ModifiedBy"] = this.ModifiedBy;

                dt.Rows.Add(dr);

                return objDalReportMaster.InsertReportDetail(dt);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dt = null;
                objDalReportMaster = null;
            }
        }
        public DataTable FetchReportDetails()
        {
            DataAccessLayer.DalReportMaster ObjDalReportMaster = null;

            try
            {
               ObjDalReportMaster = new DataAccessLayer.DalReportMaster();
               return ObjDalReportMaster.FetchReportDetails_ReportName(this.ReportName);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ObjDalReportMaster = null;

            }
        }

        public int UpdateReportMasterDetail()
        {
            DataAccessLayer.DalReportMaster objDalReportMaster = null;
            DataTable dt = null;
            try
            {
                objDalReportMaster = new DataAccessLayer.DalReportMaster();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                //Code for adding columns in datatable.                
                dt.Columns.Add("ReportId");
                dt.Columns.Add("ReportName");
                dt.Columns.Add("GroupCode");
                dt.Columns.Add("Status");
                dt.Columns.Add("ModifiedBy");

                dr["ReportId"] = this.ReportId;
                dr["ReportName"] = this.ReportName;
                dr["GroupCode"] = this.GroupCode;
                dr["Status"] = this.Status;
                dr["ModifiedBy"] = this.ModifiedBy;

                dt.Rows.Add(dr);
                return objDalReportMaster.UpdateReportDetail(dt);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dt = null;
                objDalReportMaster = null;
            }
        }
        public int DeleteDataRow(string keyvalue)
        {
            DataAccessLayer.DalReportMaster objDalReportMaster = null;
            objDalReportMaster = new DataAccessLayer.DalReportMaster();
            return objDalReportMaster.DeleteDataRow(keyvalue); 
        }
    }
 }





