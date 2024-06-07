﻿using System.Data;
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
using System.Windows;
using SHDocVw;
using System.Drawing.Drawing2D;
using System.Threading;

public partial class Admin_FrmApplicationDetailsForReject : System.Web.UI.Page
{
    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    BusinessEntityLayer.BalApprovalReviewL1 ObjbalApporvalL1 = null;
    protected BaseLayer.General_function ObjGenBal = null;
    string AppID = "";
    string FRNno = "";
    //string drpdwn = "";
    string LogoPath1 = "";
    string UserID = null;
    int Length = 0;
    byte[] Content;
    Label LabelMessage = null;
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        if (objectSessionHolderPersistingData == null)
        {
            Response.Redirect("../Login.aspx");
        }


        if ((Request.QueryString["rejection"]) == "5")
        {
            TxtFirstName.Enabled = false;
            TxtLastName.Enabled = false;
            TxtMiddleName.Enabled = false;
            TxtNationality.Enabled = false;
        }

        if (Session["company_id"] != null)
        {
            txtcompid.Text = Session["company_id"].ToString();
        }

        if (Session["company_name"] != null)
        {
            txtcompname.Text = Session["company_name"].ToString();
            txtcompname.ToolTip = Session["company_name"].ToString();

        }
        
        UserID = objectSessionHolderPersistingData.User_ID.ToString();
        LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
        //-----------------------------------------for disabling the hyperlink ------------------------------
        TreeView tvr = (TreeView)this.Page.Master.FindControl("TVLeftMenu");
        tvr.Visible = false;
        HyperLink hyp = (HyperLink)this.Page.Master.FindControl("hypHome");
        hyp.Attributes.Add("onclick", "if(!confirm('Are you sure you want to go to home page')) return false;");
        //-----------------------------------------------end ---------------------------------------------------
        string queryforzonename = "select b.ZoneName,b.ZoneCode from UserZoneRelation as a, Zonemaster as b where a.ZoneCode=b.ZoneCode and a.UserId=" + objectSessionHolderPersistingData.User_ID + "";
        ObjGenBal = new BaseLayer.General_function();
        DataTable dt = new DataTable();
        try
        {
            dt = ObjGenBal.FetchData(queryforzonename);
            if (dt.Rows.Count > 0)
            {
                LabelMessage.Text = "Zone" + " " + dt.Rows[0]["ZoneName"].ToString();
                LabelMessage.Visible = true;
                LabelMessage.BorderStyle = BorderStyle.None;
                txtZoneCode.Text = dt.Rows[0]["ZoneName"].ToString() + "--" + dt.Rows[0]["ZoneCode"].ToString();
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
            dt = null;
            ObjGenBal = null;
        }
        if (string.IsNullOrEmpty(Request.QueryString["no"]) == false && Request.QueryString["no"] != "" && string.IsNullOrEmpty(Request.QueryString["fno"]) == false && Request.QueryString["fno"] != "")
        {
            AppID = Convert.ToString(Request.QueryString["no"]);
            FRNno = Convert.ToString(Request.QueryString["fno"]);
            //drpdwn = Convert.ToString(Request.QueryString["dpr"]);
        }

        // BtnPreviewRecord.Attributes.Add("onclick", "window.open('viewcc.aspx?AppID=" + AppID + "', 'newwindow','toolbar=yes,location=no,menubar=no,width=770,height=650,resizable=no,scrollbars=yes,top=50,left=250');");
        // btnAppHistory.Attributes.Add("onclick", "window.open('viewAppHistory.aspx?AppID=" + AppID + "', 'newwindow','toolbar=no,location=no,menubar=no,width=775,height=750,fullscreen=no,resizable=no,scrollbars=no,top=50');");
        if (FRNno.ToString().Substring(0, 2) == "AR")
        {
            bnkdata.Style.Add("display", "none");
            bnkfname.Style.Add("display", "none");
            bnklname.Style.Add("display", "none");
            bnkmname.Style.Add("display", "none");
            bnknationality.Style.Add("display", "none");
        }
        if (!IsPostBack)
        {
            btnUploadCancel.Visible = false;
            ViewState["imagepath"] = null;
            if (string.IsNullOrEmpty(Request.QueryString["no"]) == false && Request.QueryString["no"] != "" && string.IsNullOrEmpty(Request.QueryString["fno"]) == false && Request.QueryString["fno"] != "")
            {
                GetData(AppID);
                // GetComments(AppID);

                A1.HRef = "javascript:NewCal('" + TxtDateOfIssue.ClientID + "','DDMMMYYYY','','',20,1)";
                doe.HRef = "javascript:NewCal('" + txtdoe.ClientID + "','DDMMMYYYY','','',11,11)";
                //A2.HRef = "javascript:NewCal('" + TxtIssueDate.ClientID + "','DDMMMYYYY','','',5,5)";
                if (txtcompname.Text.ToUpper() == "NIGER WIFE" || txtdesig.Text.ToUpper() == "NIGER WIFE")
                {
                    A3.HRef = "javascript:NewCal('" + TxtExpDate.ClientID + "','DDMMMYYYY','','',11,11)";
                }
                else
                {
                    A3.HRef = "javascript:NewCal('" + TxtExpDate.ClientID + "','DDMMMYYYY','','',5,5)";
                }

                A4.HRef = "javascript:NewCal('" + TxtDob.ClientID + "','DDMMMYYYY','','',78,1)";
                A5.HRef = "javascript:NewCal('" + txtdtemploymnt.ClientID + "','DDMMMYYYY','','',53,1)";
                binddrpdwn();
            }


            //  string CountryQuery = "Select Rejection_Description, Rejection_Code from rejection where Status= 'A' ";
            //ObjGenBal = new BaseLayer.General_function();
            // ObjGenBal.Fill_DDL(ddlRejection, CountryQuery, "Rejection_Description", "Rejection_Code");

            //  ShowHideButtons(AppID);
        }
        if (txtcompname.Text.ToUpper() == "NIGER WIFE" || txtdesig.Text.ToUpper() == "NIGER WIFE")
        {
            A3.HRef = "javascript:NewCal('" + TxtExpDate.ClientID + "','DDMMMYYYY','','',11,11)";
        }
        else
        {
            A3.HRef = "javascript:NewCal('" + TxtExpDate.ClientID + "','DDMMMYYYY','','',5,5)";
        }

        xmlretcomp();
    }

