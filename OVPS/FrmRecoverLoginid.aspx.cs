using System;
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
using System.IO;
using System.Drawing;

public partial class FrmRecoverLoginid : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.Now.AddDays(-1));
        Response.Cache.SetNoStore();
        if (Request.Cookies.Count > 0)
        {
            //HttpCookie cookie = Request.Cookies["ASPXAUTH"];
            //cookie.Expires = DateTime.Now.AddYears(-10);
            //Response.AppendCookie(cookie);
        }
        LabelSysDate.Text = DateTime.Now.ToLongDateString();

    }

    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("FrmHomePage.aspx");
    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        string sthtml = "";
        string Subject = "Your Login Details for the Online Visa Processing System";

        BaseLayer.General_function obj = null;
        obj = new BaseLayer.General_function();

        DataTable dt = null;
        dt = new DataTable();
        DataTable dt1 = null;
        dt1 = new DataTable();
        DataTable dt2 = null;
        dt2 = new DataTable();

        BusinessEntityLayer.AccountUserData objBalAccountUserData = null;
        objBalAccountUserData = new BusinessEntityLayer.AccountUserData();
        if (Rbl.SelectedValue == "")
        {
            lblError.Visible = true;
            lblError.Text = "Select Respective radio button";
            return;
        }
        if (Rbl.SelectedValue == "1")
        {
            if (txtLoginId.Text == "")
            {
                lblError.Visible = true;
                lblError.Text = "Enter Login ID";
                txtLoginId.Focus();
                return;
            }
           
           

            dt = obj.FetchData("Select Userid,Password,Username,UserType,EmailID,LoginID from Usermaster where LoginID='" + txtLoginId.Text + "'");

            if (dt.Rows.Count == 0)
            {
                lblError.Visible = true;
                lblError.Text = "Wrong Login ID";
                txtLoginId.Focus();
                return;
            } 
            if (dt.Rows[0]["LoginID"].ToString() != txtLoginId.Text)
            {
                lblError.Visible = true;
                lblError.Text = "Incorrect Login ID";
                txtLoginId.Focus();
                return;
            }
            if (dt.Rows[0]["UserType"].ToString() == "SY")
            {
                
                sthtml = sthtml + "<table border='0'>";
                sthtml = sthtml + "<tr><td>Dear " + dt.Rows[0]["Username"].ToString() + ",</td><tr>";
                sthtml = sthtml + "<tr>" + "<td ><b><font>&nbsp;</font></b>" + "</td>" + "</tr>";
                sthtml = sthtml + "<tr><td>Your LoginID :" + dt.Rows[0]["LoginID"].ToString() + "</td><tr>";
                sthtml = sthtml + "<tr><td>Your Password :" + dt.Rows[0]["Password"].ToString() + "</td><tr>";
                sthtml = sthtml + "<tr>" + "<td ><b><font>&nbsp;</font></b>" + "</td>" + "</tr>";
                sthtml = sthtml + "<tr><td>Thank you</td><tr>";
                sthtml = sthtml + "</table>";

                lblError.Text = objBalAccountUserData.ForGetPossword(dt.Rows[0]["EmailID"].ToString(), Subject, sthtml);
               
            }

            else if (dt.Rows[0]["UserType"].ToString() == "AG")
            {
                sthtml = sthtml + "<table border='0'>";
                sthtml = sthtml + "<tr><td>Dear " + dt.Rows[0]["Username"].ToString() + ",</td><tr>";
                sthtml = sthtml + "<tr>" + "<td ><b><font>&nbsp;</font></b>" + "</td>" + "</tr>";
                sthtml = sthtml + "<tr><td>Your LoginID :" + dt.Rows[0]["LoginID"].ToString() + "</td><tr>";
                sthtml = sthtml + "<tr><td>Your Password :" + dt.Rows[0]["Password"].ToString() + "</td><tr>";
                sthtml = sthtml + "<tr>" + "<td ><b><font>&nbsp;</font></b>" + "</td>" + "</tr>";
                sthtml = sthtml + "<tr><td>Thank you</td><tr>";

                sthtml = sthtml + "</table>";

                lblError.Text = objBalAccountUserData.ForGetPossword(dt.Rows[0]["EmailID"].ToString(), Subject, sthtml);

            }
            else if (dt.Rows[0]["UserType"].ToString() == "AP")
            {
                
                dt1 = obj.FetchData("Select VerifiedYN,UniqueCode from ApplicantRegistrationMaster where userid ='" + dt.Rows[0]["UserID"].ToString() + "'");

                if (dt1.Rows[0]["VerifiedYN"].ToString() == "1")
                {
                    sthtml = sthtml + "<table border='0'>";
                    sthtml = sthtml + "<tr><td>Dear " + dt.Rows[0]["Username"].ToString() + ",</td><tr>";
                    sthtml = sthtml + "<tr>" + "<td ><b><font>&nbsp;</font></b>" + "</td>" + "</tr>";
                    sthtml = sthtml + "<tr><td>Your LoginID :" + dt.Rows[0]["LoginID"].ToString() + "</td><tr>";
                    sthtml = sthtml + "<tr><td>Your Password :" + dt.Rows[0]["Password"].ToString() + "</td><tr>";
                    sthtml = sthtml + "<tr>" + "<td ><b><font>&nbsp;</font></b>" + "</td>" + "</tr>";
                    sthtml = sthtml + "<tr><td>Thank you</td><tr>";
                    sthtml = sthtml + "</table>";

                    lblError.Text = objBalAccountUserData.ForGetPossword(dt.Rows[0]["EmailID"].ToString(), Subject, sthtml);
                }
                else
                {
                     string str = System.Configuration.ConfigurationSettings.AppSettings["link"].ToString();// "http://localhost:52759/OVPS/FrmVerify.aspx";

                        sthtml = sthtml + "<table border='0'>";
                        sthtml = sthtml + "<tr><td>Dear " + dt.Rows[0]["Username"].ToString() + ",</td><tr>";
                        sthtml = sthtml + "<tr>" + "<td ><b><font>&nbsp;</font></b>" + "</td>" + "</tr>";
                        sthtml = sthtml + "<tr><td>Your LoginID :" + dt.Rows[0]["LoginID"].ToString() + "</td><tr>";
                        sthtml = sthtml + "<tr><td>Your Password :" + dt.Rows[0]["Password"].ToString() + "</td><tr>";
                        sthtml = sthtml + "<tr><td>Your Unique Code :" + dt1.Rows[0]["UniqueCode"].ToString() + "</td><tr>";  
                        sthtml = sthtml + "<tr><td>Please Click On the given Link to verify your loginID </td><tr>";
                        sthtml = sthtml + "<tr><td><h4><a href=" + str + ">Click me to Verify Your login </a> </h4> </td><tr>";
                        sthtml = sthtml + "<tr>" + "<td ><b><font>&nbsp;</font></b>" + "</td>" + "</tr>";
                        sthtml = sthtml + "<tr><td>Thank you</td><tr>";
                        sthtml = sthtml + "</table>";

                        lblError.Text = objBalAccountUserData.ForGetPossword(dt.Rows[0]["EmailID"].ToString(), Subject, sthtml);
                }               

            }
        }
            else if (Rbl.SelectedValue == "2") 
        {
                    
                    
                        if (txtEmailId.Text == "")
                        {
                            lblError.Visible = true;
                            lblError.Text = "Enter Email ID";
                            return;
                        }
                    
                       
                        dt = obj.FetchData("Select Userid,Password,Username,UserType,EmailID,LoginID from Usermaster where EmailID='" + txtEmailId.Text + "'");

                        if (dt.Rows.Count == 0)
                        {
                            lblError.Text = "Wrong Email ID";
                            txtEmailId.Focus();
                            return;
                        }
                        if (dt.Rows[0]["EmailID"].ToString() != txtEmailId.Text)
                        {
                            lblError.Visible = true;
                            lblError.Text = "Wrong Email ID";
                            txtEmailId.Focus();
                            return;
                        }
                        if (dt.Rows[0]["UserType"].ToString() == "SY")
                        {
                           
                            sthtml = sthtml + "<table border='0'>";
                            sthtml = sthtml + "<tr><td>Dear " + dt.Rows[0]["Username"].ToString() + ",</td><tr>";
                            sthtml = sthtml + "<tr>" + "<td ><b><font>&nbsp;</font></b>" + "</td>" + "</tr>";
                            sthtml = sthtml + "<tr><td>Your LoginID :" + dt.Rows[0]["LoginID"].ToString() + "</td><tr>";
                            sthtml = sthtml + "<tr><td>Your Password :" + dt.Rows[0]["Password"].ToString() + "</td><tr>";
                            sthtml = sthtml + "<tr>" + "<td ><b><font>&nbsp;</font></b>" + "</td>" + "</tr>";
                            sthtml = sthtml + "<tr><td>Thank you</td><tr>";

                            sthtml = sthtml + "</table>";

                            lblError.Text = objBalAccountUserData.ForGetPossword(dt.Rows[0]["EmailID"].ToString(), Subject, sthtml);
                        }

                        else if (dt.Rows[0]["UserType"].ToString() == "AG")
                        {
                           
                            sthtml = sthtml + "<table border='0'>";
                            sthtml = sthtml + "<tr><td>Dear " + dt.Rows[0]["Username"].ToString() + ",</td><tr>";
                            sthtml = sthtml + "<tr>" + "<td ><b><font>&nbsp;</font></b>" + "</td>" + "</tr>";
                            sthtml = sthtml + "<tr><td>Your LoginID :" + dt.Rows[0]["LoginID"].ToString() + "</td><tr>";
                            sthtml = sthtml + "<tr><td>Your Password :" + dt.Rows[0]["Password"].ToString() + "</td><tr>";
                            sthtml = sthtml + "<tr>" + "<td ><b><font>&nbsp;</font></b>" + "</td>" + "</tr>";
                            sthtml = sthtml + "<tr><td>Thank you</td><tr>";

                            sthtml = sthtml + "</table>";

                            lblError.Text = objBalAccountUserData.ForGetPossword(dt.Rows[0]["EmailID"].ToString(), Subject, sthtml);
                        }
                        else if (dt.Rows[0]["UserType"].ToString() == "AP")
                        {

                            dt2 = obj.FetchData("Select UniqueCode,VerifiedYN from ApplicantRegistrationMaster where userid ='" + dt.Rows[0]["userid"].ToString() + "'");

                            if (dt2.Rows.Count == 0)
                            {
                                lblError.Visible = true;
                                lblError.Text = "Wrong Email ID";
                                txtEmailId.Focus();
                                return;
                            }
                            if (dt2.Rows[0]["VerifiedYN"].ToString() == "1")
                            {

                                sthtml = sthtml + "<table border='0'>";
                                sthtml = sthtml + "<tr><td>Dear " + dt.Rows[0]["Username"].ToString() + ",</td><tr>";
                                sthtml = sthtml + "<tr>" + "<td ><b><font>&nbsp;</font></b>" + "</td>" + "</tr>";
                                sthtml = sthtml + "<tr><td>Your LoginID :" + dt.Rows[0]["LoginID"].ToString() + "</td><tr>";
                                sthtml = sthtml + "<tr><td>Your Password :" + dt.Rows[0]["Password"].ToString() + "</td><tr>";
                                sthtml = sthtml + "<tr>" + "<td ><b><font>&nbsp;</font></b>" + "</td>" + "</tr>";
                                sthtml = sthtml + "<tr><td>Thank you</td><tr>";
                                sthtml = sthtml + "</table>";

                                lblError.Text = objBalAccountUserData.ForGetPossword(dt.Rows[0]["EmailID"].ToString(), Subject, sthtml);

                            }
                            else
                            {
                                string str = System.Configuration.ConfigurationSettings.AppSettings["link"].ToString();//"http://localhost:52759/OVPS/FrmVerify.aspx";

                                sthtml = sthtml + "<table border='0'>";
                                sthtml = sthtml + "<tr><td>Dear " + dt.Rows[0]["Username"].ToString() + ",</td><tr>";
                                sthtml = sthtml + "<tr>" + "<td ><b><font>&nbsp;</font></b>" + "</td>" + "</tr>";
                                sthtml = sthtml + "<tr><td>Your LoginID :" + dt.Rows[0]["LoginID"].ToString() + "</td><tr>";
                                sthtml = sthtml + "<tr><td>Your Password :" + dt.Rows[0]["Password"].ToString() + "</td><tr>";
                                sthtml = sthtml + "<tr><td>Your Unique Code :" + dt2.Rows[0]["UniqueCode"].ToString() + "</td><tr>";
                                sthtml = sthtml + "<tr><td>Please Click On the given Link to verify your loginID </td><tr>";
                                sthtml = sthtml + "<tr><td><h4><a href=" + str + ">Click me to Verify Your login </a> </h4> </td><tr>";
                                sthtml = sthtml + "<tr>" + "<td ><b><font>&nbsp;</font></b>" + "</td>" + "</tr>";
                                sthtml = sthtml + "<tr><td>Thank you</td><tr>";
                                sthtml = sthtml + "</table>";

                                lblError.Text = objBalAccountUserData.ForGetPossword(dt.Rows[0]["EmailID"].ToString(), Subject, sthtml);
                            }

                        }
                    
                }

        if (lblError.Text == "Your Login Details has been sent to your mail id")
        {
            lblError.ForeColor = System.Drawing.Color.DarkGreen;
            Rbl.SelectedIndex = -1;
            txtEmailId.Text = "";
            txtLoginId.Text = "";
            txtEmailId.ReadOnly = true;
            txtLoginId.ReadOnly = true;

        }
           
  }
   
 
    protected void Rbl_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Rbl.SelectedValue == "1")
        {
            lblError.Text = "";
            txtEmailId.Text = "";
            txtLoginId.Text = "";
            txtEmailId.ReadOnly = true;
            txtLoginId.ReadOnly = false;
            txtLoginId.Focus();
        }
        else
        {
            lblError.Text = "";
            txtEmailId.Text = "";
            txtLoginId.Text = "";
            txtLoginId.ReadOnly = true;
            txtEmailId.ReadOnly = false;
            txtEmailId.Focus();
        }


    }
}
