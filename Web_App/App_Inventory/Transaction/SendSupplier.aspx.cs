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
using SHND.Data.Search;


/// <summary> 
/// SendSupplier Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Nang
/// Create Date: 27 Feb 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้าการทำงานรายการการส่งคืนร้านค้า SendSupplier
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 


public partial class App_Inventory_Transaction_SendSupplier : System.Web.UI.Page
{
    private DataTable tempTable = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            grvResult.PageIndex = 0;
            doGetList();
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        Appz.BuildCombo(cmbPlan, "PLANORDER", "NAME", "LOID", "STATUS='FN' AND TO_DATE(SYSDATE, 'DD/MM/YYYY') BETWEEN TO_DATE(STARTDATE,'DD/MM/YYYY') AND TO_DATE(ENDDATE,'DD/MM/YYYY')", "NAME", "เลือก", "0", true);
        Appz.BuildCombo(cmbSupplier, "V_SUPPLIER_PLAN", "NAME", "LOID", "PLANORDER=" + cmbPlan.SelectedValue, "NAME", "เลือก", "0", true);
        Appz.BuildCombo(cmbWarehouse, "V_WAREHOUSE_RETURN_SUPP", "NAME", "LOID", "", "NAME", "เลือก", "0", true);
        ctlStockOutDate.DateValue = DateTime.Today.Date;
        SetStatusCombo(cmbStatusFrom);
        SetStatusCombo(cmbStatusTo);

