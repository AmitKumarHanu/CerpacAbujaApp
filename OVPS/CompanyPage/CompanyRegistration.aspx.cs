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

public partial class CompanyPage_CompanyRegistration : System.Web.UI.Page
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
        string Company_Name="";
        Company_Name = Ds.Tables[0].Rows[0][0].ToString();
        txtcompanyname.Text = Company_Name;

        string Company_AddressLine1 = "";
        Company_AddressLine1 = Ds.Tables[0].Rows[0][1].ToString();
        txtaddressline1.Text = Company_AddressLine1;

        string Company_AddressLine2 = "";
        Company_AddressLine2 = Ds.Tables[0].Rows[0][2].ToString();
        txtaddressline2.Text = Company_AddressLine2;

        string Company_AddressLine3 = "";
        Company_AddressLine3 = Ds.Tables[0].Rows[0][3].ToString();
        txtaddressline3.Text = Company_AddressLine3;

        string Company_ZipCode = "";
        Company_ZipCode = Ds.Tables[0].Rows[0][4].ToString();
        txtzipcode.Text = Company_ZipCode;

        string Company_FirstPhoneNo1 = "";
        Company_FirstPhoneNo1 = Ds.Tables[0].Rows[0][5].ToString();
        txtphoneno1.Text = Company_FirstPhoneNo1;

        string Company_FirstPhoneNo2 = "";
        Company_FirstPhoneNo2 = Ds.Tables[0].Rows[0][6].ToString();
        txtphoneno2.Text = Company_FirstPhoneNo2;

        string Company_FirstPhoneNo3 = "";
        Company_FirstPhoneNo3 = Ds.Tables[0].Rows[0][7].ToString();
        txtphoneno3.Text = Company_FirstPhoneNo3;

        string Company_FaxNo = "";
        Company_FaxNo = Ds.Tables[0].Rows[0][8].ToString();
        txtfaxno.Text = Company_FaxNo;

        string Company_WebSite = "";
        Company_WebSite = Ds.Tables[0].Rows[0][9].ToString();
        txtwebsite.Text = Company_WebSite;

        string Company_EmailId = "";
        Company_EmailId = Ds.Tables[0].Rows[0][10].ToString();
        txtEmailId.Text = Company_EmailId;

        string Company_Logo = "";
        Company_Logo = Ds.Tables[0].Rows[0][11].ToString();
        if (Company_Logo=="")
        {
            ImgLogo.ImageUrl = System.Configuration.ConfigurationManager.AppSettings["LogoUrl"].ToString() + "default_logo.jpg";
        }
        else
        {
            
            ImgLogo.ImageUrl = System.Configuration.ConfigurationManager.AppSettings["LogoUrl"].ToString() + Company_Logo;
        }
        //logobrowse.FileName(Company_Logo);
        

        


    }
       
    protected void BtnSubmit_Click(object sender, EventArgs e)
        {
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        string FileName = null;
        string FileNameWithoutExt = null;
        double FileSize;
        string LogoFileExtension = "";
        string CompanyId = null;
        int ImgHeight = 0;
        int Imgwidth = 0;
        bool flag = true;
       
        string LogoPath = Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["LogoPath"].ToString());


        // code to create the object at bussiness layer.
        BusinessEntityLayer.BalCompanyDetails ObjBalCompanyDetails = null;
        try
        {
            //set the properties defined at business layer.
            ObjBalCompanyDetails = new BusinessEntityLayer.BalCompanyDetails();

            ObjBalCompanyDetails.Company_Name = txtcompanyname.Text;
            ObjBalCompanyDetails.Comp_Address_Line1 = txtaddressline1.Text;
            ObjBalCompanyDetails.Comp_Address_Line2 = txtaddressline2.Text;
            ObjBalCompanyDetails.Comp_Address_Line3 = txtaddressline3.Text;
            ObjBalCompanyDetails.Company_Zip = txtzipcode.Text;
            ObjBalCompanyDetails.Company_Phone1 = txtphoneno1.Text;
            ObjBalCompanyDetails.Company_Phone2 = txtphoneno2.Text;
            ObjBalCompanyDetails.Company_Phone3 = txtphoneno3.Text;
            ObjBalCompanyDetails.Company_Fax = txtfaxno.Text;
            ObjBalCompanyDetails.Company_WebSite = txtwebsite.Text;
            ObjBalCompanyDetails.Company_EmailId = txtEmailId.Text;
            ObjBalCompanyDetails.Created_By = objectSessionHolderPersistingData.User_ID;

            //checking for logo??
            if (logobrowse.HasFile)
            {
                HttpPostedFile myfile = null;
                int ExtCheck = 0;
                myfile = logobrowse.PostedFile;

                LogoFileExtension = Path.GetExtension(myfile.FileName);
                FileName = Path.GetFileName(myfile.FileName);
                FileNameWithoutExt = Path.GetFileNameWithoutExtension(myfile.FileName);
                FileSize = myfile.ContentLength; // in bytes
                string ValidLogoExt = System.Configuration.ConfigurationManager.AppSettings["ValidlogoExtensions"].ToString();
                double Maxsize = Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["MaxLogoSize"]);
                double MaxLogoHeight = Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["MaxLogoHeight"]);
                double MaxLogoWidth = Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["MaxLogoWidth"]);
                ExtCheck = ValidLogoExt.IndexOf(LogoFileExtension);

                System.Drawing.Image UploadLogo = null;
                UploadLogo = System.Drawing.Image.FromStream(logobrowse.PostedFile.InputStream);
                ImgHeight = UploadLogo.Height;
                Imgwidth = UploadLogo.Width;
                // if any condition fails then set flag=false;

                if (!(ExtCheck == -1))
                {
                    if (FileSize <= Maxsize)
                    {
                        if ((ImgHeight <= MaxLogoHeight) && (Imgwidth <= MaxLogoWidth))
                        {
                            flag = true;
                            //upload the logo into the server
                            logobrowse.SaveAs(LogoPath + FileNameWithoutExt + "_" + txtcompanyname.Text + LogoFileExtension);
                        }
                        else
                        {
                            //message 
                            flag = false;
                            Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
                            LabelMessage.CssClass = "errormsg";
                            LabelMessage.Text = "Dimension of the logo is always within (60 * 200)";


                        }
                    }
                    else
                    {
                        //message
                        flag = false;
                        Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
                        LabelMessage.CssClass = "errormsg";
                        LabelMessage.Text = "Please Upload logo within 250kb";

                    }

                }
                else
                {
                    //message
                    flag = false;
                    Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
                    LabelMessage.CssClass = "errormsg";
                    LabelMessage.Text = "Invalid extension of the Logo,Please check the extension of logo(.jpg,.jpeg,.gif)!!";

                }
                ObjBalCompanyDetails.Company_Logo = FileNameWithoutExt + "_" + txtcompanyname.Text + LogoFileExtension;

            }
            else
            {

                ObjBalCompanyDetails.Company_Logo = "";
            }
                statusid = ObjBalCompanyDetails.InsertCompanyRegistration();
                CompanyId = statusid.ToString();
            if ((flag == true &&(statusid>=1)))
            {
                //---------Insert Into Audit---------
                BaseLayer.General_function ObjGenBal = new BaseLayer.General_function();
                ObjGenBal.audittype = ENUMAUDITTYPE.CompanyRegistered.GetHashCode().ToString();
                ObjGenBal.userid = objectSessionHolderPersistingData.User_ID;//superadmin id
                ObjGenBal.auditdetail = "Company '"+ txtcompanyname.Text.ToString()+ "(ID:"+ statusid +")"+ "' Created";
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
             else if((flag == true) &&(statusid==0))
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
            LabelMessage.Text = ex.Message.ToString() + "May Be logo with the same name exists already.";
           
            
        }
        


       
    }

    protected void ButtonReset_Click(object sender, EventArgs e)
    {
        txtcompanyname.Text = "";
        txtaddressline1.Text = "";
        txtaddressline2.Text = "";
        txtaddressline3.Text = "";
        txtzipcode.Text = "";
        txtphoneno1.Text = "";
        txtphoneno2.Text = "";
        txtphoneno3.Text = "";
        txtfaxno.Text = "";
        txtwebsite.Text = "";
        txtEmailId.Text = "";
        logobrowse.ID = "";

    }

    protected void ButtonUpdate_Click(object sender, EventArgs e)
    {
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
         
        string FileName = null;
        string FileNameWithoutExt = null;
        double FileSize;
        string CompanyId = null;
        string LogoFileExtension = "";
        int ImgHeight = 0;
        int Imgwidth = 0;
        bool flag = true;
        string LogoPath = Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["LogoPath"].ToString());
        

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
                ObjBalCompanyDetails.Comp_Address_Line3 = txtaddressline3.Text;
                ObjBalCompanyDetails.Company_Zip = txtzipcode.Text;
                ObjBalCompanyDetails.Company_Phone1 = txtphoneno1.Text;
                ObjBalCompanyDetails.Company_Phone2 = txtphoneno2.Text;
                ObjBalCompanyDetails.Company_Phone3 = txtphoneno3.Text;
                ObjBalCompanyDetails.Company_Fax = txtfaxno.Text;
                ObjBalCompanyDetails.Company_WebSite = txtwebsite.Text;
                ObjBalCompanyDetails.Company_EmailId = txtEmailId.Text;
                ObjBalCompanyDetails.Created_By = objectSessionHolderPersistingData.User_ID;

                //checking for logo??
                if (logobrowse.HasFile)
                {
                    HttpPostedFile myfile = null;
                    int ExtCheck = 0;
                    myfile = logobrowse.PostedFile;
                    LogoFileExtension = Path.GetExtension(myfile.FileName);
                    FileName = Path.GetFileName(myfile.FileName);
                    FileNameWithoutExt = Path.GetFileNameWithoutExtension(myfile.FileName);
                    FileSize = myfile.ContentLength; // in bytes
                    string ValidLogoExt = System.Configuration.ConfigurationManager.AppSettings["ValidlogoExtensions"].ToString();
                    double Maxsize = Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["MaxLogoSize"]);
                    double MaxLogoHeight = Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["MaxLogoHeight"]);
                    double MaxLogoWidth = Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["MaxLogoWidth"]);
                    ExtCheck = ValidLogoExt.IndexOf(LogoFileExtension);

                    System.Drawing.Image UploadLogo = null;
                    UploadLogo = System.Drawing.Image.FromStream(logobrowse.PostedFile.InputStream);
                    ImgHeight = UploadLogo.Height;
                    Imgwidth = UploadLogo.Width;
                    // if any condition fails then set flag=false;

                    if (!(ExtCheck == -1))
                    {
                        if (FileSize <= Maxsize)
                        {
                            if ((ImgHeight <= MaxLogoHeight) && (Imgwidth <= MaxLogoWidth))
                            {
                                flag = true;
                                string LogoName = null;
                                string LogoPath1 = null;

                                
                                 LogoName = FileNameWithoutExt + "_" + txtcompanyname.Text + LogoFileExtension;
                                 LogoPath1 = LogoPath + LogoName;
                                
                                 if (File.Exists(LogoPath1))
                                {
                                    File.Delete(LogoPath1);
                                    //upload the logo into the server
                                    logobrowse.SaveAs(LogoPath + FileNameWithoutExt + "_" + txtcompanyname.Text + LogoFileExtension);
                                }
                                else 
                                {
                                    logobrowse.SaveAs(LogoPath + FileNameWithoutExt + "_" + txtcompanyname.Text + LogoFileExtension);
                                }
                                  
                                
                                
                                
                            }
                            else
                            {
                                //message 
                                flag = false;
                                Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
                                LabelMessage.CssClass = "errormsg";
                                LabelMessage.Text = "Dimension of the logo is always within (200 * 60)";


                            }
                        }
                        else
                        {
                            //message
                            flag = false;
                            Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
                            LabelMessage.CssClass = "errormsg";
                            LabelMessage.Text = "Please Upload logo within 250kb";

                        }

                    }
                    else
                    {
                        //message
                        flag = false;
                        Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
                        LabelMessage.CssClass = "errormsg";
                        LabelMessage.Text = "Invalid extension of the Logo,Please check the extension of logo(.jpg,.jpeg,.gif,.png)!!";

                    }

                    ObjBalCompanyDetails.Company_Logo = FileNameWithoutExt + "_" + txtcompanyname.Text + LogoFileExtension;
                }
                else
                {
                    if (ImgLogo.ImageUrl != "")
                    {
                        string[] LogofileName = ImgLogo.ImageUrl.Split('\\');
                        if (LogofileName.Length <= 1) { LogofileName = ImgLogo.ImageUrl.Split('/'); }
                        ObjBalCompanyDetails.Company_Logo = LogofileName[LogofileName.Length - 1].ToString();
                    }
                    else
                    {
                        ObjBalCompanyDetails.Company_Logo = "";
                    }
                            
                }
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
    

