<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="PO.aspx.cs" Inherits="App_Purchase_Transaction_PO" Title="SHND : Transaction - Purchase Order" %>
<%@ Register Src="../../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../../Search/POPopup.ascx" TagName="POPopup" TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="headtext">
                ใบสั่งซื้อ (PO)</td>
        </tr>
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbSave" runat="server" ToobarTitle="บันทึก" ToolbarImage="../../Images/save2.png" OnClick="tbSaveClick"/>
                <uc1:ToolBarItemCtl ID="tbCancel" runat="server" ToobarTitle="ยกเลิกการแก้ไข" ToolbarImage="../../Images/cancel.png" OnClick="tbCancelClick" />
                <uc1:ToolBarItemCtl ID="tbBack" runat="server" ToobarTitle="กลับหน้ารายการ" ToolbarImage="../../Images/icn_back.png" OnClick="tbBackClick"/>
                <uc1:ToolBarItemCtl ID="tbApprove" runat="server" ToobarTitle="อนุมัติ" ToolbarImage="../../Images/icn_approve.png" OnClick="tbApproveClick"/>
                <uc1:ToolBarItemCtl ID="tbReceive" runat="server" ToobarTitle="รับเข้า" ToolbarImage="../../Images/icn_approve.png" OnClick="tbReceiveClick"/>
                <uc1:ToolBarItemCtl ID="tbPrint" runat="server" ToobarTitle="พิมพ์" ToolbarImage="../../Images/icn_print.png" OnClick="tbPrintClick"/>

            </td>
        </tr>
        <tr>
            <td><hr style="size:1px" /></td>
        </tr>
        <tr>
            <td style="height:15px">
                <asp:Label ID="lbStatus" runat="server" EnableViewState="False"></asp:Label>
                <asp:TextBox ID="txtLOID" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
                <asp:TextBox ID="txtPrePO" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
                <asp:TextBox ID="txtStatus" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
                <asp:TextBox ID="txtMaterialClass" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
                <asp:TextBox ID="txtSupplier" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
                <asp:TextBox ID="txtIsVat" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
                </td></tr>
        <tr>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr style="height:24px">
                        <td style="padding:5px; border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid; width:500px" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" width="500">
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 130px; height: 24px; text-align: right">
                                        ใบสั่งซื้อล่วงหน้า :</td>
                                    <td colspan="3" style="height: 24px">
                                            <asp:TextBox ID="txtPrePOCode" runat="server" CssClass="zTextbox-View" ReadOnly="True" Width="120px"></asp:TextBox>&nbsp;
                                        <asp:ImageButton ID="imbSearch" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_find.png"
                                            OnClick="imbSearch_Click" />&nbsp; &nbsp;<asp:TextBox ID="txtClassName" runat="server" CssClass="zTextbox-View" ReadOnly="True" Width="160px"></asp:TextBox></td>
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 130px; height: 24px; text-align: right">
                                        ผู้จำหน่าย :</td>
                                    <td colspan="3" style="height: 24px"><asp:TextBox ID="txtSupplierName" runat="server" CssClass="zTextbox-View" ReadOnly="True" Width="240px">
                                    </asp:TextBox>
                                        <asp:TextBox ID="txtSupplierCode" runat="server" CssClass="zTextbox-View" ReadOnly="True" Width="80px"></asp:TextBox></td>
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 130px; height: 24px; text-align: right">
                                        ชื่อผู้ติดต่อ :</td>
                                    <td colspan="3" style="height: 24px">
                                        <asp:TextBox ID="txtContract" runat="server" CssClass="zTextbox" MaxLength="100" Width="330px"></asp:TextBox></td>
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 130px; height: 24px; text-align: right" valign="top">
                                    ที่อยู่ :</td>
                                    <td colspan="3" style="height: 24px">
                                        <asp:TextBox ID="txtAddress" runat="server" CssClass="zTextbox" MaxLength="100" Width="330px" TextMode="MultiLine" Height="50px"></asp:TextBox></td>
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 130px; text-align: right">
                                        เบอร์โทร :</td>
                                    <td style="width: 150px"><asp:TextBox ID="txtTel" runat="server" CssClass="zTextbox" MaxLength="100" Width="110px"></asp:TextBox></td>
                                    <td style="padding-right: 10px; text-align:right; width: 60px">
                                        แฟกซ์ :</td>
                                    <td><asp:TextBox ID="txtFax" runat="server" CssClass="zTextbox" MaxLength="100" Width="110px"></asp:TextBox></td>
                                </tr>
                            </table>
                        </td>
                        <td style="width:4px">&nbsp;</td>
                        <td style="border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid;" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td style="border-bottom: 1px solid; padding:5px;">
                                        <table border="0" cellpadding="0" cellspacing="0" width="230px">
                                            <tr style="height:24px">
                                                <td style="width:70px; padding-right:10px; text-align:right">เลขที่ PO :
                                                </td> 
                                                <td>
                                                    <asp:TextBox ID="txtCode" runat="server" CssClass="zTextbox-View" ReadOnly="True" Width="100px"></asp:TextBox>
                                                </td> 
                                            </tr>
                                            <tr style="height:24px">
                                                <td style="width:70px; padding-right:10px; text-align:right">
                                                    วันที่ PO :
                                                </td> 
                                                <td>
                                                    <uc2:CalendarControl ID="ctlPODate" Enabled="false" runat="server" />&nbsp;<span class="zRemark">*</span>
                                                </td> 
                                            </tr>
                                            <tr style="height:24px">
                                                <td style="width:70px; padding-right:10px; text-align:right">เลขที่อ้างอิง :
                                                </td> 
                                                <td>
                                                    <asp:TextBox ID="txtRefPOCode" runat="server" CssClass="zTextbox-View" ReadOnly="True" Width="100px"></asp:TextBox>
                                                </td> 
                                            </tr>

                                        </table>
                                    </td> 
                                </tr>
                                <tr>
                                    <td style="padding:5px;">
                                        <table border="0" cellpadding="0" cellspacing="0" width="230px">
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
                                    <td style="height: 5px">
                                        <asp:Label ID="lbStatusPOItem" runat="server" EnableViewState="False"></asp:Label></td> 
                                </tr> 

                                <tr>
                                    <td>
                                        <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="False" CssClass="t_tablestyle" Width="100%">
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

