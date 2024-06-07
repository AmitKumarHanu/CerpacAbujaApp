using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using Label = System.Web.UI.WebControls.Label;

public partial class Admin_frmNewFormValidation : System.Web.UI.Page
{
    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    BaseLayer.General_function objgenenral = null;
    protected BaseLayer.General_function ObjGenBal = null;
    protected DataTable dt = new DataTable();
    protected DataTable mytable = new DataTable();

    protected DataSet objDs = new DataSet();
    BusinessEntityLayer.BalApprovalReviewL1 ObjbalApporvalL1 = null;
    #endregion
    String UserID = null;
    string FName = "", LName = "", Nationality = "", DOB = "", PassportNo = "";
    protected void Page_Load(object sender, EventArgs e)
    {
       
            try
            {

                objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
                if (objectSessionHolderPersistingData == null)
                {
                    Response.Redirect("../Login.aspx");
                }
                UserID = objectSessionHolderPersistingData.User_ID.ToString();
                Page.MaintainScrollPositionOnPostBack = true;
                if (!IsPostBack)
                {
                pnlStep1.Attributes.Add("style", "display:block;");
                }
                A1.HRef = "javascript:NewCal('" + txtADate.ClientID + "','DDMMMYYYY','','',78,1)";
                A2.HRef = "javascript:NewCal('" + txtDDate.ClientID + "','DDMMMYYYY','','',78,1)";
                A4.HRef = "javascript:NewCal('" + txtDOB.ClientID + "','DDMMMYYYY','','',78,1)";



            }
            catch (Exception ex)
            {
                objgenenral = new BaseLayer.General_function();
                //string err = objgenenral.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
                lblmsg.Text = "Error occured.Please contact system administrator. Ref No: " + ex.ToString();
                lblmsg.CssClass = "warning-box";

            }
        
    }


    //----------Step1-----------------------------
    protected void Go_Click(object sender, EventArgs e)
    {
        ObjGenBal = new BaseLayer.General_function();


        //-----------First Need to check with Bank Form details---------------------------

        if (txtFormNo.Text == string.Empty)
        {
            lblmsg.Attributes.Add("class", "active");
            lblmsg.Attributes["style"] = "color:red; font-weight:bold;";
            lblmsg.Text = " Please entry bank form number";
            return;
        }


        if (txtFormNo.Text != string.Empty)
        {
            string Qty1 = " Select top 1 X1.FirstName,X1.LastName, X1.PassportNo, X1.NATIONALITY,  X2.adjective, X1.COMPANY, X1.Formno  from Uploaded_Excel_Data X1, NationalityMaster X2 where  X1.NATIONALITY=X2.Country and  X1.FORMNO like '" + txtFormNo.Text.Trim() + "'  and ISNULL( X1.cerpacno,'0')='0'  ";
            DataTable dt1 = new DataTable();
            dt1 = ObjGenBal.FetchData(Qty1);
            if (dt1.Rows.Count > 0)
            {
                txtRFormNo.Text = dt1.Rows[0]["Formno"].ToString().ToUpper();
                txtFirstName.Text = dt1.Rows[0]["FirstName"].ToString().ToUpper();
                txtLastName.Text = dt1.Rows[0]["LastName"].ToString().ToUpper();
                txtPassportNo.Text = dt1.Rows[0]["PassportNo"].ToString();
                txtNationality.Text = dt1.Rows[0]["NATIONALITY"].ToString();
                txtCountry.Text = dt1.Rows[0]["adjective"].ToString().ToUpper();
                txtCompanyName.Text = dt1.Rows[0]["COMPANY"].ToString();


                pnlStep1.Attributes.Add("style", "display:none;");
                pnlStep2.Attributes.Add("style", "display:block;");
                btnSearch.Visible = true;
                btnAddMovement.Visible = false;
                Proceed.Visible = false;
                BtnSaveMovement.Visible = false;
                btnSubmit.Visible = false;

            }
            else
            {

                pnlStep1.Attributes.Add("style", "display:block;");
                pnlStep2.Attributes.Add("style", "display:none;");
            }
        }


    }
    public static string ConvertDate(string date, string pattern)
    {

        if (string.IsNullOrEmpty(date) == false && date != "")
        {
            DateTime date2;
            if (DateTime.TryParseExact(date, pattern, CultureInfo.InvariantCulture, DateTimeStyles.None, out date2))
            {
                //  return date2.ToString("MM/d/yyyy");
                return date2.ToString("yyyy/MM/d");
            }
            else
            {
                return "";
            }
        }
        else
        {
            return "";
        }
    }

