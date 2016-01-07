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
using SHND.Flow.Prepare;
using SHND.Data.Tables;
using SHND.Global;
using SHND.Flow.Common;
using SHND.Data.Common.Utilities;
/// <summary>
/// FoodType Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Tan
/// Create Date: 22 May 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้ากาารทำงานข้อมูล WelRealServiceSearch
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

public partial class App_Prepare_Transaction_WelRealServiceSearch : System.Web.UI.Page
{
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

        // set Combo source
        Appz.BuildCombo(cmbDivision, "DIVISION", "NAME", "LOID", "ACTIVE='1' AND ISWELFARE='Y' AND ISSUBDIVISION = 'N'", "NAME", "เลือก", "0", false);
        Appz.BuildCombo(cmbSearchDiv, "DIVISION", "NAME", "LOID", "ACTIVE='1' AND ISWELFARE='Y' AND ISSUBDIVISION = 'N'", "NAME", "ทั้งหมด", "", false);
        pcTop.SetMainGridView(gvMain);
        pcBot.SetMainGridView(gvMain);
    }
    #region Button Click Event Handler
    protected void tbSave1Click(object sender, EventArgs e)
    {
        if (!doSave())
            zPop.Show();
        else
            ClearData();
    }
    protected void tbAddClick(object sender, EventArgs e)
    {
        zPop.Show();
    }
    protected void tbDeleteClick(object sender, EventArgs e)
    {
        doDelete();
    }
    protected void tbCancelClick(object sender, EventArgs e)
    {
        if (txhID.Text.Trim() == "")
            ClearData();
        else
            doGetDetail(txhID.Text);

        zPop.Show();
    }
    protected void tbBackClick(object sender, EventArgs e)
    {
        ClearData();
    }
    protected void lnkFood_Click(object sender, EventArgs e)
    {
        doGetDetail(((LinkButton)sender).CommandArgument);
        zPop.Show();
    }

    protected void imbSearch_Click(object sender, ImageClickEventArgs e)
    {
        gvMain.PageIndex = 0;
        doGetList();
    }

    protected void imbReset_Click(object sender, ImageClickEventArgs e)
    {
        ClearSearch();
        gvMain.PageIndex = 0;
        doGetList();
    }

    #endregion

    #region Gridview Event Handler

    protected void gvMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex > -1)
            e.Row.Cells[2].Text = ((e.Row.RowIndex + 1) + (gvMain.PageIndex * gvMain.PageSize)).ToString();
    }

    protected void gvMain_Sorting(object sender, GridViewSortEventArgs e)
    {
        WelRealServiceFlow fFlow = new WelRealServiceFlow();
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

    #endregion

    #region Paging Event Handler
    protected void PageChange(object sender, EventArgs e)
    {
        gvMain.PageIndex = ((Templates_PageControl)sender).SelectedPageIndex;
        doGetList();
        pcBot.Update();
        pcTop.Update();
    }
    #endregion

    #region Misc. Methods
    private ArrayList GetChecked()
    {
        ArrayList arrChk = new ArrayList();
        for (int i = 0; i < gvMain.Rows.Count; i++)
        {
            if (i > -1 && gvMain.Rows[i].Cells[0].FindControl("chkSelect") != null)
            {
                if (((CheckBox)gvMain.Rows[i].Cells[1].FindControl("chkSelect")).Checked)
                    arrChk.Add(gvMain.Rows[i].Cells[0].Text);
            }
        }

        return arrChk;
    }


    #endregion

    #region Controls Management Methods
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

    private void ClearData()
    {
        txhID.Text = "";
        txtCoupon.Text = "";
        txtCouponUse.Text = "";
        txtTiffin.Text = "";
        txtTiffinUse.Text = "";
        cmbDivision.SelectedIndex = 0;
        ctlServiceDate.DateValue = new DateTime();

    }

    private void ClearSearch()
    {
        // Clear searh data
        cmbSearchDiv.SelectedIndex = 0;
        ctlSearchDateFrom.DateValue = new DateTime();
        ctlSearchDateTo.DateValue = new DateTime();
    }

    private WelfareRealServiceData GetData()
    {
        WelfareRealServiceData ftData = new WelfareRealServiceData();
        ftData.LOID = Convert.ToDouble("0" + txhID.Text);
        ftData.COUPON = Convert.ToDouble("0" + txtCouponUse.Text);
        ftData.TIFFIN = Convert.ToDouble("0" + txtTiffinUse.Text);
        ftData.DIVISION = Convert.ToDouble(cmbDivision.SelectedItem.Value);
        ftData.SERVICEDATE = ctlServiceDate.DateValue;
        return ftData;
    }

    private void SetData(WelfareRealServiceData ftData)
    {
        txhID.Text = ftData.LOID.ToString();
        cmbDivision.SelectedIndex = cmbDivision.Items.IndexOf(cmbDivision.Items.FindByValue(ftData.DIVISION.ToString()));
        ctlServiceDate.DateValue = ftData.SERVICEDATE;
        txtCouponUse.Text = ftData.COUPON.ToString();
        txtTiffinUse.Text = ftData.TIFFIN.ToString();
        txtCoupon.Text = ftData.GETCOUPON.ToString();
        txtTiffin.Text = ftData.GETTIFFIN.ToString();
    }

    #endregion

    #region Working Method

    private void doGetList()
    {
        WelRealServiceFlow fFlow = new WelRealServiceFlow();

        // ตรวจสอบเงื่อนไขการค้นหาเพื่อแสดงปุ่ม reset การค้นหา
        imbReset.Visible = (ctlSearchDateFrom.DateValue.Year > 1) || (ctlSearchDateTo.DateValue.Year > 1) || (cmbSearchDiv.SelectedIndex != 0);

        string orderStr = "";
        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;

        gvMain.DataSource = fFlow.GetMasterList(ctlSearchDateFrom.DateValue, ctlSearchDateTo.DateValue, cmbSearchDiv.SelectedItem.Value, orderStr);
        gvMain.DataBind();
        pcTop.Update();
        pcBot.Update();
    }

    private bool doGetDetail(string LOID)
    {
        WelRealServiceFlow fFlow = new WelRealServiceFlow();
        WelfareRealServiceData fData = fFlow.GetDetails(Convert.ToDouble(LOID));

        bool ret = true;

        if (fData.LOID != 0)
        {
            SetData(fData);
        }
        else
            ret = false;

        return ret;
    }

    private bool doSave()
    {
        // verify required field
        string error = VerifyData();
        if (error != "")
        {
            SetErrorStatus(error);
            return false;
        }

        WelRealServiceFlow ftFlow = new WelRealServiceFlow();
        bool ret = true;

        // verify uniq field
        if (!ftFlow.CheckUniqCode(ctlServiceDate.DateValue,cmbDivision.SelectedValue, txhID.Text.Trim()))
        {
            SetErrorStatus(string.Format(DataResources.MSGEI015, "วันที่และผู้ใช้บริการ"));
            return false;
        }


        // data correct go on saving...
        if (txhID.Text.Trim() == "")
        {

            //  save new
            ret = ftFlow.InsertData(GetData(), Appz.CurrentUser);
        }
        else
        {
            // save update
            ret = ftFlow.UpdateData(GetData(), Appz.CurrentUser);
        }

        if (!ret)
            SetErrorStatus(ftFlow.ErrorMessage);
        else
            doGetList();

        return ret;
    }

    private void doDelete()
    {
        WelRealServiceFlow fFlow = new WelRealServiceFlow();
        if (fFlow.DeleteByLOID(GetChecked()))
        {
            gvMain.PageIndex = 0;
            doGetList();
            lbStatusMain.Text = "";
        }
        else
        {
            lbStatusMain.Text = fFlow.ErrorMessage;
            lbStatusMain.ForeColor = System.Drawing.Color.Red;
        }

    }

    private string VerifyData()
    {
        string ret = "";
        WelfareRealServiceData fData = GetData();
        if (fData.SERVICEDATE == new DateTime())
            ret = string.Format(DataResources.MSGEI002, "วันที่");
        else if (fData.DIVISION == 0)
            ret = string.Format(DataResources.MSGEI002, "ผู้ใช้บริการ");

        return ret;
    }

    #endregion
    protected void cmbDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        WelRealServiceFlow vGetRightQty = new WelRealServiceFlow();
        txtCoupon.Text = vGetRightQty.GetRightQty(this.ctlServiceDate.DateValue, Convert.ToDouble(cmbDivision.SelectedItem.Value), Convert.ToString("N")).ToString();
        txtTiffin.Text = vGetRightQty.GetRightQty(this.ctlServiceDate.DateValue, Convert.ToDouble(cmbDivision.SelectedItem.Value), Convert.ToString("Y")).ToString();
        zPop.Show();
    }

}
