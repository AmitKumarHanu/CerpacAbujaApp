using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using DataAccessLayer;

public partial class Admin_StickerPrintingProcess : System.Web.UI.Page
{
    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    BaseLayer.General_function objgenenral = null;
    BaseLayer.General_function ObjGeneral = null;
    protected BaseLayer.General_function ObjGenBal = null;

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        ObjGeneral = new BaseLayer.General_function();
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];

        if (objectSessionHolderPersistingData == null)
        {
            Response.Redirect("../Login.aspx");
        }

        Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
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
                Session["zone"] = dt.Rows[0]["ZoneName"].ToString();
            }
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            dt = null;
            objgenenral = null;
        }
        //-----------------------------------------------------check for print case----------------------------------
        string queryforlabel = "Select * from peoplechild where CerpacNo='" + TextAppId.Text.ToString().Trim() + "' and FORMNO=(Select cerpac_file_no from people where cerpac_no='"+TextAppId.Text.ToString().Trim()+"')";
        objgenenral = new BaseLayer.General_function();
        DataTable dtbrown = new DataTable();
        try
        {
            dtbrown = objgenenral.FetchData(queryforlabel);
            if (dtbrown.Rows.Count > 0)
            {
                if (dtbrown.Rows[0]["IsStickerPrinted"].ToString() == "2")
                {
                    print.Visible = true;
                    print.Text = "Reprint";
                    btnOk.Visible = true;

                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dtbrown = null;
            objgenenral = null;
        }
        //----------------------------------------------------------end---------------------------------------------

    }
    protected void Go_Click(object sender, EventArgs e)
    {
      if (TextAppId.Text != "")
        {
            objgenenral = new BaseLayer.General_function();
            string queryforsticker = "Select * from people as a, peoplechild as b where a.cerpac_no = b.cerpacno and a.cerpac_file_no = b.FORMNO and IsBrown=1 and a.cerpac_no='" + TextAppId.Text.ToString().Trim() + "'"; //0 and IsBrown=1 and IsQual=1
            DataTable dtstic = new DataTable();
            dtstic = objgenenral.FetchData(queryforsticker);
          string queryforcomp="";
            DataTable dtcomp = new DataTable();
            try
            {
                if (dtstic.Rows.Count > 0)
                {
                    //--------------------------------------for hiding the search field and displaying sticker---------------------------------
                     sticker.Style.Add("display", "");
                     print.Visible = true;
                    //----------------------------------------------------------end--------------------------------------------------

                    //------------------------------------------------checking for company name -------------------------------------
                    address.Text = "";
                    if (TextAppId.Text.Substring(0, 2) == "AO")
                    {
                        queryforcomp = "Select * from CompMaster where regno='" + dtstic.Rows[0]["company"].ToString() + "'";
                    }
                    else
                    {
                        queryforcomp = "Select * from CompMasterForARCR where regno='" + dtstic.Rows[0]["company"].ToString() + "'";
                    }
                    dtcomp = objgenenral.FetchData(queryforcomp);
                    if (dtcomp.Rows.Count > 0)
                    {
                        address.Text = dtcomp.Rows[0]["company"].ToString().Trim();
                    }
                    //---------------------------------------------- end --------------------------------------------------------

                    //----------------------------------------------------For picture-------------------------------------------
                    byte[] picData = dtstic.Rows[0]["userimage"] as byte[] ?? null;
                    System.Drawing.Image newImage;
                    if (picData != null)
                    {
                        using (MemoryStream ms = new MemoryStream(picData))
                        {
                            // Load the image from the memory stream. How you do it depends
                            // on whether you're using Windows Forms or WPF.
                            // For Windows Forms you could write:
                            // System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(ms);

                            newImage = System.Drawing.Image.FromStream(ms);

                            if (!File.Exists(Server.MapPath("~") + "/Images/Logo/" + dtstic.Rows[0]["picture"].ToString().Trim()))
                                newImage.Save(Server.MapPath("~") + "/Images/Logo/" + dtstic.Rows[0]["picture"].ToString().Trim());
                            // newImage.Save("g:/Saurabh" + Dt.Rows[0]["picture"].ToString().Trim());

                        }
                    }

                    ImgPhoto.ImageUrl = "~/Images/Logo/" + dtstic.Rows[0]["picture"].ToString().Trim();

                    //-------------------------------------------------------end-----------------------------------------------
                    //--------------------------------------------------For BarCode--------------------------------------------

                    imgbarcode.ImageUrl = "~/Images/Logo/Barcode/" + TextAppId.Text.ToString().Trim() + "BCCode.bmp";

                    //------------------------------------------------------end------------------------------------------------
                    issued.Text = string.Format("{0:d-MM-yyyy}", dtstic.Rows[0]["cerpac_receipt_date"]).ToString().Trim();
                    if (Session["zone"] != null || Session["zone"] != "")
                    {
                        at.Text = Session["zone"].ToString();
                        state.Text = Session["zone"].ToString();
                    }
                    else
                    {
                        at.Text = "--";
                        state.Text = "--";
                    }
                    expires.Text = string.Format("{0:d-MM-yyyy}", dtstic.Rows[0]["cerpac_expiry_date"]).ToString().Trim();
                    audit.Text = TextAppId.Text.ToString();
                    passportno.Text = dtstic.Rows[0]["passport_no"].ToString();
                    dob.Text = string.Format("{0:d-MM-yyyy}", dtstic.Rows[0]["date_of_birth"]).ToString().Trim();
                    name.Text = dtstic.Rows[0]["forename"].ToString() + " " + dtstic.Rows[0]["surname"].ToString();
                    address1.Text = dtstic.Rows[0]["company_add_1"].ToString();
                    address2.Text = dtstic.Rows[0]["company_add_2"].ToString();
                    hidcerpacno.Value = TextAppId.Text.ToString().Trim();
                    hidform.Value = dtstic.Rows[0]["cerpac_file_no"].ToString();

                }
            }
            catch (Exception ex)
            {
                lblmsg.Text = "Server error.Please try agian";
                lblmsg.CssClass = "warning-box";
                lblmsg.Visible = true;
            }
            finally
            {
                dtstic = null;
                dtcomp = null;
                objgenenral = null;
            }
        }
    }


    protected void print_Click(object sender, EventArgs e)
    {
        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "Onclick", "<script>window.open('StickerPrintDetail.aspx?id=" + hidcerpacno.Value.ToString().Trim() + "','Sticker','menubar=no,status=yes,Width=450,Height=1020,top=50,left=5,scrollbar=yes');</script>"); 
        SqlParameter[] pram = null;
        pram = new SqlParameter[6];
        pram[0] = new SqlParameter("@status", "2");
        pram[1] = new SqlParameter("@userid", objectSessionHolderPersistingData.User_ID);
        pram[2] = new SqlParameter("@cerpacno", hidcerpacno.Value.ToString().Trim());
        pram[3] = new SqlParameter("@formno", hidform.Value.ToString().Trim());
        pram[4] = new SqlParameter("@stickerno", "");
        pram[5] = new SqlParameter("@deedmarkno", "");
        //-------------------------------------- end------------------------------------------------------
        SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_CERPAC_STICKER_PRINT", pram);
        //========================================end======================================== 
        print.Text = "Reprint";
        btnOk.Visible = true;
    }
    protected void btnOk_Click(object sender, EventArgs e)
    {
        lbl1.Visible = true;
        StickerNo.Visible = true;
        btnSubmit.Visible = true;
        txtdeed.Visible = true;
        lbldeed.Visible = true;
        print.Visible = false;
        btnOk.Visible = false;
        searchopt.Style.Add("display", "none");
        sticker.Style.Add("display", "none");
        }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        SqlParameter[] pram = null;
        pram = new SqlParameter[6];
        pram[0] = new SqlParameter("@status", "1");
        pram[1] = new SqlParameter("@userid", objectSessionHolderPersistingData.User_ID);
        pram[2] = new SqlParameter("@cerpacno", hidcerpacno.Value.ToString().Trim());
        pram[3] = new SqlParameter("@formno", hidform.Value.ToString().Trim());
        pram[4] = new SqlParameter("@stickerno", StickerNo.Text.ToString().Trim());
        pram[5] = new SqlParameter("@deedmarkno", txtdeed.Text.ToString().Trim());
        //-------------------------------------- end------------------------------------------------------
        SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_CERPAC_STICKER_PRINT", pram);
        //========================================end======================================== 
        lbl1.Visible = false;
        StickerNo.Visible = false;
        lbldeed.Visible = false;
        txtdeed.Visible = false;
        btnSubmit.Visible = false;
        print.Visible = false;
        btnOk.Visible = false;
        lblmsg.Visible = false;
        sticker.Style.Add("display", "none");
        searchopt.Style.Add("display", "none");
        confirm.Style.Add("display", " ");
    }
}