    public int SP_Funtion(int R)
    {
        //SELECT Sl_No ,FirstName ,LastName ,PassportNo ,Company ,Nationality ,Formno ,SFirstName ,SDOB ,SNationality ,Count ,isRequest ,RequestBY ,RequestON ,isVerify ,VerifyBy ,VerifyOn FROM Cerpac .dbo .NewCase_Verfication 

        try
        {
          

            SqlParameter[] pram = new SqlParameter[10];

            // Date of Birth Detail
            if (string.IsNullOrEmpty(Convert.ToString(txtDOB.Text.Trim())))
            {
                txtDOB.Text = Convert.ToString(hdnDOB.Value);
            }


            pram[0] = new SqlParameter("@FormNo", txtRFormNo.Text.Trim());
            pram[1] = new SqlParameter("@FirstName", txtFirstName.Text.ToString().Trim());
            pram[2] = new SqlParameter("@LastName", txtLastName.Text.ToString().Trim());
            pram[3] = new SqlParameter("@Nationality", txtCountry.Text.Trim().ToString());
            pram[4] = new SqlParameter("@PassportNo", txtPassportNo.Text.Trim().ToString());
            pram[5] = new SqlParameter("@DOB", ConvertDate(txtDOB.Text.ToString().Trim(), "dd-MM-yyyy"));
            pram[6] = new SqlParameter("@Count", R);
            pram[7] = new SqlParameter("@Flag", "Pending");
            pram[8] = new SqlParameter("@UserID", UserID);
     

            pram[9] = new SqlParameter("@Success", 1);
            pram[9].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[Usp_NewCase_Verfication]", pram);
            return int.Parse(pram[9].Value.ToString());

            //return 0;
        }
        catch (Exception ex)
        {
            throw (ex);
        }

        // DateTime d1 = Convert.ToDateTime(ConvertDate(TxtIssueDate.Text.ToString(), "d-MM-yyyy"));
        //SqlParameter output = new SqlParameter("@Success", SqlDbType.Int);
        //output.Direction = ParameterDirection.Output;
        //cmd.Parameters.Add(output);
        //cn1.Open();
        //cmd.ExecuteNonQuery();
        //String R = output.Value.ToString();
        //cn1.Close();

    }



