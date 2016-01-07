using System;
using System.Collections.Generic;
using System.Text;

namespace SHND.Data.Common.Utilities
{
    public class LocalToolbarControl : DataResources
    {
        public static string NewText
        {
            get { return GetCultureText("New", "����"); }
        }
        public static string DeleteText
        {
            get { return GetCultureText("Delete", "ź"); }
        }
        public static string EditText
        {
            get { return GetCultureText("Edit", "���"); }
        }
        public static string SaveText
        {
            get { return GetCultureText("Save", "�ѹ�֡"); }
        }
        public static string CancelText
        {
            get { return GetCultureText("Cancel", "¡��ԡ"); }
        }
        public static string BackText
        {
            get { return GetCultureText("Back", "��Ѻ˹����¡��"); }
        }
        public static string ForwardText
        {
            get { return GetCultureText("Forward", "�觢�����"); }
        }
        public static string BackwardText
        {
            get { return GetCultureText("Backward", "�觤׹"); }
        }
        public static string PrintText
        {
            get { return GetCultureText("Print", "�����"); }
        }

        public static string BrowseText
        {
            get { return GetCultureText("Browse", "����"); }
        }
    }
}
