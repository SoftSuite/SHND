using System;

namespace SHND.Data.Tables
{
    /// <summary>
    /// Represents a PREPODUEDATE data.
    /// [Created by 127.0.0.1 on Febuary,24 2009]
    /// </summary>
    public class PrePODuedateData
    {
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        DateTime _DUEDATE = new DateTime(1, 1, 1);
        double _DUEQTY = 0;
        double _LOID = 0;
        double _PREPOITEM = 0;
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);
        string _CODE = "";

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
        public DateTime DUEDATE
        {
            get { return _DUEDATE; }
            set { _DUEDATE = value; }
        }
        public double DUEQTY
        {
            get { return _DUEQTY; }
            set { _DUEQTY = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public double PREPOITEM
        {
            get { return _PREPOITEM; }
            set { _PREPOITEM = value; }
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
        public string CODE
        {
            get { return _CODE; }
            set { _CODE = value; }
        }
    }
}