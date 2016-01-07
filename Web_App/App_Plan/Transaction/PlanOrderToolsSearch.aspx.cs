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
/// PlanOrderToolsSearch Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Teang
/// Create Date: 16 Feb 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    ˹�ҡ�÷���¡�â����� PlanOrderToolsSearch
/// Changes:
///    1.0 - ���ҧ
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
public partial class App_Plan_Transaction_PlanOrderToolsSearch : System.Web.UI.Page
{
    private void SetStatusCombo(DropDownList cmb)
    {
        cmb.Items.Clear();
        cmb.Items.Add(new ListItem("���ѧ���Թ���", "00"));
        cmb.Items.Add(new ListItem("�Ǻ���������ͧ���", "01"));
        cmb.Items.Add(new ListItem("�׹�ѹ", "03"));
        cmb.Items.Add(new ListItem("���˹��˹���͹��ѵ�", "04"));
        cmb.Items.Add(new ListItem("���˹��˹������͹��ѵ�", "05"));
        cmb.Items.Add(new ListItem("���˹�ҽ���͹��ѵ�", "06"));
        cmb.Items.Add(new ListItem("���˹�ҽ������͹��ѵ�", "07"));
        cmb.Items.Add(new ListItem("�������", "08"));
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
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

    protected void tbAddClick(object sender, EventArgs e)
    {
        Response.Redirect(Constant.HomeFolder + "App_Plan/Transaction/PlanOrderTools.aspx?loid=0");
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

    protected void lnkName_Click(object sender, EventArgs e)
    {
        Response.Redirect(Constant.HomeFolder + "App_Plan/Transaction/PlanOrderTools.aspx?loid=" + ((LinkButton)sender).CommandArgument);
    }

    protected void imbCopy_Click(object sender, ImageClickEventArgs e)
    {
        doCopy(Convert.ToDouble(((ImageButton)sender).CommandArgument));
    }

    #endregion

    #region Gridview Event Handler

    protected void gvMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex > -1)
        {
            e.Row.Cells[3].Text = ((e.Row.RowIndex + 1) + (gvMain.PageIndex * gvMain.PageSize)).ToString();
            ((ImageButton)e.Row.Cells[2].FindControl("imbCopy")).OnClientClick = "return confirm('" + string.Format(DataResources.MSGCC001, "������Ἱ����ҳ�����ʴ��ػ�ó�", e.Row.Cells[1].Text) + "')";
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
        this.txtSearchPlanName.Text = "";
        this.txtSearchQtCode.Text = "";
        this.txtSearchRefPRSap.Text = "";
        cmbSearchStatusFrom.SelectedIndex = 0;
        cmbSearchStatusTo.SelectedIndex = cmbSearchStatusTo.Items.Count - 1;
    }

    #endregion

    #region Working Method

    private void doGetList()
    {
        PlanOrderToolsFlow fFlow = new PlanOrderToolsFlow();
        // ��Ǩ�ͺ���͹䢡�ä��������ʴ����� reset ��ä���
        imbReset.Visible = (txtSearchPlanName.Text.Trim() != "") || (Convert.ToDouble("0" + this.txtSearchBudgetYear.Text) != 0)
            || (this.txtSearchQtCode.Text.Trim() != "") || (this.txtSearchRefPRSap.Text.Trim() != "") || (cmbSearchStatusFrom.SelectedIndex != 0) || (cmbSearchStatusTo.SelectedIndex != cmbSearchStatusTo.Items.Count - 1);

        string orderStr = "";
        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;

        gvMain.DataSource = fFlow.GetMasterList(this.txtSearchPlanName.Text.Trim(), Convert.ToInt32("0" + this.txtSearchBudgetYear.Text),
            this.txtSearchQtCode.Text.Trim(), this.txtSearchRefPRSap.Text.Trim(), this.cmbSearchStatusFrom.SelectedItem.Value, this.cmbSearchStatusTo.SelectedItem.Value, orderStr);
        gvMain.DataBind();
        pcTop.Update();
        pcBot.Update();
    }

    private void doCopy(double refPlanOrderFoodID)
    {
        PlanOrderToolsFlow fFlow = new PlanOrderToolsFlow();
        if (fFlow.CopyData(refPlanOrderFoodID, Appz.CurrentUser))
        {
            Response.Redirect(Constant.HomeFolder + "App_Plan/Transaction/PlanOrderTools.aspx?loid=" + fFlow.LOID.ToString());
        }
        else
        {
            this.lbStatusMain.Text = fFlow.ErrorMessage;
            this.lbStatusMain.ForeColor = Constant.StatusColor.Error;
        }
    }

    #endregion
}
