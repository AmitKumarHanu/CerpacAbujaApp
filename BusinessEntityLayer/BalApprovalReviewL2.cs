using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BusinessEntityLayer
{
   public  class BalApprovalReviewL2
    {
        public int APPLICATIONID { get; set; }
        public string APPROVER2STATUS { get; set; }
        public string APPROVER2COMMENTS { get; set; }
        public string Rejection_Code { get; set; }
        public string Status { get; set; }
        public string L2Id { get; set; }
        public int ModifiedBy { get; set; }


        public int UpdateApplicationStatus()
        {
            DataAccessLayer.DalApprovalReviewL2 ObjDalApprovalReviewL2 = null;
            DataTable dt = null;
            try
            {
                ObjDalApprovalReviewL2 = new DataAccessLayer.DalApprovalReviewL2();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                //Code for adding columns in datatable.
                dt.Columns.Add("APPLICATIONID");
                dt.Columns.Add("APPROVER2STATUS");
                dt.Columns.Add("APPROVER2COMMENTS");
                dt.Columns.Add("Rejection_Code");
                dt.Columns.Add("L2Id");
                dt.Columns.Add("ModifiedBy");

                dr["APPLICATIONID"] = this.APPLICATIONID;
                dr["APPROVER2STATUS"] = this.APPROVER2STATUS;
                dr["APPROVER2COMMENTS"] = this.APPROVER2COMMENTS;
                dr["Rejection_Code"] = this.Rejection_Code;
                dr["L2Id"] = this.L2Id;
                dr["ModifiedBy"] = this.ModifiedBy;

                dt.Rows.Add(dr);

                return ObjDalApprovalReviewL2.UpdateApplicationStatus(dt);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dt = null;
                ObjDalApprovalReviewL2 = null;
            }
        }

        public DataTable GetApprovedL1Detail(string ApplicantId)
        {
            DataAccessLayer.DalApprovalReviewL2 objDalApprovalReviewL2 = null;
            DataTable dt = null;
            dt = new DataTable();

            try
            {
                objDalApprovalReviewL2 = new DataAccessLayer.DalApprovalReviewL2();
                return dt = objDalApprovalReviewL2.GetApprovedL1Detail(ApplicantId);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                objDalApprovalReviewL2 = null;
            }
        }

        public DataTable GetDurationNDurationType(string AppId)
        {
            DataAccessLayer.DalApprovalReviewL2 objDalApprovalReviewL2 = null;
            DataTable dt = null;
            dt = new DataTable();

            try
            {
                objDalApprovalReviewL2 = new DataAccessLayer.DalApprovalReviewL2();
                return dt = objDalApprovalReviewL2.GetDurationNDurationTypeDal(AppId);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                objDalApprovalReviewL2 = null;
            }
        }


        public DateTime GetArrivalDate(string AppId)
        {
            DataAccessLayer.DalApprovalReviewL2 objGetArrivalDate = null;
            DateTime dt ;
            //dt = new DataTable();

            try
            {
             
                objGetArrivalDate = new DataAccessLayer.DalApprovalReviewL2();
                return dt =Convert.ToDateTime( objGetArrivalDate.GetArrivalDate(AppId).Rows[0][0]);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                objGetArrivalDate = null;
            }
        }

        public DataTable InsertValidTill(string AppId, DateTime ValidTillDate)
        {
            DataAccessLayer.DalApprovalReviewL2 objDalApprovalReviewL2 = null;
            DataTable dt = null;
            dt = new DataTable();

            try
            {
                objDalApprovalReviewL2 = new DataAccessLayer.DalApprovalReviewL2();
                return dt = objDalApprovalReviewL2.InsertValidTillDal(AppId, ValidTillDate);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                objDalApprovalReviewL2 = null;
            }
        }
    }
}
