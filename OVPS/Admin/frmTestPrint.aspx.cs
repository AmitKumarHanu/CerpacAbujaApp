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
using Microsoft.Reporting.WebForms;
using System.Drawing.Printing;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Text;
using System.Drawing.Drawing2D;
using System.IO;
using System.Globalization;
using System.Threading;
using System.Net.NetworkInformation;


public partial class Admin_frmTestPrint : System.Web.UI.Page
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
        if (!IsPostBack)
        {
          //  string script = "$(document).ready(function () { $('[id*=btn_ok]').click(); });";
          //  ClientScript.RegisterStartupScript(this.GetType(), "load", script, true);
        } 
        if (Session["card"] == null)
        {
            Response.Redirect("../Login.aspx");
        }

        //GetMacAddress();

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
            //Commented on 22 Aug after discussion with Sanjay Sir & Gagan Sir

            //DataTable dt_cerpac_serial = new DataTable();
            //string query = "select top(1) * from userstickerrelation where StickerWastedYN=0 and StickerPrintedYN=0 and USERID=" + objectSessionHolderPersistingData.User_ID + " ";
            //dt_cerpac_serial = ObjGeneral.FetchData(query);

            //txt_cerpac_serial_no.Text = dt_cerpac_serial.Rows[0]["stickerserialno"].ToString();
            //txt_reprint_card_serial_no.Text = dt_cerpac_serial.Rows[0]["stickerserialno"].ToString();
            
            //txt_cerpac_serial_no.Text = Session["CardNo"].ToString();
            bindreport();
            
            if (ds.Rows[0]["IsProduced"].ToString() == "1")
            {
                btn_ok.Enabled = false;
                btn_ok.Visible = false;
                btn_print_ok.Visible = false;
                btn_reprint_card.Visible = true;
                lbl_cerpac_serial_no.Visible = false;
                txt_cerpac_serial_no.Visible = false;
                confirm.Style.Add("display", "none");
                warn.Style.Add("display", "");

                tr1.Style.Add("display", "none");
                tr2.Style.Add("display", "none");
            }

            else if (ds.Rows[0]["IsProduced"].ToString() == "2")
            {
                btn_ok.Visible = false;
                btn_reprint_card.Visible = true;
                btn_print_ok.Visible = true;
                tr1.Style.Add("display", "");
                tr2.Style.Add("display", "");

                btn_pr_ok.Visible = false;
                btn_pr_not_ok.Visible = false;
                btn_print_cond3.Visible = false;
            }

            else if (ds.Rows[0]["IsProduced"].ToString() == "3")
            {
                btn_pr_not_ok.Visible = false;
                btn_pr_ok.Visible = false;

                btn_ok.Visible = false;
                btn_print_ok.Visible = false;
                lbl_cerpac_serial_no.Visible = false;
                txt_cerpac_serial_no.Visible = false;
                btn_reprint_card.Visible = false;
                tr1.Style.Add("display", "none");
                tr2.Style.Add("display", "none");
                btn_print_cond3.Visible = true;

            }
            else
            {
                lbl_cerpac_serial_no.Visible = true;
                txt_cerpac_serial_no.Visible = true;
                btn_ok.Enabled = true;
                btn_print_cond3.Visible = false;
                btn_print_ok.Visible = false;

                btn_reprint_card.Visible = false;
                confirm.Style.Add("display", "none");
                warn.Style.Add("display", "none");
                tr1.Style.Add("display", "none");
                tr2.Style.Add("display", "none");

                btn_pr_ok.Visible = false;
                btn_pr_not_ok.Visible = false;

               // div_load.InnerHtml = "Chip Encoding In Progress......Please wait......";
                div_load.Attributes.Add("class","loading");
                div_load.Style.Add("border", " ");
                div_load.Style.Add("background-color", " ");
          
                div_load.InnerHtml = " <img src='../Images/load.gif' alt='' />";
            }
        }

        /***************************/


        int res = 0;
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        ObjGenBal = new BaseLayer.General_function();
        BusinessEntityLayer.BalProductionModule objProduction = new BusinessEntityLayer.BalProductionModule();

      //  BaseLayer.General_function ObjGenBal = new BaseLayer.General_function();
      //  ObjGenBal.audittype = ENUMAUDITTYPE.Logout.GetHashCode().ToString();
       //// ObjGenBal.userid = "664";
        ObjGenBal.userid = objectSessionHolderPersistingData.User_ID;
        //res = objProduction.UpdateCerpacFlag(objectSessionHolderPersistingData.User_ID, txt_cer_no_5.Text);
        //res = objProduction.UpdateCerpacFlag(ObjGenBal.userid, txt_cer_no_5.Text);

    }

    public static PhysicalAddress GetMacAddress()
    {
        foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
        {
            // Only consider Ethernet network interfacess
            if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
            {
                return nic.GetPhysicalAddress();
               
            }
        }
       
        return null;
    }


    //protected void Timer1_Tick(object sender, EventArgs e)
    //{
    //    try
    //    {

    //        //Put Your Code here
    //        int res = 0;
    //        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];

    //        BusinessEntityLayer.BalProductionModule objProduction = new BusinessEntityLayer.BalProductionModule();

    //        BaseLayer.General_function ObjGenBal = new BaseLayer.General_function();
    //        ObjGenBal.audittype = ENUMAUDITTYPE.Logout.GetHashCode().ToString();
    //        ObjGenBal.userid = objectSessionHolderPersistingData.User_ID;

    //        res = objProduction.UpdateCerpacFlag(objectSessionHolderPersistingData.User_ID, txt_cer_no_5.Text);



    //    }

    //    catch (Exception ex)
    //    {

    //    }
    //}




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

                /*****************************Retrieve Image****************************/
                //byte[] picData = ds.Rows[0]["userimage"] as byte[] ?? null;
                //System.Drawing.Image newImage;
                //if (picData != null)
                //{
                //    using (MemoryStream ms = new MemoryStream(picData))
                //    {
                //        // Load the image from the memory stream. How you do it depends
                //        // on whether you're using Windows Forms or WPF.
                //        // For Windows Forms you could write:
                //        // System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(ms);

                //        newImage = System.Drawing.Image.FromStream(ms);

                //        if (ds.Rows[0]["picture"] == null || ds.Rows[0]["picture"].ToString() == "")
                //            ds.Rows[0]["picture"] = ds.Rows[0]["cerpac_no"] + ".jpg";

                //        if (!File.Exists(Server.MapPath("~") + "/Images/Logo/" + ds.Rows[0]["picture"].ToString().Trim()))
                //            newImage.Save(Server.MapPath("~") + "/Images/Logo/" + ds.Rows[0]["picture"].ToString().Trim());
                //        // newImage.Save("g:/Saurabh" + Dt.Rows[0]["picture"].ToString().Trim());

                //    }
                //}
                /*******************************End************************************/


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

                //ReportDataSource datasource = new ReportDataSource("DataSet1", dt);

                //ReportViewer1.LocalReport.DataSources.Clear();
                //ReportViewer1.LocalReport.DataSources.Add(datasource);

                //ReportViewer1.LocalReport.Refresh();

                //Generate PDF 
                //--------------------- for download of pdf file uncomment the below code------------
                //Warning[] warnings;
                //string[] streamids;
                //string mimeType;
                //string encoding;
                //string filenameExtension;

                //byte[] bytes = ReportViewer1.LocalReport.Render(
                //    "PDF", null, out mimeType, out encoding, out filenameExtension,
                //    out streamids, out warnings);

                //Response.Clear();
                //Response.Buffer = true;
                //Response.ContentType = "application/pdf";
                //Response.BinaryWrite(bytes);
                //Response.End();
                //----------------- till here----------------------------


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
                    txt_comp.Text = textInfo.ToTitleCase(dtcomp.Rows[0]["company"].ToString().Trim().ToLower());
                    txt_comps.Text = textInfo.ToTitleCase(dtcomp.Rows[0]["company"].ToString().Trim().ToLower());
                }

                /******************* End Code **********************/



            }

            /************************ Fetch Signature ***************/
            DataTable Dt = null;
            Dt = new DataTable();
            ObjGenBal = new BaseLayer.General_function();
            DataTable Dt_Auth = null;
            Dt_Auth = new DataTable();

            string queryforFetchAuth = "SELECT AuthorizedBy from ProdReportCerpacCard where cerpacno='" + lbl_cerpac_no.Text + "' and cerpac_file_no='" + ds.Rows[0]["cerpac_file_no"].ToString() + "'";
            Dt_Auth = ObjGenBal.FetchData(queryforFetchAuth);
            string queryforcerpac = "select * from UserMaster where userid='" + Dt_Auth.Rows[0]["AuthorizedBy"].ToString() + "'";
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

    public static string ConvertDate(string date, string pattern)
    {

        if (string.IsNullOrEmpty(date) == false && date != "")
        {
            DateTime date2;
            if (DateTime.TryParseExact(date, pattern, CultureInfo.InvariantCulture, DateTimeStyles.None, out date2))
            {
                return date2.ToString("MM/d/yyyy");
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

    protected void btn_ok_Click(object sender, EventArgs e)
    {

        /*
        int res = 0;
        BusinessEntityLayer.BalProductionModule objProduction = new BusinessEntityLayer.BalProductionModule();
       // objectSessionHolderPersistingData = Session["SessionHolderPersistingData"];
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        DataTable Dt = null;
        Dt = new DataTable();
        ObjGenBal = new BaseLayer.General_function();
       // string queryforcerpac = "select * from userstickerrelation where StickerWastedYN=0 and StickerPrintedYN=0 and USERID=" + objectSessionHolderPersistingData.User_ID + "";
        string queryforcerpac = "select * from userstickerrelation where StickerWastedYN=0 and StickerPrintedYN=0 and StickerNumber='" + Session["CardNo"].ToString() + "'";

        Dt = ObjGenBal.FetchData(queryforcerpac);
        if (Dt.Rows.Count > 0)
        {
           // Run();
            //res = objProduction.UpdateProducedFlag(ds.Rows[0]["cerpac_no"].ToString());
            res = objProduction.UpdateProducedFlag(ds.Rows[0]["cerpac_no"].ToString(), "", "print", Convert.ToInt32(objectSessionHolderPersistingData.User_ID), Session["CardNo"].ToString());

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
                confirm.InnerText = "Card Printed Successfully.";
               // Run();
                btn_ok.Enabled = false;
                btn_ok.Visible = false;
                btn_reprint_card.Visible = true;
                btn_print_ok.Visible = true;
                
            }
        }

        else
        {
            confirm.Style.Add("display", "none");
            warn.Style.Add("display", "");
            warn.InnerText = "Card Not Issued";
        }
*/

       //  Run();
        try
        {
            ObjGeneral = new BaseLayer.General_function();
            SqlConnection Connection = new SqlConnection();
            Connection.ConnectionString = ConfigurationManager.ConnectionStrings["NigeriaConnectionString"].ConnectionString;
            //   SqlCommand Command = new SqlCommand("update tbl_production set peopleid=@peopleid, status=1", Connection);

            /****************Fetch People Id******************/
            DataTable dt_p = new DataTable();
            string query = "SELECT people_id from people where cerpac_no='" + txt_cer_no_5.Text + "'";
            dt_p = ObjGeneral.FetchData(query);
            /****************End Fetch People Id******************/

            SqlParameter peopleid = new SqlParameter("@peopleid", SqlDbType.Int);

            peopleid.Value = dt_p.Rows[0]["people_id"].ToString();
            //Command.Parameters.Add(peopleid);
            Connection.Open();
            /// <summary>
            /// The SQL statement is executed. ExecuteNonQuery is used since no records
            /// will be returned. </summary>
            //  Command.ExecuteNonQuery();
            string IP = System.Web.HttpContext.Current.Request.UserHostAddress;
            string command = "Insert into tbl_production (peopleid,status,ip_add) values (" + peopleid.Value + ",1,'" + IP.ToString().Trim() + "')";
            SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.Text, command);

            /// <summary>
            /// The connection is closed </summary>
            Connection.Close();


            Thread.Sleep(10000);
            Thread.Sleep(50000);


            // CheckBox1.Checked = true;

            //div_load.InnerText = "Card Moved in Hoper";
            //div_load.Page.DataBind();

            //  div_load.InnerText = "Chip Encoding Start";

            //Thread.Sleep(20000);
            //  div_load.InnerText = "Data Write in Chip ";

            //  Thread.Sleep(10000);


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

                btn_reprint_card.Visible = true;
                btn_print_ok.Visible = true;
                tr1.Style.Add("display", "");
                tr2.Style.Add("display", "");

                /* New Functionality */

                tr1.Style.Add("display", "none");
                tr2.Style.Add("display", "none");

                btn_print_ok.Visible = false;
                btn_reprint_card.Visible = false;
                btn_pr_ok.Visible = true;
                btn_pr_not_ok.Visible = true;

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
    // Export the given report as an EMF (Enhanced Metafile) file.
//    private void Export(LocalReport report)
//    {

        

//        string deviceInfo =
//          @"<DeviceInfo>
//                <OutputFormat>EMF</OutputFormat>
//                <PageWidth>11in</PageWidth>
//                <PageHeight>8.5in</PageHeight>
//                <MarginTop>0.25in</MarginTop>
//                <MarginLeft>1.5in</MarginLeft>
//                <MarginRight>0.25in</MarginRight>
//                <MarginBottom>0.25in</MarginBottom>
//            </DeviceInfo>";
//        Warning[] warnings;
//        m_streams = new List<Stream>();
//        report.Render("Image", deviceInfo, CreateStream, out warnings);

//        foreach (Stream stream in m_streams)
//            stream.Position = 0;
//    }
    // Handler for PrintPageEvents
    private void PrintPage(object sender, PrintPageEventArgs ev)
    {
        Metafile pageImage = new
           Metafile(m_streams[m_currentPageIndex]);

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

    // Create a local report for Report.rdlc, load the data,
    //    export the report to an .emf file, and print it.
    //private void Run()
    //{
    //    LocalReport report = new LocalReport();
    //    report.ReportPath = @"CardDesignNewone.rdlc";
    //    report.DataSources.Add(new ReportDataSource("DataSet1", LoadSalesData()));
    //    Export(report);
    //    Print();
    //}

    public void Dispose()
    {
        if (m_streams != null)
        {
            foreach (Stream stream in m_streams)
                stream.Close();
            m_streams = null;
        }
    }

    string reason = "";
    protected void btn_Reason_Print_Click(object sender, EventArgs e)
    {
        int res = 0;

        if (txt_reprint_card_serial_no.Text == "")
        {
            confirm.Style.Add("display", "none");
            warn.Style.Add("display", "");
            warn.InnerText = "Please Enter Card No.";
            return;
        }

        if (txt_lam_front.Text == "")
        {
            confirm.Style.Add("display", "none");
            warn.Style.Add("display", "");
            warn.InnerText = "Please Enter Lamination Front No.";
            return;
        }

        if (txt_lam_back.Text == "")
        {
            confirm.Style.Add("display", "none");
            warn.Style.Add("display", "");
            warn.InnerText = "Please Enter Lamination Back No.";
            return;
        }


        //if (txt_reprint_card_serial_no.Text == "")
        //{
        //    confirm.Style.Add("display", "none");
        //    warn.Style.Add("display", "");
        //    warn.InnerText = "Please Enter Card No.";
        //    return;
        //}

        
        try
        {
            // txt_reprint_card_serial_no.Text = txt_cerpac_serial_no.Text;
            BusinessEntityLayer.BalProductionModule objProduction = new BusinessEntityLayer.BalProductionModule();
            // objectSessionHolderPersistingData = Session["SessionHolderPersistingData"];
            objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
            DataTable Dt = null;
            Dt = new DataTable();
            ObjGenBal = new BaseLayer.General_function();
            // string queryforcerpac = "select * from userstickerrelation where StickerWastedYN=0 and StickerPrintedYN=0 and USERID=" + objectSessionHolderPersistingData.User_ID + "";

            //string queryforcerpac = "select * from userstickerrelation where StickerWastedYN=0 and StickerPrintedYN=0 and StickerNumber='" + txt_reprint_card_serial_no.Text + "'";

            //validation
            string queryforcerpac = "select * from userstickerrelation where stickernumber='" + txt_reprint_card_serial_no.Text + "'";
            Dt = ObjGenBal.FetchData(queryforcerpac);

            if (Dt.Rows.Count == 0)
            {
                confirm.Style.Add("display", "none");
                warn.Style.Add("display", "");
                warn.InnerText = "You have entered wrong Card No.";
                return;
            }


            /******************************************************************************************************************/
            string queryforlam = "select * from tbl_lamination_detail where lam_no='" + txt_lam_front.Text + "' or lam_no='" + txt_lam_back.Text + "'";
            Dt = ObjGenBal.FetchData(queryforlam);

            if (Dt.Rows.Count <2)
            {
                confirm.Style.Add("display", "none");
                warn.Style.Add("display", "");
                warn.InnerText = "You have entered wrong Lamination No.";
                return;
            }
            /*****************************************************************************************************************/
            

            //queryforcerpac = "select * from userstickerrelation where StickerWastedYN=0 and StickerPrintedYN=1 and stickernumber='" + txt_cerpac_serial_no.Text + "'";

            queryforcerpac = "select * from userstickerrelation inner join CerpacNo_Out_One on UserStickerRelation.StickerNumber=CerpacNo_Out_One.CardNo  inner join Zonemaster on CerpacNo_Out_One.ZoneCode=Zonemaster.ZoneCode where (CerpacNo_Out_One.StickerWastedYN=1 or CerpacNo_Out_One.StickerPrintedYN=1) and stickernumber='" + txt_reprint_card_serial_no.Text + "'";
            Dt = ObjGenBal.FetchData(queryforcerpac);

            if (Dt.Rows.Count > 0)
            {
                confirm.Style.Add("display", "none");
                warn.Style.Add("display", "");
                // warn.InnerText = "This Card Is Already used.";
                warn.InnerText = "This Card Is Already used in Zone " + Dt.Rows[0]["ZoneName"].ToString() + " on Cerpac No. " + Dt.Rows[0]["Cerpac_No"].ToString() + ".";
                return;
            }


            


            //queryforcerpac = "select * from userstickerrelation where StickerWastedYN=1 and stickernumber='" + txt_cerpac_serial_no.Text + "'";
            queryforcerpac = "select * from userstickerrelation inner join CerpacNo_Out_One on UserStickerRelation.StickerNumber=CerpacNo_Out_One.CardNo where (CerpacNo_Out_One.StickerWastedYN=1) and stickernumber='" + txt_reprint_card_serial_no.Text + "'";
            Dt = ObjGenBal.FetchData(queryforcerpac);

            if (Dt.Rows.Count > 0)
            {
                confirm.Style.Add("display", "none");
                warn.Style.Add("display", "");
                warn.InnerText = "This Card Is Already spoiled.";
                return;
            }


            /******************************************************************************************************************/
            queryforlam = "select * from tbl_lamination_detail where (lam_no='" + txt_front_lam.Text + "' or lam_no='" + txt_back_lam.Text + "') and isnull(lam_printedYN,0)=1 and isnull(lam_wastedYN,0)=1";
            Dt = ObjGenBal.FetchData(queryforlam);

            if (Dt.Rows.Count > 0)
            {
                confirm.Style.Add("display", "none");
                warn.Style.Add("display", "");
                warn.InnerText = "This Lamination No. Already Spoiled";
                return;
            }
            /*****************************************************************************************************************/

            
            //Validation
            // string queryforcerpac = "select * from cerpacno_out_one where isnull(StickerWastedYN,0)=0 and StickerPrintedYN=1 and cardno='" + txt_reprint_card_serial_no.Text + "'";
           


            //   Dt = ObjGenBal.FetchData(queryforcerpac);

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

            Session["CardNo"] = txt_reprint_card_serial_no.Text;
            // if (Dt.Rows.Count > 0)
            {
               
                /****************************************************************************************************/
                ObjGeneral = new BaseLayer.General_function();
                SqlConnection Connection = new SqlConnection();
                
                Connection.ConnectionString = ConfigurationManager.ConnectionStrings["NigeriaConnectionString"].ConnectionString;
                Connection.Open();
                SqlCommand cmd1 = new SqlCommand("update tbl_lamination_detail set card_no='" + txt_reprint_card_serial_no.Text + "' where lam_no='" + txt_lam_front.Text + "' or lam_no='" + txt_lam_back.Text + "'", Connection);
                cmd1.ExecuteNonQuery();
                /****************************************************************************************************/


                res = objProduction.UpdateProducedFlag(ds.Rows[0]["cerpac_no"].ToString(), reason, "reprint", Convert.ToInt32(objectSessionHolderPersistingData.User_ID), Session["CardNo"].ToString());

                //---------Insert Into Audit---------
                //BaseLayer.General_function ObjGenBal = new BaseLayer.General_function();
                ObjGenBal.audittype = ENUMAUDITTYPE.Login.GetHashCode().ToString();
                ObjGenBal.userid = objectSessionHolderPersistingData.User_ID;
                ObjGenBal.auditdetail = "Update Flag in People Child Table Reprint Case";
                ObjGenBal.machineIP = Request.UserHostAddress.ToString();
                ObjGenBal.AuditInsert();
                //-----------END---------------------

                if (res == 1)
                {
                    confirm.Style.Add("display", "none");
                    warn.Style.Add("display", "none");

                    //   Run();
                    btn_ok.Enabled = false;
                }
            }

            //else
            //{
            //    confirm.Style.Add("display", "none");
            //    warn.Style.Add("display", "");
            //    warn.InnerText = "This Card Is Not Available or Already Used.";
            //}
            Response.Redirect("ProductionDetails.aspx");
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
           // Dt = null;
            objgenenral = null;
        }

    }
    protected void btn_print_ok_Click(object sender, EventArgs e)
    {




        if (txt_cerpac_serial_no.Text == "")
        {
            confirm.Style.Add("display", "none");
            warn.Style.Add("display", "");
            warn.InnerText = "Please Fill Card No.";
            return;
        }

        if (txt_front_lam.Text == "")
        {
            confirm.Style.Add("display", "none");
            warn.Style.Add("display", "");
            warn.InnerText = "Please Fill Front Lamination No.";
            return;
        }

        if (txt_back_lam.Text == "")
        {
            confirm.Style.Add("display", "none");
            warn.Style.Add("display", "");
            warn.InnerText = "Please Fill Back Lamination No.";
            return;
        }


        int res = 0;
        BusinessEntityLayer.BalProductionModule objProduction = new BusinessEntityLayer.BalProductionModule();
        // objectSessionHolderPersistingData = Session["SessionHolderPersistingData"];
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        DataTable Dt = null;
        Dt = new DataTable();
        ObjGenBal = new BaseLayer.General_function();
        //string queryforcerpac = "select * from userstickerrelation where StickerWastedYN=0 and StickerPrintedYN=0 and USERID=" + objectSessionHolderPersistingData.User_ID + "";

        try
        {
            string queryforcerpac = "select * from userstickerrelation where stickernumber='" + txt_cerpac_serial_no.Text + "'";
            Dt = ObjGenBal.FetchData(queryforcerpac);

            if (Dt.Rows.Count == 0)
            {
                confirm.Style.Add("display", "none");
                warn.Style.Add("display", "");
                warn.InnerText = "You have entered wrong Card No.";
                return;
            }

            /******************************************************************************************************************/
            string queryforlam = "select * from tbl_lamination_detail where lam_no='" + txt_front_lam.Text.Trim() + "' or lam_no='" + txt_back_lam.Text.Trim() + "'";
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




            queryforcerpac = "select * from userstickerrelation inner join CerpacNo_Out_One on UserStickerRelation.StickerNumber=CerpacNo_Out_One.CardNo  inner join Zonemaster on CerpacNo_Out_One.ZoneCode=Zonemaster.ZoneCode where (CerpacNo_Out_One.StickerWastedYN=1 or CerpacNo_Out_One.StickerPrintedYN=1) and stickernumber='" + txt_cerpac_serial_no.Text + "'";
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
            queryforlam = "select * from tbl_lamination_detail where (lam_no='" + txt_front_lam.Text + "' or lam_no='" + txt_back_lam.Text + "') and isnull(lam_printedYN,0)=0 and isnull(lam_wastedYN,0)=0";
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
            queryforcerpac = "select * from userstickerrelation inner join CerpacNo_Out_One on UserStickerRelation.StickerNumber=CerpacNo_Out_One.CardNo where (CerpacNo_Out_One.StickerWastedYN=1) and stickernumber='" + txt_cerpac_serial_no.Text + "'";
            Dt = ObjGenBal.FetchData(queryforcerpac);

            if (Dt.Rows.Count > 0)
            {
                confirm.Style.Add("display", "none");
                warn.Style.Add("display", "");
                warn.InnerText = "This Card Is Already spoiled.";
                return;
            }

            /******************************************************************************************************************/
            queryforlam = "select * from tbl_lamination_detail where (lam_no='" + txt_front_lam.Text + "' or lam_no='" + txt_back_lam.Text + "') and isnull(lam_printedYN,0)=1 and isnull(lam_wastedYN,0)=1";
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
                res = objProduction.UpdateProducedFlag(ds.Rows[0]["cerpac_no"].ToString(), "", "ok", Convert.ToInt32(objectSessionHolderPersistingData.User_ID), txt_cerpac_serial_no.Text + "#" + txt_front_lam.Text + "#" + txt_back_lam.Text);

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
                    tr1.Style.Add("display", "none");
                    tr2.Style.Add("display", "none");

                    confirm.InnerText = "Card Produced Successfully";
                    // Run();
                    btn_ok.Enabled = false;
                    btn_ok.Visible = false;
                    btn_reprint_card.Visible = false;

                    btn_print_ok.Visible = false;
                    lbl_msg_cond3.Visible = false;

                }
            }

            //else
            //{
            //    confirm.Style.Add("display", "none");
            //    warn.Style.Add("display", "");
            //    warn.InnerText = "Card Not Issued";
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
            Dt = null;
            objgenenral = null;
        }
    }

    protected void btn_pr_ok_Click(object sender, EventArgs e)
    {
        int res = 0;
        BusinessEntityLayer.BalProductionModule objProduction = new BusinessEntityLayer.BalProductionModule();
        // objectSessionHolderPersistingData = Session["SessionHolderPersistingData"];
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        //DataTable Dt = null;

        res = objProduction.UpdateProducedFlag(ds.Rows[0]["cerpac_no"].ToString(), "", "print", Convert.ToInt32(objectSessionHolderPersistingData.User_ID), "0");

        if (res == 1)
        {
            btn_ok.Visible = false;
            btn_reprint_card.Visible = true;
            btn_print_ok.Visible = true;
            
            tr1.Style.Add("display", "");
            tr2.Style.Add("display", "");

            lbl_cerpac_serial_no.Visible = true;
            txt_cerpac_serial_no.Visible = true;

            btn_pr_ok.Visible = false;
            btn_pr_not_ok.Visible = false;
            lbl_msg_cond3.Visible = false;

            /****************************************************************/
            tr2.Style.Add("display", "");
            lbl_lam_no.Visible = true;
            txt_front_lam.Visible = true;
            txt_back_lam.Visible = true;

            /****************************************************************/


        }
    }
    protected void btn_pr_not_ok_Click(object sender, EventArgs e)
    {
       // Thread.Sleep(10000);
        btn_ok.Visible = true;

        tr1.Style.Add("display", "none");
        tr2.Style.Add("display", "none");
        btn_reprint_card.Visible = false;
        btn_pr_ok.Visible = false;
        btn_pr_not_ok.Visible = false;
        lbl_msg_cond3.Visible = false;
      //  div_load.InnerHtml = "Chip Encoding In Progress......Please wait......";
        div_load.Style.Add("border", " ");
        div_load.Style.Add("background-color", " ");
          
     //   div_load.Attributes.Add("class", "loading");

        div_load.InnerHtml = "<img src='../Images/load.gif' alt='' />";

        
    }
    protected void btn_print_cond3_Click(object sender, EventArgs e)
    {
        //string confirmValue = Request.Form["confirm_value"];
        //if (confirmValue == "Yes")
        //{
      
       // Response.Write("<script>alert('You have already fired print command but status of printout is pending! Update Status click YES.')</script>");
            btn_pr_not_ok.Visible = true;
            btn_pr_ok.Visible = true;

            btn_pr_ok.Text = "YES";

            btn_pr_not_ok.Text = "NO";

            btn_ok.Visible = false;
            btn_print_ok.Visible = false;
          //  lbl_cerpac_serial_no.Visible = false;
           // txt_cerpac_serial_no.Visible = false;
            btn_reprint_card.Visible = false;
            tr1.Style.Add("display", "none");
            tr2.Style.Add("display", "none");

            btn_print_cond3.Visible = false;
            lbl_msg_cond3.Visible = true;

            //div_load.Attributes.Add("class", "loading_other");
            div_load.Style.Add("border", "5px solid #67CFF5");
            div_load.Style.Add("background-color", "White");
             div_load.InnerHtml = "Loading......Please wait......";

        //}
        //else
        //{
        //  //  Response.Write("<script>alert('No')</script>");
        //}
    }
    protected void btn_TestPrint_Click(object sender, EventArgs e)
    {

        ScriptManager.RegisterStartupScript(this, GetType(), "key", "PrintContent();", true);
    }
}