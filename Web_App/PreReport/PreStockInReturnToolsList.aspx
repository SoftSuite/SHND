<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="PreStockInReturnToolsList.aspx.cs" Inherits="PreReport_PreStockInReturnToolsList" Title="SHND : Report - Return Stock in" %>
<%@ Register Src="../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc2" %>
<%@ Register Src="../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="headtext">
                รายงานสรุปรายการวัสดุอุปกรณ์ที่รับคืนจากหน่วยงาน</td>
        </tr>
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbPrint" runat="server" ToobarTitle="พิมพ์รายงาน" ToolbarImage="../Images/icn_print.png"/>
            </td>
        </tr>
        <tr>
            <td>
                <hr style="size:1px" /> 
            </td>
        </tr>
        <tr>
            <td>
                <table border="0" cellspacing="0" cellpadding="0" width="600px">
                    <tr style="height:24px">
                        <td style="width:130px; padding-right:10px; height: 24px;" align="right">
                            หน่วยงาน :
                        </td>
                        <td><asp:DropDownList ID="cmbDivision" runat="server" CssClass="zComboBox" Width="326px">
                        </asp:DropDownList></td>
                    </tr> 
                    <tr style="height:24px">
                        <td style="width:130px; padding-right:10px; height: 24px;" align="right">
                            ประเภทวัสดุ :
                        </td>
                        <td><asp:DropDownList ID="cmbMaterialClass" runat="server" CssClass="zComboBox" Width="326px">
                        </asp:DropDownList></td>
                    </tr> 
                    <tr runat="server" style="height:24px">
                        <td style="width:130px; padding-right:10px; height: 24px;" align="right">
                            ระหว่างวันที่ :</td>
                        <td style="height: 24px">
                            <uc2:CalendarControl ID="ctlDateFrom" runat="server" />&nbsp;<span class="zRemark">*</span>
                            &nbsp;ถึง
                            <uc2:CalendarControl ID="ctlDateTo" runat="server" />&nbsp;<span class="zRemark">*</span>
                        </td>
                    </tr> 
                </table> 
            </td>
        </tr>
    </table>
</asp:Content>