using System;
using System.Collections;
using System.Data;

namespace SHND.Data.Purchase
{
    public class ReceiveSearchData
    {
        DateTime _RECEIVEDATEFROM = new DateTime(1, 1, 1);
        DateTime _RECEIVEDATETO = new DateTime(1, 1, 1);
        double _MATERIALCLASS = 0;
        string _CONTRACTCODE = "";
        string _SUPPLIERNAME = "";
        double _PLAN = 0;
        string _STATUSFROM = "";
        string _STATUSTO = "";

        public DateTime RECEIVEDATEFROM
        {
            get { return _RECEIVEDATEFROM; }
            set { _RECEIVEDATEFROM = value; }
        }
        public DateTime RECEIVEDATETO
        {
            get { return _RECEIVEDATETO; }
            set { _RECEIVEDATETO = value; }
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
