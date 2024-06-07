using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.IO;
using System.Configuration;
using System.Collections;
using System.Globalization;

public partial class Bank_UploadBankData : System.Web.UI.Page
{
    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    BaseLayer.General_function objgenenral = null;
    //BaseLayer.General_function ObjGeneral = null;
    protected BaseLayer.General_function ObjGenBal = null;
    int excp = 0;
    #endregion

    BusinessEntityLayer.BankUserData ObjFetchData = null;
    BaseLayer.General_function ObjGeneral = null;


    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            BaseLayer.General_function ObjGeneral = new BaseLayer.General_function();
            objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];


            if (objectSessionHolderPersistingData == null)
            {
                Response.Redirect("../Login.aspx");
            }

            if (!IsPostBack)
            {
                btnCopy.Visible = false;
                upload_div.Visible = false;
            }
        }
        catch (Exception ex)
        {
            Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            ObjGenBal = new BaseLayer.General_function();
            string err = ObjGenBal.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.CssClass = "warning-box";
        }
        finally
        {
            ObjGenBal = null;

        }
    }
    protected void gvProducts_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {

            //SaveCheckedValues();
            //List<int> list = new List<int>();
            //if (ViewState["SelectedRecords"] != null)
            //{
            //    list = (List<int>)ViewState["SelectedRecords"];
            //}
            //foreach (GridViewRow row in gvProducts.Rows)
            //{
            //    CheckBox chk = (CheckBox)row.FindControl("cbSelCerpacrec");
            //    var selectedKey =
            //    int.Parse(gvProducts.DataKeys[row.RowIndex].Value.ToString());
            //    if (chk.Checked)
            //    {
            //        if (!list.Contains(selectedKey))
            //        {
            //            list.Add(selectedKey);
            //        }
            //    }
            //    else
            //    {
            //        if (list.Contains(selectedKey))
            //        {
            //            list.Remove(selectedKey);
            //        }
            //    }
            //}
            //ViewState["SelectedRecords"] = list;
            //gvProducts.PageIndex = e.NewPageIndex;

            //BindData();
            //PopulateCheckedValues();



            gvProducts.PageIndex = e.NewPageIndex;
            BindData();
        }
        catch (Exception ex)
        {
            Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            ObjGenBal = new BaseLayer.General_function();
            string err = ObjGenBal.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.CssClass = "warning-box";
        }
        finally
        {
            ObjGenBal = null;

        }
    }

    private void SaveCheckedValues()
    {
        try
        {
            ArrayList userdetails = new ArrayList();
            int index = -1;
            foreach (GridViewRow gvrow in gvProducts.Rows)
            {
                index = Convert.ToInt32(gvProducts.DataKeys[gvrow.RowIndex].Value);
                bool result = ((CheckBox)gvrow.FindControl("cbSelCerpacrec")).Checked;

                // Check in the Session
                if (Session["CHECKED_ITEMS"] != null)
                    userdetails = (ArrayList)Session["CHECKED_ITEMS"];
                if (result)
                {
                    if (!userdetails.Contains(index))
                        userdetails.Add(index);
                }
                else
                    userdetails.Remove(index);
            }
            if (userdetails != null && userdetails.Count > 0)
                Session["CHECKED_ITEMS"] = userdetails;
        }
        catch (Exception ex)
        {
            Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            ObjGenBal = new BaseLayer.General_function();
            string err = ObjGenBal.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.CssClass = "warning-box";
        }
        finally
        {
            ObjGenBal = null;

        }
    }

    private void PopulateCheckedValues()
    {
        try
        {
            ArrayList userdetails = (ArrayList)Session["CHECKED_ITEMS"];
            if (userdetails != null && userdetails.Count > 0)
            {
                foreach (GridViewRow gvrow in gvProducts.Rows)
                {
                    int index = Convert.ToInt32(gvProducts.DataKeys[gvrow.RowIndex].Value);
                    if (userdetails.Contains(index))
                    {
                        CheckBox myCheckBox = (CheckBox)gvrow.FindControl("cbSelCerpacrec");
                        myCheckBox.Checked = true;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            ObjGenBal = new BaseLayer.General_function();
            string err = ObjGenBal.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.CssClass = "warning-box";
        }
        finally
        {
            ObjGenBal = null;

        }
    }

    protected void btnImport_Click1(object sender, EventArgs e)
    {
        try
        {
            // string connString1 = "";
            HttpPostedFile file = fileuploadExcel.PostedFile;
            string strFileType = Path.GetExtension(fileuploadExcel.FileName).ToLower();
            string path = fileuploadExcel.PostedFile.FileName;
            string path2 = Path.GetFullPath(fileuploadExcel.PostedFile.FileName);//check here path is valid or not yes 
            string excelPath = @"E:\Book1.xls";
            String connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};" +
                "Extended Properties='Excel 8.0;HDR=Yes'";
            connString = String.Format(connString, excelPath);
            OleDbConnection conn = new OleDbConnection(connString);
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataAdapter adap = new OleDbDataAdapter();

            DataTable dt = new DataTable();
            cmd.Connection = conn;
            conn.Open();

            //Read the name of the first sheet in the Excel document
            DataTable dtSheet;
            dtSheet = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string sheet = dtSheet.Rows[0]["TABLE_NAME"].ToString();

            //Read data from the first sheet
            cmd.CommandText = "SELECT * From [" + sheet + "]";
            adap.SelectCommand = cmd;
            adap.Fill(dt);
            conn.Close();

            //Bind the data to GridView
            gvProducts.DataSource = dt;
            gvProducts.DataBind();
        }
        catch (Exception ex)
        {
            Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            ObjGenBal = new BaseLayer.General_function();
            string err = ObjGenBal.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.CssClass = "warning-box";
        }
        finally
        {
            ObjGenBal = null;

        }
    }

    DataSet sampleDataSet = new DataSet();
    public DataTable getdata()
    {
        
            if (ViewState["Products"] != null)
                return (DataTable)ViewState["Products"];

            string FileName = System.IO.Path.GetFileName(fileuploadExcel.PostedFile.FileName);
            string strFileType = System.IO.Path.GetExtension(fileuploadExcel.PostedFile.FileName);
            // string FolderPath = System.Configuration.ConfigurationManager.AppSettings["FolderPath"];

            string FolderPath = Server.MapPath("~");
            string FilePath = FolderPath + FileName;
            fileuploadExcel.SaveAs(FilePath);
            string connString = "";
            //string strFileType = Path.GetExtension(fileuploadExcel.FileName).ToLower();
            //string path = fileuploadExcel.PostedFile.FileName;

            //string path2 = Path.GetFullPath(fileuploadExcel.PostedFile.FileName);
            ////Connection String to Excel Workbook
            if (strFileType.Trim() == ".xls")
            {
                connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FilePath + ";Extended Properties='Excel 8.0;HDR=NO;IMEX=1'";
            }
            else if (strFileType.Trim() == ".xlsx")
            {
                connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FilePath + ";Extended Properties='Excel 12.0 Xml;HDR=NO;IMEX=1'";
            }
            //connString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + path2 + ";Extended Properties=Excel 8.0;";
            string query = "SELECT * FROM [Sheet1$]";
            OleDbConnection conn = new OleDbConnection(connString);
            if (conn.State == ConnectionState.Closed)
            {
                try
                {
                    conn.Open();
                }

                catch (Exception ed)
                {
                    Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
                    ObjGenBal = new BaseLayer.General_function();
                    string err = ObjGenBal.errorhandling(ed.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
                    LabelMessage.Text = ed.Message;
                    LabelMessage.CssClass = "warning-box";
                    LabelMessage.Visible = true;
                    excp = 1;

                }
                finally
                {
                    
                }
            }
            OleDbCommand cmd = new OleDbCommand(query, conn);
            OleDbDataAdapter oleda = new OleDbDataAdapter();
            oleda.SelectCommand = cmd;
            DataSet ds = new DataSet();

            oleda.Fill(ds, "TABLE");


            sampleDataSet.Locale = CultureInfo.InvariantCulture;
            DataTable sampleDataTable = sampleDataSet.Tables.Add("SampleData");

            
             //sampleDataTable.Columns.Add("Date", typeof(DateTime));
            

            sampleDataTable.Columns.Add("Date", typeof(string));
            sampleDataTable.Columns.Add("LastName", typeof(string));
            sampleDataTable.Columns.Add("FirstName", typeof(string));
            sampleDataTable.Columns.Add("Company", typeof(string));
            sampleDataTable.Columns.Add("Nationality", typeof(string));
            sampleDataTable.Columns.Add("CerpacNo", typeof(string));
            sampleDataTable.Columns.Add("TellerNo", typeof(string));
            sampleDataTable.Columns.Add("Amount", typeof(string));

            sampleDataTable.Columns.Add("Branch", typeof(string));
            sampleDataTable.Columns.Add("RequisitionNo", typeof(string));
            sampleDataTable.Columns.Add("PassportNo", typeof(string));
            sampleDataTable.Columns.Add("MiddleName", typeof(string));
            sampleDataTable.Columns.Add("StrVisaNo", typeof(string));
            sampleDataTable.Columns.Add("FormNo", typeof(string));

            if (ds.Tables[0].Rows.Count > 0)
                btnClean.Visible = true;

            DataRow sampleDataRow;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                sampleDataRow = sampleDataTable.NewRow();
                try
                {
                    //sampleDataRow["Date"] = ds.Tables[0].Rows[i].ItemArray[0];

                    sampleDataRow["Date"] = ds.Tables[0].Rows[i].ItemArray[0].ToString().Split(' ')[0];
                }
                catch (Exception dt)
                {
                    Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
                    ObjGenBal = new BaseLayer.General_function();
                    string err = ObjGenBal.errorhandling(dt.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
                    LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
                    LabelMessage.Text = "Please put date in correct format(dd/mm/yyyy) in excel file.";
                    LabelMessage.CssClass = "warning-box";
                    LabelMessage.Visible = true;
                    excp = 1;
                   
                }
                sampleDataRow["LastName"] = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                sampleDataRow["FirstName"] = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                sampleDataRow["Company"] = ds.Tables[0].Rows[i].ItemArray[3].ToString();
                sampleDataRow["Nationality"] = ds.Tables[0].Rows[i].ItemArray[4].ToString();
                sampleDataRow["CerpacNo"] = ds.Tables[0].Rows[i].ItemArray[5].ToString();
                sampleDataRow["TellerNo"] = ds.Tables[0].Rows[i].ItemArray[6].ToString();
                sampleDataRow["Amount"] = ds.Tables[0].Rows[i].ItemArray[7].ToString();


                sampleDataRow["Branch"] = "";
                sampleDataRow["RequisitionNo"] = "";
                sampleDataRow["PassportNo"] = "";
                sampleDataRow["MiddleName"] = "";
                sampleDataRow["StrVisaNo"] = "";
                sampleDataRow["FormNo"] = ds.Tables[0].Rows[i].ItemArray[5].ToString();

                if (ds.Tables[0].Rows[i].ItemArray[5].ToString() != "")
                {

                    //if (ds.Tables[0].Rows[i].ItemArray[5].ToString().Substring(0, 2) == "AO" || ds.Tables[0].Rows[i].ItemArray[5].ToString().Substring(0, 2) == "AR" || ds.Tables[0].Rows[i].ItemArray[5].ToString().Substring(0, 2) == "CR")

                    if (ds.Tables[0].Rows[i].ItemArray[5].ToString().Substring(0, 2) != "")
                        sampleDataTable.Rows.Add(sampleDataRow);


                }
            }

            //gvProducts.DataSource = ds.Tables[0];
            //gvProducts.DataBind();
            ////da.Dispose();
            conn.Close();
            conn.Dispose();
            //  pageno.Visible = true;
            btnCopy.Visible = true;
            btnCheckAll.Visible = false;
            btnUnCheckAll.Visible = false;
            //ViewState["Products"] = ds.Tables[0];
            //return ds.Tables[0];

            ViewState["Products"] = sampleDataSet.Tables[0];
            return sampleDataSet.Tables[0];
        }
       
       

    private void BindData()
    {
        try
        {
            //Bind the grid view
            gvProducts.DataSource = getdata();
            gvProducts.DataBind();
        }
        catch (Exception ex)
        {
            Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            ObjGenBal = new BaseLayer.General_function();
            string err = ObjGenBal.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            if(LabelMessage.Text=="")
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.CssClass = "warning-box";
            LabelMessage.Visible = true;
           
           
        }
        finally
        {
            ObjGenBal = null;

        }
    }
    protected void btnImport_Click(object sender, EventArgs e)
    {
        try
        {
            string strFileType = System.IO.Path.GetExtension(fileuploadExcel.PostedFile.FileName);

            if (fileuploadExcel.PostedFile.FileName == "")
            {
                Response.Write("<script>alert('Please Select a File');</script>");
                return;
            }
            if (strFileType.Trim() != ".xls" && strFileType.Trim() != ".xlsx")
            {
                Response.Write("<script>alert('You have not uploaded a valid excel file');</script>");
                return;
            }
            BindData();
            if (excp == 1)
            {
                ViewState["Products"] = null;
                btnCopy.Visible = false;
                btnClean.Visible = false;
                return;
            }
            else
            {
                Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
                LabelMessage.Visible = false;
            }

            btnClean.Visible = true;
            gvProducts.Visible = true;
            warn.Style.Add("display", "none");
            confirm.Style.Add("display", "none");
            btnCopy.Visible = true;
            upload_div.Visible = true;
           

            lbl_excel_file.Visible = false;
            fileuploadExcel.Visible = false;
            btnImport.Visible = false;
        }
        catch (Exception ex)
        {
            Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            ObjGenBal = new BaseLayer.General_function();
            string err = ObjGenBal.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.CssClass = "warning-box";
        }
        finally
        {
            ObjGenBal = null;

        }
    }

    protected void Copy(object sender, EventArgs e)
    {
        try
        {
            BusinessEntityLayer.BankRegDetails objDetails = new BusinessEntityLayer.BankRegDetails();
           // objDetails.CleanTemp();
            CopyInTempTable();
        }
        catch (Exception ex)
        {
            Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            ObjGenBal = new BaseLayer.General_function();
            string err = ObjGenBal.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.CssClass = "warning-box";
        }
        finally
        {
            ObjGenBal = null;

        }
    }
    protected void Copy1(object sender, EventArgs e)
    {
        try
        {
            Hashtable productList = new Hashtable();
            Product product;
            foreach (GridViewRow row in gvProducts.Rows)
            {
                // Get the checkbox control that contain the user selection.
                CheckBox cbSelrecno = (CheckBox)row.FindControl("cbSelCerpacrec");


                // if (cbSelrecno != null && cbSelrecno.Checked)  
                {
                    product = new Product();
                    Label lblDate = (Label)row.FindControl("lblDate");
                    Label lblBranch = (Label)row.FindControl("lblBranch");
                    Label lblReqNo = (Label)row.FindControl("lblReqNo");
                    Label lblpassportNo = (Label)row.FindControl("lblpassportNo");
                    Label lblfirstname = (Label)row.FindControl("lblfirstname");
                    Label lblmiddleName = (Label)row.FindControl("lblmiddleName");
                    Label lbllastName = (Label)row.FindControl("lbllastName");

                    Label lblCompany = (Label)row.FindControl("lblCompany");
                    Label lblNationality = (Label)row.FindControl("lblNationality");
                    Label lblFormNO = (Label)row.FindControl("lblFormNO");
                    Label lblTellerNO = (Label)row.FindControl("lblTellerNO");
                    Label lblAmount = (Label)row.FindControl("lblAmount");
                    Label lblcerpacno = (Label)row.FindControl("lblcerpacno");
                    Label lblstrvisano = (Label)row.FindControl("lblstrvisano");



                    var culture = System.Globalization.CultureInfo.CurrentCulture;
                    //product.cerpacDate = DateTime.ParseExact(lblDate.Text.Replace('-', '/'), "dd/MM/yyyy", culture);
                    DateTime date = DateTime.ParseExact(lblDate.Text, "dd/mm/YYYY", CultureInfo.InvariantCulture);
                    //DateTime date = DateTime.Parse(DateTime.Now).ToString("MM/dd/yyyy hh:mm tt");
                    //product.cerpacDate = date.ToString();


                    product.cerpacDate = Convert.ToDateTime(lblDate.Text);

                    //FieldName = DtLicExp.ToString("MM/dd/yyyy")
                    product.Branch = lblBranch.Text;
                    product.RequisitionNo = int.Parse(lblReqNo.Text);
                    product.PassportNo = lblpassportNo.Text;
                    product.FirstName = lblfirstname.Text;
                    product.MiddleName = lblmiddleName.Text;
                    product.LastName = lbllastName.Text;
                    product.company = lblCompany.Text;
                    product.Nationality = lblNationality.Text;
                    product.formNo = lblFormNO.Text;
                    product.TellerNo = lblTellerNO.Text;
                    product.Amount = double.Parse(lblAmount.Text, NumberStyles.Currency);
                    product.CerpacNo = lblcerpacno.Text;
                    product.StrVisaNo = lblstrvisano.Text;
                    //product.ProductPrice = double.Parse(lblListPrice.Text, NumberStyles.Currency);
                    /// Get the product id of the selected product
                    productList.Add(gvProducts.DataKeys[row.RowIndex].Value.ToString(),
                                      product);
                }
            }
            if (productList.Count > 0)
                CopyProducts(productList);
            //BindData();
        }
        catch (Exception ex)
        {
            Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            ObjGenBal = new BaseLayer.General_function();
            string err = ObjGenBal.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.CssClass = "warning-box";
        }
        finally
        {
            ObjGenBal = null;

        }
    }
    private void CopyProducts(Hashtable htProducts)
    {
        try
        {
            //fetch the connection string from web.config
            string connString =
                ConfigurationManager.ConnectionStrings["NigeriaConnectionString"].ConnectionString;

            //SQL statement to insert into products
            //string sql = @"Insert into temp_bank_data values('{0}','{1}',{2},'{3}','{4}','{5}','{6}','{7}','{8}','{9}',{10},getdate(),{11},{12},getdate(),{13},getdate())";
            //// string sql = @"Insert into temp_bank_data values('{date1}','{branch}',{RequisitionNO},'{PassportNo}','{FirstName}','{MiddleName}','{LastName}','{Company}','{Nationality}','{Formno}',{TellerNo},{Amount},{CerpacNo},{StrVisaNo},{CreatedBY},getdate(),{ModifiedBy},getdate())";

            string sql = @"Insert into temp_bank_data values('{0}','{1}',{2},'{3}','{4}','{5}','{6}','{7}','{8}','{9}',{10},'{11}','{12}','{13}',getdate(),'{14}',getdate(),'{15}')";

            string formattedSQL;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                //Initialize command object
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    foreach (Product product in htProducts.Values)
                    {
                        formattedSQL = string.Format(sql, product.cerpacDate.ToString("yyyy-MM-dd",
        System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat), product.Branch, product.RequisitionNo, product.PassportNo, product.FirstName, product.LastName, product.company, product.Nationality, product.formNo, product.TellerNo, product.Amount, product.CerpacNo, product.StrVisaNo, 1, 1, product.MiddleName);
                        cmd.CommandText = formattedSQL;


                        cmd.ExecuteNonQuery();
                    }
                }
            }
            lblMessage.Text = "Following products were copied";
            foreach (string key in htProducts.Keys)
            {
                lblMessage.Text += String.Format("<br/> ProductID: {0}; ProductName:{1}", key, ((Product)htProducts[key]).LastName);
            }

            //BindData();
        }
        catch (Exception ex)
        {
            Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            ObjGenBal = new BaseLayer.General_function();
            string err = ObjGenBal.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.CssClass = "warning-box";
        }
        finally
        {
            ObjGenBal = null;

        }
    }


    public void CopyInTempTable()
    {
        try
        {
            // gvProducts.AllowPaging = false;
            //gvProducts.DataBind();

            ObjGeneral = new BaseLayer.General_function();

            string queryforposition = "select * from temp_bank_data";
            // string queryforposition = "SELECT * from vwDisplayVerifiedData";

            DataTable dt1 = new DataTable();
            dt1 = ObjGeneral.FetchData(queryforposition);

            if (dt1.Rows.Count > 0)
            {
                btnClean.Visible = true;
                confirm.Style.Add("display", "none");
                warn.Style.Add("display", "");
                warn.InnerText = "First Upload Previous Data Or Clean Previous Data";
                return;
            }

            BusinessEntityLayer.BankRegDetails objDetails = new BusinessEntityLayer.BankRegDetails();
            int res = 0;

            foreach (GridViewRow row in gvProducts.Rows)
            {
                {

                    Label lblDate = (Label)row.FindControl("lblDate");
                    Label lblBranch = (Label)row.FindControl("lblBranch");
                    Label lblReqNo = (Label)row.FindControl("lblReqNo");
                    Label lblpassportNo = (Label)row.FindControl("lblpassportNo");
                    Label lblfirstname = (Label)row.FindControl("lblfirstname");
                    Label lblmiddleName = (Label)row.FindControl("lblmiddleName");
                    Label lbllastName = (Label)row.FindControl("lbllastName");

                    Label lblCompany = (Label)row.FindControl("lblCompany");
                    Label lblNationality = (Label)row.FindControl("lblNationality");
                    Label lblFormNO = (Label)row.FindControl("lblFormNO");
                    Label lblTellerNO = (Label)row.FindControl("lblTellerNO");
                    Label lblAmount = (Label)row.FindControl("lblAmount");
                    Label lblcerpacno = (Label)row.FindControl("lblcerpacno");
                    Label lblstrvisano = (Label)row.FindControl("lblstrvisano");

                   // DateTime dat = Convert.ToDateTime(lblDate.Text);

                    var culture = System.Globalization.CultureInfo.CurrentCulture;
                    
                  

                    //---------------------
                        string sysFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                        string[] formats = { "M/d/yyyy", "M/dd/yyyy", "MM/dd/yyyy", "M/d/yy", "M/dd/yy", "MM/dd/yy",
                                              "M-d-yyyy", "M-dd-yyyy", "MM-dd-yyyy", "M-d-yy", "M-dd-yy", "MM-dd-yy",
                                             "d/M/yyyy", "dd/M/yyyy", "dd/MM/yyyy", "d/M/yy", "dd/M/yy", "dd/MM/yy",
                                             "d-M-yyyy", "dd-M-yyyy", "dd-MM-yyyy", "d-M-yy", "dd-M-yy", "dd-MM-yy",
                                             "d-MMM-yy", "dd-MMM-yy", "d-MMMM-yyyy","dd-MMMM-yyyy", };                   
                        DateTime date;
                        if (DateTime.TryParseExact(lblDate.Text, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                            objDetails.BankDate = date.ToString(sysFormat);
                        else
                        {
                            Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
                            ObjGenBal = new BaseLayer.General_function();
                            LabelMessage.Text = "Please convernt date format in to system date format.";
                            LabelMessage.CssClass = "warning-box";
                            LabelMessage.Visible = true;
                            excp = 1;
                        }

                

                    //FieldName = DtLicExp.ToString("MM/dd/yyyy")
                    objDetails.Branch = lblBranch.Text;
                    objDetails.ReqNo = (lblReqNo.Text);
                    objDetails.PassportNo = lblpassportNo.Text;
                    objDetails.FirstName = lblfirstname.Text;
                    objDetails.MiddleName = lblmiddleName.Text;
                    objDetails.LastName = lbllastName.Text;
                    objDetails.Company = lblCompany.Text;
                    objDetails.Nationality = lblNationality.Text;
                    objDetails.FormNo = lblFormNO.Text;
                    objDetails.TellerNo = lblTellerNO.Text;
                  
                    objDetails.Amount = Convert.ToDecimal(lblAmount.Text.Replace(",",""));
                    
                    objDetails.CerpacNo = lblcerpacno.Text;
                    objDetails.StrVisaNo = lblstrvisano.Text;
                    objDetails.CreatedBy = Convert.ToInt32(objectSessionHolderPersistingData.User_ID);

                    objDetails.Condition = 1;

                    res = objDetails.BankDetailsUpload();
                    // Thread.Sleep(5000);
                    // Bindlist();


                }

                if (res == 1)
                {
                    btnCopy.Visible = false;
                    // gvProducts.Visible = false;

                    // main.Style.Add("display", "none");
                }
            }
            //  Response.Write("Data Uploaded Successfully");

            //  main.Style.Add("display", "none");
            gvProducts.Visible = false;
            btnClean.Visible = false;

            lbl_excel_file.Visible = false;
            fileuploadExcel.Visible = false;
            btnImport.Visible = false;

            upload_div.Style.Add("display", "none");
            warn.Style.Add("display", "none");
            confirm.Style.Add("display", "");
            confirm.InnerText = "Data Uploaded Successfully";
        }
        catch (Exception ex)
        {
            Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            ObjGenBal = new BaseLayer.General_function();
            string err = ObjGenBal.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.CssClass = "warning-box";
        }
        finally
        {
            ObjGenBal = null;

        }
    }

    protected void CheckAll(object sender, EventArgs e)
    {
        foreach (GridViewRow row in gvProducts.Rows)
        {
            // Get the checkbox control that contain the user selection.
            CheckBox cbSelCerpacrec = (CheckBox)row.FindControl("cbSelCerpacrec");
            //if (cbSelProducts != null)
            cbSelCerpacrec.Checked = true;
        }
    }

    protected void UnCheckAll(object sender, EventArgs e)
    {
        foreach (GridViewRow row in gvProducts.Rows)
        {
            // Get the checkbox control that contain the user selection.
            CheckBox cbSelCerpacrec = (CheckBox)row.FindControl("cbSelCerpacrec");
            if (cbSelCerpacrec != null)
                cbSelCerpacrec.Checked = false;
        }

    }

    protected void cbSelCerpacrec_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i < gvProducts.Rows.Count; i++)
        {
            CheckBox chk = (CheckBox)gvProducts.Rows[i].Cells[0].FindControl("cbSelCerpacrec");
            // CheckBox chk1 = (CheckBox)gvDetails.Rows[i].Cells[0].FindControl("chkSelectAll");
            CheckBox chk1 = (CheckBox)gvProducts.HeaderRow.Cells[0].FindControl("cbHeaderSelect");
            if (chk.Checked || chk1.Checked)
            {


                btnCopy.Enabled = true;
                return;

            }
            else
            {
                btnCopy.Enabled = true;
            }

        }

    }
    protected void btnClean_Click(object sender, EventArgs e)
    {
        //int res;
        //BusinessEntityLayer.BankRegDetails objDetails = new BusinessEntityLayer.BankRegDetails();
        //res = objDetails.CleanTemp();

        //confirm.InnerText = "Previously Uploaded Data Successfully Cleaned.";
        //warn.Style.Add("display", "none");
        //confirm.Style.Add("display", "");
        //gvProducts.Visible = false;
        Response.Redirect("UploadBankData.aspx");
        ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Uploaded Data Canceled Successfully.');", true);
       // Response.Write("<script>alert('Data uploaded cancled successfully.');</script>");
       

      
        upload_div.Visible = false;
        btnClean.Visible = false;
        lbl_excel_file.Visible = true;
        btnImport.Visible = true;
        fileuploadExcel.Visible = true;
        btnCopy.Visible = false;
    }
}