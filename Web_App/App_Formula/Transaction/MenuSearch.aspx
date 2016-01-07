<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="MenuSearch.aspx.cs" Inherits="App_Formula_Transaction_MenuSearch" Title="SHND : Transaction - Menu" %>

<%@ Register Src="../../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="headtext">
                ข้อมูลเมนูล่วงหน้า</td>
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
            
                <table cellspacing="0" cellpadding="0" border="0" width="650px">
                    <tr style="height:15px">
                        <td colspan="3">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width:130px; text-align: right; padding-right:10px; height: 24px;">
                            ชื่อชุดเมนู :</td>
                        <td style="width:200px; height: 24px;">
                            <asp:TextBox ID="txtSearchName" runat="server" CssClass="zTextbox" MaxLength="100" Width="200px"></asp:TextBox>
                        </td>
                        <td style="height: 24px;">
                        </td>
                    </tr>
                    <tr >
                        <td style="padding-right: 10px; width: 130px; text-align: right; height: 24px;">
                            ประเภทอาหาร :</td>
                        <td style="width: 200px; height: 24px;">
                            <asp:DropDownList ID="cmbSearchFoodType" runat="server" Width="205px" CssClass="zComboBox">
                            </asp:DropDownList></td>
                        <td style="height: 24px;">
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-right: 10px; width: 130px; text-align: right; height: 24px;">
                            ชนิดอาหาร :</td>
                        <td style="width: 200px; height: 24px;">
                            <asp:DropDownList ID="cmbSearchFoodCategory" runat="server" Width="205px" CssClass="zComboBox">
                            </asp:DropDownList></td>
                        <td style="height: 24px;">
                            &nbsp;&nbsp;<asp:ImageButton ID="imbSearch" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_find.png"
                                OnClick="imbSearch_Click" />&nbsp;
                            <asp:ImageButton ID="imbReset" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_back.png"
                                OnClick="imbReset_Click" ToolTip="แสดงทั้งหมด" />
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
            <td style="width:1150px">
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
                        <asp:BoundField DataField="DIVISION" HeaderText="DIVISION">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="imbDelete" runat="server" ImageUrl="~/Images/icn_delete.png" ToolTip="ลบข้อมูล" CommandArgument='<%# Bind("LOID") %>' OnClick="imbDelete_Click" />  
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="60px" />
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ลำดับ" SortExpression="DEFAULT">
                            <HeaderStyle Width="60px" />
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ชื่อชุดเมนู" SortExpression="MENUNAME">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkName" runat="server" Text='<%# Bind("MENUNAME") %>' OnClick="lnkName_Click" CommandArgument='<%# Bind("LOID")  %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="FOODTYPENAME" HeaderText="ประเภทอาหาร" SortExpression="FOODTYPENAME">
                            <HeaderStyle Width="100px" />
                            <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FOODCATEGORYNAME" HeaderText="ชนิดอาหาร" SortExpression="FOODCATEGORYNAME">
                            <HeaderStyle Width="100px" />
                            <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DIVISIONNAME" HeaderText="หน่วยงาน" SortExpression="DIVISIONNAME">
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DISEASE" HeaderText="ควบคุม (disease)" SortExpression="DISEASE">
                            <HeaderStyle Width="100px" />
                            <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="BUDGETYEAR" HeaderText="ปีงบประมาณ" SortExpression="BUDGETYEAR">
                            <HeaderStyle  HorizontalAlign="Center" Width="100px" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PHASE" HeaderText="งวดประมาณการ" SortExpression="PHASE">
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
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
