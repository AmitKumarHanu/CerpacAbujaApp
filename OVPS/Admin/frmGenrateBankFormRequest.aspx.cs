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
using System.Globalization;



public partial class Admin_frmGenrateBankFormRequest : System.Web.UI.Page
{
#region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    BaseLayer.General_function objgenenral = null;
    protected DataSet objDs = new DataSet();
    protected DataTable dt = new DataTable();
    protected DataTable dtform = new DataTable();

    protected BaseLayer.General_function ObjGenBal = null;
    Label LabelMessage = null;
    string UserID = null, ZoneDetails = null, NewReq = "", FormNotxt="";
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
                FreeForm();
            }
            txtFormNo.Text =Session["FormNo"].ToString() ;
            txtFormNo1.Text = Session["FormNo1"].ToString();
            txtCerpacno.Text=Session["CerpacNo"].ToString();

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

public void NewCase()
{
    try
    {
    string xmlfilename = "default.xml";

    string foldername = ZoneDetails.Trim().ToString() + "--" + DateTime.Now.ToShortDateString().Replace("/", "").Replace(":", "");
    string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
    filePath = filePath + @"\";


    if (!Directory.Exists(filePath))
    {
        Directory.CreateDirectory(filePath);
    }

    xmlfilename = ZoneDetails.Trim().ToString() + "-CRB-" + DateTime.Now.Date.ToString("dd/MM/yyyy").Replace("/", "").Replace(":", "") + "-" + DateTime.Now.ToLocalTime().ToLongTimeString().Replace(" ", "").Replace(":", ".") + ".xml";

    if (File.Exists(Path.Combine(filePath, filePath + @"\" + xmlfilename.ToString().Trim())))
    {
        File.Delete(Path.Combine(filePath, filePath + @"\" + xmlfilename.ToString().Trim()));
    }

    System.IO.StreamWriter s = File.CreateText(System.IO.Path.Combine(filePath, filePath + @"\" + xmlfilename.ToString().Trim()));
  
    //------------------Write fresh request only in the text file--------------
      
    s.WriteLine("ZoneName \t" + ZoneDetails);
    s.WriteLine("Case \t" + 1);
    s.WriteLine("FormNo \t" + txtFormNo.Text.ToString().Trim());
    s.WriteLine("FreeFormNo \t" + ViewState["FRNList"].ToString().Trim());

    s.Dispose();
   
            
      
        
        //---------------Audit trail in bank request formno.'s---------------------

        String source = txtFormNo.Text.ToString().Trim();
        string[] stringSeparators = new string[] { "," };
        var result = source.Split(stringSeparators, StringSplitOptions.None);
        int loop = 0;
        string AlreadyReq = "";

        for (int i = 0; i <= result.Count() - 1; i++)
        {
            string formno = result[i].ToString().Trim();
            result[i] = formno;
            if (result[i].ToString().Substring(0, 2).Trim() == "AO" || result[i].ToString().Substring(0, 2).Trim() == "AR" || result[i].ToString().Substring(0, 2).Trim() == "CR" || result[i].ToString().Substring(0, 2).Trim() == "NG")
            {

                //-----------------Search in Upload excel data C table--------------------
                ObjGenBal = new BaseLayer.General_function();
                string QuerCountFound = "select count(*) from uploaded_excel_data_C where  Formno='" + result[i].ToString().Trim() + "'";

                DataTable dt = new DataTable();
                dt = ObjGenBal.FetchData(QuerCountFound);

                if (dt.Rows[0].ItemArray[0].ToString() == "0")
                {

                    //--------------------------Insert--------------------------------   

                    SqlConnection Connection = new SqlConnection();
                    Connection.ConnectionString = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;

                    SqlCommand Command = new SqlCommand("Insert into uploaded_excel_data_C (FormNo,bank_req_userid,bank_req_date,zone_name) Values( '" + result[i].ToString().Trim() + "','" + UserID.ToString().Trim() + "',GetDate(), '" + ZoneDetails + "')", Connection);
                    Connection.Open();
                    Command.ExecuteNonQuery();
                    Connection.Close();
                    NewReq = NewReq + result[i].ToString().Trim() + ",";
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
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('We found " + loop + " worng form no in textbox .'); window.location = '" + Page.ResolveUrl("frmGenrateBankFormRequest.aspx") + "';", true);
            

        }
        if (AlreadyReq != "")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Already requested form no :" + AlreadyReq.Trim().Replace(" ", ",") + ".'); window.location = '" + Page.ResolveUrl("frmGenrateBankFormRequest.aspx") + "';", true);
            

        }

        if (NewReq.Trim() != "")
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

                //if (File.Exists(Path.Combine(filePath, filePath + @"\" + xmlfilename.ToString().Trim())))
                //{

                //    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Request file successfull created on desktop :" + xmlfilename.ToString().Trim() + " .');", true);

                //}

                //txtFormNo.Text = "";
                //txtFormNo1.Text = "";
                //txtCerpacno.Text = "";

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
public void RenewalCase()
{
    try
    {

    string xmlfilename = "default.xml";

    string foldername = ZoneDetails.Trim().ToString() + "--" + DateTime.Now.ToShortDateString().Replace("/", "").Replace(":", "");
    string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
    filePath = filePath + @"\";


    if (!Directory.Exists(filePath))
    {
        Directory.CreateDirectory(filePath);
    }

    xmlfilename = ZoneDetails.Trim().ToString() + "-CRB-" + DateTime.Now.Date.ToString("dd/MM/yyyy").Replace("/", "").Replace(":", "") + "-" + DateTime.Now.ToLocalTime().ToLongTimeString().Replace(" ", "").Replace(":", ".") + ".xml";

    if (File.Exists(Path.Combine(filePath, filePath + @"\" + xmlfilename.ToString().Trim())))
    {
        File.Delete(Path.Combine(filePath, filePath + @"\" + xmlfilename.ToString().Trim()));
    }

    System.IO.StreamWriter s = File.CreateText(System.IO.Path.Combine(filePath, filePath + @"\" + xmlfilename.ToString().Trim()));

    //------------------Write Renewal request only in the text file--------------
    
    s.WriteLine("ZoneName \t" + ZoneDetails);
    s.WriteLine("Case  \t" + 2);
    s.WriteLine("FormNo \t" + txtFormNo1.Text.ToString().Trim());
    s.WriteLine("CrepacNo \t" + txtCerpacno.Text.ToString().Trim());
    s.WriteLine("FreeFormNo \t" + ViewState["FRNList"].ToString().Trim());

    s.Dispose();
   
    



        //---------------Audit trail in bank request formno.'s---------------------

        String source = txtFormNo1.Text.ToString().Trim();
        string[] stringSeparators = new string[] { "," };
        var result = source.Split(stringSeparators, StringSplitOptions.None);
        int loop = 0;
        string AlreadyReq = "";

        for (int i = 0; i <= result.Count() - 1; i++)
        {
            string formno = result[i].ToString().Trim();
            result[i] = formno;
            if (result[i].ToString().Substring(0, 2).Trim() == "AO" || result[i].ToString().Substring(0, 2).Trim() == "AR" || result[i].ToString().Substring(0, 2).Trim() == "CR" || result[i].ToString().Substring(0, 2).Trim() == "NG")
            {
                //-----------------Search in Upload excel data C table--------------------
                ObjGenBal = new BaseLayer.General_function();
                string QuerCountFound = "select count(*) from uploaded_excel_data_C where  Formno='" + result[i].ToString().Trim() + "'";

                DataTable dt = new DataTable();
                dt = ObjGenBal.FetchData(QuerCountFound);
                if (dt.Rows[0].ItemArray[0].ToString() == "0")
                {

                    //--------------------------Insert--------------------------------   

                    SqlConnection Connection = new SqlConnection();
                    Connection.ConnectionString = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;

                    SqlCommand Command = new SqlCommand("Insert into uploaded_excel_data_C (FormNo,bank_req_userid,bank_req_date,zone_name) Values( '" + result[i].ToString().Trim() + "','" + UserID.ToString().Trim() + "', GetDate() , '" + ZoneDetails + "')", Connection);
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

        if (NewReq.Trim() != "")
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

                //if (File.Exists(Path.Combine(filePath, filePath + @"\" + xmlfilename.ToString().Trim())))
                //{

                //    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Request file successfull created on desktop :" + xmlfilename.ToString().Trim() + " .');", true);

                //}

                ////------------------Create Encrypted File for Client----------------
                System.IO.FileStream fs = null;
                fs = System.IO.File.Open(output, System.IO.FileMode.Open);
                byte[] btFile = new byte[fs.Length];
                fs.Read(btFile, 0, Convert.ToInt32(fs.Length));
                fs.Close();

                File.Delete(input);
                File.Delete(output);

                Response.AddHeader("Content-disposition", "attachment; filename=" + xmlfilename.ToString().Trim());
                Response.ContentType = "application/octet-stream";
                Response.BinaryWrite(btFile);
                Response.End();              
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
        dt = null;
        ObjGenBal = null;
    }
}
public void BothCase()
{
    try
    {

    string xmlfilename = "default.xml";

    string foldername = ZoneDetails.Trim().ToString() + "--" + DateTime.Now.ToShortDateString().Replace("/", "").Replace(":", "");
    string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
    filePath = filePath + @"\";


    if (!Directory.Exists(filePath))
    {
        Directory.CreateDirectory(filePath);
    }
    xmlfilename = ZoneDetails.Trim().ToString() + "-CRB-" + DateTime.Now.Date.ToString("dd/MM/yyyy").Replace("/", "").Replace(":", "") + "-" + DateTime.Now.ToLocalTime().ToLongTimeString().Replace(" ", "").Replace(":", ".") + ".xml";

    if (File.Exists(Path.Combine(filePath, filePath + @"\" + xmlfilename.ToString().Trim())))
    {
        File.Delete(Path.Combine(filePath, filePath + @"\" + xmlfilename.ToString().Trim()));
    }

    System.IO.StreamWriter s = File.CreateText(System.IO.Path.Combine(filePath, filePath + @"\" + xmlfilename.ToString().Trim()));

    //------------------Write Fresh and Renewal case boht in request text file--------------
    
    s.WriteLine("ZoneName \t" + ZoneDetails);
    s.WriteLine("Case \t" + 3);
    s.WriteLine("FormNo \t" + txtFormNo.Text.ToString().Trim());
    s.WriteLine("FormNo1 \t" + txtFormNo1.Text.ToString().Trim());
    s.WriteLine("CrepacNo \t" + txtCerpacno.Text.ToString().Trim());
    s.WriteLine("FreeFormNo \t" + ViewState["FRNList"].ToString().Trim());


    s.Dispose();
   


        //---------------Audit trail in bank request formno.'s---------------------

        String source = txtFormNo.Text.ToString().Trim() + "," + txtFormNo1.Text.ToString().Trim();
        string[] stringSeparators = new string[] { "," };
        var result = source.Split(stringSeparators, StringSplitOptions.None);
        int loop = 0;
        string AlreadyReq = "";
        for (int i = 0; i <= result.Count() - 1; i++)
        {
            string formno = result[i].ToString().Trim();
            result[i] = formno;
            if (result[i].ToString().Substring(0, 2).Trim() == "AO" || result[i].ToString().Substring(0, 2).Trim() == "AR" || result[i].ToString().Substring(0, 2).Trim() == "CR" || result[i].ToString().Substring(0, 2).Trim() == "NG")
            {
                //-----------------Search in Upload excel data C table--------------------
                ObjGenBal = new BaseLayer.General_function();
                string QuerCountFound = "select count(*) from uploaded_excel_data_C where  Formno='" + result[i].ToString().Trim() + "'";

                DataTable dt = new DataTable();
                dt = ObjGenBal.FetchData(QuerCountFound);
                if (dt.Rows[0].ItemArray[0].ToString() == "0")
                {

                    //--------------------------Insert--------------------------------   

                    SqlConnection Connection = new SqlConnection();
                    Connection.ConnectionString = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;

                    SqlCommand Command = new SqlCommand("Insert into uploaded_excel_data_C (FormNo,bank_req_userid,bank_req_date,zone_name) Values( '" + result[i].ToString().Trim() + "','" + UserID.ToString().Trim() + "', GetDate(), '" + ZoneDetails + "')", Connection);
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

        if (NewReq.Trim() != "")
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

                //if (File.Exists(Path.Combine(filePath, filePath + @"\" + xmlfilename.ToString().Trim())))
                //{

                //    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Request file successfull created on desktop :" + xmlfilename.ToString().Trim() + " .');", true);

                //}

                ////------------------Create Encrypted File for Client----------------
                System.IO.FileStream fs = null;
                fs = System.IO.File.Open(output, System.IO.FileMode.Open);
                byte[] btFile = new byte[fs.Length];
                fs.Read(btFile, 0, Convert.ToInt32(fs.Length));
                fs.Close();

                File.Delete(input);
                File.Delete(output);

                Response.AddHeader("Content-disposition", "attachment; filename=" + xmlfilename.ToString().Trim());
                Response.ContentType = "application/octet-stream";
                Response.BinaryWrite(btFile);
                Response.End();

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
        dt = null;
        ObjGenBal = null;
    }

}
public void FreeForm()
{
    try
    {
        objgenenral = new BaseLayer.General_function();
        string quer = "Select FormNo From uploaded_excel_data_C where bank_flag=1 and flag1=1 and isnull(final_flag,0) =0";
        dtform = objgenenral.FetchData(quer);
        if (dtform.Rows.Count > 0)
        {

            for (int i = 0; i < dtform.Rows.Count; i++)
            {
                FormNotxt = FormNotxt + dtform.Rows[i].ItemArray[0].ToString() + ",";

            }
            ViewState["FRNList"] = FormNotxt;

        }
        else
        {
            ViewState["FRNList"] = "X";
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

     
protected void EncryptFile(object sender, EventArgs e)
{
    if (txtFormNo.Text != "" && txtFormNo1.Text == "" && txtCerpacno.Text=="")
    {
        NewCase();
    }
    else if (txtFormNo.Text == "" && txtFormNo1.Text != "" && txtCerpacno.Text != "")
    {
        RenewalCase();
    }
    else if (txtFormNo.Text != "" && txtFormNo1.Text != "" && txtCerpacno.Text != "")
    {
        BothCase();
    }
    else
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please genrate offline  new case / renewal case encrypted file for central. ');", true);

      
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


//protected void DecryptFile(object sender, EventArgs e)
//{
//    string foldername = "Decrypt File";
//    string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
//    filePath = filePath + @"\" + foldername;

//    if (!Directory.Exists(filePath))
//        {
//            Directory.CreateDirectory(filePath);
//        }
    
//    //Get the Input File Name and Extension
//    //string fileName = Path.GetFileNameWithoutExtension(FileUpload1.PostedFile.FileName);
//    //string fileExtension = Path.GetExtension(FileUpload1.PostedFile.FileName);

//    //string input = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) +@"\"+ fileName + fileExtension;
    
     
//   // string output = filePath + @"\" + fileName + "_dec" + fileExtension;

//    //Save the Input File, Decrypt it and save the decrypted file in output path.
//    //this.Decrypt(input, output);    

//    //Delete the original (input) and the decrypted (output) file.
//    //File.Delete(input);
//    //File.Delete(output);


   
//}

//private void Decrypt(string inputFilePath, string outputfilePath)
//{
//    string EncryptionKey = "MAKV2SPBNI99212";
//    using (Aes encryptor = Aes.Create())
//    {
//        Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
//        encryptor.Key = pdb.GetBytes(32);
//        encryptor.IV = pdb.GetBytes(16);
//        using (FileStream fsInput = new FileStream(inputFilePath, FileMode.Open))
//        {
//            using (CryptoStream cs = new CryptoStream(fsInput, encryptor.CreateDecryptor(), CryptoStreamMode.Read))
//            {
//                using (FileStream fsOutput = new FileStream(outputfilePath, FileMode.Create))
//                {
//                    int data;
//                    while ((data = cs.ReadByte()) != -1)
//                    {
//                        fsOutput.WriteByte((byte)data);
//                    }
//                }
//            }
//        }
//    }
//}
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
}