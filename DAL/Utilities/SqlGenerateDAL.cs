using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using SHND.DAL.Utilities;
using Message = SHND.Data.Common.Utilities.DataResources;

namespace SHND.DAL.Utilities
{
    public class SqlGenerateDAL
    {
        private string _DataSource = "";
        private string _Database = "";
        private string _UserID = "";
        private string _Password = "";
        private string _TableName = "";
        private string _DatabaseType = "Sql";
        private string _ErrorTableNotFound = Message.MSGEC014;

        public SqlGenerateDAL()
        {
        }

        public string DatabaseType
        {
            get { return _DatabaseType; }
        }

        public string DataSource
        {
            set { _DataSource = value; }
        }

        public string Database
        {
            set { _Database = value; }
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
                return "Data Source=" + _DataSource + ";Initial Catalog=" + _Database + ";Persist Security Info=True;User ID=" + _UserID + ";password=" + _Password;
            }
        }

        public DataTable GetUniqueColumn()
        {
            DataTable uniqueTable = new DataTable();
            uniqueTable.Columns.Add("COLUMN_NAME");
            uniqueTable.Columns.Add("CONSTRAINT_TYPE");
            uniqueTable.Columns.Add("TYPE_NAME");
            try
            {
                using (SqlConnection conn = SqlDB.GetConnection(ConnectionString))
                {
                    DataTable tmpTable = SqlDB.ExecuteTable("EXEC SP_PKEYS " + SqlDB.SetString(_TableName), conn);
                    foreach (DataRow dRow in tmpTable.Rows)
                    {
                        DataRow newRow = uniqueTable.NewRow();
                        newRow["COLUMN_NAME"] = dRow["COLUMN_NAME"].ToString();
                        newRow["CONSTRAINT_TYPE"] = "P";
                        DataTable typeTable = SqlDB.ExecuteTable("EXEC SP_COLUMNS " + SqlDB.SetString(_TableName), conn);
                        foreach (DataRow tRow in typeTable.Rows)
                        {
                            if (tRow["COLUMN_NAME"].ToString() == dRow["COLUMN_NAME"].ToString()) newRow["TYPE_NAME"] = tRow["TYPE_NAME"].ToString();
                        }
                        uniqueTable.Rows.Add(newRow);
                    }

                    conn.Close();
                    conn.Dispose();
                }
            }
            catch
            {
            }
            return uniqueTable;
        }

        public DataTable GetTableColumn()
        {
            string sql = "EXEC SP_COLUMNS " + SqlDB.SetString(_TableName);
            DataTable dt = SqlDB.ExecuteTable(sql, SqlDB.GetConnection(ConnectionString));
            dt.DefaultView.Sort = "COLUMN_NAME";
            if (dt.Rows.Count == 0)
                throw new ApplicationException(String.Format(_ErrorTableNotFound, _TableName));
            else
                return dt;
        }

        public bool IsView()
        {
            DataTable dt = SqlDB.ExecuteTable("EXEC sp_tables \'" + _TableName + "\' ", SqlDB.GetConnection(ConnectionString));
            if (dt.Rows.Count == 0)
                return false;
            else
                return dt.Rows[0]["TABLE_TYPE"].ToString() == "VIEW";
        }
    }
}
