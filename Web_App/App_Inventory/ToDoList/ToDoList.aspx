<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="ToDoList.aspx.cs" Inherits="App_Inventory_ToDoList_ToDoList" Title="SHND : Transaction - To Do List" %>
<%@ Register Src="../../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc3" %>
<%@ Register Src="../../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
 <script language="JavaScript" type="text/javascript">
        function ClienttabTodolist_ActiveTabChanged(sender, e)
        {
            __doPostBack('<%= tabTodolist.ClientID %>', sender.get_activeTab().get_headerText());
        }
    </script>

    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="headtext">To Do List</td>
        </tr>
        <tr>
            <td>
                <hr style="size:1px" />
                <asp:TextBox ID="txhSortField" runat="server" Visible="False" Width="15px"></asp:TextBox>
                <asp:TextBox ID="txhSortDir" runat="server" Visible="False" Width="15px"></asp:TextBox>
                <asp:TextBox ID="txhID" runat="server" Visible="False" Width="15px"></asp:TextBox>
                <asp:TextBox  ID="txtStatus" runat="server" Visible="False" Width="15px"></asp:TextBox>
                <asp:Label ID="lbStatus" runat="server" EnableViewState="False"></asp:Label> 
                <asp:TextBox ID="txtCurentTab" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height:15px">
                <cc1:TabContainer ID="tabTodolist" runat="server" ActiveTabIndex="0" OnActiveTabChanged="tabTodolist_ActiveTabChanged" AutoPostBack="true">
                    <cc1:TabPanel ID="tabTodolistDetail" runat="server" HeaderText="รอจ่าย" >
                        <ContentTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td style="height: 15px">
                                     <fieldset style="padding:15px;">
                                     <legend style="font-weight:bold">
                                         ค้นหา
                                     </legend>
                            
                            <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                <tr style="height:15px">
                                    <td colspan="5"></td>
                                </tr>
                                <tr style="height:24px">
                                    <td style="width:130px; text-align: right; padding-right:10px">เลขที่เบิก</td>
                                    <td style="width:200px;"><asp:TextBox ID="txtSearch" runat="server" CssClass="zTextbox" Width="200px" MaxLength="20"></asp:TextBox></td>
                                    <td style="width:30px; text-align:center;">ถึง</td>
                                    <td style="width:200px;"><asp:TextBox ID="txtSearch2" runat="server" CssClass="zTextbox" Width="200px" MaxLength="20"></asp:TextBox></td>
                                    <td></td>
                                </tr>
                                <tr style="height:24px">
                                    <td style="width:130px; text-align: right; padding-right:10px">วันที่ใช้</td>
                                    <td style="width:200px;">
                                        <uc3:CalendarControl ID="CalendarControl1" runat="server" /></td>
                                    <td style="width:30px; text-align:center;">ถึง</td>
                                    <td style="width:200px;">
                                        <uc3:CalendarControl ID="CalendarControl2" runat="server" /></td>
                                    <td></td>
                                </tr>
                                <tr style="height:24px">
                                    <td style="width:130px; text-align: right; padding-right:10px">สถานะ</td>
                                    <td style="width:200px;"><asp:DropDownList ID="cmbStatusFrom" runat="server" Width="200px" CssClass="zComboBox"></asp:DropDownList></td>
                                    <td style="width:30px; text-align:center;">ถึง</td>
                                    <td style="width:200px;"><asp:DropDownList ID="cmbStatusTo" runat="server" Width="200px" CssClass="zComboBox"></asp:DropDownList></td>
                                    <td>
                                        &nbsp;<asp:ImageButton ID="imbSearch" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_find.png" OnClick="imbSearch_Click" />
                                        &nbsp;<asp:ImageButton ID="imbReset" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_back.png"  OnClick="imbReset_Click"   ToolTip="แสดงทั้งหมด" />
                                    </td>
                                </tr>
                            </table>
                                    </fieldset> 
                                    </td> 
                                 </tr>
                             </table>
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="height:15px">
                                        <asp:Label ID="lbStatusMain" runat="server" EnableViewState="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <uc2:PageControl ID="pcTop" runat="server" OnPageChange="PageChange" />
                                        <asp:GridView ID="gvMain" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="t_tablestyle"   OnRowDataBound="gvMain_RowDataBound" OnSorting="gvMain_Sorting"   AllowPaging="True" PageSize="20" style="width:100%;">
                                        <Columns>
                                            <asp:BoundField DataField="LOID" HeaderText="LOID">
                                            <ControlStyle CssClass="zHidden"></ControlStyle>
                                            <ItemStyle CssClass="zHidden"></ItemStyle>
                                            <HeaderStyle CssClass="zHidden"></HeaderStyle>
                                            <FooterStyle CssClass="zHidden"></FooterStyle>
                                            </asp:BoundField>
                                            
                                            <asp:TemplateField HeaderText="ลำดับ" SortExpression="DEFAULT">
                                            <HeaderStyle Width="60px" />
                                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField SortExpression="CODE" HeaderText="เลขที่เบิก">
                                            <ItemStyle Width="150px" HorizontalAlign="Center" Height="24px"></ItemStyle>
                                            <HeaderStyle Width="150px" HorizontalAlign="Center"></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkCode" runat="server" Text='<%# Bind("CODE") %>' CommandArgument='<%# Bind("LOID")  %>' OnClick="lnkCode_Click"  ></asp:LinkButton>                                            
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                            <asp:BoundField HtmlEncode="False" DataField="DIVISIONNAME" SortExpression="DIVISIONNAME" HeaderText="หน่วยที่เบิก">
                                            <ItemStyle Width="250px" HorizontalAlign="Left"></ItemStyle>
                                            <HeaderStyle Width="250px" HorizontalAlign="Center"></HeaderStyle>
                                            </asp:BoundField>
                                            
                                            <asp:BoundField HtmlEncode="False" DataFormatString="{0:dd/MM/yyyy}" DataField="STOCKOUTDATE" SortExpression="STOCKOUTDATE" HeaderText="วันที่เบิก">
                                            <ItemStyle Width="100px" HorizontalAlign="Center"></ItemStyle>
                                            <HeaderStyle Width="100px" HorizontalAlign="Center"></HeaderStyle>
                                            </asp:BoundField>
                                            
                                            <asp:BoundField HtmlEncode="False" DataFormatString="{0:dd/MM/yyyy}" DataField="USEDATE" SortExpression="USEDATE" HeaderText="วันที่ใช้">
                                            <ItemStyle Width="100px" HorizontalAlign="Center"></ItemStyle>
                                            <HeaderStyle Width="100px" HorizontalAlign="Center"></HeaderStyle>
                                            </asp:BoundField>
                                            
                                            <asp:BoundField HtmlEncode="False" DataField="DOCNAME" SortExpression="DOCNAME" HeaderText="ประเภทการเบิก">
                                            <ItemStyle Width="100px"></ItemStyle>
                                            <HeaderStyle Width="100px" HorizontalAlign="Center"></HeaderStyle>
                                            </asp:BoundField>
                                            
                                            <asp:BoundField DataField="STATUSNAME" SortExpression="STATUSNAME" HeaderText="สถานะ">
                                            <ItemStyle Width="100px" HorizontalAlign="Center"></ItemStyle>
                                            <HeaderStyle Width="100px" HorizontalAlign="Center"></HeaderStyle>
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
    </ContentTemplate>
