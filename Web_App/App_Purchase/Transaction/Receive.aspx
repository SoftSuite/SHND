<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="Receive.aspx.cs" Inherits="App_Purchase_Transaction_Receive" Title="SHND : Transaction - Receive" %>
<%@ Register Src="../../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../../Search/ReceivePopup.ascx" TagName="ReceivePopup" TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="headtext">
                ตรวจรับวัสดุอาหาร</td>
        </tr>
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbSave" runat="server" ToobarTitle="บันทึก" ToolbarImage="../../Images/save2.png" OnClick="tbSaveClick"/>
                <uc1:ToolBarItemCtl ID="tbCancel" runat="server" ToobarTitle="ยกเลิกการแก้ไข" ToolbarImage="../../Images/cancel.png" />
                <uc1:ToolBarItemCtl ID="tbApprove" runat="server" ToobarTitle="อนุมัติ" ToolbarImage="../../Images/icn_approve.png" OnClick="tbApproveClick"/>
                <uc1:ToolBarItemCtl ID="tbBack" runat="server" ToobarTitle="กลับหน้ารายการ" ToolbarImage="../../Images/icn_back.png" OnClick="tbBackClick"/>
                <uc1:ToolBarItemCtl ID="tbPrint" runat="server" ToobarTitle="พิมพ์" ToolbarImage="../../Images/icn_print.png" OnClick="tbPrintClick" />
            </td>
        </tr>
        <tr>
            <td><hr style="size:1px" /></td>
        </tr>
        <tr>
            <td style="height:15px">
                <asp:Label ID="lbStatus" runat="server" EnableViewState="False"></asp:Label>
                <asp:TextBox ID="txtLOID" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
                <asp:TextBox ID="txtDivision" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
                <asp:TextBox ID="txtStatus" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
                <asp:TextBox ID="txtMaterialClass" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr style="height:24px">
                        <td style="padding:5px; border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid; width:500px" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" width="500">
                                <tr style="height:24px">
                                    <td style="width:130px; padding-right:10px; text-align:right">
                                        แผนประมาณการ :</td>
                                    <td colspan="3">
                                        <asp:DropDownList ID="cmbOrederPlan" runat="server" CssClass="zComboBox" Width="345px" AutoPostBack="True" OnSelectedIndexChanged="cmbOrederPlan_SelectedIndexChanged">
                                        </asp:DropDownList>&nbsp;<span class="zRemark">*</span></td>
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 130px; height: 24px; text-align: right">
                                        หมวดอาหาร :</td>
                                    <td colspan="3" style="height: 24px">
                                            <asp:DropDownList ID="cmbMaterialClass" runat="server" CssClass="zComboBox" Width="345px" AutoPostBack="True" OnSelectedIndexChanged="cmbMaterialClass_SelectedIndexChanged">
                                            </asp:DropDownList>&nbsp;<span class="zRemark">*</span></td>
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 130px; height: 24px; text-align: right">
                                        ผู้จำหน่าย :</td>
                                    <td colspan="3" style="height: 24px"><asp:TextBox ID="txtSupplierName" runat="server" CssClass="zTextbox-View" ReadOnly="True" Width="240px">
                                    </asp:TextBox>
                                        <asp:TextBox ID="txtSupplierCode" runat="server" CssClass="zTextbox-View" ReadOnly="True" Width="89px"></asp:TextBox></td>
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 130px; text-align: right">
                                        เบอร์โทร :</td>
                                    <td style="width: 150px"><asp:TextBox ID="txtTel" runat="server" CssClass="zTextbox-View" ReadOnly="True" MaxLength="100" Width="120px"></asp:TextBox></td>
                                    <td style="padding-right: 10px; text-align:right; width: 60px">
                                        แฟกซ์ :</td>
                                    <td><asp:TextBox ID="txtFax" runat="server" CssClass="zTextbox-View" ReadOnly="True" MaxLength="100" Width="120px"></asp:TextBox></td>
                                </tr>
                            </table>
                        </td>
                        <td style="width:4px">&nbsp;</td>
                        <td style="border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid;" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td style="border-bottom: 1px solid; padding:5px;">
                                        <table border="0" cellpadding="0" cellspacing="0" width="450px">

                                            <tr style="height:24px">
                                                <td style="width:70px; padding-right:10px; text-align:right">
                                                    วันที่ตรวจรับ :
                                                </td> 
                                                <td>
                                                    <uc2:CalendarControl ID="ctlReceiveDate" Enabled="false" runat="server" />&nbsp;<span class="zRemark">*</span>
                                                </td> 
                                            </tr>

                                        </table>
                                    </td> 
                                </tr>
                                <tr>
                                    <td style="padding:5px;">
                                        <table border="0" cellpadding="0" cellspacing="0" width="450px">
                                            <tr style="height:24px">
                                                <td style="width:70px; padding-right:10px; text-align:right">สถานะ :
                                                </td> 
                                                <td>
                                                    <asp:TextBox ID="txtStatusName" runat="server" CssClass="zTextbox-View" ReadOnly="True" Width="100px"></asp:TextBox>
                                                </td> 
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
            <td class="toolbarplace">
           <uc1:ToolBarItemCtl ID="tbAddReceiveItem" runat="server" ToobarTitle="เพิ่มรายการ" ToolbarImage="../../Images/icn_add.png" OnClick="tbAddReceiveItemClick" />
           <uc1:ToolBarItemCtl ID="tbDeleteReceiveItem" runat="server" ToobarTitle="ลบรายการ" ClientClick="return confirm('ต้องการลบข้อมูลที่เลือก ใช่หรือไม่?')" ToolbarImage="../../Images/icn_delete.png" OnClick="tbDeleteReceiveItemClick" />

            </td>
        </tr>
 <tr>
                                    <td>
                                        <asp:Label ID="lbStatusPOItem" runat="server" EnableViewState="False"></asp:Label></td> 
                                </tr> 

                                <tr>
                                    <td>
                                        <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="False" CssClass="t_tablestyle" DataSourceID="ReceiveSource" OnRowDataBound="gvItem_RowDataBound" Width="100%" >
                                            <PagerSettings Visible="False" />
                                            <Columns>
