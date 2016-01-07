<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="Officer.aspx.cs" Inherits="App_Admin_Master_Officer" Title="SHND - Officer" %>
<%@ Register Src="../../Templates/BoxControl.ascx" TagName="BoxControl" TagPrefix="uc4" %>
<%@ Register Src="../../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc3" %>
<%@ Register Src="../../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../../Search/WardPopup.ascx" TagName="WardPopup" TagPrefix="uc3" %>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">

<table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
           <td class="headtext">
               ผู้ใช้และสิทธิ์การใช้งาน</td>
                    
    </tr>
    <tr>  
        <td style="width: 25778px">
                <uc1:ToolBarItemCtl ID="tbAdd" runat="server" ToobarTitle="เพิ่มข้อมูล" OnClick="tbAddClick"   ToolbarImage="../../Images/icn_add.png"  />
            &nbsp;
               
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
            
             <table cellspacing="0" cellpadding="3" border="0" width="100%">
                    <tr style="height:15px">
                        <td colspan="2">&nbsp;</td>
                    </tr>
                 <tr>
                     <td style="padding-right: 10px; width: 120px; text-align: right">
                         ชื่อเข้าระบบ :</td>
                     <td style="height: 22px">
                         <asp:TextBox ID="txtSUserID" runat="server" CssClass="zTextbox" MaxLength="100" Width="150px"></asp:TextBox></td>
                 </tr>
                 <tr>
                     <td style="padding-right: 10px; width: 120px; text-align: right">
                         ชื่อผู้ใช้ :</td>
                     <td style="height: 22px">
                         <asp:TextBox ID="txtSFName" runat="server" CssClass="zTextbox" MaxLength="100" Width="150px"></asp:TextBox></td>
                 </tr>
                 <tr>
                     <td style="padding-right: 10px; width: 120px; text-align: right">
                         นามสกุล :</td>
                     <td style="height: 22px">
                         <asp:TextBox ID="txtSLName" runat="server" CssClass="zTextbox" MaxLength="100" Width="150px"></asp:TextBox></td>
                 </tr>
                 <tr>
                     <td style="padding-right: 10px; width: 120px; text-align: right">
                         หน่วยงาน :</td>
                     <td style="height: 22px">
                        <asp:DropDownList ID="cmbSDivision" runat="server" CssClass="zComboBox" Width="280px">
                        </asp:DropDownList></td>
                 </tr>
                    
                    <tr>
                        <td style="width:120px; text-align: right; padding-right:10px">
                            ระดับการใช้งาน :</td>
                        <td style="height: 22px">
                        <asp:DropDownList ID="cmbSGroup" runat="server" CssClass="zComboBox" Width="150px">
                            <asp:ListItem Value="">ทั้งหมด</asp:ListItem>
                            <asp:ListItem Value="O">หน่วยงานอื่นๆ</asp:ListItem>
                            <asp:ListItem Value="U">ฝ่ายโภชนาการ</asp:ListItem>
                            <asp:ListItem Value="N">พยาบาล</asp:ListItem>
                            <asp:ListItem Value="M">หมอ</asp:ListItem>
                            <asp:ListItem Value="A">ผู้ดูแลระบบ</asp:ListItem>
                        </asp:DropDownList>
                            &nbsp;
                        &nbsp; &nbsp;&nbsp;
                            <asp:ImageButton ID="imbSearch" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_find.png"
                         OnClick="imbSearch_Click1"  />&nbsp;
                        <asp:ImageButton ID="imbReset" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_back.png"
                         OnClick="imbReset_Click" ToolTip="แสดงทั้งหมด" Visible = "false"  />
                         </td>
                        </tr>
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
            <td >
                <uc2:PageControl ID="pcTop" runat="server"  Visible = "false" OnPageChange="PageChange" />
                   <asp:GridView ID="gvMain" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="t_tablestyle"   OnRowDataBound="gvMain_RowDataBound" OnSorting="gvMain_Sorting"  AllowPaging="True" PageSize="20" style="width:100%;" OnRowDeleting="gvMain_RowDeleting" >
                    <Columns>
                        <asp:BoundField DataField="LOID" HeaderText="LOID">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                         <asp:TemplateField>
                            <ItemTemplate>
                            <asp:ImageButton ID="imbDelete" runat="server" CausesValidation="true" CommandName="Delete" ImageUrl="~/Images/icn_delete.png" OnClientClick="return confirm('ต้องการลบข้อมูล ใช่หรือไม่?')"  CommandArgument='<%# Bind("LOID")  %>'  OnClick="tbDeleteClick" />&nbsp;
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="30px" />
                            <ItemStyle HorizontalAlign="Center" Width="30px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ลำดับ" SortExpression="DEFAULT">
                            <HeaderStyle Width="60px" />
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </asp:TemplateField>
                       <asp:TemplateField HeaderText="ชื่อเข้าระบบ" SortExpression="USERNAME">
                            <ItemTemplate>                      
                            <asp:LinkButton ID="lnkCode" runat="server" Text='<%# Bind("USERNAME") %>' CommandArgument='<%# Bind("LOID")  %>' OnClick= "linkCode_Click"  ></asp:LinkButton>
                            </ItemTemplate> 
                           <HeaderStyle Width="150px" />
                           <ItemStyle Width="150px" />
                      </asp:TemplateField>
                        <asp:BoundField  DataField="OFFICERNAME" HeaderText="ชื่อผู้ใช้" SortExpression="OFFICERNAME">
                            <HeaderStyle HorizontalAlign="Center" />
                          </asp:BoundField>
                        <asp:BoundField DataField="DIVISIONNAME" HeaderText="หน่วยงาน" SortExpression="DIVISION">
                            <HeaderStyle Width="150px" />
                            <ItemStyle Width="150px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="ระดับการใช้งาน" SortExpression="OFFICERGROUP" DataField="OFFICERGROUP">
                            <HeaderStyle Width="130px" />
                            <ItemStyle Width="130px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="LASTLOGON" DataFormatString="{0:d MMM yyyy [HH:mm]}" HeaderText="วันที่ใช้งานล่าสุด"
                            HtmlEncode="False" SortExpression="LASTLOGON">
                            <HeaderStyle Width="120px" />
                            <ItemStyle Width="120px" />
                        </asp:BoundField>
                          </Columns> 
                         <HeaderStyle CssClass="t_headtext" />  
                    <AlternatingRowStyle CssClass="t_alt_bg" />
                    <PagerSettings Visible="False" />
                        </asp:GridView> <uc2:PageControl ID="pcBot" runat="server"   Visible = "false"  OnPageChange="PageChange" />
                        </td> 
                        </tr> 
         </table> 
