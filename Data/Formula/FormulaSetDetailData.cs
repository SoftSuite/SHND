using System;
using System.Collections;
using SHND.Data.Tables;

/// <summary>
/// FORMULASET Data Class
/// Version 1.0
/// =========================================================================
/// Create by: Teang
/// Create Date: 6 Jan 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Data Object สำหรับข้อมูล FormulaSet
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
namespace SHND.Data.Formula
{
    public class FormulaSetDetailData
    {
        bool _ACTIVE = true;
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        double _DISHESTYPE = 0;
        double _ENERGY = 0;
        double _FOODCATEGORY = 0;
        double _FOODCOOKTYPE = 0;
        double _FOODTYPE = 0;
        string _IMGPATH = "";
        bool _ISELEMENT = false;
        bool _ISONEDISH = false;
        bool _ISSPECIFIC = false;
        double _LOID = 0;
        string _NAME = "";
        double _PACKAGE = 0;
        double _PORTION = 0;
        string _PREPARE = "";
        string _RECIPE = "";
        string _SERVEMETHOD = "";
        string _STATUS = "";
        string _STATUSNAME = "";
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);
        double _WEIGHTFORMULA = 0;
        double _WEIGHTPORTION = 0;
        private ArrayList _FormulaDisease = new ArrayList();
        private ArrayList _FormulaServe = new ArrayList();
        private ArrayList _FormulaSetItem = new ArrayList();
        private ArrayList _RefFormulaSetItem = new ArrayList();

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
        public double DISHESTYPE
        {
            get { return _DISHESTYPE; }
            set { _DISHESTYPE = value; }
        }
        public double ENERGY
        {
            get { return _ENERGY; }
            set { _ENERGY = value; }
        }
        public double FOODCATEGORY
        {
            get { return _FOODCATEGORY; }
            set { _FOODCATEGORY = value; }
        }
        public double FOODCOOKTYPE
        {
            get { return _FOODCOOKTYPE; }
            set { _FOODCOOKTYPE = value; }
        }
        public double FOODTYPE
        {
            get { return _FOODTYPE; }
            set { _FOODTYPE = value; }
        }
        public string IMGPATH
        {
            get { return _IMGPATH; }
            set { _IMGPATH = value; }
        }
        public bool ISELEMENT
        {
            get { return _ISELEMENT; }
            set { _ISELEMENT = value; }
        }
        public bool ISONEDISH
        {
            get { return _ISONEDISH; }
            set { _ISONEDISH = value; }
        }
        public bool ISSPECIFIC
        {
            get { return _ISSPECIFIC; }
            set { _ISSPECIFIC = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public string NAME
        {
            get { return _NAME; }
            set { _NAME = value; }
        }
        public double PACKAGE
        {
            get { return _PACKAGE; }
            set { _PACKAGE = value; }
        }
        public double PORTION
        {
            get { return _PORTION; }
            set { _PORTION = value; }
        }
        public string PREPARE
        {
            get { return _PREPARE; }
            set { _PREPARE = value; }
        }
        public string RECIPE
        {
            get { return _RECIPE; }
            set { _RECIPE = value; }
        }
        public string SERVEMETHOD
        {
            get { return _SERVEMETHOD; }
            set { _SERVEMETHOD = value; }
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
        public double WEIGHTFORMULA
        {
            get { return _WEIGHTFORMULA; }
            set { _WEIGHTFORMULA = value; }
        }
        public double WEIGHTPORTION
        {
            get { return _WEIGHTPORTION; }
            set { _WEIGHTPORTION = value; }
        }
        public ArrayList FormulaDisease
        {
            get { return _FormulaDisease; }
            set { _FormulaDisease = value; }
        }
        public ArrayList FormulaServe
        {
            get { return _FormulaServe; }
            set { _FormulaServe = value; }
        }
        public ArrayList FormulaSetItem
        {
            get { return _FormulaSetItem; }
            set { _FormulaSetItem = value; }
        }
        public ArrayList RefFormulaSet
        {
            get { return _RefFormulaSetItem; }
            set { _RefFormulaSetItem = value; }
        }
    }
}