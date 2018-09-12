<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCRequimentInformation.ascx.cs" Inherits="WEB.UnderWriting.Case.UserControls.Requirements.UCRequimentInformation" %>
<%@ Register Src="~/Case/UserControls/Requirements/UCAddNewRequirement.ascx" TagPrefix="uc1" TagName="UCAddNewRequirement" %>
<%@ Register Src="~/Case/UserControls/Requirements/UCRequirementTable.ascx" TagPrefix="uc1" TagName="UCRequirementTable" %>
<%@ Register Src="~/Case/UserControls/Requirements/UCRequirementComunication.ascx" TagPrefix="uc1" TagName="UCRequirementComunication" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<ul class="secundario">
    <li class="requirement">

        <asp:UpdatePanel ID="upRequirementsInfo" runat="server">
            <ContentTemplate>

                <div class=" wd100 fl mB lh27">
                    <label class=" label mB0">GENERAL DOCUMENTS REQUIREMENTS</label>
                    <div class="boton_wrapper gradient_AM_btn bdrAM fr">
                        <span class="add"></span>
                        <asp:LinkButton ID="lnkAddRequirement" runat="server" Text="Add New Requirement" CssClass="boton" OnClick="lnkAddRequirement_Click" ClientIDMode="Static"></asp:LinkButton>
                    </div>
                </div>
                <!--// 1era tabla -->
                <div class="tbl-req wd100 mB20">
                    <uc1:UCRequirementTable runat="server" ID="UCRequirementTableGeneral" />
                    <!--pagination-->
                </div>
                <!--// 1era tabla -->
                <!--// 2da tabla -->
                <label class=" label">MEDICAL REQUIREMENTS</label>
                <div class="tbl-req wd100 mB20">
                    <uc1:UCRequirementTable runat="server" ID="UCRequirementTableMedical" />
                </div>
                <!--pagination-->
                <!--// 2da tabla -->
                <!--// 3era tabla -->
                <label class=" label">FINANCIAL REQUIREMENTS</label>
                <div class="tbl-req wd100 mB20">
                    <uc1:UCRequirementTable runat="server" ID="UCRequirementTableFinancial" />
                    <!--pagination-->
                </div>
                <!--// 3era tabla -->
                <!--// 4ta tabla -->
                <label class=" label">SPORT/TRAVEL REQUIREMENTS</label>
                <div class="tbl-req wd100 mB20">
                    <uc1:UCRequirementTable runat="server" ID="UCRequirementTableActivitySports" />
                    <!--pagination-->
                </div>
                <!--// 5ta tabla -->

                <!--// 4ta tabla -->
                <label class=" label">OCCUPATION REQUIREMENTS</label>
                <div class="tbl-req wd100 mB20">
                    <uc1:UCRequirementTable runat="server" ID="UCRequirementTableOcupations" />
                    <!--pagination-->
                </div>
                <!--// 5ta tabla -->
                <!--// Fin de las tablas \\-->

                <div id="dvAddNewRequirement" style="display: none; padding: 0">
                    <uc1:UCAddNewRequirement runat="server" ID="UCAddNewRequirement" />
                </div>

                <AJAX:ModalPopupExtender ID="mpRequirementComunication" runat="server"  Enabled="true" TargetControlID="hfRequirementComunication" CacheDynamicResults="true"
                    PopupControlID="pnRequirementComunication" DropShadow="false" BackgroundCssClass="ui-widget-overlay"    BehaviorID="mpRequirementComunication">
                </AJAX:ModalPopupExtender>
                <asp:Panel ID="pnRequirementComunication" ClientIDMode="Static" runat="server" CssClass="modalPopup DraggablePop" Style="width: 1542px; height: 780px; display: none; margin: 0px; border-right-width: 1px; border-bottom-width: 1px; border-left-width: 1px; border-style: none solid solid; border-right-color: rgb(119, 119, 119); border-bottom-color: rgb(119, 119, 119); border-left-color: rgb(119, 119, 119); position: absolute; z-index: 100001; left: 361.5px; background-color: rgb(207, 207, 196);">
                       <uc1:UCRequirementComunication runat="server" ID="UCRequirementComunication" />
                    <iframe id="ifrReqComm" src="about:blank" style="position: absolute; border: none; top: 0; left: 0; z-index: -1; height: 100%; width: 100%;" ></iframe>

                </asp:Panel>
                <asp:HiddenField runat="server" ID="hfRequirementComunication" ClientIDMode="Static" Value="false" />

                <asp:HiddenField runat="server" ID="hfRequirementInsertForm" ClientIDMode="Static" Value="false" />
                <asp:HiddenField runat="server" ID="hfRequirementKey" ClientIDMode="Static" Value="" />
                <asp:HiddenField ID="hdnRequirementUploadedPDFPath" runat="server" ClientIDMode="Static" Value="" />
              

            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="lnkAddRequirement" />
            </Triggers>
        </asp:UpdatePanel>

    </li>
</ul>
