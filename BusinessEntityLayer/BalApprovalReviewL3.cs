using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BusinessEntityLayer
{
   public class BalApprovalReviewL3
    {
        public int APPLICATIONID { get; set; }
        public string APPROVER3STATUS { get; set; }
        public string APPROVER3COMMENTS { get; set; }
        public string Rejection_Code { get; set; }
        //public string Status { get; set; }
        public string L3Id { get; set; }
        public int ModifiedBy { get; set; }


        public int UpdateApplicationStatus()
        {
            DataAccessLayer.DalApprovalReviewL3 ObjDalApprovalReviewL3 = null;
            DataTable dt = null;
            try
            {
                ObjDalApprovalReviewL3 = new DataAccessLayer.DalApprovalReviewL3();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                //Code for adding columns in datatable.
                dt.Columns.Add("APPLICATIONID");
                dt.Columns.Add("APPROVER3STATUS");
                dt.Columns.Add("APPROVER3COMMENTS");
                dt.Columns.Add("Rejection_Code");
                dt.Columns.Add("L3Id");
                dt.Columns.Add("ModifiedBy");

                dr["APPLICATIONID"] = this.APPLICATIONID;
                dr["APPROVER3STATUS"] = this.APPROVER3STATUS;
                dr["APPROVER3COMMENTS"] = this.APPROVER3COMMENTS;
                dr["Rejection_Code"] = this.Rejection_Code;
                dr["L3Id"] = this.L3Id;
                dr["ModifiedBy"] = this.ModifiedBy;

                dt.Rows.Add(dr);

                return ObjDalApprovalReviewL3.UpdateApplicationStatus(dt);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dt = null;
                ObjDalApprovalReviewL3 = null;
            }
        }

       public DataTable GetApprovedL1N2DetailBal(string ApplicantId)
       {
           DataAccessLayer.DalApprovalReviewL3 objDalApprovalReviewL3 = null;
           DataTable dt = null;
           dt = new DataTable();

           try
           {
               objDalApprovalReviewL3 = new DataAccessLayer.DalApprovalReviewL3();
               return dt = objDalApprovalReviewL3.GetApprovedL1N2DetailDal(ApplicantId);


           }
           catch (Exception ex)
           {
               throw (ex);
           }

           finally
           {
               objDalApprovalReviewL3 = null;
           }
       }

       public DataTable GetDurationNDurationType(string AppId)
       {
           DataAccessLayer.DalApprovalReviewL3 objDalApprovalReviewL3 = null;
           DataTable dt = null;
           dt = new DataTable();

           try
           {
               objDalApprovalReviewL3 = new DataAccessLayer.DalApprovalReviewL3();
               return dt = objDalApprovalReviewL3.GetDurationNDurationTypeDal(AppId);


           }
           catch (Exception ex)
           {
               throw (ex);
           }

           finally
           {
               objDalApprovalReviewL3 = null;
           }
       }

       public DataTable InsertValidTill(string AppId, DateTime ValidTillDate, string VisaValidFor)
       {
           DataAccessLayer.DalApprovalReviewL3 objDalApprovalReviewL3 = null;
           DataTable dt = null;
           dt = new DataTable();

           try
           {
               objDalApprovalReviewL3 = new DataAccessLayer.DalApprovalReviewL3();
               return dt = objDalApprovalReviewL3.InsertValidTillDal(AppId,ValidTillDate,VisaValidFor);


           }
           catch (Exception ex)
           {
               throw (ex);
           }

           finally
           {
               objDalApprovalReviewL3 = null;
           }
       }
    }
}
