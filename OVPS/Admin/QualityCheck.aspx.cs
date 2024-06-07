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
using System.Globalization;
using System.Threading;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;
using System.Configuration;
using System.Net;
using System.Diagnostics;


public partial class Admin_QualityCheck : System.Web.UI.Page
{
    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    BaseLayer.General_function objgenenral = null;
    protected DataSet objDs = new DataSet();
    protected DataTable dt = new DataTable();

    protected BaseLayer.General_function ObjGenBal = null;
    string AppID = "";
    string FRNno = "";
    string UserID = null;
    Label LabelMessage = null;
    string zone_c = "";
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
                zone_c = dt.Rows[0]["ZoneName"].ToString();
            }
        }
        catch (Exception ex)
        {
            //throw (ex);
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
            Bindlist();
            detailtable.Style.Add("display", "none");
            // warn.Style.Add("display", "");
        }


        //string queryforposition = "select forename as FirstName, middle_name as MiddleName, surname as  LastName, Company, Nationality, RequisitionNo, FormNo, CerpacNo, PassportNo, isnull(StrVisaNo,'') as StrVisaNo from People as a , PeopleChild as b where a.cerpac_no = b.CerpacNo";

        //DataTable ds1 = new DataTable();
        //ds1 = objgenenral.FetchData(queryforposition);

        //if (ds1.Rows[0]["IsProduced"].ToString() == "1")
        //{
        //    btnCardOk.Enabled = true;
        //    btnCardReject.Visible = true;
        //    confirm.Style.Add("display", "none");
        //    warn.Style.Add("display", "none");
        //}
        //else
        //{
        //    btnCardOk.Enabled = false;
        //    btnCardReject.Visible = false;
        //    confirm.Style.Add("display", "none");
        //    warn.Style.Add("display", "");
        //    warn.InnerText = "Card Not Produced Till Now.";
        //}


    }

    protected void Bindlist()
    {
        objgenenral = new BaseLayer.General_function();

        //string queryforposition = "select forename as FirstName, middle_name as MiddleName, surname as  LastName, Company, Nationality, RequisitionNo, cerpac_file_no as FormNo, CerpacNo, Passport_No as PassportNo, isnull(StrVisaNo,'') as StrVisaNo, printed from People as a , PeopleChild as b where a.cerpac_no = b.CerpacNo and IsProduced=1";

      
       // string queryforposition = "select forename as FirstName, middle_name as MiddleName, surname as  LastName, Company, Nationality, RequisitionNo, cerpac_file_no as FormNo, CerpacNo, Passport_No as PassportNo, isnull(StrVisaNo,'') as StrVisaNo, printed from vw_prod_consolidated_data a, UserZoneRelation b where (IsProduced=1) and (isqual=0 or isqual is null) and a.verifiedby = b.userid  and b.ZoneCode=(select ZoneCode from UserZoneRelation where USERID=" + objectSessionHolderPersistingData.User_ID + ")";
       string queryforposition = "select forename as FirstName, middle_name as MiddleName, surname as  LastName, Company, Nationality, RequisitionNo, cerpac_file_no as FormNo, CerpacNo, Passport_No as PassportNo, isnull(StrVisaNo,'') as StrVisaNo, printed from vw_prod_consolidated_data a, UserZoneRelation b where (IsProduced=1) and (isqual=0 or isqual is null) and a.verifiedby = b.userid";
        

        DataTable dt1 = new DataTable();
        try
        {

            dt1 = objgenenral.FetchData(queryforposition);

            if (dt1.Rows.Count > 0)
            {
                grd_display_data.DataSource = dt1;
                grd_display_data.DataBind();
            }
            else
            {
                btnok.Visible = false;
                btnCardOk.Visible = false;
                btn_read.Visible = false;
                grd_display_data.DataSource = dt1;
                grd_display_data.DataBind();

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

    protected void chkAccessAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkGV;
        CheckBox chk = ((CheckBox)sender);
        string ChkName = chk.ID;
        ChkName = ChkName.Substring(0, ChkName.Length - 6);
        foreach (GridViewRow gv in grd_display_data.Rows)
        {
            chkGV = (CheckBox)gv.FindControl("CheckBox1");
            chkGV.Checked = chk.Checked;

        }

    }


    protected void Go_Click(object sender, EventArgs e)
    {
        objgenenral = new BaseLayer.General_function();
      //  string quer = "select a.*,b.* from People as a , PeopleChild as b where a.cerpac_no = b.CerpacNo and a.cerpac_no='" + TextAppId.Text.ToString() + "'";
        try
        {
            string quer = "select forename as FirstName, middle_name as MiddleName, surname as  LastName, Company, Nationality, RequisitionNo, cerpac_file_no as FormNo, CerpacNo, Passport_No as PassportNo, isnull(StrVisaNo,'') as StrVisaNo, printed from vw_prod_consolidated_data a, UserZoneRelation b where (IsProduced=1) and (isqual=0 or isqual is null) and a.verifiedby = b.userid  and b.ZoneCode=(select ZoneCode from UserZoneRelation where USERID=" + objectSessionHolderPersistingData.User_ID + ") and cerpacno='" + TextAppId.Text.ToString() + "'";



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

            //if (dt.Rows.Count > 0)
            //{
            //    if (dt.Rows[0]["Printed"].ToString() == "Y ")
            //    {
            //        btnCardOk.Visible = false;
            //        btnCardReject.Visible = false;
            //    }
            //    else
            //    {
            //        btnCardOk.Visible = true;
            //        btnCardReject.Visible = true;
            //    }
            //}
            GetData(TextAppId.Text);
            tblgrdview.Style.Add("display", "none");
            tblsearch.Style.Add("display", "none");
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


    private void GetData(string ApplicationId)
    {
        DataTable Dt = null;
        DataTable dtbnk = null;
        Dt = new DataTable();
        ObjGenBal = new BaseLayer.General_function();
        //string queryforcerpac = "select a.*,b.* from People as a , PeopleChild as b where a.cerpac_no = b.CerpacNo and (IsProduced=1) and a.cerpac_no='" + ApplicationId.ToString() + "'";

      //  string queryforcerpac = "select * from vw_prod_consolidated_data where (IsProduced=1) and (IsQual=0 or IsQual is null) and cerpac_no='" + ApplicationId.ToString() + "'";
        try
        {
            string queryforcerpac = "select * from vw_prod_consolidated_data a, UserZoneRelation b where (IsProduced=1) and (isqual=0 or isqual is null) and a.verifiedby = b.userid  and b.ZoneCode=(select ZoneCode from UserZoneRelation where USERID=" + objectSessionHolderPersistingData.User_ID + ") and cerpacno='" + ApplicationId + "'";



            CultureInfo c = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = c.TextInfo;

            Dt = ObjGenBal.FetchData(queryforcerpac);
            Session["Card"] = Dt;
            if (Dt.Rows.Count > 0)
            {
                // ImgPhoto.ImageUrl = "~/Images/Logo/" + Dt.Rows[0]["picture"].ToString().Trim();
                ImgPhoto.ImageUrl = "~/Images/Logo/" + Dt.Rows[0]["picture"].ToString().Trim();
                TxtPassportNo.Text = Dt.Rows[0]["passport_no"].ToString().Trim();
                TxtNationality.Text = string.Format("{0:dd/MM/yy}", Dt.Rows[0]["nationality"]).ToString().Trim();
                TxtPassportType.Text = string.Format("{0:dd/MM/yy}", Dt.Rows[0]["passport_issue_by"]).ToString().Trim();
                TxtDateOfIssue.Text = string.Format("{0:dd/MM/yy}", Dt.Rows[0]["passport_issue_date"]).ToString().Trim();
                txtdoe.Text = string.Format("{0:dd/MM/yy}", Dt.Rows[0]["passport_expiry_date"]).ToString().Trim();
                TxtPlaceOfIssue.Text = textInfo.ToTitleCase(Dt.Rows[0]["passport_issue_loc"].ToString().Trim().ToLower());
                TxtFirstName.Text = textInfo.ToTitleCase(Dt.Rows[0]["forename"].ToString().Trim().ToLower());
                TxtMiddleName.Text = Dt.Rows[0]["middle_name"].ToString().Trim();
                TxtLastName.Text = textInfo.ToTitleCase(Dt.Rows[0]["surname"].ToString().Trim().ToLower());
                txtcompname.Text = textInfo.ToTitleCase(Dt.Rows[0]["company"].ToString().Trim().ToLower());
                txtcompadd1.Text = textInfo.ToTitleCase(Dt.Rows[0]["company_add_1"].ToString().Trim().ToLower());
                txtcompadd2.Text = textInfo.ToTitleCase(Dt.Rows[0]["company_add_2"].ToString().Trim().ToLower());
                txtdesig.Text = textInfo.ToTitleCase(Dt.Rows[0]["designation"].ToString().Trim().ToLower());
                txtphno.Text = Dt.Rows[0]["company_tel_no"].ToString().Trim();
                txtfaxno.Text = Dt.Rows[0]["company_fax_no"].ToString().Trim();
                txtfileno.Text = Dt.Rows[0]["cerpac_file_no"].ToString().Trim();
                txtemailprsn.Text = Dt.Rows[0]["Email1"].ToString().Trim();
                txtcntcnoprsn.Text = Dt.Rows[0]["ContactNo"].ToString().Trim();

                //----------------------------------------------------data from bank--------------------------------------------
                dtbnk = new DataTable();
                string queryforbank = "select * from Uploaded_Excel_Data where FORMNO='" + ApplicationId.ToString().Trim() + "'";
                dtbnk = ObjGenBal.FetchData(queryforbank);
                if (dtbnk.Rows.Count > 0)
                {
                    txtbankfname.Text = dtbnk.Rows[0]["FirstName"].ToString().Trim();
                    txtbanklname.Text = dtbnk.Rows[0]["LastName"].ToString().Trim();
                    // TxtNationalitybank.Text = dtbnk.Rows[0]["NATIONALITY"].ToString().Trim();
                    //TxtFirstName.Text = dtbnk.Rows[0]["FirstName"].ToString().Trim();
                    //TxtLastName.Text = dtbnk.Rows[0]["LastName"].ToString().Trim();
                    // TxtNationality.Text = dtbnk.Rows[0]["NATIONALITY"].ToString().Trim();
                }
                //---------------------------------------------------- end -----------------------------------------------------

                if (Dt.Rows[0]["sex"].ToString().Trim() == "F")
                {
                    TxtSex.Text = "Female";
                }
                else
                {
                    TxtSex.Text = "Male";
                }
                TxtCerpacNo.Text = Dt.Rows[0]["cerpac_no"].ToString().Trim();

                if (Dt.Rows[0]["cerpac_receipt_date"].ToString().Trim() != null || Dt.Rows[0]["cerpac_receipt_date"].ToString().Trim() != "")
                {
                    TxtIssueDate.Text = string.Format("{0:dd/MM/yy}", Dt.Rows[0]["cerpac_receipt_date"]).ToString().Trim();
                    TxtExpDate.Text = string.Format("{0:dd/MM/yy}", Dt.Rows[0]["cerpac_expiry_date"]).ToString().Trim();
                }
                else
                {
                    TxtIssueDate.Text = "-----";
                    TxtExpDate.Text = "-----";
                }

                /* Card Info*/

                lbl_name.Text = textInfo.ToTitleCase((Dt.Rows[0]["forename"].ToString() + " " + Dt.Rows[0]["surname"].ToString()).ToLower());
                lbl_passport.Text = Dt.Rows[0]["passport_no"].ToString().ToUpper();
                lbl_desig.Text = textInfo.ToTitleCase(Dt.Rows[0]["designation"].ToString().ToLower());
                lbl_dob.Text = Dt.Rows[0]["date_of_birth"].ToString();

                lbl_nationality.Text = textInfo.ToTitleCase(Dt.Rows[0]["nationality"].ToString().ToLower());
                lbl_date_of_issue.Text = string.Format("{0:dd/MM/yy}", Dt.Rows[0]["cerpac_receipt_date"]).ToString().Trim();
                lbl_expiry_date.Text = string.Format("{0:dd/MM/yy}", Dt.Rows[0]["cerpac_expiry_date"]).ToString().Trim();


                String cer_no = Dt.Rows[0]["cerpac_no"].ToString().Substring(0, 1).ToUpper() + Dt.Rows[0]["cerpac_no"].ToString().Substring(1);
                lbl_cerpac_no.Text = cer_no;
                lbl_place_of_issue.Text = textInfo.ToTitleCase(zone_c.ToLower());
                /* Card Info*/

                /***************** Fetch Company *********************/
                string queryforcomp = "";
                if (cer_no.Substring(0, 2) == "AO")
                {
                    queryforcomp = "Select company from compmaster where regno = '" + Dt.Rows[0]["company"].ToString() + "'";
                }
                else
                {
                    queryforcomp = "Select company from CompMasterForARCR where regno = '" + Dt.Rows[0]["company"].ToString() + "'";
                }
                DataTable dtcomp = new DataTable();
                ObjGenBal = new BaseLayer.General_function();
                dtcomp = ObjGenBal.FetchData(queryforcomp);
                if (dtcomp.Rows.Count > 0)
                {
                    //  txt_comp.Text = textInfo.ToTitleCase(dtcomp.Rows[0]["company"].ToString().ToLower());
                    txt_comps.Text = textInfo.ToTitleCase(dtcomp.Rows[0]["company"].ToString().ToLower());
                }

                /******************* End Code **********************/

                /************************ Fetch Signature ***************/
                DataTable Dt1 = null;
                Dt1 = new DataTable();
                ObjGenBal = new BaseLayer.General_function();
                DataTable Dt_Auth = null;
                Dt_Auth = new DataTable();

                //string queryforFetchAuth = "SELECT AuthorizedBy from ProdReportCerpacCard1 where cerpacno='" + lbl_cerpac_no.Text + "' and cerpac_file_no='" + Dt.Rows[0]["cerpac_file_no"].ToString() + "'";
                //string queryforFetchAuth = "SELECT top 1 AuthorizedBy from ProdReportCerpacCard1 where cerpacno='" + lbl_cerpac_no.Text + "' and cerpac_file_no='" + Dt.Rows[0]["cerpac_file_no"].ToString() + "' order by AuthorizedBy ";
                string queryforFetchAuth = "SELECT  AuthorizedBy from people a, PeopleChild b where a.cerpac_no=b.CerpacNo and a.cerpac_file_no=b.FORMNO and  b.cerpacno='" + lbl_cerpac_no.Text + "' and b.FORMNO='" + Dt.Rows[0]["cerpac_file_no"].ToString() + "'";

                Dt_Auth = ObjGenBal.FetchData(queryforFetchAuth);
                string queryforcerpac1 = "select * from UserMaster where userid='" + Dt_Auth.Rows[0]["AuthorizedBy"].ToString() + "'";
              
                Dt1 = ObjGenBal.FetchData(queryforcerpac1);
                if (Dt1.Rows.Count > 0)
                {
                    byte[] picData = Dt1.Rows[0]["usersig"] as byte[] ?? null;
                    System.Drawing.Image newImage;
                    if (picData != null)
                    {
                        using (MemoryStream ms = new MemoryStream(picData))
                        {
                            // Load the image from the memory stream. How you do it depends
                            // on whether you're using Windows Forms or WPF.
                            // For Windows Forms you could write:
                            // System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(ms);
                            Bitmap img = (Bitmap)System.Drawing.Image.FromStream(ms);
                            newImage = System.Drawing.Image.FromStream(ms);

                            // if (!File.Exists(Server.MapPath("~") + "/Images/sign/sig.jpg"))
                            newImage.Save(Server.MapPath("~") + "/Images/sign/sig.jpg");
                            // newImage.Save("g:/Saurabh" + Dt.Rows[0]["picture"].ToString().Trim());

                            Bitmap tempImage = new Bitmap(Server.MapPath("~") + "/Images/sign/sig.jpg");
                            tempImage.MakeTransparent();
                            tempImage.Save(Server.MapPath("~") + "/Images/sign/sig.jpg");

                        }
                    }


                    //  ViewState["imagepath"] = Dt.Rows[0]["picture"].ToString().Trim();
                    img_sign.ImageUrl = "~/Images/sign/sig.jpg";
                }
                /******************************End***********************/

                detailtable.Style.Add("display", "");
                warn.Style.Add("display", "none");
            }
            else
            {
                detailtable.Style.Add("display", "none");
                warn.Style.Add("display", "");
                warn.InnerText = "Cerpac Number has not been produced or not exist.";
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


    protected void btnCardOk_Click(object sender, EventArgs e)
    {
        int res = 0;

        try
        {
            BusinessEntityLayer.BalProductionModule objProduction = new BusinessEntityLayer.BalProductionModule();
            objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
            DataTable Dt = null;
            Dt = new DataTable();
            ObjGenBal = new BaseLayer.General_function();

            res = objProduction.UpdateQualityFlag(TxtCerpacNo.Text, Convert.ToInt32(objectSessionHolderPersistingData.User_ID));
            btnCardOk.Visible = false;
            btnCardReject.Visible = false;
            btn_read.Visible = false;
            //---------Insert Into Audit---------

            ObjGenBal.audittype = ENUMAUDITTYPE.Login.GetHashCode().ToString();
            ObjGenBal.userid = objectSessionHolderPersistingData.User_ID;
            ObjGenBal.auditdetail = "Update Printed Flag";
            ObjGenBal.machineIP = Request.UserHostAddress.ToString();
            ObjGenBal.AuditInsert();
            //-----------END---------------------

            if (res == 1)
            {

                confirm.Style.Add("display", "");
                warn.Style.Add("display", "none");
            }
            if (res == 2)
            {
                confirm.Style.Add("display", "none");
                warn.Style.Add("display", "");
                warn.InnerText = "Already Issued";
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

   

    protected void btn_Reason_Print_Click(object sender, EventArgs e)
    {
        int res = 0;
        try
        {
            BusinessEntityLayer.BalProductionModule objProduction = new BusinessEntityLayer.BalProductionModule();
            objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
            DataTable Dt = null;
            Dt = new DataTable();
            ObjGenBal = new BaseLayer.General_function();
            string reason = "";

            if (Rd1.Checked)
                reason = Rd1.Text;
            else if (Rd2.Checked)
                reason = Rd2.Text;
            else if (Rd3.Checked)
                reason = Rd3.Text;
            else
                reason = Rd4.Text;

            if (reason == "")
            {
                confirm.Style.Add("display", "none");
                warn.Style.Add("display", "");
                warn.InnerText = "Please Give Reason First";
                return;
            }

            res = objProduction.UpdateQualityFlagReject(TxtCerpacNo.Text, Convert.ToInt32(objectSessionHolderPersistingData.User_ID), reason);

            //---------Insert Into Audit---------
            // BaseLayer.General_function ObjGenBal = new BaseLayer.General_function();
            ObjGenBal.audittype = ENUMAUDITTYPE.Login.GetHashCode().ToString();
            ObjGenBal.userid = objectSessionHolderPersistingData.User_ID;
            ObjGenBal.auditdetail = "Update Flag in UserStickerRelation";
            ObjGenBal.machineIP = Request.UserHostAddress.ToString();
            ObjGenBal.AuditInsert();
            //-----------END---------------------

            if (res == 1)
            {
                confirm.Style.Add("display", "none");
                warn.Style.Add("display", "");
                warn.InnerText = "Card Rejected";
                btnCardOk.Visible = false;
                btnCardReject.Visible = false;

            }
            if (res == 2)
            {
                confirm.Style.Add("display", "");
                warn.Style.Add("display", "none");
                warn.InnerText = "Already Issued to Candidate";
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
    protected void btnok_Click(object sender, EventArgs e)
    {
        try
        {
            ObjGenBal = new BaseLayer.General_function();
            int status = 0;
            int count = 0;
            int res = 0;
            System.Threading.Thread.Sleep(500);
            foreach (GridViewRow gv in grd_display_data.Rows)
            {
                CheckBox chkGV = (CheckBox)gv.FindControl("CheckBox1");
                if (chkGV.Checked == true)
                {
                    string keyvalue = grd_display_data.DataKeys[gv.RowIndex].Value.ToString();
                    BusinessEntityLayer.BalProductionModule objProduction = new BusinessEntityLayer.BalProductionModule();
                    DataTable Dt = null;
                    Dt = new DataTable();


                    res = res + objProduction.UpdateQualityFlag(keyvalue, Convert.ToInt32(objectSessionHolderPersistingData.User_ID));
                    count = count + 1;

                }

            }
            if (res == count && count >= 1)
            {
                confirm.Style.Add("display", "");
                warn.Style.Add("display", "none");
                tblgrdview.Style.Add("display", "none");
                tblsearch.Style.Add("display", "none");
                lblmsg.Visible = false;

                ObjGenBal.audittype = "10";
                ObjGenBal.userid = objectSessionHolderPersistingData.User_ID;
                ObjGenBal.auditdetail = "Update Printed Flag";
                ObjGenBal.machineIP = Request.UserHostAddress.ToString();
                ObjGenBal.AuditInsert();
            }
            else
            {
                lblmsg.Text = "Please select atleast one record before further processing.";
                lblmsg.CssClass = "warning-box";
                ObjGenBal.audittype = "10";
                ObjGenBal.userid = objectSessionHolderPersistingData.User_ID;
                ObjGenBal.auditdetail = "Update Printed Flag";
                ObjGenBal.machineIP = Request.UserHostAddress.ToString();
                ObjGenBal.AuditInsert();
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

        grd_display_data.PageIndex = e.NewPageIndex;
        Bindlist();
    }
    protected void grd_display_data_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            grd_display_data.EditIndex = e.NewEditIndex;
            string keyvalue = grd_display_data.DataKeys[grd_display_data.EditIndex].Value.ToString();
            TextAppId.Text = keyvalue.ToString();
            grd_display_data.Style.Add("display", "none");
            btnok.Visible = false;
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
    protected void grd_display_data_RowCreated(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[0].Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Cells[1].Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Cells[2].Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Cells[3].Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Cells[4].Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Cells[5].Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Cells[6].Attributes["onmouseover"] = "this.style.cursor='pointer';";

            //  e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
            e.Row.ToolTip = "Click to select row";
            e.Row.Cells[0].Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.grd_display_data, "Select$" + e.Row.RowIndex);
            e.Row.Cells[1].Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.grd_display_data, "Select$" + e.Row.RowIndex);
            e.Row.Cells[2].Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.grd_display_data, "Select$" + e.Row.RowIndex);
            e.Row.Cells[3].Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.grd_display_data, "Select$" + e.Row.RowIndex);
            e.Row.Cells[4].Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.grd_display_data, "Select$" + e.Row.RowIndex);
            e.Row.Cells[5].Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.grd_display_data, "Select$" + e.Row.RowIndex);
            e.Row.Cells[6].Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.grd_display_data, "Select$" + e.Row.RowIndex);

        }
    }
    protected void grd_display_data_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = grd_display_data.SelectedRow;

        objgenenral = new BaseLayer.General_function();
        string quer = "select a.*,b.* from People as a , PeopleChild as b where a.cerpac_no = b.CerpacNo and a.cerpac_no='" + row.Cells[5].Text + "'";
        DataTable dt = new DataTable();
        dt = objgenenral.FetchData(quer);

        GetData(row.Cells[5].Text);

        grd_display_data.Visible = false;

        tblsearch.Style.Add("display", "none");
        btnok.Visible = false;
        tr_msg.Style.Add("display", "none");

    }

    protected void btn_back_Click(object sender, EventArgs e)
    {
        Response.Redirect("QualityCheck.aspx");
    }
    protected void btn_read_Click(object sender, EventArgs e)
    {
        try
        {
            objgenenral = new BaseLayer.General_function();
            SqlConnection Connection = new SqlConnection();
            Connection.ConnectionString = ConfigurationManager.ConnectionStrings["NigeriaConnectionString"].ConnectionString;
            //Process[] result = Process.GetProcessesByName("GoldenReader.exe");
            //if (result.Length > 0)
            //{
            //    return;
            //}
            string IP = System.Web.HttpContext.Current.Request.UserHostAddress;
            string command = "Insert into tbl_production (peopleid,status,ip_add) values (" + 0 + ",2,'" + IP.ToString().Trim() + "')";
            SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.Text, command);
            Thread.Sleep(5000);

            SqlCommand cmd1 = new SqlCommand("Delete from tbl_production where IP_Add = '" + IP + "'", Connection);
            cmd1.ExecuteNonQuery();


            /// <summary>
            /// The connection is closed </summary>
            Connection.Close();
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
}