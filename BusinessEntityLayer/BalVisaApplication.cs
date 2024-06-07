using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BusinessEntityLayer
{
    public class BalVisaApplication
    {
        #region public property

        
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
        public string rate { get; set; }
        public string ArivalDate { get; set; }
        public string DepDate { get; set; }
        public string burundiaddress { get; set; }
        public string psb { get; set; }
        public int severaljourney { get; set; }
        public int returnticket { get; set; }
        public string Amount { get; set; }
        public string EntryPoint { get; set; }
        public string ExitPoint { get; set; }


        #endregion
        public DataTable GetVisaAppsubmit(string strtyp)
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

                dt.Rows.Add(dr);

                objSubmit.GetVisaAppsubmit(dt);


                return dt;

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
