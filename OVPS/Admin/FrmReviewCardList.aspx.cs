using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

public partial class Admin_FrmReviewCardList : System.Web.UI.Page
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

        From.HRef = "javascript:NewCal('" + txtFromDate.ClientID + "','DDMMMYYYY','','',5,1)";
        To.HRef = "javascript:NewCal('" + txtToDate.ClientID + "','DDMMMYYYY','','',5,1)";

        UserID = objectSessionHolderPersistingData.User_ID.ToString();
        LabelMessage = (Label)this.Page.Master.FindControl("lblmsg");
        if (!IsPostBack)
        {
           // bindgrid();
            //detailtable.Style.Add("dislay", "none");
           // GridViewreview.Visible = true;
        }
              
    }

    private void GetData(string ApplicationId)
    {
        DataTable Dt = null;
        Dt = new DataTable();
        ObjGenBal = new BaseLayer.General_function();
        string queryforcerpac = "select a.*,b.* from People as a , PeopleChild as b where a.cerpac_no = b.CerpacNo and a.cerpac_file_no=b.FORMNO and b.IsProduced=1 and a.cerpac_no='" + ApplicationId.ToString() + "'";
        Dt = ObjGenBal.FetchData(queryforcerpac);
        
        try
        {
            if (Dt.Rows.Count > 0)
            {
                string duplicacyquery = "Select * from tbl_card_review where cerpac_no='" + ApplicationId.ToString().Trim() + "' and cerpac_file_no='" + Dt.Rows[0]["cerpac_file_no"].ToString().Trim() +"'";
                DataTable dtdup = null;
                dtdup = new DataTable();
                dtdup = ObjGenBal.FetchData(duplicacyquery);
                if (dtdup.Rows.Count > 0)
                {
                    ClientScriptManager CSM = Page.ClientScript;

                        string strconfirm = "<script>if(!window.confirm('This Application was already reviewed. Are you sure you want to review it again')){window.location.href='FrmReviewCardList.aspx'}</script>";
                        CSM.RegisterClientScriptBlock(this.GetType(), "Confirm", strconfirm, false);
           
                }
                    detailtable.Style.Add("display", "");
                    tbl1.Style.Add("display", "");
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
                    txtdbname.Text = Dt.Rows[0]["forename"].ToString().Trim() + " " + Dt.Rows[0]["middle_name"].ToString().Trim() + " " + Dt.Rows[0]["surname"].ToString().Trim();
                    txtfrnno.Text = Dt.Rows[0]["cerpac_file_no"].ToString().Trim();
                    TxtCerpacNo.Text = Dt.Rows[0]["cerpac_no"].ToString().Trim();
                    lblexp.Text = string.Format("{0:d-MM-yyyy}", Dt.Rows[0]["cerpac_expiry_date"]).ToString().Trim();
                    lbldor.Text = string.Format("{0:d-MM-yyyy}", Dt.Rows[0]["cerpac_receipt_date"]).ToString().Trim();
                    lblnationality.Text = Dt.Rows[0]["Nationality"].ToString().Trim();
                    //--------------------------------------fetching company name from comp master-------------------------------
                    DataTable dtcomp = null;
                    dtcomp = new DataTable();
                    string queryforcomp = "";
                    queryforcomp = "Select regno,company from compmaster where regno = '" + Dt.Rows[0]["company"].ToString().Trim() + "'";

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

                    //--------------------------------------------- data from bank-------------------------------------------
                    string queryforbankdetails = "Select * from Uploaded_excel_data where FORMNO='" + txtfrnno.Text.ToString().Trim() + "'";
                    DataTable dtbnk = null;
                    dtbnk = new DataTable();
                    dtbnk = ObjGenBal.FetchData(queryforbankdetails);
   		    txtbankname.Text = "";
                    txtcompanybank.Text = "";
                
                    if (dtbnk.Rows.Count > 0)
                    {
                        txtbankname.Text = dtbnk.Rows[0]["FirstName"].ToString() + " " + dtbnk.Rows[0]["LastName"].ToString();
                        txtcompanybank.Text = dtbnk.Rows[0]["COMPANY"].ToString();
                        // lblprchase.Text = string.Format("{0:d-MM-yyyy}", dtbnk.Rows[0]["Date1"]).ToString().Trim();
                    }
                    //--------------------------------------------------end--------------------------------------------------
                    //------------------------------------------------fetching physical card number ---------------------------------
                    //string cardnoquery = "Select * from CerpacNo_Out_One where cerpac_no='" + ApplicationId.ToString().Trim() + "' and cerpac_file_no='" + txtfrnno.Text.ToString().Trim() + "' and StickerPrintedYN=1 and (StickerWastedYN is Null or StickerWastedYN='' or StickerWastedYN=0)";
                    //DataTable dtcard = null;
                    //dtcard = new DataTable();
                    //dtcard = ObjGenBal.FetchData(cardnoquery);
                    //if (dtcard.Rows.Count > 0)
                    //{
                    //    lblphycard.Text = dtcard.Rows[0]["CardNo"].ToString();
                    //}
                    //-----------------------------------------------------end-------------------------------------------------------
                    //---------------------------------------------------------code to fetch the number of forms --------------------------------------------
                    string numquery = "select count(*) as count,ProducedOn from peoplechild where IsProduced=1 and cerpacno='" + ApplicationId.ToString() + "' group by ProducedOn order by ProducedOn desc";
                    DataTable dtnum = null;
                    dtnum = new DataTable();
                    dtnum = ObjGenBal.FetchData(numquery);
                    if (dtnum.Rows.Count > 0)
                    {
                            lblnum.Text = dtnum.Rows[0]["count"].ToString();
                            string producedon = string.Format("{0:yyyy-MM-dd}", dtnum.Rows[0]["ProducedOn"]).ToString().Trim();
                            string frnquery = "Select FORMNO from peoplechild where isproduced=1 and cerpacno='" + ApplicationId.ToString() + "' and producedon between '" + producedon + " 00:00:00" + "' and '" + producedon + " 23:59:59" + "'";
                            DataTable dtfrnquery = null;
                            dtfrnquery = new DataTable();
                            dtfrnquery = ObjGenBal.FetchData(frnquery);
                            if (dtfrnquery.Rows.Count > 0)
                            {
                                if (dtfrnquery.Rows.Count == 1)
                                {
                                    txtfrnnoorig.Text = dtfrnquery.Rows[0]["FORMNO"].ToString();
                                    string querydt = "Select convert(varchar(14),DATE1,105) as DATE1 from Uploaded_excel_Data where formno='" + txtfrnnoorig.Text.ToString() + "'";
                                    DataTable dtprchs = null;
                                    dtprchs = new DataTable();
                                    dtprchs = ObjGenBal.FetchData(querydt);
                                    if (dtprchs.Rows.Count > 0)
                                    {
                                        lbldt.Text = dtprchs.Rows[0]["DATE1"].ToString();
                                    }
                                }
                                else
                                {
                                    string frnfinal = "";
                                    string prchsdt = "";
                                    for (int i = 0; i < dtfrnquery.Rows.Count; i++)
                                    {
                                        frnfinal = dtfrnquery.Rows[i]["FORMNO"].ToString() + "," + frnfinal.ToString();
                                    }
                                    
                                    txtfrnnoorig.Text = frnfinal.Substring(0, frnfinal.Length - 1);
                                    string[] val = new string[3];
                                    val = txtfrnnoorig.Text.Split(',');
                                    for (int j = 0; j < val.Length; j++)
                                    {
                                        string querydt = "Select convert(varchar(14),DATE1,105) as DATE1 from Uploaded_excel_Data where formno='" + val[j].ToString() + "'";
                                        DataTable dtprchs = null;
                                        dtprchs = new DataTable();
                                        dtprchs = ObjGenBal.FetchData(querydt);
                                        if (dtprchs.Rows.Count > 0)
                                        {
                                            prchsdt = prchsdt.ToString() + "," + dtprchs.Rows[0]["DATE1"].ToString();
                                        }
                                    }

                                    lbldt.Text = prchsdt.Remove(0, 1);//prchsdt.Substring(0, prchsdt.Length - 1);
                                }
                            }
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
                  //----------------------------------------------------------fetching user credentials---------------------------------------------------
                string query = "select (select Username from usermaster where UserID=verifiedby) as verifiedBy,(select Username from usermaster where UserID=AuthorizedBy) as AuthorizedBy,";
                query= query+ "(select Username from usermaster where UserID=ConfirmedBy) as ConfirmedBy,(select Username from usermaster where UserID=ProducedBy) as ProducedBy,";
                query=query+"(select Username from usermaster where UserID=QualBy) as QualBy,convert(varchar(14),verifiedOn,105) as verifiedDt,convert(varchar(8),verifiedOn,108) as verifiedTime,";
                query=query+"convert(varchar(14),AuthorizedOn,105) as authDt,convert(varchar(8),AuthorizedOn,108) as authTime,";
                query=query+"convert(varchar(14),ConfirmedOn,105) as confDt,convert(varchar(8),ConfirmedOn,108) as confTime,";
                query=query+"convert(varchar(14),ProducedOn,105) as prodDt,convert(varchar(8),ProducedOn,108) as prodTime,";
                query=query+"convert(varchar(14),QualOn,105) as qualDt,convert(varchar(8),QualOn,108) as QualTime";
                query=query+" from PeopleChild where FORMNO='"+txtfrnno.Text.ToString().ToString()+"'";
                ObjGenBal = new BaseLayer.General_function();
                DataTable dtusrcred = null;
                dtusrcred = new DataTable();
                dtusrcred = ObjGenBal.FetchData(query);
                if (dtusrcred.Rows.Count > 0)
                {
                    lblVerify.Text = dtusrcred.Rows[0]["verifiedBy"].ToString();
                    lblVerifyDt.Text = dtusrcred.Rows[0]["verifiedDt"].ToString();
                    lblVerifyTime.Text = dtusrcred.Rows[0]["verifiedTime"].ToString();

                    lblAuthBy.Text = dtusrcred.Rows[0]["AuthorizedBy"].ToString();
                    lblAuthDt.Text = dtusrcred.Rows[0]["authDt"].ToString();
                    lblAuthTime.Text = dtusrcred.Rows[0]["authTime"].ToString();

                    lblContecBy.Text = dtusrcred.Rows[0]["ConfirmedBy"].ToString();
                    lblContecDt.Text = dtusrcred.Rows[0]["confDt"].ToString();
                    lblContecT.Text = dtusrcred.Rows[0]["confTime"].ToString();

                    lblProdBy.Text = dtusrcred.Rows[0]["ProducedBy"].ToString();
                    lblProdOn.Text = dtusrcred.Rows[0]["prodDt"].ToString();
                    lblProdTime.Text = dtusrcred.Rows[0]["prodTime"].ToString();

                    lblQualityBy.Text = dtusrcred.Rows[0]["QualBy"].ToString();
                    lblQualityOn.Text = dtusrcred.Rows[0]["qualDt"].ToString();
                    lblQualTime.Text = dtusrcred.Rows[0]["QualTime"].ToString();
                }
                //-----------------------------------------------------------------end--------------------------------------------------------------------
                    GridViewreview.Style.Add("display", "none");
                
            }
            else
            {
                detailtable.Style.Add("display", "none");
                tbl1.Style.Add("display", "none");
                Response.Write("<script>alert('Either the card is not produced or the Form is not processed.')</script>");
                return;
                // warn.Style.Add("display", "");
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
    public static string ConvertDate(string date, string pattern)
    {

        if (string.IsNullOrEmpty(date) == false && date != "")
        {
            DateTime date2;
            if (DateTime.TryParseExact(date, pattern, CultureInfo.InvariantCulture, DateTimeStyles.None, out date2))
            {
                return date2.ToString("MM/d/yyyy");
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
    
    protected void btnverify_Click(object sender, EventArgs e)
    {
        try
        {
            int status = confirmeligibility("Ok");
            if (status == 1)
            {
                confirm.Style.Add("display", "");
                confirm.Attributes.Add("class", "confirmation-box animated-table bounceIn");
                detailtable.Style.Add("display", "none");
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
    public int confirmeligibility(string action)
    {
        SqlParameter[] pram = null;

        pram = new SqlParameter[6];
        pram[0] = new SqlParameter("@UserId", objectSessionHolderPersistingData.User_ID);
        pram[1] = new SqlParameter("@cerpacno", TxtCerpacNo.Text.ToString());
        pram[2] = new SqlParameter("@cerpac_file_no", txtfrnno.Text.ToString());
        pram[3] = new SqlParameter("@notes", txtnotes.Text.ToString());
        pram[4] = new SqlParameter("@Action", action.ToString());
        pram[5] = new SqlParameter("@SuccessId", 1);
        pram[5].Direction = ParameterDirection.Output;
        SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "USP_CERPAC_CARD_REVIEW", pram);
        return int.Parse(pram[5].Value.ToString());
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            int status = confirmeligibility("Not Ok");
            if (status == 1)
            {
                confirm.Style.Add("display", "");
                confirm.Attributes.Add("class", "confirmation-box animated-table bounceIn");
                detailtable.Style.Add("display", "none");
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
    protected void GridViewreview_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewreview.PageIndex = e.NewPageIndex;
        bindgrid();
    }

    private void bindgrid()
    {
        string frmdt = ConvertDate(txtFromDate.Value, "d-MM-yyyy");
        string todt = ConvertDate(txtToDate.Value, "d-MM-yyyy");
        string query = "select (a.forename +' '+a.surname) as name,cerpac_no,Convert(varchar(10),ProducedOn,105) as ProducedOn from people as a, PeopleChild as b, CompMaster as c where a.company=c.regno and a.cerpac_no=b.CerpacNo and a.cerpac_file_no=b.FORMNO and IsProduced=1";
        query = query + " and cerpac_no not in (Select cerpac_no from tbl_card_review) and cerpac_file_no not in (Select cerpac_no from tbl_card_review) and ProducedOn between '"+frmdt+"' and '"+todt+" 23:59:59'";
               ObjGenBal = new BaseLayer.General_function();
               DataTable dt = null;
               dt = new DataTable();
               dt = ObjGenBal.FetchData(query);
               if (dt.Rows.Count > 0)
               {
                   GridViewreview.DataSource = dt;
                   GridViewreview.DataBind();
                   GridViewreview.Visible = true;
               }
               else
               {
                   Response.Write("<script>alert('No record found')</script>");
               }
    }
    protected void GridViewreview_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridViewreview.EditIndex = e.NewEditIndex;

        Label lblcerpacno = (Label)GridViewreview.Rows[GridViewreview.EditIndex].FindControl("lblcerpacno");
        string keyvalue = lblcerpacno.Text.ToString();
        GridViewreview.Style.Add("display", "none");
    }
    protected void GridViewreview_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[0].Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Cells[1].Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Cells[2].Attributes["onmouseover"] = "this.style.cursor='pointer';";
           // e.Row.Cells[3].Attributes["onmouseover"] = "this.style.cursor='pointer';";
            
            
            e.Row.ToolTip = "Click to select row";
            e.Row.Cells[0].Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.GridViewreview, "Select$" + e.Row.RowIndex);
            e.Row.Cells[1].Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.GridViewreview, "Select$" + e.Row.RowIndex);
            e.Row.Cells[2].Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.GridViewreview, "Select$" + e.Row.RowIndex);
           // e.Row.Cells[3].Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.GridViewreview, "Select$" + e.Row.RowIndex);
         }
    }
    protected void GridViewreview_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = GridViewreview.SelectedRow;
        Label cerno = row.FindControl("lblcerpacno") as Label;
        GetData(cerno.Text);
    }
    protected void btngenerate_Click(object sender, EventArgs e)
    {
        if (txtFromDate.Value == "" || txtToDate.Value == "")
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Please Fill From- Date & To-Date.');", true);
            // Response.Write("<script language=javascript>alert('Please Fill From- Date & To-Date')</script>");
            return;

        }


        if (txtFromDate.Value != "" && txtToDate.Value != "")
        {
            try
            {
                tbldtrange.Style.Add("display", "none");
                bindgrid();

            }

            catch (Exception ep)
            {
                string exp = ep.ToString();
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Please Try Again.');", true);


            }

        }
    }
    protected void lnkgrd_Click(object sender, EventArgs e)
    {
        bindgrid();
        detailtable.Style.Add("display", "none");
        GridViewreview.Visible = true;
        GridViewreview.Style.Add("display", "");
        confirm.Style.Add("display", "none");
    }
}