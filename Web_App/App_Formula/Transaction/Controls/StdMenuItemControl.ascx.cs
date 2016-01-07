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

public partial class App_Formula_Transaction_Controls_StdMenuItemControl : System.Web.UI.UserControl
{
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        //this.ctlMenuDrinks.QuantityEnabled = false;
        //this.ctlMenuFruits.QuantityEnabled = true;
        this.ctlMenuRice.QuantityEnabled = false;
        this.ctlMenuSavory.QuantityEnabled = false;
        this.ctlMenuRice.UnitEnabled = false;
        this.ctlMenuSavory.UnitEnabled = false;

    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public double StdMenu
    {
        set { this.txtStdMenuID.Text = value.ToString(); }
    }

    public double FoodType
    {
        get { return Convert.ToDouble("0" + this.txtFoodType.Text); }
        set { this.txtFoodType.Text = value.ToString(); }
    }

    public string Meal
    {
        get { return this.txtMeal.Text; }
        set { this.txtMeal.Text = value; }
    }

    public int Day
    {
        get { return Convert.ToInt32("0" + this.txtCurrentDay.Text); }
    }

    public void BindData()
    {
        SetStyle();
        SetData();
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

        this.chkDay1.Enabled = !isReadonly;
        this.chkDay2.Enabled = !isReadonly;
        this.chkDay3.Enabled = !isReadonly;
        this.chkDay4.Enabled = !isReadonly;
        this.chkDay5.Enabled = !isReadonly;
        this.chkDay6.Enabled = !isReadonly;
        this.chkDay7.Enabled = !isReadonly;
        this.chkDay8.Enabled = !isReadonly;
        this.chkDay9.Enabled = !isReadonly;
        this.chkDay10.Enabled = !isReadonly;
        this.chkDay11.Enabled = !isReadonly;
        this.chkDay12.Enabled = !isReadonly;
        this.chkDay13.Enabled = !isReadonly;
        this.chkDay14.Enabled = !isReadonly;
        this.chkDay15.Enabled = !isReadonly;
        this.chkDay16.Enabled = !isReadonly;
        this.chkDay17.Enabled = !isReadonly;
        this.chkDay18.Enabled = !isReadonly;
        this.chkDay19.Enabled = !isReadonly;
        this.chkDay20.Enabled = !isReadonly;
        this.chkDay21.Enabled = !isReadonly;
        this.chkDay22.Enabled = !isReadonly;
        this.chkDay23.Enabled = !isReadonly;
        this.chkDay24.Enabled = !isReadonly;
        this.chkDay25.Enabled = !isReadonly;
        this.chkDay26.Enabled = !isReadonly;
        this.chkDay27.Enabled = !isReadonly;
        this.chkDay28.Enabled = !isReadonly;
        this.chkDay29.Enabled = !isReadonly;
        this.chkDay30.Enabled = !isReadonly;
        this.chkDay31.Enabled = !isReadonly;
    }

    public ArrayList SelectedDay
    {
        get
        {
            ArrayList arrData = new ArrayList();
            if (this.chkDay1.Checked) arrData.Add(1);
            if (this.chkDay2.Checked) arrData.Add(2);
            if (this.chkDay3.Checked) arrData.Add(3);
            if (this.chkDay4.Checked) arrData.Add(4);
            if (this.chkDay5.Checked) arrData.Add(5);
            if (this.chkDay6.Checked) arrData.Add(6);
            if (this.chkDay7.Checked) arrData.Add(7);
            if (this.chkDay8.Checked) arrData.Add(8);
            if (this.chkDay9.Checked) arrData.Add(9);
            if (this.chkDay10.Checked) arrData.Add(10);
            if (this.chkDay11.Checked) arrData.Add(11);
            if (this.chkDay12.Checked) arrData.Add(12);
            if (this.chkDay13.Checked) arrData.Add(13);
            if (this.chkDay14.Checked) arrData.Add(14);
            if (this.chkDay15.Checked) arrData.Add(15);
            if (this.chkDay16.Checked) arrData.Add(16);
            if (this.chkDay17.Checked) arrData.Add(17);
            if (this.chkDay18.Checked) arrData.Add(18);
            if (this.chkDay19.Checked) arrData.Add(19);
            if (this.chkDay20.Checked) arrData.Add(20);
            if (this.chkDay21.Checked) arrData.Add(21);
            if (this.chkDay22.Checked) arrData.Add(22);
            if (this.chkDay23.Checked) arrData.Add(23);
            if (this.chkDay24.Checked) arrData.Add(24);
            if (this.chkDay25.Checked) arrData.Add(25);
            if (this.chkDay26.Checked) arrData.Add(26);
            if (this.chkDay27.Checked) arrData.Add(27);
            if (this.chkDay28.Checked) arrData.Add(28);
            if (this.chkDay29.Checked) arrData.Add(29);
            if (this.chkDay30.Checked) arrData.Add(30);
            if (this.chkDay31.Checked) arrData.Add(31);

            return arrData;
        }
    }

