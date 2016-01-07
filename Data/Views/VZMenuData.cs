using System;
using System.Collections;
using System.Data;

namespace SHND.Data.Views
{
    /// <summary>
    /// Represents a V_ZMENU data.
    /// [Created by 127.0.0.1 on Febuary,4 2009]
    /// </summary>
    public class VZMenuData
    {
        DateTime _CREATEON = new DateTime(1, 1, 1);
        string _DESCRIPTION = "";
        string _ENABLED = "";
        string _FULLMENUNAME = "";
        string _GNAME = "";
        string _LINK = "";
        double _LOID = 0;
        double _MENUGROUP = 0;
        double _PARENT = 0;
        double _SEQUENCE = 0;
        string _SYSTEMNAME = "";
        double _ZSYSTEM = 0;
        
        DataTable _RestMenu = new DataTable();
        DataTable _GrantMenu = new DataTable();

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
        public string ENABLED
        {
            get { return _ENABLED; }
            set { _ENABLED = value; }
        }
        public string FULLMENUNAME
        {
            get { return _FULLMENUNAME; }
            set { _FULLMENUNAME = value; }
        }
        public string GNAME
        {
            get { return _GNAME; }
            set { _GNAME = value; }
        }
        public string LINK
        {
            get { return _LINK; }
            set { _LINK = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public double MENUGROUP
        {
            get { return _MENUGROUP; }
            set { _MENUGROUP = value; }
        }
        public double PARENT
        {
            get { return _PARENT; }
            set { _PARENT = value; }
        }
        public double SEQUENCE
        {
            get { return _SEQUENCE; }
            set { _SEQUENCE = value; }
        }
        public string SYSTEMNAME
        {
            get { return _SYSTEMNAME; }
            set { _SYSTEMNAME = value; }
        }
        public double ZSYSTEM
        {
            get { return _ZSYSTEM; }
            set { _ZSYSTEM = value; }
        }
        public DataTable RestMenu
        {
            get { return _RestMenu; }
            set { _RestMenu = value; }
        }
        public DataTable GrantMenu
        {
            get { return _GrantMenu; }
            set { _GrantMenu = value; }
        }
    }
}