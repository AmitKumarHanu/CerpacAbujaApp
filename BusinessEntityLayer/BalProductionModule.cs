using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BusinessEntityLayer
{
    public class BalProductionModule
    {
        public int UpdateProducedFlag(string CerpacNo, string reason, string condition, int userid, string CardNo)
        {
            DataAccessLayer.DalProductionModule ObjDalProduction = null;
            
            try
            {
                ObjDalProduction = new DataAccessLayer.DalProductionModule();

                return ObjDalProduction.UpdateProducedFlag(CerpacNo, reason, condition, userid, CardNo);

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
               // dt = null;
                ObjDalProduction = null;
            }
        }


        public int UpdateStikerFlag(string StikerNo, string reason, int userid)
        {
            DataAccessLayer.DalProductionModule ObjDalProduction = null;

            try
            {
                ObjDalProduction = new DataAccessLayer.DalProductionModule();

                return ObjDalProduction.UpdateStikerFlag(StikerNo, reason, userid);

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                // dt = null;
                ObjDalProduction = null;
            }
        }

        public int UpdateQualityFlag(string CerpacNo, int user_id)
        {
            DataAccessLayer.DalProductionModule ObjDalProduction = null;

            try
            {
                ObjDalProduction = new DataAccessLayer.DalProductionModule();

                return ObjDalProduction.UpdateQualityFlag(CerpacNo, user_id);

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                // dt = null;
                ObjDalProduction = null;
            }
        }

        public int UpdateQualityFlagReject(string CerpacNo, int user_id, string reason)
        {
            DataAccessLayer.DalProductionModule ObjDalProduction = null;

            try
            {
                ObjDalProduction = new DataAccessLayer.DalProductionModule();

                return ObjDalProduction.UpdateQualityFlagReject(CerpacNo, user_id, reason);

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                // dt = null;
                ObjDalProduction = null;
            }
        }


        public int UpdateLoginFlag(int userid, int condition)
        {
            DataAccessLayer.DalProductionModule ObjDalProduction = null;

            try
            {
                ObjDalProduction = new DataAccessLayer.DalProductionModule();

                return ObjDalProduction.UpdateLoginFlag(userid, condition);

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                // dt = null;
                ObjDalProduction = null;
            }
        }


        public int UpdateCerpacFlag(string userid, string cerpac_no)
        {
            DataAccessLayer.DalProductionModule ObjDalProduction = null;

            try
            {
                ObjDalProduction = new DataAccessLayer.DalProductionModule();

                return ObjDalProduction.UpdateCerpacFlag(userid, cerpac_no);

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                // dt = null;
                ObjDalProduction = null;
            }
        }

    }
}
