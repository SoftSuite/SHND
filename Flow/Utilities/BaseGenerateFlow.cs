using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using SHND.Data.Common.Utilities;

namespace SHND.Flow.Utilities
{
    public class BaseGenerateFlow
    {
        private string primaryKeyField = "";
        private string primaryKeyType = "";
        protected bool _isView = false;
        protected string _databaseType = "";
        protected DataTable _columnTable = new DataTable();
        protected DataTable _uniqueColumnTable = new DataTable();

        private string GetFullDate()
        {
            string month = "";
            switch (DateTime.Now.Month)
            {
                case 1:
                    month = "January";
                    break;
                case 2:
                    month = "Febuary";
                    break;
                case 3:
                    month = "March";
                    break;
                case 4:
                    month = "April";
                    break;
                case 5:
                    month = "May";
                    break;
                case 6:
                    month = "June";
                    break;
                case 7:
                    month = "July";
                    break;
                case 8:
                    month = "August";
                    break;
                case 9:
                    month = "September";
                    break;
                case 10:
                    month = "October";
                    break;
                case 11:
                    month = "November";
                    break;
                case 12:
                    month = "December";
                    break;
            }
            return month + "," + DateTime.Now.Day.ToString() + " " + DateTime.Now.Year.ToString();
        }

        protected string GenerateDALCode(GenerateData data)
        {
            string ret = "";
            ret = "using System;";
            ret += "\nusing System.Data;";
            ret += "\nusing System.Data." + _databaseType + "Client;";
            ret += "\nusing DB = " + data.ProjectName + ".DAL.Utilities." + _databaseType + "DB;";
            ret += "\nusing " + data.ProjectName + ".Data.Common.Utilities;";
            //ret += "\nusing " + data.ProjectName + ".Data.Common.Utilities.DataResources;";
            ret += "\n";
            ret += "\nnamespace " + data.NameSpace;
            ret += "\n{";
            ret += "\n    /// <summary>";
            ret += "\n    /// Represents a transaction for " + data.TableName + " " + (_isView ? "view" : "table") + ".";
            ret += "\n    /// [Created by " + data.UserHostName + " on " + GetFullDate() + "]";
            ret += "\n    /// </summary>";
            ret += "\n    public class " + data.ClassName;
            ret += "\n    {";
            ret += "\n";
            ret += "\n        public " + data.ClassName + "()";
            ret += "\n        {";
            ret += "\n        }";
            ret += "\n";
            ret += "\n        #region Constant";
            ret += "\n";
            ret += "\n        /// <summary>" + data.TableName + "</summary>";
            ret += "\n        private const string " + (_isView ? "view" : "table") + "Name = \"" + data.TableName + "\";";
            ret += "\n";
            ret += "\n        #endregion";
            ret += "\n";
            ret += "\n        #region Private Variables";
            ret += "\n";
            if (!_isView) ret += "\n        int _deletedRow = 0;";
            ret += GenerateCommonVariables();
            ret += GenerateFieldVariables();
            ret += "\n";
            ret += "\n        #endregion";
            ret += "\n";
            ret += "\n        #region Public Properties";
            ret += "\n";
            ret += GenerateCommonProperties();
            ret += GenerateFieldProperties();
            ret += "\n";
            ret += "\n        #endregion";
            ret += "\n";
            ret += "\n        #region Clear Data";
            ret += "\n";
            ret += GenerateClearVariables();
            ret += "\n";
            ret += "\n        #endregion";
            ret += "\n";
            ret += GeneratePublicMethods(data.TableName);
            ret += "\n";
            ret += GenerateSQL(data.TableName);
            ret += "\n";
            ret += GeneratePrivateMethods(data.TableName);
            ret += "\n";
            ret += "\n    }";
            ret += "\n}";
            return ret;
        }

