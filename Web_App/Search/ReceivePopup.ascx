<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ReceivePopup.ascx.cs" Inherits="Search_ReceivePopup" %>
<%@ Register Src="../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc3" %>
<%@ Register Src="../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%@ Register Src="../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<cc1:ModalPopupExtender ID="popupMaterialMaster"  runat="server" PopupControlID="pnlMaterialMaster" BackgroundCssClass="modalBackground" DropShadow="true" TargetControlID="btntest"></cc1:ModalPopupExtender>
<asp:Panel ID="pnlMaterialMaster" runat="server" CssClass="modalPopupSearch" style="display:none" Width="800px" Height="600px" ScrollBars="Auto">
    <table border="0" cellspacing="0" cellpadding="0" width="780px">
        <tr>
            <td class="headtext">��������ʴ������
            </td>
        </tr>
        <tr>
            <td><uc1:ToolBarItemCtl ID="tbBack" runat="server" ToobarTitle="��Ѻ˹����¡��" ToolbarImage="../../Images/icn_back.png" OnClick="tbBackClick" />
                <asp:TextBox ID="txhSortField" runat="server" Visible="False" Width="15px"></asp:TextBox><asp:TextBox
                    ID="txhSortDir" runat="server" Visible="False" Width="15px"></asp:TextBox>
                <asp:TextBox ID="txtExistKeyList" runat="server" Visible="False" Width="15px"></asp:TextBox></td>
        </tr>
        <tr>
            <td><hr size="1" />
            </td>
        </tr>
        <tr>
            <td>
                <fieldset style="padding:15px;">
                    <legend style="font-weight:bold">
                        ����
                    </legend>
                    <table border="0" cellpadding="0" cellspacing="0" width="700">
                        <tr style="height:15px">
                            <td></td>
                            <td></td>
                        </tr>
                        <tr style="height:24px">
                            <td style="width:130px; padding-right:10px; text-align:right">��Ǵ��ʴ� :</td>
                            <td>
                                <asp:DropDownList ID="cmbSearchMaterialClass" runat="server" CssClass="zComboBox" Enabled="false" Width="200px"></asp:DropDownList>
                            </td>
                        </tr> 
                        <tr style="height:24px">
                            <td style="width:130px; padding-right:10px; text-align:right">������ʴ� :</td>
                            <td>
                                <asp:TextBox ID="txtSearchName" runat="server" CssClass="zTextbox" MaxLength="100" Width="200px"></asp:TextBox>                                
                            </td>                       
                        <tr style="height:24px">
                            <td style="width:130px; padding-right:10px; text-align:right">�ѹ����˹��� :</td>
                            <td>
                                <uc3:CalendarControl ID="ctlDueDate"  runat="server" />                                
                                &nbsp;&nbsp;<asp:ImageButton ID="imbSearch" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_find.png" OnClick="imbSearch_Click" />&nbsp;
                                <asp:ImageButton ID="imbReset" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_back.png" ToolTip="�ʴ�������" OnClick="imbReset_Click" /> 
                            </td>
                        </tr>
                    </table>
                </fieldset>     
            </td>
        </tr>
        <tr>
            <td class="toolbarplace">
                <uc1:ToolBarItemCtl ID="tbAdd" runat="server" ToobarTitle="������¡��" ToolbarImage="../../Images/icn_add.png" OnClick="tbAddClick" />
            </td>
        </tr>
        <tr>
            <td>
                <uc2:PageControl ID="pcTop" runat="server" OnPageChange="PageChange" />
                <asp:GridView ID="gvMain" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="t_tablestyle" AllowPaging="True" PageSize="20" OnRowDataBound="gvMain_RowDataBound" OnSorting="gvMain_Sorting">
                    <Columns>
                        <asp:BoundField DataField="MATERIALMASTER" HeaderText="LOID">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:CheckBox ID="chkAll" runat="server" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelect" runat="server" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="30px" />
                            <ItemStyle HorizontalAlign="Center" Width="30px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="�ӴѺ" SortExpression="DEFAULT">
                            <HeaderStyle Width="60px" />
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="MATERIALNAME" HeaderText="��¡��" SortExpression="MATERIALNAME">
                            <HeaderStyle HorizontalAlign="Center" Width="200px"  />
                            <ItemStyle HorizontalAlign="Left" Width="200px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DUEQTY" HeaderText="�ӹǹ��" SortExpression="DUEQTY" HtmlEncode="false" DataFormatString="{0:#,##0.00}">
                            <HeaderStyle HorizontalAlign="Center" Width="80px" />
                             <ItemStyle HorizontalAlign="Right" Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="UNITNAME" HeaderText="˹��¹Ѻ" SortExpression="UNITNAME">
                            <HeaderStyle HorizontalAlign="Center" Width="80px" />
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRICE" HeaderText="�Ҥ� (�ҷ)" SortExpression="PRICE" HtmlEncode="false" DataFormatString="{0:#,##0.00}">
                            <HeaderStyle HorizontalAlign="Center" Width="80px" />
                            <ItemStyle HorizontalAlign="Right"  Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="MATERIALCLASSNAME" HeaderText="��Ǵ��ʴ�" SortExpression="CLASSNAME">
                            <HeaderStyle HorizontalAlign="Center" Width="140px" />
                            <ItemStyle Width="140px" />
                        </asp:BoundField>
                        <asp:BoundField HtmlEncode="False" DataFormatString="{0:dd/MM/yyyy}" DataField="USEDATE" SortExpression="USEDATE" HeaderText="�ѹ�����">
                        <ItemStyle Width="100px" HorizontalAlign="Center"></ItemStyle>
                        <HeaderStyle Width="100px" HorizontalAlign="Center"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="UNITLOID" HeaderText="UNITLOID">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ISVAT" HeaderText="ISVAT">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SAPCODE" HeaderText="SAPCODE">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CODE" HeaderText="CODE">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SPEC" HeaderText="SPEC">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ORDERQTY" HeaderText="ORDERQTY">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PLANREMAINQTY" HeaderText="PLANREMAINQTY">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PREPODUEDATE" HeaderText="PREPODUEDATE">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DUEDATE" HeaderText="DUEDATE">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                    </Columns>
                    <HeaderStyle CssClass="t_headtext" />
                    <AlternatingRowStyle CssClass="t_alt_bg" />
                    <PagerSettings Visible="False" />
                </asp:GridView>
                <uc2:PageControl ID="pcBot" runat="server" OnPageChange="PageChange" />
            </td>
        </tr>
    </table>
</asp:Panel>
<asp:Button ID="btntest" runat="server" Text="test" CssClass="zHidden" />