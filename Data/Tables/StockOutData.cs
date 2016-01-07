using System;
using System.Data;

namespace SHND.Data.Tables
{
    /// <summary>
    /// Represents a STOCKOUT data.
    /// [Created by 127.0.0.1 on Febuary,10 2009]
    /// </summary>
    public class StockOutData
    {
        string _CODE = "";
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        double _DIVISION = 0;
        double _DOCTYPE = 0;
        string _ISBREAKFAST = "";
        string _ISDINNER = "";
        string _ISLUNCH = "";
        double _LOID = 0;
        double _ORDERQTY = 0;
        double _PRIORITY = 0;
        string _REMARKS = "";
        string _STATUS = "";
        DateTime _STOCKOUTDATE = new DateTime(1, 1, 1);
        double _SUPPLIER = 0;
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);
        DateTime _USEDATE = new DateTime(1, 1, 1);
        double _WAREHOUSE = 0;
        double _PLANORDER = 0;
        DataTable _STOCKOUTITEM;

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
        public double DIVISION
        {
            get { return _DIVISION; }
            set { _DIVISION = value; }
        }
        public double DOCTYPE
        {
            get { return _DOCTYPE; }
            set { _DOCTYPE = value; }
        }
        public string ISBREAKFAST
        {
            get { return _ISBREAKFAST; }
            set { _ISBREAKFAST = value; }
        }
        public string ISDINNER
        {
            get { return _ISDINNER; }
            set { _ISDINNER = value; }
        }
        public string ISLUNCH
        {
            get { return _ISLUNCH; }
            set { _ISLUNCH = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public double ORDERQTY
        {
            get { return _ORDERQTY; }
            set { _ORDERQTY = value; }
        }
        public double PRIORITY
        {
            get { return _PRIORITY; }
            set { _PRIORITY = value; }
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
        public DateTime STOCKOUTDATE
        {
            get { return _STOCKOUTDATE; }
            set { _STOCKOUTDATE = value; }
        }
        public double SUPPLIER
        {
            get { return _SUPPLIER; }
            set { _SUPPLIER = value; }
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
        public double WAREHOUSE
        {
            get { return _WAREHOUSE; }
            set { _WAREHOUSE = value; }
        }
        public double PLANORDER
        {
            get { return _PLANORDER; }
            set { _PLANORDER = value; }
        }
        public DataTable STOCKOUTITEM 
        {
            get { return _STOCKOUTITEM; }
            set { _STOCKOUTITEM = value; }
        }
    }
}