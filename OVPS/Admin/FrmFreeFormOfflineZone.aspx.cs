using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_FrmFreeFormOfflineZone : System.Web.UI.Page
{
    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    BaseLayer.General_function objgenenral = null;
    protected DataTable dt = new DataTable();
    protected DataSet objDs = new DataSet();
    int timelapse = int.Parse(System.Configuration.ConfigurationManager.AppSettings["DaysLapse"]);
    string cerpac_exp_dt = "";
    string cerpac_receipt_dt = "";
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
            lblmsg.Visible = true;
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
        string queryfrnc = "Select * from uploaded_excel_data_C where FORMNO='" + txtssfn.Text.ToString().Trim() + "'";
        DataTable dtfrnc = null;
        dtfrnc = new DataTable();
        dtfrnc = objgenenral.FetchData(queryfrnc);
        if (dtfrnc.Rows.Count > 0)
        {
            if ((dtfrnc.Rows[0]["final_flag"].ToString().Trim() == "1") || (dtfrnc.Rows[0]["final_flag"].ToString().Trim() == "2"))
            {
                lblmsg.Text = "This FormNo is already sent to SAUKA for Production,So it can't be reversed from zone. Please contact sauka admin to reverse the form";
                lblmsg.CssClass = "warning-box";
                lblmsg.Font.Size = FontUnit.XSmall;
                lblmsg.Visible = true;
            }
            else
            {
                string queryfrn = "Select * from peoplechild where FORMNO='" + txtssfn.Text.ToString().Trim() + "'";
                DataTable dtfrn = new DataTable();
                dtfrn = objgenenral.FetchData(queryfrn);
                if (dtfrn.Rows.Count > 0)
                {
                    string cerpac_no = dtfrn.Rows[0]["CerpacNo"].ToString().Trim();
                    string fileno = txtssfn.Text.ToString().Trim();
                    cerpac_exp_dt = string.Format("{0:d-MM-yyyy}", dtfrn.Rows[0]["cerpac_expiry_date"]).ToString().Trim().Replace('-', '/');
                    cerpac_receipt_dt = string.Format("{0:d-MM-yyyy}", dtfrn.Rows[0]["cerpac_receipt_date"]).ToString().Trim().Replace('-', '/');
                    int status = denycompletely(cerpac_no, fileno);
                    if (status == 1)
                    {
                        try
                        {
                            int statuscentral = 0;
                            int statuszone = 0;
                            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["con"].ToString();
                            string qury = "Update Uploaded_excel_data set cerpac_no = null where FORMNO='" + fileno.Trim() + "'";
                            SqlConnection concentral = new SqlConnection(constring);
                            SqlCommand cmd = new SqlCommand(qury, concentral);
                            concentral.Open();
                            statuscentral = cmd.ExecuteNonQuery();
                            concentral.Close();
                            if (statuscentral == 1)
                            {
                                string constr = System.Configuration.ConfigurationManager.ConnectionStrings["NigeriaConnectionString"].ToString();
                                string quryzone = "delete from  Uploaded_excel_data where FORMNO='" + fileno.Trim() + "'";
                                SqlConnection conzone = new SqlConnection(constr);
                                SqlCommand cmdzone = new SqlCommand(quryzone, conzone);
                                conzone.Open();
                                statuszone = cmdzone.ExecuteNonQuery();
                                conzone.Close();
                                if (statuszone == 1)
                                {
                                    lblmsg.Text = "Formno reversed sucessfully";
                                    lblmsg.CssClass = "confirmation-box";
                                    lblmsg.Visible = true;
                                }
                                else
                                {

                                }
                            }
                            else
                            {
                                lblmsg.Text = "Forms were reversed sucessfully in zone but not in central due to non connectivity. Please send the encrypted file to the central server";
                                lblmsg.Font.Size = FontUnit.XSmall;
                                lblmsg.CssClass = "confirmation-box";
                                lblmsg.Visible = true;
                            }
                        }
                        catch
                        {
                            lblmsg.Text = "Forms were reversed sucessfully in zone but not in central due to non connectivity. Please send the encrypted file to the central server";
                            lblmsg.Font.Size = FontUnit.XSmall;
                            lblmsg.CssClass = "confirmation-box";
                            lblmsg.Visible = true;
                        }

                    }
                }
                else
                {
                    lblmsg.Text = "No Data Found";
                    lblmsg.CssClass = "warning-box";
                    lblmsg.Visible = true;
                }
            }
        }
    }

    public int denycompletely(string cerpacno, string frnno)
    {
        SqlParameter[] pram = null;

        pram = new SqlParameter[7];
        pram[0] = new SqlParameter("@UserId", objectSessionHolderPersistingData.User_ID);
        pram[1] = new SqlParameter("@cerpacno", cerpacno.ToString());
        pram[2] = new SqlParameter("@frnno", frnno);
        pram[3] = new SqlParameter("@reason", "FRMF");
        pram[4] = new SqlParameter("@cerpac_expiry_date", cerpac_exp_dt.Trim());
        pram[5] = new SqlParameter("@cerpac_receipt_date", cerpac_receipt_dt.Trim());
        pram[6] = new SqlParameter("@SuccessId", 1);
        pram[6].Direction = ParameterDirection.Output;
        SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_CERPAC_DATA_FREE_FORM_OFFLINE", pram);
        return int.Parse(pram[6].Value.ToString());
    } 
}