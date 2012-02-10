﻿<%@ Page Language="VB" MasterPageFile="~/Master/IlluminMasterPage.master" AutoEventWireup="false" CodeFile="UserMessageList.aspx.vb" Inherits="Message_UserMessageList" %>

<asp:Content ID="ChildPageHead" ContentPlaceHolderID="head" runat="server">
    <title></title>
     <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <script src="../js/validation.js" type="text/javascript"></script>
    <script src="../js/operation.js" type="text/javascript"></script>

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

    <script type="text/javascript">
        function ShowMessage(id) {
            var showWindow = new ShowMessageWindow({
                MessageId: id,
                NeedGetMessageById: true,
                plain: true
            });
            showWindow.show();
        }
        //这里需要使用正式的USERID
        //var LoginUserId = 2;
      
        //var LoginUserName = "David Dong";
        function SendMessage() {
            var sendWindow = new SendMessageWindow({
            width: 650
            });
            sendWindow.show();
        }
        Ext.onReady(function () {
            Ext.QuickTips.init();   
//            var rollingMSG = new rollingMessage();
//            rollingMSG.StartRolling();
        });
    </script>
</asp:Content>

<asp:Content ID="ChildPageBody" ContentPlaceHolderID="PageContentPlaceHolder" runat="server">
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    </telerik:RadAjaxManager>
     <table width="100%" class="query" id="table1">
        <caption class="advover" onclick="adv(table1,main)">
            Query</caption>
        <tbody id="main">
            <tr>
                <td width="15%">
                    Message Content
                </td>
                <td width="35%">
                    <asp:TextBox ID="txtMessageContent" runat="server" CssClass="text"></asp:TextBox>
                </td>
                <td width="15%">
                    From
                </td>
                <td width="35%">
                    <asp:TextBox ID="txtMessageFrom" runat="server" CssClass="text"></asp:TextBox>
                </td>
            </tr>
            <tr>
            <td>
            Message Subject
            </td>
            <td>
                <asp:TextBox ID="txtMessageSubject" runat="server" CssClass="text"></asp:TextBox>
            </td>
            <td>
            Message Status
            </td>
            <td>
                <asp:DropDownList ID ="ddlMessageStatus" runat="server">
                    <asp:ListItem Text="All" Value="-1"></asp:ListItem>
                    <asp:ListItem Text="New Message" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Readed Message" Value ="1"></asp:ListItem>
                </asp:DropDownList>
            </td>
            </tr>
            <tr class="dgf">
                <td colspan="4">
                    <asp:Button ID="btnQuery" runat="server" CssClass="btnqry" Text="Query" />
                    &nbsp;<input type="reset" name="Submit2" value="Clear Condition" onclick="ClearCondition();" class="btnreset" />
                    &nbsp;<input type="button" name="btnSender" value="Send Message" class="btnadd" onclick="SendMessage()"  />
                 
                </td>
            </tr>
        </tbody>
    </table>
     <div class="queryresultgrid">
        <telerik:RadGrid ID="gridResult" runat="server" AllowPaging="True" 
            AllowSorting="True" PageSize="10" AutoGenerateColumns="False" 
            GridLines="None" AutoGenerateDeleteColumn="True">
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
                    <telerik:GridBoundColumn DataField="Message_Time"  HeaderText="Time" UniqueName="timeColumn">
                    <HeaderStyle Width="40px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Message_Subject" HeaderText="Message Subject" UniqueName="subjectColumn">
                    <HeaderStyle Width="40px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Message_Content" HeaderText="Message Content" UniqueName="contentColumn">
                    <HeaderStyle Width="40px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Message_Sender" HeaderText="From" UniqueName="senderColumn">
                    <HeaderStyle Width="40px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Message_Status" HeaderText="Status" UniqueName="departmentColumn">
                    <HeaderStyle Width="40px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ID" Display="False" HeaderText="ID" UniqueName="IDColumn">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn HeaderText="Open" UniqueName = "OpenColumn">
                    <HeaderStyle Width="30px" />
                    </telerik:GridBoundColumn>
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>
    </div>
    </form>
</asp:Content>