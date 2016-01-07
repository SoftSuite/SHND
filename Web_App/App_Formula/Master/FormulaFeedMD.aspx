<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="FormulaFeedMD.aspx.cs" Inherits="App_Formula_Master_FormulaFeedMD" Title="SHND : Master - FormularFeedMD " %>
<%@ Register Src="../../Search/MaterialMasterPopup.ascx" TagName="MaterialMasterPopup" TagPrefix="uc3" %>
<%@ Register Src="../../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="headtext">
                ข้อมูลสูตรอาหารทางการแพทย์</td>
        </tr>
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

                    <table cellspacing="0" cellpadding="0" border="0" width="600px">
                        <tr style="height:15px">
                            <td colspan="4">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:120px; text-align: right; padding-right:10px; height: 24px;">ชนิดของอาหาร :</td>
                            <td colspan="3" style="height: 24px"><asp:DropDownList runat ="server" ID="cmbType" CssClass="zCombo" Width ="106px" ></asp:DropDownList> </td>
                            
                        </tr>
                        <tr style="height:24px">
                            <td style="width:120px; text-align: right; padding-right:10px">พลังงาน :</td>
                            <td style="width: 150px"><asp:TextBox ID="txtEnergyFrom" runat="server" CssClass="zTextboxR" MaxLength="50" Width="100px"></asp:TextBox>
                                <asp:Label ID="label1" runat="server" >kcal</asp:Label>   </td>   
                            <td style="width:50px;" align="center">ถึง</td>
                            <td style="width: 451px"><asp:TextBox ID="txtEnergyTo" runat="server" CssClass="zTextboxR" MaxLength="50" Width="100px"></asp:TextBox>
                                <asp:Label ID="label2" runat="server" >kcal</asp:Label>
                            </td>                 
                        </tr>
                         <tr style="height:24px">
                            <td style="width:120px; text-align: right; padding-right:10px">ปริมาณ :</td>
                            <td style="width: 150px"><asp:TextBox ID="txtCapFrom" runat="server" CssClass="zTextboxR" MaxLength="50" Width="100px"></asp:TextBox>
                                <asp:Label ID="label3" runat="server" >ml</asp:Label>  </td>    
                            <td style="width:50px;" align="center">ถึง</td>
                            <td style="width: 451px"><asp:TextBox ID="txtCapTo" runat="server" CssClass="zTextboxR" MaxLength="50" Width="100px"></asp:TextBox>
                                <asp:Label ID="label4" runat="server" >ml</asp:Label> 
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:ImageButton ID="imbSearch" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_find.png"
                                OnClick="imbSearch_Click" />
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
            </td>
        </tr>
        <tr>
            <td>
                <uc2:PageControl ID="pcTop" runat="server"  OnPageChange="PageChange" />
                <asp:GridView ID="grvResult" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="t_tablestyle" PageSize="20" 
                    OnRowDataBound="grvResult_RowDataBound" OnSorting="grvResult_Sorting" AllowPaging="True" OnRowDeleting="grvResult_RowDeleting" 
                    OnSelectedIndexChanging="grvResult_SelectedIndexChanging" Width="100%">
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
                                <asp:ImageButton runat = "server" ID = "imbCopyMain" CommandName= "Select" ImageUrl="~/Images/icn_copy.png"  OnClientClick="return confirm('ต้องการคัดลอกรายการข้อมูลสูตรใช่หรือไม่?')" />
                            </ItemTemplate>
                            <HeaderStyle Width="60px" />
                            <ItemStyle Width="60px" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="ลำดับ" SortExpression="DEFAULT">
                            <HeaderStyle Width="60px" />
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="ชนิดของอาหาร" SortExpression="FORMULANAME">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkType" runat="server"  OnClick="lnkType_Click"   Text='<%# Bind("FORMULANAME") %>' CommandArgument='<%# Bind("LOID")  %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:BoundField DataField="STRONG" HeaderText="ความเข้มข้น (Kcal/ml)" SortExpression="STRONG" HtmlEncode="false" DataFormatString="{0:#,##0.00}">
                            <HeaderStyle Width="130px" />
                            <ItemStyle HorizontalAlign="Right" Width="130px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CAPACITY" HeaderText="ปริมาณ (ml)" SortExpression="CAPACITY" HtmlEncode="false" DataFormatString="{0:#,##0.00}">
                            <HeaderStyle Width="80px" />
                            <ItemStyle HorizontalAlign="Right" Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ENERGY" HeaderText="พลังงาน (Kcal)" SortExpression="ENERGY" HtmlEncode="false" DataFormatString="{0:#,##0.00}">
                            <HeaderStyle Width="100px" />
                            <ItemStyle HorizontalAlign="Right" Width="100px" />
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
    <cc1:ModalPopupExtender ID="FormulaFeedMDPop" runat="server" TargetControlID="tbAdd$lb" PopupControlID="Panel1" BackgroundCssClass="modalBackground" DropShadow="true"></cc1:ModalPopupExtender>
    <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" style="display:none" Width="800px" Height="600" ScrollBars="Auto">
    <table cellspacing="0" cellpadding="0" border="0" width="100%">
        <tr>
            <td style="height: 20px">
        <uc1:ToolBarItemCtl ID="tbSave" runat="server" ToobarTitle="บันทึก" ToolbarImage="../../Images/save2.png"  OnClick="tbSave1Click" />
        <uc1:ToolBarItemCtl ID="tbReturn" runat="server" ToobarTitle="ยกเลิกการแก้ไข" ToolbarImage="../../Images/cancel.png"   OnClick="tbReturnClick"  />
        <uc1:ToolBarItemCtl ID="tbBack" runat="server" ToobarTitle="กลับหน้ารายการ" ToolbarImage="../../Images/icn_back.png"  OnClick="tbBackClick"/>
        <uc1:ToolBarItemCtl ID="tbPrint" runat ="server" ToolbarImage="../../Images/icn_print.png" ToobarTitle ="พิมพ์" />
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
                        <td align="right" style="width: 150px"> 
                            <asp:TextBox
                                    ID="txhID" runat="server" Width="1px" Height="9px" Visible="False"></asp:TextBox>
                            <asp:TextBox ID="txtFormulaSetItemRow" runat="server" Visible="False" Width="5px"></asp:TextBox>
                            <asp:TextBox ID="txtFullEnergy" runat="server" Visible="False" Width="5px"></asp:TextBox>
                            <asp:TextBox ID="txtflage" runat="server" Visible="False" Width="5px">0</asp:TextBox>&nbsp;
                            <asp:TextBox ID="txtCalWeight" runat="server" Width="13px" Visible="False"></asp:TextBox>
                            <asp:TextBox ID="txhSortField" runat="server" Visible="False" Width="15px"></asp:TextBox><asp:TextBox
                                ID="txhSortDir" runat="server" Visible="False" Width="15px"></asp:TextBox></td>
                        <td style="height:15px; width: 519px;">
                            <asp:Label ID="lbStatus" runat="server" EnableViewState="False"></asp:Label></td>
                    </tr>
                    <tr>
                        <td  style="width:150px" align="right"> ชนิดอาหารทางการแพทย์ :</td>
                        <td style="width: 519px">
                            <asp:DropDownList ID="cmbFoodMDType" runat ="server" CssClass ="zCombo" Width ="300px"></asp:DropDownList><span style="color:red">*</span></td>
                    </tr>
                    <tr>
                        <td style="width:150px" align="right"> ปริมาณ:</td>
                        <td style="width: 519px" >
                            <asp:TextBox ID="txtAddcap" runat="server" CssClass="zTextbox" MaxLength="50" AutoPostBack="True" OnTextChanged="txtAddcap_TextChanged"></asp:TextBox>
                            <asp:Label ID="label5" runat ="server" >ml</asp:Label>
                            <span style="color: #ff0000">*</span><span style="color:red"></span>
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 
                            <asp:CheckBox ID="chkActive" runat="server" Checked="True" Text="ใช้งาน" />
                        
                            
                        </td>
                        
                    </tr>
                    <tr>
                        <td style="width:150px"  align="right"> อัตราส่วน :</td>
                        <td style="width: 519px" >
                            <asp:TextBox ID="txtAddEnerRate" runat="server" CssClass="zTextbox" MaxLength="50" Width="59px" AutoPostBack="True" OnTextChanged="txtAddEnerRate_TextChanged"></asp:TextBox>
                            <asp:Label ID="label6" runat ="server" >Kcal :</asp:Label>
                            <asp:TextBox ID="txtAddCapRate" runat="server" CssClass="zTextbox" MaxLength="50" Width="40px" AutoPostBack="True" OnTextChanged="txtAddCapRate_TextChanged"></asp:TextBox>
                            <asp:Label ID="label7" runat ="server" >ml</asp:Label>
                            <span style="color: #ff0000">*</span><span style="color:red"></span>
                             &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;
                            <asp:Label runat="server" ID="label9">พลังงาน</asp:Label>
                            <asp:TextBox ID="txtAddEnergy" runat="server" CssClass="zTextbox-View" MaxLength="50" Width="93px" ReadOnly="True"></asp:TextBox>
                            <asp:Label ID="label8" runat ="server" >kcal</asp:Label>
                       </td>     
                    </tr>
                    <tr>
                        <td colspan ="2">
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                            <asp:ImageButton runat="server" ID ="calculator" ImageUrl="~/Images/icn_calculate.png" OnClick="calculator_Click"  />
                            <asp:Label runat="server" ID="label12" Enabled="False" >วัตถุดิบเริ่มต้น</asp:Label>
                        </td>
                    </tr>
                </table>
                &nbsp;
                
                
                
                
                <cc1:TabContainer ID="TabContainer1" runat="server"  ActiveTabIndex="0" AutoPostBack="true"   OnActiveTabChanged="TabChanged_Click" Visible="False">
        
                    <cc1:TabPanel ID="tpnInventory" runat="server" HeaderText="รายการวัตถุดิบ">
                        <ContentTemplate>
                         <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td class="subheadertext">รายการวัตถุดิบในสูตร
                                    </td> 
                                </tr>
                                <tr>
                                    <td class="toolbarplace">
                                        <uc1:ToolBarItemCtl ID="tbAddFormulaSetItem" runat="server" ToobarTitle="เพิ่มรายการ" ToolbarImage="../../Images/icn_add.png" OnClick="tbAddFormulaFeedItemClick"  />
                                        <uc1:ToolBarItemCtl ID="tbDeleteFormulaSetItem" runat="server" ToobarTitle="ลบรายการ" ToolbarImage="../../Images/icn_delete.png" OnClick ="tbDeleteFormulaFeedItemClick"  ClientClick="return confirm('ต้องการลบข้อมูลที่เลือก ใช่หรือไม่?')"   />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbStatusFormulaSetItem" runat="server" EnableViewState="False"></asp:Label></td> 
                                </tr> 
                            </table>
                            <asp:GridView ID="grvInventory" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="t_tablestyle" PageSize="20" OnRowDataBound="grvInventory_RowDataBound" OnSorting="grvResult_Sorting" AllowPaging="True" OnRowEditing="grvInventory_RowEditing" OnRowUpdating="grvInventory_RowUpdating" OnRowCancelingEdit="grvInventory_RowCancelingEdit">
                    <Columns>
                        <asp:BoundField DataField="LOID" HeaderText="LOID" ReadOnly ="True" >
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

                            <ItemStyle HorizontalAlign = "Center" Width ="60px" />
                            <HeaderStyle HorizontalAlign = "Center"  Width="60px" />
                            <FooterStyle HorizontalAlign = "Center" Width ="60px" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="ลำดับ" >
                            <HeaderStyle HorizontalAlign="Center" Width="60px" />
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="ส่วนผสม" >
                            <ItemTemplate>
                               <asp:Label ID="lblName"  runat="server" Text='<%# Bind("MATERIALNAME") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtNewName" CssClass ="zTextbox" ReadOnly ="true" runat="server" Text='<%#Bind("MATERIALNAME")%>' ></asp:TextBox >
                                <asp:ImageButton ID="imbSearch" runat="server" ImageUrl="~/Images/icn_find.png" OnClick ="imbNewSearch_Click"  ImageAlign="absmiddle"  CommandArgument="-1"/>
                            </FooterTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="200px" />
                            <ItemStyle Width="200px"  />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="จำนวน" >
                            <ItemTemplate >
                                <asp:TextBox ID="txtEditCost" runat="server" Text='<%#Bind("COST")%>' Width="85px"></asp:TextBox>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtNewCost" runat="server" Text='<%#Bind("COST")%>' Width="85px"></asp:TextBox>
                            </FooterTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="90px" />
                            <ItemStyle HorizontalAlign="Right" Width="90px" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="หน่วยนับ" >
                            <ItemTemplate>
                               <asp:Label ID="lblAbbName" runat="server" Text='<%# Bind("ABBNAME") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate >
                               <asp:Label ID="txtEditABBName" runat="server" Text='<%# Bind("ABBNAME") %>'></asp:Label>
                            </EditItemTemplate>
                            <FooterTemplate>
                               <asp:Label ID="lblAddABBName" runat="server" Text='<%# Bind("ABBNAME") %>'></asp:Label>
                            </FooterTemplate>
                            <HeaderStyle HorizontalAlign="Left" Width="90px" />
                            <ItemStyle Width="90px" />
                        </asp:TemplateField>
                            
                        <asp:BoundField DataField="UULOID" HeaderText="UULOID" ReadOnly = "True" >
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        
                        <asp:BoundField DataField="FFLOID" HeaderText="FFLOID" ReadOnly ="True" >
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>  
                        
                         <asp:BoundField DataField="FILOID" HeaderText="FILOID" ReadOnly ="True" >
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
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td class="subheadertext">สารอาหารที่ได้รับ
                                    </td> 
                                </tr>
    
                            </table>
                            <asp:GridView ID="grvNutrient" runat="server" ShowFooter ="True" AllowSorting="True" AutoGenerateColumns="False" CssClass="t_tablestyle"  AlowPaging="True" PageSize="20" AllowPaging="True" OnRowDataBound="grvNutrient_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="LOID" HeaderText="LOID">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        
                         <asp:TemplateField HeaderText="ลำดับ" >
                            <HeaderStyle HorizontalAlign = "Center" Width="60px" />
                            <ItemStyle HorizontalAlign = "Center" Width="60px" Height="20px" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="สารอาหาร" >
                            <ItemTemplate>
                               <asp:Label ID="lblNutrientName" runat="server" Text='<%# Bind("NUTRIENTNAME") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="200px" />
                            <ItemStyle Width="200px" />
                            
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="ปริมาณ" >
                            <ItemTemplate>
                               <asp:Label ID="lblNutrientCost" runat="server"  Text='<%# Bind("QTY") %>'  ></asp:Label>
                            </ItemTemplate>
                           <HeaderStyle HorizontalAlign="Center" Width="150px" />
                            <ItemStyle HorizontalAlign="Right" Width="150px" />
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
        <uc3:MaterialMasterPopup ID="ctlMaterialMasterPopup" runat="server"   OnSelectedIndexChanged="ctlMaterialMasterPopup_SelectedIndexChanged" OnCancel="ctlMaterialMasterPopup_Cancel"/>
    </asp:Panel>
</asp:Content>