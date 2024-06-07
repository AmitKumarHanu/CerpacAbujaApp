using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

namespace BusinessEntityLayer
{
   public class BalFileUpload
   {
       #region Private Variables

       private string _doc_name;
       private string _doc_type;
       private string _doc_version;
       private string _uploaded_by;
       private string _company_id;
       private string _docDesc;
       private string _UserId;
       private string _Identifier;
       private string _FromDate;
       private string _Todate;
       private string _SpecifiedDoc_name;
       private string _strDocNo; // pipe seperated values of DocNo's.
       private string _CurrentLoginUser;
       private string _TypeOfDoc;


       #endregion

       #region Public Variables

       public string doc_name
       {
           get
           {
               return _doc_name;
           }
           set
           {
               _doc_name=value;
           }
        }
       public string SpecifiedDoc_name
       {
           get
           {
               return _SpecifiedDoc_name;
           }
           set
           {
               _SpecifiedDoc_name = value;
           }
       }
       public string docDesc
       {
           get
           {
               return _docDesc;
           }
           set
           {
               _docDesc = value;
           }
       }
       public string doc_type
       {
           get 
           {
               return _doc_type;
           }
           set 
           {
               _doc_type = value;
           }
       }
       public string doc_version
       {
           get
           {
               return _doc_version;
           }
           set
           {
               _doc_version=value;
           }
       }
       public string uploaded_by
       {
           get
           {
               return _uploaded_by;
           }
           set
           {
               _uploaded_by = value;
           }
       }
       public string company_id
       {

           get
           {
               return _company_id;
           }
           set
           {
               _company_id = value;
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
       public string FromDate
       {

           get
           {
               return _FromDate;
           }
           set
           {
               _FromDate = value;
           }

       }
       public string ToDate
       {

           get
           {
               return _Todate;
           }
           set
           {
               _Todate = value;
           }

       }

       public string strDocNo
       {

           get
           {
               return _strDocNo;
           }
           set
           {
               _strDocNo = value;
           }

       }

       public string CurrentLoginUser
       {

           get
           {
               return _CurrentLoginUser;
           }
           set
           {
               _CurrentLoginUser = value;
           }

       }


       public string TypeOfDoc
       {

           get
           {
               return _TypeOfDoc;
           }
           set
           {
               _TypeOfDoc = value;
           }

       }


       #endregion


       public int InsertUploadedFileDetail(string GeographicId)
       {
           DataAccessLayer.DalFileUpload ObjDalFileUpload = null;
           DataTable dtFileUpload = null;
           try
           {
               ObjDalFileUpload = new DataAccessLayer.DalFileUpload();
               dtFileUpload = new DataTable();

               DataRow drFileUpload = dtFileUpload.NewRow();

               dtFileUpload.Columns.Add("doc_name");
               dtFileUpload.Columns.Add("SpecifiedDoc_name");
               dtFileUpload.Columns.Add("doc_type");
               dtFileUpload.Columns.Add("doc_version");
               dtFileUpload.Columns.Add("uploaded_by");
               dtFileUpload.Columns.Add("company_id");
               dtFileUpload.Columns.Add("docDesc");
               dtFileUpload.Columns.Add("TypeOfDoc");

               drFileUpload["doc_name"] = this._doc_name;
               drFileUpload["SpecifiedDoc_name"] = this._SpecifiedDoc_name;
               drFileUpload["doc_type"] = this._doc_type;
               drFileUpload["doc_version"] = this._doc_version;
               drFileUpload["uploaded_by"] = this._uploaded_by;
               drFileUpload["company_id"] = this._company_id;
               drFileUpload["docDesc"] = this._docDesc;
               drFileUpload["TypeOfDoc"] = this.TypeOfDoc;
               dtFileUpload.Rows.Add(drFileUpload);

               return ObjDalFileUpload.InsertUploadedFileDetail(dtFileUpload,GeographicId);
              

           }
           catch (Exception ex)
           {
               throw (ex);
           }

           finally
           {
               dtFileUpload = null;
               ObjDalFileUpload = null;
           }
           


       }

       public DataTable BindGrid(int UserId)
       {
           DataTable dt = new DataTable();

           DataAccessLayer.DalFileUpload ObjDalFileUpload = null;
           ObjDalFileUpload = new DataAccessLayer.DalFileUpload();
           dt = ObjDalFileUpload.BindGrid(UserId);
           return dt;
       }


       //public DataTable getDataRow(int keyvalue)
       //{
       //    DataTable dt = new DataTable();

       //    DataAccessLayer.DalFileUpload ObjDalFileUpload = null;
       //    ObjDalFileUpload = new DataAccessLayer.DalFileUpload();
       //    dt = ObjDalFileUpload.getDataRow(keyvalue);
       //    return dt;
       //}

       public int DeleteDataRow(int keyvalue)
       {
           DataAccessLayer.DalFileUpload ObjDalFileUpload = null;
           ObjDalFileUpload = new DataAccessLayer.DalFileUpload();
           return ObjDalFileUpload.DeleteDataRow(keyvalue);
       }

       public DataTable GetFilePath(int DocNo)
       {
           DataAccessLayer.DalFileUpload ObjDalFileUpload = null;
           ObjDalFileUpload = new DataAccessLayer.DalFileUpload();
           return ObjDalFileUpload.GetFilePath(DocNo);
       }

       public DataTable BindGridFetchbyCompanyId(string CompanyId)
       {
           DataTable dt = new DataTable();

           DataAccessLayer.DalFileUpload ObjDalFileUpload = null;
           ObjDalFileUpload = new DataAccessLayer.DalFileUpload();
           dt = ObjDalFileUpload.BindGridFetchbyCompanyId(CompanyId);
           return dt;
       }

       public DataTable BindGridFetchForAll()
       {
           DataTable dt = new DataTable();

           DataAccessLayer.DalFileUpload ObjDalFileUpload = null;
           ObjDalFileUpload = new DataAccessLayer.DalFileUpload();
           dt = ObjDalFileUpload.BindGridFetchForAll(this._company_id, this._UserId, this._doc_type, this._Identifier, this._FromDate, this._Todate,this._doc_name);
           return dt;
       }
       public DataTable FetchDocNo(string GeoInfo)
       {
           DataTable dt = new DataTable();

           DataAccessLayer.DalFileUpload ObjDalFileUpload = null;
           ObjDalFileUpload = new DataAccessLayer.DalFileUpload();
           dt = ObjDalFileUpload.FetchDocNo(this._company_id, this._UserId, this._doc_type, this._Identifier, this._FromDate, this._Todate, this._doc_name,this._CurrentLoginUser,GeoInfo);
           return dt;
       }

       public DataTable BindGridAdvanceSearch()
       {
           DataTable dt = new DataTable();

           DataAccessLayer.DalFileUpload ObjDalFileUpload = null;
           ObjDalFileUpload = new DataAccessLayer.DalFileUpload();
           dt = ObjDalFileUpload.BindGridAdvanceSearch(this._strDocNo);
           return dt;
       }

       public void GetDocVersion(out string DocVersion)
       {
           DataTable dt = new DataTable();

           DataAccessLayer.DalFileUpload ObjDalFileUpload = null;
           ObjDalFileUpload = new DataAccessLayer.DalFileUpload();
           dt = ObjDalFileUpload.GetDocVersion(this.uploaded_by,this.doc_name);
           DocVersion = dt.Rows[0]["DocVersion"].ToString();

       }

       public DataTable BindGridForOther(int UserId)
       {
           DataTable dt = new DataTable();

           DataAccessLayer.DalFileUpload ObjDalFileUpload = null;
           ObjDalFileUpload = new DataAccessLayer.DalFileUpload();
           dt = ObjDalFileUpload.BindGridForOther(UserId);
           return dt;
       }
      
    }
}
