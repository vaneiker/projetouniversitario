<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUCEffectivePendingReceipt.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.SubmittedPolicies.WUCEffectivePendingReceipt" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Src="~/NewBusiness/UserControls/SubmittedPolicies/WUCUploadReceiptPopup.ascx" TagPrefix="uc1" TagName="WUCUploadReceiptPopup" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:UpdatePanel runat="server" ID="udpEffectivePendingReceipt" RenderMode="Inline">
    <ContentTemplate>
        <div class="titulos_sin_accion"></div>
        <div class="fondo_gris">
            <div class="col-1-1">
                <div class="content_fondo_gris">
                    <div class="grid_wrap">
                        <dx:ASPxGridView ID="gvEffectivePendingReceipt"
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
                                         DaysLate;
                                         Status;
                                         OwnerContactId;
                                         InsuredContactId;
                                         PolicyNo;
                                         RequirementCatId;
                                         RequirementTypeId;
                                         RequirementId;
                                         AmmendmentId;
                                         IsAmmendReq;
                                         AmmendmentDate;"
                            runat="server" ClientIDMode="Static" EnableCallBacks="False" Width="100%" AutoGenerateColumns="false" OnBeforeColumnSortingGrouping="gvEffectivePendingReceipt_BeforeColumnSortingGrouping" OnPageIndexChanged="gvEffectivePendingReceipt_PageIndexChanged" OnRowCommand="gvEffectivePendingReceipt_RowCommand" OnPreRender="gvEffectivePendingReceipt_PreRender">
                            <SettingsBehavior AllowSort="true" />
                            <Columns>
                                <dx:GridViewDataColumn Caption="" VisibleIndex="0">
                                    <DataItemTemplate>
                                        <asp:CheckBox runat="server" ID="chkSelect" Style="position: relative; left: 40%;" />
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataTextColumn FieldName="PolicyNo" Caption="POLICY" VisibleIndex="1" Name="PolicyLabel"/>
                                <dx:GridViewDataTextColumn FieldName="ProductDesc" Caption="PLAN" VisibleIndex="2" Name="PlanLabel"/>
                                <dx:GridViewDataTextColumn FieldName="InsuranceFullName" Caption="INSURED" VisibleIndex="3" Width="20%" Name="INSURED"/>
                                <dx:GridViewDataTextColumn FieldName="OwnerFullName" Caption="OWNER" VisibleIndex="4" Width="20%" Name="OwnerLabel"/>
                                <dx:GridViewDataTextColumn FieldName="AgentFullName" Caption="AGENT" VisibleIndex="5" Width="20%" Name="AGENT"/>
                                <dx:GridViewDataTextColumn FieldName="DaysLate" Caption="DAYS LATE" VisibleIndex="6" Name="DaysLate"/>
                                <dx:GridViewDataTextColumn FieldName="Status" Caption="STATUS" CellStyle-HorizontalAlign="Center" VisibleIndex="7" Name="Status">
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataDateColumn FieldName="EffectiveDate" Caption="EFFECTIVE DATE"  VisibleIndex="8" CellStyle-HorizontalAlign="Center" Name="EffectiveDate">
                                    <PropertiesDateEdit DisplayFormatString="MM/dd/yyyy"></PropertiesDateEdit>
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataColumn Caption="UPLOAD" VisibleIndex="10" Width="4%" Name="UPLOAD">
                                    <DataItemTemplate>
                                        <asp:Button runat="server" CssClass="upload_file" ID="btnUploadFile" CommandName="Upload"></asp:Button>
                                    </DataItemTemplate>
                                    <Settings AllowHeaderFilter="False" AllowSort="False" />
                                </dx:GridViewDataColumn>
                            </Columns>                           
                            <SettingsBehavior ColumnResizeMode="NextColumn" />
                            <SettingsPopup>
                                <HeaderFilter Height="200" />
                            </SettingsPopup>
                            <SettingsDataSecurity AllowInsert="false" AllowEdit="false" AllowDelete="false" />
                        </dx:ASPxGridView>
                        <dx:ASPxGridViewExporter ID="Exporter" runat="server" GridViewID="gvFakeGridView"></dx:ASPxGridViewExporter>
                        <dx:ASPxGridView ID="gvFakeGridView" runat="server" EnableCallBacks="False" Width="100%" AutoGenerateColumns="False" Visible="false"
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
                                         DaysLate;
                                         Status">
                            <Columns>
                                <dx:GridViewDataTextColumn FieldName="PolicyNo" Caption="POLICY" VisibleIndex="1" />
                                <dx:GridViewDataTextColumn FieldName="ProductDesc" Caption="PLAN" VisibleIndex="2" />
                                <dx:GridViewDataTextColumn FieldName="InsuranceFullName" Caption="INSURED" VisibleIndex="3" />
                                <dx:GridViewDataTextColumn FieldName="OwnerFullName" Caption="OWNER" VisibleIndex="4" />
                                <dx:GridViewDataTextColumn FieldName="AgentFullName" Caption="AGENT" VisibleIndex="5" />
                                <dx:GridViewDataTextColumn FieldName="DaysLate" Caption="DAYS LATE" VisibleIndex="6" />
                                <dx:GridViewDataTextColumn FieldName="Status" Caption="STATUS" CellStyle-HorizontalAlign="Center" VisibleIndex="7" />
                                <dx:GridViewDataTextColumn FieldName="EffectiveDate" Caption="EFFECTIVE DATE" VisibleIndex="8" />
                            </Columns>
                             <SettingsBehavior ColumnResizeMode="NextColumn" />
                            <SettingsPopup>
                                <HeaderFilter Height="200" />
                            </SettingsPopup>
                            <SettingsDataSecurity AllowInsert="false" AllowEdit="false" AllowDelete="false" />
                            <Settings VerticalScrollableHeight="470" VerticalScrollBarMode="Visible" />
                        </dx:ASPxGridView>
                    </div>
                </div>
                <!--grid_wrap-->
            </div>
            <!--content_fondo_gris-->
        </div>
        <!--col-1-1-->
        </div>  

        <asp:HiddenField ID="hdnAmmendmentDate" ClientIDMode="Static" runat="server" />
        <asp:HiddenField ID="hdnShowPopReceipt" runat="server" Value="false" ClientIDMode="Static" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="gvEffectivePendingReceipt" />
    </Triggers>
</asp:UpdatePanel>

<asp:Button ID="btnShowPopup" Style="display: none" runat="server" Text="ShowPopup" />
<asp:ModalPopupExtender ID="ModalPopupExtender2" PopupControlID="pdfUploadPanel" DropShadow="false" BackgroundCssClass="ModalBackgroud3" TargetControlID="btnShowPopup" BehaviorID="popupBhvr" runat="server"></asp:ModalPopupExtender>
<asp:Panel runat="server" ID="pdfUploadPanel" CssClass="modalPopup" Style="display: none">
    <uc1:WUCUploadReceiptPopup runat="server" ID="WUCUploadReceiptPopup" />
</asp:Panel>


