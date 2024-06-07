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

public partial class Admin_StickerPrintDetail : System.Web.UI.Page
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
        string queryforzonename = "select b.ZoneName from UserZoneRelation as a, Zonemaster as b where a.ZoneCode=b.ZoneCode and a.UserId=" + objectSessionHolderPersistingData.User_ID + "";
        objgenenral = new BaseLayer.General_function();
        DataTable dt = new DataTable();
        try
        {
            dt = objgenenral.FetchData(queryforzonename);
            if (dt.Rows.Count > 0)
            {
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
        if (Request.QueryString["id"] != "")
        {
            getdata(Request.QueryString["id"].ToString().Trim());
        }

    }

    public void getdata(string cerpacno)
    {
        objgenenral = new BaseLayer.General_function();
            string queryforsticker = "Select * from people as a, peoplechild as b where a.cerpac_no = b.cerpacno and a.cerpac_file_no = b.FORMNO and a.cerpac_no='" + cerpacno.ToString().Trim() + "'"; // and IsBrown=1 and IsQual=1
            DataTable dtstic = new DataTable();
            dtstic = objgenenral.FetchData(queryforsticker);
          string queryforcomp="";
            DataTable dtcomp = new DataTable();
            try
            {
                if (dtstic.Rows.Count > 0)
                {
                   //------------------------------------------------checking for company name -------------------------------------
                    address.Text = "";
                    if (cerpacno.Substring(0, 2) == "AO")
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
                        address.Text = dtcomp.Rows[0]["company"].ToString().ToUpper().Trim();
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

                    imgbarcode.ImageUrl = "~/Images/Logo/Barcode/" + cerpacno.ToString().Trim() + "BCCode.bmp";

                    //------------------------------------------------------end------------------------------------------------
                    issued.Text = string.Format("{0:dd-MM-yyyy}", dtstic.Rows[0]["cerpac_receipt_date"]).ToString().Trim();
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
                    expires.Text = string.Format("{0:dd-MM-yyyy}", dtstic.Rows[0]["cerpac_expiry_date"]).ToString().Trim();
                    audit.Text = cerpacno.ToString();
                    passportno.Text = dtstic.Rows[0]["passport_no"].ToString().ToUpper();

                    dob.Text = string.Format("{0:dd-MM-yyyy}", dtstic.Rows[0]["date_of_birth"]).ToString().Trim();
                    name.Text = dtstic.Rows[0]["forename"].ToString() + " " + dtstic.Rows[0]["surname"].ToString();
                    address1.Text = dtstic.Rows[0]["company_add_1"].ToString();
                    address2.Text = dtstic.Rows[0]["company_add_2"].ToString();
                 }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dtstic = null;
                dtcomp = null;
                objgenenral = null;
            }
        }

}