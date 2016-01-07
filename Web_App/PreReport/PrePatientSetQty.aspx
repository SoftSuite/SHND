<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="PrePatientSetQty.aspx.cs" Inherits="PreReport_PrePatientSetQty" Title="SHND : Patient Set Qty"%>

<%@ Register Src="../Templates/CalendarControl.ascx" TagName="CalendarControl"
    TagPrefix="uc2" %>
<%@ Register Src="../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="headtext">��§ҹ��ػ�ӹǹ�����µ�������������
            </td>
        </tr>
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbPrint" runat="server" ToobarTitle="�������§ҹ" ToolbarImage="../Images/icn_print.png" />
            </td>
        </tr>
        <tr><td><asp:Label ID="txtErr" runat="server" ForeColor="Red"></asp:Label></td></tr>
        <tr>
            <td>
                <hr style="size:1px" /><asp:TextBox ID="txtDivision" runat="server" Visible="false"></asp:TextBox>
                            
            </td>
        </tr>
        <tr>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="600">
                    <tr style="height:24px">
                        <td style="width:130px; padding-right:10px" align="right">
                            ˹��§ҹ :</td>
                        <td>
                            <asp:TextBox ID="txtDivisionName" runat="server" CssClass="zTextbox-View" ReadOnly="True"
                                Width="200px"></asp:TextBox></td>
                    </tr> 
                    <tr style="height:24px">
                        <td style="width:130px; padding-right:10px" align="right">
                            ����������� :</td>
                        <td>
                            <asp:DropDownList ID="cmbFoodType" runat="server" CssClass="zComboBox" Width="206px">
                            </asp:DropDownList>&nbsp; VIP :  <asp:DropDownList ID="cmbVip" runat="server" CssClass="zComboBox" Width="100px">
                                <asp:ListItem Value="9">������</asp:ListItem>
                                <asp:ListItem Value="0">����к�</asp:ListItem>
                                <asp:ListItem Value="1">VIP</asp:ListItem>
                                <asp:ListItem Value="2">Super VIP</asp:ListItem>
                            </asp:DropDownList></td>
                    </tr> 
                    <tr style="height:24px">
                        <td style="width:130px; padding-right:10px" align="right">
                            �ͼ����� :</td>
                        <td>
                            <asp:DropDownList ID="cmbWard" runat="server" CssClass="zComboBox" Width="206px">
                            </asp:DropDownList></td>
                    </tr> 
                    <tr style="height:24px">
                        <td style="width:130px; padding-right:10px" align="right">
                            ����÷�觴 :</td>
                        <td><asp:TextBox ID="txtAbstain" runat="server" CssClass="zTextbox"
                                Width="200px"></asp:TextBox>
                            </td>
                    </tr> 
                    <tr style="height:24px">
                        <td style="width:130px; padding-right:10px" align="right">
                            ����÷���Ѻ੾�� :</td>
                        <td><asp:TextBox ID="txtNeed" runat="server" CssClass="zTextbox"
                                Width="200px"></asp:TextBox>
                            </td>
                    </tr> 
                    <tr style="height:24px">
                        <td style="width:130px; padding-right:10px" align="right">
                            ����÷��� :</td>
                        <td><asp:TextBox ID="txtRequest" runat="server" CssClass="zTextbox"
                                Width="200px"></asp:TextBox>
                            </td>
                    </tr> 
                    <tr style="height:24px">
                        <td style="width:130px; padding-right:10px" align="right">
                            ���������� :</td>
                        <td><asp:TextBox ID="txtIncrease" runat="server" CssClass="zTextbox"
                                Width="200px"></asp:TextBox>
                            </td>
                    </tr>
                    <tr style="height:24px">
                        <td style="width:130px; padding-right:10px; height: 24px;" align="right">
                            ��������ػ :</td>
                        <td style="height: 24px">
                            <asp:RadioButtonList ID="rbtType" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="rbtType_SelectedIndexChanged">
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
                            <uc2:CalendarControl ID="ctlDateFrom" runat="server" />
                            &nbsp;�֧
                            <uc2:CalendarControl ID="ctlDateTo" runat="server" />
                        </td>
                    </tr> 
                   
                    <tr id="pnlMonth"  runat="server"  style="height:24px" visible="false">
                        <td style="width:130px; padding-right:10px; height: 24px;" align="right">
                            �����ҧ��͹ :</td>
                        <td style="height: 24px">
                            <asp:DropDownList ID="cmbMonthFrom" runat="server" Width="106px" CssClass="zComboBox">
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
                            <asp:TextBox ID="txtMYearFrom" CssClass="zTextbox" runat="server" Width="45px" MaxLength="4"></asp:TextBox>
                            &nbsp;�֧��͹ <asp:DropDownList ID="cmbMonthTo" runat="server" Width="106px" CssClass="zComboBox">
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
                            <asp:TextBox ID="txtMYearTo" CssClass="zTextbox" runat="server" Width="45px" MaxLength="4"></asp:TextBox>              
                        </td>
                    </tr>                    
                    <tr id="PnlYear"  runat="server"  style="height:24px" visible="false">
                        <td style="width:130px; padding-right:10px; height: 24px;" align="right">
                            �����ҧ�� :</td>
                        <td style="height: 24px">
                            <asp:TextBox ID="txtYearFrom" CssClass="zTextbox" runat="server" Width="45px" MaxLength="4"></asp:TextBox>
                            &nbsp;�֧
                            <asp:TextBox ID="txtYearTo" CssClass="zTextbox" runat="server" Width="45px" MaxLength="4"></asp:TextBox>
                        </td>
                    </tr> 
                </table> 
            </td>
        </tr>
    </table>
</asp:Content>
