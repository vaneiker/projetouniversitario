<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddNewClient.aspx.cs" Inherits="WEB.NewBusiness.NewBusiness.Pages.AddNewClient" MasterPageFile="~/Business.Master" Title="Cotizador Vida - Ingresar Información" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/NewBusiness/UserControls/AddNewClient/WUCSearchClientOrOwner.ascx" TagPrefix="uc1" TagName="WUCSearchClientOrOwner" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Src="~/NewBusiness/UserControls/AddNewClient/ContactsInfo/WUCSearch.ascx" TagPrefix="uc2" TagName="WUCSearch" %>
<%@ Register Src="~/NewBusiness/UserControls/AddNewClient/ContactsInfo/ContactsInfoContainer.ascx" TagPrefix="uc1" TagName="ContactsInfoContainer" %>
<%@ Register Src="~/NewBusiness/UserControls/AddNewClient/PlanPolicy/PlanPolicyContainer.ascx" TagPrefix="uc1" TagName="PlanPolicyContainer" %>
<%@ Register Src="~/NewBusiness/UserControls/Common/WUCSearch.ascx" TagPrefix="uc3" TagName="WUCSearch" %>
<%@ Register Src="~/NewBusiness/UserControls/Common/WUCSearch.ascx" TagPrefix="uc4" TagName="WUCSearch" %>
<%@ Register Src="~/NewBusiness/UserControls/AddNewClient/Beneficiaries/BeneficiariesContainer.ascx" TagPrefix="uc1" TagName="BeneficiariesContainer" %>
<%@ Register Src="~/NewBusiness/UserControls/AddNewClient/Requirements/RequirementsContainer.ascx" TagPrefix="uc1" TagName="RequirementsContainer" %>
<%@ Register Src="~/NewBusiness/UserControls/AddNewClient/Payment/PaymentContainer.ascx" TagPrefix="uc1" TagName="PaymentContainer" %>
<%@ Register Src="~/NewBusiness/UserControls/AddNewClient/HealthDeclaration/HealthDeclarationContainer.ascx" TagPrefix="uc1" TagName="HealthDeclarationContainer" %>
<%@ Register Src="~/NewBusiness/UserControls/AddNewClient/HealthDeclaration/UCGridViewPopup.ascx" TagPrefix="uc1" TagName="UCGridViewPopup" %>
<asp:Content ID="headerContent" ContentPlaceHolderID="head" runat="server">
    <script src="../../Scripts/JSPages/AddNewClient/AddNewClient.js"> </script>
</asp:Content>

