using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.Data.SqlClient;
using DataAccessLayer;
using System.Drawing.Printing;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Text;
using System.IO;
using System.Globalization;
using System.Threading;


public partial class Admin_frmCerpacFormNoTracking : System.Web.UI.Page
{
        #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    #endregion
    String UserID = null;




    BaseLayer.General_function objGeneral = null;
    BusinessEntityLayer.BalDocdetails ObjBalDocdetails = null;
    
    protected void Page_Load(object sender, EventArgs e)
    {       
        objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        if (objectSessionHolderPersistingData == null)
        {
            Response.Redirect("../Login.aspx");
        }
        UserID = objectSessionHolderPersistingData.User_ID.ToString();
       
      // string companyid = objectSessionHolderPersistingData.CompanyId;
        Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
        try
        {
            if (!IsPostBack)
            {
                ClearlabalFun();
                DivOpt.Visible = true;
                DivAuthMsg.Visible = false;
                DivCheckSheet.Visible = false;
                DivCreateRequest.Visible = false;

                CallBackStatus();
             }
        }
        catch (Exception ex)
        {
            objGeneral = new BaseLayer.General_function();            
            string err = objGeneral.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.CssClass = "warning-box";
            LabelMessage.Visible = true;
        }
        finally
        {
           
        }
    }
        
     public void ClearlabalFun()
    {
        lblFRMNo.Text = "";
        lblAuthBy.Text = "";
        lblAuthDt.Text = "";
        lblAuthTime.Text = "";
        lblCerpacExpDt.Text = "";
       // lblDOB.Text = "";

        lblCompanyName.Text = "";
        lblForeName.Text = "";
        lblCerpacNo.Text = "";
        lblMiddleName.Text = "";
        lblDesignation.Text = "";
        lblPassportNo.Text = "";

        lblProdBy.Text = "";
        lblProdOn.Text = "";
        lblProdTime.Text = "";
        lblQualityBy.Text = "";
        lblQualityOn.Text = "";
        lblQualTime.Text = "";

        lblStatusAC.Text = "";
        lblContecBy.Text = "";
        lblContecDt.Text = "";
        lblContecT.Text = "";

        lblSex.Text = "";
        lblStatusA.Text = "";
        lblStatusP.Text = "";
        lblStatusQ.Text = "";
        lblStatusV.Text = "";
        lblSurName.Text = "";

        lblTitle.Text = "";
        lblVerify.Text = "";
        lblVerifyDt.Text = "";
        lblVerifyTime.Text = "";
        lblZoneName.Text = "";
        lblRejectDetails.Text = "";
        lblRejectDetails.Visible = false;
        ImgPhoto.ImageUrl = "~/Images/Logo/default_logo.gif";

        AuthContecOfficer.Visible = false;
        RollbackRej.Visible = false;
     
        
    }

     public void CallBackStatus()
     {
         Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
         objGeneral = new BaseLayer.General_function();

         try
         {

             
             DataTable dtcall = new DataTable();
             string QStr_Zone = "Select Upper(b.title + ' ' +  forename  + ' ' +  middle_name  + ' ' + surname) as Name, Upper(cerpac_no) as Cerpac_no, Convert(varchar(10),cerpac_expiry_date,103) as cerpac_expiry_date, Upper(card_no) as card_no, Upper(CallbackReason) as callbackReason, Upper(flag) as flag from CallBack_Request a, TitleMaster b  " +
           "where a.title=b.TitleCode  order by IsCallback, year( Request_CreatedOn ), Month(Request_CreatedOn), day(Request_CreatedOn)  desc ";

             dtcall = objGeneral.FetchData(QStr_Zone);


             if (dtcall.Rows.Count > 0)
             {
                 gvMaster.DataSource = dtcall;
                 gvMaster.DataBind();
                 LabelMessage.Visible = false;
             }
             else
             {
                 LabelMessage.Visible = true;
                 LabelMessage.ForeColor = System.Drawing.Color.Red;
                 LabelMessage.Text = "The callback records does not exist !!";
             }
          

         }
         catch (Exception ex)
         {
             objGeneral = new BaseLayer.General_function();
             string err = objGeneral.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
             LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
             LabelMessage.CssClass = "warning-box";
             LabelMessage.Visible = true;
         }
         finally
         {

             objGeneral = null;
         }
     }

