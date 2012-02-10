<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ShowError.aspx.vb" Inherits="ShowError" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="98%" align="center">
			<tr>
				<td align="center">
					<font color="#0000cc" size="5">
						<asp:Label id="lblMessage" runat="server">Error!</asp:Label>
					</font>
				</td>
			</tr>
			<tr>
				<td align="center">
					<a href="../Login.aspx">Login</a>
				</td>
			</tr>
            <tr>
				<td align="center">
					<font color="#0000cc" size="5">
						<asp:Label id="lblDetail" runat="server"></asp:Label>
					</font>
				</td>
			</tr>
		</table>
    </div>
    </form>
</body>
</html>
