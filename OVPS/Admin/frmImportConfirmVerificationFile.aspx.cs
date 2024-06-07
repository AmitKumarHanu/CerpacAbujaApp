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




public partial class Admin_frmImportConfirmVerificationFile : System.Web.UI.Page
{
    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    BaseLayer.General_function objgenenral = null;
    protected DataSet objDs = new DataSet();
    protected DataTable dt = new DataTable();
    protected DataTable dtform = new DataTable();

    protected BaseLayer.General_function ObjGenBal = null;
    string AppID = "", output = "", input ="" ;
    string UserID = null, ZoneDetails=null;
    Label LabelMessage = null ;

    int count ,   countrej ,   countdeny ;
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
                ZoneDetails = dt.Rows[0]["ZoneName"].ToString();      
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
        if (!IsPostBack)
        {
            div_File.Visible = true;
            div_grd.Visible = false;
            div_SeachDetails.Visible = false;            
            div_Save.Visible = false;
            div_rejected_Data.Visible = false;
            div_Deny_Data.Visible = false;
          
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
        DataSet ds = (DataSet)grd_display_data.DataSource;
        div_File.Visible = true;
        div_grd.Visible = false;
        div_SeachDetails.Visible = false;
        div_Save.Visible = false;

       // ds.WriteXml("XMLFileOut.xml", XmlWriteMode.IgnoreSchema);
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
        ViewState["FileAddress"] = FileUpload1.PostedFile.FileName;
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

    public void BindGrid()
    {
        try
        {
           


            string[] lines = System.IO.File.ReadAllLines((output));

            String ZoneNameLine = lines[0];
            string[] stringSeparatorsZoneNameLine = new string[] { "\t" };
            var ZoneNameLineCount = ZoneNameLine.Split(stringSeparatorsZoneNameLine, StringSplitOptions.None);
            lblZonename.Text = ZoneNameLineCount[1].Trim();

            if (ZoneNameLineCount[1].Trim() == ZoneDetails)
            {
                lblTotalResponse.Text = ZoneNameLineCount[2].Trim();
                lblConfirmed.Text = ZoneNameLineCount[3].Trim();
                lblRejected.Text = ZoneNameLineCount[4].Trim();
                lblDenny.Text = ZoneNameLineCount[5].Trim();

                div_File.Visible = false;
                div_grd.Visible = true;
                div_SeachDetails.Visible = true;
                

                //--------------------------Confirmed ---------------------------------------------------
                String ReadFirstLine = lines[1];
                string[] stringSeparatorsReadFirstLine = new string[] { "\t" };
                var FirstLineCount = ReadFirstLine.Split(stringSeparatorsReadFirstLine, StringSplitOptions.None);


                //--------------Compare with uploaded_Excel_Data-----------------------------
                String ReadFRN = FirstLineCount[1]; // lines[2];
                string[] stringSeparatorsReadFRNRow = new string[] { "," };
                var TotalReq = ReadFRN.Split(stringSeparatorsReadFRNRow, StringSplitOptions.None);

                string AlreadyReq="";
               
                if (TotalReq.Count() > 0)
                {

                    int loop = 0;
                    for (int i = 0; i <= TotalReq.Count() - 2; i++)
                    {

                        if (TotalReq[i].ToString().Substring(0, 2).Trim() == "AO" || TotalReq[i].ToString().Substring(0, 2).Trim() == "AR" || TotalReq[i].ToString().Substring(0, 2).Trim() == "CR" || TotalReq[i].ToString().Substring(0, 2).Trim() == "NG")
                        {
                            //-----------------Search in Upload excel data C table--------------------
                            ObjGenBal = new BaseLayer.General_function();
                            string QuerCountFound = "select count(*) from tbl_confirm_eligibility_offline where form_no='" + TotalReq[i].ToString().Trim() + "' and zonename='" + ZoneDetails + "'";

                            DataTable dt = new DataTable();
                            dt = ObjGenBal.FetchData(QuerCountFound);
                            if ( Convert.ToInt32( dt.Rows[0].ItemArray[0].ToString() ) > 0)
                            {
                                AlreadyReq = AlreadyReq + TotalReq[i].ToString().Trim() + "','";
                            }

                        }
                        else
                        {
                            loop++;
                        }
                        count++;
                    }

                    if (count > 0)
                    {
                        ViewState["ConfirmRecord"] = AlreadyReq;


                        //----------------------Create Data Table ---------------------------
                        DataTable myDataTable = new DataTable();

                        DataColumn myDataColumn;



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
                        myDataColumn.ColumnName = "FirstName";
                        myDataTable.Columns.Add(myDataColumn);


                        myDataColumn = new DataColumn();
                        myDataColumn.DataType = Type.GetType("System.String");
                        myDataColumn.ColumnName = "LastName";
                        myDataTable.Columns.Add(myDataColumn);


                        string queryforzonename = "Select CerpacNo, FORMNO, FirstName, LastName from Uploaded_Excel_Data where FORMNO in ('" + AlreadyReq + "')";
                         objgenenral = new BaseLayer.General_function();
                         DataTable dtConfirm = new DataTable();

                         dtConfirm = objgenenral.FetchData(queryforzonename);
                      if (dtConfirm.Rows.Count > 0)
                      {
                          for (int i = 0; i <= dtConfirm.Rows.Count -1; i++)
                          {
                             
                              //---------------------------Insert Data in DataTable------------------            

                              DataRow row;

                              row = myDataTable.NewRow();

                              //row["id"] = Guid.NewGuid().ToString();
                              row["CerpacNo"] = dtConfirm.Rows[i]["CerpacNo"];
                              row["FormNo"] = dtConfirm.Rows[i]["FormNo"];
                              row["FirstName"] = dtConfirm.Rows[i]["FirstName"];
                              row["LastName"] = dtConfirm.Rows[i]["LastName"];

                              myDataTable.Rows.Add(row);
                          }

                          if (myDataTable.Rows.Count > 0)
                          {
                              lblConfirm.Text = "Confirm Eligibility";
                              grd_display_Rejecteddata.DataSource = myDataTable;
                              grd_display_Rejecteddata.DataBind();
                              div_Save.Visible = true;

                              
                          }
                      }



                    }

                }

                //--------------------------Reject ---------------------------------------------------
               
                String ReadSecondLine = lines[2];
                string[] stringSeparatorsReadSecondLine = new string[] { "\t" };
                var SecondLineCount = ReadSecondLine.Split(stringSeparatorsReadSecondLine, StringSplitOptions.None);


                //--------------Rejected with uploaded_Excel_Data-----------------------------
                String ReadFRNRejected = SecondLineCount[1]; // lines[2];
                string[] stringSeparatorsReadRejectedRow = new string[] { "," };
                var TotalRejected = ReadFRNRejected.Split(stringSeparatorsReadRejectedRow, StringSplitOptions.None);

                string AlreadyRejected = "";
               
                if (TotalRejected.Count() > 0)
                {

                    int loop = 0;
                    for (int i = 0; i <= TotalRejected.Count() - 2; i++)
                    {

                        if (TotalRejected[i].ToString().Substring(0, 2).Trim() == "AO" || TotalRejected[i].ToString().Substring(0, 2).Trim() == "AR" || TotalRejected[i].ToString().Substring(0, 2).Trim() == "CR" || TotalRejected[i].ToString().Substring(0, 2).Trim() == "NG")
                        {
                            //-----------------Search in Upload excel data C table--------------------
                            ObjGenBal = new BaseLayer.General_function();
                            string QuerCountFound = "select count(*) from tbl_confirm_eligibility_offline where form_no='" + TotalRejected[i].ToString().Trim() + "' and zonename='" + ZoneDetails + "'";

                            DataTable dt = new DataTable();
                            dt = ObjGenBal.FetchData(QuerCountFound);
                            if (Convert.ToInt32(dt.Rows[0].ItemArray[0].ToString()) > 0)
                            {
                                AlreadyRejected = AlreadyRejected + TotalRejected[i].ToString().Trim() + "','";
                            }

                        }
                        else
                        {
                            loop++;
                        }
                        countrej++;
                    }

                    if (countrej > 0)
                    {
                        ViewState["RejectRecord"] = AlreadyRejected;


                        //----------------------Create Data Table ---------------------------
                        DataTable myDataTable = new DataTable();

                        DataColumn myDataColumn;



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
                        myDataColumn.ColumnName = "FirstName";
                        myDataTable.Columns.Add(myDataColumn);


                        myDataColumn = new DataColumn();
                        myDataColumn.DataType = Type.GetType("System.String");
                        myDataColumn.ColumnName = "LastName";
                        myDataTable.Columns.Add(myDataColumn);


                        string queryforzonename = "Select CerpacNo, FORMNO, FirstName, LastName from Uploaded_Excel_Data where FORMNO in ('" + AlreadyRejected + "')";
                        objgenenral = new BaseLayer.General_function();
                        DataTable dtReject = new DataTable();

                        dtReject = objgenenral.FetchData(queryforzonename);
                        if (dtReject.Rows.Count > 0)
                        {
                            for (int i = 0; i <= dtReject.Rows.Count - 1; i++)
                            {

                                //---------------------------Insert Data in DataTable------------------            

                                DataRow row;

                                row = myDataTable.NewRow();

                                //row["id"] = Guid.NewGuid().ToString();
                                row["CerpacNo"] = dtReject.Rows[i]["CerpacNo"];
                                row["FormNo"] = dtReject.Rows[i]["FormNo"];
                                row["FirstName"] = dtReject.Rows[i]["FirstName"];
                                row["LastName"] = dtReject.Rows[i]["LastName"];

                                myDataTable.Rows.Add(row);
                            }

                            if (myDataTable.Rows.Count > 0)
                            {
                                lblReject.Text = "Rejected Eligibility";
                                grd_display_data.DataSource = myDataTable;
                                grd_display_data.DataBind();
                                div_rejected_Data.Visible = true;
                                
                            }
                        }



                    }

                }


                //--------------------------Denny ---------------------------------------------------
               

                String ReadthirdLine = lines[3];
                string[] stringSeparatorsReadthirdLine = new string[] { "\t" };
                var thirdLineCount = ReadthirdLine.Split(stringSeparatorsReadthirdLine, StringSplitOptions.None);

                //--------------Rejected with uploaded_Excel_Data-----------------------------
                String ReadFRNDeny = thirdLineCount[1]; // lines[2];
                string[] stringSeparatorsReadDenyRow = new string[] { "," };
                var TotalDeny = ReadFRNDeny.Split(stringSeparatorsReadDenyRow, StringSplitOptions.None);

                string AlreadyDeny = "";
               
                if (TotalDeny.Count() > 0)
                {

                    int loop = 0;
                    for (int i = 0; i <= TotalDeny.Count() - 2; i++)
                    {

                        if (TotalDeny[i].ToString().Substring(0, 2).Trim() == "AO" || TotalDeny[i].ToString().Substring(0, 2).Trim() == "AR" || TotalDeny[i].ToString().Substring(0, 2).Trim() == "CR" || TotalDeny[i].ToString().Substring(0, 2).Trim() == "NG")
                        {
                            //-----------------Search in Upload excel data C table--------------------
                            ObjGenBal = new BaseLayer.General_function();
                            string QuerCountFound = "select count(*) from tbl_confirm_eligibility_offline where form_no='" + TotalDeny[i].ToString().Trim() + "' and zonename='" + ZoneDetails + "'";

                            DataTable dt = new DataTable();
                            dt = ObjGenBal.FetchData(QuerCountFound);
                            if (Convert.ToInt32(dt.Rows[0].ItemArray[0].ToString()) > 0)
                            {
                                AlreadyDeny = AlreadyDeny + TotalDeny[i].ToString().Trim() + "','";
                            }

                        }
                        else
                        {
                            loop++;
                        }
                        countdeny++;
                    }

                 
                    if (countdeny > 0)
                    {
                           ViewState["DenyRecord"] = AlreadyDeny;

                        //----------------------Create Data Table ---------------------------
                        DataTable myDataTable = new DataTable();

                        DataColumn myDataColumn;



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
                        myDataColumn.ColumnName = "FirstName";
                        myDataTable.Columns.Add(myDataColumn);


                        myDataColumn = new DataColumn();
                        myDataColumn.DataType = Type.GetType("System.String");
                        myDataColumn.ColumnName = "LastName";
                        myDataTable.Columns.Add(myDataColumn);


                        string queryforzonename = "Select CerpacNo, FORMNO, FirstName, LastName from Uploaded_Excel_Data where FORMNO in ('" + AlreadyDeny + "')";
                        objgenenral = new BaseLayer.General_function();
                        DataTable dtDeny = new DataTable();

                        dtDeny = objgenenral.FetchData(queryforzonename);
                        if (dtDeny.Rows.Count > 0)
                        {
                            for (int i = 0; i <= dtDeny.Rows.Count - 1; i++)
                            {

                                //---------------------------Insert Data in DataTable------------------            

                                DataRow row;

                                row = myDataTable.NewRow();

                                //row["id"] = Guid.NewGuid().ToString();
                                row["CerpacNo"] = dtDeny.Rows[i]["CerpacNo"];
                                row["FormNo"] = dtDeny.Rows[i]["FormNo"];
                                row["FirstName"] = dtDeny.Rows[i]["FirstName"];
                                row["LastName"] = dtDeny.Rows[i]["LastName"];

                                myDataTable.Rows.Add(row);
                            }

                            if (myDataTable.Rows.Count > 0)
                            {
                                lblDenyComp.Text = "Completely Denny";
                                grd_deny_Data.DataSource = myDataTable;
                                grd_deny_Data.DataBind();
                                div_Deny_Data.Visible = true;
                            }
                        }



                    }

                }


                //--------------------------Confirmed Details---------------------------------------------------
                String ReadFirstDetailsLine = lines[4];
                string[] stringSeparatorsReadFirstDetailsLine = new string[] { "-###-" };
                var FirstDetailsLineCount = ReadFirstDetailsLine.Split(stringSeparatorsReadFirstDetailsLine, StringSplitOptions.None);
                //--------------------------Reject Details---------------------------------------------------

                String ReadSecondDetailsLine = lines[5];
                string[] stringSeparatorsReadSecondDetailsLine = new string[] { "-###-" };
                var SecondDetailsLineCount = ReadSecondDetailsLine.Split(stringSeparatorsReadSecondDetailsLine, StringSplitOptions.None);
                //--------------------------Denny Details---------------------------------------------------


                String ReadthirdDetailsLine = lines[6];
                string[] stringSeparatorsReadthirdDetailsLine = new string[] { "-###-" };
                var thirdDetailsLineCount = ReadthirdDetailsLine.Split(stringSeparatorsReadthirdDetailsLine, StringSplitOptions.None);


            }

            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Uploaded file don't belongs to your zone !! '); window.location = '" + Page.ResolveUrl("frmConfirmEligibilityZone_Import.aspx") + "';", true);

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


    //public void SplitString()
    //{
    //    try
    //    {
    //        //int i = Convert.ToInt32(File.ReadAllLines(output).Count());

    //        //----------------------Create Data Table ---------------------------
    //        DataTable myDataTable = new DataTable();

    //        DataColumn myDataColumn;

           

    //        myDataColumn = new DataColumn();
    //        myDataColumn.DataType = Type.GetType("System.String");
    //        myDataColumn.ColumnName = "CerpacNo";
    //        myDataTable.Columns.Add(myDataColumn);

    //        myDataColumn = new DataColumn();
    //        myDataColumn.DataType = Type.GetType("System.String");
    //        myDataColumn.ColumnName = "FormNo";
    //        myDataTable.Columns.Add(myDataColumn);

    //        myDataColumn = new DataColumn();
    //        myDataColumn.DataType = Type.GetType("System.String");
    //        myDataColumn.ColumnName = "FirstName";
    //        myDataTable.Columns.Add(myDataColumn);
           

    //        myDataColumn = new DataColumn();
    //        myDataColumn.DataType = Type.GetType("System.String");
    //        myDataColumn.ColumnName = "LastName";
    //        myDataTable.Columns.Add(myDataColumn);






    //        //for (int i = 1; i <= resultfresh.Count() - 2; i++)
    //        //{
    //        //    String FresRow = resultfresh[i]; // lines[2];
    //        //    string[] stringSeparatorsFresRow = new string[] { "\t" };

    //        //    var PeopleFresRowCount = FresRow.Split(stringSeparatorsFresRow, StringSplitOptions.None);

    //        //    //---------------------------Insert Data in DataTable------------------            

    //        //    DataRow row;

    //        //    row = myDataTable.NewRow();

    //        //    //row["id"] = Guid.NewGuid().ToString();
    //        //    row["Date1"] = PeopleFresRowCount[0];
    //        //    row["FirstName"] = PeopleFresRowCount[1];
    //        //    row["MiddleName"] = PeopleFresRowCount[2];
    //        //    row["LastName"] = PeopleFresRowCount[3];
    //        //    row["Company"] = PeopleFresRowCount[4];
    //        //    row["Nationality"] = PeopleFresRowCount[5];
    //        //    row["FormNo"] = PeopleFresRowCount[7];
    //        //    row["PassportNo"] = PeopleFresRowCount[9];
    //        //    row["StrVisaNo"] = PeopleFresRowCount[10];
    //        //    row["TellerNo"] = PeopleFresRowCount[11];



    //        //    myDataTable.Rows.Add(row);
    //        //}



    //        //-----------------Transfer Basice Details -------------------------
    //        string[] lines = System.IO.File.ReadAllLines((output));

    //        //------------------Split Zone Name----------------------------------
    //        String source = lines[0];
    //        string[] stringSeparators = new string[] { "\t" };
    //        var result = source.Split(stringSeparators, StringSplitOptions.None);
    //        String ReceivedZone = result[1];
    //        lblZonename.Text = lines[0];


    //       lblTotalResponse.Text = lines[1];
    //       lblConfirmed.Text = lines[2];
    //       lblRejected.Text = lines[3];
    //       lblDenny.Text = lines[4];
    //        //-----------------------Split Fresh Case Bank Details------------------

    //        String Data1 = lines[1];

    //        if (FileUpload1.HasFile)
    //        {
    //            if (Data1.Contains("-###-"))
    //            {
    //                Data1 = lines[5];
    //                string[] stringSeparatorsdata1 = new string[] { "-###-" };
    //                var resultfresh = Data1.Split(stringSeparatorsdata1, StringSplitOptions.None);


    //                for (int i = 1; i <= resultfresh.Count() - 2; i++)
    //                {
    //                    String FresRow = resultfresh[i]; // lines[2];
    //                    string[] stringSeparatorsFresRow = new string[] { "\t" };

    //                    var PeopleFresRowCount = FresRow.Split(stringSeparatorsFresRow, StringSplitOptions.None);

    //                    //---------------------------Insert Data in DataTable------------------            

    //                    DataRow row;

    //                    row = myDataTable.NewRow();

    //                    //row["id"] = Guid.NewGuid().ToString();
    //                    row["Date1"] = PeopleFresRowCount[0];
    //                    row["FirstName"] = PeopleFresRowCount[1];
    //                    row["MiddleName"] = PeopleFresRowCount[2];
    //                    row["LastName"] = PeopleFresRowCount[3];
    //                    row["Company"] = PeopleFresRowCount[4];
    //                    row["Nationality"] = PeopleFresRowCount[5];
    //                    row["FormNo"] = PeopleFresRowCount[7];
    //                    row["PassportNo"] = PeopleFresRowCount[9];
    //                    row["StrVisaNo"] = PeopleFresRowCount[10];
    //                    row["TellerNo"] = PeopleFresRowCount[11];



    //                    myDataTable.Rows.Add(row);
    //                }
    //                //--------------------Bind DataGrid by datatable-------------------------------
    //                if (Page.IsPostBack)
    //                {

    //                    Session["myDatatable"] = myDataTable;

    //                    this.grd_display_data.DataSource = ((DataTable)Session["myDatatable"]).DefaultView;
    //                    this.grd_display_data.DataBind();

    //                    //divSearchCerpac.Visible = false;
    //                    //divgrdCerpac.Visible = false;
    //                }



    //            }

    //                //--------------------Bind DataGrid by datatable-------------------------------
    //                if (Page.IsPostBack)
    //                {

    //                 //   Session["myPeopleTable"] = myPeopleTable;

    //                    //this.grd_CerpacNo.DataSource = ((DataTable)Session["myPeopleTable"]).DefaultView;
    //                    //this.grd_CerpacNo.DataBind();

    //                    //divSearchCerpac.Visible = true;
    //                    //divgrdCerpac.Visible = true;
    //                }


    //            }



            
    //    }


    //    catch (Exception ex)
    //    {
    //        ObjGenBal = new BaseLayer.General_function();
    //        string err = ObjGenBal.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
    //        LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
    //        LabelMessage.CssClass = "warning-box";
    //        LabelMessage.Visible = true;

    //    }
    //    finally
    //    {
    //        dt = null;
    //        ObjGenBal = null;
    //    }

    //}
   
    //protected void btnEncrypt_Click(object sender, EventArgs e)
    //{
        
    //    string xmlfilename = "default.xml";
    //    string foldername = "Central Server Replay --" + DateTime.Now.ToString().Replace("/", "").Replace(":", "");
    //    string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
    //    filePath = filePath + @"\";

    // //   if ( TextAppId.Text != "")
    //    {

    //        if (!Directory.Exists(filePath))
    //        {
    //            Directory.CreateDirectory(filePath);
    //        }
    //        xmlfilename = "Central Server Replay --" + DateTime.Now.ToString().Replace("/", "").Replace(":", "") + ".xml";

    //        if (File.Exists(Path.Combine(filePath, filePath + @"\" + xmlfilename.ToString().Trim())))
    //        {
    //            File.Delete(Path.Combine(filePath, filePath + @"\" + xmlfilename.ToString().Trim()));
    //        }

    //        System.IO.StreamWriter s = File.CreateText(System.IO.Path.Combine(filePath, filePath + @"\" + xmlfilename.ToString().Trim()));


    //        //string compdata = "Central Replay" + "  " + lblRequestedZone.Text.Trim().ToString() + DateTime.Now.ToString().Replace("/", "").Replace(":", "");
    //       // string compdata;
    //        objgenenral = new BaseLayer.General_function();
    //       // string quer = "select Date1,FirstName, MiddleName, LastName, Company, Nationality, RequisitionNo, FormNo, CerpacNo, PassportNo, isnull(StrVisaNo,'') as StrVisaNo,tellerno,amount from uploaded_excel_data where formno in ('" + TextAppId.Text.Replace(",", "','") + "') and isnull(CerpacNo, '')=''";
    //        string quer = "";

    //        try
    //        {


    //            dtform = objgenenral.FetchData(quer);               
    //            for (int i = 0; i <= dtform.Rows.Count - 1; i++)

    //            {
    //                s.WriteLine(grd_display_data.Rows[i].Cells[0].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[1].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[2].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[3].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[4].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[5].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[6].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[7].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[8].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[9].Text.ToString() + "\t" + grd_display_data.Rows[i].Cells[10].Text.ToString()); ;
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
    //            dt = null;
    //            objgenenral = null;
    //        }
            
    //       // s.WriteLine(compdata);
         
    //        s.Dispose();
    //    }
    //    if (File.Exists(Path.Combine(filePath, filePath + @"\" + xmlfilename.ToString().Trim())))
    //    {
    //        //Get the Input File Name and Extension.
    //        string fileName = Path.GetFileNameWithoutExtension(filePath + @"\" + xmlfilename.ToString().Trim());
    //        string fileExtension = Path.GetExtension(filePath + @"\" + xmlfilename.ToString().Trim());

    //        //Build the File Path for the original (input) and the encrypted (output) file.
    //        string input = filePath + @"\" + fileName + fileExtension;
    //        string output = filePath + @"\" + fileName + "_enc" + fileExtension;

    //        //Save the Input File, Encrypt it and save the encrypted file in output path.
    //       this.Encrypt(input, output);

    //        File.Delete(input);
    //        //File.Delete(output);

    //        Response.End();
    //    }

    //}

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


    public int confirmeligibility(string CerpacV1, string UserIDV2, DateTime confirmon)
    {
        SqlParameter[] pram = null;

        pram = new SqlParameter[4];
        pram[0] = new SqlParameter("@UserId", UserIDV2.Trim());
        pram[1] = new SqlParameter("@cerpacno", CerpacV1.Trim());
        pram[2] = new SqlParameter("@confirmon", confirmon);
        pram[3] = new SqlParameter("@SuccessId", 1);
        pram[3].Direction = ParameterDirection.Output;
        SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_CERPAC_DATA_CONFIRM_OFF", pram);
        return int.Parse(pram[3].Value.ToString());
    }

    public int defer(string CerpacW1, string UserIDW2, DateTime confirmon)
    {
        SqlParameter[] pram = null;

        pram = new SqlParameter[4];
        pram[0] = new SqlParameter("@UserId",UserIDW2.Trim());
        pram[1] = new SqlParameter("@cerpacno", CerpacW1.Trim());
        pram[2] = new SqlParameter("@confirmon", confirmon);
        pram[3] = new SqlParameter("@SuccessId", 1);
        pram[3].Direction = ParameterDirection.Output;
        SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_CERPAC_DATA_DEFER_OFF", pram);
        return int.Parse(pram[3].Value.ToString());

    }

    public int denycompletely(string cerpacno, string frnno, string cerpac_Expiry, string cerpac_issue, string UserIDX3, DateTime confirmon)
    {
        SqlParameter[] pram = null;

        pram = new SqlParameter[8];
        pram[0] = new SqlParameter("@UserId", UserIDX3);
        pram[1] = new SqlParameter("@cerpacno", cerpacno.ToString());
        pram[2] = new SqlParameter("@frnno", frnno);
        pram[3] = new SqlParameter("@reason", "offline Mode");
        pram[4] = new SqlParameter("@cerpac_expiry_date", cerpac_Expiry.Trim());
        pram[5] = new SqlParameter("@cerpac_receipt_date", cerpac_issue.Trim());
        pram[6] = new SqlParameter("@confirmon", confirmon);
        pram[7] = new SqlParameter("@SuccessId", 1);
        pram[7].Direction = ParameterDirection.Output;
        SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_CERPAC_DATA_DENY_COMPLETELY_OFF", pram);
        return int.Parse(pram[7].Value.ToString());
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        String MsgC = "", MsgR = "", MsgD = "";
        
        try
        {
        string foldername = "Decrypt File";
        string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        filePath = filePath + @"\" + foldername;

        if (!Directory.Exists(filePath))
        {
            Directory.CreateDirectory(filePath);
        }

        //Get the Input File Name and Extension
        string fileName = Path.GetFileNameWithoutExtension(ViewState["FileAddress"].ToString());
        string fileExtension = Path.GetExtension(ViewState["FileAddress"].ToString());

        input = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + fileName + fileExtension;
        ViewState["InputFile"] = input;


        output = filePath + @"\" + fileName + "_dec" + fileExtension;
        ViewState["OutputFile"] = output;

        //Save the Input File, Decrypt it and save the decrypted file in output path.
        this.Decrypt(input, output);


      
        string[] lines = System.IO.File.ReadAllLines((output));

        String ZoneNameLine = lines[0];
        string[] stringSeparatorsZoneNameLine = new string[] { "\t" };
        var ZoneNameLineCount = ZoneNameLine.Split(stringSeparatorsZoneNameLine, StringSplitOptions.None);
        lblZonename.Text = ZoneNameLineCount[1].Trim();
        
        //--------------------------------------

        String ReadFirstLine = lines[1];
        string[] stringSeparatorsReadFirstLine = new string[] { "\t" };
        var FirstLineCount = ReadFirstLine.Split(stringSeparatorsReadFirstLine, StringSplitOptions.None);
        string conform = FirstLineCount[1].Trim();

        String ReadSceandLine = lines[2];
        string[] stringSeparatorsReadSceandLine = new string[] { "\t" };
        var SceandLineCount = ReadSceandLine.Split(stringSeparatorsReadSceandLine, StringSplitOptions.None);
        string Rejform = SceandLineCount[1].Trim();

        String ReadthirdLine = lines[3];
        string[] stringSeparatorsReadthirdLine = new string[] { "\t" };
        var thirdLineCount = ReadthirdLine.Split(stringSeparatorsReadthirdLine, StringSplitOptions.None);
        string Denyform = thirdLineCount[1].Trim();

        string Auditform = conform + "," + Rejform + "," + Denyform;

        //--------------------------Confirmed ---------------------------------------------------
        
             
        String ReadForthLine = lines[4];
        string[] stringSeparatorsReadForthLine = new string[] { "-###-" };
        var ForthLineCount = ReadForthLine.Split(stringSeparatorsReadForthLine, StringSplitOptions.None);
        string V1 ="" , V2 = "";
        DateTime V3;
        for (int i = 1; i <= ForthLineCount.Count() - 2; i++)
        {
            if (ForthLineCount[i] != "")
            {
                //--------------Compare with uploaded_Excel_Data-----------------------------
                String ReadFRN = ForthLineCount[i].Trim();
                string[] stringSeparatorsReadFRNRow = new string[] { "\t" };
                var TotalReq = ReadFRN.Split(stringSeparatorsReadFRNRow, StringSplitOptions.None);


                V1 = TotalReq[0].Trim();
                V2 = TotalReq[7].Trim();
                V3 = Convert.ToDateTime(TotalReq[8].Trim());

                int status = confirmeligibility(V1,V2,V3);
                if (status == 1)
                {

                    MsgC =  "Confirmed";
                }
            }
             
         }
        
           
               
            

            //--------------------------Reject Details---------------------------------------------------

         
             String ReadFifthLine = lines[5];
             string[] stringSeparatorsReadFifthLine = new string[] { "-###-" };
             var FifthLineCount = ReadFifthLine.Split(stringSeparatorsReadFifthLine, StringSplitOptions.None);
             string W1 = "", W2 = "";
             DateTime W3;   
             if (FifthLineCount.Count() > 0)
             {
                 for (int i = 1; i <= FifthLineCount.Count() - 2; i++)
                 {
                     if (FifthLineCount[i] != "")
                     {
                         //--------------sub sting splite-----------------------------
                         String ReadFRN = FifthLineCount[i].Trim();
                         string[] stringSeparatorsReadFRNRow = new string[] { "\t" };
                         var TotalReq = ReadFRN.Split(stringSeparatorsReadFRNRow, StringSplitOptions.None);


                         W1 = TotalReq[0].Trim();
                         W2 = TotalReq[7].Trim();
                         W3 = Convert.ToDateTime(TotalReq[8].Trim());

                         int status = defer(W1, W2, W3);
                         if (status == 1)
                         {

                             MsgR = "Rejected";
                         }
                     }

                 }
                
             }
                

            
            
            //--------------------------Denny Details---------------------------------------------------

        

             String ReadSixLine = lines[6];
             string[] stringSeparatorsReadSixLine = new string[] { "-###-" };
             var SixLineCount = ReadFifthLine.Split(stringSeparatorsReadSixLine, StringSplitOptions.None);
             string X1 = "", X2 = "",  X3="";
             DateTime X4;
             int result = 0;

             for (int i = 1; i <= SixLineCount.Count() - 2; i++)
             {
                 if (SixLineCount[i] != "")
                 {
                     //--------------sub sting splite-----------------------------
                     String ReadFRN = SixLineCount[i].Trim();
                     string[] stringSeparatorsReadFRNRow = new string[] { "\t" };
                     var TotalReq = ReadFRN.Split(stringSeparatorsReadFRNRow, StringSplitOptions.None);

                     X1 = TotalReq[0].Trim();
                     X2 = TotalReq[1].Trim();
                     X3 = TotalReq[7].Trim();
                     X4 = Convert.ToDateTime(TotalReq[8].Trim());

                    //------------------PeopleChild-----------------------------
                     ObjGenBal = new BaseLayer.General_function();
                     string peoplechildquery = "Select * from Peoplechild where cerpacno='" + X1.Trim() + "' and formno='"+X2.Trim() +"' and IsAuthorized=1 and (IsARCR is null or IsARCR=0 or IsARCR='') and (IsProduced is null or IsProduced=0)";
                     DataTable dtpc = null;
                     dtpc = new DataTable();
                     dtpc = ObjGenBal.FetchData(peoplechildquery);
                     if (dtpc.Rows.Count ==  1)
                     {
                         
                          string cerpacno = dtpc.Rows[0]["cerpacno"].ToString().Trim();
                          string frnno = dtpc.Rows[0]["FORMNO"].ToString().Trim();
                          string cerpac_Expiry= dtpc.Rows[0]["cerpac_expiry_date"].ToString().Trim();
                          string cerpac_Issue = dtpc.Rows[0]["cerpac_receipt_date"].ToString().Trim();
                          int status = denycompletely(cerpacno, frnno, cerpac_Expiry, cerpac_Issue, X3, X4);
                          result = result + status;
                         }
                     if (result > 0)
                     {
                         MsgD = " Denny";
                     }
                 }
                
             }
            //---------------------------Update in Audit table -------------------------------------
 
            //---------------Audit trail in bank request formno.'s---------------------

            Auditform = Auditform.Replace(",,",",").Replace(",","','");

            if (Auditform != "")
            {
                
                    //-----------------tbl_confirm_eligibility_offline table--------------------
                    ObjGenBal = new BaseLayer.General_function();
                    string QuerCountFound = "select count(*) from tbl_confirm_eligibility_offline where  Form_no in ('" + Auditform.Trim() + "')";

                    DataTable dt = new DataTable();
                    dt = ObjGenBal.FetchData(QuerCountFound);

                    if (dt.Rows.Count > 0)
                    {
                    

                        SqlConnection Connection = new SqlConnection();
                        Connection.ConnectionString = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;

                        SqlCommand Command = new SqlCommand("update tbl_confirm_eligibility_offline set confirmres=1 , confirmresdate = getdate(), userid = '" + UserID.ToString().Trim() + "' where form_no in ('" + Auditform + "')", Connection);
                        Connection.Open();
                        Command.ExecuteNonQuery();
                        Connection.Close();



                    }
                    
                
            }
//------------------------------------

         }
         catch (Exception ex)
         {
             ObjGenBal = new BaseLayer.General_function();
             string err = ObjGenBal.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
             LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
             LabelMessage.Visible = true;
         }
         finally
         {
             if (MsgC != "")
             {
                 ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('All " + MsgC + " forms are sucessfull uploaded !!.'); window.location = '" + Page.ResolveUrl("frmImportConfirmVerificationFile.aspx") + "';", true);

             }
             if (MsgR != "")
             {
                 ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('All " + MsgR + " forms are sucessfull uploaded !!.'); window.location = '" + Page.ResolveUrl("frmImportConfirmVerificationFile.aspx") + "';", true);

             } if (MsgD != "")
             {
                 ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('All " + MsgD + " forms are sucessfull uploaded !!.'); window.location = '" + Page.ResolveUrl("frmImportConfirmVerificationFile.aspx") + "';", true);

             }

             ObjGenBal = null;
         }                
            
            
    }
}