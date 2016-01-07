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
using SHND.Flow.Inventory;
using SHND.Data.Tables;
using SHND.Data.Common.Utilities;
using SHND.Global;

/// <summary>
/// Unit Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Nang
/// Create Date: 5 Jan 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้าการทำงานข้อมูล Unit
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

public partial class App_Inventory_Master_Unit : System.Web.UI.Page
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
        pcTop.SetMainGridView(grvResult);
        pcBot.SetMainGridView(grvResult);

    }

    #region Button Click Event Handler

    protected void tbSave1Click(object sender, EventArgs e)
    {
        if (!doSave())
            UnitPop.Show();
        else
            ClearData();
    }

    protected void tbSave2Click(object sender, EventArgs e)
    {
        if (doSave())
            ClearData();

        UnitPop.Show();
    }

    protected void imbSearch_Click(object sender, ImageClickEventArgs e)
    {
        grvResult.PageIndex = 0;
        doGetList();
    }
    protected void imbReset_Click(object sender, ImageClickEventArgs e)
    {
        ClearSearch();
        grvResult.PageIndex = 0;
        doGetList();
    }
    protected void tbReturnClick(object sender, EventArgs e)
    {
        if (txhID.Text.Trim() == "")
            ClearData();
        else
            doGetDetail(txhID.Text);

        UnitPop.Show();
    }

    protected void lnkNameThai_Click(object sender, EventArgs e)
    {
        doGetDetail(((LinkButton)sender).CommandArgument);
        UnitPop.Show();
    }

    protected void tbAddClick(object sender, EventArgs e)
    {
        UnitPop.Show();
    }
    protected void tbDeleteClick(object sender, EventArgs e)
    {
        doDelete();
    }

    protected void tbBackClick(object sender, EventArgs e)
    {
        ClearData();
    }

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

    protected void grvResult_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex > -1)
            e.Row.Cells[2].Text = ((e.Row.RowIndex + 1) + (grvResult.PageIndex * grvResult.PageSize)).ToString();
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
    #endregion

    #region Misc. Methods
    private ArrayList GetChecked()
    {
        ArrayList arrChk = new ArrayList();
        for (int i = 0; i < grvResult.Rows.Count; i++)
        {
            if (i > -1 && grvResult.Rows[i].Cells[0].FindControl("chkSelect") != null)
            {
                if (((CheckBox)grvResult.Rows[i].Cells[1].FindControl("chkSelect")).Checked)
                    arrChk.Add(grvResult.Rows[i].Cells[0].Text);
            }
        }

        return arrChk;
    }


    #endregion

    #region Controls Management Methods

    private void SetData(UnitData  uData)
    {
        txhID.Text = uData.LOID.ToString();
        chkActive.Checked = uData.ACTIVE;
        txtCode.Text = uData.CODE;
        txtThai.Text = uData.THNAME;
        txtEng.Text = uData.ENNAME;
        txtABB.Text = uData.ABBNAME;
    }

    private void SetErrorStatus(string t)
    {
        lbStatus.Text = t;
        lbStatus.ForeColor =  Constant.StatusColor.Error;
    }

    private void ClearData()
    {
        txhID.Text = "";
        txtThai.Text = "";
        txtEng.Text = "";
        txtCode.Text = "";
        chkActive.Checked = true;
        txtABB.Text = "";
    }
    private void ClearSearch()
    {
        txtSearchEng.Text = "";
        txtSearchThai.Text = "";
    }

    private UnitData  GetData()
    {
        UnitData uData = new UnitData();
        uData.LOID = Convert.ToDouble("0" + txhID.Text);
        uData.ACTIVE = chkActive.Checked;
        uData.CODE = txtCode.Text;
        uData.THNAME = txtThai.Text;
        uData.ENNAME = txtEng.Text;
        uData.ABBNAME = txtABB.Text;
        return uData;
    }

    #endregion

    #region Working Method

    private void doGetList()
    {
        UnitFlow uFlow = new UnitFlow();

        // ตรวจสอบเงื่อนไขการค้นหาเพื่อแสดงปุ่ม reset การค้นหา
        imbReset.Visible = (txtSearchEng.Text.Trim() != "" || txtSearchThai.Text.Trim() != "");

        string orderStr = "";
        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;

        grvResult.DataSource = uFlow.GetUnitSearch(txtSearchThai.Text.Trim(), txtSearchEng.Text.Trim(), orderStr);
        grvResult.DataBind();
        pcTop.Update();
        pcBot.Update();
    }

    private bool doGetDetail(string LOID)
    {
        UnitFlow uflow = new UnitFlow();
        UnitData uData = uflow.GetDetails(Convert.ToDouble(LOID));


        bool ret = true;

        if (uData.LOID != 0)
        {
            SetData(uData);
        }
        else
            ret = false;

        return ret;
    }

    private void doDelete()
    {
        UnitFlow uFlow = new UnitFlow();
        if (uFlow.DeleteByLOID(GetChecked()))
        {
            grvResult.PageIndex = 0;
            doGetList();
            lbStatusMain.Text = "";
        }
        else
        {
            lbStatusMain.Text = uFlow.ErrorMessage;
            lbStatusMain.ForeColor = System.Drawing.Color.Red;
        }
    }

    private bool doSave()
    {
         //verify required field
        string error = VerifyData();
        if (error != "")
        {
            SetErrorStatus(error);
            return false;
        }

        UnitFlow uFlow = new UnitFlow();
        bool ret = true;

         // verify uniq field
         if (!uFlow.CheckUniqThai(txtThai.Text.Trim(), txhID.Text.Trim()))
            {
                SetErrorStatus(string.Format(DataResources.MSGEI015, "ชื่อภาษาไทย", this.txtThai.Text.Trim()));
                return false;
            }

        if (!uFlow.CheckUniqEng(txtEng.Text.Trim(), txhID.Text.Trim()))
        {
            SetErrorStatus(string.Format(DataResources.MSGEI005, "ชื่อภาษาอังกฤษ", this.txtEng.Text.Trim()));
            return false;
        }

         //data correct go on saving...
        if (txhID.Text.Trim() == "")
        {
         
            //  save new
            ret = uFlow.InsertData(GetData(), Appz.CurrentUser);
        }
        else
        {

            // save update
            ret = uFlow.UpdateData(GetData(), Appz.CurrentUser);
        }

        if (!ret)
            SetErrorStatus(uFlow.ErrorMessage);
        else
            doGetList();

        return ret;
    }

    private string VerifyData()
    {
        string ret = "";
        UnitData  uData = GetData();
        if (uData.ABBNAME.Trim() == "")
            ret = string.Format(DataResources.MSGEI001, "ชื่อย่อ");
        else if (uData.THNAME.Trim() == "")
            ret = string.Format(DataResources.MSGEI001, "ชื่อภาษาไทย");

        return ret;
    }

    #endregion
}
