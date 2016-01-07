using System;
using System.Collections;
using System.Data;

namespace SHND.Data.Views
{
    /// <summary>
    /// Represents a V_MILKCODE data.
    /// [Created by 127.0.0.1 on January,28 2009]
    /// </summary>
    public class VMilkCodeData
    {
      //  string _ACTIVE = "";
      //  double _BEDQTY = 0;
      //  string _CREATEBY = "";
      //  double _DEFAULTFOODTYPE = 0;
        double _LOID = 0;
        string _MILKCODE = "";
        string _NAME = "";
        double _WARD = 0;
        
        ArrayList _MilkCodeList = new ArrayList();
        DataTable _ItemTable = new DataTable();

      /*  public string ACTIVE
        {
            get { return _ACTIVE; }
            set { _ACTIVE = value; }
        }
        public double BEDQTY
        {
            get { return _BEDQTY; }
            set { _BEDQTY = value; }
        }
        public string CREATEBY
        {
            get { return _CREATEBY; }
            set { _CREATEBY = value; }
        }
        public double DEFAULTFOODTYPE
        {
            get { return _DEFAULTFOODTYPE; }
            set { _DEFAULTFOODTYPE = value; }
        }*/
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public string MILKCODE
        {
            get { return _MILKCODE; }
            set { _MILKCODE = value; }
        }
        public string NAME
        {
            get { return _NAME; }
            set { _NAME = value; }
        }
        public double WARD
        {
            get { return _WARD; }
            set { _WARD = value; }
        }
        public ArrayList MilkCodeList
        {
            get { return _MilkCodeList; }
            set { _MilkCodeList = value; }
        }
        public DataTable MilkCodeTable
        {
            get { return _ItemTable; }
            set { _ItemTable = value; }
        }

    }
}