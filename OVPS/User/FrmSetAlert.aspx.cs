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

public partial class User_FrmSetAlert : System.Web.UI.Page
{
    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        ActionDate.HRef = "javascript:NewCal('" + TextActionDate.ClientID + "','DDMMMYYYY')";
        if (!IsPostBack)
        {

            if (Request.QueryString["DocNo"] != null)
            {               
                FillAlertData(Request.QueryString["DocNo"].ToString());
            }
        }
    }
    private void FillAlertData(string DocId)
    {
        DataAccessLayer.DalFileUpload ObjDal = null;
        DataTable dt = null;
        try
        {
            ObjDal = new DataAccessLayer.DalFileUpload();
            dt = ObjDal.FetchDocAlertByDocId(Convert.ToInt32(DocId));
            if (dt.Rows.Count > 0)
            {
                txtAlertType.Text = dt.Rows[0]["AlertType"].ToString();
                TextActionDate.Value = dt.Rows[0]["ActionDate"].ToString();
                ddlNDays.SelectedValue = dt.Rows[0]["NotificationDays"].ToString();
                CheckBoxEmailAlert.Checked = Convert.ToBoolean(dt.Rows[0]["IsEmailAlert"].ToString());
                TextBoxAlertDesc.Text = dt.Rows[0]["AlertDesc"].ToString();
                if (!string.IsNullOrEmpty(dt.Rows[0]["ActionRemark"].ToString()))
                {
                    BtnAlertSet.Text = "Action has been taken on this Alert";
                    BtnAlertSet.Enabled = false;
                    BtnAlertSet.BorderStyle = BorderStyle.Solid;
                }
                else
                {
                    BtnAlertSet.Text = "Update";
                }

            }
        }
        catch (Exception ex)
        {
            //Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            LabelMessage.CssClass = "errormsg";
            LabelMessage.Text = ex.Message.ToString();
        }
    }

    protected void BtnAlertSet_Click(object sender, EventArgs e)
    {
        string DocId = Request.QueryString["DocNo"];
        DataAccessLayer.DalFileUpload objDal = null;
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        int status = 0;
        string Msg = null;
        try
        {
            objDal = new DataAccessLayer.DalFileUpload();
            if (BtnAlertSet.Text == "submit")
            {

                status = objDal.InsertDocAlert(Convert.ToInt16(DocId), txtAlertType.Text, TextBoxAlertDesc.Text, TextActionDate.Value, Convert.ToInt16(ddlNDays.SelectedValue), CheckBoxEmailAlert.Checked, objectSessionHolderPersistingData.User_ID);
                Msg = "Document Alert has been set";
                BtnAlertSet.Enabled = false;
            }
            else
            {
                status = objDal.UpdateDocAlert(Convert.ToInt16(DocId), txtAlertType.Text, TextBoxAlertDesc.Text, TextActionDate.Value, Convert.ToInt16(ddlNDays.SelectedValue), CheckBoxEmailAlert.Checked, objectSessionHolderPersistingData.User_ID);
                Msg = "Document Alert has been Reset";
            }
            if (status == 1)
            {
               // Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
                LabelMessage.CssClass = "successmsg";
                LabelMessage.Text = Msg;
            }

        }
        catch (Exception ex)
        {
            //Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            LabelMessage.CssClass = "errormsg";
            LabelMessage.Text = ex.Message.ToString();
        }
    }
}
