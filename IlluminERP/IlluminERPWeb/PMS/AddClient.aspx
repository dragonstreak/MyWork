<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AddClient.aspx.vb" Inherits="PMS_AddClient" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Apply Client</title>
   <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <base target="_self" />
    <script src="../js/operation.js" type="text/javascript"></script>
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
      <script type="text/javascript" >
          function refresh() {
              document.getElementById("btnRefresh").click();
          }

          function refreshparent() {
              if (window.opener != null)
                  window.opener.refresh();
          }

          function CloseWindow() {
              this.close();
          }


          function onClientBeforeClose(sender, arg) {
              function callbackFunction(arg) {
                  if (arg) {
                      sender.remove_beforeClose(onClientBeforeClose);
                      sender.close();
                  }
              }
              arg.set_cancel(true);
              radconfirm("Close form : Are you sure?", callbackFunction, 300, 100, null, "Close form!");
          } 
	    </script>
      <style type="text/css">
               .multipleRowsColumns .rcbItem, .multipleRowsColumns .rcbHovered
                    {
                        float: left;
                        margin: 0 1px;
                        min-height: 13px;
                        overflow: hidden;
                        padding: 2px 19px 2px 6px;
                        width: 150px;
                    }
     </style>
      
        <style type="text/css">
          
            #divpanel {
              
                height: 100px;
                float:left;
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
	
