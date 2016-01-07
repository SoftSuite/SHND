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
/// <summary>
/// FoodType Page Class
/// Version 1.0
/// =========================================================================
/// Create by: TurBoZ
/// Create Date: 19 Dec 2008
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้ากาารทำงานข้อมูล Food Type 
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

public partial class App_Formula_Master_FoodType : System.Web.UI.Page
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

        // set Combo source
        if (Appz.LoggedOnUser.OFFICERGROUP == "A")
        {
            Appz.BuildCombo(cmbDev, "DIVISION", "NAME", "LOID", "ACTIVE='1' AND ISFORMULA='Y' " , "NAME", "เลือก", "0", false);
            Appz.BuildCombo(cmbSearchDiv, "DIVISION", "NAME", "LOID", "ACTIVE='1' AND ISFORMULA='Y' " , "NAME", "ทั้งหมด", "", false);
        }
        else
        {
            Appz.BuildCombo(cmbDev, "DIVISION", "NAME", "LOID", "ACTIVE='1' AND ISFORMULA='Y' AND LOID='" + Appz.LoggedOnUser.DIVISION.ToString() + "'", "NAME", "เลือก", "0", false);
            Appz.BuildCombo(cmbSearchDiv, "DIVISION", "NAME", "LOID", "ACTIVE='1' AND ISFORMULA='Y' AND LOID='" + Appz.LoggedOnUser.DIVISION.ToString() + "'", "NAME", "ทั้งหมด", "", false);
            cmbSearchDiv.SelectedValue = Appz.LoggedOnUser.DIVISION.ToString();
            cmbSearchDiv.Enabled = false;
        }
        
        pcTop.SetMainGridView(gvMain);
        pcBot.SetMainGridView(gvMain);
    }

    #region Button Click Event Handler
    protected void tbSave1Click(object sender, EventArgs e)
    {
        if (!doSave())
            zPop.Show();
        else
            ClearData();
    }
    protected void tbSave2Click(object sender, EventArgs e)
    {
        if (doSave())
            ClearData();
        zPop.Show();
    }
    protected void tbAddClick(object sender, EventArgs e)
    {

        zPop.Show();
    }
    protected void tbDeleteClick(object sender, EventArgs e)
    {
        doDelete();
    }
    protected void tbCancelClick(object sender, EventArgs e)
    {
        if (txhID.Text.Trim() == "")
            ClearData();
        else
            doGetDetail(txhID.Text);

        zPop.Show();
    }
    protected void tbBackClick(object sender, EventArgs e)
    {
        ClearData();
    }
    protected void lnkFood_Click(object sender, EventArgs e)
    {
        doGetDetail(((LinkButton)sender).CommandArgument);
        zPop.Show();
    }

    protected void imbSearch_Click(object sender, ImageClickEventArgs e)
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

    #endregion

    #region Gridview Event Handler

    protected void gvMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex > -1)
            e.Row.Cells[2].Text = ((e.Row.RowIndex + 1) + (gvMain.PageIndex * gvMain.PageSize)).ToString();
    }

    protected void gvMain_Sorting(object sender, GridViewSortEventArgs e)
    {
        FoodTypeFlow fFlow = new FoodTypeFlow();
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
        txtName.Text = "";
        txtCode.Text = "";
        cmbDev.SelectedIndex = 0;
        chkActive.Checked = true;
    }

    private void ClearSearch()
    {
        // Clear searh data
        txtSearchName.Text = "";
        cmbSearchDiv.SelectedIndex = 0; 
    }

    private FoodTypeData GetData()
    {
        FoodTypeData ftData = new FoodTypeData();
        ftData.LOID = Convert.ToDouble("0" + txhID.Text);
        ftData.ACTIVE = chkActive.Checked;
        ftData.CODE = txtCode.Text;
        ftData.NAME = txtName.Text;
        ftData.DIVISION = Convert.ToDouble(cmbDev.SelectedItem.Value);
        ftData.ISNURSE = chkIsNurse.Checked;
        return ftData;
    }

    private void SetData(FoodTypeData ftData)
    {
        txhID.Text = ftData.LOID.ToString();
        chkActive.Checked = ftData.ACTIVE;
        txtCode.Text = ftData.CODE;
        txtName.Text = ftData.NAME;
        cmbDev.SelectedIndex = cmbDev.Items.IndexOf(cmbDev.Items.FindByValue(ftData.DIVISION.ToString()));
        chkIsNurse.Checked = ftData.ISNURSE;

    }

    #endregion

    #region Working Method

    private void doGetList()
    {
        FoodTypeFlow fFlow = new FoodTypeFlow();

        // ตรวจสอบเงื่อนไขการค้นหาเพื่อแสดงปุ่ม reset การค้นหา
        imbReset.Visible = (txtSearchName.Text.Trim() != "") || (cmbSearchDiv.SelectedIndex != 0);

        string orderStr = "";
        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;

        gvMain.DataSource = fFlow.GetMasterList("", txtSearchName.Text, cmbSearchDiv.SelectedItem.Value, orderStr);
        gvMain.DataBind();
        pcTop.Update();
        pcBot.Update();
    }

    private bool doGetDetail(string LOID)
    {
        FoodTypeFlow fFlow = new FoodTypeFlow();
        FoodTypeData fData = fFlow.GetDetails(Convert.ToDouble(LOID));

        bool ret = true;

        if (fData.LOID != 0)
        {
            SetData(fData);
        }
        else
            ret = false;

        return ret;
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

        FoodTypeFlow ftFlow = new FoodTypeFlow();
        bool ret = true;

            // verify uniq field
        if (!ftFlow.CheckUniqCode(txtCode.Text.Trim(), txhID.Text.Trim()))
        {
            SetErrorStatus(string.Format(DataResources.MSGEI015, "รหัสประเภทอาหาร", this.txtCode.Text.Trim()));
            return false;
        }

        if (!ftFlow.CheckUniqName(txtName.Text.Trim(), txhID.Text.Trim()))
        {
            SetErrorStatus(string.Format(DataResources.MSGEI015, "ชื่อประเภทอาหาร", this.txtName.Text.Trim()));
            return false;
        }

        // data correct go on saving...
        if (txhID.Text.Trim() == "")
        {

            //  save new
            ret = ftFlow.InsertData(GetData(), Appz.CurrentUser);
        }
        else
        {
            // save update
            ret = ftFlow.UpdateData(GetData(), Appz.CurrentUser);
        }

        if (!ret)
            SetErrorStatus(ftFlow.ErrorMessage);
        else
            doGetList();

        return ret;
    }

    private void doDelete()
    {
        FoodTypeFlow fFlow = new FoodTypeFlow();
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

    private string VerifyData()
    {
        string ret = "";
        FoodTypeData fData = GetData();
        if (fData.CODE.Trim() == "")
            ret = string.Format(DataResources.MSGEI001, "รหัสประเภทอาหาร");
        else if (fData.NAME.Trim() == "")
            ret = string.Format(DataResources.MSGEI001, "ชื่อประเภทอาหาร");
        else if (fData.DIVISION == 0)
            ret = string.Format(DataResources.MSGEI002, "หน่วยงานที่รับผิดชอบ");

        return ret;
    }

    #endregion

}
