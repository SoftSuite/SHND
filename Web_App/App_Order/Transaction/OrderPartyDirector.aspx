<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="OrderPartyDirector.aspx.cs" Inherits="App_Order_Transaction_OrderPartyDirector"  Title="SHND : Transaction - Food Order for Party" %>
<%@ Register Src="../../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc3" %>
<%@ Register Src="../../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="headtext">
                สั่งอาหารจัดเลี้ยง(ผู้อำนวยการ)</td>
        </tr>
        <tr>
             <td>
                <uc1:ToolBarItemCtl ID="tbCommit" runat="server" ToobarTitle="ส่งข้อมูล"  ToolbarImage="../../Images/icn_send.png" ClientClick="return confirm('ต้องการส่งข้อมูลที่เลือก ใช่หรือไม่?')" OnClick="tbCommitClick"   />
            </td>
            <td class="zHidden"><uc1:ToolBarItemCtl ID="tbAdd"  runat="server" ToobarTitle="เพิ่มข้อมูล"  ToolbarImage="../../Images/icn_add.png" /></td>

        </tr>
        <tr>
            <td>
                <hr style="size:1px" />
            </td>
        </tr>
        <tr>
            <td style="height: 15px">
                <fieldset style="padding:15px;">
                    <legend style="font-weight:bold">ค้นหา</legend>
                        <table cellspacing="0" cellpadding="0" border="0" width="100%">
                            <tr style="height:15px">
                                <td colspan="5"></td>
                            </tr>
                            <tr style="height:24px">
                                <td style="width:130px; text-align: right; padding-right:10px">
                                    เลขที่การสั่งอาหาร</td>
                                <td style="width:200px;"><asp:TextBox ID="txtCodeFrom" runat="server" CssClass="zTextbox" Width="200px" MaxLength="20"></asp:TextBox></td>
                                <td style="width:30px; text-align:center;">ถึง</td>
                                <td style="width:200px;"><asp:TextBox ID="txtCodeTo" runat="server" CssClass="zTextbox" Width="200px" MaxLength="20"></asp:TextBox></td>
                                <td></td>
                            </tr>
                            <tr style="height:24px">
                                <td style="width:130px; text-align: right; padding-right:10px">
                                    วันที่ต้องการ</td>
                                <td style="width:200px;">
                                    <uc3:CalendarControl ID="ctlDateFrom" runat="server" /></td>
                                <td style="width:30px; text-align:center;">ถึง</td>
                                <td style="width:200px;">
                                    <uc3:CalendarControl ID="ctlDateTo" runat="server" /></td>
                                <td></td>
                            </tr>
                            <tr style="height:24px">
                                <td style="width:130px; text-align: right; padding-right:10px">สถานะการสั่งอาหาร</td>
                                <td style="width:200px;"><asp:DropDownList ID="cmbStatusFrom" runat="server" Width="200px" CssClass="zComboBox"></asp:DropDownList></td>
                                <td style="width:30px; text-align:center;">ถึง</td>
                                <td style="width:200px;"><asp:DropDownList ID="cmbStatusTo" runat="server" Width="200px" CssClass="zComboBox"></asp:DropDownList></td>
                                <td>
                                    &nbsp;<asp:ImageButton ID="imbSearch" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_find.png" OnClick="imbSearch_Click"/>
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
                            <asp:TextBox ID="txhSortField" runat="server" Visible="False" Width="15px"></asp:TextBox><asp:TextBox
                    ID="txhSortDir" runat="server" Visible="False" Width="15px"></asp:TextBox>
            </td>
        </tr>
        
        <tr>
            <td style="width:100%">
                <uc2:PageControl ID="pcTop" runat="server" OnPageChange="PageChange"/>
                <asp:GridView ID="gvMain" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="t_tablestyle" OnRowDataBound="gvMain_RowDataBound" OnSorting="gvMain_Sorting" AllowPaging="True" PageSize="20"  style="width:100%">
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
                        
                        <asp:TemplateField SortExpression="CODE" HeaderText="เลขที่การสั่งอาหาร">
                            <ItemStyle Width="100px" HorizontalAlign="center"></ItemStyle>
                            <HeaderStyle Width="100px" HorizontalAlign="Center"></HeaderStyle>
                            <ItemTemplate>
                            <asp:LinkButton ID="lnkCode" runat="server" Text='<%# Bind("CODE") %>' CommandArgument='<%# Bind("LOID")  %>'  OnClick="linkCode_Click"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
        
                        <asp:BoundField HtmlEncode="False" DataFormatString="{0:dd/MM/yyyy}" DataField="ORDERDATE" SortExpression="ORDERDATE" HeaderText="วันที่ต้องการ">
                            <ItemStyle Width="100px" HorizontalAlign="Center"></ItemStyle>
                            <HeaderStyle Width="100px" HorizontalAlign="Center"></HeaderStyle>
                        </asp:BoundField>
                        
                         <asp:BoundField DataField="DIVISIONNAME" SortExpression="DIVISIONNAME" HeaderText="หน่วยงาน">
                        </asp:BoundField>
                        
                        <asp:BoundField DataField="PARTYTYPENAME" SortExpression="PARTYTYPENAME" HeaderText="ประเภทจัดเลี้ยง">
                        </asp:BoundField>
                        
                          <asp:BoundField HtmlEncode="False" DataFormatString="{0:#,##0}" DataField="VISITORQTY" SortExpression="VISITORQTY" HeaderText="จำนวนผู้รับบริการ">
                            <ItemStyle Width="100px" HorizontalAlign="Right"></ItemStyle>
                            <HeaderStyle Width="100px" HorizontalAlign="Center"></HeaderStyle>
                        </asp:BoundField>
                        
                        <asp:BoundField DataField="STATUSNAME" SortExpression="STATUSNAME" HeaderText="สถานะการสั่งอาหาร">
                            <ItemStyle Width="150px"></ItemStyle>
                            <HeaderStyle Width="150px" HorizontalAlign="Center"></HeaderStyle>
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
    <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" style="display:none" Width="900px">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="headtext">
                สั่งอาหารจัดเลี้ยง (ผู้อำนวยการ)</td>
        </tr>
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbSave" runat="server" ToobarTitle="บันทึก" ToolbarImage="../../Images/save2.png" OnClick="tbSaveClick" />
                <uc1:ToolBarItemCtl ID="tbCancel" runat="server" ToobarTitle="ยกเลิกการแก้ไข" ToolbarImage="../../Images/cancel.png" OnClick="tbCancelClick" />
                <uc1:ToolBarItemCtl ID="tbApprovePOP" runat="server" ToobarTitle="ส่งข้อมูล" ToolbarImage="../../Images/icn_send.png" OnClick="tbApprovePOPClick"/>
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
        </tr>
        <tr>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td style="padding:5px; border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid; width:400px" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" width="500px">
                                <tr style="height:24px">
                                    <td style="width:120px; text-align:right; padding-right:10px">
                                        หน่วยงาน :</td> 
                                    <td colspan="3">
                                        <asp:TextBox ID="txtDivName" runat="server" CssClass="zTextbox-View" MaxLength="100" Width="342px" ReadOnly="True"></asp:TextBox></td>
                                </tr>
                                       <tr style="height:24px">
                                    <td style="width:120px; text-align:right; padding-right:10px">
                                        เลขที่การสั่งอาหาร :</td> 
                                    <td style="width:140px">
                                        <asp:TextBox ID="txtCode" runat="server" CssClass="zTextbox-View" ReadOnly="True" MaxLength="100" Width="125px"></asp:TextBox></td>
                                    <td style="width:60px; padding-right: 10px;" align="right">
                                      วันที่สั่ง :</td> 
                                    <td style="height: 24px; width: 180px;">
                                        <uc3:CalendarControl ID="ctlOrderDate" runat="server" Enabled="False"/>
                                        &nbsp;
                                    </td>
                                </tr>
                                       <tr style="height:24px">
                                    <td style="width:120px; text-align:right; padding-right:10px">
                                        ชื่อผู้สั่ง :</td> 
                                    <td colspan="3">
                                        <asp:DropDownList ID="ddlTitle" runat="server" Enabled="False" Width="100px" CssClass="zComboBox">
                                        </asp:DropDownList>
                                        <asp:TextBox ID="txtName" runat="server" CssClass="zTextbox-View" ReadOnly="True" Width="100px"></asp:TextBox>
                                        <asp:TextBox ID="txtLastName" runat="server" CssClass="zTextbox-View" ReadOnly="True" Width="127px"></asp:TextBox></td>

                                </tr>
                                <tr style="height:24px">
                                    <td style="width:120px; text-align:right; padding-right:10px; height: 24px;">
                                        โทรศัพท์ :</td> 
                                    <td colspan="3" style="height: 24px">
                                        <asp:TextBox ID="txtTel" runat="server" CssClass="zTextbox-View" ReadOnly="True" Width="342px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="height:24px">
                                    <td style="width:120px; text-align:right; padding-right:10px">
                                        วันที่ต้องการ :</td> 
                                    <td style="width:140px">
                                         <uc3:CalendarControl ID="ctlPartyDate" runat="server" Enabled="False"/>
                                    </td>
                                    <td style="width:60px; padding-right: 10px;" align="right">
                                      เวลา:</td> 
                                    <td style="height: 24px; width: 180px;">
                                        <asp:DropDownList ID="ddlPartyTime" Enabled="False" runat="server" Width="86px" CssClass="zComboBox">
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
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                               <tr style="height:24px">
                                    <td style="width:120px; text-align:right; padding-right:10px">
                                        ประเภทการจัดเลี้ยง :</td> 
                                    <td style="width:140px">
                                        <asp:DropDownList ID="ddlPartyType" runat="server" Enabled="False" Width="131px" CssClass="zComboBox">
                                        </asp:DropDownList></td>
                                    <td style="width:60px; padding-right: 10px;" align="right">
                                      จำนวน(ที่):</td> 
                                    <td style="height: 24px; width: 180px;">
                                        <asp:TextBox ID="txtQty" runat="server" CssClass="zTextboxR-View" ReadOnly="True" Width="80px"></asp:TextBox>
                                        
                                    </td>
                                </tr>
                                <tr style="height:24px">
                                    <td style="width:120px; text-align:right; padding-right:10px">
                                        สถานที่ :</td> 
                                    <td colspan="3">
                                        <asp:TextBox ID="txtPlace" runat="server" CssClass="zTextbox-View" ReadOnly="True" Width="342px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width:4px">
                            &nbsp;</td>
                        <td style="border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid; padding:5px" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" width="300px">
                                <tr style="height:24px;">
                                    <td style="width:100px; padding-right:10px;" align="right">
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
                                         <asp:RadioButtonList ID="rblDirector" runat="server">
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
                                         <asp:TextBox ID="txtDirector" runat="server" Width="100px" TextMode="MultiLine" Height="50px"></asp:TextBox></td>
                                     <td><asp:TextBox ID="txtOfficer" runat="server" CssClass="zTextbox-View"  ReadOnly="True" Width="100px" TextMode="MultiLine" Height="50px"></asp:TextBox></td>
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
<asp:TemplateField HeaderText="ลำดับ">
<ItemStyle Width="60px" Height="24px" HorizontalAlign="Center"></ItemStyle>

