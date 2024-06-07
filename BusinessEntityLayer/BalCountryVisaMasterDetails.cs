using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace BusinessEntityLayer
{
    public class BalCountryVisaMasterDetails
    {
        #region Automatic Property

        public int CountryVisaId { get; set; }
        public string COUNTRYCODE { get; set; }
        public string VISATYPE { get; set; }
        public string ENTRYTYPE { get; set; }
        public string PERIODTYPE { get; set; }
        public string PERIOD { get; set; }
        public string RATE { get; set; }
        public string RATEEFFECTIVEDATE { get; set; }
        public string RATECURRENCYCODE { get; set; }
        public string COMMISION { get; set; }
        public string COMMISIONEFFECTIVEDATE { get; set; }
        public string COMMISIONCURRENCYCODE { get; set; }
        public string STATUS { get; set; }
        public int CREATEDBY { get; set; }
        public int MODIFIEDBY { get; set; }
        public int ApproverLevel { get; set; }
        public int VisaTypeForApplicant { get; set; }


        # endregion

        #region Class objects

        DataAccessLayer.DalCountryVisaMasterDetails objDalCountryVisaMaster = null;
        DataTable DtVisa = null;
        # endregion

        public int InsertCountryVisaMasterDetails()
        {



            try
            {
                objDalCountryVisaMaster = new DataAccessLayer.DalCountryVisaMasterDetails();
                DtVisa = new DataTable();
                DataRow Dr = DtVisa.NewRow();

                DtVisa.Columns.Add("COUNTRYCODE");
                DtVisa.Columns.Add("VISATYPE");
                DtVisa.Columns.Add("ENTRYTYPE");
                DtVisa.Columns.Add("PERIODTYPE");
                DtVisa.Columns.Add("PERIOD");
                DtVisa.Columns.Add("RATE");
                DtVisa.Columns.Add("RATECURRENCYCODE");
                DtVisa.Columns.Add("RATEEFFECTIVEDATE");
                DtVisa.Columns.Add("COMMISION");
                DtVisa.Columns.Add("COMMISIONCURRENCYCODE");
                DtVisa.Columns.Add("COMMISIONEFFECTIVEDATE");
                DtVisa.Columns.Add("CREATEDBY");
                DtVisa.Columns.Add("ApproverLevel");
                DtVisa.Columns.Add("VisaTypeForApplicant");

                Dr["COUNTRYCODE"] = this.COUNTRYCODE;
                Dr["VISATYPE"] = this.VISATYPE;
                Dr["ENTRYTYPE"] = this.ENTRYTYPE;
                Dr["PERIODTYPE"] = this.PERIODTYPE;
                Dr["PERIOD"] = this.PERIOD;
                Dr["RATE"] = this.RATE;
                Dr["RATECURRENCYCODE"] = this.RATECURRENCYCODE;
                Dr["RATEEFFECTIVEDATE"] = this.RATEEFFECTIVEDATE;
                Dr["COMMISION"] = this.COMMISION;
                Dr["COMMISIONCURRENCYCODE"] = this.COMMISIONCURRENCYCODE;
                Dr["COMMISIONEFFECTIVEDATE"] = this.COMMISIONEFFECTIVEDATE;
                Dr["CREATEDBY"] = this.CREATEDBY;
                Dr["ApproverLevel"] = this.ApproverLevel;
                Dr["VisaTypeForApplicant"] = this.VisaTypeForApplicant;

                DtVisa.Rows.Add(Dr);
                return objDalCountryVisaMaster.InsertCountryVisaMasterDetails(DtVisa);

            }
            catch (Exception Ex)
            {
                throw (Ex);
            }
            finally
            {
                objDalCountryVisaMaster = null;
                DtVisa = null;
            }
        }

        public DataTable FetchCountryVisaMasterDetailsBy_CountryVisaId()
        {
            DataAccessLayer.DalCountryVisaMasterDetails ObjDalCountryVisaMasterDetails = null;

            try
            {
                ObjDalCountryVisaMasterDetails = new DataAccessLayer.DalCountryVisaMasterDetails();
                return ObjDalCountryVisaMasterDetails.FetchCountryVisaMasterDetailsBy_CountryVisaId(this.CountryVisaId);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ObjDalCountryVisaMasterDetails = null;

            }
        }

        public int UpdateCountryVisaMasterDetails()
        {

            try
            {
                objDalCountryVisaMaster = new DataAccessLayer.DalCountryVisaMasterDetails();
                DtVisa = new DataTable();
                DataRow Dr = DtVisa.NewRow();

                DtVisa.Columns.Add("COUNTRYCODE");
                DtVisa.Columns.Add("VISATYPE");
                DtVisa.Columns.Add("ENTRYTYPE");
                DtVisa.Columns.Add("PERIODTYPE");
                DtVisa.Columns.Add("PERIOD");
                DtVisa.Columns.Add("RATE");
                DtVisa.Columns.Add("RATECURRENCYCODE");
                DtVisa.Columns.Add("RATEEFFECTIVEDATE");
                DtVisa.Columns.Add("COMMISION");
                DtVisa.Columns.Add("COMMISIONCURRENCYCODE");
                DtVisa.Columns.Add("COMMISIONEFFECTIVEDATE");
                DtVisa.Columns.Add("MODIFIEDBY");
                DtVisa.Columns.Add("CREATEDBY");
                DtVisa.Columns.Add("ApproverLevel");
                DtVisa.Columns.Add("VisaTypeForApplicant");

                Dr["COUNTRYCODE"] = this.COUNTRYCODE;
                Dr["VISATYPE"] = this.VISATYPE;
                Dr["ENTRYTYPE"] = this.ENTRYTYPE;
                Dr["PERIODTYPE"] = this.PERIODTYPE;
                Dr["PERIOD"] = this.PERIOD;
                Dr["RATE"] = this.RATE;
                Dr["RATECURRENCYCODE"] = this.RATECURRENCYCODE;
                Dr["RATEEFFECTIVEDATE"] = this.RATEEFFECTIVEDATE;
                Dr["COMMISION"] = this.COMMISION;
                Dr["COMMISIONCURRENCYCODE"] = this.COMMISIONCURRENCYCODE;
                Dr["COMMISIONEFFECTIVEDATE"] = this.COMMISIONEFFECTIVEDATE;
                Dr["MODIFIEDBY"] = this.MODIFIEDBY;
                Dr["CREATEDBY"] = this.CREATEDBY;
                Dr["ApproverLevel"] = this.ApproverLevel;
                Dr["VisaTypeForApplicant"] = this.VisaTypeForApplicant;

                DtVisa.Rows.Add(Dr);
                return objDalCountryVisaMaster.UpdateCountryVisaMasterDetails(DtVisa);

            }
            catch (Exception Ex)
            {
                throw (Ex);
            }
            finally
            {
                objDalCountryVisaMaster = null;
                DtVisa = null;
            }
        }

        public int DeleteDataRow(string keyvalue)
        {
            objDalCountryVisaMaster = new DataAccessLayer.DalCountryVisaMasterDetails();
            return objDalCountryVisaMaster.DeleteDataRow(keyvalue);
        }

    }
}
