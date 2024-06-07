using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BusinessEntityLayer
{
    public class BalStickerDetails
    {
        public int StickerSerialNumber { get; set; }
        public int StickerNumberFrom { get; set; }
        public int StickerNumberTo { get; set; }
        public string Status { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public string UserId { get; set; }
        public int[] Issued_Removed_StickerSerialNo { get; set; }
        public int[] Issued_New_StickerSerialNo { get; set; }
        public int[] Issued_Received_StickerSerialNo { get; set; }
        public int Sticker_UserId { get; set; }



        public DataSet GetStickerInfo()
        {
            DataAccessLayer.DalStickerDetails objDalStickerDetails = null;
            try
            {
                objDalStickerDetails = new DataAccessLayer.DalStickerDetails();
                return objDalStickerDetails.GetStickerInfo(this.StickerSerialNumber);

            }
            catch (Exception e)
            {
                throw (e);
            }
            finally
            {
                objDalStickerDetails = null;
            }

        }

        DataAccessLayer.DalStickerDetails ObjDalSearch = null;
        DataSet dts = null;
        public DataSet MaxSerialNo()
        {
            ObjDalSearch = new DataAccessLayer.DalStickerDetails();
            dts = new DataSet();
            dts = ObjDalSearch.MaxSerialNo();
            return dts;

        }



        public DataTable GetStickerList()
        {
            DataAccessLayer.DalStickerDetails objDalStickerDetails = null;
            DataTable dt = null;
            try
            {
                objDalStickerDetails = new DataAccessLayer.DalStickerDetails();
                return dt = objDalStickerDetails.GetStickerList(this.UserId);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                objDalStickerDetails = null;
                dt = null;
            }

        }

        public DataTable GetStickerReceiveList()
        {
            DataAccessLayer.DalStickerDetails objDalStickerReceiveDetails = null;
            DataTable dt = null;
            try
            {
                objDalStickerReceiveDetails = new DataAccessLayer.DalStickerDetails();
                return dt = objDalStickerReceiveDetails.GetStickerReceiveList(this.UserId);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                objDalStickerReceiveDetails = null;
                dt = null;
            }

        }
        public int InsertStickerMaster()
        {
            DataAccessLayer.DalStickerDetails ObjDalStickerDetails = null;
            DataTable dt = null;
            try
            {
                ObjDalStickerDetails = new DataAccessLayer.DalStickerDetails();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                //Code for adding columns in datatable.
                dt.Columns.Add("StickerNumberFrom");
                dt.Columns.Add("StickerNumberTo");
                dt.Columns.Add("Status");
                dt.Columns.Add("CreatedBy");

                dr["StickerNumberFrom"] = this.StickerNumberFrom;
                dr["StickerNumberTo"] = this.StickerNumberTo;
                dr["Status"] = this.Status;
                dr["CreatedBy"] = this.CreatedBy;

                dt.Rows.Add(dr);

                return ObjDalStickerDetails.InsertStickerDetail(dt);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dt = null;
                ObjDalStickerDetails = null;
            }
        }
        public int UpdateStickerDetail()
        {
            DataAccessLayer.DalStickerDetails ObjDalStickerDetails = null;
            DataTable dt = null;
            try
            {
                ObjDalStickerDetails = new DataAccessLayer.DalStickerDetails();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                //Code for adding columns in datatable.
                dt.Columns.Add("StickerSerialNumber");
                dt.Columns.Add("Status");
                dt.Columns.Add("ModifiedBy");

                dr["StickerSerialNumber"] = this.StickerSerialNumber;
                dr["Status"] = this.Status;
                dr["ModifiedBy"] = this.ModifiedBy;

                dt.Rows.Add(dr);

                return ObjDalStickerDetails.UpdateStickerDetail(dt);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dt = null;
                ObjDalStickerDetails = null;
            }

        }

        public int DeleteDataRow(int keyvalue)
        {
            DataAccessLayer.DalStickerDetails ObjDalStickerDetails = null;
            ObjDalStickerDetails = new DataAccessLayer.DalStickerDetails();
            return ObjDalStickerDetails.DeleteDataRow(keyvalue);
        }




        public int StickerReceiveDetails()
        {
            DataAccessLayer.DalStickerDetails ObjDalStickerDetails = null;
            try
            {
                ObjDalStickerDetails = new DataAccessLayer.DalStickerDetails();

                return ObjDalStickerDetails.StickerReceivedDetails(this.Issued_Removed_StickerSerialNo, this.Issued_New_StickerSerialNo, this.Sticker_UserId, this.CreatedBy, this.ModifiedBy);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }



        public int StartStickerNum { get; set; }

        public int EndStickerNum { get; set; }

        public int InsertStickerIssueDetails()
        {
            DataAccessLayer.DalStickerDetails ObjDalStickerDetails = null;
            try
            {
                ObjDalStickerDetails = new DataAccessLayer.DalStickerDetails();

                return ObjDalStickerDetails.StickerIssueDetails(this.StartStickerNum, this.EndStickerNum, this.Sticker_UserId, this.CreatedBy, this.ModifiedBy);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
