using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;

namespace BusinessEntityLayer
{
    public class BalCompanyDetails
    {
        #region Private Variables

        private string _Company_Name;
        private string _Comp_Address_Line1;
        private string _Comp_Address_Line2;
        private string _Comp_Address_Line3;
        private string _Company_Zip;
        private string _Company_Phone1;
        private string _Company_Phone2;
        private string _Company_Phone3;
        private string _Company_Fax;
        private string _Company_WebSite;
        private string _Company_EmailId;
        private string _Company_Logo;
        private string _Created_By;
        private int _CompanyId;

        #endregion

        #region Public Variables

        public string Company_Name
        {
            get
            {
                return _Company_Name;
            }
            set
            {
                _Company_Name = value;
            }
        }



        public int CompanyId
        {
            get
            {
                return _CompanyId;
            }
            set
            {
                _CompanyId = value;
            }
        }

        public string Comp_Address_Line1
        {
            get
            {
                return _Comp_Address_Line1;
            }
            set
            {
                _Comp_Address_Line1 = value;
            }
        }
        public string Comp_Address_Line2
        {
            get
            {
                return _Comp_Address_Line2;
            }
            set
            {
                _Comp_Address_Line2 = value;
            }
        }
        public string Comp_Address_Line3
        {
            get
            {
                return _Comp_Address_Line3;
            }
            set
            {
                _Comp_Address_Line3 = value;
            }
        }

        public string Company_Zip
        {

            get
            {
                return _Company_Zip;
            }
            set
            {
                _Company_Zip = value;
            }

        }

        public string Company_Phone1
        {

            get
            {
                return _Company_Phone1;
            }
            set
            {
                _Company_Phone1 = value;
            }

        }
        public string Company_Phone2
        {

            get
            {
                return _Company_Phone2;
            }
            set
            {
                _Company_Phone2 = value;
            }

        }
        public string Company_Phone3
        {

            get
            {
                return _Company_Phone3;
            }
            set
            {
                _Company_Phone3 = value;
            }

        }

        public string Company_Fax
        {

            get
            {
                return _Company_Fax;
            }
            set
            {
                _Company_Fax = value;
            }

        }

        public string Company_WebSite
        {

            get
            {
                return _Company_WebSite;
            }
            set
            {
                _Company_WebSite = value;
            }

        }

        public string Company_EmailId
        {

            get
            {
                return _Company_EmailId;
            }
            set
            {
                _Company_EmailId = value;
            }

        }

        public string Company_Logo
        {

            get
            {
                return _Company_Logo;
            }
            set
            {
                _Company_Logo = value;
            }

        }

        public string Created_By
        {

            get
            {
                return _Created_By;
            }
            set
            {
                _Created_By = value;
            }

        }

        #endregion


        public int InsertCompanyRegistration()
        {
            DataAccessLayer.DalCompanyDetails ObjDalCompanyDetails = null;
            DataTable dtCompanyDetails = null;
            try
            {
                ObjDalCompanyDetails = new DataAccessLayer.DalCompanyDetails();
                dtCompanyDetails = new DataTable();

                DataRow drCompanyDetails = dtCompanyDetails.NewRow();

                dtCompanyDetails.Columns.Add("Company_Name");
                dtCompanyDetails.Columns.Add("Comp_Address_Line1");
                dtCompanyDetails.Columns.Add("Comp_Address_Line2");
                dtCompanyDetails.Columns.Add("Comp_Address_Line3");
                dtCompanyDetails.Columns.Add("Company_Zip");
                dtCompanyDetails.Columns.Add("Company_Phone1");
                dtCompanyDetails.Columns.Add("Company_Phone2");
                dtCompanyDetails.Columns.Add("Company_Phone3");
                dtCompanyDetails.Columns.Add("Company_Fax");
                dtCompanyDetails.Columns.Add("Company_WebSite");
                dtCompanyDetails.Columns.Add("Company_EmailId");
                dtCompanyDetails.Columns.Add("Company_Logo");
                dtCompanyDetails.Columns.Add("Created_By");

                drCompanyDetails["Company_Name"] = this._Company_Name;
                drCompanyDetails["Comp_Address_Line1"] = this._Comp_Address_Line1;
                drCompanyDetails["Comp_Address_Line2"] = this._Comp_Address_Line2;
                drCompanyDetails["Comp_Address_Line3"] = this._Comp_Address_Line3;
                drCompanyDetails["Company_Zip"] = this._Company_Zip;
                drCompanyDetails["Company_Phone1"] = this._Company_Phone1;
                drCompanyDetails["Company_Phone2"] = this._Company_Phone2;
                drCompanyDetails["Company_Phone3"] = this._Company_Phone3;
                drCompanyDetails["Company_Fax"] = this._Company_Fax;
                drCompanyDetails["Company_WebSite"] = this._Company_WebSite;
                drCompanyDetails["Company_EmailId"] = this._Company_EmailId;
                drCompanyDetails["Company_Logo"] = this._Company_Logo;
                drCompanyDetails["Created_By"] = this._Created_By;

                dtCompanyDetails.Rows.Add(drCompanyDetails);

                return ObjDalCompanyDetails.InsertCompanyRegistration(dtCompanyDetails);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dtCompanyDetails = null;
                ObjDalCompanyDetails = null;
            }



        }

