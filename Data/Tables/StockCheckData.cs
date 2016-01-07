using System;

namespace SHND.Data.Tables
{
    /// <summary>
    /// Represents a STOCKCHECK data.
    /// [Created by 127.0.0.1 on Febuary,11 2009]
    /// </summary>
    public class StockCheckData
    {
        string _BATCHNO = "";
        DateTime _CHECKDATE = new DateTime(1, 1, 1);
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        double _LOID = 0;
        double _MATERIALCLASS = 0;
        string _REMARKS = "";
        string _STATUS = "";
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);
        double _WAREHOUSE = 0;

        public string BATCHNO
        {
            get { return _BATCHNO; }
            set { _BATCHNO = value; }
        }
        public DateTime CHECKDATE
        {
            get { return _CHECKDATE; }
            set { _CHECKDATE = value; }
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
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public double MATERIALCLASS
        {
            get { return _MATERIALCLASS; }
            set { _MATERIALCLASS = value; }
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