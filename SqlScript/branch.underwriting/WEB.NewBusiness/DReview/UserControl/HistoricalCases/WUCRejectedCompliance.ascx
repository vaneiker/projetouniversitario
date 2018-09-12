<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUCRejectedCompliance.ascx.cs" Inherits="WEB.NewBusiness.DReview.UserControl.HistoricalCases.WUCRejectedCompliance" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Data.Linq" TagPrefix="dx" %>
<%@ Register Src="~/NewBusiness/UserControls/Common/UCNotesComments.ascx" TagPrefix="uc1" TagName="UCNotesComments" %>
<asp:UpdatePanel runat="server" ID="udpRejectByCompliance">
    <ContentTemplate>
        <dx:ASPxGridView ID="gvRejectedByCompliance"
            KeyFieldName="CorpId ;RegionId ;CountryId ;DomesticregId ;StateProvId ;ProductNameKey;CityId ;OfficeId ;CaseSeqNo ;HistSeqNo ;InsuredContactId ;AgentId ;CompanyDesc ;PolicyNo ;ProductDesc ;UserName ;InsuredFullName ;CountryDesc ;OfficeDesc ;AgentFullName ;Exception ;SubmitDate ;ChangeDate ;TimeChange ;OwnerContactId ;InsuredAddContactId ;DesignatedPensionerContactId ;StudentContactId ;PaymentId"
            runat="server" ClientIDMode="Static" DataSourceID="LinqDS" EnableCallBacks="False" Width="100%" AutoGenerateColumns="false" OnRowCommand="gvRejectedByCompliance_RowCommand" OnPreRender="gvRejectedByCompliance_PreRender">
            <SettingsBehavior AllowSort="true" />
            <Settings ShowFilterRow="true" ShowFilterBar="Auto" ShowHeaderFilterButton="true" ShowFilterRowMenu="true" ShowFilterRowMenuLikeItem="false" />
            <Columns>
                <dx:GridViewDataCheckColumn Caption="" VisibleIndex="0" Width="35px">
                    <DataItemTemplate>
                        <asp:CheckBox ID="chkSelect" runat="server" Checked="false" />
                    </DataItemTemplate>
                </dx:GridViewDataCheckColumn>

                <dx:GridViewDataColumn Caption="" VisibleIndex="1" Width="4%" >
                  <DataItemTemplate>
                     <asp:Button runat="server" CssClass="reject_file" OnClientClick="return false" ToolTip="Caso rechazado debido a que un contacto de la cotizacion tiene un status Match" />
                  </DataItemTemplate>
                 </dx:GridViewDataColumn>

                <dx:GridViewDataTextColumn FieldName="CompanyDesc" Caption="COMPANY" Name="Company" />
                <dx:GridViewDataTextColumn FieldName="PolicyNo" Caption="POLICY" Name="PolicyNoLabel" />
                <dx:GridViewDataTextColumn FieldName="ProductDesc" Caption="PLAN" Name="PlanLabel" />
                <dx:GridViewDataTextColumn FieldName="InsuredFullName" Caption="INSURED NAME" Name="InsuredName" />
                <dx:GridViewDataTextColumn FieldName="CountryDesc" Caption="COUNTRY" Name="CountryLabel" />
                <dx:GridViewDataTextColumn FieldName="OfficeDesc" Caption="OFFICE" Name="Office" />
                <dx:GridViewDataTextColumn FieldName="AgentFullName" Caption="AGENT NAME" Name="AgentNameLabel" />
                <dx:GridViewDataTextColumn FieldName="Exception" Caption="EXCEPTION" Name="Exception" Visible="false" />
                <dx:GridViewDataDateColumn FieldName="SubmitDate" Caption="SUBMITTED DATE" Name="SubmitDate" />
                <dx:GridViewDataDateColumn FieldName="ChangeDate" Caption="REJECTED DATE" Name="REJECTEDDATE" Visible="false" />
                <dx:GridViewDataTextColumn FieldName="UserName" Caption="USER" Name="USER" />
                <dx:GridViewDataColumn Caption="VIEW" Width="5%" Name="View" Visible="false">
                    <DataItemTemplate>
                        <asp:Button runat="server" CssClass="view_file" ID="btnViewFile" CommandName="view" Width="50px"></asp:Button>
                    </DataItemTemplate>
                    <Settings AllowHeaderFilter="False" AllowSort="False" />
                </dx:GridViewDataColumn>
                <dx:GridViewDataColumn Caption="COMMENT" Width="5%" Name="Comment">
                    <DataItemTemplate>
                        <asp:UpdatePanel runat="server" ID="udpBtnComment">
                            <ContentTemplate>
                                <asp:Button runat="server" CssClass="coment_file" ID="btnComment" CommandName="comment" Width="50px"></asp:Button>
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="btnComment" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </DataItemTemplate>
                    <Settings AllowHeaderFilter="False" AllowSort="False" />
                </dx:GridViewDataColumn>

                <dx:GridViewDataColumn Caption="ENVIAR A REVISION"  Width="4%" VisibleIndex="12" >
                  <DataItemTemplate>
                     <asp:Button runat="server" CssClass="upload_file" ToolTip="Regresar el Caso a Revision de Datos" CommandName="regresar" />
                  </DataItemTemplate>
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

        <dx:ASPxGridView ID="gvFakeGridView" runat="server" Visible="false">
            <Columns>
                <dx:GridViewDataTextColumn FieldName="CompanyDesc" Caption="COMPANY" />
                <dx:GridViewDataTextColumn FieldName="PolicyNo" Caption="POLICY" />
                <dx:GridViewDataTextColumn FieldName="ProductDesc" Caption="PLAN" />
                <dx:GridViewDataTextColumn FieldName="InsuredFullName" Caption="INSURED NAME" />
                <dx:GridViewDataTextColumn FieldName="CountryDesc" Caption="COUNTRY" />
                <dx:GridViewDataTextColumn FieldName="OfficeDesc" Caption="OFFICE" />
                <dx:GridViewDataTextColumn FieldName="AgentFullName" Caption="AGENT NAME" />
                <%--<dx:GridViewDataTextColumn FieldName="Exception" Caption="EXCEPTION" />--%>
                <dx:GridViewDataDateColumn FieldName="SubmitDate" Caption="SUBMITTED DATE" />
                <%--<dx:GridViewDataDateColumn FieldName="ChangeDate" Caption="REJECTED DATE" />--%>
                <dx:GridViewDataTextColumn FieldName="UserName" Caption="USER" />
            </Columns>
        </dx:ASPxGridView>

        <dx:LinqServerModeDataSource OnSelecting="LinqDS_Selecting" ID="LinqDS" runat="server" DefaultSorting="SubmitDate" />
        <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="gvFakeGridView"></dx:ASPxGridViewExporter>
        <asp:HiddenField runat="server" ID="hdnShowAddNewNoteRejectedCases" ClientIDMode="Static" Value="false" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="gvRejectedByCompliance" />
    </Triggers>
</asp:UpdatePanel>

<div id="dvAddNoteComentsHistoricalCases" style="display: none">
    <uc1:UCNotesComments runat="server" ID="UCNotesComments" />
</div>

