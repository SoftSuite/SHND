using System;

namespace SHND.Data.Views
{
    /// <summary>
    /// Represents a V_SYSTEMMENUSEARCH data.
    /// [Created by 127.0.0.1 on Febuary,2 2009]
    /// </summary>
    public class VSystemMenuSearchData
    {
        DateTime _CREATEON = new DateTime(1, 1, 1);
        string _DESCRIPTION = "";
        bool _ENABLED = false;
        string _GNAME = "";
        string _LINK = "";
        double _LOID = 0;
        double _MENUGROUP = 0;
        string _MENUNAME = "";
        double _PARENT = 0;
        double _SEQUENCE = 0;
        double _SUBMENU = 0;
        string _SYSTEMNAME = "";
        double _ZSYSTEM = 0;

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
        public bool ENABLED
        {
            get { return _ENABLED; }
            set { _ENABLED = value; }
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
        public string MENUNAME
        {
            get { return _MENUNAME; }
            set { _MENUNAME = value; }
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
        public double SUBMENU
        {
            get { return _SUBMENU; }
            set { _SUBMENU = value; }
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
    }
}