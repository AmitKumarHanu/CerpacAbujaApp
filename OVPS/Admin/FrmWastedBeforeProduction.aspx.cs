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
using System.Xml;
using System.Data.SqlClient;
using DataAccessLayer;

//------------------
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text.RegularExpressions;
using System.Net.Mail;
//using Microsoft.Reporting.WebForms;

using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Net;
using System.Windows;
using SHDocVw;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Web.Services;
using System.Web.Script.Services;

public partial class Admin_FrmWastedBeforeProduction : System.Web.UI.Page
{
    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
   BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    #endregion

   
    BaseLayer.General_function objGeneral = null;
    BusinessEntityLayer.BalDocdetails ObjBalDocdetails = null;
          
    protected void Page_Load(object sender, EventArgs e)
    {
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        if (objectSessionHolderPersistingData == null)
        {
            Response.Redirect("../Login.aspx");
        }
        string companyid = objectSessionHolderPersistingData.CompanyId;
        Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
        try
        {
            LabelMessage.CssClass = "";
            LabelMessage.Text = "";
           
            if (!IsPostBack)
            {
                btnSave.Visible = true ;
                btnCancel.Visible = true;
            }

          
        }
        catch (Exception ex)
        {
            objGeneral = new BaseLayer.General_function();
            //Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            string err = objGeneral.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.CssClass = "warning-box";
            LabelMessage.Visible = true;
        }
    }
    /*********************Select Statement by country code************/

   
    
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        
        Response.Redirect("FrmWastedBeforeProduction.aspx");
    }



    protected void btnSave_Click(object sender, EventArgs e)
    {
        Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");

        try
        {


            lblstatus.Visible = false;

            DataTable dt1 = null;
            dt1 = new DataTable();

            DataTable dt2 = null;
            dt2 = new DataTable();

            DataTable dt2f = null;
            dt2f = new DataTable();

            DataTable dt2b = null;
            dt2b = new DataTable();


            DataTable dt3 = null;
            dt3 = new DataTable();

            DataTable dt4 = null;
            dt4 = new DataTable();

            DataTable dt5 = null;
            dt5 = new DataTable();
            DataTable dt6 = null;
            dt6 = new DataTable();
            DataTable dt7 = null;
            dt7 = new DataTable();
            DataTable dt8 = null;
            dt8 = new DataTable();

            objGeneral = new BaseLayer.General_function();
            string Message = string.Empty;
            string Qry1, Qry2, Qry3, Qry4, Qry5, Qry6, Qry7, Qry2f, Qry2b, Qry8;

            if (rd1.Checked == true)
            {
                //----------------CerpacNo----------------

                if (txtCerpacNo.Text != "")
                {
                    Qry2 = "Select top 1  Cerpac_no from people a, PeopleChild b where a.cerpac_no=b.CerpacNo and a.cerpac_no='" + txtCerpacNo.Text + "'";
                    dt2 = objGeneral.FetchData(Qry2);
                    if (dt2.Rows.Count <= 0)
                    {

                        Message = "Please enter correct Cerpac No ";
                        LabelMessage.CssClass = "errormsg";
                        LabelMessage.Text = Message;//"Record Can not be updated";
                        LabelMessage.Visible = true;
                        return;
                    }
                }
                else if (txtCerpacNo.Text == "")
                {
                    Message = "Please enter Cerpac No ";
                    LabelMessage.CssClass = "errormsg";
                    LabelMessage.Text = Message;//"Record Can not be updated";
                    LabelMessage.Visible = true;
                    return;
                }

                //----------------Cerpac File No----------------

                if (txtCerpacFileNo.Text != "")
                {
                    Qry2 = "Select top 1  Cerpac_File_no from people a, PeopleChild b where a.cerpac_no=b.CerpacNo and a.cerpac_file_no=b.formno and b.formno='" + txtCerpacFileNo.Text + "' and b.IsProduced<>1 and b.IsVerified=1 and b.IsAuthorized=1 and b.ISARCR=1 and b.IsQual=0";
                    dt2 = objGeneral.FetchData(Qry2);
                    if (dt2.Rows.Count <= 0)
                    {

                        Message = "Please enter correct Cerpac file No.";
                        LabelMessage.CssClass = "errormsg";
                        LabelMessage.Text = Message;//"Record Can not be updated";
                        LabelMessage.Visible = true;
                        return;
                    }
                }
                else if (txtCerpacFileNo.Text == "")
                {
                    Message = "Please enter Cerpac file No ";
                    LabelMessage.CssClass = "errormsg";
                    LabelMessage.Text = Message;//"Record Can not be updated";
                    LabelMessage.Visible = true;
                    return;
                }
                //--------Card No is not Empty---------------

                if (txtCardNo.Text != "")
                {
                    Qry1 = "Select StickerNumber , StickerPrintedYN from UserStickerRelation where StickerNumber='" + txtCardNo.Text + "' and StickerWastedYN=1";
                    dt1 = objGeneral.FetchData(Qry1);
                    if (dt1.Rows.Count < 0)
                    {

                        Message = "This Card no. is already wasted ";
                        LabelMessage.CssClass = "errormsg";
                        LabelMessage.Text = Message;//"Record Can not be updated";
                        LabelMessage.Visible = true;
                        return;
                    }
                }
                else if (txtCardNo.Text == "")
                {
                    //-- user sticker relation
                    //lblstatus.Visible = true;
                    Message = "Plase enter Card No ";
                    LabelMessage.CssClass = "errormsg";
                    LabelMessage.Text = Message;//"Record Can not be updated";
                    LabelMessage.Visible = true;
                    return;
                }


                //-----------Front Lamination-------------------
                if (txt_front_lam.Text != "")
                {
                    Qry2f = "Select  lam_no from tbl_lamination_detail where  lamflag_f_b='F' and lam_no='" + txt_front_lam.Text + "'";
                    dt2f = objGeneral.FetchData(Qry2f);
                    if (dt2f.Rows.Count <= 0)
                    {

                        Message = "Please enter correct front lamination no. ";
                        LabelMessage.CssClass = "errormsg";
                        LabelMessage.Text = Message;//"Record Can not be updated";
                        LabelMessage.Visible = true;
                        return;
                    }
                }
                else if (txt_front_lam.Text == "")
                {
                    Message = "Please enter front lamination no. ";
                    LabelMessage.CssClass = "errormsg";
                    LabelMessage.Text = Message;//"Record Can not be updated";
                    LabelMessage.Visible = true;
                    return;
                }
                //-----------Back Lamination---------------------
                if (txt_back_lam.Text != "")
                {
                    Qry2b = "Select  lam_no from tbl_lamination_detail where  lamflag_f_b='B' and lam_no='" + txt_back_lam.Text + "' ";
                    dt2b = objGeneral.FetchData(Qry2b);
                    if (dt2b.Rows.Count <= 0)
                    {

                        Message = "Please enter correct back lamination no. ";
                        LabelMessage.CssClass = "errormsg";
                        LabelMessage.Text = Message;//"Record Can not be updated";
                        LabelMessage.Visible = true;
                        return;

                    }
                }
                else if (txt_back_lam.Text == "")
                {
                    Message = "Please enter back lamination no. ";
                    LabelMessage.CssClass = "errormsg";
                    LabelMessage.Text = Message;//"Record Can not be updated";
                    LabelMessage.Visible = true;
                    return;
                }


                //--------------Case 3-------------------
                if (txtCardNo.Text != "" && txtCerpacNo.Text != "" && txt_front_lam.Text != "" && txt_back_lam.Text != "" && txtCerpacFileNo.Text != "")
                {
                    Qry3 = "Select * from UserStickerRelation where StickerNumber='" + txtCardNo.Text + "' and StickerWastedYN =1 and StickerPrintedYN =1 ";
                    dt3 = objGeneral.FetchData(Qry3);

                    if (dt3.Rows.Count > 0)
                    {
                        Message = "This card No. is already wasted in production.";
                        LabelMessage.CssClass = "errormsg";
                        LabelMessage.Text = Message;//"Record Can not be updated";
                        LabelMessage.Visible = true;
                        return;
                    }


                    Qry4 = "Select  lam_no from tbl_lamination_detail where  lamflag_f_b='F' and lam_no='" + txt_front_lam.Text + "' and lam_wastedYN=1";
                    dt4 = objGeneral.FetchData(Qry4);

                    if (dt4.Rows.Count > 0)
                    {
                        Message = "Front lamination No. is already wasted.";
                        LabelMessage.CssClass = "errormsg";
                        LabelMessage.Text = Message;//"Record Can not be updated";
                        LabelMessage.Visible = true;
                        return;
                    }
                    Qry4 = "Select  lam_no from tbl_lamination_detail where  lamflag_f_b='B' and lam_no='" + txt_back_lam.Text + "' and lam_wastedYN=1";
                    dt4 = objGeneral.FetchData(Qry4);

                    if (dt4.Rows.Count > 0)
                    {
                        Message = "Back lamination No. is already wasted.";
                        LabelMessage.CssClass = "errormsg";
                        LabelMessage.Text = Message;//"Record Can not be updated";
                        LabelMessage.Visible = true;
                        return;
                    }

                    Qry5 = "Select * from UserStickerRelation where StickerNumber='" + txtCardNo.Text + "' and StickerPrintedYN =0 and StickerWastedYN =0";
                    dt5 = objGeneral.FetchData(Qry5);


                    if (dt5.Rows.Count > 0)
                    {
                        Qry6 = " Update UserStickerRelation Set StickerWastedYN=@StickerWastedYN, StickerPrintedYN=@StickerPrintedYN, StickerIssuedToApplicationID =@StickerIssuedToApplicationID, StickerWastedReason=@StickerWastedReason   where StickerNumber ='" + txtCardNo.Text + "'";

                        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionstring"].ToString());
                        cn.Open();
                        SqlCommand cmd = new SqlCommand(Qry6, cn);
                        cmd.Parameters.Add("@StickerWastedYN", 1);
                        cmd.Parameters.Add("@StickerPrintedYN", 1);
                        cmd.Parameters.Add("@StickerIssuedToApplicationID", txtCerpacNo.Text);
                        cmd.Parameters.Add("@StickerWastedReason", "WastedBeforeProduction");
                        cmd.ExecuteNonQuery();
                        cn.Close();

                        Qry6 = "update tbl_lamination_detail set lam_wastedYN=1, lam_printedYN=1, lam_issued_cerpac_no=@cerpac_no, lam_issued_cerpac_fileno = @formno, card_no=@CardNo, created_on=@WastedOn,created_by=@WastedBy where lam_No='" + txt_front_lam.Text.ToString() + "' and lamflag_f_b= 'F'";
                        SqlConnection cnL = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionstring"].ToString());
                        cnL.Open();
                        SqlCommand cmdL = new SqlCommand(Qry6, cnL);
                        cmdL.Parameters.Add("@cerpac_no", txtCerpacNo.Text);
                        cmdL.Parameters.Add("@formno", txtCerpacFileNo.Text);
                        cmdL.Parameters.Add("@CardNo", txtCardNo.Text);
                        cmdL.Parameters.Add("@WastedBy", int.Parse(objectSessionHolderPersistingData.User_ID));
                        cmdL.Parameters.Add("@WastedOn", DateTime.Now.ToShortDateString());
                        cmdL.ExecuteNonQuery();
                        cnL.Close();

                        Qry6 = "update tbl_lamination_detail set lam_wastedYN=1, lam_printedYN=1, lam_issued_cerpac_no=@cerpac_no, lam_issued_cerpac_fileno = @formno, card_no=@CardNo, created_on=@WastedOn,created_by=@WastedBy where lam_No='" + txt_back_lam.Text.ToString() + "' and lamflag_f_b= 'B'";
                        SqlConnection cnB = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionstring"].ToString());
                        cnB.Open();
                        SqlCommand cmdB = new SqlCommand(Qry6, cnB);
                        cmdB.Parameters.Add("@cerpac_no", txtCerpacNo.Text);
                        cmdB.Parameters.Add("@formno", txtCerpacFileNo.Text);
                        cmdB.Parameters.Add("@CardNo", txtCardNo.Text);
                        cmdB.Parameters.Add("@WastedBy", int.Parse(objectSessionHolderPersistingData.User_ID));
                        cmdB.Parameters.Add("@WastedOn", DateTime.Now.ToShortDateString());
                        cmdB.ExecuteNonQuery();
                        cnB.Close();




                        Qry7 = "Select StickerNumber, StickerWastedYN from UserStickerRelation where StickerNumber='" + txtCardNo.Text + "' and StickerWastedYN =1";
                        Qry8 = "Select  * from tbl_lamination_detail where card_no='" + txtCardNo.Text + "' and lam_issued_cerpac_fileno='" + txtCerpacFileNo.Text + "' and lam_issued_cerpac_no='" + txtCerpacNo.Text + "' and lam_wastedYN=1";
                        dt7 = objGeneral.FetchData(Qry7);
                        dt8 = objGeneral.FetchData(Qry8);
                        if (dt7.Rows.Count > 0 && dt8.Rows.Count > 0)
                        {
                            LabelMessage.Visible = true;
                            lblstatus.Visible = false;
                            LabelMessage.Text = "Saved Sucessfully in Card Waste Records";
                            LabelMessage.CssClass = "confirmation-box";
                            // Response.Redirect("FrmWastedBeforeProduction.aspx");
                        }

                    }
                    else
                    {
                        Message = "Card no. is successful print by production module";
                        LabelMessage.CssClass = "errormsg";
                        LabelMessage.Text = Message;//"Record Can not be updated";
                        LabelMessage.Visible = true;
                        return;
                    }
                }
            }
            if (rd2.Checked == true)
            {
                //-----------Front Lamination-------------------
                if (txt_front_lam.Text != "")
                {
                    Qry2f = "Select  lam_no from tbl_lamination_detail where  lamflag_f_b='F'  and lam_no='" + txt_front_lam.Text + "'";
                    dt2f = objGeneral.FetchData(Qry2f);
                    if (dt2f.Rows.Count <= 0)
                    {

                        Message = "Please enter correct Front Lamination No. ";
                        LabelMessage.CssClass = "errormsg";
                        LabelMessage.Text = Message;//"Record Can not be updated";
                        LabelMessage.Visible = true;
                        return;
                    }
                }
                else if (txt_front_lam.Text == "")
                {
                    Message = "Please enter front lamination No. ";
                    LabelMessage.CssClass = "errormsg";
                    LabelMessage.Text = Message;//"Record Can not be updated";
                    LabelMessage.Visible = true;
                    return;
                }
                //-----------Back Lamination---------------------
                if (txt_back_lam.Text != "")
                {
                    Qry2b = "Select  lam_no from tbl_lamination_detail where  lamflag_f_b='B' and lam_no='" + txt_back_lam.Text + "'";
                    dt2b = objGeneral.FetchData(Qry2b);
                    if (dt2b.Rows.Count <= 0)
                    {

                        Message = "Please enter correct back lamination no. ";
                        LabelMessage.CssClass = "errormsg";
                        LabelMessage.Text = Message;//"Record Can not be updated";
                        LabelMessage.Visible = true;
                        return;

                    }
                }
                else if (txt_back_lam.Text == "")
                {
                    Message = "Please enter back lamination no. ";
                    LabelMessage.CssClass = "errormsg";
                    LabelMessage.Text = Message;//"Record Can not be updated";
                    LabelMessage.Visible = true;
                    return;
                }


                //------------------------Case 4 --------------------------------
                string QryS1, QryS2;

                DataTable dtS1 = null;
                dtS1 = new DataTable();
                DataTable dtS2 = null;
                dtS2 = new DataTable();



                if (txt_front_lam.Text != "" && txt_back_lam.Text != "" && txtCardNo.Text == "0" && txtCerpacNo.Text == "0")
                {
                    QryS1 = "Select * From tbl_lamination_detail where (lam_No='" + txt_front_lam.Text + "' and lamflag_f_b='F' and  lam_wastedYN=1) ";
                    QryS2 = "Select * From tbl_lamination_detail where (lam_No='" + txt_back_lam.Text + "' and lamflag_f_b='B' and  lam_wastedYN=1) ";
                    dtS1 = objGeneral.FetchData(QryS1);
                    dtS2 = objGeneral.FetchData(QryS2);
                    if (dtS1.Rows.Count > 0)
                    {
                        Message = "Front Lamination No. already wasted ";
                        LabelMessage.CssClass = "errormsg";
                        LabelMessage.Text = Message;//"Record Can not be updated";
                        LabelMessage.Visible = true;
                        return;
                    }
                    if (dtS2.Rows.Count > 0)
                    {
                        Message = "Back Lamination No. already wasted ";
                        LabelMessage.CssClass = "errormsg";
                        LabelMessage.Text = Message;//"Record Can not be updated";
                        LabelMessage.Visible = true;
                        return;

                    }

                    if (dtS1.Rows.Count <= 0 && dtS2.Rows.Count <= 0)
                    {

                        Qry6 = "update tbl_lamination_detail set lam_wastedYN=1, lam_issued_cerpac_no=@cerpac_no, card_no=@CardNo, created_on=@WastedOn,created_by=@WastedBy where lam_No='" + txt_front_lam.Text.ToString() + "' and lamflag_f_b= 'F'";
                        SqlConnection cnL = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionstring"].ToString());
                        cnL.Open();
                        SqlCommand cmdL = new SqlCommand(Qry6, cnL);
                        cmdL.Parameters.Add("@cerpac_no", txtCerpacNo.Text);
                        cmdL.Parameters.Add("@CardNo", txtCardNo.Text);
                        cmdL.Parameters.Add("@WastedBy", int.Parse(objectSessionHolderPersistingData.User_ID));
                        cmdL.Parameters.Add("@WastedOn", DateTime.Now.ToShortDateString());
                        cmdL.ExecuteNonQuery();
                        cnL.Close();

                        Qry6 = "update tbl_lamination_detail set lam_wastedYN=1, lam_issued_cerpac_no=@cerpac_no, card_no=@CardNo, created_on=@WastedOn,created_by=@WastedBy where lam_No='" + txt_back_lam.Text.ToString() + "' and lamflag_f_b= 'B'";
                        SqlConnection cnB = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionstring"].ToString());
                        cnB.Open();
                        SqlCommand cmdB = new SqlCommand(Qry6, cnB);
                        cmdB.Parameters.Add("@cerpac_no", txtCerpacNo.Text);
                        cmdB.Parameters.Add("@CardNo", txtCardNo.Text);
                        cmdB.Parameters.Add("@WastedBy", int.Parse(objectSessionHolderPersistingData.User_ID));
                        cmdB.Parameters.Add("@WastedOn", DateTime.Now.ToShortDateString());
                        cmdB.ExecuteNonQuery();
                        cnB.Close();

                        QryS1 = "Select * From tbl_lamination_detail where (lam_No='" + txt_front_lam.Text + "' and lamflag_f_b='F' and lam_wastedYN=1) ";
                        QryS2 = "Select * From tbl_lamination_detail where (lam_No='" + txt_back_lam.Text + "' and lamflag_f_b='B' and lam_wastedYN=1) ";
                        dtS1 = objGeneral.FetchData(QryS1);
                        dtS2 = objGeneral.FetchData(QryS2);


                        if (dtS1.Rows.Count > 0 && dtS2.Rows.Count > 0)
                        {
                            LabelMessage.Visible = true;
                            lblstatus.Visible = false;
                            LabelMessage.Text = "Saved Sucessfully in Waste lamination Records";
                            LabelMessage.CssClass = "confirmation-box";
                            //Response.Redirect("FrmWastedBeforeProduction.aspx");
                        }

                    }
                }
            }
        }
        catch (Exception ex)
        {
            objGeneral = new BaseLayer.General_function();
            //Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            string err = objGeneral.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.CssClass = "warning-box";
            LabelMessage.Visible = true;
        }
    }      
        
    

    protected void rd1_CheckedChanged(object sender, EventArgs e)
    {
        if (rd1.Checked == true)
        {
            tr_cerpac.Style.Add("display", "");
            tr_card.Style.Add("display", "");
	    tr_cerpac_file.Style.Add("display", "");

        }
        if (rd2.Checked == true)
        {
            tr_cerpac.Style.Add("display", "none");
            tr_card.Style.Add("display", "none");
            tr_cerpac_file.Style.Add("display", "none");
            txtCerpacNo.Text = "0";
            txtCardNo.Text = "0";
            txtCerpacFileNo.Text = "0";
        }

    }
}