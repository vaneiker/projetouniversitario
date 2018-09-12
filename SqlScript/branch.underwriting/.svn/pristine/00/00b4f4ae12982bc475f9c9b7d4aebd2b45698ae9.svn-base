<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCEmisiones.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.Statistics.UCEmisiones" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Data.Linq" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPivotGrid" TagPrefix="dx" %>

<asp:UpdatePanel ID="updEmisiones" runat="server">
    <ContentTemplate>
        <asp:Panel ID="pnlEmisionesCantidad" runat="server" Visible="true">
            <dx:ASPxPivotGrid EnablePagingGestures="False" ID="pgEmisionesCantidad" ClientIDMode="Static" runat="server" DataSourceID="dsEmisiones" ClientInstanceName="pgEmisionesCantidad"
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
                <ClientSideEvents AfterCallback="function(){ ConfiguraMontos(); $('#loading').hide(); }" BeginCallback="function(){ ConfiguraMontos(); $('#loading').show(); }" BeforeCallback="function(){ ConfiguraMontos(); }" />
                <OptionsView HorizontalScrollBarMode="Auto" RowTotalsLocation="Tree" ShowColumnHeaders="False" ShowDataHeaders="False" ShowHorizontalScrollBar="True" />
                <OptionsPager Position="Bottom"></OptionsPager>
                <OptionsLoadingPanel Enabled="False"></OptionsLoadingPanel>
                <OptionsFilter ShowOnlyAvailableItems="True" />
                <Styles>
                    <CellStyle Cursor="pointer" />
                </Styles>
                <Fields>
                    <dx:PivotGridField AreaIndex="0" Caption="Producto" FieldName="Product_Type_Desc" Area="RowArea"></dx:PivotGridField>

                    <dx:PivotGridField Caption="Linea de Negocio" FieldName="Bl_Desc" Area="FilterArea"></dx:PivotGridField>
                    <dx:PivotGridField Caption="Oficina" FieldName="Office_Desc" Area="FilterArea"></dx:PivotGridField>
                    <dx:PivotGridField Caption="Canal de Ventas" FieldName="Distribution_Desc" Area="FilterArea"></dx:PivotGridField>
                    <dx:PivotGridField Caption="Director Senior" FieldName="Agent_FullName_DirectorSenior" Area="FilterArea"></dx:PivotGridField>
                    <dx:PivotGridField Caption="Director Comercial" FieldName="Agent_FullName_DirectorComercial" Area="FilterArea"></dx:PivotGridField>
                    <dx:PivotGridField Caption="Gerente Comercial" FieldName="Agent_FullName_GerenteComercial" Area="FilterArea"></dx:PivotGridField>
                    <dx:PivotGridField Caption="Agente Comercial" FieldName="Agent_FullName_Comercial" Area="FilterArea"></dx:PivotGridField>
                    <dx:PivotGridField Caption="Agente" FieldName="Agent_Name" Area="FilterArea"></dx:PivotGridField>
                    <dx:PivotGridField Caption="Poliza" FieldName="Policy_No" Area="FilterArea"></dx:PivotGridField>

                    <dx:PivotGridField FieldName="Year" Area="ColumnArea"
                        SortOrder="Descending" Options-AllowDrag="False" Options-AllowSort="False" Options-AllowFilter="False">
                    </dx:PivotGridField>
                    <dx:PivotGridField FieldName="PivotMonth" Area="ColumnArea" TotalsVisibility="None"
                        SortOrder="Descending" Options-AllowDrag="False" Options-AllowSort="False" Options-AllowFilter="False">
                    </dx:PivotGridField>

                    <dx:PivotGridField FieldName="Count" Area="DataArea" CellStyle-ForeColor="Blue" CellStyle-Font-Size="10pt" EmptyCellText="0"></dx:PivotGridField>
                </Fields>
            </dx:ASPxPivotGrid>
        </asp:Panel>

        <asp:Panel ID="pnlEmisionesPrima" runat="server" Visible="false">
            <dx:ASPxPivotGrid EnablePagingGestures="False" ID="pgEmisionesPrima" ClientIDMode="Static" runat="server" DataSourceID="dsEmisiones" ClientInstanceName="pgEmisionesPrima"
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
                <ClientSideEvents AfterCallback="function(){ ConfiguraMontos(); $('#loading').hide(); }" BeginCallback="function(){ ConfiguraMontos(); $('#loading').show(); }" BeforeCallback="function(){ ConfiguraMontos(); }" />
                <OptionsView HorizontalScrollBarMode="Auto" RowTotalsLocation="Tree" ShowColumnHeaders="False" ShowDataHeaders="False" ShowHorizontalScrollBar="True" />
                <OptionsPager Position="Bottom"></OptionsPager>
                <OptionsLoadingPanel Enabled="False"></OptionsLoadingPanel>
                <OptionsFilter ShowOnlyAvailableItems="True" />
                <Styles>
                    <CellStyle Cursor="pointer" />
                </Styles>
                <Fields>
                    <dx:PivotGridField AreaIndex="0" Caption="Producto" FieldName="Product_Type_Desc" Area="RowArea"></dx:PivotGridField>

                    <dx:PivotGridField Caption="Linea de Negocio" FieldName="Bl_Desc" Area="FilterArea" AreaIndex="0"></dx:PivotGridField>
                    <dx:PivotGridField Caption="Oficina" FieldName="Office_Desc" Area="FilterArea" AreaIndex="1"></dx:PivotGridField>
                    <dx:PivotGridField Caption="Canal de Ventas" FieldName="Distribution_Desc" Area="FilterArea" AreaIndex="2"></dx:PivotGridField>
                    <dx:PivotGridField Caption="Director Senior" FieldName="Agent_FullName_DirectorSenior" Area="FilterArea" AreaIndex="3"></dx:PivotGridField>
                    <dx:PivotGridField Caption="Director Comercial" FieldName="Agent_FullName_DirectorComercial" Area="FilterArea" AreaIndex="4"></dx:PivotGridField>
                    <dx:PivotGridField Caption="Gerente Comercial" FieldName="Agent_FullName_GerenteComercial" Area="FilterArea" AreaIndex="5"></dx:PivotGridField>
                    <dx:PivotGridField Caption="Agente Comercial" FieldName="Agent_FullName_Comercial" Area="FilterArea" AreaIndex="6"></dx:PivotGridField>
                    <dx:PivotGridField Caption="Agente" FieldName="Agent_Name" Area="FilterArea" AreaIndex="7"></dx:PivotGridField>
                    <dx:PivotGridField Caption="Poliza" FieldName="Policy_No" Area="FilterArea"></dx:PivotGridField>

                    <dx:PivotGridField FieldName="Year" Area="ColumnArea"
                        SortOrder="Descending" Options-AllowDrag="False" Options-AllowSort="False" Options-AllowFilter="False" AreaIndex="0">
                    </dx:PivotGridField>
                    <dx:PivotGridField FieldName="PivotMonth" Area="ColumnArea" TotalsVisibility="None"
                        SortOrder="Descending" Options-AllowDrag="False" Options-AllowSort="False" Options-AllowFilter="False" AreaIndex="1">
                    </dx:PivotGridField>

                    <dx:PivotGridField FieldName="Annual_Premium" Area="DataArea" CellStyle-ForeColor="Blue" CellStyle-Font-Size="10pt" EmptyCellText="0.00">
                        <CellStyle Font-Size="10pt" ForeColor="Blue">
                        </CellStyle>
                    </dx:PivotGridField>
                </Fields>
            </dx:ASPxPivotGrid>
        </asp:Panel>

        <asp:Panel ID="pnlEmisionesSumaAsegurada" runat="server" Visible="false">
            <dx:ASPxPivotGrid EnablePagingGestures="False" ID="pgEmisionesSumaAsegurada" ClientIDMode="Static" runat="server" DataSourceID="dsEmisiones" ClientInstanceName="pgEmisionesSumaAsegurada"
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
                <ClientSideEvents AfterCallback="function(){ ConfiguraMontos(); $('#loading').hide(); }" BeginCallback="function(){ ConfiguraMontos(); $('#loading').show(); }" BeforeCallback="function(){ ConfiguraMontos(); }" />
                <OptionsView HorizontalScrollBarMode="Auto" RowTotalsLocation="Tree" ShowColumnHeaders="False" ShowDataHeaders="False" ShowHorizontalScrollBar="True" />
                <OptionsPager Position="Bottom"></OptionsPager>
                <OptionsLoadingPanel Enabled="False"></OptionsLoadingPanel>
                <OptionsFilter ShowOnlyAvailableItems="True" />
                <Styles>
                    <CellStyle Cursor="pointer" />
                </Styles>
                <Fields>
                    <dx:PivotGridField AreaIndex="0" Caption="Producto" FieldName="Product_Type_Desc" Area="RowArea"></dx:PivotGridField>

                    <dx:PivotGridField Caption="Linea de Negocio" FieldName="Bl_Desc" Area="FilterArea"></dx:PivotGridField>
                    <dx:PivotGridField Caption="Oficina" FieldName="Office_Desc" Area="FilterArea"></dx:PivotGridField>
                    <dx:PivotGridField Caption="Canal de Ventas" FieldName="Distribution_Desc" Area="FilterArea"></dx:PivotGridField>
                    <dx:PivotGridField Caption="Director Senior" FieldName="Agent_FullName_DirectorSenior" Area="FilterArea"></dx:PivotGridField>
                    <dx:PivotGridField Caption="Director Comercial" FieldName="Agent_FullName_DirectorComercial" Area="FilterArea"></dx:PivotGridField>
                    <dx:PivotGridField Caption="Gerente Comercial" FieldName="Agent_FullName_GerenteComercial" Area="FilterArea"></dx:PivotGridField>
                    <dx:PivotGridField Caption="Agente Comercial" FieldName="Agent_FullName_Comercial" Area="FilterArea"></dx:PivotGridField>
                    <dx:PivotGridField Caption="Agente" FieldName="Agent_Name" Area="FilterArea"></dx:PivotGridField>
                    <dx:PivotGridField Caption="Poliza" FieldName="Policy_No" Area="FilterArea"></dx:PivotGridField>

                    <dx:PivotGridField FieldName="Year" Area="ColumnArea"
                        SortOrder="Descending" Options-AllowDrag="False" Options-AllowSort="False" Options-AllowFilter="False">
                    </dx:PivotGridField>
                    <dx:PivotGridField FieldName="PivotMonth" Area="ColumnArea" TotalsVisibility="None"
                        SortOrder="Descending" Options-AllowDrag="False" Options-AllowSort="False" Options-AllowFilter="False">
                    </dx:PivotGridField>

                    <dx:PivotGridField FieldName="Insured_Amount" Area="DataArea" CellStyle-ForeColor="Blue" CellStyle-Font-Size="10pt" EmptyCellText="0.00"></dx:PivotGridField>
                </Fields>
            </dx:ASPxPivotGrid>
        </asp:Panel>

        <asp:Panel ID="pnlEmisionesTasa" runat="server" Visible="false">
            <dx:ASPxPivotGrid EnablePagingGestures="False" ID="pgEmisionesTasa" ClientIDMode="Static" runat="server" DataSourceID="dsEmisiones" ClientInstanceName="pgEmisionesTasa"
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
                <ClientSideEvents AfterCallback="function(){ ConfiguraMontos(); $('#loading').hide(); }" BeginCallback="function(){ ConfiguraMontos(); $('#loading').show(); }" BeforeCallback="function(){ ConfiguraMontos(); }" />
                <OptionsView HorizontalScrollBarMode="Auto" RowTotalsLocation="Tree" ShowColumnHeaders="False" ShowDataHeaders="False" ShowHorizontalScrollBar="True" />
                <OptionsPager Position="Bottom"></OptionsPager>
                <OptionsLoadingPanel Enabled="False"></OptionsLoadingPanel>
                <OptionsFilter ShowOnlyAvailableItems="True" />
                <Styles>
                    <CellStyle Cursor="pointer" />
                </Styles>
                <Fields>
                    <dx:PivotGridField AreaIndex="0" Caption="Producto" FieldName="Product_Type_Desc" Area="RowArea"></dx:PivotGridField>

                    <dx:PivotGridField Caption="Linea de Negocio" FieldName="Bl_Desc" Area="FilterArea" AreaIndex="0"></dx:PivotGridField>
                    <dx:PivotGridField Caption="Oficina" FieldName="Office_Desc" Area="FilterArea" AreaIndex="1"></dx:PivotGridField>
                    <dx:PivotGridField Caption="Canal de Ventas" FieldName="Distribution_Desc" Area="FilterArea" AreaIndex="2"></dx:PivotGridField>
                    <dx:PivotGridField Caption="Director Senior" FieldName="Agent_FullName_DirectorSenior" Area="FilterArea" AreaIndex="3"></dx:PivotGridField>
                    <dx:PivotGridField Caption="Director Comercial" FieldName="Agent_FullName_DirectorComercial" Area="FilterArea" AreaIndex="4"></dx:PivotGridField>
                    <dx:PivotGridField Caption="Gerente Comercial" FieldName="Agent_FullName_GerenteComercial" Area="FilterArea" AreaIndex="5"></dx:PivotGridField>
                    <dx:PivotGridField Caption="Agente Comercial" FieldName="Agent_FullName_Comercial" Area="FilterArea" AreaIndex="6"></dx:PivotGridField>
                    <dx:PivotGridField Caption="Agente" FieldName="Agent_Name" Area="FilterArea" AreaIndex="7"></dx:PivotGridField>
                    <dx:PivotGridField Caption="Poliza" FieldName="Policy_No" Area="FilterArea" AreaIndex="8"></dx:PivotGridField>

                    <dx:PivotGridField Area="ColumnArea" FieldName="Year" SortOrder="Descending" Options-AllowDrag="False" Options-AllowFilter="False" Options-AllowSort="False" AreaIndex="0"></dx:PivotGridField>
                    <dx:PivotGridField Area="ColumnArea" FieldName="PivotMonth" SortOrder="Descending" Options-AllowDrag="False" Options-AllowFilter="False" TotalsVisibility="None" AreaIndex="1"></dx:PivotGridField>

                    <dx:PivotGridField Area="DataArea" AreaIndex="0" EmptyCellText="$0.00" FieldName="Annual_Premium"></dx:PivotGridField>
                    <dx:PivotGridField Area="DataArea" AreaIndex="1" EmptyCellText="$0.00" FieldName="Insured_Amount"></dx:PivotGridField>
                    <dx:PivotGridField Area="DataArea" AreaIndex="2" EmptyCellText="0.000" FieldName="Rate">
                        <CellStyle Font-Size="10pt" ForeColor="Blue"></CellStyle>
                    </dx:PivotGridField>
                </Fields>
            </dx:ASPxPivotGrid>
        </asp:Panel>

        <asp:Panel ID="pnlEmisionesCantidadVehiculos" runat="server" Visible="false">
            <dx:ASPxPivotGrid EnablePagingGestures="False" ID="pgEmisionesCantidadVehiculos" ClientIDMode="Static" runat="server" DataSourceID="dsEmisiones" ClientInstanceName="pgEmisionesCantidadVehiculos"
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
                <ClientSideEvents AfterCallback="function(){ ConfiguraMontos(); $('#loading').hide(); }" BeginCallback="function(){ ConfiguraMontos(); $('#loading').show(); }" BeforeCallback="function(){ ConfiguraMontos(); }" />
                <OptionsView HorizontalScrollBarMode="Auto" RowTotalsLocation="Tree" ShowColumnHeaders="False" ShowDataHeaders="False" ShowHorizontalScrollBar="True" />
                <OptionsPager Position="Bottom"></OptionsPager>
                <OptionsLoadingPanel Enabled="False"></OptionsLoadingPanel>
                <OptionsFilter ShowOnlyAvailableItems="True" />
                <Styles>
                    <CellStyle Cursor="pointer" />
                </Styles>
                <Fields>
                    <dx:PivotGridField AreaIndex="0" Caption="Producto" FieldName="Product_Type_Desc" Area="RowArea"></dx:PivotGridField>

                    <dx:PivotGridField Caption="Linea de Negocio" FieldName="Bl_Desc" Area="FilterArea"></dx:PivotGridField>
                    <dx:PivotGridField Caption="Oficina" FieldName="Office_Desc" Area="FilterArea"></dx:PivotGridField>
                    <dx:PivotGridField Caption="Canal de Ventas" FieldName="Distribution_Desc" Area="FilterArea"></dx:PivotGridField>
                    <dx:PivotGridField Caption="Director Senior" FieldName="Agent_FullName_DirectorSenior" Area="FilterArea"></dx:PivotGridField>
                    <dx:PivotGridField Caption="Director Comercial" FieldName="Agent_FullName_DirectorComercial" Area="FilterArea"></dx:PivotGridField>
                    <dx:PivotGridField Caption="Gerente Comercial" FieldName="Agent_FullName_GerenteComercial" Area="FilterArea"></dx:PivotGridField>
                    <dx:PivotGridField Caption="Agente Comercial" FieldName="Agent_FullName_Comercial" Area="FilterArea"></dx:PivotGridField>
                    <dx:PivotGridField Caption="Agente" FieldName="Agent_Name" Area="FilterArea"></dx:PivotGridField>
                    <dx:PivotGridField Caption="Poliza" FieldName="Policy_No" Area="FilterArea"></dx:PivotGridField>

                    <dx:PivotGridField FieldName="Year" Area="ColumnArea"
                        SortOrder="Descending" Options-AllowDrag="False" Options-AllowSort="False" Options-AllowFilter="False">
                    </dx:PivotGridField>
                    <dx:PivotGridField FieldName="PivotMonth" Area="ColumnArea" TotalsVisibility="None"
                        SortOrder="Descending" Options-AllowDrag="False" Options-AllowSort="False" Options-AllowFilter="False">
                    </dx:PivotGridField>

                    <dx:PivotGridField FieldName="Vehicle_Count" Area="DataArea" CellStyle-ForeColor="Blue" CellStyle-Font-Size="10pt" EmptyCellText="0"></dx:PivotGridField>
                </Fields>
            </dx:ASPxPivotGrid>
        </asp:Panel>

        <asp:Panel ID="pnlExportarExcelEmisiones" runat="server" Visible="false">
            <div class="export">
                <h4><%= RESOURCE.UnderWriting.NewBussiness.Resources.Export.ToUpper() %>:</h4>
                <asp:Button runat="server" ID="btnExportExcel" OnClick="btnExportExcel_Click" CssClass="excel" />
                <dx:ASPxPivotGridExporter ID="pgeExportExcel" runat="server" ASPxPivotGridID="pgEmisionesCantidad"></dx:ASPxPivotGridExporter>
            </div>
        </asp:Panel>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btnExportExcel" />
    </Triggers>
</asp:UpdatePanel>

<dx:LinqServerModeDataSource ID="dsEmisiones" runat="server" OnSelecting="dsEmisiones_Selecting"></dx:LinqServerModeDataSource>



