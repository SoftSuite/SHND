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
using SHND.Data.Common.Utilities;
using SHND.Data.Views;
using SHND.Global;
using SHND.Data.Order;

/// <summary>
/// ChangeOrder Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Nang
/// Create Date: 3 Apr 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้าการทำงานข้อมูลการเปลี่ยนแปลงอาหาร
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

public partial class App_Prepare_Transaction_ChangOrder : System.Web.UI.Page
{
    public Int32 CurrentPageIndex = 0;

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
        Appz.BuildCombo(cmbWard, "WARD", "NAME", "LOID", "ACTIVE='1'", "NAME", "ทั้งหมด", "0", true);
        Appz.BuildCombo(cmbOldType, "FOODTYPE", "NAME", "LOID", "ACTIVE ='1'", "NAME", "ทั้งหมด", "0", true);
        Appz.BuildCombo(cmbNewType, "FOODTYPE", "NAME", "LOID", "ACTIVE ='1'", "NAME", "ทั้งหมด", "0", true);
        Appz.BuildCombo(cmbOldCategory, "FOODCATEGORY", "NAME", "LOID", "ACTIVE ='1'", "NAME", "ทั้งหมด", "0", true);
        Appz.BuildCombo(cmbNewCategory, "FOODCATEGORY", "NAME", "LOID", "ACTIVE ='1'", "NAME", "ทั้งหมด", "0", true);
        ctlRegDate.DateValue = DateTime.Now;
        SetMealCombo(cmbMeal);
    }

    private void SetMealCombo(DropDownList cmb)
    {
        cmb.Items.Clear();
        cmb.Items.Add(new ListItem("เลือก", "0"));
        cmb.Items.Add(new ListItem("เช้า", "11"));
        cmb.Items.Add(new ListItem("กลางวัน", "21"));
        cmb.Items.Add(new ListItem("เย็น", "31"));
    }

    #region Button Click Event Handler

    protected void imbSearch_Click(object sender, ImageClickEventArgs e)
    {
        doGetList();
    }

    protected void tbSaveClick(object sender, EventArgs e)
    {
        UpdateRegister();
        RegisterPop.Show();
    }

    protected void tbBackClick(object sender, EventArgs e)
    {
        ClearData();
    }
    #endregion

    #region Gridview Event Handler

    #endregion

    #region Paging Event Handler

    #endregion


    #region Misc. Methods


    #endregion

    #region Controls Management Methods


    private void SetErrorStatus(string t)
    {
        lbStatus.Text = t;
        lbStatus.ForeColor = Constant.StatusColor.Error;
    }

    protected void cmbPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        CurrentPageIndex = Convert.ToInt32(((DropDownList)sender).SelectedValue.ToString());
        doGetList();
    }

    protected void cmbPage2_SelectedIndexChanged(object sender, EventArgs e)
    {
        CurrentPageIndex = Convert.ToInt32(((DropDownList)sender).SelectedValue.ToString());
        doGetList();
    }

    private void ClearData()
    {
        cmbMeal.SelectedIndex = -1;
        ctlRegDate.DateValue = DateTime.Today.Date;
        txhID.Text = "";
        lbStatus.Text = "";
    }

    protected void ChkTopCheckedChanged(object sender, EventArgs e)
    {
        CheckBox chktop = (CheckBox)sender;

        for (int i = 0; i < rptResult.Items.Count; i++)
        {
            App_Prepare_Transaction_ChangeOrder_ChangeorderCtl ctlChangOrder = (App_Prepare_Transaction_ChangeOrder_ChangeorderCtl)rptResult.Items[i].FindControl("ctlChangOrder");
            ctlChangOrder.GetCheckAllChangOrderCtl = chktop.Checked;
        }
    }
    #endregion

    #region Working Method

    private void doGetList()
    {
        ChangeOrderFlow cFlow = new ChangeOrderFlow();
        DataTable dt = new DataTable();
        PagedDataSource dsPaged = new PagedDataSource();
        string str = "";
        string orderStr = "";

        #region  condition where
        if (txhSortField.Text.Trim() != "")
            orderStr = " WARDNAME,PATIENTNAME ";

        //หอผู้ป่วย
        if (cmbWard.SelectedItem.Value != "0")
            str += (str == "" ? " " : " AND ") + " WARDID = " + this.cmbWard.SelectedItem.Value + "";

        //ชื่อ-สกุลผู้ป่วย
        if (txtPatientName.Text.Trim() != "")
            str += (str == "" ? " " : " AND ") + " UPPER(PATIENTNAME) LIKE UPPER('%" + txtPatientName.Text.Trim() + "%')";

        //ประเภทอาหาร OLD
        if (cmbOldType.SelectedItem.Value != "0")
            str += (str == "" ? " " : " AND ") + " FOODTYPEID_OLD = " + this.cmbOldType.SelectedItem.Value + "";

        //ประเภทอาหาร NEW
        if (cmbNewType.SelectedItem.Value != "0")
            str += (str == "" ? " " : " AND ") + " FOODTYPEID_NEW = " + this.cmbNewType.SelectedItem.Value + "";

        //ชนิดอาหาร OLD
        if (cmbOldCategory.SelectedItem.Value != "0")
            str += (str == "" ? " " : " AND ") + " FOODCATEGORID_OLD = " + this.cmbOldCategory.SelectedItem.Value + "";

        //ชนิดอาหาร NEW
        if (cmbNewCategory.SelectedItem.Value != "0")
            str += (str == "" ? " " : " AND ") + " FOODCATEGORID_NEW = " + this.cmbNewCategory.SelectedItem.Value + "";

        //วันที่ส่งอาหารใหม่
        if (ctlOrderDate.DateValue.Year.ToString() != "1")
        {
            String ss = ctlOrderDate.DateValue.Day.ToString() + '/' + ctlOrderDate.DateValue.Month.ToString() + '/' + Convert.ToString(ctlOrderDate.DateValue.Year);
            str += (str == "" ? " " : " AND ") + " ORDERDATE = TO_DATE('" + ss + "','DD/MM/YYYY')";
        }

        //เวลา
        if (txtOrderTimeFrom.Text.Trim() != "" && txtOrderTimeTo.Text.Trim() != "")
            str += (str == "" ? " " : " AND ") + " TO_CHAR(ORDERDATE,'HH24MM') BETWEEN '" + txtOrderTimeFrom.Text.Trim() + "' AND '" + txtOrderTimeTo.Text.Trim() + "'";
        else if (txtOrderTimeFrom.Text.Trim() != "")
            str += (str == "" ? " " : " AND ") + " TO_CHAR(ORDERDATE,'HH24MM') >= '" + txtOrderTimeFrom.Text.Trim() + "'";
        else if (txtOrderTimeTo.Text.Trim() != "")
            str += (str == "" ? " " : " AND ") + " TO_CHAR(ORDERDATE,'HH24MM') <= '" + txtOrderTimeTo.Text.Trim() + "'";

        //วันที่ยกเลิกอาหาร
        if (ctlEndDate.DateValue.Year.ToString() != "1")
        {
            String ss = ctlEndDate.DateValue.Day.ToString() + '/' + ctlEndDate.DateValue.Month.ToString() + '/' + Convert.ToString(ctlEndDate.DateValue.Year);
            str += (str == "" ? " " : " AND ") + " ENDDATE = TO_DATE('" + ss + "','DD/MM/YYYY')";
        }

        //เวลายกเลิกอาหาร
        if (txtEndTimeFrom.Text.Trim() != "" && txtOrderTimeTo.Text.Trim() != "")
            str += (str == "" ? " " : " AND ") + " TO_CHAR(ENDDATE,'HH24MM') BETWEEN '" + txtEndTimeFrom.Text.Trim() + "' AND '" + txtEndTimeTo.Text.Trim() + "'";
        else if (txtEndTimeFrom.Text.Trim() != "")
            str += (str == "" ? " " : " AND ") + " TO_CHAR(ENDDATE,'HH24MM') >= '" + txtEndTimeFrom.Text.Trim() + "'";
        else if (txtEndTimeTo.Text.Trim() != "")
            str += (str == "" ? " " : " AND ") + " TO_CHAR(ENDDATE,'HH24MM') <= '" + txtEndTimeTo.Text.Trim() + "'";

        #endregion

        #region SetData

        dt = cFlow.GetOrderChangeList(str, orderStr);
        ArrayList arr = new ArrayList();
        //txtConcat.Text = "";

        if (dt.Rows.Count != 0)
        {
            arr.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                VOrderChangeData vData = new VOrderChangeData();
                vData.ORDERNO = Convert.ToDouble(i + 1);
                vData.WARDNAME = dt.Rows[i]["WARDNAME"].ToString();
                vData.ROOMNO = dt.Rows[i]["ROOMNO"].ToString();
                vData.BEDNO = dt.Rows[i]["BEDNO"].ToString();
                vData.HN = dt.Rows[i]["HN"].ToString();
                vData.AN = dt.Rows[i]["AN"].ToString();
                vData.VN = dt.Rows[i]["VN"].ToString();
                vData.PATIENTNAME = dt.Rows[i]["PATIENTNAME"].ToString();
                vData.AGE = dt.Rows[i]["AGE"].ToString();
                vData.WEIGHT = Convert.ToDouble(dt.Rows[i]["WEIGHT"].ToString());
                vData.HEIGHT = Convert.ToDouble(dt.Rows[i]["HEIGHT"].ToString());
                vData.BMI = dt.Rows[i]["BMI"].ToString();
                vData.ADMITPATIENT = Convert.ToDouble(dt.Rows[i]["ADMITPATIENT"].ToString());
                arr.Add(vData);
            }
        }
        dsPaged.DataSource = arr;
        dsPaged.AllowPaging = true;
        dsPaged.PageSize = 20;
        dsPaged.CurrentPageIndex = CurrentPageIndex;
        rptResult.DataSource = dsPaged;
        rptResult.DataBind();

        cmbPage.Items.Clear();
        cmbPage2.Items.Clear();
        if (dsPaged.DataSourceCount > 0)
        {
            pnlResult.Visible = true;
            for (int j = 1; j <= dsPaged.PageCount; j++)
            {
                cmbPage.Items.Add(new ListItem(j.ToString(), Convert.ToString(j - 1)));
                cmbPage2.Items.Add(new ListItem(j.ToString(), Convert.ToString(j - 1)));
            }
            cmbPage.SelectedIndex = dsPaged.CurrentPageIndex;
            cmbPage2.SelectedIndex = dsPaged.CurrentPageIndex;
            lblTotalPage.Text = "/" + dsPaged.PageCount;
            lblTotalPage2.Text = "/" + dsPaged.PageCount;
        }
        else
        {
            pnlResult.Visible = false;
        }

        #endregion

        tbRegister.Visible = (rptResult.Items.Count == 0 ? false : true);
    }

    private bool UpdateRegister()
    {
        bool ret = true;
        string error = VerifyData();
        if (error != "")
        {
            SetErrorStatus(error);
            return false;
        }

        DataTable dtt = new DataTable(); 

        for (int i = 0; i < rptResult.Items.Count; i++)
        {
            App_Prepare_Transaction_ChangeOrder_ChangeorderCtl ctlChangOrder = (App_Prepare_Transaction_ChangeOrder_ChangeorderCtl)rptResult.Items[i].FindControl("ctlChangOrder");
            dtt = ctlChangOrder.GetLoidNewList;
        }

        ChangeOrderFlow cFlow = new ChangeOrderFlow();
        ret = cFlow.UpdateRegister(cmbMeal.SelectedItem.Value.ToString(), ctlRegDate.DateValue.ToString(), Appz.CurrentUser, dtt);
        if (ret)
        {
            SetErrorStatus("บันทึกข้อมูลเรียบร้อยแล้ว");
        }
        else
        {
            SetErrorStatus(cFlow.ErrorMessage);
        }
        return ret;
    }

    private string VerifyData()
    {
        string ret = "";
        if (this.cmbMeal.SelectedItem.Value.ToString() == "0")
            ret = string.Format(DataResources.MSGEI001, "มื้อแรกที่จ่าย");

        return ret;
    }

    #endregion

}