        protected string GenerateDataCode(GenerateData data)
        {
            string ret = "using System;";
            ret += "\n";
            ret += "\nnamespace " + data.NameSpace;
            ret += "\n{";
            ret += "\n    /// <summary>";
            //ret += "\n    /// Represents a " + data.TableName + " " + (_isView ? "view" : "table") + " data.";
            ret += "\n    /// Represents a " + data.TableName + " data.";
            ret += "\n    /// [Created by " + data.UserHostName + " on " + GetFullDate() + "]";
            ret += "\n    /// </summary>";
            ret += "\n    public class " + data.ClassName;
            ret += "\n    {";
            ret += GenerateFieldVariables();
            ret += "\n";
            ret += GenerateFieldProperties();
            ret += "\n    }";
            ret += "\n}";
            return ret;
        }

        private string GetStatement(string dataType, string columnName)
        {
            string ret = "";
            switch (dataType.ToUpper())
            {
                case "DATE":
                case "DATETIME":
                case "SMALLDATETIME":
                    ret = "DB.SetDateTime(" + columnName + ")";
                    break;

                case "BIGINT":
                case "DOUBLE":
                case "FLOAT":
                case "INT":
                case "MONEY":
                case "NUMBER":
                case "NUMERIC":
                case "REAL":
                case "SMALLINT":
                    ret = "DB.SetDouble(" + columnName + ")";
                    break;

                case "BIT":
                    ret = "DB.SetBoolean(" + columnName + ")";
                    break;

                case "DECIMAL":
                    ret = "DB.SetDecimal(" + columnName + ")";
                    break;

                default:
                    ret = "DB.SetString(" + columnName + ")";
                    break;
            }
            return ret;
        }

        #region Public Method generate

        private string GetDataType(string dataType)
        {
            string ret = "";
            switch (dataType.ToUpper())
            {
                case "DATE":
                case "DATETIME":
                case "SMALLDATETIME":
                    ret = "DateTime";
                    break;

                case "BIGINT":
                case "DOUBLE":
                case "FLOAT":
                case "INT":
                case "MONEY":
                case "NUMBER":
                case "NUMERIC":
                case "REAL":
                case "SMALLINT":
                    ret = "double";
                    break;

                case "BIT":
                    ret = "bool";
                    break;

                case "DECIMAL":
                    ret = "decimal";
                    break;

                default:
                    ret = "string";
                    break;
            }
            return ret;
        }

