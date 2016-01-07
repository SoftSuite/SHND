using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using SHND.DAL.Common;

namespace SHND.Flow.Common
{
    public class AttachFlow
    {
        private string _error;
        public string ErrorMessage { get { return _error; } }

        public DataTable getFileList(string ref1, string ref2, string uniqid)
        {
            AttachDAL attDAL = new AttachDAL();
            DataTable zDt = new DataTable();
            try
            {
                zDt = attDAL.getFileList(ref1, ref2, uniqid);
            }
            catch (Exception e)
            {
                _error = e.Message;
            }

            return zDt;
        }

        public bool InsertAttachFile(string ref1, string ref2, string uniqID, string filename, int filesize, string desc, string userID)
        {
            bool ret = true;
            AttachDAL attDAL = new AttachDAL();
            try
            {
                attDAL.InsertAttachFile(ref1, ref2, uniqID, filename, filesize, desc, userID);
            }
            catch (Exception e)
            {
                ret = false;
                _error = e.Message;
            }
            return ret;
        }

        public bool DeleteAttachFile(string ref1, string ref2, string uniqID, string filename)
        {
            {
                bool ret = true;
                AttachDAL attDAL = new AttachDAL();
                try
                {
                    attDAL.DeleteAttachFile(ref1, ref2, uniqID, filename);
                }
                catch (Exception e)
                {
                    ret = false;
                    _error = e.Message;
                }
                return ret;
            }
        }

        public bool DeleteAttachFile(double ID)
        {
            {
                bool ret = true;
                AttachDAL attDAL = new AttachDAL();
                try
                {
                    attDAL.DeleteAttachFile(ID);
                }
                catch (Exception e)
                {
                    ret = false;
                    _error = e.Message;
                }
                return ret;
            }
        }

        public string GetFilePath(double ID)
        {
            string ret = "";
            AttachDAL aDal = new AttachDAL();
            try
            {
                DataTable zDt = aDal.getFileDetail(ID);
                if (zDt.Rows.Count == 0)
                    throw new Exception("ID not found");

                ret = zDt.Rows[0]["REF1"].ToString() + "\\" + zDt.Rows[0]["REF2"].ToString() + "\\" + zDt.Rows[0]["UNIQID"].ToString() + "\\" + zDt.Rows[0]["FILENAME"].ToString();

            }
            catch (Exception e)
            {
                ret = "";
                _error = e.Message;
            }
            return ret;
        }

        public int CountFile(string ref1, string ref2, string uniqID)
        {
            int ret = 0;
            AttachDAL aDAL = new AttachDAL();

            try
            {
                ret = aDAL.CountFile(ref1, ref2, uniqID);
            }
            catch (Exception e)
            {
                ret = -1;
                _error = e.Message;
            }
            return ret;
        }
    }
}