    #region Link button day click
    protected void lnkDay1_Click(object sender, EventArgs e)
    {
        SetCurrentDay(1);
    }
    protected void lnkDay2_Click(object sender, EventArgs e)
    {
        SetCurrentDay(2);
    }
    protected void lnkDay3_Click(object sender, EventArgs e)
    {
        SetCurrentDay(3);
    }
    protected void lnkDay4_Click(object sender, EventArgs e)
    {
        SetCurrentDay(4);
    }
    protected void lnkDay5_Click(object sender, EventArgs e)
    {
        SetCurrentDay(5);
    }
    protected void lnkDay6_Click(object sender, EventArgs e)
    {
        SetCurrentDay(6);
    }
    protected void lnkDay7_Click(object sender, EventArgs e)
    {
        SetCurrentDay(7);
    }
    protected void lnkDay8_Click(object sender, EventArgs e)
    {
        SetCurrentDay(8);
    }
    protected void lnkDay9_Click(object sender, EventArgs e)
    {
        SetCurrentDay(9);
    }
    protected void lnkDay10_Click(object sender, EventArgs e)
    {
        SetCurrentDay(10);
    }
    protected void lnkDay11_Click(object sender, EventArgs e)
    {
        SetCurrentDay(11);
    }
    protected void lnkDay12_Click(object sender, EventArgs e)
    {
        SetCurrentDay(12);
    }
    protected void lnkDay13_Click(object sender, EventArgs e)
    {
        SetCurrentDay(13);
    }
    protected void lnkDay14_Click(object sender, EventArgs e)
    {
        SetCurrentDay(14);
    }
    protected void lnkDay15_Click(object sender, EventArgs e)
    {
        SetCurrentDay(15);
    }
    protected void lnkDay16_Click(object sender, EventArgs e)
    {
        SetCurrentDay(16);
    }
    protected void lnkDay17_Click(object sender, EventArgs e)
    {
        SetCurrentDay(17);
    }
    protected void lnkDay18_Click(object sender, EventArgs e)
    {
        SetCurrentDay(18);
    }
    protected void lnkDay19_Click(object sender, EventArgs e)
    {
        SetCurrentDay(19);
    }
    protected void lnkDay20_Click(object sender, EventArgs e)
    {
        SetCurrentDay(20);
    }
    protected void lnkDay21_Click(object sender, EventArgs e)
    {
        SetCurrentDay(21);
    }
    protected void lnkDay22_Click(object sender, EventArgs e)
    {
        SetCurrentDay(22);
    }
    protected void lnkDay23_Click(object sender, EventArgs e)
    {
        SetCurrentDay(23);
    }
    protected void lnkDay24_Click(object sender, EventArgs e)
    {
        SetCurrentDay(24);
    }
    protected void lnkDay25_Click(object sender, EventArgs e)
    {
        SetCurrentDay(25);
    }
    protected void lnkDay26_Click(object sender, EventArgs e)
    {
        SetCurrentDay(26);
    }
    protected void lnkDay27_Click(object sender, EventArgs e)
    {
        SetCurrentDay(27);
    }
    protected void lnkDay28_Click(object sender, EventArgs e)
    {
        SetCurrentDay(28);
    }
    protected void lnkDay29_Click(object sender, EventArgs e)
    {
        SetCurrentDay(29);
    }
    protected void lnkDay30_Click(object sender, EventArgs e)
    {
        SetCurrentDay(30);
    }
    protected void lnkDay31_Click(object sender, EventArgs e)
    {
        SetCurrentDay(31);
    }
    #endregion

