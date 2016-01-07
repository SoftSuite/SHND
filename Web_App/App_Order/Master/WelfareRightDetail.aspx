<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Templates/Page1.master" CodeFile="WelfareRightDetail.aspx.cs" Inherits="App_Order_Master_WelfareRightDetail" %>

<%@ Register Src="../../Search/DivisionPopup.ascx" TagName="DivisionPopup"
    TagPrefix="uc4" %>
<%@ Register Src="../../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="headtext">
                ข้อมูลสิทธิ์การใช้บริการอาหารสวัสดิการรายเดือน</td>
        </tr>
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbSave" runat="server" ToobarTitle="บันทึก" ToolbarImage="../../Images/save2.png" OnClick="tbSaveClick" />
                <uc1:ToolBarItemCtl ID="tbCancel" runat="server" ToobarTitle="ยกเลิกการแก้ไข" ToolbarImage="../../Images/cancel.png" OnClick="tbCancelClick" />
                <uc1:ToolBarItemCtl ID="tbBack" runat="server" ToobarTitle="กลับหน้ารายการ" ToolbarImage="../../Images/icn_back.png" OnClick="tbBackClick"/>
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
                            <table border="0" cellpadding="0" cellspacing="0" width="500">
                                <tr style="height:24px">
                                    <td style="width:100px; text-align:right; padding-right:10px">
                                        เดือน :</td> 
                                    <td>
                                        <asp:DropDownList ID="cmbMonth" runat="server" AutoPostBack="True"  OnSelectedIndexChanged="cmbMonth_SelectedIndexChanged">
                                        <asp:ListItem Value="0">เลือก</asp:ListItem>
<asp:ListItem Value="1">มกราคม</asp:ListItem>
     <asp:ListItem Value="2">กุมภาพันธ์</asp:ListItem>
     <asp:ListItem Value="3">มีนาคม</asp:ListItem>
     <asp:ListItem Value="4">เมษายน</asp:ListItem>
     <asp:ListItem Value="5">พฤษภาคม</asp:ListItem>
     <asp:ListItem Value="6">มิถุนายน</asp:ListItem>
     <asp:ListItem Value="7">กรกฎาคม</asp:ListItem>
     <asp:ListItem Value="8">สิงหาคม</asp:ListItem>
     <asp:ListItem Value="9">กันยายน</asp:ListItem>
     <asp:ListItem Value="10">ตุลาคม</asp:ListItem>
     <asp:ListItem Value="11">พฤศจิกายน</asp:ListItem>
     <asp:ListItem Value="12">ธันวาคม</asp:ListItem>
                                        </asp:DropDownList>  ปี พ.ศ. :
                                        <asp:TextBox ID="txtYear" runat="server" CssClass="zTextbox" MaxLength="4" Width="40px" AutoPostBack="True"  OnTextChanged="txtYear_TextChanged"></asp:TextBox>
                                        <asp:Label ID="lblRemarkName" runat="server" CssClass="zRemark" Text="*"></asp:Label>
                                    </td>  
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 100px; text-align: right">
                                        จำนวนวันทำการ :</td>
                                    <td>
                                        <asp:TextBox id="txtDay" runat="server" CssClass="zTextboxR"  Width="80px" AutoPostBack="True" OnTextChanged="txtDay_TextChanged"></asp:TextBox>
                                        วัน
                                        <asp:Label ID="lblRemarkCategory" runat="server" CssClass="zRemark" Text="*"></asp:Label></td>
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

                            <table border="0" cellpadding="0" cellspacing="0" width="100%">

                                <tr>
                                    <td class="toolbarplace">
                                        <uc1:ToolBarItemCtl ID="tbAddDivision" runat="server" ToobarTitle="เพิ่มหน่วยงาน" ToolbarImage="../../Images/icn_add.png" OnClick="tbAddDivisionClick" />
                                        <uc1:ToolBarItemCtl ID="tbDeleteDivision" runat="server" ToobarTitle="ลบหน่วยงาน" ToolbarImage="../../Images/icn_delete.png" OnClick="tbDeleteDivisionClick" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbStatusFormulaFeedItem" runat="server" EnableViewState="False"></asp:Label></td> 
                                </tr> 
                                <tr>
                                    <td>
                                         <asp:GridView ID="gvWelfareRightItem" runat="server" AutoGenerateColumns="False" CssClass="t_tablestyle" DataSourceID="WelfareRightItemSource" DataKeyNames="RANK" Width="750px" OnRowDataBound="gvWelfareRightItem_RowDataBound">
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
                                                        <input type="checkbox" name="chkMain" id="chkMain" onclick="chkAllBox(this, 'ctl00_MainContent_gvWelfareRightItem_ctl', '_chkSelect')" />
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
                                                <asp:BoundField DataField="DIVISIONNAME" HeaderText="หน่วยงาน">
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="จำนวนคน">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtQty" runat="server" CssClass="zTextboxR" Width="90px" MaxLength="10" Text='<%# Convert.ToDouble(Eval("QTY")).ToString("#,##0") %>' onkeypress="ChkInt(this)" onblur="valInt(this)" onfocus="prepareNum(this)" AutoPostBack="True" OnTextChanged="txtQty_TextChanged"></asp:TextBox>   
                                                    </ItemTemplate>
                                                    <ItemStyle Width="100px" HorizontalAlign="Right" /> 
                                                    <HeaderStyle Width="100px" HorizontalAlign="Center" /> 
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="จำนวนสิทธิ์">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtRightQty" runat="server" CssClass="zTextboxR-View" Readonly="true" Width="90px" MaxLength="10" Text='<%# Convert.ToDouble(Eval("QTYRiGHT")).ToString("#,##0") %>' onkeypress="ChkDbl(this)" onblur="valDbl(this)" onfocus="prepareNum(this)" ></asp:TextBox>   
                                                    </ItemTemplate>
                                                    <ItemStyle Width="100px" HorizontalAlign="Right" /> 
                                                    <HeaderStyle Width="100px" HorizontalAlign="Center" /> 
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="เบิกได้เกินสิทธิ์">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkOver" runat="server" Checked='<%# Eval("ISOVER").ToString() =="Y" %>'/>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="DIVISION" HeaderText="DIVISION">
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
                                        <asp:ObjectDataSource ID="WelfareRightItemSource" runat="server" SelectMethod="GetWelfareRightItemList" TypeName="WelfareRightItem" UpdateMethod="UpdateWelfareRightItem">
                                            <UpdateParameters>
                                                <asp:Parameter Name="LOID" Type="Double" />
                                                <asp:Parameter Name="DIVISION" Type="Double" />
                                                <asp:Parameter Name="DIVISIONNAME" Type="String" />
                                                <asp:Parameter Name="QTY" Type="Double" />
                                                <asp:Parameter Name="RIGHTQTY" Type="Double" />
                                                <asp:Parameter Name="ISOVER" Type="String" />
                                            </UpdateParameters>
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="txtLOID" DefaultValue="0" Name="Welfare" PropertyName="Text"
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

            </td>
        </tr>
    </table>
    <uc4:DivisionPopup ID="ctlDivisionPopup" runat="server" OnSelectedIndexChanged="ctlDivisionPopup_SelectedIndexChanged" />
</asp:Content>

