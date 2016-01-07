using System;
using System.Collections;
using SHND.Data.Tables;

namespace SHND.Data.Views
{
    /// <summary>
    /// Represents a V_ORDERPARTY data.
    /// [Created by 127.0.0.1 on Febuary,5 2009]
    /// </summary>
    public class VOrderPartyData
    {
        string _CODE = "";
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        string _DESCRIPTION = "";
        string _DIRECTORAPPROVE = "";
        string _DIRECTORCOMMENT = "";
        double _DIVISION = 0;
        string _DIVISIONNAME = "";
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
        string _PARTYTYPENAME = "";
        string _PLACE = "";
        string _REFCODE = "";
        string _STATUS = "";
        string _STATUSNAME = "";
        string _STATUSRANK = "";
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);
        double _VISITORQTY = 0;
        private ArrayList _OrderPartyItem = new ArrayList();

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
        public string DIVISIONNAME
        {
            get { return _DIVISIONNAME; }
            set { _DIVISIONNAME = value; }
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
        public string PARTYTYPENAME
        {
            get { return _PARTYTYPENAME; }
            set { _PARTYTYPENAME = value; }
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
        public string STATUSNAME
        {
            get { return _STATUSNAME; }
            set { _STATUSNAME = value; }
        }
        public string STATUSRANK
        {
            get { return _STATUSRANK; }
            set { _STATUSRANK = value; }
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
        public ArrayList OrderPartyItem
        {
            get { return _OrderPartyItem; }
            set { _OrderPartyItem = value; }
        }
    }
}