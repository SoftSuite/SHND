using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// MasterMaterialPopup Data Class
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
///    Data Object แทนเงื่อนไขมรการค้นหาข้อมูลวัสดุ (Material Master)
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
namespace SHND.Data.Search
{
    public class MaterialMasterPopupData
    {
        private string _Active = "";
        private string _MasterType = "";
        private double _MaterialClass = 0;
        private double _MaterialGroup = 0;
        private double _Division = 0;
        private string _Code = "";
        private string _Name = "";

        public string Active
        {
            get { return _Active; }
            set { _Active = value; }
        }
        public string MasterType
        {
            get { return _MasterType; }
            set { _MasterType = value; }
        }
        public double MaterialClass
        {
            get { return _MaterialClass; }
            set { _MaterialClass = value; }
        }
        public double MaterialGroup
        {
            get { return _MaterialGroup; }
            set { _MaterialGroup = value; }
        }
        public double Division
        {
            get { return _Division; }
            set { _Division = value; }
        }
        public string Code
        {
            get { return _Code; }
            set { _Code = value; }
        }
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
    }
}
