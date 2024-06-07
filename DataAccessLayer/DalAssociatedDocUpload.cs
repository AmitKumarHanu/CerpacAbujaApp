using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
   public class DalAssociatedDocUpload
    {
       public int InsertAsscociatedDocUpload( Hashtable ht)
       {
           SqlParameter[] pram = null;
           try
           {
               pram = new SqlParameter[14];

               pram[0] = new SqlParameter("@AssDocId", ht["AssDocId"].ToString());
               pram[1] = new SqlParameter("@DocId", ht["DocId"].ToString());
               pram[2] = new SqlParameter("@AsscoDocTypeId", ht["AsscoDocTypeId"].ToString());
               pram[3] = new SqlParameter("@DateTypeId", ht["DateTypeId"].ToString());
               pram[4] = new SqlParameter("@date", ht["date"].ToString());
               pram[5] = new SqlParameter("@NotifyDays", ht["NotifyDays"].ToString());
               pram[6] = new SqlParameter("@AsscoDocDesc", ht["AsscoDocDesc"].ToString());
               pram[7] = new SqlParameter("@ActionRemark", ht["ActionRemark"].ToString());
               pram[8] = new SqlParameter("@AsscoDocName", ht["AsscoDocName"].ToString());
               pram[9] = new SqlParameter("@AssDocExtension", ht["AssDocExtension"].ToString());
               pram[10] = new SqlParameter("@IsEmail", ht["IsEmail"].ToString());
               pram[11] = new SqlParameter("@ActionTakenBy", ht["ActionTakenBy"].ToString());
               pram[12] = new SqlParameter("@ActionDate", ht["ActionDate"].ToString());
               pram[13] = new SqlParameter("@SuccessId", 1);
               pram[13].Direction = ParameterDirection.Output;
               SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspAssociatedDocUploadInsert", pram);
               return int.Parse(pram[11].Value.ToString());

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

       public DataTable GetAssociateDocTypeList()
       {
           SqlParameter[] pram = null;
           DataSet ds = null;
           try
           {
               ds = new DataSet();
               pram = new SqlParameter[1];

               ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspAssociatedDocTypeNameFetchList", pram);
               return ds.Tables[0];

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

       public DataTable GetAssociatedDocUploadbyDocId(string DocId)
       {
           SqlParameter[] pram = null;
           DataSet ds = null;
           try
           {
               ds = new DataSet();
               pram = new SqlParameter[1];
               pram[0] = new SqlParameter("@Id", DocId);

               ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspAssociatedDocUploadFetchbyDocId", pram);
               return ds.Tables[0];

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

       public DataTable GetAssociatedDocUploadByAssoId(string AssoId)
       {
           SqlParameter[] pram = null;
           DataSet ds = null;
           try
           {
               ds = new DataSet();
               pram = new SqlParameter[1];
               pram[0] = new SqlParameter("@Id", AssoId);

               ds = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspAssociatedDocUploadFetchbyAssDocId", pram);
               return ds.Tables[0];

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
    }
}
