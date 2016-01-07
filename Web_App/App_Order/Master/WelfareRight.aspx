<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="WelfareRight.aspx.cs" Inherits="App_Order_Master_WelfareRight" %>
<%@ Register Src="../../Templates/MenuCtl.ascx" TagName="MenuCtl" TagPrefix="uc3" %>

<%@ Register Src="../../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>



<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server"> 

 <table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
           <td class="headtext">
               ข้อมูลสิทธิ์การใช้บริการอาหารสวัสดิการรายเดือน</td>
                    
    </tr>
    <tr>  
        <td style="width: 25778px">
                <uc1:ToolBarItemCtl ID="tbAdd" runat="server" ToobarTitle="เพิ่มข้อมูล"  OnClick="tbAddClick"  ToolbarImage="../../Images/icn_add.png"  />
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
                        <td colspan="1">
                        </td>
                    </tr>
                    <tr>
                        <td style="width:120px; text-align: right; padding-right:10px; height: 24px;">ปี :</td>
                        <td style="height: 24px; width: 420px;"><asp:TextBox ID="txtYearFrom" runat="server" CssClass="zTextbox" MaxLength="50" Width="100px"></asp:TextBox>
                        ถึง : <asp:TextBox ID="txtYearTo" runat="server" CssClass="zTextbox" MaxLength="50" Width="100px"></asp:TextBox></td>
                       <td style="height: 24px"> 
                        <asp:ImageButton ID="butSearch" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_find.png"
                      OnClick="imbSearch_Click"  />&nbsp;
                    <asp:ImageButton ID="imbReset" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_back.png"
                    OnClick="imbReset_Click" ToolTip="แสดงทั้งหมด" /></td>
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
                <uc2:PageControl ID="pcTop" runat="server" OnPageChange="PageChange" />
                 <asp:GridView ID="gvMain" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="t_tablestyle" OnRowDataBound="gvMain_RowDataBound" OnSorting="gvMain_Sorting" AllowPaging="True" PageSize="20" style="width:100%;">
                    <Columns>
                        <asp:BoundField DataField="LOID" HeaderText="LOID">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                         <asp:TemplateField>
                            <HeaderTemplate >
                                <input type="checkbox" name="chkMain" id="chkMain" onclick="chkAllBox(this, 'ctl00_MainContent_gvMain_ctl', '_chkSelect')" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelect" runat="server" />
                            </ItemTemplate>
                            <HeaderStyle CssClass="zHidden" HorizontalAlign="Center" Width="30px" />
                            <ItemStyle CssClass="zHidden" HorizontalAlign="Center" Width="30px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ลำดับ" SortExpression="DEFAULT">
                            <HeaderStyle Width="100px" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="เดือน ปี" SortExpression="RIGHTMONTHYEAR">
                            <ItemTemplate>                    
                                <asp:LinkButton ID="lnkCode" runat="server" Text='<%# Bind("RIGHTMONTHYEAR") %>' OnClick= "linkCode_Click" CommandArgument='<%# Bind("LOID")  %>'></asp:LinkButton>                       
                             </ItemTemplate> 
                            <HeaderStyle HorizontalAlign="Center"/>
                       </asp:TemplateField>
                        <asp:BoundField  DataField="QTYDATE" HeaderText="จำนวนวันทำการ" SortExpression="QTYDATE">
                        <HeaderStyle HorizontalAlign="Center" Width="200px" />
                            <ItemStyle HorizontalAlign="Center" Width="200px" />
                          </asp:BoundField>
                 
                        
                        </Columns> 
                         <HeaderStyle CssClass="t_headtext" />  
                    <AlternatingRowStyle CssClass="t_alt_bg" />
                    <PagerSettings Visible="False" />
                        </asp:GridView> <uc2:PageControl ID="pcBot" runat="server" OnPageChange="PageChange" />
                        </td> 
                        </tr> 
         </table> 

</asp:Content>



