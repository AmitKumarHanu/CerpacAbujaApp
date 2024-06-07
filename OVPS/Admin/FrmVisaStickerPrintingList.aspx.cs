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
using System.Data.SqlClient;
using DataAccessLayer;

public partial class Admin_FrmVisaStickerPrintingList : System.Web.UI.Page
{
   #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    #endregion
    BaseLayer.General_function ObjGenBal = null;
    string companyid;
    //Session Holder  for Persisting Data Class Object intialization
   // BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    protected void Page_PreInit(object sender, EventArgs e)
    {
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        companyid = objectSessionHolderPersistingData.CompanyId;
        if (objectSessionHolderPersistingData == null)
        {
            Response.Redirect("../Login.aspx");
        }
        Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
        LabelMessage.Visible = false;
    }
   
   
    protected void Page_Load(object sender, EventArgs e)
    {
       
        

        if (!IsPostBack)
        {
            Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            LabelMessage.CssClass = "errormsg";
            LabelMessage.Visible = false;

            BindGrid();
        }
        if (objectSessionHolderPersistingData == null)
        {
            Response.Redirect("../Login.aspx");
        }
       // BtnAccessibilty();
    }

    protected void BindGrid()
    {

        DataTable dt = new DataTable();


        BusinessEntityLayer.BalVisaStickerPrintingList ObjBalVisaStickerPrintingList = null;
        try
        {
            ObjBalVisaStickerPrintingList = new BusinessEntityLayer.BalVisaStickerPrintingList();

            dt = ObjBalVisaStickerPrintingList.GetApplicantList();

            GridViewVisaStickerList.DataSource = dt;
            GridViewVisaStickerList.DataBind();



        }
        catch (Exception ex)
        {
            Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            LabelMessage.CssClass = "errormsg";
            LabelMessage.Text = "Please contact to System Administrator; Error message is: " + ex.Message.ToString();

        }
        finally
        {
            ObjBalVisaStickerPrintingList = null;
            dt = null;
        }
    }



    protected void GridViewVisaStickerList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewVisaStickerList.PageIndex = e.NewPageIndex;
        BindGrid();
    }
    protected void GridViewVisaStickerList_RowEditing(object sender, GridViewEditEventArgs e)
    {
        string sApplicatoinID = string.Empty;
        sApplicatoinID = GridViewVisaStickerList.DataKeys[e.NewEditIndex].Value.ToString();
        Response.Redirect("FrmStickerNoAlloactionForm.aspx?ApplicationId=" + sApplicatoinID + "&&stickerno= ");
    }
    protected void Go_Click(object sender, EventArgs e)
    {
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        BusinessEntityLayer.BalVisaStickerPrintingList ObjBalVisaStickerPrintingList = null;
        string userid = string.Empty;
        userid = objectSessionHolderPersistingData.User_ID.ToString();
        DataTable dt = null;
        dt = new DataTable();

        try
        {
            string ApplicationId = TextAppId.Text.ToString();

            ObjBalVisaStickerPrintingList = new BusinessEntityLayer.BalVisaStickerPrintingList();

            dt = ObjBalVisaStickerPrintingList.GetApplicantStatusById(ApplicationId, userid);

            GridViewVisaStickerList.DataSource = dt;
            GridViewVisaStickerList.DataBind();
        }
        catch (Exception ex)
        {
            Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            LabelMessage.CssClass = "errormsg";
            LabelMessage.Text = "Please contact to System Administrator; Error message is: " + ex.Message.ToString();

        }
        finally
        {
            ObjBalVisaStickerPrintingList = null;
            dt = null;
        }
    }
    //public void BtnAccessibilty()
    //{
    //    ObjGenBal = new BaseLayer.General_function();
    //    DataTable DT = new DataTable();
    //    string strSqlstatement = "SELECT fa.Add_Permission,fa.Mod_Permission,fa.View_Permission,fa.Del_Permission " +
    //                             "FROM dbo.FORMACCESS fa " +
    //                             "INNER JOIN FormMaster fm ON fm.FormId = fa.FormId " +
    //                             "WHERE fm.FormUrl like '%Admin\\FrmVisaStickerPrintingList.aspx' AND USERID = " + Convert.ToString(objectSessionHolderPersistingData.User_ID) + "";

    //    Trace.Warn("strSqlstatement " + strSqlstatement);
    //    DT = ObjGenBal.FetchData(strSqlstatement);

    //    //if (DT.Rows[0]["Add_Permission"].ToString() == "N")
    //    //    btnAdd.Visible = false;

    //    //if (DT.Rows[0]["Mod_Permission"].ToString() == "N")
    //    //    GridViewVisaStickerList.Columns[3].Visible = false;
    //    if (companyid != "0")
    //    {
    //        if (DT.Rows.Count > 0)
    //        {
    //            if (DT.Rows[0]["Del_Permission"].ToString() == "N")
    //                GridViewVisaStickerList.Columns[7].Visible = false;
    //        }
    //    }
    //}
    //public void BtnAccessibilty()
    //{
    //    ObjGenBal = new BaseLayer.General_function();
    //    DataTable DT = new DataTable();
    //    string strSqlstatement = "select FormId  from FormMaster where FormUrl like '%Admin\\FrmVisaStickerPrintingList.aspx'";
    //    int intFormId = (int)SqlHelper.ExecuteScalar(AppSetting.ActivateConnection, CommandType.Text, strSqlstatement);
    //    Trace.Warn("intFormId" + intFormId);
    //    DT = ObjGenBal.TbBtnaccess(Convert.ToString(intFormId), objectSessionHolderPersistingData.User_ID);

    //    if (DT.Rows[0][3].ToString() == "N")
    //    {
    //        GridViewVisaStickerList.Columns[8].Visible = false;
    //    }
    //}
}