<asp:BoundField DataField="RANK" HeaderText="RANK">
<ControlStyle CssClass="zHidden"></ControlStyle>
<ItemStyle CssClass="zHidden"></ItemStyle>
<HeaderStyle CssClass="zHidden"></HeaderStyle>
<FooterStyle CssClass="zHidden"></FooterStyle>
</asp:BoundField>

<asp:BoundField DataField="LOID" HeaderText="LOID">
<ControlStyle CssClass="zHidden"></ControlStyle>
<ItemStyle CssClass="zHidden"></ItemStyle>
<HeaderStyle CssClass="zHidden"></HeaderStyle>
<FooterStyle CssClass="zHidden"></FooterStyle>
</asp:BoundField>

<asp:TemplateField>
<HeaderTemplate>
<input type="checkbox" name="chkMain" id="chkMain" onclick="chkAllBox(this, 'ctl00_MainContent_tabStdMenu_tabStdMenuDisease_gvStdMenuDisease_ctl', '_chkSelect')" />                                                                                                    
</HeaderTemplate>
<ItemStyle Width="30px" HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
<HeaderStyle Width="30px" HorizontalAlign="Center"></HeaderStyle>
<ItemTemplate>
<asp:CheckBox ID="chkSelect" runat="server" />                                                                                                  
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="ลำดับ">
<ItemStyle Width="60px" Height="20px" HorizontalAlign="Center"></ItemStyle>
<HeaderStyle Width="60px"></HeaderStyle>
<ItemTemplate>
<%# Container.DataItemIndex + 1%>                                                 
</ItemTemplate>
</asp:TemplateField>
                        <asp:TemplateField SortExpression="SAPCODE" HeaderText="รหัส SAP">
                            <ItemStyle Width="80px" HorizontalAlign="Center"></ItemStyle>
                            <HeaderStyle Width="80px" HorizontalAlign="Center"></HeaderStyle>
                            <ItemTemplate>
                            <asp:LinkButton ID="lnkCode" runat="server" Text='<%# Bind("SAPCODE") %>' CommandArgument='<%# Bind("SAPCODE")  %>'  OnClick="linkCode_Click"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
