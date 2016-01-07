using System;

namespace SHND.Data.Tables
{
    /// <summary>
    /// Represents a ZROLEASSIGN data.
    /// [Created by 127.0.0.1 on Febuary,3 2009]
    /// </summary>
    public class VZRoleAssignData
    {
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        double _ZMENU = 0;
        double _ZROLE = 0;

        public string CREATEBY
        {
            get { return _CREATEBY; }
            set { _CREATEBY = value; }
        }
        public DateTime CREATEON
        {
            get { return _CREATEON; }
            set { _CREATEON = value; }
        }
        public double ZMENU
        {
            get { return _ZMENU; }
            set { _ZMENU = value; }
        }
        public double ZROLE
        {
            get { return _ZROLE; }
            set { _ZROLE = value; }
        }
    }
}