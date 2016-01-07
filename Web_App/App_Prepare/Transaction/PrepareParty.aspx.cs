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
using SHND.Data.Common.Utilities;
using SHND.Global;
using SHND.Data.Views;
using SHND.Data.Search;


/// <summary> 
/// PrepareParty Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Nang
/// Create Date: 10 Mar 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้าการทำงานรายการการเตรียมอาหารจัดเลี้ยง PrepareParty
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 


public partial class App_Prepare_Transaction_PrepareParty : System.Web.UI.Page
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
        Appz.BuildCombo(cmbSearchDivision, "DIVISION", "NAME", "LOID", " ISPARTY = 'Y' AND ACTIVE = '1' ", "NAME", "ทั้งหมด", "0", true);
        Appz.BuildCombo(cmbSearchType, "PARTYTYPE", "NAME", "LOID", " ACTIVE = '1'", "NAME", "ทั้งหมด", "0", true);
        Appz.BuildCombo(cmbDivision, "DIVISION", "NAME", "LOID", " ACTIVE = '1' ", "NAME", "ทั้งหมด", "0", true);
        Appz.BuildCombo(cmbPartyType, "PARTYTYPE", "NAME", "LOID", " ACTIVE = '1'", "NAME", "ทั้งหมด", "0", true);

        ctlPartyDateFrom.DateValue = DateTime.Today;
        ctlPartyDateto.DateValue = DateTime.Today;
        pcTop.SetMainGridView(grvResult);
        pcBot.SetMainGridView(grvResult);
    }

    #region Button Click Event Handler

    #region Button Main

    protected void imbSearch_Click(object sender, ImageClickEventArgs e)
    {
        grvResult.PageIndex = 0;
        doGetList();
    }

    protected void lnkType_Click(object sender, EventArgs e)
    {
        doGetDetail(((LinkButton)sender).CommandArgument);
        tbPrint.Visible = (txhID.Text.Trim() != "");
        PreparePartyPop.Show();

    }


    #endregion

    #region Button Pop

    protected void tbBack_Click(object sender, EventArgs e)
    {
        ClearData();
        doGetList();
    }


    #endregion

    #endregion

    #region Gridview Event Handler


    protected void grvResult_Sorting(object sender, GridViewSortEventArgs e)
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
    }

    protected void grvItem_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex > -1)
        {
            e.Row.Cells[1].Text = ((e.Row.RowIndex + 1) + (grvItem.PageIndex * grvItem.PageSize)).ToString();
        }
    }

    protected void grvResult_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex > -1)
        {
            e.Row.Cells[3].Text = ((e.Row.RowIndex + 1) + (grvResult.PageIndex * grvResult.PageSize)).ToString();

            ImageButton imgPrint = (ImageButton)e.Row.FindControl("imgPrint");
            if (imgPrint != null)
            {
                imgPrint.OnClientClick = Appz.OpenReportScript(Constant.Reports.PreparePartyReport,Convert.ToDouble(e.Row.Cells[0].Text == ""?"0":e.Row.Cells[0].Text), false);
            }
        }
    }


    #endregion

    #region Paging Event Handler
    protected void PageChange(object sender, EventArgs e)
    {
        grvResult.PageIndex = ((Templates_PageControl)sender).SelectedPageIndex;
        doGetList();
        pcBot.Update();
        pcTop.Update();
    }
    protected void PopUpPageChange(object sender, EventArgs e)
    {
        grvItem.PageIndex = ((Templates_PageControl)sender).SelectedPageIndex;
        doGetPageChang((txhID.Text.Trim() != "" ? txhID.Text.Trim() : "0"));
        pcBot1.Update();
        pcTop1.Update();
    }

    #endregion

    #region Misc. Methods

    #endregion

    #region Controls Management Methods

    private void SetErrorStatus(string t)
    {
        lbStatus.Text = t;
        lbStatus.ForeColor = Constant.StatusColor.Error;
    }

    private void SetData(OrderPartyData oData, DataTable dt)
    {
        PreparePartyFlow pFlow = new PreparePartyFlow();


        txhID.Text = oData.LOID.ToString();
        txtOrderCode.Text = oData.CODE.ToString();
        cmbDivision.SelectedIndex = cmbDivision.Items.IndexOf(cmbDivision.Items.FindByValue(oData.DIVISION.ToString()));
        ctlOrderDate.DateValue = Convert.ToDateTime(oData.ORDERDATE.ToString());
        txtFullName.Text = pFlow.GetTitle(oData.OTITLE) + oData.ONAME.ToString() + ' ' + oData.OLASTNAME.ToString();
        txtTel.Text = oData.OTEL;
        ctlPartyDate.DateValue = Convert.ToDateTime(oData.PARTYDATETIME.ToString());
        txtTime.Text = oData.PARTYDATETIME.TimeOfDay.ToString();
        cmbPartyType.SelectedIndex = cmbPartyType.Items.IndexOf(cmbPartyType.Items.FindByValue(oData.PARTYTYPE.ToString()));
        txtVISITORQTY.Text = oData.VISITORQTY.ToString();
        txtPlace.Text = oData.PLACE.ToString();
        txtStatus.Text = pFlow.GetStatusName(oData.LOID);
        rdCommit.Checked = (oData.DIRECTORAPPROVE == "Y" ? true : false);
        rdNonCommit.Checked = (oData.DIRECTORAPPROVE == "N" ? true : false);
        RdNonApprove.Checked = (oData.NDAPPROVE == "N" ? true : false);
        RdApprove.Checked = (oData.NDAPPROVE == "Y" ? true : false);
        txtDirectCommitte.Text = oData.DIRECTORCOMMENT.ToString();
        txtNDCommitte.Text = oData.NDCOMMENT.ToString();

        this.tbPrint.ClientClick = Appz.OpenReportScript(Constant.Reports.PreparePartyReport, Convert.ToDouble(txhID.Text.Trim()), false);
        this.tbPrint.Visible = (oData.LOID != 0);

        grvItem.DataSource = dt;
        grvItem.DataBind();
        pcTop1.SetMainGridView(grvItem);
        pcBot1.SetMainGridView(grvItem);
        pcTop1.Update();
        pcBot1.Update();
    }

    private void ClearData()
    {
        txhID.Text = "";
        txtOrderCode.Text = "";
        cmbDivision.SelectedIndex = -1;
        ctlOrderDate.DateValue = new DateTime(1, 1, 1);
        txtFullName.Text = "";
        txtTel.Text = "";
        ctlPartyDate.DateValue = new DateTime(1, 1, 1);
        cmbPartyType.SelectedIndex = -1;
        txtVISITORQTY.Text = "";
        txtPlace.Text = "";
        grvItem.DataSource = null;
        grvItem.DataBind();
    }

    #endregion

    #region Working Method

    private void doGetList()
    {
        PreparePartyFlow pFlow = new PreparePartyFlow();
        string orderStr = "";
        string wh = " STATUS = 'RG' AND NDAPPROVE = 'Y' ";
        string orderdatefrom = "";
        string orderdateTo = "";
        string partydatefrom = "";
        string partydateTo = "";
        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;

        //วันที่การสั่งอาหาร
        if (ctlOrderDateFrom.DateValue.Year.ToString() != "1" && ctlOrderDateTo.DateValue.Year.ToString() != "1")
        {
            orderdatefrom = ctlOrderDateFrom.DateValue.Day.ToString() + '/' + ctlOrderDateFrom.DateValue.Month.ToString() + '/' + ctlOrderDateFrom.DateValue.Year.ToString();
            orderdateTo = ctlOrderDateTo.DateValue.Day.ToString() + '/' + ctlOrderDateTo.DateValue.Month.ToString() + '/' + ctlOrderDateTo.DateValue.Year.ToString();
        }
        else if (ctlOrderDateFrom.DateValue.Year.ToString() != "1")
            orderdatefrom = ctlOrderDateFrom.DateValue.Day.ToString() + '/' + ctlOrderDateFrom.DateValue.Month.ToString() + '/' + ctlOrderDateFrom.DateValue.Year.ToString();
        else if (ctlOrderDateFrom.DateValue.Year.ToString() != "1")
            orderdateTo = ctlOrderDateTo.DateValue.Day.ToString() + '/' + ctlOrderDateTo.DateValue.Month.ToString() + '/' + ctlOrderDateTo.DateValue.Year.ToString();

        //วันที่จัดเลี้ยง
        if (ctlPartyDateFrom.DateValue.Year.ToString() != "1" && ctlPartyDateto.DateValue.Year.ToString() != "1")
        {
            partydatefrom = ctlPartyDateFrom.DateValue.Day.ToString() + '/' + ctlPartyDateFrom.DateValue.Month.ToString() + '/' + ctlPartyDateFrom.DateValue.Year.ToString();
            partydateTo = ctlPartyDateto.DateValue.Day.ToString() + '/' + ctlPartyDateto.DateValue.Month.ToString() + '/' + ctlPartyDateto.DateValue.Year.ToString();
        }
        else if (ctlPartyDateFrom.DateValue.Year.ToString() != "1")
            partydatefrom = ctlPartyDateFrom.DateValue.Day.ToString() + '/' + ctlPartyDateFrom.DateValue.Month.ToString() + '/' + ctlPartyDateFrom.DateValue.Year.ToString();
        else if (ctlPartyDateto.DateValue.Year.ToString() != "1")
            partydateTo = ctlPartyDateto.DateValue.Day.ToString() + '/' + ctlPartyDateto.DateValue.Month.ToString() + '/' + ctlPartyDateto.DateValue.Year.ToString();

        //---------------------------------------------------------------------------------------------

        //เลขที่การสั่งอาหาร
        if (txtOrderCodeFrom.Text.Trim() != "" && txtOrderCodeTo.Text.Trim() != "")
            wh += (wh == "" ? "" : " AND ") + " UPPER(ORDERCODE) BETWEEN UPPER('" + txtOrderCodeFrom.Text.Trim() + "') AND UPPER('" + txtOrderCodeTo.Text.Trim() + "')";
        else if (txtOrderCodeFrom.Text.Trim() != "")
            wh += (wh == "" ? "" : " AND ") + " UPPER(ORDERCODE) >= UPPER('" + txtOrderCodeFrom.Text.Trim() + "')";
        else if (txtOrderCodeTo.Text.Trim() != "")
            wh += (wh == "" ? "" : " AND ") + " UPPER(ORDERCODE) <= UPPER('" + txtOrderCodeTo.Text.Trim() + "')";


        ////Check วันที่สั่งอาหาร
        if (orderdatefrom != "" && orderdateTo != "")
            wh += (wh == "" ? "" : " AND ") + " ORDERDATE BETWEEN TO_DATE('" + orderdatefrom + "','DD/MM/YYYY') AND TO_DATE('" + orderdateTo + "','DD/MM/YYYY')";
        else if (orderdatefrom != "")
            wh += (wh == "" ? "" : " AND ") + " ORDERDATE >= TO_DATE('" + orderdatefrom + "','DD/MM/YYYY')";
        else if (orderdateTo != "")
            wh += (wh == "" ? "" : " AND ") + " ORDERDATE <= TO_DATE('" + orderdateTo + "','DD/MM/YYYY')";

        ////Check วันที่จัดเลี้ยง
        if (partydatefrom != "" && partydateTo != "")
            wh += (wh == "" ? "" : " AND ") + " PARTYDATETIME BETWEEN TO_DATE('" + partydatefrom + "','DD/MM/YYYY') AND TO_DATE('" + partydateTo + "','DD/MM/YYYY')";
        else if (orderdatefrom != "")
            wh += (wh == "" ? "" : " AND ") + " PARTYDATETIME >= TO_DATE('" + partydatefrom + "','DD/MM/YYYY')";
        else if (orderdateTo != "")
            wh += (wh == "" ? "" : " AND ") + " PARTYDATETIME <= TO_DATE('" + partydateTo + "','DD/MM/YYYY')";

        //หน่วยงาน
        if (cmbSearchDivision.SelectedItem.Value != "0")
            wh += (wh == "" ? "" : " AND ") + " DIVISIONID = " + cmbSearchDivision.SelectedItem.Value.ToString();

        //ประเภทการจัดเลี้ยง
        if (cmbSearchType.SelectedItem.Value != "0")
            wh += (wh == "" ? "" : " AND ") + " PARTYTYPEID = " + cmbSearchType.SelectedItem.Value.ToString();

        grvResult.DataSource = pFlow.GetPreparePartySearch(wh, orderStr);
        grvResult.DataBind();
        pcTop.Update();
        pcBot.Update();
    }

    private bool doGetDetail(string LOID)
    {
        bool ret = true;
        PreparePartyFlow pFlow = new PreparePartyFlow();
        OrderPartyData oData = pFlow.GetOrderPartyData(Convert.ToDouble(LOID));
        DataTable dt = pFlow.GetOrderPartyItemData(Convert.ToDouble(LOID));

        if (oData.LOID != 0)
            SetData(oData, dt);
        else
            ret = false;
        return ret;
    }

    private bool doGetPageChang(string LOID)
    {
        bool ret = true;
        PreparePartyFlow pFlow = new PreparePartyFlow();
        DataTable dt = pFlow.GetOrderPartyItemData(Convert.ToDouble(LOID));

        if (dt.Rows.Count != 0)
        {
            grvItem.DataSource = dt;
            grvItem.DataBind();
        }
        else
            ret = false;
        return ret;
    }

    #endregion
}
