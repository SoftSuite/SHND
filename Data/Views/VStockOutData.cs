using System;
using System.Data;
using System.Collections;

namespace SHND.Data.Views
{
    /// <summary>
    /// Represents a V_STOCKOUT data.
    /// [Created by 127.0.0.1 on Febuary,19 2009]
    /// </summary>
    public class VStockOutData
    {
        string _CODE = "";
        double _DIVISION = 0;
        string _DIVISIONNAME = "";
        string _DOCNAME = "";
        double _DOCTYPE = 0;
        string _ISBREAKFAST = "";
        string _ISDINNER = "";
        string _ISLUNCH = "";
        double _LOID = 0;
        double _ORDERQTY = 0;
        double _PRIORITY = 0;
        string _REMARKS = "";
        string _STATUS = "";
        string _STATUSNAME = "";
        string _STATUSRANK = "";
        DateTime _STOCKOUTDATE = new DateTime(1, 1, 1);
        double _SUPPLIER = 0;
        DateTime _USEDATE = new DateTime(1, 1, 1);
        double _WAREHOUSE = 0;
        string _WAREHOUSECODE = "";
        string _WAREHOUSENAME = "";
        string _REASON = "";

        public string CODE
        {
            get { return _CODE; }
            set { _CODE = value; }
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
        public string DOCNAME
        {
            get { return _DOCNAME; }
            set { _DOCNAME = value; }
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
        public string WAREHOUSECODE
        {
            get { return _WAREHOUSECODE; }
            set { _WAREHOUSECODE = value; }
        }
        public string WAREHOUSENAME
        {
            get { return _WAREHOUSENAME; }
            set { _WAREHOUSENAME = value; }
        }
        DataTable _ItemTable = new DataTable();
        ArrayList _ItemList = new ArrayList();

        public DataTable StockoutWasteTable
        {
            get { return _ItemTable; }
            set { _ItemTable = value; }
        }

        public ArrayList StockoutWasteList
        {
            get { return _ItemList; }
            set { _ItemList = value; }
        }
        public string REASON
        {
            get { return _REASON; }
            set { _REASON = value; }
        }
    }
}