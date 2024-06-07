using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DalCompanyRegistration
    {
        //----------Insert Company Registration Detials-------------
        public int ComRegInser(DataTable dt)
        {
            SqlParameter[] parm = null;
            try
            {
                parm = new SqlParameter[16];
                parm[0] = new SqlParameter("@loginID", dt.Rows[0]["LoginID"]);
                parm[1] = new SqlParameter("@password", dt.Rows[0]["password"]);
                parm[2] = new SqlParameter("@PersonEmailID", dt.Rows[0]["PersonEmailID"]);
                parm[3] = new SqlParameter("@CompanyName", dt.Rows[0]["CompanyName"]);
                parm[4] = new SqlParameter("@Director", dt.Rows[0]["Director"]);
               
                parm[5] = new SqlParameter("@Address", dt.Rows[0]["Address"]);
                parm[6] = new SqlParameter("@Phone", dt.Rows[0]["Phone"]);
                parm[7] = new SqlParameter("@ContactPerson", dt.Rows[0]["ContactPerson"]);
                parm[8] = new SqlParameter("@DateOfIncorporation", dt.Rows[0]["DOI"]);
                parm[9] = new SqlParameter("@Designation", dt.Rows[0]["Designation"]);

                parm[10] = new SqlParameter("@MobileNo", dt.Rows[0]["MobileNo"]);
                parm[11] = new SqlParameter("@EMailID", dt.Rows[0]["EMailID"]);
                parm[12] = new SqlParameter("@FilePath", dt.Rows[0]["Path"]);
                parm[13] = new SqlParameter("@CreatedBy", dt.Rows[0]["CreatedBy"]);
                parm[14] = new SqlParameter("@Opt", dt.Rows[0]["Opt"]);
                parm[15] = new SqlParameter("@RT", 1);


                parm[15].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspComRegDetails", parm);
                return int.Parse(parm[15].Value.ToString());

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                parm = null;
            }
        }

        //-------------Company Registatiration Details-----------
        public int UpDateCompany(DataTable dt)
        {
            SqlParameter[] parm = null;
            try
            {
                parm = new SqlParameter[16];
                parm[0] = new SqlParameter("@loginID", dt.Rows[0]["LoginID"]);
                parm[1] = new SqlParameter("@password", dt.Rows[0]["password"]);
                parm[2] = new SqlParameter("@PersonEmailID", dt.Rows[0]["PersonEmailID"]);
                parm[3] = new SqlParameter("@CompanyName", dt.Rows[0]["CompanyName"]);
                parm[4] = new SqlParameter("@Director", dt.Rows[0]["Director"]);

                parm[5] = new SqlParameter("@Address", dt.Rows[0]["Address"]);
                parm[6] = new SqlParameter("@Phone", dt.Rows[0]["Phone"]);
                parm[7] = new SqlParameter("@ContactPerson", dt.Rows[0]["ContactPerson"]);
                parm[8] = new SqlParameter("@DateOfIncorporation", dt.Rows[0]["DOI"]);
                parm[9] = new SqlParameter("@Designation", dt.Rows[0]["Designation"]);

                parm[10] = new SqlParameter("@MobileNo", dt.Rows[0]["MobileNo"]);
                parm[11] = new SqlParameter("@EMailID", dt.Rows[0]["EMailID"]);
                parm[12] = new SqlParameter("@FilePath", dt.Rows[0]["Path"]);
                parm[13] = new SqlParameter("@CreatedBy", dt.Rows[0]["CreatedBy"]);
                parm[14] = new SqlParameter("@Opt", dt.Rows[0]["Opt"]);
                parm[15] = new SqlParameter("@RT", 1);


                parm[15].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspComRegDetails", parm);
                return int.Parse(parm[15].Value.ToString());

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                parm = null;
            }
        }

        //------------Del Company Registration Details -----------

        public int DelCompany(DataTable dtDel)
        {
            SqlParameter[] parm = null;
            try
            {
                parm = new SqlParameter[16];
                parm[0] = new SqlParameter("@loginID", dtDel.Rows[0]["CompanyID"]);
                parm[1] = new SqlParameter("@password", "");
                parm[2] = new SqlParameter("@PersonEmailID", "");
                parm[3] = new SqlParameter("@CompanyName", "");
                parm[4] = new SqlParameter("@Director", "");
                parm[5] = new SqlParameter("@Address", "");
                parm[6] = new SqlParameter("@Phone", "");

                parm[7] = new SqlParameter("@ContactPerson", "");
                parm[8] = new SqlParameter("@DateOfIncorporation","");
                parm[9] = new SqlParameter("@Designation", "");

                parm[10] = new SqlParameter("@MobileNo", "");
                parm[11] = new SqlParameter("@EMailID", "");

                parm[12] = new SqlParameter("@FilePath", "");
                parm[13] = new SqlParameter("@CreatedBy", 1);
                parm[14] = new SqlParameter("@Opt", dtDel.Rows[0]["Opt"]);
                parm[15] = new SqlParameter("@RT", 1);



                parm[15].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(AppSetting.ActivateConnection, CommandType.StoredProcedure, "UspComRegDetails", parm);
                return int.Parse(parm[15].Value.ToString());

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                parm = null;
            }
        }

    }
    
}
