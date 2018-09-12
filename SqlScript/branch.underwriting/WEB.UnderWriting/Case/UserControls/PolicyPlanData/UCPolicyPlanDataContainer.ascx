<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCPolicyPlanDataContainer.ascx.cs" Inherits="WEB.UnderWriting.Case.UserControls.PolicyPlanData.UCPolicyPlanDataContainer" %>
<%@ Register Src="~/Case/UserControls/PolicyPlanData/UCPocicyPlanInformation.ascx" TagPrefix="uc1" TagName="UCPocicyPlanInformation" %>
<%@ Register Src="~/Case/UserControls/PolicyPlanData/UCRiskClass.ascx" TagPrefix="uc1" TagName="UCRiskClass" %>
<%@ Register Src="~/Case/UserControls/PolicyPlanData/UCAmendments.ascx" TagPrefix="uc1" TagName="UCAmendments" %>
<%@ Register Src="~/Case/UserControls/PolicyPlanData/UCNewRisk.ascx" TagPrefix="uc1" TagName="UCNewRisk" %>
<%@ Register Src="~/Case/UserControls/PolicyPlanData/UCNewCredit.ascx" TagPrefix="uc1" TagName="UCNewCredit" %>
<%@ Register Src="~/Case/UserControls/PolicyPlanData/UCNewExclusion.ascx" TagPrefix="uc1" TagName="UCNewExclusion" %>
<%@ Register Src="~/Case/UserControls/PolicyPlanData/UCTerminateExclusion.ascx" TagPrefix="uc1" TagName="UCTerminateExclusion" %>
<%@ Register Src="~/Case/UserControls/PolicyPlanData/UCPopExclusionComment.ascx" TagPrefix="uc1" TagName="UCPopExclusionComment" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>



<div class="accordion_tabulado" id="PolicyPlanData" style="display: block;">
    <ul class="principal" id="AcordeonPolicyPlanData">
        <!--POLICY / PLAN INFORMATION-->
        <li><a href="#" id="current" class="trigger" onclick="setCurrentAccordeon(this,'#hfPolicyPlanDataAccordeon');" lnk="lnk">
            <div class="rect">
            </div>
            POLICY / PLAN INFORMATION<span></span> </a>
            <uc1:UCPocicyPlanInformation runat="server" ID="UCPocicyPlanInformation" />
            <!--secundario-->
        </li>
        <!--principal 1-->
        <!-- RISK CLASS-->
        <li><a href="#" class="trigger" onclick="setCurrentAccordeon(this,'#hfPolicyPlanDataAccordeon');" lnk="lnk">
            <div class="rect">
            </div>
            RISK CLASS <span></span></a>
            <ul class="secundario">
                <li class="risk_class">
                    <uc1:UCRiskClass runat="server" ID="UCRiskClass" />
                    <uc1:UCRiskClass runat="server" ID="UCRiskClassAditional" />
                </li>
            </ul>

            <!--secundario-->
            <div class="limpiador">
            </div>
        </li>
        <!--principal 2 // RISK CLASS-->
        <!-- AMENDMENTS -->
        <li><a href="#" class="trigger" onclick="setCurrentAccordeon(this,'#hfPolicyPlanDataAccordeon');" lnk="lnk">
            <div class="rect">
            </div>
            AMENDMENTS <span></span></a>
            <uc1:UCAmendments runat="server" ID="UCAmendments" />
        </li>
    </ul>
    <!--principal-->

    <asp:HiddenField runat="server" ID="hfAddNewRisk" Value="false" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="hfAddNewCredit" Value="false" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="hfAddNewExclusion" Value="false" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="hfExclusionComment" Value="false" ClientIDMode="Static" />
</div>

<asp:UpdatePanel ID="upPolicyContainer" runat="server">
    <ContentTemplate>
        <div id="dvPopAddNewRisk" style="display: none; padding: 0">
            <uc1:UCNewRisk runat="server" ID="UCNewRisk" />
        </div>
        <div id="dvNewCredit" style="display: none; padding: 0">
            <uc1:UCNewCredit runat="server" ID="UCNewCredit" />
        </div>

        <div id="dvExclusionComment" style="display: none; padding: 0">
            <uc1:UCPopExclusionComment runat="server" ID="UCPopExclusionComment" />
        </div>
        <div id="dvNewExclusion" style="display: none; padding: 0">
            <uc1:UCNewExclusion runat="server" ID="UCNewExclusion" />
        </div>
    </ContentTemplate>
</asp:UpdatePanel>

<AJAX:ModalPopupExtender ID="ModalPopupTerminateExclusion" runat="server" ClientIDMode="Static" Enabled="true" TargetControlID="hdnShowTerminateExclusion" CacheDynamicResults="true"
    PopupControlID="pnTerminateExlusion" DropShadow="false" BackgroundCssClass="ui-widget-overlay">
</AJAX:ModalPopupExtender>
<asp:Panel ID="pnTerminateExlusion" ClientIDMode="Static" runat="server" CssClass="modalPopup" Style="width: 1002px; height: 515px; display: none; cursor: move; margin: 0px; border-right-width: 1px; border-bottom-width: 1px; border-left-width: 1px; border-style: none solid solid; border-right-color: rgb(119, 119, 119); border-bottom-color: rgb(119, 119, 119); border-left-color: rgb(119, 119, 119); position: absolute; z-index: 100001; left: 361.5px; background-color: rgb(207, 207, 196);">
    <uc1:UCTerminateExclusion runat="server" ID="UCTerminateExclusion" />
</asp:Panel>
<asp:HiddenField ID="hdnShowTerminateExclusion" ClientIDMode="Static" runat="server" Value="false" />
