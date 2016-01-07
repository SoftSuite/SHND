<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="PreStockoutMaterial.aspx.cs" Inherits="PreReport_PreStockoutMaterial" Title="SHND : Pre Stockout Material" %>

<%@ Register Src="../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc2" %>

<%@ Register Src="../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
<table width="810px" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="headtext">
                &nbsp;��§ҹ��ػ�ʹ��ʴ�����÷������͡
            </td>
        </tr>
    </table>
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbPrint" runat="server" ToobarTitle="�������§ҹ" ToolbarImage="../Images/icn_print.png" OnClick="tbPrintClick"/>
                
            </td>
        </tr>
        
    </table>
    <table border="0" cellpadding="0" cellspacing="0" style="border-right: thin solid; border-top: thin solid; border-left: thin solid; border-bottom: thin solid; width: 591px;">
                <tr>
                    <td colspan="5" class="t_headtext">
                        &nbsp;��˹����͹�
                    </td>
                </tr>
                 <tr style="height:10px;">
                </tr>
                <tr>
                    <td style="height:15px">
                        <asp:Label ID="lbStatusMain" runat="server" EnableViewState="False"></asp:Label>
                    </td>
                </tr>
                <tr style="height:10px;">
                </tr>
                <tr style="height:23px">
                    <td style="width:130px; padding-right:10px" align="right">
                        ˹��§ҹ :</td>
                    <td colspan="3"  style="height: 23px"><asp:DropDownList ID="cmbDivision" runat="server" CssClass="zComboBox" Width="380px">
                        </asp:DropDownList>
                        </td>
                </tr> 
                <tr style="height:24px">
                    <td style="width:130px; padding-right:10px" align="right">
                        ��Ǵ����� :</td>
                    <td colspan="3"  style="height: 23px">
                        <asp:DropDownList ID="cmbMaterialClass" runat="server" CssClass="zComboBox" Width="380px" OnSelectedIndexChanged="cmbMaterialClass_SelectIndexChange" AutoPostBack="true">
                        </asp:DropDownList>
                        </td>
                </tr> 
                 <tr style="height:24px">
                    <td style="width:130px; padding-right:10px" align="right">
                        ��ʴ������ :</td>
                    <td colspan="3" style="height: 23px"><asp:DropDownList ID="cmbMaterialMaster" runat="server" CssClass="zComboBox" Width="220px">
                        </asp:DropDownList>
                        &nbsp;&nbsp; &nbsp;˹��� :&nbsp;<asp:DropDownList ID="cmbUnit" runat="server" CssClass="zComboBox" Width="100px">
                        </asp:DropDownList>
                        </td>
                </tr> 
                 <tr style="height:24px">
                    <td style="width:130px; padding-right:10px" align="right">
                        ��������ػ :</td>
                    <td colspan="3"  style="height: 23px">
                        <asp:RadioButton ID="rdDay" runat="server" GroupName="A" Text="����ѹ" ValidationGroup="GroupReport" Checked="true" />
                        &nbsp;&nbsp;
                        <asp:RadioButton ID="rdMonth" runat="server" GroupName="A" Text="�����͹" ValidationGroup="GroupReport" />
                        &nbsp;&nbsp;
                        <asp:RadioButton ID="rdYear" runat="server" GroupName="A" Text="��»�" ValidationGroup="GroupReport" />
                    </td>
                </tr> 
                <tr id="trDay" runat="server">
                   <td style="width:130px; padding-right:10px; height:23px" align="right">
                        �����ҧ�ѹ��� :</td>
                    <td colspan="3"  style="height: 23px"><uc2:CalendarControl ID="ctlDateFrom" runat="server" />
                        &nbsp;&nbsp;&nbsp;&nbsp;�֧ : 
                        <uc2:CalendarControl ID="ctlDateTo" runat="server" />
                     </td>
                </tr>
                <tr id="trMonth" style="display:none;" runat="server" >
                   <td style="width:130px; padding-right:10px; height:23px" align="right">
                        �����ҧ��͹ :</td>
                    <td  style="height: 23px">
                        <asp:DropDownList ID="cmbMonthFrom" runat="server" CssClass="zComboBox" Width="100px"  >
                            <asp:ListItem Value="01">������</asp:ListItem>
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
                        </asp:DropDownList>
                        &nbsp;&nbsp;&nbsp;&nbsp;�� : 
                        <asp:TextBox ID="txtMYearFrom" runat="server" Width="40px" CssClass="zTextbox" MaxLength="4"></asp:TextBox>
                    </td>
                    <td  style="height: 23px">
                         �֧��͹ : 
                        <asp:DropDownList ID="cmbMonthTo" runat="server" CssClass="zComboBox" Width="100px" >
                            <asp:ListItem Value="12">������</asp:ListItem>
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
                        </asp:DropDownList>
                        &nbsp;&nbsp;&nbsp;&nbsp;�� :
                        <asp:TextBox ID="txtMYearTo" runat="server" Width="40px" CssClass="zTextbox"  MaxLength="4"></asp:TextBox>
                        
                     </td> 
                </tr >
                 <tr id="trYear" style="display:none;" runat="server">
                   <td style="width:130px; padding-right:10px; height:23px" align="right">
                        �����ҧ�� :</td>
                    <td colspan="3"  style="height: 23px">
                        <asp:TextBox ID="txtYearFrom" runat="server" Width="40px" CssClass="zTextbox" MaxLength="4"></asp:TextBox>
                        &nbsp;&nbsp;�֧ : 
                        <asp:TextBox ID="txtYearTo" runat="server" Width="40px" CssClass="zTextbox" MaxLength="4"></asp:TextBox>
                        
                     </td>
                </tr>
                <tr style="height:15px;"></tr>
         </table>
</asp:Content>

