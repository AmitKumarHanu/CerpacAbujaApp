using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Configuration;
using System.Web;
using System.Data.Common;
using System.Data.SqlClient;
using System.Net;
using System;
using DataAccessLayer;
using System.Net.Mail;
using System.Web.UI.WebControls;

namespace BusinessEntityLayer
{
    public class BankUserData
    {
       
        public DataTable Fetch_BankDetail_by_UserName(string userName, string password)
        {
            DataAccessLayer.DalBankUserData ObjDalBankUserData = null;

            try
            {
                ObjDalBankUserData = new DataAccessLayer.DalBankUserData();
                return ObjDalBankUserData.Fetch_BankDetail_by_UserName(userName, password);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ObjDalBankUserData = null;

            }
        }

        //public void Fill_DDL(DropDownList ddl, string StrQuery, string Text_Field, string Value_Field)
        //{
        //    DataTable dtGenral;
        //    //   try
        //    // {
        //    dtGenral = new DataTable();
        //    dtGenral = FetchData(StrQuery);
        //    ddl.Items.Clear();
        //    ddl.DataSource = dtGenral;
        //    ddl.DataTextField = Text_Field;
        //    ddl.DataValueField = Value_Field;
        //    ddl.DataBind();
        //    ddl.Items.Insert(0, new ListItem("----Select----", "0"));

            
        //}
    }
}
