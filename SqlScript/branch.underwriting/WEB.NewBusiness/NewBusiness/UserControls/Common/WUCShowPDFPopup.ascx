<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUCShowPDFPopup.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.Common.WUCShowPDFPopup" %>
<%@ Register Assembly="PdfViewerAspNet" Namespace="PdfViewer4AspNet" TagPrefix="PdfViewer" %>
<div class="pop_up_wrapper" style="width: 1189px; height: 752px; overflow-x: hidden; overflow-y: hidden">
    <!--escriben por style el ancho que desean-->
    <div class="titulos_azules head_contengridproxi PreviewPDF" style="width: 100%;">
        <ul>
            <li style="position: absolute; left: 41%; top: 31%;">
                <%--<asp:Literal ID="ltTypeDoc" Text="PDF Document Preview" ClientIDMode="Static" runat="server"></asp:Literal>--%>
                <asp:Label ID="ltTypeDoc2" ClientIDMode="Static" runat="server"><%=RESOURCE.UnderWriting.NewBussiness.Resources.PrintPdfHeader %></asp:Label>
            </li>
            <li style="top: 13%;">
                <input type="button" id="close_pop_up" class="cls_pup" onclick="DiscardPreviewPDF()" />
            </li>          
        </ul>
    </div>
    <!--titulos_azules-->


    <PdfViewer:PdfViewer ID="pdfViewerMyPreviewPDF" CssClass="PdfViewer" runat="server" Height="712" Width="1186"
        ClientIDMode="Static" ShowScrollbars="true" ShowToolbarMode="Show">
    </PdfViewer:PdfViewer>

    <!--content_fondo_blanco-->
</div>
