<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUCCasesInProcess.ascx.cs" Inherits="WEB.NewBusiness.DReview.UserControl.CasesNotSubmitted.CasesInProcess.WUCCasesInProcess" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Data.Linq" TagPrefix="dx" %>
<asp:UpdatePanel runat="server" ID="udpCasesInProcess">
    <ContentTemplate>
        <dx:ASPxGridView ID="gvCasesInProcess" OnAfterPerformCallback="gvCasesInProcess_AfterPerformCallback"
            KeyFieldName="OwnerContactId;                          
                          CorpId;
                          RegionId;
                          CountryId;
                          DomesticregId;
                          StateProvId;
                          CityId;
                          OfficeId;
                          HistSeqNo;
                          CaseSeqNo;
                          PolicyNo;
                          AgentId;
                          ProductNameKey;
                          DesignatedPensionerContactId;
                          InsuredContactId;
                          StudentNameContactId;                                                  
                          ProductDesc;
                          OwnerFullName;
                          InsuranceFullName;
                          AgentFullName;
                          UserFullName;
                          LastUpdate;
                          AddInsuredContactId;
                          PaymentId"
            runat="server" ClientIDMode="Static"
            EnableCallBacks="False" DataSourceID="LinqDS" Width="100%" AutoGenerateColumns="False" OnRowCommand="gvCasesInProcess_RowCommand" OnPreRender="gvCasesInProcess_PreRender">
            <Settings ShowFilterRow="true" ShowFilterBar="Auto" ShowHeaderFilterButton="true" ShowFilterRowMenu="true" ShowFilterRowMenuLikeItem="false" />
            <Columns>               
                <dx:GridViewDataTextColumn FieldName="PolicyNo" Caption="POLICY" Name="PolicyLabel"/>
                <dx:GridViewDataTextColumn FieldName="ProductDesc" Caption="PLAN" Name="PlanLabel"/>         
                <dx:GridViewDataTextColumn FieldName="InsuranceFullName" Caption="INSURED NAME" Name="INSURED"/>
                <dx:GridViewDataTextColumn FieldName="CountryDesc" Caption="COUNTRY" Name="CountryLabel"/>
                <dx:GridViewDataTextColumn FieldName="OfficeDesc" Caption="OFFICE" Name="Office"/>
                <dx:GridViewDataTextColumn FieldName="AgentFullName" Caption="AGENT NAME" Name="AGENT"/>
                <dx:GridViewDataTextColumn FieldName="Exception" Caption="EXCEPTION" Name="Exception"/>
                <dx:GridViewDataTextColumn FieldName="UserFullName" Caption="USER" Name="USER"/>                  
                <dx:GridViewDataDateColumn FieldName="LastUpdate" Caption="LAST UPDATE" VisibleIndex="7" Name="LastUpdateLabel"/>                
                <dx:GridViewDataColumn Caption="VIEW" VisibleIndex="10" Width="4%" Name="View">
                    <DataItemTemplate>
                        <asp:Button runat="server" CssClass="view_file" ID="btnViewFile" CommandName="View" Width="50px"></asp:Button>
                    </DataItemTemplate>
                    <Settings AllowHeaderFilter="False" AllowSort="False" />
                </dx:GridViewDataColumn>
            </Columns>
             <SettingsBehavior ColumnResizeMode="NextColumn" />
            <Settings VerticalScrollableHeight="600" VerticalScrollBarMode="Visible" />
            <SettingsPager PageSize="20" AlwaysShowPager="true">
                <PageSizeItemSettings Visible="true" ShowAllItem="true" />
            </SettingsPager>
            <SettingsPopup>
                <HeaderFilter Height="200" />
            </SettingsPopup>
            <SettingsDataSecurity AllowInsert="false" AllowEdit="false" AllowDelete="false" />
        </dx:ASPxGridView>
        <dx:LinqServerModeDataSource OnSelecting="LinqDS_Selecting" ID="LinqDS" runat="server" DefaultSorting="LastUpdate" />
        <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="gvFakeGridView"></dx:ASPxGridViewExporter>
        <dx:ASPxGridView ID="gvFakeGridView" runat="server" EnableCallBacks="False" Width="100%" AutoGenerateColumns="False" Visible="false">
            <Columns>
                <dx:GridViewDataColumn FieldName="PolicyNo" Caption="POLICY" VisibleIndex="0" />
                <dx:GridViewDataColumn FieldName="ProductDesc" Caption="PLAN" VisibleIndex="1" />
                <dx:GridViewDataColumn FieldName="OwnerFullName" Caption="OWNER" VisibleIndex="2" />
                <dx:GridViewDataColumn FieldName="InsuranceFullName" Caption="INSURED" VisibleIndex="3" />
                <dx:GridViewDataColumn FieldName="AgentFullName" Caption="AGENT" VisibleIndex="4" />
                <dx:GridViewDataColumn FieldName="UserFullName" Caption="USER" VisibleIndex="5" />
                <dx:GridViewDataColumn FieldName="LastUpdate" Caption="LAST UPDATE" VisibleIndex="6" />
            </Columns>
        </dx:ASPxGridView>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="gvCasesInProcess" />
    </Triggers>
</asp:UpdatePanel>
