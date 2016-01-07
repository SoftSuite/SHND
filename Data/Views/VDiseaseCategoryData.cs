using System;

/// <summary>
/// V_DISEASECATEGORY Data Class
/// Version 1.0
/// =========================================================================
/// Create by: Teang
/// Create Date: 8 Jan 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Data Object สำหรับข้อมูลชนิดของสารอาหารเฉพาะโรค
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
namespace SHND.Data.Views
{
    /// <summary>
    /// Represents a V_DISEASECATEGORY data.
    /// [Created by 127.0.0.1 on January,13 2009]
    /// </summary>
    public class VDiseaseCategoryData
    {
        string _ABBNAME = "";
        string _ACTIVE = "";
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        string _DESCRIPTION = "";
        string _IMGSYMBOL = "";
        string _ISABSTAIN = "";
        string _ISCALCULATE = "";
        string _ISHIGH = "";
        string _ISINCREASE = "";
        string _ISLIGHT = "";
        string _ISLIMIT = "";
        string _ISLIQUID = "";
        string _ISLOW = "";
        string _ISNEED = "";
        string _ISNON = "";
        string _ISREGULAR = "";
        string _ISREQUEST = "";
        string _ISSOFT = "";
        string _ISSPECIAL = "";
        double _LOID = 0;
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);
        double _UNIT = 0;
        string _UNITNAME = "";
        double _QTY = 0;
        string _MEAL = "";
        string _MEALNAME = "";

        public string ABBNAME
        {
            get { return _ABBNAME; }
            set { _ABBNAME = value; }
        }
        public string ACTIVE
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
        public string ISABSTAIN
        {
            get { return _ISABSTAIN; }
            set { _ISABSTAIN = value; }
        }
        public string ISCALCULATE
        {
            get { return _ISCALCULATE; }
            set { _ISCALCULATE = value; }
        }
        public string ISHIGH
        {
            get { return _ISHIGH; }
            set { _ISHIGH = value; }
        }
        public string ISINCREASE
        {
            get { return _ISINCREASE; }
            set { _ISINCREASE = value; }
        }
        public string ISLIGHT
        {
            get { return _ISLIGHT; }
            set { _ISLIGHT = value; }
        }
        public string ISLIMIT
        {
            get { return _ISLIMIT; }
            set { _ISLIMIT = value; }
        }
        public string ISLIQUID
        {
            get { return _ISLIQUID; }
            set { _ISLIQUID = value; }
        }
        public string ISLOW
        {
            get { return _ISLOW; }
            set { _ISLOW = value; }
        }
        public string ISNEED
        {
            get { return _ISNEED; }
            set { _ISNEED = value; }
        }
        public string ISNON
        {
            get { return _ISNON; }
            set { _ISNON = value; }
        }
        public string ISREGULAR
        {
            get { return _ISREGULAR; }
            set { _ISREGULAR = value; }
        }
        public string ISREQUEST
        {
            get { return _ISREQUEST; }
            set { _ISREQUEST = value; }
        }
        public string ISSOFT
        {
            get { return _ISSOFT; }
            set { _ISSOFT = value; }
        }
        public string ISSPECIAL
        {
            get { return _ISSPECIAL; }
            set { _ISSPECIAL = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
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
        public double UNIT
        {
            get { return _UNIT; }
            set { _UNIT = value; }
        }
        public string UNITNAME
        {
            get { return _UNITNAME; }
            set { _UNITNAME = value; }
        }
        public double QTY
        {
            get { return _QTY; }
            set { _QTY = value; }
        }
        public string MEAL
        {
            get { return _MEAL; }
            set { _MEAL = value; }
        }
        public string MEALNAME
        {
            get { return _MEALNAME; }
            set { _MEALNAME = value; }
        }
    }
}