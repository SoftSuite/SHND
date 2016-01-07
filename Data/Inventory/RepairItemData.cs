using System;
using System.Collections.Generic;
using System.Text;
/// <summary>
/// FoodType Data Class
/// Version 1.0
/// =========================================================================
/// Create by: Pro
/// Create Date: 17 Feb 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Data Object สำหรับข้อมูล RepairItem
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
namespace SHND.Data.Inventory
{
    public class RepairItemData
    {
        private double _LOID = 0;
        private double _STOCKOUTITEM = 0;
        private string _DESCRIPTION = "";
        private DateTime _REPAIRDATE = new DateTime(1, 1, 1);

        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public double STOCKOUTITEM
        {
            get { return _STOCKOUTITEM; }
            set { _STOCKOUTITEM = value; }
        }
        public string DESCRIPTION
        {
            get { return _DESCRIPTION; }
            set { _DESCRIPTION = value; }
        }
        public DateTime REPAIRDATE
        {
            get { return _REPAIRDATE; }
            set { _REPAIRDATE = value; }
        }
    }
}

