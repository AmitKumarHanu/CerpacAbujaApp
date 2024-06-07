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

public partial class Admin_frmConfirmEligibilityZone_import : System.Web.UI.Page
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
    Label LabelMessage = null;

    int count = 0;
              

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

    public void SplitString()
    {
        try
        {

            string sysf = "dd-MM-yyyy";

            if (DateTimeFormatInfo.CurrentInfo.ShortDatePattern.ToCharArray()[0].ToString() == "d")
            {
                sysf = "MM-dd-yyyy";
            }
            string[] lines = System.IO.File.ReadAllLines((output));


            //---------------------------Split Encrypt file ------------------


            String ZoneName = lines[0];
            string[] stringSeparatorsZoneName = new string[] { "\t" };
            var ZoneNameCount = ZoneName.Split(stringSeparatorsZoneName, StringSplitOptions.None);


           // if (ZoneNameCount[1].ToString() == ZoneDetails)
            {


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
                    if (dt.Rows[0].ItemArray[0].ToString() != "0")
                    {
                        //--------------------------Update------------------------------
                        SqlConnection Connection = new SqlConnection();

                        Connection.ConnectionString = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;

                        SqlCommand Command = new SqlCommand("update People set forename ='" + PeopleRowCount[2].Trim().Replace("'", "''") + "', middle_name ='" + PeopleRowCount[3].Trim().Replace("'", "''") + "', surname ='" + PeopleRowCount[4].Trim().Replace("'", "''") + "', sex ='" + PeopleRowCount[5].Trim() + "', cerpac_file_no ='" + PeopleRowCount[16].Trim() + "', cerpac_expiry_date ='" + PeopleRowCount[18].Trim() + "', cerpac_receipt_date ='" + PeopleRowCount[17].Trim() + "', passport_no ='" + PeopleRowCount[24].Trim() + "', nationality ='" + PeopleRowCount[25].Trim() + "', company ='" + PeopleRowCount[38].Trim().Replace("'", "''") + "', designation= '" + PeopleRowCount[41].Trim().Replace("'", "''") + "' where cerpac_no = '" + PeopleRowCount[15].Trim() + "'", Connection);
                        Connection.Open();
                        Command.ExecuteNonQuery();
                        Connection.Close();
                        //return;

                    }
                    else
                    {

                        SqlConnection Connection = new SqlConnection();
                        Connection.ConnectionString = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;

                        //SqlCommand Command = new SqlCommand("Insert into people ([title],[forename],[middle_name],[surname],[sex],[residence_permit_no],[residence_issue_loc]" +
                        //                                      ",[deedmark_no],[printed],[label_print_count],[card_print_count],[picture],[directory],[notes]" +
                        //                                      ",[cerpac_no],[cerpac_file_no],[cerpac_receipt_date],[cerpac_expiry_date],[registration_area],[registration_code]" +
                        //                                      ",[file_no],[label_no],[book_no],[passport_no],[nationality],[passport_issue_date],[passport_expiry_date]" +
                        //                                      ",[passport_issue_loc],[passport_issue_by],[date_of_birth],[place_of_birth],[nigeria_add_1],[nigeria_add_2]" +
                        //                                      ",[nigeria_tel_no],[abroad_add_1],[abroad_add_2],[abroad_tel_no],[company],[company_add_1],[company_add_2]" +
                        //                                      ",[designation],[employment_date],[company_tel_no],[company_fax_no],[email],[date_added],[added_by_user_id]" +
                        //                                      ",[date_modified],[modified_by_user_id],[picture_taken],[picture_by_user_id],[verid_template],[verid_template_1]" +
                        //                                      ",[arcanet_2d_command],[date_system_modified],[ContactNo])" +
                        //                                      "Values('" + PeopleRowCount[1].Trim().Replace("'", "''") + "','" + PeopleRowCount[2].Trim().Replace("'", "''").Replace("'", "''") + "','" + PeopleRowCount[3].Trim().Replace("'", "''").Replace("'", "''") + "','" + PeopleRowCount[4].Trim().Replace("'", "''").Replace("'", "''") + "','" + PeopleRowCount[5].Trim().Replace("'", "''") + "','" + PeopleRowCount[6].Trim().Replace("'", "''") + "','" + PeopleRowCount[7].Trim().Replace("'", "''").Replace("'", "''") + "','" + PeopleRowCount[8].Trim().Replace("'", "''") +
                        //                                           "','" + PeopleRowCount[9].Trim().Replace("'", "''") + "','" + PeopleRowCount[10].Trim().Replace("'", "''") + "','" + PeopleRowCount[11].Trim().Replace("'", "''") + "','" + PeopleRowCount[12].Trim().Replace("'", "''") + "','" + PeopleRowCount[13].Trim().Replace("'", "''") + "','" + PeopleRowCount[14].Trim().Replace("'", "''") + "','" + PeopleRowCount[15].Trim().Replace("'", "''") + "','" + PeopleRowCount[16].Trim().Replace("'", "''") +
                        //                                           "','" + datep(PeopleRowCount[17].Trim().Replace("'", "''")) + "','" + datep(PeopleRowCount[18].Trim().Replace("'", "''")) + "','" + PeopleRowCount[19].Trim().Replace("'", "''") + "','" + PeopleRowCount[20].Trim().Replace("'", "''") + "','" + PeopleRowCount[21].Trim().Replace("'", "''") + "','" + PeopleRowCount[22].Trim().Replace("'", "''") +
                        //                                           "','" + PeopleRowCount[23].Trim().Replace("'", "''") + "','" + PeopleRowCount[24].Trim().Replace("'", "''") + "','" + PeopleRowCount[25].Trim().Replace("'", "''") + "','" + datep(PeopleRowCount[26].Trim().Replace("'", "''")) + "','" + datep(PeopleRowCount[27].Trim().Replace("'", "''")) + "','" + PeopleRowCount[28].Trim().Replace("'", "''") + "','" + PeopleRowCount[29].Trim().Replace("'", "''") +
                        //                                           "','" + datep(PeopleRowCount[30].Trim().Replace("'", "''")) + "','" + PeopleRowCount[31].Trim().Replace("'", "''") + "','" + PeopleRowCount[32].Trim().Replace("'", "''").Replace("'", "''") + "','" + PeopleRowCount[33].Trim().Replace("'", "''").Replace("'", "''") + "','" + PeopleRowCount[34].Trim().Replace("'", "''") + "','" + PeopleRowCount[35].Trim().Replace("'", "''") +
                        //                                           "','" + PeopleRowCount[36].Trim().Replace("'", "''") + "','" + PeopleRowCount[37].Trim().Replace("'", "''") + "','" + PeopleRowCount[38].Trim().Replace("'", "''").Replace("'", "''") + "','" + PeopleRowCount[39].Trim().Replace("'", "''") + "','" + PeopleRowCount[40].Trim().Replace("'", "''") + "','" + PeopleRowCount[41].Trim().Replace("'", "''").Replace("'", "''") + "','" + datep(PeopleRowCount[42].Trim().Replace("'", "''")) +
                        //                                           "','" + PeopleRowCount[43].Trim().Replace("'", "''") + "','" + PeopleRowCount[44].Trim().Replace("'", "''") + "','" + PeopleRowCount[45].Trim().Replace("'", "''") + "','" + datep(PeopleRowCount[46].Trim().Replace("'", "''")) + "','" + PeopleRowCount[47].Trim().Replace("'", "''") + "','" + datep(PeopleRowCount[48].Trim().Replace("'", "''")) + "','" + PeopleRowCount[49].Trim().Replace("'", "''") +
                        //                                           "','" + PeopleRowCount[50].Trim().Replace("'", "''") + "','" + PeopleRowCount[51].Trim().Replace("'", "''") + "','" + PeopleRowCount[52].Trim().Replace("'", "''") + "','" + PeopleRowCount[53].Trim().Replace("'", "''") + "','" + PeopleRowCount[54].Trim().Replace("'", "''") + "','" + PeopleRowCount[55].Trim().Replace("'", "''") +
                        //                                           "','" + PeopleRowCount[56].Trim().Replace("'", "''") + "')", Connection);
//

                        SqlCommand Command = new SqlCommand("Insert into people ([title],[forename],[middle_name],[surname],[sex],[residence_permit_no],[residence_issue_loc]" +
                                                              ",[deedmark_no],[printed],[label_print_count],[card_print_count],[picture],[directory],[notes]" +
                                                              ",[cerpac_no],[cerpac_file_no],[cerpac_receipt_date],[cerpac_expiry_date],[registration_area],[registration_code]" +
                                                              ",[file_no],[label_no],[book_no],[passport_no],[nationality],[passport_issue_date],[passport_expiry_date]" +
                                                              ",[passport_issue_loc],[passport_issue_by],[date_of_birth],[place_of_birth],[nigeria_add_1],[nigeria_add_2]" +
                                                              ",[nigeria_tel_no],[abroad_add_1],[abroad_add_2],[abroad_tel_no],[company],[company_add_1],[company_add_2]" +
                                                              ",[designation],[employment_date],[company_tel_no],[company_fax_no],[email],[date_added],[added_by_user_id]" +
                                                              ",[date_modified],[modified_by_user_id],[picture_taken],[picture_by_user_id],[verid_template],[verid_template_1]" +
                                                              ",[arcanet_2d_command],[date_system_modified],[ContactNo])" +
                                                              "Values('" + PeopleRowCount[1].Trim().Replace("'", "''") + "','" + PeopleRowCount[2].Trim().Replace("'", "''") + "','" + PeopleRowCount[3].Trim().Replace("'", "''") + "','" + PeopleRowCount[4].Trim().Replace("'", "''") + "','" + PeopleRowCount[5].Trim().Replace("'", "''") + "','" + PeopleRowCount[6].Trim().Replace("'", "''") + "','" + PeopleRowCount[7].Trim().Replace("'", "''") + "','" + PeopleRowCount[8].Trim().Replace("'", "''") +
                                                                   "','" + PeopleRowCount[9].Trim().Replace("'", "''") + "','" + PeopleRowCount[10].Trim().Replace("'", "''") + "','" + PeopleRowCount[11].Trim().Replace("'", "''") + "','" + PeopleRowCount[12].Trim().Replace("'", "''") + "','" + PeopleRowCount[13].Trim().Replace("'", "''") + "','" + PeopleRowCount[14].Trim().Replace("'", "''") + "','" + PeopleRowCount[15].Trim().Replace("'", "''") + "','" + PeopleRowCount[16].Trim().Replace("'", "''") +
                                                                   "','" + PeopleRowCount[17].Trim().Replace("'", "''") + "','" + PeopleRowCount[18].Trim().Replace("'", "''") + "','" + PeopleRowCount[19].Trim().Replace("'", "''") + "','" + PeopleRowCount[20].Trim().Replace("'", "''") + "','" + PeopleRowCount[21].Trim().Replace("'", "''") + "','" + PeopleRowCount[22].Trim().Replace("'", "''") +
                                                                   "','" + PeopleRowCount[23].Trim().Replace("'", "''") + "','" + PeopleRowCount[24].Trim().Replace("'", "''") + "','" + PeopleRowCount[25].Trim().Replace("'", "''") + "','" + PeopleRowCount[26].Trim().Replace("'", "''") + "','" + PeopleRowCount[27].Trim().Replace("'", "''") + "','" + PeopleRowCount[28].Trim().Replace("'", "''") + "','" + PeopleRowCount[29].Trim().Replace("'", "''") +
                                                                   "','" + PeopleRowCount[30].Trim().Replace("'", "''") + "','" + PeopleRowCount[31].Trim().Replace("'", "''") + "','" + PeopleRowCount[32].Trim().Replace("'", "''") + "','" + PeopleRowCount[33].Trim().Replace("'", "''") + "','" + PeopleRowCount[34].Trim().Replace("'", "''") + "','" + PeopleRowCount[35].Trim().Replace("'", "''") +
                                                                   "','" + PeopleRowCount[36].Trim().Replace("'", "''") + "','" + PeopleRowCount[37].Trim().Replace("'", "''") + "','" + PeopleRowCount[38].Trim().Replace("'", "''") + "','" + PeopleRowCount[39].Trim().Replace("'", "''") + "','" + PeopleRowCount[40].Trim().Replace("'", "''") + "','" + PeopleRowCount[41].Trim().Replace("'", "''") + "','" + PeopleRowCount[42].Trim().Replace("'", "''") +
                                                                   "','" + PeopleRowCount[43].Trim().Replace("'", "''") + "','" + PeopleRowCount[44].Trim().Replace("'", "''") + "','" + PeopleRowCount[45].Trim().Replace("'", "''") + "','" + PeopleRowCount[46].Trim().Replace("'", "''") + "','" + PeopleRowCount[47].Trim().Replace("'", "''") + "','" + PeopleRowCount[48].Trim().Replace("'", "''") + "','" + PeopleRowCount[49].Trim().Replace("'", "''") +
                                                                   "','" + PeopleRowCount[50].Trim().Replace("'", "''") + "','" + PeopleRowCount[51].Trim().Replace("'", "''") + "','" + PeopleRowCount[52].Trim().Replace("'", "''") + "','" + PeopleRowCount[53].Trim().Replace("'", "''") + "','" + PeopleRowCount[54].Trim().Replace("'", "''") + "','" + PeopleRowCount[55].Trim().Replace("'", "''") +
                                                                   "','" + PeopleRowCount[56].Trim().Replace("'", "''") + "')", Connection);

                        Connection.Open();
                        Command.ExecuteNonQuery();
                        Connection.Close();


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

                        Connection.ConnectionString = ConfigurationManager.ConnectionStrings["NigeriaConnectionString"].ConnectionString;
                        SqlCommand Command1 = new SqlCommand("update people set userImage=@ImageFile where cerpac_no in ('" + PeopleRowCount[15].ToString().Trim() + "')", Connection);

                        SqlParameter imageFileParameter = new SqlParameter("@ImageFile", SqlDbType.Image);
                        imageFileParameter.Value = data;
                        Command1.Parameters.Add(imageFileParameter);

                        Connection.Open();
                        Command1.ExecuteNonQuery();
                        Connection.Close();
                        //------------------------------------------------
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
                    if (dt.Rows[0].ItemArray[0].ToString() != "0")
                    {
                        //--------------------------Update------------------------------
                        SqlConnection Connection = new SqlConnection();
                        Connection.ConnectionString = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;

                        // DateTime ProducedOn, AuthorizedOn, VerifiedOn, RejectedOn, cerpac_expiry_date, cerpac_receipt_date, QualOn, BrownOn, StickerPrintedOn;

                        // SqlCommand Command = new SqlCommand("update PeopleChild set  IsVerified ='" + PeopleChildRowCount[15].Trim() + "', IsAuthorized ='" + PeopleChildRowCount[16].Trim() + "', ISARCR='" + PeopleChildRowCount[33].Trim() + "', ConfirmedBy ='" + PeopleChildRowCount[34].Trim() + "', IsProduced ='" + PeopleChildRowCount[17].Trim() + "', VerifiedBy ='" + PeopleChildRowCount[18].Trim() + "', AuthorizedBy ='" + PeopleChildRowCount[19].Trim() + "', ProducedBy ='" + PeopleChildRowCount[20].Trim() + "', ProducedOn ='" + Convert.ToDateTime(PeopleChildRowCount[21].Trim()).ToString(sysf) + "', AuthorizedOn='" + Convert.ToDateTime(PeopleChildRowCount[22].Trim()).ToString(sysf) + "', VerifiedOn ='" + Convert.ToDateTime(PeopleChildRowCount[23].Trim()).ToString(sysf) + "', IsRejected ='" + PeopleChildRowCount[24].Trim() + "', RejectedBy ='" + PeopleChildRowCount[25].Trim() + "', RejectedOn ='" + Convert.ToDateTime(PeopleChildRowCount[26].Trim()).ToString(sysf) + "', RejectionReason  ='" + PeopleChildRowCount[27].Trim() + "',cerpac_expiry_date ='" + Convert.ToDateTime(PeopleChildRowCount[38].Trim()).ToString(sysf) + "', cerpac_receipt_date ='" + Convert.ToDateTime(PeopleChildRowCount[39].Trim()).ToString(sysf) + "', IsQual ='" + PeopleChildRowCount[40].Trim() + "', QualBy ='" + PeopleChildRowCount[41].Trim() + "', QualOn ='" + Convert.ToDateTime(PeopleChildRowCount[42].Trim()).ToString(sysf) + "', BrownOn ='" + Convert.ToDateTime(PeopleChildRowCount[43].Trim()).ToString(sysf) + "', BrownBY ='" + PeopleChildRowCount[44].Trim() + "', IsBrown ='" + PeopleChildRowCount[45].Trim() + "', IsStickerPrinted ='" + PeopleChildRowCount[46].Trim() + "', StickerPrintedBy ='" + PeopleChildRowCount[47].Trim() + "', StickerPrintedOn ='" + Convert.ToDateTime(PeopleChildRowCount[48].Trim()).ToString(sysf) + "' where cerpacno in ('" + PeopleChildRowCount[7].Trim() + "') and formno='" + PeopleChildRowCount[4].Trim() + "'", Connection);

                        SqlCommand Command = new SqlCommand("update PeopleChild set  IsVerified ='" + PeopleChildRowCount[15].Trim() + "', IsAuthorized ='" + PeopleChildRowCount[16].Trim() + "', ISARCR='" + PeopleChildRowCount[33].Trim() + "', ConfirmedBy ='" + PeopleChildRowCount[34].Trim() + "', IsProduced ='" + PeopleChildRowCount[17].Trim() + "', VerifiedBy ='" + PeopleChildRowCount[18].Trim() + "', AuthorizedBy ='" + PeopleChildRowCount[19].Trim() + "', ProducedBy ='" + PeopleChildRowCount[20].Trim() + "', ProducedOn ='" + PeopleChildRowCount[21].Trim() + "', AuthorizedOn='" + PeopleChildRowCount[22].Trim() + "', VerifiedOn ='" + PeopleChildRowCount[23].Trim() + "', IsRejected ='" + PeopleChildRowCount[24].Trim() + "', RejectedBy ='" + PeopleChildRowCount[25].Trim() + "', RejectedOn ='" + PeopleChildRowCount[26].Trim() + "', RejectionReason  ='" + PeopleChildRowCount[27].Trim() + "',cerpac_expiry_date ='" + PeopleChildRowCount[38].Trim() + "', cerpac_receipt_date ='" + PeopleChildRowCount[39].Trim() + "', IsQual ='" + PeopleChildRowCount[40].Trim() + "', QualBy ='" + PeopleChildRowCount[41].Trim() + "', QualOn ='" + PeopleChildRowCount[42].Trim() + "', BrownOn ='" + PeopleChildRowCount[43].Trim() + "', BrownBY ='" + PeopleChildRowCount[44].Trim() + "', IsBrown ='" + PeopleChildRowCount[45].Trim() + "', IsStickerPrinted ='" + PeopleChildRowCount[46].Trim() + "', StickerPrintedBy ='" + PeopleChildRowCount[47].Trim() + "', StickerPrintedOn ='" + PeopleChildRowCount[48].Trim() + "' where cerpacno in ('" + PeopleChildRowCount[7].Trim() + "') and formno='" + PeopleChildRowCount[4].Trim() + "'", Connection);
                        Connection.Open();
                        Command.ExecuteNonQuery();
                        Connection.Close();



                    }
                    else
                    {
                        //--------------------------Insert--------------------------------   

                        SqlConnection Connection = new SqlConnection();
                        Connection.ConnectionString = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;


                        SqlCommand Command = new SqlCommand("Insert into peopleChild ([Date1],[Branch],[RequisitionNO],[PassportNo],[FORMNO],[TELLERNO],[CerpacNo],[StrVisaNo],[ContactNo],[Email],[CreatedBY]" +
                                                            ",[CreatedON],[MOdifiedBY],[ModifiedOn],[IsVerified],[IsAuthorized],[IsProduced],[VerifiedBy] ,[AuthorizedBy],[ProducedBy],[ProducedOn] " +
                                                            ",[AuthorizedOn],[VerifiedOn],[IsRejected],[RejectedBy],[RejectedOn] ,[RejectionReason],[ZoneNote],[AuthNote],[ProdNote],[QualNote] " +
                                                            ",[IsDependent],[DesignationCode],[DependentOn] ,[ISARCR],[ConfirmedBy],[ConfirmedOn],[cerpac_expiry_date] ,[cerpac_receipt_date],[IsQual],[QualBy],[QualOn],[BrownOn] " +
                                                            ",[BrownBY],[IsBrown],[IsStickerPrinted],[StickerPrintedBy],[StickerPrintedOn],[StickerNumber],[up_f] )" +
                                                            "Values('" + PeopleChildRowCount[0].Trim() + "','" + PeopleChildRowCount[1].Trim() + "','" + PeopleChildRowCount[2].Trim() + "','" + PeopleChildRowCount[3].Trim() + "','" + PeopleChildRowCount[4].Trim() + "','" + PeopleChildRowCount[5].Trim() + "','" + PeopleChildRowCount[7].Trim() + "','" + PeopleChildRowCount[8].Trim() + "','" + PeopleChildRowCount[9].Trim() +
                                                                 "','" + PeopleChildRowCount[10].Trim() + "','" + PeopleChildRowCount[11].Trim() + "','" + PeopleChildRowCount[12].Trim() + "','" + PeopleChildRowCount[13].Trim() + "','" + PeopleChildRowCount[14].Trim() + "','" + PeopleChildRowCount[15].Trim() + "','" + PeopleChildRowCount[16].Trim() + "','" + PeopleChildRowCount[17].Trim() + "','" + PeopleChildRowCount[18].Trim() + "','" + PeopleChildRowCount[19].Trim() +
                                                                 "','" + PeopleChildRowCount[20].Trim() + "','" + PeopleChildRowCount[21].Trim() + "','" + PeopleChildRowCount[22].Trim() + "','" + PeopleChildRowCount[23].Trim() + "','" + PeopleChildRowCount[24].Trim() + "','" + PeopleChildRowCount[25].Trim() + "','" + PeopleChildRowCount[26].Trim() + "','" + PeopleChildRowCount[27].Trim() + "','" + PeopleChildRowCount[28].Trim() + "','" + PeopleChildRowCount[29].Trim() +
                                                                 "','" + PeopleChildRowCount[30].Trim() + "','" + PeopleChildRowCount[31].Trim() + "','" + PeopleChildRowCount[32].Trim() + "','" + PeopleChildRowCount[33].Trim() + "','" + PeopleChildRowCount[34].Trim() + "','" + PeopleChildRowCount[35].Trim() + "','" + PeopleChildRowCount[36].Trim() + "','" + PeopleChildRowCount[37].Trim() + "','" + PeopleChildRowCount[38].Trim() + "','" + PeopleChildRowCount[39].Trim() +
                                                                 "','" + PeopleChildRowCount[40].Trim() + "','" + PeopleChildRowCount[41].Trim() + "','" + PeopleChildRowCount[42].Trim() + "','" + PeopleChildRowCount[43].Trim() + "','" + PeopleChildRowCount[44].Trim() + "','" + PeopleChildRowCount[45].Trim() + "','" + PeopleChildRowCount[46].Trim() + "','" + PeopleChildRowCount[47].Trim() + "','" + PeopleChildRowCount[48].Trim() + "','" + PeopleChildRowCount[49].Trim() +
                                                                 "','" + PeopleChildRowCount[50].Trim() + "')", Connection);

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
                    else
                    {

                        //--------------------------Insert--------------------------------   

                        SqlConnection Connection = new SqlConnection();
                        Connection.ConnectionString = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;

                        SqlCommand Command = new SqlCommand("Insert into CerpacNo_Out_One (CerpacNo_OutID, cerpac_no, CardIssueDate, CardNo, ZoneCode, StickerPrintedYN, StickerWastedYN, UserId, StickerWastedReason, cerpac_file_no ) Values( (select max(CerpacNo_OutID)+1 from CerpacNo_Out_One),'" + CrOutOnCount[1].Trim() + "','" + CrOutOnCount[2].Trim() + "','" + CrOutOnCount[3].Trim() + "','" + CrOutOnCount[4].Trim() + "','" + CrOutOnCount[5].Trim() + "','" + CrOutOnCount[6].Trim() + "','" + CrOutOnCount[7].Trim() + "','" + CrOutOnCount[8].Trim() + "','" + CrOutOnCount[9].Trim() + "')", Connection);
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
                    if (dt.Rows[0].ItemArray[0].ToString() != "0")
                    {
                        //--------------------------Update------------------------------
                        SqlConnection Connection = new SqlConnection();
                        Connection.ConnectionString = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
                        SqlCommand Command = new SqlCommand("Update Uploaded_Excel_Data set Cerpacno='" + UploadExcelRowCount[1].Trim() + "' where Formno='" + UploadExcelRowCount[0].Trim() + "'", Connection);
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
                String source1 = ViewState["CerpacList"].ToString().Trim();
                string[] stringSeparators = new string[] { "," };
                var result = source.Split(stringSeparators, StringSplitOptions.None);
                var result1 = source1.Split(stringSeparators, StringSplitOptions.None);
                int loop = 0;
                string AlreadyReq = "";


                string QuerforMax = "select isnull(max(ack_no),0)+1 as max from tbl_confirm_eligibility_offline";
                DataTable dt_max = new DataTable();
                ObjGenBal = new BaseLayer.General_function();
                dt_max = ObjGenBal.FetchData(QuerforMax);

                for (int i = 0; i <= result.Count() - 2; i++)
                {
                    string formno = result[i].ToString().Trim();
                    result[i] = formno;
                    if (result[i].ToString().Substring(0, 2).Trim() == "AO" || result[i].ToString().Substring(0, 2).Trim() == "AR" || result[i].ToString().Substring(0, 2).Trim() == "CR" || result[i].ToString().Substring(0, 2).Trim() == "NG")
                    {

                        //-----------------Search in Upload excel data C table--------------------
                        ObjGenBal = new BaseLayer.General_function();
                        string QuerCountFound = "select count(*) from tbl_confirm_eligibility_offline where  Form_no='" + result[i].ToString().Trim() + "'";

                        DataTable dt = new DataTable();
                        dt = ObjGenBal.FetchData(QuerCountFound);
                        if (dt.Rows[0].ItemArray[0].ToString() != "0")
                        {

                            //--------------------------Insert--------------------------------   

                            SqlConnection Connection = new SqlConnection();
                            Connection.ConnectionString = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;


                            SqlCommand Command = new SqlCommand("Update tbl_confirm_eligibility_offline set confirmreq=1, userid='" + UserID.ToString().Trim() + "', confirmreqdate=getdate() where form_no ='" + result[i].ToString().Trim() + "'", Connection);

                            Connection.Open();
                            Command.ExecuteNonQuery();
                            Connection.Close();

                        }



                        else
                        {
                            SqlConnection Connection = new SqlConnection();
                            Connection.ConnectionString = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;

                            SqlCommand Command = new SqlCommand("insert into tbl_confirm_eligibility_offline(cerpac_no,form_no,zonename,confirmreq,confirmreqdate,userid,ack_no) values('" + result1[i].ToString().Trim() + "','" + result[i].ToString().Trim() + "','" + ZoneNameCount[1].ToString().Trim() + "',1,getdate()," + UserID + "," + dt_max.Rows[0][0].ToString() + ")", Connection);
                            Connection.Open();
                            Command.ExecuteNonQuery();
                            Connection.Close();
                            //AlreadyReq = AlreadyReq + result[i].ToString().Trim() + " ";
                        }

                    }
                    else
                    {
                        loop++;
                    }

                }

                if (loop > 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('We found " + loop + " worng form no in textbox .'); window.location = '" + Page.ResolveUrl("frmconfirmEligibilityZone_Import.aspx") + "';", true);

                }
                if (AlreadyReq != "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Already requested form no :" + AlreadyReq.Trim().Replace(" ", ",") + ".'); window.location = '" + Page.ResolveUrl("frmconfirmEligibilityZone_Import.aspx") + "';", true);

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Successfully import in your database'); window.location = '" + Page.ResolveUrl("frmconfirmEligibilityZone_Import.aspx") + "';", true);

                }
                // Response.Redirect("frmImportEncryptfileAfterQC.aspx");
            }

            //else
            //{
            //    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('uploaded file don't belongs with your zone'); window.location = '" + Page.ResolveUrl("frmconfirmEligibilityZone_Import.aspx") + "';", true);
            //}
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

            //if (ZoneNameLineCount[1] == ZoneDetails)
            {
                String ReadSecondLine = lines[1];
                string[] stringSeparatorsReadSecondLine = new string[] { "\t" };
                var SecondLineCount = ReadSecondLine.Split(stringSeparatorsReadSecondLine, StringSplitOptions.None);

                String ReadthirdLine = lines[2];
                string[] stringSeparatorsReadthirdLine = new string[] { "\t" };
                var FormCount = ReadthirdLine.Split(stringSeparatorsReadSecondLine, StringSplitOptions.None);

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
                        string QuerCountFound = "select count(*) from uploaded_excel_data_C where final_flag='" + 2 + "' and   Formno='" + TotalReq[i].ToString().Trim() + "' and zone_name='" + ZoneDetails + "'";

                        DataTable dt = new DataTable();
                        dt = ObjGenBal.FetchData(QuerCountFound);
                        if (dt.Rows[0].ItemArray[0].ToString() == "0")
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
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Updated IsARCR records not for your zone '); window.location = '" + Page.ResolveUrl("frmConfirmEligibilityZone_Import.aspx") + "';", true);

                }

            }

            //else
            //{
            //    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Uploaded file don't belongs to your zone !! '); window.location = '" + Page.ResolveUrl("frmConfirmEligibilityZone_Import.aspx") + "';", true);

            //}

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
                    int FRN = Regex.Matches(AlreadyReq.ToString(), CerpacnoRow[16].Trim()).Count;
                    if (FRN > 0)
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
       // File.Delete(input);
        File.Delete(output);
        
    }
}