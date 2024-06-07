using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BusinessEntityLayer
{
    public class BalApplicantStatus
    {
        #region Private Variables

        private string _TransactionId;
        private string _ApplicantName;
        private string _ApplicantEmail;
        private string _Status;
        private string _Remark;
        private DateTime _Date;


        #endregion
        #region Private Variables
        public string TransactionId
        {
            get
            {
                return _TransactionId;
            }
            set
            {
                _TransactionId = value;
            }
        }

        public string ApplicantName
        {
            get
            {
                return _ApplicantName;
            }
            set
            {
                _ApplicantName = value;
            }
        }

        public string ApplicantEmail
        {
            get
            {
                return _ApplicantEmail;
            }
            set
            {
                _ApplicantEmail = value;
            }
        }

        public string Status
        {
            get
            {
                return _Status;
            }
            set
            {
                _Status = value;
            }
        }

        public string Remark
        {
            get
            {
                return _Remark;
            }
            set
            {
                _Remark = value;
            }
        }


        public DateTime Date
        {
            get
            {
                return _Date;
            }
            set
            {
                _Date = value;
            }
        }



        #endregion


        public DataTable GetApplicantStatusList(string L1id)
        {
            DataAccessLayer.DalApplicantStatus ObjDalApplicantStatusInfo = null;
            DataTable dt = null;
            dt = new DataTable();

            try
            {
                ObjDalApplicantStatusInfo = new DataAccessLayer.DalApplicantStatus();
                return dt = ObjDalApplicantStatusInfo.GetApplicantStatusList(L1id);

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                ObjDalApplicantStatusInfo = null;
            }
        }

        public DataTable GetApplicantStatusById(string ApplicationId)
        {
            DataAccessLayer.DalApplicantStatus ObjDalApplicantStatusById = null;
            DataTable dt = new DataTable();

            try
            {
                ObjDalApplicantStatusById = new DataAccessLayer.DalApplicantStatus();
                return dt = ObjDalApplicantStatusById.GetApplicantStatusById(ApplicationId);
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                ObjDalApplicantStatusById = null;
            }
        }

        public DataTable GetApplicantStatusListPreview(string PassportNo, string Nationality, string AppID)
        {
            DataAccessLayer.DalApplicantStatus ObjDalApplicantStatusInfoPreview = null;
            DataTable dt = null;
            dt = new DataTable();

            try
            {
                ObjDalApplicantStatusInfoPreview = new DataAccessLayer.DalApplicantStatus();
                return dt = ObjDalApplicantStatusInfoPreview.GetApplicantStatusListPreview(PassportNo, Nationality, AppID);
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                ObjDalApplicantStatusInfoPreview = null;
            }
        }

        public int DeleteDataRow(int keyvalue)
        {
            DataAccessLayer.DalApplicantStatus ObjDalApplicantStatus = null;
            ObjDalApplicantStatus = new DataAccessLayer.DalApplicantStatus();
            return ObjDalApplicantStatus.DeleteDataRow(keyvalue);
        }
        //-----------------------------By chitresh--------------------------------
        public DataTable GetApplicantStatusList1(string L1id)
        {
            DataAccessLayer.DalApplicantStatus ObjDalApplicantStatusInfo = null;
            DataTable dt = null;
            dt = new DataTable();

            try
            {
                ObjDalApplicantStatusInfo = new DataAccessLayer.DalApplicantStatus();
                return dt = ObjDalApplicantStatusInfo.GetApplicantStatusList1(L1id);

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                ObjDalApplicantStatusInfo = null;
            }
        }
        //-----------------------------end ----------------------------
        public DataTable GetApplicantStatusListApprovedVisa(string L1id)
        {
            DataAccessLayer.DalApplicantStatus ObjDalApplicantStatusInfo = null;
            DataTable dt = null;
            dt = new DataTable();

            try
            {
                ObjDalApplicantStatusInfo = new DataAccessLayer.DalApplicantStatus();
                return dt = ObjDalApplicantStatusInfo.GetApplicantStatusListApprovedVisa(L1id);

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                ObjDalApplicantStatusInfo = null;
            }
        }
    }
}
