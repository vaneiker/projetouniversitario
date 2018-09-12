<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PartialShowRequirementPdf.aspx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.AddNewClient.Requirements.PartialShowRequirementPdf" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Src="~/NewBusiness/UserControls/AddNewClient/Requirements/UCRequirementPdfPopUp.ascx" TagPrefix="uc1" TagName="UCRequirementPdfPopUp" %>
<%@ Register Assembly="PdfViewerAspNet" Namespace="PdfViewer4AspNet" TagPrefix="PdfViewer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <PdfViewer:PdfViewer ID="pdfViewerPdfPopUp" runat="server" ClientIDMode="Static" ShowScrollbars="true" ShowToolbarMode="Show" Width="900px" Height="800px">
    </PdfViewer:PdfViewer>
</body>
</html>
