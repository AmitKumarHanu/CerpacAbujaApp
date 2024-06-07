using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;

namespace BusinessEntityLayer
{
    public class BalAdminModule
    {
        #region Private Variables
        private string _Module_Id;
        private string _Module_Name;
        private string _Module_Status;
        private string _Company_Id;
        private string _Created_By;
        private string _Created_Date;
        private string _Modified_By;
        private string _Modified_Date;
        #endregion
        #region public property

        public string Module_Id
        {
            get
            {
                return _Module_Id;
            }
            set
            {
                _Module_Id = value;
            }
        }


        public string Module_Name
        {
            get
            {
                return _Module_Name;
            }
            set
            {
                _Module_Name = value;
            }
        }

        public string Module_Status
        {
            get
            {
                return _Module_Status;
            }
            set
            {
                _Module_Status = value;
            }
        }

        public string Company_Id
        {
            get
            {
                return _Company_Id;
            }
            set
            {
                _Company_Id = value;
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

        public string Created_Date
        {
            get
            {
                return _Created_Date;
            }
            set
            {
                _Created_Date = value;
            }
        }

        public string Modified_By
        {
            get
            {
                return _Modified_By;
            }
            set
            {
                _Modified_By = value;
            }
        }

        public string Modified_Date
        {
            get
            {
                return _Modified_Date;
            }
            set
            {
                _Modified_Date = value;
            }
        }

        #endregion


        /// <summary>
        /// <created By>Wasim Karim</created>
        /// </summary>
        /// <created>3 sept 2009</created>
        /// <Purpose>Insert data into ModuleMaster</Purpose>
        public int Insert_ModuleMaster()
        {
            DataAccessLayer.DalAdminModule ObjDalAdminModule = null;
            DataTable dtAdminModule = null;
            try
            {
                ObjDalAdminModule = new DataAccessLayer.DalAdminModule();
                dtAdminModule = new DataTable();

                DataRow dRowAdminModule = dtAdminModule.NewRow();

                dtAdminModule.Columns.Add("Module_Name");
                dtAdminModule.Columns.Add("Module_Status");
                dtAdminModule.Columns.Add("Company_Id");
                dtAdminModule.Columns.Add("Created_By");

                dRowAdminModule["Module_Name"] = this.Module_Name;
                dRowAdminModule["Module_Status"] = this.Module_Status;
                dRowAdminModule["Company_Id"] = this.Company_Id;
                dRowAdminModule["Created_By"] = this.Created_By;

                dtAdminModule.Rows.Add(dRowAdminModule);


                return ObjDalAdminModule.InsertAdminModule(dtAdminModule);
            }
            catch (Exception Ex)
            {
                throw (Ex);
            }
            finally
            {
                ObjDalAdminModule = null;
                dtAdminModule = null;
            }

        }

        /// <summary>
        /// <created By>Wasim Karim</created>
        /// </summary>
        /// <created>3 sept 2009</created>
        /// <Purpose>Update in ModuleMaster</Purpose>
        public int Update_ModuleMaster()
        {
            DataAccessLayer.DalAdminModule ObjDalAdminModule = null;
            DataTable dtAdminModule = null;
            try
            {
                ObjDalAdminModule = new DataAccessLayer.DalAdminModule();
                dtAdminModule = new DataTable();

                DataRow dRowAdminModule = dtAdminModule.NewRow();
                dtAdminModule.Columns.Add("Module_Id");
                dtAdminModule.Columns.Add("Module_Name");
                dtAdminModule.Columns.Add("Module_Status");
                dtAdminModule.Columns.Add("Company_Id");
                dtAdminModule.Columns.Add("Modified_By");

                dRowAdminModule["Module_Id"] = this.Module_Id;
                dRowAdminModule["Module_Name"] = this.Module_Name;
                dRowAdminModule["Module_Status"] = this.Module_Status;
                dRowAdminModule["Company_Id"] = this.Company_Id;
                dRowAdminModule["Modified_By"] = this.Modified_By;


                dtAdminModule.Rows.Add(dRowAdminModule);

                return ObjDalAdminModule.UpdateModuleMaster(dtAdminModule);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ObjDalAdminModule = null;
                dtAdminModule = null;
            }

        }

        public DataSet GetModuleInfo()
        {
            DataAccessLayer.DalAdminModule objModule = null;
            try
            {
                objModule = new DataAccessLayer.DalAdminModule();
                return objModule.GetModuleInfo(this.Module_Id);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                objModule = null;
            }

        }

        public DataTable GetUnAssociatedFormModuleList(string FormId,string CompanyId)
        {
            DataAccessLayer.DalAdminModule objModule = null;
            DataTable dt = null;
            
            try
            {
                objModule = new DataAccessLayer.DalAdminModule();
                dt = new DataTable();
                return dt = objModule.GetUnAssociatedFormModuleList(FormId, CompanyId);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                objModule = null;
            }
 
        }

        public DataTable GetAssociatedFormModuleList(string FormId, string CompanyId)
        {
            DataAccessLayer.DalAdminModule objModule = null;
            DataTable dt = null;

            try
            {
                objModule = new DataAccessLayer.DalAdminModule();
                dt = new DataTable();
                return dt = objModule.GetAssociatedFormModuleList(FormId, CompanyId);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                objModule = null;
            }

        }

        public int DeleteDataRow(int keyvalue)
        {
            DataAccessLayer.DalAdminModule ObjDalModDetails = null;
            ObjDalModDetails = new DataAccessLayer.DalAdminModule();
            return ObjDalModDetails.DeleteDataRow(keyvalue);
        }

       
    }
}
