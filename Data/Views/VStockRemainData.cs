using System;

/// <summary>
/// VStockRemainData Data Class
/// Version 1.0
/// =========================================================================
/// Create by: Teang
/// Create Date: 13 Feb 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Data Object สำหรับข้อมูลสินค้าคงคลัง
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
namespace SHND.Data.Views
{
    /// <summary>
    /// Represents a V_STOCKREMAIN data.
    /// [Created by 127.0.0.1 on Febuary,13 2009]
    /// </summary>
    public class VStockRemainData
    {
        string _BRAND = "";
        string _CODE = "";
        DateTime _EXPDATE = new DateTime(1, 1, 1);
        string _GROUPNAME = "";
        double _LOID = 0;
        string _LOTNO = "";
        double _MATERIALGROUP = 0;
        double _MATERIALMASTER = 0;
        string _MATERIALNAME = "";
        DateTime _MFGDATE = new DateTime(1, 1, 1);
        double _QTY = 0;
        DateTime _RECEIVEDATE = new DateTime(1, 1, 1);
        string _SAPCODE = "";
        double _UNIT = 0;
        string _UNITNAME = "";
        double _WAREHOUSE = 0;
        string _WAREHOUSENAME = "";

        public string BRAND
        {
            get { return _BRAND; }
            set { _BRAND = value; }
        }
        public string CODE
        {
            get { return _CODE; }
            set { _CODE = value; }
        }
        public DateTime EXPDATE
        {
            get { return _EXPDATE; }
            set { _EXPDATE = value; }
        }
        public string GROUPNAME
        {
            get { return _GROUPNAME; }
            set { _GROUPNAME = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public string LOTNO
        {
            get { return _LOTNO; }
            set { _LOTNO = value; }
        }
        public double MATERIALGROUP
        {
            get { return _MATERIALGROUP; }
            set { _MATERIALGROUP = value; }
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
        public DateTime MFGDATE
        {
            get { return _MFGDATE; }
            set { _MFGDATE = value; }
        }
        public double QTY
        {
            get { return _QTY; }
            set { _QTY = value; }
        }
        public DateTime RECEIVEDATE
        {
            get { return _RECEIVEDATE; }
            set { _RECEIVEDATE = value; }
        }
        public string SAPCODE
        {
            get { return _SAPCODE; }
            set { _SAPCODE = value; }
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
        public double WAREHOUSE
        {
            get { return _WAREHOUSE; }
            set { _WAREHOUSE = value; }
        }
        public string WAREHOUSENAME
        {
            get { return _WAREHOUSENAME; }
            set { _WAREHOUSENAME = value; }
        }
    }
}