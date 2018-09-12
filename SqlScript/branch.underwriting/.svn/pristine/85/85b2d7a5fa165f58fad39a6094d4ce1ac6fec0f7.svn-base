<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCTransport.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.IllustrationAlliedLines.Products.UCTransport" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/NewBusiness/UserControls/IllustrationAlliedLines/Products/UCCoverages.ascx" TagPrefix="uc1" TagName="UCCoverages" %>
<%@ Register Src="~/NewBusiness/UserControls/IllustrationAlliedLines/UCTransportDetail.ascx" TagPrefix="uc1" TagName="UCTransportDetail" %>
<%@ Register Src="~/NewBusiness/UserControls/IllustrationAlliedLines/UCEndosoCesionAlliedLines.ascx" TagPrefix="uc1" TagName="UCEndosoCesionAlliedLines" %>
<%@ Register Assembly="PdfViewerAspNet" Namespace="PdfViewer4AspNet" TagPrefix="PdfViewer" %>
<%@ Register Src="~/NewBusiness/UserControls/Common/WUCBlackListValidation.ascx" TagPrefix="uc1" TagName="WUCBlackListValidation" %>

<dx:ASPxGridView
    ID="gvTransportDetail"
    runat="server"
    EnableCallBacks="False"
    KeyFieldName="UniqueTransportId;InsuredAmount"
    ClientIDMode="Static"
    AutoGenerateColumns="false"
    Width="100%"
    OnRowCommand="gvAlliedLinesDetail_RowCommand"
    OnPreRender="gvTransportDetail_PreRender">
    <Columns>
        <dx:GridViewDataColumn Caption="Editar" Name="View" Visible="true" VisibleIndex="0">
            <DataItemTemplate>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div style="text-align: center">
                            <asp:LinkButton
                                runat="server"
                                ID="lnkEdit"
                                CommandName="EditTransport" CssClass="view_file">
                            </asp:LinkButton>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnkEdit" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </DataItemTemplate>
            <Settings AllowHeaderFilter="False" AllowSort="False" />
        </dx:GridViewDataColumn>
        <dx:GridViewDataTextColumn Caption="BuninessTypeLabel" FieldName="BuninessType" Name="BuninessTypeLabel" CellStyle-HorizontalAlign="Center" VisibleIndex="1">
            <Settings AllowHeaderFilter="False" AllowSort="False" />
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn Caption="ActivityLabel" FieldName="Activity" Name="ActivityLabel" CellStyle-HorizontalAlign="Center" VisibleIndex="2">
            <Settings AllowHeaderFilter="False" AllowSort="False" />
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn Caption="MerchandasingTypeeLabel" FieldName="MerchandasingType" Name="MerchandasingTypeeLabel" CellStyle-HorizontalAlign="Center" VisibleIndex="3">
            <Settings AllowHeaderFilter="False" AllowSort="False" />
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn Caption="pól. Princ." FieldName="PolicyNoMain" Name="PolicyNumberMain" Visible="false" CellStyle-HorizontalAlign="Center" VisibleIndex="4">
            <Settings AllowHeaderFilter="False" AllowSort="False" />
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn Caption="Plan" FieldName="ProductDesc" Name="PlanLabel" CellStyle-HorizontalAlign="Center" VisibleIndex="5">
            <Settings AllowHeaderFilter="False" AllowSort="False" />
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn Caption="Monto Asegurado" FieldName="InsuredAmountF" Name="InsuredAmount" CellStyle-HorizontalAlign="Center" VisibleIndex="6">
            <Settings AllowHeaderFilter="False" AllowSort="False" />
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn Caption="Prima sin Impuesto" FieldName="PremiumAmountF" Name="PremiumWithoutTax" CellStyle-HorizontalAlign="Center" VisibleIndex="7">
            <Settings AllowHeaderFilter="False" AllowSort="False" />
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataColumn Caption="Cobertura" Name="Coverage" Width="100" VisibleIndex="8">
            <DataItemTemplate>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div style="text-align: center">
                            <asp:LinkButton runat="server" ID="lnkCoverage" CommandName="Coverage" CssClass="view_file"></asp:LinkButton>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnkCoverage" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </DataItemTemplate>
            <Settings AllowHeaderFilter="False" AllowSort="False" />
        </dx:GridViewDataColumn>
        <dx:GridViewDataColumn Caption="Endoso" Name="Endorsement" Width="100" VisibleIndex="9">
            <DataItemTemplate>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div style="text-align: center">
                            <asp:LinkButton
                                runat="server"
                                ID="lnkEndosoCesion"
                                CommandName="Endoso"
                                CssClass='<%# Eval("ClassEndoso")%>'></asp:LinkButton>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnkEndosoCesion" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </DataItemTemplate>
            <Settings AllowHeaderFilter="False" AllowSort="False" />
        </dx:GridViewDataColumn>
        <dx:GridViewDataColumn Name="BlackList">
            <DataItemTemplate>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <asp:LinkButton
                            runat="server"
                            ID="lnkBlackList"
                            CommandName="BlackList"
                            CssClass='view_file'></asp:LinkButton>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnkBlackList" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </DataItemTemplate>
        </dx:GridViewDataColumn>
    </Columns>
    <SettingsPager PageSize="20" AlwaysShowPager="true">
        <PageSizeItemSettings Visible="false" ShowAllItem="true" />
    </SettingsPager>
    <SettingsBehavior AllowSelectSingleRowOnly="false" AllowSort="False" AllowFocusedRow="false" />
    <Settings ShowFooter="True" />
