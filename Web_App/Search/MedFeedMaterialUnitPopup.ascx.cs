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
/// MedFeedMaterialUnitPopup Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Nang
/// Create Date: 12 May 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้าค้นหา ข้อมูลชนิดอาหาร (Material Master)
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

public partial class Search_MedFeedMaterialUnitPopup : System.Web.UI.UserControl
{
    public delegate void SelectedIndexChangedEvent(object sender, EventArgs e, ArrayList SelectedData);
    public event SelectedIndexChangedEvent SelectedIndexChanged;
    public delegate void CancelEvent(object sender, EventArgs e);
    public event CancelEvent Cancel;


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
        if (Cancel != null) Cancel(sender, e);
    }
    //protected void tbAddClick(object sender, EventArgs e)
    //{
    //    if (SelectedIndexChanged != null) SelectedIndexChanged(sender, e, GetSelectedData());
    //}


    protected void imbSearch_Click(object sender, ImageClickEventArgs e)
    {
        gvMain.PageIndex = 0;
        doGetList();
        popupMaterialMaster.Show();
    }

    protected void ImgSelectClick(object sender, ImageClickEventArgs e)
    {
        if (SelectedIndexChanged != null) SelectedIndexChanged(sender, e, GetSelectedData(sender));
    }
    #endregion

    #region Gridview Event Handler

    protected void gvMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
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

    private ArrayList GetSelectedData(object sender)
    {
        ArrayList arrChk = new ArrayList();
        ImageButton imgSelect = (ImageButton)sender;
        if (imgSelect.ToolTip != null)
        {
            int rowindex = Convert.ToInt32(imgSelect.ToolTip);
            GridViewRow gRow = gvMain.Rows[rowindex];
            VMaterialMasterUnitData VMaterialList = new VMaterialMasterUnitData();
            VMaterialList.MATERIALMASTER = Convert.ToDouble("0" + gRow.Cells[0].Text);
            VMaterialList.MATERIALNAME = gRow.Cells[3].Text;
            VMaterialList.UNITNAME = gRow.Cells[4].Text;
            VMaterialList.CODE = gRow.Cells[5].Text;
            VMaterialList.MATERIALCODE = gRow.Cells[6].Text;
            VMaterialList.SAPCODE = gRow.Cells[7].Text;
            VMaterialList.UNIT = Convert.ToDouble("0" + gRow.Cells[8].Text);
            VMaterialList.WEIGHT = Convert.ToDouble("0" + gRow.Cells[9].Text);
            VMaterialList.COST = Convert.ToDouble("0" + gRow.Cells[10].Text);
            VMaterialList.PRICE = Convert.ToDouble("0" + gRow.Cells[11].Text);
            VMaterialList.MULTIPLY = Convert.ToDouble("0" + gRow.Cells[12].Text);
            VMaterialList.ISSTOCKIN = gRow.Cells[13].Text;
            VMaterialList.ISSTOCKOUT = gRow.Cells[14].Text;
            VMaterialList.ISFORMULA = gRow.Cells[15].Text;
            VMaterialList.ACTIVE = gRow.Cells[16].Text;
            VMaterialList.ISMAIN = gRow.Cells[17].Text;
            VMaterialList.MASTERTYPE = gRow.Cells[18].Text;
            VMaterialList.MASTERTYPENAME = gRow.Cells[19].Text;
            VMaterialList.CLASSLOID = Convert.ToDouble("0" + gRow.Cells[20].Text);
            VMaterialList.GROUPLOID = Convert.ToDouble("0" + gRow.Cells[21].Text);
            VMaterialList.GROUPNAME = gRow.Cells[22].Text;
            VMaterialList.CLASSNAME = gRow.Cells[23].Text;
            VMaterialList.SPEC = gRow.Cells[24].Text;
            VMaterialList.LOID = Convert.ToDouble("0" + gRow.Cells[25].Text);
            arrChk.Add(VMaterialList);
        }
        return arrChk;
    }

    #endregion

    #region Controls Management Methods

    private void ClearSearch()
    {
        this.txtSearchMMName.Text = "";
        txhSortField.Text = "CLASSNAME, GROUPNAME, MATERIALNAME";
    }

    public void Show(string type, string existKeyList)
    {
        this.txtExistKeyList.Text = existKeyList;
        if (type != "0")
        {
            ClearSearch();
        }

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

        string orderStr = "";
        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;

        gvMain.DataSource = fFlow.GetMedFedMaterialUnitList(this.txtSearchMMName.Text.Trim(),this.txtExistKeyList.Text, orderStr);
        gvMain.DataBind();
        pcBot.Update();
        pcTop.Update();
    }

    #endregion
}
