using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace BusinessEntityLayer
{
    public class BalUserCountryVisaTypeRelation
    {

        #region Private Variables

        private int _UserID;
        private string _CountryCode;
        private string _VisaTypeCode;
       
        private string _CreatedBy;

        #endregion

        #region Public Variables

        public int UserID
        {
            get
            {
                return _UserID;
            }
            set
            {
                _UserID = value;
            }
        }
        public string CountryCode
        {
            get
            {
                return _CountryCode;
            }
            set
            {
                _CountryCode = value;
            }
        }

        public string VisaTypeCode
        {
            get
            {
                return _VisaTypeCode;
            }
            set
            {
                _VisaTypeCode = value;
            }
        }
       
        
        

        public string CreatedBy
        {

            get
            {
                return _CreatedBy;
            }
            set
            {
                _CreatedBy = value;
            }

        }

        #endregion

        public DataSet FillCountryListBoxes(int grpID)
        {
            DataAccessLayer.DalUserCountryVisaTypeRelation ObjDalUserCountryVisa = null;

            try
            {
                ObjDalUserCountryVisa = new DataAccessLayer.DalUserCountryVisaTypeRelation();
                return ObjDalUserCountryVisa.FillCountryListBoxes(grpID);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ObjDalUserCountryVisa = null;

            }
        }

        public DataSet FillVisaListBoxes(int grpID)
        {
            DataAccessLayer.DalUserCountryVisaTypeRelation ObjDalUserCountryVisa = null;

            try
            {
                ObjDalUserCountryVisa = new DataAccessLayer.DalUserCountryVisaTypeRelation();
                return ObjDalUserCountryVisa.FillVisaListBoxes(grpID);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ObjDalUserCountryVisa = null;

            }
        }
        public DataSet FillWorkCenterBoxes(int grpID)
        {
            DataAccessLayer.DalUserCountryVisaTypeRelation ObjDalUserCountryVisa = null;

            try
            {
                ObjDalUserCountryVisa = new DataAccessLayer.DalUserCountryVisaTypeRelation();
                return ObjDalUserCountryVisa.FillWorkCenterBoxes(grpID);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ObjDalUserCountryVisa = null;

            }
        }

        public DataSet FillActivityBoxes(int grpID)
        {
            DataAccessLayer.DalUserCountryVisaTypeRelation ObjDalUserCountryVisa = null;

            try
            {
                ObjDalUserCountryVisa = new DataAccessLayer.DalUserCountryVisaTypeRelation();
                return ObjDalUserCountryVisa.FillActivityBoxes(grpID);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ObjDalUserCountryVisa = null;

            }
        }

        public DataSet getUserCountryVisaTypeList()
        {
            DataAccessLayer.DalUserCountryVisaTypeRelation ObjCountryVisaType = null;
            DataSet ds = null;

            try
            {
                ObjCountryVisaType = new DataAccessLayer.DalUserCountryVisaTypeRelation();
                return ds = ObjCountryVisaType.getUserCountryVisaTypeList();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                ObjCountryVisaType = null;
            }
        }

        public int InsertUserCountryRelation()
        {
            DataAccessLayer.DalUserCountryVisaTypeRelation ObjDalUserCountry = null;
            DataTable dt = null;
            try
            {
                ObjDalUserCountry = new DataAccessLayer.DalUserCountryVisaTypeRelation();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                //Code for adding columns in datatable.
                dt.Columns.Add("UserID");
                dt.Columns.Add("CountryCode");
                dt.Columns.Add("CreatedBy");

                dr["UserID"] = this.UserID;
                dr["CountryCode"] = this.CountryCode;
                dr["CreatedBy"] = this.CreatedBy;

                dt.Rows.Add(dr);

                return ObjDalUserCountry.InsertUserCountryRelation(dt);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dt = null;
                ObjDalUserCountry = null;
            }
        }

        public int InsertUserVisaRelation()
        {
            DataAccessLayer.DalUserCountryVisaTypeRelation ObjDalUserVisa = null;
            DataTable dt = null;
            try
            {
                ObjDalUserVisa = new DataAccessLayer.DalUserCountryVisaTypeRelation();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                //Code for adding columns in datatable.
                dt.Columns.Add("UserID");
                dt.Columns.Add("VisaTypeCode");
                dt.Columns.Add("CreatedBy");

                dr["UserID"] = this.UserID;
                dr["VisaTypeCode"] = this.VisaTypeCode;
                dr["CreatedBy"] = this.CreatedBy;

                dt.Rows.Add(dr);

                return ObjDalUserVisa.InsertUserVisaRelation(dt);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dt = null;
                ObjDalUserVisa = null;
            }
        }
        public int InsertUserWorkCenterLink()
        {
            DataAccessLayer.DalUserCountryVisaTypeRelation ObjDalUserWorkCenter = null;
            DataTable dt = null;
            try
            {
                ObjDalUserWorkCenter = new DataAccessLayer.DalUserCountryVisaTypeRelation();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                //Code for adding columns in datatable.
                dt.Columns.Add("UserID");
                dt.Columns.Add("WorkCenterID");
                dt.Columns.Add("CreatedBy");

                dr["UserID"] = this.UserID;
                dr["WorkCenterID"] = this.WorkCenterID;
                //dr["WorkCenterName"] = this.WorkCenterName;
                dr["CreatedBy"] = this.CreatedBy;

                dt.Rows.Add(dr);

                return ObjDalUserWorkCenter.InsertUserWorkCenterLink(dt);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dt = null;
                ObjDalUserWorkCenter = null;
            }
        }
        public int InsertUserActivityLink()
        {
            DataAccessLayer.DalUserCountryVisaTypeRelation ObjDalUserActivity = null;
            DataTable dt = null;
            try
            {
                ObjDalUserActivity = new DataAccessLayer.DalUserCountryVisaTypeRelation();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                //Code for adding columns in datatable.
                dt.Columns.Add("UserID");
                dt.Columns.Add("ActivityID");
                dt.Columns.Add("CreatedBy");

                dr["UserID"] = this.UserID;
                dr["ActivityID"] = this.ActivityID;
                dr["CreatedBy"] = this.CreatedBy;

                dt.Rows.Add(dr);

                return ObjDalUserActivity.InsertUserActivityLink(dt);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dt = null;
                ObjDalUserActivity = null;
            }
        }


        public string WorkCenterID { get; set; }

        public string ActivityID { get; set; }
    }
}
