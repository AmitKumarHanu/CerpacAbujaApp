using System.Data;
using System;

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

using System.Collections.Generic;
using DataAccessLayer;
using System.Globalization;
using System.Text;
using System.Net;
using System.Windows;
using SHDocVw;
using System.Drawing.Drawing2D;
using System.Threading;

public partial class Admin_frmApplicationDetailsUpdate : System.Web.UI.Page
{

    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
   
    BaseLayer.General_function ObjGenBal = null;
    BusinessEntityLayer.BalDocdetails ObjBalDocdetails = null;
    string AppID = "";
    string FRNno = "";
    //string drpdwn = "";
    string LogoPath1 = "";
    string UserID = null;
    int Length = 0;
    Label LabelMessage = null;
    byte[] Content;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];

       Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");

        if (objectSessionHolderPersistingData == null)
        {
            Response.Redirect("../Login.aspx");
        }
        //---------------------------Session for company id and company name-----------------
        if (Session["company_id"] != null)
        {
            if (Session["company_id"].ToString() != "")
            {

                txtcompid.Text = Session["company_id"].ToString();
                Session["company_id"] = "";
            }
        }

        if (Session["company_name"] != null)
        {
            if (Session["company_name"].ToString() != "")
            {
                txtcompname.Text = Session["company_name"].ToString();
                txtcompname.ToolTip = "";
                txtcompname.ToolTip = txtcompname.Text;
                Session["company_name"] = "";
            }
        }
      
        //----------------------Display Zone name------------------------
        UserID = objectSessionHolderPersistingData.User_ID.ToString();
        LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
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
            objGenBal = new BaseLayer.General_function();
            //Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            string err = ObjGenBal.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.CssClass = "warning-box";
            LabelMessage.Visible = true;
        }


        if (!IsPostBack)
        {
            //-----------Calendar Validation------------------------------
            ViewState["imagepath"] = "";
          //  A1.HRef = "javascript:NewCal('" + TxtDateOfIssue.ClientID + "','DDMMMYYYY','','',10,1)";
          //  doe.HRef = "javascript:NewCal('" + txtdoe.ClientID + "','DDMMMYYYY','','',1,10)";
            A2.HRef = "javascript:NewCal('" + TxtIssueDate.ClientID + "','DDMMMYYYY','','',5,5)";
            // A2.HRef = "javascript:NewCal('" + TxtIssueDate.ClientID + "','DDMMMYYYY','','',1,1)";

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

            //--------------Call BindDropDownlist--------------------
            binddrpdwn();

        }
        //------------------Niger Wife-----------------------------
        if (txtcompname.Text.ToUpper() == "NIGER WIFE" || txtdesig.Text.ToUpper() == "NIGER WIFE")
        {
            A3.HRef = "javascript:NewCal('" + TxtExpDate.ClientID + "','DDMMMYYYY','','',11,11)";
        }
        else
        {
            A3.HRef = "javascript:NewCal('" + TxtExpDate.ClientID + "','DDMMMYYYY','','',5,5)";
        } 
         //------------Write company details in XML file----------------   
        xmlretcomp();
    }


    public void xmlretcomp()
    {
        try
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
        catch (Exception ex)
        {
            ObjGenBal = new BaseLayer.General_function();
            string err = ObjGenBal.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
           // LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
           // LabelMessage.CssClass = "warning-box";
           // LabelMessage.Visible = true;
        }
        finally
        {
            ObjGenBal = null;
        }
    }


    protected void binddrpdwn()
    {
        Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
        ObjGenBal = new BaseLayer.General_function();
        string Message = "";
        try
        {
        ObjGenBal = new BaseLayer.General_function();
        string query = "select distinct(forename +''+ surname+'----'+cerpac_no) as Name,people_id from People";
        ObjGenBal.Fill_DDL(drpdpndt, query, "Name", "people_id");

        string query2 = "Select * from DesignationMaster";
        ObjGenBal.Fill_DDL(drprltn, query2, "Designation", "DesignationCode");

        string queryfortitle = "Select * from TitleMaster";
        ObjGenBal.Fill_DDL(drptitle, queryfortitle, "Title", "TitleCode");

        string queryfornationality = "Select * from NationalityMaster";
        ObjGenBal.Fill_DDL(TxtNationality, queryfornationality, "adjective", "adjective");
         }
         
        catch (Exception ex)
        {
            ObjGenBal = new BaseLayer.General_function();
            //Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            string err = ObjGenBal.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.CssClass = "warning-box";
            LabelMessage.Visible = true;
        }
        finally
        {
            ObjBalDocdetails = null;

        }
    }

    protected string FormatImageUrl(string image)
    {

        if (image != null && image.Length > 0)
        {
            string strimage = "http://46.38.169.33/Images/Logo/" + image;
            return strimage;

        }

        else

            return null;

    }

    private void GetData(string ApplicationId)
    {
          Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
        ObjGenBal = new BaseLayer.General_function();
        string Message = "";
        try
        {
            //----------------------------------------------------------------- data from db------------------------------------------------------

            Session["CerpaxNo"] = AppID.ToString().Trim();
            //----------Data Table --------------------
            DataTable DtSer = null; DtSer = new DataTable();
            DataTable dtcomp = null; dtcomp = new DataTable();

            //---------------Find Cerpac File No. by People table-------------
            //string queryforcerpac = "select * from People where cerpac_file_no='" + ApplicationId.ToString() + "'";
            string queryforcerpac = "select * from Peoplechild where formno='" + ApplicationId.ToString() + "'";
            DtSer = ObjGenBal.FetchData(queryforcerpac);
            if (DtSer.Rows.Count > 0)
            {
                /******************* Fetch If Dependent *******************************/
                DataTable Dt = null; Dt = new DataTable();

                //string queryfordependent = "select * from Peoplechild where formno='" + ApplicationId.ToString() + "' and cerpacno=(select cerpac_no from people where cerpac_file_no='" + ApplicationId.ToString().Trim() + "') and IsDependent=1";

                string queryfordependent = "select * from Peoplechild b, people a where a.cerpac_no=b.cerpacno and  b.formno='" + ApplicationId.ToString() + "'";
                Dt = ObjGenBal.FetchData(queryfordependent);

                if (Dt.Rows.Count == 1)
                {


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

                            if (File.Exists(Server.MapPath("~") + "/Images/Logo/" + Dt.Rows[0]["picture"].ToString().Trim()))
                                File.Delete(Server.MapPath("~") + "/Images/Logo/" + Dt.Rows[0]["picture"].ToString().Trim());

                            if (!File.Exists(Server.MapPath("~") + "/Images/Logo/" + Dt.Rows[0]["picture"].ToString().Trim()))
                                newImage.Save(Server.MapPath("~") + "/Images/Logo/" + Dt.Rows[0]["picture"].ToString().Trim());
                            // newImage.Save("g:/Saurabh" + Dt.Rows[0]["picture"].ToString().Trim());

                        }
                    }

                    ViewState["imagepath"] = Dt.Rows[0]["picture"].ToString().Trim();
                    ImgPhoto.ImageUrl = "~/Images/Logo/" + Dt.Rows[0]["picture"].ToString().Trim();


                    //-----------------Personal Details------------------------
                    drptitle.SelectedValue = Dt.Rows[0]["title"].ToString().Trim();
                    TxtFirstName.Text = Dt.Rows[0]["forename"].ToString().Replace('`',' ').Trim().Replace('.',' ');
                    TxtMiddleName.Text = Dt.Rows[0]["middle_name"].ToString().Replace('`', ' ').Trim().Replace('.', ' ');
                    TxtLastName.Text = Dt.Rows[0]["surname"].ToString().Replace('`', ' ').Trim().Replace('.', ' ');
                    radsex.SelectedValue = Dt.Rows[0]["sex"].ToString().Trim();
                    TxtNationality.Text = Dt.Rows[0]["nationality"].ToString().Trim();
                    txtpob.Text = Dt.Rows[0]["place_of_birth"].ToString().Trim();
                    TxtDob.Text = string.Format("{0:d-MM-yyyy}", Dt.Rows[0]["date_of_birth"]).ToString().Trim();
                    txtemailprsn.Text = Dt.Rows[0][11].ToString().Trim();
                    txtcntcnoprsn.Text = Dt.Rows[0][10].ToString().Trim();

                    //----------------Passport Details---------------------------
                    TxtPassportNo.Text = Dt.Rows[0]["passport_no"].ToString().Trim();
                    TxtPassportType.Text = Dt.Rows[0]["passport_issue_by"].ToString().Trim();
                    TxtPlaceOfIssue.Text = Dt.Rows[0]["passport_issue_loc"].ToString().Trim();
                    //TxtDateOfIssue.Text = string.Format("{0:d-MM-yyyy}", Dt.Rows[0]["passport_issue_date"]).ToString().Trim();
                    //txtdoe.Text = string.Format("{0:d-MM-yyyy}", Dt.Rows[0]["passport_expiry_date"]).ToString().Trim();

                    //----------------Cerpac Details---------------------------
                    TxtCerpacNo.Text = Dt.Rows[0]["cerpac_no"].ToString().Trim();
                    //FRNno = Dt.Rows[0]["cerpac_file_no"].ToString().Trim();
                    txtfileno.Text = Dt.Rows[0]["Formno"].ToString().Trim();
                    if (Dt.Rows[0]["cerpac_receipt_date"].ToString().Trim() != null || Dt.Rows[0]["cerpac_receipt_date"].ToString().Trim() != "")
                    {
                        TxtIssueDate.Text = string.Format("{0:d-MM-yyyy}", Dt.Rows[0]["cerpac_receipt_date"]).ToString().Trim();
                        TxtExpDate.Text = string.Format("{0:d-MM-yyyy}", Dt.Rows[0]["cerpac_expiry_date"]).ToString().Trim();
                    }
                    else
                    {
                        TxtIssueDate.Text = "-----";
                        TxtExpDate.Text = "-----";
                    }
                    txtphyfileno.Text = Dt.Rows[0]["file_no"].ToString().Trim();


                    //----------------Company Details---------------------------
                    string queryforcomp = "";
                    queryforcomp = "Select top 1 regno,company from compmaster where regno = '" + Dt.Rows[0]["company"].ToString().Trim() + "'";
                    ObjGenBal = new BaseLayer.General_function();
                    dtcomp = ObjGenBal.FetchData(queryforcomp);
                    if (dtcomp.Rows.Count > 0)
                    {
                        txtcompname.Text = dtcomp.Rows[0]["company"].ToString().Trim();
                        txtcompname.ToolTip = dtcomp.Rows[0]["company"].ToString().Trim();
                        txtcompid.Text = dtcomp.Rows[0]["regno"].ToString().Trim();

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
                    txtdtemploymnt.Text = string.Format("{0:d-MM-yyyy}", Dt.Rows[0]["employment_date"]).ToString().Trim();


                    //TxtFirstNamedb.Text = Dt.Rows[0]["forename"].ToString().Trim(); ;
                    //TxtLastNamedb.Text = Dt.Rows[0]["surname"].ToString().Trim();
                    //TxtNationalitydb.Text = Dt.Rows[0]["nationality"].ToString().Trim();

                    //---------------------------------------------Address Details---------------------------------------------
                    txtaddrnigeria1.Text = Dt.Rows[0]["nigeria_add_1"].ToString().Trim();
                    txtaddrnigeria2.Text = Dt.Rows[0]["nigeria_add_2"].ToString().Trim();
                    txtaddrabroad1.Text = Dt.Rows[0]["abroad_add_1"].ToString().Trim();
                    txtaddrabroad2.Text = Dt.Rows[0]["abroad_add_2"].ToString().Trim();
                    //------------------ Notice-----------------------------
                    txtnotes.Text = Dt.Rows[0]["zonenote"].ToString().Trim();

                    //------------------------Dependent Case--------------------------

                    // radtype.SelectedValue = "1";
                    // radtype_SelectedIndexChange(new object(), new EventArgs());

                    string isDepFlag = Dt.Rows[0]["isdependent"].ToString().Trim();

                    if (isDepFlag == "1")
                    {
                        txt_depnt_peopleid.Text = Dt.Rows[0]["dependenton"].ToString().Trim();

                        drprltn.SelectedIndex = drprltn.Items.IndexOf(drprltn.Items.FindByValue(Dt.Rows[0]["designationcode"].ToString().Trim()));


                        DataTable dt_fetch_dept_detail = null; dt_fetch_dept_detail = new DataTable();

                        string queryforcerpac_detail_dept = "select * from People where people_id='" + txt_depnt_peopleid.Text + "'";
                        dt_fetch_dept_detail = ObjGenBal.FetchData(queryforcerpac_detail_dept);

                        if (dt_fetch_dept_detail.Rows.Count > 0)
                        {
                            txt_dpndt.Text = dt_fetch_dept_detail.Rows[0]["cerpac_no"].ToString().Trim();
                            txt_dpndt_TextChanged(new object(), new EventArgs());
                        }

                    }
                    else if (isDepFlag == "0" || isDepFlag == "NULL" || isDepFlag == "")
                    {
                        radtype.SelectedIndex = 0;

                        lbldeprel.Visible = false;
                        lbldpndty.Visible = false;
                        lblpsnty.Visible = true;
                        lbl_dept_name.Visible = false;

                        drprltn.Visible = false;
                        txt_dept_name.Visible = false;
                        txt_dpndt.Visible = false;

                        // txtdesig.Enabled = false;


                        txt_dpndt.Text = "";
                        txt_dept_name.Text = "";


                    }


                    //------------------------------------------------end--------------------------------------------------
                }
            }
            else
            {
                // detailtable.Style.Add("display", "none");
                // warn.Style.Add("display", "");

                ScriptManager.RegisterStartupScript(this, GetType(), "key", "alert(\"Form No. Not Exist.\");", true);

            }
        } 
         
        catch (Exception ex)
        {
            ObjGenBal = new BaseLayer.General_function();
            //Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            string err = ObjGenBal.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.CssClass = "warning-box";
            LabelMessage.Visible = true;
        }
        finally
        {
            ObjBalDocdetails = null;

        }
        //---------------------------------------------------------end----------------------------------------------------------------------
        //----------------------------------------------------------for generating documents-------------------------------------
        //if (Dt.Rows.Count > 0)
        //{
        //   // string cerpactype = Dt.Rows[0]["cerpac_file_no"].ToString().Trim().Substring(0, 2);

        //   // getdocuments(cerpactype);
        //}
        //------------------------------------------------------------------end--------------------------------------------------
        //----------------------------------------------------data from bank--------------------------------------------
        //DataTable dtbnk = new DataTable();
        //string queryforbank = "select * from Uploaded_Excel_Data where FORMNO='" + FRNno.ToString().Trim() + "'";
        //dtbnk = ObjGenBal.FetchData(queryforbank);
        //if (dtbnk.Rows.Count > 0)
        //{

            //txtfnamebank.Text = dtbnk.Rows[0]["FirstName"].ToString().Trim();
            //TxtLastNamebank.Text = dtbnk.Rows[0]["LastName"].ToString().Trim();
            //TxtNationalitybank.Text = dtbnk.Rows[0]["NATIONALITY"].ToString().Trim();
        //}
        //---------------------------------------------------- end -----------------------------------------------------
        //===================================================MRZ Data Fetch====================================================================
        //DataTable dtmrz = new DataTable();
        //string querymrz = "select * from MRZData where CerpacNo='" + TxtCerpacNo.Text.ToString().Trim() + "'";
        //dtmrz = ObjGenBal.FetchData(querymrz);
        //if (dtmrz.Rows.Count > 0)
        //{
        //    //TxtFirstNamemrz.Text = dtmrz.Rows[0]["MrzFirstName"].ToString().Trim();
        //    //TxtLastNamemrz.Text = dtmrz.Rows[0]["MrzLastName"].ToString().Trim();
        //    //TxtNationalitymrz.Text = dtmrz.Rows[0]["Nationality"].ToString().Trim();
        //}

        //=====================================================end=============================================================================

        ////--------------------------------------fetching company name from comp master-------------------------------
        //string queryforcomp1 = "";
        //if (AppID.Substring(0, 2) == "AO")
        //{
        //    queryforcomp1 = "Select * from compmaster where regno= '" + txtcompid.Text.ToString() + "'";
        //}
        //else
        //{
        //    queryforcomp1 = "Select * from CompMasterForARCR where regno = '" + txtcompid.Text.ToString() + "'";
        //}
        //dtcomp = ObjGenBal.FetchData(queryforcomp1);
        //if (dtcomp.Rows.Count > 0)
        //{
        //    txtcompname.Text = dtcomp.Rows[0]["company"].ToString().Trim();
        //    txtcompname.ToolTip = dtcomp.Rows[0]["company"].ToString().Trim();
        //}
        //else
        //{
        //    txtcompid.Text = "";
        //    txtcompname.Text = "";
        //    txtcompname.ToolTip = "";
        //}
        //-----------------------------------------------------------------end----------------------------------------
            
    }

    protected void txt_dpndt_TextChanged(object sender, EventArgs e)
    {
        Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
        ObjGenBal = new BaseLayer.General_function();
        string Message = "";
        try
        {        
             string queryforcomp = "select (forename+' ' + surname) as Name, people_id from People where Cerpac_No = '" + txt_dpndt.Text.ToString() + "'";
             DataTable dt_details = new DataTable();
       
            dt_details = ObjGenBal.FetchData(queryforcomp);
            if (dt_details.Rows.Count > 0)
            {
                txt_depnt_peopleid.Text = dt_details.Rows[0]["people_id"].ToString().Trim();
                txt_dpndt.BorderColor = System.Drawing.Color.Black;

                txt_dept_name.Text = dt_details.Rows[0]["Name"].ToString().Trim();
                radtype.SelectedIndex = 1;
                lbldeprel.Visible = true;
                lbldpndty.Visible = true;
                lblpsnty.Visible = true;
                lbl_dept_name.Visible = true;

                drprltn.Visible = true;
                txt_dept_name.Visible = true;
                txt_dpndt.Visible = true;
            }
            else
            {

                lbldeprel.Visible = true;
                lbldpndty.Visible = true;
                lblpsnty.Visible = true;
                lbl_dept_name.Visible = false;

                drprltn.Visible = true;
                txt_dept_name.Visible = false;
                txt_dpndt.Visible = true;

                // txtdesig.Enabled = false;

                drprltn.SelectedIndex = -1;
                txt_dpndt.Text = "";
                txt_dept_name.Text = "";

                ScriptManager.RegisterStartupScript(this, GetType(), "key", "alert(\"Cerpac No. Not Exist.\");", true);

            }
        }
        catch (Exception ex)
        {
            ObjGenBal = new BaseLayer.General_function();
            //Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            string err = ObjGenBal.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.CssClass = "warning-box";
            LabelMessage.Visible = true;
        }
        finally
        {
            ObjBalDocdetails = null;

        }
    }

    protected void drprltn_SelectedIndexChanged(object sender, EventArgs e)
    {
       // txtdesig.Text = drprltn.SelectedItem.Text;
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

    protected void Go_Click(object sender, EventArgs e)
    {
          Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
        ObjGenBal = new BaseLayer.General_function();
        string Message = "";
        try
        {
            if (TextAppId.Text == "")
            {
                Response.Write("<script>alert('Please Fill Form no.');</script>");
                return;
            }
            else
            {
                TxtCerpacNo.Text = TextAppId.Text;
                AppID = TextAppId.Text;
               GetData(TextAppId.Text);
            }
        }
         
        catch (Exception ex)
        {
            ObjGenBal = new BaseLayer.General_function();
            //Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            string err = ObjGenBal.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.CssClass = "warning-box";
            LabelMessage.Visible = true;
        }
        finally
        {
            ObjBalDocdetails = null;

        }
    }
    protected void btnUploadPhoto_Click(object sender, EventArgs e)
    {
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        ObjGenBal = new BaseLayer.General_function();

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
            //LabelMessage.CssClass = "errormsg";
           // LabelMessage.Text = "Please enter passport number and nationality before browsing and uploading photo";
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
                //ObjBalPhoto.Photo = LogofileName[LogofileName.Length - 1].ToString();
            }
            else
            {
                Response.Write("<script>alert('Please upload photo')</script>");
                //ObjBalPhoto.Photo = string.Empty;
                //LabelMessage.CssClass = "errormsg";
                //LabelMessage.Text = "Please upload photo";
                return;

            }
        }


    }

    #region Compress Original Image

    public void compressImage(string path, int width, int height)
    {
        Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
        ObjGenBal = new BaseLayer.General_function();
        string Message = "";
        try
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
        catch (Exception ex)
        {
            ObjGenBal = new BaseLayer.General_function();
            //Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            string err = ObjGenBal.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.CssClass = "warning-box";
            LabelMessage.Visible = true;
        }
        finally
        {
            ObjBalDocdetails = null;

        }

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
          Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
        ObjGenBal = new BaseLayer.General_function();
        string Message = "";
        try
        {

        ImgPhoto.ImageUrl = "~/Images/Logo/default_logo.gif";
        //ImgPhoto.ImageUrl = null;
        logobrowse.Visible = true;
        btnUploadPhoto.Visible = true;
        btnUploadCancel.Visible = false;
        ViewState["imagepath"] = null;
        }
        catch (Exception ex)
        {
            ObjGenBal = new BaseLayer.General_function();
            //Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            string err = ObjGenBal.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.CssClass = "warning-box";
            LabelMessage.Visible = true;
        }
        finally
        {
            ObjBalDocdetails = null;

        }
    }
    protected void radtype_SelectedIndexChange(object sender, EventArgs e)
    {
         Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
        ObjGenBal = new BaseLayer.General_function();
        string Message = "";
        try
        {
        if (radtype.SelectedValue == "1")
        {

            lbldeprel.Visible = true;
            lbldpndty.Visible = true;
            lblpsnty.Visible = true;
            lbl_dept_name.Visible = false;
            
            drprltn.Visible = true;
            txt_dept_name.Visible = false;
            txt_dpndt.Visible = true;
           
           // txtdesig.Enabled = false;

            drprltn.SelectedIndex = -1;
            txt_dpndt.Text = "";
            txt_dept_name.Text = "";
          
        }
        else
        {
            lbldeprel.Visible = false;
            lbldpndty.Visible = false;
            lblpsnty.Visible = true;
            lbl_dept_name.Visible = false;

            drprltn.Visible = false;
            txt_dept_name.Visible = false;
            txt_dpndt.Visible = false;

            // txtdesig.Enabled = false;


            txt_dpndt.Text = "";
            txt_dept_name.Text = "";

        }
        }
        catch (Exception ex)
        {
            ObjGenBal = new BaseLayer.General_function();
            //Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            string err = ObjGenBal.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.CssClass = "warning-box";
            LabelMessage.Visible = true;
        }
        finally
        {
            ObjBalDocdetails = null;

        }

    }
    //public void FetchandInsert(string appid)
    //{
    //    DataTable Dt = null;
    //    Dt = new DataTable();

    //    ObjGenBal = new BaseLayer.General_function();
    //    string queryforcerpac = "select * from People where cerpac_no='" + appid.ToString() + "'";
    //    Dt = ObjGenBal.FetchData(queryforcerpac);

    //    SqlParameter[] pram = null;
    //    pram = new SqlParameter[16];
    //    pram[0] = new SqlParameter("@companyid", Dt.Rows[0]["company"].ToString().Trim());
    //    pram[1] = new SqlParameter("@compadd1", Dt.Rows[0]["company_add_1"].ToString().Trim());
    //    pram[2] = new SqlParameter("@compadd2", Dt.Rows[0]["company_add_2"].ToString().Trim());
    //    pram[3] = new SqlParameter("@CerpacNo", TxtCerpacNo.Text.ToString().Trim());
    //    pram[4] = new SqlParameter("@designation", Dt.Rows[0]["designation"].ToString().Trim());
    //    pram[5] = new SqlParameter("@comptelno", Dt.Rows[0]["company_tel_no"].ToString().Trim());
    //    pram[6] = new SqlParameter("@faxno", Dt.Rows[0]["company_fax_no"].ToString().Trim());
    //    pram[7] = new SqlParameter("@addnigeria1", Dt.Rows[0]["nigeria_add_1"].ToString().Trim());
    //    pram[8] = new SqlParameter("@addnigeria2", Dt.Rows[0]["nigeria_add_2"].ToString().Trim());
    //    pram[9] = new SqlParameter("@addabroad1", Dt.Rows[0]["abroad_add_1"].ToString().Trim());
    //    pram[10] = new SqlParameter("@addabroad2", Dt.Rows[0]["abroad_add_2"].ToString().Trim());
    //    pram[11] = new SqlParameter("@cerpacissuedate", string.Format("{0:d-MM-yyyy}", Dt.Rows[0]["cerpac_receipt_date"]).ToString().Trim());
    //    pram[12] = new SqlParameter("@cerpacexpdate", string.Format("{0:d-MM-yyyy}", Dt.Rows[0]["cerpac_expiry_date"]).ToString().Trim());

    //    pram[13] = new SqlParameter("@UserId", objectSessionHolderPersistingData.User_ID);
    //    pram[14] = new SqlParameter("@SuccessId", 1);

    //    //------------------------------------new fields---------------------------------------

    //    //-------------------------------------- end------------------------------------------------------
    //    //pram[4] = new SqlParameter("@cerpac_file_no", txtfileno.Text.ToString());
    //    SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_CERPAC_FETCHANDINSERT", pram);
    //}
    protected void btnverify_Click(object sender, EventArgs e)
    {
        Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
        ObjGenBal = new BaseLayer.General_function();
        string Message = "";
        try
        {
            if (TxtCerpacNo.Text == "")
            {
                Response.Write("<script>alert('Please Fill Any Form No. For Search First !!')</script>");
                return;
            }



            // FetchandInsert(TxtCerpacNo.Text.ToString());
            CultureInfo c = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = c.TextInfo;



            //---------------------------------------------------- for checking the expiry date of the cerpac form ------------------------------------------------- 
            DateTime d1 = Convert.ToDateTime(ConvertDate(TxtIssueDate.Text.ToString(), "d-MM-yyyy"));
            DateTime d2 = Convert.ToDateTime(ConvertDate(TxtExpDate.Text.ToString(), "d-MM-yyyy"));
            string d3 = (d2 - d1).TotalDays.ToString();
            // Response.Write("<script>alert('" + d3.ToString() + "')</script>");
            if ((TxtCerpacNo.Text.ToString().ToUpper().Substring(0, 2) == "AO" || TxtCerpacNo.Text.ToString().ToUpper().Substring(0, 2) == "CR") && int.Parse(d3) > 365)
            {
                Response.Write("<script>alert('Cerpac Expiry Date should be less than or equal to one year from issue date')</script>");
                return;
            }
            //  if (TxtCerpacNo.Text.ToString().ToUpper().Substring(0, 2) == "AR" && int.Parse(d3) > 1464)
            if ((TxtCerpacNo.Text.ToString().ToUpper().Substring(0, 2) == "AR" && int.Parse(d3) > 1465) && (txtcompname.Text.ToUpper() != "NIGER WIFE" && txtdesig.Text.ToUpper() != "NIGER WIFE"))
            {
                Response.Write("<script>alert('Cerpac Expiry Date for AR category should be less than or equal to four years from issue date')</script>");
                return;
            }

            //----------------------------------------------------------------- end---------------------------------------------------------- 

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
            if (TxtCerpacNo.Text != "")
            {
                int statusid = UpdatePeople();
                if (statusid == 1)
                {
                    UpdateImage();
                    LabelMessage.Text = "Updated Sucessfully";
                    LabelMessage.CssClass = "confirmation-box";
                }
                if (radtype.SelectedIndex == 1)
                {

                    int StatusDep = UpdateDependent();
                    if (StatusDep == 1 &&  statusid ==1 )
                    {
                        LabelMessage.Text = "Cerpac Details and Dependant Details boht are Sucessfully update!!";
                        LabelMessage.CssClass = "confirmation-box";
                    }
                }
                
                   
            }

           
           // //================================================for inserting documents=============================================
           // //foreach (ListItem li in chkbdoc.Items)
           // //{
           // //    if (li.Selected == true)
           // //    {
           // //        ObjbalApporvalL1.docode = li.Value.ToString();
           // //        ObjbalApporvalL1.cerpacno = TxtCerpacNo.Text.ToString();
           // //        int statusdoc = ObjbalApporvalL1.InsertDoc();
           // //    }
           // //}
           // //================================================end=================================================================

           // int status = ObjbalApporvalL1.UpdateCerpacApplicantData();
            //=================================== for inserting dependent================================================
            
            
              
            
            //if (status == 1)
            //{
            //    confirm.Style.Add("display", "");
            //    confirm.Attributes.Add("class", "confirmation-box animated-table bounceIn");
            //    detailtable.Style.Add("display", "none");
            //    gridtable.Style.Add("display", "none");
            //    imgbak.Style.Add("display", "none");
            //    btnUploadCancel.Visible = false;

            //    tr_cerpac.Style.Add("display", "none");


            //}
        }
        catch (Exception ex)
        {
            ObjGenBal = new BaseLayer.General_function();
            //Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            string err = ObjGenBal.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.CssClass = "warning-box";
            LabelMessage.Visible = true;
        }
        finally
        {
            ObjBalDocdetails = null;

        }
    }

    public void  UpdateImage()
    {
       

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

    }

    public int UpdatePeople()
    {
        SqlParameter[] pram = new SqlParameter[34];
        try
        {
            pram[0] = new SqlParameter("@UserId", UserID);
            pram[1] = new SqlParameter("@title", drptitle.SelectedValue.ToString());
            pram[2] = new SqlParameter("@fname", TxtFirstName.Text.Trim());
            pram[3] = new SqlParameter("@mname", TxtMiddleName.Text.Trim());
            pram[4] = new SqlParameter("@lname", TxtLastName.Text.Trim());
            pram[5] = new SqlParameter("@nationality", TxtNationality.SelectedValue.ToString());
            pram[6] = new SqlParameter("@sex", radsex.SelectedIndex);
            pram[7] = new SqlParameter("@emailprsn", txtemailprsn.Text.ToString().Trim());
            pram[8] = new SqlParameter("@contactprsn", txtcntcnoprsn.Text.ToString().Trim());
            pram[9] = new SqlParameter("@DOB", ConvertDate(TxtDob.Text.ToString().Trim() , "d-MM-yyyy"));
            pram[10] = new SqlParameter("@POB", txtpob.Text.ToString().Trim());

            pram[11] = new SqlParameter("@passportno", TxtPassportNo.Text.ToString().Trim());
            pram[12] = new SqlParameter("@passportissueby", TxtPassportType.Text.ToString().Trim());
            pram[13] = new SqlParameter("@Placeofissue", TxtPlaceOfIssue.Text.ToString().Trim());
            pram[14] = new SqlParameter("@CerpacNo", TxtCerpacNo.Text.ToString().Trim());
            pram[15] = new SqlParameter("@formno", txtfileno.Text.ToString().Trim());
            pram[16] = new SqlParameter("@issuedate", ConvertDate(TxtIssueDate.Text.ToString(), "d-MM-yyyy"));
            pram[17] = new SqlParameter("@expirydate", ConvertDate(TxtExpDate.Text.ToString(), "d-MM-yyyy"));
            pram[18] = new SqlParameter("@Phyfileno", txtphyfileno.Text.ToString().Trim());

            pram[19] = new SqlParameter("@compid", txtcompid.Text.ToString().Trim());
            pram[20] = new SqlParameter("@compname", txtcompname.Text.ToString().Trim());
            pram[21] = new SqlParameter("@compadd1", txtcompadd1.Text.ToString().Trim());
            pram[22] = new SqlParameter("@compadd2", txtcompadd2.Text.ToString().Trim());
            pram[23] = new SqlParameter("@designation", txtdesig.Text.ToString().Trim());
            pram[24] = new SqlParameter("@comptelno", txtphno.Text.ToString().Trim());
            pram[25] = new SqlParameter("@compfaxno", txtfaxno.Text.ToString().Trim());
            pram[26] = new SqlParameter("@Dateofemp", ConvertDate(txtdtemploymnt.Text.ToString(), "d-MM-yyyy"));

            pram[27] = new SqlParameter("@NigAdd1", txtaddrnigeria1.Text.ToString().Trim());
            pram[28] = new SqlParameter("@NigAdd2", txtaddrnigeria2.Text.ToString().Trim());
            pram[29] = new SqlParameter("@AbAdd1", txtaddrabroad1.Text.ToString().Trim());
            pram[30] = new SqlParameter("@AbAdd2", txtaddrabroad2.Text.ToString().Trim());
            pram[31] = new SqlParameter("@Notice", txtnotes.Text.ToString().Trim());

            //pram[29] = new SqlParameter("@@zonenote", txtnotes.ToString().Trim());

            //pram[30] = new SqlParameter("@ImagePath", ViewState["imagepath"].ToString());
            //-------------------------------------- end------------------------------------------------------
            //pram[4] = new SqlParameter("@cerpac_file_no", txtfileno.Text.ToString());
            //========================================end========================================
            pram[32] = new SqlParameter("@Opt", 1);
           
            pram[33] = new SqlParameter("@RT", 1);
            pram[33].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspCerpacUpdatePeople", pram);
          
            return int.Parse(pram[33].Value.ToString());
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

    public int UpdateDependent()
    {
        SqlParameter[] pram = new SqlParameter[7];
        try
        {
            
            pram[0] = new SqlParameter("@flagDep", radtype.SelectedIndex.ToString());
            pram[1] = new SqlParameter("@Cerpacno", TxtCerpacNo.Text.Trim());
            pram[2] = new SqlParameter("@Formno", txtfileno.Text.Trim());
            pram[3] = new SqlParameter("@App_Id", txt_depnt_peopleid.Text.Trim());
            pram[4] = new SqlParameter("@DepRel", drprltn.SelectedValue);
            pram[5] = new SqlParameter("@Opt", 2);
            pram[6] = new SqlParameter("@RT", 1);
            pram[6].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspCerpacUpdateDependant", pram);

            return int.Parse(pram[6].Value.ToString());
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


    protected void txtcompname_TextChanged(object sender, EventArgs e)
    {
        Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
        ObjGenBal = new BaseLayer.General_function();
        string Message = "";
        try
        {
      
            DataTable dtcomp = null; dtcomp = new DataTable();

            string queryforcomp = "";
            queryforcomp = "Select top 1 regno,company from compmaster where company = '" + txtcompname.ToString().Trim() + "'";
            ObjGenBal = new BaseLayer.General_function();
            dtcomp = ObjGenBal.FetchData(queryforcomp);
            if (dtcomp.Rows.Count > 0)
            {
                txtcompname.Text = dtcomp.Rows[0]["company"].ToString().Trim();
                txtcompname.ToolTip = dtcomp.Rows[0]["company"].ToString().Trim();
                txtcompid.Text = dtcomp.Rows[0]["regno"].ToString().Trim();

            }
            else
            {
                txtcompid.Text = "";
                txtcompname.Text = "";
            }
        }
        catch (Exception ex)
        {
            ObjGenBal = new BaseLayer.General_function();
            //Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            string err = ObjGenBal.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.CssClass = "warning-box";
            LabelMessage.Visible = true;
        }
        finally
        {
            ObjBalDocdetails = null;

        }
    }

    public BaseLayer.General_function objGenBal { get; set; }
}