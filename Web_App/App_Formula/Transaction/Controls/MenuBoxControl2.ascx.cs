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
using SHND.Data.Common.Utilities;
using SHND.Data.Formula;
using SHND.Data.Tables;
using SHND.Global;

public partial class App_Formula_Transaction_Controls_MenuBoxControl2 : System.Web.UI.UserControl
{
    public delegate void ClickChangedEvent(object sender, EventArgs e);
    public event ClickChangedEvent ClickChanged;
    public double MenuID;
    public DateTime Menudate;
    public string Meal;
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        Appz.BuildCombo(this.cmbUnit, "UNIT", "ABBNAME", "LOID", "", "", "เลือก", "0", false);
        Appz.BuildCombo(this.cmbUnitSelect, "V_MATERIALMASTER_UNIT", "UNITNAME", "UNIT", "", "", null, null, false);

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "Z2SCRIPT", @"
<script language='JavaScript'>
// ย้ายข้อมูลที่เลือกจาก list box หนึ่งไปยัง listbox หนึ่ง
function lstmove(lst1, lst2, cmb, txt)
{
	lsSrc = document.getElementById(lst1);
	lsDes = document.getElementById(lst2);
    cm = document.getElementById(cmb);
    tx = document.getElementById(txt);
    ret = true;
	for ( var i = 0 ; i < lsSrc.length ; i++ ){
		opt = lsSrc.options[i];
		if (opt.selected)
        {
            if (opt.value.split('#').length >= 5)//ลบออกจากฝั่งที่เลือกไว้
            {
                lsDes.add( new Option(trim(opt.text.split('[')[0]), opt.value.split('#')[0] + '#' + opt.value.split('#')[1] + '#' + opt.value.split('#')[2]) );
            }
            else
            {
                if (opt.value.split('#')[1] == 'FORMULASET')
                {
                    lsDes.add( new Option(opt.text, opt.value + '#0#0') );
                }
                else
                {
                    if (parseFloat('0' + tx.value) <= 0)
                    {
                        alert('" + string.Format(DataResources.MSGEI001, "จำนวน") + @"');
                        ret = false;
                    }
                    else
                    {
                        lsDes.add( new Option(opt.text + ' [' + ClearComma(tx.value) + ' ' + cm.options[cm.selectedIndex].text + ']', opt.value + '#' + cm.value + '#' + ClearComma(tx.value)) );
                    }
                }
            }
        }
	}

    if (ret)
    {
	    for ( var i = lsSrc.length - 1; i >= 0 ; i-- ) {
		    opt = lsSrc.options[i];
		    if (opt.selected)
			    lsSrc.remove(i);
	    }
    }
}

function getlstvalue(lst, tmp)
{
	zlst = document.getElementById(lst);
	ztmp = document.getElementById(tmp);
	ret = '';
	for ( var i = 0 ; i < zlst.length ; i++ ){
		ret = ret + zlst.options[i].value;
		if (i < zlst.length - 1)
			ret = ret + ',';
	}
	ztmp.value = ret;
}

function SetCombo(lst, cmb, txt)
{
	ls = document.getElementById(lst);
    cm = document.getElementById(cmb);
    tx = document.getElementById(txt);

	for ( var i = 0 ; i < ls.length ; i++ ){
		opt = ls.options[i];
		if (opt.selected)
        {
            if (opt.value.split('#')[1] == 'FORMULASET')
            {
                tx.value = '';
                tx.disabled = 'disabled';
                cm.disabled = 'disabled';
                cm = 0;
            }
            else
            {
                cm.value = opt.value.split('#')[2];
                tx.disabled = '';
                cm.disabled = '';
            }
        }
	}

}

</script>
");

