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
using System.Text.RegularExpressions;
using System.Drawing;



public partial class Admin_frmImportBankData : System.Web.UI.Page
{
#region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    BaseLayer.General_function objgenenral = null;
    protected DataSet objDs = new DataSet();
    protected DataTable dt = new DataTable();
    protected DataTable dtform = new DataTable();

    DataTable dtNewB = new DataTable();
    DataTable dtC = new DataTable();
    DataTable dtReNewalB = new DataTable();
    DataTable dtReNewalP = new DataTable();
    DataTable dtBothB = new DataTable();
    DataTable dtBothP = new DataTable();
      

    protected BaseLayer.General_function ObjGenBal = null;
    Label LabelMessage = null;
    string UserID = null, ZoneDetails = null;
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

                divfun();
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

public void NewCase()
{
    try
    {
        

        SqlConnection Connection = new SqlConnection();
        Connection.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        string queryforposition = "select Convert(varchar(10),Date1,103) as Date1, FirstName, MiddleName, LastName, Company, Nationality, FormNo,  PassportNo, isnull(StrVisaNo,'') as StrVisaNo,tellerno,Amount from uploaded_excel_data where formno in ('" + txtFormNo.Text.Trim().Replace(",", "','") + "') and isnull(CerpacNo, '')=''";
        SqlCommand Command = new SqlCommand(queryforposition, Connection);

        string queryCount = "select Date1, FirstName, MiddleName, LastName, Company, Nationality, FormNo,  PassportNo, isnull(StrVisaNo,'') as StrVisaNo,tellerno from uploaded_excel_data where formno in ('" + txtFormNo.Text.Trim().Replace(",", "','") + "')";
        SqlCommand CommandC = new SqlCommand(queryCount, Connection);
       


        Connection.Open();

        Command.ExecuteNonQuery();
        CommandC.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(Command);
        SqlDataAdapter daC = new SqlDataAdapter(CommandC);
        da.Fill(dtNewB);
        daC.Fill(dtC);

        Connection.Close();

        String source = txtFormNo.Text.Trim();
        int count = 0;
        
        int AO = Regex.Matches(source, "AO").Count;
        int AR = Regex.Matches(source, "AR").Count;
        int CR = Regex.Matches(source, "CR").Count;
        int NG = Regex.Matches(source, "NG").Count;
        
        //lblTotalRequest.Text = count.ToString();
        count = (AO + AR + CR + NG);
        lblTotalRequest.Text = count.ToString();

        lblFoundinDatabae.Text = dtC.Rows.Count.ToString();
        lblFreeForm.Text = dtNewB.Rows.Count.ToString();
        lblAlreadyUsedForm.Text = Convert.ToString(dtC.Rows.Count - dtNewB.Rows.Count);

        if (dtNewB.Rows.Count > 0)
        {
            grd_Bankdata.DataSource = dtNewB;
            grd_Bankdata.DataBind();
            divSearchResult.Visible = true;
            divgrd.Visible = true;
            divImportBtn.Visible = true;
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('All Form no. Already Used.'); window.location = '" + Page.ResolveUrl("frmImportBankData.aspx") + "';", true);

        }

    }
     catch (Exception ex)
    {
        //this.ClientScript.RegisterClientScriptBlock(this.GetType(), "Onclick", "<script>window.open('frmGenrateBankFormRequest.aspx?Cond={0}&FormNo1={1}, Server.UrlEncode("+1+"), Server.UrlEncode("+ txtFormNo.Text.Trim() +") ');</script>");

        //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Due to internet connection problem system automatically transfer to offline mode.'); window.location = '" + Page.ResolveUrl("frmGenrateBankFormRequest.aspx?Cond={0}&FormNo1={1}, Server.UrlEncode('" + 1 + "'), Server.UrlEncode('" + txtFormNo.Text.Trim() + "') ") + "';", true);

        Response.Redirect(String.Format("frmGenrateBankFormRequest.aspx"));
        ObjGenBal = new BaseLayer.General_function();
        string err = ObjGenBal.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
        LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
        LabelMessage.CssClass = "warning-box";
        LabelMessage.Visible = true;

    }
    finally
    {
        dtNewB = null;
        dtC = null;
        ObjGenBal = null;
    }
}
public void RenewalCase()
{
    try
    {
       
        //-----------------Uploaded Excel Data --------------Central Server --------------
            //dtReNewalB = null;

            SqlConnection ConnectionB = new SqlConnection();
            ConnectionB.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            string queryforposition = "select Convert(varchar(10),Date1,103) as Date1, FirstName, MiddleName, LastName, Company, Nationality, FormNo,  PassportNo, isnull(StrVisaNo,'') as StrVisaNo,tellerno,Amount from uploaded_excel_data where formno in ('" + txtFormNo1.Text.Trim().Replace(",", "','") + "') and isnull(CerpacNo, '')=''";
            SqlCommand CommandB = new SqlCommand(queryforposition, ConnectionB);

            string queryCount = "select Date1, FirstName, MiddleName, LastName, Company, Nationality, FormNo,  PassportNo, isnull(StrVisaNo,'') as StrVisaNo,tellerno from uploaded_excel_data where formno in ('" + txtFormNo1.Text.Trim().Replace(",", "','") + "')";
            SqlCommand CommandC = new SqlCommand(queryCount, ConnectionB);
       
            ConnectionB.Open();

            CommandB.ExecuteNonQuery();
            CommandC.ExecuteNonQuery();
            SqlDataAdapter daB = new SqlDataAdapter(CommandB);
            SqlDataAdapter daC = new SqlDataAdapter(CommandC);
            daB.Fill(dtReNewalB);
            daC.Fill(dtC);

            ConnectionB.Close();

            String source = txtFormNo1.Text.Trim();
            int count = 0;

            int AO = Regex.Matches(source, "AO").Count;
            int AR = Regex.Matches(source, "AR").Count;
            int CR = Regex.Matches(source, "CR").Count;
            int NG = Regex.Matches(source, "NG").Count;




            //lblTotalRequest.Text = count.ToString();
            count = (AO + AR + CR + NG);
            lblTotalRequest.Text = count.ToString();

            lblFoundinDatabae.Text = dtC.Rows.Count.ToString();
            lblFreeForm.Text = dtReNewalB.Rows.Count.ToString();
            lblAlreadyUsedForm.Text = Convert.ToString(dtC.Rows.Count - dtReNewalB.Rows.Count);


            if (dtReNewalB.Rows.Count > 0)
            {
                grd_Bankdata.DataSource = dtReNewalB;
                grd_Bankdata.DataBind();

                


                //---------------------People Table Data--------------Central Server ------------
                //dtReNewalP = null;

                SqlConnection ConnectionP = new SqlConnection();
                ConnectionP.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                string querypeople = "Select a.forename, a.middle_name,  a.surname, a.sex, a.cerpac_no, a.cerpac_file_no,  Convert(varchar(10),a.cerpac_receipt_date,103) as cerpac_receipt_date, Convert(varchar(10),a.cerpac_expiry_date,103) as cerpac_expiry_date,  a.passport_no, a.nationality, b.company,a.designation  from people a, compmaster b where a.company=b.regno and  a.cerpac_no in ('" + txtCerpacno.Text.Trim().Replace(",", "','").Trim() + "') order by a.forename";
                //string querypeople = "select Date1, FirstName, MiddleName, LastName, Company, Nationality, FormNo,  PassportNo, isnull(StrVisaNo,'') as StrVisaNo,tellerno from uploaded_excel_data where formno in ('" + txtFormNo.Text.Replace(",", "','") + "') and isnull(CerpacNo, '')=''";
                SqlCommand CommandP = new SqlCommand(querypeople, ConnectionP);

                ConnectionP.Open();
                CommandP.ExecuteNonQuery();
                SqlDataAdapter daP = new SqlDataAdapter(CommandP);
                daP.Fill(dtReNewalP);
                ConnectionP.Close();

                if (dtReNewalP.Rows.Count > 0)
                {
                    grd_CerpacNo.DataSource = dtReNewalP;
                    grd_CerpacNo.DataBind();
                   
                    divSearchResult.Visible = true;
                    divgrd.Visible = true;
                    divSearchCerpac.Visible = true;
                    divgrdCerpac.Visible = true;
                    divImportBtn.Visible = true;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Form no. Already Used.'); window.location = '" + Page.ResolveUrl("frmImportBankData.aspx") + "';", true);

            }
        
    }
   catch (Exception ex)
    {
        Response.Redirect(String.Format("frmGenrateBankFormRequest.aspx"));
        ObjGenBal = new BaseLayer.General_function();
        string err = ObjGenBal.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
        LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
        LabelMessage.CssClass = "warning-box";
        LabelMessage.Visible = true;

    }
    finally
    {
        dtReNewalB = null;
        dtReNewalP = null;
        dtC = null;
        ObjGenBal = null;
    }
}
public void BothCase()
{
   try
    {
       
        //-----------------Uploaded Excel Data --------------Central Server --------------
            //dtBothB = null;

            SqlConnection ConnectionB = new SqlConnection();
            ConnectionB.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            string queryforposition = "select Convert(varchar(10),Date1,103) as Date1, FirstName, MiddleName, LastName, Company, Nationality, FormNo,  PassportNo, isnull(StrVisaNo,'') as StrVisaNo,tellerno,Amount from uploaded_excel_data where formno in ('" + txtFormNo.Text.Trim().Replace(",", "','") + "','" + txtFormNo1.Text.Trim().Replace(",", "','") + "') and isnull(CerpacNo, '')=''";
            SqlCommand Command = new SqlCommand(queryforposition, ConnectionB);

            string queryCount = "select Date1, FirstName, MiddleName, LastName, Company, Nationality, FormNo,  PassportNo, isnull(StrVisaNo,'') as StrVisaNo,tellerno from uploaded_excel_data where formno in ('" + txtFormNo.Text.Trim().Replace(",", "','") + "','" + txtFormNo1.Text.Trim().Replace(",", "','") + "')";
            SqlCommand CommandC = new SqlCommand(queryCount, ConnectionB);
       
            ConnectionB.Open();

            Command.ExecuteNonQuery();
            CommandC.ExecuteNonQuery();
            SqlDataAdapter daB = new SqlDataAdapter(Command);
            SqlDataAdapter daC = new SqlDataAdapter(CommandC);
            daB.Fill(dtBothB);
            daC.Fill(dtC);
            ConnectionB.Close();

            String source = txtFormNo.Text + "," + txtFormNo1.Text;
            int count = 0;

            int AO = Regex.Matches(source, "AO").Count;
            int AR = Regex.Matches(source, "AR").Count;
            int CR = Regex.Matches(source, "CR").Count;
            int NG = Regex.Matches(source, "NG").Count;




            //lblTotalRequest.Text = count.ToString();
            count = (AO + AR + CR + NG);
            lblTotalRequest.Text = count.ToString();

            lblFoundinDatabae.Text = dtC.Rows.Count.ToString();
            lblFreeForm.Text = dtBothB.Rows.Count.ToString();
            lblAlreadyUsedForm.Text = Convert.ToString(dtC.Rows.Count - dtBothB.Rows.Count);


            if (dtBothB.Rows.Count > 0)
            {
                grd_Bankdata.DataSource = dtBothB;
                grd_Bankdata.DataBind();

                divSearchResult.Visible = true;
                divgrd.Visible = true;
                divImportBtn.Visible = true;

                //---------------------People Table Data--------------Central Server ------------
                //dtBothP = null;

                SqlConnection ConnectionP = new SqlConnection();
                ConnectionP.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                string querypeople = "Select a.forename, a.middle_name,  a.surname, a.sex, a.cerpac_no, a.cerpac_file_no,  Convert(varchar(10),a.cerpac_receipt_date,103) as cerpac_receipt_date, Convert(varchar(10),a.cerpac_expiry_date,103) as cerpac_expiry_date,  a.passport_no, a.nationality, b.company,a.designation  from people a, compmaster b where a.company=b.regno and  a.cerpac_no in ('" + txtCerpacno.Text.Trim().Replace(",", "','") + "') order by a.forename";
                //string querypeople = "select Date1, FirstName, MiddleName, LastName, Company, Nationality, FormNo,  PassportNo, isnull(StrVisaNo,'') as StrVisaNo,tellerno from uploaded_excel_data where formno in ('" + txtFormNo.Text.Replace(",", "','") + "') and isnull(CerpacNo, '')=''";
                SqlCommand CommandP = new SqlCommand(querypeople, ConnectionP);

                ConnectionP.Open();
                CommandP.ExecuteNonQuery();
                SqlDataAdapter daP = new SqlDataAdapter(CommandP);
                daP.Fill(dtBothP);
                ConnectionP.Close();

                if (dtBothP.Rows.Count > 0)
                {
                    grd_CerpacNo.DataSource = dtBothP;
                    grd_CerpacNo.DataBind();
                   

                   
                    divSearchCerpac.Visible = true;
                    divgrdCerpac.Visible = true;
                    divImportBtn.Visible = true;

                    
                }

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Form no. Already Used.'); window.location = '" + Page.ResolveUrl("frmImportBankData.aspx") + "';", true);

            }
        
    }

    catch (Exception ex)
    {
        Response.Redirect(String.Format("frmGenrateBankFormRequest.aspx"));
        ObjGenBal = new BaseLayer.General_function();
        string err = ObjGenBal.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
        LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
        LabelMessage.CssClass = "warning-box";
        LabelMessage.Visible = true;

    }
    finally
    {
        dtBothB = null;
        dtBothP = null;
        dtC = null;
        ObjGenBal = null;
    }

}


protected void btnSearch_Click(object sender, EventArgs e)
{
    Session["FormNo"] = txtFormNo.Text;
    Session["FormNo1"] = txtFormNo1.Text;
    Session["CerpacNo"] = txtCerpacno.Text;

    if (txtFormNo.Text != "" && txtFormNo1.Text == "" && txtCerpacno.Text == "")
    {
        //NewCase();
        BothCase();
    }
    else if (txtFormNo.Text == "" && txtFormNo1.Text != "" && txtCerpacno.Text != "")
    {
       // RenewalCase();
        BothCase();
    }
    else if (txtFormNo.Text != "" && txtFormNo1.Text != "" && txtCerpacno.Text != "")
    {
        BothCase();
    }
    else
    {
        divfun();
    }
    

  
}

public void divfun()
{
    divSearchResult.Visible = false;
    divgrd.Visible = false;
    divSearchCerpac.Visible = false;
    divgrdCerpac.Visible = false;
    divImportBtn.Visible = false;

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

public void SaveBankDetails()
{
    String found = "";

    SqlConnection Connection = new SqlConnection();
    Connection.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

    SqlConnection ConnectionZone = new SqlConnection();
    ConnectionZone.ConnectionString = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;


    //------------------Bank Detials Grid----------------------------------------------------------------------------------
    for (int i = 0; i <= grd_Bankdata.Rows.Count - 1; i++)
    {
        
        //-------------------Update on Central Uploaded_Excel_data table-------------------------
        SqlCommand Command = new SqlCommand("update uploaded_excel_data set cerpacno='" + ZoneDetails.ToString() + "' where formno in ('" + grd_Bankdata.Rows[i].Cells[6].Text.Trim() + "')", Connection);
        Connection.Open();
        Command.ExecuteNonQuery();
        Connection.Close();

      
        //-----------Convert date formate ()-------------
        var culture = System.Globalization.CultureInfo.CurrentCulture;

        string sysFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
        string[] formats = { "M/d/yyyy", "M/dd/yyyy", "MM/dd/yyyy", "M/d/yy", "M/dd/yy", "MM/dd/yy",
                                              "M-d-yyyy", "M-dd-yyyy", "MM-dd-yyyy", "M-d-yy", "M-dd-yy", "MM-dd-yy",
                                             "d/M/yyyy", "dd/M/yyyy", "dd/MM/yyyy", "d/M/yy", "dd/M/yy", "dd/MM/yy",
                                             "d-M-yyyy", "dd-M-yyyy", "dd-MM-yyyy", "d-M-yy", "dd-M-yy", "dd-MM-yy",
                                             "d-MMM-yy", "dd-MMM-yy", "d-MMMM-yyyy","dd-MMMM-yyyy", };
        DateTime date;
        if (DateTime.TryParseExact(grd_Bankdata.Rows[i].Cells[0].Text, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            date.ToString(sysFormat);

        //------------------Select form in Bank Database Zone DataBase-------------------------------------

        objgenenral = new BaseLayer.General_function();
        string QuerCountFound = "select count(*) from uploaded_excel_data where formno in ('" + grd_Bankdata.Rows[i].Cells[6].Text.Trim() + "')";

        DataTable dt = new DataTable();
        dt = objgenenral.FetchData(QuerCountFound);

        //------------------Insert Bank Form in Zone Database--------------------------------------

        if (dt.Rows[0].ItemArray[0].ToString() == "0")
        {
            SqlCommand CommandZone = new SqlCommand("INSERT INTO  Uploaded_Excel_Data(RecordNo, Date1, FirstName,	MiddleName , LastName, Company, Nationality, FormNo	, PassportNo, StrVisaNo, tellerno, CreatedBY, CreatedON,RequisitionNO,Amount) " +
                                                    " VALUES ( (select max(isnull(recordno,0)+1 from uploaded_excel_data),'" + (grd_Bankdata.Rows[i].Cells[0].Text) + "','" + grd_Bankdata.Rows[i].Cells[1].Text + "','" + grd_Bankdata.Rows[i].Cells[2].Text.Replace("&nbsp;", " ") + "','" + grd_Bankdata.Rows[i].Cells[3].Text + "','" + grd_Bankdata.Rows[i].Cells[4].Text + "','" + grd_Bankdata.Rows[i].Cells[5].Text + "','" + grd_Bankdata.Rows[i].Cells[6].Text + "','" + grd_Bankdata.Rows[i].Cells[7].Text + "','" + grd_Bankdata.Rows[i].Cells[8].Text + "','" + grd_Bankdata.Rows[i].Cells[9].Text + "','" + objectSessionHolderPersistingData.User_ID + "',GETDATE(),0,0)   ", ConnectionZone);
            ConnectionZone.Open();
            CommandZone.ExecuteNonQuery();
            ConnectionZone.Close();
        }
        else
        {

            found = found + grd_Bankdata.Rows[i].Cells[6].Text.Trim() + ",";

        }


    }
    if (found != "")
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Form no.: " + found + " already uploaded by central.'); window.location = '" + Page.ResolveUrl("frmImportBankData.aspx") + "';", true);

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
    for (int i = 0; i <= grd_Bankdata.Rows.Count - 1; i++)
    {

        DataTable dt = new DataTable();
       
        //-----------------Search in uploaded_excel_data_C table in Central--------------------
        
        string QuerCountFound = "select count(*) from uploaded_excel_data_C where  Formno='" + grd_Bankdata.Rows[i].Cells[6].Text.Trim() + "'";

        SqlCommand CommandCt = new SqlCommand(QuerCountFound, Connection);
               
        Connection.Open();
        SqlDataAdapter BankCt = new SqlDataAdapter(CommandCt);
        BankCt.Fill(dt);
        Connection.Close();        
        
      
        if (dt.Rows[0].ItemArray[0].ToString() == "0")

        {

            //--------------------------Insert in Bank tabel Central--------------------------------   

            SqlCommand Command = new SqlCommand("Insert into uploaded_excel_data_C (FormNo,bank_flag,bank_req_userid,bank_req_date,zone_name) Values( '" + grd_Bankdata.Rows[i].Cells[6].Text.Trim() + "','" + 1 + "','" + UserID.ToString().Trim() + "',getdate(), '" + ZoneDetails + "')", Connection);
            Connection.Open();
            Command.ExecuteNonQuery();
            Connection.Close();

        }
        else
        {
            AlreadyReq = AlreadyReq + grd_Bankdata.Rows[i].Cells[6].Text.Trim() + " ";
        }
       

        //-----------------Search in uploaded_excel_data_C table in Zone--------------------
        ObjGenBal = new BaseLayer.General_function();
        string QuerCountZone = "select count(*) from uploaded_excel_data_C where  Formno='" + grd_Bankdata.Rows[i].Cells[6].Text.Trim() + "'";
        DataTable dtz = new DataTable();
        dtz = ObjGenBal.FetchData(QuerCountZone);
        if (dtz.Rows[0].ItemArray[0].ToString() == "0")
        {

            //--------------------------Insert in uploaded_excel_data_C at Zone-------------------------------              
            SqlCommand CommandZone = new SqlCommand("Insert into uploaded_excel_data_C (FormNo,bank_flag,bank_req_userid,bank_req_date,zone_name) Values( '" + grd_Bankdata.Rows[i].Cells[6].Text.Trim() + "','"+ 1  + "','" + UserID.ToString().Trim() + "',getdate(), '" + ZoneDetails + "')", ConnectionZone);
            ConnectionZone.Open();
            CommandZone.ExecuteNonQuery();
            ConnectionZone.Close();

        }
        else
        {
            AlreadyReq = AlreadyReq + grd_Bankdata.Rows[i].Cells[6].Text.Trim() + " ";
        }



    }
    //-------------------After save successfully------------------------------
    if (AlreadyReq != "")
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Form no.: " + AlreadyReq + " already uploaded by central.'); window.location = '" + Page.ResolveUrl("frmImportBankData.aspx") + "';", true);

    }
}
public void SavePeopleDetails()
{
   
    
    SqlConnection Connection = new SqlConnection();
    Connection.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

    SqlConnection ConnectionZone = new SqlConnection();
    ConnectionZone.ConnectionString = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;

    DataTable dtPeople = new DataTable();
          
        for (int i = 0; i <= grd_CerpacNo.Rows.Count -1 ; i++)
        {
            //-----------------Search in People table-in Central-------------------

            SqlCommand CommandPeople = new SqlCommand("select [title],[forename],[middle_name],[surname],[sex],[residence_permit_no],[residence_issue_loc]" +
                                                    ",[deedmark_no],[printed],[label_print_count],[card_print_count],[picture],[directory],[notes]" +
                                                    ",[cerpac_no],[cerpac_file_no],[cerpac_receipt_date],[cerpac_expiry_date],[registration_area],[registration_code]" +
                                                    ",[file_no],[label_no],[book_no],[passport_no],[nationality],[passport_issue_date],[passport_expiry_date]" +
                                                    ",[passport_issue_loc],[passport_issue_by],[date_of_birth],[place_of_birth],[nigeria_add_1],[nigeria_add_2]" +
                                                    ",[nigeria_tel_no],[abroad_add_1],[abroad_add_2],[abroad_tel_no],[company],[company_add_1],[company_add_2]" +
                                                    ",[designation],[employment_date],[company_tel_no],[company_fax_no],[email],[date_added],[added_by_user_id]" +
                                                    ",[date_modified],[modified_by_user_id],[picture_taken],[picture_by_user_id],[verid_template],[verid_template_1]" +
                                                    ",[arcanet_2d_command],[date_system_modified],[ContactNo],[userImage] from people where cerpac_no='" + grd_CerpacNo.Rows[i].Cells[4].Text + "'", Connection);
            Connection.Open();
            SqlDataAdapter da = new SqlDataAdapter(CommandPeople);
            da.Fill(dtPeople);
            Connection.Close();

            //-----------------Search in People table-in Zone-------------------
            objgenenral = new BaseLayer.General_function();
            string QuerCountFound = "select count(*) from people where cerpac_no in ('" + grd_CerpacNo.Rows[i].Cells[4].Text.Trim() + "')";

            DataTable dt = new DataTable();
            dt = objgenenral.FetchData(QuerCountFound);
            if (dt.Rows[0].ItemArray[0].ToString() != "0")
            {
                //--------------------------Update------------------------------

                SqlCommand Command = new SqlCommand("update People set title='" + dtPeople.Rows[i].ItemArray[0].ToString() + "', forename ='" + dtPeople.Rows[i].ItemArray[1].ToString() + "', middle_name ='" + dtPeople.Rows[i].ItemArray[2].ToString() + "', surname ='" + dtPeople.Rows[i].ItemArray[3].ToString() + "', sex ='" + dtPeople.Rows[i].ItemArray[4].ToString() + "', cerpac_file_no ='" + dtPeople.Rows[i].ItemArray[15].ToString() + "', cerpac_expiry_date ='" + datep(dtPeople.Rows[i].ItemArray[17].ToString()) + "', cerpac_receipt_date ='" + datep(dtPeople.Rows[i].ItemArray[16].ToString()) + "', passport_no ='" + dtPeople.Rows[i].ItemArray[23].ToString() + "', nationality ='" + dtPeople.Rows[i].ItemArray[24].ToString() + "', company ='" + dtPeople.Rows[i].ItemArray[37].ToString() + "', designation= '" + dtPeople.Rows[i].ItemArray[40].ToString() + "' where cerpac_no = '" + grd_CerpacNo.Rows[i].Cells[4].Text.Trim() + "'", ConnectionZone);
                ConnectionZone.Open();
                Command.ExecuteNonQuery();
                ConnectionZone.Close();
               
            }
            else
            {
                //--------------------------Insert--------------------------------   


                SqlCommand Command = new SqlCommand("Insert into people ([title],[forename],[middle_name],[surname],[sex],[residence_permit_no],[residence_issue_loc]" +
                                                        ",[deedmark_no],[printed],[label_print_count],[card_print_count],[picture],[directory],[notes]" +
                                                        ",[cerpac_no],[cerpac_file_no],[cerpac_receipt_date],[cerpac_expiry_date],[registration_area],[registration_code]" +
                                                        ",[file_no],[label_no],[book_no],[passport_no],[nationality],[passport_issue_date],[passport_expiry_date]" +
                                                        ",[passport_issue_loc],[passport_issue_by],[date_of_birth],[place_of_birth],[nigeria_add_1],[nigeria_add_2]" +
                                                        ",[nigeria_tel_no],[abroad_add_1],[abroad_add_2],[abroad_tel_no],[company],[company_add_1],[company_add_2]" +
                                                        ",[designation],[employment_date],[company_tel_no],[company_fax_no],[email],[date_added],[added_by_user_id]" +
                                                        ",[date_modified],[modified_by_user_id],[picture_taken],[picture_by_user_id],[verid_template],[verid_template_1]" +
                                                        ",[arcanet_2d_command],[date_system_modified],[ContactNo])" +
                                                    "Values('" + dtPeople.Rows[i].ItemArray[0].ToString() + "','" + dtPeople.Rows[i].ItemArray[1].ToString() + "','" + dtPeople.Rows[i].ItemArray[2].ToString() + "','" + dtPeople.Rows[i].ItemArray[3].ToString() + "','" + dtPeople.Rows[i].ItemArray[4].ToString() + "','" + dtPeople.Rows[i].ItemArray[5].ToString() + "','" + dtPeople.Rows[i].ItemArray[6].ToString() + "','" + dtPeople.Rows[i].ItemArray[7].ToString() + "','" + dtPeople.Rows[i].ItemArray[8].ToString() +
                                                         "','" + dtPeople.Rows[i].ItemArray[9].ToString() + "','" + dtPeople.Rows[i].ItemArray[10].ToString() + "','" + dtPeople.Rows[i].ItemArray[11].ToString() + "','" + dtPeople.Rows[i].ItemArray[12].ToString() + "','" + dtPeople.Rows[i].ItemArray[13].ToString() + "','" + dtPeople.Rows[i].ItemArray[14].ToString() + "','" + dtPeople.Rows[i].ItemArray[15].ToString() + "','" + datep(dtPeople.Rows[i].ItemArray[16].ToString()) +
                                                         "','" + datep(dtPeople.Rows[i].ItemArray[17].ToString()) + "','" + dtPeople.Rows[i].ItemArray[18].ToString() + "','" + dtPeople.Rows[i].ItemArray[19].ToString() + "','" + dtPeople.Rows[i].ItemArray[20].ToString() + "','" + dtPeople.Rows[i].ItemArray[21].ToString() + "','" + dtPeople.Rows[i].ItemArray[22].ToString() +
                                                         "','" + dtPeople.Rows[i].ItemArray[23].ToString() + "','" + dtPeople.Rows[i].ItemArray[24].ToString() + "','" + datep(dtPeople.Rows[i].ItemArray[25].ToString()) + "','" + datep(dtPeople.Rows[i].ItemArray[26].ToString()) + "','" + dtPeople.Rows[i].ItemArray[27].ToString() + "','" + dtPeople.Rows[i].ItemArray[28].ToString() + "','" + datep(dtPeople.Rows[i].ItemArray[29].ToString()) +
                                                         "','" + dtPeople.Rows[i].ItemArray[30].ToString() + "','" + dtPeople.Rows[i].ItemArray[31].ToString() + "','" + dtPeople.Rows[i].ItemArray[32].ToString() + "','" + dtPeople.Rows[i].ItemArray[33].ToString() + "','" + dtPeople.Rows[i].ItemArray[34].ToString() + "','" + dtPeople.Rows[i].ItemArray[35].ToString() +
                                                         "','" + dtPeople.Rows[i].ItemArray[36].ToString() + "','" + dtPeople.Rows[i].ItemArray[37].ToString() + "','" + dtPeople.Rows[i].ItemArray[38].ToString() + "','" + dtPeople.Rows[i].ItemArray[39].ToString() + "','" + dtPeople.Rows[i].ItemArray[40].ToString() + "','" + datep(dtPeople.Rows[i].ItemArray[41].ToString()) + "','" + dtPeople.Rows[i].ItemArray[42].ToString() +
                                                         "','" + dtPeople.Rows[i].ItemArray[43].ToString() + "','" + dtPeople.Rows[i].ItemArray[44].ToString() + "','" + datep(dtPeople.Rows[i].ItemArray[45].ToString()) + "','" + dtPeople.Rows[i].ItemArray[46].ToString() + "','" + datep(dtPeople.Rows[i].ItemArray[47].ToString()) + "','" + dtPeople.Rows[i].ItemArray[48].ToString() + "','" + dtPeople.Rows[i].ItemArray[49].ToString() +
                                                         "','" + dtPeople.Rows[i].ItemArray[50].ToString() + "','" + dtPeople.Rows[i].ItemArray[51].ToString() + "','" + dtPeople.Rows[i].ItemArray[52].ToString() + "','" + dtPeople.Rows[i].ItemArray[53].ToString() + "','" + datep(dtPeople.Rows[i].ItemArray[54].ToString()) + "','" + dtPeople.Rows[i].ItemArray[55].ToString() +
                                                         "')", ConnectionZone);

                ConnectionZone.Open();
                Command.ExecuteNonQuery();
                ConnectionZone.Close();
            }

            //-------------------Import image in people table in Zone-----------------------------


            SqlCommand Command1 = new SqlCommand("update people set userImage=@ImageFile where cerpac_no in ('" + grd_CerpacNo.Rows[i].Cells[4].Text.Trim() + "')", ConnectionZone);

            SqlParameter imageFileParameter = new SqlParameter("@ImageFile", SqlDbType.Image);
            imageFileParameter.Value = dtPeople.Rows[i]["userImage"];
            Command1.Parameters.Add(imageFileParameter);

            ConnectionZone.Open();
            Command1.ExecuteNonQuery();
            ConnectionZone.Close();
            //------------------------------------------------

        }
    }



protected void btnImport_Click(object sender, EventArgs e)
{
    try
    {
    SaveBankDetails();
    if (grd_Bankdata.Rows.Count > 0)
    {
        SavePeopleDetails();
        
         
    }
    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Successfully Imported records in " + ZoneDetails.ToString() + " Zone Server.'); window.location = '" + Page.ResolveUrl("frmImportBankData.aspx") + "';", true);
    
    }
    catch (Exception ex)
    {
       // Response.Redirect(String.Format("frmGenrateBankFormRequest.aspx"));
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
protected void grd_CerpacNo_SelectedIndexChanged(object sender, EventArgs e)
{

}
}