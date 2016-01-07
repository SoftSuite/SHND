using System;
using System.Collections.Generic;
using System.Text;
using SHND.Data.Common.Utilities;

namespace SHND.Data.Generate
{
    public class GenerateConstants
    {
        private string _DataSource = "���觢�����";
        private string _Database = "�ҹ������";
        private string _UserID = "���ͼ�����Է���";
        private string _Password = "���ʼ�ҹ";
        private string _TableName = "���͵��ҧ�������";
        private string _ProjectName = "�����ç���";
        private string _Class = "���ͤ���";
        private string _DataSourceWaterMarkText = "�к����觢�����";
        private string _DatabaseWaterMarkText = "�кذҹ������ (����Ѻ Sql server)";
        private string _UserIDWaterMarkText = "�кت��ͼ�����Է���";
        private string _PasswordWaterMarkText = "�к����ʼ�ҹ";
        private string _TableNameWaterMarkText = "�кت��͵��ҧ�������";
        private string _ProjectNameWaterMarkText = "�кت����ç���";
        private string _NameSpaceWaterMarkText = "�кت������໫";
        private string _ClassWaterMarkText = "�кت��ͤ���";

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
