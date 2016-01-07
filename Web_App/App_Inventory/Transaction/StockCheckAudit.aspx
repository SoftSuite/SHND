<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="StockCheckAudit.aspx.cs" Inherits="App_Inventory_Transaction_StockCheckAudit" Title="SHND : Transaction - Stock Check Audit" %>
<%@ Register Src="../../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc4" %>
<%@ Register Src="../../Search/MaterialMasterPopup.ascx" TagName="MaterialMasterPopup" TagPrefix="uc3" %>
<%@ Register Src="../../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="headtext">
                ตรวจสอบการนับ</td>
        </tr>
        <tr class="zHidden">
            <td>
                <uc1:ToolBarItemCtl ID="tbAdd" runat="server" ToobarTitle="เพิ่มข้อมูล"   ToolbarImage="../../Images/icn_add.png"   />
            </td>
        </tr>
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbApproveAll" runat="server" ToobarTitle="ยืนยัน"   ToolbarImage="../../Images/icn_approve.png"  OnClick ="tbApproveAll_Click" ClientClick="return confirm('ต้องการยืนยันข้อมูลตรวจนับที่เลือก ใช่หรือไม่?')" />
                <uc1:ToolBarItemCtl ID="tbCancelAll" runat="server" ToobarTitle="ยกเลิก"   ToolbarImage="../../Images/icn_cancel.png"  OnClick ="tbCancelAll_Click" ClientClick="return confirm('ต้องการยกเลิกการตรวจนับ ใช่หรือไม่?')"/>
            </td>
        </tr>
        <tr>
            <td>
                <hr style="size:1px" />
                <asp:Label ID="lbStatusMain" runat="server" EnableViewState="False"></asp:Label></td>
        </tr>
        <tr>
            <td style="height: 15px">
                <fieldset style="padding:15px;">
                    <legend style="font-weight:bold">
                        ค้นหา
                    </legend>
                    <table cellspacing="0" cellpadding="0" border="0" width="800">
                        <tr style="height:15px">
                            <td colspan="4">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="text-align: right; padding-right:10px; height: 24px; width: 120px;">
                                เลขที่ตรวจนับ :</td>
                            <td style="height: 24px; width: 140px;">
                                <asp:TextBox ID = "txtNoFrom" runat = "server" CssClass ="zTextbox" Width="125px"></asp:TextBox></td>
                            <td style="height: 24px; width: 30px;" align="center">
                                ถึง</td>
                            <td style="height: 24px">
                                <asp:TextBox ID = "txtNoTo" runat = "server" CssClass ="zTextbox" Width="125px"></asp:TextBox> </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; padding-right:10px; height: 24px; width: 120px;">
                                วันที่ตรวจนับ :</td>
                            <td style="height: 24px; width: 140px;">
                                <uc4:CalendarControl ID="ctlDateFrom" runat="server" />
                            </td>
                            <td style="height: 24px; width: 30px;" align="center">
                                ถึง</td>
                            <td style="height: 24px">
                            <uc4:CalendarControl ID="ctlDateTo" runat="server" />
                            </td>                
                        </tr>
                        <tr>
                            <td style="text-align: right; padding-right:10px; height: 24px; width: 120px;">
                                คลัง :</td>  
                            <td colspan = "3" style=" height: 24px;">
                                <asp:DropDownList ID ="cmbWarehouse" runat = "server" Width="301px" CssClass="zComboBox" ></asp:DropDownList>
                            </td>            
                        </tr>
                        <tr>
                            <td style="text-align: right; padding-right:10px; height: 24px; width: 120px;">
                                สถานะ :</td>
                            <td style="height: 24px; width: 140px;">
                                <asp:DropDownList ID ="cmbStatusFrom" runat = "server" Width="131px" CssClass="zComboBox" ></asp:DropDownList>
                            </td>
                            <td style="height: 24px; width: 30px;" align="center">
                                ถึง</td>
                            <td style="height: 24px">
                                <asp:DropDownList ID ="cmbStatusTo" runat = "server" Width="131px" CssClass="zComboBox" ></asp:DropDownList>
                                &nbsp; &nbsp; &nbsp;
                                <asp:ImageButton ID="imbSearch" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_find.png" OnClick="imbSearch_Click"/>
                                <asp:ImageButton ID="imbReset" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_back.png"
                                    OnClick="imbReset_Click" ToolTip="แสดงทั้งหมด" /></td>  
                        </tr>
                    </table>   
                </fieldset>        
            </td>
        </tr>
        <tr>
            <td style="height:15px">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <uc2:PageControl ID="pcTop" runat="server" />
                <asp:GridView ID="grvResult" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="t_tablestyle" PageSize="20" AllowPaging="True" OnSorting="grvResult_Sorting" OnRowDataBound="grvResult_RowDataBound" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="SCLOID" HeaderText="SCLOID">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <input type="checkbox" name="chkMain" id="chkMain" onclick="chkAllBox(this, 'ctl00_MainContent_grvResult_ctl', '_chkSelect')" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelect" runat="server" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="30px" />
                            <ItemStyle HorizontalAlign="Center" Width="30px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ลำดับ" SortExpression="DEFAULT">
                            <HeaderStyle Width="60px" />
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="เลขที่ตรวจนับ" SortExpression="BATCHNO" >
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkType" runat="server" OnClick="lnkType_Click" Text='<%# Bind("BATCHNO") %>' CommandArgument='<%# Bind("SCLOID")  %>'></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="120px" />
                            <ItemStyle HorizontalAlign="Center" Width="120px" Height="20px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="CHECKDATE" HeaderText="วันที่ตรวจนับ" SortExpression ="CHECKDATE" >
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundField>
                        
                        <asp:BoundField DataField="WHNAME" HeaderText="คลังที่ตรวจนับ" SortExpression ="WHNAME" >
                            <HeaderStyle HorizontalAlign="Center" Width="150px" />
                            <ItemStyle Width="150px" />
                        </asp:BoundField>
                        
                        <asp:BoundField DataField="STATUSNAME" HeaderText="สถานะ" SortExpression ="STATUSNAME" >
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle Width="100px" />
                        </asp:BoundField>
                        
                        <asp:BoundField DataField="REMARKS" HeaderText="หมายเหตุ"  SortExpression ="REMARKS" >
                        </asp:BoundField>
                    </Columns>
                    <HeaderStyle CssClass="t_headtext" />
                    <AlternatingRowStyle CssClass="t_alt_bg" />
                    <PagerSettings Visible="False" />
                </asp:GridView>
                <uc2:PageControl ID="pcBot" runat="server" />
            </td>
        </tr>
    </table>
     <cc1:ModalPopupExtender ID="StockCheckPop" runat="server" TargetControlID="tbAdd$lb" PopupControlID="Panel1" BackgroundCssClass="modalBackground" DropShadow="true"></cc1:ModalPopupExtender>
    <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" style="display:none" Width="800px">
        <table border="0" cellspacing="0" cellpadding="0" width="100%">
            <tr>
                <td>
                    <uc1:ToolBarItemCtl ID="tbSave" runat="server" ToobarTitle="บันทึก" ToolbarImage="../../Images/save2.png" OnClick= "tbSave_Click" />
                    <uc1:ToolBarItemCtl ID="tbApprove" runat ="server" ToolbarImage="../../Images/icn_approve.png" ToobarTitle ="ยืนยัน" OnClick= "tbApprove_Click" />
                    <uc1:ToolBarItemCtl ID="tbBack" runat="server" ToobarTitle="กลับหน้ารายการ" ToolbarImage="../../Images/icn_back.png" OnClick ="tbBack_Click" />
                    <uc1:ToolBarItemCtl ID="tbPrint" runat ="server" ToolbarImage="../../Images/icn_print.png" ToobarTitle ="พิมพ์" />
                </td> 
            </tr>
            <tr>
                <td><hr style="size:1px" />
                </td> 
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
                            <td style="padding:5px; border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid; width:500px" valign="top">
                                <table border="0" cellpadding="0" cellspacing="0" width="550">
                                     <tr>
                                        <td align="right" style="padding-right: 10px; width: 130px; height: 24px"  > เลขที่การตรวจนับ :</td>
                                        <td style="width: 140px; height: 24px"  >
                                            <asp:TextBox ID = "txtBatchNo" CssClass="zTextbox-View" runat ="server" Width="125px"  ></asp:TextBox>
                                            </td>
                                        <td align="right" style="padding-right: 10px; width: 100px; height: 24px"  >วันที่ตรวจนับ :</td>
                                        <td style="width: 180px; height: 24px" > <uc4:CalendarControl ID="ctlCheckDate" runat="server" Enabled="false" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="padding-right: 10px; width: 130px; height: 24px" >คลัง :</td>
                                        <td colspan="3" style="height: 24px" >
                                            <asp:DropDownList ID="cmbWarehousePop" runat="server" Width="380px"></asp:DropDownList>
                                            <span style="color: #ff0000">*</span><span style="color:red"></span></td>
                       
                                        
                                    </tr>
                                     <tr>
                                        <td align="right" style="padding-right: 10px; width: 130px; height: 24px"  >
                                            หมวดวัสดุ :</td>
                                        <td colspan="3" style="height: 24px" >
                                            <asp:DropDownList ID ="cmbMaterialClass" runat="server" Width="380px" ></asp:DropDownList>
                                            <span style="color: #ff0000">*</span><span style="color:red"></span>
                                        </td>   
                                    </tr>
                                    <tr>
                                        <td   align="right" style="padding-right: 10px; width: 130px; height: 24px">
                                            หมายเหตุ :</td>
                                        <td  colspan="3" style="height: 24px" >
                                            <asp:TextBox ID="txtRemark" runat="server" CssClass="zTextbox" MaxLength="200" Width="374px"></asp:TextBox>
                                            
                                       </td>     
                                    </tr>
                                </table>
                            </td>
                            <td style="width:4px">&nbsp;</td>
                            <td style="padding:5px; border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid;" valign="top">
                                 <table border="0" cellpadding="0" cellspacing="0" width="200px">
                                     <tr>
                                        <td  align="right" style="padding-right:10px; width:80px">สถานะ :</td>
                                        <td >
                                            <asp:TextBox ID="txtStatus" runat="server" CssClass="zTextbox-View" Width="120px" ReadOnly="true"></asp:TextBox>

                                        </td>
                                     </tr>
                                 </table>
                            </td>
                        </tr>
                    </table> 
                </td> 
            </tr> 
            <tr>
                <td>
                    <uc2:PageControl ID="pcTop1" runat="server" OnPageChange ="PopUpPageChange" />
                    <asp:GridView ID="grvItem" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="t_tablestyle" PageSize="20" AllowPaging="True" 
                         OnRowDataBound="grvItem_RowDataBound" Visible="False" Width="100%">
                        <Columns>
                            <asp:BoundField DataField="SCLOID" HeaderText="SCLOID">
                                <ControlStyle CssClass="zHidden" />
                                <FooterStyle CssClass="zHidden" />
                                <HeaderStyle CssClass="zHidden" />
                                <ItemStyle CssClass="zHidden" />
                            </asp:BoundField>
                            
                            <asp:TemplateField HeaderText="ลำดับ" >
                                <HeaderStyle Width="60px" />
                                <ItemStyle HorizontalAlign="Center" Width="60px" />
                            </asp:TemplateField>
                            
                            <asp:BoundField DataField="MMCODE" HeaderText="รหัส" >
                                <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                <ItemStyle Width="80px" />
                            </asp:BoundField>
                            
                            <asp:BoundField DataField="MMNAME" HeaderText="รายการ" >
                            </asp:BoundField>
                            
                            <asp:BoundField DataField="THNAME" HeaderText="หน่วยนับ" >
                                <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                <ItemStyle Width="80px" />
                            </asp:BoundField>
                            
                            <asp:TemplateField HeaderText="จำนวนที่นับได้">
                                <ItemTemplate>
                                   <asp:Label id="lblCountQty" runat="server"  Text='<%# Convert.ToDouble(Eval("COUNTQTY")).ToString("#,##0.00")  %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="80px"  />
                                <ItemStyle HorizontalAlign="Right" Width="80px"  />
                            </asp:TemplateField>
                            
                             <asp:TemplateField HeaderText="จำนวนคงคลัง">
                                <ItemTemplate>
                                   <asp:Label id="lblStockQty" runat="server"  Text='<%# Convert.ToDouble(Eval("STOCKQTY")).ToString("#,##0.00")  %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="80px"  />
                                <ItemStyle HorizontalAlign="Right" Width="80px"  />
                            </asp:TemplateField>
                            
                             <asp:TemplateField HeaderText="ผลต่าง">
                                <ItemTemplate>
                                   <asp:Label id="lblDiff" runat="server" ></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="100px"  />
                                <ItemStyle HorizontalAlign="Right" Width="100px"  />
                            </asp:TemplateField>
                            
                             <asp:TemplateField HeaderText="จำนวนที่ต้องการปรับยอด">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtImproveQty" runat = "server" Text='<%# Convert.ToDouble(Eval("IMPROVEQTY")).ToString("#,##0.00") %>' CssClass="zTextboxR" Width="95px"></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="100px"  />
                                <ItemStyle HorizontalAlign="Right" Width="100px"  />
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="ปรับยอด">
                                <ItemTemplate>
                                    <asp:CheckBox  ID="chkIsImprove" runat = "server" ToolTip='<% #Bind("ISIMPROVE") %>'  ></asp:CheckBox>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="60px"  />
                                <ItemStyle HorizontalAlign="Center" Width="60px"  />
                           </asp:TemplateField>
                           
                            <asp:BoundField DataField="SCILOID" HeaderText="SCILOID">
                                <ControlStyle CssClass="zHidden" />
                                <FooterStyle CssClass="zHidden" />
                                <HeaderStyle CssClass="zHidden" />
                                <ItemStyle CssClass="zHidden" />
                            </asp:BoundField>
                        </Columns>
                        <HeaderStyle CssClass="t_headtext" />
                        <AlternatingRowStyle CssClass="t_alt_bg" />
                        <PagerSettings Visible="False" />
                    </asp:GridView><uc2:PageControl ID="pcBot1" runat="server" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>


