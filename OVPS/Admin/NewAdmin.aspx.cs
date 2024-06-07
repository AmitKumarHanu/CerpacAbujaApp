using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_NewAdmin : System.Web.UI.Page
{
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = new BaseLayer.SessionHolderPersistingData();
    protected void Page_Load(object sender, EventArgs e)
    {
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        if (objectSessionHolderPersistingData == null)
        {
            Response.Redirect("../Login.aspx");
        }
    }
    protected void lnklogout_Click(object sender, EventArgs e)
    {
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        BaseLayer.General_function ObjGenBal = new BaseLayer.General_function();
        ObjGenBal.audittype = ENUMAUDITTYPE.Logout.GetHashCode().ToString();
        ObjGenBal.userid = objectSessionHolderPersistingData.User_ID;
        ObjGenBal.auditdetail = "User Logout";
        ObjGenBal.machineIP = Request.UserHostAddress.ToString();
        ObjGenBal.AuditInsert();

        int res = 0;
        BusinessEntityLayer.BalProductionModule objProduction = new BusinessEntityLayer.BalProductionModule();
        res = objProduction.UpdateLoginFlag(Convert.ToInt32(ObjGenBal.userid), 2);

        HttpContext.Current.Session.Abandon();
        //Response.Redirect("../Login.aspx");
        Response.Redirect("../Login.aspx");
    }
}