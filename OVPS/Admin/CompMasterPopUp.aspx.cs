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
    string Opt = "";
    string Regno = "";
    string FRNno = "";
    string LogoPath1 = "";
    //string drpdwn = "";
    string UserID = null;
    string cer_no = "";
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {

       // TextBoxName.Focus();

        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        if (objectSessionHolderPersistingData == null)
        {
            Response.Redirect("../Login.aspx");
        }

        search_str = Convert.ToString(Request.QueryString["val"]);
        Regno = Convert.ToString(Request.QueryString["Regno"]);
        Opt = Convert.ToString(Request.QueryString["Opt"]);

        string queryforcompany = "";

         //cer_no = Session["CerpaxNo"].ToString();

        if ( search_str != ""  && Opt == "0" || Regno != "" && Opt == "0" )
        {
                   
            if (search_str != "" && Opt == "0")
                queryforcompany = "select top 75 regno, company from CompMaster where company like '%" + search_str + "%' order by company";
           
            if (Regno != "" && Opt == "0")
                queryforcompany = "select top 75 regno, company from CompMaster where regno='" + Regno + "'  order by company";
           
            if (search_str != "" && Regno != "" && Opt == "0")
                queryforcompany = "select top 75 regno, company from CompMaster where regno='" + Regno + "' or company ='%" + search_str + "%' order by company";

        }

        //cer_no = Session["CerpaxNo"].ToString();
        if (search_str != "" && Opt == "1" || Regno != "" && Opt == "1")
        {
            if (search_str != "" && Opt == "1")
                queryforcompany = "select top 75 regno, company from CompMasterForARCR where  company like '%" + search_str + "%' order by company";

            if (Regno != "" && Opt == "1")
                queryforcompany = "select top 75 regno, company from CompMasterForARCR where regno='" + Regno + "'  order by company";

            if (search_str != "" && Regno != "" && Opt == "1")
                queryforcompany = "select top 75 regno, company from CompMasterForARCR where regno='" + Regno + "' or company ='%" + search_str + "%' order by company";
        }

        ObjGenBal = new BaseLayer.General_function();

        if (!IsPostBack)
        {
            if (search_str != "" || Regno != "")
            {
                Session["cnt"] = "75";
                TextBoxName.Text = search_str;
                Session["search"] = search_str;


                DataTable dt = null;
                dt = new DataTable();
                try
                {
                    dt = ObjGenBal.FetchData(queryforcompany);
                    if (dt.Rows.Count < 75)
                    {
                        btn_next.Enabled = false;
                        btn_prev.Enabled = false;

                    }
                    else
                    {
                        btn_next.Enabled = true;
                        btn_prev.Enabled = true;

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
                  //  throw (ex);
                }
                finally
                {
                    dt = null;
                    ObjGenBal = null;
                }
            }
        }
    }


    protected void btn_prev_Click(object sender, EventArgs e)
    {
        Session["cnt"] = Convert.ToInt32(Session["cnt"].ToString()) - 75;

        if ((Convert.ToInt32(Session["cnt"].ToString())) <= 0)
        {
            btn_prev.Enabled = false;
        }
        else
            btn_prev.Enabled = true;

        string queryforcompany = "";

        if (search_str != "" && Opt == "0" || Regno != "" && Opt == "0")
        {


            if (search_str != "" && Opt == "0")
               // queryforcompany = "select top 75 regno, company from CompMaster where company like '%" + search_str + "%' order by company";
                queryforcompany = "select top 75 regno, company from CompMaster where company like '%" + Session["search"].ToString() + "%' and regno not in (Select top " + Session["cnt"].ToString() + " regno from CompMaster where company like '%" + Session["search"].ToString() + "%' order by company) order by company";

            if (Regno != "" && Opt == "0")
                queryforcompany = "select top 75 regno, company from CompMaster where regno='" + Regno + "'  order by company";

            if (search_str != "" && Regno != "" && Opt == "0")
                queryforcompany = "select top 75 regno, company from CompMaster where regno='" + Regno + "' And company = '%" + search_str + "%' order by company";

        }

        //cer_no = Session["CerpaxNo"].ToString();
        if (search_str != "" && Opt == "1" || Regno != "" && Opt == "1")
        {
            if (search_str != "" && Opt == "1")
                    queryforcompany = "select top 75 regno, company from CompMasterForARCR where company like '%" + Session["search"].ToString() + "%' and regno not in (Select top " + Session["cnt"].ToString() + " regno from CompMasterForARCR where company like '%" + Session["search"].ToString() + "%' order by company) order by company";

            if (Regno != "" && Opt == "1")
                queryforcompany = "select top 75 regno, company from CompMasterForARCR where regno='" + Regno + "'  order by company";

            if (search_str != "" && Regno != "" && Opt == "1")
                queryforcompany = "select top 75 regno, company from CompMasterForARCR where regno='" + Regno + "' And company = '" + search_str + "' order by company";
        }


        ObjGenBal = new BaseLayer.General_function();


        DataTable dt = null;
        dt = new DataTable();
        try
        {
            dt = ObjGenBal.FetchData(queryforcompany);

            if (dt.Rows.Count < 75)
            {
                btn_next.Enabled = false;
            }
            else

            {
                btn_next.Enabled=true;
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
           // throw (ex);

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

         if (search_str != "" && Opt == "0" || Regno != "" && Opt == "0")
         {


             if (search_str != "" && Opt == "0")
                 queryforcompany = "select top 75 regno, company from CompMaster where company like '%" + Session["search"].ToString() + "%' and regno not in  (Select top " + Session["cnt"].ToString() + " regno from CompMaster where company like '%" + Session["search"].ToString() + "%' order by company) order by company";
                 
             if (Regno != "" && Opt == "0")
                 queryforcompany = "select top 75 regno, company from CompMaster where regno='" + Regno + "'  order by company";

             if (search_str != "" && Regno != "" && Opt == "0")
                 queryforcompany = "select top 75 regno, company from CompMaster where regno='" + Regno + "' And company ='" + search_str + "' order by company";

         }

         //cer_no = Session["CerpaxNo"].ToString();
         if (search_str != "" && Opt == "1" || Regno != "" && Opt == "1")
         {
             if (search_str != "" && Opt == "1")
                 queryforcompany = "select top 75 regno, company from CompMasterForARCR where company like '%" + Session["search"].ToString() + "%' and regno not in (Select top " + Session["cnt"].ToString() + " regno from CompMasterForARCR where company like '%" + Session["search"].ToString() + "%' order by company) order by company";

             if (Regno != "" && Opt == "1")
                 queryforcompany = "select top 75 regno, company from CompMasterForARCR where regno='" + Regno + "'  order by company";

             if (search_str != "" && Regno != "" && Opt == "1")
                 queryforcompany = "select top 75 regno, company from CompMasterForARCR where regno='" + Regno + "' And company ='" + search_str + "' order by company";
         }


        ObjGenBal = new BaseLayer.General_function();

        Session["cnt"] = Convert.ToInt32(Session["cnt"].ToString()) + 75;

        DataTable dt = null;
        dt = new DataTable();
        try
        {
            dt = ObjGenBal.FetchData(queryforcompany);

            if (dt.Rows.Count < 75)
            {
                btn_next.Enabled = false;
            }
            else
            {
                btn_next.Enabled = true;
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
           // throw (ex);
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

         if (search_str != "" && Opt == "0" || Regno != "" && Opt == "0")
         {


             if (search_str != "" && Opt == "0")
                 queryforcompany = "select top 75 regno, company from CompMaster where company like '%" + name + "%' order by company";

             if (Regno != "" && Opt == "0")
                 queryforcompany = "select top 75 regno, company from CompMaster where regno like '%" + name + "%'  order by company";

             if (search_str != "" && Regno != "" && Opt == "0")
                 queryforcompany = "select top 75 regno, company from CompMaster where regno like '%" + name + "%' OR company like '%" + name + "%' order by company";

         }

         //cer_no = Session["CerpaxNo"].ToString();
         if (search_str != "" && Opt == "1" || Regno != "" && Opt == "1")
         {
             if (search_str != "" && Opt == "1")
                 queryforcompany = "select top 75 regno, company from CompMasterForARCR where  company like '%" + name + "%' order by company";

             if (Regno != "" && Opt == "1")
                 queryforcompany = "select top 75 regno, company from CompMasterForARCR where regno='" + name + "'  order by company";

             if (search_str != "" && Regno != "" && Opt == "1")
                 queryforcompany = "select top 75 regno, company from CompMasterForARCR where regno='" + name + "' OR company like '%" + name + "%' order by company";
         }


        ObjGenBal = new BaseLayer.General_function();

        Session["cnt"] = Convert.ToInt32(Session["cnt"].ToString()) + 75;

        DataTable dt = null;
        dt = new DataTable();
        try
        {
            dt = ObjGenBal.FetchData(queryforcompany);

            if (dt.Rows.Count < 75)
            {
                btn_next.Enabled = false;
                btn_prev.Enabled = false;

            }
            else
            {
                btn_next.Enabled = true;
                btn_prev.Enabled = true;

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
        try
        {
            string xmlfilename = "default.xml";
            if (Request.QueryString["val"] != "")
            {
                xmlfilename = Request.QueryString["val"].ToString().Trim() + ".xml";
            }

            if (File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"XML\" + xmlfilename.ToString().Trim())))
            {
                File.Delete(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"XML\" + xmlfilename.ToString().Trim()));
            }

            System.IO.StreamWriter s = File.CreateText(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"XML\" + xmlfilename.ToString().Trim()));

            string Regno = "";
            string comp_name = "";

            GridViewRow row = null;
            row = GridView1.SelectedRow;
            Regno = row.Cells[1].Text;
            comp_name = row.Cells[2].Text;
            comp_name = row.Cells[2].Text.Trim().Replace("&#39;", "'");
            comp_name = comp_name.Replace("'", "");
            string compdata = Regno + "," + comp_name;
            s.WriteLine(compdata);
            s.Dispose();
            Session["Regno"] = Regno;
            Session["company_name"] = comp_name;

            ScriptManager.RegisterStartupScript(this, GetType(), "key", "ReturnParentPage('" + Regno + "," + comp_name + "')", true);
        }
        catch (Exception ex)
        {
            throw (ex) ;
        }
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        GridView1.DataBind();
    }
}