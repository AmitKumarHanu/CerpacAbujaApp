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
using System.IO;
using System.Drawing;

public partial class Admin_FrmFormMaster : System.Web.UI.Page
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
        string CompanyId = objectSessionHolderPersistingData.CompanyId;
        if (CompanyId == "0")

            this.Page.MasterPageFile = "~/MasterPage/MasterPageCompany.master";
        else
            this.Page.MasterPageFile = "~/MasterPage/MasterPageUser.master";
    }

    int statusid = 0;
    string FormId = "0";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
            string CompanyId = objectSessionHolderPersistingData.CompanyId;

            // get FormId throught querystring
            if (Request.QueryString.Count != 0)
            {
                FormId = Request.QueryString[0].ToString();
                ShowFormDetail(FormId);
            }
            BtnSubmit.Visible = true;
            BtnUpdate.Visible = true;

            

            
        }



    }


    public void ShowFormDetail(string FormId)
    {

        DataTable Dt = new DataTable();
        BusinessEntityLayer.BalAdminForm objFetchCompanyDetails = null;
        objFetchCompanyDetails = new BusinessEntityLayer.BalAdminForm();
        string Form_Id = (FormId == "") ? null : FormId;
        Dt = objFetchCompanyDetails.GetFormName(Form_Id.ToString());
        //DataTable Dt = new DataTable();
        string Form_Name = "";
        Form_Name = Dt.Rows[0]["FormName"].ToString();
        TxtFormName.Text = Form_Name;

        string FormUrl = "";
        FormUrl = Dt.Rows[0]["FormURL"].ToString();
        TxtDirectoryPath.Text = FormUrl;

        
        string FormStatus = "";
        FormStatus = Dt.Rows[0]["FormStatus"].ToString();
        if (FormStatus == "A")
        {
            CheckBoxStatus.Checked = true;
        }else{
            CheckBoxStatus.Checked = false;
        }
                
    }

    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        bool flag = true;

        // code to create the object at bussiness layer.
        BusinessEntityLayer.BalAdminForm ObjBalAdminForm = null;
        try
        {
            //set the properties defined at business layer.
            ObjBalAdminForm = new BusinessEntityLayer.BalAdminForm();

            ObjBalAdminForm.Form_Name = TxtFormName.Text;
            ObjBalAdminForm.Form_Url = TxtDirectoryPath.Text;
            if (CheckBoxStatus.Checked ==true){
                ObjBalAdminForm.Form_Status = "A";
            }else{
                ObjBalAdminForm.Form_Status = "I";
            }
            //ObjBalAdminForm.Form_Id = FormId;
                    
            statusid = ObjBalAdminForm.InsertFormMaster();
            FormId = statusid.ToString();
            if ((flag == true && (statusid >= 1)))
            {
                Trace.Warn("Flag=" + flag);
                Trace.Warn("status=" + statusid.ToString());
                //ButtonReset_Click();
                Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
                LabelMessage.CssClass = "successmsg";
                LabelMessage.Text = "Record Successfully Saved";
                ShowFormDetail(FormId);
               // Response.Redirect("FrmFormMasterList.aspx");
               
            }
            else if ((flag == true) && (statusid == 0))
            {
                Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
                LabelMessage.CssClass = "errormsg";
                LabelMessage.Text = "Record Already Exist";

            }


        }
        catch (Exception ex)
        {
            Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            LabelMessage.CssClass = "errormsg";
            LabelMessage.Text = "Record Saved";


        }
        



    }


    protected void ButtonUpdate_Click(object sender, EventArgs e)
    {
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];

         // code to create the object at bussiness layer.
        BusinessEntityLayer.BalAdminForm ObjBalAdminForm = null;

        try
        {

            //set the properties defined at business layer


            ObjBalAdminForm = new BusinessEntityLayer.BalAdminForm();

            ObjBalAdminForm.Form_Id = Request.QueryString[0].ToString() ;
            ObjBalAdminForm.Form_Name = TxtFormName.Text;
            ObjBalAdminForm.Form_Url = TxtDirectoryPath.Text;

            if (CheckBoxStatus.Checked ==true){
                ObjBalAdminForm.Form_Status = "A";
            }else{
                ObjBalAdminForm.Form_Status = "I";
            }
            
           statusid = ObjBalAdminForm.UpdateFormMaster();

            if (statusid == 1)
            {
                Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
                LabelMessage.CssClass = "successmsg";
                LabelMessage.Text = "Record Update Sucessfully";
                ShowFormDetail(Request.QueryString[0].ToString());

            }
            else if (statusid == 2)
            {
                Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
                LabelMessage.CssClass = "errormsg";
                LabelMessage.Text = "Record Already Exist";

            }


        }
        catch (Exception ex)
        {
            Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            LabelMessage.CssClass = "errormsg";
            LabelMessage.Text = ex.Message.ToString();

        }


    }

    protected void ButtonList_Click(object sender, EventArgs args) {
        Response.Redirect("FrmFormMasterList.aspx");
    }



}


