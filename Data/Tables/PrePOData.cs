using System;

namespace SHND.Data.Tables
{
    /// <summary>
    /// Represents a PREPO data.
    /// [Created by 127.0.0.1 on Febuary,19 2009]
    /// </summary>
    public class PrePOData
    {
        string _ADDRESS = "";
        DateTime _BPODATE = new DateTime(1, 1, 1);
        string _CNAME = "";
        string _CODE = "";
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        string _FAX = "";
        double _LOID = 0;
        double _PLANMATERIALCLASS = 0;
        string _REMARKS = "";
        string _STATUS = "";
        string _TEL = "";
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);
        DateTime _USEDATE = new DateTime(1, 1, 1);

        public string ADDRESS
        {
            get { return _ADDRESS; }
            set { _ADDRESS = value; }
        }
        public DateTime BPODATE
        {
            get { return _BPODATE; }
            set { _BPODATE = value; }
        }
        public string CNAME
        {
            get { return _CNAME; }
            set { _CNAME = value; }
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
        public string FAX
        {
            get { return _FAX; }
            set { _FAX = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public double PLANMATERIALCLASS
        {
            get { return _PLANMATERIALCLASS; }
            set { _PLANMATERIALCLASS = value; }
        }
        public string REMARKS
        {
            get { return _REMARKS; }
            set { _REMARKS = value; }
        }
        public string STATUS
        {
            get { return _STATUS; }
            set { _STATUS = value; }
        }
        public string TEL
        {
            get { return _TEL; }
            set { _TEL = value; }
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
        public DateTime USEDATE
        {
            get { return _USEDATE; }
            set { _USEDATE = value; }
        }
    }
}