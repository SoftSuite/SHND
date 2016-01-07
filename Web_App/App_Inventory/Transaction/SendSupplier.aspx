<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="SendSupplier.aspx.cs" Inherits="App_Inventory_Transaction_SendSupplier" Title="SHND : Transaction - Return Supplier"%>
<%@ Register Src="../../Search/SendSupplierPopup.ascx" TagName="SendSupplierPopup" TagPrefix="uc3" %>
<%@ Register Src="../../Search/SendPreOrderSupplierPopup.ascx" TagName="SendPreOrderSupplierPopup" TagPrefix="uc5" %>
<%@ Register Src="../../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc4" %>
<%@ Register Src="../../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="headtext">
                ข้อมูลการส่งคืน</td>
        </tr>
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbAdd" runat="server" ToobarTitle="เพิ่มข้อมูล"   ToolbarImage="../../Images/icn_add.png" OnClick="tbAddClick"  />
                <uc1:ToolBarItemCtl ID="ToolBarItemCtl1" runat="server" ToobarTitle="ลบข้อมูลที่เลือก" OnClick="tbDeleteClick" ToolbarImage="../../Images/icn_delete.png" ClientClick="return confirm('ต้องการลบข้อมูลที่เลือก ใช่หรือไม่?')"  />
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
            
                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                    <tr style="height:15px">
                        <td colspan="4" style="height: 15px"></td>
                    </tr>
                    <tr>
                        <td style="text-align: right; padding-right:10px; height: 24px; width: 120px;">
                            เลขที่ส่งคืน :</td>
                        <td style="height: 24px; width: 140px;">
                            <asp:TextBox ID = "txtNoFrom" runat = "server" CssClass ="zTextbox" Width="125px"></asp:TextBox></td>
                        <td style="text-align: right; padding-right:10px; height: 24px; width: 30px;">
                            ถึง</td>
                        <td style="height: 24px">
                            <asp:TextBox ID = "txtNoTo" runat = "server" CssClass ="zTextbox" Width="125px"></asp:TextBox> </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; padding-right:10px; height: 24px; width: 120px;">
                            วันที่ส่งคืน :</td>
                        <td style="height: 24px; width: 140px;">
                            <uc4:CalendarControl ID="ctlDateFrom" runat="server" />
                        </td>
                        <td style="text-align: right; padding-right:10px; height: 24px; width: 30px;">
                            ถึง</td>
                        <td style="height: 24px">
                        <uc4:CalendarControl ID="ctlDateTo" runat="server" />
                        </td>                
                    </tr>
                    <tr>
                        <td style="text-align: right; padding-right:10px; height: 24px; width: 120px;">
                            ชื่อวัสดุ :</td>  
                        <td colspan = "3" style=" height: 24px;">
                            <asp:TextBox ID = "txtName" runat="server" CssClass="zTextbox" Width="306px"></asp:TextBox>
                        </td>            
                    </tr>
                    <tr>
                        <td style="text-align: right; padding-right:10px; height: 24px; width: 120px;">
                            สถานะ :</td>
                        <td style="height: 24px; width: 140px;">
                            <asp:DropDownList ID ="cmbStatusFrom" runat = "server" Width="131px" ></asp:DropDownList>
                        </td>
                        <td style="text-align: right; padding-right:10px; height: 24px; width: 30px;">
                            ถึง</td>
                        <td style="height: 24px">
                            <asp:DropDownList ID ="cmbStatusTo" runat = "server" Width="131px" ></asp:DropDownList>
                            &nbsp; &nbsp; &nbsp;
                            <asp:ImageButton ID="imbSearch" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_find.png" OnClick="imbSearch_Click"/>
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
            <td>
                <uc2:PageControl ID="pcTop" runat="server"  OnPageChange="PageChange"/>
                <asp:GridView ID="grvResult" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="t_tablestyle" PageSize="20" AllowPaging="True" 
                    OnSorting="grvResult_Sorting" Width="100%" OnRowDataBound="grvResult_RowDataBound" >
                    <Columns>
                        <asp:BoundField DataField="SOLOID" HeaderText="SOLOID">
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
                                <asp:CheckBox ID="chkSelect" runat="server" Enabled='<%# Eval("STATUS").ToString() == "WA" %>' />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="30px" />
                            <ItemStyle HorizontalAlign="Center" Width="30px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ลำดับ" SortExpression="DEFAULT">
                            <HeaderStyle Width="60px" />
                            <ItemStyle HorizontalAlign="Center" Width="60px" Height="20px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="เลขที่ส่งคืน" SortExpression="CODE" >
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkType" runat="server" OnClick="lnkType_Click" Text='<%# Bind("CODE") %>' CommandArgument='<%# Bind("SOLOID")  %>'></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="150px" />
                            <ItemStyle HorizontalAlign="Center" Width="150px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="STOCKOUTDATE" HeaderText="วันที่ส่งคืน" SortExpression ="STOCKOUTDATE" >
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundField>
                        
                        <asp:BoundField DataField="SPNAME" HeaderText="บริษัท/ร้านค้า" SortExpression ="SPNAME" >
                        </asp:BoundField>
                        
                        <asp:BoundField DataField="STATUSNAME" HeaderText="สถานะ" SortExpression ="STATUSNAME" >
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle Width="100px" />
                        </asp:BoundField>

                    </Columns>
                    <HeaderStyle CssClass="t_headtext" />
                    <AlternatingRowStyle CssClass="t_alt_bg" />
                    <PagerSettings Visible="False" />
                </asp:GridView><uc2:PageControl ID="pcBot" runat="server" />
                </td>
        </tr>
    </table>
    <cc1:ModalPopupExtender ID="StockOutPop" runat="server" TargetControlID="tbAdd$lb" PopupControlID="Panel1" BackgroundCssClass="modalBackground" DropShadow="true"></cc1:ModalPopupExtender>
    <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" style="display:none" Width="800px">
    <table cellspacing="0" cellpadding="0" border="0" width="100%" >
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbSave" runat="server" ToobarTitle="บันทึก" ToolbarImage="../../Images/save2.png" OnClick= "tbSave_Click" />
                <uc1:ToolBarItemCtl ID ="tbCancel" runat ="server" ToobarTitle ="ยกเลิกการแก้ไข" ToolbarImage="../../Images/cancel.png" OnClick ="tbCancel_Click"/>
                <uc1:ToolBarItemCtl ID="tbApprove" runat ="server" ToolbarImage="../../Images/icn_approve.png" ToobarTitle ="อนุมัติ" OnClick= "tbApprove_Click" />
                <uc1:ToolBarItemCtl ID="tbBack" runat="server" ToobarTitle="กลับหน้ารายการ" ToolbarImage="../../Images/icn_back.png" OnClick ="tbBack_Click" />
                <uc1:ToolBarItemCtl ID="tbPrint" runat ="server" ToolbarImage="../../Images/icn_print.png" ToobarTitle ="พิมพ์" />
            </td>
        </tr>
        <tr>
            <td><hr style="size:1px" /></td>
        </tr>
        <tr>
            <td style="height:15px">
                <asp:Label ID="lbStatus" runat="server" EnableViewState="False"></asp:Label>
                <asp:TextBox ID="txtFlag" runat="server" Visible="False" Width="15px"></asp:TextBox>
                <asp:TextBox ID="txtStatusFlag" runat="server" Width="1px" Height="9px" Visible="False">WA</asp:TextBox>
                <asp:TextBox ID="txhID" runat="server" Height="9px" Visible="False" Width="1px"></asp:TextBox>
                <asp:TextBox ID="txhSortField" runat="server" Visible="False" Width="15px"></asp:TextBox>
                <asp:TextBox ID="txhSortDir" runat="server" Visible="False" Width="15px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td style="padding:5px; border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid; width:620px" valign="top">
                            <table cellpadding="0" width="600" cellspacing="0" >
                                 <tr>
                                    <td align="right" style="padding-right: 10px; width: 120px; height: 24px"  > เลขที่ส่งคืน :</td>
                                    <td style="width: 170px; height: 24px" >
                                        <asp:TextBox ID = "txtCode" CssClass="zTextbox-View" runat ="server" ReadOnly="True" Width="150px"  ></asp:TextBox>
                                    </td>
                                    <td align="right" style="padding-right: 10px; width: 70px; height: 24px"  >วันที่ส่งคืน :</td>
                                    <td style="height: 24px" > 
                                        <uc4:CalendarControl ID="ctlStockOutDate" runat="server" /> 
                                         <span style="color: #ff0000">*</span><span style="color:red"></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="padding-right: 10px; width: 120px; height: 24px" >แผนประมาณการ :</td>
                                    <td colspan="3" style="height: 24px" >
                                        <asp:DropDownList ID="cmbPlan" runat="server" Width="426px" AutoPostBack="true" OnSelectedIndexChanged="cmbPlan_SelectedIndexChanged" ></asp:DropDownList>
                                        <span style="color: #ff0000">*</span><span style="color:red"></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="padding-right: 10px; width: 120px; height: 24px" >บริษัท/ร้านค้า :</td>
                                    <td colspan="3" style="height: 24px" >
                                        <asp:DropDownList ID="cmbSupplier" runat="server" Width="426px" OnSelectedIndexChanged="cmbSupplier_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                        <span style="color: #ff0000">*</span><span style="color:red"></span>
                                    </td>
                                </tr>
                                 <tr>
                                    <td align="right" style="padding-right: 10px; width: 120px; height: 24px"  >
                                        คลังที่จ่ายออก :</td>
                                    <td colspan="3" style="height: 24px" >
                                        <asp:DropDownList ID ="cmbWarehouse" runat="server" Width="426px"  OnSelectedIndexChanged="cmbWarehouse_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                        <span style="color: #ff0000">*</span><span style="color:red"></span>
                                    </td>   
                                </tr>
                                <tr>
                                    <td   align="right" style="padding-right: 10px; width: 120px; height: 24px">
                                        เหตุที่ส่งคืน :</td>
                                    <td  colspan="3" style="height: 24px" >
                                        <asp:TextBox ID="txtRemark" runat="server" CssClass="zTextbox" MaxLength="200" Width="420px"></asp:TextBox>
                                        
                                   </td>     
                                </tr>
                            </table>
                        </td>
                        <td style="width:4px">&nbsp;
                        </td>
                        <td style="padding:5px; border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid;" valign="top">
                             <table >
                                 <tr>
                                    <td  align="right" >สถานะ :</td>
                                    <td  align="right" >
                                        <asp:TextBox ID="txtStatus" runat="server" CssClass="zTextbox-View" Width="120px"  ></asp:TextBox>
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
                <uc1:ToolBarItemCtl ID="tbAddStockOutItem" runat="server" ToobarTitle="เพิ่มรายการ" ToolbarImage="../../Images/icn_add.png" OnClick="tbAddStockOutItemClick"  />
                <uc1:ToolBarItemCtl ID="tbDeleteStockOutItem" runat="server" ToobarTitle="ลบรายการ" ToolbarImage="../../Images/icn_delete.png" OnClick ="tbDeleteStockOutItemClick"  ClientClick="return confirm('ต้องการลบข้อมูลที่เลือก ใช่หรือไม่?')"   />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbStatusFormulaSetItem" runat="server" EnableViewState="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <uc2:PageControl ID="pcTop1" runat="server" OnPageChange ="PopUpPageChange" Visible="false"/>
                <asp:GridView ID="grvItem" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="t_tablestyle" PageSize="20" AllowPaging="True" 
                    OnRowDataBound="grvItem_RowDataBound" Visible="False" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="SOILOID" HeaderText="SOILOID">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:TemplateField >
                            <HeaderTemplate>
                               <asp:CheckBox ID="chkAll" runat="server" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelect" runat ="server" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign = "Center" Width ="60px" />
                            <HeaderStyle HorizontalAlign = "Center"  Width="60px" />
                            <FooterStyle HorizontalAlign = "Center" Width ="60px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ลำดับ" >
                            <HeaderStyle Width="60px" />
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="MMCODE" HeaderText="รหัส" >
                            <HeaderStyle HorizontalAlign="Center" Width="60px" />
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </asp:BoundField>
                        
                        <asp:BoundField DataField="MMNAME" HeaderText="รายการ" >
                        </asp:BoundField>
                        
                        <asp:BoundField DataField="UNAME" HeaderText="หน่วยนับ" >
                            <HeaderStyle HorizontalAlign="Center" Width="60px" />
                            <ItemStyle Width="60px" />
                        </asp:BoundField>
                        
                       <asp:TemplateField HeaderText="จำนวนที่คืน">
                            <ItemTemplate>
                                <asp:TextBox ID="txtQty" runat = "server" Text='<% #Bind("QTY") %>' CssClass="zTextboxR" Width="65px"></asp:TextBox>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="70px"  />
                            <ItemStyle HorizontalAlign="Center" Width="70px"  />
                       </asp:TemplateField>
                        <asp:TemplateField HeaderText="หมายเหตุ">
                            <ItemTemplate>
                                <asp:TextBox ID="txtRemarks" runat = "server" Text='<% #Bind("REMARKS") %>' CssClass="zTextbox" MaxLength="200" Width="195px"></asp:TextBox>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="200px"  />
                            <ItemStyle HorizontalAlign="left" Width="200px"   />
                       </asp:TemplateField>
                        <asp:BoundField DataField="SOLOID" HeaderText="SOLOID">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                         <asp:BoundField DataField="MMLOID" HeaderText="MMLOID">
                           <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />

                        </asp:BoundField>
                        
                        <asp:BoundField DataField="UULOID" HeaderText="UULOID">
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
                <uc2:PageControl ID="pcBot1" runat="server" Visible="false" />
                <uc3:SendSupplierPopup ID="ctlSendSupplierPopup" runat="server" OnSelectedIndexChanged ="ctlSendSupplierPopup_SelectedIndexChanged" OnCancel ="ctlSendSupplierPopup_Cancel" OnSearchClick="ctlSendSupplierPopup_SearchClick" OnResetClick="ctlSendSupplierPopup_ResetClick"  />
                <uc5:SendPreOrderSupplierPopup ID="ctlSendPreOrderSupplierPopup" runat="server" OnSelectedIndexChanged ="ctlSendPreOrderSupplierPopup_SelectedIndexChanged" OnCancel ="ctlSendPreOrderSupplierPopup_Cancel" OnSearchClick="ctlSendPreOrderSupplierPopup_SearchClick" OnResetClick ="ctlSendPreOrderSupplierPopup_ResetClick" />
            </td>
        </tr>
    </table>
    </asp:Panel>
</asp:Content>