        public int UpdateCompanyRegistration()
        {
            DataAccessLayer.DalCompanyDetails ObjDalCompanyDetails = null;
            DataTable dtCompanyDetails = null;
            try
            {
                ObjDalCompanyDetails = new DataAccessLayer.DalCompanyDetails();
                dtCompanyDetails = new DataTable();

                DataRow drCompanyDetails = dtCompanyDetails.NewRow();

                dtCompanyDetails.Columns.Add("CompanyId");
                dtCompanyDetails.Columns.Add("Company_Name");
                dtCompanyDetails.Columns.Add("Comp_Address_Line1");
                dtCompanyDetails.Columns.Add("Comp_Address_Line2");
                dtCompanyDetails.Columns.Add("Comp_Address_Line3");
                dtCompanyDetails.Columns.Add("Company_Zip");
                dtCompanyDetails.Columns.Add("Company_Phone1");
                dtCompanyDetails.Columns.Add("Company_Phone2");
                dtCompanyDetails.Columns.Add("Company_Phone3");
                dtCompanyDetails.Columns.Add("Company_Fax");
                dtCompanyDetails.Columns.Add("Company_WebSite");
                dtCompanyDetails.Columns.Add("Company_EmailId");
                dtCompanyDetails.Columns.Add("Company_Logo");
                dtCompanyDetails.Columns.Add("Created_By");

                drCompanyDetails["CompanyId"] = this._CompanyId;
                drCompanyDetails["Company_Name"] = this._Company_Name;
                drCompanyDetails["Comp_Address_Line1"] = this._Comp_Address_Line1;
                drCompanyDetails["Comp_Address_Line2"] = this._Comp_Address_Line2;
                drCompanyDetails["Comp_Address_Line3"] = this._Comp_Address_Line3;
                drCompanyDetails["Company_Zip"] = this._Company_Zip;
                drCompanyDetails["Company_Phone1"] = this._Company_Phone1;
                drCompanyDetails["Company_Phone2"] = this._Company_Phone2;
                drCompanyDetails["Company_Phone3"] = this._Company_Phone3;
                drCompanyDetails["Company_Fax"] = this._Company_Fax;
                drCompanyDetails["Company_WebSite"] = this._Company_WebSite;
                drCompanyDetails["Company_EmailId"] = this._Company_EmailId;
                drCompanyDetails["Company_Logo"] = this._Company_Logo;
                drCompanyDetails["Created_By"] = this._Created_By;

                dtCompanyDetails.Rows.Add(drCompanyDetails);

                return ObjDalCompanyDetails.UpdateCompanyRegistration(dtCompanyDetails);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dtCompanyDetails = null;
                ObjDalCompanyDetails = null;
            }



        }

        public DataSet GetCompanyInfo(int Company_Id)
        {
            DataAccessLayer.DalCompanyDetails ObjDalCompanyInfo = null;
            DataSet ds = null;

            try
            {
                ObjDalCompanyInfo = new DataAccessLayer.DalCompanyDetails();
                return ds = ObjDalCompanyInfo.GetCompanyInfo(Company_Id);

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                ObjDalCompanyInfo = null;
            }
        }

