<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="FormulaFeedLDSearch.aspx.cs" Inherits="App_Formula_Master_FormulaFeedLDSearch" Title="SHND : Master - Formula Feed Liquid Diet" %>

<%@ Register Src="../../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../../Search/MaterialMasterPopup.ascx" TagName="MaterialMasterPopup" TagPrefix="uc3" %>
<%@ Register Src="../../Search/DiseaseCategoryPopup.ascx" TagName="DiseaseCategoryPopup" TagPrefix="uc4" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="headtext">
                ข้อมูลสูตรอาหาร Liquid Diet</td>
        </tr>
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbAdd" runat="server" ToobarTitle="เพิ่มข้อมูล"  ToolbarImage="../../Images/icn_add.png"  />
            </td>
        </tr>
        <tr>
            <td>
                <hr style="size:1px" />
                <asp:Label ID="lbStatusMain" runat="server" EnableViewState="False"></asp:Label></td>
        </tr>
        <tr>
            <td style="height: 15px">
                <fieldset style="padding:15px;">
                    <legend style="font-weight:bold">
                        ค้นหา
                    </legend>
                    <table cellspacing="0" cellpadding="0" border="0" width="700px">
                        <tr style="height:15px">
                            <td colspan="4">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:120px; text-align: right; padding-right:10px; height: 24px;">ชื่อสูตรอาหาร :</td>
                            <td colspan="3" style="height: 24px">
                                <asp:TextBox ID="txtNameSearch" runat="server"  CssClass="zTextbox" Width="290px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:120px; text-align: right; padding-right:10px; height: 24px;">พลังงาน :</td>
                            <td style="width: 150px; height: 24px;">
                                <asp:TextBox ID="txtEnergyFrom" runat="server"  CssClass="zTextboxR" Width="96px" ></asp:TextBox>&nbsp;kcal
                            </td>
                            <td style="width: 150px; height: 24px;">
                                ถึง&nbsp;<asp:TextBox ID="txtEnergyTo" runat="server"  CssClass="zTextboxR" Width="96px" ></asp:TextBox>&nbsp;kcal
                            </td>
                            <td style="height: 24px; width: 280px;">
                            </td>
                        </tr>
                        <tr>
                            <td style="width:120px; text-align: right; padding-right:10px; height: 24px;">ปริมาณ :</td>
                            <td style="width: 150px; height: 24px;">
                                <asp:TextBox ID="txtCapacityFrom" runat="server" Width="96px"  CssClass="zTextboxR"></asp:TextBox>&nbsp;ml
                            </td>
                            <td style="width: 150px; height: 24px;">
                                ถึง&nbsp;<asp:TextBox ID="txtCapacityTo" runat="server" Width="96px"  CssClass="zTextboxR"></asp:TextBox>&nbsp;ml
                            </td>
                            <td style="height: 24px; width: 280px;">&nbsp;
                            <asp:ImageButton ID="imbSearch" runat="server" ImageUrl="~/Images/icn_find.png" OnClick="imbSearch_Click" ImageAlign="absMiddle" />
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
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <uc2:PageControl ID="pcTop" runat="server"  OnPageChange="PageChange" /> 
                    <asp:GridView ID="gvMain" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="t_tablestyle" OnSorting="gvMain_Sorting" 
                        OnRowDataBound="gvMain_RowDataBound" OnSelectedIndexChanging="gvMain_SelectedIndexChanging" OnRowDeleting="gvMain_RowDeleting" Width="100%" >
                    <Columns>
                        <asp:BoundField DataField="LOID" HeaderText="LOID">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imbDelete" runat="server" CausesValidation="true" CommandName="Delete" ImageUrl="~/Images/icn_delete.png" OnClientClick="return confirm('ต้องการลบข้อมูล ใช่หรือไม่?')" />
                                    <asp:ImageButton ID="imbCopy" runat="server" CausesValidation="true" CommandName="Select" ImageUrl="~/Images/icn_copy.png" OnClientClick="return confirm('ต้องการคัดลอกรายการข้อมูลสูตรใช่หรือไม่?')"/>&nbsp;
                                </ItemTemplate>
                            <HeaderStyle Width="60px" />
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                            <FooterStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ลำดับ" SortExpression="DEFAULT">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate> 
                            <EditItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </EditItemTemplate> 
                            <HeaderStyle HorizontalAlign="Center" Width="60px" />
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ชื่อสูตรอาหาร" SortExpression="NAME">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkName" runat="server" Text='<%# Bind("NAME") %>' OnClick="lnkName_Click" CommandArgument='<%# Bind("LOID")  %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ENERGY" HeaderText="พลังงาน(Kcal)" ReadOnly="True" SortExpression="ENERGY" DataFormatString="{0:#,##0.######}" HtmlEncode="false">
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PORTION" HeaderText="Portion" ReadOnly="True" SortExpression="PORTION">
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CAPACITY" HeaderText="ปริมาณ(ml)" ReadOnly="True" SortExpression="CAPACITY" DataFormatString="{0:#,##0.##########}" HtmlEncode="false">
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ACTIVE" HeaderText="การใช้งาน" ReadOnly="True" SortExpression="ACTIVE">
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundField>
                    </Columns>
                    <HeaderStyle CssClass="t_headtext" />
                    <AlternatingRowStyle CssClass="t_alt_bg" />
                    <PagerSettings Visible="False" />
                </asp:GridView>
               <uc2:PageControl ID="pcBot" runat="server"  OnPageChange="PageChange" /> 
            </td>
        </tr>
    </table>
    <cc1:ModalPopupExtender ID="zPop" runat="server" TargetControlID="tbAdd$lb" PopupControlID="Panel1" BackgroundCssClass="modalBackground" DropShadow="true"></cc1:ModalPopupExtender>
    <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" ScrollBars="Auto" style="display:none" Width="950px" Height="600px">
        <asp:TextBox ID="txhSortField" runat="server" Visible="False" Width="15px"></asp:TextBox>
        <asp:TextBox ID="txhSortDir" runat="server" Visible="False" Width="15px"></asp:TextBox>
        <asp:TextBox ID="txhID" runat="server" Visible="False" Width="15px"></asp:TextBox>&nbsp;
        <asp:TextBox ID="txtPrevTabIndex" runat="server" Width="32px" Visible="False">0</asp:TextBox>
    
        <table cellspacing="0" cellpadding="0" border="0" width="100%">
            <tr>
                <td>
                    <uc1:ToolBarItemCtl ID="tbSave" runat="server" ToobarTitle="บันทึก" ToolbarImage="../../Images/save2.png" OnClick="tbSaveClick" />
                    <uc1:ToolBarItemCtl ID="tbSave2" runat="server" ToobarTitle="บันทึกและเพิ่มรายการใหม่" ToolbarImage="../../Images/icn_save_add.png" OnClick="tbSave2Click"  />
                    <uc1:ToolBarItemCtl ID="tbCancel" runat="server" ToobarTitle="ยกเลิกการแก้ไข" ToolbarImage="../../Images/cancel.png" OnClick="tbCancelClick" />
                    <uc1:ToolBarItemCtl ID="tbBack" runat="server" ToobarTitle="กลับหน้ารายการ" ToolbarImage="../../Images/icn_back.png" OnClick="tbBackClick"/>
                </td>
            </tr>
            <tr>
                <td><hr style="size:1px" /></td>
            </tr>
        </table>
        <table cellspacing="0" cellpadding="10" border="0" style="border-right: thin solid; border-top: thin solid; border-left: thin solid; border-bottom: thin solid" width="100%" >
            <tr>
                <td>
                    <table cellspacing="0" cellpadding="1" border="0">
                        <tr>
                            <td style="width: 110px; padding-right: 10px; text-align: right;">
                            </td>
                            <td>
                                <asp:Label ID="lblStatus" runat="server" ForeColor="red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 110px; padding-right: 10px; text-align: right;">ชื่อสูตร :</td>
                            <td>
                                <asp:TextBox id="txtName" runat="server" CssClass="zTextbox" Width="270px"></asp:TextBox>
                                <asp:Label ID="Label1" runat="server" Text="*" ForeColor="red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 110px; padding-right: 10px; text-align: right;">ชนิดอาหาร :</td>
                            <td>
                                <asp:TextBox id="txtFeedCategory" runat="server" ReadOnly="true" CssClass="zTextbox-View" Text="Liquid Diet" Width="270px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 110px; padding-right: 10px; text-align: right;">ปริมาณ :</td>
                            <td>
                                <asp:TextBox id="txtCapacity" runat="server" CssClass="zTextboxR"></asp:TextBox>&nbsp;ml
                                <asp:Label ID="Label2" runat="server" Text="*" ForeColor="red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 110px; padding-right: 10px; text-align: right;">พลังงาน :</td>
                            <td>
                                <asp:TextBox id="txtEnergy" runat="server" ReadOnly="true" CssClass="zTextboxR-View"></asp:TextBox>&nbsp;kcal
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 110px; padding-right: 10px; text-align: right;">Portion :</td>
                            <td>
                                <asp:TextBox id="txtPortion" runat="server" CssClass="zTextboxR"></asp:TextBox>&nbsp;คน
                                <asp:Label ID="Label4" runat="server" Text="*" ForeColor="red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 110px; padding-right: 10px; text-align: right;">&nbsp;
                                <asp:TextBox ID="txtFormulaFeedLOID" runat="server" Width="54px" Visible="False"></asp:TextBox></td>
                            <td>
                                <asp:CheckBox id="chkActive" runat="server" Text="ใช้งาน" Checked="true" ></asp:CheckBox>
                            </td>
                        </tr>
                        <tr style="height:5px">
                        </tr>
                    </table>
                </td>
            </tr>
        </table><br />
        <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" OnActiveTabChanged="TabContainer1_ActiveTabChanged" AutoPostBack="true">
            <cc1:TabPanel ID="tabFeedLDItem" runat="server" HeaderText="รายการวัตถุดิบ">
                <ContentTemplate>
                    <table cellspacing="0" cellpadding="0" border="0" width="1000px">
                        <tr>
                            <td class="subheadertext" style="height: 25px">
                                &nbsp;รายการวัตถุดิบในสูตร
                            </td>
                        </tr>
                        <tr>
                            <td class="toolbarplace">
                                <uc1:ToolBarItemCtl ID="tbAddFormulaFeedItem" runat="server" ToobarTitle="เพิ่มรายการ" ToolbarImage="../../Images/icn_add.png" OnClick="tbAddFormulaFeedItemClick" />
                                <uc1:ToolBarItemCtl ID="tbDeleteFormulaFeedItem" runat="server" ToobarTitle="ลบรายการ" ToolbarImage="../../Images/icn_delete.png"  ClientClick="return confirm('ต้องการลบข้อมูลที่เลือก ใช่หรือไม่?')" OnClick="tbDeleteFormulaFeedItemClick"/>
                                <asp:TextBox ID="txhSortDirGVFeedLDItem" runat="server" Visible="False" Width="15px"></asp:TextBox>
                                <asp:TextBox ID="txhSortFieldGVFeedLDItem" runat="server" Visible="False" Width="15px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lbStatusFeedItem" runat="server" EnableViewState="False"></asp:Label></td> 
                        </tr> 
                    </table>
                    <asp:GridView ID="gvFeedLDItem" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="t_tablestyle" OnRowDataBound="gvFeedLDItem_RowDataBound" OnSorting="gvFeedLDItem_Sorting" >
                        <Columns>
                            <asp:BoundField DataField="FFILOID" HeaderText="FFILOID" ReadOnly="True">
                                <ControlStyle CssClass="zHidden" />
                                <FooterStyle CssClass="zHidden" />
                                <HeaderStyle CssClass="zHidden" Width="50px" />
                                <ItemStyle CssClass="zHidden" />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                   <asp:CheckBox ID="chkAll" runat="server" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelect" runat="server" />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="30px" />
                                <ItemStyle HorizontalAlign="Center" Width="30px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ลำดับ">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate> 
                                <EditItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </EditItemTemplate> 
                                <HeaderStyle HorizontalAlign="Center" Width="30px" />
                                <ItemStyle HorizontalAlign="Center" Width="30px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ส่วนผสม" SortExpression="MMNAME">
                                <ItemTemplate>
                                    <asp:Label ID="lblNAME" runat="server" Text='<%# Bind("MMNAME") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="155px" />
                                <ItemStyle Width="155px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="จำนวน" >
                                <ItemTemplate>
                                    <asp:TextBox ID="txtQTYAdd" runat="server" CssClass="zTextboxR" Text='<%# Bind("QTY") %>'  Width="60px" OnTextChanged="QTYCalculate" AutoPostBack="true" ToolTip='<%# Container.DataItemIndex %>'></asp:TextBox>
                                    <asp:Label ID="lblQTYAdd" runat="server" Text="*" ForeColor="red"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                <ItemStyle HorizontalAlign="Right" Width="80px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="หน่วยนับ" >
                                <ItemTemplate>
                                    <asp:DropDownList ID="cmbUnitAdd" runat="server" Width="80px" CssClass="zComboBox" OnSelectedIndexChanged="UnitCalculate" AutoPostBack="true" ToolTip='<%# Container.DataItemIndex %>'></asp:DropDownList>
                                    <asp:Label ID="lblUnitAdd" runat="server" Text="*" ForeColor="red"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="95px" />
                                <ItemStyle Width="95px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="พลังงาน(kcal)" >
                                <ItemTemplate>
                                    <asp:Label ID="lblEnergy" runat="server" Text='<%# Bind("ENERGY") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="70px" />
                                <ItemStyle HorizontalAlign="Right" Width="70px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="คาร์โบไฮเดรต(g)" >
                                <ItemTemplate>
                                    <asp:Label ID="lblCARBOHYDRATE" runat="server" Text='<%# Bind("CARBOHYDRATE") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                <ItemStyle HorizontalAlign="Right" Width="80px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="โปรตีน(g)" >
                                <ItemTemplate>
                                    <asp:Label ID="lblPROTEIN" runat="server" Text='<%# Bind("PROTEIN") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="70px" />
                                <ItemStyle HorizontalAlign="Right" Width="70px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ไขมัน(g)" >
                                <ItemTemplate>
                                    <asp:Label ID="lblFAT" runat="server" Text='<%# Bind("FAT") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="70px" />
                                <ItemStyle HorizontalAlign="Right" Width="70px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="โซเดียม(mg)" >
                                <ItemTemplate>
                                    <asp:Label ID="lblSODIUM" runat="server" Text='<%# Bind("SODIUM") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="70px" />
                                <ItemStyle HorizontalAlign="Right" Width="70px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="MMLOID" HeaderText="MMLOID" ReadOnly="True">
                                <ControlStyle CssClass="zHidden" />
                                <FooterStyle CssClass="zHidden" />
                                <HeaderStyle CssClass="zHidden" />
                                <ItemStyle CssClass="zHidden" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="ฟอสฟอรัส(mg)" >
                                <ItemTemplate>
                                    <asp:Label ID="lblPhosphorus" runat="server" Text='<%# Bind("PHOSPHORUS") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="70px" />
                                <ItemStyle HorizontalAlign="Right" Width="70px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="โพแทสเซียม(mg)" >
                                <ItemTemplate>
                                    <asp:Label ID="lblPotassium" runat="server" Text='<%# Bind("POTASSIUM") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="70px" />
                                <ItemStyle HorizontalAlign="Right" Width="70px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="แคลเซียม(mg)" >
                                <ItemTemplate>
                                    <asp:Label ID="lblCalcium" runat="server" Text='<%# Bind("CALCIUM") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="70px" />
                                <ItemStyle HorizontalAlign="Right" Width="70px" />
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle CssClass="t_headtext" />
                        <AlternatingRowStyle CssClass="t_alt_bg" />
                        <PagerSettings Visible="False" />
                    </asp:GridView>
                </ContentTemplate>
            </cc1:TabPanel>
            <cc1:TabPanel ID="tabLDDisease" runat="server" HeaderText="สารอาหารที่ควบคุม">
                <ContentTemplate>
                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                        <tr>
                            <td class="subheadertext" style="height: 25px">
                                &nbsp;ชนิดสารอาหารที่ควบคุม
                            </td>
                        </tr>
                        <tr>
                            <td class="toolbarplace">
                                <uc1:ToolBarItemCtl ID="tbAddFormulaDisease" runat="server" ToobarTitle="เพิ่มรายการ" ToolbarImage="../../Images/icn_add.png" OnClick="tbAddFormulaDiseaseClick" />
                                <uc1:ToolBarItemCtl ID="tbDeleteFormulaDisease" runat="server" ToobarTitle="ลบรายการ" ToolbarImage="../../Images/icn_delete.png"  ClientClick="return confirm('ต้องการลบข้อมูลที่เลือก ใช่หรือไม่?')" OnClick="tbDeleteFormulaDiseaseClick" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label3" runat="server" EnableViewState="False"></asp:Label></td> 
                        </tr> 
                    </table>
                    <asp:GridView ID="gvLDDisease" runat="server" AutoGenerateColumns="False" CssClass="t_tablestyle" OnRowDataBound="gvLDDisease_RowDataBound" Width="100%" >
                        <HeaderStyle CssClass="t_headtext" />
                        <PagerSettings Visible="False" />
                        <AlternatingRowStyle CssClass="t_alt_bg" />
                        <Columns>
<asp:BoundField ReadOnly="True" DataField="FDLOID" HeaderText="FDLOID">
<ControlStyle CssClass="zHidden"></ControlStyle>

<ItemStyle CssClass="zHidden"></ItemStyle>

<HeaderStyle CssClass="zHidden"></HeaderStyle>

<FooterStyle CssClass="zHidden"></FooterStyle>
</asp:BoundField>
<asp:TemplateField><HeaderTemplate>
                                   <asp:CheckBox ID="chkAll" runat="server" />
                                
</HeaderTemplate>

<ItemStyle Width="30px" HorizontalAlign="Center"></ItemStyle>

<HeaderStyle Width="30px" HorizontalAlign="Center"></HeaderStyle>
<ItemTemplate>
                                    <asp:CheckBox ID="chkSelect" runat="server" />
                                
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="ลำดับ"><EditItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                
</EditItemTemplate>

<ItemStyle Width="40px" HorizontalAlign="Center"></ItemStyle>

<HeaderStyle Width="40px" HorizontalAlign="Center"></HeaderStyle>
<ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="สารอาหารที่ควบคุม">
<ItemTemplate>
                                    <asp:Label ID="lblDCNAME" runat="server" Text='<%# Bind("DCNAME") %>'></asp:Label>
                                
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="High">
<ItemStyle Width="60px" HorizontalAlign="Center"></ItemStyle>

<HeaderStyle Width="60px" HorizontalAlign="Center"></HeaderStyle>
<ItemTemplate>
                                    <asp:RadioButton ID="radISHIGH" runat="server" GroupName="Disease" Checked='<%# Eval("FDISHIGH").ToString() == "Y" %>' Visible='<%# Eval("DCISHIGHVISIBLE").ToString() == "Y" %>' OnCheckedChanged="UpdateTmpDisease" AutoPostBack="true" ToolTip='<%# Container.DataItemIndex %>' />
                                
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Low">
<ItemStyle Width="60px" HorizontalAlign="Center"></ItemStyle>

<HeaderStyle Width="60px" HorizontalAlign="Center"></HeaderStyle>
<ItemTemplate>
                                    <asp:RadioButton ID="radISLOW" runat="server" GroupName="Disease" Checked='<%# Eval("FDISLOW").ToString() == "Y" %>' Visible='<%# Eval("DCISLOWVISIBLE").ToString() == "Y" %>' OnCheckedChanged="UpdateTmpDisease" AutoPostBack="true" ToolTip='<%# Container.DataItemIndex %>'  />
                                
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Non">
<ItemStyle Width="60px" HorizontalAlign="Center"></ItemStyle>

<HeaderStyle Width="60px" HorizontalAlign="Center"></HeaderStyle>
<ItemTemplate>
                                    <asp:RadioButton ID="radISNON" runat="server" GroupName="Disease" Checked='<%# Eval("FDISNON").ToString() == "Y" %>' Visible='<%# Eval("DCISNONVISIBLE").ToString() == "Y" %>' OnCheckedChanged="UpdateTmpDisease" AutoPostBack="true" ToolTip='<%# Container.DataItemIndex %>' />
                                
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField ReadOnly="True" DataField="DCLOID" HeaderText="DCLOID">
<ControlStyle CssClass="zHidden"></ControlStyle>

<ItemStyle CssClass="zHidden"></ItemStyle>

<HeaderStyle CssClass="zHidden"></HeaderStyle>

<FooterStyle CssClass="zHidden"></FooterStyle>
</asp:BoundField>
<asp:BoundField ReadOnly="True" DataField="DCISHIGHVISIBLE" HeaderText="DCISHIGHVISIBLE">
<ControlStyle CssClass="zHidden"></ControlStyle>

<ItemStyle CssClass="zHidden"></ItemStyle>

<HeaderStyle CssClass="zHidden"></HeaderStyle>

<FooterStyle CssClass="zHidden"></FooterStyle>
</asp:BoundField>
<asp:BoundField ReadOnly="True" DataField="DCISLOWVISIBLE" HeaderText="DCISLOWVISIBLE">
<ControlStyle CssClass="zHidden"></ControlStyle>

<ItemStyle CssClass="zHidden"></ItemStyle>

<HeaderStyle CssClass="zHidden"></HeaderStyle>

<FooterStyle CssClass="zHidden"></FooterStyle>
</asp:BoundField>
<asp:BoundField ReadOnly="True" DataField="DCISNONVISIBLE" HeaderText="DCISNONVISIBLE">
<ControlStyle CssClass="zHidden"></ControlStyle>

<ItemStyle CssClass="zHidden"></ItemStyle>

<HeaderStyle CssClass="zHidden"></HeaderStyle>

<FooterStyle CssClass="zHidden"></FooterStyle>
</asp:BoundField>
</Columns>
                    </asp:GridView>
                </ContentTemplate>
            </cc1:TabPanel>
            <cc1:TabPanel ID="tabLDNutrient" runat="server" HeaderText="สารอาหารที่ได้รับ">
                <ContentTemplate>
                    <asp:TextBox ID="txhSortDirNutrient" runat="server" Visible="False" Width="15px"></asp:TextBox>
                    <asp:TextBox ID="txhSortFieldNutrient" runat="server" Visible="False" Width="15px"></asp:TextBox>
                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                        <tr>
                            <td class="subheadertext" style="height: 25px">
                                &nbsp;สารอาหารที่ได้รับ
                            </td>
                        </tr> 
                    </table>
                    <asp:GridView ID="gvLDNutrient" runat="server" AllowSorting="true" AutoGenerateColumns="False" CssClass="t_tablestyle" OnRowDataBound="gvLDNutrient_RowDataBound" OnSorting="gvLDNutrient_Sorting"  >
                        <Columns>
                            <asp:BoundField DataField="LOID" HeaderText="LOID" ReadOnly="True">
                                <ControlStyle CssClass="zHidden" />
                                <FooterStyle CssClass="zHidden" />
                                <HeaderStyle CssClass="zHidden" />
                                <ItemStyle CssClass="zHidden" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="ลำดับ">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate> 
                                <EditItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </EditItemTemplate> 
                                <HeaderStyle HorizontalAlign="Center" Width="40px" />
                                <ItemStyle HorizontalAlign="Center" Width="40px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="NUTRIENTNAME" HeaderText="สารอาหาร" ReadOnly="True" SortExpression="NUTRIENTNAME">
                                <HeaderStyle HorizontalAlign="Center" Width="170px" />
                                <ItemStyle Width="170px" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="ปริมาณ" >
                                <ItemTemplate>
                                    <asp:Label ID="lblQTY" runat="server" />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                <ItemStyle HorizontalAlign="Right" Width="100px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="QTY" HeaderText="QTY" ReadOnly="True">
                                <ControlStyle CssClass="zHidden" />
                                <FooterStyle CssClass="zHidden" />
                                <HeaderStyle CssClass="zHidden" />
                                <ItemStyle CssClass="zHidden" />
                            </asp:BoundField>
                            <asp:BoundField DataField="UNITNAME" HeaderText="UNITNAME" ReadOnly="True">
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
        </cc1:TabContainer>
    </asp:Panel>
    <uc3:MaterialMasterPopup ID="ctlMaterialMasterPopup" runat="server" OnSelectedIndexChanged="ctlMaterialMasterPopup_SelectedIndexChanged" OnCancel="ctlMaterialMasterPopup_Cancel" />
    <uc4:DiseaseCategoryPopup ID="ctlDiseaseCategoryPopup" runat="server" OnSelectedIndexChanged="ctlDiseaseCategoryPopup_SelectedIndexChanged"/>
</asp:Content>


