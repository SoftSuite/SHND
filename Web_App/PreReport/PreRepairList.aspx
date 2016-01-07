<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="PreRepairList.aspx.cs" Inherits="PreReport_PreRepairList" Title="SHND : Report - Repair List" %>
<%@ Register Src="../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc2" %>
<%@ Register Src="../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="headtext">
                ��§ҹ�ʴ���¡����ʴ��ػ�ó����ա���觫���</td>
        </tr>
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbPrint" runat="server" ToobarTitle="�������§ҹ" ToolbarImage="../Images/icn_print.png" />
            </td>
        </tr>
        <tr>
            <td><hr style="size:1px" />
            </td>
        </tr>
        <tr>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="600">
                    <tr style="height:24px">
                        <td style="width:130px; padding-right:10px; height: 23px;" align="right">
                            ˹��§ҹ :</td>
                        <td style="height: 23px" colspan="3">
                            <asp:DropDownList ID="cmbDivision" runat="server" CssClass="zComboBox" Width="312px">
                            </asp:DropDownList></td>
                    </tr>  
                    <tr style="height: 24px">
                        <td align="right" style="padding-right: 10px; width: 130px; height: 23px">
                            ��������ʴ� :</td>
                        <td colspan="3" style="height: 23px">
                            <asp:DropDownList ID="cmbMaterialClass" runat="server" CssClass="zComboBox" Width="312px">
                            </asp:DropDownList></td>
                    </tr>
                    <tr style="height: 24px">
                        <td align="right" style="padding-right: 10px; width: 130px; height: 23px">
                            ��ʴ��ػ�ó� :</td>
                        <td colspan="3" style="height: 23px">
                            <asp:DropDownList ID="cmbMaterialMaster" runat="server" CssClass="zComboBox" Width="312px">
                            </asp:DropDownList></td>
                    </tr>
                    <tr style="height: 24px">
                        <td align="right" style="padding-right: 10px; width: 130px; height: 23px">
                            �ѹ����駫��� :</td>
                        <td style="width: 151px; height: 23px">
                            <uc2:CalendarControl ID="ctlStockOutDateFrom" runat="server" />&nbsp;<span class="zRemark">*</span>
                        </td>
                        <td style="width: 30px; height: 23px">
                            �֧</td>
                        <td style="height: 23px">
                            <uc2:CalendarControl ID="ctlStockOutDateTo" runat="server" />&nbsp;<span class="zRemark">*</span>
                        </td>
                    </tr>
                    <tr style="height: 24px">
                        <td align="right" style="padding-right: 10px; width: 130px; height: 23px">
                            �š�ë��� :</td>
                        <td colspan="3" style="height: 23px">
                            <asp:RadioButtonList ID="rblRepairStatus" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="Z">������</asp:ListItem>
                                <asp:ListItem Value="Y">������</asp:ListItem>
                                <asp:ListItem Value="N">���������</asp:ListItem>
                            </asp:RadioButtonList></td>
                    </tr>
                    <tr style="height: 24px">
                        <td align="right" style="padding-right: 10px; width: 130px; height: 23px">
                            ʶҹ� :</td>
                        <td style="width: 151px; height: 23px">
                            <asp:DropDownList ID="cmbStatusFrom" runat="server" CssClass="zComboBox" Width="132px">
                                <asp:ListItem Value="00">����¡��</asp:ListItem>
                                <asp:ListItem Value="01">��͹��ѵ�</asp:ListItem>
                                <asp:ListItem Value="02">͹��ѵ�</asp:ListItem>
                                <asp:ListItem Value="05">¡��ԡ</asp:ListItem>
                            </asp:DropDownList></td>
                        <td style="width: 30px; height: 23px">
                            �֧</td>
                        <td style="height: 23px">
                            <asp:DropDownList ID="cmbStatusTo" runat="server" CssClass="zComboBox" Width="132px">
                                <asp:ListItem Value="00">����¡��</asp:ListItem>
                                <asp:ListItem Value="01">��͹��ѵ�</asp:ListItem>
                                <asp:ListItem Value="02">͹��ѵ�</asp:ListItem>
                                <asp:ListItem Value="05">¡��ԡ</asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>
                    </table> 
            </td>
        </tr>
    </table>
</asp:Content>