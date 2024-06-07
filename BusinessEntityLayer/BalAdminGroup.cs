using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;

namespace BusinessEntityLayer
{
    public class BalAdminGroup
    {

        #region Private Variables
        private string _Group_Id;
        private string _Group_Name;
        private string _Group_Code;
        private string _Group_Status;
        private string _Company_Id;
        private string _Created_By;
        private string _Created_Date;
        private string _Modified_By;
        private string _Modified_Date;
        #endregion

        #region public property

        public string Group_Id
        {
            get
            {
                return _Group_Id;
            }
            set
            {
                _Group_Id = value;
            }
        }


        public string Group_Name
        {
            get
            {
                return _Group_Name;
            }
            set
            {
                _Group_Name = value;
            }
        }
        public string Group_Code
        {
            get
            {
                return _Group_Code;
            }
            set
            {
                _Group_Code = value;
            }
        }

        public string Group_Status
        {
            get
            {
                return _Group_Status;
            }
            set
            {
                _Group_Status = value;
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

        //<summary>
        //<created By>Wasim Karim</created>
        //</summary>
        //<created>5 sept 2009</created>
        //<Purpose>Bind grid Listing</Purpose>
        //public DataSet FillGridFieldGroupListing()
        //{
        //    DataAccessLayer.DalAdminGroup ObjDalAdminGroup = null;

        //    try
        //    {
        //        ObjDalAdminGroup = new DataAccessLayer.DalAdminGroup();
        //        return ObjDalAdminGroup.FillGridFieldGroupListing();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        ObjDalAdminGroup = null;

        //    }
        //}

        /// <summary>
        /// <created By>Wasim Karim</created>
        /// </summary>
        /// <created>1 sept 2009</created>
        /// <Purpose>Insert  into GroupMaster</Purpose>     
        public int Insert_GroupMaster()
        {
            DataAccessLayer.DalAdminGroup ObjDalAdminGroup = null;
            DataTable dtAdminGroup = null;
            try
            {
                ObjDalAdminGroup = new DataAccessLayer.DalAdminGroup();
                dtAdminGroup = new DataTable();

                DataRow dRowAdminGroup = dtAdminGroup.NewRow();

                dtAdminGroup.Columns.Add("Group_Name");
                dtAdminGroup.Columns.Add("Group_Code");
                dtAdminGroup.Columns.Add("Group_Status");
                dtAdminGroup.Columns.Add("Company_Id");
                dtAdminGroup.Columns.Add("Created_By");

                dRowAdminGroup["Group_Name"] = this.Group_Name;
                dRowAdminGroup["Group_Code"] = this.Group_Code;
                dRowAdminGroup["Group_Status"] = this.Group_Status;
                dRowAdminGroup["Company_Id"] = this.Company_Id;
                dRowAdminGroup["Created_By"] = this.Created_By;

                dtAdminGroup.Rows.Add(dRowAdminGroup);


                return ObjDalAdminGroup.InsertAdminGroup(dtAdminGroup);
            }
            catch (Exception Ex)
            {
                throw (Ex);
            }
            finally
            {
                ObjDalAdminGroup = null;
                dtAdminGroup = null;
            }

        }

        public int InsertMainGroup()
        {
            DataAccessLayer.DalAdminGroup ObjDalAdminGroup = null;
            DataTable dtAdminGroup = null;
            try
            {
                ObjDalAdminGroup = new DataAccessLayer.DalAdminGroup();
                dtAdminGroup = new DataTable();

                DataRow dRowAdminGroup = dtAdminGroup.NewRow();

                dtAdminGroup.Columns.Add("Group_Id");
                dtAdminGroup.Columns.Add("Company_Id");


                dRowAdminGroup["Group_Id"] = this.Group_Id;
                dRowAdminGroup["Company_Id"] = this.Company_Id;


                dtAdminGroup.Rows.Add(dRowAdminGroup);


                return ObjDalAdminGroup.InsertMainGroup(dtAdminGroup);
            }
            catch (Exception Ex)
            {
                throw (Ex);
            }
            finally
            {
                ObjDalAdminGroup = null;
                dtAdminGroup = null;
            }

        }
        public int CheckForMainGroup()
        {
            DataAccessLayer.DalAdminGroup ObjDalAdminGroup = null;
            try
            {
                ObjDalAdminGroup = new DataAccessLayer.DalAdminGroup();
                return ObjDalAdminGroup.CheckForMainGroup(this.Company_Id);
            }
            catch (Exception Ex)
            {
                throw (Ex);
            }
            finally
            {
                ObjDalAdminGroup = null;

            }

        }

        /// <summary>
        /// <created By>Wasim Karim</created>
        /// </summary>
        /// <created>1 sept 2009</created>
        /// <Purpose>Update GroupMaster</Purpose>
        public int Update_GroupMaster()
        {
            DataAccessLayer.DalAdminGroup ObjDalAdminGroup = null;
            DataTable dtAdminGroup = null;
            try
            {
                ObjDalAdminGroup = new DataAccessLayer.DalAdminGroup();
                dtAdminGroup = new DataTable();

                DataRow dRowAdminGroup = dtAdminGroup.NewRow();
                dtAdminGroup.Columns.Add("Group_Id");
                dtAdminGroup.Columns.Add("Group_Name");
                dtAdminGroup.Columns.Add("Group_Code");
                dtAdminGroup.Columns.Add("Group_Status");
                dtAdminGroup.Columns.Add("Company_Id");
                dtAdminGroup.Columns.Add("Modified_By");

                dRowAdminGroup["Group_Id"] = this.Group_Id;
                dRowAdminGroup["Group_Name"] = this.Group_Name;
                dRowAdminGroup["Group_Code"] = this.Group_Code;
                dRowAdminGroup["Group_Status"] = this.Group_Status;
                dRowAdminGroup["Company_Id"] = this.Company_Id;
                dRowAdminGroup["Modified_By"] = this.Modified_By;


                dtAdminGroup.Rows.Add(dRowAdminGroup);

                return ObjDalAdminGroup.UpdateGroupMaster(dtAdminGroup);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ObjDalAdminGroup = null;
                dtAdminGroup = null;
            }

        }

        public DataSet GetGroupInfo()
        {
            DataAccessLayer.DalAdminGroup objGroup = null;
            try
            {
                objGroup = new DataAccessLayer.DalAdminGroup();
                return objGroup.GetGroupInfo(this.Group_Id);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                objGroup = null;
            }

        }

        public DataSet GetGroupInfoFetchByCompanyId()
        {
            DataAccessLayer.DalAdminGroup objGroup = null;
            try
            {
                objGroup = new DataAccessLayer.DalAdminGroup();
                return objGroup.GetGroupInfoFetchByCompanyId(this.Company_Id);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                objGroup = null;
            }

        }
        public DataSet GetGroupInfoByCompanyId(string CurrentLogin)
        {
            DataAccessLayer.DalAdminGroup objGroup = null;
            try
            {
                objGroup = new DataAccessLayer.DalAdminGroup();
                return objGroup.GetGroupInfoByCompanyId(this.Company_Id, CurrentLogin);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                objGroup = null;
            }

        }

        public int DeleteDataRow(int keyvalue)
        {
            DataAccessLayer.DalAdminGroup ObjDalAdminGroup = null;
            ObjDalAdminGroup = new DataAccessLayer.DalAdminGroup();
            return ObjDalAdminGroup.DeleteDataRow(keyvalue);
        }
    }
}
