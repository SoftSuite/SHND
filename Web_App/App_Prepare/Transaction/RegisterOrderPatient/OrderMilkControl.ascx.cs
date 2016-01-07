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

public partial class App_Prepare_Transaction_RegisterOrderPatient_OrderMilkControl : System.Web.UI.UserControl
{
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
        Appz.BuildCombo(this.cmbSearchMilkCategory, "MILKCATEGORY", "NAME", "LOID", "ACTIVE='1'", "NAME", "ทั้งหมด", "0", false);
        //Appz.BuildCombo(this.cmbSearchWard, "WARD", "NAME", "LOID", "ACTIVE='1' AND LOID IN (SELECT WARDID FROM V_ORDERMILK_WAIT_REGISTER WHERE STATUS = 'FN')", "NAME", "ทั้งหมด", "0", false);
        //Appz.BuildCombo(this.cmbSearchMilkCategory, "MILKCATEGORY", "NAME", "LOID", "ACTIVE='1' AND LOID IN (SELECT MILKCATEGORY FROM ORDERMILK WHERE STATUS = 'FN')", "NAME", "ทั้งหมด", "0", false);
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

    #endregion

    #region GridView Event Handler

    protected void gvMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            CheckBox chk = (CheckBox)e.Row.Cells[1].FindControl("chkMain");
            chk.Attributes.Add("onclick", "chkAllBox1(this, '" + this.gvMain.ClientID + "_ctl', '_chkSelect', '_cmbMilkCode')");
        }
        else if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList cmbMilkCode = (DropDownList)e.Row.Cells[1].FindControl("cmbMilkCode");
            cmbMilkCode.Enabled = false;
            Appz.BuildCombo(cmbMilkCode, "MILKCODE", "MILKCODE", "LOID", "WARD=" + e.Row.Cells[2].Text, "MILKCODE", "เลือก", "0", false);
            ((CheckBox)e.Row.Cells[1].FindControl("chkSelect")).Attributes.Add("onClick", "document.getElementById('" + cmbMilkCode.ClientID + "').disabled = (this.checked ? '' : 'disabled'); if (!this.checked) document.getElementById('" + cmbMilkCode.ClientID + "').value=0;");
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
            if (i > -1 && gvMain.Rows[i].Cells[1].FindControl("chkSelect") != null)
            {
                ((DropDownList)gvMain.Rows[i].Cells[1].FindControl("cmbMilkCode")).Enabled = ((CheckBox)gvMain.Rows[i].Cells[1].FindControl("chkSelect")).Checked;
                if (((CheckBox)gvMain.Rows[i].Cells[1].FindControl("chkSelect")).Checked)
                    arrChk.Add(gvMain.Rows[i].Cells[0].Text + "#" + ((DropDownList)gvMain.Rows[i].Cells[1].FindControl("cmbMilkCode")).SelectedItem.Value);
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
        this.cmbSearchMilkCategory.SelectedIndex = 0;
        this.cmbSearchWard.SelectedIndex = 0;
        this.txtSearchPatientName.Text = "";
        this.ctlSearchOrderDate.DateValue = new DateTime();
        this.txtSearchTimeFrom.Text = "";
        this.txtSearchTimeTo.Text = "";
    }

    private void SetStatus(string t, bool isError)
    {
        this.lbStatus.Text = t;
        this.lbStatus.ForeColor = (isError ? Constant.StatusColor.Error : Constant.StatusColor.Information);
    }

    private void SetRegisterStatus(string t, bool isError)
    {
        this.lbRegisterStatus.Text = t;
        this.lbRegisterStatus.ForeColor = (isError ? Constant.StatusColor.Error : Constant.StatusColor.Information);
    }

    #endregion

    #region Working Methods

    private void Register()
    {
        bool ret = true;
        ArrayList arrData = GetChecked();
        if (arrData.Count > 0)
        {
            for (int i=0; i<arrData.Count; ++i)
            {
                if (arrData[i].ToString().Split('#')[1] == "0")
                {
                    ret = false;
                    SetStatus(string.Format(DataResources.MSGEI002, "เบอร์นม"), true);
                    break;
                }
            }
            if (ret)
            {
                this.cmbFirstMealRegister.SelectedIndex = 0;
                this.ctlFirstDateRegister.DateValue = DateTime.Today;
                this.mpeRegister.Show();
            }
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
            RegisterOrderMilkFlow fFlow = new RegisterOrderMilkFlow();
            ret = fFlow.Register(GetChecked(), this.cmbFirstMealRegister.SelectedItem.Value, this.ctlFirstDateRegister.DateValue, Appz.CurrentUser);
            if (!ret) SetRegisterStatus(fFlow.ErrorMessage, true);
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
        RegisterOrderMilkFlow fFlow = new RegisterOrderMilkFlow();
        this.imbReset.Visible = (this.ctlSearchDate.DateValue != DateTime.Today) || (this.cmbSearchMilkCategory.SelectedIndex != 0) || (this.cmbSearchWard.SelectedIndex != 0) ||
            (this.txtSearchPatientName.Text.Trim() != "") || (this.ctlSearchOrderDate.DateValue.Year != 1) || (this.txtSearchTimeFrom.Text.Trim() != "") || (this.txtSearchTimeTo.Text.Trim() != "");
        DataTable dt;
        dt = fFlow.GetRegisterList(this.ctlSearchDate.DateValue, Convert.ToDouble(this.cmbSearchWard.SelectedItem.Value), Convert.ToDouble(this.cmbSearchMilkCategory.SelectedItem.Value),
            this.txtSearchPatientName.Text.Trim(), orderDateFrom, orderDateTo, "PATIENTNAME, RANK DESC, ORDERMILK");
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
                dNewRow["LOID"] = dt.Rows[i]["LOID"];
                dNewRow["ORDERMILK"] = dt.Rows[i]["ORDERMILK"];
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
                dNewRow["WARDID"] = dt.Rows[i]["WARDID"];
                dNewRow["WARDNAME"] = dt.Rows[i]["WARDNAME"];
                dNewRow["ROOMNO"] = dt.Rows[i]["ROOMNO"];
                dNewRow["BEDNO"] = dt.Rows[i]["BEDNO"];
                dNewRow["ORDERNO"] = dt.Rows[i]["ORDERNO"];
                dNewRow["MILKNAME"] = dt.Rows[i]["MILKNAME"];
                dNewRow["ENERGY"] = dt.Rows[i]["ENERGY"];
                dNewRow["MEALQTY"] = dt.Rows[i]["MEALQTY"];
                dNewRow["VOLUMN"] = dt.Rows[i]["VOLUMN"];
                dNewRow["MILKCATEGORY"] = dt.Rows[i]["MILKCATEGORY"];
                dNewRow["ORDERDATE"] = dt.Rows[i]["ORDERDATE"];
                dNewRow["REGISTERDATE"] = dt.Rows[i]["REGISTERDATE"];
                dNewRow["MILKCODEID"] = dt.Rows[i]["MILKCODEID"];
                dNewRow["MILKCODE"] = dt.Rows[i]["MILKCODE"];
                dNewRow["FIRSTDATE"] = dt.Rows[i]["FIRSTDATE"];
                dNewRow["ENDDATE"] = dt.Rows[i]["ENDDATE"];
                dNewRow["OWNER"] = dt.Rows[i]["OWNER"];
                dNewRow["OWNERTEXT"] = dt.Rows[i]["OWNERTEXT"];
                dNewRow["STATUS"] = dt.Rows[i]["STATUS"];
                dNewRow["STATUSNAME"] = dt.Rows[i]["STATUSNAME"];
                dNewRow["ISREGISTER"] = dt.Rows[i]["ISREGISTER"];
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
