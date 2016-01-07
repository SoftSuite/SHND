<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DiseaseCategoryPopup_Meal.ascx.cs" Inherits="Search_DiseaseCategoryPopup_Meal" %>
<%@ Register Src="../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%@ Register Src="../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<cc1:ModalPopupExtender ID="popupDiseaseCategory"  runat="server" PopupControlID="pnlDiseaseCategory" BackgroundCssClass="modalBackground" DropShadow="true" TargetControlID="btntest" ></cc1:ModalPopupExtender>
<asp:Panel ID="pnlDiseaseCategory" runat="server" CssClass="modalPopupSearch" style="display:none" Width="800px">
    <table border="0" cellspacing="0" cellpadding="0" width="100%" id="TABLE1">
        <tr>
            <td class="headtext">�����Ū�Դ�ͧ��������
            </td>
        </tr>
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbBack" runat="server" ToobarTitle="��Ѻ˹����¡��" ToolbarImage="../../Images/icn_back.png" OnClick="tbBackClick" />
                <asp:TextBox ID="txhSortField" runat="server" Visible="False" Width="15px"></asp:TextBox><asp:TextBox
                    ID="txhSortDir" runat="server" Visible="False" Width="15px"></asp:TextBox>
                <asp:TextBox ID="txtType" runat="server" Visible="False" Width="15px"></asp:TextBox>
                <asp:TextBox ID="txtExistKeyList" runat="server" Visible="False" Width="15px"></asp:TextBox>
                <asp:TextBox ID="txtCategoryUse" runat="server" Visible="False" Width="15px"></asp:TextBox>
            </td>
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
                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                        <tr style="height: 24px">
                            <td style="padding-right: 10px; width: 130px; text-align: right">
                                ������������� :</td>
                            <td style="width: 200px">
                                <asp:DropDownList ID="cmbSearchCategory" runat="server" CssClass="zComboBox" Width="206px">
                                </asp:DropDownList></td>
                            <td>
                            </td>
                        </tr>
                        <tr style="height:24px">
                            <td style="width:130px; text-align: right; padding-right:10px">
                                ������� :</td>
                            <td style="width:200px;">
                                <asp:TextBox ID="txtSearchDiseaseAbb" runat="server" CssClass="zTextbox" MaxLength="100" Width="200px"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr style="height:24px">
                            <td style="width:130px; text-align: right; padding-right:10px">
                                ��������´ :</td>
                            <td style="width:200px;">
                                <asp:TextBox ID="txtSearchDiseaseDesc" runat="server" CssClass="zTextbox" MaxLength="100"
                                    Width="200px"></asp:TextBox></td>
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
                <uc1:ToolBarItemCtl ID="tbAdd" runat="server" OnClick="tbAddClick" ToobarTitle="������¡��"
                    ToolbarImage="../../Images/icn_add.png" />
            </td>
        </tr>
        <tr>
            <td>
                 <uc2:PageControl ID="pcTop" runat="server" OnPageChange="PageChange" />
                <asp:GridView ID="gvMain" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="t_tablestyle" AllowPaging="True" PageSize="20" OnRowDataBound="gvMain_RowDataBound" OnSorting="gvMain_Sorting">
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
                        <asp:BoundField DataField="ABBNAME" HeaderText="�������" SortExpression="ABBNAME">
                            <HeaderStyle HorizontalAlign="Center" Width="80px" />
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DESCRIPTION" HeaderText="��������´" SortExpression="DESCRIPTION">
                            <HeaderStyle Width="200px" />
                            <ItemStyle Width="200px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ISSPECIAL" HeaderText="�����੾���ä">
                            <HeaderStyle Width="80px" />
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ISLIMIT" HeaderText="����èӡѴ����ҳ">
                            <HeaderStyle Width="80px" />
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ISCALCULATE" HeaderText="����äӹǳ��ѧ�ҹ">
                            <HeaderStyle Width="80px" />
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ISINCREASE" HeaderText="����������">
                            <HeaderStyle Width="80px" />
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ISABSTAIN" HeaderText="����÷�觴">
                            <HeaderStyle Width="80px" />
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ISNEED" HeaderText="����÷���Ѻ੾��">
                            <HeaderStyle Width="80px" />
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ISREQUEST" HeaderText="����÷���">
                            <HeaderStyle Width="80px" />
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="High">
                            <ItemTemplate>
                                <asp:RadioButton ID="chkHigh" runat="server" GroupName="CategoryName" Visible='<%# Eval("ISHIGH").ToString() =="Y" %>' />
                            </ItemTemplate>
                            <HeaderStyle Width="40px" />
                            <ItemStyle HorizontalAlign="Center" Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Low">
                            <ItemTemplate>
                                <asp:RadioButton ID="chkLow" runat="server" GroupName="CategoryName" Visible='<%# Eval("ISLOW").ToString() =="Y" %>' />
                            </ItemTemplate>
                            <HeaderStyle Width="40px" />
                            <ItemStyle HorizontalAlign="Center" Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Non">
                            <ItemTemplate>
                                <asp:RadioButton ID="chkNon" runat="server" GroupName="CategoryName" Visible='<%# Eval("ISNON").ToString() =="Y" %>' />
                            </ItemTemplate>
                            <HeaderStyle Width="40px" />
                            <ItemStyle HorizontalAlign="Center" Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="����ҳ">
                            <ItemTemplate>
                                <asp:TextBox ID="txtQty" runat="server" Visible='<%# Eval("ISLIMIT").ToString() =="Y" %>' CssClass="zTextboxR" Width="45px" />
                            </ItemTemplate>
                            <HeaderStyle Width="50px" />
                            <ItemStyle Width="50px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="UNITNAME" HeaderText="˹��¹Ѻ">
                            <HeaderStyle Width="80px" />
                            <ItemStyle Width="80px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="UNIT" HeaderText="UNIT">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ISHIGH" HeaderText="ISHIGH">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ISLOW" HeaderText="ISLOW">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ISNON" HeaderText="ISNON">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                       <asp:TemplateField HeaderText="��������������">
                            <ItemTemplate>
                                <asp:DropDownList ID="cmbMeal" runat="server" Visible='<%# Eval("ISINCREASE").ToString() =="Y" %>' Width="80px">
                                <asp:ListItem Text="�ء����" Value="00"></asp:ListItem>
                                <asp:ListItem Text="���" Value="11"></asp:ListItem>
                                <asp:ListItem Text="��ҧ�ѹ" Value="21"></asp:ListItem>
                                <asp:ListItem Text="���" Value="31"></asp:ListItem>
                                </asp:DropDownList>
                            </ItemTemplate>
                            <HeaderStyle Width="90px" />
                            <ItemStyle Width="90px" />
                        </asp:TemplateField>
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