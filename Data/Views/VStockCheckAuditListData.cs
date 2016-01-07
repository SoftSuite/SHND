using System;

namespace SHND.Data.Views
{
    /// <summary>
    /// Represents a V_STOCKCHECKAUDIT_LIST data.
    /// [Created by 127.0.0.1 on Febuary,18 2009]
    /// </summary>
    public class VStockCheckAuditListData
    {
        double _COUNTQTY = 0;
        double _IMPROVEQTY = 0;
        string _ISIMPROVE = "";
        string _MMCODE = "";
        double _MMLOID = 0;
        string _MMNAME = "";
        double _SCILOID = 0;
        double _SCLOID = 0;
        string _STATUS = "";
        string _STATUSNAME = "";
        string _STATUSRANK = "";
        double _STOCKQTY = 0;
        string _THNAME = "";

        public double COUNTQTY
        {
            get { return _COUNTQTY; }
            set { _COUNTQTY = value; }
        }
        public double IMPROVEQTY
        {
            get { return _IMPROVEQTY; }
            set { _IMPROVEQTY = value; }
        }
        public string ISIMPROVE
        {
            get { return _ISIMPROVE; }
            set { _ISIMPROVE = value; }
        }
        public string MMCODE
        {
            get { return _MMCODE; }
            set { _MMCODE = value; }
        }
        public double MMLOID
        {
            get { return _MMLOID; }
            set { _MMLOID = value; }
        }
        public string MMNAME
        {
            get { return _MMNAME; }
            set { _MMNAME = value; }
        }
        public double SCILOID
        {
            get { return _SCILOID; }
            set { _SCILOID = value; }
        }
        public double SCLOID
        {
            get { return _SCLOID; }
            set { _SCLOID = value; }
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
        public double STOCKQTY
        {
            get { return _STOCKQTY; }
            set { _STOCKQTY = value; }
        }
        public string THNAME
        {
            get { return _THNAME; }
            set { _THNAME = value; }
        }
    }
}