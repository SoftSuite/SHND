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
/// ToDoListRemain Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Teang
/// Create Date: 17 Feb 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้าการทำรายการข้อมูล ToDoListRemain
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
public partial class App_Plan_Transaction_ToDoListRemain : System.Web.UI.Page
{
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        Appz.BuildCombo(this.cmbSearchMaterialClass, "MATERIALCLASS", "NAME", "LOID", "MASTERTYPE='FO' AND ACTIVE = '1'", "NAME", "ทั้งหมด", "0", false);
        Appz.BuildCombo(this.cmbSearchPlan, "PLANORDER", "NAME", "LOID", "STATUS = 'FN' AND ISPLANFOOD = 'Y'", "NAME", "ทั้งหมด", "0", false);
        ControlUtil.SetNumberTextbox(this.txtSearchRemainPercent);
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

    protected void lnkCode_Click(object sender, EventArgs e)
    {
        int rowIndex = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;
        SetSpecData(rowIndex);
    }

    protected void tbSaveSpecClick(object sender, EventArgs e)
    {
        if (!UpdateSpec())
        {
            this.ctlSpecPopup.Show();
        }
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

    private void SetStatus(string t, bool isError)
    {
        this.lbStatus.Text = t;
        this.lbStatus.ForeColor = (isError ? Constant.StatusColor.Error : Constant.StatusColor.Information);
    }

    private void ClearSpec()
    {
        this.txtMaterialMaster.Text = "";
        this.txtRowIndex.Text = "";
        this.lblMaterialName.Text = "";
        this.txtSpec.Text = "";
    }

    private void SetSpecData(int rowIndex)
    {
        ClearSpec();

        GridViewRow gRow = this.gvMain.Rows[rowIndex];
        this.txtRowIndex.Text = rowIndex.ToString();
        this.lblMaterialName.Text = gRow.Cells[3].Text + " (" + gRow.Cells[4].Text + ")";
        this.txtSpec.Text = gRow.Cells[10].Text;
        this.txtMaterialMaster.Text = gRow.Cells[0].Text;
        this.ctlSpecPopup.Show();
    }

    private void ClearSearch()
    {
        // Clear searh data
        ToDoListRemainFlow fFlow = new ToDoListRemainFlow();
        this.cmbSearchPlan.SelectedValue = fFlow.GetDefaultPlan(DateTime.Today).ToString();
        this.cmbSearchMaterialClass.SelectedIndex = 0;
        this.txtSearchName.Text = "";
        this.cmbSearchOperator.SelectedIndex = 0;
        this.txtSearchRemainPercent.Text = "";
    }

    #endregion

    #region Working Method

    private void doGetList()
    {
        ToDoListRemainFlow fFlow = new ToDoListRemainFlow();
        // ตรวจสอบเงื่อนไขการค้นหาเพื่อแสดงปุ่ม reset การค้นหา
        imbReset.Visible = (this.cmbSearchMaterialClass.SelectedIndex != 0) || this.txtSearchName.Text.Trim() != "" || (Convert.ToDouble("0" + this.txtSearchRemainPercent.Text) != 0)
            || (this.cmbSearchOperator.SelectedIndex != 0);

        string orderStr = "";
        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;

        gvMain.DataSource = fFlow.GetMasterList(Convert.ToDouble("0" + cmbSearchPlan.SelectedItem.Value), Convert.ToDouble("0" + this.cmbSearchMaterialClass.SelectedItem.Value), this.txtSearchName.Text,
            (this.txtSearchRemainPercent.Text.Trim() == "" ? "" : (this.cmbSearchOperator.SelectedItem.Value == "1" ? ">=" : (this.cmbSearchOperator.SelectedItem.Value == "2" ? "<=" : ""))),
            Convert.ToDouble("0" + this.txtSearchRemainPercent.Text), orderStr);
        gvMain.DataBind();
        pcTop.Update();
        pcBot.Update();
    }

    private bool UpdateSpec()
    {
        bool ret = true;
        int rowIndex = Convert.ToInt32(this.txtRowIndex.Text);
        ToDoListRemainFlow fFlow = new ToDoListRemainFlow();
        ret = fFlow.UpdateSpec(Convert.ToDouble("0" + this.txtMaterialMaster.Text), this.txtSpec.Text.Trim(), Appz.CurrentUser);
        if (!ret)
            SetStatus(fFlow.ErrorMessage, true);
        else
        {
            this.gvMain.Rows[rowIndex].Cells[10].Text = this.txtSpec.Text.Trim();
            SetStatus(DataResources.MSGIU001, false);
        }
        return ret;
    }

    #endregion

}
