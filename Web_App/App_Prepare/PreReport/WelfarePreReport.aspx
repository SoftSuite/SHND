<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="WelfarePreReport.aspx.cs" Inherits="App_Prepare_PreReport_WelfarePreReport" Title="SHND : Report - Welfare" %>

<%@ Register Src="../../Templates/CalendarControl.ascx" TagName="CalendarControl"
    TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="headtext">��§ҹ����������������ʴԡ��
            </td>
        </tr>
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbPrint" runat="server" ToobarTitle="��������������" ToolbarImage="../../Images/icn_print.png" />
                <uc1:ToolBarItemCtl ID="tbPrint2" runat="server" ToobarTitle="�������ػ��¡���ѵ�شԺ����ͧ�����" ToolbarImage="../../Images/icn_print.png" />

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
                            �ѹ�������� :</td>
                        <td><uc2:CalendarControl ID="ctlPrepareDate" runat="server" />  &nbsp; &nbsp; ���� :
                            <asp:DropDownList ID="cmbMeal" runat="server" CssClass="zComboBox" Width="75px" AutoPostBack="True">
                                <asp:ListItem Value="00">������</asp:ListItem>
                                <asp:ListItem Value="11">���</asp:ListItem>
                                <asp:ListItem Value="21">��ҧ�ѹ</asp:ListItem>
                                <asp:ListItem Value="31">���</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                    </tr> 
                    <tr style="height:24px">
                        <td style="width:130px; padding-right:10px" align="right">
                            ���ͪش���� :</td>
                        <td>
                            <asp:DropDownList ID="cmbMenu" runat="server" CssClass="zComboBox" Width="200px">
                            </asp:DropDownList></td>
                    </tr> 

                </table> 
            </td>
        </tr>
    </table>
</asp:Content>