<asp:Content ContentPlaceHolderID="bodyContent" runat="server">
    <script type="text/javascript">
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_beginRequest(BeginRequestHandler);
        prm.add_endRequest(EndRequestHandler);
    </script>
    <div id="scroll_2" class="st-content-inner">
        <!--extra div para emular el left side fixed-->

        <!--CONTENIDO EMPIEZA AQUI-->
        <div class="main clearfix">
            <!--CONTENIDO DERECHA-->
            <div class="contenido_derecha management_mc">                
                    <div class="contenedor_tabs" style="margin-bottom: 0;">
                        <ul class="tabs_ttle dvddo_in_7 lineBussines">
                            <li class="liPuntoVenta">
                                <asp:LinkButton Style="padding: 0;" runat="server" ID="lnkAuto" appname="VirtualOffice" OnClientClick="return CorfimRedirect(this)" OnClick="lnkAuto_Click">
                                <img class="IcoPuntoVenta" src="../../images/top-menu-icon/ico-auto.png" />
                                <strong>Autos</strong>                                                          
                                </asp:LinkButton>
                            </li>
                            <li class="liPuntoVenta encurso">
                                <asp:LinkButton Style="padding: 0;" runat="server" ID="lkLife" appname="VirtualOffice" OnClientClick="return CorfimRedirect(this)" OnClick="lkLife_Click"> 
                                <img class="IcoPuntoVenta" src="../../images/top-menu-icon/ico-vida.png" />
                                <strong>Vida</strong>  
                                </asp:LinkButton>
                            </li>
                            <li class="liPuntoVenta">
                                <asp:LinkButton Style="padding: 0;" runat="server" ID="lnkHealth" appname="VirtualOffice" OnClientClick="return CorfimRedirect(this)" OnClick="lnkHealth_Click"> 
                                <img class="IcoPuntoVenta" src="../../images/top-menu-icon/ico-salud.png" />
                                <strong>Salud</strong>
                                </asp:LinkButton>
                            </li>
                            <li class="liPuntoVenta">
                                <asp:LinkButton Style="padding: 0;" runat="server" ID="lnkVivienda" appname="VirtualOffice" OnClientClick="return CorfimRedirect(this)" OnClick="lnkVivienda_Click">
                               <img class="IcoPuntoVenta" src="../../images/top-menu-icon/ico-propiedad.png" />
                               <strong>Vivienda</strong>
                                </asp:LinkButton>
                            </li>
                            <li class="liPuntoVenta">
                                <asp:LinkButton Style="padding: 0;" runat="server" ID="LinkButton1" appname="VirtualOffice" OnClientClick="return CorfimRedirect(this)" OnClick="lnkLineaAleada_Click">
                              <img class="IcoPuntoVenta" src="../../images/top-menu-icon/ico-lespeciales.png" />
                              <strong>Líneas de <br>Especialidad</strong>
                                </asp:LinkButton>
                            </li>
                            <li class="liPuntoVenta">
                                <asp:LinkButton Style="padding: 0;" runat="server" ID="lnkLineaAleada" appname="VirtualOffice" OnClientClick="return CorfimRedirect(this)" OnClick="lnkLineaAleada_Click">
                                <img class="IcoPuntoVenta" src="../../images/top-menu-icon/ico-lcomerciales.png" />
                                <strong>Lineas <br>Comerciales</strong>
                                </asp:LinkButton>
                            </li>
                            <li class="liPuntoVenta">
                                <asp:LinkButton Style="padding: 0;" runat="server" ID="lkFunerario" appname="VirtualOffice" OnClientClick="return CorfimRedirect(this)" OnClick="lkLife_Click">
                              <img class="IcoPuntoVenta" src="../../images/top-menu-icon/ico-servicios.png" />
                                <strong>Servicios <br>Funerarios</strong>
                                </asp:LinkButton>
                            </li>
                        </ul>
                    </div>

                <!--wrapper de las columnas-->
                <div class="grid grid-pad">
                    <div class="col-1-1" style="padding: 0;">
                        <div class="contenedor_tabs">
                            <ul class="tabs_ttle dvddo_in_7" runat="server" id="MenuTabs" clientidmode="Static">
                                <li runat="server" id="liClientInfo">
                                    <asp:LinkButton runat="server" ID="lnkClientInfo" OnClick="ManageTabs" alt="1" CommandArgument="1" TabID="1" ClientIDMode="Static" OnClientClick="return validacionesTab(this);" tabStatus="statusClientInfo"><i runat="server" id="statusClientInfo" class="">1</i><span> <%=RESOURCE.UnderWriting.NewBussiness.Resources.ClientInfoLabel2 %> </span></asp:LinkButton>
                                </li>
                                <li runat="server" id="liOwner">
                                    <asp:LinkButton runat="server" ID="lnkOwnerInfo" OnClick="ManageTabs" alt="2" CommandArgument="2" TabID="2" ClientIDMode="Static" OnClientClick="return validacionesTab(this);" tabStatus="statusOwnerInfo"><i runat="server" id="statusOwnerInfo" class="">2</i><span><%=RESOURCE.UnderWriting.NewBussiness.Resources.OwnerInfoLabel2 %> </span></asp:LinkButton>
                                </li>
                                <li runat="server" id="liPolicy">
                                    <asp:LinkButton runat="server" ID="lnkPlanPolicy" OnClick="ManageTabs" alt="3" CommandArgument="3" TabID="3" ClientIDMode="Static" OnClientClick="return validacionesTab(this);" tabStatus="statusPlanPolicy"><i runat="server" id="statusPlanPolicy" class="">3</i><span><%=RESOURCE.UnderWriting.NewBussiness.Resources.PlanPolicyLabel %></span></asp:LinkButton>
                                </li>
                                <li runat="server" id="liBeneficiaries">
                                    <asp:LinkButton runat="server" ID="lnkBeneficiaries" OnClick="ManageTabs" alt="4" CommandArgument="4" TabID="4" ClientIDMode="Static" OnClientClick="return validacionesTab(this);" tabStatus="statusBeneficiaries"><i runat="server" id="statusBeneficiaries" class="">4</i><span><%=RESOURCE.UnderWriting.NewBussiness.Resources.BeneficiariesLabel %></span> </asp:LinkButton>
                                </li>
                                <li runat="server" id="liHealthDeclaration">
                                    <asp:LinkButton runat="server" ID="lnkHealthDeclaration" OnClick="ManageTabs" alt="5" CommandArgument="5" TabID="7" ClientIDMode="Static" OnClientClick="return validacionesTab(this);" tabStatus="statusHealthDeclaration"><i runat="server" id="statusHealthDeclaration" class="">5</i><span><%=RESOURCE.UnderWriting.NewBussiness.Resources.HealthDeclarationLabel2 %></span> </asp:LinkButton>
                                </li>
                                <li runat="server" id="liRequirements">
                                    <asp:LinkButton runat="server" ID="lnkRequirements" OnClick="ManageTabs" alt="6" CommandArgument="6" TabID="5" ClientIDMode="Static" OnClientClick="return validacionesTab(this);" tabStatus="statusRequirements"><i runat="server" id="statusRequirements" class="">6</i><span><%=RESOURCE.UnderWriting.NewBussiness.Resources.RequirementsLabel %> </span></asp:LinkButton>
                                </li>
                                <li runat="server" id="liPayment">
                                    <asp:LinkButton runat="server" ID="lnkPayment" OnClick="ManageTabs" alt="7" CommandArgument="7" TabID="6" ClientIDMode="Static" OnClientClick="return validacionesTab(this);" tabStatus="statusPayment"><i runat="server" id="statusPayment" class="">7</i><span><%=RESOURCE.UnderWriting.NewBussiness.Resources.PaymentsLabel %></span> </asp:LinkButton>
                                </li>
                            </ul>
                        </div>

                        <!--contenedor_tabs-->
                        <asp:Panel runat="server" ID="pnContainer">
                            <asp:Panel runat="server" ID="pnContactsInfo" Visible="true">
                                <uc2:WUCSearch runat="server" ID="WUCSearchContacts" />
                                <div class="titulos_sin_accion">
                                    <%                                          
                                        if (hdnCurrentTabAddNewClient.Value.Split('|')[0] == "lnkClientInfo")
                                            Response.Write(RESOURCE.UnderWriting.NewBussiness.Resources.CLIENTINFORMATIONLabel);
                                        else
                                            Response.Write(RESOURCE.UnderWriting.NewBussiness.Resources.OwnerInformationLabel);                                        
                                    %>
                                </div>
                                <div class="fondo_gris seis">
                                    <uc1:ContactsInfoContainer runat="server" ID="ContactsInfoContainer" />
                                </div>
                            </asp:Panel>

                            <asp:Panel runat="server" ID="pnPlanPolicy" Visible="false">
                                <uc4:WUCSearch runat="server" ID="WUCSearch" />
                                <div class="titulos_sin_accion">
                                    <asp:Literal runat="server" ID="policyInformation">POLICY INFORMATION</asp:Literal>
                                </div>
                                <div class="fondo_gris seis">
                                    <uc1:PlanPolicyContainer runat="server" ID="PlanPolicyContainer" />
                                </div>
                            </asp:Panel>

                            <asp:Panel runat="server" ID="pnBeneficiaries" Visible="false">
                                <uc3:WUCSearch runat="server" ID="WUCSearch3" />
                                <div class="fondo_gris seis">
                                    <uc1:BeneficiariesContainer runat="server" ID="BeneficiariesContainer" />
                                </div>
                            </asp:Panel>

                            <asp:Panel runat="server" ID="pnRequirements" Visible="false">
                                <uc3:WUCSearch runat="server" ID="WUCSearch4" />
                                <uc1:RequirementsContainer runat="server" ID="RequirementsContainer" />
                            </asp:Panel>

                            <asp:Panel runat="server" ID="pnPayment" Visible="false">
                                <uc3:WUCSearch runat="server" ID="WUCSearch5" />
                                <uc1:PaymentContainer runat="server" ID="PaymentContainer" />
                            </asp:Panel>
                            <asp:Panel runat="server" ID="pnHealthDeclaration" Visible="false">
                                <uc1:HealthDeclarationContainer runat="server" ID="HealthDeclarationContainer" />
                            </asp:Panel>
                        </asp:Panel>

                    </div>
                    <!--col-1-1-->
                </div>
                <!--grid grid-pad-->
            </div>
    <!--contendio derecha-->
        </div>
        <!-- /main clearfix -->
    </div>
    <dx:ASPxPopupControl ID="popSearchClientOrOwner" ClientInstanceName="popSearchClientOrOwner" EncodeHtml="false" runat="server" PopupHorizontalAlign="WindowCenter" ShowCloseButton="true" ShowHeader="true" Modal="True" PopupVerticalAlign="WindowCenter"
        ShowOnPageLoad="False" AllowDragging="true" ClientIDMode="Static" CloseAction="CloseButton" ClientSideEvents-Closing="CloseSearchClientOrOwner()">
        <ClientSideEvents Closing="function(s, e) {CloseSearchClientOrOwner();}" />
        <Windows>
            <dx:PopupWindow Name="ClientOwnerSearch" Modal="true" Width="800px" Height="500px">
                <ContentCollection>
                    <dx:PopupControlContentControl runat="server">
                        <uc1:WUCSearchClientOrOwner runat="server" ID="WUCSearchClientOrOwner" />
                    </dx:PopupControlContentControl>
                </ContentCollection>
            </dx:PopupWindow>
        </Windows>
    </dx:ASPxPopupControl>
    <!-- /st-content-inner -->
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="udpAddNewClient">
        <ContentTemplate>
            <asp:HiddenField runat="server" ID="hdnShowPopClientInfoSearch" ClientIDMode="Static" Value="false" />
            <asp:HiddenField runat="server" ID="hdnCurrentTabAddNewClient" ClientIDMode="Static" Value="lnkClientInfo" />
            <asp:HiddenField runat="server" ID="hdnValidate" Value="true" ClientIDMode="Static" />
            <asp:HiddenField runat="server" ClientIDMode="static" ID="hdnPopAnswerPadecimiento" Value="false" />
            <asp:HiddenField runat="server" ClientIDMode="static" ID="hdnIsFirstTime" Value="" />
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:ModalPopupExtender ID="ModalPopupPadecimiento" BackgroundCssClass="modalPopup2" PopupControlID="pnPadecimiento" TargetControlID="hfPadecimiento" BehaviorID="popupPadecimiento" runat="server"></asp:ModalPopupExtender>
    <asp:Panel runat="server" ID="pnPadecimiento" ClientIDMode="Static" Style="display: none">
        <uc1:UCGridViewPopup runat="server" ID="UCGridViewPopup" />
    </asp:Panel>
    <asp:HiddenField runat="server" ID="hfPadecimiento" ClientIDMode="Static" />
</asp:Content>
