<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCCoverages.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.IllustrationAlliedLines.Products.UCCoverages" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:UpdatePanel runat="server" ID="udpCoverage">
    <ContentTemplate>
        <dx:ASPxGridView
            ID="gvCoveragesIL"
            runat="server"
            EnableCallBacks="False"
            ClientIDMode="Static"
            AutoGenerateColumns="False"
            Width="100%" OnPageIndexChanged="gvCoverage_PageIndexChanged" OnPreRender="gvCoverage_PreRender">
            <Columns>
                <dx:GridViewDataTextColumn Caption="Coverage Type" FieldName="CoverageTypeDesc" Name="CoverageTypeDesc" CellStyle-HorizontalAlign="Center">
                    <Settings AllowHeaderFilter="False" AllowSort="true" />
                    <CellStyle HorizontalAlign="Center">
                    </CellStyle>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Coverage Desc" FieldName="CoverageDesc" Name="CoverageDesc" CellStyle-HorizontalAlign="Left">
                    <Settings AllowHeaderFilter="False" AllowSort="true" />
                    <CellStyle HorizontalAlign="Left">
                    </CellStyle>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Coverage Limit" FieldName="CoverageLimit" Name="CoverageLimit" CellStyle-HorizontalAlign="Center">
                    <Settings AllowHeaderFilter="False" AllowSort="true" />
                    <CellStyle HorizontalAlign="Center">
                    </CellStyle>
                </dx:GridViewDataTextColumn> 
                
                <dx:GridViewDataTextColumn Caption="Coinsurance Percentage" FieldName="CoinsurancePercentage" Name="CoinsurancePercentage" CellStyle-HorizontalAlign="Center">
                    <Settings AllowHeaderFilter="False" AllowSort="true" />
                    <CellStyle HorizontalAlign="Center">
                    </CellStyle>
                </dx:GridViewDataTextColumn>

                <dx:GridViewDataTextColumn Caption="Deductible Percentage" FieldName="DeductiblePercentage" Name="DeductiblePercentage" CellStyle-HorizontalAlign="Center">
                    <Settings AllowHeaderFilter="False" AllowSort="true" />
                    <CellStyle HorizontalAlign="Center">
                    </CellStyle>
                </dx:GridViewDataTextColumn>
                 <dx:GridViewDataTextColumn Caption="Premium" FieldName="UnitaryPrice" Name="Premium" CellStyle-HorizontalAlign="Center">
                    <Settings AllowHeaderFilter="False" AllowSort="true" />
                    <CellStyle HorizontalAlign="Center">
                    </CellStyle>
                </dx:GridViewDataTextColumn>
                 <dx:GridViewDataTextColumn Caption="Rate" FieldName="PremiumPercentage" Name="Rate" CellStyle-HorizontalAlign="Center">
                    <Settings AllowHeaderFilter="False" AllowSort="true" />
                    <CellStyle HorizontalAlign="Center">
                    </CellStyle>
                </dx:GridViewDataTextColumn>                 
            </Columns>
            <Settings VerticalScrollableHeight="200" VerticalScrollBarMode="Visible" />
            <SettingsPager PageSize="100" NumericButtonCount="3" AlwaysShowPager="true">
                <PageSizeItemSettings Visible="false" ShowAllItem="true" />
            </SettingsPager>            
            <SettingsBehavior AllowSelectSingleRowOnly="false" AllowSort="False" AllowFocusedRow="false" />           
        </dx:ASPxGridView>
        <asp:HiddenField runat="server" ID="hdnHideOrShowPrimeAndRate" Value="false" ClientIDMode="Static" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="gvCoveragesIL" />
    </Triggers>
</asp:UpdatePanel>

