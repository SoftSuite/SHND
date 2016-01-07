using System;

/// <summary>
/// V_DISEASECATEGORY Data Class
/// Version 1.0
/// =========================================================================
/// Create by: Teang
/// Create Date: 12 Jan 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Data Object สำหรับข้อมูลสูตรอาหารสำรับ
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
namespace SHND.Data.Views
{
    /// <summary>
    /// Represents a V_FORMULASET_SEARCH data.
    /// [Created by 127.0.0.1 on January,12 2009]
    /// </summary>
    public class VFormulaSetSearchData
    {
        string _ACTIVENAME = "";
        double _ENERGY = 0;
        double _FOODCATEGORYLOID = 0;
        string _FOODCATEGORYNAME = "";
        double _FOODCOOKTYPELOID = 0;
        string _FOODCOOKTYPENAME = "";
        double _FOODTYPELOID = 0;
        string _FOODTYPENAME = "";
        string _FORMULANAME = "";
        string _ISELEMENT = "";
        string _ISSPECIFIC = "";
        double _LOID = 0;
        double _PORTION = 0;
        string _SPECIALTYPE = "";
        string _STATUS = "";
        string _STATUSNAME = "";
        string _STATUSRANK = "";
        double _WEIGHT = 0;

        public string ACTIVENAME
        {
            get { return _ACTIVENAME; }
            set { _ACTIVENAME = value; }
        }
        public double ENERGY
        {
            get { return _ENERGY; }
            set { _ENERGY = value; }
        }
        public double FOODCATEGORYLOID
        {
            get { return _FOODCATEGORYLOID; }
            set { _FOODCATEGORYLOID = value; }
        }
        public string FOODCATEGORYNAME
        {
            get { return _FOODCATEGORYNAME; }
            set { _FOODCATEGORYNAME = value; }
        }
        public double FOODCOOKTYPELOID
        {
            get { return _FOODCOOKTYPELOID; }
            set { _FOODCOOKTYPELOID = value; }
        }
        public string FOODCOOKTYPENAME
        {
            get { return _FOODCOOKTYPENAME; }
            set { _FOODCOOKTYPENAME = value; }
        }
        public double FOODTYPELOID
        {
            get { return _FOODTYPELOID; }
            set { _FOODTYPELOID = value; }
        }
        public string FOODTYPENAME
        {
            get { return _FOODTYPENAME; }
            set { _FOODTYPENAME = value; }
        }
        public string FORMULANAME
        {
            get { return _FORMULANAME; }
            set { _FORMULANAME = value; }
        }
        public string ISELEMENT
        {
            get { return _ISELEMENT; }
            set { _ISELEMENT = value; }
        }
        public string ISSPECIFIC
        {
            get { return _ISSPECIFIC; }
            set { _ISSPECIFIC = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public double PORTION
        {
            get { return _PORTION; }
            set { _PORTION = value; }
        }
        public string SPECIALTYPE
        {
            get { return _SPECIALTYPE; }
            set { _SPECIALTYPE = value; }
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
        public double WEIGHT
        {
            get { return _WEIGHT; }
            set { _WEIGHT = value; }
        }
    }
}