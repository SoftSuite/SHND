<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="MedFeedCharge.aspx.cs" Inherits="App_Prepare_Transaction_MedFeedCharge" Title="SHND : Transaction - Medical Feed Charge" %>

<%@ Register Src="../../Search/MedFeedMaterialUnitPopup.ascx" TagName="MedFeedMaterialUnitPopup"
    TagPrefix="uc5" %>

<%@ Register Src="../../Search/MedChargePopup.ascx" TagName="AdmitPatientPopup"
    TagPrefix="uc4" %>


<%@ Register Src="../../Templates/CalendarControl.ascx" TagName="CalendarControl"
    TagPrefix="uc3" %>

<%@ Register Src="../../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
 <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="headtext">
                ใบแจ้งค่าอาหารทางการแพทย์</td>
        </tr>
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbAdd" runat="server"  ToobarTitle ="เพิ่มข้อมูล" ToolbarImage="../../Images/icn_add.png" />
                <uc1:ToolBarItemCtl ID="tbApproveMain" runat="server"  ToobarTitle ="อนุมัติ" ToolbarImage="../../Images/icn_approve.png"  OnClick ="tbApproveMainClick" />
                <uc1:ToolBarItemCtl ID="tbCancelMain" runat="server"  ToobarTitle ="ยกเลิก" ToolbarImage="../../Images/icn_cancel.png" OnClick="tbCancelMainClick" />
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
                        ค้นหาใบแจ้งค่าอาหารทางการแพทย์
                    </legend>

                    <table cellspacing="0" cellpadding="0" border="0" width="600px">
                        <tr style="height:15px">
                            <td colspan="4">&nbsp;</td>
                        </tr>
                        <tr style="height:24px">
                            <td style="width:120px; text-align: right; padding-right:10px">เลขที่ใบแจ้ง :</td>
                            <td style="width: 150px"><asp:TextBox ID="txtSearchCodeFrom" runat="server" CssClass="zTextbox" MaxLength="50" Width="100px"></asp:TextBox>
                            </td>   
                            <td style="width:50px;" align="center">ถึง</td>
                            <td style="width: 451px"><asp:TextBox ID="txtSearchCodeTo" runat="server" CssClass="zTextbox" MaxLength="50" Width="100px"></asp:TextBox>
                            </td>                 
                        </tr>
                         <tr style="height:24px">
                            <td style="width:120px; text-align: right; padding-right:10px">วันที่แจ้ง :</td>
                            <td style="width: 150px">
                                <uc3:CalendarControl ID="ctlChargeDateFrom" runat="server" />
                            </td>   
                            <td style="width:50px;" align="center">ถึง</td>
                            <td style="width: 451px">
                                <uc3:CalendarControl ID="ctlChargeDateTo" runat="server" />
                            </td>                 
                        </tr>
                        <tr>
                            <td style="width:120px; text-align: right; padding-right:10px; height: 24px;">หอผู้ป่วย :</td>
                            <td colspan="3" style="height: 24px"><asp:DropDownList runat ="server" ID="cmbSearchWard" CssClass="zCombo" Width ="280px" ></asp:DropDownList> </td>
                            
                        </tr>
                        <tr style="height:24px">
                            <td style="width:120px; text-align: right; padding-right:10px">สถานะ :</td>
                            <td style="width: 150px">
                                <asp:DropDownList ID="cmbSearchStatusFrom" runat="server" CssClass ="zComboBox" Width="107px">
                                    <asp:ListItem Value="00">กำลังดำเนินการ</asp:ListItem>
                                    <asp:ListItem Value="01">อนุมัติ</asp:ListItem>
                                    <asp:ListItem Value="02">ยกเลิก</asp:ListItem>
                                </asp:DropDownList>
                               
                            </td>   
                            <td style="width:50px;" align="center">ถึง</td>
                            <td style="width: 451px">
                                  <asp:DropDownList ID="cmbSearchStatusTo" runat="server" CssClass ="zComboBox"  Width="107px">
                                    <asp:ListItem Value="00">กำลังดำเนินการ</asp:ListItem>
                                    <asp:ListItem Value="01">อนุมัติ</asp:ListItem>
                                    <asp:ListItem Value="02">ยกเลิก</asp:ListItem>
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
                <asp:GridView ID="gvMain" Width="100%" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="t_tablestyle" PageSize="20" AllowPaging="True" OnRowDataBound="gvMain_RowDataBound" OnSorting="gvMain_Sorting"  >
                    <Columns>
                        <asp:BoundField DataField="LOID" HeaderText="LOID">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>

                         <asp:TemplateField HeaderText="ลำดับ" SortExpression="DEFAULT">
                            <HeaderStyle Width="60px" />
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </asp:TemplateField>
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
                        <asp:TemplateField HeaderText="เลขที่ใบแจ้ง" SortExpression="CODE">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkType" runat="server"   OnClick="lnkType_Click"  Text='<%# Bind("CODE") %>' CommandArgument='<%# Bind("LOID")  %>'></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="150px" />
                            <ItemStyle HorizontalAlign="Left" Width="150px" />
                        </asp:TemplateField>
                        
                        <asp:BoundField DataField="CHARGEDATE" HeaderText="วันที่แจ้ง" SortExpression="CHARGEDATE" HtmlEncode="False"   DataFormatString="{0:dd/MM/yyyy}"  >
                            <HeaderStyle HorizontalAlign="Center" Width="80px" />
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="WARDNAME" HeaderText="หอผู้ป่วย" SortExpression="WARDNAME" HtmlEncode="False" >
                            <HeaderStyle HorizontalAlign="Center" Width="200px" />
                            <ItemStyle HorizontalAlign="Left" Width="200px" />
                        </asp:BoundField>
                        
                        <asp:BoundField DataField="STATUSNAME" HeaderText="สถานะ" SortExpression="STATUSNAME">
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="STATUS" HeaderText="STATUS" SortExpression="STATUS">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
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
    <asp:Panel ID="pnlCharge" runat="server" CssClass="modalPopup" style="display:none" Width="980px">
    <table cellspacing="0" cellpadding="0" border="0" width="100%">
         
        <tr>
            <td style="height: 20px">
        <uc1:ToolBarItemCtl ID="tbSave" runat="server" ToobarTitle="บันทึก" ToolbarImage="../../Images/save2.png" OnClick ="tbSaveClick"  />
        <uc1:ToolBarItemCtl ID="tbReturn" runat="server" ToobarTitle="ยกเลิกการแก้ไข" ToolbarImage="../../Images/cancel.png"  OnClick="tbCancelClick" />
        <uc1:ToolBarItemCtl ID="tbBack" runat="server" ToobarTitle="กลับหน้ารายการ" ToolbarImage="../../Images/icn_back.png" OnClick ="tbBackClick" />
        <uc1:ToolBarItemCtl ID="tbApprove" runat="server" ToobarTitle="อนุมัติ" ToolbarImage="../../Images/icn_approve.png" OnClick ="tbApproveClick" />
        <uc1:ToolBarItemCtl ID="tbPrint" runat="server" ToobarTitle="พิมพ์" ToolbarImage="../../Images/icn_print.png" />
            </td>
        </tr>
        <tr>
            <td>
                <hr style="size:1px" />
            </td>
       </tr>
        <tr>
            <td>
                <table cellpadding="5">
                    <tr>
                        <td align="right" style="width: 70px; height: 3px;" colspan="2"> 
                            <asp:TextBox ID="txhID" runat="server" Width="1px" Height="9px" Visible="False"></asp:TextBox>
                            <asp:TextBox ID="txhSortField" runat="server" Visible="False" Width="15px"></asp:TextBox>
                            <asp:TextBox ID="txhSortDir" runat="server" Visible="False" Width="15px"></asp:TextBox>
                            <asp:TextBox ID="txtLoidIndex" runat="server" Width="1px" Height="9px" Visible="False"></asp:TextBox>
                            <asp:TextBox ID="txtStatusFlag" runat="server" Width="1px" Height="9px" Visible="False"></asp:TextBox>

                        </td>
                        <td style="height:3px; width: 712px;">
                            <asp:Label ID="lbStatus" runat="server" EnableViewState="False"></asp:Label></td>
                    </tr>
                 </table>
                 <table >
                    <tr>
                        <td style="width: 416px">
                            <fieldset style="padding:15px; height:70px ">
                            <table  border="0" cellpadding="0" cellspacing="0" style="height :65px">
                                 <tr>
                                    <td  style="width:92px; height:23px" align="right">หอผู้ป่วย : </td>
                                    <td style="width: 346px; height:23px" >
                                        <asp:DropDownList ID="cmbWard" runat ="server" CssClass ="zCombo" Width ="313px" ></asp:DropDownList>
                                        <span style="color:red">*</span>
                                        <asp:TextBox ID="txtWardLoid" runat="server" Width="20px" Height="9px" Visible ="false" ></asp:TextBox>
                                        
                                    </td>
                                </tr>                                 
                            </table>
                            </fieldset> 
                        </td>
                        <td>
                            <fieldset style="padding:15px; height:70px ">
                            <table  border="0" cellpadding="0" cellspacing="0">
                             
                                <tr>
                                    <td  style="width:96px; height: 23px;" align="right"> เลขที่ใบแจ้ง : &nbsp;</td>
                                    <td>
                                        <asp:TextBox ID="txtCode" runat="server" CssClass="zTextbox-View" ReadOnly="true" Width="124px" ></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td  style="width:96px; height:23px" align="right"> วันที่แจ้ง : &nbsp;</td>
                                    <td>
                                        <uc3:CalendarControl ID="ctlChargeDate" runat="server" Enabled="false" />
                                    </td>
                                </tr>  
                                <tr>
                                    <td  style="width:96px; height:23px" align="right"> สถานะ : &nbsp;</td>
                                    <td>
                                        <asp:TextBox ID="txtStatusName" runat="server" CssClass="zTextbox-View" ReadOnly ="true" Width="130px"></asp:TextBox>
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
     <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td class="subheadertext">ใบแจ้งค่าอาหารทางการแพทย์</td> 
            </tr>
            <tr>
                <td class="toolbarplace">
                    <uc1:ToolBarItemCtl ID="tbAddMedFeedChargeItem" runat="server" ToobarTitle="เพิ่มรายการผู้ป่วย" ToolbarImage="../../Images/icn_add.png" OnClick ="tbAddMedFeedChargeItemClick" />
                    <uc1:ToolBarItemCtl ID="tbDeleteMedFeedChargeItem" runat="server" ToobarTitle="ลบรายการผู้ป่วย" ToolbarImage="../../Images/icn_delete.png" OnClick ="tbDeleteMedFeedChargeItemClick"  ClientClick="return confirm('ต้องการลบข้อมูลที่เลือก ใช่หรือไม่?')" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbStatusFormulaSetItem" runat="server" EnableViewState="False"></asp:Label></td> 
            </tr> 
    </table>
    <uc2:PageControl ID="pcTop2" runat="server"  OnPageChange="PageChange2"  />
    <asp:GridView ID="grvItem" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="t_tablestyle" PageSize="10"  AllowPaging="True" OnRowDataBound="grvItem_RowDataBound">
        <Columns>
            <asp:TemplateField HeaderText="loid">
                <ItemTemplate >
                    <asp:TextBox ID="LOID" runat="server" ReadOnly="true" Text ='<%# Bind("LOID")%>' Width="60px" ></asp:TextBox>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" Width="60px" CssClass ="zHidden" />
                <ItemStyle HorizontalAlign="left" Width="60px"  CssClass="zHidden"  />
            </asp:TemplateField> 

            <asp:TemplateField>
                <HeaderTemplate>
                    <input type="checkbox" name="chkpop"  id="chkpop" onclick="chkAllBox(this, 'ctl00_MainContent_grvItem_ctl', '_chkSelectPop')" />
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="chkSelectPop" runat="server" />
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" Width="30px" />
                <ItemStyle HorizontalAlign="Center" Width="30px" />
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="ลำดับ" >
                <HeaderStyle HorizontalAlign="Center" Width="40px" />
                <ItemStyle HorizontalAlign="Center" Width="40px" />
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="ชื่อผู้ป่วย" >
                <ItemTemplate>
                   <asp:Label ID="lblName"  runat="server" Text='<%# Bind("PATIENTNAME") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" Width="170px" />
                <ItemStyle Width="170px"  />
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="วันที่เบิก" >
                <ItemTemplate >
                    <uc3:CalendarControl ID="ctlReqDate" runat ="server" DateValue ='<%#Bind("REQDATE")%>' Enabled="false" />
                </ItemTemplate>   
                <HeaderStyle HorizontalAlign="Center" Width="140px" />
                <ItemStyle HorizontalAlign="left" Width="140px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ชนิดอาหาร">
                <ItemTemplate >
                    <asp:TextBox ID="txtMMName" runat="server" CssClass="zTextbox-View" ReadOnly="true" Width="110px" Text='<%#Bind("MMNAME") %>'  ></asp:TextBox>
                    <asp:ImageButton ID="imgType" runat="server" ImageAlign="AbsMiddle" Visible="false" ImageUrl="~/Images/icn_find.png" OnClick ="ImgTypClick"  ToolTip='<%# Container.DataItemIndex %>'   />
                    
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" Width="160px" />
                <ItemStyle HorizontalAlign="left" Width="160px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="จำนวนที่เบิก" >
                <ItemTemplate >
                    <asp:TextBox ID="txtQty" runat="server" CssClass ="zTextboxR" Text='<%#Bind("QTY") %>' Width="60px"  OnTextChanged="QtyCalculate" AutoPostBack="true" ToolTip='<%# Container.DataItemIndex %>'  ></asp:TextBox>
                    <span style="color:red">*</span>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" Width="80px" />
                <ItemStyle HorizontalAlign="Right" Width="80px" />
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="หน่วยนับ" >
                <ItemTemplate>
                   <asp:Label ID="lblUName" runat="server" Text='<%# Bind("UUNAME") %>' Width="50px"></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" Width="60px" />
                <ItemStyle HorizontalAlign="Left" Width="60px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ราคา/หน่วย" >
                <ItemTemplate >
                    <asp:Label ID="lblPrice" runat="server" Text='<%#Bind("PRICE") %>' Width="40px" ></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" Width="50px" />
                <ItemStyle HorizontalAlign="Right" Width="50px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="รวมเป็นเงิน" >
                <ItemTemplate >
                    <asp:Label ID="lblTotal" runat="server" Text='<%#Bind("TOTAL") %>'  Width="60px"  ></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" Width="70px" />
                <ItemStyle HorizontalAlign="Right" Width="70px" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="หมายเหตุ" >
                <ItemTemplate>
                   <asp:TextBox ID="txtRemarks" runat="server" CssClass="zTextbox" Width ="140px" MaxLength="200"  Text='<%# Bind("REMARKS") %>' OnTextChanged ="txtRemarksTextChange" AutoPostBack ="true" ToolTip='<%# Container.DataItemIndex %>' ></asp:TextBox>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" Width="150px" />
                <ItemStyle HorizontalAlign="Left" Width="150px" />
            </asp:TemplateField>
                
            <asp:BoundField DataField="UULOID" HeaderText="UULOID" ReadOnly = "True" >
                <ControlStyle CssClass="zHidden" />
                <FooterStyle CssClass="zHidden" />
                <HeaderStyle CssClass="zHidden" />
                <ItemStyle CssClass="zHidden" />
            </asp:BoundField>
            
            <asp:BoundField DataField="MCLOID" HeaderText="MCLOID" ReadOnly ="True" >
                <ControlStyle CssClass="zHidden" />
                <FooterStyle CssClass="zHidden" />
                <HeaderStyle CssClass="zHidden" />
                <ItemStyle CssClass="zHidden" />
            </asp:BoundField>  
            
             <asp:BoundField DataField="MCILOID" HeaderText="MCILOID" ReadOnly ="True" >
                 <ControlStyle CssClass="zHidden" />
                <FooterStyle CssClass="zHidden" />
                <HeaderStyle CssClass="zHidden" />
                <ItemStyle CssClass="zHidden" />
            </asp:BoundField>  
            <asp:BoundField DataField="MMLOID" HeaderText="MMLOID" ReadOnly ="True" >
                 <ControlStyle CssClass="zHidden" />
                <FooterStyle CssClass="zHidden" />
                <HeaderStyle CssClass="zHidden" />
                <ItemStyle CssClass="zHidden" />
            </asp:BoundField>  

        </Columns>
        <HeaderStyle CssClass="t_headtext" />
        <AlternatingRowStyle CssClass="t_alt_bg" />
        <PagerSettings  Visible="False" />
    </asp:GridView>
     <uc2:PageControl ID="pcBot2" runat="server" OnPageChange="PageChange2"   />
    </asp:Panel>
    <uc4:AdmitPatientPopup ID="ctlAdmitPatientPopup" runat="server"   OnSelectedIndexChanged="ctlAdmitPatientPopup_SelectedIndexChanged" OnCancel="ctlAdmitPatientPopup_Cancel" />
    <uc5:MedFeedMaterialUnitPopup ID="ctlMaterialUnitPopup" runat="server"   OnSelectedIndexChanged="ctlMaterialUnitPopup_SelectedIndexChanged"  OnCancel="ctlMaterialUnitPopup_Cancel"  />
</asp:Content>

