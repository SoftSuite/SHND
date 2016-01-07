<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="OrderPartyDetailOfficer.aspx.cs" Inherits="App_Order_Transaction_OrderPartyDetailOfficer" Title="SHND : Transaction - Food Order for Party" %>

<%@ Register Src="../../Templates/CalendarControl.ascx" TagName="CalendarControl"
    TagPrefix="uc2" %>

<%@ Register Src="../../Search/OrderPartyPopup.ascx" TagName="OrderPartyPopup" TagPrefix="uc3" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <script language="JavaScript" type="text/javascript">
    </script>
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="headtext">
                �������èѴ����§ (��������ҡ��)</td>
        </tr>
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbSave" runat="server" ToobarTitle="�ѹ�֡" ToolbarImage="../../Images/save2.png" OnClick="tbSaveClick" />
                <uc1:ToolBarItemCtl ID="tbCancel" runat="server" ToobarTitle="¡��ԡ������" ToolbarImage="../../Images/cancel.png" OnClick="tbCancelClick" />
                <uc1:ToolBarItemCtl ID="tbBack" runat="server" ToobarTitle="��Ѻ˹����¡��" ToolbarImage="../../Images/icn_back.png" OnClick="tbBackClick"/>
                <uc1:ToolBarItemCtl ID="tbApprove" runat="server" ToobarTitle="͹��ѵ�" ToolbarImage="../../Images/icn_approve.png" OnClick="tbApproveClick"/>

            </td>
        </tr>
        <tr>
            <td style="height:30px" valign="top">
                <hr style="size:1px" />
                <asp:Label ID="lbStatus" runat="server" EnableViewState="False"></asp:Label>
                <asp:TextBox ID="txtLOID" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
                <asp:TextBox ID="txtStatus" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
                <asp:TextBox ID="txtDivision" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
        </tr>
        <tr>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td style="padding:5px; border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid; width:400px" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" width="500px">
                                <tr style="height:24px">
                                    <td style="width:120px; text-align:right; padding-right:10px">
                                        ˹��§ҹ :</td> 
                                    <td colspan="3">
                                        <asp:TextBox ID="txtDivName" runat="server" CssClass="zTextbox-View" MaxLength="100" Width="342px" ReadOnly="True"></asp:TextBox></td>
                                </tr>
                                       <tr style="height:24px">
                                    <td style="width:120px; text-align:right; padding-right:10px">
                                        �Ţ������������� :</td> 
                                    <td style="width:140px">
                                        <asp:TextBox ID="txtCode" runat="server" CssClass="zTextbox-View" ReadOnly="True" MaxLength="100" Width="125px"></asp:TextBox></td>
                                    <td style="width:70px; padding-right: 10px;" align="right">
                                      �ѹ������ :</td> 
                                    <td style="width: 170px">
                                        <uc2:CalendarControl ID="ctlOrderDate" runat="server" Enabled="False"/>
                                        &nbsp;
                                    </td>
                                </tr>
                                       <tr style="height:24px">
                                    <td style="width:120px; text-align:right; padding-right:10px">
                                        ���ͼ����� :</td> 
                                    <td colspan="3">
                                        <asp:DropDownList ID="ddlTitle" runat="server" Enabled="False" CssClass="zComboBox" Width="80px">
                                        </asp:DropDownList>
                                        <asp:TextBox ID="txtName" runat="server" CssClass="zTextbox-View" ReadOnly="True" Width="100px"></asp:TextBox>
                                        <asp:TextBox ID="txtLastName" runat="server" CssClass="zTextbox-View" ReadOnly="True" Width="146px"></asp:TextBox></td>

                                </tr>
                                <tr style="height:24px">
                                    <td style="width:120px; text-align:right; padding-right:10px">
                                        ���Ѿ�� :</td> 
                                    <td colspan="3">
                                        <asp:TextBox ID="txtTel" runat="server" CssClass="zTextbox-View" ReadOnly="True" Width="342px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="height:24px">
                                    <td style="width:120px; text-align:right; padding-right:10px">
                                        �ѹ����ͧ��� :</td> 
                                    <td style="width:140px">
                                         <uc2:CalendarControl ID="ctlPartyDate" runat="server" Enabled="False"/>
                                    </td>
                                    <td style="width:70px; padding-right: 10px;" align="right">
                                      ����:</td> 
                                    <td style="width: 170px">
                                        <asp:DropDownList ID="ddlPartyTime" runat="server" Enabled="False" CssClass="zComboBox" Width="86px">
                                            <asp:ListItem Value="6">6.00</asp:ListItem>
                                            <asp:ListItem Value="7">7.00</asp:ListItem>
                                            <asp:ListItem Value="8">8.00</asp:ListItem>
                                             <asp:ListItem Value="9">9.00</asp:ListItem>
                                            <asp:ListItem Value="10">10.00</asp:ListItem>
                                            <asp:ListItem Value="11">11.00</asp:ListItem>
                                             <asp:ListItem Value="12">12.00</asp:ListItem>
                                            <asp:ListItem Value="13">13.00</asp:ListItem>
                                            <asp:ListItem Value="14">14.00</asp:ListItem>
                                             <asp:ListItem Value="15">15.00</asp:ListItem>
                                            <asp:ListItem Value="16">16.00</asp:ListItem>
                                            <asp:ListItem Value="17">17.00</asp:ListItem>
                                             <asp:ListItem Value="18">18.00</asp:ListItem>
                                            <asp:ListItem Value="19">19.00</asp:ListItem>
                                            <asp:ListItem Value="20">20.00</asp:ListItem>
                                             <asp:ListItem Value="21">21.00</asp:ListItem>
                                            <asp:ListItem Value="22">22.00</asp:ListItem>
                                            <asp:ListItem Value="23">23.00</asp:ListItem>
                                             <asp:ListItem Value="0">0.00</asp:ListItem>
                                            <asp:ListItem Value="1">1.00</asp:ListItem>
                                            <asp:ListItem Value="2">2.00</asp:ListItem>
                                             <asp:ListItem Value="3">3.00</asp:ListItem>
                                            <asp:ListItem Value="4">4.00</asp:ListItem>
                                            <asp:ListItem Value="5">5.00</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                               <tr style="height:24px">
                                    <td style="width:120px; text-align:right; padding-right:10px">
                                        ��������èѴ����§ :</td> 
                                    <td style="width:140px">
                                        <asp:DropDownList ID="ddlPartyType" runat="server" Enabled="False" CssClass="zComboBox" Width="131px">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width:70px; padding-right: 10px;" align="right">
                                      �ӹǹ(���):</td> 
                                    <td style="width: 170px">
                                        <asp:TextBox ID="txtQty" runat="server" CssClass="zTextboxR-View" ReadOnly="True" Width="80px"></asp:TextBox>
                                        
                                    </td>
                                </tr>
                                <tr style="height:24px">
                                    <td style="width:120px; text-align:right; padding-right:10px">
                                        ʶҹ��� :</td> 
                                    <td colspan="3">
                                        <asp:TextBox ID="txtPlace" runat="server" CssClass="zTextbox-View" ReadOnly="True" Width="342px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width:4px">
                            &nbsp;</td>
                        <td style="border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid; padding:5px" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" width="300px">
                                <tr style="height:24px;">
                                    <td style="width:80px; padding-right:10px;" align="right">
                                        ʶҹ� :</td> 
                                    <td>
                                        <asp:TextBox ID="txtStatusName" runat="server" CssClass="zTextbox-View" ReadOnly="True" Width="150px"></asp:TextBox></td> 
                                </tr>
                                <tr style="height: 24px">
                                    <td colspan="2">
                                     <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                     <tr style="height: 24px"> 
                                     <td style="width:150px">����ӹ�¡��</td>
                                     <td>��������ҡ��</td>
                                     </tr>
                                       <tr style="height: 24px"> 
                                     <td style="width:150px">
                                         <asp:RadioButtonList ID="rblDirector" runat="server" Enabled="False">
                                             <asp:ListItem Value="Y">͹��ѵ�</asp:ListItem>
                                             <asp:ListItem Value="N">���͹��ѵ�</asp:ListItem>
                                         </asp:RadioButtonList></td>
                                     <td><asp:RadioButtonList ID="rblOfficer" runat="server">
                                         <asp:ListItem Value="Y">�Ѻ Order</asp:ListItem>
                                         <asp:ListItem Value="N">����Ѻ Order</asp:ListItem>
                                         </asp:RadioButtonList></td>
                                     </tr>
                                     <tr style="height: 24px"> 
                                     <td style="width:150px">�������</td>
                                     <td>�������</td>
                                     </tr>
                                    <tr> 
                                     <td style="width:150px">
                                         <asp:TextBox ID="txtDirector" runat="server" CssClass="zTextbox-View"  ReadOnly="True" Width="125px" TextMode="MultiLine" Height="50px"></asp:TextBox></td>
                                     <td><asp:TextBox ID="txtOfficer" runat="server" CssClass="zTextbox"  Width="125px" TextMode="MultiLine" Height="50px"></asp:TextBox></td>
                                     </tr>
                                     </table>
                                        </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table> 
            </td>
        </tr>
        <tr>
            <td style="height:5px">
            </td>
        </tr>
         <tr>
                                    <td class="toolbarplace">
                                        <uc1:ToolBarItemCtl ID="tbAddOrderPartyItem" runat="server" ToobarTitle="������¡��" ToolbarImage="../../Images/icn_add.png" OnClick="tbAddOrderPartyItemClick" />
                                        <uc1:ToolBarItemCtl ID="tbDeleteOrderPartyItem" runat="server" ToobarTitle="ź��¡��" ToolbarImage="../../Images/icn_delete.png" OnClick="tbDeleteOrderPartyItemClick" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbStatusOrderPartyItem" runat="server" EnableViewState="False"></asp:Label></td> 
                                </tr> 

                                <tr>
                                    <td>
                                        <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="False" CssClass="t_tablestyle" DataSourceID="OrderPartySource" Width="100%" >
                                            <PagerSettings Visible="False" />
                                            <Columns>
