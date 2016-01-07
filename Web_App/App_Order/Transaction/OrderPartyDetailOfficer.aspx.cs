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
using SHND.Data.Formula;
using SHND.Data.Tables;
using SHND.Data.Views;
using SHND.Flow.Order;
using SHND.Global;

/// <summary>
/// Formula Feed Detail Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Tan
/// Create Date: 1 Feb 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้ากาารทำงานข้อมูล Order Party Detail
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

public partial class App_Order_Transaction_OrderPartyDetailOfficer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
                doGetDetail((Request["loid"] == null ? "0" : Request["loid"]));
        }
    }
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        Appz.BuildCombo(ddlTitle, "TITLE", "NAME", "LOID", "ACTIVE='1'", "NAME", "เลือก", "0", false);
        Appz.BuildCombo(ddlPartyType, "PARTYTYPE", "NAME", "LOID", "ACTIVE='1'", "NAME", "เลือก", "0", false);

       // ControlUtil.SetIntTextBox(txtTel);
        ControlUtil.SetIntTextBox(txtQty);
    }
    protected void ctlOrderPartyPopup_SelectedIndexChanged(object sender, EventArgs e, ArrayList arrData)
    {
        OrderPartyItem fsItem = new OrderPartyItem();
        if (fsItem.InsertOrderPartyItem(Convert.ToDouble("0" + this.txtLOID.Text), arrData))
            BindOrderParty();
    }

    #region Button Click Event Handler

    protected void tbSaveClick(object sender, EventArgs e)
    {
        doSave();
    }
    protected void tbCancelClick(object sender, EventArgs e)
    {
        doGetDetail("0" + this.txtLOID.Text);
    }
    protected void tbBackClick(object sender, EventArgs e)
    {
        Response.Redirect(Constant.HomeFolder + "App_Order/Transaction/OrderPartyOfficer.aspx");
    }
    //protected void tbPrintClick(object sender, EventArgs e)
    //{
    //}
    protected void tbApproveClick(object sender, EventArgs e)
    {
        doApprove();
    }

    #endregion

    #region FormulaDisease Toolbar
    protected void tbAddOrderPartyItemClick(object sender, EventArgs e)
    {
        UpdateOrderPartyItem();
        OrderPartyItem fsItem = new OrderPartyItem();
        this.ctlOrderPartyPopup.Show(fsItem.getOrderList(), this.ctlPartyDate.DateValue);
    }
    protected void tbDeleteOrderPartyItemClick(object sender, EventArgs e)
    {
        OrderPartyItem fsItem = new OrderPartyItem();
        if (fsItem.DeleteOrderPartyItem(GetCheckedOrderParty())) BindOrderParty();
    }
    #endregion
    #region Misc. Methods

    private ArrayList GetCheckedOrderParty()
    {
        ArrayList arrChk = new ArrayList();
        for (int i = 0; i < gvItem.Rows.Count; i++)
        {
            if (i > -1 && gvItem.Rows[i].Cells[0].FindControl("chkSelect") != null)
            {
                GridViewRow gRow = gvItem.Rows[i];
                if (((CheckBox)gRow.Cells[1].FindControl("chkSelect")).Checked)
                {
                    arrChk.Add(Convert.ToDouble(gRow.Cells[0].Text));
                }
            }
        }
        return arrChk;
    }

        #endregion

    #region Controls Management Methods

    private void BindOrderParty()
    {
        this.gvItem.DataBind();
    }

    private void SetErrorStatusOrderPartyItem(string t)
    {
        lbStatusOrderPartyItem.Text = t;
        lbStatusOrderPartyItem.ForeColor = Constant.StatusColor.Error;
    }

    private void SetStatusOrderPartyItem(string t)
    {
        lbStatusOrderPartyItem.Text = t;
        lbStatusOrderPartyItem.ForeColor = Constant.StatusColor.Information;
    }

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

    private VOrderPartyData GetData()
    {
        VOrderPartyData fsData = new VOrderPartyData();
        fsData.LOID = Convert.ToDouble(txtLOID.Text);
        fsData.NDAPPROVE = rblOfficer.SelectedValue;
        fsData.NDCOMMENT = txtOfficer.Text;
        fsData.STATUS = txtStatus.Text;

        fsData.OrderPartyItem = GetOrderPartyItem();

        return fsData;
    }

    private void SetData(VOrderPartyData fsData)
    {
        txtLOID.Text = fsData.LOID.ToString();
        txtStatus.Text = fsData.STATUS;
        txtStatusName.Text = fsData.STATUSNAME;
        txtDivision.Text = fsData.DIVISION.ToString();
        txtDivName.Text = fsData.DIVISIONNAME;
        txtCode.Text = fsData.CODE;
        ctlOrderDate.DateValue = fsData.ORDERDATE;
        ddlTitle.SelectedValue = fsData.OTITLE.ToString();
        txtName.Text = fsData.ONAME;
        txtLastName.Text = fsData.OLASTNAME;
        txtTel.Text = fsData.OTEL;
        ctlPartyDate.DateValue = fsData.PARTYDATETIME;
        ddlPartyTime.SelectedValue = fsData.PARTYDATETIME.Hour.ToString();
        ddlPartyType.SelectedValue = fsData.PARTYTYPE.ToString();
        txtQty.Text = fsData.VISITORQTY.ToString();
        txtPlace.Text = fsData.PLACE;
        txtDirector.Text = fsData.DIRECTORCOMMENT;
        txtOfficer.Text = fsData.NDCOMMENT;
        if (fsData.DIRECTORAPPROVE !="Z")
            rblDirector.SelectedValue = fsData.DIRECTORAPPROVE;
        if (fsData.NDAPPROVE != "Z")
        rblOfficer.SelectedValue = fsData.NDAPPROVE;
      //  this.tbPrint.ClientClick = Appz.OpenReportScript(Constant.Reports.FormulaFeedBDReport, fsData.LOID, false);

        if (fsData.STATUS == "RG")
        {
            this.tbApprove.Visible = false;
            this.tbSave.Visible = false;
            this.tbCancel.Visible = false;
            this.tbAddOrderPartyItem.Visible = false;
            this.tbDeleteOrderPartyItem.Visible = false;
        }

        OrderPartyItem fsItem = new OrderPartyItem();
            fsItem.ClearOrderPartyItem();
            BindOrderParty();

    }

    private ArrayList GetOrderPartyItem()
    {
        ArrayList arrData = new ArrayList();
        for (int i = 0; i < this.gvItem.Rows.Count; ++i)
        {
            OrderPartyItemData OrderItem = new OrderPartyItemData();
            OrderItem.ORDERPARTY = Convert.ToDouble("0" + this.txtLOID.Text);
            OrderItem.FORMULASET = Convert.ToDouble("0" + this.gvItem.Rows[i].Cells[8].Text);
            OrderItem.SERVICEQTY = Convert.ToDouble("0" + ((TextBox)this.gvItem.Rows[i].Cells[6].FindControl("txtServiceQty")).Text);
            OrderItem.VISITORQTY = Convert.ToDouble("0" + ((TextBox)this.gvItem.Rows[i].Cells[5].FindControl("txtVisitorQty")).Text);
            OrderItem.LOID = Convert.ToDouble("0" + this.gvItem.Rows[i].Cells[1].Text);

            arrData.Add(OrderItem);
        }
        return arrData;
    }

    #endregion

    #region Working Method

    private void UpdateOrderPartyItem()
    {
        OrderPartyItem fsItem = new OrderPartyItem();
        if (!fsItem.UpdateOrderPartyItem(Convert.ToDouble("0" + this.txtLOID.Text), GetOrderPartyItem()))
            SetErrorStatusOrderPartyItem(DataResources.MSGEC102);
        else
            SetStatusOrderPartyItem(DataResources.MSGIU001);
    }

    private bool doGetDetail(string LOID)
    {
        OrderPartyFlow fFlow = new OrderPartyFlow();
        VOrderPartyData fData = fFlow.GetDetails(Convert.ToDouble(LOID));

        bool ret = true;
        SetData(fData);
        OrderPartyItem fsItem = new OrderPartyItem();
        fsItem.ClearOrderPartyItem();
        BindOrderParty();

        return ret;
    }

    private bool doSave()
    {
         //verify required field
        VOrderPartyData Order = GetData();
        string error = VerifyData(Order);
        if (error != "")
        {
            SetErrorStatus(error);
            return false;
        }

        OrderPartyFlow ftFlow = new OrderPartyFlow();
        bool ret = true;

        // data correct go on saving...

            ret = ftFlow.UpdateDataOfficer(Order, Appz.CurrentUser);

        if (!ret)
            SetErrorStatus(ftFlow.ErrorMessage);
        else
        {
            doGetDetail(ftFlow.LOID.ToString());
            SetStatus(DataResources.MSGIU001);
        }

        return ret;
    }

    private bool doApprove()
    {
        //verify required field
        VOrderPartyData Order = GetData();
        Order.STATUS = "RG";
        string error = VerifyData(Order);
        if (error != "")
        {
            SetErrorStatus(error);
            return false;
        }

        OrderPartyFlow ftFlow = new OrderPartyFlow();
        bool ret = true;

        // data correct go on saving...

        ret = ftFlow.UpdateDataOfficer(Order, Appz.CurrentUser);

        if (!ret)
            SetErrorStatus(ftFlow.ErrorMessage);
        else
        {
            doGetDetail(ftFlow.LOID.ToString());
            SetStatus(DataResources.MSGIU001);
        }

        return ret;
    }

    private string VerifyData(VOrderPartyData fData)
    {
        string ret = "";
        if (fData.NDAPPROVE == "Z" || fData.NDAPPROVE == "")
            ret = string.Format(DataResources.MSGEI001, "ผลการรับ Order");
        else if (this.gvItem.Rows.Count == 0)
            ret = string.Format(DataResources.MSGEI001, "รายการอาหาร");
        else if (rblOfficer.SelectedValue == "Y" & this.gvItem.Rows.Count > 0)
        {
            foreach (GridViewRow row in gvItem.Rows)
            {
                TextBox txtServiceQty = (TextBox)row.Cells[7].FindControl("txtServiceQty");
                double OrderQty = Convert.ToDouble(txtServiceQty.Text == "" ? "0" : txtServiceQty.Text);
                if (OrderQty == 0)
                {
                    ret = string.Format(DataResources.MSGEI001, "จำนวนที่รับจัด");
                    break;
                }
            }
        }
        return ret;
    }

    #endregion
}
