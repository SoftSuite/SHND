<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="CutOrder.aspx.cs" Inherits="App_Prepare_Transaction_CutOrder" Title="SHND : Transaction - Cut Order" %>

<%@ Register Src="../../Templates/CalendarControl.ascx" TagName="CalendarControl"
    TagPrefix="uc3" %>

<%@ Register Src="../../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
 <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="headtext">
                ตัดยอดก่อนเตรียม</td>
        </tr>
        <tr class ="zHidden">
            <td>
                <uc1:ToolBarItemCtl ID="tbAdd" runat="server"  ToobarTitle ="เพิ่มข้อมูล" ToolbarImage="../../Images/icn_add.png" />

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

                    <table cellspacing="0" cellpadding="0" border="0" width="600px">
                        <tr style="height:15px">
                            <td colspan="4">&nbsp;</td>
                        </tr>
                        <tr style="height:24px">
                            <td style="width:120px; text-align: right; padding-right:10px">เลขที่เบิก :</td>
                            <td style="width: 150px"><asp:TextBox ID="txtSearchCodeFrom" runat="server" CssClass="zTextbox" MaxLength="50" Width="100px"></asp:TextBox>
                            </td>   
                            <td style="width:50px;" align="center">ถึง</td>
                            <td style="width: 451px"><asp:TextBox ID="txtSearchCodeTo" runat="server" CssClass="zTextbox" MaxLength="50" Width="100px"></asp:TextBox>
                            </td>                 
                        </tr>
                         <tr style="height:24px">
                            <td style="width:120px; text-align: right; padding-right:10px">วันที่ใช้ :</td>
                            <td style="width: 150px">
                                <uc3:CalendarControl ID="ctlUseDateFrom" runat="server" />
                            </td>   
                            <td style="width:50px;" align="center">ถึง</td>
                            <td style="width: 451px">
                                <uc3:CalendarControl ID="ctlUseDateTo" runat="server" />
                            </td>                 
                        </tr>
                        <tr>
                            <td style="width:110px; text-align: right; padding-right:10px; height: 24px;">หน่วยที่เบิก :</td>
                            <td colspan="3" style="height: 24px"><asp:DropDownList runat ="server" ID="cmbSearchDivision" CssClass="zCombo" Width ="280px" ></asp:DropDownList> </td>
                            
                        </tr>
                        <tr style="height:24px">
                            <td style="width:120px; text-align: right; padding-right:10px">สถานะ :</td>
                            <td style="width: 150px">
                                <asp:DropDownList ID="cmbSearchStatusFrom" runat="server" CssClass ="zComboBox" Width="107px">
                                    <asp:ListItem Value="AP">อนุมัติ</asp:ListItem>
                                    <asp:ListItem Value="FN">เสร็จสิ้น</asp:ListItem>
                                </asp:DropDownList>
                               
                            </td>   
                            <td style="width:50px;" align="center">ถึง</td>
                            <td style="width: 451px">
                                  <asp:DropDownList ID="cmbSearchStatusTo" runat="server" CssClass ="zComboBox" Width="108px">
                                    <asp:ListItem Value="AP">อนุมัติ</asp:ListItem>
                                    <asp:ListItem Value="FN">เสร็จสิ้น</asp:ListItem>
                                </asp:DropDownList>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:ImageButton ID="imbSearch" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_find.png" OnClick="imbSearch_Click"
                                 />
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
                <uc2:PageControl ID="pcTop" runat="server"  OnPageChange="PageChange"  />
                <asp:GridView ID="gvMain" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="t_tablestyle" PageSize="20" AllowPaging="True" OnSorting="gvMain_Sorting" >
                    <Columns>
                        <asp:BoundField DataField="LOID" HeaderText="LOID">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>

                          <asp:TemplateField HeaderText="เลขที่เบิก" SortExpression="CODE">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkType" runat="server"   OnClick="lnkType_Click"  Text='<%# Bind("CODE") %>' CommandArgument='<%# Bind("LOID")  %>'></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="120px" />
                            <ItemStyle HorizontalAlign="Left" Width="120px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="DIVISIONNAME" HeaderText="ประเภทการเบิก" SortExpression="DIVISIONNAME" HtmlEncode="False" >
                            <HeaderStyle HorizontalAlign="Center" Width="120px" />
                            <ItemStyle HorizontalAlign="Left" Width="120px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="STOCKOUTDATE" HeaderText="วันที่เบิก" SortExpression="STOCKOUTDATE" HtmlEncode="False"   DataFormatString="{0:dd/MM/yyyy}"  >
                            <HeaderStyle HorizontalAlign="Center" Width="80px" />
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="USEDATE" HeaderText="วันที่ใช้" SortExpression="USEDATE" HtmlEncode="False"   DataFormatString="{0:dd/MM/yyyy}"  >
                            <HeaderStyle HorizontalAlign="Center" Width="80px" />
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DOCNAME" HeaderText="ประเภทการเบิก" SortExpression="DOCNAME" HtmlEncode="False" >
                            <HeaderStyle HorizontalAlign="Center" Width="120px" />
                            <ItemStyle HorizontalAlign="Left" Width="120px" />
                        </asp:BoundField>
                        
                        <asp:BoundField DataField="STATUSNAME" HeaderText="สถานะ" SortExpression="STATUSNAME">
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundField>
                    </Columns>
                    <HeaderStyle CssClass="t_headtext" />
                    <AlternatingRowStyle CssClass="t_alt_bg" />
                    <PagerSettings Visible="False" />
                </asp:GridView><uc2:PageControl ID="pcBot" runat="server" OnPageChange="PageChange"   />
                </td>
        </tr>
    </table>
    <cc1:ModalPopupExtender ID="zPop" runat="server" TargetControlID="tbAdd$lb" PopupControlID="pnlCharge" BackgroundCssClass="modalBackground" DropShadow="true"></cc1:ModalPopupExtender>
    <asp:Panel ID="pnlCharge" runat="server" CssClass="modalPopup" style="display:none" Width="900px">
    <table cellspacing="0" cellpadding="0" border="0" width="100%">
        <tr>
            <td class="subheadertext">
                ตัดยอดก่อนเตรียม</td> 
        </tr>
         <tr>
            <td>
                <hr style="size:1px" />
            </td>
       </tr>
        <tr>
            <td style="height: 20px">
                <uc1:ToolBarItemCtl ID="tbSave" runat="server" ToobarTitle="บันทึก" ToolbarImage="../../Images/save2.png" OnClick="tbSaveClick" />
                <uc1:ToolBarItemCtl ID="tbReturn" runat="server" ToobarTitle="ยกเลิกการแก้ไข" ToolbarImage="../../Images/cancel.png" OnClick="tbReturnClick"  />
                <uc1:ToolBarItemCtl ID="tbApprove" runat="server" ToobarTitle="เสร็จสิ้น" ToolbarImage="../../Images/icn_approve.png" OnClick ="tbApproveClick"  />
                <uc1:ToolBarItemCtl ID="tbPrint" runat ="server" ToolbarImage="../../Images/icn_print.png" ToobarTitle ="พิมพ์" />
                <uc1:ToolBarItemCtl ID="tbBack" runat="server" ToobarTitle="กลับหน้ารายการ" ToolbarImage="../../Images/icn_back.png"  />
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="5">
                    <tr>
                        <td align="right" style="width: 107px; height: 3px;" colspan="2"> 
                            <asp:TextBox ID="txhID" runat="server" Width="1px" Height="9px" Visible="False"></asp:TextBox>
                            <asp:TextBox ID="txhSortField" runat="server" Visible="False" Width="15px"></asp:TextBox>
                            <asp:TextBox ID="txtStatusFlag" runat="server" Visible="False" Width="15px"></asp:TextBox>
                            <asp:TextBox ID="txhSortDir" runat="server" Visible="False" Width="1px" Height="2px"></asp:TextBox></td>
                        <td style="height:3px; width: 712px;">
                            <asp:Label ID="lbStatus" runat="server" EnableViewState="False"></asp:Label></td>
                    </tr>
                 </table>
            </td>
         </tr>
         <tr>
            <td>
                 <table>
                    <tr>
                        <td style="width: 637px">
                       <fieldset style="padding:15px; ">
                            <table border="0" cellpadding="0" cellspacing="0" style="height :65px; width: 609px;">
                                <tr>
                                    <td align="right" style="width: 108px; height:23px">เลขที่เบิก :&nbsp;</td>
                                    <td  style="width: 195px">
                                        <asp:TextBox id="txtCode" runat="server" CssClass ="zTextbox-View" ReadOnly="true"></asp:TextBox>
                                    </td>
                                    <td align="right" style="width: 81px; height: 23px">วันที่เบิก :&nbsp;</td>
                                    <td style="width: 244px; height: 23px">
                                        <uc3:CalendarControl ID="ctlStockoutDate" runat="server" Enabled ="false" />
                                    </td>
                                </tr>
                                <tr>
                                    <td  align="right" style="width: 108px; height: 23px">หน่วยที่เบิก :&nbsp;</td>
                                    <td  style="width: 195px; height: 23px">
                                        <asp:DropDownList ID="cmbDivision" runat="server" Enabled="false" CssClass="zComboBox" Width="188px"></asp:DropDownList>
                                    </td>
                                    <td  align="right" style="width: 81px; height: 23px">คลัง :&nbsp;</td>
                                    <td  style="width: 244px; height: 23px">
                                        <asp:DropDownList ID="cmbWareHouse" runat="server" Enabled="false" CssClass="zComboBox" Width="230px"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 108px; height: 23px">ประเภทการเบิก :&nbsp;</td>
                                    <td  style="width: 195px; height: 23px">
                                       <asp:DropDownList ID="cmbDoctype" runat="server" Enabled ="false" CssClass="zComboBox" Width="188px"></asp:DropDownList>
                                    </td>
                                    <td align="right" style="width: 81px; height: 23px">จำนวนที่สั่ง :&nbsp;</td>
                                    <td  style="width: 150px; height: 23px">
                                        <asp:TextBox ID="txtOrderQty" runat="server" CssClass="zTextboxR-View" ReadOnly="true" Width="100px" ></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 108px; height: 23px">วันที่ใช้ :&nbsp;</td>
                                    <td  style="width: 195px; height: 23px">
                                        <uc3:CalendarControl ID="ctlUseDate" runat="server" Enabled="false" />
                                    </td>
                                    <td align="right" style="width: 81px; height: 23px">มื้อที่ใช้ :&nbsp;</td>
                                    <td  style="width: 244px; height: 23px">
                                        <asp:CheckBox ID="chkBP" runat="server" Enabled="false" Width="70px" Text="เช้า" />
                                        <asp:CheckBox ID="chkLunch" runat="server" Enabled="false" Width="70px" Text="กลางวัน" />
                                        <asp:CheckBox ID="chkDinner" runat="server" Enabled="false" Width="70px" Text="เย็น" />
                                    </td>
                                </tr>
                            </table>
                       </fieldset>
                       </td>
                        <td>
                            <fieldset style="padding:15px; width:160px; height:90px ">
                            <table  border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td  style="width:96px; height: 23px" align="right"> สถานะ : &nbsp;</td>
                                    <td >
                                        <asp:TextBox ID="txtStatusName" runat="server" CssClass="zTextbox-View" ReadOnly ="true" Width="100px"></asp:TextBox>
                                    </td>
                                </tr> 
                                                        
                            </table>
                            </fieldset> 
                        </td>
                    </tr>
                 </table>
         </td>
    </tr>
    </table>
    <br />
    <table>
        <tr>
            <td align ="right" style="width:800px">
                <asp:ImageButton ID="imgCalculate" runat="server"  ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_calculate.png"  OnClick ="imgCalculateClick"  />
                <asp:Label ID="label10" runat="server" Text="คำนวณจากจำนวนผู้ป่วย ณ ปัจจุบัน"></asp:Label>
            </td>
        </tr>
    </table>
     <uc2:PageControl ID="pcTop2" runat="server"  OnPageChange="PageChange2"  />
    <asp:GridView ID="grvItem" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="t_tablestyle"  AllowPaging="True" OnRowDataBound="grvItem_RowDataBound">
        <Columns>
            <asp:BoundField DataField="LOID" HeaderText="LOID" ReadOnly ="True" >
                <ControlStyle CssClass="zHidden" />
                <FooterStyle CssClass="zHidden" />
                <HeaderStyle CssClass="zHidden" />
                <ItemStyle CssClass="zHidden" />
            </asp:BoundField> 
            
            <asp:TemplateField HeaderText="ลำดับ" >
                <HeaderStyle HorizontalAlign="Center" Width="60px" />
                <ItemStyle HorizontalAlign="Center" Width="60px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="รหัส" >
                <ItemTemplate>
                   <asp:Label ID="lblCode"  runat="server" Text='<%# Bind("CODE") %>' Width="90px"></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" Width="100px" />
                <ItemStyle Width="100px"  />
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="รายการ" >
                <ItemTemplate>
                   <asp:Label ID="lblMaterialName"  runat="server" Text='<%# Bind("MATERIALNAME") %>' Width="170px"></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" Width="180px" />
                <ItemStyle HorizontalAlign ="Left" Width="180px"  />
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="หน่วยนับ" >
                <ItemTemplate>
                    <asp:Label ID="lbltUnitName" runat="server" Text='<%# Bind("UNITNAME") %>' Width="90px"></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" Width="100px" />
                <ItemStyle  HorizontalAlign ="Left" Width="100px"  />

            </asp:TemplateField>
            <asp:TemplateField HeaderText="จำนวนเบิก">
                <ItemTemplate >
                    <asp:Label ID="lblReqQty" runat="server" Text ='<%# Bind("REQQTY")%>'   Width="75px" ></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" Width="80px" />
                <ItemStyle HorizontalAlign ="Right" Width ="80px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="จำนวนที่จ่าย" >
                <ItemTemplate >
                    <asp:Label ID="lblQty" runat="server"  Text='<%#Bind("QTY") %>'  Width="75px"  ></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" Width="100px" />
                <ItemStyle HorizontalAlign="Right" Width="100px" />
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="จำนวนที่ต้องใช้" >
                <ItemTemplate>
                   <asp:TextBox ID="txtUseQty" runat="server" Text='<%#Bind("USEQTY") %>' Width="80px" OnTextChanged="UseQtyCalculate" AutoPostBack="true" ToolTip='<%# Container.DataItemIndex %>'  ></asp:TextBox>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" Width="90px" />
                <ItemStyle HorizontalAlign="Center" Width="90px" />
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="จำนวนคืนคลัง" >
                <ItemTemplate >
                    <asp:Label ID="lblReturn" runat="server" Text='<%#Bind("RETURN") %>'  Width="90px" ></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" Width="100px" />
                <ItemStyle HorizontalAlign="Right" Width="90px" />
            </asp:TemplateField>
                
            <asp:BoundField DataField="STOCKOUT" HeaderText="STOCKOUT" ReadOnly = "True" >
                <ControlStyle CssClass="zHidden" />
                <FooterStyle CssClass="zHidden" />
                <HeaderStyle CssClass="zHidden" />
                <ItemStyle CssClass="zHidden" />
            </asp:BoundField>
            <asp:BoundField DataField="MATERIALMASTER" HeaderText="MATERIALMASTER" ReadOnly = "True" >
                <ControlStyle CssClass="zHidden" />
                <FooterStyle CssClass="zHidden" />
                <HeaderStyle CssClass="zHidden" />
                <ItemStyle CssClass="zHidden" />
            </asp:BoundField>
        </Columns>
        <HeaderStyle CssClass="t_headtext" />
        <AlternatingRowStyle CssClass="t_alt_bg" />
        <PagerSettings Visible="False" />
    </asp:GridView><uc2:PageControl ID="pcBot2" runat="server" OnPageChange="PageChange2"   />
    <br />
    <table>
        <tr>
            <td>
                <asp:Label ID="lable1" runat="server" Text="หมายเหตุ :" ForeColor="red" Width="600px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Text="จำนวนตามสูตร คือ จำนวนที่คำนวณมาจากเมนู ณ เวลาที่หน่วยงานเบิก" ForeColor="green" Width="600px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="จำนวนจ่าย คือ จำนวนที่คลังจ่ายออก" ForeColor="green" Width="600px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="จำนวนที่ต้องใช้ คือ จำนวนที่หน่วยเตรียมต้องการใช้" ForeColor="green" Width="600px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label8" runat="server" Text="จำนวนคืนคลัง คือ จำนวนจ่าย-จำนวนที่ต้องใช้ จำนวนจะกลับคืนเข้าคลังโดยอัตโนมัติ" ForeColor="green" Width="600px"></asp:Label>
            </td>
        </tr>
    </table>
    </asp:Panel>
</asp:Content>

