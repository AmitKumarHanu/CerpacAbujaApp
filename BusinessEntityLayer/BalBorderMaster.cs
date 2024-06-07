using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace BusinessEntityLayer
{
   public class BalBorderMaster
   {

       #region public property
       public int BorderId { get; set; }
       public string CountryCode { get; set; }
       public string CityCode { get; set; }
       public string BorderCode { get; set; }
       public string BorderName	 { get; set; }
       public string Status { get; set; }
       public string CreatedOn {get; set;}
       public int CreatedBy {get; set;}
       public string ModifiedOn {get; set;}    
       public string ModifiedBy {get; set; }

       #endregion

       public DataSet GetBorderInfo()
       {
           DataAccessLayer.DalBorderMaster objBorder = null;
           try
           {
               objBorder = new DataAccessLayer.DalBorderMaster();
               return objBorder.GetBorderInfo(this.BorderId);
           }
           catch (Exception e)
           {
               throw (e);
           }
           finally
           {
               objBorder = null;
           }

       }

       public int InsertBorderMaster()
       {
           DataAccessLayer.DalBorderMaster objDalBorderMaster = null;
           DataTable dtBorderMaster = null;

           try
           {
               objDalBorderMaster = new DataAccessLayer.DalBorderMaster();
               dtBorderMaster = new DataTable();

               DataRow drBorderMaster = dtBorderMaster.NewRow();
               dtBorderMaster.Columns.Add("CountryCode");
               dtBorderMaster.Columns.Add("CityCode");
               dtBorderMaster.Columns.Add("BorderCode");
               dtBorderMaster.Columns.Add("BorderName");
               dtBorderMaster.Columns.Add("CreatedBy");
               dtBorderMaster.Columns.Add("Status");

               drBorderMaster["CountryCode"] = this.CountryCode;
               drBorderMaster["CityCode"] = this.CityCode;
               drBorderMaster["BorderCode"] = this.BorderCode;
               drBorderMaster["BorderName"] = this.BorderName;
               drBorderMaster["CreatedBy"] = this.CreatedBy;
               drBorderMaster["Status"] = this.Status;

               dtBorderMaster.Rows.Add(drBorderMaster);

               return objDalBorderMaster.InsertBorderMaster(dtBorderMaster);
           }
           catch (Exception ex)
           {
               throw (ex);
           }
           finally
           {
               objDalBorderMaster = null;
               dtBorderMaster = null;
           }

       }
       public int UpdateBorderMaster()
       {
           return 1;
       }


    }
}
