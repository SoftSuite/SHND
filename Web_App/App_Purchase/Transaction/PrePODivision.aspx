<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="PrePODivision.aspx.cs" Inherits="App_Purchase_Transaction_PrePO" Title="SHND : Transaction - Pre Purchase Order (Division)" %>
<%@ Register Src="../../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../../Search/PrePOPopup.ascx" TagName="PrePOPopup" TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="headtext">
                ใบสั่งซื้อล่วงหน้าสำหรับหน่วยงาน</td>
        </tr>
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbSave" runat="server" ToobarTitle="บันทึก" ToolbarImage="../../Images/save2.png" OnClick="tbSaveClick"/>
                <uc1:ToolBarItemCtl ID="tbCancel" runat="server" ToobarTitle="ยกเลิกการแก้ไข" ToolbarImage="../../Images/cancel.png" />
                <uc1:ToolBarItemCtl ID="tbApprove" runat="server" ToobarTitle="อนุมัติ" ToolbarImage="../../Images/icn_approve.png" OnClick="tbApproveClick"/>
                <uc1:ToolBarItemCtl ID="tbBack" runat="server" ToobarTitle="กลับหน้ารายการ" ToolbarImage="../../Images/icn_back.png" OnClick="tbBackClick"/>
                <uc1:ToolBarItemCtl ID="tbPrint" runat="server" ToobarTitle="พิมพ์" ToolbarImage="../../Images/icn_print.png" />
            </td>
        </tr>
        <tr>
            <td style="height:30px">
                <hr style="size:1px" />
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
                                    <td colspan="3" style="height: 24px">
                                        <asp:DropDownList ID="cmbOrederPlan" runat="server" CssClass="zComboBox" Width="340px" AutoPostBack="True" OnSelectedIndexChanged="cmbOrederPlan_SelectedIndexChanged">
                                        </asp:DropDownList>&nbsp;<span class="zRemark">*</span></td>
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 130px; height: 24px; text-align: right">
                                        หมวดอาหาร :</td>
                                    <td colspan="3" style="height: 24px">
                                            <asp:DropDownList ID="cmbMaterialClass" runat="server" CssClass="zComboBox" Width="340px" AutoPostBack="True" OnSelectedIndexChanged="cmbMaterialClass_SelectedIndexChanged">
                                            </asp:DropDownList>&nbsp;<span class="zRemark">*</span></td>
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 130px; height: 24px; text-align: right">
                                        ผู้จำหน่าย :</td>
                                    <td colspan="3" style="height: 24px"><asp:TextBox ID="txtSupplierName" runat="server" CssClass="zTextbox-View" ReadOnly="True" Width="240px">
                                    </asp:TextBox>
                                        <asp:TextBox ID="txtSupplierCode" runat="server" CssClass="zTextbox-View" ReadOnly="True" Width="84px"></asp:TextBox></td>
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 130px; height: 24px; text-align: right">
                                        หน่วยงาน :</td>
                                    <td colspan="3" style="height: 24px">
                                        <asp:TextBox ID="txtDivisionName" runat="server" CssClass="zTextbox-View" ReadOnly="True" MaxLength="100" Width="334px"></asp:TextBox></td>
                                </tr>
                            </table>
                        </td>
                        <td style="width:4px">&nbsp;</td>
                        <td style="border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid; width:230px" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td style="border-bottom: 1px solid; padding:5px;">
                                        <table border="0" cellpadding="0" cellspacing="0" width="230px">
                                            <tr style="height:24px">
                                                <td style="width:70px; padding-right:10px; text-align:right">เลขที่ :
                                                </td> 
                                                <td>
                                                    <asp:TextBox ID="txtCode" runat="server" CssClass="zTextbox-View" ReadOnly="True" Width="100px"></asp:TextBox>
                                                </td> 
                                            </tr>
                                            <tr style="height:24px">
                                                <td style="width:70px; padding-right:10px; text-align:right">วันที่สั่งซื้อ :
                                                </td> 
                                                <td>
                                                    <uc2:CalendarControl ID="ctlOrderDate" Enabled="false" runat="server" />&nbsp;<span class="zRemark">*</span>
                                                </td> 
                                            </tr>
                                            <tr style="height:24px">
                                                <td style="width:70px; padding-right:10px; text-align:right">วันที่ใช้ :
                                                </td> 
                                                <td>
                                                    <uc2:CalendarControl ID="ctlUseDate" runat="server" AutoPostBack="true" OnSelectedDateChanged="ctlUseDate_SelectedDateChanged" />&nbsp;<span class="zRemark">*</span>
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
                        <td style="width:4px">&nbsp;</td>
                        <td style="border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid;" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" width="300">
                                <tr>
                                    <td class="subheadertext">เมนูล่วงหน้า
                                    </td> 
                                </tr>
                                <tr>
                                    <td style="height:24px; padding-top:2px; padding-left:2px">
                                                <asp:GridView ID="gvMenu" runat="server" AutoGenerateColumns="False" CssClass="t_tablestyle" DataSourceID="MenuSource" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="MENUNAME" HeaderText= "ชื่อเมนู" ReadOnly="True">              
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PORTIONMENU" HeaderText= "จำนวนเมนู" ReadOnly="True">
                                    <ItemStyle Width="60px" Height="24px" HorizontalAlign="Center"></ItemStyle>
                                    <HeaderStyle Width="60px"></HeaderStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PORTIONNOW" HeaderText= "จำนวนคนปัจจุบัน" ReadOnly="True">
                                    <ItemStyle Width="60px" Height="24px" HorizontalAlign="Center"></ItemStyle>
                                    <HeaderStyle Width="60px"></HeaderStyle>
                                    </asp:BoundField>
                                </Columns>
                                <HeaderStyle CssClass="t_headtext" />
                                <AlternatingRowStyle CssClass="t_alt_bg" />
                                <PagerSettings Visible="False" />
                            </asp:GridView>
                            <asp:ObjectDataSource ID="MenuSource" runat="server" SelectMethod="GetOrderMenuList"
                                TypeName="PrePODivisionItem">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ctlUseDate" Name="usedate" PropertyName="DateValue"
                                        Type="DateTime" />
                                    <asp:ControlParameter ControlID="txtDivision" Name="division" PropertyName="Text"
                                        Type="double" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
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
           <uc1:ToolBarItemCtl ID="tbAddPOItem" runat="server" ToobarTitle="เพิ่มรายการ" ToolbarImage="../../Images/icn_add.png" OnClick="tbAddPOItemClick" />
           <uc1:ToolBarItemCtl ID="tbDeletePOItem" runat="server" ToobarTitle="ลบรายการ" ToolbarImage="../../Images/icn_delete.png" ClientClick="return confirm('ต้องการลบข้อมูลที่เลือก ใช่หรือไม่?')" OnClick="tbDeletePOItemClick" />
           <uc1:ToolBarItemCtl ID="tbCalculate" runat="server" ToobarTitle="คำนวณจากเมนู" ToolbarImage="../../Images/icn_calculate.png" OnClick="tbCalculateClick" />

            </td>
        </tr>
 <tr>
                                    <td>
                                        <asp:Label ID="lbStatusPOItem" runat="server" EnableViewState="False"></asp:Label></td> 
                                </tr> 

                                <tr>
                                    <td>
                                        <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="False" CssClass="t_tablestyle" DataSourceID="PrePODivisionSource" OnRowDataBound="gvItem_RowDataBound" Width="100%" >
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
 <ItemStyle HorizontalAlign="Center" Width="80px" />
 <HeaderStyle HorizontalAlign="Center" Width="80px" />
