using System;
using System.Collections;
using SHND.Data.Tables;

namespace SHND.Data.Tables
{
    /// <summary>
    /// Represents a PREPODIVISION data.
    /// [Created by 127.0.0.1 on Febuary,19 2009]
    /// </summary>
    public class PrePODivisionData
    {
        DateTime _BPODATE = new DateTime(1, 1, 1);
        string _CODE = "";
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        double _DIVISION = 0;
        double _LOID = 0;
        double _PLANMATERIALCLASS = 0;
        string _REMARKS = "";
        string _STATUS = "";
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);
        DateTime _USEDATE = new DateTime(1, 1, 1);
        private ArrayList _PrePODivisionItem = new ArrayList();
        string _DIVISIONNAME = "";
        string _STATUSNAME = "";
        double _PLAN = 0;
        string _SUPPLIERNAME = "";
        string _SUPPLIERCODE = "";
        double _MATERIALCLASS = 0;
        private ArrayList _PrePODuedate = new ArrayList();
        string _CNAME = "";
        string _ADDRESS = "";
        string _TEL = "";
        string _FAX = "";
        double _POVAT = 0;
        double _PONOVAT = 0;
        string _CONTACTCODE = "";

        public DateTime BPODATE
        {
            get { return _BPODATE; }
            set { _BPODATE = value; }
        }
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
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public double PLANMATERIALCLASS
        {
            get { return _PLANMATERIALCLASS; }
            set { _PLANMATERIALCLASS = value; }
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
        public ArrayList PrePODivisionItem
        {
            get { return _PrePODivisionItem; }
            set { _PrePODivisionItem = value; }
        }
        public string STATUSNAME
        {
            get { return _STATUSNAME; }
            set { _STATUSNAME = value; }
        }
        public string DIVISIONNAME
        {
            get { return _DIVISIONNAME; }
            set { _DIVISIONNAME = value; }
        }
        public double PLAN
        {
            get { return _PLAN; }
            set { _PLAN = value; }
        }
        public string SUPPLIERNAME
        {
            get { return _SUPPLIERNAME; }
            set { _SUPPLIERNAME = value; }
        }
        public string SUPPLIERCODE
        {
            get { return _SUPPLIERCODE; }
            set { _SUPPLIERCODE = value; }
        }
        public ArrayList PrePODuedate
        {
            get { return _PrePODuedate; }
            set { _PrePODuedate = value; }
        }
        public double MATERIALCLASS
        {
            get { return _MATERIALCLASS; }
            set { _MATERIALCLASS = value; }
        }
        public string CNAME
        {
            get { return _CNAME; }
            set { _CNAME = value; }
        }
        public string ADDRESS
        {
            get { return _ADDRESS; }
            set { _ADDRESS = value; }
        }
        public string TEL
        {
            get { return _TEL; }
            set { _TEL = value; }
        }
        public string FAX
        {
            get { return _FAX; }
            set { _FAX = value; }
        }
        public double POVAT
        {
            get { return _POVAT; }
            set { _POVAT = value; }
        }
        public double PONOVAT
        {
            get { return _PONOVAT; }
            set { _PONOVAT = value; }
        }
        public string CONTACTCODE
        {
            get { return _CONTACTCODE; }
            set { _CONTACTCODE = value; }
        }
        
    }
}