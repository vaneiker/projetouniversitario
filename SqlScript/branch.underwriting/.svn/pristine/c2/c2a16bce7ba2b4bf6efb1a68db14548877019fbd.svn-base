<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCPDFPopup.ascx.cs" Inherits="WEB.ConfirmationCall.UserControls.Common.UCPDFPopup" %>
<%@ Register Assembly="PdfViewerAspNet" Namespace="PdfViewer4AspNet" TagPrefix="PdfViewer" %>
<asp:UpdatePanel ID="upPaymentPdfViewer" runat="server" style="z-index : 100000000;">
    <ContentTemplate>
        <div class="pop_up_wrapper" style="overflow-x: hidden; overflow-y: hidden">
            <!--escriben por style el ancho que desean-->
            <div class="titulos_azules head_contengridproxi PreviewPDF" style="width: 100%;">
                <ul>
                    <li style="position: absolute; left: 41%; top: 31%;">
                        <%--<asp:Literal ID="ltTypeDoc" Text="PDF Document Preview" ClientIDMode="Static" runat="server"></asp:Literal>--%>
                        <asp:Label ID="ltTypeDoc2" ClientIDMode="Static" runat="server"><%=RESOURCE.UnderWriting.NewBussiness.Resources.PrintPdfHeader %></asp:Label>
                    </li>
                    <li style="top: 13%;">
                        <input type="button" id="close_pop_up" class="cls_pup" onclick="$find('popupBhvr').hide();" />
                    </li>
                </ul>
            </div>

            <PdfViewer:PdfViewer ID="pdfViewerMyPreviewPDF" CssClass="PdfViewer" runat="server" Height="709" Width="1185"
                ClientIDMode="Static" ShowScrollbars="true" ShowToolbarMode="Show">
            </PdfViewer:PdfViewer>
                        </div>
         <%--   </div>--%>
    </ContentTemplate>
</asp:UpdatePanel>