using System;

namespace SHND.Data.Tables
{
    /// <summary>
    /// Represents a PREPOITEM data.
    /// [Created by 127.0.0.1 on Febuary,19 2009]
    /// </summary>
    public class PrePOItemData
    {
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        string _ISVAT = "";
        double _LOID = 0;
        double _MATERIALMASTER = 0;
        double _MENUQTY = 0;
        double _ORDERQTY = 0;
        double _PLANREMAINQTY = 0;
        double _PREPO = 0;
        string _REMARKS = "";
        double _UNIT = 0;
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);
        double _USEQTY = 0;
        double _NETPRICE = 0;
        string _CODE = "";
        double _PRICE = 0;

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
        public string ISVAT
        {
            get { return _ISVAT; }
            set { _ISVAT = value; }
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
        public double MENUQTY
        {
            get { return _MENUQTY; }
            set { _MENUQTY = value; }
        }
        public double ORDERQTY
        {
            get { return _ORDERQTY; }
            set { _ORDERQTY = value; }
        }
        public double PLANREMAINQTY
        {
            get { return _PLANREMAINQTY; }
            set { _PLANREMAINQTY = value; }
        }
        public double PREPO
        {
            get { return _PREPO; }
            set { _PREPO = value; }
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
        public double USEQTY
        {
            get { return _USEQTY; }
            set { _USEQTY = value; }
        }
        public double NETPRICE
        {
            get { return _NETPRICE; }
            set { _NETPRICE = value; }
        }
        public string CODE
        {
            get { return _CODE; }
            set { _CODE = value; }
        }
        public double PRICE
        {
            get { return _PRICE; }
            set { _PRICE = value; }
        }
    }
}