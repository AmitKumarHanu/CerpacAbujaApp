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
using DataAccessLayer;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;


public partial class Admin_RejectApplicationsFromAuth : System.Web.UI.Page
{
    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    BaseLayer.General_function objgenenral = null;
    String ZoneID;
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        if (objectSessionHolderPersistingData == null)
        {
            Response.Redirect("../Login.aspx");
        }
       
        Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
        string queryforzonename = "select b.ZoneName, b.ZoneCode from UserZoneRelation as a, Zonemaster as b where a.ZoneCode=b.ZoneCode and a.UserId=" + objectSessionHolderPersistingData.User_ID + "";
        objgenenral = new BaseLayer.General_function();
        DataTable dt = new DataTable();
        try
        {
            dt = objgenenral.FetchData(queryforzonename);
            if (dt.Rows.Count > 0)
            {
                LabelMessage.Text = "Zone" + " " + dt.Rows[0]["ZoneName"].ToString();
                ZoneID = dt.Rows[0]["ZoneCode"].ToString();
                LabelMessage.Visible = true;
                LabelMessage.BorderStyle = BorderStyle.None;
            }
            if (!IsPostBack)
            {
                bindgrid();
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
        DataTable dtappfetch = new DataTable();
        string queryapp = "";
       // if (string.IsNullOrEmpty(Request.QueryString["no"]) == false)

        if ((Request.QueryString["rej"]) == "5")
        {
            queryapp = "select (d.forename+' '+d.surname) as Name, d.cerpac_no,d.cerpac_file_no,'Status' = case when (a.cerpac_no=a.cerpac_file_no) then 'Fresh' else 'Renewal' end from CerpacNo_Out_One as a , PeopleChild as b,UserZoneRelation as c,People as d where a.cerpac_no=b.CerpacNo and a.cerpac_file_no=b.FORMNO and b.CerpacNo=d.cerpac_no and b.IsRejected=5 and a.ZoneCode=c.ZoneCode and c.UserId=" + objectSessionHolderPersistingData.User_ID + "";
        }
        else
        {
            //queryapp = "select (d.forename+' '+d.surname) as Name, d.cerpac_no,d.cerpac_file_no,'Status' = case when (a.cerpac_no=a.cerpac_file_no) then 'Fresh' else 'Renewal' end from CerpacNo_Out_One as a , PeopleChild as b,UserZoneRelation as c,People as d where a.cerpac_no=b.CerpacNo and a.cerpac_file_no=b.FORMNO and b.CerpacNo=d.cerpac_no and b.IsRejected=1 and (b.IsVerified=0 or b.IsVerified=null) and a.ZoneCode=c.ZoneCode and c.UserId=" + objectSessionHolderPersistingData.User_ID + "";
            queryapp = "SELECT (a.forename+' '+a.surname) as Name, a.cerpac_no, b.FORMNO, 'Status' = case when (a.cerpac_no=a.cerpac_file_no) then 'Fresh' else 'Renewal' end, 'Remark' = case when (b.IsRejected =5) then 'Call Back' else 'Rejected' end  FROM People as a RIGHT OUTER JOIN Zonemaster as c INNER JOIN UserZoneRelation as d  INNER JOIN PeopleChild as b ON d.UserId = b.RejectedBy ON c.ZoneCode = d.ZoneCode ON a.cerpac_no = b.CerpacNo where d.ZoneCode="+ ZoneID +" and (b.IsRejected=5 or b.IsRejected=1 ) order by a.cerpac_no";
        }

        try
        {
            dtappfetch = objgenenral.FetchData(queryapp);
            if (dtappfetch.Rows.Count > 0)
            {
                GridViewReject.DataSource = dtappfetch;
                GridViewReject.DataBind();
            }
        }
        catch (Exception exc)
        {
            throw (exc);
           // lblmsg.Text = exc.ToString();
        }
        finally
        {
            dtappfetch = null;
        }
    }

  protected void radionewold_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (radionewold.SelectedValue == "1")
        {
            cerpfrm.Style.Add("display", "");
            TextAppId.Visible = true;
        }
        else
        {
            cerpfrm.Style.Add("display", "none");
            TextAppId.Visible = false;
        }
    }