    #region Day Property

    public double Day1
    {
        set { this.txtDay1.Text = value.ToString(); }
    }
    public double Day2
    {
        set { this.txtDay2.Text = value.ToString(); }
    }
    public double Day3
    {
        set { this.txtDay3.Text = value.ToString(); }
    }
    public double Day4
    {
        set { this.txtDay4.Text = value.ToString(); }
    }
    public double Day5
    {
        set { this.txtDay5.Text = value.ToString(); }
    }
    public double Day6
    {
        set { this.txtDay6.Text = value.ToString(); }
    }
    public double Day7
    {
        set { this.txtDay7.Text = value.ToString(); }
    }
    public double Day8
    {
        set { this.txtDay8.Text = value.ToString(); }
    }
    public double Day9
    {
        set { this.txtDay9.Text = value.ToString(); }
    }
    public double Day10
    {
        set { this.txtDay10.Text = value.ToString(); }
    }
    public double Day11
    {
        set { this.txtDay11.Text = value.ToString(); }
    }
    public double Day12
    {
        set { this.txtDay12.Text = value.ToString(); }
    }
    public double Day13
    {
        set { this.txtDay13.Text = value.ToString(); }
    }
    public double Day14
    {
        set { this.txtDay14.Text = value.ToString(); }
    }
    public double Day15
    {
        set { this.txtDay15.Text = value.ToString(); }
    }
    public double Day16
    {
        set { this.txtDay16.Text = value.ToString(); }
    }
    public double Day17
    {
        set { this.txtDay17.Text = value.ToString(); }
    }
    public double Day18
    {
        set { this.txtDay18.Text = value.ToString(); }
    }
    public double Day19
    {
        set { this.txtDay19.Text = value.ToString(); }
    }
    public double Day20
    {
        set { this.txtDay20.Text = value.ToString(); }
    }
    public double Day21
    {
        set { this.txtDay21.Text = value.ToString(); }
    }
    public double Day22
    {
        set { this.txtDay22.Text = value.ToString(); }
    }
    public double Day23
    {
        set { this.txtDay23.Text = value.ToString(); }
    }
    public double Day24
    {
        set { this.txtDay24.Text = value.ToString(); }
    }
    public double Day25
    {
        set { this.txtDay25.Text = value.ToString(); }
    }
    public double Day26
    {
        set { this.txtDay26.Text = value.ToString(); }
    }
    public double Day27
    {
        set { this.txtDay27.Text = value.ToString(); }
    }
    public double Day28
    {
        set { this.txtDay28.Text = value.ToString(); }
    }
    public double Day29
    {
        set { this.txtDay29.Text = value.ToString(); }
    }
    public double Day30
    {
        set { this.txtDay30.Text = value.ToString(); }
    }
    public double Day31
    {
        set { this.txtDay31.Text = value.ToString(); }
    }

    #endregion

    #region SetStyle

