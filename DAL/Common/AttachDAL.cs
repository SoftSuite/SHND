using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DB = SHND.DAL.Utilities.OracleDB;

namespace SHND.DAL.Common
{
    public class AttachDAL
    {
        const string TABLENAME = "ATTACHFILE";

        public DataTable getFileList(string ref1, string ref2, string uniqID)
        {
            string sqlz = " SELECT * FROM ATTACHFILE WHERE REF1 = " + DB.SetString(ref1) + " AND REF2 = " + DB.SetString(ref2) + " AND UNIQID = " + DB.SetString(uniqID) + " ";
            return DB.ExecuteTable(sqlz);
        }

        public int InsertAttachFile(string ref1, string ref2, string uniqID, string filename, int filesize, string desc, string userID)
        {
            string sqlz = " INSERT INTO ATTACHFILE ( REF1, REF2, UNIQID, FILENAME, FILESIZE, DESCRIPTION, CREATEBY) VALUES ( ";
            sqlz += " " + DB.SetString(ref1) + ", ";
            sqlz += " " + DB.SetString(ref2) + ", ";
            sqlz += " " + DB.SetString(uniqID) + ", ";
            sqlz += " " + DB.SetString(filename) + ", ";
            sqlz += " " + filesize.ToString() + ", ";
            sqlz += " " + DB.SetString(desc) + ", ";
            sqlz += " " + DB.SetString(userID) + " ";
            sqlz += " ) ";
            return DB.ExecuteNonQuery(sqlz);
        }

        public int DeleteAttachFile(string ref1, string ref2, string uniqID, string filename)
        {
            string sqlz = " DELETE FROM ATTACHFILE WHERE REF1 = " + DB.SetString(ref1) + " AND REF2 = " + DB.SetString(ref2) + " AND UNIQID = " + DB.SetString(uniqID) + " AND FILENAME = " + DB.SetString(filename) + " ";
            return DB.ExecuteNonQuery(sqlz);
        }

        public int DeleteAttachFile(double ID)
        {
            string sqlz = " DELETE FROM ATTACHFILE WHERE ID = " + DB.SetDouble(ID) + " ";
            return DB.ExecuteNonQuery(sqlz);
        }

        public DataTable getFileDetail(double ID)
        {
            string sqlz = " SELECT * FROM ATTACHFILE WHERE ID = " + DB.SetDouble(ID) + " ";
            return DB.ExecuteTable(sqlz);
        }

        public int CountFile(string ref1, string ref2, string uniqID)
        {
            string sqlz = " SELECT COUNT(ID) FROM ATTACHFILE  WHERE REF1 = " + DB.SetString(ref1) + " AND REF2 = " + DB.SetString(ref2) + " AND UNIQID = " + DB.SetString(uniqID) + " ";
            return Convert.ToInt32(DB.ExecuteScalar(sqlz));
        }
    }
}