    public void xmlretcomp()
    {

        if (File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"XML\" + TxtCerpacNo.Text.ToString().Trim() + ".xml")))
        {
            string xmltext = "";
            xmltext = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"XML\" + TxtCerpacNo.Text.ToString().Trim() + ".xml"));
            string val = xmltext.Trim();
            string[] val1 = val.Split(',');
            txtcompid.Text = val1[0].ToString();
            txtcompname.Text = val1[1].ToString();
            txtcompname.ToolTip = val1[1].ToString();
            //
        }
    }
    protected void binddrpdwn()
    {
        try
        {
            ObjGenBal = new BaseLayer.General_function();
            string query = "select distinct(forename +''+ surname+'----'+cerpac_no) as Name,people_id from People";
            ObjGenBal.Fill_DDL(drpdpndt, query, "Name", "people_id");

            string query2 = "Select * from DesignationMaster";
            ObjGenBal.Fill_DDL(drprltn, query2, "Designation", "DesignationCode");

            string queryfortitle = "Select * from TitleMaster";
            ObjGenBal.Fill_DDL(drptitle, queryfortitle, "Title", "TitleCode");

            string queryfornationality = "Select * from NationalityMaster order by adjective";
            ObjGenBal.Fill_DDL(TxtNationality, queryfornationality, "adjective", "adjective");
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

    private void GetData(string ApplicationId)
    {
        try
        {
            TxtCerpacNo.Text = AppID.ToString().Trim();
            hidcerpac.Value = TxtCerpacNo.Text.ToString().Trim();
            Session["CerpaxNo"] = AppID.ToString().Trim();
            //----------------------------------------------------------------- data from db------------------------------------------------------

            if (AppID.Substring(0, 2) == "AO" || AppID.Substring(0, 2) == "AB" || AppID.Substring(0, 2) == "CR")
            {
                lbl_comp_rc.Visible = true;
                txtcompid.Visible = true;
            }
            else
            {
                lbl_comp_rc.Visible = false;
                txtcompid.Visible = false;
            }

            DataTable Dt = null;
            Dt = new DataTable();
            DataTable dtcomp = null;
            dtcomp = new DataTable();
            ObjGenBal = new BaseLayer.General_function();
            string queryforcerpac = "select * from People where cerpac_no='" + ApplicationId.ToString() + "'";
            Dt = ObjGenBal.FetchData(queryforcerpac);
            if (Dt.Rows.Count > 0)
            {


                /******************* Fetch If Dependent *******************************/
                DataTable Dt_dependent = null;
                Dt_dependent = new DataTable();
                string queryfordependent = "select * from Peoplechild where cerpacno='" + ApplicationId.ToString() + "' and formno=(select cerpac_file_no from people where cerpac_no='" + ApplicationId.ToString().Trim() + "') and IsDependent=1";
                Dt_dependent = ObjGenBal.FetchData(queryfordependent);

                if (Dt_dependent.Rows.Count > 0)
                {
                    radtype.SelectedValue = "1";
                    radtype_SelectedIndexChange(new object(), new EventArgs());

                    txt_depnt_peopleid.Text = Dt_dependent.Rows[0]["dependenton"].ToString().Trim();

                    DataTable dt_fetch_dept_detail = null;
                    dt_fetch_dept_detail = new DataTable();
                    string queryforcerpac_detail_dept = "select * from People where people_id='" + txt_depnt_peopleid.Text + "'";
                    dt_fetch_dept_detail = ObjGenBal.FetchData(queryforcerpac_detail_dept);

                    txt_dpndt.Text = dt_fetch_dept_detail.Rows[0]["cerpac_no"].ToString().Trim();
                    txt_dpndt_TextChanged(new object(), new EventArgs());
                    drprltn.SelectedValue = Dt_dependent.Rows[0]["designationcode"].ToString().Trim();
                }
                /*********************End Code Dependent *****************************/



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

                        if (!File.Exists(Server.MapPath("~") + "/Images/Logo/" + Dt.Rows[0]["picture"].ToString().Trim()))
                            newImage.Save(Server.MapPath("~") + "/Images/Logo/" + Dt.Rows[0]["picture"].ToString().Trim());
                        // newImage.Save("g:/Saurabh" + Dt.Rows[0]["picture"].ToString().Trim());

                    }
                }

                ViewState["imagepath"] = Dt.Rows[0]["picture"].ToString().Trim();
                ImgPhoto.ImageUrl = "~/Images/Logo/" + Dt.Rows[0]["picture"].ToString().Trim();

                TxtPassportNo.Text = Dt.Rows[0]["passport_no"].ToString().Trim();
                TxtNationality.SelectedValue = Dt.Rows[0]["nationality"].ToString().Trim();
                TxtPassportType.Text = Dt.Rows[0]["passport_issue_by"].ToString().Trim();
                TxtDateOfIssue.Text = string.Format("{0:d-MM-yyyy}", Dt.Rows[0]["passport_issue_date"]).ToString().Trim();
                txtdoe.Text = string.Format("{0:d-MM-yyyy}", Dt.Rows[0]["passport_expiry_date"]).ToString().Trim();
                TxtPlaceOfIssue.Text = Dt.Rows[0]["passport_issue_loc"].ToString().Trim();
                TxtFirstName.Text = Dt.Rows[0]["forename"].ToString().Trim();
                TxtMiddleName.Text = Dt.Rows[0]["middle_name"].ToString().Trim();
                TxtLastName.Text = Dt.Rows[0]["surname"].ToString().Trim();
                txtcompid.Text = Dt.Rows[0]["company"].ToString().Trim();
                TxtNationality.Text = Dt.Rows[0]["nationality"].ToString().Trim();
                txtphyfileno.Text = Dt.Rows[0]["file_no"].ToString().Trim();
                //--------------------------------------fetching company name from comp master-------------------------------
                string queryforcomp = "";
                if (AppID.Substring(0, 2) == "AO" || AppID.Substring(0, 2) == "AB" || AppID.Substring(0, 2) == "CR")
                {
                    queryforcomp = "Select * from compmaster where regno= '" + txtcompid.Text.ToString() + "'";
                }
                else
                {
                    queryforcomp = "Select * from CompMasterForARCR where regno = '" + txtcompid.Text.ToString() + "'";
                }
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
                    txtcompname.ToolTip = "";
                }
                //-----------------------------------------------------------------end----------------------------------------
                txtcompadd1.Text = Dt.Rows[0]["company_add_1"].ToString().Trim();
                txtcompadd2.Text = Dt.Rows[0]["company_add_2"].ToString().Trim();
                txtdesig.Text = Dt.Rows[0]["designation"].ToString().Trim();
                txtphno.Text = Dt.Rows[0]["company_tel_no"].ToString().Trim();
                txtfaxno.Text = Dt.Rows[0]["company_fax_no"].ToString().Trim();
                txtfileno.Text = FRNno.ToString();
                txtemailprsn.Text = Dt.Rows[0]["Email"].ToString().Trim();
                txtcntcnoprsn.Text = Dt.Rows[0]["ContactNo"].ToString().Trim();
                radsex.SelectedValue = Dt.Rows[0]["sex"].ToString().Trim();
                TxtCerpacNo.Text = Dt.Rows[0]["cerpac_no"].ToString().Trim();
                TxtFirstNamedb.Text = Dt.Rows[0]["forename"].ToString().Trim(); ;
                TxtLastNamedb.Text = Dt.Rows[0]["surname"].ToString().Trim();
                TxtNationalitydb.Text = Dt.Rows[0]["nationality"].ToString().Trim();
                //---------------------------------------------new changes---------------------------------------------
                drptitle.SelectedValue = Dt.Rows[0]["title"].ToString().Trim();
                txtpob.Text = Dt.Rows[0]["place_of_birth"].ToString().Trim();
                txtdtemploymnt.Text = string.Format("{0:d-MM-yyyy}", Dt.Rows[0]["employment_date"]).ToString().Trim();
                TxtDob.Text = string.Format("{0:d-MM-yyyy}", Dt.Rows[0]["date_of_birth"]).ToString().Trim();
                txtaddrnigeria1.Text = Dt.Rows[0]["nigeria_add_1"].ToString().Trim();
                txtaddrnigeria2.Text = Dt.Rows[0]["nigeria_add_2"].ToString().Trim();
                txtaddrabroad1.Text = Dt.Rows[0]["abroad_add_1"].ToString().Trim();
                txtaddrabroad2.Text = Dt.Rows[0]["abroad_add_2"].ToString().Trim();
                //------------------------------------------------end--------------------------------------------------
                if (Dt.Rows[0]["cerpac_receipt_date"].ToString().Trim() != null || Dt.Rows[0]["cerpac_receipt_date"].ToString().Trim() != "")
                {
                    TxtIssueDate.Text = string.Format("{0:d-MM-yyyy}", Dt.Rows[0]["cerpac_receipt_date"]).ToString().Trim();
                    hidreceiptdate.Value = string.Format("{0:d-MM-yyyy}", Dt.Rows[0]["cerpac_expiry_date"]).ToString().Trim();
                    TxtExpDate.Text = string.Format("{0:d-MM-yyyy}", Dt.Rows[0]["cerpac_expiry_date"]).ToString().Trim();
                }
                else
                {
                    TxtIssueDate.Text = "-----";
                    TxtExpDate.Text = "-----";
                }
            }
            else
            {
                detailtable.Style.Add("display", "none");
                warn.Style.Add("display", "");
            }
            //---------------------------------------------------------end----------------------------------------------------------------------
            //----------------------------------------------------------for generating documents-------------------------------------
            string cerpactype = FRNno.ToString().Trim().Substring(0, 2);
            getdocuments(cerpactype);
            //------------------------------------------------------------------end--------------------------------------------------
            //----------------------------------------------------data from bank--------------------------------------------
            DataTable dtbnk = new DataTable();
            ObjGenBal = new BaseLayer.General_function();
            string queryforbank = "select * from Uploaded_Excel_Data where FORMNO='" + FRNno.ToString().Trim() + "'";
            dtbnk = ObjGenBal.FetchData(queryforbank);
            if (dtbnk.Rows.Count > 0)
            {

                txtfnamebank.Text = dtbnk.Rows[0]["FirstName"].ToString().Trim();
                TxtLastNamebank.Text = dtbnk.Rows[0]["LastName"].ToString().Trim();
                TxtNationalitybank.Text = dtbnk.Rows[0]["NATIONALITY"].ToString().Trim();
                //TxtFirstName.Text = dtbnk.Rows[0]["FirstName"].ToString().Trim().Replace('-',' ').Replace('.',' ').Replace("'",string.Empty) ;
                //TxtLastName.Text = dtbnk.Rows[0]["LastName"].ToString().Trim().Replace('-', ' ').Replace('.', ' ').Replace("'", string.Empty);

            }
            //---------------------------------------------------- end -----------------------------------------------------
            //-------------------------------------------------------previous notes fetch--------------------------------------
            DataTable dtprev = null;
            dtprev = new DataTable();
            ObjGenBal = null;
            ObjGenBal = new BaseLayer.General_function();
            string queryforprevcomments = "select AuthNote from peoplechild where CerpacNo='" + TxtCerpacNo.Text.ToString().Trim() + "' and FORMNO='" + txtfileno.Text.ToString().Trim() + "'";
            dtprev = ObjGenBal.FetchData(queryforprevcomments);
            if (dtprev.Rows.Count > 0)
            {
                if (dtprev.Rows[0]["AuthNote"].ToString() != "")
                {
                    txtprevnotes.Text = dtprev.Rows[0]["AuthNote"].ToString();
                }
                else
                {
                    txtprevnotes.Text = "-----";

                }
            }
            //---------------------------------------------------------end-----------------------------------------------------
            //===================================================MRZ Data Fetch====================================================================
            ObjGenBal = new BaseLayer.General_function();
            DataTable dtmrz = new DataTable();
            string querymrz = "select * from MRZData where CerpacNo='" + TxtCerpacNo.Text.ToString().Trim() + "'";
            dtmrz = ObjGenBal.FetchData(querymrz);
            if (dtmrz.Rows.Count > 0)
            {
                TxtFirstNamemrz.Text = dtmrz.Rows[0]["MrzFirstName"].ToString().Trim();
                TxtLastNamemrz.Text = dtmrz.Rows[0]["MrzLastName"].ToString().Trim();
                TxtNationalitymrz.Text = dtmrz.Rows[0]["Nationality"].ToString().Trim();
            }

            //=====================================================end=============================================================================
            //---------------------------------Code for pop up showing discrepency in data-----------------------
            //string bankname = txtfnamebank.Text.ToString().Trim() + " " + TxtLastNamebank.Text.ToString().Trim();
            //string namefromdb = TxtFirstNamedb.Text.ToString().Trim() + " " + TxtLastNamedb.Text.Trim();
            //if (bankname != namefromdb)
            //{
            //    ClientScriptManager CSM = Page.ClientScript;

            //    string strconfirm = "<script>if(!window.confirm('Bank Details of the form does not tally with the details of the person. The Card will be produced with the bank details i.e. First name: " + TxtFirstName.Text + " and Last Name: " + TxtLastName.Text + "')){window.location.href='Default.aspx'}</script>";
            //    CSM.RegisterClientScriptBlock(this.GetType(), "Confirm", strconfirm, false);
            //}
            //-----------------------------------------------end--------------------------------------------------
            
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
    protected void getdocuments(string cerpactype)
    {
        ObjGenBal = new BaseLayer.General_function();
        DataTable dtdocs = new DataTable();
        string queryfordocs = "select c.DocName,a.DocCode from VisatypeDocLink as a ,VisaTypeMaster as b,DocumentMaster as c where a.VisaTypeCode=b.VisaTypeCode and a.DocCode=c.DocCode and b.SVisaTypeName='" + cerpactype.ToString() + "'";
        dtdocs = ObjGenBal.FetchData(queryfordocs);
        if (dtdocs.Rows.Count > 0)
        {
            chkbdoc.DataSource = dtdocs;
            chkbdoc.DataTextField = "DocName";
            chkbdoc.DataValueField = "DocCode";
            chkbdoc.DataBind();
        }
    }

    public static string ConvertDate(string date, string pattern)
    {

        if (string.IsNullOrEmpty(date) == false && date != "")
        {
            DateTime date2;
            if (DateTime.TryParseExact(date, pattern, CultureInfo.InvariantCulture, DateTimeStyles.None, out date2))
            {
                return date2.ToString("MM/d/yyyy");
            }
            else
            {
                return "";
            }
        }
        else
        {
            return "";
        }
    }

    protected void btnverify_Click(object sender, EventArgs e)
    {
        try
        {
            //-----------------code for checking company and nationality------------------------------
            if (txtcompid.Text == "" || txtcompid.Text == null)
            {
                Response.Write("<script>alert('Please enter company name')</script>");
                return;
            }
            if (TxtNationality.SelectedIndex <= 0)
            {
                Response.Write("<script>alert('Please enter Nationality')</script>");
                return;
            }

            //-------------------------company and nationality code ends here-------------------------------
            CultureInfo c = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = c.TextInfo;
            Trace.Warn(TxtExpDate.Text.ToString()); 
            //---------------------------------------------------- for checking expiry date of cerpac form-------------------------------------------
            DateTime d1 = Convert.ToDateTime(ConvertDate(TxtIssueDate.Text.ToString(), "d-MM-yyyy"));
            DateTime d2 = Convert.ToDateTime(ConvertDate(TxtExpDate.Text.ToString(), "d-MM-yyyy"));
            string d3 = (d2 - d1).TotalDays.ToString();
            // Response.Write("<script>alert('" + d3.ToString() + "')</script>");
            if ((TxtCerpacNo.Text.ToString().ToUpper().Substring(0, 2) == "AO" || TxtCerpacNo.Text.ToString().ToUpper().Substring(0, 2) == "AB" || TxtCerpacNo.Text.ToString().ToUpper().Substring(0, 2) == "CR") && int.Parse(d3) > 365)
            {
                Response.Write("<script>alert('Cerpac Expiry Date should be less than or equal to one year from issue date')</script>");
                return;
            }
            if ((TxtCerpacNo.Text.ToString().ToUpper().Substring(0, 2) == "AR" && int.Parse(d3) > 1464) && (txtcompname.Text.ToUpper() != "NIGER WIFE" && txtdesig.Text.ToUpper() != "NIGER WIFE"))
            {
                Response.Write("<script>alert('Cerpac Expiry Date for AR category should be less than or equal to four years from issue date')</script>");
                return;
            }
            //---------------------------------------------------- end----------------------------------------------------------------------------------- 
            //------------------------------------------------for checking if the receipt date is not extended-----------------------------------------------------
            string query = "select max(b.cerpac_receipt_Date) as cerpac_receipt_Date from people as a, peoplechild as b  where a.cerpac_no=b.cerpacno and a.cerpac_file_no != formno and b.IsRejected='1' and b.IsVerified='0' and a.cerpac_no='"+TxtCerpacNo.Text.ToString()+"'";
            ObjGenBal = new BaseLayer.General_function();
            DataTable dtrecpt = null;
            dtrecpt = new DataTable();
            dtrecpt = ObjGenBal.FetchData(query);
            if(dtrecpt !=null)
            {
                if (dtrecpt.Rows.Count > 0)
                {
                    if (dtrecpt.Rows[0]["cerpac_receipt_Date"].ToString() == null || dtrecpt.Rows[0]["cerpac_receipt_Date"].ToString()=="")
                    {
                        if (Convert.ToDateTime(ConvertDate(hidreceiptdate.Value, "d-MM-yyyy")) < d1)
                        {
                            Response.Write("<script>alert('Cerpac issue date is more than the expected date.Please Check again.')</script>");
                            return;
                        }
                    }
                    else
                    {
                        DateTime recptdb = Convert.ToDateTime(dtrecpt.Rows[0]["cerpac_receipt_Date"].ToString()).AddYears(1);
                        if (recptdb < d1)
                        {
                            Response.Write("<script>alert('Cerpac issue date is more than the expected date.Please Check again.')</script>");
                            return;
                        }
                    }
                }
                else
                {
                    if (Convert.ToDateTime(ConvertDate(hidreceiptdate.Value, "d-MM-yyyy")) < d1)
                    {
                        Response.Write("<script>alert('Cerpac issue date is more than the expected date.Please Check again.')</script>");
                        return;
                    }
                }
            }
            else
            {
                if (Convert.ToDateTime(ConvertDate(hidreceiptdate.Value, "d-MM-yyyy")) < d1)
                {
                    Response.Write("<script>alert('Cerpac issue date is more than the expected date.Please Check again.')</script>");
                    return;
                }
            }


            //----------------------------------------------------------end----------------------------------------------------------------------------------------
            
            if (radtype.SelectedValue == "1")
            {
                if (txt_dept_name.Text == "" || txt_dpndt.Text == TxtCerpacNo.Text.ToString().Trim())
                {
                    Response.Write("<script>alert('Please Fill Cerpac Number of the person you are Dependent On.')</script>");
                    return;
                }
            }

            // System.Threading.Thread.Sleep(5000);
            if (ViewState["imagepath"] == null)
            {
                Response.Write("<script>alert('You have not uploaded picture')</script>");
                return;
            }
            if (ViewState["imagepath"].ToString().Trim() == "" || ViewState["imagepath"] == null)
            {
                Response.Write("<script>alert('You have not uploaded picture')</script>");
                return;
            }
            ObjbalApporvalL1 = new BusinessEntityLayer.BalApprovalReviewL1();
            ObjbalApporvalL1.passportissueby = textInfo.ToTitleCase(TxtPassportType.Text.ToString());
            ObjbalApporvalL1.dateofissuep = ConvertDate(TxtDateOfIssue.Text.ToString(), "d-MM-yyyy");
            ObjbalApporvalL1.dateofexpp = ConvertDate(txtdoe.Text.ToString(), "d-MM-yyyy");
            ObjbalApporvalL1.placeissuep = textInfo.ToTitleCase(TxtPlaceOfIssue.Text.ToString());
            ObjbalApporvalL1.companyname = textInfo.ToTitleCase(txtcompname.Text.ToString());
            ObjbalApporvalL1.companyadd1 = textInfo.ToTitleCase(txtcompadd1.Text.ToString());
            ObjbalApporvalL1.companyadd2 = textInfo.ToTitleCase(txtcompadd2.Text.ToString());
            ObjbalApporvalL1.designation = textInfo.ToTitleCase(txtdesig.Text.ToString());
            ObjbalApporvalL1.comptelno = txtphno.Text.ToString();
            ObjbalApporvalL1.compfaxno = txtfaxno.Text.ToString();
            ObjbalApporvalL1.emailprsn = txtemailprsn.Text.ToString();
            ObjbalApporvalL1.contactprsn = txtcntcnoprsn.Text.ToString();
            ObjbalApporvalL1.cerpacno = TxtCerpacNo.Text.ToString();
            ObjbalApporvalL1.companyid = txtcompid.Text.ToString();
            ObjbalApporvalL1.zonenote = txtnotes.Text.ToString();
            ObjbalApporvalL1.fname = textInfo.ToTitleCase(TxtFirstName.Text.ToString());
            ObjbalApporvalL1.lname = textInfo.ToTitleCase(TxtLastName.Text.ToString());
            ObjbalApporvalL1.mname = textInfo.ToTitleCase(TxtMiddleName.Text.ToString());
            ObjbalApporvalL1.nationality = TxtNationality.SelectedValue.ToString();
            ObjbalApporvalL1.passportno = TxtPassportNo.Text.ToString();
            ObjbalApporvalL1.sex = radsex.SelectedValue.ToString();
            ObjbalApporvalL1.UserId = objectSessionHolderPersistingData.User_ID;
            ObjbalApporvalL1.fileno = txtfileno.Text.ToString().Trim();
            //================================================for inserting documents=============================================
            foreach (ListItem li in chkbdoc.Items)
            {
                if (li.Selected == true)
                {
                    ObjbalApporvalL1.docode = li.Value.ToString();
                    ObjbalApporvalL1.cerpacno = TxtCerpacNo.Text.ToString();
                    int statusdoc = ObjbalApporvalL1.InsertDoc();
                }
            }
            //================================================end=================================================================
            int status;
            if ((Request.QueryString["rejection"]) == "5")
            {
                 status = ObjbalApporvalL1.VerifyRejectionAfterQuality();
            }
            else
            {
                 status = ObjbalApporvalL1.VerifyRejection();
            }
            //=================================== for inserting dependent================================================
            SqlParameter[] pram = null;
            pram = new SqlParameter[16];
            pram[0] = new SqlParameter("@isdependent", radtype.SelectedValue.ToString());
            //pram[1] = new SqlParameter("@dependenton", drpdpndt.SelectedValue.ToString());
            pram[1] = new SqlParameter("@dependenton", txt_depnt_peopleid.Text);
            pram[2] = new SqlParameter("@dependentrelation", drprltn.SelectedValue.ToString());
            pram[3] = new SqlParameter("@CerpacNo", TxtCerpacNo.Text.ToString().Trim());
            pram[4] = new SqlParameter("@issuedate", ConvertDate(TxtIssueDate.Text.ToString(), "d-MM-yyyy"));
            pram[5] = new SqlParameter("@expirydate", ConvertDate(TxtExpDate.Text.ToString(), "d-MM-yyyy"));
            pram[6] = new SqlParameter("@ImagePath", ViewState["imagepath"].ToString());
            //------------------------------------new fields---------------------------------------
            pram[7] = new SqlParameter("@title", drptitle.SelectedValue.ToString());
            pram[8] = new SqlParameter("@placebirth", txtpob.Text.ToString());
            pram[9] = new SqlParameter("@fileno", txtphyfileno.Text.ToString());
            pram[10] = new SqlParameter("@dtemp", ConvertDate(txtdtemploymnt.Text.ToString(), "d-MM-yyyy"));
            pram[11] = new SqlParameter("@nigadd1", textInfo.ToTitleCase(txtaddrnigeria1.Text.ToString()));
            pram[12] = new SqlParameter("@nigadd2", textInfo.ToTitleCase(txtaddrnigeria2.Text.ToString()));
            pram[13] = new SqlParameter("@abdadd1", textInfo.ToTitleCase(txtaddrabroad1.Text.ToString()));
            pram[14] = new SqlParameter("@abdadd2", textInfo.ToTitleCase(txtaddrabroad2.Text.ToString()));
            pram[15] = new SqlParameter("@DOB", ConvertDate(TxtDob.Text.ToString(), "d-MM-yyyy"));

            //-------------------------------------- end------------------------------------------------------
            //pram[4] = new SqlParameter("@cerpac_file_no", txtfileno.Text.ToString());
            SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_CERPAC_DEPENDENCE_UPDATE", pram);
            //========================================end========================================
            /************* Insert Image in DB **************/

            byte[] data = null;
            FileInfo fInfo = new FileInfo(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["LogoUrl"].ToString()) + ViewState["imagepath"].ToString());
            Length = System.Convert.ToInt32(fInfo.Length);
            byte[] Content = new byte[Length];
            /// <summary>
            /// The Read method is used to read the file from the ImageToUpload control </summary>
            //int Content1=ImageToUpload.PostedFile.InputStream.Read(Content,0,Length);
            long numBytes = fInfo.Length;
            FileStream fStream = new FileStream(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["LogoUrl"].ToString()) + ViewState["imagepath"].ToString(), FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fStream);
            data = br.ReadBytes((int)numBytes);


            SqlConnection Connection = new SqlConnection();
            Connection.ConnectionString = ConfigurationManager.ConnectionStrings["NigeriaConnectionString"].ConnectionString;
            SqlCommand Command = new SqlCommand("update people set userImage=@ImageFile where cerpac_no='" + TxtCerpacNo.Text + "'", Connection);

            SqlParameter imageFileParameter = new SqlParameter("@ImageFile", SqlDbType.Image);
            // imageFileParameter.Value = ViewState["contentImg"];
            imageFileParameter.Value = data;
            Command.Parameters.Add(imageFileParameter);
            Connection.Open();
            /// <summary>
            /// The SQL statement is executed. ExecuteNonQuery is used since no records
            /// will be returned. </summary>
            Command.ExecuteNonQuery();
            /// <summary>
            /// The connection is closed </summary>
            Connection.Close();
            /************* End Insert Image in DB **********/

            if (status == 1)
            {
                confirm.Style.Add("display", "");
                confirm.Attributes.Add("class", "confirmation-box animated-table bounceIn");
                detailtable.Style.Add("display", "none");
                gridtable.Style.Add("display", "none");
                imgbak.Style.Add("display", "none");
                btnUploadCancel.Visible = false;
                btnCheckSheet.Visible = true;
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
    protected void btnscanmrz_Click(object sender, EventArgs e)
    {
        btngetdata.Visible = true;
        btnscanmrz.Visible = false;
        System.Web.HttpBrowserCapabilities browser = Request.Browser;
        string s = browser.Browser;
        // Response.Write("<script>alert('You are using " + s.ToString() + "')</script>");
        if (s == "IE")
        {
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "Onclick", "<script>window.open('ScanPage.aspx?id=" + TxtCerpacNo.Text.ToString().Trim() + "','PaperVisa','menubar=no,status=yes,Width=1000,Height=600,top=50,left=5');</script>");
        }
        else
        {

            // Trace.Warn("internetexplorer");
           
            openbrowser();
            //System.Diagnostics.Process.Start("iexplore.exe");
            //this.ClientScript.RegisterClientScriptBlock(this.GetType(), "Onclick", "<script>window.open('ScanPage.aspx','PaperVisa','menubar=no,status=yes,Width=1000,Height=600,top=50,left=5');</script>");

        }
    }
    public void openbrowser()
    {

        //System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo("IExplore.exe", "http://google.com");
        //System.Diagnostics.Process.Start(startInfo);
        //startInfo = null;



       // Trace.Warn("internetexplorerfunction");
        string id = TxtCerpacNo.Text.ToString();
        InternetExplorer ie = new InternetExplorerClass();
        object nil = new object();
        object blank = "_blank";
        string page = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, "");
        string url = page + "/Admin/ScanPage.aspx?id=" + id.ToString() + "";
       // string url = "http://google.com";
        ie.Navigate(url, ref nil, ref blank, ref nil, ref nil);

    }
    protected void btngetdata_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Request.QueryString["no"]) == false && Request.QueryString["no"] != "")
        {
            AppID = Convert.ToString(Request.QueryString["no"]);
        }

        GetData(AppID);
        btngetdata.Visible = false;
    }

    protected void btnAppliHist_Click(object sender, EventArgs e)
    {
        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "Onclick", "<script>window.open('viewAppliHist.aspx?AppID=" + TxtCerpacNo.Text.ToString() + "','PaperVisa','menubar=no,status=yes,Width=1000,Height=1020,top=50,left=5,scrollbar=yes');</script>");

    }

    protected void radtype_SelectedIndexChange(object sender, EventArgs e)
    {
        
            //if (radtype.SelectedValue == "1")
            //{
            //    lbldeprel.Visible = true;
            //    drprltn.Visible = true;
            //    lbldpndty.Visible = true;
            //    drpdpndt.Visible = true;
            //}
            //else
            //{
            //    lbldeprel.Visible = false;
            //    drprltn.Visible = false;
            //    lbldpndty.Visible = false;
            //    drpdpndt.Visible = false;
            //}


        if (radtype.SelectedValue == "1")
        {
            lbldeprel.Visible = true;
            drprltn.Visible = true;
            lbldpndty.Visible = true;
            drpdpndt.Visible = true;
            // txtdesig.Text = drprltn.SelectedItem.Text;
            txtdesig.Enabled = false;



            //Saurabh Bansal
            drpdpndt.Visible = false;
            lbl_dept_name.Visible = false;
            txt_dept_name.Visible = false;
            txt_dpndt.Visible = true;
            txt_dpndt.Text = "";
            txt_dept_name.Text = "";
            txt_depnt_peopleid.Text = "";

        }
        else
        {
            lbldeprel.Visible = false;
            drprltn.Visible = false;
            lbldpndty.Visible = false;
            drpdpndt.Visible = false;
            txtdesig.Enabled = true;
            txtdesig.Text = "";

            //Saurabh Bansal
            drpdpndt.Visible = false;
            lbl_dept_name.Visible = false;
            txt_dept_name.Visible = false;
            txt_dpndt.Visible = false;
            txt_dpndt.Text = "";
            txt_dept_name.Text = "";
            txt_depnt_peopleid.Text = "";


        }
        
    }

    protected void btnUploadPhoto_Click(object sender, EventArgs e)
    {

        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        ObjGenBal = new BaseLayer.General_function();

        try
        {
            //FOR PHOTO PART       
            string FileName = null;
            string FileNameWithoutExt = null;
            double FileSize;
            string LogoFileExtension = "";
            int ImgHeight = 0;
            int Imgwidth = 0;

            string LogoPath = Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["LogoPath2"].ToString());
            //FOR PHOTO PART

            if (TxtCerpacNo.Text.ToString() == string.Empty)
            {
                //    LabelMessage.CssClass = "errormsg";
                //    LabelMessage.Text = "Please enter passport number and nationality before browsing and uploading photo";
                Response.Write("<script>alert('Please enter Cerpac No First')</script>");
                return;
            }
            //checking for Photo??
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
                double MinLogoWidth = Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["MinLogoWidth"]);
                double MinLogoHeight = Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["MinLogoHeight"]);

                ExtCheck = ValidLogoExt.IndexOf(LogoFileExtension);

                System.Drawing.Image UploadLogo = null;

                // if any condition fails then set flag=false;

                /**************Start Code For Save Image in DB****************/
                Length = System.Convert.ToInt32(logobrowse.PostedFile.InputStream.Length);

                byte[] Content = new byte[Length];

                logobrowse.PostedFile.InputStream.Read(Content, 0, Length);

                ViewState["contentImg"] = Content;

                /**************End Code For Save Image in DB****************/

                if (!(ExtCheck == -1))
                {
                    UploadLogo = System.Drawing.Image.FromStream(logobrowse.PostedFile.InputStream);
                    ImgHeight = UploadLogo.Height;
                    Imgwidth = UploadLogo.Width;

                    if (FileSize <= Maxsize)
                    {
                        if ((ImgHeight <= MaxLogoHeight) && (Imgwidth <= MaxLogoWidth) && (ImgHeight >= MinLogoHeight) && (Imgwidth >= MinLogoWidth))
                        {



                            string LogoName = null;

                            LogoName = TxtCerpacNo.Text.ToString() + LogoFileExtension;
                            LogoPath1 = LogoPath + LogoName;

                            if (File.Exists(LogoPath1))
                            {
                                File.Delete(LogoPath1);

                            }
                            //upload the photo into the server            
                            logobrowse.SaveAs(LogoPath1);

                            //compressImage(LogoPath1);
                            //ImgPhoto.ImageUrl = LogoPath1;



                            ViewState["imagepath"] = LogoName;
                            //LabelMessage.CssClass = "successmsg";
                            //LabelMessage.Text = "";

                            //Fixed the Size of the Image
                            int fixWidth = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["FixLogoWidth"]);
                            int fixHeight = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["FixLogoHeight"]);

                            //if ((ImgHeight >= fixHeight) && (Imgwidth >= fixWidth))
                            //    compressImage(LogoPath1, fixWidth, fixHeight);

                            ImgPhoto.ImageUrl = "";
                            ImgPhoto.ImageUrl = System.Configuration.ConfigurationManager.AppSettings["LogoUrl"].ToString() + LogoName.ToString().Trim();
                            logobrowse.Visible = false;
                            btnUploadPhoto.Visible = false;
                            btnUploadCancel.Visible = true;


                        }
                        else
                        {
                            Response.Write("<script>alert('Dimension of the photo should be within (min)(" + MinLogoWidth + " * " + MinLogoHeight + ") and (max)(" + MaxLogoWidth + " * " + MaxLogoHeight + ")')</script>");
                            return;

                        }
                    }
                    else
                    {


                        Response.Write("<script>alert('Please Upload photo less than 3 MB')</script>");
                        //messageflag = false;
                        //LabelMessage.CssClass = "errormsg";
                        //LabelMessage.Text = "Please Upload photo within 250kb";
                        return;

                    }

                }
                else
                {
                    //message
                    Response.Write("<script>alert('Invalid extension of the photo,Please check the extension of photo(.jpg,.jpeg,.gif)!!')</script>");

                    //LabelMessage.CssClass = "errormsg";
                    //LabelMessage.Text = "Invalid extension of the photo,Please check the extension of photo(.jpg,.jpeg,.gif)!!";
                    return;

                }

            }
            else
            {
                if (ImgPhoto.ImageUrl != "")
                {
                    string[] LogofileName = ImgPhoto.ImageUrl.Split('\\');
                    if (LogofileName.Length <= 1) { LogofileName = ImgPhoto.ImageUrl.Split('/'); }
                    Response.Write("<script>alert('Please Select a photo')</script>");
                    //ObjBalPhoto.Photo = LogofileName[LogofileName.Length - 1].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Please Select a photo')</script>");
                    //ObjBalPhoto.Photo = string.Empty;
                    //LabelMessage.CssClass = "errormsg";
                    //LabelMessage.Text = "Please upload photo";
                    return;

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


    #region Compress Original Image

    public void compressImage(string path, int width, int height)
    {


        //create a image object containing a verticel photograph
        System.Drawing.Image imgPhotoVert = System.Drawing.Image.FromFile(path);
        System.Drawing.Image imgPhoto = null;

        imgPhoto = FixedSize(imgPhotoVert, width, height);
        imgPhotoVert.Dispose();
        File.Delete(path);
        imgPhoto.Save(path);

        imgPhoto.Dispose();

    }

    #endregion

    #region Dwaw Image
    [STAThread]
    static System.Drawing.Image FixedSize(System.Drawing.Image imgPhoto, int Width, int Height)
    {
        int sourceWidth = imgPhoto.Width;
        int sourceHeight = imgPhoto.Height;
        int sourceX = 0;
        int sourceY = 0;
        int destX = 0;
        int destY = 0;
        float nPercent = 0;
        float nPercentW = 0;
        float nPercentH = 0;

        nPercentW = ((float)Width / (float)sourceWidth);
        nPercentH = ((float)Height / (float)sourceHeight);

        //if we have to pad the height pad both the top and the bottom
        //with the difference between the scaled height and the desired height
        if (nPercentH < nPercentW)
        {
            nPercent = nPercentH;
            destX = (int)((Width - (sourceWidth * nPercent)) / 2);
        }
        else
        {
            nPercent = nPercentW;
            destY = (int)((Height - (sourceHeight * nPercent)) / 2);
        }

        int destWidth = (int)(sourceWidth * nPercent);
        int destHeight = 230;// (int)(sourceHeight * nPercent);

        Bitmap bmPhoto = new Bitmap(Width, Height, PixelFormat.Format24bppRgb);
        bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);

        Graphics grPhoto = Graphics.FromImage(bmPhoto);
        grPhoto.Clear(Color.Gray);
        grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;

        grPhoto.DrawImage(imgPhoto,
            new Rectangle(destX, 0, destWidth, destHeight),
            new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
            GraphicsUnit.Pixel);

        grPhoto.Dispose();
        return bmPhoto;
    }

    #endregion

    protected void btnUploadCancel_Click(object sender, EventArgs e)
    {
        ImgPhoto.ImageUrl = "~/Images/Logo/default_logo.gif";
        //ImgPhoto.ImageUrl = null;
        logobrowse.Visible = true;
        btnUploadPhoto.Visible = true;
        btnUploadCancel.Visible = false;
        ViewState["imagepath"] = null;

    }
    protected void btnCheckSheet_Click(object sender, EventArgs e)
    {

        Response.Redirect("frmCheckSheetReports.aspx?no=" + AppID + "&fno=" + FRNno + "");
        
    }

    protected void txtcompname_TextChanged(object sender, EventArgs e)
    {
        ObjGenBal = new BaseLayer.General_function();
        string queryforcomp = "";
        if (AppID.Substring(0, 2) == "AO" || AppID.Substring(0, 2) == "AB" || AppID.Substring(0, 2) == "CR")
        {
            queryforcomp = "Select regno from compmaster where company = '" + txtcompname.Text.ToString() + "'";
        }
        else
        {
            queryforcomp = "Select regno from CompMasterForARCR where company = '" + txtcompname.Text.ToString() + "'";
        }
        DataTable dtcomp = new DataTable();
        try
        {
            dtcomp = ObjGenBal.FetchData(queryforcomp);
            if (dtcomp.Rows.Count > 0)
            {
                txtcompid.Text = dtcomp.Rows[0]["regno"].ToString().Trim();
                txtcompname.BorderColor = System.Drawing.Color.Black;
            }
            else
            {
                // txtcompname.Text = "";
                txtcompid.Text = "";
                txtcompname.BorderColor = System.Drawing.Color.Red;
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
            dtcomp = null;
            ObjGenBal = null;
        }
    }
    protected void txt_dpndt_TextChanged(object sender, EventArgs e)
    {
        ObjGenBal = new BaseLayer.General_function();
        string queryforcomp = "select (forename+' ' + surname) as Name, people_id from People where Cerpac_No = '" + txt_dpndt.Text.ToString() + "'";
        DataTable dt_details = new DataTable();
        try
        {
            dt_details = ObjGenBal.FetchData(queryforcomp);
            if (dt_details.Rows.Count > 0)
            {
                txt_depnt_peopleid.Text = dt_details.Rows[0]["people_id"].ToString().Trim();
                txt_dpndt.BorderColor = System.Drawing.Color.Black;
                lbl_dept_name.Visible = true;
                txt_dept_name.Visible = true;

                txt_dept_name.Text = dt_details.Rows[0]["Name"].ToString().Trim();
            }
            else
            {
                // txtcompname.Text = "";
                txt_depnt_peopleid.Text = "";
                txt_dpndt.BorderColor = System.Drawing.Color.Red;
                lbl_dept_name.Visible = false;
                txt_dept_name.Visible = false;
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
            dt_details = null;
            ObjGenBal = null;
        }
    }
    protected void drprltn_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtdesig.Text = drprltn.SelectedItem.Text;
    }
}