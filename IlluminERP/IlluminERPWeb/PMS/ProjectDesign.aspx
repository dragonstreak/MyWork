<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ProjectDesign.aspx.vb" Inherits="PMS_ProjectDesign" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <script src="../js/validation.js" type="text/javascript"></script>
    <script src="../js/operation.js" type="text/javascript"></script>
    <script type="text/javascript">
        //this method is used to open add user page.
        function OpenProjectDesignCostingPage(SubProId) {
            var randomStr = getRandom()
            var addResult = window.showModalDialog("ProjectDesignCosting.aspx?i=" + randomStr + '&SubProId=' + SubProId, window, 'dialogWidth=1024px;dialogHeight=700px;center:yes;location:no');
            if (addResult == 'success') {
                //refresh the grid,please take care of the control name, maybe not btnQuery.
                //$("input[id$='btnQuery']").click();
            }
        }
        function OpenProjectCostPage(SubProId) {
            var randomStr = getRandom()
            var addResult = window.showModalDialog("ProjectCost.aspx?i=" + randomStr + '&SubProId=' + SubProId, window, 'dialogWidth=1024px;dialogHeight=450px;center:yes;location:no');
            if (addResult == 'success') {
                //refresh the grid,please take care of the control name, maybe not btnQuery.
                //$("input[id$='btnQuery']").click();
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
        <telerik:RadTabStrip runat="server" MultiPageID="RadMultiPage1" ID="RadTabStrip3"
            SelectedIndex="0" Height="100%" Width="100%">
            <Tabs>
                <telerik:RadTab Text="Create Methodology">
                </telerik:RadTab>
                <telerik:RadTab Text="Project Simulation">
                </telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>
        <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0" CssClass="pageView"
            Width="100%" Height="100%">
            <telerik:RadPageView ID="RadPageView1" runat="server" Width="100%" Height="100%">
                <table width="100%" class="query" id="table1">
                    <tbody id="main">
                        <tr>
                            <td width="15%">
                                Meth.Type:
                            </td>
                            <td width="35%">
                                <asp:DropDownList ID="ddlMethType" AutoPostBack="True" runat="server">
                                    <asp:ListItem Selected="True" Value="1">Quantitative</asp:ListItem>
                                    <asp:ListItem Value="2">Qualitative</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td width="15%">
                                Methodology:
                            </td>
                            <td width="35%">
                                <asp:DropDownList ID="ddlMethodology" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td width="15%">
                                Description:
                            </td>
                            <td width="35%" colspan="3">
                                <telerik:RadTextBox ID="txtDescription" runat="server" Width="95%">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr class="dgf">
                            <td colspan="4">
                                <asp:Button ID="btnAdd" runat="server" CssClass="btnadd" Text="Add Methodology" />
                                <asp:Button ID="btnBack" runat="server" CssClass="btncancel" Text="Return" />
                                <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
                                            <AjaxSettings>
                                                <telerik:AjaxSetting AjaxControlID="ddlMethType">
                                                   
                                                </telerik:AjaxSetting>
                                                <%--<rad:AjaxSetting AjaxControlID="btnAdd">
                                                    <UpdatedControls>
                                                        <rad:AjaxUpdatedControl ControlID="dgSubProject" />
                                                    </UpdatedControls>
                                                </rad:AjaxSetting>--%>
                                              
                                            </AjaxSettings>
                                        </telerik:RadAjaxManager>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <div class="queryresultgrid">
                    <telerik:RadGrid ID="gridResult" runat="server" AllowPaging="False" AllowSorting="True"
                        AutoGenerateColumns="False" GridLines="None" AutoGenerateDeleteColumn="True">
                        <ClientSettings AllowColumnsReorder="True" ReorderColumnsOnClient="True">
                            <Selecting AllowRowSelect="True" />
                            <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                        </ClientSettings>
                        <MasterTableView>
                            <RowIndicatorColumn>
                                <HeaderStyle Width="20px"></HeaderStyle>
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn>
                                <HeaderStyle Width="20px"></HeaderStyle>
                            </ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridBoundColumn DataField="Id" HeaderText="Id" UniqueName="Id" Visible="False">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="ProId" HeaderText="ProId" UniqueName="ProId"
                                    Visible="False">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="SubJobNumber" HeaderText="Sub Job Number" UniqueName="SubJobNumber">
                                    <HeaderStyle Width="120px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="MethodologyType" HeaderText="Meth Type" UniqueName="MethodologyTypeColumn">
                                    <HeaderStyle Width="65px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="MethodologyId" HeaderText="Methodology" UniqueName="MethodologyIdColumn">
                                    <HeaderStyle Width="100px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Description" HeaderText="Description" UniqueName="DescriptionColumn">
                                </telerik:GridBoundColumn>
                               <%-- <telerik:GridButtonColumn CommandName="gbcDesign" Text="Design" UniqueName="designColumn">
                                <HeaderStyle Width="55" />
                                </telerik:GridButtonColumn>--%>
                                <telerik:GridBoundColumn HeaderText="Design" UniqueName="designColumn">
                                <HeaderStyle Width="55px" />
                                </telerik:GridBoundColumn>
                                 <telerik:GridBoundColumn HeaderText="Cost" UniqueName="costColumn">
                                <HeaderStyle Width="55px" />
                                </telerik:GridBoundColumn>
                                <%-- <telerik:GridButtonColumn CommandName="gbcCost" Text="Cost" UniqueName="costColumn">
                                <HeaderStyle Width="55px" />
                                </telerik:GridButtonColumn> --%>
                                <telerik:GridButtonColumn CommandName="Delete" Text="Delete" UniqueName="AutoGeneratedDeleteColumn">
                                    <HeaderStyle Width="55px" />
                                </telerik:GridButtonColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                </div>
                <div>
                <table id="TABLE2" onclick="return TABLE1_onclick()"              
                style="border-left-color: gray;
                                        border-bottom-color: gray; width: 384px; border-top-color: gray; border-collapse: collapse;
                                        height: 100%; border-right-color: gray;margin:0 auto">
                                        <tbody>
                                            <tr>
                                                <td colspan="2" style="font-weight: bold; font-size: 9pt; width: 100px; font-family: Arial;
                                                    height: 18px; text-align: center">
                                                    Quantitative</td>
                                                <td colspan="2" style="font-weight: bold; font-size: 9pt; width: 100px; font-family: Arial;
                                                    height: 18px; text-align: center">
                                                    Qualitative</td>
                                            </tr>
                                            <tr>
                                                <td style="font-size: 9pt; width: 100px; font-family: Arial; height: 18px">
                                                    CATI/tel interview</td>
                                                <td style="font-size: 9pt; width: 22px; font-family: Arial; height: 18px">
                                                    a</td>
                                                <td style="font-size: 9pt; width: 100px; font-family: Arial; height: 18px">
                                                    Focus Group</td>
                                                <td style="font-size: 9pt; width: 22px; font-family: Arial; height: 18px">
                                                    w</td>
                                            </tr>
                                            <tr>
                                                <td style="font-size: 9pt; width: 100px; font-family: Arial; height: 18px">
                                                    CAWI</td>
                                                <td style="font-size: 9pt; width: 22px; font-family: Arial; height: 18px">
                                                    b</td>
                                                <td style="font-size: 9pt; width: 100px; font-family: Arial; height: 18px">
                                                    In Depth</td>
                                                <td style="font-size: 9pt; width: 22px; font-family: Arial; height: 18px">
                                                    x</td>
                                            </tr>
                                            <tr>
                                                <td style="font-size: 9pt; width: 100px; font-family: Arial; height: 18px">
                                                    CLT</td>
                                                <td style="font-size: 9pt; width: 22px; font-family: Arial; height: 18px">
                                                    c</td>
                                                <td style="font-size: 9pt; width: 100px; font-family: Arial; height: 18px">
                                                    Mini Group/Traids</td>
                                                <td style="font-size: 9pt; width: 22px; font-family: Arial; height: 18px">
                                                    y</td>
                                            </tr>
                                            <tr>
                                                <td style="font-size: 9pt; width: 100px; font-family: Arial; height: 18px">
                                                    Door to door</td>
                                                <td style="font-size: 9pt; width: 22px; font-family: Arial; height: 18px">
                                                    d</td>
                                                <td style="font-size: 9pt; width: 100px; font-family: Arial; height: 18px">
                                                    Others</td>
                                                <td style="font-size: 9pt; width: 22px; font-family: Arial; height: 18px">
                                                    z</td>
                                            </tr>
                                            <tr>
                                                <td style="font-size: 9pt; width: 100px; font-family: Arial; height: 18px">
                                                    Face to face</td>
                                                <td style="font-size: 9pt; width: 22px; font-family: Arial; height: 18px">
                                                    e</td>
                                                <td style="font-size: 9pt; width: 100px; font-family: Arial; height: 18px">
                                                </td>
                                                <td style="font-size: 9pt; width: 22px; font-family: Arial; height: 18px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="font-size: 9pt; width: 100px; font-family: Arial; height: 18px">
                                                    Mail</td>
                                                <td style="font-size: 9pt; width: 22px; font-family: Arial; height: 18px">
                                                    f</td>
                                                <td style="font-size: 9pt; width: 100px; font-family: Arial; height: 18px">
                                                </td>
                                                <td style="font-size: 9pt; width: 22px; font-family: Arial; height: 18px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="font-size: 9pt; width: 100px; font-family: Arial; height: 18px">
                                                    Mystery</td>
                                                <td style="font-size: 9pt; width: 22px; font-family: Arial; height: 18px">
                                                    g</td>
                                                <td style="font-size: 9pt; width: 100px; font-family: Arial; height: 18px">
                                                </td>
                                                <td style="font-size: 9pt; width: 22px; font-family: Arial; height: 18px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="font-size: 9pt; width: 100px; font-family: Arial; height: 18px">
                                                    Online Panel</td>
                                                <td style="font-size: 9pt; width: 22px; font-family: Arial; height: 18px">
                                                    h</td>
                                                <td style="font-size: 9pt; width: 100px; font-family: Arial; height: 18px">
                                                </td>
                                                <td style="font-size: 9pt; width: 22px; font-family: Arial; height: 18px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="font-size: 9pt; width: 100px; font-family: Arial; height: 18px">
                                                    Others</td>
                                                <td style="font-size: 9pt; width: 22px; font-family: Arial; height: 18px">
                                                    i</td>
                                                <td style="font-size: 9pt; width: 100px; font-family: Arial; height: 18px">
                                                </td>
                                                <td style="font-size: 9pt; width: 22px; font-family: Arial; height: 18px">
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                </div>
                
            </telerik:RadPageView>
            <telerik:RadPageView ID="RadPageView2" runat="server" Height="100%" Width="100%">
                <div style="width:100%; text-align:center;height:100%;border: solid 1px #69c; border-width: 1px 1px 1px 1px; border-collapse: collapse">
                
                    <table border="1"  class="query" cellpadding="1" cellspacing="1" style="width:350px;margin:0">
                                <tr>
                                    <td style="border-right: gray 1px solid; border-top: gray 1px solid; font-weight: bold;
                                        font-size: 10pt; border-left: gray 1px solid; width: 165px; border-bottom: gray 1px solid;
                                        font-family: Arial; height: 20px;">
                                        -</td>
                                    <td align="center" style="border-right: gray 1px solid; border-top: gray 1px solid;
                                        font-weight: bold; font-size: 10pt; border-left: gray 1px solid; width: 183px;
                                        border-bottom: gray 1px solid; font-family: Arial; background-color: darkgray;
                                        height: 20px;">
                                        Total(Quanti/Quali)</td>
                                </tr>
                                <tr>
                                    <td style="width: 165px; background-color: white; font-size: 9pt; font-family: Arial;
                                        border-top-width: 1px; border-left-width: 1px; border-left-color: gray; border-bottom-width: 1px;
                                        border-bottom-color: gray; border-top-color: gray; border-right-width: 1px; border-right-color: gray;">
                                        Cost:</td>
                                    <td style="font-weight: bold; font-size: 10pt; width: 183px; font-family: Arial;
                                        background-color: white; border-top-width: 1px; border-left-width: 1px; border-left-color: gray;
                                        border-bottom-width: 1px; border-bottom-color: gray; border-top-color: gray;
                                        border-right-width: 1px; border-right-color: gray;">
                                        <telerik:RadNumericTextBox ID="txtTotalCost" runat="server"
                                            ReadOnly="True" Width="98%" Font-Names="Arial" Font-Overline="False" Font-Size="9pt" >
                                            <NumberFormat AllowRounding="True" DecimalDigits="0" />
                                            <InvalidStyle HorizontalAlign="Right" />
                                            <EnabledStyle HorizontalAlign="Right" />
                                            <FocusedStyle HorizontalAlign="Right" />
                                            <DisabledStyle HorizontalAlign="Right" />
                                            <NegativeStyle HorizontalAlign="Right" />
                                            <HoveredStyle HorizontalAlign="Right" />
                                        </telerik:RadNumericTextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 165px; background-color: white; font-size: 9pt; font-family: Arial;
                                        border-top-width: 1px; border-left-width: 1px; border-left-color: gray; border-bottom-width: 1px;
                                        border-bottom-color: gray; border-top-color: gray; border-right-width: 1px; border-right-color: gray;">
                                        Direct Cost:</td>
                                    <td style="font-weight: bold; font-size: 10pt; width: 183px; font-family: Arial;
                                        background-color: white; border-top-width: 1px; border-left-width: 1px; border-left-color: gray;
                                        border-bottom-width: 1px; border-bottom-color: gray; border-top-color: gray;
                                        border-right-width: 1px; border-right-color: gray;">
                                        <telerik:RadNumericTextBox ID="txtDirectCost" runat="server"
                                            ReadOnly="True" Width="60%" Font-Names="Arial" Font-Overline="False" Font-Size="9pt" >
                                            <NumberFormat AllowRounding="True" DecimalDigits="0" />
                                            <InvalidStyle HorizontalAlign="Right" />
                                            <EnabledStyle HorizontalAlign="Right" />
                                            <FocusedStyle HorizontalAlign="Right" />
                                            <DisabledStyle HorizontalAlign="Right" />
                                            <NegativeStyle HorizontalAlign="Right" />
                                            <HoveredStyle HorizontalAlign="Right" />
                                        </telerik:RadNumericTextBox>&nbsp;
                                        <telerik:RadNumericTextBox ID="txtDirectCostPer" runat="server"
                                            ReadOnly="True" Width="31%" Font-Names="Arial" Font-Overline="False" Font-Size="9pt" MaxValue="100" MinValue="0" Type="Percent" >
                                            <NumberFormat AllowRounding="True" DecimalDigits="2" />
                                            <InvalidStyle HorizontalAlign="Right" />
                                            <EnabledStyle HorizontalAlign="Right" />
                                            <FocusedStyle HorizontalAlign="Right" />
                                            <DisabledStyle HorizontalAlign="Right" />
                                            <NegativeStyle HorizontalAlign="Right" />
                                            <HoveredStyle HorizontalAlign="Right" />
                                        </telerik:RadNumericTextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 165px; background-color: white; font-size: 9pt; font-family: Arial;
                                        border-top-width: 1px; border-left-width: 1px; border-left-color: gray; border-bottom-width: 1px;
                                        border-bottom-color: gray; border-top-color: gray; border-right-width: 1px; border-right-color: gray;">
                                        Time Cost:</td>
                                    <td style="font-weight: bold; font-size: 10pt; width: 183px; font-family: Arial;
                                        background-color: white; border-top-width: 1px; border-left-width: 1px; border-left-color: gray;
                                        border-bottom-width: 1px; border-bottom-color: gray; border-top-color: gray;
                                        border-right-width: 1px; border-right-color: gray;">
                                        <telerik:RadNumericTextBox ID="txtTimeCost" runat="server"
                                            ReadOnly="True" Width="60%" Font-Names="Arial" Font-Overline="False" Font-Size="9pt" >
                                            <NumberFormat AllowRounding="True" DecimalDigits="0" />
                                            <InvalidStyle HorizontalAlign="Right" />
                                            <EnabledStyle HorizontalAlign="Right" />
                                            <FocusedStyle HorizontalAlign="Right" />
                                            <DisabledStyle HorizontalAlign="Right" />
                                            <NegativeStyle HorizontalAlign="Right" />
                                            <HoveredStyle HorizontalAlign="Right" />
                                        </telerik:RadNumericTextBox>&nbsp;
                                        <telerik:RadNumericTextBox ID="txtTimeCostPer" runat="server"
                                            ReadOnly="True" Width="31%" Font-Names="Arial" Font-Overline="False" Font-Size="9pt" MaxValue="100" MinValue="0" Type="Percent" >
                                            <NumberFormat AllowRounding="True" DecimalDigits="2" />
                                            <InvalidStyle HorizontalAlign="Right" />
                                            <EnabledStyle HorizontalAlign="Right" />
                                            <FocusedStyle HorizontalAlign="Right" />
                                            <DisabledStyle HorizontalAlign="Right" />
                                            <NegativeStyle HorizontalAlign="Right" />
                                            <HoveredStyle HorizontalAlign="Right" />
                                        </telerik:RadNumericTextBox></td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="font-size: 9pt; width: 221px; font-family: Arial; background-color: oldlace;
                                        border-top-width: 1px; border-left-width: 1px; border-left-color: gray; border-bottom-width: 1px;
                                        border-bottom-color: gray; border-top-color: gray; border-right-width: 1px; border-right-color: gray;">
                                        -</td>
                                </tr>
                                <tr>
                                    <td style="width: 165px; background-color: white; font-size: 9pt; font-family: Arial;
                                        border-top-width: 1px; border-left-width: 1px; border-left-color: gray; border-bottom-width: 1px;
                                        border-bottom-color: gray; border-top-color: gray; border-right-width: 1px; border-right-color: gray;">
                                        Profit:</td>
                                    <td style="font-weight: bold; font-size: 10pt; width: 183px; font-family: Arial;
                                        background-color: white; border-top-width: 1px; border-left-width: 1px; border-left-color: gray;
                                        border-bottom-width: 1px; border-bottom-color: gray; border-top-color: gray;
                                        border-right-width: 1px; border-right-color: gray;">
                                        <telerik:RadNumericTextBox ID="txtProfit" runat="server" Skin="Outlook" Width="60%" AutoPostBack="True" Font-Names="Arial" Font-Overline="False" Font-Size="9pt" MaxValue="1000000" MinValue="-1000000" Type="Percent">
                                            <NumberFormat AllowRounding="True" DecimalDigits="2" />
                                            <EnabledStyle HorizontalAlign="Right" />
                                            <NegativeStyle HorizontalAlign="Right" />
                                        </telerik:RadNumericTextBox></td>
                                </tr>                                
                                
                                <tr>
                                    <td colspan="2" style="font-size: 9pt; width: 221px; font-family: Arial; background-color: oldlace; border-top-width: 1px; border-left-width: 1px; border-left-color: gray;
                                        border-bottom-width: 1px; border-bottom-color: gray; border-top-color: gray;
                                        border-right-width: 1px; border-right-color: gray;">
                                        -</td>
                                </tr>
                                <tr>
                                    <td style="width: 165px; background-color: white; font-size: 9pt; font-family: Arial;
                                        border-top-width: 1px; border-left-width: 1px; border-left-color: gray; border-bottom-width: 1px;
                                        border-bottom-color: gray; border-top-color: gray; border-right-width: 1px; border-right-color: gray;">
                                        Price to client:</td>
                                    <td style="font-weight: bold; font-size: 10pt; width: 183px; font-family: Arial;
                                        background-color: white; border-top-width: 1px; border-left-width: 1px; border-left-color: gray;
                                        border-bottom-width: 1px; border-bottom-color: gray; border-top-color: gray;
                                        border-right-width: 1px; border-right-color: gray;">
                                        <telerik:RadNumericTextBox ID="txtPricetoClient" runat="server" Skin="Outlook" Width="98%" Font-Names="Arial" Font-Overline="False" Font-Size="9pt" AutoPostBack="True">
                                            <NumberFormat AllowRounding="True" DecimalDigits="2" />
                                            <EnabledStyle HorizontalAlign="Right" />
                                            <NegativeStyle HorizontalAlign="Right" />
                                        </telerik:RadNumericTextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 165px; background-color: white; font-size: 9pt; font-family: Arial;
                                        border-top-width: 1px; border-left-width: 1px; border-left-color: gray; border-bottom-width: 1px;
                                        border-bottom-color: gray; border-top-color: gray; border-right-width: 1px; border-right-color: gray;">
                                        Taxes(5% BT):</td>
                                    <td style="font-weight: bold; font-size: 10pt; width: 183px; font-family: Arial;
                                        background-color: white; border-top-width: 1px; border-left-width: 1px; border-left-color: gray;
                                        border-bottom-width: 1px; border-bottom-color: gray; border-top-color: gray;
                                        border-right-width: 1px; border-right-color: gray;">
                                        <telerik:RadNumericTextBox ID="txtTax" runat="server"
                                            ReadOnly="True" Width="98%" Font-Names="Arial" Font-Overline="False" Font-Size="9pt" >
                                            <NumberFormat AllowRounding="True" DecimalDigits="2" />
                                            <EnabledStyle HorizontalAlign="Right" />
                                        </telerik:RadNumericTextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 165px; background-color: white; font-size: 9pt; font-family: Arial;
                                        border-top-width: 1px; border-left-width: 1px; border-left-color: gray; border-bottom-width: 1px;
                                        border-bottom-color: gray; border-top-color: gray; border-right-width: 1px; border-right-color: gray;">
                                        Revenue:</td>
                                    <td style="font-weight: bold; font-size: 10pt; width: 183px; font-family: Arial;
                                        background-color: white; border-top-width: 1px; border-left-width: 1px; border-left-color: gray;
                                        border-bottom-width: 1px; border-bottom-color: gray; border-top-color: gray;
                                        border-right-width: 1px; border-right-color: gray;">
                                        <telerik:RadNumericTextBox ID="txtRevenue" runat="server"
                                            ReadOnly="True" Width="98%" Font-Names="Arial" Font-Overline="False" Font-Size="9pt" >
                                            <NumberFormat AllowRounding="True" DecimalDigits="2" />
                                            <EnabledStyle HorizontalAlign="Right" />
                                        </telerik:RadNumericTextBox></td>
                                </tr>                              
                                <tr>
                                    <td colspan="2" style="border-top-width: 1px; border-left-width: 1px; font-size: 9pt;
                                        border-left-color: gray; border-bottom-width: 1px; border-bottom-color: gray;
                                        border-top-color: gray; font-family: Arial; background-color: white; border-right-width: 1px;
                                        border-right-color: gray">
                                        -</td>
                                </tr>
                                <tr>
                                    <td align="center" style="border-top-width: 1px; border-left-width: 1px; font-size: 9pt;
                                        border-left-color: gray; border-bottom-width: 1px; border-bottom-color: gray;
                                        width: 165px; border-top-color: gray; font-family: Arial; background-color: white;
                                        border-right-width: 1px; border-right-color: gray">
                                        <asp:LinkButton ID="LinkButton1" runat="server" Font-Names="Arial" Font-Size="9pt"
                                            Height="10px" Width="102px">Approve by PM/RM</asp:LinkButton></td>
                                    <td style="border-top-width: 1px; font-weight: bold; border-left-width: 1px; font-size: 10pt;
                                        border-left-color: gray; border-bottom-width: 1px; border-bottom-color: gray;
                                        width: 183px; border-top-color: gray; font-family: Arial; background-color: white;
                                        border-right-width: 1px; border-right-color: gray">
                                        <asp:TextBox ID="TextBox1" runat="server" BackColor="Gainsboro" BorderStyle="Groove"
                                            Font-Names="Arial" Font-Size="9pt" Width="154px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td align="center" style="border-top-width: 1px; border-left-width: 1px; font-size: 9pt;
                                        border-left-color: gray; border-bottom-width: 1px; border-bottom-color: gray;
                                        width: 165px; border-top-color: gray; font-family: Arial; background-color: white;
                                        border-right-width: 1px; border-right-color: gray">
                                        <asp:LinkButton ID="LinkButton2" runat="server" Font-Names="Arial" Font-Size="9pt"
                                            Width="106px">Approve by Director</asp:LinkButton></td>
                                    <td style="border-top-width: 1px; font-weight: bold; border-left-width: 1px; font-size: 10pt;
                                        border-left-color: gray; border-bottom-width: 1px; border-bottom-color: gray;
                                        width: 183px; border-top-color: gray; font-family: Arial; background-color: white;
                                        border-right-width: 1px; border-right-color: gray">
                                        <asp:TextBox ID="TextBox2" runat="server" BackColor="Gainsboro" BorderStyle="Groove"
                                            Font-Names="Arial" Font-Size="9pt" Width="154px"></asp:TextBox></td>
                                </tr>
                                <tr>                                    
                                    <td colspan="2" style="text-align:center">
                                    <asp:Button ID="btnConfirm" runat="server" Font-Names="Arial" Font-Size="9pt" Text="Confirm"
                                    Width="60px" />
                                <asp:Button ID="txtEmailToApprove" runat="server" Font-Names="Arial" Font-Size="9pt"
                                    Text="Email to Approve" Width="110px" />
                                    <asp:Button ID="btnReturn" runat="server"  Font-Names="Arial" Font-Size="9pt" Text="Return" />
                                    </td>
                                </tr>
                            </table>
                            
                </div>
            </telerik:RadPageView>
        </telerik:RadMultiPage>
    </div>
    </form>
</body>
</html>
