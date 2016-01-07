using System;

/// <summary>
/// FORMULASERVE Data Class
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
///    Data Object สำหรับข้อมูล FormulaServe
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
namespace SHND.Data.Tables
{
    public class FormulaServeData
    {
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        double _FORMULASET = 0;
        double _LOID = 0;
        string _NAME = "";
        double _REFLOID = 0;
        string _REFTABLE = "";
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);
        double _WEIGHTRAW = 0;
        double _WEIGHTRIPE = 0;

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
        public string NAME
        {
            get { return _NAME; }
            set { _NAME = value; }
        }
        public double REFLOID
        {
            get { return _REFLOID; }
            set { _REFLOID = value; }
        }
        public string REFTABLE
        {
            get { return _REFTABLE; }
            set { _REFTABLE = value; }
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
    }
}