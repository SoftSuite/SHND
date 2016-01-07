using System;

namespace SHND.Data.Tables
{
    /// <summary>
    /// Represents a WARD data.
    /// [Created by 127.0.0.1 on January,30 2009]
    /// </summary>
    public class WardData
    {
        string _ABBNAME = "";
        bool  _ACTIVE = false;
        bool _ISLOCKCUTOFFTIME = false;
        double _BEDQTY = 0;
        string _CODE = "";
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        double _DEFAULTFOODTYPE = 0;
        double _LOID = 0;
        string _NAME = "";
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);
        string _SAPCODE = "";

        public string ABBNAME
        {
            get { return _ABBNAME; }
            set { _ABBNAME = value; }
        }
        public bool ACTIVE
        {
            get { return _ACTIVE; }
            set { _ACTIVE = value; }
        }
        public bool ISLOCKCUTOFFTIME
        {
            get { return _ISLOCKCUTOFFTIME; }
            set { _ISLOCKCUTOFFTIME = value; }
        }
        public double BEDQTY
        {
            get { return _BEDQTY; }
            set { _BEDQTY = value; }
        }
        public string CODE
        {
            get { return _CODE; }
            set { _CODE = value; }
        }
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
        public double DEFAULTFOODTYPE
        {
            get { return _DEFAULTFOODTYPE; }
            set { _DEFAULTFOODTYPE = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public string NAME
        {
            get { return _NAME; }
            set { _NAME = value; }
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
        public string SAPCODE
        {
            get { return _SAPCODE; }
            set { _SAPCODE = value; }
        }
    }
}