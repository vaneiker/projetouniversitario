<%@ Page Title="Bandeja Vida" Language="C#" MasterPageFile="~/Business.Master" AutoEventWireup="true" CodeBehind="CasesInProcess.aspx.cs" Inherits="WEB.NewBusiness.NewBusiness.Pages.CasesInProcess" %>

<%@ Register Src="~/NewBusiness/UserControls/CasesInProcess/WUCCasesInProcess.ascx" TagPrefix="uc1" TagName="WUCCasesInProcess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">    
    <script src="../../Scripts/JSPages/CasesInProcess/CasesInProcess.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">
     <script type="text/javascript">
         var prm = Sys.WebForms.PageRequestManager.getInstance();
         prm.add_beginRequest(BeginRequestHandler);
         prm.add_endRequest(EndRequestHandler);
    </script>
    <uc1:WUCCasesInProcess runat="server" ID="WUCCasesInProcess" />    
</asp:Content>