        // Put user code to initialize the page here
        if (!IsPostBack)
        {
            ControlUtil.SetIntTextBox(this.txtQty);
            string UpdateVal = "getlstvalue('" + lstSelect.ClientID + "', '" + lstSelect.ClientID + "_zLstSelect');getlstvalue('" + lstAll.ClientID + "', '" + lstAll.ClientID + "_zLstNoSelect');";
            btnAdd.Attributes.Add("OnClick", "lstmove('" + lstAll.ClientID + "','" + lstSelect.ClientID + "','" + cmbUnit.ClientID + "','" + txtQty.ClientID + "');" + UpdateVal + "return false;");
            btnRemove.Attributes.Add("OnClick", "lstmove('" + lstSelect.ClientID + "','" + lstAll.ClientID + "','" + cmbUnit.ClientID + "','" + txtQty.ClientID + "');" + UpdateVal + "return false;");
            lstAll.Attributes.Add("OnClick", "SetCombo('" + lstAll.ClientID + "', '" + cmbUnit.ClientID + "', '" + this.txtQty.ClientID + "');");
        }
        else
        {
           
                KeepState();
        }
    }

    public bool Readonly
    {
        set
        {
            if (value)
            {
                this.btnAdd.CssClass = "zHidden";
                this.btnRemove.CssClass = "zHidden";
                this.btnChange.CssClass = "";
            }
            else
            {
                this.btnAdd.CssClass = "";
                this.btnRemove.CssClass = "";
                this.btnChange.CssClass = "zHidden";
            }
        }
    }

    public bool QuantityEnabled
    {
        set
        {
            this.lblQty.Visible = value;
            this.txtQty.CssClass = (value ? "zTextboxR" : "zHidden");
            this.cmbUnit.CssClass = (value ? "zComboBox" : "zHidden");
        }
    }

    public void SetSource(DataTable zDt)
    {
        lstAll.DataSource = zDt;
        lstAll.DataTextField = "FORMULANAME";
        lstAll.DataValueField = "CODEUNIT";
        lstAll.DataBind();
    }

    public void SetDestination(DataTable zDt)
    {
        lstSelect.DataSource = zDt;
        lstSelect.DataTextField = "FORMULANAME";
        lstSelect.DataValueField = "CODEUNIT";
        lstSelect.DataBind();
    }

    public ArrayList SelectedData
    {
        get
        {
            ArrayList zLst = new ArrayList();
            for (int i = 0; i < lstSelect.Items.Count; i++)
            {
                zLst.Add(lstSelect.Items[i].Value);
            }
            return zLst;
        }
    }

    private void KeepState()
    {
        // keep state for noauth
        string zSel = Request[lstAll.ClientID + "_zLstNoSelect"];
        if (zSel != null && zSel.Trim().Length > 0)
        {
            string[] AllSel = zSel.Split(',');
            for (int i = 0; i < AllSel.Length; i++)
            {
                ListItem zItm = null;
                for (int k = 0; k < lstSelect.Items.Count; ++k)
                {
                    if (lstSelect.Items[k].Value.Split('#')[0] + "#" + lstSelect.Items[k].Value.Split('#')[1] + "#" + lstSelect.Items[k].Value.Split('#')[2] == AllSel[i].Trim())
                    {
                        zItm = lstSelect.Items[k];
                        break;
                    }
                }

                if (zItm != null)
                {
                    lstAll.Items.Add(new ListItem(zItm.Text.Split('[')[0], AllSel[i].Trim()));
                    lstSelect.Items.Remove(zItm);
                }

            }
        }
        //keep state for auth
        zSel = Request[lstSelect.ClientID + "_zLstSelect"];
        if (zSel != null && zSel.Trim().Length > 0)
        {
            string[] AllSel = zSel.Split(',');
            for (int i = 0; i < AllSel.Length; i++)
            {
                ListItem zItm = lstAll.Items.FindByValue(AllSel[i].Trim().Split('#')[0] + "#" + AllSel[i].Trim().Split('#')[1] + "#" + AllSel[i].Trim().Split('#')[2]);
                if (zItm != null)
                {
                    this.cmbUnitSelect.SelectedIndex = cmbUnitSelect.Items.IndexOf(cmbUnitSelect.Items.FindByValue(AllSel[i].Trim().Split('#')[3]));
                    lstSelect.Items.Add(new ListItem(zItm.Text + (AllSel[i].Trim().Split('#')[4] != "0" ? (" [" + AllSel[i].Trim().Split('#')[4] + cmbUnitSelect.SelectedItem.Text + "]") : ""), AllSel[i].Trim()));
                    lstAll.Items.Remove(zItm);
                }
                if (AllSel[i].Trim().Split('#')[4] != "0")
                {
                    for (int k = 0; k < lstSelect.Items.Count; ++k)
                    {
                        if (lstSelect.Items[k].Value.Split('#')[0] + "#" + lstSelect.Items[k].Value.Split('#')[1] + "#" + lstSelect.Items[k].Value.Split('#')[2] == AllSel[i].Trim().Split('#')[0] + "#" + AllSel[i].Split('#')[1] + "#" + AllSel[i].Split('#')[2])
                        {
                            this.cmbUnitSelect.SelectedIndex = cmbUnitSelect.Items.IndexOf(cmbUnitSelect.Items.FindByValue(AllSel[i].Trim().Split('#')[3]));
                            lstSelect.Items[k].Value = AllSel[i];
                            lstSelect.Items[k].Text = lstSelect.Items[k].Text.Split('[')[0].Trim() + " [" + AllSel[i].Trim().Split('#')[4] + " " + this.cmbUnitSelect.SelectedItem.Text + "]";
                            break;
                        }
                    }
                }
            }
        }
    }

    protected void btnShowSelect_Click(object sender, EventArgs e)
    {
        if (this.lstSelect.SelectedItem != null)
        {
            ShowData(this.lstSelect.SelectedItem.Value, this.lstSelect.SelectedItem.Text);
        }
    }
    protected void btnShowAll_Click(object sender, EventArgs e)
    {
        if (this.lstAll.SelectedItem != null)
        {
            ShowData(this.lstAll.SelectedItem.Value, this.lstAll.SelectedItem.Text);
        }
    }

    protected void btnChange_Click(object sender, EventArgs e)
    {
        if (this.lstSelect.SelectedItem != null)
        {
            string code = this.lstSelect.SelectedItem.Value;
            string[] item = code.Split('#');
            MenuFlow fFlow = new MenuFlow();
            MenuChangeData fData = new MenuChangeData();
            if (item[1] == "FORMULASET")
            {
                txtMenuQty.CssClass = "zTextbox-View";
                txtMenuQty.ReadOnly = true;
                txtRef.Text = "FORMULASET";
                fData = fFlow.GetMenuChange(MenuID, Menudate, Meal, Convert.ToDouble("0" + item[0]));
            }
            else
            {
                txtMenuQty.CssClass = "zTextbox";
                txtMenuQty.ReadOnly = false;
                txtRef.Text = "MATERIALMASTER";
                fData = fFlow.GetMenuChangeM(MenuID, Menudate, Meal, Convert.ToDouble("0" + item[0]));
            }
            txtCatgory.Text = fData.FOODCATEGORY;
            txtgroup.Text = fData.GROUPTYPE;
            if (fData.GROUPTYPE == "OD")
                txtGroupName.Text = "อาหารจานเดียว";
            else if (fData.GROUPTYPE == "ND")
                txtGroupName.Text = "กับข้าว";
            else if (fData.GROUPTYPE == "FR")
                txtGroupName.Text = "ผลไม้";
            else
                txtGroupName.Text = "เครื่องดื่ม";
            txtMeal.Text = fData.MEAL;
            if (fData.MEAL == "11")
                txtMealName.Text = "เช้า";
            else if (fData.MEAL == "21")
                txtMealName.Text = "กลางวัน";
            else 
                txtMealName.Text = "เย็น";
            txtMenu.Text = fData.MENULOID.ToString();
            txtMenuName.Text = fData.MENUNAME;
            txtOldMenu.Text = fData.MATERIALNAME;
            txtMaterial.Text = fData.MATERIALMASTER.ToString();
            txtType.Text = fData.FOODTYPE;
            ctlDate.DateValue = fData.MENUDATE;
            txtMenuItem.Text = fData.MENUITEMLOID.ToString();
            txtMenuQty.Text = fData.QTY.ToString();
            txtUnit.Text = fData.UNIT.ToString();
            txtDateLoid.Text = fData.MENUDATELOID.ToString();
            Appz.BuildCombo(this.cmbMenu, "V_FORMULASET_MENU", "FORMULANAME", "CODE", "GROUPTYPE = '" + fData.GROUPTYPE + "' AND CODE NOT IN (SELECT CODE FROM V_MENUITEM WHERE MENU = " + fData.MENULOID.ToString() +
                " AND MEAL = '" + fData.MEAL + "' AND MENUDATE = " + SetDateTime(fData.MENUDATE) + " AND GROUPTYPE = '" + fData.GROUPTYPE + "') ", "", "เลือก", "0", false);

            popupChange.Show();
        }
    }

    public static string SetDateTime(DateTime DateIn)
    {
        return (DateIn.Year == 1 ? "null" : "TO_DATE('" + DateIn.Year.ToString("0000") + DateIn.ToString("-MM-dd HH:mm:ss") + "', 'YYYY-MM-DD HH24:MI:SS')");
    }

    private void ShowData(string code, string name)
    {
        string[] item = code.Split('#');
        if (item[1] == "FORMULASET")
        {
            StandardMenuFlow fFlow = new StandardMenuFlow();
            this.gvFormulaSetItem.DataSource = fFlow.GetFormulaSetItemList(Convert.ToDouble("0" + item[0]));
            this.gvFormulaSetItem.DataBind();
            this.lblFormulaSetName.Text = name;
            popupFormulaSet.Show();
        }
    }

    protected void tbSaveClick(object sender, EventArgs e)
    {

        if(cmbMenu.SelectedValue == "0")
        {
            lblErr.Text = string.Format(DataResources.MSGEI002, "เมนู");
            popupChange.Show();
        }
        else
        {
            bool ret = true;
            string code = this.cmbMenu.SelectedValue;
            string[] item = code.Split('#');

            MenuFlow fFlow = new MenuFlow();
            MenuItemChangeData mData = new MenuItemChangeData();
            mData.GROUPTYPE = txtgroup.Text;
            mData.MEAL = txtMeal.Text;
            mData.QTY = Convert.ToDouble(txtMenuQty.Text);
            mData.MENUDATE = Convert.ToDouble(txtDateLoid.Text);
            mData.UNIT = Convert.ToDouble(txtUnit.Text);
        if (item[1] == "FORMULASET" & txtRef.Text == "FORMULASET")
        {
            mData.FORMULASET = Convert.ToDouble(txtMaterial.Text);
            mData.FORMULASET_NEW = Convert.ToDouble("0" + item[0]);
            mData.MATERIALMASTER = 0;
            mData.MATERIALMASTER_NEW = 0;
        }
        else if (item[1] == "FORMULASET" & txtRef.Text == "MATERIALMASTER")
        {
            mData.FORMULASET = 0;
            mData.FORMULASET_NEW = Convert.ToDouble("0" + item[0]);
            mData.MATERIALMASTER = Convert.ToDouble(txtMaterial.Text);
            mData.MATERIALMASTER_NEW = 0;
        }
        else if (item[1] == "MATERIALMASTER" & txtRef.Text == "FORMULASET")
        {
            mData.FORMULASET = Convert.ToDouble(txtMaterial.Text);
            mData.FORMULASET_NEW = 0;
            mData.MATERIALMASTER = 0;
            mData.MATERIALMASTER_NEW = Convert.ToDouble("0" + item[0]);
        }
        else
        {
            mData.FORMULASET = 0;
            mData.FORMULASET_NEW = 0;
            mData.MATERIALMASTER = Convert.ToDouble(txtMaterial.Text);
            mData.MATERIALMASTER_NEW = Convert.ToDouble("0" + item[0]);
        }
        ret = fFlow.InsertChange(mData,Convert.ToDouble(txtMenuItem.Text), Appz.CurrentUser);
        if(ret)
            if (ClickChanged != null) ClickChanged(sender, e);
        }
    }

    protected void cmbMenu_SelectedIndexChanged(object sender, EventArgs e)
    {
        string code = this.cmbMenu.SelectedValue;
        string[] item = code.Split('#');
        if (item[1] == "MATERIALMASTER")
        {
            txtMenuQty.CssClass = "zTextbox";
            txtMenuQty.ReadOnly = false;
        }
        else
        {
            txtMenuQty.CssClass = "zTextbox-View";
            txtMenuQty.ReadOnly = true;
        }
        popupChange.Show();
    }
    protected void lstAll_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.cmbUnit.CssClass == "zComboBox")
        {
            string[] item = lstAll.SelectedValue.Split('#');
            Appz.BuildCombo(this.cmbUnit, "V_MATERIALMASTER_UNIT", "UNITNAME", "UNIT", "MATERIALMASTER=" + Convert.ToDouble(item[0]), "", null, null, false);
        }
    }
}