        private string GeneratePublicMethods(string tableName)
        {
            string primaryField = "";
            string ret = "\n        #region Public Methods";
            ret += "\n";
            ret += "\n        /// <summary>";
            ret += "\n        /// Executes the select statement with the specified condition and return a System.Data.DataTable.";
            ret += "\n        /// </summary>";
            ret += "\n        /// <param name=\"whereClause\">The condition for execute select statement.</param>";
            ret += "\n        /// <param name=\"orderBy\">The fields for sort data.</param>";
            ret += "\n        /// <param name=\"trans\">The System.Data." + _databaseType + "Client." + _databaseType + "Transaction used by this System.Data." + _databaseType + "Client." + _databaseType + "Command.</param>";
            ret += "\n        /// <returns>The System.Data.DataTable object for specified condition.</returns>";
            ret += "\n        public DataTable GetDataList(string whereClause, string orderBy, " + _databaseType + "Transaction trans)";
            ret += "\n        {";
            ret += "\n            return DB.ExecuteTable(sql_select + (whereClause == \"\" ? \"\" : \"WHERE \" + whereClause + \" \") + (orderBy == \"\" ? \"\" : \"ORDER BY \" + " + (_databaseType == "Oracle" ? "DB.SetSortString(orderBy)" : "orderBy") + "), trans);";
            ret += "\n        }";
            ret += "\n";
            if (!_isView)
            {
                foreach (DataRow dRow in _uniqueColumnTable.Rows)
                {
                    primaryField = dRow["COLUMN_NAME"].ToString();

                    if (dRow["CONSTRAINT_TYPE"].ToString() == "P")
                    {
                        primaryKeyField = primaryField;
                        primaryKeyType = dRow["TYPE_NAME"].ToString();
                        ret += "\n        /// <summary>";
                        ret += "\n        /// Returns an indication whether the current data is inserted into " + tableName + " " + (_isView ? "view" : "table") + " successfully.";
                        ret += "\n        /// </summary>";
                        ret += "\n        /// <param name=\"userID\">The current user.</param>";
                        ret += "\n        /// <param name=\"trans\">The System.Data." + _databaseType + "Client." + _databaseType + "Transaction used by this System.Data." + _databaseType + "Client." + _databaseType + "Command.</param>";
                        ret += "\n        /// <returns>true if insert data successfully; otherwise, false.</returns>";
                        ret += "\n        public bool InsertCurrentData(string userID, " + _databaseType + "Transaction trans)";
                        ret += "\n        {";
                        ret += "\n            _" + primaryField + " = DB.GetNextID(TableName, trans);";
                        ret += "\n            _CREATEBY = userID;";
                        ret += "\n            _CREATEON = DateTime.Now;";
                        ret += "\n            return doInsert(trans);";
                        ret += "\n        }";
                        ret += "\n";
                        ret += "\n        /// <summary>";
                        ret += "\n        /// Returns an indication whether the current data is updated to " + tableName + " " + (_isView ? "view" : "table") + " successfully.";
                        ret += "\n        /// </summary>";
                        ret += "\n        /// <param name=\"userID\">The current user.</param>";
                        ret += "\n        /// <param name=\"trans\">The System.Data." + _databaseType + "Client." + _databaseType + "Transaction used by this System.Data." + _databaseType + "Client." + _databaseType + "Command.</param>";
                        ret += "\n        /// <returns>true if update data successfully; otherwise, false.</returns>";
                        ret += "\n        public bool UpdateCurrentData(string userID, " + _databaseType + "Transaction trans)";
                        ret += "\n        {";
                        ret += "\n            _UPDATEBY = userID;";
                        ret += "\n            _UPDATEON = DateTime.Now;";
                        ret += "\n            return doUpdate(\"" + primaryField + " = \" + " + GetStatement(dRow["TYPE_NAME"].ToString(), "_" + primaryField) + " + \" \", trans);";
                        ret += "\n        }";
                        ret += "\n";
                        ret += "\n        /// <summary>";
                        ret += "\n        /// Returns an indication whether the current data is deleted from " + tableName + " " + (_isView ? "view" : "table") + " successfully.";
                        ret += "\n        /// </summary>";
                        ret += "\n        /// <param name=\"trans\">The System.Data." + _databaseType + "Client." + _databaseType + "Transaction used by this System.Data." + _databaseType + "Client." + _databaseType + "Command.</param>";
                        ret += "\n        /// <returns>true if delete data successfully; otherwise, false.</returns>";
                        ret += "\n        public bool DeleteCurrentData(" + _databaseType + "Transaction trans)";
                        ret += "\n        {";
                        ret += "\n            return doDelete(\"" + primaryField + " = \" + " + GetStatement(dRow["TYPE_NAME"].ToString(), "_" + primaryField) + " + \" \", trans);";
                        ret += "\n        }";
                        ret += "\n";
                    }

                    ret += "\n        /// <summary>";
                    ret += "\n        /// Returns an indication whether the record of " + tableName + " by specified " + primaryField + " key is retrieved successfully.";
                    ret += "\n        /// </summary>";
                    ret += "\n        /// <param name=\"c" + primaryField + "\">The " + primaryField + " key.</param>";
                    ret += "\n        /// <param name=\"trans\">The System.Data." + _databaseType + "Client." + _databaseType + "Transaction used by this System.Data." + _databaseType + "Client." + _databaseType + "Command.</param>";
                    ret += "\n        /// <returns>true if data is retrieved successfully; otherwise, false.</returns>";
                    ret += "\n        public bool GetDataBy" + primaryField + "(" + GetDataType(dRow["TYPE_NAME"].ToString()) + " c" + primaryField + ", " + _databaseType + "Transaction trans)";
                    ret += "\n        {";
                    ret += "\n            return doGetdata(\"" + primaryField + " = \" + " + GetStatement(dRow["TYPE_NAME"].ToString(), "c" + primaryField) + " + \" \", trans);";
                    ret += "\n        }";
                    ret += "\n";
                }
            }
            ret += "\n        #endregion";
            return ret;
        }

        #endregion

        #region Common

