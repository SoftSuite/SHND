<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="PreStockInReturnMaterialList.aspx.cs" Inherits="PreReport_PreStockInReturnMaterialList" Title="SHND : Pre Stock In Return Material List" %>
<%@ Register Src="../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <table width="810px" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="headtext">
                &nbsp;รายงานสรุปรายการวัสดุอาหารที่รับคืนจากหน่วยงาน
            </td>
        </tr>
    </table>
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbPrint" runat="server" ToobarTitle="พิมพ์รายงาน" ToolbarImage="../Images/icn_print.png" OnClick="tbPrintClick"/>
                
            </td>
        </tr>
    </table>
    <table width="450px" border="0" cellpadding="0" cellspacing="0" style="border-right: thin solid; border-top: thin solid; border-left: thin solid; border-bottom: thin solid">
        <tr>
            <td colspan="3" class="t_headtext">
                &nbsp;กำหนดเงื่อนไข
            </td>
        </tr>
        <tr>
            <td style="height: 20px;" valign="middle" colspan="3">&nbsp;<asp:Label ID="lblStatus" runat="server" ForeColor="red"></asp:Label></td>
        </tr>
        <tr>
            <td style="width:35px; height: 25px;"></td>
            <td style="width: 110px;">
                หน่วยงาน
            </td>
            <td>
                <asp:DropDownList ID="cmbDivision" runat="server" CssClass="zComboBox" Width="282px"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width:35px; height: 25px;"></td>
            <td style="width: 110px;">
                หมวดอาหาร
            </td>
            <td>
                <asp:DropDownList ID="cmbMaterialClass" runat="server" CssClass="zComboBox" Width="282px"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width:35px; height: 25px;"></td>
            <td style="width: 110px;">
                ระหว่างวันที่
            </td>
            <td>
                <uc2:CalendarControl ID="ctDateFrom" runat="server" />
                ถึง&nbsp;<uc2:CalendarControl ID="ctDateTo" runat="server" />
                
            </td>
        </tr>
        <tr style="height:20px;">
        </tr>
    </table>
</asp:Content>

