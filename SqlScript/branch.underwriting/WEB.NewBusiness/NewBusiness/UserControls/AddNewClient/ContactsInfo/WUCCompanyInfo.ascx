<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUCCompanyInfo.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.AddNewClient.ContactsInfo.WUCCompanyInfo" %>
<%@ Import Namespace="Microsoft.Ajax.Utilities" %>
<%@ Register Src="~/NewBusiness/UserControls/Common/WUCAddress.ascx" TagPrefix="uc1" TagName="WUCAddress" %>
<%@ Register Src="~/NewBusiness/UserControls/Common/WUCPhoneNumber.ascx" TagPrefix="uc1" TagName="WUCPhoneNumber" %>
<%@ Register Src="~/NewBusiness/UserControls/Common/WUCEmailAddress.ascx" TagPrefix="uc1" TagName="WUCEmailAddress" %>
<%@ Register Src="~/NewBusiness/UserControls/Common/ModalFinalBeneficiary.ascx" TagPrefix="uc1" TagName="WUCFinalBeneficary" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="udpCompanyInfo">
    <ContentTemplate>
        <div class="titulos_sin_accion" style="width: 100%">
            <asp:Literal runat="server" ID="Rep_Legal">PERSONA JURIDICA</asp:Literal>
        </div>
        <asp:Panel runat="server" ID="pnCompany">
            <div class="col-1-1">
                <div class="fondo_blanco fix_height">
                    <div class="content_fondo_blanco">
                        <fieldset class="margin_t_10" id="frmCompany">
                            <div class="grupos de_3">
                                <div>
                                    <label class="label red" runat="server" id="CompanyName">Company Name</label>
                                    <asp:TextBox ID="txtCompanyName" runat="server" ClientIDMode="Static" validation="Required" Width="100%" />
                                </div>
                                <div>
                                    <label class="label" runat="server" id="SocietyType">Society Type</label>
                                    <div class="wrap_select">
                                        <asp:DropDownList ID="ddlSocietyType" ClientIDMode="Static" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                                <div>
                                    <label class="label" runat="server" id="CompanyActivity">Commercial Activity</label>
                                    <div class="wrap_select">
                                        <asp:DropDownList ID="ddlCommercialActivity" ClientIDMode="Static" runat="server"></asp:DropDownList>
                                    </div>
                                </div>

                            </div>
                            <div class="grupos de_3">
                                <div>
                                    <label class="label" runat="server" id="RegistrationNumber">Registration Number</label>
                                    <asp:TextBox ID="txtRegistrationNumber" runat="server" ClientIDMode="Static" />
                                </div>
                                <div>
                                    <label class="label red" runat="server" id="IDType">ID Type</label>
                                    <div class="wrap_select">
                                        <asp:DropDownList runat="server" ID="ddlIDType" validation="Required" AutoPostBack="true" OnSelectedIndexChanged="ddlIDType_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                </div>
                                <div>
                                    <label class="label red" runat="server" id="CompanyRNC">Company ID</label>
                                    <asp:TextBox ID="txtCompanyRNC" runat="server" ClientIDMode="Static" validation="Required" />
                                </div>
                            </div>
                            <div class="grupos de_3">
                                <div>
                                    <label class="label red" runat="server" id="RegistrationDate">Registration Date</label>
                                    <asp:TextBox ID="txtRegistrationDate" CssClass="datepicker" runat="server" ClientIDMode="Static" validation="Required" />
                                </div>
                                <div>
                                    <label class="label" runat="server" id="SocietyFinalBeneficiary">Final Beneficiary</label>
                                    <div class="wrap_select">
                                        <asp:DropDownList ID="ddlSocietyFinalBeneficiary" ClientIDMode="Static" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSocietyFinalBeneficiary_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                    <div style="margin: 10px; color: blue;">
                                        <asp:LinkButton runat="server" ID="btnVerBeneficiariosFinales" OnClick="btnVerBeneficiariosFinales_Click" Visible="false">
                                            Ver Beneficiarios Finales
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                            <asp:Panel runat="server" ID="pnFinalBeneficiaryPop" CssClass="modalPopup" ClientIDMode="Static" Style="display: none">
                                <div class="pop_up_wrapper" style="width: 1000px; height: 500px; overflow-x: hidden; overflow-y: hidden">
                                    <!--l-->
                                    <div class="titulos_azules head_contengridproxi PreviewPDF" style="width: 100%;">
                                        <ul>
                                            <li>BENEFICIARIOS FINALES</li>
                                            <li style="top: 13%;">
                                                <asp:Button ID="btnExitPopup" class="cls_pup" runat="server" Style="background-color: transparent; border-color: transparent;" OnClick="btnExitPopup_Click" />
                                            </li>
                                        </ul>
                                    </div>
                                    <!--titulos_azules-->
                                    <uc1:WUCFinalBeneficary runat="server" ID="WUCFinalBeneficary" />
                                    <!--content_fondo_blanco-->
                                </div>
                            </asp:Panel>
                            <!--grupos-->
                        </fieldset>
                    </div>
                    <!--content_fondo_blanco-->
                </div>
                <!--fondo_blanco-->
            </div>
            <!--col-1-1-->
            <uc1:WUCAddress runat="server" ID="WUCAddress1" />
            <uc1:WUCPhoneNumber runat="server" ID="WUCPhoneNumber1" />
            <uc1:WUCEmailAddress runat="server" ID="WUCEmailAddress1" />
        </asp:Panel>
        <asp:HiddenField runat="server" Value="" ClientIDMode="Static" ID="hdnIsCompany" />
        <asp:ModalPopupExtender ID="mpeFinalBeneficiary" PopupControlID="pnFinalBeneficiaryPop" DropShadow="false" BackgroundCssClass="ModalBackgroud3" TargetControlID="hdnShowFinalBenef" BehaviorID="popupBhvrFinalBeneficiaryPop" runat="server"></asp:ModalPopupExtender>
        <asp:HiddenField ID="hdnCurrentSession" runat="server" Value="" />
        <asp:HiddenField runat="server" Value="false" ClientIDMode="Static" ID="hdnShowFinalBenef" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="ddlIDType" />
        <asp:AsyncPostBackTrigger ControlID="ddlSocietyFinalBeneficiary" />
        <asp:AsyncPostBackTrigger ControlID="btnExitPopup" />
    </Triggers>
</asp:UpdatePanel>




