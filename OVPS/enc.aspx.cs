using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class enc : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Configuration config = WebConfigurationManager.OpenWebConfiguration("~");
        ConfigurationSection sec = config.GetSection("connectionStrings");
        
           //sec.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
       
           sec.SectionInformation.UnprotectSection();
        
        config.Save();
    }
}