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
        BaseLayer.General_function objGenralFunction = new BaseLayer.General_function();;
        
        string strApplicationID = Convert.ToString(Request.QueryString["AppID"]);

        if (string.IsNullOrEmpty(strApplicationID) == false)
        {
            DataTable dt = new DataTable();
            double dblTotal = 0.0;
            string strQuery = "SELECT va.Rate ,vtm.flagEmove,va.flagFastTrack FROM VisaApplicationInfo AS va INNER JOIN VisaTypeMaster vtm ON va.VisaTypeCode = vtm.VisaTypeCode WHERE va.ApplicationId = " + strApplicationID + "";
            dt = objGenralFunction.FetchData(strQuery);

            if(dt.Rows.Count > 0)
            {            
                
                lblVisaFee.Text = Convert.ToString(dt.Rows[0]["Rate"]) + " USD";
                string strEmove = Convert.ToString(dt.Rows[0]["flagEmove"]);
                string strFastTrack = Convert.ToString(dt.Rows[0]["flagFastTrack"]);
                double dblFacilyCharges = 50;
                double dbleMoveCharges = 700;
                double dblFastTrackCharges = 25;
                lblFacities.Text = dblFacilyCharges + " USD";

                dblTotal = Convert.ToDouble(dt.Rows[0]["Rate"]) + dblFacilyCharges;

                if (strEmove == "N")
                {
                    trEmove.Visible = false ; 
                }
                else
                {

                    trEmove.Visible = true;
                    lblEmove.Text = dbleMoveCharges + " USD";
                    dblTotal = dblTotal + dbleMoveCharges;
                }

                if (strFastTrack  == "N")
                {
                    trFastTrack.Visible = false;
                }
                else
                {

                    trFastTrack.Visible = true;
                    lblFastTrack.Text = dblFastTrackCharges + " USD";
                    dblTotal = dblTotal + dblFastTrackCharges;
                }

                lblToal.Text  = Convert.ToString(dblTotal) + " USD";  
            }
        }

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

    protected void btmMakePayment_Click(object sender, EventArgs e)
    {
        Response.Redirect("FrmPayment.aspx");   
    }
}