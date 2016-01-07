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
/// OrderTransferMilk Class
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
///    การจัดส่งนมผผงสำหรับเด็ก
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
public partial class App_Delivery_Transaction_OrderTransferMilk : System.Web.UI.Page
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
        Appz.BuildCombo(this.cmbSearchWard, "V_ORDERMILK_WAIT_TRANSFER", "WARDNAME", "WARDID", "", "WARDNAME", "ทั้งหมด", "0", true);
        Appz.BuildCombo(this.cmbSearchMilkCategory, "V_ORDERMILK_WAIT_TRANSFER", "MILKNAME", "MILKNAME", "", "MILKNAME", "ทั้งหมด", "", true);
        Appz.BuildCombo(this.cmbSearchOwner, "V_ORDERMILK_WAIT_TRANSFER", "OWNERNAME", "OWNER", "", "OWNERNAME", "ทั้งหมด", "", true);
        pcTop.SetMainGridView(gvMain);
        pcBot.SetMainGridView(gvMain);
        ClearSearch();
        
        this.tbPrint.ClientClick = Appz.OpenReportScript(Constant.Reports.TransferOrderMilkListReport, "paramfield1=WARD&paramvalue1=' + document.getElementById('" + this.cmbSearchWard.ClientID + "').value + " +
            "'&paramfield2=MILKNAME&paramvalue2=' + escape(document.getElementById('" + this.cmbSearchMilkCategory.ClientID + "').value) + " +
            "'&paramfield3=PATIENTNAME&paramvalue3=' + escape(trim(document.getElementById('" + this.txtSearchPatientName.ClientID + "').value)) + " +
            "'&paramfield4=HN&paramvalue4=' + " +
            "'&paramfield5=AN&paramvalue5=' + " +
            "'&paramfield6=VN&paramvalue6=' + " +
            "'&paramfield7=ORDERDATECHAR&paramvalue7=' + document.getElementById('" + this.ctlSearchOrderDate.CalendarClientID + "').value + " +
            "'&paramfield8=PREPAREMEAL&paramvalue8=' + trim(document.getElementById('" + this.cmbSearchMeal.ClientID + "').value) + " +
            "'&paramfield9=OWNER&paramvalue9=' + document.getElementById('" + this.cmbSearchOwner.ClientID + "').value + '", false);
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
        this.cmbSearchOwner.SelectedIndex = 0;
        this.cmbSearchMilkCategory.SelectedIndex = 0;
        this.cmbSearchWard.SelectedIndex = 0;
        this.txtSearchPatientName.Text = "";
        this.ctlSearchOrderDate.DateValue = DateTime.Today;
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
            TransferOrderMilkFlow fFlow = new TransferOrderMilkFlow();
            ret = fFlow.UpdateDeliverlyStatus(Appz.CurrentUser, Convert.ToDouble(this.cmbSearchWard.SelectedItem.Value), this.cmbSearchMilkCategory.SelectedItem.Value,
            this.txtSearchPatientName.Text.Trim(), "", "", "",
            this.ctlSearchOrderDate.DateValue, this.cmbSearchMeal.SelectedItem.Value, this.cmbSearchOwner.SelectedItem.Value, "PATIENTNAME, RANK DESC, ORDERNO, MILKNAME, PREPARETIME", GetChecked());
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
        TransferOrderMilkFlow fFlow = new TransferOrderMilkFlow();
        this.imbReset.Visible = (this.cmbSearchMilkCategory.SelectedIndex != 0) || (this.cmbSearchOwner.SelectedIndex != 0) || (this.cmbSearchWard.SelectedIndex != 0) ||
            (this.txtSearchPatientName.Text.Trim() != "") || (this.ctlSearchOrderDate.DateValue.Year != DateTime.Now.Year) || (this.cmbSearchMeal.SelectedIndex != 0);
        DataTable dt = fFlow.GetMasterList(Convert.ToDouble(this.cmbSearchWard.SelectedItem.Value), this.cmbSearchMilkCategory.SelectedItem.Value,
            this.txtSearchPatientName.Text.Trim(), "", "", "",
            this.ctlSearchOrderDate.DateValue, this.cmbSearchMeal.SelectedItem.Value, this.cmbSearchOwner.SelectedItem.Value, "PATIENTNAME, RANK DESC, ORDERNO, MILKNAME, PREPARETIME");
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
                dNewRow["ADMITPATIENT"] = dt.Rows[i]["ADMITPATIENT"];
                dNewRow["AGE"] = dt.Rows[i]["AGE"];
                dNewRow["AN"] = dt.Rows[i]["AN"];
                dNewRow["BEDNO"] = dt.Rows[i]["BEDNO"];
                dNewRow["BIRTHDATE"] = dt.Rows[i]["BIRTHDATE"];
                dNewRow["BMI"] = dt.Rows[i]["BMI"];
                dNewRow["ENDDATE"] = dt.Rows[i]["ENDDATE"];
                dNewRow["ENERGY"] = dt.Rows[i]["ENERGY"];
                dNewRow["FIRSTDATE"] = dt.Rows[i]["FIRSTDATE"];
                dNewRow["HEIGHT"] = dt.Rows[i]["HEIGHT"];
                dNewRow["HN"] = dt.Rows[i]["HN"];
                dNewRow["ISREGISTER"] = dt.Rows[i]["ISREGISTER"];
                dNewRow["ISTRANSFER"] = dt.Rows[i]["ISTRANSFER"];
                dNewRow["LOID"] = dt.Rows[i]["LOID"];
                dNewRow["MEALNAME"] = dt.Rows[i]["MEALNAME"];
                dNewRow["MEALQTY"] = dt.Rows[i]["MEALQTY"];
                dNewRow["MILKCATEGORY"] = dt.Rows[i]["MILKCATEGORY"];
                dNewRow["MILKCODE"] = dt.Rows[i]["MILKCODE"];
                dNewRow["MILKCODEID"] = dt.Rows[i]["MILKCODEID"];
                dNewRow["MILKNAME"] = dt.Rows[i]["MILKNAME"];
                dNewRow["ORDERDATE"] = dt.Rows[i]["ORDERDATE"];
                dNewRow["ORDERMILK"] = dt.Rows[i]["ORDERMILK"];
                dNewRow["ORDERNO"] = dt.Rows[i]["ORDERNO"];
                dNewRow["OWNER"] = dt.Rows[i]["OWNER"];
                dNewRow["OWNERNAME"] = dt.Rows[i]["OWNERNAME"];
                dNewRow["OWNERTEXT"] = dt.Rows[i]["OWNERTEXT"];
                dNewRow["PATIENTNAME"] = dt.Rows[i]["PATIENTNAME"];
                dNewRow["PREPAREMEAL"] = dt.Rows[i]["PREPAREMEAL"];
                dNewRow["PREPARETIME"] = dt.Rows[i]["PREPARETIME"];
                dNewRow["PRINTTIME"] = dt.Rows[i]["PRINTTIME"];
                dNewRow["REGISTERDATE"] = dt.Rows[i]["REGISTERDATE"];
                dNewRow["ROOMNO"] = dt.Rows[i]["ROOMNO"];
                dNewRow["STATUS"] = dt.Rows[i]["STATUS"];
                dNewRow["STATUSNAME"] = dt.Rows[i]["STATUSNAME"];
                dNewRow["VN"] = dt.Rows[i]["VN"];
                dNewRow["VOLUMN"] = dt.Rows[i]["VOLUMN"];
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
