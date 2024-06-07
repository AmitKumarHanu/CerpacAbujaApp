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

public partial class Admin_HeaderRegistration : System.Web.UI.Page
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
        string Companyid = objectSessionHolderPersistingData.CompanyId;
        if (Companyid == "0")

            this.Page.MasterPageFile = "~/MasterPage/MasterPageCompany.master";
        else
            this.Page.MasterPageFile = "~/MasterPage/MasterPageUser.master";
    }
    int statusid = 0;    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
            string CompanyId = objectSessionHolderPersistingData.CompanyId;

            BtnSubmit.Visible = true;
            BtnUpdate.Visible = false;
            BtnReset.Visible = true;
            ImgLogo.Visible = false;
            string flag = "";


            //when SuperAdmin Update a Company Information by clicking Edit button,flag is checking throught querystring
            if (Request.QueryString.Count > 0)
            {
                flag = Request.QueryString[1].ToString();
            }

            //when SuperAdmin Update a Company Information by clicking Edit button
            if (CompanyId == "0" && flag == "y")
            {
                // get CompanyId throught querystring
                CompanyId = Request.QueryString[0].ToString();
                ShowCompanyDetail(CompanyId);
                BtnSubmit.Visible = false;
                BtnUpdate.Visible = true;
                BtnReset.Visible = false;
                ImgLogo.Visible = true;
            }

            //when SuperAdmin Register a Company Information
            else if (CompanyId == "0")
            {
                //ShowCompanyDetail();
                BtnSubmit.Visible = true;
                BtnUpdate.Visible = false;
                BtnReset.Visible = true;
            }

               //when company Admin Update his company information then CompanyId get throught session
            else
            {
                ShowCompanyDetail(CompanyId);

                BtnSubmit.Visible = false;
                BtnUpdate.Visible = true;
                BtnReset.Visible = false;
                ImgLogo.Visible = true;

            }
        }     
            
                
    }
    public void ShowCompanyDetail(string CompanyId)
    {

        DataSet Ds = new DataSet();
        BusinessEntityLayer.BalCompanyDetails objFetchCompanyDetails = null;
        objFetchCompanyDetails = new BusinessEntityLayer.BalCompanyDetails();
        string Company_Id = (CompanyId == "") ? null : CompanyId;
        Ds = objFetchCompanyDetails.GetCompanyInfo(Convert.ToInt32(Company_Id));
        //DataTable Dt = new DataTable();
        string Company_Name = "";
        Company_Name = Ds.Tables[0].Rows[0][0].ToString();
        txtcompanyname.Text = Company_Name;

        string Company_AddressLine1 = "";
        Company_AddressLine1 = Ds.Tables[0].Rows[0][1].ToString();
        txtaddressline1.Text = Company_AddressLine1;
     }

    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        string CompanyId = null;
        bool flag = true;

       // code to create the object at bussiness layer.
        BusinessEntityLayer.BalCompanyDetails ObjBalCompanyDetails = null;
        try
        {
            //set the properties defined at business layer.
            ObjBalCompanyDetails = new BusinessEntityLayer.BalCompanyDetails();

            ObjBalCompanyDetails.Company_Name = txtcompanyname.Text;
            ObjBalCompanyDetails.Comp_Address_Line1 = txtaddressline1.Text;
            ObjBalCompanyDetails.Comp_Address_Line2 = txtaddressline2.Text;
           
            ObjBalCompanyDetails.Created_By = objectSessionHolderPersistingData.User_ID;

           
            
            statusid = ObjBalCompanyDetails.InsertCompanyRegistration();
            CompanyId = statusid.ToString();
            if ((flag == true && (statusid >= 1)))
            {
                //---------Insert Into Audit---------
                BaseLayer.General_function ObjGenBal = new BaseLayer.General_function();
                ObjGenBal.audittype = ENUMAUDITTYPE.CompanyRegistered.GetHashCode().ToString();
                ObjGenBal.userid = objectSessionHolderPersistingData.User_ID;//superadmin id
                ObjGenBal.auditdetail = "Company '" + txtcompanyname.Text.ToString() + "(ID:" + statusid + ")" + "' Created";
                ObjGenBal.machineIP = Request.UserHostAddress.ToString();
                ObjGenBal.AuditInsert();
                //----------End-----------

                //ButtonReset_Click();
                Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
                LabelMessage.CssClass = "successmsg";
                LabelMessage.Text = "Record Successfully Saved";
                ShowCompanyDetail(CompanyId);
                ImgLogo.Visible = true;


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


        }




    }

    protected void ButtonReset_Click(object sender, EventArgs e)
    {
        txtcompanyname.Text = "";
        txtaddressline1.Text = "";
        txtaddressline2.Text = "";
        
    }

    protected void ButtonUpdate_Click(object sender, EventArgs e)
    {
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];

       
        string CompanyId = null;
        bool flag = true;

        // code to create the object at bussiness layer.
        BusinessEntityLayer.BalCompanyDetails ObjBalCompanyDetails = null;

        CompanyId = objectSessionHolderPersistingData.CompanyId;
        if (CompanyId == "0")
        {
            // get CompanyId throught querystring
            CompanyId = Request.QueryString[0].ToString();
        }


        try
        {

            //set the properties defined at business layer


            ObjBalCompanyDetails = new BusinessEntityLayer.BalCompanyDetails();

            ObjBalCompanyDetails.CompanyId = Convert.ToInt32(CompanyId);
            ObjBalCompanyDetails.Company_Name = txtcompanyname.Text;
            ObjBalCompanyDetails.Comp_Address_Line1 = txtaddressline1.Text;
            ObjBalCompanyDetails.Comp_Address_Line2 = txtaddressline2.Text;
    
            ObjBalCompanyDetails.Created_By = objectSessionHolderPersistingData.User_ID;
         
            statusid = ObjBalCompanyDetails.UpdateCompanyRegistration();

            if ((flag == true) && (statusid == 1))
            {
                //------------------Insert into Audit-------
                BaseLayer.General_function ObjGenBal = new BaseLayer.General_function();
                ObjGenBal.audittype = ENUMAUDITTYPE.CompanyInfoUpdated.GetHashCode().ToString();
                ObjGenBal.userid = objectSessionHolderPersistingData.User_ID;
                ObjGenBal.auditdetail = "Details of company '" + txtcompanyname.Text + "(ID:" + CompanyId + ")' Updated";
                ObjGenBal.machineIP = Request.UserHostAddress.ToString();
                ObjGenBal.AuditInsert();
                //-----------END_----------
                Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
                LabelMessage.CssClass = "successmsg";
                LabelMessage.Text = "Record Update Sucessfully";
                ShowCompanyDetail(ObjBalCompanyDetails.CompanyId.ToString());
                ImgLogo.Visible = true;

            }
            else if ((flag == true) && (statusid == 2))
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

}
