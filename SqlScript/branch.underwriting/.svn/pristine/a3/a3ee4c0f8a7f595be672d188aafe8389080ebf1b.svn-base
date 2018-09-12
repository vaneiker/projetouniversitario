<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUCTBSiniestraldidad.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.IllustrationsVehicle.WUCTBSiniestraldidad" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Data.Linq" TagPrefix="dx" %>

<div class="reqVehiculo">
    <div class="tbl fl data_Gpl gvVehiculo p1 w-100 ">
        <asp:UpdatePanel runat="server" ID="udpTbSiniestralidad">
            <ContentTemplate>
                <dx:ASPxGridView
                    ID="gvTBSiniestralidad"
                    runat="server"
                    EnableCallBacks="False"
                    ClientIDMode="Static"
                    AutoGenerateColumns="false"
                    Width="100%"
                    OnPreRender="gvTBSiniestralidad_PreRender" OnPageIndexChanged="gvTBSiniestralidad_PageIndexChanged">
                    <Columns>
                        <dx:GridViewDataTextColumn Caption="Marca" FieldName="Make" Name="Make">
                            <Settings AllowHeaderFilter="False" AllowSort="true" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Modelo" FieldName="Model" Name="Model">
                            <Settings AllowHeaderFilter="False" AllowSort="true" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Año" FieldName="Year" Name="Year" CellStyle-HorizontalAlign="Center">
                            <Settings AllowHeaderFilter="False" AllowSort="true" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="% Siniestraldad" FieldName="AccidentRate" Name="AccidentRate" CellStyle-HorizontalAlign="Center">
                            <Settings AllowHeaderFilter="False" AllowSort="true" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Cantidad Vehiculos" FieldName="VehicleCount" Name="VehicleCount" CellStyle-HorizontalAlign="Center">
                            <Settings AllowHeaderFilter="False" AllowSort="true" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="% Siniestralidad Frequencia" FieldName="Frequency" Name="Frequency" CellStyle-HorizontalAlign="Center">
                            <Settings AllowHeaderFilter="False" AllowSort="true" />
                        </dx:GridViewDataTextColumn>
                         <dx:GridViewDataTextColumn Caption="% Siniestralidad Liquidacion" FieldName="Liquidation" Name="Liquidacion" CellStyle-HorizontalAlign="Center">
                            <Settings AllowHeaderFilter="False" AllowSort="true" />
                        </dx:GridViewDataTextColumn>                        
                    </Columns>
                    <SettingsPager PageSize="9" AlwaysShowPager="true">
                        <PageSizeItemSettings Visible="false" ShowAllItem="true" />
                    </SettingsPager>
                    <SettingsBehavior AllowSelectSingleRowOnly="false" AllowSort="False" AllowFocusedRow="false" />
                    <Settings ShowFooter="True" />
                </dx:ASPxGridView>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="gvTBSiniestralidad" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</div>
