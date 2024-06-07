using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace BusinessEntityLayer
{
   public class BalCompanyRegistration
    {

        //-----------Item Company Master Details----------------
        public String LoginID { get; set; }
        public String Password { get; set; }
        public String CompanyName { get; set; }
        public String Opt { get; set; }
        public String PersonEmailID { get; set; }
        public String Director { get; set; }
        public String Address { get; set; }
        public String Phone { get; set; }
        public String ContactPerson { get; set; }
        public String DOI { get; set; }
        public String Designation { get; set; }
        public String MobileNo { get; set; }
        public String PrimaryEmailID { get; set; }
        public int CreatedBy { get; set; }
        public String Path { get; set; }
       //  public String InvoiceNo { get; set; }
        //public int CreatedBy { get; set; }
        //public int CodeFrom { get; set; }
        //public int CodeTo { get; set; }
        //public string LStr { get; set; }

       DataAccessLayer.DalCompanyRegistration  ObjDalComReg = null;
        DataTable dt = null;
        public int ComRegInsert()
        {
            ObjDalComReg = new DataAccessLayer.DalCompanyRegistration();
            
            dt = new DataTable();

            DataRow dr = dt.NewRow();
            dt.Columns.Add("LoginID");
            dt.Columns.Add("Password");
            dt.Columns.Add("PersonEmailID");
            dt.Columns.Add("CompanyName");
            dt.Columns.Add("Director");
            
            dt.Columns.Add("Address");
            dt.Columns.Add("Phone");
            dt.Columns.Add("ContactPerson");
            dt.Columns.Add("DOI");
            dt.Columns.Add("Designation");

            dt.Columns.Add("MobileNo");
            dt.Columns.Add("EMailID");
            dt.Columns.Add("Path");
            dt.Columns.Add("CreatedBy");
            dt.Columns.Add("Opt");
            
            dr["LoginID"] = this.LoginID;
            dr["Password"] = this.Password;
            dr["PersonEmailID"] = this.PersonEmailID;
            dr["CompanyName"] = this.CompanyName;
            dr["Director"] = this.Director;
            
            dr["Address"] = this.Address;
            dr["Phone"] = this.Phone;
            dr["ContactPerson"] = this.ContactPerson;
            dr["DOI"] = this.DOI;
            dr["Designation"] = this.Designation;

            dr["MobileNo"] = this.MobileNo;
            dr["EMailID"] = this.PrimaryEmailID;
            dr["Path"] = this.Path;
            dr["CreatedBy"] = this.CreatedBy;
            dr["Opt"] = this.Opt;
            
            dt.Rows.Add(dr);

            return ObjDalComReg.ComRegInser(dt);
        }

       //-------------Delete Company Master------------

        public String CompanyID { get; set; }
       
        // public int CreatedBy { get; set; }
        // public String WorkAreaI { get; set; }


        DataAccessLayer.DalCompanyRegistration ObjDalDel = null;
        DataTable dtDel = null;
        public int DelCompany()
        {

            ObjDalDel = new DataAccessLayer.DalCompanyRegistration();
            dtDel = new DataTable();
            DataRow dr = dtDel.NewRow();

            dtDel.Columns.Add("CompanyID");
            dtDel.Columns.Add("Opt");

            dr["CompanyID"] = this.CompanyID;
            dr["Opt"] = this.Opt;

            dtDel.Rows.Add(dr);
            return ObjDalDel.DelCompany(dtDel);


        }

       //---------------Update Company Registration Details--------------
        DataAccessLayer.DalCompanyRegistration ObjDalUpdate= null;
        DataTable dtU = null;
        public int UpDateCompany()
        {
            ObjDalUpdate = new DataAccessLayer.DalCompanyRegistration();

            dtU = new DataTable();

            DataRow dr = dtU.NewRow();
            dtU.Columns.Add("LoginID");
            dtU.Columns.Add("Password");
            dtU.Columns.Add("PersonEmailID");
            dtU.Columns.Add("CompanyName");
            dtU.Columns.Add("Director");

            dtU.Columns.Add("Address");
            dtU.Columns.Add("Phone");
            dtU.Columns.Add("ContactPerson");
            dtU.Columns.Add("DOI");
            dtU.Columns.Add("Designation");

            dtU.Columns.Add("MobileNo");
            dtU.Columns.Add("EMailID");
            dtU.Columns.Add("Path");
            dtU.Columns.Add("CreatedBy");
            dtU.Columns.Add("Opt");

            dr["LoginID"] = this.LoginID;
            dr["Password"] = this.Password;
            dr["PersonEmailID"] = this.PersonEmailID;
            dr["CompanyName"] = this.CompanyName;
            dr["Director"] = this.Director;

            dr["Address"] = this.Address;
            dr["Phone"] = this.Phone;
            dr["ContactPerson"] = this.ContactPerson;
            dr["DOI"] = this.DOI;
            dr["Designation"] = this.Designation;

            dr["MobileNo"] = this.MobileNo;
            dr["EMailID"] = this.PrimaryEmailID;
            dr["Path"] = this.Path;
            dr["CreatedBy"] = this.CreatedBy;
            dr["Opt"] = this.Opt;

            dtU.Rows.Add(dr);

            return ObjDalUpdate.UpDateCompany(dtU);
        }
    }
}
