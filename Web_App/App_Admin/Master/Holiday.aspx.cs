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
using SHND.Data.Formula;
using SHND.Global;
using SHND.Flow.Common;
using SHND.Data.Common.Utilities;
using SHND.Flow.Inventory;
using SHND.Data.Tables;
using SHND.DAL.Views;
using SHND.DAL.Tables;
using SHND.Data.Views;

/// <summary>
/// Supplier Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Somsakoon
/// Create Date: 27 Jan 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้ากาารทำงานข้อมูล  Holiday  
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 



public partial class App_Admin_Master_Holiday : System.Web.UI.Page
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

        pcTop.SetMainGridView(gvMain);
        pcBot.SetMainGridView(gvMain);
    }


    #region Button Click Event Handler

    protected void imbSearch_Click1(object sender, EventArgs e)
    {
        gvMain.PageIndex = 0;
        doGetList();
    }

    protected void imbReset_Click(object sender, ImageClickEventArgs e)
    {
        ClearSearch();
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
        if (!doSave())
            zPop.Show();
        else
            ClearData();
    }
    protected void tbBackClick(object sender, EventArgs e)
    {
        ClearData();
    }
    protected void tbCancelClick(object sender, EventArgs e)
    {
        if (txhID.Text.Trim() == "")
            ClearData();
        else
            doGetDetail(txhID.Text);

        zPop.Show();
    }

    protected void linkCode_Click(object sender, EventArgs e)
    {
        doGetDetail(((LinkButton)sender).CommandArgument);
        zPop.Show();
    }
    protected void tbSave2Click(object sender, EventArgs e)
    {
        if (!doSave())
            zPop.Show();
        else
            ClearData();
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
        SupplierFlow sFlow = new SupplierFlow();
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
    private void doDelete()
    {
        HolidayFlow fFlow = new HolidayFlow();
        if (fFlow.DeleteByLOID(GetChecked()))
        {
            gvMain.PageIndex = 0;
            doGetList();
            lbStatusMain.Text = "";
        }
        else
        {
            lbStatusMain.Text = fFlow.ErrorMessage;
            lbStatusMain.ForeColor = System.Drawing.Color.Red;
        }

    }

    #endregion


    #region Controls Management Methods

    private void ClearData()
    {
        txhID.Text = "";
        ctlDate.DateValue = new DateTime();
        txtName.Text = "";
       
        chkActive.Checked = true;
       
    }

    private void ClearSearch()
    {
        ctlStart.DateValue = new DateTime();
        ctlEnd.DateValue = new DateTime();
    }

    private void SetErrorStatus(string t)
    {
        lbStatus.Text = t;
        lbStatus.ForeColor = Constant.StatusColor.Error;
    }
    private VHolidayData GetData()
    {
        VHolidayData sData = new VHolidayData();
        
        sData.LOID = Convert.ToDouble("0" + txhID.Text);
        sData.HOLIDAY = ctlDate.DateValue;
        sData.ACTIVE = chkActive.Checked;
        sData.NAME = txtName.Text;
       
        return sData;
    }
    private void SetData(VHolidayData ftData)
    {
        txhID.Text = ftData.LOID.ToString();
        ctlDate.DateValue = ftData.HOLIDAY;
        txtName.Text = ftData.NAME;
        chkActive.Checked = ftData.ACTIVE;
    
    }

    #endregion

    #region Working Method
    private void doGetList()
    {
        
        HolidayFlow sFlow = new HolidayFlow();

        imbReset.Visible = (ctlStart.DateValue.Year > 1 || ctlEnd.DateValue.Year > 1);
        
        string orderStr = "";
        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;

        gvMain.DataSource = sFlow.GetMasterList(ctlStart.DateValue, ctlEnd.DateValue,  orderStr);

        gvMain.DataBind();
        pcTop.Update();
        pcBot.Update(); 

    }

    private bool doSave()
    {
        // verify required field
        string error = VerifyData();
        if (error != "")
        {
            SetErrorStatus(error);
            return false;
        }

        HolidayFlow stFlow = new HolidayFlow();
        bool ret = true;

        
        // data correct go on saving...
        if (txhID.Text.Trim() == "")
        {

            //  save new
            ret = stFlow.InsertData(GetData(), Appz.CurrentUser);
        }
        else
        {
            // save update
            ret = stFlow.UpdateData(GetData(), Appz.CurrentUser);
        }

        if (!ret)
            SetErrorStatus(stFlow.ErrorMessage);
        else
            doGetList();

        return ret;
    }

    private string VerifyData()
    {
        string ret = "";
        string inputDate = "";
        int i = 1;

        VHolidayData  fData = GetData();
        HolidayFlow stFlow = new HolidayFlow();

        inputDate = fData.HOLIDAY.Day.ToString("00") + "/" + fData.HOLIDAY.Month.ToString("00") + "/" + (fData.HOLIDAY.Year+543);
        if (ctlDate.DateValue.Year == i)
            ret = string.Format(DataResources.MSGEI002,"วันที่");
        else if (fData.NAME.Trim() == "")
            ret = string.Format(DataResources.MSGEI001, "รายละเอียด");

        if (stFlow.chkDupData(fData.HOLIDAY, fData.LOID))
            ret = string.Format(DataResources.MSGEI015, "วันที่", inputDate);

        return ret;
    }

    private bool doGetDetail(string LOID)
    {
        HolidayFlow sFlow = new HolidayFlow();
        VHolidayData  sData = sFlow.GetDetails(Convert.ToDouble(LOID));

        bool ret = true;

        if (sData.LOID != 0)
        {
            SetData(sData);
        }
        else
            ret = false;

        return ret;
    }
   





    #endregion

}
