<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="FoodTypePrice.aspx.cs" Inherits="App_Admin_Master_FoodTypePrice" Title="SHND : Master - Food Type" %>

<%@ Register Src="../../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">

<table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
           <td class="headtext">
               กำหนดราคาอาหาร</td>
    </tr>
    <tr>  
        <td style="width: 25778px">
                <uc1:ToolBarItemCtl ID="tbSave" runat="server" ToobarTitle="บันทึก" onClick="tbSaveClick"  ToolbarImage="../../Images/save2.jpg"  />
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
                        <td colspan="2">
                            <asp:Label ID="lbStatus" runat="server" EnableViewState="False"></asp:Label>
                            <asp:TextBox ID="txhID" runat="server" Visible="False" Width="15px"></asp:TextBox> </td>
                    </tr>
                    <tr>
                        <td style="width:120px; text-align: right; padding-right:10px">หน่วยงานที่รับผิดชอบ :</td>
                        <td style="height: 24px"><asp:DropDownList ID="cmbDiv" runat="server" Width="307px"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width:120px; text-align: right; padding-right:10px">ประเภทอาหาร :</td>
                        <td style="height: 24px"><asp:TextBox ID="txtFoodType" runat="server" CssClass="zTextbox" MaxLength="50" Width="300px"></asp:TextBox>
                        &nbsp; &nbsp;<asp:ImageButton ID="imbSearch" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_find.png"
                        onClick="imbSearch_Click1"/> &nbsp; &nbsp;
                          <asp:ImageButton ID="imbReset" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_back.png"
                         onClick="imbReset_Click"  ToolTip="แสดงทั้งหมด" />
                         </td>
                     </tr>
                </table>
            </fieldset>        
        </td>
    </tr>
    <tr>
        <td style="height:15px">
            <asp:Label ID="lbStatusMain" runat="server" EnableViewState="False"></asp:Label>
                            <asp:TextBox ID="txhSortField" runat="server" Visible="False" Width="15px"></asp:TextBox><asp:TextBox
                                ID="txhSortDir" runat="server" Visible="False" Width="15px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td >
            <uc2:PageControl ID="pcTop" runat="server"   OnPageChange="PageChange"   />
               <asp:GridView ID="gvMain" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="t_tablestyle"  OnRowDataBound="gvMain_RowDataBound" OnSorting="gvMain_Sorting"  AllowPaging="True" PageSize="20" style="width:100%;"  >
                <Columns>
                     <asp:BoundField DataField="LOID" HeaderText="LOID">
                        <ControlStyle CssClass="zHidden" />
                        <FooterStyle CssClass="zHidden" />
                        <HeaderStyle CssClass="zHidden" />
                        <ItemStyle CssClass="zHidden" />
                    </asp:BoundField>
                  
                    <asp:TemplateField HeaderText="ลำดับ" SortExpression="DEFAULT">
                        <HeaderStyle Width="60px" />
                        <ItemStyle HorizontalAlign="Center" Width="60px" />
                    </asp:TemplateField>
                     <asp:BoundField DataField="CODE" HeaderText="รหัสใช้งาน" SortExpression="CODE">
                        <HeaderStyle HorizontalAlign="Center" Width="100px" />
                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                    </asp:BoundField> 
                     <asp:BoundField DataField="NAME" HeaderText="ประเภทอาหาร" SortExpression="NAME">
                        <HeaderStyle HorizontalAlign="Center" Width="200px" />
                        <ItemStyle HorizontalAlign="Left" Width="200px" />
                    </asp:BoundField>
                     <asp:BoundField DataField="DIVISIONNAME" HeaderText="หน่วยงานที่รับผิดชอบ" SortExpression="DIVISIONNAME">
                        <HeaderStyle HorizontalAlign="Center" Width="200px" />
                        <ItemStyle HorizontalAlign="Left" Width="200px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="ราคา" SortExpression="PRICE">
                          <HeaderStyle HorizontalAlign="Center" Width="100px" />
                        <ItemStyle HorizontalAlign="Center" Width="50px"  />
                        <ItemTemplate  >                      
                        <asp:TextBox  ID="txtPrice" runat="server" Text='<%# Bind("PRICE") %>' Width="80px" onkeypress="ChkInt(this)" onblur="valInt(this)" onfocus="prepareNum(this)" CssClass="zTextboxR"></asp:TextBox>
                        </ItemTemplate> 
                        <HeaderStyle HorizontalAlign="Center" Width="90px" />
                        <ItemStyle HorizontalAlign="Right" Width="90px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ต่อ" >
                        <ItemTemplate  >                      
                        <asp:RadioButton   ID="radDA" runat="server" Text ="วัน"  Checked='<%# (Convert.IsDBNull(Eval("PRICETYPE")) ? "" : Eval("PRICETYPE").ToString()) == "DA" %>' AutoPostBack="true" GroupName="GrpPer"  ></asp:RadioButton>
                        &nbsp; &nbsp;
                        <asp:RadioButton   ID="radME" runat="server" Text="มื้อ" Checked='<%# (Convert.IsDBNull(Eval("PRICETYPE")) ? "" : Eval("PRICETYPE").ToString()) == "ME" %>' AutoPostBack="true" GroupName="GrpPer" ></asp:RadioButton>
                        </ItemTemplate> 
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
                    </asp:GridView> <uc2:PageControl ID="pcBot" runat="server"   OnPageChange="PageChange"   />
            </td> 
        </tr> 
    </table> 
</asp:Content>

