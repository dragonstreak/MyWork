<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Top.aspx.vb" Inherits="Index_Top" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
<title>top</title>
<link href="../css/style.css" rel="stylesheet" type="text/css">
<style>
	body{background: url(../images/top_back.gif); color: white; padding: 0 10px 0 10px;}
</style>
</head>

<body class="left">
<table width="100%" height="40" border="0" cellpadding="0" cellspacing="0">
  <tr> 
    <td width="300" nowrap align="center">
        <span style="font: normal normal normal 20px/normal Arial; height: 24px; filter: dropshadow(offx=1,offy=1,positive=1,color=#999999);">Illumin ERP System</span></td>
    <td width="175"><img src="../images/top_back1.gif" width="175" height="40"></td>
    <td align="right" nowrap><div id ="CurrentDate">
        <asp:Label ID="lblCurrentDate" runat="server" Text=""></asp:Label></div>
    </td>
	<!--&nbsp;&nbsp;&nbsp;&nbsp;<a href="#" class="green"><img src="../images/tops_04.gif" align="absmiddle" border="0"> 页面导航</a>&nbsp;&nbsp;-->
	<td align="center" width="150" nowrap><a href="../index/abstract.htm" target="content" class="yellow"><img src="../images/home.gif" align="absmiddle" border="0"> Home</a>&nbsp;&nbsp;<a href="javascript:window.close();" target="_parent" class="white"><img src="../images/quit.gif" align="absmiddle" border="0"> Exit</a></td>
	
   
  </tr>
</table>
</body>
</html>

<script language="javascript"><!--
    var today = new Date();
    var week; var date;
    if (today.getDay() == 0) week = "星期日";
    if (today.getDay() == 1) week = "星期一";
    if (today.getDay() == 2) week = "星期二";
    if (today.getDay() == 3) week = "星期三";
    if (today.getDay() == 4) week = "星期四";
    if (today.getDay() == 5) week = "星期五";
    if (today.getDay() == 6) week = "星期六";
    date = (today.getYear()) + "年" + (today.getMonth() + 1) + "月" + today.getDate() + "日" + " ";
    //document.write(date + week);
//    document.getElementById("CurrentDate").innerHTML = date + week
// -->  
</script>
