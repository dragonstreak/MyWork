<%@ Page Language="VB" MasterPageFile="~/Master/IlluminMasterPage.master" AutoEventWireup="false" CodeFile="TeamQuery.aspx.vb" Inherits="User_TeamQuery" %>

<asp:Content ID="ChildPageHead" ContentPlaceHolderID="head" runat="server">
    <title>Team Query</title>
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <script src="../js/validation.js" type="text/javascript"></script>
    <script src="../js/operation.js" type="text/javascript"></script>
    <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server" />
    <script type="text/javascript">
        //this function is used to open add Team page
        var i = 0;
        function OpenAddTeamPage() {
            var randomStr = getRandom()
            var addResult = window.showModalDialog("Team.aspx?OperateType=New&i=" + randomStr, window, 'dialogWidth=660px;dialogHeight=530px');
            if (addResult == 'success') {
                //refresh the grid,please take care of the control name, maybe not btnQuery.
                $("input[id$='btnQuery']").click();
            }
        }
        function OpenModifyPage(id) {
            var randomStr = getRandom()
            var addResult = window.showModalDialog("Team.aspx?OperateType=Modify&Teamid=" + id + "&i=" + randomStr, window, 'dialogWidth=660px;dialogHeight=530px');
            if (addResult == 'success') {
                //refresh the grid,please take care of the control name, maybe not btnQuery.
                $("input[id$='btnQuery']").click();
            }
        }

        //this method is used to open assign role page.
        function OpenAssignRolePage(id) {
            var randomStr = getRandom()
            var result = window.showModalDialog("AssignRoleToTeam.aspx?OperateType=New&id=" + id + "&i=" + randomStr, window, 'dialogWidth=800px;dialogHeight=600px;center:yes');
        }

    </script>
</asp:Content>

<asp:Content ID="ChildPageBody" ContentPlaceHolderID="PageContentPlaceHolder" runat="server">
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
    <div class="title">
        Team Query
    </div>
    <table width="100%" class="query" id="table1">
        <caption class="advover" onclick="adv(table1,main)">
            Query</caption>
        <tbody id="main">
            <tr>
                <td width="15%">
                    Team Name:
                </td>
                <td width="35%">
                    <asp:TextBox ID="txtTeamName" runat="server" Width="200px" Font-Names="Arial" Font-Size="9pt"></asp:TextBox>
                </td>
                <td width="15%">
                    Sector:
                </td>
                <td width="35%">
                    <asp:DropDownList ID="ddlSector" runat="server" Width="200px" Font-Names="Arial" Font-Size="9pt" Height="21px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Parent Team:
                </td>
                <td>
                    <asp:DropDownList ID="ddlParent" runat="server" Width="200px" Font-Names="Arial" Font-Size="9pt" Height="21px">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:DropDownList ID="ddlCity" runat="server" Width="200px" Font-Names="Arial" 
                        Font-Size="9pt" Visible="False">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr class="dgf">
                <td colspan="4">
                    <asp:Button ID="btnQuery" runat="server" CssClass="btnqry" Text="Query" />
                    &nbsp;<input type="reset" name="Submit2" value="Clear Condition" class="btnreset" />
                    &nbsp;<input type="button" name="btnAdd" value="Add Team" class="btnadd" onclick="javascript:OpenAddTeamPage()" />
                </td>
            </tr>
        </tbody>
    </table>
    <div style ="width :100%" >
        <telerik:RadGrid ID="gridResult" runat="server" AllowPaging="True" 
            AllowSorting="True" PageSize="15" AutoGenerateColumns="False" 
            GridLines="None" Width="100%" Height ="450px" AllowCustomPaging="True" 
            CellSpacing="0">
            <ClientSettings AllowColumnsReorder="True" ReorderColumnsOnClient="True">
                <Selecting AllowRowSelect="True" />
                
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
                    <telerik:GridBoundColumn DataField="ID" Display="False" HeaderText="ID" 
                        UniqueName="IDColumn" AllowFiltering="False" Resizable="False">
                    <HeaderStyle Width="30px" />
                    </telerik:GridBoundColumn>               
                    <telerik:GridBoundColumn DataField="Code"  HeaderText="Code" 
                        UniqueName="codeColumn" AllowFiltering="False" Resizable="False" 
                        Visible="False">
                    <HeaderStyle Width="50px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="TeamName" HeaderText="TeamName" 
                        UniqueName="teamnameColumn" AllowFiltering="False"                
                        Resizable="False">
                     <HeaderStyle Width="80px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ParentTeamName" HeaderText="ParentTeamName" 
                        UniqueName="parentidColumn" AllowFiltering="False" Resizable="False">
                     <HeaderStyle Width="80px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="TeamleaderName" HeaderText="Teamleader" 
                        UniqueName="teamleaderidColumn" AllowFiltering="False" Resizable="False">
                    <HeaderStyle Width="150px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="City" HeaderText="City" 
                        UniqueName="cityidColumn" AllowFiltering="False" Resizable="False" 
                        Visible="False">
                    <HeaderStyle Width="50px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Sector" HeaderText="Sector" 
                        UniqueName="sectoridColumn" AllowFiltering="False" Resizable="False">
                    <HeaderStyle Width="150px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn HeaderText="Edit" UniqueName="editColumn" 
                        AllowFiltering="False" Resizable="False">
                    <HeaderStyle Width="50px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn HeaderText="Assign Role" UniqueName="roleColumn">
                     <HeaderStyle Width="100px" />
                     </telerik:GridBoundColumn>
                </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
            </MasterTableView>
            <ActiveItemStyle Wrap="False" />
            <PagerStyle Position="Top" />

<FilterMenu EnableImageSprites="False">
<WebServiceSettings>
<ODataSettings InitialContainerName=""></ODataSettings>
</WebServiceSettings>
</FilterMenu>

<HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
<WebServiceSettings>
<ODataSettings InitialContainerName=""></ODataSettings>
</WebServiceSettings>
</HeaderContextMenu>
        </telerik:RadGrid>
    </div>
    
    </form>
</asp:Content>