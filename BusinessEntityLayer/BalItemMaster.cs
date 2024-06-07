using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace  BusinessEntityLayer
{
    public class  BalItemMaster
    {

        //-----------Item Stock Details----------------
        public String MRNo { get; set; }
        public  String  MRNDate { get; set; }
        public String Name { get; set;}
        public int  Quantity { get; set; }
        public String Code { get; set; }
      //  public String InvoiceNo { get; set; }
        public int CreatedBy { get; set; }
        public int CodeFrom { get; set; }
        public int CodeTo { get; set; }
        public string LStr { get; set; }
      
        DataAccessLayer.DalItemMaster ObjDalInsert = null;
        DataTable dt = null; 
        public int InsertDetails()
        {
            ObjDalInsert = new DataAccessLayer.DalItemMaster();
            dt = new DataTable();

            DataRow dr = dt.NewRow ();
            dt.Columns.Add("MRNo");
            dt.Columns.Add("MRNDate");
            dt.Columns.Add("Name");
            dt.Columns .Add("Quantity");
            dt.Columns .Add("Code");
            dt.Columns.Add("CreatedBy");
            dt.Columns.Add("CodeFrom");
            dt.Columns.Add("CodeTo");
            dt.Columns.Add("WorkArea");
            dt.Columns.Add("LStr");

            dr["MRNo"] = this.MRNo;
            dr["MRNDate"] = this.MRNDate;
            dr["Name"] = this.Name;
            dr["Quantity"] =this.Quantity;
            dr["Code"]=this.Code ;
           // dr["InvoiceNo"] = this.InvoiceNo;
            dr["CreatedBy"] = this.CreatedBy;
            dr["CodeFrom"] = this.CodeFrom;
            dr["CodeTo"] = this.CodeTo;
            dr["WorkArea"] = this.WorkArea;
            dr["LStr"]=this.LStr;

            dt.Rows.Add (dr);
 
            return ObjDalInsert.InsertDetails (dt);
        }

     //-------------Item Code Master Details--------------
      
        public String ItemName { get; set;}
        public String ItemCode { get; set; }
        public int  ItemCurrentStock { get; set; }
        public String WorkArea { get; set; }

      
        DataAccessLayer.DalItemMaster ObjDalItemMaster = null;
        DataTable dt1 = null; 
        public int ItemMasterInseter()
        {
            ObjDalItemMaster = new DataAccessLayer.DalItemMaster();
            dt1 = new DataTable();

            DataRow dr = dt1.NewRow ();
            dt1.Columns.Add("ItemName");
            dt1.Columns .Add("ItemCode");
            dt1.Columns.Add("ItemCurrentStock");
            dt1.Columns.Add("CreatedBy");
            dt1.Columns.Add("WorkArea");

            dr["ItemName"] = this.Name;
            dr["ITemCode"]=this.Code ;
            dr["ItemCurrentStock"] = this.ItemCurrentStock;
            dr["CreatedBy"] = this.CreatedBy;
            dr["WorkArea"] = this.WorkArea;

            dt1.Rows.Add (dr);
 
            return ObjDalItemMaster.ItemMasterInsert (dt1);
        }


        //-------------Item Inventory Insert Details--------------

        public String BankCode { get; set; }
        public int ZoneID { get; set; }
        public int UserID { get; set; }
        public String ItemCodeC { get; set; }
        public int ItemCodeN { get; set; }
        // public int CreatedBy { get; set; }
       // public String WorkAreaI { get; set; }


        DataAccessLayer.DalItemMaster ObjDalItemInvertoryInsert = null;
        DataTable dt2 = null;
        public int ItemInventoryInsert()
        {
            ObjDalItemInvertoryInsert = new DataAccessLayer.DalItemMaster();
            dt2 = new DataTable();

            DataRow dr = dt2.NewRow();
            dt2.Columns.Add("BankCode");
            dt2.Columns.Add("ZoneID");
            dt2.Columns.Add("UserID");
            dt2.Columns.Add("ItemCode");
            dt2.Columns.Add("ItemCodeN");
            dt2.Columns.Add("CreatedBy");
            dt2.Columns.Add("WorkArea");


            dr["BankCode"] = this.BankCode;            
            dr["ZoneID"] = this.ZoneID ;
            dr["UserID"] = this.UserID ;
            dr["ITemCode"] = this.ItemCodeC;
            dr["ItemCodeN"] = this.ItemCodeN;
            dr["CreatedBy"] = this.CreatedBy;
            dr["WorkArea"] = this.WorkArea;

            dt2.Rows.Add(dr);

            return ObjDalItemInvertoryInsert.ItemInventoryInsert(dt2);
        }

        //--------------Update Item Stock-----------------
        DataAccessLayer.DalItemMaster ObjDalItemInvertoryUpDate = null;
        DataTable dtUpDate = null;
        public int ItemStockUpdate()
        {
            ObjDalItemInvertoryUpDate = new DataAccessLayer.DalItemMaster();
            dtUpDate= new DataTable();

            DataRow dr = dtUpDate.NewRow();
            dtUpDate.Columns.Add("BankCode");
            dtUpDate.Columns.Add("ZoneID");
            dtUpDate.Columns.Add("UserID");
            dtUpDate.Columns.Add("ItemCode");
            dtUpDate.Columns.Add("ItemCodeN");
            dtUpDate.Columns.Add("CreatedBy");
            dtUpDate.Columns.Add("WorkArea");


            dr["BankCode"] = this.BankCode;
            dr["ZoneID"] = this.ZoneID;
            dr["UserID"] = this.UserID;
            dr["ITemCode"] = this.ItemCodeC;
            dr["ItemCodeN"] = this.ItemCodeN;
            dr["CreatedBy"] = this.CreatedBy;
            dr["WorkArea"] = this.WorkArea;

            dtUpDate.Rows.Add(dr);

            return ObjDalItemInvertoryInsert.ItemStockUpdate(dt2);
        }


        //--------------------

        //-------------Item Del Item Stock Master List Grid--------------

        public String OptDelStock  { get; set; }
        // public int CreatedBy { get; set; }
        // public String WorkAreaI { get; set; }


        DataAccessLayer.DalItemMaster ObjDalStock= null;
        DataTable dtDelStock = null;
        public int DelMRNoGid() 
        {
           
            ObjDalStock = new DataAccessLayer.DalItemMaster();
            dtDelStock = new DataTable();
            DataRow dr = dtDelStock.NewRow();

            dtDelStock.Columns.Add("MRNo");
            dtDelStock.Columns.Add("OptDelStock");

            dr["MRNo"] = this.MRNo;
            dr["OptDelStock"] = this.OptDelStock;

            dtDelStock.Rows.Add(dr);
            return ObjDalStock.DelMRNoGrid(dtDelStock);

          
        }


    }  
    
}