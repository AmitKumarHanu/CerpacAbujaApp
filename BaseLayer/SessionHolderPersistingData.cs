using System;
using System.Collections.Generic;
using System.Text;


namespace BaseLayer
{
    /// <summary>
    /// This Class would Persist Data required for the application per user session
    /// String, Integers or other objects which we want to pertain thorugh out the user session, is maintained thorugh this class
    /// </summary>
    /// <Author>Ankit</Author>
    /// <CreatedOn>7th May 2008</CreatedOn>   
    /// </summary>
    public class SessionHolderPersistingData
    {
        //SessionHolderPersistingData ObjectSessionHolderPersistingData = null;

        string _User_ID = "";
        string _User_Type = "";
        string _Grp_ID = "";
        string _Grp_Name = "";
        string _User_Status = "";
        string _User_Name = "";
        string _CompanyId = "";
        string _CompanyName = "";
        string _LoginId = "";
        string _LevelType = "";
        string _Grp_Code = "";

        /// <summary>
        /// Public Constructor
        /// </summary>
        public SessionHolderPersistingData()
        {

        }

        /// <summary>
        /// This Property will contain the User_ID, and will pertain that thorugh out the session of User
        /// </summary>
        /// <Author>Ankit</Author>
        /// <CreatedOn>24th june 2008</CreatedOn>
        public string LoginId
        {
            get
            {
                return _LoginId;
            }
            set
            {
                _LoginId = value;
            }
        }

        public string User_ID
        {
            get
            {
                return _User_ID;
            }
            set
            {
                _User_ID = value;
            }
        }

        public string User_Type
        {
            get
            {
                return _User_Type;
            }
            set
            {
                _User_Type = value;
            }
        }

        public string CompanyId
        {
            get
            {
                return _CompanyId;
            }
            set
            {
                _CompanyId = value;
            }
        }

        public string CompanyName
        {
            get
            {
                return _CompanyName;
            }
            set
            {
                _CompanyName = value;
            }
        }







        /// <summary>
        /// This Property will contain the _User_Type, and will pertain that thorugh out the session of User
        /// </summary>
        /// <Author>Ankit</Author>
        /// <CreatedOn>24th june 2008</CreatedOn>
        public string Grp_ID
        {
            get
            {
                return _Grp_ID;
            }
            set
            {
                _Grp_ID = value;
            }
        }


        /// <summary>
        /// This Property will contain the _User_Status, and will pertain that thorugh out the session of User
        /// </summary>
        /// <Author>Ankit</Author>
        /// <CreatedOn>24th june 2008</CreatedOn>
        public string User_Status
        {
            get
            {
                return _User_Status;
            }
            set
            {
                _User_Status = value;
            }
        }

        /// <summary>
        /// This Property will contain the First_Name, and will pertain that thorugh out the session of User
        /// </summary>
        /// <Author>Ankit</Author>
        /// <CreatedOn>24th june 2008</CreatedOn>
        public string Grp_Name
        {
            get
            {
                return _Grp_Name;
            }
            set
            {
                _Grp_Name = value;
            }
        }

        /// <summary>
        /// This Property will contain the First_Name, and will pertain that thorugh out the session of User
        /// </summary>
        /// <Author>Ankit</Author>
        /// <CreatedOn>24th june 2008</CreatedOn>
        public string User_Name
        {
            get
            {
                return _User_Name;
            }
            set
            {
                _User_Name = value;
            }
        }



        /// <summary>
        /// This Property will contain the Approvel Level and will pertain that thorugh out the session of Level
        /// </summary>
        /// <Author>Dilip</Author>
        /// <CreatedOn>9th SEP 2011</CreatedOn>
        /// 

        public string LevelType
        {
            get
            {
                return _LevelType;
            }
            set
            {
                _LevelType = value;
            }
        }

        public string GrpCode
        {
            get
            {
                return _Grp_Code;
            }
            set
            {
                _Grp_Code = value;
            }
        }

    }

}