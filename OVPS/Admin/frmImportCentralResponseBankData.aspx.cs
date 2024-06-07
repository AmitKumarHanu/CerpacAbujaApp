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
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Drawing;

public partial class Admin_frmImportCentralResponseBankData : System.Web.UI.Page
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
    string output;
    Label LabelMessage = null ;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        if (objectSessionHolderPersistingData == null)
        {
            Response.Redirect("../Login.aspx");
        }


        UserID = objectSessionHolderPersistingData.User_ID.ToString();
       
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
                divbrowsefile.Visible = true;
                divCrefile.Visible = false;
                divgrd.Visible = false;
                divSearchResult.Visible = false;
                divSearchCerpac.Visible = false;
                divgrdCerpac.Visible = false;
               
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
            filePath = filePath + @"\";

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            divbrowsefile.Visible = false;
            divSearchResult.Visible = true;
            divgrd.Visible = true;
            divCrefile.Visible = true;


            ViewState["FileUpload1"] = FileUpload1.PostedFile.FileName;

            //Get the Input File Name and Extension
            string fileName = Path.GetFileNameWithoutExtension(FileUpload1.PostedFile.FileName);
            string fileExtension = Path.GetExtension(FileUpload1.PostedFile.FileName);

            string input = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + fileName + fileExtension;
            output = filePath + @"\" + fileName + "_dec" + fileExtension;
            
            //Save the Input File, Decrypt it and save the decrypted file in output path.
            this.Decrypt(input, output);

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


    public string datep(string date)
    {
        string sysf = "dd-MM-yyyy";

        if (DateTimeFormatInfo.CurrentInfo.ShortDatePattern.ToCharArray()[0].ToString() == "d")
        {
            sysf = "MM-dd-yyyy";
        }
        if (date.Trim() == null || date.Trim() == string.Empty)
        {
            return "";
        }
        else
            return DateTime.Parse(date).ToString(sysf);
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
            //int i = Convert.ToInt32(File.ReadAllLines(output).Count());

            //----------------------Create Data Table ---------------------------
            DataTable myDataTable = new DataTable();

            DataColumn myDataColumn;

            //myDataColumn = new DataColumn();
            //myDataColumn.DataType = Type.GetType("System.String");
            //myDataColumn.ColumnName = "id";
            //myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "Date1";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "FirstName";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "MiddleName";
            myDataTable.Columns.Add(myDataColumn);


            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "LastName";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "Company";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "Nationality";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "ReqNo";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "CerpacNo";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "FormNo";
            myDataTable.Columns.Add(myDataColumn);


            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "TellerNo";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "Amount";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "PassportNo";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "StrVisaNo";
            myDataTable.Columns.Add(myDataColumn);


            //----------------------Create People Table ---------------------------
           
            DataTable myPeopleTable = new DataTable();

            DataColumn myPeopleColumn;

            //myDataColumn = new DataColumn();
            //myDataColumn.DataType = Type.GetType("System.String");
            //myDataColumn.ColumnName = "id";
            //myDataTable.Columns.Add(myDataColumn);

           
            myPeopleColumn = new DataColumn();
            myPeopleColumn.DataType = Type.GetType("System.String");
            myPeopleColumn.ColumnName = "forename";
            myPeopleTable.Columns.Add(myPeopleColumn);

            myPeopleColumn = new DataColumn();
            myPeopleColumn.DataType = Type.GetType("System.String");
            myPeopleColumn.ColumnName = "middle_name";
            myPeopleTable.Columns.Add(myPeopleColumn);


            myPeopleColumn = new DataColumn();
            myPeopleColumn.DataType = Type.GetType("System.String");
            myPeopleColumn.ColumnName = "surname";
            myPeopleTable.Columns.Add(myPeopleColumn);

            myPeopleColumn = new DataColumn();
            myPeopleColumn.DataType = Type.GetType("System.String");
            myPeopleColumn.ColumnName = "sex";
            myPeopleTable.Columns.Add(myPeopleColumn);

            myPeopleColumn = new DataColumn();
            myPeopleColumn.DataType = Type.GetType("System.String");
            myPeopleColumn.ColumnName = "cerpac_no";
            myPeopleTable.Columns.Add(myPeopleColumn);

            myPeopleColumn = new DataColumn();
            myPeopleColumn.DataType = Type.GetType("System.String");
            myPeopleColumn.ColumnName = "cerpac_file_no";
            myPeopleTable.Columns.Add(myPeopleColumn);

            myPeopleColumn = new DataColumn();
            myPeopleColumn.DataType = Type.GetType("System.String");
            myPeopleColumn.ColumnName = "cerpac_receipt_date";
            myPeopleTable.Columns.Add(myPeopleColumn);

            myPeopleColumn = new DataColumn();
            myPeopleColumn.DataType = Type.GetType("System.String");
            myPeopleColumn.ColumnName = "cerpac_expiry_date";
            myPeopleTable.Columns.Add(myPeopleColumn);


            myPeopleColumn = new DataColumn();
            myPeopleColumn.DataType = Type.GetType("System.String");
            myPeopleColumn.ColumnName = "Passport_no";
            myPeopleTable.Columns.Add(myPeopleColumn);

            myPeopleColumn = new DataColumn();
            myPeopleColumn.DataType = Type.GetType("System.String");
            myPeopleColumn.ColumnName = "nationality";
            myPeopleTable.Columns.Add(myPeopleColumn);

            myPeopleColumn = new DataColumn();
            myPeopleColumn.DataType = Type.GetType("System.String");
            myPeopleColumn.ColumnName = "Company";
            myPeopleTable.Columns.Add(myPeopleColumn);

            myPeopleColumn = new DataColumn();
            myPeopleColumn.DataType = Type.GetType("System.String");
            myPeopleColumn.ColumnName = "Designation";
            myPeopleTable.Columns.Add(myPeopleColumn);




            //-----------------Transfer Basice Details -------------------------
            string[] lines = System.IO.File.ReadAllLines((output));

            //------------------Split Zone Name----------------------------------
            String source = lines[0];
            string[] stringSeparators = new string[] { ":" };
            var result = source.Split(stringSeparators, StringSplitOptions.None);
            String ReceivedZone = result[1];
            lblZonename.Text = lines[0];


            lblTotalRequest.Text = lines[1];
            lblFoundinDatabae.Text = lines[2];
            lblAlreadyUsedForm.Text = lines[3];
            lblFreeForm.Text = lines[4];
            //-----------------------Split Fresh Case Bank Details------------------

            String Data1 = lines[5];

            if (FileUpload1.HasFile)
            {
                if (Data1.Contains("-Cond1-"))
                {
                    Data1 = lines[5];
                    string[] stringSeparatorsdata1 = new string[] { "-Cond1-" };
                    var resultfresh = Data1.Split(stringSeparatorsdata1, StringSplitOptions.None);


                    for (int i = 1; i <= resultfresh.Count() - 2; i++)
                    {
                        String FresRow = resultfresh[i]; // lines[2];
                        string[] stringSeparatorsFresRow = new string[] { "\t" };

                        var PeopleFresRowCount = FresRow.Split(stringSeparatorsFresRow, StringSplitOptions.None);

                        //---------------------------Insert Data in DataTable------------------            

                        DataRow row;

                        row = myDataTable.NewRow();

                        //row["id"] = Guid.NewGuid().ToString();
                        row["Date1"] = PeopleFresRowCount[0];
                        row["FirstName"] = PeopleFresRowCount[1];
                        row["MiddleName"] = PeopleFresRowCount[2];
                        row["LastName"] = PeopleFresRowCount[3];
                        row["Company"] = PeopleFresRowCount[4];
                        row["Nationality"] = PeopleFresRowCount[5];
                        row["FormNo"] = PeopleFresRowCount[7];
                        row["PassportNo"] = PeopleFresRowCount[9];
                        row["StrVisaNo"] = PeopleFresRowCount[10];
                        row["TellerNo"] = PeopleFresRowCount[11];                       
                        


                        myDataTable.Rows.Add(row);
                    }
                    //--------------------Bind DataGrid by datatable-------------------------------
                    if (Page.IsPostBack)
                    {

                        Session["myDatatable"] = myDataTable;

                        this.grd_display_data.DataSource = ((DataTable)Session["myDatatable"]).DefaultView;
                        this.grd_display_data.DataBind();

                        divSearchCerpac.Visible = false;
                        divgrdCerpac.Visible = false;
                    }



                }


                if (Data1.Contains("-Cond2-"))
                {
                    Data1 = lines[5];
                    string[] stringSeparatorsdata1 = new string[] { "-Cond2-" };
                    var resultfresh = Data1.Split(stringSeparatorsdata1, StringSplitOptions.None);


                    for (int i = 1; i <= resultfresh.Count() - 2; i++)
                    {
                        String FresRow = resultfresh[i]; // lines[2];
                        string[] stringSeparatorsFresRow = new string[] { "\t" };

                        var PeopleFresRowCount = FresRow.Split(stringSeparatorsFresRow, StringSplitOptions.None);

                        //---------------------------Insert Data in DataTable------------------            

                        DataRow row;

                        row = myDataTable.NewRow();

                        row["Date1"] = PeopleFresRowCount[0];
                        row["FirstName"] = PeopleFresRowCount[1];
                        row["MiddleName"] = PeopleFresRowCount[2];
                        row["LastName"] = PeopleFresRowCount[3];
                        row["Company"] = PeopleFresRowCount[4];
                        row["Nationality"] = PeopleFresRowCount[5];
                        row["FormNo"] = PeopleFresRowCount[7];
                        row["PassportNo"] = PeopleFresRowCount[9];
                        row["StrVisaNo"] = PeopleFresRowCount[10];
                        row["TellerNo"] = PeopleFresRowCount[11];                       
                        



                        myDataTable.Rows.Add(row);
                    }
                    //--------------------Bind DataGrid by datatable-------------------------------
                    if (Page.IsPostBack)
                    {

                        Session["myDatatable"] = myDataTable;

                        this.grd_display_data.DataSource = ((DataTable)Session["myDatatable"]).DefaultView;
                        this.grd_display_data.DataBind();

                        divSearchCerpac.Visible = false;
                        divgrdCerpac.Visible = false;

                       
                    }

                    //--------------------People child-------------------------------------------
                    String Data2 = lines[6];

                    if (Data2.Contains("-Cond2-"))
                    {
                        Data2 = lines[6];
                        string[] stringSeparatorsdata2 = new string[] { "-Cond2-" };
                        var resultfresh1 = Data2.Split(stringSeparatorsdata1, StringSplitOptions.None);


                        for (int i = 1; i <= resultfresh1.Count() - 2; i++)
                        {
                            String RenewalRow = resultfresh1[i]; // lines[2];
                            string[] stringSeparatorsFresRow = new string[] { "\t" };

                            var PeopleFresRowCount = RenewalRow.Split(stringSeparatorsFresRow, StringSplitOptions.None);

                            //---------------------------Insert Data in DataTable------------------            

                            DataRow row;

                            row = myPeopleTable.NewRow();

                            //row["id"] = Guid.NewGuid().ToString();
                            row["forename"] = PeopleFresRowCount[2];
                            row["middle_name"] = PeopleFresRowCount[3];
                            row["surname"] = PeopleFresRowCount[4];
                            row["sex"] = PeopleFresRowCount[5];
                            row["cerpac_no"] = PeopleFresRowCount[15];
                            row["cerpac_file_no"] = PeopleFresRowCount[16];
                            row["Cerpac_receipt_date"] = PeopleFresRowCount[17];
                            row["Cerpac_expiry_date"] = PeopleFresRowCount[18];
                            row["passport_no"] = PeopleFresRowCount[24];
                            row["nationality"] = PeopleFresRowCount[25];
                            row["company"] = PeopleFresRowCount[49];
                            row["designation"] = PeopleFresRowCount[52];



                            myPeopleTable.Rows.Add(row);
                        }
                    }
                    //--------------------Bind DataGrid by datatable-------------------------------
                    if (Page.IsPostBack)
                    {

                        Session["myPeopleTable"] = myPeopleTable;

                        this.grd_CerpacNo.DataSource = ((DataTable)Session["myPeopleTable"]).DefaultView;
                        this.grd_CerpacNo.DataBind();

                        divSearchCerpac.Visible = true;
                        divgrdCerpac.Visible = true;
                    }



                }
                if (Data1.Contains("-Cond3-"))
                {
                    Data1 = lines[5];
                    string[] stringSeparatorsdata1 = new string[] { "-Cond3-" };
                    var resultfresh = Data1.Split(stringSeparatorsdata1, StringSplitOptions.None);


                    for (int i = 1; i <= resultfresh.Count() - 2; i++)
                    {
                        String FresRow = resultfresh[i]; // lines[2];
                        string[] stringSeparatorsFresRow = new string[] { "\t" };

                        var PeopleFresRowCount = FresRow.Split(stringSeparatorsFresRow, StringSplitOptions.None);

                        //---------------------------Insert Data in DataTable------------------            

                        DataRow row;

                        row = myDataTable.NewRow();

                        row["Date1"] = PeopleFresRowCount[0];
                        row["FirstName"] = PeopleFresRowCount[1];
                        row["MiddleName"] = PeopleFresRowCount[2];
                        row["LastName"] = PeopleFresRowCount[3];
                        row["Company"] = PeopleFresRowCount[4];
                        row["Nationality"] = PeopleFresRowCount[5];
                        row["FormNo"] = PeopleFresRowCount[7];
                        row["PassportNo"] = PeopleFresRowCount[9];
                        row["StrVisaNo"] = PeopleFresRowCount[10];
                        row["TellerNo"] = PeopleFresRowCount[11];                       
                        



                        myDataTable.Rows.Add(row);
                    }
                    Data1 = lines[6];
                    string[] stringSeparatorsdata2 = new string[] { "-Cond3-" };
                    var resultRenewal = Data1.Split(stringSeparatorsdata2, StringSplitOptions.None);


                    for (int i = 1; i <= resultRenewal.Count() - 2; i++)
                    {
                        String FresRow = resultRenewal[i]; // lines[2];
                        string[] stringSeparatorsFresRow = new string[] { "\t" };

                        var PeopleFresRowCount = FresRow.Split(stringSeparatorsFresRow, StringSplitOptions.None);

                        //---------------------------Insert Data in DataTable------------------            

                        DataRow row;

                        row = myDataTable.NewRow();
                        row["Date1"] = PeopleFresRowCount[0];
                        row["FirstName"] = PeopleFresRowCount[1];
                        row["MiddleName"] = PeopleFresRowCount[2];
                        row["LastName"] = PeopleFresRowCount[3];
                        row["Company"] = PeopleFresRowCount[4];
                        row["Nationality"] = PeopleFresRowCount[5];
                        row["FormNo"] = PeopleFresRowCount[7];
                        row["PassportNo"] = PeopleFresRowCount[9];
                        row["StrVisaNo"] = PeopleFresRowCount[10];
                        row["TellerNo"] = PeopleFresRowCount[11];                       
                       



                        myDataTable.Rows.Add(row);
                    }
                    //--------------------Bind DataGrid by datatable-------------------------------
                    if (Page.IsPostBack)
                    {

                        Session["myDatatable"] = myDataTable;

                        this.grd_display_data.DataSource = ((DataTable)Session["myDatatable"]).DefaultView;
                        this.grd_display_data.DataBind();

                        divSearchCerpac.Visible = false;
                        divgrdCerpac.Visible = false;
                    }

                    //----------------------------People----------------------------------------------
                    String Data3 = lines[7];

                    if (Data3.Contains("-Cond3-"))
                    {
                        Data3 = lines[7];
                        string[] stringSeparatorsdata3 = new string[] { "-Cond3-" };
                        var resultfresh1 = Data3.Split(stringSeparatorsdata3, StringSplitOptions.None);


                        for (int i = 1; i <= resultfresh1.Count() - 2; i++)
                        {
                            String RenewalRow = resultfresh1[i]; // lines[2];
                            string[] stringSeparatorsFresRow = new string[] { "\t" };

                            var PeopleFresRowCount = RenewalRow.Split(stringSeparatorsFresRow, StringSplitOptions.None);

                            //---------------------------Insert Data in DataTable------------------            

                            DataRow row;

                            row = myPeopleTable.NewRow();

                            //row["id"] = Guid.NewGuid().ToString();
                            row["forename"] = PeopleFresRowCount[2];
                            row["middle_name"] = PeopleFresRowCount[3];
                            row["surname"] = PeopleFresRowCount[4];
                            row["sex"] = PeopleFresRowCount[5];
                            row["cerpac_no"] = PeopleFresRowCount[15];
                            row["cerpac_file_no"] = PeopleFresRowCount[16];
                            row["Cerpac_receipt_date"] = PeopleFresRowCount[17];
                            row["Cerpac_expiry_date"] = PeopleFresRowCount[18];
                            row["passport_no"] = PeopleFresRowCount[24];
                            row["nationality"] = PeopleFresRowCount[25];
                            row["company"] = PeopleFresRowCount[49];
                            row["designation"] = PeopleFresRowCount[52];



                            myPeopleTable.Rows.Add(row);
                        }

                    }
                    //--------------------Bind DataGrid by datatable-------------------------------
                    if (Page.IsPostBack)
                    {

                        Session["myPeopleTable"] = myPeopleTable;

                        this.grd_CerpacNo.DataSource = ((DataTable)Session["myPeopleTable"]).DefaultView;
                        this.grd_CerpacNo.DataBind();

                        divSearchCerpac.Visible = true;
                        divgrdCerpac.Visible = true;
                    }


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

    public void SaveBankDetails()
    {
        String found = "";
        //------------------Bank Detials Grid----------------------------------------------------------------------------------
        for (int i = 0; i <= grd_display_data.Rows.Count - 1; i++)
        {

            SqlConnection ConnectionZone = new SqlConnection();
            ConnectionZone.ConnectionString = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
           
            //-----------Convert date formate ()-------------
            var culture = System.Globalization.CultureInfo.CurrentCulture;

            string sysFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
            string[] formats = { "M/d/yyyy", "M/dd/yyyy", "MM/dd/yyyy", "M/d/yy", "M/dd/yy", "MM/dd/yy",
                                              "M-d-yyyy", "M-dd-yyyy", "MM-dd-yyyy", "M-d-yy", "M-dd-yy", "MM-dd-yy",
                                             "d/M/yyyy", "dd/M/yyyy", "dd/MM/yyyy", "d/M/yy", "dd/M/yy", "dd/MM/yy",
                                             "d-M-yyyy", "dd-M-yyyy", "dd-MM-yyyy", "d-M-yy", "dd-M-yy", "dd-MM-yy",
                                             "d-MMM-yy", "dd-MMM-yy", "d-MMMM-yyyy","dd-MMMM-yyyy", };
            DateTime date;
            if (DateTime.TryParseExact(grd_display_data.Rows[i].Cells[0].Text, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                date.ToString(sysFormat);
            
            //------------------Select form in Bank Database-------------------------------------

            objgenenral = new BaseLayer.General_function();
            string QuerCountFound = "select count(*) from uploaded_excel_data where formno in ('" + grd_display_data.Rows[i].Cells[6].Text.Trim() + "')";
           
                DataTable dt = new DataTable();
                dt = objgenenral.FetchData(QuerCountFound);
                
                //------------------Insert Bank Form in Zone Database--------------------------------------
                   
                if (dt.Rows[0].ItemArray[0].ToString() == "0")
                {
                    //SqlCommand CommandZone = new SqlCommand("INSERT INTO  Uploaded_Excel_Data(RecordNo, Date1, FirstName,	MiddleName , LastName, Company, Nationality, FormNo	, PassportNo, StrVisaNo, tellerno, CreatedBY, CreatedON,RequisitionNO,Amount) " +
                    //                                        " VALUES ( (select max(recordno)+1 from uploaded_excel_data),'" + date.ToString(sysFormat).Trim() + "','" + grd_display_data.Rows[i].Cells[1].Text + "','" + grd_display_data.Rows[i].Cells[2].Text + "','" + grd_display_data.Rows[i].Cells[3].Text + "','" + grd_display_data.Rows[i].Cells[4].Text + "','" + grd_display_data.Rows[i].Cells[5].Text + "','" + grd_display_data.Rows[i].Cells[6].Text + "','" + grd_display_data.Rows[i].Cells[7].Text + "','" + grd_display_data.Rows[i].Cells[8].Text + "','" + grd_display_data.Rows[i].Cells[9].Text + "','" + objectSessionHolderPersistingData.User_ID + "',GETDATE(),0,0)   ", ConnectionZone);

                    if (DateTimeFormatInfo.CurrentInfo.ShortDatePattern.ToCharArray()[0].ToString() == "d")
                    {
                        sysFormat = "MM-dd-yyyy";
                    }
                    
                    string d = DateTimeFormatInfo.CurrentInfo.ShortDatePattern.ToCharArray()[0].ToString();
                    SqlCommand CommandZone = new SqlCommand("INSERT INTO  Uploaded_Excel_Data(RecordNo, Date1, FirstName,	MiddleName , LastName, Company, Nationality, FormNo	, PassportNo, StrVisaNo, tellerno, CreatedBY, CreatedON,RequisitionNO,Amount) " +
                                                           " VALUES ( (select max(isnull(recordno,0))+1 from uploaded_excel_data),'" + (grd_display_data.Rows[i].Cells[0].Text.ToString().Trim()) + "','" + grd_display_data.Rows[i].Cells[1].Text + "','" + grd_display_data.Rows[i].Cells[2].Text + "','" + grd_display_data.Rows[i].Cells[3].Text + "','" + grd_display_data.Rows[i].Cells[4].Text + "','" + grd_display_data.Rows[i].Cells[5].Text + "','" + grd_display_data.Rows[i].Cells[6].Text + "','" + grd_display_data.Rows[i].Cells[7].Text + "','" + grd_display_data.Rows[i].Cells[8].Text + "','" + grd_display_data.Rows[i].Cells[9].Text + "','" + objectSessionHolderPersistingData.User_ID + "',GETDATE(),0,0)   ", ConnectionZone);
                    ConnectionZone.Open();
                    CommandZone.ExecuteNonQuery();
                    ConnectionZone.Close();
                }
                else
                {

                    found = found + grd_display_data.Rows[i].Cells[6].Text.Trim() + ",";

                }
            
            
        }
        if (found != "")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Form no.: " + found + " already uploaded by central.'); window.location = '" + Page.ResolveUrl("frmImportCentralResponseBankData.aspx") + "';", true);

        }

        //-----------Convert date formate ()-------------
        var culture1 = System.Globalization.CultureInfo.CurrentCulture;

        string sysFormat1 = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
        string[] formats1 = { "M/d/yyyy", "M/dd/yyyy", "MM/dd/yyyy", "M/d/yy", "M/dd/yy", "MM/dd/yy",
                                              "M-d-yyyy", "M-dd-yyyy", "MM-dd-yyyy", "M-d-yy", "M-dd-yy", "MM-dd-yy",
                                             "d/M/yyyy", "dd/M/yyyy", "dd/MM/yyyy", "d/M/yy", "dd/M/yy", "dd/MM/yy",
                                             "d-M-yyyy", "dd-M-yyyy", "dd-MM-yyyy", "d-M-yy", "dd-M-yy", "dd-MM-yy",
                                             "d-MMM-yy", "dd-MMM-yy", "d-MMMM-yyyy","dd-MMMM-yyyy", };
        DateTime date1;
        if (DateTime.TryParseExact(DateTime.Now.ToShortDateString(), formats1, CultureInfo.InvariantCulture, DateTimeStyles.None, out date1))
            date1.ToString(sysFormat1);


        //---------------Audit trail in bank request formno.'s---------------------
        string AlreadyReq = "";
        for (int i = 0; i <= grd_display_data.Rows.Count - 1; i++)
        {
            //-----------------Search in uploaded_excel_data_C table--------------------
            ObjGenBal = new BaseLayer.General_function();
            string QuerCountFound = "select count(*) from uploaded_excel_data_C where  Formno='" + grd_display_data.Rows[i].Cells[6].Text.Trim() + "'";

            DataTable dt = new DataTable();
            dt = ObjGenBal.FetchData(QuerCountFound);
            if (dt.Rows[0].ItemArray[0].ToString() != "0")
            {

                //--------------------------Insert--------------------------------   

                SqlConnection Connection = new SqlConnection();
                Connection.ConnectionString = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
                if (DateTimeFormatInfo.CurrentInfo.ShortDatePattern.ToCharArray()[0].ToString() == "d")
                {
                    sysFormat1 = "MM-dd-yyyy";
                }
                SqlCommand Command = new SqlCommand("update uploaded_excel_data_C set bank_flag=1, bank_resp_userid ='" + UserID.ToString().Trim() + "', bank_resp_date=getdate() where formno = '" + grd_display_data.Rows[i].Cells[6].Text.Trim() + "'", Connection);
                Connection.Open();
                Command.ExecuteNonQuery();
                Connection.Close();
                
            }
            else
            {
                AlreadyReq = AlreadyReq + grd_display_data.Rows[i].Cells[6].Text.Trim() + " ";
            }



        }
        //-------------------After save successfully------------------------------
        if (AlreadyReq != "")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Form no.: " + AlreadyReq + " already uploaded by central.'); window.location = '" + Page.ResolveUrl("frmImportCentralResponseBankData.aspx") + "';", true);

        }
    }
    public void SavePeopleDetails()
    {
        //-----------------Transfer Basice Details -------------------------
        string[] lines = System.IO.File.ReadAllLines((output));
        //----------------Splict people table date for Renweal Case-------------
        String Data2 = lines[6];

        if (Data2.Contains("-Cond2-"))
        {
            Data2 = lines[6];
            string[] stringSeparatorsdata2 = new string[] { "-Cond2-" };
            var resultfresh1 = Data2.Split(stringSeparatorsdata2, StringSplitOptions.None);


            for (int i = 1; i <= resultfresh1.Count() - 2; i++)
            {
                String RenewalRow = resultfresh1[i]; // lines[2];
                string[] stringSeparatorsFresRow = new string[] { "\t" };

                var PeopleRowCount = RenewalRow.Split(stringSeparatorsFresRow, StringSplitOptions.None);


                //-----------------Search in People table--------------------
                objgenenral = new BaseLayer.General_function();
                string QuerCountFound = "select count(*) from people where cerpac_no in ('" + PeopleRowCount[15].Trim() + "')";

                DataTable dt = new DataTable();
                dt = objgenenral.FetchData(QuerCountFound);
                if (dt.Rows[0].ItemArray[0].ToString() != "0")
                {
                    //--------------------------Update------------------------------
                    SqlConnection Connection = new SqlConnection();
                    Connection.ConnectionString = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;

                    SqlCommand Command = new SqlCommand("update People set title='" + PeopleRowCount[1].Trim() + "', forename ='" + PeopleRowCount[2].Trim() + "', middle_name ='" + PeopleRowCount[3].Trim() + "', surname ='" + PeopleRowCount[4].Trim() + "', sex ='" + PeopleRowCount[5].Trim() + "', cerpac_file_no ='" + PeopleRowCount[16].Trim() + "', cerpac_expiry_date ='" + (PeopleRowCount[17].Trim()) + "', cerpac_receipt_date ='" + (PeopleRowCount[18].Trim()) + "', passport_no ='" + PeopleRowCount[24].Trim() + "', nationality ='" + PeopleRowCount[25].Trim() + "', company ='" + PeopleRowCount[38].Trim() + "', designation= '" + PeopleRowCount[41].Trim() +  "' where cerpac_no = '" + PeopleRowCount[15].Trim() + "'", Connection);
                    Connection.Open();
                    Command.ExecuteNonQuery();
                    Connection.Close();
                    //return;

                }
                else
                {
                    //--------------------------Insert--------------------------------   

                    SqlConnection Connection = new SqlConnection();
                    Connection.ConnectionString = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;

                    SqlCommand Command = new SqlCommand("Insert into people ([title],[forename],[middle_name],[surname],[sex],[residence_permit_no],[residence_issue_loc]" +
                                                        ",[deedmark_no],[printed],[label_print_count],[card_print_count],[picture],[directory],[notes]" +
                                                        ",[cerpac_no],[cerpac_file_no],[cerpac_receipt_date],[cerpac_expiry_date],[registration_area],[registration_code]" +
                                                        ",[file_no],[label_no],[book_no],[passport_no],[nationality],[passport_issue_date],[passport_expiry_date]" +
                                                        ",[passport_issue_loc],[passport_issue_by],[date_of_birth],[place_of_birth],[nigeria_add_1],[nigeria_add_2]" +
                                                        ",[nigeria_tel_no],[abroad_add_1],[abroad_add_2],[abroad_tel_no],[company],[company_add_1],[company_add_2]" +
                                                        ",[designation],[employment_date],[company_tel_no],[company_fax_no],[email],[date_added],[added_by_user_id]" +
                                                        ",[date_modified],[modified_by_user_id],[picture_taken],[picture_by_user_id],[verid_template],[verid_template_1]" +
                                                        ",[arcanet_2d_command],[date_system_modified],[ContactNo])" +
                                                        "Values('" + PeopleRowCount[1].Trim() + "','" + PeopleRowCount[2].Trim() + "','" + PeopleRowCount[3].Trim() + "','" + PeopleRowCount[4].Trim() + "','" + PeopleRowCount[5].Trim() + "','" + PeopleRowCount[6].Trim() + "','" + PeopleRowCount[7].Trim() + "','" + PeopleRowCount[8].Trim() +
                                                             "','" + PeopleRowCount[9].Trim() + "','" + PeopleRowCount[10].Trim() + "','" + PeopleRowCount[11].Trim() + "','" + PeopleRowCount[12].Trim() + "','" + PeopleRowCount[13].Trim() + "','" + PeopleRowCount[14].Trim() + "','" + PeopleRowCount[15].Trim() + "','" + PeopleRowCount[16].Trim() +
                                                             "','" + (PeopleRowCount[17].Trim()) + "','" + (PeopleRowCount[18].Trim()) + "','" + PeopleRowCount[19].Trim() + "','" + PeopleRowCount[20].Trim() + "','" + PeopleRowCount[21].Trim() + "','" + PeopleRowCount[22].Trim() +
                                                             "','" + PeopleRowCount[23].Trim() + "','" + PeopleRowCount[24].Trim() + "','" + PeopleRowCount[25].Trim() + "','" + (PeopleRowCount[26].Trim()) + "','" + (PeopleRowCount[27].Trim()) + "','" + PeopleRowCount[28].Trim() + "','" + PeopleRowCount[29].Trim() +
                                                             "','" + (PeopleRowCount[30].Trim()) + "','" + PeopleRowCount[31].Trim() + "','" + PeopleRowCount[32].Trim() + "','" + PeopleRowCount[33].Trim() + "','" + PeopleRowCount[34].Trim() + "','" + PeopleRowCount[35].Trim() +
                                                             "','" + PeopleRowCount[36].Trim() + "','" + PeopleRowCount[37].Trim() + "','" + PeopleRowCount[38].Trim() + "','" + PeopleRowCount[39].Trim() + "','" + PeopleRowCount[40].Trim() + "','" + (PeopleRowCount[41].Trim()) + "','" + (PeopleRowCount[42].Trim()) +
                                                             "','" + PeopleRowCount[43].Trim() + "','" + PeopleRowCount[44].Trim() + "','" + (PeopleRowCount[45].Trim()) + "','" + (PeopleRowCount[46].Trim()) + "','" + (PeopleRowCount[47].Trim()) + "','" + (PeopleRowCount[48].Trim()) + "','" + PeopleRowCount[49].Trim() +
                                                             "','" + PeopleRowCount[50].Trim() + "','" + PeopleRowCount[51].Trim() + "','" + PeopleRowCount[52].Trim() + "','" + PeopleRowCount[53].Trim() + "','" + PeopleRowCount[54].Trim() + "','" + (PeopleRowCount[55].Trim()) +
                                                             "','" + PeopleRowCount[56].Trim() + "')", Connection);

                    Connection.Open();
                    Command.ExecuteNonQuery();
                    Connection.Close();
                }

                //-------------------Import image in people table-------------------------------

                // Convert Base64 String to byte[]
                byte[] imageBytes = Convert.FromBase64String(PeopleRowCount[57].ToString().Trim());
                MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);

                // Convert byte[] to Image
                ms.Write(imageBytes, 0, imageBytes.Length);
                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(ms);


                byte[] data = null;

                ImageConverter converter = new ImageConverter();
                data = (byte[])converter.ConvertTo(bmp, typeof(byte[]));

                ms.Close();

                SqlConnection Connection1 = new SqlConnection();
                Connection1.ConnectionString = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;

                SqlCommand Command1 = new SqlCommand("update people set userImage=@ImageFile where cerpac_no in ('" + PeopleRowCount[15].ToString().Trim() + "')", Connection1);

                SqlParameter imageFileParameter = new SqlParameter("@ImageFile", SqlDbType.Image);
                imageFileParameter.Value = data;
                Command1.Parameters.Add(imageFileParameter);

                Connection1.Open();
                Command1.ExecuteNonQuery();
                Connection1.Close();
                //------------------------------------------------

            }
        }
       
    }
    public void savePeopleDetailsboth()
    {
        //-----------------Transfer Basice Details -------------------------
        string[] lines = System.IO.File.ReadAllLines((output));
     
        //----------------Split People Table Data for both case------------------
        String Data3 = lines[7];

        if (Data3.Contains("-Cond3-"))
        {
            Data3 = lines[7];
            string[] stringSeparatorsdata3 = new string[] { "-Cond3-" };
            var resultfresh1 = Data3.Split(stringSeparatorsdata3, StringSplitOptions.None);


            for (int i = 1; i <= resultfresh1.Count() - 2; i++)
            {
                String RenewalRow = resultfresh1[i]; // lines[2];
                string[] stringSeparatorsFresRow = new string[] { "\t" };

                var PeopleRowCount = RenewalRow.Split(stringSeparatorsFresRow, StringSplitOptions.None);


                //-----------------Search in People table--------------------
                objgenenral = new BaseLayer.General_function();
                string QuerCountFound = "select count(*) from people where cerpac_no in ('" + PeopleRowCount[15].Trim() + "')";

                DataTable dt = new DataTable();
                dt = objgenenral.FetchData(QuerCountFound);
                if (dt.Rows[0].ItemArray[0].ToString() != "0")
                {
                    //--------------------------Update------------------------------
                    SqlConnection Connection = new SqlConnection();
                    Connection.ConnectionString = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;

                    SqlCommand Command = new SqlCommand("update People set title='" + PeopleRowCount[1].Trim() + "', forename ='" + PeopleRowCount[2].Trim() + "', middle_name ='" + PeopleRowCount[3].Trim() + "', surname ='" + PeopleRowCount[4].Trim() + "', sex ='" + PeopleRowCount[5].Trim() + "', cerpac_file_no ='" + PeopleRowCount[16].Trim() + "', cerpac_expiry_date ='" + (PeopleRowCount[17].Trim()) + "', cerpac_receipt_date ='" + (PeopleRowCount[18].Trim()) + "', passport_no ='" + PeopleRowCount[24].Trim() + "', nationality ='" + PeopleRowCount[25].Trim() + "', company ='" + PeopleRowCount[38].Trim() + "', designation= '" + PeopleRowCount[41].Trim() + "' where cerpac_no = '" + PeopleRowCount[15].Trim() + "'", Connection);
                    Connection.Open();
                    Command.ExecuteNonQuery();
                    Connection.Close();
                    //return;

                }
                else
                {
                    //--------------------------Insert--------------------------------   

                    SqlConnection Connection = new SqlConnection();
                    Connection.ConnectionString = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;


                    SqlCommand Command = new SqlCommand("Insert into people ([title],[forename],[middle_name],[surname],[sex],[residence_permit_no],[residence_issue_loc]" +
                                                        ",[deedmark_no],[printed],[label_print_count],[card_print_count],[picture],[directory],[notes]" +
                                                        ",[cerpac_no],[cerpac_file_no],[cerpac_receipt_date],[cerpac_expiry_date],[registration_area],[registration_code]" +
                                                        ",[file_no],[label_no],[book_no],[passport_no],[nationality],[passport_issue_date],[passport_expiry_date]" +
                                                        ",[passport_issue_loc],[passport_issue_by],[date_of_birth],[place_of_birth],[nigeria_add_1],[nigeria_add_2]" +
                                                        ",[nigeria_tel_no],[abroad_add_1],[abroad_add_2],[abroad_tel_no],[company],[company_add_1],[company_add_2]" +
                                                        ",[designation],[employment_date],[company_tel_no],[company_fax_no],[email],[date_added],[added_by_user_id]" +
                                                        ",[date_modified],[modified_by_user_id],[picture_taken],[picture_by_user_id],[verid_template],[verid_template_1]" +
                                                        ",[arcanet_2d_command],[date_system_modified],[ContactNo])" +
                                                        "Values('" + PeopleRowCount[1].Trim() + "','" + PeopleRowCount[2].Trim() + "','" + PeopleRowCount[3].Trim() + "','" + PeopleRowCount[4].Trim() + "','" + PeopleRowCount[5].Trim() + "','" + PeopleRowCount[6].Trim() + "','" + PeopleRowCount[7].Trim() + "','" + PeopleRowCount[8].Trim() +
                                                             "','" + PeopleRowCount[9].Trim() + "','" + PeopleRowCount[10].Trim() + "','" + PeopleRowCount[11].Trim() + "','" + PeopleRowCount[12].Trim() + "','" + PeopleRowCount[13].Trim() + "','" + PeopleRowCount[14].Trim() + "','" + PeopleRowCount[15].Trim() + "','" + PeopleRowCount[16].Trim() +
                                                             "','" + (PeopleRowCount[17].Trim()) + "','" + (PeopleRowCount[18].Trim()) + "','" + PeopleRowCount[19].Trim() + "','" + PeopleRowCount[20].Trim() + "','" + PeopleRowCount[21].Trim() + "','" + PeopleRowCount[22].Trim() +
                                                             "','" + PeopleRowCount[23].Trim() + "','" + PeopleRowCount[24].Trim() + "','" + PeopleRowCount[25].Trim() + "','" + (PeopleRowCount[26].Trim()) + "','" + (PeopleRowCount[27].Trim()) + "','" + PeopleRowCount[28].Trim() + "','" + PeopleRowCount[29].Trim() +
                                                             "','" + (PeopleRowCount[30].Trim()) + "','" + PeopleRowCount[31].Trim() + "','" + PeopleRowCount[32].Trim() + "','" + PeopleRowCount[33].Trim() + "','" + PeopleRowCount[34].Trim() + "','" + PeopleRowCount[35].Trim() +
                                                             "','" + PeopleRowCount[36].Trim() + "','" + PeopleRowCount[37].Trim() + "','" + PeopleRowCount[38].Trim() + "','" + PeopleRowCount[39].Trim() + "','" + PeopleRowCount[40].Trim() + "','" + (PeopleRowCount[41].Trim()) + "','" + (PeopleRowCount[42].Trim()) +
                                                             "','" + PeopleRowCount[43].Trim() + "','" + PeopleRowCount[44].Trim() + "','" + (PeopleRowCount[45].Trim()) + "','" + (PeopleRowCount[46].Trim()) + "','" + (PeopleRowCount[47].Trim()) + "','" + (PeopleRowCount[48].Trim()) + "','" + PeopleRowCount[49].Trim() +
                                                             "','" + PeopleRowCount[50].Trim() + "','" + PeopleRowCount[51].Trim() + "','" + PeopleRowCount[52].Trim() + "','" + PeopleRowCount[53].Trim() + "','" + PeopleRowCount[54].Trim() + "','" +(PeopleRowCount[55].Trim()) +
                                                             "','" + PeopleRowCount[56].Trim() + "')", Connection);

                    Connection.Open();
                    Command.ExecuteNonQuery();
                    Connection.Close();
                }

                //-------------------Import image in people table-------------------------------

                // Convert Base64 String to byte[]
                byte[] imageBytes = Convert.FromBase64String(PeopleRowCount[57].ToString().Trim());
                MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);

                // Convert byte[] to Image
                ms.Write(imageBytes, 0, imageBytes.Length);
                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(ms);


                byte[] data = null;

                ImageConverter converter = new ImageConverter();
                data = (byte[])converter.ConvertTo(bmp, typeof(byte[]));

                ms.Close();

                SqlConnection Connection1 = new SqlConnection();
                Connection1.ConnectionString = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;

                SqlCommand Command1 = new SqlCommand("update people set userImage=@ImageFile where cerpac_no in ('" + PeopleRowCount[15].ToString().Trim() + "')", Connection1);

                SqlParameter imageFileParameter = new SqlParameter("@ImageFile", SqlDbType.Image);
                imageFileParameter.Value = data;
                Command1.Parameters.Add(imageFileParameter);

                Connection1.Open();
                Command1.ExecuteNonQuery();
                Connection1.Close();
                //------------------------------------------------

            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)    
    {
        try
        {
           
           string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            filePath = filePath + @"\";

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            divbrowsefile.Visible = false;
            divSearchResult.Visible = true;
            divgrd.Visible = true;
            divCrefile.Visible = true;


            
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


                String ZoneN = lblZonename.Text.Trim();
                String Data1;

                string[] stringSeparators = new string[] { ":" };
                var result = ZoneN.Split(stringSeparators, StringSplitOptions.None);
                ZoneN = result[1].Trim();

                Data1 = lines[5];

                if (ZoneN == ZoneDetails)
                {
                    if (Data1.Contains("-Cond1-"))
                    {
                        SaveBankDetails();
                        File.Delete(input);
                        File.Delete(output);
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Sucessfully  Import Bank Response file  !!.'); window.location = '" + Page.ResolveUrl("frmImportCentralResponseBankData.aspx") + "';", true);

                    }
                    else if (Data1.Contains("-Cond2-"))
                    {
                        SaveBankDetails();
                        SavePeopleDetails();
                        File.Delete(input);
                        File.Delete(output);
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Sucessfully  Import Bank Response file  !!.'); window.location = '" + Page.ResolveUrl("frmImportCentralResponseBankData.aspx") + "';", true);

                    }
                    else if (Data1.Contains("-Cond3-"))
                    {
                        SaveBankDetails();
                        savePeopleDetailsboth();
                        File.Delete(input);
                        File.Delete(output);
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Sucessfully  Import Bank Response file  !!.'); window.location = '" + Page.ResolveUrl("frmImportCentralResponseBankData.aspx") + "';", true);
                    
                    }
                }

                else
                {
                    File.Delete(input);
                    File.Delete(output);
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please contact to System Adminsitrator at Abuja !!.'); window.location = '" + Page.ResolveUrl("frmImportCentralResponseBankData.aspx") + "';", true);


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
    
}