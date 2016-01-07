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
/// Create Date: 2 Mar 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้าการทำรายการข้อมูล StockOut
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
public partial class App_Inventory_Transaction_StockOut : System.Web.UI.Page
{
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        ControlUtil.SetMinusIntTextBox(this.txtDiscountFormula);
        ControlUtil.SetMinusIntTextBox(this.txtDiscountOrder);
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
        Response.Redirect(Constant.HomeFolder + "App_Inventory/Transaction/StockOutSearch.aspx");
    }
    protected void tbApproveClick(object sender, EventArgs e)
    {
        doSave("AP", true);
    }
    protected void tbNotApproveClick(object sender, EventArgs e)
    {
        doSave("NP", true);
    }
    protected void tbVoidClick(object sender, EventArgs e)
    {
        doSave("VO", true);
    }
    #endregion

    #region StockOutItem Toolbar
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
            pData.LOID = Convert.ToDouble("0" + gRow.Cells[0].Text);
            pData.MATERIALMASTER = Convert.ToDouble("0" + gRow.Cells[16].Text);
            pData.PRICE = Convert.ToDouble("0" + gRow.Cells[18].Text);
            pData.REQQTY = Convert.ToDouble("0" + ((TextBox)gRow.Cells[8].FindControl("txtReqQty")).Text);
            pData.QTY = Convert.ToDouble("0" + ((TextBox)gRow.Cells[9].FindControl("txtQty")).Text);
            pData.UNIT = Convert.ToDouble("0" + gRow.Cells[17].Text);

            if (((CheckBox)gRow.Cells[10].FindControl("chkApprove")).Checked)
            {
                if (this.txtStatus.Text == "AP")
                    pData.STATUS = "AP";
                else if (this.txtStatus.Text == "SE")
                    pData.STATUS = "SE";
                else if (this.txtStatus.Text == "WA")
                    pData.STATUS = "WA";
                else if (this.txtStatus.Text == "NP")
                    pData.STATUS = "NP";
                else
                    pData.STATUS = "VO";
            }
            else 
            {
                if (this.txtStatus.Text == "AP")
                    pData.STATUS = "NP";
                else if (this.txtStatus.Text == "SE")
                    pData.STATUS = "SE";
                else if (this.txtStatus.Text == "WA")
                    pData.STATUS = "WA";
                else if (this.txtStatus.Text == "NP")
                    pData.STATUS = "NP";
                else
                    pData.STATUS = "VO";
            }
            

            //pData.STATUS = (((CheckBox)gRow.Cells[10].FindControl("chkApprove")).Checked ? "AP" : "NP");
            arrData.Add(pData);
        }
        return arrData;
    }

    private StockOutDetailData GetData()
    {
        StockOutDetailData pData = new StockOutDetailData();
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
        pData.ORDERQTY = Convert.ToDouble("0" + this.txtOrderQty.Text);
        pData.StockOutItemList = GetStockOutItemList();

        return pData;
    }

    private void ViewData(bool isView)
    {
        this.cmbWarehouse.Enabled = !isView;
    }

    private void SetData(StockOutDetailData pData)
    {
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

        if (!pageAuthorized || pData.STATUS != "SE")
        {
            ViewData(true);

            this.tbSave.Visible = false;
            this.tbCancel.Visible = false;
            this.tbApprove.Visible = false;
            this.tbNotApprove.Visible = false;
            this.tbVoid.Visible = false;
            this.pnlCalculate.Visible = false;
        }
        else
        {
            ViewData(false);

            this.tbSave.Visible = true;
            this.tbCancel.Visible = true;
            this.tbApprove.Visible = (pData.STATUS == "SE");
            this.tbNotApprove.Visible = (pData.STATUS == "SE");
            this.tbVoid.Visible = true;
            this.pnlCalculate.Visible = true;
        }

        this.gvMain.DataSource = pData.StockOutItemTable;
        this.gvMain.DataBind();
        CalculateNetPrice();
    }

    #endregion

    #region Working Method

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
                ((TextBox)gRow.Cells[9].FindControl("txtQty")).Text = ((Convert.ToDouble(gRow.Cells[6].Text) * (1 + (adjPercent / 100)))).ToString(Constant.DoubleFormat);
                gRow.Cells[12].Text = (Convert.ToDouble(gRow.Cells[18].Text) * Convert.ToDouble(((TextBox)gRow.Cells[9].FindControl("txtQty")).Text)).ToString(Constant.DoubleFormat);
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
                ((TextBox)gRow.Cells[9].FindControl("txtQty")).Text = ((Convert.ToDouble(gRow.Cells[5].Text) * (1 + (adjPercent / 100)))).ToString(Constant.DoubleFormat);
                gRow.Cells[12].Text = (Convert.ToDouble(gRow.Cells[18].Text) * Convert.ToDouble(((TextBox)gRow.Cells[9].FindControl("txtQty")).Text)).ToString(Constant.DoubleFormat);
            }
            total += Convert.ToDouble(gRow.Cells[12].Text);
        }
        this.txtNetPrice.Text = total.ToString(Constant.DoubleFormat);
        return ret;
    }

    private bool doGetDetail(string LOID)
    {
        StockOutFlow fFlow = new StockOutFlow();
        StockOutDetailData fData = fFlow.GetDetail(Convert.ToDouble(LOID));

        bool ret = true;
        SetData(fData);
        return ret;
    }

    private bool doSave()
    {
        return doSave("SE", false);
    }

    private bool doSave(string status, bool sendOrg)
    {
        StockOutFlow ftFlow = new StockOutFlow();
        bool ret = true;
        string error = "";
        txtStatus.Text = status;

        // verify required field
        StockOutDetailData pData = GetData();
        if (status != "") pData.STATUS = status;

        error = VerifyData(pData);
        if (error != "")
        {
            SetStatus(error, true);
            return false;
        }
        // data correct go on saving...
        if (pData.LOID != 0)
            ret = ftFlow.UpdateData(pData, Appz.CurrentUser);

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

    private string VerifyData(StockOutDetailData pData)
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
        else if (pData.STATUS == "AP")
        {
            for (int i = 0; i < pData.StockOutItemList.Count; ++i)
            {
                StockoutitemData item = (StockoutitemData)pData.StockOutItemList[i];
                if (item.REQQTY == 0)
                {
                    ret = string.Format(DataResources.MSGEI001, "จำนวนที่ต้องการ");
                    break;
                }
                else if (item.QTY == 0)
                {
                    ret = string.Format(DataResources.MSGEI001, "จำนวนที่จ่าย");
                    break;
                }
            }
        }

        return ret;
    }

    #endregion

}
