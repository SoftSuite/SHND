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
using SHND.Flow.Inventory;
using SHND.Data.Tables;
using SHND.Data.Common.Utilities;
using SHND.Global;
using SHND.Data.Views;


/// <summary>
/// StockCheckHead Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Nang
/// Create Date: 13 Feb 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้าการทำงานรายการตรวจนับ StockCheckHead
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

public partial class App_Inventory_Transaction_StockCheckHead : System.Web.UI.Page
{
    private DataTable tempTable = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            doGetList();
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        Appz.BuildCombo(cmbWarehouse, "WAREHOUSE", "NAME", "LOID", "ISVIRTUAL='N' AND ACTIVE= '1'", "NAME", "ทั้งหมด", "0", true);
        Appz.BuildCombo(cmbWarehousePop, "WAREHOUSE", "NAME", "LOID", "ISVIRTUAL='N' AND ACTIVE= '1'", "NAME", "เลือก", "0", true);
        Appz.BuildCombo(cmbMaterialClass, "MATERIALCLASS", "NAME", "LOID", "ACTIVE= '1'", "NAME", "เลือก", "0", true);
        ctlCheckDate.DateValue = DateTime.Today.Date;
        SetStatusCombo(cmbStatusFrom);
        SetStatusCombo(cmbStatusTo);

