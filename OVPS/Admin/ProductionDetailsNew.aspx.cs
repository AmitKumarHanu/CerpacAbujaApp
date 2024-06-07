using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ProductionDetailsNew : System.Web.UI.Page
{

    private int m_currentPageIndex;
    private IList<Stream> m_streams;

    DataTable ds = new DataTable();
    string zone_c = "";
    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    BaseLayer.General_function objgenenral = null;
    BaseLayer.General_function ObjGeneral = null;
    protected BaseLayer.General_function ObjGenBal = null;

    Label LabelMessage = null;

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (Session["card"] == null)
        {
            Response.Redirect("../Login.aspx");
        }

        

        //-----------------------------------------for disabling the hyperlink ------------------------------
        TreeView tvr = (TreeView)this.Page.Master.FindControl("TVLeftMenu");
        tvr.Visible = false;
        HyperLink hyp = (HyperLink)this.Page.Master.FindControl("hypHome");
        //  hyp.Attributes.Add("onclick", "if(!confirm('Are you sure you want to go to home page')) return false;");
        //-----------------------------------------------end ---------------------------------------------------


        ds = (DataTable)Session["Card"];
        LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");

        if (!IsPostBack)
        {
            ObjGeneral = new BaseLayer.General_function();
            objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];

            if (objectSessionHolderPersistingData == null)
            {
                Response.Redirect("../Login.aspx");
            }

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
           
            bindreport();

            DivPrintSameCard.Visible = false;
            DivWastedCard.Visible = false;
            DivCardPrint.Visible = false;


            if (ds.Rows[0]["IsProduced"].ToString() == "0" || ds.Rows[0]["IsProduced"].ToString() == null)
            {
                btn_ok.Visible = true;
                btnCardPrintSuccess.Visible = false;
                btnRePrintCard.Visible = false;
                btnWastedCard.Visible = false;
                btn_print_cond3.Visible = false;
            }

            if (ds.Rows[0]["IsProduced"].ToString() == "1")
            {
                btn_print_cond3.Visible = false;
                btnCardPrintSuccess.Visible = false;
                btnRePrintCard.Visible = false;
                btnWastedCard.Visible = false;                
                btn_ok.Visible = false;
                DivAlreadyPrintCard.Visible = true;
            }

            else if (ds.Rows[0]["IsProduced"].ToString() == "2")
            {
                btn_ok.Visible = false;
                btn_print_cond3.Visible = false;
                btnCardPrintSuccess.Visible = true;
                btnRePrintCard.Visible = true;
                btnWastedCard.Visible = true;
            }

            else if (ds.Rows[0]["IsProduced"].ToString() == "3")
            {
               
                btn_print_cond3.Visible = false;
                btnCardPrintSuccess.Visible = false;               
                btnRePrintCard.Visible = false;
                btnWastedCard.Visible = false;
                btn_ok.Visible = true;
            }
            else if (ds.Rows[0]["IsProduced"].ToString() == "4")
            {
                btn_ok.Visible = false;
                btn_print_cond3.Visible = false;
                btnCardPrintSuccess.Visible = false;
                btnRePrintCard.Visible = false;
                btnWastedCard.Visible = false;
                DivPrintSameCard.Visible = true;  
            }

            else
            {
                
                div_load.InnerHtml = "Chip Encoding In Progress......Please wait......";
                div_load.Attributes.Add("class", "loading");
                div_load.Style.Add("border", " ");
                div_load.Style.Add("background-color", " ");
               // div_load.InnerHtml = " <img src='../Images/load.gif' alt='' />";
            }
        }




        int res = 0;
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        ObjGenBal = new BaseLayer.General_function();
        BusinessEntityLayer.BalProductionModule objProduction = new BusinessEntityLayer.BalProductionModule();
        ObjGenBal.userid = objectSessionHolderPersistingData.User_ID;
       
    }

    //-----------------Fetch Printing Data by Database--------------------
    protected void bindreport()
    {
        ObjGeneral = new BaseLayer.General_function();
        DataTable dt = new DataTable();
        string query = "SELECT * from ProdReportCerpacCard";

        CultureInfo c = Thread.CurrentThread.CurrentCulture;
        TextInfo textInfo = c.TextInfo;
        try
        {
            dt = ObjGeneral.FetchData(query);
            //if (dt.Rows.Count > 0)
            if (ds.Rows.Count > 0)
            {

            

                ImgPhoto.ImageUrl = "~/Images/Logo/" + ds.Rows[0]["picture"].ToString().Trim();
                lbl_name.Text = textInfo.ToTitleCase((ds.Rows[0]["forename"].ToString() + " " + ds.Rows[0]["surname"].ToString()).ToLower());
                lbl_passport.Text = ds.Rows[0]["passport_no"].ToString().ToUpper();

                lbl_desig.Text = textInfo.ToTitleCase((ds.Rows[0]["designation"].ToString()).ToLower());
                lbl_dob.Text = string.Format("{0:d-MM-yyyy}", ds.Rows[0]["date_of_birth"]).ToString().Trim();
                // ConvertDate(TxtIssueDate.Text.ToString(), "d-MM-yyyy")
                lbl_nationality.Text = textInfo.ToTitleCase((ds.Rows[0]["nationality"].ToString()).ToLower());
                lbl_date_of_issue.Text = string.Format("{0:d-MM-yyyy}", ds.Rows[0]["cerpac_receipt_date"]).ToString().Trim();
                lbl_expiry_date.Text = string.Format("{0:d-MM-yyyy}", ds.Rows[0]["cerpac_expiry_date"]).ToString();

                String cer_no = ds.Rows[0]["cerpac_no"].ToString().Substring(0, 1).ToUpper() + ds.Rows[0]["cerpac_no"].ToString().Substring(1);

                lbl_cerpac_no.Text = cer_no;
                // lbl_place_of_issue.Text = textInfo.ToTitleCase((ds.Rows[0]["passport_issue_loc"].ToString()).ToLower());
                Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
                // lbl_place_of_issue.Text = textInfo.ToTitleCase((zone_c).ToLower());
                lbl_place_of_issue.Text = zone_c.ToUpper();
                //Actual Card Parameters

                txt_pass_no.Text = ds.Rows[0]["passport_no"].ToString().ToUpper();
                txt_name_1.Text = textInfo.ToTitleCase((ds.Rows[0]["forename"].ToString() + " " + ds.Rows[0]["surname"].ToString()).ToLower());
                txt_dob_2.Text = string.Format("{0:d-MM-yyyy}", ds.Rows[0]["date_of_birth"]).ToString().Trim();

                //string.Format("{0:d-MM-yyyy}", Dt.Rows[0]["passport_expiry_date"]).ToString().Trim();
                txt_desig_3.Text = textInfo.ToTitleCase((ds.Rows[0]["designation"].ToString()).ToLower());
                txt_nationality_4.Text = textInfo.ToTitleCase((ds.Rows[0]["nationality"].ToString()).ToLower());
                ImgPhoto2.Src = "~/Images/Logo/" + ds.Rows[0]["picture"].ToString().Trim();
                txt_cer_no_5.Text = cer_no;
                txt_date_of_issue_6.Text = string.Format("{0:d-MM-yyyy}", ds.Rows[0]["cerpac_receipt_date"]).ToString().Trim();
                // txt_place_of_issue_7.Text = textInfo.ToTitleCase((ds.Rows[0]["passport_issue_loc"].ToString()).ToLower());

                txt_place_of_issue_7.Text = textInfo.ToTitleCase((zone_c).ToUpper());
                txt_date_of_exp_8.Text = string.Format("{0:d-MM-yyyy}", ds.Rows[0]["cerpac_expiry_date"]).ToString().Trim();

               


                /***************** Fetch Company *********************/
                string queryforcomp = "";
                if (cer_no.Substring(0, 2) == "AO")
                {
                    queryforcomp = "Select company from compmaster where regno = '" + ds.Rows[0]["company"].ToString() + "'";
                }
                else
                {
                    queryforcomp = "Select company from CompMasterForARCR where regno = '" + ds.Rows[0]["company"].ToString() + "'";
                }
                DataTable dtcomp = new DataTable();
                ObjGenBal = new BaseLayer.General_function();
                dtcomp = ObjGenBal.FetchData(queryforcomp);
                if (dtcomp.Rows.Count > 0)
                {
                    txt_comp.Text = textInfo.ToTitleCase(dtcomp.Rows[0]["company"].ToString().ToLower());
                    txt_comps.Text = textInfo.ToTitleCase(dtcomp.Rows[0]["company"].ToString().ToLower());
                }

                /******************* End Code **********************/



            }

            /************************ Fetch Signature ***************/
            DataTable Dt = null;
            Dt = new DataTable();
            ObjGenBal = new BaseLayer.General_function();
            DataTable Dt_Auth = null;
            Dt_Auth = new DataTable();

            string queryforFetchAuth = "SELECT  AuthorizedBy from people a, PeopleChild b where a.cerpac_no=b.CerpacNo and a.cerpac_file_no=b.FORMNO and  b.cerpacno='" + lbl_cerpac_no.Text + "' and b.FORMNO='" + ds.Rows[0]["cerpac_file_no"].ToString() + "'";

            Dt_Auth = ObjGenBal.FetchData(queryforFetchAuth);
            string queryforcerpac = "select * from UserMaster where userid='" + Dt_Auth.Rows[0]["AuthorizedBy"].ToString() + "'";


            //string queryforFetchAuth = "SELECT AuthorizedBy from ProdReportCerpacCard where cerpacno='" + lbl_cerpac_no.Text + "' and cerpac_file_no='" + ds.Rows[0]["cerpac_file_no"].ToString() + "'";
            //Dt_Auth = ObjGenBal.FetchData(queryforFetchAuth);
            //string queryforcerpac = "select * from UserMaster where userid='" + Dt_Auth.Rows[0]["AuthorizedBy"].ToString() + "'";


            Dt = ObjGenBal.FetchData(queryforcerpac);
            if (Dt.Rows.Count > 0)
            {
                byte[] picData = Dt.Rows[0]["usersig"] as byte[] ?? null;
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

                        //  if (!File.Exists(Server.MapPath("~") + "/Images/sign/sig.jpg"))
                        newImage.Save(Server.MapPath("~") + "/Images/sign/sig.jpg");
                        // newImage.Save("g:/Saurabh" + Dt.Rows[0]["picture"].ToString().Trim());

                        Bitmap tempImage = new Bitmap(Server.MapPath("~") + "/Images/sign/sig.jpg");
                        tempImage.MakeTransparent();
                        tempImage.Save(Server.MapPath("~") + "/Images/sign/sig.jpg");
                    }
                }


                //  ViewState["imagepath"] = Dt.Rows[0]["picture"].ToString().Trim();
                img_sign.ImageUrl = "~/Images/sign/sig.jpg";
                img_sign_card.ImageUrl = "~/Images/sign/sig.jpg";

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
        /******************************End***********************/
    }
    //------------------------------End----------------------------------

    //---------------Start Chip Encoding----------------------------------------
    protected void btn_ok_Click(object sender, EventArgs e)
    {
        try
        {
            ObjGeneral = new BaseLayer.General_function();
            SqlConnection Connection = new SqlConnection();
            Connection.ConnectionString = ConfigurationManager.ConnectionStrings["NigeriaConnectionString"].ConnectionString;
            //SqlCommand Command = new SqlCommand("update tbl_production set peopleid=@peopleid, status=1", Connection);

            /****************Fetch People Id******************/
            DataTable dt_p = new DataTable();
            string query = "SELECT top 1 people_id from people where cerpac_no='" + txt_cer_no_5.Text + "'";
            dt_p = ObjGeneral.FetchData(query);
            /****************End Fetch People Id******************/

            SqlParameter peopleid = new SqlParameter("@peopleid", SqlDbType.Int);

            peopleid.Value = dt_p.Rows[0]["people_id"].ToString();

            Connection.Open();

            string IP = System.Web.HttpContext.Current.Request.UserHostAddress;
            string command = "Insert into tbl_production (peopleid,status,ip_add) values (" + peopleid.Value + ",1,'" + IP.ToString().Trim() + "')";
            SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.Text, command);

            Connection.Close();


            Thread.Sleep(10000);
            Thread.Sleep(50000);

            DataTable dt = new DataTable();
            string query_p = "SELECT * from tbl_production where ip_add='" + IP.ToString().Trim() + "'";
            dt = ObjGeneral.FetchData(query_p);

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["chip_status"].ToString() == "0" || dt.Rows[0]["chip_status"] == null || dt.Rows[0]["chip_status"].ToString() == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "key", "alert(\"Card not Personalised Successfully\");", true);
                    Connection.Open();
                    SqlCommand cmd11 = new SqlCommand("Delete from tbl_production where IP_Add = '" + IP + "'", Connection);
                    cmd11.ExecuteNonQuery();
                    return;
                }
            }

            if (dt.Rows.Count == 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "key", "alert(\"Card not Personalised Successfully\");", true);
                return;

            }


           ScriptManager.RegisterStartupScript(this, GetType(), "key", "PrintContent();", true);
            Connection.Open();
            SqlCommand cmd1 = new SqlCommand("Delete from tbl_production where IP_Add = '" + IP + "'", Connection);
            cmd1.ExecuteNonQuery();

            if (ds.Rows[0]["IsProduced"].ToString() == "3")
            {

            }
            Connection.Close();
            int res = 0;
            BusinessEntityLayer.BalProductionModule objProduction = new BusinessEntityLayer.BalProductionModule();
            // objectSessionHolderPersistingData = Session["SessionHolderPersistingData"];
            objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
            //DataTable Dt = null;

            res = objProduction.UpdateProducedFlag(ds.Rows[0]["cerpac_no"].ToString(), "", "fprint", Convert.ToInt32(objectSessionHolderPersistingData.User_ID), "0");

            if (res == 1)
            {
               
                  
                btn_ok.Visible = false;
                btn_print_cond3.Visible = false;

                btnCardPrintSuccess.Visible = true;
                btnRePrintCard.Visible = true;
                btnWastedCard.Visible = true;

            }
            div_load.Style.Add("border", "5px solid #67CFF5");
            div_load.Style.Add("background-color", "White");

            // div_load.Attributes.Add("class", "loading_other");
            div_load.InnerHtml = "Loading......Please wait......";
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
            objgenenral = null;
        }
    }
    //--------------------End---------------------------------------------------

    //--------------Card Printing System-----------------------------------
    protected void btnCardPrintSuccess_Click(object sender, EventArgs e)
    {
       

        int res = 0;
        BusinessEntityLayer.BalProductionModule objProduction = new BusinessEntityLayer.BalProductionModule();
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
     
        res = objProduction.UpdateProducedFlag(ds.Rows[0]["cerpac_no"].ToString(), "", "print", Convert.ToInt32(objectSessionHolderPersistingData.User_ID), "0");

        if (res == 1)
        {
            DivCardPrint.Visible = true;

            btnCardPrintSuccess.Visible = false;
            btnRePrintCard.Visible = false;
            btnWastedCard.Visible = false;


        }


    }

    protected void btnSPrintedCard_Click(object sender, EventArgs e)
    {


        if (txtSPrintedCardNo.Text == "" || txtSPrintedCardNo.Text == "")
        {
            confirm.Style.Add("display", "none");
            warn.Style.Add("display", "");
            warn.InnerText = "Please Fill Card No.";
            return;
        }

        if (txtSFrontLam.Text == "" || txtSFrontLam.Text == "")
        {
            confirm.Style.Add("display", "none");
            warn.Style.Add("display", "");
            warn.InnerText = "Please Fill Front Lamination No.";
            return;
        }

        if (txtSBackLam.Text == "" || txtSBackLam.Text == "")
        {
            confirm.Style.Add("display", "none");
            warn.Style.Add("display", "");
            warn.InnerText = "Please Fill Back Lamination No.";
            return;
        }


        int res = 0;
        BusinessEntityLayer.BalProductionModule objProduction = new BusinessEntityLayer.BalProductionModule();
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        DataTable Dt = null;
        Dt = new DataTable();
        ObjGenBal = new BaseLayer.General_function();
        //string queryforcerpac = "select * from userstickerrelation where StickerWastedYN=0 and StickerPrintedYN=0 and USERID=" + objectSessionHolderPersistingData.User_ID + "";

        try
        {
            string queryforcerpac = "select * from userstickerrelation where stickernumber='" + txtSPrintedCardNo.Text + "'";
            Dt = ObjGenBal.FetchData(queryforcerpac);

            if (Dt.Rows.Count == 0)
            {
                confirm.Style.Add("display", "none");
                warn.Style.Add("display", "");
                warn.InnerText = "You have entered wrong Card No.";
                return;
            }

            string querysamecerpac = "select StickerNumber from userstickerrelation where StickerPrintedYN=4 and StickerIssuedToApplicationID='" + ds.Rows[0]["cerpac_no"].ToString() + "'";
            Dt = ObjGenBal.FetchData(querysamecerpac);

            if (Dt.Rows.Count > 0)
            {
                if (txtSPrintedCardNo.Text != Dt.Rows[0][0].ToString())
                {
                    confirm.Style.Add("display", "none");
                    warn.Style.Add("display", "");
                    warn.InnerText = "Physcial Card No. must be same as reprint card No.";
                    return;
                }
            }


            /******************************************************************************************************************/
            string queryforlam = "select * from tbl_lamination_detail where lam_no='" + txtSFrontLam.Text + "' or lam_no='" + txtSBackLam.Text + "'";
            Dt = ObjGenBal.FetchData(queryforlam);

            if (Dt.Rows.Count < 2)
            {
                confirm.Style.Add("display", "none");
                warn.Style.Add("display", "");
                warn.InnerText = "You have entered wrong Lamination No.";
                return;
            }
            /*****************************************************************************************************************/

            queryforcerpac = "select * from userstickerrelation inner join CerpacNo_Out_One on UserStickerRelation.StickerNumber=CerpacNo_Out_One.CardNo  inner join Zonemaster on CerpacNo_Out_One.ZoneCode=Zonemaster.ZoneCode where (CerpacNo_Out_One.StickerWastedYN=1 or CerpacNo_Out_One.StickerPrintedYN=1) and stickernumber='" + txtSPrintedCardNo.Text + "'";
            Dt = ObjGenBal.FetchData(queryforcerpac);

            if (Dt.Rows.Count > 0)
            {
                confirm.Style.Add("display", "none");
                warn.Style.Add("display", "");
                // warn.InnerText = "This Card Is Already used.";
                warn.InnerText = "This Card Is Already used in Zone " + Dt.Rows[0]["ZoneName"].ToString() + " on Cerpac No. " + Dt.Rows[0]["Cerpac_No"].ToString() + ".";
                return;
            }


            /******************************************************************************************************************/
            queryforlam = "select * from tbl_lamination_detail where (lam_no='" + txtSFrontLam.Text + "' or lam_no='" + txtSBackLam.Text + "') and isnull(lam_printedYN,0)=0 and isnull(lam_wastedYN,0)=0";
            Dt = ObjGenBal.FetchData(queryforlam);

            if (Dt.Rows.Count < 2)
            {
                confirm.Style.Add("display", "none");
                warn.Style.Add("display", "");
                warn.InnerText = "This Lamination No. Already Used";
                return;
            }
            /*****************************************************************************************************************/


            //queryforcerpac = "select * from userstickerrelation where StickerWastedYN=1 and stickernumber='" + txt_cerpac_serial_no.Text + "'";
            queryforcerpac = "select * from userstickerrelation inner join CerpacNo_Out_One on UserStickerRelation.StickerNumber=CerpacNo_Out_One.CardNo where (CerpacNo_Out_One.StickerWastedYN=1) and stickernumber='" + txtSPrintedCardNo.Text + "'";
            Dt = ObjGenBal.FetchData(queryforcerpac);

            if (Dt.Rows.Count > 0)
            {
                confirm.Style.Add("display", "none");
                warn.Style.Add("display", "");
                warn.InnerText = "This Card Is Already spoiled.";
                return;
            }

            /******************************************************************************************************************/
            queryforlam = "select * from tbl_lamination_detail where (lam_no='" + txtSFrontLam.Text + "' or lam_no='" + txtSBackLam.Text + "') and isnull(lam_printedYN,0)=1 and isnull(lam_wastedYN,0)=1";
            Dt = ObjGenBal.FetchData(queryforlam);

            if (Dt.Rows.Count > 0)
            {
                confirm.Style.Add("display", "none");
                warn.Style.Add("display", "");
                warn.InnerText = "This Lamination No. Already Spoiled";
                return;
            }
            /*****************************************************************************************************************/

            // if (Dt.Rows.Count > 0)
            {


                // res = objProduction.UpdateProducedFlag(ds.Rows[0]["cerpac_no"].ToString(), "", "ok", Convert.ToInt32(objectSessionHolderPersistingData.User_ID),Session["CardNo"].ToString());
                res = objProduction.UpdateProducedFlag(ds.Rows[0]["cerpac_no"].ToString(), "", "ok", Convert.ToInt32(objectSessionHolderPersistingData.User_ID), txtSPrintedCardNo.Text + "#" + txtSFrontLam.Text + "#" + txtSBackLam.Text);

                //---------Insert Into Audit---------
                //BaseLayer.General_function ObjGenBal = new BaseLayer.General_function();
                ObjGenBal.audittype = ENUMAUDITTYPE.Login.GetHashCode().ToString();
                ObjGenBal.userid = objectSessionHolderPersistingData.User_ID;
                ObjGenBal.auditdetail = "Update Flag in People Child Table";
                ObjGenBal.machineIP = Request.UserHostAddress.ToString();
                ObjGenBal.AuditInsert();
                //-----------END---------------------

                if (res == 1)
                {
                    confirm.Style.Add("display", "");
                    warn.Style.Add("display", "none");
                    DivCardPrint.Visible = false;
                    confirm.InnerText = "The Card Produced Successfully";
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
            Dt = null;
            objgenenral = null;
        }
    }
    //---------------------End-----------------------------------

    //-----------------------------Card Reprining System-----------------------------
       
    protected void btnRePrintCard_Click(object sender, EventArgs e)
    {
        int res = 0;
        BusinessEntityLayer.BalProductionModule objProduction = new BusinessEntityLayer.BalProductionModule();
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];

        res = objProduction.UpdateProducedFlag(ds.Rows[0]["cerpac_no"].ToString(), "", "RePrintSameCard", Convert.ToInt32(objectSessionHolderPersistingData.User_ID), "0");

        if (res == 1)
        {
            DivPrintSameCard.Visible = true;

            btnRePrintCard.Visible = false;
            btnCardPrintSuccess.Visible = false;
            btnWastedCard.Visible = false;
         
           
        }

        
    }
    protected void btnRePrintSameCardNo_Click(object sender, EventArgs e)
    {

        if (txtRePrintedCardNo.Text == "" || txtRePrintedCardNo.Text == " ")
        {
            confirm.Style.Add("display", "none");
            warn.Style.Add("display", "");
            warn.InnerText = "Please Fill Card No.";
            return;
        }

        int res = 0;
        BusinessEntityLayer.BalProductionModule objProduction = new BusinessEntityLayer.BalProductionModule();
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        DataTable Dt = null;
        Dt = new DataTable();
        ObjGenBal = new BaseLayer.General_function();
        try
        {
            //----------------------------Case !---------------------------------------
            string queryforcerpac = "select * from userstickerrelation where stickernumber='" + txtRePrintedCardNo.Text + "' and StickerPrintedYN=0 and StickerIssuedToApplicationID ='0'";
            Dt = ObjGenBal.FetchData(queryforcerpac);

            if (Dt.Rows.Count == 0)
            {
                confirm.Style.Add("display", "none");
                warn.Style.Add("display", "");
                warn.InnerText = "You have entered wrong Card No.";
                return;
            }
            //----------------------------Case !!---------------------------------------
            queryforcerpac = "select * from userstickerrelation inner join CerpacNo_Out_One on UserStickerRelation.StickerNumber=CerpacNo_Out_One.CardNo  inner join Zonemaster on CerpacNo_Out_One.ZoneCode=Zonemaster.ZoneCode where (CerpacNo_Out_One.StickerWastedYN=1 or CerpacNo_Out_One.StickerPrintedYN=1) and stickernumber='" + txtRePrintedCardNo.Text + "'";
            Dt = ObjGenBal.FetchData(queryforcerpac);

            if (Dt.Rows.Count > 0)
            {
                confirm.Style.Add("display", "none");
                warn.Style.Add("display", "");
                // warn.InnerText = "This Card Is Already used.";
                warn.InnerText = "This Card Is Already used in Zone " + Dt.Rows[0]["ZoneName"].ToString() + " on Cerpac No. " + Dt.Rows[0]["Cerpac_No"].ToString() + ".";
                return;
            }

            //----------------------------Case !!!---------------------------------------
            queryforcerpac = "select * from userstickerrelation inner join CerpacNo_Out_One on UserStickerRelation.StickerNumber=CerpacNo_Out_One.CardNo where (CerpacNo_Out_One.StickerWastedYN=1) and stickernumber='" + txtRePrintedCardNo.Text + "'";
            Dt = ObjGenBal.FetchData(queryforcerpac);

            if (Dt.Rows.Count > 0)
            {
                confirm.Style.Add("display", "none");
                warn.Style.Add("display", "");
                warn.InnerText = "This Card Is Already spoiled.";
                return;
            }

            //----------------------------Call Store Procedure ---Condition =InSameCardDetails-----------------------------------
            // if (Dt.Rows.Count > 0)
            {


                // res = objProduction.UpdateProducedFlag(ds.Rows[0]["cerpac_no"].ToString(), "", "ok", Convert.ToInt32(objectSessionHolderPersistingData.User_ID),Session["CardNo"].ToString());
                res = objProduction.UpdateProducedFlag(ds.Rows[0]["cerpac_no"].ToString(), "", "InSameCardDetails", Convert.ToInt32(objectSessionHolderPersistingData.User_ID), txtRePrintedCardNo.Text);

                //---------Insert Into Audit---------
                //BaseLayer.General_function ObjGenBal = new BaseLayer.General_function();
                ObjGenBal.audittype = ENUMAUDITTYPE.Login.GetHashCode().ToString();
                ObjGenBal.userid = objectSessionHolderPersistingData.User_ID;
                ObjGenBal.auditdetail = "Update Flag in People Child Table";
                ObjGenBal.machineIP = Request.UserHostAddress.ToString();
                ObjGenBal.AuditInsert();
                //-----------END---------------------

                if (res == 1)
                {
                    confirm.Style.Add("display", "");
                    warn.Style.Add("display", "none");
                    DivPrintSameCard.Visible = false;
                    confirm.InnerText = "Your now use same card for printing !!";
                    btn_ok.Visible = true;
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
            Dt = null;
            objgenenral = null;
        }
    }
    //--------------------End---------------------------------------------------------
   
   
    //-----------Wasted Card and lamination Maintaining System---------------------
    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {

        tr3.Style.Add("display", "");
        tr71.Style.Add("display", "");

        tr4.Style.Add("display", "none");
        tr7.Style.Add("display", "none");


    }
    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {

        tr3.Style.Add("display", "");
        tr4.Style.Add("display", "");
        tr7.Style.Add("display", "");
        tr71.Style.Add("display", "");



    }
    protected void btnWastedCard_Click(object sender, EventArgs e)
    {

        DivWastedCard.Visible = true;
        btnRePrintCard.Visible = false;
        btnCardPrintSuccess.Visible = false;
        btnWastedCard.Visible = false;
        btn_ok.Visible = false;

        if (RadioButton1.Checked == true)
        {
            tr3.Style.Add("display", "");
            tr71.Style.Add("display", "");
        }
        if (RadioButton2.Checked == true)
        {
            tr3.Style.Add("display", "");
            tr4.Style.Add("display", "");
            tr7.Style.Add("display", "");
            tr71.Style.Add("display", "");



        }
    }
  
    protected void btnWSave_Click(object sender, EventArgs e)
    {
        int res = 0;

        //--------------------Card Wasted during prodution----------------------------

        if (RadioButton1.Checked == true)
        {
            if (txtWPrintedCardNo.Text == "" || txtWPrintedCardNo.Text ==  " " )
            {
                confirm.Style.Add("display", "none");
                warn.Style.Add("display", "");
                warn.InnerText = "Please Enter Card No.";
                return;
            }

            int status = WastedLam();
            if (status == 1)
            {
                // authtable.Style.Add("display", "none");
                confirm.Style.Add("display", "");
                confirm.Attributes.Add("class", "confirmation-box animated-table bounceIn");
                confirm.InnerHtml = "Wasted card details are successfully save during prodution";

                DivWastedCard.Visible = false;

            }
        }


        //--------------------Card & Lam Wasted during prodution----------------------------
        if (RadioButton2.Checked == true)
        {
            if (txtWPrintedCardNo.Text == "" || txtWPrintedCardNo.Text == " ")
            {
                confirm.Style.Add("display", "none");
                warn.Style.Add("display", "");
                warn.InnerText = "Please Enter Card No.";
                return;
            }
            if (txtWFrontLam.Text == "" || txtWFrontLam.Text == " ")
            {
                confirm.Style.Add("display", "none");
                warn.Style.Add("display", "");
                warn.InnerText = "Please Enter Lamination Front No.";
                return;
            }

            if (txtWBackLam.Text == "" || txtWBackLam.Text == " ")
            {
                confirm.Style.Add("display", "none");
                warn.Style.Add("display", "");
                warn.InnerText = "Please Enter Lamination Back No.";
                return;
            }



            try
            {
                BusinessEntityLayer.BalProductionModule objProduction = new BusinessEntityLayer.BalProductionModule();
                objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
                DataTable Dt = null;
                Dt = new DataTable();
                ObjGenBal = new BaseLayer.General_function();

                string queryforcerpac = "select * from userstickerrelation where stickernumber='" + txtWPrintedCardNo.Text + "' and StickerWastedYN=0 and StickerPrintedYN=0 ";
                Dt = ObjGenBal.FetchData(queryforcerpac);

                if (Dt.Rows.Count == 0)
                {
                    confirm.Style.Add("display", "none");
                    warn.Style.Add("display", "");
                    warn.InnerText = "You have entered wrong Card No.";
                    return;
                }


                /******************************************************************************************************************/
                string queryforlam = "select * from tbl_lamination_detail where lam_no='" + txtWFrontLam.Text + "' or lam_no='" + txtWBackLam.Text + "'";
                Dt = ObjGenBal.FetchData(queryforlam);

                if (Dt.Rows.Count < 2)
                {
                    confirm.Style.Add("display", "none");
                    warn.Style.Add("display", "");
                    warn.InnerText = "You have entered wrong Lamination No.";
                    return;
                }
                /*****************************************************************************************************************/


                //queryforcerpac = "select * from userstickerrelation where StickerWastedYN=0 and StickerPrintedYN=1 and stickernumber='" + txt_cerpac_serial_no.Text + "'";

                queryforcerpac = "select * from userstickerrelation inner join CerpacNo_Out_One on UserStickerRelation.StickerNumber=CerpacNo_Out_One.CardNo  inner join Zonemaster on CerpacNo_Out_One.ZoneCode=Zonemaster.ZoneCode where (CerpacNo_Out_One.StickerWastedYN=1 or CerpacNo_Out_One.StickerPrintedYN=1) and stickernumber='" + txtWPrintedCardNo.Text + "'";
                Dt = ObjGenBal.FetchData(queryforcerpac);

                if (Dt.Rows.Count > 0)
                {
                    confirm.Style.Add("display", "none");
                    warn.Style.Add("display", "");
                    // warn.InnerText = "This Card Is Already used.";
                    warn.InnerText = "This Card Is Already used in Zone " + Dt.Rows[0]["ZoneName"].ToString() + " on Cerpac No. " + Dt.Rows[0]["Cerpac_No"].ToString() + ".";
                    return;
                }

                queryforcerpac = "select * from userstickerrelation inner join CerpacNo_Out_One on UserStickerRelation.StickerNumber=CerpacNo_Out_One.CardNo where (CerpacNo_Out_One.StickerWastedYN=1) and stickernumber='" + txtWPrintedCardNo.Text + "'";
                Dt = ObjGenBal.FetchData(queryforcerpac);

                if (Dt.Rows.Count > 0)
                {
                    confirm.Style.Add("display", "none");
                    warn.Style.Add("display", "");
                    warn.InnerText = "This Card Is Already spoiled.";
                    return;
                }


                /******************************************************************************************************************/
                queryforlam = "select * from tbl_lamination_detail where (lam_no='" + txtWFrontLam.Text + "' or lam_no='" + txtWBackLam.Text + "') and isnull(lam_printedYN,0)=1 and isnull(lam_wastedYN,0)=1";
                Dt = ObjGenBal.FetchData(queryforlam);

                if (Dt.Rows.Count > 0)
                {
                    confirm.Style.Add("display", "none");
                    warn.Style.Add("display", "");
                    warn.InnerText = "This Lamination No. Already Spoiled";
                    return;
                }
                /*****************************************************************************************************************/

                //--------------------------Need to Insert Waste Card & Lam details------------------------------------------------------

                Session["CardNo"] = txtWPrintedCardNo.Text;

                int status = WastedCardLam();
                if (status == 1)
                {
                    // authtable.Style.Add("display", "none");
                    confirm.Style.Add("display", "");
                    confirm.Attributes.Add("class", "confirmation-box animated-table bounceIn");
                    confirm.InnerHtml = "Wasted card and lamination details are successfully save during prodution";
                    DivWastedCard.Visible = false;
                }
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
                ObjGenBal = null;
            }

        }
    }    

    public int WastedCardLam()
    {
        SqlParameter[] pram = null;

        pram = new SqlParameter[8];
        pram[0] = new SqlParameter("@UserId", objectSessionHolderPersistingData.User_ID);
        pram[1] = new SqlParameter("@CerpacNo", txt_cer_no_5.Text );
        pram[2] = new SqlParameter("@condition", "WastedCardLam");
        pram[3] = new SqlParameter("@Reason", "WastedCard and Lamination during Card Production");
        pram[4] = new SqlParameter("@CardNo", txtWPrintedCardNo.Text.ToString());
        pram[5] = new SqlParameter("@FrontLam", txtWFrontLam.Text.Trim().ToString());
        pram[6] = new SqlParameter("@BackLam", txtWBackLam.Text.Trim().ToString());

        pram[7] = new SqlParameter("@SuccessId", 1);
        pram[7].Direction = ParameterDirection.Output;
        SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_UPDATE_PRODUCED_WASTECARD_NEW", pram);
        return int.Parse(pram[7].Value.ToString());
    }

    public int WastedLam()
    {
        SqlParameter[] pram = null;

        pram = new SqlParameter[8];
        pram[0] = new SqlParameter("@UserId", objectSessionHolderPersistingData.User_ID);
        pram[1] = new SqlParameter("@CerpacNo", txt_cer_no_5.Text);
        pram[2] = new SqlParameter("@condition", "WastedCard");
        pram[3] = new SqlParameter("@Reason", "WastedCard during Card Production");
        pram[4] = new SqlParameter("@CardNo", txtWPrintedCardNo.Text.ToString());
        pram[5] = new SqlParameter("@FrontLam", "0");
        pram[6] = new SqlParameter("@BackLam", "0");

        pram[7] = new SqlParameter("@SuccessId", 1);
        pram[7].Direction = ParameterDirection.Output;
        SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_UPDATE_PRODUCED_WASTECARD_NEW", pram);
        return int.Parse(pram[7].Value.ToString());
    }
    //---------------------End-----------------------------------------------------

   
    //---------------Call Cliend System Printer--------------------------------
    // Handler for PrintPageEvents
    private void PrintPage(object sender, PrintPageEventArgs ev)
    {
        Metafile pageImage = new  Metafile(m_streams[m_currentPageIndex]);

        // Adjust rectangular area with printer margins.
        Rectangle adjustedRect = new Rectangle(
            ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
            ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
            ev.PageBounds.Width,
            ev.PageBounds.Height);

        // Draw a white background for the report
        ev.Graphics.FillRectangle(Brushes.White, adjustedRect);

        // Draw the report content
        ev.Graphics.DrawImage(pageImage, adjustedRect);

        // Prepare for the next page. Make sure we haven't hit the end.
        m_currentPageIndex++;
        ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
    }

    private void Print()
    {
        try
        {
            if (m_streams == null || m_streams.Count == 0)
                throw new Exception("Error: no stream to print.");
            PrintDocument printDoc = new PrintDocument();

            //  if (!printDoc.PrinterSettings.IsValid)
            //{
            //  throw new Exception("Error: cannot find the default printer.");
            // }
            // else
            {
                printDoc.DefaultPageSettings.Landscape = true;
                printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
                //   printDoc.PrinterSettings.PrinterName = "";
                m_currentPageIndex = 0;

                printDoc.Print();
            }

        }
        catch (Exception e)
        {
            Response.Write("<script>alert('No Printer Installed'); return false;</script>");
            return;
        }
    }

    //---------------------End------------------------------------------------
    private DataTable LoadSalesData()
    {
        // Create a new DataSet and read sales data file 
        //    data.xml into the first DataTable.


        ObjGeneral = new BaseLayer.General_function();
        DataTable dt = new DataTable();
        // string query = "SELECT * from ProdReportCerpacCard";
        string query = "SELECT * from vw_prod_consolidated_data where cerpac_no='" + lbl_cerpac_no.Text + "'";
        // try
        {
            dt = ObjGeneral.FetchData(query);

            ////DataSet dataSet = new DataSet();
            ////dataSet.ReadXml(@"..\..\data.xml");
            return dt;

        }


    }
    // Routine to provide to the report renderer, in order to
    //    save an image for each page of the report.
    private Stream CreateStream(string name,
      string fileNameExtension, Encoding encoding,
      string mimeType, bool willSeek)
    {
        Stream stream = new MemoryStream();
        m_streams.Add(stream);
        return stream;
    }
   
}