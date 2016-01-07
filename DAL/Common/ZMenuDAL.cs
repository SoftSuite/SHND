using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common;

namespace SHND.DAL.Common
{
    public class ZMenuDAL
    {

        public DataTable GetAllMenu()
        {
            string sqlz = @"SELECT M.*, MG.GNAME, MS.NAME as SYSTEMNAME
FROM ZMENU M
INNER JOIN ZMENUGROUP MG ON M.MENUGROUP = MG.GID
INNER JOIN ZSYSTEM MS ON M.ZSYSTEM = MS.LOID
WHERE M.ENABLED = 'Y'
ORDER BY MS.SEQUENCE, M.MENUGROUP, M.SEQUENCE";

            return DB.ExecuteTable(sqlz);
        }

        public DataTable GetMenuByUserLOID(double LOID)
        {
            string sqlz = @"SELECT M.*, MG.GNAME, MS.NAME as SYSTEMNAME
FROM ZMENU M
INNER JOIN ZMENUGROUP MG ON M.MENUGROUP = MG.GID
INNER JOIN ZSYSTEM MS ON M.ZSYSTEM = MS.LOID
WHERE M.ENABLED = 'Y'
AND M.LOID IN ( 
    SELECT ZMENU FROM ZROLEASSIGN WHERE ZROLE IN (
            SELECT ZROLE.LOID FROM ZROLE WHERE OFFICER = " + DB.SetDouble(LOID) + @"
            OR LOID IN (
                    SELECT PARENT FROM ZROLEREF WHERE ZROLE = (SELECT LOID FROM ZROLE WHERE OFFICER = " + DB.SetDouble(LOID) + @")
            )
    )
)
ORDER BY MS.SEQUENCE, M.MENUGROUP, M.SEQUENCE";
             return DB.ExecuteTable(sqlz);
       }

        public MenuData GetMenuDataByFileName(string fileName)
        {
            MenuData ret = new MenuData();
            string sqlz = @" SELECT * FROM ZMENU WHERE LINK LIKE '%" + fileName   + "' ";
            DataTable zDt = DB.ExecuteTable(sqlz);
            if (zDt.Rows.Count > 0)
            {
                DataRow dr = zDt.Rows[0];
                ret.SystemID = dr["ZSYSTEM"].ToString();
                //ret.SystemName = dr["SYSTEMNAME"].ToString();
                ret.GroupID = dr["MENUGROUP"].ToString();
                //ret.GroupName = dr["GNAME"].ToString();
                ret.MenuID = dr["LOID"].ToString();
                ret.MenuName = dr["MENUNAME"].ToString();
                ret.MenuDesc = dr["DESCRIPTION"].ToString();
            }
            return ret;
        }

        
    }
}
