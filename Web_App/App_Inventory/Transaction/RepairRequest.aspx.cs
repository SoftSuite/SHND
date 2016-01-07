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
/// RepairRequest Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Pro
/// Create Date: 12 FEB 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้ากาารทำงาน RepairRequest
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

public partial class App_Inventory_Transaction_RepairRequest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cmbDev.SelectedIndex = cmbDev.Items.IndexOf(cmbDev.Items.FindByValue(Appz.LoggedOnUser.DIVISION.ToString()));
            cmbDev.Enabled = false;
            if (Request["loid"] != null)
            {
                doGetDetail((Request["loid"] == null ? "0" : Request["loid"]));
            }
            else
            {
                RepairrequestItem rqItem = new RepairrequestItem();
                rqItem.ClearRepairrequestItem();
            }
        }
    }
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        this.txtStatus.Text = "WA";
        this.txtStatusName.Text = "ทำรายการ";
        this.ctlSentDate.DateValue = DateTime.Now;
        Appz.BuildCombo(cmbWarehouse, "WAREHOUSE", "NAME", "LOID", "ISVIRTUAL='N' AND ACTIVE= '1'", "LOID", "เลือก", "0", true);
        Appz.BuildCombo(cmbDev, "DIVISION", "NAME", "LOID", "ACTIVE= '1'", "LOID", "เลือก", "0", true);
        ControlUtil.SetIntTextBox(txtNo);
    }

    #region Button Click Event Handler

    protected void imbSearch_Click(object sender, ImageClickEventArgs e)
    {
        this.RepairrequestPopup1.Show(Convert.ToDouble(this.cmbWarehouse.SelectedItem.Value));
    }
    protected void tbSaveClick(object sender, EventArgs e)
    {
        doSave();
    }
    protected void tbSendClick(object sender, EventArgs e)
    {
        doSave();
        doSave("SE", true);
    }
    protected void tbCancelClick(object sender, EventArgs e)
    {
        doGetDetail("0" + this.txtLOID.Text);
    }
    protected void tbBackClick(object sender, EventArgs e)
    {
        Response.Redirect(Constant.HomeFolder + "App_Inventory/Transaction/RepairRequestSearch.aspx");
    }
    protected void tbPrintClick(object sender, EventArgs e)
    {
        //this.tbPrint.ClientClick = Appz.OpenReportScript(Constant.Reports.RepRepairRequest, rqData.LOID, false);
    }
    private void SetStatus(string t, bool isError)
    {
        this.lbStatus.Text = t;
        this.lbStatus.ForeColor = (isError ? Constant.StatusColor.Error : Constant.StatusColor.Information);
    }
    #endregion

    #region FormulaFeedItem Toolbar
    
    #endregion

    #region FormulaDisease Toolbar
    
    #endregion

    #region Gridview Event Handler

    protected void gvFormulaFeedItem_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList cmbUnit = (DropDownList)e.Row.Cells[6].FindControl("cmbUnit");

            Appz.BuildCombo(cmbUnit, "V_MATERIALMASTER_UNIT", "UNITNAME", "UNIT", "ISFORMULA = 'Y' AND MATERIALMASTER = " + e.Row.Cells[12].Text, "", null, null, false);
            DataRow drow = (DataRow)((DataRowView)e.Row.DataItem).Row;
            cmbUnit.SelectedIndex = cmbUnit.Items.IndexOf(cmbUnit.Items.FindByValue(drow["UNIT"].ToString()));
        }
    }
    
    #endregion

    #region Misc. Methods

    protected void gvMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex > -1)
            e.Row.Cells[1].Text = ((e.Row.RowIndex + 1) + (gvMain.PageIndex * gvMain.PageSize)).ToString();
    }
    //protected void gvMain_Sorting(object sender, GridViewSortEventArgs e)
    //{
    //    RepairRequestFlow fFlow = new RepairRequestFlow();
    //    if (e.SortExpression == "DEFAULT")
    //    {
    //        txhSortDir.Text = "";
    //        txhSortField.Text = "";
    //    }
    //    else
    //    {
    //        if (txhSortField.Text == e.SortExpression)
    //            txhSortDir.Text = (txhSortDir.Text.Trim() == "" ? "DESC" : "");
    //        else
    //            txhSortField.Text = e.SortExpression;
    //    }
    //    doGetDetail();

    //}
    protected void ctlRepairrequestPopup_SelectedIndexChanged(object sender, EventArgs e, VStockRemainData selectedData)
    {
        SetMaterialMasterDetail(selectedData);
    }

    #endregion

    #region Controls Management Methods

    private void BindRepairrequestItem()
    {
        
    }

    private void RepairStatus(string t)
    {
        lbStatus.Text = t;
        lbStatus.ForeColor = Constant.StatusColor.Information;
    }

    private void SetErrorStatus(string t)
    {
        lbStatus.Text = t;
        lbStatus.ForeColor = Constant.StatusColor.Error;
    }

    private void SetMaterialMasterDetail(VStockRemainData selectedData)
    {
        this.txtMaterialMaster.Text = selectedData.MATERIALMASTER.ToString();
        this.txtMCode.Text = selectedData.CODE;
        this.txtMName.Text = selectedData.MATERIALNAME;
        this.txtLotNo.Text = selectedData.LOTNO;
        this.txtBrand.Text = selectedData.BRAND;
        this.lblUnitName.Text = selectedData.UNITNAME;
        this.txtUnit.Text = selectedData.UNIT.ToString();
        this.txtMaterialLoid.Text = selectedData.MATERIALMASTER.ToString();
    }

    private RepairRequestData GetDataStatus()
    {
        RepairRequestData rqData = new RepairRequestData();
        rqData.LOID = Convert.ToDouble("0" + this.txtLOID.Text);
        rqData.CODE = this.txtCode.Text;
        rqData.STOCKOUTDATE = DateTime.Now;
        rqData.STATUS = "SE";
        if (this.txtStatus.Text == "WA") this.txtStatusName.Text = "ทำรายการ";
        else if (this.txtStatus.Text == "SE") this.txtStatusName.Text = "รออนุมัติ";
        else if (this.txtStatus.Text == "AP") this.txtStatusName.Text = "อนุมัติ";
        else if (this.txtStatus.Text == "NP") this.txtStatusName.Text = "ไม่อนุมัติ";
        else if (this.txtStatus.Text == "VO") this.txtStatusName.Text = "ยกเลิก";
        rqData.WAREHOUSE = Convert.ToDouble(this.cmbWarehouse.SelectedItem.Value);
        rqData.DIVISION = Convert.ToDouble(this.cmbDev.SelectedItem.Value);
        rqData.SIUNIT = Convert.ToDouble("0" + this.txtUnit.Text);
        rqData.REMARKS = this.txtDetail.Text;
        rqData.REPAIRBY = this.txtRepairBy.Text;
        rqData.FLOOR = Convert.ToDouble("0" + this.txtFloor.Text);
        rqData.SIQTY = Convert.ToDouble("0" + this.txtNo.Text);
        rqData.MATERIAL = Convert.ToDouble("0" + this.txtMaterialLoid.Text);
        rqData.SIBRAND = this.txtBrand.Text;
        rqData.SILOTNO = this.txtLotNo.Text;

        if (rdbNormal.Checked == true)
        {
            rqData.PRIORITY = 1;
        }
        else if (rdbSpeed.Checked == true)
        {
            rqData.PRIORITY = 2;
        }
        else
            rqData.PRIORITY = 3;
        RepairrequestItem item = new RepairrequestItem();

        return rqData;
    }
    private RepairRequestData GetData()
    {
        RepairRequestData rqData = new RepairRequestData();
        rqData.LOID = Convert.ToDouble("0" + this.txtLOID.Text);
        rqData.CODE = this.txtCode.Text;
        rqData.STOCKOUTDATE = DateTime.Now;
        rqData.STATUS = this.txtStatus.Text;
        if (this.txtStatus.Text == "WA") this.txtStatusName.Text = "ทำรายการ";
        else if (this.txtStatus.Text == "SE") this.txtStatusName.Text = "รออนุมัติ";
        else if (this.txtStatus.Text == "AP") this.txtStatusName.Text = "อนุมัติ";
        else if (this.txtStatus.Text == "NP") this.txtStatusName.Text = "ไม่อนุมัติ";
        else if (this.txtStatus.Text == "VO") this.txtStatusName.Text = "ยกเลิก";
        rqData.WAREHOUSE = Convert.ToDouble(this.cmbWarehouse.SelectedItem.Value);
        rqData.DIVISION = Convert.ToDouble(this.cmbDev.SelectedItem.Value);
        rqData.SIUNIT = Convert.ToDouble("0" + this.txtUnit.Text);
        rqData.REMARKS = this.txtDetail.Text;
        rqData.REPAIRBY = this.txtRepairBy.Text;
        rqData.FLOOR = Convert.ToDouble("0" + this.txtFloor.Text);
        rqData.SIQTY = Convert.ToDouble("0" + this.txtNo.Text);
        rqData.MATERIAL = Convert.ToDouble("0" + this.txtMaterialLoid.Text);
        rqData.SILOTNO = this.txtLotNo.Text;
        rqData.SIBRAND = this.txtBrand.Text;
        
        if (rdbNormal.Checked)
        {
            rqData.PRIORITY = 1;
        }
        else if (rdbSpeed.Checked)
        {
            rqData.PRIORITY = 2;
        }
        else
            rqData.PRIORITY = 3;
        RepairrequestItem item = new RepairrequestItem();

        return rqData;
    }
    private RepairRequestData SentData()
    {
        RepairRequestData rqData = new RepairRequestData();
        rqData.LOID = Convert.ToDouble("0" + this.txtLOID.Text);
        rqData.CODE = this.txtCode.Text;
        rqData.STOCKOUTDATE = DateTime.Now;
        rqData.STATUS = "SE";
        rqData.WAREHOUSE = Convert.ToDouble(this.cmbWarehouse.SelectedItem.Value);
        rqData.DIVISION = Convert.ToDouble(this.cmbDev.SelectedItem.Value);
        rqData.SIUNIT = Convert.ToDouble("0" + this.txtUnit.Text);
        rqData.REMARKS = this.txtDetail.Text;
        rqData.REPAIRBY = this.txtRepairBy.Text;
        rqData.FLOOR = Convert.ToDouble("0" + this.txtFloor.Text);
        rqData.SIQTY = Convert.ToDouble("0" + this.txtNo.Text);
        rqData.MATERIAL = Convert.ToDouble("0" + this.txtMaterialLoid.Text);
        if (rdbNormal.Checked == true)
        {
            rqData.PRIORITY = 1;
        }
        else if (rdbSpeed.Checked == true)
        {
            rqData.PRIORITY = 2;
        }
        else
            rqData.PRIORITY = 3;
        RepairrequestItem item = new RepairrequestItem();

        return rqData;
    }
    private bool doSave(string status, bool sendOrg)
    {
        RepairRequestFlow ftFlow = new RepairRequestFlow();
        bool ret = true;
        string error = "";

        // verify required field
        RepairRequestData pData = GetDataStatus();
        if (status != "") pData.STATUS = status;

        error = VerifyData(pData);
        if (error != "")
        {
            SetStatus(error, true);
            return false;
        }
        ret = ftFlow.UpdateData(pData, Appz.CurrentUser);

        if (!ret)
            SetStatus(ftFlow.ErrorMessage, true);
        else
        {
            doGetDetail(ftFlow.LOID.ToString());
            SetStatus(DataResources.MSGIU001, false);
        }
        return ret;
    }
    private void SetData(RepairRequestData rqData)
    {
        bool pageAuthorized = true;
        this.txtLOID.Text = rqData.LOID.ToString();
        this.txtCode.Text = rqData.CODE;
        this.cmbWarehouse.SelectedIndex = this.cmbWarehouse.Items.IndexOf(this.cmbWarehouse.Items.FindByValue(rqData.WAREHOUSE.ToString()));
        this.cmbDev.SelectedIndex = this.cmbDev.Items.IndexOf(this.cmbDev.Items.FindByValue(rqData.DIVISION.ToString()));
        this.ctlSentDate.DateValue = rqData.STOCKOUTDATE;
        this.txtStatus.Text = rqData.STATUS;
        if (this.txtStatus.Text == "WA") 
            this.txtStatusName.Text = "ทำรายการ";
        else 
        {
            this.cmbDev.Enabled = false;
            this.cmbWarehouse.Enabled = false;
            this.rdbEmergency.Enabled = false;
            this.rdbNormal.Enabled = false;
            this.rdbSpeed.Enabled = false;
            this.txtRepairBy.Enabled = false;
            this.txtNo.Enabled = false;
            this.txtDetail.Enabled = false;
            this.txtFloor.Enabled = false;
            this.imbSearch.Visible = false;
            this.tbSave.Visible = false;

            if (this.txtStatus.Text == "SE") this.txtStatusName.Text = "รอส่งซ่อม";
            else if (this.txtStatus.Text == "AP") this.txtStatusName.Text = "ส่งซ่อมแล้ว";
            else if (this.txtStatus.Text == "NP") this.txtStatusName.Text = "ไม่อนุมัติ";
            else if (this.txtStatus.Text == "FN") this.txtStatusName.Text = "เสร็จสิ้น";
            else if (this.txtStatus.Text == "VO") this.txtStatusName.Text = "ยกเลิก";
        }
        
        
        this.txtRepairBy.Text = rqData.REPAIRBY;
        this.txtDetail.Text = rqData.REMARKS;
        this.txtMaterialLoid.Text = rqData.MATERIAL.ToString();
        this.txtUnit.Text = rqData.SIUNIT.ToString();
        this.txtFloor.Text = rqData.FLOOR.ToString();
        this.txtLotNo.Text = rqData.SILOTNO;
        this.txtRepairBy.Text = rqData.REPAIRBY;
        this.txtDetail.Text = rqData.REMARKS;
        this.lblUnitName.Text = rqData.UNITNAME;
        this.txtMCode.Text = rqData.SICODE;
        this.txtMName.Text = rqData.MATERIALNAME;
        this.txtBrand.Text = rqData.SIBRAND;
        this.txtNo.Text = rqData.SIQTY.ToString();
        if (rqData.PRIORITY == 1)
        {
            this.rdbNormal.Checked = true;
            this.rdbEmergency.Checked = false;
            this.rdbSpeed.Checked = false;
        }
        else if (rqData.PRIORITY == 2)
        {
            this.rdbNormal.Checked = false;
            this.rdbEmergency.Checked = false;
            this.rdbSpeed.Checked = true;
        }
        else if (rqData.PRIORITY == 3)
        {
            this.rdbNormal.Checked = false;
            this.rdbEmergency.Checked = true;
            this.rdbSpeed.Checked = false;
        }

        RepairRequestFlow fFlow = new RepairRequestFlow();
        this.txtName.Text = fFlow.GetName(rqData.CREATEBY);
        if (rqData.LOID == 0)
        {
            this.txtStatus.Text = "WA";
            this.txtStatusName.Text = "ทำรายการ";
            this.rdbNormal.Checked = true;
            this.ctlSentDate.DateValue = DateTime.Now;
        }

        if (!pageAuthorized || rqData.STATUS != "WA")
        {
            this.tbSend.Visible = false;
            this.tbCancel.Visible = false;
        }
        else
        {
            this.tbSend.Visible = true;
            this.tbCancel.Visible = true;
        }

        this.tbPrint.ClientClick = Appz.OpenReportScript(Constant.Reports.RepRepairRequest, rqData.LOID, true);
    }

    #endregion

    #region Working Method

    
    private bool doGetDetail(string LOID)
    {
        RepairRequestFlow fFlow = new RepairRequestFlow();
        string orderStr = "";
        gvMain.DataSource = fFlow.GetRepairList(Convert.ToDouble("0" + LOID), orderStr);
        gvMain.DataBind();
        RepairRequestData rData = fFlow.GetDetails(Convert.ToDouble(LOID));

        bool ret = true;
        SetData(rData);
        RepairrequestItem fsItem = new RepairrequestItem();
        
        return ret;
    }

    private bool doSaveSent()
    {
        // verify required field
        RepairRequestData RepairRequestDetail = SentData();
        string error = VerifyData(RepairRequestDetail);
        if (error != "")
        {
            SetErrorStatus(error);
            return false;
        }

        RepairRequestFlow ftFlow = new RepairRequestFlow();
        bool ret = true;

        // data correct go on saving...
        if (RepairRequestDetail.LOID != 0)
            ret = ftFlow.UpdateData(RepairRequestDetail, Appz.CurrentUser);
        else
            ret = ftFlow.InsertData(RepairRequestDetail, Appz.CurrentUser);

        if (!ret)
            SetErrorStatus(ftFlow.ErrorMessage);
        else
        {
            //this.txtCurentTab.Text = this.tabFormulaFeed.ActiveTabIndex.ToString();
            doGetDetail(ftFlow.LOID.ToString());
            if (RepairRequestDetail.LOID != 0)
                RepairStatus(DataResources.MSGIU001);
            else
                RepairStatus(DataResources.MSGIN001);
        }

        return ret;
    }
    private bool doSave()
    {
        // verify required field
        RepairRequestData RepairRequestDetail = GetData();
        string error = VerifyData(RepairRequestDetail);
        if (error != "")
        {
            SetErrorStatus(error);
            return false;
        }

        RepairRequestFlow ftFlow = new RepairRequestFlow();
        bool ret = true;

        // data correct go on saving...
        if (RepairRequestDetail.LOID != 0)
            ret = ftFlow.UpdateData(RepairRequestDetail, Appz.CurrentUser);
        else
            ret = ftFlow.InsertData(RepairRequestDetail, Appz.CurrentUser);

        if (!ret)
            SetErrorStatus(ftFlow.ErrorMessage);
        else
        {
            //this.txtCurentTab.Text = this.tabFormulaFeed.ActiveTabIndex.ToString();
            doGetDetail(ftFlow.LOID.ToString());
            if (RepairRequestDetail.LOID != 0)
                RepairStatus(DataResources.MSGIU001);
            else
                RepairStatus(DataResources.MSGIN001);
        }

        return ret;
    }
    private string VerifyData(RepairRequestData fData)
    {
        string ret = "";
        //bool check = true;
        if (fData.STOCKOUTDATE.Year == 1)
            ret = string.Format(DataResources.MSGEI002, "วันที่ส่งซ่อม");
        else if (fData.WAREHOUSE == 0)
            ret = string.Format(DataResources.MSGEI002, "คลัง");
        else if (fData.DIVISION == 0)
            ret = string.Format(DataResources.MSGEI002, "หน่วยที่แจ้งซ่อม");
        else if (fData.MATERIAL == 0)
            ret = string.Format(DataResources.MSGEI002, "วัสดุที่ส่งซอม");

        return ret;
    }

    #endregion

    protected void rdbNormal_CheckedChanged(object sender, EventArgs e)
    {
        if (rdbNormal.Checked == true)
        {
            rdbEmergency.Checked = false;
            rdbSpeed.Checked = false;
        }

    }
    protected void rdbSpeed_CheckedChanged(object sender, EventArgs e)
    {
        if (rdbSpeed.Checked == true)
        {
            rdbEmergency.Checked = false;
            rdbNormal.Checked = false;
        }
    }
    protected void rdbEmergency_CheckedChanged(object sender, EventArgs e)
    {
        if (rdbEmergency.Checked == true)
        {
            rdbSpeed.Checked = false;
            rdbNormal.Checked = false;
        }
    }
}
