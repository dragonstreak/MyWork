<%@ Page Title="" Language="VB" MasterPageFile="~/Master/IlluminMasterPage.master" AutoEventWireup="false" CodeFile="ChangePassword.aspx.vb" Inherits="User_ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headJS" Runat="Server">
</asp:Content>
<asp:Content ID="ChildPageHead" ContentPlaceHolderID="head" Runat="Server">
     <title>Chinage Password</title>
    <link href="../css/style.css" rel="stylesheet" type="text/css"/>
    <script src="../js/validation.js" type="text/javascript"></script>
    <script src="../js/operation.js" type="text/javascript"></script>
	<telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageContentPlaceHolder" Runat="Server">
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
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        </telerik:RadAjaxManager>
    <div class="title">
        Change &nbsp; password
    </div>

     <table width="400px" class="query" id="table1">
		<tbody id="main">
		<tr >
			<td  style ="  width :150px; font-size:10pt; font-family:Arial; " >New password:</td>
			<td align =left>
                <telerik:RadTextBox ID="txtPassword" Runat="server" Width="200px"  TextMode =Password 
                    Skin="Windows7">
                </telerik:RadTextBox>
            </td>
        </tr>

        <tr >
			<td style ="  width :150px ;font-size:10pt; font-family:Arial; " >Confirm new password:</td>
			<td align =left  >
                <telerik:RadTextBox ID="txtConfirmPassword" Runat="server" Width="200px"  TextMode =Password  Skin="Windows7">
                </telerik:RadTextBox>
            </td>
		</tr>

        <tr  style=" height :30px">
			<td align="center"  colspan="2">
            
             <telerik:RadButton ID="btnSave" runat="server" Text="Save"  
                    Font-Names="Arial" Font-Size="9pt" Width="100px" Skin="Hay" >
                   <Icon PrimaryIconUrl="../images/save.png" PrimaryIconLeft="10" PrimaryIconTop="4" />
                </telerik:RadButton>
            </td>
		</tr>

        
        
		</tbody>
	</table>

 </form>
</asp:Content>

