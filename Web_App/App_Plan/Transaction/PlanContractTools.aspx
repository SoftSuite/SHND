<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="PlanContractTools.aspx.cs" Inherits="App_Plan_Transaction_PlanContractTools" Title="SHND : Transaction - Tools Order Contract" %>
<%@ Register Src="../../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="headtext">������Ἱ����ҳ�����ʴ��ػ�ó����ѭ��</td>
        </tr>
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbSave" runat="server" ToobarTitle="�ѹ�֡������" ToolbarImage="../../Images/save2.png" OnClick="tbSaveClick" />
                <uc1:ToolBarItemCtl ID="tbCancel" runat="server" ToobarTitle="¡��ԡ������" ToolbarImage="../../Images/cancel.png" OnClick="tbCancelClick" />
                <uc1:ToolBarItemCtl ID="tbBack" runat="server" ToobarTitle="��Ѻ˹����¡��" ToolbarImage="../../Images/icn_back.png" OnClick="tbBackClick" />
                <uc1:ToolBarItemCtl ID="tbApprove" runat="server" ToobarTitle="�׹�ѹ" ToolbarImage="../../Images/icn_approve.png" OnClick="tbApproveClick" />
            </td>
        </tr>
        <tr>
            <td style="height:30px">
                <hr style="size:1px" />
                <asp:Label ID="lbStatus" runat="server" EnableViewState="False"></asp:Label>
                <asp:TextBox ID="txtLOID" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
                <asp:TextBox ID="txtStatus" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
                <asp:TextBox ID="txtCurentTab" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr style="height:24px">
                        <td style="padding:5px; border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid; width:400px" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" width="500">
                                <tr style="height:24px">
                                    <td style="width:130px; padding-right:10px; text-align:right">
                                        �Ţ���Ἱ����ҳ��� :</td>
                                    <td style="width:150px">
                                        <asp:TextBox ID="txtCode" runat="server" CssClass="zTextbox-View" ReadOnly="True" Width="100px"></asp:TextBox></td>
                                    <td style="width:50px"></td>
                                    <td>
                                        <asp:DropDownList ID="cmbMaterialClass" runat="server" Visible="False">
                                        </asp:DropDownList></td>  
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 130px; height: 24px; text-align: right">
                                        ����Ἱ����ҳ��� :</td>
                                    <td colspan="3" style="height: 24px">
                                        <asp:TextBox ID="txtName" runat="server" CssClass="zTextbox-View" Width="310px" MaxLength="100" ReadOnly="True"></asp:TextBox></td>
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 130px; text-align: right">
                                        �է�����ҳ :</td>
                                    <td style="width: 150px;">
                                        <asp:TextBox ID="txtBudgetYear" runat="server" CssClass="zTextboxR-View" Width="100px" MaxLength="4" ReadOnly="True"></asp:TextBox></td>
                                    <td style="width: 50px; padding-right: 10px; text-align: right">
                                        </td>
                                    <td>
                                        </td>
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 130px; text-align: right">
                                        ��ǧ���ҷ���� :</td>
                                    <td style="width: 150px">
                                        <uc2:CalendarControl ID="ctlStartDate" runat="server" Enabled="false" />
                                    </td>
                                    <td style="width: 50px" align="center">
                                        �֧</td>
                                    <td>
                                        <uc2:CalendarControl ID="ctlEndDate" runat="server" Enabled="false" />
                                    </td>
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 130px; text-align: right">
                                        ��Ǵ��ʴ� :</td>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtClassName" runat="server" CssClass="zTextbox-View" MaxLength="100"
                                            ReadOnly="True" Width="310px"></asp:TextBox></td>
                                </tr>
                            </table>
                        </td>
                        <td style="width:4px">&nbsp;</td>
                        <td style="border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid;" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td style="border-bottom: 1px solid; padding:5px;">
                                        <table border="0" cellpadding="0" cellspacing="0" width="550px">
                                            <tr style="height:24px">
                                                <td style="width:130px; padding-right:10px; text-align:right">ʶҹ� :
                                                </td> 
                                                <td>
                                                    <asp:TextBox ID="txtStatusName" runat="server" CssClass="zTextbox-View" ReadOnly="True" Width="150px"></asp:TextBox>
                                                </td> 
                                            </tr>
                                        </table>
                                    </td> 
                                </tr>
                                <tr>
                                    <td style="padding:5px;">
                                        <table border="0" cellpadding="0" cellspacing="0" width="550px">
                                            <tr style="height:24px">
                                                <td style="width:130px; padding-right:10px; text-align:right">�Ţ���㺢�͹��ѵ� :</td> 
                                                <td>
                                                    <asp:TextBox ID="txtQtCode" runat="server" CssClass="zTextbox-View" Width="150px" MaxLength="20" ReadOnly="True"></asp:TextBox>
                                                </td> 
                                            </tr>
                                            <tr style="height:24px">
                                                <td style="width:130px; padding-right:10px; text-align:right">����㺢ͫ���/�ͨ�ҧ :</td> 
                                                <td>
                                                    <asp:TextBox ID="txtRefPRSap" runat="server" CssClass="zTextbox-View" Width="150px" MaxLength="20" ReadOnly="True"></asp:TextBox>
                                                </td> 
                                            </tr>
                                        </table>
                                    </td> 
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table> 
            </td>
        </tr>
        <tr style="height:5px">
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvMaterial" runat="server" AutoGenerateColumns="False" CssClass="t_tablestyle" OnRowDataBound="gvMaterial_RowDataBound" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="LOID" HeaderText="LOID">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="MATERIALMASTER" HeaderText="MATERIALMASTER">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="�ӴѺ">
                            <ItemTemplate>
                                <%# Container.DataItemIndex +1 %>
                            </ItemTemplate>
                            <HeaderStyle Width="50px" />
                            <ItemStyle HorizontalAlign="Center" Width="50px" Height="24px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="���� SAP">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkCode" runat="server" Text='<%# Bind("SAPCODE") %>' CommandArgument='<%# Bind("LOID") %>' OnClick="lnkCode_Click"></asp:LinkButton> 
                            </ItemTemplate>
                            <ItemStyle Width="80px" HorizontalAlign="Center" />
                            <HeaderStyle Width="80px" />  
                        </asp:TemplateField>
                        <asp:BoundField DataField="MATERIALNAME" HeaderText="��¡��">
                        </asp:BoundField>
                        <asp:BoundField DataField="UNITNAME" HeaderText="˹��¹Ѻ">
                            <ItemStyle Width="70px" />
                            <HeaderStyle Width="70px" /> 
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="�Ҥ�/˹���<br>�������">
                            <ItemTemplate>
                                <asp:TextBox ID="txtPrice" runat="server" Width="95px" Text='<%# Convert.ToDouble(Eval("PRICE")).ToString("#,##0.00") %>' 
                                    CssClass='<%# (Convert.ToString(Eval("STATUS")) == "DA") ? "zTextboxR" : "zTextboxR-View" %>' 
                                    ReadOnly='<%# Convert.ToString(Eval("STATUS")) != "DA" %>'
                                    onkeypress="ChkDbl(this)" onblur="valDbl(this)" onfocus="prepareNum(this)" ></asp:TextBox> 
                            </ItemTemplate>
                            <ItemStyle Width="100px" HorizontalAlign="Right" />
                            <HeaderStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="V">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkVat" runat="server" Checked='<%# Convert.ToString(Eval("ISVAT")) == "Y" %>' Enabled='<%# (Convert.ToString(Eval("STATUS")) == "DA") %>' />
                            </ItemTemplate>
                            <ItemStyle Width="20px" HorizontalAlign="Center" />
                            <HeaderStyle Width="20px" />  
                        </asp:TemplateField>
                        <asp:BoundField DataField="PLANQTY" HeaderText="����ҳ���" HtmlEncode="False" DataFormatString="{0:#,##0.00}">
                            <ItemStyle Width="60px" HorizontalAlign="Right" />
                            <HeaderStyle Width="60px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TOTALPRICE" HeaderText="������Թ<br>�������" HtmlEncode="False" DataFormatString="{0:#,##0.00}">
                            <ItemStyle Width="100px" HorizontalAlign="Right" />
                            <HeaderStyle Width="100px" />
                        </asp:BoundField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkDetail" Text="��������´" runat="server" CommandArgument='<%# Bind("LOID") %>'  OnClick="lnkDetail_Click" Visible='<%# Convert.ToString(Eval("STATUS")) != "WA" %>'></asp:LinkButton> 
                            </ItemTemplate>
                            <ItemStyle Width="70px" HorizontalAlign="Center" />
                            <HeaderStyle Width="70px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="���ͺ���ѷ����˹���">
                            <ItemTemplate>
                                <asp:DropDownList ID="cmbSupplier" runat="server" CssClass="zComboBox" Width="195px" >
                                </asp:DropDownList>
                            </ItemTemplate>
                            <ItemStyle Width="200px" HorizontalAlign="Right" />
                            <HeaderStyle Width="200px" />  
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="�Ţ����ѭ��">
                            <ItemTemplate>
                                <asp:TextBox ID="txtContractCode" runat="server" Width="95px" Text='<%# Eval("CONTRACTCODE") %>'  MaxLength="20"
                                    CssClass='<%# (Convert.ToString(Eval("STATUS")) == "DA") ? "zTextbox" : "zTextbox-View" %>' 
                                    ReadOnly='<%# Convert.ToString(Eval("STATUS")) != "DA" %>' ></asp:TextBox> 
                            </ItemTemplate>
                            <ItemStyle Width="100px" HorizontalAlign="Right" />
                            <HeaderStyle Width="100px" />  
                        </asp:TemplateField>
                        <asp:BoundField DataField="SAPCODE" HeaderText="SAPCODE">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SPEC" HeaderText="SPEC">
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
                        <asp:BoundField DataField="STATUS" HeaderText="STATUS">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SUPPLIER" HeaderText="SUPPLIER">
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
            </td>
        </tr>
    </table>
    <asp:TextBox ID="txtRowIndex" runat="server" Visible="false"></asp:TextBox>
    <cc1:ModalPopupExtender ID="ctlSpecPopup"  runat="server" PopupControlID="pnlSpec" BackgroundCssClass="modalBackground" DropShadow="true" TargetControlID="btnTest"></cc1:ModalPopupExtender>
    <asp:Panel ID="pnlSpec" runat="server" CssClass="modalPopup" style="display:none" >
        <table border="0" cellspacing="0" cellpadding="0" width="500">
            <tr>
                <td class="subheadertext">
                    <asp:Label ID="lblMaterialName" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <uc1:ToolBarItemCtl ID="tbSaveSpec" runat="server" ToobarTitle="�ѹ�֡������" ToolbarImage="../../Images/save2.png" OnClick="tbSaveSpecClick" />
                    <uc1:ToolBarItemCtl ID="tbBackSpec" runat="server" ToobarTitle="��Ѻ˹����¡��" ToolbarImage="../../Images/icn_back.png" />
                </td>
            </tr>
            <tr>
                <td><hr style="size:1px"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtSpec" runat="server" TextMode="MultiLine" Width="500px" Height="80px" MaxLength="200" CssClass="zTextbox"></asp:TextBox>
                </td> 
            </tr>
        </table>
    </asp:Panel>
    <asp:Button ID="btntest" runat="server" Text="test" CssClass="zHidden" />
    <cc1:ModalPopupExtender ID="ctlDetailPopup"  runat="server" PopupControlID="pnlDetail" BackgroundCssClass="modalBackground" DropShadow="true" TargetControlID="btnTest1"></cc1:ModalPopupExtender>
    <asp:Panel ID="pnlDetail" runat="server" CssClass="modalPopup" style="display:none" >
        <table border="0" cellspacing="0" cellpadding="0" width="550">
            <tr>
                <td class="subheadertext">
                    <asp:Label ID="lblMaterialNameDetail" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <uc1:ToolBarItemCtl ID="tbBackDetail" runat="server" ToobarTitle="��Ѻ˹����¡��" ToolbarImage="../../Images/icn_back.png"/>
                    <asp:TextBox ID="txtMaterialID" runat="server" Visible="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td><hr style="size:1px"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtSpecView" runat="server" TextMode="MultiLine" Width="550px" Height="80px" MaxLength="200" CssClass="zTextbox-View" ReadOnly="true"></asp:TextBox>
                </td> 
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gvDetail" runat="server" AutoGenerateColumns="False" CssClass="t_tablestyle" DataSourceID="DetailSource" DataKeyNames="DIVISION" Width="100%">
                        <Columns>
                            <asp:BoundField DataField="DIVISION" HeaderText="DIVISION">
                                <ControlStyle CssClass="zHidden" />
                                <FooterStyle CssClass="zHidden" />
                                <HeaderStyle CssClass="zHidden" />
                                <ItemStyle CssClass="zHidden" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="�ӴѺ">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex +1 %>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <%# Container.DataItemIndex +1 %>
                                </EditItemTemplate>
                                <HeaderStyle Width="50px" />
                                <ItemStyle HorizontalAlign="Center" Width="50px" Height="24px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="DIVISIONNAME" HeaderText="˹��§ҹ" ReadOnly="True">
                            </asp:BoundField>
                            <asp:BoundField DataField="REQQTY" HeaderText="��ͧ���" HtmlEncode="False" DataFormatString="{0:#,##0.00}" ReadOnly="True">
                                <ItemStyle Width="80px" HorizontalAlign="Right" />
                                <HeaderStyle Width="80px" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="����ҳ���">
                                <ItemTemplate>
                                    <asp:Label ID="lblAdjQty" runat="server" Text='<%# Convert.ToDouble(Eval("ADJQTY")).ToString("#,##0.00")  %>' ></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtAdjQty" runat="server" Width="95px" Text='<%# Convert.ToDouble(Eval("ADJQTY")).ToString("#,##0.00")  %>' 
                                        CssClass='<%# Convert.ToString(Eval("STATUS")) == "DA" ? "zTextboxR" : "zTextboxR-View" %>' 
                                        ReadOnly='<%# Convert.ToString(Eval("STATUS")) != "DA" %>'
                                        onkeypress="ChkDbl(this)" onblur="valDbl(this)" onfocus="prepareNum(this)" ></asp:TextBox> 
                                </EditItemTemplate> 
                                <ItemStyle Width="100px" HorizontalAlign="Right"/>
                                <HeaderStyle Width="100px" />  
                            </asp:TemplateField>
                            <asp:BoundField DataField="MATERIALMASTER" HeaderText="MATERIALMASTER">
                                <ControlStyle CssClass="zHidden" />
                                <FooterStyle CssClass="zHidden" />
                                <HeaderStyle CssClass="zHidden" />
                                <ItemStyle CssClass="zHidden" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DIVISION" HeaderText="DIVISION">
                                <ControlStyle CssClass="zHidden" />
                                <FooterStyle CssClass="zHidden" />
                                <HeaderStyle CssClass="zHidden" />
                                <ItemStyle CssClass="zHidden" />
                            </asp:BoundField>
                            <asp:BoundField DataField="STATUS" HeaderText="STATUS">
                                <ControlStyle CssClass="zHidden" />
                                <FooterStyle CssClass="zHidden" />
                                <HeaderStyle CssClass="zHidden" />
                                <ItemStyle CssClass="zHidden" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PLANQTY" HeaderText="PLANQTY">
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
                    <asp:ObjectDataSource ID="DetailSource" runat="server" SelectMethod="GetToolsDivisionLIst" TypeName="PlanToolsDetailItem" UpdateMethod="UpdateToolsDivision">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="txtLOID" DefaultValue="0" Name="planOrderID" PropertyName="Text" Type="Double" />
                            <asp:ControlParameter ControlID="txtMaterialID" DefaultValue="0" Name="materialMaster" PropertyName="Text" Type="Double" />
                        </SelectParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="planOrderID" Type="Double" />
                            <asp:Parameter Name="MATERIALMASTER" Type="Double" />
                            <asp:Parameter Name="DIVISION" Type="Double" />
                            <asp:Parameter Name="ADJQTY" Type="Double" />
                            <asp:Parameter Name="PLANQTY" Type="Double" />
                            <asp:Parameter Name="STATUS" Type="String" />
                        </UpdateParameters>
                    </asp:ObjectDataSource>
                </td> 
            </tr> 
        </table>
    </asp:Panel>
    <asp:Button ID="btntest1" runat="server" Text="test" CssClass="zHidden" />
</asp:Content>