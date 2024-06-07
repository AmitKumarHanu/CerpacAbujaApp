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

public partial class MasterPage_MasterPageUser : System.Web.UI.MasterPage
{
  
    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    int intAppCompleteCount = 0;
    BusinessEntityLayer.BalAdminForm ObjBalAdminForm = new BusinessEntityLayer.BalAdminForm();
    
    #endregion

    public string LabelMessage
    {
        get { return this.lblmsg.Text; }
        set { this.lblmsg.Text = value; }
    }
    public string LabelMessageCss
    {
        get { return this.lblmsg.CssClass; }
        set { this.lblmsg.CssClass = value; }
    }
   
    protected void Page_Init(object sender, EventArgs e)
    {

        Response.Cache.SetCacheability(HttpCacheability.Public);
        Response.Cache.SetMaxAge(new TimeSpan(0, 0, 0));
        Response.Cache.SetNoStore();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        HttpContext.Current.Trace.Warn("mastetr page load called :");      
        if (!IsPostBack)
        {
            objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now.AddDays(-1));
            Response.Cache.SetNoStore();
            
            
            if (Request.Cookies.Count > 0)
            {
                //HttpCookie cookie = Request.Cookies["ASPXAUTH"];
                //cookie.Expires = DateTime.Now.AddYears(-10);
                //Response.AppendCookie(cookie);
            }

            //LabelSysDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
           
            HttpContext.Current.Trace.Warn("objectSessionHolderPersistingData.User_ID :: " + objectSessionHolderPersistingData.User_ID);
            string strSqlStatement = "select COUNT(ApplicationId) as flagcompletecount from VisaApplicationInfo where flagcomplete='N' and AppliedByUserId = " + objectSessionHolderPersistingData.User_ID + "";
            intAppCompleteCount = ObjBalAdminForm.GetCompleteAppCount(strSqlStatement);
            HttpContext.Current.Trace.Warn("intAppCompleteCount :: " + intAppCompleteCount);  

            LabelSysDate.Text = DateTime.Now.ToLongDateString();
            if (objectSessionHolderPersistingData == null)
            {
                Response.Redirect("../Login.aspx");
            }
           
          
            
            if (objectSessionHolderPersistingData.CompanyId != "0")
            {
                bindLeftMenu(objectSessionHolderPersistingData.Grp_ID, objectSessionHolderPersistingData.CompanyId);
                HeaderContent(Convert.ToInt16(objectSessionHolderPersistingData.CompanyId));
                FooterContent();
            }
            string[] StrCurrentURL = new string[1];
            StrCurrentURL = HttpContext.Current.Request.Path.Split(new char[] { '/' });
            if (!StrCurrentURL[StrCurrentURL.Length - 1].Equals("default.aspx")) {
            hypHome.Visible = true;
            hypHome.NavigateUrl = "~/User/default.aspx";
            hypHome.Text = "Home";
            }
        }
    }

    private void HeaderContent(int CompanyId)
    {
        BusinessEntityLayer.BalCompanyDetails ObjBalCompanyInfo = null;
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        DataSet ds = null;
        DataTable dt = null;

        try
        {
            ds = new DataSet();
            dt = new DataTable();
            ObjBalCompanyInfo = new BusinessEntityLayer.BalCompanyDetails();

            CompanyId =Convert.ToInt16(objectSessionHolderPersistingData.CompanyId);
            ds = ObjBalCompanyInfo.GetCompanyInfo(CompanyId);

            ds.Tables.Add(dt);
            dt = ds.Tables[0];

            //LabelCompanyName.Text = dt.Rows[0]["CompanyName"].ToString();
            //ImgLogo.ImageUrl = System.Configuration.ConfigurationManager.AppSettings["LogoUrl"].ToString() +dt.Rows[0]["CompanyLogo"].ToString();

            
            LabelLoginUser.Text = " Welcome: <font color='BLACK'>"+ objectSessionHolderPersistingData.User_Name +"</font>";
            //LabelSysDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            LabelSysDate.Text = DateTime.Now.ToLongDateString();
        }
        catch (Exception ex)
        {
            lblmsg.CssClass = "errormsg";
            lblmsg.Text = ex.Message.ToString();
        }
        finally 
        {
            ds = null;
            dt = null;
            ObjBalCompanyInfo = null;
        }        
    }  

    private void FooterContent()
    {
        BusinessEntityLayer.BalCompanyDetails ObjBalCompanyInfo = null;
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        DataSet ds = null;
        DataTable dt = null;

        try
        {
            ds = new DataSet();
            dt = new DataTable();
            ObjBalCompanyInfo = new BusinessEntityLayer.BalCompanyDetails();

            int CompanyId = Convert.ToInt16(objectSessionHolderPersistingData.CompanyId);
            ds = ObjBalCompanyInfo.GetCompanyInfo(CompanyId);

            ds.Tables.Add(dt);
            dt = ds.Tables[0];
        }
        catch (Exception ex)
        {
            lblmsg.CssClass = "errormsg";
            lblmsg.Text = ex.Message.ToString();
        }
        finally
        {
            ds = null;
            dt = null;
            ObjBalCompanyInfo = null;
        } 
    }

    private void bindLeftMenu(string GrpId,string CompanyId)
    {

        //string str = MenuItem;
        TVLeftMenu.Nodes.Clear();
        TreeNode CurrentNode = null;
        TreeNode tn = null;
        
        DataTable DtFormInfo = null;
        try
        {
            //following Line should be deleted, this is for time being
           
            DtFormInfo = new DataTable();

            DtFormInfo = ObjBalAdminForm.GetFormInfo(GrpId, CompanyId);

            //Cache.Remove("LeftMenu");
            //if (Cache["LeftMenu"] == null)
            //{
            //    DtFormInfo = ObjBalAdminForm.GetFormInfo(GrpId,CompanyId);

            //    Cache["LeftMenu"] = DtFormInfo;
            //}
            //else
            //{
            //    DtFormInfo = (DataTable)Cache["LeftMenu"];
            //}
            if (DtFormInfo == null)
                return;
            string strSubmenu = "";
            if (DtFormInfo != null)
            {
                if (DtFormInfo.Rows.Count > 0)
                {
                    strSubmenu = DtFormInfo.Rows[0]["SUBMENU"].ToString();
                }
            }

            foreach (DataRow dr in DtFormInfo.Rows)
            {
                TreeNode rootNode = null;
                if (dr != null)
                {

                    if (string.IsNullOrEmpty(dr["SUBMENU"].ToString()))
                    {
                        HttpContext.Current.Trace.Warn("inside if" + dr["FormName"] );    
                        //if(String.IsNullOrEmpty(strSubmenu) || strSubmenu!=
                        tn = new TreeNode();
                        tn.Text = dr["FormName"].ToString();
                        tn.NavigateUrl = (string)(dr.IsNull("FormUrl") ? "" : dr["FormUrl"]);
                        TVLeftMenu.Nodes.Add(tn);
                    }
                    else
                    {
                        rootNode = TVLeftMenu.FindNode(dr["SUBMENU"].ToString());
                        HttpContext.Current.Trace.Warn("inside else :: " + dr["FormName"]);
                        HttpContext.Current.Trace.Warn("inside else :: " + dr["FormUrl"]);  
                        
                        string strURL = Convert.ToString(dr["FormUrl"]);  
                       
                        if (rootNode == null)
                        {
                            rootNode = new TreeNode();
                            rootNode.Text = dr["SUBMENU"].ToString();
                            rootNode.NavigateUrl = "";
                            rootNode.SelectAction = TreeNodeSelectAction.Expand;
                            //rootNode.Collapse();
                            //rootNode.Expand();                                                      
                            TVLeftMenu.Nodes.Add(rootNode);
                            // tn.NavigateUrl = (string)(dr.IsNull("PageUrl") ? "" : dr["PageUrl"]);
                        }
                        tn = new TreeNode();
                        tn.Text = dr["FormName"].ToString();

                        tn.NavigateUrl = (string)(dr.IsNull("FormUrl") ? "" : dr["FormUrl"]);
                        //Matching for current Url to keep it in Expended Form
                        string[] StrNavigateURL = new string[1];
                        StrNavigateURL = tn.NavigateUrl.Split(new char[] { '/' });


                        string[] StrCurrentURL = new string[1];
                        StrCurrentURL = HttpContext.Current.Request.Path.Split(new char[] { '/' });

                        if (intAppCompleteCount == 1)
                        {
                            if (strURL.Contains("FrmVisaApplication.aspx") == true)
                            {
                                tn.SelectAction = TreeNodeSelectAction.None;
                            }
                        }

                        if (StrNavigateURL[StrNavigateURL.Length - 1].Equals(StrCurrentURL[StrCurrentURL.Length - 1]))
                        {
                            CurrentNode = rootNode;
                        }
                        if (rootNode != null)
                        {
                            rootNode.ChildNodes.Add(tn);
                            //Page.Header.Title = dr["PageName"].ToString();
                        }
                        else
                        {                           
                            TVLeftMenu.Nodes.Add(tn);
                            // Page.Header.Title = dr["PageName"].ToString();
                        }

                    }                
                }
            }
        }
        catch (Exception ex)
        {
            LabelMessageCss = "errormsg";
            LabelMessage = ex.Message.ToString();
        }
    }    


    protected void btnlogout_Click(object sender, EventArgs e)
    {
        HttpContext.Current.Session.Abandon();
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        BaseLayer.General_function ObjGenBal = new BaseLayer.General_function();
        ObjGenBal.audittype = ENUMAUDITTYPE.Logout.GetHashCode().ToString();
        ObjGenBal.userid = objectSessionHolderPersistingData.User_ID;
        ObjGenBal.auditdetail = "User Logout";
        ObjGenBal.machineIP = Request.UserHostAddress.ToString();
        ObjGenBal.AuditInsert();
        //Response.Redirect("../Login.aspx");
        Response.Redirect("../FrmHomePage.aspx");
    }
}

