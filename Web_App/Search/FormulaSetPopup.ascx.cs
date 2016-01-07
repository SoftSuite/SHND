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
/// Create by: Teang
/// Create Date: 12 Jan 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้าค้นหา ข้อมูลสูตรอาหาร (Material Master)
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
public partial class Search_FormulaSetPopup : System.Web.UI.UserControl
{
    public delegate void SelectedIndexChangedEvent(object sender, EventArgs e, ArrayList SelectedData);
    public event SelectedIndexChangedEvent SelectedIndexChanged;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        Appz.BuildCombo(this.cmbSearchFoodType, "FOODTYPE", "NAME", "LOID", "ACTIVE='1'", "NAME", "ทั้งหมด", "0", false);
        Appz.BuildCombo(this.cmbSearchFoodCategory, "FOODCATEGORY", "NAME", "LOID", "ACTIVE='1'", "NAME", "ทั้งหมด", "0", false);

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
                    VFormulaSetSearch.ACTIVENAME = "";
                    VFormulaSetSearch.ENERGY = 0;
                    VFormulaSetSearch.FOODCATEGORYLOID = 0;
                    VFormulaSetSearch.FOODCATEGORYNAME = gRow.Cells[5].Text;
                    VFormulaSetSearch.FOODTYPELOID = 0;
                    VFormulaSetSearch.FOODTYPENAME = gRow.Cells[4].Text;
                    VFormulaSetSearch.FORMULANAME = gRow.Cells[3].Text;
                    VFormulaSetSearch.ISELEMENT = "";
                    VFormulaSetSearch.ISSPECIFIC = "";
                    VFormulaSetSearch.LOID = Convert.ToDouble("0" + gRow.Cells[0].Text);
                    VFormulaSetSearch.PORTION = Convert.ToDouble("0" + gRow.Cells[6].Text);
                    VFormulaSetSearch.SPECIALTYPE = "";
                    VFormulaSetSearch.STATUS = "";
                    VFormulaSetSearch.STATUSNAME = "";
                    VFormulaSetSearch.STATUSRANK = "";
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
        chkSearchIsElement.Checked = true;
        if (this.cmbSearchFoodCategory.Enabled) this.cmbSearchFoodCategory.SelectedIndex = 0;
        if (this.cmbSearchFoodType.Enabled) this.cmbSearchFoodType.SelectedIndex = 0;
        this.txtSearchName.Text = "";
    }

    public void Show(double formulaSetID, double foodType, double foodCategory, string existKeyList)
    {
        this.txtRefFormulaSetID.Text = formulaSetID.ToString();
        this.cmbSearchFoodCategory.SelectedIndex = this.cmbSearchFoodCategory.Items.IndexOf(this.cmbSearchFoodCategory.Items.FindByValue(foodCategory.ToString()));
        this.cmbSearchFoodCategory.Enabled = false;
        this.cmbSearchFoodType.SelectedIndex = this.cmbSearchFoodType.Items.IndexOf(this.cmbSearchFoodType.Items.FindByValue(foodType.ToString()));
        this.cmbSearchFoodType.Enabled = false;
        this.txtExistKeyList.Text = existKeyList;
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
        imbReset.Visible = (this.cmbSearchFoodCategory.SelectedIndex != 0 && this.cmbSearchFoodCategory.Enabled) || (this.cmbSearchFoodType.SelectedIndex != 0 && this.cmbSearchFoodType.Enabled) || (txtSearchName.Text.Trim() != "");

        string orderStr = "";
        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;
        gvMain.DataSource = fFlow.GetFormulaSetList(Convert.ToDouble(this.txtRefFormulaSetID.Text), Convert.ToDouble(this.cmbSearchFoodType.SelectedItem.Value), 
            Convert.ToDouble(this.cmbSearchFoodCategory.SelectedItem.Value), this.txtSearchName.Text, this.chkSearchIsElement.Checked, this.txtExistKeyList.Text, orderStr);
        gvMain.DataBind();
        pcBot.Update();
        pcTop.Update();
        this.tbAdd.Visible = (gvMain.Rows.Count > 0);
    }

    #endregion
}
