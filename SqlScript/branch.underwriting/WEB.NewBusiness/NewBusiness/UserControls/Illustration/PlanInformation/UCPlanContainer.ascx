<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCPlanContainer.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.Illustration.PlanInformation.UCPlanContainer" ClientIDMode="Static" %>
<%@ Register Src="~/NewBusiness/UserControls/Illustration/PlanInformation/UCAxys.ascx" TagPrefix="uc1" TagName="UCAxys" %>
<%@ Register Src="~/NewBusiness/UserControls/Illustration/PlanInformation/UCCompassIndex.ascx" TagPrefix="uc1" TagName="UCCompassIndex" %>
<%@ Register Src="~/NewBusiness/UserControls/Illustration/PlanInformation/UCLighthouse.ascx" TagPrefix="uc1" TagName="UCLighthouse" %>
<%@ Register Src="~/NewBusiness/UserControls/Illustration/PlanInformation/UCEduplan.ascx" TagPrefix="uc1" TagName="UCEduplan" %>
<%@ Register Src="~/NewBusiness/UserControls/Illustration/PlanInformation/UCHorizon.ascx" TagPrefix="uc1" TagName="UCHorizon" %>
<%@ Register Src="~/NewBusiness/UserControls/Illustration/PlanInformation/UCLegacy.ascx" TagPrefix="uc1" TagName="UCLegacy" %>
<%@ Register Src="~/NewBusiness/UserControls/Illustration/PlanInformation/UCSentinel.ascx" TagPrefix="uc1" TagName="UCSentinel" %>
<%@ Register Src="~/NewBusiness/UserControls/Illustration/PlanInformation/UCScholar.ascx" TagPrefix="uc1" TagName="UCScholar" %>
<%@ Register Src="~/NewBusiness/UserControls/Illustration/Beneficiaries/UCBeneficiariesContainer.ascx" TagPrefix="uc1" TagName="UCBeneficiariesContainer" %>
<%@ Register Src="~/NewBusiness/UserControls/Illustration/Requirements/UCRequirementContainer.ascx" TagPrefix="uc1" TagName="UCRequirementContainer" %>
<%@ Register Src="~/NewBusiness/UserControls/Illustration/Riders/UCRiderContainer.ascx" TagPrefix="uc1" TagName="UCRiderContainer" %>
<%@ Register Src="~/NewBusiness/UserControls/Illustration/PlanInformation/UCAxysFooter.ascx" TagPrefix="uc1" TagName="UCAxysFooter" %>
<%@ Register Src="~/NewBusiness/UserControls/Illustration/PlanInformation/UCCompassIndexFooter.ascx" TagPrefix="uc1" TagName="UCCompassIndexFooter" %>
<%@ Register Src="~/NewBusiness/UserControls/Illustration/PlanInformation/UCLighthouseFooter.ascx" TagPrefix="uc1" TagName="UCLighthouseFooter" %>
<%@ Register Src="~/NewBusiness/UserControls/Illustration/PlanInformation/UCEduplanFooter.ascx" TagPrefix="uc1" TagName="UCEduplanFooter" %>
<%@ Register Src="~/NewBusiness/UserControls/Illustration/PlanInformation/UCHorizonFooter.ascx" TagPrefix="uc1" TagName="UCHorizonFooter" %>
<%@ Register Src="~/NewBusiness/UserControls/Illustration/PlanInformation/UCLegacyFooter.ascx" TagPrefix="uc1" TagName="UCLegacyFooter" %>
<%@ Register Src="~/NewBusiness/UserControls/Illustration/PlanInformation/UCSentinelFooter.ascx" TagPrefix="uc1" TagName="UCSentinelFooter" %>
<%@ Register Src="~/NewBusiness/UserControls/Illustration/PlanInformation/UCScholarFooter.ascx" TagPrefix="uc1" TagName="UCScholarFooter" %>
<%@ Register Src="~/NewBusiness/UserControls/Illustration/PlanInformation/UCPlanSummary.ascx" TagPrefix="uc1" TagName="UCPlanSummary" %>
<%@ Register Src="~/NewBusiness/UserControls/Illustration/PlanInformation/UCTermInsuranceFooter.ascx" TagPrefix="uc1" TagName="UCTermInsuranceFooter" %>
<%@ Register Src="~/NewBusiness/UserControls/Illustration/PlanInformation/UCTermInsurance.ascx" TagPrefix="uc1" TagName="UCTermInsurance" %>
<%@ Register Src="~/NewBusiness/UserControls/Illustration/PlanInformation/UCFuneralFooter.ascx" TagPrefix="uc1" TagName="UCFuneralFooter" %>
<%@ Register Src="~/NewBusiness/UserControls/Illustration/PlanInformation/UCFuneral.ascx" TagPrefix="uc1" TagName="UCFuneral" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<div class="col-2-3">
    <div class="accordion_tabulado">
        <ul class="principal" id="acc2">
            <li>
                <a href="#item1" lnk='lnk' id="current" onclick="setCurrentAccordeon(this, '#hdnLnkAccordeon')"><%=RESOURCE.UnderWriting.NewBussiness.Resources.PlanInformationLabel.ToUpper() %><span><!--icono--></span></a>
                <ul>
                    <li>
                        <div id="frmPlanIllustrationInformation">
                            <asp:MultiView ID="mvPlanInformation" runat="server" ActiveViewIndex="0">
                                <asp:View ID="vEmpty" runat="server">
                                </asp:View>
                                <asp:View ID="vAxys" runat="server">
                                    <uc1:UCAxys runat="server" ID="UCAxys" />
                                </asp:View>
                                <asp:View ID="vCompassIndex" runat="server">
                                    <uc1:UCCompassIndex runat="server" ID="UCCompassIndex" />
                                </asp:View>
                                <asp:View ID="vEduplan" runat="server">
                                    <uc1:UCEduplan runat="server" ID="UCEduplan" />
                                </asp:View>
                                <asp:View ID="vHorizon" runat="server">
                                    <uc1:UCHorizon runat="server" ID="UCHorizon" />
                                </asp:View>
                                <asp:View ID="vLegacy" runat="server">
                                    <uc1:UCLegacy runat="server" ID="UCLegacy" />
                                </asp:View>
                                <asp:View ID="vScholar" runat="server">
                                    <uc1:UCScholar runat="server" ID="UCScholar" />
                                </asp:View>
                                <asp:View ID="vTermInsurance" runat="server">
                                    <uc1:UCTermInsurance runat="server" ID="UCTermInsurance" />
                                </asp:View>
                                <asp:View ID="vFuneral" runat="server">
                                    <uc1:UCFuneral runat="server" ID="UCFuneral" />
                                </asp:View>
                            </asp:MultiView>
                        </div>
                    </li>
                </ul>
            </li>
            <!--principal-->
            <uc1:UCRiderContainer runat="server" ID="UCRiderContainer" />

            <uc1:UCBeneficiariesContainer runat="server" ID="UCBeneficiariesContainer" />
            <!--principal-->
            <uc1:UCRequirementContainer runat="server" ID="UCRequirementContainer" />
            <!--principal-->
        </ul>
    </div>
    <!--acordeon_tabulado-->
