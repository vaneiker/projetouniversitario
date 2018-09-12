<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Fotos.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.VehicleInspectionForm.Fotos" %>
<%@ Register Src="~/NewBusiness/UserControls/VehicleInspectionForm/Foto.ascx" TagPrefix="uc1" TagName="Foto" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<div class="fondo_gris">
    <div style="padding: 10px;">
        <div class ="tResponsive">
            <ul>
                <li>
                    <uc1:Foto
                        runat="server"
                        ID="FotoFrente"
                        AlternateText="Frente"
                        CommandArgument="Frente"
                        Titulo="Frente" />
                </li>
                <li>
                    <uc1:Foto
                        runat="server"
                        ID="FotoFrenteDerecho"
                        AlternateText="Frente Derecho"
                        CommandArgument="FrenteDerecho"
                        Titulo="Frente Derecho" />
                </li>
                <li>
                    <uc1:Foto
                        runat="server"
                        ID="FotoFrenteIzquierdo"
                        AlternateText="Frente Izquierdo"
                        CommandArgument="FrenteIzquierdo"
                        Titulo="Frente Izquierdo" />
                </li>
                <li>
                    <uc1:Foto
                        runat="server"
                        ID="FotoTrasera"
                        AlternateText="Trasera"
                        CommandArgument="Trasera"
                        Titulo="Trasera" />
                </li>
                <li>
                    <uc1:Foto
                        runat="server"
                        ID="FotoTraseraDerecha"
                        AlternateText="Trasera Derecha"
                        CommandArgument="TraseraDerecha"
                        Titulo="Trasera Derecha" />
                </li>
                <li>
                    <uc1:Foto
                        runat="server"
                        ID="FotoTraseraIzquierda"
                        AlternateText="Trasera Izquierda"
                        CommandArgument="TraseraIzquierda"
                        Titulo="Trasera Izquierda" />
                </li>
                <li>
                    <uc1:Foto
                        runat="server"
                        ID="FotoBaulExterior"
                        AlternateText="Baúl Exterior"
                        CommandArgument="BaulExterior"
                        Titulo="Baúl Exterior" />
                </li>
                <li>
                    <uc1:Foto
                        runat="server"
                        ID="FotoBaulInterior"
                        AlternateText="Baúl Interior"
                        CommandArgument="BaulInterior"
                        Titulo="Baúl Interior" />
                </li>
                <li>
                    <uc1:Foto
                        runat="server"
                        ID="FotoInterior1"
                        AlternateText="Interior 1"
                        CommandArgument="Interior1"
                        Titulo="Interior 1" />
                </li>
                <li>
                    <uc1:Foto
                        runat="server"
                        ID="FotoInterior2"
                        AlternateText="Interior 2"
                        CommandArgument="Interior2"
                        Titulo="Interior 2" />
                </li>
                <li>
                    <uc1:Foto
                        runat="server"
                        ID="FotoInterior3"
                        AlternateText="Interior 3"
                        CommandArgument="Interior3"
                        Titulo="Interior 3" />
                </li>
                <li>
                    <uc1:Foto
                        runat="server"
                        ID="FotoInterior4"
                        AlternateText="Interior 4"
                        CommandArgument="Interior4"
                        Titulo="Interior 4" />
                </li>
                <li>
                    <uc1:Foto
                        runat="server"
                        ID="FotoRepuestos"
                        AlternateText="Repuestos"
                        CommandArgument="Repuestos"
                        Titulo="Repuestos" />
                </li>
                <li>
                    <uc1:Foto
                        runat="server"
                        ID="FotoMotorExterior"
                        AlternateText="Motor Exterior"
                        CommandArgument="MotorExterior"
                        Titulo="Motor Exterior" />
                </li>
                <li>
                    <uc1:Foto
                        runat="server"
                        ID="FotoMotorInterior"
                        AlternateText="Motor Interior"
                        CommandArgument="MotorInterior"
                        Titulo="Motor Interior" />
                </li>
                <li>
                    <uc1:Foto
                        runat="server"
                        ID="FotoKilometraje"
                        AlternateText="Kilometraje"
                        CommandArgument="Kilometraje"
                        Titulo="Kilometraje" />
                </li>
                <li>
                    <uc1:Foto
                        runat="server"
                        ID="FotoChasis1"
                        AlternateText="Chasis 1"
                        CommandArgument="Chasis1"
                        Titulo="Chasis 1" />
                </li>
                <li>
                    <uc1:Foto
                        runat="server"
                        ID="FotoChasis2"
                        AlternateText="Chasis 2"
                        CommandArgument="Chasis2"
                        Titulo="Chasis 2" />
                </li>
                <li>
                    <uc1:Foto
                        runat="server"
                        ID="FotoTecho"
                        AlternateText="Techo"
                        CommandArgument="Techo"
                        Titulo="Techo" />
                </li>
                 <li>
                    <uc1:Foto
                        runat="server"
                        ID="FotoSelfieInspector"
                        AlternateText="Selfie Inspictor"
                        CommandArgument="SelfieInspector"
                        Titulo="Selfie Inspector" />
                </li>
            </ul>
        </div>
    </div>
</div>
