using System;

namespace SHND.Data.Tables
{
    /// <summary>
    /// Represents a SYSCONFIG data.
    /// [Created by 127.0.0.1 on January,19 2009]
    /// </summary>
    public class SysconfigData
    {
        string _CONFIGNAME = "";
        string _CONFIGVALUE = "";
        string _DATATYPE = "";
        string _DESCRIPTION = "";
        string _FORMAT = "";
        double _LOID = 0;

        public string CONFIGNAME
        {
            get { return _CONFIGNAME; }
            set { _CONFIGNAME = value; }
        }
        public string CONFIGVALUE
        {
            get { return _CONFIGVALUE; }
            set { _CONFIGVALUE = value; }
        }
        public string DATATYPE
        {
            get { return _DATATYPE; }
            set { _DATATYPE = value; }
        }
        public string DESCRIPTION
        {
            get { return _DESCRIPTION; }
            set { _DESCRIPTION = value; }
        }
        public string FORMAT
        {
            get { return _FORMAT; }
            set { _FORMAT = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
    }
}