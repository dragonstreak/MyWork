<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ProposalInfo.aspx.vb" Inherits="PMS_ProposalInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
 <style type="text/css">
          
        #panel {
              
            height: 100px;
            display: yes;
        }
  
        .btn-slide {
            background: url(../images/btnDN.gif) no-repeat;
            width: 18px;
            height: 18px;
            display: block;
              
        }
        .active {
            background: url(../images/btnUP.gif) no-repeat;
        }
         
    </style>
      
</head>
<body  style="font-family: sans-serif, Arial, Helvetica">
    <form id="form1" runat="server">
  
   <telerik:RadScriptManager ID="ScriptManager1" runat="server" EnableTheming="True">
        <Scripts>
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
        </Scripts>
    </telerik:RadScriptManager>
  
    <script type="text/javascript">


        (function ($) {
            $(document).ready(function () {

                $(".btn-slide").click(function () {
                    $("#panel").slideToggle("slow");
                    $(this).toggleClass("active"); return false;
                });
            });
        })($telerik.$);
    </script>
  
     <table cellpadding="0" cellspacing="3" >
                                <tr>
                                    <td>
                                    Click the button for more advanced features (You can put the button anywhere) > 
                                        </td>
                                    <td>
                                         <a href="#" class="btn-slide" title="Advanced Search"></a>
                                    </td>
                                </tr>
                            </table>
  
                            <br />
                            <br />
  
   <div id="panel" >
                 <asp:Label ID="Label4" runat="server" Text="Advanced Information: " 
                     ForeColor="#006600"></asp:Label>
                                       <br />
                            <table cellpadding="0" cellspacing="3" width="100%" 
                     style="color: #006600;">
                                <tr >
                                    <td style="border-width: 1px; border-color: #C0C0C0; border-top-style: dashed; border-bottom-style: dashed; padding-top: 10px; padding-bottom: 15px;">
                                        <asp:Literal ID="Literal6" runat="server" Text="Any controls here:"></asp:Literal>
                                        <br />
                                        <asp:TextBox ID="txt1" runat="server" Width="98%"></asp:TextBox>
                                    </td>
                                    <td style="border-width: 1px; border-color: #C0C0C0; border-top-style: dashed; border-bottom-style: dashed; padding-top: 10px; padding-bottom: 15px;">
                                        <asp:Literal ID="Literal7" runat="server" Text="More controls here:"></asp:Literal>
                                        <br />
                                        <asp:TextBox ID="txt2" runat="server" Width="98%"></asp:TextBox>
                                    </td>
                                    <td style="border-width: 1px; border-color: #C0C0C0; border-top-style: dashed; border-bottom-style: dashed; padding-top: 10px; padding-bottom: 15px;">
                                        <asp:Literal ID="Literal8" runat="server" Text="Whatever controls here:"></asp:Literal>
                                        <br />
                                        <asp:TextBox ID="txt3" runat="server" Width="98%"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                             
                </div>
            <hr />
    </form>
</body>
</html>