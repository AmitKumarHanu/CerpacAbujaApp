using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BusinessEntityLayer
{
   public class BalApplicantHistory
    {
        #region Private Variables

        private string _ApplicationId;
        private string _PassportNumber;
        private string _APPLICANT_NAME;
        private string _VisaTypeName;
        private string _VisaValidFor;       
        private string _VisaValidFrom;
        private string _VisaValidThru;
        private string _Rate;
        private string _ModifiedBy;

        #endregion

        #region Public Variables

        public string ApplicationId
        {
            get
            {
                return _ApplicationId;
            }
            set
            {
                _ApplicationId = value;
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

        public string APPLICANT_NAME
        {

            get
            {
                return _APPLICANT_NAME;
            }
            set
            {
                _APPLICANT_NAME = value;
            }

        }

        public string VisaTypeName
        {

            get
            {
                return _VisaTypeName;
            }
            set
            {
                _VisaTypeName = value;
            }

        }

        public string VisaValidFor
        {
            get
            {
                return _VisaValidFor;
            }
            set
            {
                _VisaValidFor = value;
            }
        }             

        public string VisaValidFrom
        {

            get
            {
                return _VisaValidFrom;
            }
            set
            {
                _VisaValidFrom = value;
            }

        }

        public string VisaValidThru
        {

            get
            {
                return _VisaValidThru;
            }
            set
            {
                _VisaValidThru = value;
            }

        }

        public string Rate
        {

            get
            {
                return _Rate;
            }
            set
            {
                _Rate = value;
            }

        }



        public string ModifiedBy
        {

            get
            {
                return _ModifiedBy;
            }
            set
            {
                _ModifiedBy = value;
            }

        }

        #endregion

        public DataTable GetApplicantHistory(string USERID)
        {
            DataAccessLayer.DalApplicantHistory ObjDalApplicantHistory = null;
            DataTable dt = null;
            dt = new DataTable();

            try
            {
                ObjDalApplicantHistory = new DataAccessLayer.DalApplicantHistory();
                return dt = ObjDalApplicantHistory.GetApplicantHistory(USERID);
                    
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                ObjDalApplicantHistory = null;
            }
        }

        public DataTable GetApprovalHistory()
        {
            DataAccessLayer.DalApplicantHistory ObjDalApplicantHistory = null;
            DataTable dt = null;
            dt = new DataTable();

            try
            {
                ObjDalApplicantHistory = new DataAccessLayer.DalApplicantHistory();
                return dt = ObjDalApplicantHistory.GetApprovalHistory(this.ApplicationId);

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                ObjDalApplicantHistory = null;
            }
        }
    }
}
