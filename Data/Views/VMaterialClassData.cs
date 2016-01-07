using System;

namespace SHND.Data.Tables
{
    /// <summary>
    /// Represents a V_MATERIALCLASS data.
    /// [Created by 127.0.0.1 on January,22 2009]
    /// </summary>
    public class VMaterialClassData
    {
        bool _ACTIVE = true;
        string _ACTIVENAME = "";
        string _CODE = "";
        double _LOID = 0;
        string _MASTERTYPE = "";
        string _MASTERTYPENAME = "";
        string _NAME = "";
        string _STOCKINTYPE = "";
        string _STOCKINTYPENAME = "";

        public bool ACTIVE
        {
            get { return _ACTIVE; }
            set { _ACTIVE = value; }
        }
        public string ACTIVENAME
        {
            get { return _ACTIVENAME; }
            set { _ACTIVENAME = value; }
        }
        public string CODE
        {
            get { return _CODE; }
            set { _CODE = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public string MASTERTYPE
        {
            get { return _MASTERTYPE; }
            set { _MASTERTYPE = value; }
        }
        public string MASTERTYPENAME
        {
            get { return _MASTERTYPENAME; }
            set { _MASTERTYPENAME = value; }
        }
        public string NAME
        {
            get { return _NAME; }
            set { _NAME = value; }
        }
        public string STOCKINTYPE
        {
            get { return _STOCKINTYPE; }
            set { _STOCKINTYPE = value; }
        }
        public string STOCKINTYPENAME
        {
            get { return _STOCKINTYPENAME; }
            set { _STOCKINTYPENAME = value; }
        }
    }
}