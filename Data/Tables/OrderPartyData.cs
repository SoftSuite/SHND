using System;

namespace SHND.Data.Tables
{
    /// <summary>
    /// Represents a ORDERPARTY data.
    /// [Created by 127.0.0.1 on Febuary,4 2009]
    /// </summary>
    public class OrderPartyData
    {
        string _CODE = "";
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        string _DESCRIPTION = "";
        string _DIRECTORAPPROVE = "";
        string _DIRECTORCOMMENT = "";
        double _DIVISION = 0;
        double _LOID = 0;
        string _NDAPPROVE = "";
        string _NDCOMMENT = "";
        string _OLASTNAME = "";
        string _ONAME = "";
        DateTime _ORDERDATE = new DateTime(1, 1, 1);
        string _OTEL = "";
        double _OTITLE = 0;
        double _PARTYCATEGORY = 0;
        DateTime _PARTYDATETIME = new DateTime(1, 1, 1);
        double _PARTYTYPE = 0;
        string _PLACE = "";
        string _REFCODE = "";
        string _STATUS = "";
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);
        double _VISITORQTY = 0;

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
        public string DESCRIPTION
        {
            get { return _DESCRIPTION; }
            set { _DESCRIPTION = value; }
        }
        public string DIRECTORAPPROVE
        {
            get { return _DIRECTORAPPROVE; }
            set { _DIRECTORAPPROVE = value; }
        }
        public string DIRECTORCOMMENT
        {
            get { return _DIRECTORCOMMENT; }
            set { _DIRECTORCOMMENT = value; }
        }
        public double DIVISION
        {
            get { return _DIVISION; }
            set { _DIVISION = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public string NDAPPROVE
        {
            get { return _NDAPPROVE; }
            set { _NDAPPROVE = value; }
        }
        public string NDCOMMENT
        {
            get { return _NDCOMMENT; }
            set { _NDCOMMENT = value; }
        }
        public string OLASTNAME
        {
            get { return _OLASTNAME; }
            set { _OLASTNAME = value; }
        }
        public string ONAME
        {
            get { return _ONAME; }
            set { _ONAME = value; }
        }
        public DateTime ORDERDATE
        {
            get { return _ORDERDATE; }
            set { _ORDERDATE = value; }
        }
        public string OTEL
        {
            get { return _OTEL; }
            set { _OTEL = value; }
        }
        public double OTITLE
        {
            get { return _OTITLE; }
            set { _OTITLE = value; }
        }
        public double PARTYCATEGORY
        {
            get { return _PARTYCATEGORY; }
            set { _PARTYCATEGORY = value; }
        }
        public DateTime PARTYDATETIME
        {
            get { return _PARTYDATETIME; }
            set { _PARTYDATETIME = value; }
        }
        public double PARTYTYPE
        {
            get { return _PARTYTYPE; }
            set { _PARTYTYPE = value; }
        }
        public string PLACE
        {
            get { return _PLACE; }
            set { _PLACE = value; }
        }
        public string REFCODE
        {
            get { return _REFCODE; }
            set { _REFCODE = value; }
        }
        public string STATUS
        {
            get { return _STATUS; }
            set { _STATUS = value; }
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
        public double VISITORQTY
        {
            get { return _VISITORQTY; }
            set { _VISITORQTY = value; }
        }
    }
}