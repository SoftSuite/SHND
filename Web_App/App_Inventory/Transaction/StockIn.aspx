<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="StockIn.aspx.cs" Inherits="App_Inventory_Transaction_StockIn" Title="SHND : Transaction - Stock in"%>

<%@ Register Src="../../Search/MaterialStockInFoodPopup.ascx" TagName="MaterialStockInFoodPopup" TagPrefix="uc5" %>
<%@ Register Src="../../Search/MaterialStockInToolsPopup.ascx" TagName="MaterialStockInToolsPopup" TagPrefix="uc4" %>
<%@ Register Src="../../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc3" %>
<%@ Register Src="../../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="headtext">
                รับเข้า</td>
        </tr>
        <tr>
             <td>
                <uc1:ToolBarItemCtl ID="tbSave" runat="server" ToobarTitle="บันทึก"  ToolbarImage="../../Images/save2.png"  onclick="tbSaveClick" />
                <uc1:ToolBarItemCtl ID="tbCancel" runat="server" ToobarTitle="ยกเลิกการแก้ไข"  ToolbarImage="../../Images/cancel.png" OnClick="tbCancelClick" />
                <uc1:ToolBarItemCtl ID="tbCommit" runat="server" ToobarTitle="อนุมัติ"  ToolbarImage="../../Images/icn_approve.png" OnClick="tbCommitClick" />
                <uc1:ToolBarItemCtl ID="tbBack" runat="server" ToobarTitle="กลับหน้ารายการ"  ToolbarImage="../../Images/icn_back.png" OnClick="tbBackClick" />
                <uc1:ToolBarItemCtl ID="tbPrint" runat="server" ToobarTitle="พิมพ์"  ToolbarImage="../../Images/icn_print.png"  />
            </td>
        </tr>
        <tr>
            <td>
                <hr style="size:1px"/>
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
            <td>
                 <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td style="padding:5px; border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid; width:620px" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" width="600">
                                <tr style="height:24px">
                                    <td style="width:130px; text-align: right; padding-right:10px; height: 24px;">เลขที่รับเข้าคลัง :&nbsp;</td>
                                    <td style="width:170px; height: 24px;"><asp:TextBox ID="txtCODE" runat="server" CssClass="zTextbox-View" Width="150px" MaxLength="20" Readonly="True" ></asp:TextBox>
                                    </td>
                                    <td style="width:85px; text-align: right; padding-right:10px; height: 24px;">วันที่รับ :</td>
                                    <td style="height: 24px; width: 195px;"><uc3:CalendarControl ID="ctlStockInDate" runat="server"  />
                                        &nbsp;<span style="color:red">*</span>
                                    </td> 
                                </tr>
                                <tr style="height:24px">
                                    <td style="width:130px; text-align: right; padding-right:10px; height: 24px;">คลังที่รับเข้า :&nbsp;</td>
                                    <td style="width:170px; height: 24px;">
                                        <asp:DropDownList ID="cmbWareHouse" runat="server" CssClass="zComboBox" Width="156px" AutoPostBack="True" ></asp:DropDownList>
                                        <span style="color:red">*</span>
                                    </td>
                                    <td style="width:85px; text-align: right; padding-right:10px; height: 24px;">
                                        <asp:Label ID="lbOrder" runat="server" EnableViewState="true">คลังที่จ่าย :</asp:Label>
                                    </td>
                                    <td style="height: 24px; width: 195px;">
                                        <asp:DropDownList ID="cmbWareHouseOrder" runat="server" CssClass="zComboBox" Width="156px" AutoPostBack="True" ></asp:DropDownList>
                                        <asp:Label ID="lbChk" runat="server" style="color:red" Width="11px">*</asp:Label>
                                    </td>
                                    
                                </tr>
                                <tr>
                                    <td style="width:130px; text-align: right; padding-right:10px; height: 24px;">
                                        <asp:Label ID="lbPlan" runat="server" EnableViewState="true">แผนประมาณการ :</asp:Label>
                                    </td>
                                    <td colspan="3" style="height: 24px">
                                        <asp:DropDownList ID="cmbPlan" runat="server" CssClass="zComboBox" Width="421px" AutoPostBack="True" OnSelectedIndexChanged="cmbPlan_SelectedIndexChanged" ></asp:DropDownList>
                                        <asp:Label ID="lbChkPlan" runat="server" style="color:red" Width="11px">*</asp:Label>
                                    </td>
                                </tr> 
                                <tr>
                                    <td style="width:130px; text-align: right; padding-right:10px; height: 24px;">
                                        <asp:Label ID="lblMaterialClass" runat="server" EnableViewState="true" Visible="false" >หมวดอาหาร :</asp:Label>
                                    </td>
                                    <td colspan="3" style="height: 24px">
                                        <asp:DropDownList ID="cmbMaterialClass" runat="server" CssClass="zComboBox" Width="421px" AutoPostBack="True" Visible="false" OnSelectedIndexChanged="cmbMaterialClass_SelectedIndexChanged"  ></asp:DropDownList>
                                        <asp:Label ID="lblChkMaterialClass" runat="server" style="color:red" Width="11px" Visible="false">*</asp:Label>
                                    </td>
                                </tr> 
                            </table> 
                        </td>
                        <td style="width:4px">
                            &nbsp;</td>
                        <td style="border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid; padding:5px" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" width="400">
                                <tr style="height:24px;">
                                    <td style="width:110px; text-align:right; padding-right:10px; height: 24px;">
                                        ประเภทการรับเข้า :</td> 
                                    <td style="height: 24px">
                                         <asp:TextBox ID="txtTypeRef" runat="server"  Width="150px" MaxLength="20" Readonly="True" CssClass="zTextbox-View" ></asp:TextBox></td> 
                                </tr>
                                <tr style="height:24px;">
                                    <td style="width:110px; text-align:right; padding-right:10px; height: 24px;">
                                        สถานะ :</td> 
                                    <td style="height: 24px">
                                        <asp:TextBox ID="txtStatusRef" runat="server"  Width="150px" MaxLength="20" Readonly="True" CssClass="zTextbox-View" ></asp:TextBox></td> 
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>  
            <td class="toolbarplace">
                <asp:Label ID="lbStatusMain" runat="server" EnableViewState="False"></asp:Label>
                <uc1:ToolBarItemCtl ID="tbAddDetail" runat="server" ToobarTitle="เพิ่มรายการ" ToolbarImage="../../Images/icn_add.png" OnClick="tbAddDetailClick"  />
                <uc1:ToolBarItemCtl ID="tdDelDetail" runat="server" ToobarTitle="ลบรายการ" ToolbarImage="../../Images/icn_delete.png" ClientClick="return confirm('ต้องการลบข้อมูลที่เลือก ใช่หรือไม่?')" OnClick="tdDelDetailClick" />
            </td>
        </tr>
        <tr>
             <td>
              <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CssClass="t_tablestyle"  Width="100%" DataSourceID="StockInSource" OnRowDataBound="gvMain_RowDataBound">
                    <Columns>
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
                                <asp:CheckBox ID="chkSelect" runat="server" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="30px" />
                            <ItemStyle HorizontalAlign="Center" Width="30px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ลำดับ" SortExpression="DEFAULT">
                            <ItemTemplate><%# Container.DataItemIndex+1 %>
                            </ItemTemplate>
                            <HeaderStyle Width="40px" />
                            <ItemStyle HorizontalAlign="Center" Width="40px" />
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="รหัส" DataField="MATERIALCODE">
                            <ItemStyle Width="70px" HorizontalAlign="Center"></ItemStyle>
                            <HeaderStyle Width="70px" HorizontalAlign="Center"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="MATERIALNAME" HeaderText="รายการ">
                        </asp:BoundField>
                        <asp:BoundField DataField="UNITNAME" HeaderText="หน่วยนับ">
                            <ItemStyle Width="60px"></ItemStyle>
                            <HeaderStyle Width="60px" HorizontalAlign="Center"></HeaderStyle>
                        </asp:BoundField>
                       
                        <asp:TemplateField HeaderText="เลขที่สั่งซื้อ" >
                                <ItemTemplate>
                                    <asp:TextBox ID="txtSAPPOCODE" runat="server"  CssClass="zTextbox" Width="75px"  Text='<%# (Convert.IsDBNull(Eval("SAPPOCODE")) ? "" : Eval("SAPPOCODE")) %>'  ></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="80px" HorizontalAlign="Center"/> 
                                <HeaderStyle Width="80px" HorizontalAlign="Center" /> 
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="วันที่สั่งซื้อ" >
                                <ItemTemplate>
                                    <uc3:CalendarControl ID="ctlSAPPODATE" runat="server" DateValue = '<%# Convert.IsDBNull(Eval("SAPPODATE")) ? new DateTime() : Convert.ToDateTime(Eval("SAPPODATE")) %>'/>
                                </ItemTemplate>
                                <ItemStyle Width="140px" HorizontalAlign="center"/> 
                                <HeaderStyle Width="140px" HorizontalAlign="Center" /> 
                            </asp:TemplateField>
                             <asp:BoundField  HeaderText="ยอดประมาณการ" DataField="PLANQTY" >
                                <ItemStyle Width="90px" HorizontalAlign="Right"/> 
                                <HeaderStyle Width="90px" HorizontalAlign="Center" /> 
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="จำนวนที่รับ" >
                                <ItemTemplate>
                                    <asp:TextBox ID="txtQTY" runat="server" value = "0" CssClass="zTextboxR" Width="75px"  onkeypress=ChkInt(this) onblur="valInt(this)" onfocus="prepareNum(this)" Text='<%# (Convert.IsDBNull(Eval("QTY")) ? "0" : Convert.ToDouble(Eval("QTY")).ToString("#,##0")) %>'   ></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="80px" HorizontalAlign="Right"/> 
                                <HeaderStyle Width="80px" HorizontalAlign="Center" /> 
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="คงเหลือ" DataField="REMAINQTY"  >
                                <ItemStyle Width="80px" HorizontalAlign="Right"/> 
                                <HeaderStyle Width="80px" HorizontalAlign="Center" /> 
                            </asp:BoundField >
                            <asp:TemplateField HeaderText="รหัสครุภัณฑ์SAP" >
                                <ItemTemplate>
                                    <asp:TextBox ID="txtLOTNO" runat="server" CssClass="zTextbox" Width="75px"  Text='<%# (Convert.IsDBNull(Eval("LOTNO")) ? "" : Eval("LOTNO")) %>'    ></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="80px" HorizontalAlign="center" /> 
                                <HeaderStyle Width="80px" HorizontalAlign="Center" /> 
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ระยะเวลารับประกัน(เดือน)" >
                                <ItemTemplate>
                                    <asp:TextBox ID="txtGURANTEE" runat="server"  CssClass="zTextboxR" Width="75px"  onkeypress=ChkInt(this) onblur="valInt(this)" onfocus="prepareNum(this)"  Text='<%# (Convert.IsDBNull(Eval("GUARANTEE")) ? "" : Convert.ToDouble(Eval("GUARANTEE")).ToString()) %>' ></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="80px" HorizontalAlign="Right"/> 
                                <HeaderStyle Width="80px" HorizontalAlign="Center" /> 
                            </asp:TemplateField>
                                                        
                        <asp:BoundField DataField="PRICE" HeaderText="PRICE">
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
                        <asp:BoundField DataField="MATERIALMASTER" HeaderText="MATERIALMASTER">
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
                    <asp:ObjectDataSource ID="StockInSource" runat="server" SelectMethod="GetStockInItemList" TypeName="StockInDetailItem"  >
                         <SelectParameters>
                            <asp:ControlParameter PropertyName="Text" Type="Double" DefaultValue="0"  ControlID="txhID" Name="StockInID"></asp:ControlParameter>
                         </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
         </tr>
    </table>
    
<uc4:MaterialStockInToolsPopup ID="ctlMaterialStockinToolsPopup" runat="server" OnSelectedIndexChanged="ctlMaterialStockinToolsPopup_SelectedIndexChanged" />
<uc5:MaterialStockInFoodPopup ID="ctlMaterialStockInFoodPopup" runat="server" OnSelectedIndexChanged="ctlMaterialStockinFoodPopup_SelectedIndexChanged" />

</asp:Content>



