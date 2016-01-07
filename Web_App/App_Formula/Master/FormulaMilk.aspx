<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="FormulaMilk.aspx.cs" Inherits="App_Formula_Master_FormulaMilk" Title="SHND : Master - Formula Milk" %>

<%@ Register Src="../../Search/MaterialMasterPopup.ascx" TagName="MaterialMasterPopup"
    TagPrefix="uc3" %>
<%@ Register Src="../../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="headtext">
                ข้อมูลสูตรนมผงผสมสำหรับเด็ก</td>
        </tr>

    </table>
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbAdd" runat="server" ToobarTitle="เพิ่มข้อมูล" OnClick="tbAddClick"   ToolbarImage="../../Images/icn_add.png"  />
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
                        <td colspan="4">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width:120px; text-align: right; padding-right:10px; height: 22px;">
                            ชนิดของนม :</td>
                        <td colspan="3" style="height: 22px"><asp:DropDownList runat ="server" ID="cmbSearchMilkType" CssClass="zComboBox" Width ="196px" ></asp:DropDownList> </td>
                        
                    </tr>
                    <tr>
                        <td style="text-align: right; padding-right:10px">พลังงาน :</td>
                        <td style="width: 139px" ><asp:TextBox ID="txtEnergyFrom" runat="server" CssClass="zTextboxR" MaxLength="50" Width="83px" ></asp:TextBox>
                            <asp:Label ID="label1" runat="server" Width="39px" >kcal/oz</asp:Label>   </td>   
                        <td style="padding-right:10px; width: 47px;" align="center">ถึง</td>
                        <td><asp:TextBox ID="txtEnergyTo" runat="server" CssClass="zTextboxR" MaxLength="50" Width="83px" ></asp:TextBox>
                            <asp:Label ID="label2" runat="server" >kcal/oz</asp:Label>&nbsp;&nbsp;
                            <asp:ImageButton ID="imbSearch" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_find.png"
                            OnClick="imbSearch_Click" />
                            <asp:ImageButton ID="imbReset" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_back.png" OnClick="imbReset_Click" ToolTip="แสดงทั้งหมด" />
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
                <uc2:PageControl ID="pcTop" runat="server"  OnPageChange="PageChange" />
                <asp:GridView ID="grvResult" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="t_tablestyle" PageSize="20" OnRowDataBound="grvResult_RowDataBound" 
                    OnSorting="grvResult_Sorting" AllowPaging="True" OnRowDeleting="grvResult_RowDeleting" OnSelectedIndexChanging="grvResult_SelectedIndexChanging" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="LOID" HeaderText="LOID">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton runat = "server" ID="imbDeleteMain" CommandName="Delete" ImageUrl="~/Images/icn_delete.png" OnClientClick="return confirm('ต้องการลบข้อมูลที่เลือก ใช่หรือไม่?')"  />
                                <asp:ImageButton runat = "server" ID = "imbCopyMain" CommandName= "Select" ImageUrl="~/Images/icn_copy.png"   />
                            </ItemTemplate>
                            <HeaderStyle Width="60px" />
                            <ItemStyle Width="60px" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="ลำดับ" SortExpression="DEFAULT">
                            <HeaderStyle Width="60px" />
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="ชนิดของนม" SortExpression="FORMULANAME">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkType" runat="server"  OnClick="lnkType_Click"   Text='<%# Bind("FORMULANAME") %>' CommandArgument='<%# Bind("LOID")  %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ENERGY" HeaderText="พลังงาน (kcal/oz)" SortExpression="ENERGY">
                            <HeaderStyle HorizontalAlign="Center" Width="110px" />
                            <ItemStyle HorizontalAlign="Right" Width="110px" />
                        </asp:BoundField>
                        
                        <asp:BoundField DataField="ACTIVE" HeaderText="การใช้งาน" SortExpression="ACTIVE">
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundField>
                    </Columns>
                    <HeaderStyle CssClass="t_headtext" />
                    <AlternatingRowStyle CssClass="t_alt_bg" />
                    <PagerSettings Visible="False" />
                </asp:GridView><uc2:PageControl ID="pcBot" runat="server"  OnPageChange="PageChange" />
                </td>
        </tr>
    </table>
     <cc1:ModalPopupExtender ID="FormulaMilkPop" runat="server" TargetControlID="tbAdd$lb" PopupControlID="Panel1" BackgroundCssClass="modalBackground" DropShadow="true"></cc1:ModalPopupExtender>
    <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" style="display:none" Width="800px">
    <table cellspacing="0" cellpadding="0" border="0" width="100%">
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbSave" runat="server" ToobarTitle="บันทึก" ToolbarImage="../../Images/save2.png"  OnClick="tbSave1Click" />
                <uc1:ToolBarItemCtl ID="tbReturn" runat="server" ToobarTitle="ยกเลิกการแก้ไข" ToolbarImage="../../Images/cancel.png"   OnClick="tbReturnClick"  />
                <uc1:ToolBarItemCtl ID="tbBack" runat="server" ToobarTitle="กลับหน้ารายการ" ToolbarImage="../../Images/icn_back.png"  OnClick="tbBackClick"/>
                <uc1:ToolBarItemCtl ID="tbPrint" runat ="server" ToolbarImage="../../Images/icn_print.png" ToobarTitle ="พิมพ์" />
            </td>
        </tr>
        <tr>
            <td><hr style="size:1px" />
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="5">
                    <tr>
                        <td align="right" style="width: 150px">
                            <asp:TextBox ID="txhID" runat="server" Width="1px" Height="9px" Visible="False"></asp:TextBox>
                            <asp:TextBox ID="txtFormulaSetItemRow" runat="server" Visible="False" Width="5px"></asp:TextBox>
                            <asp:TextBox ID="txtMilkCapacity" runat="server" Visible="False" Width="5px"></asp:TextBox>
                            <asp:TextBox ID="txtflage" runat="server" Visible="False" Width="5px">0</asp:TextBox>
                            <asp:TextBox ID="txtMEnergy" runat="server" Width="13px" Visible="False"></asp:TextBox>
                            <asp:TextBox ID="txtNutrientRate" runat="server" Width="13px" Visible="False"></asp:TextBox>
                            <asp:TextBox ID="txhSortField" runat="server" Visible="False" Width="15px"></asp:TextBox>
                            <asp:TextBox ID="txhSortDir" runat="server" Visible="False" Width="15px"></asp:TextBox></td>
                        <td style="height:10px; width: 519px;">
                            <asp:Label ID="lbStatus" runat="server" EnableViewState="False"></asp:Label></td>
                    </tr>
                    <tr>
                        <td  style="width:150px" align="right"> ชนิดนม :</td>
                        <td style="width: 519px">
                            <asp:DropDownList ID="cmbMilkCatagory" runat ="server" CssClass ="zCombo" Width ="300px" AutoPostBack="True" OnSelectedIndexChanged="cmbMilkCatagory_SelectedIndexChanged"></asp:DropDownList><span style="color:red">*</span>
                            <asp:Label ID ="txtMilkType" runat ="server" ></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width:150px" align="right"> พลังงานที่ต้องการ:</td>
                        <td style="width: 519px" >
                            <asp:TextBox ID="txtEnergy" runat="server" CssClass="zTextboxR" MaxLength="50" Width="60px"></asp:TextBox>
                            <asp:Label ID="label5" runat ="server" >kcal/oz</asp:Label>
                            <span style="color: #ff0000">*</span><span style="color:red"></span>
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 
                            <asp:CheckBox ID="chkActive" runat="server" Checked="True" Text="ใช้งาน" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width:150px"  align="right">
                            ปริมาณ :</td>
                        <td style="width: 519px" >
                            <asp:TextBox ID="txtMilkCap" runat="server" CssClass="zTextboxR" MaxLength="50" Width="60px" Enabled="False" Text="1"></asp:TextBox>
                            <asp:Label ID="label6" runat ="server" >oz</asp:Label>
                            <span style="color: #ff0000">*</span><span style="color:red"></span>
                       </td>     
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:ImageButton runat="server" ID ="calculator" ImageUrl="~/Images/icn_calculate.png" OnClick="calculator_Click"  ImageAlign="absMiddle" />
                            <asp:Label runat="server" ID="label12" >คำนวณ</asp:Label>
                        </td>
                    </tr>
                </table>
                &nbsp;
                
                
                
                
                <cc1:TabContainer ID="TabContainer1" runat="server"  ActiveTabIndex="0" AutoPostBack="true"   OnActiveTabChanged="TabChanged_Click" Visible="False">
        
                    <cc1:TabPanel ID="tpnInventory" runat="server" HeaderText="รายการวัตถุดิบ">
                        <ContentTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td class="toolbarplace">
                                        <uc1:ToolBarItemCtl ID="tbAddFormulaMilkItem" runat="server" ToobarTitle="เพิ่มรายการ" ToolbarImage="../../Images/icn_add.png" OnClick="tbAddFormulaMilkItemClick"  />
                                        <uc1:ToolBarItemCtl ID="tbDeleteFormulaMilkItem" runat="server" ToobarTitle="ลบรายการ" ToolbarImage="../../Images/icn_delete.png" OnClick ="tbDeleteFormulaMilkItemClick"  ClientClick="return confirm('ต้องการลบข้อมูลที่เลือก ใช่หรือไม่?')"   />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbStatusFormulaSetItem" runat="server" EnableViewState="False"></asp:Label></td> 
                                </tr> 
                            </table>
                            <asp:GridView ID="grvFormulaMilkItem" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="t_tablestyle" PageSize="20" 
                                OnRowDataBound="grvFormulaMilkItem_RowDataBound" >
                                <Columns>
                                    <asp:BoundField DataField="FMILOID" HeaderText="FMILOID" ReadOnly ="True" >
                                         <ControlStyle CssClass="zHidden" />
                                        <FooterStyle CssClass="zHidden" />
                                        <HeaderStyle CssClass="zHidden" />
                                        <ItemStyle CssClass="zHidden" />
                                    </asp:BoundField> 

                                    <asp:TemplateField >
                                        <HeaderTemplate>
                                           <asp:CheckBox ID="chkAll" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSelect" runat ="server" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign = "Center" Width ="30px" />
                                        <HeaderStyle HorizontalAlign = "Center"  Width="30px" />
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="ลำดับ" >
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                        <HeaderStyle Width="60px" />
                                        <ItemStyle HorizontalAlign="Center" Width="60px" />
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="ส่วนผสม" >
                                        <ItemTemplate>
                                           <asp:Label ID="lblName"  runat="server" Text='<%# Bind("MATERIALNAME") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                        <ItemStyle HorizontalAlign="Left" Width="200px"  />
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="จำนวน" >
                                        <ItemTemplate >
                                            <asp:TextBox ID="txtQty" runat="server" Text='<%# Bind("QTY", "{0:#,##0.00}") %>' CssClass="zTextboxR" Width="85px"></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="90px" />
                                        <ItemStyle HorizontalAlign="Right" Width="90px" />
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="หน่วยนับ" >
                                        <ItemTemplate>
                                           <asp:Label ID="lblUnitname" runat="server" Text='<%# Bind("UNITNAME") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" Width="90px" />
                                        <ItemStyle HorizontalAlign="Left" Width="90px" />
                                    </asp:TemplateField>
                                        
                                    <asp:BoundField DataField="UULOID" HeaderText="UULOID" ReadOnly = "True" >
                                        <ControlStyle CssClass="zHidden" />
                                        <FooterStyle CssClass="zHidden" />
                                        <HeaderStyle CssClass="zHidden" />
                                        <ItemStyle CssClass="zHidden" />
                                    </asp:BoundField>
                                    
                                    <asp:BoundField DataField="FMLOID" HeaderText="FMLOID" ReadOnly ="True" >
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
                                <PagerSettings Visible="False" />
                            </asp:GridView>
                
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="tpnNutrient" runat="server"  HeaderText="สารอาหารที่ได้รับ">
                        <ContentTemplate>
                            <asp:GridView ID="grvNutrient" runat="server" ShowFooter ="True" AllowSorting="True" AutoGenerateColumns="False" CssClass="t_tablestyle" >
                                <Columns>
                                    <asp:BoundField DataField="LOID" HeaderText="LOID">
                                        <ControlStyle CssClass="zHidden" />
                                        <FooterStyle CssClass="zHidden" />
                                        <HeaderStyle CssClass="zHidden" />
                                        <ItemStyle CssClass="zHidden" />
                                    </asp:BoundField>
                                    
                                     <asp:TemplateField HeaderText="ลำดับ" >
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign = "Center" Width="60px" />
                                        <ItemStyle HorizontalAlign = "Center" Width="60px" Height="20px" />
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="สารอาหาร" >
                                        <ItemTemplate>
                                           <asp:Label ID="lblNutrientName" runat="server" Text='<%# Bind("NUTRIENTNAME") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                        <ItemStyle HorizontalAlign="Left" Width="200px" />
                                        
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="ปริมาณ" >
                                        <ItemTemplate>
                                           <asp:Label ID="lblNutrientCost" runat="server" Text='<%# Bind("QTY", "{0:#,##0.00}") %>'></asp:Label>
                                        </ItemTemplate>
                                       <HeaderStyle HorizontalAlign="Center" Width="150px" />
                                        <ItemStyle HorizontalAlign="Left" Width="150px" />
                                    </asp:TemplateField>
                                    
                                </Columns>
                                <HeaderStyle CssClass="t_headtext" />
                                <AlternatingRowStyle CssClass="t_alt_bg" />
                                <PagerSettings Visible="False" />
                            </asp:GridView>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    
                    
                </cc1:TabContainer><br />
                &nbsp;</td>
        </tr>
    </table>
        <uc3:MaterialMasterPopup ID="ctlMaterialMasterPopup" runat="server"  OnSelectedIndexChanged="ctlMaterialMasterPopup_SelectedIndexChanged" OnCancel="ctlMaterialMasterPopup_Cancel" />
        <asp:HiddenField ID="hdShowMaterialPopup" runat="server" />
    </asp:Panel>
</asp:Content>