</cc1:TabPanel>

<cc1:TabPanel ID="tabMinimumStock" runat="server" HeaderText="ต่ำกว่า Minimum Stock">
    <ContentTemplate>
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td class="toolbarplace" >
                    <uc1:ToolBarItemCtl ID="tbAddMinimumStock" runat="server" ToobarTitle="สั่งซื้อ" ToolbarImage="../../Images/icn_add.png" Visible="false"  />
                </td>
            </tr>
            <tr>
                <td style="height: 15px">
                 <fieldset style="padding:15px;">
                 <legend style="font-weight:bold">
                     ค้นหา
                 </legend>
        <table cellspacing="0" cellpadding="0" border="0" width="100%">
            <tr style="height:15px">
                <td colspan="2" style="height: 15px">&nbsp;</td>
            </tr>
            <tr>
                <td style="width:120px; text-align: right; padding-right:10px">คลัง </td>
                <td><asp:DropDownList ID="cmbSearchWareHouse" runat="server" Width="205px">
                    </asp:DropDownList>
                </td>
            </tr> 
             <tr>
                <td style="width:120px; text-align: right; padding-right:10px">ชื่อวัสดุ</td>
                <td style="height: 22px"><asp:TextBox ID="txtSearchMin" runat="server" CssClass="zTextbox" MaxLength="50" Width="400px"></asp:TextBox>
                &nbsp; &nbsp;<asp:ImageButton ID="imbSearchMin" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_find.png" OnClick="imbSearchMin_Click" />
                &nbsp;<asp:ImageButton ID="imbResetMin" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_back.png"  OnClick="imbResetMin_Click"   ToolTip="แสดงทั้งหมด" /></td>
            </tr>
        </table>
        </fieldset>
        </td>
        </tr>
        </table>
        
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                    <uc2:PageControl ID="pcTop1" runat="server" OnPageChange="PageChangeM" />
                    <asp:GridView ID="gvMinimumStock" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="t_tablestyle"   OnRowDataBound="gvMain_RowDataBound" OnSorting="gvMain_Sorting"   AllowPaging="True" PageSize="20" style="width:100%;">
                                            
                    <Columns>
                        <asp:BoundField DataField="LOID" HeaderText="LOID">
                        <ControlStyle CssClass="zHidden"></ControlStyle>
                        <ItemStyle CssClass="zHidden"></ItemStyle>
                        <HeaderStyle CssClass="zHidden"></HeaderStyle>
                        <FooterStyle CssClass="zHidden"></FooterStyle>
                        </asp:BoundField>
                        
                        <asp:TemplateField><HeaderTemplate>
                            <input type="checkbox" name="chkMain" id="chkMain" onclick="chkAllBox(this, 'ctl00_MainContent_gvMain_ctl', '_chkSelect')" />                                             
                        </HeaderTemplate>
                        <ItemStyle Width="30px" HorizontalAlign="Center"></ItemStyle>
                        <HeaderStyle Width="30px" HorizontalAlign="Center"></HeaderStyle>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect" runat="server" Visible="false" />                                          
                        </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="ลำดับ" SortExpression="DEFAULT">
                        <HeaderStyle Width="60px" />
                        <ItemStyle HorizontalAlign="Center" Width="60px" Height="20px" />
                        </asp:TemplateField>
                        
                        <asp:BoundField DataField="MATERIALCODE" SortExpression="CODE" HeaderText="รหัสวัสดุ">
                        <ItemStyle Width="80px" HorizontalAlign="Center"></ItemStyle>
                        <HeaderStyle Width="80px" HorizontalAlign="Center"></HeaderStyle>
                        </asp:BoundField>

                        <asp:BoundField DataField="MATERIALNAME" SortExpression="MATERIALNAME" HeaderText="รายการ">
                        <ItemStyle  HorizontalAlign="Left"></ItemStyle>
                        <HeaderStyle  HorizontalAlign="Center"></HeaderStyle>
                        </asp:BoundField>

                        <asp:BoundField DataField="WAREHOUSENAME" SortExpression="WAREHOUSENAME" HeaderText="คลัง">
                        <ItemStyle Width="120px" HorizontalAlign="Left"></ItemStyle>

                        <HeaderStyle Width="120px" HorizontalAlign="Center"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="MINSTOCK" SortExpression="MINSTOCK" HeaderText="Minimum">
                        <ItemStyle Width="80px" HorizontalAlign="Right"></ItemStyle>

                        <HeaderStyle Width="80px" HorizontalAlign="Center"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="QTY" SortExpression="QTY" HeaderText="คงคลัง">
                        <ItemStyle Width="80px" HorizontalAlign="Right"></ItemStyle>

                        <HeaderStyle Width="80px" HorizontalAlign="Center"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="UNITNAME" SortExpression="UNITNAME" HeaderText="หน่วยนับ">
                        <ItemStyle Width="80" HorizontalAlign="Center"></ItemStyle>
                        <HeaderStyle Width="80" HorizontalAlign="Center"></HeaderStyle>
                        </asp:BoundField>
                    </Columns>
                    <HeaderStyle CssClass="t_headtext" />
                    <PagerSettings Visible="False" />
                    <AlternatingRowStyle CssClass="t_alt_bg" />
                    </asp:GridView>
                    <uc2:PageControl ID="pcBot1" runat="server" OnPageChange="PageChangeM" />
                </td>
            </tr>
            </table>
            </ContentTemplate>
            </cc1:TabPanel>
        </cc1:TabContainer>
    </td>
</tr> 
</table>
</asp:Content>