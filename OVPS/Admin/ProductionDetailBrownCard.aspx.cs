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
using System.Drawing.Printing;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Text;
using System.IO;
using System.Globalization;
using System.Threading;

public partial class Admin_ProductionDetailBrownCard : System.Web.UI.Page
{
    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    BaseLayer.General_function objgenenral = null;
    BaseLayer.General_function ObjGeneral = null;
    protected BaseLayer.General_function ObjGenBal = null;
    DataTable ds = new DataTable();
    string cerpac_no = "";
    string formno = "";
    Label LabelMessage = null;
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["card"] == null)
        {
            Response.Redirect("../Login.aspx");
        }

        ds = (DataTable)Session["Card"];

        ObjGeneral = new BaseLayer.General_function();
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];

        if (objectSessionHolderPersistingData == null)
        {
            Response.Redirect("../Login.aspx");
        }
        btn_pr_ok.Visible = false;
        btn_ok.Visible = true;
        //--------------------------------------------------------chk for querystring-----------------------------------
        if (Request.QueryString["cerpacno"].ToString() != null || Request.QueryString["cerpacno"].ToString() != "" || Request.QueryString["formno"].ToString() != null || Request.QueryString["formno"].ToString() != "")
        {
            cerpac_no = Request.QueryString["cerpacno"].ToString().Trim();
            formno = Request.QueryString["formno"].ToString().Trim();
        }
        //----------------------------------------------------------------end----------------------------------------------
        
        //------------------------------------for getting data-----------------------------------------
        if (!IsPostBack)
        {
            getdata();
            imgbarcode.ImageUrl = @"~/Images/Logo/Barcode/" + cerpac_no.ToString() + "BCCode.bmp";
            imgbarcode2.ImageUrl = @"~/Images/Logo/Barcode/" + cerpac_no.ToString() + "BCCode.bmp";
        }
        //-----------------------------------------------end--------------------------------------------
       LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
        //-----------------------------------------------checking for zone ----------------------------------------
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
                Session["zone_card"] = dt.Rows[0]["ZoneName"].ToString();
                poi.Text = dt.Rows[0]["ZoneName"].ToString();
            }
        }
        catch (Exception ex)
        {
           // throw (ex);

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
        //---------------------------------------------------end------------------------------------------------------
        //-----------------------------------------------------check for print case----------------------------------
        string queryforlabel = "Select * from peoplechild where CerpacNo='" + cerpac_no + "' and FORMNO='" + formno + "'";
        objgenenral = new BaseLayer.General_function();
        DataTable dtbrown = new DataTable();
        try
        {
            dtbrown = objgenenral.FetchData(queryforlabel);
            if (dtbrown.Rows.Count > 0)
            {
                if (dtbrown.Rows[0]["IsBrown"].ToString() == "2")
                {
                    lbl_msg_cond3.Visible = true;
                    btn_ok.Visible = true;
                    btn_ok.Text = "Reprint";
                    btn_pr_ok.Visible = true;
                }
            }
        }
        catch (Exception ex)
        {
           // throw ex;

            ObjGenBal = new BaseLayer.General_function();
            string err = ObjGenBal.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.CssClass = "warning-box";
            LabelMessage.Visible = true;
        }
        finally
        {
            dtbrown = null;
            objgenenral = null;
        }
        //----------------------------------------------------------end---------------------------------------------
    }
    protected void btn_ok_Click(object sender, EventArgs e)
    {
        try
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "key", "PrintContent();", true);
            SqlParameter[] pram = null;
            pram = new SqlParameter[4];
            pram[0] = new SqlParameter("@status", "2");
            pram[1] = new SqlParameter("@userid", objectSessionHolderPersistingData.User_ID);
            pram[2] = new SqlParameter("@cerpacno", cerpac_no.ToString().Trim());
            pram[3] = new SqlParameter("@formno", formno.ToString().Trim());
            //-------------------------------------- end------------------------------------------------------
            SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_CERPAC_BROWN_CARD_PRINT", pram);
            //========================================end======================================== 

            btn_ok.Text = "Reprint";
            btn_pr_ok.Visible = true;
        }

        catch (Exception ex)
        {
            Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            ObjGenBal = new BaseLayer.General_function();
            string err = ObjGenBal.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.CssClass = "warning-box";
            LabelMessage.Visible = true;
        }
        finally
        {
          //  dt = null;
            objgenenral = null;
        }
    }

    protected void btn_pr_ok_Click(object sender, EventArgs e)
    {
        SqlParameter[] pram = null;
        pram = new SqlParameter[4];
        pram[0] = new SqlParameter("@status", "1");
        pram[1] = new SqlParameter("@userid", objectSessionHolderPersistingData.User_ID);
        pram[2] = new SqlParameter("@cerpacno", cerpac_no.ToString().Trim());
        pram[3] = new SqlParameter("@formno", formno.ToString().Trim());
        //-------------------------------------- end------------------------------------------------------
        SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_CERPAC_BROWN_CARD_PRINT", pram);
        confirm.Style.Add("display", "");
        btn_ok.Visible = false;
        btn_pr_ok.Visible = false;
        lbl_msg_cond3.Visible = false;
    }
    public void getdata()
    {
        if (ds.Rows.Count > 0)
        {
            CultureInfo c = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = c.TextInfo;
            ImgPhoto.ImageUrl = "~/Images/Logo/" + ds.Rows[0]["picture"].ToString().Trim();
            lbl_name.Text = textInfo.ToTitleCase((ds.Rows[0]["forename"].ToString() + " " + ds.Rows[0]["surname"].ToString()).ToLower());
            lbl_passport.Text = ds.Rows[0]["passport_no"].ToString().ToUpper();

            lbl_desig.Text = textInfo.ToTitleCase((ds.Rows[0]["designation"].ToString()).ToLower());
           // lbl_dob.Text = string.Format("{0:d-MM-yyyy}", ds.Rows[0]["date_of_birth"]).ToString().Trim();
            // ConvertDate(TxtIssueDate.Text.ToString(), "d-MM-yyyy")
            lbl_nationality.Text = textInfo.ToTitleCase((ds.Rows[0]["nationality"].ToString()).ToLower());
           lbl_date_of_issue.Text = string.Format("{0:d-MM-yyyy}", ds.Rows[0]["cerpac_receipt_date"]).ToString().Trim();

            lbl_expiry_date.Text = string.Format("{0:d-MM-yyyy}", ds.Rows[0]["cerpac_expiry_date"]).ToString();

            String cer_no = ds.Rows[0]["cerpac_no"].ToString().Substring(0, 1).ToUpper() + ds.Rows[0]["cerpac_no"].ToString().Substring(1);

            lbl_cerpac_no.Text = cer_no;
          //  lbl_place_of_issue.Text = textInfo.ToTitleCase((ds.Rows[0]["passport_issue_loc"].ToString()).ToLower());
         
            //Actual Card Parameters

            txt_pass_no.Text = ds.Rows[0]["passport_no"].ToString().ToUpper();
            txt_name_1.Text = textInfo.ToTitleCase((ds.Rows[0]["forename"].ToString() + " " + ds.Rows[0]["surname"].ToString()).ToLower());
           // txt_dob_2.Text = string.Format("{0:d-MM-yyyy}", ds.Rows[0]["date_of_birth"]).ToString().Trim();

            //string.Format("{0:d-MM-yyyy}", Dt.Rows[0]["passport_expiry_date"]).ToString().Trim();
            txt_desig_3.Text = textInfo.ToTitleCase((ds.Rows[0]["designation"].ToString()).ToLower());
            txt_nationality_4.Text = textInfo.ToTitleCase((ds.Rows[0]["nationality"].ToString()).ToLower());
            ImgPhoto2.Src = "~/Images/Logo/" + ds.Rows[0]["picture"].ToString().Trim();
            txt_cer_no_5.Text = cer_no;
            txt_date_of_issue_6.Text = string.Format("{0:d-MM-yyyy}", ds.Rows[0]["cerpac_receipt_date"]).ToString().Trim();
            //txt_place_of_issue_7.Text = textInfo.ToTitleCase((ds.Rows[0]["passport_issue_loc"].ToString()).ToLower());
            txt_date_of_exp_8.Text = string.Format("{0:d-MM-yyyy}", ds.Rows[0]["cerpac_expiry_date"]).ToString().Trim();

            /***************** Fetch Company *********************/
          //  String cer_no = ds.Rows[0]["cerpac_no"].ToString().Substring(0, 1).ToUpper() + ds.Rows[0]["cerpac_no"].ToString().Substring(1);

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
                comp_c.Text = textInfo.ToTitleCase(dtcomp.Rows[0]["company"].ToString().ToLower());
                txt_comps.Text = textInfo.ToTitleCase(dtcomp.Rows[0]["company"].ToString().ToLower());
            }

            /******************* End Code **********************/

        }
    }
}
