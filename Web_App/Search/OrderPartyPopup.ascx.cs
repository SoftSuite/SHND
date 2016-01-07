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
/// FormulaSetPopup Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Tan
/// Create Date: 6 Feb 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้าค้นหา รายการอาหารจัดเลี้ยง
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
public partial class Search_OrderPartyPopup : System.Web.UI.UserControl
{
    public delegate void SelectedIndexChangedEvent(object sender, EventArgs e, ArrayList SelectedData);
    public event SelectedIndexChangedEvent SelectedIndexChanged;
    public DateTime sPartyDate;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        Appz.BuildCombo(this.cmbSearchFoodType, "FOODTYPE", "NAME", "LOID", "ACTIVE='1' AND LOID = TO_NUMBER(FN_GETCONFIGVALUE(47))", "NAME", null, null, false);
        Appz.BuildCombo(this.cmbSearchFoodCookType, "FOODCOOKTYPE", "NAME", "LOID", "ACTIVE='1'", "NAME", "ทั้งหมด", "0", false);

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
        popupFormulaSet.Show();
    }

    protected void imbReset_Click(object sender, ImageClickEventArgs e)
    {
        ClearSearch();
        gvMain.PageIndex = 0;
        doGetList();
        popupFormulaSet.Show();
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
        popupFormulaSet.Show();
    }

    #endregion

    #region Paging Event Handler

    protected void PageChange(object sender, EventArgs e)
    {
        gvMain.PageIndex = ((Templates_PageControl)sender).SelectedPageIndex;
        doGetList();
        pcBot.Update();
        pcTop.Update();
        popupFormulaSet.Show();
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
                    VFormulaSetSearchData VFormulaSetSearch = new VFormulaSetSearchData();
                    VFormulaSetSearch.FOODCOOKTYPELOID = 0;
                    VFormulaSetSearch.FOODCOOKTYPENAME = gRow.Cells[4].Text;
                    VFormulaSetSearch.FOODTYPELOID = 0;
                    VFormulaSetSearch.FOODTYPENAME = gRow.Cells[3].Text;
                    VFormulaSetSearch.FORMULANAME = gRow.Cells[5].Text;
                    VFormulaSetSearch.LOID = Convert.ToDouble("0" + gRow.Cells[0].Text);
                    arrChk.Add(VFormulaSetSearch);
                }
            }
        }
        return arrChk;
    }

    #endregion

    #region Controls Management Methods

    private void ClearSearch()
    {
        this.cmbSearchFoodCookType.SelectedIndex = 0;
        this.cmbSearchFoodType.SelectedIndex = 0;
        this.txtSearchName.Text = "";
    }

    public void Show(string existKeyList, DateTime partyDate)
    {
        this.txtExistKeyList.Text = existKeyList;
        sPartyDate = partyDate;
        ClearSearch();
        gvMain.PageIndex = 0;
        doGetList();
        popupFormulaSet.Show();
    }

    #endregion

    #region Working Method

    private void doGetList()
    {
        SearchFlow fFlow = new SearchFlow();

        // ตรวจสอบเงื่อนไขการค้นหาเพื่อแสดงปุ่ม reset การค้นหา
        imbReset.Visible = (this.cmbSearchFoodCookType.SelectedIndex != 0) || (this.cmbSearchFoodType.SelectedIndex != 0) || (txtSearchName.Text.Trim() != "");

        string orderStr = "";
        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;
        gvMain.DataSource = fFlow.GetOrderPartyList(Convert.ToDouble(this.cmbSearchFoodType.SelectedItem.Value), Convert.ToDouble(this.cmbSearchFoodCookType.SelectedItem.Value), this.txtSearchName.Text,"N" ,sPartyDate, this.txtExistKeyList.Text, orderStr);
        gvMain.DataBind();
        pcBot.Update();
        pcTop.Update();
        this.tbAdd.Visible = (gvMain.Rows.Count > 0);
    }

    #endregion
}
