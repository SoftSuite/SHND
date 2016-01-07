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
using SHND.Flow.Deliverly;
using SHND.Global;

/// <summary>
/// OrderTransferFeed Class
/// Version 1.0
/// =========================================================================
/// Create by: Teang
/// Create Date: 21 Apr 2009
/// -------------------------------------------------------------------------
/// Modify By: Nang
/// Modify From: -
/// Modify Date: 15 July 2009
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    การจัดส่งอาหารทางสาย
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
public partial class App_Delivery_Transaction_OrderTransferFeed : System.Web.UI.Page
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
        Appz.BuildCombo(this.cmbSearchWard, "V_ORDERFEED_WAIT_TRANSFER", "WARDNAME", "WARD", "", "WARDNAME", "ทั้งหมด", "0", true);
        Appz.BuildCombo(this.cmbSearchFoodType, "V_ORDERFEED_WAIT_TRANSFER", "FOODTYPENAME", "FOODTYPE", "FOODTYPE IS NOT NULL", "FOODTYPENAME", "ทั้งหมด", "0", true);
        Appz.BuildCombo(this.cmbSearchFoodName, "V_ORDERFEED_WAIT_TRANSFER", "FOODNAME", "FOODNAME", "FOODNAME IS NOT NULL", "FOODNAME", "ทั้งหมด", "", true);
        pcTop.SetMainGridView(gvMain);
        pcBot.SetMainGridView(gvMain);
        ClearSearch();
        this.tbPrint.ClientClick = Appz.OpenReportScript(Constant.Reports.TransferOrderFeedListReport, "paramfield1=WARD&paramvalue1=' + document.getElementById('" + this.cmbSearchWard.ClientID + "').value + " +
            "'&paramfield2=FOODTYPE&paramvalue2=' + document.getElementById('" + this.cmbSearchFoodType.ClientID + "').value + " +
            "'&paramfield3=FOODNAME&paramvalue3=' + escape(document.getElementById('" + this.cmbSearchFoodName.ClientID + "').value) + " +
            "'&paramfield4=PATIENTNAME&paramvalue4=' + escape(trim(document.getElementById('" + this.txtSearchPatientName.ClientID + "').value)) + " +
            "'&paramfield5=HN&paramvalue5=' + trim(document.getElementById('" + this.txtSearchHN.ClientID + "').value) + " +
            "'&paramfield6=AN&paramvalue6=' + trim(document.getElementById('" + this.txtSearchAN.ClientID + "').value) + " +
            "'&paramfield7=VN&paramvalue7=' + trim(document.getElementById('" + this.txtSearchVN.ClientID + "').value) + " +
            "'&paramfield8=PRINTCHAR&paramvalue8=' + document.getElementById('" + this.ctlSearchPrintTime.CalendarClientID + "').value + " +
            "'&paramfield9=PREPAREMEAL&paramvalue9=' + trim(document.getElementById('" + this.cmbSearchMeal.ClientID + "').value) + '", false);
    }

    #region Button Click Event Handler

    protected void tbSaveClick(object sender, EventArgs e)
    {
        if (UpdateDeliverlyStatus())
            doGetList(0);
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

    #endregion

    #region GridView Event Handler

    protected void gvMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            CheckBox chk = (CheckBox)e.Row.Cells[1].FindControl("chkMain");
            chk.Attributes.Add("onclick", "chkAllBox(this, '" + this.gvMain.ClientID + "_ctl', '_chkSelect')");
        }
    }

    #endregion

    #region Paging Event Handler
    protected void PageChange(object sender, EventArgs e)
    {
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
                if (((CheckBox)gvMain.Rows[i].Cells[1].FindControl("chkSelect")).Checked && ((CheckBox)gvMain.Rows[i].Cells[1].FindControl("chkSelect")).CssClass == "")
                    arrChk.Add(gvMain.Rows[i].Cells[0].Text);
            }
        }

        return arrChk;
    }
    #endregion

    #region Controls Management Methods

    private void ClearSearch()
    {
        // Clear searh data
        this.cmbSearchFoodType.SelectedIndex = 0;
        this.cmbSearchFoodName.SelectedIndex = 0;
        this.cmbSearchWard.SelectedIndex = 0;
        this.txtSearchPatientName.Text = "";
        this.txtSearchAN.Text = "";
        this.txtSearchHN.Text = "";
        this.txtSearchVN.Text = "";
        this.ctlSearchPrintTime.DateValue = DateTime.Today;
        this.cmbSearchMeal.SelectedIndex = 0;
    }

    private void SetStatus(string t, bool isError)
    {
        this.lbStatus.Text = t;
        this.lbStatus.ForeColor = (isError ? Constant.StatusColor.Error : Constant.StatusColor.Information);
    }

    #endregion

    #region Working Methods

    private bool UpdateDeliverlyStatus()
    {
        bool ret = true;
        string error = "";
        if (GetChecked().Count == 0)
            error = string.Format(DataResources.MSGEI002, "รายการสั่งอาหาร");

        if (error != "")
        {
            SetStatus(error, true);
            ret = false;
        }
        else
        {
            TransferOrderFeedFlow fFlow = new TransferOrderFeedFlow();
            ret = fFlow.UpdateDeliverlyStatus(Appz.CurrentUser, Convert.ToDouble(this.cmbSearchWard.SelectedItem.Value), Convert.ToDouble(this.cmbSearchFoodType.SelectedItem.Value),
            this.cmbSearchFoodName.SelectedItem.Value, this.txtSearchPatientName.Text.Trim(), this.txtSearchHN.Text.Trim(), this.txtSearchAN.Text.Trim(), this.txtSearchVN.Text.Trim(),
            this.ctlSearchPrintTime.DateValue, this.cmbSearchMeal.SelectedItem.Value, "PATIENTNAME, RANK DESC, FOODNAME, FOODTYPENAME, PREPARETIME", GetChecked());
            if (!ret) SetStatus(fFlow.ErrorMessage, true);
        }
        return ret;
    }

    private void doGetList(int curPage)
    {
        int pageSize = 20;
        int count = 0;
        int rank = 0;
        int total = 0;
        TransferOrderFeedFlow fFlow = new TransferOrderFeedFlow();
        this.imbReset.Visible = (this.cmbSearchFoodName.SelectedIndex != 0) || (this.cmbSearchFoodType.SelectedIndex != 0) || (this.cmbSearchWard.SelectedIndex != 0) ||
            (this.txtSearchPatientName.Text.Trim() != "") || (this.txtSearchAN.Text.Trim() != "") || (this.txtSearchHN.Text.Trim() != "") || (this.txtSearchVN.Text.Trim() != "") ||
            (this.ctlSearchPrintTime.DateValue.Year != DateTime.Now.Year) || (this.cmbSearchMeal.SelectedIndex != 0);
        DataTable dt = fFlow.GetMasterList(Convert.ToDouble(this.cmbSearchWard.SelectedItem.Value), Convert.ToDouble(this.cmbSearchFoodType.SelectedItem.Value),
            this.cmbSearchFoodName.SelectedItem.Value, this.txtSearchPatientName.Text.Trim(), this.txtSearchHN.Text.Trim(), this.txtSearchAN.Text.Trim(), this.txtSearchVN.Text.Trim(),
            this.ctlSearchPrintTime.DateValue, this.cmbSearchMeal.SelectedItem.Value, "PATIENTNAME, RANK DESC, FOODNAME, FOODTYPENAME, PREPARETIME");
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
                dNewRow["ABSTAIN"] = dt.Rows[i]["ABSTAIN"];
                dNewRow["ADMITPATIENT"] = dt.Rows[i]["ADMITPATIENT"];
                dNewRow["AGE"] = dt.Rows[i]["AGE"];
                dNewRow["AN"] = dt.Rows[i]["AN"];
                dNewRow["BEDNO"] = dt.Rows[i]["BEDNO"];
                dNewRow["BIRTHDATE"] = dt.Rows[i]["BIRTHDATE"];
                dNewRow["BMI"] = dt.Rows[i]["BMI"];
                dNewRow["CONTROL"] = dt.Rows[i]["CONTROL"];
                dNewRow["DESCRIPTIONS"] = dt.Rows[i]["DESCRIPTIONS"];
                dNewRow["FEEDCATEGORY"] = dt.Rows[i]["FEEDCATEGORY"];
                dNewRow["FEEDCATEGORYNAME"] = dt.Rows[i]["FEEDCATEGORYNAME"];
                dNewRow["FEEDNAME"] = dt.Rows[i]["FEEDNAME"];
                dNewRow["FOODCATEGORYID"] = dt.Rows[i]["FOODCATEGORYID"];
                dNewRow["FOODCATEGORYNAME"] = dt.Rows[i]["FOODCATEGORYNAME"];
                dNewRow["FOODNAME"] = dt.Rows[i]["FOODNAME"];
                dNewRow["FOODTYPE"] = dt.Rows[i]["FOODTYPE"];
                dNewRow["FOODTYPEID"] = dt.Rows[i]["FOODTYPEID"];
                dNewRow["FOODTYPENAME"] = dt.Rows[i]["FOODTYPENAME"];
                dNewRow["FORMULAFEDDNAME"] = dt.Rows[i]["FORMULAFEDDNAME"];
                dNewRow["HEIGHT"] = dt.Rows[i]["HEIGHT"];
                dNewRow["HN"] = dt.Rows[i]["HN"];
                dNewRow["INCREASE"] = dt.Rows[i]["INCREASE"];
                dNewRow["ISTRANSFER"] = dt.Rows[i]["ISTRANSFER"];
                dNewRow["LIMIT"] = dt.Rows[i]["LIMIT"];
                dNewRow["LOID"] = dt.Rows[i]["LOID"];
                dNewRow["MATERIALNAME"] = dt.Rows[i]["MATERIALNAME"];
                dNewRow["MEALNAME"] = dt.Rows[i]["MEALNAME"];
                dNewRow["MEDENDDATE"] = dt.Rows[i]["MEDENDDATE"];
                dNewRow["MEDFIRSTDATE"] = dt.Rows[i]["MEDFIRSTDATE"];
                dNewRow["MEDISREGISTER"] = dt.Rows[i]["MEDISREGISTER"];
                dNewRow["MEDORDERDATE"] = dt.Rows[i]["MEDORDERDATE"];
                dNewRow["MEDSTATUS"] = dt.Rows[i]["MEDSTATUS"];
                dNewRow["NEED"] = dt.Rows[i]["NEED"];
                dNewRow["NONENDDATE"] = dt.Rows[i]["NONENDDATE"];
                dNewRow["NONFIRSTDATE"] = dt.Rows[i]["NONFIRSTDATE"];
                dNewRow["NONISREGISTER"] = dt.Rows[i]["NONISREGISTER"];
                dNewRow["NONORDERDATE"] = dt.Rows[i]["NONORDERDATE"];
                dNewRow["NONSTATUS"] = dt.Rows[i]["NONSTATUS"];
                dNewRow["ORDERDATE"] = dt.Rows[i]["ORDERDATE"];
                dNewRow["ORDERMEDICALFEED"] = dt.Rows[i]["ORDERMEDICALFEED"];
                dNewRow["ORDERMEDICALFEEDID"] = dt.Rows[i]["ORDERMEDICALFEEDID"];
                dNewRow["ORDERMEDICCALFEEDID"] = dt.Rows[i]["ORDERMEDICCALFEEDID"];
                dNewRow["ORDERNONMEDICAL"] = dt.Rows[i]["ORDERNONMEDICAL"];
                dNewRow["ORDERNONMEDICALID"] = dt.Rows[i]["ORDERNONMEDICALID"];
                dNewRow["PATIENTNAME"] = dt.Rows[i]["PATIENTNAME"];
                dNewRow["PREPAREMEAL"] = dt.Rows[i]["PREPAREMEAL"];
                dNewRow["PREPARETIME"] = dt.Rows[i]["PREPARETIME"];
                dNewRow["PRINTTIME"] = dt.Rows[i]["PRINTTIME"];
                dNewRow["QTY"] = dt.Rows[i]["QTY"];
                dNewRow["REGISTERDATE"] = dt.Rows[i]["REGISTERDATE"];
                dNewRow["REMARKS"] = dt.Rows[i]["REMARKS"];
                dNewRow["ROOMNO"] = dt.Rows[i]["ROOMNO"];
                dNewRow["STATUS"] = dt.Rows[i]["STATUS"];
                dNewRow["STATUSNAME"] = dt.Rows[i]["STATUSNAME"];
                dNewRow["VN"] = dt.Rows[i]["VN"];
                dNewRow["WARD"] = dt.Rows[i]["WARD"];
                dNewRow["WARDID"] = dt.Rows[i]["WARDID"];
                dNewRow["WARDNAME"] = dt.Rows[i]["WARDNAME"];
                dNewRow["WEIGHT"] = dt.Rows[i]["WEIGHT"];
                dNewRow["DELIVERYTIME"] = dt.Rows[i]["DELIVERYTIME"];
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
