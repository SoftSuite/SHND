<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OrderFeedControl.ascx.cs" Inherits="App_Prepare_Transaction_RegisterOrderPatient_OrderFeedControl" %>
<%@ Register Src="../../../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc2" %>
<%@ Register Src="../../../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc1" %>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td>
            <fieldset style="padding:15px;">
                <legend style="font-weight:bold">
                    ค้นหา
                </legend>
                <table border="0" cellpadding="0" cellspacing="0" width="900px">
                    <tr>
                        <td style="height:15px" colspan="8"></td>
                    </tr> 
                    <tr style="height: 24px">
                        <td style="padding-right: 10px; width: 110px; text-align: right">
                            วันที่สั่งอาหาร :</td>
                        <td colspan="7">
                            <uc1:CalendarControl ID="ctlSearchDate" runat="server" />
                            &nbsp;<span class="zRemark">*</span>
                        </td>
                    </tr>
                    <tr style="height: 24px">
                        <td style="padding-right: 10px; width: 110px; text-align: right">
                            หอผู้ป่วย :</td>
                        <td colspan="7">
                            <asp:DropDownList ID="cmbSearchWard" runat="server" CssClass="zComboBox" Width="200px">
                            </asp:DropDownList></td>
                    </tr>
                    <tr style="height: 24px">
                        <td style="padding-right: 10px; width: 110px; text-align: right;">
                            ชื่ออาหาร :</td>
                        <td colspan="7">
                            <asp:DropDownList ID="cmbSearchFoodName" runat="server" CssClass="zComboBox" Width="200px">
                            </asp:DropDownList></td>
                    </tr>
                    <tr style="height: 24px">
                        <td style="padding-right: 10px; width: 110px; text-align: right">
                            ชื่อ-สกุล ผู้ป่วย :</td>
                        <td colspan="7">
                            <asp:TextBox ID="txtSearchPatientName" runat="server" CssClass="zTextbox" Width="340px"></asp:TextBox></td>
                    </tr>
                    <tr style="height:24px">
                        <td style="width:110px; text-align: right; padding-right:10px">
                            วันที่บันทึก :</td>
                        <td style="width:150px;">
                            <uc1:CalendarControl ID="ctlSearchOrderDate" runat="server" />
                        </td>
                        <td style="width:50px; text-align: right; padding-right:10px">
                            เวลา :</td>
                        <td style="width:50px;">
                            <asp:TextBox ID="txtSearchTimeFrom" runat="server" CssClass="zTextboxR" Width="45px"></asp:TextBox></td>
                        <td style="width:34px;" align="center">
                            ถึง</td>
                        <td style="width:50px;">
                            <asp:TextBox ID="txtSearchTimeTo" runat="server" CssClass="zTextboxR" Width="45px"></asp:TextBox></td>
                        <td style="width:70px; padding-left:10px" class="zRemark">
                            (Ex 08:00)</td>
                        <td>
                            <asp:ImageButton ID="imbSearch" runat="server" ImageUrl="~/Images/icn_find.png" ImageAlign="absMiddle" OnClick="imbSearch_Click" />
                            <asp:ImageButton ID="imbReset" runat="server" ImageUrl="~/Images/icn_back.png" ImageAlign="absMiddle" OnClick="imbReset_Click" />
                        </td>
                    </tr>
                </table> 
                <cc1:MaskedEditExtender ID="mdeTimeFrom" runat="server" TargetControlID="txtSearchTimeFrom" MaskType="Time" Mask="99:99"></cc1:MaskedEditExtender>
                <cc1:MaskedEditExtender ID="mdeTimeTo" runat="server" TargetControlID="txtSearchTimeTo" MaskType="Time" Mask="99:99"></cc1:MaskedEditExtender>
            </fieldset>
        </td>
    </tr>
    <tr>
        <td class="toolbarplace">
            <uc2:ToolBarItemCtl ID="tbRegister" runat="server" ToolbarImage="../../Images/icn_approve.png" ToobarTitle="Register" OnClick="tbRegister_Click" />
            <uc2:ToolBarItemCtl ID="tbUnRegister" runat="server" ToolbarImage="../../Images/icn_approve.png" ToobarTitle="Non Register" OnClick="tbUnRegister_Click" />
        </td>
    </tr>
    <tr>
        <td>
            <uc3:PageControl ID="pcTop" runat="server" OnPageChange="PageChange"  />
            <asp:GridView ID="gvMain" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="t_tablestyle1" CellPadding="0" OnRowDataBound="gvMain_RowDataBound" Width="100%">
                <Columns>
                    <asp:BoundField DataField="ORDERMEDICALFEED" HeaderText="ORDERMEDICALFEED">
                        <ControlStyle CssClass="zHidden" />
                        <FooterStyle CssClass="zHidden" />
                        <HeaderStyle CssClass="zHidden" />
                        <ItemStyle CssClass="zHidden" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ORDERNONMEDICAL" HeaderText="ORDERNONMEDICAL">
                        <ControlStyle CssClass="zHidden" />
                        <FooterStyle CssClass="zHidden" />
                        <HeaderStyle CssClass="zHidden" />
                        <ItemStyle CssClass="zHidden" />
                    </asp:BoundField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <table border="0" cellpadding="2" cellspacing="0" width="100%">
                                <tr style="height:20px" class="t_headtext">
                                    <td style="width:40px; border-right:solid 1px #ebe9ed" align="center">ลำดับ</td> 
                                    <td style="width:30px; border-right:solid 1px #ebe9ed" align="center"><asp:CheckBox ID="chkMain" runat="server" /></td> 
                                    <td style="width:120px; border-right:solid 1px #ebe9ed" align="center">หอผู้ป่วย</td> 
                                    <td style="width:30px; border-right:solid 1px #ebe9ed" align="center">ห้อง</td> 
                                    <td style="width:30px; border-right:solid 1px #ebe9ed" align="center">เตียง</td> 
                                    <td style="width:50px; border-right:solid 1px #ebe9ed" align="center">HN</td> 
                                    <td style="width:50px; border-right:solid 1px #ebe9ed" align="center">AN</td> 
                                    <td style="width:50px; border-right:solid 1px #ebe9ed" align="center">VN</td>  
                                    <td style="width:250px; border-right:solid 1px #ebe9ed" align="center">ชื่อ-สกุล</td> 
                                    <td style="width:30px; border-right:solid 1px #ebe9ed" align="center">อายุ</td>  
                                    <td style="width:30px; border-right:solid 1px #ebe9ed" align="center">น.น.</td>  
                                    <td style="width:30px; border-right:solid 1px #ebe9ed" align="center">ส.ส.</td>  
                                    <td align="center">BMI</td>  
                                </tr>
                            </table>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <table border="0" cellpadding="2" cellspacing="0" width="100%">
                                <tr style="height:20px" class='<%# Eval("RANK").ToString() != "0" ? "t_alt_bg" : "zHidden" %>'>
                                    <td style="width:40px; border-right:solid 1px #ebe9ed" align="center"><%# Eval("RANK") %></td> 
                                    <td style="width:30px; border-right:solid 1px #ebe9ed" align="center"></td> 
                                    <td style="width:120px; border-right:solid 1px #ebe9ed" align="left"><%# Eval("WARDNAME") %></td> 
                                    <td style="width:30px; border-right:solid 1px #ebe9ed" align="center"><%# Eval("ROOMNO") %></td> 
                                    <td style="width:30px; border-right:solid 1px #ebe9ed" align="center"><%# Eval("BEDNO") %></td> 
                                    <td style="width:50px; border-right:solid 1px #ebe9ed" align="center"><%# Eval("HN") %></td> 
                                    <td style="width:50px; border-right:solid 1px #ebe9ed" align="center"><%# Eval("AN") %></td> 
                                    <td style="width:50px; border-right:solid 1px #ebe9ed" align="center"><%# Eval("VN") %></td>  
                                    <td style="width:250px; border-right:solid 1px #ebe9ed" align="left"><%# Eval("PATIENTNAME") %></td> 
                                    <td style="width:30px; border-right:solid 1px #ebe9ed" align="right"><%# Eval("AGE") %></td>  
                                    <td style="width:30px; border-right:solid 1px #ebe9ed" align="right"><%# Eval("WEIGHT") %></td>  
                                    <td style="width:30px; border-right:solid 1px #ebe9ed" align="right"><%# Eval("HEIGHT") %></td>  
                                    <td align="left"><%# Eval("BMI") %></td>  
                                </tr>
                                <tr style="height:1px">
                                    <td style="width:40px; border-right:solid 1px #ebe9ed" align="center"></td> 
                                    <td style="width:30px; border-right:solid 1px #ebe9ed" align="center"></td> 
                                    <td style="width:120px;" align="left"></td> 
                                    <td style="width:30px;" align="center"></td> 
                                    <td style="width:30px;" align="center"></td> 
                                    <td style="width:50px;" align="center"></td> 
                                    <td style="width:50px;" align="center"></td> 
                                    <td style="width:50px;" align="center"></td>  
                                    <td style="width:250px;" align="left"></td> 
                                    <td style="width:30px;" align="right"></td>  
                                    <td style="width:30px;" align="right"></td>  
                                    <td style="width:30px;" align="right"></td>  
                                    <td align="left"></td>  
                                </tr>
                                <tr style="height:20px">
                                    <td style="width:40px; border-right:solid 1px #ebe9ed" align="center"></td> 
                                    <td style="width:30px; border-right:solid 1px #ebe9ed" align="center"><asp:CheckBox ID="chkSelect" runat="server" Visible='<%# Eval("STATUS").ToString() != "NA" %>'/></td> 
                                    <td align="left" colspan="11">
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                            <tr style="height:20px">
                                                <td style="width:280px"><b>ชื่ออาหาร : </b><%# Eval("FOODNAME") %></td>
                                                <td style="width:250px"><b>จำนวน : </b><%# Eval("QTY") %></td>
                                                <td><b>วัน-เวลาที่บันทึก : </b><%# Eval("MEDORDERDATE", "{0:dd/MM/yyyy HH:mm:ss}") %></td>
                                            </tr>
                                            <tr style="height:20px" class='<%# Eval("CONTROL").ToString() == "" && Eval("LIMIT").ToString() == "" && Eval("INCREASE").ToString() =="" ? "zHidden" : "" %>' >
                                                <td style="width:280px"><b>ควบคุม : </b><%# Eval("CONTROL") %></td>
                                                <td style="width:250px"><b>จำกัดปริมาณ : </b><%# Eval("LIMIT") %></td>
                                                <td><b>อาหารเสริม : </b><%# Eval("INCREASE") %></td>
                                            </tr>
                                            <tr style="height:20px">
                                                <td style="width:280px"><b>ประเภท : </b><%# Eval("FOODTYPENAME") %></td>
                                                <td style="width:250px"><b>ชนิด : </b><%# Eval("FEEDCATEGORYNAME") %></td>
                                                <td></td>
                                            </tr>
                                            <tr style="height:20px">
                                                <td style="width:280px"><b>หมายเหตุ : </b><%# Eval("REMARKS") %></td>
                                                <td style="width:250px"><b>สถานะ : </b><span style="color:Red"><%# Eval("STATUSNAME") %></span></td>
                                                <td></td>
                                            </tr>
                                        </table>
                                    </td> 
                                </tr> 
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerSettings Visible="False" />
            </asp:GridView>
            <uc3:PageControl ID="pcBot" runat="server"  OnPageChange="PageChange"  /> 
        </td>
    </tr>
