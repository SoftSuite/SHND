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
using SHND.Data;
using SHND.Global;
using SHND.Flow.Common;
using SHND.Data.Common.Utilities;
using SHND.Data.Views;
using SHND.Data.Tables;

/// <summary>
/// CutOrder Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Nang
/// Create Date: 12 May 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้ากาารทำงานข้อมูลการตัดยอดก่อนเตรียม Cut Order
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 


public partial class App_Prepare_Transaction_CutOrder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cmbSearchStatusFrom.SelectedIndex = -1;
            cmbSearchStatusTo.SelectedIndex = -1;

        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        // set Combo source
        Appz.BuildCombo(cmbSearchDivision, "DIVISION", "NAME", "LOID", "ISSTOCKOUT = 'Y' AND ACTIVE='1'", "NAME", "ทั้งหมด", "0", false);
        Appz.BuildCombo(cmbDivision, "DIVISION", "NAME", "LOID", "ACTIVE='1'", "NAME", "ทั้งหมด", "0", false);
        Appz.BuildCombo(cmbWareHouse, "WAREHOUSE", "NAME", "LOID", "", "NAME", "ทั้งหมด", "0", false);
        Appz.BuildCombo(cmbDoctype, "DOCTYPE", "DOCNAME", "LOID", "", "NAME", "ทั้งหมด", "0", false);
        pcTop.SetMainGridView(gvMain);
        pcBot.SetMainGridView(gvMain);
        pcTop2.SetMainGridView(grvItem);
        pcBot2.SetMainGridView(grvItem);

    }


    #region Button Click Event Handler

    protected void tbSaveClick(object sender, EventArgs e)
    {
        if (!doSave())
            zPop.Show();
        else
            zPop.Show();

    }

    protected void tbBackClick(object sender, EventArgs e)
    {
        ClearData();
    }

    protected void tbReturnClick(object sender, EventArgs e)
    {
        doGetDetail(txhID.Text.Trim());
        zPop.Show();
    }

    protected void tbApproveClick(object sender, EventArgs e)
    {
        if (doSave())
        {
            if (doApprove())
            {
                zPop.Show();
                doGetDetail(txhID.Text.Trim());
            }
            else
                zPop.Show();
        }
        else
            zPop.Show();
    }


    protected void lnkType_Click(object sender, EventArgs e)
    {
        doGetDetail(((LinkButton)sender).CommandArgument);
        zPop.Show();
    }

    protected void imbSearch_Click(object sender, ImageClickEventArgs e)
    {
        gvMain.PageIndex = 0;
        doGetList();
    }

    protected void imgCalculateClick(object sender, EventArgs e)
    {
        PatientCalculate();
        zPop.Show();
    }


    #endregion

    #region Gridview Event Handler


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

    }


    protected void grvItem_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[1].Text = ((e.Row.RowIndex + 1) + (grvItem.PageIndex * grvItem.PageSize)).ToString();

            TextBox txtUseQty = (TextBox)e.Row.FindControl("txtUseQty");
            if (txtUseQty != null)
            {
                ControlUtil.SetDblTextBox(txtUseQty);
            } 
        }
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

    protected void PageChange2(object sender, EventArgs e)
    {
        grvItem.PageIndex = ((Templates_PageControl)sender).SelectedPageIndex;
        doGetDetail(txhID.Text.Trim());
        pcBot2.Update();
        pcTop2.Update();
        zPop.Show();
    }
    #endregion

    #region Misc. Methods

    

    #endregion

    #region Controls Management Methods
    private void SetStatus(string t)
    {
        lbStatus.Text = t;
        lbStatus.ForeColor = Constant.StatusColor.Information;
    }

    private void SetErrorStatus(string t)
    {
        lbStatus.Text = t;
        lbStatus.ForeColor = Constant.StatusColor.Error;
    }

    private void ClearData()
    {
        txhID.Text = "";
        txtCode.Text = "";
        ctlStockoutDate.DateValue = new DateTime(1, 1, 1);
        cmbDivision.SelectedIndex = -1;
        cmbWareHouse.SelectedIndex = -1;
        cmbDoctype.SelectedIndex = -1;
        txtOrderQty.Text = "";
        ctlUseDate.DateValue = new DateTime(1, 1, 1);
        chkBP.Checked = false;
        chkLunch.Checked = false;
        chkDinner.Checked = false;
        txtStatusFlag.Text = "";
        txtStatusName.Text = "";
        grvItem.DataSource = null;
        grvItem.DataBind();
    }


    private void SetData(StockOutData sData,DataTable dt)
    {
        txhID.Text = sData.LOID.ToString();
        cmbDivision.SelectedIndex = cmbDivision.Items.IndexOf(cmbDivision.Items.FindByValue(sData.DIVISION.ToString()));
        txtCode.Text = sData.CODE;
        ctlStockoutDate.DateValue = Convert.ToDateTime(sData.STOCKOUTDATE);
        cmbWareHouse.SelectedIndex = cmbWareHouse.Items.IndexOf(cmbWareHouse.Items.FindByValue(sData.WAREHOUSE.ToString()));
        cmbDoctype.SelectedIndex = cmbDoctype.Items.IndexOf(cmbDoctype.Items.FindByValue(sData.DOCTYPE.ToString()));
        txtOrderQty.Text = sData.ORDERQTY.ToString();
        ctlUseDate.DateValue = Convert.ToDateTime(sData.USEDATE);
        chkBP.Checked = (sData.ISBREAKFAST.ToString() == "Y"?true:false);
        chkLunch.Checked = (sData.ISLUNCH.ToString() == "Y" ? true : false);
        chkDinner.Checked = (sData.ISDINNER.ToString() == "Y" ? true : false);
        txtStatusName.Text = (sData.STATUS == "AP" ? "อนุมัติ" : "เสร็จสิ้น");
        txtStatusFlag.Text = sData.STATUS.ToString();
        tbSave.Visible = (sData.STATUS.ToString() == "FN" ? false : true);
        tbReturn.Visible = (sData.STATUS.ToString() == "FN" ? false : true);
        tbApprove.Visible = (sData.STATUS.ToString() == "FN" ? false : true);
        this.tbPrint.ClientClick = Appz.OpenReportScript(Constant.Reports.CutOrderReport, Convert.ToDouble(txhID.Text.Trim()), false);

       
        grvItem.DataSource = dt;
        grvItem.DataBind();
        pcBot2.Update();
        pcTop2.Update();
        BlockControl(sData.STATUS.ToString());
    }

    private void BlockControl(string st)
    {
        if (grvItem.Rows.Count > 0)
        {
            for (int i=0; i < grvItem.Rows.Count; ++i)
            {
                if (st == "FN")
                {
                    TextBox txtUseQty = (TextBox)grvItem.Rows[i].FindControl("txtUseQty");
                    txtUseQty.CssClass = "zTextboxR-View";
                    txtUseQty.ReadOnly = true ;
                }
                else
                {
                    TextBox txtUseQty = (TextBox)grvItem.Rows[i].FindControl("txtUseQty");
                    txtUseQty.CssClass = "zTextboxR";
                    txtUseQty.ReadOnly = false;
                }
            }
        }
    }


    protected void UseQtyCalculate(object sender, EventArgs e)
    {
        TextBox txtUseQty = (TextBox)sender;
        Calculate(Convert.ToInt32(txtUseQty.ToolTip));
        zPop.Show();
    }

    private void Calculate(int rowindex)
    {
        TextBox txtUseQty = (TextBox)grvItem.Rows[rowindex].FindControl("txtUseQty");
        Label lblQty = (Label)grvItem.Rows[rowindex].FindControl("lblQty");
        Label lblReturn = (Label)grvItem.Rows[rowindex].FindControl("lblReturn");
        if (txtUseQty != null && txtUseQty != null && lblReturn != null)
        {
            double qty = Convert.ToDouble(lblQty.Text.Trim());
            double useqty = Convert.ToDouble(txtUseQty.Text.Trim());
            double rn = qty - useqty ;
            lblReturn.Text = rn.ToString("#,##0.####");
        }
    }


    private DataTable GetData()
    {
        DataTable dt = new DataTable();
        DataColumn dcLOID = new DataColumn("LOID");
        DataColumn dcUSEQTY = new DataColumn("USEQTY");

        dt.Columns.Add(dcLOID);
        dt.Columns.Add(dcUSEQTY);
        for (int i = 0; i < grvItem.Rows.Count; ++i)
        {
            DataRow dr = dt.Rows.Add();
            dr["LOID"] = Convert.ToString(grvItem.Rows[i].Cells[0].Text);

            TextBox txtUseQty = (TextBox)grvItem.Rows[i].FindControl("txtUseQty");
            if (txtUseQty != null)
                dr["USEQTY"] = Convert.ToDouble(txtUseQty.Text.Trim()); 
        }
        return dt;

    }

    private void PatientCalculate()
    {
        CutOrderFlow cFlow = new CutOrderFlow();
        DataTable dt = cFlow.GetPatientCount(Convert.ToDouble(txhID.Text.Trim()));

        if (dt.Rows.Count > 0)
        {
            grvItem.DataSource = dt;
            grvItem.DataBind();
        }
    }

    #endregion

    #region Working Method

    private void doGetList()
    {
        CutOrderFlow cFlow = new CutOrderFlow();
        string str = "";
        string whstatus = "";
        string orderStr = "";
        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;

        if (txtSearchCodeFrom.Text.Trim() != "")
            str += (str == "" ? "" : " AND ") + "CODE >= '" + txtSearchCodeFrom.Text.Trim() + "'";
        if(txtSearchCodeTo.Text.Trim() != "")
            str += (str == "" ? "" : " AND ") + "CODE <= '" + txtSearchCodeTo.Text.Trim() + "'";

        if (ctlUseDateFrom.DateValue.Year != 1)
        {
            string df = ctlUseDateFrom.DateValue.Day.ToString() + '/' + ctlUseDateFrom.DateValue.Month.ToString() + '/' + Convert.ToString(ctlUseDateFrom.DateValue.Year);
            str += (str == "" ? "" : " AND ") + "USEDATE >= TO_DATE('" + df + "','DD/MM/YYYY')";
        }

        if (ctlUseDateTo.DateValue.Year != 1)
        {
            string dt = ctlUseDateTo.DateValue.Day.ToString() + '/' + ctlUseDateTo.DateValue.Month.ToString() + '/' + Convert.ToString(ctlUseDateTo.DateValue.Year);
            str += (str == "" ? "" : " AND ") + "USEDATE <= TO_DATE('" + dt + "','DD/MM/YYYY')";
        }

        if (cmbSearchDivision.SelectedItem.Value != "0")
            str += (str == "" ? "" : " AND ") + "DIVISION = " + cmbSearchDivision.SelectedItem.Value + "";

        if (cmbSearchStatusFrom.SelectedItem.Value != "0")
            whstatus += (whstatus == "" ? "" : ",") + "'"+ cmbSearchStatusFrom.SelectedItem.Value +"'";
        if(cmbSearchStatusTo.SelectedItem.Value != "0")
            whstatus += (whstatus == "" ? "" : ",") + "'"  + cmbSearchStatusTo.SelectedItem.Value +"'";

        str = str + (whstatus == "" ? "" : (str == "" ? " STATUS IN ( " + whstatus + ") " : " AND" + " STATUS IN ( " + whstatus + ") "));

        gvMain.DataSource = cFlow.GetCutOrderList(str, orderStr);
        gvMain.DataBind();
        pcTop.Update();
        pcBot.Update();
    }

    private bool doGetDetail(string LOID)
    {
        bool ret = true;
        StockOutData sData = new StockOutData();
        CutOrderFlow cFlow = new CutOrderFlow();
        sData = cFlow.GetDataStockOut(Convert.ToDouble(LOID));
        DataTable dt = cFlow.GetDataStockOutItem(Convert.ToDouble(LOID));

        if (sData.LOID != 0)
        {
            SetData(sData,dt);
        }
        else
            ret = false;

        return ret;
    }

    private bool doSave()
    {
        bool ret = true;
        // verify required field
        string error = VerifyData();
        CutOrderFlow cFlow = new CutOrderFlow();

        if (error != "")
        {
            SetErrorStatus(error);
            return false;
        }

        // data correct go on saving...
        DataTable dt = new DataTable();
        dt = GetData();
        if (dt.Rows.Count > 0)
        {
            //  update 
            ret = cFlow.UpdateStockoutItem(dt, Appz.CurrentUser);
        }
        else
        {
            SetErrorStatus("ไม่สามารถบันทึกรายการได้ เนื่องจากไม่มีข้อมูลตัดยอดก่อนเตรียม");
            ret = false;
            return ret;
        }
            

        if (!ret)
            SetErrorStatus(cFlow.ErrorMessage);
        else
            doGetList();

        return ret;
    }

    private string VerifyData()
    {
        string ret = "";
        for (int i = 0; i < grvItem.Rows.Count; ++i)
        {
            TextBox txtUseQty = (TextBox)grvItem.Rows[i].FindControl("txtUseQty");
            if(txtUseQty.Text.Trim() == "" || txtUseQty.Text.Trim() == "0")
            {
                ret = string.Format(DataResources.MSGEI001, "จำนวนที่ต้องใช้");
                return ret;
            }  
        }
        return ret;
    }

    private bool doApprove()
    {
        bool ret = true;
        CutOrderFlow cFlow = new CutOrderFlow();

        if (txhID.Text.Trim() != "")
        {
           ret = cFlow.ApproveStockout(Convert.ToDouble(txhID.Text.Trim()), Appz.CurrentUser);
        }

        if (!ret)
            SetErrorStatus(cFlow.ErrorMessage);
        else
            SetErrorStatus("รายการนี้เสร็จสิ้นแล้ว");

        return ret;
    }

    #endregion

    
}
