<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="PreMaterialOrder.aspx.cs" Inherits="PreReport_PreMaterialOrder" Title="SHND : Report - Material Order" %>

<%@ Register Src="../Templates/CalendarControl.ascx" TagName="CalendarControl"
    TagPrefix="uc2" %>
<%@ Register Src="../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="headtext">รายงานสรุปยอดการสั่งซื้อวัสดุอาหาร
            </td>
        </tr>
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbPrint" runat="server" ToobarTitle="พิมพ์รายงาน" ToolbarImage="../Images/icn_print.png" />
            </td>
        </tr>
        <tr><td><hr style="size:1px" /><asp:Label ID="txtErr" runat="server" ForeColor="Red"></asp:Label></td></tr>
        <tr>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="600">
                    <tr style="height:24px">
                        <td style="width:130px; padding-right:10px" align="right">
                            แผนประมาณการ :</td>
                        <td><asp:DropDownList ID="cmbPlan" runat="server" CssClass="zComboBox" Width="326px">
                            </asp:DropDownList>
                            </td>
                    </tr> 
                    <tr style="height:24px">
                        <td style="width:130px; padding-right:10px" align="right">
                            หมวดอาหาร :</td>
                        <td>
                            <asp:DropDownList ID="cmbClass" runat="server" CssClass="zComboBox" Width="326px">
                            </asp:DropDownList></td>
                    </tr> 
                    <tr style="height:24px">
                        <td style="width:130px; padding-right:10px" align="right">
                            หน่วยงาน :</td>
                        <td>
                            <asp:DropDownList ID="cmbDivision" runat="server" CssClass="zComboBox" Width="326px" AutoPostBack="True" OnSelectedIndexChanged="cmbDivision_SelectedIndexChanged">
                            </asp:DropDownList></td>
                    </tr> 
                    <tr style="height:24px">
                        <td style="width:130px; padding-right:10px" align="right">
                            ข้อมูลสรุป :</td>
                        <td>
                            <asp:RadioButtonList ID="rbtType" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="rbtType_SelectedIndexChanged">
                                <asp:ListItem Selected="true" Value="div">แยกตามหน่วยงาน</asp:ListItem>
                                <asp:ListItem Value="sum">สรุปรวมทั้งหมด</asp:ListItem>
                            </asp:RadioButtonList>
                            </td>
                    </tr>
                    </table> 

            </td>
        </tr>
    </table>


</asp:Content>


