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
/// Create Date: 30 Jul 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้าค้นหา หอผู้ป่วย(Material Master)
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
public partial class Search_DivisionPopup : System.Web.UI.UserControl
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

    //protected void imbSearch_Click(object sender, ImageClickEventArgs e)
    //{
    //    gvMain.PageIndex = 0;
    //    doGetList();
    //    popupMaterialMaster.Show();
    //}

    //protected void imbReset_Click(object sender, ImageClickEventArgs e)
    //{
    //    ClearSearch();
    //    gvMain.PageIndex = 0;
    //    doGetList();
    //    popupMaterialMaster.Show();
    //}

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
            txhSortField.Text = "NAME";
        }
        else
        {
            if (txhSortField.Text == e.SortExpression)
                txhSortDir.Text = (txhSortDir.Text.Trim() == "" ? "DESC" : "");
            else
                txhSortField.Text = e.SortExpression;
        }
        doGetList();
        popupWard.Show();
    }

    #endregion

    #region Paging Event Handler

    protected void PageChange(object sender, EventArgs e)
    {
        gvMain.PageIndex = ((Templates_PageControl)sender).SelectedPageIndex;
        doGetList();
        pcBot.Update();
        pcTop.Update();
        popupWard.Show();
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
                    VWelfareRightItemData VDivisionList = new VWelfareRightItemData();
                    VDivisionList.DIVISION = Convert.ToDouble("0" + gRow.Cells[0].Text);
                    VDivisionList.DIVISIONNAME = gRow.Cells[3].Text;
                    VDivisionList.ISOVER = "N";
                    VDivisionList.QTY = 0;
                    VDivisionList.QTYRIGHT = 0;
                    arrChk.Add(VDivisionList);
                }
            }
        }
        return arrChk;
    }

    #endregion

    #region Controls Management Methods

    //private void ClearSearch()
    //{
    //    txhSortField.Text = "WARDNAME";
    //}

    public void Show(string existWardList)
    {
        this.txtExistMaterialMasterList.Text = existWardList;

        gvMain.PageIndex = 0;
        doGetList();
        popupWard.Show();
    }

    #endregion

    #region Working Method

    private void doGetList()
    {
        SearchFlow fFlow = new SearchFlow();

        // ตรวจสอบเงื่อนไขการค้นหาเพื่อแสดงปุ่ม reset การค้นหา
      //  imbReset.Visible = (this.cmbSearchMaterialClass.SelectedIndex != 0 && this.cmbSearchMaterialClass.Enabled) || (txtSearchName.Text.Trim() != "");

        string orderStr = " NAME ";
        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;

        gvMain.DataSource = fFlow.GetDivisionList(this.txtExistMaterialMasterList.Text, orderStr);
        gvMain.DataBind();
        pcBot.Update();
        pcTop.Update();
    }

    #endregion
}
