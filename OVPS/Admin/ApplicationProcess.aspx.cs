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
using System.Globalization;

public partial class Admin_ApplicationProcess : System.Web.UI.Page
{

    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    BaseLayer.General_function objgenenral = null;
    protected DataTable dt = new DataTable();
    protected DataSet objDs = new DataSet();
    int timelapse = int.Parse(System.Configuration.ConfigurationManager.AppSettings["DaysLapse"]);
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        if (objectSessionHolderPersistingData == null)
        {
            Response.Redirect("../Login.aspx");
        }

        Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
        string queryforzonename = "select b.ZoneName from UserZoneRelation as a, Zonemaster as b where a.ZoneCode=b.ZoneCode and a.UserId="+objectSessionHolderPersistingData.User_ID+"";
        objgenenral = new BaseLayer.General_function();
        DataTable dt = new DataTable();
        try
        {
            dt = objgenenral.FetchData(queryforzonename);
            if (dt.Rows.Count > 0)
            {
                LabelMessage.Text = "Zone" +" "+ dt.Rows[0]["ZoneName"].ToString();
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
    protected void lnkfind_Click(object sender, EventArgs e)
    {
        Response.Redirect("FrmViewAppHistory.aspx");
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
            //--------------------------------checking for the validity of the cerpac number ----------------------------------
            DataTable dtpplchk = null;
            dtpplchk = new DataTable();
            string queryforpplchk = "Select * from people where cerpac_no='" + TextAppId.Text.ToString().Trim() + "'";
            dtpplchk = objgenenral.FetchData(queryforpplchk);
            if (dtpplchk.Rows.Count == 0)
            {
                lblmsg.Text = "This is an invalid Cerpac number / Cerpac number does not exists.";
                lblmsg.CssClass = "warning-box";
                return;
            }
            //------------------------------------------ end of validity of cerpac number ---------------------------------------
            //-----------------------------checking for the validity of the form number 10 ---------------------
            DataTable dtuploadchk = null;
            dtuploadchk = new DataTable();
            string queryforuploadchk = "Select * from uploaded_excel_data where formno='" + txtssfn.Text.ToString().Trim() + "'";
            dtuploadchk = objgenenral.FetchData(queryforuploadchk);
            if (dtuploadchk.Rows.Count == 0)
            {
                lblmsg.Text = "This is an invalid Form number / Form number does not exists.";
                lblmsg.CssClass = "warning-box";
                return;
            }
            //-----------------------------------------end of 10--------------------------------------

           string queryforzone = "Select * from CerpacNo_Out_One where cerpac_no ='" + TextAppId.Text.ToString() + "' and cerpac_file_no='" + txtssfn.Text.ToString() + "'";
            dtzone = objgenenral.FetchData(queryforzone);
            if (dtzone.Rows.Count > 0)
            {
                //----------------------------------------------------- for finding the zone of processing----------------------------
                string queryforreject = "Select * from peoplechild where CerpacNo='" + TextAppId.Text.ToString().Trim() + "' and FORMNO='" + txtssfn.Text.ToString().Trim() + "'";
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
                //-----------------------------------------------------------------------end--------------------------------------------
            }
            else
            {
                string queryforsecuredform = "Select * from Uploaded_Excel_Data where FORMNO ='" + txtssfn.Text.ToString().Trim() + "' and (CerpacNo is null or CerpacNo='')";

                dtssfn = objgenenral.FetchData(queryforsecuredform);
                if (dtssfn.Rows.Count > 0)
                {

                    //System.Threading.Thread.Sleep(500);
                    string queryforpeople = "Select * from people where cerpac_no='" + TextAppId.Text.ToString() + "'";
                    string quer = "select a.*,b.* from People as a , PeopleChild as b where a.cerpac_no = b.CerpacNo and a.cerpac_no='" + TextAppId.Text.ToString() + "' and b.FORMNO='" + txtssfn.Text.ToString().Trim() + "'";
                    string querforuser = "Select a.ZoneName,b.ZoneCode from ZoneMaster as a, UserZoneRelation as b where a.ZoneCode = b.ZoneCode and b.UserId=" + objectSessionHolderPersistingData.User_ID.ToString() + "";
                    string queryfornewcase = "Select * from Issue ";//where cerpac_no='" + TextAppId.Text.ToString() + "'
                    DataTable dtpeople = new DataTable();
                    dtpeople = objgenenral.FetchData(queryforpeople);

                    dt = objgenenral.FetchData(quer);

                    dtuser = objgenenral.FetchData(querforuser);

                    dtnew = objgenenral.FetchData(queryfornewcase);
                    //---------------------------------------------check for date of purchase and date of expiry----------------------------------------------------
                    DateTime purchasedate = Convert.ToDateTime(ConvertDate(string.Format("{0:d-MM-yyyy}", dtssfn.Rows[0]["Date1"]).ToString().Trim(),"d-MM-yyyy"));
                    DateTime expirydate = Convert.ToDateTime(ConvertDate(string.Format("{0:d-MM-yyyy}", dtpeople.Rows[0]["cerpac_expiry_date"]).ToString().Trim(),"d-MM-yyyy"));
                    string datediff = (purchasedate - expirydate).TotalDays.ToString();
                    //---------------------------------------------------- end here-----------------------------------------------------------------

                    //-------------------------------------------checking for the verification of cerpac no----------------------------------
                    if (dtpeople.Rows.Count > 0)
                    {
                        if (dt == null)
                        {
                            if (dt.Rows[0]["IsVerified"] == "1")
                            {
                                lblmsg.Text = "This Cerpac Number Has been processed but awaiting Approval.";
                                lblmsg.CssClass = "warning-box";
                            }
                       }
                        else
                        {
                            if (dtuser.Rows.Count > 0)
                            {//----------------------------------------------checking for user zone-------------------------------
                                if (dtuser.Rows[0]["ZoneName"].ToString().ToUpper() == "ABUJA")
                                {
                                    //----------------checking for the fresh case -----------------------
                                    if (dtnew.Rows.Count == 0)
                                    {
                                        //commented on 27 oct 13
                                       // Response.Redirect("FrmApplicationDetails.aspx?no=" + TextAppId.Text.ToString().Trim().ToUpper() + "&fno=" + txtssfn.Text.ToString().Trim().ToUpper() + "");

                                        lblmsg.Text = "This is not a renewal case.";
                                        lblmsg.CssClass = "warning-box";

                                    }
                                    else if (dtnew.Rows.Count > 0)
                                    {

                                        if (int.Parse(datediff) > timelapse)
                                        {
                                            radbrkcnt.Visible = true;
                                            lblmsg.Text = "The validity of this form is discontinued.Please use it as new form.";
                                            lblmsg.CssClass = "information-box";
                                        }
                                        else
                                        {
                                            Response.Redirect("FrmApplicationDetails.aspx?no=" + TextAppId.Text.ToString().Trim().ToUpper() + "&fno=" + txtssfn.Text.ToString().Trim().ToUpper() + "&type=0");
                                        }
                                    }
                                    else
                                    {
                                        lblmsg.Text = "This is not a fresh case.";
                                        lblmsg.CssClass = "warning-box";
                                    }
                                    //-------------------------------------end fresh case check----------------------------------------
                                }
                                else
                                {
                                    if (dtnew.Rows.Count == 0)
                                    {
                                        //commented on 27 oct 13
                                        // lblmsg.Text = "You are not authorized to view this CERPAC no";
                                        lblmsg.Text = "This is not a renewal case.";
                                        lblmsg.CssClass = "warning-box";
                                    }
                                    else
                                    {
                                        if (int.Parse(datediff) > timelapse)
                                        {
                                            radbrkcnt.Visible = true;
                                        }
                                        else
                                        {
                                            Response.Redirect("FrmApplicationDetails.aspx?no=" + TextAppId.Text.ToString().Trim().ToUpper() + "&fno=" + txtssfn.Text.ToString().Trim().ToUpper() + "&type=0");
                                        }
                                    }
                                }

                            }

                        }
                    }
                    else
                    {
                        lblmsg.Text = "This is not a renewal case";
                        lblmsg.CssClass = "warning-box";
                    }
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
                else
                {
                    lblmsg.Text = "This Form number has already been processed.";
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

    protected void radbrkcnt_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (radbrkcnt.SelectedValue == "1")
        {
            Response.Redirect("FrmApplicationDetails.aspx?no=" + TextAppId.Text.ToString().Trim().ToUpper() + "&fno=" + txtssfn.Text.ToString().Trim().ToUpper() + "&type=1");
        }
        else if (radbrkcnt.SelectedValue == "2")
        {
            Response.Redirect("FrmApplicationDetails.aspx?no=" + TextAppId.Text.ToString().Trim().ToUpper() + "&fno=" + txtssfn.Text.ToString().Trim().ToUpper() + "&type=2");
        }
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
}
