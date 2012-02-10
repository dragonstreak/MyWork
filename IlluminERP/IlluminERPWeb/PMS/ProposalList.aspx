<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ProposalList.aspx.vb" Inherits="PMS_ProposalList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="../css/style.css" rel="stylesheet" type="text/css"/>
      <link href="../css/style_1.css" rel="stylesheet" type="text/css"/>
     <link href="../css/screen.css" rel="stylesheet" type="text/css"/>
    <script src="../js/validation.js" type="text/javascript"></script>
    <script src="../js/operation.js" type="text/javascript"></script>
   
    <script language="javascript" type="text/javascript">
// <![CDATA[

        function addnewproposal_onclick() {

        }

// ]]>
    </script>
</head>
<body id= body_form>
    <form id="form1" runat="server">
    <div>
    	<div class="">
        	
         	 <h1>
                <a id="shortcut_add_remove" title="Add / Remove Shortcut..." href="javascript: void(0)" class="shortcut-add"></a>
                
                Proposal List
                
                 <a class="help" href="#" 
                 title="About proposal list"><small>Help</small></a>
             </h1>
         	
        </div>
        
    <table   border="0" class="query" width="100%" id="table1" cellspacing:"0" cellpadding="0">
		<caption class="advover" onclick="adv(table1,main)">Search<telerik:RadScriptManager 
                ID="RadScriptManager1" Runat="server">
            </telerik:RadScriptManager>
            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
            </telerik:RadAjaxManager>
        </caption>
		<tbody id="main">
		<tr>
        
        <td class="view_form_options" width="100%">
                <table width="307">
                    <tbody>
                        <tr>
                        	
                         <td width="299" class="label search_filters search_fields" kind="char" >
                              <table class="search_table">
                                    <tbody>
                                        <tr>
                                            <td valign="middle" nowrap="nowrap"  >
                                                <label for="name">Job Number</label>:
                                                <asp:Button ID="Button1" runat="server" Text="Button" />
                                            </td>
                                             
                                             <td  valign="middle" width="" colspan="1" >
                                               <asp:TextBox ID="txtJobNumber" runat="server" CssClass="text"></asp:TextBox>
                                             </td>
                                            
                                             <td valign="middle" width="" colspan="1" nowrap="nowrap" >
                                               <label for="name">Job Name</label>:
                                               
                                            </td>
                                             <td valign="middle" width="" colspan="1">
                                            
                                                 <telerik:RadTextBox ID="RadTextBox1" Runat="server">
                                                 </telerik:RadTextBox>
                                            </td>
                                            
                                         
                                      </tr>
                                    
                                    
                                     </tbody>
                                </table>
        				 </td>
                       
                        </tr>
                	</tbody>
               </table>
          </td>
    	</tr>
		
        <tr >
          	<td class="view_form_options" width="100%">
              <table width="100%"> 
                    <tbody>
                        <tr>
                            <td  align="left">
                                 <button title="search records." onclick="search_filter(); return false;">
                                 Search</button>
                            </td>
                            <td  align="left">
                                      <button title="Add New Proposal" id="addnewproposal" onclick="return addnewproposal_onclick()">Add proposal</button>
                              
                            </td>
                         
                        </tr>
                	</tbody>
               </table>
            </td>
		
			
		</tr>
		</tbody>
	</table>

  
    </div>
    </form>
</body>
</html>

                           