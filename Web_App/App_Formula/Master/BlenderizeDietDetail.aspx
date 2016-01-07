<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Templates/Page1.master" CodeFile="BlenderizeDietDetail.aspx.cs" Inherits="App_Formula_Master_BlenderizeDietDetail" Title="SHND : Master - Blenderize Diet" %>

<%@ Register Src="../../Search/MaterialMasterPopup.ascx" TagName="MaterialMasterPopup"
    TagPrefix="uc4" %>

<%@ Register Src="../../Search/DiseaseCategoryPopup.ascx" TagName="DiseaseCategoryPopup" TagPrefix="uc3" %>
<%@ Register Src="../../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <script language="JavaScript" type="text/javascript">
        function ClienttabFormulaFeed_ActiveTabChanged(sender, e)
        {
            __doPostBack('<%= tabFormulaFeed.ClientID %>', sender.get_activeTab().get_headerText());
        }
    </script>
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="headtext">
                ข้อมูลสูตรอาหารทางสายให้อาหาร</td>
        </tr>
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbSave" runat="server" ToobarTitle="บันทึก" ToolbarImage="../../Images/save2.png" OnClick="tbSaveClick" />
                <uc1:ToolBarItemCtl ID="tbCancel" runat="server" ToobarTitle="ยกเลิกการแก้ไข" ToolbarImage="../../Images/cancel.png" OnClick="tbCancelClick" />
                <uc1:ToolBarItemCtl ID="tbBack" runat="server" ToobarTitle="กลับหน้ารายการ" ToolbarImage="../../Images/icn_back.png" OnClick="tbBackClick"/>
                <uc1:ToolBarItemCtl ID="tbPrint" runat="server" ToobarTitle="พิมพ์รายงาน" ToolbarImage="../../Images/icn_print.png" OnClick="tbPrintClick"/>
            </td>
        </tr>
        <tr>
            <td style="height:30px" valign="top">
                <hr style="size:1px" />
                <asp:Label ID="lbStatus" runat="server" EnableViewState="False"></asp:Label>
                <asp:TextBox ID="txtLOID" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
                <asp:TextBox ID="txtStatus" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
                <asp:TextBox ID="txtCurentTab" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
                <asp:TextBox ID="txtFormulaDiseaseRow" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
                <asp:TextBox ID="txtFormulaFeedItemRow" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td style="padding:5px; border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid; width:500px" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" width="500px">
                                <tr style="height:24px">
                                    <td style="width:100px; text-align:right; padding-right:10px">
                                        ชื่อสูตร :</td> 
                                    <td>
                                        <asp:TextBox ID="txtName" runat="server" CssClass="zTextbox" MaxLength="100" Width="200px"></asp:TextBox>
                                        <asp:Label ID="lblRemarkName" runat="server" CssClass="zRemark" Text="*"></asp:Label>
                                    </td>  
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 100px; text-align: right">
                                        ชนิดอาหาร :</td>
                                    <td>
                                        <asp:TextBox id="txtFeedCategory" runat="server" CssClass="zTextbox-View" ReadOnly="True" Width="200px">Blenderize diet</asp:TextBox>
                                        <asp:Label ID="lblRemarkCategory" runat="server" CssClass="zRemark" Text="*"></asp:Label></td>
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 100px; text-align: right">
                                        ปริมาณ :</td>
                                    <td>
                                        <asp:TextBox ID="txtCapacity" runat="server" CssClass="zTextboxR" AutoPostBack="true" OnTextChanged="txtCapacity_TextChanged">
                                        </asp:TextBox><asp:Label ID="lblRemarkCapacity" runat="server" CssClass="zRemark" Text="*"></asp:Label></td>
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 100px; text-align: right">
                                        อัตราส่วน :</td>
                                    <td>
                                        <asp:TextBox id="txtEnergyRate" runat="server" CssClass="zTextboxR" Width="40px" AutoPostBack="true" OnTextChanged="txtEnergyRate_TextChanged">
                                        </asp:TextBox>
                                        Kcal :
                                        <asp:TextBox id="txtCapacityRate" runat="server" CssClass="zTextboxR" Width="40px" AutoPostBack="true" OnTextChanged="txtCapacityRate_TextChanged">
                                        </asp:TextBox>
                                        ml<asp:Label ID="lblRemarkRate" runat="server" CssClass="zRemark" Text="*"></asp:Label>
                                        &nbsp; &nbsp;พลังงาน&nbsp;<asp:TextBox id="txtEnergy" runat="server" CssClass="zTextboxR-View" Width="50px" ReadOnly="True"></asp:TextBox>
                                        Kcal</td>
                                </tr>

                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 100px; text-align: right">
                                        </td>
                                    <td>
                                       <asp:CheckBox ID="chkActive" runat="server" Text="ใช้งาน" Checked="True" />
                                        </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width:4px">
                            &nbsp;</td>
                        <td style="border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid; padding:5px" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" width="250px">
                                <tr style="height:24px; padding-bottom:12px">
                                    <td colspan="2" style="padding-right:10px;">
                                        การแบ่ง % ของสารที่กำหนด</td>  
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 120px; text-align: right;">
                                        คาร์โบไฮเดรต :</td>
                                    <td>
                                        <asp:TextBox ID="txtCarbohydrate" runat="server" CssClass="zTextboxR" MaxLength="80" Width="80px"></asp:TextBox>
                                        %</td>
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 120px; text-align: right">
                                        โปรตีน :</td>
                                    <td>
                                        <asp:TextBox ID="txtProtein" runat="server" CssClass="zTextboxR" MaxLength="80" Width="80px"></asp:TextBox>
                                        %</td>
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 120px; text-align: right">
                                        ไขมัน :</td>
                                    <td>
                                        <asp:TextBox ID="txtFat" runat="server" CssClass="zTextboxR" MaxLength="80" Width="80px"></asp:TextBox>
                                        %</td>
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
                <cc1:TabContainer ID="tabFormulaFeed" runat="server" ActiveTabIndex="0" OnActiveTabChanged="tabFormulaFeed_ActiveTabChanged" AutoPostBack="true">
                    <cc1:TabPanel ID="tabFormulaFeedItem" runat="server" HeaderText="รายการวัตถุดิบ" >
                        <ContentTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td class="subheadertext">รายการวัตถุดิบ
                                    </td> 
                                </tr>
                                <tr>
                                    <td class="toolbarplace">
                                        <uc1:ToolBarItemCtl ID="tbAddFormulaFeedItem" runat="server" ToobarTitle="เพิ่มรายการ" ToolbarImage="../../Images/icn_add.png" OnClick="tbAddFormulaFeedItemClick" />
                                        <uc1:ToolBarItemCtl ID="tbDeleteFormulaFeedItem" runat="server" ToobarTitle="ลบรายการ" ToolbarImage="../../Images/icn_delete.png" OnClick="tbDeleteFormulaFeedItemClick" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbStatusFormulaFeedItem" runat="server" EnableViewState="False"></asp:Label></td> 
                                </tr> 
                                <tr>
                                    <td>
                                         <asp:GridView ID="gvFormulaFeedItem" runat="server" AutoGenerateColumns="False" CssClass="t_tablestyle" DataSourceID="FormulaFeedItmeSource" DataKeyNames="RANK" Width="750px" OnRowDataBound="gvFormulaFeedItem_RowDataBound">
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
                                                    <HeaderStyle Width="40px" />
                                                    <ItemStyle HorizontalAlign="Center" Width="40px" Height="24px"/>
                                                </asp:TemplateField> 
                                                <asp:BoundField DataField="MATERIALNAME" HeaderText="ส่วนผสม">
                                                    <ItemStyle Width="160px" />
                                                    <HeaderStyle Width="160px" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="จำนวน">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtQty" runat="server" CssClass="zTextboxR" Width="55px" MaxLength="10" Text='<%# Convert.ToDouble(Eval("QTY")).ToString("#,##0.00") %>' onkeypress="ChkDbl(this)" onblur="valDbl(this)" onfocus="prepareNum(this)" AutoPostBack="True" OnTextChanged="txtQty_TextChanged"></asp:TextBox>   
                                                    </ItemTemplate>
                                                    <ItemStyle Width="60px" HorizontalAlign="Right" /> 
                                                    <HeaderStyle Width="60px" HorizontalAlign="Center" /> 
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="หน่วยนับ">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="cmbUnit" Width="80px" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbUnit_SelectedIndexChanged"></asp:DropDownList>  
                                                    </ItemTemplate>
                                                    <ItemStyle Width="80px"/> 
                                                    <HeaderStyle Width="80px" HorizontalAlign="Center" /> 
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="ENERGY" HeaderText="พลังงาน (kcal)" InsertVisible="False" HtmlEncode="False" DataFormatString="{0:#,##0.##}" ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Right" Width="80px" />
                                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="CARBOHYDRATE" HeaderText="คาร์โบไฮเดรต (g)" InsertVisible="False" HtmlEncode="False" DataFormatString="{0:#,##0.##}" ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Right" Width="80px" />
                                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="PROTEIN" HeaderText="โปรตีน (g)" InsertVisible="False" HtmlEncode="False" DataFormatString="{0:#,##0.##}" ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Right" Width="80px" />
                                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="FAT" HeaderText="ไขมัน (g)" InsertVisible="False" HtmlEncode="False" DataFormatString="{0:#,##0.##}" ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Right" Width="80px" />
                                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="SODIUM" HeaderText="โซเดียม (mg)" InsertVisible="False" HtmlEncode="False" DataFormatString="{0:#,##0.##}" ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Right" Width="80px" />
                                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="MATERIALMASTER" HeaderText="MATERIALMASTER">
                                                    <ControlStyle CssClass="zHidden" />
                                                    <FooterStyle CssClass="zHidden" />
                                                    <HeaderStyle CssClass="zHidden" />
                                                    <ItemStyle CssClass="zHidden" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="UNIT" HeaderText="UNIT">
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
                                        <asp:ObjectDataSource ID="FormulaFeedItmeSource" runat="server" SelectMethod="GetBlenderizeItemList" TypeName="BlenderizeItem" UpdateMethod="UpdateFormulaFeedItem">
                                            <UpdateParameters>
                                                <asp:Parameter Name="RANK" Type="Double" />
                                                <asp:Parameter Name="LOID" Type="Double" />
                                                <asp:Parameter Name="FORMULAFEED" Type="Double" />
                                                <asp:Parameter Name="MATERIALMASTER" Type="Double" />
                                                <asp:Parameter Name="MATERIALNAME" Type="String" />
                                                <asp:Parameter Name="QTY" Type="Double" />
                                                <asp:Parameter Name="UNIT" Type="Double" />
                                                <asp:Parameter Name="ENERGY" Type="Double" />
                                                <asp:Parameter Name="CARBOHYDRATE" Type="Double" />
                                                <asp:Parameter Name="PROTEIN" Type="Double" />
                                                <asp:Parameter Name="FAT" Type="Double" />
                                                <asp:Parameter Name="SODIUM" Type="Double" />
                                            </UpdateParameters>
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="txtLOID" DefaultValue="0" Name="formulaFeedID" PropertyName="Text"
                                                    Type="Double" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </td> 
                                </tr> 
                                <tr>
                                    <td style="height:25px">
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
                                        <asp:GridView ID="gvFormulaDisease" runat="server" AutoGenerateColumns="False" CssClass="t_tablestyle" DataSourceID="FormulaDiseaseSource" OnRowDataBound="gvFormulaDisease_RowDataBound" >
                                            <Columns>
                                                <asp:BoundField DataField="LOID" HeaderText="LOID">
                                                    <ControlStyle CssClass="zHidden" />
                                                    <FooterStyle CssClass="zHidden" />
                                                    <HeaderStyle CssClass="zHidden" />
                                                    <ItemStyle CssClass="zHidden" />
                                                </asp:BoundField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <input type="checkbox" name="chkMain" id="Checkbox1" onclick="chkAllBox(this, 'ctl00_MainContent_tabFormulaSet_tabFormulaDisease_gvFormulaDisease_ctl', '_chkSelect')" />
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
                                                        <asp:RadioButton ID="chkHigh" runat="server" GroupName="CategoryName" Checked='<%# Eval("ISHIGH").ToString() =="Y" %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="40px" />
                                                    <ItemStyle HorizontalAlign="Center" Width="40px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Low">
                                                    <ItemTemplate>
                                                        <asp:RadioButton ID="chkLow" runat="server" GroupName="CategoryName" Checked='<%# Eval("ISLOW").ToString() =="Y" %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="40px" />
                                                    <ItemStyle HorizontalAlign="Center" Width="40px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Non">
                                                    <ItemTemplate>
                                                        <asp:RadioButton ID="chkNon" runat="server" GroupName="CategoryName" Checked='<%# Eval("ISNON").ToString() =="Y" %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="40px" />
                                                    <ItemStyle HorizontalAlign="Center" Width="40px" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="DISEASECATEGORY" HeaderText="DISEASECATEGORY" ReadOnly="True">
                                                    <ControlStyle CssClass="zHidden" />
                                                    <FooterStyle CssClass="zHidden" />
                                                    <HeaderStyle CssClass="zHidden" />
                                                    <ItemStyle CssClass="zHidden" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ISHIGHVISIBLE" HeaderText="ISHIGHVISIBLE" ReadOnly="True">
                                                    <ControlStyle CssClass="zHidden" />
                                                    <FooterStyle CssClass="zHidden" />
                                                    <HeaderStyle CssClass="zHidden" />
                                                    <ItemStyle CssClass="zHidden" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ISLOWVISIBLE" HeaderText="ISLOWVISIBLE" ReadOnly="True">
                                                    <ControlStyle CssClass="zHidden" />
                                                    <FooterStyle CssClass="zHidden" />
                                                    <HeaderStyle CssClass="zHidden" />
                                                    <ItemStyle CssClass="zHidden" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ISNONVISIBLE" HeaderText="ISNONVISIBLE" ReadOnly="True">
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
                                        <asp:ObjectDataSource ID="FormulaDiseaseSource" runat="server" SelectMethod="GetFormulaDiseaseList" TypeName="BlenderizeItem">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="txtLOID" DefaultValue="0" Name="formulaFeedID" PropertyName="Text"
                                                    Type="Double" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </td> 
                                </tr>
                            </table>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="tabNutrient" runat="server" HeaderText="สารอาหารที่ได้รับ">
                        <ContentTemplate>
                            <asp:GridView ID="gvFormulaFeedNutrient" runat="server" AutoGenerateColumns="False" CssClass="t_tablestyle" DataSourceID="FormulaFeedNutrientSource" Width="400px">
                                <Columns>
                                    <asp:TemplateField HeaderText="ลำดับ">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1%>
                                        </ItemTemplate> 
                                        <HeaderStyle Width="40px" />
                                        <ItemStyle HorizontalAlign="Center" Width="50px" Height="20px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="NUTRIENTNAME" HeaderText= "สารอาหาร" ReadOnly="True">
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="ปริมาณ (g)">
                                        <ItemTemplate>
                                            <asp:Label ID="lblQty" runat="server" Text='<%# Convert.ToDouble(Eval("QTY")).ToString("#,##0.00") + " " + Eval("UNITNAME") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" Width="90px" />
                                        <HeaderStyle Width="90px" />
                                    </asp:TemplateField> 
                                    <asp:BoundField DataField="ENERGY" DataFormatString="{0:N2}" HeaderText= "%พลังงาน" ReadOnly="True">
                                        <ItemStyle HorizontalAlign="Right" Width="90px" />
                                        <HeaderStyle Width="90px" />
                                    </asp:BoundField>
                                </Columns>
                                <HeaderStyle CssClass="t_headtext" />
                                <AlternatingRowStyle CssClass="t_alt_bg" />
                                <PagerSettings Visible="False" />
                            </asp:GridView>
                            <asp:ObjectDataSource ID="FormulaFeedNutrientSource" runat="server" SelectMethod="GetFormulaNutrientList"
                                TypeName="BlenderizeItem">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="txtLOID" DefaultValue="0" Name="formulaFeedID" PropertyName="Text"
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
</asp:Content>
