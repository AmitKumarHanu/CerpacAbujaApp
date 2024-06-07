using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;
using System.Data.SqlClient;

namespace BusinessEntityLayer
{
    public class BalAdminKeyword
    {
        #region private variables

        private string _CompanyId;
        private string _Identifier;
        private string _IdentifierId;
        private string _UserId;
        #endregion

        #region public variables
       
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
        public string Identifier
        {
            get
            {
                return _Identifier;
            }
            set
            {
                _Identifier = value;
            }
        }

        public string IdentifierId
        {
            get
            {
                return _IdentifierId;
            }
            set
            {
                _IdentifierId = value;
            }
        }
        public string UserId
        {
            get
            {
                return _UserId;
            }
            set
            {
                _UserId = value;
            }
        }
        #endregion

        public DataTable BindGrid()
        {
            DataAccessLayer.DalAdminKeyword ObjDalAdminKeyword = null;

            try
            {
                ObjDalAdminKeyword = new DataAccessLayer.DalAdminKeyword();
                return ObjDalAdminKeyword.BindGrid(this._CompanyId);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ObjDalAdminKeyword = null;

            }
        }
        public DataTable BindGridByIdentifier(string IdentifierId)
        {
            DataAccessLayer.DalAdminKeyword ObjDalAdminKeyword = null;

            try
            {
                ObjDalAdminKeyword = new DataAccessLayer.DalAdminKeyword();
                return ObjDalAdminKeyword.BindGridByIdentifier(this._UserId, IdentifierId);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ObjDalAdminKeyword = null;

            }
        }
        public DataTable  Fetch_DocIdentifier()
        {
            DataAccessLayer.DalAdminKeyword ObjDalAdminKeyword = null;
            DataTable dt = null;
            try
            {
                dt = new DataTable();
                ObjDalAdminKeyword = new DataAccessLayer.DalAdminKeyword();
                return dt = ObjDalAdminKeyword.Fetch_DocIdentifier(this._IdentifierId);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ObjDalAdminKeyword = null;

            }
        }

        public void Insert_DocIdentifier()
        {
            DataAccessLayer.DalAdminKeyword ObjDalAdminKeyword = null;

            try
            {
                ObjDalAdminKeyword = new DataAccessLayer.DalAdminKeyword();
                ObjDalAdminKeyword.Insert_DocIdentifier(this._Identifier,this._CompanyId);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ObjDalAdminKeyword = null;

            }
        }
        public void Update_DocIdentifier()
        {
            DataAccessLayer.DalAdminKeyword ObjDalAdminKeyword = null;

            try
            {
                ObjDalAdminKeyword = new DataAccessLayer.DalAdminKeyword();
                ObjDalAdminKeyword.Update_DocIdentifier(this._Identifier, this._CompanyId,this._IdentifierId);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ObjDalAdminKeyword = null;

            }
        }


    }
}
