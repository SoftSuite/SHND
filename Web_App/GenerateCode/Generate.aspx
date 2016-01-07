<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Generate.aspx.cs" Inherits="Generate_Generate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Generate</title>
    <link href="../Templates/BaseStyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </ajaxToolkit:ToolkitScriptManager>
        <asp:UpdatePanel ID="updMain" runat="server">
            <ContentTemplate>
                <table border="0" width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <table border="0" width="900px" cellpadding="0" cellspacing="0" style="border-right: #0099ff 1px solid; border-top: #0099ff 1px solid; border-left: #0099ff 1px solid; border-bottom: #0099ff 1px solid; background-color:#E0FFFF">
                                <tr>
                                    <td style="height:25px; width:10px"></td>
                                    <td colspan="5">
                                        <asp:RadioButton ID="rdbSql" runat="server" Text="Sql Server" GroupName="Type" />&nbsp;&nbsp;
                                        &nbsp;
                                        <asp:RadioButton ID="rdbOracle" runat="server" Text="Oracle" GroupName="Type" Checked="True" /></td>
                                    <td align="right" style="width: 218px">
                                        &nbsp;
                                    </td>
                                    <td style="width:10px"></td>
                                </tr> 
                                <tr>
                                    <td style="width:10px"></td>
                                    <td colspan="6"><hr />
                                        <ajaxToolkit:TextBoxWatermarkExtender ID="txtServerWatermark" runat="server" TargetControlID="txtServer" WatermarkCssClass="water" >
                                        </ajaxToolkit:TextBoxWatermarkExtender>
                                        <ajaxToolkit:TextBoxWatermarkExtender ID="txtDatabaseWatermark" runat="server" TargetControlID="txtDatabase" WatermarkCssClass="water">
                                        </ajaxToolkit:TextBoxWatermarkExtender>
                                        <ajaxToolkit:TextBoxWatermarkExtender ID="txtUserIDWatermark" runat="server" TargetControlID="txtUserID" WatermarkCssClass="water">
                                        </ajaxToolkit:TextBoxWatermarkExtender>
                                        <ajaxToolkit:TextBoxWatermarkExtender ID="txtPasswordWatermark" runat="server" TargetControlID="txtPassword" WatermarkCssClass="water">
                                        </ajaxToolkit:TextBoxWatermarkExtender>
                                        <ajaxToolkit:TextBoxWatermarkExtender ID="txtTableWatermark" runat="server" TargetControlID="txtTable" WatermarkCssClass="water">
                                        </ajaxToolkit:TextBoxWatermarkExtender>
                                        <ajaxToolkit:TextBoxWatermarkExtender ID="txtNamespaceWatermark" runat="server" TargetControlID="txtNamespace" WatermarkCssClass="water">
                                        </ajaxToolkit:TextBoxWatermarkExtender>
                                        <ajaxToolkit:TextBoxWatermarkExtender ID="txtClassWatermark" runat="server" TargetControlID="txtClass" WatermarkCssClass="water">
                                        </ajaxToolkit:TextBoxWatermarkExtender>
                                    </td>
                                    <td style="width:10px"></td>
                                </tr> 
                                <tr>
                                    <td style="height:25px; width:10px"></td>
                                    <td style="width:85px">
                                        Data Source</td>
                                    <td style="width:240px" align="right">
                                        <asp:TextBox ID="txtServer" runat="server" Width="190px" CssClass="zTextbox">SHND</asp:TextBox></td>
                                    <td style="width:40px"></td>
                                    <td style="width:85px">
                                        Database</td>
                                    <td style="width: 220px">
                                        <asp:TextBox ID="txtDatabase" runat="server" Width="190px" CssClass="zTextbox"></asp:TextBox></td>
                                    <td style="width: 218px"></td>
                                    <td style="width:10px"></td>
                                </tr> 
                                <tr>
                                    <td style="height:25px; width:10px"></td>
                                    <td style="width:85px">
                                        User ID</td>
                                    <td style="width:240px" align="right">
                                        <asp:TextBox ID="txtUserID" runat="server" Width="190px" CssClass="zTextbox">shndadmin</asp:TextBox></td>
                                    <td style="width:40px"></td>
                                    <td style="width:85px">
                                        Password</td>
                                    <td style="width: 220px">
                                        <asp:TextBox ID="txtPassword" runat="server" Width="190px" CssClass="zTextbox">!shnd!</asp:TextBox></td>
                                    <td style="width: 218px"></td>
                                    <td style="width:10px"></td>
                                </tr> 
                                <tr>
                                    <td style="height:25px; width:10px"></td>
                                    <td style="width:85px">
                                        Table/View</td>
                                    <td style="width:240px" align="right">
                                        <asp:TextBox ID="txtTable" runat="server" Width="190px" CssClass="zTextbox"></asp:TextBox></td>
                                    <td style="width:40px"></td>
                                    <td style="width:85px"></td>
                                    <td style="width:220px"></td>
                                    <td style="width: 218px"></td>
                                    <td style="width:10px"></td>
                                </tr> 
                                <tr>
                                    <td style="width:10px"></td>
                                    <td colspan="6"><hr /></td>
                                    <td style="width:10px"></td>
                                </tr> 
                                <tr>
                                    <td style="height:25px; width:10px"></td>
                                    <td style="width:85px">
                                        Namespace</td>
                                    <td style="width:240px" align="right">
                                        [Project].[DAL/Data].<asp:TextBox ID="txtNamespace" runat="server" Width="110px" CssClass="zTextbox"></asp:TextBox></td>
                                    <td style="width:40px"></td>
                                    <td style="width:85px">
                                        Class Name</td>
                                    <td style="width: 220px">
                                        <asp:TextBox ID="txtClass" runat="server" Width="190px" CssClass="zTextbox"></asp:TextBox></td>
                                    <td style="width: 218px">
                                        <asp:Button ID="btnGenerateDAL" runat="server" OnClick="btnGenerateDAL_Click" Text="Generate DAL" CssClass="zButton" Width="100px" />
                                        <asp:Button ID="btnGenerateData" runat="server" OnClick="btnGenerateData_Click" Text="Generate Data" CssClass="zButton" Width="100px" /></td>
                                    <td style="width:10px"></td>
                                </tr> 
                                <tr>
                                    <td style="height:5px; width:10px"></td>
                                    <td style="width:85px"></td>
                                    <td style="width:240px"></td>
                                    <td style="width:40px"></td>
                                    <td style="width:85px"></td>
                                    <td style="width: 220px"></td>
                                    <td style="width: 218px"></td>
                                    <td style="width:10px"></td>
                                </tr> 
                            </table>
                        </td> 
                    </tr> 
                    <tr>
                        <td></td> 
                    </tr> 
                    <tr>
                        <td style="width:895px;">
                            <div id="up_container" >
                                <asp:UpdatePanel ID="updCode" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtCode" runat="server" Height="430px" TextMode="MultiLine" Width="895px" Wrap="False" BackColor="#FFFFC0" ReadOnly="true" CssClass="zTextbox" BorderColor="#C04000" BorderStyle="Solid" BorderWidth="1px" ></asp:TextBox>
                                        <asp:Label ID="lblTest" runat="server" Text=""></asp:Label>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnGenerateDAL" EventName="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="btnGenerateData" EventName="Click" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>  
                            <ajaxToolkit:UpdatePanelAnimationExtender ID="upae" BehaviorID="animation" runat="server" TargetControlID="updCode" >
                                <Animations>
                                    <OnUpdating>
                                        <Sequence>
                                            <ScriptAction Script="var b = $find('animation'); b._originalHeight = b._element.offsetHeight;" />
                                            <Parallel duration="0">
                                                <EnableAction AnimationTarget="btnGenerateDAL" Enabled="false" />
                                                <EnableAction AnimationTarget="btnGenerateData" Enabled="false" />
                                                <EnableAction AnimationTarget="rdbSql" Enabled="false" />
                                                <EnableAction AnimationTarget="rdbOracle" Enabled="false" />
                                                <EnableAction AnimationTarget="txtServer" Enabled="false" />
                                                <EnableAction AnimationTarget="txtDatabase" Enabled="false" />
                                                <EnableAction AnimationTarget="txtUserID" Enabled="false" />
                                                <EnableAction AnimationTarget="txtPassword" Enabled="false" />
                                                <EnableAction AnimationTarget="txtTable" Enabled="false" />
                                                <EnableAction AnimationTarget="txtNamespace" Enabled="false" />
                                                <EnableAction AnimationTarget="txtClass" Enabled="false" />
                                            </Parallel>
                                            <StyleAction Attribute="overflow" Value="hidden" /> 
                                           
                                            <%-- Do each of the selected effects --%>
                                            <Parallel duration="0" Fps="20">
                                                <Resize Height="0" /> 
                                            </Parallel>  
                                        </Sequence> 
                                    </OnUpdating>
                                    <OnUpdated>
                                        <Sequence>
                                            <%-- Do each of the selected effects --%>
                                            <Parallel duration=".25" Fps="30">
                                                <Condition ConditionScript="$get('effect_fade').checked">
                                                    <FadeIn AnimationTarget="up_container" minimumOpacity=".2" />
                                                </Condition>
                                                <Condition ConditionScript="$get('effect_collapse').checked">
                                                    <%-- Get the stored height --%>
                                                    <Resize HeightScript="$find('animation')._originalHeight" />
                                                </Condition>
                                                <Condition ConditionScript="$get('effect_color').checked">
                                                    <Color AnimationTarget="up_container" PropertyKey="backgroundColor"
                                                        StartValue="#FF0000" EndValue="#40669A" />
                                                </Condition>
                                            </Parallel>
                                            
                                            <%-- Enable all the controls --%>
                                            <Parallel duration="0">
                                                <EnableAction AnimationTarget="btnGenerateDAL" Enabled="true" />
                                                <EnableAction AnimationTarget="btnGenerateData" Enabled="true" />
                                                <EnableAction AnimationTarget="rdbSql" Enabled="true" />
                                                <EnableAction AnimationTarget="rdbOracle" Enabled="true" />
                                                <EnableAction AnimationTarget="txtServer" Enabled="true" />
                                                <EnableAction AnimationTarget="txtDatabase" Enabled="true" />
                                                <EnableAction AnimationTarget="txtUserID" Enabled="true" />
                                                <EnableAction AnimationTarget="txtPassword" Enabled="true" />
                                                <EnableAction AnimationTarget="txtTable" Enabled="true" />
                                                <EnableAction AnimationTarget="txtNamespace" Enabled="true" />
                                                <EnableAction AnimationTarget="txtClass" Enabled="true" />
                                            </Parallel>                            
                                        </Sequence>
                                    </OnUpdated>
                                </Animations> 
                            </ajaxToolkit:UpdatePanelAnimationExtender>
                        </td> 
                    </tr>
                </table> 
            </ContentTemplate> 
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