        public DataSet GetCompanyList()
        {
            DataAccessLayer.DalCompanyDetails ObjDalCompanyInfo = null;
            DataSet ds = null;

            try
            {
                ObjDalCompanyInfo = new DataAccessLayer.DalCompanyDetails();
                return ds = ObjDalCompanyInfo.GetCompanyList();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                ObjDalCompanyInfo = null;
            }
        }

        //public DataTable getDataRow(int keyvalue)
        //{
        //    DataTable dt = new DataTable();

        //    DataAccessLayer.DalCompanyDetails ObjDalCompanyDetails = null;
        //    ObjDalCompanyDetails = new DataAccessLayer.DalCompanyDetails();
        //    dt = ObjDalCompanyDetails.getDataRow(keyvalue);
        //    return dt;
        //}

        public int ExpireQuota(string keyvalue)
        {
            DataAccessLayer.DalCompanyDetails ObjDalCompanyDetails = null;
            ObjDalCompanyDetails = new DataAccessLayer.DalCompanyDetails();
            return ObjDalCompanyDetails.ExpireQuota(keyvalue);
        }

        public string PositionCode { get; set; }

        public string PositionName { get; set; }

        public int companyid { get; set; }

        public int InsertPosition()
        {
            DataAccessLayer.DalCompanyDetails ObjDalCompanyDetails = null;
            DataTable dtCompanyDetails = null;
            try
            {
                ObjDalCompanyDetails = new DataAccessLayer.DalCompanyDetails();
                dtCompanyDetails = new DataTable();

                DataRow drCompanyDetails = dtCompanyDetails.NewRow();

                
                dtCompanyDetails.Columns.Add("PositionName");
                dtCompanyDetails.Columns.Add("companyid");

               
                drCompanyDetails["PositionName"] = this.PositionName;
                drCompanyDetails["companyid"] = this.companyid;

                dtCompanyDetails.Rows.Add(drCompanyDetails);

                return ObjDalCompanyDetails.InsertPosition(dtCompanyDetails);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dtCompanyDetails = null;
                ObjDalCompanyDetails = null;
            }

        }

        public string QuotaNo { get; set; }

        public string dateofsanction { get; set; }

        public string Position { get; set; }

        public string NumPosition { get; set; }

        public string BalPosition { get; set; }
        public string dateofexipry { get; set; }

        public int InsertQuota()
        {
            DataAccessLayer.DalCompanyDetails ObjDalCompanyDetails = null;
            DataTable dtCompanyDetails = null;
            try
            {
                ObjDalCompanyDetails = new DataAccessLayer.DalCompanyDetails();
                dtCompanyDetails = new DataTable();

                DataRow drCompanyDetails = dtCompanyDetails.NewRow();

                dtCompanyDetails.Columns.Add("QuotaNo");
                dtCompanyDetails.Columns.Add("dateofsanction");
                dtCompanyDetails.Columns.Add("Position");
                dtCompanyDetails.Columns.Add("NumPosition");
                dtCompanyDetails.Columns.Add("BalPosition");
                dtCompanyDetails.Columns.Add("companyid");
                dtCompanyDetails.Columns.Add("dateofexipry");


                drCompanyDetails["QuotaNo"] = this.QuotaNo;
                drCompanyDetails["dateofsanction"] = this.dateofsanction;
                drCompanyDetails["Position"] = this.Position;
                drCompanyDetails["NumPosition"] = this.NumPosition;
                drCompanyDetails["BalPosition"] = this.BalPosition;
                drCompanyDetails["companyid"] = this.companyid;
                drCompanyDetails["dateofexipry"] = this.dateofexipry;

                dtCompanyDetails.Rows.Add(drCompanyDetails);

                return ObjDalCompanyDetails.InsertQuota(dtCompanyDetails);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dtCompanyDetails = null;
                ObjDalCompanyDetails = null;
            }
        }

        public int DeleteDataRow(string keyvalue)
        {
            DataAccessLayer.DalCompanyDetails ObjDalCompanyDetails = null;
            ObjDalCompanyDetails = new DataAccessLayer.DalCompanyDetails();
            return ObjDalCompanyDetails.DeleteDataRow(keyvalue);
        }

