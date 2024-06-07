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
                        

                    }
                }


               

                /***********************************/



                ImgPhoto.ImageUrl = "~/Images/Logo/" + Dt.Rows[0]["picture"].ToString().Trim();
                txtPeoplename.Text = Dt.Rows[0]["forename"].ToString().Trim() + " " + Dt.Rows[0]["middle_name"].ToString().Trim()+" "+Dt.Rows[0]["surname"].ToString().Trim();
                txtfrnno.Text = Dt.Rows[0]["cerpac_file_no"].ToString().Trim();
                TxtCerpacNo.Text = Dt.Rows[0]["cerpac_no"].ToString().Trim();
                lblPeopleCerpac.Text = Dt.Rows[0]["cerpac_no"].ToString().Trim();
                lblPeopleNationlaity.Text = Dt.Rows[0]["nationality"].ToString().Trim();
                lblPeoplePassportNo.Text = Dt.Rows[0]["passport_no"].ToString().Trim();
                //--------------------------------------fetching company name from comp master-------------------------------
                DataTable dtcomp = null;
                dtcomp = new DataTable();
                string queryforcomp = "";
                queryforcomp = "Select regno,company from compmaster where regno = '" + Dt.Rows[0]["company"].ToString().Trim() + "'";
                
                ObjGenBal = new BaseLayer.General_function();
                dtcomp = ObjGenBal.FetchData(queryforcomp);
                if (dtcomp.Rows.Count > 0)
                {
                    txtPeolpeCompany.Text = dtcomp.Rows[0]["company"].ToString().Trim();
                    txtPeolpeCompany.ToolTip = dtcomp.Rows[0]["company"].ToString().Trim();

                }
                else
                {
                    //txtcompid.Text = "";
                    txtPeolpeCompany.Text = "";
                }
                //-----------------------------------------------------------------end----------------------------------------
                //------------------------------------------------------------code to fetch expiry date from view----------------------------------------------
                string expdtquery = "Select * from vw_prod_consolidated_data where IsVerified='1' and IsAuthorized='1' and (IsARCR is null or IsARCR = '0' or IsARCR='') and (IsProduced is null or IsProduced = '0' or IsProduced='') and cerpac_no='" + TxtCerpacNo.Text.ToString().Trim() + "' ";
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
                string numquery = "select * from PeopleChild  where IsAuthorized=1 and IsVerified=1 and (ISARCR=0 or ISARCR is null) and cerpacno='" + ApplicationId.ToString() + "'";
                DataTable dtnum = null;
                dtnum = new DataTable();
                dtnum = ObjGenBal.FetchData(numquery);
                if (dtnum.Rows.Count > 0)
                {
                    lblnum.Text = dtnum.Rows.Count.ToString();
                    if (dtnum.Rows.Count == 1)
                    {
                        txtfrnnoorig.Text = dtnum.Rows[0]["FORMNO"].ToString();
                    }
                    else
                    {
                        string frnfinal = "";
                        for (int i = 0; i < dtnum.Rows.Count; i++)
                        {
                            frnfinal = dtnum.Rows[i]["FORMNO"].ToString() + "," + frnfinal.ToString();
                            
                        }
                        txtfrnnoorig.Text = frnfinal.Substring(0, frnfinal.Length - 1);
                    }

                    bankdetails(txtfrnnoorig.Text.ToString().Trim());
                }
                else
                {
                    lblnum.Text = "0";
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
                string queryforbankdetails = "Select * from Uploaded_excel_data where FORMNO='" + txtfrnno.Text.ToString().Trim() + "'";
                DataTable dtbnk = null;
                dtbnk = new DataTable();
                dtbnk = ObjGenBal.FetchData(queryforbankdetails);
                if (dtbnk.Rows.Count > 0)
                {
                   // lblform1.Text = txtfrnno.Text.ToString().Trim();
                    //txtbankname.Text = dtbnk.Rows[0]["FirstName"].ToString() + " " + dtbnk.Rows[0]["LastName"].ToString();
                   // txtcompanybank.Text = dtbnk.Rows[0]["COMPANY"].ToString();
                    lblprchase.Text = string.Format("{0:d-MM-yyyy}", dtbnk.Rows[0]["Date1"]).ToString().Trim().Replace('-', '/');
                   // lblBankNationality.Text = dtbnk.Rows[0]["nationality"].ToString();
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

    public void bankdetails(string data)
    {
        if (data.ToString() != "")
        {
            string querytxt = data.ToString();
           // string[] formnos = new string[10];
            //formnos = querytxt.Split(',');
            string formnos="";
            formnos = querytxt.Replace(",","','");

                BaseLayer.General_function gnfc = new BaseLayer.General_function();
                string query = "Select formno, (FirstName+' '+LastName) as Name, NATIONALITY, Passportno, Company from uploaded_excel_Data where FORMNO in ('" + formnos.ToString().Trim() + "')";
                DataTable dtfrms = new DataTable();
                dtfrms = gnfc.FetchData(query);
                if (dtfrms.Rows.Count > 0)
                {
                    DataList1.DataSource= dtfrms;
                  
                    DataList1.DataBind();
                  
                    //lblform2.Text = formnos[1].ToString().Trim();
                    //lblform2name.Text = dtfrms.Rows[0]["FirstName"].ToString() + " " + dtfrms.Rows[0]["LastName"].ToString();
                    //lblform2company.Text = dtfrms.Rows[0]["company"].ToString();
                    //lblform2nationality.Text = dtfrms.Rows[0]["nationality"].ToString();

                }
            //if (formnos.Length == 2)
            //{
            //    BaseLayer.General_function gnfc = new BaseLayer.General_function();
            //    string query = "Select * from uploaded_excel_Data where FORMNO='" + formnos[1].ToString().Trim() + "'";
            //    DataTable dtfrms = new DataTable();
            //    dtfrms = gnfc.FetchData(query);
            //    if (dtfrms.Rows.Count > 0)
            //    {
            //        lblform2.Text = formnos[1].ToString().Trim();
            //        lblform2name.Text = dtfrms.Rows[0]["FirstName"].ToString() + " " + dtfrms.Rows[0]["LastName"].ToString();
            //        lblform2company.Text = dtfrms.Rows[0]["company"].ToString();
            //        lblform2nationality.Text = dtfrms.Rows[0]["nationality"].ToString();
            //        lblform3.Text = "NA";
            //        lblform3name.Text = "NA";
            //        lblform3nationality.Text = "NA";
            //        lblform3company.Text = "NA";
            //    }
            //    else
            //    {

            //    }
            //}
            //else if (formnos.Length >= 3)
            //{
            //    BaseLayer.General_function gnfc = new BaseLayer.General_function();
            //    string query = "Select * from uploaded_excel_Data where FORMNO='" + formnos[1].ToString().Trim() + "'";
            //    DataTable dtfrms = new DataTable();
            //    dtfrms = gnfc.FetchData(query);
            //    if (dtfrms.Rows.Count > 0)
            //    {
            //        lblform2.Text = formnos[1].ToString().Trim();
            //        lblform2name.Text = dtfrms.Rows[0]["FirstName"].ToString() + " " + dtfrms.Rows[0]["LastName"].ToString();
            //        lblform2company.Text = dtfrms.Rows[0]["company"].ToString();
            //        lblform2nationality.Text = dtfrms.Rows[0]["nationality"].ToString();
            //    }

            //    string query3 = "Select * from uploaded_excel_Data where FORMNO='" + formnos[2].ToString().Trim() + "'";
            //    DataTable dtfrms3 = new DataTable();
            //    dtfrms3 = gnfc.FetchData(query3);
            //    if (dtfrms3.Rows.Count > 0)
            //    {
            //        lblform3.Text = formnos[2].ToString().Trim();
            //        lblform3name.Text = dtfrms3.Rows[0]["FirstName"].ToString() + " " + dtfrms3.Rows[0]["LastName"].ToString();
            //        lblform3company.Text = dtfrms3.Rows[0]["company"].ToString();
            //        lblform3nationality.Text = dtfrms3.Rows[0]["nationality"].ToString();

            //    }
            //}

        }
        else
        {
            
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
                p.InnerHtml = "Applicant Confirmed Sucessfully";
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
                confirm.Style.Add("display", "block");
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

        pram = new SqlParameter[7];
        pram[0] = new SqlParameter("@UserId", objectSessionHolderPersistingData.User_ID);
        pram[1] = new SqlParameter("@cerpacno", cerpacno.ToString());
        pram[2] = new SqlParameter("@frnno", frnno);
        pram[3] = new SqlParameter("@reason", radreason.SelectedValue.ToString().Trim());
        pram[4] = new SqlParameter("@cerpac_expiry_date", lblexp.Text.ToString().Trim());
        pram[5] = new SqlParameter("@cerpac_receipt_date", lblrcpt.Text.ToString().Trim());
        pram[6] = new SqlParameter("@SuccessId", 1);
        pram[6].Direction = ParameterDirection.Output;
        SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_CERPAC_DATA_DENY_COMPLETELY", pram);
        return int.Parse(pram[6].Value.ToString());
    }

    protected void txtfrnnoorig_Click(object sender, EventArgs e)
    {
        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "Onclick", "<script>window.open('BankCheck.aspx?FormNo=" + txtfrnnoorig.Text.ToString() + "','Bank Forms','menubar=no,status=yes,Width=1000,Height=450,top=50,left=5,scrollbar=yes');</script>");
    }
   
}