using System;

namespace SHND.Data.Tables
{
    /// <summary>
    /// Represents a PREPARETIME data.
    /// [Created by 127.0.0.1 on April,8 2009]
    /// </summary>
    public class PrepareTimeData
    {
        DateTime _CHECKTIME = new DateTime(1, 1, 1);
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        string _ISTRANSFER = "";
        double _LOID = 0;
        string _PREPAREMEAL = "";
        double _REFMEDLOID = 0;
        double _REFNONMEDLOID = 0;
        string _REFTABLEMED = "";
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);
        DateTime _DELIVERYTIME = new DateTime(1, 1, 1);

        public DateTime CHECKTIME
        {
            get { return _CHECKTIME; }
            set { _CHECKTIME = value; }
        }
        public string CREATEBY
        {
            get { return _CREATEBY; }
            set { _CREATEBY = value; }
        }
        public DateTime CREATEON
        {
            get { return _CREATEON; }
            set { _CREATEON = value; }
        }
        public string ISTRANSFER
        {
            get { return _ISTRANSFER; }
            set { _ISTRANSFER = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public string PREPAREMEAL
        {
            get { return _PREPAREMEAL; }
            set { _PREPAREMEAL = value; }
        }
        public double REFMEDLOID
        {
            get { return _REFMEDLOID; }
            set { _REFMEDLOID = value; }
        }
        public double REFNONMEDLOID
        {
            get { return _REFNONMEDLOID; }
            set { _REFNONMEDLOID = value; }
        }
        public string REFTABLEMED
        {
            get { return _REFTABLEMED; }
            set { _REFTABLEMED = value; }
        }
        public string UPDATEBY
        {
            get { return _UPDATEBY; }
            set { _UPDATEBY = value; }
        }
        public DateTime UPDATEON
        {
            get { return _UPDATEON; }
            set { _UPDATEON = value; }
        }
        public DateTime DELIVERYTIME
        {
            get { return _DELIVERYTIME; }
            set { _DELIVERYTIME = value; }
        }
    }
}