<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyProfile.ascx.cs" Inherits="WEB.ConfirmationCall.UserControls.Common.MyProfile.MyProfile" %>
<%@ Register Src="AgentProfile.ascx" TagName="AgentProfile" TagPrefix="uc1" %>
<%@ Register Src="Calendar.ascx" TagName="Calendar" TagPrefix="uc2" %>
<div id="menu-2">
    <div class="st-menu st-effect-2" id="scroll_1">
        <!-- perfil del agente part-->
        <div id="profile_menu_logo" class="logo_atl" runat="server">
        </div>
        <!--logo-->
        <div class="accordion">
            <ul id="acordeon_agent_profile">
                <li class="perfil_agent">
                    <uc1:AgentProfile ID="AgentProfile1" runat="server" />
                </li>
                <!--perfil_agente-->
                <li class="calendar_agent">
                    <uc2:Calendar ID="Calendar1" runat="server" />
                </li>
            </ul>
        </div>
        <!--accordion-->
    </div>
    <!--st-menu st-effect-2-->
</div>
<!-- id menu-2 -->

