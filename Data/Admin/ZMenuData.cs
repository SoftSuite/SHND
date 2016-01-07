using System;
using System.Collections;
using System.Data;

namespace SHND.Data.Tables
{
    /// <summary>
    /// Represents a ZMENU data.
    /// [Created by 127.0.0.1 on Febuary,2 2009]
    /// </summary>
    public class ZMenuData
    {
        DateTime _CREATEON = new DateTime(1, 1, 1);
        string _DESCRIPTION = "";
        string _ENABLED = "";
        string _IMAGE = "";
        string _LINK = "";
        double _LOID = 0;
        double _MENUGROUP = 0;
        string _MENUNAME = "";
        double _PARENT = 0;
        double _SEQUENCE = 0;
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
        public string ENABLED
        {
            get { return _ENABLED; }
            set { _ENABLED = value; }
        }
        public string IMAGE
        {
            get { return _IMAGE; }
            set { _IMAGE = value; }
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
        public double ZSYSTEM
        {
            get { return _ZSYSTEM; }
            set { _ZSYSTEM = value; }
        }
       
    }
}