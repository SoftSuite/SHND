using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SHND.Flow.Prepare;
using SHND.Data.Common.Utilities;
using SHND.Data.Views;
using SHND.Global;

/// <summary>
/// NpoOrderSetCtl Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Nang
/// Create Date: 13 June 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้าการทำงานข้อมูลรายชื่อผู้ป่วยที่งดอาหาร
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 


public partial class App_Prepare_Transaction_NpoOrderSet_NpoOrderSetCtl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //doGetList(0);
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        Appz.BuildCombo(cmbWard, "WARD", "NAME", "LOID", "ACTIVE='1'", "NAME", "ทั้งหมด", "0", true);
        this.btnSearch.OnClientClick = "if (document.getElementById('" + this.txtTimeFrom.ClientID + "').value != '') " +
    "{" +
    "if (parseFloat(document.getElementById('" + this.txtTimeFrom.ClientID + "').value.split(':')[0]) >= 24 || parseFloat(document.getElementById('" + this.txtTimeFrom.ClientID + "').value.split(':')[1]) > 59) " +
    "{ alert('รุปแบเวลาไม่ถูกต้อง (จำนวนชั่วโมงต้องน้อยกว่า 24 และนาทีต้องไม่เกิน 59)'); document.getElementById('" + this.txtTimeFrom.ClientID + "').focus(); return false; } " +
    "} " +
    "if (document.getElementById('" + this.txtTimeTo.ClientID + "').value != '') " +
    "{" +
    "if (parseFloat(document.getElementById('" + this.txtTimeTo.ClientID + "').value.split(':')[0]) >= 24 || parseFloat(document.getElementById('" + this.txtTimeTo.ClientID + "').value.split(':')[1]) > 59) " +
    "{ alert('รุปแบเวลาไม่ถูกต้อง (จำนวนชั่วโมงต้องน้อยกว่า 24 และนาทีต้องไม่เกิน 59)'); document.getElementById('" + this.txtTimeTo.ClientID + "').focus(); return false; } " +
    "}" ;

    pcTop.SetMainGridView(gvMain);
    pcBot.SetMainGridView(gvMain);
    }

    #region Button Click Event Handler

    protected void imbSearch_Click(object sender, ImageClickEventArgs e)
    {
        doGetList(0);
    }

    protected void imbReset_Click(object sender, ImageClickEventArgs e)
    {
        ClearSearch();
        doGetList(0);
    }

    #endregion

    #region Gridview Event Handler
    #endregion

    #region Paging Event Handler
    protected void PageChange(object sender, EventArgs e)
    {
        doGetList(((Templates_PageControl)sender).SelectedPageIndex);
    }
    #endregion


    #region Misc. Methods
    #endregion

    #region Controls Management Methods

    private void ClearSearch()
    {
        // Clear searh data
        txtPatientName.Text = "";
        cmbWard.SelectedIndex = 0;
        ctlNpoStart.DateValue = new DateTime(1, 1, 1);
        txtTimeFrom.Text = "";
        txtTimeTo.Text = "";

    }

    #endregion

    #region Working Method

    private void doGetList(int curPage)
    {
        int pageSize = 20;
        int count = 0;
        int rank = 0;
        int total = 0;
        DataTable dt = new DataTable();

        dt = GetDataInsert();

        #region SetData

        DataTable dtNew = dt.Clone();
        DataRow dNewRow;

        for (int i = 0; i < dt.Rows.Count; ++i)
        {
            if (Convert.ToInt32(dt.Rows[i]["RANK"]) != rank && Convert.ToInt32(dt.Rows[i]["RANK"]) != 0)
            {
                rank = Convert.ToInt32(dt.Rows[i]["RANK"]);
                if (rank >= (curPage * pageSize) + 1 && rank <= (curPage * pageSize) + pageSize) ++count;
            }
            if (rank != total) total = rank;
            if (rank >= (curPage * pageSize) + 1 && rank <= (curPage * pageSize) + pageSize)
            {
                dNewRow = dtNew.NewRow();
                dNewRow["RANK"] = dt.Rows[i]["RANK"];
                dNewRow["FOODTYPENAME"] = dt.Rows[i]["FOODTYPENAME"];
                dNewRow["FEEDNAME"] = dt.Rows[i]["FEEDNAME"];
                dNewRow["PATIENTNAME"] = dt.Rows[i]["PATIENTNAME"];
                dNewRow["AGE"] = dt.Rows[i]["AGE"];
                dNewRow["WEIGHT"] = dt.Rows[i]["WEIGHT"];
                dNewRow["HEIGHT"] = dt.Rows[i]["HEIGHT"];
                dNewRow["BMI"] = dt.Rows[i]["BMI"];
                dNewRow["WARDNAME"] = dt.Rows[i]["WARDNAME"];
                dNewRow["ROOMNO"] = dt.Rows[i]["ROOMNO"];
                dNewRow["BEDNO"] = dt.Rows[i]["BEDNO"];
                dNewRow["FOODCATEGORYNAME"] = dt.Rows[i]["FOODCATEGORYNAME"];
                dNewRow["QTY"] = dt.Rows[i]["QTY"];
                dNewRow["CONTROL"] = dt.Rows[i]["CONTROL"];
                dNewRow["ABSTAIN"] = dt.Rows[i]["ABSTAIN"];
                dNewRow["REMARKS"] = dt.Rows[i]["REMARKS"];
                dNewRow["LIMIT"] = dt.Rows[i]["LIMIT"];
                dNewRow["NEED"] = dt.Rows[i]["NEED"];
                dNewRow["ORDERDATE"] = dt.Rows[i]["ORDERDATE"];
                dNewRow["STATUS"] = dt.Rows[i]["STATUS"];
                dNewRow["INCREASE"] = dt.Rows[i]["INCREASE"];
                dNewRow["STATUSNAME"] = dt.Rows[i]["STATUSNAME"];
                dNewRow["HN"] = dt.Rows[i]["HN"];
                dNewRow["AN"] = dt.Rows[i]["VN"];
                dNewRow["VN"] = dt.Rows[i]["AN"];
                dtNew.Rows.Add(dNewRow);
            }
        }
        this.gvMain.DataSource = dtNew;
        this.gvMain.DataBind();
        pcTop.Update(curPage, total, pageSize, count);
        pcBot.Update(curPage, total, pageSize, count);

        #endregion

    }


    private DataTable GetDataInsert()
    {
        NpoOrderSetFlow nFlow = new NpoOrderSetFlow();
        DataTable dt = new DataTable();

        imbReset.Visible = (txtPatientName.Text.Trim() != "") || (txtTimeFrom.Text.Trim() != "") || (txtTimeTo.Text.Trim() != "") || (cmbWard.SelectedItem.ToString() != "0");
        DateTime orderDateFrom = this.ctlNpoStart.DateValue;
        DateTime orderDateTo = this.ctlNpoStart.DateValue;

        //วันที่งดอาหาร
        if (orderDateFrom.Year != 1 && this.txtTimeFrom.Text.Trim() != "")
            orderDateFrom = new DateTime(orderDateFrom.Year, orderDateFrom.Month, orderDateFrom.Day, Convert.ToInt32(this.txtTimeFrom.Text.Substring(0, 2)), Convert.ToInt32(this.txtTimeFrom.Text.Substring(3, 2)), 0);
        if (orderDateTo.Year != 1 && this.txtTimeTo.Text.Trim() != "")
            orderDateTo = new DateTime(orderDateTo.Year, orderDateTo.Month, orderDateTo.Day, Convert.ToInt32(this.txtTimeTo.Text.Substring(0, 2)), Convert.ToInt32(this.txtTimeTo.Text.Substring(3, 2)), 0);


        dt = nFlow.GetNpoOrderSetList(Convert.ToDouble(this.cmbWard.SelectedItem.Value), this.txtPatientName.Text.Trim(), orderDateFrom, orderDateTo, this.cmbOrderType.SelectedItem.Value, "PATIENTNAME, RANK DESC");
        return dt;
    }
    #endregion

}