        public int UpdatePosition()
        {
            DataAccessLayer.DalCompanyDetails ObjDalCompanyDetails = null;
            DataTable dtCompanyDetails = null;
            try
            {
                ObjDalCompanyDetails = new DataAccessLayer.DalCompanyDetails();
                dtCompanyDetails = new DataTable();

                DataRow drCompanyDetails = dtCompanyDetails.NewRow();

                dtCompanyDetails.Columns.Add("PositionCode");
                dtCompanyDetails.Columns.Add("PositionName");


                drCompanyDetails["PositionCode"] = this.PositionCode;
                drCompanyDetails["PositionName"] = this.PositionName;


                dtCompanyDetails.Rows.Add(drCompanyDetails);

                return ObjDalCompanyDetails.UpdatePosition(dtCompanyDetails);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dtCompanyDetails = null;
                ObjDalCompanyDetails = null;
            }

        }

        public int UpdateQuota()
        {
            DataAccessLayer.DalCompanyDetails ObjDalCompanyDetails = null;
            DataTable dtCompanyDetails = null;
            try
            {
                ObjDalCompanyDetails = new DataAccessLayer.DalCompanyDetails();
                dtCompanyDetails = new DataTable();

                DataRow drCompanyDetails = dtCompanyDetails.NewRow();

                dtCompanyDetails.Columns.Add("QuotaNo");
                dtCompanyDetails.Columns.Add("dateofsanction");
                dtCompanyDetails.Columns.Add("Position");
                dtCompanyDetails.Columns.Add("NumPosition");
                dtCompanyDetails.Columns.Add("BalPosition");
                dtCompanyDetails.Columns.Add("dateofexipry");//STRQuotaId
                dtCompanyDetails.Columns.Add("STRQuotaId");


                drCompanyDetails["QuotaNo"] = this.QuotaNo;
                drCompanyDetails["dateofsanction"] = this.dateofsanction;
                drCompanyDetails["Position"] = this.Position;
                drCompanyDetails["NumPosition"] = this.NumPosition;
                drCompanyDetails["BalPosition"] = this.BalPosition;
                drCompanyDetails["dateofexipry"] = this.dateofexipry;
                drCompanyDetails["STRQuotaId"] = this.STRQuotaId;

                dtCompanyDetails.Rows.Add(drCompanyDetails);

                return ObjDalCompanyDetails.UpdateQuota(dtCompanyDetails);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dtCompanyDetails = null;
                ObjDalCompanyDetails = null;
            }
        }

