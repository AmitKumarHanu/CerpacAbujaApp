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

    protected void btnCancel_Click(object sender, EventArgs e)
    {

        Response.Redirect("Default.aspx");   


    }
}