using System;

namespace SHND.Data.Views
{
    /// <summary>
    /// Represents a V_ORDER_PARTY_SEARCH data.
    /// [Created by 127.0.0.1 on March,11 2009]
    /// </summary>
    public class VOrderPartySearchData
    {
        double _DIVISIONID = 0;
        string _DIVISIONNAME = "";
        string _NDAPPROVE = "";
        double _OPLOID = 0;
        string _ORDERCODE = "";
        DateTime _ORDERDATE = new DateTime(1, 1, 1);
        DateTime _PARTYDATETIME = new DateTime(1, 1, 1);
        string _PARTYTYPE = "";
        double _PARTYTYPEID = 0;
        string _PLACE = "";
        string _STATUS = "";
        string _STATUSNAME = "";
        double _VISITORQTY = 0;

        public double DIVISIONID
        {
            get { return _DIVISIONID; }
            set { _DIVISIONID = value; }
        }
        public string DIVISIONNAME
        {
            get { return _DIVISIONNAME; }
            set { _DIVISIONNAME = value; }
        }
        public string NDAPPROVE
        {
            get { return _NDAPPROVE; }
            set { _NDAPPROVE = value; }
        }
        public double OPLOID
        {
            get { return _OPLOID; }
            set { _OPLOID = value; }
        }
        public string ORDERCODE
        {
            get { return _ORDERCODE; }
            set { _ORDERCODE = value; }
        }
        public DateTime ORDERDATE
        {
            get { return _ORDERDATE; }
            set { _ORDERDATE = value; }
        }
        public DateTime PARTYDATETIME
        {
            get { return _PARTYDATETIME; }
            set { _PARTYDATETIME = value; }
        }
        public string PARTYTYPE
        {
            get { return _PARTYTYPE; }
            set { _PARTYTYPE = value; }
        }
        public double PARTYTYPEID
        {
            get { return _PARTYTYPEID; }
            set { _PARTYTYPEID = value; }
        }
        public string PLACE
        {
            get { return _PLACE; }
            set { _PLACE = value; }
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
        public double VISITORQTY
        {
            get { return _VISITORQTY; }
            set { _VISITORQTY = value; }
        }
    }
}