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
using System.Data.SqlClient;
using Microsoft.Reporting.WebForms;
using System.Drawing.Printing;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Drawing2D;
using System.IO;
using System.Globalization;
using System.Net.NetworkInformation;

public partial class Admin_frmProductionRep : System.Web.UI.Page
{

    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;

    BaseLayer.General_function ObjGeneral = null;
    protected BaseLayer.General_function ObjGenBal = null;

    Label LabelMessage = null;

    DataTable dtZ = new DataTable();
   
    protected DataSet objDs = new DataSet();



    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        From.HRef = "javascript:NewCal('" + txtFromDate.ClientID + "','DDMMMYYYY','','',1,80)";
      
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];

        LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
       
        if (!IsPostBack)
        {
            ObjGenBal = new BaseLayer.General_function();
            objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];

            if (objectSessionHolderPersistingData == null)
            {
                Response.Redirect("../Login.aspx");
            }

            string queryforzonename = "select b.ZoneName, b.ZoneIP , b.ZoneCode from UserZoneRelation as a, Zonemaster as b where a.ZoneCode=b.ZoneCode and a.UserId=" + objectSessionHolderPersistingData.User_ID + "";
            ObjGenBal = new BaseLayer.General_function();
            DataTable dt = new DataTable();
            try
            {
                dt = ObjGenBal.FetchData(queryforzonename);
                if (dt.Rows.Count > 0)
                {
                    LabelMessage.Text =  dt.Rows[0]["ZoneName"].ToString();
                    ViewState["ZoneName"] = dt.Rows[0]["ZoneName"].ToString();
                    ViewState["ZoneIP"]=dt.Rows[0]["ZoneIP"].ToString();
                    ViewState["ZoneCode"]=dt.Rows[0]["ZoneCode"].ToString();
                    LabelMessage.Visible = true;
                    LabelMessage.BorderStyle = BorderStyle.None;
                    DaliyProd();
                    
                }
            }
            catch (Exception ex)
            {
                ObjGenBal = new BaseLayer.General_function();
                string err = ObjGenBal.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
                LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
                LabelMessage.CssClass = "warning-box";
                LabelMessage.Visible = true;
            }
            finally
            {
                dt = null;
               
            }        
            
        }    
        
    }
    public static string ConvertDate(string date, string pattern)
    {

        if (string.IsNullOrEmpty(date) == false && date != "")
        {
            DateTime date2;
            if (DateTime.TryParseExact(date, pattern, CultureInfo.InvariantCulture, DateTimeStyles.None, out date2))
            {
                return date2.ToString("MM/dd/yyyy");
            }
            else
            {
                return "";
            }
        }
        else
        {
            return "";
        }
    }
   

    protected void btn_generate_report_Click(object sender, EventArgs e)
    {
       
        if (txtFromDate.Value == "")
        {

            ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Please Fill From-Date.');", true);
            return;

        }
        else
        {
            ProdCount();
            WastedCount();
            DaliyProd();
            int T=0;
            if (txtWastedCard.Text != "" && txtProdCount.Text != "")
            {
                 T=  ( Convert.ToInt32(txtProdCount.Text) + Convert.ToInt32(txtWastedCard.Text));
                txtTotalCount.Text = T.ToString();
            }
        }
        
    }

    public void ProdCount()
    {
        ObjGeneral = new BaseLayer.General_function();
        DataTable dt = new DataTable();

        try
        {

            if (txtFromDate.Value != "")
            {
            
                String Query = "Select Count(Distinct(card_no)) as ProdCount from tbl_lamination_detail where (created_on ='" + ConvertDate(txtFromDate.Value, "d-MM-yyyy") + " ' )  and lam_printedYN=1 and lam_wastedYN=0";
                dt = ObjGeneral.FetchData(Query);
         
                if (dt.Rows.Count > 0)
                {
                    txtProdCount.Text = dt.Rows[0]["ProdCount"].ToString();                   
                }
            }
            
        }
        catch (Exception ex)
        {
            ObjGenBal = new BaseLayer.General_function();
            //Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            string err = ObjGenBal.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.CssClass = "warning-box";
            LabelMessage.Visible = true;
        }
    }


    public void WastedCount()
    {
        ObjGeneral = new BaseLayer.General_function();
        DataTable dt = new DataTable();

        try
        {

            if (txtFromDate.Value != "")
            {

                String Query = "Select Count(Distinct(card_no)) as ProdCount from tbl_lamination_detail where (created_on ='" + ConvertDate(txtFromDate.Value, "d-MM-yyyy") + "' )  and lam_printedYN=1 and lam_wastedYN=1";
                dt = ObjGeneral.FetchData(Query);

                if (dt.Rows.Count > 0)
                {
                    txtWastedCard.Text = dt.Rows[0]["ProdCount"].ToString();
                }
            }

        }
        catch (Exception ex)
        {
            ObjGenBal = new BaseLayer.General_function();
            //Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            string err = ObjGenBal.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.CssClass = "warning-box";
            LabelMessage.Visible = true;
        }
    }


    //-------------------Button for synchroniz Production Report in Central and Zone------------------------
    protected void btnSynchornicReport_Click(object sender, EventArgs e)
    {


        try
        {
            //-----------------Central Server Connection String--------------
            SqlConnection Connection_C = new SqlConnection();
            Connection_C.ConnectionString = "Data Source=192.168.1.28;Initial Catalog=Cerpac;uid=sa;pwd=cenindia123;";

            SqlConnection Connection_Z = new SqlConnection();
            Connection_Z.ConnectionString = "Data Source='" + ViewState["ZoneIP"].ToString() + "';Initial Catalog=Cerpac;uid=sa;pwd=zoneindia123;";



            //---------------Check in Central--------------------------
            SqlDataAdapter AdapterZC = new SqlDataAdapter();
            DataSet dtc = new DataSet();
            string QueryCen = "Select * from ProdSummaryRep where  Prod_Date='" + ConvertDate(txtFromDate.Value, "d-MM-yyyy") + "'";

            if (IsConnectedToInternet() == true)
            {

                Connection_C.Open();
                AdapterZC.SelectCommand = new SqlCommand(QueryCen, Connection_C);
                AdapterZC.Fill(dtc);
                Connection_C.Close();
            }
            else
            {
                Response.Write("<script>alert('Please check connection with central server !.')</script>");
                return;
            }
            if (dtc.Tables[0].Rows.Count > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "MyFun1", "alert('Production Details  Already Exist in Central Server.');", true);
                return;
            }

            //-------------------Check in Zone---------    
            ObjGenBal = new BaseLayer.General_function();
       
            string QueryZone = "Select * from ProdSummaryRep where  Prod_Date='" + ConvertDate(txtFromDate.Value, "d-MM-yyyy") + "'";
            dtZ = ObjGenBal.FetchData(QueryZone);
            if (dtZ.Rows.Count > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "MyFun1", "alert('Production Details  Already Exist in Zonal Server.');", true);
                return;
            }

            //--------------Insert into Central table--------------
            SqlDataAdapter adapter1 = new SqlDataAdapter();
            string QueryC1 = "Select * from ProdSummaryRep where  Prod_Date='" + ConvertDate(txtFromDate.Value, "d-MM-yyyy") + "'";

            DataTable dt = new DataTable();
            Connection_C.Open();
            adapter1.SelectCommand = new SqlCommand(QueryC1, Connection_C);
            adapter1.Fill(dt);
            Connection_C.Close();

            if (dt.Rows.Count == 0)
            {
                if (IsConnectedToInternet() == true)
                {

                    Connection_C.Open();
                    string Command_C = "Insert into ProdSummaryRep (ZoneCode,ZoneName, Prod_Date, Prod_Card, Prod_Wasted, Prod_Total,CreatedON ,CreatedBy) Values  ( '" + ViewState["ZoneCode"].ToString() + "' ,'" + ViewState["ZoneName"].ToString() + "','" + ConvertDate(txtFromDate.Value, "d-MM-yyyy") + "','" + txtProdCount.Text.Trim() + "','" + txtWastedCard.Text.Trim() + "','" + txtTotalCount.Text.Trim() + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "'," + int.Parse(objectSessionHolderPersistingData.User_ID) + ")";
                    SqlHelper.ExecuteNonQuery(Connection_C, CommandType.Text, Command_C);
                    Connection_C.Close();

                    Connection_Z.Open();
                    string Command_Z = "Insert into ProdSummaryRep (ZoneCode,ZoneName, Prod_Date, Prod_Card, Prod_Wasted, Prod_Total,CreatedON ,CreatedBy) Values  ( '" + ViewState["ZoneCode"].ToString() + "' ,'" + ViewState["ZoneName"].ToString() + "','" + ConvertDate(txtFromDate.Value, "d-MM-yyyy") + "','" + txtProdCount.Text.Trim() + "','" + txtWastedCard.Text.Trim() + "','" + txtTotalCount.Text.Trim() + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "'," + int.Parse(objectSessionHolderPersistingData.User_ID) + ")";
                    SqlHelper.ExecuteNonQuery(Connection_Z, CommandType.Text, Command_Z);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", " alert('Daily Card Production Report Save Sussessfully in Central Server.'); window.open('frmProductionRep.aspx');", true);
                    Connection_Z.Close();
                    
                }
                else
                {
                    Response.Write("<script>alert('Please check connection with central server !.')</script>");
                    return;
                }

            }

        }
        catch (Exception ex)
        {
            ObjGenBal = new BaseLayer.General_function();

            string err = ObjGenBal.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.CssClass = "warning-box";
            LabelMessage.Visible = true;
        }
        finally
        {
            ProdCount();
          
        }
    }          


    
    //----------------------Check central server ping status----------------------------------
    public bool IsConnectedToInternet()
    {
        string pingurl = "192.168.1.28";   
        bool result = false;
        Ping p = new Ping();
        try
        {
            PingReply reply = p.Send(pingurl, 3000);
            if (reply.Status == IPStatus.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch
        {
            return false;
        }

    }

    //-------------------------Binding Grid Details ---------------------------------------

    public void DaliyProd()

    {
        try
        {
            //-------------------Check in Central---------


            ObjGenBal = new BaseLayer.General_function();

            string Query_ProdReport = "  Select Prod_Date,  Prod_Card , Prod_Wasted, Prod_Total , zonename From ProdSummaryRep order by year(Prod_Date) desc, month(Prod_Date) desc ,day(Prod_Date) desc";
            objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.Text, Query_ProdReport);



        }
        catch (Exception ex)
        {
            ObjGenBal = new BaseLayer.General_function();

            string err = ObjGenBal.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.CssClass = "warning-box";
            LabelMessage.Visible = true;
        }
        finally
        {
            //objDs = null;
        }
    }
}