        private string GenerateCommonVariables()
        {
            string ret = "";
            ret += "\n        string _error = \"\";";
            ret += "\n        string _information = \"\";";
            ret += "\n        bool _OnDB = false;";
            return ret;
        }

        private string GenerateCommonProperties()
        {
            string ret = "";
            ret += "\n        public string " + (_isView ? "View" : "Table") + "Name";
            ret += "\n        {";
            ret += "\n            get { return " + (_isView ? "view" : "table") + "Name; }";
            ret += "\n        }";
            ret += "\n        public string ErrorMessage";
            ret += "\n        {";
            ret += "\n            get { return _error; }";
            ret += "\n        }";
            ret += "\n        public string InformationMessage";
            ret += "\n        {";
            ret += "\n            get { return _information; }";
            ret += "\n        }";
            ret += "\n        public bool OnDB";
            ret += "\n        {";
            ret += "\n            get { return _OnDB; }";
            ret += "\n            set { _OnDB = value; }";
            ret += "\n        }";
            return ret;
        }

        #endregion

        private string GenerateClearVariables()
        {
            string ret = "";
            ret += "\n        /// <summary>";
            ret += "\n        /// Initialize data.";
            ret += "\n        /// </summary>";
            ret += "\n        private void ClearData()";
            ret += "\n        {";
            foreach (DataRow dRow in _columnTable.Rows)
            {
                switch (dRow["TYPE_NAME"].ToString().ToUpper())
                {
                    case "DATE":
                    case "DATETIME":
                    case "SMALLDATETIME":
                        ret += "\n            _" + dRow["COLUMN_NAME"].ToString() + " = new DateTime(1, 1, 1);";
                        break;

                    case "BIGINT":
                    case "DOUBLE":
                    case "FLOAT":
                    case "INT":
                    case "MONEY":
                    case "NUMBER":
                    case "NUMERIC":
                    case "REAL":
                    case "SMALLINT":
                        ret += "\n            _" + dRow["COLUMN_NAME"].ToString() + " = 0;";
                        break;

                    case "BIT":
                        ret += "\n           _" + dRow["COLUMN_NAME"].ToString() + " = false;";
                        break;

                    case "DECIMAL":
                        ret += "\n            _" + dRow["COLUMN_NAME"].ToString() + " = 0.0;";
                        break;

                    default:
                        ret += "\n            _" + dRow["COLUMN_NAME"].ToString() + " = \"\";";
                        break;
                }
            }
            ret += "\n        }";
            return ret;
        }

        #region Field Variables

        private string GenerateFieldVariables()
        {
            string ret = "";
            foreach (DataRow dRow in _columnTable.Rows)
            {
                switch (dRow["TYPE_NAME"].ToString().ToUpper())
                {
                    case "DATE":
                    case "DATETIME":
                    case "SMALLDATETIME":
                        ret += "\n        DateTime _" + dRow["COLUMN_NAME"].ToString() + " = new DateTime(1, 1, 1);";
                        break;

                    case "BIGINT":
                    case "DOUBLE":
                    case "FLOAT":
                    case "INT":
                    case "MONEY":
                    case "NUMBER":
                    case "NUMERIC":
                    case "REAL":
                    case "SMALLINT":
                        ret += "\n        double _" + dRow["COLUMN_NAME"].ToString() + " = 0;";
                        break;

                    case "BIT":
                        ret += "\n        bool _" + dRow["COLUMN_NAME"].ToString() + " = false;";
                        break;

                    case "DECIMAL":
                        ret += "\n        decimal _" + dRow["COLUMN_NAME"].ToString() + " = 0.0;";
                        break;

                    default:
                        ret += "\n        string _" + dRow["COLUMN_NAME"].ToString() + " = \"\";";
                        break;
                }
            }
            return ret;
        }

        #endregion

        #region Public Field Properties generate

