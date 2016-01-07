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
using SHND.Flow.Plan;
using SHND.Global;

/// <summary>
/// PlanContractFoodSearch Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Teang
/// Create Date: 12 Feb 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้าการทำรายการข้อมูล PlanContractFoodSearch
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
public partial class App_Plan_Transaction_PlanContractFoodSearch : System.Web.UI.Page
{
    private void SetStatusCombo(DropDownList cmb)
    {
        cmb.Items.Clear();
        cmb.Items.Add(new ListItem("กำลังดำเนินการ", "00"));
        cmb.Items.Add(new ListItem("รวบรวมความต้องการ", "01"));
        cmb.Items.Add(new ListItem("ยืนยัน", "03"));
        cmb.Items.Add(new ListItem("หัวหน้าหน่วยอนุมัติ", "04"));
        cmb.Items.Add(new ListItem("หัวหน้าหน่วยไม่อนุมัติ", "05"));
        cmb.Items.Add(new ListItem("หัวหน้าฝ่ายอนุมัติ", "06"));
        cmb.Items.Add(new ListItem("หัวหน้าฝ่ายไม่อนุมัติ", "07"));
        cmb.Items.Add(new ListItem("เสร็จสิ้น", "08"));
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        ControlUtil.SetNumberTextbox(this.txtSearchPhase);
        ControlUtil.SetYearTextbox(this.txtSearchBudgetYear);
        SetStatusCombo(this.cmbSearchStatusFrom);
        SetStatusCombo(this.cmbSearchStatusTo);
        pcTop.SetMainGridView(gvMain);
        pcBot.SetMainGridView(gvMain);
        ClearSearch();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            doGetList();
        }
    }

    #region Button Click Event Handler

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

    protected void lnkName_Click(object sender, EventArgs e)
    {
        Response.Redirect(Constant.HomeFolder + "App_Plan/Transaction/PlanContractFood.aspx?loid=" + ((LinkButton)sender).CommandArgument);
    }

    #endregion

    #region Gridview Event Handler

    protected void gvMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex > -1)
        {
            e.Row.Cells[2].Text = ((e.Row.RowIndex + 1) + (gvMain.PageIndex * gvMain.PageSize)).ToString();
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
        this.txtSearchBudgetYear.Text = "";
        this.txtSearchPhase.Text = "";
        this.txtSearchPlanName.Text = "";
        this.txtSearchQtCode.Text = "";
        this.txtSearchRefPRSap.Text = "";
        cmbSearchStatusFrom.SelectedIndex = 5;
        cmbSearchStatusTo.SelectedIndex = 5;
    }

    #endregion

    #region Working Method

    private void doGetList()
    {
        PlanContractFoodFlow fFlow = new PlanContractFoodFlow();
        // ตรวจสอบเงื่อนไขการค้นหาเพื่อแสดงปุ่ม reset การค้นหา
        imbReset.Visible = (txtSearchPlanName.Text.Trim() != "") || (Convert.ToDouble("0" + this.txtSearchPhase.Text) != 0) || (Convert.ToDouble("0" + this.txtSearchBudgetYear.Text) != 0)
            || (this.txtSearchQtCode.Text.Trim() != "") || (this.txtSearchRefPRSap.Text.Trim() != "") || (cmbSearchStatusFrom.SelectedIndex != 5) || (cmbSearchStatusTo.SelectedIndex != 5);

        string orderStr = "";
        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;

        gvMain.DataSource = fFlow.GetMasterList(this.txtSearchPlanName.Text.Trim(), Convert.ToInt32("0" + this.txtSearchPhase.Text), Convert.ToInt32("0" + this.txtSearchBudgetYear.Text),
            this.txtSearchQtCode.Text.Trim(), this.txtSearchRefPRSap.Text.Trim(), this.cmbSearchStatusFrom.SelectedItem.Value, this.cmbSearchStatusTo.SelectedItem.Value, orderStr);
        gvMain.DataBind();
        pcTop.Update();
        pcBot.Update();
    }

    #endregion

}
