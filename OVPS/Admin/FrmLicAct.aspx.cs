using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_FrmLicAct : System.Web.UI.Page
{
    
     #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    BaseLayer.General_function objgenenral = null;
    protected DataSet objDs = new DataSet();
    protected DataTable dt = new DataTable();
   
    protected BaseLayer.General_function ObjGenBal = null;
    string AppID = "";
    string UserID = null, ZoneDetails = null;
    string output, input, Cerptxt = "", CerpFiletxt = "";
    Label LabelMessage = null ;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {

    }

   


   

    protected void DecryptFile(object sender, EventArgs e)
    {
        string foldername = "Decrypt File";
        string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        filePath = filePath + @"\" + foldername;

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

        // Delete the original (input) and the decrypted (output) file.
        File.Delete(input);
        File.Delete(output);



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

    protected void btnUpload_Click(object sender, EventArgs e)
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
            filePath = filePath + @"\";

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }


            //Get the Input File Name and Extension
            string fileName = Path.GetFileNameWithoutExtension(FileUpload1.PostedFile.FileName);
            string fileExtension = Path.GetExtension(FileUpload1.PostedFile.FileName);

            input = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + fileName + fileExtension;
            ViewState["InputFile"] = input;


            output = filePath + @"\" + fileName + "!" + fileExtension;
            ViewState["OutputFile"] = output;

            //Save the Input File, Decrypt it and save the decrypted file in output path.
            this.Decrypt(input, output);
           
            //string Readfile = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + fileName + fileExtension;
            //dstest.ReadXml(filePath);
            string[] lines = System.IO.File.ReadAllLines((output));


            //---------------------------Split Encrypt file ------------------


            String Key = lines[0];
            string[] stringSeparatorsKey = new string[] { "\t" };
            var KeyCount = Key.Split(stringSeparatorsKey, StringSplitOptions.None);

            
            //Delete the original (input) and the decrypted (output) file.
            //File.Delete(input);
            File.Delete(output);

           /****** Script for SelectTopNRows command from SSMS  ******/
            //SELECT [LKey],[LID],[rowguid]FROM [Cerpac].[dbo].[Licensing]
                //-----------------Search in People table--------------------
            
                string ConnectionString = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
                SqlConnection Conn = new SqlConnection(ConnectionString.ToString());

               
                string QuerCountFound = "select count(*) from Licensing where LKey in ('" + KeyCount[1].Trim() + "')";
                SqlCommand cmd = new SqlCommand(QuerCountFound, Conn);
                Conn.Open();
                SqlDataAdapter Adp = new SqlDataAdapter(cmd);
                Adp.SelectCommand.CommandTimeout = 0;
                DataTable dt = new DataTable();
                Adp.Fill(dt);
                Conn.Close();

                if (dt.Rows[0].ItemArray[0].ToString() == "0")
                {
                    //--------------------------Update------------------------------

                    SqlCommand Command = new SqlCommand("update Licensing set LKey ='" + KeyCount[1].Trim() + "' where LID = 1009", Conn);
                    Conn.Open();
                    Command.ExecuteNonQuery();
                    Conn.Close();

                    lblmessage.Text = "Successfull Activated";
                    lblmessage.Visible = true;
                    lblmessage.CssClass = "information-box";
                    lblmessage.Font.Size = FontUnit.Small;
                    lblmessage.Style.Add("text-decoration", "blink");
                }
                else
                {
                    lblmessage.Text = "Please select correct license activation file";
                    lblmessage.Visible = true;
                    lblmessage.CssClass = "information-box";
                    lblmessage.Font.Size = FontUnit.Small;
                    lblmessage.Style.Add("text-decoration", "blink");
                }

            }
        
        catch (Exception ex)
        {
         

        }
        
    }

   
}