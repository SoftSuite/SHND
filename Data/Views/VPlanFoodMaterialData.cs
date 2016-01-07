using System;

/// <summary>
/// VMaterialListData Data Class
/// Version 1.0
/// =========================================================================
/// Create by: Teang
/// Create Date: 30 Jan 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Data Object สำหรับข้อมูล ประมาณการวัสดุอาหาร
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
namespace SHND.Data.Views
{
    /// <summary>
    /// Represents a V_PLAN_FOOD_MATERIAL data.
    /// [Created by 127.0.0.1 on January,30 2009]
    /// </summary>
    public class VPlanFoodMaterialData
    {
        double _CLASSLOID = 0;
        string _CLASSNAME = "";
        string _ISVAT = "";
        double _LOID = 0;
        double _MATERIALMASTER = 0;
        string _MATERIALNAME = "";
        double _MENUQTY = 0;
        double _PLANMATERIALCLASS = 0;
        double _PLANORDER = 0;
        double _PLANQTY = 0;
        double _PRICE = 0;
        string _SAPCODE = "";
        string _SPEC = "";
        double _TOTALPRICE = 0;
        double _UNIT = 0;
        string _UNITNAME = "";
        double _VAT = 0;

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
        public string ISVAT
        {
            get { return _ISVAT; }
            set { _ISVAT = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
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
        public double MENUQTY
        {
            get { return _MENUQTY; }
            set { _MENUQTY = value; }
        }
        public double PLANMATERIALCLASS
        {
            get { return _PLANMATERIALCLASS; }
            set { _PLANMATERIALCLASS = value; }
        }
        public double PLANORDER
        {
            get { return _PLANORDER; }
            set { _PLANORDER = value; }
        }
        public double PLANQTY
        {
            get { return _PLANQTY; }
            set { _PLANQTY = value; }
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
        public double TOTALPRICE
        {
            get { return _TOTALPRICE; }
            set { _TOTALPRICE = value; }
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
        public double VAT
        {
            get { return _VAT; }
            set { _VAT = value; }
        }
    }
}