</asp:BoundField>

<asp:BoundField DataField="PRICE" HeaderText="ราคา/หน่วย" HtmlEncode="false" DataFormatString="{0:#,##0.00}">
 <ItemStyle HorizontalAlign="Right" Width="80px" />
 <HeaderStyle HorizontalAlign="Center" Width="80px" />
</asp:BoundField>

<asp:BoundField DataField="MENUQTY" HeaderText="จำนวนเมนู" HtmlEncode="false" DataFormatString="{0:#,##0.00}">
 <ItemStyle HorizontalAlign="Right" Width="60px" />
 <HeaderStyle HorizontalAlign="Center" Width="60px" />
</asp:BoundField>

<asp:TemplateField HeaderText="จำนวนสั่งซื้อ">
<ItemStyle Width="80px" Height="24px" HorizontalAlign="Center"></ItemStyle>
<HeaderStyle Width="80px"></HeaderStyle>
<ItemTemplate>
<asp:TextBox ID="txtOrderQty" Width="75px" CssClass="zTextboxR" runat="server" Text='<%# Convert.IsDBNull(Eval("ORDERQTY")) ? "0.00" : Convert.ToDouble(Eval("ORDERQTY")).ToString("#,##0.00") %>' OnTextChanged="txtOrderQty_TextChanged" AutoPostBack="true"></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>

