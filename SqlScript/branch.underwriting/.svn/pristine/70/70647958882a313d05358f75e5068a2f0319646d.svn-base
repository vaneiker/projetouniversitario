<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Case.aspx.cs" Inherits="WEB.UnderWriting.Case.Pages.Case" MasterPageFile="~/Case.Master" EnableEventValidation="false" %>

<%@ Register Src="~/Case/UserControls/Common/Header.ascx" TagPrefix="uc1" TagName="Header" %>
<%@ Register Src="~/Case/UserControls/Common/Left.ascx" TagPrefix="uc1" TagName="Left" %>
<%@ Register Src="~/Case/UserControls/Common/Right.ascx" TagPrefix="uc1" TagName="Right" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="head">
    <script src="../../Js/JSPages/Cases/Cases.js" type="text/javascript"></script>    
</asp:Content>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="Header">
    <uc1:Header runat="server" ID="HeaderCase" />
</asp:Content>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Left">
    <asp:Panel runat="server" ID="pnLeftControl" Style="display: none" ClientIDMode="Static">
        <uc1:Left runat="server" ID="Left" />
    </asp:Panel>
</asp:Content>

<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="Right">
    <asp:Panel runat="server" ID="pnRightControl" Style="display: none" ClientIDMode="Static">
        <uc1:Right runat="server" ID="Right" />
    </asp:Panel>
</asp:Content>

<asp:Content ID="Content" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
      
</asp:Content>