    private void SetStyle()
    {
        if (this.txtCurrentDay.Text == "") this.txtCurrentDay.Text = "1";

        #region Set CssClass
        this.lnkDay1.CssClass = (this.lnkDay1.Text == this.txtCurrentDay.Text ? "dateselect" : (Convert.ToDouble("0" + this.txtDay1.Text) > 0 ? "datetable" : "datenone"));
        this.lnkDay2.CssClass = (this.lnkDay2.Text == this.txtCurrentDay.Text ? "dateselect" : (Convert.ToDouble("0" + this.txtDay2.Text) > 0 ? "datetable" : "datenone"));
        this.lnkDay3.CssClass = (this.lnkDay3.Text == this.txtCurrentDay.Text ? "dateselect" : (Convert.ToDouble("0" + this.txtDay3.Text) > 0 ? "datetable" : "datenone"));
        this.lnkDay4.CssClass = (this.lnkDay4.Text == this.txtCurrentDay.Text ? "dateselect" : (Convert.ToDouble("0" + this.txtDay4.Text) > 0 ? "datetable" : "datenone"));
        this.lnkDay5.CssClass = (this.lnkDay5.Text == this.txtCurrentDay.Text ? "dateselect" : (Convert.ToDouble("0" + this.txtDay5.Text) > 0 ? "datetable" : "datenone"));
        this.lnkDay6.CssClass = (this.lnkDay6.Text == this.txtCurrentDay.Text ? "dateselect" : (Convert.ToDouble("0" + this.txtDay6.Text) > 0 ? "datetable" : "datenone"));
        this.lnkDay7.CssClass = (this.lnkDay7.Text == this.txtCurrentDay.Text ? "dateselect" : (Convert.ToDouble("0" + this.txtDay7.Text) > 0 ? "datetable" : "datenone"));
        this.lnkDay8.CssClass = (this.lnkDay8.Text == this.txtCurrentDay.Text ? "dateselect" : (Convert.ToDouble("0" + this.txtDay8.Text) > 0 ? "datetable" : "datenone"));
        this.lnkDay9.CssClass = (this.lnkDay9.Text == this.txtCurrentDay.Text ? "dateselect" : (Convert.ToDouble("0" + this.txtDay9.Text) > 0 ? "datetable" : "datenone"));
        this.lnkDay10.CssClass = (this.lnkDay10.Text == this.txtCurrentDay.Text ? "dateselect" : (Convert.ToDouble("0" + this.txtDay10.Text) > 0 ? "datetable" : "datenone"));
        this.lnkDay11.CssClass = (this.lnkDay11.Text == this.txtCurrentDay.Text ? "dateselect" : (Convert.ToDouble("0" + this.txtDay11.Text) > 0 ? "datetable" : "datenone"));
        this.lnkDay12.CssClass = (this.lnkDay12.Text == this.txtCurrentDay.Text ? "dateselect" : (Convert.ToDouble("0" + this.txtDay12.Text) > 0 ? "datetable" : "datenone"));
        this.lnkDay13.CssClass = (this.lnkDay13.Text == this.txtCurrentDay.Text ? "dateselect" : (Convert.ToDouble("0" + this.txtDay13.Text) > 0 ? "datetable" : "datenone"));
        this.lnkDay14.CssClass = (this.lnkDay14.Text == this.txtCurrentDay.Text ? "dateselect" : (Convert.ToDouble("0" + this.txtDay14.Text) > 0 ? "datetable" : "datenone"));
        this.lnkDay15.CssClass = (this.lnkDay15.Text == this.txtCurrentDay.Text ? "dateselect" : (Convert.ToDouble("0" + this.txtDay15.Text) > 0 ? "datetable" : "datenone"));
        this.lnkDay16.CssClass = (this.lnkDay16.Text == this.txtCurrentDay.Text ? "dateselect" : (Convert.ToDouble("0" + this.txtDay16.Text) > 0 ? "datetable" : "datenone"));
        this.lnkDay17.CssClass = (this.lnkDay17.Text == this.txtCurrentDay.Text ? "dateselect" : (Convert.ToDouble("0" + this.txtDay17.Text) > 0 ? "datetable" : "datenone"));
        this.lnkDay18.CssClass = (this.lnkDay18.Text == this.txtCurrentDay.Text ? "dateselect" : (Convert.ToDouble("0" + this.txtDay18.Text) > 0 ? "datetable" : "datenone"));
        this.lnkDay19.CssClass = (this.lnkDay19.Text == this.txtCurrentDay.Text ? "dateselect" : (Convert.ToDouble("0" + this.txtDay19.Text) > 0 ? "datetable" : "datenone"));
        this.lnkDay20.CssClass = (this.lnkDay20.Text == this.txtCurrentDay.Text ? "dateselect" : (Convert.ToDouble("0" + this.txtDay20.Text) > 0 ? "datetable" : "datenone"));
        this.lnkDay21.CssClass = (this.lnkDay21.Text == this.txtCurrentDay.Text ? "dateselect" : (Convert.ToDouble("0" + this.txtDay21.Text) > 0 ? "datetable" : "datenone"));
        this.lnkDay22.CssClass = (this.lnkDay22.Text == this.txtCurrentDay.Text ? "dateselect" : (Convert.ToDouble("0" + this.txtDay22.Text) > 0 ? "datetable" : "datenone"));
        this.lnkDay23.CssClass = (this.lnkDay23.Text == this.txtCurrentDay.Text ? "dateselect" : (Convert.ToDouble("0" + this.txtDay23.Text) > 0 ? "datetable" : "datenone"));
        this.lnkDay24.CssClass = (this.lnkDay24.Text == this.txtCurrentDay.Text ? "dateselect" : (Convert.ToDouble("0" + this.txtDay24.Text) > 0 ? "datetable" : "datenone"));
        this.lnkDay25.CssClass = (this.lnkDay25.Text == this.txtCurrentDay.Text ? "dateselect" : (Convert.ToDouble("0" + this.txtDay25.Text) > 0 ? "datetable" : "datenone"));
        this.lnkDay26.CssClass = (this.lnkDay26.Text == this.txtCurrentDay.Text ? "dateselect" : (Convert.ToDouble("0" + this.txtDay26.Text) > 0 ? "datetable" : "datenone"));
        this.lnkDay27.CssClass = (this.lnkDay27.Text == this.txtCurrentDay.Text ? "dateselect" : (Convert.ToDouble("0" + this.txtDay27.Text) > 0 ? "datetable" : "datenone"));
        this.lnkDay28.CssClass = (this.lnkDay28.Text == this.txtCurrentDay.Text ? "dateselect" : (Convert.ToDouble("0" + this.txtDay28.Text) > 0 ? "datetable" : "datenone"));
        this.lnkDay29.CssClass = (this.lnkDay29.Text == this.txtCurrentDay.Text ? "dateselect" : (Convert.ToDouble("0" + this.txtDay29.Text) > 0 ? "datetable" : "datenone"));
        this.lnkDay30.CssClass = (this.lnkDay30.Text == this.txtCurrentDay.Text ? "dateselect" : (Convert.ToDouble("0" + this.txtDay30.Text) > 0 ? "datetable" : "datenone"));
        this.lnkDay31.CssClass = (this.lnkDay31.Text == this.txtCurrentDay.Text ? "dateselect" : (Convert.ToDouble("0" + this.txtDay31.Text) > 0 ? "datetable" : "datenone"));
        #endregion

        #region Set LinkButton Enabled
        this.lnkDay1.Enabled = (this.lnkDay1.Text != this.txtCurrentDay.Text);
        this.lnkDay2.Enabled = (this.lnkDay2.Text != this.txtCurrentDay.Text);
        this.lnkDay3.Enabled = (this.lnkDay3.Text != this.txtCurrentDay.Text);
        this.lnkDay4.Enabled = (this.lnkDay4.Text != this.txtCurrentDay.Text);
        this.lnkDay5.Enabled = (this.lnkDay5.Text != this.txtCurrentDay.Text);
        this.lnkDay6.Enabled = (this.lnkDay6.Text != this.txtCurrentDay.Text);
        this.lnkDay7.Enabled = (this.lnkDay7.Text != this.txtCurrentDay.Text);
        this.lnkDay8.Enabled = (this.lnkDay8.Text != this.txtCurrentDay.Text);
        this.lnkDay9.Enabled = (this.lnkDay9.Text != this.txtCurrentDay.Text);
        this.lnkDay10.Enabled = (this.lnkDay10.Text != this.txtCurrentDay.Text);
        this.lnkDay11.Enabled = (this.lnkDay11.Text != this.txtCurrentDay.Text);
        this.lnkDay12.Enabled = (this.lnkDay12.Text != this.txtCurrentDay.Text);
        this.lnkDay13.Enabled = (this.lnkDay13.Text != this.txtCurrentDay.Text);
        this.lnkDay14.Enabled = (this.lnkDay14.Text != this.txtCurrentDay.Text);
        this.lnkDay15.Enabled = (this.lnkDay15.Text != this.txtCurrentDay.Text);
        this.lnkDay16.Enabled = (this.lnkDay16.Text != this.txtCurrentDay.Text);
        this.lnkDay17.Enabled = (this.lnkDay17.Text != this.txtCurrentDay.Text);
        this.lnkDay18.Enabled = (this.lnkDay18.Text != this.txtCurrentDay.Text);
        this.lnkDay19.Enabled = (this.lnkDay19.Text != this.txtCurrentDay.Text);
        this.lnkDay20.Enabled = (this.lnkDay20.Text != this.txtCurrentDay.Text);
        this.lnkDay21.Enabled = (this.lnkDay21.Text != this.txtCurrentDay.Text);
        this.lnkDay22.Enabled = (this.lnkDay22.Text != this.txtCurrentDay.Text);
        this.lnkDay23.Enabled = (this.lnkDay23.Text != this.txtCurrentDay.Text);
        this.lnkDay24.Enabled = (this.lnkDay24.Text != this.txtCurrentDay.Text);
        this.lnkDay25.Enabled = (this.lnkDay25.Text != this.txtCurrentDay.Text);
        this.lnkDay26.Enabled = (this.lnkDay26.Text != this.txtCurrentDay.Text);
        this.lnkDay27.Enabled = (this.lnkDay27.Text != this.txtCurrentDay.Text);
        this.lnkDay28.Enabled = (this.lnkDay28.Text != this.txtCurrentDay.Text);
        this.lnkDay29.Enabled = (this.lnkDay29.Text != this.txtCurrentDay.Text);
        this.lnkDay30.Enabled = (this.lnkDay30.Text != this.txtCurrentDay.Text);
        this.lnkDay31.Enabled = (this.lnkDay31.Text != this.txtCurrentDay.Text);
        #endregion

        #region Set Checkbox Enabled
        this.chkDay1.Enabled = this.lnkDay1.Enabled;
        this.chkDay2.Enabled = this.lnkDay2.Enabled;
        this.chkDay3.Enabled = this.lnkDay3.Enabled;
        this.chkDay4.Enabled = this.lnkDay4.Enabled;
        this.chkDay5.Enabled = this.lnkDay5.Enabled;
        this.chkDay6.Enabled = this.lnkDay6.Enabled;
        this.chkDay7.Enabled = this.lnkDay7.Enabled;
        this.chkDay8.Enabled = this.lnkDay8.Enabled;
        this.chkDay9.Enabled = this.lnkDay9.Enabled;
        this.chkDay10.Enabled = this.lnkDay10.Enabled;
        this.chkDay11.Enabled = this.lnkDay11.Enabled;
        this.chkDay12.Enabled = this.lnkDay12.Enabled;
        this.chkDay13.Enabled = this.lnkDay13.Enabled;
        this.chkDay14.Enabled = this.lnkDay14.Enabled;
        this.chkDay15.Enabled = this.lnkDay15.Enabled;
        this.chkDay16.Enabled = this.lnkDay16.Enabled;
        this.chkDay17.Enabled = this.lnkDay17.Enabled;
        this.chkDay18.Enabled = this.lnkDay18.Enabled;
        this.chkDay19.Enabled = this.lnkDay19.Enabled;
        this.chkDay20.Enabled = this.lnkDay20.Enabled;
        this.chkDay21.Enabled = this.lnkDay21.Enabled;
        this.chkDay22.Enabled = this.lnkDay22.Enabled;
        this.chkDay23.Enabled = this.lnkDay23.Enabled;
        this.chkDay24.Enabled = this.lnkDay24.Enabled;
        this.chkDay25.Enabled = this.lnkDay25.Enabled;
        this.chkDay26.Enabled = this.lnkDay26.Enabled;
        this.chkDay27.Enabled = this.lnkDay27.Enabled;
        this.chkDay28.Enabled = this.lnkDay28.Enabled;
        this.chkDay29.Enabled = this.lnkDay29.Enabled;
        this.chkDay30.Enabled = this.lnkDay30.Enabled;
        this.chkDay31.Enabled = this.lnkDay31.Enabled;
        #endregion

        #region Set Checkbox Checked
        this.chkDay1.Checked = !this.lnkDay1.Enabled;
        this.chkDay2.Checked = !this.lnkDay2.Enabled;
        this.chkDay3.Checked = !this.lnkDay3.Enabled;
        this.chkDay4.Checked = !this.lnkDay4.Enabled;
        this.chkDay5.Checked = !this.lnkDay5.Enabled;
        this.chkDay6.Checked = !this.lnkDay6.Enabled;
        this.chkDay7.Checked = !this.lnkDay7.Enabled;
        this.chkDay8.Checked = !this.lnkDay8.Enabled;
        this.chkDay9.Checked = !this.lnkDay9.Enabled;
        this.chkDay10.Checked = !this.lnkDay10.Enabled;
        this.chkDay11.Checked = !this.lnkDay11.Enabled;
        this.chkDay12.Checked = !this.lnkDay12.Enabled;
        this.chkDay13.Checked = !this.lnkDay13.Enabled;
        this.chkDay14.Checked = !this.lnkDay14.Enabled;
        this.chkDay15.Checked = !this.lnkDay15.Enabled;
        this.chkDay16.Checked = !this.lnkDay16.Enabled;
        this.chkDay17.Checked = !this.lnkDay17.Enabled;
        this.chkDay18.Checked = !this.lnkDay18.Enabled;
        this.chkDay19.Checked = !this.lnkDay19.Enabled;
        this.chkDay20.Checked = !this.lnkDay20.Enabled;
        this.chkDay21.Checked = !this.lnkDay21.Enabled;
        this.chkDay22.Checked = !this.lnkDay22.Enabled;
        this.chkDay23.Checked = !this.lnkDay23.Enabled;
        this.chkDay24.Checked = !this.lnkDay24.Enabled;
        this.chkDay25.Checked = !this.lnkDay25.Enabled;
        this.chkDay26.Checked = !this.lnkDay26.Enabled;
        this.chkDay27.Checked = !this.lnkDay27.Enabled;
        this.chkDay28.Checked = !this.lnkDay28.Enabled;
        this.chkDay29.Checked = !this.lnkDay29.Enabled;
        this.chkDay30.Checked = !this.lnkDay30.Enabled;
        this.chkDay31.Checked = !this.lnkDay31.Enabled;
        #endregion
    }

