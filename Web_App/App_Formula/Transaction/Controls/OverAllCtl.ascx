<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OverAllCtl.ascx.cs" Inherits="App_Formula_Transaction_Controls_OverAllCtl" %>
<%@ Register Src="../../../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%@ Register Src="../../../Templates/CalendarControl.ascx" TagName="CalendarControl"
    TagPrefix="uc1" %>
<table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="right" style="width: 70px; height: 3px;" colspan="2"> 
                <asp:TextBox ID="txhSortField" runat="server" Visible="False" Width="15px"></asp:TextBox>
                <asp:TextBox ID="txhSortDir" runat="server" Visible="False" Width="15px"></asp:TextBox>
            </td>
            <td style="height:3px; width: 712px;">
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
                            <td colspan="5">&nbsp;</td>
                        </tr>
                         <tr style="height:24px">
                            <td style="text-align: right; padding-right:10px">วันที่ :</td>
                            <td style="width: 137px" >
                                <uc1:CalendarControl ID="ctlDateFrom" runat="server" />
                            </td>   
                            <td  align="center">ถึง</td>
                            <td >
                                <uc1:CalendarControl ID="ctlDateTo" runat="server" />
                            </td>                 
                        </tr>
                        <tr>
                            <td style="text-align: right; padding-right:10px; height: 24px;">มื้อ :</td>
                            <td colspan="4" style="height: 24px">
                                <asp:DropDownList runat ="server" ID="cmbMeal" CssClass="zComboBox" Width ="150px" ></asp:DropDownList>
                             </td>
                            
                        </tr>
                         <tr>
                            <td style="text-align: right; padding-right:10px; height: 24px;">กลุ่ม :</td>
                            <td colspan="4" style="height: 24px">
                                <asp:DropDownList runat ="server" ID="cmbGroup" CssClass="zComboBox" Width ="250px" ></asp:DropDownList>
                             </td>
                            
                        </tr>
                        <tr>
                        <td style="text-align: right; padding-right:10px; height: 24px;">รายการ :</td>
                        <td colspan="4" style="height:24px">
                               <asp:TextBox runat ="server" ID="txtName" CssClass="zTextbox" Width ="350px"></asp:TextBox>
                               <asp:ImageButton ID="imbSearch" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_find.png"
                                OnClick="imbSearch_Click" />
                                <asp:ImageButton ID="imbReset" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_back.png"
                                     OnClick="imbReset_Click" Visible="false" ToolTip="แสดงทั้งหมด" />
                                </td>                   
                        </tr>
                    </table>   
            </fieldset>        
           
         <tr>
            <td>
                 <uc2:PageControl ID="pcTop" runat="server" OnPageChange="PageChange" Visible="false" />
                <asp:GridView ID="grvResult" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="t_tablestyle" PageSize="20" 
                    OnSorting="grvResult_Sorting" AllowPaging="True" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="MENU" HeaderText="MENU">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>    
                        <asp:BoundField DataField="MENUDATE" HeaderText="วันที่" SortExpression="MENUDATE" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="False" >
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="มื้อ" SortExpression="MEALNAME">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkMeal" runat="server" Text='<%# Bind("MEALNAME") %>' OnClick="lnkMeal_Click" ></asp:LinkButton>                            
                            </ItemTemplate>
                            <HeaderStyle Width="80px" />
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:TemplateField>                   
                        <asp:BoundField DataField="FORMULANAME" HeaderText="รายการ" SortExpression="FORMULANAME" HtmlEncode="false">
                        </asp:BoundField>
                        <asp:BoundField DataField="GROUPNAME" HeaderText="กลุ่ม" SortExpression="GROUPNAME" HtmlEncode="false">
                            <HeaderStyle Width="150px" />
                            <ItemStyle HorizontalAlign="Left" Width="150px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="MEAL" HeaderText="MEAL">
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
                <uc2:PageControl ID="pcBot" runat="server" OnPageChange="PageChange" Visible="false" />
                 
                </td>
        </tr>
    </table>