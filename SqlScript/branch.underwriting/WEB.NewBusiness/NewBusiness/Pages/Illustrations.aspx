<%@ Page Title="Bandeja" Language="C#" MasterPageFile="~/Business.Master" AutoEventWireup="true" CodeBehind="Illustrations.aspx.cs" Inherits="WEB.NewBusiness.NewBusiness.Pages.Illustrations" %>
<%@ Register Src="~/NewBusiness/UserControls/Illustration/WUCIllustrationsList.ascx" TagPrefix="uc1" TagName="WUCIllustrationsList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Scripts/JSPages/Illustration/IllustrationList.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">
    
    <script type="text/javascript">
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_beginRequest(BeginRequestHandler);
        prm.add_endRequest(EndRequestHandler);
    </script>
   
    <uc1:WUCIllustrationsList runat="server" ID="WUCIllustrationsList" />
    <asp:HiddenField runat="server" ID="LoginAgentId" ClientIDMode="static" Value="" />

</asp:Content>