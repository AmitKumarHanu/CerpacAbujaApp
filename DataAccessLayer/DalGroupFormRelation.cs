using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
   public class DalGroupFormRelation
    {
        /// <summary>
        /// <author >Wasim Karim</author>
        /// <created Date>5 sept 2009</created>
        /// <purpose> Bind ListBoxes</purpose>
        /// </summary>
        /// <returns></returns>      

       public DataSet FillListBoxes(string GrpId, string CurrentLogin)
        {

            SqlParameter[] pram = null;
            DataSet objDs = null;
            try
            {
                pram = new SqlParameter[2];
                pram[0] = new SqlParameter("@GrpId", GrpId);
                pram[1] = new SqlParameter("@CurrentLogin", CurrentLogin);
               
                objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspListFormRelationFetchByGrpId", pram);
                objDs.Tables[0].TableName = "UnAssociated";
                objDs.Tables[1].TableName = "Associated";
                return objDs;

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
       public DataTable BindGrid(string UserId)
       {

           SqlParameter[] pram = null;
           DataSet objDs = null;
           DataTable dt = null;
           try
           {
               pram = new SqlParameter[1];
               pram[0] = new SqlParameter("@UserId", UserId);

               objDs = SqlHelper.ExecuteDataset(AppSetting.ActivateConnection, CommandType.StoredProcedure, "[UspFormAccessFetchByUserId]", pram);
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
        /// <summary>
        /// <author>Wasim Karim</author>
        /// <creation date>5 sept 2009</creation>
        /// <purpose>Insert into GroupFormRelation table</purpose>
        /// </summary>
        /// <returns></returns> 
       public int InsertGroupFormRelation(DataTable dt)
       {
           SqlParameter[] pram = null;
           try
           {
               pram = new SqlParameter[4];
               pram[0] = new SqlParameter("@CompanyID", dt.Rows[0]["CompanyID"]);
               pram[1] = new SqlParameter("@GrpId", dt.Rows[0]["GrpId"]);
               pram[2] = new SqlParameter("@FormIdList", dt.Rows[0]["FormId"]);

               pram[3] = new SqlParameter("@SuccessId", 1);
               pram[3].Direction = ParameterDirection.Output;
               SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspGroupFormRelationInsert", pram);
               return int.Parse(pram[3].Value.ToString());

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
