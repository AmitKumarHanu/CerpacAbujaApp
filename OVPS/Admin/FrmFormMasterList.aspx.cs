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

public partial class FrmFormMasterList : System.Web.UI.Page
{

    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    #endregion

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
        if (!IsPostBack)
        {
            BindGrid();

        }

    }

    protected void BindGrid()
    {
       // int UserId = 3; //from current session
        //int CompanyId=3;
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        BusinessEntityLayer.BalAdminForm ObjBalAdminForm = null;
         try
        {    
        ObjBalAdminForm = new BusinessEntityLayer.BalAdminForm();


        ds = ObjBalAdminForm.FillGridFormList();

        GridViewFormList.DataSource = ds;
        GridViewFormList.DataBind();              
              
               
          
        }
        catch (Exception ex)
        {
            Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            LabelMessage.CssClass = "errormsg";
            LabelMessage.Text = "Please contact to System Administrator; Error message is: " + ex.Message.ToString(); 
            
        }
        finally
        {
            ObjBalAdminForm = null;
            dt = null;
        }
    }     
    
    protected void GridViewFormList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];

        if (e.CommandName.Equals("Edit"))
        {
            string flag = "y";
            int index = Convert.ToInt32(e.CommandArgument);
            int FormID = (int)GridViewFormList.DataKeys[index].Value;
            int keyvalue = (int)GridViewFormList.DataKeys[index].Value;
            //Label lblCompanyName = (Label)GridViewFormList.Rows[index].FindControl("lblCompanyName");
            //string CompanyName = lblCompanyName.Text.ToString();
            

            Response.Redirect("FrmFormMaster.aspx?FormID="+FormID+"& flag="+flag+"");
            
        }
        else if (e.CommandName.Equals("Delete"))
        {
            //string ss = "";
            int index = Convert.ToInt32(e.CommandArgument);
            int keyvalue = (int)GridViewFormList.DataKeys[index].Value;
            Label lblCompanyName = (Label)GridViewFormList.Rows[index].FindControl("lblCompanyName");
            string CompanyName = lblCompanyName.Text.ToString();
            BusinessEntityLayer.BalAdminForm ObjBalAdminForm = null;
            ObjBalAdminForm = new BusinessEntityLayer.BalAdminForm();
            int statusid = ObjBalAdminForm.DeleteDataRow(keyvalue);

            if (statusid == 1)
            {
                BaseLayer.General_function ObjGenBal = new BaseLayer.General_function();
                ObjGenBal.audittype = ENUMAUDITTYPE.CompanyDeleted.GetHashCode().ToString();
                ObjGenBal.userid = objectSessionHolderPersistingData.User_ID;
                ObjGenBal.auditdetail = "Company '" + CompanyName + "(ID:" + keyvalue + ")' Deleted";
                ObjGenBal.machineIP = Request.UserHostAddress.ToString();
                ObjGenBal.AuditInsert();
                Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
                LabelMessage.CssClass = "successmsg";
                LabelMessage.Text = "Record Successfully deleted.";

                //ss = GridViewFormList.Rows[index].Cells[5].Text; --for Bound field
                            
            }
            
        }
        
    }

    protected void GridViewFormList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BindGrid();
    }

    protected void GridViewFormList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        
       GridViewFormList.PageIndex = e.NewPageIndex;
        BindGrid();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("FrmFormMaster.aspx");
    }
}