<asp:BoundField DataField="MATERIALNAME" HeaderText="รายการ">
</asp:BoundField>

<asp:BoundField DataField="UNITNAME" HeaderText="หน่วยนับ">
 <ItemStyle Width="60px" />
 <HeaderStyle HorizontalAlign="Center" Width="60px" />
</asp:BoundField>

<asp:BoundField DataField="PRICE" HeaderText="ราคา/หน่วย" HtmlEncode="false" DataFormatString="{0:#,##0.00}">
 <ItemStyle HorizontalAlign="Right" Width="80px" />
 <HeaderStyle HorizontalAlign="Center" Width="80px" />
</asp:BoundField>

<asp:BoundField DataField="ORDERQTY" HeaderText="จำนวนสั่งซื้อ" HtmlEncode="false" DataFormatString="{0:#,##0.00}">
 <ItemStyle HorizontalAlign="Right" Width="80px" />
 <HeaderStyle HorizontalAlign="Center" Width="80px" />
</asp:BoundField>

<asp:BoundField DataField="DUEQTY" HeaderText="กำหนดส่ง" HtmlEncode="false" DataFormatString="{0:#,##0.00}">
 <ItemStyle HorizontalAlign="Right" Width="70px" />
 <HeaderStyle HorizontalAlign="Center" Width="70px" />
</asp:BoundField>

<asp:TemplateField HeaderText="จำนวนตรวจรับ">
<ItemStyle Width="80px" Height="24px" HorizontalAlign="Center"></ItemStyle>
<HeaderStyle Width="80px"></HeaderStyle>
<ItemTemplate>
<asp:TextBox ID="txtReceiveQty" Width="75px" CssClass="zTextboxR" runat="server" Text='<%# Convert.IsDBNull(Eval("RECEIVEQTY")) ? "0.00" : Convert.ToDouble(Eval("RECEIVEQTY")).ToString("#,##0.00") %>' OnTextChanged="txtReceiveQty_TextChanged" AutoPostBack="true"></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="ยอดรวม">
<ItemStyle Width="80px" Height="24px" HorizontalAlign="Center"></ItemStyle>
<HeaderStyle Width="80px"></HeaderStyle>
<ItemTemplate>
<asp:TextBox ID="txtNetPrice" Width="75px" CssClass="zTextboxR-View"  ReadOnly="True" runat="server" Text='<%# Convert.IsDBNull(Eval("NETPRICE")) ? "0.00" : Convert.ToDouble(Eval("NETPRICE")).ToString("#,##0.00") %>'></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>

                        <asp:BoundField DataField="PLANREMAINQTY" HeaderText="PLANREMAINQTY" HtmlEncode="false" DataFormatString="{0:#,##0.00}">
<ControlStyle CssClass="zHidden"></ControlStyle>
<ItemStyle CssClass="zHidden"></ItemStyle>
<HeaderStyle CssClass="zHidden"></HeaderStyle>
<FooterStyle CssClass="zHidden"></FooterStyle>
</asp:BoundField>
                        
                        <asp:TemplateField HeaderText="V">
                        <ItemTemplate>
                        <asp:Checkbox ID="chkVat" runat="server" Checked='<%# Eval("ISVAT").ToString() =="Y" %>' Enabled="false" />
                        </ItemTemplate>
                        <HeaderStyle Width="30px" />
                        <ItemStyle HorizontalAlign="Center" Width="30px" />
                        </asp:TemplateField>

