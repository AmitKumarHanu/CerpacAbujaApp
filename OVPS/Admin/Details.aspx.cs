using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;
using System.Text;
using System.Drawing;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Globalization;
//using OfficeOpenXml;
using System.Data;
using System.Data.Sql;

public partial class Details : System.Web.UI.Page
{
    BaseLayer.General_function objGeneral = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["q"] != "")
        {
            string data = Request.QueryString["q"].ToString().Trim();
            string[] split = data.Split(';');
            for (int i = 0; i < split.Length; i++)
            {
                Lblfirstname.Text = split[0].Substring(13,split[0].IndexOf(' ')).ToString().Trim();
                lbllastname.Text = split[1].Substring(12, split[1].IndexOf(' ')).ToString().Trim();
                lbldatebirth.Text = split[2].Substring(7, (split[2].Length)-7).ToString().Trim();
                lblpassport.Text = split[3].Substring(10, (split[3].Length)-10).ToString().Trim();
            }
        }
        else
        {
            Lblfirstname.Text = "Nothing to display";
        }

    }


    protected void btnverify_Click(object sender, EventArgs e)
    {
        objGeneral = new BaseLayer.General_function();
        DataTable dt = new DataTable();
        if (Request.QueryString["id"] != "")
        {
            string id = Request.QueryString["id"].ToString().Trim();
            string query = "Select FirstName,LastName,DateOfBirth,PassportNumber from VisaApplicationInfo where ApplicationId=" + id.ToString() + "";
            dt=objGeneral.FetchData(query);
            if (dt.Rows.Count > 0)
            {
                lblfndb.Text = dt.Rows[0]["FirstName"].ToString().Trim().ToUpper();
                lbllndb.Text = dt.Rows[0]["LastName"].ToString().Trim().ToUpper();
                lbldobdb.Text = string.Format("{0:yyMMdd}", dt.Rows[0]["DateOfBirth"]).ToString();
                lblpassdb.Text = dt.Rows[0]["PassportNumber"].ToString().Trim().ToUpper();
                if (lblfndb.Text.ToUpper() == Lblfirstname.Text.ToUpper())
                {
                    imgtickfn.Visible = true;
                }
                else
                {
                    imgcrossfn.Visible = true;
                }

                if (lbllndb.Text.ToUpper() == lbllastname.Text.ToUpper())
                {
                    imgtickfnln.Visible = true;
                }
                else
                {
                    imgcrossln.Visible = true;
                }

                if (lbldobdb.Text == lbldatebirth.Text)
                {
                    imgtickdob.Visible = true;
                }
                else
                {
                    imgcrossdob.Visible = true;
                }

                if (lblpassdb.Text.ToUpper() == lblpassport.Text.ToUpper())
                {
                    imgtickpass.Visible = true;
                }
                else
                {
                    imgcrosspass.Visible = true;
                }
            }
            else
            {
                Response.Write("<script>alert('Application not found')</script>");
            }
        }
    }
}