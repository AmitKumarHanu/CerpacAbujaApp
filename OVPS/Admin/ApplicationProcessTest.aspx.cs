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
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;


public partial class Admin_ApplicationProcessTest : System.Web.UI.Page
{
    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    BaseLayer.General_function objgenenral = null;
    protected DataTable dt = new DataTable();
    protected DataSet objDs = new DataSet();
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        if (objectSessionHolderPersistingData == null)
        {
            Response.Redirect("../Login.aspx");
        }

        Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
        TreeView trvie = (TreeView)this.Page.Master.FindControl("TVLeftMenu");
        trvie.Visible = false;
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
            }
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            dt = null;
            objgenenral = null;
        }
    }
    public string base64Encode(string data)
    {
        try
        {
            byte[] encData_byte = new byte[data.Length];
            encData_byte = System.Text.Encoding.UTF8.GetBytes(data);
            string encodedData = Convert.ToBase64String(encData_byte);
            return encodedData;
        }
        catch (Exception e)
        {
            throw new Exception("Error in base64Encode" + e.Message);
        }
    }
    protected void Go_Click(object sender, EventArgs e)
    {
        objgenenral = new BaseLayer.General_function();
        DataTable dtpeople = null;
        dtpeople = new DataTable();
        string queryforpeople = "Select * from People where cerpac_no = '"+TextAppId.Text.ToString().ToUpper().Trim()+"'";
        dtpeople=objgenenral.FetchData(queryforpeople);
        if(dtpeople.Rows.Count>0)
        {
            Response.Redirect("FrmApplicationDetailstest.aspx?no=" + TextAppId.Text.ToString().Trim().ToUpper() + "&fno=" + base64Encode(TextAppId.Text.ToString().Trim().ToUpper()) + "");
        }
    }

}