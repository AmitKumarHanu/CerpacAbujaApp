using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DalDocGroupRelation
    {
        public DataTable BindGrid(string CompanyId,string DocNo)
        {

            SqlParameter[] pram = null;
            DataSet objDs = null;
            DataTable dt = null;
            try
            {
                pram = new SqlParameter[2];
                pram[0] = new SqlParameter("@CompanyId", CompanyId);
                pram[1] = new SqlParameter("@DocNo", DocNo);

                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspDocGroupRelationFetchByCompanyId", pram);
                dt = objDs.Tables[0];

                return dt;

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

        public DataTable BindDataList(string CompanyId, string DocNo)
        {

            SqlParameter[] pram = null;
            DataSet objDs = null;
            DataTable dt = null;
            try
            {
                pram = new SqlParameter[2];
                pram[0] = new SqlParameter("@CompanyId", CompanyId);
                pram[1] = new SqlParameter("@DocNo", DocNo);

                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspDocIdentifierRelationFetch", pram);
                dt = objDs.Tables[0];

                return dt;

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

        public DataTable DocInfo(string DocNo)
        {
            SqlParameter[] pram = null;
            DataSet objDs = null;
            DataTable dt = null;
            try
            {
                pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@DocNo", DocNo);

                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspDocUploadMasterFetch", pram);
                dt = objDs.Tables[0];

                return dt;

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
       

        public void InsertAccess(DataTable dt,DataTable dt1,string DocNo)
        {

            SqlParameter[] pram = null;
            try
            {
                pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@DocNo", DocNo);
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspDocGroupRelationDeleteByDocNo",pram);
                CopyGrpDocDataToDestination(new SqlConnection(AppSetting.ActivateConnection), dt);
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspDocIdentifierRelationDeleteByDocNo", pram);
                CopyIdentifierDocDataToDestination(new SqlConnection(AppSetting.ActivateConnection), dt1);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        private void CopyGrpDocDataToDestination(SqlConnection con, DataTable table)
        {
            con.Open();
            SqlBulkCopyColumnMapping mapping1 =

                new SqlBulkCopyColumnMapping("DocNo", "DocNo");

            SqlBulkCopyColumnMapping mapping2 =

                new SqlBulkCopyColumnMapping("GrpId", "GrpId");

            SqlBulkCopyColumnMapping mapping3 =

                new SqlBulkCopyColumnMapping("View_Permission", "View_Permission");

            SqlBulkCopy bulkCopy = new SqlBulkCopy(con);



            bulkCopy.BatchSize = 100;

            bulkCopy.BulkCopyTimeout = 5;

            bulkCopy.ColumnMappings.Add(mapping1);

            bulkCopy.ColumnMappings.Add(mapping2);

            bulkCopy.ColumnMappings.Add(mapping3);


            bulkCopy.DestinationTableName = "DocGroupRelation";

            bulkCopy.NotifyAfter = 200;

            bulkCopy.WriteToServer(table);

        }


        private void CopyIdentifierDocDataToDestination(SqlConnection con, DataTable table)
        {
            con.Open();
            SqlBulkCopyColumnMapping mapping1 =

                new SqlBulkCopyColumnMapping("DocNo", "DocNo");

            SqlBulkCopyColumnMapping mapping2 =

                new SqlBulkCopyColumnMapping("IdentifierId", "IdentifierId");

            SqlBulkCopy bulkCopy = new SqlBulkCopy(con);
           
            bulkCopy.BatchSize = 100;

            bulkCopy.BulkCopyTimeout = 5;

            bulkCopy.ColumnMappings.Add(mapping1);

            bulkCopy.ColumnMappings.Add(mapping2);

            bulkCopy.DestinationTableName = "DocIdentifierRelation";

            bulkCopy.NotifyAfter = 200;

            bulkCopy.WriteToServer(table);

        }
    }
}
