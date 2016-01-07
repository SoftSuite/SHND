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
public partial class App_Plan_Transaction_PlanContractTools : System.Web.UI.Page
{
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        Appz.BuildCombo(this.cmbMaterialClass, "MATERIALCLASS", "NAME", "LOID", "", "", "", "", false);
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
        Response.Redirect(Constant.HomeFolder + "App_Plan/Transaction/PlanContractToolsSearch.aspx");
    }
    protected void tbApproveClick(object sender, EventArgs e)
    {
        doSave("FN", true);
    }
    #endregion

    protected void tbSaveSpecClick(object sender, EventArgs e)
    {
        int rowIndex = Convert.ToInt32(this.txtRowIndex.Text);
        this.gvMaterial.Rows[rowIndex].Cells[14].Text = this.txtSpec.Text.Trim();
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
        PlanToolsDetailItem item = new PlanToolsDetailItem();
        item.ClearToolsDivision();

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
        this.txtSpec.Text = gRow.Cells[14].Text;
        this.ctlSpecPopup.Show();
    }

    private void SetDetailData(int rowIndex)
    {
        ClearDetail();
        GridViewRow gRow = this.gvMaterial.Rows[rowIndex];
        this.txtRowIndex.Text = rowIndex.ToString();
        this.txtMaterialID.Text = gRow.Cells[1].Text;
        this.lblMaterialNameDetail.Text = gRow.Cells[4].Text + " (" + gRow.Cells[5].Text + ")";
        this.txtSpecView.Text = gRow.Cells[14].Text;
        this.gvDetail.DataBind();
        this.ctlDetailPopup.Show();
    }

    private ArrayList GetPlanToolsItemList()
    {
        ArrayList arrData = new ArrayList();
        PlanToolsItemData pData;
        for (int i = 0; i < this.gvMaterial.Rows.Count; ++i)
        {
            GridViewRow gRow = this.gvMaterial.Rows[i];
            pData = new PlanToolsItemData();
            pData.ISVAT = ((CheckBox)gRow.Cells[7].FindControl("chkVat")).Checked;
            pData.LOID = Convert.ToDouble("0" + gRow.Cells[0].Text);
            pData.MATERIALMASTER = Convert.ToDouble("0" + gRow.Cells[1].Text);
            pData.PLANQTY = Convert.ToDouble("0" + gRow.Cells[8].Text);
            pData.PRICE = Convert.ToDouble("0" + ((TextBox)gRow.Cells[6].FindControl("txtPrice")).Text);
            pData.SPEC = gRow.Cells[14].Text;
            pData.UNIT = Convert.ToDouble("0" + gRow.Cells[15].Text);
            pData.CONTRACTCODE = ((TextBox)gRow.Cells[12].FindControl("txtContractCode")).Text;
            pData.SUPPLIER = Convert.ToDouble("0" + ((DropDownList)gRow.Cells[11].FindControl("cmbSupplier")).Text); ;
            arrData.Add(pData);
        }
        return arrData;
    }

    private PlanToolsDetailData GetData()
    {
        PlanToolsDetailData pData = new PlanToolsDetailData();
        pData.LOID = Convert.ToDouble("0" + this.txtLOID.Text);
        pData.STATUS = this.txtStatus.Text;
        pData.PlanToolsItem = GetPlanToolsItemList();
        return pData;
    }

    private void ViewData(bool isView)
    {
        this.txtSpec.CssClass = (isView ? "zTextbox-View" : "zTextbox");
        this.txtSpec.ReadOnly = isView;
    }

    private void SetData(PlanToolsDetailData pData)
    {
        bool pageAuthorized = true;
        this.txtBudgetYear.Text = pData.BUDGETYEAR.ToString();
        this.txtCode.Text = pData.CODE;
        this.txtLOID.Text = pData.LOID.ToString();
        this.txtName.Text = pData.NAME;
        this.cmbMaterialClass.SelectedIndex = this.cmbMaterialClass.Items.IndexOf(this.cmbMaterialClass.Items.FindByValue(pData.MATERIALCLASS.ToString()));
        this.txtClassName.Text = this.cmbMaterialClass.SelectedItem.Text;
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

        this.gvMaterial.DataSource = pData.PlanToolsTable;
        this.gvMaterial.DataBind();
    }

    #endregion

    #region Working Method

    private bool doGetDetail(string LOID)
    {
        PlanContractToolsFlow fFlow = new PlanContractToolsFlow();
        PlanToolsDetailData fData = fFlow.GetDetail(Convert.ToDouble(LOID));

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
        PlanContractToolsFlow ftFlow = new PlanContractToolsFlow();
        bool ret = true;
        string error = "";

        // verify required field
        PlanToolsDetailData pData = GetData();
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

    private string VerifyData(PlanToolsDetailData pData)
    {
        string ret = "";
        if (pData.STATUS == "FN")
        {
            for (int i = 0; i < pData.PlanToolsItem.Count; ++i)
            {
                PlanToolsItemData mData = (PlanToolsItemData)pData.PlanToolsItem[i];
                if (mData.PRICE == 0)
                {
                    ret = string.Format(DataResources.MSGEI001, "ราคาต่อหน่วยรวมภาษี");
                    break;
                }
                else if (mData.SUPPLIER == 0)
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

    protected void gvMaterial_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList cmbSupplier = (DropDownList)e.Row.Cells[11].FindControl("cmbSupplier");
            if (e.Row.Cells[16].Text == "DA")
            {
                Appz.BuildCombo(cmbSupplier, "SUPPLIER", "NAME", "LOID", "ACTIVE = '1'", "NAME", "เลือก", "0", false);
                cmbSupplier.Enabled = true;
            }
            else
            {
                Appz.BuildCombo(cmbSupplier, "SUPPLIER", "NAME", "LOID", "", "NAME", "", "0", false);
                cmbSupplier.Enabled = false;
            }
            cmbSupplier.SelectedIndex = cmbSupplier.Items.IndexOf(cmbSupplier.Items.FindByValue(e.Row.Cells[17].Text));
        }
    }
}
