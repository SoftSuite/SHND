<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="BlenderizeDietSearch.aspx.cs" Inherits="App_Formula_Master_BlenderizeDietSearch" Title="SHND : Master - Blenderize Diet" %>

<%@ Register Src="../../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="headtext">
                ข้อมูลสูตรอาหารทางสายให้อาหาร</td>
        </tr>
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbAdd" runat="server" ToobarTitle="เพิ่มข้อมูล" OnClick="tbAddClick" ToolbarImage="../../Images/icn_add.png"  />
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
                ค้นหา
            </legend>
            
                <table cellspacing="0" cellpadding="0" border="0" width="600px">
                    <tr style="height:15px">
                        <td colspan="4">&nbsp;</td>
                    </tr>
                    <tr style="height:24px">
                        <td style="width:100px; text-align: right; padding-right:10px">ชื่อสูตร :</td>
                        <td colspan="3"><asp:TextBox ID="txtSearchName" runat="server" CssClass="zTextbox" MaxLength="50" Width="310px"></asp:TextBox></td>
                    </tr>
                    <tr style="height:24px">
                        <td style="width:100px; text-align: right; padding-right:10px">ปริมาณ :</td>
                        <td style="width:180px"><asp:TextBox ID="txtCapFrom" runat="server" CssClass="zTextboxR" MaxLength="50" Width="100px"></asp:TextBox>
                            ml</td>
                        <td style="width:20px; text-align: right; padding-right:10px">ถึง</td>
                        <td><asp:TextBox ID="txtCapTo" runat="server" CssClass="zTextboxR" MaxLength="50" Width="100px"></asp:TextBox>&nbsp; ml </td>
                    </tr>
                    <tr style="height:24px">
                        <td style="width:100px; text-align: right; padding-right:10px">พลังงาน :</td>
                        <td style="width:180px"><asp:TextBox ID="txtEnFrom" runat="server" CssClass="zTextboxR" MaxLength="50" Width="100px"></asp:TextBox>
                            kcal/ml</td>
                        <td style="width:20px; text-align: right; padding-right:10px">ถึง</td>
                        <td><asp:TextBox ID="txtEnTo" runat="server" CssClass="zTextboxR" MaxLength="50" Width="100px"></asp:TextBox>&nbsp; kcml/ml &nbsp; &nbsp;&nbsp; &nbsp;
                        <asp:ImageButton ID="imbSearch" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_find.png"
                    OnClick="imbSearch_Click" />&nbsp;
                <asp:ImageButton ID="imbReset" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_back.png"
                    OnClick="imbReset_Click" ToolTip="แสดงทั้งหมด" /></td>
                    </tr>

                </table>

                
            </fieldset>        
            </td>
        </tr>
        <tr>
            <td style="height:15px">
                <asp:Label ID="lbStatusMain" runat="server" EnableViewState="False"></asp:Label>
                <asp:Label ID="Label1" runat="server" EnableViewState="False"></asp:Label>
                <asp:TextBox ID="txhSortField" runat="server" Visible="False" Width="15px"></asp:TextBox><asp:TextBox
                    ID="txhSortDir" runat="server" Visible="False" Width="15px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
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
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="imbDelete" runat="server" ImageUrl="~/Images/icn_delete.png" ToolTip="ลบข้อมูล" CommandArgument='<%# Bind("LOID") %>' OnClick="imbDelete_Click"/>
                                <asp:ImageButton ID="imbCopy" runat="server" ImageUrl="~/Images/icn_copy.png" ToolTip="คัดลอกข้อมูล" CommandArgument='<%# Bind("LOID") %>' OnClick="imbCopy_Click" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="60px" />
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ลำดับ" SortExpression="DEFAULT">
                            <HeaderStyle Width="60px" />
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ชื่อสูตรอาหาร" SortExpression="NAME">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkFood" runat="server" Text='<%# Bind("NAME") %>' OnClick="lnkFood_Click" CommandArgument='<%# Bind("LOID")  %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ENERGY" HeaderText="พลังงาน (Kcal)" SortExpression="ENERGY" HtmlEncode="false" DataFormatString="{0:#,##0.00}">
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle HorizontalAlign="Right" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CAPACITY" HeaderText="ปริมาณ (ml)" SortExpression="CAPACITY" HtmlEncode="false" DataFormatString="{0:#,##0.00}">
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle HorizontalAlign="Right" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ACTIVE" HeaderText="การใช้งาน" SortExpression="ACTIVE">
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundField>
                    </Columns>
                    <HeaderStyle CssClass="t_headtext" />
                    <AlternatingRowStyle CssClass="t_alt_bg" />
                    <PagerSettings Visible="False" />
                </asp:GridView><uc2:PageControl ID="pcBot" runat="server" OnPageChange="PageChange" />
                </td>
        </tr>
    </table>

</asp:Content>