        pcTop.SetMainGridView(grvResult);
        pcBot.SetMainGridView(grvResult);
    }

    private void SetStatusCombo(DropDownList cmb)
    {
        cmb.Items.Clear();
        //cmb.Items.Add(new ListItem("ทำรายการ", "00"));
        //cmb.Items.Add(new ListItem("ยืนยันการนับ", "01"));
        cmb.Items.Add(new ListItem("รออนุมัติ", "02"));
        cmb.Items.Add(new ListItem("อนุมัติ", "03"));
        //cmb.Items.Add(new ListItem("ยกเลิก", "04"));
    }

    #region Button Click Event Handler

    #region Button Main

    protected void imbSearch_Click(object sender, ImageClickEventArgs e)
    {
        grvResult.PageIndex = 0;
        doGetList();
    }

    protected void imbReset_Click(object sender, ImageClickEventArgs e)
    {
        ClearSearch();
        grvResult.PageIndex = 0;
        doGetList();
    }

    protected void lnkType_Click(object sender, EventArgs e)
    {
        doGetDetail(((LinkButton)sender).CommandArgument);
        StockCheckPop.Show();
    }

    protected void tbApproveMain_Click(object sender, EventArgs e)
    {
        doApproveMain();
    }

    protected void tbCancelMain_Click(object sender, EventArgs e)
    {
        doVoidMain();
    }

    #endregion

    #region Button Pop

    protected void tbApprove_Click(object sender, EventArgs e)
    {
        bool ret = true;
        if (DoSaveStockCheck())
        {
            ret = DoSaveStockCheckItem(txhID.Text.Trim());
            if (!ret)
            {
                SetStatus("เกิดข้อผิดพลาดในการแก้ไขข้อมูล", true);
                StockCheckPop.Show();
            }
            else
            {
                if (DoApprove())
                {
                    doGetDetail(txhID.Text.Trim());
                    if (grvItem.Rows.Count > 0)
                        grvItem.Visible = true;

                    SetStatus("บันทึกข้อมูลเรียบร้อยแล้ว", false);
                    StockCheckPop.Show();
                }
            }
        }
        else
        {
            StockCheckPop.Show();
        }
    }

    protected void tbBack_Click(object sender, EventArgs e)
    {
        ClearData();
        cmbMaterialClass.Enabled = true;
        cmbWarehousePop.Enabled = true;
        doGetList();
    }

    protected void tbCancel_Click(object sender, EventArgs e)
    {
        DoCancel();
        doGetList();
    }

    #endregion

    #endregion

    #region Gridview Event Handler

    protected void grvResult_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex > -1)
        {
            e.Row.Cells[2].Text = ((e.Row.RowIndex + 1) + (grvResult.PageIndex * grvResult.PageSize)).ToString();

            if (e.Row.Cells[6].Text == "อนุมัติ" || e.Row.Cells[6].Text == "ยกเลิก")
            {
                CheckBox chkSelect = (CheckBox)e.Row.FindControl("chkSelect");
                chkSelect.Enabled = false;
                chkSelect.CssClass = "zHidden";
            }
        }
    }

    protected void grvResult_Sorting(object sender, GridViewSortEventArgs e)
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
    }

    protected void grvItem_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex > -1)
        {
            e.Row.Cells[1].Text = ((e.Row.RowIndex + 1) + (grvItem.PageIndex * grvItem.PageSize)).ToString();

            CheckBox chkIsImprove = (CheckBox)e.Row.FindControl("chkIsImprove");
            if (chkIsImprove.ToolTip != "")
                chkIsImprove.Checked = (chkIsImprove.ToolTip == "N" ? false : true);

            Label lblCountQty = (Label)e.Row.FindControl("lblCountQty");
            Label lblStockQty = (Label)e.Row.FindControl("lblStockQty");
            Label lblDiff = (Label)e.Row.FindControl("lblDiff");
            if (lblDiff != null && lblStockQty != null && lblCountQty != null)
            {
                double stockqty = Convert.ToDouble(lblStockQty.Text.Trim());
                double countqty = Convert.ToDouble(lblCountQty.Text.Trim());

                if (stockqty < 0)
                {
                    lblDiff.Text = Convert.ToString(stockqty + countqty);
                }
                else if (stockqty > 0)
                {
                    lblDiff.Text = Convert.ToString(countqty - stockqty);
                }
                else if (stockqty == 0)
                {
                    lblDiff.Text = Convert.ToString(countqty - stockqty);
                }
            }
        }
    }


    #endregion

    #region Paging Event Handler

    protected void PageChange(object sender, EventArgs e)
    {
        grvResult.PageIndex = ((Templates_PageControl)sender).SelectedPageIndex;
        doGetList();
        pcBot.Update();
        pcTop.Update();
    }

    protected void PopUpPageChange(object sender, EventArgs e)
    {
        grvItem.PageIndex = ((Templates_PageControl)sender).SelectedPageIndex;
        GetPageChange();
        pcBot1.Update();
        pcTop1.Update();
    }
    #endregion

    #region Misc. Methods

    private ArrayList GetChecked()
    {
        ArrayList arrChk = new ArrayList();

        for (int i = 0; i < grvResult.Rows.Count; i++)
        {
            if (i > -1 && grvResult.Rows[i].FindControl("chkSelect") != null)
            {
                CheckBox chkSelect = (CheckBox)grvResult.Rows[i].FindControl("chkSelect");
                if (chkSelect.Checked == true)
                    arrChk.Add(grvResult.Rows[i].Cells[0].Text);
            }
        }
        return arrChk;
    }

    private void CreateTempTable()
    {
        tempTable = new DataTable();
        DataColumn dcSCILOID = new DataColumn("SCILOID");
        DataColumn dcISIMPROVE = new DataColumn("ISIMPROVE");

        tempTable.Columns.Add(dcSCILOID);
        tempTable.Columns.Add(dcISIMPROVE);
    }
    #endregion

    #region Controls Management Methods

    private void SetStatus(string t, bool isError)
    {
        lbStatus.Text = t;
        lbStatus.ForeColor = (isError ? Constant.StatusColor.Error : Constant.StatusColor.Information);
    }

    private void ClearSearch()
    {
        this.txtNoFrom.Text = "";
        this.txtNoTo.Text = "";
        this.ctlDateFrom.DateValue = new DateTime();
        this.ctlDateTo.DateValue = new DateTime();
        this.cmbWarehouse.SelectedIndex = 0;
        this.cmbStatusFrom.SelectedIndex = 0;
        this.cmbStatusTo.SelectedIndex = 0;
    }

    private StockCheckData GetData()
    {
        StockCheckData sData = new StockCheckData();
        sData.MATERIALCLASS = Convert.ToDouble(cmbMaterialClass.SelectedItem.Value.ToString());
        sData.WAREHOUSE = Convert.ToDouble(cmbWarehousePop.SelectedItem.Value.ToString());
        sData.STATUS = txtStatusFlag.Text.Trim();
        sData.REMARKS = txtRemark.Text.Trim();
        sData.CHECKDATE = Convert.ToDateTime(ctlCheckDate.DateValue.Date);
        sData.LOID = Convert.ToDouble((txhID.Text.Trim() == "" ? "0" : txhID.Text.Trim()));
        sData.BATCHNO = txtBatchNo.Text.Trim();
        return sData;
    }

    private void SetData(StockCheckData sData, DataTable dt)
    {
        txhID.Text = sData.LOID.ToString();
        txtBatchNo.Text = sData.BATCHNO.ToString();
        ctlCheckDate.DateValue = Convert.ToDateTime(sData.CHECKDATE);
        cmbWarehousePop.SelectedIndex = cmbWarehousePop.Items.IndexOf(cmbWarehousePop.Items.FindByValue(sData.WAREHOUSE.ToString()));
        cmbMaterialClass.SelectedIndex = cmbMaterialClass.Items.IndexOf(cmbMaterialClass.Items.FindByValue(sData.MATERIALCLASS.ToString()));
        txtRemark.Text = sData.REMARKS.ToString();
        txtStatusFlag.Text = sData.STATUS.ToString();
        txtStatus.Text = (sData.STATUS == "WA" ? "ทำรายการ" : (sData.STATUS == "CN" ? "ยืนยันการนับ" : (sData.STATUS == "AP" ? "อนุมัติ" : (sData.STATUS == "VO" ? "ยกเลิก" : (sData.STATUS == "CO" ? "รออนุมัติ" : "")))));

        this.tbApprove.Visible = (txhID.Text.Trim() != "" || txhID.Text.Trim() != "0");

        grvItem.DataSource = dt;
        grvItem.DataBind();
        pcTop1.SetMainGridView(grvItem);
        pcBot1.SetMainGridView(grvItem);
        pcBot1.Update();
        pcTop1.Update();
        this.grvItem.Visible = (txhID.Text.Trim() != "" || txhID.Text.Trim() != "0");
        SetControl();
        if (txtStatusFlag.Text.Trim() == "AP" || txtStatusFlag.Text.Trim() == "VO")
        {
            //grvItem.Enabled = false;
            txtRemark.CssClass = "zTextbox-View";
            txtRemark.ReadOnly = true;
            tbApprove.Visible = false;
            tbApprove.Visible = false;
            tbCancel.Visible = false;
            for (int i = 0; i < grvItem.Rows.Count; ++i)
            {
                CheckBox chkIsImprove = (CheckBox)grvItem.Rows[i].FindControl("chkIsImprove");
                if (chkIsImprove != null)
                    chkIsImprove.Enabled = false;
            }
        }
    }

    private void ClearData()
    {
        txhID.Text = "";
        txtBatchNo.Text = "";
        ctlCheckDate.DateValue = DateTime.Today.Date;
        cmbWarehousePop.SelectedIndex = -1;
        cmbMaterialClass.SelectedIndex = -1;
        txtRemark.Text = "";
        txtStatus.Text = "";
        txtStatusFlag.Text = "WA";
        grvItem.DataSource = null;
        grvItem.DataBind();
        grvItem.Visible = false;
        grvItem.Enabled = true;
        txtRemark.CssClass = "zTextbox";
        txtRemark.ReadOnly = false;
        cmbMaterialClass.Enabled = true;
        cmbWarehousePop.Enabled = true;
        tbApprove.Visible = true;
        tbCancel.Visible = true;
    }

    private void SetControl()
    {
        if (txhID.Text.Trim() != "" || txhID.Text.Trim() != "0")
        {
            txtBatchNo.CssClass = "zTextbox-View";
            txtBatchNo.ReadOnly = true;
            ctlCheckDate.Enabled = false;
            cmbWarehousePop.Enabled = false;
            cmbMaterialClass.Enabled = false;
        }
    }
    #endregion

    #region Working Method

    private void doGetList()
    {
        StockCheckAuditFlow sFlow = new StockCheckAuditFlow();
        string orderStr = "";
        string wh = "";
        string datefrom = "";
        string dateTo = "";
        this.imbReset.Visible = (this.txtNoFrom.Text.Trim() != "") || (this.txtNoTo.Text.Trim() != "") || (this.ctlDateFrom.DateValue.Year != 1) || (this.ctlDateTo.DateValue.Year != 1) ||
            (this.cmbWarehouse.SelectedIndex != 0) || (this.cmbStatusFrom.SelectedIndex != 0) || (this.cmbStatusTo.SelectedIndex != 0);
        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;

        if (ctlDateFrom.DateValue.Year.ToString() != "1" && ctlDateTo.DateValue.Year.ToString() != "1")
        {
            datefrom = ctlDateFrom.DateValue.Day.ToString() + '/' + ctlDateFrom.DateValue.Month.ToString() + '/' + ctlDateFrom.DateValue.Year.ToString();
            dateTo = ctlDateTo.DateValue.Day.ToString() + '/' + ctlDateTo.DateValue.Month.ToString() + '/' + ctlDateTo.DateValue.Year.ToString();
        }

        //Check เลขที่ตรวจรับ
        if (txtNoFrom.Text.Trim() != "" && txtNoTo.Text.Trim() != "")
            wh += " BATCHNO BETWEEN " + txtNoFrom.Text.Trim() + " AND " + txtNoTo.Text.Trim() + "";
        else if (txtNoFrom.Text.Trim() != "")
            wh += (wh == "" ? "" : " AND ") + " BATCHNO >= " + txtNoFrom.Text.Trim() + "";
        else if (txtNoTo.Text.Trim() != "")
            wh += (wh == "" ? "" : " AND ") + " BATCHNO <= " + txtNoTo.Text.Trim() + "";

        //Check วันที่ตรวจรับ
        if (ctlDateFrom.DateValue.Year.ToString() != "1" && ctlDateTo.DateValue.Year.ToString() != "1")
            wh += " TO_DATE(CHECKDATE,'DD/MM/YYYY') BETWEEN TO_DATE('" + datefrom + "','DD/MM/YYYY') AND TO_DATE('" + dateTo + "','DD/MM/YYYY')";
        else if (ctlDateFrom.DateValue.Date.Year.ToString() != "1")
            wh += (wh == "" ? "" : " AND ") + " TO_DATE(CHECKDATE,'DD/MM/YYYY') >= TO_DATE('" + datefrom + "','DD/MM/YYYY')";
        else if (ctlDateTo.DateValue.Date.Year.ToString() != "1")
            wh += (wh == "" ? "" : " AND ") + " TO_DATE(CHECKDATE,'DD/MM/YYYY') <= TO_DATE('" + dateTo + "','DD/MM/YYYY')";

        //คลัง
        if (cmbWarehouse.SelectedItem.Value.ToString() != "0")
            wh += (wh == "" ? "" : " AND ") + " WHLOID = " + cmbWarehouse.SelectedItem.Value + "";

        //สถานะ
        if (cmbStatusFrom.SelectedItem.Value != "0" && cmbStatusTo.SelectedItem.Value != "0")
            wh += (wh == "" ? "" : " AND ") + " STATUSRANK BETWEEN " + cmbStatusFrom.SelectedItem.Value.ToString() + " AND " + cmbStatusTo.SelectedItem.Value.ToString() + "";
        else if (cmbStatusFrom.SelectedItem.Value == "0")
            wh += (wh == "" ? "" : " AND ") + " STATUSRANK >= " + cmbStatusFrom.SelectedItem.Value + "";
        else if (cmbStatusTo.SelectedItem.Value == "0")
            wh += (wh == "" ? "" : " AND ") + " STATUSRANK <= " + cmbStatusTo.SelectedItem.Value + "";

        grvResult.DataSource = sFlow.GetStockCheckSearch(wh, orderStr);
        grvResult.DataBind();
        pcTop.Update();
        pcBot.Update();
    }

    private bool DoSaveStockCheck()
    {
        bool ret = true;

        //data correct go on saving...
        double sLoid = 0;

        //save update
        StockCheckHeadFlow sFlow = new StockCheckHeadFlow();
        sLoid = sFlow.UpdateStockCheck(GetData(), Appz.CurrentUser);
        txhID.Text = sLoid.ToString();
        txtFlag.Text = "1";

        if (sLoid == 0)
        {
            SetStatus(sFlow.ErrorMessage, true);
            ret = false;
        }
        else
            doGetList();

        return ret;
    }

    private bool DoSaveStockCheckItem(string sLoid)
    {
        bool ret = true;

        StockCheckHeadFlow sFlow = new StockCheckHeadFlow();

        CreateTempTable();
        for (int i = 0; i < grvItem.Rows.Count; i++)
        {
            DataRow ddr = tempTable.Rows.Add();
            ddr["SCILOID"] = grvItem.Rows[i].Cells[10].Text.Trim();
            CheckBox chkIsImprove = (CheckBox)grvItem.Rows[i].FindControl("chkIsImprove");
            ddr["ISIMPROVE"] = (chkIsImprove.Checked ? "Y" : "N");
        }

        ret = sFlow.UpdateStockCheckItem(tempTable, Appz.CurrentUser);

        return ret;
    }

    private bool doGetDetail(string LOID)
    {
        bool ret = true;
        StockCheckHeadFlow sFlow = new StockCheckHeadFlow();
        StockCheckData sData = sFlow.GetStockCheckData(Convert.ToDouble(LOID));
        DataTable dt = sFlow.GetStockCheckHeadList(Convert.ToDouble(LOID));

        if (sData.LOID != 0)
            SetData(sData, dt);
        else
            ret = false;
        return ret;
    }


    private bool DoApprove()
    {
        bool ret = true;
        StockCheckHeadFlow sFlow = new StockCheckHeadFlow();
        double sLoid = 0;

        //save update
        if (txhID.Text.Trim() != "" && txhID.Text.Trim() != "0")
        {
            sLoid = sFlow.UpdateApprove(Convert.ToDouble(txhID.Text.Trim()), Appz.CurrentUser,"AP");
            txhID.Text = sLoid.ToString();
        }
        else
            SetStatus(string.Format(DataResources.MSGEI002, "รายการตรวจนับ"), true);

        if (sLoid == 0)
        {
            SetStatus(sFlow.ErrorMessage, true);
            ret = false;
        }
        else
            doGetList();

        return ret;
    }

    private bool DoCancel()
    {
        bool ret = true;
        StockCheckHeadFlow sFlow = new StockCheckHeadFlow();
        double sLoid = 0;

        //save update
        if (txhID.Text.Trim() != "" && txhID.Text.Trim() != "0")
        {
            sLoid = sFlow.UpdateApprove(Convert.ToDouble(txhID.Text.Trim()), Appz.CurrentUser, "VO");
            txhID.Text = sLoid.ToString();
        }
        else
            SetStatus(string.Format(DataResources.MSGEI002, "รายการตรวจนับ"), true);

        if (sLoid == 0)
        {
            SetStatus(sFlow.ErrorMessage, true);
            ret = false;
        }
        else
            doGetList();

        return ret;
    }

    private void GetPageChange()
    {
        StockCheckHeadFlow sFlow = new StockCheckHeadFlow();
        DataTable dt = sFlow.GetStockCheckHeadList(Convert.ToDouble(txhID.Text.Trim()));

        grvItem.DataSource = dt;
        grvItem.DataBind();
        pcTop1.SetMainGridView(grvItem);
        pcBot1.SetMainGridView(grvItem);
        pcBot1.Update();
        pcTop1.Update();
        this.grvItem.Visible = (txhID.Text.Trim() != "" || txhID.Text.Trim() != "0");
        if (txtStatusFlag.Text.Trim() == "AP" || txtStatusFlag.Text.Trim() == "VO")
        {
            grvItem.Enabled = false;
            txtRemark.CssClass = "zTextbox-View";
            txtRemark.ReadOnly = true;
            tbApprove.Visible = false;
            tbCancel.Visible = false;
        }
    }

    private void doApproveMain()
    {
        StockCheckHeadFlow sFlow = new StockCheckHeadFlow();
        if (sFlow.ApproveStockCheckByLoid(GetChecked(), Appz.CurrentUser))
        {
            grvResult.PageIndex = 0;
            doGetList();
            lbStatusMain.Text = "";
        }
        else
        {
            lbStatusMain.Text = sFlow.ErrorMessage;
            lbStatusMain.ForeColor = System.Drawing.Color.Red;
        }
    }

    private void doVoidMain()
    {
        StockCheckHeadFlow sFlow = new StockCheckHeadFlow();
        if (sFlow.VoidStockCheckByLoid(GetChecked(),Appz.CurrentUser))
        {
            grvResult.PageIndex = 0;
            doGetList();
            lbStatusMain.Text = "";
        }
        else
        {
            lbStatusMain.Text = sFlow.ErrorMessage;
            lbStatusMain.ForeColor = System.Drawing.Color.Red;
        }
    }

    #endregion

}
