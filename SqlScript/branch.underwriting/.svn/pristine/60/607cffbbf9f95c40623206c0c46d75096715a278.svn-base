<%@ Page Title="Listo para Revisar - Pólizas" Language="C#" MasterPageFile="~/Business.Master" AutoEventWireup="true" CodeBehind="ReadyToReview.aspx.cs" Inherits="WEB.NewBusiness.NewBusiness.Pages.ReadyToReview" %>

<%@ Register Src="~/NewBusiness/UserControls/ReadyToReview/WUCReadyToReview.ascx" TagPrefix="uc1" TagName="WUCReadyToReview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Scripts/JSPages/ReadyToReview/ReadyToReview.js"></script>    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">
   <script type="text/javascript">
       var prm = Sys.WebForms.PageRequestManager.getInstance();
       prm.add_beginRequest(BeginRequestHandler);
       prm.add_endRequest(EndRequestHandler);
    </script>
    <uc1:WUCReadyToReview runat="server" ID="WUCReadyToReview" />
</asp:Content>