<asp:BoundField DataField="PLANREMAINQTY" HeaderText="จำนวนคงเหลือ" HtmlEncode="false" DataFormatString="{0:#,##0.00}">
 <ItemStyle HorizontalAlign="Right" Width="80px" />
 <HeaderStyle HorizontalAlign="Center" Width="80px" />
</asp:BoundField>

<asp:TemplateField HeaderText="จำนวนเงิน">
<ItemStyle Width="60px" Height="24px" HorizontalAlign="Center"></ItemStyle>
<HeaderStyle Width="60px"></HeaderStyle>
<ItemTemplate>
<asp:TextBox ID="txtNetPrice" Width="55px" CssClass="zTextboxR-View"  ReadOnly="True" runat="server" Text='<%# Convert.IsDBNull(Eval("NETPRICE")) ? "0.00" : Convert.ToDouble(Eval("NETPRICE")).ToString("#,##0.00") %>'></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>
                        <asp:BoundField DataField="MATERIALMASTER" HeaderText="MATERIALMASTER">
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
<asp:TextBox ID="txtRemark" Width="145px" CssClass="zTextbox" runat="server" MaxLength="200" Text='<%# DataBinder.Eval(Container.DataItem, "REMARKS") %>'></asp:TextBox>
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

</Columns>
<HeaderStyle CssClass="t_headtext" />
<AlternatingRowStyle CssClass="t_alt_bg" />
                                        </asp:GridView>
                                        <asp:ObjectDataSource ID="PrePODivisionSource" runat="server" SelectMethod="GetPrePODivisiontemList" TypeName="PrePODivisionItem">
                                            <SelectParameters>
