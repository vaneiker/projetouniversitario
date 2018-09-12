<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUCApprovedCases.ascx.cs" Inherits="WEB.NewBusiness.DReview.UserControl.HistoricalCases.WUCApprovedCases" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Data.Linq" TagPrefix="dx" %>
<%@ Register Src="~/NewBusiness/UserControls/Common/UCNotesComments.ascx" TagPrefix="uc1" TagName="UCNotesComments" %>
<asp:UpdatePanel runat="server" ID="udpApprovedCases">
    <ContentTemplate>
        <dx:ASPxGridView ID="gvApprovedCases"
            KeyFieldName="CorpId;RegionId;CountryId;ProductNameKey;DomesticregId;StateProvId;CityId;OfficeId;CaseSeqNo;HistSeqNo ;InsuredContactId;InsuredAddContactId ;AgentId ;CompanyDesc ;PolicyNo ;ProductDesc ;UserName;InsuredFullName;CountryDesc ;OfficeDesc ;AgentFullName ;Exception ;SubmitDate ;ChangeDate; TimeChange ;OwnerContactId ;DesignatedPensionerContactId ;StudentContactId ;PaymentId"
            runat="server" ClientIDMode="Static"
            EnableCallBacks="False" DataSourceID="LinqDS" Width="100%" AutoGenerateColumns="False" OnRowCommand="gvApprovedCases_RowCommand" OnPreRender="gvApprovedCases_PreRender">
            <Settings ShowFilterRow="true" ShowFilterBar="Auto" ShowHeaderFilterButton="true" ShowFilterRowMenu="true" ShowFilterRowMenuLikeItem="false" />
            <Columns>
                <dx:GridViewDataCheckColumn Caption="" VisibleIndex="0" Width="35px">
                    <DataItemTemplate>
                        <asp:CheckBox ID="chkSelect" runat="server" Checked="false" />
                    </DataItemTemplate>
                </dx:GridViewDataCheckColumn>
                <dx:GridViewDataTextColumn FieldName="CompanyDesc" Caption="COMPANY" Width="10%" Name="Company"/>
                <dx:GridViewDataTextColumn FieldName="PolicyNo" Caption="POLICY" Name="PolicyNoLabel"/>
                <dx:GridViewDataTextColumn FieldName="ProductDesc" Caption="PLAN"  Name="PlanLabel"/>
                <dx:GridViewDataTextColumn FieldName="InsuredFullName" Caption="INSURED NAME"  Width="18%" Name="InsuredName"/>
                <dx:GridViewDataTextColumn FieldName="CountryDesc" Caption="COUNTRY" Name="CountryLabel"/>
                <dx:GridViewDataTextColumn FieldName="OfficeDesc" Caption="OFFICE" Name="Office"/>
                <dx:GridViewDataTextColumn FieldName="AgentFullName" Caption="AGENT NAME"  Width="18%" Name="AgentNameLabel"/>
                <dx:GridViewDataTextColumn FieldName="Exception" Caption="EXCEPTION" Name="Exception"/>
                <dx:GridViewDataDateColumn FieldName="SubmitDate" Caption="SUBMITTED DATE" Name="SubmitDate"/>
                <dx:GridViewDataDateColumn FieldName="ChangeDate" Caption="APPROVED DATE" Name="APPROVEDDATE"/>
                <dx:GridViewDataTextColumn FieldName="UserName" Caption="USER" Name="USER"/>
                <dx:GridViewDataColumn Caption="VIEW" Width="5%" Name="View"  Visible="false">
                    <DataItemTemplate>
                        <asp:Button runat="server" CssClass="view_file" ID="btnViewFile" CommandName="view" Width="50px"></asp:Button>
                    </DataItemTemplate>
                    <Settings AllowHeaderFilter="False" AllowSort="False" />
                </dx:GridViewDataColumn>
                <dx:GridViewDataColumn Caption="COMMENT" Width="5%" Name="Comment">
                    <DataItemTemplate>                          
                         <asp:UpdatePanel runat="server" ID="udpBtncomment">
                             <ContentTemplate>
                                    <asp:Button runat="server" CssClass="coment_file" ID="btnComment" CommandName="comment" Width="50px"></asp:Button>
                             </ContentTemplate>
                             <Triggers>
                                <asp:PostBackTrigger  ControlID="btnComment" />
                             </Triggers>
                         </asp:UpdatePanel> 
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
        <dx:LinqServerModeDataSource OnSelecting="LinqDS_Selecting" ID="LinqDS" runat="server" DefaultSorting="SubmitDate"/>
        <dx:ASPxGridView ID="gvFakeGridView"
            runat="server" ClientIDMode="Static" Visible="false">                        
            <Columns>                               
                <dx:GridViewDataTextColumn FieldName="CompanyDesc" Caption="COMPANY" />
                <dx:GridViewDataTextColumn FieldName="PolicyNo" Caption="POLICY" />
                <dx:GridViewDataTextColumn FieldName="ProductDesc" Caption="PLAN" />
                <dx:GridViewDataTextColumn FieldName="InsuredFullName" Caption="INSURED NAME" />
                <dx:GridViewDataTextColumn FieldName="CountryDesc" Caption="COUNTRY" />
                <dx:GridViewDataTextColumn FieldName="OfficeDesc" Caption="OFFICE" />
                <dx:GridViewDataTextColumn FieldName="AgentFullName" Caption="AGENT NAME" />
                <dx:GridViewDataDateColumn FieldName="Exception" Caption="EXCEPTION" />
                <dx:GridViewDataDateColumn FieldName="SubmitDate" Caption="SUBMITTED DATE" />
                <dx:GridViewDataDateColumn FieldName="ChangeDate" Caption="APPROVED DATE" />
                <dx:GridViewDataTextColumn FieldName="UserName" Caption="USER" />                
            </Columns>            
        </dx:ASPxGridView>

        <dx:ASPxGridViewExporter ID="ASPxGridViewExporter2" runat="server" GridViewID="gvFakeGridView"></dx:ASPxGridViewExporter>
        <asp:HiddenField runat="server" ClientIDMode="Static" ID="hdnShowAddNewNoteApprovedCases" Value="false" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="gvApprovedCases" />
    </Triggers>
</asp:UpdatePanel>
<div id="dvAddNoteComentsHistoricalCases" style="display: none">
    <uc1:UCNotesComments runat="server" ID="UCNotesComments" />
</div>
