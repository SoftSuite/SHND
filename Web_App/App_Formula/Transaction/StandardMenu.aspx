<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="StandardMenu.aspx.cs" Inherits="App_Formula_Transaction_StandardMenu" Title="SHND : Transaction - Statndard Menu" %>
<%@ Register Src="../../Search/DiseaseCategoryPopup.ascx" TagName="DiseaseCategoryPopup" TagPrefix="uc3" %>
<%@ Register Src="Controls/StdMenuItemControl.ascx" TagName="StdMenuItemControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <script language="JavaScript" type="text/javascript">
        function tabStdMenu_ClientActiveTabChanged(sender, e)
        {
            __doPostBack('<%= tabStdMenu.ClientID %>', sender.get_activeTab().get_headerText());
        }
    </script>
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="headtext">
                ข้อมูลเมนูมาตรฐาน</td>
        </tr>
        <tr>
            <td style="height: 20px">
                <uc1:ToolBarItemCtl ID="tbSave" runat="server" ToobarTitle="บันทึก" ToolbarImage="../../Images/save2.png" OnClick="tbSaveClick" />
                <uc1:ToolBarItemCtl ID="tbCancel" runat="server" ToobarTitle="ยกเลิกการแก้ไข" ToolbarImage="../../Images/cancel.png" OnClick="tbCancelClick" />
                <uc1:ToolBarItemCtl ID="tbBack" runat="server" ToobarTitle="กลับหน้ารายการ" ToolbarImage="../../Images/icn_back.png" OnClick="tbBackClick"/>
                <uc1:ToolBarItemCtl ID="tbPrint" runat="server" ToobarTitle="พิมพ์รายงาน" ToolbarImage="../../Images/icn_print.png" />
                <uc1:ToolBarItemCtl ID="tbConfirm" runat="server" ToobarTitle="ยืนยัน" ToolbarImage="../../Images/icn_add.png" OnClick="tbConfirmClick"/>
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
                <asp:TextBox ID="txtDivision" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
                <asp:TextBox ID="txtCurentTab" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td style="padding:5px; border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid; width:400px" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" width="550px">
                                <tr style="height:24px">
                                    <td style="width:110px; text-align:right; padding-right:10px">
                                        ชื่อชุดอาหาร :</td> 
                                    <td>
                                        <asp:TextBox ID="txtName" runat="server" CssClass="zTextbox" MaxLength="100" Width="350px"></asp:TextBox>
                                        <asp:Label ID="lblRemarkName" runat="server" CssClass="zRemark" Text="*"></asp:Label>
                                    </td>
                                </tr>
                                <tr style="height: 24px">
                                    <td style="width:110px; text-align:right; padding-right:10px">
                                        ประเภทอาหาร :</td> 
                                    <td>
                                        <asp:DropDownList ID="cmbFoodType" runat="server" Width="205px" CssClass="zComboBox" AutoPostBack="True" OnSelectedIndexChanged="cmbFoodType_SelectedIndexChanged"></asp:DropDownList>
                                        <asp:Label ID="lblRemarkFoodType" runat="server" CssClass="zRemark" Text="*"></asp:Label>
                                    </td>
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 110px; text-align: right">
                                        ชนิดอาหาร :</td>
                                    <td>
                                        <asp:DropDownList ID="cmbFoodCategory" runat="server" Width="205px" CssClass="zComboBox"></asp:DropDownList>
                                        <asp:Label ID="Label5" runat="server" CssClass="zRemark" Text="*"></asp:Label>
                                    </td>
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 110px; text-align: right">
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkIsSpecific" runat="server" Text="อาหารเฉพาะโรค" /> 
                                    </td>
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 110px; text-align: right">
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkActive" runat="server" Text="ใช้งาน" /> 
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width:4px">
                            &nbsp;</td>
                        <td style="border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid; padding:5px" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" width="300px">
                                <tr style="height:24px;">
                                    <td style="width:100px; text-align:right; padding-right:10px;">
                                        สถานะ :</td> 
                                    <td>
                                        <asp:TextBox ID="txtStatusName" runat="server" CssClass="zTextbox-View"
                                            ReadOnly="True" Width="150px"></asp:TextBox></td> 
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 100px; text-align: right">
                                        หน่วยงาน :</td>
                                    <td>
                                        <asp:TextBox ID="txtDivisionName" runat="server" CssClass="zTextbox-View" ReadOnly="True"
                                            Width="150px"></asp:TextBox></td>
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
                <cc1:TabContainer ID="tabStdMenu" runat="server" ActiveTabIndex="0" OnActiveTabChanged="tabStdMenu_ActiveTabChanged" AutoPostBack="true">
                    <cc1:TabPanel ID="tabStdMenuDisease" runat="server" HeaderText="ชนิดสารอาหารที่ควบคุม" >
                        <ContentTemplate>
                            <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                <tr>
                                    <td class="toolbarplace">
                                        <uc1:ToolBarItemCtl ID="tbAddStdMenuDisease" runat="server" ToobarTitle="เพิ่มรายการ" ToolbarImage="../../Images/icn_add.png" OnClick="tbAddStdMenuDiseaseClick" />
                                        <uc1:ToolBarItemCtl ID="tbDeleteStdMenuDisease" runat="server" ToobarTitle="ลบรายการ" ToolbarImage="../../Images/icn_delete.png" OnClick="tbDeleteStdMenuDiseaseClick" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbStatusStdMenuDisease" runat="server" EnableViewState="False"></asp:Label>
                                    </td> 
                                </tr>
                                <tr>
                                    <td>
                                        <asp:GridView ID="gvStdMenuDisease" runat="server" AutoGenerateColumns="False" CssClass="t_tablestyle" DataSourceID="stdMenuDiseaseSource" OnRowDataBound="gvStdMenuDisease_RowDataBound">
                                            <Columns>
                                                <asp:BoundField DataField="DISEASECATEGORY" HeaderText="DISEASECATEGORY">
                                                    <ControlStyle CssClass="zHidden" />
                                                    <FooterStyle CssClass="zHidden" />
                                                    <HeaderStyle CssClass="zHidden" />
                                                    <ItemStyle CssClass="zHidden" />
                                                </asp:BoundField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <input type="checkbox" name="chkMain" id="chkMain" onclick="chkAllBox(this, 'ctl00_MainContent_tabStdMenu_tabStdMenuDisease_gvStdMenuDisease_ctl', '_chkSelect')" />
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
                                                <asp:BoundField DataField="DISEASECATEGORYNAME" HeaderText="สารอาหารที่ควบคุม">
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
                                                <asp:BoundField ReadOnly="True" DataField="ISHIGH" HeaderText="ISHIGH">
                                                <ControlStyle CssClass="zHidden"></ControlStyle>

                                                <ItemStyle CssClass="zHidden"></ItemStyle>

                                                <HeaderStyle CssClass="zHidden"></HeaderStyle>

                                                <FooterStyle CssClass="zHidden"></FooterStyle>
                                                </asp:BoundField>
                                                <asp:BoundField ReadOnly="True" DataField="ISLOW" HeaderText="ISLOW">
                                                <ControlStyle CssClass="zHidden"></ControlStyle>

                                                <ItemStyle CssClass="zHidden"></ItemStyle>

                                                <HeaderStyle CssClass="zHidden"></HeaderStyle>

                                                <FooterStyle CssClass="zHidden"></FooterStyle>
                                                </asp:BoundField>
                                                <asp:BoundField ReadOnly="True" DataField="ISNON" HeaderText="ISNON">
                                                <ControlStyle CssClass="zHidden"></ControlStyle>

                                                <ItemStyle CssClass="zHidden"></ItemStyle>

                                                <HeaderStyle CssClass="zHidden"></HeaderStyle>

                                                <FooterStyle CssClass="zHidden"></FooterStyle>
                                                </asp:BoundField>
                                            </Columns>
                                            <HeaderStyle CssClass="t_headtext" />
                                            <AlternatingRowStyle CssClass="t_alt_bg" />
                                            <PagerSettings Visible="False" />
                                        </asp:GridView>
                                        <asp:ObjectDataSource ID="stdMenuDiseaseSource" runat="server" SelectMethod="GetStdMenuDiseaseList" TypeName="StandardMenuDetailItem">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="txtLOID" DefaultValue="0" Name="stdMenuID" PropertyName="Text"
                                                    Type="Double" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </td> 
                                </tr>
                            </table>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="tabStdMenuItemBreakfast" runat="server" HeaderText="มื้อเช้า">
                        <ContentTemplate>
                            <uc2:StdMenuItemControl ID="ctlStdMenuItemBreakfast" runat="server"/>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="tabStdMenuItemLunch" runat="server" HeaderText="มื้อกลางวัน" >
                        <ContentTemplate>
                            <uc2:StdMenuItemControl ID="ctlStdMenuItemLunch" runat="server"/>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="tabStdMenuItemDinner" runat="server" HeaderText="มื้อเย็น" >
                        <ContentTemplate>
                            <uc2:StdMenuItemControl ID="ctlStdMenuItemDinner" runat="server"/>
                        </ContentTemplate>
                    </cc1:TabPanel>
                </cc1:TabContainer>
            </td>
        </tr>  
    </table> 
    <uc3:DiseaseCategoryPopup id="ctlDiseaseCategoryPopup" runat="server" OnSelectedIndexChanged="ctlDiseaseCategoryPopup_SelectedIndexChanged" />
</asp:Content>