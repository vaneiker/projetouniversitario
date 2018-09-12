<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCGridView.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.AddNewClient.HealthDeclaration.UCGridView" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<div class="de_uno">
    <div class="grupos">
        <div class="float_left">
            <div class="grupos" style="padding-left: 6px">
                <asp:Button runat="server" ID="btnAdd" CssClass="btn_grey" Text="Add/Edit Treatment Disease" OnClick="btnAdd_Click" />
            </div>
        </div>
    </div>
    <!--grupos-->
    <div class="grid_wrap margin_t_15 gris">
        <dx:ASPxGridView ID="gvTratamientoEnfermedad" runat="server"
            EnableCallBacks="False"
            AutoGenerateColumns="False"
            SettingsPager-PageSize="15"
            Width="100%" validation="Required" OnPreRender="gvTratamientoEnfermedad_PreRender">
            <SettingsPager PageSize="3">
            </SettingsPager>
            <Columns>
                <dx:GridViewDataTextColumn Caption="Treatment / Disease" FieldName="DiseaseDesc" VisibleIndex="0" Name="TreatmentOrDisease">
                </dx:GridViewDataTextColumn>
            </Columns>
            <SettingsBehavior AllowSelectSingleRowOnly="true" AllowSort="False" />
        </dx:ASPxGridView>
    </div>
    <!--grid_wrap-->
</div>
<asp:HiddenField runat="server" Value="0" />
<!--grupos de_1-->



