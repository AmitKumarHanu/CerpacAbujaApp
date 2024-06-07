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
using System.Windows;
using SHDocVw;
using System.Drawing.Drawing2D;
using System.Threading;

public partial class Admin_frmApplicationDetailsUpdate : System.Web.UI.Page
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
        Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
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
            throw (ex);
        }
        finally
        {
            dt = null;
            ObjGenBal = null;
        }

        if (!IsPostBack)
        {
            ViewState["imagepath"] = "";
          //  A1.HRef = "javascript:NewCal('" + TxtDateOfIssue.ClientID + "','DDMMMYYYY','','',10,1)";
          //  doe.HRef = "javascript:NewCal('" + txtdoe.ClientID + "','DDMMMYYYY','','',1,10)";
            A2.HRef = "javascript:NewCal('" + TxtIssueDate.ClientID + "','DDMMMYYYY','','',0,1)";
            A3.HRef = "javascript:NewCal('" + TxtExpDate.ClientID + "','DDMMMYYYY','','',0,2)";
            A4.HRef = "javascript:NewCal('" + TxtDob.ClientID + "','DDMMMYYYY','','',78,1)";
            A5.HRef = "javascript:NewCal('" + txtdtemploymnt.ClientID + "','DDMMMYYYY','','',53,1)";
            binddrpdwn();

        }
    }

    protected void binddrpdwn()
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
        //----------------------------------------------------------------- data from db------------------------------------------------------

        Session["CerpaxNo"] = AppID.ToString().Trim();
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
            TxtPassportType.Text = Dt.Rows[0]["passport_issue_by"].ToString().Trim();
            //TxtDateOfIssue.Text = string.Format("{0:d-MM-yyyy}", Dt.Rows[0]["passport_issue_date"]).ToString().Trim();
            //txtdoe.Text = string.Format("{0:d-MM-yyyy}", Dt.Rows[0]["passport_expiry_date"]).ToString().Trim();
            TxtPlaceOfIssue.Text = Dt.Rows[0]["passport_issue_loc"].ToString().Trim();
            TxtFirstName.Text = Dt.Rows[0]["forename"].ToString().Trim();
            TxtMiddleName.Text = Dt.Rows[0]["middle_name"].ToString().Trim();
            TxtLastName.Text = Dt.Rows[0]["surname"].ToString().Trim();
            txtcompname.Text = Dt.Rows[0]["company"].ToString().Trim();
            txtcompname.ToolTip = Dt.Rows[0]["company"].ToString().Trim();

            txtcompadd1.Text = Dt.Rows[0]["company_add_1"].ToString().Trim();
            txtcompadd2.Text = Dt.Rows[0]["company_add_2"].ToString().Trim();
            txtdesig.Text = Dt.Rows[0]["designation"].ToString().Trim();
            txtphno.Text = Dt.Rows[0]["company_tel_no"].ToString().Trim();
            txtfaxno.Text = Dt.Rows[0]["company_fax_no"].ToString().Trim();
            txtfileno.Text = Dt.Rows[0]["cerpac_file_no"].ToString().Trim();
            FRNno = Dt.Rows[0]["cerpac_file_no"].ToString().Trim();
            txtemailprsn.Text = Dt.Rows[0]["Email"].ToString().Trim();
            txtcntcnoprsn.Text = Dt.Rows[0]["ContactNo"].ToString().Trim();
            radsex.SelectedValue = Dt.Rows[0]["sex"].ToString().Trim();
            TxtCerpacNo.Text = Dt.Rows[0]["cerpac_no"].ToString().Trim();
            TxtNationality.Text = Dt.Rows[0]["nationality"].ToString().Trim();
            //TxtFirstNamedb.Text = Dt.Rows[0]["forename"].ToString().Trim(); ;
            //TxtLastNamedb.Text = Dt.Rows[0]["surname"].ToString().Trim();
            //TxtNationalitydb.Text = Dt.Rows[0]["nationality"].ToString().Trim();
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
        //string cerpactype = Dt.Rows[0]["cerpac_file_no"].ToString().Trim().Substring(0, 2);
        //getdocuments(cerpactype);
        //------------------------------------------------------------------end--------------------------------------------------
        //----------------------------------------------------data from bank--------------------------------------------
        DataTable dtbnk = new DataTable();
        string queryforbank = "select * from Uploaded_Excel_Data where FORMNO='" + FRNno.ToString().Trim() + "'";
        dtbnk = ObjGenBal.FetchData(queryforbank);
        if (dtbnk.Rows.Count > 0)
        {

            //txtfnamebank.Text = dtbnk.Rows[0]["FirstName"].ToString().Trim();
            //TxtLastNamebank.Text = dtbnk.Rows[0]["LastName"].ToString().Trim();
            //TxtNationalitybank.Text = dtbnk.Rows[0]["NATIONALITY"].ToString().Trim();
        }
        //---------------------------------------------------- end -----------------------------------------------------
        //===================================================MRZ Data Fetch====================================================================
        DataTable dtmrz = new DataTable();
        string querymrz = "select * from MRZData where CerpacNo='" + TxtCerpacNo.Text.ToString().Trim() + "'";
        dtmrz = ObjGenBal.FetchData(querymrz);
        if (dtmrz.Rows.Count > 0)
        {
            //TxtFirstNamemrz.Text = dtmrz.Rows[0]["MrzFirstName"].ToString().Trim();
            //TxtLastNamemrz.Text = dtmrz.Rows[0]["MrzLastName"].ToString().Trim();
            //TxtNationalitymrz.Text = dtmrz.Rows[0]["Nationality"].ToString().Trim();
        }

        //=====================================================end=============================================================================

        //--------------------------------------fetching company name from comp master-------------------------------
        string queryforcomp = "";
        if (AppID.Substring(0, 2) == "AO")
        {
            queryforcomp = "Select * from compmaster where regno= '" + txtcompid.Text.ToString() + "'";
        }
        else
        {
            queryforcomp = "Select * from CompMasterForARCR where regno = '" + txtcompid.Text.ToString() + "'";
        }
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
            throw (ex);
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
        if (TextAppId.Text == "")
        {
            Response.Write("<script>alert('Please Fill Cerpac No.');</script>");
            return;
        }
        TxtCerpacNo.Text = TextAppId.Text;
        AppID = TextAppId.Text;
        GetData(TextAppId.Text);
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

                        if ((ImgHeight >= fixHeight) && (Imgwidth >= fixWidth))
                            compressImage(LogoPath1, fixWidth, fixHeight);

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

    protected void btnverify_Click(object sender, EventArgs e)
    {
        CultureInfo c = Thread.CurrentThread.CurrentCulture;
        TextInfo textInfo = c.TextInfo;

        DateTime d1 = Convert.ToDateTime(ConvertDate(TxtIssueDate.Text.ToString(), "d-MM-yyyy"));
        DateTime d2 = Convert.ToDateTime(ConvertDate(TxtExpDate.Text.ToString(), "d-MM-yyyy"));
        string d3 = (d2 - d1).TotalDays.ToString();
        // Response.Write("<script>alert('" + d3.ToString() + "')</script>");
        ////if (int.Parse(d3) >= 365)
        ////{
        ////    Response.Write("<script>alert('Cerpac Expiry Date should be less than or equal to one year from issue date')</script>");
        ////    return;
        ////}
        // System.Threading.Thread.Sleep(5000);

        if (radtype.SelectedValue == "1")
        {
            if (txt_dept_name.Text == "" || txt_dpndt.Text == TxtCerpacNo.Text.ToString().Trim())
            {
                Response.Write("<script>alert('Please Fill Cerpac Number of the person you are Dependent On.')</script>");
                return;
            }
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
            ObjbalApporvalL1 = new BusinessEntityLayer.BalApprovalReviewL1();
            ObjbalApporvalL1.passportissueby = textInfo.ToTitleCase(TxtPassportType.Text.ToString());
            // ObjbalApporvalL1.dateofissuep = ConvertDate(TxtDateOfIssue.Text.ToString(), "d-MM-yyyy");
            // ObjbalApporvalL1.dateofexpp = ConvertDate(txtdoe.Text.ToString(), "d-MM-yyyy");
            ObjbalApporvalL1.placeissuep = textInfo.ToTitleCase(TxtPlaceOfIssue.Text.ToString());
            ObjbalApporvalL1.companyname = txtcompname.Text.ToString();
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
            int status = ObjbalApporvalL1.UpdateCerpacApplicantData();
            //=================================== for inserting dependent================================================
            SqlParameter[] pram = null;
            pram = new SqlParameter[16];
            pram[0] = new SqlParameter("@isdependent", radtype.SelectedValue.ToString());
            pram[1] = new SqlParameter("@dependenton", drpdpndt.SelectedValue.ToString());
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

            if (status == 1)
            {
                confirm.Style.Add("display", "");
                confirm.Attributes.Add("class", "confirmation-box animated-table bounceIn");
                detailtable.Style.Add("display", "none");
                gridtable.Style.Add("display", "none");
                imgbak.Style.Add("display", "none");
                btnUploadCancel.Visible = false;

                tr_cerpac.Style.Add("display", "none");

            
        }
    }
}