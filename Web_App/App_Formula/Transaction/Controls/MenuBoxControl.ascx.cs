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
using SHND.Flow.Formula;
using SHND.Global;

public partial class App_Formula_Transaction_Controls_MenuBoxControl : System.Web.UI.UserControl
{
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
            }
            else
            {
                this.btnAdd.CssClass = "";
                this.btnRemove.CssClass = "";
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

    public bool UnitEnabled
    {
        set
        {
            this.lblUnit.Visible = value;
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
    protected void lstAll_SelectedIndexChanged(object sender, EventArgs e)
    {

            string[] item = lstAll.SelectedValue.Split('#');
        //    try
        //    {
                Appz.BuildCombo(this.cmbUnit, "V_MATERIALMASTER_UNIT", "UNITNAME", "UNIT", "MATERIALMASTER=" + Convert.ToDouble(item[0]), "", null, null, false);
       //     }
         //   catch (Exception ex)
         //   {
         //   }
    }
}
