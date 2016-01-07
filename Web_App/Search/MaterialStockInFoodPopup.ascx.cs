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
/// MaterialStockInFoodPopup Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Somsakoon
/// Create Date: 27 Feb 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้าค้นหา ข้อมูลวัสดุอาหาร (V_Stockin_food_Popup)
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

public partial class Search_MaterialStockInFoodPopup : System.Web.UI.UserControl
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
                    VStockinFoodPopupData VStockinFoodPopup = new VStockinFoodPopupData();

                    VStockinFoodPopup.CLASSLOID = Convert.ToDouble("0" + gRow.Cells[11].Text);
                    VStockinFoodPopup.CLASSNAME = gRow.Cells[6].Text;

                    VStockinFoodPopup.GROUPLOID = Convert.ToDouble("0" + gRow.Cells[12].Text);
                    VStockinFoodPopup.GROUPNAME = gRow.Cells[13].Text;
                    VStockinFoodPopup.MATERIALCODE = gRow.Cells[3].Text;
                    VStockinFoodPopup.MATERIALMASTER = Convert.ToDouble("0" + gRow.Cells[0].Text);
                    VStockinFoodPopup.MATERIALNAME = gRow.Cells[4].Text;
                    VStockinFoodPopup.SAPCODE = gRow.Cells[9].Text;
                    VStockinFoodPopup.SPEC = gRow.Cells[14].Text;
                    VStockinFoodPopup.UNIT = Convert.ToDouble("0" + gRow.Cells[10].Text);
                    VStockinFoodPopup.UNITNAME = gRow.Cells[5].Text;
                    VStockinFoodPopup.PLANQTY = Convert.ToDouble("0" + gRow.Cells[7].Text);
                    VStockinFoodPopup.PLANREMAIN = Convert.ToDouble("0" + gRow.Cells[8].Text);
                    arrChk.Add(VStockinFoodPopup);
                }
            }
        }
        return arrChk;
    }

    #endregion

    #region Controls Management Methods

    private void ClearSearch()
    {
        this.cmbSearchPlanQTY.SelectedIndex = 0;
        this.cmbSearchMaterialClass.SelectedIndex = 0;
        this.txtSearchName.Text = "";
        txhSortField.Text = "CLASSNAME, GROUPNAME, MATERIALNAME";
    }

    public void Show(string mPlanOrder, string mMaterialClass, string existMaterialList)
    {
        this.txtDocType.Text = "";
        this.txtType.Text = "";
        Appz.BuildCombo(cmbSearchPlanQTY, "V_PLAN_FOOD_SEARCH", "NAME", "LOID", "ISPLANFOOD= 'Y' AND STATUS ='FN'", "NAME", "ทั้งหมด", "0", false);
        Appz.BuildCombo(cmbSearchMaterialClass, "MATERIALCLASS", "NAME", "LOID", "MASTERTYPE='FO' AND ACTIVE = '1'", "NAME", "ทั้งหมด", "0", false);
        this.txtSearchName.Text = "";
        this.txtExistCodeList.Text = existMaterialList;

        cmbSearchPlanQTY.SelectedValue = mPlanOrder;
        cmbSearchPlanQTY.Enabled = false;
        cmbSearchMaterialClass.SelectedValue = mMaterialClass;
        cmbSearchMaterialClass.Enabled = false;

        gvMain.PageIndex = 0;
        doGetList();
        popupMaterialMaster.Show();
    }

    

    #endregion

    #region Working Method

    private void doGetList()
    {
        SearchFlow fFlow = new SearchFlow();

        // ตรวจสอบเงื่อนไขการค้นหาเพื่อแสดงปุ่ม reset การค้นหา
        imbReset.Visible = ((this .cmbSearchPlanQTY.SelectedIndex !=0 && this.cmbSearchPlanQTY.Enabled) ||  (this.cmbSearchMaterialClass.SelectedIndex != 0 && this.cmbSearchMaterialClass.Enabled) || (txtSearchName.Text.Trim() != ""));

        string orderStr = "";
        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;

        
        gvMain.DataSource = fFlow.GetMaterialFoodStockinList(Convert.ToDouble("0" + this.cmbSearchPlanQTY.SelectedItem.Value), Convert.ToDouble("0" + this.cmbSearchMaterialClass.SelectedItem.Value), this.txtSearchName.Text.Trim(), this.txtExistCodeList.Text , orderStr);
        gvMain.DataBind();
        pcBot.Update();
        pcTop.Update();
    }

    #endregion
}
