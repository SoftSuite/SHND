using System;

namespace SHND.Data.Tables
{
    /// <summary>
    /// Represents a DISEASECATEGORY data.
    /// [Created by 127.0.0.1 on December,29 2008]
    /// </summary>
    public class DiseaseCategoryData
    {
        string _ABBNAME = "";
        bool _ACTIVE = false;
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        string _DESCRIPTION = "";
        string _IMGSYMBOL = "";
        bool _ISABSTAIN = false;
        bool _ISCALCULATE = false;
        bool _ISINCREASE = false;
        bool _ISLIMIT = false;
        bool _ISLIQUID = false;
        bool _ISNEED = false;
        bool _ISREGULAR = false;
        bool _ISREQUEST = false;
        bool _ISSOFT = false;
        bool _ISMILK = false;
        bool _ISSPECIAL = false;
        bool _ISLIGHT = false;
        bool _ISHIGH = false;
        bool _ISLOW = false;
        bool _ISNON = false;
        double _LOID = 0;
        double _UNIT = 0;
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);

        public string ABBNAME
        {
            get { return _ABBNAME; }
            set { _ABBNAME = value; }
        }
        public bool ACTIVE
        {
            get { return _ACTIVE; }
            set { _ACTIVE = value; }
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
        public string DESCRIPTION
        {
            get { return _DESCRIPTION; }
            set { _DESCRIPTION = value; }
        }
        public string IMGSYMBOL
        {
            get { return _IMGSYMBOL; }
            set { _IMGSYMBOL = value; }
        }
        public bool ISABSTAIN
        {
            get { return _ISABSTAIN; }
            set { _ISABSTAIN = value; }
        }
        public bool ISCALCULATE
        {
            get { return _ISCALCULATE; }
            set { _ISCALCULATE = value; }
        }
        public bool ISINCREASE
        {
            get { return _ISINCREASE; }
            set { _ISINCREASE = value; }
        }
        public bool ISLIMIT
        {
            get { return _ISLIMIT; }
            set { _ISLIMIT = value; }
        }
        public bool ISLIQUID
        {
            get { return _ISLIQUID; }
            set { _ISLIQUID = value; }
        }
        public bool ISNEED
        {
            get { return _ISNEED; }
            set { _ISNEED = value; }
        }
        public bool ISREGULAR
        {
            get { return _ISREGULAR; }
            set { _ISREGULAR = value; }
        }
        public bool ISREQUEST
        {
            get { return _ISREQUEST; }
            set { _ISREQUEST = value; }
        }
        public bool ISSOFT
        {
            get { return _ISSOFT; }
            set { _ISSOFT = value; }
        }
        public bool ISMILK
        {
            get { return _ISMILK; }
            set { _ISMILK = value; }
        }
        public bool ISSPECIAL
        {
            get { return _ISSPECIAL; }
            set { _ISSPECIAL = value; }
        }
        public bool ISLIGHT
        {
            get { return _ISLIGHT; }
            set { _ISLIGHT = value; }
        }
        public bool ISHIGH
        {
            get { return _ISHIGH; }
            set { _ISHIGH = value; }
        }
        public bool ISLOW
        {
            get { return _ISLOW; }
            set { _ISLOW = value; }
        }
        public bool ISNON
        {
            get { return _ISNON; }
            set { _ISNON = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public double UNIT
        {
            get { return _UNIT; }
            set { _UNIT = value; }
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