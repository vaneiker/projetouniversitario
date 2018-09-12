<%@ Page Title="Revision de Datos" Language="C#" MasterPageFile="~/DReviewMaster.Master" AutoEventWireup="true" CodeBehind="DReview.aspx.cs" Inherits="WEB.NewBusiness.DReview.Pages.DReview" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Src="~/NewBusiness/UserControls/AddNewClient/WUCSearchClientOrOwner.ascx" TagPrefix="uc1" TagName="WUCSearchClientOrOwner" %>
<%@ Register Src="~/DReview/UserControl/DReview/DReviewContainer.ascx" TagPrefix="uc1" TagName="DReviewContainer" %>
<%@ Register Src="~/NewBusiness/UserControls/AddNewClient/HealthDeclaration/UCGridViewPopup.ascx" TagPrefix="uc1" TagName="UCGridViewPopup" %>
<%@ Register Src="~/DReview/UserControl/CasesNotSubmitted/CasesNotSubmittedContainer.ascx" TagPrefix="uc1" TagName="CasesNotSubmittedContainer" %>
<%@ Register Src="~/DReview/UserControl/HistoricalCases/HistoricalCasesContainer.ascx" TagPrefix="uc1" TagName="HistoricalCasesContainer" %>
<%@ Register Src="~/DReview/UserControl/Common/WUCView.ascx" TagPrefix="uc1" TagName="WUCView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/JsPages/DReview.js"></script>
    <script src="../js/JsPages/DropDownScript.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">
    <script type="text/javascript">
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_beginRequest(BeginRequestHandler);
        prm.add_endRequest(EndRequestHandler);
    </script>
    <asp:UpdatePanel UpdateMode="Conditional" runat="server" ID="udpViews" ChildrenAsTriggers="true" >
        <ContentTemplate>
            <asp:MultiView ID="mtvPrincipal" runat="server" ActiveViewIndex="0">
                <asp:View runat="server" ID="Data" >
                    <asp:MultiView runat="server" ActiveViewIndex="0" ID="mtvMenuSup" >
                        <asp:View runat="server" ID="vDataReview" >
                            <uc1:DReviewContainer runat="server" ID="DReviewContainer"  />                          
                        </asp:View>
                        <asp:View runat="server" ID="vHistoricalCases">
                            <uc1:HistoricalCasesContainer runat="server" ID="HistoricalCasesContainer" />
                        </asp:View>
                        <asp:View runat="server" ID="vCasesNotSubmitted">
                            <uc1:CasesNotSubmittedContainer runat="server" ID="CasesNotSubmittedContainer" />
                        </asp:View>
                        <asp:View runat="server" ID="vAdministrator">
                            <h1>Comming</h1>
                        </asp:View>
                    </asp:MultiView>
                </asp:View>
                <asp:View runat="server" ID="View">
                    <uc1:WUCView runat="server" ID="WUCView" />
                </asp:View>
            </asp:MultiView>
        </ContentTemplate>        
        <%--<Triggers>
                            <asp:AsyncPostBackTrigger ControlID="bodyContent_DReviewContainer_WUCPopMergeCases_btnSave" EventName="Click"/> 
                            </Triggers>--%>
    </asp:UpdatePanel>
    <dx:ASPxPopupControl ID="popSearchClientOrOwner" ClientInstanceName="popSearchClientOrOwner" EncodeHtml="false" runat="server" PopupHorizontalAlign="WindowCenter" ShowCloseButton="true" ShowHeader="true" Modal="True" PopupVerticalAlign="WindowCenter"
        ShowOnPageLoad="False" AllowDragging="true" ClientIDMode="Static" CloseAction="CloseButton" ClientSideEvents-Closing="CloseSearchClientOrOwner()">
        <ClientSideEvents Closing="function(s, e) {CloseSearchClientOrOwner();}" />
        <Windows>
            <dx:PopupWindow Name="ClientOwnerSearch" Modal="true" Width="800px" Height="500px">
                <ContentCollection>
                    <dx:PopupControlContentControl runat="server">
                        <uc1:WUCSearchClientOrOwner runat="server" ID="WUCSearchClientOrOwner" />
                    </dx:PopupControlContentControl>
                </ContentCollection>
            </dx:PopupWindow>
        </Windows>
    </dx:ASPxPopupControl>
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="udpAddNewClient">
        <ContentTemplate>
            <asp:HiddenField runat="server" ID="hdnShowPopClientInfoSearch" ClientIDMode="Static" Value="false" />
            <asp:HiddenField runat="server" ID="hdnValidate" Value="true" ClientIDMode="Static" />
            <asp:HiddenField runat="server" ID="hdnIsView" ClientIDMode="Static" Value="false" />
            <asp:HiddenField runat="server" ClientIDMode="static" ID="hdnPopAnswerPadecimiento" Value="false" />
            <asp:HiddenField runat="server" ID="containerMessage" Value="body" ClientIDMode="Static" />
            <asp:HiddenField runat="server" ID="hfisFuneral" Value="" ClientIDMode="Static" />
            <asp:HiddenField runat="server" ID="hfProdutLine" Value="" ClientIDMode="Static" />               
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:ModalPopupExtender ID="ModalPopupPadecimiento" PopupControlID="pnPadecimiento" BackgroundCssClass="modalPopup2" TargetControlID="hfPadecimiento" BehaviorID="popupPadecimiento" runat="server"></asp:ModalPopupExtender>
    <asp:Panel runat="server" ID="pnPadecimiento" ClientIDMode="Static">
        <uc1:UCGridViewPopup runat="server" ID="UCGridViewPopup" />
    </asp:Panel>
    <asp:HiddenField runat="server" ID="hfPadecimiento" ClientIDMode="Static"/> 
</asp:Content>
