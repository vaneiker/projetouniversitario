<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Processing.ascx.cs" Inherits="Web.SubmittedPolicies.Life.UserControls.Processing.WebUserControl1" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Data.Linq" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:UpdatePanel ID="upProcessingPolicies" runat="server" ClientIDMode="Static" style="width: 100%;">
    <ContentTemplate>
        <div class="Grid_dv">
            <dx:ASPxGridView ID="gvProcessingPolicies"
                runat="server"
                DataSourceID="dsProcessingPolicies"
                KeyFieldName="Corp_Id;Region_Id;Country_Id;Domesticreg_Id;State_Prov_Id;City_Id;Office_Id;Case_Seq_No;Hist_Seq_No;Step_Type_Id;Step_Id;Step_Case_No;Policy_No"
                AutoGenerateColumns="false"
                ShowHeaderWhenEmpty="true"
                SettingsLoadingPanel-Mode="Disabled"
                EnableCallBacks="False"
                OnFocusedRowChanged="gvProcessingPolicies_OnFocusedRowChanged">
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
                    <dx:GridViewDataColumn Caption="Status" CellStyle-CssClass="c14" HeaderStyle-CssClass="c14" HeaderStyle-HorizontalAlign="Center">
                        <DataItemTemplate>
                            <asp:Label ID="lblStepDesc" Text='<%# ( bool.Parse(Eval("SentCoreStatus").ToString()) ? "En Proceso" : "Error") %>' OnClientClick="return false;" runat="server" ClientIDMode="Static" CssClass="fl mT10"></asp:Label>
                            <img align="center" src='<%# ( bool.Parse(Eval("SentCoreStatus").ToString()) ? "../../../images/alert_mamei.png" : "../../../images/x.png") %>' class="alert_naranja fr">
                        </DataItemTemplate>
                    </dx:GridViewDataColumn>
                </Columns>
                <SettingsBehavior AllowFocusedRow="true" ProcessFocusedRowChangedOnServer="true" AllowSelectSingleRowOnly="true" />
                <SettingsPager PageSize="10" NumericButtonCount="3" Summary-Text="Página {0} de {1} ({2} elementos)" />
            </dx:ASPxGridView>
            <dx:LinqServerModeDataSource ID="dsProcessingPolicies" runat="server" OnSelecting="dsProcessingPolicies_OnSelecting" />
    </ContentTemplate>
</asp:UpdatePanel>
