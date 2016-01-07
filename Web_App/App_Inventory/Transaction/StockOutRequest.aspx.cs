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
using SHND.Data.Common.Utilities;
using SHND.Data.Inventory;
using SHND.Data.Tables;
using SHND.Data.Views;
using SHND.Flow.Inventory;
using SHND.Global;

/// <summary>
/// StockOutRequest Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Teang
/// Create Date: 23 Feb 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้าการทำรายการข้อมูล StockOutRequest
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
public partial class App_Inventory_Transaction_StockOutRequest : System.Web.UI.Page
{
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        ControlUtil.SetMinusIntTextBox(this.txtDiscountFormula);
        ControlUtil.SetMinusIntTextBox(this.txtDiscountOrder);
        this.tbAddFromMenu.ClientClick = "if (document.getElementById('" + this.cmbDocType.ClientID + "').value != '6' || document.getElementById('" + this.cmbDocType.ClientID + "').value == '0') " +
            "{ alert('สำหรับประเภทการเบิกจ่ายวัสดุอาหารเท่านั้น'); return false; } " +
            "else if (document.getElementById('" + this.ctlUseDate.CalendarClientID + "').value == '') { alert('" + string.Format(DataResources.MSGEI001, "วันที่ใช้") + "'); return false; } " +
            "else if (!(document.getElementById('" + this.chkIsBreakfast.ClientID + "').checked || document.getElementById('" + this.chkIsDinner.ClientID + "').checked || document.getElementById('" + this.chkIsLunch.ClientID + "').checked)) " +
            "{ alert('" + string.Format(DataResources.MSGEI002, "มื้อที่ใช้") + "'); return false; } else return true;";
        this.tbAddOthers.ClientClick = "if (document.getElementById('" + this.cmbDocType.ClientID + "').value == '0') " +
            "{ alert('" + string.Format(DataResources.MSGEI001, "ประเภทการเบิก") + "'); return false; } ";
        this.imbCalculateFormula.OnClientClick = "return (parseFloat(document.getElementById('" + this.txtDiscountFormula.ClientID + "').value=='' ? '0' : document.getElementById('" + this.txtDiscountFormula.ClientID + "').value) != 0);";
        this.imbCalculateOrder.OnClientClick = "return (parseFloat(document.getElementById('" + this.txtDiscountOrder.ClientID + "').value=='' ? '0' : document.getElementById('" + this.txtDiscountOrder.ClientID + "').value) != 0);";

