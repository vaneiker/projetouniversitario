<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InspectionForm.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.VehicleInspectionForm.InspectionForm" %>
<%@ Register Src="~/NewBusiness/UserControls/VehicleInspectionForm/InformacionesGenerales.ascx" TagPrefix="uc1" TagName="InformacionesGenerales" %>
<%@ Register Src="~/NewBusiness/UserControls/VehicleInspectionForm/TipoCombustible.ascx" TagPrefix="uc1" TagName="TipoCombustible" %>
<%@ Register Src="~/NewBusiness/UserControls/VehicleInspectionForm/VerificacionFuncionamiento.ascx" TagPrefix="uc1" TagName="VerificacionFuncionamiento" %>
<%@ Register Src="~/NewBusiness/UserControls/VehicleInspectionForm/VerificacionPartesFisicas.ascx" TagPrefix="uc1" TagName="VerificacionPartesFisicas" %>
<%@ Register Src="~/NewBusiness/UserControls/VehicleInspectionForm/AccesoriosTapiceria.ascx" TagPrefix="uc1" TagName="AccesoriosTapiceria" %>
<%@ Register Src="~/NewBusiness/UserControls/VehicleInspectionForm/SistemasSeguridadComplementos.ascx" TagPrefix="uc1" TagName="SistemasSeguridadComplementos" %>
<%@ Register Src="~/NewBusiness/UserControls/VehicleInspectionForm/Fotos.ascx" TagPrefix="uc1" TagName="Fotos" %>
<%@ Register Src="~/NewBusiness/UserControls/VehicleInspectionForm/OtrasInformaciones.ascx" TagPrefix="uc1" TagName="OtrasInformaciones" %>