  protected void Search_Click(object sender, EventArgs e)
  {
      objgenenral = new BaseLayer.General_function();
      DataTable dt = new DataTable();
      string SerchFormno = txtSearchFormno.Text;
      string queryapp = "";
      queryapp = "SELECT (a.forename+' '+a.surname) as Name, a.cerpac_no, b.FORMNO, 'Status' = case when (a.cerpac_no=a.cerpac_file_no) then 'Fresh' else 'Renewal' end, 'Remark' = case when (b.IsRejected =5) then 'Call Back' else 'Rejected' end  FROM People as a RIGHT OUTER JOIN Zonemaster as c INNER JOIN UserZoneRelation as d  INNER JOIN PeopleChild as b ON d.UserId = b.RejectedBy ON c.ZoneCode = d.ZoneCode ON a.cerpac_no = b.CerpacNo where d.ZoneCode=" + ZoneID + " and b.FORMNO ='" + SerchFormno + "' and (b.IsRejected=5 or b.IsRejected=1 ) order by a.cerpac_no";
      try
      {
          dt = objgenenral.FetchData(queryapp);
          if (dt.Rows.Count > 0)
          {
              Response.Redirect("FrmApplicationDetailsForReject.aspx?no=" + dt.Rows[0]["cerpac_no"].ToString().Trim() + "&fno=" + dt.Rows[0]["formno"].ToString().Trim() + "");
     
          }
          else 
          {
              lblmsg.Text = "This Secured Sold Form No. does not found in the reject and callback utility. ";
              lblmsg.CssClass = "warning-box";
                  
          }
      }
      catch (Exception exc)
      {
          throw (exc);
         
      }
      finally
      {
          dt = null;
      }     
  }

