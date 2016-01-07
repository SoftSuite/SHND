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
/// StockCheckCounter Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Nang
/// Create Date: 6 Feb 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้าการทำงานรายการตรวจนับ StockCheckCounter
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

public partial class App_Inventory_Transaction_StockCheckCounterSearch : System.Web.UI.Page
{
    private DataTable tempTable = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            doGetList();   
        }
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
        pcTop1.Visible = false;
        pcBot1.Visible = false;
    }

    private void SetStatusCombo(DropDownList cmb)
    {
        cmb.Items.Clear();
        cmb.Items.Add(new ListItem("กำลังดำเนินการ", "00"));
        cmb.Items.Add(new ListItem("ยืนยันการนับ", "01"));
        cmb.Items.Add(new ListItem("รออนุมัติ", "02"));
        cmb.Items.Add(new ListItem("อนุมัติ", "03"));
        cmb.Items.Add(new ListItem("ยกเลิก", "04"));
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
        StockCheckPop.Show();
    }

    protected void lnkType_Click(object sender, EventArgs e)
    {
        doGetDetail(((LinkButton)sender).CommandArgument);
        StockCheckPop.Show();
        tbPrint.Visible = (txhID.Text.Trim() != "");
    }

    protected void tbDeleteClick(object sender, EventArgs e)
    {
        doDeleteMain();
    }

    protected void tbApprove_Click(object sender, EventArgs e)
    {
        bool ret = true;
        if (DoSaveStockCheck())
        {
            ret = DoSaveStockCheckItem(txhID.Text.Trim());
            if (!ret)
            {
                StockCheckPop.Show();
            }
            else
            {
                if (DoApprove())
                {
                    doGetDetail(txhID.Text.Trim());
                    if (grvItem.Rows.Count > 0)
                        grvItem.Visible = true;

                    SetStatus("ยืนยันข้อมูลเรียบร้อยแล้ว", false);
                    //doGetList();
                    StockCheckPop.Show();
                }
                else
                {
                    SetStatus("เกิดข้อผิดพลาดในการยืนยันข้อมูล", true);
                    StockCheckPop.Show();
                }
            }
        }
        else
        {
            StockCheckPop.Show();
        }
    }
    #endregion

    #region Button Pop

    protected void tbSave_Click(object sender, EventArgs e)
    {
        bool ret = true;
        if (DoSaveStockCheck())
        {
            ret = DoSaveStockCheckItem(txhID.Text.Trim());
            if (!ret)
            {
                StockCheckPop.Show();
            }
            else
            {
                doGetDetail(txhID.Text.Trim());
                if (grvItem.Rows.Count > 0)
                    grvItem.Visible = true;

                SetStatus("บันทึกข้อมูลเรียบร้อยแล้ว", false);
                //doGetList();
                StockCheckPop.Show();
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

    #endregion

    #endregion

    #region Gridview Event Handler

    protected void grvResult_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex > -1)
        {
            e.Row.Cells[2].Text = ((e.Row.RowIndex + 1) + (grvResult.PageIndex * grvResult.PageSize)).ToString();
            if (e.Row.Cells[6].Text != "กำลังดำเนินการ")
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

            TextBox txtCount = (TextBox)e.Row.FindControl("txtCount");
            if (txtCount != null)
                ControlUtil.SetDblTextBox(txtCount);
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
        doGetPageChang((txhID.Text.Trim()!=""?txhID.Text.Trim():"0"));
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
        DataColumn dcSCILOID = new DataColumn("SCILOID");
        DataColumn dcCOUNTQTY = new DataColumn("COUNTQTY");
        DataColumn dcISIMPROVE = new DataColumn("ISIMPROVE");
        DataColumn dcIMPROVEQTY = new DataColumn("IMPROVEQTY");

        tempTable.Columns.Add(dcSCILOID);
        tempTable.Columns.Add(dcCOUNTQTY);
        tempTable.Columns.Add(dcISIMPROVE);
        tempTable.Columns.Add(dcIMPROVEQTY);
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
        StockCheckCounterFlow sFlow = new StockCheckCounterFlow();
        StockCheckData sData = new StockCheckData();
        sData.MATERIALCLASS = Convert.ToDouble(cmbMaterialClass.SelectedItem.Value.ToString());
        sData.WAREHOUSE = Convert.ToDouble(cmbWarehousePop.SelectedItem.Value.ToString());
        sData.STATUS = txtStatusFlag.Text.Trim();
        sData.REMARKS = txtRemark.Text.Trim();
        sData.CHECKDATE = Convert.ToDateTime(ctlCheckDate.DateValue.Date);
        sData.LOID = Convert.ToDouble((txhID.Text.Trim() == ""?"0":txhID.Text.Trim()));
        sData.BATCHNO = txtBatchNo.Text.Trim();
        return sData;
    }

    private void SetData(StockCheckData sData,DataTable dt)
    {
        txhID.Text = sData.LOID.ToString();
        txtBatchNo.Text = sData.BATCHNO.ToString();
        ctlCheckDate.DateValue = Convert.ToDateTime(sData.CHECKDATE);
        cmbWarehousePop.SelectedIndex = cmbWarehousePop.Items.IndexOf(cmbWarehousePop.Items.FindByValue(sData.WAREHOUSE.ToString()));
        cmbMaterialClass.SelectedIndex = cmbMaterialClass.Items.IndexOf(cmbMaterialClass.Items.FindByValue(sData.MATERIALCLASS.ToString()));
        txtRemark.Text = sData.REMARKS.ToString();
        txtStatusFlag.Text = sData.STATUS.ToString();
        txtStatus.Text = (sData.STATUS == "WA" ? "กำลังดำเนินการ" : (sData.STATUS == "CN" ? "ยืนยันการนับ" : (sData.STATUS == "CO" ? "รออนุมัติ" : (sData.STATUS == "AP" ? "อนุมัติ" : (sData.STATUS == "VO" ? "ยกเลิก" : "")))));

        this.tbPrint.ClientClick = Appz.OpenReportScript(Constant.Reports.StockCheckCountReport, Convert.ToDouble(txhID.Text.Trim()), false);
        this.tbPrint.Visible = (sData.LOID != 0);
        this.tbApprove.Visible = (txhID.Text.Trim() != "" || txhID.Text.Trim() != "0");

        grvItem.DataSource = dt;
        grvItem.DataBind();
        pcTop1.SetMainGridView(grvItem);
        pcBot1.SetMainGridView(grvItem);
        pcTop1.Update();
        pcBot1.Update();
        this.grvItem.Visible = (txhID.Text.Trim() != "" || txhID.Text.Trim() != "0");
        if (grvItem.Rows.Count == 0)
        {
            pcTop1.Visible = false;
            pcBot1.Visible = false;
        }
        SetControl();
        this.tbApprove.Visible = (sData.LOID > 0);
        if (txtStatusFlag.Text.Trim() == "WA")
        {
            txtRemark.CssClass = "zTextbox";
            txtRemark.ReadOnly = false;
            tbApprove.Visible = true;
            tbSave.Visible = true;
            for (int i = 0; i < grvItem.Rows.Count; ++i)
            {
                TextBox txtCount = (TextBox)grvItem.Rows[i].FindControl("txtCount");
                txtCount.CssClass = "zTextbox";
                txtCount.ReadOnly = false;
            }
        }
        else
        {
            //grvItem.Enabled = false;
            txtRemark.CssClass = "zTextbox-View";
            txtRemark.ReadOnly = true;
            tbApprove.Visible = false;
            tbSave.Visible = false;
            for (int i = 0; i < grvItem.Rows.Count; ++i)
            {
                TextBox txtCount = (TextBox)grvItem.Rows[i].FindControl("txtCount");
                txtCount.CssClass = "zTextboxR-View";
                txtCount.ReadOnly = true;
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
        pcTop1.Visible = false;
        pcBot1.Visible = false;
        txtRemark.CssClass = "zTextbox";
        txtRemark.ReadOnly = false;
        cmbMaterialClass.Enabled = true;
        cmbWarehousePop.Enabled = true;
        tbSave.Visible = true;
        tbApprove.Visible = false;
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
        StockCheckCounterFlow sFlow = new StockCheckCounterFlow();
        string orderStr = "";
        string wh = "";
        string datefrom = "";
        string dateTo ="";
        this.imbReset.Visible = (this.txtNoFrom.Text.Trim() != "") || (this.txtNoTo.Text.Trim() != "") || (this.ctlDateFrom.DateValue.Year != 1) || (this.ctlDateTo.DateValue.Year != 1) ||
            (this.cmbWarehouse.SelectedIndex != 0) || (this.cmbStatusFrom.SelectedIndex != 0) || (this.cmbStatusTo.SelectedIndex != 0);

        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;

        if (ctlDateFrom.DateValue.Year.ToString() != "1" && ctlDateTo.DateValue.Year.ToString() != "1")
        {
            datefrom = ctlDateFrom.DateValue.Day.ToString()+'/' + ctlDateFrom.DateValue.Month.ToString() +'/'+ ctlDateFrom.DateValue.Year.ToString();
            dateTo = ctlDateTo.DateValue.Day.ToString() + '/' + ctlDateTo.DateValue.Month.ToString() + '/' + ctlDateTo.DateValue.Year.ToString();
        }


        //Check เลขที่ตรวจรับ
        if(txtNoFrom.Text.Trim() != "" && txtNoTo.Text.Trim() != "")
            wh += " BATCHNO BETWEEN "+ txtNoFrom.Text.Trim() +" AND "+ txtNoTo.Text.Trim()+"";
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
        if(cmbWarehouse.SelectedItem.Value.ToString() != "0")
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
        //verify required field
        string error = VerifyData();
        if (error != "")
        {
            SetStatus(error, true);
            return false;
        }
        StockCheckCounterFlow sFlow = new StockCheckCounterFlow();

        // verify uniq field
        if (!sFlow.CheckUniqe(txtBatchNo.Text.Trim(), Convert.ToDouble(txhID.Text == "" ? "0" : txhID.Text.Trim()), "BATCHNO"))
        {
            SetStatus(string.Format(DataResources.MSGEI015, "เลขที่ตรวจนับ", this.txtBatchNo.Text.Trim()), true);
            return false;
        }

        //data correct go on saving...
        double sLoid = 0;
        if (txhID.Text.Trim() == "" || txhID.Text.Trim() == "0")
        {
            //  save new
            sLoid = sFlow.InsertStockCheck(GetData(), Appz.CurrentUser);
            txhID.Text = sLoid.ToString();
            txtFlag.Text = "0";
            ret = true;
        }
        else
        {
            //save update
            sLoid = sFlow.UpdateStockCheck(GetData(), Appz.CurrentUser);
            txhID.Text = sLoid.ToString();
            txtFlag.Text = "1";
            
        }

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

        StockCheckCounterFlow sFlow = new StockCheckCounterFlow();

        if (txtFlag.Text.Trim() == "0")
        {
            //Insert New
            DataTable dt = new DataTable();
            dt = sFlow.GetMaterialMaterList(Convert.ToDouble(cmbMaterialClass.SelectedItem.Value.ToString()));
            ret = sFlow.InsertStockCheckItem(dt, Convert.ToDouble(txhID.Text.Trim()), Appz.CurrentUser);

        }
        else
        {
            CreateTempTable();
            for (int i = 0; i < grvItem.Rows.Count; i++)
            {
                DataRow ddr = tempTable.Rows.Add();
                ddr["SCILOID"] = grvItem.Rows[i].Cells[6].Text.Trim();
                TextBox txtCount = (TextBox)grvItem.Rows[i].FindControl("txtCount");
                if (txtCount != null)
                {
                   // if (txtCount.Text.Trim() != "0" && txtCount.Text.Trim() != "0.00")
                   // {
                        ddr["COUNTQTY"] = txtCount.Text.Trim();
                        ddr["IMPROVEQTY"] = txtCount.Text.Trim();
                  //  }
                  //  else
                  //  {
                  //      SetStatus("กรุณาระบุจำนวนที่นับได้ รายการที่ " + Convert.ToDouble(i+1),true);
                  //      ret = false;
                  //      return ret;
                  //  }
                }
            }
            ret = sFlow.UpdateStockCheckItem(tempTable,  Appz.CurrentUser);
            if (!ret)
                SetStatus("เกิดข้อผิดพลาดในการบันทึกข้อมูล", true);
        }
        return ret;
    }

    private bool doGetDetail(string LOID)
    {
        bool ret = true;
        StockCheckCounterFlow sFlow = new StockCheckCounterFlow();
        StockCheckData sData = sFlow.GetStockCheckData(Convert.ToDouble(LOID));
        DataTable dt = sFlow.GetStockCheckItemData(Convert.ToDouble(LOID));

        if (sData.LOID != 0)
            SetData(sData,dt);
        else
            ret = false;
        return ret;
    }

    private bool doGetPageChang(string LOID)
    {
        bool ret = true;
        StockCheckCounterFlow sFlow = new StockCheckCounterFlow();
        DataTable dt = sFlow.GetStockCheckItemData(Convert.ToDouble(LOID));

        if (dt.Rows.Count != 0)
        {
            grvItem.DataSource = dt;
            grvItem.DataBind();
        }
        else
            ret = false;
        return ret;
    }

    private string VerifyData()
    {
        string ret = "";
        StockCheckData sData = GetData();
        if (sData.WAREHOUSE == 0)
            ret = string.Format(DataResources.MSGEI002, "คลังที่ตรวจนับ");
        else if (sData.MATERIALCLASS == 0)
            ret = string.Format(DataResources.MSGEI002, "หมวดวัสดุ");
        else if (CheckMaterialMaster())
            ret = "ไม่พบรายการวัสดุในหมวดนี้";

        return ret;
    }

    private void doDeleteMain()
    {
        StockCheckCounterFlow sFlow = new StockCheckCounterFlow();
        if (sFlow.DeleteStockCheckByLoid(GetChecked()))
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

    private bool CheckMaterialMaster()
    {
        StockCheckCounterFlow sFlow = new StockCheckCounterFlow();
        return sFlow.CheckMaterialMaster(cmbMaterialClass.SelectedItem.Value.ToString());
    }


    private bool DoApprove()
    {
        bool ret = true;
        StockCheckCounterFlow sFlow = new StockCheckCounterFlow();
        double sLoid = 0;

        //save update
        if (txhID.Text.Trim() != "" && txhID.Text.Trim() != "0")
        {
            sLoid = sFlow.UpdateApprove(Convert.ToDouble(txhID.Text.Trim()), Appz.CurrentUser);
            txhID.Text = sLoid.ToString();
        }
        else
            SetStatus(string.Format(DataResources.MSGEI002, "รายการตรวจนับ"), true);


        if (sLoid == 0)
        {
            SetStatus(sFlow.ErrorMessage, true);
            ret = false;
        }
        //else
        //{
        //    doGetList();
        //    ClearData();
        //}

        return ret;
    }
    #endregion

  
}
