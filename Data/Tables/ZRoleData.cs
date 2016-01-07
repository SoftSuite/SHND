using System;
using System.Collections;
using System.Data;

namespace SHND.Data.Tables
{
    /// <summary>
    /// Represents a ZROLE data.
    /// [Created by 127.0.0.1 on Febuary,3 2009]
    /// </summary>
    public class ZRoleData
    {
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        string _DESCRIPTION = "";
        double _LOID = 0;
        double _OFFICER = 0;
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);
        string _ZLEVEL = "";
        ArrayList _GroupMenu = new ArrayList();
        DataTable _ZROLEASSIGN = new DataTable();

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
        public string DESCRIPTION
        {
            get { return _DESCRIPTION; }
            set { _DESCRIPTION = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public double OFFICER
        {
            get { return _OFFICER; }
            set { _OFFICER = value; }
        }
        public string UPDATEBY
        {
            get { return _UPDATEBY; }
            set { _UPDATEBY = value; }
        }
        public DateTime UPDATEON
        {
            get { return _UPDATEON; }
            set { _UPDATEON = value; }
        }
        public string ZLEVEL
        {
            get { return _ZLEVEL; }
            set { _ZLEVEL = value; }
        }
        public ArrayList RoleAssign
        {
            get { return _GroupMenu; }
            set { _GroupMenu = value; }
        }
        public DataTable ZROLEASSIGNDATATABLE
        {
            get { return _ZROLEASSIGN; }
            set { _ZROLEASSIGN = value; }
        }
    }
}