</dx:ASPxGridView>
<asp:ModalPopupExtender ID="ModalPopupCoverage" PopupControlID="popCoverage" DropShadow="false" BackgroundCssClass="ModalBackgroud3" TargetControlID="hdnTransportCoverages" BehaviorID="TransportupBhvrnavyCoverages" runat="server"></asp:ModalPopupExtender>
<asp:Panel runat="server" ID="popCoverage" ClientIDMode="Static">
    <div class="pop_up_wrapper" style="width: 936px; height: 775px; overflow-x: hidden; overflow-y: hidden">
        <!--escriben por style el ancho que desean-->
        <div class="titulos_azules head_contengridproxi PreviewPDF" style="width: 100%;">
            <ul>
                <li style="position: absolute; left: 41%; top: 31%;">
                    <asp:Label ID="Label1" ClientIDMode="Static" runat="server" Text="COBERTURAS"></asp:Label>
                </li>
                <li style="top: 13%;">
                    <input type="button" id="close_pop_up" class="cls_pup" style="background-color: transparent; border: none;" onclick="CloseTransportCoverage();" />
                </li>
            </ul>
        </div>
        <uc1:UCCoverages runat="server" ID="UCCoverages" />
        <!--content_fondo_blanco-->
    </div>
</asp:Panel>
<asp:ModalPopupExtender ID="mpeTransportDetail" PopupControlID="pnTransportDetail" DropShadow="false" BackgroundCssClass="ModalBackgroud3" TargetControlID="hdnPopTransportDetail" BehaviorID="popupBhvrTransportDetail" runat="server"></asp:ModalPopupExtender>
<asp:Panel runat="server" ID="pnTransportDetail" CssClass="modalPopup" ClientIDMode="Static" Style="display: none">
    <div class="pop_up_wrapper" style="width: 1564px; height: 838px; overflow-x: hidden; overflow-y: hidden">
        <!--escriben por style el ancho que desean-->
        <div class="titulos_azules head_contengridproxi PreviewPDF" style="width: 100%;">
            <ul>
                <li style="position: absolute; left: 41%; top: 31%;">
                    <asp:Label ID="lblTitle" ClientIDMode="Static" runat="server"></asp:Label>
                </li>
                <li style="top: 13%;">
                    <input type="button" id="close_pop_up" class="cls_pup" style="background-color: transparent; border: none;" onclick="ClosePopTransportDetail();" />
                </li>
            </ul>
        </div>
        <!--titulos_azules-->
        <uc1:UCTransportDetail runat="server" ID="UCTransportDetail" />
        <!--content_fondo_blanco-->
    </div>
