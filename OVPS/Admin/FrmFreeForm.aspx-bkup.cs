using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;

public partial class Admin_FrmFreeForm : System.Web.UI.Page
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
        string queryfrn = "Select * from peoplechild where formno='" + txtssfn.Text.ToString().Trim() + "'";
        DataTable dtfrn = null;
        dtfrn = new DataTable();
        dtfrn = objgenenral.FetchData(queryfrn);
        if (dtfrn.Rows.Count > 0)
        {
            if ((dtfrn.Rows[0]["IsProduced"].ToString().Trim() == string.Empty || dtfrn.Rows[0]["IsProduced"].ToString().Trim() == "" || dtfrn.Rows[0]["IsProduced"].ToString().Trim() == null) && (dtfrn.Rows[0]["IsQual"].ToString().Trim() == string.Empty || dtfrn.Rows[0]["IsQual"].ToString().Trim() == "" || dtfrn.Rows[0]["IsQual"].ToString().Trim() == null))
            {
                //ClientScriptManager CSM = Page.ClientScript;
                //string strconfirm = "<script>if(!window.confirm('Are you sure you want to free this form with formno="+txtssfn.Text.ToString()+" and cerpacno="+dtfrn.Rows[0]["cerpacno"].ToString()+"')){window.location.href='FrmFreeForm.aspx'}</script>";
                //CSM.RegisterClientScriptBlock(this.GetType(), "Confirm", strconfirm, false);
                string cerpac_no=dtfrn.Rows[0]["cerpacno"].ToString().Trim();
                string fileno=txtssfn.Text.ToString().Trim();
                int status = denycompletely(cerpac_no,fileno);
                if (status == 1)
                {
                    Response.Write("<script>alert('Forms Reversed Sucessfully.The Forms are now available for future use.')</script>");
                    txtssfn.Text = "";
                }
            }
            else
            {
                Response.Write("<script>alert('This form is already produced and cannot be reversed')</script>");
            }
        }
    }

    public int denycompletely(string cerpacno, string frnno)
    {
        SqlParameter[] pram = null;

        pram = new SqlParameter[5];
        pram[0] = new SqlParameter("@UserId", objectSessionHolderPersistingData.User_ID);
        pram[1] = new SqlParameter("@cerpacno", cerpacno.ToString());
        pram[2] = new SqlParameter("@frnno", frnno);
        pram[3] = new SqlParameter("@reason", "FRMF");
        pram[4] = new SqlParameter("@SuccessId", 1);
        pram[4].Direction = ParameterDirection.Output;
        SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_CERPAC_DATA_DENY_COMPLETELY", pram);
        return int.Parse(pram[4].Value.ToString());
    } 
}