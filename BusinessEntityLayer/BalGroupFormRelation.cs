using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;

namespace BusinessEntityLayer
{
   public class BalGroupFormRelation
    {
        #region Private Variables
        
        private string _GrpId;
        private string _FormId;
       private string _CompanyId;
       private string _UserId;
        
        #endregion
        #region public property
        
        public string GrpId
        {
            get
            {
                return _GrpId;
            }
            set
            {
                _GrpId = value;
            }
        }

        public string FormId
        {
            get
            {
                return _FormId;
            }
            set
            {
                _FormId = value;
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
        //<summary>
        //<created By>Wasim Karim</created>
        //</summary>
        //<created>5 sept 2009</created>
        //<Purpose>Bind UnAssociatedListBox</Purpose>

       public DataSet FillListBoxes(string CurrentLogin)
        {
            DataAccessLayer.DalGroupFormRelation ObjDalGroupFormRelatioin = null;

            try
            {
                ObjDalGroupFormRelatioin = new DataAccessLayer.DalGroupFormRelation();
                return ObjDalGroupFormRelatioin.FillListBoxes(this.GrpId, CurrentLogin);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ObjDalGroupFormRelatioin = null;

            }
        }
       public DataTable BindGrid()
       {
           DataAccessLayer.DalGroupFormRelation ObjDalGroupFormRelatioin = null;

           try
           {
               ObjDalGroupFormRelatioin = new DataAccessLayer.DalGroupFormRelation();
               return ObjDalGroupFormRelatioin.BindGrid(this.UserId);
           }
           catch (Exception ex)
           {
               throw (ex);
           }
           finally
           {
               ObjDalGroupFormRelatioin = null;

           }
       }

        /// <summary>
        /// <created By>Wasim Karim</created>
        /// </summary>
        /// <created>5 sept 2009</created>
        /// <Purpose>Insert  into GroupFormRelation table</Purpose>
        /// 
        public int InsertGroupFormRelation()
        {
            DataAccessLayer.DalGroupFormRelation ObjDalGroupFormRelatioin = null;
            DataTable DtAssociated = null;
            try
            {
                ObjDalGroupFormRelatioin = new DataAccessLayer.DalGroupFormRelation();
                DtAssociated = new DataTable();

                DataRow dRowGroupFormRelatioin = DtAssociated.NewRow();

                DtAssociated.Columns.Add("CompanyID");
                DtAssociated.Columns.Add("GrpId");
                DtAssociated.Columns.Add("FormId");


                dRowGroupFormRelatioin["CompanyID"] = this.CompanyId;
                dRowGroupFormRelatioin["GrpId"] = this.GrpId;
                dRowGroupFormRelatioin["FormId"] = this.FormId;

                DtAssociated.Rows.Add(dRowGroupFormRelatioin);


                return ObjDalGroupFormRelatioin.InsertGroupFormRelation(DtAssociated);
            }
            catch (Exception Ex)
            {
                throw (Ex);
            }
            finally
            {
                ObjDalGroupFormRelatioin = null;
                DtAssociated = null;
            }

        }

    }
}
