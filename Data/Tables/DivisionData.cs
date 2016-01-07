using System;

namespace SHND.Data.Tables
{
    /// <summary>
    /// Represents a DIVISION data.
    /// [Created by 127.0.0.1 on January,26 2009]
    /// </summary>
    public class DivisionData
    {
        string _ACTIVE = "";
        string _CODE = "";
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        string _ISDIRECTOR = "";
        string _ISFORMULA = "";
        string _ISNUTRIENT = "";
        string _ISONLINEREQUEST = "";
        string _ISPARTY = "";
        string _ISPLAN = "";
        string _ISSTOCKOUT = "";
        string _ISSUBDIVISION = "";
        string _ISWELFARE = "";
        double _LOID = 0;
        double _MAINDIVISION = 0;
        string _NAME = "";
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);

        public string ACTIVE
        {
            get { return _ACTIVE; }
            set { _ACTIVE = value; }
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
        public string ISDIRECTOR
        {
            get { return _ISDIRECTOR; }
            set { _ISDIRECTOR = value; }
        }
        public string ISFORMULA
        {
            get { return _ISFORMULA; }
            set { _ISFORMULA = value; }
        }
        public string ISNUTRIENT
        {
            get { return _ISNUTRIENT; }
            set { _ISNUTRIENT = value; }
        }
        public string ISONLINEREQUEST
        {
            get { return _ISONLINEREQUEST; }
            set { _ISONLINEREQUEST = value; }
        }
        public string ISPARTY
        {
            get { return _ISPARTY; }
            set { _ISPARTY = value; }
        }
        public string ISPLAN
        {
            get { return _ISPLAN; }
            set { _ISPLAN = value; }
        }
        public string ISSTOCKOUT
        {
            get { return _ISSTOCKOUT; }
            set { _ISSTOCKOUT = value; }
        }
        public string ISSUBDIVISION
        {
            get { return _ISSUBDIVISION; }
            set { _ISSUBDIVISION = value; }
        }
        public string ISWELFARE
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
        public string NAME
        {
            get { return _NAME; }
            set { _NAME = value; }
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
    }
}