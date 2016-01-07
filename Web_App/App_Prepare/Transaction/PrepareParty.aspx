<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="PrepareParty.aspx.cs" Inherits="App_Prepare_Transaction_PrepareParty" Title="SHND : Transaction - Prepare Party" %>



<%@ Register Src="../../Templates/CalendarControl.ascx" TagName="CalendarControl"
    TagPrefix="uc4" %>
<%@ Register Src="../../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="headtext">
                ข้อมูลการเตรียมอาหารจัดเลี้ยง</td>
        </tr>

    </table>
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr style="display:none;">
            <td>
                <uc1:ToolBarItemCtl ID="tbAdd" runat="server" ToobarTitle="เพิ่มข้อมูล"    ToolbarImage="../../Images/icn_add.png"  />
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
                ค้นหาข้อมูลการสั่งอาหารจัดเลี้ยง
            </legend>
            
                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                    <tr style="height:15px">
                        <td colspan="4" style="height: 25px">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align: right; padding-right:10px; height: 30px; width: 173px;">
                            เลขที่การสั่งอาหาร :</td>
                        <td style="height: 22px; ">
                            <asp:TextBox ID = "txtOrderCodeFrom" runat = "server" CssClass ="zTextbox" ></asp:TextBox>
                            &nbsp; &nbsp; &nbsp; ถึง : &nbsp;<asp:TextBox ID = "txtOrderCodeTo" runat = "server" CssClass ="zTextbox" ></asp:TextBox> </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; padding-right:10px; height: 22px; width: 173px;">
                            วันที่การสั่งอาหาร:</td>
                        <td style="height: 22px; ">
                            <uc4:CalendarControl ID="ctlOrderDateFrom" runat="server" />
                            &nbsp; &nbsp; &nbsp;ถึง : &nbsp;<uc4:CalendarControl ID="ctlOrderDateTo" runat="server" />
                        </td>                
                    </tr>
                    <tr>
                        <td style="text-align: right; padding-right:10px; height: 22px; width: 173px;">
                            วันที่จัดเลี้ยง:</td>
                        <td style="height: 22px; ">
                            <uc4:CalendarControl ID="ctlPartyDateFrom" runat="server" />
                            &nbsp; &nbsp; &nbsp;ถึง : &nbsp;<uc4:CalendarControl ID="ctlPartyDateto" runat="server" />
                        </td>                
                    </tr>
                    <tr style="height:30px">
                        <td style="text-align: right; padding-right:10px; height: 22px; width: 173px;">
                            หน่วยงาน :</td>  
                        <td colspan = "5" style=" height: 22px;">
                            <asp:DropDownList ID="cmbSearchDivision" Width ="320px" runat="server" CssClass ="zCombo"></asp:DropDownList>
                        </td>            
                    </tr>
                    <tr  style="height:30px">
                        <td style="text-align: right; padding-right:10px; height: 22px; width: 173px;">
                            ประเภทการจัดเลี้ยง :</td>  
                        <td colspan = "5" style=" height: 22px;">
                            <asp:DropDownList ID="cmbSearchType" Width ="320px" runat="server" CssClass ="zCombo"></asp:DropDownList>
                           &nbsp; &nbsp; &nbsp;
                            <asp:ImageButton ID="imbSearch" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_find.png" OnClick="imbSearch_Click"/>

                        </td>            
                    </tr>                   
                     
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
                <uc2:PageControl ID="pcTop" runat="server"  OnPageChange="PageChange" Visible="false"/>
                <asp:GridView ID="grvResult" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="t_tablestyle" PageSize="20" AllowPaging="True"  OnSorting="grvResult_Sorting" OnRowDataBound="grvResult_RowDataBound" >
                    <Columns>
                        <asp:BoundField DataField="OPLOID" HeaderText="OPLOID">
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
                        <asp:TemplateField>
                           <ItemTemplate>
                                <asp:ImageButton ID="imgPrint" runat="server" ImageUrl="~/Images/icn_print.png" CommandName= "Select" />
                           </ItemTemplate>
                           <ItemStyle HorizontalAlign="Center" Width="60px" />
                           <HeaderStyle Width="60px" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="ลำดับ" SortExpression="DEFAULT">
                            <HeaderStyle Width="60px" />
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="เลขที่การสั่งอาหาร" SortExpression="ORDERCODE" >
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkType" runat="server" OnClick="lnkType_Click" Text='<%# Bind("ORDERCODE") %>' CommandArgument='<%# Bind("OPLOID")  %>'></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="ORDERDATE" HeaderText="วันที่ส่ง" SortExpression ="ORDERDATE" >
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundField>
                        
                        <asp:BoundField DataField="PARTYFULLDATETIME" HeaderText="วันที่จัดเลี้ยง" SortExpression ="PARTYFULLDATETIME" >
                            <HeaderStyle HorizontalAlign="Center" Width="140px" />
                            <ItemStyle HorizontalAlign="left" Width="140px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PARTYTYPE" HeaderText="ประเภทการจัดเลี้ยง" SortExpression ="PARTYTYPE" >
                            <HeaderStyle HorizontalAlign="Center" Width="120px" />
                            <ItemStyle HorizontalAlign="left" Width="120px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DIVISIONNAME" HeaderText="หน่วยงาน" SortExpression ="DIVISIONNAME" >
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle HorizontalAlign="left" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="VISITORQTY" HeaderText="จำนวนผู้รับบริการ" SortExpression ="VISITORQTY" >
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle HorizontalAlign="right"  Width="100px" />
                        </asp:BoundField>
                         <asp:BoundField DataField="PLACE" HeaderText="สถานที่จัดเลี้ยง" SortExpression ="PLACE" >
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                             <ItemStyle HorizontalAlign="Center" Width="100px" />
                          </asp:BoundField>
                        <asp:BoundField DataField="STATUSNAME" HeaderText="สถานะ" SortExpression ="STATUSNAME" >
                            <HeaderStyle HorizontalAlign="Center" Width="120px" />
                            <ItemStyle HorizontalAlign="Center" Width="120px" />
                        </asp:BoundField>

                    </Columns>
                    <HeaderStyle CssClass="t_headtext" />
                    <AlternatingRowStyle CssClass="t_alt_bg" />
                    <PagerSettings Visible="False" />
                </asp:GridView><uc2:PageControl ID="pcBot" runat="server" Visible="false" OnPageChange="PageChange" />
                </td>
        </tr>
    </table>
     <cc1:ModalPopupExtender ID="PreparePartyPop" runat="server" TargetControlID="tbAdd$lb" PopupControlID="Panel1" BackgroundCssClass="modalBackground" DropShadow="true"></cc1:ModalPopupExtender>
    <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" style="display:none" Width="950px">
    <table cellspacing="0" cellpadding="0" border="0" width="100%" >
        <tr>
            <td class="headtext" colspan="2" >
                ข้อมูลการเตรียมอาหารจัดเลี้ยง</td> 
        </tr>
         <tr>
            <td colspan="2" >
                <hr style="size:1px" />
            </td>
       </tr>
        <tr>
            <td style="height: 20px; width: 549px;">
        <uc1:ToolBarItemCtl ID="tbPrint" runat ="server" ToolbarImage="../../Images/icn_print.png" ToobarTitle ="พิมพ์" />
        <uc1:ToolBarItemCtl ID="tbBack" runat="server" ToobarTitle="กลับหน้ารายการ" ToolbarImage="../../Images/icn_back.png" OnClick ="tbBack_Click" />
            </td>
            <td  valign="top" style="height: 20px">&nbsp;
           </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 549px"  ></td>
            <td  valign="top">&nbsp;
           </td>
        </tr>
        <tr>
            <td  valign="top" style="width: 549px">
            <fieldset >
                <table cellpadding="5" >
                    <tr>
                        <td align="right" style="width: 456px" >
                            <asp:TextBox ID="txhID" runat="server" Height="5px" Visible="False" Width="1px"></asp:TextBox>
                            <asp:TextBox ID="txhSortField" runat="server" Visible="False" Width="5px" Height="1px"></asp:TextBox><asp:TextBox
                                ID="txhSortDir" runat="server" Visible="False" Width="5px" Height="5px"></asp:TextBox></td>
                        <td style="height:10px;" colspan="3" >
                            <asp:Label ID="lbStatus" runat="server" EnableViewState="False"></asp:Label></td>
                    </tr>
                    <tr>
                       <td align="right" style="width: 456px"  > หน่วยงาน :</td>
                        <td  colspan="3" >
                        <asp:DropDownList ID ="cmbDivision" runat ="server" Width="260px" Enabled ="false"  ></asp:DropDownList>
                        </td>
                    </tr>
                     <tr>
                        <td align="right" style="width: 456px"  > เลขที่การส่งอาหาร :</td>
                        <td style="width: 189px"  >
                            <asp:TextBox ID = "txtOrderCode" CssClass="zTextbox-View" runat ="server"  ReadOnly ="true" ></asp:TextBox>
                            </td>
                        <td align="right" style="width: 354px"   >วันที่ส่ง :</td>
                        <td style="width: 270px" > <uc4:CalendarControl ID="ctlOrderDate" Enabled ="false" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 456px"  >ชื่อผู้ส่ง :</td>
                        <td colspan="3" >
                            <asp:TextBox ID = "txtFullName" CssClass="zTextbox-View" runat ="server" ReadOnly = "true"  Width="244px"  ></asp:TextBox>
                            </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 456px" >โทรศัพท์ :</td>
                        <td>
                            <asp:TextBox ID = "txtTel" CssClass="zTextbox-View" runat ="server" ReadOnly="true" ></asp:TextBox>
                            </td>
                        <td align="right" style="width: 354px"  >จำนวน(ที่) :</td>
                        <td style="width: 270px" > 
                            <asp:TextBox ID = "txtVISITORQTY" CssClass="zTextbox-View" runat ="server" ReadOnly="true"  ></asp:TextBox>
                        </td>
                    </tr>
                   <tr>
                        <td align="right" style="width: 456px"  >วันที่ต้องการ :</td>
                        <td  > 
                             <uc4:CalendarControl ID="ctlPartyDate" Enabled ="false" runat="server" />
                        </td>
                        <td align="right" style="width: 354px"  >เวลา :</td>
                        <td style="width: 100px" > 
                            <asp:TextBox ID = "txtTime" CssClass="zTextbox-View" runat ="server" ReadOnly="true" Width="79px"  ></asp:TextBox>
                        </td>
                    </tr>
                   <tr>
                        <td align="right" style="width: 456px"  >ประเภทการจัดเลี้ยง :</td>
                        <td style="width: 189px" colspan="3" > 
                            <asp:DropDownList ID ="cmbPartyType" runat ="server" Enabled="false" Width="244px" ></asp:DropDownList>
                        </td>
                        
                    </tr>
                    <tr>
                        <td align="right" style="width: 456px"  >สถานที่ :</td>
                        <td colspan="3"  > 
                            <asp:TextBox ID = "txtPlace" CssClass="zTextbox-View" runat ="server" ReadOnly="true" Width="345px"  ></asp:TextBox>
                        </td>
                    </tr>
                </table>
                </fieldset>
                &nbsp;
             </td>
             <td  valign="top">
                <fieldset style="height :250px">
                     <table >
                     <tr >
                         <td colspan="2" style="height:20px;">
                         </td>
                     </tr>
                     <tr style="width:200px" align="center" >
                        <td  align="right" >สถานะการสั่งอาหาร :
                        <asp:TextBox ID="txtStatus"  runat="server" CssClass="zTextbox-View" Width="200px" ReadOnly="true"  ></asp:TextBox>
                    </td>
                     </tr>
                       <tr>
                        <td style="width: 223px" colspan = "4">
                        <fieldset style="height :185px">
                            <table >
                            <tr>
                                <td>
                                <fieldset style="height :175px">
                                    <table>
                                        <tr>
                                            <td align="left" style="width: 212px" >ผู้อำนวยการ :</td>
                                        </tr>
                                        <tr>
                                            <td style="width: 212px">
                                                <asp:RadioButton GroupName="Approve" runat="server" ID="RdApprove" Text="อนุมัติ" Enabled="false" />
                                            </td>
                                        </tr>
                                         <tr>
                                            <td style="width: 212px">
                                                <asp:RadioButton GroupName="Approve" runat="server" ID="RdNonApprove" Enabled="false" Text="ไม่อนุมัติ" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="width: 212px; height:30px"  >ความเห็น :</td>
                                        </tr>
                                        <tr>
                                            <td style="height:70px; width: 212px;">
                                               <asp:TextBox ID="txtDirectCommitte" runat="server" Width="187px" Height="62px" TextMode="MultiLine" CssClass="zTextbox-View" ReadOnly="true" ></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </fieldset> 
                                </td> 
                                <td>
                                <fieldset style="height :175px">
                                    <table>
                                        <tr>
                                            <td align="left" style="width: 212px" >ฝ่ายโภชนาการ :</td> 
                                        </tr>
                                        <tr>
                                            <td style="width: 212px">
                                                <asp:RadioButton GroupName="NDCOMMIT" runat="server" ID="rdCommit" Enabled="false" Text="อนุมัติ" />
                                            </td>
                                        </tr>
                                         <tr>
                                            <td style="width: 212px">
                                                <asp:RadioButton GroupName="NDCOMMIT" runat="server" ID="rdNonCommit" Enabled="false" Text="ไม่อนุมัติ" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="width: 212px; height:30px" >ความเห็น :</td>
                                        </tr>
                                        <tr>
                                            <td style="height:70px; width: 212px;">
                                               <asp:TextBox ID="txtNDCommitte" runat="server" Width="187px" Height="62px" TextMode="MultiLine" CssClass="zTextbox-View" ReadOnly ="true" ></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </fieldset> 
                                </td> 
                            </tr>
                            </table>
                         </fieldset>
                            
                         </td>
                       </tr>
                    </table> 
                </fieldset>
            </td>
        </tr>
        <tr>
            <td colspan="4" style="height:2px"></td>
        </tr>
        <tr>
            <td colspan ="4">
            <table >
    <tr>
        <td >
               <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td>
                                    <asp:Label ID="lbStatusOrderPartytItem" runat="server" EnableViewState="False"></asp:Label></td> 
                            </tr> 
                    </table>
                    </td>
                </tr>
                <tr>
                        <td>
                            <uc2:PageControl ID="pcTop1" runat="server" OnPageChange ="PopUpPageChange" Visible="false"/>
                            <asp:GridView ID="grvItem" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="t_tablestyle" PageSize="20" AllowPaging="True" OnRowDataBound="grvItem_RowDataBound" >
                                <Columns>
                                    <asp:BoundField DataField="OPLOID" HeaderText="OPLOID">
                                        <ControlStyle CssClass="zHidden" />
                                        <FooterStyle CssClass="zHidden" />
                                        <HeaderStyle CssClass="zHidden" />
                                        <ItemStyle CssClass="zHidden" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="ลำดับ" >
                                        <HeaderStyle Width="60px" />
                                        <ItemStyle HorizontalAlign="Center" Width="60px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="DTNAME" HeaderText="ประเภทคาวหวาน" >
                                        <HeaderStyle HorizontalAlign="Center" Width="120px" />
                                        <ItemStyle HorizontalAlign="Left" Width="120px" />
                                    </asp:BoundField>
                                    
                                    <asp:BoundField DataField="FSNAME" HeaderText="รายการอาหาร" >
                                        <HeaderStyle HorizontalAlign="Center" Width="250px" />
                                        <ItemStyle HorizontalAlign="Left" Width="250px" />
                                    </asp:BoundField>
                                    
                                   <asp:BoundField DataField="VISITORQTY" HeaderText="จำนวนเบิก">
                                        <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                                    </asp:BoundField>
                                    
                                    <asp:BoundField DataField="SERVICEQTY" HeaderText="จำนวนรับจัด">
                                        <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OPILOID" HeaderText="OPILOID">
                                        <ControlStyle CssClass="zHidden" />
                                        <FooterStyle CssClass="zHidden" />
                                        <HeaderStyle CssClass="zHidden" />
                                        <ItemStyle CssClass="zHidden" />
                                    </asp:BoundField>
                                </Columns>
                                <HeaderStyle CssClass="t_headtext" />
                                <AlternatingRowStyle CssClass="t_alt_bg" />
                                <PagerSettings Visible="False" />
                            </asp:GridView><uc2:PageControl ID="pcBot1" runat="server" Visible="false" />
                            &nbsp;
                            </td>
                    </tr>
                
                </table>
           
            </td>
        
        </tr>
    </table>
    </asp:Panel>
</asp:Content>


