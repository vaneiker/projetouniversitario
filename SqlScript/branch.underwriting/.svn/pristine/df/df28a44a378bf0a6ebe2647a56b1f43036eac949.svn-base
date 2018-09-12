<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSeeDiscount.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.IllustrationsVehicle.UCSeeDiscount" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<div id="frmApplySurcharge" class="barra_sub_menu">
    <div class="recargoApply">
        <div class="tbl data_Gpl gvRecargos">
            <dx:ASPxGridView ID="gvRecargos" runat="server" ClientIDMode="Static"
                KeyFieldName="DiscountId;DiscountRuleId;DiscountRuleDetailId;NotePredefiniedId;Comment"
                EnableCallBacks="False" Width="100%" AutoGenerateColumns="False">
                <Columns>
                    <dx:GridViewDataTextColumn FieldName="FullName" Name="AGENT" Caption="Suscriptor" Settings-AllowSort="False" Width="30%"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="TipoDescuento" Name="TypeOfDiscount" Caption="Tipo Descuento" Settings-AllowSort="False" Width="20%"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="PorcentajeDescuento" Name="PercentageDiscount" Caption="Porcentaje" Settings-AllowSort="False" Width="8%"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="MontoDescuento" Name="AmountOfDiscount" Caption="Descuento" CellStyle-HorizontalAlign="Right" Settings-AllowSort="False" Width="12%">
                        <PropertiesTextEdit DisplayFormatString="$#,##0.00" NullDisplayText="$0.00"></PropertiesTextEdit>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Comment" Name="DiscountComment" Caption="Nota" Settings-AllowSort="False" Width="12%"></dx:GridViewDataTextColumn>
                </Columns>
                <TotalSummary>
                    <dx:ASPxSummaryItem FieldName="MontoDescuento" SummaryType="Sum" DisplayFormat="$#,##0.00" />
                </TotalSummary>
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
                <SettingsBehavior ColumnResizeMode="Control" AllowFocusedRow="true" />
                <SettingsPager PageSize="10" AlwaysShowPager="true">
                    <PageSizeItemSettings Visible="false" ShowAllItem="true" />
                </SettingsPager>
                <SettingsDataSecurity AllowInsert="false" AllowEdit="false" AllowDelete="false" />
            </dx:ASPxGridView>

        </div>
    </div>
</div>