<asp:TemplateField HeaderText="ลำดับ">
<ItemStyle Width="60px" Height="24px" HorizontalAlign="Center"></ItemStyle>
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
 <ItemStyle HorizontalAlign="Center" Width="60px" />
 <HeaderStyle HorizontalAlign="Center" Width="60px" />
</asp:BoundField>

<asp:BoundField DataField="PRICE" HeaderText="ราคา/หน่วย" HtmlEncode="false" DataFormatString="{0:#,##0.00}">
 <ItemStyle HorizontalAlign="Right" Width="80px" />
 <HeaderStyle HorizontalAlign="Center" Width="80px" />
</asp:BoundField>

<asp:BoundField DataField="RECEIVEQTY" HeaderText="จำนวน" HtmlEncode="false" DataFormatString="{0:#,##0.00}">
 <ItemStyle HorizontalAlign="Right" Width="60px" />
 <HeaderStyle HorizontalAlign="Center" Width="60px" />
</asp:BoundField>

<asp:BoundField DataField="PLANREMAINQTY" HeaderText="คงเหลือ" HtmlEncode="false" DataFormatString="{0:#,##0.00}">
 <ItemStyle HorizontalAlign="Right" Width="60px" />
 <HeaderStyle HorizontalAlign="Center" Width="60px" />
</asp:BoundField>

<asp:BoundField DataField="NETPRICE" HeaderText="จำนวนเงิน" HtmlEncode="false" DataFormatString="{0:#,##0.00}">
 <ItemStyle HorizontalAlign="Right" Width="80px" />
 <HeaderStyle HorizontalAlign="Center" Width="80px" />
</asp:BoundField>

<asp:TemplateField HeaderText="หมายเหตุ">
<ItemStyle Width="150px" Height="24px" HorizontalAlign="Center"></ItemStyle>
<HeaderStyle Width="150px"></HeaderStyle>
<ItemTemplate>
<asp:TextBox ID="txtRemark" Width="145px" CssClass="zTextbox" MaxLength="200" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "REMARKS") %>'></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>

<asp:BoundField DataField="MATERIALMASTER" HeaderText="MATERIALMASTER">
<ControlStyle CssClass="zHidden"></ControlStyle>
<ItemStyle CssClass="zHidden"></ItemStyle>
<HeaderStyle CssClass="zHidden"></HeaderStyle>
<FooterStyle CssClass="zHidden"></FooterStyle>
</asp:BoundField>

<asp:BoundField DataField="USEQTY" HeaderText="USEQTY">
<ControlStyle CssClass="zHidden"></ControlStyle>
<ItemStyle CssClass="zHidden"></ItemStyle>
<HeaderStyle CssClass="zHidden"></HeaderStyle>
<FooterStyle CssClass="zHidden"></FooterStyle>
</asp:BoundField>

<asp:BoundField DataField="UNIT" HeaderText="UNIT">
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

</Columns>
<HeaderStyle CssClass="t_headtext" />
<AlternatingRowStyle CssClass="t_alt_bg" />
                                        </asp:GridView>

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
                                    <td>
                                        <asp:TextBox ID="txtRemark" runat="server" CssClass="zTextbox" Height="60px" MaxLength="200" TextMode="MultiLine" Width="330px"></asp:TextBox></td>
                                </tr>
                            </table> 
                        </td>
                        <td style="width:4px">&nbsp;</td>
                        <td style="border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid; padding-right: 5px; padding-left: 5px; padding-bottom: 5px; padding-top: 5px;" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" width="370px">
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 200px; text-align: right">ยอดเงินรวม :
                                    </td>
                                    <td style="width:170px">
                                        <asp:TextBox ID="txtTotal" runat="server" CssClass="zTextboxR-View" ReadOnly="True" Width="100px"></asp:TextBox>&nbsp;บาท 
                                    </td>
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 200px; text-align: right">VAT
                                        &nbsp;<asp:CheckBox ID="chkVat" runat="server" Enabled="false" />&nbsp;
                                        <asp:TextBox ID="txtVat" runat="server" CssClass="zTextbox" ReadOnly="True" Width="20px"></asp:TextBox>&nbsp;% :
                                    </td>
                                    <td style="width:170px">
                                        <asp:TextBox ID="txtTotalVat" runat="server" CssClass="zTextboxR-View" ReadOnly="True" Width="100px"></asp:TextBox>&nbsp;บาท 
                                    </td>
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 200px; text-align: right">ยอดสุทธิ :
                                    </td>
                                    <td style="width:170px">
                                        <asp:TextBox ID="txtGrandTotal" runat="server" CssClass="zTextboxR-View" ReadOnly="True" Width="100px"></asp:TextBox>&nbsp;บาท 
                                    </td>
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 200px; text-align: right">ยอดเงินประมาณการคงเหลือ :
                                    </td>
                                    <td style="width:170px">
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
        <uc3:POPopup id="ctlPOPopup" OnSelectedIndexChanged="ctlPOPopup_SelectedIndexChanged" runat="server" />
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