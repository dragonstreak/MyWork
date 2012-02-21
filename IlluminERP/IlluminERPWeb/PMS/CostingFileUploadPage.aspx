<%@ Page Language="VB" AutoEventWireup="false" CodeFile="CostingFileUploadPage.aspx.vb" Inherits="CostingFileUploadPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <base target="_self" />
    <link href="../Css/CornorPanel.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 40px;
            height: 40px;
        }
    </style>
    <script type="text/javascript">
        function CloseWindow() {
            
            window.close();
        }
        function submitFile(sender, e) {
            $("#btnSubmitFile")[0].click();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
            <asp:ScriptReference Path="~/Plugins/BlockUI.js" />
        </Scripts>
    </telerik:RadScriptManager>
    <div class="sharp color1" style="width:406px; padding-left:10px">
            <b class="b1"></b><b class="b2"></b><b class="b3"></b><b class="b4"></b>
            <div class="content"  style="height:237px; width: 418px;" >
                <h3>
                    <asp:Label ID="labelStatus" runat="server" Text="Upload estimate file(only for excel file)"></asp:Label></h3>
                    <hr align="left" size="1" style="border-style: dotted; color: Aqua;" noshade />
                <div>
                   <telerik:RadUpload ID="RadUpload1" Runat="server"                    
                    OnClientFileSelected="submitFile" 
                        ControlObjectsVisibility="None" Width="344px"
                    >
                </telerik:RadUpload>
                   
                  
                </div>
            </div>
            <b class="b5"></b><b class="b6"></b><b class="b7"></b><b class="b8"></b>
        </div>
        <asp:Button ID="btnSubmitFile" runat="server" Text="Submit" Width="0px" Height="0px" CssClass="hiddenBtn"/>
    </form>
</body>
</html>
