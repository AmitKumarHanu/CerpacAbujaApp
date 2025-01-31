﻿using System;
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
using DataAccessLayer;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing;



public partial class Admin_ProductionProcess : System.Web.UI.Page
{
    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    BaseLayer.General_function objgenenral = null;
    protected DataSet objDs = new DataSet();
    protected DataTable dt = new DataTable();
   
    protected BaseLayer.General_function ObjGenBal = null;
    string AppID = "", FormNo="";
    string UserID = null;
    Label LabelMessage = null;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        if (objectSessionHolderPersistingData == null)
        {
            Response.Redirect("../Login.aspx");
        }

        //-----------------------------------------for disabling the hyperlink ------------------------------
        TreeView tvr = (TreeView)this.Page.Master.FindControl("TVLeftMenu");
       // tvr.Visible = false;
        HyperLink hyp = (HyperLink)this.Page.Master.FindControl("hypHome");
      //  tvr.Attributes.Add("onclick", "if(!confirm('Are you sure you want to go to home page')) return false;");
        //-----------------------------------------------end ---------------------------------------------------


        LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
        string queryforzonename = "select b.ZoneName from UserZoneRelation as a, Zonemaster as b where a.ZoneCode=b.ZoneCode and a.UserId=" + objectSessionHolderPersistingData.User_ID + "";
        objgenenral = new BaseLayer.General_function();
        DataTable dt = new DataTable();
        try
        {
            dt = objgenenral.FetchData(queryforzonename);
            if (dt.Rows.Count > 0)
            {
                LabelMessage.Text = "Zone" + " " + dt.Rows[0]["ZoneName"].ToString();
                LabelMessage.Visible = true;
                LabelMessage.BorderStyle = BorderStyle.None;
            }
        }
         catch (Exception ex)
        {
            objgenenral = new BaseLayer.General_function();
            string err = objgenenral.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            lblmsg.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            lblmsg.CssClass = "warning-box";
        }
        
