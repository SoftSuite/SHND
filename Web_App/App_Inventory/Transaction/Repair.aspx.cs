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
using SHND.Flow.Inventory;
using SHND.Data.Inventory;
using SHND.Global;
using SHND.Flow.Common;

/// <summary>
/// FoodType Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Pro
/// Create Date: 11 Feb 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้ากาารทำงานข้อมูล Repair
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

public partial class App_Inventory_Transaction_Repair : System.Web.UI.Page
{
    //private DataTable tempTable = null;

    private RepairItem item;
    public RepairItem ItemObj
    {
        get { if (item == null) item = new RepairItem(); return item; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["loid"] != null)
            {
                doGetDetail((Request["loid"] == null ? "0" : Request["loid"]));
            }
        }
    }
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        this.ctlSentDate.DateValue = DateTime.Now;
        Appz.BuildCombo(cmbWarehouse, "WAREHOUSE", "NAME", "LOID", "ISVIRTUAL='N' AND ACTIVE='1'", "NAME", "ทั้งหมด", "", false);
        Appz.BuildCombo(cmbDev, "DIVISION", "NAME", "LOID", "", "NAME", "ทั้งหมด", "", false);
    }

    #region Button Click Event Handler

    protected void tbSaveClick(object sender, EventArgs e)
    {
        doSave();
    }
    protected void tbReceiveClick(object sender, EventArgs e)
    {
        doSave("FN", true);
    }
    protected void tbApproveClick(object sender, EventArgs e)
    {
        doSave("AP", true);
    }
    protected void tbCancelClick(object sender, EventArgs e)
    {
        doGetDetail("0" + this.txtLOID.Text);
    }
    protected void tbBackClick(object sender, EventArgs e)
    {
        Response.Redirect(Constant.HomeFolder + "App_Inventory/Transaction/RepairSearch.aspx");
    }
    protected void tbPrintClick(object sender, EventArgs e)
    {
        //this.tbPrint.ClientClick = Appz.OpenReportScript(Constant.Reports.RepRepairRequest, rqData.LOID, false);
    }

    #endregion


    #region grvItemNew
    private void SetGrvItem()
    {
        this.grvItem.DataBind();
        this.grvItemNew.DataBind();

        if (grvItem.Rows.Count > 0)
        {
            this.grvItem.Visible = true;
            this.grvItemNew.Visible = false;
        }
        else
        {
            this.grvItem.Visible = false;
            this.grvItemNew.Visible = true;
        }
    }
    protected void grvItemNew_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Int16 rowIndex = 0;
        Templates_CalendarControl ctlDate = (Templates_CalendarControl)this.grvItemNew.Rows[rowIndex].Cells[2].FindControl("ctlNewDate");
        TextBox txtDetail = (TextBox)this.grvItemNew.Rows[rowIndex].Cells[3].FindControl("txtNewDetail");
       
        if (e.CommandName == "Insert")
        {
            RepairItemData data = new RepairItemData();
            data.DESCRIPTION = txtDetail.Text;
            data.REPAIRDATE = ctlDate.DateValue;

            if (ItemObj.InsertRepairItem(data))
            {
                SetGrvItem();
            }
            //else
                //Appz.ClientAlert(this, ItemObj.ErrorMessage);
        }
    }

    protected void grvItemNew_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (this.txtStockoutItemLoid.Text != "0")
            {
                string tableName = "(SELECT * FROM REPAIRSTATUS WHERE STOCKOUTITEM = '" + this.txtStockoutItemLoid.Text + "')";
            }
        }
    }

    #endregion
    #region grvItem

    protected void grvItem_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Templates_CalendarControl ctlDate = (Templates_CalendarControl)this.grvItem.FooterRow.Cells[2].FindControl("ctlNewDate1");
        TextBox txtDetail = (TextBox)this.grvItem.FooterRow.Cells[3].FindControl("txtDetailNew");

        if (e.CommandName == "Insert")
        {
            RepairItemData data = new RepairItemData();
            data.REPAIRDATE = ctlDate.DateValue;
            data.DESCRIPTION = txtDetail.Text;

            if (ItemObj.InsertRepairItem(data))
            {
                SetGrvItem();
            }
            //else
                //Appz.ClientAlert(this, ItemObj.ErrorMessage);
        }
    }

    protected void grvItem_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //string tableName = "(SELECT * FROM REPAIRSTATUS WHERE STOCKOUTITEM = '" + this.txtStockoutItemLoid.Text + "')";
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate) || e.Row.RowState == DataControlRowState.Edit)
            {
                ImageButton imbCancel = (ImageButton)e.Row.FindControl("imbCancel");

                imbCancel.OnClientClick = "return confirm('ยืนยันการยกเลิกรายการ');";
            }
            else if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                ImageButton imbDelete = (ImageButton)e.Row.FindControl("imbDelete");

                imbDelete.OnClientClick = "return confirm('ยืนยันการลบรายการ');";
            }
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {

        }
    }
   
    protected void grvItem_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        if (e.ExceptionHandled)
        {
            e.KeepInEditMode = true;
            //Appz.ClientAlert(this, e.Exception.Message);
        }
    }

    protected void grvItem_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        if (e.ExceptionHandled)
        {
            //Appz.ClientAlert(this, e.Exception.Message);
        }
        else
        {
            SetGrvItem();
        }
    }

    protected void grvItem_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Templates_CalendarControl ctlDate = (Templates_CalendarControl)this.grvItem.Rows[e.RowIndex].Cells[2].FindControl("ctlEditDate");
        TextBox txtDetail = (TextBox)this.grvItem.Rows[e.RowIndex].Cells[3].FindControl("txtDetailEdit");

        RepairItemData data = new RepairItemData();
        data.REPAIRDATE = ctlDate.DateValue;
        data.DESCRIPTION = txtDetail.Text;

        e.NewValues["DESCRIPTION"] = data.DESCRIPTION;
        e.NewValues["REPAIRDATE"] = data.REPAIRDATE;
    }

       #endregion

    #region Misc. Methods

    protected void ctlRepairrequestPopup_SelectedIndexChanged(object sender, EventArgs e, ArrayList arrData)
    {
        RepairrequestItem rqItem = new RepairrequestItem();
        if (rqItem.InsertRepairrequest(Convert.ToDouble("0" + this.txtLOID.Text), arrData))
            BindRepairrequestItem();
    }

    #endregion

    #region Controls Management Methods

    private void BindRepairrequestItem()
    {
        //this.gvMain.DataBind();
    }

    private void FeedStatus(string t)
    {
        lbStatus.Text = t;
        lbStatus.ForeColor = Constant.StatusColor.Information;
    }

    private void SetErrorStatus(string t)
    {
        lbStatus.Text = t;
        lbStatus.ForeColor = Constant.StatusColor.Error;
    }

    private ArrayList GetRepairStatusItemList(double loid)
    {
        ArrayList arrData = new ArrayList();
        RepairItemData RData;
        for (int i = 0; i < this.grvItem.Rows.Count; ++i)
        {
            GridViewRow gRow = this.grvItem.Rows[i];
            RData = new RepairItemData();
            RData.DESCRIPTION = gRow.Cells[3].Text;
            RData.LOID = Convert.ToDouble("0" + gRow.Cells[0].Text);
            RData.REPAIRDATE = Convert.ToDateTime(gRow.Cells[2].Text);
            RData.STOCKOUTITEM = loid;
            arrData.Add(RData);
        }
        return arrData;
    }

    private RepairRequestData GetData()
    {
        RepairRequestData rqData = new RepairRequestData();
        rqData.LOID = Convert.ToDouble("0" + this.txtLOID.Text);
        rqData.CODE = this.txtCode.Text;
        rqData.STOCKOUTDATE = DateTime.Now;
        rqData.STATUS = this.txtStatus.Text;
        rqData.STATUSNAME = this.txtStatusName.Text;
        rqData.WAREHOUSE = this.cmbWarehouse.SelectedIndex;
        rqData.DIVISION = this.cmbDev.SelectedIndex;
        rqData.SIUNIT = Convert.ToDouble("0" + this.txtUnit.Text);
        rqData.REMARKS = this.txtDetail.Text;
        rqData.REPAIRBY = this.txtRepairBy.Text;
        rqData.REPAIRREMARKS = this.txtRemarks.Text;
        //rqData.ArrRepairItem = GetRepairStatusItemList(Convert.ToDouble(this.txtStockoutItemLoid.Text));
        rqData.FLOOR = Convert.ToDouble("0" + this.txtFloor.Text);
        rqData.SIQTY = Convert.ToDouble("0" + this.txtNo.Text);
        rqData.MATERIAL = Convert.ToDouble("0" + this.txtMaterialLoid.Text);
        rqData.SIBRAND = txtType.Text;
        rqData.SILOTNO = txtLotNo.Text;
        RepairItem ItemObj = new RepairItem();
        rqData.ITEM = ItemObj.GetItemList();
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

        if (this.rdbRepairY.Checked)
        {
            rqData.REPAIRSTATUS = "Y";
        }
        else if (this.rdbRepairN.Checked)
        {
            rqData.REPAIRSTATUS = "N";
        }
        else
            rqData.REPAIRSTATUS = "Z";

        RepairrequestItem item = new RepairrequestItem();

        return rqData;
    }
    private void SetRepair(string loid)
    {
        //DataTable dt = FlowObj.GetProductPackage(this.txtStockoutItemLoid.Text);
        //if (dt.Rows.Count > 0)
        //{
            
        //}
    }
    private void SetData(RepairRequestData rqData)
    {
        //bool pageAuthorized = true;
        this.txtLOID.Text = Request["loid"] == null ? "0" : Request["loid"];
        this.txtCode.Text = rqData.CODE;
        this.cmbWarehouse.SelectedIndex = this.cmbWarehouse.Items.IndexOf(this.cmbWarehouse.Items.FindByValue(rqData.WAREHOUSE.ToString()));
        this.cmbDev.SelectedIndex = this.cmbDev.Items.IndexOf(this.cmbDev.Items.FindByValue(rqData.DIVISION.ToString()));
        this.ctlSentDate.DateValue = rqData.STOCKOUTDATE;
        this.txtStatus.Text = rqData.STATUS;
        this.txtStockoutItemLoid.Text = rqData.SILOID.ToString();
        if (this.txtStockoutItemLoid.Text != "")
            SetRepair(this.txtStockoutItemLoid.Text);
        if (this.txtStatus.Text == "WA") this.txtStatusName.Text = "ทำรายการ";
        else if (this.txtStatus.Text == "SE") this.txtStatusName.Text = "รอส่งซ่อม";
        else if (this.txtStatus.Text == "AP") this.txtStatusName.Text = "ส่งซ่อมแล้ว";
        else if (this.txtStatus.Text == "NP") this.txtStatusName.Text = "ไม่อนุมัติ";
        else if (this.txtStatus.Text == "FN") this.txtStatusName.Text = "เสร็จสิ้น";
        else if (this.txtStatus.Text == "VO") this.txtStatusName.Text = "ยกเลิก";

        if (this.txtStatus.Text != "WA")
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
        this.txtNo.Text = rqData.SIQTY.ToString();
        this.txtRemarks.Text = rqData.REPAIRREMARKS;
        this.txtType.Text = rqData.SIBRAND;
        if (rqData.REPAIRSTATUS == "Y")
        {
            this.rdbRepairY.Checked = true;
            this.rdbRepairN.Checked = false;
        }
        else if (rqData.REPAIRSTATUS == "N")
        {
            this.rdbRepairY.Checked = false;
            this.rdbRepairN.Checked = true;
        }
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

        if (rqData.STATUS == "AP")
        {
            this.tbSave.Visible = false;
            this.tbApprove.Visible = false;
            this.tbReceive.Visible = true;
            this.tbCancel.Visible = false;
            this.rdbRepairN.Enabled = true;
            this.rdbRepairY.Enabled = true;
            this.txtRemarks.Enabled = true;
        }
        else if (rqData.STATUS == "FN")
        {
            this.tbSave.Visible = false;
            this.tbApprove.Visible = false;
            this.tbReceive.Visible = false;
            this.tbCancel.Visible = false;
            this.rdbRepairN.Enabled = false;
            this.rdbRepairY.Enabled = false;
            this.txtRemarks.Enabled = false;
        }
        else if (rqData.STATUS == "SE")
        {
            this.tbSave.Visible = true;
            this.tbReceive.Visible = false;
            this.tbCancel.Visible = true;
            this.rdbRepairN.Enabled = false;
            this.rdbRepairY.Enabled = false;
            this.txtRemarks.Enabled = false;
        }

        RepairItem item = new RepairItem();
        item.ClearSession();
        this.grvItem.DataBind();
        SetGrvItem();
        this.tbPrint.ClientClick = Appz.OpenReportScript(Constant.Reports.RepRepairRequest, rqData.LOID, true);
    }

    #endregion

    #region Working Method


    private bool doGetDetail(string LOID)
    {
        RepairFlow fFlow = new RepairFlow();
        RepairRequestData rData = fFlow.GetDetails(Convert.ToDouble(LOID));
        
        bool ret = true;
        SetData(rData);
        RepairrequestItem fsItem = new RepairrequestItem();

        return ret;
    }
    private void SetStatus(string t, bool isError)
    {
        this.lbStatus.Text = t;
        this.lbStatus.ForeColor = (isError ? Constant.StatusColor.Error : Constant.StatusColor.Information);
    }
    private void RepairStatus(string t)
    {
        lbStatus.Text = t;
        lbStatus.ForeColor = Constant.StatusColor.Information;
    }
    private RepairRequestData GetDataStatus()
    {
        RepairRequestData rqData = new RepairRequestData();
        rqData.LOID = Convert.ToDouble("0" + this.txtLOID.Text);
        rqData.CODE = this.txtCode.Text;
        rqData.STOCKOUTDATE = DateTime.Now;
        //rqData.STATUS = "SE";
        if (this.txtStatus.Text == "WA") this.txtStatusName.Text = "ทำรายการ";
        else if (this.txtStatus.Text == "SE") this.txtStatusName.Text = "รอส่งซ่อม";
        else if (this.txtStatus.Text == "AP") this.txtStatusName.Text = "ส่งซ่อมแล้ว";
        else if (this.txtStatus.Text == "NP") this.txtStatusName.Text = "ไม่อนุมัติ";
        else if (this.txtStatus.Text == "VO") this.txtStatusName.Text = "ยกเลิก";
        rqData.WAREHOUSE = this.cmbWarehouse.SelectedIndex;
        rqData.DIVISION = this.cmbDev.SelectedIndex;
        rqData.SIUNIT = Convert.ToDouble("0" + this.txtUnit.Text);
        rqData.REMARKS = this.txtDetail.Text;
        rqData.REPAIRBY = this.txtRepairBy.Text;
        rqData.FLOOR = Convert.ToDouble("0" + this.txtFloor.Text);
        rqData.SIQTY = Convert.ToDouble("0" + this.txtNo.Text);
        rqData.MATERIAL = Convert.ToDouble("0" + this.txtMaterialLoid.Text);
        rqData.SILOTNO = txtLotNo.Text;
        rqData.SIBRAND = txtType.Text;
        rqData.REPAIRREMARKS = this.txtRemarks.Text;
        if(rdbRepairY.Checked)
        {
            rqData.REPAIRSTATUS = "Y";
        }
        else if (rdbRepairN.Checked)
        {
            rqData.REPAIRSTATUS = "N";
        }
        else
            rqData.REPAIRSTATUS = "Z";

        RepairItem ItemObj = new RepairItem();
        rqData.ITEM = ItemObj.GetItemList();
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
    private bool doSave(string status, bool sendOrg)
    {
        RepairFlow ftFlow = new RepairFlow();
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
    private bool doSave()
    {
        RepairRequestData RepairRequestDetail = GetData();
        string error = VerifyData(RepairRequestDetail);
        if (error != "")
        {
            SetErrorStatus(error);
            return false;
        }

        RepairFlow ftFlow = new RepairFlow();
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
        bool check = true;
        if (fData.STATUS == "FN" & fData.REPAIRSTATUS == "Z")
            ret = string.Format(DataResources.MSGEI002, "ผลการซ่อม");
        //else if (fData.CAPACITY == 0)
        //    ret = string.Format(DataResources.MSGEI001, "ปริมาณ");
        //else if (fData.ENERGYRATE == 0 || fData.CAPACITYRATE == 0)
        //    ret = string.Format(DataResources.MSGEI001, "อัตราส่วน");
        //else if (fData.FormulaFeedItem.Count == 0 && this.txtCurentTab.Text == "0")
        //    ret = string.Format(DataResources.MSGEI001, "วัตถุดิบในสูตรอาหาร");

        if (ret == "")
        {
            //foreach (GridViewRow row in gvFormulaFeedItem.Rows)
            //{
            //    TextBox txt = (TextBox)row.Cells[5].FindControl("txtQty");
            //    if (txt.Text == "" || Convert.ToDouble(txt.Text) == 0)
            //    {
            //        check = false;
            //        break;
            //    }
            //}
            if (!check)
                ret = string.Format("จำนวนในรายการวัตถุดิบต้องมากกว่า 0");
        }

        return ret;
    }

    #endregion
    protected void rdbRepairY_CheckedChanged(object sender, EventArgs e)
    {
        if (rdbRepairY.Checked == true)
        {
            rdbRepairN.Checked = false;
        }
    }
    protected void rdbRepairN_CheckedChanged(object sender, EventArgs e)
    {
        if (rdbRepairN.Checked == true)
        {
            rdbRepairY.Checked = false;
        }
    }
}