        Appz.BuildCombo(this.cmbDivision, "DIVISION", "NAME", "LOID", "ACTIVE = '1'", "NAME", "เลือก", "0", false);
        Appz.BuildCombo(this.cmbDocType, "DOCTYPE", "DOCNAME", "LOID", "ISSTOCKOUT = 'Y'", "DOCNAME", "เลือก", "0", false);
        Appz.BuildCombo(this.cmbWarehouse, "WAREHOUSE", "NAME", "LOID", "ISVIRTUAL='N' AND ACTIVE = '1'", "NAME", "เลือก", "0", false);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            doGetDetail((Request["loid"] == null ? "0" : Request["loid"]));
        }
    }

    protected void ctlUseDate_SelectedDateChanged(object sender, EventArgs e)
    {
        UpdateStockOutItemFromMenu();
    }
    protected void chkIsBreakfast_CheckedChanged(object sender, EventArgs e)
    {
        UpdateStockOutItemFromMenu();
    }
    protected void chkIsLunch_CheckedChanged(object sender, EventArgs e)
    {
        UpdateStockOutItemFromMenu();
    }
    protected void chkIsDinner_CheckedChanged(object sender, EventArgs e)
    {
        UpdateStockOutItemFromMenu();
    }

    protected void ctlMenuStockOut_SelectedIndexChanged(object sender, EventArgs e, ArrayList arrData)
    {
        StockOutRequestDetailItem fsItem = new StockOutRequestDetailItem();
        if (fsItem.InsertStockOutItemOrder(Convert.ToDouble("0" + this.txtLOID.Text), arrData))
        {
            this.gvMain.DataBind();
            CalculateNetPrice();
        }
    }

    protected void ctMaterialUnit_SelectedIndexChanged(object sender, EventArgs e, ArrayList arrData)
    {
        StockOutRequestDetailItem fsItem = new StockOutRequestDetailItem();
        if (fsItem.InsertStockOutItemOther(Convert.ToDouble("0" + this.txtLOID.Text), arrData))
        {
            this.gvMain.DataBind();
            CalculateNetPrice();
        }
    }

    protected void cmbDocType_SelectedIndexChanged(object sender, EventArgs e)
    {
        StockOutRequestDetailItem item = new StockOutRequestDetailItem();
        item.ClearData();
        this.gvMain.DataBind();
        CalculateNetPrice();
    }

    #region Button Click Event Handler

    #region Main Toolbar
    protected void tbSaveClick(object sender, EventArgs e)
    {
        doSave();
    }
    protected void tbCancelClick(object sender, EventArgs e)
    {
        doGetDetail("0" + this.txtLOID.Text);
    }
    protected void tbBackClick(object sender, EventArgs e)
    {
        Response.Redirect(Constant.HomeFolder + "App_Inventory/Transaction/StockOutRequestSearch.aspx");
    }
    protected void tbSendClick(object sender, EventArgs e)
    {
        doSave("SE", true);
    }
    #endregion

    #region StockOutItem Toolbar
    protected void tbAddFromMenuClick(object sender, EventArgs e)
    {
        AddStockOutItemFromMenu();
    }
    protected void tbAddOthersClick(object sender, EventArgs e)
    {
        AddStockOutItemFromOthers();
    }
    protected void tbDeleteClick(object sender, EventArgs e)
    {
        DeleteStockOutItem();
    }
    protected void imbCalculateOrder_Click(object sender, ImageClickEventArgs e)
    {
        AdjustQtyOrder();
    }
    protected void imbCalculateFormula_Click(object sender, ImageClickEventArgs e)
    {
        AdjustQtyFormula();
    }
    #endregion

    #endregion

    #region Misc. Methods

    private ArrayList GetCheckedStockOutItem()
    {
        ArrayList arrChk = new ArrayList();
        for (int i = 0; i < gvMain.Rows.Count; i++)
        {
            if (i > -1 && gvMain.Rows[i].Cells[2].FindControl("chkSelect") != null)
            {
                GridViewRow gRow = gvMain.Rows[i];
                if (((CheckBox)gRow.Cells[2].FindControl("chkSelect")).Checked)
                {
                    arrChk.Add(Convert.ToDouble(gRow.Cells[0].Text));
                }
            }
        }
        return arrChk;
    }

    #endregion

    #region Controls Management Methods

    private void SetStatus(string t, bool isError)
    {
        this.lbStatus.Text = t;
        this.lbStatus.ForeColor = (isError ? Constant.StatusColor.Error : Constant.StatusColor.Information);
    }

    private void CalculateNetPrice()
    {
        double total = 0;
        for (int i = 0; i < this.gvMain.Rows.Count; ++i)
        {
            GridViewRow gRow = this.gvMain.Rows[i];
            total += Convert.ToDouble(gRow.Cells[12].Text);
        }
        this.txtNetPrice.Text = total.ToString(Constant.DoubleFormat);
    }

    private ArrayList GetStockOutItemList()
    {
        ArrayList arrData = new ArrayList();
        StockoutitemData pData;
        for (int i = 0; i < this.gvMain.Rows.Count; ++i)
        {
            GridViewRow gRow = this.gvMain.Rows[i];
            pData = new StockoutitemData();
            pData.ISMENU = gRow.Cells[13].Text;
            pData.LOID = Convert.ToDouble("0" + gRow.Cells[1].Text);
            pData.MATERIALMASTER = Convert.ToDouble("0" + gRow.Cells[16].Text);
            pData.PRICE = Convert.ToDouble("0" + gRow.Cells[18].Text);
            pData.RANK = Convert.ToDouble("0" + gRow.Cells[0].Text);
            pData.REQQTY = Convert.ToDouble("0" + ((TextBox)gRow.Cells[10].FindControl("txtReqQty")).Text);
            pData.UNIT = Convert.ToDouble("0" + gRow.Cells[17].Text);
            arrData.Add(pData);
        }
        return arrData;
    }

    private StockOutRequestData GetData()
    {
        StockOutRequestData pData = new StockOutRequestData();
        pData.CODE = this.txtCode.Text.Trim();
        pData.DIVISION = Convert.ToDouble(this.cmbDivision.SelectedItem.Value);
        pData.DOCTYPE = Convert.ToDouble(this.cmbDocType.SelectedItem.Value);
        pData.ISBREAKFAST = this.chkIsBreakfast.Checked;
        pData.ISLUNCH = this.chkIsLunch.Checked;
        pData.ISDINNER = this.chkIsDinner.Checked;
        pData.LOID = Convert.ToDouble(this.txtLOID.Text);
        pData.STATUS = this.txtStatus.Text;
        pData.STOCKOUTDATE = this.ctlStockDate.DateValue;
        pData.USEDATE = this.ctlUseDate.DateValue;
        pData.WAREHOUSE = Convert.ToDouble(this.cmbWarehouse.SelectedItem.Value);
        pData.StockOutItemList = GetStockOutItemList();

        return pData;
    }

    private void ViewData(bool isView)
    {
        this.ctlStockDate.Enabled = !isView;
        this.cmbWarehouse.Enabled = !isView;
        this.cmbDocType.Enabled = !isView;
        this.ctlUseDate.Enabled = !isView;
        this.chkIsBreakfast.Enabled = !isView;
        this.chkIsDinner.Enabled = !isView;
        this.chkIsLunch.Enabled = !isView;
    }

    private void SetData(StockOutRequestData pData)
    {
        this.txtCurDiscountFormula.Text = "";
        this.txtCurDiscountOrder.Text = "";

        bool pageAuthorized = true;
        this.txtCode.Text = pData.CODE;
        this.cmbDivision.SelectedIndex = cmbDivision.Items.IndexOf(cmbDivision.Items.FindByValue((pData.DIVISION == 0 ? Appz.LoggedOnUser.DIVISION.ToString() : pData.DIVISION.ToString())));
        this.cmbDocType.SelectedIndex = cmbDocType.Items.IndexOf(cmbDocType.Items.FindByValue(pData.DOCTYPE.ToString()));
        this.chkIsBreakfast.Checked = pData.ISBREAKFAST;
        this.chkIsDinner.Checked = pData.ISDINNER;
        this.chkIsLunch.Checked = pData.ISLUNCH;
        this.txtLOID.Text = pData.LOID.ToString();
        this.txtStatus.Text = pData.STATUS;
        this.txtStatusName.Text = pData.STATUSNAME;
        this.ctlStockDate.DateValue = (pData.STOCKOUTDATE.Year == 1 ? DateTime.Today : pData.STOCKOUTDATE);
        this.ctlUseDate.DateValue = pData.USEDATE;
        this.cmbWarehouse.SelectedIndex = this.cmbWarehouse.Items.IndexOf(this.cmbWarehouse.Items.FindByValue(pData.WAREHOUSE.ToString()));
        this.tbPrint.Visible = (pData.LOID != 0);
        this.tbPrint.ClientClick = Appz.OpenReportScript(Constant.Reports.RepStockOut, pData.LOID, false);
        this.txtOrderQty.Text = pData.ORDERQTY.ToString(Constant.IntFormat);

        if (!pageAuthorized || pData.STATUS == "SE" || pData.STATUS == "AP" || pData.STATUS == "VO")
        {
            ViewData(true);

            this.trToolbar.Visible = false;
            this.tbCancel.Visible = false;
            this.tbSave.Visible = false;
            this.tbAddFromMenu.Visible = false;
            this.tbAddOthers.Visible = false;
            this.tbDelete.Visible = false;
            this.tbSend.Visible = false;
            this.pnlCalculate.Visible = false;
            this.gvMain.Columns[2].Visible = false;
        }
        else
        {
            ViewData(false);

            this.tbSend.Visible = (pData.STATUS == "WA" || pData.STATUS == "NP");
            this.trToolbar.Visible = (pData.STATUS == "WA" || pData.STATUS == "NP");
            this.tbCancel.Visible = (pData.STATUS == "WA" || pData.STATUS == "NP");
            this.tbSave.Visible = (pData.STATUS == "WA" || pData.STATUS == "NP");
            this.gvMain.Columns[2].Visible = true;
        }

        StockOutRequestDetailItem item = new StockOutRequestDetailItem();
        item.ClearAllSession();
        this.gvMain.DataBind();
        CalculateNetPrice();
    }

    #endregion

    #region Working Method

    private void UpdateStockOutItem()
    {
        StockOutRequestDetailItem item = new StockOutRequestDetailItem();
        item.UpdateStockOutItem(Convert.ToDouble("0" + this.txtLOID.Text), GetStockOutItemList());
    }

    private void UpdateStockOutItemFromMenu()
    {
        StockOutRequestDetailItem fsItem = new StockOutRequestDetailItem();
        if (fsItem.UpdateStockOutItem(Convert.ToDouble("0" + this.txtLOID.Text), GetStockOutItemList(), Convert.ToDouble(this.cmbDivision.SelectedItem.Value), this.ctlUseDate.DateValue, this.chkIsBreakfast.Checked, this.chkIsLunch.Checked, this.chkIsDinner.Checked))
        {
            this.gvMain.DataBind();
            CalculateNetPrice();
        }
    }

    private void AddStockOutItemFromMenu()
    {
        UpdateStockOutItem();
        string materialList = "";
        for (int i = 0; i < this.gvMain.Rows.Count; ++i)
        {
            materialList += (materialList == "" ? "" : ",") + "'" + this.gvMain.Rows[i].Cells[16].Text + "#" + this.gvMain.Rows[i].Cells[17].Text + "'";
        }
        ctlMenuStockOut.Show(Convert.ToDouble(this.cmbDocType.SelectedItem.Value), Convert.ToDouble(this.cmbDivision.SelectedItem.Value), this.ctlUseDate.DateValue, this.chkIsBreakfast.Checked, this.chkIsLunch.Checked, this.chkIsDinner.Checked, materialList);
    }

    private void AddStockOutItemFromOthers()
    {
        UpdateStockOutItem();
        string materialList = "";
        for (int i = 0; i < this.gvMain.Rows.Count; ++i)
        {
            materialList += (materialList == "" ? "" : ",") + "'" + this.gvMain.Rows[i].Cells[16].Text + "#" + this.gvMain.Rows[i].Cells[17].Text + "'";
        }
        ctMaterialUnit.Show("", Convert.ToDouble(this.cmbDocType.SelectedItem.Value), 0, "", materialList);
    }

    private void DeleteStockOutItem()
    {
        UpdateStockOutItem();
        StockOutRequestDetailItem item = new StockOutRequestDetailItem();
        if (item.DeleteStockOutItem(GetCheckedStockOutItem()))
        {
            this.gvMain.DataBind();
            CalculateNetPrice();
        }
    }

    private bool AdjustQtyOrder()
    {
        double total = 0;
        bool ret = true;
        double adjPercent = (this.txtDiscountOrder.Text == "" ? 0 : Convert.ToDouble(this.txtDiscountOrder.Text));

        for (int i = 0; i < this.gvMain.Rows.Count; ++i)
        {
            GridViewRow gRow = this.gvMain.Rows[i];
            if (gRow.Cells[13].Text == "Y")
            {
                ((TextBox)gRow.Cells[10].FindControl("txtReqQty")).Text = ((Convert.ToDouble(gRow.Cells[8].Text) * (1 + (adjPercent / 100)))).ToString(Constant.DoubleFormat);
                gRow.Cells[12].Text = (Convert.ToDouble(gRow.Cells[18].Text) * Convert.ToDouble(((TextBox)gRow.Cells[10].FindControl("txtReqQty")).Text)).ToString(Constant.DoubleFormat);
            }
            total += Convert.ToDouble(gRow.Cells[12].Text);
        }
        this.txtNetPrice.Text = total.ToString(Constant.DoubleFormat);
        return ret;
    }

    private bool AdjustQtyFormula()
    {
        double total = 0;
        bool ret = true;
        double adjPercent = (this.txtDiscountFormula.Text == "" ? 0 : Convert.ToDouble(this.txtDiscountFormula.Text));

        for (int i = 0; i < this.gvMain.Rows.Count; ++i)
        {
            GridViewRow gRow = this.gvMain.Rows[i];
            if (gRow.Cells[13].Text == "Y")
            {
                ((TextBox)gRow.Cells[10].FindControl("txtReqQty")).Text = ((Convert.ToDouble(gRow.Cells[7].Text) * (1 + (adjPercent / 100)))).ToString(Constant.DoubleFormat);
                gRow.Cells[12].Text = (Convert.ToDouble(gRow.Cells[18].Text) * Convert.ToDouble(((TextBox)gRow.Cells[10].FindControl("txtReqQty")).Text)).ToString(Constant.DoubleFormat);
            }
            total += Convert.ToDouble(gRow.Cells[12].Text);
        }
        this.txtNetPrice.Text = total.ToString(Constant.DoubleFormat);
        return ret;
    }

    private bool doGetDetail(string LOID)
    {
        StockOutRequestFlow fFlow = new StockOutRequestFlow();
        StockOutRequestData fData = fFlow.GetDetail(Convert.ToDouble(LOID));

        bool ret = true;
        SetData(fData);
        return ret;
    }

    private bool doSave()
    {
        return doSave("", false);
    }

    private bool doSave(string status, bool sendOrg)
    {
        StockOutRequestFlow ftFlow = new StockOutRequestFlow();
        bool ret = true;
        string error = "";

        // verify required field
        StockOutRequestData pData = GetData();
        if (status != "") pData.STATUS = status;

        if (pData.DOCTYPE == 6 && pData.USEDATE.Year != 1 && (pData.ISBREAKFAST || pData.ISLUNCH || pData.ISDINNER))
            pData.ORDERQTY = ftFlow.CalPatentQtyStockOut(pData.DIVISION, pData.USEDATE, pData.ISBREAKFAST, pData.ISLUNCH, pData.ISDINNER);
        else
            pData.ORDERQTY = 0;
        error = VerifyData(pData);
        if (error != "")
        {
            SetStatus(error, true);
            return false;
        }
        // data correct go on saving...
        if (pData.LOID != 0)
            ret = ftFlow.UpdateData(pData, Appz.CurrentUser);
        else
            ret = ftFlow.InsertData(pData, Appz.CurrentUser);

        if (!ret)
            SetStatus(ftFlow.ErrorMessage, true);
        else
        {
            doGetDetail(ftFlow.LOID.ToString());
            if (pData.LOID == 0)
                SetStatus(DataResources.MSGIN001, false);
            else
                SetStatus(DataResources.MSGIU001, false);
        }
        return ret;
    }

    private string VerifyData(StockOutRequestData pData)
    {
        string ret = "";
        if (pData.STOCKOUTDATE.Year == 1)
            ret = string.Format(DataResources.MSGEI001, "วันที่เบิก");
        else if (pData.WAREHOUSE == 0)
            ret = string.Format(DataResources.MSGEI002, "คลัง");
        else if (pData.DOCTYPE == 0)
            ret = string.Format(DataResources.MSGEI002, "ประเภทการเบิก");
        else if (pData.USEDATE.Year == 1)
            ret = string.Format(DataResources.MSGEI001, "วันที่ใช้");
        else if (pData.StockOutItemList.Count == 0)
        {
            ret = string.Format(DataResources.MSGEI002, "วัสดุ");
        }
        else
        {
            for (int i = 0; i < pData.StockOutItemList.Count; ++i)
            {
                StockoutitemData item = (StockoutitemData)pData.StockOutItemList[i];
                if (item.REQQTY == 0)
                {
                    ret = string.Format(DataResources.MSGEI001, "จำนวนที่ต้องการ");
                    break;
                }
            }
        }

        return ret;
    }

    #endregion

}
