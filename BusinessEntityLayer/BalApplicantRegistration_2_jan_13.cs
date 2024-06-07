using System;
using System.Collections.Generic;
using System.Text; 
using System.Data;
using System.Web;  

namespace BusinessEntityLayer
{
   public class BalApplicantRegistration
    {

        #region  Automatic Properties

        public string userLoginid { get; set; }
        public string Password { get; set; }
        public int CompanyID { get; set; }
        public int grpid { get; set; }
        public string PrimaryEmail { get; set; }
        public string AlternateEmail { get; set; }

        public string SecretQuestion { get; set; }
        public string SecretQueAnswer { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string DateofBirth { get; set; }
        public string PlaceofBirth { get; set; }
        public string Sex { get; set; }
        public string MaritalStatus { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string Nationality { get; set; }
        public string CurrentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string PassportNo { get; set; }
        public string PassportType { get; set; }
        public string DateofIssue{ get; set; }
        public string DateofExpiry { get; set; }
        public string PlaceofIssue { get; set; }
        public string IssuingAuthority { get; set; }
        public string MobileNo { get; set; }
        public string UserIPAddress { get; set; }
        public string LandLinePhoneNo { get; set; }
        public string UniqueCode { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string Photo { get; set; }
        //Task1 changes : start
        public string ColorHair { get; set; }
        public string ColorEye { get; set; }
        public string IndentityMark { get; set; }
        public string Height { get; set; }
        public string InMilitary { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string EmpName { get; set; }
        public string EmpPhoneNo { get; set; }
        public string EmpLivedFrom { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string EmpCity { get; set; }
        public string EmpState { get; set; }
        public string EmpPostCode { get; set; }
        public string IntedAddress1 { get; set; }
        public string IntedAddress2 { get; set; }
        public string IntedCity { get; set; }
        public string IntedState { get; set; }
        public string IntedDistrict { get; set; }
        public string IntedPostcode { get; set; }
        public string ApplyCountryYears { get; set; }
        public string FlagSeriousDisease { get; set; }
        public string FlagCrimeRecord { get; set; }
        public string FlagDrugReport { get; set; }
        public string FlagDeported { get; set; }
        public string FlagFraudRecord { get; set; }

       //Last visited countries details 
        public string CountryCode1 { get; set; }
	    public string CityName1 { get; set; }
	    public string DepartureDate1 { get; set; }
	    public string CountryCode2 { get; set; }
	    public string CityName2 { get; set; }
    	public string DepartureDate2 { get; set; }
    	public string CountryCode3 { get; set; }
    	public string CityName3 { get; set; }
        public string DepartureDate3 { get; set; }

        //Last Lived countries details 
        public string LastLivedCountryCode1 { get; set; }
        public string LastLivedCityName1 { get; set; }
        public string LastLivedDepartureDate1 { get; set; }
        public string LastLivedCountryCode2 { get; set; }
        public string LastLivedCityName2 { get; set; }
        public string LastLivedDepartureDate2 { get; set; }
        public string LastLivedCountryCode3 { get; set; }
        public string LastLivedCityName3 { get; set; }
        public string LastLivedDepartureDate3 { get; set; }

        //Task1 changes : End

        public string AttachmentFile { get; set; }
        
        //public string Status { get; set; }
        //public string CreatedBy { get; set; }
        //public string ModifiedBy { get; set; }
         
      #endregion

        #region InsertApplicantRegister
        public int InsertApplicantRegister()
        {

            System.Web.HttpContext.Current.Trace.Warn("inside InsertApplicantRegister BAL ");  
            DataAccessLayer.DalApplicantRegist ObjDalApplicantRegist = null;
            DataTable dt = null;
            //try
            //{
                ObjDalApplicantRegist = new DataAccessLayer.DalApplicantRegist();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                //Code for adding columns in datatable.
                dt.Columns.Add("LoginID");
                dt.Columns.Add("CompanyID");
                dt.Columns.Add("GrpID");
                dt.Columns.Add("Password");
                dt.Columns.Add("PrimaryEmail");
                dt.Columns.Add("AlternateEmail");
                dt.Columns.Add("SecretQuestion");
                dt.Columns.Add("SecretQueAnswer");
                dt.Columns.Add("FirstName");
                dt.Columns.Add("MiddleName");
                dt.Columns.Add("LastName");
                dt.Columns.Add("DateOfBirth");
                dt.Columns.Add("PlaceOfBirth");
                dt.Columns.Add("Sex");
                dt.Columns.Add("MaritalStatus");
                dt.Columns.Add("FatherName");
                dt.Columns.Add("MotherName");
                dt.Columns.Add("Nationality");
                dt.Columns.Add("CurrentAddress");
                dt.Columns.Add("PermanentAddress");
                dt.Columns.Add("PassportNo");
                dt.Columns.Add("PassportType");
                dt.Columns.Add("DateOfIssue");
                dt.Columns.Add("DateOfExpiry");
                dt.Columns.Add("PlaceOfIssue");
                dt.Columns.Add("IssuingAuthority");
                dt.Columns.Add("MobileNumber");
                dt.Columns.Add("LandlinePhone");
                dt.Columns.Add("UserIPAddress");
                dt.Columns.Add("UniqueCode");
                dt.Columns.Add("Photo");
                //Task1 changes : Start
                dt.Columns.Add("ColorHair");
                dt.Columns.Add("ColorEye");
                dt.Columns.Add("IndentityMark");
                dt.Columns.Add("Height");
                dt.Columns.Add("InMilitary");
                dt.Columns.Add("FromDate");
                dt.Columns.Add("ToDate");
                dt.Columns.Add("EmpName");
                dt.Columns.Add("EmpPhoneNo");
                dt.Columns.Add("EmpLivedFrom");
                dt.Columns.Add("Address1");
                dt.Columns.Add("Address2");
                dt.Columns.Add("EmpCity");
                dt.Columns.Add("EmpState");
                dt.Columns.Add("EmpPostCode");
                dt.Columns.Add("IntedAddress1");
                dt.Columns.Add("IntedAddress2");
                dt.Columns.Add("IntedCity");
                dt.Columns.Add("IntedState");
                dt.Columns.Add("IntedDistrict");
                dt.Columns.Add("IntedPostcode");
                dt.Columns.Add("ApplyCountryYears");
                dt.Columns.Add("FlagSeriousDisease");
                dt.Columns.Add("FlagCrimeRecord");
                dt.Columns.Add("FlagDrugReport");
                dt.Columns.Add("FlagDeported");
                dt.Columns.Add("FlagFraudRecord");

                //Last Visited countried details 
                dt.Columns.Add("CountryCode1");
	            dt.Columns.Add("CityName1");
	            dt.Columns.Add("DepartureDate1");
	            dt.Columns.Add("CountryCode2");
	            dt.Columns.Add("CityName2");
        	    dt.Columns.Add("DepartureDate2");
        	    dt.Columns.Add("CountryCode3");
    	        dt.Columns.Add("CityName3");
                dt.Columns.Add("DepartureDate3");

                //Last lived countried details 
                dt.Columns.Add("LastLivedCountryCode1");
                dt.Columns.Add("LastLivedCityName1");
                dt.Columns.Add("LastLivedDepartureDate1");
                dt.Columns.Add("LastLivedCountryCode2");
                dt.Columns.Add("LastLivedCityName2");
                dt.Columns.Add("LastLivedDepartureDate2");
                dt.Columns.Add("LastLivedCountryCode3");
                dt.Columns.Add("LastLivedCityName3");
                dt.Columns.Add("LastLivedDepartureDate3");
                //Task1 changes : End

                //dt.Columns.Add("CreatedBy");
                //dt.Columns.Add("ModifiedBy");                

                dr["LoginID"] = this.userLoginid;                                   
                dr["CompanyID"] = this.CompanyID;
                dr["GrpID"] = this.grpid;
                dr["Password"] = this.Password;
                dr["PrimaryEmail"] = this.PrimaryEmail;
                dr["AlternateEmail"] = this.AlternateEmail;
                dr["SecretQuestion"] = this.SecretQuestion;
                dr["SecretQueAnswer"] = this.SecretQueAnswer;
                dr["FirstName"] = this.FirstName;
                dr["MiddleName"] = this.MiddleName;
                dr["LastName"] = this.LastName;
                dr["DateOfBirth"] = this.DateofBirth;
                dr["PlaceOfBirth"] = this.PlaceofBirth;
                dr["Sex"] = this.Sex;
                dr["MaritalStatus"] = this.MaritalStatus;
                dr["FatherName"] = this.FatherName;
                dr["MotherName"] = this.MotherName;
                dr["Nationality"] = this.Nationality;
                dr["CurrentAddress"] = this.CurrentAddress;
                dr["PermanentAddress"] = this.PermanentAddress;
                dr["PassportNo"] = this.PassportNo;
                dr["PassportType"] = this.PassportType;
                dr["DateOfIssue"] = this.DateofIssue;
                dr["DateOfExpiry"] = this.DateofExpiry;
                dr["PlaceOfIssue"] = this.PlaceofIssue;
                dr["IssuingAuthority"] = this.IssuingAuthority;
                dr["MobileNumber"] = this.MobileNo;
                dr["LandlinePhone"] = this.LandLinePhoneNo;
                dr["UserIPAddress"] = this.UserIPAddress;
                dr["UniqueCode"]= this.UniqueCode;
                dr["Photo"]=this.Photo;
                //Task1 changes : Start
                dr["ColorHair"] = this.ColorHair;
                dr["ColorEye"] = this.ColorEye;
                dr["IndentityMark"] = this.IndentityMark;
                dr["Height"] = this.Height;
                dr["InMilitary"] = this.InMilitary;
                dr["FromDate"] = this.FromDate;
                dr["ToDate"] = this.ToDate;
                dr["EmpName"] = this.EmpName ;
                dr["EmpPhoneNo"] = this.EmpPhoneNo  ;
                dr["EmpLivedFrom"] = this.EmpLivedFrom;
                dr["Address1"] = this.Address1 ;
                dr["Address2"] = this.Address2 ;
                dr["EmpCity"] = this.EmpCity ;
                dr["EmpState"] = this.EmpState ;
                dr["EmpPostCode"] = this.EmpPostCode;
                dr["IntedAddress1"] = this.IntedAddress1 ;
                dr["IntedAddress2"] = this.IntedAddress2 ;
                dr["IntedCity"] = this.IntedCity  ;
                dr["IntedState"] = this.IntedState  ;
                dr["IntedDistrict"] = this.IntedDistrict ;
                dr["IntedPostcode"] = this.IntedPostcode ;
                dr["ApplyCountryYears"] = this.ApplyCountryYears  ;
                dr["FlagSeriousDisease"] = this.FlagSeriousDisease;
                dr["FlagCrimeRecord"] = this.FlagCrimeRecord;
                dr["FlagDrugReport"] = this.FlagDrugReport;
                dr["FlagDeported"] = this.FlagDeported;
                dr["FlagFraudRecord"] = this.FlagFraudRecord;
                 
                 //insert data to last visited country
                dr["CountryCode1"] =  this.CountryCode1 ;
                dr["CityName1"] = this.CityName1 ;
                dr["DepartureDate1"] = this.DepartureDate1 ;
                dr["CountryCode2"] = this.CountryCode2 ;
                dr["CityName2"] = this.CityName2  ;
                dr["DepartureDate2"] = this.DepartureDate2 ;
                dr["CountryCode3"] = this.CountryCode3  ;
                dr["CityName3"] = this.CityName3  ;
                dr["DepartureDate3"] = this.DepartureDate3 ;

                //insert data to last lived country
                dr["LastLivedCountryCode1"] = this.LastLivedCountryCode1;
                dr["LastLivedCityName1"] = this.LastLivedCityName1;
                dr["LastLivedDepartureDate1"] = this.LastLivedDepartureDate1;
                dr["LastLivedCountryCode2"] = this.LastLivedCountryCode2;
                dr["LastLivedCityName2"] = this.LastLivedCityName2;
                dr["LastLivedDepartureDate2"] = this.LastLivedDepartureDate2;
                dr["LastLivedCountryCode3"] = this.LastLivedCountryCode3;
                dr["LastLivedCityName3"] = this.LastLivedCityName3;
                dr["LastLivedDepartureDate3"] = this.LastLivedDepartureDate3;

               //Insert data into last visited countries details 
                
                System.Web.HttpContext.Current.Trace.Warn("ddlHairColor.SelectedValue.ToString() " + this.ColorHair);
                System.Web.HttpContext.Current.Trace.Warn("ddlEyeColor.SelectedValue.ToString() " + this.ColorEye);
                System.Web.HttpContext.Current.Trace.Warn("IndentityMark " + this.IndentityMark);
                System.Web.HttpContext.Current.Trace.Warn("ddlHairColor.SelectedValue.ToString() " + this.Height); 

                //Task1 changes : End

                //dr["CreatedBy"] = this.CreatedBy;
                //dr["ModifiedBy"] = this.ModifiedBy;

                dt.Rows.Add(dr);

                return ObjDalApplicantRegist.InsertApplicantRegister(dt);
            //}
            //catch (Exception ex)
            //{
            //    throw (ex);
            //}

            //finally
            //{
            //    dt = null;
            //    ObjDalApplicantRegist = null;
            //}
        }

        #endregion

        public int EmailHandler()
        {
            int i;

            DataAccessLayer.DalApplicantRegist ObjDalApplicantRegist = null;
            ObjDalApplicantRegist = new DataAccessLayer.DalApplicantRegist();
            i = ObjDalApplicantRegist.SendMailMessage(this.PrimaryEmail, this.Subject, this.Message, this.AlternateEmail);
            return i;
        }
       
    }
}
