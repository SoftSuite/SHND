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
using SHND.Flow.Inventory;
using SHND.Data.Formula;
using SHND.Global;
using SHND.Flow.Common;
using SHND.Data.Common.Utilities;
/// <summary>
/// FoodType Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Pro
/// Create Date: 13 Feb 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้ากาารทำงานข้อมูล RepairSearch
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

public partial class App_Inventory_Transaction_RepairSearch : System.Web.UI.Page
{
    private void SetStatusCombo(DropDownList cmb)
    {
        cmb.Items.Clear();
        cmb.Items.Add(new ListItem("รอส่งซ่อม", "01"));
        cmb.Items.Add(new ListItem("ส่งซ่อมแล้ว", "02"));
        cmb.Items.Add(new ListItem("เสร็จสิ้น", "04"));
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
        Appz.BuildCombo(cmbSearchDiv, "DIVISION", "NAME", "LOID", "", "NAME", "ทั้งหมด", "", false);
        pcTop.SetMainGridView(gvMain);
        pcBot.SetMainGridView(gvMain);
        ClearSearch();
    }

    #region Button Click Event Handler
    
    protected void lnkRepair_Click(object sender, EventArgs e)
    {
        Response.Redirect(Constant.HomeFolder + "App_Inventory/Transaction/Repair.aspx?loid=" + ((LinkButton)sender).CommandArgument);
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
            e.Row.Cells[1].Text = ((e.Row.RowIndex + 1) + (gvMain.PageIndex * gvMain.PageSize)).ToString();
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[7].Text != "1")
                e.Row.Cells[5].ForeColor= System.Drawing.Color.Red;
        }
    }

    protected void gvMain_Sorting(object sender, GridViewSortEventArgs e)
    {
        RepairRequestFlow fFlow = new RepairRequestFlow();
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

    #region Misc. Methods

    #endregion

    #region Controls Management Methods
   

    private void ClearSearch()
    {
        // Clear searh data
        txtCodeFrom.Text = "";
        txtCodeTo.Text = "";
        cmbSearchDiv.SelectedIndex = 0;
        cmbSearchStatusFrom.SelectedIndex = 0;
        cmbSearchStatusTo.SelectedIndex = 0;
    }

    #endregion

    #region Working Method

    private void doGetList()
    {
        RepairRequestFlow fFlow = new RepairRequestFlow();

        // ตรวจสอบเงื่อนไขการค้นหาเพื่อแสดงปุ่ม reset การค้นหา
        imbReset.Visible = (this.txtCodeFrom.Text.Trim() != "") || (this.txtCodeTo.Text.Trim() != "") || ctlStartDate.DateValue.Year != 1 || ctlEndDate.DateValue.Year != 1 ||
         (this.cmbSearchDiv.SelectedIndex != 0) || (this.cmbSearchStatusFrom.SelectedIndex != 0) || (this.cmbSearchStatusTo.SelectedIndex != this.cmbSearchStatusTo.Items.Count - 1);

        string orderStr = "";
        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;

        gvMain.DataSource = fFlow.GetMaterialList(txtCodeFrom.Text, txtCodeTo.Text, ctlStartDate.DateValue, ctlEndDate.DateValue, Convert.ToDouble("0" + this.cmbSearchDiv.SelectedItem.Value), this.cmbSearchStatusFrom.SelectedItem.Value, this.cmbSearchStatusTo.SelectedItem.Value, orderStr);
        gvMain.DataBind();
        pcTop.Update();
        pcBot.Update();
    }


    #endregion

}
