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

public partial class Admin_FrmVisaTypeList : System.Web.UI.Page
{
    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    #endregion
    BusinessEntityLayer.BalVisaTypeDetails objBalVisaTypeDetail = null;
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
        objBalVisaTypeDetail = new BusinessEntityLayer.BalVisaTypeDetails();
        ObjGenBal = new BaseLayer.General_function();
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        if (objectSessionHolderPersistingData == null)
        {
            Response.Redirect("../Login.aspx");
        }

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
                                 "WHERE fm.FormUrl like '%Admin\\FrmVisaTypeList.aspx' AND USERID = " + Convert.ToString(objectSessionHolderPersistingData.User_ID) + "";

        Trace.Warn("strSqlstatement " + strSqlstatement);
        DT = ObjGenBal.FetchData(strSqlstatement);
        if (companyid != "0")
        {
            if (DT.Rows.Count > 0)
            {
                if (DT.Rows[0]["Add_Permission"].ToString() == "N")
                    btnAdd.Visible = false;

                if (DT.Rows[0]["Mod_Permission"].ToString() == "N")
                    GridViewVisaTypeList.Columns[3].Visible = false;

                if (DT.Rows[0]["Del_Permission"].ToString() == "N")
                    GridViewVisaTypeList.Columns[4].Visible = false;
                if (DT.Rows[0]["View_Permission"].ToString() == "N")
                    GridViewVisaTypeList.Columns[5].Visible = false;
            }
        }
    }

    //public void BtnAccessibilty()
    //{
    //    ObjGenBal = new BaseLayer.General_function();
    //    DataTable DT = new DataTable();
    //    string strSqlstatement = "select FormId  from FormMaster where FormUrl like '%Admin\\FrmVisaTypeList.aspx'";
    //    int intFormId = (int)SqlHelper.ExecuteScalar(AppSetting.ActivateConnection, CommandType.Text, strSqlstatement);
    //    Trace.Warn("intFormId" + intFormId);
    //    DT = ObjGenBal.TbBtnaccess(Convert.ToString(intFormId), objectSessionHolderPersistingData.User_ID);

    //    if (DT.Rows[0][2].ToString() == "N")
    //        btnAdd.Visible = false;
    //    if (DT.Rows[0][3].ToString() == "N")
    //    {
    //        GridViewVisaTypeList.Columns[4].Visible = false;

    //    }
    //    if (DT.Rows[0][4].ToString() == "N")
    //        GridViewVisaTypeList.Columns[5].Visible = false;  

    //}

    protected void BindGrid()
    {       
        DataSet ds = new DataSet();
       
        try
        {
            ds = objBalVisaTypeDetail.GetVisaTypeList();
            
            GridViewVisaTypeList.DataSource = ds;
            GridViewVisaTypeList.DataBind();            

        }
        catch (Exception ex)
        {
            Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            LabelMessage.CssClass = "errormsg";
            LabelMessage.Text = "Please contact to System Administrator; Error message is: " + ex.Message.ToString();

        }
        finally
        {
            objBalVisaTypeDetail = null;
            ds = null;
        }
    }   

    protected void GridViewVisaTypeList_RowEditing(object sender, GridViewEditEventArgs e)
    {
        string keyvalue;
        keyvalue = GridViewVisaTypeList.DataKeys[e.NewEditIndex].Value.ToString();
        Session["Mode"] = "update";
        Session["id"] = keyvalue;
        Response.Redirect("FrmVisaTypeMaster.aspx");
    }

    protected void GridViewVisaTypeList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {        
        
        string keyvalue;
        string Message = "";
        keyvalue = GridViewVisaTypeList.DataKeys[e.RowIndex].Value.ToString().Trim();

        Label lblVisaTypeCode = (Label)GridViewVisaTypeList.Rows[e.RowIndex].FindControl("lblVisaTypeCode");
        string VisaTypeCode = lblVisaTypeCode.Text.ToString();
        Label lblSVisaTypeName = (Label)GridViewVisaTypeList.Rows[e.RowIndex].FindControl("lblSVisaTypeName");
        string SVisaTypeName = lblSVisaTypeName.Text.ToString();
        Label lblVisaTypeName = (Label)GridViewVisaTypeList.Rows[e.RowIndex].FindControl("lblVisaTypeName");
        string VisaTypeName = lblVisaTypeName.Text.ToString();

        Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
        try
        {
            

            //Call the Delete method of business layer
            int StatusId = objBalVisaTypeDetail.DeleteDataRow(keyvalue);
            Message = getXmlMessage((Int32)ENUMFORMCODE.VisaTypeMaster.GetHashCode(), StatusId, "delete");

            if (StatusId == 1)
            {
                //----------------Insert into Audit---------
                BaseLayer.General_function ObjGenBal = new BaseLayer.General_function();
                ObjGenBal.audittype = ENUMAUDITTYPE.VisaTypeDeleted.GetHashCode().ToString();
                ObjGenBal.userid = objectSessionHolderPersistingData.User_ID;
                ObjGenBal.auditdetail = "VisaType '" + VisaTypeName + "'(Code:'" + VisaTypeCode + "')'" + "' deleted.";
                ObjGenBal.machineIP = Request.UserHostAddress.ToString();
                ObjGenBal.AuditInsert();
                //---------------End----------------------
                LabelMessage.CssClass = "successmsg";
                LabelMessage.Text = Message;//"Record Successfully Deleted";
                
                BindGrid();

            }
            else
            {
                Message = getXmlMessage((Int32)ENUMFORMCODE.VisaTypeMaster.GetHashCode(), 0, "delete");
                LabelMessage.CssClass = "errormsg";
                LabelMessage.Text = Message; //"Record can not be Deleted! Please try again";

            }

        }
        catch (Exception ex)
        {
            LabelMessage.CssClass = "errormsg";
            LabelMessage.Text = "Please contact to System Administrator; Error message is: " + ex.Message.ToString(); ;
        }
        finally
        {
            objBalVisaTypeDetail = null;
        }
    }

    protected void GridViewVisaTypeList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        GridViewVisaTypeList.PageIndex = e.NewPageIndex;
        BindGrid();
    }

    protected void GridApplicantPrintVisa_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string AppID = GridViewVisaTypeList.DataKeys[e.Row.RowIndex].Value.ToString();
            //Session["AppID"] = AppID.ToString();
            ImageButton keyButton = (ImageButton)e.Row.FindControl("btnView");
            keyButton.Attributes.Add("onClick", "javascript:return viewwork('" + AppID + "')");

        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Session["Mode"] = "insert";
        Response.Redirect("FrmVisaTypeMaster.aspx");
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
