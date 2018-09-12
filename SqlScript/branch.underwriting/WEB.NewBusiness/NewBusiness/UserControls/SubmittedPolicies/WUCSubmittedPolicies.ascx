<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUCSubmittedPolicies.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.SubmittedPolicies.WUCSubmittedPolicies" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Src="~/NewBusiness/UserControls/Common/UCNotesComments.ascx" TagPrefix="uc1" TagName="UCNotesComments" %>
<asp:UpdatePanel runat="server" ID="udpSubmittedPolicies" RenderMode="Inline">
    <ContentTemplate>
        <div class="titulos_sin_accion"></div>
        <div class="fondo_gris">
            <div class="col-1-1">
                <div class="content_fondo_gris">
                    <div class="grid_wrap">
                        <dx:ASPxGridView ID="gvSubmittedPolcies"
                            KeyFieldName="CorpId ;
                                         RegionId ;
                                         CountryId ;
                                         DomesticregId ;
                                         StateProvId ;
                                         CityId ;
                                         OfficeId ;
                                         CaseSeqNo ;
                                         HistSeqNo ;                                         
                                         AgentId;
                                         DaysPending"
                            runat="server" ClientIDMode="Static" EnableCallBacks="False" Width="100%" AutoGenerateColumns="false" OnRowCommand="gvSubmittedPolcies_RowCommand" OnBeforeColumnSortingGrouping="gvSubmittedPolcies_BeforeColumnSortingGrouping" OnPageIndexChanged="gvSubmittedPolcies_PageIndexChanged" OnPreRender="gvSubmittedPolcies_PreRender">
                            <SettingsBehavior AllowSort="true" />
                            <Columns>
                                <dx:GridViewDataCheckColumn Caption="" VisibleIndex="0" Width="3%">
                                    <DataItemTemplate>
                                        <asp:CheckBox runat="server" ID="chkSelect"/>
                                    </DataItemTemplate>
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewDataTextColumn FieldName="OfficeDesc" Caption="OFFICE" Name="Office"/>
                                <dx:GridViewDataTextColumn FieldName="PolicyNo" Caption="POLICY" Name="PolicyLabel"/>
                                <dx:GridViewDataTextColumn FieldName="ProductDesc" Caption="PLAN" Name="PlanLabel"/>
                                <dx:GridViewDataTextColumn FieldName="UserName" Caption="USER" Name="USER"/>
                                <dx:GridViewDataTextColumn FieldName="InsuredFullName" Caption="INSURED" Name="INSURED"/>
                                <dx:GridViewDataTextColumn FieldName="OwnerFullName" Caption="OWNER" Name="OwnerLabel"/>
                                <dx:GridViewDataTextColumn FieldName="AgentFullName" Caption="AGENT" Name="AGENT"/>
                                <dx:GridViewDataTextColumn FieldName="SubmitDate" Caption="SUBMITTED TO STL" Name="SUBMITEDTOSTL"/>
                                <dx:GridViewDataColumn Caption="COMMENT" VisibleIndex="9" Width="80px" Name="Comment">
                                    <DataItemTemplate>
                                        <asp:Button runat="server" CssClass="coment_file" CommandName="Comment" ID="btnComment"></asp:Button>
                                    </DataItemTemplate>
                                    <Settings AllowHeaderFilter="False" AllowSort="False" />
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataTextColumn FieldName="DaysPending" Caption="DAYS PROCESSING" CellStyle-HorizontalAlign="Center"  Name="DaysProcessing"/>
                            </Columns>                    
                            <SettingsBehavior ColumnResizeMode="NextColumn" />
                            <SettingsPopup>
                                <HeaderFilter Height="200" />
                            </SettingsPopup>
                            <SettingsDataSecurity AllowInsert="false" AllowEdit="false" AllowDelete="false" />
                            <Settings VerticalScrollableHeight="470" VerticalScrollBarMode="Visible" />
                        </dx:ASPxGridView>
                    </div>
                    <!--grid_wrap-->
                </div>
                <!--content_fondo_gris-->
            </div>
            <!--col-1-1-->
        </div>
        <dx:ASPxGridViewExporter ID="Exporter" runat="server" GridViewID="gvFakeGridView"></dx:ASPxGridViewExporter>
        <dx:ASPxGridView ID="gvFakeGridView" runat="server" EnableCallBacks="False" Width="100%" AutoGenerateColumns="False" Visible="false"
            KeyFieldName="OfficeDesc;
                          PolicyNo;
                          ProductDesc;
                          UserName;
                          InsuredFullName;
                          OwnerFullName;
                          AgentFullName;
                          SubmitDate;
                          DaysPending">
            <Columns>
                <dx:GridViewDataTextColumn FieldName="OfficeDesc" Caption="OFFICE" />
                <dx:GridViewDataTextColumn FieldName="PolicyNo" Caption="POLICY" />
                <dx:GridViewDataTextColumn FieldName="ProductDesc" Caption="PLAN" />
                <dx:GridViewDataTextColumn FieldName="UserName" Caption="USER" />
                <dx:GridViewDataTextColumn FieldName="InsuredFullName" Caption="INSURED" />
                <dx:GridViewDataTextColumn FieldName="OwnerFullName" Caption="OWNER" />
                <dx:GridViewDataTextColumn FieldName="AgentFullName" Caption="AGENT" />
                <dx:GridViewDataTextColumn FieldName="SubmitDate" Caption="SUBMITTED TO STL" />
                <dx:GridViewDataTextColumn FieldName="DaysPending" Caption="DAYS PROCESSING" CellStyle-HorizontalAlign="Center" />
            </Columns>
        </dx:ASPxGridView>
        <asp:HiddenField runat="server" ID="hdnShowPopAddCommment" ClientIDMode="Static" Value="false" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="gvSubmittedPolcies" />
    </Triggers>
</asp:UpdatePanel>

<div id="dvPopAddComment" style="display: none; padding: 0">
    <uc1:UCNotesComments runat="server" ID="UCNotesComments" />
</div>

