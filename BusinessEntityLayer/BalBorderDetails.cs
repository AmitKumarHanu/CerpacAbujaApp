using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BusinessEntityLayer
{
    public class BalBorderDetails
    {
        public int BorderId { get; set; }
        public string BorderName { get; set; }
        public string Status { get; set; }
        public string ModifiedBy { get; set; }



        public DataTable GetBorderList()
        {
            DataAccessLayer.DalBorderDetails ObjDalBorderInfo = null;
            DataTable dt = null;

            try
            {
                ObjDalBorderInfo = new DataAccessLayer.DalBorderDetails();
                return dt = ObjDalBorderInfo.GetBorderList();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                ObjDalBorderInfo = null;
            }
        }
        public int UpdateBorderDetail()
        {
            DataAccessLayer.DalBorderDetails ObjDalBorderDetails = null;
            DataTable dt = null;
            try
            {
                ObjDalBorderDetails = new DataAccessLayer.DalBorderDetails();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                //Code for adding columns in datatable.
                dt.Columns.Add("BorderId");
                dt.Columns.Add("BorderName");
                dt.Columns.Add("Status");
                dt.Columns.Add("ModifiedBy");

                dr["BorderId"] = this.BorderId;
                dr["BorderName"] = this.BorderName;
                dr["Status"] = this.Status;
                dr["ModifiedBy"] = this.ModifiedBy;

                dt.Rows.Add(dr);

                return ObjDalBorderDetails.UpdateBorderDetail(dt);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dt = null;
                ObjDalBorderDetails = null;
            }
        }

        public int DeleteDataRow(int keyvalue)
        {
            DataAccessLayer.DalBorderDetails ObjDalBorderDetails = null;
            ObjDalBorderDetails = new DataAccessLayer.DalBorderDetails();
            return ObjDalBorderDetails.DeleteDataRow(keyvalue);
        }
    }
 
}
