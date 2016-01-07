<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MaterialMaster100Popup.ascx.cs" Inherits="Search_MaterialMaster100Popup" %>
<%@ Register Src="../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%@ Register Src="../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<cc1:ModalPopupExtender ID="popupMaterialMaster"  runat="server" PopupControlID="pnlMaterialMaster" BackgroundCssClass="modalBackground" DropShadow="true" TargetControlID="btntest"></cc1:ModalPopupExtender>
<asp:Panel ID="pnlMaterialMaster" runat="server" CssClass="modalPopupSearch" style="display:none" >
    <table border="0" cellspacing="0" cellpadding="0" width="100%">
        <tr>
            <td class="headtext">��������ʴ�
            </td>
        </tr>
        <tr>
            <td><uc1:ToolBarItemCtl ID="tbBack" runat="server" ToobarTitle="��Ѻ˹����¡��" ToolbarImage="../../Images/icn_back.png" OnClick="tbBackClick" />
                <asp:TextBox ID="txhSortField" runat="server" Visible="False" Width="15px"></asp:TextBox><asp:TextBox
                    ID="txhSortDir" runat="server" Visible="False" Width="15px"></asp:TextBox>
                <asp:TextBox ID="txtExistKeyList" runat="server" Visible="False" Width="15px"></asp:TextBox></td>
        </tr>
        <tr>
            <td><hr style="size:1px" />
            </td>
        </tr>
        <tr>
            <td>
                <fieldset style="padding:15px;">
                    <legend style="font-weight:bold">
                        ����
                    </legend>
                    <table cellspacing="0" cellpadding="0" border="0" width="700">
                        <tr style="height:15px">
                            <td colspan="3">&nbsp;</td>
                            <td colspan="1" style="width: 200px">
                            </td>
                            <td colspan="1">
                            </td>
                        </tr>
                        <tr style="height: 24px">
                            <td style="padding-right: 10px; width: 110px; text-align: right">
                                ��������ʴ� :</td>
                            <td style="width: 200px">
                                <asp:DropDownList ID="cmbSearchMasterType" runat="server" CssClass="zComboBox" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="cmbSearchMasterType_SelectedIndexChanged">
                                </asp:DropDownList></td>
                            <td style="padding-right: 10px; width: 100px; text-align: right">
                            </td>
                            <td style="width: 200px">
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr style="height: 24px">
                            <td style="padding-right: 10px; width: 110px; text-align: right">
                                ��Ǵ������ʴ� :</td>
                            <td style="width: 200px">
                                <asp:DropDownList ID="cmbSearchMaterialClass" runat="server" CssClass="zComboBox" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="cmbSearchMaterialClass_SelectedIndexChanged">
                                </asp:DropDownList></td>
                            <td style="padding-right: 10px; width: 100px; text-align: right">
                                �������ʴ� :
                            </td>
                            <td style="width: 200px">
                                <asp:DropDownList ID="cmbSearchMaterialGroup" runat="server" CssClass="zComboBox" Width="200px">
                                </asp:DropDownList>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr style="height:24px">
                            <td style="width:110px; text-align: right; padding-right:10px">
                                ������ʴ� :</td>
                            <td style="width:200px;">
                                <asp:TextBox ID="txtSearchCode" runat="server" CssClass="zTextbox" MaxLength="100" Width="194px"></asp:TextBox>
                            </td>
                            <td style="padding-right: 10px; width: 100px; text-align: right">
                                ������ʴ� :
                            </td>
                            <td style="width: 200px">
                                <asp:TextBox ID="txtSearchName" runat="server" CssClass="zTextbox" MaxLength="100"
                                    Width="194px"></asp:TextBox>
                            </td>
                            <td>
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
                <asp:GridView ID="gvMain" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="t_tablestyle" AllowPaging="True" PageSize="100" 
                    OnRowDataBound="gvMain_RowDataBound" OnSorting="gvMain_Sorting" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="LOID" HeaderText="LOID">
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
                        <asp:BoundField DataField="MATERIALCODE" HeaderText="������ʴ�" SortExpression="MATERIALCODE">
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="MATERIALNAME" HeaderText="������ʴ�" SortExpression="MATERIALNAME">
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DIVISIONNAME" HeaderText="DIVISIONNAME">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="GROUPNAME" HeaderText="�������ʴ�" SortExpression="GROUPNAME">
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CLASSNAME" HeaderText="��Ǵ������ʴ�" SortExpression="CLASSNAME">
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="MASTERTYPENAME" HeaderText="��������ʴ�" SortExpression="MASTERTYPENAME">
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="WEIGHT" HeaderText="WEIGHT">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ENERGY100G" HeaderText="ENERGY100G">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ENERGYBYUNIT" HeaderText="ENERGYBYUNIT">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CARBOHYDRATE" HeaderText="CARBOHYDRATE">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PROTEIN" HeaderText="PROTEIN">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FAT" HeaderText="FAT">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SODIUM" HeaderText="SODIUM">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ULOID" HeaderText="ULOID">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="UNITNAME" HeaderText="˹���" SortExpression="UNITNAME">
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PHOSPHORUS" HeaderText="PHOSPHORUS">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="POTASSIUM" HeaderText="POTASSIUM">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CALCIUM" HeaderText="CALCIUM">
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
