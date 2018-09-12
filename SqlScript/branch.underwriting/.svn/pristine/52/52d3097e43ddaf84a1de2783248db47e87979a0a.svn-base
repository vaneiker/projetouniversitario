<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUCReadyToReview.ascx.cs" Inherits="WEB.NewBusiness.DReview.UserControl.CasesNotSubmitted.ReadyToreview.WUCReadyToReview" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Src="~/NewBusiness/UserControls/Common/UCNotesComments.ascx" TagPrefix="uc1" TagName="UCNotesComments" %>
<asp:UpdatePanel runat="server" ID="udpReadyToReview" UpdateMode="Conditional">
    <ContentTemplate>
        <div class="titulos_sin_accion02" runat="server" id="Search">SEARCH</div>
        <asp:Panel runat="server" class="barra1 no_padding" DefaultButton="btnSearch">
            <div class="filter">
                <div class="grupos de_7">
                    <div>
                        <label class="label" runat="server" id="Policy">Policy</label>
                        <asp:TextBox runat="server" ID="txtPolicy" ClientIDMode="Static" Policy="Policy" />
                    </div>
                    <div>
                        <label class="label" runat="server" id="Plan">Plan</label>
                        <div class="wrap_select">
                            <asp:DropDownList runat="server" ID="ddlPlan" ClientIDMode="Static">
                            </asp:DropDownList>
                        </div>
                        <!--wrap_select-->
                    </div>
                    <div>
                        <label class="label" runat="server" id="From">From</label>
                        <asp:TextBox runat="server" ID="FromTxt" CssClass="RTRdatepickerFrom datepicker_03" ClientIDMode="Static"/>
                    </div>
                    <div>
                        <label class="label" runat="server" id="To">To</label>
                        <asp:TextBox runat="server" ID="ToTxt" CssClass="RTRdatepickerTo datepicker_03" ClientIDMode="Static"/>
                    </div>
                    <div>
                        <label class="label" runat="server" id="AgentName">Agent Name</label>
                        <div class="wrap_select">
                            <asp:DropDownList runat="server" ID="ddlAgents" ClientIDMode="Static">
                            </asp:DropDownList>
                        </div>
                        <!--wrap_select-->
                    </div>
                    <div>
                        <label class="label" runat="server" id="InsuredName">Insured Name</label>
                        <asp:TextBox runat="server" ID="InsuredNameTxt" ClientIDMode="Static" alphabetical='alphabetical' AllowEnter="true" />
                    </div>
                    <div>
                        <label class="label" runat="server" id="OwnerName">Owner Name</label>
                        <asp:TextBox runat="server" ID="OwnerNameTxt" ClientIDMode="Static" alphabetical='alphabetical' AllowEnter="true"/>
                    </div>
                </div>
                <!--grupos-->

                <div class="grupos">
                    <div class="float_right">
                        <div class="boton_wrapper verde">
                            <span class=" search"></span>
                            <asp:Button CssClass="boton" Text="Search" runat="server" ID="btnSearch" OnClientClick="return validateFilter(this)" ClientIDMode="Static" OnClick="btnSearch_Click" />
                        </div>
                        <div class="boton_wrapper gris">
                            <span class="borrar"></span>
                            <asp:Button CssClass="boton" Text="Clear" ID="btnClear" runat="server" OnClick="btnClear_Click" />
                        </div>
                    </div>
                </div>
                <!--grupos-->

            </div>
            <!--filter-->
        </asp:Panel>
        <!--barra1-->

        <div class="titulos_sin_accion" runat="server" id="ReadyToReview">READY TO REVIEW</div>
        <div class="fondo_gris">
            <div class="col-1-1">
                <div class="content_fondo_gris">
                    <div class="grid_wrap">
                        <dx:ASPxGridView ID="gvReadyToReview" runat="server"
                            KeyFieldName="OwnerContactId;
                                        CaseSeqNo;
                                        CorpId;
                                        RegionId;
                                        CountryId;
                                        DomesticregId;
                                        StateProvId;
                                        CityId;
                                        OfficeId;
                                        HistSeqNo;
                                        PolicyNo;
                                        AgentId;
                                        DesignatedPensionerContactId;
                                        InsuredContactId;
                                        StudentNameContactId;                                                  
                                        ProductDesc;
                                        OwnerFullName;
                                        InsuranceFullName;
                                        AgentFullName;
                                        UserFullName;
                                        ProductNameKey;
                                        LastUpdate;
                                        AddInsuredContactId;
                                        PaymentId"
                            OnRowCommand="gvReadyToReview_RowCommand1" ClientIDMode="Static" OnPageIndexChanged="gvReadyToReview_PageIndexChanged" OnBeforeColumnSortingGrouping="gvReadyToReview_BeforeColumnSortingGrouping" OnPageSizeChanged="gvReadyToReview_PageSizeChanged" OnPreRender="gvReadyToReview_PreRender">
                            <ClientSideEvents BeginCallback="function(){BeginRequestHandler();}" EndCallback="function(){ pageLoad(); EndRequestHandler(); }" />
                            <Columns>
                                <dx:GridViewDataColumn Caption="POLICY" FieldName="PolicyNo" VisibleIndex="1" Name="PolicyLabel"/>
                                <dx:GridViewDataColumn Caption="PLAN" FieldName="ProductDesc" VisibleIndex="2" Name="PlanLabel"/>
                                <dx:GridViewDataColumn Caption="INSURED NAME" FieldName="InsuranceFullName" VisibleIndex="3" Name="INSURED"/>
                                <dx:GridViewDataColumn Caption="OWNER" FieldName="OwnerFullName" VisibleIndex="4" Name="OwnerLabel" />
                                <dx:GridViewDataTextColumn FieldName="CountryDesc" Caption="COUNTRY" VisibleIndex="4" Name="CountryLabel"/>
                                <dx:GridViewDataTextColumn FieldName="OfficeDesc" Caption="OFFICE" VisibleIndex="5" Width="4%" Name="Office"/>
                                <dx:GridViewDataColumn Caption="AGENT NAME" FieldName="AgentFullName" VisibleIndex="6" Name="AGENT"/>
                                <dx:GridViewDataTextColumn FieldName="Exception" Caption="EXCEPTION" VisibleIndex="7" Width="5%" Name="Exception"/>
                                <dx:GridViewDataColumn Caption="USER" FieldName="UserFullName" VisibleIndex="8" Name="USER"/>
                                <dx:GridViewDataDateColumn Caption="LAST UPDATE" FieldName="LastUpdate" VisibleIndex="9" Width="7%" Name="LastUpdateLabel"/>
                                <dx:GridViewDataColumn Caption="VIEW" VisibleIndex="10" Width="4%" Name="View">
                                    <DataItemTemplate>
                                        <asp:Button runat="server" CssClass="view_file" ID="btnViewFile" CommandName="View"></asp:Button>
                                    </DataItemTemplate>
                                    <Settings AllowHeaderFilter="False" AllowSort="False" />
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="PAYMENT" VisibleIndex="11" Width="4%" Name="PaymentsLabel">
                                    <DataItemTemplate>
                                        <asp:Button runat="server" CssClass='<%# bool.Parse(Eval("IsPaymentCompleted").ToString())?"payment_fileDisabled":"payment_file" %>' ID="btnPayment" CommandName="Payment" OnClientClick="return false;"></asp:Button>
                                    </DataItemTemplate>
                                    <Settings AllowHeaderFilter="False" AllowSort="False" />
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="COMMENT" VisibleIndex="12" Width="5%" Name="Comment">
                                    <DataItemTemplate>
                                        <asp:UpdatePanel runat="server" ID="udpBtncomment">
                                            <ContentTemplate>
                                                 <asp:Button runat="server" CssClass="coment_file" ID="btnComment" CommandName="Comment"></asp:Button>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:PostBackTrigger ControlID="btnComment" />
                                            </Triggers>
                                            </asp:UpdatePanel>                                         
                                    </DataItemTemplate>
                                    <Settings AllowHeaderFilter="False" AllowSort="False" />
                                </dx:GridViewDataColumn>
                            </Columns>
                              <SettingsBehavior ColumnResizeMode="NextColumn" />
                            <Settings VerticalScrollableHeight="480" VerticalScrollBarMode="Visible" />
                            <SettingsPager PageSize="15" AlwaysShowPager="true">
                                <PageSizeItemSettings Visible="true" ShowAllItem="true" />
                            </SettingsPager>
                            <SettingsPopup>
                                <HeaderFilter Height="200" />
                            </SettingsPopup>
                            <SettingsDataSecurity AllowInsert="false" AllowEdit="false" AllowDelete="false" />                            
                        </dx:ASPxGridView>
                        <dx:ASPxGridView ID="gvFakeGridView" runat="server" EnableCallBacks="False" Width="100%" AutoGenerateColumns="False" Visible="false ">
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
                        <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="gvFakeGridView"></dx:ASPxGridViewExporter>
                    </div>
                    <!--grid_wrap-->
                </div>
                <!--content_fondo_gris-->
            </div>
            <!--col-1-1-->
        </div>
        <!--fondo gris-->
        <asp:HiddenField runat="server" ID="hdnShowPopComment" ClientIDMode="Static" Value="false" />
    </ContentTemplate>
</asp:UpdatePanel>
<div id="dvPopAddComment" style="display: none; padding: 0">
    <uc1:UCNotesComments runat="server" ID="UCNotesComments" />
</div>

