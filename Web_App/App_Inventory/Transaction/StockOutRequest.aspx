<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="StockOutRequest.aspx.cs" Inherits="App_Inventory_Transaction_StockOutRequest" Title="SHND : Transaction - Stock out Requisition" %>
<%@ Register Src="../../Search/MenuStockOutPopup.ascx" TagName="MenuStockOutPopup" TagPrefix="uc4" %>
<%@ Register Src="../../Search/MaterialUnitPopup.ascx" TagName="MaterialUnitPopup" TagPrefix="uc3" %>
<%@ Register Src="../../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="headtext">
                ข้อมูลการเบิกวัสดุ</td>
        </tr>
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbSave" runat="server" ToobarTitle="บันทึกข้อมูล" ToolbarImage="../../Images/save2.png" OnClick="tbSaveClick" />
                <uc1:ToolBarItemCtl ID="tbCancel" runat="server" ToobarTitle="ยกเลิกการแก้ไข" ToolbarImage="../../Images/cancel.png" OnClick="tbCancelClick" />
                <uc1:ToolBarItemCtl ID="tbSend" runat="server" ToobarTitle="ส่งข้อมูล" ToolbarImage="../../Images/icn_send.png" OnClick="tbSendClick" />
                <uc1:ToolBarItemCtl ID="tbBack" runat="server" ToobarTitle="กลับหน้ารายการ" ToolbarImage="../../Images/icn_back.png" OnClick="tbBackClick" />
                <uc1:ToolBarItemCtl ID="tbPrint" runat="server" ToobarTitle="พิมพ์ใบเบิก" ToolbarImage="../../Images/icn_print.png"/>
            </td>
        </tr>
        <tr>
            <td style="height:30px">
                <hr style="size:1px" />
                <asp:Label ID="lbStatus" runat="server" EnableViewState="False"></asp:Label>
                <asp:TextBox ID="txtLOID" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
                <asp:TextBox ID="txtStatus" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td valign="top" style="padding:5px; border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid; width:600px">
                            <table border="0" cellpadding="0" cellspacing="0" width="600">
                                <tr style="height:24px">
                                    <td style="width:100px; text-align:right; padding-right:10px">
                                        เลขที่เบิก :</td> 
                                    <td style="width:170px">
                                        <asp:TextBox ID="txtCode" runat="server" CssClass="zTextbox-View" ReadOnly="True"
                                            Width="150px"></asp:TextBox></td> 
                                    <td style="width:100px; text-align:right; padding-right:10px">
                                        วันที่เบิก :</td> 
                                    <td>
                                        <uc2:CalendarControl ID="ctlStockDate" runat="server" />&nbsp;<span class="zRemark">*</span>
                                    </td> 
                                </tr>
                                <tr style="height:24px">
                                    <td style="width:100px; text-align:right; padding-right:10px">
                                        หน่วยที่เบิก :</td> 
                                    <td style="width:170px">
                                        <asp:DropDownList ID="cmbDivision" runat="server" CssClass="zComboBox" Enabled="False"
                                            Width="156px">
                                        </asp:DropDownList></td> 
                                    <td style="width:100px; text-align:right; padding-right:10px">
                                        คลัง :</td> 
                                    <td>
                                        <asp:DropDownList ID="cmbWarehouse" runat="server" CssClass="zComboBox" Width="156px">
                                        </asp:DropDownList>&nbsp;<span class="zRemark">*</span></td> 
                                </tr>
                                <tr style="height:24px">
                                    <td style="width:100px; text-align:right; padding-right:10px">
                                        ประเภทการเบิก :</td> 
                                    <td style="width:170px">
                                        <asp:DropDownList ID="cmbDocType" runat="server" CssClass="zComboBox" Width="156px" AutoPostBack="True" OnSelectedIndexChanged="cmbDocType_SelectedIndexChanged">
                                        </asp:DropDownList>&nbsp;<span class="zRemark">*</span></td> 
                                    <td style="width:100px; text-align:right; padding-right:10px">
                                        จำนวนที่สั่ง :</td> 
                                    <td>
                                        <asp:TextBox ID="txtOrderQty" runat="server" CssClass="zTextboxR-View" ReadOnly="True"
                                            Width="150px"></asp:TextBox></td> 
                                </tr>
                                <tr style="height:24px">
                                    <td style="width:100px; text-align:right; padding-right:10px">
                                        วันที่ใช้ :</td> 
                                    <td style="width:170px">
                                        <uc2:CalendarControl ID="ctlUseDate" runat="server" AutoPostBack="true" OnSelectedDateChanged="ctlUseDate_SelectedDateChanged" />&nbsp;<span class="zRemark">*</span>
                                    </td> 
                                    <td style="width:100px; text-align:right; padding-right:10px">
                                        มื้อที่ใช้ :</td> 
                                    <td>
                                        <asp:CheckBox ID="chkIsBreakfast" runat="server" Text="เช้า" AutoPostBack="True" OnCheckedChanged="chkIsBreakfast_CheckedChanged" />
                                        <asp:CheckBox ID="chkIsLunch" runat="server" Text="กลางวัน" AutoPostBack="True" OnCheckedChanged="chkIsLunch_CheckedChanged" />
                                        <asp:CheckBox ID="chkIsDinner" runat="server" Text="เย็น" AutoPostBack="True" OnCheckedChanged="chkIsDinner_CheckedChanged" />&nbsp;<span class="zRemark">*</span></td> 
                                </tr>
                            </table>
                        </td>
                        <td style="width:4px">&nbsp;
                        </td>
                        <td valign="top" style="border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid;">
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td style="border-bottom: 1px solid; padding:5px;">
                                        <table border="0" cellpadding="0" cellspacing="0" width="500">
                                            <tr style="height:24px">
                                                <td style="padding-right:10px; text-align:right; width:80px">
                                                    สถานะ :</td>
                                                <td style="width:420px">
                                                    <asp:TextBox ID="txtStatusName" runat="server" CssClass="zTextbox-View" ReadOnly="True"
                                                        Width="120px"></asp:TextBox></td>
                                            </tr>
                                        </table> 
                                    </td> 
                                </tr>
                                <tr>
                                    <td style="padding:5px">
                                        <table border="0" cellpadding="0" cellspacing="0" width="500">
                                            <tr style="height:24px">
                                                <td style="padding-right:10px; text-align:right; width:80px">
                                                    รวมเงิน :</td>
                                                <td style="width:420px">
                                                    <asp:TextBox ID="txtNetPrice" runat="server" CssClass="zTextboxR-View" ReadOnly="True"
                                                        Width="120px"></asp:TextBox></td>
                                            </tr>
                                        </table> 
                                    </td> 
                                </tr>
                            </table>
                        </td>
                    </tr> 
                </table>  
            </td>
        </tr>
        <tr>
            <td style="height:3px">
            </td>
        </tr>
        <tr id="trToolbar" runat="Server">
            <td class="toolbarplace" style="padding:3px">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td>
                            <uc1:ToolBarItemCtl ID="tbAddFromMenu" runat="server" ToobarTitle="เพิ่มรายการตามเมนู" ToolbarImage="../../Images/icn_add.png" OnClick="tbAddFromMenuClick" />
                            <uc1:ToolBarItemCtl ID="tbAddOthers" runat="server" ToobarTitle="เพิ่มรายการอื่นๆ" ToolbarImage="../../Images/icn_add.png" OnClick="tbAddOthersClick" />
                            <uc1:ToolBarItemCtl ID="tbDelete" runat="server" ToobarTitle="ลบข้อมูล" ToolbarImage="../../Images/icn_Delete.png" OnClick="tbDeleteClick" />
                            <asp:TextBox ID="txtCurDiscountOrder" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
                            <asp:TextBox ID="txtCurDiscountFormula" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
                        </td>
                        <td align="right">
                            <asp:Panel ID="pnlCalculate" runat="server">
                                <table border="0" cellpadding="0" cellspacing="0" width="430px">
                                    <tr>
                                        <td style="padding:2px; background-color:#ebe1eb; width:200px">&nbsp;&nbsp;
                                            <asp:TextBox ID="txtDiscountOrder" runat="server" CssClass="zTextboxR" Width="50px"></asp:TextBox>
                                            <asp:Label ID="Label1" runat="server" Text="% จากจำนวนที่สั่ง"></asp:Label>
                                            <asp:ImageButton ID="imbCalculateOrder" runat="server" ImageUrl="~/Images/icn_calculate.png" ImageAlign="AbsMiddle" ToolTip="คำนวณ" OnClick="imbCalculateOrder_Click" />&nbsp;&nbsp;
                                        </td>
                                        <td style="width:3px"></td>
                                        <td style="padding:2px; background-color:#ebe1eb; width:217px">&nbsp;&nbsp;
                                            <asp:TextBox ID="txtDiscountFormula" runat="server" CssClass="zTextboxR" Width="50px"></asp:TextBox>
                                            <asp:Label ID="Label2" runat="server" Text="% ของจำนวนตามสูตร"></asp:Label>
                                            <asp:ImageButton ID="imbCalculateFormula" runat="server" ImageUrl="~/Images/icn_calculate.png" ImageAlign="AbsMiddle" ToolTip="คำนวณ" OnClick="imbCalculateFormula_Click" />&nbsp;&nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr> 
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CssClass="t_tablestyle" DataSourceID="ItemSource" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="RANK" HeaderText="RANK">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="LOID" HeaderText="LOID">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <input type="checkbox" name="chkMain" id="chkMain" onclick="chkAllBox(this, 'ctl00_MainContent_gvMain_ctl', '_chkSelect')" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelect" runat="server" Enabled='<%# Eval("STATUSSTOCKOUT").ToString() == "WA" || Eval("STATUSSTOCKOUT").ToString() == "NP" %>' />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="30px" />
                            <ItemStyle HorizontalAlign="Center" Width="30px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ลำดับ" SortExpression="DEFAULT">
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>
                            <HeaderStyle Width="60px" />
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="CODE" HeaderText="รหัส" SortExpression="CODE">
                            <HeaderStyle Width="80px" />
                            <ItemStyle Width="80px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="MATERIALNAME" HeaderText="รายการ" SortExpression="MATERIALNAME">
                        </asp:BoundField>
                        <asp:BoundField DataField="UNITNAME" HeaderText="หน่วยนับ" SortExpression="UNITNAME">
                            <HeaderStyle Width="80px" />
                            <ItemStyle Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FORMULAQTY" HeaderText="จำนวนตามสูตร" SortExpression="FORMULAQTY" HtmlEncode="False" DataFormatString="{0:#,##0.00}">
                            <HeaderStyle Width="90px" />
                            <ItemStyle Width="90px" HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PREQTY" HeaderText="จำนวน&lt;br&gt;สั่งล่วงหน้า" SortExpression="PREQTY" HtmlEncode="False" DataFormatString="{0:#,##0.00}">
                            <HeaderStyle Width="90px" />
                            <ItemStyle Width="90px" HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="LASTQTY" HeaderText="จำนวน&lt;br&gt;เบิกล่าสุด" SortExpression="LASTQTY" HtmlEncode="False" DataFormatString="{0:#,##0.00}">
                            <HeaderStyle Width="90px" />
                            <ItemStyle Width="90px" HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="จำนวน&lt;br&gt;ที่ต้องการ">
                            <ItemTemplate>
                                <asp:TextBox ID="txtReqQty" runat="server" Width="85px" Text='<%# Convert.ToDouble(Eval("REQQTY")).ToString("#,##0.00") %>' 
                                    CssClass='<%# (Convert.ToString(Eval("STATUSSTOCKOUT")) == "WA" || Convert.ToString(Eval("STATUSSTOCKOUT")) == "NP") ? "zTextboxR" : "zTextboxR-View" %>' 
                                    ReadOnly='<%# !(Convert.ToString(Eval("STATUSSTOCKOUT")) == "WA" || Convert.ToString(Eval("STATUSSTOCKOUT")) == "NP") %>'
                                    onkeypress="ChkDbl(this)" onblur="valDbl(this)" onfocus="prepareNum(this)" ></asp:TextBox> 
                            </ItemTemplate>
                            <ItemStyle Width="90px" HorizontalAlign="Right" />
                            <HeaderStyle Width="90px" />  
                        </asp:TemplateField>
                        <asp:BoundField DataField="QTY" HeaderText="จำนวนที่จ่าย" SortExpression="QTY" HtmlEncode="False" DataFormatString="{0:#,##0.00}">
                            <HeaderStyle Width="90px" />
                            <ItemStyle Width="90px" HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="REQTOTAL" HeaderText="จำนวนเงิน" SortExpression="REQTOTAL" HtmlEncode="False" DataFormatString="{0:#,##0.00}">
                            <HeaderStyle Width="100px" />
                            <ItemStyle Width="100px" HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ISMENU" HeaderText="M" SortExpression="ISMENU">
                            <HeaderStyle Width="30px" />
                            <ItemStyle Width="30px" HorizontalAlign="center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="STATUSNAME" HeaderText="สถานะ" SortExpression="STATUSNAME">
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="STATUS" HeaderText="STATUS">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="MATERIALMASTER" HeaderText="MATERIALMASTER">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="UNIT" HeaderText="UNIT">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRICE" HeaderText="PRICE">
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
                <asp:ObjectDataSource ID="ItemSource" runat="server" SelectMethod="GetStockOutItemList"
                    TypeName="StockOutRequestDetailItem">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="txtLOID" DefaultValue="0" Name="stockOutID" PropertyName="Text"
                            Type="Double" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
    </table>
    <uc3:MaterialUnitPopup ID="ctMaterialUnit" runat="server" OnSelectedIndexChanged="ctMaterialUnit_SelectedIndexChanged" />
    <uc4:MenuStockOutPopup ID="ctlMenuStockOut" runat="server" OnSelectedIndexChanged="ctlMenuStockOut_SelectedIndexChanged" />
</asp:Content>