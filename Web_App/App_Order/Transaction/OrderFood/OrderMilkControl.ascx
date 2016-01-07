<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OrderMilkControl.ascx.cs" Inherits="App_Order_Transaction_OrderFood_OrderMilkControl" %>
<%@ Register Src="../../../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc2" %>
<%@ Register Src="../../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<cc1:ModalPopupExtender ID="popupOrder"  runat="server" PopupControlID="pnlOrder" BackgroundCssClass="modalBackground" DropShadow="true" TargetControlID="btntest" ></cc1:ModalPopupExtender>
<asp:Panel ID="pnlOrder" runat="server" CssClass="modalPopupSearch" style="display:none">
    <table border="0" cellspacing="0" cellpadding="0" width="100%" >
        <tr>
            <td class="headtext">
                <asp:Label ID="lblHead" CssClass="headtext" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbSave" runat="server" ToobarTitle="บันทึก" ToolbarImage="../../Images/save2.png" OnClick="tbSaveClick" />
                <uc1:ToolBarItemCtl ID="tbCancel" runat="server" ToobarTitle="ยกเลิกการแก้ไข" ToolbarImage="../../Images/cancel.png" OnClick="tbCancelClick" />
                <uc1:ToolBarItemCtl ID="tbBack" runat="server" ToobarTitle="กลับหน้ารายการ" ToolbarImage="../../Images/icn_back.png" />
                <uc1:ToolBarItemCtl ID="tbDiscontinue" runat="server" ToobarTitle="Discontinue" ToolbarImage="../../Images/icn_cancel.png" OnClick="tbDiscontinueClick" />
            </td>
        </tr>
        <tr>
            <td style="height:30px;" valign="top">
                <hr style="size:1px" />
                <asp:Label ID="lbStatus" runat="server" EnableViewState="False"></asp:Label>
                <asp:TextBox ID="txtLOID" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
                <asp:TextBox ID="txtWard" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
                <asp:TextBox ID="txtStatus" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
                <asp:TextBox ID="txtAdmitPatient" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
                <asp:TextBox ID="txtIsView" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
                <asp:TextBox ID="txtIsDoctor" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="700">
                    <tr style="height:24px">
                        <td colspan="2" style="padding-right: 10px" align="right">
                            <div style="width:190px; text-align:left"><asp:RadioButton ID="rdoOwnerS" runat="server" Text="นมของโรงพยาบาล" GroupName="OWNER" /></div>
                        </td>
                        <td colspan="3">
                            <asp:DropDownList ID="cmbMilkCategory" runat="server" CssClass="zComboBox" Width="200px"></asp:DropDownList>
                            &nbsp;
                        </td>
                    </tr>
                    <tr style="height: 24px">
                        <td colspan="2" style="padding-right: 10px" align="right">
                            <div style="width:190px; text-align:left"><asp:RadioButton ID="rdoOwnerM" runat="server" Text="นมเฉพาะโรคที่ต้องนำมาเอง" GroupName="OWNER" />
                            &nbsp;&nbsp;ยี่ห้อ</div></td>
                        <td colspan="3">
                            <asp:TextBox ID="txtOwnerText" runat="server" CssClass="zTextbox" Width="400px" MaxLength="200"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                                            <td style="width:75px; padding-right:10px" align="right"></td>
                        <td style="width:75px; padding-right:10px" align="right">พลังงาน : </td>
                        <td style="width:200px;" align="left"> <asp:TextBox ID="txtEnergy" runat="server" CssClass="zTextboxR" Width="75px"></asp:TextBox>
                                &nbsp;Kcal/Oz&nbsp;<asp:Label ID="lblEnergy" ForeColor="Red" runat="server" Text="*"></asp:Label></td>
                        <td align="right" style="padding-right: 10px; width: 150px">
                            Body Weight :</td>
                        <td >
                        <asp:TextBox ID="txtWeight" runat="server" CssClass="zTextboxR" Width="75px"></asp:TextBox> KG.
                        </td>
                    </tr>
                    <tr style="height:24px;">
                    <td style="width:75px; padding-right:10px" align="right"></td>
                        <td style="width:75px; padding-right:10px" align="right">
                            ปริมาณ :
                        </td>
                        <td style="width:200px;" align="left">
                            <asp:TextBox ID="txtVolumn" runat="server" CssClass="zTextboxR" Width="75px"></asp:TextBox>
                            cc/มื้อ&nbsp;<asp:Label ID="lblVolumn" ForeColor="Red" runat="server" Text="*"></asp:Label>&nbsp;
                        </td>
                        <td align="right" style="padding-right: 10px; width: 150px">
                            จำนวนมื้อ :</td>
                        <td >
                            <asp:DropDownList ID="cmbMealQty" runat="server" CssClass="zComboBox" Width="50px" OnSelectedIndexChanged="cmbMealQty_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            <asp:Label ID="lblMeal" ForeColor="Red" runat="server" Text="*"></asp:Label>
                            <asp:Button ID="imbTime" runat="server" Width="50px" Text="TIME" Visible="false" CssClass="zButton" OnClick="imbTime_Click" />
                        </td>
                    </tr> 
                   
                    </tr>
                    <tr>
                        <td align="right" style="padding-right: 10px; width: 150px">
                        </td>
                        <td colspan="4">
                            <table border="0" cellpadding="0" cellspacing="0" width="506px">
                                <tr>
                                    <td style="padding:5px; border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid;">
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%" >
                                            <tr>
                                                <td>
                                                    <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CssClass="t_tablestyle" DataKeyNames="DISEASECATEGORY" DataSourceID="DiseaseCategorySource" OnRowDataBound="gvMain_RowDataBound">
                                                        <Columns>
                                                            <asp:BoundField DataField="DISEASECATEGORY" HeaderText="DISEASECATEGORY">
                                                                <ControlStyle CssClass="zHidden" />
                                                                <FooterStyle CssClass="zHidden" />
                                                                <HeaderStyle CssClass="zHidden" />
                                                                <ItemStyle CssClass="zHidden" />
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="ลำดับ" SortExpression="DEFAULT">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex+1 %>
                                                                </ItemTemplate> 
                                                                <HeaderStyle Width="50px" />
                                                                <ItemStyle HorizontalAlign="Center" Width="50px" Height="20px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="DISEASECATEGORYNAME" HeaderText="อาหารเสริม" SortExpression="DISEASECATEGORYNAME">
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="ปริมาณ">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtQty" CssClass="zTextboxR" Width="75px" runat="server" Text='<%# Convert.ToDouble(Eval("QTY")).ToString("#,##0.00") %>' OnTextChanged="txtQty_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                </ItemTemplate>
                                                                <HeaderStyle Width="80px" />
                                                                <ItemStyle HorizontalAlign="Right" Width="80px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="UNITNAME" HeaderText="หน่วย" SortExpression="UNITNAME">
                                                                <HeaderStyle Width="80px" />
                                                                <ItemStyle Width="80px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="UNIT" HeaderText="UNIT">
                                                                <ControlStyle CssClass="zHidden" />
                                                                <FooterStyle CssClass="zHidden" />
                                                                <HeaderStyle CssClass="zHidden" />
                                                                <ItemStyle CssClass="zHidden" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="ISHIGH" HeaderText="ISHIGH">
                                                                <ControlStyle CssClass="zHidden" />
                                                                <FooterStyle CssClass="zHidden" />
                                                                <HeaderStyle CssClass="zHidden" />
                                                                <ItemStyle CssClass="zHidden" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="ISLOW" HeaderText="ISLOW">
                                                                <ControlStyle CssClass="zHidden" />
                                                                <FooterStyle CssClass="zHidden" />
                                                                <HeaderStyle CssClass="zHidden" />
                                                                <ItemStyle CssClass="zHidden" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="ISNON" HeaderText="ISNON">
                                                                <ControlStyle CssClass="zHidden" />
                                                                <FooterStyle CssClass="zHidden" />
                                                                <HeaderStyle CssClass="zHidden" />
                                                                <ItemStyle CssClass="zHidden" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="ISSPIN" HeaderText="ISSPIN">
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
                                                    <asp:ObjectDataSource ID="DiseaseCategorySource" runat="server" DeleteMethod="DeleteDiseaseCategory"
                                                        SelectMethod="GetDiseaseCategoryList" TypeName="OrderFoodDetailItem">
                                                        <DeleteParameters>
                                                            <asp:Parameter Name="DISEASECATEGORY" Type="Double" />
                                                        </DeleteParameters>
                                                        <SelectParameters>
                                                            <asp:ControlParameter ControlID="txtLOID" DefaultValue="0" Name="refLOID" PropertyName="Text"
                                                                Type="Double" />
                                                            <asp:Parameter DefaultValue="ORDERMILK" Name="refTable" Type="String" />
                                                        </SelectParameters>
                                                    </asp:ObjectDataSource>
                                                    
                                                </td>
                                            </tr> 
                                        </table>
                                    </td> 
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr style="height: 24px">
                        <td align="right" valign="middle" ><asp:CheckBox ID="chkIsSpin" runat="server" Enabled="false" Text="ปั่น" /></td>
                        <td colspan="3" >
                            <uc1:ToolBarItemCtl ID="tbCalculateEnergy" runat="server" ToobarTitle="คำนวณพลังงานรวม" ToolbarImage="../../Images/icn_calculate.png" />
                            <asp:TextBox ID="txtEnergyTotal" runat="server" CssClass="zTextboxR-View" Width="75px"></asp:TextBox>
                            Kcal/วัน
                        </td>
                        <td >
                            <asp:TextBox ID="txtEnergyMeal" runat="server" CssClass="zTextboxR-View" Width="75px"></asp:TextBox>
                            Kcal/KG/วัน
                        </td>
                    </tr>
                     <tr style="height: 24px">
                        <td align="right" style="padding-right: 10px; width: 150px" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" width="100px">
                                <tr style="height:24px"><td>เวลา :</td></tr>
                            </table>
                        </td>
                        <td colspan="4">
                            <table border="0" cellspacing="0" cellpadding="0" width="325px">
                                <tr style="height:22px">
                                    <td style="width:25px"><asp:CheckBox ID="chkTime06" runat="server" Text="6" /></td> 
                                    <td style="width:25px"><asp:CheckBox ID="chkTime07" runat="server" Text="7" /></td> 
                                    <td style="width:25px"><asp:CheckBox ID="chkTime08" runat="server" Text="8" /></td> 
                                    <td style="width:25px"><asp:CheckBox ID="chkTime09" runat="server" Text="9" /></td> 
                                    <td style="width:25px"><asp:CheckBox ID="chkTime10" runat="server" Text="10" /></td> 
                                    <td style="width:25px"><asp:CheckBox ID="chkTime11" runat="server" Text="11" /></td> 
                                    <td style="width:25px"></td>
                                </tr>
                                <tr style="height:22px">
                                    <td style="width:25px"><asp:CheckBox ID="chkTime12" runat="server" Text="12" /></td> 
                                    <td style="width:25px"><asp:CheckBox ID="chkTime13" runat="server" Text="13" /></td> 
                                    <td style="width:25px"><asp:CheckBox ID="chkTime14" runat="server" Text="14" /></td> 
                                    <td style="width:25px"><asp:CheckBox ID="chkTime15" runat="server" Text="15" /></td> 
                                    <td style="width:25px"><asp:CheckBox ID="chkTime16" runat="server" Text="16" /></td> 
                                    <td style="width:25px"><asp:CheckBox ID="chkTime17" runat="server" Text="17" /></td> 
                                    <td style="width:25px"></td>
                                </tr>
                                <tr style="height:22px">
                                    <td style="width:25px"><asp:CheckBox ID="chkTime18" runat="server" Text="18" /></td> 
                                    <td style="width:25px"><asp:CheckBox ID="chkTime19" runat="server" Text="19" /></td> 
                                    <td style="width:25px"><asp:CheckBox ID="chkTime20" runat="server" Text="20" /></td> 
                                    <td style="width:25px"><asp:CheckBox ID="chkTime21" runat="server" Text="21" /></td> 
                                    <td style="width:25px"><asp:CheckBox ID="chkTime22" runat="server" Text="22" /></td> 
                                    <td style="width:25px"><asp:CheckBox ID="chkTime23" runat="server" Text="23" /></td> 
                                    <td style="width:25px"></td>
                                </tr>
                                <tr style="height:22px">
                                    <td style="width:25px"><asp:CheckBox ID="chkTime24" runat="server" Text="24" /></td> 
                                    <td style="width:25px"><asp:CheckBox ID="chkTime01" runat="server" Text="1" /></td> 
                                    <td style="width:25px"><asp:CheckBox ID="chkTime02" runat="server" Text="2" /></td> 
                                    <td style="width:25px"><asp:CheckBox ID="chkTime03" runat="server" Text="3" /></td> 
                                    <td style="width:25px"><asp:CheckBox ID="chkTime04" runat="server" Text="4" /></td> 
                                    <td style="width:25px"><asp:CheckBox ID="chkTime05" runat="server" Text="5" /></td> 
                                    <td style="width:25px"></td>
                                </tr>
                            </table>
                        </td>
                    <tr style="height:24px">
                        <td style="width:150px; padding-right:10px" align="right">เริ่ม :
                        </td>
                        <td colspan="4">
                            <uc2:CalendarControl ID="ctlFirstDate" runat="server" /><uc2:CalendarControl ID="ctlFirstDateRegis" Visible="false" runat="server" />
                            &nbsp; เวลา&nbsp;
                            <asp:DropDownList ID="cmbFirstTime" runat="server" CssClass="zComboBox" Width="80px">
                                <asp:ListItem Text="" Value=""></asp:ListItem>
                                <asp:ListItem Text="01.00 น." Value="1"></asp:ListItem>
                                <asp:ListItem Text="02.00 น." Value="2"></asp:ListItem>
                                <asp:ListItem Text="03.00 น." Value="3"></asp:ListItem>
                                <asp:ListItem Text="04.00 น." Value="4"></asp:ListItem>
                                <asp:ListItem Text="05.00 น." Value="5"></asp:ListItem>
                                <asp:ListItem Text="06.00 น." Value="6"></asp:ListItem>
                                <asp:ListItem Text="07.00 น." Value="7"></asp:ListItem>
                                <asp:ListItem Text="08.00 น." Value="8"></asp:ListItem>
                                <asp:ListItem Text="09.00 น." Value="9"></asp:ListItem>
                                <asp:ListItem Text="10.00 น." Value="10"></asp:ListItem>
                                <asp:ListItem Text="11.00 น." Value="11"></asp:ListItem>
                                <asp:ListItem Text="12.00 น." Value="12"></asp:ListItem>
                                <asp:ListItem Text="13.00 น." Value="13"></asp:ListItem>
                                <asp:ListItem Text="14.00 น." Value="14"></asp:ListItem>
                                <asp:ListItem Text="15.00 น." Value="15"></asp:ListItem>
                                <asp:ListItem Text="16.00 น." Value="16"></asp:ListItem>
                                <asp:ListItem Text="17.00 น." Value="17"></asp:ListItem>
                                <asp:ListItem Text="18.00 น." Value="18"></asp:ListItem>
                                <asp:ListItem Text="19.00 น." Value="19"></asp:ListItem>
                                <asp:ListItem Text="20.00 น." Value="20"></asp:ListItem>
                                <asp:ListItem Text="21.00 น." Value="21"></asp:ListItem>
                                <asp:ListItem Text="22.00 น." Value="22"></asp:ListItem>
                                <asp:ListItem Text="23.00 น." Value="23"></asp:ListItem>
                                <asp:ListItem Text="24.00 น." Value="24"></asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;<asp:Label ID="lblDate" ForeColor="Red" runat="server" Text="*"></asp:Label><asp:TextBox ID="txtFirstTimeRegis" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
                        </td>
                    </tr> 
                    <tr style="height:24px">
                        <td style="width:150px; padding-right:10px" align="right">ถึง :
                        </td>
                        <td colspan="4">
                            <uc2:CalendarControl ID="ctlEndDate" runat="server" />
                            &nbsp; เวลา&nbsp;
                            <asp:DropDownList ID="cmbEndTime" runat="server" CssClass="zComboBox" Width="80px">
                                <asp:ListItem Text="" Value=""></asp:ListItem>
                                <asp:ListItem Text="01.00 น." Value="1"></asp:ListItem>
                                <asp:ListItem Text="02.00 น." Value="2"></asp:ListItem>
                                <asp:ListItem Text="03.00 น." Value="3"></asp:ListItem>
                                <asp:ListItem Text="04.00 น." Value="4"></asp:ListItem>
                                <asp:ListItem Text="05.00 น." Value="5"></asp:ListItem>
                                <asp:ListItem Text="06.00 น." Value="6"></asp:ListItem>
                                <asp:ListItem Text="07.00 น." Value="7"></asp:ListItem>
                                <asp:ListItem Text="08.00 น." Value="8"></asp:ListItem>
                                <asp:ListItem Text="09.00 น." Value="9"></asp:ListItem>
                                <asp:ListItem Text="10.00 น." Value="10"></asp:ListItem>
                                <asp:ListItem Text="11.00 น." Value="11"></asp:ListItem>
                                <asp:ListItem Text="12.00 น." Value="12"></asp:ListItem>
                                <asp:ListItem Text="13.00 น." Value="13"></asp:ListItem>
                                <asp:ListItem Text="14.00 น." Value="14"></asp:ListItem>
                                <asp:ListItem Text="15.00 น." Value="15"></asp:ListItem>
                                <asp:ListItem Text="16.00 น." Value="16"></asp:ListItem>
                                <asp:ListItem Text="17.00 น." Value="17"></asp:ListItem>
                                <asp:ListItem Text="18.00 น." Value="18"></asp:ListItem>
                                <asp:ListItem Text="19.00 น." Value="19"></asp:ListItem>
                                <asp:ListItem Text="20.00 น." Value="20"></asp:ListItem>
                                <asp:ListItem Text="21.00 น." Value="21"></asp:ListItem>
                                <asp:ListItem Text="22.00 น." Value="22"></asp:ListItem>
                                <asp:ListItem Text="23.00 น." Value="23"></asp:ListItem>
                                <asp:ListItem Text="24.00 น." Value="24"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr> 
                    <tr style="height: 3px">
                        <td align="right" style="padding-right: 10px; width: 150px"></td>
                        <td style="width: 100px">
                        </td>
                        <td style="width:70px">
                        </td>
                        <td align="right" style="width: 50px"></td>
                        <td style="width: 330px">
                        </td>
                    </tr>
                    <tr style="height: 3px">
                        <td align="right" style="padding-right: 10px; width: 150px"></td>
                        <td style="width: 100px">
                        </td>
                        <td style="width:70px">
                        </td>
                        <td align="right" style="width: 50px"></td>
                        <td style="width: 330px">
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="padding-right: 10px; width: 150px"valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" width="100px">
                                <tr style="height:24px">
                                    <td align="right">หมายเหตุ :</td> 
                                </tr>
                            </table>
                        </td>
                        <td colspan="4">
                            <asp:TextBox ID="txtRemarks" runat="server" CssClass="zTextbox" Width="500px" TextMode="multiline" Height="60px" MaxLength="200"></asp:TextBox>
                        </td>
                    </tr>
                </table> 
            </td>
        </tr>
    </table>
</asp:Panel>
<asp:Button ID="btntest" runat="server" Text="test" CssClass="zHidden" />