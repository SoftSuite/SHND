<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="PlanOrderTools.aspx.cs" Inherits="App_Plan_Transaction_PlanOrderTools" Title="SHND : Transaction - Tool Order Planning" %>
<%@ Register Src="../../Search/MaterialUnitPopup.ascx" TagName="MaterialUnitPopup" TagPrefix="uc3" %>
<%@ Register Src="../../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="headtext">ข้อมูลแผนประมาณการวัสดุอุปกรณ์</td>
        </tr>
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbSave" runat="server" ToobarTitle="บันทึกข้อมูล" ToolbarImage="../../Images/save2.png" OnClick="tbSaveClick" />
                <uc1:ToolBarItemCtl ID="tbCancel" runat="server" ToobarTitle="ยกเลิกการแก้ไข" ToolbarImage="../../Images/cancel.png" OnClick="tbCancelClick" />
                <uc1:ToolBarItemCtl ID="tbBack" runat="server" ToobarTitle="กลับหน้ารายการ" ToolbarImage="../../Images/icn_back.png" OnClick="tbBackClick" />
                <uc1:ToolBarItemCtl ID="tbSendOrg" runat="server" ToobarTitle="ส่งให้หน่วยงาน" ToolbarImage="../../Images/icn_approve.png" OnClick="tbSendOrgClick" />
                <uc1:ToolBarItemCtl ID="tbConfirm" runat="server" ToobarTitle="ยืนยัน" ToolbarImage="../../Images/icn_approve.png" OnClick="tbConfirmClick" />
                <uc1:ToolBarItemCtl ID="tbOrgApprove" runat="server" ToobarTitle="อนุมัติ" ToolbarImage="../../Images/icn_approve.png" OnClick="tbOrgApproveClick" />
                <uc1:ToolBarItemCtl ID="tbOrgNotApprove" runat="server" ToobarTitle="ไม่อนุมัติ" ToolbarImage="../../Images/icn_cancel.png" OnClick="tbOrgNotApproveClick" />
                <uc1:ToolBarItemCtl ID="tbDivApprove" runat="server" ToobarTitle="อนุมัติ" ToolbarImage="../../Images/icn_approve.png" OnClick="tbDivApproveClick" />
                <uc1:ToolBarItemCtl ID="tbDivNotApprove" runat="server" ToobarTitle="ไม่อนุมัติ" ToolbarImage="../../Images/icn_cancel.png" OnClick="tbDivNotApproveClick" />
                <uc1:ToolBarItemCtl ID="tbPrintPR" runat="server" ToobarTitle="พิมพ์ใบเสนอราคา" ToolbarImage="../../Images/icn_print.png"/>
                <uc1:ToolBarItemCtl ID="tbPrintPlan" runat="server" ToobarTitle="พิมพ์รายงานประมาณการ" ToolbarImage="../../Images/icn_print.png"/>
            </td>
        </tr>
        <tr>
            <td style="height:30px">
                <hr style="size:1px" />
                <asp:Label ID="lbStatus" runat="server" EnableViewState="False"></asp:Label>
                <asp:TextBox ID="txtLOID" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
                <asp:TextBox ID="txtStatus" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr style="height:24px">
                        <td style="padding:5px; border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid; width:400px" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" width="500">
                                <tr style="height:24px">
                                    <td style="width:131px; padding-right:10px; text-align:right">
                                        เลขที่แผนประมาณการ :</td>
                                    <td style="width:149px">
                                        <asp:TextBox ID="txtCode" runat="server" CssClass="zTextbox-View" ReadOnly="True" Width="100px"></asp:TextBox></td>
                                    <td style="width:50px"></td>
                                    <td style="width: 170px"></td>  
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 131px; height: 24px; text-align: right">
                                        ชื่อแผนประมาณการ :</td>
                                    <td colspan="3" style="height: 24px">
                                        <asp:TextBox ID="txtName" runat="server" CssClass="zTextbox" Width="330px" MaxLength="100"></asp:TextBox>&nbsp;<span class="zRemark">*</span></td>
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 131px; text-align: right">
                                        ปีงบประมาณ :</td>
                                    <td style="width: 149px;">
                                        <asp:TextBox ID="txtBudgetYear" runat="server" CssClass="zTextboxR" Width="100px" MaxLength="4"></asp:TextBox>&nbsp;<span class="zRemark">*</span></td>
                                    <td style="width: 50px; padding-right: 10px; text-align: right">
                                    </td>
                                    <td style="width: 170px">
                                    </td>
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 131px; text-align: right">
                                        ช่วงเวลาที่ใช้ :</td>
                                    <td style="width: 149px">
                                        <uc2:CalendarControl ID="ctlStartDate" runat="server" />&nbsp;<span class="zRemark">*</span>
                                    </td>
                                    <td style="width: 50px" align="center">
                                        ถึง</td>
                                    <td style="width: 170px">
                                        <uc2:CalendarControl ID="ctlEndDate" runat="server" />&nbsp;<span class="zRemark">*</span>
                                    </td>
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 131px; text-align: right">
                                        หมวดวัสดุ :</td>
                                    <td colspan="3">
                                        <asp:DropDownList ID="cmbMaterialClass" runat="server" CssClass="zComboBox" Width="340px" AutoPostBack="True" OnSelectedIndexChanged="cmbMaterialClass_SelectedIndexChanged">
                                        </asp:DropDownList>&nbsp;<span class="zRemark">*</span>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width:4px">&nbsp;</td>
                        <td style="border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid;" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td style="border-bottom: 1px solid; padding:5px;">
                                        <table border="0" cellpadding="0" cellspacing="0" width="280px">
                                            <tr style="height:24px">
                                                <td style="width:130px; padding-right:10px; text-align:right">สถานะ :
                                                </td> 
                                                <td>
                                                    <asp:TextBox ID="txtStatusName" runat="server" CssClass="zTextbox-View" ReadOnly="True" Width="150px"></asp:TextBox>
                                                </td> 
                                            </tr>
                                        </table>
                                    </td> 
                                </tr>
                                <tr>
                                    <td style="padding:5px;">
                                        <table border="0" cellpadding="0" cellspacing="0" width="280px">
                                            <tr style="height:24px">
                                                <td style="width:130px; padding-right:10px; text-align:right">เลขที่ใบขออนุมัติ :</td> 
                                                <td>
                                                    <asp:TextBox ID="txtQtCode" runat="server" CssClass="zTextbox" Width="150px" MaxLength="20"></asp:TextBox>
                                                </td> 
                                            </tr>
                                            <tr style="height:24px">
                                                <td style="width:130px; padding-right:10px; text-align:right">รหัสใบขอซื้อ/ขอจ้าง :</td> 
                                                <td>
                                                    <asp:TextBox ID="txtRefPRSap" runat="server" CssClass="zTextbox" Width="150px" MaxLength="20"></asp:TextBox>
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
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr class="toolbarplace" >
                        <td>
                            <uc1:ToolBarItemCtl ID="tbAddMaterial" runat="server" ToobarTitle="เพิ่มรายการ" ToolbarImage="../../Images/icn_add.png" OnClick="tbAddMaterialClick" />
                            <uc1:ToolBarItemCtl ID="tbDeleteMaterial" runat="server" ToobarTitle="ลบรายการ" ToolbarImage="../../Images/icn_delete.png" OnClick="tbDeleteMaterialClick" />
                        </td>
                        <td align="right">&nbsp;
                            <asp:TextBox ID="txtTotalAdjust" runat="server" CssClass="zTextboxR" Visible="False"
                                Width="50px"></asp:TextBox><asp:Label ID="lblAdjust" runat="server" Text="เพิ่ม/ลด จำนวนประมาณการ (%)"></asp:Label>
                            <asp:TextBox ID="txtAdjPercent" runat="server" CssClass="zTextboxR" Width="50px"></asp:TextBox>
                            <asp:ImageButton ID="imbCalculate" runat="server" ImageUrl="~/Images/icn_calculate.png" ImageAlign="AbsMiddle" ToolTip="คำนวณ" OnClick="imbCalculate_Click"/>
                        </td> 
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:GridView ID="gvMaterial" runat="server" AutoGenerateColumns="False" CssClass="t_tablestyle" DataSourceID="MaterialItemSource" DataKeyNames="MATERIALMASTER" Width="100%" >
                                <Columns>
                                    <asp:BoundField DataField="MATERIALMASTER" HeaderText="MATERIALMASTER">
                                        <ControlStyle CssClass="zHidden" />
                                        <FooterStyle CssClass="zHidden" />
                                        <HeaderStyle CssClass="zHidden" />
                                        <ItemStyle CssClass="zHidden" />
                                    </asp:BoundField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <input type="checkbox" name="chkMain" id="chkMain" onclick="chkAllBox(this, 'ctl00_MainContent_gvMaterial_ctl', '_chkSelect')" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSelect" runat="server" Enabled='<%# Convert.ToString(Eval("STATUS")) == "WA" %>' />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="30px" />
                                        <ItemStyle HorizontalAlign="Center" Width="30px" VerticalAlign="Top" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ลำดับ">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex +1 %>
                                        </ItemTemplate>
                                        <HeaderStyle Width="50px" />
                                        <ItemStyle HorizontalAlign="Center" Width="50px" Height="24px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="รหัส SAP">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkCode" runat="server" Text='<%# Bind("SAPCODE") %>' CommandArgument='<%# Bind("LOID") %>' OnClick="lnkCode_Click"></asp:LinkButton> 
                                        </ItemTemplate>
                                        <ItemStyle Width="80px" HorizontalAlign="Center" />
                                        <HeaderStyle Width="80px" />  
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="MATERIALNAME" HeaderText="รายการ">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="UNITNAME" HeaderText="หน่วยนับ">
                                        <ItemStyle Width="70px" />
                                        <HeaderStyle Width="70px" /> 
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="ราคา/หน่วย&lt;br&gt;รวมภาษี">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtPrice" runat="server" Width="95px" Text='<%# Convert.ToDouble(Eval("PRICE")).ToString("#,##0.00") %>' 
                                                CssClass='<%# (Convert.ToString(Eval("STATUS")) == "WA" || Convert.ToString(Eval("STATUS")) == "CO" || Convert.ToString(Eval("STATUS")) == "SN" || Convert.ToString(Eval("STATUS")) == "DN") ? "zTextboxR" : "zTextboxR-View" %>' 
                                                ReadOnly='<%# !(Convert.ToString(Eval("STATUS")) == "WA" || Convert.ToString(Eval("STATUS")) == "CO" || Convert.ToString(Eval("STATUS")) == "SN" || Convert.ToString(Eval("STATUS")) == "DN") %>'
                                                onkeypress="ChkDbl(this)" onblur="valDbl(this)" onfocus="prepareNum(this)" ></asp:TextBox> 
                                        </ItemTemplate>
                                        <ItemStyle Width="100px" HorizontalAlign="Right" />
                                        <HeaderStyle Width="100px" />  
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="V">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkVat" runat="server" Checked='<%# Convert.ToString(Eval("ISVAT")) == "Y" %>' Enabled='<%# Convert.ToString(Eval("STATUS")) == "WA" || Convert.ToString(Eval("STATUS")) == "CO" || Convert.ToString(Eval("STATUS")) == "SN" || Convert.ToString(Eval("STATUS")) == "DN" %>' />
                                        </ItemTemplate>
                                        <ItemStyle Width="20px" HorizontalAlign="Center" />
                                        <HeaderStyle Width="20px" />  
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="PLANQTY" HeaderText="ประมาณการ" HtmlEncode="False" DataFormatString="{0:#,##0.00}">
                                        <ItemStyle Width="80px" HorizontalAlign="Right" />
                                        <HeaderStyle Width="80px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TOTALPRICE" HeaderText="รวมเป็นเงิน&lt;br&gt;รวมภาษี" HtmlEncode="False" DataFormatString="{0:#,##0.00}">
                                        <ItemStyle Width="100px" HorizontalAlign="Right" />
                                        <HeaderStyle Width="100px" />
                                    </asp:BoundField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkDetail" Text="รายละเอียด" runat="server" CommandArgument='<%# Bind("LOID") %>'  OnClick="lnkDetail_Click" Visible='<%# Convert.ToString(Eval("STATUS")) != "WA" %>'></asp:LinkButton> 
                                        </ItemTemplate>
                                        <ItemStyle Width="70px" HorizontalAlign="Center" />
                                        <HeaderStyle Width="70px" />  
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="SAPCODE" HeaderText="SAPCODE">
                                        <ControlStyle CssClass="zHidden" />
                                        <FooterStyle CssClass="zHidden" />
                                        <HeaderStyle CssClass="zHidden" />
                                        <ItemStyle CssClass="zHidden" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SPEC" HeaderText="SPEC">
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
                                    <asp:BoundField DataField="STATUS" HeaderText="STATUS">
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
                            <asp:ObjectDataSource ID="MaterialItemSource" runat="server" SelectMethod="GetToolsItemList" TypeName="PlanToolsDetailItem">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="txtLOID" DefaultValue="0" Name="planOrderID" PropertyName="Text"
                                        Type="Double" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td> 
                    </tr> 
                </table>
            </td>
        </tr>
    </table>
    <uc3:MaterialUnitPopup ID="ctlMaterialUnitPopup" runat="server" OnSelectedIndexChanged="ctlMaterialUnitPopup_SelectedIndexChanged" />
    <asp:TextBox ID="txtRowIndex" runat="server" Visible="false"></asp:TextBox>
    <cc1:ModalPopupExtender ID="ctlSpecPopup"  runat="server" PopupControlID="pnlSpec" BackgroundCssClass="modalBackground" DropShadow="true" TargetControlID="btnTest"></cc1:ModalPopupExtender>
    <asp:Panel ID="pnlSpec" runat="server" CssClass="modalPopup" style="display:none" >
        <table border="0" cellspacing="0" cellpadding="0" width="500">
            <tr>
                <td class="subheadertext">
                    <asp:Label ID="lblMaterialName" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <uc1:ToolBarItemCtl ID="tbSaveSpec" runat="server" ToobarTitle="บันทึกข้อมูล" ToolbarImage="../../Images/save2.png" OnClick="tbSaveSpecClick" />
                    <uc1:ToolBarItemCtl ID="tbBackSpec" runat="server" ToobarTitle="กลับหน้ารายการ" ToolbarImage="../../Images/icn_back.png" />
                </td>
            </tr>
            <tr>
                <td><hr style="size:1px"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtSpec" runat="server" TextMode="MultiLine" Width="500px" Height="80px" MaxLength="200" CssClass="zTextbox"></asp:TextBox>
                </td> 
            </tr>
        </table>
    </asp:Panel>
    <asp:Button ID="btntest" runat="server" Text="test" CssClass="zHidden" />
    <cc1:ModalPopupExtender ID="ctlDetailPopup"  runat="server" PopupControlID="pnlDetail" BackgroundCssClass="modalBackground" DropShadow="true" TargetControlID="btnTest1"></cc1:ModalPopupExtender>
    <asp:Panel ID="pnlDetail" runat="server" CssClass="modalPopup" style="display:none" >
        <table border="0" cellspacing="0" cellpadding="0" width="550">
            <tr>
                <td class="subheadertext">
                    <asp:Label ID="lblMaterialNameDetail" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <uc1:ToolBarItemCtl ID="tbBackDetail" runat="server" ToobarTitle="กลับหน้ารายการ" ToolbarImage="../../Images/icn_back.png" OnClick="tbBackDetailClick" />
                    <asp:TextBox ID="txtMaterialID" runat="server" Visible="false"></asp:TextBox>
                    <asp:TextBox ID="txtIsUpdated" runat="server" Visible="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td><hr style="size:1px"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtSpecView" runat="server" TextMode="MultiLine" Width="550px" Height="80px" MaxLength="200" CssClass="zTextbox-View" ReadOnly="true"></asp:TextBox>
                </td> 
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gvDetail" runat="server" AutoGenerateColumns="False" CssClass="t_tablestyle" DataSourceID="DetailSource" DataKeyNames="DIVISION" OnRowCommand="gvDetail_RowCommand" OnRowUpdated="gvDetail_RowUpdated" OnRowUpdating="gvDetail_RowUpdating"  Width="100%">
                        <Columns>
                            <asp:BoundField DataField="DIVISION" HeaderText="DIVISION">
                                <ControlStyle CssClass="zHidden" />
                                <FooterStyle CssClass="zHidden" />
                                <HeaderStyle CssClass="zHidden" />
                                <ItemStyle CssClass="zHidden" />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="imbReturn" runat="server" CausesValidation="False" ImageUrl="~/Images/icn_return.png" CommandArgument='<%# Container.DataItemIndex %>' Visible='<%# Convert.ToString(Eval("STATUS")) == "ST" || Convert.ToString(Eval("STATUS")) == "SN" || Convert.ToString(Eval("STATUS")) == "DN" %>' OnClick="imbReturn_Click" />
                                    <asp:ImageButton ID="imbEdit" runat="server" CausesValidation="False" CommandName="Edit" ImageUrl="~/Images/icn_edit.png"/>
                                </ItemTemplate>
                                <EditItemTemplate>
                                        <asp:ImageButton ID="imbSave" runat="server" CausesValidation="True" CommandName="Update" ImageUrl="~/Images/save2.png" />
                                        <asp:ImageButton ID="imbCancel" runat="server" CausesValidation="False" CommandName="Cancel" ImageUrl="~/Images/icn_back.png"/>
                                </EditItemTemplate> 
                                <HeaderStyle HorizontalAlign="Center" Width="60px" />
                                <ItemStyle HorizontalAlign="Center" Width="60px" VerticalAlign="Top" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ลำดับ">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex +1 %>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <%# Container.DataItemIndex +1 %>
                                </EditItemTemplate>
                                <HeaderStyle Width="50px" />
                                <ItemStyle HorizontalAlign="Center" Width="50px" Height="24px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="DIVISIONNAME" HeaderText="หน่วยงาน" ReadOnly="True">
                            </asp:BoundField>
                            <asp:BoundField DataField="REQQTY" HeaderText="ต้องการ" HtmlEncode="False" DataFormatString="{0:#,##0.00}" ReadOnly="True">
                                <ItemStyle Width="80px" HorizontalAlign="Right" />
                                <HeaderStyle Width="80px" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="ประมาณการ">
                                <ItemTemplate>
                                    <asp:Label ID="lblAdjQty" runat="server" Text='<%# Convert.ToDouble(Eval("ADJQTY")).ToString("#,##0.00")  %>' ></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtAdjQty" runat="server" Width="95px" Text='<%# Convert.ToDouble(Eval("ADJQTY")).ToString("#,##0.00")  %>' 
                                        CssClass='<%# Convert.ToString(Eval("STATUS")) != "CO" ? "zTextboxR" : "zTextboxR-View" %>' 
                                        ReadOnly='<%# Convert.ToString(Eval("STATUS")) == "CO" %>'
                                        onkeypress="ChkDbl(this)" onblur="valDbl(this)" onfocus="prepareNum(this)" ></asp:TextBox> 
                                </EditItemTemplate> 
                                <ItemStyle Width="100px" HorizontalAlign="Right"/>
                                <HeaderStyle Width="100px" />  
                            </asp:TemplateField>
                            <asp:BoundField DataField="MATERIALMASTER" HeaderText="MATERIALMASTER">
                                <ControlStyle CssClass="zHidden" />
                                <FooterStyle CssClass="zHidden" />
                                <HeaderStyle CssClass="zHidden" />
                                <ItemStyle CssClass="zHidden" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DIVISION" HeaderText="DIVISION">
                                <ControlStyle CssClass="zHidden" />
                                <FooterStyle CssClass="zHidden" />
                                <HeaderStyle CssClass="zHidden" />
                                <ItemStyle CssClass="zHidden" />
                            </asp:BoundField>
                            <asp:BoundField DataField="STATUS" HeaderText="STATUS">
                                <ControlStyle CssClass="zHidden" />
                                <FooterStyle CssClass="zHidden" />
                                <HeaderStyle CssClass="zHidden" />
                                <ItemStyle CssClass="zHidden" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PLANQTY" HeaderText="PLANQTY">
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
                    <asp:ObjectDataSource ID="DetailSource" runat="server" SelectMethod="GetToolsDivisionLIst" TypeName="PlanToolsDetailItem" UpdateMethod="UpdateToolsDivision">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="txtLOID" DefaultValue="0" Name="planOrderID" PropertyName="Text" Type="Double" />
                            <asp:ControlParameter ControlID="txtMaterialID" DefaultValue="0" Name="materialMaster" PropertyName="Text" Type="Double" />
                        </SelectParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="planOrderID" Type="Double" />
                            <asp:Parameter Name="MATERIALMASTER" Type="Double" />
                            <asp:Parameter Name="DIVISION" Type="Double" />
                            <asp:Parameter Name="ADJQTY" Type="Double" />
                            <asp:Parameter Name="PLANQTY" Type="Double" />
                            <asp:Parameter Name="STATUS" Type="String" />
                        </UpdateParameters>
                    </asp:ObjectDataSource>
                </td> 
            </tr> 
        </table>
    </asp:Panel>
    <asp:Button ID="btntest1" runat="server" Text="test" CssClass="zHidden" />
</asp:Content>