        private string GenerateFieldProperties()
        {
            string ret = "";
            foreach (DataRow dRow in _columnTable.Rows)
            {
                switch (dRow["TYPE_NAME"].ToString().ToUpper())
                {
                    case "DATE":
                    case "DATETIME":
                    case "SMALLDATETIME":
                        ret += "\n        public DateTime " + dRow["COLUMN_NAME"].ToString();
                        break;

                    case "BIGINT":
                    case "DOUBLE":
                    case "FLOAT":
                    case "INT":
                    case "MONEY":
                    case "NUMBER":
                    case "NUMERIC":
                    case "REAL":
                    case "SMALLINT":
                        ret += "\n        public double " + dRow["COLUMN_NAME"].ToString();
                        break;

                    case "BIT":
                        ret += "\n        public bool _" + dRow["COLUMN_NAME"].ToString();
                        break;

                    case "DECIMAL":
                        ret += "\n        public decimal _" + dRow["COLUMN_NAME"].ToString();
                        break;

                    default:
                        ret += "\n        public string " + dRow["COLUMN_NAME"].ToString();
                        break;
                }
                ret += "\n        {";
                ret += "\n            get { return _" + dRow["COLUMN_NAME"].ToString() + "; }";
                ret += "\n            set { _" + dRow["COLUMN_NAME"].ToString() + " = value; }";
                ret += "\n        }";
            }
            return ret;
        }

        #endregion

        #region SQL statement generate

        private string GenerateSQL(string tableName)
        {
            string ret = "";
            string column = "";
            string field = "";
            ret += "\n        #region SQL Statements";
            ret += "\n";
            if (!_isView)
            {
                foreach (DataRow dRow in _columnTable.Rows)
                {
                    if (dRow["COLUMN_NAME"].ToString() != "UPDATEON" && dRow["COLUMN_NAME"].ToString() != "UPDATEBY")
                    {
                        column += (column == "" ? "" : ", ") + dRow["COLUMN_NAME"].ToString();
                        field += (field == "" ? "" : " + \", \";") + "\n                sql += " + GetStatement(dRow["TYPE_NAME"].ToString(), "_" + dRow["COLUMN_NAME"].ToString());
                    }
                }
                field += (field == "" ? "" : " + \" \";");

                ret += "\n        /// <summary>";
                ret += "\n        /// Gets the insert statement for " + tableName + " table.";
                ret += "\n        /// </summary>";
                ret += "\n        private string sql_insert";
                ret += "\n        {";
                ret += "\n            get";
                ret += "\n            {";
                ret += "\n                string sql = \"INSERT INTO \" + " + (_isView ? "view" : "table") + "Name + \"(" + column + ") \";";
                ret += "\n                sql += \"VALUES (\";";
                ret += field;
                ret += "\n                sql += \")\";";
                ret += "\n                return sql;";
                ret += "\n            }";
                ret += "\n        }";
                ret += "\n";

                field = "";
                foreach (DataRow dRow in _columnTable.Rows)
                {
                    if (dRow["COLUMN_NAME"].ToString() != "CREATEON" && dRow["COLUMN_NAME"].ToString() != "CREATEBY" && dRow["COLUMN_NAME"].ToString() != primaryKeyField)
                    {
                        field += (field == "" ? "" : " + \", \";") + "\n                sql += \"" + dRow["COLUMN_NAME"].ToString() + " = \" + " + GetStatement(dRow["TYPE_NAME"].ToString(), "_" + dRow["COLUMN_NAME"].ToString());
                    }
                }
                field += (field == "" ? "" : " + \" \";");
                ret += "\n        /// <summary>";
                ret += "\n        /// Gets the update statement for " + tableName + " table.";
                ret += "\n        /// </summary>";
                ret += "\n        private string sql_update";
                ret += "\n        {";
                ret += "\n            get";
                ret += "\n            {";
                ret += "\n                string sql = \"UPDATE \" + " + (_isView ? "view" : "table") + "Name + \" SET \";";
                ret += field;
                ret += "\n                return sql;";
                ret += "\n            }";
                ret += "\n        }";
                ret += "\n";

                ret += "\n        /// <summary>";
                ret += "\n        /// Gets the delete statement for " + tableName + " table.";
                ret += "\n        /// </summary>";
                ret += "\n        private string sql_delete";
                ret += "\n        {";
                ret += "\n            get";
                ret += "\n            {";
                ret += "\n                string sql = \"DELETE FROM \" + " + (_isView ? "view" : "table") + "Name + \" \";";
                ret += "\n                return sql;";
                ret += "\n            }";
                ret += "\n        }";
                ret += "\n";
            }
            ret += "\n        /// <summary>";
            ret += "\n        /// Gets the select statement for " + tableName + " table.";
            ret += "\n        /// </summary>";
            ret += "\n        private string sql_select";
            ret += "\n        {";
            ret += "\n            get";
            ret += "\n            {";
            ret += "\n                string sql = \"SELECT * FROM \" + " + (_isView ? "view" : "table") + "Name + \" \";";
            ret += "\n                return sql;";
            ret += "\n            }";
            ret += "\n        }";
            ret += "\n";
            ret += "\n        #endregion";
            return ret;
        }

