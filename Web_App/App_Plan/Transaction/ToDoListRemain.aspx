<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="ToDoListRemain.aspx.cs" Inherits="App_Plan_Transaction_ToDoListRemain" Title="SHND : Transaction - To Do List" %>
<%@ Register Src="../../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="headtext">To Do List</td>
        </tr>
        <tr>
            <td style="height:10px">
            </td>
        </tr>
        <tr>
            <td>
                <cc1:TabContainer ID="tabToDoList" runat="server" ActiveTabIndex="0">
                    <cc1:TabPanel ID="tabRemain" runat="server" HeaderText="ยอดประมาณการวัสดุอาหารคงเหลือ" >
                        <ContentTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td>
                                        <fieldset style="padding:15px;">
                                            <legend style="font-weight:bold">ค้นหา</legend>
                                            <table border="0" cellspacing="0" cellpadding="0" width="900">
                                                <tr style="height:15px">
                                                    <td colspan="2"></td>
                                                    <td colspan="1">
                                                    </td>
                                                </tr>
                                                <tr style="height:24px">
                                                    <td style="padding-right:10px; width:130px; text-align:right">
                                                        แผนประมาณการ :
                                                    </td>
                                                    <td colspan="2" style="width: 320px" >
                                                        <asp:DropDownList ID="cmbSearchPlan" runat="server" CssClass="zComboBox" Width="306px"></asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr style="height:24px">
                                                    <td style="padding-right:10px; width:130px; text-align:right">
                                                        หมวดอาหาร :</td>
                                                    <td colspan="2" style="width: 320px">
                                                        <asp:DropDownList ID="cmbSearchMaterialClass" runat="server" CssClass="zComboBox" Width="306px"></asp:DropDownList>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr style="height:24px" >
                                                    <td style="padding-right:10px; width:130px; text-align:right">
                                                        ชื่อวัสดุอาหาร :</td>
                                                    <td colspan="2" style="width: 320px" >
                                                        <asp:TextBox ID="txtSearchName" runat="server" Width="300px" CssClass="zTextbox"></asp:TextBox></td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr style="height:24px">
                                                    <td style="padding-right:10px; width:130px; text-align:right">
                                                        % คงเหลือ :</td>
                                                    <td style="width: 320px">
                                                        <asp:DropDownList ID="cmbSearchOperator" runat="server" CssClass="zComboBox" Width="80px">
                                                            <asp:ListItem>ไม่เลือก</asp:ListItem>
                                                            <asp:ListItem Value="1">&gt;=</asp:ListItem>
                                                            <asp:ListItem Value="2">&lt;=</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:TextBox ID="txtSearchRemainPercent" runat="server" CssClass="zTextboxR" MaxLength="3"
                                                            Width="50px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:ImageButton ID="imbSearch" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_find.png" OnClick="imbSearch_Click" />&nbsp;
                                                        <asp:ImageButton ID="imbReset" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_back.png" OnClick="imbReset_Click" ToolTip="แสดงทั้งหมด" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </fieldset>
                                    </td>  
                                </tr>
                                <tr>
                                    <td style="height:15px">
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
                                                <asp:BoundField DataField="MATERIALMASTER" HeaderText="MATERIALMASTER">
                                                    <ControlStyle CssClass="zHidden" />
                                                    <FooterStyle CssClass="zHidden" />
                                                    <HeaderStyle CssClass="zHidden" />
                                                    <ItemStyle CssClass="zHidden" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="ลำดับ" SortExpression="DEFAULT">
                                                    <HeaderStyle Width="60px" />
                                                    <ItemStyle HorizontalAlign="Center" Width="60px" Height="24px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="รหัส SAP" SortExpression="SAPCODE">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkCode" runat="server" Text='<%# Eval("SAPCODE").ToString() == "" ? "-" : Eval("SAPCODE") %>' CommandArgument='<%# Bind("MATERIALMASTER") %>' OnClick="lnkCode_Click"></asp:LinkButton> 
                                                    </ItemTemplate>
                                                    <ItemStyle Width="80px" HorizontalAlign="Center" />
                                                    <HeaderStyle Width="80px" />  
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="MATERIALNAME" HeaderText="รายการ" SortExpression="MATERIALNAME">
                                                </asp:BoundField>
                                                <asp:BoundField DataField="UNITNAME" HeaderText="หน่วยนับ" SortExpression="UNITNAME">
                                                    <ItemStyle Width="70px" />
                                                    <HeaderStyle Width="70px" /> 
                                                </asp:BoundField>
                                                <asp:BoundField DataField="CLASSNAME" HeaderText="หมวดวัสดุ" SortExpression="CLASSNAME">
                                                    <ItemStyle Width="150px" />
                                                    <HeaderStyle Width="150px" /> 
                                                </asp:BoundField>
                                                <asp:BoundField DataField="REMAINQTY" HeaderText="คงเหลือ" HtmlEncode="False" DataFormatString="{0:#,##0.00}">
                                                    <ItemStyle Width="80px" HorizontalAlign="Right" />
                                                    <HeaderStyle Width="80px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ADJQTY" HeaderText="ประมาณการ" HtmlEncode="False" DataFormatString="{0:#,##0.00}">
                                                    <ItemStyle Width="80px" HorizontalAlign="Right" />
                                                    <HeaderStyle Width="80px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="REMAINPERCENT" HeaderText="% คงเหลือ" HtmlEncode="False" DataFormatString="{0:#,##0.00}">
                                                    <ItemStyle Width="80px" HorizontalAlign="Right" />
                                                    <HeaderStyle Width="80px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="NETPRICE" HeaderText="รวมเป็นเงิน<br>รวมภาษี" HtmlEncode="False" DataFormatString="{0:#,##0.00}">
                                                    <ItemStyle Width="80px" HorizontalAlign="Right" />
                                                    <HeaderStyle Width="80px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="SPEC" HeaderText="SPEC">
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
                        </ContentTemplate>
                    </cc1:TabPanel>
                </cc1:TabContainer>
            </td>
        </tr>
    </table> 
    <asp:TextBox ID="txtRowIndex" runat="server" Visible="false"></asp:TextBox>
    <asp:TextBox ID="txtMaterialMaster" runat="server" Visible="false"></asp:TextBox>
    <cc1:ModalPopupExtender ID="ctlSpecPopup"  runat="server" PopupControlID="pnlSpec" BackgroundCssClass="modalBackground" DropShadow="true" TargetControlID="btnTest"></cc1:ModalPopupExtender>
    <asp:Panel ID="pnlSpec" runat="server" CssClass="modalPopup" style="display:none" >
        <table border="0" cellspacing="0" cellpadding="0" width="500">
            <tr>
                <td class="subheadertext">
                    <asp:Label ID="lblMaterialName" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <uc1:ToolBarItemCtl ID="tbSaveSpec" runat="server" ToobarTitle="บันทึกข้อมูล" ToolbarImage="../../Images/save2.png" OnClick="tbSaveSpecClick" Visible="false" />
                    <uc1:ToolBarItemCtl ID="tbBackSpec" runat="server" ToobarTitle="กลับหน้ารายการ" ToolbarImage="../../Images/icn_back.png" />
                </td>
            </tr>
            <tr>
                <td><hr style="size:1px"/>
                    <asp:Label ID="lbStatus" runat="server" EnableViewState="False" ></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtSpec" runat="server" TextMode="MultiLine" Width="500px" Height="80px" MaxLength="200" CssClass="zTextbox" Enabled="False"></asp:TextBox>
                </td> 
            </tr>
        </table>
    </asp:Panel>
    <asp:Button ID="btntest" runat="server" Text="test" CssClass="zHidden" />
</asp:Content>