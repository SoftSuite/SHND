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
using SHND.Flow.Formula;
using SHND.Data.Order;
using SHND.Data.Tables;
using SHND.Global;
using SHND.Flow.Common;
using SHND.Data.Common.Utilities;
using SHND.Flow.Order;
using SHND.DAL.Views;
using SHND.DAL.Tables;


public partial class App_Order_Transaction_OrderWelfare : System.Web.UI.Page
{
    Double Amount;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           doGetList();
        }
    }

    private void SetStatusCombo(DropDownList cmbStatus)
    {
        cmbStatus.Items.Clear();
        cmbStatus.Items.Add(new ListItem("กำลังดำเนินการ", "00"));
        cmbStatus.Items.Add(new ListItem("ฝ่ายโภชนาการรับ Order", "01"));
        cmbStatus.Items.Add(new ListItem("ยกเลิกการสั่งอาหาร", "02"));
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        SetStatusCombo(cmbSearchStatusFrom);
        SetStatusCombo(cmbSearchStatusTo);

       Appz.BuildCombo(cmbDiv, "DIVISION", "NAME", "LOID", "ISWELFARE ='Y' AND MAINDIVISION IS NULL ", "NAME","เลือก" ,"0", false);
        
        pcTop.SetMainGridView(gvMain);
        pcBot.SetMainGridView(gvMain);

        ControlUtil.SetIntTextBox(this.MonM);
        ControlUtil.SetIntTextBox(this.MonL);
        ControlUtil.SetIntTextBox(this.MonE);
        ControlUtil.SetIntTextBox(this.TueM);
        ControlUtil.SetIntTextBox(this.TueL);
        ControlUtil.SetIntTextBox(this.TueE);
        ControlUtil.SetIntTextBox(this.WenM);
        ControlUtil.SetIntTextBox(this.WenL);
        ControlUtil.SetIntTextBox(this.WenE);
        ControlUtil.SetIntTextBox(this.ThM);
        ControlUtil.SetIntTextBox(this.ThL);
        ControlUtil.SetIntTextBox(this.ThE);
        ControlUtil.SetIntTextBox(this.FriM);
        ControlUtil.SetIntTextBox(this.FriL);
        ControlUtil.SetIntTextBox(this.FriE);
        ControlUtil.SetIntTextBox(this.SatM);
        ControlUtil.SetIntTextBox(this.SatL);
        ControlUtil.SetIntTextBox(this.SatE);
        ControlUtil.SetIntTextBox(this.SunM);
        ControlUtil.SetIntTextBox(this.SunL);
        ControlUtil.SetIntTextBox(this.SunE);
    }


    #region Button Click Event Handler

    protected void imbSearch_Click(object sender, ImageClickEventArgs e)
    {
        gvMain.PageIndex = 0;
        doGetList();
    }
    protected void tbAddClick(object sender, EventArgs e)
    { 
        zPop.Show();
    }

    protected void tbDeleteClick(object sender, EventArgs e)
    {
        doDelete();
    }

    protected void tbSave1Click(object sender, EventArgs e)
    {
        string status = this.txtStatus.Text;
        this.txtStatus.Text = "WA";
        if (!doSave())
            this.txtStatus.Text = status;
        else
        {
            doGetDetail(txhID.Text);

        }
         zPop.Show();  
    }

    protected void tbSave2Click(object sender, EventArgs e)
    {
        if (txhID.Text.Trim() == "")
            ClearData();
        else
            doGetDetail(txhID.Text);
        zPop.Show();

    }
    protected void tbSave3Click(object sender, EventArgs e)
    {
        string status = this.txtStatus.Text;
        this.txtStatus.Text = "RG";
        if (!doSave())
            this.txtStatus.Text = status;
        else
            doGetDetail(txhID.Text);
        zPop.Show();  
    }
    protected void tbSave4Click(object sender, EventArgs e)
    {
        string status = this.txtStatus.Text;
        this.txtStatus.Text = "DC";
        if (!doSave())
            this.txtStatus.Text = status;
        else
            doGetDetail(txhID.Text);
        zPop.Show();  
    }

    protected void tbCommitClick(object sender, EventArgs e)
    {
        doUpdateByCheck();
    }

    protected void tbBackClick(object sender, EventArgs e)
    {
        ClearData();
   }

    protected void linkCode_Click(Object sender, EventArgs e)
    {
        doGetDetail(((LinkButton)sender).CommandArgument);
        zPop.Show();
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
        OrderWelfareFlow sFlow = new OrderWelfareFlow();
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
   
    private void SetControl()
    {
        bool enable = this.tbSave.Visible;
        this.txtRef.ReadOnly = !enable;
        this.txtRef.CssClass = (enable ? "zTextbox" : "zTextbox-View");
        this.CalendarControl3.Enabled = enable;
        //this.CalendarControl4.Enabled = enable;
        //this.CalendarControl5.Enabled = enable;
        this.cmbDiv.Enabled = enable;

        this.MonM.ReadOnly = !enable;
        this.MonM.CssClass = (enable ? "zTextboxR" : "zTextboxR-View");
        this.MonL.ReadOnly = !enable;
        this.MonL.CssClass = (enable ? "zTextboxR" : "zTextboxR-View");
        this.MonE.ReadOnly = !enable;
        this.MonE.CssClass = (enable ? "zTextboxR" : "zTextboxR-View");

        this.TueM.ReadOnly = !enable;
        this.TueM.CssClass = (enable ? "zTextboxR" : "zTextboxR-View");
        this.TueL.ReadOnly = !enable;
        this.TueL.CssClass = (enable ? "zTextboxR" : "zTextboxR-View");
        this.TueE.ReadOnly = !enable;
        this.TueE.CssClass = (enable ? "zTextboxR" : "zTextboxR-View");

        this.WenE.ReadOnly = !enable;
        this.WenM.CssClass = (enable ? "zTextboxR" : "zTextboxR-View");
        this.WenL.ReadOnly = !enable;
        this.WenL.CssClass = (enable ? "zTextboxR" : "zTextboxR-View");
        this.WenE.ReadOnly = !enable;
        this.WenE.CssClass = (enable ? "zTextboxR" : "zTextboxR-View");

        this.ThM.ReadOnly = !enable;
        this.ThM.CssClass = (enable ? "zTextboxR" : "zTextboxR-View");
        this.ThL.ReadOnly = !enable;
        this.ThL.CssClass = (enable ? "zTextboxR" : "zTextboxR-View");
        this.ThE.ReadOnly = !enable;
        this.ThE.CssClass = (enable ? "zTextboxR" : "zTextboxR-View");

        this.FriM.ReadOnly = !enable;
        this.FriM.CssClass = (enable ? "zTextboxR" : "zTextboxR-View");
        this.FriL.ReadOnly = !enable;
        this.FriL.CssClass = (enable ? "zTextboxR" : "zTextboxR-View");
        this.FriE.ReadOnly = !enable;
        this.FriE.CssClass = (enable ? "zTextboxR" : "zTextboxR-View");

        this.SatM.ReadOnly = !enable;
        this.SatM.CssClass = (enable ? "zTextboxR" : "zTextboxR-View");
        this.SatL.ReadOnly = !enable;
        this.SatL.CssClass = (enable ? "zTextboxR" : "zTextboxR-View");
        this.SatE.ReadOnly = !enable;
        this.SatE.CssClass = (enable ? "zTextboxR" : "zTextboxR-View");

        this.SunM.ReadOnly = !enable;
        this.SunM.CssClass = (enable ? "zTextboxR" : "zTextboxR-View");
        this.SunL.ReadOnly = !enable;
        this.SunL.CssClass = (enable ? "zTextboxR" : "zTextboxR-View");
        this.SunE.ReadOnly = !enable;
        this.SunE.CssClass = (enable ? "zTextboxR" : "zTextboxR-View");

    }

    private void ClearData()
    {
        this.tbSave.Visible = true;
        this.tbSave2.Visible = true;
        this.tbSave3.Visible = true;
        this.tbSave4.Visible = false;

        txhID.Text = "";
        txhSortDir.Text = "";
        this.txtStatus.Text = "WA";
        txtIDReq.Text = "";
        txtRef.Text = "";
        txtSearchCodeFrom.Text = "";
        txtSearchCodeTo.Text = "";
        txtStatusRef.Text = "กำลังดำเนินการ";
        txtSumOrder.Text = "";
        txtSumOrderCu.Text = "";
        ctlSearchDateFrom.DateValue = new DateTime();
        ctlSearchDateTo.DateValue = new DateTime();
        CalendarControl3.DateValue = new DateTime();
       // CalendarControl4.DateValue = new DateTime();
       // CalendarControl5.DateValue = new DateTime();
        cmbMonthFrom.SelectedValue = "0";
        cmbMonthTo.SelectedValue = "0";
        txtYearFrom.Text = "";
        txtYearTo.Text = "";

        ctlRefDate.DateValue = new DateTime();

        this.txtStatus.Text = "";
        cmbDiv.SelectedIndex = 0;
        gvMain1.DataBind();

        MonM.Text = "";
        MonL.Text = "";
        MonE.Text = "";
        
        TueM.Text = "";
        TueL.Text = "";
        TueE.Text = "";
        
        WenM.Text = "";
        WenL.Text = "";
        WenE.Text = "";
        
        ThM.Text = "";
        ThL.Text = "";
        ThE.Text = "";
        
        FriM.Text = "";
        FriL.Text = "";
        FriE.Text = "";
        
        SatM.Text = "";
        SatL.Text = "";
        SatE.Text = "";

        SunM.Text = "";
        SunL.Text = "";
        SunE.Text = "";

        SetControl();
    }

    private void SetErrorStatus(string t)
    {
        lbStatus.Text = t;
        lbStatus.ForeColor = Constant.StatusColor.Error;
    }

    private void SetStatus(string t)
    {
        lbStatus.Text = t;
        lbStatus.ForeColor = Constant.StatusColor.Information;
    }


    #endregion

    #region Working Method

    private void doGetList()
    {
        OrderWelfareFlow sFlow = new OrderWelfareFlow();
         
        string orderStr = "";
        this.imbReset.Visible = (this.txtSearchCodeFrom.Text.Trim() != "") || (this.txtSearchCodeTo.Text.Trim() != "") || (this.ctlSearchDateFrom.DateValue.Year != 1) || (this.ctlSearchDateTo.DateValue.Year != 1) ||
            (this.cmbSearchStatusFrom.SelectedIndex != 0) || (this.cmbSearchStatusTo.SelectedIndex != 0);
        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;
            
        gvMain.DataSource = sFlow.GetMasterList(txtSearchCodeFrom.Text, txtSearchCodeTo.Text, ctlSearchDateFrom.DateValue, ctlSearchDateTo.DateValue, cmbSearchStatusFrom.SelectedItem.Value, cmbSearchStatusTo.SelectedItem.Value, orderStr);

        gvMain.DataBind();
        pcTop.Update();
        pcBot.Update();

    }
    private void doGetListDivision()
    {
        if (this.cmbDiv.SelectedItem.Value == "0")
        {
            gvMain1.DataSource = new DataTable();
            gvMain1.DataBind();
        }
        else
        {
            OrderWelfareFlow sFlow = new OrderWelfareFlow();
            gvMain1.DataSource = sFlow.GetMasterListByDivision(Convert.ToDouble(cmbDiv.SelectedItem.Value));
            gvMain1.DataBind();
        }
       

    }
    

    private bool doGetDetail(string LOID)
    {
        
        OrderWelfareFlow sFlow = new OrderWelfareFlow();
       VOrderWelfareData  sData = sFlow.GetDetails(Convert.ToDouble(LOID));

        bool ret = true;

        if (sData.LOID != 0)
        {
            if (sData.STATUS == "RG")
            { 
                tbSave3.Visible = false;
                tbSave4.Visible = true;
            }
        //   else if (sData .STATUS == ""

         /*   VOrderWelfareData VOrderWelfare = new VOrderWelfareData();
            if (VOrderWelfare.STATUS == "")
            {
                tbSave4.Visible = false;
            }
            if (VOrderWelfare.STATUS == "WA")
            {
                tbSave4.Visible = false;
            }
            if (VOrderWelfare.STATUS == "DC")
            {
                tbSave4.Visible = false;
            }
*/


            SetData(sData);
        }
        else
            ret = false;

        return ret;
    }




    private bool doSave()
    {
        VOrderWelfareData sData = GetData();
        //txtTiffin.Text = sData.TIFFIN.ToString();
        string error = VerifyData(sData);
        if (error != "")
        {
            SetErrorStatus(error);
            return false;
        }
        OrderWelfareFlow stFlow = new OrderWelfareFlow();
      
        bool ret = true;
        

        // verify uniq field

      /*  if (!stFlow.CheckUniqCode(txtRef.Text.Trim(), txhID.Text.Trim())) 
        {
            SetErrorStatus("เลขที่ขอเบิกซ้ำ");
            return false;
        } */
        // data correct go on saving...
        if (txhID.Text.Trim() == "")
        {

            //  save new
            ret = stFlow.InsertData(sData, Appz.CurrentUser);
         
        }
        else
        {
            // save update
            ret = stFlow.UpdateData(sData, Appz.CurrentUser);
        }

        if (!ret)
            SetErrorStatus(stFlow.ErrorMessage);
        else
        {
            doGetDetail(stFlow.LOID.ToString());
            if (sData.LOID != 0)
                SetStatus(DataResources.MSGIU001);
            else
                SetStatus(DataResources.MSGIN001);
        }
        //else
        //    this.txhID.Text = stFlow.LOID.ToString();

        return ret;

    }

    private string VerifyData(VOrderWelfareData sData)
    {
        string ret = "";

        if (sData.REFCODE.ToString() == "")
            ret = string.Format(DataResources.MSGEI001, "เลขที่เอกสารอ้างอิง");
        else if (sData.REFDATE.Year == 1)
            ret = string.Format(DataResources.MSGEI002, "วันที่ของเอกสารอ้างอิง");
        else if (cmbMonthFrom.SelectedValue == "0" || txtYearFrom.Text == "")
            ret = string.Format(DataResources.MSGEI002, "ระยะเวลาเริ่มต้น");
        else if (cmbMonthTo.SelectedValue == "0" || txtYearTo.Text == "")
            ret = string.Format(DataResources.MSGEI002, "ระยะเวลาสิ้นสุด");
        else if (sData.DIVISION == 0)
            ret = string.Format(DataResources.MSGEI002, "หน่วยงาน");
        else if (radTiffin.SelectedValue == "N" & (sData.TIFFIN < sData.COUPON))
        {
            OrderWelfareFlow sFlow = new OrderWelfareFlow();
            if (sFlow.GetTiffinOver(Convert.ToDouble(cmbDiv.SelectedValue), Convert.ToDouble(cmbMonthFrom.SelectedValue), Convert.ToDouble(txtYearFrom.Text), Convert.ToDouble(cmbMonthTo.SelectedValue), Convert.ToDouble(txtYearTo.Text)) == "N")
            ret = "จำนวนคูปองที่ขอรับบริการมากกว่าจำนวนสิทธิ์ที่ได้รับ";
        txtSumOrderCu.Text = sData.COUPON.ToString();
        txtTiffin.Text = sData.TIFFIN.ToString();
        }
        
        return ret;
   
    }


    private void doDelete()
    {
        OrderWelfareFlow sFlow = new OrderWelfareFlow();
        //SupplierFlow sFlow = new SupplierFlow();
        if (sFlow.DeleteByLOID(GetChecked()))
        {
            gvMain.PageIndex = 0;
            doGetList();
            lbStatusMain.Text = "";
        }
        else
        {
            lbStatusMain.Text = sFlow.ErrorMessage;
            lbStatusMain.ForeColor = System.Drawing.Color.Red;
        }
    }

        private void doUpdateByCheck()
    {
        OrderWelfareFlow sFlow = new OrderWelfareFlow();
        //SupplierFlow sFlow = new SupplierFlow();
        if (sFlow.UpdateByLOID(Appz.CurrentUser, GetChecked()))
        {
            gvMain.PageIndex = 0;
            doGetList();
            lbStatusMain.Text = "";
        }
        else
        {
            lbStatusMain.Text = sFlow.ErrorMessage;
            lbStatusMain.ForeColor = System.Drawing.Color.Red;
        }

    }



    #endregion

    #region Controls Management Methods

    private ArrayList GetOrderWelfareItemData()
    {
        ArrayList arrData = new ArrayList();
        Amount = 0;
        for (int i = 0; i < gvMain1.Rows.Count; i++)
        {
            OrderWelfareItemData sData = new OrderWelfareItemData();
            sData.QTY = Convert.ToDouble("0" + ((TextBox)gvMain1.Rows[i].Cells[3].FindControl("txtOrder")).Text);
            sData.ORDERWELFARE = Convert.ToDouble("0" + txhID.Text);
            sData.SUBDIVISION = Convert.ToDouble("0" + gvMain1.Rows[i].Cells[4].Text);
            arrData.Add(sData);
            Amount += sData.QTY;
        }
        return arrData;
    }
    private double CalculateCupon()
    {
        VOrderWelfareData ftData = new VOrderWelfareData();
      
        
        DateTime SDate,FDate;
        int MonD = 0, TueD = 0, WenD = 0, ThuD = 0, FriD = 0, SatD = 0, SunD = 0;
        double   m, t, w, th, f, sa, su;

        double SumOfDay = 0;
        SDate = new DateTime(int.Parse(txtYearFrom.Text)-543,int.Parse(cmbMonthFrom.SelectedValue),1);
        FDate = new DateTime(int.Parse(txtYearTo.Text) - 543, int.Parse(cmbMonthTo.SelectedValue)+1, 1).AddDays(-1);
        while (SDate <= FDate) 
        {
            switch (SDate.DayOfWeek.ToString())
            {
                case "Sunday" : 
                    SunD = SunD + 1;
                    break; 
                case "Monday" : 
                    MonD = MonD + 1;
                    break;
                case "Tuesday": 
                    TueD = TueD + 1;
                    break;
                case "Wednesday" :
                    WenD = WenD + 1;
                    break;
                case "Thursday":
                    ThuD = ThuD + 1;
                    break;
                case "Friday":
                    FriD = FriD + 1;
                    break;
                case "Saturday":
                    SatD = SatD + 1;
                    break;
            }
            SDate = SDate.AddDays(1);
        }

        m = Convert.ToDouble(MonM.Text) + Convert.ToDouble(MonL.Text) + Convert.ToDouble(MonE.Text);
        t = Convert.ToDouble(TueM.Text) + Convert.ToDouble(TueL.Text) + Convert.ToDouble(TueE.Text);
        w = Convert.ToDouble(WenM.Text) + Convert.ToDouble(WenL.Text) + Convert.ToDouble(WenE.Text);
        th = Convert.ToDouble(ThM.Text) + Convert.ToDouble(ThL.Text) + Convert.ToDouble(ThE.Text);
        f = Convert.ToDouble(FriM.Text) + Convert.ToDouble(FriL.Text) + Convert.ToDouble(FriE.Text);
        sa = Convert.ToDouble(SatM.Text) + Convert.ToDouble(SatL.Text) + Convert.ToDouble(SatE.Text);
        su = Convert.ToDouble(SunM.Text) + Convert.ToDouble(SunL.Text) + Convert.ToDouble(SunE.Text);
        su = SunD * su;
        m = MonD * m;
        t = TueD * t;
        w = WenD * w;
        th = ThuD * th;
        f = FriD * f;
        sa = SatD * sa;


        SumOfDay += su + m + t + w + th + f + sa;
       // txtSumOrder.Text  = Convert.ToString (SumOfDay);
        return SumOfDay;
    }


    private VOrderWelfareData GetData()
    {
       
        VOrderWelfareData sData = new VOrderWelfareData();

        sData.ORDERCODE = txtIDReq.Text; //เลขที่การสั่งอาหารสวัสดิการ
        sData.ORDERDATE = DateTime.Now;  // วันที่ขอเบิก
        sData.DIVISION = Convert.ToDouble(cmbDiv.SelectedItem.Value);

        sData.STARTDATE = new DateTime(int.Parse(txtYearFrom.Text) - 543, int.Parse(cmbMonthFrom.SelectedValue), 1);

        sData.FINISHDATE = new DateTime(int.Parse(txtYearTo.Text) - 543, int.Parse(cmbMonthTo.SelectedValue) + 1, 1).AddDays(-1);
        sData.LOID = Convert.ToDouble("0" + txhID.Text);
        sData.STATUS = this.txtStatus.Text;
        sData.ISTIFFIN = radTiffin.SelectedValue;
        
        //if (sData.STATUS == "WA" )
        //{
        //    sData.STATUS = "RG";
        //    sData.LOID = Convert.ToDouble(txhID.Text);
        //}
        //else 
           
        //{
        //    St = 0;
        //    if (sData.STATUS == "RG")
        //    {
        //        sData.STATUS = "DC";
        //        sData.LOID = Convert.ToDouble(txhID.Text);
        //    }
        //    if (sData.STATUS == "")
        //    {
        //        sData.STATUS = "WA";
              
        //    }
        //}

        //this.txtStatus.Text;
        sData.REFCODE = txtRef.Text; //เลขที่เอกสารอ้างอิง Nullable

        sData.REFDATE = CalendarControl3.DateValue;  //ลงวันที่
        sData.OrderWelfareItemList = GetOrderWelfareItemData();

        sData.BD1 = Convert.ToDouble(MonM.Text);
        sData.BD2 = Convert.ToDouble(TueM.Text);
        sData.BD3 = Convert.ToDouble(WenM.Text);
        sData.BD4 = Convert.ToDouble(ThM.Text);
        sData.BD5 = Convert.ToDouble(FriM.Text);
        sData.BD6 = Convert.ToDouble(SatM.Text);
        sData.BD7 = Convert.ToDouble(SunM.Text);

        sData.LD1 = Convert.ToDouble(MonL.Text);
        sData.LD2 = Convert.ToDouble(TueL.Text);
        sData.LD3 = Convert.ToDouble(WenL.Text);
        sData.LD4 = Convert.ToDouble(ThL.Text);
        sData.LD5 = Convert.ToDouble(FriL.Text);
        sData.LD6 = Convert.ToDouble(SatL.Text);
        sData.LD7 = Convert.ToDouble(SunL.Text);

        sData.DD1 = Convert.ToDouble(MonE.Text);
        sData.DD2 = Convert.ToDouble(TueE.Text);
        sData.DD3 = Convert.ToDouble(WenE.Text);
        sData.DD4 = Convert.ToDouble(ThE.Text);
        sData.DD5 = Convert.ToDouble(FriE.Text);
        sData.DD6 = Convert.ToDouble(SatE.Text);
        sData.DD7 = Convert.ToDouble(SunE.Text);

        sData.COUPON = this.CalculateCupon();
        OrderWelfareFlow stFlow = new OrderWelfareFlow();

        sData.TIFFIN = stFlow.GetTiffin(Convert.ToDouble(cmbDiv.SelectedValue), Convert.ToDouble(cmbMonthFrom.SelectedValue), Convert.ToDouble(txtYearFrom.Text), Convert.ToDouble(cmbMonthTo.SelectedValue), Convert.ToDouble(txtYearTo.Text));
        sData.AMOUNT =Amount;
        return sData;
    }

    private void SetData(VOrderWelfareData ftData)
    {
       
        txhID.Text = ftData.LOID.ToString();
        txtIDReq.Text = ftData.ORDERCODE;//เลขที่ขอเบิก
        txtRef.Text = ftData.REFCODE; //เลขที่อ้างอิง
        cmbDiv.SelectedIndex = cmbDiv.Items.IndexOf(cmbDiv.Items.FindByText(ftData.DIVISION.ToString()));
        txtStatusRef.Text = ftData.STATUSNAME;
        //txtSumOrder.Text = Convert.ToString(ftData.SUMQTY);
        txtSumOrder.Text = Convert.ToString(ftData.AMOUNT);
        this.txtStatus.Text = ftData.STATUS;
        this.txhID.Text = ftData.LOID.ToString();
        ctlRefDate.DateValue  =Convert.ToDateTime(ftData.ORDERDATE.ToShortDateString());
        CalendarControl3.DateValue = ftData.REFDATE;
        //CalendarControl4.DateValue = ftData.STARTDATE;
        //CalendarControl5.DateValue = ftData.FINISHDATE;
        cmbMonthFrom.SelectedValue = ftData.STARTDATE.Month.ToString();
        cmbMonthTo.SelectedValue = ftData.FINISHDATE.Month.ToString();
        txtYearFrom.Text = (ftData.STARTDATE.Year+543).ToString();
        txtYearTo.Text = (ftData.FINISHDATE.Year+543).ToString();
    //************    txtSumOrder.Text  = CalculateCupon();

        cmbDiv.SelectedValue =  Convert.ToString (ftData.DIVISION);
        radTiffin.SelectedValue = ftData.ISTIFFIN;
       this.gvMain1.DataSource = ftData.OrderWelfareItemTable;
        this.gvMain1.DataBind();

        MonM.Text = Convert.ToString(ftData.BD1);
        TueM.Text = Convert.ToString(ftData.BD2);
        WenM.Text = Convert.ToString(ftData.BD3);
        ThM.Text = Convert.ToString(ftData.BD4);
        FriM.Text = Convert.ToString(ftData.BD5);
        SatM.Text = Convert.ToString(ftData.BD6);
        SunM.Text = Convert.ToString(ftData.BD7);

        MonL.Text = Convert.ToString(ftData.LD1);
        TueL.Text = Convert.ToString(ftData.LD2);
        WenL.Text = Convert.ToString(ftData.LD3);
        ThL.Text = Convert.ToString(ftData.LD4);
        FriL.Text = Convert.ToString(ftData.LD5);
        SatL.Text =Convert.ToString(ftData.LD6);
        SunL.Text =Convert.ToString(ftData.LD7);

        MonE.Text = Convert.ToString(ftData.DD1);
        TueE.Text = Convert.ToString(ftData.DD2);
        WenE.Text = Convert.ToString(ftData.DD3);
        ThE.Text = Convert.ToString(ftData.DD4);
        FriE.Text = Convert.ToString(ftData.DD5);
        SatE.Text = Convert.ToString(ftData.DD6);
        SunE.Text = Convert.ToString(ftData.DD7);
        txtSumOrderCu.Text = Convert.ToString(ftData.COUPON);

        this.tbSave.Visible = (this.txtStatus.Text == "WA") || (this.txtStatus.Text == "");
        this.tbSave2.Visible = this.tbSave.Visible;
        this.tbSave3.Visible = this.tbSave.Visible;
        this.tbSave4.Visible = (this.txtStatus.Text == "RG");

        OrderWelfareFlow stFlow = new OrderWelfareFlow();
        txtTiffin.Text = stFlow.GetTiffin(ftData.DIVISION, ftData.STARTDATE.Month, ftData.STARTDATE.Year+543, ftData.FINISHDATE.Month, ftData.FINISHDATE.Year+543).ToString();

        SetControl();
    }

    #endregion

    protected void cmbDiv_SelectedIndexChanged(object sender, EventArgs e)
    {
        doGetListDivision();
       zPop.Show();
    }


    protected void gvMain1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox txtOrder = (TextBox)e.Row.Cells[3].FindControl("txtOrder");
            txtOrder.ReadOnly = (this.txtStatus.Text != "WA" && this.txtStatus.Text != "");
            txtOrder.CssClass = (txtOrder.ReadOnly ? "zTextboxR-View" : "zTextboxR");
        }
    }

    protected void imbReset_Click(object sender, ImageClickEventArgs e)
    {
        this.txtSearchCodeFrom.Text = "";
        this.txtSearchCodeTo.Text = "";
        this.ctlSearchDateFrom.DateValue = new DateTime();
        this.ctlSearchDateTo.DateValue = new DateTime();
        this.cmbSearchStatusFrom.SelectedIndex = 0;
        this.cmbSearchStatusTo.SelectedIndex = 0;

        gvMain.PageIndex = 0;
        doGetList();
    }

    protected void radTiffin_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (radTiffin.SelectedValue == "N")
        {
            lblTiffin.Visible = true;
            txtTiffin.Visible = true;
        }
        else
        {
            lblTiffin.Visible = false;
            txtTiffin.Visible = false;
        }
        zPop.Show();
    }
}
