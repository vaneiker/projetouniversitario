<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucClientSearch.ascx.cs" Inherits="CollectorsModule.Controls.ucClientSearch" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Data.Linq" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<div class="contenido">
    <div id="pnlContent" class="bdrRadius20 row_A">
        <div class=" tbl data_Gpl">
            <dx:ASPxGridView ID="gvClients" ClientInstanceName="gvClients" runat="server" KeyFieldName="POLICY_NUMBER" OnCustomColumnDisplayText="gvClients_CustomColumnDisplayText"
                SettingsBehavior-AllowSelectSingleRowOnly="true" EnableRowsCache="false" OnDataBinding="gvClients_DataBinding" OnProcessColumnAutoFilter="gvClients_ProcessColumnAutoFilter"
                OnFocusedRowChanged="gvClients_FocusedRowChanged" OnSelectionChanged="gvClients_FocusedRowChanged" OnCustomCallback="gvClients_CustomCallback">
                <Columns>
                    <dx:GridViewCommandColumn ShowSelectCheckbox="True" Caption="Seleccionar" VisibleIndex="0" Width="5%">
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataColumn FieldName="CUSTNAME" VisibleIndex="1" Width="25%">
                        <HeaderCaptionTemplate>
                            Nombre Completo
                        </HeaderCaptionTemplate>
                    </dx:GridViewDataColumn>
                    <dx:GridViewDataColumn FieldName="DATE_OF_BIRTH" VisibleIndex="1" Width="20%">
                        <HeaderCaptionTemplate>
                            Fecha de Nacimiento
                        </HeaderCaptionTemplate>
                    </dx:GridViewDataColumn>
                    <dx:GridViewDataColumn FieldName="CLIENT_ID" VisibleIndex="1" Width="15%">
                        <HeaderCaptionTemplate>
                            No. Cédula
                        </HeaderCaptionTemplate>
                    </dx:GridViewDataColumn>
                    <dx:GridViewDataColumn FieldName="POLICY_NUMBER" VisibleIndex="2" Width="25%">
                        <HeaderCaptionTemplate>
                            No. Póliza
                        </HeaderCaptionTemplate>
                    </dx:GridViewDataColumn>
                    <dx:GridViewDataColumn FieldName="RowKey" VisibleIndex="3" Visible="false">
                        <HeaderCaptionTemplate>
                            RowKey
                        </HeaderCaptionTemplate>
                    </dx:GridViewDataColumn>
                    <dx:GridViewCommandColumn ShowClearFilterButton="true" Caption="Filtrar" ShowApplyFilterButton="true" Visible="false" VisibleIndex="7" />
                </Columns>
                <SettingsBehavior AllowSelectByRowClick="true" />
                <Settings ShowFilterRow="true" />
                <SettingsBehavior ProcessFocusedRowChangedOnServer="true" />
                <SettingsBehavior FilterRowMode="Auto" />
                <SettingsLoadingPanel Mode="Disabled" />
                <ClientSideEvents FocusedRowChanged="function(s,e){console.log(e);}" SelectionChanged="grid_SelectionChanged" EndCallback="function(s, e) {loading(false);setGridStyles();}" BeginCallback="function(s, e) {loading(true);}" />
            </dx:ASPxGridView>
            <%--<dx:ASPxGridView ID="gvClients" ClientInstanceName="gvClients" runat="server" KeyFieldName="RowKey"
            SettingsBehavior-AllowSelectSingleRowOnly="true" EnableRowsCache="false" OnDataBinding="gvClients_DataBinding" OnProcessColumnAutoFilter="gvClients_ProcessColumnAutoFilter"
            OnFocusedRowChanged="gvClients_FocusedRowChanged" OnSelectionChanged="gvClients_FocusedRowChanged">
            <Columns>
                <dx:GridViewCommandColumn ShowSelectCheckbox="True" Caption="Seleccionar" VisibleIndex="0">
                </dx:GridViewCommandColumn>
                <dx:GridViewDataColumn FieldName="First_Name" VisibleIndex="1" Width="20%">
                      <HeaderCaptionTemplate>
                        Nombre del cliente
                    </HeaderCaptionTemplate>
                </dx:GridViewDataColumn>
                <dx:GridViewDataColumn FieldName="Lastname" VisibleIndex="2" Width="20%">
                    <HeaderCaptionTemplate>
                        Apellido del cliente
                    </HeaderCaptionTemplate>
                </dx:GridViewDataColumn>
                <dx:GridViewDataColumn FieldName="Dob" VisibleIndex="3" Width="20%">
                    <HeaderCaptionTemplate>
                        Fecha de nacimiento
                    </HeaderCaptionTemplate>
                </dx:GridViewDataColumn>
                <dx:GridViewDataColumn FieldName="Id" VisibleIndex="4" Width="15%">
                    <HeaderCaptionTemplate>
                        No. Cedula
                    </HeaderCaptionTemplate>
                </dx:GridViewDataColumn>
                <dx:GridViewDataColumn FieldName="Policy_No" VisibleIndex="5" Width="20%">
                    <HeaderCaptionTemplate>
                        No. Poliza
                    </HeaderCaptionTemplate>   
                </dx:GridViewDataColumn>
                <dx:GridViewDataColumn FieldName="Contact_Id" VisibleIndex="6" Visible="false">
                    <HeaderCaptionTemplate>
                        Contact_Id
                    </HeaderCaptionTemplate>
                </dx:GridViewDataColumn>
                <dx:GridViewCommandColumn ShowClearFilterButton="true" Caption="Filtrar" ShowApplyFilterButton="true" Visible="false" VisibleIndex="7" />
            </Columns>
            <Settings ShowFilterRow="true" />
            <SettingsBehavior ProcessFocusedRowChangedOnServer="true" />
            <SettingsBehavior FilterRowMode="Auto" />
            <ClientSideEvents SelectionChanged="grid_SelectionChanged" EndCallback="setGridStyles" />
        </dx:ASPxGridView>--%>
        </div>
    </div>
    <div class="col-4 fr botones_func mT20">
        <asp:Button runat="server" ID="btnContinue" CssClass="col-4 fr button button-green alignC embossed" Text="Continuar" OnClientClick="loading(true);" OnClick="btnContinue_Click" />
        <asp:Button runat="server" ID="btnCleanFilters" CssClass="col-4 fr button button-red alignC embossed" Text="Limpiar" OnClientClick="if (!UserClearConfirmation()){return false;} else {loading(true); return true;}" OnClick="btnCleanFilters_Click" />
    </div>
</div>
<!--contenido-->