<asp:BoundField DataField="RANK" HeaderText="RANK">
<ControlStyle CssClass="zHidden"></ControlStyle>

<ItemStyle CssClass="zHidden"></ItemStyle>

<HeaderStyle CssClass="zHidden"></HeaderStyle>

<FooterStyle CssClass="zHidden"></FooterStyle>
</asp:BoundField>
<asp:BoundField DataField="LOID" HeaderText="LOID">
<ControlStyle CssClass="zHidden"></ControlStyle>

<ItemStyle CssClass="zHidden"></ItemStyle>

<HeaderStyle CssClass="zHidden"></HeaderStyle>

<FooterStyle CssClass="zHidden"></FooterStyle>
</asp:BoundField>
<asp:TemplateField><HeaderTemplate>
                                                <input type="checkbox" name="chkMain" id="chkMain" onclick="chkAllBox(this, 'ctl00_MainContent_tabStdMenu_tabStdMenuDisease_gvStdMenuDisease_ctl', '_chkSelect')" />                                                    
                                                
</HeaderTemplate>

<ItemStyle Width="30px" HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>

<HeaderStyle Width="30px" HorizontalAlign="Center"></HeaderStyle>
<ItemTemplate>
                                                <asp:CheckBox ID="chkSelect" runat="server" />                                                   
                                                
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="�ӴѺ">
<ItemStyle Width="60px" Height="24px" HorizontalAlign="Center"></ItemStyle>

