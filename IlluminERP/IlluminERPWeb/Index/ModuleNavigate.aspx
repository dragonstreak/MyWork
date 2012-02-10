<%@ Page Language="VB" MasterPageFile="~/Master/IlluminMasterPage.master" AutoEventWireup="false" CodeFile="ModuleNavigate.aspx.vb" Inherits="Index_ModuleNavigate" %>

<asp:Content ID="ChildPageHead" ContentPlaceHolderID="head" runat="server">
    <title></title>
     <link href="../Css/style.css" rel="stylesheet" type="text/css" />
     <telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
     
     <style type="text/css">
        #navigatePanel {display:inline;  list-style-type:none}
        #navigatePanel li {margin:20px 10px}
        #navigatePanel li div{float:left; background:white; width:120px;height:100px; margin: 10px; padding:15px 15px 45px 25px; }
     </style>
</asp:Content>

<asp:Content ID="ChildPageBody" ContentPlaceHolderID="PageContentPlaceHolder" runat="server">
     <form id="form1" runat="server">
     <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        <Scripts>
            <%--Needed for JavaScript IntelliSense in VS2010--%>
            <%--For VS2008 replace RadScriptManager with ScriptManager--%>
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
        </Scripts>
    </telerik:RadScriptManager>
    <div>
        <ul id="navigatePanel">
             <li>
                <div >
                    <span style=" position:relative; top:120px; left:5px; z-index:1000;font-size:12px;  font-weight :bold ">
                        Proposal List
                    </span>
                    <a  href="../PMS/ProposalQuery.aspx?type=pm"> 
                    <img src="../Images/png/product.png" alt="ProposalList" width="96" height="96" />
                    </a>                    
                </div>
            </li>
            

            <li>
                <div >
                    <span style=" position:relative; top:120px; left:5px; z-index:1000;font-size:12px;  font-weight :bold ">
                        Proposal Quotation
                    </span>
                    <a  href="../PMS/ProposalQuery.aspx?type=quot"> 
                    <img src="../Images/png/sale.png" alt="Quotation" width="96" height="96" />
                    </a>                    
                </div>
            </li>
            
            <li>
                <div id="timingNav"  >
                    <span style=" position:relative; top:120px; left:5px; z-index:1000; font-size:12px;  font-weight :bold">
                        Proposal Timing
                    </span>
                    <a id="timingNav_Link" href="../PMS/ProposalQuery.aspx?type=timing"> 
                    <img src="../Images/png/project.png" alt="Timing" width="96" height="96" />
                    </a>                    
                </div>
            </li>
            
              <li>
                <div >
                    <span style=" position:relative; top:120px; left:5px; z-index:1000;font-size:12px;  font-weight :bold ">
                        Pro/Prj Status
                    </span>
                    <a  href="#"> 
                    <img src="../Images/png/Status.png" alt="Status" width="96" height="96" />
                    </a>                    
                </div>
            </li>


             <li>
                <div >
                    <span style=" position:relative; top:120px; left:25px; z-index:1000;font-size:12px;  font-weight :bold ">
                        My Task
                    </span>
                    <a  href="#"> 
                    <img src="../Images/png/task.png" alt="Task" width="96" height="96" />
                    </a>                    
                </div>
            </li>
            
             <li>
                <div >
                    <span style=" position:relative; top:120px; left:5px; z-index:1000;font-size:12px;  font-weight :bold ">
                        My Schedule
                    </span>
                    <a  href="../Index/HomePage.aspx"> 
                    <img src="../Images/png/schedule.png" alt="Schedule" width="96" height="96" />
                    </a>                    
                </div>
            </li>
            
             <li>
                <div >
                    <span style=" position:relative; top:120px; left:5px; z-index:1000;font-size:12px;  font-weight :bold ">
                        My Message
                    </span>
                    <a  href="../Message/UserMessageList.aspx"> 
                    <img src="../Images/png/message.png" alt="Message" width="96" height="96" />
                    </a>                    
                </div>
            </li>
            
             <li>
                <div >
                    <span style=" position:relative; top:120px; left:5px; z-index:1000;font-size:12px;  font-weight :bold ">
                        Pro/Prj Query
                    </span>
                    <a  href="#"> 
                    <img src="../Images/png/Proquery.png" alt="ProQuery" width="96" height="96" />
                    </a>                    
                </div>
            </li>
            
           
            
             
        </ul>
    </div>

    <div id="toolTipContain" style="display:none; z-index:10000">
        
    </div>
    </form>
</asp:Content>
