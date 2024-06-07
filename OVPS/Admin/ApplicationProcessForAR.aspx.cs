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
using DataAccessLayer;

public partial class Admin_ApplicationProcessForAR : System.Web.UI.Page
{
    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    BaseLayer.General_function objgenenral = null;
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
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


    protected void radionewold_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (radionewold.SelectedValue == "1")
        {
            cerpfrm.Style.Add("display", "");
            TextAppId.Visible = true;
        }
        else
        {
            cerpfrm.Style.Add("display", "none");
            TextAppId.Visible = false;
        }
    }
    protected void Go_Click(object sender, EventArgs e)
    {
        objgenenral = new BaseLayer.General_function();
        double Num;
        bool isNum;
        bool isNum_f;
        try
        {
        if (radionewold.SelectedValue == "0")
        {
            isNum = double.TryParse(txtssfn.Text.Remove(0, 2), out Num);


            if (txtssfn.Text.ToString() == "" || txtssfn.Text.ToString() == string.Empty)
            {
                lblmsg.Text = "Please Enter Secured Form No";
                lblmsg.CssClass = "warning-box";
            }


            else if (txtssfn.Text.Length < 8 || txtssfn.Text.ToString().Substring(0, 2).ToUpper() != "AR" || isNum == false)
            {
                lblmsg.Text = "You have not entered correct Secured form number. Please check again.";
                lblmsg.CssClass = "warning-box";
            }
            else
            {
                TextAppId.Text = txtssfn.Text.ToString().ToUpper();
                //-------------------------------------------checking for processing at some other zone-------------------------------
                string queryforzone = "Select * from CerpacNo_Out_One where cerpac_no ='" + TextAppId.Text.ToString() + "' and cerpac_file_no='" + TextAppId.Text.ToString() + "'";
                DataTable dtzone = null;
                dtzone= new DataTable();
                dtzone = objgenenral.FetchData(queryforzone);
                if (dtzone.Rows.Count > 0)
                {
                    string zonecode = dtzone.Rows[0]["ZoneCode"].ToString().Trim();
                    string queryforzonename = "Select ZoneName from ZoneMaster where ZoneCode=" + zonecode + "";
                    DataTable dtzonename = null;
                    dtzonename = new DataTable();
                    dtzonename = objgenenral.FetchData(queryforzonename);
                    if (dtzonename.Rows.Count > 0)
                    {
                        lblmsg.Text = "This Cerpac Number is under processing at " + dtzonename.Rows[0]["ZoneName"].ToString() + " zone.";
                        lblmsg.CssClass = "warning-box";
                    }
                }
                else
                {
                    //-------------------------------------------------------end------------------------------------------------------
                    //--------------------------------------------------------code to check if the form was used or not-------------------------------------
                    DataTable dtpeoparchk = null;
                    dtpeoparchk = new DataTable();
                    string queryforarchk = "Select * from people where cerpac_no='" + txtssfn.Text.ToString().Trim() + "' or cerpac_file_no='" + txtssfn.Text.ToString().Trim() +"'";
                    dtpeoparchk = objgenenral.FetchData(queryforarchk);
                    if (dtpeoparchk.Rows.Count > 0)
                    {
                        lblmsg.Text = "This form number is already used.";
                        lblmsg.CssClass = "warning-box";
                        return;
                    }
                    //---------------------------------------------------------------end-----------------------------------------------
                    Response.Redirect("FrmApplicationDetailsForNew.aspx?no=" + TextAppId.Text.ToString().Trim().ToUpper() + "&fno=" + txtssfn.Text.ToString().Trim().ToUpper() + "");
                }
            }
        }
        else
        {
            isNum = double.TryParse(TextAppId.Text.Remove(0, 2), out Num);
            isNum_f = double.TryParse(txtssfn.Text.Remove(0, 2), out Num);

            if (TextAppId.Text.Length < 8 || TextAppId.Text.ToString().Substring(0, 2).ToUpper() != "AR" || isNum == false)
            {
                lblmsg.Text = "You have not entered correct cerpac number. Please check again.";
                lblmsg.CssClass = "warning-box";
            }

              //  isNum = double.TryParse(TextAppId.Text.Remove(0, 2), out Num);
            else if (txtssfn.Text.Length < 8 || txtssfn.Text.ToString().Substring(0, 2).ToUpper() != "AR" || isNum_f == false)
            {
                lblmsg.Text = "You have not entered correct Secured form number. Please check again.";
                lblmsg.CssClass = "warning-box";
            }

            else if (txtssfn.Text.ToString() == "" || txtssfn.Text.ToString() == string.Empty || TextAppId.Text.ToString() == "" || TextAppId.Text.ToString() == string.Empty)
            {
                lblmsg.Text = "Please Enter Secured Form No and Cerpac no.";
                lblmsg.CssClass = "warning-box";
            }
            else if (txtssfn.Text.Length < 8 || txtssfn.Text.ToString().Substring(0, 2).ToUpper() != "AR" || TextAppId.Text.Length < 8 || TextAppId.Text.ToString().Substring(0, 2).ToUpper() != "AR")
            {
                lblmsg.Text = "You have not entered correct Secured form number. Please check again.";
                lblmsg.CssClass = "warning-box";
            }
            else
            {
                string queryforzone = "Select * from CerpacNo_Out_One where cerpac_no ='" + TextAppId.Text.ToString().Trim() + "' and cerpac_file_no='" + txtssfn.Text.ToString() + "'";
                DataTable dtzone = null; 
                dtzone= new DataTable();
                dtzone = objgenenral.FetchData(queryforzone);
                if (dtzone.Rows.Count > 0)
                {
                    string zonecode = dtzone.Rows[0]["ZoneCode"].ToString().Trim();
                    string queryforzonename = "Select ZoneName from ZoneMaster where ZoneCode=" + zonecode + "";
                    DataTable dtzonename = null;
                    dtzonename= new DataTable();
                    dtzonename = objgenenral.FetchData(queryforzonename);
                    if (dtzonename.Rows.Count > 0)
                    {
                        lblmsg.Text = "This Cerpac Number is under processing at " + dtzonename.Rows[0]["ZoneName"].ToString() + " zone.";
                        lblmsg.CssClass = "warning-box";
                    }
                }
                else
                {
                    DataTable dtappar = null;
                    dtappar= new DataTable();
                    string queryforar = "Select * from People where cerpac_no='" + TextAppId.Text.ToString().Trim() + "'";


                    dtappar = objgenenral.FetchData(queryforar);
                    if (dtappar.Rows.Count > 0)
                    {
                        //--------------------------------------------------------code to check if the form was used or not-------------------------------------
                        DataTable dtpeoparchk = null;
                        dtpeoparchk = new DataTable();
                        string queryforarchk = "Select * from people where cerpac_no='" + txtssfn.Text.ToString().Trim() + "' or cerpac_file_no='" + txtssfn.Text.ToString().Trim() + "'";
                        dtpeoparchk = objgenenral.FetchData(queryforarchk);
                        if (dtpeoparchk.Rows.Count > 0)
                        {
                            lblmsg.Text = "This form number is already used.";
                            lblmsg.CssClass = "warning-box";
                            return;
                        }
                        //---------------------------------------------------------------end-----------------------------------------------

                        Response.Redirect("FrmApplicationDetails.aspx?no=" + TextAppId.Text.ToString().Trim().ToUpper() + "&fno=" + txtssfn.Text.ToString().Trim().ToUpper() + "&type=0");
                    }
                    else
                    {
                        lblmsg.Text = "This is not a renewal case.Please check again";
                        lblmsg.CssClass = "warning-box";
                    }
                }

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
        finally
        {
           
        }
    }
}