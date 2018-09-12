<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUCEquifax.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.Common.WUCEquifax" %>
<%@ Register Assembly="PdfViewerAspNet" Namespace="PdfViewer4AspNet" TagPrefix="PdfViewer" %>
<asp:UpdatePanel runat="server" style="padding: 8px; height: 711px;" UpdateMode="Conditional" ID="udpTransunion">
    <ContentTemplate>
        <PdfViewer:PdfViewer ID="pdfViewerEquifax" CssClass="PdfViewer" runat="server" Height="900" Width="1186" ClientIDMode="Static" ShowScrollbars="true" ShowToolbarMode="Show" PageFitMode="Fit">
        </PdfViewer:PdfViewer>
    </ContentTemplate>
</asp:UpdatePanel>
