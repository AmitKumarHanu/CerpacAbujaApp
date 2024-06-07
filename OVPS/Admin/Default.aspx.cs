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

public partial class User_Default : System.Web.UI.Page
{

    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    Label LabelMessage = null;
    BaseLayer.General_function objgenenral = null;
    BaseLayer.General_function objgen = null;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        if (!IsPostBack)
        {
            if (objectSessionHolderPersistingData == null)
            {
                Response.Redirect("../Login.aspx");
            }
            string qualuser = ConfigurationManager.AppSettings["qualuser"].ToString();

            Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            string queryforzonename = "select b.ZoneName from UserZoneRelation as a, Zonemaster as b where a.ZoneCode=b.ZoneCode and a.UserId=" + objectSessionHolderPersistingData.User_ID + "";
            objgenenral = new BaseLayer.General_function();
            DataTable dt = new DataTable();
           
             
           /**********************Auto Quality*****************************/
            BusinessEntityLayer.BalProductionModule objProduction = new BusinessEntityLayer.BalProductionModule();
            

           // select cerpacno from (select cerpacno , DATEDIFF(DAY,ProducedOn,GETDATE()) as d from PeopleChild) a  where d > 20
            try
            {
               // string queryforAutoqual = "select cerpacno from (select cerpacno , DATEDIFF(DAY,ProducedOn,GETDATE()) as d, isqual from PeopleChild) a  where d > 20 and isqual<>1";
                string queryforAutoqual = "select cerpacno from (select cerpacno , DATEDIFF(DAY,ProducedOn,GETDATE()) as d, isqual from PeopleChild where isnull(isproduced,0)=1) a  where d > 20 and isnull(isqual,0)<>1";
                objgenenral = new BaseLayer.General_function();
                dt = objgenenral.FetchData(queryforAutoqual);

                for (int l = 0; l < dt.Rows.Count; l++)
                {
                    objProduction.UpdateQualityFlag(dt.Rows[l]["cerpacno"].ToString(), Convert.ToInt32(qualuser));
                }
            }
            catch (Exception ex)
            {
            }
            /*****************************Amit*********************************/

            SqlConnection Connection = new SqlConnection();
            Connection.ConnectionString = ConfigurationManager.ConnectionStrings["NigeriaConnectionString"].ConnectionString;
            //////Connection.Open();
            //////SqlCommand cmd11 = new SqlCommand("Delete from compnew where regno in (select regno from compnew_rep)", Connection);
            //////cmd11.ExecuteNonQuery();
            //////Connection.Close();
                   
            
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

            //-------------------------------------------Code for password policy-------------------------------
            string query = "Select * from tbl_passwordpolicy where UserId='" + objectSessionHolderPersistingData.User_ID + "'";
            objgen = new BaseLayer.General_function();
            DataTable dtpwd = new DataTable();
            dtpwd = objgen.FetchData(query);
            if (dtpwd.Rows.Count > 0)
            {
                DateTime d1 = Convert.ToDateTime(dtpwd.Rows[0]["ChangedOn"].ToString());
                DateTime d2 = Convert.ToDateTime(DateTime.Now);
                string d3 = (d2 - d1).TotalDays.ToString();
                if (double.Parse(d3) >= 20)
                {
                    Response.Redirect("~/User/FrmChangePassword.aspx?msg=abcdefghijklmnopqrstuvwxyz");
                }

            }
            else
            {
                Response.Redirect("~/User/FrmChangePassword.aspx?msg=abcdefghijklmnopqrstuvwxyz");
            }
            //---------------------------------------------------end----------------------------------------
            //---------------------------------- code to fetch last login ---------------------------------------
            try
            {
                string lastloginquery = "Select * from tbl_Passwordpolicy where userid='" + objectSessionHolderPersistingData.User_ID + "'";
                objgenenral = new BaseLayer.General_function();
                DataTable dtlastlogin = null;
                dtlastlogin = new DataTable();
                dtlastlogin = objgenenral.FetchData(lastloginquery);
                if (dtlastlogin.Rows.Count > 0)
                {
                    if ((dtlastlogin.Rows[0]["machineIP"].ToString() == null || dtlastlogin.Rows[0]["machineIP"].ToString() == string.Empty))
                    {
                        lbllastlogin.Text = "No login details found yet";
                    }
                    else
                    {
                        DayOfWeek lastday = Convert.ToDateTime(dtlastlogin.Rows[0]["LastLogin"].ToString()).DayOfWeek;
                       
                        string lastdate = string.Format("{0:d-MM-yyyy}", dtlastlogin.Rows[0]["LastLogin"]).ToString().Trim();
                        string lasttime = DateTime.Parse(dtlastlogin.Rows[0]["LastLogin"].ToString()).ToShortTimeString();
                        string IP = dtlastlogin.Rows[0]["machineip"].ToString();
                        //lbllastlogin.Text = "Your account was accessed last on " + lastday.ToString() + " (" + lastdate + ") at "+lasttime+" from " + IP + " ip address. If you have not accessed you accoutn, please change your password immediately.";
                        divmsg.InnerHtml = "Your account was accessed last on <strong> " + lastday.ToString() + ",(" + lastdate + "</strong>) at <strong>" + lasttime + "</strong> from <strong>" + IP + "</strong> ip address. If you have not accessed you account, please change your password immediately.";
                    }
                }
                else
                {
                    lbllastlogin.Text = "No last login details found yet last";
                }
            }
            catch
            {
 
            }
            //------------------------------------------end-------------------------------------------------------
            //---------------------------------------------code to update last login-----------------------------------------

           // Response.Write("<script>alert('" + HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString() + "')</script>");
            try
            {
                Connection.Open();
                string updatelogindetailquery = "update tbl_Passwordpolicy set LastLogin=GetDate(),machineip='" + HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString() + "' where userid='" + objectSessionHolderPersistingData.User_ID + "'";
                SqlCommand cmd1 = new SqlCommand(updatelogindetailquery, Connection);
                cmd1.ExecuteNonQuery();
                Connection.Close();
            }
            catch(Exception ex)
            {
                throw (ex);
            }
           //-------------------------------------------------------end-----------------------------------------------------
           
        }

        
    }



   

}