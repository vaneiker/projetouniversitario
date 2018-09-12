<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Issue.ascx.cs" Inherits="Web.SubmittedPolicies.Life.UserControls.Issue.Issue" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Data.Linq" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<%@ Register Src="~/Life/UserControls/Issue/Popups/UCAmmendments.ascx" TagPrefix="uc1" TagName="UCAmmendments" %>
<%@ Register Src="~/Life/UserControls/Issue/Popups/UCReject.ascx" TagPrefix="uc1" TagName="UCReject" %>
<%@ Register Src="~/Life/UserControls/Issue/Popups/UCDocuments.ascx" TagPrefix="uc1" TagName="UCDocuments" %>
<!--PASOS /> -->
<asp:UpdatePanel ID="upIssuePolicies" runat="server" ClientIDMode="Static">
    <ContentTemplate>
        <div class="Grid_dv">
            <dx:ASPxGridView ID="gvIssuePolicies"
                runat="server"
                DataSourceID="dsIssuePolicies"
                KeyFieldName="Corp_Id;Region_Id;Country_Id;Domesticreg_Id;State_Prov_Id;City_Id;Office_Id;Case_Seq_No;Hist_Seq_No;Step_Type_Id;Step_Id;Step_Case_No;Policy_No"
                AutoGenerateColumns="false"
                ShowHeaderWhenEmpty="true"
                SettingsLoadingPanel-Mode="Disabled"
                OnFocusedRowChanged="gvIssuePolicies_OnFocusedRowChanged"
                EnableCallBacks="False"
                OnRowCommand="gvIssuePolicies_OnRowCommand">
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
                    <dx:GridViewDataTextColumn FieldName="Insured_Amount" Caption="Suma Asegurada" HeaderStyle-HorizontalAlign="Center" CellStyle-CssClass="c6" HeaderStyle-CssClass="c6">
                        <PropertiesTextEdit DisplayFormatString="C2"></PropertiesTextEdit>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataColumn FieldName="InsuredFullName" Caption="Nombre del Asegurado" CellStyle-CssClass="c7" HeaderStyle-CssClass="c7" HeaderStyle-HorizontalAlign="Center" />
                    <dx:GridViewDataColumn FieldName="Payment_Freq_Type_Desc" Caption="Frecuencia de Pago" CellStyle-CssClass="c8" HeaderStyle-CssClass="c8" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center" />
                    <dx:GridViewDataColumn FieldName="MethodOfPayment" Caption="Tipo de Pago" CellStyle-CssClass="c9" HeaderStyle-CssClass="c9" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center" />
                    <dx:GridViewDataDateColumn FieldName="FirstPaymentDate" Caption="Fecha Pago Inicial" HeaderStyle-HorizontalAlign="Center" CellStyle-CssClass="c10" HeaderStyle-CssClass="c10"
                        CellStyle-HorizontalAlign="Center">
                        <PropertiesDateEdit DisplayFormatString="MM/dd/yyyy"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn FieldName="LastPaymentDate" Caption="Fecha Pago Final" HeaderStyle-HorizontalAlign="Center" CellStyle-CssClass="c11" HeaderStyle-CssClass="c11"
                        CellStyle-HorizontalAlign="Center">
                        <PropertiesDateEdit DisplayFormatString="MM/dd/yyyy"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataColumn FieldName="AgentFullName" Caption="Nombre Agente" CellStyle-CssClass="c12" HeaderStyle-CssClass="c12" HeaderStyle-HorizontalAlign="Center" />
                    <dx:GridViewDataColumn FieldName="Office_Desc" Caption="Oficina" CellStyle-CssClass="c13" HeaderStyle-CssClass="c13" HeaderStyle-HorizontalAlign="Center" />
                    <dx:GridViewDataColumn Caption="Enmienda" HeaderStyle-CssClass="c14" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center">
                        <DataItemTemplate>
                            <asp:LinkButton runat="server" ID="btnAmmendments" CommandName="Ammendment" CssClass="c14 btn1 ico_G enmienda" />
                        </DataItemTemplate>
                    </dx:GridViewDataColumn>
                    <dx:GridViewDataColumn Caption="Rechazar" HeaderStyle-CssClass="c16" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center">
                        <DataItemTemplate>
                            <asp:LinkButton runat="server" ID="btnReject" CommandName="Reject" CssClass="c16 btn3 ico_G doc_delete" />
                        </DataItemTemplate>
                    </dx:GridViewDataColumn>
                    <dx:GridViewDataTextColumn Caption="Seleccionar" CellStyle-CssClass="c17" HeaderStyle-CssClass="c17" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center">
                        <DataItemTemplate>
                            <dx:ASPxCheckBox runat="server" ID="chkIssueSelecst" ClientSideEvents-Click="return ASPxClientUtils.PreventEventAndBubble(e.htmlEvent); }" />
                        </DataItemTemplate>
                    </dx:GridViewDataTextColumn>
                </Columns>
                <SettingsBehavior AllowFocusedRow="true" ProcessFocusedRowChangedOnServer="true" AllowSelectSingleRowOnly="true" />
                <SettingsPager PageSize="10" NumericButtonCount="3" Summary-Text="Página {0} de {1} ({2} elementos)"/>
            </dx:ASPxGridView>
            <dx:LinqServerModeDataSource ID="dsIssuePolicies" runat="server" OnSelecting="dsIssuePolicies_OnSelecting" />

            <!-- POP UPS /> -->

            <!-- AMMENDMENTS /> -->
            <AJAX:ModalPopupExtender ID="mpAmmendments"
                BehaviorID="mpAmmendments"
                PopupControlID="pnPopAmmendments"
                TargetControlID="hdnShowAmmendments"
                runat="server">
            </AJAX:ModalPopupExtender>
            <asp:Panel ID="pnPopAmmendments" runat="server" Style="display: none; margin: 0px; border-right-width: 1px; border-bottom-width: 1px; border-left-width: 1px; border-style: none solid solid; border-right-color: rgb(119, 119, 119); border-bottom-color: rgb(119, 119, 119); border-left-color: rgb(119, 119, 119); position: absolute; z-index: 100001; left: 361.5px; background-color: rgb(207, 207, 196);">
                <uc1:UCAmmendments runat="server" ID="UCAmmendments1" />
            </asp:Panel>
            <asp:HiddenField ID="hdnShowAmmendments" ClientIDMode="Static" runat="server" Value="false" />

            <!-- DOCUMENTS /> -->
            <AJAX:ModalPopupExtender ID="mpDocuments"
                BehaviorID="mpDocuments"
                PopupControlID="pnPopDocuments"
                TargetControlID="hdnShowDocuments"
                runat="server">
            </AJAX:ModalPopupExtender>
            <asp:Panel ID="pnPopDocuments" runat="server" Style="display: none; margin: 0px; border-right-width: 1px; border-bottom-width: 1px; border-left-width: 1px; border-style: none solid solid; border-right-color: rgb(119, 119, 119); border-bottom-color: rgb(119, 119, 119); border-left-color: rgb(119, 119, 119); position: absolute; z-index: 100001; left: 361.5px; background-color: rgb(207, 207, 196);">
                <uc1:UCDocuments runat="server" ID="UCDocuments1" />
            </asp:Panel>
            <asp:HiddenField ID="hdnShowDocuments" ClientIDMode="Static" runat="server" Value="false" />

            <!-- REJECT /> -->
            <AJAX:ModalPopupExtender ID="mpReject"
                BehaviorID="mpReject"
                PopupControlID="pnPopReject"
                TargetControlID="hdnShowReject"
                runat="server">
            </AJAX:ModalPopupExtender>
            <asp:Panel ID="pnPopReject" runat="server" Style="display: none; margin: 0px; border-right-width: 1px; border-bottom-width: 1px; border-left-width: 1px; border-style: none solid solid; border-right-color: rgb(119, 119, 119); border-bottom-color: rgb(119, 119, 119); border-left-color: rgb(119, 119, 119); position: absolute; z-index: 100001; left: 361.5px; background-color: rgb(207, 207, 196);">
                <uc1:UCReject runat="server" ID="UCReject1" />
            </asp:Panel>
            <asp:HiddenField ID="hdnShowReject" ClientIDMode="Static" runat="server" Value="false" />
        </div>
        <div class="row_A fl mT10">
            <asp:LinkButton runat="server" ID="lnkEmitir" CssClass="btn bgreen fr" Text="Emitir" OnClick="lnkEmitir_OnClick" OnClientClick="return ValidateSelectedGrid(this,'#upIssuePolicies');"></asp:LinkButton>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>



