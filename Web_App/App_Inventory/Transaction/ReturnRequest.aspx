<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="ReturnRequest.aspx.cs" Inherits="App_Inventory_Transaction_ReturnRequest" Title="SHND : Transaction - Return Requisition" %>

<%@ Register Src="../../Search/MaterialReturnRequestPopup.ascx" TagName="MaterialReturnRequestPopup" TagPrefix="uc4" %>
<%@ Register Src="../../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc3" %>
<%@ Register Src="../../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="headtext">
                ข้อมูลการคืนคลัง</td>
        </tr>
        <tr>
             <td>
                <uc1:ToolBarItemCtl ID="tbCommit" runat="server" ToobarTitle="บันทึก"  ToolbarImage="../../Images/save2.png" Onclick="tbSaveClick" />
                <uc1:ToolBarItemCtl ID="tbCancel" runat="server" ToobarTitle="ยกเลิกการแก้ไข"  ToolbarImage="../../Images/cancel.png" OnClick ="tbCancelClick" />
                <uc1:ToolBarItemCtl ID="tbSend" runat="server" ToobarTitle="ส่งข้อมูล"  ToolbarImage="../../Images/icn_approve.png" Onclick="tbSendClick" />
                <uc1:ToolBarItemCtl ID="tbBack" runat="server" ToobarTitle="กลับหน้ารายการ"  ToolbarImage="../../Images/icn_back.png" OnClick ="tbBackClick" />
                <uc1:ToolBarItemCtl ID="tbPrint" runat="server" ToobarTitle="พิมพ์"  ToolbarImage="../../Images/icn_print.png" />
            </td>
        </tr>
        <tr>
            <td>
                <hr size="1" />
            </td>
        </tr>
        <tr>
            <td style="height:15px">
                <asp:Label ID="lbStatus" runat="server" EnableViewState="False"></asp:Label>
                <asp:TextBox ID="txhSortField" runat="server" Visible="False" Width="15px"></asp:TextBox>
                <asp:TextBox ID="txhSortDir" runat="server" Visible="False" Width="15px"></asp:TextBox>
                <asp:TextBox ID="txhID" runat="server" Visible="False" Width="15px"></asp:TextBox>
                <asp:TextBox  ID="txtStatus" runat="server" Visible="False" Width="15px"></asp:TextBox>
                <asp:TextBox ID="txhDocType" runat="server" Visible="False" Width="15px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 15px">
                     <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td style="padding:5px; border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid; width:620px;" valign="top">
                                <table border="0" cellpadding="0" cellspacing="0" width="600">
                                    <tr style="height:24px">
                                        <td style="width:130px; text-align: right; padding-right:10px">เลขที่คืน :&nbsp;</td>
                                        <td style="width:170px;"><asp:TextBox ID="txtCODE" runat="server" CssClass="zTextbox-View" Width="150px" MaxLength="20" Readonly="True" ></asp:TextBox>
                                        </td>
                                        <td style="width:131px; text-align: right; padding-right:10px">วันที่คืน :</td>
                                        <td><uc3:CalendarControl ID="ctlReturnDate" runat="server"  />
                                            &nbsp;<span style="color:red">*</span>
                                        </td> 
                                    </tr>
                                    <tr style="height:24px">
                                        <td style="width:130px; text-align: right; padding-right:10px; height: 23px;">คลังที่รับเข้า :&nbsp;</td>
                                        <td style="width:170px; height: 23px;">
                                            <asp:DropDownList ID="cmbWareHouse" runat="server" CssClass="zComboBox" Width="156px" AutoPostBack="True" ></asp:DropDownList>
                                            <span style="color:red">*</span>
                                        </td>
                                         <td style="width:131px; text-align: right; padding-right:10px; height: 23px;">หน่วยที่คืนคลัง :&nbsp;</td>
                                        <td style="width:170px; height: 23px;">
                                            <asp:DropDownList ID="cmbDiv" runat="server" CssClass="zComboBox" Width="156px" AutoPostBack="True" Enabled ="false"  ></asp:DropDownList>
                                            <span style="color:red">*</span>
                                        </td>
                                        
                                    </tr>
                                    
                                    <tr>
                                    <td style="width:130px; text-align: right; padding-right:10px; height: 20px;">
                                        สาเหตุการคืน :</td>
                                        <td colspan="3" style="height: 20px">
                                            <asp:TextBox ID="txtRemark" runat="server" CssClass="zTextbox" MaxLength="200" Width="458px" AutoPostBack="True"  ></asp:TextBox> 
                                            <span style="color:red">*</span>
                                        </td>
                                    </tr> 
                                    
                                </table> 
                            </td>
                            <td style="width:4px;">
                                &nbsp;</td>
                            <td style="border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid; padding:5px;" valign="top">
                                <table border="0" cellpadding="0" cellspacing="0" width="235px">
                                    <tr style="height:24px;">
                                        <td style="width:110px; text-align:right; padding-right:10px; height: 24px;">
                                            สถานะ :</td> 
                                        <td style="height: 24px">
                                            <asp:TextBox ID="txtStatusRef" runat="server"  Width="100px" MaxLength="20" Readonly="True" CssClass="zTextbox-View"  ></asp:TextBox></td> 
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                
                
                </td>
                </tr>
            <tr>
            </tr>
             <tr>
            </tr>
        <tr>  
            <td class="toolbarplace">
                <asp:Label ID="lbStatusMain" runat="server" EnableViewState="False"></asp:Label>
                <uc1:ToolBarItemCtl ID="tbAddDetail" runat="server" ToobarTitle="เพิ่มรายการ" ToolbarImage="../../Images/icn_add.png" OnClick="tbAddDetailClick"  />
                <uc1:ToolBarItemCtl ID="tdDelDetail" runat="server" ToobarTitle="ลบรายการ" ToolbarImage="../../Images/icn_delete.png" ClientClick="return confirm('ต้องการลบข้อมูลที่เลือก ใช่หรือไม่?')" OnClick = "tdDelDetailClick" />
            </td>
        </tr>
        <tr>
             <td>
              <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CssClass="t_tablestyle"  Width="100%" DataSourceID="ReturnRequestSource" OnRowDataBound="gvMain_RowDataBound">
                         <Columns>
                        <asp:BoundField DataField="MATERIALMASTER" HeaderText="MATERIALMASTER">
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
                                <asp:CheckBox ID="chkSelect" runat="server" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="30px" />
                            <ItemStyle HorizontalAlign="Center" Width="30px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ลำดับ" SortExpression="DEFAULT">
                            <ItemTemplate><%# Container.DataItemIndex+1 %>
                            </ItemTemplate>
                            <HeaderStyle Width="60px" />
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="รหัส" DataField="MATERIALCODE">
                            <ItemStyle Width="80px" HorizontalAlign="Center"></ItemStyle>
                            <HeaderStyle Width="80px" HorizontalAlign="Center"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="MATERIALNAME" HeaderText="รายการ">
                        </asp:BoundField>
                        <asp:BoundField DataField="UNITNAME" HeaderText="หน่วยนับ">
                            <ItemStyle Width="100px" ></ItemStyle>
                            <HeaderStyle Width="100px" HorizontalAlign="Center"></HeaderStyle>
                        </asp:BoundField>
                          <asp:TemplateField HeaderText="จำนวนที่เบิก"  >
                                <ItemTemplate>
                                    <asp:TextBox ID="txtQTY" runat="server" value = "0"  CssClass="zTextboxR-View" Width="95px"   Text='<%# (Convert.IsDBNull(Eval("STOCKOUTQTY")) ? "0" : Convert.ToDouble(Eval("STOCKOUTQTY")).ToString("#,##0.####")) %>'  readonly="true" ></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="100px" HorizontalAlign="Center"/> 
                                <HeaderStyle Width="100px" HorizontalAlign="Center" /> 
                         </asp:TemplateField>
                            <asp:TemplateField HeaderText="จำนวนที่คืน(ดี)" >
                                <ItemTemplate>
                                    <asp:TextBox ID="txtGOODQTY" runat="server" value = "0" CssClass="zTextboxR" Width="95px" MaxLength="10"  onkeypress=ChkInt(this) onblur="valInt(this)" onfocus="prepareNum(this)" Text='<%# (Convert.IsDBNull(Eval("QTY")) ? "0" : Convert.ToDouble(Eval("QTY")).ToString("#,##0.####")) %>'   ></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="100px" HorizontalAlign="Center"/> 
                                <HeaderStyle Width="100px" HorizontalAlign="Center" /> 
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="จำนวนที่คืน(เสีย)" >
                                <ItemTemplate>
                                    <asp:TextBox ID="txtWASTEQTY" runat="server" value = "0" CssClass="zTextboxR" Width="95px" MaxLength="10"  onkeypress=ChkInt(this) onblur="valInt(this)" onfocus="prepareNum(this)" Text='<%# (Convert.IsDBNull(Eval("WASTEQTY")) ? "0" : Convert.ToDouble(Eval("WASTEQTY")).ToString("#,##0.####")) %>'   ></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="100px" HorizontalAlign="Center"/> 
                                <HeaderStyle Width="100px" HorizontalAlign="Center" /> 
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="หมายเหตุ" >
                                <ItemTemplate>
                                    <asp:TextBox ID="txtREMARKS" runat="server"  CssClass="zTextboxL" Width="95px" MaxLength="200" Text='<%# (Convert.IsDBNull(Eval("REMARKS")) ? "" : Eval("REMARKS").ToString()) %>'   ></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="100px" HorizontalAlign="Right"/> 
                                <HeaderStyle Width="100px" HorizontalAlign="Center" /> 
                            </asp:TemplateField>
                         
                         <asp:BoundField DataField="UNIT" HeaderText="UNIT">
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
                    <asp:ObjectDataSource ID="ReturnRequestSource" runat="server" SelectMethod="GetReturnRequestItemList" TypeName="ReturnRequestDetailItem"  >
                         <SelectParameters>
                            <asp:ControlParameter PropertyName="Text" Type="Double" DefaultValue="0"  ControlID="txhID" Name="StockInID"></asp:ControlParameter>
                         </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
         </tr>
    </table>
<uc4:MaterialReturnRequestPopup ID="ctlMaterialReturnrRequestPopup" runat="server" OnSelectedIndexChanged="ctlMaterialReturnRequestPopup_SelectedIndexChanged" />

</asp:Content>

