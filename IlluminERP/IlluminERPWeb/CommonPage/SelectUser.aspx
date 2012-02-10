<%@ Page Language="VB" AutoEventWireup="false" CodeFile="SelectUser.aspx.vb" Inherits="CommonPage_SelectUser" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Select User</title>
   <script language="javascript">
//			function refreshparent()
//			{
//				
//				if(window.opener!=null)
//				    {

//					}
//					else
//					{
//						window.opener.refresh();
//					}
//				}
//

       function refreshparent() {
           if (window.opener.location != "") {
               window.opener.refresh();

           }
       }
		</script>
</head>
<body  onunload ="refreshparent();" >
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <div>
        <div style="z-index: 101; left: 8px; width: 325px; position: absolute; top: 0px;
            height: 425px; background-color: gainsboro;">
            <telerik:RadTreeView ID="radTeamUserTree" runat="server" AutoPostBack="True" AutoPostBackOnCheck="True" CheckBoxes="True">
            </telerik:RadTreeView>
            <telerik:RadAjaxManager id="RadAjaxManager1" runat="server">
                <ajaxsettings>
<telerik:AjaxSetting AjaxControlID="radTeamUserTree"><UpdatedControls>
<telerik:AjaxUpdatedControl ControlID="radTeamUserTree" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
</UpdatedControls>
</telerik:AjaxSetting>
</ajaxsettings>
            </telerik:RadAjaxManager>
            <telerik:RadAjaxLoadingPanel id="AjaxLoadingPanel1" Runat="server" height="75px" width="75px">
                <asp:Image ID="Image1" runat="server" AlternateText="Loading..." ImageUrl="~/RadControls/Ajax/Skins/Default/Loading.gif" />
            </telerik:RadAjaxLoadingPanel></div>
        <div style="z-index: 102; left: 8px; width: 325px; position: absolute; top: 424px;
            height: 1px">
            <table style="width: 100%">
                <tr>
                    <td  align ="center" colspan="2">
                      <asp:Button ID="btnOK" runat="server" Font-Names="Arial" Font-Size="9pt" Text="OK"
                            Width="60px" />
                        <asp:Button ID="btnCancel" runat="server" Font-Names="Arial" Font-Size="9pt" Text="Cancel" /></td>
                </tr>
            </table>
            &nbsp;
        </div>
    
    </div>
    </form>
</body>
</html>
