<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="SHNDChangePassword.aspx.cs" Inherits="SHNDChangePassword" Title="SHND System : เปลี่ยนรหัสผ่าน" %>

<%@ Register Src="Templates/MenuCtl.ascx" TagName="MenuCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <br />
    <br />
    <br />
    <center><span style="text-align:center; font-size:13pt">เปลี่ยนรหัสผ่าน</span></center>
    <br />
    <br />
    <table width="380" cellpadding="0" cellspacing="0" style="border-color: #0000cc; border-width: 3px; border-style:solid; background-color:#ffffff; " align="center" id="TABLE1">
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
                        <td style="width:100px" align=right>
                        <strong></strong>
                                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="txtUserName">ชื่อเข้าระบบ :</asp:Label>
                        </td>
                        <td style="padding: 3px 3px 3px 3px">
                                        <asp:TextBox ID="txtUserName" runat="server" CssClass="zTextboxView" Width="130px" ReadOnly="True"></asp:TextBox>&nbsp;
                            <font style="color:red">*</font></td>
                    </tr>
                    <tr style="height:25px">
                        <td style="width:100px" align=right>
                                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="txtOPass">รหัสผ่านเดิม :</asp:Label>
                        </td>
                        <td style="padding: 3px 3px 3px 3px">
                                        <asp:TextBox ID="txtOPass" runat="server" TextMode="Password" CssClass="zTextbox" Width="130px"></asp:TextBox>&nbsp;
                            <font style="color:red">*</font></td>
                    </tr>
                    <tr style="height: 25px">
                        <td align="right" style="width: 100px">
                            <asp:Label ID="lblNPass" runat="server" AssociatedControlID="txtNPass">รหัสผ่านใหม่ :</asp:Label></td>
                        <td style="padding-right: 3px; padding-left: 3px; padding-bottom: 3px; padding-top: 3px">
                            <asp:TextBox ID="txtNPass" runat="server" CssClass="zTextbox" TextMode="Password"
                                Width="130px"></asp:TextBox>&nbsp; <font style="color:red">*</font></td>
                    </tr>
                    <tr style="height: 25px">
                        <td align="right" style="width: 100px">
                            <asp:Label ID="lblCPass" runat="server" AssociatedControlID="txtCPass">ยืนยันรหัสผ่านใหม่ :</asp:Label></td>
                        <td style="padding-right: 3px; padding-left: 3px; padding-bottom: 3px; padding-top: 3px">
                            <asp:TextBox ID="txtCPass" runat="server" CssClass="zTextbox" TextMode="Password"
                                Width="130px"></asp:TextBox>&nbsp; <font style="color:red">*</font></td>
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
                                        <asp:Button ID="btnChangePassword" runat="server" Text="เปลี่ยนรหัสผ่าน" ValidationGroup="Login1" CssClass="zButton" Font-Bold="True" OnClick="btnChangePassword_Click" />
                                    &nbsp;&nbsp;&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" style="height:15px">
            
            </td>
        </tr>
    </table>            
    <asp:Panel ID="Panel1" runat="server" Width="100%">
        <cc1:modalpopupextender id="zPop" runat="server" backgroundcssclass="modalBackground"
            dropshadow="true" popupcontrolid="Panel1" targetcontrolid="Button1">
        </cc1:modalpopupextender>
        <asp:Button ID="Button1" runat="server" CssClass="zHidden" Text="Button" Width="0px" /><table id="tbError" runat="server" bgcolor="#ffffff" style="border-right: #ff0000 1px solid;
            border-top: #ff0000 1px solid; border-left: #ff0000 1px solid; border-bottom: #ff0000 1px solid"
            visible="false" width="400">
            <tr>
                <td align="center" style="height: 100px" valign="middle">
                    <asp:Label ID="lblError" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                    <br />
                    <br />
                    <asp:Button ID="btnClose" runat="server" CssClass="zButton" OnClick="btnClose_Click"
                        Text="ปิด" Width="50px" /></td>
            </tr>
        </table>
    </asp:Panel>
    <asp:TextBox ID="txtLogout" runat="server" Visible="False"></asp:TextBox>

</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MenuContent">
    <uc1:MenuCtl ID="MenuCtl1" runat="server" MenuLOID="PW" />
</asp:Content>

