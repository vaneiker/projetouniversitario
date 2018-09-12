<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NeverIssued.ascx.cs" Inherits="Web.SubmittedPolicies.Life.UserControls.NeverIssued.NeverIssued" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.Data.Linq" Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<%@ Register Src="~/Life/UserControls/NeverIssued/Popups/UCEditNeverIssued.ascx" TagPrefix="uc1" TagName="UCEditNeverIssued" %>



<div class="row_box">
    <asp:UpdatePanel ID="upNeverIssuePolicies" runat="server" ClientIDMode="Static">
        <ContentTemplate>
            <div class="Grid_dv">
                <dx:ASPxGridView ID="gvNeverIssued"
                    runat="server"
                    DataSourceID="dsNeverIssued"
                    KeyFieldName="Corp_Id;Region_Id;Country_Id;Domesticreg_Id;State_Prov_Id;City_Id;Office_Id;Case_Seq_No;Hist_Seq_No;Step_Type_Id;Step_Id;Step_Case_No;Policy_No"
                    AutoGenerateColumns="false"
                    ShowHeaderWhenEmpty="true"
                    SettingsLoadingPanel-Mode="Disabled"
                    OnFocusedRowChanged="gvNeverIssued_OnFocusedRowChanged"
                    EnableCallBacks="False"
                    OnRowCommand="gvNeverIssued_OnRowCommand">
                    <Settings ShowFilterRow="false" ShowFilterBar="Hidden" ShowHeaderFilterButton="false" ShowFilterRowMenu="false" ShowFilterRowMenuLikeItem="false" />
                    <Columns>
                        <dx:GridViewDataColumn FieldName="Policy_No" Caption="Número de Póliza" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center" CellStyle-CssClass="c1" HeaderStyle-CssClass="c1" />
                        <dx:GridViewDataColumn FieldName="OwnerFullName" Caption="Nombre del Propietario" CellStyle-CssClass="c2" HeaderStyle-CssClass="c2" HeaderStyle-HorizontalAlign="Center" />
                        <dx:GridViewDataDateColumn FieldName="ApplicationDate" Caption="Fecha de Solicitud" HeaderStyle-HorizontalAlign="Center" CellStyle-CssClass="c3" HeaderStyle-CssClass="c3"
                            CellStyle-HorizontalAlign="Center">
                            <PropertiesDateEdit DisplayFormatString="MM/dd/yyyy"></PropertiesDateEdit>
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataColumn FieldName="Product_Desc" Caption="Tipo de Producto" CellStyle-CssClass="c4" HeaderStyle-CssClass="c4" HeaderStyle-HorizontalAlign="Center" />
                        <dx:GridViewDataTextColumn FieldName="Initial_Premium" Caption="Monto de Prima Inicial" HeaderStyle-HorizontalAlign="Center" CellStyle-CssClass="c5" HeaderStyle-CssClass="c5">
                            <PropertiesTextEdit DisplayFormatString="C2"></PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataColumn FieldName="AgentFullName" Caption="Nombre Agente" CellStyle-CssClass="c6" HeaderStyle-CssClass="c6" HeaderStyle-HorizontalAlign="Center" />
                        <dx:GridViewDataColumn FieldName="Office_Desc" Caption="Oficina" CellStyle-CssClass="c7" HeaderStyle-CssClass="c7" HeaderStyle-HorizontalAlign="Center" />
                        <dx:GridViewDataColumn FieldName="Step_Reason_Desc" Caption="Condición" CellStyle-CssClass="c8" HeaderStyle-CssClass="c8" HeaderStyle-HorizontalAlign="Center" />
                        <dx:GridViewDataColumn FieldName="Status" Caption="Estatus" CellStyle-CssClass="c9" HeaderStyle-CssClass="c9" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center">
                            <DataItemTemplate>
                                <dx:ASPxImage ID="imgStatus" ImageUrl='<%# Eval("Status_Image")%>' runat="server" Width="22px" Height="26px" ImageAlign="Middle"></dx:ASPxImage>
                            </DataItemTemplate>
                        </dx:GridViewDataColumn>
                        <dx:GridViewDataColumn Caption="Editar" HeaderStyle-CssClass="c10" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center">
                            <DataItemTemplate>
                                <asp:LinkButton runat="server" ID="btnEditNeverIssued" CommandName="Edit" CssClass="btn1 ico_G edit" />
                            </DataItemTemplate>
                        </dx:GridViewDataColumn>
                        <dx:GridViewDataTextColumn Caption="Seleccionar" CellStyle-CssClass="c11" HeaderStyle-CssClass="c11" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center">
                            <DataItemTemplate>
                                <dx:ASPxCheckBox runat="server" ID="chkIssueSelecst" ClientSideEvents-Click="return ASPxClientUtils.PreventEventAndBubble(e.htmlEvent); }" />
                            </DataItemTemplate>
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <SettingsBehavior AllowFocusedRow="true" ProcessFocusedRowChangedOnServer="true" AllowSelectSingleRowOnly="true" />
                    <SettingsPager PageSize="10" NumericButtonCount="3"  Summary-Text="Página {0} de {1} ({2} elementos)"/>
                </dx:ASPxGridView>
                <dx:LinqServerModeDataSource ID="dsNeverIssued" runat="server" OnSelecting="dsNeverIssued_OnSelecting" />
            </div>
            <div class="row_A fl mT10">
                <asp:Button runat="server" ID="btnNIREnviar" Text="Enviar" CssClass="btn bgreen fr" OnClick="btnNIREnviar_OnClick" OnClientClick="return ValidateSelectedGrid(this,'#upNeverIssuePolicies');" />
            </div>

            <!-- POP UPS /> -->

            <!-- Edit Never Issued /> -->
            <AJAX:ModalPopupExtender ID="mpEditNeverIssued"
                BehaviorID="mpEditNeverIssued"
                PopupControlID="pnEditNeverIssued"
                TargetControlID="hdnShowEditNeverIssued"
                runat="server">
            </AJAX:ModalPopupExtender>
            <asp:Panel ID="pnEditNeverIssued" runat="server" Style="display: none; margin: 0px; border-right-width: 1px; border-bottom-width: 1px; border-left-width: 1px; border-style: none solid solid; border-right-color: rgb(119, 119, 119); border-bottom-color: rgb(119, 119, 119); border-left-color: rgb(119, 119, 119); position: absolute; z-index: 100001; left: 361.5px; background-color: rgb(207, 207, 196);">
                <uc1:UCEditNeverIssued runat="server" id="UCEditNeverIssued1" />
            </asp:Panel>
            <asp:HiddenField ID="hdnShowEditNeverIssued" ClientIDMode="Static" runat="server" Value="false" />
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
