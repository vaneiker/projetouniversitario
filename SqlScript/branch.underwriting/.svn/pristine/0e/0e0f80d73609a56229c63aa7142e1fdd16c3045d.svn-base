<%@ Page Title="" Language="C#" MasterPageFile="~/Business.Master" AutoEventWireup="true" CodeBehind="IllustrationsLife.aspx.cs" Inherits="WEB.NewBusiness.NewBusiness.Pages.IllustrationsLife" %>

<%@ Register Src="~/NewBusiness/UserControls/Illustration/UCIllustrationsLifeList.ascx" TagPrefix="uc1" TagName="UCIllustrationsLifeList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Scripts/JSPages/Illustration/IllustrationList.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">

    <script type="text/javascript">
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_beginRequest(BeginRequestHandler);
        prm.add_endRequest(EndRequestHandler);
    </script> 
    <!-- Poner aqui el nuevo grid de illustraciones para la linea de negocios de vida-->
    <uc1:UCIllustrationsLifeList runat="server" id="UCIllustrationsLifeList" />

</asp:Content>

