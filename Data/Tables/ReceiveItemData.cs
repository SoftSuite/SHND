using System;

namespace SHND.Data.Tables
{
    /// <summary>
    /// Represents a RECEIVEITEM data.
    /// [Created by 127.0.0.1 on March,17 2009]
    /// </summary>
    public class ReceiveItemData
    {
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        double _LOID = 0;
        double _MATERIALMASTER = 0;
        double _PREPODUEDATE = 0;
        double _RECEIVE = 0;
        double _RECEIVEQTY = 0;
        string _REMARKS = "";
        double _UNIT = 0;
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);

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
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public double MATERIALMASTER
        {
            get { return _MATERIALMASTER; }
            set { _MATERIALMASTER = value; }
        }
        public double PREPODUEDATE
        {
            get { return _PREPODUEDATE; }
            set { _PREPODUEDATE = value; }
        }
        public double RECEIVE
        {
            get { return _RECEIVE; }
            set { _RECEIVE = value; }
        }
        public double RECEIVEQTY
        {
            get { return _RECEIVEQTY; }
            set { _RECEIVEQTY = value; }
        }
        public string REMARKS
        {
            get { return _REMARKS; }
            set { _REMARKS = value; }
        }
        public double UNIT
        {
            get { return _UNIT; }
            set { _UNIT = value; }
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
    }
}