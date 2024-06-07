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

public partial class Admin_FrmConfirmEligibilityAO : System.Web.UI.Page
{
    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    BusinessEntityLayer.BalApprovalReviewL1 ObjbalApporvalL1 = null;
    protected BaseLayer.General_function ObjGenBal = null;
    string CerpacNo = "";
    string FRN = "";
    string UserID = null;
    Label LabelMessage = null;
    #endregion

    string ApplicationId;

    protected void Page_Load(object sender, EventArgs e)
    {
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        if (objectSessionHolderPersistingData == null)
        {
            Response.Redirect("../Login.aspx");
        }
        UserID = objectSessionHolderPersistingData.User_ID.ToString();
        LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
      //  if (string.IsNullOrEmpty(Request.QueryString["no"]) == false && Request.QueryString["no"] != "")
      // {
            
            FRN = Convert.ToString(Request.QueryString["FRN"]);
            CerpacNo = Convert.ToString(Request.QueryString["CerpacNo"]);
        
      // }

        if (!IsPostBack)
        {
           // if (string.IsNullOrEmpty(Request.QueryString["no"]) == false && Request.QueryString["no"] != "")
            {
                GetData(CerpacNo,FRN);
                // GetComments(AppID);

            }


        }
    }

    private void GetData(string ApplicationId, string FRN)
    {
        DataTable Dt = null;
        Dt = new DataTable();
        ObjGenBal = new BaseLayer.General_function();
        string queryforcerpac = "select * from vw_wrong_forms_used_report where cerpac_no='"+ApplicationId.ToString().Trim()+"' and cerpac_file_no='"+FRN.ToString().Trim()+"'";
        Dt = ObjGenBal.FetchData(queryforcerpac);
        try
        {
            if (Dt.Rows.Count > 0)
            {

                txtdbname.Text = Dt.Rows[0]["first_name"].ToString().Trim() +" "+Dt.Rows[0]["last_name"].ToString().Trim();
                txtfrnno.Text = FRN.ToString().Trim();
                TxtCerpacNo.Text = ApplicationId.ToString().Trim();
                //--------------------------------------fetching company name from comp master-------------------------------
                DataTable dtcomp = null;
                dtcomp = new DataTable();
                string queryforcomp = "";
                queryforcomp = "Select regno,company from compmaster where regno = '" + Dt.Rows[0]["comp"].ToString().Trim() + "'";
                
                ObjGenBal = new BaseLayer.General_function();
                dtcomp = ObjGenBal.FetchData(queryforcomp);
                if (dtcomp.Rows.Count > 0)
                {
                    txtcompany.Text = dtcomp.Rows[0]["company"].ToString().Trim();
                    txtcompany.ToolTip = dtcomp.Rows[0]["company"].ToString().Trim();

                }
                else
                {
                    //txtcompid.Text = "";
                    txtcompany.Text = "";
                }
                //-----------------------------------------------------------------end----------------------------------------
                //------------------------------------------------------------code to fetch expiry date from view----------------------------------------------
                string expdtquery = "Select * from people_wrong_forms_used_details where cerpac_file_no='"+txtfrnno.Text.ToString().Trim()+"' and cerpac_no='" + TxtCerpacNo.Text.ToString().Trim() + "' ";
                DataTable dtexpdt = null;
                dtexpdt = new DataTable();
                dtexpdt = ObjGenBal.FetchData(expdtquery);
                if (dtexpdt.Rows.Count > 0)
                {
                    lblexp.Text = string.Format("{0:d-MM-yyyy}", dtexpdt.Rows[0]["cerpac_expiry_date"]).ToString().Trim();
                    lblrcpt.Text = string.Format("{0:d-MM-yyyy}", dtexpdt.Rows[0]["cerpac_receipt_date"]).ToString().Trim();
                }
                //---------------------------------------------------------------------end---------------------------------------------------------------------
                //---------------------------------------------------------code to fetch the number of forms --------------------------------------------
                string numquery = "select count(*) as count,ConfirmedOn from people_wrong_forms_used_Details where cerpac_no='" + ApplicationId.ToString() + "' group by ConfirmedOn order by ConfirmedOn desc";
                    DataTable dtnum = null;
                    dtnum = new DataTable();
                    dtnum = ObjGenBal.FetchData(numquery);
                    if (dtnum.Rows.Count > 0)
                    {
                        //lblnum.Text = dtnum.Rows[0]["count"].ToString();
                        string confirmedon = string.Format("{0:yyyy-MM-dd}", dtnum.Rows[0]["ConfirmedOn"]).ToString().Trim();
                        string frnquery = "Select cerpac_file_no from people_wrong_forms_used_Details where cerpac_no='" + ApplicationId.ToString() + "' and confirmedon between '" + confirmedon + " 00:00:00" + "' and '" + confirmedon + " 23:59:59" + "'";
                        DataTable dtfrnquery = null;
                        dtfrnquery = new DataTable();
                        dtfrnquery = ObjGenBal.FetchData(frnquery);
                        if (dtfrnquery.Rows.Count == 1)
                        {
                            txtfrnnoorig.Text = dtfrnquery.Rows[0]["cerpac_file_no"].ToString();
                            lblnum.Text = "1";

                        }
                        else
                        {
                            string frnfinal = "";
                            for (int i = 0; i < dtnum.Rows.Count; i++)
                            {
                                frnfinal = dtfrnquery.Rows[i]["cerpac_file_no"].ToString() + "," + frnfinal.ToString();

                            }
                            txtfrnnoorig.Text = frnfinal.Substring(0, frnfinal.Length - 1);
                            string[] val = new string[10];
                            val = txtfrnnoorig.Text.Split(',');
                            lblnum.Text = val.Length.ToString();
                        }
                    }
                //-----------------------------------------------------------------------end-------------------------------------------------------------

                //-------------------------------------------------code to check the fresh or renewal case-------------------------------------------------
                string newrenewquery = "Select * from Issue where cerpac_no='" + TxtCerpacNo.Text.ToString().Trim() + "'";
                DataTable dtnewrenew = null;
                dtnewrenew = new DataTable();
                dtnewrenew = ObjGenBal.FetchData(newrenewquery);
                if (dtnewrenew.Rows.Count > 0)
                {
                    lblnewrenew.Text = "Renewal";
                }
                else
                {
                    lblnewrenew.Text = "Fresh";
                }
                //----------------------------------------------------------end-----------------------------------------------------------------------
               
               //--------------------------------------------- data from bank-------------------------------------------
               
                   txtbankname.Text = Dt.Rows[0]["FirstName"].ToString() + " " + Dt.Rows[0]["LastName"].ToString();
                   txtcompanybank.Text = Dt.Rows[0]["COMPANY"].ToString();
                   lblprchase.Text = string.Format("{0:d-MM-yyyy}", Dt.Rows[0]["Date1"]).ToString().Trim().Replace('-','/');
                //-----------------------------------------------end----------------------------------------------------

                //---------------------------------------------fetching reason---------------------------------------- 
                   string reasonquery = "Select Reason from people_wrong_forms_used_details where cerpac_no='" + ApplicationId.ToString().Trim() + "' and cerpac_file_no='" + FRN.ToString().Trim() + "'";
                   DataTable dtrsn = null;
                   dtrsn = new DataTable();
                   dtrsn = ObjGenBal.FetchData(reasonquery);
                   if (dtrsn.Rows.Count > 0)
                   {
                       if (dtrsn.Rows[0]["Reason"].ToString().Trim() == "BDMS")
                       {
                           lblreason.Text = "Bank Data Missmatch";
                       }
                       else if (dtrsn.Rows[0]["Reason"].ToString().Trim() == "EDWC")
                       {
                           lblreason.Text = "Expiry date wrongly calculated";
                       }
                       else if (dtrsn.Rows[0]["Reason"].ToString().Trim() == "OTHS")
                       {
                           lblreason.Text = "Others";
                       }
                       else if (dtrsn.Rows[0]["Reason"].ToString().Trim() == "FRMF")
                       {
                           lblreason.Text = "The Form was free before Production";
                       }
                       else
                       {
                           lblreason.Text = "No reason";
                       }
                   }
                   else
                   {
                       lblreason.Text = "No reason";
                   }
               
                //--------------------------------------------------end--------------------------------------------------
            }
            else
            {
                detailtable.Style.Add("display", "none");
                warn.Style.Add("display", "");
            }

            
        }
        catch (Exception ex)
        {
            ObjGenBal = new BaseLayer.General_function();
            string err = ObjGenBal.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.Visible = true;
        }

    }

    
}