<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUCReadyToReview.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.ReadyToReview.WUCReadyToReview" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Data.Linq" TagPrefix="dx" %>
<%@ Register Src="~/NewBusiness/UserControls/Common/UCNotesComments.ascx" TagPrefix="uc1" TagName="UCNotesComments" %>
<%@ Register Src="~/NewBusiness/UserControls/Common/WUCAddComment.ascx" TagPrefix="uc1" TagName="WUCAddComment" %>
<asp:UpdatePanel runat="server" ID="udpReadyToReview" UpdateMode="Conditional" RenderMode="Inline">
    <ContentTemplate>
        <div id="scroll_2" class="st-content-inner">
            <!--extra div para emular el left side fixed-->
            <!--CONTENIDO EMPIEZA AQUI-->
            <div class="main clearfix">
                <!--CONTENIDO DERECHA-->
                <div class="contenido_derecha management_mc">
                    <!--wrapper de las columnas-->
                    <div class="grid grid-pad">
                        <div class="col-1-1">
                            <div class="titulos_sin_accion02" runat="server" id="Search">SEARCH</div>
                            <asp:Panel runat="server" class="barra1 no_padding" DefaultButton="btnSearch">
                                <div class="filter">
                                    <div class="grupos de_8">                                        
                                        <div>
                                            <label class="label" runat="server" id="ProductType">Product Type</label>
                                            <div class="wrap_select">
                                                <asp:DropDownList runat="server" ID="ddlBusinessLine" ClientIDMode="Static">
                                                </asp:DropDownList>
                                            </div>
                                            <!--wrap_select-->
                                        </div>
                                        <div>
                                            <label class="label" runat="server" id="PolicyNo">Policy</label>
                                            <asp:TextBox runat="server" ID="txtPolicy" ClientIDMode="Static" Policy='Policy' CustomFilter="true" />
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
                                            <asp:TextBox runat="server" ID="FromTxt" CssClass="datepicker" ClientIDMode="Static" />
                                        </div>
                                        <div>
                                            <label class="label" runat="server" id="To">To</label>
                                            <asp:TextBox runat="server" ID="ToTxt" CssClass="datepicker" ClientIDMode="Static" />
                                        </div>
                                        <div>
                                            <label class="label" runat="server" id="Agent">Agent Name</label>
                                            <div class="wrap_select">
                                                <asp:DropDownList runat="server" ID="ddlAgents" ClientIDMode="Static">
                                                </asp:DropDownList>
                                            </div>
                                            <!--wrap_select-->
                                        </div>
                                        <div>
                                            <label class="label" runat="server" id="InsuredName">Insured Name</label>
                                            <asp:TextBox runat="server" ID="InsuredNameTxt" ClientIDMode="Static" alphabetical='alphabetical' />
                                        </div>
                                        <div>
                                            <label class="label" runat="server" id="OwnerName">Owner Name</label>
                                            <asp:TextBox runat="server" ID="OwnerNameTxt" ClientIDMode="Static" alphabetical='alphabetical' />
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
                                                <asp:Button CssClass="boton" Text="Clear" runat="server" OnClick="btnClear_Click" ID="btnClear" />
                                            </div>
                                        </div>
                                    </div>
                                    <!--grupos-->

                                </div>
                                <!--filter-->
                            </asp:Panel>
                            <!--barra1-->

                            <div class="titulos_sin_accion" runat="server" id="ReadyToReview">READY TO REVIEW</div>
                            <div class="fondo_gris fl">
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
                                                              ProductNameKey;
                                                              AgentFullName;
                                                              UserFullName;
                                                              LastUpdate;
                                                              AddInsuredContactId;PaymentId"
                                                OnRowCommand="gvReadyToReview_RowCommand1" ClientIDMode="Static" OnPageIndexChanged="gvReadyToReview_PageIndexChanged" OnBeforeColumnSortingGrouping="gvReadyToReview_BeforeColumnSortingGrouping" OnPreRender="gvReadyToReview_PreRender" Width="100%">
                                                <ClientSideEvents BeginCallback="function(){BeginRequestHandler();}" EndCallback="function(){ pageLoad(); EndRequestHandler(); }" />
                                                <Columns>
                                                    <dx:GridViewDataCheckColumn Caption="" VisibleIndex="0" Width="3%">
                                                        <DataItemTemplate>
                                                            <asp:CheckBox ID="chkSelectedPolicy" runat="server" Checked="false" />
                                                        </DataItemTemplate>
                                                    </dx:GridViewDataCheckColumn>                                                           
                                                    <dx:GridViewDataColumn Caption="BUSINESS LINE" FieldName="ProductTypeDesc" VisibleIndex="1" Name="ProductTypeLabel" />
                                                    <dx:GridViewDataColumn Caption="POLICY" FieldName="PolicyNo" VisibleIndex="1" Name="PolicyLabel" />
                                                    <dx:GridViewDataColumn Caption="PLAN" FieldName="ProductDesc" VisibleIndex="2" Name="PlanLabel" />
                                                    <dx:GridViewDataColumn Caption="INSURED" FieldName="InsuranceFullName" VisibleIndex="3" Name="INSURED" />
                                                    <dx:GridViewDataColumn Caption="OWNER" FieldName="OwnerFullName" VisibleIndex="4" Name="OwnerLabel" />
                                                    <dx:GridViewDataTextColumn FieldName="OfficeDesc" Caption="OFFICE" Name="Office" VisibleIndex="5" />
                                                    <dx:GridViewDataColumn Caption="AGENT" FieldName="AgentFullName" VisibleIndex="6" Name="AGENT" />
                                                    <dx:GridViewDataColumn Caption="USER" FieldName="UserFullName" VisibleIndex="7" Name="USER" />
                                                    <dx:GridViewDataColumn Caption="LAST UPDATE" FieldName="LastUpdate" VisibleIndex="8" Name="LastUpdateLabel" />
                                                    <dx:GridViewDataColumn Caption="VIEW" VisibleIndex="9" Visible="false" Name="View">
                                                        <DataItemTemplate>
                                                            <asp:Button runat="server" CssClass="view_file" ID="btnViewFile" CommandName="View"></asp:Button>
                                                        </DataItemTemplate>
                                                        <Settings AllowHeaderFilter="False" AllowSort="False" />
                                                    </dx:GridViewDataColumn>
                                                    <dx:GridViewDataColumn Caption="PAYMENT" VisibleIndex="10" Name="PaymentsLabel">
                                                        <DataItemTemplate>
                                                            <asp:Button runat="server" CssClass='<%# bool.Parse(Eval("IsPaymentCompleted").ToString())?"payment_fileDisabled":"payment_file" %>' ID="btnPayment" CommandName="Payment"></asp:Button>
                                                        </DataItemTemplate>
                                                        <Settings AllowHeaderFilter="False" AllowSort="False" />
                                                    </dx:GridViewDataColumn>
                                                    <dx:GridViewDataColumn Caption="COMMENT" VisibleIndex="11" Name="Comment">
                                                        <DataItemTemplate>
                                                            <asp:UpdatePanel runat="server" ID="udpbtnComment">
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
                                                    <dx:GridViewDataColumn Caption="EDIT" VisibleIndex="12" Name="Edit">
                                                        <DataItemTemplate>
                                                            <asp:Button runat="server" CssClass="edit_file" ID="btnEdit" CommandName="Modify"></asp:Button>
                                                        </DataItemTemplate>
                                                        <Settings AllowHeaderFilter="False" AllowSort="False" />
                                                    </dx:GridViewDataColumn>
                                                    <dx:GridViewDataColumn Caption="REJECT" VisibleIndex="13" Name="Reject">
                                                        <DataItemTemplate>
                                                            <asp:UpdatePanel runat="server" ID="udpbtnReject">
                                                                <ContentTemplate>
                                                                    <asp:Button runat="server" CssClass="reject_file" ID="btnReject" CommandName="Reject"></asp:Button>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:PostBackTrigger ControlID="btnReject" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </DataItemTemplate>
                                                        <Settings AllowHeaderFilter="False" AllowSort="False" />
                                                    </dx:GridViewDataColumn>
                                                </Columns>
                                                <SettingsBehavior ColumnResizeMode="NextColumn" />
                                                <Settings VerticalScrollableHeight="460" VerticalScrollBarMode="Visible" />
                                                <SettingsBehavior AllowSelectByRowClick="true" AllowSelectSingleRowOnly="true" />
                                                <SettingsPager PageSize="15" NumericButtonCount="3" AlwaysShowPager="true" />
                                                <SettingsPopup>
                                                    <HeaderFilter Height="200" />
                                                </SettingsPopup>
                                                <SettingsDataSecurity AllowInsert="false" AllowEdit="false" AllowDelete="false" />
                                                <Settings ShowFilterBar="Hidden" />
                                            </dx:ASPxGridView>
                                        </div>
                                        <!--grid_wrap-->
                                    </div>
                                    <!--content_fondo_gris-->
                                </div>
                                <!--col-1-1-->
                            </div>
                            <!--fondo gris-->
                        </div>
                        <!--col-1-1-->

                        <div class="col-1-1">
                            <div class="barra_sub_menu">
                                <div class="grupos de_2_b last">
                                    <div class="leyenda">
                                        <span runat="server" id="SelectionGridMessage">To select a record, click the checkbox in the corresponding row . To select the full list ,
                                                click on the top checkbox column.
                                        </span>
                                    </div>
                                    <div class="grupos de_2">
                                        <div>
                                            <div class="btn_celeste">
                                                <span class="see_ilustracion"></span>
                                                <asp:Button runat="server" ID="btnSubmitSTL" CssClass="boton" Text="SUBMIT TO DATA REVIEW" OnClientClick="return ConfirmSubmitToSTL(this)" OnClick="btnSubmitSTL_Click" />
                                            </div>
                                            <!--btn_celeste-->
                                        </div>

                                        <div>
                                            <div class="btn_celeste">
                                                <span class="print_list_celeste"></span>
                                                <asp:Button runat="server" ID="btnPrintList" Text="EXPORT TO EXCEL" ClientIDMode="Static" class="boton" value="EXPORT" OnClick="btnPrintList_Click" OnClientClick="return ConfirmPrintList(this)" />
                                            </div>
                                            <!--btn_celeste-->
                                        </div>
                                    </div>
                                    <!--grupos-->
                                </div>
                                <!--grupos-->
                            </div>
                            <!--barra_sub_menu-->
                        </div>
                        <!--col-1-1-->
                    </div>
                    <!--grid grid-pad-->
                </div>
                <!--contendio derecha-->

            </div>
            <!-- /main clearfix -->
        </div>
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
        <asp:HiddenField runat="server" ID="hdnShowPopReject" ClientIDMode="Static" Value="false" />
        <asp:HiddenField runat="server" ID="hdnShowPopComment" ClientIDMode="Static" Value="false" />
        <asp:HiddenField runat="server" ID="hdnPaymentIsCompleted" ClientIDMode="Static" Value="false" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="gvReadyToReview" />
        <asp:PostBackTrigger ControlID="btnPrintList" />
    </Triggers>
</asp:UpdatePanel>

<div id="dvCommentReject" style="display: none">
    <uc1:WUCAddComment runat="server" ID="WUCAddComment1" />
</div>
<div id="dvPopAddComment" style="display: none; padding: 0">
    <uc1:UCNotesComments runat="server" ID="UCNotesComments" />
</div>
