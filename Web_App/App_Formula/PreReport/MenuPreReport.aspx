<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="MenuPreReport.aspx.cs" Inherits="App_Formula_PreReport_MenuPreReport" Title="SHND : Report - Menu" %>

<%@ Register Src="../../Templates/CalendarControl.ascx" TagName="CalendarControl"
    TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="headtext">��§ҹ�����ҵðҹ
            </td>
        </tr>
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbPrint" runat="server" ToobarTitle="�������§ҹ" ToolbarImage="../../Images/icn_print.png" />
            </td>
        </tr>
        <tr>
            <td><hr style="size:1px" />
                            <asp:TextBox ID="txtDivision" runat="server" Visible="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="500">
                    <tr style="height:24px">
                        <td style="width:130px; padding-right:10px" align="right">
                            ˹��§ҹ :</td>
                        <td>
                            <asp:TextBox ID="txtDivisionName" runat="server" CssClass="zTextbox-View" ReadOnly="True"
                                Width="200px"></asp:TextBox></td>
                    </tr> 
                    <tr style="height:24px">
                        <td style="width:130px; padding-right:10px" align="right">
                            ���ͪش�����ҵðҹ :</td>
                        <td>
                            <asp:DropDownList ID="cmbMenu" runat="server" CssClass="zComboBox" Width="200px">
                            </asp:DropDownList></td>
                    </tr> 
                    <tr style="height:24px">
                        <td style="width:130px; padding-right:10px" align="right">
                            ����������� :</td>
                        <td>
                            <asp:DropDownList ID="cmbFoodType" runat="server" CssClass="zComboBox" Width="200px">
                            </asp:DropDownList></td>
                    </tr> 
                    <tr style="height:24px">
                        <td style="width:130px; padding-right:10px" align="right">
                            ��Դ����� :</td>
                        <td>
                            <asp:DropDownList ID="cmbFoodCategory" runat="server" CssClass="zComboBox" Width="200px">
                            </asp:DropDownList></td>
                    </tr> 
                    <tr style="height:24px">
                        <td style="width:130px; padding-right:10px" align="right">
                            �ѹ��� :</td>
                        <td>
                            <uc2:CalendarControl ID="ctlDateFrom" runat="server" />
                            &nbsp;�֧
                            <uc2:CalendarControl ID="ctlDateTo" runat="server" />
                        </td>
                    </tr> 
                </table> 
            </td>
        </tr>
    </table>
</asp:Content>