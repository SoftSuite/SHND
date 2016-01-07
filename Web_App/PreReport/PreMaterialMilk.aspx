<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="PreMaterialMilk.aspx.cs" Inherits="PreReport_PreMaterialMilk" Title="SHND : Report - MaterialMilk" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../Templates/CalendarControl.ascx" TagName="CalendarControl"
    TagPrefix="uc2" %>
<%@ Register Src="../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="headtext">��§ҹ��ػ����ҳ��������
            </td>
        </tr>
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbPrint" runat="server" ToobarTitle="�������§ҹ" ToolbarImage="../Images/icn_print.png" />
            </td>
        </tr>
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
                            ��Դ���� :</td>
                        <td>
                            <asp:DropDownList ID="cmbMilk" runat="server" CssClass="zComboBox" Width="132px">
                            </asp:DropDownList></td>
                    </tr> 
                    <tr style="height:24px">
                        <td style="width:130px; padding-right:10px; height: 24px;" align="right">
                            �ѹ�������� :</td>
                        <td style="height: 24px">
                            <uc2:CalendarControl ID="ctlDate" runat="server" />  &nbsp; &nbsp; ���� :
                            <asp:DropDownList ID="cmbMeal" runat="server" CssClass="zComboBox" Width="75px" AutoPostBack="True" OnSelectedIndexChanged="cmbMeal_SelectedIndexChanged">
                                <asp:ListItem Value="00">������</asp:ListItem>
                                <asp:ListItem Value="11">���</asp:ListItem>
                                <asp:ListItem Value="21">��ҧ�ѹ</asp:ListItem>
                                <asp:ListItem Value="31">���</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr> 
                    <tr style="height:24px">
                        <td style="width:130px; padding-right:10px" align="right">
                            ��������� :</td>
                        <td>
                            <asp:TextBox ID="txtTimeFrom" ReadOnly="true" CssClass="zTextbox-View" runat="server" Width="45px" ></asp:TextBox>
                            &nbsp;�֧
                            <asp:TextBox ID="txtTimeTo" ReadOnly="true" CssClass="zTextbox-View" runat="server" Width="45px" ></asp:TextBox>&nbsp; [Ex.08:00]
                        </td>
                    </tr> 
                    </table> 
                <cc1:MaskedEditExtender ID="mdeTimeFrom" runat="server" TargetControlID="txtTimeFrom" MaskType="Time" Mask="99:99"></cc1:MaskedEditExtender>
                <cc1:MaskedEditExtender ID="mdeTimeTo" runat="server" TargetControlID="txtTimeTo" MaskType="Time" Mask="99:99"></cc1:MaskedEditExtender>
            
                             
            </td>
        </tr>
    </table>
</asp:Content>

