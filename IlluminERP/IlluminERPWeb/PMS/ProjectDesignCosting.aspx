<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ProjectDesignCosting.aspx.vb"
    Inherits="PMS_ProjectDesignCosting" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Design</title>
    <base target="_self" />
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <script src="../js/validation.js" type="text/javascript"></script>
    <script src="../js/operation.js" type="text/javascript"></script>   
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
        <table width="100%" class="bg">
            <tr>
                <td style="width: 120px; text-align: right">
                    Sub Job Number :
                </td>
                <td style="width: 120px">
                    <telerik:RadTextBox ID="txtSubJobNumber" runat="server">
                    </telerik:RadTextBox>
                </td>
                <td style="width: 110px">
                    Methodology:
                </td>
                <td style="width: 120px">
                    <telerik:RadTextBox ID="txtMethodology" runat="server">
                    </telerik:RadTextBox>
                </td>
                <td style="width: 80px">
                    Description:
                </td>
                <td style="text-align: left">
                    <telerik:RadTextBox ID="txtCityDescription" Width="250px" runat="server">
                    </telerik:RadTextBox>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <fieldset style="width: 96%">
                        <legend>City Sample Size</legend>
                        <table width="100%">
                            <tr>
                                <td style="width: 106px; text-align: right">
                                    Select City :
                                </td>
                                <td style="width: 110px; text-align: left">
                                    <telerik:RadComboBox ID="cbDistrict" runat="server" Width="105px" Height="300px"
                                        MarkFirstMatch="True" Skin="Office2007" AutoPostBack="True">
                                    </telerik:RadComboBox>
                                </td>
                                <td style="width: 110px">
                                    <telerik:RadComboBox ID="cbProvince" runat="server" Width="105px" Height="300px"
                                        Skin="Office2007" AutoPostBack="True">
                                    </telerik:RadComboBox>
                                </td>
                                <td style="width: 110px">
                                    <telerik:RadComboBox ID="cbCity" runat="server" Width="105px" Height="300px" Skin="Office2007"
                                        CausesValidation="True">
                                    </telerik:RadComboBox>
                                </td>
                                <td style="width: 116px; text-align: right">
                                    Sample Size:
                                </td>
                                <td style="text-align: left">
                                    <telerik:RadNumericTextBox ID="txtSampleSize" runat="server" Width="280" Font-Names="Arial"
                                        Font-Overline="False" Font-Size="9pt">
                                        <NumberFormat AllowRounding="True" DecimalDigits="0" />
                                    </telerik:RadNumericTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right">
                                    Description :
                                </td>
                                <td colspan="5" style="text-align: left">
                                    <telerik:RadTextBox runat="server" ID="txtDescription" Width="742px">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6">
                                    <asp:Button runat="server" class="btnadd" ID="btnAdd" Text="Add" />&nbsp; <span style="font-size: 10pt;
                                        font-family: Arial"><strong><span style="font-size: 9pt">Total Samplesizes</span>&nbsp;
                                            <telerik:RadNumericTextBox ID="txtTotalSampleSize" runat="server" Width="88px" Font-Names="Arial"
                                                Font-Overline="False" Font-Size="9pt" ReadOnly="true" AutoPostBack="true">
                                            </telerik:RadNumericTextBox>
                                        </strong></span>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6">
                                    <telerik:RadGrid ID="rdCiySampleSize" runat="server" AutoGenerateColumns="False"
                                        AutoGenerateDeleteColumn="True" GridLines="None" Skin="Office2007">
                                        <MasterTableView AllowPaging="True" PageSize="5">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="Id" HeaderText="Id" UniqueName="Id" Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="SubProId" HeaderText="SubProId" UniqueName="SubProId"
                                                    Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="CityId" HeaderText="City" UniqueName="City">
                                                    <HeaderStyle Width="100px" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                                                        Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Samplesize" HeaderText="Samplesize" UniqueName="Samplesize">
                                                    <HeaderStyle Width="100px" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                                                        Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Description" HeaderText="Description" UniqueName="Description">
                                                    <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                        Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridButtonColumn CommandName="Delete" Text="Delete" UniqueName="AutoGeneratedDeleteColumn">
                                                    <HeaderStyle Width="45px" />
                                                </telerik:GridButtonColumn>
                                            </Columns>
                                            <ExpandCollapseColumn Resizable="False" Visible="False">
                                                <HeaderStyle Width="20px" />
                                            </ExpandCollapseColumn>
                                            <RowIndicatorColumn Visible="False">
                                                <HeaderStyle Width="20px" />
                                            </RowIndicatorColumn>
                                            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                        </MasterTableView>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </td>
            </tr>
            <tr runat="server" id="QuantiRow" style="display:none">
                <td colspan="6">
                    <fieldset style="width: 96%">
                        <legend>Recruitment </legend>
                        <table width="100%">
                            <tr>
                                <td style="text-align: right; width: 220px">
                                    Sampling method:
                                </td>
                                <td style="text-align: left; width: 200px">
                                   <asp:RadioButtonList ID="radblSamplingMethod" runat="server" Font-Names="Arial" Font-Size="9pt"
                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                </asp:RadioButtonList>
                                </td>
                                <td style="text-align: right; width: 200px">
                                    LEN of&nbsp; questionnair:
                                </td>
                                <td style="text-align: left">
                                    <telerik:RadNumericTextBox ID="txtLenofQues" runat="server" Width="104px" Font-Names="Arial"
                                        Font-Overline="False" Font-Size="9pt">                                      
                                    </telerik:RadNumericTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right">
                                    NO. of&nbsp; OEQ
                                </td>
                                <td style="text-align: left">
                                    <asp:RadioButtonList ID="radblNOofOEQ" runat="server" Font-Names="Arial" Font-Size="9pt"
                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                </asp:RadioButtonList>
                                <telerik:RadTextBox  ID="txtNoofOEQ" runat="server" Width="88px"></telerik:RadTextBox>
                               
                                </td>
                                <td style="text-align: right">
                                    Project Scope:
                                </td>
                                <td style="text-align: left">
                                    <asp:RadioButtonList ID="radblProjectscope" runat="server" Font-Names="Arial" Font-Size="9pt"
                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right">
                                    Data format:
                                </td>
                                <td style="text-align: left">
                                   <asp:RadioButtonList ID="radblDataformat" runat="server" Font-Names="Arial" Font-Size="9pt"
                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                </asp:RadioButtonList>
                                </td>
                                <td style="text-align: right">
                                    <span style="font-size: 9pt; font-family: Arial">Data Map:</span>
                                </td>
                                <td style="text-align: left">
                                    <asp:RadioButtonList ID="radblDatamap" runat="server" Font-Names="Arial" Font-Size="9pt"
                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                </asp:RadioButtonList>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </td>
            </tr>
            <tr runat="server" id="QualiRow">
                <td colspan="6">
                    <fieldset style="width: 96%">
                        <legend>Recruitment </legend>
                        <table width="100%">
                            <tr>
                                <td style="text-align: right; width: 220px">
                                    Client list:
                                </td>
                                <td style="text-align: left; width: 200px">
                                    <asp:CheckBoxList ID="chklClientList" runat="server" Font-Names="Arial" Font-Size="9pt"
                                        RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    </asp:CheckBoxList>
                                </td>
                                <td style="text-align: right; width: 200px">
                                    Transcript needed:
                                </td>
                                <td style="text-align: left">
                                    <asp:CheckBoxList ID="chklTranscript" runat="server" Font-Names="Arial" Font-Size="9pt"
                                        RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    </asp:CheckBoxList>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right">
                                    Audio tape recording needed:
                                </td>
                                <td style="text-align: left">
                                    <asp:CheckBoxList ID="chklAudio" runat="server" Font-Names="Arial" Font-Size="9pt"
                                        RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    </asp:CheckBoxList>
                                </td>
                                <td style="text-align: right">
                                    Video tape recording needed:
                                </td>
                                <td style="text-align: left">
                                    <asp:CheckBoxList ID="chklVideo" runat="server" Font-Names="Arial" Font-Size="9pt"
                                        RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    </asp:CheckBoxList>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right">
                                    Video format:
                                </td>
                                <td style="text-align: left">
                                    <asp:RadioButtonList ID="radblVideoformat" runat="server" Font-Names="Arial" Font-Size="9pt"
                                        RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    </asp:RadioButtonList>
                                    <telerik:RadTextBox ID="txtVideoformat" runat="server" Width="88px">
                                    </telerik:RadTextBox>
                                </td>
                                <td style="text-align: right">
                                    <span style="font-size: 9pt; font-family: Arial">Translator require:</span>
                                </td>
                                <td style="text-align: left">
                                    <asp:CheckBoxList ID="chklTranslator" runat="server" Font-Names="Arial" Font-Size="9pt"
                                        RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    </asp:CheckBoxList>
                                    <telerik:RadTextBox ID="txtTranslator" runat="server" Width="88px">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </td>
            </tr>
            <tr runat="server" id="CriteriaRow">
                <td  colspan="6">
                <fieldset style="width: 96%">
                        <legend>Criteria </legend>
                        <table width="100%">
                            <tr >
                                <td style="text-align:right;width:220px">
                                Age:
                                </td>
                                <td style="text-align:left">
                                <asp:CheckBoxList ID="chklCAge" runat="server" Font-Names="Arial" Font-Size="9pt"
                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                </asp:CheckBoxList>
                                </td>
                            </tr>
                            <tr>
                               <td style="text-align:right">
                                Gender:
                                </td>
                                <td style="text-align:left">
                                <asp:CheckBoxList ID="chklCGender" runat="server" Font-Names="Arial" Font-Size="9pt"
                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                </asp:CheckBoxList>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:right">
                                Monthly HH income:
                                </td>
                                <td style="text-align:left">
                                <asp:CheckBoxList ID="chklCMonthlyIncome" runat="server" Font-Names="Arial" Font-Size="9pt"
                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                </asp:CheckBoxList>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:right">
                                Product usage frequency:
                                </td>
                                <td style="text-align:left">
                                <asp:CheckBoxList ID="chklCFrequency" runat="server" Font-Names="Arial" Font-Size="9pt"
                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                </asp:CheckBoxList>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:right">
                                Role in decision making process:
                                </td>
                                <td style="text-align:left">
                                <asp:CheckBoxList ID="chklCRole" runat="server" Font-Names="Arial" Font-Size="9pt"
                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                </asp:CheckBoxList>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </td>
            </tr>
            <tr runat="server" id="AutomotiveRow" style="display:none">
            <td colspan="6">
            <fieldset style="width: 96%">
                        <legend>Automotive </legend>
                        <table width="100%">
                            <tr >
                                <td style="text-align:right;width:220px">
                                Car OwnerShip:
                                </td>
                                <td style="text-align:left">
                                <asp:CheckBoxList ID="chklACarOwnership" runat="server" Font-Names="Arial" Font-Size="9pt"
                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                </asp:CheckBoxList>
                                </td>
                            </tr>
                                <tr >
                                <td style="text-align:right;width:220px">
                                Car Segment(Car Owner):
                                </td>
                                <td style="text-align:left">
                                <asp:CheckBoxList ID="chklACarSegment" runat="server" Font-Names="Arial" Font-Size="9pt"
                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                </asp:CheckBoxList>
                                </td>
                            </tr> 
                            <tr >
                                <td style="text-align:right;width:220px">
                               Pricing level(purchase intender)::
                                </td>
                                <td style="text-align:left">
                               <asp:CheckBoxList ID="chklAPricingLevel" runat="server" Font-Names="Arial" Font-Size="9pt"
                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                </asp:CheckBoxList>
                                </td>
                            </tr>                
                                            
                        </table>
            </fieldset>
            </td>
            </tr>
            <tr runat="server" id="BusinessRow" style="display:none">
            <td colspan="6">
            <fieldset style="width: 96%">
                        <legend>Business </legend>
                        <table width="100%">
                            <tr >
                                <td style="text-align:right;width:220px">
                                Number of Employee:
                                </td>
                                <td style="text-align:left">
                                <asp:CheckBoxList ID="chklBEmployeeNO" runat="server" Font-Names="Arial" Font-Size="9pt"
                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                </asp:CheckBoxList>
                                </td>
                            </tr>
                                <tr >
                                <td style="text-align:right;width:220px">
                                Position:
                                </td>
                                <td style="text-align:left">
                                <asp:CheckBoxList ID="chklBPosition" runat="server" Font-Names="Arial" Font-Size="9pt"
                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                </asp:CheckBoxList>
                                </td>
                            </tr>           
                        </table>
            </fieldset>
            </td>
            </tr>
            <tr runat="server" id="FinanceRow" style="display:none">
            <td colspan="6">
            <fieldset style="width: 96%">
                        <legend>Finance </legend>
                        <table width="100%">
                            <tr >
                                <td style="text-align:right;width:220px">
                                Market:
                                </td>
                                <td style="text-align:left">
                               <asp:CheckBoxList ID="chklFMarket" runat="server" Font-Names="Arial" Font-Size="9pt"
                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                </asp:CheckBoxList>
                                </td>
                            </tr>
                                      
                        </table>
            </fieldset>
            </td>
            </tr>
            <tr runat="server" id="HealthcareRow" style="display:none">
            <td colspan="6">
            <fieldset style="width: 96%">
                        <legend>Healthcare </legend>
                        <table width="100%">
                            <tr >
                                <td style="text-align:right;width:220px">
                                Degree:
                                </td>
                                <td style="text-align:left">
                               <asp:CheckBoxList ID="chklHDegree" runat="server" Font-Names="Arial" Font-Size="9pt"
                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                </asp:CheckBoxList>
                                </td>
                            </tr>
                                 <tr >
                                <td style="text-align:right;width:220px">
                                Job Title:
                                </td>
                                <td style="text-align:left">
                                <asp:CheckBoxList ID="chklHJobTitle" runat="server" Font-Names="Arial" Font-Size="9pt"
                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                </asp:CheckBoxList>
                                </td>
                            </tr>     
                        </table>
            </fieldset>
            </td>
            </tr>
            <tr>
                <td  colspan="6" runat="server" id="TechnologyRow">
                <fieldset style="width: 96%">
                        <legend>Technology </legend>
                        <table width="100%">
                            <tr >
                                <td style="text-align:right;width:220px">
                                Number of employee:
                                </td>
                                <td style="text-align:left">
                                <asp:CheckBoxList ID="chklTEmployeeNO" runat="server" Font-Names="Arial" Font-Size="9pt"
                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                </asp:CheckBoxList>
                                </td>
                            </tr>
                            <tr>
                               <td style="text-align:right">
                                Job Title:
                                </td>
                                <td style="text-align:left">
                                <asp:CheckBoxList ID="chklTJobTitle" runat="server" Font-Names="Arial" Font-Size="9pt"
                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                </asp:CheckBoxList>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:right">
                                Role in decrision making Process:
                                </td>
                                <td style="text-align:left">
                               <asp:CheckBoxList ID="chklTRole" runat="server" Font-Names="Arial" Font-Size="9pt"
                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                </asp:CheckBoxList>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:right">
                               Ownership:
                                </td>
                                <td style="text-align:left">
                               <asp:CheckBoxList ID="chklTOwnership" runat="server" Font-Names="Arial" Font-Size="9pt"
                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                </asp:CheckBoxList>
                                </td>
                            </tr>                          
                        </table>
                    </fieldset>
                </td>
            </tr>
            <tr>
            <td  colspan="6" style="width:100%;text-align:center">
             <asp:Button ID="btnSave" CssClass="btnsave" runat="server" Font-Names="Arial" Font-Size="9pt" Text="Save"
                Width="58px" />
            <%--<asp:Button ID="btnCancel" runat="server" Font-Names="Arial" Font-Size="9pt" Text="Cancel" />--%>
            <input type="button" name="btnCancel" value="Cancel" class="btnclose" onclick="javascript:CloseModelWindow();" />
                            <asp:Button ID="btnEmail" runat="server" Font-Names="Arial" Font-Size="9pt" Text="Email"
                Width="58px" />
            </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
