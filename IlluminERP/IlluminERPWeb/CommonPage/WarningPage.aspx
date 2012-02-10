<%@ Page Language="VB" AutoEventWireup="false" CodeFile="WarningPage.aspx.vb" Inherits="CommonPage_WarningPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ERP Alert</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <img src="../Images/warning.gif" />&nbsp;&nbsp;Error Information<br />
        <hr />
    
    </div>
        <asp:Label ID="lblWarningMessage" runat="server" Font-Names="Arial" Font-Size="10pt"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblContact" runat="server" Font-Names="Arial" Font-Size="10pt" ForeColor="Blue"></asp:Label>
    </form>
</body>
</html>
