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

public partial class Templates_CalendarControl : System.Web.UI.UserControl
{
    public delegate void SelectedDateChangedEvent(object sender, EventArgs e);
    public event SelectedDateChangedEvent SelectedDateChanged;

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        this.txtDate.Attributes.Add("readonly", "readonly");
    }

    public bool AutoPostBack
    {
        set
        {
                this.txtDate.AutoPostBack = value;
        }
        get
        {
            return this.txtDate.AutoPostBack;
        }
    }

    public TextBox DateControl
    {
        get { return this.txtDate; }
    }

    public string CalendarClientID
    {
        get { return this.txtDate.ClientID; }
    }

    public void SetDisableImageClient(bool visible)
    {
        this.imgCal.Style.Add("display", (visible ? "" : "none"));
    }

    public string ImageClientID
    {
        get { return this.imgCal.ClientID; }
    }

    public bool TextEnabled
    {
        set { this.txtDate.Enabled = value; }
    }

    public DateTime DateValue
    {
        get { return GetDate(); }
        set { SetDate(value); }
    }

    public bool Enabled
    {
        get { return imgCal.Style["display"] == ""; }
        set { this.imgCal.Style.Add("display", (value ? "" : "none")); }
    }

    private DateTime GetDate()
    {
        if (txtDate.Text.Trim() != "")
        {
            return DateTime.ParseExact(txtDate.Text, cb.Format, null);
        }
        else
            return new DateTime();
    }

    private void SetDate(DateTime zDate)
    {
        if (zDate.Year == 1)
            txtDate.Text = "";
        else
            this.txtDate.Text = zDate.ToString(cb.Format);
    }

    protected void txtDate_TextChanged(object sender, EventArgs e)
    {
        if (SelectedDateChanged != null) SelectedDateChanged(sender, e);
    }
}