<asp:TemplateField HeaderText="หมายเหตุ">
<ItemStyle Width="150px" Height="24px" HorizontalAlign="Center"></ItemStyle>
<HeaderStyle Width="150px"></HeaderStyle>
<ItemTemplate>
<asp:TextBox ID="txtRemark" Width="145px" CssClass="zTextbox" runat="server" MaxLength="200" Text=<%# DataBinder.Eval(Container.DataItem, "REMARKS") %>></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>

<asp:BoundField DataField="MATERIALMASTER" HeaderText="MATERIALMASTER">
<ControlStyle CssClass="zHidden"></ControlStyle>
<ItemStyle CssClass="zHidden"></ItemStyle>
<HeaderStyle CssClass="zHidden"></HeaderStyle>
<FooterStyle CssClass="zHidden"></FooterStyle>
</asp:BoundField>

<asp:BoundField DataField="UNITLOID" HeaderText="UNITLOID">
<ControlStyle CssClass="zHidden"></ControlStyle>
<ItemStyle CssClass="zHidden"></ItemStyle>
<HeaderStyle CssClass="zHidden"></HeaderStyle>
<FooterStyle CssClass="zHidden"></FooterStyle>
</asp:BoundField>

<asp:BoundField DataField="CODE" HeaderText="CODE">
<ControlStyle CssClass="zHidden"></ControlStyle>
<ItemStyle CssClass="zHidden"></ItemStyle>
<HeaderStyle CssClass="zHidden"></HeaderStyle>
<FooterStyle CssClass="zHidden"></FooterStyle>
</asp:BoundField>

<asp:BoundField DataField="SPEC" HeaderText="SPEC">
<ControlStyle CssClass="zHidden"></ControlStyle>
<ItemStyle CssClass="zHidden"></ItemStyle>
<HeaderStyle CssClass="zHidden"></HeaderStyle>
<FooterStyle CssClass="zHidden"></FooterStyle>
</asp:BoundField>

<asp:BoundField DataField="PREPODUEDATE" HeaderText="PREPODUEDATE">
<ControlStyle CssClass="zHidden"></ControlStyle>
<ItemStyle CssClass="zHidden"></ItemStyle>
<HeaderStyle CssClass="zHidden"></HeaderStyle>
<FooterStyle CssClass="zHidden"></FooterStyle>
</asp:BoundField>

<asp:BoundField HtmlEncode="False" DataFormatString="{0:dd/MM/yyyy}" DataField="DUEDATE" HeaderText="วันที่กำหนดส่ง">
<ItemStyle Width="100px" HorizontalAlign="Center"></ItemStyle>
<HeaderStyle Width="100px" HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>

<asp:BoundField HtmlEncode="False" DataFormatString="{0:dd/MM/yyyy}" DataField="USEDATE" HeaderText="วันที่ใช้">
<ItemStyle Width="100px" HorizontalAlign="Center"></ItemStyle>
<HeaderStyle Width="100px" HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>

</Columns>
<HeaderStyle CssClass="t_headtext" />
<AlternatingRowStyle CssClass="t_alt_bg" />
                                        </asp:GridView>
                                        <asp:ObjectDataSource ID="ReceiveSource" runat="server" SelectMethod="GetReceivetemList" TypeName="ReceiveItem">
                                            <SelectParameters>
