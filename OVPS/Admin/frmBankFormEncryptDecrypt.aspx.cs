using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Xml.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml;
using DataAccessLayer;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;


using System.Drawing;


using System.Drawing.Imaging;



public partial class Admin_frmBankFormEncryptDecrypt : System.Web.UI.Page
{
    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    BaseLayer.General_function objgenenral = null;
    protected DataSet objDs = new DataSet();
    protected DataTable dt = new DataTable();

    protected BaseLayer.General_function ObjGenBal = null;
    Label LabelMessage = null;
    string UserID = null, ZoneDetails=null;
    string base64String;
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
                ZoneDetails = dt.Rows[0]["ZoneName"].ToString() ;
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
  
     
protected void EncryptFile(object sender, EventArgs e)
{
    string xmlfilename = "default.xml";
    string foldername = ZoneDetails.Trim().ToString()+"--"+ DateTime.Now.ToShortDateString().Replace("/", "").Replace(":", "");
    //string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
    string filePath = Environment.GetFolderPath(Environment.SpecialFolder .Desktop);
    filePath = filePath + @"\" ;

    if (txtFormNo.Text != "")
    {
        
        if (!Directory.Exists(filePath))
        {
            Directory.CreateDirectory(filePath);
        }
        xmlfilename = ZoneDetails.Trim().ToString() + "--" + DateTime.Now.ToShortDateString().Replace("/", "").Replace(":", "") +".xml";

        if (File.Exists(Path.Combine(filePath, filePath + @"\" + xmlfilename.ToString().Trim())))
        {
            File.Delete(Path.Combine(filePath, filePath + @"\" + xmlfilename.ToString().Trim()));
        }

        System.IO.StreamWriter s = File.CreateText(System.IO.Path.Combine(filePath, filePath + @"\" + xmlfilename.ToString().Trim()));


        string compdata = txtFormNo.Text.Trim().ToString() + "  "+ ZoneDetails.Trim().ToString();
        s.WriteLine(compdata);
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

        File.Delete(input);
        //File.Delete(output);

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

    string input = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) +@"\"+ fileName + fileExtension;
    
     
    string output = filePath + @"\" + fileName + "_dec" + fileExtension;

    //Save the Input File, Decrypt it and save the decrypted file in output path.
    this.Decrypt(input, output);    

    //Delete the original (input) and the decrypted (output) file.
    //File.Delete(input);
    //File.Delete(output);

   
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
//public void desktopfolder()
//{
// string foldername = DateTime.Now.ToString().Replace("/","").Replace(":","");
// string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
// filePath = filePath + @"\"+foldername ;
// //string extension = ".log";
// if (!Directory.Exists(filePath))
// {
//      Directory.CreateDirectory(filePath);
// }
//}
//    public void xmlCreate()
//    {
//        string xmlfilename = "default.xml";
//        string foldername = DateTime.Now.ToString().Replace("/", "").Replace(":", "");
//        string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
//        filePath = filePath + @"\" + foldername;
          
//        if (txtFormNo.Text != "")
//        {
//            //string extension = ".log";
//            if (!Directory.Exists(filePath))
//            {
//                Directory.CreateDirectory(filePath);
//            }
//            xmlfilename = txtFormNo.Text.Trim().ToString() + DateTime.Now.ToBinary() + ".xml";

//            if (File.Exists(Path.Combine(filePath, filePath + @"\" + xmlfilename.ToString().Trim())))
//            {
//                File.Delete(Path.Combine(filePath, filePath + @"\" + xmlfilename.ToString().Trim()));
//            }

//            System.IO.StreamWriter s = File.CreateText(System.IO.Path.Combine(filePath, filePath + @"\" + xmlfilename.ToString().Trim()));


//            string compdata = txtFormNo.Text.Trim().ToString();
//            s.WriteLine(compdata);
//            s.Dispose();
//        }
//        if (File.Exists(Path.Combine(filePath, filePath + @"\" + xmlfilename.ToString().Trim())))
//            {
//                //Get the Input File Name and Extension.
//                string fileName = Path.GetFileNameWithoutExtension(filePath + @"\" + xmlfilename.ToString().Trim());
//                string fileExtension = Path.GetExtension(filePath + @"\" + xmlfilename.ToString().Trim());

//                //Build the File Path for the original (input) and the encrypted (output) file.
//                string input = filePath + @"\" + fileName + fileExtension;
//                string output = filePath + @"\" + fileName + "_enc" + fileExtension;

//                //Save the Input File, Encrypt it and save the encrypted file in output path.
//                //FileUpload1.SaveAs(input);
//                this.Encrypt(input, output);

//                //Download the Encrypted File.
//                //Response.ContentType = FileUpload1.PostedFile.ContentType;
//                //Response.Clear();
//               // Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(output));
//                //Response.WriteFile(output);
//                Response.Flush();

//                //Delete the original (input) and the encrypted (output) file.
//                File.Delete(input);
//                //File.Delete(output);

//                Response.End();
//        }
//    }
//    public void xmlretcomp()
//    {
//        try
//        {
//            if (File .Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"XML\" + txtFormNo.Text.ToString().Trim() + ".xml")))
//            {
//                string xmltext = "";
//                xmltext = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"XML\" + txtFormNo.Text.ToString().Trim() + ".xml"));
//                string val = xmltext.Trim();
//                string[] val1 = val.Split(',');
//                txtFormNo.Text = val1[0].ToString();
               

//                //
//            }
//        }
//        catch (Exception ex)
//        {
//            ObjGenBal = new BaseLayer.General_function();
//            string err = ObjGenBal.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
//            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
//            LabelMessage.CssClass = "warning-box";
//            LabelMessage.Visible = true;
//        }
//        finally
//        {
//            ObjGenBal = null;
//        }
//    }

public void ConvertImagetoBase64()
{
    //StreamResourceInfo sri = null;
    //Uri uri = new Uri("Checked.png", UriKind.Relative);
    //sri = Application.GetResourceStream(uri);

    //BitmapImage bitmap = new BitmapImage();
    //bitmap.SetSource(sri.Stream);
    //WriteableBitmap wb = new WriteableBitmap(bitmap);

    //MemoryStream ms = new MemoryStream();
    //wb.SaveJpeg(ms, bitmap.PixelWidth, bitmap.PixelHeight, 0, 100);
    //byte[] imageBytes = ms.ToArray();

    //base64 = System.Convert.ToBase64String(imageBytes);
}
protected void btnImage1_Click(object sender, EventArgs e)
{
    //--------------------------People table---------------------------------------
  
    objgenenral = new BaseLayer.General_function();
    DataTable dt = new DataTable();


    string QurPeople = "SELECT  userImage FROM  Cerpac . dbo . People where cerpac_no in ('AO216960') ";
    dt = objgenenral.FetchData(QurPeople);
   
    byte[] barrImg = (byte[])dt.Rows[0]["userimage"];

    MemoryStream mstream = new MemoryStream(barrImg);
    System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(mstream);

    string imageString = ConvertImage(bmp);
    StreamWriter sw = new StreamWriter(@"D:\waleedelkot.xml", false);
    sw.Write(imageString);
    sw.Close();
   
}

//private String ReadImage()
//{
//    byte[] barrImg = (byte[])dt.Rows[0]["userimage"];

//    MemoryStream mstream = new MemoryStream(barrImg);
//    System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(mstream);
//    MemoryStream imageStream = new MemoryStream();

//    bmp.Save(imageStream, ImageFormat.Jpeg);

//    string imageString = Convert.ToBase64String(imageStream.ToArray()); ;
//    StreamWriter sw = new StreamWriter(@"D:\waleedelkot.xml", false);
//    sw.Write(imageString);
//    sw.Close();
//}

//private String SaveImage()
//{
//    string[] lines = System.IO.File.ReadAllLines(@"D:\waleedelkot.xml");

//    // Convert Base64 String to byte[]
//    byte[] imageBytes = Convert.FromBase64String(lines[0].ToString());
//    MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);

//    // Convert byte[] to Image
//    ms.Write(imageBytes, 0, imageBytes.Length);
//    System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(ms);

//    byte[] data = null;
   
//    ImageConverter converter = new ImageConverter();
//    data = (byte[])converter.ConvertTo(bmp, typeof(byte[]));

//    ms.Close();

//}

protected void BtnImage2_Click(object sender, EventArgs e)
{
    try
    {
        
        string[] lines = System.IO.File.ReadAllLines(@"D:\waleedelkot.xml");

        // Convert Base64 String to byte[]
        byte[] imageBytes = Convert.FromBase64String(lines[0].ToString());
        MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);

        // Convert byte[] to Image
        ms.Write(imageBytes, 0, imageBytes.Length);
        System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(ms);

        if (File.Exists(Server.MapPath("~") + "/Images/Testing.jpeg"))
            File.Delete(Server.MapPath("~") + "/Images/Testing.jpeg");


        if (!File.Exists(Server.MapPath("~") + "/Images/Testing.jpeg"))
            bmp.Save(Server.MapPath("~") + "/Images/Testing.jpeg");

        //Image1.ImageUrl=(Server.MapPath("~") + "/Images/Testing.jpeg");
        ms.Close();

      

    }
    catch (Exception ex)
    {

    }
}
private string ConvertImage(Bitmap sBit)
{

    MemoryStream imageStream = new MemoryStream();
    sBit.Save(imageStream, ImageFormat.Jpeg);

    return Convert.ToBase64String(imageStream.ToArray());
}



protected void btnUpdateImage_Click(object sender, EventArgs e)
{
    /************* Insert Image in DB **************/
    string[] lines = System.IO.File.ReadAllLines(@"D:\waleedelkot.xml");

    // Convert Base64 String to byte[]
    byte[] imageBytes = Convert.FromBase64String(lines[0].ToString());
    MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);

    // Convert byte[] to Image
    ms.Write(imageBytes, 0, imageBytes.Length);
    System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(ms);

      


    byte[] data = null;
    //BinaryReader br = new BinaryReader(ms);
    //data = br.ReadBytes((int)numBytes);

    ImageConverter converter = new ImageConverter();
    data = (byte[])converter.ConvertTo(bmp, typeof(byte[]));

    ms.Close();

    SqlConnection Connection = new SqlConnection();
    Connection.ConnectionString = ConfigurationManager.ConnectionStrings["NigeriaConnectionString"].ConnectionString;
    SqlCommand Command = new SqlCommand("update people set userImage=@ImageFile where cerpac_no in ('AO109493') ", Connection);

    SqlParameter imageFileParameter = new SqlParameter("@ImageFile", SqlDbType.Image);
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

protected void btnSaveImage_Click(object sender, EventArgs e)
{
    BaseLayer.General_function ObjGenBal = new BaseLayer.General_function();

    DataTable dtimg = new DataTable();
    string qryimg = "select UserImage from people where cerpac_no= (select cerpacno from peoplechild where formno='AO216960')";
    dtimg = ObjGenBal.FetchData(qryimg);

    byte[] picData = dtimg.Rows[0]["userimage"] as byte[] ?? null;
    System.Drawing.Image bmp;

    if (picData != null)
    {
        using (MemoryStream ms = new MemoryStream(picData))
        {
            // Load the image from the memory stream. How you do it depends
            // on whether you're using Windows Forms or WPF.
            // For Windows Forms you could write:
            //System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(ms);

            bmp = System.Drawing.Image.FromStream(ms);



            if (File.Exists(Server.MapPath("~") + "/Images/Testing.jpeg"))
                File.Delete(Server.MapPath("~") + "/Images/Testing.jpeg");


            if (!File.Exists(Server.MapPath("~") + "/Images/Testing.jpeg"))
                bmp.Save(Server.MapPath("~") + "/Images/Testing.jpeg");

        }
    }
}

protected void btnSaveTemp_Click(object sender, EventArgs e)
{
    string myTempFile = Path.Combine(Path.GetTempPath(), "SaveFile.txt");
    using (StreamWriter sw = new StreamWriter(myTempFile))
    {
        sw.WriteLine("Your error message");
    }
}
}
