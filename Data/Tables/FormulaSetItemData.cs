using System;

/// <summary>
/// FORMULASETITEM Data Class
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
///    Data Object สำหรับข้อมูล FormulaSetItem
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
namespace SHND.Data.Tables
{
    public class FormulaSetItemData
    {
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        double _ENERGY = 0;
        double _FORMULASET = 0;
        double _LOID = 0;
        double _MATERIALMASTER = 0;
        string _PREPARENAME = "";
        double _REFFORMULA = 0;
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);
        double _WEIGHT = 0;
        double _WEIGHTRAW = 0;
        double _WEIGHTRIPE = 0;
        double _WEIGHT1 = 0;
        double _WEIGHTRIPE1 = 0;
        double _WEIGHTRAW1 = 0;
        double _ENERGY1 = 0;

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
        public double ENERGY
        {
            get { return _ENERGY; }
            set { _ENERGY = value; }
        }
        public double FORMULASET
        {
            get { return _FORMULASET; }
            set { _FORMULASET = value; }
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
        public string PREPARENAME
        {
            get { return _PREPARENAME; }
            set { _PREPARENAME = value; }
        }
        public double REFFORMULA
        {
            get { return _REFFORMULA; }
            set { _REFFORMULA = value; }
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
        public double WEIGHT
        {
            get { return _WEIGHT; }
            set { _WEIGHT = value; }
        }
        public double WEIGHTRAW
        {
            get { return _WEIGHTRAW; }
            set { _WEIGHTRAW = value; }
        }
        public double WEIGHTRIPE
        {
            get { return _WEIGHTRIPE; }
            set { _WEIGHTRIPE = value; }
        }
        public double WEIGHT1
        {
            get { return _WEIGHT1; }
            set { _WEIGHT1 = value; }
        }
        public double WEIGHTRIPE1
        {
            get { return _WEIGHTRIPE1; }
            set { _WEIGHTRIPE1 = value; }
        }
        public double WEIGHTRAW1
        {
            get { return _WEIGHTRAW1; }
            set { _WEIGHTRAW1 = value; }
        }
        public double ENERGY1
        {
            get { return _ENERGY1; }
            set { _ENERGY1 = value; }
        }
    }
}