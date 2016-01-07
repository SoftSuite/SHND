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
public partial class Search_MaterialMaster100Popup : System.Web.UI.UserControl
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
        this.cmbSearchMasterType.Items.Clear();
        this.cmbSearchMasterType.Items.Add(new ListItem("ทั้งหมด", ""));
        this.cmbSearchMasterType.Items.Add(new ListItem("นมผสมสำหรับเด็ก", "MI"));
        this.cmbSearchMasterType.Items.Add(new ListItem("ยาและเวชภัณฑ์", "DU"));
        this.cmbSearchMasterType.Items.Add(new ListItem("วัสดุอาหาร 7 หมวด", "FO"));
        this.cmbSearchMasterType.Items.Add(new ListItem("วัสดุอุปกรณ์ เครื่องมือ ภาชนะ", "TL"));
        this.cmbSearchMasterType.Items.Add(new ListItem("วัสดุอื่นๆ", "OT"));
        this.cmbSearchMasterType.Items.Add(new ListItem("อาหารทางสายให้อาหาร", "MD"));
        //SetMaterialClass();

        pcBot.SetMainGridView(gvMain);
        pcTop.SetMainGridView(gvMain);
    }

    protected void cmbSearchMasterType_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetMaterialClass();
        popupMaterialMaster.Show();
    }
    protected void cmbSearchMaterialClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetMaterialGroup();
        popupMaterialMaster.Show();
    }

    #region Button Click Event Handler

    protected void tbBackClick(object sender, EventArgs e)
    {
        if (Cancel != null) Cancel(sender, e);
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
                    VMaterialMasterData VMaterialMaster = new VMaterialMasterData();
                    VMaterialMaster.ACTIVE = "";
                    VMaterialMaster.ACTIVENAME = "";
                    VMaterialMaster.ARTICLECODE = "";
                    VMaterialMaster.CARBOHYDRATE = Convert.ToDouble("0" + gRow.Cells[12].Text);
                    VMaterialMaster.CLASSLOID = 0;
                    VMaterialMaster.CLASSNAME = gRow.Cells[7].Text;
                    VMaterialMaster.COST = 0;
                    VMaterialMaster.DIVISIONNAME = gRow.Cells[5].Text;
                    VMaterialMaster.DIVLOID = 0;
                    VMaterialMaster.ENERGY100G = Convert.ToDouble("0" + gRow.Cells[10].Text);
                    VMaterialMaster.ENERGYBYUNIT = Convert.ToDouble("0" + gRow.Cells[11].Text);
                    VMaterialMaster.FAT = Convert.ToDouble("0" + gRow.Cells[14].Text);
                    VMaterialMaster.GROUPLOID = 0;
                    VMaterialMaster.GROUPNAME = gRow.Cells[0].Text;
                    VMaterialMaster.ISCOUNT = "";
                    VMaterialMaster.LOID = Convert.ToDouble("0" + gRow.Cells[0].Text);
                    VMaterialMaster.MASTERTYPE = "";
                    VMaterialMaster.MASTERTYPENAME = gRow.Cells[8].Text;
                    VMaterialMaster.MATERIALCODE = gRow.Cells[3].Text;
                    VMaterialMaster.MATERIALNAME = gRow.Cells[4].Text;
                    VMaterialMaster.MAXSTOCK = 0;
                    VMaterialMaster.MINSTOCK = 0;
                    VMaterialMaster.ORDERTYPE = "";
                    VMaterialMaster.ORDERTYPENAME = "";
                    VMaterialMaster.PRICE = 0;
                    VMaterialMaster.PROTEIN = Convert.ToDouble("0" + gRow.Cells[13].Text);
                    VMaterialMaster.REMARKS = "";
                    VMaterialMaster.SAPCODE = "";
                    VMaterialMaster.SAPWAREHOUSELOID = 0;
                    VMaterialMaster.SAPWAREHOUSENAME = "";
                    VMaterialMaster.SODIUM = Convert.ToDouble("0" + gRow.Cells[15].Text);
                    VMaterialMaster.SPEC = "";
                    VMaterialMaster.STOCKINTYPE = "";
                    VMaterialMaster.STOCKINTYPENAME = "";
                    VMaterialMaster.STOCKOUTBREAKFAST = "";
                    VMaterialMaster.STOCKOUTDINNER = "";
                    VMaterialMaster.STOCKOUTLUNCH = "";
                    VMaterialMaster.THNAME = "";
                    VMaterialMaster.ULOID = Convert.ToDouble("0" + gRow.Cells[16].Text);
                    VMaterialMaster.UNITNAME = gRow.Cells[17].Text;
                    VMaterialMaster.WEIGHT = Convert.ToDouble("0" + gRow.Cells[9].Text);
                    VMaterialMaster.PHOSPHORUS = Convert.ToDouble("0" + gRow.Cells[18].Text);
                    VMaterialMaster.POTASSIUM = Convert.ToDouble("0" + gRow.Cells[19].Text);
                    VMaterialMaster.CALCIUM = Convert.ToDouble("0" + gRow.Cells[20].Text);
                    arrChk.Add(VMaterialMaster);
                }
            }
        }
        return arrChk;
    }

    #endregion

    #region Controls Management Methods

    private void ClearSearch()
    {
        if(this.cmbSearchMasterType.Enabled) this.cmbSearchMasterType.SelectedIndex = 0;
        this.cmbSearchMaterialClass.SelectedIndex = 0;
        this.cmbSearchMaterialGroup.SelectedIndex = 0;
        this.txtSearchCode.Text = "";
        this.txtSearchName.Text = "";
    }

    public void Show(string type)
    {
        Show(type, "");
    }

    public void Show(string type, string existKeyList)
    {
        this.txtExistKeyList.Text = existKeyList;
        if (type == "1")
        {
            this.cmbSearchMasterType.SelectedIndex = this.cmbSearchMasterType.Items.IndexOf(this.cmbSearchMasterType.Items.FindByValue("FO"));
            this.cmbSearchMasterType.Enabled = false;
            SetMaterialClass();
            ClearSearch();
        }
        else if (type == "2")
        {
            this.cmbSearchMasterType.SelectedIndex = this.cmbSearchMasterType.Items.IndexOf(this.cmbSearchMasterType.Items.FindByValue("MD"));
            this.cmbSearchMasterType.Enabled = false;
            SetMaterialClass();
            ClearSearch();
        }
        else
        {
            SetMaterialClass();
            ClearSearch();
        }

        gvMain.PageIndex = 0;
        doGetList();
        popupMaterialMaster.Show();
    }

    #endregion

    #region Working Method

    private void SetMaterialClass()
    {
        Appz.BuildCombo(this.cmbSearchMaterialClass, "MATERIALCLASS", "NAME", "LOID", "MASTERTYPE='" + this.cmbSearchMasterType.SelectedItem.Value + "' AND ACTIVE = '1'", "NAME", "ทั้งหมด", "0", false);
        //this.cmbSearchMaterialClass.SelectedIndex = 0;
        SetMaterialGroup();
    }

    private void SetMaterialGroup()
    {
        Appz.BuildCombo(this.cmbSearchMaterialGroup, "MATERIALGROUP", "NAME", "LOID", "MATERIALCLASS=" + this.cmbSearchMaterialClass.SelectedItem.Value + " AND ACTIVE = '1'", "NAME", "ทั้งหมด", "0", false);
        //this.cmbSearchMaterialGroup.SelectedIndex = 0;
    }

    private void doGetList()
    {
        SearchFlow fFlow = new SearchFlow();

        // ตรวจสอบเงื่อนไขการค้นหาเพื่อแสดงปุ่ม reset การค้นหา
        imbReset.Visible = (this.cmbSearchMaterialClass.SelectedIndex != 0) || (this.cmbSearchMaterialGroup.SelectedIndex != 0) || (txtSearchCode.Text.Trim() != "") || (txtSearchName.Text.Trim() != "");

        string orderStr = "";
        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;
        MaterialMasterPopupData condition = new MaterialMasterPopupData();
        condition.Active = "1";
        condition.Code = this.txtSearchCode.Text.Trim();
        condition.MasterType = this.cmbSearchMasterType.SelectedItem.Value;
        condition.MaterialClass = Convert.ToDouble(this.cmbSearchMaterialClass.SelectedItem.Value);
        condition.MaterialGroup = Convert.ToDouble(this.cmbSearchMaterialGroup.SelectedItem.Value);
        condition.Name = this.txtSearchName.Text.Trim();
        gvMain.DataSource = fFlow.GetMaterialMasterList(condition, "", this.txtExistKeyList.Text, orderStr);
        gvMain.DataBind();
        pcBot.Update();
        pcTop.Update();
    }

    #endregion
}