    protected void RejectFun()
    {
        Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
        objGeneral = new BaseLayer.General_function();
        string Message = string.Empty;
        LabelMessage.Visible = false;
          
        try
        {
                   

            if (txtSerach.Text != "")
            {

                BaseLayer.General_function ObjGeneral = new BaseLayer.General_function();
                DataTable dt = new DataTable();
                string Query = "SELECT top 1  isnull(IsRejected,0) as IsRejected , Reject , RejectedDate , RejectedTime , RejectionReason FROM CerpacFormNoTracking Where FORMNO='" + txtSerach.Text + "'";
                dt = ObjGeneral.FetchData(Query);
                if (dt.Rows.Count == 0)
                {
                    Response.Write("<script>alert('Applicant information does not found ');</script>");

                }
                else if (dt.Rows.Count > 0)
                {
                    //-----------Display Image----------------
                    BaseLayer.General_function ObjGenBal = new BaseLayer.General_function();

                    DataTable dtimg = new DataTable();
                    string qryimg = "select top 1 * from people where cerpac_no= (select cerpacno from peoplechild where formno='" + txtSerach.Text + "')";
                    dtimg = ObjGeneral.FetchData(qryimg);
                                        
                    byte[] picData = dtimg.Rows[0]["userimage"] as byte[] ?? null;
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

                            if (!File.Exists(Server.MapPath("~") + "/Images/Logo/" + dtimg.Rows[0]["picture"].ToString().Trim()))
                                newImage.Save(Server.MapPath("~") + "/Images/Logo/" + dtimg.Rows[0]["picture"].ToString().Trim());
                            // newImage.Save("g:/Saurabh" + Dt.Rows[0]["picture"].ToString().Trim());

                        }
                    }


                    ViewState["imagepath"] = dtimg.Rows[0]["picture"].ToString().Trim();
                    if (ViewState["imagepath"] != null || ViewState["imagepath"] != "")
                    {
                        if (File.Exists(Server.MapPath("~") + "/Images/Logo/" + dtimg.Rows[0]["picture"].ToString().Trim()))
                            ImgPhoto.ImageUrl = "~/Images/Logo/" + dtimg.Rows[0]["picture"].ToString().Trim();

                        else
                            ImgPhoto.ImageUrl = "~/Images/Logo/default_logo.gif";
                    }

                    else
                    {
                        ImgPhoto.ImageUrl = "~/Images/Logo/default_logo.gif";

                    }

                    if ("1" == dt.Rows[0].ItemArray[0].ToString().Trim())//IsQual(28)
                    {
                        lblRejectDetails.Visible = true;
                        lblRejectDetails.ForeColor = System.Drawing.Color.Red;
                        lblRejectDetails.Text = "Rejection:'" + dt.Rows[0].ItemArray[4].ToString().Trim() + "'";
                    }
                    else if ("0" == dt.Rows[0].ItemArray[0].ToString().Trim() || "" == dt.Rows[0].ItemArray[0].ToString().Trim())
                    {
                        lblRejectDetails.ForeColor = System.Drawing.Color.Red;
                        lblRejectDetails.Text = "";
                        return;
                    }
                   
                }
            }

        }
        catch (Exception ex)
        {
            objGeneral = new BaseLayer.General_function();
            //Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            string err = objGeneral.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.CssClass = "warning-box";
            LabelMessage.Visible = true;
        }
    }
  
    protected void btnSerach_Click(object sender, EventArgs e)
        {
              //----------------------Flag and Auditing-----------------------
        Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
        objGeneral = new BaseLayer.General_function();
        string Message = string.Empty;
        try
        {
            if (txtSerach.Text != "" )
            {
                 BaseLayer.General_function ObjGeneral = new BaseLayer.General_function();
                 DataTable dt1 = new DataTable();
                 dt1 = null;
                 string Query = "SELECT top 1 cerpac_file_no From People Where cerpac_no='" + txtSerach.Text + "' And cerpac_file_no is Not Null";

                    dt1 = ObjGeneral.FetchData(Query);   
                    if (dt1.Rows.Count == 0)
                        {
                            FindFun();
                            //Response.Write("<script>alert('Application information does not found ');</script>");
                            
                        }
                    else if (dt1.Rows.Count > 0)
                    {
                      txtSerach.Text= dt1.Rows[0][0].ToString().Trim();
                       FindFun();
                    }
                    //ClearlabalFun();
                    DivOpt.Visible = false;                    
                    DivCheckSheet.Visible = true;
                    DivAuthMsg.Visible = false;
                    DivCreateRequest.Visible = false;
             }
        }
        catch (Exception ex)
        {
            objGeneral = new BaseLayer.General_function();
            //Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            string err = objGeneral.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.CssClass = "warning-box";
            LabelMessage.Visible = true;
        }
        finally
        {
            ObjBalDocdetails = null;

        }

    }

    public void FindFun()
    {
            Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            objGeneral = new BaseLayer.General_function();
            string Message = string.Empty;
            LabelMessage.Visible = false;
                  
            try
            {
           
                if (txtSerach.Text != "")
                {
                    ClearlabalFun();
                 
                    BaseLayer.General_function ObjGeneral = new BaseLayer.General_function();
                    DataTable dt = new DataTable();
                    dt = null;
                    //string Query = "SELECT top 1 a.FORMNO,a.CerpacNo,a.Title,a.forename, a.middle_name, a.surname, a.sex, b.company, a.designation, a.CerpacExpiry, a.DOB, a.passport_no, a.ZoneName, a.IsVerified, 	 a.Verify, a.VerifiedDate, a.VerifiedTime, a.IsAuthorized, 	 a.Auth,	a.AuthDate,	a.AuthTime,	a.IsProduced, 	a.Prod,	a.ProdDate,	a.ProdTime, a.IsQual	, a.Qual, 	 a.QualDate,	 a.QualTime,  a.IsRejected,  a.Reject, a.RejectedDate,  a.RejectedTime,	a.Rejection_Description,	a.RejectionReason, a.ISARCR, a.IsARCRUser, a.IsArCrDate, a.IsArCrTime From CerpacFormNoTracking a, CompMaster b Where a.FORMNO='" + txtSerach.Text + "' And a.company=b.regno And a.FormNo is Not Null";
                    string Query = "SELECT top 1 a.FORMNO,a.CerpacNo,a.Title,a.forename, a.middle_name, a.surname, a.sex, isnull(b.company,'')as Company, a.designation, a.CerpacExpiry, a.DOB, a.passport_no, a.ZoneName, a.IsVerified, 	 a.Verify, a.VerifiedDate, a.VerifiedTime, a.IsAuthorized, 	 a.Auth,	a.AuthDate,	a.AuthTime,	a.IsProduced, 	a.Prod,	a.ProdDate,	a.ProdTime, a.IsQual	, a.Qual, 	 a.QualDate,	 a.QualTime,  a.IsRejected,  a.Reject, a.RejectedDate,  a.RejectedTime,	a.Rejection_Description,	a.RejectionReason, a.ISARCR, a.IsARCRUser, a.IsArCrDate, a.IsArCrTime FROM (CerpacFormNoTracking a left join compMaster b ON a.company=b.regno) where a.FORMNO='" + txtSerach.Text + "'And a.FormNo is Not Null"; 
               
                    dt = ObjGeneral.FetchData(Query);   
                    if (dt.Rows.Count == 0)
                        {
                            Response.Write("<script>alert('Applicant information does not found ');</script>");
                   
                        }
                        else if (dt.Rows.Count > 0)
                        {
                            RejectFun();

                    //-----------Personal Details-------------

                    lblFRMNo.Text = dt.Rows[0][0].ToString().Trim();
                    lblCerpacNo.Text = dt.Rows[0][1].ToString().Trim();
                    lblCerpacExpDt.Text = dt.Rows[0][9].ToString().Trim();
                    lblTitle.Text = dt.Rows[0][2].ToString().Trim();
                    lblForeName.Text = dt.Rows[0][3].ToString().Trim();
                    lblMiddleName.Text = dt.Rows[0][4].ToString().Trim();
                    lblSurName.Text = dt.Rows[0][5].ToString().Trim();
                    if ("M" == dt.Rows[0][6].ToString().Trim())
                        lblSex.Text = "Male";
                    else
                        lblSex.Text = "Female";
                    lblCompanyName.Text = dt.Rows[0][7].ToString().Trim();
                    lblDesignation.Text = dt.Rows[0][8].ToString().Trim();
                    lblPassportNo.Text = dt.Rows[0][11].ToString().Trim();

                    //29.dbo.Zonemaster.ZoneName, 
                    lblZoneName.Text = dt.Rows[0][12].ToString().Trim();
                    if (txtSerach.Text.Substring(0, 2) == "AR" || txtSerach.Text.Substring(0, 2) == "AO" || txtSerach.Text.Substring(0, 2) == "AB" || txtSerach.Text.Substring(0, 2) == "CR")
                    {
                        AuthContecOfficer.Visible = true;
                        lblSr1.Text = "1";
                        lblSr2.Text = "2";
                        lblSr3.Text = "3";
                        lblSr4.Text = "4";
                        lblSr5.Text = "5";


                    }
                    else
                    {
                        AuthContecOfficer.Visible = false;
                        lblSr1.Text = "1";
                        lblSr2.Text = "2";
                        lblSr3.Text = "3";
                        lblSr4.Text = "3";
                        lblSr5.Text = "4";
                    }
                    

                    //-------------- Verification ------------------

                    if ("1" == dt.Rows[0].ItemArray[13].ToString().Trim()) //IsVerified(13) ,
                    {
                        lblStatusV.ForeColor = System.Drawing.Color.Green;
                        lblStatusV.Text = "Completed";
                        lblVerify.Text = dt.Rows[0][14].ToString().Trim();
                        lblVerifyDt.Text = dt.Rows[0][15].ToString().Trim();
                        lblVerifyTime.Text = dt.Rows[0][16].ToString().Trim();
                    }

                    else if ("0" == dt.Rows[0].ItemArray[13].ToString().Trim() && "1" == dt.Rows[0].ItemArray[29].ToString().Trim()) //IsAuthorized(24), IsRejected(28) 
                    {
                        lblStatusV.ForeColor = System.Drawing.Color.Red;
                        lblStatusV.Text = "Rejected";
                        lblVerify.Text = dt.Rows[0].ItemArray[30].ToString().Trim();
                        lblVerifyDt.Text = dt.Rows[0].ItemArray[31].ToString().Trim();
                        lblVerifyTime.Text = dt.Rows[0].ItemArray[32].ToString().Trim();
                       
                        return;
                    }
                    else if ("0" == dt.Rows[0].ItemArray[13].ToString().Trim() && "0" == dt.Rows[0].ItemArray[13].ToString().Trim())
                    {
                        lblStatusV.ForeColor = System.Drawing.Color.Red;
                        lblStatusV.Text = "Waiting";
                        return;
                    }

                    //------------Authorization-------------
                   //IsAuthorized, 	 Auth,	AuthDate,	AuthTime,	
                   if ("1" == dt.Rows[0].ItemArray[17].ToString().Trim()) //IsAuthorized(17)
                    {
                        lblStatusA.ForeColor = System.Drawing.Color.Green;
                        lblStatusA.Text = "Completed";
                        lblAuthBy.Text = dt.Rows[0][18].ToString().Trim();
                        lblAuthDt.Text = dt.Rows[0][19].ToString().Trim();
                        lblAuthTime.Text = dt.Rows[0][20].ToString().Trim();
                    }
                    else if ("0" == dt.Rows[0].ItemArray[17].ToString().Trim() && "1" == dt.Rows[0].ItemArray[29].ToString().Trim()) //IsAuthorized(25), IsRejected(28) 
                    {
                        lblStatusA.ForeColor = System.Drawing.Color.Red;
                        lblStatusA.Text = "Rejected";
                        lblAuthBy.Text = dt.Rows[0].ItemArray[30].ToString().Trim();
                        lblAuthDt.Text = dt.Rows[0].ItemArray[31].ToString().Trim();
                        lblAuthTime.Text = dt.Rows[0].ItemArray[32].ToString().Trim();
                       
                        return;
                    }
                     else if ("0" == dt.Rows[0].ItemArray[17].ToString().Trim() || "" == dt.Rows[0].ItemArray[17].ToString().Trim())
                    {
                        lblStatusA.ForeColor = System.Drawing.Color.Red;
                        lblStatusA.Text = "Waiting";
                        return;
                    }
                     //----------------ISARCR flag---------------------------
                     if ("1" == dt.Rows[0].ItemArray[35].ToString().Trim()  && "AR" == dt.Rows[0].ItemArray[0].ToString().Trim().Substring(0, 2) || "1" == dt.Rows[0].ItemArray[35].ToString().Trim() && "AO" == dt.Rows[0].ItemArray[0].ToString().Trim().Substring(0, 2) || "1" == dt.Rows[0].ItemArray[35].ToString().Trim() && "AB" == dt.Rows[0].ItemArray[0].ToString().Trim().Substring(0, 2) || "1" == dt.Rows[0].ItemArray[35].ToString().Trim() && "CR" == dt.Rows[0].ItemArray[0].ToString().Trim().Substring(0, 2))  
                     {
                         AuthContecOfficer.Visible = true;
                         lblStatusAC.ForeColor = System.Drawing.Color.Green;
                         lblStatusAC.Text = "Completed";
                         lblContecBy.Text = dt.Rows[0][36].ToString().Trim();
                         lblContecDt.Text = dt.Rows[0][37].ToString().Trim();
                         lblContecT.Text = dt.Rows[0][38].ToString().Trim();

                     }
                     else if ("0" == dt.Rows[0].ItemArray[35].ToString().Trim() || "" == dt.Rows[0].ItemArray[35].ToString().Trim())
                     {
                         lblStatusAC.ForeColor = System.Drawing.Color.Red;
                         lblStatusAC.Text = "Waiting";
                         return;
                     }

                    //------------------------IsProduct =1 ----------------------------------------
                    //IsProduced, 	Prod,	ProdDate,	ProdTime, 
                            
                    if ("1" == dt.Rows[0].ItemArray[21].ToString().Trim()) //IsProduced(26) 
                    {
                        lblStatusP.ForeColor = System.Drawing.Color.Green;
                        lblStatusP.Text = "Completed";
                        lblProdBy.Text = dt.Rows[0][22].ToString().Trim();
                        lblProdOn.Text = dt.Rows[0][23].ToString().Trim();
                        lblProdTime.Text = dt.Rows[0][24].ToString().Trim();

                    } 
                     //------------------------IsProduct =2 ----------------------------------------
                    else if ("2" == dt.Rows[0].ItemArray[21].ToString().Trim()) //IsProduced(26) 
                    {
                        lblStatusP.ForeColor = System.Drawing.Color.Red;
                        lblStatusP.Text = "Waiting";
                     
                        return;

                    }
                    //------------------------IsProduct =3 ----------------------------------------
                    else if ("3" == dt.Rows[0].ItemArray[21].ToString().Trim()) //IsProduced(26) 
                    {
                        lblStatusP.ForeColor = System.Drawing.Color.Red;
                        lblStatusP.Text = "waiting";

                        return;
                    }

                    else if ("0" == dt.Rows[0].ItemArray[21].ToString().Trim() && "1" == dt.Rows[0].ItemArray[29].ToString().Trim()) //IsProduced(21) , IsRejected(29) 
                    {
                        lblStatusP.ForeColor = System.Drawing.Color.Red;
                        lblStatusP.Text = "Rejected";
                        lblProdBy.Text = dt.Rows[0].ItemArray[30].ToString().Trim();
                        lblProdOn.Text = dt.Rows[0].ItemArray[31].ToString().Trim();
                        lblProdTime.Text = dt.Rows[0].ItemArray[32].ToString().Trim();
                        
                        
                        return;
                    }
                    else if ("0" == dt.Rows[0].ItemArray[21].ToString().Trim() || "" == dt.Rows[0].ItemArray[21].ToString().Trim()) //IsProduced(26) , IsRejected(28) 
                    {
                        lblStatusP.ForeColor = System.Drawing.Color.Red;
                        lblStatusP.Text = "Waiting";
                        return;
                    }
                    //---------------Quality--------------------------
                    //IsQual,	 Qual, 	 QualDate,	 QualTime, 
                            
                    if ("1" == dt.Rows[0].ItemArray[25].ToString().Trim())//IsQual(27)
                    {
                        //btnRollhlDataEntry.Visible = true;
                        RollbackRej.Visible = true;
                        lblStatusQ.ForeColor = System.Drawing.Color.Green;
                        lblStatusQ.Text = "Completed";
                        lblQualityBy.Text = dt.Rows[0].ItemArray[26].ToString().Trim();
                        lblQualityOn.Text = dt.Rows[0].ItemArray[27].ToString().Trim();
                        lblQualTime.Text = dt.Rows[0].ItemArray[28].ToString().Trim();
                        
                    }
                    else if ("0" == dt.Rows[0].ItemArray[25].ToString().Trim() && "1" == dt.Rows[0].ItemArray[29].ToString().Trim()) //IsProduced(25) , IsRejected(29) 
                    {
                        lblStatusQ.ForeColor = System.Drawing.Color.Red;
                        lblStatusQ.Text = "Rejected";
                        lblQualityBy.Text = dt.Rows[0].ItemArray[30].ToString().Trim();
                        lblQualityOn.Text = dt.Rows[0].ItemArray[31].ToString().Trim();
                        lblQualTime.Text = dt.Rows[0].ItemArray[32].ToString().Trim();
                        
                        return;
                    }

                    else if ("0" == dt.Rows[0].ItemArray[25].ToString().Trim() || "" == dt.Rows[0].ItemArray[25].ToString().Trim())
                    {
                        lblStatusQ.ForeColor = System.Drawing.Color.Red;
                        lblStatusQ.Text = "Waiting";
                        return;
                    }
                    //-----------Regected--------------------------
                    // IsRejected,  Reject, RejectedDate,  RejectedTime,	Rejection_Description,	RejectionReason,
                     
                    if ("1" == dt.Rows[0].ItemArray[29].ToString().Trim())//IsQual(28)
                    {
                        lblRejectDetails.ForeColor = System.Drawing.Color.Red;
                        lblRejectDetails.Text = "Regected Application :'"+ dt.Rows[0].ItemArray[34].ToString().Trim()+"'";
                    }
                    else if ("0" == dt.Rows[0].ItemArray[29].ToString().Trim() || "" == dt.Rows[0].ItemArray[29].ToString().Trim())
                    {
                        lblRejectDetails.ForeColor = System.Drawing.Color.Red;
                        lblRejectDetails.Text = "";
                        return;
                    }

                   }
                }

            }
            catch (Exception ex)
            {
                objGeneral = new BaseLayer.General_function();
                //Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
                string err = objGeneral.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
                LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
                LabelMessage.CssClass = "warning-box";
                LabelMessage.Visible = true;
            }
            finally
            {
                ObjBalDocdetails = null;

            }           
            
        }    
   
   
    public int AdminRejFlag()
    {
        SqlParameter[] pram = new SqlParameter[9];
        try
        {
            pram[0] = new SqlParameter("@CerpacNo", lblCerpacNo.Text.ToString().Trim());
            pram[1] = new SqlParameter("@FormNo", txtSerach.Text.ToString().Trim());
            pram[2] = new SqlParameter("@Authority", ddlAuthority.SelectedItem.Text.ToString().Trim());
            pram[3] = new SqlParameter("@Purpose", ddlPurpose.SelectedItem.Text.ToString().Trim());
            pram[4] = new SqlParameter("@Remark", "");
            pram[5] = new SqlParameter("@Flag", "");
            pram[6] = new SqlParameter("@UpdatedBy", UserID);
            pram[7] = new SqlParameter("@Opt", 2);
            pram[8] = new SqlParameter("@Rt", 1);
            pram[8].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[UspTrackProdFlag]", pram);
            return int.Parse(pram[8].Value.ToString());

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            pram = null;
        }
    }
   
   
    protected void btnRollBackProd_Click(object sender, EventArgs e)
    {
        //----------------------Flag and Auditing-----------------------
        Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
        objGeneral = new BaseLayer.General_function();
        string Message = string.Empty;
        try
        {
            if (txtSerach.Text != "" && lblCerpacExpDt.Text != "")
            {
                DivOpt.Visible = false;
                DivCheckSheet.Visible = false;
                DivAuthMsg.Visible = true;
                DivCreateRequest.Visible = false;
            }
        }
        catch (Exception ex)
        {
            objGeneral = new BaseLayer.General_function();
            //Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            string err = objGeneral.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.CssClass = "warning-box";
            LabelMessage.Visible = true;
        }
        finally
        {
            ObjBalDocdetails = null;

        }

        //------------------ end--------------------
    }

    protected void btnRequestCallBack_Click(object sender, EventArgs e)
    {
        //----------------------Flag and Auditing-----------------------
        Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
        objGeneral = new BaseLayer.General_function();
        string Message = string.Empty;
        try
        {
            if (txtSerach.Text != "" && lblCerpacExpDt.Text != "")
            {
                DivOpt.Visible = false;
                DivCheckSheet.Visible = false;
                DivAuthMsg.Visible = false;
                DivCreateRequest.Visible = true;
            }
        }
        catch (Exception ex)
        {
            objGeneral = new BaseLayer.General_function();
            //Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
            string err = objGeneral.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.CssClass = "warning-box";
            LabelMessage.Visible = true;
        }
        finally
        {
            ObjBalDocdetails = null;

        }

        //------------------ end--------------------

        
    }

    public int ReuestCallBack()
    {
        SqlParameter[] pram = new SqlParameter[9];
        try
        {
            pram[0] = new SqlParameter("@CerpacNo", lblCerpacNo.Text.ToString().Trim());
            pram[1] = new SqlParameter("@FormNo", txtSerach.Text.ToString().Trim());
            pram[2] = new SqlParameter("@Authority", ddlAuthority1.SelectedItem.Text.ToString().Trim());
            pram[3] = new SqlParameter("@Purpose", ddlPurpose1.SelectedItem.Text.ToString().Trim());
            pram[4] = new SqlParameter("@Remark", "Request for Callback");
            pram[5] = new SqlParameter("@Flag", "Pending");
            pram[6] = new SqlParameter("@UpdatedBy", UserID);
            pram[7] = new SqlParameter("@Opt", 3);
            pram[8] = new SqlParameter("@Rt", 1);
            pram[8].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[UspTrackProdFlag]", pram);
            return int.Parse(pram[8].Value.ToString());
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            pram = null;
        }
    }

    
    protected void btnRollBackCard_Click(object sender, EventArgs e)
    {
        //-----------------Admin Rejected After Quality----------
        Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
        objGeneral = new BaseLayer.General_function();
        string Message = string.Empty;
        try
        {
            if (txtSerach.Text != "" && lblCerpacExpDt.Text != "")
            {
                int statusid = AdminRejFlag();
                Message = "Successfully Card Callback after Quality";
                if (statusid == 1)
                {
                    LabelMessage.Visible = true;
                    LabelMessage.Text = Message;
                    LabelMessage.CssClass = "confirmation-box";
                    div_main.Visible = false;
                }
                else
                {
                    Message = " Try Again !!";
                    LabelMessage.CssClass = "errormsg";
                    LabelMessage.Text = Message;//"Record Can not be saved";
                    LabelMessage.Visible = true;
                    txtSerach.Focus();

                }
            }
        }
        catch (Exception ex)
        {
            objGeneral = new BaseLayer.General_function();
            string err = objGeneral.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.CssClass = "warning-box";
            LabelMessage.Visible = true;
        }
        finally
        {
            ObjBalDocdetails = null;

        }
        //----------------------- end ---------------------------

    }
    protected void btnProceedCallBackRequest_Click(object sender, EventArgs e)
    {
        //-----------------Admin Rejected After Quality----------
        Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
        objGeneral = new BaseLayer.General_function();
        string Message = string.Empty;
        try
        {
            if (txtSerach.Text != "" && lblCerpacExpDt.Text != "")
            {
                int statusid = ReuestCallBack();
                if (statusid == 1)
                {

                    LabelMessage.Visible = true;
                    LabelMessage.Text = "The Card Callback Reuest Successfully Generate !!"; ;
                    LabelMessage.CssClass = "confirmation-box";
                    div_main.Visible = false;
                }
                else
                {
                    Message = " Try Again !!";
                    LabelMessage.CssClass = "errormsg";
                    LabelMessage.Text = Message;//"Record Can not be saved";
                    LabelMessage.Visible = true;
                    txtSerach.Focus();

                }
            }
        }
        catch (Exception ex)
        {
            objGeneral = new BaseLayer.General_function();
            string err = objGeneral.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.CssClass = "warning-box";
            LabelMessage.Visible = true;
        }
        finally
        {
            ObjBalDocdetails = null;

        }
        //----------------------- end ---------------------------

    }
    protected void gvMaster_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Label LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
        objGeneral = new BaseLayer.General_function();

        try
        {
            

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string CerpacNo = gvMaster.DataKeys[e.Row.RowIndex].Value.ToString();
               
                GridView gvZoneDetail = e.Row.FindControl("gvZoneDetail") as GridView;
                DetailsView gvDetails = e.Row.FindControl("gvDetails") as DetailsView;

                DataTable dtGet = new DataTable();


                string QStr_Zone = "SELECT CallBack_id,ZoneName,c.Title,forename,middle_name,surname,cerpac_no,cerpac_file_no,Convert(varchar(10),cerpac_receipt_date,103) as cerpac_receipt_date, Convert(varchar(10),cerpac_expiry_date,103) as cerpac_expiry_date, card_no, front_lam_No  " +
               " ,back_lam_No,b.UserName as Request_CreatedBy, Convert(varchar(10),Request_CreatedOn,103) as Request_CreatedOn, CallbackApproveBy, CallbackReason,Remark, Convert(varchar(10),CallbackOn,103) as CallbackOn, flag  " +
               " FROM CallBack_Request a, UserMaster b , TitleMaster c where a.Request_CreatedBy=b.UserID and  a.title=c.TitleCode and cerpac_no='" + CerpacNo.ToString().Trim() + "'";

                dtGet = objGeneral.FetchData(QStr_Zone);



                if (dtGet.Rows.Count > 0)
                {


                    gvDetails.DataSource = dtGet;
                    gvDetails.DataBind();
                    LabelMessage.Visible = false;

                }
                else
                {
                    LabelMessage.Visible = true;
                    LabelMessage.ForeColor = System.Drawing.Color.Red;
                    LabelMessage.Text = "The callback records does not exist !!";

                }
            }
         
        }
        catch (Exception ex)
        {
            objGeneral = new BaseLayer.General_function();
            string err = objGeneral.errorhandling(ex.ToString(), int.Parse(objectSessionHolderPersistingData.User_ID));
            LabelMessage.Text = "Error occured.Please contact system administrator. Ref No: " + err.ToString();
            LabelMessage.CssClass = "warning-box";
            LabelMessage.Visible = true;
        }
        finally
        {

            objGeneral = null;
        }
    }
}
