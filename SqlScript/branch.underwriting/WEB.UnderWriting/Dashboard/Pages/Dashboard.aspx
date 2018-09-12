<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="WEB.UnderWriting.Dashboard.Pages.Dashboard"
    MasterPageFile="~/Dashboard/Dashboard.Master" EnableEventValidation="false" %>

<%@ Register Src="~/Dashboard/UserControls/Common/Right.ascx" TagPrefix="uc1" TagName="Right" %>
<%@ Register Src="~/Dashboard/UserControls/Common/Bottom.ascx" TagPrefix="uc1" TagName="Bottom" %>
<%@ Register Src="~/Dashboard/UserControls/Common/Left.ascx" TagPrefix="uc1" TagName="Left" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="head">
    <script src="<%=ResolveClientUrl("~/Js/JSPages/Dashboard/Dashboard.js") %>"></script>
    <script type="text/javascript">
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_beginRequest(BeginRequestHandler);
        prm.add_endRequest(EndRequestHandler);
    </script>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Left">
    <div id="box-alerts" style="height: 478px;">
        <uc1:Left runat="server" ID="Left" />
    </div>
</asp:Content>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="Right">
    <div id="box-pol">
        <uc1:Right runat="server" ID="Right" />
    </div>
</asp:Content>

<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="Bottom">
    <div id="box-main" style="height: 485px;">
        <uc1:Bottom runat="server" ID="Bottom" />
    </div>
</asp:Content>


