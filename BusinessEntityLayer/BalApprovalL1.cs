using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BusinessEntityLayer
{
    public class BalApprovalL1
    {
        #region Private Variables

        private string _ApplicationId;
        private string _PassportNumber;
        private string _Name;
        private string _ApplicantCountryCode;
        private string _IssuingAuthority;
        private string _VisaTypeName;
        private string _ModifiedBy;
        private string _id;
        private string _Filename;
        private string _userid;
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
        public string id
        {

            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        public string userid
        {
            get { return _userid; }
            set { _id = value; }
        }
        public string Filename
        {
            get { return _Filename; }
            set { _Filename = value; }
        }


        #endregion

        public DataTable GetVisaPandingList(string L1id)
        {
            DataAccessLayer.DalApprovalL1 ObjDalApprovalL1 = null;
            DataTable dt = null;
            dt = new DataTable();

            try
            {
                ObjDalApprovalL1 = new DataAccessLayer.DalApprovalL1();
                return dt = ObjDalApprovalL1.GetDalVisaPandingList(L1id);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                ObjDalApprovalL1 = null;
            }
        }

        // ===============================BY CHITRESH =========================
        public DataTable GetVisaApprovedList(string L1id)
        {
            DataAccessLayer.DalApprovalL1 ObjDalApprovalL1 = null;
            DataTable dt = null;
            dt = new DataTable();

            try
            {
                ObjDalApprovalL1 = new DataAccessLayer.DalApprovalL1();
                return dt = ObjDalApprovalL1.GetDalVisaApprovedList(L1id);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                ObjDalApprovalL1 = null;
            }
        }

        public int ForwardToCC()
        {
            DataAccessLayer.DalApprovalL1 ObjDalApprovalL1 = null;
            ObjDalApprovalL1 = new DataAccessLayer.DalApprovalL1();
            DataTable dt = new DataTable();
            dt = new DataTable();
            try
            {


                DataRow dr = dt.NewRow();

                //Code for adding columns in datatable.
                dt.Columns.Add("ApplicationId");
                // dt.Columns.Add("GenerateFileCode");
                //dt.Columns.Add("APPROVER1STATUS");
                // dt.Columns.Add("APPROVER1COMMENTS");
                // dt.Columns.Add("Rejection_Code");
                dt.Columns.Add("id");
                // dt.Columns.Add("ModifiedBy");

                dr["ApplicationId"] = this.ApplicationId;
                // dr["GenerateFileCode"] = this.GenerateFileCode;
                // dr["APPROVER1STATUS"] = this.APPROVER1STATUS;
                //  dr["APPROVER1COMMENTS"] = this.APPROVER1COMMENTS;
                // dr["Rejection_Code"] = this.Rejection_Code;
                dr["id"] = this.id;
                // dr["ModifiedBy"] = this.ModifiedBy;

                dt.Rows.Add(dr);

                return ObjDalApprovalL1.ForwardToCC(dt);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                dt = null;
                ObjDalApprovalL1 = null;
            }
        }

        public DataTable GetApprovalUploadDetails(string ApplicationId, string Userid)
        {
            DataAccessLayer.DalApprovalL1 ObjDalApprovalL1 = null;
            DataTable dt = null;
            dt = new DataTable();

            try
            {
                ObjDalApprovalL1 = new DataAccessLayer.DalApprovalL1();
                return dt = ObjDalApprovalL1.GetDalVisaApprovedList(ApplicationId, Userid);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                ObjDalApprovalL1 = null;
            }
        }

        public int InsertApproval()
        {
            DataAccessLayer.DalApprovalL1 ObjDalApprovalL1 = null;
            ObjDalApprovalL1 = new DataAccessLayer.DalApprovalL1();
            DataTable dt = new DataTable();
            dt = new DataTable();
            try
            {


                DataRow dr = dt.NewRow();

                //Code for adding columns in datatable.
                dt.Columns.Add("ApplicationId");
                dt.Columns.Add("Filename");
                //dt.Columns.Add("APPROVER1STATUS");
                // dt.Columns.Add("APPROVER1COMMENTS");
                // dt.Columns.Add("Rejection_Code");
                dt.Columns.Add("id");
                // dt.Columns.Add("ModifiedBy");

                dr["ApplicationId"] = this.ApplicationId;
                dr["Filename"] = this.Filename;
                // dr["APPROVER1STATUS"] = this.APPROVER1STATUS;
                //  dr["APPROVER1COMMENTS"] = this.APPROVER1COMMENTS;
                // dr["Rejection_Code"] = this.Rejection_Code;
                dr["id"] = this.id;
                // dr["ModifiedBy"] = this.ModifiedBy;

                dt.Rows.Add(dr);

                return ObjDalApprovalL1.InsertApproval(dt);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                dt = null;
                ObjDalApprovalL1 = null;
            }
        }

        public DataTable GetIssueVisaList(string ApplicationId, string User_id)
        {
            DataAccessLayer.DalApprovalL1 ObjDalApprovalL1 = null;
            DataTable dt = null;
            dt = new DataTable();

            try
            {
                ObjDalApprovalL1 = new DataAccessLayer.DalApprovalL1();
                return dt = ObjDalApprovalL1.GetDalIssueVisaList(ApplicationId, User_id);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                ObjDalApprovalL1 = null;
            }
        }

        public DataTable GetIssueVisaListbyApplicationId(string ApplicationId, string User_id)
        {
            DataAccessLayer.DalApprovalL1 ObjDalApprovalL1 = null;
            DataTable dt = null;
            dt = new DataTable();

            try
            {
                ObjDalApprovalL1 = new DataAccessLayer.DalApprovalL1();
                return dt = ObjDalApprovalL1.GetDalIssueVisaListbyApplicationId(ApplicationId, User_id);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                ObjDalApprovalL1 = null;
            }
        }
        //=================================END=========================== 




    }

}