</div>
<!--col-2-3-->

<div class="col-1-3">
    <div class="fondo_blanco">
        <uc1:UCPlanSummary runat="server" ID="UCPlanSummary1" />
    </div>
    <!--fondo_blanco-->
</div>
<!--col-1-3-->

<div class="col-1-1">
    <div class="barra_azul_celeste">
        <asp:MultiView ID="mvPlanInformationFooter" runat="server" ActiveViewIndex="0">
            <asp:View ID="vAxysFooter" runat="server">
                <uc1:UCAxysFooter runat="server" ID="UCAxysFooter" />
            </asp:View>
            <asp:View ID="vCompassIndexFooter" runat="server">
                <uc1:UCCompassIndexFooter runat="server" ID="UCCompassIndexFooter" />
            </asp:View>
            <asp:View ID="vEduplanFooter" runat="server">
                <uc1:UCEduplanFooter runat="server" ID="UCEduplanFooter" />
            </asp:View>
            <asp:View ID="vHorizonFooter" runat="server">
                <uc1:UCHorizonFooter runat="server" ID="UCHorizonFooter" />
            </asp:View>
            <asp:View ID="vLegacyFooter" runat="server">
                <uc1:UCLegacyFooter runat="server" ID="UCLegacyFooter" />
            </asp:View>
            <asp:View ID="vSentinelFooter" runat="server">
                <uc1:UCSentinelFooter runat="server" ID="UCSentinelFooter" />
            </asp:View>
            <asp:View ID="vScholarFooter" runat="server">
                <uc1:UCScholarFooter runat="server" ID="UCScholarFooter" />
            </asp:View>
            <asp:View ID="vTermInsuranceFooter" runat="server">
                <uc1:UCTermInsuranceFooter runat="server" ID="UCTermInsuranceFooter" />
            </asp:View>
            <asp:View ID="vFuneralFooter" runat="server">
                <uc1:UCFuneralFooter runat="server" ID="UCFuneralFooter" />
            </asp:View>
        </asp:MultiView>
        <!--grupos-->
    </div>
    <!--barra_azul_celeste-->
    <div class="barra_sub_menu">
        <div class="grupos de_5">
            <div>
                <div class="btn_celeste">
                    <span class="calculadora"></span>
                    <asp:Button runat="server" ID="btnCalculate" CssClass="boton" Text="Calculate" OnClientClick="return ValidatePlan();" OnClick="btnCalculate_Click" />
                </div>
                <!--btn_celeste-->
            </div>
            <div>
                <div class="btn_celeste">
                    <span class="see_ilustracion"></span>
                    <asp:Button runat="server" ID="btnSeeIllustration" CssClass="boton" Text="Ver Cotización" OnClientClick="return ValidatePlan();" OnClick="btnSeeIllustration_Click" />
                </div>
                <!--btn_celeste-->
            </div>
            <div>
                <div class="btn_celeste">
                    <span class="compare_ilustracion"></span>
                    <asp:Button runat="server" ID="btnCompareIllustration" CssClass="boton" Text="Compare Illustration" OnClientClick="return ValidatePlan();" OnClick="btnCompareIllustration_Click" />
                </div>
                <!--btn_celeste-->
            </div>
            <div>
                <div class="btn_celeste">
                    <span class="add_ilustracion"></span>
                    <asp:Button runat="server" ID="btnAddIllustration" CssClass="boton" Text="Add Illustration" OnClick="btnAddIllustration_Click" />
                </div>
                <!--btn_celeste-->
            </div>
            <div>
                <div class="btn_celeste">
                    <span class="email_ilustracion"></span>
                    <asp:Button runat="server" ID="btnEmailIllustration" CssClass="boton" Text="E-mail Illustration" OnClick="btnEmailIllustration_Click" />
                </div>
                <!--btn_celeste-->
            </div>
            <div>
                <div class="btn_celeste">
                    <span class="save_celeste"></span>
                    <asp:Button runat="server" ID="btnSave" CssClass="boton" Text="Save" OnClientClick="return ValidatePlan();" OnClick="btnSave_Click" />
                </div>
                <!--btn_celeste-->
            </div>
            <div>
                <div class="btn_celeste">
                    <span class="save_as"></span>
                    <asp:Button runat="server" ID="btnSaveAs" CssClass="boton" Text="Save As" OnClientClick="return ValidatePlan();" OnClick="btnSaveAs_Click" />
                </div>
                <!--btn_celeste-->
            </div>
            <div>
                <div class="btn_celeste">
                    <span class="submit_celeste"></span>
                    <asp:Button runat="server" ID="btnSubmit" ClientIDMode="Static" CssClass="boton" Text="Submit Policy" OnClientClick="return SaveIllustration();" OnClick="btnSubmit_Click" />

                </div>
                <!--btn_celeste-->
            </div>
            <div>
                <div class="btn_celeste">
                    <span class="delete_celeste"></span>
                    <asp:Button runat="server" ID="btnDelete" CssClass="boton" Text="Delete" OnClientClick="return ConfirmDelete(this);" OnClick="btnDelete_Click" />
                </div>
                <!--btn_celeste-->
            </div>
            <div>
                <div class="btn_celeste">
                    <span class="delete_celeste"></span>
                    <asp:Button runat="server" ID="btnEform" CssClass="boton" Text="Eform" OnClick="btnEform_Click" />
                </div>
                <!--btn_celeste-->
            </div>
        </div>
        <!--grupos-->
    </div>
    <!--barra_sub_menu-->
