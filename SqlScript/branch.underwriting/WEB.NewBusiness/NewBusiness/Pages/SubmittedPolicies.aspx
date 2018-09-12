<%@ Page Title="Someter Póliza" Language="C#" MasterPageFile="~/Business.Master" AutoEventWireup="true" CodeBehind="SubmittedPolicies.aspx.cs" Inherits="WEB.NewBusiness.NewBusiness.Pages.SubmittedPolicies" %>

<%@ Register Src="~/NewBusiness/UserControls/SubmittedPolicies/Common/WUCSearch.ascx" TagPrefix="uc1" TagName="WUCSearch" %>
<%@ Register Src="~/NewBusiness/UserControls/SubmittedPolicies/WUCSubmittedPolicies.ascx" TagPrefix="uc1" TagName="WUCSubmittedPolicies" %>
<%@ Register Src="~/NewBusiness/UserControls/SubmittedPolicies/Common/WUCFooter.ascx" TagPrefix="uc1" TagName="WUCFooter" %>
<%@ Register Src="~/NewBusiness/UserControls/SubmittedPolicies/WUCEffectivePendingReceipt.ascx" TagPrefix="uc1" TagName="WUCEffectivePendingReceipt" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Scripts/JSPages/SubmittedPolicies/SubmittedPolicies.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">
    <script type="text/javascript">
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_beginRequest(BeginRequestHandler);
        prm.add_endRequest(EndRequestHandler);
    </script>
    <div id="scroll_2" class="st-content-inner">
        <!--extra div para emular el left side fixed-->
        <!--CONTENIDO EMPIEZA AQUI-->
        <div class="main clearfix">
            <!--CONTENIDO DERECHA-->
            <div class="contenido_derecha management_mc">
                <div class="grid grid-pad">
                    <div class="col-1-1">
                        <div class="contenedor_tabs">
                            <ul id="MenuTabs" class="tabs_ttle dvddo_in_2">
                                <li class="active">
                                    <asp:LinkButton runat="server" ID="lnkSubmittedPolicies" OnClick="ManageTabs" ClientIDMode="Static" OnClientClick="BeginRequestHandler(this)"> <%=RESOURCE.UnderWriting.NewBussiness.Resources.SubmittedPoliciesLabel%> </asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton runat="server" ID="lnkEffectivePendingReceipt" OnClick="ManageTabs" ClientIDMode="Static" OnClientClick="BeginRequestHandler(this)"><%=RESOURCE.UnderWriting.NewBussiness.Resources.EffectivePendingReceipt%> </asp:LinkButton>
                                </li>
                            </ul>
                        </div>

                        <!--contenedor_tabs-->
                        <uc1:WUCSearch runat="server" ID="WUCSearch" />
                        <asp:MultiView runat="server" ID="mtvViews" ActiveViewIndex="0">
                            <asp:View runat="server" ID="vSubmittedPolicies">
                                <uc1:WUCSubmittedPolicies runat="server" ID="WUCSubmittedPolicies" />
                            </asp:View>
                            <asp:View runat="server" ID="vEffectivePendingReceipt">
                                <uc1:WUCEffectivePendingReceipt runat="server" ID="WUCEffectivePendingReceipt" />
                            </asp:View>
                        </asp:MultiView>
                        <uc1:WUCFooter runat="server" ID="WUCFooter" />
                    </div>
                    <!--grid grid-pad-->

                </div>
            </div>
        </div>
    </div>

    <asp:HiddenField runat="server" ID="hdnCurrentTabSubmittedPolicies" Value="lnkSubmittedPolicies" ClientIDMode="Static" />

</asp:Content>
