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

public partial class MasterPage_MasterPageCompany : System.Web.UI.MasterPage
{

    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
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

        if (objectSessionHolderPersistingData.User_ID == "")
        {
            Response.Redirect("../Login.aspx");
        }
        lbl_id.Text = objectSessionHolderPersistingData.User_ID;
        if (!IsPostBack)
        {

            LabelSysDate.Text = DateTime.Now.ToLongDateString();
            LabelLoginUser.Text = "Welcome: " + objectSessionHolderPersistingData.User_Name;
           
            if (objectSessionHolderPersistingData.CompanyId != "0")
            {
                bindLeftMenu(objectSessionHolderPersistingData.Grp_ID, objectSessionHolderPersistingData.CompanyId);
                
            }         

        }           
    }

    protected void Timer1_Tick(object sender, EventArgs e)
    {


        try
        {

            //Put Your Code here
            int res = 0;
            objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];

            BusinessEntityLayer.BalProductionModule objProduction = new BusinessEntityLayer.BalProductionModule();

            BaseLayer.General_function ObjGenBal = new BaseLayer.General_function();
            ObjGenBal.audittype = ENUMAUDITTYPE.Logout.GetHashCode().ToString();
            ObjGenBal.userid = objectSessionHolderPersistingData.User_ID;

            //res = objProduction.UpdateLoginFlag(Convert.ToInt32(Session["UserId"].ToString()), 2);
            res = objProduction.UpdateLoginFlag(Convert.ToInt32(lbl_id.Text), 3);


        }

        catch (Exception ex)
        {

        }
    }

    protected void btnlogout_Click(object sender, ImageClickEventArgs e)
    {
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        BaseLayer.General_function ObjGenBal = new BaseLayer.General_function();
        ObjGenBal.audittype = ENUMAUDITTYPE.Logout.GetHashCode().ToString();
        ObjGenBal.userid = "0";//superadmin id
        ObjGenBal.auditdetail = "User Logout";
        ObjGenBal.machineIP = Request.UserHostAddress.ToString();
        //ObjGenBal.machineName = System.Net.Dns.GetHostName();
        //ObjGenBal.windowUser = System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToString();
        ObjGenBal.AuditInsert();
        Response.Redirect("../Login.aspx");
    }

    private void bindLeftMenu(string GrpId, string CompanyId)
    {

        //string str = MenuItem;
        TVLeftMenu.Nodes.Clear();
        TreeNode CurrentNode = null;
        TreeNode tn = null;

        //if (string.IsNullOrEmpty(MenuItem))
        //  return;

        BusinessEntityLayer.BalAdminForm ObjBalAdminForm = null;
        DataTable DtFormInfo = null;
        try
        {
            //following Line should be deleted, this is for time being
            ObjBalAdminForm = new BusinessEntityLayer.BalAdminForm();
            DtFormInfo = new DataTable();

            Cache.Remove("LeftMenu");
            if (Cache["LeftMenu"] == null)
            {
                DtFormInfo = ObjBalAdminForm.GetFormInfo(GrpId, CompanyId);

                Cache["LeftMenu"] = DtFormInfo;
            }
            else
            {
                DtFormInfo = (DataTable)Cache["LeftMenu"];
            }
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
                        //if(String.IsNullOrEmpty(strSubmenu) || strSubmenu!=
                        tn = new TreeNode();
                        tn.Text = dr["FormName"].ToString();
                        tn.NavigateUrl = (string)(dr.IsNull("FormUrl") ? "" : dr["FormUrl"]);
                        TVLeftMenu.Nodes.Add(tn);
                    }
                    else
                    {
                        rootNode = TVLeftMenu.FindNode(dr["SUBMENU"].ToString());
                        if (rootNode == null)
                        {
                            rootNode = new TreeNode();
                            rootNode.Text = dr["SUBMENU"].ToString();
                            rootNode.NavigateUrl = "";
                            rootNode.SelectAction = TreeNodeSelectAction.Expand;
                            // rootNode.Collapse();

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
                    //TVLeftMenu.CollapseAll();
                    if (CurrentNode != null)
                    {
                        CurrentNode.Expand();
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


}
