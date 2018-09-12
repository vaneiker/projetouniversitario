<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HistoricalCasesContainer.ascx.cs" Inherits="WEB.NewBusiness.DReview.UserControl.HistoricalCases.HistoricalCasesContainer" %>
<%@ Register Src="~/DReview/UserControl/HistoricalCases/WUCApprovedCases.ascx" TagPrefix="uc1" TagName="WUCApprovedCases" %>
<%@ Register Src="~/DReview/UserControl/HistoricalCases/WUCRejectedCases.ascx" TagPrefix="uc1" TagName="WUCRejectedCases" %>
 <!--Bmarroquin 19-04-2017 se agrega tab de rechazados por cumplimiento-->
<%@ Register Src="~/DReview/UserControl/HistoricalCases/WUCRejectedCompliance.ascx" TagPrefix="uc1" TagName="WUCRejectedCompliance" %>

<asp:UpdatePanel runat="server" id="upHistoricalCasesContainer">
    <ContentTemplate>
        <div class="grid grid-pad">
            <div class="col-1-1">
                <div class="contenedor_tabs">
                    <ul class="tabs_ttle dvddo_in_3" id="MenuTabHistoricalCases">
                        <li>
                            <asp:LinkButton runat="server" ID="lnkApprovedCases" ClientIDMode="Static" OnClick="ManageTabs" OnClientClick="BeginRequestHandler()"> <%= RESOURCE.UnderWriting.NewBussiness.Resources.APPROVEDCASES %> </asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton runat="server" ID="lnkRejectedCases" ClientIDMode="Static" OnClick="ManageTabs" OnClientClick="BeginRequestHandler()"> <%=RESOURCE.UnderWriting.NewBussiness.Resources.REJECTEDCASES %></asp:LinkButton>
                        </li>
                          <!--Bmarroquin 19-04-2017 se agrega tab (li) de rechazados por cumplimiento-->
                        <li>
                            <asp:LinkButton runat="server" ID="lnkRejectedByCompliance" ClientIDMode="Static" OnClick="ManageTabs" OnClientClick="BeginRequestHandler()"> <%=RESOURCE.UnderWriting.NewBussiness.Resources.tabRejectCompliLabel %></asp:LinkButton>
                        </li>
                    </ul>
                </div>
                <!--contenedor_tabs-->
                <div class="fondo_gris">
                    <div class="col-1-1">
                        <div class="content_fondo_gris">
                            <asp:MultiView runat="server" ID="mtvHistoricalCases">
                                <asp:View runat="server" ID="vApprovedCases">
                                    <uc1:WUCApprovedCases runat="server" ID="WUCApprovedCases" />
                                </asp:View>
                                <asp:View runat="server" ID="vRejectedCases">
                                    <uc1:WUCRejectedCases runat="server" ID="WUCRejectedCases" />
                                </asp:View>
                                <!--Bmarroquin 19-04-2017 se agrega grid de rechazados por cumplimiento-->
                                <asp:View runat="server" ID="vRejectedCompliance">
                                    <uc1:WUCRejectedCompliance runat="server" ID="WUCRejectedCompliance" />
                                </asp:View>
                            </asp:MultiView>

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
                        <div class="grupos de_2">
                            <div>
                                <div class="btn_celeste">
                                    <span class="iconos_botones_azules_virtualoffice"></span>
                                    <asp:Button ID="btnExport" runat="server" Text="EXPORT" CssClass="boton" OnClick="btnExport_Click" />
                                </div>
                                <!--btn_celeste-->
                            </div>
                        </div>
                    </div>
                    <!--grupos-->
                </div>
                <!--barra_sub_menu-->
            </div>
            <!--col-1-1-->
        </div>
        <asp:HiddenField runat="server" ID="hdnCurrentTabHistoricalCases" ClientIDMode="Static" Value="lnkApprovedCases" />
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btnExport" />
    </Triggers>
</asp:UpdatePanel>