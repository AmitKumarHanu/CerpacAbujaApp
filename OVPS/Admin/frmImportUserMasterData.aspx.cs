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
using System.Drawing;


public partial class Admin_frmImportUserMasterData : System.Web.UI.Page
{
    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    BaseLayer.General_function objgenenral = null;
    protected DataSet objDs = new DataSet();
    protected DataTable dt = new DataTable();
    protected DataTable dtform = new DataTable();

    protected BaseLayer.General_function ObjGenBal = null;
    string AppID = "";
    string UserID = null, ZoneDetails=null;
    Label LabelMessage = null ;
    string input, output;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        if (objectSessionHolderPersistingData == null)
        {
            Response.Redirect("../Login.aspx");
        }

        

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
                ZoneDetails = dt.Rows[0]["ZoneName"].ToString() ;
            }
            if (!IsPostBack)
            {
                DivDecrypt.Visible = true; 
                divgrd.Visible = false;
                DivImport.Visible = false;

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
    protected void btn_cancel_Click(object sender, EventArgs e)
    {


        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Reset Import User Page!!.'); window.location = '" + Page.ResolveUrl("frmImportUserMasterData.aspx") + "';", true);
    }
    

    
    protected void DecryptFile(object sender, EventArgs e)
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


        
        if (!Directory.Exists(filePath))
        {
            Directory.CreateDirectory(filePath);
        }

        //Get the Input File Name and Extension
        string fileName = Path.GetFileNameWithoutExtension(FileUpload1.PostedFile.FileName);
        string fileExtension = Path.GetExtension(FileUpload1.PostedFile.FileName);

        input = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + fileName + fileExtension;

        ViewState["FileUpload1"] = FileUpload1.PostedFile.FileName;

        output = filePath + @"\" + fileName + "_dec" + fileExtension;

        //Save the Input File, Decrypt it and save the decrypted file in output path.
        this.Decrypt(input, output);

        
        BindGrid();
        //SplitString();
        //string Readfile = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + fileName + fileExtension;
        //dstest.ReadXml(filePath);
        
        //Delete the original (input) and the decrypted (output) file.
        //File.Delete(input);
        //File.Delete(output);


    }

    protected void BindGrid()
    {
        try
        {
              //int i = Convert.ToInt32(File.ReadAllLines(output).Count());

            //----------------------Create Data Table ---------------------------
            DataTable myDataTable = new DataTable();

            DataColumn myDataColumn;

       
            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "LoginID";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "UserName";
            myDataTable.Columns.Add(myDataColumn);


            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "UserType";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "UserActiveFromDate";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "UserActiveToDate";
            myDataTable.Columns.Add(myDataColumn);

            
              //-----------------Transfer Basice Details -------------------------
            string[] lines = System.IO.File.ReadAllLines((output));

            //------------------Split Zone Name----------------------------------
            String source = lines[0];
            string[] stringSeparators = new string[] { "\t" };
            var result = source.Split(stringSeparators, StringSplitOptions.None);
            String ReceivedZone = result[1];
            //lblZonename.Text = lines[0];

            if (ZoneDetails == result[1].ToString())
            {

                //-----------------------Split User Mastee  Details------------------

                String UserMaster = lines[2];
                string[] stringSeparatorUserMaster = new string[] { "-###-" };
                var resultUserMaster = UserMaster.Split(stringSeparatorUserMaster, StringSplitOptions.None);
                //` String ReceivedUserMaster = resultUserMaster[1];
                for (int i = 1; i <= resultUserMaster.Count() - 2; i++)
                {



                    String UserMasterRow = resultUserMaster[i];
                    string[] stringSeparatorsUserMasterRow = new string[] { "\t" };
                    var UserMasterRowCount = UserMasterRow.Split(stringSeparatorsUserMasterRow, StringSplitOptions.None);

                    //---------------------------Insert Data in DataTable------------------            

                    DataRow row;

                    row = myDataTable.NewRow();
                    row["LoginID"] = UserMasterRowCount[2];
                    row["UserName"] = UserMasterRowCount[4];
                    row["UserType"] = UserMasterRowCount[24];
                    row["UserActiveFromDate"] = UserMasterRowCount[17];
                    row["UserActiveToDate"] = UserMasterRowCount[18];


                    myDataTable.Rows.Add(row);
                }
                //--------------------Bind DataGrid by datatable-------------------------------
                if (Page.IsPostBack)
                {

                    Session["myDatatable"] = myDataTable;

                    this.grdUserList.DataSource = ((DataTable)Session["myDatatable"]).DefaultView;
                    this.grdUserList.DataBind();

                    DivDecrypt.Visible = false;
                    divgrd.Visible = true;
                    DivImport.Visible = true;

                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Your are importing wrong file. Please import correct user detail file  !!.'); window.location = '" + Page.ResolveUrl("frmImportUserMasterData.aspx") + "';", true);

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

    public void SplitString()
    {
        try
        {

            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            filePath = filePath + @"\";

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

           

            //Get the Input File Name and Extension
            string fileName = Path.GetFileNameWithoutExtension(ViewState["FileUpload1"].ToString());
            string fileExtension = Path.GetExtension(ViewState["FileUpload1"].ToString());

            string input = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + fileName + fileExtension;
            //string input = ViewState["input"].ToString();


            output = filePath + @"\" + fileName + "_dec" + fileExtension;

            //Save the Input File, Decrypt it and save the decrypted file in output path.
            this.Decrypt(input, output);



            //-----------------Transfer Basice Details -------------------------
            string[] lines = System.IO.File.ReadAllLines((output));

            //------------------Split Zone Name----------------------------------
            String source = lines[0];
            string[] stringSeparators = new string[] { "\t" };
            var result = source.Split(stringSeparators, StringSplitOptions.None);
            String ReceivedZone = result[1];
            //lblZonename.Text = lines[0];

            //-------------Split--Recived--UserID------------------------------
            String UID = lines[1];
            string[] stringSeparatorUID = new string[] { "\t" };
            var resultUID = UID.Split(stringSeparatorUID, StringSplitOptions.None);
            String ReceivedUID = resultUID[1];

            //-------------Split--Recived--UserID------------------------------
            String UID1 = resultUID[1]; ;
            string[] stringSeparatorUID1 = new string[] { "','" };
            var resultUID1 = UID1.Split(stringSeparatorUID1, StringSplitOptions.None);
            String ReceivedUID1 = resultUID1[1];

            SqlConnection Connection = new SqlConnection();
            Connection.ConnectionString = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;


            //-----------------------Split User Mastee  Details------------------

            String UserMaster = lines[2];
            string[] stringSeparatorUserMaster = new string[] { "-###-" };
            var resultUserMaster = UserMaster.Split(stringSeparatorUserMaster, StringSplitOptions.None);
           //` String ReceivedUserMaster = resultUserMaster[1];
            for (int i = 1; i <= resultUserMaster.Count()-2; i++)
            {

            

                String UserMasterRow = resultUserMaster[i]; 
                string[] stringSeparatorsUserMasterRow = new string[] { "\t" };
                var UserMasterRowCount = UserMasterRow.Split(stringSeparatorsUserMasterRow, StringSplitOptions.None);

                //-----------------Search in UserMaster table--------------------
                objgenenral = new BaseLayer.General_function();
                string QuerCountFound = "select count(*) from UserMaster where UserID in ('" + UserMasterRowCount[1].Trim() + "')";

                DataTable dtZ = new DataTable();
                dtZ = objgenenral.FetchData(QuerCountFound);
                if (dtZ.Rows[0].ItemArray[0].ToString() != "0")
                    {
                       
                        //------------------Update Zone UserMaster-------------------------
                        SqlCommand CommandZU = new SqlCommand("SET IDENTITY_INSERT UserMaster ON; update UserMaster set [CompanyID]='" + UserMasterRowCount[0].Trim() + "',[LoginID]='" + UserMasterRowCount[2].Trim() + "',[Password]='" + UserMasterRowCount[3].Trim() + "',[UserName]='" + UserMasterRowCount[4].Trim() +
                                "',[UserType]='" + UserMasterRowCount[5].Trim() + "',[GrpID]='" + UserMasterRowCount[6].Trim() + "',[DateOfBirth]='" + UserMasterRowCount[7].Trim() + "',[EmailID]='" + UserMasterRowCount[8].Trim() + "',[Designation]='" + UserMasterRowCount[9].Trim() +
                                "',[MobileNumber]='" + UserMasterRowCount[10].Trim() + "',[LandLineNumber]='" + UserMasterRowCount[11].Trim() + "',[Address]='" + UserMasterRowCount[12].Trim() + "',[ApproverYN]='" + UserMasterRowCount[13].Trim() + "',[ApproverLevel]='" + UserMasterRowCount[14].Trim() +
                                "',[BankPersonYN]='" + UserMasterRowCount[15].Trim() + "',[BorderCode]='" + UserMasterRowCount[16].Trim() + "',[UserActiveFromDate]='" + UserMasterRowCount[17].Trim() + "',[UserActiveToDate]='" + UserMasterRowCount[18].Trim() + "',[UserStatus]='" + UserMasterRowCount[19].Trim() +
                                "',[CreatedOn]='" + UserMasterRowCount[20].Trim() + "',[CreatedBy]='" + UserMasterRowCount[21].Trim() + "',[ModifiedOn]='" + UserMasterRowCount[22].Trim() + "',[ModifiedBy]='" + UserMasterRowCount[23].Trim() + "',[GrpCode]='" + UserMasterRowCount[24].Trim() + "' where  UserID in ('" + UserMasterRowCount[1].Trim() + "'); SET IDENTITY_INSERT usermaster OFF;", Connection);
                        Connection.Open();
                        CommandZU.ExecuteNonQuery();
                        Connection.Close();
                    }
                    else
                    {
                        //------------------Insert Zone UserZoneRelation-------------------------
                        SqlCommand CommandUZR = new SqlCommand("SET IDENTITY_INSERT Usermaster ON; INSERT INTO  UserMaster ([CompanyID],[UserID],[LoginID],[Password],[UserName]" +
                                                        ",[UserType],[GrpID], [DateOfBirth], [EmailID],[Designation]" +
                                                        ",[MobileNumber],[LandLineNumber],[Address],[ApproverYN],[ApproverLevel]" +
                                                        ",[BankPersonYN],[BorderCode],[UserActiveFromDate],[UserActiveToDate],[UserStatus]" +
                                                        ",[CreatedOn],[CreatedBy],[ModifiedOn],[ModifiedBy],[GrpCode]) " +
                                             " VALUES ('" + UserMasterRowCount[0].Trim() + "','" + UserMasterRowCount[1].Trim() + "','" + UserMasterRowCount[2].Trim() + "','" + UserMasterRowCount[3].Trim() + "','" + UserMasterRowCount[4].Trim() + "','"
                                             + UserMasterRowCount[5].Trim() + "','" + UserMasterRowCount[6].Trim() + "','" + UserMasterRowCount[7].Trim() + "','" + UserMasterRowCount[8].Trim() + "','" + UserMasterRowCount[9].Trim() + "','"
                                             + UserMasterRowCount[10].Trim() + "','" + UserMasterRowCount[11].Trim() + "','" + UserMasterRowCount[12].Trim() + "','" + UserMasterRowCount[13].Trim() + "','" + UserMasterRowCount[14].Trim() + "','"
                                             + UserMasterRowCount[15].Trim() + "','" + UserMasterRowCount[16].Trim() + "','" + UserMasterRowCount[17].Trim() + "','" + UserMasterRowCount[18].Trim() + "','" + UserMasterRowCount[19].Trim() + "','"
                                             + UserMasterRowCount[20].Trim() + "','" + UserMasterRowCount[21].Trim() + "','" + UserMasterRowCount[22].Trim() + "','" + UserMasterRowCount[23].Trim() + "','" + UserMasterRowCount[24].Trim() + "'); SET IDENTITY_INSERT usermaster OFF;", Connection);
                        Connection.Open();
                        CommandUZR.ExecuteNonQuery();
                        Connection.Close();
                    }

                //-------------------Import image in UserMaster table-------------------------------

                if (UserMasterRowCount[25].Trim() != "Null")
                {
                    // Convert Base64 String to byte[]
                    byte[] imageBytes = Convert.FromBase64String(UserMasterRowCount[25].ToString().Trim());
                    MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);

                    // Convert byte[] to Image
                    ms.Write(imageBytes, 0, imageBytes.Length);
                    System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(ms);


                    byte[] data = null;

                    ImageConverter converter = new ImageConverter();
                    data = (byte[])converter.ConvertTo(bmp, typeof(byte[]));

                    ms.Close();


                    Connection.ConnectionString = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;

                    SqlCommand Command1 = new SqlCommand("Update UserMaster set UserSig =@UserSig where UserId in ('" + UserMasterRowCount[1].Trim() + "')", Connection);

                    SqlParameter imageFileParameter = new SqlParameter("@UserSig", SqlDbType.Image);
                    imageFileParameter.Value = data;
                    Command1.Parameters.Add(imageFileParameter);

                    Connection.Open();
                    Command1.ExecuteNonQuery();
                    Connection.Close();
                }
                //------------------------------------------------

            }

            //-----------------------Split User Zone Relation Details------------------

            String UserZoneR = lines[3];
            string[] stringSeparatorUserZoneR = new string[] { "-###-" };
            var resultUserZoneR = UserZoneR.Split(stringSeparatorUserZoneR, StringSplitOptions.None);
            //String ReceivedUserZoneR = resultUserZoneR[1];
            for (int i = 1; i <= resultUserZoneR.Count() - 2; i++)
            {
                String UserZoneRRow = resultUserZoneR[i]; // lines[2];
                string[] stringSeparatorsUserZoneRRow = new string[] { "\t" };
                var UserZoneRRowCount = UserZoneRRow.Split(stringSeparatorsUserZoneRRow, StringSplitOptions.None);

                string QueryUserMasterZ = "Select count(*) From UserZoneRelation where UserID in ('" + UserZoneRRowCount[1].Trim() + "')";

                DataTable dtZ1 = new DataTable();
                dtZ1 = objgenenral.FetchData(QueryUserMasterZ);

                if (dtZ1.Rows[0].ItemArray[0].ToString() != "0")
                {
                    //------------------Update Zone UserMaster-------------------------
                    SqlCommand CommandZU = new SqlCommand("SET IDENTITY_INSERT UserZoneRelation ON; update UserZoneRelation set [UserZoneId]='" + UserZoneRRowCount[0].Trim() + "',[ZoneCode]='" + UserZoneRRowCount[2].Trim() + "'where  UserID in ('" + UserZoneRRowCount[1].Trim() + "'); SET IDENTITY_INSERT UserZoneRelation OFF;", Connection);

                    Connection.Open();
                    CommandZU.ExecuteNonQuery();
                    Connection.Close();
                }
                else
                {
                    //------------------Insert Zone UserZoneRelation-------------------------

                    SqlCommand CommandUZR = new SqlCommand("SET IDENTITY_INSERT UserZoneRelation ON; INSERT INTO  UserZoneRelation ( [UserZoneId], [UserId],[ZoneCode]) " +
                                         " VALUES ('" + UserZoneRRowCount[0].Trim() + "','" + UserZoneRRowCount[1].Trim() + "','" + UserZoneRRowCount[2].Trim() + "'); SET IDENTITY_INSERT UserZoneRelation ON;", Connection);

                    Connection.Open();
                    CommandUZR.ExecuteNonQuery();
                    Connection.Close();
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

    
    protected void btnEncrypt_Click(object sender, EventArgs e)
    {

        if (ViewState["FileUpload1"].ToString() != "")
        {
            SplitString();
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Import file Successfull !!.'); window.location = '" + Page.ResolveUrl("frmImportUserMasterData.aspx") + "';", true);
            File.Delete(input);
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