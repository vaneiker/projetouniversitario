<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCProperty.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.IllustrationAlliedLines.Inspection.UCProperty" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Src="~/NewBusiness/UserControls/Common/WUCDigitalSign.ascx" TagPrefix="uc1" TagName="WUCDigitalSign" %>
<asp:UpdatePanel runat="server">
    <ContentTemplate>
        <asp:Panel ID="pnlGeneral" runat="server">
            <!--accordion_tabulado-->
            <div class="accordion_tabulado">
                <div id="frmFormularioInspeccionPropiedades">
                    <ul class="principal" id="bacc1">
                        <li>
                            <a data-review-group-id="0" href="#item0" id="current" class="trigger shown" lnk="lnk"><%= RESOURCE.UnderWriting.NewBussiness.Resources.InspectionInformation.ToUpper() %>
                                <span>
                                    <!--icono-->
                                </span>
                            </a>
                            <ul>
                                <li>
                                    <div class="fondo_blanco" style="height: 138px;">
                                        <div style="padding: 10px;">
                                            <div class="grupos de_3">
                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.QuotationNumber %>:</span>
                                                    <asp:TextBox
                                                        grpclsitmopt="0|0|0|0|n"
                                                        Enabled="false"
                                                        ID="txtPolizaNo"
                                                        runat="server"
                                                        Style="text-align: center;"></asp:TextBox>
                                                </div>

                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.InspectionDate %>:</span>
                                                    <asp:TextBox
                                                        CssClass="fecha"
                                                        grpclsitmopt="0|0|0|0|n"
                                                        Enabled="false"
                                                        ID="txtFechaInspeccion"
                                                        runat="server"
                                                        Style="text-align: center; text-transform: uppercase;"></asp:TextBox>
                                                </div>

                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.Property %>:</span>
                                                    <asp:DropDownList
                                                        AutoPostBack="true"
                                                        CssClass="combo_box propiedades"
                                                        DataValueField="Key"
                                                        DataTextField="Value"
                                                        ID="ddlPropiedades"
                                                        OnSelectedIndexChanged="ddlPropiedades_SelectedIndexChanged"
                                                        runat="server"
                                                        Style="height: 30px;">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="grupos de_3">
                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.NameRisk %>:</span>
                                                    <asp:TextBox
                                                        grpclsitmopt="0|0|0|0|y"
                                                        ID="txtNombreRiesgo"
                                                        runat="server"></asp:TextBox>
                                                </div>

                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.LocationInspected %>:</span>
                                                    <asp:TextBox
                                                        grpclsitmopt="0|0|0|0|n"
                                                        ID="txtUbicacionInspeccionada"
                                                        runat="server"></asp:TextBox>
                                                </div>
                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.Number %>:</span>
                                                    <asp:TextBox
                                                        CssClass="onlyNumbers"
                                                        grpclsitmopt="0|0|0|0|n"
                                                        ID="txtNumero"
                                                        runat="server"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="grupos de_3">
                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.TypeRisk %>:</span>
                                                    <asp:TextBox
                                                        grpclsitmopt="0|0|0|0|y"
                                                        ID="txtTipoRiesgo"
                                                        runat="server"></asp:TextBox>
                                                </div>

                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.Middleman %>:</span>
                                                    <asp:TextBox
                                                        grpclsitmopt="0|0|0|0|n"
                                                        ID="txtIntermediario"
                                                        runat="server"></asp:TextBox>
                                                </div>

                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.InspectedBy %>:</span>
                                                    <asp:TextBox
                                                        grpclsitmopt="0|0|0|0|n"
                                                        ID="txtInspeccionadoPor"
                                                        runat="server" Visible="false"></asp:TextBox>
                                                    <asp:DropDownList
                                                        grpclsitmopt="0|0|0|0|n"
                                                        AutoPostBack="true"
                                                        ClientIDMode="Static"
                                                        CssClass="combo_box"
                                                        DataValueField="Key"
                                                        DataTextField="Value"
                                                        ID="drpInspectors"
                                                        OnSelectedIndexChanged="drpInspectors_SelectedIndexChanged"
                                                        runat="server"
                                                        Style="padding-left: 4px; width: 50%;">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                </li>
                            </ul>
                        </li>
                        <li>
                            <a data-review-group-id="1" href="#item1" class="trigger shown" lnk="lnk">1. <%= RESOURCE.UnderWriting.NewBussiness.Resources.GeneralData.ToUpper() %>
                                <span>
                                    <!--icono-->
                                </span>
                            </a>
                            <ul>
                                <li>
                                    <div class="fondo_blanco" style="height: 176px;">
                                        <div style="padding: 10px;">
                                            <div class="grupos de_3">
                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.OwnerName %>:</span>
                                                    <asp:TextBox
                                                        grpclsitmopt="9|1|1|0|y"
                                                        ID="txtNombrePropietario"
                                                        runat="server"></asp:TextBox>
                                                </div>

                                                <div class="label_plus_input par inputDoble">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.IdentificationNumber %>:</span>
                                                    <div>
                                                        <asp:TextBox
                                                            Enabled="false"
                                                            grpclsitmopt="9|2|1|0|n"
                                                            ID="txtNumeroIdentificacion"
                                                            ReadOnly="true"
                                                            runat="server"
                                                            Style="text-align: center;"></asp:TextBox>
                                                        <asp:TextBox
                                                            Enabled="false"
                                                            grpclsitmopt="0|0|0|0|n"
                                                            ID="txtIdentificationType"
                                                            ReadOnly="true"
                                                            runat="server"
                                                            Style="text-align: center;"></asp:TextBox>
                                                    </div>
                                                </div>

                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.InterviewWith %>:</span>
                                                    <asp:TextBox
                                                        grpclsitmopt="9|3|1|0|y"
                                                        ID="txtEntrevistaCon"
                                                        runat="server"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="grupos de_3">
                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.AgeOfRisk %>:</span>
                                                    <asp:TextBox
                                                        grpclsitmopt="9|4|1|0|y"
                                                        ID="txtEdadRiesgo"
                                                        runat="server"></asp:TextBox>
                                                </div>

                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.BusinessMovement %>:</span>
                                                    <div class="fl inspection_radio">
                                                        <div style="width: 100% !important;">
                                                            <asp:RadioButtonList
                                                                CellPadding="0"
                                                                CellSpacing="0"
                                                                CssClass="datos_generales"
                                                                DataValueField="Key"
                                                                DataTextField="Value"
                                                                ID="rblMovimientoComercial"
                                                                RepeatDirection="Horizontal"
                                                                RepeatLayout="Table"
                                                                runat="server"
                                                                GroupId="9"
                                                                ClassId="5">
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.FormalAccounting %>:</span>
                                                    <div class="fl inspection_radio">
                                                        <div style="width: 100% !important;">
                                                            <asp:RadioButtonList
                                                                CellPadding="0"
                                                                CellSpacing="0"
                                                                CssClass="datos_generales"
                                                                DataValueField="Key"
                                                                DataTextField="Value"
                                                                ID="rblOrganizacionContable"
                                                                RepeatDirection="Horizontal"
                                                                RepeatLayout="Table"
                                                                runat="server"
                                                                GroupId="9"
                                                                ClassId="6">
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="grupos de_3">
                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.NumberOfEmployees %>:</span>
                                                    <asp:TextBox
                                                        CssClass="onlyNumbers"
                                                        grpclsitmopt="9|7|1|0|y"
                                                        ID="txtNoDeEmpleados"
                                                        number="number"
                                                        runat="server"
                                                        Style="text-align: right;"></asp:TextBox>
                                                </div>

                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.Horary %>:</span>
                                                    <asp:TextBox
                                                        grpclsitmopt="9|8|1|0|y"
                                                        ID="txtHorario"
                                                        runat="server"></asp:TextBox>
                                                </div>

                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.Building %>:</span>
                                                    <div class="fl inspection_radio">
                                                        <div style="width: 100% !important;">
                                                            <asp:RadioButtonList
                                                                CellPadding="0"
                                                                CellSpacing="0"
                                                                CssClass="datos_generales"
                                                                DataValueField="Key"
                                                                DataTextField="Value"
                                                                ID="rblEdificio"
                                                                RepeatDirection="Horizontal"
                                                                RepeatLayout="Table"
                                                                runat="server"
                                                                GroupId="9"
                                                                ClassId="9">
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="grupos de_1">
                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.PreviousInsurer %>:</span>
                                                    <asp:TextBox
                                                        grpclsitmopt="9|10|1|0|n"
                                                        ID="txtAseguradoraAnterior"
                                                        runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </li>
                            </ul>
                        </li>
                        <li>
                            <a data-review-group-id="2" href="#item2" class="trigger shown" lnk="lnk">
                                <label id="lblSumasAseguradas" style="font-weight: bold !important;"></label>
                                <span>
                                    <!--icono-->
                                </span>
                            </a>
                            <ul>
                                <li>
                                    <div class="fondo_blanco">
                                        <div style="padding: 10px;">
                                            <div class="grupos de_2">
                                                <div>
                                                    <div class="grupos de_2">
                                                        <div class="grupos de_2">
                                                            <div class="label_plus_input par">
                                                                <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.Building %>:</span>
                                                                <asp:TextBox
                                                                    grpclsitmopt="10|1|1|0|n"
                                                                    ID="txtSumasAseguradasEdificio"
                                                                    runat="server"
                                                                    Style="text-align: right;"></asp:TextBox>
                                                            </div>
                                                            <div class="fl inspection_radio">
                                                                <div>
                                                                    <asp:RadioButtonList
                                                                        CellPadding="0"
                                                                        CellSpacing="0"
                                                                        CssClass="sumas_aseguradas"
                                                                        DataValueField="Key"
                                                                        DataTextField="Value"
                                                                        ID="rblSumasAseguradasEdificio"
                                                                        RepeatColumns="2"
                                                                        RepeatDirection="Horizontal"
                                                                        RepeatLayout="Table"
                                                                        runat="server"
                                                                        GroupId="10"
                                                                        ClassId="1">
                                                                    </asp:RadioButtonList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="label_plus_input par">
                                                            <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.Detail %>:</span>
                                                            <asp:TextBox
                                                                grpclsitmopt="10|1|4|0|n"
                                                                ID="txtInfraSupraSuguroEdificio"
                                                                runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div>
                                                    <div class="grupos de_2">
                                                        <div class="grupos de_2">
                                                            <div class="label_plus_input par">
                                                                <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.Furniture %>:</span>
                                                                <asp:TextBox
                                                                    grpclsitmopt="10|2|1|0|n"
                                                                    ID="txtSumasAseguradasMobiliarios"
                                                                    runat="server"
                                                                    Style="text-align: right;"></asp:TextBox>
                                                            </div>
                                                            <div class="fl inspection_radio">
                                                                <div>
                                                                    <asp:RadioButtonList
                                                                        CellPadding="0"
                                                                        CellSpacing="0"
                                                                        CssClass="sumas_aseguradas"
                                                                        DataValueField="Key"
                                                                        DataTextField="Value"
                                                                        ID="rblSumasAseguradasMobiliarios"
                                                                        RepeatColumns="2"
                                                                        RepeatDirection="Horizontal"
                                                                        RepeatLayout="Table"
                                                                        runat="server"
                                                                        GroupId="10"
                                                                        ClassId="2">
                                                                    </asp:RadioButtonList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="label_plus_input par">
                                                            <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.Detail %>:</span>
                                                            <asp:TextBox
                                                                grpclsitmopt="10|2|4|0|n"
                                                                ID="txtInfraSupraSeguroMobiliarios"
                                                                runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="grupos de_2">
                                                <div>
                                                    <div class="grupos de_2">
                                                        <div class="grupos de_2">
                                                            <div class="label_plus_input par">
                                                                <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.Machineries %>:</span>
                                                                <asp:TextBox
                                                                    grpclsitmopt="10|3|1|0|n"
                                                                    ID="txtSumasAseguradasMaquinarias"
                                                                    runat="server"
                                                                    Style="text-align: right;"></asp:TextBox>
                                                            </div>
                                                            <div class="fl inspection_radio">
                                                                <div>
                                                                    <asp:RadioButtonList
                                                                        CellPadding="0"
                                                                        CellSpacing="0"
                                                                        CssClass="sumas_aseguradas"
                                                                        DataValueField="Key"
                                                                        DataTextField="Value"
                                                                        ID="rblSumasAseguradasMaquinarias"
                                                                        RepeatColumns="2"
                                                                        RepeatDirection="Horizontal"
                                                                        RepeatLayout="Table"
                                                                        runat="server"
                                                                        GroupId="10"
                                                                        ClassId="3">
                                                                    </asp:RadioButtonList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="label_plus_input par">
                                                            <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.Detail %>:</span>
                                                            <asp:TextBox
                                                                grpclsitmopt="10|3|4|0|n"
                                                                ID="txtInfraSupraSeguroMaquinarias"
                                                                runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div>
                                                    <div class="grupos de_2">
                                                        <div class="grupos de_2">
                                                            <div class="label_plus_input par">
                                                                <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.Existence %>:</span>
                                                                <asp:TextBox
                                                                    grpclsitmopt="10|4|1|0|n"
                                                                    ID="txtSumasAseguradasExistencia"
                                                                    runat="server"
                                                                    Style="text-align: right;"></asp:TextBox>
                                                            </div>
                                                            <div class="fl inspection_radio">
                                                                <div>
                                                                    <asp:RadioButtonList
                                                                        CellPadding="0"
                                                                        CellSpacing="0"
                                                                        CssClass="sumas_aseguradas"
                                                                        DataValueField="Key"
                                                                        DataTextField="Value"
                                                                        ID="rblSumasAseguradasExistencia"
                                                                        RepeatColumns="2"
                                                                        RepeatDirection="Horizontal"
                                                                        RepeatLayout="Table"
                                                                        runat="server"
                                                                        GroupId="10"
                                                                        ClassId="4">
                                                                    </asp:RadioButtonList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="label_plus_input par">
                                                            <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.Detail %>:</span>
                                                            <asp:TextBox
                                                                grpclsitmopt="10|4|4|0|n"
                                                                ID="txtInfoSupraSeguroExistencia"
                                                                runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </li>
                            </ul>
                        </li>
                        <li>
                            <a data-review-group-id="3" href="#item3" class="trigger shown" lnk="lnk">3. <%= RESOURCE.UnderWriting.NewBussiness.Resources.Description.ToUpper() %>
                                <span>
                                    <!--icono-->
                                </span>
                            </a>
                            <ul>
                                <li>
                                    <div class="fondo_blanco">
                                        <div style="padding: 10px;">
                                            <div class="grupos de_2">
                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.TypeOfBuilding %>:</span>
                                                    <div class="fl inspection_radio">
                                                        <div>
                                                            <asp:RadioButtonList
                                                                CellPadding="0"
                                                                CellSpacing="0"
                                                                DataValueField="Key"
                                                                DataTextField="Value"
                                                                ID="rblTipoEdificio"
                                                                RepeatColumns="5"
                                                                RepeatDirection="Horizontal"
                                                                RepeatLayout="Table"
                                                                runat="server"
                                                                GroupId="11"
                                                                ClassId="1">
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.Others %>:</span>
                                                    <asp:TextBox
                                                        grpclsitmopt="11|2|1|0|n"
                                                        ID="txtTipoEdificioOtros"
                                                        runat="server"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="grupos de_2">
                                                <div class="grupos de_3">
                                                    <div class="label_plus_input par">
                                                        <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.TypeOfConstruction %>:</span>
                                                        <%--                                                        <asp:TextBox
                                                            grpclsitmopt="11|3|1|0|n"
                                                            ID="txtTipoConstruccion"
                                                            runat="server"></asp:TextBox>--%>
                                                        <asp:DropDownList
                                                            CssClass="combo_box"
                                                            ID="ddlTipoconstruccion"
                                                            runat="server"
                                                            Style="height: 30px;"
                                                            GroupId="11"
                                                            ClassId="3">
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="fl inspection_radio">
                                                        <div>
                                                            <asp:RadioButtonList
                                                                CellPadding="0"
                                                                CellSpacing="0"
                                                                DataValueField="Key"
                                                                DataTextField="Value"
                                                                ID="rblTipoConstruccionNoSi"
                                                                RepeatColumns="2"
                                                                RepeatDirection="Horizontal"
                                                                RepeatLayout="Table"
                                                                runat="server"
                                                                GroupId="11"
                                                                ClassId="3">
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                    <div class="label_plus_input par">
                                                        <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.EdificationValueLabel %>:</span>
                                                        <asp:TextBox
                                                            grpclsitmopt="11|3|4|0|n"
                                                            ID="txtEfificacionTipoConstruccion"
                                                            runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="grupos de_1">
                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.Furniture %>:</span>
                                                    <asp:TextBox
                                                        grpclsitmopt="11|4|1|0|y"
                                                        ID="txtDescripcionMobiliarios"
                                                        runat="server"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="grupos de_1">
                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.Machineries %>:</span>
                                                    <asp:TextBox
                                                        grpclsitmopt="11|5|1|0|y"
                                                        ID="txtDescripcionMaquinarias"
                                                        runat="server"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="grupos de_1">
                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.Existence %>:</span>
                                                    <asp:TextBox
                                                        grpclsitmopt="11|6|1|0|y"
                                                        ID="txtDescripcionExistencia"
                                                        runat="server"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="grupos de_2">
                                                <div>
                                                    <div class="grupos de_3">
                                                        <div class="label_plus_input par">
                                                            <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.YearOfConstructionOfTheBuilding %>:</span>
                                                            <asp:TextBox
                                                                CssClass="onlyNumbers"
                                                                grpclsitmopt="11|7|1|0|y"
                                                                ID="txtAnoConstruccionEdificio"
                                                                number="number"
                                                                runat="server"
                                                                Style="text-align: right;"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div>
                                                    <div class="grupos de_3">
                                                        <div class="label_plus_input par">
                                                            <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.NumberOfFloors %>:</span>
                                                            <asp:TextBox
                                                                CssClass="onlyNumbers"
                                                                grpclsitmopt="11|8|1|0|y"
                                                                ID="txtCantidadPisos"
                                                                number="number"
                                                                runat="server"
                                                                Style="text-align: right;"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="grupos de_2">
                                                <div>
                                                    <div class="grupos de_3">
                                                        <div class="label_plus_input par">
                                                            <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.M2PerFloor %>:</span>
                                                            <asp:TextBox
                                                                CssClass="onlyNumbers"
                                                                grpclsitmopt="11|9|1|0|y"
                                                                ID="txtM2ConstruccionPorPiso"
                                                                number="number"
                                                                runat="server"
                                                                Style="text-align: right;"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div>
                                                    <div class="grupos de_3">
                                                        <div class="label_plus_input par">
                                                            <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.NumberOfApartmentsOfficesPerFloor %>:</span>
                                                            <asp:TextBox
                                                                CssClass="onlyNumbers"
                                                                grpclsitmopt="11|10|1|0|y"
                                                                ID="txtCantidadAptoOficinaPorPiso"
                                                                number="number"
                                                                runat="server"
                                                                Style="text-align: right;"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="grupos de_2">
                                                <div class="grupos de_3">
                                                    <div class="label_plus_input par">
                                                        <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.M2ForApartmentOffice %>:</span>
                                                        <asp:TextBox
                                                            CssClass="onlyNumbers"
                                                            grpclsitmopt="11|11|1|0|y"
                                                            ID="txtM2ConstruccionPorAptoOficina"
                                                            number="number"
                                                            runat="server"
                                                            Style="text-align: right;"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </li>
                            </ul>
                        </li>
                        <li>
                            <a data-review-group-id="4" href="#item4" class="trigger shown" lnk="lnk">4. <%= RESOURCE.UnderWriting.NewBussiness.Resources.LostHistory.ToUpper() %>
                                <span>
                                    <!--icono-->
                                </span>
                            </a>
                            <ul>
                                <li>
                                    <div class="fondo_blanco">
                                        <div style="padding: 10px;">
                                            <div class="grupos de_3">
                                                <div class="label_plus_input par perdidasSiNo rbl">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.HaveYouHadLosses %></span>
                                                    <div class="fl inspection_radio">
                                                        <div>
                                                            <asp:RadioButtonList
                                                                CellPadding="0"
                                                                CellSpacing="0"
                                                                CssClass="perdidasSiNo"
                                                                DataValueField="Key"
                                                                DataTextField="Value"
                                                                ID="rblHaTenidoPerdidas"
                                                                OnChange="perdidasSiNo()"
                                                                RepeatDirection="Horizontal"
                                                                RepeatLayout="Table"
                                                                runat="server"
                                                                GroupId="12"
                                                                ClassId="1">
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="label_plus_input par perdidasNiveles">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.LossLevel %>:</span>
                                                    <div class="fl inspection_radio">
                                                        <div>
                                                            <asp:RadioButtonList
                                                                CellPadding="0"
                                                                CellSpacing="0"
                                                                CssClass="nivelesPerdidas"
                                                                DataValueField="Key"
                                                                DataTextField="Value"
                                                                ID="rblNivelPerdidas"
                                                                OnChange="chkNinguna()"
                                                                RepeatDirection="Vertical"
                                                                RepeatLayout="UnorderedList"
                                                                runat="server"
                                                                GroupId="12"
                                                                ClassId="2">
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="grupos de_1">
                                                <div class="label_plus_input par perdidasCausa">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.CauseOfLoss %>:</span>
                                                    <div class="fl inspection_radio">
                                                        <div>
                                                            <asp:RadioButtonList
                                                                CellPadding="0"
                                                                CellSpacing="0"
                                                                CssClass="causaPerdidas"
                                                                DataValueField="Key"
                                                                DataTextField="Value"
                                                                ID="rblCausaPerdida"
                                                                RepeatDirection="Vertical"
                                                                RepeatLayout="UnorderedList"
                                                                runat="server"
                                                                GroupId="12"
                                                                ClassId="4">
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="grupos de_1">
                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.Others %>:</span>
                                                    <asp:TextBox
                                                        CssClass="perdidasOtros"
                                                        Enabled="false"
                                                        grpclsitmopt="12|5|1|0|n"
                                                        ID="txtHistorialPerdidaOtros"
                                                        runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </li>
                            </ul>
                        </li>
                        <li>
                            <a data-review-group-id="5" href="#item5" class="trigger shown" lnk="lnk">5. <%= RESOURCE.UnderWriting.NewBussiness.Resources.SinistralityOfTheArea.ToUpper() %>
                                <span>
                                    <!--icono-->
                                </span>
                            </a>
                            <ul>
                                <li>
                                    <div class="fondo_blanco">
                                        <div style="padding: 10px;">
                                            <div class="grupos de_3">
                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.Casualty %>:</span>
                                                    <div class="inspection_radio">
                                                        <div style="padding-top: 5px;">
                                                            <asp:RadioButtonList
                                                                CellPadding="0"
                                                                CellSpacing="0"
                                                                DataValueField="Key"
                                                                DataTextField="Value"
                                                                ID="rblSiniestralidadZona"
                                                                RepeatDirection="Horizontal"
                                                                RepeatLayout="Table"
                                                                runat="server"
                                                                GroupId="13"
                                                                ClassId="1">
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.CommentOnTheOriginOfTheAccident %>:</span>
                                                    <asp:TextBox
                                                        grpclsitmopt="13|2|1|0|n"
                                                        ID="txtComentarOrigenSiniestralidad"
                                                        runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </li>
                            </ul>
                        </li>
                        <li>
                            <a data-review-group-id="6" href="#item6" class="trigger shown" lnk="lnk">6. <%= RESOURCE.UnderWriting.NewBussiness.Resources.Boundary.ToUpper() %>
                                <span>
                                    <!--icono-->
                                </span>
                            </a>
                            <ul>
                                <li>
                                    <div class="fondo_blanco">
                                        <div style="padding: 10px;">
                                            <div class="grupos de_2">
                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.North %>:</span>
                                                    <asp:DropDownList
                                                        CssClass="combo_box colindancias"
                                                        ID="ddlColindanciaNorte"
                                                        runat="server"
                                                        Style="height: 30px;"
                                                        GroupId="14"
                                                        ClassId="1">
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.South %>:</span>
                                                    <asp:DropDownList
                                                        CssClass="combo_box colindancias"
                                                        ID="ddlColindanciaSur"
                                                        runat="server"
                                                        Style="height: 30px;"
                                                        GroupId="14"
                                                        ClassId="2">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="grupos de_2">
                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.East %>:</span>
                                                    <asp:DropDownList
                                                        CssClass="combo_box colindancias"
                                                        ID="ddlColindanciaEste"
                                                        runat="server"
                                                        Style="height: 30px;"
                                                        GroupId="14"
                                                        ClassId="3">
                                                    </asp:DropDownList>
                                                </div>

                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.West %>:</span>
                                                    <asp:DropDownList
                                                        CssClass="combo_box colindancias"
                                                        ID="ddlColindanciaOeste"
                                                        runat="server"
                                                        Style="height: 30px;"
                                                        GroupId="14"
                                                        ClassId="4">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="grupos de_1">
                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.Detail %>:</span>
                                                    <asp:TextBox
                                                        CssClass="perdidasOtros"
                                                        grpclsitmopt="14|5|1|0|n"
                                                        ID="txtDetalleColindancia"
                                                        runat="server"></asp:TextBox>
                                                </div>
                                            </div>

                                        </div>

                                    </div>
                                </li>
                            </ul>
                        </li>
                        <li>
                            <a data-review-group-id="7" href="#item7" class="trigger shown" lnk="lnk">7. <%= RESOURCE.UnderWriting.NewBussiness.Resources.LocationOfRisk.ToUpper() %>
                                <span>
                                    <!--icono-->
                                </span>
                            </a>
                            <ul>
                                <li>
                                    <div class="fondo_blanco">
                                        <div style="padding: 10px;">
                                            <div class="grupos de_2">
                                                <div class="label_plus_input par">
                                                    <asp:Label ID="lblLocalizacionCalle" runat="server" Style="font-size: 13px; padding-top: 3px;"></asp:Label>
                                                    <asp:TextBox
                                                        grpclsitmopt="15|1|1|0|n"
                                                        ID="txtCalle"
                                                        runat="server"></asp:TextBox>
                                                </div>

                                                <div class="label_plus_input par">
                                                    <asp:Label ID="lblLocalizacionSector" runat="server" Style="font-size: 13px; padding-top: 3px;"></asp:Label>
                                                    <asp:TextBox
                                                        grpclsitmopt="15|2|1|0|n"
                                                        ID="txtSectorParajeSeccion"
                                                        runat="server" ClientIDMode="Static"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="grupos de_2">
                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.Town %>:</span>
                                                    <asp:TextBox
                                                        grpclsitmopt="15|3|1|0|n"
                                                        ID="txtMunicipio"
                                                        runat="server" ClientIDMode="Static"></asp:TextBox>
                                                </div>

                                                <div class="label_plus_input par">
                                                    <asp:Label ID="lblLocalizacionProvincia" runat="server" Style="font-size: 13px; padding-top: 3px;"></asp:Label>
                                                    <asp:TextBox
                                                        grpclsitmopt="15|4|1|0|n"
                                                        ID="txtProvincia"
                                                        runat="server" ClientIDMode="Static"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="grupos de_2">
                                                <div class="label_plus_input par">
                                                    <asp:Label ID="lblLocalizacionLongitud" runat="server" Style="font-size: 13px; padding-top: 3px;"></asp:Label>
                                                    <asp:TextBox
                                                        grpclsitmopt="15|5|1|0|n"
                                                        ID="txtLongitud"
                                                        runat="server" ClientIDMode="Static"></asp:TextBox>
                                                </div>

                                                <div class="label_plus_input par">
                                                    <asp:Label ID="lblLatitud" runat="server" Style="font-size: 13px; padding-top: 3px;"></asp:Label>
                                                    <asp:TextBox
                                                        grpclsitmopt="15|6|1|0|n"
                                                        ID="txtLatitud"
                                                        runat="server" ClientIDMode="Static"></asp:TextBox>
                                                </div>
                                                <div class="label_plus_input par">
                                                    <input id="btnGetCurrentLocation" style="display: none; width: 178px !important;" type="button" class="col-12 fl button button-red alignC embossed" value="Obtener localización" />
                                                </div>
                                            </div>
                                            <div>
                                                <div id="dvInputSearch" style="display: none;"></div>
                                                <div id="map" style="height: 368px">
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </li>
                            </ul>
                        </li>
                        <li>
                            <a data-review-group-id="8" href="#item8" class="trigger shown" lnk="lnk">8. <%= RESOURCE.UnderWriting.NewBussiness.Resources.DescriptionOfTheProcesses.ToUpper() %>
                                <span>
                                    <!--icono-->
                                </span>
                            </a>
                            <ul>
                                <li>
                                    <div class="fondo_blanco" style="height: 194px;">
                                        <div style="padding: 10px;">
                                            <div class="grupos de_1">
                                                <asp:TextBox
                                                    grpclsitmopt="16|1|1|0|y"
                                                    ID="txtDescripcionProceso"
                                                    Rows="10"
                                                    runat="server"
                                                    TextMode="MultiLine"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </li>
                            </ul>
                        </li>
                        <li>
                            <a data-review-group-id="9" href="#item9" class="trigger shown" lnk="lnk">9. <%= RESOURCE.UnderWriting.NewBussiness.Resources.DescriptionOfHazards.ToUpper() %>
                                <span>
                                    <!--icono-->
                                </span>
                            </a>
                            <ul>
                                <li>
                                    <div class="fondo_blanco">
                                        <div style="padding: 10px;">
                                            <div class="grupos de_3">
                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.StorageAndUseOfFuels %>:</span>
                                                    <div class="fl inspection_radio">
                                                        <div>
                                                            <asp:RadioButtonList
                                                                CellPadding="0"
                                                                CellSpacing="0"
                                                                DataValueField="Key"
                                                                DataTextField="Value"
                                                                ID="rblAlmacenamientoUsoCombustible"
                                                                RepeatDirection="Horizontal"
                                                                RepeatLayout="Table"
                                                                runat="server"
                                                                GroupId="17"
                                                                ClassId="1">
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.Type %>:</span>
                                                    <div class="fl inspection_radio">
                                                        <div>
                                                            <asp:RadioButtonList
                                                                CellPadding="0"
                                                                CellSpacing="0"
                                                                DataValueField="Key"
                                                                DataTextField="Value"
                                                                ID="rbTipoCombustible"
                                                                RepeatDirection="Horizontal"
                                                                RepeatLayout="Table"
                                                                runat="server"
                                                                GroupId="17"
                                                                ClassId="1">
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.Others %>:</span>
                                                    <asp:TextBox
                                                        grpclsitmopt="17|1|6|0|n"
                                                        ID="txtCombustibleOtros"
                                                        runat="server"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="grupos de_3">
                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.DoesTheBuildingHaveFuelLoad %></span>
                                                    <div class="fl inspection_radio">
                                                        <div>
                                                            <asp:RadioButtonList
                                                                CellPadding="0"
                                                                CellSpacing="0"
                                                                DataValueField="Key"
                                                                DataTextField="Value"
                                                                ID="rblEdificacionCargaCombustible"
                                                                RepeatDirection="Horizontal"
                                                                RepeatLayout="Table"
                                                                runat="server"
                                                                GroupId="17"
                                                                ClassId="2">
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.HowIsIt %></span>
                                                    <div class="fl inspection_radio">
                                                        <div>
                                                            <asp:RadioButtonList
                                                                CellPadding="0"
                                                                CellSpacing="0"
                                                                DataValueField="Key"
                                                                DataTextField="Value"
                                                                ID="rblCargaCombustibleComoEs"
                                                                RepeatDirection="Horizontal"
                                                                RepeatLayout="Table"
                                                                runat="server"
                                                                GroupId="17"
                                                                ClassId="2">
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="grupos de_2">
                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.ElectricalSubstation %>:</span>
                                                    <div class="fl inspection_radio">
                                                        <div>
                                                            <asp:RadioButtonList
                                                                CellPadding="0"
                                                                CellSpacing="0"
                                                                DataValueField="Key"
                                                                DataTextField="Value"
                                                                ID="rblSubastacionElectrica"
                                                                RepeatDirection="Horizontal"
                                                                RepeatLayout="Table"
                                                                runat="server"
                                                                GroupId="17"
                                                                ClassId="3">
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="grupos de_4">
                                                    <div class="label_plus_input par">
                                                        <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.Quantity %>:</span>
                                                        <asp:TextBox
                                                            CssClass="onlyNumbers"
                                                            grpclsitmopt="17|3|3|0|y"
                                                            ID="txtSubastacionElectricaCantidad"
                                                            number="number"
                                                            runat="server"
                                                            Style="text-align: right;"></asp:TextBox>
                                                    </div>
                                                    <div class="label_plus_input par">
                                                        <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.Make %>:</span>
                                                        <asp:TextBox
                                                            grpclsitmopt="17|3|6|0|n"
                                                            ID="txtSubastacionElectricaMarca"
                                                            runat="server"></asp:TextBox>
                                                    </div>
                                                    <div class="label_plus_input par">
                                                        <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.Model %>:</span>
                                                        <asp:TextBox
                                                            grpclsitmopt="17|3|7|0|n"
                                                            ID="txtSubastacionElectricaModelo"
                                                            runat="server"></asp:TextBox>
                                                    </div>
                                                    <div class="label_plus_input par">
                                                        <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.SerialLabel %>:</span>
                                                        <asp:TextBox
                                                            grpclsitmopt="17|3|8|0|n"
                                                            ID="txtSubastacionElectricaSerial"
                                                            runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="grupos de_3">
                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.ElectricGenerators %>:</span>
                                                    <div class="fl inspection_radio">
                                                        <div>
                                                            <asp:RadioButtonList
                                                                CellPadding="0"
                                                                CellSpacing="0"
                                                                DataValueField="Key"
                                                                DataTextField="Value"
                                                                ID="rblGeneradoresElectricos"
                                                                RepeatDirection="Horizontal"
                                                                RepeatLayout="Table"
                                                                runat="server"
                                                                GroupId="17"
                                                                ClassId="4">
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.Quantity %>:</span>
                                                    <asp:TextBox
                                                        CssClass="onlyNumbers"
                                                        grpclsitmopt="17|4|3|0|y"
                                                        ID="txtGeneradoresElectricosCantidad"
                                                        number="number"
                                                        runat="server"
                                                        Style="text-align: right;"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="grupos de_3">
                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.Boilers %>:</span>
                                                    <div class="fl inspection_radio">
                                                        <div>
                                                            <asp:RadioButtonList
                                                                CellPadding="0"
                                                                CellSpacing="0"
                                                                DataValueField="Key"
                                                                DataTextField="Value"
                                                                ID="rblCalderas"
                                                                RepeatDirection="Horizontal"
                                                                RepeatLayout="Table"
                                                                runat="server"
                                                                GroupId="17"
                                                                ClassId="5">
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.Quantity %>:</span>
                                                    <asp:TextBox
                                                        CssClass="onlyNumbers"
                                                        grpclsitmopt="17|5|3|0|y"
                                                        ID="txtCalderasCantidad"
                                                        number="number"
                                                        runat="server"
                                                        Style="text-align: right;"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="grupos de_3">
                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.CompressedAir %>:</span>
                                                    <div class="fl inspection_radio">
                                                        <div>
                                                            <asp:RadioButtonList
                                                                CellPadding="0"
                                                                CellSpacing="0"
                                                                DataValueField="Key"
                                                                DataTextField="Value"
                                                                ID="rblAireComprimido"
                                                                RepeatDirection="Horizontal"
                                                                RepeatLayout="Table"
                                                                runat="server"
                                                                GroupId="17"
                                                                ClassId="6">
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.Quantity %>:</span>
                                                    <asp:TextBox
                                                        CssClass="onlyNumbers"
                                                        grpclsitmopt="17|6|3|0|y"
                                                        ID="txtAireComprimidoCantidad"
                                                        number="number"
                                                        runat="server"
                                                        Style="text-align: right;"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="grupos de_3">
                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.FreeHalls %>:</span>
                                                    <div class="fl inspection_radio">
                                                        <div>
                                                            <asp:RadioButtonList
                                                                CellPadding="0"
                                                                CellSpacing="0"
                                                                DataValueField="Key"
                                                                DataTextField="Value"
                                                                ID="rblPasillosLibres"
                                                                RepeatDirection="Horizontal"
                                                                RepeatLayout="Table"
                                                                runat="server"
                                                                GroupId="17"
                                                                ClassId="7">
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.Comentar %>:</span>
                                                    <asp:TextBox
                                                        grpclsitmopt="17|7|3|0|n"
                                                        ID="txtPasillosLibresComentar"
                                                        runat="server"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="grupos de_3">
                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.FlammableFluids %>:</span>
                                                    <div class="fl inspection_radio">
                                                        <div>
                                                            <asp:RadioButtonList
                                                                CellPadding="0"
                                                                CellSpacing="0"
                                                                DataValueField="Key"
                                                                DataTextField="Value"
                                                                ID="rblFluidosInflamables"
                                                                RepeatDirection="Horizontal"
                                                                RepeatLayout="Table"
                                                                runat="server"
                                                                GroupId="17"
                                                                ClassId="8">
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.Detail %>:</span>
                                                    <asp:TextBox
                                                        grpclsitmopt="17|8|3|0|n"
                                                        ID="txtFluidosInflamablesDetalle"
                                                        runat="server"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="grupos de_3">
                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.OrderCleaningWithinRisk %>:</span>
                                                    <div class="fl inspection_radio">
                                                        <div>
                                                            <asp:RadioButtonList
                                                                CellPadding="0"
                                                                CellSpacing="0"
                                                                DataValueField="Key"
                                                                DataTextField="Value"
                                                                ID="rblOrdenLimpiezaDentroRiesgo"
                                                                RepeatDirection="Horizontal"
                                                                RepeatLayout="Table"
                                                                runat="server"
                                                                GroupId="17"
                                                                ClassId="9">
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.Detail %>:</span>
                                                    <asp:TextBox
                                                        grpclsitmopt="17|9|4|0|n"
                                                        ID="txtOrdenLimpiezaDentroRiesgoComentar"
                                                        runat="server"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="grupos de_3">
                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.OrderCleaningOutOfRisk %>:</span>
                                                    <div class="fl inspection_radio">
                                                        <div>
                                                            <asp:RadioButtonList
                                                                CellPadding="0"
                                                                CellSpacing="0"
                                                                DataValueField="Key"
                                                                DataTextField="Value"
                                                                ID="rblOrdenLimpiezaFueraRiesgo"
                                                                RepeatDirection="Horizontal"
                                                                RepeatLayout="Table"
                                                                runat="server"
                                                                GroupId="17"
                                                                ClassId="10">
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.Detail %>:</span>
                                                    <asp:TextBox
                                                        grpclsitmopt="17|10|4|0|n"
                                                        ID="txtOrdenLimpiezaFueraRiesgoComentar"
                                                        runat="server"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="grupos de_3">
                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.OrderGeneralCleaning %>:</span>
                                                    <div class="fl inspection_radio">
                                                        <div>
                                                            <asp:RadioButtonList
                                                                CellPadding="0"
                                                                CellSpacing="0"
                                                                DataValueField="Key"
                                                                DataTextField="Value"
                                                                ID="rblOrdenLimpiezaGeneral"
                                                                RepeatDirection="Horizontal"
                                                                RepeatLayout="Table"
                                                                runat="server"
                                                                GroupId="17"
                                                                ClassId="11">
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.Detail %>:</span>
                                                    <asp:TextBox
                                                        grpclsitmopt="17|11|4|0|n"
                                                        ID="txtOrdenLimpiezaGeneralComentar"
                                                        runat="server"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="grupos de_3">
                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.ElectricalInstallations %>:</span>
                                                    <div class="fl inspection_radio">
                                                        <div>
                                                            <asp:RadioButtonList
                                                                CellPadding="0"
                                                                CellSpacing="0"
                                                                DataValueField="Key"
                                                                DataTextField="Value"
                                                                ID="rblInstalacionesElectricas"
                                                                RepeatDirection="Horizontal"
                                                                RepeatLayout="Table"
                                                                runat="server"
                                                                GroupId="17"
                                                                ClassId="12">
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.Others2 %>:</span>
                                                    <asp:TextBox
                                                        grpclsitmopt="17|12|4|0|n"
                                                        ID="txtInstalacionesElectricasOtras"
                                                        runat="server"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="grupos de_1">
                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.OtherObservedHazards %>:</span>
                                                    <asp:TextBox
                                                        grpclsitmopt="17|13|1|0|n"
                                                        ID="txtOtrosPeligrosObservados"
                                                        runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </li>
                            </ul>
                        </li>
                        <li>
                            <a data-review-group-id="10" href="#item10" class="trigger shown" lnk="lnk">10. <%= RESOURCE.UnderWriting.NewBussiness.Resources.PreventionProtection.ToUpper() %>
                                <span>
                                    <!--icono-->
                                </span>
                            </a>
                            <ul>
                                <li>
                                    <div class="fondo_blanco">
                                        <div style="padding: 10px;">
                                            <div class="grupos de_3">
                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.FireHoses %>:</span>
                                                    <div class="fl inspection_radio">
                                                        <div>
                                                            <asp:RadioButtonList
                                                                CellPadding="0"
                                                                CellSpacing="0"
                                                                DataValueField="Key"
                                                                DataTextField="Value"
                                                                ID="rblManguerasContraIncendios"
                                                                RepeatDirection="Horizontal"
                                                                RepeatLayout="Table"
                                                                runat="server"
                                                                GroupId="18"
                                                                ClassId="1">
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.NumberOfExtinguishers %>:</span>
                                                    <asp:TextBox
                                                        CssClass="onlyNumbers"
                                                        grpclsitmopt="18|2|1|0|y"
                                                        ID="txtCantidadExtintores"
                                                        number="number"
                                                        runat="server"
                                                        Style="text-align: right;"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="grupos de_3">
                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.EmergencySigns %>:</span>
                                                    <div class="fl inspection_radio">
                                                        <div>
                                                            <asp:RadioButtonList
                                                                CellPadding="0"
                                                                CellSpacing="0"
                                                                DataValueField="Key"
                                                                DataTextField="Value"
                                                                ID="rblSenalesEmergencias"
                                                                RepeatDirection="Horizontal"
                                                                RepeatLayout="Table"
                                                                runat="server"
                                                                GroupId="18"
                                                                ClassId="3">
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.FirePumps %>:</span>
                                                    <div class="fl inspection_radio">
                                                        <div>
                                                            <asp:RadioButtonList
                                                                CellPadding="0"
                                                                CellSpacing="0"
                                                                DataValueField="Key"
                                                                DataTextField="Value"
                                                                ID="rblBombasAaguaContraIncendio"
                                                                RepeatDirection="Horizontal"
                                                                RepeatLayout="Table"
                                                                runat="server"
                                                                GroupId="18"
                                                                ClassId="4">
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.Quantity %>:</span>
                                                    <asp:TextBox
                                                        CssClass="onlyNumbers"
                                                        grpclsitmopt="18|5|1|0|y"
                                                        ID="txtBombasAaguaContraIncendioCantidad"
                                                        number="number"
                                                        runat="server"
                                                        Style="text-align: right;"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="grupos de_3">
                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.LightingRod %>:</span>
                                                    <div class="fl inspection_radio">
                                                        <div>
                                                            <asp:RadioButtonList
                                                                CellPadding="0"
                                                                CellSpacing="0"
                                                                DataValueField="Key"
                                                                DataTextField="Value"
                                                                ID="rblPararrayos"
                                                                RepeatDirection="Horizontal"
                                                                RepeatLayout="Table"
                                                                runat="server"
                                                                GroupId="18"
                                                                ClassId="6">
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.WaterSupplyFirefighter %>:</span>
                                                    <div class="fl inspection_radio">
                                                        <div>
                                                            <asp:RadioButtonList
                                                                CellPadding="0"
                                                                CellSpacing="0"
                                                                DataValueField="Key"
                                                                DataTextField="Value"
                                                                ID="rblTomaAguaBomberos"
                                                                RepeatDirection="Horizontal"
                                                                RepeatLayout="Table"
                                                                runat="server"
                                                                GroupId="18"
                                                                ClassId="7">
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.Quantity %>:</span>
                                                    <asp:TextBox
                                                        CssClass="onlyNumbers"
                                                        grpclsitmopt="18|8|1|0|y"
                                                        ID="txtTomaAguaBomberosCantidad"
                                                        number="number"
                                                        runat="server"
                                                        Style="text-align: right;"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="grupos de_3">
                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.AutomaticSprinklers %>:</span>
                                                    <div class="fl inspection_radio">
                                                        <div>
                                                            <asp:RadioButtonList
                                                                CellPadding="0"
                                                                CellSpacing="0"
                                                                DataValueField="Key"
                                                                DataTextField="Value"
                                                                ID="rblRociadoresAutomaticos"
                                                                RepeatDirection="Horizontal"
                                                                RepeatLayout="Table"
                                                                runat="server"
                                                                GroupId="18"
                                                                ClassId="9">
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.FireBrigade %>:</span>
                                                    <div class="fl inspection_radio">
                                                        <div>
                                                            <asp:RadioButtonList
                                                                CellPadding="0"
                                                                CellSpacing="0"
                                                                DataValueField="Key"
                                                                DataTextField="Value"
                                                                ID="rblBrigadaContraIncendios"
                                                                RepeatDirection="Horizontal"
                                                                RepeatLayout="Table"
                                                                runat="server"
                                                                GroupId="18"
                                                                ClassId="10">
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="label_plus_input par">
                                                    <%--                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.HowMany %></span>
                                                    <asp:TextBox
                                                        CssClass="onlyNumbers"
                                                        grpclsitmopt="18|11|1|0|y"
                                                        ID="txtBrigadaContraIncendiosCuantas"
                                                        number="number"
                                                        runat="server"
                                                        Style="text-align: right;"></asp:TextBox>--%>
                                                </div>
                                            </div>

                                            <div class="grupos de_3">
                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.EmergencyStairs %>:</span>
                                                    <div class="fl inspection_radio">
                                                        <div>
                                                            <asp:RadioButtonList
                                                                CellPadding="0"
                                                                CellSpacing="0"
                                                                DataValueField="Key"
                                                                DataTextField="Value"
                                                                ID="rblEscalerasEmergencias"
                                                                RepeatDirection="Horizontal"
                                                                RepeatLayout="Table"
                                                                runat="server"
                                                                GroupId="18"
                                                                ClassId="12">
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.FireSystem %>:</span>
                                                    <div class="fl inspection_radio">
                                                        <div>
                                                            <asp:RadioButtonList
                                                                CellPadding="0"
                                                                CellSpacing="0"
                                                                DataValueField="Key"
                                                                DataTextField="Value"
                                                                ID="rblSistemaContraIncendio"
                                                                RepeatDirection="Horizontal"
                                                                RepeatLayout="Table"
                                                                runat="server"
                                                                GroupId="18"
                                                                ClassId="13">
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.Type %>:</span>
                                                    <asp:TextBox
                                                        grpclsitmopt="18|14|1|0|y"
                                                        ID="txtSistemaContraIncendioTipo"
                                                        runat="server"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="grupos de_3">
                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.RollingDoors %>:</span>
                                                    <div class="fl inspection_radio">
                                                        <div>
                                                            <asp:RadioButtonList
                                                                CellPadding="0"
                                                                CellSpacing="0"
                                                                DataValueField="Key"
                                                                DataTextField="Value"
                                                                ID="rblPuertasEnrollables"
                                                                RepeatDirection="Horizontal"
                                                                RepeatLayout="Table"
                                                                runat="server"
                                                                GroupId="18"
                                                                ClassId="15">
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.AlarmSystem %>:</span>
                                                    <div class="fl inspection_radio">
                                                        <div>
                                                            <asp:RadioButtonList
                                                                CellPadding="0"
                                                                CellSpacing="0"
                                                                DataValueField="Key"
                                                                DataTextField="Value"
                                                                ID="rblSistemaAlarma"
                                                                RepeatDirection="Horizontal"
                                                                RepeatLayout="Table"
                                                                runat="server"
                                                                GroupId="18"
                                                                ClassId="16">
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.Type %>:</span>
                                                    <asp:TextBox
                                                        grpclsitmopt="18|17|1|0|y"
                                                        ID="txtSistemaAlarmaTipo"
                                                        runat="server"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="grupos de_2">
                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.CCTVMonitoringService %>:</span>
                                                    <div class="fl inspection_radio">
                                                        <div>
                                                            <asp:RadioButtonList
                                                                CellPadding="0"
                                                                CellSpacing="0"
                                                                DataValueField="Key"
                                                                DataTextField="Value"
                                                                ID="rblServicioMonitoreoCCTV"
                                                                RepeatDirection="Horizontal"
                                                                RepeatLayout="Table"
                                                                runat="server"
                                                                GroupId="18"
                                                                ClassId="18">
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.Quantity %>:</span>
                                                    <asp:TextBox
                                                        CssClass="onlyNumbers"
                                                        grpclsitmopt="18|19|1|0|y"
                                                        ID="txtServicioMonitoreoCCTVCantidad"
                                                        runat="server"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="grupos de_2">
                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.SecurityBox %>:</span>
                                                    <div class="fl inspection_radio">
                                                        <div>
                                                            <asp:RadioButtonList
                                                                CellPadding="0"
                                                                CellSpacing="0"
                                                                DataValueField="Key"
                                                                DataTextField="Value"
                                                                ID="rblCajaSeguridad"
                                                                RepeatDirection="Horizontal"
                                                                RepeatLayout="Table"
                                                                runat="server"
                                                                GroupId="18"
                                                                ClassId="20">
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.TypeAndSize %>:</span>
                                                    <asp:TextBox
                                                        grpclsitmopt="18|21|1|0|y"
                                                        ID="txtCajaSeguridadTipoTamano"
                                                        runat="server"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="grupos de_2">
                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.WindowsDoorsGrills %>:</span>
                                                    <div class="fl inspection_radio">
                                                        <div>
                                                            <asp:RadioButtonList
                                                                CellPadding="0"
                                                                CellSpacing="0"
                                                                DataValueField="Key"
                                                                DataTextField="Value"
                                                                ID="rblRejasVentanasPuertas"
                                                                RepeatDirection="Horizontal"
                                                                RepeatLayout="Table"
                                                                runat="server"
                                                                GroupId="18"
                                                                ClassId="22">
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.WindowsType %>:</span>
                                                    <asp:TextBox
                                                        grpclsitmopt="18|23|1|0|y"
                                                        ID="txtRejasVentanasPuertasTipoVentanas"
                                                        runat="server"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="grupos de_2">
                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.PushButtons %>:</span>
                                                    <div class="fl inspection_radio">
                                                        <div>
                                                            <asp:RadioButtonList
                                                                CellPadding="0"
                                                                CellSpacing="0"
                                                                DataValueField="Key"
                                                                DataTextField="Value"
                                                                ID="rblPulsadoresManuales"
                                                                RepeatDirection="Horizontal"
                                                                RepeatLayout="Table"
                                                                runat="server"
                                                                GroupId="18"
                                                                ClassId="24">
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.Comentar %>:</span>
                                                    <asp:TextBox
                                                        grpclsitmopt="18|25|1|0|n"
                                                        ID="txtrblPulsadoresManualesComentar"
                                                        runat="server"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="grupos de_3">
                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.PreventiveMaintenance %>:</span>
                                                    <div class="fl inspection_radio">
                                                        <div>
                                                            <asp:RadioButtonList
                                                                CellPadding="0"
                                                                CellSpacing="0"
                                                                DataValueField="Key"
                                                                DataTextField="Value"
                                                                ID="rblMantenimientoPreventivo"
                                                                RepeatDirection="Horizontal"
                                                                RepeatLayout="Table"
                                                                runat="server"
                                                                GroupId="18"
                                                                ClassId="26">
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="grupos de_3">
                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.Storage %>:</span>
                                                    <div class="fl inspection_radio">
                                                        <div>
                                                            <asp:RadioButtonList
                                                                CellPadding="0"
                                                                CellSpacing="0"
                                                                DataValueField="Key"
                                                                DataTextField="Value"
                                                                ID="rblAlmacenamiento"
                                                                RepeatDirection="Horizontal"
                                                                RepeatLayout="Table"
                                                                runat="server"
                                                                GroupId="18"
                                                                ClassId="27">
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.Quality %>:</span>
                                                    <div class="fl inspection_radio">
                                                        <div>
                                                            <asp:RadioButtonList
                                                                CellPadding="0"
                                                                CellSpacing="0"
                                                                DataValueField="Key"
                                                                DataTextField="Value"
                                                                ID="rblAlmacenamientoBRM"
                                                                RepeatDirection="Horizontal"
                                                                RepeatLayout="Table"
                                                                runat="server"
                                                                GroupId="18"
                                                                ClassId="28">
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="grupos de_2">
                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.ElectricalPowerSupply %>:</span>
                                                    <div class="fl inspection_radio">
                                                        <div>
                                                            <asp:RadioButtonList
                                                                CellPadding="0"
                                                                CellSpacing="0"
                                                                DataValueField="Key"
                                                                DataTextField="Value"
                                                                ID="rblAlimentacionElectrica"
                                                                RepeatDirection="Horizontal"
                                                                RepeatLayout="Table"
                                                                runat="server"
                                                                GroupId="18"
                                                                ClassId="29">
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="grupos de_2">
                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.TypeWaterSupply %>:</span>
                                                    <div class="fl inspection_radio">
                                                        <div>
                                                            <asp:RadioButtonList
                                                                CellPadding="0"
                                                                CellSpacing="0"
                                                                DataValueField="Key"
                                                                DataTextField="Value"
                                                                ID="rblTipoSuministroAgua"
                                                                RepeatDirection="Horizontal"
                                                                RepeatLayout="Table"
                                                                runat="server"
                                                                GroupId="18"
                                                                ClassId="30">
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.Others %>:</span>
                                                    <asp:TextBox
                                                        grpclsitmopt="18|31|1|0|n"
                                                        ID="txtTipoSuministroAguaOtros"
                                                        runat="server"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="grupos de_2">
                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.TypeWaterStorage %>:</span>
                                                    <div class="fl inspection_radio">
                                                        <div>
                                                            <asp:RadioButtonList
                                                                CellPadding="0"
                                                                CellSpacing="0"
                                                                DataValueField="Key"
                                                                DataTextField="Value"
                                                                ID="rblTipoAlmacenamientoAgua"
                                                                RepeatDirection="Horizontal"
                                                                RepeatLayout="Table"
                                                                runat="server"
                                                                GroupId="18"
                                                                ClassId="32">
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.AmountGallons %>:</span>
                                                    <asp:TextBox
                                                        CssClass="onlyNumbers"
                                                        grpclsitmopt="18|33|1|0|y"
                                                        ID="txtTipoAlmacenamientoAguaCantidadGalones"
                                                        number="number"
                                                        runat="server"
                                                        Style="text-align: right;"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="grupos de_3">
                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.Watchers %>:</span>
                                                    <div class="fl inspection_radio">
                                                        <div>
                                                            <asp:RadioButtonList
                                                                CellPadding="0"
                                                                CellSpacing="0"
                                                                DataValueField="Key"
                                                                DataTextField="Value"
                                                                ID="rblVigilantes"
                                                                RepeatDirection="Horizontal"
                                                                RepeatLayout="Table"
                                                                runat="server"
                                                                GroupId="18"
                                                                ClassId="34">
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.Quantity %>:</span>
                                                    <asp:TextBox
                                                        CssClass="onlyNumbers"
                                                        grpclsitmopt="18|35|1|0|y"
                                                        ID="txtVigilantesCantidad"
                                                        number="number"
                                                        runat="server"
                                                        Style="text-align: right;"></asp:TextBox>
                                                </div>

                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.Horary %>:</span>
                                                    <asp:TextBox
                                                        grpclsitmopt="18|36|1|0|y"
                                                        ID="txtVigilantesHorario"
                                                        runat="server"></asp:TextBox>
                                                </div>
                                            </div>

                                            <asp:Panel ID="pnlDO" runat="server" Visible="false">
                                                <div class="grupos de_2">
                                                    <div class="label_plus_input par">
                                                        <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.DistanceFromTheSea %>:</span>
                                                        <div class="fl inspection_radio">
                                                            <div>
                                                                <asp:RadioButtonList
                                                                    CellPadding="0"
                                                                    CellSpacing="0"
                                                                    DataValueField="Key"
                                                                    DataTextField="Value"
                                                                    ID="rblDistanciaMar"
                                                                    RepeatDirection="Horizontal"
                                                                    RepeatLayout="Table"
                                                                    runat="server"
                                                                    GroupId="18"
                                                                    ClassId="37">
                                                                </asp:RadioButtonList>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="label_plus_input par">
                                                        <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.Detail %>:</span>
                                                        <asp:TextBox
                                                            grpclsitmopt="18|38|1|0|y"
                                                            ID="txtDistanciaMarDetallar"
                                                            runat="server"></asp:TextBox>
                                                    </div>
                                                </div>

                                                <div class="grupos de_2">
                                                    <div class="label_plus_input par">
                                                        <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.DistanceFromOtherSourcesOfWater %>:</span>
                                                        <div class="fl inspection_radio">
                                                            <div>
                                                                <asp:RadioButtonList
                                                                    CellPadding="0"
                                                                    CellSpacing="0"
                                                                    DataValueField="Key"
                                                                    DataTextField="Value"
                                                                    ID="rblDistanciaOtrasFuentesAgua"
                                                                    RepeatDirection="Horizontal"
                                                                    RepeatLayout="Table"
                                                                    runat="server"
                                                                    GroupId="18"
                                                                    ClassId="39">
                                                                </asp:RadioButtonList>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="label_plus_input par">
                                                        <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.Detail %>:</span>
                                                        <asp:TextBox
                                                            grpclsitmopt="18|40|1|0|y"
                                                            ID="txtDistanciaOtrasFuentesAguaDetallar"
                                                            runat="server"></asp:TextBox>
                                                    </div>
                                                </div>

                                                <div class="grupos de_3">
                                                    <div class="label_plus_input par">
                                                        <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.FireDistance %>:</span>
                                                        <div class="fl inspection_radio">
                                                            <div>
                                                                <asp:RadioButtonList
                                                                    CellPadding="0"
                                                                    CellSpacing="0"
                                                                    DataValueField="Key"
                                                                    DataTextField="Value"
                                                                    ID="rblDistanciaBomberos"
                                                                    RepeatDirection="Horizontal"
                                                                    RepeatLayout="Table"
                                                                    runat="server"
                                                                    GroupId="18"
                                                                    ClassId="41">
                                                                </asp:RadioButtonList>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="label_plus_input par">
                                                        <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.DistanceFromPN %>:</span>
                                                        <div class="fl inspection_radio">
                                                            <div>
                                                                <asp:RadioButtonList
                                                                    CellPadding="0"
                                                                    CellSpacing="0"
                                                                    DataValueField="Key"
                                                                    DataTextField="Value"
                                                                    ID="rblDistanciaPN"
                                                                    RepeatDirection="Horizontal"
                                                                    RepeatLayout="Table"
                                                                    runat="server"
                                                                    GroupId="18"
                                                                    ClassId="42">
                                                                </asp:RadioButtonList>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </asp:Panel>

                                            <asp:Panel ID="pnlSV" runat="server" Visible="false">
                                                <div class="grupos de_2">
                                                    <div class="label_plus_input par">
                                                        <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.DistanceToRiversLakesOrSeas %>:</span>
                                                        <asp:TextBox
                                                            Enabled="false"
                                                            grpclsitmopt="0|0|0|0|n"
                                                            ID="txtPrevencionProteccionDistanciaRiosLagosMares"
                                                            runat="server"></asp:TextBox>
                                                    </div>

                                                    <div class="label_plus_input par">
                                                        <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.Detail %>:</span>
                                                        <asp:TextBox
                                                            grpclsitmopt="18|43|1|0|y"
                                                            ID="txtPrevencionProteccionDistanciaRiosLagosMaresDetallar"
                                                            runat="server"></asp:TextBox>
                                                    </div>
                                                </div>

                                                <div class="grupos de_2">
                                                    <div class="label_plus_input par">
                                                        <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.DistanceFromVolcanoes %>:</span>
                                                        <asp:TextBox
                                                            Enabled="false"
                                                            grpclsitmopt="0|0|0|0|n"
                                                            ID="txtPrevencionProteccionDistanciaVolcanes"
                                                            runat="server"></asp:TextBox>
                                                    </div>

                                                    <div class="label_plus_input par">
                                                        <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.Detail %>:</span>
                                                        <asp:TextBox
                                                            grpclsitmopt="18|44|1|0|y"
                                                            ID="txtPrevencionProteccionDistanciaVolcanesDetallar"
                                                            runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </asp:Panel>
                                        </div>
                                    </div>
                                </li>
                            </ul>
                        </li>
                        <li>
                            <a data-review-group-id="11" href="#item11" class="trigger shown" lnk="lnk">11. <%= RESOURCE.UnderWriting.NewBussiness.Resources.EstimatedLossesFireCoverage.ToUpper() %>
                                <span>
                                    <!--icono-->
                                </span>
                            </a>
                            <ul>
                                <li>
                                    <div class="fondo_blanco">
                                        <div style="padding: 10px;">
                                            <div class="grupos de_1">
                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.MaximumPossibleLoss %> (MPL):</span>
                                                    <asp:TextBox
                                                        CssClass="onlyNumbers"
                                                        grpclsitmopt="19|1|1|0|y"
                                                        ID="txtPerdidaMaximaPosible"
                                                        number="number"
                                                        runat="server"
                                                        Style="text-align: right;"></asp:TextBox>
                                                </div>
                                                <div>
                                                    <%= RESOURCE.UnderWriting.NewBussiness.Resources.EstimationOfLossesForFireCoverageMPL %>
                                                </div>
                                            </div>
                                            <div class="grupos de_1">
                                                <br />
                                            </div>
                                            <div class="grupos de_1">
                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.EstimatedMaximumLoss %> (EML):</span>
                                                    <asp:TextBox
                                                        CssClass="onlyNumbers"
                                                        grpclsitmopt="19|2|1|0|y"
                                                        ID="txtPerdidaMaximaEstimada"
                                                        number="number"
                                                        runat="server"
                                                        Style="text-align: right;"></asp:TextBox>
                                                </div>
                                                <div>
                                                    <%= RESOURCE.UnderWriting.NewBussiness.Resources.EstimationOfLossesForFireCoverageEML %>
                                                </div>
                                            </div>
                                            <div class="grupos de_1">
                                                <br />
                                            </div>
                                        </div>
                                    </div>
                                </li>
                            </ul>
                        </li>
                        <li>
                            <a data-review-group-id="12" href="#item12" class="trigger shown" lnk="lnk">12. <%= RESOURCE.UnderWriting.NewBussiness.Resources.ExposureToRisks.ToUpper() %>
                                <span>
                                    <!--icono-->
                                </span>
                            </a>
                            <ul>
                                <li>
                                    <div class="fondo_blanco">
                                        <div style="padding: 10px;">
                                            <table style="border-collapse: collapse; border: none; font-size: 13pt;">
                                                <tr>
                                                    <td style="padding: 0in 5.4pt 0in 5.4pt; height: 35px; width: 18%;">
                                                        <p style="margin-bottom: 0in; margin-bottom: .0001pt; line-height: normal;">&nbsp;</p>
                                                    </td>
                                                    <td colspan="3" style="padding: 0in 5.4pt 0in 5.4pt">
                                                        <p style="margin-bottom: 0in; margin-bottom: .0001pt; text-align: center; line-height: normal; font-weight: bold;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.LossEstimate.ToUpper() %></p>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 0in 5.4pt 0in 5.4pt; height: 35px; width: 18%;">
                                                        <p style="margin-bottom: 0in; margin-bottom: .0001pt; text-align: center; line-height: normal; font-weight: bold;">
                                                            <br />
                                                            <br />
                                                            <%= RESOURCE.UnderWriting.NewBussiness.Resources.Risks.ToUpper() %>
                                                        </p>
                                                    </td>
                                                    <td style="padding: 0in 5.4pt 0in 5.4pt; width: 28%;">
                                                        <p style="margin-bottom: 0in; margin-bottom: .0001pt; text-align: center; line-height: normal; font-weight: bold;">
                                                            <br />
                                                            <br />
                                                            <%= RESOURCE.UnderWriting.NewBussiness.Resources.Exposition %>
                                                        </p>
                                                    </td>
                                                    <td style="padding: 0in 5.4pt 0in 5.4pt;">
                                                        <p style="margin-bottom: 0in; margin-bottom: .0001pt; text-align: center; line-height: normal; font-weight: bold;">
                                                            <%= RESOURCE.UnderWriting.NewBussiness.Resources.MaximumPossibleLoss %> (MPL)
                                                        </p>
                                                    </td>
                                                    <td style="padding: 0in 5.4pt 0in 5.4pt;">
                                                        <p style="margin-bottom: 0in; margin-bottom: .0001pt; text-align: center; line-height: normal; font-weight: bold;">
                                                            <%= RESOURCE.UnderWriting.NewBussiness.Resources.EstimatedMaximumLoss %> (EML)
                                                        </p>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="label_plus_input par" style="height: 40px;">
                                                        <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.FireLightningExplosion %>:</span>
                                                    </td>
                                                    <td style="padding: 0in 5.4pt 0in 5.4pt;">
                                                        <asp:TextBox
                                                            CssClass="onlyNumbers"
                                                            grpclsitmopt="20|1|1|0|y"
                                                            ID="txtIncendioRayoExplosionExposicion"
                                                            number="number"
                                                            runat="server"
                                                            Style="text-align: right;"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 0in 5.4pt 0in 5.4pt;">
                                                        <asp:TextBox
                                                            CssClass="onlyNumbers"
                                                            grpclsitmopt="20|2|1|0|y"
                                                            ID="txtIncendioRayoExplosionMPL"
                                                            number="number"
                                                            runat="server"
                                                            Style="text-align: right;"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 0in 5.4pt 0in 5.4pt;">
                                                        <asp:TextBox
                                                            CssClass="onlyNumbers"
                                                            grpclsitmopt="20|3|1|0|y"
                                                            ID="txtIncendioRayoExplosionEML"
                                                            number="number"
                                                            runat="server"
                                                            Style="text-align: right;"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="label_plus_input par" style="height: 40px;">
                                                        <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.HurricaneNearTheSea %>:</span>
                                                    </td>
                                                    <td style="padding: 0in 5.4pt 0in 5.4pt;">
                                                        <asp:TextBox
                                                            CssClass="onlyNumbers"
                                                            grpclsitmopt="20|4|1|0|y"
                                                            ID="txtHuracanRasMarExposicion"
                                                            number="number"
                                                            runat="server"
                                                            Style="text-align: right;"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 0in 5.4pt 0in 5.4pt;">
                                                        <asp:TextBox
                                                            CssClass="onlyNumbers"
                                                            grpclsitmopt="20|5|1|0|y"
                                                            ID="txtHuracanRasMarMPL"
                                                            number="number"
                                                            runat="server"
                                                            Style="text-align: right;"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 0in 5.4pt 0in 5.4pt;">
                                                        <asp:TextBox
                                                            CssClass="onlyNumbers"
                                                            grpclsitmopt="20|6|1|0|y"
                                                            ID="txtHuracanRasMarEML"
                                                            number="number"
                                                            runat="server"
                                                            Style="text-align: right;"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="label_plus_input par" style="height: 40px;">
                                                        <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.Flood %>:</span>
                                                    </td>
                                                    <td style="padding: 0in 5.4pt 0in 5.4pt;">
                                                        <asp:TextBox
                                                            CssClass="onlyNumbers"
                                                            grpclsitmopt="20|7|1|0|y"
                                                            ID="txtInundacionExposicion"
                                                            number="number"
                                                            runat="server"
                                                            Style="text-align: right;"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 0in 5.4pt 0in 5.4pt;">
                                                        <asp:TextBox
                                                            CssClass="onlyNumbers"
                                                            grpclsitmopt="20|8|1|0|y"
                                                            ID="txtInundacionMPL"
                                                            number="number"
                                                            runat="server"
                                                            Style="text-align: right;"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 0in 5.4pt 0in 5.4pt;">
                                                        <asp:TextBox
                                                            CssClass="onlyNumbers"
                                                            grpclsitmopt="20|9|1|0|y"
                                                            ID="txtInundacionEML"
                                                            number="number"
                                                            runat="server"
                                                            Style="text-align: right;"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="label_plus_input par" style="height: 40px;">
                                                        <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.Earthquake %>:</span>
                                                    </td>
                                                    <td style="padding: 0in 5.4pt 0in 5.4pt;">
                                                        <asp:TextBox
                                                            CssClass="onlyNumbers"
                                                            grpclsitmopt="20|10|1|0|y"
                                                            ID="txtTerremotoTemblorTierraExposicion"
                                                            number="number"
                                                            runat="server"
                                                            Style="text-align: right;"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 0in 5.4pt 0in 5.4pt;">
                                                        <asp:TextBox
                                                            CssClass="onlyNumbers"
                                                            grpclsitmopt="20|11|1|0|y"
                                                            ID="txtTerremotoTemblorTierraMPL"
                                                            number="number"
                                                            runat="server"
                                                            Style="text-align: right;"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 0in 5.4pt 0in 5.4pt;">
                                                        <asp:TextBox
                                                            CssClass="onlyNumbers"
                                                            grpclsitmopt="20|12|1|0|y"
                                                            ID="txtTerremotoTemblorTierraEML"
                                                            number="number"
                                                            runat="server"
                                                            Style="text-align: right;"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="label_plus_input par" style="height: 40px;">
                                                        <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.Stole %>:</span>
                                                    </td>
                                                    <td style="padding: 0in 5.4pt 0in 5.4pt;">
                                                        <asp:TextBox
                                                            CssClass="onlyNumbers"
                                                            grpclsitmopt="20|13|1|0|y"
                                                            ID="txtRoboExposicion"
                                                            number="number"
                                                            runat="server"
                                                            Style="text-align: right;"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 0in 5.4pt 0in 5.4pt;">
                                                        <asp:TextBox
                                                            CssClass="onlyNumbers"
                                                            grpclsitmopt="20|14|1|0|y"
                                                            ID="txtRoboMPL"
                                                            number="number"
                                                            runat="server"
                                                            Style="text-align: right;"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 0in 5.4pt 0in 5.4pt;">
                                                        <asp:TextBox
                                                            CssClass="onlyNumbers"
                                                            grpclsitmopt="20|15|1|0|y"
                                                            ID="txtRoboEML"
                                                            number="number"
                                                            runat="server"
                                                            Style="text-align: right;"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="label_plus_input par" style="height: 40px;">
                                                        <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.AssaultRobbery %>:</span>
                                                    </td>
                                                    <td style="padding: 0in 5.4pt 0in 5.4pt;">
                                                        <asp:TextBox
                                                            CssClass="onlyNumbers"
                                                            grpclsitmopt="20|16|1|0|y"
                                                            ID="txtAsaltoAtracoExposicion"
                                                            number="number"
                                                            runat="server"
                                                            Style="text-align: right;"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 0in 5.4pt 0in 5.4pt;">
                                                        <asp:TextBox
                                                            CssClass="onlyNumbers"
                                                            grpclsitmopt="20|17|1|0|y"
                                                            ID="txtAsaltoAtracoMPL"
                                                            number="number"
                                                            runat="server"
                                                            Style="text-align: right;"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 0in 5.4pt 0in 5.4pt;">
                                                        <asp:TextBox
                                                            CssClass="onlyNumbers"
                                                            grpclsitmopt="20|18|1|0|y"
                                                            ID="txtAsaltoAtracoEML"
                                                            number="number"
                                                            runat="server"
                                                            Style="text-align: right;"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </li>
                            </ul>
                        </li>
                        <li>
                            <a data-review-group-id="13" href="#item13" class="trigger shown" lnk="lnk">13. <%= RESOURCE.UnderWriting.NewBussiness.Resources.RiskCategory.ToUpper() %>
                                <span>
                                    <!--icono-->
                                </span>
                            </a>
                            <ul>
                                <li>
                                    <div class="fondo_blanco">
                                        <div style="padding: 10px;">
                                            <div class="grupos de_1">
                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.Category %>:</span>
                                                    <div class="fl inspection_radio">
                                                        <div>
                                                            <asp:RadioButtonList
                                                                CellPadding="0"
                                                                CellSpacing="0"
                                                                DataValueField="Key"
                                                                DataTextField="Value"
                                                                ID="rblCategoriaRiesgo"
                                                                RepeatDirection="Horizontal"
                                                                RepeatLayout="Table"
                                                                runat="server"
                                                                GroupId="21"
                                                                ClassId="1">
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </li>
                            </ul>
                        </li>
                        <li>
                            <a data-review-group-id="14" href="#item14" class="trigger shown" lnk="lnk">14. <%= RESOURCE.UnderWriting.NewBussiness.Resources.RiskOpinion.ToUpper() %>
                                <span>
                                    <!--icono-->
                                </span>
                            </a>
                            <ul>
                                <li>
                                    <div class="fondo_blanco" style="height: 194px;">
                                        <div style="padding: 10px;">
                                            <div class="grupos de_1">
                                                <asp:TextBox
                                                    grpclsitmopt="22|1|1|0|y"
                                                    ID="txtOpinionRiesgo"
                                                    Rows="10"
                                                    runat="server"
                                                    TextMode="MultiLine"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </li>
                            </ul>
                        </li>
                        <li>
                            <a data-review-group-id="15" href="#item15" class="trigger shown" lnk="lnk">15. <%= RESOURCE.UnderWriting.NewBussiness.Resources.TechnicalRecommendations.ToUpper() %>
                                <span>
                                    <!--icono-->
                                </span>
                            </a>
                            <ul>
                                <li>
                                    <div class="fondo_blanco" style="height: 194px;">
                                        <div style="padding: 10px;">
                                            <div class="grupos de_1">
                                                <asp:TextBox
                                                    grpclsitmopt="23|1|1|0|y"
                                                    ID="txtRecomendacionesTecnicas"
                                                    Rows="10"
                                                    runat="server"
                                                    TextMode="MultiLine"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </li>
                            </ul>
                        </li>
                        <li>
                            <a data-review-group-id="16" href="#item16" class="trigger shown" lnk="lnk">16. <%= RESOURCE.UnderWriting.NewBussiness.Resources.RecommendationsMadeSentInsured.ToUpper() %>
                                <span>
                                    <!--icono-->
                                </span>
                            </a>
                            <ul>
                                <li>
                                    <div class="fondo_blanco" style="height: 194px;">
                                        <div style="padding: 10px;">
                                            <div class="grupos de_1">
                                                <asp:TextBox
                                                    grpclsitmopt="24|1|1|0|y"
                                                    ID="txtRecomendacionesHechasEnviadasAsegurado"
                                                    Rows="10"
                                                    runat="server"
                                                    TextMode="MultiLine"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </li>
                            </ul>
                        </li>
                        <li>
                            <a data-review-group-id="17" href="#item17" class="trigger shown" lnk="lnk">17. <%= RESOURCE.UnderWriting.NewBussiness.Resources.Pictures.ToUpper() %>
                                <span>
                                    <!--icono-->
                                </span>
                            </a>
                            <ul>
                                <li>
                                    <div class="fondo_blanco">
                                        <div style="padding: 10px;">
                                            <div class="grupos de_3">
                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.Type %>:</span>
                                                    <div class="fl inspection_radio">
                                                        <div>
                                                            <asp:RadioButtonList
                                                                AutoPostBack="true"
                                                                CellPadding="0"
                                                                CellSpacing="0"
                                                                DataTextField="Value"
                                                                DataValueField="Key"
                                                                ID="rblTipoFoto"
                                                                OnSelectedIndexChanged="rblTipoFoto_SelectedIndexChanged"
                                                                RepeatDirection="Horizontal"
                                                                RepeatLayout="Table"
                                                                runat="server">
                                                            </asp:RadioButtonList>

                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="label_plus_input par">
                                                    <span style="font-size: 13px; padding-top: 3px;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.Category %>:</span>
                                                    <asp:DropDownList
                                                        AutoPostBack="true"
                                                        CssClass="combo_box categoria_foto"
                                                        DataTextField="Value"
                                                        DataValueField="Key"
                                                        Enabled="false"
                                                        ID="ddlCategoriaFoto"
                                                        OnSelectedIndexChanged="ddlCategoriaFoto_SelectedIndexChanged"
                                                        runat="server"
                                                        Style="height: 30px;">
                                                    </asp:DropDownList>
                                                </div>
                                                <div>
                                                    <div class="grupos de_2">
                                                        <div style="text-align: center;">
                                                            <input
                                                                class="button button-blue alignC embossed btn-file selectPhoto"
                                                                disabled="disabled"
                                                                onclick="fileUpload();"
                                                                style="font-size: 10pt;"
                                                                type="button"
                                                                value='<%= String.Format("{0} {1}", RESOURCE.UnderWriting.NewBussiness.Resources.Select, RESOURCE.UnderWriting.NewBussiness.Resources.Photos)%>' />
                                                        </div>
                                                        <div>
                                                            <asp:Label
                                                                ClientIDMode="Static"
                                                                CssClass="errmsgvif"
                                                                Font-Bold="true"
                                                                Font-Size="12px"
                                                                ID="lblMessages"
                                                                runat="server"
                                                                Style="color: red;"></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="grupos de_1">
                                                <div class="tbl data_Gpl gvPictures">
                                                    <dx:ASPxGridView
                                                        ID="gvPictures"
                                                        runat="server"
                                                        KeyFieldName="DocCategoryId;DocTypeId;DocumentDesc;DocumentId;DocumentName"
                                                        EnableCallBacks="False"
                                                        Width="100%"
                                                        AutoGenerateColumns="False"
                                                        OnRowCommand="gvPictures_RowCommand"
                                                        OnAfterPerformCallback="gvPictures_AfterPerformCallback"
                                                        OnBeforeHeaderFilterFillItems="gvPictures_BeforeHeaderFilterFillItems"
                                                        OnPreRender="gvPictures_PreRender"
                                                        OnPageIndexChanged="gvPictures_PageIndexChanged">
                                                        <Columns>
                                                            <dx:GridViewDataTextColumn FieldName="DocumentDesc" Name="Tipo" Caption="TIPO" VisibleIndex="1">
                                                                <%-- <Settings AllowHeaderFilter="True" AllowSort="True" AutoFilterCondition="Contains" />--%>
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="DocumentName" Name="Categoría" Caption="CATEGORIA" VisibleIndex="2">
                                                                <%-- <Settings AllowHeaderFilter="True" AllowSort="True" AutoFilterCondition="Contains" />--%>
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataBinaryImageColumn FieldName="DocumentBinary" Name="DocumentBinary" Caption="FOTO" CellStyle-HorizontalAlign="Center" VisibleIndex="3" Width="10%">
                                                                <PropertiesBinaryImage ImageHeight="100px" ImageWidth="150px" ImageSizeMode="FitProportional" EnableServerResize="false" />
                                                            </dx:GridViewDataBinaryImageColumn>
                                                            <dx:GridViewDataColumn Name="Delete" Caption="ELIMINAR" CellStyle-HorizontalAlign="Center" Settings-AllowSort="False" VisibleIndex="4" Width="5%">
                                                                <DataItemTemplate>
                                                                    <asp:UpdatePanel runat="server" ID="UpdatePanel3">
                                                                        <ContentTemplate>
                                                                            <asp:Button runat="server" CssClass="delete_file" ID="btnDelete" CommandName="Delete" OnClientClick="return DlgConfirmALIF(this)"></asp:Button>
                                                                        </ContentTemplate>
                                                                        <Triggers>
                                                                            <asp:AsyncPostBackTrigger ControlID="btnDelete" />
                                                                        </Triggers>
                                                                    </asp:UpdatePanel>
                                                                </DataItemTemplate>
                                                                <Settings AllowHeaderFilter="False" AllowSort="False" />
                                                            </dx:GridViewDataColumn>
                                                        </Columns>
                                                        <Settings
                                                            HorizontalScrollBarMode="Hidden"
                                                            VerticalScrollBarMode="Hidden"
                                                            ShowGroupPanel="false"
                                                            ShowFooter="true"
                                                            ShowFilterRow="false"
                                                            ShowHeaderFilterButton="false"
                                                            ShowFilterRowMenu="false"
                                                            ShowFilterRowMenuLikeItem="false"
                                                            ShowFilterBar="Hidden" />
                                                        <SettingsBehavior ColumnResizeMode="Control" AllowFocusedRow="true" AllowSelectSingleRowOnly="false" />
                                                        <SettingsPager PageSize="10" AlwaysShowPager="true">
                                                            <PageSizeItemSettings Visible="false" ShowAllItem="true" />
                                                        </SettingsPager>
                                                        <SettingsDataSecurity AllowInsert="false" AllowEdit="false" AllowDelete="false" />
                                                    </dx:ASPxGridView>
                                                    <br />
                                                    <div class="label_plus_input par">
                                                        <span style="font-size: 13px; padding-top: 3px; width: 300px !important;"><%= RESOURCE.UnderWriting.NewBussiness.Resources.UsuarioInspeccion %>:</span>
                                                        <asp:TextBox ID="txtUsuarioInspeccion" validation="Required" Width="300px" runat="server" ClientIDMode="Static"></asp:TextBox>
                                                    </div>
                                                    <div style="padding-top: 1em;">
                                                        <div class="label_plus_input">
                                                            <span style="font-size: 13px; padding-top: 3px; width: 100% !important;" class="alignC">Firma del cliente</span>
                                                            <div class="wd100 fl textInfo">
                                                                <uc1:WUCDigitalSign runat="server" ID="WUCDigitalSign" />
                                                                <asp:Image runat="server" Style="display: none" ID="imgSignatureImage" ClientIDMode="Static" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </li>
                            </ul>
                        </li>
                    </ul>
                </div>
            </div>
            <!--accordion_tabulado-->


            <!--botones-->
            <div class="row_A mT10 btnFunc" style="padding-right: 12px;">
                <div class="fl">
                    <asp:Button
                        runat="server"
                        ID="btnBackToIllustrations"
                        CssClass="col-12 fl button button-red alignC embossed"
                        CausesValidation="false"
                        OnClick="btnBackToIllustrations_Click"
                        Text="Back to Illustrations" />
                </div>
                <div class="fr" style="padding-right: 10px;">
                    <asp:Button
                        runat="server"
                        ID="btnSave"
                        CssClass=" button button-green alignC embossed"
                        OnClientClick="SetearFirma()"
                        OnClick="btnSave_Click"
                        Text="Save" />

                    <%--<asp:Button
                        Enabled="false"
                        runat="server"
                        ID="btnDownLoad"
                        CssClass=" button button-blue alignC embossed boton_descargar_foto"
                        Text="Download Pictures" />--%>

                    <asp:Button
                        runat="server"
                        ID="btnClean"
                        CssClass=" button button-gris alignC embossed"
                        OnClick="btnClean_Click"
                        Text="Clean" />

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
            <!--botones-->
        </asp:Panel>
        <asp:HiddenField runat="server" ID="hdnHasSign" ClientIDMode="Static" Value="false" />
        <asp:HiddenField runat="server" ID="hdnCustomerSign" ClientIDMode="Static" Value="" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="ddlPropiedades" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="btnBackToIllustrations" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClean" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="rblTipoFoto" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="ddlCategoriaFoto" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="btnSendToSubscription" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="drpInspectors" EventName="SelectedIndexChanged" />
    </Triggers>
</asp:UpdatePanel>

<asp:HiddenField runat="server" ID="hdnAlliedLinesRiskInspectionForm" ClientIDMode="Static" Value="" />


<asp:UpdatePanel ID="upnCargarFoto" runat="server">
    <ContentTemplate>
        <asp:FileUpload
            AllowMultiple="true"
            ID="fuFotografia1"
            runat="server"
            OnChange="uploadImage();"
            Style="visibility: hidden;" />

        <asp:Button
            ID="btnCargarFoto"
            OnClick="btnCargarFoto_Click"
            runat="server"
            Style="visibility: hidden;" />
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btnCargarFoto" />
    </Triggers>
</asp:UpdatePanel>