    protected void Proceed_Click(object sender, EventArgs e)
    {
        objgenenral = new BaseLayer.General_function();
        DataTable dtzone = new DataTable();
        DataTable dtzonename = new DataTable();
        DataTable dtssfn = new DataTable();
        DataTable dt = new DataTable();
        DataTable dtuser = new DataTable();
        DataTable dtnew = new DataTable();
        DataTable dtreject = new DataTable();

        try
        {
            //-----------------------------Bank table check ------------------
            DataTable dtuploadchk = null;
            dtuploadchk = new DataTable();
            string queryforuploadchk = "Select * from uploaded_excel_data where formno='" + txtFormNo.Text.ToString().Trim() + "'";
            dtuploadchk = objgenenral.FetchData(queryforuploadchk);
            if (dtuploadchk.Rows.Count == 0)
            {
                lblmsg.Text = "This is an invalid Form number / Form number does not exists.";
                lblmsg.CssClass = "warning-box";
                return;
            }

            //-----------------------------Bank form Used or Not check-------------------------------------
            string queryforzone = "Select * from CerpacNo_Out_One where cerpac_no ='" + txtFormNo.Text.ToString() + "' and cerpac_file_no='" + txtFormNo.Text.ToString() + "'";
            dtzone = objgenenral.FetchData(queryforzone);
            if (dtzone.Rows.Count > 0)
            {
                string queryforreject = "Select * from peoplechild where CerpacNo='" + txtFormNo.Text.ToString().Trim() + "' and FORMNO='" + txtFormNo.Text.ToString().Trim() + "'";
                dtreject = objgenenral.FetchData(queryforreject);
                if (dtreject.Rows.Count > 0 && dtreject.Rows[0]["IsRejected"].ToString() == "1")
                {
                    lblmsg.Text = "This is a Rejected Case.";
                    lblmsg.CssClass = "warning-box";
                }
                else
                {
                    string zonecode = dtzone.Rows[0]["ZoneCode"].ToString().Trim();
                    string queryforzonename = "Select ZoneName from ZoneMaster where ZoneCode=" + zonecode + "";

                    dtzonename = objgenenral.FetchData(queryforzonename);
                    if (dtzonename.Rows.Count > 0)
                    {
                        lblmsg.Text = "This Cerpac Number is under processing at " + dtzonename.Rows[0]["ZoneName"].ToString() + " zone.";
                        lblmsg.CssClass = "warning-box";
                    }
                }
            }


            else
            {
                //-----------------------------Move for New Application-------------------------------------

                string queryforsecuredform = "Select * from Uploaded_Excel_Data where FORMNO ='" + txtFormNo.Text.ToString().Trim() + "'and (CerpacNo is null or CerpacNo='')";

                dtssfn = objgenenral.FetchData(queryforsecuredform);
                if (dtssfn.Rows.Count > 0)
                {



                    string quer = "select * from People where cerpac_no='" + txtFormNo.Text.ToString() + "'";
                    string querforuser = "Select a.ZoneName,b.ZoneCode from ZoneMaster as a, UserZoneRelation as b where a.ZoneCode = b.ZoneCode and b.UserId=" + objectSessionHolderPersistingData.User_ID.ToString() + "";
                    string queryfornewcase = "Select * from Issue where cerpac_no='" + txtFormNo.Text.ToString() + "'";

                    dt = objgenenral.FetchData(quer);

                    dtuser = objgenenral.FetchData(querforuser);

                    dtnew = objgenenral.FetchData(queryfornewcase);
                    //-------------------------------------------checking for the verification of cerpac no----------------------------------
                    if (dt.Rows.Count > 0)
                    {
                        lblmsg.Text = "This is not a Fresh Application.";
                        lblmsg.CssClass = "warning-box";
                    }
                    else
                    {
                        if (dtuser.Rows.Count > 0)
                        {

                            //----------------checking for the fresh case -----------------------
                            if (dtnew.Rows.Count == 0)
                            {
                                Response.Redirect("FrmApplicationDetailsForNew.aspx?no=" + txtFormNo.Text.ToString().Trim().ToUpper() + "&fno=" + txtFormNo.Text.ToString().Trim().ToUpper() + "");
                            }
                            else if (dtnew.Rows.Count > 0)
                            {
                                lblmsg.Text = "This is not a fresh case.";
                                lblmsg.CssClass = "warning-box";
                                // Response.Redirect("FrmApplicationDetails.aspx?no=" + TextAppId.Text.ToString() + "&fno=" + TextAppId.Text.ToString().Trim() + "");
                            }


                        }
                        else
                        {
                            lblmsg.Text = "The user is not associated with any zone.";
                            lblmsg.CssClass = "warning-box";
                        }
                    }
                }
                else
                {
                    lblmsg.Text = "This Application has already been processed.";
                    lblmsg.CssClass = "warning-box";
                }
            }


        }
        catch (Exception ex)
        {
            objgenenral = new BaseLayer.General_function();
            string err = objgenenral.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            lblmsg.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            lblmsg.CssClass = "warning-box";
        }

    }

    //----------Step2-----------------------------
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        ObjGenBal = new BaseLayer.General_function();

        if (txtDOB.Text == string.Empty)
        {
            lblmsg.Attributes.Add("class", "active");
            lblmsg.Attributes["style"] = "color:red; font-weight:bold;";
            lblmsg.Text = " Please entry date of birth";
            return;
        }

