<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OrderFeedSetCtl.ascx.cs" Inherits="App_Prepare_Transaction_OrderFeedSet_OrderFeedSetCtl" %>
<%@ Register Src="../../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl"
    TagPrefix="uc2" %>

<%@ Register Src="../../../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Src="../../../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc1" %>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td>
            <uc2:ToolBarItemCtl ID="tbCut" runat="server" ToobarTitle ="�Ѵ�ʹ" ToolbarImage="../../Images/icn_approve.png" />
            <uc2:ToolBarItemCtl ID="tbPrintList" runat="server" ToobarTitle ="�������§ҹ�����������" ToolbarImage="../../Images/icn_print.png" />
            <uc2:ToolBarItemCtl ID="tbPrintSlip" runat="server" ToobarTitle ="�Ծ�� Slip" ToolbarImage="../../Images/icn_print.png" />
        </td>
    </tr>
    <tr>
        <td>
            <hr style="size:1px" />
        </td>
    </tr>
    <tr>
        <td>
            <fieldset style="padding:15px;">
                <legend style="font-weight:bold">
                    ���Ң�����
                </legend>
                <table border="0" cellpadding="0" cellspacing="0" width="900px">
                    <tr>
                        <td style="height:15px" colspan="8"></td>
                    </tr> 
                    <tr style="height: 24px">
                        <td style="padding-right: 10px; width: 110px; text-align: right">
                            �ͼ����� :</td>
                        <td colspan="7">
                            <asp:DropDownList ID="cmbSearchWard" runat="server" CssClass="zComboBox" Width="200px">
                            </asp:DropDownList></td>
                    </tr>
                    <tr style="height: 24px">
                        <td style="padding-right: 10px; width: 110px; text-align: right">
                            ����������� :</td>
                        <td colspan="7">
                            <asp:DropDownList ID="cmbSearchFoodType" runat="server" CssClass="zComboBox" Width="200px">
                            </asp:DropDownList></td>
                    </tr>
                    <tr style="height: 24px">
                        <td style="padding-right: 10px; width: 110px; text-align: right">
                            ��Դ����� :</td>
                        <td colspan="7">
                            <asp:DropDownList ID="cmbSearchFoodCategory" runat="server" CssClass="zComboBox" Width="200px">
                            </asp:DropDownList></td>
                    </tr>
                    <tr style="height: 24px">
                        <td style="padding-right: 10px; width: 110px; text-align: right">
                            ����-ʡ�� ������ :</td>
                        <td colspan="7">
                            <asp:TextBox ID="txtSearchPatientName" runat="server" CssClass="zTextbox" Width="340px"></asp:TextBox></td>
                    </tr>
                    <tr style="height: 24px">
                        <td style="padding-right: 10px; width: 110px; text-align: right">
                            HN :</td>
                        <td colspan="7">
                            <asp:TextBox ID="txtSearchHN" runat="server" CssClass="zTextbox" Width="100px"></asp:TextBox>
                            AN :
                            <asp:TextBox ID="txtSearchAN" runat="server" CssClass="zTextbox" Width="100px"></asp:TextBox>
                            VN :
                            <asp:TextBox ID="txtSearchVN" runat="server" CssClass="zTextbox" Width="100px"></asp:TextBox>

                        </td>
                    </tr>
                    
                    <tr style="height:24px">
                        <td style="width:110px; text-align: right; padding-right:10px">
                            �ѹ���������� :</td>
                        <td style="width:150px;">
                            <uc1:CalendarControl ID="ctlSearchOrderDate" runat="server" />
                        </td>
                        <td style="width:50px; text-align: right; padding-right:10px">
                            ���� :</td>
                        <td style="width:29px;">
                            <asp:TextBox ID="txtSearchTimeFrom" runat="server" CssClass="zTextboxR" Width="45px"></asp:TextBox></td>
                        <td style="width:34px;" align="center">
                            �֧</td>
                        <td style="width:50px;">
                            <asp:TextBox ID="txtSearchTimeTo" runat="server" CssClass="zTextboxR" Width="45px"></asp:TextBox></td>
                        <td style="width:70px; padding-left:10px" class="zRemark" colspan="3">
                            (Ex 08:00)</td>
                    </tr>
                     <tr style="height:24px">
                        <td style="width:110px; text-align: right; padding-right:10px">
                            �ѹ��� Register :</td>
                        <td style="width:150px;">
                            <uc1:CalendarControl ID="ctlSearchRegDate" runat="server" />
                        </td>
                        <td style="width:50px; text-align: right; padding-right:10px">
                            ���� :</td>
                        <td style="width:29px;">
                            <asp:TextBox ID="txtRegTimeFrom" runat="server" CssClass="zTextboxR" Width="45px"></asp:TextBox></td>
                        <td style="width:34px;" align="center">
                            �֧</td>
                        <td style="width:50px;">
                            <asp:TextBox ID="txtRegTimeTo" runat="server" CssClass="zTextboxR" Width="45px"></asp:TextBox></td>
                        <td style="width:70px; padding-left:10px" class="zRemark">
                            (Ex 08:00)</td>
                        <td>
                            <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/Images/icn_find.png" ImageAlign="absMiddle" OnClick="imbSearch_Click" />&nbsp;
                            &nbsp;<asp:ImageButton ID="imbReset" Visible="false" runat="server" ImageUrl="~/Images/icn_back.png" ImageAlign="absMiddle" OnClick="imbReset_Click" />

                        </td>
                    </tr>
                </table> 
                <cc1:MaskedEditExtender ID="mdeTimeFrom" runat="server" TargetControlID="txtSearchTimeFrom" MaskType="Time" Mask="99:99"></cc1:MaskedEditExtender>
                <cc1:MaskedEditExtender ID="mdeTimeTo" runat="server" TargetControlID="txtSearchTimeTo" MaskType="Time" Mask="99:99"></cc1:MaskedEditExtender>
                <cc1:MaskedEditExtender ID="mdeRegTimeFrom" runat="server" TargetControlID="txtRegTimeFrom" MaskType="Time" Mask="99:99"></cc1:MaskedEditExtender>
                <cc1:MaskedEditExtender ID="mdeRegTimeTo" runat="server" TargetControlID="txtRegTimeTo" MaskType="Time" Mask="99:99"></cc1:MaskedEditExtender>

            </fieldset>
        </td>
    </tr>

    <tr>
        <td>
            <uc3:PageControl ID="pcTop" runat="server" OnPageChange="PageChange"  />
            <asp:GridView ID="gvMain" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="t_tablestyle1" CellPadding="0" OnRowDataBound="gvMain_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="ORDERMEDICALFEED" HeaderText="ORDERMEDICALFEED">
                        <ControlStyle CssClass="zHidden" />
                        <FooterStyle CssClass="zHidden" />
                        <HeaderStyle CssClass="zHidden" />
                        <ItemStyle CssClass="zHidden" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ORDERNONMEDICAL" HeaderText="ORDERNONMEDICAL">
                        <ControlStyle CssClass="zHidden" />
                        <FooterStyle CssClass="zHidden" />
                        <HeaderStyle CssClass="zHidden" />
                        <ItemStyle CssClass="zHidden" />
                    </asp:BoundField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <table border="0" cellpadding="2" cellspacing="0" width="100%">
                                <tr style="height:20px" class="t_headtext">
                                    <td style="width:40px; border-right:solid 1px" align="center">�ӴѺ</td> 
                                    <td style="width:30px; border-right:solid 1px" align="center"></td> 
                                    <td style="width:120px; border-right:solid 1px" align="center">�ͼ�����</td> 
                                    <td style="width:30px; border-right:solid 1px" align="center">��ͧ</td> 
                                    <td style="width:30px; border-right:solid 1px" align="center">��§</td> 
                                    <td style="width:60px; border-right:solid 1px" align="center">HN</td> 
                                    <td style="width:60px; border-right:solid 1px" align="center">AN</td> 
                                    <td style="width:50px; border-right:solid 1px" align="center">VN</td>  
                                    <td style="width:250px; border-right:solid 1px" align="center">����-ʡ��</td> 
                                    <td style="width:30px; border-right:solid 1px" align="center">����</td>  
                                    <td style="width:30px; border-right:solid 1px" align="center">�.�.</td>  
                                    <td style="width:30px; border-right:solid 1px" align="center">�.�.</td>  
                                    <td style="border-right:solid 1px" align="center">BMI</td>  
                                </tr>
                            </table>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <table border="0" cellpadding="2" cellspacing="0" width="100%">
                                <tr style="height:20px" class='<%# Eval("RANK").ToString() != "0" ? "t_alt_bg" : "zHidden" %>'>
                                    <td style="width:40px; border-right:solid 1px" align="center"><%# Eval("RANK") %></td> 
                                    <td style="width:30px; border-right:solid 1px" align="center"></td> 
                                    <td style="width:120px; border-right:solid 1px" align="left"><%# Eval("WARDNAME") %></td> 
                                    <td style="width:30px; border-right:solid 1px" align="center"><%# Eval("ROOMNO") %></td> 
                                    <td style="width:30px; border-right:solid 1px" align="center"><%# Eval("BEDNO") %></td> 
                                    <td style="width:60px; border-right:solid 1px" align="center"><%# Eval("HN") %></td> 
                                    <td style="width:60px; border-right:solid 1px" align="center"><%# Eval("AN") %></td> 
                                    <td style="width:50px; border-right:solid 1px" align="center"><%# Eval("VN") %></td>  
                                    <td style="width:250px; border-right:solid 1px" align="left"><%# Eval("PATIENTNAME") %></td> 
                                    <td style="width:30px; border-right:solid 1px" align="right"><asp:Label ID="lblAGE" runat="server" Text='<%#Eval("AGE")%>'></asp:Label></td>  
                                    <td style="width:30px; border-right:solid 1px" align="right"><%# Eval("WEIGHT") %></td>  
                                    <td style="width:30px; border-right:solid 1px" align="right"><%# Eval("HEIGHT") %></td>  
                                    <td style="border-right:solid 1px" align="left"><%# Eval("BMI") %></td>  
                                </tr>
                                <tr style="height:1px">
                                    <td style="width:40px; border-right:solid 1px" align="center"></td> 
                                    <td style="width:30px; border-right:solid 1px" align="center"></td> 
                                    <td style="width:120px; border-right:solid 1px" align="left"></td> 
                                    <td style="width:30px; border-right:solid 1px" align="center"></td> 
                                    <td style="width:30px; border-right:solid 1px" align="center"></td> 
                                    <td style="width:50px; border-right:solid 1px" align="center"></td> 
                                    <td style="width:50px; border-right:solid 1px" align="center"></td> 
                                    <td style="width:50px; border-right:solid 1px" align="center"></td>  
                                    <td style="width:250px; border-right:solid 1px" align="left"></td> 
                                    <td style="width:30px; border-right:solid 1px" align="right"></td>  
                                    <td style="width:30px; border-right:solid 1px" align="right"></td>  
                                    <td style="width:30px; border-right:solid 1px" align="right"></td>  
                                    <td style="border-right:solid 1px" align="left"></td>  
                                </tr>
                                <tr style="height:20px">
                                    <td style="width:40px;" align="center"></td> 
                                    <td style="width:30px;" align="center"></td> 
                                    <td align="left" colspan="11">
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                            <tr style="height:20px">
                                                <td style="width:280px"><b>��������� : </b><%# Eval("FOODNAME") %></td>
                                                <td style="width:250px"><b>�ӹǹ : </b><%# Eval("QTY") %></td>
                                                <td><b>�ѹ-���ҷ��ѹ�֡ : </b><%# Eval("ORDERDATE") %></td>
                                            </tr>
                                            <tr style="height:20px" class='<%# Eval("CONTROL").ToString() == "" && Eval("LIMIT").ToString() == "" && Eval("INCREASE").ToString() =="" ? "zHidden" : "" %>' >
                                                <td style="width:280px"><b>�Ǻ��� : </b><%# Eval("CONTROL") %></td>
                                                <td style="width:250px"><b>�ӡѴ����ҳ : </b><%# Eval("LIMIT") %></td>
                                                <td><b>���ҷ�� Register : </b><%# Eval("REGISTERDATE")%></td>
                                            </tr>
                                            <tr style="height:20px">
                                                <td style="width:280px"><b>������ : </b><%# Eval("FOODTYPENAME") %></td>
                                                <td style="width:250px"><b>��Դ : </b><%# Eval("FEEDCATEGORYNAME") %></td>
                                                <td><b>���������� : </b><%# Eval("INCREASE") %></td>
                                                <td></td>
                                            </tr>
                                            <tr style="height:20px">
                                                <td style="width:280px"><b>�����˵� : </b><%# Eval("REMARKS") %></td>
                                                <td style="width:250px"><b>ʶҹ� : </b><span style="color:Red"><%# Eval("STATUSNAME") %></span></td>
                                                <td></td>
                                            </tr>
                                        </table>
                                    </td> 
                                </tr> 
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerSettings Visible="False" />
            </asp:GridView>
            <uc3:PageControl ID="pcBot" runat="server"  OnPageChange="PageChange"  /> 
        </td>
    </tr>
