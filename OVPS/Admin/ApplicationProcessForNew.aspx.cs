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

public partial class Admin_ApplicationProcessForNew : System.Web.UI.Page
{
    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    BaseLayer.General_function objgenenral = null;
    protected DataTable dt = new DataTable();
    protected DataSet objDs = new DataSet();
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
    protected void Go_Click(object sender, EventArgs e)
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
            //-----------------------------checking for the validity of the cerpac number 10 ---------------------
            DataTable dtuploadchk = null;
            dtuploadchk = new DataTable();
            string queryforuploadchk = "Select * from uploaded_excel_data where formno='"+TextAppId.Text.ToString().Trim()+"'";
            dtuploadchk = objgenenral.FetchData(queryforuploadchk);
            if (dtuploadchk.Rows.Count==0)
            {
                lblmsg.Text = "This is an invalid Form number / Form number does not exists.";
                lblmsg.CssClass = "warning-box";
                return; 
            }
                //-----------------------------------------end of 10--------------------------------------
            string queryforzone = "Select * from CerpacNo_Out_One where cerpac_no ='" + TextAppId.Text.ToString() + "' and cerpac_file_no='" + TextAppId.Text.ToString() + "'";
            dtzone = objgenenral.FetchData(queryforzone);
            if (dtzone.Rows.Count > 0)
            {
                string queryforreject = "Select * from peoplechild where CerpacNo='" + TextAppId.Text.ToString().Trim() + "' and FORMNO='" + TextAppId.Text.ToString().Trim() + "'";
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
                string queryforsecuredform = "Select * from Uploaded_Excel_Data where FORMNO ='" + TextAppId.Text.ToString().Trim() + "'and (CerpacNo is null or CerpacNo='')";

                dtssfn = objgenenral.FetchData(queryforsecuredform);
                if (dtssfn.Rows.Count > 0)
                {

                    //System.Threading.Thread.Sleep(500);




                    string quer = "select * from People where cerpac_no='" + TextAppId.Text.ToString() + "'";
                    string querforuser = "Select a.ZoneName,b.ZoneCode from ZoneMaster as a, UserZoneRelation as b where a.ZoneCode = b.ZoneCode and b.UserId=" + objectSessionHolderPersistingData.User_ID.ToString() + "";
                    string queryfornewcase = "Select * from Issue where cerpac_no='" + TextAppId.Text.ToString() + "'";

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
                        {//----------------------------------------------checking for user zone-------------------------------
                           // if (dtuser.Rows[0]["ZoneName"].ToString().ToUpper() == "ABUJA")
                            {
                                //----------------checking for the fresh case -----------------------
                                if (dtnew.Rows.Count == 0)
                                {
                                    Response.Redirect("FrmApplicationDetailsForNew.aspx?no=" + TextAppId.Text.ToString().Trim().ToUpper() + "&fno=" + TextAppId.Text.ToString().Trim().ToUpper() + "");
                                }
                                else if (dtnew.Rows.Count > 0)
                                {
                                    lblmsg.Text = "This is not a fresh case.";
                                    lblmsg.CssClass = "warning-box";
                                    // Response.Redirect("FrmApplicationDetails.aspx?no=" + TextAppId.Text.ToString() + "&fno=" + TextAppId.Text.ToString().Trim() + "");
                                }
                                //-------------------------------------end fresh case check----------------------------------------
                            }
                            //else
                            //{
                            //    if (dtnew.Rows.Count == 0)
                            //    {
                            //        lblmsg.Text = "You are not authorized to view this CERPAC no";
                            //        lblmsg.CssClass = "warning-box";
                            //    }
                            //    else
                            //    {
                            //        Response.Redirect("FrmApplicationDetailsForNew.aspx?no=" + TextAppId.Text.ToString().Trim().ToUpper() + "&fno=" + TextAppId.Text.ToString().Trim().ToUpper() + "");
                            //    }
                            //}

                        }
                        else
                        {
                            lblmsg.Text = "The user is not associated with any zone.";
                            lblmsg.CssClass = "warning-box";
                        }

                        // }
                        //else if (dt.Rows.Count > 0 && dt.Rows[0]["IsVerified"].ToString() == "1")
                        //{
                        //    lblmsg.Text = "This Cerpac Number Has already been verified";
                        //    lblmsg.CssClass = "warning-box";
                        //}

                        //else
                        //{
                        //    lblmsg.Text = "This Cerpac Number does not exists.Please check the number and try again";
                        //    lblmsg.CssClass = "error-box";

                        //}
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
        finally
        {
             dtzone = null;
             dtzonename = null;
             dtssfn = null;
             dt = null;
             dtuser = null;
             dtnew = null;
             dtreject = null;
        }
    }
}