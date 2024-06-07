using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BusinessEntityLayer
{
   public class BalApplicationReview1
    {
        #region Private Variables

        private string _ApplicationId;
        private string _PassportNumber;
        private string _Name;
        private string _ApplicantCountryCode;
        private string _IssuingAuthority;
        private string _VisaTypeName;
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

        public string Name
        {

            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }

        }

        public string ApplicantCountryCode
        {

            get
            {
                return _ApplicantCountryCode;
            }
            set
            {
                _ApplicantCountryCode = value;
            }

        }

        public string IssuingAuthority
        {
            get
            {
                return _IssuingAuthority;
            }
            set
            {
                _IssuingAuthority = value;
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

        public DataTable GetApplicationReview1(string APPLICATIONID)
        {
            DataAccessLayer.DalApplicationReview1 ObjDalApplicationReview1 = null;
            DataTable dt = null;
            dt = new DataTable();

            try
            {
                ObjDalApplicationReview1 = new DataAccessLayer.DalApplicationReview1();
                return dt = ObjDalApplicationReview1.GetApplicationReview1(APPLICATIONID);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                ObjDalApplicationReview1 = null;
            }
        }

    }
}
