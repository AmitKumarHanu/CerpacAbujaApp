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

public partial class User_ActiveAlertList : System.Web.UI.Page
{
    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
        }
    }

    private void BindGrid()
    {
        DataAccessLayer.DalFileUpload ObjDal = null;
        DataTable dt = null;
         objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        try {
            ObjDal = new DataAccessLayer.DalFileUpload();
            dt = ObjDal.FetchActiveAlertbyUserId(objectSessionHolderPersistingData.User_ID);
            GridViewFilesList.DataSource=dt;
            GridViewFilesList.DataBind();
        }
        catch (Exception ex)
        {
            Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            LabelMessage.CssClass = "errormsg";
            LabelMessage.Text = ex.Message.ToString();
        }
    }

    protected void GridViewFilesList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Select"))
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int keyvalue = (int)GridViewFilesList.DataKeys[index].Value;
            Response.Redirect("~/User/FrmActionAlert.aspx?DocId=" + keyvalue + "");

        }

    }

    protected void GridViewFilesList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewFilesList.PageIndex = e.NewPageIndex;
        BindGrid();
    }
}
