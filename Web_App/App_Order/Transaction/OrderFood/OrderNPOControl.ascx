<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OrderNPOControl.ascx.cs" Inherits="App_Order_Transaction_OrderFood_OrderNPOControl" %>
<%@ Register Src="../../../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc2" %>
<%@ Register Src="../../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<cc1:ModalPopupExtender ID="popupOrder"  runat="server" PopupControlID="pnlOrder" BackgroundCssClass="modalBackground" DropShadow="true" TargetControlID="btntest" ></cc1:ModalPopupExtender>
<asp:Panel ID="pnlOrder" runat="server" CssClass="modalPopup" style="display:none" Width="800px">
    <table border="0" cellspacing="0" cellpadding="0" width="100%" >
        <tr>
            <td class="headtext">อาหารที่แพทย์สั่ง
            </td>
        </tr>
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbSave" runat="server" ToobarTitle="บันทึก" ToolbarImage="../../Images/save2.png" OnClick="tbSaveClick" />
                <uc1:ToolBarItemCtl ID="tbCancel" runat="server" ToobarTitle="ยกเลิกการแก้ไข" ToolbarImage="../../Images/cancel.png" OnClick="tbCancelClick" />
                <uc1:ToolBarItemCtl ID="tbBack" runat="server" ToobarTitle="กลับหน้ารายการ" ToolbarImage="../../Images/icn_back.png" />
                <uc1:ToolBarItemCtl ID="tbDiscontinue" runat="server" ToobarTitle="Discontinue" ToolbarImage="../../Images/icn_cancel.png" OnClick="tbDiscontinueClick" />
            </td>
        </tr>
        <tr>
            <td style="height:30px;" valign="top">
                <hr style="size:1px" />
                <asp:Label ID="lbStatus" runat="server" EnableViewState="False"></asp:Label>
                <asp:TextBox ID="txtLOID" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
                <asp:TextBox ID="txtStatus" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
                <asp:TextBox ID="txtAdmitPatient" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
                <asp:TextBox ID="txtIsView" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="700">
                    <tr style="height:24px">
                        <td style="width:150px; padding-right:10px" align="right">เริ่ม :
                        </td>
                        <td style="width: 550px">
                            <uc2:CalendarControl ID="ctlFirstDate" runat="server" />
                            &nbsp; เวลา&nbsp;
                            <asp:DropDownList ID="cmbFirstTime" runat="server" CssClass="zComboBox" Width="80px">
                                <asp:ListItem Text="" Value="-1"></asp:ListItem>
                                <asp:ListItem Text="00.00 น." Value="0"></asp:ListItem>
                                <asp:ListItem Text="01.00 น." Value="1"></asp:ListItem>
                                <asp:ListItem Text="02.00 น." Value="2"></asp:ListItem>
                                <asp:ListItem Text="03.00 น." Value="3"></asp:ListItem>
                                <asp:ListItem Text="04.00 น." Value="4"></asp:ListItem>
                                <asp:ListItem Text="05.00 น." Value="5"></asp:ListItem>
                                <asp:ListItem Text="06.00 น." Value="6"></asp:ListItem>
                                <asp:ListItem Text="07.00 น." Value="7"></asp:ListItem>
                                <asp:ListItem Text="08.00 น." Value="8"></asp:ListItem>
                                <asp:ListItem Text="09.00 น." Value="9"></asp:ListItem>
                                <asp:ListItem Text="10.00 น." Value="10"></asp:ListItem>
                                <asp:ListItem Text="11.00 น." Value="11"></asp:ListItem>
                                <asp:ListItem Text="12.00 น." Value="12"></asp:ListItem>
                                <asp:ListItem Text="13.00 น." Value="13"></asp:ListItem>
                                <asp:ListItem Text="14.00 น." Value="14"></asp:ListItem>
                                <asp:ListItem Text="15.00 น." Value="15"></asp:ListItem>
                                <asp:ListItem Text="16.00 น." Value="16"></asp:ListItem>
                                <asp:ListItem Text="17.00 น." Value="17"></asp:ListItem>
                                <asp:ListItem Text="18.00 น." Value="18"></asp:ListItem>
                                <asp:ListItem Text="19.00 น." Value="19"></asp:ListItem>
                                <asp:ListItem Text="20.00 น." Value="20"></asp:ListItem>
                                <asp:ListItem Text="21.00 น." Value="21"></asp:ListItem>
                                <asp:ListItem Text="22.00 น." Value="22"></asp:ListItem>
                                <asp:ListItem Text="23.00 น." Value="23"></asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;<span class="zRemark">*</span>
                        </td>
                    </tr> 
                    <tr style="height: 24px">
                        <td align="right" style="padding-right: 10px; width: 150px">
                            จำนวนชั่วโมงที่งด :</td>
                        <td style="width: 550px">
                            <asp:TextBox ID="txtNPOPeriod" runat="server" CssClass="zTextboxR" Width="100px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="height:24px">
                        <td style="width:150px; padding-right:10px" align="right">ถึง :
                        </td>
                        <td style="width: 550px">
                            <uc2:CalendarControl ID="ctlEndDate" runat="server" Enabled="false" />
                            &nbsp; เวลา&nbsp;
                            <asp:DropDownList ID="cmbEndTime" runat="server" CssClass="zComboBox" Width="80px" Enabled="False">
                                <asp:ListItem Text="" Value="-1"></asp:ListItem>
                                <asp:ListItem Text="00.00 น." Value="0"></asp:ListItem>
                                <asp:ListItem Text="01.00 น." Value="1"></asp:ListItem>
                                <asp:ListItem Text="02.00 น." Value="2"></asp:ListItem>
                                <asp:ListItem Text="03.00 น." Value="3"></asp:ListItem>
                                <asp:ListItem Text="04.00 น." Value="4"></asp:ListItem>
                                <asp:ListItem Text="05.00 น." Value="5"></asp:ListItem>
                                <asp:ListItem Text="06.00 น." Value="6"></asp:ListItem>
                                <asp:ListItem Text="07.00 น." Value="7"></asp:ListItem>
                                <asp:ListItem Text="08.00 น." Value="8"></asp:ListItem>
                                <asp:ListItem Text="09.00 น." Value="9"></asp:ListItem>
                                <asp:ListItem Text="10.00 น." Value="10"></asp:ListItem>
                                <asp:ListItem Text="11.00 น." Value="11"></asp:ListItem>
                                <asp:ListItem Text="12.00 น." Value="12"></asp:ListItem>
                                <asp:ListItem Text="13.00 น." Value="13"></asp:ListItem>
                                <asp:ListItem Text="14.00 น." Value="14"></asp:ListItem>
                                <asp:ListItem Text="15.00 น." Value="15"></asp:ListItem>
                                <asp:ListItem Text="16.00 น." Value="16"></asp:ListItem>
                                <asp:ListItem Text="17.00 น." Value="17"></asp:ListItem>
                                <asp:ListItem Text="18.00 น." Value="18"></asp:ListItem>
                                <asp:ListItem Text="19.00 น." Value="19"></asp:ListItem>
                                <asp:ListItem Text="20.00 น." Value="20"></asp:ListItem>
                                <asp:ListItem Text="21.00 น." Value="21"></asp:ListItem>
                                <asp:ListItem Text="22.00 น." Value="22"></asp:ListItem>
                                <asp:ListItem Text="23.00 น." Value="23"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr> 
                    <tr style="height: 24px">
                        <td align="right" style="padding-right: 10px; width: 150px" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" width="100px">
                                <tr style="height:24px">
                                    <td align="right">หมายเหตุ :</td> 
                                </tr>
                            </table>
                        </td>
                        <td style="width: 550px">
                            <asp:TextBox ID="txtRemarks" runat="server" CssClass="zTextbox" Width="500px" TextMode="multiline" Height="60px" MaxLength="200"></asp:TextBox>
                        </td>
                    </tr>
                </table> 
            </td>
        </tr>
    </table>
</asp:Panel>
<asp:Button ID="btntest" runat="server" Text="test" CssClass="zHidden" />