</asp:Panel>
<asp:ModalPopupExtender ID="ModalPopupEndoso" PopupControlID="popEndoso" DropShadow="false" BackgroundCssClass="ModalBackgroud3" TargetControlID="hdnEndosoPopup" BehaviorID="popupEndoso" runat="server"></asp:ModalPopupExtender>
<asp:Panel runat="server" ID="popEndoso" CssClass="modalPopup" ClientIDMode="Static" Style="display: none">
    <div class="pop_up_wrapper tbl data_Gpl coberageT" style="width: 800px; height: 452px; border: 1px solid #000; overflow-x: hidden; overflow-y: hidden">
        <!--escriben por style el ancho que desean-->
        <div class="titulos_azules head_contengridproxi PreviewPDF" style="width: 100%;">
            <ul>
                <li style="position: absolute; left: 41%; top: 18%;">
                    <span><%=RESOURCE.UnderWriting.NewBussiness.Resources.EndosoTitulo%></span>
                </li>
                <li style="top: 13%;">
                    <input type="button" class="cls_pup" style="background-color: transparent; border: none;" onclick="ClosePopEndoso();" />
                </li>
            </ul>
        </div>
        <!--titulos_azules-->
        <uc1:UCEndosoCesionAlliedLines runat="server" ID="UCEndosoCesionAlliedLines" />
        <!--content_fondo_blanco-->
    </div>
</asp:Panel>
<asp:ModalPopupExtender ID="ModalPopupShowPDF" PopupControlID="pnShowPDF" DropShadow="false" BackgroundCssClass="ModalBackgroud3" TargetControlID="hdnShowPDF" BehaviorID="popupBhvr1PDF" runat="server"></asp:ModalPopupExtender>
<asp:Panel runat="server" ID="pnShowPDF" CssClass="modalPopup" ClientIDMode="Static" Style="display: none;">
    <div class="pop_up_wrapper" style="width: 1189px; height: 752px; overflow-x: hidden; overflow-y: hidden">
        <!--escriben por style el ancho que desean-->
        <div class="titulos_azules head_contengridproxi PreviewPDF" style="width: 100%;">
            <ul>
                <li style="position: absolute; left: 41%; top: 31%;">
                    <asp:Label ID="ltTypeDoc2" ClientIDMode="Static" runat="server"><%=RESOURCE.UnderWriting.NewBussiness.Resources.PrintPdfHeader %></asp:Label>
                </li>
                <li style="top: 13%;">
                    <input type="button" id="close_pop_up" class="cls_pup" style="background-color: transparent; border: 0;" onclick="ClosePop();" />
                </li>
            </ul>
        </div>
        <!--titulos_azules-->
        <PdfViewer:PdfViewer
            ID="pdfViewerMyPreviewPDF"
            CssClass="PdfViewer"
            runat="server"
            Height="712"
            Width="1186"
            ClientIDMode="Static"
            ShowScrollbars="true"
            ShowToolbarMode="Show">
        </PdfViewer:PdfViewer>
        <!--content_fondo_blanco-->
    </div>
</asp:Panel>

<asp:ModalPopupExtender ID="ModalPopupBlackList" PopupControlID="popBlackList" DropShadow="false" BackgroundCssClass="ModalBackgroud3" TargetControlID="hdnPopBlackList" BehaviorID="popupBlackList" runat="server"></asp:ModalPopupExtender>
<asp:Panel runat="server" ID="popBlackList" CssClass="modalPopup" ClientIDMode="Static" Style="display: none">
    <div class="pop_up_wrapper tbl data_Gpl coberageT" style="width: 800px; height: 340px; border: 1px solid #000; overflow-x: hidden; overflow-y: hidden">
        <!--escriben por style el ancho que desean-->
        <div class="titulos_azules head_contengridproxi PreviewPDF" style="width: 100%;">
            <ul>
                <li style="position: absolute; left: 41%; top: 18%;">
                    <span><%=RESOURCE.UnderWriting.NewBussiness.Resources.BlackList%></span>
                </li>
                <li style="top: 13%;">
                    <input type="button" class="cls_pup" style="background-color: transparent; border: none;" onclick="ClosePopBlackList();" />
                </li>
            </ul>
        </div>
        <!--titulos_azules-->
        <uc1:WUCBlackListValidation runat="server" ID="WUCBlackListValidation" />
        <!--content_fondo_blanco-->
        <asp:HiddenField runat="server" Value="false" ID="hdnPopBlackList" ClientIDMode="Static" />
    </div>
</asp:Panel>
<asp:HiddenField runat="server" ID="hdnTransportCoverages" Value="false" ClientIDMode="Static" />
<asp:HiddenField runat="server" ID="hdnPopTransportDetail" Value="false" ClientIDMode="Static" />
<asp:HiddenField runat="server" Value="false" ID="hdnEndosoPopup" ClientIDMode="Static" />
<asp:HiddenField runat="server" Value="false" ID="hdnShowPDF" ClientIDMode="Static" />