    protected void Go_Click(object sender, EventArgs e)
    {
        objgenenral = new BaseLayer.General_function();

        if (radionewold.SelectedValue == "0")
        {

            if (txtssfn.Text.ToString() == "" || txtssfn.Text.ToString() == string.Empty)
            {
                lblmsg.Text = "Please Enter Secured Form No";
                lblmsg.CssClass = "warning-box";
            }
            else if (txtssfn.Text.Length < 8)
            {
                lblmsg.Text = "You have not entered correct Secured form number. Please check again.";
                lblmsg.CssClass = "warning-box";
            }
            else
            {
                TextAppId.Text = txtssfn.Text.ToString();
                //--------------------------------------------------------checking that the person who puchased the form is the same--------------------------------------
                string queryforupload = "Select * from uploaded_Excel_Data where FORMNO='" + txtssfn.Text.ToString().Trim() + "' and CerpacNo='" + TextAppId.Text.ToString().Trim() + "'";
                DataTable dtupload = new DataTable();
                DataTable dtzone = new DataTable();
               
                DataTable dtzonename = new DataTable();
                try
                {
                    dtupload = objgenenral.FetchData(queryforupload);
                    if (dtupload.Rows.Count > 0)
                    {
                        //-----------------------------------------------------------------------end--------------------------------------------------------------------------------
                        //-------------------------------------------checking for processing at some other zone-------------------------------
                        string queryforzone = "Select * from CerpacNo_Out_One as a,PeopleChild as b where b.IsRejected=1 and (b.IsVerified=0 or b.IsVerified is NULL) and B.CerpacNo ='" + TextAppId.Text.ToString() + "' and b.FORMNO='" + txtssfn.Text.ToString() + "'"; 

                        dtzone = objgenenral.FetchData(queryforzone);
                        
                        if (dtzone.Rows.Count > 0)
                        {
                            Response.Redirect("FrmApplicationDetailsForReject.aspx?no=" + TextAppId.Text.ToString() + "&fno=" + txtssfn.Text.ToString().Trim() + "");
                        }
                         else
                        {
                            //-------------------------------------------------------end------------------------------------------------------
                            lblmsg.Text = "No Record Found.";
                            lblmsg.CssClass = "warning-box";
                        }
                    }
                    else
                    {
                        lblmsg.Text = "This Form Number is not correct.Please enter correct form no";
                        lblmsg.CssClass = "warning-box";
                    }
                }
                catch (Exception exc)
                {
                    //lblmsg.Text = exc.ToString();
                    //lblmsg.CssClass = "error-box";
                    throw (exc);
                }
                finally
                {
                     dtupload = null;
                     dtzone = null;
                     dtzonename = null;
                }
            }
            
        }
        else
        {
            if (txtssfn.Text.ToString() == "" || txtssfn.Text.ToString() == string.Empty || TextAppId.Text.ToString() == "" || TextAppId.Text.ToString() == string.Empty)
            {
                lblmsg.Text = "Please Enter Secured Form No and Cerpac no.";
                lblmsg.CssClass = "warning-box";
            }
            else if (txtssfn.Text.Length < 8 || TextAppId.Text.Length < 8)
            {
                lblmsg.Text = "You have not entered correct Secured form number. Please check again.";
                lblmsg.CssClass = "warning-box";
            }
            //else if (txtssfn.Text.ToString() == TextAppId.Text.ToString())
            //{
            //    lblmsg.Text = "This is not a fresh Case";
            //    lblmsg.CssClass = "warning-box";
            //}
            else
            {
                //--------------------------------------------------------checking that the person who puchased the form is the same--------------------------------------
                string queryforupload = "Select * from uploaded_Excel_Data where FORMNO='" + txtssfn.Text.ToString().Trim() + "' and CerpacNo='" + TextAppId.Text.ToString().Trim() + "'";
                DataTable dtupload = new DataTable();
                DataTable dtzone = new DataTable();
                DataTable dtzonename = new DataTable();
                try
                {
                    dtupload = objgenenral.FetchData(queryforupload);
                    if (dtupload.Rows.Count > 0)
                    {
                        //-----------------------------------------------------------------------end--------------------------------------------------------------------------------
                        string queryforzone = "Select * from CerpacNo_Out_One as a,PeopleChild as b where b.IsRejected=1 and (b.IsVerified=0 or b.IsVerified is NULL) and b.CerpacNo ='" + TextAppId.Text.ToString() + "' and b.FORMNO='" + txtssfn.Text.ToString() + "'";

                        dtzone = objgenenral.FetchData(queryforzone);

                        if (dtzone.Rows.Count > 0)
                        {
                            Response.Redirect("FrmApplicationDetailsForReject.aspx?no=" + TextAppId.Text.ToString() + "&fno=" + txtssfn.Text.ToString().Trim() + "");

                        }

                        else
                        {
                            lblmsg.Text = "No record found.";
                            lblmsg.CssClass = "warning-box";
                        }
                    }
                    else
                    {
                        lblmsg.Text = "This Form Number is Sold to some other person.Please enter correct form no";
                        lblmsg.CssClass = "warning-box";
                    }
                }
                catch (Exception exc)
                {
                    lblmsg.Text = exc.ToString();
                    lblmsg.CssClass = "error-box";
                }
                finally
                {
                    dtupload = null;
                    dtzone = null;
                    dtzonename = null;
                }
            }
        }
    }

    protected void GridViewReject_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        GridViewReject.PageIndex = e.NewPageIndex;
        bindgrid();
    }

    protected void GridViewReject_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            //  e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
            e.Row.ToolTip = "Click to select row";
            e.Row.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.GridViewReject, "Select$" + e.Row.RowIndex);
        }
    }
    protected void GridViewReject_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = GridViewReject.SelectedRow;

       // GetData(row.Cells[6].Text);

      //  string lbl_frm_no = GridViewReject.FindControl("cerpac_file_no").ToString();

        String llbl = ((Label)row.Cells[3].FindControl("lblFRNNo")).Text;

        if ((Request.QueryString["rej"]) == "5")
        {
            Response.Redirect("FrmApplicationDetailsForReject.aspx?no=" + row.Cells[1].Text + "&fno=" + llbl.ToUpper().Trim() + "&rejection=5");
        }
        else
        {
            Response.Redirect("FrmApplicationDetailsForReject.aspx?no=" + row.Cells[1].Text + "&fno=" + llbl.ToUpper().Trim() + "");
        }
       
    }
}