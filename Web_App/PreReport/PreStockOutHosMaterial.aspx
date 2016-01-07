<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="PreStockOutHosMaterial.aspx.cs" Inherits="PreReport_PreStockOutHosMaterial" Title="SHND : Report - Tool Stock out (Return to main warehouse)" %>
<%@ Register Src="../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc2" %>
<%@ Register Src="../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="headtext">��§ҹ��ػ�ʹ��ʴ��ػ�ó����觤׹��ѧ�ͧ�ç��Һ��
            </td>
        </tr>
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbPrint" runat="server" ToobarTitle="�������§ҹ" ToolbarImage="../Images/icn_print.png"/>
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
                            ��������ʴ� :
                        </td>
                        <td><asp:DropDownList ID="cmbMaterialClass" runat="server" CssClass="zComboBox" Width="326px">
                        </asp:DropDownList></td>
                    </tr> 
                    <tr style="height:24px">
                        <td style="width:130px; padding-right:10px; height: 24px;" align="right">
                            ��ʴ��ػ�ó� :</td>
                        <td style="height: 24px">
                            <asp:DropDownList ID="cmbMaterialMaster" runat="server" CssClass="zComboBox" Width="326px" OnSelectedIndexChanged="cmbMaterialMaster_SelectedIndexChanged" AutoPostBack="True">
                            </asp:DropDownList>&nbsp; ˹��� &nbsp;<asp:DropDownList ID="cmbUnit" runat="server" CssClass="zComboBox" Width="70px" Enabled="False">
                            </asp:DropDownList></td>
                    </tr> 
                    <tr style="height:24px">
                        <td style="width:130px; padding-right:10px; height: 24px;" align="right">
                            ��������ػ :</td>
                        <td style="height: 24px">
                            <asp:RadioButtonList ID="rbtType" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Selected="true" Value="dd">����ѹ</asp:ListItem>
                                <asp:ListItem Value="mm">�����͹</asp:ListItem>
                                <asp:ListItem Value="yy">��»�</asp:ListItem>
                            </asp:RadioButtonList>
                            </td>
                    </tr>
                    <tr id="pnlDate"  runat="server" style="height:24px">
                        <td style="width:130px; padding-right:10px; height: 24px;" align="right">
                            �����ҧ�ѹ��� :</td>
                        <td style="height: 24px">
                            <uc2:CalendarControl ID="ctlDateFrom" runat="server" />&nbsp;<span class="zRemark">*</span>
                            &nbsp;�֧
                            <uc2:CalendarControl ID="ctlDateTo" runat="server" />&nbsp;<span class="zRemark">*</span>
                        </td>
                    </tr> 
                   
                    <tr id="pnlMonth"  runat="server"  style="height:24px" >
                        <td style="width:130px; padding-right:10px; height: 24px;" align="right">
                            �����ҧ��͹ :</td>
                        <td style="height: 24px">
                            <asp:DropDownList ID="cmbMonthFrom" runat="server" Width="106px" CssClass="zComboBox">
                             <asp:ListItem Value="">���͡</asp:ListItem>
                                <asp:ListItem Value="01">���Ҥ�</asp:ListItem>
                                <asp:ListItem Value="02">����Ҿѹ��</asp:ListItem>
                                <asp:ListItem Value="03">�չҤ�</asp:ListItem>
                                <asp:ListItem Value="04">����¹</asp:ListItem>
                                <asp:ListItem Value="05">����Ҥ�</asp:ListItem>
                                <asp:ListItem Value="06">�Զع�¹</asp:ListItem>
                                <asp:ListItem Value="07">�á�Ҥ�</asp:ListItem>
                                <asp:ListItem Value="08">�ԧ�Ҥ�</asp:ListItem>
                                <asp:ListItem Value="09">�ѹ��¹</asp:ListItem>
                                <asp:ListItem Value="10">���Ҥ�</asp:ListItem>
                                <asp:ListItem Value="11">��Ȩԡ�¹</asp:ListItem>
                                <asp:ListItem Value="12">�ѹ�Ҥ�</asp:ListItem>
                            </asp:DropDownList> �� 
                            <asp:TextBox ID="txtMYearFrom" CssClass="zTextbox" runat="server" Width="45px" MaxLength="4"></asp:TextBox>&nbsp;<span class="zRemark">*</span>
                            &nbsp;�֧��͹ <asp:DropDownList ID="cmbMonthTo" runat="server" Width="106px" CssClass="zComboBox">
                             <asp:ListItem Value="">���͡</asp:ListItem>
                                <asp:ListItem Value="01">���Ҥ�</asp:ListItem>
                                <asp:ListItem Value="02">����Ҿѹ��</asp:ListItem>
                                <asp:ListItem Value="03">�չҤ�</asp:ListItem>
                                <asp:ListItem Value="04">����¹</asp:ListItem>
                                <asp:ListItem Value="05">����Ҥ�</asp:ListItem>
                                <asp:ListItem Value="06">�Զع�¹</asp:ListItem>
                                <asp:ListItem Value="07">�á�Ҥ�</asp:ListItem>
                                <asp:ListItem Value="08">�ԧ�Ҥ�</asp:ListItem>
                                <asp:ListItem Value="09">�ѹ��¹</asp:ListItem>
                                <asp:ListItem Value="10">���Ҥ�</asp:ListItem>
                                <asp:ListItem Value="11">��Ȩԡ�¹</asp:ListItem>
                                <asp:ListItem Value="12">�ѹ�Ҥ�</asp:ListItem>
                            </asp:DropDownList> �� 
                            <asp:TextBox ID="txtMYearTo" CssClass="zTextbox" runat="server" Width="45px" MaxLength="4"></asp:TextBox>&nbsp;<span class="zRemark">*</span>
                        </td>
                    </tr>                    
                    <tr id="PnlYear"  runat="server"  style="height:24px">
                        <td style="width:130px; padding-right:10px; height: 24px;" align="right">
                            �����ҧ�� :</td>
                        <td style="height: 24px">
                            <asp:TextBox ID="txtYearFrom" CssClass="zTextbox" runat="server" Width="45px" MaxLength="4"></asp:TextBox>&nbsp;<span class="zRemark">*</span>
                            &nbsp;�֧
                            <asp:TextBox ID="txtYearTo" CssClass="zTextbox" runat="server" Width="45px" MaxLength="4"></asp:TextBox>&nbsp;<span class="zRemark">*</span>
                        </td>
                    </tr> 
                </table> 
            </td>
        </tr>
    </table>
</asp:Content>