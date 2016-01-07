using System;
using System.Collections;
using System.Data;

namespace SHND.Data.Order
{
    /// <summary>
    /// Represents a V_ORDERWELFARE data.
    /// [Created by 127.0.0.1 on January,14 2009]
    /// </summary>
    public class VOrderWelfareData
    {
        double _BD1 = 0;
        double _BD2 = 0;
        double _BD3 = 0;
        double _BD4 = 0;
        double _BD5 = 0;
        double _BD6 = 0;
        double _BD7 = 0;
        double _COUPON = 0;
        string _CREATEBY = "";
        double _DD1 = 0;
        double _DD2 = 0;
        double _DD3 = 0;
        double _DD4 = 0;
        double _DD5 = 0;
        double _DD6 = 0;
        double _DD7 = 0;
        double _DIVISION = 0;
        DateTime _FINISHDATE = new DateTime(1, 1, 1);
        string _ISSUBDIVISION = "";
        double _LD1 = 0;
        double _LD2 = 0;
        double _LD3 = 0;
        double _LD4 = 0;
        double _LD5 = 0;
        double _LD6 = 0;
        double _LD7 = 0;
        double _LOID = 0;
        double _MAINDIVISION = 0;
        string _NAME = "";
        string _ORDERCODE = "";
        DateTime _ORDERDATE = new DateTime(1, 1, 1);
        string _REFCODE = "";
        DateTime _REFDATE = new DateTime(1, 1, 1);
        DateTime _STARTDATE = new DateTime(1, 1, 1);
        string _STATUS = "";
        string _STATUSNAME = "";
        string _STATUSRANK = "";
        double _SUMQTY = 0;
        double _AMOUNT = 0;
        string _ISTIFFIN = "";
        DataTable _ItemTable = new DataTable();
        ArrayList _ItemList = new ArrayList();
        double _TIFFIN = 0;

        public double BD1
        {
            get { return _BD1; }
            set { _BD1 = value; }
        }
        public double BD2
        {
            get { return _BD2; }
            set { _BD2 = value; }
        }
        public double BD3
        {
            get { return _BD3; }
            set { _BD3 = value; }
        }
        public double BD4
        {
            get { return _BD4; }
            set { _BD4 = value; }
        }
        public double BD5
        {
            get { return _BD5; }
            set { _BD5 = value; }
        }
        public double BD6
        {
            get { return _BD6; }
            set { _BD6 = value; }
        }
        public double BD7
        {
            get { return _BD7; }
            set { _BD7 = value; }
        }
        public double COUPON
        {
            get { return _COUPON; }
            set { _COUPON = value; }
        }
        public string CREATEBY
        {
            get { return _CREATEBY; }
            set { _CREATEBY = value; }
        }
        public double DD1
        {
            get { return _DD1; }
            set { _DD1 = value; }
        }
        public double DD2
        {
            get { return _DD2; }
            set { _DD2 = value; }
        }
        public double DD3
        {
            get { return _DD3; }
            set { _DD3 = value; }
        }
        public double DD4
        {
            get { return _DD4; }
            set { _DD4 = value; }
        }
        public double DD5
        {
            get { return _DD5; }
            set { _DD5 = value; }
        }
        public double DD6
        {
            get { return _DD6; }
            set { _DD6 = value; }
        }
        public double DD7
        {
            get { return _DD7; }
            set { _DD7 = value; }
        }
        public double DIVISION
        {
            get { return _DIVISION; }
            set { _DIVISION = value; }
        }
        public DateTime FINISHDATE
        {
            get { return _FINISHDATE; }
            set { _FINISHDATE = value; }
        }
        public string ISSUBDIVISION
        {
            get { return _ISSUBDIVISION; }
            set { _ISSUBDIVISION = value; }
        }
        public double LD1
        {
            get { return _LD1; }
            set { _LD1 = value; }
        }
        public double LD2
        {
            get { return _LD2; }
            set { _LD2 = value; }
        }
        public double LD3
        {
            get { return _LD3; }
            set { _LD3 = value; }
        }
        public double LD4
        {
            get { return _LD4; }
            set { _LD4 = value; }
        }
        public double LD5
        {
            get { return _LD5; }
            set { _LD5 = value; }
        }
        public double LD6
        {
            get { return _LD6; }
            set { _LD6 = value; }
        }
        public double LD7
        {
            get { return _LD7; }
            set { _LD7 = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public double MAINDIVISION
        {
            get { return _MAINDIVISION; }
            set { _MAINDIVISION = value; }
        }
        public string NAME
        {
            get { return _NAME; }
            set { _NAME = value; }
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
        public string REFCODE
        {
            get { return _REFCODE; }
            set { _REFCODE = value; }
        }
        public DateTime REFDATE
        {
            get { return _REFDATE; }
            set { _REFDATE = value; }
        }
        public DateTime STARTDATE
        {
            get { return _STARTDATE; }
            set { _STARTDATE = value; }
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
        public double SUMQTY
        {
            get { return _SUMQTY; }
            set { _SUMQTY = value; }
        }
        public double AMOUNT
        {
            get { return _AMOUNT; }
            set { _AMOUNT = value; }
        }
        public string ISTIFFIN
        {
            get { return _ISTIFFIN; }
            set { _ISTIFFIN = value; }
        }
        public DataTable OrderWelfareItemTable
        {
            get { return _ItemTable; }
            set { _ItemTable = value; }
        }

        public ArrayList OrderWelfareItemList
        {
            get { return _ItemList; }
            set { _ItemList = value; }
        }
        public double TIFFIN
        {
            get { return _TIFFIN; }
            set { _TIFFIN = value; }
        }
    }
}