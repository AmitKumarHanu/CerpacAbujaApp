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

public partial class Admin_frmLaminationDetail : System.Web.UI.Page
{

     DataTable ds = new DataTable();
    string zone_c = "";

    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    BaseLayer.General_function objgenenral = null;
    BaseLayer.General_function ObjGeneral = null;
    protected BaseLayer.General_function ObjGenBal = null;

    Label LabelMessage = null;

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //  string script = "$(document).ready(function () { $('[id*=btn_ok]').click(); });";
            //  ClientScript.RegisterStartupScript(this.GetType(), "load", script, true);
        }
        //if (Session["card"] == null)
        //{
        //    Response.Redirect("../Login.aspx");
        //}

        LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        if (!IsPostBack)
        {
            ObjGeneral = new BaseLayer.General_function();
            objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];

            if (objectSessionHolderPersistingData == null)
            {
                Response.Redirect("../Login.aspx");
            }

            string queryforzonename = "select b.ZoneName from UserZoneRelation as a, Zonemaster as b where a.ZoneCode=b.ZoneCode and a.UserId=" + objectSessionHolderPersistingData.User_ID + "";
            objgenenral = new BaseLayer.General_function();
            DataTable dt = new DataTable();
            try
            {
                dt = objgenenral.FetchData(queryforzonename);
                if (dt.Rows.Count > 0)
                {
                    LabelMessage.Text = "Zone" + " " + dt.Rows[0]["ZoneName"].ToString();
                    LabelMessage.Visible = true;
                    LabelMessage.BorderStyle = BorderStyle.None;
                    zone_c = dt.Rows[0]["ZoneName"].ToString();
                }
            }
            catch (Exception ex)
            {
                ObjGenBal = new BaseLayer.General_function();
                string err = ObjGenBal.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
                LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
                LabelMessage.CssClass = "warning-box";
                LabelMessage.Visible = true;
            }
            finally
            {
                dt = null;
                objgenenral = null;
            }
        }
    }

    protected void btn_submit_Click(object sender, EventArgs e)
    {
        SqlConnection Connection = new SqlConnection();
        Connection.ConnectionString = ConfigurationManager.ConnectionStrings["NigeriaConnectionString"].ConnectionString;

       // Connection.ConnectionString = "Data Source=" + ddl_location.SelectedValue + ";Initial Catalog=Cerpac;Integrated Security=True";
        Connection.Open();
        string front_back_flag = "";

        if (rd_front.Checked == true)
            front_back_flag = "F";

        if (rd_back.Checked == true)
            front_back_flag = "B";

        if (txt_prefix.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "MyFun1", "alert('Please Fill Lamination Roll Prefix.');", true);
            return;
        }
        if (txt_lam_s.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "MyFun1", "alert('Please Fill Lamination Roll Starting Point.');", true);
            return;
        }

        if (txt_lam_e.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "MyFun1", "alert('Please Fill Lamination Roll Ending Point.');", true);
            return;
        }


        //string queryforlam = "select 1 from tbl_lamination_detail where lam_no='" + txt_prefix.Text + txt_lam_s.Text + "' or lam_no='" + txt_prefix.Text + txt_lam_e.Text + "'";
        //objgenenral = new BaseLayer.General_function();
        //DataTable dt = new DataTable();
        //dt = objgenenral.FetchData(queryforlam);

        //if (dt.Rows.Count > 0)
        //{
        //    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "MyFun1", "alert('This Series Already Exist.');", true);
        //    return;

        //}

        for (int i = Convert.ToInt32(txt_lam_s.Text); i <= Convert.ToInt32(txt_lam_e.Text); i++)
        {

            string queryforlam = "select 1 from tbl_lamination_detail where lam_no='" + txt_prefix.Text + Convert.ToString(Convert.ToInt32(i.ToString()).ToString("D" + txt_lam_s.Text.Length)) + "'";
            objgenenral = new BaseLayer.General_function();
            DataTable dt = new DataTable();
            dt = objgenenral.FetchData(queryforlam);

            if (dt.Rows.Count == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "MyFun1", "alert('This Series Already Exist.');", true);
                // return;



                string command = "Insert into tbl_lamination_detail (lam_id,lam_No,lamflag_f_b,lam_printedYN,lam_wastedYN,created_on,created_by) values ((select isnull(max(lam_id),0)+1 as lam_id from tbl_lamination_detail),'" + txt_prefix.Text + Convert.ToString(Convert.ToInt32(i.ToString()).ToString("D" + txt_lam_s.Text.Length)) + "','" + front_back_flag + "',0,0, '" + DateTime.Now.ToShortDateString() + "'," + int.Parse(objectSessionHolderPersistingData.User_ID) + ")";
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.Text, command);
            }
        }

        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "MyFun1", "alert('Lamination Series Inserted Sussessfully.');", true);
        /// <summary>
        /// The connection is closed </summary>
        Connection.Close();
    }
    protected void txt_prefix_TextChanged(object sender, EventArgs e)
    {
        
    }
}