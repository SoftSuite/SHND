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
using SHND.Data.Tables;
using SHND.Data.Formula;
using SHND.Flow.Formula;

public partial class App_Formula_Transaction_Controls_MenuItemControl : System.Web.UI.UserControl
{
    public double MenuID;
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        //this.ctlMenuDrinks.QuantityEnabled = false;
        //this.ctlMenuFruits.QuantityEnabled = true;
        this.ctlMenuRice.QuantityEnabled = false;
        this.ctlMenuSavory.QuantityEnabled = false;


    }
    protected void Page_Load(object sender, EventArgs e)
    {
        ctlMenuRice.MenuID = MenuID;
        ctlMenuSavory.MenuID = MenuID;
        ctlMenuFruits.MenuID = MenuID;
        ctlMenuDrinks.MenuID = MenuID;

        ctlMenuRice.Menudate = Day;
        ctlMenuSavory.Menudate = Day;
        ctlMenuFruits.Menudate = Day;
        ctlMenuDrinks.Menudate = Day;

        ctlMenuRice.Meal = Meal;
        ctlMenuSavory.Meal = Meal;
        ctlMenuFruits.Meal = Meal;
        ctlMenuDrinks.Meal = Meal;

    }

    public double Menu
    {
        set { this.txtMenuID.Text = value.ToString(); }
    }
    public double FoodCategory
    {
        set { this.txtFoodCategory.Text = value.ToString(); }
    }
    public double FoodType
    {
        set { this.txtFoodType.Text = value.ToString(); }
    }

    public string Meal
    {
        get { return this.txtMeal.Text; }
        set { this.txtMeal.Text = value; }
    }

    public DateTime Day
    {
        get { return Convert.ToDateTime(this.ctlDate.DateValue); }
    }

    public double Portion
    {
        get { return Convert.ToDouble(this.txtAmount.Text == "" ? "0" : this.txtAmount.Text); }
    }

    public void BindData(DateTime day, DateTime dayTo, DateTime curday)
    {
        this.txtDayFrom.Text = day.ToString("dd/MM/yyyy");
        this.txtDayTo.Text = dayTo.ToString("dd/MM/yyyy");
       // SetStyle();
        SetData(curday);
    }

    public bool Readonly
    {
        set { SetReadonly(value); }
    }

    private void SetReadonly(bool isReadonly)
    {
        this.ctlMenuDrinks.Readonly = isReadonly;
        this.ctlMenuFruits.Readonly = isReadonly;
        this.ctlMenuRice.Readonly = isReadonly;
        this.ctlMenuSavory.Readonly = isReadonly;
        this.txtAmount.ReadOnly = true;
        this.txtAmount.CssClass = "zTextbox-View";
        //this.ctlDate.Enabled = false;
        //this.imbSearch.Visible = false;
    }

    //private void SetCurrentDay(int day)
    //{
    //    this.txtCurrentDay.Text = day.ToString();
    //   // BindData();
    //}

    private void SetData(DateTime day)
    {
        this.ctlDate.DateValue = day;
        MenuFlow sFlow = new MenuFlow();
        //this.
        StdMenuItemControlData itemData = sFlow.GetMenuItemData(Convert.ToDouble("0" + this.txtMenuID.Text), day, txtMeal.Text, Convert.ToDouble("0" + txtFoodType.Text),Convert.ToDouble("0" + txtFoodCategory.Text));
        this.ctlMenuDrinks.SetSource(itemData.AllDrinks);
        this.ctlMenuDrinks.SetDestination(itemData.SelectedDrinks);
        this.ctlMenuFruits.SetSource(itemData.AllFruits);
        this.ctlMenuFruits.SetDestination(itemData.SelectedFruits);
        this.ctlMenuRice.SetSource(itemData.AllRice);
        this.ctlMenuRice.SetDestination(itemData.SelectedRice);
        this.ctlMenuSavory.SetSource(itemData.AllSavory);
        this.ctlMenuSavory.SetDestination(itemData.SelectedSavory);
        this.gvMenuItemNutrient.DataBind();
        this.txtEnergy.Text = itemData.ENERGY.ToString(Constant.DoubleFormat);
        this.txtAmount.Text = itemData.PORTION.ToString(Constant.IntFormat);

    }

    public ArrayList SelectedData()
    {
        ArrayList arrData = new ArrayList();
        ArrayList arrLOID;
        arrLOID = ctlMenuDrinks.SelectedData;
        for (int i = 0; i < arrLOID.Count; ++i)
        {
            string[] code = arrLOID[i].ToString().Split('#');
            StdMenuItemData item = new StdMenuItemData();
            if (code[1] == "FORMULASET")
                item.FORMULASET = Convert.ToDouble(code[0]);
            else
                item.MATERIALMASTER = Convert.ToDouble(code[0]);
            item.MEAL = this.txtMeal.Text;
            item.GROUPTYPE = "BV";
            //item.UNIT = Convert.ToDouble(code[2]);
            item.UNIT = Convert.ToDouble(code[3]);
            item.QTY = Convert.ToDouble(code[4]);
            arrData.Add(item);
        }
        arrLOID = ctlMenuFruits.SelectedData;
        for (int i = 0; i < arrLOID.Count; ++i)
        {
            string[] code = arrLOID[i].ToString().Split('#');
            StdMenuItemData item = new StdMenuItemData();
            if (code[1] == "FORMULASET")
                item.FORMULASET = Convert.ToDouble(code[0]);
            else
                item.MATERIALMASTER = Convert.ToDouble(code[0]);
            item.MEAL = this.txtMeal.Text;
            item.GROUPTYPE = "FR";
           // item.UNIT = Convert.ToDouble(code[2]);
            item.UNIT = Convert.ToDouble(code[3]);
            item.QTY = Convert.ToDouble(code[4]);
            arrData.Add(item);
        }
        arrLOID = ctlMenuRice.SelectedData;
        for (int i = 0; i < arrLOID.Count; ++i)
        {
            string[] code = arrLOID[i].ToString().Split('#');
            StdMenuItemData item = new StdMenuItemData();
            if (code[1] == "FORMULASET")
                item.FORMULASET = Convert.ToDouble(code[0]);
            else
                item.MATERIALMASTER = Convert.ToDouble(code[0]);
            item.MEAL = this.txtMeal.Text;
            item.GROUPTYPE = "OD";
            item.UNIT = Convert.ToDouble(code[2]);
            item.QTY = Convert.ToDouble(code[4]);
            arrData.Add(item);
        }
        arrLOID = ctlMenuSavory.SelectedData;
        for (int i = 0; i < arrLOID.Count; ++i)
        {
            string[] code = arrLOID[i].ToString().Split('#');
            StdMenuItemData item = new StdMenuItemData();
            if (code[1] == "FORMULASET")
                item.FORMULASET = Convert.ToDouble(code[0]);
            else
                item.MATERIALMASTER = Convert.ToDouble(code[0]);
            item.MEAL = this.txtMeal.Text;
            item.GROUPTYPE = "ND";
            item.UNIT = Convert.ToDouble(code[2]);
            item.QTY = Convert.ToDouble(code[4]);
            arrData.Add(item);
        }
        return arrData;
    }
    protected void imbSearch_Click(object sender, ImageClickEventArgs e)
    {
        if (Convert.ToDateTime(ctlDate.DateValue) >= Convert.ToDateTime(txtDayFrom.Text) & Convert.ToDateTime(ctlDate.DateValue) <= Convert.ToDateTime(txtDayTo.Text))
        {
            SetData(Convert.ToDateTime(ctlDate.DateValue));
            lblError.Text = "";
        }
        else
        {
            lblError.Text = "วันที่ไม่อยู่ในช่วงที่ระบุ";
            SetData(Convert.ToDateTime(txtDayFrom.Text));

        }
    }
    protected void ctlMenuRice_ClickChanged(object sender, EventArgs e)
    {
        SetData(Day);
    }
    protected void ctlMenuSavory_ClickChanged(object sender, EventArgs e)
    {
        SetData(Day);
    }
    protected void ctlMenuFruits_ClickChanged(object sender, EventArgs e)
    {
        SetData(Day);
    }
    protected void ctlMenuDrinks_ClickChanged(object sender, EventArgs e)
    {
        SetData(Day);
    }
    
}
