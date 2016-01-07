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
/// MaterialMasterPopup Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Pom
/// Create Date: 12 May 2009
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
public partial class Search_MaterialStockOutWastePopup : System.Web.UI.UserControl
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
        Appz.BuildCombo(cmbMaterialClass, "MATERIALCLASS", "NAME", "LOID", "MASTERTYPE = 'FO' AND ACTIVE = '1'", "NAME", "เลือก", "0", false);
        Appz.BuildCombo(cmbMaterialGroup, "MATERIALGROUP", "NAME", "LOID", "ACTIVE = '1'", "NAME", "เลือก", "0", false);
        pcBot.SetMainGridView(gvMain);
        pcTop.SetMainGridView(gvMain);
    }

    #region Button Click Event Handler

    protected void tbBackClick(object sender, EventArgs e)
    {
        txtExistKeyList.Text = "";
        if (Cancel != null) Cancel(sender, e);
    }

    protected void imbSearch_Click(object sender, ImageClickEventArgs e)
    {
        gvMain.PageIndex = 0;
        doGetList();
        popupMaterialMaster.Show();
    }

    protected void tbAddClick(object sender, EventArgs e)
    {
        txtExistKeyList.Text = "";
        if (SelectedIndexChanged != null) SelectedIndexChanged(sender, e, GetSelectedData());
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

    #region Controls Management Methods

    private void ClearSearch()
    {
        txtName.Text = "";
        cmbMaterialGroup.SelectedIndex = -1;
    }

    public void Show(double warehouse, string existKeyList)
    {
        this.txtExistKeyList.Text = existKeyList;
        this.txtWarehouse.Text = warehouse.ToString();

        //this.cmbMaterialClass.SelectedIndex = this.cmbMaterialClass.Items.IndexOf(this.cmbMaterialClass.Items.FindByValue(materialclass));
        //this.cmbMaterialClass.Enabled = false;
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

    #endregion

    #region Working Method

    private void doGetList()
    {
        SearchFlow fFlow = new SearchFlow();

        gvMain.DataSource = fFlow.GetMaterialStockOutWasteList(this.txtName.Text,Convert.ToDouble(cmbMaterialClass.SelectedItem.Value), Convert.ToDouble(cmbMaterialGroup.SelectedItem.Value),Convert.ToDouble(txtWarehouse.Text), txtExistKeyList.Text, "CLASSNAME, GROUPNAME, MATERIALNAME");
        gvMain.DataBind();
        pcBot.Update();
        pcTop.Update();
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
                    VMaterialMasterData VMaterialMaster = new VMaterialMasterData();
                    VMaterialMaster.LOID = Convert.ToDouble("0" + gRow.Cells[0].Text);
                    VMaterialMaster.SAPCODE = gRow.Cells[3].Text;
                    VMaterialMaster.MATERIALNAME = gRow.Cells[4].Text;
                    VMaterialMaster.ULOID = Convert.ToDouble("0" + gRow.Cells[6].Text);
                    VMaterialMaster.THNAME = gRow.Cells[5].Text;
                    arrChk.Add(VMaterialMaster);
                }
            }
        }
        return arrChk;
    }

    #endregion
}
