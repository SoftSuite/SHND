<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SHNDLogin.aspx.cs" Inherits="SHNDLogin" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SHND : Login</title>
    <link href="Templates/BaseStyle.css"
        rel="stylesheet" type="text/css" />
        
        
<script language='JavaScript'>
//check windows
if (window.name != 'SHNDSYSTEM') 
{
    //window.open(parent.document.URL, 'SHNDSYSTEM', 'resizable=yes,scrollbars=yes,width=1040,height=700');
    //window.open(parent.document.URL, 'SHNDSYSTEM', 'resizable=yes,scrollbars=yes,fullscreen=yes');
    //
    FullScreenWindow();
    document.location = 'default.aspx';
}

function FullScreenWindow(){
    var params = [
        'height='+screen.height,
        'width='+screen.width,
        'fullscreen=yes' // only works in IE, but here for completeness
    ].join(',');
    var popup = window.open('SHNDMain.aspx', 'SHNDSYSTEM', params); 
    popup.moveTo(0,0);
    
    return false;
}


</script>
</head>
<body style="background-color:#eeeeee">
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate" OnLoggingIn="Login1_LoggingIn" OnLoginError="Login1_LoginError" Width="100%" OnLoggedIn="Login1_LoggedIn">
            <LayoutTemplate>
<table width="380" cellpadding="0" cellspacing="0" style="border-color: #0000cc; border-width: 3px; border-style:solid; background-color:#ffffff; " align="center">
        <tr>
            <td colspan="2" style="height:75px; background-color:#cc00cc;">
                <img src="Images/theme01.png" />
            </td>
        </tr>
        <tr>
            <td style="width:100px; padding: 3px 3px 3px 3px;" align="center"><img src="Images/keys.png" /></td>
            <td valign="top">
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td colspan="2" style="height:15px">
                        </td>
                    </tr>
                    <tr style="height:25px">
                        <td style="width:80px" align=right>
                        <strong></strong>
                                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">ชื่อเข้าระบบ :</asp:Label>
                        </td>
                        <td style="padding: 3px 3px 3px 3px">
                                        <asp:TextBox ID="UserName" runat="server" CssClass="zTextbox" Width="130px"></asp:TextBox>&nbsp;
                            <font style="color:red">*</font></td>
                    </tr>
                    <tr style="height:25px">
                        <td style="width:80px" align=right>
                                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">รหัสผ่าน :</asp:Label>
                        </td>
                        <td style="padding: 3px 3px 3px 3px">
                                        <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="zTextbox" Width="130px"></asp:TextBox>&nbsp;
                            <font style="color:red">*</font></td>
                    </tr>
                    <tr style="height: 25px">
                        <td align="right" style="width: 80px">
                        </td>
                        <td style="padding-right: 3px; padding-left: 3px; padding-bottom: 3px; padding-top: 3px">
                                        <asp:CheckBox ID="RememberMe" runat="server" Text="จดจำการเข้าระบบ" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="height:15px" align="center">
                <hr size="1" style=" border-style:solid; border-width:1px; height:0px; color:#dd00dd; width:95%;" />
                <span style="color:red"><asp:Literal ID="FailureText" runat="server" EnableViewState="False" Visible="False"></asp:Literal></span>
            </td>
        </tr>
        <tr>
            <td></td>
            <td align="right">
                                        <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="ลงชื่อเข้าใช้" ValidationGroup="Login1" CssClass="zButton" Font-Bold="True" />
                                    &nbsp;&nbsp;&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" style="height:15px">
            
            </td>
        </tr>
    </table>            
            </LayoutTemplate>
        </asp:Login>
         <cc1:ModalPopupExtender ID="zPop" runat="server" PopupControlID="Panel1" TargetControlID="Button1" BackgroundCssClass="modalBackground" DropShadow="true">
        </cc1:ModalPopupExtender>
            <asp:Button ID="Button1" runat="server" Text="Button" Width="0px" CssClass="zHidden" />
            <asp:Panel ID="Panel1" runat="server" Width="100%">
            <table width="400" bgcolor="#ffffff" style="border: solid 1px 1px 1px 1px #ff0000" id="tbError" runat="server" visible="false">
            <tr>
                <td style="height:100px;" valign="middle" align="center">
                    <asp:Label ID="lblError" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                    <br />
                    <br />
                    <asp:Button ID="btnClose" runat="server" CssClass="zButton" OnClick="btnClose_Click"
                        Text="ปิด" Width="50px" /></td>
            </tr>
            </table>
            </asp:Panel>
        </ContentTemplate>
        </asp:UpdatePanel>
        &nbsp;
       &nbsp;&nbsp;
    </div>
    </form>
</body>
</html>
