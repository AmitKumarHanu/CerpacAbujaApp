using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BusinessEntityLayer
{
    public class BalCurrencyDetails
    {
        #region Private Variables

        private string _CurrencyCode;
        private string _CurrencyName;
        private string _ModifiedBy;
        private string _CurrencyDescription;


        #endregion

        #region Public Variables

        public string CurrencyCode
        {
            get
            {
                return _CurrencyCode;
            }
            set
            {
                _CurrencyCode = value;
            }
        }
        public string CurrencyName
        {
            get
            {
                return _CurrencyName;
            }
            set
            {
                _CurrencyName = value;
            }
        }
       
        public string Status { get; set; }
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

        public string CurrencyDescription
        {
            get
            {
                return _CurrencyDescription;
            }
            set
            {
                _CurrencyDescription = value;
            }
        }

        #endregion


        public DataSet GetCurrencyList()
        {
            DataAccessLayer.DalCurrencyDetails ObjDalCurrencyInfo = null;
            DataSet ds = null;

            try
            {
                ObjDalCurrencyInfo = new DataAccessLayer.DalCurrencyDetails();
                return ds = ObjDalCurrencyInfo.GetCurrencyList();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                ObjDalCurrencyInfo = null;
            }
        }
        public DataTable FetchCurrencyDetails_CurrencyCode()
        {
            DataAccessLayer.DalCurrencyDetails ObjDalCurrencyDetails = null;

            try
            {
                ObjDalCurrencyDetails = new DataAccessLayer.DalCurrencyDetails();
                return ObjDalCurrencyDetails.FetchCurrencyDetails_CurrencyCode(this.CurrencyCode);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ObjDalCurrencyDetails = null;

            }
        }

        public int InsertCurrencyDetail()
        {
            DataAccessLayer.DalCurrencyDetails ObjDalCurrencyDetails = null;
            DataTable dt = null;
            try
            {
                ObjDalCurrencyDetails = new DataAccessLayer.DalCurrencyDetails();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                //Code for adding columns in datatable.
                dt.Columns.Add("CurrencyCode");
                dt.Columns.Add("CurrencyName");
                dt.Columns.Add("Status");
                dt.Columns.Add("ModifiedBy");

                dr["CurrencyCode"] = this.CurrencyCode;
                dr["CurrencyName"] = this.CurrencyName;
                dr["Status"] = this.Status;
                dr["ModifiedBy"] = this.ModifiedBy;

                dt.Rows.Add(dr);

                return ObjDalCurrencyDetails.InsertCurrencyDetail(dt);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dt = null;
                ObjDalCurrencyDetails = null;
            }
        }

        public int UpdateCurrencyDetail()
        {
            DataAccessLayer.DalCurrencyDetails ObjDalCurrencyDetails = null;
            DataTable dt = null;
            try
            {
                ObjDalCurrencyDetails = new DataAccessLayer.DalCurrencyDetails();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                //Code for adding columns in datatable.
                dt.Columns.Add("CurrencyCode");
                dt.Columns.Add("CurrencyName");
                dt.Columns.Add("Status");
                dt.Columns.Add("ModifiedBy");

                dr["CurrencyCode"] = this.CurrencyCode;
                dr["CurrencyName"] = this.CurrencyName;
                dr["Status"] = this.Status;
                dr["ModifiedBy"] = this.ModifiedBy;

                dt.Rows.Add(dr);

                return ObjDalCurrencyDetails.UpdateCurrencyDetail(dt);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dt = null;
                ObjDalCurrencyDetails = null;
            }
        }

        public int DeleteDataRow(string keyvalue)
        {
            DataAccessLayer.DalCurrencyDetails ObjDalCurrencyDetails = null;
            ObjDalCurrencyDetails = new DataAccessLayer.DalCurrencyDetails();
            //return ObjDalCurrencyDetails.DeleteDataRow(keyvalue);
            //return ObjDalCurrencyDetails.DeleteDataRow(keyvalue);
            return ObjDalCurrencyDetails.DeleteDataRow(keyvalue);
        }
    }
}
