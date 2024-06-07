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
using System.Xml;

public partial class FrmZonMaster : System.Web.UI.Page
{
    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    #endregion

    BaseLayer.General_function objGeneral = null;
    BusinessEntityLayer.BalZonDetails ObjBalZonDetails = null;
   // BusinessEntityLayer.BalCityDetails objBalCityDetails = null;
    BaseLayer.General_function ObjGeneral = null;
    protected void Page_PreInit(object sender, EventArgs e)
    {
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        if (objectSessionHolderPersistingData == null)
        {
            Response.Redirect("../Login.aspx");
        }
        string companyid = objectSessionHolderPersistingData.CompanyId;
        if (companyid == "0")

            this.Page.MasterPageFile = "~/MasterPage/MasterPageCompany.master";
        else
            this.Page.MasterPageFile = "~/MasterPage/MasterPageUser.master";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        string[] a = new string[100];
        Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
        ObjBalZonDetails = new BusinessEntityLayer.BalZonDetails();
        objGeneral = new BaseLayer.General_function();
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        ////////////////////////////////////////////////////////
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.Now.AddDays(-1));
        Response.Cache.SetNoStore();
        if (Request.Cookies.Count > 0)
        {
            //HttpCookie cookie = Request.Cookies["ASPXAUTH"];
            //cookie.Expires = DateTime.Now.AddYears(-10);
            //Response.AppendCookie(cookie);
        }
        ///////////////////////////////////////////////////////
        //-----Alerts for save and Update Buttons.----
        string strScriptSave = "if(!confirm('Do you want to save this record ?'))  return false; ";
        string strScriptUpdate = "if(!confirm('Do you want to update this record  ?'))  return false; ";
        btnUpdate.Attributes.Add("onclick", strScriptUpdate);
        btnSave.Attributes.Add("onclick", strScriptSave);
        //----End---------------
       // BindGrid();
        try
        {
            LabelMessage.CssClass = "";
            LabelMessage.Text = "";

            if (!IsPostBack)
            {
                BindDropdownList();
                if (Session["Mode"].ToString() == "insert")
                {
                    btnSave.Visible = true;
                    btnUpdate.Visible = false;
                    GridView1.Visible = true;
                    GridView2.Visible = false;
                    ddlCountryName.SelectedIndex = 1;
                    ddlCountryName.Enabled = false;
                    bindgrid1();
                    ddlZoneName.Visible = true;
                    lblZoneName.Visible = false;
                }
                else 
                    if (Session["Mode"].ToString() == "update")
                {

                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    if (Session["id"] != null)
                    {
                        ddlZoneName.Visible = false;
                        lblZoneName.Visible = true;
                        Trace.Warn("id" + Session["id"].ToString());
                        FillFormField(Session["id"].ToString());
                        GridView1.Visible = false;
                        GridView2.Visible = true;
                        bindgrid2();
                        string query = "select CityCode from ZoneCitymaster where ZoneCode=(select ZoneCode from Zonemaster where ZoneName='" + Session["id"].ToString() + "')";
                        DataTable dt = new DataTable();
                        dt = objGeneral.FetchData(query);
                        Session["count"] = dt.Rows.Count.ToString();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            foreach (GridViewRow dg in GridView2.Rows)
                            {
                                if (dt.Rows[i]["CityCode"].ToString().Trim() == (Convert.ToInt32(GridView2.DataKeys[dg.RowIndex].Value)).ToString().Trim())
                                {
                                    CheckBox cb1 = ((CheckBox)dg.FindControl("CheckBox1"));
                                    cb1.Checked = true;

                                    a[i] = dt.Rows[i]["CityCode"].ToString();

                                    Trace.Warn("a[i]" + a[i].ToString());
                                }


                            }
                        }
                        Session["a"] = a;
                        Trace.Warn("aa" + Session["a"].ToString());
                    }
                }
                    else if (Session["Mode"].ToString() == "view")
                    {
                        FillFormField(Session["id"].ToString());
                        txtZonCode.ReadOnly = true;
                        ddlCountryName.Enabled = false;
                        ddlZoneName.Visible = false;
                        GridView1.EnableViewState = false;
                        btnSave.Visible = false;
                        btnUpdate.Visible = false;
                        btnCancel.Visible = true;


                    }
            }
        }
        
        catch (Exception ex)
        {
            LabelMessage.CssClass = "errormsg";
            LabelMessage.Text = "Please contact to System Administrator; Error message is: " + ex.Message.ToString(); ;
        }
     }

    private void bindgrid1()
    {
        DataSet ds = new DataSet();

        try
        {
            ObjBalZonDetails = new BusinessEntityLayer.BalZonDetails();
            ds = ObjBalZonDetails.GetZonList();

            GridView1.DataSource = ds;
            GridView1.DataBind();

        }
        catch (Exception ex)
        {
            Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            LabelMessage.CssClass = "errormsg";
            LabelMessage.Text = "Please contact to System Administrator; Error message is: " + ex.Message.ToString();

        }
        finally
        {
            ObjBalZonDetails = null;
            ds = null;
        }
    }
    private void bindgrid2()
    {
        DataSet ds = new DataSet();

        try
        {
            ObjBalZonDetails = new BusinessEntityLayer.BalZonDetails();
            ds = ObjBalZonDetails.GetZonUpdateList();

            GridView2.DataSource = ds;
            GridView2.DataBind();

        }
        catch (Exception ex)
        {
            Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            LabelMessage.CssClass = "errormsg";
            LabelMessage.Text = "Please contact to System Administrator; Error message is: " + ex.Message.ToString();

        }
        finally
        {
            ObjBalZonDetails = null;
            ds = null;
        }
    }
    private void BindDropdownList()
    {
        string CountryNameQuery = "SELECT CountryCode,CountryName  FROM CountryMaster WHERE  CountryCode=234";
        objGeneral.Fill_DDL(ddlCountryName, CountryNameQuery, "CountryName", "CountryCode");

        string ZoneNameQuery = "SELECT ZoneCode,ZoneName  FROM Zonemaster";
        objGeneral.Fill_DDL(ddlZoneName, ZoneNameQuery, "ZoneName", "ZoneCode");

    }

    private void FillFormField(string id)
    {
        Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
        // code to create the object at bussiness layer

        DataTable ObjDt = null;
        ObjDt = new DataTable();

        try
        {

            ObjBalZonDetails.ZonCode = id;
            ObjDt = ObjBalZonDetails.FetchZonDetails();

            if (ObjDt.Rows.Count > 0)
            {
                ddlCountryName.SelectedIndex = 1;
                //ddlCountryName.SelectedValue = ddlCountryName.Items.FindByValue(ObjDt.Rows[0]["CountryCode"].ToString()) == null ? "0" : ObjDt.Rows[0]["CountryCode"].ToString();
                ddlCountryName.Enabled = false;
                lblZoneName.Text = Session["id"].ToString();
                //ddlZoneName.Enabled = false;
                // txtZonName.Text = ObjDt.Rows[0]["ZoneCode"].ToString();
                //  txtZonName.ReadOnly = true;
                txtZonCode.Text = ObjDt.Rows[0]["ZoneCode"].ToString();


            }

        }
        catch (Exception ex)
        {

            LabelMessage.CssClass = "errormsg";
            LabelMessage.Text = "Please contact to System Administrator; Error message is: " + ex.Message.ToString();

        }
        finally
        {
            ObjBalZonDetails = null;
            ObjDt = null;
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Session["Mode"] = null;
        Session["id"] = null;
        Response.Redirect("FrmZonList.aspx");
    }

    protected void btnSave_Click(object sender, EventArgs e)
     {
       
        Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
        string Message = string.Empty;
        try
        {

            foreach (GridViewRow gr in GridView1.Rows)
            {
                CheckBox cb = ((CheckBox)gr.FindControl("chk_select"));
                if (cb.Checked == true)
                {
            //set the properties defined at business layer
            ObjBalZonDetails.CountryCode = ddlCountryName.SelectedValue.ToString();
           // ObjBalZonDetails.ZonName = ddlZoneName.SelectedValue.ToString();
            ObjBalZonDetails.ZonCode = txtZonCode.Text.ToString();
            //ObjBalZonDetails.ZonName = txtZonCode.Text.ToString();
            ObjBalZonDetails.ModifiedBy = objectSessionHolderPersistingData.User_ID;
            int CityCode = Convert.ToInt32(GridView1.DataKeys[gr.RowIndex].Value);
            ObjBalZonDetails.CityCode = CityCode.ToString();
            //string CityName = GridView1.DataKeys[gr.RowIndex].Values.ToString();
            //ObjBalZonDetails.CityName = CityName.ToString();
             int statusid = ObjBalZonDetails.InsertZonDetail();
             Message = "Record successfully saved";
            if (statusid == 1)
            {
                objGeneral.audittype = ENUMAUDITTYPE.ZonCreated.GetHashCode().ToString();
                objGeneral.userid = objectSessionHolderPersistingData.User_ID;
                objGeneral.auditdetail = "Zone" + txtZonCode.Text+"(ID:" + ddlZoneName.SelectedValue.ToString() + ")' linked";
                objGeneral.machineIP = Request.UserHostAddress.ToString();
                objGeneral.AuditInsert();
                //Session["Status"] = Message;//"Record successfully saved";
                Response.Redirect("FrmZonList.aspx", false);
            }
            else if (statusid == 2)
            {
                Labelerrormessage.Visible = true;
                Labelerrormessage.Text = "This City is under another Zone";
                //LabelMessage.CssClass = "errormsg";
               // LabelMessage.Text = "This City is under another Zone";// "City Code Already Exist";
                //ddlZoneName.Focus();
            }                      
            else
            {
                Message = "Record Can not be saved";
                LabelMessage.CssClass = "errormsg";
                LabelMessage.Text = Message;//"Record Can not be saved";

            }

                }
            }

        }
        catch (Exception ex)
        {
            LabelMessage.CssClass = "errormsg";
            LabelMessage.Text = "Please contact to System Administrator; Error message is: " + ex.Message.ToString(); ;
        }
        finally
        {
            ObjBalZonDetails = null;

        }
    }
 /*   protected void BindGrid()
    {
        DataSet ds = new DataSet();

        try
        {
            
            GridView1.RowStyle.HorizontalAlign = HorizontalAlign.Center;
            
           // GridView1.EditRowStyle.VerticalAlign = VerticalAlign.Middle;
            //GridView1.BorderWidth = 0;
            //  GridView1.RowStyle.BorderWidth = 0;
            ds = ObjBalZonDetails.GetZoneCityList();

            GridView1.DataSource = ds;
           // GridView1.AutoGenerateColumns = false;
            GridView1.DataBind();
            
        }
        catch (Exception ex)
        {
            Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            LabelMessage.CssClass = "errormsg";
            LabelMessage.Text = "Please contact to System Administrator; Error message is: " + ex.Message.ToString();

        }
        finally
        {
            ObjBalZonDetails = null;
            ds = null;
        }
    }*/

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string[] b = new string[100];
        int statusid = 0;
        int counter = 0;
        int j = 0;
        Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
        string id = null;
        int count = 0;
        string Message = "";
        try
        {
            if (Session["id"] != null)
            {
                id = Session["id"].ToString();

            }
            if (Session["a"] != null)
            {
                count = Convert.ToInt32(Session["count"].ToString());
                for (int i = 0; i < count; i++)
                {
                    string[] a = (string[])Session["a"];
                    //Trace.Warn("a[i]" + a[i].ToString());
                    int status = ObjBalZonDetails.DeletePrevdata(a[i].ToString());
                }
            }

            //set the properties defined at business layer
            foreach (GridViewRow gr in GridView2.Rows)
            {
                CheckBox cb = ((CheckBox)gr.FindControl("CheckBox1"));
                if (cb.Checked == true)
                {
                    //set the properties defined at business layer
                    ObjBalZonDetails.CountryCode = ddlCountryName.SelectedValue.ToString();
                    // ObjBalZonDetails.ZonName = ddlZoneName.SelectedValue.ToString();
                    ObjBalZonDetails.ZonCode = txtZonCode.Text.ToString();
                    //ObjBalZonDetails.ZonName = txtZonCode.Text.ToString();
                    ObjBalZonDetails.ModifiedBy = objectSessionHolderPersistingData.User_ID;
                    int CityCode = Convert.ToInt32(GridView2.DataKeys[gr.RowIndex].Value);
                    ObjBalZonDetails.CityCode = CityCode.ToString();
                    //string CityName = GridView1.DataKeys[gr.RowIndex].Values.ToString();
                    //ObjBalZonDetails.CityName = CityName.ToString();
                    //statusid = ObjBalZonDetails.InsertZonDetail();
                    Message = "Record successfully updated";
                    counter = counter + 1;
                    int status = 0;
                    status = ObjBalZonDetails.InsertZonDetail();
                    statusid = statusid + status;
                    if (status != 1)
                    {

                        b[j] = CityCode.ToString();
                        j++;
                        // Session["City"] = Session["City"] + ", " + CityCode.ToString();
                    }

                }
            }
            if (statusid == counter)
            {
                objGeneral.audittype = ENUMAUDITTYPE.ZonCreated.GetHashCode().ToString();
                objGeneral.userid = objectSessionHolderPersistingData.User_ID;
                objGeneral.auditdetail = "Zone" + txtZonCode.Text + "(ID:" + ddlZoneName.SelectedValue.ToString() + ")' linked";
                objGeneral.machineIP = Request.UserHostAddress.ToString();
                objGeneral.AuditInsert();
                Session["Status"] = Message;//"Record successfully saved";
                Response.Redirect("FrmZonList.aspx", false);
            }
            else
            {
                Labelerrormessage.Visible = true;
                string txt = null;
                for (int k = 0; k < j; k++)
                {
                    if (k == 0)
                    {
                        txt = txt + b[k].ToString();
                    }
                    else
                    {
                        txt = txt + "&" + " " + b[k].ToString() + " ";
                    }
                }
                Labelerrormessage.Text = "Zones with zone code" + " " + txt + " " + "is/are under another Zone";
                //LabelMessage.CssClass = "errormsg";
                // LabelMessage.Text = "This City is under another Zone";// "City Code Already Exist";
                //ddlZoneName.Focus();
            }


        }




        catch (Exception ex)
        {
            LabelMessage.CssClass = "errormsg";
            LabelMessage.Text = "Please contact to System Administrator; Error message is: " + ex.Message.ToString(); ;
        }
        finally
        {
            ObjBalZonDetails = null;
            //Session["id"] = null;
            Session["a"] = null;
            Session["count"] = null;


        }
    }

    public string getXmlMessage(int FormID, int ErrorID, string Mode)
    {
        string errormessage = string.Empty;
        string XMLPath = Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["XMLPath"].ToString()) + "Error.xml";
        XmlDocument xd = new XmlDocument();

        //xd.Load(@"D:\Projects\OVPS\OVPS\Error.xml");
        xd.Load(XMLPath);
        XmlNodeList FormList = xd.SelectNodes("/RootMessage/form");
        foreach (XmlNode FormNode in FormList)
        {
            if (Convert.ToInt32(FormNode.Attributes["id"].Value) == FormID)
            {
                foreach (XmlNode Errornode in FormNode.ChildNodes)
                {
                    if (Convert.ToInt32(Errornode.Attributes["id"].Value) == ErrorID && Errornode.Attributes["mode"].Value == Mode)
                    {
                        errormessage = Errornode.InnerText;
                        return errormessage;
                    }
                }
            }
        }
        errormessage = FormList[0].ParentNode.ChildNodes[0].InnerText;
        return errormessage;
    }

    protected void ddlZoneName_SelectedIndexChanged(object sender, EventArgs e)
    {
        //string ZoneName = ddlZoneName.SelectedValue.ToString();
        txtZonCode.Text = ddlZoneName.SelectedValue.ToString();
        // string qury = "select ZoneCode from Zonemaster where ZoneName='"+ ZoneName.ToString() +"' ";

        //DataTable dt = new DataTable();
        //dt = ObjGeneral.FetchData(qury);
        //txtZonCode.Text = dt.Rows[0]["ZoneCode"].ToString();
    }
    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