        if (txtFormNo.Text != string.Empty && txtDOB.Text != string.Empty && txtFirstName.Text != string.Empty)
        {
            string QtyF = "Select top 1 FirstName,LastName, NATIONALITY, PassportNo  from Uploaded_Excel_Data where FORMNO like '" + txtFormNo.Text.Trim() + "' and ( FirstName like '" + txtFirstName.Text.Trim() + "%' or LastName like '" + txtFirstName.Text.Trim() + "%')  and ( FirstName like '" + txtLastName.Text.Trim() + "%' or LastName like '" + txtLastName.Text.Trim() + "%') and ISNULL(cerpacno,'0')='0'  ";
            DataTable dtf = new DataTable();
            dtf = ObjGenBal.FetchData(QtyF);
            if (dtf.Rows.Count > 0)
            {
                FName = dtf.Rows[0]["FirstName"].ToString().ToUpper();
                LName = dtf.Rows[0]["LastName"].ToString().ToUpper();
                Nationality = dtf.Rows[0]["NATIONALITY"].ToString();
                PassportNo = dtf.Rows[0]["PassportNo"].ToString().ToUpper();
                DOB = txtDOB.Text.Trim(); ;
                lblmsg.Attributes.Add("class", "active");
                lblmsg.Attributes["style"] = "color:block; font-weight:bold;";
                lblmsg.Text = "New STR Visa holder expatriate details.";
                if (FName == txtFirstName.Text.ToUpper() || FName == txtLastName.Text.ToUpper())
                {
                    //------------Pls check again---------------------
                    string QtyF1 = "Select Formno, FirstName, LastName, PassportNo, Company, Convert(varchar(10),SDOB,23) as SDOB , Nationality, SNationality ,isVerify From NewCase_Verfication where isRequest=1  and " +
                        " FORMNO like '" + txtFormNo.Text.Trim() + "' and ( FirstName like '" + txtFirstName.Text.Trim() + "%' or LastName like '" + txtFirstName.Text.Trim() + "%')   ";
                    DataTable dtF = new DataTable();
                    dtF = ObjGenBal.FetchData(QtyF1);



                    if (dtF.Rows.Count > 0 && dtF.Rows[0]["isVerify"].ToString() == "0")
                    {

                        lblmsg.Attributes.Add("class", "active");
                        //lblmsg.Attributes["style"] = "color:red; font-weight:bold;";
                        lblmsg.Text = " The bank form number " + txtFormNo.Text.Trim() + " is waiting for central approval ";
                        Go.Visible = true;
                        lblmsg.Visible = true;

                        return;
                    }


                    if (dtF.Rows.Count > 0 && dtF.Rows[0]["isVerify"].ToString() == "1")
                    {

                        lblmsg.Attributes.Add("class", "active");
                        //lblmsg.Attributes["style"] = "color:red; font-weight:bold;";
                        lblmsg.Text = " The bank form number " + txtFormNo.Text.Trim() + " has been approved by central  ";
                        lblmsg.CssClass = "confirmation-box";
                        lblmsg.ForeColor = System.Drawing.Color.Green;


                        // Go.Visible = true;

                        btnSearch.Visible = false;
                        btnAddMovement.Visible = false;
                        Proceed.Visible = true;
                        BtnSaveMovement.Visible = false;
                        btnSubmit.Visible = false;

                        return;
                    }


                    if (dtF.Rows.Count > 0 && dtF.Rows[0]["isVerify"].ToString() == "-1")
                    {

                        lblmsg.Attributes.Add("class", "active");
                        //lblmsg.Attributes["style"] = "color:red; font-weight:bold;";
                        lblmsg.Text = " The bank form number " + txtFormNo.Text.Trim() + " has been rejected by central   ";
                        lblmsg.CssClass = "confirmation-box";
                        lblmsg.ForeColor = System.Drawing.Color.Red;

                        Go.Visible = true;

                        return;

                    }
                    //-----------frind duplication cerpac holder details---------------------------

                    // string QtyN = "Select  Forename, surname, Cerpac_no, convert(varchar(10), cerpac_expiry_date,103) as cerpac_expiry_date, Nationality, Passport_No, convert(varchar(10), date_of_birth,103)  as  DOB, b.Company, Designation From people a, CompMaster b  where a.company=b.regno and  (forename = '" + FName.ToString().Trim() + "' or surname = '" + FName.ToString().Trim() + "') and ( forename='" + LName.ToString().Trim() + "'  or surname='" + LName.ToString().Trim() + "' ) and  nationality='" + txtCountry.Text.Trim() + "' and  (  date_of_birth='" + ConvertDate(txtDOB.Text.ToString().Trim(), "d-MM-yyyy") + "' or Passport_no='" + PassportNo.ToString().Trim() + "')  order by year(cerpac_expiry_date) desc, month(cerpac_expiry_date) desc, day(cerpac_expiry_date) desc";
                    string QtyN = "Select  Forename, surname, Cerpac_no, convert(varchar(10), cerpac_expiry_date,103) as cerpac_expiry_date, Nationality, Passport_No,  b.Company, Designation From people a, CompMaster b  where a.company=b.regno and  (forename = '" + FName.ToString().Trim() + "' or surname = '" + FName.ToString().Trim() + "') and ( forename='" + LName.ToString().Trim() + "'  or surname='" + LName.ToString().Trim() + "' ) and  nationality='" + txtCountry.Text.Trim() + "' and  (  date_of_birth='" + ConvertDate(txtDOB.Text.ToString().Trim(), "d-MM-yyyy") + "' or Passport_no='" + PassportNo.ToString().Trim() + "')  order by year(cerpac_expiry_date) desc, month(cerpac_expiry_date) desc, day(cerpac_expiry_date) desc";
                    DataTable dt = new DataTable();
                    dt = ObjGenBal.FetchData(QtyN);

                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            GridNDetails.DataSource = dt;
                            GridNDetails.DataBind();

                            string EDate = dt.Rows[0]["cerpac_expiry_date"].ToString();
                            string CDate = DateTime.Now.ToShortDateString().Replace('-', '/');
                            pnlStep1.Attributes.Add("style", "display:none;");
                            pnlStep2.Attributes.Add("style", "display:block;");
                            pnlStep3.Attributes.Add("style", "display:block;");

                            btnSearch.Visible = false;
                            btnAddMovement.Visible = true;
                            Proceed.Visible = false;
                            BtnSaveMovement.Visible = false;
                            btnSubmit.Visible = false;
                            //Please add arrival/departure details , STR Visa Details between 22/11/2022 - 17/04/2023 from passport.
                            lblmsg1.Visible = true;
                            lblmsg1.Text = "The expatriate record already exists in the database. <br /> Please add arrival/departure details between '" + EDate.ToString() + "'  to '" + CDate.ToString() + "'  from passport."; ;
                            lblmsg1.CssClass = "confirmation-box";
                            lblmsg1.ForeColor = System.Drawing.Color.Green;

                        }

                        else
                        {

                            btnSearch.Visible = false;
                            btnAddMovement.Visible = false;
                            Proceed.Visible = true;
                            BtnSaveMovement.Visible = false;
                            btnSubmit.Visible = false;
                        }

                    }
                    else
                    {

                        lblmsg.Attributes.Add("class", "active");
                        //lblmsg.Attributes["style"] = "color:red; font-weight:bold;";
                        lblmsg.Text = " Pls try again" + " </h4>";
                        return;
                    }
                }

            }

        }
    }

    //----------Step3-----------------------------
    protected void btnAddMovement_Click(object sender, EventArgs e)
    {


        pnlStep1.Attributes.Add("style", "display:none;");
        pnlStep2.Attributes.Add("style", "display:block;");
        pnlStep3.Attributes.Add("style", "display:block;");
        pnlStep4.Attributes.Add("style", "display:block;");

        btnSearch.Visible = false;
        btnAddMovement.Visible = false;
        Proceed.Visible = false;
        BtnSaveMovement.Visible = true;
        btnSubmit.Visible = false;

        txtAProd.Text = "";
        txtADate.Text = "";
        txtDPort.Text = "";
        txtDDate.Text = "";
        txtSTRVisa.Text = "";

    }
    //----------Step4-----------------------------
    protected void BtnSaveMovement_Click(object sender, EventArgs e)
    {
        pnlStep1.Attributes.Add("style", "display:none;");
        pnlStep2.Attributes.Add("style", "display:block;");
        pnlStep3.Attributes.Add("style", "display:block;");
        pnlStep4.Attributes.Add("style", "display:none;");
        pnlStep5.Attributes.Add("style", "display:block;");
        pnlStep6.Attributes.Add("style", "display:none;");

        if (txtAProd.Text != string.Empty && txtADate.Text != string.Empty || txtDPort.Text != string.Empty && txtDDate.Text != string.Empty)
        {
            grdMovement.Visible = true; //my grid view name  
            createnewrow(); //call a function  

            lblMsg2.Text = " "; ;
            lblMsg2.CssClass = "confirmation-box";
            lblMsg2.ForeColor = System.Drawing.Color.Red;

        }

        btnSearch.Visible = false;
        btnAddMovement.Visible = true;
        Proceed.Visible = false;
        BtnSaveMovement.Visible = false;
        btnSubmit.Visible = true;


    }

    public void createnewrow()
    {

        if (ViewState["Row"] != null)
        {
            mytable = (DataTable)ViewState["Row"];
            DataRow dr = null;
            if (mytable.Rows.Count > 0)
            {
                dr = mytable.NewRow();
                dr["Arrival_Port"] = txtAProd.Text;
                dr["Arrival_Date"] = txtADate.Text;
                dr["Departure_Port"] = txtDPort.Text;
                dr["Departure_Date"] = txtDDate.Text;
                dr["STR_Visa_Bo"] = txtSTRVisa.Text;
                mytable.Rows.Add(dr);
                ViewState["Row"] = mytable;
                grdMovement.DataSource = ViewState["Row"];
                grdMovement.DataBind();
            }
        }
        else
        {

            mytable.Columns.Add("Arrival_Port", typeof(string));
            mytable.Columns.Add("Arrival_Date", typeof(string));
            mytable.Columns.Add("Departure_Port", typeof(string));
            mytable.Columns.Add("Departure_Date", typeof(string));
            mytable.Columns.Add("STR_Visa_Bo", typeof(string));
            DataRow dr1 = mytable.NewRow();
            dr1 = mytable.NewRow();
            dr1["Arrival_Port"] = txtAProd.Text;
            dr1["Arrival_Date"] = txtADate.Text;
            dr1["Departure_Port"] = txtDPort.Text;
            dr1["Departure_Date"] = txtDDate.Text;
            dr1["STR_Visa_Bo"] = txtSTRVisa.Text;
            mytable.Rows.Add(dr1);
            ViewState["Row"] = mytable;
            grdMovement.DataSource = ViewState["Row"];
            grdMovement.DataBind();
        }
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //--------------Function to save details on NewCase_Verification table----------------------
        //SELECT Sl_No ,FirstName ,LastName ,PassportNo ,Company ,Nationality ,Formno ,SFirstName ,SDOB ,SNationality ,Count ,isRequest ,RequestBY ,RequestON ,isVerify ,VerifyBy ,VerifyOn FROM Cerpac.dbo.NewCase_Verfication

        try
        {



            if (txtFormNo.Text != string.Empty && txtDOB.Text != string.Empty && txtFirstName.Text != string.Empty)
            {
                int k = ckPonint();
          

                if (k > 300 || txtSTRVisa.Text == string.Empty) {
                    //lblMsg2.Text = " Please provide arriving details with in 90 days for movement verification by the airport authority !!"; ;
                    lblMsg2.Text = " Please provide arriving details with in 90 days with new STR Visa number for verification !!"; ;
                    lblMsg2.CssClass = "confirmation-box";
                    lblMsg2.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    pnlStep6.Attributes.Add("style", "display:block;");

                   
                    if (!FileUpload1.HasFile)
                    {



                        lblMsg2.Visible = true;
                        lblMsg2.Text = "Please upload str visa screenshots";
                        lblMsg2.CssClass = "warning-box";
                        return;


                    }

                    int status = SP_Funtion(dt.Rows.Count);
                    if (status == 1)
                    {
                        int Move = SP_Movement(mytable.Rows.Count);

                        if (Move == 1)
                        {
                            Attachfile();
                        }
                        lblmsg.Visible = true;
                        lblmsg.Text = "Initiate verification request successfull. Please wait for central approval !!"; ;
                        lblmsg.CssClass = "confirmation-box";
                        lblmsg.ForeColor = System.Drawing.Color.Green;

                        pnlStep1.Attributes.Add("style", "display:none;");
                        pnlStep2.Attributes.Add("style", "display:none;");
                        pnlStep3.Attributes.Add("style", "display:none;");
                        pnlStep4.Attributes.Add("style", "display:none;");
                        pnlStep5.Attributes.Add("style", "display:none;");
                        pnlStep6.Attributes.Add("style", "display:none;");

                        btnSearch.Visible = false;
                        btnAddMovement.Visible = false;
                        Proceed.Visible = false;
                        BtnSaveMovement.Visible = false;
                        btnSubmit.Visible = false;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            objgenenral = new BaseLayer.General_function();
            //string err = objgenenral.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            lblmsg.Text = "Error occured.Please contact system administrator. Ref No: " + ex.ToString();
            lblmsg.CssClass = "warning-box";

        }
    }

    public static string connection = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ToString();

    public int SP_Movement(int R)
    {
        //SqlParameter[] pram = new SqlParameter[9];
        ////--------------Normal-----------------
        //for (int i = 0; i > mytable.Rows.Count; i++)
        //{
        //    pram[0] = new SqlParameter("@FormNo", txtRFormNo.Text.Trim());
        //    pram[1] = new SqlParameter("@Arrival_Port", mytable.Rows[i]["Arrival_Port"].ToString());
        //    pram[2] = new SqlParameter("@Arrival_Date", mytable.Rows[i]["Arrival_Date"].ToString());
        //    pram[3] = new SqlParameter("@Departure_Port", mytable.Rows[i]["Departure_Port"].ToString());
        //    pram[4] = new SqlParameter("@Departure_Date", mytable.Rows[i]["Departure_Date"].ToString());
        //    pram[5] = new SqlParameter("@STR_Visa_Bo", mytable.Rows[i]["STR_Visa_Bo"].ToString());
        //    pram[6] = new SqlParameter("@Flag", "M");
        //    pram[7] = new SqlParameter("@UserID", UserID);

        //    pram[8] = new SqlParameter("@Success", 1);
        //    pram[8].Direction = ParameterDirection.Output;
        //    SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[Usp_NewCase_Movement]", pram);
        //    return int.Parse(pram[8].Value.ToString());


        //}
        int Count = 0;
        //--------------Normal-----------------
        foreach (GridViewRow r in grdMovement.Rows)
        {
            //SELECT Sl_No,Formno,Arrival_Port,Arrival_Date,Departure_Port,Departure_Date,STR_Visa_Bo,isRequest,RequestBY,RequestON,isVerify,VerifyBy,VerifyOn FROM NewCase_Movement

            SqlConnection cn1 = new SqlConnection(connection);

            Label lblArrival_Port = (Label)r.FindControl("lblArrival_Port");
            Label lblArrival_Date = (Label)r.FindControl("lblArrival_Date");
            Label lblDeparture_Port = (Label)r.FindControl("lblDeparture_Port");
            Label lblDeparture_Date = (Label)r.FindControl("lblDeparture_Date");
            Label lblSTR_Visa_Bo = (Label)r.FindControl("lblSTR_Visa_Bo");



            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn1;
            cmd.CommandText = "[Usp_NewCase_Movement]";

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FormNo", txtRFormNo.Text.Trim());
            cmd.Parameters.AddWithValue("@Arrival_Port", lblArrival_Port.Text.ToString());
            cmd.Parameters.AddWithValue("@Arrival_Date", lblArrival_Date.Text.ToString());
            cmd.Parameters.AddWithValue("@Departure_Port", lblDeparture_Port.Text.ToString());
            cmd.Parameters.AddWithValue("@Departure_Date", lblDeparture_Date.Text.ToString());
            cmd.Parameters.AddWithValue("@STR_Visa_Bo", lblSTR_Visa_Bo.Text.ToString());

            cmd.Parameters.AddWithValue("@Userid", UserID);
            cmd.Parameters.AddWithValue("@Flag", "A");
            SqlParameter output = new SqlParameter("@Success", SqlDbType.Int);
            output.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(output);
            cn1.Open();
            cmd.ExecuteNonQuery();
            String R1 = output.Value.ToString();
            cn1.Close();

            if (R1 == "1")
            {
                //---------Get Mobile number-----------                       
                // string SMS = CommonFunctions.SendSMS("+231775462142", " Hello, Your application reference id "+ lbl_EmployeeID.Text.Trim().ToString() + " has approved by Commission General, Liberia Immigartion Service. Please move for payment process!");
                Session["StrVisa"] = lblSTR_Visa_Bo.Text.ToString();
                Count++;
            }


            //}


        }



        return 1;



    }


    public int Attachfile()
    {
        string filePath = FileUpload1.PostedFile.FileName; // getting the file path of uploaded file  
        string filename1 = Path.GetFileName(filePath); // getting the file name of uploaded file  
        string ext = Path.GetExtension(filename1); // getting the file extension of uploaded file  
        string type = String.Empty;
        if (filePath == String.Empty)
        {

            lblMsg2.Visible = true;
            lblMsg2.Text = "Please upload str visa screenshots";
            lblMsg2.CssClass = "warning-box";
            return 0;

        }
        else
        {
            if (!FileUpload1.HasFile)
            {

                lblMsg2.Visible = true;
                lblMsg2.Text = "Please upload str visa screenshots";
                return 0;
            }
            else
                if (FileUpload1.HasFile)
            {


                    SqlConnection Connection = new SqlConnection();
                    Connection.ConnectionString = ConfigurationManager.ConnectionStrings["NigeriaConnectionString"].ConnectionString;

                    Stream fs = FileUpload1.PostedFile.InputStream;
                    BinaryReader br = new BinaryReader(fs); //reads the binary files  
                    Byte[] bytes = br.ReadBytes((Int32)fs.Length); //counting the file length into bytes  

                    SqlCommand Command = new SqlCommand("Update NewCase_Verfication Set Attachment=@Attachment, FileName=@FileName, STRVisaNo='" + Session["StrVisa"].ToString().Trim() + "' Where Formno='" + txtFormNo.Text.ToString().Trim() + "' and FirstName='" + txtFirstName.Text.ToString().Trim() + "' and LastName='" + txtLastName.Text.ToString().Trim() + " '", Connection);
                    Command.Parameters.Add("@Attachment", SqlDbType.Binary).Value = bytes;
                    Command.Parameters.Add("@FileName", SqlDbType.VarChar).Value = filename1;
                    Connection.Open();
                    Command.ExecuteNonQuery();
                    Connection.Close();

                    return 1;
                
            }
        }
        return 0;
    }

    protected void grdMovement_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    public int ckPonint()
    {
        int Count = 0;
        string ADate = "";
        CultureInfo provider = CultureInfo.InvariantCulture;
        //--------------Normal-----------------
        foreach (GridViewRow r in grdMovement.Rows)
        {
            

            Label lblArrival_Port = (Label)r.FindControl("lblArrival_Port");
            Label lblArrival_Date = (Label)r.FindControl("lblArrival_Date");
            Label lblDeparture_Port = (Label)r.FindControl("lblDeparture_Port");
            Label lblDeparture_Date = (Label)r.FindControl("lblDeparture_Date");
            Label lblSTR_Visa_Bo = (Label)r.FindControl("lblSTR_Visa_Bo");
            ADate = lblArrival_Date.Text.Trim();
        }
        string CDate = DateTime.Now.ToShortDateString().Replace('-', '/');

        // DateTime d1 = Convert.ToDateTime(ADate);
        // DateTime d2 = DateTime.Now.AddDays(-1);

        //DateTime d1 = DateTime.ParseExact(ADate, new string[] { "MM.dd.yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "dd.MM.yyyy", "dd-MM-yyyy", "dd/MM/yyyy" }, provider, DateTimeStyles.None);
        //DateTime d2 = DateTime.Now.AddDays(-1);

        //TimeSpan t = d1 - d2;
        //double NrOfDays = t.TotalDays;
        //DateTime.Parse(String value, IFormatProvider provider)

        //TimeSpan t1 = d2 - d1;
        //int days = Convert.ToInt16( t1.TotalDays );
        int days = 300;
        return days;
    }

}