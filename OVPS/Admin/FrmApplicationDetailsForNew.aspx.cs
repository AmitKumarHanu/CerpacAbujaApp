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
using System.Web.Services;
using System.Web.Script.Services;
using System.Net.NetworkInformation;

public partial class Admin_FrmApplicationDetailsForNew : System.Web.UI.Page
{
    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    BusinessEntityLayer.BalApprovalReviewL1 ObjbalApporvalL1 = null;
    protected BaseLayer.General_function ObjGenBal = null;
    string AppID = "";
    string FRNno = "";
    string LogoPath1 = "";
    //string drpdwn = "";
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
                txtcompname.ToolTip = txtcompname.Text.ToString();
                Session["company_name"] = "";
            }
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
                binddrpdwn();
                GetData(AppID);
                // GetComments(AppID);


                //DateTime startDate = Convert.ToDateTime(string.Format("{0:MM-d-yyyy}", (TxtIssueDate.Text)).ToString().Trim());
                //DateTime expiryDate = startDate.AddDays(30);


                A1.HRef = "javascript:NewCal('" + TxtDateOfIssue.ClientID + "','DDMMMYYYY','','',20,1)";
                doe.HRef = "javascript:NewCal('" + txtdoe.ClientID + "','DDMMMYYYY','','',11,14)";
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


    [ScriptMethod, WebMethod]

    public static string docall()
    {
        return "Hello";
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
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.CssClass = "warning-box";
            LabelMessage.Visible = true;
        }
        finally
        {
            ObjGenBal = null;
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
            if (ViewState["imagepath"] != null)
            {
                btnUploadCancel.Visible = true;
            }
            if (AppID.Substring(0, 2) == "AO" || AppID.Substring(0, 2) == "AB" || AppID.Substring(0, 2) == "CR")
            {
                lbl_comp_rc.Visible = true;
                txtcompid.Visible = true;
                TxtFirstName.ReadOnly = true;
                TxtLastName.ReadOnly = true;
                TxtMiddleName.ReadOnly = true;
            }
            else
            {
                lbl_comp_rc.Visible = false;
                txtcompid.Visible = false;
            }

            txtfileno.Text = FRNno.ToString().Trim();
            string cerpactype = AppID.ToString().Trim().Substring(0, 2);
            getdocuments(cerpactype);

            //----------------------------------------------------data from bank--------------------------------------------

            ObjGenBal = new BaseLayer.General_function();
            DataTable dtbnk = new DataTable();
            string queryforbank = "select * from Uploaded_Excel_Data where FORMNO='" + FRNno.ToString().Trim() + "'";
            dtbnk = ObjGenBal.FetchData(queryforbank);
            if (dtbnk.Rows.Count > 0)
            {
                txtfnamebank.Text = dtbnk.Rows[0]["FirstName"].ToString().Trim();
                TxtLastNamebank.Text = dtbnk.Rows[0]["LastName"].ToString().Trim();
                TxtNationalitybank.Text = dtbnk.Rows[0]["NATIONALITY"].ToString().Trim();
                TxtFirstName.Text = dtbnk.Rows[0]["FirstName"].ToString().Trim();
                TxtLastName.Text = dtbnk.Rows[0]["LastName"].ToString().Trim();

                TxtIssueDate.Text = string.Format("{0:d-MM-yyyy}", dtbnk.Rows[0]["Date1"]).ToString().Trim();

                txt_purchase_date.Text = string.Format("{0:d-MM-yyyy}", dtbnk.Rows[0]["Date1"]).ToString().Trim();
                // TxtNationality.Text = dtbnk.Rows[0]["NATIONALITY"].ToString().Trim();

                ListItem selectedListItem = TxtNationality.Items.FindByValue(dtbnk.Rows[0]["NATIONALITY"].ToString().Trim());
                if (selectedListItem != null)
                {
                    TxtNationality.Text = dtbnk.Rows[0]["NATIONALITY"].ToString().Trim();
                }
                //if(TxtNationality.SelectedValue == dtbnk.Rows[0]["NATIONALITY"].ToString().Trim())
              //  TxtNationality.SelectedValue = dtbnk.Rows[0]["NATIONALITY"].ToString().Trim();
                /*****************Saurabh*********************/
            }
            //---------------------------------------------------- end -----------------------------------------------------
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
        try
        {
            dtdocs = ObjGenBal.FetchData(queryfordocs);
            if (dtdocs.Rows.Count > 0)
            {
                chkbdoc.DataSource = dtdocs;
                chkbdoc.DataTextField = "DocName";
                chkbdoc.DataValueField = "DocCode";
                chkbdoc.DataBind();
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
    public bool IsConnectedToInternet()
    {
        //   Uri url = new Uri();
        string pingurl = ConfigurationManager.AppSettings["IPAddress"].ToString();
        //   string host = pingurl;
        bool result = false;
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
   

    protected void btnverify_Click(object sender, EventArgs e)
    {
        try
        {
            //-------------------- for checking connectivity with server-------------------
            if (IsConnectedToInternet() == false)
            {
                Response.Write("<script>alert('No network connection.Please try again later.')</script>");
                return;
            }
            //----------------------------------- end -------------------------------------

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
            if (File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"XML\" + TxtCerpacNo.Text.ToString().Trim() + ".xml")))
            {
                File.Delete(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"XML\" + TxtCerpacNo.Text.ToString().Trim() + ".xml"));
            }
            CultureInfo c = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = c.TextInfo;

            //---------------------------------------------------- for checking the expiry date of the cerpac form ------------------------------------------------- 
            DateTime d1 = Convert.ToDateTime(ConvertDate(TxtIssueDate.Text.ToString(), "d-MM-yyyy"));
            DateTime d2 = Convert.ToDateTime(ConvertDate(TxtExpDate.Text.ToString(), "d-MM-yyyy"));
            string d3 = (d2 - d1).TotalDays.ToString();
            // Response.Write("<script>alert('" + d3.ToString() + "')</script>");
            if ((TxtCerpacNo.Text.ToString().ToUpper().Substring(0, 2) == "AO" || TxtCerpacNo.Text.ToString().ToUpper().Substring(0, 2) == "CR"  || TxtCerpacNo.Text.ToString().ToUpper().Substring(0, 2) == "AB") && int.Parse(d3) >= 366)
            {
                Response.Write("<script>alert('Cerpac Expiry Date should be less than or equal to one year from issue date')</script>");
                return;
            }
            if ((TxtCerpacNo.Text.ToString().ToUpper().Substring(0, 2) == "AR" && int.Parse(d3) > 1465) && (txtcompname.Text.ToUpper() != "NIGER WIFE" && txtdesig.Text.ToUpper() != "NIGER WIFE"))
            {
                Response.Write("<script>alert('Cerpac Expiry Date for AR category should be less than or equal to four years from issue date')</script>");
                return;
            }
            //----------------------------------------------------------------end -----------------------------------------------------------------------

            if (radtype.SelectedValue == "1")
            {
                if (txt_dept_name.Text == "" || txt_dpndt.Text == TxtCerpacNo.Text.ToString().Trim())
                {
                    Response.Write("<script>alert('Please Fill Cerpac Number of the person you are Dependent On.')</script>");
                    return;
                }
            }

            // System.Threading.Thread.Sleep(5000);
            //DateTime d1 = Convert.ToDateTime(ConvertDate(TxtIssueDate.Text.ToString(), "d-MM-yyyy"));
            //DateTime d2 = 

            ObjbalApporvalL1 = new BusinessEntityLayer.BalApprovalReviewL1();
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

            int status = updatecerpacdata();
                       
            /************* Insert Image in DB **************/
            if (status == 1)
            {
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

            
                confirm.Style.Add("display", "");
                confirm.Attributes.Add("class", "confirmation-box animated-table bounceIn");
                detailtable.Style.Add("display", "none");
                gridtable.Style.Add("display", "none");
                imgbak.Style.Add("display", "none");
                btnUploadCancel.Visible = false;

                btnCheckSheet.Visible = true;
            }
            else
            {
                confirm.Style.Add("display", "");
                confirm.Attributes.Add("class", "warning-box");
                p.InnerHtml = "The Connection to Server was broken. Please try after some time.";
                detailtable.Style.Add("display", "none");
                gridtable.Style.Add("display", "none");
                imgbak.Style.Add("display", "none");
                btnUploadCancel.Visible = false;
                btnCheckSheet.Visible = false;
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

    public int updatecerpacdata()
    {
        CultureInfo c = Thread.CurrentThread.CurrentCulture;
        TextInfo textInfo = c.TextInfo;
        SqlParameter[] pram = null;
        pram = new SqlParameter[39];
        pram[0] = new SqlParameter("@passportissueby", textInfo.ToTitleCase(TxtPassportType.Text.ToString()));
        pram[1] = new SqlParameter("@dateofissuep", ConvertDate(TxtDateOfIssue.Text.ToString(), "d-MM-yyyy"));
        pram[2] = new SqlParameter("@dateofexpp", ConvertDate(txtdoe.Text.ToString(), "d-MM-yyyy"));
        pram[3] = new SqlParameter("@placeissuep", textInfo.ToTitleCase(TxtPlaceOfIssue.Text.ToString()));
        pram[4] = new SqlParameter("@companyname", txtcompname.Text.ToString());
        pram[5] = new SqlParameter("@companyadd1", textInfo.ToTitleCase(txtcompadd1.Text.ToString()));
        pram[6] = new SqlParameter("@companyadd2", textInfo.ToTitleCase(txtcompadd2.Text.ToString()));
        pram[7] = new SqlParameter("@designation", textInfo.ToTitleCase(txtdesig.Text.ToString()));
        pram[8] = new SqlParameter("@comptelno", txtphno.Text.ToString());
        pram[9] = new SqlParameter("@compfaxno", txtfaxno.Text.ToString());
        pram[10] = new SqlParameter("@emailprsn", txtemailprsn.Text.ToString());
        pram[11] = new SqlParameter("@contactprsn", txtcntcnoprsn.Text.ToString());
        pram[12] = new SqlParameter("@cerpacno", TxtCerpacNo.Text.ToString());
        pram[13] = new SqlParameter("@companyid", txtcompid.Text.ToString().Trim());
        pram[14] = new SqlParameter("@UserId", objectSessionHolderPersistingData.User_ID);
        pram[15] = new SqlParameter("@zonenote", txtnotes.Text.ToString());
        pram[16] = new SqlParameter("@fname", textInfo.ToTitleCase(TxtFirstName.Text.ToString()));
        pram[17] = new SqlParameter("@lname", textInfo.ToTitleCase(TxtLastName.Text.ToString()));
        pram[18] = new SqlParameter("@mname", textInfo.ToTitleCase(TxtMiddleName.Text.ToString()));
        pram[19] = new SqlParameter("@nationality", TxtNationality.SelectedValue.ToString());
        pram[20] = new SqlParameter("@passportno", TxtPassportNo.Text.ToString());
        pram[21] = new SqlParameter("@sex", radsex.SelectedValue.ToString());
        pram[22] = new SqlParameter("@fileno", txtfileno.Text.ToString().Trim());
        pram[23] = new SqlParameter("@isdependent", radtype.SelectedValue.ToString());
        pram[24] = new SqlParameter("@dependenton", txt_depnt_peopleid.Text);
        pram[25] = new SqlParameter("@dependentrelation", drprltn.SelectedValue.ToString());
        pram[26] = new SqlParameter("@issuedate", ConvertDate(TxtIssueDate.Text.ToString(), "d-MM-yyyy"));
        pram[27] = new SqlParameter("@expirydate", ConvertDate(TxtExpDate.Text.ToString(), "d-MM-yyyy"));
        pram[28] = new SqlParameter("@ImagePath", ViewState["imagepath"].ToString());
        pram[29] = new SqlParameter("@title", drptitle.SelectedValue.ToString());
        pram[30] = new SqlParameter("@placebirth", txtpob.Text.ToString());
        pram[31] = new SqlParameter("@phyfileno", txtphyfileno.Text.ToString());
        pram[32] = new SqlParameter("@dtemp", ConvertDate(txtdtemploymnt.Text.ToString(), "d-MM-yyyy"));
        pram[33] = new SqlParameter("@nigadd1", textInfo.ToTitleCase(txtaddrnigeria1.Text.ToString()));
        pram[34] = new SqlParameter("@nigadd2", textInfo.ToTitleCase(txtaddrnigeria2.Text.ToString()));
        pram[35] = new SqlParameter("@abdadd1", textInfo.ToTitleCase(txtaddrabroad1.Text.ToString()));
        pram[36] = new SqlParameter("@abdadd2", textInfo.ToTitleCase(txtaddrabroad2.Text.ToString()));
        pram[37] = new SqlParameter("@DOB", ConvertDate(TxtDob.Text.ToString(), "d-MM-yyyy"));
        pram[38] = new SqlParameter("@SuccessId", 1);
        pram[38].Direction = ParameterDirection.Output;
        SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_CERPAC_DATA_INSERT", pram);
        return int.Parse(pram[38].Value.ToString());
    }


    private void GenerateThumbnails(double scaleFactor, Stream sourcePath, string targetPath)
    {
        using (var image = System.Drawing.Image.FromStream(sourcePath))
        {
            // can given width of image as we want
            var newWidth = (int)(image.Width * scaleFactor);
            // can given height of image as we want
            var newHeight = (int)(image.Height * scaleFactor);
            var thumbnailImg = new Bitmap(newWidth, newHeight);
            var thumbGraph = Graphics.FromImage(thumbnailImg);
            thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
            thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
            thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
            var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
            thumbGraph.DrawImage(image, imageRectangle);
            thumbnailImg.Save(targetPath, System.Drawing.Imaging.ImageFormat.Jpeg);
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
           

            // change if else by Saurabh on date 12 Dec 13
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
                //Length = System.Convert.ToInt32(logobrowse.PostedFile.InputStream.Length);

                //byte[] Content = new byte[Length];

                //logobrowse.PostedFile.InputStream.Read(Content, 0, Length);

                //ViewState["contentImg"] = Content;

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
                          //  logobrowse.SaveAs(LogoPath1);

                            //compressImage(LogoPath1);
                            //ImgPhoto.ImageUrl = LogoPath1;
                           // FileStream strm = new FileStream(LogoPath1, FileMode.Open, FileAccess.Read);

                            Stream strm = logobrowse.PostedFile.InputStream;
                            GenerateThumbnails(0.5, strm, LogoPath1);


                            ViewState["imagepath"] = LogoName;
                            //LabelMessage.CssClass = "successmsg";
                            //LabelMessage.Text = "";

                            //Fixed the Size of the Image
                            int fixWidth = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["FixLogoWidth"]);
                            int fixHeight = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["FixLogoHeight"]);

                            //if ((ImgHeight >= fixHeight) && (Imgwidth >= fixWidth))
                            //    compressImage(LogoPath1, fixWidth, fixHeight);

                            ImgPhoto.ImageUrl = System.Configuration.ConfigurationManager.AppSettings["LogoUrl"].ToString() + LogoName.ToString();
                            logobrowse.Visible = false;
                            btnUploadPhoto.Visible = false;
                            btnUploadCancel.Visible = true;
                            btnscanpic.Visible = false;

                        }
                        else
                        {
                            //message 

                            //LabelMessage.CssClass = "errormsg";
                            //LabelMessage.Text = "Dimension of the photo is always within (210 * 210)";
                            // Response.Write("<script>alert('Dimension of the photo is always within (210 * 210)')</script>");
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
             else if (File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Images\Logo\" + TxtCerpacNo.Text.ToString().Trim() + ".jpg")))
             {
                 btnUploadCancel.Visible = true;
                 btnUploadPhoto.Visible = false;
                 logobrowse.Visible = false;
                 btnscanpic.Visible = false;
                 string LogoName1 = null;

                 LogoName1 = TxtCerpacNo.Text.ToString() + ".jpg";
                 //LogoPath1 = LogoPath + LogoName;
                 ViewState["imagepath"] = LogoName1;
                 ImgPhoto.ImageUrl = System.Configuration.ConfigurationManager.AppSettings["LogoUrl"].ToString() + LogoName1.ToString();
                 //ImgPhoto.ImageUrl = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Images\Logo\" + TxtCerpacNo.Text.ToString().Trim() + ".jpg");
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
      //  ImgPhoto.ImageUrl = null;
        logobrowse.Visible = true;
        btnUploadPhoto.Visible = true;
        btnUploadCancel.Visible = false;
        btnscanpic.Visible = true;
        ViewState["imagepath"] = null;

    }

    protected void btnCheckSheet_Click(object sender, EventArgs e)
    {

        Response.Redirect("frmCheckSheetReports.aspx?no=" + AppID + "&fno=" + FRNno + "");

    }

    protected void txtcompname_TextChanged(object sender, EventArgs e)
    {
        if (txtcompname.Text.ToUpper() == "NIGER WIFE" || txtdesig.Text.ToUpper() == "NIGER WIFE")
        {
            A3.HRef = "javascript:NewCal('" + TxtExpDate.ClientID + "','DDMMMYYYY','','',11,11)";
        }
        else
        {
            A3.HRef = "javascript:NewCal('" + TxtExpDate.ClientID + "','DDMMMYYYY','','',5,5)";
        }


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


    protected void drprltn_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtdesig.Text = drprltn.SelectedItem.Text;
    }
    


    protected void txtcompadd1_TextChanged(object sender, EventArgs e)
    {
        ObjGenBal = new BaseLayer.General_function();
        string queryforcomp = "Select regno from compmaster where company = '" + txtcompname.Text.ToString() + "'";
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

    protected void TxtIssueDate_TextChanged(object sender, EventArgs e)
    {
        //ObjGenBal = new BaseLayer.General_function();
        //string queryforcheckDate = "select Date1 as PurchaseDate from uploaded_excel_data where FormNo = '" + TxtCerpacNo.Text.ToString() + "'";
        //DataTable dt_date = new DataTable();

        //dt_date = ObjGenBal.FetchData(queryforcheckDate);

        //DateTime d1 = Convert.ToDateTime(ConvertDate(TxtIssueDate.Text.ToString(), "d-MM-yyyy"));
        //DateTime d2 = Convert.ToDateTime(ConvertDate(string.Format("{0:d-MM-yyyy}", dt_date.Rows[0]["PurchaseDate"]).ToString().Trim(),"d-MM-yyyy"));
        ////string.Format("{0:d-MM-yyyy}", dt_date.Rows[0]["PurchaseDate"]).ToString().Trim()
        //string d3 = (d2 - d1).TotalDays.ToString();

        //if (Convert.ToInt32(d3) > 90)
        //{
        //    TxtIssueDate.Text = "";
        //     ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Please Fill Valid Date.');", true);
        //     TxtIssueDate.Text = "";
        //}

    }
    protected void btnscanpic_Click(object sender, EventArgs e)
    {
        btngetdata.Visible = true;
        btnscanmrz.Visible = false;
        System.Web.HttpBrowserCapabilities browser = Request.Browser;
        string s = browser.Browser;
        // Response.Write("<script>alert('You are using " + s.ToString() + "')</script>");
        if (s == "IE")
        {
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "Onclick", "<script>window.open('ScanPic.aspx?id="+TxtCerpacNo.Text.ToString().Trim()+"','PaperVisa','menubar=no,status=yes,Width=1000,Height=600,top=50,left=5');</script>");
        }
        else
        {

            // Trace.Warn("internetexplorer");

            openbrowserpic();
            //System.Diagnostics.Process.Start("iexplore.exe");
            //this.ClientScript.RegisterClientScriptBlock(this.GetType(), "Onclick", "<script>window.open('ScanPage.aspx','PaperVisa','menubar=no,status=yes,Width=1000,Height=600,top=50,left=5');</script>");

        }
    }

    public void openbrowserpic()
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
        string url = page + "/Admin/ScanPic.aspx?id=" + id.ToString() + "";
        // string url = "http://google.com";
        ie.Navigate(url, ref nil, ref blank, ref nil, ref nil);

    }
}