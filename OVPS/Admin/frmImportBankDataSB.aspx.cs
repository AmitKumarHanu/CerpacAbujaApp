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
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class Admin_frmImportBankDataSB : System.Web.UI.Page
{
    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    BaseLayer.General_function objgenenral = null;
    protected DataSet objDs = new DataSet();
    protected DataTable dt = new DataTable();

    protected BaseLayer.General_function ObjGenBal = null;
    string AppID = "";
    string UserID = null;
    Label LabelMessage = null;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        if (objectSessionHolderPersistingData == null)
        {
            Response.Redirect("../Login.aspx");
        }

        //-----------------------------------------for disabling the hyperlink ------------------------------
        TreeView tvr = (TreeView)this.Page.Master.FindControl("TVLeftMenu");
        // tvr.Visible = false;
        HyperLink hyp = (HyperLink)this.Page.Master.FindControl("hypHome");
        //  tvr.Attributes.Add("onclick", "if(!confirm('Are you sure you want to go to home page')) return false;");
        //-----------------------------------------------end ---------------------------------------------------


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
        string queryforCount = "select Date1, FirstName, MiddleName, LastName, Company, Nationality, RequisitionNo, FormNo, CerpacNo, PassportNo, isnull(StrVisaNo,'') as StrVisaNo,tellerno,amount from uploaded_excel_data where formno in ('" + TextAppId.Text.Replace(",", "','") + "')";

        string queryforCerpacNo = "select * from people where cerpac_no in ('" + txt_cerpac_no.Text.Replace(",", "','") + "')";


        SqlCommand Command = new SqlCommand(queryforposition, Connection);
        SqlCommand CommandCnt = new SqlCommand(queryforCount, Connection);

        SqlCommand Command_cerpac = new SqlCommand(queryforCerpacNo, Connection);
        
        Connection.Open();
        
        Command.ExecuteNonQuery();
        CommandCnt.ExecuteNonQuery();
        Command_cerpac.ExecuteNonQuery();

        DataTable dt1 = new DataTable();
        DataTable dt_cnt = new DataTable();

        DataTable dt_cerpac = new DataTable();
       // dt1 = null;
        SqlDataAdapter da = new SqlDataAdapter(Command);
        SqlDataAdapter da_cnt = new SqlDataAdapter(CommandCnt);

        SqlDataAdapter da_cerpac = new SqlDataAdapter(Command_cerpac);
        

        da.Fill(dt1);
        da_cnt.Fill(dt_cnt);

        da_cerpac.Fill(dt_cerpac);

        Connection.Close();
        da.Dispose();
        da_cnt.Dispose();
        divSearchResult.Style.Add("display", "");
       
      //  dt1 = objgenenral.FetchData(queryforposition);
        lblFoundinDatabae.Text = dt_cnt.Rows.Count.ToString();
        lblTotalRequest.Text = TextAppId.Text.Split(',').Length.ToString();
        lblFreeForm.Text = dt1.Rows.Count.ToString();
        lblAlreadyUsedForm.Text = Convert.ToString(dt_cnt.Rows.Count - dt1.Rows.Count);


        if (dt1.Rows.Count > 0 || dt_cerpac.Rows.Count>0)
        {
            if (dt1.Rows.Count > 0)
            {
                lblTotalRequest.Text = TextAppId.Text.Split(',').Length.ToString();
                lblFoundinDatabae.Text = dt1.Rows.Count.ToString();


                grd_display_data.DataSource = dt1;
                grd_display_data.DataBind();

                tr45.Style.Add("display", "");

                // divSearchResult.Style.Add("display", "");
                div_grd.Style.Add("display", "");
            }

            if (dt_cerpac.Rows.Count > 0)
            {
                grd_cerpac.DataSource = dt_cerpac;
                grd_cerpac.DataBind();

                tr45.Style.Add("display", "");

                // divSearchResult.Style.Add("display", "");
                div_cerpac.Style.Add("display", "");
            }
        }


        else
        {

            grd_display_data.DataSource = dt1;
            grd_display_data.DataBind();
            tr45.Style.Add("display", "none");
          //  divSearchResult.Style.Add("display", "none");
            div_grd.Style.Add("display", "");
        }


    }

    protected void Go_Click(object sender, EventArgs e)
    {
        objgenenral = new BaseLayer.General_function();
        //string quer = "select a.*,b.* from People as a , PeopleChild as b where a.cerpac_no = b.CerpacNo and a.cerpac_no='" + TextAppId.Text.ToString() + "'";

       // string quer = "select * from vw_prod_consolidated_data a, UserZoneRelation b where (IsAuthorized=1) and (isarcr=1) and (IsProduced=0 or IsProduced is null or IsProduced=2 or IsProduced=3) and a.verifiedby = b.userid  and b.ZoneCode=(select ZoneCode from UserZoneRelation where USERID=" + objectSessionHolderPersistingData.User_ID + ") and cerpacno='" + TextAppId.Text.ToString() + "'";
        string quer="select Date1,FirstName, MiddleName, LastName, Company, Nationality, RequisitionNo, FormNo, CerpacNo, PassportNo, isnull(StrVisaNo,'') as StrVisaNo,tellerno,amount from uploaded_excel_data where formno in ('"+TextAppId.Text.Replace(",","','")+"') and isnull(CerpacNo, '')<>''";

        try
        {
            Session["forms"] = TextAppId.Text;
            //////// string querforuser = "Select a.ZoneName,b.ZoneCode from ZoneMaster as a, UserZoneRelation as b where a.ZoneCode = b.ZoneCode and b.UserId=" + objectSessionHolderPersistingData.User_ID.ToString() + "";
            ////// string queryfornewcase = "Select * from Issue where cerpac_no='" + TextAppId.Text.ToString() + "'";
            DataTable dt = new DataTable();
            dt = objgenenral.FetchData(quer);
            //////// DataTable dtuser = new DataTable();
            //////// dtuser = objgenenral.FetchData(querforuser);
            ////// DataTable dtnew = new DataTable();
            ////// dtnew = objgenenral.FetchData(queryfornewcase);
            ////// if (dt.Rows.Count > 0 && dt.Rows[0]["IsVerified"].ToString().Trim() == "0")
            ////// {
            Bindlist();

            ////// }
            ////// else if (dt.Rows.Count > 0 && dt.Rows[0]["IsVerified"].ToString() == "1")
            ////// {
            //////     lblmsg.Text = "This Cerpac Number Has already been verified";
            //////     lblmsg.CssClass = "warning-box";
            ////// }
            ////// else
            ////// {
            //////     lblmsg.Text = "This Cerpac Number does not exists.Please check the number and try again";
            //////     lblmsg.CssClass = "error-box";

            ////// }

           // GetData(TextAppId.Text);
        }
        catch (Exception ex)
        {
            Response.Redirect("frmGenrateBankFormRequest.aspx");
            //objgenenral = new BaseLayer.General_function();
            //string err = objgenenral.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            //lblmsg.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            //lblmsg.CssClass = "warning-box";
        }
        finally
        {
            dt = null;
            objgenenral = null;
        }
    }

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
           // e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            //  e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
           // e.Row.ToolTip = "Click to select row";
          //  e.Row.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.grd_display_data, "Select$" + e.Row.RowIndex);
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
        Response.Redirect("frmImportBankData.aspx");
    }
    protected void btn_import_Click(object sender, EventArgs e)
    {
      try
        {
            foreach (GridViewRow gv in grd_display_data.Rows)
            {
                SqlConnection Connection = new SqlConnection();
                Connection.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;


                SqlConnection ConnectionZone = new SqlConnection();
                ConnectionZone.ConnectionString = ConfigurationManager.ConnectionStrings["NigeriaConnectionString"].ConnectionString;

                SqlCommand Command_ch = new SqlCommand("select * from uploaded_excel_data where formno='" + gv.Cells[8].Text + "'", ConnectionZone);
                ConnectionZone.Open();
                DataTable dt_ch = new DataTable();

                SqlDataAdapter da_Ch = new SqlDataAdapter(Command_ch);

                da_Ch.Fill(dt_ch);
                ConnectionZone.Close();

                if (dt_ch.Rows.Count == 0)
                {
                    SqlCommand Command = new SqlCommand("update uploaded_excel_data set cerpacno='" + LabelMessage.Text.Split(' ')[1].ToString() + "' where formno in ('" + TextAppId.Text.Replace(",", "','") + "')", Connection);
                    Connection.Open();
                    Command.ExecuteNonQuery();
                    Connection.Close();



                    //select check
                    SqlCommand CommandSelect = new SqlCommand("select * from uploaded_excel_data where formno='" + gv.Cells[10].Text+"'", ConnectionZone);
                    Connection.Open();
                    DataTable dt_ch_uploaded_excel_data = new DataTable();

                    SqlDataAdapter da_Ch_uploaded_excel_data = new SqlDataAdapter(CommandSelect);

                    da_Ch_uploaded_excel_data.Fill(dt_ch_uploaded_excel_data);
                    Connection.Close();

                    if (dt_ch_uploaded_excel_data.Rows.Count == 0)
                    {
                        SqlCommand CommandZone = new SqlCommand("INSERT INTO  Uploaded_Excel_Data(RecordNo, date1,branch,RequisitionNO,PassportNo,FirstName,MiddleName,LastName,Company,Nationality,Formno,TellerNo,Amount,StrVisaNo,CreatedBY,CreatedON)" +
                                                                " VALUES ( (select max(recordno)+1 from uploaded_excel_data),'" + ((Convert.ToDateTime(gv.Cells[0].Text))).ToString("MM/dd/yyyy") + "','',0,'" + gv.Cells[11].Text + "','" + gv.Cells[1].Text + "','" + gv.Cells[2].Text + "','" + gv.Cells[3].Text + "','" + gv.Cells[4].Text + "','" + gv.Cells[5].Text + "','" + gv.Cells[8].Text + "','" + gv.Cells[9].Text + "','" + gv.Cells[10].Text + "','" + gv.Cells[12].Text + "'," + objectSessionHolderPersistingData.User_ID + ",GETDATE())   ", ConnectionZone);
                        ConnectionZone.Open();
                        CommandZone.ExecuteNonQuery();
                        ConnectionZone.Close();

                        SqlCommand cmd_uploaded_excel_data_C = new SqlCommand("insert into uploaded_excel_data_C (formno, userid,request_date) values ('" + gv.Cells[8].Text + "', " + objectSessionHolderPersistingData.User_ID + ", getdate())", ConnectionZone);
                        ConnectionZone.Open();
                        cmd_uploaded_excel_data_C.ExecuteNonQuery();
                        ConnectionZone.Close();

                        SqlCommand cmd_uploaded_excel_data_C_central = new SqlCommand("insert into uploaded_excel_data_C (formno, userid,request_date) values ('" + gv.Cells[8].Text + "', " + objectSessionHolderPersistingData.User_ID + ", getdate())", Connection);
                        Connection.Open();
                        cmd_uploaded_excel_data_C_central.ExecuteNonQuery();
                        Connection.Close();

                    }
                   

                }
            }

            foreach (GridViewRow gv_cerpac in grd_cerpac.Rows)
            {
                SqlConnection Connection = new SqlConnection();
                Connection.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

                SqlConnection ConnectionZone = new SqlConnection();
                ConnectionZone.ConnectionString = ConfigurationManager.ConnectionStrings["NigeriaConnectionString"].ConnectionString;

                SqlCommand Command_ch_people = new SqlCommand("select * from people where cerpac_no='" + gv_cerpac.Cells[4].Text + "'", Connection);
                Connection.Open();
                DataTable dt_ch_people = new DataTable();

                SqlDataAdapter da_Ch_people = new SqlDataAdapter(Command_ch_people);

                da_Ch_people.Fill(dt_ch_people);
                Connection.Close();

                SqlCommand Command_ch_people_z = new SqlCommand("select * from people where cerpac_no='" + gv_cerpac.Cells[4].Text + "'", ConnectionZone);
                ConnectionZone.Open();
                DataTable dt_ch_people_z = new DataTable();

                SqlDataAdapter da_Ch_people_z = new SqlDataAdapter(Command_ch_people_z);

                da_Ch_people_z.Fill(dt_ch_people_z);
                ConnectionZone.Close();
                if (dt_ch_people_z.Rows.Count == 0)
                {
                    byte[] img = dt_ch_people.Rows[0]["userImage"] as byte[] ?? null;

                    SqlParameter picparameter = new SqlParameter("@pic", SqlDbType.Image);

                    picparameter.Value = img;
                    if (picparameter.Value == null)
                        picparameter.Value = "";



                    SqlCommand cmd11 = new SqlCommand("insert into people ([title],[forename],[middle_name],[surname],[sex],[residence_permit_no],[residence_issue_loc],[deedmark_no],[issue_no],[printed],[label_print_count],[card_print_count],[picture],[directory],[notes]" +
                                                           ",[cerpac_no],[cerpac_file_no],[cerpac_receipt_date],[cerpac_expiry_date],[registration_area],[registration_code],[file_no],[label_no],[book_no],[passport_no],[nationality],[passport_issue_date],[passport_expiry_date],[passport_issue_loc]" +
                                                           ",[passport_issue_by],[date_of_birth],[place_of_birth],[nigeria_add_1],[nigeria_add_2],[nigeria_tel_no],[abroad_add_1],[abroad_add_2],[abroad_tel_no],[company],[company_add_1],[company_add_2],[designation],[employment_date],[company_tel_no]" +
                                                            ",[company_fax_no],[email],[date_added],[added_by_user_id],[date_modified],[modified_by_user_id],[date_system_modified],[ContactNo],[userImage]) " +
                                                           "values('" + dt_ch_people.Rows[0]["title"].ToString().Replace("'", "''") + "','" + dt_ch_people.Rows[0]["forename"].ToString().Replace("'", "''") + "','" + dt_ch_people.Rows[0]["middle_name"].ToString().Replace("'", "''") + "','" + dt_ch_people.Rows[0]["surname"].ToString().Replace("'", "''") + "','" + dt_ch_people.Rows[0]["sex"].ToString().Replace("'", "''") + "','" + dt_ch_people.Rows[0]["residence_permit_no"].ToString().Replace("'", "''") + "','" + dt_ch_people.Rows[0]["residence_issue_loc"].ToString().Replace("'", "''") + "','" + dt_ch_people.Rows[0]["deedmark_no"].ToString().Replace("'", "''") + "','" + dt_ch_people.Rows[0]["issue_no"].ToString().Replace("'", "''") + "','" + dt_ch_people.Rows[0]["printed"].ToString().Replace("'", "''") + "','" + dt_ch_people.Rows[0]["label_print_count"].ToString().Replace("'", "''") + "','" + dt_ch_people.Rows[0]["card_print_count"].ToString().Replace("'", "''") + "','" + dt_ch_people.Rows[0]["picture"].ToString().Replace("'", "''") + "','" + dt_ch_people.Rows[0]["directory"].ToString().Replace("'", "''") + "','" + dt_ch_people.Rows[0]["notes"].ToString().Replace("'", "''") + "'," +
                                                           "'" + dt_ch_people.Rows[0]["cerpac_no"].ToString().Replace("'", "''") + "','" + dt_ch_people.Rows[0]["cerpac_file_no"].ToString().Replace("'", "''") + "','" + (Convert.ToDateTime(dt_ch_people.Rows[0]["cerpac_receipt_date"].ToString().Replace("'", "''"))).ToString("MM/dd/yyyy") + "','" + (Convert.ToDateTime(dt_ch_people.Rows[0]["cerpac_expiry_date"].ToString().Replace("'", "''"))).ToString("MM/dd/yyyy") + "','" + dt_ch_people.Rows[0]["registration_area"].ToString().Replace("'", "''") + "','" + dt_ch_people.Rows[0]["registration_code"].ToString().Replace("'", "''") + "','" + dt_ch_people.Rows[0]["file_no"].ToString().Replace("'", "''") + "','" + dt_ch_people.Rows[0]["label_no"].ToString().Replace("'", "''") + "','" + dt_ch_people.Rows[0]["book_no"].ToString().Replace("'", "''") + "','" + dt_ch_people.Rows[0]["passport_no"].ToString().Replace("'", "''") + "','" + dt_ch_people.Rows[0]["nationality"].ToString().Replace("'", "''") + "','" + (Convert.ToDateTime(dt_ch_people.Rows[0]["passport_issue_date"].ToString().Replace("'", "''"))).ToString("MM/dd/yyyy") + "','" + (Convert.ToDateTime(dt_ch_people.Rows[0]["passport_expiry_date"].ToString().Replace("'", "''"))).ToString("MM/dd/yyyy") + "','" + dt_ch_people.Rows[0]["passport_issue_loc"].ToString().Replace("'", "''") + "'," +
                                                           "'" + dt_ch_people.Rows[0]["passport_issue_by"].ToString().Replace("'", "''") + "','" + (Convert.ToDateTime(dt_ch_people.Rows[0]["date_of_birth"].ToString().Replace("'", "''"))).ToString("MM/dd/yyyy") + "','" + dt_ch_people.Rows[0]["place_of_birth"].ToString().Replace("'", "''") + "','" + dt_ch_people.Rows[0]["nigeria_add_1"].ToString().Replace("'", "''") + "','" + dt_ch_people.Rows[0]["nigeria_add_2"].ToString().Replace("'", "''") + "','" + dt_ch_people.Rows[0]["nigeria_tel_no"].ToString().Replace("'", "''") + "','" + dt_ch_people.Rows[0]["abroad_add_1"].ToString().Replace("'", "''") + "','" + dt_ch_people.Rows[0]["abroad_add_2"].ToString().Replace("'", "''") + "','" + dt_ch_people.Rows[0]["abroad_tel_no"].ToString().Replace("'", "''") + "','" + dt_ch_people.Rows[0]["company"].ToString().Replace("'", "''") + "','" + dt_ch_people.Rows[0]["company_add_1"].ToString().Replace("'", "''") + "','" + dt_ch_people.Rows[0]["company_add_2"].ToString().Replace("'", "''") + "','" + dt_ch_people.Rows[0]["designation"].ToString().Replace("'", "''") + "','" + (Convert.ToDateTime(dt_ch_people.Rows[0]["employment_date"].ToString().Replace("'", "''"))).ToString("MM/dd/yyyy") + "','" + dt_ch_people.Rows[0]["company_tel_no"].ToString().Replace("'", "''") + "'," +
                                                           "'" + dt_ch_people.Rows[0]["company_fax_no"].ToString().Replace("'", "''") + "','" + dt_ch_people.Rows[0]["email"].ToString().Replace("'", "''") + "','" + ((dt_ch_people.Rows[0]["date_added"].ToString().Replace("'", "''"))) + "','" + dt_ch_people.Rows[0]["added_by_user_id"].ToString().Replace("'", "''") + "','" + dt_ch_people.Rows[0]["date_modified"].ToString().Replace("'", "''") + "','" + dt_ch_people.Rows[0]["modified_by_user_id"].ToString().Replace("'", "''") + "','" + (Convert.ToDateTime(dt_ch_people.Rows[0]["date_system_modified"].ToString().Replace("'", "''"))).ToString("MM/dd/yyyy") + "','" + dt_ch_people.Rows[0]["ContactNo"].ToString().Replace("'", "''") + "',@pic" +
                                                           ")", ConnectionZone);
                    ConnectionZone.Open();
                    cmd11.Parameters.Add(picparameter);
                    cmd11.ExecuteNonQuery();
                    ConnectionZone.Close();
                }
                else
                {
                    //update
                    if ((DateTime.Compare(Convert.ToDateTime(dt_ch_people.Rows[0]["cerpac_receipt_date"].ToString().Replace("'", "''")), Convert.ToDateTime(dt_ch_people_z.Rows[0]["cerpac_receipt_date"].ToString().Replace("'", "''"))))>0)
                    {
                        byte[] img = dt_ch_people_z.Rows[0]["userImage"] as byte[] ?? null;

                        SqlParameter picparameter = new SqlParameter("@pic", SqlDbType.Image);

                        picparameter.Value = img;
                        if (picparameter.Value == null)
                            picparameter.Value = "";



                        SqlCommand cmd11 = new SqlCommand("update people set forename='" + dt_ch_people.Rows[0]["forename"].ToString().Replace("'", "''") + "', middlename='" + dt_ch_people.Rows[0]["middlename"].ToString().Replace("'", "''") + "', surname='" + dt_ch_people.Rows[0]["surname"].ToString().Replace("'", "''") + "', sex='" + dt_ch_people.Rows[0]["sex"].ToString().Replace("'", "''") + "', residence_issue_loc='" + dt_ch_people.Rows[0]["residence_issue_loc"].ToString().Replace("'", "''") + "', date_of_birth='" + (Convert.ToDateTime(dt_ch_people.Rows[0]["date_of_birth"].ToString().Replace("'", "''"))).ToString("MM/dd/yyyy") + "', cerpac_receipt_date='" + (Convert.ToDateTime(dt_ch_people.Rows[0]["cerpac_receipt_date"].ToString().Replace("'", "''"))).ToString("MM/dd/yyyy") + "', cerpac_expiry_date='" + (Convert.ToDateTime(dt_ch_people.Rows[0]["cerpac_expiry_date"].ToString().Replace("'", "''"))).ToString("MM/dd/yyyy") + "', passport_no='" + dt_ch_people.Rows[0]["passport_no"].ToString().Replace("'", "''") + "' where cerpac_no='" + dt_ch_people.Rows[0]["cerpac_no"].ToString().Replace("'", "''") + "'", ConnectionZone);
                        ConnectionZone.Open();
                        cmd11.Parameters.Add(picparameter);
                        cmd11.ExecuteNonQuery();
                        ConnectionZone.Close();
                    }

                }


            }
            ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Data Inserted & Updated Successfully.');", true);
            Go_Click(sender, e);
        }
        catch (Exception ex)
      {
          Response.Redirect("frmGenrateBankFormRequest.aspx");
          //objgenenral = new BaseLayer.General_function();
          // string err = objgenenral.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
          //lblmsg.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
          //lblmsg.Text = "There is no conectivity between servers. Please use offline."; 
          // lblmsg.CssClass = "warning-box";
      }
      finally
      {
          dt = null;
          objgenenral = null;
      }
        

    }
   
}