using System.Data;
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
using System.Drawing.Imaging;
using System.IO;
using System.Text.RegularExpressions;
using System.Net.Mail;
//using Microsoft.Reporting.WebForms;
using System.Xml.Linq;
using System.Drawing.Imaging;
using System.Collections.Generic;
using DataAccessLayer;
using System.Globalization;
using System.Text;
using System.Net;
using System.Windows;
using SHDocVw;
using System.Drawing.Drawing2D;
using System.Threading;

public partial class Admin_CompanyPopUp : System.Web.UI.Page
{
    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    BusinessEntityLayer.BalApprovalReviewL1 ObjbalApporvalL1 = null;
    protected BaseLayer.General_function ObjGenBal = null;
    string search_str = "";
    string FRNno = "";
    string LogoPath1 = "";
    //string drpdwn = "";
    string UserID = null;
    string cer_no = "";
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {



        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        if (objectSessionHolderPersistingData == null)
        {
            Response.Redirect("../Login.aspx");
        }

        search_str = Convert.ToString(Request.QueryString["val"]);

        string queryforcompany = "";

         cer_no = Session["CerpaxNo"].ToString();

        if (cer_no.Substring(0, 2) == "AO")
            queryforcompany = "select top 50 regno, company from CompMaster where company like '" + search_str + "%' order by company";
        else
            queryforcompany = "select top 50 regno, company from CompMasterForARCR where company like '" + search_str + "%'  order by company";

        ObjGenBal = new BaseLayer.General_function();

        if (!IsPostBack)
        {
            Session["cnt"] = "50";
            TextBoxName.Text = search_str;
            Session["search"] = search_str;


            DataTable dt = null;
            dt = new DataTable();
            try
            {
                dt = ObjGenBal.FetchData(queryforcompany);
                if (dt.Rows.Count < 50)
                {
                    btn_next.Visible = false;
                    btn_prev.Visible = false;

                }
                else
                {
                    btn_next.Visible = true;
                    btn_prev.Visible = true;

                }
                if (dt.Rows.Count > 0)
                {
                    GridView1.EditIndex = -1;
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    //LabelMessage.Text = "Zone" + " " + dt.Rows[0]["ZoneName"].ToString();
                    //LabelMessage.Visible = true;
                    //LabelMessage.BorderStyle = BorderStyle.None;
                    //txtZoneCode.Text = dt.Rows[0]["ZoneName"].ToString() + "--" + dt.Rows[0]["ZoneCode"].ToString();
                }
            }

            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                dt = null;
                ObjGenBal = null;
            }
        }
    }


    protected void btn_prev_Click(object sender, EventArgs e)
    {
        Session["cnt"] = Convert.ToInt32(Session["cnt"].ToString()) - 50;

        if ((Convert.ToInt32(Session["cnt"].ToString())) <= 0)
        {
            btn_prev.Visible = false;
        }
        else
            btn_prev.Visible = true;

        string queryforcompany = "";
        if (cer_no.Substring(0, 2) == "AO")
        {
            queryforcompany = "select top 50 regno, company from CompMaster where company like '" + Session["search"].ToString() + "%' and regno not in (select top " + Session["cnt"].ToString() + " regno from CompMaster where company like '" + Session["search"].ToString() + "%'  order by company)  order by company";
        }

        else
        {
            queryforcompany = "select top 50 regno, company from CompMasterForARCR where company like '" + Session["search"].ToString() + "%' and regno not in (select top " + Session["cnt"].ToString() + " regno from CompMasterForARCR where company like '" + Session["search"].ToString() + "%'  order by company)  order by company";
        }


        ObjGenBal = new BaseLayer.General_function();


        DataTable dt = null;
        dt = new DataTable();
        try
        {
            dt = ObjGenBal.FetchData(queryforcompany);

            if (dt.Rows.Count < 50)
            {
                btn_next.Visible = false;
            }
            else

            {
                btn_next.Visible=true;
            }

            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = null;
                GridView1.EditIndex = -1;
                GridView1.DataBind();
                GridView1.DataSource = dt;
                GridView1.DataBind();
                //LabelMessage.Text = "Zone" + " " + dt.Rows[0]["ZoneName"].ToString();
                //LabelMessage.Visible = true;
                //LabelMessage.BorderStyle = BorderStyle.None;
                //txtZoneCode.Text = dt.Rows[0]["ZoneName"].ToString() + "--" + dt.Rows[0]["ZoneCode"].ToString();
            }
        }

        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            dt = null;
            ObjGenBal = null;
        }
    }
    protected void btn_next_Click(object sender, EventArgs e)
    {
         string queryforcompany = "";
         if (cer_no.Substring(0, 2) == "AO")
         {
             queryforcompany = "select top 50 regno, company from CompMaster where company like '" + Session["search"].ToString() + "%' and regno not in (select top " + Session["cnt"].ToString() + " regno from CompMaster where company like '" + Session["search"].ToString() + "%'  order by company)  order by company";
         }

         else
         {
             queryforcompany = "select top 50 regno, company from CompMasterForARCR where company like '" + Session["search"].ToString() + "%' and regno not in (select top " + Session["cnt"].ToString() + " regno from CompMasterForARCR where company like '" + Session["search"].ToString() + "%'  order by company)  order by company";
         }

        ObjGenBal = new BaseLayer.General_function();

        Session["cnt"] = Convert.ToInt32(Session["cnt"].ToString()) + 50;

        DataTable dt = null;
        dt = new DataTable();
        try
        {
            dt = ObjGenBal.FetchData(queryforcompany);

            if (dt.Rows.Count < 50)
            {
                btn_next.Visible = false;
            }
            else
            {
                btn_next.Visible = true;
            }


            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                GridView1.EditIndex = -1;
               
                GridView1.DataSource = dt;
                GridView1.DataBind();
                //LabelMessage.Text = "Zone" + " " + dt.Rows[0]["ZoneName"].ToString();
                //LabelMessage.Visible = true;
                //LabelMessage.BorderStyle = BorderStyle.None;
                //txtZoneCode.Text = dt.Rows[0]["ZoneName"].ToString() + "--" + dt.Rows[0]["ZoneCode"].ToString();
            }
        }

        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            dt = null;
            ObjGenBal = null;
        }
    }
    protected void btn_search_Click(object sender, EventArgs e)
    {

        string name = this.TextBoxName.Text;
        //your code to modify name.......
        Session["search"] = name;
        Session["cnt"] = "0";

         string queryforcompany = "";
         if (cer_no.Substring(0, 2) == "AO")
         {
             queryforcompany = "select top 50 regno, company from CompMaster where company like '" + Session["search"].ToString() + "%' and regno not in (select top " + Session["cnt"].ToString() + " regno from CompMaster where company like '" + Session["search"].ToString() + "%'  order by company)  order by company";
         }
         else
         {
             queryforcompany = "select top 50 regno, company from CompMasterForARCR where company like '" + Session["search"].ToString() + "%' and regno not in (select top " + Session["cnt"].ToString() + " regno from CompMasterForARCR where company like '" + Session["search"].ToString() + "%'  order by company)  order by company";
         }

        ObjGenBal = new BaseLayer.General_function();

        Session["cnt"] = Convert.ToInt32(Session["cnt"].ToString()) + 50;

        DataTable dt = null;
        dt = new DataTable();
        try
        {
            dt = ObjGenBal.FetchData(queryforcompany);

            if (dt.Rows.Count < 50)
            {
                btn_next.Visible = false;
                btn_prev.Visible = false;

            }
            else
            {
                btn_next.Visible = true;
                btn_prev.Visible = true;

            }

          //  if (dt.Rows.Count > 0)
            {
                GridView1.EditIndex = -1;
                GridView1.DataSource = dt;
                GridView1.DataBind();
                //LabelMessage.Text = "Zone" + " " + dt.Rows[0]["ZoneName"].ToString();
                //LabelMessage.Visible = true;
                //LabelMessage.BorderStyle = BorderStyle.None;
                //txtZoneCode.Text = dt.Rows[0]["ZoneName"].ToString() + "--" + dt.Rows[0]["ZoneCode"].ToString();
            }
        }

        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            dt = null;
            ObjGenBal = null;
        }
    }
    //protected void btn_submit_Click(object sender, EventArgs e)
    //{
    //    string val = "";
    //    ScriptManager.RegisterStartupScript(this, GetType(), "key", "ReturnParentPage('" + val + "')", true);
    //}

    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //foreach (GridViewRow gridRow in GridView1.Rows)
        //{
        //    CheckBoxList checkboxlist = (CheckBoxList)(GridView1.Rows[gridRow.RowIndex].Cells[0].FindControl("CheckBox1"));

        //    checkboxlist.Attributes.Add("onclick", "CheckOne('" + checkboxlist.ClientID + "');");
        //}

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[0].Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Cells[1].Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Cells[2].Attributes["onmouseover"] = "this.style.cursor='pointer';";
            
           
            //  e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
            e.Row.ToolTip = "Click to select row";
            e.Row.Cells[0].Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.GridView1, "Select$" + e.Row.RowIndex);
            e.Row.Cells[1].Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.GridView1, "Select$" + e.Row.RowIndex);
            e.Row.Cells[2].Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.GridView1, "Select$" + e.Row.RowIndex);
           
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string xmlfilename = "default.xml";
        if (Request.QueryString["no"] != "")
        {
            xmlfilename = Request.QueryString["no"].ToString().Trim()+".xml";
        }

        if (Session["cerpaxNo"] != null)
        {
            if (Session["cerpaxNo"] != "")
            {
                xmlfilename = Session["cerpaxNo"].ToString().Trim() + ".xml";
            }
        }

        if (File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"XML\"+xmlfilename.ToString().Trim())))
        {
            File.Delete(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"XML\" + xmlfilename.ToString().Trim()));
        }

        System.IO.StreamWriter s = File.CreateText(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"XML\" + xmlfilename.ToString().Trim()));
        
        string comp_id = "";
        string comp_name = "";

        GridViewRow row = null;
         row = GridView1.SelectedRow;
        comp_id = row.Cells[1].Text;
       // comp_name = row.Cells[2].Text;
        comp_name = row.Cells[2].Text.Trim().Replace("&#39;", "'");
        comp_name = row.Cells[2].Text.Trim().Replace("&amp;", "&");

        comp_name = comp_name.Replace("'", "");
        string compdata= comp_id+","+comp_name;
        s.WriteLine(compdata);
        s.Dispose();
        Session["company_id"] = comp_id;
        Session["company_name"] = comp_name;

        ScriptManager.RegisterStartupScript(this, GetType(), "key", "ReturnParentPage('" + comp_id + "," + comp_name + "')", true);
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        GridView1.DataBind();
    }
}