<HeaderStyle Width="60px"></HeaderStyle>
<ItemTemplate>
<%# Container.DataItemIndex + 1%>
                                                 
</ItemTemplate>
</asp:TemplateField>

<asp:BoundField DataField="FOODCOOKTYPENAME" HeaderText="ประเภทคาวหวาน">
 <ItemStyle HorizontalAlign="Left" Width="160px" />
 <HeaderStyle HorizontalAlign="Center" Width="160px" />
</asp:BoundField>

<asp:BoundField DataField="FORMULASETNAME" HeaderText="รายการ">
</asp:BoundField>
<asp:TemplateField HeaderText="จำนวนที่เบิก">
<ItemStyle Width="80px" Height="24px" HorizontalAlign="Center"></ItemStyle>

<HeaderStyle Width="80px"></HeaderStyle>
<ItemTemplate>
<asp:TextBox ID="txtVisitorQty" Width="75px" CssClass="zTextboxR-View"  ReadOnly="True" runat="server" Text=<%# DataBinder.Eval(Container.DataItem, "VISITORQTY") %>></asp:TextBox>
 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="จำนวนที่รับจัด">
<ItemStyle Width="80px" Height="24px" HorizontalAlign="Center"></ItemStyle>

<HeaderStyle Width="80px"></HeaderStyle>
<ItemTemplate>
<asp:TextBox ID="txtServiceQty" Width="75px" CssClass="zTextboxR-View"  ReadOnly="True" runat="server" Text=<%# DataBinder.Eval(Container.DataItem, "SERVICEQTY") %>></asp:TextBox>
 
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
</asp:Panel>
</asp:Content>
