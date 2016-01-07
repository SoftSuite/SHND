using System;

/// <summary>
/// VMaterialMasterUnitData Data Class
/// Version 1.0
/// =========================================================================
/// Create by: Teang
/// Create Date: 19 Feb 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Data Object สำหรับข้อมูลวัสดุอาหาร
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
namespace SHND.Data.Views
{
    /// <summary>
    /// Represents a V_MATERIALMASTER_UNIT data.
    /// [Created by 127.0.0.1 on Febuary,19 2009]
    /// </summary>
    public class VMaterialMasterUnitData
    {
        string _ACTIVE = "";
        double _CLASSLOID = 0;
        string _CLASSNAME = "";
        string _CODE = "";
        double _COST = 0;
        double _GROUPLOID = 0;
        string _GROUPNAME = "";
        string _ISFORMULA = "";
        string _ISMAIN = "";
        string _ISSTOCKIN = "";
        string _ISSTOCKOUT = "";
        double _LOID = 0;
        string _MASTERTYPE = "";
        string _MASTERTYPENAME = "";
        string _MATERIALCODE = "";
        double _MATERIALMASTER = 0;
        string _MATERIALNAME = "";
        double _MULTIPLY = 0;
        double _PRICE = 0;
        string _SAPCODE = "";
        string _SPEC = "";
        double _UNIT = 0;
        string _UNITNAME = "";
        double _WEIGHT = 0;

        public string ACTIVE
        {
            get { return _ACTIVE; }
            set { _ACTIVE = value; }
        }
        public double CLASSLOID
        {
            get { return _CLASSLOID; }
            set { _CLASSLOID = value; }
        }
        public string CLASSNAME
        {
            get { return _CLASSNAME; }
            set { _CLASSNAME = value; }
        }
        public string CODE
        {
            get { return _CODE; }
            set { _CODE = value; }
        }
        public double COST
        {
            get { return _COST; }
            set { _COST = value; }
        }
        public double GROUPLOID
        {
            get { return _GROUPLOID; }
            set { _GROUPLOID = value; }
        }
        public string GROUPNAME
        {
            get { return _GROUPNAME; }
            set { _GROUPNAME = value; }
        }
        public string ISFORMULA
        {
            get { return _ISFORMULA; }
            set { _ISFORMULA = value; }
        }
        public string ISMAIN
        {
            get { return _ISMAIN; }
            set { _ISMAIN = value; }
        }
        public string ISSTOCKIN
        {
            get { return _ISSTOCKIN; }
            set { _ISSTOCKIN = value; }
        }
        public string ISSTOCKOUT
        {
            get { return _ISSTOCKOUT; }
            set { _ISSTOCKOUT = value; }
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
        public string MATERIALCODE
        {
            get { return _MATERIALCODE; }
            set { _MATERIALCODE = value; }
        }
        public double MATERIALMASTER
        {
            get { return _MATERIALMASTER; }
            set { _MATERIALMASTER = value; }
        }
        public string MATERIALNAME
        {
            get { return _MATERIALNAME; }
            set { _MATERIALNAME = value; }
        }
        public double MULTIPLY
        {
            get { return _MULTIPLY; }
            set { _MULTIPLY = value; }
        }
        public double PRICE
        {
            get { return _PRICE; }
            set { _PRICE = value; }
        }
        public string SAPCODE
        {
            get { return _SAPCODE; }
            set { _SAPCODE = value; }
        }
        public string SPEC
        {
            get { return _SPEC; }
            set { _SPEC = value; }
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
        public double WEIGHT
        {
            get { return _WEIGHT; }
            set { _WEIGHT = value; }
        }
    }
}