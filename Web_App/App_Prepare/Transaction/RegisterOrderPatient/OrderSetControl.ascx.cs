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
using SHND.Flow.Prepare;
using SHND.Global;

public partial class App_Prepare_Transaction_RegisterOrderPatient_OrderSetControl : System.Web.UI.UserControl
{
    public bool RegisterVisible
    {
        set
        {
            this.tbRegister.Visible = value;
        }
    }
    public bool UnRegisterVisible
    {
        set
        {
            this.tbUnRegister.Visible = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            doGetList(0);
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        Appz.BuildCombo(this.cmbSearchWard, "WARD", "NAME", "LOID", "ACTIVE='1'", "NAME", "ทั้งหมด", "0", false);
        Appz.BuildCombo(this.cmbSearchFoodType, "FOODTYPE", "NAME", "LOID", "ACTIVE='1'", "NAME", "ทั้งหมด", "0", false);
        Appz.BuildCombo(this.cmbSearchFoodCategory, "FOODCATEGORY", "NAME", "LOID", "ACTIVE='1' AND LOID NOT IN(FN_GETCONFIGVALUEBYNAME('LIQUIDLOID'),FN_GETCONFIGVALUEBYNAME('MILKLOID'))", "NAME", "ทั้งหมด", "0", false);

        //Appz.BuildCombo(this.cmbSearchWard, "WARD", "NAME", "LOID", "ACTIVE='1' AND LOID IN (SELECT WARD FROM V_ORDER_WAIT_REGISTER WHERE STATUS = '" + (this.tbRegister.Visible ? "FN" : "WA") + "')", "NAME", "ทั้งหมด", "0", false);
        //Appz.BuildCombo(this.cmbSearchFoodType, "FOODTYPE", "NAME", "LOID", "ACTIVE='1' AND LOID IN (SELECT FOODTYPE FROM V_ORDER_WAIT_REGISTER WHERE STATUS = '" + (this.tbRegister.Visible ? "FN" : "WA") + "')", "NAME", "ทั้งหมด", "0", false);
        //Appz.BuildCombo(this.cmbSearchFoodCategory, "FOODCATEGORY", "NAME", "LOID", "ACTIVE='1' AND LOID IN (SELECT FOODCATEGORY FROM V_ORDER_WAIT_REGISTER WHERE STATUS = '" + (this.tbRegister.Visible ? "FN" : "WA") + "')", "NAME", "ทั้งหมด", "0", false);

        this.imbSearch.OnClientClick = "if (document.getElementById('" + this.ctlSearchDate.CalendarClientID + "').value == '') { alert('" + string.Format(DataResources.MSGEI002, "วันที่สั่งอาหาร") + "'); return false; } " +
            "else if (document.getElementById('" + this.txtSearchTimeFrom.ClientID + "').value != '') " +
            "{" +
            "if (parseFloat(document.getElementById('" + this.txtSearchTimeFrom.ClientID + "').value.split(':')[0]) >= 24 || parseFloat(document.getElementById('" + this.txtSearchTimeFrom.ClientID + "').value.split(':')[1]) > 59) " +
            "{ alert('รุปแบเวลาไม่ถูกต้อง (จำนวนชั่วโมงต้องน้อยกว่า 24 และนาทีต้องไม่เกิน 59)'); document.getElementById('" + this.txtSearchTimeFrom.ClientID + "').focus(); return false; } " +
            "} " +
            "if (document.getElementById('" + this.txtSearchTimeTo.ClientID + "').value != '') " +
            "{" +
            "if (parseFloat(document.getElementById('" + this.txtSearchTimeTo.ClientID + "').value.split(':')[0]) >= 24 || parseFloat(document.getElementById('" + this.txtSearchTimeTo.ClientID + "').value.split(':')[1]) > 59) " +
            "{ alert('รุปแบเวลาไม่ถูกต้อง (จำนวนชั่วโมงต้องน้อยกว่า 24 และนาทีต้องไม่เกิน 59)'); document.getElementById('" + this.txtSearchTimeTo.ClientID + "').focus(); return false; } " +
            "}";
        pcTop.SetMainGridView(gvMain);
        pcBot.SetMainGridView(gvMain);
        ClearSearch();
    }

    #region Button Click Event Handler

    protected void tbRegister_Click(object sender, EventArgs e)
    {
        Register();
    }

    protected void tbUnRegister_Click(object sender, EventArgs e)
    {
        NonRegister();
    }

    protected void imbSearch_Click(object sender, ImageClickEventArgs e)
    {
        doGetList(0);
    }

    protected void imbReset_Click(object sender, ImageClickEventArgs e)
    {
        ClearSearch();
        doGetList(0);
    }

    protected void tbSaveRegister_Click(object sender, EventArgs e)
    {
        if (!SaveRegister())
            this.mpeRegister.Show();
        else
            doGetList(0);
    }

    protected void tbSaveNonRegister_Click(object sender, EventArgs e)
    {
        if (!SaveNonRegister())
            this.mpeNonRegister.Show();
        else
            doGetList(0);
    }

    #endregion

    #region GridView Event Handler

    protected void gvMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            CheckBox chk = (CheckBox)e.Row.Cells[2].FindControl("chkMain");
            chk.Attributes.Add("onclick", "chkAllBox(this, '" + this.gvMain.ClientID + "_ctl', '_chkSelect')");
        }
    }

    #endregion

    #region Paging Event Handler
    protected void PageChange(object sender, EventArgs e)
    {
        //gvMain.PageIndex = ((Templates_PageControl)sender).SelectedPageIndex;
        doGetList(((Templates_PageControl)sender).SelectedPageIndex);
    }
    #endregion

    #region Misc. Methods
    private ArrayList GetChecked()
    {
        ArrayList arrChk = new ArrayList();
        for (int i = 0; i < gvMain.Rows.Count; i++)
        {
            if (i > -1 && gvMain.Rows[i].Cells[2].FindControl("chkSelect") != null)
            {
                if (((CheckBox)gvMain.Rows[i].Cells[2].FindControl("chkSelect")).Checked)
                    arrChk.Add(gvMain.Rows[i].Cells[0].Text + "#" + gvMain.Rows[i].Cells[1].Text);
            }
        }

        return arrChk;
    }
    #endregion

    #region Controls Management Methods

    private void ClearSearch()
    {
        // Clear searh data
        this.ctlSearchDate.DateValue = DateTime.Today;
        this.cmbSearchFoodType.SelectedIndex = 0;
        this.cmbSearchFoodCategory.SelectedIndex = 0;
        this.cmbSearchWard.SelectedIndex = 0;
        this.txtSearchPatientName.Text = "";
        this.ctlSearchOrderDate.DateValue = new DateTime();
        this.txtSearchTimeFrom.Text = "";
        this.txtSearchTimeTo.Text = "";
    }

    private void SetRegisterStatus(string t, bool isError)
    {
        this.lbRegisterStatus.Text = t;
        this.lbRegisterStatus.ForeColor = (isError ? Constant.StatusColor.Error : Constant.StatusColor.Information);
    }

    private void SetNonRegisterStatus(string t, bool isError)
    {
        this.lbNonRegisterStatus.Text = t;
        this.lbNonRegisterStatus.ForeColor = (isError ? Constant.StatusColor.Error : Constant.StatusColor.Information);
    }
    
    #endregion

    #region "Working Methods"

    private void Register()
    {
        if (GetChecked().Count > 0)
        {
            this.cmbFirstMealRegister.SelectedIndex = 0;
            this.ctlFirstDateRegister.DateValue = DateTime.Today;
            this.mpeRegister.Show();
        }
    }

    private void NonRegister()
    {
        if (GetChecked().Count > 0)
        {
            this.txtReason.Text = "รายการสั่งอาหารไม่สมบูรณ์ ไม่สามารถให้บริการได้";
            this.mpeNonRegister.Show();
        }
    }

    private bool SaveRegister()
    {
        bool ret = true;
        string error = "";
        if (this.cmbFirstMealRegister.SelectedItem.Value == "")
            error = string.Format(DataResources.MSGEI002, "มื้อแรกที่จ่าย");
        else if (this.ctlFirstDateRegister.DateValue.Year == 1)
            error = string.Format(DataResources.MSGEI002, "วันที่ Register");

        if (error != "")
        {
            SetRegisterStatus(error, true);
            ret = false;
        }
        else
        {
            RegisterOrderSetFlow fFlow = new RegisterOrderSetFlow();
            ret = fFlow.Register(GetChecked(), this.cmbFirstMealRegister.SelectedItem.Value, this.ctlFirstDateRegister.DateValue, Appz.CurrentUser);
            if (!ret) SetRegisterStatus(fFlow.ErrorMessage, true);
        }
        return ret;
    }

    private bool SaveNonRegister()
    {
        bool ret = true;
        string error = "";
        if (this.txtReason.Text.Trim() == "")
            error = string.Format(DataResources.MSGEI001, "เหตุผล");

        if (error != "")
        {
            SetNonRegisterStatus(error, true);
            ret = false;
        }
        else
        {
            RegisterOrderSetFlow fFlow = new RegisterOrderSetFlow();
            ret = fFlow.NonRegister(GetChecked(), this.txtReason.Text.Trim(), Appz.CurrentUser);
            if (!ret) SetNonRegisterStatus(fFlow.ErrorMessage, true);
        }
        return ret;
    }

    private void doGetList(int curPage)
    {
        DateTime orderDateFrom = this.ctlSearchOrderDate.DateValue;
        DateTime orderDateTo = this.ctlSearchOrderDate.DateValue;
        if (orderDateFrom.Year != 1 && this.txtSearchTimeFrom.Text.Trim() != "")
            orderDateFrom = new DateTime(orderDateFrom.Year, orderDateFrom.Month, orderDateFrom.Day, Convert.ToInt32(this.txtSearchTimeFrom.Text.Substring(0, 2)), Convert.ToInt32(this.txtSearchTimeFrom.Text.Substring(3, 2)), 0);
        if (orderDateTo.Year != 1 && this.txtSearchTimeTo.Text.Trim() != "")
            orderDateTo = new DateTime(orderDateTo.Year, orderDateTo.Month, orderDateTo.Day, Convert.ToInt32(this.txtSearchTimeTo.Text.Substring(0, 2)), Convert.ToInt32(this.txtSearchTimeTo.Text.Substring(3, 2)), 0);
        int pageSize = 20;
        int count = 0;
        int rank = 0;
        int total = 0;
        RegisterOrderSetFlow fFlow = new RegisterOrderSetFlow();
        this.imbReset.Visible = (this.ctlSearchDate.DateValue != DateTime.Today) || (this.cmbSearchFoodCategory.SelectedIndex != 0) || (this.cmbSearchFoodType.SelectedIndex != 0) || (this.cmbSearchWard.SelectedIndex != 0) ||
            (this.txtSearchPatientName.Text.Trim() != "") || (this.ctlSearchOrderDate.DateValue.Year != 1) || (this.txtSearchTimeFrom.Text.Trim() != "") || (this.txtSearchTimeTo.Text.Trim() != "");
        DataTable dt;
        if (this.tbRegister.Visible)
        {
            dt = fFlow.GetRegisterList(this.ctlSearchDate.DateValue, Convert.ToDouble(this.cmbSearchWard.SelectedItem.Value), Convert.ToDouble(this.cmbSearchFoodType.SelectedItem.Value),
                Convert.ToDouble(this.cmbSearchFoodCategory.SelectedItem.Value), this.txtSearchPatientName.Text.Trim(), orderDateFrom, orderDateTo, "PATIENTNAME, RANK DESC, ORDERMEDICALSET, ORDERNONMEDICAL");
        }
        else
        {
            dt = fFlow.GetNonRegisterList(this.ctlSearchDate.DateValue, Convert.ToDouble(this.cmbSearchWard.SelectedItem.Value), Convert.ToDouble(this.cmbSearchFoodType.SelectedItem.Value),
                Convert.ToDouble(this.cmbSearchFoodCategory.SelectedItem.Value), this.txtSearchPatientName.Text.Trim(), orderDateFrom, orderDateTo, "PATIENTNAME, RANK DESC, ORDERMEDICALSET, ORDERNONMEDICAL");
        }
        DataTable dtNew = dt.Clone();
        DataRow dNewRow;
        for (int i = 0; i < dt.Rows.Count; ++i)
        {
            if (Convert.ToInt32(dt.Rows[i]["RANK"]) != rank && Convert.ToInt32(dt.Rows[i]["RANK"]) != 0)
            {
                rank = Convert.ToInt32(dt.Rows[i]["RANK"]);
                if (rank >= (curPage * pageSize) + 1 && rank <= (curPage * pageSize) + pageSize) ++count;
            }
            if (rank != total) total = rank;
            if (rank >= (curPage * pageSize) + 1 && rank <= (curPage * pageSize) + pageSize)
            {
                dNewRow = dtNew.NewRow();
                dNewRow["RANK"] = dt.Rows[i]["RANK"];
                dNewRow["ORDERMEDICALSET"] = dt.Rows[i]["ORDERMEDICALSET"];
                dNewRow["ORDERNONMEDICAL"] = dt.Rows[i]["ORDERNONMEDICAL"];
                dNewRow["ADMITPATIENT"] = dt.Rows[i]["ADMITPATIENT"];
                dNewRow["HN"] = dt.Rows[i]["HN"];
                dNewRow["VN"] = dt.Rows[i]["VN"];
                dNewRow["AN"] = dt.Rows[i]["AN"];
                dNewRow["PATIENTNAME"] = dt.Rows[i]["PATIENTNAME"];
                dNewRow["BIRTHDATE"] = dt.Rows[i]["BIRTHDATE"];
                dNewRow["AGE"] = dt.Rows[i]["AGE"];
                dNewRow["WEIGHT"] = dt.Rows[i]["WEIGHT"];
                dNewRow["HEIGHT"] = dt.Rows[i]["HEIGHT"];
                dNewRow["BMI"] = dt.Rows[i]["BMI"];
                dNewRow["WARD"] = dt.Rows[i]["WARD"];
                dNewRow["WARDNAME"] = dt.Rows[i]["WARDNAME"];
                dNewRow["ROOMNO"] = dt.Rows[i]["ROOMNO"];
                dNewRow["BEDNO"] = dt.Rows[i]["BEDNO"];
                dNewRow["FOODCATEGORY"] = dt.Rows[i]["FOODCATEGORY"];
                dNewRow["FOODCATEGORYNAME"] = dt.Rows[i]["FOODCATEGORYNAME"];
                dNewRow["QTY"] = dt.Rows[i]["QTY"];
                dNewRow["MEDFIRSTDATE"] = dt.Rows[i]["MEDFIRSTDATE"];
                dNewRow["MEDENDDATE"] = dt.Rows[i]["MEDENDDATE"];
                dNewRow["MEDSTATUS"] = dt.Rows[i]["MEDSTATUS"];
                dNewRow["FOODTYPE"] = dt.Rows[i]["FOODTYPE"];
                dNewRow["FOODTYPENAME"] = dt.Rows[i]["FOODTYPENAME"];
                dNewRow["NONFIRSTDATE"] = dt.Rows[i]["NONFIRSTDATE"];
                dNewRow["NONENDDATE"] = dt.Rows[i]["NONENDDATE"];
                dNewRow["NONSTATUS"] = dt.Rows[i]["NONSTATUS"];
                dNewRow["CONTROL"] = dt.Rows[i]["CONTROL"];
                dNewRow["LIMIT"] = dt.Rows[i]["LIMIT"];
                dNewRow["INCREASE"] = dt.Rows[i]["INCREASE"];
                dNewRow["ABSTAIN"] = dt.Rows[i]["ABSTAIN"];
                dNewRow["NEED"] = dt.Rows[i]["NEED"];
                dNewRow["REMARKS"] = dt.Rows[i]["REMARKS"];
                dNewRow["ISNPO"] = dt.Rows[i]["ISNPO"];
                dNewRow["MEDORDERDATE"] = dt.Rows[i]["MEDORDERDATE"];
                dNewRow["NONORDERDATE"] = dt.Rows[i]["NONORDERDATE"];
                dNewRow["DESCRIPTIONS"] = dt.Rows[i]["DESCRIPTIONS"];
                dNewRow["STATUS"] = dt.Rows[i]["STATUS"];
                dNewRow["STATUSNAME"] = dt.Rows[i]["STATUSNAME"];
                dtNew.Rows.Add(dNewRow);
            }
        }
        this.gvMain.DataSource = dtNew;
        this.gvMain.DataBind();

        pcTop.Update(curPage, total, pageSize, count);
        pcBot.Update(curPage, total, pageSize, count);
    }

    #endregion

}
