<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCPerformance.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.Statistics.UCPerformance" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Data.Linq" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPivotGrid" TagPrefix="dx" %>

<asp:UpdatePanel ID="updPerformanceSuscriptores" runat="server">
    <ContentTemplate>
        <asp:Panel ID="pnlPerformanceSuscriptores" runat="server" Visible="true">
            <dx:ASPxPivotGrid EnablePagingGestures="False" ID="pgPerformanceSuscriptores" ClientIDMode="Static" runat="server" DataSourceID="dsPerformance" ClientInstanceName="pgPerformanceSuscriptores"
                OptionsPager-NumericButtonCount="10"
                OptionsPager-Position="Bottom"
                OptionsLoadingPanel-Enabled="false"
                OptionsView-ShowHorizontalScrollBar="true"
                OptionsView-ShowDataHeaders="False"
                OptionsView-ShowColumnHeaders="False"
                OptionsView-ShowColumnGrandTotals="True"
                OptionsView-ShowRowGrandTotals="True"
                OptionsView-RowTotalsLocation="Tree"
                ClientSideEvents-BeginCallback="function(){ $('#loading').show(); }"
                ClientSideEvents-AfterCallback="function(){ $('#loading').hide(); }"
                OptionsFilter-ShowOnlyAvailableItems="true"
                OptionsView-HorizontalScrollBarMode="Auto"
                OptionsView-HorizontalScrollingMode="Standard">
                <ClientSideEvents AfterCallback="function(){ ConfiguraValores(); $('#loading').hide(); }" BeginCallback="function(){ ConfiguraValores(); $('#loading').show(); }" BeforeCallback="function(){ ConfiguraValores(); }" />
                <OptionsView HorizontalScrollBarMode="Auto" RowTotalsLocation="Tree" ShowColumnHeaders="False" ShowDataHeaders="False" ShowHorizontalScrollBar="True" />
                <OptionsPager Position="Bottom"></OptionsPager>
                <OptionsLoadingPanel Enabled="False"></OptionsLoadingPanel>
                <OptionsFilter ShowOnlyAvailableItems="True" />
                <Styles>
                    <CellStyle Cursor="pointer" />
                </Styles>
                <Fields>
                    <dx:PivotGridField Caption="Linea de Negocio" FieldName="Bl_Desc" Area="FilterArea"></dx:PivotGridField>
                    <dx:PivotGridField Caption="Oficina" FieldName="Office_Desc" Area="FilterArea"></dx:PivotGridField>
                    <dx:PivotGridField Caption="Canal de Ventas" FieldName="Distribution_Desc" Area="FilterArea"></dx:PivotGridField>
                    <dx:PivotGridField Caption="Producto" FieldName="Product_Type_Desc" Area="FilterArea"></dx:PivotGridField>

                    <dx:PivotGridField AreaIndex="0" Caption="Suscriptor" FieldName="Subscriber_Name" Area="RowArea"></dx:PivotGridField>

                    <dx:PivotGridField FieldName="Year" Area="ColumnArea"
                        SortOrder="Descending" Options-AllowDrag="False" Options-AllowSort="False" Options-AllowFilter="False">
                    </dx:PivotGridField>
                    <dx:PivotGridField FieldName="PivotMonth" Area="ColumnArea" TotalsVisibility="None"
                        SortOrder="Descending" Options-AllowDrag="False" Options-AllowSort="False" Options-AllowFilter="False">
                    </dx:PivotGridField>                                        
                    
                    <%--suma de Count -> cantidad--%>
                    <dx:PivotGridField Area="DataArea" AreaIndex="0" EmptyCellText="0" FieldName="Count"></dx:PivotGridField>

                    <%--Time / Tiempo--%>
                    <dx:PivotGridField Area="DataArea" AreaIndex="1" EmptyCellText="0" FieldName="Performance_Subscriber_Minute"></dx:PivotGridField>
                    

                    <%--Performance / Rendimiento--%>
                    <dx:PivotGridField Area="DataArea" AreaIndex="2" EmptyCellText="0" FieldName="Performance">
                        <CellStyle Font-Size="10pt" ForeColor="Blue"></CellStyle>                        
                    </dx:PivotGridField>
                </Fields>
            </dx:ASPxPivotGrid>
        </asp:Panel>

        <asp:Panel ID="pnlPerformanceInspectores" runat="server" Visible="false">
            <dx:ASPxPivotGrid EnablePagingGestures="False" ID="pgPerformanceInspectores" ClientIDMode="Static" runat="server" DataSourceID="dsPerformance" ClientInstanceName="pgPerformanceInspectores"
                OptionsPager-NumericButtonCount="10"
                OptionsPager-Position="Bottom"
                OptionsLoadingPanel-Enabled="false"
                OptionsView-ShowHorizontalScrollBar="true"
                OptionsView-ShowDataHeaders="False"
                OptionsView-ShowColumnHeaders="False"
                OptionsView-ShowColumnGrandTotals="True"
                OptionsView-ShowRowGrandTotals="True"
                OptionsView-RowTotalsLocation="Tree"
                ClientSideEvents-BeginCallback="function(){ $('#loading').show(); }"
                ClientSideEvents-AfterCallback="function(){ $('#loading').hide(); }"
                OptionsFilter-ShowOnlyAvailableItems="true"
                OptionsView-HorizontalScrollBarMode="Auto"
                OptionsView-HorizontalScrollingMode="Standard">
                <ClientSideEvents AfterCallback="function(){ ConfiguraValores(); $('#loading').hide(); }" BeginCallback="function(){ ConfiguraValores(); $('#loading').show(); }" BeforeCallback="function(){ ConfiguraValores(); }" />
                <OptionsView HorizontalScrollBarMode="Auto" RowTotalsLocation="Tree" ShowColumnHeaders="False" ShowDataHeaders="False" ShowHorizontalScrollBar="True" />
                <OptionsPager Position="Bottom"></OptionsPager>
                <OptionsLoadingPanel Enabled="False"></OptionsLoadingPanel>
                <OptionsFilter ShowOnlyAvailableItems="True" />
                <Styles>
                    <CellStyle Cursor="pointer" />
                </Styles>
                <Fields>
                    <dx:PivotGridField Caption="Linea de Negocio" FieldName="Bl_Desc" Area="FilterArea"></dx:PivotGridField>
                    <dx:PivotGridField Caption="Oficina" FieldName="Office_Desc" Area="FilterArea"></dx:PivotGridField>
                    <dx:PivotGridField Caption="Canal de Ventas" FieldName="Distribution_Desc" Area="FilterArea"></dx:PivotGridField>
                    <dx:PivotGridField Caption="Producto" FieldName="Product_Type_Desc" Area="FilterArea"></dx:PivotGridField>

                    <dx:PivotGridField AreaIndex="0" Caption="Inspector" FieldName="Inspector_Name" Area="RowArea"></dx:PivotGridField>

                    <dx:PivotGridField FieldName="Year" Area="ColumnArea"
                        SortOrder="Descending" Options-AllowDrag="False" Options-AllowSort="False" Options-AllowFilter="False">
                    </dx:PivotGridField>
                    <dx:PivotGridField FieldName="PivotMonth" Area="ColumnArea" TotalsVisibility="None"
                        SortOrder="Descending" Options-AllowDrag="False" Options-AllowSort="False" Options-AllowFilter="False">
                    </dx:PivotGridField>

                    <%--suma de Count -> cantidad--%>
                    <dx:PivotGridField Area="DataArea" AreaIndex="0" EmptyCellText="0" FieldName="Count"></dx:PivotGridField>

                    <%--Time / Tiempo--%>
                    <dx:PivotGridField Area="DataArea" AreaIndex="1" EmptyCellText="0" FieldName="Performance_Inspector_Minute"></dx:PivotGridField>
                    

                    <%--Performance / Rendimiento--%>
                    <dx:PivotGridField Area="DataArea" AreaIndex="2" EmptyCellText="0" FieldName="Performance">
                        <CellStyle Font-Size="10pt" ForeColor="Blue"></CellStyle>                        
                    </dx:PivotGridField>
                </Fields>
            </dx:ASPxPivotGrid>
        </asp:Panel>

        <asp:Panel ID="pnlExportarExcelPerformance" runat="server" Visible="false">
            <div class="export">
                <h4><%= RESOURCE.UnderWriting.NewBussiness.Resources.Export.ToUpper() %>:</h4>
                <asp:Button runat="server" ID="btnExportExcel" OnClick="btnExportExcel_Click" CssClass="excel" />
                <dx:ASPxPivotGridExporter ID="pgeExportExcel" runat="server" ASPxPivotGridID="pgPerformanceSuscriptores"></dx:ASPxPivotGridExporter>
            </div>
        </asp:Panel>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btnExportExcel" />
    </Triggers>
</asp:UpdatePanel>

<dx:LinqServerModeDataSource ID="dsPerformance" runat="server" OnSelecting="dsPerformance_Selecting"></dx:LinqServerModeDataSource>
