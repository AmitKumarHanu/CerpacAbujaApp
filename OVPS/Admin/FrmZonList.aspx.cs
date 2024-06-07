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
using System.Data.SqlClient;
using DataAccessLayer;

public partial class Admin_FrmZonList : System.Web.UI.Page
{
    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    #endregion
    BusinessEntityLayer.BalZonDetails objBalZonDetail = null;
    BaseLayer.General_function ObjGenBal = null;
    string companyid;
    protected void Page_PreInit(object sender, EventArgs e)
    {
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        if (objectSessionHolderPersistingData == null)
        {
            Response.Redirect("../Login.aspx");
        }
         companyid = objectSessionHolderPersistingData.CompanyId;
        if (companyid == "0")

            this.Page.MasterPageFile = "~/MasterPage/MasterPageCompany.master";
        else
            this.Page.MasterPageFile = "~/MasterPage/MasterPageUser.master";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        objBalZonDetail = new BusinessEntityLayer.BalZonDetails();
        ObjGenBal = new BaseLayer.General_function();
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

        Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
        LabelMessage.CssClass = "";
        LabelMessage.Text = "";

        if (!IsPostBack)
        {
            BindGrid();
            if (Session["Status"] != null)
            {
                LabelMessage.CssClass = "successmsg";
                LabelMessage.Text = Session["Status"].ToString();
                Session["Status"] = null;

            }
             BtnAccessibilty();
        }
       
    }
    public void BtnAccessibilty()
    {
        ObjGenBal = new BaseLayer.General_function();
        DataTable DT = new DataTable();
        string strSqlstatement = "SELECT fa.Add_Permission,fa.Mod_Permission,fa.View_Permission,fa.Del_Permission " +
                                 "FROM dbo.FORMACCESS fa " +
                                 "INNER JOIN FormMaster fm ON fm.FormId = fa.FormId " +
                                 "WHERE fm.FormUrl like '%Admin\\FrmZonList.aspx' AND USERID = " + Convert.ToString(objectSessionHolderPersistingData.User_ID) + "";

        Trace.Warn("strSqlstatement " + strSqlstatement);
        DT = ObjGenBal.FetchData(strSqlstatement);
        if (companyid != "0")
        {
            if (DT.Rows.Count > 0)
            {
                if (DT.Rows[0]["Add_Permission"].ToString() == "N")
                    btnAdd.Visible = false;

                if (DT.Rows[0]["Mod_Permission"].ToString() == "N")
                    GridViewZonList.Columns[4].Visible = false;
            }
        }
        //if (DT.Rows[0]["Del_Permission"].ToString() == "N")
        //    GridViewZonList.Columns[4].Visible = false;
    }
    //public void BtnAccessibilty()
    //{        
    //    DataTable DT = new DataTable();
    //    string strSqlstatement = "select FormId  from FormMaster where FormUrl like '%Admin\\FrmZonList.aspx'";
    //    int intFormId = (int)SqlHelper.ExecuteScalar(AppSetting.ActivateConnection, CommandType.Text, strSqlstatement);
    //    Trace.Warn("intFormId" + intFormId);
    //    DT = ObjGenBal.TbBtnaccess(Convert.ToString(intFormId), objectSessionHolderPersistingData.User_ID);

    //    if (DT.Rows[0][3].ToString() == "N")
    //        btnAdd.Visible = false;
    //    if (DT.Rows[0][4].ToString() == "N")
    //    {
    //        GridViewZonList.Columns[4].Visible = false;            
            
    //    }
    //    if (DT.Rows[0][5].ToString() == "N")
    //      GridViewZonList.Columns[4].Visible = false;  
       

    //}
       
    protected void BindGrid()
    {        
        DataSet ds = new DataSet();
           
        //try
        //{
            ds = objBalZonDetail.GetZoneList();

            GridViewZonList.DataSource = ds;
            GridViewZonList.DataBind();

        // }
        //catch (Exception ex)
        //{
        //    Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
        //    LabelMessage.CssClass = "errormsg";
        //    LabelMessage.Text = "Please contact to System Administrator; Error message is: " + ex.Message.ToString();

        //}
        //finally
        //{
        //    objBalZonDetail = null;
        //    ds = null;
        //}
    }

