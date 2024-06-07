using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using DataAccessLayer;
using System.Data.SqlClient;
//using Microsoft.Reporting.WebForms;
using System.Drawing.Printing;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Text;
using System.Drawing.Drawing2D;
using System.IO;
using System.Globalization;
using System.Threading;
using System.Net.NetworkInformation;


public partial class Admin_frmChipInit : System.Web.UI.Page
{

    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    BaseLayer.General_function objgenenral = null;
    BaseLayer.General_function ObjGeneral = null;
    protected BaseLayer.General_function ObjGenBal = null;

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
          //  string script = "$(document).ready(function () { $('[id*=btn_Init]').click(); });";
          //  ClientScript.RegisterStartupScript(this.GetType(), "load", script, true);
        } 
    }
    protected void btn_Init_Click(object sender, EventArgs e)
    {
       // btn_exit.Enabled = false;
       // btn_Init.Enabled = false;
        ObjGeneral = new BaseLayer.General_function();
        SqlConnection Connection = new SqlConnection();
        Connection.ConnectionString = ConfigurationManager.ConnectionStrings["NigeriaConnectionString"].ConnectionString;

        string IP = System.Web.HttpContext.Current.Request.UserHostAddress;
        string command = "Insert into tbl_production (peopleid,status,ip_add) values (" + 0 + ",1,'" + IP.ToString().Trim() + "')";
        SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.Text, command);

        /// <summary>
        /// The connection is closed </summary>
        Connection.Close();

        Thread.Sleep(40000);

        DataTable dt = new DataTable();
        string query_p = "SELECT * from tbl_production where ip_add='" + IP.ToString().Trim() + "'";
        dt = ObjGeneral.FetchData(query_p);

        if (dt.Rows.Count > 0)
        {
            if (dt.Rows[0]["chip_status"].ToString() == "0" || dt.Rows[0]["chip_status"] == null || dt.Rows[0]["chip_status"].ToString()=="")
            {
                tr_start.Style.Add("display", "none");
                tr_notover.Style.Add("display", "");
                tr_over.Style.Add("display", "none");

                //ScriptManager.RegisterStartupScript(this, GetType(), "key", "alert(\"Card not Initialized Successfully.\");", true);
               // return;
            }
            else
            {
               // ScriptManager.RegisterStartupScript(this, GetType(), "key", "alert(\"Card Initialized Successfully. Put New Card on Reader For Initialization.\");", true);
                tr_start.Style.Add("display", "none");
                tr_notover.Style.Add("display", "none");
                tr_over.Style.Add("display", "");
            }
        }

        if (dt.Rows.Count == 0)
        {
            tr_start.Style.Add("display", "none");
            tr_notover.Style.Add("display", "");
            tr_over.Style.Add("display", "none");

            // ScriptManager.RegisterStartupScript(this, GetType(), "key", "alert(\"Card not Initialized Successfully.\");", true);
           // return;

        }
        Connection.Open();
        SqlCommand cmd1 = new SqlCommand("Delete from tbl_production where IP_Add = '" + IP + "'", Connection);
        cmd1.ExecuteNonQuery();

    }
    protected void btn_exit_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProductionProcess.aspx");
    }
}