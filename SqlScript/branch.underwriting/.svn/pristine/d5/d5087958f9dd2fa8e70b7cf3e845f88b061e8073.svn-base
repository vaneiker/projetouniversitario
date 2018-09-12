<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCPrintingInvoice.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.Illustration.UCPrintingInvoice" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="PdfViewerAspNet" Namespace="PdfViewer4AspNet" TagPrefix="PdfViewer" %>
<div class="pop_up_wrapper" style="width: 500px; /*height: 250px; */ overflow-x: hidden; overflow-y: hidden;">
    <!--escriben por style el ancho que desean-->
    <div class="titulos_azules head_contengridproxi PreviewPDF" style="width: 100%;">
        <ul>
            <li style="position: absolute; top: 31%;">
                <asp:Label ID="Label1" ClientIDMode="Static" runat="server">IMPRESION DE FACTURA</asp:Label>
            </li>
            <li style="top: 13%;">
                <input type="button" id="close_pop_up" class="cls_pup" style="background-color: transparent; border: 0px;" onclick="closePopPrintInvoice()" />
            </li>
        </ul>
    </div>
    <!--titulos_azules-->
    <div class="cont_gnl tab_pane_container rcomp mT25 mB20 fl padding10">
        <div class="col-4 fl">
            <div class="label_plus_input par mT20">
                <span>Número de Poliza</span>
            </div>
        </div>
        <div class="col-4 fl">
            <div class="label_plus_input par mT15">
                <asp:TextBox runat="server" ID="txtPolicyNumber"></asp:TextBox>
            </div>
        </div>
        <div class="col-4 fl">
            <div class="label_plus_input par">
                <div class="boton_wrapper verde ">
                    <span class=" search"></span>
                    <asp:Button runat="server" Text="BUSCAR" ID="btnSearch" CssClass="boton" OnClick="btnSearch_Click" />
                </div>
            </div>
        </div>
        <div class="fl col-1-1">
            <dx:ASPxGridView ID="gvInvoices"
                runat="server"
                ClientIDMode="Static"
                EnableCallBacks="False"
                AutoGenerateColumns="False"
                KeyFieldName="InvoiceNumber">
                <Columns>
                    <dx:GridViewDataCheckColumn Caption="" VisibleIndex="0" Width="50px" Name="CheckSelect">
                        <DataItemTemplate>
                            <asp:CheckBox runat="server" ID="chkSelect" />
                        </DataItemTemplate>
                    </dx:GridViewDataCheckColumn>
                    <dx:GridViewDataColumn Caption="Fecha Factura" FieldName="InvoiceDate">
                        <Settings AllowHeaderFilter="False" AllowSort="False" />
                    </dx:GridViewDataColumn>
                    <dx:GridViewDataColumn Caption="Numero Factura" FieldName="InvoiceNumber">
                        <Settings AllowHeaderFilter="False" AllowSort="False" />
                    </dx:GridViewDataColumn>
                    <dx:GridViewDataColumn Caption="Concepto" FieldName="Concept" Width="50%">
                        <Settings AllowHeaderFilter="False" AllowSort="False" />
                    </dx:GridViewDataColumn>
                </Columns>
                <Settings
                    HorizontalScrollBarMode="Visible"
                    VerticalScrollableHeight="200"
                    VerticalScrollBarMode="Visible"
                    ShowGroupPanel="false"
                    ShowFooter="true"
                    ShowHeaderFilterButton="true"
                    ShowFilterRowMenu="true"
                    ShowFilterRowMenuLikeItem="false" />
                <SettingsBehavior ColumnResizeMode="Control" AllowSelectSingleRowOnly="true" />                
                <SettingsDataSecurity
                    AllowInsert="false"
                    AllowEdit="false"
                    AllowDelete="false" />
            </dx:ASPxGridView>
        </div>
        <div class="col-1-1 fl mT10">
            <div class="btn_celeste">
                <span class="print_list_celeste"></span>
                <asp:Button runat="server" Text="IMPRIMIR" ID="btnImprimir" CssClass="boton" OnClientClick="return ValidateCheck('#gvInvoices','YoucanonlyInvoiceSelect');" Style="line-height: 28px;" OnClick="btnImprimir_Click" />
            </div>
        </div>
    </div>
    <!--content_fondo_blanco-->
</div>
<asp:ModalPopupExtender ID="mpeFactura" PopupControlID="pnFactura" DropShadow="false" BackgroundCssClass="ModalBackgroud3" TargetControlID="hdnPopFactura" BehaviorID="popupBhvrFactura" runat="server"></asp:ModalPopupExtender>
<asp:Panel runat="server" ID="pnFactura" CssClass="modalPopup" ClientIDMode="Static" Style="display: none">
    <div class="pop_up_wrapper" style="width: 1034px; height: 712px; overflow-x: hidden; overflow-y: hidden">
        <!--escriben por style el ancho que desean-->
        <div class="titulos_azules head_contengridproxi PreviewPDF" style="width: 100%;">
            <ul>
                <li style="position: absolute; left: 41%; top: 31%;">
                    <asp:Label ID="lblTitle" ClientIDMode="Static" runat="server">Factura</asp:Label>
                </li>
                <li style="top: 13%;">
                    <input type="button" id="close_pop_up" class="cls_pup" onclick="ClosePopFactura();" />
                </li>
            </ul>
        </div>
        <!--titulos_azules-->
        <PdfViewer:PdfViewer ID="pdfViewerMyPreviewPDF" CssClass="PdfViewer" runat="server" Height="712" Width="1033"
            ClientIDMode="Static" ShowScrollbars="true" ShowToolbarMode="Show">
        </PdfViewer:PdfViewer>
        <!--content_fondo_blanco-->
    </div>
</asp:Panel>
<asp:HiddenField runat="server" Value="false" ID="hdnPopFactura" ClientIDMode="Static" />