        #endregion

        #region Private Methods generate

        private string GeneratePrivateMethods(string tableName)
        {
            string ret = "";
            ret += "\n        #region Private Methods";
            ret += "\n";
            if (!_isView)
            {
                ret += "\n        /// <summary>";
                ret += "\n        /// Returns an indication whether the current data is inserted into " + tableName + " " + (_isView ? "view" : "table") + " successfully.";
                ret += "\n        /// </summary>";
                ret += "\n        /// <param name=\"trans\">The System.Data." + _databaseType + "Client." + _databaseType + "Transaction used by this System.Data." + _databaseType + "Client." + _databaseType + "Command.</param>";
                ret += "\n        /// <returns>true if insert data successfully; otherwise, false.</returns>";
                ret += "\n        public bool doInsert(" + _databaseType + "Transaction trans)";
                ret += "\n        {";
                ret += "\n            bool ret = true;";
                ret += "\n            int affectedRow = 0;";
                ret += "\n            if (!_OnDB)";
                ret += "\n            {";
                ret += "\n                try";
                ret += "\n                {";
                ret += "\n                    affectedRow = DB.ExecuteNonQuery(sql_insert, trans);";
                ret += "\n                    ret = (affectedRow > 0);";
                ret += "\n                    if (!ret)";
                ret += "\n                        _error = DataResources.MSGEN001;";
                ret += "\n                    else";
                ret += "\n                        _OnDB = true;";
                ret += "\n                    _information = DataResources.MSGIN001;";
                ret += "\n                }";
                ret += "\n                catch (DAL.Utilities.BaseDB.DatabaseException ex)";
                ret += "\n                {";
                ret += "\n                    ret = false;";
                ret += "\n                    _error = ex.Message;";
                ret += "\n                }";
                ret += "\n                catch (Exception ex)";
                ret += "\n                {";
                ret += "\n                    ex.ToString();";
                ret += "\n                    ret = false;";
                ret += "\n                    _error = DataResources.MSGEC101;";
                ret += "\n                }";
                ret += "\n            }";
                ret += "\n            else";
                ret += "\n            {";
                ret += "\n                ret = false;";
                ret += "\n                _error = DataResources.MSGEN002;";
                ret += "\n            }";
                ret += "\n            return ret;";
                ret += "\n        }";
                ret += "\n";
                ret += "\n        /// <summary>";
                ret += "\n        /// Returns an indication whether the current data is updated to " + tableName + " " + (_isView ? "view" : "table") + " successfully.";
                ret += "\n        /// </summary>";
                ret += "\n        /// <param name=\"whText\">The condition specify the updating record(s).</param>";
                ret += "\n        /// <param name=\"trans\">The System.Data." + _databaseType + "Client." + _databaseType + "Transaction used by this System.Data." + _databaseType + "Client." + _databaseType + "Command.</param>";
                ret += "\n        /// <returns>true if update data successfully; otherwise, false.</returns>";
                ret += "\n        public bool doUpdate(string whText, " + _databaseType + "Transaction trans)";
                ret += "\n        {";
                ret += "\n            bool ret = true;";
                ret += "\n            int affectedRow = 0;";
                ret += "\n            if (_OnDB)";
                ret += "\n            {";
                ret += "\n                if (whText.Trim() != \"\")";
                ret += "\n                {";
                ret += "\n                    string tmpWhere = \"WHERE \" + whText;";
                ret += "\n                    try";
                ret += "\n                    {";
                ret += "\n                        affectedRow = DB.ExecuteNonQuery(sql_update + tmpWhere, trans);";
                ret += "\n                        ret = (affectedRow > 0);";
                ret += "\n                        if (!ret) _error = DataResources.MSGEU001;";
                ret += "\n                        _information = DataResources.MSGIU001;";
                ret += "\n                    }";
                ret += "\n                    catch (DAL.Utilities.BaseDB.DatabaseException ex)";
                ret += "\n                    {";
                ret += "\n                        ret = false;";
                ret += "\n                        _error = ex.Message;";
                ret += "\n                    }";
                ret += "\n                    catch (Exception ex)";
                ret += "\n                    {";
                ret += "\n                        ex.ToString();";
                ret += "\n                        ret = false;";
                ret += "\n                        _error = DataResources.MSGEC102;";
                ret += "\n                    }";
                ret += "\n                }";
                ret += "\n                else";
                ret += "\n                {";
                ret += "\n                    ret = false;";
                ret += "\n                    _error = DataResources.MSGEU003;";
                ret += "\n                }";
                ret += "\n            }";
                ret += "\n            else";
                ret += "\n            {";
                ret += "\n                ret = false;";
                ret += "\n                _error = DataResources.MSGEU002;";
                ret += "\n            }";
                ret += "\n            return ret;";
                ret += "\n        }";
                ret += "\n";
                ret += "\n        /// <summary>";
                ret += "\n        /// Returns an indication whether the current data is deleted from " + tableName + " " + (_isView ? "view" : "table") + " successfully.";
                ret += "\n        /// </summary>";
                ret += "\n        /// <param name=\"whText\">The condition specify the deleting record(s).</param>";
                ret += "\n        /// <param name=\"trans\">The System.Data." + _databaseType + "Client." + _databaseType + "Transaction used by this System.Data." + _databaseType + "Client." + _databaseType + "Command.</param>";
                ret += "\n        /// <returns>true if delete data successfully; otherwise, false.</returns>";
                ret += "\n        public bool doDelete(string whText, " + _databaseType + "Transaction trans)";
                ret += "\n        {";
                ret += "\n            bool ret = true;";
                ret += "\n            _deletedRow = 0;";
                ret += "\n            if (whText.Trim() != \"\")";
                ret += "\n            {";
                ret += "\n                string tmpWhere = \"WHERE \" + whText;";
                ret += "\n                try";
                ret += "\n                {";
                ret += "\n                    _deletedRow = DB.ExecuteNonQuery(sql_delete + tmpWhere, trans);";
                ret += "\n                    ret = (_deletedRow > 0);";
                ret += "\n                    if (!ret) _error = DataResources.MSGED001;";
                ret += "\n                    _information = DataResources.MSGID001;";
                ret += "\n                }";
                ret += "\n                catch (DAL.Utilities.BaseDB.DatabaseException ex)";
                ret += "\n                {";
                ret += "\n                    ret = false;";
                ret += "\n                    _error = ex.Message;";
                ret += "\n                }";
                ret += "\n                catch (Exception ex)";
                ret += "\n                {";
                ret += "\n                    ex.ToString();";
                ret += "\n                    ret = false;";
                ret += "\n                    _error = DataResources.MSGEC103;";
                ret += "\n                }";
                ret += "\n            }";
                ret += "\n            else";
                ret += "\n            {";
                ret += "\n                ret = false;";
                ret += "\n                _error = DataResources.MSGED003;";
                ret += "\n            }";
                ret += "\n            return ret;";
                ret += "\n        }";
                ret += "\n";
            }
            ret += "\n        /// <summary>";
            ret += "\n        /// Returns an indication whether the record of " + tableName + " by specified condition is retrieved successfully.";
            ret += "\n        /// </summary>";
            ret += "\n        /// <param name=\"whText\">The condition specify the deleting record(s).</param>";
            ret += "\n        /// <param name=\"trans\">The System.Data." + _databaseType + "Client." + _databaseType + "Transaction used by this System.Data." + _databaseType + "Client." + _databaseType + "Command.</param>";
            ret += "\n        /// <returns>true if data is retrieved successfully; otherwise, false.</returns>";
            ret += "\n        public bool doGetdata(string whText, " + _databaseType + "Transaction trans)";
            ret += "\n        {";
            ret += "\n            bool ret = true;";
            ret += "\n            ClearData();";
            ret += "\n            _OnDB = false;";
            ret += "\n            if (whText.Trim() != \"\")";
            ret += "\n            {";
            ret += "\n                string tmpWhere = \"WHERE \" + whText;";
            ret += "\n                " + _databaseType + "DataReader zRdr = null;";
            ret += "\n                try";
            ret += "\n                {";
            ret += "\n                    zRdr = DB.ExecuteReader(sql_select + tmpWhere, trans);";
            ret += "\n                    if (zRdr.Read())";
            ret += "\n                    {";
            ret += "\n                            _OnDB = true;";
            foreach (DataRow dRow in _columnTable.Rows)
            {
                switch (dRow["TYPE_NAME"].ToString().ToUpper())
                {
                    case "DATE":
                    case "DATETIME":
                    case "SMALLDATETIME":
                        ret += "\n                            if (!Convert.IsDBNull(zRdr[\"" + dRow["COLUMN_NAME"].ToString() + "\"])) _" + dRow["COLUMN_NAME"].ToString() + " = Convert.ToDateTime(zRdr[\"" + dRow["COLUMN_NAME"].ToString() + "\"]);";
                        break;

                    case "BIGINT":
                    case "DOUBLE":
                    case "FLOAT":
                    case "INT":
                    case "MONEY":
                    case "NUMBER":
                    case "NUMERIC":
                    case "REAL":
                    case "SMALLINT":
                        ret += "\n                            if (!Convert.IsDBNull(zRdr[\"" + dRow["COLUMN_NAME"].ToString() + "\"])) _" + dRow["COLUMN_NAME"].ToString() + " = Convert.ToDouble(zRdr[\"" + dRow["COLUMN_NAME"].ToString() + "\"]);";
                        break;

                    case "BIT":
                        ret += "\n                            if (!Convert.IsDBNull(zRdr[\"" + dRow["COLUMN_NAME"].ToString() + "\"])) _" + dRow["COLUMN_NAME"].ToString() + " = Convert.ToBoolean(zRdr[\"" + dRow["COLUMN_NAME"].ToString() + "\"]);";
                        break;

                    case "DECIMAL":
                        ret += "\n                            if (!Convert.IsDBNull(zRdr[\"" + dRow["COLUMN_NAME"].ToString() + "\"])) _" + dRow["COLUMN_NAME"].ToString() + " = Convert.ToDecimal(zRdr[\"" + dRow["COLUMN_NAME"].ToString() + "\"]);";
                        break;

                    default:
                        ret += "\n                            if (!Convert.IsDBNull(zRdr[\"" + dRow["COLUMN_NAME"].ToString() + "\"])) _" + dRow["COLUMN_NAME"].ToString() + " = zRdr[\"" + dRow["COLUMN_NAME"].ToString() + "\"].ToString();";
                        break;
                }
            }
            ret += "\n                    }";
            ret += "\n                    else";
            ret += "\n                    {";
            ret += "\n                        ret = false;";
            ret += "\n                        _error = DataResources.MSGEV002;";
            ret += "\n                    }";
            ret += "\n                    zRdr.Close();";
            ret += "\n                }";
            ret += "\n                catch (Exception ex)";
            ret += "\n                {";
            ret += "\n                    ex.ToString();";
            ret += "\n                    ret = false;";
            ret += "\n                    _error = DataResources.MSGEC104;";
            ret += "\n                    if (zRdr != null && !zRdr.IsClosed)";
            ret += "\n                        zRdr.Close();";
            ret += "\n                }";
            ret += "\n            }";
            ret += "\n            else";
            ret += "\n            {";
            ret += "\n                ret = false;";
            ret += "\n                _error = DataResources.MSGEV001;";
            ret += "\n            }";
            ret += "\n            return ret;";
            ret += "\n        }";
            ret += "\n";
            ret += "\n        #endregion";
            return ret;
        }

        #endregion
    }
}
