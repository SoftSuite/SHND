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
/// PlanContractFood Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Teang
/// Create Date: 13 Feb 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้าการทำรายการข้อมูล PlanContractFood
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
public partial class App_Plan_Transaction_PlanContractFood : System.Web.UI.Page
{
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        this.txtCurentTab.Text = this.tabPlanOrder.ActiveTabIndex.ToString();
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
        if (this.txtStatus.Text == "DA" && this.tbSave.Visible)
        {
            if (!doSave())
                this.tabPlanOrder.ActiveTabIndex = Convert.ToInt32(this.txtCurentTab.Text);
        }
        else
            doGetDetail("0" + this.txtLOID.Text);
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
        Response.Redirect(Constant.HomeFolder + "App_Plan/Transaction/PlanContractFoodSearch.aspx");
    }
    protected void tbApproveClick(object sender, EventArgs e)
    {
        doSave("FN", true);
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
        PlanFoodDetailItem item = new PlanFoodDetailItem();
        item.ClearDetail();

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
        this.txtMaterialID.Text = gRow.Cells[1].Text;
        this.lblMaterialNameDetail.Text = gRow.Cells[4].Text + " (" + gRow.Cells[5].Text + ")";
        this.txtSpecView.Text = gRow.Cells[16].Text;
        this.gvDetail.DataBind();
        this.ctlDetailPopup.Show();
    }

    private ArrayList GetPlanMaterialItemList()
    {
        ArrayList arrData = new ArrayList();
        PlanMaterialItemData pData;
        for (int i = 0; i < this.gvMaterial.Rows.Count; ++i)
        {
            GridViewRow gRow = this.gvMaterial.Rows[i];
            pData = new PlanMaterialItemData();
            pData.ISVAT = ((CheckBox)gRow.Cells[9].FindControl("chkVat")).Checked;
            pData.LOID = Convert.ToDouble("0" + gRow.Cells[0].Text);
            pData.MATERIALMASTER = Convert.ToDouble("0" + gRow.Cells[1].Text);
            pData.PLANMATERIALCLASS = Convert.ToDouble("0" + gRow.Cells[19].Text);
            pData.PLANQTY = Convert.ToDouble("0" + gRow.Cells[11].Text);
            pData.PRICE = Convert.ToDouble("0" + ((TextBox)gRow.Cells[7].FindControl("txtPrice")).Text);
            pData.SPEC = gRow.Cells[16].Text;
            pData.UNIT = Convert.ToDouble("0" + gRow.Cells[17].Text);
            arrData.Add(pData);
        }
        return arrData;
    }

    private ArrayList GetPlanMaterialClassList()
    {
        ArrayList arrData = new ArrayList();
        PlanMaterialClassData pData;
        for (int i=0; i<this.gvMaterialClass.Rows.Count; ++i)
        {
            GridViewRow gRow = this.gvMaterialClass.Rows[i];
            pData = new PlanMaterialClassData();
            pData.CONTRACTCODE = ((TextBox)gRow.Cells[5].FindControl("txtContractCode")).Text.Trim();
            pData.LOID = Convert.ToDouble("0" + gRow.Cells[0].Text);
            pData.SUPPLIER = Convert.ToDouble(((DropDownList)gRow.Cells[4].FindControl("cmbSupplier")).SelectedItem.Value);
            arrData.Add(pData);
        }
        return arrData;
    }

    private PlanFoodDetailData GetData()
    {
        PlanFoodDetailData pData = new PlanFoodDetailData();
        pData.LOID = Convert.ToDouble("0" + this.txtLOID.Text);
        pData.STATUS = this.txtStatus.Text;
        pData.ArrMaterialMaster = GetPlanMaterialItemList();
        pData.PlanMaterialClass = GetPlanMaterialClassList();
        return pData;
    }

    private void ViewData(bool isView)
    {
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

        if (!pageAuthorized || pData.STATUS != "DA")
        {
            ViewData(true);

            tbSaveSpec.Visible = false;
            this.tbSave.Visible = false;
            this.tbCancel.Visible = false;
            this.tbApprove.Visible = false;
        }
        else
        {
            ViewData(false);
            this.tbSave.Visible = true;
            this.tbCancel.Visible = true;
            this.tbApprove.Visible = true;
        }

        this.gvMaterial.DataSource = pData.PlanMaterialItemTable;
        this.gvMaterial.DataBind();

        this.gvMaterialClass.DataSource = pData.PlanMaterialClassTable;
        this.gvMaterialClass.DataBind();
    }

    #endregion

    #region Working Method

    private bool doGetDetail(string LOID)
    {
        this.txtCurentTab.Text = this.tabPlanOrder.ActiveTabIndex.ToString();
        PlanContractFoodFlow fFlow = new PlanContractFoodFlow();
        PlanFoodDetailData fData = fFlow.GetDetail(Convert.ToDouble(LOID));

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
        PlanContractFoodFlow ftFlow = new PlanContractFoodFlow();
        bool ret = true;
        string error = "";

        // verify required field
        PlanFoodDetailData pData = GetData();
        if (status != "") pData.STATUS = status;

        error = VerifyData(pData);
        if (error != "")
        {
            SetStatus(error, true);
            return false;
        }
        ret = ftFlow.UpdateData(pData, Appz.CurrentUser, this.txtCurentTab.Text);

        if (!ret)
            SetStatus(ftFlow.ErrorMessage, true);
        else
        {
            doGetDetail(ftFlow.LOID.ToString());
            SetStatus(DataResources.MSGIU001, false);
        }
        return ret;
    }

    private string VerifyData(PlanFoodDetailData pData)
    {
        string ret = "";
        if (pData.STATUS == "FN")
        {
            for (int i = 0; i < pData.ArrMaterialMaster.Count; ++i)
            {
                PlanMaterialItemData mData = (PlanMaterialItemData)pData.ArrMaterialMaster[i];
                if (mData.PRICE == 0)
                {
                    ret = string.Format(DataResources.MSGEI001, "ราคาต่อหน่วยรวมภาษี");
                    break;
                }
            }
            for (int i = 0; i < pData.PlanMaterialClass.Count; ++i)
            {
                PlanMaterialClassData mData = (PlanMaterialClassData)pData.PlanMaterialClass[i];
                if (mData.SUPPLIER == 0)
                {
                    ret = string.Format(DataResources.MSGEI002, "บริษัท");
                    break;
                }
                else if (mData.CONTRACTCODE == "")
                {
                    ret = string.Format(DataResources.MSGEI001, "เลขที่สัญญา");
                    break;
                }
            }
        }

        return ret;
    }

    #endregion

    protected void gvMaterialClass_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList cmbSupplier = (DropDownList)e.Row.Cells[3].FindControl("cmbSupplier");
            if (e.Row.Cells[6].Text == "DA")
            {
                Appz.BuildCombo(cmbSupplier, "SUPPLIER", "NAME", "LOID", "ACTIVE = '1'", "NAME", "เลือก", "0", false);
                cmbSupplier.Enabled = true;
            }
            else
            {
                Appz.BuildCombo(cmbSupplier, "SUPPLIER", "NAME", "LOID", "", "NAME", "", "0", false);
                cmbSupplier.Enabled = false;
            }
            cmbSupplier.SelectedIndex = cmbSupplier.Items.IndexOf(cmbSupplier.Items.FindByValue(e.Row.Cells[1].Text));
        }
    }
}