<asp:ControlParameter PropertyName="Text" Type="Double" DefaultValue="0" Name="PrePO" ControlID="txtLOID"></asp:ControlParameter>
</SelectParameters>
                                        </asp:ObjectDataSource>
                                    </td> 
                                </tr>
        <tr>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr style="height:24px">
                        <td style="padding:5px; border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid; width:500px" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" width="500">
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 131px; height: 24px; text-align: right" valign="top" align="right">
                                        <table border="0" cellspacing="0" cellpadding="0" width="100px">
                                            <tr>
                                                <td style="height:24px">หมายเหตุ :
                                                </td>
                                            </tr>
                                        </table> 
                                    </td>
                                    <td style="height: 24px;">
                                        <asp:TextBox ID="txtRemark" runat="server" CssClass="zTextbox" Height="60px" MaxLength="200" TextMode="MultiLine" Width="334px"></asp:TextBox></td>
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
        <uc3:PrePOPopup id="ctlPrePOPopup" runat="server" OnSelectedIndexChanged="ctlPrePOPopup_SelectedIndexChanged" />
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
                    <uc1:ToolBarItemCtl ID="tbBackDetail" runat="server" ToobarTitle="กลับหน้ารายการ" ToolbarImage="../../Images/icn_back.png" OnClick="tbBackDetailClick" />
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
                    <asp:GridView ID="gvDetail" runat="server" AutoGenerateColumns="False" CssClass="t_tablestyle" DataSourceID="DeliverySource" DataKeyNames="RANK" OnRowCommand="gvDetail_RowCommand" OnRowUpdated="gvDetail_RowUpdated" OnRowUpdating="gvDetail_RowUpdating" OnRowDataBound="gvDetail_RowDataBound" OnRowDeleted="gvDetail_RowDeleted" ShowFooter="True" Width="100%">
                        <Columns>
                            <asp:BoundField DataField="PREPOITEM" HeaderText="PREPOITEM">
                                <ControlStyle CssClass="zHidden" />
                                <FooterStyle CssClass="zHidden" />
                                <HeaderStyle CssClass="zHidden" />
                                <ItemStyle CssClass="zHidden" />
                            </asp:BoundField>
                            <asp:TemplateField ShowHeader="False">
                                <EditItemTemplate>
                                    <asp:ImageButton id="imbSave" runat="server" ImageUrl="~/Images/save2.jpg" ToolTip="บันทึก" CommandName="Update" CausesValidation="True"></asp:ImageButton> 
                                    <asp:ImageButton id="imbCancel" runat="server" ImageUrl="~/Images/icn_back.png" ToolTip="ยกเลิก" CommandName="Cancel" CausesValidation="False"></asp:ImageButton> 
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:ImageButton id="imbAdd" runat="server" ImageUrl="~/Images/save2.jpg" ToolTip="เพิ่มรายการใหม่" CommandName="Insert" CausesValidation="True"></asp:ImageButton> 
                                </FooterTemplate>
                                <ItemStyle Width="60px" HorizontalAlign="Center"></ItemStyle>
                                <HeaderStyle Width="60px" HorizontalAlign="Center"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:ImageButton id="imbEdit" runat="server" ImageUrl="~/Images/icn_edit.png" ToolTip="แก้ไข" CommandName="Edit" CausesValidation="False"></asp:ImageButton> 
                                    <asp:ImageButton id="imbDelete" runat="server" ImageUrl="~/Images/icn_delete.png" ToolTip="ลบ" CommandName="Delete" CausesValidation="False"></asp:ImageButton> 
                                </ItemTemplate>
                                <FooterStyle Width="60px" HorizontalAlign="Center"></FooterStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ลำดับ">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex +1 %>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <%# Container.DataItemIndex +1 %>
                                </EditItemTemplate>
                                <HeaderStyle Width="60px" />
                                <ItemStyle HorizontalAlign="Center" Width="60px" Height="20px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="กำหนดส่ง">
                                <EditItemTemplate>
                                    <uc2:CalendarControl id="ctlEditDate"   DateValue='<%# Bind("DUEDATE") %>' runat="server"></uc2:CalendarControl> 
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <uc2:CalendarControl id="ctlNewDate" runat="server"></uc2:CalendarControl> 
                                </FooterTemplate>
                                <ItemTemplate>
                                    <uc2:CalendarControl id="ctlItemDate" DateValue='<%# Bind("DUEDATE") %>' Enabled="false" runat="server"></uc2:CalendarControl> 
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="จำนวน">
                                <ItemTemplate>
                                    <asp:Label ID="lblDueQty" runat="server" Text='<%# Convert.ToDouble(Eval("DUEQTY")).ToString("#,##0.00")  %>' ></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEditQty" runat="server" Width="95px" Text='<%# Convert.ToDouble(Eval("DUEQTY")).ToString("#,##0.00")  %>' 
                                        CssClass="zTextboxR" onkeypress="ChkDbl(this)" onblur="valDbl(this)" onfocus="prepareNum(this)" ></asp:TextBox> 
                                </EditItemTemplate> 
                                <FooterTemplate>
                                     <asp:TextBox ID="txtNewQty" runat="server" Width="95px" Text="" 
                                        CssClass="zTextboxR" onkeypress="ChkDbl(this)" onblur="valDbl(this)" onfocus="prepareNum(this)" ></asp:TextBox> 
                                </FooterTemplate>
                                <ItemStyle Width="100px" HorizontalAlign="Center"></ItemStyle>
                                <HeaderStyle Width="100px" HorizontalAlign="Center"></HeaderStyle>
                                <FooterStyle Width="100px" HorizontalAlign="Center"></FooterStyle> 
                            </asp:TemplateField>
                            <asp:BoundField DataField="CODE" HeaderText="CODE">
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
                            <asp:BoundField DataField="RANK" HeaderText="RANK">
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
                    <asp:ObjectDataSource ID="DeliverySource" runat="server" SelectMethod="GetMaterialDeliveryLIst" TypeName="PrePODivisionItem" UpdateMethod="UpdateMaterialDelivery"  DeleteMethod="DeleteMaterialDelivery" >
                        <SelectParameters>
                            <asp:ControlParameter ControlID="txtLOID" DefaultValue="0" Name="PrePO" PropertyName="Text" Type="Double" />
                            <asp:ControlParameter ControlID="txtMaterialID" DefaultValue="0" Name="CODE" PropertyName="Text" Type="String" />
                        </SelectParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="PrePO" Type="Double" />
                            <asp:Parameter Name="DUEDATE" Type="DateTime" />
                            <asp:Parameter Name="DUEQTY" Type="Double" />
                            <asp:Parameter Name="CODE" Type="String" />
                            <asp:Parameter Name="LOID" Type="Double" />
                            <asp:Parameter Name="RANK" Type="Double" />
                        </UpdateParameters>
                        <deleteparameters>
                            <asp:Parameter Type="Double" Name="RANK"></asp:Parameter>
                        </deleteparameters>
                    </asp:ObjectDataSource>
                    <asp:GridView id="grvItemNew" runat="server" AutoGenerateColumns="False"
                     CssClass="t_tablestyle" DataKeyNames="LOID" DataSourceID="NewItemDataSource"
                     EmptyDataText="<center>***ไม่พบข้อมูล***</center>" OnRowCommand="grvItemNew_RowCommand"
                     OnRowDataBound="grvItemNew_RowDataBound" Width="100%" >
                    <pagersettings visible="False"></pagersettings>
                    <emptydatarowstyle borderwidth="0px"/>
                        <columns>
                           <asp:TemplateField ShowHeader="False">
                                <HeaderStyle Width="60px" HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle Width="60px" HorizontalAlign="Center"/>
                                <ItemTemplate>
                                    <asp:ImageButton id="imbSave" runat="server" ImageUrl="~/Images/save2.gif" ToolTip="เพิ่มรายการใหม่" CommandName="Insert" CausesValidation="True"></asp:ImageButton> 
                                </ItemTemplate>
                           </asp:TemplateField>
                           <asp:TemplateField HeaderText="ลำดับ" InsertVisible="False">
                                 <HeaderStyle Width="60px" HorizontalAlign="Center"></HeaderStyle>
                                 <ItemStyle Width="60px" HorizontalAlign="Center"/>
                                 <ItemTemplate>
                                    <asp:Label ID="lblNo" runat="server" Text=""></asp:Label>
                                 </ItemTemplate>
                           </asp:TemplateField>
                           <asp:TemplateField HeaderText="กำหนดส่ง">
                                 <ItemTemplate>
                                    <uc2:CalendarControl id="ctlDate" runat="server" ></uc2:CalendarControl>
                                 </ItemTemplate>
                           </asp:TemplateField>
                           <asp:TemplateField HeaderText="จำนวน">
                                 <HeaderStyle Width="100px" HorizontalAlign="Center"></HeaderStyle>
                                 <ItemStyle Width="100px" HorizontalAlign="Center"/>
                                 <ItemTemplate>
                                    <asp:TextBox id="txtQty" CssClass="zTextboxR" Width="95px" onkeypress="ChkDbl(this)" onblur="valDbl(this)" onfocus="prepareNum(this)" runat="server" ></asp:TextBox>
                                 </ItemTemplate>
                          </asp:TemplateField>
                       </columns>
                      <headerstyle cssclass="t_headtext" />
                     <alternatingrowstyle cssclass="t_alt_bg" />
                  </asp:GridView><asp:ObjectDataSource id="NewItemDataSource" runat="server" OldValuesParameterFormatString="{0}"
                                            SelectMethod="GetMaterialDeliveryBlank" TypeName="PrePODivisionItem"> </asp:ObjectDataSource></td>
            </tr> 
        </table>
    </asp:Panel>
    <asp:Button ID="btntest1" runat="server" Text="test" CssClass="zHidden" />
</asp:Content>