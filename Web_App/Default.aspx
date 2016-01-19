<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sirirach Hospital Nutrient Department System</title>
    
<%--    <script type="text/javascript" language="javascript">
        function FullScreenWindow(){
            var params = [
                'height='+screen.height,
                'width='+screen.width,
                'fullscreen=yes' // only works in IE, but here for completeness
            ].join(',');
            var popup = window.open('SHNDMain.aspx', 'SHNDSYSTEM', params); 
            popup.moveTo(0,0);
            
            return false;
        }
    </script>--%>
</head>
<body>
    <form id="form1" runat="server">
        &nbsp;<div>
            Siriraj Hospital Nutrition Department System<br />
            <br />
            <a href="#" onclick="window.open('SHNDMain.aspx', 'SHNDSYSTEM', 'resizable=yes,scrollbars=yes,width=1015,height=700'); return false;">Click to Enter System</a></div>
    </form>
</body>
</html>
