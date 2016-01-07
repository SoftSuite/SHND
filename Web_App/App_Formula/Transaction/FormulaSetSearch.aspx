<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="FormulaSetSearch.aspx.cs" Inherits="App_Formula_Transaction_FormulaSetSearch" Title="SHND : Transaction - Formula Set" %>
<%@ Register Src="../../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="headtext">
                �������ٵ���������Ѻ</td>
        </tr>
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbAdd" runat="server" ToobarTitle="����������" OnClick="tbAddClick" ToolbarImage="../../Images/icn_add.png"  />
                <asp:TextBox ID="txtDivision" runat="server" Visible="False" Width="15px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <hr style="size:1px" />
            </td>
        </tr>
        <tr>
            <td style="height: 15px">
            <fieldset style="padding:15px;">
            <legend style="font-weight:bold">
                ����
            </legend>
            
                <table cellspacing="0" cellpadding="0" border="0" width="1050px">
                    <tr style="height:15px">
                        <td colspan="5">&nbsp;</td>
                    </tr>
                    <tr style="height:24px">
                        <td style="width:130px; text-align: right; padding-right:10px">
                            �����ٵ������ :</td>
                        <td style="width:200px;">
                            <asp:TextBox ID="txtSearchName" runat="server" CssClass="zTextbox" MaxLength="100" Width="200px"></asp:TextBox>
                        </td>
                        <td style="width:30px; text-align:center;">
                        </td>
                        <td style="width:200px;">
                        </td>
                        <td>
                        </td>
                    </tr>
                     <tr style="height:24px">
                        <td style="padding-right: 10px; width: 130px; text-align: right">
                            ˹��§ҹ :</td>
                        <td style="width: 200px">
                            <asp:DropDownList ID="cmbDivision" runat="server" Width="205px" CssClass="zComboBox" AutoPostBack="true" OnSelectedIndexChanged="cmbDivision_SelectedIndexChanged">
                            </asp:DropDownList></td>
                        <td style="width: 30px; text-align: center">
                        </td>
                        <td style="width: 200px">
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr style="height:24px">
                        <td style="padding-right: 10px; width: 130px; text-align: right">
                            ����������� :</td>
                        <td style="width: 200px">
                            <asp:DropDownList ID="cmbSearchFoodType" runat="server" Width="205px" CssClass="zComboBox">
                            </asp:DropDownList></td>
                        <td style="width: 30px; text-align: center">
                        </td>
                        <td style="width: 200px">
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr style="height:24px">
                        <td style="padding-right: 10px; width: 130px; text-align: right">
                            ��Դ����� :</td>
                        <td style="width: 200px">
                            <asp:DropDownList ID="cmbSearchFoodCategory" runat="server" Width="205px" CssClass="zComboBox">
                            </asp:DropDownList></td>
                        <td style="width: 30px; text-align: center">
                        </td>
                        <td style="width: 200px">
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr style="height:24px">
                        <td style="padding-right: 10px; width: 130px; text-align: right">
                            ������/੾���ä :</td>
                        <td colspan="4">
                            <asp:RadioButton ID="rdbAll" runat="server" GroupName="specific" Text="������" Checked="True" />
                            <asp:RadioButton ID="rdbNormal" runat="server" GroupName="specific" Text="������" />
                            <asp:RadioButton ID="rdbSpecific" runat="server" GroupName="specific" Text="੾���ä" /></td>
                    </tr>
                    <tr style="height:24px">
                        <td style="padding-right: 10px; width: 130px; text-align: right">
                           </td>
                        <td colspan="4">
                            <asp:CheckBox ID="chkActive" runat="server" Checked="True" Text="�ʴ�੾���ٵ÷����ҹ">
                            </asp:CheckBox>
