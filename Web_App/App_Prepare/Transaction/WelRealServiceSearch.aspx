<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="WelRealServiceSearch.aspx.cs" Inherits="App_Prepare_Transaction_WelRealServiceSearch" Title="SHND : Transaction - WelRealServiceSearch" %>
<%@ Register Src="../../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc3" %>
<%@ Register Src="../../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="headtext">
                ข้อมูลจำนวนผู้รับบริการอาหารสวัสดิการ</td>
        </tr>
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbAdd" runat="server" ToobarTitle="เพิ่มข้อมูล" OnClick="tbAddClick" ToolbarImage="../../Images/icn_add.png"  />
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
                        <td colspan="2">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width:120px; text-align: right; padding-right:10px; height: 24px;">ผู้ใช้บริการ :</td>
                        <td style="height: 24px"><asp:DropDownList ID="cmbSearchDiv" runat="server" Width="206px">
                </asp:DropDownList></td>
                    </tr>
                    <tr style="height:24px">
                        <td style="width:120px; text-align: right; padding-right:10px">วันที่ :</td>
                        <td><uc3:CalendarControl ID="ctlSearchDateFrom" runat="server" />&nbsp; ถึง 
                        <uc3:CalendarControl ID="ctlSearchDateTo" runat="server" /> &nbsp;
                <asp:ImageButton ID="imbSearch" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_find.png" OnClick="imbSearch_Click"
                                 /><asp:ImageButton ID="imbReset" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_back.png"
                    OnClick="imbReset_Click" ToolTip="แสดงทั้งหมด" />
                    </td></tr>
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
                <uc2:PageControl ID="pcTop" runat="server" OnPageChange="PageChange"/>
                <asp:GridView ID="gvMain" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="t_tablestyle" OnRowDataBound="gvMain_RowDataBound" 
                    OnSorting="gvMain_Sorting" AllowPaging="True" PageSize="20" width="100%">
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
                            <HeaderStyle Width="60px" />
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </asp:TemplateField>
                        <asp:BoundField  HtmlEncode="False" DataFormatString="{0:dd/MM/yyyy}" DataField="SERVICEDATE" HeaderText="วันที่" SortExpression="SERVICEDATE">
                            <HeaderStyle HorizontalAlign="Center" Width="150px" />
                            <ItemStyle HorizontalAlign="Center" Width="150px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="ผู้ใช้บริการ" SortExpression="DIVISIONNAME">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkFood" runat="server" Text='<%# Bind("DIVISIONNAME") %>' OnClick="lnkFood_Click" CommandArgument='<%# Bind("LOID")  %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="COUPON" HeaderText="จำนวนคูปอง" SortExpression="COUPON">
                            <HeaderStyle HorizontalAlign="Center" Width="150px" />
                            <ItemStyle HorizontalAlign="Center" Width="150px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TIFFIN" HeaderText="จำนวนปิ่นโต" SortExpression="TIFFIN">
                            <HeaderStyle HorizontalAlign="Center" Width="150px" />
                            <ItemStyle HorizontalAlign="Center" Width="150px" />
                        </asp:BoundField>
                    </Columns>
                    <HeaderStyle CssClass="t_headtext" />
                    <AlternatingRowStyle CssClass="t_alt_bg" />
                    <PagerSettings Visible="False" />
                </asp:GridView><uc2:PageControl ID="pcBot" runat="server" OnPageChange="PageChange" />
                </td>
        </tr>
    </table>
    <cc1:ModalPopupExtender ID="zPop" runat="server" TargetControlID="tbAdd$lb" PopupControlID="Panel1" BackgroundCssClass="modalBackground" DropShadow="true"></cc1:ModalPopupExtender>
    <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" style="display:none" Width="800px">
    <table cellspacing="0" cellpadding="0" border="0" width="100%">
        <tr>
            <td>
        <uc1:ToolBarItemCtl ID="tbSave" runat="server" ToobarTitle="บันทึก" ToolbarImage="../../Images/save2.png" OnClick="tbSave1Click" />
        <uc1:ToolBarItemCtl ID="tbCancel" runat="server" ToobarTitle="ยกเลิกการแก้ไข" ToolbarImage="../../Images/cancel.png" OnClick="tbCancelClick" />
                <uc1:ToolBarItemCtl ID="tbBack" runat="server" ToobarTitle="กลับหน้ารายการ" ToolbarImage="../../Images/icn_back.png" OnClick="tbBackClick"/>
            </td>
        </tr>
        <tr>
            <td><hr style="size:1px" /></td>
        </tr>
        <tr>
            <td>
                <table cellpadding="5">
                    <tr>
                        <td align="right" style="width: 150px">
                            <asp:TextBox ID="txhSortField" runat="server" Visible="False" Width="15px"></asp:TextBox><asp:TextBox
                                ID="txhSortDir" runat="server" Visible="False" Width="15px"></asp:TextBox><asp:TextBox
                                    ID="txhID" runat="server" Visible="False" Width="15px"></asp:TextBox></td>
                        <td colspan="3">
                            <asp:Label ID="lbStatus" runat="server" EnableViewState="False"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width:150px" align="right"> วันที่ :</td>
                        <td colspan="3">
                            <uc3:CalendarControl ID="ctlServiceDate" runat="server"  /> <span style="color:red">*</span></td>
                    </tr>
                    <tr>
                        <td style="width:150px" align="right"> ผู้ใช้บริการ :</td>
                        <td colspan="3">
                            <asp:DropDownList ID="cmbDivision" runat="server" CssClass="zComboBox" Width="200px" OnSelectedIndexChanged="cmbDivision_SelectedIndexChanged" AutoPostBack="true" >
                            </asp:DropDownList> <span style="color:red">*</span></td>
                    </tr>
                    <tr>
                        <td style="width:150px" align="right"> จำนวนผู้มีสิทธิ์ :</td>
                        <td><asp:TextBox ID="txtCoupon" CssClass="zTextboxR-View" ReadOnly="true" runat="server"></asp:TextBox>
                            </td>
                         <td> ปิ่นโต :</td>
                        <td><asp:TextBox ID="txtTiffin" CssClass="zTextboxR-View" ReadOnly="true" runat="server"></asp:TextBox>
                            </td>
                    </tr>
                    <tr>
                        <td style="width:150px" align="right"> จำนวนผู้ใช้บริการ :</td>
                        <td><asp:TextBox ID="txtCouponUse" CssClass="zTextboxR" runat="server"></asp:TextBox>
                            </td>
                        <td> ปิ่นโต :</td>
                        <td><asp:TextBox ID="txtTiffinUse" CssClass="zTextboxR" runat="server"></asp:TextBox>
                            </td>
                    </tr>
                    
                </table>
                <br />
                <br />
            </td>
        </tr>
    </table>
    </asp:Panel>
</asp:Content>

