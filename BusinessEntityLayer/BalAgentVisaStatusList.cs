using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BusinessEntityLayer
{
   public  class BalAgentVisaStatusList
    {
        #region Private Variables

        private string _ApplicationId;
        private string _PassportNumber;
        private string _ApplicantName;
        private string _FatherName;
        private string _EmailID;
        private string _Approver1Status;
        private string _Approver2Status;
        private string _Approver3Status;
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

        public string FatherName
        {

            get
            {
                return _FatherName;
            }
            set
            {
                _FatherName = value;
            }

        }

        public string EmailID
        {
            get
            {
                return _EmailID;
            }
            set
            {
                _EmailID = value;
            }
        }

        public string Approver1Status
        {
            get
            {
                return _Approver1Status;
            }
            set
            {
                _Approver1Status = value;
            }
        }

        public string Approver2Status
        {
            get
            {
                return _Approver2Status;
            }
            set
            {
                _Approver2Status = value;
            }
        }

        public string Approver3Status
        {
            get
            {
                return _Approver3Status;
            }
            set
            {
                _Approver3Status = value;
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

        public DataTable GetApplicantVisaStatus(string AppliedByUserId)
        {
            DataAccessLayer.DalAgentVisaStatusList ObjDalAgentVisaStatusList = null;
            DataTable dt = null;
            dt = new DataTable();

            try
            {
                ObjDalAgentVisaStatusList = new DataAccessLayer.DalAgentVisaStatusList();
                return dt = ObjDalAgentVisaStatusList.GetAgentVisaStatusList(AppliedByUserId);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                ObjDalAgentVisaStatusList = null;
            }
        }

        public DataTable GetApplicantStatusById(string ApplicationId, string userid)
        {
            DataAccessLayer.DalAgentVisaStatusList ObjDalAgentVisaStatusList = null;
            DataTable dt = new DataTable();

            try
            {
                ObjDalAgentVisaStatusList = new DataAccessLayer.DalAgentVisaStatusList();
                return dt = ObjDalAgentVisaStatusList.GetApplicantStatusById(ApplicationId, userid);
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                ObjDalAgentVisaStatusList = null;
            }
        }
    }
}
