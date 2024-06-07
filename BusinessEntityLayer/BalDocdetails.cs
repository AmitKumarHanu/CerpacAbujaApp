using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BusinessEntityLayer
{
    public class BalDocdetails
    {
        #region Private Variables

        private string _DocCode;
        private string _DocName;
        private string _DocDesc { get; set; }


        #endregion

        #region Public Variables

        public string DocCode
        {
            get
            {
                return _DocCode;
            }
            set
            {
                _DocCode = value;
            }
        }

        public string DocName
        {
            get
            {
                return _DocName;
            }
            set
            {
                _DocName = value;
            }
        }
        public string DocDesc
        {
            get
            {
                return _DocDesc;
            }
            set
            {
                _DocDesc = value;
            }
        }

        public string ModifiedBy { get; set; }

        #endregion


        public DataSet GetDocList()
        {
            DataAccessLayer.DalDocdetails ObjDalDocInfo = null;
            DataSet ds = null;

            try
            {
                ObjDalDocInfo = new DataAccessLayer.DalDocdetails();
                return ds = ObjDalDocInfo.GetdocList();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                ObjDalDocInfo = null;
            }
        }

        public int InsertDocDetail()
        {
            DataAccessLayer.DalDocdetails ObjDalDocdetails = null;
            DataTable dt = null;
            try
            {
                ObjDalDocdetails = new DataAccessLayer.DalDocdetails();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                //Code for adding columns in datatable.
                dt.Columns.Add("DocCode");
                dt.Columns.Add("DocName");
                dt.Columns.Add("DocDesc");
                dt.Columns.Add("ModifiedBy");

                dr["DocCode"] = this.DocCode;
                dr["DocName"] = this.DocName;
                dr["DocDesc"] = this.DocDesc;
                dr["ModifiedBy"] = this.ModifiedBy;

                dt.Rows.Add(dr);

                return ObjDalDocdetails.InsertdocDetail(dt);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dt = null;
                ObjDalDocdetails = null;
            }
        }

        public DataTable FetchDocdetails()
        {
            DataAccessLayer.DalDocdetails ObjDalDocdetails = null;

            try
            {
                ObjDalDocdetails = new DataAccessLayer.DalDocdetails();
                return ObjDalDocdetails.FetchDocDetails(this.DocCode);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ObjDalDocdetails = null;

            }
        }

        public int UpdateDocdetail()
        {
            DataAccessLayer.DalDocdetails ObjDalDocdetails = null;
            DataTable dt = null;
            try
            {
                ObjDalDocdetails = new DataAccessLayer.DalDocdetails();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                //Code for adding columns in datatable.                
                dt.Columns.Add("DocCode");
                dt.Columns.Add("DocName");
                dt.Columns.Add("DocDesc");
                dt.Columns.Add("ModifiedBy");

                dr["DocCode"] = this.DocCode;
                dr["DocName"] = this.DocName;
                dr["DocDesc"] = this.DocDesc;
                dr["ModifiedBy"] = this.ModifiedBy;

                dt.Rows.Add(dr);

                return ObjDalDocdetails.UpdateDocDetail(dt);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dt = null;
                ObjDalDocdetails = null;
            }
        }

        public int DeleteDataRow(string keyvalue)
        {
            DataAccessLayer.DalDocdetails ObjDalDocdetails = null;
            ObjDalDocdetails = new DataAccessLayer.DalDocdetails();
            return ObjDalDocdetails.DeleteDataRow(keyvalue);
        }

        //======================================================= by chitresh for cerpac ============================================ ==============
        //************ Designation Master insert*************************




        public string designame { get; set; }

        public string createdby { get; set; }

        public string desigCode { get; set; }

        public int InsertDesignation()
        {
            DataAccessLayer.DalDocdetails ObjDalDocdetails = null;
            DataTable dt = null;
            try
            {
                ObjDalDocdetails = new DataAccessLayer.DalDocdetails();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                //Code for adding columns in datatable.
                dt.Columns.Add("designame");
                dt.Columns.Add("createdby");

                dr["designame"] = this.designame;
                dr["createdby"] = this.createdby;


                dt.Rows.Add(dr);

                return ObjDalDocdetails.InsertDesignation(dt);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dt = null;
                ObjDalDocdetails = null;
            }
        }


        // ****************************** end ****************************************************
        //********************************************updation Designation master*********************************************
        public int UpdateDeisgnation()
        {
            DataAccessLayer.DalDocdetails ObjDalDocdetails = null;
            DataTable dt = null;
            try
            {
                ObjDalDocdetails = new DataAccessLayer.DalDocdetails();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                //Code for adding columns in datatable.
                dt.Columns.Add("designame");
                dt.Columns.Add("desigCode");
                dt.Columns.Add("createdby");


                dr["designame"] = this.designame;
                dr["desigCode"] = this.desigCode;
                dr["createdby"] = this.createdby;


                dt.Rows.Add(dr);

                return ObjDalDocdetails.UpdateDesignation(dt);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dt = null;
                ObjDalDocdetails = null;
            }
        }
        //**********************************************end*********************************************************
        //============================================================end====================================================================

        
    }
}
