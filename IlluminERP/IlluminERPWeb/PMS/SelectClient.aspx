<%@ Page Language="VB" AutoEventWireup="false" CodeFile="SelectClient.aspx.vb" Inherits="PMS_SelectClient" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Client Query</title>
      <link href="../css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <table class ="query" width ="600px">
            <tbody>
                 <tr >
                    <td class="title"colspan ="2">
                        Client Query
                        <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
                        </telerik:RadScriptManager>
                    </td>
                </tr>
           
               <tr  >
                  <td width="20%">
                     Client Name:
                  </td>
                 
                  <td>
                      <telerik:RadTextBox ID="RadTextBox1" Runat="server" Skin="Windows7" Width="50%">
                      </telerik:RadTextBox>
                      <asp:Button ID="btnQuery" runat="server" Text="Query " class="btnqry" 
                            width="82px" />
                  </td>

              
               </tr>

          </tbody>
           </table>
    </div>
    </form>
</body>
</html>
