<%@ Page Language="VB" AutoEventWireup="false" CodeFile="UpdateProposal.aspx.vb" Inherits="PMS_UpdateProposal" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
        <link href="../css/style.css" rel="stylesheet" type="text/css" />
      	<script src="../js/operation.js" type="text/javascript"></script>
      	<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
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
        
            <table cellspacing="0" class="dg" height="152" cellpadding="0" style="width: 584px" >
                <tr>
                    <td style="height: 22px;" >
                        <span style="font-size: 9pt; font-family: Arial">Job Number:<span style="font-size: 12pt;
                            color:red; font-family: Times New Roman">*</span></span></td>
                    <td style="height: 22px; width: 140px; font-size: 12pt; font-family: Times New Roman;">
                        <telerik:RadTextBox ID="txtJobNumber" runat="server" LabelCssClass="radLabelCss_Default"
                            Skin="Office2007" Width="168px" Font-Names="Arial" Font-Size="9pt" BackColor="Silver">
                        </telerik:RadTextBox></td>
                    <td style="height: 22px; font-size: 12pt; font-family: Times New Roman;" >
                        <span style="font-size: 9pt; font-family: Arial">Job Name:</span><span style="color:red">*</span></td>
                    <td style="height: 22px; width: 140px; font-size: 12pt; font-family: Times New Roman;">
                        <telerik:RadTextBox ID="txtJobName" runat="server" LabelCssClass="radLabelCss_Default"
                            Skin="Office2007" Width="168px" Font-Names="Arial" Font-Size="9pt" AutoPostBack="True">
                        </telerik:RadTextBox></td>
                </tr>
                <tr style="font-size: 12pt; font-family: Times New Roman">
                    <td style="height: 22px" >
                        <span style="font-size: 9pt; font-family: Arial">Project Type:</span></td>
                    <td style="height: 22px; width: 140px;"><telerik:RadComboBox ID="cbProjectType" runat="server"  SkinsPath="~/RadControls/ComboBox/Skins"
                            Width="160px" NoWrap="True">
                    </telerik:RadComboBox>
                    </td>
                    <td style="height: 22px" >
                        <span style="font-size: 9pt; font-family: Arial">Office:</span></td>
                    <td style="height: 22px; width: 140px; font-size: 12pt; font-family: Times New Roman;">
                        <telerik:RadComboBox ID="cbCity" runat="server"  SkinsPath="~/RadControls/ComboBox/Skins"
                            Width="160px">
                        </telerik:RadComboBox>
                    </td>
                </tr>
                <tr style="font-size: 12pt; font-family: Times New Roman">
                    <td height="16" >
                        <span style="font-size: 9pt; font-family: Arial">Client Type:</span><span style="color:red"></span></td>
                    <td height="22" style="width: 140px">
                        <telerik:RadComboBox ID="cbClientType" runat="server"  SkinsPath="~/RadControls/ComboBox/Skins"
                            Width="160px" AutoPostBack="True">
                            <Items>
                                <telerik:RadComboBoxItem ID="RadComboBoxItem1" runat="server" Selected="True" Text="----NULL----" Value="0" />
                                <telerik:RadComboBoxItem ID="RadComboBoxItem2" runat="server" Text="Internal Client" Value="1" />
                                <telerik:RadComboBoxItem ID="RadComboBoxItem3" runat="server" Text="External Client" Value="2" />
                            </Items>
                        </telerik:RadComboBox>
                    </td>
                    <td height="22" >
                        <span style="font-size: 9pt; font-family: Arial">Status:</span></td>
                    <td height="22" style="width: 140px">
                        <telerik:RadComboBox ID="cbStatus" runat="server"  SkinsPath="~/RadControls/ComboBox/Skins"
                            Width="160px" AutoPostBack="True">
                        </telerik:RadComboBox>
                    </td>
                </tr>
                <tr style="font-size: 12pt; font-family: Times New Roman">
                    <td height="15" >
                        <span style="font-size: 9pt; font-family: Arial">Internal Client:</span></td>
                    <td colspan="3" height="22">
                        <telerik:RadComboBox ID="cbInternalClient" runat="server"  SkinsPath="~/RadControls/ComboBox/Skins"
                            Width="448px" Height="300px" MarkFirstMatch="True" ShowMoreResultsBox="True" ExpandEffect="RandomDissolve">
                        </telerik:RadComboBox>
                    </td>
                </tr>
                <tr style="font-size: 12pt; font-family: Times New Roman">
                    <td style="height: 22px;" >
                        <span style="font-size: 9pt; font-family: Arial">Ending Client:</span></td>
                    <td colspan="3" style="height: 22px">
                        <telerik:RadComboBox ID="cbEndClient" runat="server"  SkinsPath="~/RadControls/ComboBox/Skins"
                            Width="448px" Height="300px" MarkFirstMatch="True" ShowMoreResultsBox="True" AutoPostBack="True" ExpandEffect="RandomDissolve" DropDownWidth="480px">
                        </telerik:RadComboBox>
                    </td>
                </tr>
                <tr style="font-size: 12pt; font-family: Times New Roman">
                    <td height="15" >
                        <span style="font-size: 9pt; font-family: Arial">Client Description:</span></td>
                    <td colspan="3" height="22"><telerik:RadTextBox ID="txtClientDescription" runat="server" LabelCssClass="radLabelCss_Office2007"
                            Skin="Office2007" Width="450px" Font-Names="Arial" Font-Size="9pt" BackColor="Silver">
                    </telerik:RadTextBox></td>
                </tr>
                <tr style="font-size: 12pt; font-family: Times New Roman">
                    <td colspan="4" height="7" >
                    </td>
                </tr>
                <tr style="font-size: 12pt; font-family: Times New Roman">
                    <td style="height: 22px;" >
                        <span style="font-size: 9pt; font-family: Arial">Sector:<span style="font-size: 12pt;
                            color:red; font-family: Times New Roman">*</span></span></td>
                    <td style="height: 22px; width: 140px; font-size: 12pt; font-family: Times New Roman;">
                        <telerik:RadComboBox ID="cbSector" runat="server"  SkinsPath="~/RadControls/ComboBox/Skins"
                            Width="160px" AutoPostBack="True" ExpandEffect="RandomDissolve">
                        </telerik:RadComboBox>
                    </td>
                    <td style="height: 22px; font-size: 12pt; font-family: Times New Roman;" >
                        <span style="font-size: 9pt; font-family: Arial">Product Category:</span><span style="color:red">*</span></td>
                    <td style="height: 22px; width: 140px; font-size: 12pt; font-family: Times New Roman;">
                        <telerik:RadComboBox ID="cbProductCategory" runat="server"  SkinsPath="~/RadControls/ComboBox/Skins"
                            Width="160px" ShowMoreResultsBox="True" Height="300px" ExpandEffect="RandomDissolve">
                        </telerik:RadComboBox>
                    </td>
                </tr>
                <tr style="font-size: 12pt; font-family: Times New Roman">
                    <td style="height: 17px" >
                        <span style="font-size: 9pt; font-family: Arial">Business solution: <span style="font-size: 12pt;
                            color:red; font-family: Times New Roman">*</span></span></td>
                    <td style="height: 17px; width: 140px; font-size: 12pt; font-family: Times New Roman;">
                        <telerik:RadComboBox ID="cbBS" runat="server"  SkinsPath="~/RadControls/ComboBox/Skins"
                            Width="160px" ExpandEffect="RandomDissolve" Height="300px">
                        </telerik:RadComboBox>
                    </td>
                    <td style="height: 17px; font-size: 12pt; font-family: Times New Roman;" >
                        <span style="font-size: 9pt; font-family: Arial">Other Business Sou.</span></td>
                    <td style="height: 22px; width: 140px; font-size: 12pt; font-family: Times New Roman;">
                        <telerik:RadComboBox ID="cbOtherBS" runat="server"  SkinsPath="~/RadControls/ComboBox/Skins"
                            Width="160px" ShowMoreResultsBox="True" ExpandEffect="RandomDissolve" Height="300px">
                        </telerik:RadComboBox>
                    </td>
                </tr>
                <tr style="font-size: 12pt; font-family: Times New Roman">
                    <td style="height: 17px" >
                        <span style="font-size: 9pt; font-family: Arial">AOE:</span><span style="color:red">*</span></td>
                    <td style="height: 17px; width: 140px;">
                        <telerik:RadComboBox ID="cbAOE" runat="server"  SkinsPath="~/RadControls/ComboBox/Skins"
                            Width="160px" ExpandEffect="RandomDissolve">
                        </telerik:RadComboBox>
                    </td>
                    <td style="height: 17px" >
                        <span style="font-size: 9pt; font-family: Arial">Digital Products: <span style="font-size: 12pt;
                            color:red; font-family: Times New Roman">*</span></span></td>
                    <td style="height: 22px; width: 140px; font-size: 12pt; font-family: Times New Roman;">
                        <telerik:RadComboBox ID="cbDigital" runat="server" ExpandEffect="RandomDissolve" Height="300px"
                            ShowMoreResultsBox="True"  SkinsPath="~/RadControls/ComboBox/Skins"
                            Width="160px">
                        </telerik:RadComboBox>
                    </td>
                </tr>
                <tr style="font-size: 12pt; font-family: Times New Roman">
                    <td style="height: 17px" >
                        <span style="font-size: 9pt; font-family: Arial">Probability: <span style="font-size: 12pt;
                            color:red; font-family: Times New Roman">*</span></span></td>
                    <td style="height: 17px; width: 140px; font-size: 12pt; font-family: Times New Roman;">
                        <telerik:RadNumericTextBox ID="txtProbablity" runat="server" Culture="Chinese (People's Republic of China)"
                            LabelCssClass="radLabelCss_Default" Skin="" Type="Percent" Width="168px" MaxValue="100" MinValue="0">
                            <NumberFormat AllowRounding="True" DecimalDigits="0" />
                        </telerik:RadNumericTextBox></td>
                    <td style="height: 17px; font-size: 12pt; font-family: Times New Roman;" >
                        .</td>
                    <td style="height: 22px; width: 140px; font-size: 12pt; font-family: Times New Roman;">
                        .</td>
                </tr>
                <tr style="font-size: 12pt; font-family: Times New Roman">
                    <td style="height: 17px" >
                        <span style="font-size: 9pt; font-family: Arial">Quanti Revenue: </span>
                    </td>
                    <td style="height: 17px; width: 140px;">
                        <telerik:RadNumericTextBox ID="txtQuantiRevenue" runat="server" Culture="Chinese (People's Republic of China)"
                            LabelCssClass="radLabelCss_Default" Skin="" Type="Currency" Width="168px" AutoPostBack="True">
                            <NumberFormat AllowRounding="True" />
                        </telerik:RadNumericTextBox></td>
                    <td style="height: 17px" >
                        <span style="font-size: 9pt; font-family: Arial">Quali Revenue: </span>
                    </td>
                    <td style="height: 22px; width: 140px;">
                        <telerik:RadNumericTextBox ID="txtQualiRevenue" runat="server" Culture="Chinese (People's Republic of China)"
                            LabelCssClass="radLabelCss_Default" Skin="" Type="Currency" Width="168px" AutoPostBack="True">
                            <NumberFormat AllowRounding="True" />
                        </telerik:RadNumericTextBox></td>
                </tr>
                <tr style="font-size: 12pt; font-family: Times New Roman">
                    <td style="height: 17px" >
                        <span style="font-size: 9pt; font-family: Arial">Total Revenue: </span>
                    </td>
                    <td style="height: 17px; width: 140px;">
                        <telerik:RadNumericTextBox ID="txtTotalRevenue" runat="server" Culture="Chinese (People's Republic of China)"
                            LabelCssClass="radLabelCss_Default" Skin="" Type="Currency" Width="168px">
                            <NumberFormat AllowRounding="True" />
                        </telerik:RadNumericTextBox></td>
                    <td style="height: 17px" >
                        <span style="font-size: 9pt; font-family: Arial">Estimate GM:</span></td>
                    <td style="height: 22px; width: 140px;">
                        <telerik:RadComboBox ID="cbGMPercent" runat="server"  SkinsPath="~/RadControls/ComboBox/Skins"
                            Width="48px" ShowMoreResultsBox="True" AutoPostBack="True">
                        <Items>
                            <telerik:RadComboBoxItem ID="RadComboBoxItem9" runat="server" Selected="True" Text="-NULL-" Value="0" />
                            <telerik:RadComboBoxItem ID="RadComboBoxItem10" runat="server" Text="10%" Value="10" />
                            <telerik:RadComboBoxItem ID="RadComboBoxItem11" runat="server" Text="20%" Value="20" />
                            <telerik:RadComboBoxItem ID="RadComboBoxItem12" runat="server" Text="30%" Value="30" />
                            <telerik:RadComboBoxItem ID="RadComboBoxItem13" runat="server" Text="40%" Value="40" />
                            <telerik:RadComboBoxItem ID="RadComboBoxItem14" runat="server" Text="50%" Value="50" />
                            <telerik:RadComboBoxItem ID="RadComboBoxItem15" runat="server" Text="60%" Value="60" />
                            <telerik:RadComboBoxItem ID="RadComboBoxItem16" runat="server" Text="70%" Value="70" />
                            <telerik:RadComboBoxItem ID="RadComboBoxItem17" runat="server" Text="80%" Value="80" />
                            <telerik:RadComboBoxItem ID="RadComboBoxItem18" runat="server" Text="90%" Value="90" />
                            <telerik:RadComboBoxItem ID="RadComboBoxItem19" runat="server" Text="100%" Value="100" />
                        </Items>
                    </telerik:RadComboBox>
                        <telerik:RadNumericTextBox ID="txtGM" runat="server" Culture="Chinese (People's Republic of China)"
                            LabelCssClass="radLabelCss_Office2007" Skin="Office2007" Type="Currency" Width="56px" BackColor="Silver" ReadOnly="True">
                            <NumberFormat AllowRounding="True" />
                        </telerik:RadNumericTextBox></td>
                </tr>
            	<tr style="font-size: 12pt; font-family: Times New Roman">
                    <td colspan="4" height="7" >
                    </td>
                </tr>
                <tr style="font-size: 12pt; font-family: Times New Roman">
                    <td style="height: 22px" >
                        <span style="font-size: 9pt; font-family: Arial">Prepared By: </span>
                    </td>
                    <td style="height: 22px; width: 140px;"><telerik:RadTextBox ID="txtPrepared" runat="server" LabelCssClass="radLabelCss_Default"
                            Skin="Office2007" Width="168px" Font-Names="Arial" Font-Size="9pt" BackColor="Silver">
                    </telerik:RadTextBox></td>
                    <td style="height: 22px" >
                        <span style="font-size: 9pt; font-family: Arial">Proposal Date: </span>
                    </td>
                    <td style="height: 22px; width: 140px;">
                        <telerik:RadTextBox ID="txtCreateDate" runat="server" LabelCssClass="radLabelCss_Default"
                            Skin="Office2007" Width="168px" Font-Names="Arial" Font-Size="9pt" BackColor="Silver">
                           
                        </telerik:RadTextBox></td>
                </tr>
                <tr style="font-size: 12pt; font-family: Times New Roman">
                    <td  style="height: 22px">
                        <span style="font-size: 9pt; font-family: Arial">Director: <span style="font-size: 12pt;
                            color:red; font-family: Times New Roman">*</span></span></td>
                    <td style="width: 140px; height: 22px; font-size: 12pt; font-family: Times New Roman;">
                        <telerik:RadComboBox ID="cbDirector"  runat="server"  SkinsPath="~/RadControls/ComboBox/Skins"
                            Width="160px" ShowMoreResultsBox="True">
                        </telerik:RadComboBox>
                    </td>
                    <td  style="height: 22px; font-size: 12pt; font-family: Times New Roman;">
                        <span style="font-size: 9pt; font-family: Arial">PM/RM/RD: <span style="font-size: 12pt;
                            color:red; font-family: Times New Roman">*</span></span></td>
                    <td style="width: 140px; height: 22px; font-size: 12pt; font-family: Times New Roman;">
                        <telerik:RadComboBox ID="cbManager" runat="server"  SkinsPath="~/RadControls/ComboBox/Skins"
                            Width="160px" ShowMoreResultsBox="True">
                        </telerik:RadComboBox>
                    </td>
                </tr>
                <tr style="font-size: 12pt; font-family: Times New Roman">
                    <td style="height: 22px" >
                        <asp:Label ID="lblTeamMember" runat="server" Font-Names="Arial" Font-Size="9pt" Height="22px"
                            Text="Team Member: " Width="120px"></asp:Label></td>
                    <td style="height: 22px;" colspan="3">
                        <telerik:RadTextBox ID="txtUserList" runat="server" BackColor="Silver" Font-Names="Arial"
                            Font-Size="9pt" ReadOnly="True" Width="424px">
                        </telerik:RadTextBox><asp:Button ID="btnSelectUser" runat="server" Height="20px" Text="..."
                            Width="24px" /></td>
                </tr>
                <tr style="font-size: 12pt; font-family: Times New Roman">
                    <td  style="height: 22px">
                        <asp:Label ID="Label1" runat="server" Font-Names="Arial" Font-Size="9pt" Height="22px"
                            Text="Brief Description of the study" Width="120px"></asp:Label></td>
                    <td colspan="3" style="height: 22px">
                        <telerik:RadTextBox ID="txtDescription" runat="server" Font-Names="Arial" Font-Size="9pt"
                            TextMode="MultiLine" Width="450px">
                        </telerik:RadTextBox></td>
                </tr>
                <tr style="font-size: 12pt; font-family: Times New Roman">
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
                    <telerik:AjaxSetting AjaxControlID="cbStatus">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="cbStatus" LoadingPanelID="AjaxLoadingPanel1" />
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
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="txtAlert" LoadingPanelID="AjaxLoadingPanel1" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                </AjaxSettings>
            </telerik:RadAjaxManager>
            <telerik:RadAjaxLoadingPanel ID="AjaxLoadingPanel1" runat="server" Height="75px" Width="75px">
                <asp:Image ID="Image1" runat="server" AlternateText="Loading..." ImageUrl="~/RadControls/Ajax/Skins/Default/Loading.gif" Height="72px" />
            </telerik:RadAjaxLoadingPanel>
        
        <div style="z-index: 103; left: 8px; width: 560px; position: absolute; top: 0px;
            height: 1px; font-size: 12pt; font-family: Times New Roman;">
            <telerik:RadTextBox ID="txtAlert" runat="server" AutoPostBack="True" BorderColor="White"
                Font-Bold="True" Font-Names="Verdana" Font-Size="11pt" ForeColor="Red" Width="480px">
            </telerik:RadTextBox></div>
       

        <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
        </telerik:RadScriptManager>
       

    </form>
</body>
</html>
