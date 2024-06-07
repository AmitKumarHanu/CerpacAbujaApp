using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace BusinessEntityLayer
{
    public class BalUserMasterDetails
    {
        public string companyid { get; set; }
        public string grpid { get; set; }
        public string username { get; set; }
        public int userid { get; set; }
        public string loginid { get; set; }
        public string password { get; set; }

        public string usertype { get; set; }
        public string designation { get; set; }
        public string ZoneCode { get; set;}
        public string approvallevel { get; set; }
        public string approver { get; set; }
        public string bankperson { get; set; }
        public string borderid { get; set; }
        public string UserActiveFrom { get; set; }
        public string UserActiveTo { get; set; }
        public string DateOfBirth { get; set; }
        public string EmailId { get; set; }
        public string ContactNo { get; set; }
        public string LandlineNo { get; set; }
        public string Address { get; set; }
        public string UserStatus { get; set; }
        public int CreatedBy { get; set; }



        //public DataTable Fetch_UserDetail_by_UserName(string UserName,string Password)
        //{
        //    DataAccessLayer.DalAccountUserData ObjDalAccountUserData = null;

        //    try
        //    {
        //        ObjDalAccountUserData = new DataAccessLayer.DalAccountUserData();
        //        return ObjDalAccountUserData.Fetch_USerDetailByUserName(UserName,Password);

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        ObjDalAccountUserData = null;

        //    }
        //}

        public DataSet Fetch_UserDetail_by_UserId(int UserId)
        {
            DataAccessLayer.DalUserMasterDetails ObjDalUserData = null;

            try
            {
                ObjDalUserData = new DataAccessLayer.DalUserMasterDetails();
                return ObjDalUserData.Fetch_USerDetailByUserId(UserId);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ObjDalUserData = null;

            }
        }

        public DataTable Fetch_UserDetail_by_CompanyId(string CompanyId, string UserType)
        {
            DataAccessLayer.DalUserMasterDetails ObjDalUserData = null;

            try
            {
                ObjDalUserData = new DataAccessLayer.DalUserMasterDetails();
                return ObjDalUserData.Fetch_UserDetail_by_CompanyId(CompanyId, UserType);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ObjDalUserData = null;

            }
        }

        //public DataTable Fetch_UserDetail_by_GrpId()
        //{
        //    DataAccessLayer.DalAccountUserData ObjDalAccountUserData = null;

        //    try
        //    {
        //        ObjDalAccountUserData = new DataAccessLayer.DalAccountUserData();
        //        return ObjDalAccountUserData.Fetch_UserDetail_by_GrpId(this.grpid);

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        ObjDalAccountUserData = null;

        //    }
        //}

        ///// <author >Wasim Karim</author>
        ///// <created Date>2 sept 09</created>
        ///// <purpose> Fetch GroupMaster by CompanyId</purpose>
        ///// </summary>
        ///// <returns></returns>       
        //public DataTable Fetch_GroupDetail_by_CompanyId(string CompanyId)
        //{
        //    DataAccessLayer.DalAccountUserData ObjDalAccountUserData = null;

        //    try
        //    {
        //        ObjDalAccountUserData = new DataAccessLayer.DalAccountUserData();
        //        return ObjDalAccountUserData.Fetch_GroupDetail_by_CompanyId(CompanyId);

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        ObjDalAccountUserData = null;

        //    }
        //}

        ///// <author >Wasim Karim</author>
        ///// <created Date>3 sept 09</created>
        ///// <purpose> Fetch ModuleMaster by CompanyId</purpose>
        ///// </summary>
        ///// <returns></returns>
        //public DataTable Fetch_ModuleDetail_by_CompanyId(string CompanyId)
        //{
        //    DataAccessLayer.DalAccountUserData ObjDalAccountUserData = null;

        //    try
        //    {
        //        ObjDalAccountUserData = new DataAccessLayer.DalAccountUserData();
        // 
        // return ObjDalAccountUserData.Fetch_ModuleDetail_by_CompanyId(CompanyId);

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        ObjDalAccountUserData = null;

        //    }
        //}
        public DataTable FetchBorderList()
        {
            DataAccessLayer.DalUserMasterDetails ObjDaluser = null;
            ObjDaluser = new DataAccessLayer.DalUserMasterDetails();
            return ObjDaluser.FetchBorderList();
        }
        public DataTable FetchCountryList()
        {
            DataAccessLayer.DalUserMasterDetails ObjDalUser = null;
            ObjDalUser = new DataAccessLayer.DalUserMasterDetails();
            return ObjDalUser.FetchCountryList();
        }

        public DataTable FetchVisaTypeList()
        {
            DataAccessLayer.DalUserMasterDetails ObjDalUser = null;
            ObjDalUser = new DataAccessLayer.DalUserMasterDetails();
            return ObjDalUser.FetchVisaTypeList();
        }
        public DataTable FetchZoneDetails_ZoneCode()
        {
            DataAccessLayer.DalUserMasterDetails ObjDalUser = null;
            ObjDalUser = new DataAccessLayer.DalUserMasterDetails();
        return ObjDalUser.FetchZoneDetails_ZoneCode();
        }

        ///// <author >Ankit gupta</author>
        ///// <created Date>10th july 2008</created>
        ///// <purpose> Fetch Home page Content</purpose>
        ///// </summary>
        ///// <returns></returns>
        //public DataTable Fetch_Homepage_Content()
        //{
        //    DataAccessLayer.DalAccountUserData ObjDalAccountUserData = null;

        //    try
        //    {
        //        ObjDalAccountUserData = new DataAccessLayer.DalAccountUserData();
        //        return ObjDalAccountUserData.Fetch_HomePage_content();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        ObjDalAccountUserData = null;

        //    }
        //}

        public int Insert_UserDetail()
        {
            DataAccessLayer.DalUserMasterDetails ObjDalUserDetails = null;
            DataTable dt = null;

            try
            {
                ObjDalUserDetails = new DataAccessLayer.DalUserMasterDetails();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                dt.Columns.Add("CompanyId");
                dt.Columns.Add("loginid");
                dt.Columns.Add("Password");
                dt.Columns.Add("UserName");
                dt.Columns.Add("usertype");
                dt.Columns.Add("GrpId");
                dt.Columns.Add("DateOfBirth");
                dt.Columns.Add("EmailId");
                dt.Columns.Add("designation");
                dt.Columns.Add("ZoneCode");
                dt.Columns.Add("ContactNo");
                dt.Columns.Add("LandlineNo");
                dt.Columns.Add("Address");
                dt.Columns.Add("approver");
                dt.Columns.Add("approvallevel");
                dt.Columns.Add("bankperson");
                dt.Columns.Add("borderid");
                dt.Columns.Add("UserActiveFrom");
                dt.Columns.Add("UserActiveTo");
                dt.Columns.Add("UserStatus");
                dt.Columns.Add("CreatedBy");


                dr["CompanyId"] = this.companyid;
                dr["loginid"] = this.loginid;
                dr["Password"] = this.password;
                dr["UserName"] = this.username;
                dr["usertype"] = this.usertype;
                dr["GrpId"] = this.grpid;
                dr["DateOfBirth"] = this.DateOfBirth;
                dr["EmailId"] = this.EmailId;
                dr["designation"] = this.designation;
                dr["ZoneCode"] = this.ZoneCode;
                dr["ContactNo"] = this.ContactNo;
                dr["LandlineNo"] = this.LandlineNo;
                dr["Address"] = this.Address;
                dr["approver"] = this.approver;
                dr["approvallevel"] = this.approvallevel;
                dr["bankperson"] = this.bankperson;
                dr["borderid"] = this.borderid;
                dr["UserActiveFrom"] = this.UserActiveFrom;
                dr["UserActiveTo"] = this.UserActiveTo;
                dr["UserStatus"] = this.UserStatus;
                dr["CreatedBy"] = this.CreatedBy;

                dt.Rows.Add(dr);
                return ObjDalUserDetails.Insert_UserDetail(dt);
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public int update_userdetail()
        {
            DataAccessLayer.DalUserMasterDetails ObjDalUserDetails = null;
            DataTable dt = null;

            try
            {
                ObjDalUserDetails = new DataAccessLayer.DalUserMasterDetails();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                dt.Columns.Add("CompanyId");
                dt.Columns.Add("UserId");
                dt.Columns.Add("loginid");
               // dt.Columns.Add("Password");
                dt.Columns.Add("UserName");
                dt.Columns.Add("usertype");
                dt.Columns.Add("GrpId");
                dt.Columns.Add("DateOfBirth");
                dt.Columns.Add("EmailId");
                dt.Columns.Add("designation");
                dt.Columns.Add("ZoneCode");
                dt.Columns.Add("ContactNo");
                dt.Columns.Add("LandlineNo");
                dt.Columns.Add("Address");
                dt.Columns.Add("approver");
                dt.Columns.Add("approvallevel");
                dt.Columns.Add("bankperson");
                dt.Columns.Add("borderid");
                dt.Columns.Add("UserActiveFrom");
                dt.Columns.Add("UserActiveTo");
                dt.Columns.Add("UserStatus");
                dt.Columns.Add("CreatedBy");


                dr["CompanyId"] = this.companyid;
                dr["UserId"] = this.userid;
                dr["loginid"] = this.loginid;
               // dr["Password"] = this.password;
                dr["UserName"] = this.username;
                dr["usertype"] = this.usertype;
                dr["GrpId"] = this.grpid;
                dr["DateOfBirth"] = this.DateOfBirth;
                dr["EmailId"] = this.EmailId;
                dr["designation"] = this.designation;
                dr["ZoneCode"] = this.ZoneCode;
                dr["ContactNo"] = this.ContactNo;
                dr["LandlineNo"] = this.LandlineNo;
                dr["Address"] = this.Address;
                dr["approver"] = this.approver;
                dr["approvallevel"] = this.approvallevel;
                dr["bankperson"] = this.bankperson;
                dr["borderid"] = this.borderid;
                dr["UserActiveFrom"] = this.UserActiveFrom;
                dr["UserActiveTo"] = this.UserActiveTo;
                dr["UserStatus"] = this.UserStatus;
                dr["CreatedBy"] = this.CreatedBy;

                dt.Rows.Add(dr);
                return ObjDalUserDetails.Update_UserDetails(dt);
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public int Insert_User_Country_VisaType(DataTable dtCountryList, DataTable dtVisaTypeList)
        {
            DataAccessLayer.DalUserMasterDetails ObjDalUserDetails = null;
            ObjDalUserDetails = new DataAccessLayer.DalUserMasterDetails();
            return ObjDalUserDetails.Insert_User_Country_VisaType(dtCountryList, dtVisaTypeList);

        }

        public int Update_User_Country_VisaType(DataTable dtCountryList, DataTable dtVisaTypeList)
        {
            DataAccessLayer.DalUserMasterDetails ObjDalUserDetails = null;
            ObjDalUserDetails = new DataAccessLayer.DalUserMasterDetails();
            return ObjDalUserDetails.Update_User_Country_VisaType(dtCountryList, dtVisaTypeList, this.userid);
            // return 1;

        }






        public int DeleteDataRow(int keyvalue)
        {

            DataAccessLayer.DalUserMasterDetails ObjDalUserData = null;
            ObjDalUserData = new DataAccessLayer.DalUserMasterDetails();
            return ObjDalUserData.DeleteDataRow(keyvalue);
        }
    }
}
//public string ForGetPossword(string UserName)
//{
//    DataTable dt = null;
//    DataAccessLayer.DalAccountUserData ObjDalAccountUserData = null;
//    BaseLayer.General_function objgen = null;

//    try
//    {
//        ObjDalAccountUserData = new DataAccessLayer.DalAccountUserData();
//        dt = ObjDalAccountUserData.ForGetPossword(UserName);

//        if (dt.Rows[0][0].ToString() == "2") // Invalid User 
//        {
//            return "Invalid User Name";
//        }
//        else  //send mail and send success msg
//        {
//            objgen = new BaseLayer.General_function();
//            string MsgBody = " Dear " + dt.Rows[0]["username"].ToString();
//            MsgBody = MsgBody + "<br> Your Password :" + dt.Rows[0]["Password"].ToString();
//            if (objgen.SendMail(dt.Rows[0]["EmailId"].ToString(), dt.Rows[0]["CompanyEmailId"].ToString(), "Password", MsgBody))
//                return " your Password has been sent to your mail id";
//            else
//                return "Problem in Mail server,your Password could notsent to your mail id";

//        }

//    }
//    catch (Exception ex)
//    {
//        throw (ex);
//    }
//    finally
//    {
//        ObjDalAccountUserData = null;

//    }
//}

//public int UserMasterChangePassword()
//{
//    DataAccessLayer.DalAccountUserData ObjDalUserDetails = null;
//    DataTable dtUserDetails = null;
//    try
//    {
//        ObjDalUserDetails = new DataAccessLayer.DalAccountUserData();
//        dtUserDetails = new DataTable();

//        DataRow drUserDetails = dtUserDetails.NewRow();

//        dtUserDetails.Columns.Add("UserName");
//        dtUserDetails.Columns.Add("Password");
//        dtUserDetails.Columns.Add("NewPassword");

//        drUserDetails["UserName"] = this.username;
//        drUserDetails["Password"] = this.password;
//        //drUserDetails["NewPassword"] = this.Newpassword;

//        dtUserDetails.Rows.Add(drUserDetails);

//        return ObjDalUserDetails.UserMasterChangePassword(dtUserDetails);


//    }
//    catch (Exception ex)
//    {
//        throw (ex);
//    }

//    finally
//    {
//        dtUserDetails = null;
//        ObjDalUserDetails = null;
//    }



//}














