<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="OrderParty.aspx.cs" Inherits="App_Order_Transaction_OrderParty" Title="SHND : Transaction - Food Order for Party" %>

<%@ Register Src="../../Templates/CalendarControl.ascx" TagName="CalendarControl"
    TagPrefix="uc2" %>

<%@ Register Src="../../Search/OrderPartyPopup.ascx" TagName="OrderPartyPopup" TagPrefix="uc3" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <script language="JavaScript" type="text/javascript">
    </script>
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="headtext">
                สั่งอาหารจัดเลี้ยง (หน่วยงาน) </td>
        </tr>
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbSave" runat="server" ToobarTitle="บันทึก" ToolbarImage="../../Images/save2.png" OnClick="tbSaveClick" />
                <uc1:ToolBarItemCtl ID="tbCancel" runat="server" ToobarTitle="ยกเลิกการแก้ไข" ToolbarImage="../../Images/cancel.png" OnClick="tbCancelClick" />
                <uc1:ToolBarItemCtl ID="tbApprove" runat="server" ToobarTitle="ส่งข้อมูล" ToolbarImage="../../Images/icn_send.png" OnClick="tbApproveClick"/>
                <uc1:ToolBarItemCtl ID="tbBack" runat="server" ToobarTitle="กลับหน้ารายการ" ToolbarImage="../../Images/icn_back.png" OnClick="tbBackClick"/>

            </td>
        </tr>
        <tr>
            <td style="height:30px" valign="top">
                <hr style="size:1px" />
                <asp:Label ID="lbStatus" runat="server" EnableViewState="False"></asp:Label>
                <asp:TextBox ID="txtLOID" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
                <asp:TextBox ID="txtStatus" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
                <asp:TextBox ID="txtDivision" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
            </td> 
        </tr>
        <tr>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td style="padding:5px; border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid; width:500px" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" width="520">
                                <tr style="height:24px">
                                    <td style="width:120px; text-align:right; padding-right:10px">
                                        หน่วยงาน:</td> 
                                    <td colspan="3">
                                        <asp:TextBox ID="txtDivName" runat="server" CssClass="zTextbox-View" MaxLength="100" Width="362px" ReadOnly="True"></asp:TextBox></td>
                                </tr>
                                       <tr style="height:24px">
                                    <td style="width:120px; text-align:right; padding-right:10px">
                                        เลขที่การสั่งอาหาร:</td> 
                                    <td style="width:160px">
                                        <asp:TextBox ID="txtCode" runat="server" CssClass="zTextbox-View" ReadOnly="True" MaxLength="100" Width="125px"></asp:TextBox></td>
                                    <td style="width:65px; padding-right: 10px;" align="right">
                                      วันที่สั่ง :</td> 
                                    <td>
                                        <uc2:CalendarControl ID="ctlOrderDate" Enabled="false" runat="server" /><span class="zRemark">*</span>
                                    </td>
                                </tr>
                                       <tr style="height:24px">
                                    <td style="width:120px; text-align:right; padding-right:10px">
                                        ชื่อผู้สั่ง:</td> 
                                    <td colspan="3">
                                        <asp:DropDownList ID="ddlTitle" runat="server" CssClass="zComboBox" Width="100px">
                                        </asp:DropDownList>
                                        <asp:TextBox ID="txtName" runat="server" CssClass="zTextbox" Width="100px"></asp:TextBox>
                                        <asp:TextBox ID="txtLastName" runat="server" CssClass="zTextbox" Width="148px"></asp:TextBox>
                                        <span class="zRemark">*</span>
                                    </td>

                                </tr>
                                <tr style="height:24px">
                                    <td style="width:120px; text-align:right; padding-right:10px">
                                        โทรศัพท์:</td> 
                                    <td colspan="3">
                                        <asp:TextBox ID="txtTel" runat="server" CssClass="zTextbox" Width="362px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="height:24px">
                                    <td style="width:120px; text-align:right; padding-right:10px">
                                      วันที่ต้องการ:</td> 
                                    <td style="width:160px">
                                         <uc2:CalendarControl ID="ctlPartyDate" runat="server" /><span class="zRemark">*</span></td>
                                    <td style="width:65px; padding-right: 10px;" align="right">
                                        เวลา :</td> 
                                    <td>
                                        <asp:DropDownList ID="ddlPartyTime" runat="server" CssClass="zComboBox" Width="80px">
                                            <asp:ListItem Value="">เลือก</asp:ListItem>
                                            <asp:ListItem Value="6">06.00</asp:ListItem>
                                            <asp:ListItem Value="7">07.00</asp:ListItem>
                                            <asp:ListItem Value="8">08.00</asp:ListItem>
                                             <asp:ListItem Value="9">09.00</asp:ListItem>
                                            <asp:ListItem Value="10">10.00</asp:ListItem>
                                            <asp:ListItem Value="11">11.00</asp:ListItem>
                                             <asp:ListItem Value="12">12.00</asp:ListItem>
                                            <asp:ListItem Value="13">13.00</asp:ListItem>
                                            <asp:ListItem Value="14">14.00</asp:ListItem>
                                             <asp:ListItem Value="15">15.00</asp:ListItem>
                                            <asp:ListItem Value="16">16.00</asp:ListItem>
                                            <asp:ListItem Value="17">17.00</asp:ListItem>
                                             <asp:ListItem Value="18">18.00</asp:ListItem>
                                            <asp:ListItem Value="19">19.00</asp:ListItem>
                                            <asp:ListItem Value="20">20.00</asp:ListItem>
                                             <asp:ListItem Value="21">21.00</asp:ListItem>
                                            <asp:ListItem Value="22">22.00</asp:ListItem>
                                            <asp:ListItem Value="23">23.00</asp:ListItem>
                                             <asp:ListItem Value="0">00.00</asp:ListItem>
                                            <asp:ListItem Value="1">01.00</asp:ListItem>
                                            <asp:ListItem Value="2">02.00</asp:ListItem>
                                             <asp:ListItem Value="3">03.00</asp:ListItem>
                                            <asp:ListItem Value="4">04.00</asp:ListItem>
                                            <asp:ListItem Value="5">05.00</asp:ListItem>
                                        </asp:DropDownList>&nbsp;<span class="zRemark">*</span>
                                    </td>
                                </tr>
                               <tr style="height:24px">
                                    <td style="width:120px; text-align:right; padding-right:10px">
                                     ประเภทการจัดเลี้ยง:</td> 
                                    <td style="width:160px">
                                        <asp:DropDownList ID="ddlPartyType" runat="server" CssClass="zComboBox" Width="131px">
                                        </asp:DropDownList>
                                        <span class="zRemark">*</span>
                                    </td>
                                    <td style="width:65px; padding-right: 10px;" align="right">
                                        จำนวน(ที่) :</td> 
                                    <td>
                                        <asp:TextBox ID="txtQty" runat="server" CssClass="zTextboxR" Width="74px"></asp:TextBox>
                                        <span class="zRemark">*</span>
                                    </td>
                                </tr>
                                <tr style="height:24px">
                                    <td style="width:120px; text-align:right; padding-right:10px">
                                        สถานที่:</td> 
                                    <td colspan="3">
                                        <asp:TextBox ID="txtPlace" runat="server" CssClass="zTextbox" Width="362px"></asp:TextBox>
                                        <span class="zRemark">*</span>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width:4px">
                            &nbsp;</td>
                        <td style="border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid; padding:5px" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" width="300px">
                                <tr style="height:24px;">
                                    <td style="width:45px; padding-right:10px;">
                                        สถานะ :</td> 
                                    <td>
                                        <asp:TextBox ID="txtStatusName" runat="server" CssClass="zTextbox-View" ReadOnly="True" Width="150px"></asp:TextBox></td> 
                                </tr>
                                <tr style="height: 24px">
                                    <td colspan="2">
                                     <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                     <tr style="height: 24px"> 
                                     <td style="width:150px">ผู้อำนวยการ</td>
                                     <td>ฝ่ายโภชนาการ</td>
                                     </tr>
                                       <tr style="height: 24px"> 
                                     <td style="width:150px">
                                         <asp:RadioButtonList ID="rblDirector" runat="server" Enabled="False">
                                             <asp:ListItem Value="Y">อนุมัติ</asp:ListItem>
                                             <asp:ListItem Value="N">ไม่อนุมัติ</asp:ListItem>
                                         </asp:RadioButtonList></td>
                                     <td><asp:RadioButtonList ID="rblOfficer" runat="server" Enabled="False">
                                         <asp:ListItem Value="Y">รับ Order</asp:ListItem>
                                         <asp:ListItem Value="N">ไม่รับ Order</asp:ListItem>
                                         </asp:RadioButtonList></td>
                                     </tr>
                                     <tr style="height: 24px"> 
                                     <td style="width:150px">ความเห็น</td>
                                     <td>ความเห็น</td>
                                     </tr>
                                    <tr> 
                                     <td style="width:150px">
                                         <asp:TextBox ID="txtDirector" runat="server" CssClass="zTextbox-View"  ReadOnly="True" Width="125px" TextMode="MultiLine" Height="50px"></asp:TextBox></td>
                                     <td><asp:TextBox ID="txtOfficer" runat="server" CssClass="zTextbox-View"  ReadOnly="True" Width="125px" TextMode="MultiLine" Height="50px"></asp:TextBox></td>
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
            <td style="height:5px">
            </td>
        </tr>
         <tr>
                                    <td class="toolbarplace">
                                        <uc1:ToolBarItemCtl ID="tbAddOrderPartyItem" runat="server" ToobarTitle="เพิ่มรายการ" ToolbarImage="../../Images/icn_add.png" OnClick="tbAddOrderPartyItemClick" />
                                        <uc1:ToolBarItemCtl ID="tbDeleteOrderPartyItem" runat="server" ToobarTitle="ลบรายการ" ToolbarImage="../../Images/icn_delete.png" OnClick="tbDeleteOrderPartyItemClick" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbStatusOrderPartyItem" runat="server" EnableViewState="False"></asp:Label></td> 
                                </tr> 

                                <tr>
                                    <td>
                                        <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="False" CssClass="t_tablestyle" DataSourceID="OrderPartySource" Width="100%" >
                                            <PagerSettings Visible="False" />
                                            <Columns>
