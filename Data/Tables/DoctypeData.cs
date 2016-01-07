using System;

namespace SHND.Data.Tables
{
    /// <summary>
    /// Represents a DOCTYPE data.
    /// [Created by 127.0.0.1 on Febuary,13 2009]
    /// </summary>
    public class DoctypeData
    {
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        string _DESCRIPTION = "";
        string _DOCNAME = "";
        string _ISREQUISITION = "";
        double _LOID = 0;
        string _REPORTNAME = "";
        string _TYPE = "";
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);
        double _WAREHOUSE = 0;

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
        public string DOCNAME
        {
            get { return _DOCNAME; }
            set { _DOCNAME = value; }
        }
        public string ISREQUISITION
        {
            get { return _ISREQUISITION; }
            set { _ISREQUISITION = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public string REPORTNAME
        {
            get { return _REPORTNAME; }
            set { _REPORTNAME = value; }
        }
        public string TYPE
        {
            get { return _TYPE; }
            set { _TYPE = value; }
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
        public double WAREHOUSE
        {
            get { return _WAREHOUSE; }
            set { _WAREHOUSE = value; }
        }
    }
}