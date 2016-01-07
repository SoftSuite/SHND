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
using SHND.DAL.Tables;
using SHND.Data.Tables;

/// <summary>
/// OrderPatientSet Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Nang
/// Create Date: 31 Mar 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้าการทำงานข้อมูลการจัดอาหารสำรับ
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

public partial class App_Prepare_Transaction_OrderPatientSet : System.Web.UI.Page
{
    public Int32 CurrentPageIndex = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //doGetList();
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        Appz.BuildCombo(cmbWard, "WARD", "NAME", "LOID", "ACTIVE='1'", "NAME", "ทั้งหมด", "0", true);
        Appz.BuildCombo(cmbType, "FOODTYPE", "NAME", "LOID", "ACTIVE='1' AND DIVISION = " + Appz.LoggedOnUser.DIVISION + "", "NAME", "ทั้งหมด", "0", true);
        Appz.BuildCombo(cmbCategory, "FOODCATEGORY", "NAME", "LOID", "ACTIVE='1' ", "NAME", "ทั้งหมด", "0", true);
        
        SetMealCombo(cmbMeal);
        ctlCheckTime.DateValue = DateTime.Today.Date;
        txtTime.Text = DateTime.Now.Hour.ToString() + ':' + DateTime.Now.Minute.ToString() + ':' + DateTime.Now.Second.ToString();
        this.tbPrintReport.ClientClick = Appz.OpenReportScript(Constant.Reports.OrderSetListReport, "paramfield1=WARD&paramvalue1=' + document.getElementById('" + this.cmbWard.ClientID + "').value + " +
            "'&paramfield2=FOODTYPE&paramvalue2=' + document.getElementById('" + this.cmbType.ClientID + "').value + " +
            "'&paramfield3=FOODCATEGORY&paramvalue3=' + document.getElementById('" + this.cmbCategory.ClientID + "').value + " +
            "'&paramfield4=PATIENTNAME&paramvalue4=' + escape(trim(document.getElementById('" + this.txtPatientName.ClientID + "').value)) + " +
            "'&paramfield5=HN&paramvalue5=' + trim(document.getElementById('" + this.txtHN.ClientID + "').value) + " +
            "'&paramfield6=AN&paramvalue6=' + trim(document.getElementById('" + this.txtAN.ClientID + "').value) + " +
            "'&paramfield7=VN&paramvalue7=' + trim(document.getElementById('" + this.txtVN.ClientID + "').value) + " +
            "'&paramfield8=ORDERDATE&paramvalue8=' + document.getElementById('" + this.ctlOrderDate.CalendarClientID + "').value + " +
            "'&paramfield9=ORDERTIMEFROM&paramvalue9=' + document.getElementById('" + this.txtOrderTimeFrom.ClientID + "').value + " +
            "'&paramfield10=ORDERTIMETO&paramvalue10=' + document.getElementById('" + this.txtOrderTimeTo.ClientID + "').value + " +
            "'&paramfield11=REGISTERDATE&paramvalue11=' + document.getElementById('" + this.ctlRegDate.CalendarClientID + "').value + " +
            "'&paramfield12=REGISTERTIMEFROM&paramvalue12=' + document.getElementById('" + this.txtRegTimeFrom.ClientID + "').value + " +
            "'&paramfield13=REGISTERTIMETO&paramvalue13=' + document.getElementById('" + this.txtRegTimeTo.ClientID + "').value + '", false);