    protected void GridViewZonList_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridViewZonList.EditIndex = e.NewEditIndex;

        Label labelZonCode = (Label)GridViewZonList.Rows[GridViewZonList.EditIndex].FindControl("lblZonCode");

        string keyvalue = labelZonCode.Text.ToString();
        Session["Mode"] = "update";
        Session["id"] = keyvalue;
        Response.Redirect("FrmZonMaster.aspx");
        
    }
    protected void GridViewZonList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
        BaseLayer.General_function ObjGenBal = new BaseLayer.General_function();
        DataTable dt = null;
        dt = new DataTable();

        if (e.CommandName.Equals("Select"))
        {
            Session["Mode"] = "view";
            int index = Convert.ToInt32(e.CommandArgument);
            string keyvalue = GridViewZonList.DataKeys[index].Value.ToString();
            Session["id"] = keyvalue;
            Response.Redirect("FrmZonMaster.aspx");
            //this.ClientScript.RegisterClientScriptBlock(this.GetType(), "Onclick", "<script>window.open('viewGroupprnt.aspx?AppID=" + keyvalue + "&x=N','PaperVisa','menubar=no,status=yes,Width=1000,scrollbar=yes,4tHeight=600,top=50,left=5');</script>");

        }
    }

    protected void GridViewZonList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string keyvalue;
        string Message = "";
        keyvalue = GridViewZonList.DataKeys[e.RowIndex].Value.ToString().Trim();
        Label labelZonCode = (Label)GridViewZonList.Rows[e.RowIndex].FindControl("lblZonCode");
        Label labelZonName = (Label)GridViewZonList.Rows[e.RowIndex].FindControl("lblZonName");
        
  
        Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
        //try
        //{                   
            

            //Call the Delete method of business layer
            int StatusId = objBalZonDetail.DeleteDataRow(keyvalue);

            DataTable DT = new DataTable();
            string strSqlstatement = "select FormId  from FormMaster where FormUrl like '%Admin\\FrmZonList.aspx'";
            int intFormId = (int)SqlHelper.ExecuteScalar(AppSetting.ActivateConnection, CommandType.Text, strSqlstatement);
            Trace.Warn("intFormId" + intFormId);
            

            Message = getXmlMessage(Convert.ToInt32(intFormId), StatusId, "delete");
            if (StatusId == 1)
            {
                ObjGenBal.audittype = ENUMAUDITTYPE.ZonDeleted.GetHashCode().ToString();
                ObjGenBal.userid = objectSessionHolderPersistingData.User_ID;
                ObjGenBal.auditdetail = "Zone '" + labelZonName.Text + "(ID:" + labelZonCode.Text + ")' Deleted";
                ObjGenBal.machineIP = Request.UserHostAddress.ToString();
                ObjGenBal.AuditInsert();
                LabelMessage.CssClass = "successmsg";
                LabelMessage.Text = Message;//"Record Successfully Deleted";
               
                BindGrid();

            }
            else
            {
                Message = getXmlMessage(Convert.ToInt32(ENUMFORMCODE.Zonemaster.GetHashCode()), 0, "delete");
                LabelMessage.CssClass = "errormsg";
               //    LabelMessage.Text = Message;//"Record can not be Deleted! Please try again";

            }

        //}
        //catch (Exception ex)
        //{
        //    LabelMessage.CssClass = "errormsg";
        //    LabelMessage.Text = "Please contact to System Administrator; Error message is: " + ex.Message.ToString(); ;
        //}
        //finally
        //{
        //    objBalZonDetail = null;
        //}
    }

    protected void GridViewZonList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        GridViewZonList.PageIndex = e.NewPageIndex;
        BindGrid();
    }

    protected void btnAdd_Click(object sender, ImageClickEventArgs e)
    {
        Session["Mode"] = "insert";
        Response.Redirect("FrmZonMaster.aspx");
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
    protected void GridViewZonList_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
 