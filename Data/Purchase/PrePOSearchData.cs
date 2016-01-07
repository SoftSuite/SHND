using System;
using System.Collections;
using System.Data;

namespace SHND.Data.Purchase
{
    public class PrePOSearchData
    {
        string _CODEFROM = "";
        string _CODETO = "";
        DateTime _PODATEFROM = new DateTime(1, 1, 1);
        DateTime _PODATETO = new DateTime(1, 1, 1);
        DateTime _USEDATEFROM = new DateTime(1, 1, 1);
        DateTime _USEDATETO = new DateTime(1, 1, 1);
        double _MATERIALCLASS = 0;
        string _CONTRACTCODE = "";
        string _SUPPLIERNAME = "";
        double _PLAN = 0;
        string _STATUSFROM = "";
        string _STATUSTO = "";
        double _DIVISION = 0;

        public string CODEFROM
        {
            get { return _CODEFROM; }
            set { _CODEFROM = value; }
        }
        public string CODETO
        {
            get { return _CODETO; }
            set { _CODETO = value; }
        }
        public DateTime PODATEFROM
        {
            get { return _PODATEFROM; }
            set { _PODATEFROM = value; }
        }
        public DateTime PODATETO
        {
            get { return _PODATETO; }
            set { _PODATETO = value; }
        }
        public DateTime USEDATEFROM
        {
            get { return _USEDATEFROM; }
            set { _USEDATEFROM = value; }
        }
        public DateTime USEDATETO
        {
            get { return _USEDATETO; }
            set { _USEDATETO = value; }
        }
        public double MATERIALCLASS
        {
            get { return _MATERIALCLASS; }
            set { _MATERIALCLASS = value; }
        }
        public string CONTRACTCODE
        {
            get { return _CONTRACTCODE; }
            set { _CONTRACTCODE = value; }
        }
        public string SUPPLIERNAME
        {
            get { return _SUPPLIERNAME; }
            set { _SUPPLIERNAME = value; }
        }
        public double PLAN
        {
            get { return _PLAN; }
            set { _PLAN = value; }
        }
        public double DIVISION
        {
            get { return _DIVISION; }
            set { _DIVISION = value; }
        }
        public string STATUSFROM
        {
            get { return _STATUSFROM; }
            set { _STATUSFROM = value; }
        }
        public string STATUSTO
        {
            get { return _STATUSTO; }
            set { _STATUSTO = value; }
        }
    }
}
