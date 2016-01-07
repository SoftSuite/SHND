using System;
using System.Collections.Generic;
using System.Text;
using SHND.DAL.Utilities;
using SHND.Data.Common.Utilities;

namespace SHND.Flow.Utilities
{
    public class OracleGenerateFlow : BaseGenerateFlow
    {
        OracleGenerateDAL _dal;

        private OracleGenerateDAL DALObj
        {
            get { if (_dal == null) { _dal = new OracleGenerateDAL(); } return _dal; }
        }

        private void SetData(GenerateData data)
        {
            DALObj.DataSource = data.DataSource;
            DALObj.Database = data.Database;
            DALObj.UserID = data.UserID;
            DALObj.Password = data.Password;
            DALObj.TableName = data.TableName;
            _databaseType = DALObj.DatabaseType;
            _isView = DALObj.IsView();
            _columnTable = DALObj.GetTableColumn();
            _uniqueColumnTable = DALObj.GetUniqueColumn();
        }

        public string GenerateDAL(GenerateData data)
        {
            SetData(data);
            return GenerateDALCode(data);
        }

        public string GenerateData(GenerateData data)
        {
            SetData(data);
            return GenerateDataCode(data);
        }
    }
}