        this.tbPrintSlip.ClientClick = Appz.OpenReportScript(Constant.Reports.OrderSetSlipReport, "paramfield1=WARDID&paramvalue1=' + document.getElementById('" + this.cmbWard.ClientID + "').value + " +
            "'&paramfield2=FOODTYPE&paramvalue2=' + document.getElementById('" + this.cmbType.ClientID + "').value + " +
            "'&paramfield3=FOODCATEGORY&paramvalue3=' + document.getElementById('" + this.cmbCategory.ClientID + "').value + " +
            "'&paramfield4=PATIENTNAME&paramvalue4=' + escape(trim(document.getElementById('" + this.txtPatientName.ClientID + "').value)) + " +
            "'&paramfield5=HN&paramvalue5=' + trim(document.getElementById('" + this.txtHN.ClientID + "').value) + " +
            "'&paramfield6=AN&paramvalue6=' + trim(document.getElementById('" + this.txtAN.ClientID + "').value) + " +
            "'&paramfield7=VN&paramvalue7=' + trim(document.getElementById('" + this.txtVN.ClientID + "').value) + " +
            "'&paramfield8=ORDERDATE&paramvalue8=' + document.getElementById('" + this.ctlOrderDate.CalendarClientID + "').value + " +
            "'&paramfield9=ORDERTIMEFROM&paramvalue9=' + document.getElementById('" + this.txtOrderTimeFrom.ClientID + "').value + " +
            "'&paramfield10=ORDERTIMETO&paramvalue10=' + document.getElementById('" + this.txtOrderTimeTo.ClientID + "').value + " +
            "'&paramfield11=REGISTERDATE&paramvalue11=' + document.getElementById('" + this.ctlRegDate.CalendarClientID + "').value + " +
            "'&paramfield12=REGISTERTIMEFROM&paramvalue12=' + document.getElementById('" + this.txtRegTimeFrom.ClientID + "').value + " +
            "'&paramfield13=REGISTERTIMETO&paramvalue13=' + document.getElementById('" + this.txtRegTimeTo.ClientID + "').value + " +
            "'&paramfield14=DIVISION&paramvalue14=" + Appz.LoggedOnUser.DIVISION.ToString(), false);


