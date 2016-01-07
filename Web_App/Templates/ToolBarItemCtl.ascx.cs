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

public partial class Templates_ToolBarItemCtl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public event EventHandler Click;

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        buildToolbarButton();
        setMouseAction();
    }

    #region private fields
    string _img = "";
    string _title = "";
    #endregion

    #region public properties
    public string ToolbarImage
    {
        get { return _img; }
        set { _img = value; buildToolbarButton(); }
    }

    public string ToobarTitle
    {
        get { return _title; }
        set { _title = value; buildToolbarButton(); }
    }

    public bool Enabled
    {
        get { return lb.Enabled; }
        set { lb.Enabled = value; }
    }

    public string ClientClick
    {
        get { return lb.OnClientClick; }
        set { lb.OnClientClick = value; }
    }

    #endregion

    #region internal methods
    private void buildToolbarButton()
    {
        if (_img != "")
            lb.Text = "<img src='" + _img + "' border='0' align='AbsMiddle'> ";
        else
            lb.Text = "";

        if (_title != "")
            lb.Text += _title;
        else
            lb.Text += this.ID;

        lb.ToolTip = _title;
    }

    private const string zMouseOver = "this.className='toolbarbuttonhover'";
    private const string zMoveOut = "this.className='toolbarbutton'";
    private void setMouseAction()
    {
        lb.Attributes.Clear();
        lb.Attributes.Add("OnMouseOver", zMouseOver);
        lb.Attributes.Add("OnMouseOut", zMoveOut);
    }

    protected void lb_Click(object sender, EventArgs e)
    {
        if (Click != null)
            Click(sender, e);
    }

    #endregion
}
