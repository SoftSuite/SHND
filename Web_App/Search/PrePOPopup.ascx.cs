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
using SHND.Data.Search;
using SHND.Data.Views;
using SHND.Flow.Search;
using SHND.Global;

/// <summary>
/// MaterialUnitPopup Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Tan
/// Create Date: 19 Feb 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    ˹�Ҥ��� ��������ʴ������ (Plan Material Master)
/// Changes:
///    1.0 - ���ҧ
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
public partial class Search_PrePOPopup : System.Web.UI.UserControl
{
    public delegate void SelectedIndexChangedEvent(object sender, EventArgs e, ArrayList SelectedData);
    public event SelectedIndexChangedEvent SelectedIndexChanged;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        pcBot.SetMainGridView(gvMain);
        pcTop.SetMainGridView(gvMain);
    }

    #region Button Click Event Handler

    protected void tbBackClick(object sender, EventArgs e)
    {
    }

    protected void tbAddClick(object sender, EventArgs e)
    {
        if (SelectedIndexChanged != null) SelectedIndexChanged(sender, e, GetSelectedData());
    }

    protected void imbSearch_Click(object sender, ImageClickEventArgs e)
    {
        gvMain.PageIndex = 0;
        doGetList();
        popupMaterialMaster.Show();
    }

    protected void imbReset_Click(object sender, ImageClickEventArgs e)
    {
        ClearSearch();
        gvMain.PageIndex = 0;
        doGetList();
        popupMaterialMaster.Show();
    }

    #endregion

    #region Gridview Event Handler

    protected void gvMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            ((CheckBox)e.Row.Cells[1].FindControl("chkAll")).Attributes.Add("onclick", "chkAllBox(this, '" + this.gvMain.ClientID + "_ctl', '_chkSelect')");
        }
        else if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[2].Text = ((e.Row.RowIndex + 1) + (gvMain.PageIndex * gvMain.PageSize)).ToString();
        }
    }
    protected void gvMain_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression == "DEFAULT")
        {
            txhSortDir.Text = "";
            txhSortField.Text = "CLASSNAME, GROUPNAME, MATERIALNAME";
        }
        else
        {
            if (txhSortField.Text == e.SortExpression)
                txhSortDir.Text = (txhSortDir.Text.Trim() == "" ? "DESC" : "");
            else
                txhSortField.Text = e.SortExpression;
        }
        doGetList();
        popupMaterialMaster.Show();
    }

    #endregion

    #region Paging Event Handler

    protected void PageChange(object sender, EventArgs e)
    {
        gvMain.PageIndex = ((Templates_PageControl)sender).SelectedPageIndex;
        doGetList();
        pcBot.Update();
        pcTop.Update();
        popupMaterialMaster.Show();
    }

    #endregion

    #region Misc. Methods

    private ArrayList GetSelectedData()
    {
        ArrayList arrChk = new ArrayList();
        for (int i = 0; i < gvMain.Rows.Count; i++)
        {
            if (i > -1 && gvMain.Rows[i].Cells[0].FindControl("chkSelect") != null)
            {
                GridViewRow gRow = gvMain.Rows[i];
                if (((CheckBox)gRow.Cells[1].FindControl("chkSelect")).Checked)
                {
                    VPrePOMaterialClassData PrePOItemList = new VPrePOMaterialClassData();
                    PrePOItemList.MATERIALMASTER = Convert.ToDouble("0" + gRow.Cells[0].Text);
                    PrePOItemList.PRICE = Convert.ToDouble("0" + gRow.Cells[5].Text);
                    PrePOItemList.MATERIALNAME = gRow.Cells[3].Text;
                    PrePOItemList.UNITLOID = Convert.ToDouble("0" + gRow.Cells[7].Text);
                    PrePOItemList.UNITNAME = gRow.Cells[4].Text;
                    PrePOItemList.ISVAT = gRow.Cells[8].Text;
                    PrePOItemList.SAPCODE = gRow.Cells[9].Text;
                    PrePOItemList.CODE = gRow.Cells[10].Text;
                    PrePOItemList.SPEC = gRow.Cells[11].Text;
                    arrChk.Add(PrePOItemList);
                }
            }
        }
        return arrChk;
    }

    #endregion

    #region Controls Management Methods

    private void ClearSearch()
    {
      //  this.cmbSearchMaterialClass.SelectedIndex = 0;
        this.txtSearchName.Text = "";
        txhSortField.Text = "CLASSNAME, GROUPNAME, MATERIALNAME";
    }

    public void Show(double plan, double materialclass, string existKeyList)
    {
        Appz.BuildCombo(this.cmbSearchMaterialClass, "MATERIALCLASS", "NAME", "LOID", "MASTERTYPE='FO' AND ACTIVE = '1'", "NAME", "������", "0", false);
        cmbSearchMaterialClass.SelectedValue = materialclass.ToString();
        txtPlan.Text = plan.ToString();

        this.txtExistKeyList.Text = existKeyList;
        ClearSearch();

        gvMain.PageIndex = 0;
        doGetList();
        popupMaterialMaster.Show();
    }

    public void Show(double materialClassID, string existKeyList)
    {
        Appz.BuildCombo(this.cmbSearchMaterialClass, "MATERIALCLASS", "NAME", "LOID", "MASTERTYPE<>'FO' AND ACTIVE = '1'", "NAME", "������", "0", false);
        this.txtExistKeyList.Text = existKeyList;
        ClearSearch();
        this.cmbSearchMaterialClass.SelectedIndex = this.cmbSearchMaterialClass.Items.IndexOf(this.cmbSearchMaterialClass.Items.FindByValue(materialClassID.ToString()));
        this.cmbSearchMaterialClass.Enabled = false;

        gvMain.PageIndex = 0;
        doGetList();
        popupMaterialMaster.Show();
    }

    #endregion

    #region Working Method

    private void doGetList()
    {
        SearchFlow fFlow = new SearchFlow();

        // ��Ǩ�ͺ���͹䢡�ä��������ʴ����� reset ��ä���
        imbReset.Visible = (this.cmbSearchMaterialClass.SelectedIndex != 0 && this.cmbSearchMaterialClass.Enabled) || (txtSearchName.Text.Trim() != "");

        string orderStr = "";
        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;
        gvMain.DataSource = fFlow.GetPrePOMaterialList(Convert.ToDouble(this.txtPlan.Text.Trim()), Convert.ToDouble(this.cmbSearchMaterialClass.SelectedItem.Value), this.txtSearchName.Text.Trim(), this.txtExistKeyList.Text, orderStr);
        gvMain.DataBind();
        pcBot.Update();
        pcTop.Update();
    }

    #endregion
}
