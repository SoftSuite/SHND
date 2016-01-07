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
/// Create by: Teang
/// Create Date: 8 Jan 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้าค้นหา ข้อมูลวัสดุ (Material Master)
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
public partial class Search_MaterialUnitPopup : System.Web.UI.UserControl
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
                    VMaterialMasterUnitData VMaterialList = new VMaterialMasterUnitData();
                    VMaterialList.CLASSLOID = Convert.ToDouble("0" + gRow.Cells[10].Text);
                    VMaterialList.CLASSNAME = gRow.Cells[7].Text;
                    VMaterialList.COST = Convert.ToDouble("0" + gRow.Cells[6].Text);
                    VMaterialList.GROUPLOID = Convert.ToDouble("0" + gRow.Cells[11].Text);
                    VMaterialList.GROUPNAME = gRow.Cells[12].Text;
                    VMaterialList.MATERIALCODE = gRow.Cells[3].Text;
                    VMaterialList.MATERIALMASTER = Convert.ToDouble("0" + gRow.Cells[0].Text);
                    VMaterialList.MATERIALNAME = gRow.Cells[4].Text;
                    VMaterialList.SAPCODE = gRow.Cells[8].Text;
                    VMaterialList.SPEC = gRow.Cells[13].Text;
                    VMaterialList.UNIT = Convert.ToDouble("0" + gRow.Cells[9].Text);
                    VMaterialList.UNITNAME = gRow.Cells[5].Text;
                    arrChk.Add(VMaterialList);
                }
            }
        }
        return arrChk;
    }

    #endregion

    #region Controls Management Methods

    private void ClearSearch()
    {
        this.cmbSearchMaterialClass.SelectedIndex = 0;
        this.txtSearchName.Text = "";
        txhSortField.Text = "CLASSNAME, GROUPNAME, MATERIALNAME";
    }

    public void Show(string type, double docType, double materialClassID, string existMaterialMasterList, string existCodeList)
    {
        this.txtDocType.Text = docType.ToString();
        this.txtType.Text = type;
        if (docType == 0)
        {
            switch (type)
            {
                case "1" :
                    Appz.BuildCombo(this.cmbSearchMaterialClass, "MATERIALCLASS", "NAME", "LOID", "MASTERTYPE='FO' AND ACTIVE = '1'", "NAME", "ทั้งหมด", "0", false);
                    break;
                case "2" :
                    Appz.BuildCombo(this.cmbSearchMaterialClass, "MATERIALCLASS", "NAME", "LOID", "MASTERTYPE<>'FO' AND ACTIVE = '1'", "NAME", "ทั้งหมด", "0", false);
                    break;
                default :
                    Appz.BuildCombo(this.cmbSearchMaterialClass, "MATERIALCLASS", "NAME", "LOID", "ACTIVE = '1'", "NAME", "ทั้งหมด", "0", false);
                    break;
            }
        }
        else
        {
            Appz.BuildCombo(this.cmbSearchMaterialClass, "MATERIALCLASS", "NAME", "LOID", "ACTIVE = '1' AND MASTERTYPE IN (SELECT MASTERTYPE FROM DOCTYPEMASTERTYPE WHERE DOCTYPE = " + docType.ToString() + ")", "NAME", "ทั้งหมด", "0", false);
        }

        ClearSearch();
        if (materialClassID != 0)
        {
            this.cmbSearchMaterialClass.SelectedIndex = this.cmbSearchMaterialClass.Items.IndexOf(this.cmbSearchMaterialClass.Items.FindByValue(materialClassID.ToString()));
            this.cmbSearchMaterialClass.Enabled = false;
        }
        this.txtExistCodeList.Text = existCodeList;
        this.txtExistMaterialMasterList.Text = existMaterialMasterList;

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
        imbReset.Visible = (this.cmbSearchMaterialClass.SelectedIndex != 0 && this.cmbSearchMaterialClass.Enabled) || (txtSearchName.Text.Trim() != "");

        string orderStr = "";
        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;

        string otherConditions = "";
        string isStockIn = "Y";

        switch (this.txtType.Text)
        {
            case "1":
                otherConditions = "MASTERTYPE='FO'";
                break;
            case "2":
                otherConditions = "MASTERTYPE<>'FO'";
                break;
        }
        gvMain.DataSource = fFlow.GetMaterialUnitList(Convert.ToDouble("0" + this.txtDocType.Text), Convert.ToDouble(this.cmbSearchMaterialClass.SelectedItem.Value),
            this.txtSearchName.Text.Trim(), isStockIn, this.txtExistMaterialMasterList.Text, this.txtExistCodeList.Text, otherConditions, orderStr);
        gvMain.DataBind();
        pcBot.Update();
        pcTop.Update();
    }

    #endregion
}