</td>
                    </tr>
                    <tr style="height:24px">
                        <td style="width:130px; text-align: right; padding-right:10px">
                            ʶҹ� :</td>
                        <td style="width:200px;">
                            <asp:DropDownList ID="cmbSearchStatusFrom" runat="server" Width="205px" CssClass="zComboBox"></asp:DropDownList>
                        </td>
                        <td style="width:30px; text-align:center;">
                            �֧</td>
                        <td style="width:200px;"><asp:DropDownList ID="cmbSearchStatusTo" runat="server" Width="205px" CssClass="zComboBox">
                        </asp:DropDownList></td>
                        <td>
                            &nbsp;&nbsp;<asp:ImageButton ID="imbSearch" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_find.png"
                                OnClick="imbSearch_Click" />&nbsp;
                            <asp:ImageButton ID="imbReset" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_back.png"
                                OnClick="imbReset_Click" ToolTip="�ʴ�������" />
                        </td>
                    </tr>
                </table>
               
            </fieldset>        
            </td>
        </tr>
        <tr>
            <td style="height:15px">
                <asp:Label ID="lbStatusMain" runat="server" EnableViewState="False"></asp:Label>
                <asp:TextBox ID="txhSortField" runat="server" Visible="False" Width="15px"></asp:TextBox><asp:TextBox
                    ID="txhSortDir" runat="server" Visible="False" Width="15px"></asp:TextBox></td>
        </tr>
        <tr>
            <td >
                <uc2:PageControl ID="pcTop" runat="server" OnPageChange="PageChange"/>
                <asp:GridView ID="gvMain" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="t_tablestyle" OnRowDataBound="gvMain_RowDataBound" 
                    OnSorting="gvMain_Sorting" AllowPaging="True" PageSize="20" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="LOID" HeaderText="LOID">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FORMULANAME" HeaderText="FORMULANAME">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="imbDelete" runat="server" ImageUrl="~/Images/icn_delete.png" ToolTip="ź������" CommandArgument='<%# Bind("LOID") %>' OnClick="imbDelete_Click" Visible='<%# (Eval("STATUS").ToString() != "AP") && (Eval("DIVISION").ToString() == txtDivision.Text) %>'/>
                                <asp:ImageButton ID="imbCopy" runat="server" ImageUrl="~/Images/icn_copy.png" ToolTip="�Ѵ�͡������" CommandArgument='<%# Bind("LOID") %>' OnClick="imbCopy_Click" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="70px" />
                            <ItemStyle HorizontalAlign="Center" Width="70px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="�ӴѺ" SortExpression="DEFAULT">
                            <HeaderStyle Width="60px" />
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="�����ٵ������" SortExpression="FORMULANAME">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkFormulaSet" runat="server" Text='<%# Bind("FORMULANAME") %>' OnClick="lnkFormulaSet_Click" CommandArgument='<%# Bind("LOID")  %>'></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle Width="250px" />
                            <HeaderStyle Width="250px" />
                        </asp:TemplateField>
                         <asp:BoundField DataField="DIVISIONNAME" HeaderText="˹��§ҹ" SortExpression="DIVISIONNAME">
                            <HeaderStyle Width="120px" />
                            <ItemStyle Width="120px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FOODTYPENAME" HeaderText="�����������" SortExpression="FOODTYPENAME">
                            <HeaderStyle Width="110px" />
                            <ItemStyle Width="110px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FOODCATEGORYNAME" HeaderText="��Դ�����" SortExpression="FOODCATEGORYNAME">
                            <HeaderStyle Width="80px" />
                            <ItemStyle Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SPECIALTYPE" HeaderText="������/੾���ä" SortExpression="SPECIALTYPE">
                            <HeaderStyle Width="120px" />
                            <ItemStyle Width="120px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ENERGY" HeaderText="��ѧ�ҹ (kcal)" SortExpression="ENERGY" HtmlEncode="False" DataFormatString="{0:#,##0}">
                            <HeaderStyle Width="100px" />
                            <ItemStyle Width="100px" HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PORTION" HeaderText="Portion" SortExpression="PORTION" HtmlEncode="False" DataFormatString="{0:#,##0}">
                            <HeaderStyle Width="70px" />
                            <ItemStyle Width="70px" HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="WEIGHT" HeaderText="���˹ѡ (g)" SortExpression="WEIGHT" HtmlEncode="False" DataFormatString="{0:#,##0.00}">
                            <HeaderStyle Width="70px" />
                            <ItemStyle Width="70px" HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="STATUSNAME" HeaderText="ʶҹ�" SortExpression="STATUSNAME">
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ACTIVENAME" HeaderText="�����ҹ" SortExpression="ACTIVENAME">
                            <HeaderStyle HorizontalAlign="Center" Width="80px" />
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
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
</asp:Content>