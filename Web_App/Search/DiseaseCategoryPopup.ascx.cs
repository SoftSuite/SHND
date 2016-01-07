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
using SHND.Data.Views;
using SHND.Flow.Search;
using SHND.Global;

/// <summary>
/// DiseaseCategoryPopup Page Class
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
///    หน้าค้นหา ข้อมูลชนิดของสารอาหารเฉพาะโรค (Disease Category)
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
public partial class Search_DiseaseCategoryPopup : System.Web.UI.UserControl
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
        if (SelectedIndexChanged != null) SelectedIndexChanged(sender, e, GetSelectedData());
    }

    protected void tbAddClick(object sender, EventArgs e)
    {
        if (SelectedIndexChanged != null) SelectedIndexChanged(sender, e, GetSelectedData());
    }

    protected void imbSearch_Click(object sender, ImageClickEventArgs e)
    {
        gvMain.PageIndex = 0;
        doGetList();
        popupDiseaseCategory.Show();
    }

    protected void imbReset_Click(object sender, ImageClickEventArgs e)
    {
        ClearSearch();
        gvMain.PageIndex = 0;
        doGetList();
        popupDiseaseCategory.Show();
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
            ControlUtil.SetDblTextBox((TextBox)e.Row.Cells[15].FindControl("txtQty"));
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
        popupDiseaseCategory.Show();
    }

    #endregion

    #region Paging Event Handler

    protected void PageChange(object sender, EventArgs e)
    {
        gvMain.PageIndex = ((Templates_PageControl)sender).SelectedPageIndex;
        doGetList();
        pcBot.Update();
        pcTop.Update();
        popupDiseaseCategory.Show();
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
                    VDiseaseCategoryData VDiseaseCategory = new VDiseaseCategoryData();
                    CheckBox chkHigh = (CheckBox)gRow.Cells[12].FindControl("chkHigh");
                    CheckBox chkLow = (CheckBox)gRow.Cells[13].FindControl("chkLow");
                    CheckBox chkNon = (CheckBox)gRow.Cells[14].FindControl("chkNon");
                    VDiseaseCategory.ABBNAME = gRow.Cells[3].Text;
                    VDiseaseCategory.ACTIVE = "";
                    VDiseaseCategory.DESCRIPTION = gRow.Cells[4].Text;
                    VDiseaseCategory.IMGSYMBOL = "";
                    VDiseaseCategory.ISABSTAIN = gRow.Cells[9].Text;
                    VDiseaseCategory.ISCALCULATE = gRow.Cells[7].Text;
                    VDiseaseCategory.ISHIGH = (chkHigh.Visible && chkHigh.Checked ? "Y" : "N");
                    VDiseaseCategory.ISINCREASE = gRow.Cells[8].Text;
                    VDiseaseCategory.ISLIGHT = "";
                    VDiseaseCategory.ISLIMIT = gRow.Cells[6].Text;
                    VDiseaseCategory.ISLIQUID = "";
                    VDiseaseCategory.ISLOW = (chkLow.Visible && chkLow.Checked ? "Y" : "N");
                    VDiseaseCategory.ISNEED = gRow.Cells[10].Text;
                    VDiseaseCategory.ISNON = (chkNon.Visible && chkNon.Checked ? "Y" : "N");
                    VDiseaseCategory.ISREGULAR = "";
                    VDiseaseCategory.ISREQUEST = gRow.Cells[11].Text;
                    VDiseaseCategory.ISSOFT = "";
                    VDiseaseCategory.ISSPECIAL = gRow.Cells[5].Text;
                    VDiseaseCategory.LOID = Convert.ToDouble("0" + gRow.Cells[0].Text);
                    VDiseaseCategory.QTY = Convert.ToDouble("0" + ((TextBox)gRow.Cells[15].FindControl("txtQty")).Text);
                    VDiseaseCategory.UNIT = Convert.ToDouble("0" + gRow.Cells[17].Text.Replace("&nbsp;", ""));
                    VDiseaseCategory.UNITNAME = gRow.Cells[16].Text.Replace("&nbsp;", "");
                    arrChk.Add(VDiseaseCategory);
                }
            }
        }
        return arrChk;
    }

    #endregion

    #region Controls Management Methods

    private void ClearSearch()
    {
        txtSearchDiseaseAbb.Text = "";
        txtSearchDiseaseDesc.Text = "";
    }

    public void Show(bool isSpecific, bool isIncrease, bool isLimit, bool isCalculate, string cDiseaseCategory, string existKeyList)
    {
        this.txtType.Text = "2";
        this.cmbSearchCategory.Items.Clear();
        this.cmbSearchCategory.Items.Add(new ListItem("ทั้งหมด", ""));
        if (isSpecific) this.cmbSearchCategory.Items.Add(new ListItem("อาหารเฉพาะโรค", "1"));
        if (isLimit) this.cmbSearchCategory.Items.Add(new ListItem("อาหารจำกัดปริมาณ", "2"));
        if (isCalculate) this.cmbSearchCategory.Items.Add(new ListItem("อาหารคำนวณพลังงาน", "3"));
        if (isIncrease) this.cmbSearchCategory.Items.Add(new ListItem("อาหารเสริม", "4"));
        
        this.gvMain.Columns[5].Visible = false;
        this.gvMain.Columns[6].Visible = false;
        this.gvMain.Columns[7].Visible = false;
        this.gvMain.Columns[8].Visible = false;
        this.gvMain.Columns[9].Visible = false;
        this.gvMain.Columns[10].Visible = false;
        this.gvMain.Columns[11].Visible = false;

        ClearSearch();
        this.txtExistKeyList.Text = existKeyList;
        this.txtCategoryUse.Text = cDiseaseCategory;
        gvMain.PageIndex = 0;
        doGetList();
        popupDiseaseCategory.Show();
    }

    public void Show(bool isAbstain, bool isNeed, bool isRequest, string cDiseaseCategory, string existKeyList)
    {
        this.txtType.Text = "3";
        this.cmbSearchCategory.Items.Clear();
        this.cmbSearchCategory.Items.Add(new ListItem("ทั้งหมด", ""));
        if (isAbstain) this.cmbSearchCategory.Items.Add(new ListItem("อาหารที่งด", "1"));
        if (isNeed) this.cmbSearchCategory.Items.Add(new ListItem("อาหารที่รับเฉพาะ", "2"));
        if (isRequest) this.cmbSearchCategory.Items.Add(new ListItem("อาหารที่ขอ", "3"));

        this.gvMain.Columns[5].Visible = false;
        this.gvMain.Columns[6].Visible = false;
        this.gvMain.Columns[7].Visible = false;
        this.gvMain.Columns[8].Visible = false;
        this.gvMain.Columns[9].Visible = false;
        this.gvMain.Columns[10].Visible = false;
        this.gvMain.Columns[11].Visible = false;
        this.gvMain.Columns[12].Visible = false;
        this.gvMain.Columns[13].Visible = false;
        this.gvMain.Columns[14].Visible = false;
        this.gvMain.Columns[15].Visible = false;
        this.gvMain.Columns[16].Visible = false;

        ClearSearch();
        this.txtExistKeyList.Text = existKeyList;
        this.txtCategoryUse.Text = cDiseaseCategory;
        gvMain.PageIndex = 0;
        doGetList();
        popupDiseaseCategory.Show();
    }

    public void Show(string type,string cDiseaseCategory, string existKeyList)
    {
        this.txtType.Text = type;
        if (type == "1")
        {
            this.cmbSearchCategory.Items.Clear();
            this.cmbSearchCategory.Items.Add(new ListItem("ทั้งหมด", ""));
            this.cmbSearchCategory.Items.Add(new ListItem("ชนิดอาหารเฉพาะโรค", "1"));
            this.cmbSearchCategory.Items.Add(new ListItem("ชนิดอาหารจำกัดปริมาณ", "2"));
            this.cmbSearchCategory.Items.Add(new ListItem("ชนิดอาหารคำนวณพลังงาน", "3"));
            this.cmbSearchCategory.Items.Add(new ListItem("ชนิดอาหารเสริม", "4"));
            this.cmbSearchCategory.Items.Add(new ListItem("ชนิดอาหารที่ผู้ป่วยขอรับเฉพาะ","5"));
            this.cmbSearchCategory.Items.Add(new ListItem("ชนิดอาหารที่ผู้ป่วยไม่ขอรับ/งด", "6"));
            this.cmbSearchCategory.Items.Add(new ListItem("ชนิดอาหารที่ผู้ป่วยขอ", "7"));
            this.gvMain.Columns[5].Visible = false;
            this.gvMain.Columns[6].Visible = false;
            this.gvMain.Columns[7].Visible = false;
            this.gvMain.Columns[8].Visible = false;
            this.gvMain.Columns[9].Visible = false;
            this.gvMain.Columns[10].Visible = false;
            this.gvMain.Columns[11].Visible = false;
            this.gvMain.Columns[15].Visible = false;
            this.gvMain.Columns[16].Visible = false;
            this.gvMain.Columns[17].Visible = false;
        }
        ClearSearch();
        this.txtExistKeyList.Text = existKeyList;
        this.txtCategoryUse.Text = cDiseaseCategory;
        gvMain.PageIndex = 0;
        doGetList();
        popupDiseaseCategory.Show();
    }

    #endregion

    #region Working Method

    private void doGetList()
    {
        SearchFlow fFlow = new SearchFlow();
        string otherCondition = "";

        // ตรวจสอบเงื่อนไขการค้นหาเพื่อแสดงปุ่ม reset การค้นหา
        imbReset.Visible = (txtSearchDiseaseAbb.Text.Trim() != "") || (txtSearchDiseaseDesc.Text.Trim() != "");

        string orderStr = "";
        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;

        if (this.txtType.Text == "1" || this.txtType.Text == "2")
        {
            for (int i = 0; i < this.cmbSearchCategory.Items.Count; ++i)
            {
                if (this.cmbSearchCategory.Items[i].Value == "1") otherCondition += (otherCondition == "" ? "" : "OR ") + "ISSPECIAL = 'Y' ";
                if (this.cmbSearchCategory.Items[i].Value == "2") otherCondition += (otherCondition == "" ? "" : "OR ") + "ISLIMIT = 'Y' ";
                if (this.cmbSearchCategory.Items[i].Value == "3") otherCondition += (otherCondition == "" ? "" : "OR ") + "ISCALCULATE = 'Y' ";
                if (this.cmbSearchCategory.Items[i].Value == "4") otherCondition += (otherCondition == "" ? "" : "OR ") + "ISINCREASE = 'Y' ";
                if (this.cmbSearchCategory.Items[i].Value == "5") otherCondition += (otherCondition == "" ? "" : "OR ") + "ISNEED = 'Y' ";
                if (this.cmbSearchCategory.Items[i].Value == "6") otherCondition += (otherCondition == "" ? "" : "OR ") + "ISABSTAIN = 'Y' ";
                if (this.cmbSearchCategory.Items[i].Value == "7") otherCondition += (otherCondition == "" ? "" : "OR ") + "ISREQUEST = 'Y' ";

            }
            gvMain.DataSource = fFlow.GetDiseaseCategoryList(txtSearchDiseaseAbb.Text, txtSearchDiseaseDesc.Text, 
                (this.cmbSearchCategory.SelectedItem.Value == "1" ? "Y" : ""),
                (this.cmbSearchCategory.SelectedItem.Value == "2" ? "Y" : ""), 
                (this.cmbSearchCategory.SelectedItem.Value == "3" ? "Y" : ""),
                (this.cmbSearchCategory.SelectedItem.Value == "4" ? "Y" : ""),
                (this.cmbSearchCategory.SelectedItem.Value == "5" ? "Y" : ""),
                (this.cmbSearchCategory.SelectedItem.Value == "6" ? "Y" : ""),
                (this.cmbSearchCategory.SelectedItem.Value == "7" ? "Y" : ""),this.txtCategoryUse.Text, 
                txtExistKeyList.Text, "(" + otherCondition + ")", orderStr);
        }
        else if (this.txtType.Text == "3")
        {
            for (int i = 0; i < this.cmbSearchCategory.Items.Count; ++i)
            {
                if (this.cmbSearchCategory.Items[i].Value == "1") otherCondition += (otherCondition == "" ? "" : "OR ") + "ISABSTAIN = 'Y' ";
                if (this.cmbSearchCategory.Items[i].Value == "2") otherCondition += (otherCondition == "" ? "" : "OR ") + "ISNEED = 'Y' ";
                if (this.cmbSearchCategory.Items[i].Value == "3") otherCondition += (otherCondition == "" ? "" : "OR ") + "ISREQUEST = 'Y' ";
            }
            gvMain.DataSource = fFlow.GetDiseaseCategoryList(txtSearchDiseaseAbb.Text, txtSearchDiseaseDesc.Text, (this.cmbSearchCategory.SelectedItem.Value == "1" ? "Y" : ""),
                (this.cmbSearchCategory.SelectedItem.Value == "2" ? "Y" : ""), 
                (this.cmbSearchCategory.SelectedItem.Value == "3" ? "Y" : ""),txtCategoryUse.Text, txtExistKeyList.Text, "(" + otherCondition + ")", orderStr);
        }
        gvMain.DataBind();
        pcBot.Update();
        pcTop.Update();
    }

    #endregion
}
