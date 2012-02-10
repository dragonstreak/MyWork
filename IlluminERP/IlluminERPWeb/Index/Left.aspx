<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Left.aspx.vb" Inherits="Index_Left" %>

<%@ Register src="../Ascx/PanelBarMenu.ascx" tagname="PanelBarMenu" tagprefix="uc1" %>

<HTML>
<HEAD>
<title>left</title>
<script type="text/javascript" src="../JS/ig_shared.js"></script>
<script type="text/javascript" src="../JS/ig_webmenu.js"></script>
 <link href="../ExtJs/resources/css/ext-all.css" rel="stylesheet" type="text/css" />
    <link href="../ExtJs/resources/css/xtheme-gray.css" rel="stylesheet" type="text/css" />
    <script src="../ExtJs/adapter/ext/ext-base.js" type="text/javascript"></script>
    <script src="../ExtJs/ext-all-debug.js" type="text/javascript"></script>
    <script src="../JS/Ext.ux.util.js" type="text/javascript"></script>
    <script src="../JS/Ext.ux.grid.Search.js" type="text/javascript"></script>
    <script src="../JS/MessageJs/SendMessageWindow.js" type="text/javascript"></script>
    <script src="../JS/MessageJs/ShowMessageWindow.js" type="text/javascript"></script>
    <script src="../JS/MessageJs/NewMessageTip.js" type="text/javascript"></script>
    <script src="../JS/MessageJs/RollingMessage.js" type="text/javascript"></script>
<script language="javascript">
        Ext.onReady(function () {
            Ext.QuickTips.init();   
            var rollingMSG = new rollingMessage();
            rollingMSG.StartRolling();
        });
<!--
    function hide() {
        var menu = document.all.menu;
        var col = document.all.col;
        if (menu.style.display == "") {
            menu.style.display = "none";
            col.innerHTML = "&gt;";
        }
    }

    function show() {
        var menu = document.all.menu;
        var col = document.all.col;
        if (menu.style.display == "none") {
            menu.style.display = "";
            col.innerHTML = "&lt;";
        }
    }
//-->
</script>
<link href="../css/style.css" rel="stylesheet" type="text/css">
<style type="text/css">
<!--
	table.menu1{background: #D3E5FA; color: #000066; border: solid 1px #11599e; cursor: Default;}
	td.TopLevelStyle{font: normal normal normal 14px/normal "Arial", sans-serif; border: solid 1px #518CC5; padding: 4px;}
	td.TopLevelHover{font: normal normal normal 14px/normal "Arial", sans-serif; border: solid 1px AliceBlue; background: #518CC5; cursor: Default;}
-->
</style>
</HEAD>

<body class="left">
    <form id="Form1" runat="server">
<table width="100%" height="800px" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td width="130" id="menu" class="menu" valign="top">
			<!--开始了-->
			<table width="100%" border='0' cellpadding='4' cellspacing='1' 
				class="">
				<tr>
					<td align='left'  class="">
                        <uc1:PanelBarMenu ID="PanelBarMenu1" runat="server" />
                    </td>
				</tr>

			</table>
			
			<!--结束了-->
		</td>
		<td id="col" class="col" onclick="hide()" onmouseover="show()">&lt;</td>
		<td>
            <iframe name="content" frameborder="0" width="100%" height="100%" src="../index/HomePage.aspx"></iframe>
         </td>
	</tr>
</table>

<!--又开始了-->



<!--又结束了-->
    </form>
</body>
</HTML>