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


public partial class Admin_frmGenrateFreeFormFile : System.Web.UI.Page
{
    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    BaseLayer.General_function objgenenral = null;
    protected DataSet objDs = new DataSet();
    protected DataTable dt = new DataTable();
    protected DataTable dtform = new DataTable();
    
    protected BaseLayer.General_function ObjGenBal = null;
    string AppID = "",  FormNotxt = "";                       
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
                divSearchResult.Visible = true;
                divgrd.Visible = true;
                divCrefile.Visible = true;
                lblZonename.Text = ZoneDetails;
                BindGird();
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
                string quer = "Select FormNo From uploaded_excel_data_C where bank_flag=1 and flag1=1 and isnull(final_flag,0) =0";
                    dtform = objgenenral.FetchData(quer);
                    if (dtform.Rows.Count > 0)
                        {
                        grd_display_data.DataSource = dtform;
                        grd_display_data.DataBind();

                                      
                        for (int i = 0; i < dtform.Rows.Count; i++)
                        {
                            FormNotxt = FormNotxt + dtform.Rows[i].ItemArray[0].ToString() + ",";

                        }
                        ViewState["FRNList"] = FormNotxt;

                        int AO = Regex.Matches(FormNotxt.ToString(), "AO").Count;
                        int AR = Regex.Matches(FormNotxt.ToString(), "AR").Count;
                        int CR = Regex.Matches(FormNotxt.ToString(), "CR").Count;
                        int NG = Regex.Matches(FormNotxt.ToString(), "NG").Count;


                        lblAOCerpacNo.Text = AO.ToString();
                        lblARCerpacNo.Text = AR.ToString();
                        lblCRCerpacNo.Text = CR.ToString();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Waiting for free the bank form : Nil !! .');", true);

                        dtform = null;
                        divgrd.Visible = false;
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
            dtform = null;
            dt = null;
            objgenenral = null;
        }


    }
    protected void btnEncrypt_Click(object sender, EventArgs e)
    {
        try
        {
            string xmlfilename = "default.xml";

            string foldername = "FBF -" + ZoneDetails + "-" + DateTime.Now.ToString().Replace("/", "").Replace(":", "");
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            filePath = filePath + @"\";

            if (lblAOCerpacNo.Text != "0" || lblARCerpacNo.Text != "0" || lblCRCerpacNo.Text != "0")
            {

                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                //------------Free Bank Form no -------------------------------
                xmlfilename = ZoneDetails.Trim().ToString() + "-FBF-" + DateTime.Now.Date.ToString("dd/MM/yyyy").Replace("/", "").Replace(":", "") + "-" + DateTime.Now.ToLocalTime().ToLongTimeString().Replace(" ", "").Replace(":", ".") + ".xml";


                if (File.Exists(Path.Combine(filePath, filePath + @"\" + xmlfilename.ToString().Trim())))
                {
                    File.Delete(Path.Combine(filePath, filePath + @"\" + xmlfilename.ToString().Trim()));
                }

                System.IO.StreamWriter s = File.CreateText(System.IO.Path.Combine(filePath, filePath + @"\" + xmlfilename.ToString().Trim()));


                //------------------Write Form no in the text file--------------
                s.WriteLine("ZoneName \t" + ZoneDetails);
                s.WriteLine("Case \t" + 4);
                s.WriteLine("FreeFormNo \t" + ViewState["FRNList"].ToString().Trim());



                //----------------------Delete Form no by Uploaded_Excel_Data_C--------------------------------------


                if (File.Exists(Path.Combine(filePath, filePath + @"\" + xmlfilename.ToString().Trim())))
                {
                  
                    SqlConnection Connection = new SqlConnection();
                    Connection.ConnectionString = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;

                    SqlCommand Command = new SqlCommand("Delete From uploaded_excel_data_C where bank_flag=1 and flag1=1 and isnull(final_flag,0)=0", Connection);
                    Connection.Open();
                    Command.ExecuteNonQuery();
                    Connection.Close();

                   
                }


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



                //------------------Create Encrypted File for Client----------------
                File.Delete(input);

                System.IO.FileStream fs = null;
                fs = System.IO.File.Open(output, System.IO.FileMode.Open);
                byte[] btFile = new byte[fs.Length];
                fs.Read(btFile, 0, Convert.ToInt32(fs.Length));
                fs.Close();
                
                File.Delete(output);
                Response.AddHeader("Content-disposition", "attachment; filename=" + xmlfilename.ToString().Trim());
                Response.ContentType = "application/octet-stream";
                Response.BinaryWrite(btFile);
                Response.End();


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



    
}