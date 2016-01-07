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



/// <summary>
/// Supplier Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Somsakoon
/// Create Date: 6 Jan 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้ากาารทำงานข้อมูล Supplier  
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

public partial class App_Inventory_Master_Default : System.Web.UI.Page
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
     Appz.BuildCombo(cmbProvince , "PROVINCE", "NAME", "LOID", "", "NAME", "เลือก", "0", false);
     cmbProvince.SelectedIndex = 0;
     SetAmphur();
   
      pcTop.SetMainGridView(gvMain);
      pcBot.SetMainGridView(gvMain);

       
    }

     

    #region Button Click Event Handler

    protected void butSearch_Click1(object sender, EventArgs e)
    {
        gvMain.PageIndex = 0;
        doGetList();
    }
    protected void linkCode_Click(Object sender, EventArgs e)
    {
        doGetDetail(((LinkButton)sender).CommandArgument);
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
    protected void tbSave1Click(object sender, EventArgs e)
    {

        if (!doSave())
            zPop.Show();
        else
            ClearData();
    }

    protected void tbSave2Click(object sender,  EventArgs e)
    {
        if (!doSave())
            zPop.Show();
        else
            ClearData();
        zPop.Show();

    /*     if (txhID.Text.Trim() == "")
            ClearData();
        else
            doGetDetail(txhID.Text);

        zPop.Show();*/
    }
    protected void tbSave3Click(object sender, EventArgs e)
    {
             if (txhID.Text.Trim() == "")
            ClearData();
        else
            doGetDetail(txhID.Text);

        zPop.Show();
    }
    protected void tbBackClick(object sender,  EventArgs e)
    {
        ClearData();
          
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
        SupplierFlow  sFlow = new SupplierFlow ();
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
    

    private void SetAmphur()
    {
        Appz.BuildCombo(this.cmbAum, "AMPHUR", "NAME", "LOID", "PROVINCE=" + this.cmbProvince.SelectedItem.Value + " AND ACTIVE = '1'", "NAME", "เลือก", "0", false);
        //cmbAum.SelectedIndex = 0;
        SetTumbol();
    }
    private void SetTumbol()
    {
        Appz.BuildCombo(this.cmbTumbol, "TAMBOL", "NAME", "LOID", "AMPHUR=" + this.cmbAum.SelectedItem.Value + " AND ACTIVE = '1'", "NAME", "เลือก", "0", false);
        //cmbTumbol.SelectedIndex = 0;
    }
    private void ClearData()
    {
        txhID.Text = "";
        txtCode.Text  = "";
        txtName.Text = "";
        txtAdd.Text = "";
        cmbProvince.SelectedIndex = 0;
        cmbAum.SelectedIndex = 0;
        cmbTumbol.SelectedIndex = 0;
        txtCode1.Text = "";
        txtTel.Text = "";
        txtMoblie.Text = "";
        txtFax.Text = "";
        txtEmail.Text = "";
        txtUser.Text = "";
        txtRemarks.Text = "";
       
      
        chkActive.Checked = true;
    }

    private void ClearSearch()
    {
        // Clear searh data
        txtSearch.Text = "";
      
    }


    private void SetErrorStatus(string t)
    {
        lbStatus.Text = t;
        lbStatus.ForeColor = Constant.StatusColor.Error;
    }
   

    #endregion

    #region Working Method

    private void doGetList()
    {
        SupplierFlow  sFlow = new SupplierFlow ();

        // ตรวจสอบเงื่อนไขการค้นหาเพื่อแสดงปุ่ม reset การค้นหา
        imbReset.Visible = (txtSearch.Text.Trim() != "");

        string orderStr = "";
        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;
       // if (txtSearch.Text.Trim() != "")

            // orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;

            gvMain.DataSource = sFlow.GetMasterList("", txtSearch.Text, "", orderStr);
        
        gvMain.DataBind();
        pcTop.Update();
        pcBot.Update();
    }



    private bool doGetDetail(string LOID)
    {
        SupplierFlow  sFlow = new SupplierFlow ();
        SupplierData  sData = sFlow.GetDetails(Convert.ToDouble(LOID));

        bool ret = true;

        if (sData.LOID != 0)
        {
            SetData(sData);
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

        SupplierFlow  stFlow = new SupplierFlow ();
        bool ret = true;

        // verify uniq field

        if (!stFlow.CheckUniqCode(txtName.Text.Trim (),txhID.Text.Trim ()))
        {
            SetErrorStatus(string.Format(DataResources.MSGEI015, "ชื่อบริษัท/ร้านค้า", this.txtName.Text.Trim()));
            return false;
        }

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
        SupplierData  sData = GetData();
        if (sData.NAME.Trim() == "")
            ret = string.Format(DataResources.MSGEI001, "ชื่อบริษัท/ร้านค้า");
        else if (sData.ADDRESS.Trim() == "")
            ret = string.Format(DataResources.MSGEI001, "ที่อยู่");
        else if (sData.PROVINCE == 0)
            ret = string.Format(DataResources.MSGEI002, "จังหวัด");
        else if (sData.AMPHUR == 0)
            ret = string.Format(DataResources.MSGEI002, "อำเภอ/เขต");
        
        
        else if (sData.TEL.Trim() == "")
            ret = string.Format(DataResources.MSGEI001, "โทรศัพท์บ้าน");
        else if (sData.MOBILE.Trim() == "")
            ret = string.Format(DataResources.MSGEI001, "โทรศัพท์มือถือ");
        else if (sData.CONTACTNAME.Trim() == "")
            ret = string.Format(DataResources.MSGEI001, "ชื่อผู้ติดต่อ");
       
        return ret;
    }

    
    private void doDelete()
    {
        SupplierFlow  sFlow = new SupplierFlow ();
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





    #endregion


    #region Controls Management Methods

    private SupplierData GetData()
    {
        SupplierData sData = new SupplierData();
     
        sData.ACTIVE = chkActive.Checked;  
        sData.CODE = txtCode.Text;
        sData.NAME = txtName.Text;
        sData.ADDRESS = txtAdd.Text;
        sData.PROVINCE = Convert.ToDouble(cmbProvince.SelectedItem.Value);
        sData.AMPHUR = Convert.ToDouble(cmbAum.SelectedItem.Value);
        sData.TAMBOL = Convert.ToDouble(cmbTumbol.SelectedItem.Value);
        sData.ZIPCODE = txtCode1.Text;
        sData.TEL = txtTel.Text;
        sData.MOBILE = txtMoblie.Text;
        sData.FAX = txtFax.Text;
        sData.EMAIL = txtEmail.Text;
        sData.CONTACTNAME = txtUser.Text;
        sData.REMARKS = txtRemarks.Text;
        sData.LOID =  Convert.ToDouble("0" + txhID.Text);


        return sData;
    }



    private void SetData(SupplierData  ftData)
    {
        txhID.Text = ftData.LOID.ToString();
              
        txtCode.Text = ftData.CODE;
        txtName.Text = ftData.NAME;
        txtAdd .Text = ftData.ADDRESS ;
        txtCode1 .Text  = ftData.ZIPCODE ;
        txtTel .Text = ftData .TEL ;
        txtMoblie .Text = ftData .MOBILE ;
        txtFax .Text = ftData .FAX ;
        txtEmail .Text = ftData .EMAIL ;
        txtUser .Text = ftData .CONTACTNAME ;
        chkActive.Checked =Convert .ToBoolean ( ftData.ACTIVE);
        cmbProvince.SelectedValue =Convert .ToString (ftData.PROVINCE);
      // cmbProvince.SelectedIndex = cmbProvince.Items.IndexOf(cmbProvince.Items.FindByText(ftData.PROVINCE.ToString()));
       SetAmphur();
        cmbAum.SelectedIndex = cmbAum.Items.IndexOf(cmbAum.Items.FindByValue(ftData.AMPHUR.ToString()));
        SetTumbol();
       cmbTumbol.SelectedIndex = cmbTumbol.Items.IndexOf(cmbTumbol.Items.FindByValue(ftData.TAMBOL.ToString()));
        txtRemarks.Text = ftData.REMARKS;
    }

 
    
    #endregion

    
    protected void cmbAum_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetTumbol();
        zPop.Show();
    }
    protected void cmbProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetAmphur();
        zPop.Show();
    }
}
