using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DalVisaApplicationSubmit
    {


        public int GetVisaAppsubmit(DataTable dt)
        {

            SqlParameter[] pram = null;

            //try
            //{

            pram = new SqlParameter[192];

            pram[0] = new SqlParameter("@ratecurrency", dt.Rows[0]["ratecurrency"]);
            pram[1] = new SqlParameter("@Nationality", dt.Rows[0]["Nationality"]);
            pram[2] = new SqlParameter("@PassportNo", dt.Rows[0]["PassportNo"]);
            pram[3] = new SqlParameter("@PassportType", dt.Rows[0]["PassportType"]);
            pram[4] = new SqlParameter("@Doissue", dt.Rows[0]["Doissue"]);
            pram[5] = new SqlParameter("@DoExp", dt.Rows[0]["DoExp"]);
            pram[6] = new SqlParameter("@Poissue", dt.Rows[0]["Poissue"]);
            pram[7] = new SqlParameter("@issuingauthority", dt.Rows[0]["issuingauthority"]);
            pram[8] = new SqlParameter("@fname", dt.Rows[0]["fname"]);
            pram[9] = new SqlParameter("@mname", dt.Rows[0]["mname"]);
            pram[10] = new SqlParameter("@lname", dt.Rows[0]["lname"]);
            pram[11] = new SqlParameter("@sex", dt.Rows[0]["sex"]);
            pram[12] = new SqlParameter("@dob", dt.Rows[0]["dob"]);
            pram[13] = new SqlParameter("@pob", dt.Rows[0]["pob"]);
            pram[14] = new SqlParameter("@maritalstatus", dt.Rows[0]["maritalstatus"]);
            pram[15] = new SqlParameter("@fathername", dt.Rows[0]["fathername"]);
            pram[16] = new SqlParameter("@mothername", dt.Rows[0]["mothername"]);
            pram[17] = new SqlParameter("@spousename", dt.Rows[0]["spousename"]);
            pram[18] = new SqlParameter("@currentaddress", dt.Rows[0]["currentaddress"]);
            pram[19] = new SqlParameter("@permanentaddress", dt.Rows[0]["permanentaddress"]);
            pram[20] = new SqlParameter("@mobilenumber", dt.Rows[0]["mobilenumber"]);
            pram[21] = new SqlParameter("@landlinenumber", dt.Rows[0]["landlinenumber"]);
            pram[22] = new SqlParameter("@primaryemail", dt.Rows[0]["primaryemail"]);
            pram[23] = new SqlParameter("@alternateemail", dt.Rows[0]["alternateemail"]);
            pram[24] = new SqlParameter("@presentoccupation", dt.Rows[0]["presentoccupation"]);
            pram[25] = new SqlParameter("@country", dt.Rows[0]["country"]);
            pram[26] = new SqlParameter("@VisaType", dt.Rows[0]["VisaType"]);
            pram[27] = new SqlParameter("@EntryType", dt.Rows[0]["EntryType"]);
            pram[28] = new SqlParameter("@periodtype", dt.Rows[0]["periodtype"]);
            pram[29] = new SqlParameter("@Duration", dt.Rows[0]["Duration"]);
            pram[30] = new SqlParameter("@rate", dt.Rows[0]["rate"]);
            pram[31] = new SqlParameter("@ArivalDate", dt.Rows[0]["ArivalDate"]);
            pram[32] = new SqlParameter("@DepDat", dt.Rows[0]["DepDate"]);
            pram[33] = new SqlParameter("@burundiaddress", dt.Rows[0]["burundiaddress"]);
            pram[34] = new SqlParameter("@psb", dt.Rows[0]["psb"]);
            pram[35] = new SqlParameter("@severaljourney", dt.Rows[0]["severaljourney"]);
            pram[36] = new SqlParameter("@returnticket", dt.Rows[0]["returnticket"]);
            pram[37] = new SqlParameter("@EntryPoint", dt.Rows[0]["EntryPoint"]);
            pram[38] = new SqlParameter("@ExitPoint", dt.Rows[0]["ExitPoint"]);
            pram[39] = new SqlParameter("@logobrowser", dt.Rows[0]["logobrowser"]);
            pram[40] = new SqlParameter("@appliedBy", dt.Rows[0]["appliedBy"]);
            pram[41] = new SqlParameter("@appliedByUserId", dt.Rows[0]["appliedByUserId"]);
            pram[42] = new SqlParameter("@createdBy", dt.Rows[0]["createdBy"]);
            pram[43] = new SqlParameter("@Status", dt.Rows[0]["Status"]);

            pram[44] = new SqlParameter("@EmployerName", dt.Rows[0]["EmployerName"]);
            pram[45] = new SqlParameter("@JobDesc", dt.Rows[0]["JobDesc"]);
            pram[46] = new SqlParameter("@OcuPossition", dt.Rows[0]["OcuPossition"]);

            pram[47] = new SqlParameter("@MoneyForTravellUSD", dt.Rows[0]["MoneyForTravellUSD"]);
            pram[48] = new SqlParameter("@ModeOfTravel", dt.Rows[0]["ModeOfTravel"]);
            pram[49] = new SqlParameter("@IntededDuration", dt.Rows[0]["IntededDuration"]);

            pram[50] = new SqlParameter("@flagPrevApplied", dt.Rows[0]["flagPrevApplied"]);
            pram[51] = new SqlParameter("@flagPrevVisit", dt.Rows[0]["flagPrevVisit"]);
            pram[52] = new SqlParameter("@flagVisaGranted", dt.Rows[0]["flagVisaGranted"]);
            pram[53] = new SqlParameter("@PrevAppliedVisaPlace", dt.Rows[0]["PrevAppliedVisaPlace"]);
            pram[54] = new SqlParameter("@PrevVisitReason", dt.Rows[0]["PrevVisitReason"]);
            pram[55] = new SqlParameter("@PrevVisaRejReason", dt.Rows[0]["PrevVisaRejReason"]);

            pram[56] = new SqlParameter("@PreVisit1FromDate", dt.Rows[0]["PreVisit1FromDate"]);
            pram[57] = new SqlParameter("@PreVisit1ToDate", dt.Rows[0]["PreVisit1ToDate"]);
            pram[58] = new SqlParameter("@PreVisit1Addr1", dt.Rows[0]["PreVisit1Addr1"]);
            pram[59] = new SqlParameter("@PreVisit1Addr2", dt.Rows[0]["PreVisit1Addr2"]);
            pram[60] = new SqlParameter("@PreVisit1City", dt.Rows[0]["PreVisit1City"]);
            pram[61] = new SqlParameter("@PreVisit1State", dt.Rows[0]["PreVisit1State"]);
            pram[62] = new SqlParameter("@PreVisit1District", dt.Rows[0]["PreVisit1District"]);
            pram[63] = new SqlParameter("@PreVisit1Postcode", dt.Rows[0]["PreVisit1Postcode"]);

            pram[64] = new SqlParameter("@PreVisit2FromDate", dt.Rows[0]["PreVisit2FromDate"]);
            pram[65] = new SqlParameter("@PreVisit2ToDate", dt.Rows[0]["PreVisit2ToDate"]);
            pram[66] = new SqlParameter("@PreVisit2Addr1", dt.Rows[0]["PreVisit2Addr1"]);
            pram[67] = new SqlParameter("@PreVisit2Addr2", dt.Rows[0]["PreVisit2Addr2"]);
            pram[68] = new SqlParameter("@PreVisit2City", dt.Rows[0]["PreVisit2City"]);
            pram[69] = new SqlParameter("@PreVisit2State", dt.Rows[0]["PreVisit2State"]);
            pram[70] = new SqlParameter("@PreVisit2District", dt.Rows[0]["PreVisit2District"]);
            pram[71] = new SqlParameter("@PreVisit2Postcode", dt.Rows[0]["PreVisit2Postcode"]);

            pram[72] = new SqlParameter("@PreVisit3FromDate", dt.Rows[0]["PreVisit3FromDate"]);
            pram[73] = new SqlParameter("@PreVisit3ToDate", dt.Rows[0]["PreVisit3ToDate"]);
            pram[74] = new SqlParameter("@PreVisit3Addr1", dt.Rows[0]["PreVisit3Addr1"]);
            pram[75] = new SqlParameter("@PreVisit3Addr2", dt.Rows[0]["PreVisit3Addr2"]);
            pram[76] = new SqlParameter("@PreVisit3City", dt.Rows[0]["PreVisit3City"]);
            pram[77] = new SqlParameter("@PreVisit3State", dt.Rows[0]["PreVisit3State"]);
            pram[78] = new SqlParameter("@PreVisit3District", dt.Rows[0]["PreVisit3District"]);
            pram[79] = new SqlParameter("@PreVisit3Postcode", dt.Rows[0]["PreVisit3Postcode"]);

            pram[80] = new SqlParameter("@ColorHair", dt.Rows[0]["ColorHair"]);
            pram[81] = new SqlParameter("@ColorEye", dt.Rows[0]["ColorEye"]);
            pram[82] = new SqlParameter("@IndentityMark", dt.Rows[0]["IndentityMark"]);
            pram[83] = new SqlParameter("@Height", dt.Rows[0]["Height"]);

            pram[84] = new SqlParameter("@InMilitary", dt.Rows[0]["InMilitary"]);
            pram[85] = new SqlParameter("@FromDate", dt.Rows[0]["FromDate"]);
            pram[86] = new SqlParameter("@ToDate", dt.Rows[0]["ToDate"]);

            pram[87] = new SqlParameter("@EmpName", dt.Rows[0]["EmpName"]);
            pram[88] = new SqlParameter("@EmpPhoneNo", dt.Rows[0]["EmpPhoneNo"]);
            pram[89] = new SqlParameter("@EmpLivedFrom", dt.Rows[0]["EmpLivedFrom"]);
            pram[90] = new SqlParameter("@Address1", dt.Rows[0]["Address1"]);
            pram[91] = new SqlParameter("@Address2", dt.Rows[0]["Address2"]);
            pram[92] = new SqlParameter("@EmpCity", dt.Rows[0]["EmpCity"]);
            pram[93] = new SqlParameter("@EmpState", dt.Rows[0]["EmpState"]);
            pram[94] = new SqlParameter("@EmpPostCode", dt.Rows[0]["EmpPostCode"]);

            pram[95] = new SqlParameter("@IntedAddress1", dt.Rows[0]["IntedAddress1"]);
            pram[96] = new SqlParameter("@IntedAddress2", dt.Rows[0]["IntedAddress2"]);
            pram[97] = new SqlParameter("@IntedCity", dt.Rows[0]["IntedCity"]);
            pram[98] = new SqlParameter("@IntedState", dt.Rows[0]["IntedState"]);
            pram[99] = new SqlParameter("@IntedDistrict", dt.Rows[0]["IntedDistrict"]);
            pram[100] = new SqlParameter("@IntedPostcode", dt.Rows[0]["IntedPostcode"]);

            pram[101] = new SqlParameter("@ApplyCountryYears", dt.Rows[0]["ApplyCountryYears"]);
            pram[102] = new SqlParameter("@FlagSeriousDisease", dt.Rows[0]["FlagSeriousDisease"]);
            pram[103] = new SqlParameter("@FlagCrimeRecord", dt.Rows[0]["FlagCrimeRecord"]);
            pram[104] = new SqlParameter("@FlagDrugReport", dt.Rows[0]["FlagDrugReport"]);
            pram[105] = new SqlParameter("@FlagDeported", dt.Rows[0]["FlagDeported"]);
            pram[106] = new SqlParameter("@FlagFraudRecord", dt.Rows[0]["FlagFraudRecord"]);

            pram[107] = new SqlParameter("@CountryCode1", dt.Rows[0]["CountryCode1"]);
            pram[108] = new SqlParameter("@CityName1", dt.Rows[0]["CityName1"]);
            pram[109] = new SqlParameter("@DepartureDate1", dt.Rows[0]["DepartureDate1"]);
            pram[110] = new SqlParameter("@CountryCode2", dt.Rows[0]["CountryCode2"]);
            pram[111] = new SqlParameter("@CityName2", dt.Rows[0]["CityName2"]);
            pram[112] = new SqlParameter("@DepartureDate2", dt.Rows[0]["DepartureDate2"]);
            pram[113] = new SqlParameter("@CountryCode3", dt.Rows[0]["CountryCode3"]);
            pram[114] = new SqlParameter("@CityName3", dt.Rows[0]["CityName3"]);
            pram[115] = new SqlParameter("@DepartureDate3", dt.Rows[0]["DepartureDate3"]);

            pram[116] = new SqlParameter("@LastLivedCountryCode1", dt.Rows[0]["LastLivedCountryCode1"]);
            pram[117] = new SqlParameter("@LastLivedCityName1", dt.Rows[0]["LastLivedCityName1"]);
            pram[118] = new SqlParameter("@LastLivedDepartureDate1", dt.Rows[0]["LastLivedDepartureDate1"]);
            pram[119] = new SqlParameter("@LastLivedCountryCode2", dt.Rows[0]["LastLivedCountryCode2"]);
            pram[120] = new SqlParameter("@LastLivedCityName2", dt.Rows[0]["LastLivedCityName2"]);
            pram[121] = new SqlParameter("@LastLivedDepartureDate2", dt.Rows[0]["LastLivedDepartureDate2"]);
            pram[122] = new SqlParameter("@LastLivedCountryCode3", dt.Rows[0]["LastLivedCountryCode3"]);
            pram[123] = new SqlParameter("@LastLivedCityName3", dt.Rows[0]["LastLivedCityName3"]);
            pram[124] = new SqlParameter("@LastLivedDepartureDate3", dt.Rows[0]["LastLivedDepartureDate3"]);

            pram[125] = new SqlParameter("@flagFastTrack", dt.Rows[0]["flagFastTrack"]);

            pram[126] = new SqlParameter("@OtherName", dt.Rows[0]["OtherName"]);

            pram[127] = new SqlParameter("@FatherLastName", dt.Rows[0]["FatherLastName"]);
            pram[128] = new SqlParameter("@FatherDateOfBirth", dt.Rows[0]["FatherDateOfBirth"]);
            pram[129] = new SqlParameter("@FatherAddress", dt.Rows[0]["FatherAddress"]);
            pram[130] = new SqlParameter("@FatherNationality", dt.Rows[0]["FatherNationality"]);

            pram[131] = new SqlParameter("@MotherLastName", dt.Rows[0]["MotherLastName"]);
            pram[132] = new SqlParameter("@MotherDateOfBirth", dt.Rows[0]["MotherDateOfBirth"]);
            pram[133] = new SqlParameter("@MotherAddress", dt.Rows[0]["MotherAddress"]);
            pram[134] = new SqlParameter("@MotherNationality", dt.Rows[0]["MotherNationality"]);


            pram[135] = new SqlParameter("@OldPaasportIssueDate", dt.Rows[0]["OldPaasportIssueDate"]);
            pram[136] = new SqlParameter("@PlaceIssueOldPassport", dt.Rows[0]["PlaceIssueOldPassport"]);

            pram[137] = new SqlParameter("@currAddress2", dt.Rows[0]["currAddress2"]);
            pram[138] = new SqlParameter("@City", dt.Rows[0]["City"]);
            pram[139] = new SqlParameter("@State", dt.Rows[0]["State"]);
            pram[140] = new SqlParameter("@District", dt.Rows[0]["District"]);
            pram[141] = new SqlParameter("@Postcode", dt.Rows[0]["Postcode"]);
            pram[142] = new SqlParameter("@CurrentCountry", dt.Rows[0]["CurrentCountry"]);
            pram[143] = new SqlParameter("@LivedInCurrentAdd", dt.Rows[0]["LivedInCurrentAdd"]);

            pram[144] = new SqlParameter("@PerAddres2", dt.Rows[0]["PerAddres2"]);
            pram[145] = new SqlParameter("@PerCity", dt.Rows[0]["PerCity"]);
            pram[146] = new SqlParameter("@PerState", dt.Rows[0]["PerState"]);
            pram[147] = new SqlParameter("@PerPostcode", dt.Rows[0]["PerPostcode"]);
            pram[148] = new SqlParameter("@PerDistrict", dt.Rows[0]["PerDistrict"]);
            pram[149] = new SqlParameter("@PerCountry", dt.Rows[0]["PerCountry"]);

            pram[150] = new SqlParameter("@CurrentLocation", dt.Rows[0]["CurrentLocation"]);

            pram[151] = new SqlParameter("@flagOtherNationality", dt.Rows[0]["flagOtherNationality"]);
            pram[152] = new SqlParameter("@OtherNationality", dt.Rows[0]["OtherNationality"]);

            pram[153] = new SqlParameter("@DateRejected", dt.Rows[0]["DateRejected"]);
            pram[154] = new SqlParameter("@LastRejectedVisaType", dt.Rows[0]["LastRejectedVisaType"]);
            pram[155] = new SqlParameter("@flagRejeAppeal", dt.Rows[0]["flagRejeAppeal"]);
            pram[156] = new SqlParameter("@RejectedAppDiffer", dt.Rows[0]["RejectedAppDiffer"]);

            pram[157] = new SqlParameter("@flagRefusedAnyCountry", dt.Rows[0]["flagRefusedAnyCountry"]);
            pram[158] = new SqlParameter("@RefusedAnyCountry", dt.Rows[0]["RefusedAnyCountry"]);

            pram[159] = new SqlParameter("@flagRefuseEntryOnArrival", dt.Rows[0]["flagRefuseEntryOnArrival"]);
            pram[160] = new SqlParameter("@RefusedVisaOnArrivalPlace", dt.Rows[0]["RefusedVisaOnArrivalPlace"]);
            pram[161] = new SqlParameter("@RefusedVisaOnArrivalDate", dt.Rows[0]["RefusedVisaOnArrivalDate"]);
            pram[162] = new SqlParameter("@flagRefusedVisArriAppeal", dt.Rows[0]["flagRefusedVisArriAppeal"]);
            pram[163] = new SqlParameter("@RefusedVisArriAppOutcome", dt.Rows[0]["RefusedVisArriAppOutcome"]);
            pram[164] = new SqlParameter("@RefusedVisaOnArrivalReason", dt.Rows[0]["RefusedVisaOnArrivalReason"]);

            pram[165] = new SqlParameter("@Disease", dt.Rows[0]["Disease"]);

            pram[166] = new SqlParameter("@CrimeRecord", dt.Rows[0]["CrimeRecord"]);
            pram[167] = new SqlParameter("@ConvictionDate", dt.Rows[0]["ConvictionDate"]);
            pram[168] = new SqlParameter("@ConvictedPlace", dt.Rows[0]["ConvictedPlace"]);
            pram[169] = new SqlParameter("@Sentence", dt.Rows[0]["Sentence"]);

            pram[170] = new SqlParameter("@flagConvictionInOtherCountry", dt.Rows[0]["flagConvictionInOtherCountry"]);
            pram[171] = new SqlParameter("@ConvictionInOtherCountry", dt.Rows[0]["ConvictionInOtherCountry"]);
            pram[172] = new SqlParameter("@DrugReport", dt.Rows[0]["DrugReport"]);

            pram[173] = new SqlParameter("@DeportedNoticeDate", dt.Rows[0]["DeportedNoticeDate"]);
            pram[174] = new SqlParameter("@DeportedNoticeType", dt.Rows[0]["DeportedNoticeType"]);
            pram[175] = new SqlParameter("@DeportedLeave", dt.Rows[0]["DeportedLeave"]);
            pram[176] = new SqlParameter("@DeportedAppealeddetails", dt.Rows[0]["DeportedAppealeddetails"]);

            pram[177] = new SqlParameter("@flagDeportedOtherCountry", dt.Rows[0]["flagDeportedOtherCountry"]);
            pram[178] = new SqlParameter("@DeportedOtherCountry", dt.Rows[0]["DeportedOtherCountry"]);

            pram[179] = new SqlParameter("@FraudRecord", dt.Rows[0]["FraudRecord"]);

            pram[180] = new SqlParameter("@OldPassport", dt.Rows[0]["OldPassport"]);

            pram[181] = new SqlParameter("@flagComplete", dt.Rows[0]["flagComplete"]);

            pram[182] = new SqlParameter("@flagFreshPassport", dt.Rows[0]["flagFreshPassport"]);

            pram[183] = new SqlParameter("@flagCuurContactDetails", dt.Rows[0]["flagCuurContactDetails"]);

            pram[184] = new SqlParameter("@EmbassyId", dt.Rows[0]["EmbassyId"]);

            pram[185] = new SqlParameter("@flagInMillitary", dt.Rows[0]["flagInMillitary"]);

            pram[186] = new SqlParameter("@flagEmployement", dt.Rows[0]["flagEmployement"]);

            pram[187] = new SqlParameter("@flagEmplDt", dt.Rows[0]["flagEmplDt"]);

            pram[188] = new SqlParameter("@flagLastVisit", dt.Rows[0]["flagLastVisit"]);
            pram[189] = new SqlParameter("@flagLastVisitCountries", dt.Rows[0]["flagLastVisitCountries"]);
            pram[190] = new SqlParameter("@flagLastLived", dt.Rows[0]["flagLastLived"]);

            pram[191] = new SqlParameter("@SuccessId", 1);
            pram[191].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_VISA_APPLICATION_INFO_INSERT", pram);

            return (int.Parse(pram[191].Value.ToString())); // RETURN APPLICATIONID
            //    }

            //catch (Exception e)
            //{
            //    throw (e);
            //}

            //finally
            //{
            //    pram = null;
            //}

        }
        public DataSet GetVisaAppDetails(string ApplicationID)
        {
            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[2];
                pram[0] = new SqlParameter("@ApplicationID", ApplicationID);

                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspVisaApplicationInfoFetchByApplicationId", pram);
                objDs.Tables[0].TableName = "VisaApplicationInfo";

                return objDs;


            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                pram = null;
                objDs = null;
            }
        }

        public DataTable GetVisaApplicationInfo4Update(string ApplicationID)
        {
            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@ApplicationID", ApplicationID);

                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "dbo.USP_VISA_APP_INFO_FETCH_APPID", pram);
                objDs.Tables[0].TableName = "VisaApplicationInfo";

                return objDs.Tables[0];


            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                pram = null;
                objDs = null;
            }
        }

        public int UpdateVisaApplication(DataTable dt)
        {

            SqlParameter[] pram = null;

            try
            {

                pram = new SqlParameter[193];

                pram[0] = new SqlParameter("@ratecurrency", dt.Rows[0]["ratecurrency"]);
                pram[1] = new SqlParameter("@Nationality", dt.Rows[0]["Nationality"]);
                pram[2] = new SqlParameter("@PassportNo", dt.Rows[0]["PassportNo"]);
                pram[3] = new SqlParameter("@PassportType", dt.Rows[0]["PassportType"]);
                pram[4] = new SqlParameter("@Doissue", dt.Rows[0]["Doissue"]);
                pram[5] = new SqlParameter("@DoExp", dt.Rows[0]["DoExp"]);
                pram[6] = new SqlParameter("@Poissue", dt.Rows[0]["Poissue"]);
                pram[7] = new SqlParameter("@issuingauthority", dt.Rows[0]["issuingauthority"]);
                pram[8] = new SqlParameter("@fname", dt.Rows[0]["fname"]);
                pram[9] = new SqlParameter("@mname", dt.Rows[0]["mname"]);
                pram[10] = new SqlParameter("@lname", dt.Rows[0]["lname"]);
                pram[11] = new SqlParameter("@sex", dt.Rows[0]["sex"]);
                pram[12] = new SqlParameter("@dob", dt.Rows[0]["dob"]);
                pram[13] = new SqlParameter("@pob", dt.Rows[0]["pob"]);
                pram[14] = new SqlParameter("@maritalstatus", dt.Rows[0]["maritalstatus"]);
                pram[15] = new SqlParameter("@fathername", dt.Rows[0]["fathername"]);
                pram[16] = new SqlParameter("@mothername", dt.Rows[0]["mothername"]);
                pram[17] = new SqlParameter("@spousename", dt.Rows[0]["spousename"]);
                pram[18] = new SqlParameter("@currentaddress", dt.Rows[0]["currentaddress"]);
                pram[19] = new SqlParameter("@permanentaddress", dt.Rows[0]["permanentaddress"]);
                pram[20] = new SqlParameter("@mobilenumber", dt.Rows[0]["mobilenumber"]);
                pram[21] = new SqlParameter("@landlinenumber", dt.Rows[0]["landlinenumber"]);
                pram[22] = new SqlParameter("@primaryemail", dt.Rows[0]["primaryemail"]);
                pram[23] = new SqlParameter("@alternateemail", dt.Rows[0]["alternateemail"]);
                pram[24] = new SqlParameter("@presentoccupation", dt.Rows[0]["presentoccupation"]);
                pram[25] = new SqlParameter("@country", dt.Rows[0]["country"]);
                pram[26] = new SqlParameter("@VisaType", dt.Rows[0]["VisaType"]);
                pram[27] = new SqlParameter("@EntryType", dt.Rows[0]["EntryType"]);
                pram[28] = new SqlParameter("@periodtype", dt.Rows[0]["periodtype"]);
                pram[29] = new SqlParameter("@Duration", dt.Rows[0]["Duration"]);
                pram[30] = new SqlParameter("@rate", dt.Rows[0]["rate"]);
                pram[31] = new SqlParameter("@ArivalDate", dt.Rows[0]["ArivalDate"]);
                pram[32] = new SqlParameter("@DepDat", dt.Rows[0]["DepDate"]);
                pram[33] = new SqlParameter("@burundiaddress", dt.Rows[0]["burundiaddress"]);
                pram[34] = new SqlParameter("@psb", dt.Rows[0]["psb"]);
                pram[35] = new SqlParameter("@severaljourney", dt.Rows[0]["severaljourney"]);
                pram[36] = new SqlParameter("@returnticket", dt.Rows[0]["returnticket"]);
                pram[37] = new SqlParameter("@EntryPoint", dt.Rows[0]["EntryPoint"]);
                pram[38] = new SqlParameter("@ExitPoint", dt.Rows[0]["ExitPoint"]);
                pram[39] = new SqlParameter("@logobrowser", dt.Rows[0]["logobrowser"]);
                pram[40] = new SqlParameter("@appliedBy", dt.Rows[0]["appliedBy"]);
                pram[41] = new SqlParameter("@appliedByUserId", dt.Rows[0]["appliedByUserId"]);
                pram[42] = new SqlParameter("@createdBy", dt.Rows[0]["createdBy"]);
                pram[43] = new SqlParameter("@Status", dt.Rows[0]["Status"]);

                pram[44] = new SqlParameter("@EmployerName", dt.Rows[0]["EmployerName"]);
                pram[45] = new SqlParameter("@JobDesc", dt.Rows[0]["JobDesc"]);
                pram[46] = new SqlParameter("@OcuPossition", dt.Rows[0]["OcuPossition"]);

                pram[47] = new SqlParameter("@MoneyForTravellUSD", dt.Rows[0]["MoneyForTravellUSD"]);
                pram[48] = new SqlParameter("@ModeOfTravel", dt.Rows[0]["ModeOfTravel"]);
                pram[49] = new SqlParameter("@IntededDuration", dt.Rows[0]["IntededDuration"]);

                pram[50] = new SqlParameter("@flagPrevApplied", dt.Rows[0]["flagPrevApplied"]);
                pram[51] = new SqlParameter("@flagPrevVisit", dt.Rows[0]["flagPrevVisit"]);
                pram[52] = new SqlParameter("@flagVisaGranted", dt.Rows[0]["flagVisaGranted"]);
                pram[53] = new SqlParameter("@PrevAppliedVisaPlace", dt.Rows[0]["PrevAppliedVisaPlace"]);
                pram[54] = new SqlParameter("@PrevVisitReason", dt.Rows[0]["PrevVisitReason"]);
                pram[55] = new SqlParameter("@PrevVisaRejReason", dt.Rows[0]["PrevVisaRejReason"]);

                pram[56] = new SqlParameter("@PreVisit1FromDate", dt.Rows[0]["PreVisit1FromDate"]);
                pram[57] = new SqlParameter("@PreVisit1ToDate", dt.Rows[0]["PreVisit1ToDate"]);
                pram[58] = new SqlParameter("@PreVisit1Addr1", dt.Rows[0]["PreVisit1Addr1"]);
                pram[59] = new SqlParameter("@PreVisit1Addr2", dt.Rows[0]["PreVisit1Addr2"]);
                pram[60] = new SqlParameter("@PreVisit1City", dt.Rows[0]["PreVisit1City"]);
                pram[61] = new SqlParameter("@PreVisit1State", dt.Rows[0]["PreVisit1State"]);
                pram[62] = new SqlParameter("@PreVisit1District", dt.Rows[0]["PreVisit1District"]);
                pram[63] = new SqlParameter("@PreVisit1Postcode", dt.Rows[0]["PreVisit1Postcode"]);

                pram[64] = new SqlParameter("@PreVisit2FromDate", dt.Rows[0]["PreVisit2FromDate"]);
                pram[65] = new SqlParameter("@PreVisit2ToDate", dt.Rows[0]["PreVisit2ToDate"]);
                pram[66] = new SqlParameter("@PreVisit2Addr1", dt.Rows[0]["PreVisit2Addr1"]);
                pram[67] = new SqlParameter("@PreVisit2Addr2", dt.Rows[0]["PreVisit2Addr2"]);
                pram[68] = new SqlParameter("@PreVisit2City", dt.Rows[0]["PreVisit2City"]);
                pram[69] = new SqlParameter("@PreVisit2State", dt.Rows[0]["PreVisit2State"]);
                pram[70] = new SqlParameter("@PreVisit2District", dt.Rows[0]["PreVisit2District"]);
                pram[71] = new SqlParameter("@PreVisit2Postcode", dt.Rows[0]["PreVisit2Postcode"]);

                pram[72] = new SqlParameter("@PreVisit3FromDate", dt.Rows[0]["PreVisit3FromDate"]);
                pram[73] = new SqlParameter("@PreVisit3ToDate", dt.Rows[0]["PreVisit3ToDate"]);
                pram[74] = new SqlParameter("@PreVisit3Addr1", dt.Rows[0]["PreVisit3Addr1"]);
                pram[75] = new SqlParameter("@PreVisit3Addr2", dt.Rows[0]["PreVisit3Addr2"]);
                pram[76] = new SqlParameter("@PreVisit3City", dt.Rows[0]["PreVisit3City"]);
                pram[77] = new SqlParameter("@PreVisit3State", dt.Rows[0]["PreVisit3State"]);
                pram[78] = new SqlParameter("@PreVisit3District", dt.Rows[0]["PreVisit3District"]);
                pram[79] = new SqlParameter("@PreVisit3Postcode", dt.Rows[0]["PreVisit3Postcode"]);

                pram[80] = new SqlParameter("@ColorHair", dt.Rows[0]["ColorHair"]);
                pram[81] = new SqlParameter("@ColorEye", dt.Rows[0]["ColorEye"]);
                pram[82] = new SqlParameter("@IndentityMark", dt.Rows[0]["IndentityMark"]);
                pram[83] = new SqlParameter("@Height", dt.Rows[0]["Height"]);

                pram[84] = new SqlParameter("@InMilitary", dt.Rows[0]["InMilitary"]);
                pram[85] = new SqlParameter("@FromDate", dt.Rows[0]["FromDate"]);
                pram[86] = new SqlParameter("@ToDate", dt.Rows[0]["ToDate"]);

                pram[87] = new SqlParameter("@EmpName", dt.Rows[0]["EmpName"]);
                pram[88] = new SqlParameter("@EmpPhoneNo", dt.Rows[0]["EmpPhoneNo"]);
                pram[89] = new SqlParameter("@EmpLivedFrom", dt.Rows[0]["EmpLivedFrom"]);
                pram[90] = new SqlParameter("@Address1", dt.Rows[0]["Address1"]);
                pram[91] = new SqlParameter("@Address2", dt.Rows[0]["Address2"]);
                pram[92] = new SqlParameter("@EmpCity", dt.Rows[0]["EmpCity"]);
                pram[93] = new SqlParameter("@EmpState", dt.Rows[0]["EmpState"]);
                pram[94] = new SqlParameter("@EmpPostCode", dt.Rows[0]["EmpPostCode"]);

                pram[95] = new SqlParameter("@IntedAddress1", dt.Rows[0]["IntedAddress1"]);
                pram[96] = new SqlParameter("@IntedAddress2", dt.Rows[0]["IntedAddress2"]);
                pram[97] = new SqlParameter("@IntedCity", dt.Rows[0]["IntedCity"]);
                pram[98] = new SqlParameter("@IntedState", dt.Rows[0]["IntedState"]);
                pram[99] = new SqlParameter("@IntedDistrict", dt.Rows[0]["IntedDistrict"]);
                pram[100] = new SqlParameter("@IntedPostcode", dt.Rows[0]["IntedPostcode"]);

                pram[101] = new SqlParameter("@ApplyCountryYears", dt.Rows[0]["ApplyCountryYears"]);
                pram[102] = new SqlParameter("@FlagSeriousDisease", dt.Rows[0]["FlagSeriousDisease"]);
                pram[103] = new SqlParameter("@FlagCrimeRecord", dt.Rows[0]["FlagCrimeRecord"]);
                pram[104] = new SqlParameter("@FlagDrugReport", dt.Rows[0]["FlagDrugReport"]);
                pram[105] = new SqlParameter("@FlagDeported", dt.Rows[0]["FlagDeported"]);
                pram[106] = new SqlParameter("@FlagFraudRecord", dt.Rows[0]["FlagFraudRecord"]);

                pram[107] = new SqlParameter("@CountryCode1", dt.Rows[0]["CountryCode1"]);
                pram[108] = new SqlParameter("@CityName1", dt.Rows[0]["CityName1"]);
                pram[109] = new SqlParameter("@DepartureDate1", dt.Rows[0]["DepartureDate1"]);
                pram[110] = new SqlParameter("@CountryCode2", dt.Rows[0]["CountryCode2"]);
                pram[111] = new SqlParameter("@CityName2", dt.Rows[0]["CityName2"]);
                pram[112] = new SqlParameter("@DepartureDate2", dt.Rows[0]["DepartureDate2"]);
                pram[113] = new SqlParameter("@CountryCode3", dt.Rows[0]["CountryCode3"]);
                pram[114] = new SqlParameter("@CityName3", dt.Rows[0]["CityName3"]);
                pram[115] = new SqlParameter("@DepartureDate3", dt.Rows[0]["DepartureDate3"]);

                pram[116] = new SqlParameter("@LastLivedCountryCode1", dt.Rows[0]["LastLivedCountryCode1"]);
                pram[117] = new SqlParameter("@LastLivedCityName1", dt.Rows[0]["LastLivedCityName1"]);
                pram[118] = new SqlParameter("@LastLivedDepartureDate1", dt.Rows[0]["LastLivedDepartureDate1"]);
                pram[119] = new SqlParameter("@LastLivedCountryCode2", dt.Rows[0]["LastLivedCountryCode2"]);
                pram[120] = new SqlParameter("@LastLivedCityName2", dt.Rows[0]["LastLivedCityName2"]);
                pram[121] = new SqlParameter("@LastLivedDepartureDate2", dt.Rows[0]["LastLivedDepartureDate2"]);
                pram[122] = new SqlParameter("@LastLivedCountryCode3", dt.Rows[0]["LastLivedCountryCode3"]);
                pram[123] = new SqlParameter("@LastLivedCityName3", dt.Rows[0]["LastLivedCityName3"]);
                pram[124] = new SqlParameter("@LastLivedDepartureDate3", dt.Rows[0]["LastLivedDepartureDate3"]);

                pram[125] = new SqlParameter("@flagFastTrack", dt.Rows[0]["flagFastTrack"]);

                pram[126] = new SqlParameter("@OtherName", dt.Rows[0]["OtherName"]);

                pram[127] = new SqlParameter("@FatherLastName", dt.Rows[0]["FatherLastName"]);
                pram[128] = new SqlParameter("@FatherDateOfBirth", dt.Rows[0]["FatherDateOfBirth"]);
                pram[129] = new SqlParameter("@FatherAddress", dt.Rows[0]["FatherAddress"]);
                pram[130] = new SqlParameter("@FatherNationality", dt.Rows[0]["FatherNationality"]);

                pram[131] = new SqlParameter("@MotherLastName", dt.Rows[0]["MotherLastName"]);
                pram[132] = new SqlParameter("@MotherDateOfBirth", dt.Rows[0]["MotherDateOfBirth"]);
                pram[133] = new SqlParameter("@MotherAddress", dt.Rows[0]["MotherAddress"]);
                pram[134] = new SqlParameter("@MotherNationality", dt.Rows[0]["MotherNationality"]);


                pram[135] = new SqlParameter("@OldPaasportIssueDate", dt.Rows[0]["OldPaasportIssueDate"]);
                pram[136] = new SqlParameter("@PlaceIssueOldPassport", dt.Rows[0]["PlaceIssueOldPassport"]);

                pram[137] = new SqlParameter("@currAddress2", dt.Rows[0]["currAddress2"]);
                pram[138] = new SqlParameter("@City", dt.Rows[0]["City"]);
                pram[139] = new SqlParameter("@State", dt.Rows[0]["State"]);
                pram[140] = new SqlParameter("@District", dt.Rows[0]["District"]);
                pram[141] = new SqlParameter("@Postcode", dt.Rows[0]["Postcode"]);
                pram[142] = new SqlParameter("@CurrentCountry", dt.Rows[0]["CurrentCountry"]);
                pram[143] = new SqlParameter("@LivedInCurrentAdd", dt.Rows[0]["LivedInCurrentAdd"]);

                pram[144] = new SqlParameter("@PerAddres2", dt.Rows[0]["PerAddres2"]);
                pram[145] = new SqlParameter("@PerCity", dt.Rows[0]["PerCity"]);
                pram[146] = new SqlParameter("@PerState", dt.Rows[0]["PerState"]);
                pram[147] = new SqlParameter("@PerPostcode", dt.Rows[0]["PerPostcode"]);
                pram[148] = new SqlParameter("@PerDistrict", dt.Rows[0]["PerDistrict"]);
                pram[149] = new SqlParameter("@PerCountry", dt.Rows[0]["PerCountry"]);

                pram[150] = new SqlParameter("@CurrentLocation", dt.Rows[0]["CurrentLocation"]);

                pram[151] = new SqlParameter("@flagOtherNationality", dt.Rows[0]["flagOtherNationality"]);
                pram[152] = new SqlParameter("@OtherNationality", dt.Rows[0]["OtherNationality"]);

                pram[153] = new SqlParameter("@DateRejected", dt.Rows[0]["DateRejected"]);
                pram[154] = new SqlParameter("@LastRejectedVisaType", dt.Rows[0]["LastRejectedVisaType"]);
                pram[155] = new SqlParameter("@flagRejeAppeal", dt.Rows[0]["flagRejeAppeal"]);
                pram[156] = new SqlParameter("@RejectedAppDiffer", dt.Rows[0]["RejectedAppDiffer"]);

                pram[157] = new SqlParameter("@flagRefusedAnyCountry", dt.Rows[0]["flagRefusedAnyCountry"]);
                pram[158] = new SqlParameter("@RefusedAnyCountry", dt.Rows[0]["RefusedAnyCountry"]);

                pram[159] = new SqlParameter("@flagRefuseEntryOnArrival", dt.Rows[0]["flagRefuseEntryOnArrival"]);
                pram[160] = new SqlParameter("@RefusedVisaOnArrivalPlace", dt.Rows[0]["RefusedVisaOnArrivalPlace"]);
                pram[161] = new SqlParameter("@RefusedVisaOnArrivalDate", dt.Rows[0]["RefusedVisaOnArrivalDate"]);
                pram[162] = new SqlParameter("@flagRefusedVisArriAppeal", dt.Rows[0]["flagRefusedVisArriAppeal"]);
                pram[163] = new SqlParameter("@RefusedVisArriAppOutcome", dt.Rows[0]["RefusedVisArriAppOutcome"]);
                pram[164] = new SqlParameter("@RefusedVisaOnArrivalReason", dt.Rows[0]["RefusedVisaOnArrivalReason"]);

                pram[165] = new SqlParameter("@Disease", dt.Rows[0]["Disease"]);

                pram[166] = new SqlParameter("@CrimeRecord", dt.Rows[0]["CrimeRecord"]);
                pram[167] = new SqlParameter("@ConvictionDate", dt.Rows[0]["ConvictionDate"]);
                pram[168] = new SqlParameter("@ConvictedPlace", dt.Rows[0]["ConvictedPlace"]);
                pram[169] = new SqlParameter("@Sentence", dt.Rows[0]["Sentence"]);

                pram[170] = new SqlParameter("@flagConvictionInOtherCountry", dt.Rows[0]["flagConvictionInOtherCountry"]);
                pram[171] = new SqlParameter("@ConvictionInOtherCountry", dt.Rows[0]["ConvictionInOtherCountry"]);
                pram[172] = new SqlParameter("@DrugReport", dt.Rows[0]["DrugReport"]);


                pram[173] = new SqlParameter("@DeportedNoticeDate", dt.Rows[0]["DeportedNoticeDate"]);
                pram[174] = new SqlParameter("@DeportedNoticeType", dt.Rows[0]["DeportedNoticeType"]);
                pram[175] = new SqlParameter("@DeportedLeave", dt.Rows[0]["DeportedLeave"]);
                pram[176] = new SqlParameter("@DeportedAppealeddetails", dt.Rows[0]["DeportedAppealeddetails"]);

                pram[177] = new SqlParameter("@flagDeportedOtherCountry", dt.Rows[0]["flagDeportedOtherCountry"]);
                pram[178] = new SqlParameter("@DeportedOtherCountry", dt.Rows[0]["DeportedOtherCountry"]);

                pram[179] = new SqlParameter("@FraudRecord", dt.Rows[0]["FraudRecord"]);
                pram[180] = new SqlParameter("@OldPassport", dt.Rows[0]["OldPassport"]);
                pram[181] = new SqlParameter("@flagComplete", dt.Rows[0]["flagComplete"]);
                pram[182] = new SqlParameter("@flagFreshPassport", dt.Rows[0]["flagFreshPassport"]);
                pram[183] = new SqlParameter("@flagCuurContactDetails", dt.Rows[0]["flagCuurContactDetails"]);
                pram[184] = new SqlParameter("@EmbassyId", dt.Rows[0]["EmbassyId"]);
                pram[185] = new SqlParameter("@flagInMillitary", dt.Rows[0]["flagInMillitary"]);
                pram[186] = new SqlParameter("@flagEmployement", dt.Rows[0]["flagEmployement"]);
                pram[187] = new SqlParameter("@flagEmplDt", dt.Rows[0]["flagEmplDt"]);
                pram[188] = new SqlParameter("@flagLastVisit", dt.Rows[0]["flagLastVisit"]);
                pram[189] = new SqlParameter("@flagLastVisitCountries", dt.Rows[0]["flagLastVisitCountries"]);
                pram[190] = new SqlParameter("@flagLastLived", dt.Rows[0]["flagLastLived"]);

                pram[191] = new SqlParameter("@ApplicationID", dt.Rows[0]["ApplicationID"]);

                pram[192] = new SqlParameter("@SuccessId", 1);
                pram[192].Direction = ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_VISA_APPLICATION_INFO_UPDATE", pram);

                return (int.Parse(pram[192].Value.ToString())); // RETURN APPLICATIONID
            }

            catch (Exception e)
            {
                throw (e);
            }

            finally
            {
                pram = null;
            }

        }
        //--------------------------------------By chitresh------------------------

        public DataSet GetVisaAppDocDetails(string ApplicationID)
        {
            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[2];
                pram[0] = new SqlParameter("@ApplicationID", ApplicationID);

                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspVisaApplicationDocInfoFetchByApplicationId", pram);
                objDs.Tables[0].TableName = "VisaApplicationInfo";

                return objDs;


            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                pram = null;
                objDs = null;
            }
        }
        public DataTable GetDocForPrint(string strApplicationId)
        {
            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[2];
                pram[0] = new SqlParameter("@ApplicationID", strApplicationId);

                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspVisaApplicationDocInfoFetchByApplicationIdForPrint", pram);
                objDs.Tables[0].TableName = "VisaApplicationInfo";

                return objDs.Tables[0];


            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                pram = null;
                objDs = null;
            }
        }
        //-------------------------------------end-------------------------



        public int InsertAttachedDocs(DataTable dt)
        {
            SqlParameter[] pram = null;

            try
            {

                pram = new SqlParameter[4];

                pram[0] = new SqlParameter("@ApplicationId", dt.Rows[0]["ApplicationId"]);
                pram[1] = new SqlParameter("@filename", dt.Rows[0]["filename"]);
                pram[2] = new SqlParameter("@DocCode", dt.Rows[0]["DocCode"]);
                pram[3] = new SqlParameter("@SuccessId", 1);
                pram[3].Direction = ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_INSERT_ATTACHED_DOCS", pram);

                return (int.Parse(pram[3].Value.ToString()));
            }

            catch (Exception e)
            {
                throw (e);
            }

            finally
            {
                pram = null;
            }
        }

        public int UpdateAttachedDocs(DataTable dt)
        {
            SqlParameter[] pram = null;

            try
            {

                pram = new SqlParameter[4];

                pram[0] = new SqlParameter("@ApplicationId", dt.Rows[0]["ApplicationId"]);
                pram[1] = new SqlParameter("@filename", dt.Rows[0]["filename"]);
                pram[2] = new SqlParameter("@DocCode", dt.Rows[0]["DocCode"]);
                pram[3] = new SqlParameter("@SuccessId", 1);
                pram[3].Direction = ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_UPDATE_ATTACHED_DOCS", pram);

                return (int.Parse(pram[3].Value.ToString()));
            }

            catch (Exception e)
            {
                throw (e);
            }

            finally
            {
                pram = null;
            }
        }

        public int UpdateFlagPayment(DataTable dt)
        {
            SqlParameter[] pram = null;

            try
            {
                pram = new SqlParameter[3];

                pram[0] = new SqlParameter("@ApplicationId", dt.Rows[0]["ApplicationId"]);
                pram[1] = new SqlParameter("@PaymentReceiptNo", dt.Rows[0]["PaymentReceiptNo"]);
                pram[2] = new SqlParameter("@SuccessId", 1);
                pram[2].Direction = ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USPVisaApplicationPaymentFlagUpdate", pram);

                return (int.Parse(pram[2].Value.ToString()));
            }

            catch (Exception e)
            {
                throw (e);
            }

            finally
            {
                pram = null;
            }
        }
    }
}
