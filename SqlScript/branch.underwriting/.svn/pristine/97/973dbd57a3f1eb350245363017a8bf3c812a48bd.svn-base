<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CasesNotSubmittedContainer.ascx.cs" Inherits="WEB.NewBusiness.DReview.UserControl.CasesNotSubmitted.CasesNotSubmittedContainer" %>
<%@ Register Src="~/DReview/UserControl/CasesNotSubmitted/CasesInProcess/WUCCasesInProcess.ascx" TagPrefix="uc1" TagName="WUCCasesInProcess" %>
<%@ Register Src="~/DReview/UserControl/CasesNotSubmitted/ReadyToreview/WUCReadyToReview.ascx" TagPrefix="uc1" TagName="WUCReadyToReview" %>
<div class="col-1-1">
    <div class="contenedor_tabs">
        <ul class="tabs_ttle dvddo_in_2" id="menuTabsCasesNotSubmitted">
            <li class="active">
                <asp:LinkButton runat="server" ID="lnkCasesInProcess" ClientIDMode="Static" OnClientClick="BeginRequestHandler()" OnClick="ManageTab"> <%=RESOURCE.UnderWriting.NewBussiness.Resources.CasesInProcessLabel.ToUpper() %></asp:LinkButton>
            </li>
            <li>
                <asp:LinkButton runat="server" ID="lnkReadyToReview" ClientIDMode="Static" OnClientClick="BeginRequestHandler()" OnClick="ManageTab"> <%=RESOURCE.UnderWriting.NewBussiness.Resources.ReadyToReviewLabel.ToUpper() %></asp:LinkButton>
            </li>
        </ul>
    </div>
    <!--contenedor_tabs-->
    <div class="fondo_gris">
        <div class="col-1-1">
            <div class="content_fondo_gris">
                <asp:MultiView runat="server" ID="mtvCasesNotSubmitted" ActiveViewIndex="0">
                    <asp:View runat="server" ID="vCasesInProcess">
                        <uc1:WUCCasesInProcess runat="server" ID="WUCCasesInProcess" />
                    </asp:View>
                    <asp:View runat="server" ID="vReadyToReview">
                        <uc1:WUCReadyToReview runat="server" ID="WUCReadyToReview" />
                    </asp:View>
                </asp:MultiView>
            </div>
            <!--content_fondo_gris-->
        </div>
        <!--col-1-1-->
    </div>
    <!--fondo gris-->
</div>
<asp:HiddenField runat="server" ID="hdnCurrentTabCasesNoSubmitted" ClientIDMode="Static" Value="lnkCasesInProcess" />
