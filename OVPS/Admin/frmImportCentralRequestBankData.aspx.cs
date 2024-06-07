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


public partial class Admin_frmImportCentralRequestBankData : System.Web.UI.Page
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
                ZoneDetails = dt.Rows[0]["ZoneName"].ToString() + "--" + dt.Rows[0]["ZoneCode"].ToString();
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
        if (!IsPostBack)
        {
           // Bindlist();
           // detailtable.Style.Add("display", "none");
            // warn.Style.Add("display", "");
        }
    }

    protected void Bindlist()
    {
        objgenenral = new BaseLayer.General_function();

        //Change By Saurabh as per discussion with Sanjay Sir on date 8th Sep
        //string queryforposition = "select forename as FirstName, middle_name as MiddleName, surname as  LastName, Company, Nationality, RequisitionNo, FormNo, CerpacNo, PassportNo, isnull(StrVisaNo,'') as StrVisaNo from People as a , PeopleChild as b where a.cerpac_no = b.CerpacNo and IsAuthorized=1 and ISARCR=1 and (IsProduced<>1 or IsProduced is null )";

        //regarding zone
        //string queryforposition = "select forename as FirstName, middle_name as MiddleName, surname as  LastName, Company, Nationality, RequisitionNo, cerpac_file_no as FormNo, CerpacNo, Passport_No, isnull(StrVisaNo,'') as StrVisaNo from vw_prod_consolidated_data where  IsAuthorized=1 and  and (IsProduced<>1 or IsProduced is null )";

        SqlConnection Connection = new SqlConnection();
        Connection.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        string queryforposition = "select Date1, FirstName, MiddleName, LastName, Company, Nationality, RequisitionNo, FormNo, CerpacNo, PassportNo, isnull(StrVisaNo,'') as StrVisaNo,tellerno,amount from uploaded_excel_data where formno in ('" + TextAppId.Text.Replace(",", "','") + "') and isnull(CerpacNo, '')=''";


        SqlCommand Command = new SqlCommand(queryforposition, Connection);
        Connection.Open();
        
        Command.ExecuteNonQuery();
        DataTable dt1 = new DataTable();
       // dt1 = null;
        SqlDataAdapter da = new SqlDataAdapter(Command);
        da.Fill(dt1);
        Connection.Close();
        da.Dispose();


       
      //  dt1 = objgenenral.FetchData(queryforposition);

        if (dt1.Rows.Count > 0)
        {
            grd_display_data.DataSource = dt1;
            grd_display_data.DataBind();

            tr45.Style.Add("display", "");
        }
        else
        {

            grd_display_data.DataSource = dt1;
            grd_display_data.DataBind();
            tr45.Style.Add("display", "");

        }


    }

    //protected void Go_Click(object sender, EventArgs e)
    //{

    //    objgenenral = new BaseLayer.General_function();
    //    //string quer = "select a.*,b.* from People as a , PeopleChild as b where a.cerpac_no = b.CerpacNo and a.cerpac_no='" + TextAppId.Text.ToString() + "'";

    //    // string quer = "select * from vw_prod_consolidated_data a, UserZoneRelation b where (IsAuthorized=1) and (isarcr=1) and (IsProduced=0 or IsProduced is null or IsProduced=2 or IsProduced=3) and a.verifiedby = b.userid  and b.ZoneCode=(select ZoneCode from UserZoneRelation where USERID=" + objectSessionHolderPersistingData.User_ID + ") and cerpacno='" + TextAppId.Text.ToString() + "'";
    //    string quer = "select Date1,FirstName, MiddleName, LastName, Company, Nationality, RequisitionNo, FormNo, CerpacNo, PassportNo, isnull(StrVisaNo,'') as StrVisaNo,tellerno,amount from uploaded_excel_data where formno in ('" + TextAppId.Text.Replace(",", "','") + "') and isnull(CerpacNo, '')<>''";

    //    try
    //    {

            
    //        //////// string querforuser = "Select a.ZoneName,b.ZoneCode from ZoneMaster as a, UserZoneRelation as b where a.ZoneCode = b.ZoneCode and b.UserId=" + objectSessionHolderPersistingData.User_ID.ToString() + "";
    //        ////// string queryfornewcase = "Select * from Issue where cerpac_no='" + TextAppId.Text.ToString() + "'";
    //        DataTable dt = new DataTable();
    //        dt = objgenenral.FetchData(quer);
    //        //////// DataTable dtuser = new DataTable();
    //        //////// dtuser = objgenenral.FetchData(querforuser);
    //        ////// DataTable dtnew = new DataTable();
    //        ////// dtnew = objgenenral.FetchData(queryfornewcase);
    //        ////// if (dt.Rows.Count > 0 && dt.Rows[0]["IsVerified"].ToString().Trim() == "0")
    //        ////// {
    //        Bindlist();

    //        ////// }
    //        ////// else if (dt.Rows.Count > 0 && dt.Rows[0]["IsVerified"].ToString() == "1")
    //        ////// {
    //        //////     lblmsg.Text = "This Cerpac Number Has already been verified";
    //        //////     lblmsg.CssClass = "warning-box";
    //        ////// }
    //        ////// else
    //        ////// {
    //        //////     lblmsg.Text = "This Cerpac Number does not exists.Please check the number and try again";
    //        //////     lblmsg.CssClass = "error-box";

    //        ////// }

    //        // GetData(TextAppId.Text);
    //    }
    //    catch (Exception ex)
    //    {
    //        objgenenral = new BaseLayer.General_function();
    //        string err = objgenenral.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
    //        lblmsg.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
    //        lblmsg.CssClass = "warning-box";
    //    }
    //    finally
    //    {
    //        dt = null;
    //        objgenenral = null;
    //    }
    //}

    protected void grd_display_data_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        grd_display_data.PageIndex = e.NewPageIndex;
        Bindlist();

    }
    protected void grd_display_data_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {

    }

    protected void grd_display_data_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            //  e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
            e.Row.ToolTip = "Click to select row";
            e.Row.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.grd_display_data, "Select$" + e.Row.RowIndex);
        }
    }

    protected void grd_display_data_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = grd_display_data.SelectedRow;

      //  GetData(row.Cells[6].Text);
      //  btn_back.Visible = true;
    }
    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        DataSet ds = (DataSet)grd_display_data.DataSource;

       // ds.WriteXml("XMLFileOut.xml", XmlWriteMode.IgnoreSchema);
    }
    //protected void btn_import_Click(object sender, EventArgs e)
    //{

    //    foreach (GridViewRow gv in grd_display_data.Rows)
    //    {
    //        SqlConnection Connection = new SqlConnection();
    //        Connection.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

    //        SqlCommand Command = new SqlCommand("update uploaded_excel_data set cerpacno='" + LabelMessage.Text+ "' where formno in ('" + TextAppId.Text.Replace(",", "','") + "')", Connection);
    //        Connection.Open();
    //        Command.ExecuteNonQuery();
    //        Connection.Close();


    //        SqlConnection ConnectionZone = new SqlConnection();
    //        ConnectionZone.ConnectionString = ConfigurationManager.ConnectionStrings["NigeriaConnectionString"].ConnectionString;

    //        SqlCommand CommandZone = new SqlCommand("INSERT INTO  Uploaded_Excel_Data(RecordNo, date1,branch,RequisitionNO,PassportNo,FirstName,MiddleName,LastName,Company,Nationality,Formno,TellerNo,Amount,StrVisaNo,CreatedBY,CreatedON)" +
    //                                                " VALUES ( (select max(recordno)+1 from uploaded_excel_data),'" + gv.Cells[0].Text + "','',0,'" + gv.Cells[11].Text + "','" + gv.Cells[1].Text + "','" + gv.Cells[2].Text + "','" + gv.Cells[3].Text + "','" + gv.Cells[4].Text + "','" + gv.Cells[5].Text + "','" + gv.Cells[8].Text + "','" + gv.Cells[9].Text + "','" + gv.Cells[10].Text + "','" + gv.Cells[12].Text + "'," + objectSessionHolderPersistingData.User_ID + ",GETDATE())   ", ConnectionZone);
    //        ConnectionZone.Open();
    //        CommandZone.ExecuteNonQuery();
    //        ConnectionZone.Close();
    //    }
       

        

    //}

    
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
        //TextAppId.Text = File.ReadAllText(output);
        //SplitString();
        //string Readfile = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + fileName + fileExtension;
        //dstest.ReadXml(filePath);
        
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
    
    public void SplitString()
    {
        String source = TextAppId.Text;
        string[] stringSeparators = new string[] { "  " };
        var result = source.Split(stringSeparators, StringSplitOptions.None);
        TextAppId.Text = result[0];
        lblZonename.Text = result[1];
        lblRequestedZone.Text = result[1];

        
    }
    protected void btnSearchForm_Click(object sender, EventArgs e)
    {

        String source = TextAppId.Text;
        int count = 0;
        foreach (char c in source)
        {
            if (c == 'A' || c == 'C' || c == 'N')
            {
                count++;
            }
        }
        lblTotalRequest.Text = count.ToString();

        objgenenral = new BaseLayer.General_function();
        string QuerCountFound = "select count(*) from uploaded_excel_data where formno in ('" + TextAppId.Text.Replace(",", "','") + "')";
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

        }
        string QuerCountUsedFound = "select count(*) from uploaded_excel_data where formno in ('" + TextAppId.Text.Replace(",", "','") + "') and isnull(CerpacNo, '')<>''";

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

        }

        string QuerCountFreeFound = "select count(*) from uploaded_excel_data where formno in ('" + TextAppId.Text.Replace(",", "','") + "') and isnull(CerpacNo, '')=''";

        try
        {
            DataTable dt = new DataTable();
            dt = objgenenral.FetchData(QuerCountFreeFound);
            if (dt.Rows.Count > 0)
            {
               lblFreeForm.Text = dt.Rows[0][0].ToString();

                //tr45.Style.Add("display", "");
            }
        }
        catch (Exception ex)
        {

        }

        string quer = "select Date1,FirstName, MiddleName, LastName, Company, Nationality, RequisitionNo, FormNo, CerpacNo, PassportNo, isnull(StrVisaNo,'') as StrVisaNo,tellerno,amount from uploaded_excel_data where formno in ('" + TextAppId.Text.Replace(",", "','") + "') and isnull(CerpacNo, '')=''";

        try
        {

            
            dtform = objgenenral.FetchData(quer);
            if (dtform.Rows.Count > 0)
            {
                grd_display_data.DataSource = dtform;
                grd_display_data.DataBind();

                //tr45.Style.Add("display", "");
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
    protected void btnEncrypt_Click(object sender, EventArgs e)
    {
        
        string xmlfilename = "default.xml";
        string foldername = "Central Server Replay --" + DateTime.Now.ToString().Replace("/", "").Replace(":", "");
        string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        filePath = filePath + @"\";

        if (TextAppId.Text != "")
        {

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            xmlfilename = "Central Server Replay --" + DateTime.Now.ToString().Replace("/", "").Replace(":", "") + ".xml";

            if (File.Exists(Path.Combine(filePath, filePath + @"\" + xmlfilename.ToString().Trim())))
            {
                File.Delete(Path.Combine(filePath, filePath + @"\" + xmlfilename.ToString().Trim()));
            }

            System.IO.StreamWriter s = File.CreateText(System.IO.Path.Combine(filePath, filePath + @"\" + xmlfilename.ToString().Trim()));


            //string compdata = "Central Replay" + "  " + lblRequestedZone.Text.Trim().ToString() + DateTime.Now.ToString().Replace("/", "").Replace(":", "");
           // string compdata;
            objgenenral = new BaseLayer.General_function();
            string quer = "select Date1,FirstName, MiddleName, LastName, Company, Nationality, RequisitionNo, FormNo, CerpacNo, PassportNo, isnull(StrVisaNo,'') as StrVisaNo,tellerno,amount from uploaded_excel_data where formno in ('" + TextAppId.Text.Replace(",", "','") + "') and isnull(CerpacNo, '')=''";

            try
            {


                dtform = objgenenral.FetchData(quer);               
                for (int i = 0; i <= dtform.Rows.Count - 1; i++)

                {
                    s.WriteLine(grd_display_data.Rows[i].Cells[0].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[1].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[2].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[3].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[4].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[5].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[6].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[7].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[8].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[9].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[10].Text.ToString()); ;
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

            File.Delete(input);
            //File.Delete(output);

            Response.End();
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