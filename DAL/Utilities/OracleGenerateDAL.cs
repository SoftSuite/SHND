using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using SHND.DAL.Utilities;
using Message = SHND.Data.Common.Utilities.DataResources;

namespace SHND.DAL.Utilities
{
    public class OracleGenerateDAL
    {
        private string _Database = "";
        private string _DataSource = "";
        private string _UserID = "";
        private string _Password = "";
        private string _TableName = "";
        private string _DatabaseType = "Oracle";
        private string _ErrorTableNotFound = Message.MSGEC014;

        public string DatabaseType
        {
            get { return _DatabaseType; }
        }

        public string Database
        {
            set { _Database = value; }
        }

        public string DataSource
        {
            set { _DataSource = value; }
        }

        public string UserID
        {
            set { _UserID = value; }
        }

        public string Password
        {
            set { _Password = value; }
        }

        public string TableName
        {
            set { _TableName = value.ToUpper(); }
        }

        /// <summary>
        /// Get the connection string for the current application's default configuration.
        /// </summary>
        private string ConnectionString
        {
            get
            {
                return "Data Source=" + _DataSource + ";Persist Security Info=True;User ID=" + _UserID + ";Password=" + _Password + ";Unicode=True";
            }
        }

        public DataTable GetUniqueColumn()
        {
            string sql = "SELECT A.COLUMN_NAME, B.CONSTRAINT_TYPE, C.DATA_TYPE TYPE_NAME ";
            sql += "FROM USER_CONS_COLUMNS A INNER JOIN USER_CONSTRAINTS B ON A.CONSTRAINT_NAME = B.CONSTRAINT_NAME ";
            sql += "INNER JOIN USER_TAB_COLUMNS C ON C.TABLE_NAME = A.TABLE_NAME AND C.COLUMN_NAME = A.COLUMN_NAME ";
            sql += "WHERE A.TABLE_NAME = " + OracleDB.SetString(_TableName) + " AND B.CONSTRAINT_TYPE IN ('P', 'U') AND ";
            sql += "A.CONSTRAINT_NAME IN (SELECT CONSTRAINT_NAME FROM USER_CONS_COLUMNS WHERE TABLE_NAME = " + OracleDB.SetString(_TableName) + " ";
            sql += "GROUP BY CONSTRAINT_NAME HAVING COUNT(*) = 1) ";
            sql += "ORDER BY B.CONSTRAINT_TYPE, A.COLUMN_NAME";
            return OracleDB.ExecuteTable(sql, OracleDB.GetConnection(ConnectionString));
        }

        public DataTable GetTableColumn()
        {
            string sql = "SELECT COLUMN_NAME, DATA_TYPE TYPE_NAME ";
            sql += "FROM USER_TAB_COLUMNS WHERE TABLE_NAME = " + OracleDB.SetString(_TableName) + " ";
            sql += "ORDER BY COLUMN_NAME";
            DataTable dt = OracleDB.ExecuteTable(sql, OracleDB.GetConnection(ConnectionString));
            if (dt.Rows.Count == 0)
                throw new ApplicationException(String.Format(_ErrorTableNotFound, _TableName));
            else
                return dt;
        }

        public bool IsView()
        {
            string sql = "SELECT VIEW_NAME FROM USER_VIEWS WHERE VIEW_NAME = " + OracleDB.SetString(_TableName) + " ";
            return (OracleDB.ExecuteTable(sql, OracleDB.GetConnection(ConnectionString)).Rows.Count > 0);
        }
    }
}
