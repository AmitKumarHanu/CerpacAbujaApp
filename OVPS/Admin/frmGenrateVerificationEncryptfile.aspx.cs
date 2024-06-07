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


public partial class Admin_frmGenrateVerificationEncryptfile : System.Web.UI.Page
{
    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    BaseLayer.General_function objgenenral = null;
    protected DataSet objDs = new DataSet();
    protected DataTable dt = new DataTable();
    protected DataTable dtform = new DataTable();
    protected DataTable dtconfim_1 = new DataTable();
    protected DataTable dtconfim_2 = new DataTable();
    protected DataTable dtconfim_3 = new DataTable();


    protected DataTable dtDeny = new DataTable();
    protected DataTable dtConfimred = new DataTable();
    protected DataTable dtReject = new DataTable();
   
    protected BaseLayer.General_function ObjGenBal = null;
    string AppID = "", Cerptxt = "", CerpFiletxt = "", formnotxt_1="", formnotxt_2="", formnotxt_3="";                       
    string UserID = null, ZoneDetails=null;
    Label LabelMessage = null ;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        if (objectSessionHolderPersistingData == null)
        {
            Response.Redirect("../Login.aspx");
        }
        LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");

        UserID = objectSessionHolderPersistingData.User_ID.ToString();

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
                ZoneDetails = dt.Rows[0]["ZoneName"].ToString();
            }
            if (!IsPostBack)
            {
                divgrd.Visible = false;
                divCrefile.Visible = false;
                divSearchResult.Visible = false;
                DivZonelist.Visible = true;

                bindZonelist();
               
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


    protected void bindZonelist()
    {

        try
        {
            objgenenral = new BaseLayer.General_function();


            string QrybindZonelist = "Select * from zonemaster order by zonename";
            objgenenral.Fill_DDL(cmdZoneList, QrybindZonelist, "zonename", "zonecode");



        }
        catch (Exception ex)
        {
            objgenenral = new BaseLayer.General_function();
            string err = objgenenral.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.CssClass = "warning-box";
            LabelMessage.Visible = true;
        }
        finally
        {
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
    
    
    protected void BindGird()
    {
        try
        {
            

                objgenenral = new BaseLayer.General_function();
                 // string quer = "Select Distinct( a.cerpac_no) as dist , a.forename ,a.middle_name ,a.surname  ,a.cerpac_no ,a.cerpac_file_no ,Convert(varchar(11), a.cerpac_receipt_date, 103) as cerpac_receipt_date , Convert(varchar(11), a.cerpac_expiry_date, 103) as cerpac_expiry_date, a.passport_no , a.nationality ,Convert(varchar(11), a.date_of_birth, 103) as date_of_birth ,a.place_of_birth ,c.company, a.designation From people a, PeopleChild b, CompMaster c  where a.cerpac_file_no= b.FORMNO and a.cerpac_no=b.CerpacNo and a.company=c.regno and b.IsVerified=1 and b.IsAuthorized=1 and isnull(b.ISARCR,0)=1 and (b.IsProduced<>4 or b.isProduced is null or b.isProduced=0) and (b.isqual is null or b.IsQual=0) and isnull( b.IsRejected,0 )=0 and a.cerpac_file_no not in (Select formno from uploaded_excel_data_C where isnull (final_flag,0)=2)";
                string quer = "Select Distinct( a.cerpac_no) as dist , a.forename ,a.middle_name ,a.surname  ,a.cerpac_no ,a.cerpac_file_no ,Convert(varchar(11), a.cerpac_receipt_date, 103) as cerpac_receipt_date , Convert(varchar(11), a.cerpac_expiry_date, 103) as cerpac_expiry_date, a.passport_no , a.nationality ,Convert(varchar(11), a.date_of_birth, 103) as date_of_birth ,a.place_of_birth ,c.company, a.designation From people a, PeopleChild b, CompMaster c, userzonerelation d where a.cerpac_file_no= b.FORMNO and a.cerpac_no=b.CerpacNo and a.company=c.regno and b.IsVerified=1 and isnull(b.IsAuthorized,0)=1 and isnull(b.ISARCR,0)=1 and (b.IsProduced<>4 or b.isProduced is null or b.isProduced=0 or b.isProduced=' ') and (b.isqual is null or b.IsQual=0) and isnull( b.IsRejected,0 )=0 and  b.VerifiedBy= d.UserId and b.CerpacNo in (select cerpac_no from tbl_confirm_eligibility_offline where isnull( confirmres,0)=0 and isnull( confirmreq,0)=1 and isnull( confm_flag,0)<>0)  and d.ZoneCode='"+ cmdZoneList.SelectedValue +"'";
              
                    dtform = objgenenral.FetchData(quer);
                    if (dtform.Rows.Count > 0)
                    {



                        grd_display_data.DataSource = dtform;
                        grd_display_data.DataBind();

                        for (int i = 0; i < dtform.Rows.Count; i++)
                        {
                            Cerptxt = Cerptxt + dtform.Rows[i].ItemArray[0].ToString() + ",";

                        }
                
                        for (int i = 0; i < dtform.Rows.Count; i++)
                        {
                            CerpFiletxt = CerpFiletxt + dtform.Rows[i].ItemArray[5].ToString() + ",";

                        }
                        ViewState["CerpacList"] = Cerptxt;
                        ViewState["FRNList"] = CerpFiletxt;


                      

                        //---------------------Confirm flag =1-------------------------------
                        string confim_flag_1 = "Select form_no from tbl_confirm_eligibility_offline where isnull( confirmres,0)=0 and isnull( confirmreq,0)=1 and isnull( confm_flag,0)=1 and zonename='" + lblZonename.Text.Trim() + "'";

                        dtconfim_1 = objgenenral.FetchData(confim_flag_1);
                        if (dtconfim_1.Rows.Count > 0)
                        {
                            for (int i = 0; i < dtconfim_1.Rows.Count; i++)
                            {
                                formnotxt_1 = formnotxt_1 + dtconfim_1.Rows[i].ItemArray[0].ToString() + ",";

                            }
                        }

                        //---------------------Confirm flag =2-----------------------------
                        string confim_flag_2 = "Select form_no from tbl_confirm_eligibility_offline where isnull( confirmres,0)=0 and isnull( confirmreq,0)=1 and isnull( confm_flag,0)=2 and zonename='" + lblZonename.Text.Trim() + "'";

                        dtconfim_2 = objgenenral.FetchData(confim_flag_2);
                        if (dtconfim_2.Rows.Count > 0)
                        {
                            for (int i = 0; i < dtconfim_2.Rows.Count; i++)
                            {
                                formnotxt_2 = formnotxt_2 + dtconfim_2.Rows[i].ItemArray[0].ToString() + ",";

                            }
                        }

                        //---------------------Confirm flag =3-----------------------------------
                        string confim_flag_3 = "Select form_no from tbl_confirm_eligibility_offline where isnull( confirmres,0)=0 and isnull( confirmreq,0)=1 and isnull( confm_flag,0)=3 and zonename='" + lblZonename.Text.Trim() + "'";

                        dtconfim_3 = objgenenral.FetchData(confim_flag_3);
                        if (dtconfim_3.Rows.Count > 0)
                        {
                            for (int i = 0; i < dtconfim_3.Rows.Count; i++)
                            {
                                formnotxt_3 = formnotxt_3 + dtconfim_3.Rows[i].ItemArray[0].ToString() + ",";

                            }
                        }

                        ViewState["Confirm_flag_1"] = formnotxt_1;
                        ViewState["Confirm_flag_2"] = formnotxt_2;
                        ViewState["Confirm_flag_3"] = formnotxt_3;

                       

                        lblTotalResponse.Text = Convert.ToString( Convert.ToInt32(dtconfim_1.Rows.Count) + Convert.ToInt32(dtconfim_2.Rows.Count) + Convert.ToInt32(dtconfim_3.Rows.Count));
                        lblComfirmed.Text = Convert.ToInt32(dtconfim_1.Rows.Count).ToString();
                        lblReject.Text = Convert.ToInt32(dtconfim_2.Rows.Count).ToString();
                        lblDeny.Text = Convert.ToInt32(dtconfim_3.Rows.Count).ToString();

                        ViewState["TotalResponse"] = lblTotalResponse.Text.Trim();
                        ViewState["Comfirmed"] = lblComfirmed.Text.Trim();
                        ViewState["Reject"] = lblReject.Text.Trim();
                        ViewState["Deny"] = lblDeny.Text.Trim();



                        if (Convert.ToInt32(lblTotalResponse.Text) >= 0)
                        {
                            divgrd.Visible = true;
                        }

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Waiting for  genrate encrypted file after Contec Verification records : Nil !! .');", true);

                        dtform = null;
                        divgrd.Visible = false;
                        divCrefile.Visible = false;
                        //Response.Redirect("frmGenrateConsolidateEncryptfile.aspx");
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

    public string datep(string date)
    {
        string sysf = "dd-MM-yyyy";

        if (date.Trim() == null || date.Trim() == string.Empty)
        {
            return "";
        }

        if (DateTimeFormatInfo.CurrentInfo.ShortDatePattern.ToCharArray()[0].ToString() == "d")
        {
            sysf = "MM-dd-yyyy";
            return DateTime.Parse(date).ToString(sysf);
        }

       // else  if (DateTimeFormatInfo.CurrentInfo.ShortDatePattern.ToCharArray()[0].ToString() == "M")




        else

            return DateTime.Parse(date).ToString();

    }

    protected void btnEncrypt_Click(object sender, EventArgs e)
    {
        
        string xmlfilename = "default.xml";

        string foldername = "CNF-" + lblZonename.Text + "-" + DateTime.Now.ToString().Replace("/", "").Replace(":", "");
        string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        filePath = filePath + @"\";

        string filePath1 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        filePath1 = filePath1 + @"\";

        if (lblTotalResponse.Text != "0")
        {

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            //------------Process Request for Production-------------------------------
            xmlfilename = lblZonename.Text.Trim().ToString() + "-CNF-" + DateTime.Now.Date.ToString("dd/MM/yyyy").Replace("/", "").Replace(":", "") + "-" + DateTime.Now.ToLocalTime().ToLongTimeString().Replace(" ", "").Replace(":", ".") + ".xml";


            if (File.Exists(Path.Combine(filePath, filePath + @"\" + xmlfilename.ToString().Trim())))
            {
                File.Delete(Path.Combine(filePath, filePath + @"\" + xmlfilename.ToString().Trim()));
            }

            System.IO.StreamWriter s = File.CreateText(System.IO.Path.Combine(filePath, filePath + @"\" + xmlfilename.ToString().Trim()));

            System.IO.StreamWriter s1 = File.CreateText(System.IO.Path.Combine(filePath1, filePath1 + @"\" + xmlfilename.ToString().Trim()));

            objgenenral = new BaseLayer.General_function();
             
            try
            {
               
                //------------------Write textbox serach result in the text file--------------
                s.WriteLine("ZoneName \t" + lblZonename.Text.Trim() + " \t " + ViewState["TotalResponse"].ToString().Trim() + " \t " + ViewState["Comfirmed"].ToString().Trim() + " \t " + ViewState["Reject"].ToString().Trim() + " \t " + ViewState["Deny"].ToString().Trim());
                s.WriteLine("FormNo_1 \t" + ViewState["Confirm_flag_1"].ToString().Trim());
                s.WriteLine("FormNo_2 \t" + ViewState["Confirm_flag_2"].ToString().Trim());
                s.WriteLine("FormNo_3 \t" + ViewState["Confirm_flag_3"].ToString().Trim());

                //---------------------Confirmed Form no's---------------------------------------------
                string txtConfimred = "-###-";
                string QurConfimred = "SELECT   [cerpac_no],[form_no],[zonename],[confirmres],[confirmresdate],[userid],[confm_flag],[ConfirmBy],[ConfirmOn]  from tbl_confirm_eligibility_offline where  form_no in ('" + ViewState["Confirm_flag_1"].ToString().Trim().Replace(",", "','") + "')";

                dtConfimred = objgenenral.FetchData(QurConfimred);

                for (int i = 0; i <= dtConfimred.Rows.Count - 1; i++)
                {
                    txtConfimred = txtConfimred + dtConfimred.Rows[i].ItemArray[0].ToString().Trim() + " \t " + dtConfimred.Rows[i].ItemArray[1].ToString().Trim() + " \t " + dtConfimred.Rows[i].ItemArray[2].ToString().Trim() + " \t " + dtConfimred.Rows[i].ItemArray[3].ToString().Trim() + " \t " + datep(dtConfimred.Rows[i].ItemArray[4].ToString().Trim()) + " \t "
                    + dtConfimred.Rows[i].ItemArray[5].ToString().Trim() + " \t " + dtConfimred.Rows[i].ItemArray[6].ToString().Trim() + " \t " + dtConfimred.Rows[i].ItemArray[7].ToString().Trim() + " \t " + datep(dtConfimred.Rows[i].ItemArray[8].ToString().Trim()) + " \t " +  "-###-";
                    
                }
                s.WriteLine(txtConfimred.Replace(",", " "));


                //---------------------Reject Form no's---------------------------------------------
                string txtReject = "-###-";
                string QurReject = "SELECT   [cerpac_no],[form_no],[zonename],[confirmres],[confirmresdate],[userid],[confm_flag],[ConfirmBy],[ConfirmOn] from tbl_confirm_eligibility_offline where form_no in ('" + ViewState["Confirm_flag_2"].ToString().Trim().Replace(",", "','") + "')";

                dtReject = objgenenral.FetchData(QurReject);

                for (int i = 0; i <= dtReject.Rows.Count - 1; i++)
                {
                    txtReject = txtReject + dtReject.Rows[i].ItemArray[0].ToString().Trim() + " \t " + dtReject.Rows[i].ItemArray[1].ToString().Trim() + " \t " + dtReject.Rows[i].ItemArray[2].ToString().Trim() + " \t " + dtReject.Rows[i].ItemArray[3].ToString().Trim() + " \t " + datep(dtReject.Rows[i].ItemArray[4].ToString().Trim()) + " \t "
                    + dtReject.Rows[i].ItemArray[5].ToString().Trim() + " \t " + dtReject.Rows[i].ItemArray[6].ToString().Trim() + " \t " + dtReject.Rows[i].ItemArray[7].ToString().Trim() + " \t " + datep(dtReject.Rows[i].ItemArray[8].ToString().Trim()) + " \t " + "-###-";

                }
                s.WriteLine(txtReject.Replace(",", " "));


                //---------------------Deny Form no's---------------------------------------------
                string txtDeny = "-###-";
                string QurDeny = "SELECT   [cerpac_no],[form_no],[zonename],[confirmres],[confirmresdate],[userid],[confm_flag],[ConfirmBy],[ConfirmOn]  from tbl_confirm_eligibility_offline where  form_no in ('" + ViewState["Confirm_flag_3"].ToString().Trim().Replace(",", "','") + "')";

                dtDeny = objgenenral.FetchData(QurDeny);

                for (int i = 0; i <= dtDeny.Rows.Count - 1; i++)
                {
                    txtDeny = txtDeny + dtDeny.Rows[i].ItemArray[0].ToString().Trim() + " \t " + dtDeny.Rows[i].ItemArray[1].ToString().Trim() + " \t " + dtDeny.Rows[i].ItemArray[2].ToString().Trim() + " \t " + dtDeny.Rows[i].ItemArray[3].ToString().Trim() + " \t " + datep(dtDeny.Rows[i].ItemArray[4].ToString().Trim()) + " \t "
                    + dtDeny.Rows[i].ItemArray[5].ToString().Trim() + " \t " + dtDeny.Rows[i].ItemArray[6].ToString().Trim() + " \t " + dtDeny.Rows[i].ItemArray[7].ToString().Trim() + " \t " + datep(dtDeny.Rows[i].ItemArray[8].ToString().Trim()) + " \t " + "-###-";

                }
                s.WriteLine(txtDeny.Replace(",", " "));


                s.Dispose();
                 

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
         
            //s.Dispose();
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


        //---------------Audit trail in confimaton flag formno.'s---------------------

        String source = ViewState["Confirm_flag_1"].ToString().Trim() + ',' + ViewState["Confirm_flag_2"].ToString().Trim() + ',' + ViewState["Confirm_flag_3"].ToString().Trim();
        string[] stringSeparators = new string[] { "," };
        var result = source.Split(stringSeparators, StringSplitOptions.None);

        int loop = 0, Req=0;
       

        for (int i = 0; i < result.Count() - 1; i++)
        {
            string formno = result[i].ToString().Trim();
            result[i] = formno;
            if (formno != "")
            {
                if (result[i].ToString().Substring(0, 2).Trim() == "AO" || result[i].ToString().Substring(0, 2).Trim() == "AR" || result[i].ToString().Substring(0, 2).Trim() == "CR" || result[i].ToString().Substring(0, 2).Trim() == "NG")
                {
                    //-----------------Search in Upload excel data C table--------------------
                    ObjGenBal = new BaseLayer.General_function();
                    string QuerCountFound = "select count(*) from tbl_confirm_eligibility_offline where confirmreq=1 and confirmres=0 and  Form_no='" + result[i].ToString().Trim() + "'";

                    DataTable dt = new DataTable();
                    dt = ObjGenBal.FetchData(QuerCountFound);

                    if (dt.Rows[0].ItemArray[0].ToString() != "0")
                    {


                        SqlConnection Connection = new SqlConnection();
                        Connection.ConnectionString = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;

                        SqlCommand Command = new SqlCommand("Update tbl_confirm_eligibility_offline set confirmres=1, confirmresdate=getdate() where form_no ='" + result[i].ToString().Trim() + "'", Connection);
                        Connection.Open();
                        Command.ExecuteNonQuery();
                        Connection.Close();



                    }
                    Req++;
                }
            }
            else  if (formno != "")            
            {
                
                loop++;
            }

        }
        if (loop > 0)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('We found " + loop + " worng form no in textbox .'); window.location = '" + Page.ResolveUrl("frmGenrateConsolidateEncryptfile.aspx") + "';", true);
            
      
        }
       
        //----------------------------------------------
        if (Req > 0)
        {
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

                

                //------------------Create Encrypted File for Client----------------
                File.Delete(input);
            
                System.IO.FileStream fs = null;
                fs = System.IO.File.Open(output, System.IO.FileMode.Open);
                byte[] btFile = new byte[fs.Length];
                fs.Read(btFile, 0, Convert.ToInt32(fs.Length));
                fs.Close();
                if (File.Exists(Path.Combine(output)))
                {

                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Request file successfull created on desktop :" + xmlfilename.ToString().Trim() + " .');", true);

                }
                File.Delete(output);
                BindGird();
                Response.AddHeader("Content-disposition", "attachment; filename=" + xmlfilename.ToString().Trim());
                Response.ContentType = "application/octet-stream";
                Response.BinaryWrite(btFile);
                Response.End();

            }
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



    protected void btnDetails_Click(object sender, EventArgs e)
    {
        lblZonename.Text = cmdZoneList.SelectedItem.Text;
        divgrd.Visible = true;
        divCrefile.Visible = true;
        divSearchResult.Visible = true;
        DivZonelist.Visible = false;

        BindGird();
    }
}