</table>
<asp:Button ID="btnRegister" runat="server" Text="Button" CssClass="zHidden" />
<cc1:ModalPopupExtender ID="mpeRegister" runat="server" TargetControlID="btnRegister" PopupControlID="pnlRegister" BackgroundCssClass="modalBackground" DropShadow="true"></cc1:ModalPopupExtender>
<asp:Panel ID="pnlRegister" runat="server" CssClass="modalPopup" style="display:none" Width="400px">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="subheadertext">ยืนยันการ Register</td>
        </tr>
        <tr>
            <td>
                <uc2:ToolBarItemCtl ID="tbSaveRegister" runat="server" ToolbarImage="../../Images/save2.png" ToobarTitle="บันทึก" OnClick="tbSaveRegister_Click" />
                <uc2:ToolBarItemCtl ID="tbCancelRegister" runat="server" ToolbarImage="../../Images/icn_back.png" ToobarTitle="ยกเลิก" />
            </td>
        </tr>
        <tr>
            <td><hr style="size:1px" /><asp:Label ID="lbRegisterStatus" runat="server" EnableViewState="False"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="400">
                    <tr style="height:24px">
                        <td style="width:120px; padding-right:10px" align="right">มื้อแรกที่จ่าย :</td>
                        <td>
                            <asp:DropDownList ID="cmbFirstMealRegister" runat="server" CssClass="zComboBox" Width="100px">
                                <asp:ListItem Value="">เลือก</asp:ListItem>
                                <asp:ListItem Value="11">เช้า</asp:ListItem>
                                <asp:ListItem Value="21">กลางวัน</asp:ListItem>
                                <asp:ListItem Value="31">เย็น</asp:ListItem>
                            </asp:DropDownList>
                            <span class="zRemark">*</span></td>
                    </tr> 
                    <tr style="height:24px">
                        <td style="width:120px; padding-right:10px" align="right">วันที่ :</td>
                        <td>
                            <uc1:CalendarControl ID="ctlFirstDateRegister" runat="server" /><span class="zRemark">&nbsp;*</span>
                        </td>
                    </tr> 
                </table> 
            </td>
        </tr>
        <tr>
            <td style="height:24px"></td>
        </tr>
    </table>
