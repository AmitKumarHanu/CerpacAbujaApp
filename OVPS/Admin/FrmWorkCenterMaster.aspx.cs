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

public partial class FrmWorkCenterMaster : System.Web.UI.Page
{
    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    #endregion

    BaseLayer.General_function objGeneral = null;
    BusinessEntityLayer.BalWorkCenterDetails ObjBalWorkCenterDetails = null;

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
        Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
        ObjBalWorkCenterDetails = new BusinessEntityLayer.BalWorkCenterDetails();
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

        try
        {
            LabelMessage.CssClass = "";
            LabelMessage.Text = "";

            {
                //BindDropdownList();
                if (Session["Mode"].ToString() == "insert")
                {
                    btnSave.Visible = true;
                    btnUpdate.Visible = false;

                }
                if (Session["Mode"].ToString() == "update")
                {

                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    string query = "Select WorkCenterMasterID from WorkCenterMaster where WorkCenter='" + Session["id"].ToString() + "'";
                    DataTable dt = new DataTable();
                    dt = objGeneral.FetchData(query);
                    Session["WorkCenterID"] = dt.Rows[0]["WorkCenterMasterID"].ToString();
                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    if (!IsPostBack)
                    {
                        FillFormField(Convert.ToInt32(Session["WorkCenterID"].ToString()));
                    }
                    Trace.Warn("Session" + Session["WorkCenterID"].ToString());
                }
                else if (Session["Mode"].ToString() == "view")
                {
                    string query = "Select WorkCenterMasterID from WorkCenterMaster where WorkCenter='" + Session["id"].ToString() + "'";
                    DataTable dt = new DataTable();
                    dt = objGeneral.FetchData(query);
                    Session["WorkCenterID"] = dt.Rows[0]["WorkCenterMasterID"].ToString();
                    FillFormField(Convert.ToInt32(Session["WorkCenterID"].ToString()));
                    btnSave.Visible = false;
                    btnUpdate.Visible = false;
                    txtWorkCenter.ReadOnly = true;
                    chkactive.Enabled = false;

                }
            }


        }
        catch (Exception ex)
        {
            LabelMessage.CssClass = "errormsg";
            LabelMessage.Text = "Please contact to System Administrator; Error message is: " + ex.Message.ToString(); ;
        }
    }

    //private void BindDropdownList()
    //{        
        //string CountryNameQuery = "SELECT WorkCenter,  FROM WorkCenterMaster WHERE  STATUS='A' order by WorkCenter";
        //objGeneral.Fill_DDL(ddlCountryName, CountryNameQuery, "CountryName", "CountryCode");

    //}

    private void FillFormField(int id)
    {
        Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
        // code to create the object at bussiness layer
        
        DataTable ObjDt = null;
        ObjDt = new DataTable();

        try
        {
            ObjBalWorkCenterDetails = new BusinessEntityLayer.BalWorkCenterDetails();
            ObjBalWorkCenterDetails.WorkCenterID = id;
            ObjDt = ObjBalWorkCenterDetails.FetchWorkCenterDetails();

            if (ObjDt.Rows.Count > 0)
            {
                //ddlCountryName.SelectedValue = ddlCountryName.Items.FindByValue(ObjDt.Rows[0]["CountryCode"].ToString()) == null ? "0" : ObjDt.Rows[0]["CountryCode"].ToString(); 
                //ddlCountryName.Enabled = false;
                //txtCityCode.Text = ObjDt.Rows[0]["CityCode"].ToString();
                //txtCityCode.ReadOnly = true;
                txtWorkCenter.Text = ObjDt.Rows[0]["WorkCenter"].ToString();                
                chkactive.Checked = ObjDt.Rows[0]["Status"].ToString() == "A" ? true : false;

            }

        }
        catch (Exception ex)
        {

            LabelMessage.CssClass = "errormsg";
            LabelMessage.Text = "Please contact to System Administrator; Error message is: " + ex.Message.ToString();

        }
        finally
        {
            ObjBalWorkCenterDetails = null;
            ObjDt = null;
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Session["Mode"] = null;
        Session["id"] = null;
        Response.Redirect("FrmWorkCenterList.aspx");
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
       
        Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
        string Message = string.Empty;
        try
        {          
            

            //set the properties defined at business layer
            ObjBalWorkCenterDetails.WorkCenter = txtWorkCenter.Text.ToString();
            //ObjBalCityDetails.CityName = txtCityName.Text;
            ObjBalWorkCenterDetails.Status = chkactive.Checked == true ? "A" : "I";
            ObjBalWorkCenterDetails.ModifiedBy = objectSessionHolderPersistingData.User_ID;


            int statusid = ObjBalWorkCenterDetails.InsertWorkCenterDetail();
            Message = "Record successfully saved";
            if (statusid == 1)
            {
                objGeneral.audittype = ENUMAUDITTYPE.WorkCenterCreated.GetHashCode().ToString();
                objGeneral.userid = objectSessionHolderPersistingData.User_ID;
                objGeneral.auditdetail = "WorkCenter '" + "(ID:" + txtWorkCenter.Text + ")' Created";
                objGeneral.machineIP = Request.UserHostAddress.ToString();
                objGeneral.AuditInsert();
                Session["Status"] = Message;//"Record successfully saved";
                Response.Redirect("FrmWorkCenterList.aspx", false);
            }
            else if (statusid == 2)
            {
                lblstatus.Visible = true;// "Doc Code Already Exist";
                lblstatus.CssClass = "errormsg";
                lblstatus.Text = "Work Center already exists";
                txtWorkCenter.Focus();
            }                      
            else
            {
                Message = "Record Can not be saved";
               // LabelMessage.CssClass = "errormsg";
                LabelMessage.Text = Message;//"Record Can not be saved";

            }



        }
        catch (Exception ex)
        {
            LabelMessage.CssClass = "errormsg";
            LabelMessage.Text = "Please contact to System Administrator; Error message is: " + ex.Message.ToString(); ;
        }
        finally
        {
            ObjBalWorkCenterDetails = null;

        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        
        Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
        string id = null;
        string Message = "";
        string WorkCenterID="";
        try
        {
            if (Session["id"] != null)
            {
                id = Session["id"].ToString();
               
            }

            if (Session["WorkCenterID"].ToString() != null)
            {
                WorkCenterID = Session["WorkCenterID"].ToString();
            }
            //set the properties defined at business layerst
            string values = txtWorkCenter.Text;
            ObjBalWorkCenterDetails = new BusinessEntityLayer.BalWorkCenterDetails();
            ObjBalWorkCenterDetails.WorkCenterID = Convert.ToInt32(WorkCenterID.ToString());
            ObjBalWorkCenterDetails.WorkCenter = txtWorkCenter.Text.ToString();
            ObjBalWorkCenterDetails.Status = chkactive.Checked == true ? "A" : "I";
            ObjBalWorkCenterDetails.ModifiedBy = objectSessionHolderPersistingData.User_ID;


            int statusid = ObjBalWorkCenterDetails.UpdateWorkCenterDetail();
            Message = "Record successfully Updated";
            if (statusid == 1)
            {
                objGeneral.audittype = ENUMAUDITTYPE.WorkCenterUpdated.GetHashCode().ToString();
                objGeneral.userid = objectSessionHolderPersistingData.User_ID;
                objGeneral.auditdetail = "Details of Work Center : '" + id + "' updated";
                objGeneral.machineIP = Request.UserHostAddress.ToString();
                objGeneral.AuditInsert();
                Session["Status"] = Message;//"Record successfully Updated";
                Response.Redirect("FrmWorkCenterList.aspx", false);
            }
                     
            else
            {
                Message = "Record Can not be updated";
                LabelMessage.CssClass = "errormsg";
                LabelMessage.Text = Message;//"Record Can not be updated";

            }



        }
        catch (Exception ex)
        {
            LabelMessage.CssClass = "errormsg";
            LabelMessage.Text = "Please contact to System Administrator; Error message is: " + ex.Message.ToString(); ;
        }
        finally
        {
            ObjBalWorkCenterDetails = null;

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
}
