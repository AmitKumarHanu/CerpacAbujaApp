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
using DataAccessLayer;

using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Drawing.Imaging;


public partial class Admin_frmImportZoneRequestBankData : System.Web.UI.Page
{
    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    BaseLayer.General_function objgenenral = null;
    protected DataSet objDs = new DataSet();
    protected DataTable dt = new DataTable();
    protected DataTable dtform = new DataTable();
    protected DataTable dtCerpac = new DataTable();

    protected BaseLayer.General_function ObjGenBal = null;
    string AppID = "";
    string UserID = null, ZoneDetails = null, NewReq;
    Label LabelMessage = null ;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
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
                divbrowsefile.Visible = true;
                DivCase1.Visible = false;
                DivCase2.Visible = false;
                DivCase3.Visible = false;
                divgrd.Visible = false;
                divSearchResult.Visible = false;
                divReadFile.Visible = false;
                divSearchCerpac.Visible = false;
                divgrdCerpac.Visible = false;
                divCrefile.Visible = false;
               
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
            objgenenral = null;
        }
        
    }

    protected void grd_display_data_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
     

    }
    protected void grd_display_data_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {

    }

    protected void grd_display_data_RowCreated(object sender, GridViewRowEventArgs e)
    {
       
    }

    protected void grd_display_data_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
    
       
    protected void DecryptFile(object sender, EventArgs e)
    {
        try
        {
            if (FileUpload1.HasFile)
            {
                string Savepath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + FileUpload1.FileName;
                FileUpload1.SaveAs(Savepath);
            }

            //string foldername = "Decrypt File";
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            filePath = filePath + @"\" ;

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }



            //Get the Input File Name and Extension
            string fileName = Path.GetFileNameWithoutExtension(FileUpload1.PostedFile.FileName);
            string fileExtension = Path.GetExtension(FileUpload1.PostedFile.FileName);

            string input = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + fileName + fileExtension;


            string output = filePath + @"\" + fileName + "_dec" + fileExtension;

            //Save the Input File, Decrypt it and save the decrypted file in output path.
            this.Decrypt(input, output);

            TextAppId.Text = File.ReadAllText(output);
            SplitString();

           
            //string Readfile = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + fileName + fileExtension;
            //dstest.ReadXml(filePath);

            //Delete the original (input) and the decrypted (output) file.
            //File.Delete(input);
            //File.Delete(output);
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

    }

    private void Decrypt(string inputFilePath, string outputfilePath)
    {
        string EncryptionKey = "MAKV2SPBNI99212";
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (FileStream fsInput = new FileStream(inputFilePath, FileMode.Open))
            {
                using (CryptoStream cs = new CryptoStream(fsInput, encryptor.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    using (FileStream fsOutput = new FileStream(outputfilePath, FileMode.Create))
                    {
                        int data;
                        while ((data = cs.ReadByte()) != -1)
                        {
                            fsOutput.WriteByte((byte)data);
                        }
                    }
                }
            }
        }
    }
    
    public void SplitString()
    {
        try
        {
            String source = TextAppId.Text;
            string[] stringSeparators = new string[] { "\r\n" };
            var result = source.Split(stringSeparators, StringSplitOptions.None);

            String FirstLine = result[0].Trim();
            string[] stringSeparators1 = new string[] { "\t" };
            var resultFirst  = FirstLine.Split(stringSeparators1, StringSplitOptions.None);
            lblZonename.Text = resultFirst[1];
            lblFreshZoneName.Text = resultFirst[1];
            lblRenewalZoneName.Text = resultFirst[1];
            lblBothZoneName.Text = resultFirst[1];

            String SecondLine = result[1].Trim();
            string[] stringSeparators2 = new string[] { "\t" };
            var resultSecond = SecondLine.Split(stringSeparators2, StringSplitOptions.None);
            String Condition = resultSecond[1];
            ViewState["Condition"] = Condition;

            if (Condition == "1")
            {
                String ThirdLine = result[2].Trim();
                string[] stringSeparators3 = new string[] { "\t" };
                var resultThird = ThirdLine.Split(stringSeparators3, StringSplitOptions.None);
                txtFormNo_Z1.Text = resultThird[1];
                
                divbrowsefile.Visible = false;
                DivCase1.Visible = true;
                DivCase2.Visible = false;
                DivCase3.Visible = false;
            } else if (Condition == "2")
            {
                String ThirdLine = result[2].Trim();
                string[] stringSeparators3 = new string[] { "\t" };
                var resultThird = ThirdLine.Split(stringSeparators3, StringSplitOptions.None);
                txtFormNo_R1.Text = resultThird[1];

                String ForthLine = result[3].Trim();
                string[] stringSeparators4 = new string[] { "\t" };
                var resultForth = ForthLine.Split(stringSeparators4, StringSplitOptions.None);
                txtCerpacno_R1.Text = resultForth[1];
               
                divbrowsefile.Visible = false;
                DivCase1.Visible = false;
                DivCase2.Visible = true;
                DivCase3.Visible = false;
            } else if (Condition == "3")
            {
                String ThirdLine = result[2].Trim();
                string[] stringSeparators3 = new string[] { "\t" };
                var resultThird = ThirdLine.Split(stringSeparators3, StringSplitOptions.None);
                txtFormNo_B1.Text = resultThird[1];

                String ForthLine = result[3].Trim();
                string[] stringSeparators4 = new string[] { "\t" };
                var resultForth = ForthLine.Split(stringSeparators4, StringSplitOptions.None);
                txtFormNo_B2.Text = resultForth[1];

                String FifthLine = result[4].Trim();
                string[] stringSeparators5 = new string[] { "\t" };
                var resultFifth = FifthLine.Split(stringSeparators5, StringSplitOptions.None);
                txtCerpacNo_B1.Text = resultFifth[1];

                divbrowsefile.Visible = false;
                DivCase1.Visible = false;
                DivCase2.Visible = false;
                DivCase3.Visible = true;
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

        
    }
   
    protected void btnSearchForm_Click(object sender, EventArgs e)
    {

        String source = txtFormNo_Z1.Text.Trim();
        int count = 0;



        int AO = Regex.Matches(source, "AO").Count;
        int AR = Regex.Matches(source, "AR").Count;
        int CR = Regex.Matches(source, "CR").Count;
        int NG = Regex.Matches(source, "NG").Count;


       

        divbrowsefile.Visible = false;
        divReadFile.Visible = true;
        divSearchResult.Visible = true;
        divgrd.Visible = false;
        divCrefile.Visible = false;
        

        //lblTotalRequest.Text = count.ToString();
        count = (AO + AR + CR + NG);
        lblTotalRequest.Text = count.ToString();

        //---------------------------------------Total Form found in database-------------------------------------

        objgenenral = new BaseLayer.General_function();
        string QuerCountFound = "select count(*) from uploaded_excel_data where formno in ('" + txtFormNo_Z1.Text.Replace(",", "','") + "')";
        try
        {
            DataTable dt = new DataTable();
            dt = objgenenral.FetchData(QuerCountFound);
            if (dt.Rows.Count > 0)
            {
                lblFoundinDatabae.Text = dt.Rows[0][0].ToString();

                //tr45.Style.Add("display", "");
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

        //------------------------total already used form in bank database------------------------=

        string QuerCountUsedFound = "select count(*) from uploaded_excel_data where formno in ('" + txtFormNo_Z1.Text.Replace(",", "','") + "') and isnull(CerpacNo, '')<>''";

        try
        {
            DataTable dt = new DataTable();
            dt = objgenenral.FetchData(QuerCountUsedFound);
            if (dt.Rows.Count > 0)
            {
                lblAlreadyUsedForm.Text = dt.Rows[0][0].ToString();

                //tr45.Style.Add("display", "");
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

        //--------------------------total free form no.'s for issue to request location--------------------------------
        string QuerCountFreeFound = "select count(*) from uploaded_excel_data where formno in ('" + txtFormNo_Z1.Text.Replace(",", "','") + "') and isnull(CerpacNo, '')=''";

        try
        {
            DataTable dt = new DataTable();
            dt = objgenenral.FetchData(QuerCountFreeFound);
            if (dt.Rows.Count > 0)
            {
               lblFreeForm.Text = dt.Rows[0][0].ToString();

                
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
        //---------------------------------------------------check audit trail---------------------------------------------------

        //-----------Convert date formate ()-------------
        var culture = System.Globalization.CultureInfo.CurrentCulture;

        string sysFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
        string[] formats = { "M/d/yyyy", "M/dd/yyyy", "MM/dd/yyyy", "M/d/yy", "M/dd/yy", "MM/dd/yy",
                                              "M-d-yyyy", "M-dd-yyyy", "MM-dd-yyyy", "M-d-yy", "M-dd-yy", "MM-dd-yy",
                                             "d/M/yyyy", "dd/M/yyyy", "dd/MM/yyyy", "d/M/yy", "dd/M/yy", "dd/MM/yy",
                                             "d-M-yyyy", "dd-M-yyyy", "dd-MM-yyyy", "d-M-yy", "dd-M-yy", "dd-MM-yy",
                                             "d-MMM-yy", "dd-MMM-yy", "d-MMMM-yyyy","dd-MMMM-yyyy", };
        DateTime date;
        if (DateTime.TryParseExact(DateTime.Now.ToShortDateString(), formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            date.ToString(sysFormat);
        //---------------Audit trail in bank request formno.'s---------------------

        String src = txtFormNo_Z1.Text.ToString().Trim();
        string[] stringSeparators = new string[] { "," };
        var result = src.Split(stringSeparators, StringSplitOptions.None);
        int loop = 0;
        string AlreadyReq = "";
        for (int i = 0; i <= result.Count() - 1; i++)
        {
            string formno = result[i].ToString().Trim();
            result[i] = formno;
            if (result[i].ToString().Substring(0, 2).Trim() == "AO" || result[i].ToString().Substring(0, 2).Trim() == "AR" || result[i].ToString().Substring(0, 2).Trim() == "CR" || result[i].ToString().Substring(0, 2).Trim() == "NG")
            {
                //-----------------Search in People table--------------------
                ObjGenBal = new BaseLayer.General_function();
                //string QuerAudit = "select count(*) from uploaded_excel_data_C where  Formno='" + result[i].ToString().Trim() + "' and isnull(final_flag, '')=''";
                string QuerAudit = "select count(*) from uploaded_excel_data_C where  Formno='" + result[i].ToString().Trim() + "'";

                DataTable dt = new DataTable();
                dt = ObjGenBal.FetchData(QuerAudit);
                if (dt.Rows[0].ItemArray[0].ToString() == "0")
                {

                    //--------------------------Insert--------------------------------   

                    SqlConnection Connection = new SqlConnection();
                    Connection.ConnectionString = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;

                    SqlCommand Command = new SqlCommand("Insert into uploaded_excel_data_C (FormNo,bank_req_userid,bank_req_date,zone_name) Values( '" + result[i].ToString().Trim() + "','" + UserID.ToString().Trim() + "','" + date.ToString(sysFormat) + "', '" + lblZonename.Text + "')", Connection);
                    Connection.Open();
                    Command.ExecuteNonQuery();
                    Connection.Close();
                    NewReq = NewReq + result[i].ToString().Trim() + " ";
                }
                else
                {
                    AlreadyReq = AlreadyReq + result[i].ToString().Trim() + " ";
                }

            }
            else
            {
                loop++;
            }

        }
        if (loop > 0)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('We found " + loop + " worng form no in textbox .');", true);

        }
        if (AlreadyReq != "")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Already requested form no :" + AlreadyReq.Trim().Replace(" ", ",") + ".');", true);

        }

        //-------------------Bind datagrid with free form no.'s only for genrate encrypt respons file ----------------------------

        try
        {
            if (lblFreeForm.Text.Trim() != "0")
            {
                string quer = "select FirstName, LastName, Company, Nationality, FormNo, CerpacNo, tellerno, amount, Convert(varchar(10),Date1,103) as ReceivedDate, PassportNo, isnull(StrVisaNo,'') as StrVisaNo from uploaded_excel_data where formno in ('" + txtFormNo_Z1.Text.Replace(",", "','") + "') and isnull(CerpacNo, '')=''";




                //divbrowsefile.Visible = false;
                //divReadFile.Visible = false;
                //divSearchResult.Visible = true;
                //divgrd.Visible = true;
                //divCrefile.Visible = true;

                dtform = objgenenral.FetchData(quer);
                if (dtform.Rows.Count > 0)
                {
                    grd_display_data.DataSource = dtform;
                    grd_display_data.DataBind();

                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Requested form no.'s already used.');", true);
               
               
            }
            dtform = null;
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
            objgenenral = null;
        }

    }
    protected void btnEncrypt_Click(object sender, EventArgs e)
    {
        
        string xmlfilename = "default.xml";
        string foldername = "CRB-" + DateTime.Now.ToString().Replace("/", "").Replace(":", "");
        string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        filePath = filePath + @"\";

        if (TextAppId.Text != "")
        {

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            //---------------Central Response for Bank Request----------------------
            xmlfilename = "CRB-" + lblZonename.Text.Trim().ToString() + "-" + DateTime.Now.Date.ToString("dd/MM/yyyy").Replace("/", "").Replace(":", "") + "-" + DateTime.Now.ToLocalTime().ToLongTimeString().Replace(" ", "").Replace(":", ".") + ".xml";

            if (File.Exists(Path.Combine(filePath, filePath + @"\" + xmlfilename.ToString().Trim())))
            {
                File.Delete(Path.Combine(filePath, filePath + @"\" + xmlfilename.ToString().Trim()));
            }

            System.IO.StreamWriter s = File.CreateText(System.IO.Path.Combine(filePath, filePath + @"\" + xmlfilename.ToString().Trim()));

           
            try
            {
                //------------------Write textbox serach result in the text file--------------
                s.WriteLine("ZoneName : " + lblZonename.Text);
                s.WriteLine("Total Request from zone:\t" + lblTotalRequest.Text);
                s.WriteLine("Form in Bank Database :\t"+ lblFoundinDatabae.Text);
                s.WriteLine("Already used Form:\t"+ lblAlreadyUsedForm.Text);
                s.WriteLine("Current Issue Form:\t" + lblFreeForm.Text);
                objgenenral = new BaseLayer.General_function();

               if (ViewState["Condition"].ToString() == "1")
                {
                    string txtBankCondition1 = "-Cond1-";
                   
                    //------------------Write bank details in the text file------------------------
                    string quer = "select Convert(varchar(10),Date1,103) as Date1, FirstName, MiddleName, LastName, Company, Nationality, RequisitionNo, FormNo, CerpacNo, PassportNo, isnull(StrVisaNo,'') as StrVisaNo,tellerno,amount from uploaded_excel_data where formno in ('" + txtFormNo_Z1.Text.Replace(",", "','") + "') and isnull(CerpacNo, '')=''";

                    dtform = objgenenral.FetchData(quer);
                    for (int i = 0; i <= dtform.Rows.Count - 1; i++)
                    {
                       txtBankCondition1= txtBankCondition1+ grd_display_data.Rows[i].Cells[0].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[1].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[2].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[3].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[4].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[5].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[6].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[7].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[8].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[9].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[10].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[11].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[12].Text.ToString() + "-Cond1-";

                    }
                    s.WriteLine(txtBankCondition1);
                }
                else if (ViewState["Condition"].ToString() == "2")
                {
                    string txtBankCondition2 = "-Cond2-";
                    string txtPeopleCondition2 = "-Cond2-"; 
                 
                    //------------------Write bank grid details in the text file------------------------
                    string quer = "select Convert(varchar(10),Date1,103) as Date1, FirstName, MiddleName, LastName, Company, Nationality, RequisitionNo, FormNo, CerpacNo, PassportNo, isnull(StrVisaNo,'') as StrVisaNo,tellerno,amount from uploaded_excel_data where formno in ('" + txtFormNo_R1.Text.Replace(",", "','") + "') and isnull(CerpacNo, '')=''";

                    dtform = objgenenral.FetchData(quer);
                    for (int i = 0; i <= dtform.Rows.Count - 1; i++)
                    {
                       txtBankCondition2= txtBankCondition2 + grd_display_data.Rows[i].Cells[0].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[1].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[2].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[3].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[4].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[5].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[6].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[7].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[8].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[9].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[10].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[11].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[12].Text.ToString() + "-Cond2-";

                    }
                    s.WriteLine(txtBankCondition2);
                    //------------------Write People table grid details in the text file------------------------
                    string QuerPeople = "SELECT people_id , title , forename , middle_name , surname , sex , residence_permit_no , residence_issue_loc , deedmark_no ,  printed ," +
                    " label_print_count , card_print_count , picture , directory , notes , cerpac_no , cerpac_file_no , cerpac_receipt_date , cerpac_expiry_date , registration_area ," +
                    " registration_code , file_no , label_no , book_no , passport_no , nationality , passport_issue_date , passport_expiry_date , passport_issue_loc , passport_issue_by ," +
                    " date_of_birth , place_of_birth , nigeria_add_1 , nigeria_add_2 , nigeria_tel_no , abroad_add_1 , abroad_add_2 , abroad_tel_no , company , company_add_1 ," +
                    " company_add_2  , designation , employment_date , company_tel_no , company_fax_no , email , date_added , added_by_user_id , date_modified , modified_by_user_id ," +
                    " picture_taken , picture_by_user_id , verid_template , verid_template_1 , arcanet_2d_command , date_system_modified , ContactNo , userImage " +
                    " from people where cerpac_no in ('" + txtCerpacno_R1.Text.Replace(",", "','") + "')";

                    dtCerpac = objgenenral.FetchData(QuerPeople);
                    for (int i = 0; i <= dtCerpac.Rows.Count - 1; i++)
                    {
                        //--------------------Convert Byte[] to baser64 String ----------------------
                        //byte[] barrImg = (byte[])dt.Rows[0]["userimage"];
                        byte[] barrImg = (byte[])dtCerpac.Rows[i].ItemArray[57];

                        MemoryStream mstream = new MemoryStream(barrImg);
                        System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(mstream);
                        MemoryStream imageStream = new MemoryStream();

                        bmp.Save(imageStream, ImageFormat.Jpeg);

                        string imageString = Convert.ToBase64String(imageStream.ToArray());
                        //---------------------------------------------------------------------------

                        txtPeopleCondition2 = txtPeopleCondition2 + dtCerpac.Rows[i].ItemArray[0].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[1].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[2].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[3].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[4].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[5].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[6].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[7].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[8].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[9].ToString().Trim() + "\t"
                              + dtCerpac.Rows[i].ItemArray[10].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[11].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[12].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[13].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[14].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[15].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[16].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[17].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[18].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[19].ToString().Trim() + "\t"
                              + dtCerpac.Rows[i].ItemArray[20].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[21].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[22].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[23].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[24].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[25].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[26].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[27].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[28].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[29].ToString().Trim() + "\t"
                              + dtCerpac.Rows[i].ItemArray[30].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[31].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[32].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[33].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[34].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[35].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[36].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[37].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[38].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[39].ToString().Trim() + "\t"
                              + dtCerpac.Rows[i].ItemArray[40].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[41].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[42].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[43].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[44].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[45].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[46].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[47].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[48].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[49].ToString().Trim() + "\t"
                              + dtCerpac.Rows[i].ItemArray[50].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[51].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[52].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[53].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[54].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[55].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[56].ToString().Trim() + " \t " + imageString + "-Cond2-";
                         
                    }
                    
                    s.WriteLine(txtPeopleCondition2);
                }
                else if (ViewState["Condition"].ToString() == "3")
                {
                    string txtFreshCondition3 = "-Cond3-";
                    string txtRenewCondition3 = "-Cond3-";
                    string txtPeopleCondition3 = "-Cond3-";
                   
                    //------------------Write bank details in the text file------------------------
                    string querFresh = "select Convert(varchar(10),Date1,103) as Date1, FirstName, MiddleName, LastName, Company, Nationality, RequisitionNo, FormNo, CerpacNo, PassportNo, isnull(StrVisaNo,'') as StrVisaNo,tellerno,amount from uploaded_excel_data where formno in ('" +  txtFormNo_B1.Text.Replace(",", "','") + "') and isnull(CerpacNo, '')=''";

                    dtform = objgenenral.FetchData(querFresh);
                    for (int i = 0; i <= dtform.Rows.Count - 1; i++)
                    {
                        txtFreshCondition3 = txtFreshCondition3 + grd_display_data.Rows[i].Cells[0].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[1].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[2].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[3].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[4].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[5].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[6].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[7].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[8].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[9].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[10].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[11].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[12].Text.ToString() + "-Cond3-";

                    }
                    s.WriteLine(txtFreshCondition3);


                    //------------------Write bank grid details in the text file------------------------
                    string querRenewal = "select Convert(varchar(10),Date1,103) as Date1, FirstName, MiddleName, LastName, Company, Nationality, RequisitionNo, FormNo, CerpacNo, PassportNo, isnull(StrVisaNo,'') as StrVisaNo,tellerno,amount from uploaded_excel_data where formno in ('" + txtFormNo_B2.Text.Replace(",", "','") + "') and isnull(CerpacNo, '')=''";

                    dtform = objgenenral.FetchData(querRenewal);
                    for (int i = 0; i <= dtform.Rows.Count - 1; i++)
                    {
                        txtRenewCondition3 = txtRenewCondition3 + grd_display_data.Rows[i].Cells[0].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[1].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[2].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[3].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[4].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[5].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[6].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[7].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[8].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[9].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[10].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[11].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[12].Text.ToString() + "-Cond3-";

                    }
                    s.WriteLine(txtRenewCondition3);

                    //------------------Write People table grid details in the text file------------------------
                    string QuerPeople = "SELECT people_id , title , forename , middle_name , surname , sex , residence_permit_no , residence_issue_loc , deedmark_no ,  printed ," +
                    " label_print_count , card_print_count , picture , directory , notes , cerpac_no , cerpac_file_no , cerpac_receipt_date , cerpac_expiry_date , registration_area ," +
                    " registration_code , file_no , label_no , book_no , passport_no , nationality , passport_issue_date , passport_expiry_date , passport_issue_loc , passport_issue_by ," +
                    " date_of_birth , place_of_birth , nigeria_add_1 , nigeria_add_2 , nigeria_tel_no , abroad_add_1 , abroad_add_2 , abroad_tel_no , company , company_add_1 ," +
                    " company_add_2  , designation , employment_date , company_tel_no , company_fax_no , email , date_added , added_by_user_id , date_modified , modified_by_user_id ," +
                    " picture_taken , picture_by_user_id , verid_template , verid_template_1 , arcanet_2d_command , date_system_modified , ContactNo , userImage " +
                    " from people where cerpac_no in ('" + txtCerpacNo_B1.Text.Replace(",", "','") + "')";

                    dtCerpac = objgenenral.FetchData(QuerPeople);
                    for (int i = 0; i <= dtCerpac.Rows.Count - 1; i++)
                    {
                        //--------------------Convert Byte[] to baser64 String ----------------------
                        //byte[] barrImg = (byte[])dt.Rows[0]["userimage"];
                        byte[] barrImg = (byte[])dtCerpac.Rows[i].ItemArray[57];

                        MemoryStream mstream = new MemoryStream(barrImg);
                        System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(mstream);
                        MemoryStream imageStream = new MemoryStream();

                        bmp.Save(imageStream, ImageFormat.Jpeg);

                        string imageString = Convert.ToBase64String(imageStream.ToArray());
                        //---------------------------------------------------------------------------


                        txtPeopleCondition3 = txtPeopleCondition3 + dtCerpac.Rows[i].ItemArray[0].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[1].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[2].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[3].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[4].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[5].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[6].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[7].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[8].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[9].ToString().Trim() + "\t"
                              + dtCerpac.Rows[i].ItemArray[10].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[11].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[12].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[13].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[14].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[15].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[16].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[17].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[18].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[19].ToString().Trim() + "\t"
                              + dtCerpac.Rows[i].ItemArray[20].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[21].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[22].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[23].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[24].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[25].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[26].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[27].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[28].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[29].ToString().Trim() + "\t"
                              + dtCerpac.Rows[i].ItemArray[30].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[31].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[32].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[33].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[34].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[35].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[36].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[37].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[38].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[39].ToString().Trim() + "\t"
                              + dtCerpac.Rows[i].ItemArray[40].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[41].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[42].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[43].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[44].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[45].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[46].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[47].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[48].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[49].ToString().Trim() + "\t"
                              + dtCerpac.Rows[i].ItemArray[50].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[51].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[52].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[53].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[54].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[55].ToString().Trim() + " \t " + dtCerpac.Rows[i].ItemArray[56].ToString().Trim() + " \t " + imageString + "-Cond3-";
                         
                    }
                    s.WriteLine(txtPeopleCondition3);
                }

                    //-------------------Hold Form no----------------
                    for (int i = 0; i <= grd_display_data.Rows.Count - 1; i++)
                    {
                        SqlConnection Connection = new SqlConnection();
                        Connection.ConnectionString = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;

                        SqlCommand Command = new SqlCommand("update uploaded_excel_data set cerpacno='" + lblZonename.Text.Trim() + "' where formno = '" + grd_display_data.Rows[i].Cells[8].Text.Trim() + "'", Connection);
                        Connection.Open();
                        Command.ExecuteNonQuery();
                        Connection.Close();
                    }
                    //-----------Convert date formate ()-------------
                    var culture = System.Globalization.CultureInfo.CurrentCulture;

                    string sysFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                    string[] formats = { "M/d/yyyy", "M/dd/yyyy", "MM/dd/yyyy", "M/d/yy", "M/dd/yy", "MM/dd/yy",
                                              "M-d-yyyy", "M-dd-yyyy", "MM-dd-yyyy", "M-d-yy", "M-dd-yy", "MM-dd-yy",
                                             "d/M/yyyy", "dd/M/yyyy", "dd/MM/yyyy", "d/M/yy", "dd/M/yy", "dd/MM/yy",
                                             "d-M-yyyy", "dd-M-yyyy", "dd-MM-yyyy", "d-M-yy", "dd-M-yy", "dd-MM-yy",
                                             "d-MMM-yy", "dd-MMM-yy", "d-MMMM-yyyy","dd-MMMM-yyyy", };
                    DateTime date;
                    if (DateTime.TryParseExact(DateTime.Now.ToShortDateString(), formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                        date.ToString(sysFormat);

                    //-------------------Update Audit trail form no. details----------------
                    for (int i = 0; i <= grd_display_data.Rows.Count - 1; i++)
                    {
                        SqlConnection Connection = new SqlConnection();
                        Connection.ConnectionString = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;

                        SqlCommand Command = new SqlCommand("update uploaded_excel_data_C set bank_flag=1, bank_resp_userid ='" + UserID.ToString().Trim() + "', bank_resp_date='" + date.ToString(sysFormat) + "' where formno = '" + grd_display_data.Rows[i].Cells[8].Text.Trim() + "'", Connection);
                        Connection.Open();
                        Command.ExecuteNonQuery();
                        Connection.Close();
                    }
                    dtform = null;
                    
                

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
                objgenenral = null;
            }
            
           // s.WriteLine(compdata);
         
            s.Dispose();
        }
        if (File.Exists(Path.Combine(filePath, filePath + @"\" + xmlfilename.ToString().Trim())))
        {
            //Get the Input File Name and Extension.
            string fileName = Path.GetFileNameWithoutExtension(filePath + @"\" + xmlfilename.ToString().Trim());
            string fileExtension = Path.GetExtension(filePath + @"\" + xmlfilename.ToString().Trim());

            //Build the File Path for the original (input) and the encrypted (output) file.
            string input = filePath + @"\" + fileName + fileExtension;
            string output = filePath + @"\" + fileName + "_enc" + fileExtension;

            //Save the Input File, Encrypt it and save the encrypted file in output path.
           this.Encrypt(input, output);

           //----------------Create File on client-------------
           txtfilename.Value = xmlfilename.ToString().Trim();
          
           File.Delete(input);

           System.IO.FileStream fs = null;
           fs = System.IO.File.Open(output, System.IO.FileMode.Open);
           byte[] btFile = new byte[fs.Length];
           fs.Read(btFile, 0, Convert.ToInt32(fs.Length));
           fs.Close();           
          
           File.Delete(output);

           Response.AddHeader("Content-disposition", "attachment; filename=" + xmlfilename);
           Response.ContentType = "application/octet-stream";
           Response.BinaryWrite(btFile);
           Response.End();
          
            //Response.End();
        }
        
    }

    private void Encrypt(string inputFilePath, string outputfilePath)
    {
        string EncryptionKey = "MAKV2SPBNI99212";
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (FileStream fsOutput = new FileStream(outputfilePath, FileMode.Create))
            {
                using (CryptoStream cs = new CryptoStream(fsOutput, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    using (FileStream fsInput = new FileStream(inputFilePath, FileMode.Open))
                    {
                        int data;
                        while ((data = fsInput.ReadByte()) != -1)
                        {
                            cs.WriteByte((byte)data);
                        }
                    }
                }
            }
        }
    }

    public void BindFrom(string txtfrom)
    {
        String source = txtfrom;
        int count = 0;



        int AO = Regex.Matches(source, "AO").Count;
        int AR = Regex.Matches(source, "AR").Count;
        int CR = Regex.Matches(source, "CR").Count;
        int NG = Regex.Matches(source, "NG").Count;




        //lblTotalRequest.Text = count.ToString();
        count = (AO + AR + CR + NG);
        lblTotalRequest.Text = count.ToString();

        //---------------------------------------Total Form found in database-------------------------------------

        objgenenral = new BaseLayer.General_function();
        string QuerCountFound = "select count(*) from uploaded_excel_data where formno in ('" + txtfrom.Replace(",", "','").Trim() + "')";
        try
        {
            DataTable dt = new DataTable();
            dt = objgenenral.FetchData(QuerCountFound);
            if (dt.Rows.Count > 0)
            {
                lblFoundinDatabae.Text = dt.Rows[0][0].ToString();

                //tr45.Style.Add("display", "");
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

        //------------------------total already used form in bank database------------------------=

        string QuerCountUsedFound = "select count(*) from uploaded_excel_data where formno in ('" + txtfrom.Replace(",", "','").Trim() + "') and isnull(CerpacNo, '')<>''";

        try
        {
            DataTable dt = new DataTable();
            dt = objgenenral.FetchData(QuerCountUsedFound);
            if (dt.Rows.Count > 0)
            {
                lblAlreadyUsedForm.Text = dt.Rows[0][0].ToString();

                //tr45.Style.Add("display", "");
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

        //--------------------------total free form no.'s for issue to request location--------------------------------
        string QuerCountFreeFound = "select count(*) from uploaded_excel_data where formno in ('" + txtfrom.Replace(",", "','").Trim() + "') and isnull(CerpacNo, '')=''";

        try
        {
            DataTable dt = new DataTable();
            dt = objgenenral.FetchData(QuerCountFreeFound);
            if (dt.Rows.Count > 0)
            {
                lblFreeForm.Text = dt.Rows[0][0].ToString();


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
        //---------------------------------------------------check audit trail---------------------------------------------------

        //-----------Convert date formate ()-------------
        var culture = System.Globalization.CultureInfo.CurrentCulture;

        string sysFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
        string[] formats = { "M/d/yyyy", "M/dd/yyyy", "MM/dd/yyyy", "M/d/yy", "M/dd/yy", "MM/dd/yy",
                                              "M-d-yyyy", "M-dd-yyyy", "MM-dd-yyyy", "M-d-yy", "M-dd-yy", "MM-dd-yy",
                                             "d/M/yyyy", "dd/M/yyyy", "dd/MM/yyyy", "d/M/yy", "dd/M/yy", "dd/MM/yy",
                                             "d-M-yyyy", "dd-M-yyyy", "dd-MM-yyyy", "d-M-yy", "dd-M-yy", "dd-MM-yy",
                                             "d-MMM-yy", "dd-MMM-yy", "d-MMMM-yyyy","dd-MMMM-yyyy", };
        DateTime date;
        if (DateTime.TryParseExact(DateTime.Now.ToShortDateString(), formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            date.ToString(sysFormat);
        //---------------Audit trail in bank request formno.'s---------------------

        String src = txtfrom.Trim();
        string[] stringSeparators = new string[] { "," };
        var result = src.Split(stringSeparators, StringSplitOptions.None);
        int loop = 0;
        string AlreadyReq = "";
        for (int i = 0; i <= result.Count() - 1; i++)
        {
            string formno = result[i].ToString().Trim();
            result[i] = formno;
            if (result[i].ToString().Substring(0, 2).Trim() == "AO" || result[i].ToString().Substring(0, 2).Trim() == "AR" || result[i].ToString().Substring(0, 2).Trim() == "CR" || result[i].ToString().Substring(0, 2).Trim() == "NG")
            {
                //-----------------Search in Bank tracking table--------------------
                ObjGenBal = new BaseLayer.General_function();
                //string QuerAudit = "select count(*) from uploaded_excel_data_C where  Formno='" + result[i].ToString().Trim() + "' and isnull(final_flag, '')=''";
                string QuerAudit = "select count(*) from uploaded_excel_data_C where  Formno='" + result[i].ToString().Trim() + "'";

                DataTable dt = new DataTable();
                dt = ObjGenBal.FetchData(QuerAudit);
                if (dt.Rows[0].ItemArray[0].ToString() == "0")
                {

                    //--------------------------Insert--------------------------------   

                    SqlConnection Connection = new SqlConnection();
                    Connection.ConnectionString = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;

                    SqlCommand Command = new SqlCommand("Insert into uploaded_excel_data_C (FormNo,bank_req_userid,bank_req_date,zone_name) Values( '" + result[i].ToString().Trim() + "','" + UserID.ToString().Trim() + "','" + date.ToString(sysFormat) + "', '" + lblZonename.Text + "')", Connection);
                    Connection.Open();
                    Command.ExecuteNonQuery();
                    Connection.Close();
                    NewReq = NewReq + result[i].ToString().Trim() + " ";
                }
                else
                {
                    AlreadyReq = AlreadyReq + result[i].ToString().Trim() + " ";
                }

            }
            else
            {
                loop++;
            }

        }
        if (loop > 0)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('We found " + loop + " worng form no in textbox .');", true);

        }
        if (AlreadyReq != "")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Already requested form no :" + AlreadyReq.Trim().Replace(" ", ",") + ".');", true);

        }

        //-------------------Bind datagrid with free form no.'s only for genrate encrypt respons file ----------------------------

        try
        {
            if (lblFreeForm.Text.Trim() != "0")
            {
                string quer = "select Convert(varchar(10),Date1,103) as Date1, FirstName, MiddleName, LastName, Company, Nationality, RequisitionNo, FormNo, CerpacNo, PassportNo, isnull(StrVisaNo,'') as StrVisaNo,tellerno,amount from uploaded_excel_data where formno in ('" + txtfrom.Replace(",", "','").Trim() + "') and isnull(CerpacNo, '')=''  order by FirstName";




                DivCase1.Visible = false;
                DivCase2.Visible = false;
                DivCase3.Visible = false;
                divReadFile.Visible = false;
                
                dtform = objgenenral.FetchData(quer);
                if (dtform.Rows.Count > 0)
                {
                    grd_display_data.DataSource = dtform;
                    grd_display_data.DataBind();

                    divSearchResult.Visible = true;
                    divSearchCerpac.Visible = false;
                    divgrd.Visible = true;
                    divgrdCerpac.Visible = false;
                    divCrefile.Visible = true;
                  

                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Requested form no.'s already used.');", true);


            }
            dtform = null;
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
            objgenenral = null;
        }
    }

    public void BindCerpac(string txtCerpacNo)
    {
        String source = txtCerpacNo;
        int count = 0;



        int AO = Regex.Matches(source, "AO").Count;
        int AR = Regex.Matches(source, "AR").Count;
        int CR = Regex.Matches(source, "CR").Count;
        int NG = Regex.Matches(source, "NG").Count;






        //lblTotalRequest.Text = count.ToString();
        count = (AO + AR + CR + NG);
        lblTotalRequest.Text = count.ToString();

        //-------------------Bind datagrid with free form no.'s only for genrate encrypt respons file ----------------------------

        try
        {
            if (lblFreeForm.Text.Trim() != "0")
            {
            objgenenral = new BaseLayer.General_function();

            string quer = "Select a.forename, a.middle_name,  a.surname, a.sex, a.cerpac_no, a.cerpac_file_no,  Convert(varchar(10),a.cerpac_receipt_date,103) as cerpac_receipt_date, Convert(varchar(10),a.cerpac_expiry_date,103) as cerpac_expiry_date,  a.passport_no, a.nationality, b.company,a.designation  from people a, compmaster b where a.company=b.regno and  a.cerpac_no in ('" + txtCerpacNo.Replace(",", "','").Trim() + "') order by a.forename";



            DivCase1.Visible = false;
            DivCase2.Visible = false;
            DivCase3.Visible = false;
            divReadFile.Visible = false;
              
                dtCerpac = objgenenral.FetchData(quer);
                if (dtCerpac.Rows.Count > 0)
                {
                    grd_CerpacNo.DataSource = dtCerpac;
                    grd_CerpacNo.DataBind();

                  
                    divSearchCerpac.Visible = true;                   
                    divgrdCerpac.Visible = true;
                  

                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Requested form no.'s already used.');", true);


            }
            dtform = null;
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
            objgenenral = null;
        }
    }

    protected void btnFreshCase_Click(object sender, EventArgs e)
    {
        BindFrom(txtFormNo_Z1.Text);
       
       // divCrefile.Visible = true;
           
       
    }
    protected void btnRenewCase_Click(object sender, EventArgs e)
    {
        BindFrom(txtFormNo_R1.Text);
        BindCerpac(txtCerpacno_R1.Text);
        
       // divCrefile.Visible = true;
    }
    protected void btnbothCase_Click(object sender, EventArgs e)
    {
        BindFrom(txtFormNo_B1.Text + "," + txtFormNo_B2.Text );
        BindCerpac( txtCerpacNo_B1.Text);
       // divCrefile.Visible = true;

        
    }
}