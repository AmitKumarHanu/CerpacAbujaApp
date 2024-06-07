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
using System.Net.Mail;
using System.Threading;
using System.Text;

public partial class User_frmEmail : System.Web.UI.Page
{
    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (IsPostBack)
        //{

        //        Response.Write("<div id='mydiv' >");
        //        Response.Write("_");
        //        Response.Write("</div>");
        //        Response.Write("<script>mydiv.innerText = '';</script>");
        //        Response.Write("<script language=javascript>;");
        //        Response.Write("var dots = 0;var dotmax = 10;function ShowWait()");
        //        Response.Write("{var output; output = 'Sending Mail...';dots++;if(dots>=dotmax)dots=1;");
        //        Response.Write("for(var x = 0;x < dots;x++){output += '.';}mydiv.innerText =  output;}");
        //        Response.Write("function StartShowWait(){mydiv.style.visibility = 'visible';window.setInterval('ShowWait()',1000);}");
        //        Response.Write("function HideWait(){mydiv.style.visibility = 'hidden';window.clearInterval();}");
        //        Response.Write("StartShowWait();</script>");
        //        Response.Flush();
        //        Thread.Sleep(10000) ;
        //}
        if (!IsPostBack)
        {
            objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
            DataTable dtUser = new DataTable();
            BusinessEntityLayer.AccountUserData objBalAccountUserData = null;
            objBalAccountUserData = new BusinessEntityLayer.AccountUserData();
            dtUser = objBalAccountUserData.Fetch_UserDetail_by_UserId(objectSessionHolderPersistingData.User_ID.ToString());
            txtEmailTo.Text = dtUser.Rows[0]["EmailId"].ToString();
            string DocNo = Request.QueryString[0].ToString();
            BusinessEntityLayer.BalFileUpload ObjBalFileUpload = null;
            ObjBalFileUpload = new BusinessEntityLayer.BalFileUpload();
            DataTable dt = ObjBalFileUpload.GetFilePath(Convert.ToInt32(DocNo));
            lblDocName.Text = dt.Rows[0]["DocumentName"].ToString();
            ViewState["Dt"] = dt;
        }
    }
    public static void PrintProgressBar()
    {

        StringBuilder sb = new StringBuilder();

        sb.Append("<div id='updiv' style='Font-weight:bold;font-size:11pt;Left:160px;COLOR:black;font-family:verdana;Position:absolute;Top:140px;Text-Align:center;'>");

        sb.Append("&nbsp;<script> var up_div=document.getElementById('updiv');up_div.innerText='';</script>");

        sb.Append("<script language=javascript>");

        sb.Append("var dts=0; var dtmax=10;");

        sb.Append("function ShowWait(){var output;output='Sending Mail!';dts++;if(dts>=dtmax)dts=1;");

        sb.Append("for(var x=0;x < dts; x++){output+='';}up_div.innerText=output;up_div.style.color='red';}");

        sb.Append("function StartShowWait(){up_div.style.visibility='visible';ShowWait();window.setInterval('ShowWait()',100);}");

        sb.Append("StartShowWait();</script>");

        HttpContext.Current.Response.Write(sb.ToString());

        HttpContext.Current.Response.Flush();

    }
    public static void ClearProgressBar()
    {

        StringBuilder sbc = new StringBuilder();

        sbc.Append("<script language='javascript'>");

        sbc.Append("up_div.style.visibility='hidden';");

        sbc.Append("history.go(-1)");

        sbc.Append("</script>");

        HttpContext.Current.Response.Write(sbc);
    }

    protected void btnSubmit_Click1(object sender, EventArgs e)
    {
        PrintProgressBar();
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        btnSubmit.Visible = false;
        DataTable dt = (DataTable)ViewState["Dt"];

        string To = txtEmailTo.Text;
        string Subject = txtSubject.Text.ToString().Trim();
        string Massage = txtMessage.Text.ToString().Trim() + "<br><br><br><b> Mail sent through 'Document Management System'.</b><br><b>Please do not reply to this mail.</b>";
        string DocPath = Server.MapPath(dt.Rows[0]["FilePath"].ToString()) + dt.Rows[0]["FileName"].ToString();
        BaseLayer.General_function ObjGen = null;
        ObjGen = new BaseLayer.General_function();
        if (ObjGen.SendMailMessage(System.Configuration.ConfigurationManager.AppSettings["Email.Smtp"], new MailAddress(System.Configuration.ConfigurationManager.AppSettings["Email.From"]), To, Subject, Massage, DocPath))
        {
            //--------------Insert into Audit-----------
            BaseLayer.General_function ObjGenBal = new BaseLayer.General_function();
            ObjGenBal.audittype = ENUMAUDITTYPE.DocEmail.GetHashCode().ToString();
            ObjGenBal.userid = objectSessionHolderPersistingData.User_ID;
            ObjGenBal.auditdetail = "Doc '" + dt.Rows[0]["DocumentName"].ToString() + "(DocNo:" + Request.QueryString[0].ToString()+")" + "' emailed to '" + txtEmailTo.Text + "' .";
            ObjGenBal.machineIP = Request.UserHostAddress.ToString();
            ObjGenBal.AuditInsert();
            //---------------------End----------
            Response.Write("<script>alert('Mail Sent Successfully');</script>");
            Response.Write("<script>window.close();</script>");
        }
        else
        {

            //lblMailMsg.CssClass = "errormsg";
            //lblMailMsg.Text = "Problem in Mail Server";
            Response.Write("<script>alert('Problem in Mail Server,Please Check Your Connection.');</script>");
            // Response.Write("<script>window.close();</script>");

        }
        Thread.Sleep(2000);
        ClearProgressBar();



    }





}
