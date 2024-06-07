using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BusinessEntityLayer
{
    public class BalVisaTypeDetails
    {

        public string VisaTypeCode { get; set; }
        public string SVisaTypeName { get; set; }
        public string VisaTypeName { get; set; }
        public string Status { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public string flagEmove { get; set; }



        
        public DataSet GetVisaTypeList()
        {
            DataAccessLayer.DalVisaTypeDetails ObjDalVisaTypeInfo = null;
            DataSet ds = null;

            try
            {
                ObjDalVisaTypeInfo = new DataAccessLayer.DalVisaTypeDetails();
                return ds = ObjDalVisaTypeInfo.GetVisaTypeList();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                ObjDalVisaTypeInfo = null;
            }
        }
        public DataSet GetDocList()
        {
            DataAccessLayer.DalVisaTypeDetails ObjDalVisaTypeDetails = null;
            ObjDalVisaTypeDetails = new DataAccessLayer.DalVisaTypeDetails();
            return ObjDalVisaTypeDetails.GetDocList();
        }

        public int InsertVisaTypeDetail()
        {
            DataAccessLayer.DalVisaTypeDetails ObjDalVisaTypeDetails = null;
            DataTable dt = null;
            try
            {
                ObjDalVisaTypeDetails = new DataAccessLayer.DalVisaTypeDetails();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                //Code for adding columns in datatable.
                dt.Columns.Add("VisaTypeCode");
                dt.Columns.Add("SVisaTypeName");
                dt.Columns.Add("VisaTypeName");
                dt.Columns.Add("Status");
                dt.Columns.Add("CreatedBy");
                dt.Columns.Add("flagEmove");

                dr["VisaTypeCode"] = this.VisaTypeCode;
                dr["SVisaTypeName"] = this.SVisaTypeName;               
                dr["VisaTypeName"] = this.VisaTypeName;
                dr["Status"] = this.Status;
                dr["CreatedBy"] = this.CreatedBy;
                dr["flagEmove"] = this.flagEmove;

                dt.Rows.Add(dr);

                return ObjDalVisaTypeDetails.InsertVisaTypeDetail(dt);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dt = null;
                ObjDalVisaTypeDetails = null;
            }
        }

        public DataTable FetchVisaTypeDetails_VisaTypeCode()
        {
            DataAccessLayer.DalVisaTypeDetails ObjDalVisaTypeDetails = null;

            try
            {
                ObjDalVisaTypeDetails = new DataAccessLayer.DalVisaTypeDetails();
                return ObjDalVisaTypeDetails.FetchVisaTypeDetails_VisaTypeCode(this.VisaTypeCode);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ObjDalVisaTypeDetails = null;

            }
        }

        public int UpdateVisaTypeDetail()
        {
            DataAccessLayer.DalVisaTypeDetails ObjDalVisaTypeDetails = null;
            DataTable dt = null;
            try
            {
                ObjDalVisaTypeDetails = new DataAccessLayer.DalVisaTypeDetails();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                //Code for adding columns in datatable.
                dt.Columns.Add("VisaTypeCode");
                dt.Columns.Add("SVisaTypeName");
                dt.Columns.Add("VisaTypeName");
                dt.Columns.Add("Status");
                dt.Columns.Add("ModifiedBy");
                dt.Columns.Add("flagEmove");

                dr["VisaTypeCode"] = this.VisaTypeCode;
                dr["SVisaTypeName"] = this.SVisaTypeName;
                dr["VisaTypeName"] = this.VisaTypeName;                
                dr["Status"] = this.Status;
                dr["ModifiedBy"] = this.ModifiedBy;
                dr["flagEmove"] = this.flagEmove;

                dt.Rows.Add(dr);

                return ObjDalVisaTypeDetails.UpdateVisaTypeDetail(dt);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dt = null;
                ObjDalVisaTypeDetails = null;
            }
        }

        public int DeleteDataRow(string keyvalue)
        {
            DataAccessLayer.DalVisaTypeDetails ObjDalVisaTypeDetails = null;
            ObjDalVisaTypeDetails = new DataAccessLayer.DalVisaTypeDetails();
            return ObjDalVisaTypeDetails.DeleteDataRow(keyvalue);
        }

        public string DocCode { get; set; }

        public string FlagMmendatory { get; set; }

        public int InsertDocUpdated()
        {
            DataAccessLayer.DalVisaTypeDetails ObjDalVisaTypeDetails = null;
            DataTable dt = null;
            try
            {
                ObjDalVisaTypeDetails = new DataAccessLayer.DalVisaTypeDetails();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                //Code for adding columns in datatable.
                dt.Columns.Add("VisaTypeCode");
                dt.Columns.Add("DocCode");
                //dt.Columns.Add("SVisaTypeName");
                // dt.Columns.Add("VisaTypeName");
                // dt.Columns.Add("Status");
                dt.Columns.Add("FlagMmendatory");
                dt.Columns.Add("CreatedBy");
                // dt.Columns.Add("DocCode");

                dr["VisaTypeCode"] = this.VisaTypeCode;
                dr["DocCode"] = this.DocCode;
                // dr["VisaTypeName"] = this.VisaTypeName;
                //dr["Status"] = this.Status;
                dr["CreatedBy"] = this.CreatedBy;
                dr["FlagMmendatory"] = this.FlagMmendatory;
                // dr["DocCode"] = this.DocCode;
                dt.Rows.Add(dr);

                return ObjDalVisaTypeDetails.InsertDocUpdated(dt);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dt = null;
                ObjDalVisaTypeDetails = null;
            }
        }

        public int DeletePrevDoc(string VisaTypeCode)
        {
            DataAccessLayer.DalVisaTypeDetails ObjDalVisaTypeDetails = null;
            ObjDalVisaTypeDetails = new DataAccessLayer.DalVisaTypeDetails();
            return ObjDalVisaTypeDetails.DeletePrevDoc(VisaTypeCode);
        }
        public DataSet GetActivityList()
        {
            DataAccessLayer.DalVisaTypeDetails ObjDalVisaTypeDetails = null;
            ObjDalVisaTypeDetails = new DataAccessLayer.DalVisaTypeDetails();
            return ObjDalVisaTypeDetails.GetActivityList();
        }

        public int WorkCenterMasterId { get; set; }
        public int StepId { get; set; }

        public string DisplayActivityName { get; set; }

        public int ActivityMasterID { get; set; }

        public int InsertWorkFlow()
        {
            DataAccessLayer.DalVisaTypeDetails ObjDalVisaTypeDetails = null;
            DataTable dt = null;
            try
            {
                ObjDalVisaTypeDetails = new DataAccessLayer.DalVisaTypeDetails();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                //Code for adding columns in datatable.
                dt.Columns.Add("WorkCenterMasterId");
                dt.Columns.Add("StepId");
                dt.Columns.Add("DisplayActivityName");
                dt.Columns.Add("ActivityMasterID");
                dt.Columns.Add("VisaTypeCode");
                //dt.Columns.Add("CreatedBy");
                //dt.Columns.Add("flagEmove");

                dr["WorkCenterMasterId"] = this.WorkCenterMasterId;
                dr["StepId"] = this.StepId;
                dr["DisplayActivityName"] = this.DisplayActivityName;
                dr["ActivityMasterID"] = this.ActivityMasterID;
                dr["VisaTypeCode"] = this.VisaTypeCode;
                //dr["CreatedBy"] = this.CreatedBy;
                //dr["flagEmove"] = this.flagEmove;

                dt.Rows.Add(dr);

                return ObjDalVisaTypeDetails.InsertWorkFlow(dt);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dt = null;
                ObjDalVisaTypeDetails = null;
            }
        }

        public int DeleteWorkFlowForUpdation(string p)
        {
            DataAccessLayer.DalVisaTypeDetails ObjDalVisaTypeDetails = null;
            ObjDalVisaTypeDetails = new DataAccessLayer.DalVisaTypeDetails();
            return ObjDalVisaTypeDetails.DeleteWorkFlowForUpdation(p);
        }
    }
}
