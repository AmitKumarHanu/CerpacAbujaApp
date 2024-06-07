using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BusinessEntityLayer
{
   public  class BalRejectionMaster
    {
        #region Private Variables

       private string _Rejection_Code;
       private string _Rejection_Description;
        ////private string _CurrencyName;
        private string _ModifiedBy;
       


        #endregion

        #region Public Variables

        public string Rejection_Code
        {
            get
            {
                return _Rejection_Code;
            }
            set
            {
                _Rejection_Code = value;
            }
        }
        public string Rejection_Description
        {
            get
            {
                return _Rejection_Description;
            }
            set
            {
                _Rejection_Description = value;
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

        //public string CurrencyDescription
        //{
        //    get
        //    {
        //        return _CurrencyDescription;
        //    }
        //    set
        //    {
        //        _CurrencyDescription = value;
        //    }
        //}

        #endregion


        public DataSet GetRejetionList()
        {
            DataAccessLayer.DalRejectionMaster objRejectionMaster = null;
            DataSet ds = null;

            try
            {
                objRejectionMaster = new DataAccessLayer.DalRejectionMaster();
                return ds = objRejectionMaster.GetRejectionList();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                objRejectionMaster = null;
            }
        }

        public DataTable FetchRejectionDetails_RejectionCode()
        {
            DataAccessLayer.DalRejectionMaster objRejectionMaster = null;

            try
            {
                objRejectionMaster = new DataAccessLayer.DalRejectionMaster();
                return objRejectionMaster.FetchRejectionDetails_RejectionCode(this._Rejection_Code);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                objRejectionMaster = null;

            }
        }

        public int InsertRejectionDetail()
        {
            DataAccessLayer.DalRejectionMaster objRejectionMaster = null;
            DataTable dt = null;
            try
            {
                objRejectionMaster = new DataAccessLayer.DalRejectionMaster();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                //Code for adding columns in datatable.
                dt.Columns.Add("Rejection_Code");
                dt.Columns.Add("Rejection_Description");
                dt.Columns.Add("Status");
                dt.Columns.Add("ModifiedBy");

                dr["Rejection_Code"] = this._Rejection_Code;
                dr["Rejection_Description"] = this._Rejection_Description;
                dr["Status"] = this.Status;
                dr["ModifiedBy"] = this.ModifiedBy;

                dt.Rows.Add(dr);

                return objRejectionMaster.InsertRejectionDetail(dt);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dt = null;
                objRejectionMaster = null;
            }
        }

        public int UpdateRejectionDetail()
        {
            DataAccessLayer.DalRejectionMaster objRejectionMaster = null;
            DataTable dt = null;
            try
            {
                objRejectionMaster = new DataAccessLayer.DalRejectionMaster();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                //Code for adding columns in datatable.
                dt.Columns.Add("Rejection_Code");
                dt.Columns.Add("Rejection_Description");
                dt.Columns.Add("Status");
                dt.Columns.Add("ModifiedBy");

                dr["Rejection_Code"] = this._Rejection_Code;
                dr["Rejection_Description"] = this._Rejection_Description;
                dr["Status"] = this.Status;
                dr["ModifiedBy"] = this.ModifiedBy;

                dt.Rows.Add(dr);

                return objRejectionMaster.UpdateRejectionDetail(dt);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dt = null;
                objRejectionMaster = null;
            }
        }

        public int DeleteDataRow(string keyvalue)
        {
            DataAccessLayer.DalRejectionMaster objRejectionMaster = null;
            objRejectionMaster = new DataAccessLayer.DalRejectionMaster();
            //return ObjDalCurrencyDetails.DeleteDataRow(keyvalue);
            //return ObjDalCurrencyDetails.DeleteDataRow(keyvalue);
            return objRejectionMaster.DeleteDataRow(keyvalue);
        }

    }
}
