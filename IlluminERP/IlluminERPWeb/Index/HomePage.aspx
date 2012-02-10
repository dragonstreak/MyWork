<%@ Page Language="VB" MasterPageFile="~/Master/IlluminMasterPage.master" AutoEventWireup="false" CodeFile="HomePage.aspx.vb" Inherits="HomePage" %>

<asp:Content ID="ChildPageHead" ContentPlaceHolderID="head" runat="server">
	<title></title>
	<telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="ChildPageBody" ContentPlaceHolderID="PageContentPlaceHolder" runat="server">
    <form id="form1" runat="server" style="height:100%">
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
        <div>
            <iframe id="SchedulerFrame" name="SchedulerFrame" frameborder="0" scrolling="no" width="100%" height="420px" src="../index/Scheduler.aspx"></iframe>
        </div>
        <div style="margin:5px 0px; padding:5px; border:1px solid black">
            <iframe id="NewsFrame" name="NewsFrame" frameborder="0" width="100%" scrolling="no" height="160px" src="../news/NewsList.aspx"></iframe>
        </div>        
	</div>
	</form>
</asp:Content>
