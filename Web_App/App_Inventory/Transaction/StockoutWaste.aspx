<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="StockoutWaste.aspx.cs" Inherits="App_Inventory_Transaction_StockoutWaste" Title="SHND : Master - Waste Stock out"%>


<%@ Register Src="../../Search/MaterialStockOutWastePopup.ascx" TagName="MaterialStockOutWastePopup" TagPrefix="uc4" %>
<%@ Register Src="../../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc3" %>
<%@ Register Src="../../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="headtext">
                ข้อมูลการจำหน่ายของเสีย</td>
        </tr>
        <tr>
             <td>
                <uc1:ToolBarItemCtl ID="tbSave" runat="server" ToobarTitle="บันทึกข้อมูล"  ToolbarImage="../../Images/save2.png" OnClick="tbSaveClick"  />
                <uc1:ToolBarItemCtl ID="tbCancel" runat="server" ToobarTitle="ยกเลิกการแก้ไข"  ToolbarImage="../../Images/cancel.png" OnClick="tbCancelClick" />
                <uc1:ToolBarItemCtl ID="tbSend" runat="server" ToobarTitle="ส่งข้อมูล"  ToolbarImage="../../Images/icn_approve.png" OnClick="tbSendClick" />
                <uc1:ToolBarItemCtl ID="tbCommit" runat="server" ToobarTitle="อนุมัติ"  ToolbarImage="../../Images/icn_approve.png" OnClick="tbCommitClick" />
                <uc1:ToolBarItemCtl ID="tbNotApprove" runat="server" ToobarTitle="ไม่อนุมัติ"  ToolbarImage="../../Images/icn_cancel.png" OnClick="tbNotApproveClick" />
                <uc1:ToolBarItemCtl ID="tbBack" runat="server" ToobarTitle="กลับหน้ารายการ"  ToolbarImage="../../Images/icn_back.png" OnClick="tbBackClick"  />
                <uc1:ToolBarItemCtl ID="tbPrint" runat="server" ToobarTitle="พิมพ์"  ToolbarImage="../../Images/icn_print.png" />
            </td>
        </tr>
        <tr>
            <td>
                <hr style="size:1px" />
                    <asp:TextBox ID="txhSortField" runat="server" Visible="False" Width="15px"></asp:TextBox>
                    <asp:TextBox ID="txhSortDir" runat="server" Visible="False" Width="15px"></asp:TextBox>
                    <asp:TextBox ID="txhID" runat="server" Visible="False" Width="15px"></asp:TextBox>
                    <asp:TextBox  ID="txtStatus" runat="server" Visible="False" Width="15px"></asp:TextBox>
                    <asp:Label ID="lbStatus" runat="server" EnableViewState="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="height: 15px">
                     <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td style="padding:5px; border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid; width:409px" valign="top">
                                <table border="0" cellpadding="0" cellspacing="0" width="540px">
                                    <tr style="height:24px">
                                        <td style="width:130px; text-align: right; padding-right:10px">เลขที่จำหน่าย
                                        </td>
                                        <td style="width:160px;"><asp:TextBox ID="txtCODE" runat="server" CssClass="zTextbox-View" Width="150px" MaxLength="20" Readonly="True" ></asp:TextBox>
                                        </td>
                                        <td style="width:112px; text-align: right; padding-right:10px">วันที่จำหน่าย 
                                        </td>
                                        <td><uc3:CalendarControl ID="ctlStockoutDate" runat="server"  /><span style="color:red">*</span>
                                        </td> 
                                    </tr>
                                    <tr style="height:24px">
                                        <td style="width:130px; text-align: right; padding-right:10px">คลังที่จำหน่ายออก
                                        </td>
                                        <td style="width:160px;">
                                            <asp:DropDownList ID="cmbWareHouse" runat="server" CssClass="zComboBox" Width="150px" AutoPostBack="True" ></asp:DropDownList><span style="color:red">*</span>
                                        </td>
                                        <td style="width:112px; text-align: right; padding-right:10px">หน่วยงานที่ทำเสีย 
                                        </td>
                                        <td style="width:170px;">
                                            <asp:DropDownList ID="cmbDiv" runat="server" CssClass="zComboBox" Width="150px" AutoPostBack="True" ></asp:DropDownList><span style="color:red">*</span>
                                        </td> 
                                    </tr>
                                    <tr>
                                        <td style="width:130px; text-align: right; padding-right:10px">
                                            <asp:Label ID="lblReason" runat="server" Text="เหตุผลการจำหน่ายของเสีย" Visible="false"></asp:Label>&nbsp;
                                        </td>
                                        <td colspan="3">
                                            <asp:TextBox ID="txtReason" runat="server" Width="400px" MaxLength="500" Readonly="True" Visible="false"></asp:TextBox>
                                            <asp:Label ID="lblReasonStar" runat="server" Text="*" Visible="false" ForeColor="red"></asp:Label>&nbsp;
                                        </td>
                                    </tr>
                                    
                                </table> 
                            </td>
                            <td style="width:4px">
                                &nbsp;</td>
                            <td style="border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid; padding:5px" valign="top">
                                <table border="0" cellpadding="0" cellspacing="0" width="235px">
                                    <tr style="height:24px;">
                                        <td style="width:110px; text-align:right; padding-right:10px;">
                                            สถานะ :</td> 
                                        <td>
                                            <asp:TextBox ID="txtStatusRef" runat="server"  Width="100px" MaxLength="20" Readonly="True" CssClass="zTextboxR-View" >กำลังดำเนิการ</asp:TextBox></td> 
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
            <td class="toolbarplace" style="padding:5px; border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid; width:400px" valign="top">
                <asp:Label ID="lbStatusMain" runat="server" EnableViewState="False"></asp:Label>
                <uc1:ToolBarItemCtl ID="tbAddDetail" runat="server" ToobarTitle="เพิ่มรายการ" ToolbarImage="../../Images/icn_add.png" OnClick="tbAddDetailClick" />
                <uc1:ToolBarItemCtl ID="tdDelDetail" runat="server" ToobarTitle="ลบรายการ" ToolbarImage="../../Images/icn_delete.png" OnClick="tdDelDetailClick" ClientClick="return confirm('ต้องการลบข้อมูลที่เลือก ใช่หรือไม่?')" />
            </td>
        </tr>
        <tr>
             <td>
              <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CssClass="t_tablestyle"  Width="100%" DataSourceID="StockoutSource">
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
                            <HeaderStyle Width="60px" />
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="รหัส SAP" DataField="SAPCODE">
                            <ItemStyle Width="80px" HorizontalAlign="Center"></ItemStyle>
                            <HeaderStyle Width="80px" HorizontalAlign="Center"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="MATERIALNAME" HeaderText="รายการ">
                            <ItemStyle Width="170px" HorizontalAlign="Left"></ItemStyle>
                            <HeaderStyle Width="170px" HorizontalAlign="Center"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="UNITNAME" HeaderText="หน่วยนับ">
                            <ItemStyle Width="100px" HorizontalAlign="Center"></ItemStyle>
                            <HeaderStyle Width="100px" HorizontalAlign="Center"></HeaderStyle>
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="จำนวนที่เสีย" >
                                <ItemTemplate>
                                    <asp:TextBox ID="txtQTY" runat="server" value = "0" CssClass="zTextboxR" Width="95px"  onkeypress="ChkDbl(this)" onblur="valInt(this)" onfocus="prepareNum(this)" Text='<%# (Convert.IsDBNull(Eval("QTY")) ? "" : Convert.ToDouble(Eval("QTY")).ToString("#,##0")) %>'  ></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="100px" HorizontalAlign="Center"/> 
                                <HeaderStyle Width="100px" HorizontalAlign="Center" /> 
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="หมายเหตุ"  >
                                <ItemTemplate>
                                    <asp:TextBox ID="txtRemark" runat="server"  CssClass="zTextboxL" Width="230px" MaxLength="200" Text='<%# (Convert.IsDBNull(Eval("REMARKS")) ? "" : Eval("REMARKS")).ToString() %>' ></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="250px" /> 
                                <HeaderStyle Width="250px" HorizontalAlign="Center" /> 
                            </asp:TemplateField>
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
                    <asp:ObjectDataSource ID="StockoutSource" runat="server" SelectMethod="GetStockoutWasteItemList" TypeName="StockoutWasteDetailItem"  >
                         <SelectParameters>
                            <asp:ControlParameter PropertyName="Text" Type="Double" DefaultValue="0" ControlID="txhID" Name="StockoutWasteID"></asp:ControlParameter>
                         </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
         </tr>
    </table>
<uc4:MaterialStockOutWastePopup ID="ctlMaterialStockOutWastePopup" runat="server" OnSelectedIndexChanged="ctlMaterialStockOutWastePopup_SelectedIndexChanged"  />

</asp:Content>