<body  onunload="refreshparent();">
        <form id="form1" runat="server" >
             <table cellspacing="1" cellpadding="1" class="info" >
              <tbody>
               
                <tr >
                    <td class ="title" colspan="4">
                        Clinet Information</td>
                </tr>
               
                <tr>
                    <td class="lable" style="width: 210px">
                        <span class="red">*</span>Client Name(CN):
                    </td>
                    <td colspan="3">
            <div style="text-align: left">
                
                        <telerik:RadTextBox ID="txtClientCN" Runat="server" Skin="Windows7" 
                    Width="520px" Rows="1">
                        </telerik:RadTextBox>
                
            </div>     


             
                    </td>
                </tr>
                <tr>
                    <td class="lable" style="width: 210px">
                        <span class="red">*</span>Client Name(EN):
                    </td>
                    <td colspan="3">
                        <telerik:RadTextBox ID="txtClientEN" Runat="server" Skin="Windows7" 
                            Width="520px" Rows="1">
                        </telerik:RadTextBox>


             
                    </td>
                </tr>
                <tr>
                    <td class="title" colspan="4">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="lable" style="width: 210px">
                        First Name(CN):</td>
                    <td    >
                        <telerik:RadTextBox ID="txtFirstNameCN" Runat="server" Skin="Windows7" 
                            Width="200px" Rows="1">
                        </telerik:RadTextBox>
                    </td>
                    <td class="lable">
                        Last Name(CN):</td>
                    <td  >
                        <telerik:RadTextBox ID="txtLastNameCN" Runat="server" Skin="Windows7" 
                            Width="200px" Rows="1">
                        </telerik:RadTextBox>
                    </td>
                </tr>
                <tr>
                    <td class="lable" style="width: 210px">
                        First Name(EN):</td>
                    <td    >
                        <telerik:RadTextBox ID="txtFirstNameEN" Runat="server" Skin="Windows7" 
                            Width="200px" Rows="1">
                        </telerik:RadTextBox>
                    </td>
                    <td class="lable">
                        Last Name(EN):</td>
                    <td  >
                        <telerik:RadTextBox ID="txtLastNameEN" Runat="server" Skin="Windows7" 
                            Width="200px" Rows="1">
                        </telerik:RadTextBox>
                    </td>
                </tr>
                <tr>
                    <td class="lable" style="width: 210px">
                        Job Title:</td>
                    <td    >
                        <telerik:RadTextBox ID="txtJobTitle" Runat="server" Skin="Windows7" 
                            Width="200px" Rows="1">
                        </telerik:RadTextBox>
                    </td>
                    <td class="lable">
                        Department:</td>
                    <td  >
                        <telerik:RadTextBox ID="txtDepartment" Runat="server" Skin="Windows7" 
                            Width="200px" Rows="1">
                        </telerik:RadTextBox>
                    </td>
                </tr>
                <tr>
                    <td class="lable" style="width: 210px">
                        Email:</td>
                    <td    >
                        <telerik:RadTextBox ID="txtEmail" Runat="server" Skin="Windows7" 
                            Width="200px" Rows="1">
                        </telerik:RadTextBox>
                    </td>
                    <td class="lable">
                        Mobile Phone:</td>
                    <td  >
                        <telerik:RadTextBox ID="txtMobilePhone" Runat="server" Skin="Windows7" 
                            Width="200px" Rows="1">
                        </telerik:RadTextBox>
                    </td>
                </tr>
                <tr>
                    <td class="lable" style="width: 210px">
                        TEL-Gerneral:</td>
                    <td    >
                        <telerik:RadTextBox ID="txtTelGeneral" Runat="server" Skin="Windows7" 
                            Width="200px" Rows="1">
                        </telerik:RadTextBox>
                    </td>
                    <td class="lable">
                        TEL-Direct:</td>
                    <td  >
                        <telerik:RadTextBox ID="txtTELDirect" Runat="server" Skin="Windows7" 
                            Width="200px" Rows="1">
                        </telerik:RadTextBox>
                    </td>
                </tr>
                <tr>
                    <td class="lable" style="width: 210px">
                        Country:</td>
                    <td    >
                        <telerik:RadTextBox ID="txtCountry" Runat="server" Skin="Windows7" 
                            Width="200px" Rows="1">
                        </telerik:RadTextBox>
                    </td>
                    <td class="lable">
                        City:</td>
                    <td  >
                        <telerik:RadTextBox ID="txtCity" Runat="server" Skin="Windows7" 
                            Width="200px" Rows="1">
                        </telerik:RadTextBox>
                    </td>
                </tr>
                <tr>
                    <td class="lable" style="width: 210px">
                        Post Code:</td>
                    <td    >
                        <telerik:RadTextBox ID="txtPostCode" Runat="server" Skin="Windows7" 
                            Width="200px" Rows="1">
                        </telerik:RadTextBox>
                    </td>
                    <td class="lable">
                        Web Site:</td>
                    <td  >
                        <telerik:RadTextBox ID="txtWebSite" Runat="server" Skin="Windows7" 
                            Width="200px" Rows="1">
                        </telerik:RadTextBox>
                    </td>
                </tr>
                <tr>
                    <td class="lable" style="width: 210px">
                        Address(CN):</td>
                    <td colspan="3"    >
                
                        <telerik:RadTextBox ID="txtAddressCN" Runat="server" Skin="Windows7" 
                    Width="520px" Rows="1">
                        </telerik:RadTextBox>
                
                    </td>
                </tr>
                <tr>
                    <td class="lable" style="width: 210px">
                        Address(EN):</td>
                    <td colspan="3"    >
                
                        <telerik:RadTextBox ID="txtAddressEN" Runat="server" Skin="Windows7" 
                    Width="520px" Rows="1">
                        </telerik:RadTextBox>
                
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                    
            
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4" align="center" style =" height:28px;">

                       <div style="text-align: center ">
                        <telerik:RadButton ID="btnEmail" runat="server"  Text ="Email to application" Font-Names="Arial" 
                            Font-Size="9pt" Width="170px" Skin="Hay" >

                             <Icon PrimaryIconUrl="../images/mail.png" PrimaryIconLeft="10" PrimaryIconTop="4" />
                        </telerik:RadButton>
                
                            </div>
                       
                        </td>
                </tr>
                </tbody>
            </table>
            <div >
               <table cellspacing="1" cellpadding="1"  class="button">
                <tbody>
                    <tr>
                        
                     </tr>
                </tbody>
              </table>
                
            </div>     


             
             <telerik:RadWindowManager ID="RadWindowManager1" runat="server" 
                 EnableShadow="True" Skin="Telerik"  
                 Behaviors="Resize, Minimize, Close, Maximize, Move">
                 <Windows>
                   <telerik:RadWindow ID="RadWindow1" runat="server" Width="850px" Height="650px" Modal="true"    EnableShadow="true"  
                        OnClientBeforeClose   ="onClientBeforeClose">
                        
                   
                </telerik:RadWindow>

                   <telerik:RadWindow ID="RadWindow3" runat="server" Width="650px" Height="450px" Modal="true"    EnableShadow="true"  
                        OnClientBeforeClose   ="onClientBeforeClose" >
                        
                   
                </telerik:RadWindow>

                <telerik:RadWindow ID="RadWindow2" runat="server" Width="850px" Height="650px" Modal="true"
                     OnClientBeforeClose   ="onClientBeforeClose"
                   >
                </telerik:RadWindow>
                  <telerik:RadWindow ID="StageWindow" runat="server" Width="980px" Height="650px"   Modal="true"  EnableShadow="true" 
                        OnClientBeforeClose   ="onClientBeforeClose"
                   
                   > 
                        
                   
                </telerik:RadWindow>
        </Windows>
             </telerik:RadWindowManager>
             

             <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
                <Scripts>
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
                </Scripts>
             </telerik:RadScriptManager>

             
              <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" 
              >
                  <AjaxSettings>
                      <telerik:AjaxSetting AjaxControlID="btnEmail">
                          <UpdatedControls>
                              <telerik:AjaxUpdatedControl ControlID="btnEmail" />
                          </UpdatedControls>
                      </telerik:AjaxSetting>
                  </AjaxSettings>
             </telerik:RadAjaxManager>

             
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
            
       


                
      
         </form>
 
</body>
</html>
