using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Dashboard : System.Web.UI.Page
{
    #region "Declarations"
   
    protected BaseLayer.General_function ObjGenBal = null;
 
    #endregion


    protected void Page_Load(object sender, EventArgs e)
    {
        string IPAddress = WebConfigurationManager.AppSettings["IPAddress"];
        float A = 0, V = 0, P = 0, Q = 0, T = 0;
        //----------ZoneName------------------
        DataTable DtZ = new DataTable();
        ObjGenBal = new BaseLayer.General_function();
        string QtrZone = "( Select ZoneName From Zonemaster where ZoneIP='" + IPAddress.ToString().Trim() + "') ";
        DtZ = ObjGenBal.FetchData(QtrZone);
        try
        {
            if (DtZ.Rows.Count > 0)
            {

                lblZoneName.InnerText = DtZ.Rows[0][0].ToString();
              
            }
            else
            {
                lblAuthorization.InnerText = "0";

            }
        }
         catch (Exception ex)
        {
            //MessageBox.Show(ex.Message);
        }


        //------------------Authorization------------------------
      
        DataTable DtA = new DataTable();
        ObjGenBal = new BaseLayer.General_function();
        string QtrAuth = "select count(*) as Count from people a, PeopleChild b, UserZoneRelation c where a.cerpac_no=b.CerpacNo and a.cerpac_file_no=b.FORMNO and b.IsVerified=1 and isnull(b.IsAuthorized,0)<>1 and isnull(b.ISARCR,0)<>1 and (isnull(b.IsProduced,0)<>1) and isnull(b.isQual,0)<>1 and b.verifiedby = c.userid   and c.ZoneCode=(select ZoneCode from Zonemaster where ZoneIP='" + IPAddress.ToString().Trim() + "') ";
        DtA = ObjGenBal.FetchData(QtrAuth);
        try
        {
            if (DtA.Rows.Count > 0)
            {

                lblAuthorization.InnerText = DtA.Rows[0][0].ToString();
                A = Convert.ToInt32(DtA.Rows[0][0].ToString());
                //lblDataEntry.InnerText = DtA.Rows[0][0].ToString();
            }
            else
            {
                lblAuthorization.InnerText = "0";

            }
        
       

            //------------------Convte Verification------------------------
            DataTable DtV = new DataTable();
            ObjGenBal = new BaseLayer.General_function();
            string QtrVerify = "select count(*) as Count from people a, PeopleChild b, UserZoneRelation c where a.cerpac_no=b.CerpacNo and a.cerpac_file_no=b.FORMNO and b.IsVerified=1 and b.IsAuthorized=1 and isnull(b.ISARCR,0)<>1 and (isnull(b.IsProduced,0)<>1) and isnull(b.isQual,0)<>1 and b.verifiedby = c.userid   and c.ZoneCode=(select ZoneCode from Zonemaster where ZoneIP='" + IPAddress.ToString().Trim() + "') ";
            DtV = ObjGenBal.FetchData(QtrVerify);

            if (DtV.Rows.Count > 0)
            {

                lblVerification.InnerText = DtV.Rows[0][0].ToString();
                V = Convert.ToInt32(DtV.Rows[0][0].ToString());
            }
            else
            {
                lblVerification.InnerText = "0";

            }


            //------------------Production------------------------
            DataTable DtP = new DataTable();
            ObjGenBal = new BaseLayer.General_function();
            string QtrProd = "select count(*) as Count from people a, PeopleChild b, UserZoneRelation c where a.cerpac_no=b.CerpacNo and a.cerpac_file_no=b.FORMNO and b.IsVerified=1 and b.IsAuthorized=1 and b.ISARCR=1 and (isnull(b.IsProduced,0)<>1 and isnull(b.IsProduced,0)<>2 and isnull(b.IsProduced,0)<>3) and isnull(b.isQual,0)<>1 and b.verifiedby = c.userid   and c.ZoneCode=(select ZoneCode from Zonemaster where ZoneIP='" + IPAddress.ToString().Trim() + "') ";
            DtP = ObjGenBal.FetchData(QtrProd);

            if (DtP.Rows.Count > 0)
            {

                lblProduction.InnerText = DtP.Rows[0][0].ToString();
                P = Convert.ToInt32(DtP.Rows[0][0].ToString());
            }
            else
            {
                lblProduction.InnerText = "0";

            }

            //------------------Quality------------------------
            DataTable DtQ = new DataTable();
            ObjGenBal = new BaseLayer.General_function();
            string QtrQuality = "select count(*) as Count from people a, PeopleChild b, UserZoneRelation c where a.cerpac_no=b.CerpacNo and a.cerpac_file_no=b.FORMNO and b.IsVerified=1 and b.IsAuthorized=1 and b.ISARCR=1 and b.IsProduced=1 and isnull(b.isQual,0)<>1 and b.verifiedby = c.userid   and c.ZoneCode=(select ZoneCode from Zonemaster where ZoneIP='" + IPAddress.ToString().Trim() + "') ";
            DtQ = ObjGenBal.FetchData(QtrQuality);

            if (DtQ.Rows.Count > 0)
            {

                lblQuality.InnerText = DtQ.Rows[0][0].ToString();
                Q = Convert.ToInt32(DtQ.Rows[0][0].ToString());
            }
            else
            {
                lblQuality.InnerText = "0";

            }

            //------------------Completed------------------------
            DataTable DtC = new DataTable();
            ObjGenBal = new BaseLayer.General_function();
            string QtrCompleted = "select count(*) as Count from people a, PeopleChild b, UserZoneRelation c where a.cerpac_no=b.CerpacNo and a.cerpac_file_no=b.FORMNO and b.IsVerified=1 and b.IsAuthorized=1 and b.ISARCR=1 and b.IsProduced=1 and isnull(b.isQual,0)=1 and b.verifiedby = c.userid  and b.QualOn=GetDate()  and c.ZoneCode=(select ZoneCode from Zonemaster where ZoneIP='" + IPAddress.ToString().Trim() + "') ";
            DtC = ObjGenBal.FetchData(QtrCompleted);

            if (DtC.Rows.Count > 0)
            {

              //  lblCompleted.InnerText = DtC.Rows[0][0].ToString();
            }
            else
            {
             //   lblCompleted.InnerText = "0";

            }

            //------------- Calculate %--------------------

            T = A + V + P + Q;
            //------------------Authorization------------------------
            lblA.InnerText = Convert.ToString(Math.Round( ( (A / T) * 100), 2 )) + "%";
            lblA.Style["width"] = Convert.ToString(Math.Round( ( (A/T) * 100), 2))+"%";

            lblV.InnerText = Convert.ToString(Math.Round( ( (V/T) * 100), 2)) + "%";
            lblV.Style["width"] = Convert.ToString(Math.Round( ( (V / T) * 100), 2)) + "%";

            lblP.InnerText = Convert.ToString(Math.Round( ( (P / T) * 100), 2 )) + "%";
            lblP.Style["width"] = Convert.ToString(Math.Round( ( (P / T) * 100), 2 ) )  + "%";

            lblQ.InnerText = Convert.ToString( Math.Round( ( (Q / T) * 100), 2 )) + "%";
            lblQ.Style["width"] = Convert.ToString( Math.Round( ( (Q / T) * 100), 2 )) + "%";
      


        }

        catch (Exception ex)
        {
            //MessageBox.Show(ex.Message);
        }
    }
}