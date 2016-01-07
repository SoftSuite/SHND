<%@ Page Language="C#"  MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="MenuDetail.aspx.cs" Inherits="App_Formula_Transaction_MenuDetail"  Title="SHND : Transaction - Menu" %>

<%@ Register Src="Controls/OverAllCtl.ascx" TagName="OverAllCtl" TagPrefix="uc4" %>

<%@ Register Src="../../Search/DiseaseCategoryPopup.ascx" TagName="DiseaseCategoryPopup" TagPrefix="uc3" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Src="Controls/MenuItemControl.ascx" TagName="MenuItemControl" TagPrefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="headtext">
                ������������ǧ˹��</td>
        </tr>
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbSave" runat="server" ToobarTitle="�ѹ�֡" ToolbarImage="../../Images/save2.png" OnClick="tbSaveClick" />
                <uc1:ToolBarItemCtl ID="tbCancel" runat="server" ToobarTitle="¡��ԡ������" ToolbarImage="../../Images/cancel.png" OnClick="tbCancelClick" />
                <uc1:ToolBarItemCtl ID="tbBack" runat="server" ToobarTitle="��Ѻ˹����¡��" ToolbarImage="../../Images/icn_back.png" OnClick="tbBackClick"/>
                <uc1:ToolBarItemCtl ID="tbPrint" runat="server" ToobarTitle="�������§ҹ" ToolbarImage="../../Images/icn_print.png" />
                <uc1:ToolBarItemCtl ID="tbApprove" runat="server" ToobarTitle="͹��ѵ�" ToolbarImage="../../Images/icn_approve.png" OnClick="tbApproveClick"/>

            </td>
        </tr>
        <tr>
            <td style="height:30px" valign="top">
                <hr style="size:1px" />
                <asp:Label ID="lbStatus" runat="server" EnableViewState="False"></asp:Label>
                <asp:TextBox ID="txtLOID" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
                <asp:TextBox ID="txtItem" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
                <asp:TextBox ID="txtYearOld" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
                <asp:TextBox ID="txtPhaseOld" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
                <asp:TextBox ID="txtStatus" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
                <asp:TextBox ID="txtDivision" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
                <asp:TextBox ID="txtCurentTab" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
                <asp:TextBox ID="txtCurentDate" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
                <asp:TextBox ID="txtCurentMeal" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td style="padding:5px; border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid; width:400px" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" width="550px">
                                <tr style="height:24px">
                                    <td style="width:110px; text-align:right; padding-right:10px">
                                        ��������:</td> 
                                    <td>
                                        <asp:TextBox ID="txtName" runat="server" CssClass="zTextbox" MaxLength="100" Width="350px"></asp:TextBox>
                                        <asp:Label ID="lblRemarkName" runat="server" CssClass="zRemark" Text="*"></asp:Label>
                                    </td>
                                </tr>
                                <tr style="height: 24px">
                                    <td style="width:110px; text-align:right; padding-right:10px">
                                        ����������� :</td> 
                                    <td>
                                        <asp:DropDownList ID="cmbFoodType" runat="server" Width="205px" CssClass="zComboBox"></asp:DropDownList>
                                        <asp:Label ID="lblRemarkFoodType" runat="server" CssClass="zRemark" Text="*"></asp:Label>
                                    </td>
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 110px; text-align: right">
                                        ��Դ����� :</td>
                                    <td>
                                        <asp:DropDownList ID="cmbFoodCategory" runat="server" Width="205px" CssClass="zComboBox"></asp:DropDownList>
                                        <asp:Label ID="lblRemarkCategory" runat="server" CssClass="zRemark" Text="*"></asp:Label>
                                    </td>
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 110px; text-align: right">
                                        �է�����ҳ :</td>
                                    <td>
                                        <asp:TextBox ID="txtBudgetYear" runat="server" CssClass="zTextbox" MaxLength="4" Width="50px" OnTextChanged="txtBudgetYear_TextChanged" AutoPostBack="True"></asp:TextBox>
                                        <asp:Label ID="lblRemarkBudgetYear" runat="server" CssClass="zRemark" Text="*"></asp:Label>
                                    </td>
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 110px; text-align: right">
                                        �Ǵ����ҳ��� :</td>
                                    <td>
                                        <asp:RadioButtonList ID="rblPhase" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="rblPhase_SelectedIndexChanged" Width="140px">
                                            <asp:ListItem Value="1"  Selected="True">�Ǵ��� 1</asp:ListItem>
                                            <asp:ListItem Value="2">�Ǵ��� 2</asp:ListItem>
                                        </asp:RadioButtonList> <asp:Label ID="lblRemarkPhase" runat="server" CssClass="zRemark" Text="*"></asp:Label>
                                    </td>
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 110px; text-align: right">
                                        �ѹ��� :</td>
                                    <td>
                                        <asp:TextBox ID="txtDateFrom" runat="server" CssClass="zTextbox-View" ReadOnly="True"  Width="100px"></asp:TextBox> �֧ 
                                        <asp:TextBox ID="txtDateTo" runat="server" CssClass="zTextbox-View" ReadOnly="True"  Width="100px"></asp:TextBox>
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
                                        ʶҹ� :</td> 
                                    <td>
                                        <asp:TextBox ID="txtStatusName" runat="server" CssClass="zTextbox-View" ReadOnly="True" Width="150px"></asp:TextBox></td> 
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 100px; text-align: right">
                                        ˹��§ҹ :</td>
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
                    <cc1:TabPanel ID="tabStdMenuDisease" runat="server" HeaderText="��Դ�������÷��Ǻ���" >
                        <ContentTemplate>
                            <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                <tr>
                                    <td class="toolbarplace">
                                        <uc1:ToolBarItemCtl ID="tbAddStdMenuDisease" runat="server" ToobarTitle="������¡��" ToolbarImage="../../Images/icn_add.png" OnClick="tbAddStdMenuDiseaseClick" />
                                        <uc1:ToolBarItemCtl ID="tbDeleteStdMenuDisease" runat="server" ToobarTitle="ź��¡��" ToolbarImage="../../Images/icn_delete.png" OnClick="tbDeleteStdMenuDiseaseClick" />
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
                                            <HeaderStyle CssClass="t_headtext" />
                                            <PagerSettings Visible="False" />
                                            <AlternatingRowStyle CssClass="t_alt_bg" />
                                            <Columns>
