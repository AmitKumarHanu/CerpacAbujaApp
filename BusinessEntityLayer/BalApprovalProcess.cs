using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BusinessEntityLayer
{
    public class BalApprovalProcess
    {
       public int APPLICATIONID { get; set; }


       public DataTable GetApplicationListByUserID(string UserID)
       {
           DataAccessLayer.DalApprovalProcess ObjDalDalApprovalProcess = null;
           DataTable dt = null;
           dt = new DataTable();

           try
           {
               ObjDalDalApprovalProcess = new DataAccessLayer.DalApprovalProcess();
               return dt = ObjDalDalApprovalProcess.GetApplicationListByUserID(UserID);

           }
           catch (Exception ex)
           {
               throw (ex);
           }

           finally
           {
               ObjDalDalApprovalProcess = null;
           }
       }

       public DataTable GetApplicationListByAppID(string UserID,string ApplicationID)
       {
           DataAccessLayer.DalApprovalProcess ObjDalDalApprovalProcess = null;
           DataTable dt = null;
           dt = new DataTable();

           try
           {
               ObjDalDalApprovalProcess = new DataAccessLayer.DalApprovalProcess();
               return dt = ObjDalDalApprovalProcess.GetApplicationListByAppID(UserID, ApplicationID);

           }
           catch (Exception ex)
           {
               throw (ex);
           }

           finally
           {
               ObjDalDalApprovalProcess = null;
           }
       }

       public DataTable GetApplicationDetails(string ApplicationID)
       {
           DataAccessLayer.DalApprovalProcess ObjDalDalApprovalProcess = null;
           DataTable dt = null;
           dt = new DataTable();

           try
           {
               ObjDalDalApprovalProcess = new DataAccessLayer.DalApprovalProcess();
               return dt = ObjDalDalApprovalProcess.GetApplicationDetails(ApplicationID);
           }
           catch (Exception ex)
           {
               throw (ex);
           }

           finally
           {
               ObjDalDalApprovalProcess = null;
           }
       }

       public DataTable GetAllActivitiesByUserID(string UserID, string strAppID)
       {
           DataAccessLayer.DalApprovalProcess ObjDalDalApprovalProcess = null;
           DataTable dt = null;
           dt = new DataTable();

           try
           {
               ObjDalDalApprovalProcess = new DataAccessLayer.DalApprovalProcess();
               return dt = ObjDalDalApprovalProcess.GetAllActivitiesByUserID(UserID, strAppID);
           }
           catch (Exception ex)
           {
               throw (ex);
           }

           finally
           {
               ObjDalDalApprovalProcess = null;
           }
       }

       public int UpdateApplicationWorkFlow(string ApplicationID, string StepId, string ActivityCode, string FlagActivityStatus, string Comments, string UserID, string strFileName)
       {
           DataAccessLayer.DalApprovalProcess ObjDalApprovalProcesss = null;
           DataTable dt = null;
           //try
           //{
               ObjDalApprovalProcesss = new DataAccessLayer.DalApprovalProcess();
               dt = new DataTable();

               DataRow dr = dt.NewRow();

               //Code for adding columns in datatable.
               dt.Columns.Add("ApplicationID");
               dt.Columns.Add("StepId");
               dt.Columns.Add("ActivityCode");
               dt.Columns.Add("FlagActivityStatus");
               dt.Columns.Add("Comments");
               dt.Columns.Add("UserID");
               dt.Columns.Add("strFileName");      
             
                dr["ApplicationID"] = ApplicationID;
                dr["StepId"] = StepId;
                dr["ActivityCode"] = ActivityCode;
                dr["FlagActivityStatus"] = FlagActivityStatus;
                dr["Comments"] = Comments;
                dr["UserID"] = UserID;
                dr["strFileName"] = strFileName;

               dt.Rows.Add(dr);

               return ObjDalApprovalProcesss.UpdateApplicationWorkFlow(dt);
           //}
           //catch (Exception ex)
           //{
           //    throw (ex);
           //}

           //finally
           //{
           //    dt = null;
           //    ObjDalApprovalProcesss = null;
           //}
       }

       public int UpdateApplicationForImg(string ApplicationID, string UserID)
       {
           DataAccessLayer.DalApprovalProcess ObjDalApprovalProcesss = null;
           DataTable dt = null;
           //try
           //{
           ObjDalApprovalProcesss = new DataAccessLayer.DalApprovalProcess();
           dt = new DataTable();

           DataRow dr = dt.NewRow();

           //Code for adding columns in datatable.
           dt.Columns.Add("ApplicationID");
           dt.Columns.Add("USERID");

           dr["ApplicationID"] = ApplicationID;
           dr["USERID"] = UserID;

           dt.Rows.Add(dr);

           return ObjDalApprovalProcesss.UpdateApplicationForImg(dt);
           //}
           //catch (Exception ex)
           //{
           //    throw (ex);
           //}

           //finally
           //{
           //    dt = null;
           //    ObjDalApprovalProcesss = null;
           //}
       }

       public int UpdateApplicationForRejection(string ApplicationID, string strRejectionCode, string strRejectionDesc)
       {
           DataAccessLayer.DalApprovalProcess ObjDalApprovalProcesss = null;
           DataTable dt = null;
           //try
           //{
           ObjDalApprovalProcesss = new DataAccessLayer.DalApprovalProcess();
           dt = new DataTable();

           DataRow dr = dt.NewRow();

           //Code for adding columns in datatable.
           dt.Columns.Add("ApplicationID");
           dt.Columns.Add("RejectionCode");
           dt.Columns.Add("RejectionDesc");

           dr["ApplicationID"] = ApplicationID;
           dr["RejectionCode"] = strRejectionCode;
           dr["RejectionDesc"] = strRejectionDesc;

           dt.Rows.Add(dr);

           return ObjDalApprovalProcesss.UpdateApplicationForRejection(dt);
           //}
           //catch (Exception ex)
           //{
           //    throw (ex);
           //}

           //finally
           //{
           //    dt = null;
           //    ObjDalApprovalProcesss = null;
           //}
       }

       public DataTable GetAllActivitiesByUserID(string UserID)
       {
           throw new NotImplementedException();
       }
    }
}
