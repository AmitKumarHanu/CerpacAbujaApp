using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BusinessEntityLayer
{
   public class BalGuestLogin
    {
        #region  Automatic Properties

        public string Loginid { get; set; }
        public string Password { get; set; }
        public int CompanyID { get; set; }
        public int grpid { get; set; }
        public string EmailId { get; set; }       
        public string UniqueCode { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string UserIPAddress { get; set; }
        //public string Status { get; set; }
        //public string CreatedBy { get; set; }
        //public string ModifiedBy { get; set; }

        #endregion

        #region InsertGuestRegister
        public int InsertGuestRegister()
        {
            DataAccessLayer.DalGuestLogin ObjDalGuestLogin = null;
            DataTable dt = null;
            try
            {
                ObjDalGuestLogin = new DataAccessLayer.DalGuestLogin();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                //Code for adding columns in datatable.
                dt.Columns.Add("LoginID");
                dt.Columns.Add("CompanyID");
                dt.Columns.Add("GrpID");
                dt.Columns.Add("EmailId");
                dt.Columns.Add("Password");
                dt.Columns.Add("UserIPAddress");
                dt.Columns.Add("UniqueCode");
                //dt.Columns.Add("CreatedBy");
                //dt.Columns.Add("ModifiedBy");

                dr["LoginID"] = this.Loginid;
                dr["CompanyID"] = this.CompanyID;
                dr["GrpID"] = this.grpid;
                dr["Password"] = this.Password;
                dr["EmailId"] = this.EmailId;
                dr["UserIPAddress"] = this.UserIPAddress;
                dr["UniqueCode"] = this.UniqueCode;
                //dr["CreatedBy"] = this.CreatedBy;
                //dr["ModifiedBy"] = this.ModifiedBy;

                dt.Rows.Add(dr);

                return ObjDalGuestLogin.InsertGuestRegister(dt);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dt = null;
                ObjDalGuestLogin = null;
            }
        }

        #endregion

        public int EmailHandler()
        {
            int i;

            DataAccessLayer.DalGuestLogin ObjDalGuestLogin = null;
            ObjDalGuestLogin = new DataAccessLayer.DalGuestLogin();
            i = ObjDalGuestLogin.SendMailMessage(this.EmailId, this.Subject, this.Message);
            return i;
        }   
    }
}