<asp:BoundField DataField="DISEASECATEGORY" HeaderText="DISEASECATEGORY">
<ControlStyle CssClass="zHidden"></ControlStyle>

<ItemStyle CssClass="zHidden"></ItemStyle>

<HeaderStyle CssClass="zHidden"></HeaderStyle>

<FooterStyle CssClass="zHidden"></FooterStyle>
</asp:BoundField>
<asp:TemplateField><HeaderTemplate>
                                                        <input type="checkbox" name="chkMain" id="chkMain" onclick="chkAllBox(this, 'ctl00_MainContent_tabStdMenu_tabStdMenuDisease_gvStdMenuDisease_ctl', '_chkSelect')" />
                                                    
</HeaderTemplate>

<ItemStyle Width="30px" HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>

<HeaderStyle Width="30px" HorizontalAlign="Center"></HeaderStyle>
<ItemTemplate>
                                                        <asp:CheckBox ID="chkSelect" runat="server" />
                                                    
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="�ӴѺ">
<ItemStyle Width="60px" Height="24px" HorizontalAlign="Center"></ItemStyle>

<HeaderStyle Width="60px"></HeaderStyle>
<ItemTemplate>
                                                        <%# Container.DataItemIndex + 1%>
                                                    
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="DISEASECATEGORYNAME" HeaderText="�������÷��Ǻ���"></asp:BoundField>
<asp:TemplateField HeaderText="High">
<ItemStyle Width="40px" HorizontalAlign="Center"></ItemStyle>

<HeaderStyle Width="40px"></HeaderStyle>
<ItemTemplate>
                                                        <asp:RadioButton ID="chkHigh" runat="server" GroupName="CategoryName" Checked='<%# Eval("ISHIGH").ToString() =="Y" %>' />
                                                    
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Low">
<ItemStyle Width="40px" HorizontalAlign="Center"></ItemStyle>

<HeaderStyle Width="40px"></HeaderStyle>
<ItemTemplate>
                                                        <asp:RadioButton ID="chkLow" runat="server" GroupName="CategoryName" Checked='<%# Eval("ISLOW").ToString() =="Y" %>' />
                                                    
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Non">
<ItemStyle Width="40px" HorizontalAlign="Center"></ItemStyle>

<HeaderStyle Width="40px"></HeaderStyle>
<ItemTemplate>
                                                        <asp:RadioButton ID="chkNon" runat="server" GroupName="CategoryName" Checked='<%# Eval("ISNON").ToString() =="Y" %>' />
                                                    
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField ReadOnly="True" DataField="ISHIGHVISIBLE" HeaderText="ISHIGHVISIBLE">
<ControlStyle CssClass="zHidden"></ControlStyle>

