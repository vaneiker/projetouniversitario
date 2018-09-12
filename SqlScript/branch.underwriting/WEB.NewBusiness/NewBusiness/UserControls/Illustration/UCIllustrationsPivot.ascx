<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCIllustrationsPivot.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.Illustration.UCIllustrationsPivot" %>
<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPivotGrid" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Data.Linq" TagPrefix="dx" %>
<div id="dvIllustrationPivot">
    <asp:UpdatePanel ID="UpdatePanelIllustrations" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="grupos de_6">
                <div>
                    <asp:Label runat="server" ID="lblPeriod" CssClass="label"><%= RESOURCE.UnderWriting.NewBussiness.Resources.TimeDimension %>:</asp:Label>
                    <asp:DropDownList runat="server" ID="drpPeriod" DataTextField="Value" DataValueField="Key" OnSelectedIndexChanged="drpPeriod_SelectedIndexChanged" AutoPostBack="true" Style="display: block;">
                    </asp:DropDownList>
                </div>
                <div>
                    <asp:Label runat="server" ID="lblPeriodYears" CssClass="label" Visible="false"><%= RESOURCE.UnderWriting.NewBussiness.Resources.Years %>:</asp:Label>
                    <asp:DropDownList runat="server" ID="drpPeriodYears" DataTextField="Value" DataValueField="Key" OnSelectedIndexChanged="drpPeriodYears_SelectedIndexChanged" AutoPostBack="true" Visible="false">
                    </asp:DropDownList>
                </div>
                <div>
                    <asp:Label runat="server" ID="lblPeriodData" CssClass="label" Visible="false"></asp:Label>
                    <asp:DropDownList runat="server" ID="drpPeriodData" DataTextField="Value" DataValueField="Key" OnSelectedIndexChanged="drpPeriodData_SelectedIndexChanged" AutoPostBack="true" Visible="false">
                    </asp:DropDownList>
                </div>
            </div>
            <dx:ASPxPivotGrid EnablePagingGestures="False" ID="pgIllustrations" ClientIDMode="Static" runat="server" DataSourceID="dsIllustrations"
                OptionsPager-NumericButtonCount="10"
                OptionsPager-Position="Bottom"
                OptionsLoadingPanel-Enabled="false"
                OptionsView-ShowHorizontalScrollBar="true"
                OptionsView-ShowDataHeaders="False"
                OptionsView-ShowColumnHeaders="False"
                OptionsView-ShowColumnGrandTotals="True"
                OptionsView-ShowRowGrandTotals="True"
                OptionsView-RowTotalsLocation="Tree"
                ClientSideEvents-BeginCallback="function(){ BeginRequestHandler(); }"
                ClientSideEvents-AfterCallback="function(){ EndRequestHandler(); }"
                OptionsFilter-ShowOnlyAvailableItems="true"
                OptionsView-HorizontalScrollBarMode="Auto"
                OptionsView-HorizontalScrollingMode="Standard">
                <Styles>
                    <CellStyle Cursor="pointer" />
                </Styles>
                <Fields>
                    <dx:PivotGridField FieldName="BusinessLine" ID="LineofBusinessLabel" Area="FilterArea"></dx:PivotGridField>
                    <dx:PivotGridField FieldName="Office" Area="FilterArea"></dx:PivotGridField>
                    <dx:PivotGridField FieldName="Channel" Area="FilterArea"></dx:PivotGridField>
                    <dx:PivotGridField FieldName="Agent" ID="VendorName" Area="FilterArea"></dx:PivotGridField>
                    <dx:PivotGridField FieldName="Subscriber" ID="AssignedSubscriber" Area="FilterArea"></dx:PivotGridField>
                    <dx:PivotGridField FieldName="Year" Area="ColumnArea"
                        SortOrder="Descending" Options-AllowDrag="False" Options-AllowSort="False" Options-AllowFilter="False">
                    </dx:PivotGridField>
                    <dx:PivotGridField FieldName="PivotMonth" Area="ColumnArea" TotalsVisibility="None"
                        SortOrder="Descending" Options-AllowDrag="False" Options-AllowSort="False" Options-AllowFilter="False">
                    </dx:PivotGridField>
                    <dx:PivotGridField FieldName="Count" Area="DataArea" CellStyle-ForeColor="Blue">
                    </dx:PivotGridField>
                    <dx:PivotGridField FieldName="PolicyStatus" ID="LiteralStatus" Area="RowArea"></dx:PivotGridField>
                </Fields>
            </dx:ASPxPivotGrid>
            <div class="export">
                <h4><%= RESOURCE.UnderWriting.NewBussiness.Resources.Export.ToUpper() %>:</h4>

                <asp:Button runat="server" ID="btnExportExcelIllustrations" OnClick="btnExportExcelIllustrations_Click" CssClass="excel" />
                <dx:ASPxPivotGridExporter ID="ExportExcelIllustrations" runat="server" ASPxPivotGridID="pgIllustrations"></dx:ASPxPivotGridExporter>
            </div>
            <dx:LinqServerModeDataSource ID="dsIllustrations" runat="server" OnSelecting="dsIllustrations_Selecting"></dx:LinqServerModeDataSource>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnExportExcelIllustrations" />
            <asp:AsyncPostBackTrigger ControlID="drpPeriodData" />
            <asp:AsyncPostBackTrigger ControlID="drpPeriodYears" />
        </Triggers>
    </asp:UpdatePanel>
</div>
