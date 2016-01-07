using System;

namespace SHND.Data.Tables
{
    /// <summary>
    /// Represents a V_DIVISION_SEARCH data.
    /// [Created by 127.0.0.1 on January,26 2009]
    /// </summary>
    public class VDivisionSeacrhData
    {
        bool _ACTIVE = false;
        string _CODE = "";
        bool _DIACTIVE = false;
        bool _ISDIRECTOR = false;
        bool _ISFORMULA = false;
        bool _ISNUTRIENT = false;
        bool _ISONLINEREQUEST = false;
        bool _ISPARTY = false;
        bool _ISPLAN = false;
        bool _ISSTOCKOUT = false;
        bool _ISSUBDIVISION = false;
        bool _ISWELFARE = false;
        double _LOID = 0;
        double _MAINDIVISION = 0;
        string _MAINDIVISIONNAME = "";
        string _NAME = "";

        public bool ACTIVE
        {
            get { return _ACTIVE; }
            set { _ACTIVE = value; }
        }
        public string CODE
        {
            get { return _CODE; }
            set { _CODE = value; }
        }
        public bool DIACTIVE
        {
            get { return _DIACTIVE; }
            set { _DIACTIVE = value; }
        }
        public bool ISDIRECTOR
        {
            get { return _ISDIRECTOR; }
            set { _ISDIRECTOR = value; }
        }
        public bool ISFORMULA
        {
            get { return _ISFORMULA; }
            set { _ISFORMULA = value; }
        }
        public bool ISNUTRIENT
        {
            get { return _ISNUTRIENT; }
            set { _ISNUTRIENT = value; }
        }
        public bool ISONLINEREQUEST
        {
            get { return _ISONLINEREQUEST; }
            set { _ISONLINEREQUEST = value; }
        }
        public bool ISPARTY
        {
            get { return _ISPARTY; }
            set { _ISPARTY = value; }
        }
        public bool ISPLAN
        {
            get { return _ISPLAN; }
            set { _ISPLAN = value; }
        }
        public bool ISSTOCKOUT
        {
            get { return _ISSTOCKOUT; }
            set { _ISSTOCKOUT = value; }
        }
        public bool ISSUBDIVISION
        {
            get { return _ISSUBDIVISION; }
            set { _ISSUBDIVISION = value; }
        }
        public bool ISWELFARE
        {
            get { return _ISWELFARE; }
            set { _ISWELFARE = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public double MAINDIVISION
        {
            get { return _MAINDIVISION; }
            set { _MAINDIVISION = value; }
        }
        public string MAINDIVISIONNAME
        {
            get { return _MAINDIVISIONNAME; }
            set { _MAINDIVISIONNAME = value; }
        }
        public string NAME
        {
            get { return _NAME; }
            set { _NAME = value; }
        }
    }
}