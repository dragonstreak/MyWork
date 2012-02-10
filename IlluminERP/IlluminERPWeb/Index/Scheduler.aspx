<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Scheduler.aspx.vb" Inherits="Index_Scheduler" %>

<%@ Register src="../Ascx/UserScheduler.ascx" tagname="UserScheduler" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <uc1:UserScheduler ID="UserScheduler1" runat="server" />
    
    </div>
    </form>
</body>
</html>
