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
    string AppID = "";
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
        if (string.IsNullOrEmpty(Request.QueryString["no"]) == false && Request.QueryString["no"] != "")
        {
            AppID = Convert.ToString(Request.QueryString["no"]);
        }

        if (!IsPostBack)
        {
            if (string.IsNullOrEmpty(Request.QueryString["no"]) == false && Request.QueryString["no"] != "")
            {
                GetData(AppID);
                // GetComments(AppID);

            }


        }
    }

    private void GetData(string ApplicationId)
    {
        DataTable Dt = null;
        Dt = new DataTable();
        ObjGenBal = new BaseLayer.General_function();
        string queryforcerpac = "select a.*,b.* from People as a , PeopleChild as b where a.cerpac_no = b.CerpacNo and b.IsAuthorized=1 and b.IsVerified=1 and (b.ISARCR=0 or b.ISARCR is null) and a.cerpac_no='" + ApplicationId.ToString() + "'";
        Dt = ObjGenBal.FetchData(queryforcerpac);
        try
        {
            if (Dt.Rows.Count > 0)
            {

                /**********Fetch Image**************/

                byte[] picData = Dt.Rows[0]["userimage"] as byte[] ?? null;
                System.Drawing.Image newImage;

                if (picData != null)
                {
                    using (MemoryStream ms = new MemoryStream(picData))
                    {
                        // Load the image from the memory stream. How you do it depends
                        // on whether you're using Windows Forms or WPF.
                        // For Windows Forms you could write:
                        // System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(ms);

                        newImage = System.Drawing.Image.FromStream(ms);

                        if (Dt.Rows[0]["picture"] == null || Dt.Rows[0]["picture"].ToString() == "")
                            Dt.Rows[0]["picture"] = Dt.Rows[0]["cerpac_no"] + ".jpg";

                        if (!File.Exists(Server.MapPath("~") + "/Images/Logo/" + Dt.Rows[0]["picture"].ToString().Trim()))
                            newImage.Save(Server.MapPath("~") + "/Images/Logo/" + Dt.Rows[0]["picture"].ToString().Trim());
                        // newImage.Save("g:/Saurabh" + Dt.Rows[0]["picture"].ToString().Trim());

                    }
                }


                //ViewState["imagepath"] = Dt.Rows[0]["picture"].ToString().Trim();

                /***********************************/



                ImgPhoto.ImageUrl = "~/Images/Logo/" + Dt.Rows[0]["picture"].ToString().Trim();

                txtpassportno.Text = Dt.Rows[0]["passport_no"].ToString().Trim();
                //TxtNationality.Text = string.Format("{0:dd/MM/yy}", Dt.Rows[0]["nationality"]).ToString().Trim();
                //TxtPassportType.Text = string.Format("{0:dd/MM/yy}", Dt.Rows[0]["passport_issue_by"]).ToString().Trim();
               // TxtDateOfIssue.Text = string.Format("{0:dd/MM/yy}", Dt.Rows[0]["passport_issue_date"]).ToString().Trim();
                //txtdoe.Text = string.Format("{0:dd/MM/yy}", Dt.Rows[0]["passport_expiry_date"]).ToString().Trim();
                //TxtPlaceOfIssue.Text = Dt.Rows[0]["passport_issue_loc"].ToString().Trim();
                txtdbname.Text = Dt.Rows[0]["forename"].ToString().Trim() + " " + Dt.Rows[0]["middle_name"].ToString().Trim()+" "+Dt.Rows[0]["surname"].ToString().Trim();
                txtfrnno.Text = Dt.Rows[0]["cerpac_file_no"].ToString().Trim();
                
                //--------------------------------------fetching company name from comp master-------------------------------
                DataTable dtcomp = null;
                dtcomp = new DataTable();
                string queryforcomp = "";
                
                    queryforcomp = "Select regno,company from compmaster where regno = '" + Dt.Rows[0]["company"].ToString().Trim() + "'";
                
                //  string queryforcomp = "Select company from compmaster where regno='" + Dt.Rows[0]["company"].ToString().Trim() + "'";
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


               TxtCerpacNo.Text = Dt.Rows[0]["cerpac_no"].ToString().Trim();


                //if (Dt.Rows[0]["cerpac_receipt_date"].ToString().Trim() != null || Dt.Rows[0]["cerpac_receipt_date"].ToString().Trim() != "")
                //{
                //    TxtIssueDate.Text = string.Format("{0:dd/MM/yy}", Dt.Rows[0]["cerpac_receipt_date"]).ToString().Trim();
                //    TxtExpDate.Text = string.Format("{0:dd/MM/yy}", Dt.Rows[0]["cerpac_expiry_date"]).ToString().Trim();
                //}
                //else
                //{
                //    TxtIssueDate.Text = "-----";
                //    TxtExpDate.Text = "-----";
                //}
                //-------------------------------------------fetching bank details-------------------------
               string queryforbankdetails = "Select * from Uploaded_excel_data where FORMNO='" + txtfrnno.Text.ToString().Trim() + "'";
               DataTable dtbnk = null;
               dtbnk = new DataTable();
               dtbnk = ObjGenBal.FetchData(queryforbankdetails);
               if (dtbnk.Rows.Count > 0)
               {
                   txtbankname.Text = dtbnk.Rows[0]["FirstName"].ToString() + " " + dtbnk.Rows[0]["LastName"].ToString();
                   txtcompanybank.Text = dtbnk.Rows[0]["COMPANY"].ToString();

               }
                //------------------------------------------------end---------------------------------------
            }
            else
            {
                detailtable.Style.Add("display", "none");
                warn.Style.Add("display", "");
            }

            //--------------------------------------------- data from bank-------------------------------------------

            //--------------------------------------------------end--------------------------------------------------
        }
        catch (Exception ex)
        {
            ObjGenBal = new BaseLayer.General_function();
            string err = ObjGenBal.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.Visible = true;
        }

    }

    protected void btnverify_Click(object sender, EventArgs e)
    {
        try
        {
            int status = confirmeligibility();
            if (status == 1)
            {
                authtable.Style.Add("display", "none");
                confirm.Style.Add("display", "");
                confirm.Attributes.Add("class", "confirmation-box animated-table bounceIn");
            }
        }
        catch (Exception ex)
        {
            ObjGenBal = new BaseLayer.General_function();
            string err = ObjGenBal.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.Visible = true;
        }
        finally
        {
            ObjGenBal = null;
        }

    }

    public int confirmeligibility()
    {
        SqlParameter[] pram = null;

        pram = new SqlParameter[4];
        pram[0] = new SqlParameter("@UserId", objectSessionHolderPersistingData.User_ID);
        pram[1] = new SqlParameter("@cerpacno", TxtCerpacNo.Text.ToString());
        pram[2] = new SqlParameter("@SuccessId", 1);
        pram[2].Direction = ParameterDirection.Output;
        SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_CERPAC_DATA_CONFIRM", pram);
        return int.Parse(pram[2].Value.ToString());
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            int status = defer();
            if (status == 1)
            {
                authtable.Style.Add("display", "none");
                confirm.Style.Add("display", "");
                confirm.Attributes.Add("class", "confirmation-box animated-table bounceIn");
                p.InnerHtml = "Application Rejected";

            }
        }
        catch (Exception ex)
        {
            ObjGenBal = new BaseLayer.General_function();
            string err = ObjGenBal.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.Visible = true;
        }
        finally
        {
            ObjGenBal = null;
        }
    }

    public int defer()
    {
        SqlParameter[] pram = null;

        pram = new SqlParameter[3];
        pram[0] = new SqlParameter("@UserId", objectSessionHolderPersistingData.User_ID);
        pram[1] = new SqlParameter("@cerpacno", TxtCerpacNo.Text.ToString());
        pram[2] = new SqlParameter("@SuccessId", 1);
        pram[2].Direction = ParameterDirection.Output;
        SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_CERPAC_DATA_DEFER", pram);
        return int.Parse(pram[2].Value.ToString());

    }

    protected void btnAppliHist_Click(object sender, EventArgs e)
    {
        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "Onclick", "<script>window.open('viewAppliHist.aspx?AppID=" + TxtCerpacNo.Text.ToString() + "','PaperVisa','menubar=no,status=yes,Width=1000,Height=1020,top=50,left=5,scrollbar=yes');</script>");

    }
    protected void btndenycompletely_Click(object sender, EventArgs e)
    {
        try
        {
            int result = 0;
            ObjGenBal = new BaseLayer.General_function();
            string peoplechildquery = "Select * from Peoplechild where cerpacno='" + TxtCerpacNo.Text.ToString().Trim() + "' and IsAuthorized=1 and (IsARCR is null or IsARCR=0 or IsARCR='') and (IsProduced is null or IsProduced=0)";
            DataTable dtpc = null;
            dtpc = new DataTable();
            dtpc = ObjGenBal.FetchData(peoplechildquery);
            if (dtpc.Rows.Count > 0)
            {
                for (int i = 0; i < dtpc.Rows.Count; i++)
                {
                    string cerpacno = dtpc.Rows[i]["cerpacno"].ToString().Trim();
                    string frnno = dtpc.Rows[i]["FORMNO"].ToString().Trim();
                    int status = denycompletely(cerpacno, frnno);
                    result = result + status;
                }
                if (result > 0)
                {
                    authtable.Style.Add("display", "none");
                    confirm.Style.Add("display", "");
                    confirm.Attributes.Add("class", "confirmation-box animated-table bounceIn");
                    p.InnerHtml = "Application Rejected and form(s) are free for use now.";
                }
                else
                {
                    this.ClientScript.RegisterClientScriptBlock(this.GetType(), "Onclick", "<script>alert('Error occured.Try again later');</script>");
                }
            }
        }
        
        catch(Exception ex)
        {
            ObjGenBal = new BaseLayer.General_function();
            string err = ObjGenBal.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.Visible = true;
        }
    }

    public int denycompletely(string cerpacno, string frnno)
    {
        SqlParameter[] pram = null;

        pram = new SqlParameter[4];
        pram[0] = new SqlParameter("@UserId", objectSessionHolderPersistingData.User_ID);
        pram[1] = new SqlParameter("@cerpacno", cerpacno.ToString());
        pram[2] = new SqlParameter("@frnno", frnno);
        pram[3] = new SqlParameter("@SuccessId", 1);
        pram[3].Direction = ParameterDirection.Output;
        SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_CERPAC_DATA_DENY_COMPLETELY", pram);
        return int.Parse(pram[3].Value.ToString());
    }
}