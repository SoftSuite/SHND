<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="MaterialFeed.aspx.cs" Inherits="App_Inventory_Master_MaterialFeed"  Title="SHND : Master - Material Feed" %>

<%@ Register Src="../../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <script language="JavaScript" type="text/javascript">
        function TabContainer_ActiveTabChanged(sender, e)
        {
            __doPostBack('<%= TabContainer1.ClientID %>', sender.get_activeTab().get_headerText());
        }
    </script>
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
            <td class="headtext">
                ข้อมูลอาหารทางสาย/นม/ยา</td>
        </tr>
        <tr>
            <td>
            <uc1:ToolBarItemCtl ID="tbAdd" runat="server" ToobarTitle="เพิ่มข้อมูล" OnClick="tbAddClick" ToolbarImage="../../Images/icn_add.png"  />
            <uc1:ToolBarItemCtl ID="ToolBarItemCtl1" runat="server" ToobarTitle="ลบข้อมูลที่เลือก" OnClick="tbDeleteClick" ToolbarImage="../../Images/icn_delete.png" ClientClick="return confirm('ต้องการลบข้อมูลที่เลือก ใช่หรือไม่?')"  />
            <uc1:ToolBarItemCtl ID="tbPrint" runat="server" ToobarTitle="พิมพ์" ToolbarImage="../../Images/icn_print.png"  />
                <uc1:ToolBarItemCtl ID="tbExcel" runat="server" ToobarTitle="Export to Excel" ToolbarImage="../../Images/icn_excel.png"  />

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
                        <td colspan="2">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width:120px; text-align: right; padding-right:10px; height: 24px;">
                            ประเภท :</td>
                        <td style="height: 24px">
                            <asp:DropDownList ID="cmbSearchGroup" runat="server" Width="206px">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td style="width:120px; text-align: right; padding-right:10px; height: 24px;">
                            ชื่อวัสดุ :</td>
                        <td style="height: 24px">
                            <asp:TextBox ID="txtSearchName" runat="server" CssClass="zTextbox" Width="200px"></asp:TextBox>
                            &nbsp; &nbsp;<asp:ImageButton ID="imbSearch" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_find.png"
                    OnClick="imbSearch_Click" />&nbsp;
                <asp:ImageButton ID="imbReset" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_back.png"
                    OnClick="imbReset_Click" ToolTip="แสดงทั้งหมด" />
                    </td></tr>
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
                <uc2:PageControl ID="pcTop" runat="server" OnPageChange="PageChange"/>
                <asp:GridView ID="gvMain" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="t_tablestyle" OnRowDataBound="gvMain_RowDataBound" 
                    OnSorting="gvMain_Sorting" AllowPaging="True" PageSize="20" Width="100%">
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
                        <asp:TemplateField HeaderText="รหัส SAP" SortExpression="SAPCODE">
                            <HeaderStyle HorizontalAlign="Center" Width="80px" />
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkName" runat="server" Text='<%# Bind("SAPCODE") %>' OnClick="lnkName_Click" CommandArgument='<%# Bind("LOID")  %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="MATERIALNAME" HeaderText="รายการ" SortExpression="MATERIALNAME">
                            <HeaderStyle Width="200px" />
                            <ItemStyle Width="200px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="GROUPNAME" HeaderText="ประเภท" SortExpression="GROUPNAME">
                            <HeaderStyle HorizontalAlign="Center" Width="120px" />
                            <ItemStyle Width="120px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="UNITNAME" HeaderText="หน่วยนับ" SortExpression="UNITNAME">
                            <HeaderStyle HorizontalAlign="Center" Width="80px" />
                            <ItemStyle Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ACTIVENAME" HeaderText="การใช้งาน" SortExpression="ACTIVENAME">
                            <HeaderStyle HorizontalAlign="Center" Width="80px" />
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="REMARKS" HeaderText="หมายเหตุ" SortExpression="REMARKS">
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
    <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" style="display:none" Width="800px" Height="600" ScrollBars="Auto">
    <table cellspacing="0" cellpadding="0" border="0" width="100%">
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbSave" runat="server" ToobarTitle="บันทึก" ToolbarImage="../../Images/save2.png" OnClick="tbSave1Click" />
                <uc1:ToolBarItemCtl ID="tbSave2" runat="server" ToobarTitle="บันทึกและเพิ่มรายการใหม่" ToolbarImage="../../Images/icn_save_add.png" OnClick="tbSave2Click"  />
                <uc1:ToolBarItemCtl ID="tbCancel" runat="server" ToobarTitle="ยกเลิกการแก้ไข" ToolbarImage="../../Images/cancel.png" OnClick="tbCancelClick" />
                <uc1:ToolBarItemCtl ID="tbBack" runat="server" ToobarTitle="กลับหน้ารายการ" ToolbarImage="../../Images/icn_back.png" OnClick="tbBackClick"/>
            </td>
        </tr>
        <tr>
            <td><hr style="size:1px" /></td>
        </tr>
        <tr>
            <td>
              <asp:Label ID="lbStatusTab" runat="server" EnableViewState="False"></asp:Label>
                <asp:TextBox ID="txhSortField" runat="server" Visible="False" Width="15px"></asp:TextBox>
                <asp:TextBox ID="txhSortDir" runat="server" Visible="False" Width="15px"></asp:TextBox>
                <asp:TextBox ID="txhID" runat="server" Visible="False" Width="15px"></asp:TextBox>
                <asp:TextBox ID="txtCurrTabIndex" Visible="False" runat="server" Width="32px">0</asp:TextBox>
            </td>
        </tr>
    </table>
    <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" OnActiveTabChanged="TabContainer1_ActiveTabChanged" AutoPostBack="true">
        <cc1:TabPanel ID="tabFeedDetail" runat="server" HeaderText="รายละเอียด">
            <ContentTemplate>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td style="width:460px" valign="top">
                            <table cellspacing="0" cellpadding="1" border="0" width="100%" >
                                                    <tr>
                                    <td style="width: 120px; padding-right: 10px;" align="right">
                                    </td>
                                    <td><asp:Label ID="lbStatusTab1" runat="server" EnableViewState="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 120px; padding-right: 10px; height: 23px;" align="right">รหัสวัสดุ :</td>
                                    <td><asp:TextBox ID="txtCode" runat="server" Width="123px" ReadOnly="true" CssClass="zTextbox-View" ></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 120px; padding-right: 10px; height: 24px;" align="right">&nbsp;
                                    </td>
                                    <td><asp:CheckBox ID="chkActive" runat="server" Text="ใช้งาน" Checked="true" ></asp:CheckBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 120px; padding-right: 10px; height: 24px;" align="right">
                                        ชื่อวัสดุ :</td>
                                    <td><asp:TextBox ID="txtName" runat="server" Width="290px" CssClass="zTextbox" ></asp:TextBox>
                                        <asp:Label id="lbl1" runat="server" Text="*" ForeColor="red"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 120px; padding-right: 10px; height: 24px;" align="right">ประเภท :</td>
                                    <td>
                                        <asp:DropDownList ID="cmbMaterialGroup1" runat="server" Width="296px" CssClass="zComboBox" AutoPostBack="True" OnSelectedIndexChanged="cmbMaterialGroup1_SelectedIndexChanged"></asp:DropDownList>
                                        <asp:Label id="Label2" runat="server" Text="*" ForeColor="red"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 120px; padding-right: 10px; height: 24px;" align="right">ชนิดของนม :</td>
                                    <td style="height: 24px"><asp:DropDownList ID="cmbMilkCategory" runat="server" Width="150px" CssClass="zComboBox" Enabled="False"></asp:DropDownList>
                                        <asp:Label id="LblMilk" runat="server" Text="*  (นมผสมสำหรับเด็ก)" ForeColor="red"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 120px; padding-right: 10px; height: 24px;" align="right">หน่วยนับ :</td>
                                    <td style="height: 24px"><asp:DropDownList ID="cmbUnit1" runat="server" Width="150px" CssClass="zComboBox"></asp:DropDownList>
                                        <asp:Label id="Label3" runat="server" Text="*" ForeColor="red"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 120px; padding-right: 10px; height: 24px;" align="right">น้ำหนัก(กรัม)ต่อหน่วย :</td>
                                    <td style="height: 24px"><asp:TextBox ID="txtWeight" runat="server" Width="106px" CssClass="zTextboxR" ></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 120px; padding-right: 10px; height: 24px;" align="right">ราคาทุน :</td>
                                    <td style="height: 24px"><asp:TextBox ID="txtCost" runat="server" Width="106px" CssClass="zTextboxR" ></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 120px; padding-right: 10px; height: 24px;" align="right">ราคาขาย :</td>
                                    <td style="height: 24px"><asp:TextBox ID="txtPrice" runat="server" Width="106px" CssClass="zTextboxR" ></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 120px; padding-right: 10px;" valign="top" align="right">Spec :</td>
                                    <td><asp:TextBox ID="txtSpec" runat="server" Width="290px" Rows="4" TextMode="MultiLine" CssClass="zTextbox" ></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 120px; padding-right: 10px; height: 24px;" align="right">วิธีการรับเข้า :</td>
                                    <td style="height: 24px"><asp:DropDownList ID="cmbOrderType" runat="server" Width="150px" CssClass="zComboBox">
                                        <asp:ListItem Value="">เลือก</asp:ListItem>
                                        <asp:ListItem Value="PO">สั่งซื้อ</asp:ListItem>
                                        <asp:ListItem Value="RQ">เบิกจากคลังโรงพยาบาล</asp:ListItem>
                                        <asp:ListItem Value="SA">รับจากระบบ SAP</asp:ListItem>
                                        <asp:ListItem Value="OT">รับโดยกรณีอื่นๆ</asp:ListItem>
                                    </asp:DropDownList>
                                        <asp:Label id="Label4" runat="server" Text="*" ForeColor="red"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 120px; padding-right: 10px; height: 24px;" align="right">หน่วยงานที่ตัดจ่าย :</td>
                                    <td style="height: 24px"><asp:DropDownList ID="cmbDivision" runat="server" Width="150px" CssClass="zComboBox"></asp:DropDownList>
                                        <asp:Label id="Label5" runat="server" Text="*" ForeColor="red"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 120px; padding-right: 10px; height: 24px;" align="right">&nbsp;
                                    </td>
                                    <td style="height: 24px"><asp:CheckBox ID="chkIsCount" runat="server" Text="นับสต๊อก" Checked="true" ></asp:CheckBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 120px; padding-right: 10px; height: 24px;" align="right">ปริมาณต่ำสุด :</td>
                                    <td style="height: 24px"><asp:TextBox ID="txtMinStock" runat="server" Width="106px" CssClass="zTextboxR" ></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 120px; padding-right: 10px; height: 24px;" align="right">ปริมาณสูงสุด :</td>
                                    <td style="height: 24px"><asp:TextBox ID="txtMaxStock" runat="server" Width="106px" CssClass="zTextboxR" ></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 120px; padding-right: 10px;" valign="top" align="right">หมายเหตุ :</td>
                                    <td><asp:TextBox ID="txtRemarks" runat="server" Width="290px" Rows="4" TextMode="MultiLine" CssClass="zTextbox" ></asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="height:3px;">
                                </tr>
                            </table>
                        </td>
                        <td valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" width="280px" style="border-right: mediumorchid thin solid; border-top: mediumorchid thin solid; border-left: mediumorchid thin solid; border-bottom: mediumorchid thin solid;">
                                <tr>
                                    <td style="padding:5px">
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td style="width: 90px; padding-right:10px; height: 24px;" align="right">รหัส SAP :</td>
                                                <td style="height: 24px">
                                                    <asp:TextBox ID="txtSAP" runat="server" CssClass="zTextbox"  Width="150px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 90px; padding-right:10px; height: 24px;" align="right">คลัง SAP :</td>
                                                <td style="height: 24px">
                                                    <asp:DropDownList ID="cmbSAP" runat="server" CssClass="zComboBox" Width="156px">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td> 
                                </tr>
                            </table> 
                        </td>
                    </tr> 
                </table>
            </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel ID="tabFeedUnit" runat="server" HeaderText="หน่วยย่อย">
            <ContentTemplate>
                <table cellspacing="0" cellpadding="1" border="0" >
                    <tr>
                        <td style="width: 100px">
                        </td>
                        <td><asp:Label ID="lbStatusTab2" runat="server" EnableViewState="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px">รหัสวัสดุ
                        </td>
                        <td><asp:TextBox ID="txtCode_FeedUnit" runat="server" Width="123px" CssClass="zTextbox-View" ReadOnly="True" ></asp:TextBox>&nbsp;&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px">ชื่อวัสดุอาหาร
                        </td>
                        <td><asp:TextBox ID="txtName_FeedUnit" runat="server" Width="296px" CssClass="zTextbox-View" ReadOnly="True" ></asp:TextBox>
                    </tr>
                    <tr>
                        <td style="width: 100px">ประเภทอาหาร
                        </td>
                        <td><asp:TextBox ID="txtMaterialGroup_FeedUnit" runat="server" Width="260px" CssClass="zTextbox-View" ReadOnly="True" ></asp:TextBox>
                    </tr>
                    <tr>
                        <td style="width: 100px">หน่วยหลัก
                        </td>
                        <td><asp:TextBox ID="txtUnit_FeedUnit" runat="server" Width="260px" CssClass="zTextbox-View" ReadOnly="True" ></asp:TextBox>
                    </tr>
                </table><br />
                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                    <tr>
                        <td class="t_headtext">
                            หน่วยย่อย
                        </td>
                    </tr>
                </table>
          <asp:GridView ID="gvFeedUnit" runat="server" AllowSorting="True" ShowFooter="True" AutoGenerateColumns="False" CssClass="t_tablestyle" OnRowDataBound="gvFeedUnit_RowDataBound" OnRowEditing="gvFeedUnit_RowEditing" OnRowCancelingEdit="gvFeedUnit_RowCancelingEdit" OnRowDeleting="gvFeedUnit_RowDeleting" OnRowUpdating="gvFeedUnit_RowUpdating"   >
                    <Columns>
                        <asp:BoundField DataField="MMLOID" HeaderText="MMLOID">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:TemplateField ShowHeader="False">
                                <EditItemTemplate>
                                    <asp:ImageButton ID="imbSave" runat="server" CausesValidation="true" CommandName="Update" ImageUrl="~/Images/save2.png" />&nbsp;
                                    <asp:ImageButton ID="imbCancel" runat="server" CausesValidation="False" CommandName="Cancel" ImageUrl="~/Images/cancel.png"/>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:ImageButton ID="imbEdit" runat="server" CausesValidation="true" CommandName="Edit" ImageUrl="~/Images/icn_edit.png" />&nbsp;
                                    <asp:ImageButton ID="imbDelete" runat="server" CausesValidation="true" CommandName="Delete" ImageUrl="~/Images/icn_delete.png" OnClientClick="return confirm('ต้องการลบข้อมูล ใช่หรือไม่?')"/>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:ImageButton ID="imbSaveUnit" runat="server" ImageUrl="~/Images/save2.png" OnClick="imbSaveUnit_Click" />
                                </FooterTemplate>
                            <HeaderStyle Width="60px" />
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                            <FooterStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="หน่วยนับ">
                            <ItemTemplate>
                                <asp:Label ID="lbTHNAME" runat="server" Text='<%# Bind("THNAME") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="cmbTHUNIT" runat="server" CssClass="zComboBox" Width="105px"></asp:DropDownList>
                                <asp:Label ID="lblTHUNITAdd1" runat="server" Text="*" ForeColor="red"></asp:Label>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:DropDownList ID="cmbTHUNITAdd" runat="server" CssClass="zComboBox" Width="105px" />
                                <asp:Label ID="lblTHUNITAdd" runat="server" Text="*" ForeColor="red"></asp:Label>
                            </FooterTemplate>
                            <FooterStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" Width="120px" />
                            <ItemStyle HorizontalAlign="Left" Width="120px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="น้ำหนักต่อหน่วย(g)">
                            <ItemTemplate>
                                <asp:Label ID="lblWeight" runat="server" Text='<%# Bind("WEIGHT") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtWeight" runat="server" CssClass="zTextboxR" Width="70px"></asp:TextBox>
                                <asp:Label ID="lblWeightAdd1" runat="server" Text="*" ForeColor="red"></asp:Label>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtWeightAdd" runat="server" CssClass="zTextboxR" Width="70px" />
                                <asp:Label ID="lblWeightAdd" runat="server" Text="*" ForeColor="red"></asp:Label>
                            </FooterTemplate>
                            <FooterStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" Width="90px" />
                            <ItemStyle HorizontalAlign="Right" Width="90px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ราคาทุน">
                            <ItemTemplate>
                                <asp:Label ID="lblCost" runat="server" Text='<%# Bind("COST") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtCost" runat="server" CssClass="zTextboxR"  Width="70px"></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtCostAdd" runat="server" CssClass="zTextboxR" Width="70px" />
                            </FooterTemplate>
                            <FooterStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" Width="80px" />
                            <ItemStyle HorizontalAlign="Right" Width="80px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ราคาขาย">
                            <ItemTemplate>
                                <asp:Label ID="lblPrice" runat="server" Text='<%# Bind("PRICE") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPrice" runat="server" CssClass="zTextboxR"  Width="70px"></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtPriceAdd" runat="server" CssClass="zTextboxR" Width="70px" />
                            </FooterTemplate>
                            <FooterStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" Width="80px" />
                            <ItemStyle HorizontalAlign="Right" Width="80px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ตัวคูณ">
                            <ItemTemplate>
                                <asp:Label ID="lblMultiply" runat="server" Text='<%# Bind("MULTIPLY") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtMultiply" runat="server" CssClass="zTextboxR"  Width="60px"></asp:TextBox>
                                <asp:Label ID="lblMultiplyAdd1" runat="server" Text="*" ForeColor="red"></asp:Label>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtMultiplyAdd" runat="server" CssClass="zTextboxR" Width="60px" />
                                <asp:Label ID="lblMultiplyAdd" runat="server" Text="*" ForeColor="red"></asp:Label>
                            </FooterTemplate>
                            <FooterStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" Width="80px" />
                            <ItemStyle HorizontalAlign="Right" Width="80px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="รับเข้า">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkIsStockIn" runat="server" Enabled="false"></asp:CheckBox>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:CheckBox ID="chkIsStockInEdit" runat="server" ></asp:CheckBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:CheckBox ID="chkIsStockInAdd" runat="server"  />
                            </FooterTemplate>
                            <FooterStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" Width="60px" />
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="เบิกจ่าย">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkIsStockOut" runat="server" Enabled="false"></asp:CheckBox>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:CheckBox ID="chkIsStockOutEdit" runat="server" ></asp:CheckBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:CheckBox ID="chkIsStockOutAdd" runat="server"  />
                            </FooterTemplate>
                            <FooterStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" Width="60px" />
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="สร้างสูตร">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkIsFormula" runat="server" Enabled="false"></asp:CheckBox>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:CheckBox ID="chkIsFormulaEdit" runat="server" ></asp:CheckBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:CheckBox ID="chkIsFormulaAdd" runat="server"  />
                            </FooterTemplate>
                            <FooterStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" Width="60px" />
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ใช้งาน">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkActive" runat="server" Enabled="false"></asp:CheckBox>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:CheckBox ID="chkActiveEdit" runat="server" ></asp:CheckBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:CheckBox ID="chkActiveAdd" runat="server" Checked="true"  />
                            </FooterTemplate>
                            <FooterStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" Width="60px" />
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="WEIGHT" HeaderText="WEIGHT" ReadOnly="True">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="COST" HeaderText="COST" ReadOnly="True">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRICE" HeaderText="PRICE" ReadOnly="True">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="MULTIPLY" HeaderText="MULTIPLY" ReadOnly="True">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ISSTOCKIN" HeaderText="ISSTOCKIN" ReadOnly="True">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ISSTOCKOUT" HeaderText="ISSTOCKOUT" ReadOnly="True">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ISFORMULA" HeaderText="ISFORMULA" ReadOnly="True">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ACTIVE" HeaderText="ACTIVE" ReadOnly="True">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="UNITLOID" HeaderText="UNITLOID" ReadOnly="True">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ISMAIN" HeaderText="ISMAIN" ReadOnly="True">
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
                &nbsp;
            </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="สารอาหาร" >
            <ContentTemplate>
                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                    <tr>
                        <td style="width: 100px">
                        </td>
                        <td><asp:Label ID="lbStatusTab3" runat="server" EnableViewState="False"></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td style="width: 127px">
                            &nbsp;&nbsp;รหัส SAP
                        </td>
                        <td>
                            <asp:TextBox ID="txtMSap" runat="server" Width="100px" CssClass="zTextbox-View"></asp:TextBox>&nbsp;&nbsp;
                        </td>
                        <td>
                        </td>
                    </tr>
                                        <tr>
                        <td style="width: 127px">
                            &nbsp;&nbsp;ชื่อวัสดุอาหาร
                        </td>
                        <td>
                            <asp:TextBox ID="txtMName" runat="server" Width="200px" CssClass="zTextbox-View"></asp:TextBox>&nbsp;&nbsp;
                        </td>
                        <td>
                        </td>
                    </tr>
                                        <tr>
                        <td style="width: 127px">
                            &nbsp;&nbsp;ประเภทอาหาร
                        </td>
                        <td>
                            <asp:TextBox ID="txtMType" runat="server" Width="200px" CssClass="zTextbox-View"></asp:TextBox>&nbsp;&nbsp;
                        </td>
                        <td>
                        </td>
                    </tr>
                                        <tr>
                        <td style="width: 127px">
                            &nbsp;&nbsp;หน่วยหลัก
                        </td>
                        <td>
                            <asp:TextBox ID="txtMUnit" runat="server" Width="100px" CssClass="zTextbox-View"></asp:TextBox>&nbsp;&nbsp;
                        </td>
                        <td>
                        </td>
                    </tr>                    
                    <tr>
                        <td colspan="2">
                            &nbsp;&nbsp;น้ำหนักสำหรับใช้คำนวณพลังงานและสารอาหาร
                        </td>
                        <td>
                        </td>
                    </tr> 
                    <tr>
                        <td style="width: 127px">
                            &nbsp;&nbsp;
                        </td>
                        <td>
                            <asp:TextBox ID="txtMWeight" runat="server" Width="100px" CssClass="zTextboxR"></asp:TextBox>&nbsp;&nbsp;กรัม
                        </td>
                        <td>
                        </td>
                    </tr>             
                    <tr>
                        <td style="width: 127px">
                            &nbsp;&nbsp;พลังงานที่ได้รับ 
                        </td>
                        <td>
                            <asp:TextBox ID="txtKcal" runat="server" Width="100px" CssClass="zTextboxR-View" ReadOnly="true"></asp:TextBox>&nbsp;&nbsp;Kcal
                        </td>
                        <td>
                            <asp:TextBox ID="txhSortFieldTabNutrient" runat="server" Visible="False" Width="15px"></asp:TextBox>
                            <asp:TextBox ID="txhSortDirTabNutrient" runat="server" Visible="False" Width="15px"></asp:TextBox>
                        </td>
                    </tr>
                </table><br />
                <table cellspacing="0" cellpadding="0" border="0" width="550">
                    <tr>
                        <td class="t_headtext" style="height: 25px">
                            &nbsp;สารอาหารที่ได้รับ
                        </td>
                    </tr>
                </table>
                <asp:GridView ID="gvFeedNutrient" runat="server" AllowSorting="True" ShowFooter="True" AutoGenerateColumns="False" CssClass="t_tablestyle" OnSorting="gvFeedNutrient_Sorting" OnRowDataBound="gvFeedNutrient_RowDataBound" OnRowDeleting="gvFeedNutrient_RowDeleting" OnRowCancelingEdit="gvFeedNutrient_RowCancelingEdit" OnRowEditing="gvFeedNutrient_RowEditing" OnRowUpdating="gvFeedNutrient_RowUpdating">
                    <Columns>
                        <asp:BoundField DataField="NUTRIENTLOID" HeaderText="NUTRIENTLOID">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:TemplateField ShowHeader="False">
                                <EditItemTemplate>
                                    <asp:ImageButton ID="imbgvFeedNutrientSave" runat="server" CausesValidation="true" CommandName="Update" ImageUrl="~/Images/save2.png" />&nbsp;
                                    <asp:ImageButton ID="imbgvFeedNutrientCancel" runat="server" CausesValidation="False" CommandName="Cancel" ImageUrl="~/Images/cancel.png"/>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:ImageButton ID="imbgvFeedNutrientEdit" runat="server" CausesValidation="true" CommandName="Edit" ImageUrl="~/Images/icn_edit.png" />&nbsp;
                                    <asp:ImageButton ID="imbgvFeedNutrientDelete" runat="server" CausesValidation="true" CommandName="Delete" ImageUrl="~/Images/icn_delete.png" OnClientClick="return confirm('ต้องการลบข้อมูล ใช่หรือไม่?')"/>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:ImageButton ID="imbgvFeedNutrientAdd" runat="server" ImageUrl="~/Images/save2.png" OnClick="imbgvFeedNutrientAdd_Click" />
                                </FooterTemplate>
                            <HeaderStyle Width="60px" />
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                            <FooterStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ลำดับ">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate> 
                            <EditItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </EditItemTemplate> 
                            <HeaderStyle HorizontalAlign="Center" Width="50px" />
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="สารอาหาร" SortExpression="NUTRIENTNAME">
                            <ItemTemplate>
                                <asp:Label ID="lblNUTRIENTNAME" runat="server" Text='<%# Bind("NUTRIENTNAME") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="cmbNUTRIENTNAMEEdit" runat="server" CssClass="zComboBox" Width="165px"></asp:DropDownList>
                                <asp:Label ID="lblNUTRIENTNAMEAdd1" runat="server" Text="*" ForeColor="red"></asp:Label>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:DropDownList ID="cmbNUTRIENTNAMEAdd" runat="server" CssClass="zComboBox" Width="165px" />
                                <asp:Label ID="lblNUTRIENTNAMEAdd" runat="server" Text="*" ForeColor="red"></asp:Label>
                            </FooterTemplate>
                            <FooterStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" Width="180px" />
                            <ItemStyle HorizontalAlign="Left" Width="180px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ปริมาณ">
                            <ItemTemplate>
                                <asp:Label ID="lblQTY" runat="server" Text='<%# Bind("QTY") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtQTYEdit" runat="server" CssClass="zTextboxR"  Width="100px"></asp:TextBox>
                                <asp:Label ID="lblQTYAdd1" runat="server" Text="*" ForeColor="red"></asp:Label>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtQTYAdd" runat="server" CssClass="zTextboxR" Width="100px" />
                                <asp:Label ID="lblQTYAdd" runat="server" Text="*" ForeColor="red"></asp:Label>
                            </FooterTemplate>
                            <FooterStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" Width="120px" />
                            <ItemStyle HorizontalAlign="Right" Width="120px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="UNITNAME" HeaderText="หน่วยนับ" ReadOnly="True" HeaderStyle-Width="120px" ItemStyle-Width="120px">      
                        </asp:BoundField>
                        <asp:BoundField DataField="NUTRIENTLOID" HeaderText="NUTRIENTLOID" ReadOnly="True">
                                                        <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="QTY" HeaderText="QTY" ReadOnly="True">
                                                        <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="UNITLOID" HeaderText="UNITLOID" ReadOnly="True">
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
</asp:Content>

