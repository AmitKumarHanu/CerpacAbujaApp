using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_FrmFileImport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnImportBankFile_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmImportCentralResponseBankData.aspx");
    }
    protected void btnImportAfterQC_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmImportEncryptfileAfterQC.aspx");
    }
}