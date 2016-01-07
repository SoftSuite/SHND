<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register TagPrefix="CR" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SHND :: Reports</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <CR:CrystalReportViewer ID="ctlReportViewer" runat="server" AutoDataBind="false" Width="100%" Height="100%"
            DisplayGroupTree="False" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" EnableDrillDown="False" HasToggleGroupTreeButton="False" PrintMode="ActiveX" HasCrystalLogo="False" HasSearchButton="False" 
            HasViewList="False" OnUnload="ctlReportViewer_Unload"  />
    </div>
    </form>
</body>
</html>
