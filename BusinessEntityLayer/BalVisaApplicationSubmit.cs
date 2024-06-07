using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace BusinessEntityLayer
{
    public class BalVisaApplicationSubmit
    {
        #region public property

        //public int ApplicationId { get; set; }
        //public string Name { get; set; }
        public string logobrowse { get; set; }
        public string ratecurrency { get; set; }
        public string Nationality { get; set; }
        public string PassportNo { get; set; }
        public string PassportType { get; set; }
        public string Doissue { get; set; }
        public string DoExp { get; set; }
        public string Poissue { get; set; }
        public string issuingauthority { get; set; }
        public string fname { get; set; }
        public string mname { get; set; }
        public string lname { get; set; }
        public string sex { get; set; }
        public string dob { get; set; }
        public string pob { get; set; }
        public string maritalstatus { get; set; }
        public string fathername { get; set; }
        public string mothername { get; set; }
        public string spousename { get; set; }
        public string currentaddress { get; set; }
        public string permanentaddress { get; set; }
        public string mobilenumber { get; set; }
        public string landlinenumber { get; set; }
        public string primaryemail { get; set; }
        public string alternateemail { get; set; }
        public string presentoccupation { get; set; }
        public string country { get; set; }
        public string VisaType { get; set; }
        public string EntryType { get; set; }
        public string periodtype { get; set; }
        public string Duration { get; set; }
        public decimal rate { get; set; }
        public string ArivalDate { get; set; }
        public string DepDate { get; set; }
        public string burundiaddress { get; set; }
        public string psb { get; set; }
        public int severaljourney { get; set; }
        public int returnticket { get; set; }
        public string Amount { get; set; }
        public string EntryPoint { get; set; }
        public string ExitPoint { get; set; }
        public int AppliedBy { get; set; }
        public int AppliedByUserId { get; set; }
        public int CreatedBy { get; set; }
        public int Status { get; set; }
        public int ApplicationID { get; set; }

        public string EmployerName { get; set; }
        public string JobDesc { get; set; }
        public string OcuPossition { get; set; }

        public string MoneyForTravellUSD { get; set; }
        public string ModeOfTravel { get; set; }
        public string IntededDuration { get; set; }

        public string flagPrevApplied { get; set; }
        public string flagPrevVisit { get; set; }
        public string flagVisaGranted { get; set; }
        public string PrevAppliedVisaPlace { get; set; }
        public string PrevVisitReason { get; set; }
        public string PrevVisaRejReason { get; set; }

        public string PreVisit1FromDate { get; set; }
        public string PreVisit1ToDate { get; set; }
        public string PreVisit1Addr1 { get; set; }
        public string PreVisit1Addr2 { get; set; }
        public string PreVisit1City { get; set; }
        public string PreVisit1State { get; set; }
        public string PreVisit1District { get; set; }
        public string PreVisit1Postcode { get; set; }

        public string PreVisit2FromDate { get; set; }
        public string PreVisit2ToDate { get; set; }
        public string PreVisit2Addr1 { get; set; }
        public string PreVisit2Addr2 { get; set; }
        public string PreVisit2City { get; set; }
        public string PreVisit2State { get; set; }
        public string PreVisit2District { get; set; }
        public string PreVisit2Postcode { get; set; }

        public string PreVisit3FromDate { get; set; }
        public string PreVisit3ToDate { get; set; }
        public string PreVisit3Addr1 { get; set; }
        public string PreVisit3Addr2 { get; set; }
        public string PreVisit3City { get; set; }
        public string PreVisit3State { get; set; }
        public string PreVisit3District { get; set; }
        public string PreVisit3Postcode { get; set; }

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

        public string CountryCode1 { get; set; }
        public string CityName1 { get; set; }
        public string DepartureDate1 { get; set; }
        public string CountryCode2 { get; set; }
        public string CityName2 { get; set; }
        public string DepartureDate2 { get; set; }
        public string CountryCode3 { get; set; }
        public string CityName3 { get; set; }
        public string DepartureDate3 { get; set; }

        public string LastLivedCountryCode1 { get; set; }
        public string LastLivedCityName1 { get; set; }
        public string LastLivedDepartureDate1 { get; set; }
        public string LastLivedCountryCode2 { get; set; }
        public string LastLivedCityName2 { get; set; }
        public string LastLivedDepartureDate2 { get; set; }
        public string LastLivedCountryCode3 { get; set; }
        public string LastLivedCityName3 { get; set; }
        public string LastLivedDepartureDate3 { get; set; }

        public string flagFastTrack { get; set; }

        public string OtherName { get; set; }

        public string FatherLastName { get; set; }
        public string FatherDateOfBirth { get; set; }
        public string FatherAddress { get; set; }
        public string FatherNationality { get; set; }

        public string MotherLastName { get; set; }
        public string MotherDateOfBirth { get; set; }
        public string MotherAddress { get; set; }
        public string MotherNationality { get; set; }

        public string OldPassport { get; set; }
        public string OldPaasportIssueDate { get; set; }
        public string PlaceIssueOldPassport { get; set; }

        public string currAddress2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string Postcode { get; set; }
        public string CurrentCountry { get; set; }
        public string LivedInCurrentAdd { get; set; }

        public string PerAddres2 { get; set; }
        public string PerCity { get; set; }
        public string PerState { get; set; }
        public string PerPostcode { get; set; }
        public string PerDistrict { get; set; }
        public string PerCountry { get; set; }

        public string CurrentLocation { get; set; }

        public string flagOtherNationality { get; set; }
        public string OtherNationality { get; set; }

        public string DateRejected { get; set; }
        public string LastRejectedVisaType { get; set; }
        public string flagRejeAppeal { get; set; }
        public string RejectedAppDiffer { get; set; }

        public string flagRefusedAnyCountry { get; set; }
        public string RefusedAnyCountry { get; set; }

        public string flagRefuseEntryOnArrival { get; set; }
        public string RefusedVisaOnArrivalPlace { get; set; }
        public string RefusedVisaOnArrivalDate { get; set; }
        public string flagRefusedVisArriAppeal { get; set; }
        public string RefusedVisArriAppOutcome { get; set; }
        public string RefusedVisaOnArrivalReason { get; set; }

        public string Disease { get; set; }

        public string CrimeRecord { get; set; }
        public string ConvictionDate { get; set; }
        public string ConvictedPlace { get; set; }
        public string Sentence { get; set; }

        public string flagConvictionInOtherCountry { get; set; }
        public string ConvictionInOtherCountry { get; set; }
        public string DrugReport { get; set; }

        public string DeportedNoticeDate { get; set; }
        public string DeportedNoticeType { get; set; }
        public string DeportedLeave { get; set; }
        public string DeportedAppealeddetails { get; set; }

        public string flagDeportedOtherCountry { get; set; }
        public string DeportedOtherCountry { get; set; }

        public string FraudRecord { get; set; }
        public string flagComplete { get; set; }
        public string flagFreshPassport { get; set; }
        public string flagCuurContactDetails { get; set; }
        public string EmbassyId { get; set; }
        public string flagInMillitary { get; set; }
        public string flagEmployement { get; set; }
        public string flagEmplDt { get; set; }
        public string flagLastVisit { get; set; }
        public string flagLastVisitCountries { get; set; }
        public string flagLastLived { get; set; }

        #endregion

        public int GetVisaAppsubmit()
        {

            DataAccessLayer.DalVisaApplicationSubmit objSubmit = null;

            DataTable dt = null;
            //try
            //{
            objSubmit = new DataAccessLayer.DalVisaApplicationSubmit();
            dt = new DataTable();

            DataRow dr = dt.NewRow();

            //dt.Columns.Add("Name");
            dt.Columns.Add("ratecurrency");
            dt.Columns.Add("logobrowser");
            dt.Columns.Add("Nationality");
            dt.Columns.Add("PassportNo");
            dt.Columns.Add("PassportType");
            dt.Columns.Add("Doissue");
            dt.Columns.Add("DoExp");
            dt.Columns.Add("Poissue");
            dt.Columns.Add("issuingauthority");
            dt.Columns.Add("fname");
            dt.Columns.Add("mname");
            dt.Columns.Add("lname");
            dt.Columns.Add("sex");
            dt.Columns.Add("dob");
            dt.Columns.Add("pob");
            dt.Columns.Add("maritalstatus");
            dt.Columns.Add("fathername");
            dt.Columns.Add("mothername");
            dt.Columns.Add("spousename");
            dt.Columns.Add("currentaddress");
            dt.Columns.Add("permanentaddress");
            dt.Columns.Add("mobilenumber");
            dt.Columns.Add("landlinenumber");
            dt.Columns.Add("primaryemail");
            dt.Columns.Add("alternateemail");
            dt.Columns.Add("presentoccupation");
            dt.Columns.Add("country");
            dt.Columns.Add("VisaType");
            dt.Columns.Add("EntryType");
            dt.Columns.Add("periodtype");
            dt.Columns.Add("Duration");
            dt.Columns.Add("rate");
            dt.Columns.Add("ArivalDate");
            dt.Columns.Add("DepDate");
            dt.Columns.Add("burundiaddress");
            dt.Columns.Add("psb");
            dt.Columns.Add("severaljourney");
            dt.Columns.Add("returnticket");
            dt.Columns.Add("EntryPoint");
            dt.Columns.Add("ExitPoint");
            dt.Columns.Add("AppliedBy");
            dt.Columns.Add("AppliedByUserId");
            dt.Columns.Add("CreatedBy");
            dt.Columns.Add("Status");

            dt.Columns.Add("EmployerName");
            dt.Columns.Add("JobDesc");
            dt.Columns.Add("OcuPossition");

            dt.Columns.Add("MoneyForTravellUSD");
            dt.Columns.Add("ModeOfTravel");
            dt.Columns.Add("IntededDuration");

            dt.Columns.Add("flagPrevApplied");
            dt.Columns.Add("flagPrevVisit");
            dt.Columns.Add("flagVisaGranted");
            dt.Columns.Add("PrevAppliedVisaPlace");
            dt.Columns.Add("PrevVisitReason");
            dt.Columns.Add("PrevVisaRejReason");

            dt.Columns.Add("PreVisit1FromDate");
            dt.Columns.Add("PreVisit1ToDate");
            dt.Columns.Add("PreVisit1Addr1");
            dt.Columns.Add("PreVisit1Addr2");
            dt.Columns.Add("PreVisit1City");
            dt.Columns.Add("PreVisit1State");
            dt.Columns.Add("PreVisit1District");
            dt.Columns.Add("PreVisit1Postcode");

            dt.Columns.Add("PreVisit2FromDate");
            dt.Columns.Add("PreVisit2ToDate");
            dt.Columns.Add("PreVisit2Addr1");
            dt.Columns.Add("PreVisit2Addr2");
            dt.Columns.Add("PreVisit2City");
            dt.Columns.Add("PreVisit2State");
            dt.Columns.Add("PreVisit2District");
            dt.Columns.Add("PreVisit2Postcode");

            dt.Columns.Add("PreVisit3FromDate");
            dt.Columns.Add("PreVisit3ToDate");
            dt.Columns.Add("PreVisit3Addr1");
            dt.Columns.Add("PreVisit3Addr2");
            dt.Columns.Add("PreVisit3City");
            dt.Columns.Add("PreVisit3State");
            dt.Columns.Add("PreVisit3District");
            dt.Columns.Add("PreVisit3Postcode");

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

            dt.Columns.Add("CountryCode1");
            dt.Columns.Add("CityName1");
            dt.Columns.Add("DepartureDate1");
            dt.Columns.Add("CountryCode2");
            dt.Columns.Add("CityName2");
            dt.Columns.Add("DepartureDate2");
            dt.Columns.Add("CountryCode3");
            dt.Columns.Add("CityName3");
            dt.Columns.Add("DepartureDate3");

            dt.Columns.Add("LastLivedCountryCode1");
            dt.Columns.Add("LastLivedCityName1");
            dt.Columns.Add("LastLivedDepartureDate1");
            dt.Columns.Add("LastLivedCountryCode2");
            dt.Columns.Add("LastLivedCityName2");
            dt.Columns.Add("LastLivedDepartureDate2");
            dt.Columns.Add("LastLivedCountryCode3");
            dt.Columns.Add("LastLivedCityName3");
            dt.Columns.Add("LastLivedDepartureDate3");

            dt.Columns.Add("flagFastTrack");

            dt.Columns.Add("OtherName");

            dt.Columns.Add("FatherLastName");
            dt.Columns.Add("FatherDateOfBirth");
            dt.Columns.Add("FatherAddress");
            dt.Columns.Add("FatherNationality");

            dt.Columns.Add("MotherLastName");
            dt.Columns.Add("MotherDateOfBirth");
            dt.Columns.Add("MotherAddress");
            dt.Columns.Add("MotherNationality");

            dt.Columns.Add("OldPassport");
            dt.Columns.Add("OldPaasportIssueDate");
            dt.Columns.Add("PlaceIssueOldPassport");

            dt.Columns.Add("currAddress2");
            dt.Columns.Add("City");
            dt.Columns.Add("State");
            dt.Columns.Add("District");
            dt.Columns.Add("Postcode");
            dt.Columns.Add("CurrentCountry");
            dt.Columns.Add("LivedInCurrentAdd");

            dt.Columns.Add("PerAddres2");
            dt.Columns.Add("PerCity");
            dt.Columns.Add("PerState");
            dt.Columns.Add("PerPostcode");
            dt.Columns.Add("PerDistrict");
            dt.Columns.Add("PerCountry");

            dt.Columns.Add("CurrentLocation");

            dt.Columns.Add("flagOtherNationality");
            dt.Columns.Add("OtherNationality");

            dt.Columns.Add("DateRejected");
            dt.Columns.Add("LastRejectedVisaType");
            dt.Columns.Add("flagRejeAppeal");
            dt.Columns.Add("RejectedAppDiffer");

            dt.Columns.Add("flagRefusedAnyCountry");
            dt.Columns.Add("RefusedAnyCountry");

            dt.Columns.Add("flagRefuseEntryOnArrival");
            dt.Columns.Add("RefusedVisaOnArrivalPlace");
            dt.Columns.Add("RefusedVisaOnArrivalDate");
            dt.Columns.Add("flagRefusedVisArriAppeal");
            dt.Columns.Add("RefusedVisArriAppOutcome");
            dt.Columns.Add("RefusedVisaOnArrivalReason");

            dt.Columns.Add("Disease");

            dt.Columns.Add("CrimeRecord");
            dt.Columns.Add("ConvictionDate");
            dt.Columns.Add("ConvictedPlace");
            dt.Columns.Add("Sentence");

            dt.Columns.Add("flagConvictionInOtherCountry");
            dt.Columns.Add("ConvictionInOtherCountry");
            dt.Columns.Add("DrugReport");

            dt.Columns.Add("DeportedNoticeDate");
            dt.Columns.Add("DeportedNoticeType");
            dt.Columns.Add("DeportedLeave");
            dt.Columns.Add("DeportedAppealeddetails");

            dt.Columns.Add("flagDeportedOtherCountry");
            dt.Columns.Add("DeportedOtherCountry");

            dt.Columns.Add("FraudRecord");
            dt.Columns.Add("flagComplete");
            dt.Columns.Add("flagFreshPassport");
            dt.Columns.Add("flagCuurContactDetails");
            dt.Columns.Add("EmbassyId");
            dt.Columns.Add("flagInMillitary");
            dt.Columns.Add("flagEmployement");
            dt.Columns.Add("flagEmplDt");
            dt.Columns.Add("flagLastVisit");
            dt.Columns.Add("flagLastVisitCountries");
            dt.Columns.Add("flagLastLived");

            //dr["Name"] = this.Name;
            dr["ratecurrency"] = this.ratecurrency;
            dr["logobrowser"] = this.logobrowse;
            dr["Nationality"] = this.Nationality;
            dr["PassportNo"] = this.PassportNo;
            dr["PassportType"] = this.PassportType;
            dr["Doissue"] = this.Doissue;
            dr["DoExp"] = this.DoExp;
            dr["Poissue"] = this.Poissue;
            dr["issuingauthority"] = this.issuingauthority;
            dr["fname"] = this.fname;
            dr["mname"] = this.mname;
            dr["lname"] = this.lname;
            dr["sex"] = this.sex;
            dr["dob"] = this.dob;
            dr["pob"] = this.pob;
            dr["maritalstatus"] = this.maritalstatus;
            dr["fathername"] = this.fathername;
            dr["mothername"] = this.mothername;
            dr["spousename"] = this.spousename;
            dr["currentaddress"] = this.currentaddress;
            dr["permanentaddress"] = this.permanentaddress;
            dr["mobilenumber"] = this.mobilenumber;
            dr["landlinenumber"] = this.landlinenumber;
            dr["primaryemail"] = this.primaryemail;
            dr["alternateemail"] = this.alternateemail;
            dr["presentoccupation"] = this.presentoccupation;
            dr["country"] = this.country;
            dr["VisaType"] = this.VisaType;
            dr["EntryType"] = this.EntryType;
            dr["periodtype"] = this.periodtype;
            dr["Duration"] = this.Duration;
            dr["rate"] = this.rate;
            dr["ArivalDate"] = this.ArivalDate;
            dr["DepDate"] = this.DepDate;
            dr["burundiaddress"] = this.burundiaddress;
            dr["psb"] = this.psb;
            dr["severaljourney"] = this.severaljourney;
            dr["returnticket"] = this.returnticket;
            dr["EntryPoint"] = this.EntryPoint;
            dr["ExitPoint"] = this.ExitPoint;
            dr["AppliedBy"] = this.AppliedBy;
            dr["AppliedByUserId"] = this.AppliedByUserId;
            dr["CreatedBy"] = this.CreatedBy;
            dr["Status"] = this.Status;

            dr["EmployerName"] = this.EmployerName;
            dr["JobDesc"] = this.JobDesc;
            dr["OcuPossition"] = this.OcuPossition;

            dr["MoneyForTravellUSD"] = this.MoneyForTravellUSD;
            dr["ModeOfTravel"] = this.ModeOfTravel;
            dr["IntededDuration"] = this.IntededDuration;

            dr["flagPrevApplied"] = this.flagPrevApplied;
            dr["flagPrevVisit"] = this.flagPrevVisit;
            dr["flagVisaGranted"] = this.flagVisaGranted;
            dr["PrevAppliedVisaPlace"] = this.PrevAppliedVisaPlace;
            dr["PrevVisitReason"] = this.PrevVisitReason;
            dr["PrevVisaRejReason"] = this.PrevVisaRejReason;

            dr["PreVisit1FromDate"] = this.PreVisit1FromDate;
            dr["PreVisit1ToDate"] = this.PreVisit1ToDate;
            dr["PreVisit1Addr1"] = this.PreVisit1Addr1;
            dr["PreVisit1Addr2"] = this.PreVisit1Addr2;
            dr["PreVisit1City"] = this.PreVisit1City;
            dr["PreVisit1State"] = this.PreVisit1State;
            dr["PreVisit1District"] = this.PreVisit1District;
            dr["PreVisit1Postcode"] = this.PreVisit1Postcode;

            dr["PreVisit2FromDate"] = this.PreVisit2FromDate;
            dr["PreVisit2ToDate"] = this.PreVisit2ToDate;
            dr["PreVisit2Addr1"] = this.PreVisit2Addr1;
            dr["PreVisit2Addr2"] = this.PreVisit2Addr2;
            dr["PreVisit2City"] = this.PreVisit2City;
            dr["PreVisit2State"] = this.PreVisit2State;
            dr["PreVisit2District"] = this.PreVisit2District;
            dr["PreVisit2Postcode"] = this.PreVisit2Postcode;

            dr["PreVisit3FromDate"] = this.PreVisit3FromDate;
            dr["PreVisit3ToDate"] = this.PreVisit3ToDate;
            dr["PreVisit3Addr1"] = this.PreVisit3Addr1;
            dr["PreVisit3Addr2"] = this.PreVisit3Addr2;
            dr["PreVisit3City"] = this.PreVisit3City;
            dr["PreVisit3State"] = this.PreVisit3State;
            dr["PreVisit3District"] = this.PreVisit3District;
            dr["PreVisit3Postcode"] = this.PreVisit3Postcode;

            dr["ColorHair"] = this.ColorHair;
            dr["ColorEye"] = this.ColorEye;
            dr["IndentityMark"] = this.IndentityMark;
            dr["Height"] = this.Height;

            dr["InMilitary"] = this.InMilitary;
            dr["FromDate"] = this.FromDate;
            dr["ToDate"] = this.ToDate;

            dr["EmpName"] = this.EmpName;
            dr["EmpPhoneNo"] = this.EmpPhoneNo;
            dr["EmpLivedFrom"] = this.EmpLivedFrom;
            dr["Address1"] = this.Address1;
            dr["Address2"] = this.Address2;
            dr["EmpCity"] = this.EmpCity;
            dr["EmpState"] = this.EmpState;
            dr["EmpPostCode"] = this.EmpPostCode;

            dr["IntedAddress1"] = this.IntedAddress1;
            dr["IntedAddress2"] = this.IntedAddress2;
            dr["IntedCity"] = this.IntedCity;
            dr["IntedState"] = this.IntedState;
            dr["IntedDistrict"] = this.IntedDistrict;
            dr["IntedPostcode"] = this.IntedPostcode;

            dr["ApplyCountryYears"] = this.ApplyCountryYears;
            dr["FlagSeriousDisease"] = this.FlagSeriousDisease;
            dr["FlagCrimeRecord"] = this.FlagCrimeRecord;
            dr["FlagDrugReport"] = this.FlagDrugReport;
            dr["FlagDeported"] = this.FlagDeported;
            dr["FlagFraudRecord"] = this.FlagFraudRecord;

            dr["CountryCode1"] = this.CountryCode1;
            dr["CityName1"] = this.CityName1;
            dr["DepartureDate1"] = this.DepartureDate1;
            dr["CountryCode2"] = this.CountryCode2;
            dr["CityName2"] = this.CityName2;
            dr["DepartureDate2"] = this.DepartureDate2;
            dr["CountryCode3"] = this.CountryCode3;
            dr["CityName3"] = this.CityName3;
            dr["DepartureDate3"] = this.DepartureDate3;

            dr["LastLivedCountryCode1"] = this.LastLivedCountryCode1;
            dr["LastLivedCityName1"] = this.LastLivedCityName1;
            dr["LastLivedDepartureDate1"] = this.LastLivedDepartureDate1;
            dr["LastLivedCountryCode2"] = this.LastLivedCountryCode2;
            dr["LastLivedCityName2"] = this.LastLivedCityName2;
            dr["LastLivedDepartureDate2"] = this.LastLivedDepartureDate2;
            dr["LastLivedCountryCode3"] = this.LastLivedCountryCode3;
            dr["LastLivedCityName3"] = this.LastLivedCityName3;
            dr["LastLivedDepartureDate3"] = this.LastLivedDepartureDate3;

            dr["flagFastTrack"] = this.flagFastTrack;

            dr["OtherName"] = this.OtherName;

            dr["FatherLastName"] = this.FatherLastName;
            dr["FatherDateOfBirth"] = this.FatherDateOfBirth;
            dr["FatherAddress"] = this.FatherAddress;
            dr["FatherNationality"] = this.FatherNationality;

            dr["MotherLastName"] = this.MotherLastName;
            dr["MotherDateOfBirth"] = this.MotherDateOfBirth;
            dr["MotherAddress"] = this.MotherAddress;
            dr["MotherNationality"] = this.MotherNationality;

            dr["OldPassport"] = this.OldPassport;
            dr["OldPaasportIssueDate"] = this.OldPaasportIssueDate;
            dr["PlaceIssueOldPassport"] = this.PlaceIssueOldPassport;

            dr["currAddress2"] = this.currAddress2;
            dr["City"] = this.City;
            dr["State"] = this.State;
            dr["District"] = this.District;
            dr["Postcode"] = this.Postcode;
            dr["CurrentCountry"] = this.CurrentCountry;
            dr["LivedInCurrentAdd"] = this.LivedInCurrentAdd;

            dr["PerAddres2"] = this.PerAddres2;
            dr["PerCity"] = this.PerCity;
            dr["PerState"] = this.PerState;
            dr["PerPostcode"] = this.PerPostcode;
            dr["PerDistrict"] = this.PerDistrict;
            dr["PerCountry"] = this.PerCountry;

            dr["CurrentLocation"] = this.CurrentLocation;

            dr["flagOtherNationality"] = this.flagOtherNationality;
            dr["OtherNationality"] = this.OtherNationality;

            dr["DateRejected"] = this.DateRejected;
            dr["LastRejectedVisaType"] = this.LastRejectedVisaType;
            dr["flagRejeAppeal"] = this.flagRejeAppeal;
            dr["RejectedAppDiffer"] = this.RejectedAppDiffer;

            dr["flagRefusedAnyCountry"] = this.flagRefusedAnyCountry;
            dr["RefusedAnyCountry"] = this.RefusedAnyCountry;

            dr["flagRefuseEntryOnArrival"] = this.flagRefuseEntryOnArrival;
            dr["RefusedVisaOnArrivalPlace"] = this.RefusedVisaOnArrivalPlace;
            dr["RefusedVisaOnArrivalDate"] = this.RefusedVisaOnArrivalDate;
            dr["flagRefusedVisArriAppeal"] = this.flagRefusedVisArriAppeal;
            dr["RefusedVisArriAppOutcome"] = this.RefusedVisArriAppOutcome;
            dr["RefusedVisaOnArrivalReason"] = this.RefusedVisaOnArrivalReason;

            dr["Disease"] = this.Disease;

            dr["CrimeRecord"] = this.CrimeRecord;
            dr["ConvictionDate"] = this.ConvictionDate;
            dr["ConvictedPlace"] = this.ConvictedPlace;
            dr["Sentence"] = this.Sentence;

            dr["flagConvictionInOtherCountry"] = this.flagConvictionInOtherCountry;
            dr["ConvictionInOtherCountry"] = this.ConvictionInOtherCountry;
            dr["DrugReport"] = this.DrugReport;

            dr["DeportedNoticeDate"] = this.DeportedNoticeDate;
            dr["DeportedNoticeType"] = this.DeportedNoticeType;
            dr["DeportedLeave"] = this.DeportedLeave;
            dr["DeportedAppealeddetails"] = this.DeportedAppealeddetails;

            dr["flagDeportedOtherCountry"] = this.flagDeportedOtherCountry;
            dr["DeportedOtherCountry"] = this.DeportedOtherCountry;

            dr["FraudRecord"] = this.FraudRecord;
            dr["flagComplete"] = this.flagComplete;
            dr["flagFreshPassport"] = this.flagFreshPassport;
            dr["flagCuurContactDetails"] = this.flagCuurContactDetails;
            dr["EmbassyId"] = this.EmbassyId;
            dr["flagInMillitary"] = this.flagInMillitary;
            dr["flagEmployement"] = this.flagEmployement;
            dr["flagEmplDt"] = this.flagEmplDt;
            dr["flagLastVisit"] = this.flagLastVisit;
            dr["flagLastVisitCountries"] = this.flagLastVisitCountries;
            dr["flagLastLived"] = this.flagLastLived;

            dt.Rows.Add(dr);

            return objSubmit.GetVisaAppsubmit(dt);

            //}
            //catch (Exception e)
            //{
            //    throw (e);
            //}
            //finally
            //{
            //    objSubmit = null;
            //}

        }

        public DataSet GetVisaAppDetails(string ApplicationID)
        {
            DataAccessLayer.DalVisaApplicationSubmit ObjDalAppDetails = null;

            try
            {
                ObjDalAppDetails = new DataAccessLayer.DalVisaApplicationSubmit();
                return ObjDalAppDetails.GetVisaAppDetails(ApplicationID);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ObjDalAppDetails = null;

            }
        }

        public DataTable GetVisaApplicationInfo4Update(string ApplicationID)
        {
            DataAccessLayer.DalVisaApplicationSubmit ObjDalAppDetails = null;

            try
            {
                ObjDalAppDetails = new DataAccessLayer.DalVisaApplicationSubmit();
                return ObjDalAppDetails.GetVisaApplicationInfo4Update(ApplicationID);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ObjDalAppDetails = null;

            }
        }


        public int UpdateVisaApplication()
        {

            DataAccessLayer.DalVisaApplicationSubmit objSubmit = null;

            DataTable dt = null;
            try
            {
                objSubmit = new DataAccessLayer.DalVisaApplicationSubmit();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                //dt.Columns.Add("Name");
                dt.Columns.Add("ratecurrency");
                dt.Columns.Add("logobrowser");
                dt.Columns.Add("Nationality");
                dt.Columns.Add("PassportNo");
                dt.Columns.Add("PassportType");
                dt.Columns.Add("Doissue");
                dt.Columns.Add("DoExp");
                dt.Columns.Add("Poissue");
                dt.Columns.Add("issuingauthority");
                dt.Columns.Add("fname");
                dt.Columns.Add("mname");
                dt.Columns.Add("lname");
                dt.Columns.Add("sex");
                dt.Columns.Add("dob");
                dt.Columns.Add("pob");
                dt.Columns.Add("maritalstatus");
                dt.Columns.Add("fathername");
                dt.Columns.Add("mothername");
                dt.Columns.Add("spousename");
                dt.Columns.Add("currentaddress");
                dt.Columns.Add("permanentaddress");
                dt.Columns.Add("mobilenumber");
                dt.Columns.Add("landlinenumber");
                dt.Columns.Add("primaryemail");
                dt.Columns.Add("alternateemail");
                dt.Columns.Add("presentoccupation");
                dt.Columns.Add("country");
                dt.Columns.Add("VisaType");
                dt.Columns.Add("EntryType");
                dt.Columns.Add("periodtype");
                dt.Columns.Add("Duration");
                dt.Columns.Add("rate");
                dt.Columns.Add("ArivalDate");
                dt.Columns.Add("DepDate");
                dt.Columns.Add("burundiaddress");
                dt.Columns.Add("psb");
                dt.Columns.Add("severaljourney");
                dt.Columns.Add("returnticket");
                dt.Columns.Add("EntryPoint");
                dt.Columns.Add("ExitPoint");
                dt.Columns.Add("AppliedBy");
                dt.Columns.Add("AppliedByUserId");
                dt.Columns.Add("CreatedBy");
                dt.Columns.Add("Status");
                dt.Columns.Add("ApplicationID");
                dt.Columns.Add("EmployerName");
                dt.Columns.Add("JobDesc");
                dt.Columns.Add("OcuPossition");

                dt.Columns.Add("MoneyForTravellUSD");
                dt.Columns.Add("ModeOfTravel");
                dt.Columns.Add("IntededDuration");

                dt.Columns.Add("flagPrevApplied");
                dt.Columns.Add("flagPrevVisit");
                dt.Columns.Add("flagVisaGranted");
                dt.Columns.Add("PrevAppliedVisaPlace");
                dt.Columns.Add("PrevVisitReason");
                dt.Columns.Add("PrevVisaRejReason");

                dt.Columns.Add("PreVisit1FromDate");
                dt.Columns.Add("PreVisit1ToDate");
                dt.Columns.Add("PreVisit1Addr1");
                dt.Columns.Add("PreVisit1Addr2");
                dt.Columns.Add("PreVisit1City");
                dt.Columns.Add("PreVisit1State");
                dt.Columns.Add("PreVisit1District");
                dt.Columns.Add("PreVisit1Postcode");

                dt.Columns.Add("PreVisit2FromDate");
                dt.Columns.Add("PreVisit2ToDate");
                dt.Columns.Add("PreVisit2Addr1");
                dt.Columns.Add("PreVisit2Addr2");
                dt.Columns.Add("PreVisit2City");
                dt.Columns.Add("PreVisit2State");
                dt.Columns.Add("PreVisit2District");
                dt.Columns.Add("PreVisit2Postcode");

                dt.Columns.Add("PreVisit3FromDate");
                dt.Columns.Add("PreVisit3ToDate");
                dt.Columns.Add("PreVisit3Addr1");
                dt.Columns.Add("PreVisit3Addr2");
                dt.Columns.Add("PreVisit3City");
                dt.Columns.Add("PreVisit3State");
                dt.Columns.Add("PreVisit3District");
                dt.Columns.Add("PreVisit3Postcode");

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

                dt.Columns.Add("CountryCode1");
                dt.Columns.Add("CityName1");
                dt.Columns.Add("DepartureDate1");
                dt.Columns.Add("CountryCode2");
                dt.Columns.Add("CityName2");
                dt.Columns.Add("DepartureDate2");
                dt.Columns.Add("CountryCode3");
                dt.Columns.Add("CityName3");
                dt.Columns.Add("DepartureDate3");

                dt.Columns.Add("LastLivedCountryCode1");
                dt.Columns.Add("LastLivedCityName1");
                dt.Columns.Add("LastLivedDepartureDate1");
                dt.Columns.Add("LastLivedCountryCode2");
                dt.Columns.Add("LastLivedCityName2");
                dt.Columns.Add("LastLivedDepartureDate2");
                dt.Columns.Add("LastLivedCountryCode3");
                dt.Columns.Add("LastLivedCityName3");
                dt.Columns.Add("LastLivedDepartureDate3");

                dt.Columns.Add("flagFastTrack");

                dt.Columns.Add("OtherName");

                dt.Columns.Add("FatherLastName");
                dt.Columns.Add("FatherDateOfBirth");
                dt.Columns.Add("FatherAddress");
                dt.Columns.Add("FatherNationality");

                dt.Columns.Add("MotherLastName");
                dt.Columns.Add("MotherDateOfBirth");
                dt.Columns.Add("MotherAddress");
                dt.Columns.Add("MotherNationality");

                dt.Columns.Add("OldPassport");
                dt.Columns.Add("OldPaasportIssueDate");
                dt.Columns.Add("PlaceIssueOldPassport");

                dt.Columns.Add("currAddress2");
                dt.Columns.Add("City");
                dt.Columns.Add("State");
                dt.Columns.Add("District");
                dt.Columns.Add("Postcode");
                dt.Columns.Add("CurrentCountry");
                dt.Columns.Add("LivedInCurrentAdd");

                dt.Columns.Add("PerAddres2");
                dt.Columns.Add("PerCity");
                dt.Columns.Add("PerState");
                dt.Columns.Add("PerPostcode");
                dt.Columns.Add("PerDistrict");
                dt.Columns.Add("PerCountry");

                dt.Columns.Add("CurrentLocation");

                dt.Columns.Add("flagOtherNationality");
                dt.Columns.Add("OtherNationality");

                dt.Columns.Add("DateRejected");
                dt.Columns.Add("LastRejectedVisaType");
                dt.Columns.Add("flagRejeAppeal");
                dt.Columns.Add("RejectedAppDiffer");

                dt.Columns.Add("flagRefusedAnyCountry");
                dt.Columns.Add("RefusedAnyCountry");

                dt.Columns.Add("flagRefuseEntryOnArrival");
                dt.Columns.Add("RefusedVisaOnArrivalPlace");
                dt.Columns.Add("RefusedVisaOnArrivalDate");
                dt.Columns.Add("flagRefusedVisArriAppeal");
                dt.Columns.Add("RefusedVisArriAppOutcome");
                dt.Columns.Add("RefusedVisaOnArrivalReason");

                dt.Columns.Add("Disease");

                dt.Columns.Add("CrimeRecord");
                dt.Columns.Add("ConvictionDate");
                dt.Columns.Add("ConvictedPlace");
                dt.Columns.Add("Sentence");

                dt.Columns.Add("flagConvictionInOtherCountry");
                dt.Columns.Add("ConvictionInOtherCountry");
                dt.Columns.Add("DrugReport");

                dt.Columns.Add("DeportedNoticeDate");
                dt.Columns.Add("DeportedNoticeType");
                dt.Columns.Add("DeportedLeave");
                dt.Columns.Add("DeportedAppealeddetails");

                dt.Columns.Add("flagDeportedOtherCountry");
                dt.Columns.Add("DeportedOtherCountry");

                dt.Columns.Add("FraudRecord");
                dt.Columns.Add("flagComplete");
                dt.Columns.Add("flagFreshPassport");
                dt.Columns.Add("flagCuurContactDetails");
                dt.Columns.Add("EmbassyId");
                dt.Columns.Add("flagInMillitary");
                dt.Columns.Add("flagEmployement");
                dt.Columns.Add("flagEmplDt");
                dt.Columns.Add("flagLastVisit");
                dt.Columns.Add("flagLastVisitCountries");
                dt.Columns.Add("flagLastLived");


                dr["EmployerName"] = this.EmployerName;
                dr["JobDesc"] = this.JobDesc;
                dr["OcuPossition"] = this.OcuPossition;

                dr["MoneyForTravellUSD"] = this.MoneyForTravellUSD;
                dr["ModeOfTravel"] = this.ModeOfTravel;
                dr["IntededDuration"] = this.IntededDuration;

                dr["flagPrevApplied"] = this.flagPrevApplied;
                dr["flagPrevVisit"] = this.flagPrevVisit;
                dr["flagVisaGranted"] = this.flagVisaGranted;
                dr["PrevAppliedVisaPlace"] = this.PrevAppliedVisaPlace;
                dr["PrevVisitReason"] = this.PrevVisitReason;
                dr["PrevVisaRejReason"] = this.PrevVisaRejReason;

                dr["PreVisit1FromDate"] = this.PreVisit1FromDate;
                dr["PreVisit1ToDate"] = this.PreVisit1ToDate;
                dr["PreVisit1Addr1"] = this.PreVisit1Addr1;
                dr["PreVisit1Addr2"] = this.PreVisit1Addr2;
                dr["PreVisit1City"] = this.PreVisit1City;
                dr["PreVisit1State"] = this.PreVisit1State;
                dr["PreVisit1District"] = this.PreVisit1District;
                dr["PreVisit1Postcode"] = this.PreVisit1Postcode;

                dr["PreVisit2FromDate"] = this.PreVisit2FromDate;
                dr["PreVisit2ToDate"] = this.PreVisit2ToDate;
                dr["PreVisit2Addr1"] = this.PreVisit2Addr1;
                dr["PreVisit2Addr2"] = this.PreVisit2Addr2;
                dr["PreVisit2City"] = this.PreVisit2City;
                dr["PreVisit2State"] = this.PreVisit2State;
                dr["PreVisit2District"] = this.PreVisit2District;
                dr["PreVisit2Postcode"] = this.PreVisit2Postcode;

                dr["PreVisit3FromDate"] = this.PreVisit3FromDate;
                dr["PreVisit3ToDate"] = this.PreVisit3ToDate;
                dr["PreVisit3Addr1"] = this.PreVisit3Addr1;
                dr["PreVisit3Addr2"] = this.PreVisit3Addr2;
                dr["PreVisit3City"] = this.PreVisit3City;
                dr["PreVisit3State"] = this.PreVisit3State;
                dr["PreVisit3District"] = this.PreVisit3District;
                dr["PreVisit3Postcode"] = this.PreVisit3Postcode;

                dr["ColorHair"] = this.ColorHair;
                dr["ColorEye"] = this.ColorEye;
                dr["IndentityMark"] = this.IndentityMark;
                dr["Height"] = this.Height;

                dr["InMilitary"] = this.InMilitary;
                dr["FromDate"] = this.FromDate;
                dr["ToDate"] = this.ToDate;

                dr["EmpName"] = this.EmpName;
                dr["EmpPhoneNo"] = this.EmpPhoneNo;
                dr["EmpLivedFrom"] = this.EmpLivedFrom;
                dr["Address1"] = this.Address1;
                dr["Address2"] = this.Address2;
                dr["EmpCity"] = this.EmpCity;
                dr["EmpState"] = this.EmpState;
                dr["EmpPostCode"] = this.EmpPostCode;

                dr["IntedAddress1"] = this.IntedAddress1;
                dr["IntedAddress2"] = this.IntedAddress2;
                dr["IntedCity"] = this.IntedCity;
                dr["IntedState"] = this.IntedState;
                dr["IntedDistrict"] = this.IntedDistrict;
                dr["IntedPostcode"] = this.IntedPostcode;

                dr["ApplyCountryYears"] = this.ApplyCountryYears;
                dr["FlagSeriousDisease"] = this.FlagSeriousDisease;
                dr["FlagCrimeRecord"] = this.FlagCrimeRecord;
                dr["FlagDrugReport"] = this.FlagDrugReport;
                dr["FlagDeported"] = this.FlagDeported;
                dr["FlagFraudRecord"] = this.FlagFraudRecord;

                dr["CountryCode1"] = this.CountryCode1;
                dr["CityName1"] = this.CityName1;
                dr["DepartureDate1"] = this.DepartureDate1;
                dr["CountryCode2"] = this.CountryCode2;
                dr["CityName2"] = this.CityName2;
                dr["DepartureDate2"] = this.DepartureDate2;
                dr["CountryCode3"] = this.CountryCode3;
                dr["CityName3"] = this.CityName3;
                dr["DepartureDate3"] = this.DepartureDate3;

                dr["LastLivedCountryCode1"] = this.LastLivedCountryCode1;
                dr["LastLivedCityName1"] = this.LastLivedCityName1;
                dr["LastLivedDepartureDate1"] = this.LastLivedDepartureDate1;
                dr["LastLivedCountryCode2"] = this.LastLivedCountryCode2;
                dr["LastLivedCityName2"] = this.LastLivedCityName2;
                dr["LastLivedDepartureDate2"] = this.LastLivedDepartureDate2;
                dr["LastLivedCountryCode3"] = this.LastLivedCountryCode3;
                dr["LastLivedCityName3"] = this.LastLivedCityName3;
                dr["LastLivedDepartureDate3"] = this.LastLivedDepartureDate3;

                dr["flagFastTrack"] = this.flagFastTrack;

                dr["OtherName"] = this.OtherName;

                dr["FatherLastName"] = this.FatherLastName;
                dr["FatherDateOfBirth"] = this.FatherDateOfBirth;
                dr["FatherAddress"] = this.FatherAddress;
                dr["FatherNationality"] = this.FatherNationality;

                dr["MotherLastName"] = this.MotherLastName;
                dr["MotherDateOfBirth"] = this.MotherDateOfBirth;
                dr["MotherAddress"] = this.MotherAddress;
                dr["MotherNationality"] = this.MotherNationality;

                dr["OldPassport"] = this.OldPassport;
                dr["OldPaasportIssueDate"] = this.OldPaasportIssueDate;
                dr["PlaceIssueOldPassport"] = this.PlaceIssueOldPassport;

                dr["currAddress2"] = this.currAddress2;
                dr["City"] = this.City;
                dr["State"] = this.State;
                dr["District"] = this.District;
                dr["Postcode"] = this.Postcode;
                dr["CurrentCountry"] = this.CurrentCountry;
                dr["LivedInCurrentAdd"] = this.LivedInCurrentAdd;

                dr["PerAddres2"] = this.PerAddres2;
                dr["PerCity"] = this.PerCity;
                dr["PerState"] = this.PerState;
                dr["PerPostcode"] = this.PerPostcode;
                dr["PerDistrict"] = this.PerDistrict;
                dr["PerCountry"] = this.PerCountry;

                dr["CurrentLocation"] = this.CurrentLocation;

                dr["flagOtherNationality"] = this.flagOtherNationality;
                dr["OtherNationality"] = this.OtherNationality;

                dr["DateRejected"] = this.DateRejected;
                dr["LastRejectedVisaType"] = this.LastRejectedVisaType;
                dr["flagRejeAppeal"] = this.flagRejeAppeal;
                dr["RejectedAppDiffer"] = this.RejectedAppDiffer;

                dr["flagRefusedAnyCountry"] = this.flagRefusedAnyCountry;
                dr["RefusedAnyCountry"] = this.RefusedAnyCountry;

                dr["flagRefuseEntryOnArrival"] = this.flagRefuseEntryOnArrival;
                dr["RefusedVisaOnArrivalPlace"] = this.RefusedVisaOnArrivalPlace;
                dr["RefusedVisaOnArrivalDate"] = this.RefusedVisaOnArrivalDate;
                dr["flagRefusedVisArriAppeal"] = this.flagRefusedVisArriAppeal;
                dr["RefusedVisArriAppOutcome"] = this.RefusedVisArriAppOutcome;
                dr["RefusedVisaOnArrivalReason"] = this.RefusedVisaOnArrivalReason;

                dr["Disease"] = this.Disease;

                dr["CrimeRecord"] = this.CrimeRecord;
                dr["ConvictionDate"] = this.ConvictionDate;
                dr["ConvictedPlace"] = this.ConvictedPlace;
                dr["Sentence"] = this.Sentence;

                dr["flagConvictionInOtherCountry"] = this.flagConvictionInOtherCountry;
                dr["ConvictionInOtherCountry"] = this.ConvictionInOtherCountry;
                dr["DrugReport"] = this.DrugReport;

                dr["DeportedNoticeDate"] = this.DeportedNoticeDate;
                dr["DeportedNoticeType"] = this.DeportedNoticeType;
                dr["DeportedLeave"] = this.DeportedLeave;
                dr["DeportedAppealeddetails"] = this.DeportedAppealeddetails;

                dr["flagDeportedOtherCountry"] = this.flagDeportedOtherCountry;
                dr["DeportedOtherCountry"] = this.DeportedOtherCountry;

                dr["FraudRecord"] = this.FraudRecord;
                dr["flagComplete"] = this.flagComplete;
                dr["flagFreshPassport"] = this.flagFreshPassport;
                dr["flagCuurContactDetails"] = this.flagCuurContactDetails;
                dr["EmbassyId"] = this.EmbassyId;
                dr["flagInMillitary"] = this.flagInMillitary;
                dr["flagEmployement"] = this.flagEmployement;
                dr["flagEmplDt"] = this.flagEmplDt;
                dr["flagLastVisit"] = this.flagLastVisit;
                dr["flagLastVisitCountries"] = this.flagLastVisitCountries;
                dr["flagLastLived"] = this.flagLastLived;
                //dr["Name"] = this.Name;
                dr["ratecurrency"] = this.ratecurrency;
                dr["logobrowser"] = this.logobrowse;
                dr["Nationality"] = this.Nationality;
                dr["PassportNo"] = this.PassportNo;
                dr["PassportType"] = this.PassportType;
                dr["Doissue"] = this.Doissue;
                dr["DoExp"] = this.DoExp;
                dr["Poissue"] = this.Poissue;
                dr["issuingauthority"] = this.issuingauthority;
                dr["fname"] = this.fname;
                dr["mname"] = this.mname;
                dr["lname"] = this.lname;
                dr["sex"] = this.sex;
                dr["dob"] = this.dob;
                dr["pob"] = this.pob;
                dr["maritalstatus"] = this.maritalstatus;
                dr["fathername"] = this.fathername;
                dr["mothername"] = this.mothername;
                dr["spousename"] = this.spousename;
                dr["currentaddress"] = this.currentaddress;
                dr["permanentaddress"] = this.permanentaddress;
                dr["mobilenumber"] = this.mobilenumber;
                dr["landlinenumber"] = this.landlinenumber;
                dr["primaryemail"] = this.primaryemail;
                dr["alternateemail"] = this.alternateemail;
                dr["presentoccupation"] = this.presentoccupation;
                dr["country"] = this.country;
                dr["VisaType"] = this.VisaType;
                dr["EntryType"] = this.EntryType;
                dr["periodtype"] = this.periodtype;
                dr["Duration"] = this.Duration;
                dr["rate"] = this.rate;
                dr["ArivalDate"] = this.ArivalDate;
                dr["DepDate"] = this.DepDate;
                dr["burundiaddress"] = this.burundiaddress;
                dr["psb"] = this.psb;
                dr["severaljourney"] = this.severaljourney;
                dr["returnticket"] = this.returnticket;
                dr["EntryPoint"] = this.EntryPoint;
                dr["ExitPoint"] = this.ExitPoint;
                dr["AppliedBy"] = this.AppliedBy;
                dr["AppliedByUserId"] = this.AppliedByUserId;
                dr["CreatedBy"] = this.CreatedBy;
                dr["Status"] = this.Status;
                dr["ApplicationID"] = this.ApplicationID;
                dr["EmployerName"] = this.EmployerName;
                dr["JobDesc"] = this.JobDesc;
                dr["OcuPossition"] = this.OcuPossition;

                dr["MoneyForTravellUSD"] = this.MoneyForTravellUSD;
                dr["ModeOfTravel"] = this.ModeOfTravel;
                dr["IntededDuration"] = this.IntededDuration;

                dr["flagPrevApplied"] = this.flagPrevApplied;
                dr["flagPrevVisit"] = this.flagPrevVisit;
                dr["flagVisaGranted"] = this.flagVisaGranted;
                dr["PrevAppliedVisaPlace"] = this.PrevAppliedVisaPlace;
                dr["PrevVisitReason"] = this.PrevVisitReason;
                dr["PrevVisaRejReason"] = this.PrevVisaRejReason;

                dr["PreVisit1FromDate"] = this.PreVisit1FromDate;
                dr["PreVisit1ToDate"] = this.PreVisit1ToDate;
                dr["PreVisit1Addr1"] = this.PreVisit1Addr1;
                dr["PreVisit1Addr2"] = this.PreVisit1Addr2;
                dr["PreVisit1City"] = this.PreVisit1City;
                dr["PreVisit1State"] = this.PreVisit1State;
                dr["PreVisit1District"] = this.PreVisit1District;
                dr["PreVisit1Postcode"] = this.PreVisit1Postcode;

                dr["PreVisit2FromDate"] = this.PreVisit2FromDate;
                dr["PreVisit2ToDate"] = this.PreVisit2ToDate;
                dr["PreVisit2Addr1"] = this.PreVisit2Addr1;
                dr["PreVisit2Addr2"] = this.PreVisit2Addr2;
                dr["PreVisit2City"] = this.PreVisit2City;
                dr["PreVisit2State"] = this.PreVisit2State;
                dr["PreVisit2District"] = this.PreVisit2District;
                dr["PreVisit2Postcode"] = this.PreVisit2Postcode;

                dr["PreVisit3FromDate"] = this.PreVisit3FromDate;
                dr["PreVisit3ToDate"] = this.PreVisit3ToDate;
                dr["PreVisit3Addr1"] = this.PreVisit3Addr1;
                dr["PreVisit3Addr2"] = this.PreVisit3Addr2;
                dr["PreVisit3City"] = this.PreVisit3City;
                dr["PreVisit3State"] = this.PreVisit3State;
                dr["PreVisit3District"] = this.PreVisit3District;
                dr["PreVisit3Postcode"] = this.PreVisit3Postcode;

                dr["ColorHair"] = this.ColorHair;
                dr["ColorEye"] = this.ColorEye;
                dr["IndentityMark"] = this.IndentityMark;
                dr["Height"] = this.Height;

                dr["InMilitary"] = this.InMilitary;
                dr["FromDate"] = this.FromDate;
                dr["ToDate"] = this.ToDate;

                dr["EmpName"] = this.EmpName;
                dr["EmpPhoneNo"] = this.EmpPhoneNo;
                dr["EmpLivedFrom"] = this.EmpLivedFrom;
                dr["Address1"] = this.Address1;
                dr["Address2"] = this.Address2;
                dr["EmpCity"] = this.EmpCity;
                dr["EmpState"] = this.EmpState;
                dr["EmpPostCode"] = this.EmpPostCode;

                dr["IntedAddress1"] = this.IntedAddress1;
                dr["IntedAddress2"] = this.IntedAddress2;
                dr["IntedCity"] = this.IntedCity;
                dr["IntedState"] = this.IntedState;
                dr["IntedDistrict"] = this.IntedDistrict;
                dr["IntedPostcode"] = this.IntedPostcode;

                dr["ApplyCountryYears"] = this.ApplyCountryYears;
                dr["FlagSeriousDisease"] = this.FlagSeriousDisease;
                dr["FlagCrimeRecord"] = this.FlagCrimeRecord;
                dr["FlagDrugReport"] = this.FlagDrugReport;
                dr["FlagDeported"] = this.FlagDeported;
                dr["FlagFraudRecord"] = this.FlagFraudRecord;

                dr["CountryCode1"] = this.CountryCode1;
                dr["CityName1"] = this.CityName1;
                dr["DepartureDate1"] = this.DepartureDate1;
                dr["CountryCode2"] = this.CountryCode2;
                dr["CityName2"] = this.CityName2;
                dr["DepartureDate2"] = this.DepartureDate2;
                dr["CountryCode3"] = this.CountryCode3;
                dr["CityName3"] = this.CityName3;
                dr["DepartureDate3"] = this.DepartureDate3;

                dr["LastLivedCountryCode1"] = this.LastLivedCountryCode1;
                dr["LastLivedCityName1"] = this.LastLivedCityName1;
                dr["LastLivedDepartureDate1"] = this.LastLivedDepartureDate1;
                dr["LastLivedCountryCode2"] = this.LastLivedCountryCode2;
                dr["LastLivedCityName2"] = this.LastLivedCityName2;
                dr["LastLivedDepartureDate2"] = this.LastLivedDepartureDate2;
                dr["LastLivedCountryCode3"] = this.LastLivedCountryCode3;
                dr["LastLivedCityName3"] = this.LastLivedCityName3;
                dr["LastLivedDepartureDate3"] = this.LastLivedDepartureDate3;

                dr["flagFastTrack"] = this.flagFastTrack;

                dr["OtherName"] = this.OtherName;

                dr["FatherLastName"] = this.FatherLastName;
                dr["FatherDateOfBirth"] = this.FatherDateOfBirth;
                dr["FatherAddress"] = this.FatherAddress;
                dr["FatherNationality"] = this.FatherNationality;

                dr["MotherLastName"] = this.MotherLastName;
                dr["MotherDateOfBirth"] = this.MotherDateOfBirth;
                dr["MotherAddress"] = this.MotherAddress;
                dr["MotherNationality"] = this.MotherNationality;

                dr["OldPassport"] = this.OldPassport;
                dr["OldPaasportIssueDate"] = this.OldPaasportIssueDate;
                dr["PlaceIssueOldPassport"] = this.PlaceIssueOldPassport;

                dr["currAddress2"] = this.currAddress2;
                dr["City"] = this.City;
                dr["State"] = this.State;
                dr["District"] = this.District;
                dr["Postcode"] = this.Postcode;
                dr["CurrentCountry"] = this.CurrentCountry;
                dr["LivedInCurrentAdd"] = this.LivedInCurrentAdd;

                dr["PerAddres2"] = this.PerAddres2;
                dr["PerCity"] = this.PerCity;
                dr["PerState"] = this.PerState;
                dr["PerPostcode"] = this.PerPostcode;
                dr["PerDistrict"] = this.PerDistrict;
                dr["PerCountry"] = this.PerCountry;

                dr["CurrentLocation"] = this.CurrentLocation;

                dr["flagOtherNationality"] = this.flagOtherNationality;
                dr["OtherNationality"] = this.OtherNationality;

                dr["DateRejected"] = this.DateRejected;
                dr["LastRejectedVisaType"] = this.LastRejectedVisaType;
                dr["flagRejeAppeal"] = this.flagRejeAppeal;
                dr["RejectedAppDiffer"] = this.RejectedAppDiffer;

                dr["flagRefusedAnyCountry"] = this.flagRefusedAnyCountry;
                dr["RefusedAnyCountry"] = this.RefusedAnyCountry;

                dr["flagRefuseEntryOnArrival"] = this.flagRefuseEntryOnArrival;
                dr["RefusedVisaOnArrivalPlace"] = this.RefusedVisaOnArrivalPlace;
                dr["RefusedVisaOnArrivalDate"] = this.RefusedVisaOnArrivalDate;
                dr["flagRefusedVisArriAppeal"] = this.flagRefusedVisArriAppeal;
                dr["RefusedVisArriAppOutcome"] = this.RefusedVisArriAppOutcome;
                dr["RefusedVisaOnArrivalReason"] = this.RefusedVisaOnArrivalReason;

                dr["Disease"] = this.Disease;

                dr["CrimeRecord"] = this.CrimeRecord;
                dr["ConvictionDate"] = this.ConvictionDate;
                dr["ConvictedPlace"] = this.ConvictedPlace;
                dr["Sentence"] = this.Sentence;

                dr["flagConvictionInOtherCountry"] = this.flagConvictionInOtherCountry;
                dr["ConvictionInOtherCountry"] = this.ConvictionInOtherCountry;
                dr["DrugReport"] = this.DrugReport;

                dr["DeportedNoticeDate"] = this.DeportedNoticeDate;
                dr["DeportedNoticeType"] = this.DeportedNoticeType;
                dr["DeportedLeave"] = this.DeportedLeave;
                dr["DeportedAppealeddetails"] = this.DeportedAppealeddetails;

                dr["flagDeportedOtherCountry"] = this.flagDeportedOtherCountry;
                dr["DeportedOtherCountry"] = this.DeportedOtherCountry;

                dr["FraudRecord"] = this.FraudRecord;
                dr["flagComplete"] = this.flagComplete;
                dr["flagFreshPassport"] = this.flagFreshPassport;
                dr["flagCuurContactDetails"] = this.flagCuurContactDetails;
                dr["EmbassyId"] = this.EmbassyId;
                dr["flagInMillitary"] = this.flagInMillitary;
                dr["flagEmployement"] = this.flagEmployement;
                dr["flagEmplDt"] = this.flagEmplDt;
                dr["flagLastVisit"] = this.flagLastVisit;
                dr["flagLastVisitCountries"] = this.flagLastVisitCountries;
                dr["flagLastLived"] = this.flagLastLived;
                dt.Rows.Add(dr);

                return objSubmit.UpdateVisaApplication(dt);
            }
            catch (Exception e)
            {
                throw (e);
            }
            finally
            {
                objSubmit = null;
            }

        }
        //-----------------------By Chtiresh----------------------

        public DataSet GetVisaAppDocDetails(string Applicaitonid)
        {
            DataAccessLayer.DalVisaApplicationSubmit ObjDalAppDetails = null;

            try
            {
                ObjDalAppDetails = new DataAccessLayer.DalVisaApplicationSubmit();
                return ObjDalAppDetails.GetVisaAppDocDetails(Applicaitonid);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ObjDalAppDetails = null;

            }
        }
        public DataTable GetDocForPrint(string strApplicationId)
        {
            DataAccessLayer.DalVisaApplicationSubmit ObjDalAppDetails = null;

            try
            {
                ObjDalAppDetails = new DataAccessLayer.DalVisaApplicationSubmit();
                return ObjDalAppDetails.GetDocForPrint(strApplicationId);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ObjDalAppDetails = null;

            }
        }
        //-=------------------------end--------------------------


        public string filename { get; set; }

        public string DocCode { get; set; }

        public int InsertAttachedDocs()
        {
            DataAccessLayer.DalVisaApplicationSubmit objSubmit = null;

            DataTable dt = null;
            try
            {
                objSubmit = new DataAccessLayer.DalVisaApplicationSubmit();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                //dt.Columns.Add("Name");
                dt.Columns.Add("ApplicationId");
                dt.Columns.Add("filename");
                dt.Columns.Add("DocCode");

                //dr["Name"] = this.Name;
                dr["ApplicationId"] = this.ApplicationID;
                dr["filename"] = this.filename;
                dr["DocCode"] = this.DocCode;
                dt.Rows.Add(dr);

                return objSubmit.InsertAttachedDocs(dt);

            }
            catch (Exception e)
            {
                throw (e);
            }
            finally
            {
                objSubmit = null;
            }
        }

        public int UpdateFlagPayment(string strPaymentReceiptNo)
        {
            DataAccessLayer.DalVisaApplicationSubmit objSubmit = null;

            DataTable dt = null;
            try
            {
                objSubmit = new DataAccessLayer.DalVisaApplicationSubmit();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                //dt.Columns.Add("Name");
                dt.Columns.Add("ApplicationId");
                dt.Columns.Add("PaymentReceiptNo");

                //dr["Name"] = this.Name;
                dr["ApplicationId"] = this.ApplicationID;
                dr["PaymentReceiptNo"] = strPaymentReceiptNo;

                dt.Rows.Add(dr);

                return objSubmit.UpdateFlagPayment(dt);

            }
            catch (Exception e)
            {
                throw (e);
            }
            finally
            {
                objSubmit = null;
            }
        }

        public int UpdateAttachedDocs()
        {
            DataAccessLayer.DalVisaApplicationSubmit objSubmit = null;

            DataTable dt = null;
            try
            {
                objSubmit = new DataAccessLayer.DalVisaApplicationSubmit();
                dt = new DataTable();

                DataRow dr = dt.NewRow();

                //dt.Columns.Add("Name");
                dt.Columns.Add("ApplicationId");
                dt.Columns.Add("filename");
                dt.Columns.Add("DocCode");

                //dr["Name"] = this.Name;
                dr["ApplicationId"] = this.ApplicationID;
                dr["filename"] = this.filename;
                dr["DocCode"] = this.DocCode;
                dt.Rows.Add(dr);

                return objSubmit.UpdateAttachedDocs(dt);

            }
            catch (Exception e)
            {
                throw (e);
            }
            finally
            {
                objSubmit = null;
            }
        }
    }
}