</table>
    <cc1:ModalPopupExtender ID="CutPop" runat="server" TargetControlID="tbCut$lb" PopupControlID="PnlCut" BackgroundCssClass="modalBackground" DropShadow="true"></cc1:ModalPopupExtender>
    <asp:Panel ID="PnlCut" runat="server" CssClass="modalPopup" style="display:none" Width="500px">
    <table cellspacing="0" cellpadding="0" border="0" width="100%">
        <tr>
            <td>
                <uc2:ToolBarItemCtl ID="tbSave" runat="server" ToobarTitle="�ѹ�֡" ToolbarImage="../../Images/save2.png" OnClick ="tbSaveClick"  />
                <uc2:ToolBarItemCtl ID="tbBack" runat="server" ToobarTitle="��Ѻ˹����¡��" ToolbarImage="../../Images/icn_back.png" OnClick="tbBackClick" />
            </td>
        </tr>
        <tr>
            <td><hr style="size:1px" /></td>
        </tr>
        <tr>
            <td>
                <table>
                   <tr>
                        <td align="right">
                            <asp:TextBox ID="txhSortField" runat="server" Visible="False" Width="15px"></asp:TextBox><asp:TextBox
                                ID="txhSortDir" runat="server" Visible="False" Width="15px"></asp:TextBox><asp:TextBox
                                    ID="txhID" runat="server" Visible="False" Width="15px"></asp:TextBox>
                                <asp:TextBox ID="txtConcat" runat="server"  Visible="False"  Width="15px" ></asp:TextBox>
                             </td>
                        <td style="height:15px">
                            <asp:Label ID="lbStatus" runat="server" EnableViewState="False"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="height:23px;">���� :</td>
                        <td style="height:23px"><asp:TextBox ID="txtTime" runat="server" Width ="100px"  CssClass="zTextbox-View" ReadOnly="true"></asp:TextBox> </td>
                        <td style="height:23px">Cut of Time</td>
                        <td style="height:23px;"><asp:TextBox ID="txtCutOfTime" runat="server" Width ="100px" CssClass="zTextbox-View" ReadOnly="true" ></asp:TextBox> </td>
                    </tr>
                </table>
                <br />
                <table >
                    <tr>
                        <td style="height:23px; width:80px"></td>
                        <td style="height:23px" align="right">�ӹǹ :</td>
                        <td ><asp:TextBox id="txtQty" runat="server" Width="100px" CssClass="zTextboxR-View" ReadOnly="true"></asp:TextBox>  ��
                        </td>
                    </tr>
                    <tr>
                        <td style="height:23px; width:80px"></td>
                        <td style="height:23px" align="right">���� :</td>
                        <td ><asp:DropDownList ID="cmbMeal" runat="server" Width="108px" AutoPostBack="True" OnSelectedIndexChanged="cmbMeal_SelectedIndexChanged" ></asp:DropDownList>
                        <span id="Span1" style="color:Red" runat="server" >*</span>
                        </td>
                    </tr>
                    <tr>
                        <td style="height:23px; width:80px"></td>
                        <td style="height:23px" align="right">�ѹ��� :</td>
                        <td ><uc1:CalendarControl ID="ctlCheckTime" Enabled="false" runat="server" />
                        </td>
                    </tr>
                </table>
                <br />
                <br />
            </td>
        </tr>
        
        
    </table>
    </asp:Panel>