<asp:BoundField DataField="RANK" HeaderText="RANK">
<ControlStyle CssClass="zHidden"></ControlStyle>

<ItemStyle CssClass="zHidden"></ItemStyle>

<HeaderStyle CssClass="zHidden"></HeaderStyle>

<FooterStyle CssClass="zHidden"></FooterStyle>
</asp:BoundField>
<asp:BoundField DataField="LOID" HeaderText="LOID">
<ControlStyle CssClass="zHidden"></ControlStyle>

<ItemStyle CssClass="zHidden"></ItemStyle>

<HeaderStyle CssClass="zHidden"></HeaderStyle>

<FooterStyle CssClass="zHidden"></FooterStyle>
</asp:BoundField>
<asp:TemplateField><HeaderTemplate>
                                                <input type="checkbox" name="chkMain" id="chkMain" onclick="chkAllBox(this, 'ctl00_MainContent_tabStdMenu_tabStdMenuDisease_gvStdMenuDisease_ctl', '_chkSelect')" />                                                    
                                                
</HeaderTemplate>

<ItemStyle Width="30px" HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>

<HeaderStyle Width="30px" HorizontalAlign="Center"></HeaderStyle>
<ItemTemplate>
                                                <asp:CheckBox ID="chkSelect" runat="server" />                                                   
                                                
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="ลำดับ">
<ItemStyle Width="60px" Height="24px" HorizontalAlign="Center"></ItemStyle>

