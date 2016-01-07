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
using SHND.Data.Tables;

public partial class App_Prepare_Transaction_OrderFeedSet_OrderFeedSetCtl : System.Web.UI.UserControl
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        SetMealCombo(cmbMeal);
        ctlCheckTime.DateValue = DateTime.Today.Date;
        txtTime.Text = DateTime.Now.Hour.ToString() + ':' + DateTime.Now.Minute.ToString() + ':' + DateTime.Now.Second.ToString();

        Appz.BuildCombo(this.cmbSearchWard, "WARD", "NAME", "LOID", "ACTIVE='1'", "NAME", "ทั้งหมด", "0",true);
        Appz.BuildCombo(this.cmbSearchFoodType, "FOODTYPE", "NAME", "LOID", "ACTIVE ='1'", "NAME", "ทั้งหมด", "0", true);
        Appz.BuildCombo(this.cmbSearchFoodCategory, "V_MATERIALFEED", "NAME", "LOID", "", "NAME", "ทั้งหมด", "0", true);

        this.btnSearch.OnClientClick = "if (document.getElementById('" + this.txtSearchTimeFrom.ClientID + "').value != '') " +
            "{" +
            "if (parseFloat(document.getElementById('" + this.txtSearchTimeFrom.ClientID + "').value.split(':')[0]) >= 24 || parseFloat(document.getElementById('" + this.txtSearchTimeFrom.ClientID + "').value.split(':')[1]) > 59) " +
            "{ alert('รุปแบเวลาไม่ถูกต้อง (จำนวนชั่วโมงต้องน้อยกว่า 24 และนาทีต้องไม่เกิน 59)'); document.getElementById('" + this.txtSearchTimeFrom.ClientID + "').focus(); return false; } " +
            "} " +
            "if (document.getElementById('" + this.txtSearchTimeTo.ClientID + "').value != '') " +
            "{" +
            "if (parseFloat(document.getElementById('" + this.txtSearchTimeTo.ClientID + "').value.split(':')[0]) >= 24 || parseFloat(document.getElementById('" + this.txtSearchTimeTo.ClientID + "').value.split(':')[1]) > 59) " +
            "{ alert('รุปแบเวลาไม่ถูกต้อง (จำนวนชั่วโมงต้องน้อยกว่า 24 และนาทีต้องไม่เกิน 59)'); document.getElementById('" + this.txtSearchTimeTo.ClientID + "').focus(); return false; } " +
            "}"+

            "else if (document.getElementById('" + this.txtRegTimeFrom.ClientID + "').value != '') " +
            "{" +
            "if (parseFloat(document.getElementById('" + this.txtRegTimeFrom.ClientID + "').value.split(':')[0]) >= 24 || parseFloat(document.getElementById('" + this.txtRegTimeFrom.ClientID + "').value.split(':')[1]) > 59) " +
            "{ alert('รุปแบเวลาไม่ถูกต้อง (จำนวนชั่วโมงต้องน้อยกว่า 24 และนาทีต้องไม่เกิน 59)'); document.getElementById('" + this.txtRegTimeFrom.ClientID + "').focus(); return false; } " +
            "} " +
            "if (document.getElementById('" + this.txtRegTimeTo.ClientID + "').value != '') " +
            "{" +
            "if (parseFloat(document.getElementById('" + this.txtRegTimeTo.ClientID + "').value.split(':')[0]) >= 24 || parseFloat(document.getElementById('" + this.txtRegTimeTo.ClientID + "').value.split(':')[1]) > 59) " +
            "{ alert('รุปแบเวลาไม่ถูกต้อง (จำนวนชั่วโมงต้องน้อยกว่า 24 และนาทีต้องไม่เกิน 59)'); document.getElementById('" + this.txtRegTimeTo.ClientID + "').focus(); return false; } " +
            "}";


        pcTop.SetMainGridView(gvMain);
        pcBot.SetMainGridView(gvMain);
        pcTop.Visible = false;
        pcBot.Visible = false;
        //ClearSearch();
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
        doGetList(0);
    }

    protected void imbReset_Click(object sender, ImageClickEventArgs e)
    {
        ClearSearch();
        //doGetList(0);
    }

    #region Toolbar Pop

    protected void tbSaveClick(object sender, EventArgs e)
    {
        InsertPrepareTime();
        CutPop.Show();
    }

    protected void tbBackClick(object sender, EventArgs e)
    {
        ClearData();
    }
    #endregion

    #endregion

    #region GridView Event Handler

    #endregion

    #region Paging Event Handler
    protected void PageChange(object sender, EventArgs e)
    {
        doGetList(((Templates_PageControl)sender).SelectedPageIndex);
    }
    #endregion

    #region Misc. Methods
  
    #endregion

    #region Controls Management Methods

    private void ClearSearch()
    {
        // Clear searh data
        this.cmbSearchWard.SelectedIndex = -1;
        this.txtSearchPatientName.Text = "";
        this.ctlSearchOrderDate.DateValue = new DateTime();
        this.txtSearchTimeFrom.Text = "";
        this.txtSearchTimeTo.Text = "";
        this.cmbSearchFoodCategory.SelectedIndex = -1;
        this.cmbSearchFoodType.SelectedIndex = -1;
        this.txtSearchAN.Text = "";
        this.txtSearchHN.Text = "";
        this.txtSearchVN.Text = "";
        this.ctlSearchRegDate.DateValue = new DateTime();
        this.txtRegTimeFrom.Text = "";
        this.txtRegTimeTo.Text = "";
        pcBot.Visible = false;
        pcTop.Visible = false;
        imbReset.Visible = false;
        gvMain.Visible = false;
    }

    private void SetErrorStatus(string t)
    {
        lbStatus.Text = t;
        lbStatus.ForeColor = Constant.StatusColor.Error;
    }


    protected void cmbMeal_SelectedIndexChanged(object sender, EventArgs e)
    {
        CutPop.Show();
        string wh = "";
        OrderPatientSetFlow oFlow = new OrderPatientSetFlow();
        if (cmbMeal.SelectedItem.Value != "0")
        {
            if (cmbMeal.SelectedItem.Value == "11")
            {
                wh = "SELECT BREAKFASTTIME FROM CUTOFFTIME WHERE USEFOR ='S' ";
            }
            else if (cmbMeal.SelectedItem.Value == "21")
            {
                wh = "SELECT LUNCHTIME FROM CUTOFFTIME WHERE USEFOR ='S' ";
            }
            else if (cmbMeal.SelectedItem.Value == "31")
            {
                wh = "SELECT DINNERTIME FROM CUTOFFTIME WHERE USEFOR ='S' ";
            }

            txtCutOfTime.Text = oFlow.GetCutOfTime(wh);
        }
        else
            txtCutOfTime.Text = "";
    }

    private void ClearData()
    {
        txtTime.Text = DateTime.Now.Hour.ToString() + ':' + DateTime.Now.Minute.ToString() + ':' + DateTime.Now.Second.ToString();
        txtCutOfTime.Text = "";
        //txtQty.Text = "";
        cmbMeal.SelectedIndex = -1;
        ctlCheckTime.DateValue = DateTime.Today.Date;
        txhID.Text = "";
        lbStatus.Text = "";
    }

    private PrepareTimeData GetData()
    {
        PrepareTimeData pData = new PrepareTimeData();
        pData.REFTABLEMED = "ORDERMEDICALFEED";
        //pData.CHECKTIME = ctlCheckTime.DateValue;
        pData.CHECKTIME = DateTime.Now;
        pData.PREPAREMEAL = cmbMeal.SelectedItem.Value;
        pData.ISTRANSFER = "N";
        return pData;
    }


    private void SetPrint()
    {
        string strOFrom = "";
        string strOTo = "";
        string strRFrom = "";
        string strRTo = "";

        DateTime strOrderDateFrom = this.ctlSearchOrderDate.DateValue;
        DateTime strOrderDateTo = this.ctlSearchOrderDate.DateValue;
        DateTime strRegisterDateFrom = this.ctlSearchRegDate.DateValue;
        DateTime strRegisterDateTo = this.ctlSearchRegDate.DateValue;

        //วันที่สั่งอาหาร
        if (strOrderDateFrom.Year != 1 && this.txtSearchTimeFrom.Text.Trim() != "")
        {
            strOrderDateFrom = new DateTime(strOrderDateFrom.Year, strOrderDateFrom.Month, strOrderDateFrom.Day, Convert.ToInt32(this.txtSearchTimeFrom.Text.Substring(0, 2)), Convert.ToInt32(this.txtSearchTimeFrom.Text.Substring(3, 2)), 0);
            strOFrom = Convert.ToString(strOrderDateFrom.Year + 543) + '-' + strOrderDateFrom.Month.ToString("00") + '-' + strOrderDateFrom.Day.ToString("00") + ' ' + strOrderDateFrom.TimeOfDay.ToString();
        }
        if (strOrderDateTo.Year != 1 && this.txtSearchTimeTo.Text.Trim() != "")
        {
            strOrderDateTo = new DateTime(strOrderDateTo.Year, strOrderDateTo.Month, strOrderDateTo.Day, Convert.ToInt32(this.txtSearchTimeTo.Text.Substring(0, 2)), Convert.ToInt32(this.txtSearchTimeTo.Text.Substring(3, 2)), 0);
            strOTo = Convert.ToString(strOrderDateTo.Year + 543) + '-' + strOrderDateTo.Month.ToString("00") + '-' + strOrderDateTo.Day.ToString("00") + ' ' + strOrderDateTo.TimeOfDay.ToString();
        }

        //วันที่ Register
        if (strRegisterDateFrom.Year != 1 && this.txtRegTimeFrom.Text.Trim() != "")
        {
            strRegisterDateFrom = new DateTime(strRegisterDateFrom.Year, strRegisterDateFrom.Month, strRegisterDateFrom.Day, Convert.ToInt32(this.txtRegTimeFrom.Text.Substring(0, 2)), Convert.ToInt32(this.txtRegTimeFrom.Text.Substring(3, 2)), 0);
            strRFrom = Convert.ToString(strRegisterDateFrom.Year + 543) + '-' + strRegisterDateFrom.Month.ToString("00") + '-' + strRegisterDateFrom.Day.ToString("00") + ' ' + strRegisterDateFrom.TimeOfDay.ToString();

        }
        if (strRegisterDateTo.Year != 1 && this.txtRegTimeTo.Text.Trim() != "")
        {
            strRegisterDateTo = new DateTime(strRegisterDateTo.Year, strRegisterDateTo.Month, strRegisterDateTo.Day, Convert.ToInt32(this.txtRegTimeTo.Text.Substring(0, 2)), Convert.ToInt32(this.txtRegTimeTo.Text.Substring(3, 2)), 0);
            strRTo = Convert.ToString(strRegisterDateTo.Year+543) + '-' + strRegisterDateTo.Month.ToString() + '-' + strRegisterDateTo.Day.ToString() + ' ' + strRegisterDateTo.TimeOfDay.ToString();

        }

        this.tbPrintList.ClientClick = Appz.OpenReportScript(Constant.Reports.OrderFeedListReport, "paramfield1=WARD&paramvalue1=" + cmbSearchWard.SelectedItem.Value +
            "&paramfield2=FOODTYPE&paramvalue2=" + cmbSearchFoodType.SelectedItem.Value +
            "&paramfield3=FOODCATEGORY&paramvalue3=" + cmbSearchFoodCategory.SelectedItem.Value +
            "&paramfield4=PATIENTNAME&paramvalue4=" + Server.UrlEncode(txtSearchPatientName.Text.Trim()) +
            "&paramfield5=HN&paramvalue5=" + txtSearchHN.Text.Trim() +
            "&paramfield6=AN&paramvalue6=" + txtSearchAN.Text.Trim() +
            "&paramfield7=VN&paramvalue7=" + txtSearchVN.Text.Trim() +
            "&paramfield8=ORDERDATEFROM&paramvalue8=" + strOFrom +
            "&paramfield9=ORDERDATETO&paramvalue9=" + strOTo +
            "&paramfield10=REGISTERDATEFROM&paramvalue10=" + strRFrom +
            "&paramfield11=REGISTERDATETO&paramvalue11=" + strRTo, false);

        this.tbPrintSlip.ClientClick = Appz.OpenReportScript(Constant.Reports.OrderFeedSlipReport, "paramfield1=WARD&paramvalue1=" + cmbSearchWard.SelectedItem.Value +
           "&paramfield2=FOODTYPE&paramvalue2=" + cmbSearchFoodType.SelectedItem.Value +
           "&paramfield3=FOODCATEGORY&paramvalue3=" + cmbSearchFoodCategory.SelectedItem.Value +
           "&paramfield4=PATIENTNAME&paramvalue4=" + Server.UrlEncode(txtSearchPatientName.Text.Trim()) +
           "&paramfield5=HN&paramvalue5=" + txtSearchHN.Text.Trim() +
           "&paramfield6=AN&paramvalue6=" + txtSearchAN.Text.Trim() +
           "&paramfield7=VN&paramvalue7=" + txtSearchVN.Text.Trim() +
           "&paramfield8=ORDERDATEFROM&paramvalue8=" + strOFrom +
           "&paramfield9=ORDERDATETO&paramvalue9=" + strOTo +
           "&paramfield10=REGISTERDATEFROM&paramvalue10=" + strRFrom +
           "&paramfield11=REGISTERDATETO&paramvalue11=" + strRTo, false);

    }
    #endregion

    #region "Working Methods"

    private void doGetList(int curPage)
    {
        imbReset.Visible = (cmbSearchWard.SelectedValue != "0") || (this.cmbSearchFoodType.SelectedValue != "0") || (this.cmbSearchFoodCategory.SelectedValue != "0") ||
(this.txtSearchPatientName.Text != "") || (txtRegTimeFrom.Text.Trim() != "") || (this.txtRegTimeTo.Text.Trim() != "") || (this.txtSearchTimeFrom.Text.Trim() != "") ||
(this.txtSearchTimeTo.Text.Trim() != "") || (ctlSearchOrderDate.DateValue.Year != 1) || (ctlSearchRegDate.DateValue.Year != 1) || (this.txtSearchAN.Text != "") || (this.txtSearchHN.Text != "") || (this.txtSearchVN.Text != "");

        int pageSize = 20;
        int count = 0;
        int rank = 0;
        int total = 0;
        DataTable dt = new DataTable();
        dt = GetDataInsert();
        #region SetData
        
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
                dNewRow["ORDERMEDICALFEEDID"] = dt.Rows[i]["ORDERMEDICALFEEDID"];
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
                dNewRow["MATERIALNAME"] = dt.Rows[i]["MATERIALNAME"];
                dNewRow["FORMULAFEEDNAME"] = dt.Rows[i]["FORMULAFEEDNAME"];
                dNewRow["MEDFIRSTDATE"] = dt.Rows[i]["MEDFIRSTDATE"];
                dNewRow["MEDENDDATE"] = dt.Rows[i]["MEDENDDATE"];
                dNewRow["MEDSTATUS"] = dt.Rows[i]["MEDSTATUS"];
                dNewRow["FOODTYPE"] = dt.Rows[i]["FOODTYPE"];
                dNewRow["FOODTYPENAME"] = dt.Rows[i]["FOODTYPENAME"];
                dNewRow["NONFIRSTDATE"] = dt.Rows[i]["NONFIRSTDATE"];
                dNewRow["NONENDDATE"] = dt.Rows[i]["NONENDDATE"];
                dNewRow["NONSTATUS"] = dt.Rows[i]["NONSTATUS"];
                dNewRow["QTY"] = dt.Rows[i]["QTY"];
                dNewRow["FEEDCATEGORY"] = dt.Rows[i]["FEEDCATEGORY"];
                dNewRow["FEEDCATEGORYNAME"] = dt.Rows[i]["FEEDCATEGORYNAME"];
                dNewRow["REMARKS"] = dt.Rows[i]["REMARKS"];
                dNewRow["FOODNAME"] = dt.Rows[i]["FOODNAME"];
                dNewRow["MEDORDERDATE"] = dt.Rows[i]["MEDORDERDATE"];
                dNewRow["NONORDERDATE"] = dt.Rows[i]["NONORDERDATE"];
                dNewRow["CONTROL"] = dt.Rows[i]["CONTROL"];
                dNewRow["LIMIT"] = dt.Rows[i]["LIMIT"];
                dNewRow["INCREASE"] = dt.Rows[i]["INCREASE"];
                dNewRow["ABSTAIN"] = dt.Rows[i]["ABSTAIN"];
                dNewRow["NEED"] = dt.Rows[i]["NEED"];
                dNewRow["DESCRIPTIONS"] = dt.Rows[i]["DESCRIPTIONS"];
                dNewRow["STATUS"] = dt.Rows[i]["STATUS"];
                dNewRow["STATUSNAME"] = dt.Rows[i]["STATUSNAME"];
                dNewRow["ORDERDATE"] = dt.Rows[i]["ORDERDATE"];
                dNewRow["REGISTERDATE"] = dt.Rows[i]["REGISTERDATE"];
                dtNew.Rows.Add(dNewRow);
            }
        }

        txtQty.Text = dtNew.Rows.Count.ToString();
        this.gvMain.DataSource = dtNew;
        this.gvMain.DataBind();
        this.gvMain.Visible = true;
        pcTop.Update(curPage, total, pageSize, count);
        pcBot.Update(curPage, total, pageSize, count);
        pcTop.Visible = true;
        pcBot.Visible = true;


        #endregion

        SetPrint();

    }


    private bool InsertPrepareTime()
    {
        bool ret = true;
        DataTable dd = new DataTable();
        string error = VerifyData();
        if (error != "")
        {
            SetErrorStatus(error);
            return false;
        }

        OrderFeedSetFlow oFlow = new OrderFeedSetFlow();
        dd =  GetDataInsert();
        ret = oFlow.InsertPrepareTime(GetData(), Appz.CurrentUser.ToString(), dd);
        if (ret)
        {
            SetErrorStatus("บันทึกข้อมูลเรียบร้อยแล้ว");
        }
        else
        {
            SetErrorStatus(oFlow.ErrorMessage);
        }
        return ret;
    }

    private string VerifyData()
    {
        string ret = "";
        PrepareTimeData pData = GetData();
        if (pData.CHECKTIME.ToString() == "")
            ret = string.Format(DataResources.MSGEI001, "วันที่");
        else if (pData.PREPAREMEAL.ToString() == "0")
            ret = string.Format(DataResources.MSGEI001, "มื้อ");

        return ret;
    }

    private DataTable GetDataInsert()
    {
        DateTime orderDateFrom = this.ctlSearchOrderDate.DateValue;
        DateTime orderDateTo = this.ctlSearchOrderDate.DateValue;
        DateTime RegDateFrom = this.ctlSearchRegDate.DateValue;
        DateTime RegDateTo = this.ctlSearchRegDate.DateValue;

        //วันที่สั่งอาหาร
        if (orderDateFrom.Year != 1 && this.txtSearchTimeFrom.Text.Trim() != "")
            orderDateFrom = new DateTime(orderDateFrom.Year, orderDateFrom.Month, orderDateFrom.Day, Convert.ToInt32(this.txtSearchTimeFrom.Text.Substring(0, 2)), Convert.ToInt32(this.txtSearchTimeFrom.Text.Substring(3, 2)), 0);
        if (orderDateTo.Year != 1 && this.txtSearchTimeTo.Text.Trim() != "")
            orderDateTo = new DateTime(orderDateTo.Year, orderDateTo.Month, orderDateTo.Day, Convert.ToInt32(this.txtSearchTimeTo.Text.Substring(0, 2)), Convert.ToInt32(this.txtSearchTimeTo.Text.Substring(3, 2)), 0);

        //วันที่ Register
        if (RegDateFrom.Year != 1 && this.txtRegTimeFrom.Text.Trim() != "")
            RegDateFrom = new DateTime(RegDateFrom.Year, RegDateFrom.Month, RegDateFrom.Day, Convert.ToInt32(this.txtRegTimeFrom.Text.Substring(0, 2)), Convert.ToInt32(this.txtRegTimeFrom.Text.Substring(3, 2)), 0);
        if (RegDateTo.Year != 1 && this.txtRegTimeTo.Text.Trim() != "")
            RegDateTo = new DateTime(RegDateTo.Year, RegDateTo.Month, RegDateTo.Day, Convert.ToInt32(this.txtRegTimeTo.Text.Substring(0, 2)), Convert.ToInt32(this.txtRegTimeTo.Text.Substring(3, 2)), 0);

        OrderFeedSetFlow oFlow = new OrderFeedSetFlow();
        DataTable dt;

        dt = oFlow.GetOrderFeedSetList(Convert.ToDouble(this.cmbSearchWard.SelectedItem.Value), Convert.ToDouble(this.cmbSearchFoodType.SelectedItem.Value), (this.cmbSearchFoodCategory.SelectedValue == "0" ? "" : this.cmbSearchFoodCategory.SelectedItem.Text.Trim()),
             this.txtSearchPatientName.Text.Trim(), orderDateFrom, orderDateTo, RegDateFrom, RegDateTo, this.txtSearchHN.Text.Trim(), this.txtSearchAN.Text.Trim(), txtSearchVN.Text.Trim(), "PATIENTNAME, RANK DESC");

        return dt;
    }

    protected void gvMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRow drow = (DataRow)((DataRowView)e.Row.DataItem).Row;
            Label lblAge = (Label)e.Row.Cells[2].FindControl("lblAge");
            if (drow["BIRTHDATE"].ToString() != "")
            {
                if (Convert.ToDateTime(drow["BIRTHDATE"]).ToString("MMdd") == DateTime.Today.AddDays(1).ToString("MMdd"))
                    lblAge.BackColor = System.Drawing.Color.Gold;
                else if (Convert.ToDateTime(drow["BIRTHDATE"]).ToString("MMdd") == DateTime.Today.ToString("MMdd"))
                    lblAge.ForeColor = System.Drawing.Color.Red;
            }


        }
    }
    #endregion
}
