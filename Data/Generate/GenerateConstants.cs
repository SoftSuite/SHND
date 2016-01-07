using System;
using System.Collections.Generic;
using System.Text;
using SHND.Data.Common.Utilities;

namespace SHND.Data.Generate
{
    public class GenerateConstants
    {
        private string _DataSource = "แหล่งข้อมูล";
        private string _Database = "ฐานข้อมูล";
        private string _UserID = "ชื่อผู้มีสิทธิ์";
        private string _Password = "รหัสผ่าน";
        private string _TableName = "ชื่อตารางหรือวิว";
        private string _ProjectName = "ชื่อโครงการ";
        private string _Class = "ชื่อคลาส";
        private string _DataSourceWaterMarkText = "ระบุแหล่งข้อมูล";
        private string _DatabaseWaterMarkText = "ระบุฐานข้อมูล (สำหรับ Sql server)";
        private string _UserIDWaterMarkText = "ระบุชื่อผู้มีสิทธิ์";
        private string _PasswordWaterMarkText = "ระบุรหัสผ่าน";
        private string _TableNameWaterMarkText = "ระบุชื่อตารางหรือวิว";
        private string _ProjectNameWaterMarkText = "ระบุชื่อโครงการ";
        private string _NameSpaceWaterMarkText = "ระบุชื่อเนมสเปซ";
        private string _ClassWaterMarkText = "ระบุชื่อคลาส";

        public string DataSourceRequire { get { return Message.Error.MSGEI001.Replace("{0}", _DataSource); } }
        public string DatabaseRequire { get { return Message.Error.MSGEI001.Replace("{0}", _Database); } }
        public string UserIDRequire { get { return Message.Error.MSGEI001.Replace("{0}", _UserID); } }
        public string PasswordRequire { get { return Message.Error.MSGEI001.Replace("{0}", _Password); } }
        public string TableRequire { get { return Message.Error.MSGEI001.Replace("{0}", _TableName); } }
        public string ProjectNameRequire { get { return Message.Error.MSGEI001.Replace("{0}", _ProjectName); } }
        public string ClassRequire { get { return Message.Error.MSGEI001.Replace("{0}", _Class); } }

        public string DataSourceWaterMarkText { get { return _DataSourceWaterMarkText; } }
        public string DatabaseWaterMarkText { get { return _DatabaseWaterMarkText; } }
        public string UserIDWaterMarkText { get { return _UserIDWaterMarkText; } }
        public string PasswordWaterMarkText { get { return _PasswordWaterMarkText; } }
        public string TableNameWaterMarkText { get { return _TableNameWaterMarkText; } }
        public string ProjectNameWaterMarkText { get { return _ProjectNameWaterMarkText; } }
        public string NameSpaceWaterMarkText { get { return _NameSpaceWaterMarkText; } }
        public string ClassWaterMarkText { get { return _ClassWaterMarkText; } }
    }
}
