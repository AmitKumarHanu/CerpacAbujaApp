using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BusinessEntityLayer
{
  public  class BalL2Status
    {
        #region Private Variables

        private string _ApplicantId;
        private string _ApplicantName;
        private string _ApplicantEmail;
        private string _Status;
        private string _Remark;
        private DateTime _Date;

        #endregion

        #region Private Variables
        public string ApplicantId
        {
            get
            {
                return _ApplicantId;
            }
            set
            {
                _ApplicantId = value;
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


        public DataTable GetL2StatusList(string L1id)
        {
            DataAccessLayer.DalL2status ObjDalL2status = null;
            DataTable dt = null;
            dt = new DataTable();

            try
            {
                ObjDalL2status = new DataAccessLayer.DalL2status();
                return dt = ObjDalL2status.GetL2StatusList(L1id);

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                ObjDalL2status = null;
            }
        }

        public DataTable GetApplicantStatusById(string ApplicationId)
        {
            DataAccessLayer.DalL2status ObjDalL2status = null;
            DataTable dt = new DataTable();

            try
            {
                ObjDalL2status = new DataAccessLayer.DalL2status();
                return dt = ObjDalL2status.GetApplicantStatusById(ApplicationId);
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                ObjDalL2status = null;
            }
        }

       
    }
}
