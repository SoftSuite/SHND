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

public partial class App_Formula_Transaction_Controls_MenuBoxControlMenu : System.Web.UI.UserControl
{
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        Appz.BuildCombo(this.cmbUnit, "UNIT", "ABBNAME", "LOID", "", "", "เลือก", "0", false);
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
            if (opt.text.split('[').length == 1 && opt.value.split('#')[2] != '0' && tx.className != 'zHidden') //source
            {
                if (parseFloat('0' + tx.value) <= 0)
                {
                    alert('" + string.Format(DataResources.MSGEI001, "จำนวน") + @"');
                    ret = false;
                }
                else
                {
			        lsDes.add( new Option(opt.text + ' [' + ClearComma(tx.value) + ' ' + cm.options[cm.selectedIndex].text + ']', opt.value + '#' + cm.value + '#' + ClearComma(tx.value)) );
                    //lsDes.add( new Option(opt.text, opt.value) );
                }
            }
            else
            {
                lsDes.add( new Option(trim(opt.text.split('[')[0]), opt.value.split('#')[0] + '#' + opt.value.split('#')[1] + '#' + opt.value.split('#')[2]) );
                //lsDes.add( new Option(opt.text, opt.value) );
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

// ย้ายข้อมูลทั้งหมดจาก list box หนึ่งไปยัง listbox หนึ่งง
function lstmoveall(lst1, lst2)
{
	lsSrc = document.getElementById(lst1);
	lsDes = document.getElementById(lst2);

	for ( var i = 0 ; i < lsSrc.length ; i++ ){
		opt = lsSrc.options[i];
		lsDes.add( new Option(opt.text, opt.value) );
	}

	for ( var i = lsSrc.length - 1; i >= 0 ; i-- ) {
		opt = lsSrc.options[i];
		lsSrc.remove(i);
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

function SetCombo(lst, cmb)
{
	ls = document.getElementById(lst);
    cm = document.getElementById(cmb);

	for ( var i = 0 ; i < ls.length ; i++ ){
		opt = ls.options[i];
		if (opt.selected)
            cm.value = opt.value.split('#')[2];
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
            lstAll.Attributes.Add("OnClick", "SetCombo('" + lstAll.ClientID + "', '" + cmbUnit.ClientID + "');");
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
        }
    }

    public bool QuantityEnabled
    {
        set
        {
            this.lblQty.Visible = value;
            this.txtQty.CssClass = (value ? "zTextboxR" : "zHidden");
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
                if (this.lblQty.Visible)
                {
                    ListItem zItm = null; // = lstSelect.Items.FindByValue(AllSel[i].Trim());
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
                else
                {
                    ListItem zItm = lstSelect.Items.FindByValue(AllSel[i].Trim());
                    if (zItm != null)
                    {
                        lstAll.Items.Add(zItm);
                        lstSelect.Items.Remove(zItm);
                    }
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
                if (this.lblQty.Visible)
                {
                    ListItem zItm = lstAll.Items.FindByValue(AllSel[i].Trim().Split('#')[0] + "#" + AllSel[i].Trim().Split('#')[1] + "#" + AllSel[i].Trim().Split('#')[2]);

                    if (zItm != null)
                    {
                        this.cmbUnit.SelectedIndex = cmbUnit.Items.IndexOf(cmbUnit.Items.FindByValue(AllSel[i].Trim().Split('#')[3]));
                        lstSelect.Items.Add(new ListItem(zItm.Text + (AllSel[i].Trim().Split('#')[3] != "" ? (" [" + AllSel[i].Trim().Split('#')[4] + cmbUnit.SelectedItem.Text + "]") : ""), AllSel[i].Trim()));
                        lstAll.Items.Remove(zItm);
                    }
                }
                else
                {
                    ListItem zItm = lstAll.Items.FindByValue(AllSel[i].Trim());
                    if (zItm != null)
                    {
                        lstSelect.Items.Add(zItm);
                        lstAll.Items.Remove(zItm);
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
}
