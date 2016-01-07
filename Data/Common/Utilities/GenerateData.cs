using System;
using System.Collections.Generic;
using System.Text;

namespace SHND.Data.Common.Utilities
{
    public class GenerateData
    {
        private string _DataSource = "";
        private string _Database = "";
        private string _UserID = "";
        private string _Password = "";
        private string _TableName = "";
        private string _NameSpace = "";
        private string _ClassName = "";
        private string _UserHostName = "";
        private string _ProjectName = "";

        public string DataSource
        {
            get { return _DataSource; }
            set { _DataSource = value; }
        }
        public string Database
        {
            get { return _Database; }
            set { _Database = value; }
        }
        public string UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
        public string TableName
        {
            get { return _TableName.ToUpper(); }
            set { _TableName = value; }
        }
        public string NameSpace
        {
            get { return _NameSpace; }
            set { _NameSpace = value; }
        }
        public string ClassName
        {
            get { return _ClassName; }
            set { _ClassName = value; }
        }
        public string UserHostName
        {
            get { return _UserHostName; }
            set { _UserHostName = value; }
        }
        public string ProjectName
        {
            get { return _ProjectName; }
            set { _ProjectName = value; }
        }
    }
}