<HeaderStyle Width="60px"></HeaderStyle>
<ItemTemplate>
<%# Container.DataItemIndex + 1%>
                                                 
</ItemTemplate>
</asp:TemplateField>

<asp:BoundField DataField="FOODCOOKTYPENAME" HeaderText="ประเภทคาวหวาน">
<ItemStyle Width="150px"></ItemStyle>

<HeaderStyle Width="150px"></HeaderStyle>
</asp:BoundField>

<asp:BoundField DataField="FORMULASETNAME" HeaderText="รายการ">
</asp:BoundField>
<asp:TemplateField HeaderText="จำนวนที่เบิก">
<ItemStyle Width="80px" HorizontalAlign="Center"></ItemStyle>

<HeaderStyle Width="80px"></HeaderStyle>
<ItemTemplate>
<asp:TextBox ID="txtVisitorQty" Width="75px" CssClass="zTextboxR" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "VISITORQTY") %>'></asp:TextBox>
 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="จำนวนที่รับจัด">
<ItemStyle Width="100px" Height="24px" HorizontalAlign="Center"></ItemStyle>

<HeaderStyle Width="100px"></HeaderStyle>
<ItemTemplate>
<asp:TextBox ID="txtServiceQty" Width="95px" CssClass="zTextboxR-View"  ReadOnly="True" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SERVICEQTY") %>'></asp:TextBox>
 
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="FORMULASET" HeaderText="FORMULASET">
<ControlStyle CssClass="zHidden"></ControlStyle>

<ItemStyle CssClass="zHidden"></ItemStyle>

<HeaderStyle CssClass="zHidden"></HeaderStyle>

<FooterStyle CssClass="zHidden"></FooterStyle>
</asp:BoundField>
</Columns>
                                            <HeaderStyle CssClass="t_headtext" />
                                            <AlternatingRowStyle CssClass="t_alt_bg" />
                                        </asp:GridView>
                                        <asp:ObjectDataSource ID="OrderPartySource" runat="server" SelectMethod="GetOrderPartyItemList" TypeName="OrderPartyItem">
                                            <SelectParameters>
<asp:ControlParameter PropertyName="Text" Type="Double" DefaultValue="0" Name="OrderParty" ControlID="txtLOID"></asp:ControlParameter>
</SelectParameters>
                                        </asp:ObjectDataSource>
                                    </td> 
                                </tr>
                           
    </table> 
    <uc3:OrderPartyPopup id="ctlOrderPartyPopup" runat="server" OnSelectedIndexChanged="ctlOrderPartyPopup_SelectedIndexChanged" />
</asp:Content>
