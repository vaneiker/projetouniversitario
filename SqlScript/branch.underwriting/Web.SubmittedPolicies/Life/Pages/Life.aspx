<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Life.aspx.cs" Inherits="Web.SubmittedPolicies.Life.Pages.Life" MasterPageFile="~/SubmittedPolicies.Master" Async="true" %>

<%@ Register Src="~/Life/UserControls/Issue/IssueContainer.ascx" TagPrefix="uc1" TagName="IssueContainer" %>
<%@ Register Src="~/Life/UserControls/NeverIssued/NeverIssued.ascx" TagPrefix="uc2" TagName="NeverIssued" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="head">
    <script src="../../Js/Life.js"></script>
</asp:Content>
<asp:Content ID="Content" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:UpdatePanel runat="server" ID="upLife">
        <ContentTemplate>
            <div class="row emision_cont mB15">
                <!-- SUB-TABS -->
                <div class="col-12 mT10">
                    <div class="data_main cont_tabs">
                        <ul class="boton_result row">
                            <li id="liIssue" class="activo" runat="server">
                                <asp:LinkButton runat="server" ID="lnkIssue" Text="Emisión" OnClick="lnkIssue_OnClick"></asp:LinkButton>
                            </li>
                            <li id="liNeverIssued" class="" runat="server">
                                <asp:LinkButton runat="server" ID="lnkNeverIssued" Text="No Emitidas" OnClick="lnkNeverIssued_OnClick"> </asp:LinkButton>
                            </li>
                        </ul>
                        <!--GRID PRINCIPAL-->
                        <asp:MultiView runat="server" ID="mvLife" ActiveViewIndex="0">
                            <asp:View runat="server" ID="vIssue">
                                <uc1:IssueContainer runat="server" ID="UCIssueContainer" />
                            </asp:View>
                            <asp:View runat="server" ID="vNeverIssued">
                                <uc2:NeverIssued runat="server" ID="UCNeverIssued" />
                            </asp:View>
                        </asp:MultiView>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="lnkIssue" />
            <asp:AsyncPostBackTrigger ControlID="lnkNeverIssued" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
