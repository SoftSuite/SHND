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
/// PlanOrderToolsDivision Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Teang
/// Create Date: 11 Feb 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้าการทำรายการข้อมูล PlanOrderToolsDivision
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
public partial class App_Plan_Transaction_PlanOrderToolsDivision : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Appz.BuildCombo(this.cmbMaterialClass, "MATERIALCLASS", "NAME", "LOID", "", "", "", "", false);
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
        Response.Redirect(Constant.HomeFolder + "App_Plan/Transaction/PlanOrderToolsDivisionSearch.aspx");
    }
    protected void tbSendClick(object sender, EventArgs e)
    {
        doSave("ST");
    }
    #endregion

    protected void lnkCode_Click(object sender, EventArgs e)
    {
        int rowIndex = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;
        SetSpecData(rowIndex);
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
        this.lblMaterialName.Text = "";
        this.txtSpec.Text = "";
    }

    private void SetSpecData(int rowIndex)
    {
        ClearSpec();

        GridViewRow gRow = this.gvMaterial.Rows[rowIndex];
        this.lblMaterialName.Text = gRow.Cells[3].Text + " (" + gRow.Cells[4].Text + ")";
        this.txtSpec.Text = gRow.Cells[7].Text;
        this.ctlSpecPopup.Show();
    }

    private ArrayList GetToolsDivisionList()
    {
        ArrayList arrData = new ArrayList();
        PlanToolsDivisionData pData;
        for (int i = 0; i < this.gvMaterial.Rows.Count; ++i)
        {
            pData = new PlanToolsDivisionData();
            GridViewRow gRow = this.gvMaterial.Rows[i];
            pData.ADJQTY = 0;
            pData.LOID = Convert.ToDouble(gRow.Cells[0].Text);
            pData.REQQTY = Convert.ToDouble("0" + ((TextBox)gRow.Cells[5].FindControl("txtReqQty")).Text);
            arrData.Add(pData);
        }
        return arrData;
    }

    private PlanToolsDivisionDetailData GetData()
    {
        PlanToolsDivisionDetailData pData = new PlanToolsDivisionDetailData();
        pData.LOID = Convert.ToDouble("0" + this.txtLOID.Text);
        pData.STATUS = this.txtStatus.Text;
        pData.PlanToolsDivisionList = GetToolsDivisionList();
        return pData;
    }

    private void SetData(PlanToolsDivisionDetailData pData)
    {
        bool pageAuthorized = true;
        this.txtBudgetYear.Text = pData.BUDGETYEAR.ToString();
        this.txtCode.Text = pData.CODE;
        this.txtLOID.Text = pData.LOID.ToString();
        this.txtName.Text = pData.NAME;
        this.txtStatus.Text = pData.STATUS;
        this.txtStatusName.Text = pData.STATUSNAME;
        this.ctlEndDate.DateValue = pData.ENDDATE;
        this.ctlStartDate.DateValue = pData.STARTDATE;
        this.txtDivisionName.Text = pData.DIVISIONNAME;
        this.cmbMaterialClass.SelectedIndex = this.cmbMaterialClass.Items.IndexOf(this.cmbMaterialClass.Items.FindByValue(pData.MATERIALCLASS.ToString()));
        this.txtClassName.Text = this.cmbMaterialClass.SelectedItem.Text;
        this.gvMaterial.DataSource = pData.PlanToolsDivisionTable;
        this.gvMaterial.DataBind();

        if (!pageAuthorized || pData.STATUS != "CO")
        {
            this.tbSend.Visible = false;
        }
        else
        {
            this.tbSend.Visible = true;
        }
    }

    #endregion

    #region Working Method

    private bool doGetDetail(string LOID)
    {
        PlanOrderToolsDivisionFlow fFlow = new PlanOrderToolsDivisionFlow();
        PlanToolsDivisionDetailData fData = fFlow.GetDetails(Convert.ToDouble(LOID));

        bool ret = true;
        SetData(fData);
        return ret;
    }

    private bool doSave()
    {
        return doSave("");
    }

    private bool doSave(string status)
    {
        PlanOrderToolsDivisionFlow ftFlow = new PlanOrderToolsDivisionFlow();
        bool ret = true;
        // verify required field
        PlanToolsDivisionDetailData pData = GetData();
        if (status != "") pData.STATUS = status;

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

    #endregion

}
