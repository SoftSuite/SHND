<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="FormulaSet.aspx.cs" Inherits="App_Formula_Transaction_FormulaSet" Title="SHND : Transaction - Formula Set" %>
<%@ Register Src="../../Search/FormulaSetPopup.ascx" TagName="FormulaSetPopup" TagPrefix="uc6" %>
<%@ Register Src="../../Templates/AttachControl.ascx" TagName="AttachControl" TagPrefix="uc5" %>
<%@ Register Src="../../Search/MaterialMaster100Popup.ascx" TagName="MaterialMasterPopup" TagPrefix="uc4" %>
<%@ Register Src="../../Search/DiseaseCategoryPopup.ascx" TagName="DiseaseCategoryPopup" TagPrefix="uc3" %>
<%@ Register Src="../../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="headtext">
                ข้อมูลสูตรอาหารสำรับ</td>
        </tr>
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbSave" runat="server" ToobarTitle="บันทึก" ToolbarImage="../../Images/save2.png" OnClick="tbSaveClick" />
                <uc1:ToolBarItemCtl ID="tbCancel" runat="server" ToobarTitle="ยกเลิกการแก้ไข" ToolbarImage="../../Images/cancel.png" OnClick="tbCancelClick" />
                <uc1:ToolBarItemCtl ID="tbBack" runat="server" ToobarTitle="กลับหน้ารายการ" ToolbarImage="../../Images/icn_back.png" OnClick="tbBackClick"/>
                <uc1:ToolBarItemCtl ID="tbPrint" runat="server" ToobarTitle="พิมพ์รายงาน" ToolbarImage="../../Images/icn_print.png" />
                <uc1:ToolBarItemCtl ID="tbTest" runat="server" ToobarTitle="ทดลองทำ" ToolbarImage="../../Images/icn_test.png" OnClick="tbTestClick"/>
                <uc1:ToolBarItemCtl ID="tbApprove" runat="server" ToobarTitle="อนุมัติ" ToolbarImage="../../Images/icn_approve.png" OnClick="tbApproveClick"/>
                <uc1:ToolBarItemCtl ID="tbNotApprove" runat="server" ToobarTitle="ไม่อนุมัติ" ToolbarImage="../../Images/icn_cancel.png" OnClick="tbNotApproveClick"/>
            </td>
        </tr>
        <tr>
            <td style="height:30px" valign="top">
                <hr style="size:1px" />
                <asp:Label ID="lbStatus" runat="server" EnableViewState="False"></asp:Label>
                <asp:TextBox ID="txtLOID" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
                <asp:TextBox ID="txtStatus" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
                <asp:TextBox ID="txtCurentTab" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
                <asp:TextBox ID="txtDivision" runat="server" CssClass="zHidden" MaxLength="80"
                    Width="29px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td style="padding:5px; border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid; width:500px" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" width="550px">
                                <tr style="height:24px">
                                    <td style="width:110px; text-align:right; padding-right:10px">
                                        ชื่อสูตรอาหาร :</td> 
                                    <td style="width:230px">
                                        <asp:TextBox ID="txtName" runat="server" CssClass="zTextbox" MaxLength="100" Width="200px"></asp:TextBox>
                                        <asp:Label ID="lblRemarkName" runat="server" CssClass="zRemark" Text="*"></asp:Label>
                                    </td> 
                                    <td>
                                        <asp:CheckBox ID="chkIsSpecific" runat="server" Text="อาหารเฉพาะโรค" /></td> 
                                </tr>
                                <tr style="height:24px">
                                    <td style="width:110px; text-align:right; padding-right:10px">
                                        ประเภทอาหาร :</td> 
                                    <td style="width:230px">
                                        <asp:DropDownList ID="cmbFoodType" runat="server" Width="205px" CssClass="zComboBox" AutoPostBack="True" OnSelectedIndexChanged="cmbFoodType_SelectedIndexChanged"></asp:DropDownList>
                                        <asp:Label ID="lblRemarkFoodType" runat="server" CssClass="zRemark" Text="*"></asp:Label></td> 
                                    <td>
                                        <asp:CheckBox ID="chkIsOneDish" runat="server" Text="อาหารจานเดียว" /></td> 
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 110px; text-align: right">
                                        ชนิดอาหาร :</td>
                                    <td style="width: 230px"><asp:DropDownList ID="cmbFoodCategory" runat="server" Width="205px" CssClass="zComboBox" AutoPostBack="True" OnSelectedIndexChanged="cmbFoodCategory_SelectedIndexChanged">
                                    </asp:DropDownList>
                                        <asp:Label ID="Label5" runat="server" CssClass="zRemark" Text="*"></asp:Label></td>
                                    <td><asp:CheckBox ID="chkIsElement" runat="server" Text="ใช้เป็นส่วนผสมในสูตรอื่นๆ" /></td> 
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 110px; text-align: right">
                                        ประเภทการปรุง :</td>
                                    <td style="width: 230px">
                                       <asp:DropDownList ID="cmbFoodCookType" runat="server" Width="205px" CssClass="zComboBox"></asp:DropDownList>
                                       <asp:Label ID="Label2" runat="server" CssClass="zRemark" Text="*"></asp:Label>
                                    </td>
                                    <td><asp:CheckBox ID="chkActive" runat="server" Text="ใช้งาน" /></td> 
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 110px; text-align: right">
                                        ประเภทคาวหวาน :</td>
                                    <td style="width: 230px">
                                        <asp:DropDownList ID="cmbDishesType" runat="server" Width="205px" CssClass="zComboBox"></asp:DropDownList>
                                        <asp:Label ID="Label3" runat="server" CssClass="zRemark" Text="*"></asp:Label>
                                    </td>
                                    <td></td> 
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 110px; text-align: right">
                                        ภาชนะบรรจุ :</td>
                                    <td style="width: 230px"><asp:DropDownList ID="cmbPackage" runat="server" Width="205px" CssClass="zComboBox">
                                    </asp:DropDownList></td>
                                    <td>
                                        </td>
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 110px; text-align: right; height: 24px;">
                                        Portion :</td>
                                    <td style="width: 230px; height: 24px;">
                                        <asp:TextBox ID="txtPortion" runat="server" CssClass="zTextboxR" MaxLength="80" Width="80px" ></asp:TextBox>
                                        <asp:Label ID="Label1" runat="server" CssClass="zRemark" Text="*"></asp:Label>
                                        คน</td>
                                    <td style="height: 24px">
                                        </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width:4px">
                            &nbsp;</td>
                        <td style="border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid; padding:5px" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" width="300px">
                                <tr style="height:24px; padding-bottom:12px">
                                    <td style="width:120px; text-align:right; padding-right:10px;">
                                        สถานะ :</td> 
                                    <td>
                                        <asp:TextBox ID="txtStatusName" runat="server" CssClass="zTextbox-View"
                                            ReadOnly="True" Width="150px"></asp:TextBox></td> 
                                </tr>
                                <tr style="height: 12px;">
                                    <td colspan="2" style="border-top: 1px solid;">
                                        &nbsp;</td>
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 120px; text-align: right;">
                                        พลังงานที่ได้รับ :</td>
                                    <td>
                                        <asp:TextBox ID="txtEnergy" runat="server" CssClass="zTextboxR-View" MaxLength="80" Width="80px" ReadOnly="True"></asp:TextBox>&nbsp;
                                        kcal</td>
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 120px; text-align: right">
                                        น้ำหนักรวมสูตร :</td>
                                    <td>
                                        <asp:TextBox ID="txtWeightFormula" runat="server" CssClass="zTextboxR-View" MaxLength="80" Width="80px"></asp:TextBox>&nbsp;
                                        g</td>
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 120px; text-align: right">
                                        น้ำหนักรวม Portion :</td>
                                    <td>
                                        <asp:TextBox ID="txtWeightPortion" runat="server" CssClass="zTextboxR-View" MaxLength="80" Width="80px" ReadOnly="True"></asp:TextBox>&nbsp;
                                        g</td>
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
            <td style="height:15px">
                <cc1:TabContainer ID="tabFormulaSet" runat="server" ActiveTabIndex="0" OnActiveTabChanged="tabFormulaSet_ActiveTabChanged" AutoPostBack="true">
                    <cc1:TabPanel ID="tabFormulaSetItem" runat="server" HeaderText="รายการวัตถุดิบ" >
                        <ContentTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td class="subheadertext">รายการวัตถุดิบในสูตรอาหาร
                                    </td> 
                                </tr>
                                <tr>
                                    <td class="toolbarplace">
                                        <uc1:ToolBarItemCtl ID="tbAddFormulaSetItem" runat="server" ToobarTitle="เพิ่มรายการ" ToolbarImage="../../Images/icn_add.png" OnClick="tbAddFormulaSetItemClick" />
                                        <uc1:ToolBarItemCtl ID="tbDeleteFormulaSetItem" runat="server" ToobarTitle="ลบรายการ" ToolbarImage="../../Images/icn_delete.png" OnClick="tbDeleteFormulaSetItemClick" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbStatusFormulaSetItem" runat="server" EnableViewState="False"></asp:Label></td> 
                                </tr> 
                                <tr>
                                    <td>
                                         <asp:GridView ID="gvFormulaSetItem" runat="server" AutoGenerateColumns="False" CssClass="t_tablestyle" DataSourceID="FormulaSetItmeSource" DataKeyNames="RANK" Width="1200px" OnRowDataBound="gvFormulaSetItem_RowDataBound">
                                            <Columns>
                                                <asp:BoundField DataField="RANK" HeaderText="RANK">
                                                    <ControlStyle CssClass="zHidden" />
                                                    <FooterStyle CssClass="zHidden" />
                                                    <HeaderStyle CssClass="zHidden" />
                                                    <ItemStyle CssClass="zHidden" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="LOID" HeaderText="LOID">
                                                    <ControlStyle CssClass="zHidden" />
                                                    <FooterStyle CssClass="zHidden" />
                                                    <HeaderStyle CssClass="zHidden" />
                                                    <ItemStyle CssClass="zHidden" />
                                                </asp:BoundField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <input type="checkbox" name="chkMain" id="chkMain" onclick="chkAllBox(this, 'ctl00_MainContent_tabFormulaSet_tabFormulaSetItem_gvFormulaSetItem_ctl', '_chkSelect')" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkSelect" runat="server" />
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" Width="30px" />
                                                    <ItemStyle HorizontalAlign="Center" Width="30px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="ลำดับ">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex+1 %>
                                                    </ItemTemplate> 
                                                    <EditItemTemplate>
                                                        <%# Container.DataItemIndex+1 %>
                                                    </EditItemTemplate> 
                                                    <HeaderStyle Width="30px" />
                                                    <ItemStyle HorizontalAlign="Center" Width="30px" Height="24px"/>
                                                </asp:TemplateField> 
                                                <asp:BoundField DataField="MATERIALNAME" HeaderText="ส่วนผสม">
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="น้ำหนักสูตร(g)">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtWeightRawEdit" runat="server" CssClass="zTextboxR" Width="65px" MaxLength="10" Text='<%# Convert.ToDouble(Eval("WEIGHTRAW")).ToString("#,##0.00") %>' onkeypress="ChkDbl(this)" onblur="valDbl(this)" onfocus="prepareNum(this)" ></asp:TextBox>   
                                                    </ItemTemplate>
                                                    <ItemStyle Width="70px" HorizontalAlign="Right" /> 
                                                    <HeaderStyle Width="70px" HorizontalAlign="Center" /> 
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="ชื่อในการเตรียม">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtPrepareNameEdit" runat="server" CssClass="zTextbox" Width="130px" MaxLength="100" Text='<%# Bind("PREPARENAME") %>'></asp:TextBox>  
                                                    </ItemTemplate>
                                                    <ItemStyle Width="140px" /> 
                                                    <HeaderStyle Width="140px" HorizontalAlign="Center" />
                                                </asp:TemplateField>

                                                <asp:BoundField DataField="WEIGHT" HeaderText="น้ำหนักเบิก(g)" HtmlEncode="False" DataFormatString="{0:#,##0.00}">
                                                    <ItemStyle Width="70px" HorizontalAlign="Right" /> 
                                                    <HeaderStyle Width="70px" HorizontalAlign="Center" /> 
                                                </asp:BoundField>
                                                
                                                <asp:BoundField DataField="WEIGHTRIPE" HeaderText="น้ำหนักสุก(g)" HtmlEncode="False" DataFormatString="{0:#,##0.00}">
                                                    <ItemStyle Width="70px" HorizontalAlign="Right" /> 
                                                    <HeaderStyle Width="70px" HorizontalAlign="Center" /> 
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ENERGY" HeaderText="พลังงาน(kcal)" InsertVisible="False" HtmlEncode="False" DataFormatString="{0:#,##0.00}" ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Right" Width="80px" />
                                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="CARBOHYDRATE" HeaderText="คาร์โบไฮเดรต(g)" InsertVisible="False" HtmlEncode="False" DataFormatString="{0:#,##0.00}" ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Right" Width="80px" />
                                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="PROTEIN" HeaderText="โปรตีน(g)" InsertVisible="False" HtmlEncode="False" DataFormatString="{0:#,##0.00}" ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Right" Width="80px" />
                                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="FAT" HeaderText="ไขมัน(g)" InsertVisible="False" HtmlEncode="False" DataFormatString="{0:#,##0.00}" ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Right" Width="80px" />
                                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="SODIUM" HeaderText="โซเดียม(mg)" InsertVisible="False" HtmlEncode="False" DataFormatString="{0:#,##0.00}" ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Right" Width="80px" />
                                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="MATERIALMASTER" HeaderText="MATERIALMASTER">
                                                    <ControlStyle CssClass="zHidden" />
                                                    <FooterStyle CssClass="zHidden" />
                                                    <HeaderStyle CssClass="zHidden" />
                                                    <ItemStyle CssClass="zHidden" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="MATERIALWEIGHT" HeaderText="MATERIALWEIGHT">
                                                    <ControlStyle CssClass="zHidden" />
                                                    <FooterStyle CssClass="zHidden" />
                                                    <HeaderStyle CssClass="zHidden" />
                                                    <ItemStyle CssClass="zHidden" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="WEIGHTCOOK" HeaderText="WEIGHTCOOK">
                                                    <ControlStyle CssClass="zHidden" />
                                                    <FooterStyle CssClass="zHidden" />
                                                    <HeaderStyle CssClass="zHidden" />
                                                    <ItemStyle CssClass="zHidden" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="PHOSPHORUS" HeaderText="ฟอสฟอรัส(mg)" InsertVisible="False" HtmlEncode="False" DataFormatString="{0:#,##0.00}" ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Right" Width="80px" />
                                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="POTASSIUM" HeaderText="โพแทสเซียม(mg)" InsertVisible="False" HtmlEncode="False" DataFormatString="{0:#,##0.00}" ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Right" Width="80px" />
                                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="CALCIUM" HeaderText="แคลเซียม(mg)" InsertVisible="False" HtmlEncode="False" DataFormatString="{0:#,##0.00}" ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Right" Width="80px" />
                                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                                </asp:BoundField>
                                            </Columns> 
                                            <HeaderStyle CssClass="t_headtext" />
                                            <AlternatingRowStyle CssClass="t_alt_bg" />
                                            <PagerSettings Visible="False" />
                                         </asp:GridView>
                                        <asp:ObjectDataSource ID="FormulaSetItmeSource" runat="server" SelectMethod="GetFormulaSetItemList" TypeName="FormulaSetDetailItem" UpdateMethod="UpdateFormulaSetItem">
                                            <UpdateParameters>
                                                <asp:Parameter Name="RANK" Type="Double" />
                                                <asp:Parameter Name="LOID" Type="Double" />
                                                <asp:Parameter Name="FORMULASET" Type="Double" />
                                                <asp:Parameter Name="MATERIALMASTER" Type="Double" />
                                                <asp:Parameter Name="PREPARENAME" Type="String" />
                                                <asp:Parameter Name="WEIGHT" Type="Double" />
                                                <asp:Parameter Name="WEIGHTRIPE" Type="Double" />
                                                <asp:Parameter Name="WEIGHTRAW" Type="Double" />
                                                <asp:Parameter Name="ENERGY" Type="Double" />
                                                <asp:Parameter Name="REFFORMULA" Type="Double" />
                                                <asp:Parameter Name="MATERIALNAME" Type="String" />
                                                <asp:Parameter Name="CARBOHYDRATE" Type="Double" />
                                                <asp:Parameter Name="PROTEIN" Type="Double" />
                                                <asp:Parameter Name="FAT" Type="Double" />
                                                <asp:Parameter Name="SODIUM" Type="Double" />
                                            </UpdateParameters>
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="txtLOID" DefaultValue="0" Name="formulaSetID" PropertyName="Text"
                                                    Type="Double" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </td> 
                                </tr> 
                                <tr>
                                    <td style="height:25px">
                                    </td> 
                                </tr> 
                                <tr>
                                    <td class="subheadertext">ส่วนผสมจากสูตรอื่นๆ
                                    </td> 
                                </tr>
                                <tr>
                                    <td class="toolbarplace">
                                        <uc1:ToolBarItemCtl ID="tbAddRefFormulaSet" runat="server" ToobarTitle="เพิ่มรายการ" ToolbarImage="../../Images/icn_add.png" OnClick="tbAddRefFormulaSetClick" />
                                        <uc1:ToolBarItemCtl ID="tbDeleteRefFormulaSet" runat="server" ToobarTitle="ลบรายการ" ToolbarImage="../../Images/icn_delete.png" OnClick="tbDeleteRefFormulaSetClick" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbStatusRefFormulaSet" runat="server" EnableViewState="False"></asp:Label>
                                    </td> 
                                </tr> 
                                <tr>
                                    <td>
                                        <asp:GridView ID="gvRefFormula" runat="server"  AutoGenerateColumns="False" CssClass="t_tablestyle" DataSourceID="RefFormulaSource" DataKeyNames="RANK" Width="1200px"
                                            OnRowDataBound="gvRefFormula_RowDataBound">
                                            <Columns>
                                                <asp:BoundField DataField="RANK" HeaderText="RANK">
                                                    <ControlStyle CssClass="zHidden" />
                                                    <FooterStyle CssClass="zHidden" />
                                                    <HeaderStyle CssClass="zHidden" />
                                                    <ItemStyle CssClass="zHidden" />
                                                </asp:BoundField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <input type="checkbox" name="chkMain" id="chkMain" onclick="chkAllBox(this, 'ctl00_MainContent_tabFormulaSet_tabFormulaSetItem_gvRefFormula_ctl', '_chkSelect')" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkSelect" runat="server" />
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" Width="30px" />
                                                    <ItemStyle HorizontalAlign="Center" Width="30px" VerticalAlign="Top" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="สูตรอาหาร">
                                                    <ItemTemplate>
                                                        <div style="height:24px"><asp:Label ID="lblName" runat="server" Text='<%# Bind("REFORMULASETNAME") %>'></asp:Label>
                                                        <asp:TextBox ID="txtRefFormula" runat="server" CssClass="zHidden" Width="30px" Text='<%# Bind("REFFORMULA") %>'></asp:TextBox></div>
                                                        <asp:GridView ID="gvRefFormulaSetItem" runat="server" AutoGenerateColumns="False" CssClass="t_tablestyle" Width="1160px">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="ลำดับ">
                                                                    <ItemTemplate>
                                                                        <%# Container.DataItemIndex + 1%>
                                                                    </ItemTemplate> 
                                                                    <HeaderStyle Width="30px" />
                                                                    <ItemStyle HorizontalAlign="Center" Width="30px" Height="24px" />
                                                                </asp:TemplateField> 
                                                                <asp:BoundField DataField="MATERIALNAME" HeaderText="ส่วนผสม">
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="WEIGHTRAW" HeaderText="น้ำหนักสูตร(g)" HtmlEncode="False" DataFormatString="{0:#,##0.00}" ReadOnly="True">
                                                                    <ItemStyle HorizontalAlign="Right" Width="70px" />
                                                                    <HeaderStyle HorizontalAlign="Center" Width="70px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="PREPARENAME" HeaderText="ชื่อในการเตรียม">
                                                                    <ItemStyle Width="140px" />
                                                                    <HeaderStyle HorizontalAlign="Center" Width="140px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="WEIGHT" HeaderText="น้ำหนักเบิก(g)" HtmlEncode="False" DataFormatString="{0:#,##0.00}" ReadOnly="True">
                                                                    <ItemStyle HorizontalAlign="Right" Width="70px" />
                                                                    <HeaderStyle HorizontalAlign="Center" Width="70px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="WEIGHTRIPE" HeaderText="น้ำหนักสุก (g)" HtmlEncode="False" DataFormatString="{0:#,##0.00}" ReadOnly="True">
                                                                    <ItemStyle HorizontalAlign="Right" Width="70px" />
                                                                    <HeaderStyle HorizontalAlign="Center" Width="70px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="ENERGY" HeaderText="พลังงาน (kcal)" InsertVisible="False" HtmlEncode="False" DataFormatString="{0:#,##0.00}" ReadOnly="True">
                                                                    <ItemStyle HorizontalAlign="Right" Width="80px" />
                                                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                                                    <FooterStyle HorizontalAlign="Right" Width="80px"/>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="CARBOHYDRATE" HeaderText="คาร์โบไฮเดรต (g)" InsertVisible="False" HtmlEncode="False" DataFormatString="{0:#,##0.00}" ReadOnly="True">
                                                                    <ItemStyle HorizontalAlign="Right" Width="80px" />
                                                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                                                    <FooterStyle HorizontalAlign="Right" Width="80px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="PROTEIN" HeaderText="โปรตีน (g)" InsertVisible="False" HtmlEncode="False" DataFormatString="{0:#,##0.00}" ReadOnly="True">
                                                                    <ItemStyle HorizontalAlign="Right" Width="80px" />
                                                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                                                    <FooterStyle HorizontalAlign="Right" Width="80px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="FAT" HeaderText="ไขมัน (g)" InsertVisible="False" HtmlEncode="False" DataFormatString="{0:#,##0.00}" ReadOnly="True">
                                                                    <ItemStyle HorizontalAlign="Right" Width="80px" />
                                                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                                                    <FooterStyle HorizontalAlign="Right" Width="80px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="SODIUM" HeaderText="โซเดียม (mg)" InsertVisible="False" HtmlEncode="False" DataFormatString="{0:#,##0.00}" ReadOnly="True">
                                                                    <ItemStyle HorizontalAlign="Right" Width="80px" />
                                                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                                                    <FooterStyle HorizontalAlign="Right" Width="80px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="PHOSPHORUS" HeaderText="ฟอสฟอรัส (mg)" InsertVisible="False" HtmlEncode="False" DataFormatString="{0:#,##0.00}" ReadOnly="True">
                                                                    <ItemStyle HorizontalAlign="Right" Width="80px" />
                                                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                                                    <FooterStyle HorizontalAlign="Right" Width="80px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="POTASSIUM" HeaderText="โพแทสเซียม (mg)" InsertVisible="False" HtmlEncode="False" DataFormatString="{0:#,##0.00}" ReadOnly="True">
                                                                    <ItemStyle HorizontalAlign="Right" Width="80px" />
                                                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                                                    <FooterStyle HorizontalAlign="Right" Width="80px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="CALCIUM" HeaderText="แคลเซียม (mg)" InsertVisible="False" HtmlEncode="False" DataFormatString="{0:#,##0.00}" ReadOnly="True">
                                                                    <ItemStyle HorizontalAlign="Right" Width="80px" />
                                                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                                                    <FooterStyle HorizontalAlign="Right" Width="80px" />
                                                                </asp:BoundField>
                                                                                                                <asp:BoundField DataField="WEIGHT1" HeaderText="WEIGHT1">
                                                    <ControlStyle CssClass="zHidden" />
                                                    <FooterStyle CssClass="zHidden" />
                                                    <HeaderStyle CssClass="zHidden" />
                                                    <ItemStyle CssClass="zHidden" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="WEIGHTRIPE1" HeaderText="WEIGHTRIPE1">
                                                    <ControlStyle CssClass="zHidden" />
                                                    <FooterStyle CssClass="zHidden" />
                                                    <HeaderStyle CssClass="zHidden" />
                                                    <ItemStyle CssClass="zHidden" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="WEIGHTRAW1" HeaderText="WEIGHTRAW1">
                                                    <ControlStyle CssClass="zHidden" />
                                                    <FooterStyle CssClass="zHidden" />
                                                    <HeaderStyle CssClass="zHidden" />
                                                    <ItemStyle CssClass="zHidden" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ENERGY1" HeaderText="ENERGY1">
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
                                                    </ItemTemplate>
                                                </asp:TemplateField> 
                                                <asp:BoundField DataField="REFFORMULA" HeaderText="REFFORMULA">
                                                    <ControlStyle CssClass="zHidden" />
                                                    <FooterStyle CssClass="zHidden" />
                                                    <HeaderStyle CssClass="zHidden" />
                                                    <ItemStyle CssClass="zHidden" />
                                                </asp:BoundField>

                                            </Columns>
                                            <HeaderStyle CssClass="t_headtext" />
                                            <PagerSettings Visible="False" />
                                        </asp:GridView> 
                                        <asp:ObjectDataSource ID="RefFormulaSource" runat="server" SelectMethod="GetRefFormulaSetList" TypeName="FormulaSetDetailItem">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="txtLOID" DefaultValue="0" Name="formulaSetID" PropertyName="Text"
                                                    Type="Double" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </td> 
                                </tr> 
                            </table>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="tabFormulaServe" runat="server" HeaderText="การจัดเสิร์ฟ">
                        <ContentTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td class="toolbarplace" colspan="2">
                                        <uc1:ToolBarItemCtl ID="tbAddFormulaServe" runat="server" ToobarTitle="เพิ่มรายการ" ToolbarImage="../../Images/icn_add.png" OnClick="tbAddFormulaServeClick" />
                                        <uc1:ToolBarItemCtl ID="tbDeleteFormulaServe" runat="server" ToobarTitle="ลบรายการ" ToolbarImage="../../Images/icn_delete.png" OnClick="tbDeleteFormulaServeClick" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="lbStatusFormulaServe" runat="server" EnableViewState="False"></asp:Label>
                                    </td> 
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:GridView ID="gvFormulaServe" runat="server" AutoGenerateColumns="False" CssClass="t_tablestyle" DataSourceID="FormulaServeSource" Width="600px">
                                            <Columns>
                                                <asp:BoundField DataField="RANK" HeaderText="RANK">
                                                    <ControlStyle CssClass="zHidden" />
                                                    <FooterStyle CssClass="zHidden" />
                                                    <HeaderStyle CssClass="zHidden" />
                                                    <ItemStyle CssClass="zHidden" />
                                                </asp:BoundField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <input type="checkbox" name="chkMain" id="chkMain" onclick="chkAllBox(this, 'ctl00_MainContent_tabFormulaSet_tabFormulaServe_gvFormulaServe_ctl', '_chkSelect')" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkSelect" runat="server" />
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" Width="30px" />
                                                    <ItemStyle HorizontalAlign="Center" Width="30px" VerticalAlign="Top" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="ลำดับ">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1%>
                                                    </ItemTemplate> 
                                                    <EditItemTemplate>
                                                        <%# Container.DataItemIndex + 1%>
                                                    </EditItemTemplate> 
                                                    <HeaderStyle Width="40px" />
                                                    <ItemStyle HorizontalAlign="Center" Width="50px" Height="24px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="ส่วนผสม" SortExpression="NAME">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkName" runat="server" Text='<%# Bind("NAME") %>' OnClick="lnkName_Click" CommandArgument='<%# Bind("RANK")  %>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="WEIGHTRIPE" HeaderText= "น้ำหนักสุก (g)" ReadOnly="True" HtmlEncode="False" DataFormatString="{0:#,##0.00}">
                                                    <HeaderStyle Width="80px" />
                                                    <ItemStyle HorizontalAlign="Right" Width="80px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="WEIGHTRAW" HeaderText= "น้ำหนักดิบ (g)" ReadOnly="True" HtmlEncode="False" DataFormatString="{0:#,##0.00}">
                                                    <HeaderStyle Width="80px" />
                                                    <ItemStyle HorizontalAlign="Right" Width="80px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="NAME" HeaderText="NAME">
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
                                        <asp:ObjectDataSource ID="FormulaServeSource" runat="server" SelectMethod="GetFormulaServeList"
                                            TypeName="FormulaSetDetailItem">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="txtLOID" Name="formulaSetID" PropertyName="Text"
                                                    Type="Double" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </td> 
                                </tr> 
                                <tr style="height:15px">
                                    <td style="width: 100px">
                                    </td> 
                                   <td>
                                   </td> 
                                </tr> 
                                <tr>
                                    <td valign="top" align="right" style="padding-right:10px; width:100px">
                                        วิธีการเสิร์ฟ :</td> 
                                   <td valign="top">
                                       <asp:TextBox ID="txtServeMethod" runat="server" CssClass="zTextbox" Height="86px" MaxLength="500" 
                                           TextMode="MultiLine" Width="480px"></asp:TextBox></td> 
                                </tr> 
                                <tr>
                                    <td colspan="2" valign="top">
                                       <uc5:AttachControl ID="ctlAttach" runat="server" AllowDelete="true" AllowMultiUpload="false" 
                                           OverwriteExistFile="true" Reference1="FORMULASET" Reference2="IMGPATH" />
                                           ไฟล์ภาพต้องมีนามสกุล *.jpg ขนาดไฟล์ไม่เกิน 100k
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="tabFormulaDisease" runat="server" HeaderText="สารอาหารที่ควบคุม">
                        <ContentTemplate>
                            <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                <tr>
                                    <td class="toolbarplace">
                                        <uc1:ToolBarItemCtl ID="tbAddFormulaDisease" runat="server" ToobarTitle="เพิ่มรายการ" ToolbarImage="../../Images/icn_add.png" OnClick="tbAddFormulaDiseaseClick" />
                                        <uc1:ToolBarItemCtl ID="tbDeleteFormulaDisease" runat="server" ToobarTitle="ลบรายการ" ToolbarImage="../../Images/icn_delete.png" OnClick="tbDeleteFormulaDiseaseClick" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbStatusFormulaDisease" runat="server" EnableViewState="False"></asp:Label>
                                    </td> 
                                </tr>
                                <tr>
                                    <td>
                                        <asp:GridView ID="gvFormulaDisease" runat="server" AutoGenerateColumns="False" CssClass="t_tablestyle" DataSourceID="FormulaDiseaseSource" OnRowDataBound="gvFormulaDisease_RowDataBound">
                                            <Columns>
                                                <asp:BoundField DataField="LOID" HeaderText="LOID">
                                                    <ControlStyle CssClass="zHidden" />
                                                    <FooterStyle CssClass="zHidden" />
                                                    <HeaderStyle CssClass="zHidden" />
                                                    <ItemStyle CssClass="zHidden" />
                                                </asp:BoundField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <input type="checkbox" name="chkMain" id="chkMain" onclick="chkAllBox(this, 'ctl00_MainContent_tabFormulaSet_tabFormulaDisease_gvFormulaDisease_ctl', '_chkSelect')" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkSelect" runat="server" />
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" Width="30px" />
                                                    <ItemStyle HorizontalAlign="Center" Width="30px" VerticalAlign="Top" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="ลำดับ">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1%>
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="60px" />
                                                    <ItemStyle HorizontalAlign="Center" Width="60px" Height="24px" />
                                                </asp:TemplateField> 
                                                <asp:BoundField DataField="NAME" HeaderText="สารอาหารที่ควบคุม">
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="High">
                                                    <ItemTemplate>
                                                        <asp:RadioButton ID="chkHigh" runat="server" GroupName="CategoryName" Visible='<%# Eval("ISHIGHVISIBLE").ToString() =="Y" %>' Checked='<%# Eval("ISHIGH").ToString() =="Y" %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="40px" />
                                                    <ItemStyle HorizontalAlign="Center" Width="40px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Low">
                                                    <ItemTemplate>
                                                        <asp:RadioButton ID="chkLow" runat="server" GroupName="CategoryName" Visible='<%# Eval("ISLOWVISIBLE").ToString() =="Y" %>' Checked='<%# Eval("ISLOW").ToString() =="Y" %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="40px" />
                                                    <ItemStyle HorizontalAlign="Center" Width="40px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Non">
                                                    <ItemTemplate>
                                                        <asp:RadioButton ID="chkNon" runat="server" GroupName="CategoryName" Visible='<%# Eval("ISNONVISIBLE").ToString() =="Y" %>' Checked='<%# Eval("ISNON").ToString() =="Y" %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="40px" />
                                                    <ItemStyle HorizontalAlign="Center" Width="40px" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="DISEASECATEGORY" HeaderText="DISEASECATEGORY">
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
                                        <asp:ObjectDataSource ID="FormulaDiseaseSource" runat="server" SelectMethod="GetFormulaDiseaseList" TypeName="FormulaSetDetailItem">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="txtLOID" DefaultValue="0" Name="formulaSetID" PropertyName="Text"
                                                    Type="Double" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </td> 
                                </tr>
                            </table>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="tabFormulaMethod" runat="server" HeaderText="วิธีเตรียม วิธีปรุง/วิธีทำ">
                        <ContentTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td style="width:100px; padding-right:10px; text-align:right; vertical-align:top">วิธีเตรียม :
                                    </td> 
                                    <td>
                                        <asp:TextBox ID="txtPrepare" runat="server" CssClass="zTextbox" MaxLength="500" Width="500px" Height="100px" TextMode="MultiLine"></asp:TextBox>
                                    </td> 
                                </tr>
                                <tr>
                                    <td colspan="2" style="height:5px"></td> 
                                </tr> 
                                <tr>
                                    <td style="width:100px; padding-right:10px; text-align:right; vertical-align:top">วิธีปรุง/วิธีทำ :
                                    </td> 
                                    <td>
                                        <asp:TextBox ID="txtRecipe" runat="server" CssClass="zTextbox" MaxLength="500" Width="500px" Height="100px" TextMode="MultiLine"></asp:TextBox>
                                    </td> 
                                </tr>
                            </table>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="tabNutrient" runat="server" HeaderText="สารอาหารที่ได้รับ">
                        <ContentTemplate>
                            สารอาหารที่ได้รับสำหรับ 1 Portion
                            <asp:GridView ID="gvFormulaSetNutrient" runat="server" AutoGenerateColumns="False" CssClass="t_tablestyle" DataSourceID="FormulaSetNutrientSource" Width="300px">
                                <Columns>
                                    <asp:TemplateField HeaderText="ลำดับ">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1%>
                                        </ItemTemplate> 
                                        <HeaderStyle Width="40px" />
                                        <ItemStyle HorizontalAlign="Center" Width="50px" Height="24px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="NUTRIENTNAME" HeaderText= "สารอาหาร" ReadOnly="True">
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="ปริมาณ (g)">
                                        <ItemTemplate>
                                            <asp:Label ID="lblQty" runat="server" Text='<%# Convert.ToDouble(Eval("QTY")).ToString("#,##0.00") + " " + Eval("UNITNAME") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="120px" />
                                        <HeaderStyle Width="120px" />
                                    </asp:TemplateField> 
                                </Columns>
                                <HeaderStyle CssClass="t_headtext" />
                                <AlternatingRowStyle CssClass="t_alt_bg" />
                                <PagerSettings Visible="False" />
                            </asp:GridView>
                            <asp:ObjectDataSource ID="FormulaSetNutrientSource" runat="server" SelectMethod="GetFormulaNutrientList"
                                TypeName="FormulaSetDetailItem">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="txtLOID" DefaultValue="0" Name="formulaSetID" PropertyName="Text"
                                        Type="Double" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            *คำนวณปริมาณสารอาหารที่ได้รับตามปริมาณวัตถุดิบแต่ละรายการ
                        </ContentTemplate>
                    </cc1:TabPanel>
                </cc1:TabContainer>
            </td>
        </tr>
    </table>
    <uc3:DiseaseCategoryPopup id="ctlDiseaseCategoryPopup" runat="server" OnSelectedIndexChanged="ctlDiseaseCategoryPopup_SelectedIndexChanged">
    </uc3:DiseaseCategoryPopup>
    <uc4:MaterialMasterPopup ID="ctlMaterialMasterPopup" runat="server" OnSelectedIndexChanged="ctlMaterialMasterPopup_SelectedIndexChanged" />
    <uc6:FormulaSetPopup id="ctlFormulaSetPopup" runat="server" OnSelectedIndexChanged="vtlFormulaSetPopup_SelectedIndexChanged"/>
    <cc1:ModalPopupExtender ID="popupFormulaServe"  runat="server" PopupControlID="pnlFormulaServe" BackgroundCssClass="modalBackground" DropShadow="true" TargetControlID="tabFormulaSet$tabFormulaServe$tbAddFormulaServe$lb" ></cc1:ModalPopupExtender>
    <asp:Panel ID="pnlFormulaServe" runat="server" CssClass="modalPopup" style="display:none" Width="800px">
    <table cellspacing="0" cellpadding="0" border="0" width="100%">
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbAddFormulaServeDetail" runat="server" ToobarTitle="บันทึก" ToolbarImage="../../Images/save2.png" OnClick="tbAddFormulaServeDetailClick" />
                <uc1:ToolBarItemCtl ID="tbAddAndNewFormulaServe" runat="server" ToobarTitle="บันทึกและเพิ่มรายการใหม่" ToolbarImage="../../Images/icn_save_add.png" OnClick="tbAddAndNewFormulaServeClick"  />
                <uc1:ToolBarItemCtl ID="tbCancelFormulaServe" runat="server" ToobarTitle="ยกเลิกการแก้ไข" ToolbarImage="../../Images/cancel.png" OnClick="tbCancelFormulaServeClick" />
                <uc1:ToolBarItemCtl ID="tbBackFormulaServe" runat="server" ToobarTitle="กลับหน้ารายการ" ToolbarImage="../../Images/icn_back.png" OnClick="tbBackFormulaServeClick"/>
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
                            <asp:TextBox ID="txhID" runat="server" Visible="False" Width="15px"></asp:TextBox></td>
                        <td style="height:15px">
                            <asp:Label ID="lbStatusFormulaServeDetail" runat="server" EnableViewState="False"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width:150px" align="right"> ส่วนผสม :</td>
                        <td>
                            <asp:TextBox ID="txtServeName" runat="server" CssClass="zTextbox" Width="200px" MaxLength="100"></asp:TextBox> <span style="color:red">*</span></td>
                    </tr>
                    <tr>
                        <td style="width:150px" align="right"> น้ำหนักสุก (g) :</td>
                        <td>
                            <asp:TextBox ID="txtWeightRipe" runat="server" CssClass="zTextboxR" Width="150px" MaxLength="10"> </asp:TextBox><span style="color:red">*</span></td>
                    </tr>
                    <tr>
                        <td style="width:150px" align="right"> น้ำหนักดิบ (g) :</td>
                        <td>
                            <asp:TextBox ID="txtWeightRaw" runat="server" CssClass="zTextboxR" Width="150px" MaxLength="10"> </asp:TextBox></td>
                    </tr>
                </table>
                <br />
            </td>
        </tr>
    </table>
    </asp:Panel>
</asp:Content>