<ItemStyle CssClass="zHidden"></ItemStyle>

<HeaderStyle CssClass="zHidden"></HeaderStyle>

<FooterStyle CssClass="zHidden"></FooterStyle>
</asp:BoundField>
<asp:BoundField ReadOnly="True" DataField="ISLOWVISIBLE" HeaderText="ISLOWVISIBLE">
<ControlStyle CssClass="zHidden"></ControlStyle>

<ItemStyle CssClass="zHidden"></ItemStyle>

<HeaderStyle CssClass="zHidden"></HeaderStyle>

<FooterStyle CssClass="zHidden"></FooterStyle>
</asp:BoundField>
<asp:BoundField ReadOnly="True" DataField="ISNONVISIBLE" HeaderText="ISNONVISIBLE">
<ControlStyle CssClass="zHidden"></ControlStyle>

<ItemStyle CssClass="zHidden"></ItemStyle>

<HeaderStyle CssClass="zHidden"></HeaderStyle>

<FooterStyle CssClass="zHidden"></FooterStyle>
</asp:BoundField>
</Columns>
                                        </asp:GridView>
                                        <asp:ObjectDataSource ID="stdMenuDiseaseSource" runat="server" SelectMethod="GetMenuDiseaseList" TypeName="MenuDetailItem">
                                            <SelectParameters>
<asp:ControlParameter PropertyName="Text" Type="Double" DefaultValue="0" Name="MenuID" ControlID="txtLOID"></asp:ControlParameter>
</SelectParameters>
                                        </asp:ObjectDataSource>
                                    </td> 
                                </tr>
                            </table>
                        </ContentTemplate>
                    </cc1:TabPanel>
                     <cc1:TabPanel ID="TabStdMenuSelect" runat="server" HeaderText="���͡�����ҵðҹ" >
                        <ContentTemplate>
                            <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                <tr>
                                    <td class="toolbarplace">
                                        <asp:ImageButton ID="imbCal" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_copy.png" OnClick="imbCal_Click" ToolTip="�Ѵ�͡" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        
                                    </td> 
                                </tr>
                                <tr>
                                    <td>
                                        <asp:GridView ID="gvStdMenu" runat="server" AutoGenerateColumns="False" CssClass="t_tablestyle" DataSourceID="stdMenuSource" OnRowDataBound="gvStdMenu_RowDataBound">
                                            <HeaderStyle CssClass="t_headtext" />
                                            <PagerSettings Visible="False" />
                                            <AlternatingRowStyle CssClass="t_alt_bg" />
                                            <Columns>

<asp:BoundField DataField="MONTHYEAR" HeaderText="��͹��">
<ItemStyle Width="100px" HorizontalAlign="Center"></ItemStyle>
<HeaderStyle Width="100px"></HeaderStyle>
</asp:BoundField>

<asp:TemplateField HeaderText="���͡���٨ҡ">
<ItemStyle Width="300px" ></ItemStyle>
<HeaderStyle Width="300px"></HeaderStyle>
<ItemTemplate>
<asp:RadioButton ID="rbtStandard" Text="�����ҵðҹ" runat="server" GroupName="Menu" Checked='<%# Eval("MENUSOURCE").ToString() =="S" %>' AutoPostBack="True" OnCheckedChanged="rbtStandard_CheckedChanged"> </asp:RadioButton>
<asp:DropDownList ID="cmbStandard" CssClass="zComboBox" runat="server" Width="200px"></asp:DropDownList><br>
<asp:RadioButton ID="rbtDialy"  Text="���ٻ�Ш��ѹ" GroupName="Menu" runat="server" Checked='<%# Eval("MENUSOURCE").ToString() =="B" %>' AutoPostBack="True" OnCheckedChanged="rbtDialy_CheckedChanged"> </asp:RadioButton>  
���͹ 
<asp:DropDownList ID="cmbMonth" CssClass="zComboBox" runat="server" SelectedValue='<%# Eval("BMONTH").ToString()%>' Enabled='<%# Eval("MENUSOURCE").ToString() =="B" %>'>
<asp:ListItem Value="0">���͡</asp:ListItem>
<asp:ListItem Value="1">���Ҥ�</asp:ListItem>
     <asp:ListItem Value="2">����Ҿѹ��</asp:ListItem>
     <asp:ListItem Value="3">�չҤ�</asp:ListItem>
     <asp:ListItem Value="4">����¹</asp:ListItem>
     <asp:ListItem Value="5">����Ҥ�</asp:ListItem>
     <asp:ListItem Value="6">�Զع�¹</asp:ListItem>
     <asp:ListItem Value="7">�á�Ҥ�</asp:ListItem>
     <asp:ListItem Value="8">�ԧ�Ҥ�</asp:ListItem>
     <asp:ListItem Value="9">�ѹ��¹</asp:ListItem>
     <asp:ListItem Value="10">���Ҥ�</asp:ListItem>
     <asp:ListItem Value="11">��Ȩԡ�¹</asp:ListItem>
     <asp:ListItem Value="12">�ѹ�Ҥ�</asp:ListItem>