<asp:ControlParameter PropertyName="Text" Type="Double" DefaultValue="0" Name="Receive" ControlID="txtLOID"></asp:ControlParameter>
</SelectParameters>
                                        </asp:ObjectDataSource>
                                    </td> 
                                </tr>
        <tr>
            <td style="height: 5px">
            </td>
        </tr>
        <tr>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr style="height:24px">
                        <td style="padding:5px; border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid; width:500px" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" width="500">
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 130px; height: 24px; text-align: right" valign="top">
                                        <table border="0" cellspacing="0" cellpadding="0" width="100px">
                                            <tr>
                                                <td style="height:24px">หมายเหตุ :
                                                </td>
                                            </tr>
                                        </table> 
                                    </td>
                                    <td style="height: 24px;">
                                        <asp:TextBox ID="txtRemark" runat="server" CssClass="zTextbox" Height="60px" MaxLength="200" TextMode="MultiLine" Width="339px"></asp:TextBox></td>
                                </tr>
                            </table> 
                        </td>
                        <td style="width:4px">&nbsp;</td>
                        <td style="border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid; padding-right: 5px; padding-left: 5px; padding-bottom: 5px; padding-top: 5px;" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" width="370px">
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 180px; text-align: right">ยอดเงินรวม :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtTotal" runat="server" CssClass="zTextboxR-View" ReadOnly="True" Width="100px"></asp:TextBox>&nbsp;บาท 
                                    </td>
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 180px; text-align: right">ยอดเงินประมาณการคงเหลือ :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRemain" runat="server" CssClass="zTextboxR-View" ReadOnly="True" Width="100px"></asp:TextBox>&nbsp;บาท 
                                    </td>
                                </tr>
                            </table> 
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
        <uc3:ReceivePopup id="ctlReceivePopup" runat="server" OnSelectedIndexChanged="ctlReceivePopup_SelectedIndexChanged" />
        <asp:TextBox ID="txtRowIndex" runat="server" Visible="false"></asp:TextBox><cc1:ModalPopupExtender ID="ctlSpecPopup"  runat="server" PopupControlID="pnlSpec" BackgroundCssClass="modalBackground" DropShadow="true" TargetControlID="btnTest"></cc1:ModalPopupExtender>
    <asp:Panel ID="pnlSpec" runat="server" CssClass="modalPopup" style="display:none" >
        <table border="0" cellspacing="0" cellpadding="0" width="500">
            <tr>
                <td class="subheadertext">
                    <asp:Label ID="lblMaterialName" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <uc1:ToolBarItemCtl ID="tbBackSpec" runat="server" ToobarTitle="กลับหน้ารายการ" ToolbarImage="../../Images/icn_back.png" />
                </td>
            </tr>
            <tr>
                <td><hr style="size:1px"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtSpec" runat="server" TextMode="MultiLine" Width="500px" Height="80px" MaxLength="200" CssClass="zTextbox-View"  ReadOnly="true"></asp:TextBox>
                </td> 
            </tr>
        </table>
    </asp:Panel>
    <asp:Button ID="btntest" runat="server" Text="test" CssClass="zHidden" />
        <cc1:ModalPopupExtender ID="ctlDetailPopup"  runat="server" PopupControlID="pnlDetail" BackgroundCssClass="modalBackground" DropShadow="true" TargetControlID="btnTest1"></cc1:ModalPopupExtender>
    <asp:Panel ID="pnlDetail" runat="server" CssClass="modalPopup" style="display:none" >
        <table border="0" cellspacing="0" cellpadding="0" width="400">
            <tr>
                <td class="subheadertext">
                    <asp:Label ID="lblMaterialNameDetail" runat="server" Text=""></asp:Label>
                </td>
                <td class="subheadertext" align="right">
                    สั่งซื้อ : <asp:Label ID="lblMaterialQty" runat="server" Text=""> &nbsp;&nbsp;&nbsp;</asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:TextBox ID="txtMaterialID" runat="server" Visible="false"></asp:TextBox>
                    <asp:TextBox ID="txtIsUpdated" runat="server" Visible="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2"><hr style="size:1px"/>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lbStatusDelivery" runat="server" EnableViewState="False"></asp:Label>
                </td> 
            </tr>
            <tr>
                <td colspan="2">
                    <asp:TextBox ID="txtSpecView" runat="server" TextMode="MultiLine" Width="400px" Height="80px" MaxLength="200" CssClass="zTextbox-View" ReadOnly="true"></asp:TextBox>
                </td> 
            </tr>
            <tr>
                <td colspan="2">

                   </td>
            </tr> 
        </table>
    </asp:Panel>
    <asp:Button ID="btntest1" runat="server" Text="test" CssClass="zHidden" />
</asp:Content>