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
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

public partial class Admin_ViewFullApplication : System.Web.UI.Page
{

    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    BaseLayer.General_function ObjGeneral = null;
    Label LabelMessage = null;
    string LogoPath1 = string.Empty;
    BusinessEntityLayer.BalVisaApplicationSubmit ObjBalVisa = new BusinessEntityLayer.BalVisaApplicationSubmit();
    protected DataTable dt = new DataTable();
    protected DataTable dt1 = new DataTable();
    string strApplicationId;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {

        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        if (objectSessionHolderPersistingData == null)
        {
            Response.Redirect("../Login.aspx");
        }

        if (Request.QueryString["id"] != null)
        {
             lblnum1.Text = "2 of " + Convert.ToString(Session["Number"]);
             lblnum2.Text = "3 of " + Convert.ToString(Session["Number"]);
             lblnum3.Text = "4 of " + Convert.ToString(Session["Number"]);
             lblnum4.Text = "5 of " + Convert.ToString(Session["Number"]);
            strApplicationId = Request.QueryString["id"].ToString();
            ObjBalVisa = new BusinessEntityLayer.BalVisaApplicationSubmit();
            dt = new DataTable();
            dt = ObjBalVisa.GetVisaApplicationInfo4Update(strApplicationId);
            dt1 = ObjBalVisa.GetDocForPrint(strApplicationId);
            if(dt1.Rows.Count>0)
            {Panel1.Controls.Add(new LiteralControl("<table border=0 cellpadding=0 cellspacing=0><tr><td width=30></td></tr>"));
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    Panel1.Controls.Add(new LiteralControl("<tr><td>"));
                    Label lblDocName = new Label();
                    lblDocName.ID = lblDocName + " " + dt1.Rows[i]["DocName"].ToString();
                    Panel1.Controls.Add(new LiteralControl("<strong>"));
                    lblDocName.Text = dt1.Rows[i]["DocName"].ToString();
                    Panel1.Controls.Add(new LiteralControl("</strong>"));
                    Panel1.Controls.Add(lblDocName);
                    Panel1.Controls.Add(new LiteralControl("</td></tr>"));
                    Panel1.Controls.Add(new LiteralControl("<tr><td height=20></td></tr><tr><td>"));
                    Panel1.Controls.Add(new LiteralControl("<img src =../new/"+dt1.Rows[i]["Filename"].ToString().Trim() +" height =1130 width = 800 />"));
                   // System.Web.UI.WebControls.Image img = new System.Web.UI.WebControls.Image();
                   // img.ID = "img" + dt1.Rows[0]["Filename"].ToString().Trim();
                   // img.ImageUrl = "~/Images/Logo/" + dt1.Rows[i]["Filename"].ToString().Trim() + "?refreshTime=" + Server.UrlEncode(DateTime.Now.TimeOfDay.ToString());
                   // img.Visible = true;
                   // Panel1.Controls.Add(img);
                    
                    Panel1.Controls.Add(new LiteralControl("</td></tr>"));
                    Panel1.Controls.Add(new LiteralControl("<tr><td align = center>"));
                    Label lblnum5 = new Label();
                    lblnum5.ID = "lblnum" + Convert.ToString(5 + (i + 1));
                    lblnum5.Text = Convert.ToString(5 + (i + 1)) + "of " + Convert.ToString(Session["Number"]);
                    Panel1.Controls.Add(lblnum5);
                    Panel1.Controls.Add(new LiteralControl("</td></tr>"));
                    Panel1.Controls.Add(new LiteralControl("<tr><td height=50><br/><br/></td></tr>"));

                     
                }
                Panel1.Controls.Add(new LiteralControl("</table>"));

            }

        }

    }

    

    
}