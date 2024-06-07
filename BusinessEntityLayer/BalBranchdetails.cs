using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BusinessEntityLayer
{
    public class BalBranchdetails
    {
        #region Private Variables

        private string _BranchCode;
        private string _BranchName;
       


        #endregion

        #region Public Variables

        public string BranchCode
        {
            get
            {
                return _BranchCode;
            }
            set
            {
                _BranchCode = value;
            }
        }

        public string BranchName
        {
            get
            {
                return _BranchName;
            }
            set
            {
                _BranchName = value;
            }
        }

        public string ModifiedBy { get; set; }

        #endregion


        public DataSet GetBranchList()
        {
            DataAccessLayer.DalBranchdetails ObjDalBranchInfo = null;
            DataSet ds = null;

            try
            {
                ObjDalBranchInfo = new DataAccessLayer.DalBranchdetails();
                return ds = ObjDalBranchInfo.GetBranchList();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                ObjDalBranchInfo = null;
            }
        }

        public int InsertBranchDetail()
        {
            DataAccessLayer.DalBranchdetails ObjDalBranchdetails = null;
            DataTable dt = null;
            try
            {
                ObjDalBranchdetails = new DataAccessLayer.DalBranchdetails();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                //Code for adding columns in datatable.
               // dt.Columns.Add("BranchCode");
                dt.Columns.Add("BranchName");
                dt.Columns.Add("ModifiedBy");

               // dr["BranchCode"] = this.BranchCode;
                dr["BranchName"] = this.BranchName;
                dr["ModifiedBy"] = this.ModifiedBy;

                dt.Rows.Add(dr);

                return ObjDalBranchdetails.InsertBranchDetail(dt);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dt = null;
                ObjDalBranchdetails = null;
            }
        }

        public DataTable FetchBranchdetails()
        {
            DataAccessLayer.DalBranchdetails ObjDalBranchdetails = null;

            try
            {
                ObjDalBranchdetails = new DataAccessLayer.DalBranchdetails();
                return ObjDalBranchdetails.FetchBranchDetails(this.BranchCode);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ObjDalBranchdetails = null;

            }
        }

        public int UpdateBranchdetail()
        {
            DataAccessLayer.DalBranchdetails ObjDalBranchdetails = null;
            DataTable dt = null;
            try
            {
                ObjDalBranchdetails = new DataAccessLayer.DalBranchdetails();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                //Code for adding columns in datatable.                
               
                dt.Columns.Add("BranchName");
                dt.Columns.Add("ModifiedBy");
                dt.Columns.Add("BranchCode");
                
                dr["BranchName"] = this.BranchName;
                dr["ModifiedBy"] = this.ModifiedBy;
                dr["BranchCode"] = this.BranchCode;
                dt.Rows.Add(dr);

                return ObjDalBranchdetails.UpdateBranchDetail(dt);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dt = null;
                ObjDalBranchdetails = null;
            }
        }

        public int DeleteDataRow(string keyvalue)
        {
            DataAccessLayer.DalBranchdetails ObjDalBranchdetails = null;
            ObjDalBranchdetails = new DataAccessLayer.DalBranchdetails();
            return ObjDalBranchdetails.DeleteDataRow(keyvalue);
        }



        public int InsertBranchdetail()
        {
            throw new NotImplementedException();
        }
    }
}
