<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUCView.ascx.cs" Inherits="WEB.NewBusiness.DReview.UserControl.Common.WUCView" %>
<%@ Register Src="~/NewBusiness/UserControls/Common/WUCAddress.ascx" TagPrefix="uc1" TagName="WUCAddress" %>
<%@ Register Src="~/NewBusiness/UserControls/AddNewClient/ContactsInfo/ContactsInfoContainer.ascx" TagPrefix="uc1" TagName="ContactsInfoContainer" %>
<%@ Register Src="~/NewBusiness/UserControls/AddNewClient/Beneficiaries/BeneficiariesContainer.ascx" TagPrefix="uc1" TagName="BeneficiariesContainer" %>
<%@ Register Src="~/NewBusiness/UserControls/AddNewClient/HealthDeclaration/HealthDeclarationContainer.ascx" TagPrefix="uc1" TagName="HealthDeclarationContainer" %>
<%@ Register Src="~/NewBusiness/UserControls/AddNewClient/Requirements/RequirementsContainer.ascx" TagPrefix="uc1" TagName="RequirementsContainer" %>
<%@ Register Src="~/NewBusiness/UserControls/AddNewClient/Payment/PaymentContainer.ascx" TagPrefix="uc1" TagName="PaymentContainer" %>
<%@ Register Src="~/NewBusiness/UserControls/AddNewClient/PlanPolicy/PlanPolicyContainer.ascx" TagPrefix="uc1" TagName="PlanPolicyContainer" %>
<%@ Register Src="~/NewBusiness/UserControls/AddNewClient/Requirements/WUCPDFViewerReq.ascx" TagPrefix="uc1" TagName="WUCPDFViewerReq" %>

