<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="PreMenuPrepare.aspx.cs" Inherits="PreReport_PreMenuPrepare" Title="SHND : Pre Menu Prepare" %>

<%@ Register Src="../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc2" %>
<%@ Register Src="../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <table width="810px" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="headtext">
                &nbsp;เมนูอาหารสำรับ
            </td>
        </tr>
    </table>
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbPrint" runat="server" ToobarTitle="พิมพ์เมนูอาหาร" ToolbarImage="../Images/icn_print.png" OnClick="tbPrintClick"/>
                
            </td>
        </tr>
    </table>
    <table width="450px" border="0" cellpadding="0" cellspacing="0" style="border-right: thin solid; border-top: thin solid; border-left: thin solid; border-bottom: thin solid">
        <tr>
            <td colspan="3" class="t_headtext">
                &nbsp;กำหนดเงื่อนไข
            </td>
        </tr>
        <tr style="height:10px;">
        </tr>
        <tr>
            <td style="width:35px; height: 25px;"></td>
            <td style="width: 110px;">
                หน่วยงาน
            </td>
            <td>
                <asp:DropDownList ID="cmbDivision" runat="server" CssClass="zComboBox" Width="250px" AutoPostBack="true" OnSelectedIndexChanged="cmbDivision_SelectedIndexChanged" ></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width:35px; height: 25px;"></td>
            <td style="width: 110px">
                เมนูอาหารวันที่
            </td>
            <td>
                <uc2:CalendarControl ID="ctMenuDate" runat="server" />
                &nbsp;มื้อ&nbsp;<asp:DropDownList ID="cmbMeal" runat="server" CssClass="zComboBox" Width="93px" AutoPostBack="true" OnSelectedIndexChanged="cmbMeal_SelectedIndexChanged">
                                    <asp:ListItem Value="0" Text="ทั้งหมด"></asp:ListItem>
                                    <asp:ListItem Value="11" Text="เช้า"></asp:ListItem>
                                    <asp:ListItem Value="21" Text="กลางวัน"></asp:ListItem>
                                    <asp:ListItem Value="31" Text="เย็น"></asp:ListItem>
                                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width:35px; height: 25px;"></td>
            <td style="width: 110px">
                เวลาตัดยอด
            </td>
            <td>
                <asp:TextBox ID="txtPrintTimeFrom" runat="server" CssClass="zTextboxR" Width="45px"></asp:TextBox>
                &nbsp;ถึง&nbsp;<asp:TextBox ID="txtPrintTimeTo" runat="server" CssClass="zTextboxR" Width="45px"></asp:TextBox>
                &nbsp;<asp:Label ID="lblEx" runat="server" Text="[EX.08:00]" ForeColor="red" Font-Italic="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width:35px; height: 25px;"></td>
            <td style="width: 110px;">
                ชื่อชุดเมนู
            </td>
            <td>
                <asp:DropDownList ID="cmbMenu" runat="server" CssClass="zComboBox" Width="250px"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width:35px; height: 25px;"></td>
            <td style="width: 110px;">
                ประเภทอาหาร
            </td>
            <td>
                <asp:DropDownList ID="cmbFoodType" runat="server" CssClass="zComboBox" Width="250px"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width:35px; height: 25px;"></td>
            <td style="width: 110px;">
                ชนิดอาหาร
            </td>
            <td>
                <asp:DropDownList ID="cmbFoodCategory" runat="server" CssClass="zComboBox" Width="250px"></asp:DropDownList>
            </td>
        </tr>
        <tr style="height:15px;">
        </tr>
    </table>
    <cc1:MaskedEditExtender ID="mdeTimeFrom" runat="server" TargetControlID="txtPrintTimeFrom" MaskType="Time" Mask="99:99"></cc1:MaskedEditExtender>
    <cc1:MaskedEditExtender ID="mdeTimeTo" runat="server" TargetControlID="txtPrintTimeTo" MaskType="Time" Mask="99:99"></cc1:MaskedEditExtender>
</asp:Content>

