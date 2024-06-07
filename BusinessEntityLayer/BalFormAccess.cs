using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;
using System.Data.SqlClient;

namespace BusinessEntityLayer
{
    public class BalFormAccess
    {
        public void InsertFormAccess(string UserId,DataTable dt)
        {
            DataAccessLayer.DalFormAccess ObjDalDalFormAccess = null;

            try
            {
                ObjDalDalFormAccess = new DataAccessLayer.DalFormAccess();
                ObjDalDalFormAccess.InsertFormAccess(dt,UserId);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ObjDalDalFormAccess = null;

            }
        }
        

    }
}