<div class="grid grid-pad">
    <div class="col-1-1">
        <div class="grupos titulos_sin_accion2">
            <asp:Literal runat="server" ID="ltViewLabel"></asp:Literal>
            <div class="float_right padding_r_10">
                <div class="boton_wrapper azul margin_0">
                    <span class="prev_icon"></span>
                    <asp:Button CssClass="boton" runat="server" ID="btnBackToTheList" Text="Back to the list" OnClick="btnBackToTheList_Click" />
                </div>
            </div>
            <!--grupos-->
        </div>
        <!--col-1-1-->
        <div class="col-1-1">
            <div class="barra1 no_padding">
                <div class="filter">
                    <div class="grupos de_5">
                        <div>
                            <label class="label" runat="server" id="PolicyNo">Policy #</label>
                            <asp:TextBox runat="server" ID="txtPolicy" ReadOnly="true" disabled></asp:TextBox>
                        </div>
                        <div>
                            <label class="label" runat="server" id="FirstName">First Name</label>
                            <asp:TextBox runat="server" ID="txtFirstName" ReadOnly="true" disabled></asp:TextBox>
                        </div>
                        <div>
                            <label class="label" runat="server" id="MiddleName">Middle Name</label>
                            <asp:TextBox runat="server" ID="txtMiddleName" ReadOnly="true" disabled></asp:TextBox>
                        </div>
                        <div>
                            <label class="label" runat="server" id="LastName">Last Name</label>
                            <asp:TextBox runat="server" ID="txtLastName" ReadOnly="true" disabled></asp:TextBox>
                        </div>
                        <div>
                            <label class="label" runat="server" id="SecondLastName">Second Last Name</label>
                            <asp:TextBox runat="server" ID="txtSecondLastName" ReadOnly="true" disabled></asp:TextBox>
                        </div>
                    </div>
                    <!--grupos-->
                </div>
                <!--filter-->
            </div>
            <!--barra1-->
            <div class="contenedor_tabs">
                <ul id="MenuTabsView" class="tabs_ttle dvddo_in_7">
                    <li>
                        <asp:LinkButton runat="server" ID="lnkClientInfo" OnClick="ManageTabs" ClientIDMode="Static" OnClientClick="BeginRequestHandler(this);return validacionesTab(this);"> <%=RESOURCE.UnderWriting.NewBussiness.Resources.ClientInfoLabel %>  </asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton runat="server" ID="lnkOwnerInfo" OnClick="ManageTabs" ClientIDMode="Static" OnClientClick="BeginRequestHandler(this); return validacionesTab(this);"> <%=RESOURCE.UnderWriting.NewBussiness.Resources.OwnerInfoLabel %>  </asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton runat="server" ID="lnkPlanPolicy" OnClick="ManageTabs" ClientIDMode="Static" OnClientClick="BeginRequestHandler(this); return validacionesTab(this);"> <%=RESOURCE.UnderWriting.NewBussiness.Resources.PlanInformationLabel %> </asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton runat="server" ID="lnkBeneficiaries" OnClick="ManageTabs" ClientIDMode="Static" OnClientClick="BeginRequestHandler(this);return validacionesTab(this);"> <%=RESOURCE.UnderWriting.NewBussiness.Resources.BeneficiariesLabel %> </asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton runat="server" ID="lnkHealthDeclaration" OnClick="ManageTabs" ClientIDMode="Static" OnClientClick="BeginRequestHandler(this);return validacionesTab(this);"> <%=RESOURCE.UnderWriting.NewBussiness.Resources.HealthDeclarationLabel %> </asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton runat="server" ID="lnkRequirements" OnClick="ManageTabs" ClientIDMode="Static" OnClientClick="BeginRequestHandler(this);return validacionesTab(this);"> <%=RESOURCE.UnderWriting.NewBussiness.Resources.RequirementsLabel %> </asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton runat="server" ID="lnkPayment" OnClick="ManageTabs" ClientIDMode="Static" OnClientClick="BeginRequestHandler(this);return validacionesTab(this);"> <%=RESOURCE.UnderWriting.NewBussiness.Resources.PaymentsLabel %> </asp:LinkButton>
                    </li>
                </ul>
            </div>
            <!--contenedor_tabs-->

            <div class="fondo_gris">

                <asp:MultiView runat="server" ID="mtvTabs" ActiveViewIndex="0">
                    <asp:View runat="server" ID="vContactsInfo">
                        <uc1:ContactsInfoContainer runat="server" ID="ContactsInfoContainer" />
                    </asp:View>
                    <asp:View runat="server" ID="vPlanPolicy">
                        <uc1:PlanPolicyContainer runat="server" ID="PlanPolicyContainer" />
                    </asp:View>
                    <asp:View runat="server" ID="vBeneficiaries">
                        <uc1:BeneficiariesContainer runat="server" ID="BeneficiariesContainer" />
                    </asp:View>
                    <asp:View runat="server" ID="vHealthDeclaration">
                        <uc1:HealthDeclarationContainer runat="server" ID="HealthDeclarationContainer" />
                    </asp:View>
                    <asp:View runat="server" ID="vRequirements">
                        <uc1:RequirementsContainer runat="server" ID="RequirementsContainer" />
                    </asp:View>
                    <asp:View runat="server" ID="vPayments">
                        <uc1:PaymentContainer runat="server" ID="PaymentContainer" />
                    </asp:View>
                </asp:MultiView>
            </div>
            <!--fondo gris-->
        </div>
        <!--col-1-2--> 
    </div>
    <!--grid grid-pad-->
</div>
<asp:HiddenField runat="server" ID="hdnCurrentTabView" Value="lnkClientInfo" ClientIDMode="Static" />
<asp:HiddenField runat="server" ID="hdnIsCompanyOwnerView" Value="false" ClientIDMode="Static" />
<asp:HiddenField runat="server" ID="hdnShowPopRequirementPDF" Value="false" ClientIDMode="Static" />
<asp:HiddenField runat="server" ID="hdnisFuneral" Value="false" ClientIDMode="Static" />
<div id="dvPopPDFRequirements" style="display: none">
    <uc1:WUCPDFViewerReq runat="server" ID="WUCPDFViewerReq" />
</div>
