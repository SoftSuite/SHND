<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="PreCompareInterest.aspx.cs" Inherits="PreReport_PreCompareInterest" Title="SHND : Report - Compare Interest" %>
<%@ Register Src="../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc2" %>
<%@ Register Src="../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="headtext">��§ҹʶԵ���ǹ��ҧ�ҡ��������
            </td>
        </tr>
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbPrint" runat="server" ToobarTitle="�������§ҹ" ToolbarImage="../Images/icn_print.png" />
            </td>
        </tr>
        <tr>
            <td><hr style="size:1px" />
                            <asp:TextBox ID="txtDivision" runat="server" Visible="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="600">
 
                    <tr style="height:24px">
                        <td style="width:130px; padding-right:10px" align="right">
                            ��Ǵ����� :</td>
                        <td>
                            <asp:DropDownList ID="cmbClass" runat="server" CssClass="zComboBox" Width="346px" OnSelectedIndexChanged="cmbClass_SelectedIndexChanged" AutoPostBack="True">
                            </asp:DropDownList></td>
                    </tr> 
                    <tr style="height:24px">
                        <td style="width:130px; padding-right:10px" align="right">
                            ������ :</td>
                        <td>
                            <asp:DropDownList ID="cmbGroup" runat="server" CssClass="zComboBox" Width="346px">
                            </asp:DropDownList></td>
                    </tr> 
                                        <tr style="height:24px">
                        <td style="width:130px; padding-right:10px" align="right">
                            ��ʴ������ :</td>
                        <td>
                            <asp:TextBox ID="txtMaterial" runat="server" CssClass="zTextbox" ReadOnly="True"
                                Width="340px"></asp:TextBox></td>
                    </tr> 
                    <tr style="height:24px">
                        <td style="width:130px; padding-right:10px" align="right">
                            �����ҧ�ѹ��� :</td>
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

