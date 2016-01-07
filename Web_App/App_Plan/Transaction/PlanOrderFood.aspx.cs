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
using SHND.Data.Views;
using SHND.Flow.Plan;
using SHND.Flow.Search;
using SHND.Global;

/// <summary>
/// PlanOrderFood Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Teang
/// Create Date: 26 Jan 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้าการทำรายการข้อมูล PlanOrderFood
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
public partial class App_Plan_Transaction_PlanOrderFood : System.Web.UI.Page
{
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        ControlUtil.SetNumberTextbox(this.txtPhase);
        ControlUtil.SetYearTextbox(this.txtBudgetYear);
        ControlUtil.SetMinusIntTextBox(this.txtAdjPercent);
        this.txtCurentTab.Text = this.tabPlanOrder.ActiveTabIndex.ToString();
        this.imbCalculate.OnClientClick = "return (parseFloat(document.getElementById('" + this.txtAdjPercent.ClientID + "').value=='' ? '0' : document.getElementById('" + this.txtAdjPercent.ClientID + "').value) != 0);";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            doGetDetail((Request["loid"] == null ? "0" : Request["loid"]));
        }
    }

    protected void tabPlanOrder_ActiveTabChanged(object sender, EventArgs e)
    {
        if (this.txtStatus.Text != "FN" && this.tbSave.Visible)
        {
            if (!doSave())
                this.tabPlanOrder.ActiveTabIndex = Convert.ToInt32(this.txtCurentTab.Text);
        }
        else
            doGetDetail("0" + this.txtLOID.Text);
    }

    protected void ctlMaterialUnitPopup_SelectedIndexChanged(object sender, EventArgs e, ArrayList arrData)
    {
        PlanFoodDetailItem fsItem = new PlanFoodDetailItem();
        if (fsItem.InsertMaterialItem(Convert.ToDouble("0" + this.txtLOID.Text), arrData))
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

    protected void ctlOfficerPopup_SelectedIndexChanged(object sender, EventArgs e, ArrayList arrData)
    {
        PlanFoodDetailItem fsItem = new PlanFoodDetailItem();
        if (fsItem.InsertOfficer(Convert.ToDouble("0" + this.txtLOID.Text), arrData))
        {
            this.gvOfficer.DataBind();
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
        Response.Redirect(Constant.HomeFolder + "App_Plan/Transaction/PlanOrderFoodSearch.aspx");
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
        AddMaterialItem();
    }
    protected void tbDeleteMaterialClick(object sender, EventArgs e)
    {
        DeleteMaterialItem();
    }
    protected void tbAddMaterialTotClick(object sender, EventArgs e)
    {
        AddMaterialTotItem();
    }
    #endregion

    #region PlanCouncil Toolbar
    protected void tbAddOfficerClick(object sender, EventArgs e)
    {
        AddOfficer();
    }
    protected void tbDeleteOfficerClick(object sender, EventArgs e)
    {
        DeleteOfficer();
    }
    #endregion

    protected void tbSaveSpecClick(object sender, EventArgs e)
    {
        int rowIndex = Convert.ToInt32(this.txtRowIndex.Text);
        this.gvMaterial.Rows[rowIndex].Cells[16].Text = this.txtSpec.Text.Trim();
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
            PlanFoodDetailItem item = new PlanFoodDetailItem();
            double adjQty = item.GetTotalAdjQty(Convert.ToDouble("0" + this.txtLOID.Text), Convert.ToDouble("0" + this.txtMaterialID.Text));
            int rowIndex = Convert.ToInt16("0" + this.txtRowIndex.Text);
            this.gvMaterial.Rows[rowIndex].Cells[11].Text = adjQty.ToString("#,##0.00");
            this.gvMaterial.Rows[rowIndex].Cells[12].Text = (adjQty * Convert.ToDouble("0" + ((TextBox)this.gvMaterial.Rows[rowIndex].Cells[7].FindControl("txtPrice")).Text)).ToString("#,##0.00");
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
            //Appz.ClientAlert(this, e.Exception.Message);
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

    private ArrayList GetCheckedOfficer()
    {
        ArrayList arrChk = new ArrayList();
        for (int i = 0; i < gvOfficer.Rows.Count; i++)
        {
            if (i > -1 && gvOfficer.Rows[i].Cells[1].FindControl("chkSelect") != null)
            {
                GridViewRow gRow = gvOfficer.Rows[i];
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

    private void SetStatusMaterial(string t, bool isError)
    {
        this.lbStatusmaterial.Text = t;
        this.lbStatusmaterial.ForeColor = (isError ? Constant.StatusColor.Error : Constant.StatusColor.Information);
    }
    private void SetStatusOfficer(string t, bool isError)
    {
        this.lbStatusOfficer.Text = t;
        this.lbStatusOfficer.ForeColor = (isError ? Constant.StatusColor.Error : Constant.StatusColor.Information);
    }
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
        this.txtSpec.Text = gRow.Cells[16].Text;
        this.ctlSpecPopup.Show();
    }

    private void SetDetailData(int rowIndex)
    {
        ClearDetail();
        GridViewRow gRow = this.gvMaterial.Rows[rowIndex];
        this.txtRowIndex.Text = rowIndex.ToString();
        this.txtMaterialID.Text = gRow.Cells[0].Text;
        this.lblMaterialNameDetail.Text = gRow.Cells[4].Text + " (" + gRow.Cells[5].Text + ")";
        this.txtSpecView.Text = gRow.Cells[16].Text;
        this.gvDetail.DataBind();
        this.ctlDetailPopup.Show();
    }

    private ArrayList GetMaterialItemList()
    {
        ArrayList arrData = new ArrayList();
        VPlanFoodMaterialData pData;
        for (int i = 0; i < this.gvMaterial.Rows.Count; ++i)
        {
            GridViewRow gRow = this.gvMaterial.Rows[i];
            pData = new VPlanFoodMaterialData();
            pData.CLASSLOID = Convert.ToDouble("0" + gRow.Cells[14].Text);
            pData.ISVAT = (((CheckBox)gRow.Cells[9].FindControl("chkVat")).Checked ? "Y" : "N");
            pData.MATERIALMASTER = Convert.ToDouble(gRow.Cells[0].Text);
            pData.PLANQTY = Convert.ToDouble("0" + gRow.Cells[11].Text);
            pData.PRICE = Convert.ToDouble("0" + ((TextBox)gRow.Cells[7].FindControl("txtPrice")).Text);
            pData.SAPCODE = gRow.Cells[15].Text;
            pData.SPEC = gRow.Cells[16].Text;
            pData.UNIT = Convert.ToDouble("0" + gRow.Cells[17].Text);
            arrData.Add(pData);
        }
        return arrData;
    }

    private ArrayList GetMaterialDivisionList()
    {
        PlanFoodDetailItem item = new PlanFoodDetailItem();
        return item.GetMaterialDivisionData();
    }

    private ArrayList GetPlanCouncilList()
    {
        ArrayList arrData = new ArrayList();
        PlanOrderCouncilData pData;
        for (int i = 0; i < this.gvOfficer.Rows.Count; ++i)
        {
            GridViewRow gRow = this.gvOfficer.Rows[i];
            pData = new PlanOrderCouncilData();
            pData.DIVISION = Convert.ToDouble("0" + gRow.Cells[19].Text);
            pData.M1 = ((CheckBox)gRow.Cells[6].FindControl("chkM1")).Checked;
            pData.M2 = ((CheckBox)gRow.Cells[7].FindControl("chkM2")).Checked;
            pData.M3 = ((CheckBox)gRow.Cells[8].FindControl("chkM3")).Checked;
            pData.M4 = ((CheckBox)gRow.Cells[9].FindControl("chkM4")).Checked;
            pData.M5 = ((CheckBox)gRow.Cells[10].FindControl("chkM5")).Checked;
            pData.M6 = ((CheckBox)gRow.Cells[11].FindControl("chkM6")).Checked;
            pData.M7 = ((CheckBox)gRow.Cells[12].FindControl("chkM7")).Checked;
            pData.M8 = ((CheckBox)gRow.Cells[13].FindControl("chkM8")).Checked;
            pData.M9 = ((CheckBox)gRow.Cells[14].FindControl("chkM9")).Checked;
            pData.M10 = ((CheckBox)gRow.Cells[15].FindControl("chkM10")).Checked;
            pData.M11 = ((CheckBox)gRow.Cells[16].FindControl("chkM11")).Checked;
            pData.M12 = ((CheckBox)gRow.Cells[17].FindControl("chkM12")).Checked;
            pData.OFFICER = Convert.ToDouble("0" + gRow.Cells[18].Text);
            pData.POSITION = ((TextBox)gRow.Cells[5].FindControl("txtPosition")).Text.Trim();
            arrData.Add(pData);
        }
        return arrData;
    }

    private PlanFoodDetailData GetData()
    {
        PlanFoodDetailData pData = new PlanFoodDetailData();
        pData.BUDGETYEAR = Convert.ToDouble("0" + this.txtBudgetYear.Text);
        pData.CODE = this.txtCode.Text.Trim();
        pData.ENDDATE = this.ctlEndDate.DateValue;
        pData.ISPLANFOOD = true;
        pData.LOID = Convert.ToDouble("0" + this.txtLOID.Text);
        pData.MATERIALCLASS = 0;
        pData.NAME = this.txtName.Text.Trim();
        if (this.ctlEndDate.DateValue.Year !=1 && this.ctlStartDate.DateValue.Year != 1)
        {
            if (ctlStartDate.DateValue.CompareTo(ctlEndDate.DateValue) < 0) pData.PERIODTIME = (this.ctlEndDate.DateValue.Month - this.ctlStartDate.DateValue.Month) + (12 * (this.ctlEndDate.DateValue.Year - this.ctlStartDate.DateValue.Year)) + 1;
        }
        pData.PHASE = this.txtPhase.Text;
        pData.QTCODE = this.txtQtCode.Text.Trim();
        pData.REFPRSAP = this.txtRefPRSap.Text.Trim();
        pData.STARTDATE = this.ctlStartDate.DateValue;
        pData.STATUS = this.txtStatus.Text;
        pData.AdjPercent = Convert.ToDouble("0" + this.txtTotalAdjust.Text);
        pData.ArrMaterialMaster = GetMaterialItemList();
        pData.ArrMaterialCouncil = GetPlanCouncilList();
        pData.PlanMaterialDivision = GetMaterialDivisionList();

        return pData;
    }

    private void ViewData(bool isView)
    {
        this.txtBudgetYear.CssClass = (isView ? "zTextboxR-View" : "zTextboxR");
        this.txtBudgetYear.ReadOnly = isView;
        this.txtName.CssClass = (isView ? "zTextbox-View" : "zTextbox");
        this.txtName.ReadOnly = isView;
        this.txtPhase.CssClass = (isView ? "zTextboxR-View" : "zTextboxR");
        this.txtPhase.ReadOnly = isView;
        this.ctlEndDate.Enabled = !isView;
        this.ctlStartDate.Enabled = !isView;
        this.txtSpec.CssClass = (isView ? "zTextbox-View" : "zTextbox");
        this.txtSpec.ReadOnly = isView;
    }

    private void SetData(PlanFoodDetailData pData)
    {
        bool pageAuthorized = true;
        this.txtBudgetYear.Text = pData.BUDGETYEAR.ToString();
        this.txtCode.Text = pData.CODE;
        this.txtLOID.Text = pData.LOID.ToString();
        this.txtName.Text = pData.NAME;
        this.txtPeriodTime.Text = pData.PERIODTIME.ToString(Constant.IntFormat);
        this.txtPhase.Text = pData.PHASE.ToString();
        this.txtQtCode.Text = pData.QTCODE;
        this.txtRefPRSap.Text = pData.REFPRSAP;
        this.txtStatus.Text = pData.STATUS;
        this.txtStatusName.Text = pData.STATUSNAME;
        this.ctlEndDate.DateValue = pData.ENDDATE;
        this.ctlStartDate.DateValue = pData.STARTDATE;
        this.tbPrintPlan.Visible = (pData.LOID != 0);
        this.tbPrintPR.Visible = (pData.LOID != 0);
        this.tbPrintForm.Visible = (pData.LOID != 0);
        this.txtTotalAdjust.Text = "";
        this.tbPrintPR.ClientClick = Appz.OpenReportScript(Constant.Reports.QuotationReport, pData.LOID, false);
        this.tbPrintPlan.ClientClick = Appz.OpenReportScript(Constant.Reports.PlanOrderReport, pData.LOID, false);
        this.tbPrintForm.ClientClick = Appz.OpenReportScript(Constant.Reports.QuotationFormReport, pData.LOID, false);

        if (!pageAuthorized || pData.STATUS == "FN")
        {
            ViewData(true);

            this.txtQtCode.CssClass = "zTextbox-View";
            this.txtQtCode.ReadOnly = true;
            this.txtRefPRSap.CssClass = "zTextbox-View";
            this.txtRefPRSap.ReadOnly = true;
            tbSaveSpec.Visible = false;
            tbAddMaterial.Visible = false;
            tbAddMaterialTot.Visible = false;
            tbDeleteMaterial.Visible = false;
            tbAddOfficer.Visible = false;
            tbDeleteOfficer.Visible = false;
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
                this.tbOrgNotApprove.Visible = (pData.STATUS =="CF");
                this.tbDivApprove.Visible = (pData.STATUS == "SA");
                this.tbDivNotApprove.Visible = (pData.STATUS == "SA");

                this.ctlEndDate.Enabled = false;
                this.ctlStartDate.Enabled = false;
                this.lblAdjust.Visible = false;
                this.txtAdjPercent.Visible = false;
                this.imbCalculate.Visible = false;
                this.tbAddMaterial.Visible = false;
                this.tbAddMaterialTot.Visible = false;
                this.tbDeleteMaterial.Visible = false;
                this.gvMaterial.Columns[1].Visible = false;
                this.tbSaveSpec.Visible = false;
                this.gvDetail.Columns[1].Visible = false;
                this.tbAddOfficer.Visible = false;
                this.tbDeleteOfficer.Visible = false;
                this.gvOfficer.Columns[1].Visible = false;
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

                this.ctlEndDate.Enabled = (pData.STATUS == "WA");
                this.ctlStartDate.Enabled = (pData.STATUS == "WA");
                this.lblAdjust.Visible = (pData.STATUS != "WA");
                this.txtAdjPercent.Visible = (pData.STATUS != "WA");
                this.imbCalculate.Visible = (pData.STATUS != "WA");
                this.tbAddMaterial.Visible = true;
                this.tbAddMaterialTot.Visible = true;
                this.tbDeleteMaterial.Visible = true;
                this.gvMaterial.Columns[1].Visible = true;
                this.tbSaveSpec.Visible = true;
                this.gvDetail.Columns[1].Visible = true;
                this.tbAddOfficer.Visible = true;
                this.tbDeleteOfficer.Visible = true;
                this.gvOfficer.Columns[1].Visible = true;
            }
        }

        PlanFoodDetailItem item = new PlanFoodDetailItem();
        item.ClearAllSession();
        this.gvMaterial.DataBind();
        this.gvOfficer.DataBind();
    }

    #endregion

    #region Working Method

    private void UpdateMaterialItem()
    {
        PlanFoodDetailItem item = new PlanFoodDetailItem();
        item.UpdateMaterialItem(Convert.ToDouble("0" + this.txtLOID.Text), GetMaterialItemList());
    }

    private void AddMaterialItem()
    {
        UpdateMaterialItem();
        string materialList = "";
        for (int i = 0; i < this.gvMaterial.Rows.Count; ++i)
        {
            materialList += (materialList == "" ? "" : ",") + this.gvMaterial.Rows[i].Cells[0].Text;
        }
        ctlMaterialUnitPopup.Show("1", 0, 0, materialList, "");
    }

    private void AddMaterialTotItem()
    {
        UpdateMaterialItem();
        string materialList = "";
        for (int i = 0; i < this.gvMaterial.Rows.Count; ++i)
        {
            materialList += (materialList == "" ? "" : ",") + this.gvMaterial.Rows[i].Cells[0].Text;
        }
        ArrayList arrChk = new ArrayList();
        SearchFlow fFlow = new SearchFlow();
        DataTable dt = fFlow.GetMaterialUnitList(0, 0, "", "Y", materialList, "", " MASTERTYPE='FO' AND STOCKINTYPE='1' ", " CLASSNAME, GROUPNAME, MATERIALNAME ");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            DataRow dRow = dt.Rows[i];
            VMaterialMasterUnitData VMaterialList = new VMaterialMasterUnitData();
            VMaterialList.CLASSLOID = Convert.ToDouble("0" + dRow["CLASSLOID"].ToString());
            VMaterialList.CLASSNAME = dRow["CLASSNAME"].ToString();
            VMaterialList.COST = Convert.ToDouble("0" + dRow["COST"].ToString());
            VMaterialList.GROUPLOID = Convert.ToDouble("0" + dRow["GROUPLOID"].ToString());
            VMaterialList.GROUPNAME = dRow["GROUPNAME"].ToString();
            VMaterialList.MATERIALCODE = dRow["MATERIALCODE"].ToString();
            VMaterialList.MATERIALMASTER = Convert.ToDouble("0" + dRow["MATERIALMASTER"].ToString());
            VMaterialList.MATERIALNAME = dRow["MATERIALNAME"].ToString();
            VMaterialList.SAPCODE = dRow["SAPCODE"].ToString();
            VMaterialList.SPEC = dRow["SPEC"].ToString();
            VMaterialList.UNIT = Convert.ToDouble("0" + dRow["UNIT"].ToString());
            VMaterialList.UNITNAME = dRow["UNITNAME"].ToString();
            
            arrChk.Add(VMaterialList);
         }
         PlanFoodDetailItem item = new PlanFoodDetailItem();
         item.InsertMaterialItem(Convert.ToDouble("0" + this.txtLOID.Text), arrChk);
         gvMaterial.DataBind();
    }

    private void DeleteMaterialItem()
    {
        bool hasNewRow = false;
        UpdateMaterialItem();
        PlanFoodDetailItem item = new PlanFoodDetailItem();
        if (item.DeleteMaterialItem(GetCheckedMaterialItem()))
        {
            this.gvMaterial.DataBind();
            if (this.txtStatus.Text != "WA")
            {
                for (int i = 0; i < this.gvMaterial.Rows.Count; ++i)
                {
                    if (this.gvMaterial.Rows[i].Cells[18].Text == "WA")
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

    private void UpdateOfficer()
    {
        PlanFoodDetailItem item = new PlanFoodDetailItem();
        item.UpdateOfficer(Convert.ToDouble("0" + this.txtLOID.Text), GetPlanCouncilList());
    }

    private void AddOfficer()
    {
        UpdateOfficer();
        string officerList = "";
        for (int i = 0; i < this.gvOfficer.Rows.Count; ++i)
        {
            officerList += (officerList == "" ? "" : ",") + this.gvOfficer.Rows[i].Cells[0].Text;
        }
        ctlOfficerPopup.Show(officerList);
    }

    private void DeleteOfficer()
    {
        UpdateOfficer();
        PlanFoodDetailItem item = new PlanFoodDetailItem();
        if (item.DeleteOfficer(GetCheckedOfficer()))
        {
            this.gvOfficer.DataBind();
        }
    }

    private bool AdjustQty()
    {
        bool ret = true;
        double adjPercent = (this.txtAdjPercent.Text == "" ? 0: Convert.ToDouble(this.txtAdjPercent.Text));
        this.txtTotalAdjust.Text = ((this.txtTotalAdjust.Text == "" ? 0 : Convert.ToDouble(this.txtTotalAdjust.Text)) + adjPercent).ToString();
        PlanFoodDetailItem item = new PlanFoodDetailItem();
        Hashtable ht = item.GetAdjQty(Convert.ToDouble("0" + this.txtLOID.Text), (this.txtTotalAdjust.Text == "" ? 0 : Convert.ToDouble(this.txtTotalAdjust.Text)));
        if (ht.Count > 0)
        {
            for (int i = 0; i < this.gvMaterial.Rows.Count; ++i)
            {
                GridViewRow gRow = this.gvMaterial.Rows[i];
                if (ht[gRow.Cells[0].Text] != null)
                {
                    gRow.Cells[11].Text = Convert.ToDouble(ht[gRow.Cells[0].Text]).ToString(Constant.DoubleFormat);
                    //gRow.Cells[11].Text = (Convert.ToDouble("0" + gRow.Cells[11].Text) + (Convert.ToDouble("0" + gRow.Cells[11].Text) * adjPercent / 100)).ToString(Constant.DoubleFormat);
                    gRow.Cells[12].Text = (Convert.ToDouble("0" + gRow.Cells[11].Text) * Convert.ToDouble("0" + ((TextBox)gRow.Cells[7].FindControl("txtPrice")).Text)).ToString(Constant.DoubleFormat);
                }
            }
        }
        return ret;
    }

    private void ReturnMaterialDivision(int RowIndex)
    {
        PlanFoodDetailItem item = new PlanFoodDetailItem();
        if (item.UpdateMaterialDivision(Convert.ToDouble("0" + this.txtLOID.Text), Convert.ToDouble("0" + this.txtMaterialID.Text), Convert.ToDouble("0" + this.gvDetail.Rows[RowIndex].Cells[0].Text), "CO"))
            this.gvDetail.DataBind();
    }

    private bool doGetDetail(string LOID)
    {
        this.txtCurentTab.Text = this.tabPlanOrder.ActiveTabIndex.ToString();
        PlanOrderFoodFlow fFlow = new PlanOrderFoodFlow();
        PlanFoodDetailData fData = fFlow.GetDetails(Convert.ToDouble(LOID));

        bool ret = true;
        SetData(fData);
        return ret;
    }

    private bool doUpdateStatus(string status)
    {
        PlanOrderFoodFlow ftFlow = new PlanOrderFoodFlow();
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
        PlanOrderFoodFlow ftFlow = new PlanOrderFoodFlow();
        bool ret = true;
        string error = "";

        // verify required field
        PlanFoodDetailData pData = GetData();
        if (status != "") pData.STATUS = status;

        switch (pData.STATUS)
        {
            case "WA":
                goto case "CF";
            case "CO":
                goto case "CF";
            case "CF" :
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
                if (ftFlow.CheckUniqueDate(pData.LOID, pData.STARTDATE, pData.ENDDATE))
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
                    ret = ftFlow.UpdateData(pData, Appz.CurrentUser, this.txtCurentTab.Text, sendOrg);
                else
                    ret = ftFlow.InsertData(pData, Appz.CurrentUser, this.txtCurentTab.Text, sendOrg);

                break;
            case "SA":
                goto case "DA";
            case "DA" :
                ret = ftFlow.UpdateStatus(pData.LOID, pData.STATUS, pData.QTCODE, pData.REFPRSAP, Appz.CurrentUser);
                break;
        }
        if (!ret)
            SetStatus(ftFlow.ErrorMessage, true);
        else
        {
            this.txtCurentTab.Text = this.tabPlanOrder.ActiveTabIndex.ToString();
            doGetDetail(ftFlow.LOID.ToString());
            if (pData.LOID == 0)
                SetStatus(DataResources.MSGIN001, false);
            else
                SetStatus(DataResources.MSGIU001, false);
        }
        return ret;
    }

    private string VerifyData(PlanFoodDetailData pData)
    {
        string ret = "";
        if (pData.NAME == "")
            ret = string.Format(DataResources.MSGEI001, "ชื่อแผนประมาณการ");
        else if (pData.PHASE == "")
            ret = string.Format(DataResources.MSGEI001, "งวดที่ประมาณการ");
        else if (pData.BUDGETYEAR == 0)
            ret = string.Format(DataResources.MSGEI001, "ปีงบประมาณ");
        else if (pData.STARTDATE.Year == 1)
            ret = string.Format(DataResources.MSGEI001, "ช่วงเวลาเริ่มต้น");
        else if (pData.ENDDATE.Year == 1)
            ret = string.Format(DataResources.MSGEI001, "ช่วงเวลาสิ้นสุด");
        else if (pData.STATUS == "CO")
        {
            if (pData.ArrMaterialMaster.Count == 0)
            {
                ret = string.Format(DataResources.MSGEI002, "วัสดุอาหาร");
            }
            //else
            //{
            //    for (int i = 0; i < pData.ArrMaterialMaster.Count; ++i)
            //    {
            //        VPlanFoodMaterialData mData = (VPlanFoodMaterialData)pData.ArrMaterialMaster[i];
            //        if (mData.PRICE == 0)
            //        {
            //            ret = string.Format(DataResources.MSGEI001, "ราคาวัสดุอาหาร");
            //            break;
            //        }
            //    }
            //}
        }
        else if (pData.STATUS == "CF")
        {
            if (pData.ArrMaterialCouncil.Count == 0)
            {
                ret = string.Format(DataResources.MSGEI002, "คณะกรรมการตรวจรับ");
            }
            else
            {
                for (int i = 0; i < pData.ArrMaterialCouncil.Count; ++i)
                {
                    PlanOrderCouncilData mData = (PlanOrderCouncilData)pData.ArrMaterialCouncil[i];
                    if (mData.POSITION.Trim() == "")
                    {
                        ret = string.Format(DataResources.MSGEI001, "ตำแหน่ง");
                        break;
                    }
                }
            }
        }

        return ret;
    }

    #endregion

}
