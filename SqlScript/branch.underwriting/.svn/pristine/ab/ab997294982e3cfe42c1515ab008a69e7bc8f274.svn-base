<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUCIllustrationsList.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.Illustration.WUCIllustrationsList" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Data.Linq" TagPrefix="dx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/NewBusiness/UserControls/Illustration/UCPopupChangeStatusSaveNotes.ascx" TagPrefix="uc1" TagName="UCPopupChangeStatusSaveNotes" %>
<%@ Register Src="~/NewBusiness/UserControls/Illustration/UCIllustrationsPivot.ascx" TagPrefix="uc1" TagName="UCIllustrationsPivot" %>
<%@ Register Src="~/NewBusiness/UserControls/Statistics/UCEmisiones.ascx" TagPrefix="uc1" TagName="UCEmisiones" %>
<%@ Register Src="~/NewBusiness/UserControls/Statistics/UCPerformance.ascx" TagPrefix="uc1" TagName="UCPerformance" %>
<%@ Register Src="~/NewBusiness/UserControls/Illustration/UCPrintingInvoice.ascx" TagPrefix="uc1" TagName="UCPrintingInvoice" %>


<asp:UpdatePanel ID="udpIllustration" runat="server">
    <ContentTemplate>
        <asp:Timer runat="server" Enabled="false" ID="tBandejas" OnTick="tBandejas_Tick"></asp:Timer>
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
                                <%--<a href="#" id="lnkIllustrationList" lnk="lnk" onclick="setCurrentAccordeon(this,'#hdnAccordeonIllustrationList');">
                                    <%=RESOURCE.UnderWriting.NewBussiness.Resources.InboxIllustrations %><span><!--icono--></span></a>--%>
                                <ul>
                                    <li>
                                        <div class="grid grid-pad">
                                            <div class="col-1-1">
                                                <div class="fondo_gris">

                                                    <div class="col-1-1">
                                                        <div class="contenedor_tabs" style="margin-bottom: 0;">
                                                            <ul class="tabs_ttle dvddo_in_7 lineBussines">
                                                                <li class="liPuntoVenta" id="liPuntoVenta">
                                                                    <asp:LinkButton Style="padding: 0;" runat="server" ID="lnkAuto" appname="VirtualOffice" OnClick="lnkAuto_Click">
                                                                    <img class="IcoPuntoVenta Altura" src="../../images/top-menu-icon/ico-auto.png" />
                                                                    <strong class="BandejaLineaTope">Autos</strong>
                                                                    </asp:LinkButton>
                                                                </li>
                                                                <li class="liPuntoVenta" id="VidaFunerarios">
                                                                    <asp:LinkButton Style="padding: 0;" runat="server" ID="lkLife" appname="VirtualOffice" OnClientClick="return CorfimRedirect(this)" OnClick="lkLife_Click"> 
                                                                    <img class="IcoPuntoVenta Altura" src="../../images/top-menu-icon/ico-vida.png" />
                                                                    <strong class="BandejaLineaTope">Vida & Funerarios</strong>  
                                                                    </asp:LinkButton>
                                                                </li>
                                                                <li class="liPuntoVenta" id="SaludInternacional">
                                                                    <asp:LinkButton Style="padding: 0;" runat="server" ID="lnkHealth" appname="VirtualOffice" OnClientClick="return CorfimRedirect(this)" OnClick="lnkHealth_Click"> 
                                                                    <img class="IcoPuntoVenta Altura" src="../../images/top-menu-icon/ico-salud.png" />
                                                                    <strong class="BandejaLineaTope">Salud Internacional</strong>
                                                                    </asp:LinkButton>
                                                                </li>
                                                                <%--                                                            <li class="liPuntoVenta">
                                                                <asp:LinkButton Style="padding: 0;" runat="server" ID="lnkVivienda" appname="VirtualOffice" OnClientClick="return CorfimRedirect(this)" OnClick="lnkVivienda_Click">
                                                                   <img class="IcoPuntoVenta Altura" src="../../images/top-menu-icon/ico-propiedad.png" />
                                                                   <strong>Vivienda</strong>
                                                                </asp:LinkButton>
                                                            </li>--%>
                                                                <%--                                                            <li class="liPuntoVenta">
                                                                <asp:LinkButton Style="padding: 0;" runat="server" ID="LinkButton1" appname="VirtualOffice" OnClientClick="return CorfimRedirect(this)" OnClick="lnkLineaAleada_Click">
                                                                      <img class="IcoPuntoVenta Altura" src="../../images/top-menu-icon/ico-lespeciales.png" />
                                                                      <strong class="BandejaLineaTope">Líneas de <br>Especialidad</strong>
                                                                </asp:LinkButton>
                                                            </li>--%>
                                                                <li class="liPuntoVenta" id="Comerciales">
                                                                    <asp:LinkButton Style="padding: 0;" runat="server" ID="lnkLineaAleada" appname="VirtualOffice" OnClick="lnkLineaAleada_Click">
                                                                    <img class="IcoPuntoVenta Altura" src="../../images/top-menu-icon/ico-lcomerciales.png" />
                                                                    <strong class="BandejaLineaTope">Propiedad & Líneas Generales</strong>
                                                                    </asp:LinkButton>
                                                                </li>
                                                                <%--                                                            <li class="liPuntoVenta">
                                                                <asp:LinkButton Style="padding: 0;" runat="server" ID="lkFunerario" appname="VirtualOffice" OnClientClick="return CorfimRedirect(this)" OnClick="lkLife_Click">
                                                                      <img class="IcoPuntoVenta Altura" src="../../images/top-menu-icon/ico-servicios.png" />
                                                                      <strong class="BandejaLineaTope">Servicios <br>Funerarios</strong>
                                                                </asp:LinkButton>
                                                            </li>--%>
                                                            </ul>
                                                        </div>
                                                        <%--Refrescar Contadores--%>
                                                        <div class="fr" style="padding-bottom: 10px; display: none">
                                                            <div class="btn_celeste" style="padding-top: 7px; padding-right: 22px;">
                                                                <asp:Button
                                                                    runat="server"
                                                                    ID="btnRefreshCounters"
                                                                    CssClass="boton"
                                                                    Text="Refresh Counters"
                                                                    OnClick="btnRefreshCounters_Click" />
                                                            </div>
                                                        </div>
                                                        <%--Refrescar Contadores--%>
                                                        <div class="contenedor_tabs">
                                                            <ul class="tabs_ttle dvddo_in_3" id="ulGroupTabs" runat="server">
                                                                <li id="lilnkPreSuscripcion" runat="server">
                                                                    <asp:LinkButton runat="server" ID="lnkPreSuscripcion" ClientIDMode="Static" OnClick="ManageGroupTabs"><%=RESOURCE.UnderWriting.NewBussiness.Resources.PreSubscription %></asp:LinkButton>
                                                                    <i class="punt" runat="server" id="PreSuscripcion" clientidmode="Static">0</i>
                                                                </li>
                                                                <li id="lilnkSuscripcion" runat="server">
                                                                    <asp:LinkButton runat="server" ID="lnkSuscripcion" ClientIDMode="Static" OnClick="ManageGroupTabs"><%=RESOURCE.UnderWriting.NewBussiness.Resources.Subscription %></asp:LinkButton>
                                                                    <i class="punt" runat="server" id="Suscripcion" clientidmode="Static">0</i>
                                                                </li>
                                                                <li id="lilnkHistorico" runat="server">
                                                                    <asp:LinkButton runat="server" ID="lnkHistorico" ClientIDMode="Static" OnClick="ManageGroupTabs"><%=RESOURCE.UnderWriting.NewBussiness.Resources.Historical %></asp:LinkButton>
                                                                    <i class="punt" runat="server" id="Historico" clientidmode="Static">0</i>
                                                                </li>
                                                            </ul>

                                                            <asp:HiddenField runat="server" ID="hdnPreSuscripcionCount" ClientIDMode="Static" Value="0" />
                                                            <asp:HiddenField runat="server" ID="hdnSuscripcionCount" ClientIDMode="Static" Value="0" />
                                                            <asp:HiddenField runat="server" ID="hdnHistoricoCount" ClientIDMode="Static" Value="0" />
                                                            <asp:HiddenField runat="server" ID="hdnIllustrationsToWorkCount" ClientIDMode="Static" Value="0" />
                                                            <asp:HiddenField runat="server" ID="hdnCompleteIllustrationsCount" Value="0" ClientIDMode="Static" />
                                                            <asp:HiddenField runat="server" ID="hdnDeclinedByClientCount" Value="0" ClientIDMode="Static" />
                                                            <asp:HiddenField runat="server" ID="hdnExpiredCount" Value="0" ClientIDMode="Static" />
                                                            <asp:HiddenField runat="server" ID="hdnExpiringCount" Value="0" ClientIDMode="Static" />
                                                            <asp:HiddenField runat="server" ID="hdnSubscriptionsCount" Value="0" ClientIDMode="Static" />
                                                            <asp:HiddenField runat="server" ID="hdnDiscountsCount" Value="0" ClientIDMode="Static" />
                                                            <asp:HiddenField runat="server" ID="hdnMissingDocumentsCount" ClientIDMode="Static" Value="0" />
                                                            <asp:HiddenField runat="server" ID="hdnDeclinedBySubscriptionCount" Value="0" ClientIDMode="Static" />
                                                            <asp:HiddenField runat="server" ID="hdnConfirmationCallCount" Value="0" ClientIDMode="Static" />
                                                            <asp:HiddenField runat="server" ID="hdnMissingInspectionsCount" Value="0" ClientIDMode="Static" />
                                                            <asp:HiddenField runat="server" ID="hdnFacultativeCount" Value="0" ClientIDMode="Static" />
                                                            <asp:HiddenField runat="server" ID="hdnApprovedBySubscriptionCount" Value="0" ClientIDMode="Static" />
                                                            <asp:HiddenField runat="server" ID="hdnHistoricalIllustrationsCount" Value="0" ClientIDMode="Static" />
                                                            <asp:HiddenField runat="server" ID="hdnPuntoVentaTabCount" Value="0" ClientIDMode="Static" />
                                                            <asp:HiddenField runat="server" ID="hdnIncompleteIllustrationCount" Value="0" ClientIDMode="Static" />
                                                            <asp:HiddenField runat="server" ID="hdnApprovedByClientCount" Value="0" ClientIDMode="Static" />

                                                            <ul class="tabs_ttle dvddo_in_5" id="MenuTabs" runat="server" clientidmode="Static">
                                                                <asp:MultiView ActiveViewIndex="0" ID="mvGroupTabs" runat="server">
                                                                    <asp:View ID="vwPreSuscripcion" runat="server">
                                                                        <li id="lilnkIllustrationsToWork" runat="server" visible="false">
                                                                            <asp:LinkButton runat="server" ID="lnkIllustrationsToWork" OnClick="ManageTabs" ClientIDMode="Static"></asp:LinkButton>
                                                                            <i class="punt" runat="server" id="IllustrationsToWorkCount">0</i>
                                                                        </li>
                                                                        <li id="lilnkCompleteIllustrations" runat="server" visible="false">
                                                                            <asp:LinkButton runat="server" ID="lnkCompleteIllustrations" OnClick="ManageTabs" ClientIDMode="Static"><%=RESOURCE.UnderWriting.NewBussiness.Resources.CompleteIllustrations %></asp:LinkButton>
                                                                            <i class="punt" runat="server" id="CompleteIllustrationsCount">0</i>
                                                                        </li>
                                                                        <li id="lilnkDeclinedByClient" runat="server" visible="false">
                                                                            <asp:LinkButton runat="server" ID="lnkDeclinedByClient" OnClick="ManageTabs" ClientIDMode="Static"><%=RESOURCE.UnderWriting.NewBussiness.Resources.DeclinedByClient %></asp:LinkButton>
                                                                            <i class="punt" runat="server" id="DeclinedByClientCount">0</i>
                                                                        </li>
                                                                        <li id="lilnkExpired" runat="server" visible="false">
                                                                            <asp:LinkButton runat="server" ID="lnkExpired" OnClick="ManageTabs" ClientIDMode="Static"><%=RESOURCE.UnderWriting.NewBussiness.Resources.Expired %></asp:LinkButton>
                                                                            <i class="punt" runat="server" id="ExpiredCount">0</i>
                                                                        </li>
                                                                        <li id="lilnkExpiring" runat="server" visible="false">
                                                                            <asp:LinkButton runat="server" ID="lnkExpiring" OnClick="ManageTabs" ClientIDMode="Static"><%=RESOURCE.UnderWriting.NewBussiness.Resources.Expiring %></asp:LinkButton>
                                                                            <i class="punt" runat="server" id="ExpiringCount">0</i>
                                                                        </li>
                                                                    </asp:View>
                                                                    <asp:View ID="vwSuscripcion" runat="server">
                                                                        <li id="lilnkSubscriptions" runat="server" visible="false">
                                                                            <asp:LinkButton runat="server" ID="lnkSubscriptions" OnClick="ManageTabs" ClientIDMode="Static"><%=RESOURCE.UnderWriting.NewBussiness.Resources.Subscriptions %></asp:LinkButton>
                                                                            <i class="punt" runat="server" id="SubscriptionsCount">0</i>
                                                                        </li>
                                                                        <li id="lilnkDiscounts" runat="server" visible="false">
                                                                            <asp:LinkButton runat="server" ID="lnkDiscounts" OnClick="ManageTabs" ClientIDMode="Static"><%=RESOURCE.UnderWriting.NewBussiness.Resources.Discount %></asp:LinkButton>
                                                                            <i class="punt" runat="server" id="DiscountsCount">0</i>
                                                                        </li>
                                                                        <li id="lilnkConfirmationCall" runat="server" visible="false">
                                                                            <asp:LinkButton runat="server" ID="lnkConfirmationCall" OnClick="ManageTabs" ClientIDMode="Static"><%=RESOURCE.UnderWriting.NewBussiness.Resources.ConfirmationCall %></asp:LinkButton>
                                                                            <i class="punt" runat="server" id="ConfirmationCallCount">0</i>
                                                                        </li>
                                                                        <li id="lilnkMissingDocuments" runat="server" visible="false">
                                                                            <asp:LinkButton runat="server" ID="lnkMissingDocuments" OnClick="ManageTabs" ClientIDMode="Static"><%=RESOURCE.UnderWriting.NewBussiness.Resources.MissingDocuments %></asp:LinkButton>
                                                                            <i class="punt" runat="server" id="MissingDocumentsCount">0</i>
                                                                        </li>
                                                                        <li id="lilnkMissingInspections" runat="server" visible="false">
                                                                            <asp:LinkButton runat="server" ID="lnkMissingInspections" OnClick="ManageTabs" ClientIDMode="Static"><%=RESOURCE.UnderWriting.NewBussiness.Resources.MissingInspections %></asp:LinkButton>
                                                                            <i class="punt" runat="server" id="MissingInspectionsCount">0</i>
                                                                        </li>
                                                                        <li id="lilnkFacultative" runat="server" visible="false">
                                                                            <asp:LinkButton runat="server" ID="lnkFacultative" OnClick="ManageTabs" ClientIDMode="Static"><%=RESOURCE.UnderWriting.NewBussiness.Resources.FacultativesCases %></asp:LinkButton>
                                                                            <i class="punt" runat="server" id="FacultativeCount">0</i>
                                                                        </li>
                                                                    </asp:View>
                                                                    <asp:View ID="vwHistorico" runat="server">
                                                                        <li id="lilnkDeclinedBySubscription" runat="server" visible="false">
                                                                            <asp:LinkButton runat="server" ID="lnkDeclinedBySubscription" OnClick="ManageTabs" ClientIDMode="Static"><%=RESOURCE.UnderWriting.NewBussiness.Resources.DeclinedBySubscription %></asp:LinkButton>
                                                                            <i class="punt" runat="server" id="DeclinedBySubscriptionCount">0</i>
                                                                        </li>
                                                                        <li id="lilnkApprovedBySubscription" runat="server" visible="false">
                                                                            <asp:LinkButton runat="server" ID="lnkApprovedBySubscription" OnClick="ManageTabs" ClientIDMode="Static"><%=RESOURCE.UnderWriting.NewBussiness.Resources.ApprovedBySubscription %></asp:LinkButton>
                                                                            <i class="punt" runat="server" id="ApprovedBySubscriptionCount">0</i>
                                                                        </li>
                                                                        <li id="lilnkHistoricalIllustrations" runat="server" visible="false">
                                                                            <asp:LinkButton runat="server" ID="lnkHistoricalIllustrations" OnClick="ManageTabs" ClientIDMode="Static"><%=RESOURCE.UnderWriting.NewBussiness.Resources.IllustrationHistoric %></asp:LinkButton>
                                                                            <i class="punt" runat="server" id="HistoricalIllustrationsCount">0</i>
                                                                        </li>
                                                                        <li id="lilnkPuntoVentaTab" runat="server" visible="false">
                                                                            <asp:LinkButton runat="server" ID="lnkPuntoVentaTab" OnClick="ManageTabs" ClientIDMode="Static"><%=RESOURCE.UnderWriting.NewBussiness.Resources.PuntoVentaTab %></asp:LinkButton>
                                                                            <i class="punt" runat="server" id="PuntoVentaTabCount">0</i>
                                                                        </li>
                                                                        <li id="lilnkStatistics" runat="server" visible="false">
                                                                            <asp:LinkButton runat="server" ID="lnkStatistics" OnClick="ManageTabs" ClientIDMode="Static"><%=RESOURCE.UnderWriting.NewBussiness.Resources.Statistics %></asp:LinkButton>
                                                                        </li>
                                                                    </asp:View>
                                                                </asp:MultiView>

                                                                <li id="lilnkIncompleteIllustration" runat="server" style="display: none">
                                                                    <asp:LinkButton runat="server" ID="lnkIncompleteIllustration" OnClick="ManageTabs" ClientIDMode="Static"><%=RESOURCE.UnderWriting.NewBussiness.Resources.IncompleteIllustrations %></asp:LinkButton>
                                                                    <i class="punt" runat="server" id="IncompleteIllustrationCount">0</i>
                                                                </li>
                                                                <li id="lilnkApprovedByClient" runat="server" style="display: none">
                                                                    <asp:LinkButton runat="server" ID="lnkApprovedByClient" OnClick="ManageTabs" ClientIDMode="Static"><%=RESOURCE.UnderWriting.NewBussiness.Resources.ApprovedByClient %></asp:LinkButton>
                                                                    <i class="punt" runat="server" id="ApprovedByClientCount">0</i>
                                                                </li>
                                                            </ul>
                                                        </div>
                                                        <asp:Panel runat="server" CssClass="barra1 no_padding">
                                                            <div class="filter">
                                                                <div class="accordion_tabulado">
                                                                    <ul class="principal">
                                                                        <li>
                                                                            <a href="#" id="lnkFiltersList" lnk="lnk" onclick="setCurrentAccordeon(this,'#hdnAccordeonFiltersList');">
                                                                                <%=RESOURCE.UnderWriting.NewBussiness.Resources.Filters %><span><!--icono--></span></a>
                                                                            <ul>
                                                                                <li>
                                                                                    <asp:Panel ID="pnlIllustrationsFilters" runat="server" Visible="true">
                                                                                        <div class="grupos de_6">
                                                                                            <div>
                                                                                                <asp:Label runat="server" ID="lblFrom" CssClass="label"><%= RESOURCE.UnderWriting.NewBussiness.Resources.From %>:</asp:Label>
                                                                                                <asp:TextBox runat="server" ID="txtFrom" CssClass="datepicker" Style="display: block;">
                                                                                                </asp:TextBox>
                                                                                            </div>
                                                                                            <asp:panel runat="server" ID="pnFilterOffice" Visible="false">
                                                                                                <asp:Label runat="server" ID="lblOffice" CssClass="label"><%= WEB.NewBusiness.Common.Utility.Capitalize(RESOURCE.UnderWriting.NewBussiness.Resources.Office)%>:</asp:Label>
                                                                                                <asp:DropDownList runat="server" ID="drpOffice" DataTextField="Value" DataValueField="Key" OnSelectedIndexChanged="drpOffice_SelectedIndexChanged" AutoPostBack="true" Style="display: block;">
                                                                                                </asp:DropDownList>
                                                                                            </asp:panel>
                                                                                            <div>
                                                                                                <asp:Label runat="server" ID="lblPeriod" CssClass="label"><%= RESOURCE.UnderWriting.NewBussiness.Resources.TimeDimension %>:</asp:Label>
                                                                                                <asp:DropDownList runat="server" ID="drpPeriod" DataTextField="Value" DataValueField="Key" OnSelectedIndexChanged="drpPeriod_SelectedIndexChanged"  Style="display: block;">
                                                                                                </asp:DropDownList>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="grupos de_6">
                                                                                            <div>
                                                                                                <asp:Label runat="server" ID="lblTo" CssClass="label"><%= RESOURCE.UnderWriting.NewBussiness.Resources.To %>:</asp:Label>
                                                                                                <asp:TextBox runat="server" ID="txtTo" CssClass="datepicker" Style="display: block;">
                                                                                                </asp:TextBox>
                                                                                            </div>
                                                                                            <asp:panel runat="server" ID="pnFilterCompany" Visible="false">
                                                                                                <asp:Label runat="server" ID="lblCompanyProfile" CssClass="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.Company %>:</asp:Label>
                                                                                                <asp:DropDownList runat="server" ID="drpCompanyProfile" DataTextField="CompanyDesc" DataValueField="CompanyId" Style="display: block;">
                                                                                                </asp:DropDownList>
                                                                                            </asp:panel>
                                                                                            <asp:panel runat="server" ID="pnFilterAgent" Visible="false">
                                                                                                <asp:Label runat="server" ID="lblAgent" CssClass="label"></asp:Label>
                                                                                                <asp:DropDownList runat="server" ID="drpAgent" DataTextField="Value" DataValueField="Key" AutoPostBack="true" Style="display: block;" OnSelectedIndexChanged="drpAgent_SelectedIndexChanged">
                                                                                                </asp:DropDownList>
                                                                                            </asp:panel>
                                                                                            <asp:panel runat="server" ID="pnFilterBusinessLine" Visible="false">
                                                                                                <asp:Label runat="server" ID="lblBusinessLine" CssClass="label"><%= RESOURCE.UnderWriting.NewBussiness.Resources.LineofBusinessLabel %>:</asp:Label>
                                                                                                <asp:DropDownList runat="server" ID="drpBusinessLine" DataTextField="Value" DataValueField="Key" Style="display: block;">
                                                                                                </asp:DropDownList>
                                                                                            </asp:panel>
                                                                                            <div class="boton_wrapper verde">
                                                                                                <span class=" search"></span>
                                                                                                <asp:Button CssClass="boton" Text="Search" runat="server" ID="btnSearch" ClientIDMode="Static" OnClick="btnSearch_Click" />
                                                                                            </div>
                                                                                        </div>
                                                                                    </asp:Panel>
                                                                                    <asp:Panel ID="pnlStatisticsFilters" runat="server" Visible="false">
                                                                                        <div class="grupos de_6">
                                                                                            <div>
                                                                                                <label class="label"><%= WEB.NewBusiness.Common.Utility.Capitalize(RESOURCE.UnderWriting.NewBussiness.Resources.StatisticsReportType)%>:</label>
                                                                                                <asp:DropDownList AutoPostBack="true" runat="server" ID="ddlStatisticsReportType" OnSelectedIndexChanged="ddlStatisticsReportType_SelectedIndexChanged"></asp:DropDownList>
                                                                                            </div>
                                                                                            <asp:Panel ID="pnlEmisionesViewBy" runat="server" Visible="true">
                                                                                                <label class="label"><%= WEB.NewBusiness.Common.Utility.Capitalize(RESOURCE.UnderWriting.NewBussiness.Resources.ViewBy)%>:</label>
                                                                                                <asp:DropDownList AutoPostBack="true" runat="server" ID="ddlEmisionesViewBy" OnSelectedIndexChanged="ddlEmisionesViewBy_SelectedIndexChanged"></asp:DropDownList>
                                                                                            </asp:Panel>
                                                                                            <asp:Panel ID="pnlPerformanceViewBy" runat="server" Visible="false">
                                                                                                <label class="label"><%= WEB.NewBusiness.Common.Utility.Capitalize(RESOURCE.UnderWriting.NewBussiness.Resources.ViewBy)%>:</label>
                                                                                                <asp:DropDownList AutoPostBack="true" runat="server" ID="ddlPerformanceViewBy" OnSelectedIndexChanged="ddlPerformanceViewBy_SelectedIndexChanged"></asp:DropDownList>
                                                                                            </asp:Panel>
                                                                                            <div>
                                                                                                <label class="label"><%= WEB.NewBusiness.Common.Utility.Capitalize(RESOURCE.UnderWriting.NewBussiness.Resources.TimeDimension)%>:</label>
                                                                                                <asp:DropDownList AutoPostBack="true" runat="server" ID="ddlStatisticsTimeDimension" OnSelectedIndexChanged="ddlStatisticsTimeDimension_SelectedIndexChanged"></asp:DropDownList>
                                                                                            </div>
                                                                                            <asp:Panel ID="pnlPeriodData" runat="server" Visible="false">
                                                                                                <asp:Label runat="server" ID="lblPeriodData" CssClass="label"></asp:Label>
                                                                                                <asp:DropDownList AutoPostBack="true" runat="server" ID="ddlPeriodData" OnSelectedIndexChanged="ddlPeriodData_SelectedIndexChanged"></asp:DropDownList>
                                                                                            </asp:Panel>
                                                                                            <asp:Panel ID="pnlYears" runat="server">
                                                                                                <label class="label"><%= WEB.NewBusiness.Common.Utility.Capitalize(RESOURCE.UnderWriting.NewBussiness.Resources.Year)%>s:</label>
                                                                                                <asp:DropDownList AutoPostBack="true" runat="server" ID="ddlYears" OnSelectedIndexChanged="ddlYears_SelectedIndexChanged"></asp:DropDownList>
                                                                                            </asp:Panel>
                                                                                            <div class="boton_wrapper verde fr">
                                                                                                <span class=" search"></span>
                                                                                                <asp:Button CssClass="boton" Text="Search" runat="server" ID="btnStatisticsSearch" ClientIDMode="Static" OnClick="btnStatisticsSearch_Click" />
                                                                                            </div>
                                                                                        </div>
                                                                                    </asp:Panel>
                                                                                    <!--filter_by_period-->
                                                                                    <br class="clear">
                                                                                    <!--puedes usar un botton o submit si quieres-->
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </div>
                                                        </asp:Panel>
                                                        <div class="content_fondo_gris">
                                                            <asp:Panel ID="pnlIllustrationGridView" runat="server" Visible="true">
                                                                <div class="grid_wrap">
                                                                    <asp:MultiView ActiveViewIndex="0" ID="mvBandejaPOS" runat="server">
                                                                        <asp:View ID="vwBandeja" runat="server">
                                                                            <dx:ASPxGridView ID="gvIllustration"
                                                                                runat="server"
                                                                                ClientIDMode="Static"
                                                                                ClientInstanceName="gridList"
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
                                                                                      AgentId;                                                                                                                                                                       
                                                                                      IllustrationStatusCode;
                                                                                      PlanGroupCode;
                                                                                      AssignedSubscriberId;
                                                                                      TipoRiesgoNameKey;
                                                                                      IllustrationNo;
                                                                                      InsuredName;
                                                                                      PolicyNoMain;
                                                                                      ProductSubTypeDesc;
                                                                                      HasFacultative;"
                                                                                EnableCallBacks="False"
                                                                                AutoGenerateColumns="False"
                                                                                OnRowCommand="gvIllustration_RowCommand"
                                                                                OnAfterPerformCallback="gvIllustration_AfterPerformCallback"
                                                                                OnBeforeHeaderFilterFillItems="gvIllustration_BeforeHeaderFilterFillItems"
                                                                                OnPreRender="gvIllustration_PreRender"
                                                                                OnPageIndexChanged="gvIllustration_PageIndexChanged"
                                                                                OnHtmlRowCreated="gvIllustration_HtmlRowCreated">
                                                                                <ClientSideEvents
                                                                                    RowDblClick="IllustrationListRowDblClick"
                                                                                    RowClick="IllustrationListRowClick" />
                                                                                <Columns>
                                                                                    <dx:GridViewDataCheckColumn Caption="" VisibleIndex="0" Width="50px" Name="CheckSelect">
                                                                                        <DataItemTemplate>
                                                                                            <asp:CheckBox runat="server" ID="chkSelect" />
                                                                                        </DataItemTemplate>
                                                                                    </dx:GridViewDataCheckColumn>

                                                                                    <dx:GridViewDataColumn Name="View" Caption="" Width="50px" PropertiesEditType="TextBox" VisibleIndex="1">
                                                                                        <DataItemTemplate>
                                                                                            <asp:Button runat="server" CssClass="view_file" ID="btnVerCotPol" CommandName="VerCotPol" title="Ver detalle de la cotización"></asp:Button>
                                                                                        </DataItemTemplate>
                                                                                        <Settings AllowHeaderFilter="False" AllowSort="False" />
                                                                                    </dx:GridViewDataColumn>

                                                                                    <dx:GridViewDataColumn Name="InspectionLabel" Caption="" Width="50px" PropertiesEditType="TextBox" VisibleIndex="2">
                                                                                        <DataItemTemplate>
                                                                                            <asp:Button runat="server" ID="btnInspection" CommandName="Inspection" CssClass='<%# Eval("InspectionFormCssClass") %>' Enabled='<%# Eval("InspectionFormEnabled") %>' title="Ir a la inspección" />
                                                                                        </DataItemTemplate>
                                                                                        <Settings AllowHeaderFilter="False" AllowSort="False" />
                                                                                    </dx:GridViewDataColumn>

                                                                                    <dx:GridViewDataColumn Name="RequiredLabel" Caption="" PropertiesEditType="TextBox" Width="50px" VisibleIndex="3">
                                                                                        <DataItemTemplate>
                                                                                            <asp:Button runat="server" ID="btnRequired" CommandName="Required" CssClass='<%# Eval("DocumentRequiredCssClass") %>' Enabled='<%# Eval("DocumentRequiredEnabled") %>' title="Ir al tab de documentos Requeridos" />
                                                                                        </DataItemTemplate>
                                                                                        <Settings AllowHeaderFilter="False" AllowSort="False" />
                                                                                    </dx:GridViewDataColumn>

                                                                                    <dx:GridViewDataColumn Name="FinancialClearance" Caption="" VisibleIndex="4" CellStyle-HorizontalAlign="Center" Width="50px" PropertiesEditType="TextBox">
                                                                                        <DataItemTemplate>
                                                                                            <asp:Image runat="server" ID="imgRiesgo" Style="width: 22px; height: 22px;" />
                                                                                        </DataItemTemplate>
                                                                                        <Settings AllowHeaderFilter="False" AllowSort="False" />
                                                                                        <CellStyle HorizontalAlign="Center">
                                                                                        </CellStyle>
                                                                                    </dx:GridViewDataColumn>

                                                                                    <dx:GridViewDataColumn Name="Notes" Caption="NOTE" VisibleIndex="100" PropertiesEditType="TextBox">
                                                                                        <DataItemTemplate>
                                                                                            <asp:Button runat="server" CssClass="edit_file" ID="btnNote" CommandName="Note"></asp:Button>
                                                                                        </DataItemTemplate>
                                                                                        <Settings AllowHeaderFilter="False" AllowSort="False" />
                                                                                    </dx:GridViewDataColumn>
                                                                                </Columns>
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
                                                                                <SettingsBehavior ColumnResizeMode="Control" AllowSelectSingleRowOnly="true" />
                                                                                <SettingsPager
                                                                                    PageSize="11"
                                                                                    AlwaysShowPager="true">
                                                                                    <PageSizeItemSettings
                                                                                        Visible="true"
                                                                                        ShowAllItem="true" />
                                                                                </SettingsPager>
                                                                                <SettingsPopup>
                                                                                    <HeaderFilter Height="200" />
                                                                                </SettingsPopup>
                                                                                <SettingsDataSecurity
                                                                                    AllowInsert="false"
                                                                                    AllowEdit="false"
                                                                                    AllowDelete="false" />
                                                                            </dx:ASPxGridView>

                                                                            <asp:HiddenField runat="server" ID="hdnSelectedRowVisibleIndex" ClientIDMode="Static" />
                                                                            <asp:HiddenField runat="server" ID="hdnQuotationTabs" ClientIDMode="Static" />
                                                                            <asp:HiddenField runat="server" ID="hdnInsuredAmount" ClientIDMode="Static" />
                                                                            <asp:HiddenField runat="server" ID="hdnTotalPremium" ClientIDMode="Static" />
                                                                            <asp:HiddenField runat="server" ID="hdnInitialPremium" ClientIDMode="Static" />
                                                                            <asp:Button runat="server" ID="btnSelectedRow" OnClick="btnSelectedRow_Click" ClientIDMode="Static" Style="display: none;" />
                                                                        </asp:View>
                                                                        <asp:View ID="vwPOS" runat="server">
                                                                            <dx:ASPxGridView ID="gvPOSCotizaciones"
                                                                                runat="server"
                                                                                ClientIDMode="Static"
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
                                                                                      AgentId;                                                                                                                                                                       
                                                                                      IllustrationStatusCode;
                                                                                      PlanGroupCode;
                                                                                      AssignedSubscriberId;
                                                                                      TipoRiesgoNameKey;
                                                                                      IllustrationNo;
                                                                                      InsuredName;
                                                                                      ProductSubTypeDesc;"
                                                                                EnableCallBacks="False"
                                                                                AutoGenerateColumns="False"
                                                                                OnAfterPerformCallback="gvPOSCotizaciones_AfterPerformCallback"
                                                                                OnBeforeHeaderFilterFillItems="gvPOSCotizaciones_BeforeHeaderFilterFillItems"
                                                                                OnPreRender="gvPOSCotizaciones_PreRender"
                                                                                OnPageIndexChanged="gvPOSCotizaciones_PageIndexChanged">
                                                                                <Columns>
                                                                                    <dx:GridViewDataTextColumn Caption="Tipo de Plan" FieldName="PlanType" Name="PlanTypeLabel" VisibleIndex="0">
                                                                                        <Settings AllowHeaderFilter="False" AllowSort="False" AutoFilterCondition="Contains" />
                                                                                    </dx:GridViewDataTextColumn>
                                                                                    <dx:GridViewDataTextColumn Caption="Número de Cotización Temporal" FieldName="IllustrationNo" Name="ILLUSTRATIONLABEL" VisibleIndex="1">
                                                                                        <Settings AllowHeaderFilter="False" AllowSort="False" AutoFilterCondition="Contains" />
                                                                                    </dx:GridViewDataTextColumn>
                                                                                    <dx:GridViewDataDateColumn Caption="Fecha de la cotización" FieldName="IllustrationDate" Name="Illustration_Date" VisibleIndex="2">
                                                                                        <Settings AllowHeaderFilter="False" AllowSort="False" AutoFilterCondition="Contains" />
                                                                                        <PropertiesDateEdit DisplayFormatString="g" />
                                                                                    </dx:GridViewDataDateColumn>
                                                                                    <dx:GridViewDataTextColumn Caption="Prima sin impuestos" FieldName="TotalPremiumF" Name="PremiumWithoutTax" VisibleIndex="3">
                                                                                        <CellStyle HorizontalAlign="Right" />
                                                                                        <Settings AllowHeaderFilter="False" AllowSort="False" AutoFilterCondition="Contains" />
                                                                                    </dx:GridViewDataTextColumn>
                                                                                    <dx:GridViewDataTextColumn Caption="Monto asegurado" FieldName="InsuredAmountF" Name="InsuredAmount" VisibleIndex="4">
                                                                                        <CellStyle HorizontalAlign="Right" />
                                                                                        <Settings AllowHeaderFilter="False" AllowSort="False" AutoFilterCondition="Contains" />
                                                                                    </dx:GridViewDataTextColumn>
                                                                                    <dx:GridViewDataTextColumn Caption="Oficina" FieldName="Office" Name="Office" VisibleIndex="5">
                                                                                        <Settings AllowHeaderFilter="False" AllowSort="False" AutoFilterCondition="Contains" />
                                                                                    </dx:GridViewDataTextColumn>
                                                                                    <dx:GridViewDataTextColumn Caption="Vendedor" FieldName="AgentName" Name="Vendor" VisibleIndex="6">
                                                                                        <Settings AllowHeaderFilter="False" AllowSort="False" AutoFilterCondition="Contains" />
                                                                                    </dx:GridViewDataTextColumn>
                                                                                    <dx:GridViewDataTextColumn Caption="Telefono Vendedor" FieldName="AgentPhones" Name="TelefonoVendedor" VisibleIndex="7">
                                                                                        <Settings AllowHeaderFilter="False" AllowSort="False" AutoFilterCondition="Contains" />
                                                                                    </dx:GridViewDataTextColumn>
                                                                                    <dx:GridViewDataTextColumn Caption="Asegurado" FieldName="InsuredName" Name="INSURED" VisibleIndex="8">
                                                                                        <Settings AllowHeaderFilter="False" AllowSort="False" AutoFilterCondition="Contains" />
                                                                                    </dx:GridViewDataTextColumn>
                                                                                </Columns>
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
                                                                                <SettingsBehavior ColumnResizeMode="Control" AllowSelectSingleRowOnly="true" />
                                                                                <SettingsPager
                                                                                    PageSize="11"
                                                                                    AlwaysShowPager="true">
                                                                                    <PageSizeItemSettings
                                                                                        Visible="true"
                                                                                        ShowAllItem="true" />
                                                                                </SettingsPager>
                                                                                <SettingsPopup>
                                                                                    <HeaderFilter Height="200" />
                                                                                </SettingsPopup>
                                                                                <SettingsDataSecurity
                                                                                    AllowInsert="false"
                                                                                    AllowEdit="false"
                                                                                    AllowDelete="false" />
                                                                            </dx:ASPxGridView>
                                                                        </asp:View>
                                                                    </asp:MultiView>
                                                                </div>
                                                            </asp:Panel>
                                                            <asp:Panel ID="pnlStatisticsGridView" runat="server" Visible="false">
                                                                <div class="grid_wrap">
                                                                    <asp:MultiView ActiveViewIndex="0" ID="mvStatistics" runat="server">
                                                                        <asp:View ID="vwEmisiones" runat="server">
                                                                            <uc1:UCEmisiones runat="server" ID="UCEmisiones" />
                                                                        </asp:View>
                                                                        <asp:View ID="vwPerformance" runat="server">
                                                                            <uc1:UCPerformance runat="server" ID="UCPerformance" />
                                                                        </asp:View>
                                                                    </asp:MultiView>
                                                                </div>
                                                            </asp:Panel>
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
                                                    <div class="grupos de_4_b last">
                                                        <div class="grupos de_5">
                                                            <asp:Panel runat="server" ID="pnlPrintInvoice" OnPreRender="pnlPrintInvoice_PreRender">
                                                                <div class="btn_celeste">
                                                                    <span class="see_ilustracion"></span>
                                                                    <asp:Button runat="server" CssClass="boton" Text="" ID="btnPrintInvoice" OnClick="btnPrintInvoice_Click" OnClientClick="return ValidateTabForDeterminatePrintInvoce()" />
                                                                </div>
                                                            </asp:Panel>
                                                            <asp:Panel runat="server" ID="pnlAssignIllustrations">
                                                                <div class="btn_celeste">
                                                                    <span class="see_ilustracion"></span>
                                                                    <asp:Button runat="server" CssClass="boton" Text="" ID="btnOpenAssignIllustrations" OnClientClick="return ValidateCheck('#gvIllustration','Youcanonlyassignquote');" OnClick="btnOpenAssignIllustrations_Click" />
                                                                </div>
                                                            </asp:Panel>
                                                            <asp:Panel runat="server" ID="pnlApprovedBySubscription" Visible="false">
                                                                <div class="btn_celeste">
                                                                    <span class="see_ilustracion"></span>
                                                                    <asp:Button runat="server" CssClass="boton" Text="" ID="btnApproveBySubscription" OnClick="btnApproveBySubscription_Click" OnClientClick="return ValidateSendToCore(this,'gvIllustration')" />
                                                                </div>
                                                            </asp:Panel>

                                                            <asp:Panel runat="server" ID="pnlDeclinedByClient" Visible="false">
                                                                <div class="btn_celeste">
                                                                    <span class="see_ilustracion"></span>
                                                                    <asp:Button runat="server" CssClass="boton" Text="DECLINED BY CLIENT" ID="btnDeclinedByClient" ClientIDMode="Static" OnClientClick="return ChangeIllustrationStatus(this)" />
                                                                </div>
                                                                <!--btn_celeste-->
                                                            </asp:Panel>

                                                            <asp:Panel runat="server" ID="pnlLocaleQuotFlat">
                                                                <div class="btn_celeste">
                                                                    <span class="see_ilustracion"></span>
                                                                    <asp:Button runat="server" CssClass="boton" Text="Locate Quote" ID="btnLocaleQuotFlat" ClientIDMode="Static" OnClick="btnLocaleQuotFlat_Click" />
                                                                </div>
                                                                <!--btn_celeste-->
                                                            </asp:Panel>

                                                            <asp:Panel runat="server" ID="pnlSubscription" Visible="false">
                                                                <div class="btn_celeste">
                                                                    <span class="see_ilustracion"></span>
                                                                    <asp:Button runat="server" CssClass="boton" Text="SUBSCRIPTION" ID="btnSubscription" OnClientClick="return ChangeIllustrationStatus(this)" />
                                                                </div>
                                                                <!--btn_celeste-->
                                                            </asp:Panel>

                                                            <asp:Panel ID="pnFlatTableRefresh" CssClass="fr" runat="server" Visible="true">
                                                                <div class="btn_celeste">
                                                                    <span class="add_ilustracion"></span>
                                                                    <asp:Button runat="server" CssClass="boton" ID="btnFlatTableRefresh" Text="Flat Table Refresh" OnClick="btnFlatTableRefresh_Click" OnClientClick="return ValidateCheck('#gvIllustration','Youcanonlyassignquote');" />
                                                                </div>
                                                                <!--btn_celeste-->
                                                            </asp:Panel>

                                                            <asp:Panel ID="pnlExportExcel" CssClass="fr" runat="server" Visible="true">
                                                                <div class="btn_celeste">
                                                                    <span class="add_ilustracion"></span>
                                                                    <asp:Button runat="server" CssClass="boton" ID="btnPrintList" Text="EXPORT TO EXCEL" OnClick="btnPrintList_Click" />
                                                                </div>
                                                                <!--btn_celeste-->
                                                            </asp:Panel>
                                                        </div>
                                                    </div>
                                                    <!--grupos-->
                                                </div>
                                                <!--grupos-->
                                            </div>
                                            <!--barra_sub_menu-->
                                        </div>
                                    </li>
                                </ul>
                            </li>
                        </ul>

                    </div>
                    <!--grid grid-pad-->
                </div>
                <!--contendio derecha-->
            </div>
            <!-- /main clearfix -->
        </div>

        <uc1:UCPopupChangeStatusSaveNotes runat="server" ID="ucPopupChangeStatusSaveNotes" />
        <asp:ModalPopupExtender ID="popAssignIllustrations" PopupControlID="AssignIllustrations" DropShadow="false" BackgroundCssClass="ModalBackgroud3" TargetControlID="hdnShowPopAssignIllustration" BehaviorID="popupBhvrShowPopAssignIllustration" runat="server" />
        <asp:Panel runat="server" ID="AssignIllustrations" CssClass="modalPopup" ClientIDMode="Static" Style="display: none">
            <div class="pop_up_wrapper" style="width: 300px; height: 371px; overflow-x: hidden; overflow-y: hidden; background-color: #525659;">
                <!--escriben por style el ancho que desean-->
                <div class="titulos_azules head_contengridproxi PreviewPDF" style="width: 100%;">
                    <ul>
                        <li style="position: absolute; top: 31%;">
                            <asp:Label ID="ltTypeDoc2" ClientIDMode="Static" runat="server"></asp:Label>
                        </li>
                        <li style="top: 13%;">
                            <input type="button" id="close_pop_up" class="cls_pup" style="background-color: transparent; border: 0px;" onclick="closePopAssignIllustration()" />
                        </li>
                    </ul>
                </div>
                <!--titulos_azules-->
                <div id="frmAssignIllustrations" class="barra_sub_menu">
                    <div class="grupos">
                        <asp:Label ID="lblAssignIllustrationMessage" runat="server" CssClass="label backgroundtransparent"></asp:Label>
                        <div id="divAssignListPolicies">
                            <table>
                                <thead>
                                    <tr>
                                        <th class="dxgvHeader_DevEx"></th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr class="dxgvDataRow_DevEx">
                                        <td class="dxgv">
                                            <asp:Literal runat="server" ID="ltSelectedPolicy"></asp:Literal>
                                            <asp:HiddenField runat="server" ID="PolicyKey" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <asp:Label runat="server" ID="lblAssignIllustrations" ClientIDMode="Static" CssClass="label backgroundtransparent"></asp:Label>
                        <div>
                            <asp:TextBox runat="server" ID="txtAgentsOrSubscriptor" ClientIDMode="Static" Style="width: 281px;"></asp:TextBox>
                        </div>
                        <asp:Panel runat="server" ID="divdrpAsignIllustrations" CssClass="wrap_select" Style="display: none">
                            <asp:DropDownList runat="server" ID="drpAssignIllustrationsSubscribers" ClientIDMode="Static" validation="Required"></asp:DropDownList>
                        </asp:Panel>
                        <div class="btn_celeste">
                            <span class="submit_celeste"></span>
                            <asp:Button runat="server" ID="btnAssignIllustrations" ClientIDMode="Static" CssClass="boton" OnClick="btnAssignIllustrations_Click" OnClientClick="return validateForm('frmAsignIllustrations');" />
                        </div>
                    </div>
                </div>
                <!--content_fondo_blanco-->
            </div>
        </asp:Panel>

        <asp:ModalPopupExtender ID="popLocateQuotFlat" PopupControlID="LocaleQuotFlat" DropShadow="false" BackgroundCssClass="ModalBackgroud3" TargetControlID="hdnShowpopLocateQuotFlat" BehaviorID="popupBhvrShowPopLocateQuotFlat" runat="server" />
        <asp:Panel runat="server" ID="LocaleQuotFlat" CssClass="modalPopup" ClientIDMode="Static" Style="display: none">
            <div class="pop_up_wrapper" style="width: 300px; /*height: 250px; */ overflow-x: hidden; overflow-y: hidden; background-color: #525659;">
                <!--escriben por style el ancho que desean-->
                <div class="titulos_azules head_contengridproxi PreviewPDF" style="width: 100%;">
                    <ul>
                        <li style="position: absolute; top: 31%;">
                            <asp:Label ID="Label1" ClientIDMode="Static" runat="server"></asp:Label>
                        </li>
                        <li style="top: 13%;">
                            <input type="button" id="close_pop_up" class="cls_pup" style="background-color: transparent; border: 0px;" onclick="closePopLocateQuotFlat()" />
                        </li>
                    </ul>
                </div>
                <!--titulos_azules-->
                <div id="frmAssignIllustrations_1" class="barra_sub_menu">
                    <div class="grupos">
                        <asp:Label runat="server" ID="Label3" ClientIDMode="Static" CssClass="label backgroundtransparent">Número de Cotización</asp:Label>
                        <br />
                        <asp:TextBox runat="server" ID="txtQuotNumberFlat" ClientIDMode="Static" Style="width: 281px;"></asp:TextBox>
                        <br />
                        <asp:Label runat="server" ID="lblTab" ClientIDMode="Static" CssClass="label backgroundtransparent" Visible="false"></asp:Label>
                        <br />
                        <div class="btn_celeste">
                            <span class="submit_celeste"></span>
                            <asp:Button runat="server" ID="btnLocateQFlat" ClientIDMode="Static" CssClass="boton" Text="Localizar" OnClick="btnLocateQFlat_Click" />
                        </div>
                    </div>
                </div>
                <!--content_fondo_blanco-->
            </div>
        </asp:Panel>

        <asp:ModalPopupExtender ID="ModalPrintingInvoice" PopupControlID="pnPrintingInvoice" DropShadow="false" BackgroundCssClass="ModalBackgroud3" TargetControlID="hdnShowpoppnPrintingInvoice" BehaviorID="popupBhvrShowPoppnPrintingInvoice" runat="server" />
        <asp:Panel runat="server" ID="pnPrintingInvoice" CssClass="modalPopup" ClientIDMode="Static" Style="display: none">
            <uc1:UCPrintingInvoice runat="server" ID="UCPrintingInvoice" />
        </asp:Panel>
        <asp:Button runat="server" ID="btnReorderColumnsGrid" OnClick="btnReorderColumnsGrid_Click"  ClientIDMode="Static"/>
        <asp:HiddenField runat="server" Value="" ID="hdnCounter" ClientIDMode="Static" />
        <asp:HiddenField runat="server" ID="hdnPreSuscripcion" Value="true" />
        <asp:HiddenField runat="server" ID="hdnSuscripcion" Value="true" />
        <asp:HiddenField runat="server" ID="hdnHistorico" Value="true" />
        <asp:HiddenField runat="server" ID="hdnGroupTabIndex" Value="0" />
        <asp:HiddenField runat="server" ID="hdnIsLoad" Value="false" />
        <asp:HiddenField runat="server" ID="hdnAccordeonIllustrationList" Value="acc1|0" ClientIDMode="Static" />
        <asp:HiddenField runat="server" ID="hdnAccordeonFiltersList" Value="acc2|0" ClientIDMode="Static" />
        <asp:HiddenField runat="server" ID="hdnValidate" ClientIDMode="Static" Value="true" />
        <asp:HiddenField runat="server" ID="hdnTabSelected" ClientIDMode="Static" Value="" />
        <asp:HiddenField runat="server" ID="hdnTabGroup" ClientIDMode="Static" Value="lnkPreSuscripcion" />
        <asp:HiddenField runat="server" Value="0" ID="hdnBusinessLineId" ClientIDMode="Static" />
        <asp:HiddenField runat="server" ID="hdnShowPopAssignIllustration" ClientIDMode="Static" Value="false" />
        <asp:HiddenField runat="server" ID="hdnCounterFreQ" ClientIDMode="Static" />
        <asp:HiddenField runat="server" ID="hdnParameters" ClientIDMode="Static" Value="" />
        <asp:HiddenField runat="server" ID="hdnTabBandeja" ClientIDMode="Static" Value="" />
        <asp:HiddenField runat="server" ID="hdnShowpopLocateQuotFlat" ClientIDMode="Static" Value="false" />
        <asp:HiddenField runat="server" ID="hdnShowpoppnPrintingInvoice" ClientIDMode="Static" Value="false" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="lnkPuntoVentaTab" />
        <asp:AsyncPostBackTrigger ControlID="lnkIllustrationsToWork" />
        <asp:AsyncPostBackTrigger ControlID="lnkHistoricalIllustrations" />
        <asp:AsyncPostBackTrigger ControlID="lnkIncompleteIllustration" />
        <asp:AsyncPostBackTrigger ControlID="lnkCompleteIllustrations" />
        <asp:AsyncPostBackTrigger ControlID="lnkApprovedByClient" />
        <asp:AsyncPostBackTrigger ControlID="lnkSubscriptions" />
        <asp:AsyncPostBackTrigger ControlID="lnkExpired" />
        <asp:AsyncPostBackTrigger ControlID="lnkExpiring" />
        <asp:AsyncPostBackTrigger ControlID="lnkDeclinedByClient" />
        <asp:AsyncPostBackTrigger ControlID="lnkDeclinedBySubscription" />
        <asp:AsyncPostBackTrigger ControlID="lnkMissingDocuments" />
        <asp:AsyncPostBackTrigger ControlID="lnkMissingInspections" />
        <asp:AsyncPostBackTrigger ControlID="lnkApprovedBySubscription" />
        <asp:AsyncPostBackTrigger ControlID="gvIllustration" />
        <asp:AsyncPostBackTrigger ControlID="lnkStatistics" />
        <asp:AsyncPostBackTrigger ControlID="lnkConfirmationCall" />
        <asp:AsyncPostBackTrigger ControlID="lnkDiscounts" />
        <asp:PostBackTrigger ControlID="btnPrintList" />
        <asp:AsyncPostBackTrigger ControlID="lnkPreSuscripcion" />
        <asp:AsyncPostBackTrigger ControlID="lnkSuscripcion" />
        <asp:AsyncPostBackTrigger ControlID="lnkHistorico" />
        <asp:AsyncPostBackTrigger ControlID="lnkFacultative" />
        <asp:AsyncPostBackTrigger ControlID="btnLocaleQuotFlat" />
    </Triggers>
</asp:UpdatePanel>
<div style="display: none;">
    <dx:ASPxGridView ID="gvFakeGridView" runat="server" ClientIDMode="Static" EnableCallBacks="False" AutoGenerateColumns="true">
    </dx:ASPxGridView>
    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="gvFakeGridView" ExportedRowType="All"></dx:ASPxGridViewExporter>
</div>
