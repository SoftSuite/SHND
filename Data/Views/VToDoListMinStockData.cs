using System;

namespace SHND.Data.Views
{
    /// <summary>
    /// Represents a V_TODOLIST_MINSTOCK data.
    /// [Created by 127.0.0.1 on Febuary,10 2009]
    /// </summary>
    public class VToDoListMinStockData
    {
        double _LOID = 0;
        double _MATERIALCLASS = 0;
        string _MATERIALCODE = "";
        string _MATERIALNAME = "";
        double _MINSTOCK = 0;
        double _QTY = 0;
        string _UNITNAME = "";
        double _WAREHOUSE = 0;
        string _WAREHOUSENAME = "";

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
        public string MATERIALCODE
        {
            get { return _MATERIALCODE; }
            set { _MATERIALCODE = value; }
        }
        public string MATERIALNAME
        {
            get { return _MATERIALNAME; }
            set { _MATERIALNAME = value; }
        }
        public double MINSTOCK
        {
            get { return _MINSTOCK; }
            set { _MINSTOCK = value; }
        }
        public double QTY
        {
            get { return _QTY; }
            set { _QTY = value; }
        }
        public string UNITNAME
        {
            get { return _UNITNAME; }
            set { _UNITNAME = value; }
        }
        public double WAREHOUSE
        {
            get { return _WAREHOUSE; }
            set { _WAREHOUSE = value; }
        }
        public string WAREHOUSENAME
        {
            get { return _WAREHOUSENAME; }
            set { _WAREHOUSENAME = value; }
        }
    }
}