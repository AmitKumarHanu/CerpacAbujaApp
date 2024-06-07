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

//------------------
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text.RegularExpressions;
using System.Net.Mail;
//using Microsoft.Reporting.WebForms;

using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Net;
using System.Windows;
using SHDocVw;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Web.Services;
using System.Web.Script.Services;


//------------

public partial class Admin_FrmCompanyMaster : System.Web.UI.Page
{
    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    #endregion

    BaseLayer.General_function objGeneral = null;
    BusinessEntityLayer.BalDocdetails ObjBalDocdetails = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        if (objectSessionHolderPersistingData == null)
        {
            Response.Redirect("../Login.aspx");
        }
        string companyid = objectSessionHolderPersistingData.CompanyId;
        Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
        try
        {
            LabelMessage.CssClass = "";
            LabelMessage.Text = "";
            txtCompanyName.Visible = true;
            txtRegno.Visible = true;
            //lblOpt.Text = "0";
            
            if (!IsPostBack)
            {
                btnSave.Visible = false;
                btnCancel.Visible = true;   
                btnSearch.Visible = true;
                btnUpdate.Visible = true;                
                btnAdd.Visible = true;                              
            }
           
            //if (!IsPostBack)
            //{
            //    txtCountryName.Visible = true;
            //    txtNationality.Visible = true;
            //    txtCountryCode.Visible = true;
            //    // BindDropdownList();
            //    if (Session["Mode"].ToString() == "insert")
            //    {
            //        btnSave.Visible = true;
            //        btnUpdate.Visible = false;

            //    }
            //    else if (Session["Mode"].ToString() == "update")
            //    {

            //        btnSave.Visible = false;
            //        btnUpdate.Visible = true;
            //        txtNationality.Visible = false;
            //        txtNationality.ReadOnly = true;
            //        if (Session["Country_code"] != null)
            //       FillFormField(Session["Country_code"].ToString());
            //    }

            //    else if (Session["Mode"].ToString() == "view")
            //    {
            //        FillFormField(Session["Country_Code"].ToString());
            //        btnSave.Visible = false;
            //        btnUpdate.Visible = false;
            //        txtCountryName.ReadOnly = true;
            //        txtNationality.Visible = true;
            //        txtCountryCode.Visible = true;
                   
            //    }
           // }
        }
        catch (Exception ex)
        {
            objGeneral = new BaseLayer.General_function();
            //Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            string err = objGeneral.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.CssClass = "warning-box";
            LabelMessage.Visible = true;
        }
    }
    /*********************Select Statement by country code************/

   
    
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        
        Response.Redirect("FrmCompanyMaster.aspx");
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {

        btnSearch.Visible = false;
        btnUpdate.Visible = false;
        btnAdd.Visible = false;
        
        btnSave.Visible = true;
        btnCancel.Visible = true;

        txtCompanyName.Text = "";
        txtRegno.Text = "";
        rdOptionList.SelectedIndex = -1;


    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        lblstatus.Visible = false;
        Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
        objGeneral = new BaseLayer.General_function();
        string Message = string.Empty;
        try
        {
            if (txtRegno.Text != "" && txtCompanyName.Text != "" && rdOptionList.SelectedIndex >=0)
            {
                int statusid = InsertCompany();
                Message = "Record successfully saved";
                if (statusid == 1)
                {
                    LabelMessage.Visible = true;
                    lblstatus.Visible = false;
                    LabelMessage.Text = "Saved Sucessfully";
                    LabelMessage.CssClass = "confirmation-box";
                    objGeneral.audittype = ENUMAUDITTYPE.DocCreated.GetHashCode().ToString();
                    objGeneral.userid = objectSessionHolderPersistingData.User_ID;
                    objGeneral.auditdetail = "Company Name '" + txtCompanyName.Text + "'( Registration No.:'" + txtRegno + "')";
                    objGeneral.machineIP = Request.UserHostAddress.ToString();
                    objGeneral.AuditInsert();
                    //  Session["Status"] = Message;//"Record successfully saved";
                    //Response.Redirect("FrmTitleList.aspx", false);
                }
                else if (statusid == 0)
                {
                     Message = "Company Registration No. already exists";
                    LabelMessage.CssClass = "errormsg";
                    LabelMessage.Text = Message;//"Record Can not be saved";
                    LabelMessage.Visible = true;
                
                    txtRegno.Focus();
                }
                else
                {
                    Message = "Record Can not be saved.Please Contact system administrator";
                    LabelMessage.CssClass = "errormsg";
                    LabelMessage.Text = Message;//"Record Can not be saved";
                    LabelMessage.Visible = true;
                }


            }
            else
            {

                // lblstatus.Visible = false;
                Message = "The company type, registration no. and company name must be enter";
                // lblstatus.Visible = true;
                LabelMessage.CssClass = "errormsg";
                LabelMessage.Text = Message;//"Record Can not be updated";
                LabelMessage.Visible = true;
                txtRegno.Focus();

            }
        }
        catch (Exception ex)
        {
            objGeneral = new BaseLayer.General_function();
            //Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            string err = objGeneral.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.CssClass = "warning-box";
            LabelMessage.Visible = true;
        }
        finally
        {
            ObjBalDocdetails = null;

        }
    }
    /**********************Insert Function for Nationality Master***************/
    public int InsertCompany()
    {
        SqlParameter[] pram = new SqlParameter[5];
        try
        {
            pram[0] = new SqlParameter("@Regno", txtRegno.Text.ToString().Trim());
            pram[1] = new SqlParameter("@Company", txtCompanyName .Text.ToString().Trim());
            pram[2] = new SqlParameter("@Opt", rdOptionList.SelectedItem.Text.ToString().Trim ());
            pram[3] = new SqlParameter("@Case", 1);
            pram[4] = new SqlParameter("@RT", 1);
            pram[4].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspCompNewRep", pram);
            return int.Parse(pram[4].Value.ToString());
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            pram = null;
        }
    }

    

    protected void btnUpdate_Click(object sender, EventArgs e)
    {

        Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
        objGeneral = new BaseLayer.General_function();
        string Message = "";
        try
        {
            if (txtRegno.Text != "" && txtCompanyName.Text != "" && rdOptionList.SelectedIndex >= 0)
            {

                int statusid = UpdateCompany();
                Message = "Record successfully Updated";
                lblstatus.Visible = false;
                if (statusid == 1)
                {

                    btnSearch.Visible = true;
                    btnUpdate.Visible = true;
                    btnAdd.Visible = true;
                    btnCancel.Visible = true;
                    btnSave.Visible = false;

                    LabelMessage.Visible = true;
                    lblstatus.Visible = false;

                    LabelMessage.Text = "Company Updated Sucessfully";
                    LabelMessage.CssClass = "confirmation-box";
                    objGeneral.audittype = "10";
                    objGeneral.userid = objectSessionHolderPersistingData.User_ID;
                    objGeneral.auditdetail = "Company Name : '" + txtCompanyName.Text + "' & Registration no. '" + txtRegno.Text + "' updated";
                    objGeneral.machineIP = Request.UserHostAddress.ToString();
                    objGeneral.AuditInsert();
                    Session["Status"] = Message;//"Record successfully Updated";

                    //Response.Redirect("FrmTitleList.aspx", false);

                }

                else
                {
                   // lblstatus.Visible = false;
                    Message = "Record Can not be updated";
                   // lblstatus.Visible = true;
                    LabelMessage.CssClass = "errormsg";
                    LabelMessage.Text = Message;//"Record Can not be updated";
                    LabelMessage.Visible = true;
                }
            }
            else
            {

               // lblstatus.Visible = false;
                Message = "The company registration no., From type  and company name must be enter"; 
               // lblstatus.Visible = true;
                LabelMessage.CssClass = "errormsg";
                LabelMessage.Text = Message;//"Record Can not be updated";
                LabelMessage.Visible = true;
                txtRegno.Focus();

            }
        }
        catch (Exception ex)
        {
            objGeneral = new BaseLayer.General_function();
            //Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            string err = objGeneral.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.CssClass = "warning-box";
            LabelMessage.Visible = true;
        }
        finally
        {
            ObjBalDocdetails = null;

        }
    }

    public int UpdateCompany()
    {
        SqlParameter[] pram = new SqlParameter[5];
        try
        {
            pram[0] = new SqlParameter("@Regno", txtRegno.Text.ToString());
            pram[1] = new SqlParameter("@Company", txtCompanyName.Text.ToString());
            pram[2] = new SqlParameter("@Opt", rdOptionList.SelectedItem.Text.ToString());
            pram[3] = new SqlParameter("@Case", 2);
            pram[4] = new SqlParameter("@RT", 1);
            pram[4].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspCompNewRep", pram);
            return int.Parse(pram[4].Value.ToString());
        }
        catch (Exception ex)
        {
            throw(ex);
        }
        finally
        {
            pram = null;
        }
    }



    protected void rdOptionList_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdOptionList.SelectedIndex == 0)
        {

            lblOpt.Text = "0";
        }
        else if (rdOptionList.SelectedIndex == 1)
        {

            lblOpt.Text = "1";
        }

       // btnUpdate.Visible = false;
       // btnSearch.Visible = true;
       
    }
   
}