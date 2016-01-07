<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="PreStockinTools.aspx.cs" Inherits="PreReport_PreStockinTools" Title="SHND : Report - Stockin Tools" %>
<%@ Register Src="../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc2" %>
<%@ Register Src="../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="headtext">��§ҹ��ػ�ӹǹ�ʹ��ʴ��ػ�ó����Ѻ��Ҥ�ѧ
            </td>
        </tr>
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbPrint" runat="server" ToobarTitle="�������§ҹ" ToolbarImage="../Images/icn_print.png"  OnClick="tbPrintClick"/>
            </td>
        </tr>
        <tr>
            <td>
                            <asp:TextBox ID="txtDivision" runat="server" Visible="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="600" style="border-right: thin solid; border-top: thin solid; border-left: thin solid; border-bottom: thin solid">
                    <tr>
                    <td colspan="5" class="t_headtext">
                        &nbsp;��˹����͹�
                    </td>
                </tr>
                 <tr style="height:10px"></tr>
                    <tr style="height:24px">
                        <td style="width:130px; padding-right:10px" align="right">
                            ����������Ѻ��� :</td>
                        <td><asp:DropDownList ID="cmbType" runat="server" CssClass="zComboBox" Width="200px">
                            </asp:DropDownList>
                            </td>
                    </tr>  
                    <tr style="height:24px">
                        <td style="width:130px; padding-right:10px" align="right">
                            ��������ʴ� :</td>
                        <td><asp:DropDownList ID="cmbClass" runat="server" CssClass="zComboBox" Width="200px"  OnSelectedIndexChanged="cmbClass_SelectedIndexChanged" AutoPostBack="True">
                            </asp:DropDownList>
                            </td>
                    </tr> 
                    <tr style="height:24px">
                        <td style="width:130px; padding-right:10px" align="right">
                            ��ʴ��ػ�ó� :</td>
                        <td>
                            <asp:DropDownList ID="cmbMaterial" runat="server" CssClass="zComboBox" Width="200px" OnSelectedIndexChanged="cmbMaterial_SelectedIndexChanged" AutoPostBack="True">
                            </asp:DropDownList>&nbsp; ˹��� &nbsp;<asp:DropDownList ID="cmbUnit" runat="server" CssClass="zComboBox" Width="70px" Enabled="False">
                            </asp:DropDownList></td>
                    </tr> 
                    <tr style="height:24px">
                        <td style="width:130px; padding-right:10px" align="right">
                            ��������ػ :</td>
                        <td>
                            <asp:RadioButtonList ID="rbtType" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="rbtType_SelectedIndexChanged">
                                <asp:ListItem Selected="true" Value="dd">����ѹ</asp:ListItem>
                                <asp:ListItem Value="mm">�����͹</asp:ListItem>
                                <asp:ListItem Value="yy">��»�</asp:ListItem>
                            </asp:RadioButtonList>
                            </td>
                    </tr>
                                        <tr id="pnlDate"  runat="server" style="height:24px">
                        <td style="width:130px; padding-right:10px" align="right">
                            �����ҧ�ѹ��� :</td>
                        <td>
                            <uc2:CalendarControl ID="ctlDateFrom" runat="server" />
                            &nbsp;�֧
                            <uc2:CalendarControl ID="ctlDateTo" runat="server" />
                        </td>
                    </tr> 
                   
                    <tr id="pnlMonth"  runat="server"  style="height:24px" visible="false">
                        <td style="width:130px; padding-right:10px" align="right">
                            �����ҧ��͹ :</td>
                        <td>
                            <asp:DropDownList ID="cmbMonthFrom" runat="server" Width="106px">
                                <asp:ListItem Value="0">���͡</asp:ListItem>
                                <asp:ListItem Value="1">���Ҥ�</asp:ListItem>
                                <asp:ListItem Value="2">����Ҿѹ��</asp:ListItem>
                                <asp:ListItem Value="3">�չҤ�</asp:ListItem>
                                <asp:ListItem Value="4">����¹</asp:ListItem>
                                <asp:ListItem Value="5">����Ҥ�</asp:ListItem>
                                <asp:ListItem Value="6">�Զع�¹</asp:ListItem>
                                <asp:ListItem Value="7">�á�Ҥ�</asp:ListItem>
                                <asp:ListItem Value="8">�ԧ�Ҥ�</asp:ListItem>
                                <asp:ListItem Value="9">�ѹ��¹</asp:ListItem>
                                <asp:ListItem Value="10">���Ҥ�</asp:ListItem>
                                <asp:ListItem Value="11">��Ȩԡ�¹</asp:ListItem>
                                <asp:ListItem Value="12">�ѹ�Ҥ�</asp:ListItem>
                            </asp:DropDownList> �� 
                            <asp:TextBox ID="txtMYearFrom" CssClass="zTextBox" runat="server" Width="45px" MaxLength="4"></asp:TextBox>
                            &nbsp;�֧��͹ <asp:DropDownList ID="cmbMonthTo" runat="server" Width="106px">
                             <asp:ListItem Value="0">���͡</asp:ListItem>
                                <asp:ListItem Value="1">���Ҥ�</asp:ListItem>
                                <asp:ListItem Value="2">����Ҿѹ��</asp:ListItem>
                                <asp:ListItem Value="3">�չҤ�</asp:ListItem>
                                <asp:ListItem Value="4">����¹</asp:ListItem>
                                <asp:ListItem Value="5">����Ҥ�</asp:ListItem>
                                <asp:ListItem Value="6">�Զع�¹</asp:ListItem>
                                <asp:ListItem Value="7">�á�Ҥ�</asp:ListItem>
                                <asp:ListItem Value="8">�ԧ�Ҥ�</asp:ListItem>
                                <asp:ListItem Value="9">�ѹ��¹</asp:ListItem>
                                <asp:ListItem Value="10">���Ҥ�</asp:ListItem>
                                <asp:ListItem Value="11">��Ȩԡ�¹</asp:ListItem>
                                <asp:ListItem Value="12">�ѹ�Ҥ�</asp:ListItem>
                            </asp:DropDownList> �� 
                            <asp:TextBox ID="txtMYearTo" CssClass="zTextBox" runat="server" Width="45px" MaxLength="4"></asp:TextBox>              
                        </td>
                    </tr>                    
                    <tr id="PnlYear"  runat="server"  style="height:24px" visible="false">
                        <td style="width:130px; padding-right:10px" align="right">
                            �����ҧ�� :</td>
                        <td>
                            <asp:TextBox ID="txtYearFrom" CssClass="zTextBox" runat="server" Width="45px" MaxLength="4"></asp:TextBox>
                            &nbsp;�֧
                            <asp:TextBox ID="txtYearTo" CssClass="zTextBox" runat="server" Width="45px" MaxLength="4"></asp:TextBox>
                        </td>
                    </tr> 
                    </table> 

            </td>
        </tr>
    </table>
</asp:Content>