<cc1:ModalPopupExtender ID="zPop" runat="server" TargetControlID="tbAdd$lb" PopupControlID="Panel1" BackgroundCssClass="modalBackground" DropShadow="true"></cc1:ModalPopupExtender>
    <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" style="display:none" Width="800px" Height="600px" ScrollBars="Auto">
    <table cellspacing="0" cellpadding="0" border="0" width="100%">
        
        <tr>
            <td>
            <uc1:ToolBarItemCtl ID="tbSave" runat="server" ToobarTitle="บันทึก" ToolbarImage="../../Images/save2.png" OnClick="tbSaveClick"   />
            <uc1:ToolBarItemCtl ID="tbCancel" runat="server" ToobarTitle="ยกเลิกการแก้ไข" ToolbarImage="../../Images/cancel.png"  OnClick="tbCancelClick"   />
            <uc1:ToolBarItemCtl ID="tbBack" runat="server" ToobarTitle="กลับหน้ารายการ" ToolbarImage="../../Images/icn_back.png" OnClick="tbBackClick" />
            </td>
        </tr>
        <tr>
            <td><hr style="size:1px" /></td>
        </tr>
        <tr>
            <td>
            <table width="90%" align="center" cellpadding="5" cellspacing="0" border="0">
                <tr>
                    <td align="right" style="width: 150px; height: 15px">
                        <asp:TextBox ID="txhID" runat="server" Visible="False" Width="15px"></asp:TextBox>
                        <asp:TextBox ID="txhSortDir" runat="server" Visible="False" Width="15px"></asp:TextBox>
                        <asp:TextBox ID="txhSortField" runat="server" Visible="False" Width="15px"></asp:TextBox></td>
                    <td style="height: 15px">
                        <asp:Label ID="lbStatus" runat="server" EnableViewState="False"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width:150px; height: 15px;" align="right">
                        ชื่อผู้ใช้ :</td>
                    <td style="height: 15px">
                        <asp:DropDownList ID="cmbTitle" runat="server" CssClass="zComboBox" Width="100px">
                        </asp:DropDownList>&nbsp;
                        <asp:TextBox ID="txtFName" runat="server" CssClass="zTextbox" MaxLength="100" Width="150px"></asp:TextBox>
                        <asp:TextBox ID="txtLName" runat="server" CssClass="zTextbox" MaxLength="100" Width="150px"></asp:TextBox>
                        <span style="color: #ff0000">*</span></td>
                </tr>
                <tr>
                    <td align="right" style="width: 150px; height: 15px">
                        หน่วยงาน :</td>
                    <td style="height: 15px"><asp:DropDownList ID="cmbDivision" runat="server" CssClass="zComboBox" Width="280px">
                    </asp:DropDownList>
                        <span style="color: #ff0000">*</span></td>
                </tr>
                <tr>
                    <td align="right" style="width: 150px; height: 15px">
                        เบอร์โทร :</td>
                    <td style="height: 15px">
                        <asp:TextBox ID="txtPhone" runat="server" CssClass="zTextbox" Width="200px" MaxLength="50"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right" style="width: 150px; height: 15px">
                        E-Mail :</td>
                    <td style="height: 15px">
                        <asp:TextBox ID="txtEMail" runat="server" CssClass="zTextbox" Width="200px" MaxLength="100"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right" style="width: 150px; height: 15px">
                    </td>
                    <td style="height: 15px">
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 150px; height: 15px">
                        ชือเข้าระบบ :</td>
                    <td style="height: 15px">
                        <asp:TextBox ID="txtUserName" runat="server" CssClass="zTextbox" Width="150px" MaxLength="30"></asp:TextBox>
                        <span style="color: #ff0000">*</span></td>
                </tr>
                <tr>
                    <td align="right" style="width: 150px; height: 15px">
                        รหัสผ่าน :</td>
                    <td style="height: 15px">
                        <asp:TextBox ID="txtPasswd" runat="server" CssClass="zTextbox" Width="150px" MaxLength="20" TextMode="Password"></asp:TextBox>
                        <asp:Label ID="lblPasswordNeed" runat="server" ForeColor="Red" Text="*"></asp:Label></td>
                </tr>
                <tr>
                    <td align="right" style="width: 150px; height: 15px">
                        ระดับการใช้งาน :</td>
                    <td style="height: 15px"><asp:DropDownList ID="cmbUserGroup" runat="server" CssClass="zComboBox" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="cmbUserGroup_SelectedIndexChanged">
                        <asp:ListItem>เลือก</asp:ListItem>
                        <asp:ListItem Value="O">หน่วยงานอื่นๆ</asp:ListItem>
                        <asp:ListItem Value="U">ฝ่ายโภชนาการ</asp:ListItem>
                        <asp:ListItem Value="N">พยาบาล</asp:ListItem>
                        <asp:ListItem Value="M">หมอ</asp:ListItem>
                        <asp:ListItem Value="A">ผู้ดูแลระบบ</asp:ListItem>
                    </asp:DropDownList>
                        <span style="color: #ff0000">*</span></td>
                </tr>
                <tr>
                    <td align="right" style="width: 150px; height: 15px">
                        </td>
                    <td style="height: 15px">
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 150px; height: 15px">
                        วันที่เริ่มต้นใช้งาน :</td>
                    <td style="height: 15px">
                        <uc3:CalendarControl ID="dtpEFDate" runat="server" />
                        &nbsp; <span style="color: #ff0000">*</span></td>
                </tr>
                <tr>
                    <td align="right" style="width: 150px; height: 15px">
                        วันที่สิ้นสุดการใช้งาน :</td>
                    <td style="height: 15px">
                        <uc3:CalendarControl ID="dtpEPDate" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 150px; height: 15px">
                        ระงับการใช้งาน :</td>
                    <td style="height: 15px">
                        <asp:CheckBox ID="chkDisable" runat="server" Text="เช็คเพื่อระงับการใช้งานของผู้ใช้" /></td>
                </tr>
                <tr>
                    <td align="right" style="width: 150px; height: 15px">
                        วันที่เข้าระบบล่าสุด :</td>
                    <td style="height: 15px">
                        <asp:TextBox ID="txtLastLogon" runat="server" CssClass="zTextbox-View" Width="150px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right" style="width: 150px; height: 15px">
                        วันที่เปลี่ยนรหัสผ่านล่าสุด :</td>
                    <td style="height: 15px">
                        <asp:TextBox ID="txtLastChangePW" runat="server" CssClass="zTextbox-View" Width="150px"></asp:TextBox>
                        &nbsp;
                        <asp:CheckBox ID="chkForceChangePw" runat="server" Checked="True" Text="บังคับให้เปลี่ยนรหัสผ่านเมื่อเข้าระบบครั้งต่อไป" /></td>
                </tr>
            </table>
            </td>
        </tr>
        <tr>
            <td>
                <hr style="size:1px" />
                &nbsp;</td>
        </tr>
        <tr>
            <td style="padding-right: 20px; padding-left: 20px; padding-bottom: 20px; padding-top: 20px">
                <cc1:TabContainer ID="tabRole" runat="server" ActiveTabIndex="0">
                    <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                        <ContentTemplate>
                            <br />
                            <strong>กำหนดรายละเอียดกลุ่มของเมนู<br />
                            </strong>
                            <br />
                            <table cellpadding="5" align="center">
                                <tr style="background-color:#eeeeee">
                                    <td colspan="2" style="padding-top:10px; padding-bottom:15px;" align="center">
                                        <uc4:BoxControl ID="z2Group" runat="server" txtDestHead="กลุ่มที่มีสิทธิ์" txtSourceHead="กลุ่มทั้งหมด"  />
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                        <HeaderTemplate>
                            กำหนดกลุ่มเมนู
                        </HeaderTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                        <ContentTemplate>
                            <br />
                            <strong>กำหนดรายละเอียดสิทธิ์ในการใช้เมนู<br />
                                <br />
                            </strong>
                            <table cellpadding="5" align="center">
                                <tr style="background-color:#eeeeee">
                                   <td colspan="2" style="padding-top:10px; padding-bottom:15px;" align="center">
                                    <uc4:BoxControl ID="z2Menu" runat="server" txtDestHead="เมนูที่มีสิทธิ์" txtSourceHead="เมนูทั้งหมด"  />
                                  </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                        <HeaderTemplate>
                            กำหนดรายละเอียดสิทธิ์ในการใช้เมนู
                        </HeaderTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="tabWard" runat="server" HeaderText="TabPanel2">
                        <ContentTemplate>
                            <br />
                            <strong>กำหนดหอผู้ป่วยที่รับผิดชอบ<br />
                                <br />
                            </strong>
                            <table Width="100%">
                                <tr>
                                    <td class="toolbarplace">
                                        <uc1:ToolBarItemCtl ID="tbAddWard" runat="server" ToobarTitle="เพิ่มหอผู้ป่วย" ToolbarImage="../../Images/icn_add.png" OnClick="tbAddWardClick" />
                                        <uc1:ToolBarItemCtl ID="tbDeleteWard" runat="server" ToobarTitle="ลบหอผู้ป่วย" ToolbarImage="../../Images/icn_delete.png" OnClick="tbDeleteWardClick" />
                                    </td>
                                </tr></table>
                            <table cellpadding="5" align="center">

                                <tr style="background-color:#eeeeee">
                                   <td colspan="2" style="padding-top:10px; padding-bottom:15px;" align="center">
                                    <asp:GridView ID="gvward" runat="server" AutoGenerateColumns="False" CssClass="t_tablestyle" DataSourceID="WardSource" 
                                            DataKeyNames="WARD" Width="100%">
                                            <Columns>
                                                <asp:BoundField DataField="WARD" HeaderText="WARD">
                                                    <ControlStyle CssClass="zHidden" />
                                                    <FooterStyle CssClass="zHidden" />
                                                    <HeaderStyle CssClass="zHidden" />
                                                    <ItemStyle CssClass="zHidden" />
                                                </asp:BoundField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <input type="checkbox" name="chkMain" id="chkMain" onclick="chkAllBox(this, 'ctl00_MainContent_tabRole_tabWard_gvWard_ctl', '_chkSelect')" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkSelect" runat="server"/>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" Width="30px" />
                                                    <ItemStyle HorizontalAlign="Center" Width="30px" VerticalAlign="Top" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="ลำดับ">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex +1 %>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="zHidden"  Width="50px" />
                                                    <ItemStyle CssClass="zHidden" HorizontalAlign="Center" Width="50px" Height="24px" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="WARDNAME" HeaderText="หอผู้ป่วย">
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="ลำดับ">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtorder" runat="server" Width="95px" Text='<%# Eval("PRIORITY").ToString() %>' 
                                                            CssClass="zTextboxR"></asp:TextBox> 
                                                    </ItemTemplate>
                                                    <ItemStyle Width="100px" HorizontalAlign="Right" />
                                                    <HeaderStyle Width="100px" />  
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="ค่าเริ่มต้น">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkDefault" runat="server" Checked='<%# Convert.ToString(Eval("ISDEFAULT")) == "1" %>' onclick="javascript:SelectCheckboxes(this);"  />
                                                    </ItemTemplate>
                                                    <ItemStyle Width="80px" HorizontalAlign="Center" />
                                                    <HeaderStyle Width="80px" />  
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="ใช้งาน">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkActive" runat="server" Checked='<%# Convert.ToString(Eval("ACTIVE")) == "1" %>' />
                                                    </ItemTemplate>
                                                    <ItemStyle Width="80px" HorizontalAlign="Center" />
                                                    <HeaderStyle Width="80px" />  
                                                </asp:TemplateField>
                                            </Columns>
                                            <HeaderStyle CssClass="t_headtext" />
                                            <AlternatingRowStyle CssClass="t_alt_bg" />
                                            <PagerSettings Visible="False" />
                                        </asp:GridView>
                                        <asp:ObjectDataSource ID="WardSource" runat="server" SelectMethod="GetWardList" TypeName="WardDetailItem">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="txhID" DefaultValue="0" Name="officer" PropertyName="Text"
                                                    Type="Double" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                  </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                        <HeaderTemplate>
                            กำหนดหอผู้ป่วยที่รับผิดชอบ
                        </HeaderTemplate>
                    </cc1:TabPanel>
                </cc1:TabContainer>
        </tr>
        <tr>
            <td align="center">
            </td>
        </tr>
    </table>
   <uc3:WardPopup id="ctlWardPopup" runat="server" OnSelectedIndexChanged="ctlWardPopup_SelectedIndexChanged" OnCancel="ctlWardPopup_Cancel">
    </uc3:WardPopup>

</asp:Panel>
 <script language="javascript" type="text/javascript">
function SelectCheckboxes(e)
{
    if(e.checked)
   {
	    elm=document.aspnetForm.elements;
	    for(i=0;i<elm.length;i++)
	    if(elm[i].type=="checkbox"&& elm[i].id!=e.id)
	    {
			if(elm[i].id.indexOf("chkDefault") >= 0)
				elm[i].checked=false;
		}
   }
}
</script>
</asp:Content>

