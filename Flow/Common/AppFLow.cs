using System;
using System.Collections.Generic;
using System.Text;
using SHND.DAL.Functions;

namespace SHND.Flow.Common
{
    public class AppFLow
    {
        public static string GetConfigValue(double ID)
        {
            FunctionDAL fDAL = new FunctionDAL();
            return fDAL.GetConfigValue(ID);
        }
    }
}
