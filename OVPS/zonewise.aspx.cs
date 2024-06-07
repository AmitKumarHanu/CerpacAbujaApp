using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.IO;
using System.Configuration;
using System.Collections;
using System.Globalization;


public partial class zonewise : System.Web.UI.Page
{
    BaseLayer.General_function objgenenral = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        string ID = Request.QueryString["id"].ToString();
        bindgrid(ID);

        
    }

    private void bindgrid(string id)
    {
        objgenenral = new BaseLayer.General_function();
        string queryforverified = "Select a.*,b.ZoneCode from vw_prod_consolidated_data as a, CerpacNo_Out_One as b where a.cerpac_no = b.cerpac_no and a.IsVerified = 1 and (a.IsAuthorized is null or a.IsAuthorized=0 ) and b.ZoneCode="+id.ToString().Trim()+"";
        DataTable dtverified = objgenenral.FetchData(queryforverified);
        if (dtverified.Rows.Count > 0)
        {
            GridViewVerify.DataSource = dtverified;
            GridViewVerify.DataBind();
        }

        string queryforauth = "Select a.*,b.ZoneCode from vw_prod_consolidated_data as a, CerpacNo_Out_One as b where a.cerpac_no = b.cerpac_no and a.IsVerified = 1 and a.IsAuthorized=1 and (a.IsProduced is null or a.IsProduced=0 ) and b.ZoneCode=" + id.ToString().Trim() + "";
        DataTable dtauth = new DataTable();
        dtauth = objgenenral.FetchData(queryforauth);
        if (dtauth.Rows.Count > 0)
        {
            //-----------------------------------gridviewauth data bind------------(IsQual is null or IsQual =0)
            GridViewAuth.DataSource = dtauth;
            GridViewAuth.DataBind();
            //-------------------------------------end---------------------------
        }
        string queryforprod = "Select a.*,b.ZoneCode from vw_prod_consolidated_data as a, CerpacNo_Out_One as b where a.cerpac_no = b.cerpac_no and a.IsVerified = 1 and a.IsAuthorized=1 and a.IsProduced =1 and (IsQual is null or IsQual =0) and b.ZoneCode=" + id.ToString().Trim() + " ";
        DataTable dtprod = new DataTable();
        dtprod = objgenenral.FetchData(queryforprod);
        if (dtprod.Rows.Count > 0)
        {
            //-----------------------------------gridviewprod data bind------------
            GridViewProd.DataSource = dtprod;
            GridViewProd.DataBind();
            //-------------------------------------end---------------------------
        }
       
    }
}