        public string dateofbirth { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Nationality { get; set; }

        public string PassportNo { get; set; }

        public int applicationid { get; set; }

        public int InsertApplicant()
        {
            DataAccessLayer.DalCompanyDetails ObjDalCompanyDetails = null;
            DataTable dtCompanyDetails = null;
            try
            {
                ObjDalCompanyDetails = new DataAccessLayer.DalCompanyDetails();
                dtCompanyDetails = new DataTable();

                DataRow drCompanyDetails = dtCompanyDetails.NewRow();

                dtCompanyDetails.Columns.Add("QuotaNo");
                dtCompanyDetails.Columns.Add("dateofbirth");
                dtCompanyDetails.Columns.Add("FirstName");
                dtCompanyDetails.Columns.Add("LastName");
                dtCompanyDetails.Columns.Add("Nationality");
                dtCompanyDetails.Columns.Add("PassportNo");
                dtCompanyDetails.Columns.Add("companyid");
                dtCompanyDetails.Columns.Add("PositionCode");


                drCompanyDetails["QuotaNo"] = this.QuotaNo;
                drCompanyDetails["dateofbirth"] = this.dateofbirth;
                drCompanyDetails["FirstName"] = this.FirstName;
                drCompanyDetails["LastName"] = this.LastName;
                drCompanyDetails["Nationality"] = this.Nationality;
                drCompanyDetails["PassportNo"] = this.PassportNo;
                drCompanyDetails["companyid"] = this.companyid;
                drCompanyDetails["PositionCode"] = this.PositionCode;

                dtCompanyDetails.Rows.Add(drCompanyDetails);

                return ObjDalCompanyDetails.InsertApplicant(dtCompanyDetails);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dtCompanyDetails = null;
                ObjDalCompanyDetails = null;
            }
        }

        public int UpdateApplicantData()
        {
            DataAccessLayer.DalCompanyDetails ObjDalCompanyDetails = null;
            DataTable dtCompanyDetails = null;
            try
            {
                ObjDalCompanyDetails = new DataAccessLayer.DalCompanyDetails();
                dtCompanyDetails = new DataTable();

                DataRow drCompanyDetails = dtCompanyDetails.NewRow();

                dtCompanyDetails.Columns.Add("QuotaNo");
                dtCompanyDetails.Columns.Add("dateofbirth");
                dtCompanyDetails.Columns.Add("FirstName");
                dtCompanyDetails.Columns.Add("LastName");
                dtCompanyDetails.Columns.Add("Nationality");
                dtCompanyDetails.Columns.Add("PassportNo");
                dtCompanyDetails.Columns.Add("applicationid");
                dtCompanyDetails.Columns.Add("PositionCode");


                drCompanyDetails["QuotaNo"] = this.QuotaNo;
                drCompanyDetails["dateofbirth"] = this.dateofbirth;
                drCompanyDetails["FirstName"] = this.FirstName;
                drCompanyDetails["LastName"] = this.LastName;
                drCompanyDetails["Nationality"] = this.Nationality;
                drCompanyDetails["PassportNo"] = this.PassportNo;
                drCompanyDetails["applicationid"] = this.applicationid;
                drCompanyDetails["PositionCode"] = this.PositionCode;

                dtCompanyDetails.Rows.Add(drCompanyDetails);

                return ObjDalCompanyDetails.UpdateApplicantData(dtCompanyDetails);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dtCompanyDetails = null;
                ObjDalCompanyDetails = null;
            }
        }

        public string RequisitionNo { get; set; }
        public string DateofResign { get; set; }
        public string STRQuotaId { get; set; }

        public int CreateRequistion()
        {
            DataAccessLayer.DalCompanyDetails ObjDalCompanyDetails = null;
            DataTable dtCompanyDetails = null;
            try
            {
                ObjDalCompanyDetails = new DataAccessLayer.DalCompanyDetails();
                dtCompanyDetails = new DataTable();

                DataRow drCompanyDetails = dtCompanyDetails.NewRow();

                dtCompanyDetails.Columns.Add("applicationId");
                dtCompanyDetails.Columns.Add("RequisitionNo");

                drCompanyDetails["applicationId"] = this.applicationid;
                drCompanyDetails["RequisitionNo"] = this.RequisitionNo;


                dtCompanyDetails.Rows.Add(drCompanyDetails);

                return ObjDalCompanyDetails.CreateRequistion(dtCompanyDetails);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dtCompanyDetails = null;
                ObjDalCompanyDetails = null;
            }
        }

        public int UpdateBalancePosition()
        {
            DataAccessLayer.DalCompanyDetails ObjDalCompanyDetails = null;
            DataTable dtCompanyDetails = null;
            try
            {
                ObjDalCompanyDetails = new DataAccessLayer.DalCompanyDetails();
                dtCompanyDetails = new DataTable();

                DataRow drCompanyDetails = dtCompanyDetails.NewRow();

                dtCompanyDetails.Columns.Add("QuotaNo");
                dtCompanyDetails.Columns.Add("PositionCode");
                dtCompanyDetails.Columns.Add("DateofResign");
                dtCompanyDetails.Columns.Add("applicationid");

                drCompanyDetails["QuotaNo"] = this.QuotaNo;
                drCompanyDetails["PositionCode"] = this.PositionCode;
                drCompanyDetails["DateofResign"] = this.DateofResign;
                drCompanyDetails["applicationid"] = this.applicationid;

                dtCompanyDetails.Rows.Add(drCompanyDetails);

                return ObjDalCompanyDetails.UpdateBalancePosition(dtCompanyDetails);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dtCompanyDetails = null;
                ObjDalCompanyDetails = null;
            }
        }

       
    }
}
