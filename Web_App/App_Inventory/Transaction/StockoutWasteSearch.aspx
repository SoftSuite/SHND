<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="StockoutWasteSearch.aspx.cs" Inherits="App_Inventory_Transaction_StockoutWasteSearch" Title="SHND : Master - Waste Stock out" %>

<%@ Register Src="../../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc3" %>
<%@ Register Src="../../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">

    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="headtext">
                ข้อมูลการจำหน่ายของเสีย</td>
        </tr>
        <tr>
             <td>
                <uc1:ToolBarItemCtl ID="tbAdd" runat="server" ToobarTitle="เพิ่มข้อมูล"  ToolbarImage="../../Images/icn_add.png" OnClick= "tbAddClick"  />
                <uc1:ToolBarItemCtl ID="tbDel" runat="server" ToobarTitle="ลบข้อมูลที่เลือก"  ToolbarImage="../../Images/icn_delete.png" ClientClick="return confirm('ต้องการลบข้อมูลที่เลือก ใช่หรือไม่?')"  OnClick="tbDeleteClick"  />
               
            </td>
        </tr>
        <tr>
            <td>
                <hr style="size:1px" />
                <asp:TextBox ID="txhSortField" runat="server" Visible="False" Width="15px"></asp:TextBox>
                <asp:TextBox ID="txhSortDir" runat="server" Visible="False" Width="15px"></asp:TextBox>
                <asp:TextBox ID="txhID" runat="server" Visible="False" Width="15px"></asp:TextBox>
                <asp:TextBox  ID="txtStatus" runat="server" Visible="False" Width="15px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 15px">
                <fieldset style="padding:15px;">
                    <legend style="font-weight:bold">ค้นหา</legend>
                        <table cellspacing="0" cellpadding="0" border="0" width="100%">
                            <tr style="height:15px">
                                <td colspan="5"></td>
                            </tr>
                            <tr style="height:24px">
                                <td style="width:130px; text-align: right; padding-right:10px">เลขที่การจำหน่ายของเสีย</td>
                                <td style="width:200px;"><asp:TextBox ID="txtSearch" runat="server" CssClass="zTextbox" Width="200px" MaxLength="20"></asp:TextBox></td>
                                <td style="width:30px; text-align:center;">ถึง</td>
                                <td style="width:200px;"><asp:TextBox ID="txtSearchTo" runat="server" CssClass="zTextbox" Width="200px" MaxLength="20"></asp:TextBox></td>
                                <td></td>
                            </tr>
                            <tr style="height:24px">
                                <td style="width:130px; text-align: right; padding-right:10px">วันที่จำหน่ายของเสีย</td>
                                <td style="width:200px;">
                                    <uc3:CalendarControl ID="CalendarControl1" runat="server" /></td>
                                <td style="width:30px; text-align:center;">ถึง</td>
                                <td style="width:200px;">
                                    <uc3:CalendarControl ID="CalendarControl2" runat="server" /></td>
                                <td></td>
                            </tr>
                            <tr style="height:24px">
                                 <td style="width:130px; text-align: right; padding-right:10px">คลังที่จำหน่ายออก</td>
                                 <td style="width:200px;"><asp:DropDownList ID="cmbSearcWarehouse" runat="server" Width="200px" CssClass="zComboBox"></asp:DropDownList></td>
                                 
                            </tr>
                            <tr style="height:24px">
                                <td style="width:130px; text-align: right; padding-right:10px">สถานะ</td>
                                <td style="width:200px;"><asp:DropDownList ID="cmbSearcStatusFrom" runat="server" Width="200px" CssClass="zComboBox"></asp:DropDownList></td>
                                <td style="width:30px; text-align:center;">ถึง</td>
                                <td style="width:200px;"><asp:DropDownList ID="cmbSearchStatusTo" runat="server" Width="200px" CssClass="zComboBox"></asp:DropDownList></td>
                                <td>
                                    &nbsp;<asp:ImageButton ID="imbSearch" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_find.png" OnClick="imbSearch_Click" />
                                    &nbsp;
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
            </td>
        </tr>
        
        <tr>
            <td  >
                <uc2:PageControl ID="pcTop" runat="server" />
                <asp:GridView ID="gvMain" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="t_tablestyle"  OnRowDataBound="gvMain_RowDataBound" OnSorting="gvMain_Sorting"  AllowPaging="True" PageSize="20"  style="width:100%;">
                    <Columns>
                        <asp:BoundField DataField="LOID" HeaderText="LOID">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <input type="checkbox" name="chkMain" id="chkMain" onclick="chkAllBox(this, 'ctl00_MainContent_gvMain_ctl', '_chkSelect')"  />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelect" runat="server"  Enabled='<%# Eval("STATUS").ToString() == "WA" || Eval("STATUS").ToString() == "NP" %>'   />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="30px" />
                            <ItemStyle HorizontalAlign="Center" Width="30px" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="ลำดับ" SortExpression="DEFAULT">
                            <HeaderStyle Width="60px" />
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField SortExpression="CODE" HeaderText="เลขที่การจำหน่ายของเสีย">
                            <ItemStyle Width="150px" HorizontalAlign="center"></ItemStyle>
                            <HeaderStyle Width="150px" HorizontalAlign="Center"></HeaderStyle>
                            <ItemTemplate>
                            <asp:LinkButton ID="lnkCode" runat="server" Text='<%# Bind("CODE") %>' CommandArgument='<%# Bind("LOID")  %>' OnClick= "linkCode_Click"  ></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
        
                        <asp:BoundField HtmlEncode="False" DataFormatString="{0:dd/MM/yyyy}" DataField="STOCKOUTDATE" SortExpression="STOCKOUTDATE" HeaderText="วันที่จำหน่ายของเสีย">
                            <ItemStyle Width="120px" HorizontalAlign="Center"></ItemStyle>
                            <HeaderStyle Width="120px" HorizontalAlign="Center"></HeaderStyle>
                        </asp:BoundField>
                        
                        
                          <asp:BoundField HtmlEncode="False"  DataField="DIVISIONNAME" SortExpression="DIVISIONNAME" HeaderText="หน่วยที่ทำเสีย">
                            <ItemStyle Width="200px"></ItemStyle>
                            <HeaderStyle Width="200px" HorizontalAlign="Center"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="WAREHOUSENAME" SortExpression="WAREHOUSENAME" HeaderText="คลังที่จำหน่ายออก">
                            <ItemStyle Width="120px"></ItemStyle>
                            <HeaderStyle Width="120px" HorizontalAlign="Center"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="STATUSNAME" SortExpression="STATUSNAME" HeaderText="สถานะ">
                            <ItemStyle Width="100px"></ItemStyle>
                            <HeaderStyle Width="100px" HorizontalAlign="Center"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="STATUS" HeaderText="STATUS">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                    </Columns>
                   <HeaderStyle CssClass="t_headtext" />
                    <AlternatingRowStyle CssClass="t_alt_bg" />
                    <PagerSettings Visible="False" />
                </asp:GridView><uc2:PageControl ID="pcBot" runat="server"  />
                </td>
        </tr>
    </table>



</asp:Content>

