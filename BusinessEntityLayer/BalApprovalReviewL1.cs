using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BusinessEntityLayer
{
   public class BalApprovalReviewL1
    {
       public int APPLICATIONID { get; set; }
       public string APPROVER1STATUS { get; set; }
       public string APPROVER1COMMENTS { get; set; }
       public string Rejection_Code { get; set ;}
        public string Status { get; set; }
        public string L1Id { get; set; }
        public int ModifiedBy { get; set; }
       
      
        public int UpdateApplicationStatus()
        {
            DataAccessLayer.DalApprovalReviewL1 ObjDalApprovalReviewL1 = null;
            DataTable dt = null;
            try
            {
                ObjDalApprovalReviewL1 = new DataAccessLayer.DalApprovalReviewL1();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                //Code for adding columns in datatable.
                dt.Columns.Add("APPLICATIONID");
                dt.Columns.Add("APPROVER1STATUS");
                dt.Columns.Add("APPROVER1COMMENTS");
                dt.Columns.Add("Rejection_Code");
                dt.Columns.Add("L1Id"); 
                dt.Columns.Add("ModifiedBy");

                dr["APPLICATIONID"] = this.APPLICATIONID;
                dr["APPROVER1STATUS"] = this.APPROVER1STATUS;
                dr["APPROVER1COMMENTS"] = this.APPROVER1COMMENTS;
                dr["Rejection_Code"] = this.Rejection_Code;
                dr["L1Id"] = this.L1Id; 
                dr["ModifiedBy"] = this.ModifiedBy;

                dt.Rows.Add(dr);

                return ObjDalApprovalReviewL1.UpdateApplicationStatus(dt);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dt = null;
                ObjDalApprovalReviewL1 = null;
            }
        }

        public DataTable GetDurationNDurationType(string AppId)
        {
            DataAccessLayer.DalApprovalReviewL1 objDalApprovalReviewL1 = null;
            DataTable dt = null;
            dt = new DataTable();

            try
            {
                objDalApprovalReviewL1 = new DataAccessLayer.DalApprovalReviewL1();
                return dt = objDalApprovalReviewL1.GetDurationNDurationTypeDal(AppId);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                objDalApprovalReviewL1 = null;
            }
        }

        public DateTime GetArrivalDate(string AppId)
        {
            DataAccessLayer.DalApprovalReviewL1 objGetArrivalDate = null;
            DateTime dt;
            //dt = new DataTable();

            try
            {

                objGetArrivalDate = new DataAccessLayer.DalApprovalReviewL1();
                return dt = Convert.ToDateTime(objGetArrivalDate.GetArrivalDate(AppId).Rows[0][0]);


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
            DataAccessLayer.DalApprovalReviewL1 objDalApprovalReviewL1 = null;
            DataTable dt = null;
            dt = new DataTable();

            try
            {
                objDalApprovalReviewL1 = new DataAccessLayer.DalApprovalReviewL1();
                return dt = objDalApprovalReviewL1.InsertValidTillDal(AppId, ValidTillDate);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                objDalApprovalReviewL1 = null;
            }
        }

        //-------------------------By chitresh ------------------------
        public int UpdateApplicationStatusCommandCenter()
        {
            DataAccessLayer.DalApprovalReviewL1 ObjDalApprovalReviewL1 = null;
            DataTable dt = null;
            try
            {
                ObjDalApprovalReviewL1 = new DataAccessLayer.DalApprovalReviewL1();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                //Code for adding columns in datatable.
                dt.Columns.Add("APPLICATIONID");
                dt.Columns.Add("GenerateFileCode");
                //dt.Columns.Add("APPROVER1STATUS");
                // dt.Columns.Add("APPROVER1COMMENTS");
                // dt.Columns.Add("Rejection_Code");
                dt.Columns.Add("L1Id");
                // dt.Columns.Add("ModifiedBy");

                dr["APPLICATIONID"] = this.APPLICATIONID;
                dr["GenerateFileCode"] = this.GenerateFileCode;
                // dr["APPROVER1STATUS"] = this.APPROVER1STATUS;
                //  dr["APPROVER1COMMENTS"] = this.APPROVER1COMMENTS;
                // dr["Rejection_Code"] = this.Rejection_Code;
                dr["L1Id"] = this.L1Id;
                // dr["ModifiedBy"] = this.ModifiedBy;

                dt.Rows.Add(dr);

                return ObjDalApprovalReviewL1.UpdateApplicationStatusCommandCenter(dt);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dt = null;
                ObjDalApprovalReviewL1 = null;
            }
        }


        public string GenerateFileCode { get; set; }

        public DataTable GetDocLsit(string ApplicationId)
        {
            DataAccessLayer.DalApprovalReviewL1 objDalApprovalReviewL1 = null;
            DataTable dt = null;
            dt = new DataTable();

            try
            {
                objDalApprovalReviewL1 = new DataAccessLayer.DalApprovalReviewL1();
                return dt = objDalApprovalReviewL1.GetDocList(ApplicationId);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                objDalApprovalReviewL1 = null;
            }

        }
        //----------------------- end -------------------------------
//------------------------------------------------------by chitresh CERPAC ------------------------------------------------------
        public string passportissueby { get; set; }

        public string dateofissuep { get; set; }

        public string dateofexpp { get; set; }

        public string placeissuep { get; set; }

        public string companyname { get; set; }

        public string companyadd1 { get; set; }

        public string companyadd2 { get; set; }

        public string designation { get; set; }

        public string comptelno { get; set; }

        public string compfaxno { get; set; }

        public string emailprsn { get; set; }

        public string contactprsn { get; set; }

        public string cerpacno { get; set; }

        public string companyid { get; set; }

        public string UserId { get; set; }

        public string reason { get; set; }

        public string zonenote { get; set; }

        public string authnotes { get; set; }

        public string fname { get; set; }

        public string lname { get; set; }

        public string mname { get; set; }

        public string nationality { get; set; }

        public string passportno { get; set; }

        public string sex { get; set; }

        public string docode { get; set; }

        public string isdependent { get; set; }

        public string dependenton { get; set; }

        public string dependentrelation { get; set; }

        public string fileno { get; set; }

        public int UpdateCerpacData()
        {
            DataAccessLayer.DalApprovalReviewL1 ObjDalApprovalReviewL1 = null;
            DataTable dt = null;
            try
            {
                ObjDalApprovalReviewL1 = new DataAccessLayer.DalApprovalReviewL1();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                //Code for adding columns in datatable.
                dt.Columns.Add("passportissueby");
                dt.Columns.Add("dateofissuep");
                dt.Columns.Add("dateofexpp");
                dt.Columns.Add("placeissuep");
                dt.Columns.Add("companyname");
                dt.Columns.Add("companyadd1");
                dt.Columns.Add("companyadd2");
                dt.Columns.Add("designation");
                dt.Columns.Add("comptelno");
                dt.Columns.Add("compfaxno");
                dt.Columns.Add("emailprsn");
                dt.Columns.Add("contactprsn");
                dt.Columns.Add("cerpacno");
                dt.Columns.Add("companyid");
                dt.Columns.Add("UserId");
                dt.Columns.Add("zonenote");
                dt.Columns.Add("fname");
                dt.Columns.Add("lname");
                dt.Columns.Add("mname");
                dt.Columns.Add("nationality");
                dt.Columns.Add("passportno");
                dt.Columns.Add("sex");
                dt.Columns.Add("fileno");
                

                dr["passportissueby"] = this.passportissueby;
                dr["dateofissuep"] = this.dateofissuep;
                dr["dateofexpp"] = this.dateofexpp;
                dr["placeissuep"] = this.placeissuep;
                dr["companyname"] = this.companyname;
                dr["companyadd1"] = this.companyadd1;
                dr["companyadd2"] = this.companyadd2;
                dr["designation"] = this.designation;
                dr["comptelno"] = this.comptelno;
                dr["compfaxno"] = this.compfaxno;
                dr["emailprsn"] = this.emailprsn;
                dr["contactprsn"] = this.contactprsn;
                dr["cerpacno"] = this.cerpacno;
                dr["companyid"] = this.companyid;
                dr["UserId"] = this.UserId;
                dr["zonenote"] = this.zonenote;
                dr["fname"] = this.fname;
                dr["lname"] = this.lname;
                dr["mname"] = this.mname;
                dr["nationality"] = this.nationality;
                dr["passportno"] = this.passportno;
                dr["sex"] = this.sex;
                dr["fileno"] = this.fileno;
               

                dt.Rows.Add(dr);

                return ObjDalApprovalReviewL1.UpdateCerpacData(dt);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dt = null;
                ObjDalApprovalReviewL1 = null;
            }
        }

        public int UpdateCerpacApplicantData()
        {
            DataAccessLayer.DalApprovalReviewL1 ObjDalApprovalReviewL1 = null;
            DataTable dt = null;
            try
            {
                ObjDalApprovalReviewL1 = new DataAccessLayer.DalApprovalReviewL1();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                //Code for adding columns in datatable.
                dt.Columns.Add("passportissueby");
                dt.Columns.Add("dateofissuep");
                dt.Columns.Add("dateofexpp");
                dt.Columns.Add("placeissuep");
                dt.Columns.Add("companyname");
                dt.Columns.Add("companyadd1");
                dt.Columns.Add("companyadd2");
                dt.Columns.Add("designation");
                dt.Columns.Add("comptelno");
                dt.Columns.Add("compfaxno");
                dt.Columns.Add("emailprsn");
                dt.Columns.Add("contactprsn");
                dt.Columns.Add("cerpacno");
                dt.Columns.Add("companyid");
                dt.Columns.Add("UserId");
                dt.Columns.Add("zonenote");
                dt.Columns.Add("fname");
                dt.Columns.Add("lname");
                dt.Columns.Add("mname");
                dt.Columns.Add("nationality");
                dt.Columns.Add("passportno");
                dt.Columns.Add("sex");
                dt.Columns.Add("fileno");


                dr["passportissueby"] = this.passportissueby;
                dr["dateofissuep"] = this.dateofissuep;
                dr["dateofexpp"] = this.dateofexpp;
                dr["placeissuep"] = this.placeissuep;
                dr["companyname"] = this.companyname;
                dr["companyadd1"] = this.companyadd1;
                dr["companyadd2"] = this.companyadd2;
                dr["designation"] = this.designation;
                dr["comptelno"] = this.comptelno;
                dr["compfaxno"] = this.compfaxno;
                dr["emailprsn"] = this.emailprsn;
                dr["contactprsn"] = this.contactprsn;
                dr["cerpacno"] = this.cerpacno;
                dr["companyid"] = this.companyid;
                dr["UserId"] = this.UserId;
                dr["zonenote"] = this.zonenote;
                dr["fname"] = this.fname;
                dr["lname"] = this.lname;
                dr["mname"] = this.mname;
                dr["nationality"] = this.nationality;
                dr["passportno"] = this.passportno;
                dr["sex"] = this.sex;
                dr["fileno"] = this.fileno;


                dt.Rows.Add(dr);

                return ObjDalApprovalReviewL1.UpdateCerpacApplicantData(dt);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dt = null;
                ObjDalApprovalReviewL1 = null;
            }
        }

        public int InsertCerpacData()
        {
            DataAccessLayer.DalApprovalReviewL1 ObjDalApprovalReviewL1 = null;
            DataTable dt = null;
            try
            {
                ObjDalApprovalReviewL1 = new DataAccessLayer.DalApprovalReviewL1();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                //Code for adding columns in datatable.
                dt.Columns.Add("passportissueby");
                dt.Columns.Add("dateofissuep");
                dt.Columns.Add("dateofexpp");
                dt.Columns.Add("placeissuep");
                dt.Columns.Add("companyname");
                dt.Columns.Add("companyadd1");
                dt.Columns.Add("companyadd2");
                dt.Columns.Add("designation");
                dt.Columns.Add("comptelno");
                dt.Columns.Add("compfaxno");
                dt.Columns.Add("emailprsn");
                dt.Columns.Add("contactprsn");
                dt.Columns.Add("cerpacno");
                dt.Columns.Add("companyid");
                dt.Columns.Add("UserId");
                dt.Columns.Add("zonenote");
                dt.Columns.Add("fname");
                dt.Columns.Add("lname");
                dt.Columns.Add("mname");
                dt.Columns.Add("nationality");
                dt.Columns.Add("passportno");
                dt.Columns.Add("sex");
                dt.Columns.Add("fileno");


                dr["passportissueby"] = this.passportissueby;
                dr["dateofissuep"] = this.dateofissuep;
                dr["dateofexpp"] = this.dateofexpp;
                dr["placeissuep"] = this.placeissuep;
                dr["companyname"] = this.companyname;
                dr["companyadd1"] = this.companyadd1;
                dr["companyadd2"] = this.companyadd2;
                dr["designation"] = this.designation;
                dr["comptelno"] = this.comptelno;
                dr["compfaxno"] = this.compfaxno;
                dr["emailprsn"] = this.emailprsn;
                dr["contactprsn"] = this.contactprsn;
                dr["cerpacno"] = this.cerpacno;
                dr["companyid"] = this.companyid;
                dr["UserId"] = this.UserId;
                dr["zonenote"] = this.zonenote;
                dr["fname"] = this.fname;
                dr["lname"] = this.lname;
                dr["mname"] = this.mname;
                dr["nationality"] = this.nationality;
                dr["passportno"] = this.passportno;
                dr["sex"] = this.sex;
                dr["fileno"] = this.fileno;


                dt.Rows.Add(dr);

                return ObjDalApprovalReviewL1.InsertCerpacData(dt);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dt = null;
                ObjDalApprovalReviewL1 = null;
            }
        }

        public int Authorize()
        {
             DataAccessLayer.DalApprovalReviewL1 ObjDalApprovalReviewL1 = null;
            DataTable dt = null;
            try
            {
                ObjDalApprovalReviewL1 = new DataAccessLayer.DalApprovalReviewL1();
                dt = new DataTable();

                DataRow dr = dt.NewRow();
                dt.Columns.Add("UserId");
                dt.Columns.Add("cerpacno");
                dt.Columns.Add("authnotes");
                
                dr["UserId"] = this.UserId;
                dr["cerpacno"] = this.cerpacno;
                dr["authnotes"] = this.authnotes;

                dt.Rows.Add(dr);

                return ObjDalApprovalReviewL1.Authorize(dt);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dt = null;
                ObjDalApprovalReviewL1 = null;
            }


        }

        public int Reject()
        {
            DataAccessLayer.DalApprovalReviewL1 ObjDalApprovalReviewL1 = null;
            DataTable dt = null;
            try
            {
                ObjDalApprovalReviewL1 = new DataAccessLayer.DalApprovalReviewL1();
                dt = new DataTable();

                DataRow dr = dt.NewRow();
                dt.Columns.Add("UserId");
                dt.Columns.Add("cerpacno");
                dt.Columns.Add("reason");
                dt.Columns.Add("file_no");
                dt.Columns.Add("authnotes");

                dr["UserId"] = this.UserId;
                dr["cerpacno"] = this.cerpacno;
                dr["reason"] = this.reason;
                dr["file_no"] = this.fileno;
                dr["authnotes"] = this.authnotes;

                dt.Rows.Add(dr);

                return ObjDalApprovalReviewL1.Reject(dt);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dt = null;
                ObjDalApprovalReviewL1 = null;
            }
        }
        public int InsertDoc()
        {
            DataAccessLayer.DalApprovalReviewL1 ObjDalApprovalReviewL1 = null;
            DataTable dt = null;
            try
            {
                ObjDalApprovalReviewL1 = new DataAccessLayer.DalApprovalReviewL1();
                dt = new DataTable();

                DataRow dr = dt.NewRow();
                dt.Columns.Add("docode");
                dt.Columns.Add("cerpacno");
               

                dr["docode"] = this.docode;
                dr["cerpacno"] = this.cerpacno;
               

                dt.Rows.Add(dr);

                return ObjDalApprovalReviewL1.InsertDoc(dt);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dt = null;
                ObjDalApprovalReviewL1 = null;
            }
        }

        public int Confirm()
        {
            DataAccessLayer.DalApprovalReviewL1 ObjDalApprovalReviewL1 = null;
            DataTable dt = null;
            try
            {
                ObjDalApprovalReviewL1 = new DataAccessLayer.DalApprovalReviewL1();
                dt = new DataTable();

                DataRow dr = dt.NewRow();
                dt.Columns.Add("UserId");
                dt.Columns.Add("cerpacno");
               

                dr["UserId"] = this.UserId;
                dr["cerpacno"] = this.cerpacno;
               

                dt.Rows.Add(dr);

                return ObjDalApprovalReviewL1.Confirm(dt);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dt = null;
                ObjDalApprovalReviewL1 = null;
            }
        }

        public int Defer()
        {
            DataAccessLayer.DalApprovalReviewL1 ObjDalApprovalReviewL1 = null;
            DataTable dt = null;
            try
            {
                ObjDalApprovalReviewL1 = new DataAccessLayer.DalApprovalReviewL1();
                dt = new DataTable();

                DataRow dr = dt.NewRow();
                dt.Columns.Add("UserId");
                dt.Columns.Add("cerpacno");


                dr["UserId"] = this.UserId;
                dr["cerpacno"] = this.cerpacno;


                dt.Rows.Add(dr);

                return ObjDalApprovalReviewL1.Defer(dt);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dt = null;
                ObjDalApprovalReviewL1 = null;
            }
        }

        public int VerifyRejection()
        {
            DataAccessLayer.DalApprovalReviewL1 ObjDalApprovalReviewL1 = null;
            DataTable dt = null;
            try
            {
                ObjDalApprovalReviewL1 = new DataAccessLayer.DalApprovalReviewL1();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                //Code for adding columns in datatable.
                dt.Columns.Add("passportissueby");
                dt.Columns.Add("dateofissuep");
                dt.Columns.Add("dateofexpp");
                dt.Columns.Add("placeissuep");
                dt.Columns.Add("companyname");
                dt.Columns.Add("companyadd1");
                dt.Columns.Add("companyadd2");
                dt.Columns.Add("designation");
                dt.Columns.Add("comptelno");
                dt.Columns.Add("compfaxno");
                dt.Columns.Add("emailprsn");
                dt.Columns.Add("contactprsn");
                dt.Columns.Add("cerpacno");
                dt.Columns.Add("companyid");
                dt.Columns.Add("UserId");
                dt.Columns.Add("zonenote");
                dt.Columns.Add("fname");
                dt.Columns.Add("lname");
                dt.Columns.Add("mname");
                dt.Columns.Add("nationality");
                dt.Columns.Add("passportno");
                dt.Columns.Add("sex");
                dt.Columns.Add("fileno");


                dr["passportissueby"] = this.passportissueby;
                dr["dateofissuep"] = this.dateofissuep;
                dr["dateofexpp"] = this.dateofexpp;
                dr["placeissuep"] = this.placeissuep;
                dr["companyname"] = this.companyname;
                dr["companyadd1"] = this.companyadd1;
                dr["companyadd2"] = this.companyadd2;
                dr["designation"] = this.designation;
                dr["comptelno"] = this.comptelno;
                dr["compfaxno"] = this.compfaxno;
                dr["emailprsn"] = this.emailprsn;
                dr["contactprsn"] = this.contactprsn;
                dr["cerpacno"] = this.cerpacno;
                dr["companyid"] = this.companyid;
                dr["UserId"] = this.UserId;
                dr["zonenote"] = this.zonenote;
                dr["fname"] = this.fname;
                dr["lname"] = this.lname;
                dr["mname"] = this.mname;
                dr["nationality"] = this.nationality;
                dr["passportno"] = this.passportno;
                dr["sex"] = this.sex;
                dr["fileno"] = this.fileno;


                dt.Rows.Add(dr);

                return ObjDalApprovalReviewL1.VerifyRejection(dt);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dt = null;
                ObjDalApprovalReviewL1 = null;
            }
        }

        public int VerifyRejectionAfterQuality()
        {
            DataAccessLayer.DalApprovalReviewL1 ObjDalApprovalReviewL1 = null;
            DataTable dt = null;
            try
            {
                ObjDalApprovalReviewL1 = new DataAccessLayer.DalApprovalReviewL1();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                //Code for adding columns in datatable.
                dt.Columns.Add("passportissueby");
                dt.Columns.Add("dateofissuep");
                dt.Columns.Add("dateofexpp");
                dt.Columns.Add("placeissuep");
                dt.Columns.Add("companyname");
                dt.Columns.Add("companyadd1");
                dt.Columns.Add("companyadd2");
                dt.Columns.Add("designation");
                dt.Columns.Add("comptelno");
                dt.Columns.Add("compfaxno");
                dt.Columns.Add("emailprsn");
                dt.Columns.Add("contactprsn");
                dt.Columns.Add("cerpacno");
                dt.Columns.Add("companyid");
                dt.Columns.Add("UserId");
                dt.Columns.Add("zonenote");
                dt.Columns.Add("fname");
                dt.Columns.Add("lname");
                dt.Columns.Add("mname");
                dt.Columns.Add("nationality");
                dt.Columns.Add("passportno");
                dt.Columns.Add("sex");
                dt.Columns.Add("fileno");


                dr["passportissueby"] = this.passportissueby;
                dr["dateofissuep"] = this.dateofissuep;
                dr["dateofexpp"] = this.dateofexpp;
                dr["placeissuep"] = this.placeissuep;
                dr["companyname"] = this.companyname;
                dr["companyadd1"] = this.companyadd1;
                dr["companyadd2"] = this.companyadd2;
                dr["designation"] = this.designation;
                dr["comptelno"] = this.comptelno;
                dr["compfaxno"] = this.compfaxno;
                dr["emailprsn"] = this.emailprsn;
                dr["contactprsn"] = this.contactprsn;
                dr["cerpacno"] = this.cerpacno;
                dr["companyid"] = this.companyid;
                dr["UserId"] = this.UserId;
                dr["zonenote"] = this.zonenote;
                dr["fname"] = this.fname;
                dr["lname"] = this.lname;
                dr["mname"] = this.mname;
                dr["nationality"] = this.nationality;
                dr["passportno"] = this.passportno;
                dr["sex"] = this.sex;
                dr["fileno"] = this.fileno;


                dt.Rows.Add(dr);

                return ObjDalApprovalReviewL1.VerifyRejectionAfterQuality(dt);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dt = null;
                ObjDalApprovalReviewL1 = null;
            }
        }

       //---------------------------------------------------end-------------------------------------------------------------------



        
    }
}