        finally
        {
            dt = null;
            objgenenral = null;
        }
        if (!IsPostBack)
        {
            Bindlist();
            detailtable.Style.Add("display", "none");
           // warn.Style.Add("display", "");
        }
    }

   
    //---------------------------Bind Grid- for Waiting Production Data only----------------------------------------
    protected void Bindlist()
    {
        objgenenral = new BaseLayer.General_function();

       
    
    
        string queryforposition = " (Select  distinct(cerpac_file_no),forename as FirstName, middle_name as MiddleName, surname as  LastName, Company, Nationality, RequisitionNo, cerpac_file_no as FormNo, CerpacNo, Passport_No, isnull(StrVisaNo,'') as StrVisaNo," +
 " CASE WHEN cerpac_file_no like 'AR%' THEN 'Waiting' WHEN cerpac_file_no like 'CR%' THEN 'Waiting' ELSE  'Normal' END    as Status " +
 " from vw_prod_consolidated_data a, UserZoneRelation b where (IsAuthorized=1) and (IsProduced=0 or IsProduced is null or IsProduced=2 or IsProduced=3 or IsProduced=4) " +
 " and ISARCR=1 and a.verifiedby = b.userid  and b.ZoneCode=(select ZoneCode from UserZoneRelation where USERID='" + objectSessionHolderPersistingData.User_ID + "')  and a.cerpac_file_no not in ( Select cerpac_file_no from Central_FormVerification where IsVerified<>1 )  )" +
 " Union all" +
  " (Select  distinct(X.formno), forename as FirstName,  middle_name as MiddleName,  surname as LastName, Company, Nationality, X.RequisitionNo, X.FormNo, X.CerpacNo, Passport_No,  isnull(X.StrVisaNo,'') as StrVisaNo,  'Callback' as Status " +
 " From Central_CallBack X, PeopleChild a, UserZoneRelation b where X.FORMNO=a.FORMNO and  IsCallback=1 and isnull(IsCallbackVerified,0)<>1 and ZoneName=(select b.ZoneName from UserZoneRelation a , Zonemaster b where a.ZoneCode=b.ZoneCode and  a.UserId='" + objectSessionHolderPersistingData.User_ID + "') " +
 " and (a.IsAuthorized=1) and (a.IsProduced=0 or a.IsProduced is null or a.IsProduced=2 or a.IsProduced=3 or a.IsProduced=4) and a.ISARCR=1 and a.verifiedby = b.userid )  ";


      //  (Select  distinct(cerpac_file_no),forename as FirstName, middle_name as MiddleName, surname as  LastName, Company, Nationality, RequisitionNo, cerpac_file_no as FormNo, CerpacNo, Passport_No, isnull(StrVisaNo,'') as StrVisaNo, 
 // CASE WHEN cerpac_file_no like 'AR%' THEN 'Waiting' WHEN cerpac_file_no like 'CR%' THEN 'Waiting'ELSE  'Normal' END    as Status  
 // from vw_prod_consolidated_data a, UserZoneRelation b where (IsAuthorized=1) and (IsProduced=0 or IsProduced is null or IsProduced=2 or IsProduced=3 or IsProduced=4)  
 // and ISARCR=1 and a.verifiedby = b.userid  and b.ZoneCode=(select ZoneCode from UserZoneRelation where USERID='28760')  and a.cerpac_file_no not in ( Select cerpac_file_no from Central_FormVerification where IsVerified<>1 )  ) 
 // Union all 
 //  (Select  distinct(X.formno), forename as FirstName,  middle_name as MiddleName,  surname as LastName, Company, Nationality, X.RequisitionNo, X.FormNo, X.CerpacNo, Passport_No,  isnull(X.StrVisaNo,'') as StrVisaNo,  'Callback' as Status  
 // From Central_CallBack X, PeopleChild a, UserZoneRelation b where X.FORMNO=a.FORMNO and  IsCallback=1 and isnull(IsCallbackVerified,0)<>1 and ZoneName=(select b.ZoneName from UserZoneRelation a , Zonemaster b where a.ZoneCode=b.ZoneCode and  a.UserId='28760')  
 // and (a.IsAuthorized=1) and (a.IsProduced=0 or a.IsProduced is null or a.IsProduced=2 or a.IsProduced=3 or a.IsProduced=4) and a.ISARCR=1 and a.verifiedby = b.userid )  ;




        DataTable dt1 = new DataTable();
        dt1 = null;
        dt1 = objgenenral.FetchData(queryforposition);

        if (dt1.Rows.Count > 0)
        {
            grd_display_data.DataSource = dt1;
            grd_display_data.DataBind();
        }
        else
        {
            
            grd_display_data.DataSource = dt1;
            grd_display_data.DataBind();
            
        }


    }

    //-----------------------------Display Details Select Cerpac no ------------------------------------------------
    protected void Go_Click(object sender, EventArgs e)
    {
        objgenenral = new BaseLayer.General_function();
        //string quer = "select a.*,b.* from People as a , PeopleChild as b where a.cerpac_no = b.CerpacNo and a.cerpac_no='" + TextAppId.Text.ToString() + "'";

        string quer = "select * from vw_prod_consolidated_data a, UserZoneRelation b where (IsAuthorized=1) and (isarcr=1) and (IsProduced=0 or IsProduced is null or IsProduced=2 or IsProduced=3 or IsProduced=4) and a.verifiedby = b.userid  and b.ZoneCode=(select ZoneCode from UserZoneRelation where USERID=" + objectSessionHolderPersistingData.User_ID + ") and cerpacno='" + TextAppId.Text.ToString() + "'";
       try
       {

            DataTable dt = new DataTable();
            dt = objgenenral.FetchData(quer);
            FormNo = dt.Rows[0]["Cerpac_file_no"].ToString().Trim();
           GetData(TextAppId.Text, FormNo);
       }
       catch (Exception ex)
       {
           objgenenral = new BaseLayer.General_function();
           string err = objgenenral.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
           lblmsg.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
           lblmsg.CssClass = "warning-box";
       }
       finally
       {
           dt = null;
           objgenenral = null;
       }
    }

    private void GetData(string ApplicationId, string FormNo1)
    {
        DataTable Dt = null, DtCall = null, DtCall1 = null, DtCall2 = null;
        Dt = new DataTable();
        ObjGenBal = new BaseLayer.General_function();
        try
        {
            //-----------------------Cross Check Call Back Verify Flag----------------------

            string QtyCallBack = "Select 'Waiting' as Status From Central_CallBack where IsCallback=1 and isnull(IsCallbackVerified,0)<>1 and ZoneName=(select b.ZoneName from UserZoneRelation a , Zonemaster b where a.ZoneCode=b.ZoneCode and  a.UserId=" + objectSessionHolderPersistingData.User_ID + ") and cerpac_no='" + ApplicationId.ToString().Trim() + "' and cerpac_file_no='" + FormNo1.ToString().Trim() + "'"; 
            DtCall = ObjGenBal.FetchData(QtyCallBack);
            if (DtCall.Rows.Count > 0)
            {
                lblmsg.Text = "Please verify callback CERPAC by central before production !! ";
                lblmsg.CssClass = "warning-box";
                return;
    
            }

           //-----------------------Cross Verify Flag for AR and CR----------------------


            //-----------------------Cross Verify Flag for AR and CR----------------------

            string QtyARCR1 = "Select cerpac_no, cerpac_file_no From People where cerpac_no='" + ApplicationId.ToString().Trim() + "' and cerpac_file_no='" + FormNo1.ToString().Trim() + "' and ( cerpac_file_no like 'AR%' or cerpac_file_no like 'CR%' ) ";
            DtCall1 = ObjGenBal.FetchData(QtyARCR1);

            if (DtCall1.Rows.Count > 0)
            {
                string QtyARCR2 = "Select count(*)  as Count From [Central_FormVerification] where cerpac_no='" + ApplicationId.ToString().Trim() + "' and cerpac_file_no='" + FormNo1.ToString().Trim() + "' and ( cerpac_file_no like 'AR%' or cerpac_file_no like 'CR%' )  and isnull(isverified,0)=1 ";
                DtCall2 = ObjGenBal.FetchData(QtyARCR2);

                lblmsg.Text = DtCall2.Rows[0]["Count"].ToString();
                if (Convert.ToInt32(DtCall2.Rows[0]["Count"].ToString()) == 0)
                {
                    lblmsg.Text = "Please verify CERPAC by central before production !! ";
                    lblmsg.CssClass = "warning-box";
                    return;
                }
            }


            string queryforcerpac = "select * from vw_prod_consolidated_data where (IsAuthorized=1) and (isarcr=1) and cerpac_no='" + ApplicationId.ToString() + "' and (IsProduced=0 or IsProduced is null or IsProduced=2 or IsProduced=3 or IsProduced=4)";
            Dt = ObjGenBal.FetchData(queryforcerpac);
            Session["Card"] = Dt;
            DataTable dtimg = new DataTable();
            if (Dt.Rows.Count > 0)
            {
            string qryimg = "select userimage from people where cerpac_no='" + Dt.Rows[0]["cerpac_no"].ToString() + "'";
            dtimg = ObjGenBal.FetchData(qryimg);

            
               

                /**********Fetch Image**************/

                byte[] picData = dtimg.Rows[0]["userimage"] as byte[] ?? null;
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
                TxtNationality.Text = string.Format("{0:dd/MM/yy}", Dt.Rows[0]["nationality"]).ToString().Trim();
                TxtPassportType.Text = string.Format("{0:dd/MM/yy}", Dt.Rows[0]["passport_issue_by"]).ToString().Trim();
                TxtDateOfIssue.Text = string.Format("{0:dd/MM/yy}", Dt.Rows[0]["passport_issue_date"]).ToString().Trim();
                txtdoe.Text = string.Format("{0:dd/MM/yy}", Dt.Rows[0]["passport_expiry_date"]).ToString().Trim();
                TxtPlaceOfIssue.Text = Dt.Rows[0]["passport_issue_loc"].ToString().Trim();
                TxtFirstName.Text = Dt.Rows[0]["forename"].ToString().Trim();
                TxtMiddleName.Text = Dt.Rows[0]["middle_name"].ToString().Trim();
                TxtLastName.Text = Dt.Rows[0]["surname"].ToString().Trim();
                txtcompid.Text = Dt.Rows[0]["company"].ToString().Trim();

                //DataTable ds_comp = new DataTable();
                //ds_comp = ObjGenBal.FetchData("select isnull(company,'') as company from compmaster where regno='" + txtcompid.Text + "'");

                //if (ds_comp.Rows.Count > 0)
                //    txtcompname.Text = ds_comp.Rows[0]["company"].ToString().Trim();
                //else
                //    txtcompname.Text = "";

                //--------------------------------------fetching company name from comp master-------------------------------
                DataTable dtcomp = null;
                dtcomp = new DataTable();
                string queryforcomp = "";
                if (ApplicationId.Substring(0, 2) == "AO")
                {
                    queryforcomp = "Select regno,company from compmaster where regno = '" + Dt.Rows[0]["company"].ToString().Trim() + "'";
                }
                else
                {
                    queryforcomp = "Select regno,company from CompMasterForARCR where regno = '" + Dt.Rows[0]["company"].ToString().Trim() + "'";
                }



                //  string queryforcomp = "Select company from compmaster where regno='" + Dt.Rows[0]["company"].ToString().Trim() + "'";
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

                detailtable.Style.Add("display", "");
                warn.Style.Add("display", "none");
                div_grd.Style.Add("display", "none");
                tr_msg.Style.Add("display", "none");

                tr_ser.Style.Add("display", "none");

                imagecom(picData);

            }
            else
            {
                lblmsg.Text = "Cerpac Number has not been verified or not exist or Already Produced.";
                detailtable.Style.Add("display", "none");


              //  warn.Style.Add("display", "");
            }
        }

        catch (Exception ex)
        {
            objgenenral = new BaseLayer.General_function();
            string err = objgenenral.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            lblmsg.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            lblmsg.CssClass = "warning-box";
        }
        finally
        {
            dt = null;
            objgenenral = null;
        }

    }

    //---------------------------------Calling Card Production Detail Page---------------------------------------
    protected void btnCardGen_Click(object sender, EventArgs e)
    {
        objgenenral = new BaseLayer.General_function();
        DataTable dt_con=new DataTable();
        
       

        {
            Response.Redirect("ProductionDetails.aspx");
        }
      

    }

    /****************Image Compress***********************************/

    private void GenerateThumbnails(double scaleFactor, Stream sourcePath,string targetPath)
    {
        using (var image =System.Drawing.Image.FromStream(sourcePath))
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
    public void imagecom(byte[] picData)
    {
       // byte[] picData = dt.Rows[0]["userimage"] as byte[] ?? null;
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

                //if (dt.Rows[0]["picture"] == null || dt.Rows[0]["picture"].ToString() == "")
                //    dt.Rows[0]["picture"] = dt.Rows[0]["cerpac_no"] + ".jpg";

                if (File.Exists(Server.MapPath("~") + "/Images/prod/1.jpg"))
                    File.Delete(Server.MapPath("~") + "/Images/prod/1.jpg");

                if (File.Exists(Server.MapPath("~") + "/Images/prod/11.jpg"))
                    File.Delete(Server.MapPath("~") + "/Images/prod/11.jpg");


                if (!File.Exists(Server.MapPath("~") + "/Images/prod/1.jpg"))
                    newImage.Save(Server.MapPath("~") + "/Images/prod/1.jpg");
                //// newImage.Save("g:/Saurabh" + Dt.Rows[0]["picture"].ToString().Trim());

               // compressImage(Server.MapPath("~") + "/Images/prod/1.jpg", 80, 100);

                
                
               //// compress(System.Drawing.Image ImgPhoto, Server.MapPath("~") + "/Images/prod/1.jpg");
                FileStream strm = new FileStream(Server.MapPath("~") + "/Images/prod/1.jpg", FileMode.Open, FileAccess.Read);
                GenerateThumbnails(0.5, strm, Server.MapPath("~") + "/Images/prod/11.jpg");
                /************* Insert Image in DB **************/
                int Length = 0;
                byte[] data = null;
                FileInfo fInfo = new FileInfo(Server.MapPath("~") + "/Images/prod/11.jpg");
                Length = System.Convert.ToInt32(fInfo.Length);
                byte[] Content = new byte[Length];
                /// <summary>
                /// The Read method is used to read the file from the ImageToUpload control </summary>
                //int Content1=ImageToUpload.PostedFile.InputStream.Read(Content,0,Length);
                long numBytes = fInfo.Length;
                FileStream fStream = new FileStream(Server.MapPath("~") + "/Images/prod/11.jpg", FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fStream);
                data = br.ReadBytes((int)numBytes);


                SqlConnection Connection = new SqlConnection();
                Connection.ConnectionString = ConfigurationManager.ConnectionStrings["NigeriaConnectionString"].ConnectionString;
                SqlCommand Command = new SqlCommand("update people set userImage=@ImageFile where cerpac_no='" + TxtCerpacNo.Text + "' and datalength(userimage)>24800", Connection);

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

            //    DataTable dtimg = new DataTable();
            //    string qryimg = "select userimage,datalength(userimage) as leng from people where cerpac_no='" + TxtCerpacNo.Text + "'";
            //dtimg = ObjGenBal.FetchData(qryimg);

            //if (dtimg.Rows.Count > 0)
            //{
            //    byte[] picData1 = dtimg.Rows[0]["userimage"] as byte[] ?? null;

            //}

               
            }
        }
    }


    public void Crop(Bitmap bm, int cropX, int cropY, int cropWidth, int cropHeight)
    {
        var rect = new System.Drawing.Rectangle(cropX, cropY, cropWidth, cropHeight);

        Bitmap newBm = bm.Clone(rect, bm.PixelFormat);

        newBm.Save("c:/image2.jpg");
    }

    private ImageCodecInfo GetEncoder(ImageFormat format)
    {

        ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

        foreach (ImageCodecInfo codec in codecs)
        {
            if (codec.FormatID == format.Guid)
            {
                return codec;
            }
        }
        return null;
    }
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

    /**********************************************************************************/


    protected void grd_display_data_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        grd_display_data.PageIndex = e.NewPageIndex;
        Bindlist();

    }
    protected void grd_display_data_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {

    }

    protected void grd_display_data_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
          //  e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
            e.Row.ToolTip = "Click to select row";
            e.Row.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.grd_display_data, "Select$" + e.Row.RowIndex);
        }
    }

    protected void grd_display_data_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = grd_display_data.SelectedRow;

        GetData(row.Cells[5].Text, row.Cells[6].Text);
        btn_back.Visible = true;
    }
    protected void btn_back_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProductionProcess.aspx");
    }
}