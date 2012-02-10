<%@ Page Language="VB" AutoEventWireup="false" CodeFile="NewsList.aspx.vb" Inherits="NewsList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
	<telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <script src="../js/operation.js" type="text/javascript"></script>
</head>
<body style="border:0px">
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
	<div class="newslist">
    <marquee behavior="scroll" direction="up" scrollamount="1" 
            scrolldelay="1" onmouseout="if (document.all!=null){this.start()}" 
            onmouseover="if (document.all!=null){this.stop()}">
    <%
        For i As Integer = 0 To dvNews.Count -1
					
            Dim row As System.Data.DataRowView = dvNews(i)
%>
    <%
If Convert.ToInt32(row("ReadRate")) > 200 then
            
%>
    <font color="red">hot!</font>
    <%
    End If
%>
    <a href='#' onclick="openWindow('../News/ViewNews.aspx?id= <%=row("NewsID")%>','big','ViewNews')" class="black" > <%=row("TITLE")%> </a> 
    <span style="width:20px"></span>
    <%  If Convert.IsDBNull(row("ModifiedTime")) Then %>
           <%= Convert.ToDateTime(row("CreatedTime")).ToLongDateString()%> 
      <%  Else %>
             <%= Convert.ToDateTime(row("ModifiedTime")).ToLongDateString()%>
       <% End If%>
    <span style="width:20px"></span>
    <%  If Convert.IsDBNull(row("ModifiedByName")) Then %>
           <% If Not Convert.IsDBNull(row("CreatedByName")) Then %>
               Publisher: <%= row("CreatedByName").ToString()%>
            <%End If %>
        <%  Else %>
               Publisher: <%= row("ModifiedByName").ToString()%>
        <%  End If%>
    <br/>
    <%
	 Next
%>
    </marquee>
    <!--
    <div align="right">
      <asp:HyperLink id="HLMoreNews" runat="server" CssClass="gray">more news</asp:HyperLink>
    </div>
    -->
  </div>
	</form>
</body>
</html>
