<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="Repair.aspx.cs" Inherits="App_Inventory_Transaction_Repair" Title="SHND : Transaction - Repair" %>
<%@ Register Src="../../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="headtext">
                ข้อมูลการส่งซ่อม</td>
        </tr>
        <tr>
            <td style="height: 20px">
                <uc1:ToolBarItemCtl ID="tbSave" runat="server" ToobarTitle="บันทึก" ToolbarImage="../../Images/save2.png" OnClick="tbSaveClick" />
                <uc1:ToolBarItemCtl ID="tbCancel" runat="server" ToobarTitle="ยกเลิกการแก้ไข" ToolbarImage="../../Images/cancel.png" OnClick="tbCancelClick" />
                <uc1:ToolBarItemCtl ID="tbApprove" runat="server" ToobarTitle="ส่งซ่อม" ToolbarImage="../../Images/icn_approve.png" OnClick="tbApproveClick" />
                <uc1:ToolBarItemCtl ID="tbReceive" runat="server" OnClick="tbReceiveClick" ToobarTitle="ตรวจรับงานซ่อม"  ToolbarImage="../../Images/icn_add.png" />
                <uc1:ToolBarItemCtl ID="tbBack" runat="server" ToobarTitle="กลับหน้ารายการ" ToolbarImage="../../Images/icn_back.png" OnClick="tbBackClick"/>
                <uc1:ToolBarItemCtl ID="tbPrint" runat="server" ToobarTitle="พิมพ์รายงาน" ToolbarImage="../../Images/icn_print.png" OnClick="tbPrintClick"/>
            </td>
        </tr>
        <tr>
            <td style="height:30px" valign="top">
                <hr style="size:1px" />
                <asp:Label ID="lbStatus" runat="server" EnableViewState="False"></asp:Label>
                <asp:TextBox ID="txtLOID" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
                <asp:TextBox ID="txtStatus" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
                <asp:TextBox ID="txtStockoutItemLoid" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
                <asp:TextBox id="txtMaterialLoid" runat="server" Width="48px" Visible="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td style="padding:5px; border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid; width:670px" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" width="650">
                                <tr style="height:24px">
                                    <td style="width:120px; text-align:right; padding-right:10px">
                                        เลขที่ส่งซ่อม :</td> 
                                    <td style="width:200px">
                                        <asp:TextBox ID="txtCode" runat="server" CssClass="zTextbox-View" MaxLength="20"
                                            Width="150px" ReadOnly="True"></asp:TextBox></td>  
                                    <td style="width: 130px; padding-right: 10px;" align="right">
                                        วันที่ส่งซ่อม :</td>
                                    <td style="width: 200px">
                                        <uc2:CalendarControl id="ctlSentDate" runat="server">
                                        </uc2:CalendarControl></td>
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 120px; text-align: right">
                                        คลัง :</td>
                                    <td style="width: 200px">
                                        <asp:DropDownList ID="cmbWarehouse" runat="server" CssClass="zComboBox" Width="156px">
                                        </asp:DropDownList></td>
                                    <td style="width: 130px; padding-right: 10px;" align="right">
                                        หน่วยที่แจ้งซ่อม :</td>
                                    <td style="width: 200px">
                                        <asp:DropDownList ID="cmbDev" runat="server" CssClass="zComboBox" Width="156px">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 120px; text-align: right">
                                        ความเร่งด่วน :</td>
                                     <td style="width: 200px; height: 24px;">
                                        <asp:RadioButton ID="rdbNormal" runat="server" Checked="True" Text="ปกติ" Enabled="False" />
                                        <asp:RadioButton
                                            ID="rdbSpeed" runat="server" Text="เร่งด่วน" Enabled="False" />
                                        <asp:RadioButton ID="rdbEmergency"
                                                runat="server" Text="ฉุกเฉิน" Enabled="False" />
                                    </td>
                                    <td style="width: 130px; padding-right: 10px; height: 24px;" align="right">
                                        ชื่อผู้แจ้งซ่อม :</td>
                                    <td style="width: 200px; height: 24px;">
                                        <asp:TextBox ID="txtName" runat="server" CssClass="zTextbox-View" MaxLength="20"
                                            Width="150px" ReadOnly="True"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="height: 10px;" align="right">
                                    </td>
                                </tr>
                                <tr style="height:24px">
                                    <td style="width:120px; text-align:right; padding-right:10px; height: 24px;">
                                        รหัสวัสดุ :</td>
                                    <td style="height: 24px;" colspan="3">
                                        <asp:TextBox ID="txtMCode" runat="server" CssClass="zTextbox-View" MaxLength="20"
                                            Width="150px" ReadOnly="True"></asp:TextBox>
                                        <asp:TextBox ID="txtMName" runat="server" CssClass="zTextbox-View" MaxLength="20"
                                            Width="319px" ReadOnly="True"></asp:TextBox></td>
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 120px; text-align: right">
                                        รหัสครุภัณฑ์ :</td>
                                    <td colspan="2">
                                        <asp:TextBox ID="txtLotNo" runat="server" CssClass="zTextbox-View" MaxLength="20"
                                            Width="150px" ReadOnly="True"></asp:TextBox>จำนวน<asp:TextBox ID="txtNo" runat="server" CssClass="zTextbox-View" MaxLength="20" Width="48px" ReadOnly="True"></asp:TextBox><asp:Label id="lblUnitName" runat="server"></asp:Label></td>
                                    <td style="width: 200px">
                                        ชั้นที่ &nbsp;
                                        <asp:TextBox id="txtFloor" runat="server" Width="35px" CssClass="zTextbox-View" ReadOnly="True"></asp:TextBox></td>
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 120px; text-align: right">
                                        รุ่น/ยี่ห้อ :</td>
                                    <td style="width: 200px">
                                        <asp:TextBox ID="txtType" runat="server" CssClass="zTextbox-View" MaxLength="20"
                                            Width="150px" ReadOnly="True"></asp:TextBox></td>
                                    <td style="width: 130px">
                                        <asp:TextBox id="txtUnit" runat="server" CssClass="zTextbox" MaxLength="20"
                                            Width="13px" Visible="False"></asp:TextBox></td>
                                    <td style="width: 200px">
                                    </td>
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 120px; text-align: right">
                                        รายละเอียด :</td>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtDetail" runat="server" CssClass="zTextbox-View" Height="59px"
                                            MaxLength="20" TextMode="MultiLine" Width="481px" ReadOnly="True"></asp:TextBox></td>
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 120px; text-align: right">
                                        ช่างผู้รับผิดชอบ :</td>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtRepairBy" runat="server" CssClass="zTextbox" MaxLength="20"
                                            Width="481px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="height: 10px">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" class="subheadertext">
                                        รายละเอียดการซ่อม</td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:GridView id="grvItem" runat="server" AutoGenerateColumns="False" CssClass="t_tablestyle"
                                            DataKeyNames="LOID" DataSourceID="ItemDataSource"
                                            OnRowCommand="grvItem_RowCommand" OnRowDataBound="grvItem_RowDataBound" OnRowDeleted="grvItem_RowDeleted"
                                            OnRowUpdated="grvItem_RowUpdated" OnRowUpdating="grvItem_RowUpdating" ShowFooter="True" Width="650px">
                                            <pagersettings visible="False"></pagersettings>
                                            <columns>
                                            <asp:TemplateField ShowHeader="False">
                                                <EditItemTemplate>
                                                    <asp:ImageButton id="imbSave" runat="server" ImageUrl="~/Images/save2.jpg" ToolTip="บันทึก" CommandName="Update" CausesValidation="True"></asp:ImageButton> <asp:ImageButton id="imbCancel" runat="server" ImageUrl="~/Images/icn_back.png" ToolTip="ยกเลิก" CommandName="Cancel" CausesValidation="False"></asp:ImageButton> 
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:ImageButton id="imbAdd" runat="server" ImageUrl="~/Images/save2.jpg" ToolTip="เพิ่มรายการใหม่" CommandName="Insert" CausesValidation="True"></asp:ImageButton> 
                                                </FooterTemplate>
                                                <ItemTemplate>
                                                    <asp:ImageButton id="imbEdit" runat="server" ImageUrl="~/Images/icn_edit.png" ToolTip="แก้ไข" CommandName="Edit" CausesValidation="False"></asp:ImageButton> <asp:ImageButton id="imbDelete" runat="server" ImageUrl="~/Images/icn_delete.png" ToolTip="ลบ" CommandName="Delete" CausesValidation="False"></asp:ImageButton> 
                                                </ItemTemplate>
                                                <ItemStyle Width="60px" HorizontalAlign="Center"></ItemStyle>
                                                <HeaderStyle Width="60px" HorizontalAlign="Center"></HeaderStyle>
                                                <FooterStyle Width="60px" HorizontalAlign="Center"></FooterStyle>
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField HeaderText="ลำดับ" InsertVisible="False">
                                                <ItemStyle Width="60px" HorizontalAlign="Center"></ItemStyle>
                                                <HeaderStyle Width="60px"></HeaderStyle>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblNo" runat="server" Text='<%# Bind("RANK") %>'></asp:Label>       
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField HeaderText="วันที่">
                                                <EditItemTemplate>
                                                    <uc2:CalendarControl id="ctlEditDate"   DateValue='<%# Bind("REPAIRDATE") %>' runat="server" ></uc2:CalendarControl>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <uc2:CalendarControl id="ctlNewDate1" runat="server" ></uc2:CalendarControl> 
                                                </FooterTemplate>
                                                <ItemTemplate >
                                                    <uc2:CalendarControl id="ctlItemDate" DateValue='<%# Bind("REPAIRDATE") %>' runat="server"></uc2:CalendarControl> 
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField HeaderText="รายละเอียด">
                                                <EditItemTemplate>
                                                    <asp:TextBox id="txtDetailEdit" runat="server" Text='<%# Bind("DESCRIPTION") %>' Width="375px" ></asp:TextBox> 
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox id="txtDetailNew" runat="server" Width="375px" ></asp:TextBox> 
                                                </FooterTemplate>
                                                <ItemTemplate>
                                                    <asp:TextBox id="txtDetail" runat="server" CssClass="zTextbox-View" Text='<%# Bind("DESCRIPTION") %>' Width="375px" ReadOnly="True" ></asp:TextBox> 
                                                </ItemTemplate>
                                                <ItemStyle Width="380px"></ItemStyle>
                                                <HeaderStyle Width="380px"></HeaderStyle>
                                            </asp:TemplateField>
                                        
                                            <asp:BoundField DataField="LOID">
                                                <ControlStyle CssClass="zHidden"></ControlStyle>
                                                <ItemStyle CssClass="zHidden"></ItemStyle>
                                                <HeaderStyle CssClass="zHidden"></HeaderStyle>
                                                <FooterStyle CssClass="zHidden"></FooterStyle>
                                            </asp:BoundField>
                                            
                                            <asp:BoundField DataField="RANK">
                                                <ControlStyle CssClass="zHidden"></ControlStyle>
                                                <ItemStyle CssClass="zHidden"></ItemStyle>
                                                <HeaderStyle CssClass="zHidden"></HeaderStyle>
                                                <FooterStyle CssClass="zHidden"></FooterStyle>
                                            </asp:BoundField>
                                                 
                                            </columns>
                                            <headerstyle cssclass="t_headtext" />
                                            <alternatingrowstyle cssclass="t_alt_bg" />
                                        </asp:GridView>
                                        <asp:ObjectDataSource id="ItemDataSource" runat="server" DeleteMethod="DeleteRepairItem" SelectMethod="GetRepairItem" TypeName="RepairItem"
                                                UpdateMethod="UpdateRepairItem">
                                            <deleteparameters>
                                                <asp:Parameter Type="Double" Name="LOID"></asp:Parameter>
                                            </deleteparameters>
                                            <updateparameters>
                                                <asp:Parameter Type="Decimal" Name="LOID"></asp:Parameter>
                                                <asp:Parameter Type="Decimal" Name="RANK"></asp:Parameter>
                                                <asp:Parameter Type="DateTime" Name="REPAIRDATE"></asp:Parameter>
                                                <asp:Parameter Type="String" Name="DESCRIPTION"></asp:Parameter>
                                            </updateparameters>
                                            <selectparameters>
                                                <asp:ControlParameter PropertyName="Text" Type="Double" Name="LOID" ControlID="txtLOID"></asp:ControlParameter>
                                            </selectparameters>
                                        </asp:ObjectDataSource>
                                        <asp:GridView id="grvItemNew" runat="server" AutoGenerateColumns="False" CssClass="t_tablestyle" DataKeyNames="LOID" DataSourceID="NewItemDataSource"
                                            OnRowCommand="grvItemNew_RowCommand" OnRowDataBound="grvItemNew_RowDataBound" Width="650px">
                                            <pagersettings visible="False"></pagersettings>
                                            <columns>
                                                <asp:TemplateField ShowHeader="False">
                                                    <HeaderStyle Width="60px" HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center" /> 
                                                    <ItemTemplate>
                                                        <asp:ImageButton id="imbSave" runat="server" ImageUrl="~/Images/save2.gif" ToolTip="เพิ่มรายการใหม่" CommandName="Insert" CausesValidation="True"></asp:ImageButton> 
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                
                                                <asp:TemplateField HeaderText="ลำดับ" InsertVisible="False">
                                                    <HeaderStyle Width="60px" HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblNo" runat="server" Text=""></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                
                                                <asp:TemplateField HeaderText="วันที่">
                                                    <ItemTemplate>
                                                        <uc2:CalendarControl id="ctlNewDate" runat="server" ></uc2:CalendarControl>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                
                                                <asp:TemplateField HeaderText="รายละเอียด">
                                                    <HeaderStyle Width="380px"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <asp:TextBox id="txtNewDetail" runat="server" Width="375px" ></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                
                                                <asp:BoundField DataField="LOID">
                                                    <ControlStyle CssClass="zHidden"></ControlStyle>
                                                    <ItemStyle CssClass="zHidden"></ItemStyle>
                                                    <HeaderStyle CssClass="zHidden"></HeaderStyle>
                                                    <FooterStyle CssClass="zHidden"></FooterStyle>
                                                </asp:BoundField>
                                            </columns>
                                            <headerstyle cssclass="t_headtext" />
                                            <alternatingrowstyle cssclass="t_alt_bg" />
                                        </asp:GridView>
                                        <asp:ObjectDataSource id="NewItemDataSource" runat="server" OldValuesParameterFormatString="{0}"
                                                SelectMethod="GetRepairItemBlank" TypeName="RepairItem"> </asp:ObjectDataSource>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width:4px">
                            &nbsp;</td>
                        <td style="border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid; padding:5px" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" width="200px">
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 70px; text-align: right; height: 24px;">
                                        สถานะ :</td>
                                    <td style="height: 24px">
                                        <asp:TextBox ID="txtStatusName" runat="server" CssClass="zTextbox-View" MaxLength="20" Width="120px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 70px; height: 24px; text-align: right">
                                    </td>
                                    <td style="height: 24px">
                                    </td>
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 70px; height: 24px; text-align: right">
                                        ผลการซ่อม :</td>
                                    <td style="height: 24px">
                                        <asp:RadioButton id="rdbRepairY" runat="server" Text="ซ่อมได้" AutoPostBack="True" OnCheckedChanged="rdbRepairY_CheckedChanged"></asp:RadioButton></td>
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 70px; height: 24px; text-align: right">
                                    </td>
                                    <td style="height: 24px">
                                        <asp:RadioButton id="rdbRepairN" runat="server" Text="ซ่อมไม่ได้" AutoPostBack="True" OnCheckedChanged="rdbRepairN_CheckedChanged">
                                        </asp:RadioButton></td>
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 70px; height: 24px; text-align: right">
                                    </td>
                                    <td style="height: 24px">
                                    </td>
                                </tr>
                                <tr style="height: 24px">
                                    <td colspan="2" style="width: 70px; height: 24px">
                                        หมายเหตุ</td>
                                </tr>
                                <tr style="height: 24px">
                                    <td colspan="2" style="width: 70px; height: 24px">
                                        <asp:TextBox id="txtRemarks" runat="server" Height="57px" TextMode="MultiLine" Width="200px"></asp:TextBox></td>
                                </tr>
                            </table>
                        </td>
                    </tr> 
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
