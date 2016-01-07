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
/// PlanOrderFoodDivision Page Class
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
///    หน้าการทำรายการข้อมูล PlanOrderFoodDivision
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
public partial class App_Plan_Transaction_PlanOrderFoodDivision : System.Web.UI.Page
{
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
        Response.Redirect(Constant.HomeFolder + "App_Plan/Transaction/PlanOrderFoodDivisionSearch.aspx");
    }
    protected void tbSendClick(object sender, EventArgs e)
    {
        doSave("ST");
    }
    protected void tbCalculateClick(object sender, EventArgs e)
    {
        UpdateMenuQty();
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
        this.txtSpec.Text = gRow.Cells[9].Text;
        this.ctlSpecPopup.Show();
    }

    private ArrayList GetMaterialDivisionList()
    {
        ArrayList arrData = new ArrayList();
        PlanMaterialDivisionData pData;
        for (int i = 0; i < this.gvMaterial.Rows.Count; ++i)
        {
            pData = new PlanMaterialDivisionData();
            GridViewRow gRow = this.gvMaterial.Rows[i];
            pData.ADJQTY = 0;
            pData.LOID = Convert.ToDouble(gRow.Cells[0].Text);
            pData.MENUQTY = Convert.ToDouble("0" + gRow.Cells[6].Text);
            pData.REQQTY = Convert.ToDouble("0" + ((TextBox)gRow.Cells[7].FindControl("txtReqQty")).Text);
            arrData.Add(pData);
        }
        return arrData;
    }

    private PlanFoodDivisionDetailData GetData()
    {
        PlanFoodDivisionDetailData pData = new PlanFoodDivisionDetailData();
        pData.LOID = Convert.ToDouble("0" + this.txtLOID.Text);
        pData.STATUS = this.txtStatus.Text;
        pData.MaterialDivisionList = GetMaterialDivisionList();
        return pData;
    }

    private void SetData(PlanFoodDivisionDetailData pData)
    {
        double total = 0;
        bool pageAuthorized = true;
        this.txtBudgetYear.Text = pData.BUDGETYEAR.ToString();
        this.txtCode.Text = pData.CODE;
        this.txtLOID.Text = pData.LOID.ToString();
        this.txtName.Text = pData.NAME;
        this.txtPhase.Text = pData.PHASE.ToString();
        this.txtStatus.Text = pData.STATUS;
        this.txtStatusName.Text = pData.STATUSNAME;
        this.ctlEndDate.DateValue = pData.ENDDATE;
        this.ctlStartDate.DateValue = pData.STARTDATE;
        this.txtDivisionName.Text = pData.DIVISIONNAME;
        this.gvMenu.DataSource = pData.MenuByDivision;
        this.gvMenu.DataBind();
        this.gvMaterial.DataSource = pData.MaterialDivision;
        this.gvMaterial.DataBind();

        for (int i = 0; i < pData.MenuByDivision.Rows.Count; ++i)
        {
            total += Convert.ToDouble(pData.MenuByDivision.Rows[i]["PORTION"]);
        }

        if (this.gvMenu.Rows.Count >0) ((Label)this.gvMenu.FooterRow.Cells[1].FindControl("lblTotal")).Text = total.ToString(Constant.IntFormat);

        if (!pageAuthorized || pData.STATUS != "CO")
        {
            this.tbSend.Visible = false;
            this.tbCalculate.Visible = false;
        }
        else
        {
            this.tbSend.Visible = true;
            this.tbCalculate.Visible = true;
        }
    }

    #endregion

    #region Working Method

    private void UpdateMenuQty()
    {
        PlanOrderFoodDivisionFlow fFlow = new PlanOrderFoodDivisionFlow();
        this.gvMaterial.DataSource = fFlow.GetCalculatedItem(Convert.ToDouble("0" + this.txtLOID.Text), this.ctlStartDate.DateValue, this.ctlEndDate.DateValue);
        this.gvMaterial.DataBind();
    }

    private bool doGetDetail(string LOID)
    {
        PlanOrderFoodDivisionFlow fFlow = new PlanOrderFoodDivisionFlow();
        PlanFoodDivisionDetailData fData = fFlow.GetDetails(Convert.ToDouble(LOID));

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
        PlanOrderFoodDivisionFlow ftFlow = new PlanOrderFoodDivisionFlow();
        bool ret = true;
        // verify required field
        PlanFoodDivisionDetailData pData = GetData();
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
