<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCIllustrationsLifeList.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.Illustration.UCIllustrationsLifeList" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Data.Linq" TagPrefix="dx" %>
<%@ Register Src="~/NewBusiness/UserControls/Illustration/UCPopupChangeStatusSaveNotes.ascx" TagPrefix="uc1" TagName="UCPopupChangeStatusSaveNotes" %>
<%@ Register Src="~/NewBusiness/UserControls/Illustration/UCIllustrationsPivot.ascx" TagPrefix="uc1" TagName="UCIllustrationsPivot" %>

<asp:UpdatePanel ID="udpIllustration" runat="server">
    <ContentTemplate>
        <div id="scroll_2" class="st-content-inner">
            <!--extra div para emular el left side fixed-->
            <!--CONTENIDO EMPIEZA AQUI-->
            <div class="main clearfix">
                <!--CONTENIDO DERECHA-->
                <div class="management_mc">
                    <!--wrapper de las columnas-->
                    <div class="accordion_tabulado">
                        <ul class="principal" id="acc1">
                            <li>
                                <a href="#" id="lnkIllustrationList" lnk="lnk" onclick="setCurrentAccordeon(this,'#hdnAccordeonIllustrationList');">
                                    <%=RESOURCE.UnderWriting.NewBussiness.Resources.InboxIllustrationsLife %><span><!--icono--></span>
                                </a>
                                <ul>
                                    <li>
                                        <div class="grid grid-pad">
                                            <div class="col-1-1">
                                                <div class="fondo_gris">
                                                    <div class="col-1-1">
                                                        <div class="content_fondo_gris">
                                                            <div class="grid_wrap">
                                                                <dx:ASPxGridView ID="gvIllustrationLife"
                                                                    runat="server" ClientIDMode="Static"
                                                                    KeyFieldName="CaseSeqNo;
                                                                                   CorpId;
                                                                                   RegionId;
                                                                                   CountryId;
                                                                                   DomesticregId;
                                                                                   StateProvId;
                                                                                   CityId;
                                                                                   OfficeId;
                                                                                   HistSeqNo;
                                                                                   CustomerPlanNo;
                                                                                   InsuredId;
                                                                                   IllustrationStatusCode;PlanGroupCode;AssignedSubscriberId"
                                                                    EnableCallBacks="False" AutoGenerateColumns="False" Width="1818px" OnPreRender="gvIllustrationLife_PreRender">
                                                                    <ClientSideEvents />
                                                                    <Columns>
                                                                        <dx:GridViewDataCheckColumn Width="2%" Caption="" VisibleIndex="0">
                                                                            <DataItemTemplate>
                                                                                <asp:CheckBox runat="server" ID="chkSelect" />
                                                                            </DataItemTemplate>
                                                                        </dx:GridViewDataCheckColumn>

                                                                        <dx:GridViewDataColumn Width="8%" Name="RequiredLabel" Caption="Required">
                                                                            <DataItemTemplate>
                                                                                <asp:Button runat="server" ID="btnRequired" CommandName="Required" CssClass="required_doc" />
                                                                            </DataItemTemplate>
                                                                            <Settings AllowHeaderFilter="False" AllowSort="False" />
                                                                        </dx:GridViewDataColumn>

                                                                        <dx:GridViewDataColumn Width="8%" Caption="Financial Clearance" Name="FinancialClearance">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <Settings AllowHeaderFilter="False" AllowSort="False" />
                                                                        </dx:GridViewDataColumn>

                                                                        <dx:GridViewDataTextColumn Width="7%" FieldName="FamilyProduct" Name="LineofBusinessLabel" Caption="Family Product" Settings-AutoFilterCondition="Contains" Settings-HeaderFilterMode="CheckedList" />
                                                                        <dx:GridViewDataTextColumn Width="11%" FieldName="PlanType" Name="PlanTypeLabel" Caption="PLAN TYPE" Settings-AutoFilterCondition="Contains" Settings-HeaderFilterMode="CheckedList" />
                                                                        <dx:GridViewDataTextColumn Width="12%" FieldName="IllustrationNo" Name="ILLUSTRATIONLABEL" Caption="ILLUSTRATION NUMBER" Settings-AutoFilterCondition="Contains" Settings-AllowHeaderFilter="False" />
                                                                        <dx:GridViewDataTextColumn Width="12%" FieldName="Status" Name="LiteralStatus" Caption="STATUS" CellStyle-Wrap="True" Settings-AutoFilterCondition="Contains" Settings-HeaderFilterMode="CheckedList" />
                                                                        <dx:GridViewDataTextColumn Width="12%" FieldName="Office" Name="Office" Caption="OFFICE" Settings-AutoFilterCondition="Contains" Settings-HeaderFilterMode="CheckedList" />
                                                                        <dx:GridViewDataTextColumn Width="12%" FieldName="Channel" Name="Channel" Caption="Channel" CellStyle-Wrap="True" Settings-AutoFilterCondition="Contains" />
                                                                        <dx:GridViewDataTextColumn Width="15%" FieldName="AgentName" Name="Vendor" Caption="Vendor Name" CellStyle-Wrap="True" Settings-AutoFilterCondition="Contains" />
                                                                        <dx:GridViewDataTextColumn Width="15%" FieldName="InsuredName" Name="INSURED" CellStyle-Wrap="True" Caption="NAME / LASTNAME" Settings-AutoFilterCondition="Contains" Settings-AllowHeaderFilter="False" />
                                                                        <dx:GridViewDataTextColumn Width="11%" FieldName="Identification" Name="ID" Caption="Identification" Settings-AutoFilterCondition="Contains" Settings-AllowHeaderFilter="False" />
                                                                        <dx:GridViewDataTextColumn Width="11%" FieldName="TotalPremiumF" Name="PremiumWithoutTax" Caption="Total Premium Without Tax" Settings-AutoFilterCondition="Contains" Settings-AllowHeaderFilter="False" CellStyle-HorizontalAlign="Right" />
                                                                        <dx:GridViewDataTextColumn Width="11%" FieldName="InitialPremiumF" Name="PaidPremium" Caption="Paid Premium" Settings-AutoFilterCondition="Contains" Settings-AllowHeaderFilter="False" CellStyle-HorizontalAlign="Right" />
                                                                        <dx:GridViewDataTextColumn Width="9%" FieldName="InsuredAmountF" Name="InsuredAmount" Caption="Insured Amount" Settings-AutoFilterCondition="Contains" Settings-AllowHeaderFilter="False" CellStyle-HorizontalAlign="Right" />

                                                                        <dx:GridViewDataTextColumn Width="9%" FieldName="IllustrationDate" Name="Illustration_Date" SortOrder="Ascending" SortIndex="1" Caption="Illustration Date" Settings-AutoFilterCondition="Contains" Settings-AllowHeaderFilter="False">
                                                                            <PropertiesTextEdit DisplayFormatString="dd-MMM-yyyy"></PropertiesTextEdit>
                                                                            <CellStyle HorizontalAlign="Center"></CellStyle>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                        </dx:GridViewDataTextColumn>

                                                                        <dx:GridViewDataTextColumn Width="9%" FieldName="ExpirationDate" Name="Expiration_Date" Caption="Expiration Date" Settings-AutoFilterCondition="Contains" Settings-AllowHeaderFilter="False">
                                                                            <PropertiesTextEdit DisplayFormatString="dd-MMM-yyyy"></PropertiesTextEdit>
                                                                            <CellStyle HorizontalAlign="Center"></CellStyle>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                        </dx:GridViewDataTextColumn>

                                                                        <dx:GridViewDataTextColumn Width="9%" FieldName="NewStatusDate" Name="NewStatusDate" Settings-AutoFilterCondition="Contains" Settings-AllowHeaderFilter="False">
                                                                            <PropertiesTextEdit DisplayFormatString="dd-MMM-yyyy"></PropertiesTextEdit>
                                                                            <CellStyle HorizontalAlign="Center"></CellStyle>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                        </dx:GridViewDataTextColumn>

                                                                        <dx:GridViewDataTextColumn Width="12%" FieldName="AssignedSubscriber" Name="Subscriber" Caption="Assigned Subscriber" CellStyle-Wrap="True" Settings-AutoFilterCondition="Equals" Settings-AllowHeaderFilter="False" />
                                                                        <dx:GridViewDataTextColumn FieldName="MissingDocuments" Name="MissingDocuments" Settings-AutoFilterCondition="Equals" Settings-AllowHeaderFilter="False" />
                                                                        <dx:GridViewDataTextColumn Width="4%" FieldName="AvailableDays" Name="Days" Caption="Days" Settings-AutoFilterCondition="Equals" Settings-AllowHeaderFilter="False" />
                                                                        <dx:GridViewDataColumn Width="5%" Name="Notes" Caption="NOTE">
                                                                            <DataItemTemplate>
                                                                                <asp:Button runat="server" CssClass="edit_file" ID="btnNote" CommandName="Note"></asp:Button>
                                                                            </DataItemTemplate>
                                                                            <Settings AllowHeaderFilter="False" AllowSort="False" />
                                                                        </dx:GridViewDataColumn>
                                                                    </Columns>
                                                                    <TotalSummary>
                                                                        <dx:ASPxSummaryItem FieldName="InsuredAmount" SummaryType="Sum" />
                                                                        <dx:ASPxSummaryItem FieldName="TotalPremium" SummaryType="Sum" />
                                                                        <dx:ASPxSummaryItem FieldName="InitialPremium" SummaryType="Sum" />
                                                                    </TotalSummary>
                                                                    <Settings
                                                                        HorizontalScrollBarMode="Visible"
                                                                        VerticalScrollableHeight="440"
                                                                        VerticalScrollBarMode="Visible"
                                                                        ShowGroupPanel="false"
                                                                        ShowFooter="true"
                                                                        ShowFilterRow="true"
                                                                        ShowHeaderFilterButton="true"
                                                                        ShowFilterRowMenu="true"
                                                                        ShowFilterRowMenuLikeItem="false"
                                                                        ShowFilterBar="Auto" />
                                                                    <SettingsBehavior ColumnResizeMode="Control" AllowFocusedRow="true" />
                                                                    <SettingsPager PageSize="50" AlwaysShowPager="true">
                                                                        <PageSizeItemSettings Visible="true" ShowAllItem="true" />
                                                                    </SettingsPager>
                                                                    <SettingsPopup>
                                                                        <HeaderFilter Height="200" />
                                                                    </SettingsPopup>
                                                                    <SettingsDataSecurity AllowInsert="false" AllowEdit="false" AllowDelete="false" />
                                                                </dx:ASPxGridView>
                                                                <asp:HiddenField runat="server" ID="hdnSelectedRowVisibleIndex" ClientIDMode="Static" />
                                                                <asp:HiddenField runat="server" ID="hdnQuotationTabs" ClientIDMode="Static" />

                                                                <asp:HiddenField runat="server" ID="hdnInsuredAmount" ClientIDMode="Static" />
                                                                <asp:HiddenField runat="server" ID="hdnTotalPremium" ClientIDMode="Static" />
                                                                <asp:HiddenField runat="server" ID="hdnInitialPremium" ClientIDMode="Static" />

                                                                <asp:Button runat="server" ID="btnSelectedRow" ClientIDMode="Static" Style="display: none;" />
                                                            </div>
                                                            <!--grid_wrap-->
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-1-1">
                                                <div class="barra_sub_menu">
                                                    <div class="grupos de_4_b last">
                                                        <div class="grupos de_6">
                                                            <div class="fr">
                                                                <div class="btn_celeste">
                                                                    <span class="add_ilustracion"></span>
                                                                    <asp:Button runat="server" CssClass="boton" ID="btnPrintListToExcellLife" Text="EXPORT TO EXCEL" OnClick="btnPrintListToExcellLife_Click"  />
                                                                </div>
                                                                <!--btn_celeste-->
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                </ul>
                            </li>
                        </ul>
                    </div>

                </div>

            </div>

           <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="gvIllustrationLife"></dx:ASPxGridViewExporter>
        </div>

        <asp:HiddenField runat="server" ID="hdnLineOfBusiness" />
        <asp:HiddenField runat="server" ID="hdnIsLoad" Value="false" />
        <asp:HiddenField runat="server" ID="hdnAccordeonIllustrationList" Value="acc1|0" ClientIDMode="Static" />
        <asp:HiddenField runat="server" ID="hdnAccordeonFiltersList" Value="acc2|0" ClientIDMode="Static" />
        <asp:HiddenField runat="server" ID="hdnValidate" ClientIDMode="Static" Value="true" />
        <asp:HiddenField runat="server" ID="hdnTabSelected" ClientIDMode="Static" Value="" />
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btnPrintListToExcellLife" />
    </Triggers>
</asp:UpdatePanel> 