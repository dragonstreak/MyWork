<%@ Page Language="VB" MasterPageFile="~/Master/IlluminMasterPage.master" AutoEventWireup="false" CodeFile="ProjectQuery.aspx.vb" Inherits="PMS_ProjectQuery" %>

<asp:Content ID="ChildPageHead" ContentPlaceHolderID="head" runat="server">
    <title>Project Query</title>
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <script src="../js/validation.js" type="text/javascript"></script>
    <script src="../js/operation.js" type="text/javascript"></script>
    <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server" />
</asp:Content>

<asp:Content ID="ChildPageBody" ContentPlaceHolderID="PageContentPlaceHolder" runat="server">
    <form id="form1">
    <table width="100%" class="query" id="table1">
        <caption class="advover" onclick="adv(table1,main)">
            Query</caption>
        <tbody id="main">
            <tr>
                <td width="15%">
                    Prject Status:
                </td>
                <td width="35%">
                    <asp:DropDownList ID="ddlProjectStatus" runat="server">
                    </asp:DropDownList>
                </td>
                <td width="15%">
                    Job Number:
                </td>
                <td width="35%">
                    <asp:TextBox ID="txtJobNumber" runat="server" CssClass="text"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td width="15%">
                    Job Name:
                </td>
                <td width="35%">
                    <asp:TextBox ID="txtJobName" runat="server" CssClass="text"></asp:TextBox>
                </td>
                <td width="15%">
                    Client Name:
                </td>
                <td width="35%">
                    <asp:TextBox ID="txtClientName" runat="server" CssClass="text"></asp:TextBox>
                </td>
            </tr>
            <tr class="dgf">
                <td colspan="4">
                    <asp:Button ID="btnQuery" runat="server" CssClass="btnqry" Text="Query" />
                    &nbsp;<input type="reset" name="Submit2" value="Clear Condition" class="btnreset" />
                    &nbsp;
                </td>
            </tr>
        </tbody>
    </table>
    <div class="queryresultgrid">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
    <telerik:RadGrid ID="gridResult" runat="server" AllowPaging="True" 
            AllowSorting="True" PageSize="2" AutoGenerateColumns="False" 
            GridLines="None" >
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
                    <telerik:GridBoundColumn DataField="JobNumber"  HeaderText="Job Number" >
                    <HeaderStyle Width="40px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="JobName" HeaderText="Job Name" >
                    <HeaderStyle Width="40px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="FullName" HeaderText="End Client" >
                    <HeaderStyle Width="40px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ResearchName" HeaderText="Research" >
                    <HeaderStyle Width="40px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ManagerName" HeaderText="PM/RM" >
                    <HeaderStyle Width="40px" />
                    </telerik:GridBoundColumn>    
                     <telerik:GridBoundColumn DataField="ProjectStatus" HeaderText="Project Status" >
                    <HeaderStyle Width="40px" />                    
                    </telerik:GridBoundColumn>    
                     <telerik:GridBoundColumn DataField="id" HeaderText="Project id" Visible="false" UniqueName="IDColumn">
                    <HeaderStyle Width="40px" />                    
                    </telerik:GridBoundColumn> 
                   <telerik:GridButtonColumn Text="Enter" CommandName="enterCommand">
                   <HeaderStyle Width="30px" />    
                   </telerik:GridButtonColumn>
                    <%--<telerik:GridHyperLinkColumn Text="Enter" NavigateUrl="../User/UserQuery.aspx">
                    <HeaderStyle Width="30px" />     </telerik:GridHyperLinkColumn>--%>
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>
    </div>
    </form>
</asp:Content>
