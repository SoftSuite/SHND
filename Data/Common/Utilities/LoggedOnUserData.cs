using System;
using System.Collections.Generic;
using System.Text;

namespace SHND.Data.Common.Utilities
{
    [Serializable]
    public class LoggedOnUserData
    {
        double _LOID = 0;
        string _USERNAME = "";
        double _DIVISION = 0;
        double _TITLE = 0;
        //string _TITLENAME = "";
        //string _FIRSTNAME = "";
        //string _LASTNAME = "";
        string _OFFICERGROUP = "";
        string _FULLNAME = "";
        string _DIVISIONNAME = "";
        string _OFFICERGROUPNAME = "";
        DateTime _LATSLOGON = new DateTime();
        //bool _Active = true;
        bool _ForcePWChange = false;
        UserData.Roles _Role = UserData.Roles.Guest;


        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public string USERNAME
        {
            get { return _USERNAME; }
            set { _USERNAME = value; }
        }
        public double DIVISION
        {
            get { return _DIVISION; }
            set { _DIVISION = value; }
        }
        public double TITLE
        {
            get { return _TITLE; }
            set { _TITLE = value; }
        }
        //public string TITLENAME
        //{
        //    get { return _TITLENAME; }
        //    set { _TITLENAME = value; }
        //}
        //public string FIRSTNAME
        //{
        //    get { return _FIRSTNAME; }
        //    set { _FIRSTNAME = value; }
        //}
        //public string LASTNAME
        //{
        //    get { return _LASTNAME; }
        //    set { _LASTNAME = value; }
        //}
        public string OFFICERGROUP
        {
            get { return _OFFICERGROUP; }
            set { _OFFICERGROUP = value; }
        }
        public string FULLNAME
        {
            get { return _FULLNAME; }
            set { _FULLNAME = value; }
        }
        public string DIVISIONNAME
        {
            get { return _DIVISIONNAME; }
            set { _DIVISIONNAME = value; }
        }
        public string OFFICERGROUPNAME
        {
            get { return _OFFICERGROUPNAME; }
            set { _OFFICERGROUPNAME = value; }
        }
        public DateTime LASTLOGON
        {
            get { return _LATSLOGON; }
            set { _LATSLOGON = value; }
        }
        //public bool Active
        //{
        //    get { return _Active; }
        //    set { _Active = value; }
        //}

        public bool ForcePWChange
        {
            get { return _ForcePWChange; }
            set { _ForcePWChange = value; }
        }
        public UserData.Roles UserRole
        {
            get { return _Role; }
            set { _Role = value; }
        }

    }
}
