<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="StockIn.aspx.cs" Inherits="App_Inventory_Transaction_StockIn" Title="SHND : Transaction - Stock in"%>

<%@ Register Src="../../Search/MaterialStockInFoodPopup.ascx" TagName="MaterialStockInFoodPopup" TagPrefix="uc5" %>
<%@ Register Src="../../Search/MaterialStockInToolsPopup.ascx" TagName="MaterialStockInToolsPopup" TagPrefix="uc4" %>
<%@ Register Src="../../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc3" %>
<%@ Register Src="../../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="headtext">
                �Ѻ���</td>
        </tr>
        <tr>
             <td>
                <uc1:ToolBarItemCtl ID="tbSave" runat="server" ToobarTitle="�ѹ�֡"  ToolbarImage="../../Images/save2.png"  onclick="tbSaveClick" />
                <uc1:ToolBarItemCtl ID="tbCancel" runat="server" ToobarTitle="¡��ԡ������"  ToolbarImage="../../Images/cancel.png" OnClick="tbCancelClick" />
                <uc1:ToolBarItemCtl ID="tbCommit" runat="server" ToobarTitle="͹��ѵ�"  ToolbarImage="../../Images/icn_approve.png" OnClick="tbCommitClick" />
                <uc1:ToolBarItemCtl ID="tbBack" runat="server" ToobarTitle="��Ѻ˹����¡��"  ToolbarImage="../../Images/icn_back.png" OnClick="tbBackClick" />
                <uc1:ToolBarItemCtl ID="tbPrint" runat="server" ToobarTitle="�����"  ToolbarImage="../../Images/icn_print.png"  />
            </td>
        </tr>
        <tr>
            <td>
                <hr style="size:1px"/>
            </td>
        </tr>
        <tr>
            <td style="height:15px">
                <asp:Label ID="lbStatus" runat="server" EnableViewState="False"></asp:Label>
                <asp:TextBox ID="txhSortField" runat="server" Visible="False" Width="15px"></asp:TextBox>
                <asp:TextBox ID="txhSortDir" runat="server" Visible="False" Width="15px"></asp:TextBox>
                <asp:TextBox ID="txhID" runat="server" Visible="False" Width="15px"></asp:TextBox>
                <asp:TextBox  ID="txtStatus" runat="server" Visible="False" Width="15px"></asp:TextBox>
                <asp:TextBox ID="txhDocType" runat="server" Visible="False" Width="15px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                 <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td style="padding:5px; border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid; width:620px" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" width="600">
                                <tr style="height:24px">
                                    <td style="width:130px; text-align: right; padding-right:10px; height: 24px;">�Ţ����Ѻ��Ҥ�ѧ :&nbsp;</td>
                                    <td style="width:170px; height: 24px;"><asp:TextBox ID="txtCODE" runat="server" CssClass="zTextbox-View" Width="150px" MaxLength="20" Readonly="True" ></asp:TextBox>
                                    </td>
                                    <td style="width:85px; text-align: right; padding-right:10px; height: 24px;">�ѹ����Ѻ :</td>
                                    <td style="height: 24px; width: 195px;"><uc3:CalendarControl ID="ctlStockInDate" runat="server"  />
                                        &nbsp;<span style="color:red">*</span>
                                    </td> 
                                </tr>
                                <tr style="height:24px">
                                    <td style="width:130px; text-align: right; padding-right:10px; height: 24px;">��ѧ����Ѻ��� :&nbsp;</td>
                                    <td style="width:170px; height: 24px;">
                                        <asp:DropDownList ID="cmbWareHouse" runat="server" CssClass="zComboBox" Width="156px" AutoPostBack="True" ></asp:DropDownList>
                                        <span style="color:red">*</span>
                                    </td>
                                    <td style="width:85px; text-align: right; padding-right:10px; height: 24px;">
                                        <asp:Label ID="lbOrder" runat="server" EnableViewState="true">��ѧ������ :</asp:Label>
                                    </td>
                                    <td style="height: 24px; width: 195px;">
                                        <asp:DropDownList ID="cmbWareHouseOrder" runat="server" CssClass="zComboBox" Width="156px" AutoPostBack="True" ></asp:DropDownList>
                                        <asp:Label ID="lbChk" runat="server" style="color:red" Width="11px">*</asp:Label>
                                    </td>
                                    
                                </tr>
                                <tr>
                                    <td style="width:130px; text-align: right; padding-right:10px; height: 24px;">
                                        <asp:Label ID="lbPlan" runat="server" EnableViewState="true">Ἱ����ҳ��� :</asp:Label>
                                    </td>
                                    <td colspan="3" style="height: 24px">
                                        <asp:DropDownList ID="cmbPlan" runat="server" CssClass="zComboBox" Width="421px" AutoPostBack="True" OnSelectedIndexChanged="cmbPlan_SelectedIndexChanged" ></asp:DropDownList>
                                        <asp:Label ID="lbChkPlan" runat="server" style="color:red" Width="11px">*</asp:Label>
                                    </td>
                                </tr> 
                                <tr>
                                    <td style="width:130px; text-align: right; padding-right:10px; height: 24px;">
                                        <asp:Label ID="lblMaterialClass" runat="server" EnableViewState="true" Visible="false" >��Ǵ����� :</asp:Label>
                                    </td>
                                    <td colspan="3" style="height: 24px">
                                        <asp:DropDownList ID="cmbMaterialClass" runat="server" CssClass="zComboBox" Width="421px" AutoPostBack="True" Visible="false" OnSelectedIndexChanged="cmbMaterialClass_SelectedIndexChanged"  ></asp:DropDownList>
                                        <asp:Label ID="lblChkMaterialClass" runat="server" style="color:red" Width="11px" Visible="false">*</asp:Label>
                                    </td>
                                </tr> 
                            </table> 
                        </td>
                        <td style="width:4px">
                            &nbsp;</td>
                        <td style="border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid; padding:5px" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" width="400">
                                <tr style="height:24px;">
                                    <td style="width:110px; text-align:right; padding-right:10px; height: 24px;">
                                        ����������Ѻ��� :</td> 
                                    <td style="height: 24px">
                                         <asp:TextBox ID="txtTypeRef" runat="server"  Width="150px" MaxLength="20" Readonly="True" CssClass="zTextbox-View" ></asp:TextBox></td> 
                                </tr>
                                <tr style="height:24px;">
                                    <td style="width:110px; text-align:right; padding-right:10px; height: 24px;">
                                        ʶҹ� :</td> 
                                    <td style="height: 24px">
                                        <asp:TextBox ID="txtStatusRef" runat="server"  Width="150px" MaxLength="20" Readonly="True" CssClass="zTextbox-View" ></asp:TextBox></td> 
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>  
            <td class="toolbarplace">
                <asp:Label ID="lbStatusMain" runat="server" EnableViewState="False"></asp:Label>
                <uc1:ToolBarItemCtl ID="tbAddDetail" runat="server" ToobarTitle="������¡��" ToolbarImage="../../Images/icn_add.png" OnClick="tbAddDetailClick"  />
                <uc1:ToolBarItemCtl ID="tdDelDetail" runat="server" ToobarTitle="ź��¡��" ToolbarImage="../../Images/icn_delete.png" ClientClick="return confirm('��ͧ���ź�����ŷ�����͡ ���������?')" OnClick="tdDelDetailClick" />
            </td>
        </tr>
        <tr>
             <td>
              <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CssClass="t_tablestyle"  Width="100%" DataSourceID="StockInSource" OnRowDataBound="gvMain_RowDataBound">
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
                        <asp:TemplateField HeaderText="�ӴѺ" SortExpression="DEFAULT">
                            <ItemTemplate><%# Container.DataItemIndex+1 %>
                            </ItemTemplate>
                            <HeaderStyle Width="40px" />
                            <ItemStyle HorizontalAlign="Center" Width="40px" />
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="����" DataField="MATERIALCODE">
                            <ItemStyle Width="70px" HorizontalAlign="Center"></ItemStyle>
                            <HeaderStyle Width="70px" HorizontalAlign="Center"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="MATERIALNAME" HeaderText="��¡��">
                        </asp:BoundField>
                        <asp:BoundField DataField="UNITNAME" HeaderText="˹��¹Ѻ">
                            <ItemStyle Width="60px"></ItemStyle>
                            <HeaderStyle Width="60px" HorizontalAlign="Center"></HeaderStyle>
                        </asp:BoundField>
                       
                        <asp:TemplateField HeaderText="�Ţ�����觫���" >
                                <ItemTemplate>
                                    <asp:TextBox ID="txtSAPPOCODE" runat="server"  CssClass="zTextbox" Width="75px"  Text='<%# (Convert.IsDBNull(Eval("SAPPOCODE")) ? "" : Eval("SAPPOCODE")) %>'  ></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="80px" HorizontalAlign="Center"/> 
                                <HeaderStyle Width="80px" HorizontalAlign="Center" /> 
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="�ѹ�����觫���" >
                                <ItemTemplate>
                                    <uc3:CalendarControl ID="ctlSAPPODATE" runat="server" DateValue = '<%# Convert.IsDBNull(Eval("SAPPODATE")) ? new DateTime() : Convert.ToDateTime(Eval("SAPPODATE")) %>'/>
                                </ItemTemplate>
                                <ItemStyle Width="140px" HorizontalAlign="center"/> 
                                <HeaderStyle Width="140px" HorizontalAlign="Center" /> 
                            </asp:TemplateField>
                             <asp:BoundField  HeaderText="�ʹ����ҳ���" DataField="PLANQTY" >
                                <ItemStyle Width="90px" HorizontalAlign="Right"/> 
                                <HeaderStyle Width="90px" HorizontalAlign="Center" /> 
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="�ӹǹ����Ѻ" >
                                <ItemTemplate>
                                    <asp:TextBox ID="txtQTY" runat="server" value = "0" CssClass="zTextboxR" Width="75px"  onkeypress=ChkInt(this) onblur="valInt(this)" onfocus="prepareNum(this)" Text='<%# (Convert.IsDBNull(Eval("QTY")) ? "0" : Convert.ToDouble(Eval("QTY")).ToString("#,##0")) %>'   ></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="80px" HorizontalAlign="Right"/> 
                                <HeaderStyle Width="80px" HorizontalAlign="Center" /> 
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="�������" DataField="REMAINQTY"  >
                                <ItemStyle Width="80px" HorizontalAlign="Right"/> 
                                <HeaderStyle Width="80px" HorizontalAlign="Center" /> 
                            </asp:BoundField >
                            <asp:TemplateField HeaderText="���ʤ���ѳ��SAP" >
                                <ItemTemplate>
                                    <asp:TextBox ID="txtLOTNO" runat="server" CssClass="zTextbox" Width="75px"  Text='<%# (Convert.IsDBNull(Eval("LOTNO")) ? "" : Eval("LOTNO")) %>'    ></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="80px" HorizontalAlign="center" /> 
                                <HeaderStyle Width="80px" HorizontalAlign="Center" /> 
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="���������Ѻ��Сѹ(��͹)" >
                                <ItemTemplate>
                                    <asp:TextBox ID="txtGURANTEE" runat="server"  CssClass="zTextboxR" Width="75px"  onkeypress=ChkInt(this) onblur="valInt(this)" onfocus="prepareNum(this)"  Text='<%# (Convert.IsDBNull(Eval("GUARANTEE")) ? "" : Convert.ToDouble(Eval("GUARANTEE")).ToString()) %>' ></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="80px" HorizontalAlign="Right"/> 
                                <HeaderStyle Width="80px" HorizontalAlign="Center" /> 
                            </asp:TemplateField>
                                                        
                        <asp:BoundField DataField="PRICE" HeaderText="PRICE">
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
                        <asp:BoundField DataField="MATERIALMASTER" HeaderText="MATERIALMASTER">
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
                    <asp:ObjectDataSource ID="StockInSource" runat="server" SelectMethod="GetStockInItemList" TypeName="StockInDetailItem"  >
                         <SelectParameters>
                            <asp:ControlParameter PropertyName="Text" Type="Double" DefaultValue="0"  ControlID="txhID" Name="StockInID"></asp:ControlParameter>
                         </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
         </tr>
    </table>
    
<uc4:MaterialStockInToolsPopup ID="ctlMaterialStockinToolsPopup" runat="server" OnSelectedIndexChanged="ctlMaterialStockinToolsPopup_SelectedIndexChanged" />
<uc5:MaterialStockInFoodPopup ID="ctlMaterialStockInFoodPopup" runat="server" OnSelectedIndexChanged="ctlMaterialStockinFoodPopup_SelectedIndexChanged" />

</asp:Content>



