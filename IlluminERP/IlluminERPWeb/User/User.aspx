<%@ Page Language="VB" AutoEventWireup="false" CodeFile="User.aspx.vb" Inherits="User_User" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <base target="_self" />
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function CloseWindow() {
            this.close();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <table class="bg">
      
        <tr>
            <td>
                Code:
            </td>
            <td>
                <telerik:RadTextBox ID="tbCode" runat="server">
                </telerik:RadTextBox>
            </td>
            <td>
                E_Name:
            </td>
            <td>
                <telerik:RadTextBox ID="tbEName" runat="server">
                </telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td>
                C_Name:
            </td>
            <td>
                <telerik:RadTextBox ID="tbCName" runat="server">
                </telerik:RadTextBox>
            </td>
            <td>
                EMail:
            </td>
            <td>
                <telerik:RadTextBox ID="tbEmail" runat="server">
                </telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td>
                Position:
            </td>
            <td>
                <%--<telerik:RadComboBox style="border: 6px #69c" ID="cbCity" MaxHeight="100" runat="server" Height="17px" Width="125px">
                </telerik:RadComboBox>--%>
                <asp:DropDownList   ID="cbPosition" runat="server" Width="125px">
                </asp:DropDownList>
            </td>
            <td>
                Line Manager:</td>
            <td>
                <%--<telerik:RadComboBox  ID="cbDepartment" MaxHeight="100" runat="server" Height="17px" Width="125px">
                </telerik:RadComboBox>--%>
                <asp:DropDownList  ID="cbManager" runat="server"  Width="125px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Extension:</td>
            <td>
                <%--<telerik:RadComboBox style="border: 6px #69c" Height="50" MaxHeight="100" ID="cbPosition" runat="server" Width="125px">
                </telerik:RadComboBox>--%>
                <telerik:RadTextBox ID="tbExtension" runat="server">
                </telerik:RadTextBox>
            </td>
            <td>
                &nbsp;OnDuty:</td>
            <td>
                <%--<telerik:RadComboBox style="border: 6px #69c" MaxHeight="100" ID="cbManager" runat="server" Height="17px" Width="125px">
                </telerik:RadComboBox>--%>
                <asp:DropDownList runat="server" ID="cbDuty" Width="127px">
                <asp:ListItem Text="Left the Job" Value="0">
                </asp:ListItem>
                <asp:ListItem Text="On the Job" Value="1" Selected="True">
                </asp:ListItem>
                </asp:DropDownList>
              
            </td>
        </tr>
        <tr>
            <td>
                &nbsp; Password:
            </td>
            <td>
                <telerik:RadTextBox ID="tbPassword" runat="server">
                </telerik:RadTextBox>
            </td>
            <td>
                PIN Code:
            </td>
            <td>                
                <telerik:RadTextBox ID="tbPinCode" runat="server">
                </telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td>
                Comm. Date:
            </td>
            <td>
                <telerik:RadDatePicker ID="diCommDate" runat="server" Width="127px">
                </telerik:RadDatePicker>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Remark:</td>
            <td colspan="3" align="left">
                <%--<telerik:RadComboBox style="border: 6px #69c"  MaxHeight="100" ID="cbDuty" runat="server" Height="17px" Width="125px">
                    <Items>
                        <telerik:RadComboBoxItem Text="Left the Job" Value="0" />
                        <telerik:RadComboBoxItem Text="On the Job" Value="1" Selected="True" />
                    </Items>
                </telerik:RadComboBox>--%>
                <telerik:RadTextBox ID="tbRemark" Width="100%" runat="server" TextMode="MultiLine">
                </telerik:RadTextBox>
              
            </td>
        </tr>
        <tr>
            <td colspan="4" align="center">
                <asp:Button ID="btnSave" runat="server" Text="Save" class="btnsave" />
                <input type="button" name="btnCancel" value="Cancel" class="btnclose" onclick="javascript:CloseWindow();" /><asp:ScriptManager 
                    ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
        </td>
        </tr>
    </table>
    </form>
</body>
</html>