    #endregion

    private void SetCurrentDay(int day)
    {
        this.txtCurrentDay.Text = day.ToString();
        BindData();
    }

    private void SetData()
    {
        StandardMenuFlow sFlow = new StandardMenuFlow();
        StdMenuItemControlData itemData = sFlow.GetStdMenuItemData(Convert.ToDouble("0" + this.txtStdMenuID.Text), Convert.ToInt32("0" + this.txtCurrentDay.Text), this.txtMeal.Text, FoodType);
        this.ctlMenuDrinks.SetSource(itemData.AllDrinks);
        this.ctlMenuDrinks.SetDestination(itemData.SelectedDrinks);
        this.ctlMenuFruits.SetSource(itemData.AllFruits);
        this.ctlMenuFruits.SetDestination(itemData.SelectedFruits);
        this.ctlMenuRice.SetSource(itemData.AllRice);
        this.ctlMenuRice.SetDestination(itemData.SelectedRice);
        this.ctlMenuSavory.SetSource(itemData.AllSavory);
        this.ctlMenuSavory.SetDestination(itemData.SelectedSavory);
        this.gvStdMenuItemNutrient.DataBind();
        this.txtEnergy.Text = itemData.ENERGY.ToString(Constant.DoubleFormat);
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
            //item.UNIT = Convert.ToDouble(code[2]);
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
}
