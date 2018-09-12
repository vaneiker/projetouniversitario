<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCIllustrationContainer.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.Illustration.UCIllustrationContainer" %>
<%@ Register Src="~/NewBusiness/UserControls/Illustration/PlanInformation/UCPlanContainer.ascx" TagPrefix="uc1" TagName="UCPlanContainer" %>
<%@ Register Src="~/NewBusiness/UserControls/Illustration/Compare/UCCompareContainer.ascx" TagPrefix="uc1" TagName="UCCompareContainer" %>
<%@ Register Src="~/NewBusiness/UserControls/Illustration/UCIllustratorPreview.ascx" TagPrefix="uc1" TagName="UCIllustratorPreview" %>
<%@ Register Src="~/NewBusiness/UserControls/Illustration/UCHeaderIllustrationInformation.ascx" TagPrefix="uc1" TagName="UCHeaderIllustrationInformation" %>
<%@ Register Src="~/NewBusiness/UserControls/Illustration/EForm/UCFormsContainer.ascx" TagPrefix="uc1" TagName="UCFormsContainer" %>

<div id="frmHeaderIllustrationInformation">
    <uc1:UCHeaderIllustrationInformation runat="server" ID="UCHeaderIllustrationInformation" />
</div>
<!--accordion_tabulado-->
<asp:MultiView ID="mvIllustrator" runat="server">
    <asp:View ID="VPlanInformation" runat="server">
        <uc1:UCPlanContainer runat="server" ID="UCPlanContainer" />
    </asp:View>
    <asp:View ID="vCompare" runat="server">
        <uc1:UCCompareContainer runat="server" ID="UCCompareContainer" />
    </asp:View>
    <asp:View ID="VPreview" runat="server">
        <uc1:UCIllustratorPreview runat="server" ID="UCIllustratorPreview" />
    </asp:View>
    <asp:View ID="vEform" runat="server">
        <uc1:UCFormsContainer runat="server" ID="UCFormsContainer" />
    </asp:View>
</asp:MultiView>

