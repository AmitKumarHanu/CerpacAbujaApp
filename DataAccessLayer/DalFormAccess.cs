using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
   public class DalFormAccess
    {
       public void InsertFormAccess(DataTable dt,string UserId)
        {
            
            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[2];
                pram[0] = new SqlParameter("@UserId", UserId);
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspFormAccessDeleteByUserId",pram);
              
                CopyDataToDestination(new SqlConnection(AppSetting.ActivateConnection), dt);


            }
           catch (Exception ex)
           {
               throw(ex);
           }
            
        }






        private void CopyDataToDestination(SqlConnection con, DataTable table)
        {
            con.Open();
            SqlBulkCopyColumnMapping mapping1 =

                new SqlBulkCopyColumnMapping("FormId", "FormId");

            SqlBulkCopyColumnMapping mapping2 =

                new SqlBulkCopyColumnMapping("UserId", "UserId");

            SqlBulkCopyColumnMapping mapping3 =

                new SqlBulkCopyColumnMapping("Add_Permission", "Add_Permission");

            SqlBulkCopyColumnMapping mapping4 =

                new SqlBulkCopyColumnMapping("Mod_Permission", "Mod_Permission");

            SqlBulkCopyColumnMapping mapping5 =
                new SqlBulkCopyColumnMapping("Del_Permission", "Del_Permission");

            SqlBulkCopyColumnMapping mapping6 =

                new SqlBulkCopyColumnMapping("View_Permission", "View_Permission");

            SqlBulkCopy bulkCopy = new SqlBulkCopy(con);



            bulkCopy.BatchSize = 100;

            bulkCopy.BulkCopyTimeout = 5;

            bulkCopy.ColumnMappings.Add(mapping1);

            bulkCopy.ColumnMappings.Add(mapping2);

            bulkCopy.ColumnMappings.Add(mapping3);

            bulkCopy.ColumnMappings.Add(mapping4);

            bulkCopy.ColumnMappings.Add(mapping5);

            bulkCopy.ColumnMappings.Add(mapping6);


            bulkCopy.DestinationTableName = "FormAccess";

            bulkCopy.NotifyAfter = 200;

            bulkCopy.WriteToServer(table);
          
        }
    }
}
