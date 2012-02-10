<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Illumin ERP Login</title>
</head>
<style>
* { margin:0 auto; padding:0; border:0;}
body { background:#F0F0F0; font:12px "Arial"; color:#FFFFFF;}
input { border:1px solid #F0F0F0;}
.main { background:url(images/login_bg.jpg) repeat-x; height:600px;}
.login { background:#CC0000; width:468px; height:262px; border:1px solid #000;position:absolute;top:200px;left:400px;}
.top { width:464px; height:113px; border:2px solid #F0F0F0; margin-top:1px;}
.logo { background:url(images/logo_white.png) no-repeat; width:214px; height:42px; float:right; margin:30px 70px 0 0px;}
.lable { background:url(images/logo_book.png) no-repeat; width:100px; height:120px; float:left; margin:2px 31px 0 30px;}
.submit { background:url(images/submit.gif) no-repeat; width:71px; height:24px; border:0;} 
.reset { background:url(images/reset.gif) no-repeat; width:71px; height:24px; border:0;} 
.marginleft { margin-left:30px}
    .style1
    {
        width: 209px;
    }
</style>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Assembly="Telerik.Web.UI" 
                Name="Telerik.Web.UI.Common.Core.js">
            </asp:ScriptReference>
            <asp:ScriptReference Assembly="Telerik.Web.UI" 
                Name="Telerik.Web.UI.Common.jQuery.js">
            </asp:ScriptReference>
            <asp:ScriptReference Assembly="Telerik.Web.UI" 
                Name="Telerik.Web.UI.Common.jQueryInclude.js">
            </asp:ScriptReference>
        </Scripts>
    </telerik:RadScriptManager>
    <div>
        <table width="100%" class="main" cellpadding="0" cellspacing="0">
  <tr>
    <td>
      <div class="login">
        <div class="top">
          <div class="logo"></div>
          <div class="lable"></div>
        </div>
        <table width="468" cellpadding="0" cellspacing="0">
          <tr>
            <td width="282" style="padding-top:17px;">
              <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                  <td align="right" height="30" class="style1">User ID:
                  <td align="center" width="161">
                    <asp:TextBox ID="txtUserName" runat="server" Width="120px" Font-Names="Arial" Font-Size="9pt" meta:resourcekey="txtUserNameResource1"></asp:TextBox>
                  </td>
                </tr>
                <tr>
                  <td align="right" height="30" class="style1">Password:</td>
                  <td align="center" width="161">
                    <asp:TextBox ID="txtPassword" runat="server" Width="120px" Font-Names="Arial" Font-Size="9pt" TextMode="Password" meta:resourcekey="txtPasswordResource1"></asp:TextBox>
  
                  </td>
                </tr>
              </table>
            </td>
            <td style="padding-top:17px;">
              <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                  <td height="27">
                  
                  
                      <telerik:RadButton ID="btnLogin" runat="server" Text="Login" Width ="80px" 
                          Skin="Hay">
                         
                                <Icon PrimaryIconUrl="images/login.png" PrimaryIconLeft="4" PrimaryIconTop="4" />
                   
                      </telerik:RadButton>
                  
                    </td>
                </tr>
                <tr>
                  <td height="27">
                      <asp:CheckBox ID="chkSavePassword" runat="server" Font-Names="Arial" Font-Size="8pt"
                                                    Text="Remember me" Width="120px" meta:resourcekey="chkSavePasswordResource1" />
                      
                   </td>
                </tr>
              </table>
            </td>
          </tr>
        </table>
       
        <table width="100%" cellpadding="0" cellspacing="0" style="margin-top:28px;">
          <tr>
            <td align="center";>
                <br />
                Conpyright @ 2011 illuminera</td>
          </tr>
        </table>
      </div>
      <!--login -->
    </td>
  </tr>
</table>
    </div>
    </form>
</body>
</html>