<div class="st-content-inner noOverflow">
    <!--extra div para emular el left side fixed-->
    <div id="main" style="display: block;">
        <!--CONTENIDO EMPIEZA AQUI-->
        <div class="main clearfix">
            <!--CONTENIDO DERECHA-->
            <div class="contenido_derecha details_mc">
                <!--wrapper de las columnas-->
                <div class="grid grid-pad">
                    <div class="col-1-1">
                        <div class="contenedor_tabs">
                            <ul class="tabs_ttle dvddo_in_3">
                                <li class="active dos_lineas" style="width: 100%; top: 10px;">
                                    <label><%= RESOURCE.UnderWriting.NewBussiness.Resources.VehicleInspectionForm.ToUpper() %></label>
                                </li>
                            </ul>
                        </div>
                        <!--contenedor_tabs-->

                        <!--accordion_tabulado-->
                        <div class="accordion_tabulado">
                            <div class="InformacionesG" id="frmFormularioInspeccion">
                                <asp:UpdatePanel ClientIDMode="Static" ID="updFormularioInspeccion" runat="server">
                                    <ContentTemplate>
                                        <ul class="principal">
                                            <li>
                                                <a data-review-group-id="" href="#item1" id="current" class="trigger shown"><%= RESOURCE.UnderWriting.NewBussiness.Resources.VehicleGeneralInformation.ToUpper() %>
                                                    <span>
                                                        <!--icono-->
                                                    </span>
                                                </a>
                                                <ul>
                                                    <li>
                                                        <uc1:InformacionesGenerales runat="server" ID="informacionesGenerales1" />
                                                    </li>
                                                </ul>
                                            </li>
                                            <li>
                                                <a data-review-group-id="" href="#item3" class="trigger shown"><%= RESOURCE.UnderWriting.NewBussiness.Resources.VehicleFuelType.ToUpper() %>
                                                    <span>
                                                        <!--icono-->
                                                    </span>
                                                </a>
                                                <ul>
                                                    <li>
                                                        <uc1:TipoCombustible runat="server" ID="tipoCombustible1" />
                                                    </li>
                                                </ul>
                                            </li>
                                            <li>
                                                <a data-review-group-id="" href="#item4" class="trigger shown"><%= RESOURCE.UnderWriting.NewBussiness.Resources.VehicleOperationCheck.ToUpper() %>
                                                    <span>
                                                        <!--icono-->
                                                    </span>
                                                </a>
                                                <ul>
                                                    <li>
                                                        <uc1:VerificacionFuncionamiento runat="server" ID="verificacionFuncionamiento1" />
                                                    </li>
                                                </ul>
                                            </li>
                                            <li>
                                                <a data-review-group-id="" href="#item5" class="trigger shown"><%= RESOURCE.UnderWriting.NewBussiness.Resources.VehicleCheckPhysicalParts.ToUpper() %>
                                                    <span>
                                                        <!--icono-->
                                                    </span>
                                                </a>
                                                <ul>
                                                    <li>
                                                        <uc1:VerificacionPartesFisicas runat="server" ID="verificacionPartesFisicas1" />
                                                    </li>
                                                </ul>
                                            </li>
                                            <li>
                                                <a data-review-group-id="" href="#item6" class="trigger shown"><%= string.Format("{0} {1} {2}", RESOURCE.UnderWriting.NewBussiness.Resources.VehicleAccessories,
                                                                                                                                                RESOURCE.UnderWriting.NewBussiness.Resources.And,
                                                                                                                                                RESOURCE.UnderWriting.NewBussiness.Resources.VehicleUpholstery) %>
                                                    <span>
                                                        <!--icono-->
                                                    </span>
                                                </a>
                                                <ul>
                                                    <li>
                                                        <uc1:AccesoriosTapiceria runat="server" ID="accesoriosTapiceria1" />
                                                    </li>
                                                </ul>
                                            </li>
                                            <li style="display: ;">
                                                <a data-review-group-id="" href="#item7" class="trigger shown"><%= string.Format("{0} {1} {2}", RESOURCE.UnderWriting.NewBussiness.Resources.VehicleSecuritySystems,
                                                                                                                                                RESOURCE.UnderWriting.NewBussiness.Resources.And,
                                                                                                                                                RESOURCE.UnderWriting.NewBussiness.Resources.VehicleComplement) %>
                                                    <span>
                                                        <!--icono-->
                                                    </span>
                                                </a>
                                                <ul>
                                                    <li>
                                                        <uc1:SistemasSeguridadComplementos runat="server" ID="sistemasSeguridadComplementos1" />
                                                    </li>
                                                </ul>
                                            </li>
                                            <li>
                                                <a data-review-group-id="" href="#item8" class="trigger shown"><%= RESOURCE.UnderWriting.NewBussiness.Resources.VehiclePhotos.ToUpper() %>
                                                    <span>
                                                        <!--icono-->
                                                    </span>
                                                </a>
                                                <ul>
                                                    <li>
                                                        <uc1:Fotos runat="server" ID="Fotos1" />
                                                    </li>
                                                </ul>
                                            </li>
                                            <li>
                                                <a data-review-group-id="" href="#item9" class="trigger shown"><%= RESOURCE.UnderWriting.NewBussiness.Resources.OtherInformations.ToUpper() %>
                                                    <span>
                                                        <!--icono-->
                                                    </span>
                                                </a>
                                                <ul>
                                                    <li>
                                                        <uc1:OtrasInformaciones runat="server" ID="otrasInformaciones1" />
                                                    </li>
                                                </ul>
                                            </li>
                                        </ul>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>

                            <%--Botones--%>
                            <div class="row_A mT10 btnFunc" style="padding-right: 12px;">
                                <div class="fl">
                                    <asp:Button
                                        ClientIDMode="Static"
                                        runat="server"
                                        ID="btnBackToIllustrations"
                                        CssClass="col-12 fl button button-red alignC embossed"
                                        CausesValidation="false"
                                        OnClientClick="return DlgConfirmWithCallBackInspectionForm(this, '', 500, 150, null, null, 'VehicleLeavingInspectionPage');"
                                        OnClick="btnBackToIllustrations_Click" />
                                </div>
                                <div class="fr" style="padding-right: 10px;">
                                    <asp:Button
                                        runat="server"
                                        ID="btnSave"
                                        CssClass=" button button-green alignC embossed"
                                        Text="Save"
                                        OnClientClick="return saveAll('');"
                                        OnClick="btnSave_Click" />

                                    <asp:Button
                                        Enabled="false"
                                        runat="server"
                                        ID="btnDownLoad"
                                        CssClass=" button button-blue alignC embossed boton_descargar_foto"
                                        Text="Download"
                                        OnClick="btnDownLoad_Click" />

                                    <asp:Button
                                        runat="server"
                                        ID="btnClean"
                                        CssClass=" button button-gris alignC embossed"
                                        Text="Clean"
                                        OnClientClick="return DlgConfirmInspectionForm(this);"
                                        OnClick="btnClean_Click" />

                                    <asp:Button
                                        runat="server"
                                        Enabled="false"
                                        ID="btnSendToSubscription"
                                        CssClass="button button-red alignC embossed"
                                        ClientIDMode="Static"
                                        Text=""
                                        OnClick="btnSendToSubscription_Click" />
                                </div>

                            </div>
                            <%--Botones--%>
                        </div>
                        <!--accordion_tabulado-->
                    </div>
                    <!--col-1-1-->
                    <!--grid grid-pad-->
                </div>
                <!--contendio derecha-->
            </div>
            <!-- /main clearfix -->
        </div>
    </div>
</div>

<asp:HiddenField ClientIDMode="Static" ID="hdnValidate" runat="server" Value="true" />
<asp:HiddenField ClientIDMode="Static" ID="hdnSaved" runat="server" Value="false" />