</asp:DropDownList> �� 
<asp:TextBox ID="txtYear" CssClass='<%# Eval("MENUSOURCE").ToString() =="B" ? "zTextboxR" : "zTextboxR-View" %>' Width="50px" runat="server" Text='<%# Eval("BYEAR").ToString()%>' ReadOnly='<%# Eval("MENUSOURCE").ToString() =="S" %>'></asp:TextBox>                                                
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="����Ңͧ�ӹǹ������">
<ItemStyle Width="160px"></ItemStyle>
<HeaderStyle Width="160px"></HeaderStyle>
<ItemTemplate>
<asp:RadioButtonList ID="rbtPortion" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rbtPortion_SelectedIndexChanged" RepeatDirection="Vertical">
                                    <asp:ListItem Value="1">����¨ҡ 6 ��͹�������</asp:ListItem>
                                    <asp:ListItem Value="2">���͹����ش</asp:ListItem>
                                    <asp:ListItem Value="3">��͹���ǡѹ�ͧ�շ������</asp:ListItem>
                                </asp:RadioButtonList>                                                
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="�ӹǹ������ (��)">
<ItemStyle Width="100px" HorizontalAlign="Center"></ItemStyle>
<HeaderStyle Width="100px"></HeaderStyle>
<ItemTemplate>
      <asp:TextBox ID="txtAmount" CssClass="zTextboxR" Text='<%# Convert.IsDBNull(Eval("PATIENTQTY")) ? "0" : Convert.ToDouble(Eval("PATIENTQTY")).ToString("#,##0") %>' Width="80px" runat="server"></asp:TextBox>                                         
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="MMONTH" HeaderText="��͹">
<ItemStyle CssClass="zHidden"></ItemStyle>
<HeaderStyle CssClass="zHidden"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="MYEAR" HeaderText="��">
<ItemStyle CssClass="zHidden"></ItemStyle>
<HeaderStyle CssClass="zHidden"></HeaderStyle>
</asp:BoundField>
</Columns>
                                        </asp:GridView>
                                        <asp:ObjectDataSource ID="stdMenuSource" runat="server" SelectMethod="GetStdMenuList" TypeName="MenuDetailItem">
                                            <SelectParameters>
<asp:ControlParameter PropertyName="Text" Type="Double" DefaultValue="0" Name="MenuID" ControlID="txtLOID"></asp:ControlParameter>
</SelectParameters>
                                        </asp:ObjectDataSource>
                                    </td> 
                                </tr>
                            </table>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabOverAll" runat="server" HeaderText="�Ҿ���" >
                        <ContentTemplate>
                            <uc4:OverAllCtl ID="ctlOverAll" runat="server" OnLinkClick="ctlOverAllLinkClick"/>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="tabMenuItemBreakfast" runat="server" HeaderText="�������">
                        <ContentTemplate>
                            <uc2:MenuItemControl ID="ctlMenuItemBreakfast" runat="server"/>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="tabMenuItemLunch" runat="server" HeaderText="���͡�ҧ�ѹ" >
                        <ContentTemplate>
                            <uc2:MenuItemControl ID="ctlMenuItemLunch" runat="server"/>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="tabMenuItemDinner" runat="server" HeaderText="�������" >
                        <ContentTemplate>
                            <uc2:MenuItemControl ID="ctlMenuItemDinner" runat="server"/>
                        </ContentTemplate>
                    </cc1:TabPanel>
                </cc1:TabContainer>
            </td>
        </tr>  
    </table> 
    <uc3:DiseaseCategoryPopup id="ctlDiseaseCategoryPopup" runat="server" OnSelectedIndexChanged="ctlDiseaseCategoryPopup_SelectedIndexChanged" />
</asp:Content>
