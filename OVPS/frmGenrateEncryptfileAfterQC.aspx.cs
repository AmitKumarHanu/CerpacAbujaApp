﻿using System;
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


public partial class Admin_frmGenrateEncryptfileAfterQC : System.Web.UI.Page
{
    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    BaseLayer.General_function objgenenral = null;
    protected DataSet objDs = new DataSet();
    protected DataTable dt = new DataTable();
    protected DataTable dtform = new DataTable();
    protected DataTable dtPeople = new DataTable();
    protected DataTable dtPeopleChild = new DataTable();
    protected DataTable dtUploadExcel = new DataTable();
    protected DataTable dtCerpacOutOne = new DataTable();

    protected BaseLayer.General_function ObjGenBal = null;
    string AppID = "", Cerptxt = "", CerpFiletxt="";
    string UserID = null, ZoneDetails = null, output;
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
              // divbrowsefile.Visible = false;
                divSearchResult.Visible = true;
                divgrd.Visible = true;
                divCrefile.Visible = true;
                lblZonename.Text = ZoneDetails;
                BindGird();
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

    protected void BindGird()
    {
        try
        {
            

                objgenenral = new BaseLayer.General_function();
                //string quer = "Select Distinct( a.cerpac_no) as dist , a.forename ,a.middle_name ,a.surname  ,a.cerpac_no ,a.cerpac_file_no ,Convert(varchar(11), a.cerpac_receipt_date, 103) as cerpac_receipt_date , Convert(varchar(11), a.cerpac_expiry_date, 103) as cerpac_expiry_date, passport_no ,nationality ,Convert(varchar(11), a.date_of_birth, 103) as date_of_birth ,a.place_of_birth ,c.company, a.designation  from people a , PeopleChild b, compmaster c where a.company = c.regno and a.cerpac_no=b.CerpacNo and a.cerpac_file_no= b.FORMNO and  a.cerpac_no in ('" + txtAppId.Text.Replace(",", "','") + "') and b.IsVerified=1 and b.IsAuthorized=1 and b.ISARCR=1 and b.IsProduced<>4 and b.IsQual=0 and isnull(b.IsBrown,0)=0 and isnull( b.IsRejected,0 )=0";
                string quer = "Select Distinct( a.cerpac_no) as dist , a.forename ,a.middle_name ,a.surname  ,a.cerpac_no ,a.cerpac_file_no ,Convert(varchar(11), a.cerpac_receipt_date, 103) as cerpac_receipt_date , Convert(varchar(11), a.cerpac_expiry_date, 103) as cerpac_expiry_date, a.passport_no , a.nationality ,Convert(varchar(11), a.date_of_birth, 103) as date_of_birth ,a.place_of_birth ,c.company, a.designation From people a, PeopleChild b, CompMaster c where a.cerpac_no=b.CerpacNo and a.company=c.regno and b.IsVerified=1 and b.IsAuthorized=1 and b.ISARCR=1 and b.IsProduced=1 and b.IsQual=1 and isnull( b.IsRejected,0 )=0 and b.FORMNO  in (Select formno from uploaded_excel_data_C where isnull (final_flag,0)=0)";
                dtform = objgenenral.FetchData(quer);
                if (dtform.Rows.Count > 0)
                {
                    
                        grd_display_data.DataSource = dtform;
                        grd_display_data.DataBind();

                        for (int i = 0; i < dtform.Rows.Count; i++)
                        {
                            Cerptxt = Cerptxt + dtform.Rows[i].ItemArray[0].ToString() + ",";

                        }
                        //string source = txt;
                    
                    ViewState["CerpacList"] = Cerptxt;

                    dtform = null;

                    string querformno = "Select b.formno From people a, PeopleChild b where a.cerpac_no=b.CerpacNo and b.IsVerified=1 and b.IsAuthorized=1 and b.ISARCR=1 and b.IsProduced=1 and b.IsQual=1 and isnull( b.IsRejected,0 )=0 and b.FORMNO  in (Select formno from uploaded_excel_data_C where isnull (final_flag,0)=0)";
                    dtform = objgenenral.FetchData(querformno);
                    if (dtform.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtform.Rows.Count; i++)
                        {
                            CerpFiletxt = CerpFiletxt + dtform.Rows[i].ItemArray[0].ToString() + ",";

                        }
                    }
                    int count = 0;
                    ViewState["FRNList"] = CerpFiletxt;


                    int AO = Regex.Matches(Cerptxt.ToString(), "AO").Count;
                    int AR = Regex.Matches(Cerptxt.ToString(), "AR").Count;
                    int CR = Regex.Matches(Cerptxt.ToString(), "CR").Count;
                    int NG = Regex.Matches(Cerptxt.ToString(), "NG").Count;


                    count = (AO + AR + CR + NG);
                    lblAOCerpacNo.Text = AO.ToString();
                    lblARCerpacNo.Text = AR.ToString();
                    lblCRCerpacNo.Text = CR.ToString();

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('We does not have any records after quality for distribution !!');", true);

                    dtform = null;
                    divgrd.Visible = false;
                    divCrefile.Visible = false;
                    //Response.Redirect("frmGenrateConsolidateEncryptfile.aspx");
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
    protected void btnEncrypt_Click(object sender, EventArgs e)
    {
        
        string xmlfilename = "default.xml";
        string foldername = "QCF-" + ZoneDetails + "-" + DateTime.Now.ToString().Replace("/", "").Replace(":", "");
        string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        filePath = filePath + @"\";

        //if ( lblTotalRequest.Text != "0")
        //{

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            //-----------------------Create File After Quality---------------------------
            xmlfilename = "QCF-" + ZoneDetails + "-" + DateTime.Now.Date.ToString("dd/MM/yyyy").Replace("/", "").Replace(":", "") + "-" + DateTime.Now.ToLocalTime().ToLongTimeString().Replace(" ", "").Replace(":", ".") + ".xml";

            if (File.Exists(Path.Combine(filePath, filePath + @"\" + xmlfilename.ToString().Trim())))
            {
                File.Delete(Path.Combine(filePath, filePath + @"\" + xmlfilename.ToString().Trim()));
            }

            System.IO.StreamWriter s = File.CreateText(System.IO.Path.Combine(filePath, filePath + @"\" + xmlfilename.ToString().Trim()));


            try
            {
                string txtRecords = "-###-";
                //------------------Write textbox serach result in the text file--------------
                s.WriteLine("ZoneName \t" + ZoneDetails);
                s.WriteLine("CerpacNo \t" + ViewState["CerpacList"].ToString().Trim());
                s.WriteLine("FormNo \t" + ViewState["FRNList"].ToString().Trim());

                //--------------------------People table---------------------------------------
                objgenenral = new BaseLayer.General_function();

                string QurPeople = "SELECT people_id , title , forename , middle_name , surname , sex , residence_permit_no , residence_issue_loc , deedmark_no ,  printed ," +
                " label_print_count , card_print_count , picture , directory , notes , cerpac_no , formno as cerpac_file_no , People.cerpac_receipt_date , People.cerpac_expiry_date , registration_area ," +
                " registration_code , file_no , label_no , book_no , passport_no , nationality , passport_issue_date , passport_expiry_date , passport_issue_loc , passport_issue_by ," +
                " date_of_birth , place_of_birth , nigeria_add_1 , nigeria_add_2 , nigeria_tel_no , abroad_add_1 , abroad_add_2 , abroad_tel_no , company , company_add_1 ," +
                " company_add_2  , designation , employment_date , company_tel_no , company_fax_no , People.email , date_added , added_by_user_id , date_modified , modified_by_user_id ," +
                " picture_taken , picture_by_user_id , verid_template , verid_template_1 , arcanet_2d_command , date_system_modified , People.ContactNo " +
                " FROM  People, PeopleChild where People.cerpac_no=PeopleChild.CerpacNo and formno in ('" + ViewState["FRNList"].ToString().Trim(',').Replace(",", "','") + "')";
                dtPeople = objgenenral.FetchData(QurPeople);


                for (int i = 0; i <= dtPeople.Rows.Count - 1; i++)
                {
                    txtRecords = txtRecords + dtPeople.Rows[i].ItemArray[0].ToString().Trim() + " \t " + dtPeople.Rows[i].ItemArray[1].ToString().Trim() + " \t " + dtPeople.Rows[i].ItemArray[2].ToString().Trim() + " \t " + dtPeople.Rows[i].ItemArray[3].ToString().Trim() + " \t " + dtPeople.Rows[i].ItemArray[4].ToString().Trim() + " \t " + dtPeople.Rows[i].ItemArray[5].ToString().Trim() + " \t " + dtPeople.Rows[i].ItemArray[6].ToString().Trim() + " \t " + dtPeople.Rows[i].ItemArray[7].ToString().Trim() + " \t " + dtPeople.Rows[i].ItemArray[8].ToString().Trim() + " \t " + dtPeople.Rows[i].ItemArray[9].ToString().Trim() + "\t"
                         + dtPeople.Rows[i].ItemArray[10].ToString().Trim() + " \t " + dtPeople.Rows[i].ItemArray[11].ToString().Trim() + " \t " + dtPeople.Rows[i].ItemArray[12].ToString().Trim() + " \t " + dtPeople.Rows[i].ItemArray[13].ToString().Trim() + " \t " + dtPeople.Rows[i].ItemArray[14].ToString().Trim() + " \t " + dtPeople.Rows[i].ItemArray[15].ToString().Trim() + " \t " + dtPeople.Rows[i].ItemArray[16].ToString().Trim() + " \t " + dtPeople.Rows[i].ItemArray[17].ToString().Trim() + " \t " + dtPeople.Rows[i].ItemArray[18].ToString().Trim() + " \t " + dtPeople.Rows[i].ItemArray[19].ToString().Trim() + "\t"
                         + dtPeople.Rows[i].ItemArray[20].ToString().Trim() + " \t " + dtPeople.Rows[i].ItemArray[21].ToString().Trim() + " \t " + dtPeople.Rows[i].ItemArray[22].ToString().Trim() + " \t " + dtPeople.Rows[i].ItemArray[23].ToString().Trim() + " \t " + dtPeople.Rows[i].ItemArray[24].ToString().Trim() + " \t " + dtPeople.Rows[i].ItemArray[25].ToString().Trim() + " \t " + dtPeople.Rows[i].ItemArray[26].ToString().Trim() + " \t " + dtPeople.Rows[i].ItemArray[27].ToString().Trim() + " \t " + dtPeople.Rows[i].ItemArray[28].ToString().Trim() + " \t " + dtPeople.Rows[i].ItemArray[29].ToString().Trim() + "\t"
                         + dtPeople.Rows[i].ItemArray[30].ToString().Trim() + " \t " + dtPeople.Rows[i].ItemArray[31].ToString().Trim() + " \t " + dtPeople.Rows[i].ItemArray[32].ToString().Trim() + " \t " + dtPeople.Rows[i].ItemArray[33].ToString().Trim() + " \t " + dtPeople.Rows[i].ItemArray[34].ToString().Trim() + " \t " + dtPeople.Rows[i].ItemArray[35].ToString().Trim() + " \t " + dtPeople.Rows[i].ItemArray[36].ToString().Trim() + " \t " + dtPeople.Rows[i].ItemArray[37].ToString().Trim() + " \t " + dtPeople.Rows[i].ItemArray[38].ToString().Trim() + " \t " + dtPeople.Rows[i].ItemArray[39].ToString().Trim() + "\t"
                         + dtPeople.Rows[i].ItemArray[40].ToString().Trim() + " \t " + dtPeople.Rows[i].ItemArray[41].ToString().Trim() + " \t " + dtPeople.Rows[i].ItemArray[42].ToString().Trim() + " \t " + dtPeople.Rows[i].ItemArray[43].ToString().Trim() + " \t " + dtPeople.Rows[i].ItemArray[44].ToString().Trim() + " \t " + dtPeople.Rows[i].ItemArray[45].ToString().Trim() + " \t " + dtPeople.Rows[i].ItemArray[46].ToString().Trim() + " \t " + dtPeople.Rows[i].ItemArray[47].ToString().Trim() + " \t " + dtPeople.Rows[i].ItemArray[48].ToString().Trim() + " \t " + dtPeople.Rows[i].ItemArray[49].ToString().Trim() + "\t"
                         + dtPeople.Rows[i].ItemArray[50].ToString().Trim() + " \t " + dtPeople.Rows[i].ItemArray[51].ToString().Trim() + " \t " + dtPeople.Rows[i].ItemArray[52].ToString().Trim() + " \t " + dtPeople.Rows[i].ItemArray[53].ToString().Trim() + " \t " + dtPeople.Rows[i].ItemArray[54].ToString().Trim() + " \t " + dtPeople.Rows[i].ItemArray[55].ToString().Trim() + " \t " + dtPeople.Rows[i].ItemArray[56].ToString().Trim() + " -###- ";
                    //+dtPeople.Rows[i].ItemArray[58].ToString().Trim() + " \t " + dtPeople.Rows[i].ItemArray[59].ToString().Trim() + "\t";
                    //+ dtPeople.Rows[i].ItemArray[60].ToString().Trim() + " \t ";
                }
                s.WriteLine(txtRecords.Replace(",", " "));
                //---------------------PeopleChild---------------------------------------------
                string txtPeopleChild = "-###-";
                string QurPeopleChild = "SELECT  Date1 , Branch , RequisitionNO , PassportNo , FORMNO , TELLERNO , AMOUNT , CerpacNo , StrVisaNo , b.ContactNo , " +
             " b.Email , CreatedBY , CreatedON , MOdifiedBY , ModifiedOn , IsVerified , IsAuthorized , IsProduced , VerifiedBy , AuthorizedBy ," +
             " ProducedBy , ProducedOn , AuthorizedOn , VerifiedOn , IsRejected , RejectedBy , RejectedOn , RejectionReason , ZoneNote , AuthNote ," +
             " ProdNote , QualNote , IsDependent , DesignationCode , DependentOn , ISARCR , ConfirmedBy , ConfirmedOn , b.cerpac_expiry_date , b.cerpac_receipt_date ," +
             " IsQual , QualBy , QualOn , BrownOn , BrownBY , IsBrown , IsStickerPrinted , StickerPrintedBy , StickerPrintedOn , StickerNumber ," +
             " up_f FROM PeopleChild b where formno in ('" + ViewState["FRNList"].ToString().Trim(',').Replace(",", "','") + "') and b.IsVerified=1 and b.IsAuthorized=1 and b.ISARCR=1 and b.IsProduced=1 and b.IsQual=1 and isnull(b.IsBrown,0)=0 and isnull( b.IsRejected,0 )=0";

                dtPeopleChild = objgenenral.FetchData(QurPeopleChild);

                for (int i = 0; i <= dtPeopleChild.Rows.Count - 1; i++)
                {
                    txtPeopleChild = txtPeopleChild + dtPeopleChild.Rows[i].ItemArray[0].ToString().Trim() + " \t " + dtPeopleChild.Rows[i].ItemArray[1].ToString().Trim() + " \t " + dtPeopleChild.Rows[i].ItemArray[2].ToString().Trim() + " \t " + dtPeopleChild.Rows[i].ItemArray[3].ToString().Trim() + " \t " + dtPeopleChild.Rows[i].ItemArray[4].ToString().Trim() + " \t " + dtPeopleChild.Rows[i].ItemArray[5].ToString().Trim() + " \t " + dtPeopleChild.Rows[i].ItemArray[6].ToString().Trim() + " \t " + dtPeopleChild.Rows[i].ItemArray[7].ToString().Trim() + " \t " + dtPeopleChild.Rows[i].ItemArray[8].ToString().Trim() + " \t " + dtPeopleChild.Rows[i].ItemArray[9].ToString().Trim() + "\t"
                         + dtPeopleChild.Rows[i].ItemArray[10].ToString().Trim() + " \t " + dtPeopleChild.Rows[i].ItemArray[11].ToString().Trim() + " \t " + dtPeopleChild.Rows[i].ItemArray[12].ToString().Trim() + " \t " + dtPeopleChild.Rows[i].ItemArray[13].ToString().Trim() + " \t " + dtPeopleChild.Rows[i].ItemArray[14].ToString().Trim() + " \t " + dtPeopleChild.Rows[i].ItemArray[15].ToString().Trim() + " \t " + dtPeopleChild.Rows[i].ItemArray[16].ToString().Trim() + " \t " + dtPeopleChild.Rows[i].ItemArray[17].ToString().Trim() + " \t " + dtPeopleChild.Rows[i].ItemArray[18].ToString().Trim() + " \t " + dtPeopleChild.Rows[i].ItemArray[19].ToString().Trim() + "\t"
                         + dtPeopleChild.Rows[i].ItemArray[20].ToString().Trim() + " \t " + dtPeopleChild.Rows[i].ItemArray[21].ToString().Trim() + " \t " + dtPeopleChild.Rows[i].ItemArray[22].ToString().Trim() + " \t " + dtPeopleChild.Rows[i].ItemArray[23].ToString().Trim() + " \t " + dtPeopleChild.Rows[i].ItemArray[24].ToString().Trim() + " \t " + dtPeopleChild.Rows[i].ItemArray[25].ToString().Trim() + " \t " + dtPeopleChild.Rows[i].ItemArray[26].ToString().Trim() + " \t " + dtPeopleChild.Rows[i].ItemArray[27].ToString().Trim() + " \t " + dtPeopleChild.Rows[i].ItemArray[28].ToString().Trim() + " \t " + dtPeopleChild.Rows[i].ItemArray[29].ToString().Trim() + "\t"
                         + dtPeopleChild.Rows[i].ItemArray[30].ToString().Trim() + " \t " + dtPeopleChild.Rows[i].ItemArray[31].ToString().Trim() + " \t " + dtPeopleChild.Rows[i].ItemArray[32].ToString().Trim() + " \t " + dtPeopleChild.Rows[i].ItemArray[33].ToString().Trim() + " \t " + dtPeopleChild.Rows[i].ItemArray[34].ToString().Trim() + " \t " + dtPeopleChild.Rows[i].ItemArray[35].ToString().Trim() + " \t " + dtPeopleChild.Rows[i].ItemArray[36].ToString().Trim() + " \t " + dtPeopleChild.Rows[i].ItemArray[37].ToString().Trim() + " \t " + dtPeopleChild.Rows[i].ItemArray[38].ToString().Trim() + " \t " + dtPeopleChild.Rows[i].ItemArray[39].ToString().Trim() + "\t"
                         + dtPeopleChild.Rows[i].ItemArray[40].ToString().Trim() + " \t " + dtPeopleChild.Rows[i].ItemArray[41].ToString().Trim() + " \t " + dtPeopleChild.Rows[i].ItemArray[42].ToString().Trim() + " \t " + dtPeopleChild.Rows[i].ItemArray[43].ToString().Trim() + " \t " + dtPeopleChild.Rows[i].ItemArray[44].ToString().Trim() + " \t " + dtPeopleChild.Rows[i].ItemArray[45].ToString().Trim() + " \t " + dtPeopleChild.Rows[i].ItemArray[46].ToString().Trim() + " \t " + dtPeopleChild.Rows[i].ItemArray[47].ToString().Trim() + " \t " + dtPeopleChild.Rows[i].ItemArray[48].ToString().Trim() + " \t " + dtPeopleChild.Rows[i].ItemArray[49].ToString().Trim() + "\t"
                         + dtPeopleChild.Rows[i].ItemArray[50].ToString().Trim() + " -###- ";
                    //+dtPeopleChild.Rows[i].ItemArray[51].ToString().Trim() + " \t " + dtPeopleChild.Rows[i].ItemArray[52].ToString().Trim() + " \t " + dtPeopleChild.Rows[i].ItemArray[53].ToString().Trim() + " \t " + dtPeopleChild.Rows[i].ItemArray[54].ToString().Trim() + " \t " + dtPeopleChild.Rows[i].ItemArray[55].ToString().Trim() + " \t " + dtPeopleChild.Rows[i].ItemArray[56].ToString().Trim() + " \t " + dtPeopleChild.Rows[i].ItemArray[57].ToString().Trim() + " -###- ";
                    //+dtPeopleChild.Rows[i].ItemArray[58].ToString().Trim() + " \t " + dtPeopleChild.Rows[i].ItemArray[59].ToString().Trim() + "\t";
                    //+ dtPeople.Rows[i].ItemArray[60].ToString().Trim() + " \t ";
                }
                s.WriteLine(txtPeopleChild);

                //--------------------Cerpac_Out_One------------------------------------------
                string txtCerpac_Out_One = "-###-";

                string QurCerpacOutOne = "SELECT c.CerpacNo_OutID , c.cerpac_no , c.CardIssueDate , c.CardNo , c.ZoneCode , c.StickerPrintedYN , c.StickerWastedYN , c.UserId , c.StickerWastedReason , c.cerpac_file_no " +
               "FROM  people a, PeopleChild b , CerpacNo_Out_One c where a.cerpac_no=b.CerpacNo and a.cerpac_no= c.cerpac_no " +
               "and b.FORMNO = c.cerpac_file_no " +
               "and b.IsVerified=1 and b.IsAuthorized=1 and b.isQual=1 and b.ISARCR=1 and b.IsProduced=1    and isnull(b.IsBrown,0)=0 and isnull( b.IsRejected,0 )=0 " +
               "and a.cerpac_no in ('" + ViewState["FRNList"].ToString().Trim().Replace(",", "','") + "')";

                dtCerpacOutOne = objgenenral.FetchData(QurCerpacOutOne);


                for (int i = 0; i <= dtCerpacOutOne.Rows.Count - 1; i++)
                {
                    txtCerpac_Out_One = txtCerpac_Out_One + dtCerpacOutOne.Rows[i].ItemArray[0].ToString().Trim() + " \t " + dtCerpacOutOne.Rows[i].ItemArray[1].ToString().Trim() + " \t " + dtCerpacOutOne.Rows[i].ItemArray[2].ToString().Trim() + " \t " + dtCerpacOutOne.Rows[i].ItemArray[3].ToString().Trim() + " \t " + dtCerpacOutOne.Rows[i].ItemArray[4].ToString().Trim() + " \t " + dtCerpacOutOne.Rows[i].ItemArray[5].ToString().Trim() + " \t " + dtCerpacOutOne.Rows[i].ItemArray[6].ToString().Trim() + " \t " + dtCerpacOutOne.Rows[i].ItemArray[7].ToString().Trim() + " \t " + dtCerpacOutOne.Rows[i].ItemArray[8].ToString().Trim() + " \t " + dtCerpacOutOne.Rows[i].ItemArray[9].ToString().Trim() + "-###-";

                }
                s.WriteLine(txtCerpac_Out_One);


                //----------------------Upload_excel_Data--------------------------------------
                string txtUploadExcelData = "-###-";

                //objgenenral = new BaseLayer.General_function();

                string QurUploadexcel = "SELECT FORMNO,CerpacNo   FROM Uploaded_Excel_Data where  Formno in ('" + ViewState["FRNList"].ToString().Trim().Replace(",", "','") + "')";

                dtUploadExcel = objgenenral.FetchData(QurUploadexcel);

                for (int i = 0; i <= dtUploadExcel.Rows.Count - 1; i++)
                {
                    txtUploadExcelData = txtUploadExcelData + dtUploadExcel.Rows[i].ItemArray[0].ToString().Trim() + " \t " + dtUploadExcel.Rows[i].ItemArray[1].ToString().Trim() + " -###- ";

                }
                s.WriteLine(txtUploadExcelData);

                dtform = null;

                s.Dispose();



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

                //String source = ViewState["FRNList"].ToString().Trim();
                //string[] stringSeparators = new string[] { "," };
                //var result = source.Split(stringSeparators, StringSplitOptions.None);
                //int loop=0;
                //for (int i = 0; i < result.Count() - 1; i++)
                //{
                //    string formno = result[i].ToString().Trim();
                //    result[i] = formno;
                //    if (result[i].ToString().Substring(0, 2).Trim() == "AO" || result[i].ToString().Substring(0, 2).Trim() == "AR" || result[i].ToString().Substring(0, 2).Trim() == "CR" || result[i].ToString().Substring(0, 2).Trim() == "NG")
                //    {
                //        //-----------------Search in Upload excel data C table--------------------
                //        ObjGenBal = new BaseLayer.General_function();
                //        string QuerCountFound = "select count(*) from uploaded_excel_data_C where  Formno='" + result[i].ToString().Trim() + "'";

                //        DataTable dt = new DataTable();
                //        dt = ObjGenBal.FetchData(QuerCountFound);
                //        if (dt.Rows[0].ItemArray[0].ToString() != "0")
                //        {

                //            //--------------------------Insert--------------------------------   

                //            SqlConnection Connection = new SqlConnection();
                //            Connection.ConnectionString = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;


                //            SqlCommand Command = new SqlCommand("Update uploaded_excel_data_C set Final_flag=1, resuserid='" + UserID.ToString().Trim() + "', response_date='" + date.ToString(sysFormat)  + "' where formno ='" + result[i].ToString().Trim() + "'", Connection);
                //            Connection.Open();
                //            Command.ExecuteNonQuery();
                //            Connection.Close();
                //            loop++;
                //        }


                //    }
                //}


                //Saurabh Code
                SqlConnection Connection = new SqlConnection();
                Connection.ConnectionString = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;

                if (DateTimeFormatInfo.CurrentInfo.ShortDatePattern.ToCharArray()[0].ToString() == "d")
                {
                    sysFormat = "MM-dd-yyyy";
                }
                SqlCommand Command = new SqlCommand("Update uploaded_excel_data_C set Final_flag=1, resuserid='" + UserID.ToString().Trim() + "', response_date='" + date.ToString(sysFormat) + "' where formno in ('" + ViewState["FRNList"].ToString().Trim(',').Replace(",", "','") + "')", Connection);
                Connection.Open();
                Command.ExecuteNonQuery();
                Connection.Close();



                    //----------------------------------------------
                   // if (result.Count() - 1 == loop)
                    {
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
                            //------------------Create Encrypted File for Client----------------
                            File.Delete(input);
                          
                            System.IO.FileStream fs = null;
                            fs = System.IO.File.Open(output, System.IO.FileMode.Open);
                            byte[] btFile = new byte[fs.Length];
                            fs.Read(btFile, 0, Convert.ToInt32(fs.Length));
                            fs.Close();

                            File.Delete(output);

                            txtfilename.Value = xmlfilename.ToString().Trim();
                           

                            Response.AddHeader("Content-disposition", "attachment; filename=" + xmlfilename.ToString().Trim());
                            Response.ContentType = "application/octet-stream";
                            Response.BinaryWrite(btFile);
                            Response.End();


                          
                            

                            //Response.End();
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
                objgenenral = null;
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