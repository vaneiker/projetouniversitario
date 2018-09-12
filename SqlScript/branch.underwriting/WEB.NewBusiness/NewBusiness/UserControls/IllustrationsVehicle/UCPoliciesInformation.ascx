<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCPoliciesInformation.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.IllustrationsVehicle.UCPoliciesInformation" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Data.Linq" TagPrefix="dx" %>

<div class="row">
    <div class="cont_gnl tab_pane_container rcomp mT25">
        <div class="round_blue "><%=RESOURCE.UnderWriting.NewBussiness.Resources.ExistingPolicies%></div>
        <div class="reqVehiculo">
            <div class="tbl data_Gpl gvVehiculos rasegu">
                <dx:ASPxGridView
                    ID="gvPolicies"
                    runat="server"
                    EnableCallBacks="False"
                    KeyFieldName="PolicyKey"
                    ClientIDMode="Static"
                    AutoGenerateColumns="false"
                    Width="100%"
                    OnRowCommand="gvPolicies_RowCommand"
                    OnPreRender="gvPolicies_PreRender"
                    OnPageIndexChanged="gvPolicies_PageIndexChanged">
                    <Columns>
                        <dx:GridViewDataTextColumn Caption="Compañía" FieldName="Company" Name="Company">
                            <Settings AllowHeaderFilter="False" AllowSort="True" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Poliza" FieldName="Policy" Name="PolicyNoLabel">
                            <Settings AllowHeaderFilter="False" AllowSort="True" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Línea de Negocio" FieldName="BusinessLine" Name="LineofBusinessLabel">
                            <Settings AllowHeaderFilter="False" AllowSort="True" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Monto Prima" FieldName="PremiumAmount" Name="PremiumAmount">
                            <Settings AllowHeaderFilter="False" AllowSort="True" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Fecha de Emisión" FieldName="EffectiveDate" Name="EmmisionDate" Width="8%">
                            <Settings AllowHeaderFilter="False" AllowSort="True" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Fecha de Expiración" FieldName="ExpirationDate" Name="ExpirationDate" Width="8%">
                            <Settings AllowHeaderFilter="False" AllowSort="True" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Estado" FieldName="Status" Name="Status" Width="8%">
                            <Settings AllowHeaderFilter="False" AllowSort="True" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataColumn Caption="Notas" Name="Notes" Width="5%">
                            <DataItemTemplate>
                                <div style="text-align: center">
                                    <asp:Button runat="server" CssClass="edit_file" ID="btnNote"></asp:Button>
                                </div>
                            </DataItemTemplate>
                            <Settings AllowHeaderFilter="False" AllowSort="False" />
                        </dx:GridViewDataColumn>
                    </Columns>
                    <SettingsPager PageSize="20" AlwaysShowPager="true">
                        <PageSizeItemSettings Visible="false" ShowAllItem="true" />
                    </SettingsPager>
                    <SettingsBehavior AllowSelectSingleRowOnly="false" AllowSort="false" AllowFocusedRow="false" />
                    <Settings ShowFooter="true" />
                </dx:ASPxGridView>
            </div>
        </div>
    </div>
</div>
