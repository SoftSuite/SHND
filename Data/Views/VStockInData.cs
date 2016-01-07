using System;
using System.Collections;
using System.Data;

namespace SHND.Data.Views
{
    /// <summary>
    /// Represents a V_STOCKIN data.
    /// [Created by 127.0.0.1 on Febuary,18 2009]
    /// </summary>
    public class VStockInData
    {
        string _CODE = "";
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        double _DIVISION = 0;
        double _DOCLOID = 0;
        string _DOCNAME = "";
        double _DOCTYPE = 0;
        string _INVCODE = "";
        string _ISSTOCKIN = "";
        string _ISVAT = "";
        double _LOID = 0;
        double _PO = 0;
        double _PLANORDER = 0;
        double _PLANMATERIALCLASS = 0;
        double _MATERIALCLASS = 0;
        string _REFCODE = "";
        string _STATUS = "";
        string _STATUSNAME = "";
        string _STATUSRANK = "";
        double _SAPWAREHOUSE = 0;
        string _REMARKS = "";
        DateTime _STOCKINDATE = new DateTime(1, 1, 1);
        double _WAREHOUSE = 0;
        DataTable _ItemTable = new DataTable();
        ArrayList _ItemList = new ArrayList();

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
        public double DOCLOID
        {
            get { return _DOCLOID; }
            set { _DOCLOID = value; }
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
        public string INVCODE
        {
            get { return _INVCODE; }
            set { _INVCODE = value; }
        }
        public string ISSTOCKIN
        {
            get { return _ISSTOCKIN; }
            set { _ISSTOCKIN = value; }
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
        public double PO
        {
            get { return _PO; }
            set { _PO = value; }
        }
        public double PLANORDER
        {
            get { return _PLANORDER; }
            set { _PLANORDER = value; }
        }
        public double PLANMATERIALCLASS
        {
            get { return _PLANMATERIALCLASS; }
            set { _PLANMATERIALCLASS = value; }
        }
        public double MATERIALCLASS
        {
            get { return _MATERIALCLASS; }
            set { _MATERIALCLASS = value; }
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
        public DateTime STOCKINDATE
        {
            get { return _STOCKINDATE; }
            set { _STOCKINDATE = value; }
        }
        public double WAREHOUSE
        {
            get { return _WAREHOUSE; }
            set { _WAREHOUSE = value; }
        }
        public double SAPWAREHOUSE
        {
            get { return _SAPWAREHOUSE; }
            set { _SAPWAREHOUSE = value; }
        }
        public string REMARKS
        {
            get { return _REMARKS; }
            set { _REMARKS = value; }
        }
        public DataTable StockInTable
        {
            get { return _ItemTable; }
            set { _ItemTable = value; }
        }

        public ArrayList StockInList
        {
            get { return _ItemList; }
            set { _ItemList = value; }
        }
    }
}