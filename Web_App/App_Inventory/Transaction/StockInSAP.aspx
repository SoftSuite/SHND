<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="StockInSAP.aspx.cs" Inherits="App_Inventory_Transaction_StockInSAP" Title="SHND : Transaction - SAP Stock in"%>


<%@ Register Src="../../Search/MaterialUnitPopup.ascx" TagName="MaterialUnitPopup" TagPrefix="uc4" %>
<%@ Register Src="../../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc3" %>
<%@ Register Src="../../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="headtext">
                �Ѻ��Ҩҡ PO ��к� SAP</td>
        </tr>
        <tr>
             <td>
                <uc1:ToolBarItemCtl ID="tbSave" runat="server" ToobarTitle="�ѹ�֡"  ToolbarImage="../../Images/icn_add.png"  onclick="tbSaveClick" />
                <uc1:ToolBarItemCtl ID="tbCancel" runat="server" ToobarTitle="¡��ԡ������"  ToolbarImage="../../Images/icn_back.png" OnClick="tbCancelClick" />
                <uc1:ToolBarItemCtl ID="tbCommit" runat="server" ToobarTitle="͹��ѵ�"  ToolbarImage="../../Images/icn_approve.png" OnClick="tbCommitClick" />
                <uc1:ToolBarItemCtl ID="tbPrint" runat="server" ToobarTitle="�����"  ToolbarImage="../../Images/icn_print.png" />
                <uc1:ToolBarItemCtl ID="tbBack" runat="server" ToobarTitle="��Ѻ˹����¡��"  ToolbarImage="../../Images/icn_return.png" OnClick="tbBackClick" />
            </td>
        </tr>
        <tr>
            <td>
                <hr size="1" />
                    <asp:TextBox ID="txhSortField" runat="server" Visible="False" Width="15px"></asp:TextBox>
                    <asp:TextBox ID="txhSortDir" runat="server" Visible="False" Width="15px"></asp:TextBox>
                    <asp:TextBox ID="txhID" runat="server" Visible="False" Width="15px"></asp:TextBox>
                    <asp:TextBox  ID="txtStatus" runat="server" Visible="False" Width="15px"></asp:TextBox>
                    <asp:Label ID="lbStatus" runat="server" EnableViewState="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="height: 15px">
                     <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td style="padding:5px; border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid; width:800px" valign="top">
                                <table border="0" cellpadding="0" cellspacing="0" width="800px">
                                    <tr style="height:24px">
                                        <td style="width:120px; text-align: right; padding-right:10px">�Ţ����Ѻ��Ҥ�ѧ
                                        </td>
                                        <td style="width:350px;"><asp:TextBox ID="txtCODE" runat="server" CssClass="zTextbox-View" Width="150px" MaxLength="20" Readonly="True" ></asp:TextBox>
                                        </td>
                                        <td style="width:50px; text-align: right; padding-right:10px">�ѹ����Ѻ 
                                        </td>
                                        <td><uc3:CalendarControl ID="ctlStockInDate" runat="server"  /><span style="color:red">*</span>
                                        </td> 
                                    </tr>
                                    <tr style="height:24px">
                                        <td style="width:120px; text-align: right; padding-right:10px">��ѧ����Ѻ���
                                        </td>
                                        <td style="width:170px;">
                                            <asp:DropDownList ID="cmbWareHouse" runat="server" CssClass="zComboBox" Width="150px" AutoPostBack="True" ></asp:DropDownList><span style="color:red">*</span>
                                        </td>
                                    </tr>
                                    <tr>
                                    <td style="width:120px; text-align: right; padding-right:10px; height: 20px;">Ἱ����ҳ���
                                        </td>
                                        <td style="width:170px; height: 20px;">
                                            <asp:DropDownList ID="cmbPlan" runat="server" CssClass="zComboBox" Width="350px" AutoPostBack="True" ></asp:DropDownList><span style="color:red">*</span>
                                        </td> 
                                    </tr> 
                                    
                                </table> 
                            </td>
                            <td style="width:4px">
                                &nbsp;</td>
                            <td style="border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid; padding:5px" valign="top">
                                <table border="0" cellpadding="0" cellspacing="0" width="235px">
                                    <tr style="height:24px;">
                                        <td style="width:110px; text-align:right; padding-right:10px;">
                                            ����������Ѻ���</td> 
                                        <td>
                                             <asp:TextBox ID="txtTypeRef" runat="server"  Width="100px" MaxLength="20" Readonly="True" CssClass="zTextboxR-View" >�Ѻ��ҨҡPO�SAP</asp:TextBox></td> 
                                    </tr>
                                    <tr style="height:24px;">
                                        <td style="width:110px; text-align:right; padding-right:10px;">
                                            ʶҹ�</td> 
                                        <td>
                                            <asp:TextBox ID="txtStatusRef" runat="server"  Width="100px" MaxLength="20" Readonly="True" CssClass="zTextboxR-View" >���ѧ���ԡ��</asp:TextBox></td> 
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                
                
                </td>
                </tr>
            <tr>
            </tr>
             <tr>
            </tr>
        <tr>  
            <td class="toolbarplace" style="padding:5px; border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid; width:400px" valign="top">
                <asp:Label ID="lbStatusMain" runat="server" EnableViewState="False"></asp:Label>
                <uc1:ToolBarItemCtl ID="tbAddDetail" runat="server" ToobarTitle="����" ToolbarImage="../../Images/icn_add.png" OnClick="tbAddDetailClick"  />
                <uc1:ToolBarItemCtl ID="tdDelDetail" runat="server" ToobarTitle="ź" ToolbarImage="../../Images/icn_delete.png" ClientClick="return confirm('��ͧ���ź�����ŷ�����͡ ���������?')" OnClick="tdDelDetailClick" />
            </td>
        </tr>
        <tr>
             <td>
              <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CssClass="t_tablestyle"  Width="100%" DataSourceID="StockInSource">
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
                            <HeaderStyle Width="60px" />
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="����" DataField="MATERIALCODE">
                            <ItemStyle Width="100px" HorizontalAlign="Center"></ItemStyle>
                            <HeaderStyle Width="100px" HorizontalAlign="Center"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="MATERIALNAME" HeaderText="��¡��">
                            <ItemStyle Width="150px" HorizontalAlign="Left"></ItemStyle>
                            <HeaderStyle Width="150px" HorizontalAlign="Center"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="UNITNAME" HeaderText="˹��¹Ѻ">
                            <ItemStyle Width="100px" HorizontalAlign="Left"></ItemStyle>
                            <HeaderStyle Width="100px" HorizontalAlign="Center"></HeaderStyle>
                        </asp:BoundField>
                       
                        <asp:TemplateField HeaderText="�Ţ�����觫���" >
                                <ItemTemplate>
                                    <asp:TextBox ID="txtSAPPOCODE" runat="server"  CssClass="zTextboxR" Width="50px" MaxLength="10" Text='<%# (Convert.IsDBNull(Eval("SAPPOCODE")) ? "" : Eval("SAPPOCODE")) %>'  ></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="100px" HorizontalAlign="Center"/> 
                                <HeaderStyle Width="100px" HorizontalAlign="Center" /> 
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="�ѹ�����觫���" >
                                <ItemTemplate>
                                    <uc3:CalendarControl ID="ctlSAPPODATE" runat="server" DateValue = '<%# Convert.IsDBNull(Eval("SAPPODATE")) ? new DateTime() : Convert.ToDateTime(Eval("SAPPODATE")) %>' />
                                </ItemTemplate>
                                <ItemStyle Width="100px" HorizontalAlign="Center"/> 
                                <HeaderStyle Width="100px" HorizontalAlign="Center" /> 
                            </asp:TemplateField>
                             <asp:BoundField  HeaderText="�ʹ����ҳ���" DataField="PLANQTY" >
                                <ItemStyle Width="100px" HorizontalAlign="Right"/> 
                                <HeaderStyle Width="100px" HorizontalAlign="Center" /> 
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="�ӹǹ����Ѻ" >
                                <ItemTemplate>
                                    <asp:TextBox ID="txtQTY" runat="server" value = "0" CssClass="zTextboxR" Width="50px" MaxLength="6"  onkeypress=ChkInt(this) onblur="valInt(this)" onfocus="prepareNum(this)" Text='<%# (Convert.IsDBNull(Eval("QTY")) ? "0" : Convert.ToDouble(Eval("QTY")).ToString("#,##0")) %>'   ></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="100px" HorizontalAlign="Right"/> 
                                <HeaderStyle Width="100px" HorizontalAlign="Center" /> 
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="�������" DataField="REMAINQTY"  >
                                <ItemStyle Width="100px" HorizontalAlign="Right"/> 
                                <HeaderStyle Width="100px" HorizontalAlign="Center" /> 
                            </asp:BoundField >
                            <asp:TemplateField HeaderText="���ʤ���ѳ��SAP" >
                                <ItemTemplate>
                                    <asp:TextBox ID="txtLOTNO" runat="server" CssClass="zTextboxR" Width="50px" MaxLength="6" Text='<%# (Convert.IsDBNull(Eval("LOTNO")) ? "" : Eval("LOTNO")) %>'    ></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="100px" HorizontalAlign="Center"/> 
                                <HeaderStyle Width="100px" HorizontalAlign="Center" /> 
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="���������Ѻ��Сѹ(��͹)" >
                                <ItemTemplate>
                                    <asp:TextBox ID="txtGURANTEE" runat="server"  CssClass="zTextboxR" Width="50px" MaxLength="6"  onkeypress=ChkInt(this) onblur="valInt(this)" onfocus="prepareNum(this)"  Text='<%# (Convert.IsDBNull(Eval("GUARANTEE")) ? "" : Convert.ToDouble(Eval("GUARANTEE")).ToString()) %>' ></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="100px" HorizontalAlign="Right"/> 
                                <HeaderStyle Width="100px" HorizontalAlign="Center" /> 
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
<uc4:MaterialUnitPopup ID="ctlMaterialUnitPopup" runat="server" OnSelectedIndexChanged="ctlMaterialUnitPopup_SelectedIndexChanged" />

</asp:Content>



