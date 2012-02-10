<%@ Page Language="VB" AutoEventWireup="false" CodeFile="UpdateStatus.aspx.vb" Inherits="PMS_UpdatStatus" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Update Status</title>
 <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <base target="_self" />
    <script src="../js/operation.js" type="text/javascript"></script>
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
 
        <style id="Style1" type="text/css" runat="server">
            .radupload { float: left; margin-bottom:20px; }
            .bigModule { clear: both; }
            .smallModule { margin-bottom:20px; }
            #controlContainer { vertical-align: top; padding: 20px 10px; }
            .ruProgressArea { position: absolute; top: 0; left: 10px; }
            input.RadUploadSubmit { margin-top: 20px; }
        </style>
      
    
       
</head>
	
<body  >
        <form id="form1" runat="server" >

        
         
             <table cellspacing="1" cellpadding="1" class="info" >
              <tbody>
               
                <tr >
                    <td class ="title" colspan="4">
                        Update Project Status</td>
                </tr>
               
                <tr>
                    <td class="lable" style="width: 210px">
                        Job Numer:</td>
                    <td    >
                        <telerik:RadTextBox ID="txtJobNumber" Runat="server" Skin="Windows7" 
                            Width="200px" Rows="1">
                        </telerik:RadTextBox>
                    </td>
                    <td class="lable">
                        Jab Name:</td>
                    <td  >
                        <telerik:RadTextBox ID="txtJobName" Runat="server" Skin="Windows7" 
                            Width="200px" Rows="1">
                        </telerik:RadTextBox>
                    </td>
                </tr>
                <tr>
                    <td class="lable" style="width: 210px">
                        Client:</td>
                    <td colspan="3"    >
                
                        <telerik:RadTextBox ID="txtClient" Runat="server" Skin="Windows7" 
                    Width="520px" Rows="1">
                        </telerik:RadTextBox>
                
                    </td>
                </tr>
                <tr>
                    <td class="lable" colspan="4">
                        &nbsp;</td>
                </tr>
            
                <tr>
                    <td class="lable" style="width: 210px">
                        Project Status:</td>
                    <td colspan="3"    >

     

                        <telerik:RadComboBox ID="cbStatus" Runat="server" Width="200px" 
                            AutoPostBack="True">
                        </telerik:RadComboBox>

                    </td>
                </tr>
            
                <tr>
                    <td class="lable" style="width: 210px">
                        Memo:</td>
                    <td colspan="3"    >

     

                        <telerik:RadTextBox ID="txtmemo" Runat="server" Skin="Windows7" 
                            Width="520px" Rows="3" TextMode="MultiLine">
                        </telerik:RadTextBox>

                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="center" style =" height:28px;">

                       <div style="text-align: center ">
                        <telerik:RadButton ID="btnSave" runat="server"  Text ="Submit" Font-Names="Arial" 
                            Font-Size="9pt" Width="120px" Skin="Hay"  >

                             <Icon PrimaryIconUrl="../images/Save.png" PrimaryIconLeft="10" PrimaryIconTop="4" />
                        </telerik:RadButton>
                
                            </div>
                       
                        </td>
                </tr>
                </tbody>
            </table>
            <div >
               <table cellspacing="1" cellpadding="1"  class="button">
                <tbody>
                </tbody>
              </table>
                
                <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
                </telerik:RadScriptManager>
                
             
                
                <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
                    <AjaxSettings>
                        <telerik:AjaxSetting AjaxControlID="cbFileType">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="RadUpload" />
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                    </AjaxSettings>
                </telerik:RadAjaxManager>
                
             
                
            </div>     
         </form>
 
</body>
</html>
