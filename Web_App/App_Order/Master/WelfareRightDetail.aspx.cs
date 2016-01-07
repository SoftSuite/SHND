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
using SHND.Data.Formula;
using SHND.Data.Tables;
using SHND.Data.Views;
using SHND.Flow.Order;
using SHND.Global;

/// <summary>
/// Formula Feed Detail Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Tan
/// Create Date: 13 Jan 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้ากาารทำงานข้อมูล WelfareRight
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

public partial class App_Order_Master_WelfareRightDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
                doGetDetail((Request["loid"] == null ? "0" : Request["loid"]));

        }

    }
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        // Feed Combo source
        //Appz.BuildCombo(cmbFeedType, "FeedTYPE", "NAME", "LOID", "ACTIVE='1'", "NAME", "เลือก", "0", false);
        //Appz.BuildCombo(cmbFeedCategory, "FeedCATEGORY", "NAME", "LOID", "ACTIVE='1'", "NAME", "เลือก", "0", false);
        //Appz.BuildCombo(cmbFeedCookType, "FeedCOOKTYPE", "NAME", "LOID", "ACTIVE='1'", "NAME", "เลือก", "0", false);
        //Appz.BuildCombo(cmbDishesType, "DISHESTYPE", "NAME", "LOID", "ACTIVE='1'", "NAME", "เลือก", "0", false);
        //Appz.BuildCombo(cmbPackage, "V_MATERIALMASTER", "NAME", "LOID", "ACTIVE='1' AND MASTERTYPE = 'TL'", "NAME", "เลือก", "0", false);

        ControlUtil.SetYearTextbox(txtYear);
        ControlUtil.SetIntTextBox(txtDay);

       
        this.tbDeleteDivision.ClientClick = "return confirm('" + DataResources.MSGCD003 + "')";
    }


    protected void ctlDivisionPopup_SelectedIndexChanged(object sender, EventArgs e, ArrayList arrData)
    {
        WelfareRightItem fsItem = new WelfareRightItem();
        if (fsItem.InsertWelfareRightItem(Convert.ToDouble("0" + this.txtLOID.Text), arrData))
            BindWelfareRightItem();
    }

    #region Button Click Event Handler

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
        Response.Redirect(Constant.HomeFolder + "App_Order/Master/WelfareRight.aspx");
    }


    #endregion

    #region FormulaFeedItem Toolbar
    protected void tbAddDivisionClick(object sender, EventArgs e)
    {
        UpdateWelfareRightItem();
        WelfareRightItem fsItem = new WelfareRightItem();
        this.ctlDivisionPopup.Show(fsItem.getDivision());
    }
    protected void tbDeleteDivisionClick(object sender, EventArgs e)
    {
        UpdateWelfareRightItem();
        WelfareRightItem fsItem = new WelfareRightItem();
        if (fsItem.DeleteWelfareRightItem(GetCheckedWelfareRightItem())) BindWelfareRightItem();
    }
    #endregion


    #region Gridview Event Handler

    protected void gvWelfareRightItem_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    DropDownList cmbUnit = (DropDownList)e.Row.Cells[6].FindControl("cmbUnit");

        //    Appz.BuildCombo(cmbUnit, "V_MATERIALMASTER_UNIT", "UNITNAME", "UNIT", "ISFORMULA = 'Y' AND MATERIALMASTER = " + e.Row.Cells[12].Text, "", null, null, false);
        //    DataRow drow = (DataRow)((DataRowView)e.Row.DataItem).Row;
        //    cmbUnit.SelectedIndex = cmbUnit.Items.IndexOf(cmbUnit.Items.FindByValue(drow["UNIT"].ToString()));
        //}
    }

    #endregion

    #region Misc. Methods

    private ArrayList GetCheckedWelfareRightItem()
    {
        ArrayList arrChk = new ArrayList();
        for (int i = 0; i < gvWelfareRightItem.Rows.Count; i++)
        {
            if (i > -1 && gvWelfareRightItem.Rows[i].Cells[0].FindControl("chkSelect") != null)
            {
                GridViewRow gRow = gvWelfareRightItem.Rows[i];
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

    private void BindWelfareRightItem()
    {
        this.gvWelfareRightItem.DataBind();
    }

    private void SetErrorStatusWelfareRightItem(string t)
    {
        lbStatusFormulaFeedItem.Text = t;
        lbStatusFormulaFeedItem.ForeColor = Constant.StatusColor.Error;
    }

    private void FeedStatusWelfareRightItem(string t)
    {
        lbStatusFormulaFeedItem.Text = t;
        lbStatusFormulaFeedItem.ForeColor = Constant.StatusColor.Information;
    }

    private void SetStatus(string t)
    {
        lbStatus.Text = t;
        lbStatus.ForeColor = Constant.StatusColor.Information;
    }

    private void SetErrorStatus(string t)
    {
        lbStatus.Text = t;
        lbStatus.ForeColor = Constant.StatusColor.Error;
    }

    private ArrayList GetWelfareRightItem()
    {
        ArrayList arrData = new ArrayList();
        for (int i = 0; i < this.gvWelfareRightItem.Rows.Count; ++i)
        {
            CheckBox chkOver = (CheckBox)this.gvWelfareRightItem.Rows[i].Cells[7].FindControl("chkOver");

            VWelfareRightItemData WelfareRightItem = new VWelfareRightItemData();
            WelfareRightItem.WELFARERIGHT = Convert.ToDouble("0" + this.txtLOID.Text);
            WelfareRightItem.DIVISION = Convert.ToDouble("0" + this.gvWelfareRightItem.Rows[i].Cells[8].Text);
            WelfareRightItem.QTY = Convert.ToDouble("0" + ((TextBox)this.gvWelfareRightItem.Rows[i].Cells[5].FindControl("txtQty")).Text);
            WelfareRightItem.QTYRIGHT = Convert.ToDouble("0" + ((TextBox)this.gvWelfareRightItem.Rows[i].Cells[6].FindControl("txtRightQty")).Text);
            WelfareRightItem.LOID = Convert.ToDouble("0" + this.gvWelfareRightItem.Rows[i].Cells[1].Text);
            WelfareRightItem.ISOVER = chkOver.Checked ? "Y" : "N";

            arrData.Add(WelfareRightItem);
        }
        return arrData;
    }

    private VWelfareRightData GetData()
    {
        VWelfareRightData fsData = new VWelfareRightData();
        fsData.RIGHTMONTH = cmbMonth.SelectedValue;
        fsData.RIGHTYEAR = Convert.ToDouble(txtYear.Text);
        fsData.QTYDATE = Convert.ToDouble(txtDay.Text);

        fsData.LOID = Convert.ToDouble("0" + this.txtLOID.Text);

        fsData.WelfareRightItem = GetWelfareRightItem();

        return fsData;
    }

    private void SetData(VWelfareRightData fsData)
    {
        this.txtLOID.Text = fsData.LOID.ToString();
        this.cmbMonth.SelectedValue = fsData.RIGHTMONTH;
        this.txtDay.Text = fsData.QTYDATE.ToString();
        this.txtYear.Text = fsData.RIGHTYEAR.ToString();

        WelfareRightItem fsItem = new WelfareRightItem();

        fsItem.ClearAllSession();
        BindWelfareRightItem();

        if (fsData.LOID == 0)
        {
         txtYear.Text = (DateTime.Now.Year+543).ToString();
        }


    }

    #endregion

    #region Working Method

    private void UpdateWelfareRightItem()
    {
        WelfareRightItem fsItem = new WelfareRightItem();
        if (!fsItem.UpdateWelfareRightItem(Convert.ToDouble("0" + this.txtLOID.Text), GetWelfareRightItem()))
            SetErrorStatusWelfareRightItem(DataResources.MSGEC102);
        else
            FeedStatusWelfareRightItem(DataResources.MSGIU001);
    }

    private bool doGetDetail(string LOID)
    {
        WelfareRightFlow fFlow = new WelfareRightFlow();
        VWelfareRightData fData = fFlow.GetDetails(Convert.ToDouble(LOID));

        bool ret = true;
        SetData(fData);
        WelfareRightItem fsItem = new WelfareRightItem();

        fsItem.ClearAllSession();
        BindWelfareRightItem();

        return ret;
    }

    private bool doSave()
    {
        // verify required field
        VWelfareRightData WelfareRightDetail = GetData();
        string error = VerifyData(WelfareRightDetail);
        if (error != "")
        {
            SetErrorStatus(error);
            return false;
        }

        WelfareRightFlow ftFlow = new WelfareRightFlow();
        bool ret = true;

        // verify uniq field
        //if (!ftFlow.CheckUniqueKey(FormulaFeedDetail.LOID, FormulaFeedDetail.NAME))
        //{
        //    SetErrorStatus(string.Format(DataResources.MSGEI015, "ชื่อสูตร", FormulaFeedDetail.NAME));
        //    return false;
        //}

        // data correct go on saving...
        if (WelfareRightDetail.LOID != 0)
            ret = ftFlow.UpdateData(WelfareRightDetail, Appz.CurrentUser);
        else
            ret = ftFlow.InsertData(WelfareRightDetail, Appz.CurrentUser);

        if (!ret)
            SetErrorStatus(ftFlow.ErrorMessage);
        else
        {
            doGetDetail(ftFlow.LOID.ToString());
            if (WelfareRightDetail.LOID != 0)
                SetStatus(DataResources.MSGIU001);
            else
                SetStatus(DataResources.MSGIN001);
        }

        return ret;
    }

    private string VerifyData(VWelfareRightData fData)
    {
        string ret = "";
        bool check = true;
        if (fData.RIGHTMONTH == "")
            ret = string.Format(DataResources.MSGEI001, "เดือน");
        else if (fData.RIGHTYEAR == 0)
            ret = string.Format(DataResources.MSGEI001, "ปี");
        else if (fData.QTYDATE == 0)
            ret = string.Format(DataResources.MSGEI001, "จำนวนวันทำการ");
        else if (gvWelfareRightItem.Rows.Count == 0)
            ret = string.Format(DataResources.MSGEI001, "หน่วยงาน");

        if (ret == "")
        {
            foreach (GridViewRow row in gvWelfareRightItem.Rows)
            {
                TextBox txt = (TextBox)row.Cells[5].FindControl("txtQty");
                if (txt.Text == "" || Convert.ToDouble(txt.Text) == 0)
                {
                    check = false;
                    break;
                }
            }
            if (!check)
                ret = string.Format(DataResources.MSGEI001, "จำนวนคน");
        }

        return ret;
    }

    protected void txtQty_TextChanged(object sender, EventArgs e)
    {
        TextBox txt = (TextBox)sender;
        Int16 rowIndex = (Int16)((GridViewRow)txt.Parent.Parent).RowIndex;

        double qty = Convert.ToDouble(txt.Text);
        double day = Convert.ToDouble(txtDay.Text);

        ((TextBox)this.gvWelfareRightItem.Rows[rowIndex].Cells[6].FindControl("txtRightQty")).Text = (qty * day).ToString();

    }

    protected void txtDay_TextChanged(object sender, EventArgs e)
    {
        double qty = Convert.ToDouble(txtDay.Text);
        foreach (GridViewRow row in gvWelfareRightItem.Rows)
        {
            TextBox txtRightQty = (TextBox)row.Cells[6].FindControl("txtRightQty");
            TextBox txtQty = (TextBox)row.Cells[5].FindControl("txtQty");
            double RightQty = Convert.ToDouble(txtQty.Text);
            txtRightQty.Text = (RightQty * qty).ToString();
        }
    }
    #endregion


    protected void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(cmbMonth.SelectedValue != "0" & txtYear.Text != "")
        {
            DateTime StartDate = new DateTime(int.Parse(txtYear.Text)-543, int.Parse(cmbMonth.SelectedValue), 1);
            DateTime EndDate = new DateTime(int.Parse(txtYear.Text)-543, int.Parse(cmbMonth.SelectedValue)+1, 1);

        TimeSpan Date = EndDate - StartDate;
        int Day = Date.Days;
        WelfareRightFlow wFlow = new WelfareRightFlow();
        double holiday = wFlow.GetHoliday(StartDate, EndDate);
        txtDay.Text = (Day - holiday).ToString();
        double qty = Convert.ToDouble(txtDay.Text);
        foreach (GridViewRow row in gvWelfareRightItem.Rows)
        {
            TextBox txtRightQty = (TextBox)row.Cells[6].FindControl("txtRightQty");
            TextBox txtQty = (TextBox)row.Cells[5].FindControl("txtQty");
            double RightQty = Convert.ToDouble(txtQty.Text);
            txtRightQty.Text = (RightQty * qty).ToString();
        }
        }
    }
    protected void txtYear_TextChanged(object sender, EventArgs e)
    {
        if (cmbMonth.SelectedValue != "0" & txtYear.Text != "")
        {
            DateTime StartDate = new DateTime(int.Parse(txtYear.Text) - 543, int.Parse(cmbMonth.SelectedValue), 1);
            DateTime EndDate = new DateTime(int.Parse(txtYear.Text) - 543, int.Parse(cmbMonth.SelectedValue) + 1, 1);

            TimeSpan Date = EndDate - StartDate;
            int Day = Date.Days;
            txtDay.Text = Day.ToString();
            double qty = Convert.ToDouble(txtDay.Text);
            foreach (GridViewRow row in gvWelfareRightItem.Rows)
            {
                TextBox txtRightQty = (TextBox)row.Cells[6].FindControl("txtRightQty");
                TextBox txtQty = (TextBox)row.Cells[5].FindControl("txtQty");
                double RightQty = Convert.ToDouble(txtQty.Text);
                txtRightQty.Text = (RightQty * qty).ToString();
            }
        }
    }
}