<HeaderStyle Width="60px"></HeaderStyle>
<ItemTemplate>
<%# Container.DataItemIndex + 1%>
                                                 
</ItemTemplate>
</asp:TemplateField>

<asp:BoundField DataField="FOODCOOKTYPENAME" HeaderText="�����������ҹ">
 <ItemStyle HorizontalAlign="Left" Width="160px" />
 <HeaderStyle HorizontalAlign="Center" Width="160px" />
</asp:BoundField>

<asp:BoundField DataField="FORMULASETNAME" HeaderText="��¡��">
</asp:BoundField>
<asp:TemplateField HeaderText="�ӹǹ����ԡ">
<ItemStyle Width="80px" Height="24px" HorizontalAlign="Center"></ItemStyle>

<HeaderStyle Width="80px"></HeaderStyle>
<ItemTemplate>
<asp:TextBox ID="txtVisitorQty" Width="75px" CssClass="zTextboxR-View" ReadOnly="true" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "VISITORQTY") %>'></asp:TextBox>
 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="�ӹǹ����Ѻ�Ѵ">
<ItemStyle Width="80px" Height="24px" HorizontalAlign="Center"></ItemStyle>

<HeaderStyle Width="80px"></HeaderStyle>
<ItemTemplate>
<asp:TextBox ID="txtServiceQty" Width="75px" CssClass="zTextboxR" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SERVICEQTY") %>'></asp:TextBox>
 
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="FORMULASET" HeaderText="FORMULASET">
<ControlStyle CssClass="zHidden"></ControlStyle>

<ItemStyle CssClass="zHidden"></ItemStyle>

<HeaderStyle CssClass="zHidden"></HeaderStyle>

<FooterStyle CssClass="zHidden"></FooterStyle>
</asp:BoundField>
</Columns>
                                            <HeaderStyle CssClass="t_headtext" />
                                            <AlternatingRowStyle CssClass="t_alt_bg" />
                                        </asp:GridView>
                                        <asp:ObjectDataSource ID="OrderPartySource" runat="server" SelectMethod="GetOrderPartyItemList" TypeName="OrderPartyItem">
                                            <SelectParameters>
<asp:ControlParameter PropertyName="Text" Type="Double" DefaultValue="0" Name="OrderParty" ControlID="txtLOID"></asp:ControlParameter>
</SelectParameters>
                                        </asp:ObjectDataSource>
                                    </td> 
                                </tr>
                           
    </table> 
    <uc3:OrderPartyPopup id="ctlOrderPartyPopup" runat="server" OnSelectedIndexChanged="ctlOrderPartyPopup_SelectedIndexChanged" />
</asp:Content>
