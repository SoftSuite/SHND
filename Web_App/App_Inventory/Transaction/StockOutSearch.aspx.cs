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
using SHND.Data.Common.Utilities;
using SHND.Flow.Inventory;
using SHND.Global;

/// <summary>
/// StockOutSearch Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Teang
/// Create Date: 2 Mar 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้าการทำรายการข้อมูล StockOut
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
public partial class App_Inventory_Transaction_StockOutSearch : System.Web.UI.Page
{
    private void SetStatusCombo(DropDownList cmb)
    {
        cmb.Items.Clear();
        cmb.Items.Add(new ListItem("ทำรายการ", "00"));
        cmb.Items.Add(new ListItem("รอจ่าย", "01"));
        cmb.Items.Add(new ListItem("จ่ายเรียบร้อย", "02"));
        cmb.Items.Add(new ListItem("ไม่อนุมัติ", "03"));
        cmb.Items.Add(new ListItem("ยืนยัน", "04"));
        cmb.Items.Add(new ListItem("ยกเลิก", "05"));
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            doGetList();
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        // set Combo source
        SetStatusCombo(this.cmbSearchStatusFrom);
        SetStatusCombo(this.cmbSearchStatusTo);
        pcTop.SetMainGridView(gvMain);
        pcBot.SetMainGridView(gvMain);
        ClearSearch();
    }

    #region Button Click Event Handler

    protected void lnkCode_Click(object sender, EventArgs e)
    {
        Response.Redirect(Constant.HomeFolder + "App_Inventory/Transaction/StockOut.aspx?loid=" + ((LinkButton)sender).CommandArgument);
    }

    protected void imbSearch_Click(object sender, ImageClickEventArgs e)
    {
        gvMain.PageIndex = 0;
        doGetList();
    }

    protected void imbReset_Click(object sender, ImageClickEventArgs e)
    {
        ClearSearch();
        gvMain.PageIndex = 0;
        doGetList();
    }

    #endregion

    #region Gridview Event Handler

    protected void gvMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex > -1)
        {
            e.Row.Cells[1].Text = ((e.Row.RowIndex + 1) + (gvMain.PageIndex * gvMain.PageSize)).ToString();
        }
    }

    protected void gvMain_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression == "DEFAULT")
        {
            txhSortDir.Text = "";
            txhSortField.Text = "";
        }
        else
        {
            if (txhSortField.Text == e.SortExpression)
                txhSortDir.Text = (txhSortDir.Text.Trim() == "" ? "DESC" : "");
            else
                txhSortField.Text = e.SortExpression;
        }
        doGetList();

    }

    #endregion

    #region Paging Event Handler
    protected void PageChange(object sender, EventArgs e)
    {
        gvMain.PageIndex = ((Templates_PageControl)sender).SelectedPageIndex;
        doGetList();
        pcBot.Update();
        pcTop.Update();
    }
    #endregion

    #region Controls Management Methods

    private void ClearSearch()
    {
        // Clear searh data
        txtSearchCodeFrom.Text = "";
        txtSearchCodeTo.Text = "";
        this.ctlUseDateFrom.DateValue = new DateTime();
        this.ctlUseDateTo.DateValue = new DateTime();
        this.cmbSearchStatusFrom.SelectedIndex = 1;
        cmbSearchStatusTo.SelectedIndex = cmbSearchStatusTo.Items.Count - 1;
    }

    #endregion

    #region Working Method

    private void doGetList()
    {
        StockOutRequestFlow fFlow = new StockOutRequestFlow();

        // ตรวจสอบเงื่อนไขการค้นหาเพื่อแสดงปุ่ม reset การค้นหา
        imbReset.Visible = (txtSearchCodeFrom.Text.Trim() != "") || (this.txtSearchCodeTo.Text.Trim() != "") || (this.ctlUseDateFrom.DateValue.Year != 1) || (this.ctlUseDateTo.DateValue.Year != 1) ||
            (this.cmbSearchStatusFrom.SelectedIndex != 1) || (this.cmbSearchStatusTo.SelectedIndex != (this.cmbSearchStatusTo.Items.Count - 1));

        string orderStr = "";
        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;

        gvMain.DataSource = fFlow.GetMasterList(this.txtSearchCodeFrom.Text.Trim(), this.txtSearchCodeTo.Text.Trim(), this.ctlUseDateFrom.DateValue, this.ctlUseDateTo.DateValue,
            this.cmbSearchStatusFrom.SelectedItem.Value, this.cmbSearchStatusTo.SelectedItem.Value,0, orderStr);
        gvMain.DataBind();
        pcTop.Update();
        pcBot.Update();
    }

    #endregion

}
