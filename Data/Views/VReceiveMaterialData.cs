using System;
using System.Collections.Generic;
using System.Text;

namespace SHND.Data.Views
{
    public class VReceiveMaterialData
    {
        string _CLASSNAME = "";
        string _GROUPNAME = "";
        string _ISVAT = "";
        double _MATERIALCLASS = 0;
        string _MATERIALCODE = "";
        string _SAPCODE = "";
        double _MATERIALGROUP = 0;
        double _MATERIALMASTER = 0;
        string _MATERIALNAME = "";
        double _PLANORDER = 0;
        double _PRICE = 0;
        double _NETPRICE = 0;
        double _UNITLOID = 0;
        string _UNITNAME = "";
        double _ORDERQTY = 0;
        string _REMARK = "";
        string _CODE = "";
        string _SPEC = "";
        double _RECEIVEQTY = 0;
        double _DUEQTY = 0;
        double _PLANREMAINQTY = 0;
        double _PREPODUEDATE = 0;
        DateTime _DUEDATE = new DateTime(1, 1, 1);
        DateTime _USEDATE = new DateTime(1, 1, 1);

        public string CLASSNAME
        {
            get { return _CLASSNAME; }
            set { _CLASSNAME = value; }
        }
        public string GROUPNAME
        {
            get { return _GROUPNAME; }
            set { _GROUPNAME = value; }
        }
        public string ISVAT
        {
            get { return _ISVAT; }
            set { _ISVAT = value; }
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
        public string SAPCODE
        {
            get { return _SAPCODE; }
            set { _SAPCODE = value; }
        }
        public double MATERIALGROUP
        {
            get { return _MATERIALGROUP; }
            set { _MATERIALGROUP = value; }
        }
        public double MATERIALMASTER
        {
            get { return _MATERIALMASTER; }
            set { _MATERIALMASTER = value; }
        }
        public string MATERIALNAME
        {
            get { return _MATERIALNAME; }
            set { _MATERIALNAME = value; }
        }
        public double PLANORDER
        {
            get { return _PLANORDER; }
            set { _PLANORDER = value; }
        }
        public double PRICE
        {
            get { return _PRICE; }
            set { _PRICE = value; }
        }
        public double NETPRICE
        {
            get { return _NETPRICE; }
            set { _NETPRICE = value; }
        }
        public double UNITLOID
        {
            get { return _UNITLOID; }
            set { _UNITLOID = value; }
        }
        public string UNITNAME
        {
            get { return _UNITNAME; }
            set { _UNITNAME = value; }
        }
        public double ORDERQTY
        {
            get { return _ORDERQTY; }
            set { _ORDERQTY = value; }
        }
        public string REMARK
        {
            get { return _REMARK; }
            set { _REMARK = value; }
        }
        public string CODE
        {
            get { return _CODE; }
            set { _CODE = value; }
        }
        public string SPEC
        {
            get { return _SPEC; }
            set { _SPEC = value; }
        }
        public double RECEIVEQTY
        {
            get { return _RECEIVEQTY; }
            set { _RECEIVEQTY = value; }
        }
        public double DUEQTY
        {
            get { return _DUEQTY; }
            set { _DUEQTY = value; }
        }
        public double PLANREMAINQTY
        {
            get { return _PLANREMAINQTY; }
            set { _PLANREMAINQTY = value; }
        }
        public double PREPODUEDATE
        {
            get { return _PREPODUEDATE; }
            set { _PREPODUEDATE = value; }
        }
        public DateTime DUEDATE
        {
            get { return _DUEDATE; }
            set { _DUEDATE = value; }
        }
        public DateTime USEDATE
        {
            get { return _USEDATE; }
            set { _USEDATE = value; }
        }
    }
}
