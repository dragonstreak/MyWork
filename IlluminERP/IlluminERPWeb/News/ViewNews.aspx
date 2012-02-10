<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ViewNews.aspx.vb" Inherits="ViewNews" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
	<telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <script src="../js/validation.js" type="text/javascript"></script>
    <script src="../js/operation.js" type="text/javascript"></script>

    <script language="javascript">
        function CloseWindow() {
            this.close();
        }
    </script>
</head>
<body class="newsbody">
    <form id="form1" runat="server">
	<telerik:RadScriptManager ID="RadScriptManager1" runat="server">
		<Scripts>
			<%--Needed for JavaScript IntelliSense in VS2010--%>
			<%--For VS2008 replace RadScriptManager with ScriptManager--%>
			<asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
			<asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
			<asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
		</Scripts>
	</telerik:RadScriptManager>
	<script type="text/javascript">
		//Put your JavaScript code here.
    </script>
	<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
	</telerik:RadAjaxManager>
	<div>
        <div style="border:1px solid #000000; width:720px; max-width:1024px; min-width:600px; padding:1em 2em; background-color:#F5FFFA; margin:auto">
            <div style="text-align:center; ">
            <asp:Label ID="lblTitle" CssClass="newstitle" runat="server"></asp:Label>
            </div>        
            <div style="text-align: left; ">
            <%=NewsBasicInfo %>
            </div>
            <div style="text-align: left; ">
            <%= NewsContent%>
            </div>
            <div>
                <input type="button" name="btnCancel" value="Close" class="btnclose" onclick="javascript:CloseWindow();" />
            </div>
        </div>
	</div>
	</form>
</body>
</html>
