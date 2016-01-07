using System;
using System.Collections.Generic;
using System.Text;

namespace SHND.Data.Common.Utilities
{
    public class LocalToolbarControl : DataResources
    {
        public static string NewText
        {
            get { return GetCultureText("New", "เพิ่ม"); }
        }
        public static string DeleteText
        {
            get { return GetCultureText("Delete", "ลบ"); }
        }
        public static string EditText
        {
            get { return GetCultureText("Edit", "แก้ไข"); }
        }
        public static string SaveText
        {
            get { return GetCultureText("Save", "บันทึก"); }
        }
        public static string CancelText
        {
            get { return GetCultureText("Cancel", "ยกเลิก"); }
        }
        public static string BackText
        {
            get { return GetCultureText("Back", "กลับหน้ารายการ"); }
        }
        public static string ForwardText
        {
            get { return GetCultureText("Forward", "ส่งข้อมูล"); }
        }
        public static string BackwardText
        {
            get { return GetCultureText("Backward", "ส่งคืน"); }
        }
        public static string PrintText
        {
            get { return GetCultureText("Print", "พิมพ์"); }
        }

        public static string BrowseText
        {
            get { return GetCultureText("Browse", "ค้นหา"); }
        }
    }
}