</asp:Panel>
<asp:Button ID="btnNonRegister" runat="server" Text="Button" CssClass="zHidden" />
<cc1:ModalPopupExtender ID="mpeNonRegister" runat="server" TargetControlID="btnNonRegister" PopupControlID="pnlNonRegister" BackgroundCssClass="modalBackground" DropShadow="true"></cc1:ModalPopupExtender>
<asp:Panel ID="pnlNonRegister" runat="server" CssClass="modalPopup" style="display:none" Width="400px">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="subheadertext">ยืนยันการ<u><b>ไม่</b></u> Register</td>
        </tr>
        <tr>
            <td>
                <uc2:ToolBarItemCtl ID="tbSaveNonRegister" runat="server" ToolbarImage="../../Images/save2.png" ToobarTitle="บันทึก" OnClick="tbSaveNonRegister_Click" />
                <uc2:ToolBarItemCtl ID="tbCancelNonRegister" runat="server" ToolbarImage="../../Images/icn_back.png" ToobarTitle="ยกเลิก" />
            </td>
        </tr>
        <tr>
            <td><hr style="size:1px" /><asp:Label ID="lbNonRegisterStatus" runat="server" EnableViewState="False"></asp:Label></td>
        </tr>
        <tr style="height:24px">
            <td style="padding-left:20px">เหตุผล :</td>
        </tr>
        <tr>
            <td style="padding-left:20px">
                <asp:TextBox ID="txtReason" runat="server" CssClass="zTextbox" Height="80px" MaxLength="200"
                    TextMode="MultiLine" Width="350px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="height:24px"></td>
        </tr>
    </table>
</asp:Panel>