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
using SHND.Data.Plan;
using SHND.Data.Tables;
using SHND.Data.Views;
using SHND.Flow.Plan;
using SHND.Global;

/// <summary>
/// PlanOrderTools Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Teang
/// Create Date: 16 Feb 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้าการทำรายการข้อมูล PlanOrderTools
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
public partial class App_Plan_Transaction_PlanOrderTools : System.Web.UI.Page
{
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        ControlUtil.SetYearTextbox(this.txtBudgetYear);
        ControlUtil.SetMinusIntTextBox(this.txtAdjPercent);
        this.tbAddMaterial.ClientClick = "if (document.getElementById('" + this.cmbMaterialClass.ClientID + "').value == '0') { alert('" + string.Format(DataResources.MSGEI002, "หมวดวัสดุ") + "'); return false; }";
        this.imbCalculate.OnClientClick = "return (parseFloat(document.getElementById('" + this.txtAdjPercent.ClientID + "').value=='' ? '0' : document.getElementById('" + this.txtAdjPercent.ClientID + "').value) != 0);";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            doGetDetail((Request["loid"] == null ? "0" : Request["loid"]));
        }
    }

    protected void ctlMaterialUnitPopup_SelectedIndexChanged(object sender, EventArgs e, ArrayList arrData)
    {
        PlanToolsDetailItem fsItem = new PlanToolsDetailItem();
        if (fsItem.InsertToolsItem(Convert.ToDouble("0" + this.txtLOID.Text), arrData))
        {
            this.gvMaterial.DataBind();
            if (this.txtStatus.Text != "WA" && arrData.Count > 0)
            {
                this.tbSendOrg.Visible = true;
                this.tbConfirm.Visible = false;
                this.lblAdjust.Visible = this.tbConfirm.Visible;
                this.txtAdjPercent.Visible = this.tbConfirm.Visible;
                this.imbCalculate.Visible = this.tbConfirm.Visible;
            }
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
        Response.Redirect(Constant.HomeFolder + "App_Plan/Transaction/PlanOrderToolsSearch.aspx");
    }
    protected void tbSendOrgClick(object sender, EventArgs e)
    {
        this.txtTotalAdjust.Text = "";
        doSave("CO", true);
    }
    protected void tbConfirmClick(object sender, EventArgs e)
    {
        doSave("CF", false);
    }
    protected void tbOrgApproveClick(object sender, EventArgs e)
    {
        doUpdateStatus("SA");
    }
    protected void tbOrgNotApproveClick(object sender, EventArgs e)
    {
        doUpdateStatus("SN");
    }
    protected void tbDivApproveClick(object sender, EventArgs e)
    {
        doUpdateStatus("DA");
    }
    protected void tbDivNotApproveClick(object sender, EventArgs e)
    {
        doUpdateStatus("DN");
    }
    #endregion

    #region MaterialItem Toolbar
    protected void tbAddMaterialClick(object sender, EventArgs e)
    {
        AddToolsItem();
    }
    protected void tbDeleteMaterialClick(object sender, EventArgs e)
    {
        DeleteToolsItem();
    }
    #endregion

    protected void cmbMaterialClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        PlanToolsDetailItem item = new PlanToolsDetailItem();
        item.RemoveMaterial();
        this.gvMaterial.DataBind();
    }

    protected void tbSaveSpecClick(object sender, EventArgs e)
    {
        int rowIndex = Convert.ToInt32(this.txtRowIndex.Text);
        this.gvMaterial.Rows[rowIndex].Cells[12].Text = this.txtSpec.Text.Trim();
    }

    protected void lnkCode_Click(object sender, EventArgs e)
    {
        int rowIndex = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;
        SetSpecData(rowIndex);
    }

    protected void lnkDetail_Click(object sender, EventArgs e)
    {
        int rowIndex = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;
        SetDetailData(rowIndex);
    }

    protected void imbCalculate_Click(object sender, ImageClickEventArgs e)
    {
        AdjustQty();
    }

    protected void imbReturn_Click(object sender, ImageClickEventArgs e)
    {
        int rowIndex = ((GridViewRow)((ImageButton)sender).Parent.Parent).RowIndex;
        ReturnMaterialDivision(rowIndex);
    }

    protected void tbBackDetailClick(object sender, EventArgs e)
    {
        if (this.txtIsUpdated.Text == "1")
        {
            PlanToolsDetailItem item = new PlanToolsDetailItem();
            double adjQty = item.GetTotalAdjQty(Convert.ToDouble("0" + this.txtLOID.Text), Convert.ToDouble("0" + this.txtMaterialID.Text));
            int rowIndex = Convert.ToInt16("0" + this.txtRowIndex.Text);
            this.gvMaterial.Rows[rowIndex].Cells[8].Text = adjQty.ToString("#,##0.00");
            this.gvMaterial.Rows[rowIndex].Cells[9].Text = (adjQty * Convert.ToDouble("0" + ((TextBox)this.gvMaterial.Rows[rowIndex].Cells[6].FindControl("txtPrice")).Text)).ToString("#,##0.00");
        }
    }

    #endregion

    #region GridView Event Handler

    protected void gvDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        this.ctlDetailPopup.Show();
    }

    protected void gvDetail_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        e.ExceptionHandled = (e.Exception != null);
        if (e.ExceptionHandled)
        {
            e.KeepInEditMode = true;
        }
        else
            this.txtIsUpdated.Text = "1";
    }

    protected void gvDetail_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        e.NewValues["ADJQTY"] = Convert.ToDouble("0" + ((TextBox)this.gvDetail.Rows[e.RowIndex].Cells[6].FindControl("txtAdjQty")).Text);
        e.NewValues["planOrderID"] = Convert.ToDouble("0" + this.txtLOID.Text);
    }

    #endregion

    #region Misc. Methods

    private ArrayList GetCheckedMaterialItem()
    {
        ArrayList arrChk = new ArrayList();
        for (int i = 0; i < gvMaterial.Rows.Count; i++)
        {
            if (i > -1 && gvMaterial.Rows[i].Cells[1].FindControl("chkSelect") != null)
            {
                GridViewRow gRow = gvMaterial.Rows[i];
                if (((CheckBox)gRow.Cells[1].FindControl("chkSelect")).Checked)
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

    private void ClearSpec()
    {
        this.txtRowIndex.Text = "";
        this.lblMaterialName.Text = "";
        this.txtSpec.Text = "";
    }

    private void ClearDetail()
    {
        this.txtIsUpdated.Text = "";
        this.txtRowIndex.Text = "";
        this.txtMaterialID.Text = "";
        this.txtSpecView.Text = "";
        this.lblMaterialNameDetail.Text = "";
    }

    private void SetSpecData(int rowIndex)
    {
        ClearSpec();

        GridViewRow gRow = this.gvMaterial.Rows[rowIndex];
        this.txtRowIndex.Text = rowIndex.ToString();
        this.lblMaterialName.Text = gRow.Cells[4].Text + " (" + gRow.Cells[5].Text + ")";
        this.txtSpec.Text = gRow.Cells[12].Text;
        this.ctlSpecPopup.Show();
    }

    private void SetDetailData(int rowIndex)
    {
        ClearDetail();
        GridViewRow gRow = this.gvMaterial.Rows[rowIndex];
        this.txtRowIndex.Text = rowIndex.ToString();
        this.txtMaterialID.Text = gRow.Cells[0].Text;
        this.lblMaterialNameDetail.Text = gRow.Cells[4].Text + " (" + gRow.Cells[5].Text + ")";
        this.txtSpecView.Text = gRow.Cells[12].Text;
        this.gvDetail.DataBind();
        this.ctlDetailPopup.Show();
    }

    private ArrayList GetToolsItemList()
    {
        ArrayList arrData = new ArrayList();
        PlanToolsItemData pData;
        for (int i = 0; i < this.gvMaterial.Rows.Count; ++i)
        {
            GridViewRow gRow = this.gvMaterial.Rows[i];
            pData = new PlanToolsItemData();
            pData.ISVAT = ((CheckBox)gRow.Cells[7].FindControl("chkVat")).Checked;
            pData.MATERIALMASTER = Convert.ToDouble(gRow.Cells[0].Text);
            pData.PLANQTY = Convert.ToDouble("0" + gRow.Cells[8].Text);
            pData.PRICE = Convert.ToDouble("0" + ((TextBox)gRow.Cells[6].FindControl("txtPrice")).Text);
            pData.SPEC = gRow.Cells[12].Text;
            pData.UNIT = Convert.ToDouble("0" + gRow.Cells[13].Text);
            arrData.Add(pData);
        }
        return arrData;
    }

    private ArrayList GetToolsDivisionList()
    {
        PlanToolsDetailItem item = new PlanToolsDetailItem();
        return item.GetToolsDivisionData();
    }

    private PlanToolsDetailData GetData()
    {
        PlanToolsDetailData pData = new PlanToolsDetailData();
        pData.BUDGETYEAR = Convert.ToDouble("0" + this.txtBudgetYear.Text);
        pData.CODE = this.txtCode.Text.Trim();
        pData.ENDDATE = this.ctlEndDate.DateValue;
        pData.ISPLANFOOD = false;
        pData.LOID = Convert.ToDouble("0" + this.txtLOID.Text);
        pData.MATERIALCLASS = Convert.ToDouble(this.cmbMaterialClass.SelectedItem.Value);
        pData.NAME = this.txtName.Text.Trim();
        if (this.ctlEndDate.DateValue.Year != 1 && this.ctlStartDate.DateValue.Year != 1)
        {
            if (ctlStartDate.DateValue.CompareTo(ctlEndDate.DateValue) < 0) pData.PERIODTIME = (this.ctlEndDate.DateValue.Month - this.ctlStartDate.DateValue.Month) + (12 * (this.ctlEndDate.DateValue.Year - this.ctlStartDate.DateValue.Year)) + 1;
        }
        pData.PHASE = "";
        pData.QTCODE = this.txtQtCode.Text.Trim();
        pData.REFPRSAP = this.txtRefPRSap.Text.Trim();
        pData.STARTDATE = this.ctlStartDate.DateValue;
        pData.STATUS = this.txtStatus.Text;
        pData.AdjPercent = Convert.ToDouble("0" + this.txtTotalAdjust.Text);
        pData.PlanToolsItem = GetToolsItemList();
        pData.PlanToolsDivision = GetToolsDivisionList();

        return pData;
    }

    private void ViewData(bool isView)
    {
        this.txtBudgetYear.CssClass = (isView ? "zTextboxR-View" : "zTextboxR");
        this.txtBudgetYear.ReadOnly = isView;
        this.txtName.CssClass = (isView ? "zTextbox-View" : "zTextbox");
        this.txtName.ReadOnly = isView;
        this.cmbMaterialClass.Enabled = !isView;
        this.ctlEndDate.Enabled = !isView;
        this.ctlStartDate.Enabled = !isView;
        this.txtSpec.CssClass = (isView ? "zTextbox-View" : "zTextbox");
        this.txtSpec.ReadOnly = isView;
    }

    private void SetData(PlanToolsDetailData pData)
    {
        bool pageAuthorized = true;
        this.txtBudgetYear.Text = pData.BUDGETYEAR.ToString();
        this.txtCode.Text = pData.CODE;
        this.txtLOID.Text = pData.LOID.ToString();
        if (pData.STATUS == "WA")
            Appz.BuildCombo(this.cmbMaterialClass, "MATERIALCLASS", "NAME", "LOID", "MASTERTYPE <> 'FO' AND ACTIVE = '1'", "NAME", "เลือก", "0", false);
        else
            Appz.BuildCombo(this.cmbMaterialClass, "MATERIALCLASS", "NAME", "LOID", "ACTIVE = '1'", "NAME", "เลือก", "0", false);

        this.cmbMaterialClass.SelectedIndex = this.cmbMaterialClass.Items.IndexOf(this.cmbMaterialClass.Items.FindByValue(pData.MATERIALCLASS.ToString()));
        this.txtName.Text = pData.NAME;
        this.txtQtCode.Text = pData.QTCODE;
        this.txtRefPRSap.Text = pData.REFPRSAP;
        this.txtStatus.Text = pData.STATUS;
        this.txtStatusName.Text = pData.STATUSNAME;
        this.ctlEndDate.DateValue = pData.ENDDATE;
        this.ctlStartDate.DateValue = pData.STARTDATE;
        this.tbPrintPlan.Visible = (pData.LOID != 0);
        this.tbPrintPR.Visible = (pData.LOID != 0);
        this.txtTotalAdjust.Text = "";
        this.tbPrintPR.ClientClick = Appz.OpenReportScript(Constant.Reports.QuotationToolsReport, pData.LOID, false);
        this.tbPrintPlan.ClientClick = Appz.OpenReportScript(Constant.Reports.PlanOrderToolsReport, pData.LOID, false);

        if (!pageAuthorized || pData.STATUS == "FN")
        {
            ViewData(true);

            this.txtQtCode.CssClass = "zTextbox-View";
            this.txtQtCode.ReadOnly = true;
            this.txtRefPRSap.CssClass = "zTextbox-View";
            this.txtRefPRSap.ReadOnly = true;
            tbSaveSpec.Visible = false;
            tbAddMaterial.Visible = false;
            tbDeleteMaterial.Visible = false;
            this.lblAdjust.Visible = false;
            this.txtAdjPercent.Visible = false;
            this.imbCalculate.Visible = false;
            this.tbSave.Visible = false;
            this.tbCancel.Visible = false;
            this.tbConfirm.Visible = false;
            this.tbDivApprove.Visible = false;
            this.tbDivNotApprove.Visible = false;
            this.tbOrgApprove.Visible = false;
            this.tbOrgNotApprove.Visible = false;
            this.tbSendOrg.Visible = false;
            this.gvMaterial.Columns[1].Visible = false;
            this.gvDetail.Columns[1].Visible = false;
        }
        else
        {
            this.tbSave.Visible = true;
            this.tbCancel.Visible = true;
            this.txtQtCode.CssClass = "zTextbox";
            this.txtQtCode.ReadOnly = false;
            this.txtRefPRSap.CssClass = "zTextbox";
            this.txtRefPRSap.ReadOnly = false;

            if (pData.STATUS == "CF" || pData.STATUS == "SA" || pData.STATUS == "DA")
            {
                ViewData(true);
                this.tbSendOrg.Visible = false;
                this.tbConfirm.Visible = false;
                this.tbOrgApprove.Visible = (pData.STATUS == "CF");
                this.tbOrgNotApprove.Visible = (pData.STATUS == "CF");
                this.tbDivApprove.Visible = (pData.STATUS == "SA");
                this.tbDivNotApprove.Visible = (pData.STATUS == "SA");

                this.ctlEndDate.Enabled = false;
                this.ctlStartDate.Enabled = false;
                this.lblAdjust.Visible = false;
                this.txtAdjPercent.Visible = false;
                this.imbCalculate.Visible = false;
                this.tbAddMaterial.Visible = false;
                this.tbDeleteMaterial.Visible = false;
                this.gvMaterial.Columns[1].Visible = false;
                this.tbSaveSpec.Visible = false;
                this.gvDetail.Columns[1].Visible = false;
            }
            else // WA, CO, SN, DN
            {
                ViewData(false);

                this.tbSendOrg.Visible = (pData.STATUS == "WA");
                this.tbConfirm.Visible = (pData.STATUS != "WA");
                this.tbOrgApprove.Visible = false;
                this.tbOrgNotApprove.Visible = false;
                this.tbDivApprove.Visible = false;
                this.tbDivNotApprove.Visible = false;

                this.cmbMaterialClass.Enabled = (pData.STATUS == "WA");
                this.ctlEndDate.Enabled = (pData.STATUS == "WA");
                this.ctlStartDate.Enabled = (pData.STATUS == "WA");
                this.lblAdjust.Visible = (pData.STATUS != "WA");
                this.txtAdjPercent.Visible = (pData.STATUS != "WA");
                this.imbCalculate.Visible = (pData.STATUS != "WA");
                this.tbAddMaterial.Visible = true;
                this.tbDeleteMaterial.Visible = true;
                this.gvMaterial.Columns[1].Visible = true;
                this.gvMaterial.Columns[10].Visible = (pData.STATUS != "WA");
                this.tbSaveSpec.Visible = true;
                this.gvDetail.Columns[1].Visible = true;
            }
        }

        PlanToolsDetailItem item = new PlanToolsDetailItem();
        item.ClearAllSession();
        this.gvMaterial.DataBind();
    }

    #endregion

    #region Working Method

    private void UpdateToolsItem()
    {
        PlanToolsDetailItem item = new PlanToolsDetailItem();
        item.UpdateToolsItem(Convert.ToDouble("0" + this.txtLOID.Text), GetToolsItemList());
    }

    private void AddToolsItem()
    {
        UpdateToolsItem();
        string materialList = "";
        for (int i = 0; i < this.gvMaterial.Rows.Count; ++i)
        {
            materialList += (materialList == "" ? "" : ",") + this.gvMaterial.Rows[i].Cells[0].Text;
        }
        ctlMaterialUnitPopup.Show("2", 0, Convert.ToDouble(this.cmbMaterialClass.SelectedItem.Value), materialList, "");
    }

    private void DeleteToolsItem()
    {
        bool hasNewRow = false;
        UpdateToolsItem();
        PlanToolsDetailItem item = new PlanToolsDetailItem();
        if (item.DeleteToolsItem(GetCheckedMaterialItem()))
        {
            this.gvMaterial.DataBind();
            if (this.txtStatus.Text != "WA")
            {
                for (int i = 0; i < this.gvMaterial.Rows.Count; ++i)
                {
                    if (this.gvMaterial.Rows[i].Cells[14].Text == "WA")
                    {
                        hasNewRow = true;
                        break;
                    }
                }
            }
            if (!hasNewRow && this.txtStatus.Text != "WA")
            {
                this.tbSendOrg.Visible = false;
                this.tbConfirm.Visible = true;
                this.lblAdjust.Visible = this.tbConfirm.Visible;
                this.txtAdjPercent.Visible = this.tbConfirm.Visible;
                this.imbCalculate.Visible = this.tbConfirm.Visible;
            }
        }
    }

    private bool AdjustQty()
    {
        bool ret = true;
        double adjPercent = (this.txtAdjPercent.Text == "" ? 0 : Convert.ToDouble(this.txtAdjPercent.Text));
        this.txtTotalAdjust.Text = ((this.txtTotalAdjust.Text == "" ? 0 : Convert.ToDouble(this.txtTotalAdjust.Text)) + adjPercent).ToString();
        PlanToolsDetailItem item = new PlanToolsDetailItem();
        Hashtable ht = item.GetAdjQty(Convert.ToDouble("0" + this.txtLOID.Text), (this.txtTotalAdjust.Text == "" ? 0 : Convert.ToDouble(this.txtTotalAdjust.Text)));
        if (ht.Count > 0)
        {
            for (int i = 0; i < this.gvMaterial.Rows.Count; ++i)
            {
                GridViewRow gRow = this.gvMaterial.Rows[i];
                if (ht[gRow.Cells[0].Text] != null)
                {
                    gRow.Cells[8].Text = Convert.ToDouble(ht[gRow.Cells[0].Text]).ToString(Constant.DoubleFormat);
                    gRow.Cells[9].Text = (Convert.ToDouble("0" + gRow.Cells[8].Text) * Convert.ToDouble("0" + ((TextBox)gRow.Cells[6].FindControl("txtPrice")).Text)).ToString(Constant.DoubleFormat);
                }
            }
        }
        return ret;
    }

    private void ReturnMaterialDivision(int RowIndex)
    {
        PlanToolsDetailItem item = new PlanToolsDetailItem();
        if (item.UpdateToolsDivision(Convert.ToDouble("0" + this.txtLOID.Text), Convert.ToDouble("0" + this.txtMaterialID.Text), Convert.ToDouble("0" + this.gvDetail.Rows[RowIndex].Cells[0].Text), "CO"))
            this.gvDetail.DataBind();
    }

    private bool doGetDetail(string LOID)
    {
        PlanOrderToolsFlow fFlow = new PlanOrderToolsFlow();
        PlanToolsDetailData fData = fFlow.GetDetails(Convert.ToDouble(LOID));

        bool ret = true;
        SetData(fData);
        return ret;
    }

    private bool doUpdateStatus(string status)
    {
        PlanOrderToolsFlow ftFlow = new PlanOrderToolsFlow();
        bool ret = true;
        ret = ftFlow.UpdateStatus(Convert.ToDouble("0" + this.txtLOID.Text), status, this.txtQtCode.Text.Trim(), this.txtRefPRSap.Text.Trim(), Appz.CurrentUser);

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
        return doSave("", false);
    }

    private bool doSave(string status, bool sendOrg)
    {
        PlanOrderToolsFlow ftFlow = new PlanOrderToolsFlow();
        bool ret = true;
        string error = "";

        // verify required field
        PlanToolsDetailData pData = GetData();
        if (status != "") pData.STATUS = status;

        switch (pData.STATUS)
        {
            case "WA":
                goto case "CF";
            case "CO":
                goto case "CF";
            case "CF":
                error = VerifyData(pData);
                if (error != "")
                {
                    SetStatus(error, true);
                    return false;
                }

                if (!ftFlow.CheckUniqueKey(pData.LOID, pData.NAME))
                {
                    SetStatus(string.Format(DataResources.MSGEI015, "ชื่อแผนประมาณการ", pData.NAME), true);
                    return false;
                }
                if (ftFlow.CheckUniqueDate(pData.LOID,pData.MATERIALCLASS,pData.STARTDATE,pData.ENDDATE))
                {
                    SetStatus(string.Format(DataResources.MSGEI015, "ช่วงเวลาที่ใช้", pData.STARTDATE.ToString("dd/MM/yyyy") + " ถึง " + pData.ENDDATE.ToString("dd/MM/yyyy")), true);
                    return false;
                }
                
                goto case "DN";
            case "SN":
                goto case "DN";
            case "DN":
                // data correct go on saving...
                if (pData.LOID != 0)
                    ret = ftFlow.UpdateData(pData, Appz.CurrentUser, sendOrg);
                else
                    ret = ftFlow.InsertData(pData, Appz.CurrentUser, sendOrg);

                break;
            case "SA":
                goto case "DA";
            case "DA":
                ret = ftFlow.UpdateStatus(pData.LOID, pData.STATUS, pData.QTCODE, pData.REFPRSAP, Appz.CurrentUser);
                break;
        }
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

    private string VerifyData(PlanToolsDetailData pData)
    {
        string ret = "";
        if (pData.NAME == "")
            ret = string.Format(DataResources.MSGEI001, "ชื่อแผนประมาณการ");
        else if (pData.BUDGETYEAR == 0)
            ret = string.Format(DataResources.MSGEI001, "ปีงบประมาณ");
        else if (pData.STARTDATE.Year == 1)
            ret = string.Format(DataResources.MSGEI001, "ช่วงเวลาเริ่มต้น");
        else if (pData.ENDDATE.Year == 1)
            ret = string.Format(DataResources.MSGEI001, "ช่วงเวลาสิ้นสุด");
        else if (pData.MATERIALCLASS == 0)
            ret = string.Format(DataResources.MSGEI002, "หมวดวัสดุ");
        else if (pData.STATUS == "CF")
        {
            PlanOrderToolsFlow ftFlow = new PlanOrderToolsFlow();
            DataTable dt = ftFlow.chkConfirmDiv(pData.LOID);
            if (pData.PlanToolsItem.Count == 0)
            {
                ret = string.Format(DataResources.MSGEI002, "วัสดุอุปกรณ์");
            }
            //for (int i = 0; i < dt.Rows.Count; ++i) //แสดงชื่อหน่วยงานที่ยังไม่ส่งข้อมูลมาให้ธุรการ ตรวจสอบตอนกดยืนยัน
            //{
            //    ret = "หน่วยงาน " + dt.Rows[i]["DIVISIONNAME"] + " ยังไม่ส่งข้อมูล";
            //}
        }

        return ret;
    }

    #endregion

}
