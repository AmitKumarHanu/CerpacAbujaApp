using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
//using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//using System.Xml.Linq;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;



namespace BusinessEntityLayer
{
    public class BalMyProfile
    {

        #region  Automatic Properties

        public string userLoginid { get; set; }
        public string Password { get; set; }
        //public int CompanyID { get; set; }
        //public int grpid { get; set; }
        public string PrimaryEmail { get; set; }
        // public string AlternateEmail { get; set; }

        public string SecretQuestion { get; set; }
        public string SecretAnswer { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string OtherName { get; set; }
        public string DateofBirth { get; set; }
        public string PlaceofBirth { get; set; }
        public string Sex { get; set; }
        public string MaritalStatus { get; set; }
        public string FatherName { get; set; }
        public string FatherLastName { get; set; }
        public string DateofBirthF { get; set; }
        //public string FatherAddress { get; set; }
        public string PassportType { get; set; }
        public string FatherNationality { get; set; }
        public string MotherName { get; set; }
        public string MotherLastName { get; set; }
        public string DateofBirthM { get; set; }
        //public string MotherAddress { get; set; }
        public string MotherNationality { get; set; }
        public string Nationality { get; set; }
        public string CurrentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string PassportOrTravelDocumentNumber { get; set; }
        //public string PassportType { get; set; }
        //public string DateofIssue{ get; set; }
        public string DateofExpiry { get; set; }
        public string PlaceofIssue { get; set; }
        public string IssuingAuthority { get; set; }
        public string ColorOfEyes { get; set; }
        public string ColorOfhair { get; set; }
        public string Height { get; set; }
        public string IndentificationMarks { get; set; }
        public string DateOfIssue { get; set; }
        public string PlaceOfIssue { get; set; }
        public string DateOfExpiry { get; set; }
        public string PlaceAndCountryOfBirthM { get; set; }
        public string PlaceAndCountryOfBirthF { get; set; }


        //public string MobileNo { get; set; }
        //public string UserIPAddress { get; set; }
        // public string LandLinePhoneNo { get; set; }
        //public string UniqueCode { get; set; }
        //public string Subject { get; set; }
        //public string Message { get; set; }
        //public string Photo { get; set; }
        //public string AttachmentFile { get; set; }
        //public string Status { get; set; }
        //public string CreatedBy { get; set; }
        //public string ModifiedBy { get; set; }

        #endregion

        #region UpdateMyProfile
        #endregion
        public int UpdateMyProfile()
        {
            DataAccessLayer.DalMyProfile ObjDalMyProfile = null;
            DataTable dt = null;
            try
            {
                ObjDalMyProfile = new DataAccessLayer.DalMyProfile();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                //Code for adding columns in datatable.
                dt.Columns.Add("LoginID");
                //dt.Columns.Add("CompanyID");
                //dt.Columns.Add("GrpID");
                //   dt.Columns.Add("Password");
                dt.Columns.Add("PrimaryEmail");
                //dt.Columns.Add("AlternateEmail");
                // dt.Columns.Add("SecretQuestion");
                //  dt.Columns.Add("SecretAnswer");
                dt.Columns.Add("FirstName");
                dt.Columns.Add("MiddleName");
                dt.Columns.Add("LastName");
                dt.Columns.Add("OtherName");
                dt.Columns.Add("DateOfBirth");
                dt.Columns.Add("PlaceOfBirth");
                dt.Columns.Add("Sex");
                dt.Columns.Add("MaritalStatus");
                dt.Columns.Add("FatherName");
                dt.Columns.Add("FatherLastName");
                dt.Columns.Add("DateofBirthF");
                dt.Columns.Add("PlaceAndCountryOfBirthF");
                dt.Columns.Add("FatherNationality");
                dt.Columns.Add("MotherName");
                dt.Columns.Add("MotherLastName");
                dt.Columns.Add("DateofBirthM");
                dt.Columns.Add("PlaceAndCountryOfBirthM");
                dt.Columns.Add("MotherNationality");
                dt.Columns.Add("Nationality");
                dt.Columns.Add("CurrentAddress");
                dt.Columns.Add("PermanentAddress");
                dt.Columns.Add("PassportOrTravelDocumentNumber");
                dt.Columns.Add("PassportType");
                dt.Columns.Add("DateOfIssue");
                dt.Columns.Add("DateOfExpiry");
                dt.Columns.Add("PlaceOfIssue");
                dt.Columns.Add("IssuingAuthority");
                dt.Columns.Add("Height");
                // dt.Columns.Add("OtherName");
                dt.Columns.Add("ColorOfEyes");
                dt.Columns.Add("ColorOfHair");
                dt.Columns.Add("IndentificationMarks");
                //dt.Columns.Add("MobileNumber");
                //dt.Columns.Add("LandlinePhone");
                //dt.Columns.Add("UserIPAddress");
                //dt.Columns.Add("UniqueCode");
                // dt.Columns.Add("Photo");
                //dt.Columns.Add("CreatedBy");
                //dt.Columns.Add("ModifiedBy");



                dr["LoginID"] = this.userLoginid;
                // dr["CompanyID"] = this.CompanyID;
                //dr["GrpID"] = this.grpid;
                //    dr["Password"] = this.Password;
                dr["PrimaryEmail"] = this.PrimaryEmail;
                //dr["AlternateEmail"] = this.AlternateEmail;
                //   dr["SecretQuestion"] = this.SecretQuestion;
                //    dr["SecretAnswer"] = this.SecretAnswer;
                dr["FirstName"] = this.FirstName;
                dr["MiddleName"] = this.MiddleName;
                dr["LastName"] = this.LastName;
                dr["OtherName"] = this.OtherName;
                dr["DateOfBirth"] = this.DateofBirth;
                dr["PlaceOfBirth"] = this.PlaceofBirth;
                dr["Sex"] = this.Sex;
                dr["MaritalStatus"] = this.MaritalStatus;
                dr["FatherName"] = this.FatherName;
                dr["FatherLastName"] = this.FatherLastName;
                dr["DateofBirthF"] = this.DateofBirthF;
                dr["PlaceAndCountryOfBirthF"] = this.PlaceAndCountryOfBirthF;
                dr["FatherNationality"] = this.FatherNationality;
                dr["MotherName"] = this.MotherName;
                dr["MotherLastName"] = this.MotherLastName;
                dr["DateofBirthM"] = this.DateofBirthM;
                dr["PlaceAndCountryOfBirthM"] = this.PlaceAndCountryOfBirthM;
                dr["MotherNationality"] = this.MotherNationality;
                dr["Nationality"] = this.Nationality;
                //dr["CurrentAddress"] = this.CurrentAddress;
                // dr["PermanentAddress"] = this.PermanentAddress;
                dr["PassportOrTravelDocumentNumber"] = this.PassportOrTravelDocumentNumber;
                dr["PassportType"] = this.PassportType;
                dr["DateOfIssue"] = this.DateOfIssue;
                dr["DateOfExpiry"] = this.DateofExpiry;
                dr["PlaceOfIssue"] = this.PlaceofIssue;
                dr["IssuingAuthority"] = this.IssuingAuthority;
                dr["Height"] = this.Height;
                // dr["OtherName"] = this.OtherName;
                dr["IndentificationMarks"] = this.IndentificationMarks;
                dr["ColorOfEyes"] = this.ColorOfEyes;
                dr["ColorOfHair"] = this.ColorOfHair;
                // dr["MobileNumber"] = this.MobileNo;
                //dr["LandlinePhone"] = this.LandLinePhoneNo;
                //dr["UserIPAddress"] = this.UserIPAddress;
                // dr["UniqueCode"]= this.UniqueCode;
                // dr["Photo"]=this.Photo;
                //dr["CreatedBy"] = this.CreatedBy;
                //dr["ModifiedBy"] = this.ModifiedBy;

                dt.Rows.Add(dr);

                return ObjDalMyProfile.UpdateMyProfile(dt);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                dt = null;
                ObjDalMyProfile = null;
            }
        }








        public string PlaceandCountryOfBirth { get; set; }

        public string DateofIssue { get; set; }

        public string ColorOfHair { get; set; }

        public string PassportOrTravelDocumentNo { get; set; }
    }
}