        pcTop.SetMainGridView(grvResult);
        pcBot.SetMainGridView(grvResult);

    }

    private void SetStatusCombo(DropDownList cmb)
    {
        cmb.Items.Clear();
        cmb.Items.Add(new ListItem("ทำรายการ", "00"));
        cmb.Items.Add(new ListItem("อนุมัติ", "02"));

    }

    protected void ctlSendSupplierPopup_SelectedIndexChanged(object sender, EventArgs e, ArrayList arrData)
    {
        if (InsertNewDataToTmpStockOutItem(arrData))
            BindGVFeedItem();

        StockOutPop.Show();
    }
    protected void ctlSendPreOrderSupplierPopup_SelectedIndexChanged(object sender, EventArgs e, ArrayList arrData)
    {
        if (InsertNewPreItemToTmp(arrData))
            BindGVFeedItem();

        StockOutPop.Show();
    }


    protected void ctlSendSupplierPopup_Cancel(object sender, EventArgs e)
    {
        StockOutPop.Show();
    }
    protected void ctlSendPreOrderSupplierPopup_Cancel(object sender, EventArgs e)
    {
        StockOutPop.Show();
    }
    protected void ctlSendSupplierPopup_SearchClick(object sender, EventArgs e)
    {
        StockOutPop.Show();
    }

    protected void ctlSendSupplierPopup_ResetClick(object sender, EventArgs e)
    {
        StockOutPop.Show();
    }

    protected void ctlSendPreOrderSupplierPopup_SearchClick(object sender, EventArgs e)
    {
        StockOutPop.Show();
    }

    protected void ctlSendPreOrderSupplierPopup_ResetClick(object sender, EventArgs e)
    {
        StockOutPop.Show();
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

    protected void tbAddClick(object sender, EventArgs e)
    {
        StockOutPop.Show();
    }

    protected void lnkType_Click(object sender, EventArgs e)
    {
        doGetDetail(((LinkButton)sender).CommandArgument);
        StockOutPop.Show();
        tbPrint.Visible = (txhID.Text.Trim() != "");
    }

    protected void tbDeleteClick(object sender, EventArgs e)
    {
        doDeleteMain();
    }

    protected void tbApprove_Click(object sender, EventArgs e)
    {
        if (!DoApprove())
            StockOutPop.Show();
    }
    #endregion

    #region Button Pop

    protected void tbSave_Click(object sender, EventArgs e)
    {
        //bool ret = true;
        if (DoSaveStockOut())
            SetErrorStatus("บันทึกข้อมูลเรียบร้อยแล้ว");
        //else
        //    SetErrorStatus("เกิดข้อผิดพลาดในการแก้ไขข้อมูล");

        StockOutPop.Show();
    }

    protected void tbCancel_Click(object sender, EventArgs e)
    {
        if(txhID.Text.Trim() == "" )
            ClearData();
        else
            doGetDetail(txhID.Text.Trim());
        StockOutPop.Show();
    }

    protected void tbBack_Click(object sender, EventArgs e)
    {
        ClearData();
        doGetList();
    }

    protected void tbAddStockOutItemClick(object sender, EventArgs e)
    {
        if (cmbPlan.SelectedValue.ToString() == "0")
            SetErrorStatus(string.Format(DataResources.MSGEI002, "แผนประมาณการ")); 
        else if (cmbSupplier.SelectedValue.ToString() == "0" || cmbSupplier.SelectedValue.ToString() == "")
            SetErrorStatus(string.Format(DataResources.MSGEI002, "บริษัท/ร้านค้า"));
        else if (cmbWarehouse.SelectedValue.ToString()=="0")
            SetErrorStatus(string.Format(DataResources.MSGEI002, "คลังที่จ่ายออก"));
        else
        {
            if (cmbWarehouse.SelectedValue.ToString() == Constant.Warehouse.WarehousePreOrder.Loid)
            {
                VSendPreOrderSupplierPopupData Condition = new VSendPreOrderSupplierPopupData();
                Condition.PLANORDER = Convert.ToDouble(cmbPlan.SelectedValue);
                Condition.SUPPLIER = Convert.ToDouble(cmbSupplier.SelectedValue);

                this.ctlSendPreOrderSupplierPopup.Show(Condition);
            }
            else
            {
                this.ctlSendSupplierPopup.Show(getMaterialList(), getSupplier(), cmbWarehouse.SelectedItem.Value, cmbPlan.SelectedItem.Value);
                this.ctlSendSupplierPopup.ShowOnly();
            }
        }

            StockOutPop.Show();
    }

    private string getSupplier()
    {
        string materialList = "";
        materialList = cmbSupplier.SelectedItem.Value;
        return materialList;
    }

    private string getMaterialList()
    {
        string materialList = "";
        DataTable dt = (DataTable)Session["StockOutItem"];
        if (dt != null)
        {
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                materialList += (materialList == "" ? "" : ",") + dt.Rows[i]["MMLOID"].ToString();
            }
        }
        return materialList;
    }

    protected void tbDeleteStockOutItemClick(object sender, EventArgs e)
    {
        doDeleteStockOutItemOnGrid();
    }
    #endregion

    #endregion

    #region Gridview Event Handler


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
            e.Row.Cells[2].Text = ((e.Row.RowIndex + 1) + (grvItem.PageIndex * grvItem.PageSize)).ToString();
            bool enabled = (this.txtStatusFlag.Text == "WA");

            TextBox txtQty = (TextBox)e.Row.FindControl("txtQty");
            TextBox txtRemarks = (TextBox)e.Row.FindControl("txtRemarks");
            if (txtQty != null)
                ControlUtil.SetDblTextBox(txtQty);
            txtQty.ReadOnly = !enabled;
            txtQty.CssClass = (enabled ? "zTextboxR" : "zTextboxR-View");
            txtRemarks.ReadOnly = !enabled;
            txtRemarks.CssClass = (enabled ? "zTextbox" : "zTextbox-View");
        }
        if (e.Row.RowType == DataControlRowType.Header)
        {
            ((CheckBox)e.Row.Cells[1].FindControl("chkAll")).Attributes.Add("onclick", "chkAllBox(this, '" + this.grvItem.ClientID + "_ctl', '_chkSelect')");
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
        doGetPageChang((txhID.Text.Trim() != "" ? txhID.Text.Trim() : "0"));
        pcBot1.Update();
        pcTop1.Update();
    }

    #endregion

    #region Misc. Methods

    private ArrayList GetChecked()
    {
        ArrayList arrChk = new ArrayList();
        for (int i = 0; i < grvItem.Rows.Count; i++)
        {
            if (i > -1 && grvItem.Rows[i].Cells[0].FindControl("chkSelect") != null)
            {
                if (((CheckBox)grvItem.Rows[i].Cells[1].FindControl("chkSelect")).Checked)
                    arrChk.Add(grvItem.Rows[i].Cells[9].Text);
            }
        }

        return arrChk;
    }

    private ArrayList GetCheckedMain()
    {
        ArrayList arrChk = new ArrayList();
        for (int i = 0; i < grvResult.Rows.Count; i++)
        {
            if (i > -1 && grvResult.Rows[i].Cells[0].FindControl("chkSelect") != null)
            {
                if (((CheckBox)grvResult.Rows[i].Cells[1].FindControl("chkSelect")).Checked)
                    arrChk.Add(grvResult.Rows[i].Cells[0].Text);
            }
        }

        return arrChk;
    }

    private void CreateTempTable()
    {
        tempTable = new DataTable();
        DataColumn dcSOLOID = new DataColumn("SOLOID");
        DataColumn dcMMCODE = new DataColumn("MMCODE");
        DataColumn dcMMNAME = new DataColumn("MMNAME");
        DataColumn dcUNAME = new DataColumn("UNAME");
        DataColumn dcQTY = new DataColumn("QTY");
        DataColumn dcREMARKS = new DataColumn("REMARKS");
        DataColumn dcSOILOID = new DataColumn("SOILOID");
        DataColumn dcMMLOID = new DataColumn("MMLOID");
        DataColumn dcUULOID = new DataColumn("UULOID");

        tempTable.Columns.Add(dcSOLOID);
        tempTable.Columns.Add(dcMMCODE);
        tempTable.Columns.Add(dcMMNAME);
        tempTable.Columns.Add(dcUNAME);
        tempTable.Columns.Add(dcQTY);
        tempTable.Columns.Add(dcREMARKS);
        tempTable.Columns.Add(dcSOILOID);
        tempTable.Columns.Add(dcMMLOID);
        tempTable.Columns.Add(dcUULOID);
    }

    #endregion

    #region Controls Management Methods

    private void SetErrorStatus(string t)
    {
        lbStatus.Text = t;
        lbStatus.ForeColor = Constant.StatusColor.Error;
    }

    private StockOutData GetData(String str)
    {
        StockOutData sData = new StockOutData();
        sData.WAREHOUSE = Convert.ToDouble(cmbWarehouse.SelectedItem.Value.ToString());
        sData.PLANORDER = Convert.ToDouble(cmbPlan.SelectedItem.Value.ToString());
        sData.SUPPLIER = Convert.ToDouble(cmbSupplier.SelectedItem.Value.ToString());
        sData.STOCKOUTDATE = ctlStockOutDate.DateValue.Date;
        sData.REMARKS = txtRemark.Text.Trim();
        if (cmbSupplier.SelectedItem.Value.ToString() == Constant.DocType.StockOutReturnHos.SupplierLOID)
            sData.DOCTYPE = Convert.ToDouble(Constant.DocType.StockOutReturnHos.Loid);
        else 
            sData.DOCTYPE = Convert.ToDouble(Constant.DocType.StockOutReturnSupp.Loid);

        sData.STATUS = str;
        sData.DIVISION = Appz.LoggedOnUser.DIVISION;
        sData.LOID = Convert.ToDouble((txhID.Text.Trim() == "" ? "0" : txhID.Text.Trim()));
        sData.STOCKOUTITEM = (DataTable)Session["StockOutItem"];
        return sData;
    }

    private void SetData(StockOutData sData, DataTable dt)
    {
        txhID.Text = sData.LOID.ToString();
        txtCode.Text = sData.CODE.ToString();
        ctlStockOutDate.DateValue = Convert.ToDateTime(sData.STOCKOUTDATE.ToString());
        cmbPlan.SelectedIndex = cmbPlan.Items.IndexOf(cmbPlan.Items.FindByValue(sData.PLANORDER.ToString()));
        Appz.BuildCombo(cmbSupplier, "V_SUPPLIER_PLAN", "NAME", "LOID", "PLANORDER=" + cmbPlan.SelectedValue, "NAME", "เลือก", "0", true);
        cmbSupplier.SelectedIndex = cmbSupplier.Items.IndexOf(cmbSupplier.Items.FindByValue(sData.SUPPLIER.ToString()));

        cmbWarehouse.SelectedIndex = cmbWarehouse.Items.IndexOf(cmbWarehouse.Items.FindByValue(sData.WAREHOUSE.ToString()));
        txtRemark.Text = sData.REMARKS.ToString();
        txtStatusFlag.Text = sData.STATUS.ToString();
        txtStatus.Text = (sData.STATUS == "WA" ? "ทำรายการ" : (sData.STATUS == "SE" ? "รออนุมัติ" : (sData.STATUS == "AP" ? "อนุมัติ" : (sData.STATUS == "VO" ? "ยกเลิก" : ""))));

        this.tbPrint.ClientClick = Appz.OpenReportScript(Constant.Reports.SendSupplierReport, Convert.ToDouble(txhID.Text.Trim()), false);
        this.tbPrint.Visible = (sData.LOID != 0);
        this.tbApprove.Visible = (txhID.Text.Trim() != "" || txhID.Text.Trim() != "0");

        Session["StockOutItem"] = dt;
        BindGVFeedItem();
        this.grvItem.Visible = (txhID.Text.Trim() != "" || txhID.Text.Trim() != "0");
        if (txtStatusFlag.Text.Trim() != "WA")
        {
            this.cmbPlan.Enabled = false;
            ctlStockOutDate.Enabled = false;
            cmbSupplier.Enabled = false;
            cmbWarehouse.Enabled = false;
            txtRemark.CssClass = "zTextbox-View";
            txtRemark.ReadOnly = true;
            tbApprove.Visible = false;
            tbCancel.Visible = false;
            tbSave.Visible = false;
            tbAddStockOutItem.Visible = false;
            tbDeleteStockOutItem.Visible = false;
            this.grvItem.Columns[1].Visible = false;
        }
        else if (txtStatusFlag.Text.Trim() == "WA")
        {
            this.cmbPlan.Enabled = true;
            ctlStockOutDate.Enabled = true;
            cmbSupplier.Enabled = true;
            cmbWarehouse.Enabled = true;
            txtRemark.CssClass = "zTextbox";
            txtRemark.ReadOnly = false;
            tbApprove.Visible =true;
            tbCancel.Visible = true;
            tbSave.Visible = true;
            tbAddStockOutItem.Visible = true;
            tbDeleteStockOutItem.Visible = true;
            this.grvItem.Columns[1].Visible = true;
        }
    }

    private void ClearData()
    {
        txhID.Text = "";
        txtCode.Text = "";
        ctlStockOutDate.DateValue = DateTime.Today.Date;
        cmbWarehouse.SelectedIndex = -1;
        cmbSupplier.SelectedIndex = -1;
        txtRemark.Text = "";
        txtRemark.CssClass = "zTextbox";
        txtRemark.ReadOnly = false;
        txtStatus.Text = "";
        txtStatusFlag.Text = "WA";
        grvItem.DataSource = null;
        grvItem.DataBind();
        grvItem.Visible = false;
        grvItem.Enabled = true;
        tbSave.Visible = true;
        tbApprove.Visible = true;
        tbCancel.Visible = true;
        Session["StockOutItem"] = null;
        cmbPlan.SelectedIndex = -1;
    }

    private void ClearSearch()
    {
        txtNoFrom.Text = "";
        txtNoTo.Text = "";
        txtName.Text = "";
        ctlDateFrom.DateValue = new DateTime();
        ctlDateTo.DateValue = new DateTime();
        cmbStatusFrom.SelectedValue = "00";
        cmbStatusTo.SelectedValue = "00";

    }

    private void doDeleteAllItem()
    {
        DataTable dt = (DataTable)Session["StockOutItem"];
        for (int i = 0; i < grvItem.Rows.Count; i++)
        {
            DataRow dr = dt.Rows[0];
            dt.Rows.Remove(dr);
        }

        Session["StockOutItem"] = dt;
        BindGVFeedItem();
    }

    #endregion

    #region Working Method

    private void doGetList()
    {
        SendSupplierFlow sFlow = new SendSupplierFlow();

        imbReset.Visible = (txtNoFrom.Text.Trim() != "" || txtNoTo.Text.Trim() != "" || txtName.Text.Trim() != "" || ctlDateFrom.DateValue.Year != 1 || ctlDateTo.DateValue.Year != 1 || cmbStatusFrom.SelectedIndex != 0 || cmbStatusTo.SelectedIndex != 0);

        string orderStr = "";
        string wh = "";
        string datefrom = "";
        string dateTo = "";
        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;

        if (ctlDateFrom.DateValue.Year.ToString() != "1" && ctlDateTo.DateValue.Year.ToString() != "1")
        {
            datefrom = ctlDateFrom.DateValue.Day.ToString() + '/' + ctlDateFrom.DateValue.Month.ToString() + '/' + ctlDateFrom.DateValue.Year.ToString();
            dateTo = ctlDateTo.DateValue.Day.ToString() + '/' + ctlDateTo.DateValue.Month.ToString() + '/' + ctlDateTo.DateValue.Year.ToString();
        }
        else if (ctlDateFrom.DateValue.Year.ToString() != "1")
             datefrom = ctlDateFrom.DateValue.Day.ToString() + '/' + ctlDateFrom.DateValue.Month.ToString() + '/' + ctlDateFrom.DateValue.Year.ToString();
         else if (ctlDateTo.DateValue.Year.ToString() != "1")
             dateTo = ctlDateTo.DateValue.Day.ToString() + '/' + ctlDateTo.DateValue.Month.ToString() + '/' + ctlDateTo.DateValue.Year.ToString();

        //Check เลขที่ส่งคืน
        if (txtNoFrom.Text.Trim() != "" && txtNoTo.Text.Trim() != "")
            wh += " UPPER(CODE) BETWEEN UPPER('" + txtNoFrom.Text.Trim() + "') AND UPPER('" + txtNoTo.Text.Trim() + "')";
        else if (txtNoFrom.Text.Trim() != "")
            wh += (wh == "" ? "" : " AND ") + " UPPER(CODE) >= UPPER('" + txtNoFrom.Text.Trim() + "')";
        else if (txtNoTo.Text.Trim() != "")
            wh += (wh == "" ? "" : " AND ") + " UPPER(CODE) <= UPPER('" + txtNoTo.Text.Trim() + "')";


        //Check วันที่ส่งคืน
        if (datefrom != "" && dateTo != "")
            wh += " STOCKOUTDATE BETWEEN TO_DATE('" + datefrom + "','DD/MM/YYYY') AND TO_DATE('" + dateTo + "','DD/MM/YYYY')";
        else if (datefrom != "")
            wh += (wh == "" ? "" : " AND ") + " STOCKOUTDATE >= TO_DATE('" + datefrom + "','DD/MM/YYYY')";
        else if (dateTo != "")
            wh += (wh == "" ? "" : " AND ") + " STOCKOUTDATE <= TO_DATE('" + dateTo + "','DD/MM/YYYY')";

        //ชื่อวัสดุ
        if (txtName.Text.Trim() != "")
            wh += (wh == "" ? "" : " AND ") + " UPPER(MATERIALNAME) LIKE UPPER('%" + txtName.Text.Trim() + "%')";

        //สถานะ
        if (cmbStatusFrom.SelectedItem.Value != "0" && cmbStatusTo.SelectedItem.Value != "0")
            wh += (wh == "" ? "" : " AND ") + " STATUSRANK BETWEEN " + cmbStatusFrom.SelectedItem.Value.ToString() + " AND " + cmbStatusTo.SelectedItem.Value.ToString() + "";
        else if (cmbStatusFrom.SelectedItem.Value == "0")
            wh += (wh == "" ? "" : " AND ") + " STATUSRANK >= " + cmbStatusFrom.SelectedItem.Value + "";
        else if (cmbStatusTo.SelectedItem.Value == "0")
            wh += (wh == "" ? "" : " AND ") + " STATUSRANK <= " + cmbStatusTo.SelectedItem.Value + "";

        grvResult.DataSource = sFlow.GetSendSupplierSearch(wh, orderStr);
        grvResult.DataBind();
        pcTop.Update();
        pcBot.Update();
    }

    private bool DoSaveStockOut()
    {
        bool ret = true;
        //double sLoid = 0;
        SendSupplierFlow sFlow = new SendSupplierFlow();

        //verify required field
        string error = VerifyData("WA");
        if (error != "")
        {
            SetErrorStatus(error);
            return false;
        }

        if (grvItem.Rows.Count == 0)
        {
            SetErrorStatus(string.Format(DataResources.MSGEI002, "รายการที่ต้องส่งคืน"));
            return false;
        }

        //data correct go on saving...
        if (txhID.Text.Trim() == "" || txhID.Text.Trim() == "0")
        {
            //  save new
            ret = sFlow.InsertStockOut(GetData("WA"), Appz.CurrentUser);
            if (ret)
            {
                txhID.Text = sFlow.LOID.ToString();
                ret = DoSaveStockOutItem(sFlow.LOID.ToString(), true);
            }
            else
            {
                SetErrorStatus(sFlow.ErrorMessage);
                return false;
            }
        }
        else
        {
            //save update
            ret = sFlow.UpdateStockOut(GetData("WA"), Appz.CurrentUser);
            if (ret)
            {
                txhID.Text = sFlow.LOID.ToString();
                ret = DoSaveStockOutItem(sFlow.LOID.ToString(), false);
            }
            else
            {
                SetErrorStatus(sFlow.ErrorMessage);
                return false;
            }
        }

        if (!ret)
            SetErrorStatus(sFlow.ErrorMessage);
        else
        {
            doGetList();
            doGetDetail(txhID.Text);
        }

        return ret;
    }

    private bool DoSaveStockOutItem(string sLoid, bool isInsert)
    {
        bool ret = true;
        SendSupplierFlow sFlow = new SendSupplierFlow();

        DataTable dt = new DataTable();
        dt = (DataTable)Session["StockOutItem"];
        for (int i = 0; i < grvItem.Rows.Count; i++)
        {
            if (dt.Rows[i]["MMLOID"].ToString() == grvItem.Rows[i].Cells[9].Text)
            {
                TextBox txtQty = (TextBox)grvItem.Rows[i].FindControl("txtQty");
                TextBox txtRemarks = (TextBox)grvItem.Rows[i].FindControl("txtRemarks");
                if (txtQty.Text != "")
                {
                    dt.Rows[i]["QTY"] = txtQty.Text.Trim();
                    dt.Rows[i]["REMARKS"] = txtRemarks.Text.Trim();
                }
            } 
        }
        if (isInsert)
            ret = sFlow.InsertStockOutItem(dt, Convert.ToDouble(txhID.Text.Trim()), Appz.CurrentUser);
        else
            ret = sFlow.UpdateStockOutItem(dt, Convert.ToDouble(txhID.Text.Trim()), Appz.CurrentUser);

        return ret;
    }

    private bool doGetDetail(string LOID)
    {
        bool ret = true;
        SendSupplierFlow sFlow = new SendSupplierFlow();
        StockOutData sData = sFlow.GetStockOutData(Convert.ToDouble(LOID));
        DataTable dt = sFlow.GetStockOutItemData(Convert.ToDouble(LOID));


        if (sData.LOID != 0)
            SetData(sData, dt);
        else
            ret = false;
        return ret;
    }

    private bool doGetPageChang(string LOID)
    {
        bool ret = true;
        SendSupplierFlow sFlow = new SendSupplierFlow();
        DataTable dt = sFlow.GetStockOutItemData(Convert.ToDouble(LOID));

        if (dt.Rows.Count != 0)
        {
            Session["StockOutItem"] = dt;
            BindGVFeedItem();
        }
        else
            ret = false;
        return ret;
    }

    private string VerifyData(string str)
    {
        string ret = "";
        StockOutData sData = GetData(str);
        if (cmbPlan.SelectedItem.Value.ToString() == "0")
            ret = string.Format(DataResources.MSGEI002, "แผนประมาณการ");
        else if (sData.STOCKOUTDATE.Date.Year == 1)
            ret = string.Format(DataResources.MSGEI002, "วันที่ส่งคืน");
        else if (sData.SUPPLIER == 0)
            ret = string.Format(DataResources.MSGEI002, "บริษัท/ร้านค้า");
        //else if (sData.REMARKS == "")
        //    ret = string.Format(DataResources.MSGEI001, "เหตุที่ส่งคืน");
        else if (sData.WAREHOUSE == 0)
            ret = string.Format(DataResources.MSGEI002, "คลังที่จ่ายออก"); ;
        
        if (grvItem.Rows.Count != 0)
        {
            for (int i = 0; i < grvItem.Rows.Count; i++)
            {
                TextBox txtQty = (TextBox)grvItem.Rows[i].FindControl("txtQty");
                if (txtQty.Text == "" || txtQty.Text=="0.00")
                {
                    ret = string.Format(DataResources.MSGEI001, "จำนวนที่ส่งคืน");
                    break;
                }
            }
        }

        return ret;
    }

    private void doDeleteMain()
    {
        SendSupplierFlow sFlow = new SendSupplierFlow();
        if (sFlow.DeleteStockOutByLoid(GetCheckedMain()))
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

    private bool DoApprove()
    {
        bool ret = true;
        SendSupplierFlow sFlow = new SendSupplierFlow();
        double sLoid = 0;

        if (txhID.Text.Trim() != "" && txhID.Text.Trim() != "0")
        {
            ret = sFlow.UpdateStockOut(GetData("AP"), Appz.CurrentUser);
            sLoid = sFlow.LOID;
            if(sLoid != 0)
            {
                 //bool rr = true;

                 DataTable dt = new DataTable();
                 dt = (DataTable)Session["StockOutItem"];

                 for (int i = 0; i < grvItem.Rows.Count; i++)
                 {
                     if (dt.Rows[i]["MMLOID"].ToString() == grvItem.Rows[i].Cells[9].Text)
                     {
                         TextBox txtQty = (TextBox)grvItem.Rows[i].FindControl("txtQty");
                         TextBox txtRemarks = (TextBox)grvItem.Rows[i].FindControl("txtRemarks");
                         if (txtQty != null)
                         {
                             dt.Rows[i]["QTY"] = txtQty.Text.Trim();
                             dt.Rows[i]["REMARKS"] = txtRemarks.Text.Trim();
                         }
                     }
                 }

                ret = sFlow.UpdateStockOutItem(dt, sLoid, Appz.CurrentUser);
            }   
        }
        else
            SetErrorStatus(string.Format(DataResources.MSGEI002, "รายการส่งคืนร้านค้า"));

        if (sLoid == 0)
        {
            SetErrorStatus(sFlow.ErrorMessage);
            ret = false;
        }
        else
            doGetList();

        return ret;
    }

    private bool InsertNewPreItemToTmp(ArrayList arrData)
    {
        bool ret = true;
        DataTable dt = new DataTable();
        if (Session["StockOutItem"] != null)
        {
            dt = (DataTable)Session["StockOutItem"];
        }
        else
        {
            CreateTempTable();
            dt = tempTable;
        }

        try
        {
            for (int i = 0; i < arrData.Count; i++)
            {
                VSendPreOrderSupplierPopupData VStockout = (VSendPreOrderSupplierPopupData)arrData[i];
                DataRow dr = dt.NewRow();

                dr["MMNAME"] = VStockout.MATERIALNAME;
                dr["MMCODE"] = VStockout.MATERIALCODE;
                dr["UNAME"] = VStockout.UNITNAME;
                dr["UULOID"] = VStockout.UNIT;
                dr["MMLOID"] = VStockout.MATERIALMASTER;
                dt.Rows.Add(dr);
            }

            Session["StockOutItem"] = dt;
        }
        catch (Exception ex)
        {
            ex.ToString();
            ret = false;
        }

        return ret;
    }

    private bool InsertNewDataToTmpStockOutItem(ArrayList arrData)
    {
        bool ret = true;
        DataTable dt = new DataTable();
        if (Session["StockOutItem"] != null)
        {
            dt = (DataTable)Session["StockOutItem"];
        }
        else
        {
            CreateTempTable();
            dt = tempTable;
        }

        try
        {
            for (int i = 0; i < arrData.Count; i++)
            {
                VStockoutReturenPopUpData VStockout = (VStockoutReturenPopUpData)arrData[i];
                DataRow dr = dt.NewRow();

                dr["MMNAME"] = Server.HtmlDecode(VStockout.MATERIALNAME);
                dr["MMCODE"] = VStockout.MATERIALCODE;
                dr["UNAME"] = VStockout.UNITNAME;
                dr["UULOID"] = VStockout.UNIT;
                dr["MMLOID"] = VStockout.MATERIALMASTER;
                dt.Rows.Add(dr);
            }

            Session["StockOutItem"] = dt;
        }
        catch (Exception ex)
        {
            ex.ToString();
            ret = false;
        }

        return ret;
    }

    public void BindGVFeedItem()
    {
        if(Session["StockOutItem"] != null)
        {
            grvItem.DataSource = Session["StockOutItem"];
            grvItem.DataBind();
            grvItem.Visible = true;
            pcTop1.SetMainGridView(grvItem);
            pcBot1.SetMainGridView(grvItem);
            pcTop1.Update();
            pcBot1.Update();
        }
        StockOutPop.Show();
    }

    private void doDeleteStockOutItemOnGrid()
    {
        ArrayList arrSOILOIDList = GetChecked();
        DataTable dt = (DataTable)Session["StockOutItem"];

        if (arrSOILOIDList.Count > 0 && dt != null)
        {
            foreach (string soiloid in arrSOILOIDList)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (soiloid == dt.Rows[i]["MMLOID"].ToString())
                    {
                        DataRow dr = dt.Rows[i];
                        dt.Rows.Remove(dr);
                    }
                }
            }
        }
        Session["StockOutItem"] = dt;
        BindGVFeedItem();
    }


    #endregion

    protected void cmbPlan_SelectedIndexChanged(object sender, EventArgs e)
    {
        Appz.BuildCombo(cmbSupplier, "V_SUPPLIER_PLAN", "NAME", "LOID", "PLANORDER=" + cmbPlan.SelectedValue, "NAME", "เลือก", "0", true);
        doDeleteAllItem();
        StockOutPop.Show();
    }
    protected void cmbSupplier_SelectedIndexChanged(object sender, EventArgs e)
    {
        doDeleteAllItem();
        StockOutPop.Show();
    }
    protected void cmbWarehouse_SelectedIndexChanged(object sender, EventArgs e)
    {
        doDeleteAllItem();
        StockOutPop.Show();
    }
    protected void grvResult_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex > -1)
            e.Row.Cells[2].Text = ((e.Row.RowIndex + 1) + (grvResult.PageIndex * grvResult.PageSize)).ToString();
    }

}
