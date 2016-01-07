using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
/// <summary>
/// FoodType Data Class
/// Version 1.0
/// =========================================================================
/// Create by: Pro
/// Create Date: 12 Feb 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Data Object สำหรับข้อมูล Repair
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

namespace SHND.Data.Inventory
{
    public class RepairRequestData
    {
        double _LOID = 0;
        string _CODE = "";
        string _CREATEBY = "";
        DateTime _STOCKOUTDATE = new DateTime(1, 1, 1);
        double _WAREHOUSE = 0;
        double _PRIORITY = 0;
        string _STATUS = "";
        double _DIVISION = 0;
        double _SILOID = 0;
        string _SICODE = "";
        string _SILOTNO = "";
        double _SIQTY = 0;
        double _SIUNIT = 0;
        string _STATUSNAME = "";
        double _FLOOR = 0;
        string _REMARKS = "";
        string _REPAIRBY = "";
        double _MATERIAL = 0;
        string _UNITNAME = "";
        string _MATERIALNAME = "";
        string _REPAIRREMARKS = "";
        string _REPAIRSTATUS = "";
        string _SIBRAND = "";
        private ArrayList _ITEM = new ArrayList();
        ArrayList _ArrRepairItem = new ArrayList();


        public ArrayList ArrRepairItem
        {
            get { return _ArrRepairItem; }
            set { _ArrRepairItem = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
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
        public string SICODE
        {
            get { return _SICODE; }
            set { _SICODE = value; }
        }

        public DateTime STOCKOUTDATE
        {
            get { return _STOCKOUTDATE; }
            set { _STOCKOUTDATE = value; }
        }

        public double WAREHOUSE
        {
            get { return _WAREHOUSE; }
            set { _WAREHOUSE = value; }
        }

        public double PRIORITY
        {
            get { return _PRIORITY; }
            set { _PRIORITY = value; }
        }

        public string STATUS
        {
            get { return _STATUS; }
            set { _STATUS = value; }
        }

        public double DIVISION
        {
            get { return _DIVISION; }
            set { _DIVISION = value; }
        }

        public double SILOID
        {
            get { return _SILOID; }
            set { _SILOID = value; }
        }

        public string SILOTNO
        {
            get { return _SILOTNO; }
            set { _SILOTNO = value; }
        }

        public double SIQTY
        {
            get { return _SIQTY; }
            set { _SIQTY = value; }
        }
        public double SIUNIT
        {
            get { return _SIUNIT; }
            set { _SIUNIT = value; }
        }
        public string STATUSNAME
        {
            get { return _STATUSNAME; }
            set { _STATUSNAME = value; }
        }
        public double FLOOR
        {
            get { return _FLOOR; }
            set { _FLOOR = value; }
        }
        public string REMARKS
        {
            get { return _REMARKS; }
            set { _REMARKS = value; }
        }
        public string REPAIRBY
        {
            get { return _REPAIRBY; }
            set { _REPAIRBY = value; }
        }
        public double MATERIAL
        {
            get { return _MATERIAL; }
            set { _MATERIAL = value; }
        }
        public string UNITNAME
        {
            get { return _UNITNAME; }
            set { _UNITNAME = value; }
        }
        public string MATERIALNAME
        {
            get { return _MATERIALNAME; }
            set { _MATERIALNAME = value; }
        }
        public string REPAIRREMARKS
        {
            get { return _REPAIRREMARKS; }
            set { _REPAIRREMARKS = value; }
        }
        public string SIBRAND
        {
            get { return _SIBRAND; }
            set { _SIBRAND = value; }
        }
        public string REPAIRSTATUS
        {
            get { return _REPAIRSTATUS; }
            set { _REPAIRSTATUS = value; }
        }
        public ArrayList ITEM
        {
            get { return _ITEM; }
            set { _ITEM = value; }
        }
    }
}