        this.tbPrintNutrient.ClientClick = Appz.OpenReportScript(Constant.Reports.PatientNutrientReport, "paramfield1=WARDID&paramvalue1=' + document.getElementById('" + this.cmbWard.ClientID + "').value + " +
    "'&paramfield2=FOODTYPE&paramvalue2=' + document.getElementById('" + this.cmbType.ClientID + "').value + " +
    "'&paramfield3=FOODCATEGORY&paramvalue3=' + document.getElementById('" + this.cmbCategory.ClientID + "').value + " +
    "'&paramfield4=PATIENTNAME&paramvalue4=' + escape(trim(document.getElementById('" + this.txtPatientName.ClientID + "').value)) + " +
    "'&paramfield5=HN&paramvalue5=' + trim(document.getElementById('" + this.txtHN.ClientID + "').value) + " +
    "'&paramfield6=AN&paramvalue6=' + trim(document.getElementById('" + this.txtAN.ClientID + "').value) + " +
    "'&paramfield7=VN&paramvalue7=' + trim(document.getElementById('" + this.txtVN.ClientID + "').value) + " +
    "'&paramfield8=ORDERDATE&paramvalue8=' + document.getElementById('" + this.ctlOrderDate.CalendarClientID + "').value + " +
    "'&paramfield9=ORDERTIMEFROM&paramvalue9=' + document.getElementById('" + this.txtOrderTimeFrom.ClientID + "').value + " +
    "'&paramfield10=ORDERTIMETO&paramvalue10=' + document.getElementById('" + this.txtOrderTimeTo.ClientID + "').value + " +
    "'&paramfield11=REGISTERDATE&paramvalue11=' + document.getElementById('" + this.ctlRegDate.CalendarClientID + "').value + " +
    "'&paramfield12=REGISTERTIMEFROM&paramvalue12=' + document.getElementById('" + this.txtRegTimeFrom.ClientID + "').value + " +
    "'&paramfield13=REGISTERTIMETO&paramvalue13=' + document.getElementById('" + this.txtRegTimeTo.ClientID + "').value + '", false);
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
        txtTime.Text = DateTime.Now.Hour.ToString() + ':' + DateTime.Now.Minute.ToString() + ':' + DateTime.Now.Second.ToString();
        txtCutOfTime.Text = "";
        txtQty.Text = "";
        cmbMeal.SelectedIndex = -1;
        ctlCheckTime.DateValue = DateTime.Today.Date;
        txhID.Text = "";
        lbStatus.Text = "";
    }

    private PrepareTimeData GetData()
    {
        PrepareTimeData pData = new PrepareTimeData();
        pData.REFTABLEMED = "ORDERMEDICALSET";
        pData.CHECKTIME = DateTime.Now;
        pData.PREPAREMEAL = cmbMeal.SelectedItem.Value;
        pData.ISTRANSFER = "N";
        return pData;
    }


    #endregion

    #region Working Method

    private string strCondition()
    {
        #region where
        string str = "";
        //หอผู้ป่วย
        if (cmbWard.SelectedItem.Value != "0")
        {
            str += (str == "" ? " " : " AND ") + " WARDID = " + this.cmbWard.SelectedItem.Value + "";
        }

        //หน่วยงาน
        str += (str == "" ? " " : " AND ") + " DIVISION = " + Appz.LoggedOnUser.DIVISION.ToString() + "";

        //ประเภทอาหาร
        if (cmbCategory.SelectedItem.Value != "0")
        {
            str += (str == "" ? " " : " AND ") + " FOODCATEGORY = " + this.cmbCategory.SelectedItem.Value + "";
        }

        //ชนิดอาหาร
        if (cmbType.SelectedItem.Value != "0")
        {
            str += (str == "" ? " " : " AND ") + " FOODTYPE = " + this.cmbType.SelectedItem.Value + "";
        }

        //ชื่อ-สกุลผู้ป่วย
        if (txtPatientName.Text.Trim() != "")
            str += (str == "" ? " " : " AND ") + " UPPER(PATIENTNAME) LIKE UPPER('%" + txtPatientName.Text.Trim() + "%')";

        //HN
        if (txtHN.Text.Trim() != "")
            str += (str == "" ? " " : " AND ") + " UPPER(HN) LIKE UPPER('%" + txtHN.Text.Trim() + "%')";

        //AN
        if (txtAN.Text.Trim() != "")
            str += (str == "" ? " " : " AND ") + " UPPER(AN) LIKE UPPER('%" + txtAN.Text.Trim() + "%')";

        //VN
        if (txtVN.Text.Trim() != "")
            str += (str == "" ? " " : " AND ") + " UPPER(VN) LIKE UPPER('%" + txtVN.Text.Trim() + "%')";

        //วันที่สั่งอาหาร
        if (ctlOrderDate.DateValue.Year.ToString() != "1")
        {
            String sdate = ctlOrderDate.DateValue.Day.ToString() + '/' + ctlOrderDate.DateValue.Month.ToString() + '/' + Convert.ToString(ctlOrderDate.DateValue.Year);
            str += (str == "" ? " " : " AND ") + " ORDERDATE = TO_DATE('" + sdate + "','DD/MM/YYYY')";
        }

        //เวลาสั่งอาหาร
        if (txtOrderTimeFrom.Text.Trim() != "" && txtOrderTimeTo.Text.Trim() != "")
            str += (str == "" ? " " : " AND ") + " SUBSTR(ORDERTIME,1,2)||SUBSTR(ORDERTIME,4,5) BETWEEN '" + txtOrderTimeFrom.Text.Trim() + "' AND '" + txtOrderTimeTo.Text.Trim() + "'";
        else if (txtOrderTimeFrom.Text.Trim() != "")
            str += (str == "" ? " " : " AND ") + " SUBSTR(ORDERTIME,1,2)||SUBSTR(ORDERTIME,4,5) >= '" + txtOrderTimeFrom.Text.Trim() + "'";
        else if (txtOrderTimeTo.Text.Trim() != "")
            str += (str == "" ? " " : " AND ") + " SUBSTR(ORDERTIME,1,2)||SUBSTR(ORDERTIME,4,5) <= '" + txtOrderTimeTo.Text.Trim() + "'";

        //วันที่ Register
        if (ctlRegDate.DateValue.Year.ToString() != "1")
        {
            String sr = ctlRegDate.DateValue.Day.ToString() + '/' + ctlRegDate.DateValue.Month.ToString() + '/' + Convert.ToString(ctlRegDate.DateValue.Year);
            str += (str == "" ? " " : " AND ") + " REGISTERDATE = TO_DATE('" + sr + "','DD/MM/YYYY')";
        }

        //เวลา  Register
        if (txtRegTimeFrom.Text.Trim() != "" && txtRegTimeTo.Text.Trim() != "")
            str += (str == "" ? " " : " AND ") + " SUBSTR(REGISTERTIME,1,2)||SUBSTR(REGISTERTIME,4,5) BETWEEN '" + txtRegTimeFrom.Text.Trim() + "' AND '" + txtRegTimeTo.Text.Trim() + "'";
        else if (txtRegTimeFrom.Text.Trim() != "")
            str += (str == "" ? " " : " AND ") + " SUBSTR(REGISTERTIME,1,2)||SUBSTR(REGISTERTIME,4,5) >= '" + txtRegTimeFrom.Text.Trim() + "'";
        else if (txtRegTimeTo.Text.Trim() != "")
            str += (str == "" ? " " : " AND ") + " SUBSTR(REGISTERTIME,1,2)||SUBSTR(REGISTERTIME,4,5) <= '" + txtRegTimeTo.Text.Trim() + "'";

        #endregion

        return str;
    }

    private void doGetList()
    {
        OrderPatientSetFlow oFlow = new OrderPatientSetFlow();
        DataTable dt = new DataTable();
        PagedDataSource dsPaged = new PagedDataSource();
        string str = strCondition();
        string orderStr = "";

        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;

        App_Prepare_Control_OrderPatientSetCtl.StrWhr = str;

        #region Set Control

        dt = oFlow.GetOrderPatientList(str, orderStr);
        ArrayList arr = new ArrayList();
        txtConcat.Text = "";
        if (dt.Rows.Count != 0)
        {
            arr.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                VOrderWaitRegisterData vData = new VOrderWaitRegisterData();
                vData.ORDERNO = Convert.ToDouble(i + 1);
                vData.ADMITPATIENT = Convert.ToDouble(dt.Rows[i]["ADMITPATIENT"].ToString());
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
                vData.ADMITPATIENT =  Convert.ToDouble(dt.Rows[i]["ADMITPATIENT"].ToString());
                if (dt.Rows[i]["BIRTHDATE"].ToString() != "")
                    vData.BIRTHDATE = Convert.ToDateTime(dt.Rows[i]["BIRTHDATE"]);
                arr.Add(vData);
           }
        }
        dsPaged.DataSource = arr;
        dsPaged.AllowPaging = true;
        dsPaged.PageSize = 20;
        dsPaged.CurrentPageIndex = CurrentPageIndex;
       
        gvResult.DataSource = dsPaged;
        gvResult.DataBind();
        txtQty.Text = dsPaged.DataSourceCount.ToString();

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
       
    }

    protected void gvResult_ItemDataBound(Object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lblAge = (Label)(e.Item.FindControl("lblAge"));


            VOrderWaitRegisterData ItemDat = (VOrderWaitRegisterData)e.Item.DataItem;
            if (ItemDat.BIRTHDATE.ToString() != "")
            {
                if (ItemDat.BIRTHDATE.ToString("MMdd") == DateTime.Today.AddDays(1).ToString("MMdd"))
                    lblAge.BackColor = System.Drawing.Color.Gold;
                else if (ItemDat.BIRTHDATE.ToString("MMdd") == DateTime.Today.ToString("MMdd"))
                    lblAge.ForeColor = System.Drawing.Color.Red;
            }
        }

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

        OrderPatientSetFlow oFlow = new OrderPatientSetFlow();
        //dd = oFlow.GetOrderPatientData(strCondition(),"");
        dd = oFlow.GetOrderPatientList(strCondition(), "");
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
        if (pData.CHECKTIME.ToString()  == "")
            ret = string.Format(DataResources.MSGEI001, "วันที่");
        else if (pData.PREPAREMEAL.ToString()  == "0")
            ret = string.Format(DataResources.MSGEI001, "มื้อ");

        return ret;
    }
    #endregion
   
}
