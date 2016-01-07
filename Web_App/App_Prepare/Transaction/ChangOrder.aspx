<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="ChangOrder.aspx.cs" Inherits="App_Prepare_Transaction_ChangOrder" Title="SHND : Transaction - Change Order" %>

<%@ Register Src="ChangeOrder/ChangeorderCtl.ascx" TagName="ChangeorderCtl" TagPrefix="uc2" %>


<%@ Register Src="../../Templates/CalendarControl.ascx" TagName="CalendarControl"
    TagPrefix="uc3" %>


<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <table  border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="headtext" style="height: 30px">ข้อมูลการเปลี่ยนแปลงอาหาร</td>
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
                        ค้นหาข้อมูล
                    </legend>
                    <table cellspacing="0" cellpadding="0" border="0" style="width: 691px">
                        <tr style="height:15px">
                            <td colspan="5">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:117px; text-align: right; padding-right:10px; height: 24px;">หอผู้ป่วย :</td>
                            <td colspan="2" style="height: 24px"><asp:DropDownList runat ="server" ID="cmbWard" CssClass="zCombo" Width ="285px" ></asp:DropDownList> </td>
                            
                        </tr>
                        <tr>
                            <td style="width:117px; text-align: right; padding-right:10px; height: 24px;">ประเภทอาหาร :</td>
                            <td style="height: 24px; width: 304px;">OLD <asp:DropDownList runat ="server" ID="cmbOldType" CssClass="zCombo" Width ="150px" ></asp:DropDownList></td>
                            <td style="height: 24px;">NEW <asp:DropDownList runat ="server" ID="cmbNewType" CssClass="zCombo" Width ="150px" ></asp:DropDownList> </td>
                        </tr>
                       <tr>
                            <td style="width:117px; text-align: right; padding-right:10px; height: 24px;">ชนิดอาหาร :</td>
                            <td style="height: 24px; width: 304px;">OLD <asp:DropDownList runat ="server" ID="cmbOldCategory" CssClass="zCombo" Width ="150px" ></asp:DropDownList> </td>
                            <td style="height: 24px; ">NEW <asp:DropDownList runat ="server" ID="cmbNewCategory" CssClass="zCombo" Width ="150px" ></asp:DropDownList> </td>
                        </tr>
                         <tr style="height:24px">
                            <td style="width:117px; text-align: right; padding-right:10px; height: 24px;">ชื่่อ-สกุลผู้ป่วย :</td>
                            <td colspan="2" style="height: 24px">
                            <asp:TextBox ID="txtPatientName" runat="server" CssClass ="zTextbox" Width="480px"></asp:TextBox></td>                 
                        </tr>
                        <tr style="height:24px">
                            <td style="width:117px; text-align: right; padding-right:10px">วันที่สั่งอาหาร :</td>
                            <td style="width: 304px">
                                <uc3:CalendarControl ID="ctlOrderDate" runat="server" />
                                &nbsp; &nbsp; &nbsp; &nbsp;
                                &nbsp; &nbsp;
                            &nbsp;&nbsp;เวลา : 
                            <asp:TextBox ID="txtOrderTimeFrom" runat="server" CssClass="zTextboxR" Width="58px"></asp:TextBox></td>
                            <td>ถึง :
                                <asp:TextBox ID="txtOrderTimeTo" runat="server" CssClass="zTextboxR"  Width="58px"></asp:TextBox>
                                &nbsp; &nbsp;<asp:Label ID="label2" runat="server" Text="(Ex 08:00)" CssClass="zRemark"></asp:Label>
                            </td>
                        </tr>
                        <tr  style="height:24px">
                            <td style="width:117px; text-align: right; padding-right:10px">วันที่ยกเลิกอาหาร :</td>
                            <td style="width: 304px"  >
                                <uc3:CalendarControl ID="ctlEndDate" runat="server" />
                                &nbsp; &nbsp; &nbsp;
                                &nbsp; &nbsp; &nbsp; &nbsp; เวลา :
                           <asp:TextBox ID="txtEndTimeFrom" runat="server" CssClass="zTextboxR" Width="58px"></asp:TextBox></td>
                             <td>ถึง :
                            <asp:TextBox ID="txtEndTimeTo" runat="server" CssClass="zTextboxR"  Width="58px"></asp:TextBox>
                            &nbsp;&nbsp;
                           <asp:Label ID="label1" runat="server" Text="(Ex 08:00)" CssClass="zRemark"></asp:Label>
                           &nbsp;&nbsp;
                            <asp:ImageButton ID="imbSearch" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_find.png" OnClick="imbSearch_Click" />&nbsp;
                            </td>                 
                        </tr>
                    </table>   
            </fieldset>        
            </td>
        </tr>
        <tr>
            <td><uc1:ToolBarItemCtl ID="tbRegister" runat="server"   ToobarTitle ="Register" ToolbarImage="../../Images/icn_approve.png" />
            </td>
        </tr>
        <tr>
            <td >
                <asp:Label ID="lbStatusMain" runat="server" EnableViewState="False"></asp:Label>
            </td>
        </tr>
        
        <tr>
            <td align="right" style="width: 150px">
                <asp:TextBox ID="txhSortField" runat="server" Visible="False" Width="15px"></asp:TextBox><asp:TextBox
                    ID="txhSortDir" runat="server" Visible="False" Width="15px"></asp:TextBox><asp:TextBox
                        ID="txhID" runat="server" Visible="False" Width="15px"></asp:TextBox></td>
            <td style="height:15px">
                </td>
        </tr>
        <tr>
            <td>
                 <asp:Panel ID="pnlResult" runat="server" Width="100%" Visible="false" >
                  หน้า&nbsp;<asp:DropDownList ID="cmbPage" runat="server" AutoPostBack="True" CssClass="zComboBox" Width="40px" OnSelectedIndexChanged="cmbPage_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:Label ID="lblTotalPage" runat="server"></asp:Label>
                <br />    
                <br /> 
                
                <asp:Repeater ID="rptResult" runat="server">
                <HeaderTemplate >
                    <table border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse; border-color:White;" class="t_headtext">
                        <tr>
                        <td style=" width: 40px; " align="center">
                            ลำดับ</td>
                       <td  style="width: 40px; "  align="center">
                            <asp:CheckBox ID="chktop" runat="server"  OnCheckedChanged="ChkTopCheckedChanged" AutoPostBack ="true" /></td>
                        <td style="width: 120px;"  align="center">
                            หอผู้ป่วย</td>
                        <td style=" width: 40px;"  align="center">
                            ห้อง</td>
                        <td style=" width: 40px;"  align="center">
                            เตียง</td>
                        <td style=" width: 100px;" align="center">
                            HN</td>
                        <td style="width: 100px; " align="center">
                            AN</td>
                        <td style="width: 100px; " align="center">
                            VN</td>
                        <td style=" width: 180px;" align="center">
                            ชื่อ-สกุล</td>
                        <td style=" width: 40px; " align="center">
                            อายุ</td>
                        <td style=" width: 40px; " align="center">
                            น.น.</td>
                        <td style=" width: 40px; " align="center">
                            ส.ส.</td>
                        <td style=" width: 60px; " align="center">
                           BMI</td>
                        <td style=" width: 60px; display:none "  align="center">
                           ADMITPATIENT</td>
                        </tr>
                    </table>
                </HeaderTemplate>
                <ItemTemplate>
                    <table border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse;" class ="t_alt_bg">
                        <tr>
                        <td  style=" width: 40px; vertical-align :top" align="center">
                           <%#Eval("ORDERNO")%></td>
                        <td  style=" width: 40px; vertical-align :top" align="center" >
                            </td>
                        <td  style=" width: 120px; vertical-align:top" >
                            <%#Eval("WARDNAME")%></td>
                        <td  style=" width: 40px; vertical-align :top" align="center">
                            <%#Eval("ROOMNO")%></td>
                        <td style=" width: 40px; vertical-align :top"  align="center">
                            <%#Eval("BEDNO")%></td>
                        <td style=" width: 100px; vertical-align :top" align="center">
                            <%#Eval("HN")%></td>
                        <td style=" width: 100px; vertical-align :top" align="center">
                            <%#Eval("AN")%></td>
                        <td style=" width: 100px; vertical-align :top" align="center">
                            <%#Eval("VN")%></td>
                        <td style=" width: 180px; vertical-align :top" >
                            <%#Eval("PATIENTNAME")%></td>
                        <td style=" width: 40px; vertical-align :top"  align="center">
                            <%#Eval("AGE")%></td>
                        <td style=" width: 40px; vertical-align :top"  align="center">
                            <%#Eval("WEIGHT")%></td>
                        <td style=" width: 40px; vertical-align :top"  align="center">
                            <%#Eval("HEIGHT")%></td>
                        <td style=" width: 60px; vertical-align :top" >
                            <%#Eval("BMI")%></td>
                            
                         <td style=" width: 60px; vertical-align :top ;display:none"   >
                            <%#Eval("ADMITPATIENT")%></td>
                        </tr>
                    </table>
                    <table border="0"  cellpadding="0" cellspacing="0">
                        <tr>
                           <td><uc2:ChangeorderCtl ID="ctlChangOrder" runat="server" GetChangOrderCtl ='<%#Eval("ADMITPATIENT")%>' />

                           </td>
                        </tr>
                        <tr>
                            <td style="height:20px"></td>
                        </tr>
                    </table>
                        <hr style="height:1px; width:100%; color:#dddddd" />
                </ItemTemplate>
                <FooterTemplate>

                </FooterTemplate>
                </asp:Repeater>
                 หน้า&nbsp;<asp:DropDownList ID="cmbPage2" runat="server" AutoPostBack="True" CssClass="zComboBox" Width="40px" OnSelectedIndexChanged="cmbPage2_SelectedIndexChanged"></asp:DropDownList>
                 <asp:Label ID="lblTotalPage2" runat="server"></asp:Label>
                </asp:Panel>        
            </td>
            
        </tr>
    </table>
    <cc1:ModalPopupExtender ID="RegisterPop" runat="server" TargetControlID="tbRegister$lb" PopupControlID="pnlRegister" BackgroundCssClass="modalBackground" DropShadow="true"></cc1:ModalPopupExtender>
    <asp:Panel ID="pnlRegister" runat="server" CssClass="modalPopup" style="display:none" Width="600px">
    <table cellspacing="0" cellpadding="0" border="0" width="100%">
        <tr>
            <td>
        <uc1:ToolBarItemCtl ID="tbSave" runat="server" ToobarTitle="บันทึก" ToolbarImage="../../Images/save2.png" OnClick ="tbSaveClick"   />
        <uc1:ToolBarItemCtl ID="tbBack" runat="server" ToobarTitle="กลับหน้ารายการ" ToolbarImage="../../Images/icn_back.png" OnClick ="tbBackClick" />
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
                                <asp:TextBox ID="TextBox1" runat="server" Visible="False" Width="15px"></asp:TextBox><asp:TextBox
                                    ID="TextBox2" runat="server" Visible="False" Width="15px"></asp:TextBox><asp:TextBox
                                        ID="TextBox3" runat="server" Visible="False" Width="15px"></asp:TextBox>
                                    <asp:TextBox ID="txtConcat" runat="server"  Visible="False"  Width="15px" ></asp:TextBox>
                                 </td>
                            <td style="height:15px">
                                <asp:Label ID="lbStatus" runat="server" EnableViewState="False"></asp:Label></td>
                        </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table >
                    <tr>
                        <td style="height:23px; width:80px"></td>
                        <td style="height:23px" align="right">มื้อแรกที่จ่าย :</td>
                        <td ><asp:DropDownList ID="cmbMeal" runat="server" Width="108px"  ></asp:DropDownList>
                        <span id="Span1" style="color:Red" runat="server" >*</span>
                        </td>
                    </tr>
                    
                    <tr>
                        <td style="height:23px; width:80px"></td>
                        <td style="height:23px" align="right">วันที่ :</td>
                        <td >
                            <uc3:CalendarControl ID="ctlRegDate" runat="server"  />
                           
                            
                        </td>
                    </tr>
                </table>
                <br />
                <br />
            </td>
        </tr>
    </table>
    </asp:Panel>
</asp:Content>

