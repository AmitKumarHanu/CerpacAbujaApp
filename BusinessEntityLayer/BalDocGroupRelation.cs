using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;
using System.Data.SqlClient;

namespace BusinessEntityLayer
{
    public class BalDocGroupRelation
    {
        #region private variables
        private string _DocNo;
        private string _CompanyId;
        #endregion

        #region public variables
        public string DocNo
        {
            get
            {
                return _DocNo;
            }
            set
            {
                _DocNo = value;
            }
        }

        public string CompanyId
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
        #endregion

        public DataTable BindGrid()
        {
            DataAccessLayer.DalDocGroupRelation ObjDalDocGroupRelation = null;

            try
            {
                ObjDalDocGroupRelation = new DataAccessLayer.DalDocGroupRelation();
                return ObjDalDocGroupRelation.BindGrid(this._CompanyId,this._DocNo);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ObjDalDocGroupRelation = null;

            }
        }

        public DataTable BindDataList()
        {
            DataAccessLayer.DalDocGroupRelation ObjDalDocGroupRelation = null;

            try
            {
                ObjDalDocGroupRelation = new DataAccessLayer.DalDocGroupRelation();
                return ObjDalDocGroupRelation.BindDataList(this._CompanyId, this._DocNo);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ObjDalDocGroupRelation = null;

            }
        }

        public DataTable DocInfo()
        {
            DataAccessLayer.DalDocGroupRelation ObjDalDocGroupRelation = null;

            try
            {
                ObjDalDocGroupRelation = new DataAccessLayer.DalDocGroupRelation();
                return ObjDalDocGroupRelation.DocInfo(this._DocNo);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ObjDalDocGroupRelation = null;

            }
    
        }
        public void InsertAccess(string DocNo, DataTable dtDocGrp,DataTable dtDocIdentifier)
        {
            DataAccessLayer.DalDocGroupRelation ObjDalDocGroupRelation = null;

            try
            {
                ObjDalDocGroupRelation = new DataAccessLayer.DalDocGroupRelation();
                ObjDalDocGroupRelation.InsertAccess(dtDocGrp,dtDocIdentifier,DocNo);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ObjDalDocGroupRelation = null;

            }
        }
    }
}
