using System;
using SHND.Data.Tables;
using System.Collections;

namespace SHND.Data.Views
{
    /// <summary>
    /// Represents a V_PO data.
    /// [Created by 127.0.0.1 on April,2 2009]
    /// </summary>
    public class VPOData
    {
        string _ADDRESS = "";
        DateTime _BPODATE = new DateTime(1, 1, 1);
        string _CLASSNAME = "";
        string _CNAME = "";
        string _CODE = "";
        string _FAX = "";
        string _ISVAT = "";
        double _LOID = 0;
        double _MATERIALCLASS = 0;
        DateTime _PODATE = new DateTime(1, 1, 1);
        double _PREPO = 0;
        double _PLANORDER = 0;
        string _PREPOCODE = "";
        string _RECEIVECODE = "";
        string _REFPOCODE = "";
        string _REMARKS = "";
        string _STATUS = "";
        string _STATUSNAME = "";
        string _STATUSRANK = "";
        double _SUPPLIER = 0;
        string _SUPPLIERCODE = "";
        string _SUPPLIERNAME = "";
        string _TEL = "";
        DateTime _USEDATE = new DateTime(1, 1, 1);
        double _VATRATE = 0;
        private ArrayList _POItem = new ArrayList();
        string _CONTRACTCODE = "";

        public string ADDRESS
        {
            get { return _ADDRESS; }
            set { _ADDRESS = value; }
        }
        public DateTime BPODATE
        {
            get { return _BPODATE; }
            set { _BPODATE = value; }
        }
        public string CLASSNAME
        {
            get { return _CLASSNAME; }
            set { _CLASSNAME = value; }
        }
        public string CNAME
        {
            get { return _CNAME; }
            set { _CNAME = value; }
        }
        public string CODE
        {
            get { return _CODE; }
            set { _CODE = value; }
        }
        public string FAX
        {
            get { return _FAX; }
            set { _FAX = value; }
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
        public double MATERIALCLASS
        {
            get { return _MATERIALCLASS; }
            set { _MATERIALCLASS = value; }
        }
        public DateTime PODATE
        {
            get { return _PODATE; }
            set { _PODATE = value; }
        }
        public double PREPO
        {
            get { return _PREPO; }
            set { _PREPO = value; }
        }
        public double PLANORDER
        {
            get { return _PLANORDER; }
            set { _PLANORDER = value; }
        }
        public string PREPOCODE
        {
            get { return _PREPOCODE; }
            set { _PREPOCODE = value; }
        }
        public string RECEIVECODE
        {
            get { return _RECEIVECODE; }
            set { _RECEIVECODE = value; }
        }
        public string REFPOCODE
        {
            get { return _REFPOCODE; }
            set { _REFPOCODE = value; }
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
        public double SUPPLIER
        {
            get { return _SUPPLIER; }
            set { _SUPPLIER = value; }
        }
        public string SUPPLIERCODE
        {
            get { return _SUPPLIERCODE; }
            set { _SUPPLIERCODE = value; }
        }
        public string SUPPLIERNAME
        {
            get { return _SUPPLIERNAME; }
            set { _SUPPLIERNAME = value; }
        }
        public string TEL
        {
            get { return _TEL; }
            set { _TEL = value; }
        }
        public DateTime USEDATE
        {
            get { return _USEDATE; }
            set { _USEDATE = value; }
        }
        public double VATRATE
        {
            get { return _VATRATE; }
            set { _VATRATE = value; }
        }
        public ArrayList POItem
        {
            get { return _POItem; }
            set { _POItem = value; }
        }
        public string CONTRACTCODE
        {
            get { return _CONTRACTCODE; }
            set { _CONTRACTCODE = value; }
        }
    }
}