</div>
<!--col-1-1-->
<asp:HiddenField runat="server" ID="hdnLnkAccordeon" ClientIDMode="Static" />
<asp:HiddenField runat="server" ID="hdnCanSaveWithOtherAgent" ClientIDMode="Static" Value="false" />
<asp:HiddenField runat="server" ID="hdnOwnerId" />
<dx:ASPxPopupControl ID="ppcAgentToSubmit" runat="server" CloseAction="CloseButton" CloseOnEscape="true" Modal="True"
    PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="ppcAgentToSubmit" AllowDragging="True"
    PopupAnimationType="None" HeaderText="Contact">
    <ContentCollection>
        <dx:PopupControlContentControl runat="server" Width="100px" Height="100px">
            <div id="frmAgentToSubmit" class="barra_sub_menu">
                <div class="grupos">
                    <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.Select.ToUpper() %> <%=RESOURCE.UnderWriting.NewBussiness.Resources.AGENT.ToUpper() %>:</label>
                    <div class="wrap_select" style="width: 255px;">
                        <asp:DropDownList runat="server" ID="ddlAgentToSubmit" validation="Required" ClientIDMode="Static"></asp:DropDownList>
                    </div>
                    <div>
                    </div>
                    <div class="btn_celeste">
                        <span class="submit_celeste"></span>
                        <asp:Button runat="server" ID="btnSaveWithAgent" OnClientClick="return btnSaveAgent();" ClientIDMode="Static" CssClass="boton" OnClick="btnSubmit_Click" Text="Save Agent" />
                    </div>
                </div>
            </div>
        </dx:PopupControlContentControl>
    </ContentCollection>
</dx:ASPxPopupControl>
