using System;

namespace SHND.Data.Tables
{
    /// <summary>
    /// Represents a V_MATERIALGROUP data.
    /// [Created by 127.0.0.1 on January,23 2009]
    /// </summary>
    public class VMaterialGroupData
    {
        bool _ACTIVE = false;
        string _ACTIVENAME = "";
        string _CODE = "";
        double _LOID = 0;
        double _MATERIALCLASS = 0;
        string _MATERIALCLASSNAME = "";
        string _NAME = "";

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
        public double MATERIALCLASS
        {
            get { return _MATERIALCLASS; }
            set { _MATERIALCLASS = value; }
        }
        public string MATERIALCLASSNAME
        {
            get { return _MATERIALCLASSNAME; }
            set { _MATERIALCLASSNAME = value; }
        }
        public string NAME
        {
            get { return _NAME; }
            set { _NAME = value; }
        }
    }
}