<%@ Page Language="VB" AutoEventWireup="false" CodeFile="NewProposal.aspx.vb" Inherits="PMS_NewProposal" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title></title>
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    	<script src="../js/operation.js" type="text/javascript"></script>
 <script language="javascript">
     function refresh() {
         document.getElementById("btnRefresh").click();
     }

     function refreshparent() {
         if (window.opener != null)
             window.opener.refresh();
     }
		
	
	</script>
</head>
	
<body leftMargin="0" topMargin="0" onunload="refreshparent();" >
    <form id="form1" runat="server">
            
            <!--<table cellSpacing="0" cellPadding="0" bgColor="#696969" border="0" style="width: 100%; left: 0px; position: absolute; top: 0px; height: 40px; z-index: 101;">
				<tr>
					<td style="BORDER-TOP: #ffffdc 1px solid; BORDER-LEFT: #ffffdc 1px solid; height: 40px;" align="right"
						width="15">&nbsp;</td>
					<td style="BORDER-RIGHT: 1px solid #ffffdc; BORDER-TOP: 1px solid #ffffdc; PADDING-LEFT: 2px; WIDTH: 164px; height: 40px;"
						noWrap><b><font face="Arial" color="#FFFFDC">New Proposal</font></b></td>
					<td style="WIDTH: 8px; height: 40px;" width="8"><FONT face="Arial"></FONT></td>
					<td style="WIDTH: 794px; height: 40px;">
						&nbsp;</td>
				</tr>
			</table>    -->
            <table cellspacing="0"  height="152" cellpadding="0" style="width: 584px"  class="dg">
                <tr>
                    <td style="height: 22px;" >
                        <span style="font-size: 9pt; font-family: Arial">Job Number:</span> <span style="color:red">
                            *</span></td>
                    <td style="height: 22px;">
                        <telerik:RadTextBox ID="txtJobNumber" runat="server" LabelCssClass="radLabelCss_Default"
                            Skin="Office2007" Width="180px" Font-Names="Arial" Font-Size="9pt" 
                            BackColor="Silver">
                        </telerik:RadTextBox></td>
                    <td style="height: 22px; width: 1586px;" >
                        <span style="font-size: 9pt; font-family: Arial">Job Name:<span style="font-size: 12pt;
                            color:red; ">*</span></span></td>
                    <td style="height: 22px; width: 200px; font-size: 12pt; ;">
                        <telerik:RadTextBox ID="txtJobName" runat="server" LabelCssClass="radLabelCss_Default"
                            Skin="Office2007" Width="180px" Font-Names="Arial" Font-Size="9pt" 
                            AutoPostBack="True">
                        </telerik:RadTextBox></td>
                </tr>
                <tr style="font-size: 12pt; ">
                    <td style="height: 22px" >
                        <span style="font-size: 9pt; font-family: Arial">Project Type:</span></td>
                    <td style="height: 22px"><telerik:RadComboBox ID="cbProjectType" runat="server" 
                             SkinsPath="~/RadControls/ComboBox/Skins"
                            Width="175px" NoWrap="True" EnableScreenBoundaryDetection="False" 
                            ShowWhileLoading="False">
                    </telerik:RadComboBox>
                    </td>
                    <td style="height: 22px; width: 1586px;" >
                        <span style="font-size: 9pt; font-family: Arial">Office:</span><span style="color:red">*</span></td>
                    <td style="height: 22px; width: 200px;">
                        <telerik:RadComboBox ID="cbCity" runat="server"  SkinsPath="~/RadControls/ComboBox/Skins"
                            Width="175px">
                        </telerik:RadComboBox>
                    </td>
                </tr>
                <tr>
                    <td height="16" >
                        <span style="font-size: 9pt; font-family: Arial">Client Type:<span style="font-size: 12pt;
                            color:red; ">*</span></span></td>
                    <td height="22" style="font-size: 12pt; ">
                        <telerik:RadComboBox ID="cbClientType" runat="server"  SkinsPath="~/RadControls/ComboBox/Skins"
                            Width="175px" AutoPostBack="True">
                            <Items>
                                <telerik:RadComboBoxItem runat="server" Selected="True" Text="----NULL----" Value="0" />
                                <telerik:RadComboBoxItem runat="server" Text="Internal Client" Value="1" />
                                <telerik:RadComboBoxItem runat="server" Text="External Client" Value="2" />
                            </Items>
                        </telerik:RadComboBox>
                    </td>
                    <td height="22"  style="font-size: 12pt; width: 1586px; ">
                        <span style="font-size: 9pt; font-family: Arial">Status:<span style="font-size: 12pt;
                            color:red; ">*</span></span></td>
                    <td height="22" style="width: 200px; font-size: 12pt; ;">
                        <telerik:RadComboBox ID="cbStatus" runat="server"  SkinsPath="~/RadControls/ComboBox/Skins"
                            Width="175px">
                        </telerik:RadComboBox>
                    </td>
                </tr>
                <tr style="font-size: 12pt; ">
                    <td height="15" >
                        <span style="font-size: 9pt; font-family: Arial">Internal Client:</span></td>
                    <td colspan="3" height="22">
                        <telerik:RadComboBox ID="cbInternalClient" runat="server"  SkinsPath="~/RadControls/ComboBox/Skins"
                            Width="480px" Height="300px" MarkFirstMatch="True" 
                            ExpandEffect="RandomDissolve">
                        </telerik:RadComboBox>
                    </td>
                </tr>
                <tr style="font-size: 12pt; ">
                    <td style="height: 22px;" >
                        <span style="font-size: 9pt; font-family: Arial">Ending Client:</span></td>
                    <td colspan="3" style="height: 22px">
                        <telerik:RadComboBox ID="cbEndClient" runat="server"  SkinsPath="~/RadControls/ComboBox/Skins"
                            Width="480px" Height="300px" MarkFirstMatch="True" AutoPostBack="True" 
                            ExpandEffect="RandomDissolve" DropDownWidth="480px">
                        </telerik:RadComboBox>
                    </td>
                </tr>
                <tr style="font-size: 12pt; ">
                    <td height="15" >
                        <span style="font-size: 9pt; font-family: Arial">Client Description:</span></td>
                    <td colspan="3" height="22"><telerik:RadTextBox ID="txtClientDescription" 
                            runat="server" LabelCssClass="radLabelCss_Office2007"
                            Skin="Office2007" Width="488px" Font-Names="Arial" Font-Size="9pt" 
                            BackColor="Silver">
                    </telerik:RadTextBox></td>
                </tr>
                <tr style="font-size: 12pt; ">
                    <td colspan="4" height="7" >
                        </td>
                </tr>
                <tr style="font-size: 12pt; ">
                    <td style="height: 22px;" >
                        <span style="font-size: 9pt; font-family: Arial">Sector:</span><span style="color:red">*</span></td>
                    <td style="height: 22px;">
                        <telerik:RadComboBox ID="cbSector" runat="server"  SkinsPath="~/RadControls/ComboBox/Skins"
                            Width="175px" AutoPostBack="True" ExpandEffect="RandomDissolve">
                        </telerik:RadComboBox>
                    </td>
                    <td style="height: 22px; width: 1586px;" >
                        <span style="font-size: 9pt; font-family: Arial">Product Category:<span style="font-size: 12pt;
                            color:red; ">*</span></span></td>
                    <td style="height: 22px; width: 200px; font-size: 12pt; ;">
                        <telerik:RadComboBox ID="cbProductCategory" runat="server"  SkinsPath="~/RadControls/ComboBox/Skins"
                            Width="175px" Height="300px" ExpandEffect="RandomDissolve">
                        </telerik:RadComboBox>
                    </td>
                </tr>
                <tr style="font-size: 12pt; ">
                    <td style="height: 22px" >
                        <span style="font-size: 9pt; font-family: Arial">Business Soulation:<span style="font-size: 12pt;
                            color:red; ">*</span></span></td>
                    <td style="height: 22px; font-size: 12pt; ;">
                        <telerik:RadComboBox ID="cbBS" runat="server"  SkinsPath="~/RadControls/ComboBox/Skins"
                            Width="175px" ExpandEffect="RandomDissolve" Height="300px">
                        </telerik:RadComboBox>
                    </td>
                    <td style="height: 22px; font-size: 12pt; width: 1586px; ;" >
                        <span style="font-size: 9pt; font-family: Arial">Other Business Sou</span></td>
                    <td style="height: 22px; width: 200px; font-size: 12pt; ;">
                        <telerik:RadComboBox ID="cbOtherBS" runat="server"  SkinsPath="~/RadControls/ComboBox/Skins"
                            Width="175px" ExpandEffect="RandomDissolve" Height="300px">
                        </telerik:RadComboBox>
                    </td>
                </tr>
                <tr style="font-size: 12pt; ">
                    <td style="height: 17px" >
                        <span style="font-size: 9pt; font-family: Arial">AOE:<span style="font-size: 12pt;
                            color:red; ">*</span></span></td>
                    <td style="height: 17px; font-size: 12pt; ;">
                        <telerik:RadComboBox ID="cbAOE" runat="server"  SkinsPath="~/RadControls/ComboBox/Skins"
                            Width="175px" ExpandEffect="RandomDissolve">
                        </telerik:RadComboBox>
                    </td>
                    <td style="height: 17px; font-size: 12pt; width: 1586px; ;" >
                        <span style="font-size: 9pt; font-family: Arial">Digital Products:<span style="font-size: 12pt;
                            color:red; ">*</span></span></td>
                    <td style="height: 22px; width: 200px; font-size: 12pt; ;">
                        <telerik:RadComboBox ID="cbDigital" runat="server"  SkinsPath="~/RadControls/ComboBox/Skins"
                            Width="175px" ExpandEffect="RandomDissolve" Height="300px">
                    </telerik:RadComboBox>
                    </td>
                </tr>
                <tr style="font-size: 12pt; ">
                    <td style="height: 17px" >
                        <span style="font-size: 9pt; font-family: Arial">Probability: </span><span style="color:red">
                            *</span></td>
                    <td style="height: 17px">
                        <telerik:RadNumericTextBox ID="txtProbablity" runat="server" Culture="Chinese (People's Republic of China)"
                            LabelCssClass="radLabelCss_Default" Skin="" Type="Percent" Width="180px" 
                            MaxValue="100" MinValue="0">
                            <NumberFormat AllowRounding="True" DecimalDigits="0" />
                        </telerik:RadNumericTextBox></td>
                    <td style="height: 17px; width: 1586px;" >
                        .</td>
                    <td style="height: 22px; width: 200px;">
                        .</td>
                </tr>
                <tr style="font-size: 12pt; ">
                    <td style="height: 17px" >
                        <span style="font-size: 9pt; font-family: Arial">Quanti Revenue</span>:</td>
                    <td style="height: 17px">
                        <telerik:RadNumericTextBox ID="txtQuantiRevenue" runat="server" Culture="Chinese (People's Republic of China)"
                            LabelCssClass="radLabelCss_Default" Skin="" Type="Currency" Width="180px" 
                            AutoPostBack="True">
                            <NumberFormat AllowRounding="True" />
                        </telerik:RadNumericTextBox></td>
                    <td style="height: 17px; width: 1586px;" >
                        <span style="font-size: 9pt; font-family: Arial">Quali Revenue: </span>
                    </td>
                    <td style="height: 22px; width: 200px;">
                        <telerik:RadNumericTextBox ID="txtQualiRevenue" runat="server" Culture="Chinese (People's Republic of China)"
                            LabelCssClass="radLabelCss_Default" Skin="" Type="Currency" Width="180px" 
                            AutoPostBack="True">
                            <NumberFormat AllowRounding="True" />
                        </telerik:RadNumericTextBox></td>
                </tr>
                <tr style="font-size: 12pt; ">
                    <td style="height: 17px" >
                        <span style="font-size: 9pt; font-family: Arial">Total Revenue: </span>
                    </td>
                    <td style="height: 17px">
                        <telerik:RadNumericTextBox ID="txtTotalRevenue" runat="server" Culture="Chinese (People's Republic of China)"
                            LabelCssClass="radLabelCss_Default" Skin="" Type="Currency" Width="180px">
                            <NumberFormat AllowRounding="True" />
                        </telerik:RadNumericTextBox></td>
                    <td style="height: 17px; width: 1586px;" >
                        <span style="font-size: 9pt; font-family: Arial">Estimate GM:</span></td>
                    <td style="height: 22px; width: 200px;">
                        <telerik:RadComboBox ID="cbGMPercent" runat="server"  SkinsPath="~/RadControls/ComboBox/Skins"
                            Width="64px" ShowMoreResultsBox="True" AutoPostBack="True">
                        <Items>
                            <telerik:RadComboBoxItem runat="server" Selected="True" Text="-NULL-" Value="0" />
                            <telerik:RadComboBoxItem runat="server" Text="10%" Value="10" />
                            <telerik:RadComboBoxItem runat="server" Text="20%" Value="20" />
                            <telerik:RadComboBoxItem runat="server" Text="30%" Value="30" />
                            <telerik:RadComboBoxItem runat="server" Text="40%" Value="40" />
                            <telerik:RadComboBoxItem runat="server" Text="50%" Value="50" />
                            <telerik:RadComboBoxItem runat="server" Text="60%" Value="60" />
                            <telerik:RadComboBoxItem runat="server" Text="70%" Value="70" />
                            <telerik:RadComboBoxItem runat="server" Text="80%" Value="80" />
                            <telerik:RadComboBoxItem runat="server" Text="90%" Value="90" />
                            <telerik:RadComboBoxItem runat="server" Text="100%" Value="100" />
                        </Items>
                    </telerik:RadComboBox>
                        <telerik:RadNumericTextBox ID="txtGM" runat="server" Culture="Chinese (People's Republic of China)"
                            LabelCssClass="radLabelCss_Office2007" Skin="Office2007" Type="Currency" 
                            Width="88px" BackColor="Silver" ReadOnly="True">
                            <NumberFormat AllowRounding="True" />
                        </telerik:RadNumericTextBox></td>
                </tr>
            	<tr style="font-size: 12pt; ">
                    <td colspan="4" height="7" >
                    </td>
                </tr>
                <tr style="font-size: 12pt; ">
                    <td style="height: 22px" >
                        <span style="font-size: 9pt; font-family: Arial">Prepared By: </span>
                    </td>
                    <td style="height: 22px"><telerik:RadTextBox ID="txtPrepared" runat="server" LabelCssClass="radLabelCss_Default"
                            Skin="Office2007" Width="180px" Font-Names="Arial" Font-Size="9pt" 
                            BackColor="Silver">
                    </telerik:RadTextBox></td>
                    <td style="height: 22px; width: 1586px;" >
                        <span style="font-size: 9pt; font-family: Arial">Proposal Date: </span>
                    </td>
                    <td style="height: 22px; width: 200px;">
                        <telerik:RadTextBox ID="txtCreateDate" runat="server" LabelCssClass="radLabelCss_Default"
                            Skin="Office2007" Width="180px" Font-Names="Arial" Font-Size="9pt" 
                            BackColor="Silver">
                           
                        </telerik:RadTextBox></td>
                </tr>
                <tr style="font-size: 12pt; ">
                    <td  style="height: 22px">
                        <span style="font-size: 9pt; font-family: Arial">PM/RM/RD:<span style="font-size: 12pt;
                            color:red; ">*</span></span></td>
                    <td style="height: 22px; font-size: 12pt; ;">
                        <telerik:RadComboBox ID="cbManager" runat="server" SkinsPath="~/RadControls/ComboBox/Skins"
                            Width="175px" ShowMoreResultsBox="True">
                        </telerik:RadComboBox>
                    </td>
                    <td  style="height: 22px; font-size: 12pt; width: 1586px; ;">
                        <span style="font-size: 9pt; font-family: Arial">Director:<span style="font-size: 12pt;
                            color:red; ">*</span></span></td>
                    <td style="height: 22px; width: 200px; font-size: 12pt; ;">
                        <telerik:RadComboBox ID="cbDirector" runat="server"  SkinsPath="~/RadControls/ComboBox/Skins"
                            Width="175px" ShowMoreResultsBox="True">
                        </telerik:RadComboBox>
                    </td>
                </tr>
                <tr style="font-size: 12pt; ">
                    <td style="height: 22px" >
                        <asp:Label ID="lblTeamMember" runat="server" Font-Names="Arial" Font-Size="9pt" Height="22px"
                            Text="Team Member: " Width="120px"></asp:Label></td>
                    <td style="height: 22px" colspan="3">
                        <telerik:RadTextBox ID="txtUserList" runat="server" Width="456px" ReadOnly="True" 
                            BackColor="Silver" Font-Names="Arial" Font-Size="9pt">
                        </telerik:RadTextBox>
                        <asp:Button ID="btnSelectUser" runat="server" Text="..." Width="24px" Height="20px" /></td>
                </tr>
                <tr style="font-size: 12pt; ">
                    <td  style="height: 22px">
                        <asp:Label ID="Label1" runat="server" Font-Names="Arial" Font-Size="9pt" Height="22px"
                            Text="Brief Description of the study" Width="120px"></asp:Label></td>
                    <td colspan="3" style="height: 22px">
                        <telerik:RadTextBox ID="txtDescription" runat="server" Font-Names="Arial" Font-Size="9pt"
                            TextMode="MultiLine" Width="488px">
                        </telerik:RadTextBox></td>
                </tr>
                <tr style="font-size: 12pt; ">
                    <td style="height: 22px"  colspan="4" align="center" >
                        &nbsp;<asp:Button ID="btnSave" runat="server" Text="Save" Width="64px" Font-Names="Arial" Font-Size="9pt"  />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="64px" Font-Names="Arial" Font-Size="9pt" />
                        <asp:Button ID="btnRefresh" runat="server" Height="0px" Text="Button" /></td>
                </tr>
            </table>
            &nbsp;<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
                <AjaxSettings>
                    <telerik:AjaxSetting AjaxControlID="txtJobName">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="txtJobName" LoadingPanelID="AjaxLoadingPanel1" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="cbClientType">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="cbInternalClient" />
                            <telerik:AjaxUpdatedControl ControlID="cbEndClient" LoadingPanelID="AjaxLoadingPanel1" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="cbEndClient">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="txtClientDescription" LoadingPanelID="AjaxLoadingPanel1" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="cbSector">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="cbProductCategory" LoadingPanelID="AjaxLoadingPanel1" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="txtQuantiRevenue">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="txtTotalRevenue" LoadingPanelID="AjaxLoadingPanel1" />
                            <telerik:AjaxUpdatedControl ControlID="txtGM" LoadingPanelID="AjaxLoadingPanel1" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="txtQualiRevenue">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="txtTotalRevenue" LoadingPanelID="AjaxLoadingPanel1" />
                            <telerik:AjaxUpdatedControl ControlID="txtGM" LoadingPanelID="AjaxLoadingPanel1" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="cbGMPercent">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="txtGM" LoadingPanelID="AjaxLoadingPanel1" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="btnSave">
                    </telerik:AjaxSetting>
                </AjaxSettings>
            </telerik:RadAjaxManager>
            <telerik:RadAjaxLoadingPanel ID="AjaxLoadingPanel1" runat="server" Height="75px" 
                Width="75px">
                <asp:Image ID="Image1" runat="server" AlternateText="Loading..." ImageUrl="~/RadControls/Ajax/Skins/Default/Loading.gif" Height="72px" />
            </telerik:RadAjaxLoadingPanel>
        
       


            <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
            </telerik:RadScriptManager>
       


    </form>
</body>
</html>
