using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;

namespace BusinessEntityLayer
{
    public class BalAdminForm
    {
        #region Private Variables
        private string _Form_Id;
        private string _Form_Name;
        private string _Form_Url;
        private string _Form_Status;
        private string _ModIdList;
        private string _Company_Id;
        private string _Grp_Id;

        #endregion

        #region public property
        public string Form_Id
        {
            get
            {
                return _Form_Id;
            }
            set
            {
                _Form_Id = value;
            }
        }
        public string Form_Name
        {
            get
            {
                return _Form_Name;
            }
            set
            {
                _Form_Name = value;
            }
        }
        public string Form_Url
        {
            get
            {
                return _Form_Url;
            }
            set
            {
                _Form_Url = value;
            }
        }
        public string Form_Status
        {
            get
            {
                return _Form_Status;
            }
            set
            {
                _Form_Status = value;
            }
        }

        public string ModIdList
        {
            get
            {
                return _ModIdList;
            }
            set
            {
                _ModIdList = value;
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
        public string Grp_Id
        {
            get
            {
                return _Grp_Id;
            }
            set
            {
                _Grp_Id = value;
            }
        }
        #endregion

        //<summary>
        //<created By>Wasim Karim</created>
        //</summary>
        //<created>3 sept 2009</created>
        //<Purpose>Bind grid Listing</Purpose>
        public DataSet FillGridFormList()
        {
            DataAccessLayer.DalAdminForm ObjDalAdminForm = null;

            try
            {
                ObjDalAdminForm = new DataAccessLayer.DalAdminForm();
                if (this.Grp_Id == "34")
                {
                    this.Grp_Id = null;
                }
                return ObjDalAdminForm.FillGridFormList(this.Grp_Id);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ObjDalAdminForm = null;

            }
        }

        /// <summary>
        /// <created By>WasimKarim</created>
        /// </summary>
        /// <created>Date 26 Nov 2008</created>
        /// <Purpose>Update PS_FormMaster_Status</Purpose>
        //public int UpdatePS_FormMaster_Status(DataTable dtAdminForm)
        //{
        //    DataAccessLayer.DalAdminForm ObjDalAdminForm = null;


        //    try
        //    {
        //        ObjDalAdminForm = new DataAccessLayer.DalAdminForm();

        //        return ObjDalAdminForm.UpdatePS_FormMaster_Status(dtAdminForm);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        ObjDalAdminForm = null;
        //        dtAdminForm = null;
        //    }

        //}


        /// <summary>
        /// <created By>WasimKarim</created>
        /// </summary>
        /// <created>5 sept 2009</created>
        /// <Purpose>Insert into ModuleFormRelation table</Purpose>
        public int InsertFormModRelation()
        {
            DataAccessLayer.DalAdminForm ObjDalAdminForm = null;

            try
            {
                ObjDalAdminForm = new DataAccessLayer.DalAdminForm();
                return ObjDalAdminForm.InsertFormModRelation(this.Form_Id, this.ModIdList, this.Company_Id);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ObjDalAdminForm = null;
            }

        }

        public DataTable GetFormName(string FormId)
        {
            DataAccessLayer.DalAdminForm objFormName = null;
            DataTable dt = null;
            try
            {
                objFormName = new DataAccessLayer.DalAdminForm();
                return dt = objFormName.GetFormName(FormId);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                objFormName = null;
            }
        }

        /// <summary>
        /// <created By>WasimKarim</created>
        /// </summary>
        /// <created>8 sept 2009</created>
        /// <Purpose>Fetch FormMaster by GrpId</Purpose>
        public DataTable GetFormInfo(string GrpId, string CompanyId)
        {
            DataAccessLayer.DalAdminForm objFormInfo = null;
            DataTable dt = null;
            try
            {
                objFormInfo = new DataAccessLayer.DalAdminForm();
                return dt = objFormInfo.GetFormInfo(GrpId, CompanyId);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                objFormInfo = null;
            }
        }

        public int DeleteDataRow(int keyvalue)
        {
            DataAccessLayer.DalAdminForm ObjDalAdminForm = null;
            ObjDalAdminForm = new DataAccessLayer.DalAdminForm();
            return ObjDalAdminForm.DeleteDataRow(keyvalue);
        }

        public int GetCompleteAppCount(string strSqlstatement)
        {
            DataAccessLayer.DalAdminForm ObjDalAdminForm = null;
            ObjDalAdminForm = new DataAccessLayer.DalAdminForm();
            return ObjDalAdminForm.GetCompleteAppCount(strSqlstatement);
        }

        public int InsertFormMaster()
        {
            DataAccessLayer.DalAdminForm ObjDalAdminForm = null;
            DataTable dtAdminGroup = null;
            try
            {
                ObjDalAdminForm = new DataAccessLayer.DalAdminForm();
                dtAdminGroup = new DataTable();

                DataRow dRowAdminGroup = dtAdminGroup.NewRow();

                dtAdminGroup.Columns.Add("Form_Name");
                dtAdminGroup.Columns.Add("Form_URL");
                dtAdminGroup.Columns.Add("Form_Status");

                dRowAdminGroup["Form_Name"] = this.Form_Name;
                dRowAdminGroup["Form_URL"] = this.Form_Url;
                dRowAdminGroup["Form_Status"] = this.Form_Status;
                dtAdminGroup.Rows.Add(dRowAdminGroup);


                return ObjDalAdminForm.InsertForm(dtAdminGroup);
            }
            catch (Exception Ex)
            {
                throw (Ex);
            }
            finally
            {
                ObjDalAdminForm = null;
                dtAdminGroup = null;
            }

        }

        public int UpdateFormMaster()
        {
            DataAccessLayer.DalAdminForm ObjDalAdminForm = null;
            DataTable dtAdminGroup = null;
            try
            {
                ObjDalAdminForm = new DataAccessLayer.DalAdminForm();
                dtAdminGroup = new DataTable();

                DataRow dRowAdminGroup = dtAdminGroup.NewRow();
                dtAdminGroup.Columns.Add("Form_Id");
                dtAdminGroup.Columns.Add("Form_Name");
                dtAdminGroup.Columns.Add("Form_Status");
                dtAdminGroup.Columns.Add("Form_URL");

                dRowAdminGroup["Form_Id"] = this.Form_Id;
                dRowAdminGroup["Form_Name"] = this.Form_Name;
                dRowAdminGroup["Form_Status"] = this.Form_Status;
                dRowAdminGroup["Form_URL"] = this.Form_Url;

                dtAdminGroup.Rows.Add(dRowAdminGroup);

                return ObjDalAdminForm.UpdateFormMaster(dtAdminGroup);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ObjDalAdminForm = null;
                dtAdminGroup = null;
            }

        }

    }
}
