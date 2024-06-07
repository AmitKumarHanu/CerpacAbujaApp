using System.Data;
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
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text.RegularExpressions;
using System.Net.Mail;
//using Microsoft.Reporting.WebForms;
using System.Xml.Linq;
using System.Drawing.Imaging;
using System.Collections.Generic;
using DataAccessLayer;
using System.Globalization;
using System.Text;
using System.Net;
using System.Net.NetworkInformation;


public partial class Admin_AuthorizationDetails : System.Web.UI.Page
{

    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    BusinessEntityLayer.BalApprovalReviewL1 ObjbalApporvalL1 = null;
    protected BaseLayer.General_function ObjGenBal = null;
    string AppID = "", category="";
    string UserID = null;
    Label LabelMessage = null;
    #endregion
    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
            if (objectSessionHolderPersistingData == null)
            {
                Response.Redirect("../Login.aspx");
            }
            UserID = objectSessionHolderPersistingData.User_ID.ToString();
            if (!IsPostBack)
            {
                A1.HRef = "javascript:NewCal('" + txtHQDate.ClientID + "','DDMMMYYYY','','',20,1)";
                A2.HRef = "javascript:NewCal('" + txtSCDate.ClientID + "','DDMMMYYYY','','',20,1)";
              
                if (string.IsNullOrEmpty(Request.QueryString["no"]) == false && Request.QueryString["no"] != "")
                {
                    AppID = Convert.ToString(Request.QueryString["no"]);
                    ViewState["AppID"] = AppID;

                    string QtyFresh = "Select cerpac_file_no, cerpac_no from people as a, peoplechild as b where a.cerpac_no=b.cerpacno and a.cerpac_File_no='" + AppID.Trim() + "' and b.formno='" + AppID.Trim() + "'";
                    ObjGenBal = new BaseLayer.General_function();
                    DataTable dtFresh = null;
                    dtFresh = new DataTable();

                    dtFresh = ObjGenBal.FetchData(QtyFresh);
                    if (dtFresh.Rows.Count > 0)
                    {
                        DivFreshAuth.Visible = true;
                        DivAuthDetails.Visible = false;
                        DivLoader.Visible = false;
                        DivAuthRecord.Visible = false;
                        trDeny.Visible = false;
                        trBtnOption.Visible = false;
                        trBtnOption.Visible = false;
                        DivCrossValidation.Visible = false;
                        DivApproved.Visible = false;
                        DivePassMsg.Visible = false;

                        lblCerpacNoAuth.Text = dtFresh.Rows[0]["cerpac_no"].ToString().Trim();
                        lblFormNoAuth.Text = dtFresh.Rows[0]["cerpac_file_no"].ToString().Trim();

                    }
                    else
                    {
                        DivFreshAuth.Visible = false;
                        DivAuthDetails.Visible = true;
                        DivLoader.Visible = true;
                        DivAuthRecord.Visible = true;
                        DivBtn.Visible = true;
                        trDeny.Visible = false;
                        trBtnOption.Visible = true;
        
                        DivCrossValidation.Visible = false;
                        DivApproved.Visible = false;
                        DivePassMsg.Visible = false;

                        if (string.IsNullOrEmpty(Request.QueryString["no"]) == false && Request.QueryString["no"] != "")
                        {
                            lblHeadQuatorAuth.Text = "";
                            lblStateCommadAuth.Text = "";

                            GetData(AppID);

                         

                        }

                    }
                }
                LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
                string queryforzonename = "select b.ZoneName,b.ZoneCode from UserZoneRelation as a, Zonemaster as b where a.ZoneCode=b.ZoneCode and a.UserId=" + objectSessionHolderPersistingData.User_ID + "";
                ObjGenBal = new BaseLayer.General_function();
                DataTable dt = null;
                dt = new DataTable();

                dt = ObjGenBal.FetchData(queryforzonename);
                if (dt.Rows.Count > 0)
                {
                    LabelMessage.Text = "Zone" + " " + dt.Rows[0]["ZoneName"].ToString();
                    LabelMessage.Visible = true;
                    LabelMessage.BorderStyle = BorderStyle.None;
                    txtZoneCode.Text = dt.Rows[0]["ZoneName"].ToString() + "--" + dt.Rows[0]["ZoneCode"].ToString();

                    lblZoneNameAuth.Text = dt.Rows[0]["ZoneName"].ToString();
                    lblZoneCodeAuth.Text = dt.Rows[0]["ZoneCode"].ToString();
                }



            }
        }
        catch (Exception ex)
        {
            ObjGenBal = new BaseLayer.General_function();
            string err = ObjGenBal.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.CssClass = "warning-box";
            LabelMessage.Visible = true;
        }
        finally
        {
            
            ObjGenBal = null;
        }

    
           

            
        
    }

    protected void BtnAuth_Click(object sender, EventArgs e)
    {
        DivFreshAuth.Visible = false;
        DivAuthDetails.Visible = true;
        DivLoader.Visible = true;
        DivAuthRecord.Visible = true;
        DivBtn.Visible = true;
        trDeny.Visible = false;
        trBtnOption.Visible = true;
        DivCrossValidation.Visible = false;
        DivApproved.Visible = false;
        DivePassMsg.Visible = false;

        if (string.IsNullOrEmpty(Request.QueryString["no"]) == false && Request.QueryString["no"] != "")
        {
      
            lblHeadQuatorAuth.Text = ddlHQAuthority.SelectedItem.Text + " have approved on date :";
            lblStateCommadAuth.Text = ddlSCAuthority.SelectedItem.Text +" have approved on date :";
            lblHeadDate.Text = txtHQDate.Text.ToString().Trim();
            lblStateDate.Text = txtSCDate.Text.ToString().Trim();
            GetData(ViewState["AppID"].ToString());
           
        }


    }
    protected void BtnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("AuthorizationProcess.aspx");
    }

   

    private void GetData(string ApplicationId)
    {
        DataTable Dt = null;
        Dt = new DataTable();
        DataTable dtcomp = null;
        dtcomp = new DataTable();
        DataTable dtbnk = null;
        DataTable dtretri = null;
        ObjGenBal = new BaseLayer.General_function();
        try
        {
           
            string queryforcerpac = "select a.*,b.* from People as a , PeopleChild as b where a.cerpac_no = b.CerpacNo and a.cerpac_file_no=b.FORMNO and (b.IsAuthorized=0 or b.IsAuthorized IS NULL) and b.IsVerified=1 and a.cerpac_no='" + ApplicationId.ToString() + "'";
            Dt = ObjGenBal.FetchData(queryforcerpac);
            if (Dt.Rows.Count > 0)
            {
                string queryforretrie = "Select * from VisaApplicationBiometric where VisaApplicationId='" + Dt.Rows[0]["people_id"].ToString().Trim() + "'";
                dtretri = ObjGenBal.FetchData(queryforretrie);
                if (dtretri.Rows.Count > 0)
                {
                    btnbio.Visible = true;
                }
                else
                {
                    btnbio.Visible = false;
                }

                /**********Fetch Image**************/

                byte[] picData = Dt.Rows[0]["userimage"] as byte[] ?? null;
                System.Drawing.Image newImage;

                if (picData != null)
                {
                    using (MemoryStream ms = new MemoryStream(picData))
                    {
                        // Load the image from the memory stream. How you do it depends
                        // on whether you're using Windows Forms or WPF.
                        // For Windows Forms you could write:
                        // System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(ms);

                        newImage = System.Drawing.Image.FromStream(ms);

                        if (Dt.Rows[0]["picture"] == null || Dt.Rows[0]["picture"].ToString() == "")
                            Dt.Rows[0]["picture"] = Dt.Rows[0]["cerpac_no"] + ".jpg";

                        if (!File.Exists(Server.MapPath("~") + "/Images/Logo/" + Dt.Rows[0]["picture"].ToString().Trim()))
                            newImage.Save(Server.MapPath("~") + "/Images/Logo/" + Dt.Rows[0]["picture"].ToString().Trim());
                        // newImage.Save("g:/Saurabh" + Dt.Rows[0]["picture"].ToString().Trim());

                    }
                }


                //ViewState["imagepath"] = Dt.Rows[0]["picture"].ToString().Trim();

                /***********************************/

                ImgPhoto.ImageUrl = "~/Images/Logo/" + Dt.Rows[0]["picture"].ToString().Trim();

                TxtPassportNo.Text = Dt.Rows[0]["passport_no"].ToString().Trim();
                TxtNationality.Text =  Dt.Rows[0]["nationality"].ToString().Trim();
                TxtPassportType.Text = string.Format("{0:dd/MM/yy}", Dt.Rows[0]["passport_issue_by"]).ToString().Trim();
                TxtDateOfIssue.Text = string.Format("{0:dd/MM/yy}", Dt.Rows[0]["passport_issue_date"]).ToString().Trim();
                txtdoe.Text = string.Format("{0:dd/MM/yy}", Dt.Rows[0]["passport_expiry_date"]).ToString().Trim();
                TxtPlaceOfIssue.Text = Dt.Rows[0]["passport_issue_loc"].ToString().Trim();
                TxtFirstName.Text = Dt.Rows[0]["forename"].ToString().Trim();
                TxtMiddleName.Text = Dt.Rows[0]["middle_name"].ToString().Trim();
                TxtLastName.Text = Dt.Rows[0]["surname"].ToString().Trim();
                txtcompid.Text = Dt.Rows[0]["company"].ToString().Trim();
                //--------------------------------------fetching company name from comp master-------------------------------              

                string queryforcomp = "Select regno,company from compmaster where regno = '" + Dt.Rows[0]["company"].ToString().Trim() + "'";               
                ObjGenBal = new BaseLayer.General_function();
                dtcomp = ObjGenBal.FetchData(queryforcomp);
                if (dtcomp.Rows.Count > 0)
                {
                    txtcompname.Text = dtcomp.Rows[0]["company"].ToString().Trim();
                    txtcompname.ToolTip = dtcomp.Rows[0]["company"].ToString().Trim();

                }
                else
                {
                    txtcompid.Text = "";
                    txtcompname.Text = "";
                }
                //-----------------------------------------------------------------end----------------------------------------
                txtcompadd1.Text = Dt.Rows[0]["company_add_1"].ToString().Trim();
                txtcompadd2.Text = Dt.Rows[0]["company_add_2"].ToString().Trim();
                txtdesig.Text = Dt.Rows[0]["designation"].ToString().Trim();
                txtphno.Text = Dt.Rows[0]["company_tel_no"].ToString().Trim();
                txtfaxno.Text = Dt.Rows[0]["company_fax_no"].ToString().Trim();
                txtfileno.Text = Dt.Rows[0]["cerpac_file_no"].ToString().Trim();
                txtemailprsn.Text = Dt.Rows[0]["Email1"].ToString().Trim();
                txtcntcnoprsn.Text = Dt.Rows[0]["ContactNo"].ToString().Trim();
                //ApplicationId = Dt.Rows[0]["people_id"].ToString().Trim();
                txtphyfileno.Text = Dt.Rows[0]["file_no"].ToString().Trim();


                //----------------------------------------------------data from bank--------------------------------------------
                dtbnk = new DataTable();
                string queryforbank = "select * from Uploaded_Excel_Data where FORMNO='" + txtfileno.Text.ToString().Trim() + "'";
                dtbnk = ObjGenBal.FetchData(queryforbank);
                if (dtbnk.Rows.Count > 0)
                {
                    txtbankfname.Text = dtbnk.Rows[0]["FirstName"].ToString().Trim();
                    txtbanklname.Text = dtbnk.Rows[0]["LastName"].ToString().Trim();
                    // TxtNationalitybank.Text = dtbnk.Rows[0]["NATIONALITY"].ToString().Trim();
                    //TxtFirstName.Text = dtbnk.Rows[0]["FirstName"].ToString().Trim();
                    //TxtLastName.Text = dtbnk.Rows[0]["LastName"].ToString().Trim();
                    // TxtNationality.Text = dtbnk.Rows[0]["NATIONALITY"].ToString().Trim();
                }
                //---------------------------------------------------- end -----------------------------------------------------
                //---------------------------------Code for pop up showing discrepency in data-----------------------
                string bankname = txtbankfname.Text.ToString().Trim() + " " + txtbanklname.Text.ToString().Trim();
                string namefromdb = TxtFirstName.Text.ToString().Trim() + " " + TxtLastName.Text.Trim();
                if (bankname != namefromdb)
                {
                  //  reviewmsg.Text = "Bank Details of the form does not tally with the details of the person. The Card will be produced with the bank details i.e. First name: " + TxtFirstName.Text + " and Last Name: " + TxtLastName.Text + "'";
                    ClientScriptManager CSM = Page.ClientScript;
                    string strconfirm = "<script>if(!window.confirm('Bank Details of the form does not tally with the details of the person. The Card will be produced with the bank details i.e. First name: " + TxtFirstName.Text + " and Last Name: " + TxtLastName.Text + "')){window.location.href='Default.aspx'}</script>";
                    CSM.RegisterClientScriptBlock(this.GetType(), "Confirm", strconfirm, false);
                }
                //-----------------------------------------------end--------------------------------------------------

           

                if (lblHeadQuatorAuth.Text != "")
                {
                    trHQAuth.Visible = true;
                    trSCAuth.Visible = true;
                }
                else
                {
                    trHQAuth.Visible = false;
                    trSCAuth.Visible = false;
                }
                if (Dt.Rows[0]["sex"].ToString().Trim() == "F")
                {
                    TxtSex.Text = "Female";
                }
                else
                {

                    TxtSex.Text = "Male";
                }
                TxtCerpacNo.Text = Dt.Rows[0]["cerpac_no"].ToString().Trim();
              
                if (Dt.Rows[0]["cerpac_receipt_date"].ToString().Trim() != null || Dt.Rows[0]["cerpac_receipt_date"].ToString().Trim() != "")
                {
                    TxtIssueDate.Text = string.Format("{0:dd/MM/yy}", Dt.Rows[0]["cerpac_receipt_date"]).ToString().Trim();
                    TxtExpDate.Text = string.Format("{0:dd/MM/yy}", Dt.Rows[0]["cerpac_expiry_date"]).ToString().Trim();
                }
                else
                {
                    TxtIssueDate.Text = "-----";
                    TxtExpDate.Text = "-----";
                }

                //if (TxtCerpacNo.Text.Trim() == txtfileno.Text.Trim() && (TxtCerpacNo.Text.Trim().Substring(0, 2) == "AO" || TxtCerpacNo.Text.Trim().Substring(0, 2) == "CR"))
                //{
                //    trBtn.Visible = true;
                //    DivBtn.Visible = false;
                //}
                //else
                //{
                //    trBtn.Visible = false;
                //    DivBtn.Visible = true;
                //}
            }
            else
            {
                DivAuthRecord.Style.Add("display", "none");
                warn.Style.Add("display", "");
            }
        }
        catch (Exception ex)
        {
            ObjGenBal = new BaseLayer.General_function();
            string err = ObjGenBal.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.CssClass = "warning-box";
            LabelMessage.Visible = true;
        }
        finally
        {
            ObjGenBal = null;
        }


    }
    protected void btnbio_Click(object sender, EventArgs e)
    {
        try
        {
            ObjGenBal = new BaseLayer.General_function();
            string queryforapp = "Select people_id from People where cerpac_no='" + TxtCerpacNo.Text.ToString() + "'";
            DataTable dt = new DataTable();
            dt = ObjGenBal.FetchData(queryforapp);
            string appid = dt.Rows[0]["people_id"].ToString().Trim();
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "Onclick", "<script>window.open('bioretrival.aspx?id=" + appid + "','PaperVisa','menubar=no,status=yes,Width=1000,Height=1020,top=50,left=5,scrollbar=yes');</script>");
        }
        catch (Exception ex)
        {
            ObjGenBal = new BaseLayer.General_function();
            string err = ObjGenBal.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.CssClass = "warning-box";
            LabelMessage.Visible = true;
        }
        finally
        {
            ObjGenBal = null;
        }
    }
    protected void btnverify_Click(object sender, EventArgs e)
    {
        //-------------Cross Check EPass category-------------------

        
        System.Threading.Thread.Sleep(5000);
        ObjbalApporvalL1 = new BusinessEntityLayer.BalApprovalReviewL1();
        ObjbalApporvalL1.UserId = objectSessionHolderPersistingData.User_ID;
        ObjbalApporvalL1.cerpacno = TxtCerpacNo.Text.ToString();
        ObjbalApporvalL1.authnotes = "";
        try
        {
            int status =0, imgflag=0;
            status = ObjbalApporvalL1.Authorize();

            //if (TxtCerpacNo.Text.Trim() == txtfileno.Text.Trim() && (TxtCerpacNo.Text.Trim().Substring(0, 2) == "AO" || TxtCerpacNo.Text.Trim().Substring(0, 2) == "CR"))
            //{
            //    if (category.ToString().Trim() == "ST" || category.ToString().Trim() == "CP")
            //    {
            //          status = ObjbalApporvalL1.Authorize();
            //    }
            //    else
            //    {
            //        LabelMessage.Text = "The expatriate should not have valid VISA type !!";
            //        LabelMessage.CssClass = "warning-box";
            //        LabelMessage.Visible = true;
            //    }
            //}
            //else
            //{
            //      status = ObjbalApporvalL1.Authorize();
            //}



            if (status == 1)
            {
               

                ObjGenBal = new BaseLayer.General_function();
                DataTable dtauthsign = null;
                dtauthsign = new DataTable();
                string queryforsign = "Select * from UserMaster where UserID=" + objectSessionHolderPersistingData.User_ID + "";
                dtauthsign = ObjGenBal.FetchData(queryforsign);
                if (dtauthsign.Rows.Count > 0)
                {
                    lblname.Text =  dtauthsign.Rows[0]["UserName"].ToString() ;
                    byte[] picData = dtauthsign.Rows[0]["usersig"] as byte[] ?? null;
                    System.Drawing.Image newImage;
                    if (picData != null)
                    {
                        using (MemoryStream ms = new MemoryStream(picData))
                        {
                            Bitmap img = (Bitmap)System.Drawing.Image.FromStream(ms);
                            newImage = System.Drawing.Image.FromStream(ms);

                            //  if (!File.Exists(Server.MapPath("~") + "/Images/sign/sig.jpg"))
                            newImage.Save(Server.MapPath("~") + "/Images/sign/sig.jpg");
                            // newImage.Save("g:/Saurabh" + Dt.Rows[0]["picture"].ToString().Trim());

                            Bitmap tempImage = new Bitmap(Server.MapPath("~") + "/Images/sign/sig.jpg");
                            tempImage.MakeTransparent();
                            tempImage.Save(Server.MapPath("~") + "/Images/sign/sig.jpg");

                        }
                    }
                    img_sign.ImageUrl = "~/Images/sign/sig.jpg";

                    imgflag = 1;
                }
                //-------------------Log Approval Authority Details-----------------
                if (imgflag == 1 && TxtCerpacNo.Text.Trim() == txtfileno.Text.Trim())
                {
                   
                   SqlConnection Connection = new SqlConnection();
                   Connection.ConnectionString = ConfigurationManager.ConnectionStrings["NigeriaConnectionString"].ConnectionString;                 
                   string command = "  Insert into tbl_AuthApproval (CerpacNo,FromNo,isAuth,AuthorizedBy,AuthorizedOn,AuthHeadCommandBy,AuthHeadCommandOn,AuthStateCommandBy,AuthStateCommandOn,ZoneCode,ZoneName) " +
                       "Values ('" + TxtCerpacNo.Text.Trim() + "','" + txtfileno.Text.Trim() + "',1,'" + lblname.Text.Trim() + "',GetDate(),'" + ddlHQAuthority.SelectedItem.Text + "','" + lblHeadDate.Text.ToString().Trim() +
                       "','" + ddlSCAuthority.SelectedItem.Text + "','" + lblStateDate.Text.ToString().Trim() + "','" + lblZoneCodeAuth.Text.Trim() + "','" + lblZoneNameAuth.Text.Trim() + "')";
                   SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.Text, command);
                   Connection.Close();
                }
                DivAuthRecord.Style.Add("display", "none");
                confirm.Style.Add("display", "");
                confirm.Attributes.Add("class", "animated-table bounceIn");
                tbl12.Style.Add("display", "none");

                DivAuthDetails.Visible = false;
                DivLoader.Visible = false;
                DivAuthRecord.Visible = false;
                DivCrossValidation.Visible = false;
                DivBtn.Visible = false;
                DivApproved.Visible = true;
                DivePassMsg.Visible = false;
            }
            else
            {


                DivAuthDetails.Visible = false;
                DivLoader.Visible = false;
                DivAuthRecord.Visible = false;
                DivCrossValidation.Visible = false;
                DivBtn.Visible = false;
                DivApproved.Visible = false;
                DivePassMsg.Visible = true;

            }
        }
        
        catch (Exception ex)
        {
            ObjGenBal = new BaseLayer.General_function();
            string err = ObjGenBal.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.CssClass = "warning-box";
            LabelMessage.Visible = true;
        }
        finally
        {
            ObjbalApporvalL1 = null;
        }
       
    }

 
   
    protected void btnAppliHist_Click(object sender, EventArgs e)
    {
        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "Onclick", "<script>window.open('viewAppliHist.aspx?AppID=" + TxtCerpacNo.Text.ToString() + "','PaperVisa','menubar=no,status=yes,Width=1000,Height=1020,top=50,left=5,scrollbar=yes');</script>"); 

    }

     //----------------------Check central server ping status----------------------------------
    public bool IsConnectedToInternet(string IPAddress)
    {
        string pingurl = IPAddress.ToString();

        Ping p = new Ping();
        try
        {
            PingReply reply = p.Send(pingurl, 3000);
            if (reply.Status == IPStatus.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch
        {

            return false;

        }
    }

    protected void btnProceedAuthorize_Click(object sender, EventArgs e)
    {
        try
        {

            //if (TxtCerpacNo.Text.Trim() == txtfileno.Text.Trim() && (TxtCerpacNo.Text.Trim().Substring(0, 2) == "AO" || TxtCerpacNo.Text.Trim().Substring(0, 2) == "CR"))
            //{


            //    Boolean Flag = false;
            //    string connection = System.Configuration.ConfigurationManager.ConnectionStrings["ePassCentral"].ToString();

            //    SqlConnection con = new SqlConnection(connection);

            //    string[] words = connection.Split(';');
            //    string DataSource = words[0].ToString().Trim();

            //    string[] cliendIP = DataSource.Split('=');

            //    Flag = IsConnectedToInternet(cliendIP[1].ToString());

            //    if (Flag == true)
            //    {
            //      int status=   CrossValidation();
            //      if (status == 1)
            //      {
            //          CrossValidtionAudit();
            //      }

            //      DivAuthDetails.Visible = false;
            //      DivLoader.Visible = false;
            //      trBtn.Visible = false;
            //      DivAuthRecord.Visible = false;
            //      DivCrossValidation.Visible = true;
            //      DivBtn.Visible = true;
            //      DivApproved.Visible = false;
            //      DivePassMsg.Visible = false;

            //    }
            //    else
            //    {
            //        DivAuthDetails.Visible = false;
            //        DivLoader.Visible = false;
            //        trBtn.Visible = false;
            //        DivAuthRecord.Visible = true;
            //        DivCrossValidation.Visible = false;
            //        DivBtn.Visible = true;
            //        DivApproved.Visible = false;
            //        DivePassMsg.Visible = false;
            //    }
            //}
        }
        catch (Exception ex)
        {
            ObjGenBal = new BaseLayer.General_function();
            string err = ObjGenBal.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.CssClass = "warning-box";
            LabelMessage.Visible = true;
        }
        finally
        {
            ObjbalApporvalL1 = null;
        }
    }

    public int CrossValidation()
    {


        //if (TxtCerpacNo.Text.Trim() == txtfileno.Text.Trim() && (TxtCerpacNo.Text.Trim().Substring(0, 2) == "AO" || TxtCerpacNo.Text.Trim().Substring(0, 2) == "CR"))
        //{


        //    Boolean Flag = false;
        //    string connection = System.Configuration.ConfigurationManager.ConnectionStrings["ePassCentral"].ToString();

        //    SqlConnection con = new SqlConnection(connection);

        //    string[] words = connection.Split(';');
        //    string DataSource = words[0].ToString().Trim();

        //    string[] cliendIP = DataSource.Split('=');

        //    Flag = IsConnectedToInternet(cliendIP[1].ToString());

        //    if (Flag == true)
        //    {
        //        string Query = "WITH CTE (first_name, last_name, passport_no, nationality, gender, uniqueid , category, arrival_date, port_entry, departure_date,RN) AS " +
        //        "( " +
        //         "SELECT first_name, last_name, a.passport_no as passport_no, a.nationality as nationality, gender, a.uniqueid as uniqueid, b.category, b.arrival_date, (Select locname from tbl_loc where locid=b.port_entry) as port_entry, b.departure_date, " +
        //         "RN = ROW_NUMBER() OVER (PARTITION BY a.uniqueid, a.passport_no ORDER BY a.uniqueid, a.passport_no,year(arrival_date) desc, month(arrival_date), day(arrival_date) desc  ) " +
        //         "FROM tbl_personal_detail a, tbl_movement_details b  " +
        //         "where a.uniqueid=b.uniqueid and b.passport_no=b.passport_no " +
        //        ")  " +
        //        "Select * from CTE  WHERE RN = 1 and passport_no='" + TxtPassportNo.Text.ToUpper().ToString() + "'";

        //        con.Open();
        //        SqlDataAdapter da = new SqlDataAdapter(Query, con);
        //        DataTable dt = new DataTable();
        //        da.Fill(dt);
        //        con.Close();
        //        con.Dispose();

        //        if (dt.Rows.Count > 0)
        //        {

        //            ePassFristName.Text = dt.Rows[0]["first_name"].ToString().Trim();
        //            ePassLastName.Text = dt.Rows[0]["last_name"].ToString().Trim();
        //            ePassPassportNo.Text = dt.Rows[0]["passport_no"].ToString().Trim();
        //            ePassNationality.Text = dt.Rows[0]["nationality"].ToString().Trim();
        //            ePassVISACategory.Text = dt.Rows[0]["category"].ToString().Trim();
        //            ePassArrivalDate.Text = dt.Rows[0]["arrival_date"].ToString().Trim();
        //            ePassPortofEntry.Text = dt.Rows[0]["port_entry"].ToString().Trim();

        //            category = ePassVISACategory.Text.Trim();

        //            if (ePassVISACategory.Text.Trim() == "CP")
        //                ePassVISACategory.Text = "CERPAC Card Holder";

        //            else if (ePassVISACategory.Text.Trim() == "ST")
        //                ePassVISACategory.Text = "STR VISA Holder";

        //            else if (ePassVISACategory.Text.Trim() == "DP")
        //                ePassVISACategory.Text = "Diplomat VISA Holder";

        //            else if (ePassVISACategory.Text.Trim() == "DT")
        //                ePassVISACategory.Text = "Dependent VISA Holder";

        //            else if (ePassVISACategory.Text.Trim() == "EP")
        //                ePassVISACategory.Text = "ePAss Holder";


        //            return 1;



        //        }

        //        else
        //        {


        //            return 0;
        //        }

        //    }
        //    return 0;
        //}
        return 0;
    }

    public int CrossValidtionAudit()
    {
       
            //if (TxtCerpacNo.Text.Trim() == txtfileno.Text.Trim() && (TxtCerpacNo.Text.Trim().Substring(0, 2) == "AO" || TxtCerpacNo.Text.Trim().Substring(0, 2) == "CR"))
            //{

            //    //---------------Insert Cross Validation data for Audit-------------------------


            //    SqlConnection Connection = new SqlConnection();
            //    Connection.ConnectionString = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;

            //    Connection.Open();
            //    string QtyCrossValidation = "Insert into CrossValidation (CrFirstName,CrLastName,CrCerpacNo,CrFromNo,CrCerpacReceiptDate,CrCerpacExpiryDate,CrPassportNo, " +
            //        " CrNationality,CrCompany,CrDesignation,BkFirstName,BkLastName,BkPassportNo,BkNationality,BkCompany,ePFirstName,ePLastName,ePPassportNo,ePNationality, " +
            //        " ePPortOfEntry,ePArrivalDate,ePVisaType,isCrossValidate,AuthBy,AuthorizedOn,ZoneName " +
            //        " Values ('" + TxtFirstName.Text.Trim() + "','" + TxtLastName.Text.Trim() + "','" + TxtCerpacNo.Text.Trim() + "','" + txtfileno.Text.Trim() + "','" + TxtIssueDate.Text.Trim() + "','" + TxtExpDate.Text.Trim() + "','" + TxtPassportNo.Text.Trim() +
            //        "', '" + TxtNationality.Text.Trim() + "','" + txtcompname.Text.Trim() + "','" + txtdesig.Text.Trim() + "','" + txtbankfname.Text.Trim() + "','" + txtbanklname.Text.Trim() + "' ,'" + TxtPassportNo.Text.Trim() + "','" + TxtNationality.Text.Trim() +
            //        "','" + txtcompname.Text.Trim() + "','" + ePassFristName.Text.Trim() + "','" + ePassLastName.Text.Trim() + "','" + ePassPassportNo.Text.Trim() + "','" + ePassNationality.Text.Trim() + "','" + ePassPortofEntry.Text.Trim() +
            //        "','" + ePassArrivalDate.Text.Trim() + "','" + ePassVISACategory.Text.Trim() + "','" + "Flag" + "','" + objectSessionHolderPersistingData.User_ID.Trim() + "','" + LabelMessage.Text.Trim() + "')";

            //    SqlCommand cmd1 = new SqlCommand(QtyCrossValidation, Connection);
            //    cmd1.ExecuteNonQuery();
            //    Connection.Close();

            //    return 1;

            //}
            //else
            //{
            //    LabelMessage.Text = "Kindly Check Cross Validation Audit Log !!";
            //    LabelMessage.CssClass = "warning-box";
            //    LabelMessage.Visible = true;

            //    return 0;
            //}

        return 0;
        
       
    }


  
    protected void btnDeny_Click(object sender, EventArgs e)
    {
        DivFreshAuth.Visible = false;
        DivAuthDetails.Visible = true;
        DivLoader.Visible = true;
        DivAuthRecord.Visible = true;
        trDeny.Visible = true;
        trBtnOption.Visible = false;        
        DivCrossValidation.Visible = false;
        DivApproved.Visible = false;
        DivePassMsg.Visible = false;
       

    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(5000);
        ObjbalApporvalL1 = new BusinessEntityLayer.BalApprovalReviewL1();
        ObjbalApporvalL1.UserId = objectSessionHolderPersistingData.User_ID;
        ObjbalApporvalL1.cerpacno = TxtCerpacNo.Text.ToString();
        ObjbalApporvalL1.authnotes = "";
        ObjbalApporvalL1.reason = txtReason.Text.ToString();
        ObjbalApporvalL1.fileno = txtfileno.Text.ToString();
        try
        {
            int status = ObjbalApporvalL1.Reject();
            if (status == 1)
            {
                
                DivAuthDetails.Visible = false;
                DivLoader.Visible = false;
                DivAuthRecord.Visible = false;
                DivCrossValidation.Visible = false;
                DivBtn.Visible = false;
                DivApproved.Visible = false ;
                DivePassMsg.Visible = false;
                ClientScriptManager CSM = Page.ClientScript;
                string strconfirm = "<script>if(!window.confirm('The Bank form number " + lblFormNoAuth.Text + " has rejected successful')){window.location.href='Default.aspx'}</script>";
                CSM.RegisterClientScriptBlock(this.GetType(), "Confirm", strconfirm, false);

                msg.Text = "The Bank form number " + lblFormNoAuth.Text + " has rejected successful";
            }
        }
        catch (Exception ex)
        {
            ObjGenBal = new BaseLayer.General_function();
            string err = ObjGenBal.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.CssClass = "warning-box";
            LabelMessage.Visible = true;
        }
        finally
        {
            ObjbalApporvalL1 = null;
        }
    }
}