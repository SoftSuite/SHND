using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SHND.DAL.Common;
using SHND.Data.Common;

namespace SHND.Flow.Common
{
    public class MenuFlow
    {
        string _error = "";
        public string ErrorMessage { get { return _error; } }

        public DataTable GetAllMenu()
        {
            DataTable ret;
            try
            {
                ZMenuDAL mDAL = new ZMenuDAL();
                ret = mDAL.GetAllMenu();
            }
            catch (Exception ex)
            {
                _error = ex.Message;
                ret = new DataTable();
            }
            return ret;

        }

        public DataTable GetMenuByUserLOID(double cLOID)
        {
            DataTable ret = null;
            try
            {
                ZMenuDAL mDAL = new ZMenuDAL();
                ret = mDAL.GetMenuByUserLOID(cLOID);
            }
            catch (Exception ex)
            {
                _error = ex.Message;
                ret = new DataTable();
            }
            return ret;
        }

        public MenuData GetMenuDataByFileName(string fileName)
        {
            MenuData ret;
            try
            {
                ZMenuDAL mDAL = new ZMenuDAL();
                ret = mDAL.GetMenuDataByFileName(fileName);
            }
            catch (Exception ex)
            {
                _error = ex.Message;
                ret = new MenuData();
            }
            return ret;

        }

    }
}
