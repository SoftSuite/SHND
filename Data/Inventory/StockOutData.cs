using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

/// <summary>
/// StockOutData Data Class
/// Version 1.0
/// =========================================================================
/// Create by: Teang
/// Create Date: 2 Mar 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Data Object สำหรับข้อมูล StockOut
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
namespace SHND.Data.Inventory
{
    public class StockOutData
    {
        string _CODE = "";
        double _DIVISION = 0;
        string _DIVISIONNAME = "";
        string _DOCNAME = "";
        double _DOCTYPE = 0;
        bool _ISBREAKFAST = true;
        bool _ISDINNER = true;
        bool _ISLUNCH = true;
        bool _ISREQUISITION = true;
        bool _ISSTOCKIN = true;
        bool _ISSTOCKOUT = true;
        double _LOID = 0;
        double _ORDERQTY = 0;
        double _PRIORITY = 0;
        string _REMARKS = "";
        string _STATUS = "";
        string _STATUSNAME = "";
        string _STATUSRANK = "";
        DateTime _STOCKOUTDATE = new DateTime(1, 1, 1);
        double _SUPPLIER = 0;
        string _TYPE = "";
        DateTime _USEDATE = new DateTime(1, 1, 1);
        double _WAREHOUSE = 0;
        string _WAREHOUSECODE = "";
        string _WAREHOUSENAME = "";
        ArrayList _ArrStockOutItem = new ArrayList();
        DataTable _StockOutTable = new DataTable();

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
        public bool ISBREAKFAST
        {
            get { return _ISBREAKFAST; }
            set { _ISBREAKFAST = value; }
        }
        public bool ISDINNER
        {
            get { return _ISDINNER; }
            set { _ISDINNER = value; }
        }
        public bool ISLUNCH
        {
            get { return _ISLUNCH; }
            set { _ISLUNCH = value; }
        }
        public bool ISREQUISITION
        {
            get { return _ISREQUISITION; }
            set { _ISREQUISITION = value; }
        }
        public bool ISSTOCKIN
        {
            get { return _ISSTOCKIN; }
            set { _ISSTOCKIN = value; }
        }
        public bool ISSTOCKOUT
        {
            get { return _ISSTOCKOUT; }
            set { _ISSTOCKOUT = value; }
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
        public string TYPE
        {
            get { return _TYPE; }
            set { _TYPE = value; }
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
        public ArrayList StockOutItemList
        {
            get { return _ArrStockOutItem; }
            set { _ArrStockOutItem = value; }
        }
        public DataTable StockOutItemTable
        {
            get { return _StockOutTable; }
            set { _StockOutTable = value; }
        }
    }
}
