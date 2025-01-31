﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using DataAccessLayer;
using System.Data;
using System.Data.SqlClient;

public partial class Admin_ApplicationsWaitingBioMetrics : System.Web.UI.Page
{
    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    BaseLayer.General_function objgenenral = null;
    protected DataTable dt = new DataTable();
    protected DataSet objDs = new DataSet();
    BusinessEntityLayer.BalApprovalReviewL1 ObjbalApporvalL1 = null;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        if (objectSessionHolderPersistingData == null)
        {
            Response.Redirect("../Login.aspx");
        }

        if (!IsPostBack)
        {
            bindgrid();
        }
        Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
        string queryforzonename = "select b.ZoneName from UserZoneRelation as a, Zonemaster as b where a.ZoneCode=b.ZoneCode and a.UserId=" + objectSessionHolderPersistingData.User_ID + "";
        objgenenral = new BaseLayer.General_function();
        DataTable dt = new DataTable();
        try
        {
            dt = objgenenral.FetchData(queryforzonename);
            if (dt.Rows.Count > 0)
            {
                LabelMessage.Text = "Zone" + " " + dt.Rows[0]["ZoneName"].ToString();
                LabelMessage.Visible = true;
                LabelMessage.BorderStyle = BorderStyle.None;
            }
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            dt = null;
            objgenenral = null;
        }
    }
    protected void bindgrid()
    {
        objgenenral = new BaseLayer.General_function();
        DataTable dt = new DataTable();
        DataTable dtbio = new DataTable();
        DataTable dtmetrics = new DataTable();
        dtmetrics.Columns.Add("Name", typeof(String));
        dtmetrics.Columns.Add("cerpac_no", typeof(String));
        dtmetrics.Columns.Add("FORMNO", typeof(String));
        try
        {
            string queryforgrid = "select a.cerpac_no,(a.forename+' '+a.surname)as Name,b.FORMNO,a.people_id from People as a , PeopleChild as b,CerpacNo_Out_One as c,UserZoneRelation as d where a.cerpac_no = b.CerpacNo and b.CerpacNo=c.cerpac_no and b.FORMNO=c.cerpac_file_no and c.ZoneCode=d.ZoneCode and b.IsVerified=1 and (b.IsAuthorized=0 or b.IsAuthorized is null) and d.UserId=" + objectSessionHolderPersistingData.User_ID + "";
           
            dt = objgenenral.FetchData(queryforgrid);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                string queryforbiometrics = "Select * from VisaApplicationBiometric where VisaApplicationId=" + dt.Rows[i]["people_id"].ToString().Trim() + "";
                
                dtbio = objgenenral.FetchData(queryforbiometrics);
               
                    if (dtbio.Rows.Count == 0)
                    {
                        dtmetrics.Rows.Add(dt.Rows[i]["Name"].ToString(), dt.Rows[i]["cerpac_no"].ToString(), dt.Rows[i]["FORMNO"].ToString());

                    }
                }
                GridViewBioMetric.DataSource = dtmetrics;
                GridViewBioMetric.DataBind();
            }
        }
        catch (Exception exc)
        {
            throw (exc);
        }
        finally
        {
            dtmetrics = null;
            dt = null;
            dtbio = null;
            objgenenral = null;
        }
    }
    protected void GridViewBioMetric_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        GridViewBioMetric.PageIndex = e.NewPageIndex;
        bindgrid();
    }
}