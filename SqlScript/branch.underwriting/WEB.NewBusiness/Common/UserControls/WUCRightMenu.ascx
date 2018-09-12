<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUCRightMenu.ascx.cs" Inherits="WEB.NewBusiness.Common.UserControls.WUCRightMenu" %>

<div id="menu-3">
    <div class="st-menu st-effect-3" id="scroll_2">
        <div class="clearfix">
            <div class="herramientas" runat="server" id="Tools">TOOLS</div>
            <div class="toolbar">
                <ul>
                    <li>
                        <a href="#" class="home" onclick="Notify(this)" runat="server" id="Home">Home</a>
                    </li>
                    <li>
                        <a href="#" class="outlook" onclick="Notify(this)" runat="server" id="Outlook">Outlook</a>
                    </li>
                    <li>
                        <a href="#" class="crm" onclick="Notify(this)">CRM</a>
                    </li>
                    <li>
                        <a href="#" class="calendar" onclick="Notify(this)">Calendar</a>
                    </li>
                    <li>
                        <a href="#" class=" ticketcenter" onclick="Notify(this)">Ticket Center</a>
                    </li>
                    <li>
                        <a href="#" class="webex" onclick="Notify(this)">WebEx</a>
                    </li>
                    <li>
                        <a href="#" class="chat" onclick="Notify(this)">Chat</a>
                    </li>
                    <li>
                        <a href="#" class="phone_book" onclick="Notify(this)">Phone Book</a>
                    </li>
                    <li>
                        <a href="#" class="cisco" onclick="Notify(this)">Cisco</a>
                    </li>                  
                    
                </ul>
            </div>
            <!--toolbar-->
        </div>
        <!--clearfix-->

    </div>
    <!--st-menu st-effect-3-->
</div>
<!--menu-3-->
