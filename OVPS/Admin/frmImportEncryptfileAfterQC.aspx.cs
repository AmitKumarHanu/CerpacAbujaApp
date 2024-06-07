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
using System.Drawing;
using System.Drawing.Imaging;


public partial class Admin_frmImportEncryptfileAfterQC : System.Web.UI.Page
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
    string UserID = null, ZoneDetails = null;
    string output, input, Cerptxt = "", CerpFiletxt = "";
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
                divbrowsefile.Visible = true;
                divCrefile.Visible = false;
                divgrd.Visible = false;
                divSearchResult.Visible = false;
                
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
            divbrowsefile.Visible = true;
            divSearchResult.Visible = false;
            divgrd.Visible = true;
            divCrefile.Visible = true;

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

            input = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + fileName + fileExtension;
            ViewState["InputFile"] = input;


            output = filePath + @"\" + fileName + "_dec" + fileExtension;
            ViewState["OutputFile"] = output;

            //Save the Input File, Decrypt it and save the decrypted file in output path.
            this.Decrypt(input, output);
            BindGrid();
           
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

                   
            string[] lines = System.IO.File.ReadAllLines((output));

            
            //---------------------------Split Encrypt file ------------------

           
                String ZoneName = lines[0];
                string[] stringSeparatorsZoneName = new string[] { "\t" };
                var ZoneNameCount = ZoneName.Split(stringSeparatorsZoneName, StringSplitOptions.None);

             
                //----------------Split People Table Data------------------
                String People = lines[3];
                string[] stringSeparatorsPeople = new string[] { "-###-" };
                var PeopleCount = People.Split(stringSeparatorsPeople, StringSplitOptions.None);
                for (int i = 1; i <= PeopleCount.Count() - 2; i++)
                {
                    String PeopleRow = PeopleCount[i]; // lines[2];
                    string[] stringSeparatorsPeopleRow = new string[] { "\t" };

                    var PeopleRowCount = PeopleRow.Split(stringSeparatorsPeopleRow, StringSplitOptions.None);
                   
                        //-----------------Search in People table--------------------
                        objgenenral = new BaseLayer.General_function();
                        string QuerCountFound = "select count(*) from people where cerpac_no in ('" + PeopleRowCount[15].Trim() + "')";

                        DataTable dt = new DataTable();
                        dt = objgenenral.FetchData(QuerCountFound);
                        if (dt.Rows[0].ItemArray[0].ToString()  != "0")
                        {
                            //--------------------------Update------------------------------
                            SqlConnection Connection = new SqlConnection();
                            Connection.ConnectionString = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;

                            SqlCommand Command = new SqlCommand("update People set forename ='" + PeopleRowCount[2].Trim() + "', middle_name ='" + PeopleRowCount[3].Trim() + "', surname ='" + PeopleRowCount[4].Trim() + "', sex ='" + PeopleRowCount[5].Trim() + "', cerpac_file_no ='" + PeopleRowCount[16].Trim() + "', cerpac_expiry_date ='" + PeopleRowCount[18].Trim() + "', cerpac_receipt_date ='" + PeopleRowCount[17].Trim() + "', passport_no ='" + PeopleRowCount[24].Trim() + "', nationality ='" + PeopleRowCount[25].Trim() + "', company ='" + PeopleRowCount[38].Trim() + "', designation= '" + PeopleRowCount[41].Trim() + "' where cerpac_no = '" + PeopleRowCount[15].Trim() + "'", Connection);
                            Connection.Open();
                            Command.ExecuteNonQuery();
                            Connection.Close();
                            //return;

                        }
                        
                }
            
          
           
            //---------------------Split PeopleChild Data------------------------------------

                String PeopleChild = lines[4];
                string[] stringSeparatorsPeopleChild = new string[] { "-###-" };
                var PeopleChildCount = PeopleChild.Split(stringSeparatorsPeopleChild, StringSplitOptions.None);
                for (int i = 1; i <= PeopleChildCount.Count() - 2; i++)
                {
                    String PeopleChildRow = PeopleChildCount[i]; // lines[2];
                    string[] stringSeparatorsPeopleChildRow = new string[] { "\t" };

                    var PeopleChildRowCount = PeopleChildRow.Split(stringSeparatorsPeopleChildRow, StringSplitOptions.None);
                   
                        //-----------------Search in PeopleChild table--------------------
                        objgenenral = new BaseLayer.General_function();
                        string QuerCountFound = "select count(*) from peoplechild where cerpacno in ('" + PeopleChildRowCount[7].Trim() + "') and formno='" + PeopleChildRowCount[4].Trim() + "'";

                        DataTable dt = new DataTable();
                        dt = objgenenral.FetchData(QuerCountFound);
                        if (dt.Rows[0].ItemArray[0].ToString()  != "0")
                        {
                            //--------------------------Update------------------------------
                            SqlConnection Connection = new SqlConnection();
                            Connection.ConnectionString = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;

                            SqlCommand Command = new SqlCommand("update PeopleChild set  IsVerified ='" + PeopleChildRowCount[15].Trim() + "', IsAuthorized ='" + PeopleChildRowCount[16].Trim() +  "', ISARCR='" + PeopleChildRowCount[35].Trim() + "',ConfirmedBy='" + PeopleChildRowCount[36].Trim() + "',ConfirmedOn='" + PeopleChildRowCount[37].Trim() +"', IsProduced ='" + PeopleChildRowCount[17].Trim() + "', VerifiedBy ='" + PeopleChildRowCount[18].Trim() + "', AuthorizedBy ='" + PeopleChildRowCount[19].Trim() + "', ProducedBy ='" + PeopleChildRowCount[20].Trim() + "', ProducedOn ='" + PeopleChildRowCount[21].Trim() + "', AuthorizedOn='" + PeopleChildRowCount[22].Trim() + "', VerifiedOn ='" + PeopleChildRowCount[23].Trim() + "', IsRejected ='" + PeopleChildRowCount[24].Trim() + "', RejectedBy ='" + PeopleChildRowCount[25].Trim() + "', RejectedOn ='" + PeopleChildRowCount[26].Trim() + "', RejectionReason  ='" + PeopleChildRowCount[27].Trim() + "',cerpac_expiry_date ='" + PeopleChildRowCount[38].Trim() + "', cerpac_receipt_date ='" + PeopleChildRowCount[39].Trim() + "', IsQual ='" + PeopleChildRowCount[40].Trim() + "', QualBy ='" + PeopleChildRowCount[41].Trim() + "', QualOn ='" + PeopleChildRowCount[42].Trim() + "', BrownOn ='" + PeopleChildRowCount[43].Trim() + "', BrownBY ='" + PeopleChildRowCount[44].Trim() + "', IsBrown ='" + PeopleChildRowCount[45].Trim() + "', IsStickerPrinted ='" + PeopleChildRowCount[46].Trim() + "', StickerPrintedBy ='" + PeopleChildRowCount[47].Trim() + "', StickerPrintedOn ='" + PeopleChildRowCount[48].Trim() + "' where cerpacno in ('" + PeopleChildRowCount[7].Trim() + "') and formno='" + PeopleChildRowCount[4].Trim() + "'", Connection);
                            Connection.Open();
                            Command.ExecuteNonQuery();
                            Connection.Close();
                    
                        }
                       
                }
            
            //---------------------Split CerpacOn_Out_One table Data------------------------------------

            String CrOutOne = lines[5];
            string[] stringSeparatorsCrOutOne = new string[] { "-###-" };
            var CrOutOneCount = CrOutOne.Split(stringSeparatorsCrOutOne, StringSplitOptions.None);
            for (int i = 1; i <= CrOutOneCount.Count() - 2; i++)
            {
                String CrOutOnRow = CrOutOneCount[i]; // lines[2];
                string[] stringSeparatorsCrOutOnRow = new string[] { "\t" };

                var CrOutOnCount = CrOutOnRow.Split(stringSeparatorsCrOutOnRow, StringSplitOptions.None);

                //-----------------Search in CerpacOn_Out_One table--------------------
                objgenenral = new BaseLayer.General_function();
                string QuerCountFound = "select count(*) from CerpacNo_Out_One where  cerpac_no='" + CrOutOnCount[1].Trim() + "' and cerpac_file_no='" + CrOutOnCount[9].Trim() + "'";

                DataTable dt = new DataTable();
                dt = objgenenral.FetchData(QuerCountFound);
                if (dt.Rows[0].ItemArray[0].ToString() != "0")
                {
                   
                    ////--------------------------Update------------------------------
                    SqlConnection Connection = new SqlConnection();
                    Connection.ConnectionString = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
                    SqlCommand Command = new SqlCommand("Update CerpacNo_Out_One set CardIssueDate='" + CrOutOnCount[2].Trim() + "', CardNo='" + CrOutOnCount[3].Trim() + "', ZoneCode='" + CrOutOnCount[4].Trim() + "', StickerPrintedYN='" + CrOutOnCount[5].Trim() + "', StickerWastedYN='" + CrOutOnCount[6].Trim() + "', UserId='" + CrOutOnCount[7].Trim() + "', StickerWastedReason='" + CrOutOnCount[8].Trim() + "' where cerpac_no in ('" + CrOutOnCount[1].Trim() + "') and cerpac_file_no='" + CrOutOnCount[9].Trim() + "'", Connection);
                    Connection.Open();
                    Command.ExecuteNonQuery();
                    Connection.Close();

                }
                
            }
             


            //---------------------Split Upload Excel table Data------------------------------------

                String UploadExcel = lines[6];
                string[] stringSeparatorsUploadExcel = new string[] { "-###-" };
                var UploadExcelCount = UploadExcel.Split(stringSeparatorsUploadExcel, StringSplitOptions.None);
                for (int i = 1; i <= UploadExcelCount.Count() - 2; i++)
                {
                    String UploadExcelRow = UploadExcelCount[i]; // lines[2];
                    string[] stringSeparatorsUploadExcelRow = new string[] { "\t" };

                    var UploadExcelRowCount = UploadExcelRow.Split(stringSeparatorsUploadExcelRow, StringSplitOptions.None);

                    //-----------------Search in Upload Excel table--------------------
                        objgenenral = new BaseLayer.General_function();
                        string QuerCountFound = "select count(*) from Uploaded_Excel_Data where formno='" + UploadExcelRowCount[0].Trim() + "'";

                        DataTable dt = new DataTable();
                        dt = objgenenral.FetchData(QuerCountFound);
                        if (dt.Rows[0].ItemArray[0].ToString()  != "0")
                        {
                            //--------------------------Update------------------------------
                            SqlConnection Connection = new SqlConnection();
                            Connection.ConnectionString = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
                            SqlCommand Command = new SqlCommand("Update Uploaded_Excel_Data set Cerpacno='" + UploadExcelRowCount[1].Trim() +  "' where Formno='" + UploadExcelRowCount[0].Trim() + "'", Connection);
                            Connection.Open();
                            Command.ExecuteNonQuery();
                            Connection.Close();                          
                    
                        }                        
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
                //---------------Audit trail in bank request formno.'s---------------------

                String source = ViewState["FRNList"].ToString();
                string[] stringSeparators = new string[] { "," };
                var result = source.Split(stringSeparators, StringSplitOptions.None);
                int loop = 0;
                string AlreadyReq = "";
                for (int i = 0; i <= result.Count() - 2; i++)
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
                        if (dt.Rows[0].ItemArray[0].ToString() != "0")
                        {

                            //--------------------------Insert--------------------------------   

                            SqlConnection Connection = new SqlConnection();
                            Connection.ConnectionString = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;

               
                            SqlCommand Command = new SqlCommand("Update uploaded_excel_data_C set Final_flag=1, resuserid='" + UserID.ToString().Trim() + "', response_date='" + date.ToString(sysFormat) + "' where formno ='" + result[i].ToString().Trim() + "'", Connection);
                            
                            Connection.Open();
                            Command.ExecuteNonQuery();
                            Connection.Close();
                            
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
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('We found " + loop + " worng form no in textbox .'); window.location = '" + Page.ResolveUrl("frmImportEncryptfileAfterQC.aspx") + "';", true);
                
                }
                if (AlreadyReq != "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Already requested form no :" + AlreadyReq.Trim().Replace(" ", ",") + ".'); window.location = '" + Page.ResolveUrl("frmImportEncryptfileAfterQC.aspx") + "';", true);
              
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Successfully import in your database'); window.location = '" + Page.ResolveUrl("frmImportEncryptfileAfterQC.aspx") + "';", true);
           
                }
               // Response.Redirect("frmImportEncryptfileAfterQC.aspx");
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
    public void BindGrid()
    {
        try
        {
            string AlreadyReq = "";
            

            divbrowsefile.Visible = true;
            divCrefile.Visible = false;
            divgrd.Visible = false;
            divSearchResult.Visible = true;


            string[] lines = System.IO.File.ReadAllLines((output));

            String ZoneNameLine = lines[0];
            string[] stringSeparatorsZoneNameLine = new string[] { "\t" };
            var ZoneNameLineCount = ZoneNameLine.Split(stringSeparatorsZoneNameLine, StringSplitOptions.None);
            lblZonename.Text = ZoneNameLineCount[1];


            String ReadSecondLine = lines[1];
            string[] stringSeparatorsReadSecondLine = new string[] { "\t" };
            var SecondLineCount = ReadSecondLine.Split(stringSeparatorsReadSecondLine, StringSplitOptions.None);

            String ReadthirdLine = lines[2];
            string[] stringSeparatorsReadthirdLine = new string[] { "\t" };
            var FormCount = ReadthirdLine.Split(stringSeparatorsReadSecondLine, StringSplitOptions.None);          

            int count = 0;
            //--------------Compare with uploaded_Excel_Data-----------------------------
            String ReadFRN = FormCount[1]; // lines[2];
            string[] stringSeparatorsReadFRNRow = new string[] { "," };
            var TotalReq = ReadFRN.Split(stringSeparatorsReadFRNRow, StringSplitOptions.None);
  
            int loop = 0;
            for (int i = 0; i <= TotalReq.Count() - 2; i++)
            {
                
                if (TotalReq[i].ToString().Substring(0, 2).Trim() == "AO" || TotalReq[i].ToString().Substring(0, 2).Trim() == "AR" || TotalReq[i].ToString().Substring(0, 2).Trim() == "CR" || TotalReq[i].ToString().Substring(0, 2).Trim() == "NG")
                {
                    //-----------------Search in Upload excel data C table--------------------
                    ObjGenBal = new BaseLayer.General_function();
                    string QuerCountFound = "select count(*) from uploaded_excel_data_C where final_flag='"+ 2 +"' and   Formno='" + TotalReq[i].ToString().Trim() + "' and zone_name='" + ZoneDetails + "'";

                    DataTable dt = new DataTable();
                    dt = ObjGenBal.FetchData(QuerCountFound);
                    if (dt.Rows[0].ItemArray[0].ToString() != "0")
                    {
                        AlreadyReq = AlreadyReq + TotalReq[i].ToString().Trim() + ",";
                    }

                }
                else
                {
                    loop++;
                }
                count++;
            }

            if (AlreadyReq != "")
            {


                int AO = Regex.Matches(AlreadyReq.ToString(), "AO").Count;
                int AR = Regex.Matches(AlreadyReq.ToString(), "AR").Count;
                int CR = Regex.Matches(AlreadyReq.ToString(), "CR").Count;
                int NG = Regex.Matches(AlreadyReq.ToString(), "NG").Count;


                //lblTotalRequest.Text = count.ToString();
                count = (AO + AR + CR + NG);
                lblTotalRequest.Text = count.ToString();
                lblAOCerpacNo.Text = AO.ToString();
                lblARCerpacNo.Text = AR.ToString();
                lblCRCerpacNo.Text = CR.ToString();

                //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('You receive only form no :" + AlreadyReq.Trim().Replace(" ", ",") + " after quality.');", true);


            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Updated QC records not for your zone '); window.location = '" + Page.ResolveUrl("frmImportEncryptfileAfterQC.aspx") + "';", true);
           
            }
          


            //----------------------------------------------------------------------------


            if (count > 0)
            {

                divbrowsefile.Visible = false;
                divCrefile.Visible = true;
                divgrd.Visible = true;
                divSearchResult.Visible = true;


                //----------------------Create Data Table ---------------------------
                DataTable myDataTable = new DataTable();

                DataColumn myDataColumn;


                //------------------------People Table------------------


                myDataColumn = new DataColumn();
                myDataColumn.DataType = Type.GetType("System.String");
                myDataColumn.ColumnName = "forename";
                myDataTable.Columns.Add(myDataColumn);

                myDataColumn = new DataColumn();
                myDataColumn.DataType = Type.GetType("System.String");
                myDataColumn.ColumnName = "middle_name";
                myDataTable.Columns.Add(myDataColumn);

                myDataColumn = new DataColumn();
                myDataColumn.DataType = Type.GetType("System.String");
                myDataColumn.ColumnName = "surname";
                myDataTable.Columns.Add(myDataColumn);



                myDataColumn = new DataColumn();
                myDataColumn.DataType = Type.GetType("System.String");
                myDataColumn.ColumnName = "cerpac_no";
                myDataTable.Columns.Add(myDataColumn);

                myDataColumn = new DataColumn();
                myDataColumn.DataType = Type.GetType("System.String");
                myDataColumn.ColumnName = "cerpac_file_no";
                myDataTable.Columns.Add(myDataColumn);

                myDataColumn = new DataColumn();
                myDataColumn.DataType = Type.GetType("System.String");
                myDataColumn.ColumnName = "cerpac_receipt_date";
                myDataTable.Columns.Add(myDataColumn);

                myDataColumn = new DataColumn();
                myDataColumn.DataType = Type.GetType("System.String");
                myDataColumn.ColumnName = "cerpac_expiry_date";
                myDataTable.Columns.Add(myDataColumn);



                myDataColumn = new DataColumn();
                myDataColumn.DataType = Type.GetType("System.String");
                myDataColumn.ColumnName = "passport_no";
                myDataTable.Columns.Add(myDataColumn);

                myDataColumn = new DataColumn();
                myDataColumn.DataType = Type.GetType("System.String");
                myDataColumn.ColumnName = "nationality";
                myDataTable.Columns.Add(myDataColumn);



                myDataColumn = new DataColumn();
                myDataColumn.DataType = Type.GetType("System.String");
                myDataColumn.ColumnName = "date_of_birth";
                myDataTable.Columns.Add(myDataColumn);


                myDataColumn = new DataColumn();
                myDataColumn.DataType = Type.GetType("System.String");
                myDataColumn.ColumnName = "company";
                myDataTable.Columns.Add(myDataColumn);


                myDataColumn = new DataColumn();
                myDataColumn.DataType = Type.GetType("System.String");
                myDataColumn.ColumnName = "designation";
                myDataTable.Columns.Add(myDataColumn);


                //myDataColumn = new DataColumn();
                //myDataColumn.DataType = Type.GetType("System.String");
                //myDataColumn.ColumnName = "userImage";
                //myDataTable.Columns.Add(myDataColumn);




               
                String Cerpacno = lines[3];
                string[] stringSeparatorsCerpacno = new string[] { "-###-" };
                var CerpacnoCount = Cerpacno.Split(stringSeparatorsCerpacno, StringSplitOptions.None);



                for (int i = 1; i <= CerpacnoCount.Count() - 2; i++)
                {
                
                 
                    String result = CerpacnoCount[i]; // lines[2];
                    string[] stringSeparatorsCerpacnoRow = new string[] { "\t" };
                    var CerpacnoRow = result.Split(stringSeparatorsCerpacnoRow, StringSplitOptions.None);

                    DataRow row;
                     int FRN = Regex.Matches(AlreadyReq.ToString(), CerpacnoRow[16].Trim() ).Count;
                     if ( FRN > 0)
                     {
                             row = myDataTable.NewRow();


                            row["forename"] = CerpacnoRow[2];
                            row["middle_name"] = CerpacnoRow[3];
                            row["surname"] = CerpacnoRow[4];
                            row["cerpac_no"] = CerpacnoRow[15];
                            row["cerpac_file_no"] = CerpacnoRow[16];
                            row["cerpac_receipt_date"] = CerpacnoRow[17];
                            row["cerpac_expiry_date"] = CerpacnoRow[18];
                            row["passport_no"] = CerpacnoRow[24];
                            row["nationality"] = CerpacnoRow[25];
                            row["date_of_birth"] = CerpacnoRow[30];
                            //row["company"] = CerpacnoRow[38];
                            row["designation"] = CerpacnoRow[41];
                          //  row["userImage"] = CerpacnoRow[57];


                            myDataTable.Rows.Add(row);
                    }
                }
                   
                
            
                if (myDataTable.Rows.Count > 0)
                {
                    grd_display_data.DataSource = myDataTable;
                    grd_display_data.DataBind();

                    for (int i = 0; i < grd_display_data.Rows.Count; i++)
                    {
                        Cerptxt = Cerptxt + grd_display_data.Rows[i].Cells[3].Text.ToString() + ",";

                    }
                    //string source = txt;

                    for (int i = 0; i < grd_display_data.Rows.Count; i++)
                    {
                        CerpFiletxt = CerpFiletxt + grd_display_data.Rows[i].Cells[4].Text.ToString() + ",";

                    }
                    ViewState["CerpacList"] = Cerptxt;
                    ViewState["FRNList"] = CerpFiletxt;
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
           // dt = null;
            ObjGenBal = null;
        }

    }

    

    protected void btnImport_Click(object sender, EventArgs e)
    {

        //string foldername = "Decrypt File";
        string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        filePath = filePath + @"\";

        if (!Directory.Exists(filePath))
        {
            Directory.CreateDirectory(filePath);
        }


        //Get the Input File Name and Extension
        //string fileName = Path.GetFileNameWithoutExtension(FileUpload1.PostedFile.FileName);
        //string fileExtension = Path.GetExtension(FileUpload1.PostedFile.FileName);

         //= Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + fileName + fileExtension;

        if (ViewState["InputFile"] != null)
        {
            input = ViewState["InputFile"].ToString();
        }

        //output = filePath + @"\" + fileName + "_dec" + fileExtension;
        if (ViewState["OutputFile"] != null)
        {
            output = ViewState["OutputFile"].ToString();
        }

        //Save the Input File, Decrypt it and save the decrypted file in output path.
        this.Decrypt(input, output);
        SplitString();        

        //Delete the original (input) and the decrypted (output) file.
        File.Delete(input);
        File.Delete(output);
        

    }
}