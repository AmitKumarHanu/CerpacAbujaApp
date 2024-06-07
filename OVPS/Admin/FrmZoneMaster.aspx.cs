using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Xml;

public partial class FrmZoneMaster : System.Web.UI.Page
{
    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    #endregion
    BusinessEntityLayer.BalZoneDetails ObjBalZoneDetials = null;
    BaseLayer.General_function objGeneral = null;
    
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
        ObjBalZoneDetails = new BusinessEntityLayer.BalZoneDetails();
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

            if (!IsPostBack)
            {

                if (Session["Mode"].ToString() == "insert")
                {
                    btnSave.Visible = true;
                    btnUpdate.Visible = false;
                }
                else if ((Session["Mode"].ToString() == "update"))
                {

                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    if (Session["id"] != null)
                        FillFormField(Session["id"].ToString());
                }
                else if (Session["Mode"].ToString() == "view")
                {
                    FillFormField(Session["id"].ToString());
                    btnSave.Visible = false;
                    btnUpdate.Visible = false;
                    txtZoneCode.ReadOnly = true;
                    txtboxZonalOfficer.ReadOnly = true;
                    TxtboxAddress.ReadOnly = true;
                    txtZoneFullName.ReadOnly = true;
                    txtMobileNo.ReadOnly = true;
                    TxtboxAddress.ReadOnly = true;
                    txtZoneDesc.ReadOnly = true;
                    txtEmailID.ReadOnly = true;

                }

            }
        }
        catch (Exception ex)
        {
            LabelMessage.CssClass = "errormsg";
            LabelMessage.Text = "Please contact to System Administrator; Error message is: " + ex.Message.ToString(); ;
        }
    }       


    private void FillFormField(string id)
    {
        Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
        // code to create the object at bussiness layer
        
        DataTable ObjDt = null;
        ObjDt = new DataTable();

        try
        {

            ObjBalZoneDetails.ZoneCode = id;
            ObjDt = ObjBalZoneDetails.FetchZoneDetails_ZoneCode();

            if (ObjDt.Rows.Count > 0)
            {

                txtZoneCode.Text = ObjDt.Rows[0]["ZoneCode"].ToString() == null ? string.Empty : ObjDt.Rows[0]["ZoneCode"].ToString();
                txtZoneCode.ReadOnly = true;
                txtZoneDesc.Text = ObjDt.Rows[0]["ZoneDesc"].ToString() == null ? string.Empty : ObjDt.Rows[0]["ZoneDesc"].ToString();
                txtEmailID.Text = ObjDt.Rows[0]["Emailid"].ToString() == null ? string.Empty : ObjDt.Rows[0]["Emailid"].ToString();
                txtZoneFullName.Text = ObjDt.Rows[0]["ZoneName"].ToString() == null ? string.Empty : ObjDt.Rows[0]["ZoneName"].ToString();
                txtMobileNo.Text = ObjDt.Rows[0]["MobileNo"].ToString() == null ? string.Empty : ObjDt.Rows[0]["MobileNo"].ToString();
                TxtboxAddress.Text = ObjDt.Rows[0]["Address"].ToString() == null ? string.Empty : ObjDt.Rows[0]["Address"].ToString();
                txtboxZonalOfficer.Text = ObjDt.Rows[0]["ZonalOfficer"].ToString() == null ? string.Empty : ObjDt.Rows[0]["ZonalOfficer"].ToString();
               // rblEAC.SelectedValue = ObjDt.Rows[0]["EACFlag"].ToString() == null ? "N" : ObjDt.Rows[0]["EACFlag"].ToString();
              //  chkactive.Checked = ObjDt.Rows[0]["Status"].ToString() == "A" ? true : false;                            
                             
             }

        }
        catch (Exception ex)
        {

            LabelMessage.CssClass = "errormsg";
            LabelMessage.Text = "Please contact to System Administrator; Error message is: " + ex.Message.ToString(); 
           
        }
        finally
        {
            ObjBalZoneDetails = null;
            ObjDt = null;
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Session["Mode"] = null;
        Session["id"] = null;
        Response.Redirect("FrmZoneList.aspx");
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        
        Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
        string Message = "";        
        try
        {             
            //set the properties defined at business layer

            ObjBalZoneDetails.ZoneCode = txtZoneCode.Text;
            ObjBalZoneDetails.ZoneDesc = txtZoneDesc.Text;
            ObjBalZoneDetails.EmailID = txtEmailID.Text;
            ObjBalZoneDetails.ZoneFullName = txtZoneFullName.Text;
            ObjBalZoneDetails.ZonalOfficer = txtboxZonalOfficer.Text;
            ObjBalZoneDetails.Address = TxtboxAddress.Text;
            ObjBalZoneDetails.MobileNo = txtMobileNo.Text;
            /*-- For EAC Flag --*/
           // ObjBalZoneDetails.EACFlag = rblEAC.SelectedValue.ToString();
            /*-- For EAC Flag --*/
            //ObjBalZoneDetails.Status = chkactive.Checked == true ? "A" : "I";
            //ObjBalZoneDetails.ModifiedBy = objectSessionHolderPersistingData.User_ID;


            int statusid = ObjBalZoneDetails.InsertZoneDetail();
           // Message = getXmlMessage((Int32)ENUMFORMCODE.ZoneMaster.GetHashCode(), statusid, "save");
            if (statusid == 1)
            {
                objGeneral.audittype = ENUMAUDITTYPE.ZoneCreated.GetHashCode().ToString();
                objGeneral.userid = objectSessionHolderPersistingData.User_ID;
                objGeneral.auditdetail = "Country '" + txtZoneDesc.Text + "(ID:" + txtZoneCode.Text + ")' Created";
                objGeneral.machineIP = Request.UserHostAddress.ToString();
                objGeneral.AuditInsert();

                 Session["Status"] = Message;//"Record successfully Updated";
                Response.Redirect("FrmZoneList.aspx", false);
                Session["Mode"] = null;
                Session["id"] = null;
            }
            else if (statusid == 2)
            {
                lblstatus.Visible = true;// "Doc Code Already Exist";
                lblstatus.CssClass = "errormsg";
                lblstatus.Text = "Zone Code already exists";
                txtZoneCode.Focus();
            }
            else if (statusid == 3)
            {
                LabelMessage.CssClass = "errormsg";
                LabelMessage.Text = Message;//"Country Name Already Exist";
                txtZoneDesc.Focus();
            }
            else if (statusid == 4)
            {
                LabelMessage.CssClass = "errormsg";
                LabelMessage.Text = Message;//"Abbreviation Already Exist";
                txtZoneFullName.Focus();
            }
            else
            {
                Message = getXmlMessage((Int32)ENUMFORMCODE.CountryMaster.GetHashCode(), 0, "save");
                LabelMessage.CssClass = "errormsg";
                LabelMessage.Text = Message;//"Record Can not be saved";
                
            }



        }
        catch (Exception ex)
        {
            LabelMessage.CssClass = "errormsg";
            LabelMessage.Text = "Please contact to System Administrator; Error message is: " + ex.Message.ToString(); 
        }
        finally
        {
            ObjBalZoneDetails = null;

        }
    }      

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
       
        Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
        string id = null;
        string Message = string.Empty;
        try
        {
            if (Session["id"] != null)
            {
                id = Session["id"].ToString();
            }

            ObjBalZoneDetails.ZoneCode = id;
            ObjBalZoneDetails.ZoneDesc = txtZoneDesc.Text;
            ObjBalZoneDetails.EmailID = txtEmailID.Text;
            ObjBalZoneDetails.ZoneFullName = txtZoneFullName.Text;
            ObjBalZoneDetails.Address = TxtboxAddress.Text;
            ObjBalZoneDetails.ZonalOfficer = txtboxZonalOfficer.Text;
            ObjBalZoneDetails.MobileNo = txtMobileNo.Text;
            /*-- For EAC Flag --*/
          //  ObjBalZoneDetails.EACFlag = rblEAC.SelectedValue.ToString();
            /*-- For EAC Flag --*/
           // ObjBalZoneDetails.Status = chkactive.Checked == true ? "A" : "I";
           // ObjBalZoneDetails.ModifiedBy = objectSessionHolderPersistingData.User_ID;
            
            int statusid = ObjBalZoneDetails.UpdateZoneDetail();
            Message = getXmlMessage((Int32)ENUMFORMCODE.ZoneMaster.GetHashCode(), statusid, "update");

            if (statusid == 1)
            {
                objGeneral.audittype = ENUMAUDITTYPE.ZoneUpdated.GetHashCode().ToString();
                objGeneral.userid = objectSessionHolderPersistingData.User_ID;
                objGeneral.auditdetail = "Details of Country Code : '" + id + "' updated";
                objGeneral.machineIP = Request.UserHostAddress.ToString();
                objGeneral.AuditInsert();
                Session["Status"] = Message;//"Record successfully Updated";
                Response.Redirect("FrmZoneList.aspx", false);
                Session["Mode"] = null;
                Session["id"] = null;
            }
            else if (statusid == 2)
            {
                LabelMessage.CssClass = "errormsg";
                LabelMessage.Text = Message;// "Country Name Already Exist";
                txtZoneDesc.Focus();
            }
            else if (statusid == 3)
            {
                LabelMessage.CssClass = "errormsg";
                LabelMessage.Text = Message;//"Abbreviation Already Exist";
                txtZoneFullName.Focus();
            }
            else
            {
                Message = getXmlMessage((Int32)ENUMFORMCODE.CountryMaster.GetHashCode(), 0, "update");
                LabelMessage.CssClass = "errormsg";
                LabelMessage.Text = Message;
             
            }
           
            

        }
        catch (Exception ex)
        {
            LabelMessage.CssClass = "errormsg";
            LabelMessage.Text = "Please contact to System Administrator; Error message is: " + ex.Message.ToString(); ;
        }
        finally
        {
            ObjBalZoneDetails = null;

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

    protected void txtZoneFullName_TextChanged(object sender, EventArgs e)
    {

    }

    public BusinessEntityLayer.BalZoneDetails ObjBalZoneDetails { get; set; }
}
