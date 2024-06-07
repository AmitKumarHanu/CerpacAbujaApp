
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_BankCheck : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        pnlforms.Controls.Add(new LiteralControl("<table>"));
        pnlforms.Controls.Add(new LiteralControl("<thead><tr ><td class=tbl><strong>Form No</strong></td> <td class=tbl>First Name</td> <td class=tbl>Last Name</td> <td class=tbl>Nationality</td> <td class=tbl>Company</td></tr></thead>"));
        pnlforms.Controls.Add(new LiteralControl("<tbody>"));
        if (Request.QueryString["FormNo"].ToString().Contains(","))
        {
            string querytxt = Request.QueryString["FormNo"].ToString();
            string[] formnos = new string[10];
            formnos = querytxt.Split(',');

            for (int i = 0; i < formnos.Length; i++)
            {
                BaseLayer.General_function gnfc = new BaseLayer.General_function();
                string query = "Select * from uploaded_excel_Data where FORMNO='" + formnos[i].ToString().Trim() + "'";
                DataTable dtfrms = new DataTable();
                dtfrms = gnfc.FetchData(query);
                if (dtfrms.Rows.Count > 0)
                {
                    pnlforms.Controls.Add(new LiteralControl("<tr>"));
                    pnlforms.Controls.Add(new LiteralControl("<td><strong>" + dtfrms.Rows[0]["FORMNO"].ToString() + "</strong></td> <td>" + dtfrms.Rows[0]["FirstName"].ToString() + "</td> <td>" + dtfrms.Rows[0]["LastName"].ToString() + "</td> <td>" + dtfrms.Rows[0]["Nationality"].ToString() + "</td> <td>" + dtfrms.Rows[0]["Company"].ToString() + "</td>"));
                    pnlforms.Controls.Add(new LiteralControl("</tr>"));
                }
                else
                {
                    pnlforms.Controls.Add(new LiteralControl("<tr class=tbl>"));
                    pnlforms.Controls.Add(new LiteralControl("<td>" + formnos[i].ToString() + "</td> <td colspan=5>No details found</td>"));
                    pnlforms.Controls.Add(new LiteralControl("</tr>"));
                }
            }
        }
        else
        {
                string querytxt = Request.QueryString["FormNo"].ToString();
            
                BaseLayer.General_function gnfc = new BaseLayer.General_function();
                string query = "Select * from uploaded_excel_Data where FORMNO='" + querytxt.ToString().Trim() + "'";
                DataTable dtfrms = new DataTable();
                dtfrms = gnfc.FetchData(query);
                if (dtfrms.Rows.Count > 0)
                {
                    pnlforms.Controls.Add(new LiteralControl("<tr class=tbl>"));
                    pnlforms.Controls.Add(new LiteralControl("<td><strong>" + dtfrms.Rows[0]["FORMNO"].ToString() + "</strong></td> <td>" + dtfrms.Rows[0]["FirstName"].ToString() + "</td> <td>" + dtfrms.Rows[0]["LastName"].ToString() + "</td> <td>" + dtfrms.Rows[0]["Nationality"].ToString() + "</td> <td>" + dtfrms.Rows[0]["Company"].ToString() + "</td>"));
                    pnlforms.Controls.Add(new LiteralControl("</tr>"));
                }
                else
                {
                    pnlforms.Controls.Add(new LiteralControl("<tr class=tbl>"));
                    pnlforms.Controls.Add(new LiteralControl("<td>" + querytxt.ToString() + "</td> <td colspan=5>No details found</td>"));
                    pnlforms.Controls.Add(new LiteralControl("</tr>"));
                }
            
        }
        pnlforms.Controls.Add(new LiteralControl("</tbody>"));
        pnlforms.Controls.Add(new LiteralControl("</table>"));
    }
}