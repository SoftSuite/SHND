<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="PreStockinToolList.aspx.cs" Inherits="PreReport_PreStockinToolList" Title="SHND : Report - Stockin Tool List" %>
<%@ Register Src="../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc2" %>
<%@ Register Src="../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="headtext">
                ��§ҹ��ػ��¡����ʴ��ػ�ó����Ѻ��Ҥ�ѧ</td>
        </tr>
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbPrint" runat="server" ToobarTitle="�������§ҹ" ToolbarImage="../Images/icn_print.png" />
            </td>
        </tr>
        <tr>
            <td>
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
                        <td style="width:130px; padding-right:10px; height: 23px;" align="right">
                            ����������Ѻ��� :</td>
                        <td style="height: 23px" colspan="3"><asp:DropDownList ID="cmbType" runat="server" CssClass="zComboBox" Width="312px">
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
                            �����ҧ�ѹ��� :</td>
                        <td style="width: 151px; height: 23px">
                            <uc2:CalendarControl ID="ctlStockOutDateFrom" runat="server" />
                            &nbsp;<span class="zRemark">*</span>
                        </td>
                        <td style="width: 30px; height: 23px">
                            �֧</td>
                        <td style="height: 23px">
                            <uc2:CalendarControl ID="ctlStockOutDateTo" runat="server" />
                            &nbsp;<span class="zRemark">*</span>
                        </td>
                    </tr>
                    </table> 
            </td>
        </tr>
    </table>
</asp:Content>