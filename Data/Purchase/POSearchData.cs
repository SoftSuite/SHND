using System;
using System.Collections.Generic;
using System.Text;

namespace SHND.Data.Purchase
{
    public class POSearchData
    {
        string _POCODEFROM = "";
        string _POCODETO = "";
        string _PREPOCODEFROM = "";
        string _PREPOCODETO = "";
        DateTime _PODATEFROM = new DateTime(1, 1, 1);
        DateTime _PODATETO = new DateTime(1, 1, 1);
        DateTime _PREPODATEFROM = new DateTime(1, 1, 1);
        DateTime _PREPODATETO = new DateTime(1, 1, 1);
        double _MATERIALCLASS = 0;
        string _CONTRACTCODE = "";
        string _SUPPLIERNAME = "";
        string _STATUSFROM = "";
        string _STATUSTO = "";

        public string POCODEFROM
        {
            get { return _POCODEFROM; }
            set { _POCODEFROM = value; }
        }
        public string POCODETO
        {
            get { return _POCODETO; }
            set { _POCODETO = value; }
        }
        public string PREPOCODEFROM
        {
            get { return _PREPOCODEFROM; }
            set { _PREPOCODEFROM = value; }
        }
        public string PREPOCODETO
        {
            get { return _PREPOCODETO; }
            set { _PREPOCODETO = value; }
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
        public DateTime PREPODATEFROM
        {
            get { return _PREPODATEFROM; }
            set { _PREPODATEFROM = value; }
        }
        public DateTime PREPODATETO
        {
            get { return _PREPODATETO; }
            set { _PREPODATETO = value; }
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
