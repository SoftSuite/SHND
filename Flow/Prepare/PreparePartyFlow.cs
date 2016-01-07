using System;
using System.Collections.Generic;
using System.Text;
using zTran = SHND.DAL.Utilities.OracleTransactionDB;
using System.Data;
using SHND.DAL.Views;
using SHND.Data.Views;
using SHND.DAL.Tables;
using SHND.Data.Tables;
using System.Collections;

/// <summary>
/// PreparePartyFlow Class
/// Version 1.0
/// =========================================================================
/// Create by: Nang
/// Create Date: 11 Mar 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงานของหน้า PrepareParty
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

namespace SHND.Flow.Prepare
{
    public class PreparePartyFlow
    {
        string _error = "";
        public string ErrorMessage { get { return _error; } }

        public DataTable GetPreparePartySearch(string wh, string orderstr)
        {
            VOrderPartySearchDAL vDAL = new VOrderPartySearchDAL();
            return vDAL.GetDataList(wh, orderstr, null);
        }

        #region Get Data Pop

        #region Get Data Popup

        public OrderPartyData GetOrderPartyData(double opLoid)
        {
            OrderPartyDAL oDAL = new OrderPartyDAL();
            OrderPartyData oData = new OrderPartyData();
            oDAL.GetDataByLOID(opLoid, null);
            if (oDAL.OnDB)
            {
                oData.CODE = oDAL.CODE;
                oData.ORDERDATE = oDAL.ORDERDATE;
                oData.DIVISION = oDAL.DIVISION;
                oData.OTITLE = oDAL.OTITLE;
                oData.ONAME = oDAL.ONAME;
                oData.OLASTNAME = oDAL.OLASTNAME;
                oData.OTEL = oDAL.OTEL;
                oData.PARTYDATETIME = oDAL.PARTYDATETIME;
                oData.PARTYTYPE = oDAL.PARTYTYPE;
                oData.VISITORQTY = oDAL.VISITORQTY;
                oData.PLACE = oDAL.PLACE;
                oData.DIRECTORAPPROVE = oDAL.DIRECTORAPPROVE;
                oData.DIRECTORCOMMENT = oDAL.DIRECTORCOMMENT;
                oData.NDAPPROVE = oDAL.NDAPPROVE;
                oData.NDCOMMENT = oDAL.NDCOMMENT;
                oData.LOID = oDAL.LOID;
            }
            else
                _error = Data.Common.Utilities.DataResources.MSGEU002;

            return oData;
        }


        public DataTable GetOrderPartyItemData(double oLoid)
        {
            OrderPartyItemDAL opiDAL = new OrderPartyItemDAL();
            return opiDAL.GetPreparePartyItem("OP.LOID = "+ oLoid, "OPI.LOID", null);
        }

        public string GetTitle(double tloid)
        {
            TitleDAL tDAL = new TitleDAL();
            return tDAL.GetName(tloid);
        }

        public string GetStatusName(double tloid)
        {
            OrderPartyDAL oDAL = new OrderPartyDAL();
            return oDAL.GetStatusName(tloid);
        }


        #endregion


        #endregion
    }


}
