<%@ Page Language="VB" AutoEventWireup="false" CodeFile="NewsQuery.aspx.vb" Inherits="NewsQuery" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
	<telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
    <link href="../css/style.css" rel="stylesheet" type="text/css"/>
    <script src="../js/validation.js" type="text/javascript"></script>
    <script src="../js/operation.js" type="text/javascript"></script>
    <script type="text/javascript">
        //this function is used to open add user page
        var i = 0;
        //this method is used to get the random string.
        function getRandom() {
            var date = new Date();
            return Math.random() + "_" + date.getTime();
        }
        //this method is used to open add page.
        function OpenAddPage() {
            var randomStr = getRandom()
            var addResult = window.showModalDialog("News.aspx?OperateType=New&i=" + randomStr, window, 'dialogWidth=1024px;dialogHeight=768px;center:yes');
            if (addResult == 'success') {
                //refresh the grid,please take care of the control name, maybe not btnQuery.
                $("input[id$='btnQuery']").click();
            }
        }
        //this method is used to open modify page.
        function OpenModifyPage(id) {
            var randomStr = getRandom()
            var addResult = window.showModalDialog("News.aspx?OperateType=Modify&id=" + id + "&i=" + randomStr, window, 'dialogWidth=1024px;dialogHeight=768px;center:yes');
            if (addResult == 'success') {
                //refresh the grid,please take care of the control name, maybe not btnQuery.
                $("input[id$='btnQuery']").click();
            }
        }
    </script>
</head>
<body>
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
        <div class="title">News Query</div>
        <table width="100%" class="query" id="table1">
        <caption class="advover" onclick="adv(table1,main)">
            Query</caption>
        <tbody id="main">
            <tr>
                <td width="10%">
                    Title
                </td>
                <td width="20%">
                    <asp:TextBox ID="txtTitleQry" runat="server" CssClass="text"></asp:TextBox>
                </td>
                <td width="10%">
                    Type
                </td>
                <td width="20%">
                    <asp:DropDownList ID="ddlTypeQry" runat="server">
                    </asp:DropDownList>
                </td>
                <td width="10%">
                    Severity
                </td>
                <td width="30%">
                    <asp:DropDownList ID="ddlSeverityQry" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            
            <tr class="dgf">
                <td colspan="6">
                    <asp:Button ID="btnQuery" runat="server" CssClass="btnqry" Text="Query" />
                    &nbsp;<input type="reset" id="btnClear" value="Clear Condition" onclick="ClearCondition();" class="btnreset" />
                    &nbsp;<input type="button" name="btnAdd" value="Add News" class="btnadd" onclick="javascript:OpenAddPage()" />
                    
                </td>
            </tr>
        </tbody>
        </table>

        <div class="queryresultgrid">

        <telerik:RadGrid ID="gridResult" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" PageSize="2" GridLines="None" HorizontalAlign ="Left" >
            <ClientSettings AllowColumnsReorder="True" ReorderColumnsOnClient="True">
                <Selecting AllowRowSelect="True" />
                <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                
            </ClientSettings>

            <MasterTableView>
            <CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>

            <RowIndicatorColumn>
            <HeaderStyle Width="20px"></HeaderStyle>
            </RowIndicatorColumn>

            <ExpandCollapseColumn>
            <HeaderStyle Width="20px"></HeaderStyle>
            </ExpandCollapseColumn>
                <Columns>
                    <telerik:GridBoundColumn DataField="Title" HeaderText="Title" 
                        UniqueName="titleColumn">
                         <HeaderStyle Width="220px" />
                         <ItemStyle HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn HeaderText="News Type" DataField="NewsTypeName" UniqueName="typeColumn">
                     <HeaderStyle Width="100px" />
                      <ItemStyle HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn HeaderText="Severity Level" 
                        UniqueName="severityColumn">
                      <HeaderStyle Width="80px" />
                      <ItemStyle HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn HeaderText="Published" 
                        UniqueName="publishedColum">
                      <HeaderStyle Width="60px" />
                      <ItemStyle HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                     <telerik:GridBoundColumn HeaderText="CreatedBy" DataField="CreatedByName"
                        UniqueName="createdByColumn">     
                        <HeaderStyle Width="100px" />                 
                      <ItemStyle HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn HeaderText="CreatedTime" DataField="CreatedTime"
                        UniqueName="createdTimeColumn">     
                        <HeaderStyle Width="100px" />                 
                      <ItemStyle HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                     <telerik:GridBoundColumn HeaderText="ModifiedBy" DataField="ModifiedByName"
                        UniqueName="modifiedByColumn">     
                        <HeaderStyle Width="100px" />                 
                      <ItemStyle HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn HeaderText="ModifiedTime" DataField="ModifiedTime"
                        UniqueName="modifiedTimeColumn">     
                        <HeaderStyle Width="100px" />                 
                      <ItemStyle HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn HeaderText="Edit" UniqueName="editColumn">
                     <HeaderStyle Width="60px" />
                     <ItemStyle HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                     <telerik:GridBoundColumn HeaderText="ID" UniqueName="IDColumn" DataField="NewsID" Display="false">
                    </telerik:GridBoundColumn>
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>
        </div>

	</div>
	</form>
</body>
</html>
