using System;

namespace SHND.Data.Tables
{
    /// <summary>
    /// Represents a ORDERPARTYITEM data.
    /// [Created by 127.0.0.1 on Febuary,5 2009]
    /// </summary>
    public class OrderPartyItemData
    {
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        double _FORMULASET = 0;
        double _LOID = 0;
        double _ORDERPARTY = 0;
        double _SERVICEQTY = 0;
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);
        double _VISITORQTY = 0;

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
        public double FORMULASET
        {
            get { return _FORMULASET; }
            set { _FORMULASET = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public double ORDERPARTY
        {
            get { return _ORDERPARTY; }
            set { _ORDERPARTY = value; }
        }
        public double SERVICEQTY
        {
            get { return _SERVICEQTY; }
            set { _SERVICEQTY = value; }
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