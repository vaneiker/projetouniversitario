<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Confirmation.ascx.cs" Inherits="Web.SubmittedPolicies.Life.UserControls.Issue.Confirmation" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.Data.Linq" Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<div class="Grid_dv No_Click">
    <dx:ASPxGridView ID="gvConfirmationPolicies"
        runat="server"
        DataSourceID="dsConfirmationPolicies"
        KeyFieldName="Corp_Id;Region_Id;Country_Id;Domesticreg_Id;State_Prov_Id;City_Id;Office_Id;Case_Seq_No;Hist_Seq_No;Policy_No"
        EnableCallBacks="false"
        AutoGenerateColumns="false"
        ShowHeaderWhenEmpty="true">
        <Settings ShowFilterRow="false" ShowFilterBar="Hidden" ShowHeaderFilterButton="false" ShowFilterRowMenu="false" ShowFilterRowMenuLikeItem="false" />
        <Columns>
            <dx:GridViewDataColumn FieldName="Policy_No" Caption="Número de Póliza" Settings-AutoFilterCondition="Contains" CellStyle-CssClass="c1" HeaderStyle-CssClass="c1" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center"/>
            <dx:GridViewDataColumn FieldName="OwnerFullName" Caption="Nombre del Propietario" Settings-AutoFilterCondition="Contains" CellStyle-CssClass="c2" HeaderStyle-CssClass="c2"  HeaderStyle-HorizontalAlign="Center" />
            <dx:GridViewDataDateColumn FieldName="Policy_Effective_Date" Caption="Fecha de Emision" HeaderStyle-HorizontalAlign="Center" CellStyle-CssClass="c3" HeaderStyle-CssClass="c3"
                CellStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Equals">
                <PropertiesDateEdit DisplayFormatString="MM/dd/yyyy"></PropertiesDateEdit>
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataColumn FieldName="Product_Desc" Caption="Tipo de Producto" Settings-AutoFilterCondition="Contains" CellStyle-CssClass="c4" HeaderStyle-CssClass="c4"  HeaderStyle-HorizontalAlign="Center" />
            <dx:GridViewDataTextColumn FieldName="Initial_Premium" Caption="Monto de Prima Inicial"  HeaderStyle-HorizontalAlign="Center"  Settings-AutoFilterCondition="Equals" CellStyle-CssClass="c5" HeaderStyle-CssClass="c5">
                <PropertiesTextEdit DisplayFormatString="C2"></PropertiesTextEdit>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataColumn FieldName="Payment_Freq_Type_Desc" Caption="Frecuencia de Pago" Settings-AutoFilterCondition="Contains" CellStyle-CssClass="c6" HeaderStyle-CssClass="c6" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center"/>
            <dx:GridViewDataColumn FieldName="MethodOfPayment" Caption="Tipo de Pago" Settings-AutoFilterCondition="Contains" CellStyle-CssClass="c7" HeaderStyle-CssClass="c7" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center"/>
            <dx:GridViewDataDateColumn FieldName="LastPaymentDate" Caption="Fecha Pago Final" HeaderStyle-HorizontalAlign="Center" CellStyle-CssClass="c8" HeaderStyle-CssClass="c8" 
                CellStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Equals">
                <PropertiesDateEdit DisplayFormatString="MM/dd/yyyy"></PropertiesDateEdit>
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataColumn FieldName="AgentFullName" Caption="Nombre Agente" Settings-AutoFilterCondition="Contains" CellStyle-CssClass="c9" HeaderStyle-CssClass="c9" HeaderStyle-HorizontalAlign="Center"  />
            <dx:GridViewDataColumn FieldName="Office_Desc" Caption="Oficina" Settings-AutoFilterCondition="Contains" CellStyle-CssClass="c10" HeaderStyle-CssClass="c10" HeaderStyle-HorizontalAlign="Center"  />
            <dx:GridViewDataDateColumn FieldName="Sent_Date" Caption="Fecha Enviada" HeaderStyle-HorizontalAlign="Center" CellStyle-CssClass="c11" HeaderStyle-CssClass="c11"
                CellStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Equals">
                <PropertiesDateEdit DisplayFormatString="MM/dd/yyyy"></PropertiesDateEdit>
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataColumn FieldName="Sent_Days" Caption="Dias Enviada" Settings-AutoFilterCondition="Contains" CellStyle-CssClass="c12" HeaderStyle-CssClass="c12" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center"/>
            <dx:GridViewDataDateColumn FieldName="Max_Received_Date" Caption="Fecha Máxima para Recibir" HeaderStyle-HorizontalAlign="Center" CellStyle-CssClass="c13" HeaderStyle-CssClass="c13"
                CellStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Equals">
                <PropertiesDateEdit DisplayFormatString="MM/dd/yyyy"></PropertiesDateEdit>
            </dx:GridViewDataDateColumn>
        </Columns>
        <SettingsBehavior AllowFocusedRow="False" ProcessFocusedRowChangedOnServer="true" AllowSelectSingleRowOnly="true" />
        <SettingsPager PageSize="10" NumericButtonCount="3"  Summary-Text="Página {0} de {1} ({2} elementos)"/>
        <SettingsPopup>
            <HeaderFilter Height="200" />
        </SettingsPopup>
        <SettingsDataSecurity AllowInsert="false" AllowEdit="false" AllowDelete="false" />
    </dx:ASPxGridView>
    <dx:LinqServerModeDataSource ID="dsConfirmationPolicies" runat="server" OnSelecting="dsConfirmationPolicies_OnSelecting" />
</div>
