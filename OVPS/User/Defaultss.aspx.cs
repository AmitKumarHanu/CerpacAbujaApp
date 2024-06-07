using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class User_Default : System.Web.UI.Page
{

    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    BaseLayer.General_function objgen = null;
    Label LabelMessage = null;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        if (!IsPostBack)
        {
            if (objectSessionHolderPersistingData == null)
            {
                Response.Redirect("../Login.aspx");
            }
            string query = "Select * from tbl_passwordpolicy where UserId='" + objectSessionHolderPersistingData.User_ID + "'";
            objgen = new BaseLayer.General_function();
            DataTable dt = new DataTable();
            dt = objgen.FetchData(query);
            if (dt.Rows.Count > 0)
            {
                DateTime d1 = Convert.ToDateTime(dt.Rows[0]["ChangedOn"].ToString());
                DateTime d2 = Convert.ToDateTime(DateTime.Now);
                string d3 = (d2 - d1).TotalDays.ToString();
                if (int.Parse(d3) >= 20)
                {
                    Response.Redirect("FrmChangePassword.aspx");
                }

            }
            else
            {
                Response.Redirect("FrmChangePassword.aspx");
            }
         
            // Set Application message
            if (Request.QueryString["Msg"] != null)
            {
                if (Request.QueryString["Msg"] == "Y")
                {

                    LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
                    LabelMessage.CssClass = "successmsg";
                    LabelMessage.Text = " Visa Application submitted successfully and Confirmation Email has been sent to your mail id ";
                    if (Request.QueryString["AppId"] != null)
                    {
                        string iAppId;
                        iAppId = Request.QueryString["AppId"].ToString();
                        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "VisaApp", "<script>window.open('../Admin/FrmVisaApplicationSubmit.aspx?id=" + iAppId + "','_blank','menubar=no,status=yes,Width=1000,Height=600,top=50,left=50');</script>");
                    }
                }
                else if (Request.QueryString["Msg"].ToUpper() == "UPDATE")
                {

                    LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
                    LabelMessage.CssClass = "successmsg";
                    LabelMessage.Text = " Visa Application Updated successfully ";
                    if (Request.QueryString["AppId"] != null)
                    {
                        string iAppId;
                        iAppId = Request.QueryString["AppId"].ToString();
                        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "VisaApp", "<script>window.open('../Admin/FrmVisaApplicationSubmit.aspx?id=" + iAppId + "','_blank','menubar=no,status=yes,Width=1000,Height=600,top=50,left=50');</script>");
                    }
                }
            }
        }
    }

    
}