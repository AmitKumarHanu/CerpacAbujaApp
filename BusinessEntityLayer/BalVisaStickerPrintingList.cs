using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BusinessEntityLayer
{
   public class BalVisaStickerPrintingList
    {
        public DataTable GetApplicantList()
        {
            DataAccessLayer.DalVisaStickerPrintingList ObjDalVisaStickerPrintingList = null;
            DataTable dt = null;
            dt = new DataTable();

            try
            {
                ObjDalVisaStickerPrintingList = new DataAccessLayer.DalVisaStickerPrintingList();
                return dt = ObjDalVisaStickerPrintingList.GetVisaStickerListDal();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                ObjDalVisaStickerPrintingList = null;
            }
        }


        public int UpdateStickerWastage(string stickerno, string WasteReason, string uid)
        {
            int i = 0;
            DataAccessLayer.DalVisaStickerPrintingList ObjDalVisaStickerPrintingList = null;
            //ObjDalVisaStickerPrintingList = new DataAccessLayer.DalVisaStickerPrintingList();

            try
            {
                ObjDalVisaStickerPrintingList = new DataAccessLayer.DalVisaStickerPrintingList();
                return i = ObjDalVisaStickerPrintingList.UpdateVisaStickerWastageDal(stickerno, WasteReason, uid);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ObjDalVisaStickerPrintingList = null;
            }

        }

        public int UpadteStickerUsages(string stickerno, string uid, string AppId, string Remark, DateTime ValidTillDate)
        {
            int i = 0;
            DataAccessLayer.DalVisaStickerPrintingList ObjDalVisaStickerPrintingList = null;
            
            try
            {
                ObjDalVisaStickerPrintingList = new DataAccessLayer.DalVisaStickerPrintingList();
                return i = ObjDalVisaStickerPrintingList.UpadteStickerUsagesDal(stickerno, uid, AppId, Remark, ValidTillDate);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ObjDalVisaStickerPrintingList = null;
            }

        }

        public int UpadteStickerUsagesByWestage(string uid, string AppId)
        {
            int i = 0;
            DataAccessLayer.DalVisaStickerPrintingList ObjDalVisaStickerPrintingList = null;
            
            try
            {
                ObjDalVisaStickerPrintingList = new DataAccessLayer.DalVisaStickerPrintingList();
                return i = ObjDalVisaStickerPrintingList.UpadteStickerUsagesByWestageDal(uid, AppId);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ObjDalVisaStickerPrintingList = null;
            }

        }

        public int UpadteStickerUsagesByID(string stickerno, string uid, string AppId, string Remark, int StickerStatusID)
        {
            int i = 0;
            DataAccessLayer.DalVisaStickerPrintingList ObjDalVisaStickerPrintingList = null;

            try
            {
                ObjDalVisaStickerPrintingList = new DataAccessLayer.DalVisaStickerPrintingList();
                return i = ObjDalVisaStickerPrintingList.UpadteStickerUsagesByIDDal(stickerno, uid, AppId, Remark, StickerStatusID);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ObjDalVisaStickerPrintingList = null;
            }

        }

        public DataTable GetApplicantStatusById(string ApplicationId, string userid)
        {
            DataAccessLayer.DalVisaStickerPrintingList ObjDalVisaStickerPrintingList = null;
            DataTable dt = new DataTable();

            try
            {
                ObjDalVisaStickerPrintingList = new DataAccessLayer.DalVisaStickerPrintingList();
                return dt = ObjDalVisaStickerPrintingList.GetApplicantStatusById(ApplicationId, userid);
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                ObjDalVisaStickerPrintingList = null;
            }
        }


        public DataTable GetMRZ(string AppId)
        {
            DataAccessLayer.DalVisaStickerPrintingList ObjDalVisaStickerPrintingList = null;
            DataTable dt = null;
            dt = new DataTable();

            try
            {
                ObjDalVisaStickerPrintingList = new DataAccessLayer.DalVisaStickerPrintingList();
                return dt = ObjDalVisaStickerPrintingList.GetMRZDal(AppId);
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                ObjDalVisaStickerPrintingList = null;
            }
        }

        public int InsertMRZ(string MRZ1, string MRZ2, string AppId, string strValidTillDate)
        {
            int i = 0;
            DataAccessLayer.DalVisaStickerPrintingList ObjDalVisaStickerPrintingList = null;

            //try
            //{
                ObjDalVisaStickerPrintingList = new DataAccessLayer.DalVisaStickerPrintingList();
                return i = ObjDalVisaStickerPrintingList.InsertMRZDal(MRZ1, MRZ2, AppId, strValidTillDate);
            //}
            //catch (Exception ex)
            //{
            //    throw (ex);
            //}
            //finally
            //{
            //    ObjDalVisaStickerPrintingList = null;
            //}

        }

        public  DataTable PrintStickerBal(string ApplicationId)
        {
            
            DataAccessLayer.DalVisaStickerPrintingList ObjDalVisaStickerPrintingList = null;
            DataTable dt = null;
            dt = new DataTable();
            try
            {
                ObjDalVisaStickerPrintingList = new DataAccessLayer.DalVisaStickerPrintingList();
               return dt = ObjDalVisaStickerPrintingList.PrintStickerDal(ApplicationId);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ObjDalVisaStickerPrintingList = null;
            }

        }

    }
}
