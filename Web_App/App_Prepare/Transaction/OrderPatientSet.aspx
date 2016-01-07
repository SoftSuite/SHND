<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="OrderPatientSet.aspx.cs" Inherits="App_Prepare_Transaction_OrderPatientSet" Title="SHND : Transaction - Food Order Set" %>

<%@ Register Src="../Control/OrderPatientSetCtl.ascx" TagName="OrderPatientSetCtl"
    TagPrefix="uc6" %>

<%@ Register Src="../../Templates/CalendarControl.ascx" TagName="CalendarControl"
    TagPrefix="uc4" %>
<%@ Register Src="../../Search/MaterialMasterPopup.ascx" TagName="MaterialMasterPopup" TagPrefix="uc3" %>
<%@ Register Src="../../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table  border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="headtext">
                ข้อมูลการจัดอาหารสำรับ</td>
        </tr>
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbCut" runat="server" ToobarTitle="ตัดยอด" ToolbarImage="../../Images/icn_approve.png" />
                &nbsp; &nbsp;
                <uc1:ToolBarItemCtl ID="tbPrintReport" runat="server" ToobarTitle ="พิมพ์รายงานการสั่งอาหาร" ToolbarImage="../../Images/icn_print.png" />
                &nbsp; &nbsp;
                <uc1:ToolBarItemCtl ID="tbPrintSlip" runat="server" ToobarTitle ="พิมพ์ Slip" ToolbarImage="../../Images/icn_print.png"  />
                 &nbsp; &nbsp;
                 <uc1:ToolBarItemCtl ID="tbPrintNutrient" runat="server" ToobarTitle ="พิมพ์รายงานสารอาหารที่ได้รับ" ToolbarImage="../../Images/icn_print.png" Visible="false" />

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
                        ค้นหาข้อมูล
                    </legend>

                    <table cellspacing="0" cellpadding="0" border="0" style="width: 691px">
                        <tr style="height:15px">
                            <td colspan="5">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:117px; text-align: right; padding-right:10px; height: 24px;">หอผู้ป่วย :</td>
                            <td  style="height: 24px"><asp:DropDownList runat ="server" ID="cmbWard" CssClass="zCombo" Width ="285px" ></asp:DropDownList> </td>
                            
                        </tr>
                         <tr>
                            <td style="width:117px; text-align: right; padding-right:10px; height: 24px;">ประเภทอาหาร :</td>
                            <td style="height: 24px;" ><asp:DropDownList runat ="server" ID="cmbType" CssClass="zCombo" Width ="283px" ></asp:DropDownList></td>                        </tr>
                       <tr>
                            <td style="width:117px; text-align: right; padding-right:10px; height: 24px;">ชนิดอาหาร :</td>
                            <td style="height: 24px; "><asp:DropDownList runat ="server" ID="cmbCategory" CssClass="zCombo" Width ="283px" ></asp:DropDownList> </td>
                        </tr>
                         <tr style="height:24px">
                            <td style="width:117px; text-align: right; padding-right:10px; height: 24px;">ชื่่อ-สกุลผู้ป่วย :</td>
                            <td style="height: 24px">
                            <asp:TextBox ID="txtPatientName" runat="server" CssClass ="zTextbox" Width="350px"></asp:TextBox></td>                 
                        </tr>
                         <tr style="height:24px">
                            <td style="width:117px; text-align: right; padding-right:10px; height: 22px;">HN :</td>
                            <td style="height: 22px" ><asp:TextBox ID ="txtHN" runat="server" CssClass="zTextbox"></asp:TextBox>
                            &nbsp;&nbsp; &nbsp;&nbsp; AN : 
                            <asp:TextBox ID="txtAN" runat="server" CssClass="zTextbox" Width="58px"></asp:TextBox>
                            &nbsp;&nbsp; &nbsp;VN :
                            <asp:TextBox ID="txtVN" runat="server" CssClass="zTextbox"  Width="58px"></asp:TextBox></td>
                        </tr>
                        <tr style="height:24px">
                            <td style="width:117px; text-align: right; padding-right:10px; height: 24px;">วันที่สั่งอาหาร :</td>
                            <td style="height: 24px" ><uc4:CalendarControl ID="ctlOrderDate" runat="server" />
                            &nbsp;&nbsp;&nbsp;เวลา : 
                            <asp:TextBox ID="txtOrderTimeFrom" runat="server" CssClass="zTextbox" Width="58px"></asp:TextBox>
                            &nbsp;&nbsp; &nbsp; ถึง :
                            <asp:TextBox ID="txtOrderTimeTo" runat="server" CssClass="zTextbox"  Width="58px"></asp:TextBox></td>
                        </tr>
                        <tr  style="height:24px">
                            <td style="width:117px; text-align: right; padding-right:10px">วันที่ Register :</td>
                            <td  ><uc4:CalendarControl ID="ctlRegDate" runat="server" />
                            &nbsp;&nbsp;&nbsp;เวลา :
                           <asp:TextBox ID="txtRegTimeFrom" runat="server" CssClass="zTextbox" Width="58px"></asp:TextBox>&nbsp;&nbsp;&nbsp; &nbsp; ถึง :
                            <asp:TextBox ID="txtRegTimeTo" runat="server" CssClass="zTextbox"  Width="58px"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:ImageButton ID="imbSearch" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_find.png" OnClick="imbSearch_Click" />
                                &nbsp;
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
            <td>
                 <asp:Panel ID="pnlResult" runat="server" Width="100%" Visible="false" >
                  หน้า&nbsp;<asp:DropDownList ID="cmbPage" runat="server" AutoPostBack="True" CssClass="zComboBox" Width="40px" OnSelectedIndexChanged="cmbPage_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:Label ID="lblTotalPage" runat="server"></asp:Label>
                <br />    
                <br /> 
                
                <asp:Repeater ID="gvResult" runat="server" onItemDataBound="gvResult_ItemDataBound">
                <HeaderTemplate >
                    <table  border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse; border-color:White;" class="t_headtext">
                        <tr>
                        <td style="width: 40px;  "  align="center">
                            ลำดับ</td>
                        <td  style="width: 120px; " align="center">
                            หอผู้ป่วย</td>
                        <td  style="width: 40px;  " align="center">
                            ห้อง</td>
                        <td style=" width: 40px;  " align="center">
                            เตียง</td>
                        <td style="width: 100px;  " align="center">
                            HN</td>
                        <td style="width: 100px;  " align="center">
                            AN</td>
                        <td style="width: 100px;  " align="center">
                            VN</td>
                        <td style="width: 180px;  " align="center">
                            ชื่อ-สกุล</td>
                        <td style="width: 40px;   " align="center">
                            อายุ</td>
                        <td style="width: 40px;   " align="center">
                            น.น.</td>
                        <td style="width: 40px;   " align="center">
                            ส.ส.</td>
                        <td style="width: 60px;   " align="center">
                           BMI</td>
                        </tr>
                    </table>
                </HeaderTemplate>
                <ItemTemplate>
                    <table border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse; " class ="t_alt_bg">
                        <tr>
                        <td style=" width: 40px; vertical-align :top"  align="center">
                           <%#Eval("ORDERNO")%></td>
                        <td  style=" width: 120px; vertical-align :top " >
                            <%#Eval("WARDNAME")%></td>
                        <td  style=" width: 40px; vertical-align :top "  align="center">
                            <%#Eval("ROOMNO")%></td>
                        <td style=" width: 40px; vertical-align :top "  align="center">
                            <%#Eval("BEDNO")%></td>
                        <td style=" width: 100px; vertical-align :top "  align="center">
                            <%#Eval("HN")%></td>
                        <td style=" width: 100px; vertical-align :top " align="center">
                            <%#Eval("AN")%></td>
                        <td style=" width: 100px; vertical-align :top "  align="center">
                            <%#Eval("VN")%></td>
                        <td style=" width: 180px; vertical-align :top " >
                            <%#Eval("PATIENTNAME")%></td>
                        <td style=" width: 40px; vertical-align :top " align="center">
                            <asp:Label ID="lblAGE" runat="server" Text='<%#Eval("AGE")%>'></asp:Label></td>
                        <td style=" width: 40px; vertical-align :top "  align="center">
                            <%#Eval("WEIGHT")%></td>
                        <td style=" width: 40px; vertical-align :top "  align="center">
                            <%#Eval("HEIGHT")%></td>
                        <td style=" width: 60px; vertical-align :top " >
                            <%#Eval("BMI")%></td>
                        </tr>
                    </table>
                    <table border="0"  cellpadding="0" cellspacing="0">
                        <tr>
                            <td><uc6:OrderPatientSetCtl ID="OrderPatientSetCtl" runat="server"  GetOrderPatientSet='<%#Eval("ADMITPATIENT")%>' />
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
                 หน้า&nbsp;<asp:DropDownList ID="cmbPage2" runat="server" AutoPostBack="True" CssClass="zComboBox" Width="40px" OnSelectedIndexChanged="cmbPage2_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:Label ID="lblTotalPage2" runat="server"></asp:Label>
                </asp:Panel>        
            </td>
            
        </tr>
    </table>
    <cc1:ModalPopupExtender ID="CutPop" runat="server" TargetControlID="tbCut$lb" PopupControlID="PnlCut" BackgroundCssClass="modalBackground" DropShadow="true"></cc1:ModalPopupExtender>
    <asp:Panel ID="PnlCut" runat="server" CssClass="modalPopup" style="display:none" Width="500px">
    <table cellspacing="0" cellpadding="0" border="0" width="100%">
        <tr>
            <td>
        <uc1:ToolBarItemCtl ID="tbSave" runat="server" ToobarTitle="บันทึก" ToolbarImage="../../Images/save2.png" OnClick ="tbSaveClick"  />
        <uc1:ToolBarItemCtl ID="tbBack" runat="server" ToobarTitle="กลับหน้ารายการ" ToolbarImage="../../Images/icn_back.png" OnClick="tbBackClick" />
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
                        <td style="height:23px;">เวลา :</td>
                        <td style="height:23px"><asp:TextBox ID="txtTime" runat="server" Width ="100px"  CssClass="zTextbox-View" ReadOnly="true"></asp:TextBox> </td>
                        <td style="height:23px">Cut of Time</td>
                        <td style="height:23px;"><asp:TextBox ID="txtCutOfTime" runat="server" Width ="100px" CssClass="zTextbox-View" ReadOnly="true" ></asp:TextBox> </td>
                    </tr>
                </table>
                <br />
                <table >
                    <tr>
                        <td style="height:23px; width:80px"></td>
                        <td style="height:23px" align="right">จำนวน :</td>
                        <td ><asp:TextBox id="txtQty" runat="server" Width="100px" CssClass="zTextboxR-View" ReadOnly="true"></asp:TextBox>  คน
                        </td>
                    </tr>
                    <tr>
                        <td style="height:23px; width:80px"></td>
                        <td style="height:23px" align="right">มื้อ :</td>
                        <td ><asp:DropDownList ID="cmbMeal" runat="server" Width="108px" AutoPostBack="True" OnSelectedIndexChanged="cmbMeal_SelectedIndexChanged" ></asp:DropDownList>
                        <span style="color:Red" runat="server" >*</span>
                        </td>
                    </tr>
                    <tr>
                        <td style="height:23px; width:80px"></td>
                        <td style="height:23px" align="right">วันที่ :</td>
                        <td ><uc4:CalendarControl ID="ctlCheckTime" Enabled="false" runat="server" />
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



