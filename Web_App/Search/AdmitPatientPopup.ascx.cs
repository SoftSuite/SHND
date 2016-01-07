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
using SHND.Data.Search;
using SHND.Data.Views;
using SHND.Flow.Search;
using SHND.Global;

/// <summary>
/// AdmitPatientPopup Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Nang
/// Create Date: 11 May 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้าค้นหา ข้อมูลผู้ป่วย(Admit Patient)
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

public partial class Search_AdmitPatientPopup : System.Web.UI.UserControl
{
    public delegate void SelectedIndexChangedEvent(object sender, EventArgs e, ArrayList SelectedData);
    public event SelectedIndexChangedEvent SelectedIndexChanged;

    public delegate void CancelEvent(object sender, EventArgs e);
    public event CancelEvent Cancel;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        Appz.BuildCombo(cmbWard, "WARD", "NAME", "LOID", "ACTIVE='1'", "NAME", "ทั้งหมด", "0", false);
        pcBot.SetMainGridView(gvMain);
        pcTop.SetMainGridView(gvMain);
    }

    #region Button Click Event Handler

    protected void tbBackClick(object sender, EventArgs e)
    {
        if (Cancel != null) Cancel(sender, e);
    }

    protected void tbAddClick(object sender, EventArgs e)
    {
        if (SelectedIndexChanged != null) SelectedIndexChanged(sender, e, GetSelectedData());
    }

    protected void imbSearch_Click(object sender, ImageClickEventArgs e)
    {
        gvMain.PageIndex = 0;
        doGetList();
        popupAdmitPatient.Show();
    }

    protected void imbReset_Click(object sender, ImageClickEventArgs e)
    {
        ClearSearch();
        gvMain.PageIndex = 0;
        doGetList();
        popupAdmitPatient.Show();
    }

    #endregion

    #region Gridview Event Handler

    protected void gvMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            ((CheckBox)e.Row.Cells[1].FindControl("chkAll")).Attributes.Add("onclick", "chkAllBox(this, '" + this.gvMain.ClientID + "_ctl', '_chkSelect')");
        }
        else if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[2].Text = ((e.Row.RowIndex + 1) + (gvMain.PageIndex * gvMain.PageSize)).ToString();
        }
    }
    protected void gvMain_Sorting(object sender, GridViewSortEventArgs e)
    {
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
        popupAdmitPatient.Show();
    }

    #endregion

    #region Paging Event Handler

    protected void PageChange(object sender, EventArgs e)
    {
        gvMain.PageIndex = ((Templates_PageControl)sender).SelectedPageIndex;
        doGetList();
        pcBot.Update();
        pcTop.Update();
        popupAdmitPatient.Show();
    }

    #endregion

    #region Misc. Methods

    private ArrayList GetSelectedData()
    {
        ArrayList arrChk = new ArrayList();
        for (int i = 0; i < gvMain.Rows.Count; i++)
        {
            if (i > -1 && gvMain.Rows[i].Cells[0].FindControl("chkSelect") != null)
            {
                GridViewRow gRow = gvMain.Rows[i];
                if (((CheckBox)gRow.Cells[1].FindControl("chkSelect")).Checked)
                {
                    VAdmitPatientData vData = new VAdmitPatientData();
                    vData.LOID = Convert.ToDouble("0" + gRow.Cells[0].Text);
                    if (gRow.Cells[3].Text != "")
                        vData.ADMITDATE = Convert.ToDateTime(gRow.Cells[3].Text);
                    vData.PATIENTNAME = gRow.Cells[4].Text;
                    vData.HN = gRow.Cells[5].Text;
                    vData.AN = gRow.Cells[6].Text;
                    vData.VN = gRow.Cells[7].Text;
                    vData.TITLE =(gRow.Cells[8].Text == ""?0:Convert.ToDouble("0" + gRow.Cells[8].Text));
                    vData.DISEASE = gRow.Cells[9].Text;
                    vData.WARD = (gRow.Cells[10].Text ==""?0: Convert.ToDouble("0"+ gRow.Cells[10].Text));
                    vData.ROOMNO = gRow.Cells[11].Text;
                    vData.BEDNO = gRow.Cells[12].Text;
                    if (gRow.Cells[13].Text != "" & gRow.Cells[13].Text != "&nbsp;")
                        vData.BIRTHDATE = Convert.ToDateTime(gRow.Cells[13].Text);
                    vData.WEIGHT = (gRow.Cells[13].Text == ""?0: Convert.ToDouble("0" + gRow.Cells[14].Text));
                    vData.HEIGHT = (gRow.Cells[15].Text == ""?0: Convert.ToDouble("0" + gRow.Cells[15].Text));
                    vData.DRUGALLERGIC = gRow.Cells[16].Text;
                    vData.FOODALLERGIC = gRow.Cells[17].Text;
                    vData.DIAGNOSIS = gRow.Cells[18].Text;

                    arrChk.Add(vData);
                }
            }
        }
        return arrChk;
    }

    #endregion

    #region Controls Management Methods

    private void ClearSearch()
    {
        if (this.cmbWard.Enabled) this.cmbWard.SelectedIndex = 0;
        this.txtSearchPName.Text = "";
        this.txtSearchHN.Text = "";
        this.txtSearchAN.Text = "";
        this.ctlAdmitDateFrom.DateValue = new DateTime(1, 1, 1);
        this.ctlAdmitDateTo.DateValue = new DateTime(1, 1, 1);
    }

    public void Show(string type)
    {
        Show(type, "");
    }

    public void Show(string type, string existKeyList)
    {
        this.txtExistKeyList.Text = existKeyList;
        if (type != "0")
        {
            ClearSearch();
            cmbWard.SelectedIndex = cmbWard.Items.IndexOf(cmbWard.Items.FindByValue(type.Trim()));
        }

        gvMain.PageIndex = 0;
        doGetList();
        popupAdmitPatient.Show();
    }

    #endregion

    #region Working Method

    private void doGetList()
    {
        SearchFlow fFlow = new SearchFlow();
        string dtfrom = "";
        string dtto = "";

        // ตรวจสอบเงื่อนไขการค้นหาเพื่อแสดงปุ่ม reset การค้นหา
        imbReset.Visible = (ctlAdmitDateFrom.DateValue.Year != 1 || ctlAdmitDateTo.DateValue.Year != 1 || txtSearchPName.Text.Trim() != "" || txtSearchHN.Text.Trim() != "" || txtSearchAN.Text.Trim() != "");

        string orderStr = "";
        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;

        if (this.ctlAdmitDateFrom.DateValue.Year != 1 )
        {
            dtfrom = this.ctlAdmitDateFrom.DateValue.Day.ToString() + '/' + this.ctlAdmitDateFrom.DateValue.Month.ToString() + '/' + this.ctlAdmitDateFrom.DateValue.Year.ToString();
        }

        if (this.ctlAdmitDateTo.DateValue.Year != 1)
        {
            dtto = this.ctlAdmitDateTo.DateValue.Day.ToString() + '/' + this.ctlAdmitDateTo.DateValue.Month.ToString() + '/' + this.ctlAdmitDateTo.DateValue.Year.ToString();
        }

        gvMain.DataSource = fFlow.GetAdmitPatientList(txtSearchPName.Text.Trim(), txtSearchHN.Text.Trim(), txtSearchAN.Text.Trim(),
                            dtfrom, dtto, Convert.ToDouble("0" + cmbWard.SelectedItem.Value.ToString()),
                            this.txtExistKeyList.Text, orderStr);
        gvMain.DataBind();
        pcBot.Update();
        pcTop.Update();
    }

    #endregion
}
