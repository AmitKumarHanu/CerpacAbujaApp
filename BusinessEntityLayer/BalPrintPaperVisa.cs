using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BusinessEntityLayer
{
   public class BalPrintPaperVisa
    {
       public DataTable GetApprovedVisaDetail(string Applicant)
       {
           DataAccessLayer.DalPrintPaperVisa objDalPrintVisa = null;
           DataTable dt = null;
           dt = new DataTable();

           try
           {
               objDalPrintVisa = new DataAccessLayer.DalPrintPaperVisa();
               return dt = objDalPrintVisa.GetApprovedVisaDetailDL(Applicant);


           }
           catch (Exception ex)
           {
               throw (ex);
           }

           finally
           {
               objDalPrintVisa = null;
           }
       }


       public int UpadatePaperVisaStatus(string Applicant)
       {
           DataAccessLayer.DalPrintPaperVisa objDalPrintVisa = null;
           DataTable dt = null;
           dt = new DataTable();

           try
           {
               objDalPrintVisa = new DataAccessLayer.DalPrintPaperVisa();
              return objDalPrintVisa.UpadatePaperVisaStatusDL(Applicant);
               


           }
           catch (Exception ex)
           {
               throw (ex);
           }

           finally
           {
               objDalPrintVisa = null;
           }
       }
       public int ApplicationId { get; set; }

       public string ghostimage { get; set; }

       public string qrcode { get; set; }

       public int insertencryptdata()
       {
           DataAccessLayer.DalPrintPaperVisa objdalencryptdata = null;
           DataTable dt = null;

           try
           {
               objdalencryptdata = new DataAccessLayer.DalPrintPaperVisa();
               dt = new DataTable();

               DataRow dr = dt.NewRow();

               dt.Columns.Add("ApplicationId");
               dt.Columns.Add("ghostimage");
               dt.Columns.Add("qrcode");



               dr["ApplicationId"] = this.ApplicationId;
               dr["ghostimage"] = this.ghostimage;
               dr["qrcode"] = this.qrcode;


               dt.Rows.Add(dr);
               return objdalencryptdata.insertencryptdata(dt);
           }
           catch (Exception ex)
           {
               throw (ex);
           }
       }
    }
}
