<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ProjectContract.aspx.vb" Inherits="PMS_ProjectContract" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Project Contract</title>
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
                        Contract Information</td>
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
                        Project Owner:</td>
                    <td    >
                        <telerik:RadTextBox ID="txtProjectOwner" Runat="server" Skin="Windows7" 
                            Width="200px" Rows="1">
                        </telerik:RadTextBox>
                    </td>
                    <td class="lable">
                        Contract Date:</td>
                    <td  >
                        <telerik:RadDatePicker ID="txtContractDate" Runat="server" Width="200px">
                        </telerik:RadDatePicker>
                    </td>
                </tr>
                <tr>
                    <td class="lable" style="width: 210px">
                        Amount:</td>
                    <td    >
                        <telerik:RadNumericTextBox ID="txtAmount" Runat="server" Culture="zh-CN" 
                            LabelWidth="" Type="Currency" Width="200px" Value="0">
<NumberFormat ZeroPattern="¥n"></NumberFormat>
                        </telerik:RadNumericTextBox>
                    </td>
                    <td class="lable">
                        Additional Amount:</td>
                    <td  >
                        <telerik:RadNumericTextBox ID="txtAdditionalAmount" Runat="server" 
                            Culture="zh-CN" LabelWidth="" Type="Currency" Width="200px" Value="0">
<NumberFormat ZeroPattern="¥n"></NumberFormat>
                        </telerik:RadNumericTextBox>
                    </td>
                </tr>
                <tr>
                    <td class="lable" style="width: 210px">
                        Contact :</td>
                    <td    >
                        <telerik:RadTextBox ID="txtContact" Runat="server" Skin="Windows7" 
                            Width="200px" Rows="1">
                        </telerik:RadTextBox>
                    </td>
                    <td class="lable">
                        Telephone:</td>
                    <td  >
                        <telerik:RadTextBox ID="txtTel" Runat="server" Skin="Windows7" 
                            Width="200px" Rows="1">
                        </telerik:RadTextBox>
                    </td>
                </tr>
                <tr>
                    <td class="lable" style="width: 210px">
                        Memo:</td>
                    <td colspan="3"    >
                
                        <telerik:RadTextBox ID="txtMemo" Runat="server" Skin="Windows7" 
                                     Width="520px" TextMode="MultiLine">

                        </telerik:RadTextBox>
                
                    </td>
                </tr>
            
                <tr>
                    <td class="lable" style="width: 210px">
                        Contract Upload:</td>
                    <td colspan="3"    >

     

                        <telerik:RadUpload ID="RadUpload" Runat="server">
                        </telerik:RadUpload>
                       
                        <telerik:RadGrid ID="RadGrid" runat="server" AutoGenerateColumns="False" 
                            AutoGenerateDeleteColumn="True" CellSpacing="0" GridLines="None">
<MasterTableView>
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridBoundColumn DataField="Id" 
            FilterControlAltText="Filter columnId column" HeaderText="Id" 
            UniqueName="columnId" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="ProId" 
            FilterControlAltText="Filter columnProId column" HeaderText="ProId" 
            UniqueName="columnProId" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="FileName" 
            FilterControlAltText="Filter columnFileName column" HeaderText="File Name" 
            UniqueName="columnFileName">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="FileFolder" 
            FilterControlAltText="Filter columnFileFolder column" HeaderText="File Folder" 
            UniqueName="columnFileFolder" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridButtonColumn CommandName="Download" 
            FilterControlAltText="Filter columnDownload column" Text="Download" 
            UniqueName="columnDownload">
        </telerik:GridButtonColumn>
    </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
</MasterTableView>

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

                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="center" style =" height:28px;">

                       <div style="text-align: center ">
                        <telerik:RadButton ID="btnSave" runat="server"  Text ="Save" Font-Names="Arial" 
                            Font-Size="9pt" Width="100px" Skin="Hay"  >

                             <Icon PrimaryIconUrl="../images/Save.png" PrimaryIconLeft="10" PrimaryIconTop="4" />
                        </telerik:RadButton>
                
                        <telerik:RadButton ID="btnSendMail" runat="server"  Text ="Email for approval" Font-Names="Arial" 
                            Font-Size="9pt" Width="150px" Skin="Hay"  >

                             <Icon PrimaryIconUrl="../images/mail.png" PrimaryIconLeft="10" PrimaryIconTop="4" />
                        </telerik:RadButton>
                
                        <telerik:RadButton ID="btnApprove" runat="server"  Text ="Approve" Font-Names="Arial" 
                            Font-Size="9pt" Width="100px" Skin="Hay"  >

                             <Icon PrimaryIconUrl="../images/accept.png" PrimaryIconLeft="10" PrimaryIconTop="4" />
                        </telerik:RadButton>
                
                            </div>
                       
                        </td>
                </tr>
                <tr>
                    <td colspan="4" align="center" style =" height:28px;">

                       &nbsp;
                       
                        </td>
                </tr>
                </tbody>
            </table>
            <div >
                
                <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
                </telerik:RadScriptManager>
                
             
                
            </div>     


            
             
              

             
        
                
      
         </form>
 
</body>
</html>
