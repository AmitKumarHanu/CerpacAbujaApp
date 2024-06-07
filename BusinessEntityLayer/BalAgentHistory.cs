using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BusinessEntityLayer
{
   public class BalAgentHistory
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
            DataAccessLayer.DalAgentHistory ObjDalAgentHistory = null;
            DataTable dt = null;
            dt = new DataTable();

            try
            {
                ObjDalAgentHistory = new DataAccessLayer.DalAgentHistory();
                return dt = ObjDalAgentHistory.GetApplicantHistory(USERID);
                    
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                ObjDalAgentHistory = null;
            }
        }

        public DataTable GetApplicantStatusById(string ApplicationId, string userid)
        {
            DataAccessLayer.DalAgentHistory ObjDalAgentHistory = null;
            DataTable dt = new DataTable();

            try
            {
                ObjDalAgentHistory = new DataAccessLayer.DalAgentHistory();
                return dt = ObjDalAgentHistory.GetApplicantStatusById(ApplicationId, userid);
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                ObjDalAgentHistory = null;
            }
        }
    
    }
}
