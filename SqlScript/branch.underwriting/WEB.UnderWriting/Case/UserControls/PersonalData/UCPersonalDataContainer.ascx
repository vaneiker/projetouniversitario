<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCPersonalDataContainer.ascx.cs" Inherits="WEB.UnderWriting.Case.UserControls.PersonalData.PersonalDataContainer" %>
<%@ Register Src="~/Case/UserControls/PersonalData/UCPersonalData.ascx" TagPrefix="uc1" TagName="UCPersonalData" %>
<%@ Register Src="~/Case/UserControls/PersonalData/UCAddresses.ascx" TagPrefix="uc2" TagName="UCAddresses" %>
<%@ Register Src="~/Case/UserControls/PersonalData/UCEmailPhone.ascx" TagPrefix="uc3" TagName="UCEmailPhone" %>
<%@ Register Src="~/Case/UserControls/PersonalData/UCBackgroundCheck.ascx" TagPrefix="uc4" TagName="UCBackgroundCheck" %>
<%@ Register Src="~/Case/UserControls/PersonalData/UCClaims.ascx" TagPrefix="uc5" TagName="UCClaims" %>
<%@ Register Src="~/Case/UserControls/PersonalData/UCWork.ascx" TagPrefix="uc6" TagName="UCWork" %>
<%@ Register Src="~/Case/UserControls/PersonalData/UCCompliance.ascx" TagPrefix="uc7" TagName="UCCompliance" %>
<%@ Register Src="~/Case/UserControls/PersonalData/UCTransunion.ascx" TagPrefix="uc8" TagName="UCTransunion" %>


<asp:UpdatePanel ID="upPersonalData" runat="server">
    <ContentTemplate>
        <div class="accordion_tabulado" id="PersonalData" style="display: block;">
            <ul class="principal" id="AcordeonPersonalData">
                <!--principal-->
                <li>
                    <a href="#" id="AccPersonalData" accordeonvisible="current" class="trigger" onclick="setCurrentAccordeon(this,'#hfPolicyPlanDataAccordeon');" lnk="lnk">
                        <div class="rect"></div>
                        PERSONAL DATA 
                    <span></span>
                    </a>
                    <uc1:UCPersonalData ID="UCPersonalData1" runat="server" />
                </li>
                <!--principal 1-->

                <!--principal 2 // ADDRESSES-->
                <li>
                    <a id="AccAddresses" href="#" class="trigger" onclick="setCurrentAccordeon(this,'#hfPolicyPlanDataAccordeon');" lnk="lnk">
                        <div class="rect"></div>
                        ADDRESSES <span></span>
                    </a>
                    <uc2:UCAddresses ID="UCAddresses1" runat="server" />
                </li>
                <!--principal 2 // ADDRESSES-->
                
                <!--WORK-->
                <li>
                    <a id="accWork" href="#" class="trigger" onclick="setCurrentAccordeon(this,'#hfPolicyPlanDataAccordeon');" lnk="lnk">
                        <div class="rect"></div>
                        WORK DATA<span></span>
                    </a>
                 <uc6:UCWork runat="server" id="UCWork1" />
                </li>
                <!--WORK-->

                  
                <!-- EMAIL & PHONE NUMBERS -->
                <li>
                    <a id="AccEmailPhones" href="#" class="trigger" onclick="setCurrentAccordeon(this,'#hfPolicyPlanDataAccordeon');" lnk="lnk">
                        <div class="rect"></div>
                        EMAIL &amp; PHONE NUMBERS <span></span>
                    </a>
                    <uc3:UCEmailPhone ID="UCEmailPhone1" runat="server" />
                </li>
                <!-- // EMAIL & PHONE NUMBERS -->

                <!-- COMPLIANCE -->
                <li>
                    <a id="AccCompliance" href="#" class="trigger" onclick="setCurrentAccordeon(this,'#hfPolicyPlanDataAccordeon');" lnk="lnk">
                        <div class="rect"></div>
                        COMPLIANCE <span></span>
                    </a>
                    <uc7:UCCompliance ID="UCCompliance1" runat="server" />
                </li>
                <!-- // COMPLIANCE -->

                <!-- COMPLIANCE -->
                <li>
                    <a id="AccCreditScore" href="#" class="trigger" onclick="setCurrentAccordeon(this,'#hfPolicyPlanDataAccordeon');" lnk="lnk">
                        <div class="rect"></div>
                        CREDIT SCORE <span></span>
                    </a>
                    <uc8:UCTransunion runat="server" id="UCTransunion" />
                </li>
                <!-- // COMPLIANCE -->

                <!-- BACKGROUND CHECK -->
                <li>
                    <a id="AccBGCheck" href="#" class="trigger" onclick="setCurrentAccordeon(this,'#hfPolicyPlanDataAccordeon');" lnk="lnk">
                        <div class="rect"></div>
                        BACKGROUND CHECK <span></span>
                    </a> 
                    <uc4:UCBackgroundCheck ID="UCBackgroundCheck1" runat="server" /> 
                    
                </li>
                <!-- // BACKGROUND CHECK -->

                <!-- CLAIMS-->
                <li>
                    <a id="AccClaims" href="#" class="trigger" onclick="setCurrentAccordeon(this,'#hfPolicyPlanDataAccordeon');" lnk="lnk">
                        <div class="rect"></div>
                        CLAIMS <span></span>
                    </a>
                    <uc5:UCClaims ID="UCClaims1" runat="server" />
                </li>
                <!-- // CLAIMS-->
            </ul>
            <!--principal-->
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
