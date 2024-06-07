using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    /// <summary>
    /// Appsetting class is mainly used for making connection using webconfig file.
    /// </summary>
    /// <author>Ankit Gupta</author>
    /// <created Date>22 sep 2009 </created>
    public static class AppSetting
    {

        public static SqlConnection _strConnection;
      /// <summary>
      /// Property for creating connection between data access layer and sql server      /// </summary>
        public static string ActivateConnection
        {
           
            get
            {

                return System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
            }
        }
    }
}
