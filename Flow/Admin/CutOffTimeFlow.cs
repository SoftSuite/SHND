using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using zTran = SHND.DAL.Utilities.OracleTransactionDB;
using SHND.DAL.Admin;
using SHND.Data.Admin;

namespace SHND.Flow.Admin
{
    public class CutOffTimeFlow
    {
        public CutOffTimeData GetDataByUseFor(string UseFor)
        {
            CutOffTimeData ftData = new CutOffTimeData();
            CutOffTimeDAL ftDAL = new CutOffTimeDAL();

            ftDAL.GetDataByUSEFOR("F", null);
            ftData.LOID = ftDAL.LOID;
            ftData.BREAKFASTTIME = ftDAL.BREAKFASTTIME;
            ftData.LUNCHTIME = ftDAL.LUNCHTIME;
            ftData.DINNERTIME = ftDAL.DINNERTIME;

            return ftData;
        }
    }
}
