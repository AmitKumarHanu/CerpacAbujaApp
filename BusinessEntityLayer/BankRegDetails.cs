using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;

namespace BusinessEntityLayer
{
    public class BankRegDetails
    {
        public string BankLoginid { get; set; }
        public string BankName { get; set; }        
        public string Password { get; set; }
        public string BranchName { get; set; }
        public string BankAddress { get; set; }
        public string Email { get; set; }        
        public string City { get; set; }
        public string Country { get; set; }

        public string ContactPerson { get; set; }
        public string ContactPersonEmail { get; set; }
        public string ContactPersonMobile { get; set; }


        /***************** BankFileUpload *********************/

        public string BankDate { get; set; }
        public string Branch { get; set; }
        public string ReqNo { get; set; }
        public string PassportNo { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Nationality { get; set; }
        public string CerpacNo { get; set; }
        public string FormNo { get; set; }
        public string TellerNo { get; set; }
        public decimal Amount { get; set; }
        public string StrVisaNo { get; set; }
        public int CreatedBy { get; set; }
        public int Condition { get; set; }

        
        public int BankRegistration()
        {
            DataAccessLayer.DalBankRegDetails obj=new DataAccessLayer.DalBankRegDetails();
            return obj.BankRegistration(BankLoginid, BankName, Password, BranchName, BankAddress, Email, City, Country, ContactPerson, ContactPersonEmail, ContactPersonMobile);
        }

        public int BankDetailsUpload()
        {
            DataAccessLayer.DalBankRegDetails obj = new DataAccessLayer.DalBankRegDetails();
            return obj.BankUploadVerifiedData(BankDate, Branch, ReqNo, PassportNo, FirstName, MiddleName, LastName, Company, Nationality, FormNo, TellerNo, Amount, CreatedBy, CerpacNo,StrVisaNo,Condition);
        }
    }
}
